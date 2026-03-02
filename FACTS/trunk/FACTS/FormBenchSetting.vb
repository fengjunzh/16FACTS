Imports System.IO
Imports System.Xml.Serialization
Imports C1.Win.C1FlexGrid
Imports FACTS.Model
Imports SerialNumInq

Public Class FormBenchSetting
    Private productM As FACTS.Model.product_main
    Private SwitchPortMapSettingFileName As String
    Private _SwitchPortMap As CSwitchPortMapping = Nothing
    Private Spec As TestSpec = Nothing
    Private Sub btnInstrumentCk_Click(sender As Object, e As EventArgs) Handles btnInstrumentCk.Click
        Try
            btnInstrumentCk.Enabled = False

            GUI.ProgressMinmum = 0
            GUI.ProgressMaximum = 4
            GUI.ProgressBarValue = 1

            InitializeCMR(Me.txtIPAddress.Text, Me.cbInstrumentType.Text)
            GUI.ProgressBarValue += 1

            Dim iviv As IVIAVI = CType(pInstCtrl, IVIAVI)

            If iviv Is Nothing Then Return

            If iviv.PCTState = 0 Then iviv.LaunchPCT()
            GUI.ProgressBarValue += 1

            If iviv.PCTState = 1 Then
                Dim viv As New SCPIInstrument
                viv.IPAddress = Me.txtIPAddress.Text
                viv.PortNumber = Me.txtPort.Text
                viv.Open()
                Me.txtIDN.Text = viv.IDNString
            End If
            GUI.ProgressBarValue += 1

        Catch ex As Exception
            MsgBox("FormBenchSetting().btnInstrumentCk_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Check Instrument Connection Error")
        Finally
            btnInstrumentCk.Enabled = True
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If gBenchSetting IsNot Nothing Then gBenchSetting = Nothing
            gBenchSetting = New CBenchSetting
            With gBenchSetting
                .TestMode = cbTestMode.Text
                .TestPhaseStation = cbPhaseStation.Text
                .TestPhaseStationMainId = gTestPlan.LoadPhaseStation(cbTestMode.Text, cbPhaseStation.Text)
                If Integer.TryParse(txtCalHour.Text, .CalHour) = False Then
                    .CalHour = gCalInterval
                Else
                    .CalHour = Integer.Parse(txtCalHour.Text)
                End If
                .Program = tbProgram.Text
                .IpAddress = Me.txtIPAddress.Text
                .Port = Me.txtPort.Text
                .SAPFailSafeMode = ckSAPFailSafeMode.Checked
                .InstrumentType = Me.cbInstrumentType.Text
                .RecJumperCalType = [Enum].Parse(GetType(numJumperCalType), Me.cbRecJumperCalType.Text)
                .RecJumperLength = Me.tbRecJumperLength.Text
                Dim retryCountStr As String = Me.txtRetryCount.Text
                Dim retryCount As Integer
                If retryCountStr.Length = 0 Then
                    MsgBox("Please enter retry count!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Set Retry Count")
                    Exit Sub
                Else
                    If Integer.TryParse(retryCountStr, retryCount) = False Then
                        MsgBox("Please enter correct retry count!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Set Retry Count")
                        Exit Sub
                    End If
                End If
                If retryCount > 2 Then retryCount = 2
                If retryCount < 1 Then retryCount = 0
                .RetryCount = retryCount
                .LiveMode = ckLiveMode.Checked
                If rbSystem.Checked Then
                    .TestType = numTestType.System
                ElseIf rbConnector.Checked Then
                    .TestType = numTestType.Connector
                Else
                    .TestType = numTestType.Pigtail
                End If
                GUI.TestType = .TestType
                GUI.RetryCount = .RetryCount
                .Save(gBenchSettingFileName)
            End With

            GUI.Mode_Name = gBenchSetting.TestMode
            GUI.SAP_Fail_Safe_Mode = gBenchSetting.SAPFailSafeMode
            GUI.CollapseLiveModePanel = Not ckLiveMode.Checked

            If Me.fgSwitchPortMapping.Rows.Count > 1 Then
                If _SwitchPortMap IsNot Nothing Then _SwitchPortMap = Nothing
                _SwitchPortMap = New CSwitchPortMapping
                SwitchPortMapSettingFileName = String.Format("{0}\{1}.xml", My.Application.Info.DirectoryPath, "SwitchPortMapping")
                With _SwitchPortMap
                    .PortMapList = GetAntennaSwitchPortMap()
                    .Save(SwitchPortMapSettingFileName)
                End With
            End If

            GUI.ClearGui()

            Close()

        Catch ex As Exception
            MsgBox("FormBenchSetting.btnSave_Click()::" & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Save Error")
        End Try
    End Sub
    Private Function GetAntennaSwitchPortMap() As List(Of CPortMap)
        Try
            Dim resp As New List(Of CPortMap)
            Dim item As CPortMap

            Dim row As Row
            For i As Integer = fgSwitchPortMapping.Rows.Fixed To fgSwitchPortMapping.Rows.Count - 1
                item = New CPortMap
                row = fgSwitchPortMapping.Rows(i)
                item.FiberId = row(1)
                item.SwitchPortId = row(2)
                resp.Add(item)
            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("GetAntennaSwitchPortMap() - " & ex.Message)
        End Try
    End Function
    Private Sub AddMachineModel()
        Try
            Me.cbInstrumentType.Items.Clear()
            Me.cbInstrumentType.Items.AddRange([Enum].GetNames(GetType(numModel)))
        Catch ex As Exception
            Throw New Exception("AddModel()::" & ex.Message)
        End Try
    End Sub
    Private Sub AddRecJumperCalType()
        Try
            Me.cbRecJumperCalType.Items.Clear()

            For Each calType In [Enum].GetValues(GetType(numJumperCalType))
                If calType = 0 Then Continue For
                Me.cbRecJumperCalType.Items.Add(calType.ToString)
            Next
            Me.cbRecJumperCalType.SelectedIndex = 1
        Catch ex As Exception
            Throw New Exception("AddRecJumperCalType()::" & ex.Message)
        End Try
    End Sub
    Private Sub FormBenchSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AddMachineModel()
            AddRecJumperCalType

            Dim modeML As List(Of FACTS.Model.mode)
            Dim mode As New FACTS.BLL.modeManager
            cbTestMode.Items.Clear()
            modeML = mode.SelectAll
            Me.cbTestMode.Items.AddRange(modeML.ToArray)

            With gBenchSetting
                cbTestMode.Text = .TestMode
                cbPhaseStation.Text = .TestPhaseStation
                tbProgram.Text = .Program
                txtCalHour.Text = gCalInterval
                txtIPAddress.Text = .IpAddress
                txtPort.Text = .Port
                ckSAPFailSafeMode.Checked = .SAPFailSafeMode
                cbRecJumperCalType.Text = [Enum].Parse(GetType(numJumperCalType), .RecJumperCalType).ToString
                tbRecJumperLength.Text = .RecJumperLength
                Me.cbInstrumentType.Text = .InstrumentType
                Me.txtRetryCount.Text = .RetryCount.ToString
                Me.ckLiveMode.Checked = .LiveMode
                If .TestType = numTestType.System Then
                    rbSystem.Checked = True
                ElseIf .TestType = numTestType.Connector Then
                    rbConnector.Checked = True
                Else
                    rbPigtail.Checked = True
                End If
            End With

            LoadFgAntSwmConfig()

        Catch ex As Exception
            MsgBox("FormBenchSetting.FormBenchSetting_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load Form Error")
        End Try
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            Dim dlg As New OpenFileDialog()
            With dlg
                .CheckFileExists = True
                .CheckPathExists = True
                .Multiselect = False
                .InitialDirectory = System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()
                .Filter = "All files (*.*)|*.*||ResultTransferGUI.exe"
                .FilterIndex = 2
                .ShowDialog()
                If .FileName <> "" Then
                    tbProgram.Text = .FileName
                End If
            End With
        Catch ex As Exception
            MsgBox("btnSelect_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub InitfgSwitchPortMapping()
        Try
            'set up grid
            fgSwitchPortMapping.Clear()
            fgSwitchPortMapping.Cols.Fixed = 1
            fgSwitchPortMapping.Cols.Count = 3
            fgSwitchPortMapping.Rows.Fixed = 1
            fgSwitchPortMapping.Rows.Count = 1
            fgSwitchPortMapping.Cols(1).Caption = "Fiber Id"
            fgSwitchPortMapping.Cols(2).Caption = "Switch Port Id"

            fgSwitchPortMapping.Cols(1).AllowEditing = False

            FormatGrid(fgSwitchPortMapping, 9, 9)

        Catch ex As Exception
            Throw New Exception("InitfgAntSwmConfig()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub LoadFgAntSwmConfig()
        Try
            SwitchPortMapSettingFileName = String.Format("{0}\{1}.xml", My.Application.Info.DirectoryPath, "SwitchPortMapping")
            _SwitchPortMap = CSwitchPortMapping.CreateInstance(SwitchPortMapSettingFileName)

            If _SwitchPortMap Is Nothing Then
                InitSwitchPortMapping()
            Else
                InitfgSwitchPortMapping()
                Dim row As Row
                With _SwitchPortMap
                    For Each portMap As CPortMap In .PortMapList
                        row = fgSwitchPortMapping.Rows.Add()
                        row(1) = portMap.FiberId
                        row(2) = portMap.SwitchPortId
                    Next

                End With
                FormatGrid(fgSwitchPortMapping, 9, 9)
            End If
        Catch ex As Exception
            Throw New Exception("LoadFgAntSwmConfig()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub InitSwitchPortMapping()
        Try
            InitfgSwitchPortMapping()

            Dim row As Row
            For i As Integer = 1 To 24
                row = fgSwitchPortMapping.Rows.Add()
                row(1) = i
                row(2) = i
            Next

            FormatGrid(fgSwitchPortMapping, 9, 9)

        Catch ex As Exception
            MsgBox("btnNew_Click()::" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "New Config Error")
        End Try
    End Sub
    Private Sub fgSwitchPortMapping_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgSwitchPortMapping.OwnerDrawCell
        Try
            If e.Row >= fgSwitchPortMapping.Rows.Fixed And e.Col = fgSwitchPortMapping.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgSwitchPortMapping.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("fgSwitchPortMapping_OwnerDrawCell()::" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Owner Draw Cell Error")
        End Try
    End Sub

    Private Sub cbRecJumperCalType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRecJumperCalType.SelectedIndexChanged
        Try
            If [Enum].Parse(GetType(numJumperCalType), Me.cbRecJumperCalType.Text) = numJumperCalType.Real Then
                Me.tbRecJumperLength.Enabled = False
            Else
                Me.tbRecJumperLength.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("cbRecJumperCalType_SelectedIndexChanged()::" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Select Rec Jumer Cal Type")
        End Try
    End Sub
End Class
Public Class CBenchSetting
    Public TestMode As String
    Public TestPhaseStation As String
    Public TestPhaseStationMainId As String
    Public InstrumentType As String
    Public IpAddress As String
    Public Port As String
    Public CalHour As Integer
    Public Program As String
    Public SAPFailSafeMode As Boolean
    Public RetryCount As SByte
    Public LiveMode As Boolean
    Public TestType As numTestType
    Public RecJumperCalType As numJumperCalType
    Public RecJumperLength As Decimal
    Public Sub Save(ByVal filename As String)
        Try
            Dim XSerz As New XmlSerializer(Me.GetType)
            Dim StrmWt As New System.IO.StreamWriter(filename)
            XSerz.Serialize(StrmWt, Me)
            StrmWt.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Shared Function CreateInstance(ByVal filename As String) As CBenchSetting
        Try
            If My.Computer.FileSystem.FileExists(filename) = False Then
                Return Nothing
            Else
                Dim BenchSetting As CBenchSetting = Nothing
                Using StrmRd As New System.IO.StreamReader(filename)
                    Dim XSerz As New XmlSerializer(GetType(CBenchSetting))
                    BenchSetting = CType(XSerz.Deserialize(StrmRd), CBenchSetting)
                    StrmRd.Close()
                End Using
                Return BenchSetting
            End If
        Catch ex As Exception
            Throw New Exception(String.Format("Read file '{0}' fail!", filename) & vbNewLine & ex.Message)
        End Try
    End Function

End Class
Public Class CPortMap

    <XmlAttribute>
    Public Property FiberId As Integer
    <XmlElement>
    Public Property SwitchPortId As Integer
End Class
Public Class CSwitchPortMapping
    <XmlElement("PortMap")>
    Public PortMapList As New List(Of CPortMap)

    Public Sub Save(ByVal filename As String)
        Try
            Dim XSerz As New XmlSerializer(Me.GetType)
            Dim StrmWt As New System.IO.StreamWriter(filename)
            XSerz.Serialize(StrmWt, Me)
            StrmWt.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Shared Function CreateInstance(ByVal filename As String) As CSwitchPortMapping
        Try
            If My.Computer.FileSystem.FileExists(filename) = False Then
                Return Nothing
            Else
                Dim SwitchPortMap As CSwitchPortMapping = Nothing
                Using StrmRd As New System.IO.StreamReader(filename)
                    Dim XSerz As New XmlSerializer(GetType(CSwitchPortMapping))
                    SwitchPortMap = CType(XSerz.Deserialize(StrmRd), CSwitchPortMapping)
                    StrmRd.Close()
                End Using
                Return SwitchPortMap
            End If
        Catch ex As Exception
            Throw New Exception(String.Format("Read file '{0}' fail!", filename) & vbNewLine & ex.Message)
        End Try
    End Function
End Class

