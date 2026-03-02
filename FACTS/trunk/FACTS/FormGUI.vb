Imports C1.Win.C1FlexGrid
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO
Imports System.Threading
Imports SerialNumInq
Imports FACTS.Model
Imports System.Net.Http.Headers

Public Class FormGUI
    Private _SW_Version As String
    Private _SW_Name As String
    Private _Database As String
    Private _Mode_Name As String
    Private _SAP_Fail_Safe_Mode As String
    Private _Factory As String
    Private _ProgressValue As Integer
    Private _ProgressMinmum As Integer
    Private _ProgressMaximum As Integer
    Private m_fileName As String = "C:\Andrew\test_system\InputFiber.xml"
    Private _Plant_Code As String
    Private _SelectedPhaseName As String
    Private _InstrumentReady As String
    Private _TestType As numTestType
    Private _RetryCount As String
    Private _1500Connector As String
    Private _1501Connector As String
    Private _Subunits As Integer
    Private _FiberPerSubunit As Integer
    Private _Length As Decimal
    Private _Description As String
    Private _WO As String
    Private _TotalTest As Integer
    Private _PF As String
    Public Property SW_Version As String
        Set(value As String)
            _SW_Version = value
        End Set
        Get
            Return _SW_Version
        End Get
    End Property

    Public WriteOnly Property SW_Name As String
        Set(value As String)
            _SW_Name = value
            Me.Text = String.Format("{0} - ver. {1} - (11/25/2022))", value, SW_Version)
        End Set
    End Property
    Public WriteOnly Property Database As String
        Set(value As String)
            _Database = value
            Me.tsslDatabaseName.Text = "DB: " & value
        End Set
    End Property

    Public WriteOnly Property Mode_Name As String
        Set(value As String)
            _Mode_Name = value
            Me.tsslMode.Text = "Mode: " & value
        End Set
    End Property

    Public WriteOnly Property SAP_Fail_Safe_Mode As String
        Set(value As String)
            _SAP_Fail_Safe_Mode = value
            Me.tsslSAPFailSafeMode.Text = "SAP Fail Safe Mode: " & IIf(value, "ON", "OFF")
            Me.tsslSAPFailSafeMode.ForeColor = IIf(value, Color.Red, SystemColors.ControlText)
        End Set
    End Property

    Public Property Factory As String
        Get
            Return _Factory
        End Get
        Set(value As String)
            _Factory = value
            Me.tsslPlant.Text = "Factory: " & value
        End Set
    End Property

    Public Property ProgressBarValue As Integer
        Get
            Return _ProgressValue
        End Get
        Set(value As Integer)
            _ProgressValue = value
            Me.pbProgress.Value = value
            My.Application.DoEvents()
        End Set
    End Property

    Public WriteOnly Property ProgressMinmum As Integer
        Set(value As Integer)
            Me.pbProgress.Minimum = value
            My.Application.DoEvents()
        End Set
    End Property

    Public WriteOnly Property ProgressMaximum As Integer
        Set(value As Integer)
            Me.pbProgress.Maximum = value
            My.Application.DoEvents()
        End Set
    End Property

    Public Property Plant_Code As String
        Get
            Return _Plant_Code
        End Get
        Set(value As String)
            _Plant_Code = value
        End Set
    End Property

    Public Property SelectedPhaseName As String
        Get
            Return _SelectedPhaseName
        End Get
        Set(value As String)
            _SelectedPhaseName = value
        End Set
    End Property

    WriteOnly Property InstrumentReady As String
        Set(value As String)
            _InstrumentReady = value
            Me.tsslInstrumentState.Text = "Instrument State: " & value
            Me.tsslInstrumentState.ForeColor = IIf(value = "Ready", SystemColors.ControlText, Color.Red)
        End Set
    End Property

    Public Sub ClearStatusMsg()
        Me.TxtStatus.Text = ""
    End Sub
    Public ReadOnly Property LogMessage() As String
        Get
            Return Me.TxtStatus.Text
        End Get
    End Property
    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        End
    End Sub
    Public Sub LoadTestPhaseGrid(spec As TestSpec)
        Try
            InitGridTestPhases()
            Dim row As Row
            For Each phase As TestPhase In spec.TestPhaseList
                If gBenchSetting.TestType = numTestType.System Then
                    If phase.Name <> "System" Then Continue For
                Else
                    If phase.Name = "System" Then Continue For
                End If
                row = fgTestPhases.Rows.Add()
                row(0) = phase.Name
                SetStepStatus(phase.Name, 0)
                'row(2) = True
                row.UserData = phase
            Next

            If Me.fgTestPhases.Rows.Count > 1 Then
                If SelectedPhaseName IsNot Nothing Then
                    Dim rowIdx As Integer = fgTestPhases.FindRow(SelectedPhaseName, 1, 0, False)
                    If rowIdx > 0 Then
                        fgTestPhases(rowIdx, 2) = True
                        CType(fgTestPhases.Rows(rowIdx).UserData, TestPhase).Selected = True
                    Else
                        fgTestPhases(1, 2) = True
                        CType(fgTestPhases.Rows(1).UserData, TestPhase).Selected = True
                        SelectedPhaseName = fgTestPhases(1, 0)
                    End If
                Else
                    fgTestPhases(1, 2) = True
                    CType(fgTestPhases.Rows(1).UserData, TestPhase).Selected = True
                    SelectedPhaseName = fgTestPhases(1, 0)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("FormGUI.LoadTestPhaseGrid()::" & ex.Message)
        End Try
    End Sub
    Public Sub DisplayLiveValue(channel As String, wavelength As String, il As String, orl As String, power As String)
        Try
            If Me.InvokeRequired Then
                Me.BeginInvoke(New Action(Of String, String, String, String, String)(AddressOf ShowLiveValue), channel, wavelength, il, orl, power)
            Else
                ShowLiveValue(channel, wavelength, il, orl, power)
            End If
        Catch ex As Exception
            Throw New Exception("FormGUI.DisplayLiveValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub ShowLiveValue(channel As String, wavelength As String, il As String, orl As String, power As String)
        Try
            Me.lblChannel.Text = IIf(channel.Length = 0, "------", channel)
            Me.lblWavelength.Text = IIf(wavelength.Length = 0, "------", wavelength)
            Me.lblIL.Text = IIf(il.Length = 0, "------", il)
            Me.lblORL.Text = IIf(orl.Length = 0, "------", orl)
            Me.lblPower.Text = IIf(power.Length = 0, "------", power)
        Catch ex As Exception
            Throw New Exception("FormGUI.ShowLiveValue()::" & ex.Message)
        End Try
    End Sub
    WriteOnly Property CollapseLiveModePanel() As Boolean
        Set(value As Boolean)
            splitLiveMode.Panel2Collapsed = value
        End Set
    End Property

    Public Property TestType As numTestType
        Get
            Return _TestType
        End Get
        Set(value As numTestType)
            _TestType = value
            Me.tsslTestType.Text = value.ToString & " Test"
        End Set
    End Property
    WriteOnly Property RetryCount As String
        Set(value As String)
            _RetryCount = value
            Me.tsslRetryCount.Text = String.Format("Retry Count: {0}", value)
        End Set
    End Property

    Public WriteOnly Property C1500Connector As String
        Set(value As String)
            _1500Connector = value
            Me.lbl1500Connector.Text = value
        End Set
    End Property

    Public WriteOnly Property C1501Connector As String
        Set(value As String)
            _1501Connector = value
            Me.lbl1501Connector.Text = value
        End Set
    End Property

    Public WriteOnly Property Subunits As Integer
        Set(value As Integer)
            _Subunits = value
            Me.lblSubunits.Text = value
        End Set
    End Property

    Public WriteOnly Property FiberPerSubunit As Integer
        Set(value As Integer)
            _FiberPerSubunit = value
            Me.lblFiberPerSubunit.Text = value
        End Set
    End Property

    Public WriteOnly Property Length As Decimal
        Set(value As Decimal)
            _Length = value
            Me.lblLength.Text = value
        End Set
    End Property

    Public WriteOnly Property Description As String
        Set(value As String)
            _Description = value
            Me.lblDescription.Text = value
        End Set
    End Property
    Public WriteOnly Property WO As String
        Set(value As String)
            _WO = value
            Me.lblWO.Text = value
        End Set
    End Property
    Public WriteOnly Property TotalTest As Integer
        Set(value As Integer)
            _TotalTest = value
            Me.lblTotal.Text = value
        End Set
    End Property
    Public WriteOnly Property PF As String
        Set(value As String)
            _PF = value
            Me.lblPF.Text = value
        End Set
    End Property
    Public Sub LoadTestItemsGrid(Spec As TestSpec)
        Try

            InitGridTestGroups()
            InitGridTestItems()

            Dim Tphase As TestPhase = Spec.PhaseByName(SelectedPhaseName)
            Dim rlilPhase As TestPhaseRlIl = CType(Tphase, TestPhaseRlIl)
            If Tphase Is Nothing Then Return

            Dim row As Row
            Dim groupRowIdx As Integer
            Dim itemRowIdx As Integer

            fgTestGroups.Redraw = False
            fgTestItems.Redraw = False


            For Each Tgroup As TestGroup In rlilPhase.TestGroupList
                row = Me.fgTestGroups.Rows.Add()
                groupRowIdx = row.Index
                row(0) = Tgroup.Name
                SetGroupStatusByRowIdx(groupRowIdx, 0)
                row(2) = Tgroup.Selected
                row.UserData = Tgroup
                For Each Titem As TestItem In Tgroup.TestItemList
                    row = Me.fgTestItems.Rows.Add()
                    itemRowIdx = row.Index
                    row(1) = Titem.Name
                    row(2) = Titem.sub_unit
                    row(3) = Titem.fiber
                    row(4) = Titem.Selected
                    row(5) = Titem.limit_low
                    row(7) = Titem.limit_up
                    SetTestItemStatusByRowIdx(itemRowIdx, 0)
                    row.UserData = Titem
                Next
            Next

            'FormatGrid(fgTestGroups, 9, 8)
            'FormatGrid(fgTestItems, 9, 8)

            If fgTestGroups.Rows.Count > 0 Then
                fgTestGroups.ShowCell(1, 1)
            End If
            If fgTestItems.Rows.Count > 0 Then
                fgTestItems.ShowCell(1, 1)
            End If

            fgTestGroups.Redraw = True
            fgTestItems.Redraw = True
        Catch ex As Exception
            Throw New Exception("FormGUI.LoadTestItemsGrid()::" & ex.Message)
        End Try
    End Sub
    Public Sub SetStepStatus(ByVal TestStep As String, ByVal Status As Short)
        Try
            Dim rowIdx As Integer

            If Status < 0 Or Status > 4 Then Status = 0

            rowIdx = fgTestPhases.FindRow(TestStep, 1, 0, False)

            If rowIdx < 1 Then Exit Sub

            Select Case Status
                Case 0
                    Me.fgTestPhases(rowIdx, 1) = ""
                    Me.fgTestPhases.SetCellStyle(rowIdx, 1, fgTestPhases.Styles("Black"))
                Case 1
                    Me.fgTestPhases(rowIdx, 1) = "Running"
                    Me.fgTestPhases.SetCellStyle(rowIdx, 1, fgTestPhases.Styles("Blue"))
                Case 2
                    Me.fgTestPhases(rowIdx, 1) = "PASS"
                    Me.fgTestPhases.SetCellStyle(rowIdx, 1, fgTestPhases.Styles("Green"))
                Case 3
                    Me.fgTestPhases(rowIdx, 1) = "FAIL"
                    Me.fgTestPhases.SetCellStyle(rowIdx, 1, fgTestPhases.Styles("Red"))
                Case 4
                    Me.fgTestPhases(rowIdx, 1) = "Abort"
                    Me.fgTestPhases.SetCellStyle(rowIdx, 1, fgTestGroups.Styles("Red"))
            End Select
        Catch ex As Exception
            Throw New Exception("SetStepStatus() - " & ex.Message)
        End Try
    End Sub
    Public Sub SetGroupStatusByRowIdx(ByVal RowIdx As Integer, ByVal Status As Integer)
        Try
            If Status < 0 Or Status > 4 Then Status = 0

            If RowIdx > Me.fgTestGroups.Rows.Count - 1 Then Exit Sub

            Select Case Status
                Case 0
                    Me.fgTestGroups(RowIdx, 1) = ""
                    Me.fgTestGroups.SetCellStyle(RowIdx, 1, fgTestGroups.Styles("Black"))
                Case 1
                    Me.fgTestGroups(RowIdx, 1) = "Running"
                    Me.fgTestGroups.SetCellStyle(RowIdx, 1, fgTestGroups.Styles("Blue"))
                Case 2
                    Me.fgTestGroups(RowIdx, 1) = "PASS"
                    Me.fgTestGroups.SetCellStyle(RowIdx, 1, fgTestGroups.Styles("Green"))
                Case 3
                    Me.fgTestGroups(RowIdx, 1) = "FAIL"
                    Me.fgTestGroups.SetCellStyle(RowIdx, 1, fgTestGroups.Styles("Red"))
                Case 4
                    Me.fgTestGroups(RowIdx, 1) = "Abort"
                    Me.fgTestGroups.SetCellStyle(RowIdx, 1, fgTestGroups.Styles("Red"))
            End Select
        Catch ex As Exception
            Throw New Exception("SetGroupStatusByRowIdx() - " & ex.Message)
        End Try
    End Sub
    Public Sub SetGroupStatus(ByVal TestGroup As String, ByVal Status As Short)
        Try
            Dim rowIdx As Integer

            If Status < 0 Or Status > 4 Then Status = 0

            rowIdx = fgTestGroups.FindRow(TestGroup, 1, 0, False)

            If rowIdx < 1 Then Exit Sub

            Dim displayTopRowIdx As Integer = rowIdx - 6
            If displayTopRowIdx < 1 Then displayTopRowIdx = 1
            Me.fgTestGroups.TopRow = displayTopRowIdx

            Select Case Status
                Case 0
                    Me.fgTestGroups(rowIdx, 1) = ""
                    Me.fgTestGroups.SetCellStyle(rowIdx, 1, fgTestGroups.Styles("Black"))
                Case 1
                    Me.fgTestGroups(rowIdx, 1) = "Running"
                    Me.fgTestGroups.SetCellStyle(rowIdx, 1, fgTestGroups.Styles("Blue"))
                Case 2
                    Me.fgTestGroups(rowIdx, 1) = "PASS"
                    Me.fgTestGroups.SetCellStyle(rowIdx, 1, fgTestGroups.Styles("Green"))
                Case 3
                    Me.fgTestGroups(rowIdx, 1) = "FAIL"
                    Me.fgTestGroups.SetCellStyle(rowIdx, 1, fgTestGroups.Styles("Red"))
                Case 4
                    Me.fgTestGroups(rowIdx, 1) = "Abort"
                    Me.fgTestGroups.SetCellStyle(rowIdx, 1, fgTestGroups.Styles("Red"))
            End Select
        Catch ex As Exception
            Throw New Exception("SetGroupStatus() - " & ex.Message)
        End Try
    End Sub
    Public Sub SetTestItemStatusByRowIdx(ByVal rowIdx As Integer, ByVal Status As Short)
        Try
            If Status < 0 Or Status > 4 Then Status = 0

            If rowIdx > Me.fgTestItems.Rows.Count - 1 Then Exit Sub

            Select Case Status
                Case 0
                    Me.fgTestItems(rowIdx, 8) = ""
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestGroups.Styles("Black"))
                Case 1
                    Me.fgTestItems(rowIdx, 8) = "Running"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestGroups.Styles("Blue"))
                Case 2
                    Me.fgTestItems(rowIdx, 8) = "PASS"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestGroups.Styles("Green"))
                Case 3
                    Me.fgTestItems(rowIdx, 8) = "FAIL"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestGroups.Styles("Red"))
                Case 4
                    Me.fgTestItems(rowIdx, 8) = "Abort"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestGroups.Styles("Red"))
            End Select
        Catch ex As Exception
            Throw New Exception("SetTestItemStatusByRowIdx() - " & ex.Message)
        End Try
    End Sub
    Public Sub SetTestItemStatus(ByVal TestItem As String, ByVal Status As Integer)
        Try
            Dim rowIdx As Integer

            If Status < 0 Or Status > 5 Then Status = 0

            rowIdx = fgTestItems.FindRow(TestItem, 1, 1, False)

            If rowIdx < 1 Then Exit Sub

            Dim displayTopRowIdx As Integer = rowIdx - 6
            If displayTopRowIdx < 1 Then displayTopRowIdx = 1
            Me.fgTestItems.TopRow = displayTopRowIdx

            Select Case Status
                Case 0
                    Me.fgTestItems(rowIdx, 8) = ""
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Black"))
                Case 1
                    Me.fgTestItems(rowIdx, 8) = "Running"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Blue"))
                Case 2
                    Me.fgTestItems(rowIdx, 8) = "PASS"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Green"))
                Case 3
                    Me.fgTestItems(rowIdx, 8) = "FAIL"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Red"))
                Case 4
                    Me.fgTestItems(rowIdx, 8) = "Abort"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Red"))
                Case 5
                    Me.fgTestItems(rowIdx, 8) = "PASS"
                    Me.fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("DarkOrange"))
            End Select
        Catch ex As Exception
            Throw New Exception("SetTestItemStatus() - " & ex.Message)
        End Try
    End Sub
    Public Sub ClearGroupTestResults(groupName As String)
        Dim i As Integer

        For i = 1 To Me.fgTestGroups.Rows.Count - 1
            If Me.fgTestGroups(i, 0) = groupName Then
                Call SetGroupStatus(Me.fgTestGroups(i, 0), 0)
            End If
        Next

        For i = 1 To Me.fgTestItems.Rows.Count - 1
            If Me.fgTestItems.Rows(i).UserData Is Nothing Then Continue For
            If CType(Me.fgTestItems.Rows(i).UserData, TestItem).ParentGroup.Name = groupName Then
                Call SetTestItemStatus(Me.fgTestItems(i, 1), 0)
            End If
        Next

    End Sub
    Public Sub ClearTestResults()
        Dim i As Integer

        For i = 1 To Me.fgTestPhases.Rows.Count - 1
            If Me.fgTestPhases(i, 2) = True Then
                Call SetStepStatus(Me.fgTestPhases(i, 0), 0)
            End If
        Next

        For i = 1 To Me.fgTestGroups.Rows.Count - 1
            If Me.fgTestGroups(i, 2) = True Then
                Call SetGroupStatus(Me.fgTestGroups(i, 0), 0)
            End If
        Next

        Dim firstSelectedTestItemRowIdx As Integer = 99999
        For i = 1 To Me.fgTestItems.Rows.Count - 1
            If Me.fgTestItems(i, 4) = True Then
                If i < firstSelectedTestItemRowIdx Then firstSelectedTestItemRowIdx = i
                Call SetTestItemStatus(Me.fgTestItems(i, 1), 0)
            End If
        Next
        Me.fgTestItems.TopRow = firstSelectedTestItemRowIdx

    End Sub
    Public Sub ClearGui()
        Me.ClearInput()
        InitGridTestPhases()
        InitGridTestGroups()
        InitGridTestItems()
        Me.ClearStatusMsg()
        Me.CmdCAL.Enabled = False
        Me.CmdRunAll.Enabled = False
    End Sub
    Public Function DisplayNumericResult(ByVal Test As String, ByVal Low As Double, ByVal High As Double, ByVal meas As Double)
        Try
            Dim rowIdx As Integer = Me.fgTestItems.FindRow(Test, 1, 1, False, True, False)
            Dim row As Row
            Dim findRow As Boolean = True
            If rowIdx < 1 Then
                row = Me.fgTestItems.Rows.Add()
                rowIdx = row.Index
                findRow = False
            End If

            Me.fgTestItems.Redraw = False

            If findRow = False Then
                Me.fgTestItems(rowIdx, 1) = Test
                Me.fgTestItems(rowIdx, 5) = Low
                Me.fgTestItems(rowIdx, 7) = High
            End If

            Me.fgTestItems(rowIdx, 6) = String.Format("{0:0.000}", meas)

            If meas < Low Or meas > High Then
                Me.fgTestItems(rowIdx, 8) = "FAIL"
                'If Test.Contains("LEN") Then
                '    If meas < Low - 1 Or meas > High - 1 Then
                '        fgTestItems.SetCellStyle(rowIdx, 6, fgTestItems.Styles("DarkOrange"))
                '        fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("DarkOrange"))
                '    Else
                '        fgTestItems.SetCellStyle(rowIdx, 6, fgTestItems.Styles("Red"))
                '        fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Red"))
                '    End If
                'Else
                fgTestItems.SetCellStyle(rowIdx, 6, fgTestItems.Styles("Red"))
                fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Red"))
                'End If
            Else
                Me.fgTestItems(rowIdx, 8) = "PASS"
                fgTestItems.SetCellStyle(rowIdx, 6, fgTestItems.Styles("Black"))
                fgTestItems.SetCellStyle(rowIdx, 8, fgTestItems.Styles("Green"))
            End If

            Me.fgTestItems.Redraw = True

            Me.fgTestItems.ShowCell(rowIdx, 2)

            Return IIf(meas < Low Or meas > High, False, True)
        Catch ex As Exception
            Throw New Exception("DisplayNumericResult() - " & ex.Message)
        End Try
    End Function
    Private Sub BenchSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BenchSettingToolStripMenuItem.Click
        Try
            gBenchSetting = CBenchSetting.CreateInstance(gBenchSettingFileName)
            Dim BenSet As New FormBenchSetting
            BenSet.ShowDialog()
            gBenchSetting = CBenchSetting.CreateInstance(gBenchSettingFileName)
            If gBenchSetting IsNot Nothing Then Me.Mode_Name = gBenchSetting.TestMode
        Catch ex As Exception
            MsgBox("FormGUI.BenchSettingToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Bench Setting Error")
        End Try
    End Sub
    Public Sub AddStatusMsg(ByVal Msg As String, Optional ByVal NewLine As Boolean = True)
        Try
            With Me.TxtStatus
                .AppendText(Msg)
                If NewLine Then .AppendText(vbNewLine)
                .SelectionStart = Len(.Text)
            End With
            My.Application.DoEvents()
        Catch ex As Exception
            Throw New Exception("FormGUI.AddStatusMsgSync()::" & ex.Message)
        End Try
    End Sub

    Private Sub SetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupToolStripMenuItem.Click
        Try
            Dim frmSetup As New FormSetup
            frmSetup.ShowDialog()
        Catch ex As Exception
            MsgBox("FormGUI.SetupToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Open Setup Form Error")
        End Try
    End Sub

    Private Sub MAP200LiveModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MAP200LiveModeToolStripMenuItem.Click
        Try
            FormLiveMode.ShowDialog()
        Catch ex As Exception
            MsgBox("FormGUI.MAP200LiveModeToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Open Live Mode Form Error")
        End Try
    End Sub
    Private Sub SetFormSkin()
        Try
            Dim skinfile As String = "MacOS.ssk"
            Dim skin As New Sunisoft.IrisSkin.SkinEngine
            skin.SkinFile = Application.StartupPath & "\" & skinfile
            skin.Active = True
        Catch ex As Exception
            Throw New Exception("FormMain.SetFormSkin()::" & ex.Message)
        End Try
    End Sub
    Private Sub FormGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'SetFormSkin()
            Me.pbProgress.Value = 0

            Dim cs As CellStyle
            ' Set test phases style
            cs = fgTestPhases.Styles.Add("Blue")
            cs.ForeColor = Color.Blue
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestPhases.Styles.Add("Red")
            cs.BackColor = Color.Red
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestPhases.Styles.Add("Black")
            cs.ForeColor = Color.Black
            cs = fgTestPhases.Styles.Add("Green")
            cs.BackColor = Color.Green
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestPhases.Styles.Add("Alternate")
            cs.BackColor = Color.AliceBlue

            ' Set test groups style
            cs = fgTestGroups.Styles.Add("Blue")
            cs.ForeColor = Color.Blue
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestGroups.Styles.Add("Red")
            cs.BackColor = Color.Red
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestGroups.Styles.Add("Black")
            cs.ForeColor = Color.Black
            cs = fgTestGroups.Styles.Add("Green")
            cs.BackColor = Color.Green
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestGroups.Styles.Add("Alternate")
            cs.BackColor = Color.AliceBlue

            ' Set test items style
            cs = fgTestItems.Styles.Add("Blue")
            cs.Font = New Font(Font.Bold, 9)
            cs.ForeColor = Color.Blue
            cs = fgTestItems.Styles.Add("Red")
            cs.BackColor = Color.Red
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestItems.Styles.Add("Black")
            cs.ForeColor = Color.Black
            cs = fgTestItems.Styles.Add("Green")
            cs.BackColor = Color.Green
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestItems.Styles.Add("DarkOrange")
            cs.BackColor = Color.DarkOrange
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgTestItems.Styles.Add("Alternate")
            cs.BackColor = Color.AliceBlue

            tsslUserName.Text = "User: " & Environment.UserName.ToUpper
            tsslPCName.Text = "PC Name: " & SystemInformation.ComputerName

            InitGridTestPhases()
            InitGridTestGroups()
            InitGridTestItems()

            Me.txtSN1.Focus()
            Me.txtSN1.Select()

            InitInput()

            ShowToolTip()
        Catch ex As Exception
            MsgBox("FormGUI.FormGUI_Load()::" & ex.Message, MsgBoxStyle.Exclamation, "Open FormGUI Error")
        End Try
    End Sub
    Private Sub ShowToolTip()
        Try
            ToolTip1.SetToolTip(Me.ckLoadPFQ, "Show Pass Fail Quantity right after SN and PN is entered, this may slowdown the test because it takes time to query database")
        Catch ex As Exception
            Throw New Exception("ShowToolTip()::" & ex.Message)
        End Try
    End Sub
    Private Sub InitInput()
        Try
            Dim NewFiber = New Fiber
            Dim _InputFiber As InputFiber = Nothing
            If File.Exists(m_fileName) = True Then
                _InputFiber = New InputFiber(m_fileName)
            End If
            If _InputFiber IsNot Nothing Then
                Dim acscSN, acscPN As New AutoCompleteStringCollection
                For Each inputFiber As CInputFiber In _InputFiber.Input_Fiber_List
                    acscSN.Add(inputFiber.Fiber.SN)
                    acscPN.Add(inputFiber.Fiber.PN)
                Next
                Me.txtSN1.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.txtSN1.AutoCompleteCustomSource = acscSN
                Me.txtSN1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.txtSN2.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.txtSN2.AutoCompleteCustomSource = acscSN
                Me.txtSN2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtPN.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtPN.AutoCompleteCustomSource = acscPN
                Me.TxtPN.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
        Catch ex As Exception
            MsgBox("GUI.InitInput()::" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Exclamation, "Init Fiber Input")
        End Try
    End Sub
    Private Sub ClearInput()
        Try
            Me.txtSN1.Clear()
            Me.txtSN1.Enabled = True
            Me.txtSN1.Focus()
            Me.txtSN1.Select()
            Me.txtSN2.Clear()
            Me.txtSN2.Enabled = False
            Me.TxtPN.Clear()
            Me.TxtPN.Enabled = False
        Catch ex As Exception
            MsgBox("GUI.ClearInput()::" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Exclamation, "Clear Fiber Input")
        End Try
    End Sub

    Private Sub InitGridTestPhases()
        Try
            'set up grid
            fgTestPhases.Clear()
            fgTestPhases.Cols.Fixed = 0
            fgTestPhases.Cols.Count = 3
            fgTestPhases.Rows.Fixed = 1
            fgTestPhases.Rows.Count = 1
            fgTestPhases.Cols(0).Caption = "Test Step"
            fgTestPhases.Cols(1).Caption = "Status"
            fgTestPhases.Cols(2).Caption = "Select"

            Dim cs As CellStyle = fgTestPhases.Styles.Add("Select")
            cs.DataType = Type.GetType("System.Boolean")
            fgTestPhases.Cols(2).Style = cs

            FormatGrid(fgTestPhases, 9, 9)

            fgTestPhases.Cols(0).Width = 180
            fgTestPhases.Cols(1).Width = 60
            fgTestPhases.Cols(2).Width = 50

        Catch ex As Exception
            Throw New Exception("InitGridTestPhases()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub InitGridTestGroups()
        Try
            'set up grid
            fgTestGroups.Clear()
            fgTestGroups.Cols.Fixed = 0
            fgTestGroups.Cols.Count = 3
            fgTestGroups.Rows.Fixed = 1
            fgTestGroups.Rows.Count = 1
            fgTestGroups.Cols(0).Caption = "Test Group"
            fgTestGroups.Cols(1).Caption = "Status"
            fgTestGroups.Cols(2).Caption = "Select"

            Dim cs As CellStyle = fgTestGroups.Styles.Add("Select")
            cs.DataType = Type.GetType("System.Boolean")
            fgTestGroups.Cols(2).Style = cs

            FormatGrid(fgTestGroups, 9, 9)

            fgTestGroups.Cols(0).AllowEditing = False
            fgTestGroups.Cols(1).AllowEditing = False

            fgTestGroups.Cols(0).Width = 180
            fgTestGroups.Cols(1).Width = 60
            fgTestGroups.Cols(2).Width = 50

        Catch ex As Exception
            Throw New Exception("InitGridTestGroups()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub InitGridTestItems()
        Try
            'set up grid
            fgTestItems.Clear()
            fgTestItems.Cols.Fixed = 1
            fgTestItems.Cols.Count = 9
            fgTestItems.Rows.Fixed = 1
            fgTestItems.Rows.Count = 1
            fgTestItems.Cols(1).Caption = "Test Item"
            fgTestItems.Cols(2).Caption = "Subunit"
            fgTestItems.Cols(3).Caption = "Fiber"
            fgTestItems.Cols(4).Caption = "Select"
            fgTestItems.Cols(5).Caption = "Min"
            fgTestItems.Cols(6).Caption = "Measure"
            fgTestItems.Cols(7).Caption = "Max"
            fgTestItems.Cols(8).Caption = "Status"

            Dim cs As CellStyle = fgTestItems.Styles.Add("Select")
            cs.DataType = Type.GetType("System.Boolean")
            fgTestItems.Cols(4).Style = cs

            fgTestItems.Cols(4).AllowEditing = True

            FormatGrid(fgTestItems, 9, 9)

            Me.fgTestItems.Cols(5).Format = "0.000"
            Me.fgTestItems.Cols(6).Format = "0.000"
            Me.fgTestItems.Cols(7).Format = "0.000"

            'Me.fgTestItems.Cols(5).Visible = False
            'Me.fgTestItems.Cols(7).Visible = False

            fgTestItems.Cols(0).AllowEditing = False
            fgTestItems.Cols(1).AllowEditing = False
            fgTestItems.Cols(2).AllowEditing = False
            fgTestItems.Cols(3).AllowEditing = False
            fgTestItems.Cols(5).AllowEditing = False
            fgTestItems.Cols(6).AllowEditing = False
            fgTestItems.Cols(7).AllowEditing = False
            fgTestItems.Cols(8).AllowEditing = False

            fgTestItems.Cols(0).Width = 40  'Id
            fgTestItems.Cols(1).Width = 210 'Test Item
            fgTestItems.Cols(2).Width = 60  'Subunit
            fgTestItems.Cols(3).Width = 50  'Fiber
            fgTestItems.Cols(4).Width = 50  'Select
            fgTestItems.Cols(5).Width = 50  'Min
            fgTestItems.Cols(6).Width = 80  'Measure
            fgTestItems.Cols(7).Width = 50  'Max
            fgTestItems.Cols(8).Width = 55  'Status

        Catch ex As Exception
            Throw New Exception("InitGridTestItems()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Public Sub ShowSetup()
        Try
            Me.SetupToolStripMenuItem.PerformClick()
        Catch ex As Exception
            MsgBox("FormGUI.ShowSetup()::" & ex.Message, MsgBoxStyle.Exclamation, "Show Setup Interface Error")
        End Try
    End Sub
    Private Sub txtSN1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSN1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                GUI.txtSN1.ForeColor = SystemColors.WindowText
                GUI.txtSN1.BackColor = SystemColors.Window
                GUI.txtSN2.ForeColor = SystemColors.WindowText
                GUI.txtSN2.BackColor = SystemColors.Window
                If txtSN1.Text.Length = 0 Then Me.txtSN1.Focus() : Me.txtSN1.SelectAll() : Return
                txtSN1.Enabled = False
                Dim SN As String = txtSN1.Text.ToUpper
                If SN.Length = 7 Then
                    SN = String.Format("{0}{1}", DateTime.Today.Year.ToString.Substring(2), Plant_Code) + SN
                    Me.txtSN1.Text = SN
                End If
                txtSN1.Enabled = True
                If gBenchSetting.TestType = numTestType.System Or gBenchSetting.TestType = numTestType.Pigtail Then
                    txtSN2.Enabled = False
                    Me.TxtPN.Enabled = True

                    If gBenchSetting.SAPFailSafeMode = False Then
                        Dim objSerialInq As New SerialNumInq.SerialInq
                        Dim Product As SerialNumInq.Product
                        Product = objSerialInq.GetProduct(SN)
                        If Product IsNot Nothing Then
                            Me.TxtPN.Text = Product.PartNumber
                        Else
                            MsgBox("SAP server maybe down or the SN you entered not in SAP, please switch SAP fail safe mode on", MsgBoxStyle.OkOnly & MsgBoxStyle.Critical)
                            txtSN1.Enabled = True
                            txtSN1.Focus()
                            txtSN1.SelectAll()
                            Return
                        End If

                        Dim PN As String = TxtPN.Text
                        Dim WO As String = Product.OrderNumber

                        If gTestPlan IsNot Nothing Then
                            InitGridTestItems()
                            Dim status As Boolean = gTestPlan.CheckSN(SN, "", PN, WO)
                            CmdRunAll.Enabled = status
                            CmdCAL.Enabled = status
                            CmdRunAll.Focus()
                            CmdRunAll.Select()
                        End If
                    Else
                        Me.TxtPN.Focus()
                        Me.TxtPN.SelectAll()
                    End If
                Else
                    txtSN2.Enabled = True
                    Me.txtSN2.Focus()
                    Me.txtSN2.SelectAll()
                End If
            End If
        Catch ex As Exception
            MsgBox("TxtBarcode_KeyDown()::" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub
    Private Sub txtSN2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSN2.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtSN1.Text.Length = 0 Then Me.txtSN1.Focus() : Me.txtSN1.SelectAll() : Return
                If txtSN2.Text.Length = 0 Then Me.txtSN2.Focus() : Me.txtSN2.SelectAll() : Return
                txtSN2.Enabled = False
                Dim SN1 As String = txtSN1.Text.ToUpper
                Dim SN2 As String = txtSN2.Text.ToUpper

                If SN1 = SN2 Then
                    MsgBox("Two SNs are identical, please check SN", MsgBoxStyle.OkOnly & MsgBoxStyle.Critical)
                    Me.txtSN1.Focus()
                    Me.txtSN1.SelectAll()
                    Return
                End If

                If SN2.Length = 7 Then
                    SN2 = String.Format("{0}{1}", DateTime.Today.Year.ToString.Substring(2), Plant_Code) + SN2
                    Me.txtSN1.Text = SN2
                End If
                If gBenchSetting.SAPFailSafeMode = False Then
                    Dim objSerialInq As New SerialNumInq.SerialInq
                    Dim Product1, Product2 As SerialNumInq.Product
                    Product1 = objSerialInq.GetProduct(SN1)
                    Product2 = objSerialInq.GetProduct(SN2)
                    If Product1 IsNot Nothing And Product2 IsNot Nothing Then
                        If Product1.PartNumber = Product2.PartNumber Then
                            Me.TxtPN.Text = Product1.PartNumber
                        Else
                            MsgBox("Two products are different, please check SN", MsgBoxStyle.OkOnly & MsgBoxStyle.Critical)
                            txtSN1.Enabled = True
                            txtSN1.Focus()
                            txtSN1.SelectAll()
                            Return
                        End If
                    Else
                        MsgBox("SAP server maybe down or the SN you entered not in SAP, please switch SAP fail safe mode on", MsgBoxStyle.OkOnly & MsgBoxStyle.Critical)
                        txtSN1.Enabled = True
                        txtSN1.Focus()
                        txtSN1.SelectAll()
                        Return
                    End If

                    Dim PN As String = TxtPN.Text
                    Dim WO As String = Product1.OrderNumber

                    If gTestPlan IsNot Nothing Then
                        InitGridTestItems()
                        Dim status As Boolean = gTestPlan.CheckSN(SN1, SN2, PN, WO)
                        CmdRunAll.Enabled = status
                        CmdCAL.Enabled = status
                        CmdRunAll.Focus()
                        CmdRunAll.Select()
                    End If
                End If
                Me.TxtPN.Enabled = True
                'Me.TxtPN.Focus()
                'Me.TxtPN.SelectAll()
                txtSN2.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("TxtBarcode_KeyDown()::" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub
    Private Sub TxtPN_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPN.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If gTestPlan IsNot Nothing Then
                    InitGridTestItems()
                    Dim SN1 As String = txtSN1.Text.ToUpper
                    Dim SN2 As String = txtSN2.Text.ToUpper
                    Dim PN As String = TxtPN.Text
                    Dim WO As String = Nothing
                    If gBenchSetting.SAPFailSafeMode = False Then
                        Dim objSerialInq As New SerialNumInq.SerialInq
                        Dim Product As SerialNumInq.Product
                        Product = objSerialInq.GetProduct(SN1)
                        WO = Product.OrderNumber
                    Else
                        WO = "600123"
                    End If
                    If gBenchSetting.TestType = numTestType.System Or gBenchSetting.TestType = numTestType.Pigtail Then
                        If SN1.Length > 0 And PN.Length > 0 Then
                            Dim status As Boolean = gTestPlan.CheckSN(SN1, SN2, PN, WO)
                            CmdRunAll.Enabled = status
                            CmdCAL.Enabled = status
                        End If
                    Else
                        If SN1.Length > 0 And SN2.Length > 0 And PN.Length > 0 Then
                            Dim status As Boolean = gTestPlan.CheckSN(SN1, SN2, PN, WO)
                            CmdRunAll.Enabled = status
                            CmdCAL.Enabled = status
                        End If
                    End If
                    CmdRunAll.Focus()
                    CmdRunAll.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox("TxtPN_KeyDown()::" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "ERROR")
        End Try
    End Sub

    Private Sub fgTestPhases_Click(sender As Object, e As EventArgs) Handles fgTestPhases.Click
        Try
            If gTestPlan Is Nothing Then Return
            If Me.fgTestPhases.Row < 1 Then Return
            If Me.fgTestPhases(fgTestPhases.Row, 2) = True Then Return
            Dim phase As TestPhase
            For i As Integer = Me.fgTestPhases.Rows.Fixed To Me.fgTestPhases.Rows.Count - 1
                phase = CType(Me.fgTestPhases.Rows(i).UserData, TestPhase)
                If i = fgTestPhases.Row Then
                    Me.fgTestPhases(i, 2) = True
                    phase.Selected = True
                    SelectedPhaseName = Me.fgTestPhases(i, 0)
                Else
                    Me.fgTestPhases(i, 2) = False
                    phase.Selected = False
                End If
            Next

            LoadTestItemsGrid(gTestPlan.Spec)

            Dim SN As String = txtSN1.Text.ToUpper
            Dim PN As String = TxtPN.Text

            If ckLoadTestData.Checked Then
                gTestPlan.LoadTestData(SN, PN, SelectedPhaseName)
            End If

        Catch ex As Exception
            MsgBox("fgTestPhases_Click()::" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Change Test Phase Error")
        End Try
    End Sub

    Private Sub CmdCAL_Click(sender As Object, e As EventArgs) Handles CmdCAL.Click
        Try
            If gTestPlan IsNot Nothing Then
                gTestPlan.Calibrate(SelectedPhaseName)
            End If
        Catch ex As Exception
            MsgBox("CmdCAL_Click()::" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Load CAL Interface Error")
        End Try
    End Sub

    Private Sub CmdRunAll_Click(sender As Object, e As EventArgs) Handles CmdRunAll.Click
        Try
            ' Save input antenna SN and PN
            Dim newFiber1 As New Fiber
            newFiber1.SN = Me.txtSN1.Text
            newFiber1.PN = Me.TxtPN.Text
            Dim _InputFiber As InputFiber
            If File.Exists(m_fileName) = False Then
                _InputFiber = New InputFiber(newFiber1)
            Else
                _InputFiber = New InputFiber(m_fileName, newFiber1)
            End If
            _InputFiber.SaveXML(m_fileName)

            Dim newFiber2 As New Fiber
            newFiber2.SN = Me.txtSN2.Text
            newFiber2.PN = Me.TxtPN.Text
            If File.Exists(m_fileName) = False Then
                _InputFiber = New InputFiber(newFiber1)
            Else
                _InputFiber = New InputFiber(m_fileName, newFiber1)
            End If
            _InputFiber.SaveXML(m_fileName)

            EnableForm(False)

            SetStepStatus(GUI.SelectedPhaseName, 1)

            Timer1.Enabled = True

            Dim Cancel As Boolean
            Dim testStep As String = GUI.SelectedPhaseName
            If gTestPlan IsNot Nothing Then
                gTestPlan.RunTest(newFiber1.SN, newFiber2.SN, testStep, False, Cancel)
                If Cancel Then
                    CancelTest(testStep)
                Else
                    EndTest(testStep)
                End If
            End If

        Catch ex As Exception
            AddStatusMsg("RunTest()::" & ex.Message)
        Finally
            Timer1.Enabled = False
            EnableForm(True)
        End Try
    End Sub
    Private Sub EnableForm(ByVal Enable As Boolean)
        CmdAbort.Enabled = Not Enable
        CmdRunAll.Enabled = Enable
        CmdCAL.Enabled = Enable
        fgTestGroups.Enabled = Enable
        fgTestPhases.Enabled = Enable
        fgTestItems.Enabled = Enable
        txtSN1.Enabled = Enable
        If gBenchSetting.TestType = numTestType.Connector Then
            txtSN2.Enabled = True
        Else
            txtSN2.Enabled = False
        End If
        TxtPN.Enabled = Enable
    End Sub
    Private Sub CancelTest(ByVal testStep As String)
        Try
            SetStepStatus(testStep, 4)

            Timer1.Enabled = False

            GUI.ShowLiveValue("", "", "", "", "")
            gTestPlan.CloseLiveDisplay()

            Call EnableForm(True)
        Catch ex As Exception
            Throw New Exception("CancelTest() - " & ex.Message)
        End Try
    End Sub
    Private Sub EndTest(ByVal testStep As String)
        Try
            Dim frmTestComplete As New FormTestComplete

            Timer1.Enabled = False

            SetStepStatus(testStep, 4)

            If (gTestPlan.TestRes.GetPassCount + gTestPlan.TestRes.GetFailCount) > 0 Then
                Dim status As Boolean
                Select Case gTestPlan.TestRes.GetFinalPassFailStatus(gTestPlan.TestPhase.TestGroupList.Count)
                    Case numPFAState.P
                        SetStepStatus(testStep, 2)
                        status = True
                    Case numPFAState.F
                        SetStepStatus(testStep, 3)
                        status = False
                    Case numPFAState.A
                        SetStepStatus(testStep, 4)
                        status = False
                End Select

                If gBenchSetting.TestType = numTestType.Connector Then
                    Dim connStatus As Boolean = gTestPlan.TestRes.GetConenctorTestStatus(False)
                    GUI.txtSN1.ForeColor = Color.White
                    GUI.txtSN1.BackColor = IIf(connStatus, Color.Green, Color.Red)
                    connStatus = gTestPlan.TestRes.GetConenctorTestStatus(True)
                    GUI.txtSN2.ForeColor = Color.White
                    GUI.txtSN2.BackColor = IIf(connStatus, Color.Green, Color.Red)
                Else
                    GUI.txtSN1.ForeColor = Color.White
                    GUI.txtSN1.BackColor = IIf(status, Color.Green, Color.Red)
                End If

                Dim dialogRes As Boolean = frmTestComplete.TestComplete(status, False)

            End If

            GUI.ShowLiveValue("", "", "", "", "")
            gTestPlan.CloseLiveDisplay()

            Call EnableForm(True)

            If GUI.Plant_Code = "CN10" Then
                Me.Select()
                Me.txtSN1.Focus()
                Me.txtSN1.SelectAll()
            Else
                Me.txtSN1.Clear()
                If Me.txtSN2.Enabled Then Me.txtSN2.Clear()
                Me.txtSN1.Focus()
                Me.txtSN1.SelectAll()
            End If

        Catch ex As Exception
            Throw New Exception("EndTest() - " & ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New Action(AddressOf ShowTestTimeSync))
            Else
                ShowTestTimeSync()
            End If
        Catch ex As Exception
            MsgBox("Timer1_Tick() - " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Exception")
        End Try
    End Sub
    Private Sub ShowTestTimeSync()
        Try
            Dim tSpan As TimeSpan = DateTime.Now - gTestPlan.TestRes.Head.MeasStartTime
            Me.tsslCycleTime.Text = String.Format("Elapsed Time: {0:00}:{1:00}:{2:00} ", tSpan.Hours, tSpan.Minutes, tSpan.Seconds)
        Catch ex As Exception
            Throw New Exception("ShowTestTimeSync() - " & ex.Message)
        End Try
    End Sub

    Private Sub FormGUI_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                CmdRunAll.PerformClick()
            End If
            If e.KeyCode = Keys.F3 Then
                CmdCAL.PerformClick()
            End If
        Catch ex As Exception
            MsgBox("FormGUI_KeyDown() - " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "FormGUI Key Down Error")
        End Try
    End Sub

    Private Sub FormGUI_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Try
            If e.KeyData = Keys.Control + Keys.R Then
                CmdRunAll.PerformClick()
            End If
            If e.KeyData = Keys.Control + Keys.C Then
                CmdCAL.PerformClick()
            End If
        Catch ex As Exception
            MsgBox("FormGUI_KeyUp() - " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "FormGUI Key Up Error")
        End Try
    End Sub

    Private Sub fgTestItems_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgTestItems.OwnerDrawCell
        Try
            If e.Row >= fgTestItems.Rows.Fixed And e.Col = fgTestItems.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgTestItems.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormGUI.fgTestItems_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            Dim ti As TestItem
            Dim tg As TestGroup
            For i As Integer = fgTestItems.Rows.Fixed To fgTestItems.Rows.Count - 1
                fgTestItems.Rows(i).Item(4) = True
                ti = CType(fgTestItems.Rows(i).UserData, TestItem)
                ti.Selected = True
            Next
            For i As Integer = fgTestGroups.Rows.Fixed To fgTestGroups.Rows.Count - 1
                fgTestGroups.Rows(i).Item(2) = True
                tg = CType(fgTestGroups.Rows(i).UserData, TestGroup)
                tg.Selected = True
            Next
        Catch ex As Exception
            MsgBox("FormGUI.SelectAllToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Select All Test Items Error")
        End Try
    End Sub

    Private Sub SelectNothingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNothingToolStripMenuItem.Click
        Try
            Dim ti As TestItem
            Dim tg As TestGroup
            For i As Integer = fgTestItems.Rows.Fixed To fgTestItems.Rows.Count - 1
                fgTestItems.Rows(i).Item(4) = False
                ti = CType(fgTestItems.Rows(i).UserData, TestItem)
                ti.Selected = False
            Next
            For i As Integer = fgTestGroups.Rows.Fixed To fgTestGroups.Rows.Count - 1
                fgTestGroups.Rows(i).Item(2) = False
                tg = CType(fgTestGroups.Rows(i).UserData, TestGroup)
                tg.Selected = False
            Next
        Catch ex As Exception
            MsgBox("FormGUI.SelectNothingToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Select Nothing Error")
        End Try
    End Sub
    Private Sub fgTestGroups_Click(sender As Object, e As EventArgs) Handles fgTestGroups.Click
        Try
            Dim selectedRowIdx As Integer = Me.fgTestGroups.Row
            If selectedRowIdx < 1 Then Return
            Dim ti As TestItem
            Dim tg As TestGroup

            fgTestItems.Redraw = False
            fgTestGroups.Redraw = False
            Dim coupledGroupIdx As Integer
            Dim coupledGroupSelected As Boolean
            Dim selectedTg As TestGroup = CType(fgTestGroups.Rows(selectedRowIdx).UserData, TestGroup)
            coupledGroupSelected = CBool(fgTestGroups(selectedRowIdx, 2))
            If selectedTg.GroupId Mod 2 = 0 Then
                coupledGroupIdx = selectedTg.GroupId - 1
            Else
                coupledGroupIdx = selectedTg.GroupId + 1
            End If
            If Me.fgTestGroups.Col = 2 Then
                For i As Integer = fgTestGroups.Rows.Fixed To fgTestGroups.Rows.Count - 1
                    tg = CType(fgTestGroups.Rows(i).UserData, TestGroup)
                    fgTestGroups(i, 2) = CBool(fgTestGroups(i, 2))
                    tg.Selected = CBool(fgTestGroups(i, 2))
                    If tg.GroupId = selectedTg.GroupId Or tg.GroupId = coupledGroupIdx Then
                        fgTestGroups(i, 2) = coupledGroupSelected
                        tg.Selected = coupledGroupSelected
                    End If
                Next
            Else
                For i As Integer = fgTestGroups.Rows.Fixed To fgTestGroups.Rows.Count - 1
                    tg = CType(fgTestGroups.Rows(i).UserData, TestGroup)
                    fgTestGroups(i, 2) = False
                    tg.Selected = False
                    If tg.GroupId = selectedTg.GroupId Or tg.GroupId = coupledGroupIdx Then
                        fgTestGroups(i, 2) = True
                        tg.Selected = True
                    End If
                Next
            End If

            For i As Integer = fgTestItems.Rows.Fixed To fgTestItems.Rows.Count - 1
                fgTestItems(i, 4) = False
                ti = CType(fgTestItems.Rows(i).UserData, TestItem)
                ti.Selected = False
                If ti.ParentGroup.Selected Then
                    fgTestItems(i, 4) = True
                    ti.Selected = True
                End If
            Next

            fgTestItems.Redraw = True
            fgTestGroups.Redraw = True

            Me.fgTestItems.TopRow = GetFirstSelectedRow(fgTestItems)

        Catch ex As Exception
            MsgBox("FormGUI.fgTestGroups_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Select Test Group Error")
        End Try
    End Sub
    Private Function GetFirstSelectedRow(flexGrid As C1FlexGrid) As Integer
        Try
            For iRow As Integer = 1 To flexGrid.Rows.Count - 1
                If flexGrid(iRow, 4) = True Then Return iRow : Exit For
            Next
            Return 0
        Catch ex As Exception
            Throw New Exception("GetFirstSelectedRow() - " & ex.Message)
        End Try
    End Function
    Private Sub fgTestItems_Click(sender As Object, e As EventArgs) Handles fgTestItems.Click
        Try
            Dim selectedRowIdx As Integer = Me.fgTestItems.Row
            If selectedRowIdx < 1 Then Return
            Dim ti As TestItem
            Dim tg As TestGroup

            fgTestItems.Redraw = False
            fgTestGroups.Redraw = False
            Dim coupledGroupIdx As Integer
            Dim coupledGroupSelected As Boolean
            Dim selectedTi As TestItem
            selectedTi = CType(fgTestItems.Rows(selectedRowIdx).UserData, TestItem)
            coupledGroupSelected = CBool(fgTestItems(selectedRowIdx, 4))
            If selectedTi.ParentGroup.GroupId Mod 2 = 0 Then
                coupledGroupIdx = selectedTi.ParentGroup.GroupId - 1
            Else
                coupledGroupIdx = selectedTi.ParentGroup.GroupId + 1
            End If
            If fgTestItems.Col = 4 Then
                For i As Integer = fgTestItems.Rows.Fixed To fgTestItems.Rows.Count - 1
                    ti = CType(fgTestItems.Rows(i).UserData, TestItem)
                    fgTestItems(i, 4) = CBool(fgTestItems(i, 4))
                    ti.Selected = CBool(fgTestItems(i, 4))
                    If ti.ParentGroup.GroupId = selectedTi.ParentGroup.GroupId Or ti.ParentGroup.GroupId = coupledGroupIdx Then
                        fgTestItems(i, 4) = coupledGroupSelected
                        ti.Selected = coupledGroupSelected
                    End If
                Next
            Else
                For i As Integer = fgTestItems.Rows.Fixed To fgTestItems.Rows.Count - 1
                    ti = CType(fgTestItems.Rows(i).UserData, TestItem)
                    fgTestItems(i, 4) = False
                    ti.Selected = False
                    If ti.ParentGroup.GroupId = selectedTi.ParentGroup.GroupId Or ti.ParentGroup.GroupId = coupledGroupIdx Then
                        fgTestItems(i, 4) = True
                        ti.Selected = True
                    End If
                Next
            End If

            Me.fgTestGroups.Select()
            For i As Integer = fgTestGroups.Rows.Fixed To fgTestGroups.Rows.Count - 1
                fgTestGroups(i, 2) = False
                tg = CType(fgTestGroups.Rows(i).UserData, TestGroup)
                tg.Selected = False
                For Each item As TestItem In tg.TestItemList
                    If item.Selected Then
                        fgTestGroups(i, 2) = True
                        tg.Selected = True
                    End If
                Next
            Next

            fgTestItems.Redraw = True
            fgTestGroups.Redraw = True

        Catch ex As Exception
            MsgBox("FormGUI.fgTestItems_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Select Test Item Error")
        End Try
    End Sub

    Private Sub UploadTestDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadTestDataToolStripMenuItem.Click
        Try
            If gTestPlan Is Nothing Then Return
            gTestPlan.SaveTestRes(True)
        Catch ex As Exception
            MsgBox("FormGUI.UploadTestDataToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Upload Test Data Error")
        End Try
    End Sub

    Private Sub FormGUI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMain.Close()
    End Sub

    Private Sub ShowPFDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowPFDetailToolStripMenuItem.Click
        Try
            Dim frmPFDetail As New FormPFDetail(Me.txtSN1.Text)
            frmPFDetail.ShowDialog()
        Catch ex As Exception
            MsgBox("FormGUI.ShowPFDetailToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Show PF Detail Error")
        End Try
    End Sub
End Class

Public Class Fiber
    Public SN As String
    Public PN As String
    Public Sub New(SN As String)
        SN = SN
    End Sub
    Public Sub New()

    End Sub
    Public Sub New(ByVal NdId As XmlNode)
        For Each nd As XmlNode In NdId
            If nd.Name = "Fiber" Then
                Dim keystr As String = nd.Attributes("Key").Value
                Dim valuestr As String = nd.Attributes("Value").Value
                Select Case keystr
                    Case "SN"
                        SN = valuestr.ToUpper
                    Case "PN"
                        PN = valuestr.ToUpper
                End Select
            End If
        Next
    End Sub
End Class
Public Class CInputFiber
    Public Fiber As Fiber
    Public id As Integer
End Class
Public Class InputFiber
    Public Input_Fiber_List As List(Of CInputFiber)
    Public Sub New(newFiber As Fiber)
        Dim newInputFiber As New CInputFiber
        newInputFiber.id = 1
        newInputFiber.Fiber = newFiber
        Input_Fiber_List = New List(Of CInputFiber)
        Input_Fiber_List.Add(newInputFiber)
    End Sub
    Public Sub New(ByVal filename As String, newFiber As Fiber)
        Try
            Dim XDoc As New XmlDocument
            XDoc.Load(filename)
            Dim InputFiberNode As XmlNode = XDoc.DocumentElement.SelectSingleNode("/InputFiber")
            Input_Fiber_List = New List(Of CInputFiber)
            Dim newInputFiber As CInputFiber
            If InputFiberNode.ChildNodes.Count > 0 Then
                For Each nd As XmlNode In InputFiberNode.ChildNodes
                    newInputFiber = New CInputFiber
                    newInputFiber.id = Integer.Parse(nd.Attributes("Number").Value)
                    newInputFiber.Fiber = New Fiber(nd)
                    Input_Fiber_List.Add(newInputFiber)
                Next
            End If
            If Input_Fiber_List.Count > 9 Then
                Input_Fiber_List.RemoveAt(0)
            End If
            newInputFiber = New CInputFiber
            newInputFiber.id = Input_Fiber_List.FindLast(Function(o) o.id > 0).id + 1
            newInputFiber.Fiber = newFiber
            Input_Fiber_List.Add(newInputFiber)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub New(ByVal filename As String)
        Try
            Dim XDoc As New XmlDocument
            XDoc.Load(filename)
            Dim InputFiberNode As XmlNode = XDoc.DocumentElement.SelectSingleNode("/InputFiber")
            Input_Fiber_List = New List(Of CInputFiber)
            Dim newInputFiber As CInputFiber
            If InputFiberNode.ChildNodes.Count > 0 Then
                For Each nd As XmlNode In InputFiberNode.ChildNodes
                    newInputFiber = New CInputFiber
                    newInputFiber.id = Integer.Parse(nd.Attributes("Number").Value)
                    newInputFiber.Fiber = New Fiber(nd)
                    Input_Fiber_List.Add(newInputFiber)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub SaveXML(ByVal filename As String)
        Try
            Dim XDoc As New XmlDocument
            Dim rtnd As XmlNode = XDoc.CreateElement("InputFiber")
            Dim att As XmlAttribute = XDoc.CreateAttribute("date")
            att.Value = Now
            rtnd.Attributes.Append(att)
            XDoc.AppendChild(rtnd)

            For Each inputFiber As CInputFiber In Input_Fiber_List
                Dim idNode As XmlNode = XDoc.CreateElement("ID")
                att = XDoc.CreateAttribute("Number")
                att.Value = inputFiber.id
                idNode.Attributes.Append(att)
                rtnd.AppendChild(idNode)

                idNode.AppendChild(AddPara(XDoc, "SN", inputFiber.Fiber.SN))
                idNode.AppendChild(AddPara(XDoc, "PN", inputFiber.Fiber.PN))
            Next

            XDoc.Save(filename)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Function AddPara(ByVal XDoc As XmlDocument, ByVal key As String, ByVal value As String) As XmlNode
        Try
            Dim nd As XmlNode = XDoc.CreateElement("Fiber")

            Dim att As XmlAttribute = XDoc.CreateAttribute("Key")
            att.Value = key
            nd.Attributes.Append(att)

            att = XDoc.CreateAttribute("Value")
            att.Value = value
            nd.Attributes.Append(att)
            Return nd
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class