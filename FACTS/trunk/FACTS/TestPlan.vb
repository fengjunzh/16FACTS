Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.IO
Imports FACTS
Imports FACTS.Model
Imports C1.Win.C1FlexGrid
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports Sunisoft.IrisSkin
Imports C1.Win.C1Chart
Imports System.ComponentModel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports FACTS.BLL

Public Class TestPlan
    Private SW_Version As String = "1.0"
    Private ConnFile As String = "FACTS.xmls"
    Private ConnStr As String
    Private DataFolder As String = String.Format("{0}\TestData", My.Application.Info.DirectoryPath)
    Private CalFolder As String = String.Format("{0}\CalData", gCfgFolder)
    Private SettingFileName As String = "BenchSetting.xml"
    Private AbortFlag As Boolean
    Private IVIV As IVIAVI
    Public TestPhase As TestPhaseRlIl
    Private CalValid As Boolean = True
    Private DebugMode As Boolean
    Private RepeatPhase As Boolean
    'Private PassStr As String = "P"
    'Private FailStr As String = "F"
    'Private AbortStr As String = "A"
    Private LogFile As String = "log.txt"
    Private MeasResDic As Dictionary(Of String, CMeasRessult)
    Public TestRes As TestResult = Nothing
    Public product_main As Model.product_main = Nothing
    Public Spec As TestSpec = Nothing
    Private Delegate Sub DelLiveDisplay(ByVal ti As TestItem)
    Private StopLiveDisplay As Boolean
    Private SN1, SN2 As String
    Private MessageShowed As Boolean
    Public Sub InitializeGui()
        Try
            GUI = New FormGUI

            Dim folder As String = My.Application.Info.DirectoryPath
            Environment.CurrentDirectory = folder

            With My.Application.Info.Version
                SW_Version = String.Format("{0}.{1}.{2}.{3}", .Major, .Minor, .Build, .Revision)
            End With
            GUI.SW_Version = SW_Version
            GUI.SW_Name = "Fiber Assembly RL/IL Test Enviroment"

            GUI.Show()

            If My.Computer.FileSystem.DirectoryExists(gCfgFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(gCfgFolder)
            End If

            Dim cfgfile As String = String.Format("{0}\{1}", gCfgFolder, ConnFile)

            Dim src_connfile As New CATS_XML(ConnFile)
            Dim dest_connfile As New CATS_XML(cfgfile)

            If src_connfile > dest_connfile AndAlso My.Computer.FileSystem.FileExists(ConnFile) Then
                File.Copy(ConnFile, cfgfile, True)
            End If

            If My.Computer.FileSystem.FileExists(cfgfile) = False Then
                Throw New Exception(String.Format("The file '{0}' not found!", ConnFile))
            End If

            dest_connfile = Nothing
            dest_connfile = New CATS_XML(cfgfile)
            ConnStr = dest_connfile.ConnString

            Dim serverName As String = String.Empty
            Dim database As String = String.Empty
            Dim reg As Regex = New Regex("Data Source=(\S+)")
            Dim match As Match = reg.Match(ConnStr.Split(";")(0))
            If match.Success Then serverName = match.Groups(1).Value.ToUpper
            reg = New Regex("Initial Catalog=(\S+)")
            match = reg.Match(ConnStr.Split(";")(1))
            If match.Success Then database = match.Groups(1).Value.ToUpper
            GUI.Database = String.Format("{0}_{1}", serverName, database)

            Dim CatsConn As New FACTS.BLL.CATSManager
            CatsConn.ActivateCATS(ConnStr)

            Dim factoryName As String = dest_connfile.Location

            Dim factoryM As FACTS.Model.factory
            Dim factoryBll As New FACTS.BLL.factoryManager
            factoryM = factoryBll.SelectByFactory(factoryName)
            GUI.Factory = factoryM.name
            GUI.Plant_Code = factoryM.code

            If My.Computer.FileSystem.DirectoryExists(DataFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(DataFolder)
            End If

            If My.Computer.FileSystem.DirectoryExists(CalFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(CalFolder)
            End If

            If My.Computer.FileSystem.DirectoryExists(gLocalSpecFolder) = False Then
                My.Computer.FileSystem.CreateDirectory(gLocalSpecFolder)
            End If

            factoryName = dest_connfile.Location

            gBenchSetting = CBenchSetting.CreateInstance(gBenchSettingFileName)
            If gBenchSetting Is Nothing Then
                Dim BenSet As New FormBenchSetting
                BenSet.ShowDialog()
            End If

            gBenchSetting = CBenchSetting.CreateInstance(gBenchSettingFileName)
            If gBenchSetting IsNot Nothing Then
                GUI.Mode_Name = gBenchSetting.TestMode
                GUI.SAP_Fail_Safe_Mode = gBenchSetting.SAPFailSafeMode
                GUI.Factory = factoryName
                GUI.TestType = gBenchSetting.TestType
                GUI.RetryCount = gBenchSetting.RetryCount
                If gBenchSetting.RecJumperCalType = numJumperCalType.NA Then gBenchSetting.RecJumperCalType = numJumperCalType.Simulate
            End If

            If gBenchSetting.LiveMode = False Then
                GUI.CollapseLiveModePanel = True
            Else
                GUI.CollapseLiveModePanel = False
            End If

            InitializeCalibrateIO()

            GUI.InstrumentReady = "Not Ready"

            GUI.ShowSetup()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Initialize GUI Error")
            End
        End Try
    End Sub
    Public Function CheckSN(ByVal GUI_SN1 As String, GUI_SN2 As String, ByVal GUI_PN As String, Optional ByVal WO As String = "600123") As Boolean
        Try
            GUI.ClearStatusMsg()
            AbortFlag = False

            gBenchSetting = CBenchSetting.CreateInstance(SettingFileName)
            If gBenchSetting Is Nothing Then Throw New Exception("No Bench Setting!")

            SN1 = GUI_SN1.ToUpper
            SN2 = GUI_SN2.ToUpper

            If SN1 = String.Empty Then
                MsgBox("Serial Number is empty!", MsgBoxStyle.Critical)
                Return False
            End If

            If gBenchSetting.TestType = numTestType.Connector Then
                If SN2 = String.Empty Then
                    MsgBox("Serial Number 2 is empty!", MsgBoxStyle.Critical)
                    Return False
                End If
            End If

            Dim PN As String = GUI_PN.ToUpper
            If PN = String.Empty Then
                If MsgBox("Part Number is empty!" & vbNewLine & "Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Return False
                End If
            End If

            Dim sw As New Stopwatch
            sw.Start()

            ' Init test
            TestRes = New TestResult(gBenchSetting.Program)

            If CheckSnPn(SN1, PN, WO) = False Then Return False
            If SN2.Length > 0 Then
                If CheckSnPn(SN2, PN, WO) = False Then Return False
            End If

            gFamily = [Enum].Parse(GetType(numFamily), product_main.Family)
            gConnectorFamily = GetConnectorType()

            ' Load Db test spec and update local spec
            Dim cq_modes As Model.cq_modes = Nothing
            If LoadTestSpec(cq_modes) = False Then Return False

            ' Check if phase station exists for a product at a specific mode
            ' Table Name: product_mode_phase_station
            If CheckPhaseStation(cq_modes, PN) = False Then Return False

            sw.Stop()
            AddStatusMsg(String.Format("Load Test SPEC time = {0} ms", sw.ElapsedMilliseconds()))

            If Spec.TestPhaseList Is Nothing OrElse Spec.TestPhaseList.Count = 0 Then
                AddStatusMsg("No test phase found!")
                Return False
            End If

            ' Write head of test result
            WriteTestResHead(SN1, WO, cq_modes.product_mode_id)

            LoadGuiTestSpec()

            LoadTestData(SN1, PN, GUI.SelectedPhaseName)

            Dim status As String = LoadTestStatus(SN1, PN, GUI.SelectedPhaseName)

            If status IsNot Nothing Then
                GUI.txtSN1.ForeColor = Color.White
                GUI.txtSN1.BackColor = IIf(status = "P", Color.Green, Color.Red)
            End If

            status = LoadTestStatus(SN2, PN, GUI.SelectedPhaseName)

            If status IsNot Nothing Then
                GUI.txtSN2.ForeColor = Color.White
                GUI.txtSN2.BackColor = IIf(status = "P", Color.Green, Color.Red)
            End If

            DisplayWoInfo(WO)

            Return True
        Catch ex As Exception
            MsgBox("TestPlan.CheckSN()::" & vbCrLf & " at " & ex.ToString, MsgBoxStyle.Exclamation, "Check SN Error")
            Return False
        End Try
    End Function
    Private Sub DisplayWoInfo(wo As String)
        Try
            If Not GUI.ckLoadPFQ.Checked Then Return
            If wo = "600123" Then Return
            If wo.Length = 0 Then Return
            If wo.StartsWith("00") Then wo = wo.Substring(2)
            GUI.Cursor = Cursors.WaitCursor
            Dim TotalNum As Integer
            Dim PNum As Integer
            Dim FNum As Integer
            Dim cq_pswBll As New cq_product_sn_woManager
            Dim cq_pswML As List(Of cq_product_sn_wo) = cq_pswBll.SelectAllByWo(wo)
            If cq_pswML Is Nothing Then Return
            Dim lstPhaseStatus As List(Of FACTS.Model.cq_phases_status)
            Dim cq_phstatus As New FACTS.BLL.cq_phases_statusManager
            For Each cq_pswM As cq_product_sn_wo In cq_pswML
                lstPhaseStatus = cq_phstatus.SelectAll(cq_pswM.product_name, cq_pswM.product_serial_num, gBenchSetting.TestMode, gBenchSetting.TestPhaseStationMainId)
                If lstPhaseStatus Is Nothing Then Continue For
                If GUI.SelectedPhaseName Is Nothing Then Continue For
                cq_pswM.phase_status = lstPhaseStatus.Find(Function(o) o.phase = GUI.SelectedPhaseName).phase_status
                TotalNum += 1
                If cq_pswM.phase_status = numPFAState.P.ToString Then
                    PNum += 1
                Else
                    FNum += 1
                End If
            Next
            TotalNum = cq_pswML.Count
            GUI.TotalTest = TotalNum
            GUI.PF = String.Format("{0}/{1}", PNum, FNum)
            GUI.Cursor = Cursors.Default
        Catch ex As Exception
            GUI.Cursor = Cursors.Default
            Throw New Exception("TestPlan.DisplayWoInfo()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Public Sub RunTest(ByVal SN1 As String, ByVal SN2 As String, ByVal _TestPhase As String, ByVal _DebugMode As Boolean, ByRef Cancel As Boolean)
        Dim SaveFile As Boolean = True
        DebugMode = _DebugMode
        AbortFlag = False
        Try
            TestRes.Head.MeasStartTime = Now

            ' Get testphase(RL_ISO/CAPE) based on selected test phase
            Dim TstPhase As TestPhase = Spec.PhaseByName(_TestPhase)
            TestPhase = TryCast(TstPhase, TestPhaseRlIl)
            If TestPhase Is Nothing Then
                MsgBox("Testphase is nothing" & _TestPhase, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            For Each group As TestGroup In TestPhase.TestGroupList
                If group.Selected = False Then
                    SaveFile = False
                    Exit For
                Else
                    For Each item As TestItem In group.TestItemList
                        If item.Selected = False Then
                            SaveFile = False
                            Exit For
                        End If
                    Next
                End If
            Next

            ' Check antenna switch port index mapping
            Dim AntSwitchSettingFileName As String = String.Format("{0}\{1}.xml", My.Application.Info.DirectoryPath, "SwitchPortMapping")
            gAntSwmPortMapping = CSwitchPortMapping.CreateInstance(AntSwitchSettingFileName)

#If Simulate Then
#Else
            IVIV = TryCast(pInstCtrl, IVIAVI)
            IVIV.AverageTime = 1
            ' Disable Zone 1 and 2
            IVIV.ORLSetup(1) = "0"
            IVIV.ORLSetup(2) = "0"
            ' Setup ORL Zone
            IVIV.ORLSetup(1) = "1,1,-0.5,0.5"
            If GUI.SelectedPhaseName = "System" Then
                IVIV.ORLSetup(2) = "1,2,-0.5,0.5"
            End If
            ' Check Cal file validate
            If CheckCalibrationFile(SaveFile) = False Then Return
#End If

            ' Write RET/Instrument info
            WriteTestRes()

            With TestRes.Head
                .SetupTime = Now.Subtract(.MeasStartTime).TotalSeconds
            End With

            ' Clear test result
            GUI.ClearTestResults()
            'TestRes.TestPhase.TestGroups.Clear()
            MeasResDic = New Dictionary(Of String, CMeasRessult)

            ' Run group test
            MessageShowed = False
            DoGroupTest()

        Catch cancelEx As OperationCanceledException
            Cancel = True
            SaveFile = False
            MsgBox("Test Cancelled", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Cancel")
        Catch ex As Exception
            'This error handler catches the 'abort' exception as well as any other unhandled exceptions
            AbortFlag = True
            Cancel = True
            SaveFile = False
            MsgBox("Test Aborted", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Abort")
        Finally

            With TestRes.Head
                If AbortFlag Then
                    .MeasStatus = numPFAState.A.ToString
                    GUI.SetStepStatus(GUI.SelectedPhaseName, 4)
                Else
                    .MeasStatus = TestRes.GetFinalPassFailStatus(TestPhase.TestGroupList.Count).ToString
                End If
                .MeasStopTime = Now
                .TotalTime = .MeasStopTime.Subtract(.MeasStartTime).TotalSeconds
            End With

#If Simulate Then
            SaveFile = False
#End If
            SaveTestRes(SaveFile)

            Dim log As String = vbCrLf & TestRes.Head.MeasStartTime & vbCrLf & SN1 & SN2 & vbCrLf & GUI.LogMessage
            SaveLogToFile(log, LogFile)
        End Try
    End Sub
    Private Sub SaveLogToFile(ByVal log As String, ByVal filename As String)
        Dim MaxLine As Long = 100000

        If File.Exists(filename) Then
            Dim ls() As String = File.ReadAllLines(filename)
            If ls.Length > MaxLine Then
                File.WriteAllLines(filename, ls.Skip(MaxLine \ 2).ToArray)
            End If
        End If
        My.Computer.FileSystem.WriteAllText(filename, log, True)

    End Sub
    Public Sub SaveTestRes(saveFile As Boolean)
        Try
            ' Save result normally
            If AbortFlag = True Then Return
            If TestRes.TestPhase.TestGroups.Count = 0 Then Return
            Dim dlgRes As DialogResult
            If saveFile = False Then dlgRes = MsgBox("Do you want to upload test data to database?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Upload Test Data")
            If dlgRes = DialogResult.No Then Return

            TestRes.SaveToFile(String.Format("{0}\{1}!{2:yyyyMMddHHmmss}!{3}!{4}!{5}", DataFolder, TestRes.Head.SerialNumber, Now, gBenchSetting.TestMode, product_main.Product_name, GUI.SelectedPhaseName), True, True)
            If SN2.Length > 0 Then
                Threading.Thread.Sleep(2000)
                TestRes.Head.SerialNumber = SN2
                TestRes.SaveToFile(String.Format("{0}\{1}!{2:yyyyMMddHHmmss}!{3}!{4}!{5}", DataFolder, TestRes.Head.SerialNumber, Now, gBenchSetting.TestMode, product_main.Product_name, GUI.SelectedPhaseName), True, False)
                Dim snrBll As New BLL.serial_number_relationManager
                Dim snrM As New serial_number_relation
                With snrM
                    .Serial_number_1 = SN1
                    .Serial_number_2 = SN2
                    .Register_datetime = Now
                End With
                snrBll.Add(snrM)
            End If
        Catch ex As Exception
            Throw New Exception("TestPlan.SaveTestRes()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub DoGroupTest()
        Try
            Dim connecttime As Integer = 0
            Dim meastime As Integer = 0
            Dim groupName As String = ""
            Do
                GUI.SetStepStatus(GUI.SelectedPhaseName, 1)
                RepeatPhase = False
                For Each group As TestGroup In TestPhase.TestGroupList

                    Dim resTg As CTestGroup
                    If TestRes.TestPhase.TestGroups.Exists(Function(o) o.GroupName = group.Name) Then
                        resTg = TestRes.TestPhase.TestGroups.Find(Function(o) o.GroupName = group.Name)
                        For Each resTi In resTg.TestItems
                            resTi.Gen1 = 0
                        Next
                    End If

                    If group.Selected = False Then Continue For

                    Dim tgres As CTestGroup
                    If TestRes.TestPhase.TestGroups.Exists(Function(o) o.GroupName = group.Name) Then
                        tgres = TestRes.TestPhase.TestGroups.Find(Function(o) o.GroupName = group.Name)
                    Else
                        tgres = New CTestGroup(group)
                        TestRes.TestPhase.TestGroups.Add(tgres)
                    End If

                    tgres.GroupStatus = numPFAState.F.ToString

                    Try
                        RunTestGroup(group, tgres, groupName)
                        connecttime += group.ConnectTime
                        meastime += group.MeasTime
                        If RepeatPhase = True Then Exit For
                    Catch cancelEx As OperationCanceledException
                        GUI.SetGroupStatus(group.Name, 4)
                        Throw New OperationCanceledException("Test Cancelled!")
                    Catch ex As Exception
                        Throw New Exception(ex.ToString)
                    End Try
                Next
            Loop While (RepeatPhase = True)

            With TestRes.Head
                .ConnectTime = connecttime
                .MeasTime = meastime
            End With
        Catch ex As Exception
            Throw New Exception("TestPlan.DoGroupTest()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub RunTestGroup(ByVal group As TestGroup, ByVal tgres As CTestGroup, ByRef groupName As String)
        Dim startMeas As DateTime = Now
        Try
            GUI.SetGroupStatus(group.Name, 1)
            AddStatusMsg(group.Name & " ... Start")

            Dim showMsgList As New List(Of String)
            Dim startconn As DateTime = Now
            Dim repeatGroup As Boolean
            Dim retryCount As Integer = gBenchSetting.RetryCount + 1
            Dim continueTest As Boolean = False

            ' Group channel setup
#If Simulate Then
#Else
            SetupMeasurement(group)
#End If
            Dim channel As Integer
            channel = group.Channel
            If gAntSwmPortMapping IsNot Nothing Then
                channel = gAntSwmPortMapping.PortMapList.Find(Function(o) o.FiberId = channel).SwitchPortId
            End If

            Select Case gConnectorFamily
                Case numConnFamily.DUAL_MPO
                    If gBenchSetting.TestType = numTestType.System Then
                        If MessageShowed = False Then
                            If group.FirstTestItem.message.Length > 0 Then
                                showMsgList.Add(group.FirstTestItem.message)
                            Else
                                showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                            End If
                            MessageShowed = True
                        End If
                    Else
                        If MessageShowed = False Or (group.Name.EndsWith("1_B") And group.FirstTestItem.fiber = 1) Then
                            If group.FirstTestItem.message.Length > 0 Then
                                showMsgList.Add(group.FirstTestItem.message)
                            Else
                                showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                            End If
                            MessageShowed = True
                        End If
                    End If
                Case numConnFamily.SINGLE_MPO
                    If group.Name.Contains("_A") Then
                        showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                    Else
                        If MessageShowed = False Then
                            showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                            MessageShowed = True
                        End If
                    End If
                Case Else
                    If GUI.SelectedPhaseName = "System" Or gBenchSetting.TestType = numTestType.Pigtail Then
                        If product_main.Fiber_per_subunit > 2 Then
                            If group.FirstTestItem.fiber = 1 Then
                                showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                            End If
                            If group.FirstTestItem.message.Length > 0 Then
                                showMsgList.Add(group.FirstTestItem.message)
                            End If
                        Else
                            If gBenchSetting.TestType = numTestType.Pigtail Then
                                If MessageShowed = False Then
                                    showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                                    MessageShowed = True
                                End If
                            Else
                                showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                            End If
                        End If
                    Else
                        showMsgList.Add(String.Format("Please Switch to MTJ{0} at Channel {1}", channel, channel))
                    End If
            End Select

            If showMsgList.Count > 0 Then
                Dim frmPrompt As New FormConnectPrompt()
                frmPrompt.TextContent = String.Join(vbCrLf, showMsgList)

                StopLiveDisplay = False
                Dim dgRun As New DelLiveDisplay(AddressOf LiveDisplay)
                Dim res As IAsyncResult = dgRun.BeginInvoke(group.FirstTestItem, Nothing, Nothing)

                frmPrompt.ShowDialog()

                If frmPrompt.DialogResult = MsgBoxResult.Cancel Then
                    AbortFlag = True
                End If
                My.Application.DoEvents()

                StopLiveDisplay = True
                dgRun.EndInvoke(res)
            End If

            Do
                repeatGroup = False
                retryCount -= 1
                For Each item As TestItem In group.TestItemList

                    If item.Selected = False Then Continue For

                    GUI.SetTestItemStatus(item.Name, 1)
                    My.Application.DoEvents()

                    If groupName <> group.Name Then
                        group.ConnectTime = Now.Subtract(startconn).TotalSeconds
                        groupName = group.Name
                    End If

                    If AbortFlag Then
                        GUI.SetTestItemStatus(item.Name, 4)
                        Threading.Thread.Sleep(1000)
                        Throw New Exception("Test Aborted")
                    End If

                    Dim tires As CTestItem
                    If tgres.TestItems.Exists(Function(o) o.Name = item.Name) Then
                        tires = tgres.TestItems.Find(Function(o) o.Name = item.Name)
                        tires.Traces.Clear()
                        tires.TestExtend.MeasValue.Clear()
                    Else
                        tires = New CTestItem(item)
                        tgres.TestItems.Add(tires)
                    End If

                    tires.MeasStatus = numPFAState.F.ToString

                    Try
                        RunTestItem(item, tires)
                        RetryTest(tires, retryCount, item, group, repeatGroup, continueTest)
                        If repeatGroup Then
                            Exit For
                        ElseIf RepeatPhase Then
                            Exit Do
                        ElseIf continueTest Then
                            Continue For
                        End If
                    Catch cancelEx As OperationCanceledException
                        Throw New OperationCanceledException("Test Cancelled!")
                    Catch ex As Exception
                        Throw New Exception(ex.Message)
                    End Try
                Next
            Loop While (repeatGroup = True)

        Catch cancelEx As OperationCanceledException
            Throw New OperationCanceledException("Test Cancelled!")
        Catch ex As Exception
            AddStatusMsg(String.Format("RunTestGroup() - {0}", ex.Message))
            Throw New Exception(ex.Message)
        Finally
            Dim Status As Boolean = TestRes.GetGroupStatus(group.Name)

            If AbortFlag Then
                GUI.SetGroupStatus(group.Name, 4)
            Else
                If Status Then
                    GUI.SetGroupStatus(group.Name, 2)
                Else
                    GUI.SetGroupStatus(group.Name, 3)
                End If
            End If

            If AbortFlag Then
                tgres.GroupStatus = numPFAState.A.ToString
            Else
                tgres.GroupStatus = IIf(Status, numPFAState.P.ToString, numPFAState.F.ToString)
            End If

            group.MeasTime = Now.Subtract(startMeas).TotalSeconds - group.ConnectTime

            AddStatusMsg(String.Format("{0} ... Stop, {1} s", group.Name, group.MeasTime))

        End Try
    End Sub
    Private Sub LiveDisplay(ti As TestItem)
        Try
            If gBenchSetting.LiveMode = False Then Return
#If Simulate Then
            Return
#End If
            Dim channel, wavelength, il, orl, power As String
            channel = ti.ParentGroup.Channel
            'wavelength = ti.wave_length
            Dim valStr As String
            Dim val() As String
            With IVIV
                'If .MeasState = MeasState.IDLE Then .MeasStart()
                '.Channel = channel
                '.Wavelength = wavelength
                .LiveMode = 1
                'channel = .Channel
                wavelength = ti.ParentGroup.WavelengthList.Last
                Do While Not StopLiveDisplay
                    valStr = .LiveModeValue
                    If valStr Is Nothing Then
                        'If .MeasState = MeasState.IDLE Then .MeasStart()
                        .LiveMode = 1
                        Continue Do
                    End If
                    If valStr.Length = 0 Then
                        'If .MeasState = MeasState.IDLE Then .MeasStart()
                        .LiveMode = 1
                        Continue Do
                    End If
                    val = valStr.Split(vbLf)
                    il = val(0)
                    If il.Contains("---") Then
                        'If .MeasState = MeasState.IDLE Then .MeasStart()
                        .LiveMode = 1
                        Continue Do
                    End If
                    orl = val(1)
                    power = val(2)
                    If power.Contains("---") Then
                        'If .MeasState = MeasState.IDLE Then .MeasStart()
                        .LiveMode = 1
                        Continue Do
                    End If
                    GUI.DisplayLiveValue(channel, wavelength, il, orl, power)
                    Application.DoEvents()
                Loop
            End With
        Catch ex As Exception
            Throw New Exception("TestPlan.RunTestGroup.LiveDisplay()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub RetryTest(tires As CTestItem, retryCount As Integer, item As TestItem, group As TestGroup, ByRef repeatGroup As Boolean, ByRef continueTest As Boolean)
        Try
            'If tires.MeasStatus = FailStr And retryCount > 0 And Not item.Name.Contains("LEN") Then
            If tires.MeasStatus = numPFAState.F.ToString And retryCount > 0 Then
                Dim dgRun As DelLiveDisplay = Nothing
                Dim Res As IAsyncResult = Nothing
                If gBenchSetting.LiveMode Then
                    StopLiveDisplay = False
                    dgRun = New DelLiveDisplay(AddressOf LiveDisplay)
                    Res = dgRun.BeginInvoke(group.FirstTestItem, Nothing, Nothing)
                End If
                Dim frmRetry As New FormRetry(item, tires, TestRes, product_main, TestPhase, Spec)
                frmRetry.ShowDialog()
                Select Case frmRetry.ReturnTestType
                    Case 0 ' Retry Test
                        If frmRetry.ReturnRetryType = 0 Then 'Rety current group
                            Dim key As String
                            For Each wl As String In group.WavelengthList
                                key = String.Format("{0}_{1}", group.Name, wl)
                                If MeasResDic.ContainsKey(key) Then MeasResDic.Remove(key)
                            Next
                            GUI.ClearGroupTestResults(group.Name)
                            repeatGroup = True
                        ElseIf frmRetry.ReturnRetryType = 1 Then 'Retry from first test item
                            MeasResDic = New Dictionary(Of String, CMeasRessult)
                            GUI.ClearTestResults()
                            RepeatPhase = True
                        End If
                    Case 1 ' Contine Test
                        continueTest = True
                    Case 2 ' Exit Test
                        Throw New OperationCanceledException("Test Cancelled!")
                End Select
                If gBenchSetting.LiveMode Then
                    StopLiveDisplay = True
                    dgRun.EndInvoke(Res)
                End If
            End If
        Catch ex As Exception
            Throw New Exception("TestPlan.RunTestGroup.RetryTest() Then :
                " & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub RunTestItem(ByVal item As TestItem, ByVal tires As CTestItem)
        Try
            ' Get min/max value
            Dim measValue As Double
            GetMeasValue(item, measValue, tires)

            Dim status As Boolean
            status = GUI.DisplayNumericResult(item.Name, item.limit_low, item.limit_up, measValue)
            My.Application.DoEvents()

            SaveTestItemRes(tires, measValue, status)

        Catch ex As Exception
            AddStatusMsg("RunTestItem()::" & ex.Message)
            tires.MeasString = ex.Message
            If AbortFlag Then tires.MeasStatus = numPFAState.A.ToString
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SaveTestItemRes(ByRef tires As CTestItem, tmpvalue As Double, status As Boolean)
        Try
            With tires
                .MeasValue = tmpvalue
                .Gen1 = 1
                If status Then .MeasStatus = numPFAState.P.ToString
            End With
        Catch ex As Exception
            Throw New Exception("TestPlan.RunTestItem.SaveTestItemRes()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub SetupMeasurement(ByVal group As TestGroup)
        Try
            With IVIV
                ' DUT test
                .MeasFunction = 1
                ' J1 out
                .LaunchPort = 1
                ' Singe/Dual MTJ
                If GUI.SelectedPhaseName.Contains("System") Then
                    .MTJConnection = 2
                    .DUTLengthEstimated = False
                Else
                    .MTJConnection = 1
                    '.ReceiveJumperUsage = 0
                    .DUTLengthEstimated = False
                    '.DUTLengthEstimated = product_main.Length_m
                    '.JumperLengthOverrideOption(3) = 0
                    '.JumperLengthOverrideValue(3) = 4
                End If

                If gAntSwmPortMapping Is Nothing Then
                    .Channel(1) = group.Channel
                Else
                    .Channel(1) = gAntSwmPortMapping.PortMapList.Find(Function(o) o.FiberId = group.Channel).SwitchPortId
                End If
                .WavelengthList = group.WavelengthListStr
                .ILOnly = False

            End With
            Threading.Thread.Sleep(3000)
        Catch ex As Exception
            Throw New Exception("SetupMeasurement()::" & ex.Message)
        End Try
    End Sub
    Private Sub GetMeasValue(ti As TestItem, ByRef measValue As Double, ByRef tires As CTestItem)
        Try
            Dim measRes As CMeasRessult = Nothing
            Dim key As String = String.Format("{0}_{1}", ti.ParentGroup.Name, ti.wave_length)

            Dim iStep As Integer
            If Not MeasResDic.ContainsKey(key) Then
                Dim measResArr As String() = Nothing
                Dim measResStr As String

#If Simulate Then
                measResArr = GetSilulateTestValue(ti.ParentGroup.WavelengthList)
                measResStr = String.Join(",", measResArr)
#Else
                With IVIV
                    .MeasStart()
                    Do
                        .WaitOPC(1)
                        measResStr = .MeasResAll.Trim
                        measResArr = measResStr.Split(",")
                        iStep += 1
                        If iStep > 10 Then Exit Do
                    Loop While (measResStr = String.Empty Or measResStr.Contains(",,,"))
                End With
#End If
                Dim waveLengthCount As Integer = ti.ParentGroup.WavelengthList.Count
                Dim indexList As New List(Of Integer)
                For i As Integer = 0 To waveLengthCount - 1
                    indexList.Add(i * 5)
                Next
                If measResStr = String.Empty Or measResStr.Contains(",,,") Then
                    For i As Integer = 0 To waveLengthCount - 1
                        measRes = New CMeasRessult
                        key = String.Format("{0}_{1}", ti.ParentGroup.Name, measResArr(indexList(i)))
                        measRes.IL = 100
                        measRes.Length = 0
                        measRes.ORL = 0
                        MeasResDic.Add(key, measRes)
                    Next
                Else
                    For i As Integer = 0 To waveLengthCount - 1
                        measRes = New CMeasRessult
                        key = String.Format("{0}_{1}", ti.ParentGroup.Name, measResArr(indexList(i)))
                        measRes.IL = measResArr(indexList(i) + 1)
                        measRes.Length = measResArr(indexList(i) + 2)
                        If GUI.SelectedPhaseName = "System" Then
                            measRes.ORL1 = CDbl(measResArr(indexList(i) + 3))
                            measRes.ORL2 = CDbl(measResArr(indexList(i) + 4))
                            measRes.ORL = Math.Abs(10 * Math.Log10(10 ^ (-measRes.ORL1 / 10) + 10 ^ (-measRes.ORL2 / 10)))
                        Else
                            measRes.ORL = CDbl(measResArr(indexList(i) + 3))
                        End If
                        MeasResDic.Add(key, measRes)
                    Next
                End If
            End If

            key = String.Format("{0}_{1}", ti.ParentGroup.Name, ti.wave_length)
            measRes = MeasResDic.Item(key)
            Select Case ti.Name.Substring(0, 3).ToUpper
                Case "IL_"
                    measValue = measRes.IL
                Case "LEN"
                    measValue = measRes.Length
                Case "RL_"
                    measValue = measRes.ORL
                    tires.ORL1 = measRes.ORL1
                    tires.ORL2 = measRes.ORL2
            End Select

        Catch ex As Exception
            Throw New Exception("TestPlan.RunTestItem.GetMeasValue()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub WriteTestRes()
        Try
            ' Write head
            TestRes.ConnString = ConnStr
            ' Write head of test result
            With TestRes.Head
                .SpecMainId = TestPhase.ID
                .PhaseMainId = TestPhase.phaseID
                .PhaseName = TestPhase.Name
                .SoftwareRev = SW_Version
                .Factory = GUI.Factory
            End With
            TestRes.Flag.MTS = False

            ' Write Instrument
            Dim SCPIInst As SCPIInstrument = CType(IVIV, SCPIInstrument)
            With TestRes.TestInstruments

                Dim inst As New CInstrument
                With inst
#If Simulate Then
                    .Model = "Simulate MAP200"
                    .SerialNumber = "Simulate 12345"
                    .Hardware = ""
                    .Firmware = ""
                    .Idn = ""
#Else
                    .Model = SCPIInst.Model
                    .SerialNumber = SCPIInst.Serial_Number
                    .Hardware = ""
                    .Firmware = SCPIInst.FW_Revision
                    .Idn = SCPIInst.IDNString
#End If

                End With
                .Add(inst)
            End With
        Catch ex As Exception
            Throw New Exception("TestPlan.WriteTestRes()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Function CheckCalibrationFile(ByRef SaveFile As Boolean) As Boolean
        Try
            AddStatusMsg("Start to check calibration file...")
            Dim calF As New CalibrateFactory(product_main, TestPhase, IVIV)
            Dim cal As Calibrate = calF.CreateInstance()
            If cal.IsCalValid = False Then
                CalValid = False
            Else
                CalValid = True
            End If

            If CalValid = False Then
                SaveFile = False
                AddStatusMsg("Invalid calibration!")
                If DebugMode Then
                    If MsgBox("The calibration file is invalid, do you want to continue? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Check Calibration") = DialogResult.No Then
                        Return False
                    End If
                Else
                    MsgBox("The calibration file is invalid, please re-calibrate! ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    Return False
                End If
            End If

            AddStatusMsg("Calibration check done!")

            Return True

        Catch ex As Exception
            Throw New Exception("TestPlan.CheckCalibrationFile()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Function
    Private Function GetConnectorType() As numConnFamily
        Try
            'If gBenchSetting.TestType = numTestType.Pigtail Then Return numConnFamily.NA

            Dim cf1500M As connector_family
            Dim cf1501M As connector_family

            Dim cfBll As New BLL.connector_familyManager
            cf1500M = cfBll.Select1500ByProduct(product_main.Product_name)
            cf1501M = cfBll.Select1501ByProduct(product_main.Product_name)

            GUI.C1500Connector = cf1500M.Family_name
            GUI.C1501Connector = cf1501M.Family_name

            If cf1501M.Family_name = "NA" Then
                If cf1500M.Family_name.Contains("MPO") Or cf1500M.Family_name.Contains("HMFOC") Then
                    Return numConnFamily.DUAL_MPO
                Else
                    Return numConnFamily.NON_MPO
                End If
            End If

            If (cf1500M.Family_name.Contains("MPO") And cf1501M.Family_name.Contains("MPO")) Or (cf1500M.Family_name.Contains("HMFOC") And cf1501M.Family_name.Contains("HMFOC")) Then
                Return numConnFamily.DUAL_MPO
            ElseIf Not (cf1500M.Family_name.Contains("MPO") Or cf1500M.Family_name.Contains("HMFOC")) And Not (cf1501M.Family_name.Contains("MPO") Or cf1501M.Family_name.Contains("HMFOC")) Then
                Return numConnFamily.NON_MPO
            End If

            Return numConnFamily.SINGLE_MPO
        Catch ex As Exception
            Throw New Exception("TestPlan.GetConnectorType()::" & ex.Message)
        End Try
    End Function
    Public Sub LoadTestData(ByVal SN As String, ByVal PN As String, ByVal phase As String)
        Dim _frmProcess As New FormProcess
        Try
            _frmProcess.Label1.Text = "Loading Test Data ... ... "
            _frmProcess.AutoWidth()
            _frmProcess.Show()
            My.Application.DoEvents()

            Dim sw As New Stopwatch
            sw.Start()

            Dim status As Model.cq_phases_status = Nothing
            Dim lstPhaseStatus As List(Of FACTS.Model.cq_phases_status)
            Dim cq_phstatus As New FACTS.BLL.cq_phases_statusManager

            lstPhaseStatus = cq_phstatus.SelectAll(PN, SN, gBenchSetting.TestMode, gBenchSetting.TestPhaseStationMainId)
            If lstPhaseStatus IsNot Nothing Then
                For Each status In lstPhaseStatus
                    Select Case status.phase_status
                        Case "P"
                            GUI.SetStepStatus(status.phase, 2)
                        Case "F"
                            GUI.SetStepStatus(status.phase, 3)
                        Case "A"
                            GUI.SetStepStatus(status.phase, 4)
                    End Select
                Next
            End If

            If lstPhaseStatus IsNot Nothing Then
                status = lstPhaseStatus.Find(Function(o) o.phase = phase)
            End If

            TestRes.TestPhase.TestGroups.Clear()

            If status Is Nothing Then
                GUI.SetStepStatus(phase, 0)
            Else
                With status
                    AddStatusMsg(String.Format("{0}: {1}, {2}", .phase, .phase_status, .start_datetime))
                    Select Case .phase_status
                        Case "P"
                            GUI.SetStepStatus(.phase, 2)
                        Case "F"
                            GUI.SetStepStatus(.phase, 3)
                        Case "A"
                            GUI.SetStepStatus(.phase, 4)
                    End Select
                End With

                Dim test_dataBll As New BLL.cq_test_dataManager()
                Dim lstMeas As List(Of Model.cq_test_data) = test_dataBll.SelectAllByMeasPhaseId(status.meas_phase_id)

                If lstMeas IsNot Nothing Then
                    Dim rlilPhase As TestPhaseRlIl = Nothing
                    Dim Tphase As TestPhase
                    Tphase = Spec.TestPhaseList.Find(Function(o) o.Name = phase)
                    If Tphase IsNot Nothing Then
                        rlilPhase = TryCast(Tphase, TestPhaseRlIl)
                    End If
                    If rlilPhase IsNot Nothing Then
                        For Each gp As TestGroup In rlilPhase.TestGroupList
                            Dim tgres As New CTestGroup(gp)

                            Dim query As IEnumerable(Of cq_test_data) = From g In lstMeas
                                                                        Where g.Group_main_id = gp.ID

                            If query.ToList.Count = 0 Then Continue For

                            tgres.GroupStatus = query.Last.Group_status

                            Select Case query.Last.Group_status
                                Case "P"
                                    GUI.SetGroupStatus(gp.Name, 2)
                                Case "F"
                                    GUI.SetGroupStatus(gp.Name, 3)
                                Case "A"
                                    GUI.SetGroupStatus(gp.Name, 4)
                            End Select

                            For Each ti As TestItem In gp.TestItemList
                                Dim tires As New CTestItem(ti)

                                Dim query2 As IEnumerable(Of cq_test_data) = From item In lstMeas
                                                                             Where item.Spec_detail_id = ti.ID

                                If query2.ToList.Count = 0 Then Continue For
                                Dim passStatus As Integer
                                Dim val As Double = query2.Last.Meas_high_value
                                If val >= ti.limit_low And val <= ti.limit_up Then
                                    passStatus = 2
                                Else
                                    passStatus = 3
                                End If

                                GUI.SetTestItemStatus(ti.Name, passStatus)
                                GUI.DisplayNumericResult(ti.Name, ti.limit_low, ti.limit_up, val.ToString)

                                With tires
                                    .MeasValue = val
                                    .MeasStatus = query2.Last.Meas_detail_status
                                End With
                                tgres.TestItems.Add(tires)
                            Next
                            TestRes.TestPhase.TestGroups.Add(tgres)
                        Next
                    End If
                End If
            End If

            sw.Stop()
            AddStatusMsg(String.Format("Load Test Data time = {0} ms", sw.ElapsedMilliseconds()))

            _frmProcess.Close()
        Catch ex As Exception
            If _frmProcess IsNot Nothing Then _frmProcess.Close()
            Throw New Exception("TestPlan.LoadTestData()::" & ex.Message)
        End Try

    End Sub
    Public Function LoadTestStatus(ByVal SN As String, ByVal PN As String, ByVal phase As String) As String
        Try
            If SN Is Nothing Then Return Nothing
            If SN.Length = 0 Then Return Nothing
            Dim isSecondSn As Boolean
            Dim snrM As Model.serial_number_relation = Nothing
            Dim snrBll As New BLL.serial_number_relationManager
            snrM = snrBll.SelectBySn(SN)
            If snrM Is Nothing Then Return Nothing
            If SN = snrM.Serial_number_2 Then isSecondSn = True

            Dim status As Model.cq_phases_status = Nothing
            Dim lstPhaseStatus As List(Of FACTS.Model.cq_phases_status)
            Dim cq_phstatus As New FACTS.BLL.cq_phases_statusManager

            lstPhaseStatus = cq_phstatus.SelectAll(PN, SN, gBenchSetting.TestMode, gBenchSetting.TestPhaseStationMainId)

            If lstPhaseStatus IsNot Nothing Then
                status = lstPhaseStatus.Find(Function(o) o.phase = phase)
            End If

            Dim halfGroupNum As Integer
            Dim GroupNum As Integer
            Dim groupCounter As Integer
            Dim snStatus As Boolean = True

            If status IsNot Nothing Then
                Dim test_dataBll As New BLL.cq_test_dataManager()
                Dim lstMeas As List(Of Model.cq_test_data) = test_dataBll.SelectAllByMeasPhaseId(status.meas_phase_id)
                If lstMeas IsNot Nothing Then
                    Dim rlilPhase As TestPhaseRlIl = Nothing
                    Dim Tphase As TestPhase
                    Tphase = Spec.TestPhaseList.Find(Function(o) o.Name = phase)
                    If Tphase IsNot Nothing Then
                        rlilPhase = TryCast(Tphase, TestPhaseRlIl)
                    End If
                    GroupNum = rlilPhase.TestGroupList.Count
                    halfGroupNum = GroupNum \ 2
                    If rlilPhase IsNot Nothing Then
                        For Each gp As TestGroup In rlilPhase.TestGroupList
                            groupCounter += 1
                            If isSecondSn Then
                                If groupCounter <= halfGroupNum Then Continue For
                            Else
                                If groupCounter > halfGroupNum Then Exit For
                            End If

                            Dim tgres As New CTestGroup(gp)

                            Dim query = From g In lstMeas
                                        Where g.Group_main_id = gp.ID

                            If query Is Nothing OrElse query.Count = 0 Then Continue For

                            tgres.GroupStatus = query.Last.Group_status

                            If query.Last.Group_status <> "P" Then
                                snStatus = False
                                Exit For
                            End If
                        Next
                        If snStatus = False Then Return "F" Else Return "P"
                    End If
                End If
            End If

            Return Nothing

        Catch ex As Exception
            Throw New Exception("TestPlan.LoadTestStatus()::" & ex.Message)
        End Try
    End Function
    Private Sub LoadGuiTestSpec()
        Try
            ' Define steps and groups
            Dim steps() As String = Spec.TestPhaseNames
            For i As Integer = 0 To steps.Length - 1
                Dim RlIlPhase As TestPhaseRlIl = TryCast(Spec.TestPhaseList(i), TestPhaseRlIl)
                If RlIlPhase Is Nothing Then Continue For
                AddStatusMsg(String.Format("{0} spec ver = {1}", RlIlPhase.Name, RlIlPhase.VersionSpec))
            Next
            ' Load test phases grid
            GUI.LoadTestPhaseGrid(Spec)
            ' Load test groups and items grid
            GUI.LoadTestItemsGrid(Spec)
        Catch ex As Exception
            Throw New Exception("CheckSN.LoadGuiTestSpec(): " & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub WriteTestResHead(SN As String, WO As String, product_mode_id As Integer)
        Try
            ' Write head of test result
            With TestRes
                With .Head
                    .SerialNumber = SN
                    .ProductName = product_main.Product_name
                    If WO.Length > 10 Then
                        .WorkOrder = WO.Substring(2)
                    Else
                        .WorkOrder = WO
                    End If
                    .ProductMainId = product_main.Id
                    .ProductModeId = product_mode_id
                    .ProductMode = gBenchSetting.TestMode
                    .PhaseStationMainId = gBenchSetting.TestPhaseStationMainId
                    .UserName = Environment.UserName.ToUpper
                End With
            End With
        Catch ex As Exception
            Throw New Exception("CheckSN.WriteTestResHead()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Function CheckPhaseStation(cq_modes As Model.cq_modes, PN As String) As Boolean
        Try
            ' Check if phase station exists for a product at a specific mode
            ' Table Name: product_mode_phase_station
            If CheckPhaseStation(cq_modes.product_mode_id, gBenchSetting.TestPhaseStation) = False Then
                AddStatusMsg("Not find test_station = " & gBenchSetting.TestPhaseStation)
                MsgBox("Not find Test Station -- " & gBenchSetting.TestPhaseStation & "." & vbCrLf &
                    "- Product -- " & PN & vbCrLf &
                    "- MODE -- " & cq_modes.mode, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("CheckSN.CheckPhaseStation()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Function
    Private Function CheckPhaseStation(product_mode_id As Integer, phase_station As String) As Boolean
        Try
            If phase_station Is Nothing Then Return False

            Dim cqpmpsBll As New FACTS.BLL.cq_product_mode_phase_stationManager
            Dim cqpmpsML As List(Of FACTS.Model.cq_product_mode_phase_station)

            cqpmpsML = cqpmpsBll.SelectAllByProductModeId(product_mode_id, True, True)

            If cqpmpsML Is Nothing Then Return False

            For Each cqpmps As cq_product_mode_phase_station In cqpmpsML
                If cqpmps.M_phase_station_main.phase_station.ToUpper.Trim = phase_station.ToUpper.Trim Then
                    Return True
                End If
            Next

            Return False

        Catch ex As Exception
            Throw New Exception("CheckPhaseStation()::" & ex.Message)
        End Try

    End Function
    Private Function LoadTestSpec(ByRef cq_modes As Model.cq_modes) As Boolean
        Dim _frmProcess As FormProcess = Nothing
        Try
            ' Load local spec file
            Dim specfile As String
            specfile = String.Format("{0}\{1}_{2}.xml", gLocalSpecFolder, gBenchSetting.TestMode.ToUpper, product_main.Product_name)
            Dim localSpec As TestSpec = Nothing
            If My.Computer.FileSystem.FileExists(specfile) Then
                AddStatusMsg("Read Local test spec file ... ")
                localSpec = New TestSpec(specfile)
                AddStatusMsg(localSpec.ValidDate)
            Else
                AddStatusMsg("No Local test spec file!")
            End If

            ' Find in product_mode based on product id and mode
            Dim cq_modesManager As New BLL.cq_modesManager()
            Dim cq_modesList As List(Of Model.cq_modes) = cq_modesManager.SelectAllByProductMainId(product_main.Id)

            Dim query As IEnumerable(Of cq_modes) = From cqmd In cq_modesList
                                                    Where cqmd.mode = gBenchSetting.TestMode And cqmd.validity

            If query.ToList.Count = 0 Then
                AddStatusMsg(String.Format("Product: {0} @ Mode: {1} Not Found!", product_main.Product_name, gBenchSetting.TestMode))
                Return False
            Else
                cq_modes = query.Single
                Dim modeSpecML As List(Of Model.mode_spec)
                Dim modeSpecManager As New BLL.mode_specManager
                modeSpecML = modeSpecManager.SelectByProductModeId(cq_modes.product_mode_id)

                AddStatusMsg(String.Format("product_mode_id = {0}", cq_modes.product_mode_id))
                AddStatusMsg(String.Format("DB test spec valid date = {0}", cq_modes.validation_date))

                Dim specM As Model.spec_main
                Dim phaseM As Model.phase_main
                Dim updateLocalSpec As Boolean = False
                If localSpec Is Nothing Then
                    updateLocalSpec = True
                Else
                    For Each msM As Model.mode_spec In modeSpecML
                        If msM.validity = False Or msM.validation = False Then Continue For
                        specM = (New BLL.spec_mainManager).SelectById(msM.spec_main_id)
                        phaseM = (New BLL.phase_mainManager).SelectById(specM.phase_main_id)
                        If phaseM.class_id > 2 Then Continue For
                        If Not localSpec.TestPhaseList.Exists(Function(o) o.ID = msM.spec_main_id And o.ValidDate.ToString = msM.validation_date.ToString) Then
                            updateLocalSpec = True
                            Exit For
                        End If
                    Next
                End If

                If updateLocalSpec Then
                    AddStatusMsg("Read test spec from DB ... ")
                    _frmProcess = New FormProcess
                    _frmProcess.Label1.Text = "Loading Test Spec ... ... "
                    _frmProcess.AutoWidth()
                    _frmProcess.Show()
                    My.Application.DoEvents()
                    Spec = New TestSpec(cq_modes)
                    If Spec.TestPhaseList IsNot Nothing Then Spec.SaveXML(specfile)
                    AddStatusMsg("OK")
                    _frmProcess.Close()
                Else
                    AddStatusMsg("Use local test spec")
                    Spec = localSpec
                End If
            End If

            Return True

        Catch ex As Exception
            If _frmProcess IsNot Nothing Then _frmProcess.Close()
            Throw New Exception("CheckSN.LoadTestSpec()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Function
    Private Function CheckSnPn(SN As String, PN As String, WO As String) As Boolean
        Try
            ' Searching SN in product_sn
            AddStatusMsg(String.Format("Find SN '{0}' in DB ... ", SN))
            Dim product_snManager As New BLL.product_snManager
            Dim product_sn As Model.product_sn = product_snManager.SelectBySerialNum(SN)
            If product_sn Is Nothing Then
                AddStatusMsg("Not Found!")
                TestRes.Flag.InsertSN = True
            Else
                AddStatusMsg(String.Format("product_main_id = {0}", product_sn.product_main_id))
                TestRes.Flag.InsertSN = False
            End If

            Dim product_name As String
            Dim product_mainManager As New BLL.product_mainManager
            If product_sn Is Nothing Then
                product_main = product_mainManager.SelectByProductName(PN)
                product_name = PN
            Else
                product_main = product_mainManager.SelectById(product_sn.product_main_id)
                product_name = product_main.Product_name
            End If

            If product_main Is Nothing Then
                AddStatusMsg(String.Format("product_name = {0} ... Not Found!!", product_name))
                Return False
            Else
                AddStatusMsg(String.Format("product_name = {0}", product_main.Product_name))
            End If

            If product_main.Product_name.ToUpper <> PN Then
                AddStatusMsg(String.Format(" input = {0}, Mismatch!", PN))
                Return False
            End If

            GUI.Subunits = product_main.Subunit
            GUI.FiberPerSubunit = product_main.Fiber_per_subunit
            GUI.Length = product_main.Length_m
            GUI.Description = product_main.Product_desc
            If WO.Length > 0 Then GUI.WO = IIf(WO.StartsWith("00"), WO.Substring(2), WO) Else GUI.WO = "600123"

            Return True
        Catch ex As Exception
            Throw New Exception("CheckSN.CheckSnPn()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Function
    Public Function LoadPhaseStation(mode As String, phasestation As String)
        Try
            Dim cqmpsML As New List(Of FACTS.Model.cq_mode_phase_station)
            Dim cqmpsBll As New FACTS.BLL.cq_mode_phase_stationManager
            Dim cqmpsM As FACTS.Model.cq_mode_phase_station

            cqmpsML = cqmpsBll.SelectAllByMode(mode, True, True)

            If cqmpsML Is Nothing Then
                cqmpsM = Nothing
                MsgBox("Not find any test station in MODE<" & mode & ">.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Else
                For Each cqmpsM In cqmpsML
                    If cqmpsM.M_phase_station_main.phase_station.ToUpper.Trim = phasestation.ToUpper.Trim Then
                        Return cqmpsM.M_phase_station_main.id
                    End If
                Next
            End If

            Return 0

        Catch ex As Exception
            Throw New Exception("LoadPhaseStation()::" & ex.Message)
        End Try
    End Function
    Public Sub Calibrate(ByVal TestPhase As String)
        Try
#If Simulate Then
#Else
            IVIV = TryCast(pInstCtrl, IVIAVI)
            If IVIV Is Nothing Then Return
#End If
            Dim tPhase As TestPhase = Spec.PhaseByName(GUI.SelectedPhaseName)
            Dim tPhaseRlIl As TestPhaseRlIl = TryCast(tPhase, TestPhaseRlIl)
            If tPhaseRlIl Is Nothing Then
                MsgBox(String.Format("Testphase {0} is nothing", GUI.SelectedPhaseName), MsgBoxStyle.Critical, "Test Phase Error")
                Exit Sub
            End If

            ' Check antenna switch port index mapping
            Dim AntSwitchSettingFileName As String = String.Format("{0}\{1}.xml", My.Application.Info.DirectoryPath, "SwitchPortMapping")
            gAntSwmPortMapping = CSwitchPortMapping.CreateInstance(AntSwitchSettingFileName)

            Dim calF As New CalibrateFactory(product_main, tPhaseRlIl, IVIV)
            Dim cal As Calibrate = calF.CreateInstance()
            cal.DoCal()

        Catch ex As Exception
            GUI.AddStatusMsg(ex.Message)
        End Try
    End Sub
    Public Sub AddStatusMsg(Msg As String)
        If GUI Is Nothing Then Exit Sub
        Try
            GUI.AddStatusMsg(String.Format("[{0:HH:mm:ss.fff}] {1}", Now, Msg), True)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub InitializeCalibrateIO()
        Try
            pCalIO = (New CalibrateIOFactory).CreateInstance

        Catch ex As Exception
            Throw New Exception("InitializeCalibrateIO() - " & ex.Message)
        End Try
    End Sub
    Public Sub CloseLiveDisplay()
        Try
#If Simulate Then
#Else
            IVIV.LiveMode = 0
#End If
        Catch ex As Exception
            Throw New Exception("CloseLiveDisplay() - " & ex.Message)
        End Try
    End Sub

End Class

Public Class CMeasRessult
    Public IL As Double
    Public ORL As Double
    Public ORL1 As Double
    Public ORL2 As Double
    Public Length As Double
End Class
Public Class CATS_XML
    Public CreateTime As DateTime = DateTime.MinValue
    Public Location As String = ""
    Public ConnString As String = ""

    Public Sub New(ByVal filename As String)
        If My.Computer.FileSystem.FileExists(filename) = False Then Exit Sub

        Dim Encryptor As New Encryptor.Encryptor
        Dim filecontent As String = Encryptor.DecryptFromFile(filename)

        Dim xdoc As New XmlDocument()
        xdoc.LoadXml(filecontent)

        Dim nd As XmlNode = xdoc.SelectSingleNode("/CATS/Property/CreateTime")
        If nd IsNot Nothing Then CreateTime = nd.InnerText

        nd = xdoc.SelectSingleNode("/CATS/Factory/Location")
        If nd IsNot Nothing Then Location = nd.InnerText

        nd = xdoc.SelectSingleNode("/CATS/DataBase/ConnString")
        If nd IsNot Nothing Then ConnString = nd.InnerText
    End Sub

    Public Shared Operator >(ByVal a As CATS_XML, ByVal b As CATS_XML) As Boolean
        Return a.CreateTime > b.CreateTime
    End Operator
    Public Shared Operator <(ByVal a As CATS_XML, ByVal b As CATS_XML) As Boolean
        Return a.CreateTime < b.CreateTime
    End Operator
End Class
