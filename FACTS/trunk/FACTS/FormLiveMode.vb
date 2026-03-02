Imports C1.Win.C1FlexGrid
Imports FACTS.Model

Public Class FormLiveMode
    Private IVIV As IVIAVI = Nothing
    Private ChannelReady As Boolean
    Private WaveLengthReady As Boolean
    Private Delegate Sub DelLiveDisplay()
    Private StopLiveDisplay As Boolean
    Private dgRun As New DelLiveDisplay(AddressOf LiveDisplay)
    Private res As IAsyncResult
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub FormLiveMode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitializeInstrument(gBenchSetting)
            IVIV = CType(pInstCtrl, IVIAVI)
            If IVIV Is Nothing Then Return

            ' Set channel number
            Me.nudChannels.Minimum = 1
            Me.nudChannels.Maximum = IVIV.ChannelAvailable
            Me.nudChannels.Value = 1

            ' Add wave length control
            Dim ckWaveLength As RadioButton
            Dim sourceWaveLengthList As List(Of String) = IVIV.WavelengthAvailable.Split(",").ToList
            For Each waveLength As String In sourceWaveLengthList
                ckWaveLength = New RadioButton
                With ckWaveLength
                    .Checked = False
                    .Text = waveLength.Trim & " nm"
                    .Tag = waveLength
                    AddHandler .CheckedChanged, AddressOf WavelengthSettingChange
                End With
                Me.flpWavelength.Controls.Add(ckWaveLength)
            Next

            ChannelReady = False
            WaveLengthReady = False
        Catch ex As Exception
            MsgBox("FormLiveMode.FormLiveMode_Load()::" & ex.Message, MsgBoxStyle.Exclamation, "Form Load Error")
        End Try
    End Sub
    Private Sub WavelengthSettingChange()
        Try
            Me.btnExecute.Enabled = False
            Me.lblWaveLengthStatus.BackColor = SystemColors.ControlDark
        Catch ex As Exception
            Throw New Exception("FormLiveMode.WavelengthSettingChange")
        End Try
    End Sub
    Private Sub btnSetChannel_Click(sender As Object, e As EventArgs) Handles btnSetChannel.Click
        Try
            IVIV.Channel(1) = Me.nudChannels.Value
            Me.lblChStatus.BackColor = Color.LimeGreen
            ChannelReady = True
            If ChannelReady And WaveLengthReady Then Me.btnExecute.Enabled = True Else Me.btnExecute.Enabled = False
        Catch ex As Exception
            MsgBox("FormLiveMode.btnSetChannel_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Set Channel Error")
            Me.lblChStatus.BackColor = SystemColors.ControlDark
            ChannelReady = False
        End Try
    End Sub

    Private Sub btnSetWaveLength_Click(sender As Object, e As EventArgs) Handles btnSetWaveLength.Click
        Try
            Dim waveLength As Integer
            Dim ckCtr As RadioButton
            For Each ctr As Control In Me.flpWavelength.Controls
                If TypeOf (ctr) Is RadioButton Then
                    ckCtr = CType(ctr, RadioButton)
                    If ckCtr.Checked Then
                        waveLength = ckCtr.Tag
                        IVIV.Wavelength = waveLength
                        Me.lblWaveLengthStatus.BackColor = Color.LimeGreen
                        WaveLengthReady = True
                        Exit For
                    End If
                End If
            Next

            If ChannelReady And WaveLengthReady Then Me.btnExecute.Enabled = True Else Me.btnExecute.Enabled = False
        Catch ex As Exception
            MsgBox("FormLiveMode.btnSetWaveLength_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Set Wavelength Error")
            Me.lblWaveLengthStatus.BackColor = SystemColors.ControlDark
            WaveLengthReady = False
        End Try
    End Sub

    Private Sub nudChannels_ValueChanged(sender As Object, e As EventArgs) Handles nudChannels.ValueChanged
        Try
            Me.btnExecute.Enabled = False
            Me.lblChStatus.BackColor = SystemColors.ControlDark
        Catch ex As Exception
            MsgBox("FormLiveMode.btnSetWaveLength_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Channel Value Change Error")
        End Try
    End Sub
    Private Sub LiveDisplay()
        Try
            Dim il, orl, power As String
            Dim valStr As String
            Dim val() As String
            With IVIV
                '.MeasStart()
                .LiveMode = 1
                Do While Not StopLiveDisplay
                    valStr = .LiveModeValue
                    val = valStr.Split(vbLf)
                    il = val(0)
                    orl = val(1)
                    power = val(2)
                    DisplayLiveValue(il, orl, power)
                    Application.DoEvents()
                Loop
            End With
        Catch ex As Exception
            Throw New Exception("FormLiveMode.LiveDisplay()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Public Sub DisplayLiveValue(il As String, orl As String, power As String)
        Try
            If Me.InvokeRequired Then
                Me.BeginInvoke(New Action(Of String, String, String)(AddressOf ShowLiveValue), il, orl, power)
            Else
                ShowLiveValue(il, orl, power)
            End If
        Catch ex As Exception
            Throw New Exception("FormLiveMode.DisplayLiveValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub ShowLiveValue(il As String, orl As String, power As String)
        Try
            Me.lblIL.Text = IIf(il.Length = 0, "------", il)
            Me.lblRL.Text = IIf(orl.Length = 0, "------", orl)
            Me.lblPower.Text = IIf(power.Length = 0, "------", power)
        Catch ex As Exception
            Throw New Exception("FormLiveMode.ShowLiveValue()::" & ex.Message)
        End Try
    End Sub
    Private Sub SetupMeasurement()
        Try
            With IVIV
                ' DUT test
                .MeasFunction = 1
                ' J1 out
                .LaunchPort = 1
                ' Singe/Dual MTJ
                If GUI.SelectedPhaseName = "Connector" Then
                    .MTJConnection = 1
                Else
                    .MTJConnection = 2
                End If
            End With
        Catch ex As Exception
            Throw New Exception("SetupMeasurement()::" & ex.Message)
        End Try
    End Sub
    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        Try
            If Me.btnExecute.Text = "Start" Then
                SetupMeasurement()
                StopLiveDisplay = False
                res = dgRun.BeginInvoke(Nothing, Nothing)
                btnExecute.Text = "Stop"
            Else
                IVIV.LiveMode = 0
                StopLiveDisplay = True
                DisplayLiveValue("", "", "")
                dgRun.EndInvoke(res)
                btnExecute.Text = "Start"
                Application.DoEvents()
            End If
        Catch ex As Exception
            MsgBox("FormLiveMode.btnStart_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Live Display Error")
        End Try
    End Sub
End Class