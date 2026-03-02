Imports C1.Win.C1FlexGrid

Public Class FormSetup
    Private iviv As IVIAVI
    Private cmr8100 As IVIAVI
    Private InitInstrumentReady As Boolean
    Private SystemIntegrationReady As Boolean
    Private Sub FormSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If gBenchSetting Is Nothing Then Return

            InitInstrumentReady = False
            SystemIntegrationReady = False

            GUI.ProgressMinmum = 0
            GUI.ProgressMaximum = 14
            GUI.ProgressBarValue = 0

            GUI.ProgressBarValue += 1

            InitializeCMR(gBenchSetting)
            GUI.ProgressBarValue += 1

            cmr8100 = CType(pInstCtrl, IVIAVI)

            If cmr8100 Is Nothing Then Return

            If cmr8100.PCTState = 0 Then cmr8100.LaunchPCT()
            For i As Integer = 1 To 10
                cmr8100.WaitOPC(1)
                GUI.ProgressBarValue += 1
            Next

            If cmr8100.PCTState = 1 Then
                If InitializeInstrument(gBenchSetting) Then
                    iviv = CType(pInstCtrl, IVIAVI)
                    If iviv Is Nothing Then Return
                    InitInstrumentReady = True
                    Me.lblHardwareInit.BackColor = Color.LimeGreen
                End If
            End If
            GUI.ProgressBarValue += 1

            SystemIntegrationReady = GetSysIntegrationStatus()
            Me.lblSystemIntegeration.BackColor = IIf(SystemIntegrationReady, Color.LimeGreen, SystemColors.ControlDark)

            Me.rbRange1.Checked = True
            Me.lblDUTMeasRange.BackColor = Color.LimeGreen

            Me.btnDone.Enabled = True

            GUI.ProgressBarValue += 1

        Catch ex As Exception
            InitInstrumentReady = False
            SystemIntegrationReady = False
            Me.btnDone.Enabled = False
            MsgBox("FormSetup.FormSetup_Load()::" & ex.Message, MsgBoxStyle.Exclamation, "Setup Form Load Error")
        Finally
            If InitInstrumentReady And SystemIntegrationReady Then
                Me.lblSetupComplete.BackColor = Color.LimeGreen
                Me.btnDone.Enabled = True
                Me.btnDone.Select()
            Else
                Me.lblSetupComplete.BackColor = Color.Red
                Me.btnDone.Enabled = False
            End If
#If Simulate Then
            Me.btnDone.Enabled = True
#End If
        End Try
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        GUI.txtSN1.Enabled = True
        'GUI.txtSN2.Enabled = True
        'GUI.TxtPN.Enabled = True
        GUI.txtSN1.Select()
#If Simulate Then
        GUI.InstrumentReady = "Simulate"
#Else
        GUI.InstrumentReady = "Ready"
