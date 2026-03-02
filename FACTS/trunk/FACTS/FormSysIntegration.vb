Imports System.Data.SqlTypes
Imports System.Xml.Serialization
Imports C1.Win.C1FlexGrid

Public Class FormSysIntegration
    Private IVIV As IVIAVI
    Private FPDReady As Boolean
    Private FPPReady As Boolean
    Private SPLReady As Boolean
    Private NumChannel As Integer
    Public Sub New(viv As IVIAVI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        IVIV = viv
    End Sub
    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        If FPDReady And FPPReady And SPLReady Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub
    Private Sub ClearFgFPDNewValue()
        Try
            For Each r As Row In Me.fgFPD.Rows
                If r.Index = 0 Then Continue For
                r(4) = ""
            Next
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.ClearFgFPDNewValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub ClearFgFPPNewValue()
        Try
            For Each r As Row In Me.fgFPP.Rows
                If r.Index = 0 Then Continue For
                r(3) = ""
            Next
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.ClearFgFPPNewValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub ClearFgSPLNewValue()
        Try
            For Each r As Row In Me.fgSPL.Rows
                If r.Index = 0 Then Continue For
                r(4) = ""
            Next
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.ClearFgSPLNewValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub InitFgFPD()
        Try
            'set up grid
            fgFPD.Clear(ClearFlags.Content)
            fgFPD.Cols.Fixed = 1
            fgFPD.Cols.Count = 5
            fgFPD.Rows.Fixed = 1
            fgFPD.Rows.Count = 1
            fgFPD.Cols(1).Caption = "Wavelength"
            fgFPD.Cols(2).Caption = "Factory"
            fgFPD.Cols(3).Caption = "Current Value"
            fgFPD.Cols(4).Caption = "New Distance(m)"

            Dim cs As CellStyle
            cs = fgFPD.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            FormatGrid(fgFPD, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormSysIntegration.InitFgFPD()::" & ex.Message)
        End Try
    End Sub
    Private Sub InitFgFPP()
        Try
            'set up grid
            fgFPP.Clear(ClearFlags.Content)
            fgFPP.Cols.Fixed = 1
            fgFPP.Cols.Count = 4
            fgFPP.Rows.Fixed = 1
            fgFPP.Rows.Count = 1
            fgFPP.Cols(1).Caption = "Wavelength"
            fgFPP.Cols(2).Caption = "Current Value"
            fgFPP.Cols(3).Caption = "New Value"

            Dim cs As CellStyle
            cs = fgFPP.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            FormatGrid(fgFPP, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormSysIntegration.InitFgFPP()::" & ex.Message)
        End Try
    End Sub

    Private Sub fgFPD_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgFPD.OwnerDrawCell
        Try
            If e.Row >= fgFPD.Rows.Fixed And e.Col = fgFPD.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgFPD.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormSysIntegration.fgFPD_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub FormSysIntegration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FPDReady = True
            FPPReady = True
            SPLReady = True

            gSysIntegration = (New BLL.system_integrationManager).SelectBySN(pInstCtrl.Serial_Number)
            If gSysIntegration Is Nothing Then
                FPDReady = False
                FPPReady = False
                SPLReady = False
            Else
                If Now.Subtract(gSysIntegration.Fpd_finish_datetime).Days > gSysIntegrationDays Or gSysIntegration.Fpd_result = False Then FPDReady = False
                If Now.Subtract(gSysIntegration.Fpp_finish_datetime).Days > gSysIntegrationDays Or gSysIntegration.Fpp_result = False Then FPPReady = False
                If Now.Subtract(gSysIntegration.Spl_finish_datetime).Days > gSysIntegrationDays Or gSysIntegration.Spl_result = False Then SPLReady = False
                Me.nudChannelNum.Value = IIf(gSysIntegration.Spl_channel_num = 0, 2, gSysIntegration.Spl_channel_num)
                NumChannel = Me.nudChannelNum.Value
                LoadFgFPDValue()
                LoadFgFPPValue()
                LoadFgSPLValue()
            End If

            lblFPDState.BackColor = IIf(FPDReady, Color.LimeGreen, SystemColors.ControlDark)
            lblFPPState.BackColor = IIf(FPPReady, Color.LimeGreen, SystemColors.ControlDark)
            lblSPLState.BackColor = IIf(SPLReady, Color.LimeGreen, SystemColors.ControlDark)

            Me.btnFPPStartAdjustment.Enabled = FPDReady
            Me.btnSPLStartAdjustment.Enabled = FPDReady And FPPReady

        Catch ex As Exception
            MsgBox("FormSysIntegration.FormSysIntegration_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub fgFPP_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgFPP.OwnerDrawCell
        Try
            If e.Row >= fgFPP.Rows.Fixed And e.Col = fgFPP.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgFPP.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormSysIntegration.fgFPP_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub InitFgSPL()
        Try
            'set up grid
            fgSPL.Clear(ClearFlags.Content)
            fgSPL.Cols.Fixed = 1
            fgSPL.Cols.Count = 5
            fgSPL.Rows.Fixed = 1
            fgSPL.Rows.Count = 1
            fgSPL.Cols(1).Caption = "Channel"
            fgSPL.Cols(2).Caption = "Wavelength"
            fgSPL.Cols(3).Caption = "Current Value"
            fgSPL.Cols(4).Caption = "New Distance(m)"

            Dim cs As CellStyle
            cs = fgSPL.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            FormatGrid(fgSPL, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormSysIntegration.InitFgSPL()::" & ex.Message)
        End Try
    End Sub

    Private Sub fgSPL_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgSPL.OwnerDrawCell
        Try
            If e.Row >= fgFPP.Rows.Fixed And e.Col = fgFPP.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgFPP.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormSysIntegration.fgFPP_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnFPDStartAdjustment_Click(sender As Object, e As EventArgs) Handles btnFPDStartAdjustment.Click
        Try
            If FormFPDConnPrompt.ShowDialog = DialogResult.OK Then
                ClearFgFPDNewValue()
                Me.gbFPD.Enabled = False
                Me.pgBar.Minimum = 0
                Me.pgBar.Maximum = 50
                Me.pgBar.Value = 0
                Dim startTime As DateTime = Now
                Me.tsslStatus.Text = "Front pannel distance adjusment in process......"
                Me.lblFPDStatus.BackColor = Color.Yellow
                ' Front Panel Distance Adjustment
                IVIV.FactoryCalMeasStart(1)
                Dim respStr As String
                Do
                    respStr = IVIV.WaitOPCResponse(1)
                    ShowFactoryCalElapsedTime(startTime)
                    If Me.pgBar.Value < Me.pgBar.Maximum Then Me.pgBar.Value += 1
                    My.Application.DoEvents()
                Loop Until (respStr.StartsWith("1"))
                LoadFgFPDValue()
                FPDReady = False
                Me.lblFPDStatus.BackColor = Color.LimeGreen
                Me.tsslStatus.Text = "Front pannel distance adjusment complete"
                Me.btnFPDSaveNewValues.Enabled = Enabled
                Me.pgBar.Value = Me.pgBar.Maximum
            End If
        Catch ex As Exception
            Me.lblFPDStatus.BackColor = Color.Red
            Me.btnFPDSaveNewValues.Enabled = False
            MsgBox("FormSysIntegration.btnFPDStartAdjustment_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.gbFPD.Enabled = True
        End Try
    End Sub
    Private Sub LoadFgSPLValue()
        Try
            InitFgSPL()
            Dim i As Integer
            Dim r As Row = Nothing
            Dim colIdx As Integer
            For j As Integer = 1 To NumChannel
                i = 0
                Dim value As String = IVIV.SwitchPathLength(j)
                For Each val As String In value.Split(",")
                    If i Mod 3 = 0 Then r = Me.fgSPL.Rows.Add() : r(1) = j
                    If r Is Nothing Then r = Me.fgFPD.Rows.Add()
                    colIdx = i Mod 3 + 2
                    r(colIdx) = val
                    If fgSPL.Cols(colIdx).Caption = "Current Value" Then
                        If val = 0 Then SPLReady = False
                    End If

                    i += 1
                Next
            Next
            FormatGrid(fgSPL, 9, 9)
            fgSPL.Row = -1
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.LoadFgFPPValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadFgFPDValue()
        Try
            InitFgFPD()
            Dim fpdStr As String = IVIV.FrontPanelDistance
            Dim r As Row = Nothing
            Dim i As Integer
            Dim colIdx As Integer
            For Each val As String In fpdStr.Split(",")
                If i Mod 4 = 0 Then r = Me.fgFPD.Rows.Add()
                If r Is Nothing Then r = Me.fgFPD.Rows.Add()
                colIdx = i Mod 4 + 1
                r(colIdx) = val
                If fgFPD.Cols(colIdx).Caption = "Current Value" Then
                    If val = 0 Then FPDReady = False
                End If
                i += 1
            Next
            FormatGrid(fgFPD, 9, 9)
            fgFPD.Row = -1
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.LoadFgFPPValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadFgFPPValue()
        Try
            InitFgFPP()
            Dim r As Row = Nothing
            Dim i As Integer
            Dim colIdx As Integer
            Dim fppStr As String = IVIV.FrontPanelPowerRatio
            For Each val As String In fppStr.Split(",")
                If i Mod 3 = 0 Then r = Me.fgFPP.Rows.Add()
                If r Is Nothing Then r = Me.fgFPD.Rows.Add()
                colIdx = i Mod 3 + 1
                r(colIdx) = val
                If fgFPP.Cols(colIdx).Caption = "Current Value" Then
                    If val = 0 Then FPPReady = False
                End If
                i += 1
            Next
            FormatGrid(fgFPP, 9, 9)
            fgFPP.Row = -1
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.LoadFgFPPValue()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnFPDSaveNewValues_Click(sender As Object, e As EventArgs) Handles btnFPDSaveNewValues.Click
        Try
            If MessageBox.Show("Are you sure you want to write the new distance values to the PCT?", "Front Panel Distance Adjustment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                Me.lblFPDSaveNewValue.BackColor = Color.Red
                Return
            End If
            Dim startTime As DateTime = Now
            Me.pgBar.Minimum = 0
            Me.pgBar.Maximum = 10
            Me.pgBar.Value = 0
            Me.tsslStatus.Text = "Save measurements for this step in process......"
            Me.lblFPDSaveNewValue.BackColor = Color.Yellow
            Me.gbFPD.Enabled = False
            InitFgFPD()
            My.Application.DoEvents()
            IVIV.FactoryCalMeasCommit(1)
            Dim respStr As String
            Do
                respStr = IVIV.WaitOPCResponse(1)
                ShowFactoryCalElapsedTime(startTime)
                If Me.pgBar.Value < Me.pgBar.Maximum Then Me.pgBar.Value += 1
                My.Application.DoEvents()
            Loop Until (respStr.StartsWith("1"))
            FPDReady = True
            LoadFgFPDValue()
            lblFPDState.BackColor = IIf(FPDReady, Color.LimeGreen, SystemColors.ControlDark)

            Dim sysIntBll As New BLL.system_integrationManager
            gSysIntegration = sysIntBll.SelectBySN(pInstCtrl.Serial_Number)

            If gSysIntegration Is Nothing Then
                gSysIntegration = New Model.system_integration
                With gSysIntegration
                    .Instr_serial_num = pInstCtrl.Serial_Number
                    .Fpd_result = FPDReady
                    .Fpd_finish_datetime = Now
                    .Fpp_result = False
                    .Fpp_finish_datetime = "1753-01-01 00:00:00"
                    .Spl_result = False
                    .Spl_finish_datetime = "1753-01-01 00:00:00"
                End With
                sysIntBll.Add(gSysIntegration)
            Else
                With gSysIntegration
                    .Fpd_result = FPDReady
                    .Fpd_finish_datetime = Now
                End With
                sysIntBll.Update(gSysIntegration)
            End If

            Me.lblFPDSaveNewValue.BackColor = Color.LimeGreen
            Me.tsslStatus.Text = "Save measurements for this step complete"

            Me.pgBar.Value = Me.pgBar.Maximum
        Catch ex As Exception
            Me.lblFPDSaveNewValue.BackColor = Color.Red
            MsgBox("FormSysIntegration.btnFPDSaveNewValues_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.gbFPD.Enabled = True
        End Try
    End Sub

    Private Sub btnFPPStartAdjustment_Click(sender As Object, e As EventArgs) Handles btnFPPStartAdjustment.Click
        Try
            If FormFPPConnPrompt.ShowDialog = DialogResult.OK Then
                ClearFgFPPNewValue()
                Me.pgBar.Minimum = 0
                Me.pgBar.Maximum = 50
                Me.pgBar.Value = 0
                Dim startTime As DateTime = Now
                Me.tsslStatus.Text = "Front pannel power ratio adjustment in process......"
                Me.lblFPPStatus.BackColor = Color.Yellow
                My.Application.DoEvents()
                Me.gbFPP.Enabled = False
                IVIV.FactoryCalMeasStart(2)
                Dim respStr As String
                Do
                    respStr = IVIV.WaitOPCResponse(1)
                    ShowFactoryCalElapsedTime(startTime)
                    If Me.pgBar.Value < Me.pgBar.Maximum Then Me.pgBar.Value += 1
                    My.Application.DoEvents()
                Loop Until (respStr.StartsWith("1"))
                LoadFgFPPValue()
                FPPReady = False
                Me.lblFPPStatus.BackColor = Color.LimeGreen
                Me.tsslStatus.Text = "Front pannel power ratio adjustment complete"
                Me.btnFPPSaveNewValue.Enabled = Enabled
                Me.pgBar.Value = Me.pgBar.Maximum
            End If
        Catch ex As Exception
            Me.lblFPPStatus.BackColor = Color.Red
            MsgBox("FormSysIntegration.btnFPPStartAdjustment_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.gbFPP.Enabled = True
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedTab Is TabPage3 Then
                btnFPPStartAdjustment.Enabled = FPDReady
            ElseIf TabControl1.SelectedTab Is TabPage4 Then
                btnSPLStartAdjustment.Enabled = FPDReady And FPPReady
            End If
        Catch ex As Exception
            MsgBox("FormSysIntegration.TabControl1_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnFPPSaveNewValue_Click(sender As Object, e As EventArgs) Handles btnFPPSaveNewValue.Click
        Try
            If MessageBox.Show("Are you sure you want to write the new power values to the PCT?", "Front Panel Power Ratio Adjustment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                Me.lblFPPSaveNewValue.BackColor = Color.Red
                Return
            End If
            Dim startTime As DateTime = Now
            Me.pgBar.Minimum = 0
            Me.pgBar.Maximum = 10
            Me.pgBar.Value = 0
            Me.tsslStatus.Text = "Save measurements for this step in process......"
            Me.lblFPPSaveNewValue.BackColor = Color.Yellow
            Me.gbFPP.Enabled = False
            InitFgFPP()
            My.Application.DoEvents()
            IVIV.FactoryCalMeasCommit(2)
            Dim respStr As String
            Do
                respStr = IVIV.WaitOPCResponse(1)
                ShowFactoryCalElapsedTime(startTime)
                If Me.pgBar.Value < Me.pgBar.Maximum Then Me.pgBar.Value += 1
                My.Application.DoEvents()
            Loop Until (respStr.StartsWith("1"))

            FPPReady = True
            LoadFgFPPValue()
            lblFPPState.BackColor = IIf(FPPReady, Color.LimeGreen, SystemColors.ControlDark)

            Dim sysIntBll As New BLL.system_integrationManager
            gSysIntegration = sysIntBll.SelectBySN(pInstCtrl.Serial_Number)

            If gSysIntegration Is Nothing Then
                gSysIntegration = New Model.system_integration
                With gSysIntegration
                    .Instr_serial_num = pInstCtrl.Serial_Number
                    .Fpp_result = FPPReady
                    .Fpp_finish_datetime = Now
                    .Fpd_result = False
                    .Fpd_finish_datetime = "1753-01-01 00:00:00"
                    .Spl_result = False
                    .Spl_finish_datetime = "1753-01-01 00:00:00"
                End With
                sysIntBll.Add(gSysIntegration)
            Else
                With gSysIntegration
                    .Fpp_result = FPPReady
                    .Fpp_finish_datetime = Now
                End With
                sysIntBll.Update(gSysIntegration)
            End If

            Me.lblFPPSaveNewValue.BackColor = Color.LimeGreen
            Me.tsslStatus.Text = "Save measurements for this step complete"
            Me.pgBar.Value = Me.pgBar.Maximum
        Catch ex As Exception
            Me.lblFPPSaveNewValue.BackColor = Color.Red
            MsgBox("FormSysIntegration.btnFPPSaveNewValue_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.gbFPP.Enabled = True
        End Try
    End Sub

    Private Sub btnSPLStartAdjustment_Click(sender As Object, e As EventArgs) Handles btnSPLStartAdjustment.Click
        Try
            If FormSPLConnPrompt.ShowDialog = DialogResult.OK Then
                ClearFgSPLNewValue()
                Dim startTime As DateTime = Now
                Me.pgBar.Minimum = 0
                Me.pgBar.Maximum = NumChannel * 15
                Me.pgBar.Value = 0
                Me.tsslStatus.Text = "Switch path length adjustment in process......"
                Me.lblSPLStatus.BackColor = Color.Yellow
                My.Application.DoEvents()
                Me.gbSPL.Enabled = False
                Dim respStr As String
                For i As Integer = 1 To NumChannel
                    IVIV.Channel(1) = i
                    IVIV.FactoryCalMeasStart(6)
                    Do
                        respStr = IVIV.WaitOPCResponse(1)
                        ShowFactoryCalElapsedTime(startTime)
                        If Me.pgBar.Value < Me.pgBar.Maximum Then Me.pgBar.Value += 1
                        My.Application.DoEvents()
                    Loop Until (respStr.StartsWith("1"))
                Next

                LoadFgSPLValue()
                SPLReady = False

                Me.lblSPLStatus.BackColor = Color.LimeGreen
                Me.tsslStatus.Text = "Switch path length adjustment complete"
                Me.btnSPLSaveNewValue.Enabled = True

                Me.pgBar.Value = Me.pgBar.Maximum
            End If
        Catch ex As Exception
            Me.lblSPLStatus.BackColor = Color.Red
            MsgBox("FormSysIntegration.btnSPLStartAdjustment_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.gbSPL.Enabled = True
        End Try
    End Sub

    Private Sub btnSPLSaveNewValue_Click(sender As Object, e As EventArgs) Handles btnSPLSaveNewValue.Click
        Try
            If MessageBox.Show("Are you sure you want to write the new distance values to the PCT?", "Front Panel Distance Adjustment", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.No Then
                Me.lblFPPSaveNewValue.BackColor = Color.Red
                Return
            End If
            Dim startTime As DateTime = Now
            Me.pgBar.Minimum = 0
            Me.pgBar.Maximum = 10
            Me.pgBar.Value = 0
            Me.tsslStatus.Text = "Save measurements for this step in process......"
            Me.lblSPLSaveNewValue.BackColor = Color.Yellow
            Me.gbSPL.Enabled = False
            InitFgSPL()
            IVIV.FactoryCalMeasCommit(6)
            Dim respStr As String
            Do
                respStr = IVIV.WaitOPCResponse(1)
                ShowFactoryCalElapsedTime(startTime)
                If Me.pgBar.Value < Me.pgBar.Maximum Then Me.pgBar.Value += 1
                My.Application.DoEvents()
            Loop Until (respStr.StartsWith("1"))

            SPLReady = True
            LoadFgSPLValue()
            lblSPLState.BackColor = IIf(SPLReady, Color.LimeGreen, SystemColors.ControlDark)

            Dim sysIntBll As New BLL.system_integrationManager
            gSysIntegration = sysIntBll.SelectBySN(pInstCtrl.Serial_Number)

            If gSysIntegration Is Nothing Then
                gSysIntegration = New Model.system_integration
                With gSysIntegration
                    .Instr_serial_num = pInstCtrl.Serial_Number
                    .Spl_result = SPLReady
                    .Spl_finish_datetime = Now
                    .Fpd_result = False
                    .Fpd_finish_datetime = "1753-01-01 00:00:00"
                    .Fpp_result = False
                    .Fpp_finish_datetime = "1753-01-01 00:00:00"
                    .Spl_channel_num = Me.nudChannelNum.Value
                End With
                sysIntBll.Add(gSysIntegration)
            Else
                With gSysIntegration
                    .Spl_result = SPLReady
                    .Spl_finish_datetime = Now
                    .Spl_channel_num = Me.nudChannelNum.Value
                End With
                sysIntBll.Update(gSysIntegration)
            End If

            Me.lblSPLSaveNewValue.BackColor = Color.LimeGreen
            Me.tsslStatus.Text = "Save measurements for this step complete"

            Me.pgBar.Value = Me.pgBar.Maximum
        Catch ex As Exception
            Me.lblSPLSaveNewValue.BackColor = Color.Red
            MsgBox("FormSysIntegration.btnSPLSaveNewValue_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        Finally
            Me.gbSPL.Enabled = True
        End Try
    End Sub

    Private Sub nudChannelNum_ValueChanged(sender As Object, e As EventArgs) Handles nudChannelNum.ValueChanged
        NumChannel = Me.nudChannelNum.Value
    End Sub
    Private Sub ShowFactoryCalElapsedTime(startTime As DateTime)
        Try
            Dim tSpan As TimeSpan = DateTime.Now - startTime
            Me.tsslTimeElapsed.Text = String.Format("{0:00}:{1:00}:{2:00} ", tSpan.Hours, tSpan.Minutes, tSpan.Seconds)
            Application.DoEvents()
        Catch ex As Exception
            Throw New Exception("FormSysIntegration.ShowFactoryCalElapsedTime()::" & ex.Message)
        End Try
    End Sub
End Class
Public Class CSystemIntegration
    Public FrontPanelDistance As Boolean
    Public FPDFinishDateTime As DateTime
    Public FrontPannelPowerRatio As Boolean
    Public FPPFinishDateTime As DateTime
    Public SwitchPathLength As Boolean
    Public SPLFinishDateTime As DateTime
    Public SPLChannelNum As Integer
    Public InstrumentSN As String
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
    Public Shared Function CreateInstance(ByVal filename As String) As CSystemIntegration
        Try
            If My.Computer.FileSystem.FileExists(filename) = False Then
                Return Nothing
            Else
                Dim SystemIntegration As CSystemIntegration = Nothing
                Using StrmRd As New System.IO.StreamReader(filename)
                    Dim XSerz As New XmlSerializer(GetType(CSystemIntegration))
                    SystemIntegration = CType(XSerz.Deserialize(StrmRd), CSystemIntegration)
                    StrmRd.Close()
                End Using
                Return SystemIntegration
            End If
        Catch ex As Exception
            Throw New Exception(String.Format("Read file '{0}' fail!", filename) & vbNewLine & ex.Message)
        End Try
    End Function

End Class