#End If

        Close()
    End Sub

    Private Sub btnLiveMode_Click(sender As Object, e As EventArgs) Handles btnLiveMode.Click
        Try
            Dim frmLiveMode As New FormLiveMode
            frmLiveMode.ShowDialog()
        Catch ex As Exception
            MsgBox("FormSetup.btnLiveMode_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Open Live Mode Form Error")
        End Try
    End Sub

    Private Sub btnResetMAP200_Click(sender As Object, e As EventArgs) Handles btnRetMAP.Click
        Try
            Me.tsslStatus.Text = "Reset MAP in process......"
            My.Application.DoEvents()
            Me.pgBar.Minimum = 0
            Me.pgBar.Value = 0
            If cmr8100.PCTState = 1 Then
                Me.pgBar.Maximum = 20
                cmr8100.ExitPCT()
                For i As Integer = 1 To 10
                    cmr8100.WaitOPC(1)
                    pgBar.Value += 1
                Next
                cmr8100.LaunchPCT()
                For i As Integer = 1 To 10
                    cmr8100.WaitOPC(1)
                    pgBar.Value += 1
                Next
            Else
                Me.pgBar.Maximum = 10
                cmr8100.LaunchPCT()
                For i As Integer = 1 To 10
                    cmr8100.WaitOPC(1)
                    pgBar.Value += 1
                Next
            End If
            Me.tsslStatus.Text = "Reset MAP Complete"
        Catch ex As Exception
            MsgBox("FormSetup.btnResetMAP200_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Reset MAP Error")
        End Try
    End Sub

    Private Sub btnSysIntegration_Click(sender As Object, e As EventArgs) Handles btnSysIntegration.Click
        Try
            Dim frmSysIntegration As New FormSysIntegration(iviv)
            If frmSysIntegration.ShowDialog() = DialogResult.OK Then
                Me.lblSystemIntegeration.BackColor = Color.LimeGreen
                SystemIntegrationReady = True
                Me.lblSetupComplete.BackColor = Color.LimeGreen
                Me.btnDone.Enabled = True
                Me.btnDone.Select()
            Else
                Me.lblSystemIntegeration.BackColor = Color.Red
                SystemIntegrationReady = False
                Me.lblSetupComplete.BackColor = Color.Red
                Me.btnDone.Enabled = False
            End If
        Catch ex As Exception
            Me.lblSystemIntegeration.BackColor = Color.Red
            MsgBox("FormSetup.btnSysIntegration_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Open System Integration Interface Error")
        End Try
    End Sub
    Private Sub InitializeHardware()
        Try
            If gBenchSetting Is Nothing Then Return

            InitInstrumentReady = False

            GUI.ProgressMinmum = 0
            GUI.ProgressMaximum = 4
            GUI.ProgressBarValue = 1

            InitializeCMR(gBenchSetting)
            GUI.ProgressBarValue += 1

            iviv = CType(pInstCtrl, IVIAVI)

            If iviv Is Nothing Then Return

            If iviv.PCTState = 0 Then iviv.LaunchPCT()
            Threading.Thread.Sleep(5000)
            GUI.ProgressBarValue += 1

            If iviv.PCTState = 1 Then
                If InitializeInstrument(gBenchSetting) Then
                    iviv = CType(pInstCtrl, IVIAVI)
                    If iviv Is Nothing Then Return
                    InitInstrumentReady = True
                    Me.lblHardwareInit.BackColor = Color.LimeGreen
                End If
            End If
            GUI.ProgressBarValue += 1
        Catch ex As Exception
            Throw New Exception("FormSetup.InitializeHardware()::" & ex.Message)
        End Try
    End Sub
    Private Sub btnInitializeHardware_Click(sender As Object, e As EventArgs) Handles btnInitializeHardware.Click
        Try
            InitializeHardware()
        Catch ex As Exception
            MsgBox("FormSetup.btnInitializeHardware_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Initialize Hardware Error")
        End Try
    End Sub

    Private Function GetSysIntegrationStatus() As Boolean
        Try
            gSysIntegration = (New BLL.system_integrationManager).SelectBySN(pInstCtrl.Serial_Number)

            If gSysIntegration Is Nothing Then Return False

            Dim FPDReady As Boolean = True
            Dim FPPReady As Boolean = True
            Dim SPLReady As Boolean = True

            If Now.Subtract(gSysIntegration.Fpd_finish_datetime).Days > gSysIntegrationDays Or gSysIntegration.Fpd_result = False Then FPDReady = False
            If Now.Subtract(gSysIntegration.Fpp_finish_datetime).Days > gSysIntegrationDays Or gSysIntegration.Fpp_result = False Then FPPReady = False
            If Now.Subtract(gSysIntegration.Spl_finish_datetime).Days > gSysIntegrationDays Or gSysIntegration.Fpp_result = False Then SPLReady = False

            'Dim channelNum As Integer = gSysIntegration.Spl_channel_num
            'ReadSystemIntegrationValue(FPDReady, FPPReady, SPLReady, channelNum)

            Return FPDReady And FPPReady And SPLReady

        Catch ex As Exception
            Throw New Exception("FormSetup.GetSysIntegrationStatus()::" & ex.Message)
        End Try
    End Function
    Private Sub ReadSystemIntegrationValue(ByRef FPDReady As Boolean, ByRef FPPReady As Boolean, ByRef SPLReady As Boolean, ByVal channelNum As Integer)
        Try
            Dim readStr As String
            ' FPD current value
            readStr = iviv.FrontPanelDistance
            Dim valStr As String() = readStr.Split(",")
            If valStr(2) = 0 Then FPDReady = False
            ' FPP current value
            readStr = iviv.FrontPanelPowerRatio
            valStr = readStr.Split(",")
            If valStr(1) = 0 Then FPPReady = False
            ' SPL current value
            For i As Integer = 1 To channelNum
                readStr = iviv.SwitchPathLength(i)
                valStr = readStr.Split(",")
                If valStr(1) = 0 Then FPPReady = False : Exit For
            Next
        Catch ex As Exception
            Throw New Exception("FormSetup.GetSysIntegrationStatus()::" & ex.Message)
        End Try
    End Sub

    Private Sub rbRange_CheckedChanged(sender As Object, e As EventArgs) Handles rbRange1.CheckedChanged, rbRange2.CheckedChanged, rbRange3.CheckedChanged, rbRange4.CheckedChanged, rbRange5.CheckedChanged, rbRange6.CheckedChanged
        Try
            If iviv Is Nothing Then Return
            If rbRange1.Checked Then
                iviv.MeasRange = 0
            ElseIf rbRange2.Checked Then
                iviv.MeasRange = 1
            ElseIf rbRange3.Checked Then
                iviv.MeasRange = 2
            ElseIf rbRange4.Checked Then
                iviv.MeasRange = 3
            ElseIf rbRange5.Checked Then
                iviv.MeasRange = 4
            ElseIf rbRange6.Checked Then
                iviv.MeasRange = 5
            End If
        Catch ex As Exception
            MsgBox("FormSetup.rbRange_CheckedChanged()::" & ex.Message, MsgBoxStyle.Exclamation, "Select Measurement Range Error")
        End Try
    End Sub
End Class