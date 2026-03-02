Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Claims
Imports C1.Win.C1FlexGrid
Imports FACTS.CalibrateItem

Public Class FormCalibrate
    Private calItems As List(Of CalibrateItem)
    Private productMain As FACTS.Model.product_main
    Private tPhaseRlIl As TestPhaseRlIl
    Private VIV As IVIAVI
    Private Delegate Sub DelegateRefTest(ByRef CalItem As CalibrateItem, ByVal VIV As IVIAVI)
    Private Delegate Sub DelLiveDisplay(ByRef CalItem As CalibrateItem, ByVal VIV As IVIAVI)
    Private StopLiveDisplay As Boolean
    Private calType As numCalibrateType '0=System, 1=Connector
    Private abortFlag As Boolean = False
    Private FrmRecJumperCalPrompt As FormRecJumperCalPrompt = Nothing
    Private FrmMTJJumperCalPrompt As FormCalConnPrompt = Nothing
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    Public Sub New(calibrateItems As List(Of CalibrateItem), pmM As FACTS.Model.product_main, testPhase As TestPhaseRlIl, iVIV As IVIAVI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.calItems = calibrateItems
        productMain = pmM
        tPhaseRlIl = testPhase
        VIV = iVIV
    End Sub
    Private Sub FormCalibrate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.btnStartCal.Select()

            LoadCalItems(calItems)

        Catch ex As Exception
            MsgBox("FormCalibrate_Load()::" & vbCrLf & " at " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Load Calibrate Form Error")
        End Try
    End Sub
    Private Sub LoadCalItems(calibrateItems As List(Of CalibrateItem))
        Try
            InitGridCal()
            Dim calIOF As New CalibrateIOFactory
            Dim calIO As CalibrateIO
            calIO = calIOF.CreateInstance
            Dim calItems As List(Of CalibrateItem) = calIO.TotalItems

            Dim calItem As CalibrateItem

            If calibrateItems Is Nothing Then Return

            Dim row As Row
            Dim rowIdx As Integer

            calType = calibrateItems.First.CalType

            For Each item As CalibrateItem In calibrateItems

                calItem = calIO.SelectItem(item)

                If calItem Is Nothing Then
                    calItem = item
                End If

                row = fgCal.Rows.Add()
                rowIdx = row.Index

                row(2) = item.CalType
                row(3) = item.Channel
                row(4) = item.WaveLength
                row(5) = item.MTJConnection
                row(6) = item.JumperType
                row(7) = item.JumperCalType
                row(8) = calItem.Power
                row(9) = calItem.Offset
                row(10) = calItem.Length
                row(11) = calItem.CalTime
                row(12) = item.Message

                item.CalTime = calItem.CalTime

                If Now.Subtract(calItem.CalTime).TotalHours > gCalInterval Or calItem.CalType <> [Enum].Parse(GetType(numCalibrateType), GUI.SelectedPhaseName) Then
                    fgCal.Rows(rowIdx).Style = fgCal.Styles("IndianRed")
                    row(1) = True
                    item.CalValid = False
                Else
                    fgCal.Rows(rowIdx).Style = fgCal.Styles("GreenYellow")
                    row(1) = False
                    item.CalValid = True
                End If

                'If calItem.JumperCalType <> gBenchSetting.RecJumperCalType Then
                '    fgCal.Rows(rowIdx).Style = fgCal.Styles("IndianRed")
                '    row(1) = True
                '    item.CalValid = False
                'End If

                row.UserData = item
            Next

            FormatGrid(fgCal, 9, 9)

        Catch ex As Exception
            Throw New Exception("LoadCalItems() - " & ex.Message)
        End Try
    End Sub
    Private Sub InitGridCal()
        Try
            'set up grid
            fgCal.Clear()
            fgCal.Cols.Fixed = 1
            fgCal.Cols.Count = 13
            fgCal.Rows.Fixed = 1
            fgCal.Rows.Count = 1
            fgCal.Cols(1).Caption = "Select"
            fgCal.Cols(2).Caption = "Cal Type"
            fgCal.Cols(3).Caption = "Chan"
            fgCal.Cols(4).Caption = "WL"
            fgCal.Cols(5).Caption = "Jumper Conn Mode"
            fgCal.Cols(6).Caption = "Jumper"
            fgCal.Cols(7).Caption = "Jumper Cal Type"
            fgCal.Cols(8).Caption = "Power"
            fgCal.Cols(9).Caption = "Offset"
            fgCal.Cols(10).Caption = "LEN(m)"
            fgCal.Cols(11).Caption = "Cal Time"
            fgCal.Cols(12).Caption = "Message"

            Dim cs As CellStyle = fgCal.Styles.Add("Select")
            cs.DataType = Type.GetType("System.Boolean")
            fgCal.Cols(1).Style = cs

            For i As Integer = 1 To fgCal.Cols.Fixed
                fgCal.Cols(i).AllowEditing = True
            Next

            cs = fgCal.Styles.Add("IndianRed")
            cs.BackColor = Color.IndianRed

            cs = fgCal.Styles.Add("GreenYellow")
            cs.BackColor = Color.GreenYellow

            cs = fgCal.Styles.Add("Pink")
            cs.BackColor = Color.Pink

            fgCal.Cols(11).Format = "yyyy-MM-dd HH:mm:ss"

            FormatGrid(fgCal, 9, 9)

        Catch ex As Exception
            Throw New Exception("InitGridTestItems()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub

    Private Sub fgCal_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgCal.OwnerDrawCell
        Try
            If e.Row >= fgCal.Rows.Fixed And e.Col = fgCal.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgCal.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("fgTestItems_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub EnableButton(enabled As Boolean)
        btnStartCal.Enabled = enabled
        btnExit.Enabled = enabled
    End Sub

    Private Sub btnStartCal_Click(sender As Object, e As EventArgs) Handles btnStartCal.Click
        Try
            EnableButton(False)

            abortFlag = False

            Me.tsslpbCal.Minimum = 0
            Me.tsslpbCal.Maximum = 50

#If Simulate Then
#Else
            SetupMeasurement(VIV)
#End If

            Dim idx As Integer = 0
            Dim msg As String = ""
            Dim showMsg As Boolean = True
            For idx = 1 To fgCal.Rows.Count - 1
                If CBool(Me.fgCal(idx, 1)) = True Then
                    If ExecuteStepCalibrate(idx, msg, showMsg) = False Then Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox("btnStartCal_Click()::" & ex.Message, MsgBoxStyle.Exclamation, "Calibrate Erorr")
        Finally
            EnableButton(True)
            Me.tsslStatus.Text = String.Format("Calibration Done")
        End Try
    End Sub

    Private Function ExecuteStepCalibrate(idx As Integer, ByRef msg As String, ByRef ShowMsg As Boolean) As Boolean
        Try
            If idx < 0 Then Return False

            Dim row As Row
            row = fgCal.Rows(idx)
            Dim calItem As CalibrateItem = CType(row.UserData, CalibrateItem)
            Dim calFail As Boolean = True

            Do While calFail

                If abortFlag = True Then Throw New Exception("Calibrate aborted")

                Me.tsslpbCal.Value = 0
                Me.tsslpbCal.Value += 1

                fgCal.Row = idx
                row.Style = fgCal.Styles("Pink")
                Me.tsslStatus.Text = String.Format("Calibrating Channel {0} at Wavelength {1}", calItem.Channel, calItem.WaveLength)
                Me.tsslpbCal.Value += 1
                Application.DoEvents()

#If Simulate Then
#Else
                With VIV
                    ' Singe/Dual MTJ
                    If calItem.MTJConnection = numJumperConnectionType.SingleMTJ Then
                        .MTJConnection = 1
                        .Channel(1) = calItem.Channel
                    Else
                        .MTJConnection = 2
                        .Channel(1) = calItem.Channel
                        .Channel(3) = calItem.Channel
                    End If
                    .Wavelength = calItem.WaveLength
                    If calItem.JumperType = numJumperType.MTJ Then
                        .JumperLengthOverrideOption(1) = 1
                        .JumperLengthOverrideOption(2) = 1
                    Else
                        If gBenchSetting.RecJumperCalType = numJumperCalType.Real Then
                            .JumperLengthOverrideOption(3) = 1
                            .JumperILOverrideOption(3) = 1
                        Else
                            .JumperLengthOverrideOption(3) = 0
                            .JumperLengthOverrideValue(3) = gBenchSetting.RecJumperLength
                            .JumperILOverrideOption(3) = 0
                            .JumperILOverrideValue(3) = 0.05
                        End If
                        ShowMsg = True
                    End If
                End With
#End If
                StopLiveDisplay = False
                Dim dgLiveDispaly As New DelLiveDisplay(AddressOf LiveDisplay)
                Dim iRes As IAsyncResult = dgLiveDispaly.BeginInvoke(calItem, VIV, Nothing, Nothing)

                Select Case gConnectorFamily
                    Case numConnFamily.NON_MPO
                        If productMain.Fiber_per_subunit <= 2 Then
                            If ShowMsgWhenChannelChanged(msg, calFail, calItem) = False Then Return False
                        Else
                            If GUI.SelectedPhaseName = "System" Or gBenchSetting.TestType = numTestType.Pigtail Then
                                If ShowMsgWhenChannelChanged(msg, calFail, calItem) = False Then Return False
                            Else
                                If ShowMsgOnce(ShowMsg, calFail, calItem) = False Then Return False
                            End If
                        End If
                    Case numConnFamily.DUAL_MPO, numConnFamily.SINGLE_MPO
                        If calItem.CalType = numCalibrateType.Connector_B Then
                            If ShowMsgWhenChannelChanged(msg, calFail, calItem) = False Then Return False
                        Else
                            If ShowMsgOnce(ShowMsg, calFail, calItem) = False Then Return False
                        End If
                End Select

                StopLiveDisplay = True
                dgLiveDispaly.EndInvoke(calItem, iRes)

                Me.tsslpbCal.Value += 1
                Application.DoEvents()

                Dim dgRun As New DelegateRefTest(AddressOf ExcuseStepCalibration)
                Dim res As IAsyncResult = dgRun.BeginInvoke(calItem, VIV, Nothing, Nothing)
                Me.tsslpbCal.Value += 1

                Do While Not res.AsyncWaitHandle.WaitOne(500)
                    If Me.tsslpbCal.Value < Me.tsslpbCal.Maximum Then
                        Me.tsslpbCal.Value += 1
                    End If
                    Application.DoEvents()
                Loop

                dgRun.EndInvoke(calItem, res)

                If DoCalVerify(calItem) = True Then calFail = False

                calItem.CalTime = Now
                pCalIO.AddItem(calItem)
                row.Style = fgCal.Styles("GreenYellow")
                row(8) = calItem.Power
                row(9) = calItem.Offset
                row(10) = calItem.Length
                row(11) = calItem.CalTime
                calItem.CalValid = True
                Me.tsslpbCal.Value = Me.tsslpbCal.Maximum
                Application.DoEvents()
            Loop

            Return True
        Catch ex As Exception
            Throw New Exception("FormCalibrate.ExecuteStepCalibrate()::" & ex.Message)
        End Try
    End Function
    ''' <summary>
    ''' Show cal message when channel changed or cal fail
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="calFail"></param>
    ''' <param name="calItem"></param>
    ''' <returns></returns>
    Private Function ShowMsgWhenChannelChanged(ByRef msg As String, calFail As Boolean, calItem As CalibrateItem) As Boolean
        Try

            If msg <> calItem.Message Or calFail = False Then
                If calItem.JumperType = numJumperType.MTJ Then
                    If FrmMTJJumperCalPrompt Is Nothing Then FrmMTJJumperCalPrompt = New FormCalConnPrompt
                    FrmMTJJumperCalPrompt.ActiveChannel = calItem.Channel
                    FrmMTJJumperCalPrompt.PictureBox1.Image = FrmMTJJumperCalPrompt.ImageList1.Images.Item(calItem.Channel - 1)
                    If FrmMTJJumperCalPrompt.ShowDialog = DialogResult.OK Then
                        msg = calItem.Message
                    Else
                        Return False
                    End If
                Else
                    If gBenchSetting.RecJumperCalType = numJumperCalType.Simulate Then Return True
                    If FrmRecJumperCalPrompt Is Nothing Then FrmRecJumperCalPrompt = New FormRecJumperCalPrompt
                    If FrmRecJumperCalPrompt.ShowDialog = DialogResult.OK Then
                        msg = calItem.Message
                    Else
                        Return False
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("FormCalibrate.ShowMsg()::" & ex.Message)
        End Try
    End Function
    ''' <summary>
    ''' Show message once when cal start
    ''' </summary>
    ''' <param name="showMsg"></param>
    ''' <param name="calFail"></param>
    ''' <param name="calItem"></param>
    ''' <returns></returns>
    Private Function ShowMsgOnce(ByRef showMsg As Boolean, calFail As Boolean, calItem As CalibrateItem) As Boolean
        Try
            If calFail = False Or showMsg Then
                If calItem.JumperType = numJumperType.MTJ Then
                    If FrmMTJJumperCalPrompt Is Nothing Then FrmMTJJumperCalPrompt = New FormCalConnPrompt
                    FrmMTJJumperCalPrompt.ActiveChannel = calItem.Channel
                    FrmMTJJumperCalPrompt.PictureBox1.Image = FrmMTJJumperCalPrompt.ImageList1.Images.Item(calItem.Channel - 1)
                    If FrmMTJJumperCalPrompt.ShowDialog = DialogResult.Cancel Then
                        Return False
                    End If
                Else
                    If gBenchSetting.RecJumperCalType = numJumperCalType.Simulate Then Return True
                    If FrmRecJumperCalPrompt Is Nothing Then FrmRecJumperCalPrompt = New FormRecJumperCalPrompt
                    If FrmRecJumperCalPrompt.ShowDialog = DialogResult.Cancel Then
                        Return False
                    End If
                End If
                showMsg = False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("FormCalibrate.ShowMsgOnce()::" & ex.Message)
        End Try
    End Function

    Private Function DoCalVerify(calItem As CalibrateItem) As Boolean
        Try

            Dim tmpString As String = ""

            tmpString += "Power" & vbTab & calItem.Power & vbCrLf
            tmpString += "Offset" & vbTab & calItem.Offset & vbCrLf
            tmpString += "Length" & vbTab & calItem.Length & vbCrLf

            tmpString += vbCrLf & "Do you want to calibrate again?"

            If calItem.Offset < -0.03 Or calItem.Offset > 3 Then
                If MessageBox.Show(tmpString, "Calibration Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = MsgBoxResult.Yes Then Return False
            End If

            Return True
        Catch ex As Exception
            Throw New Exception("FormCalibrate.DoCalVerify()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Function
    Private Sub LiveDisplay(ByRef CalItem As CalibrateItem, ByVal VIV As IVIAVI)
        Try
            'If FrmRecJumperCalPrompt IsNot Nothing Then SetControlEnabled(FrmRecJumperCalPrompt.btnOK, False)
            'If FrmMTJJumperCalPrompt IsNot Nothing Then SetControlEnabled(FrmMTJJumperCalPrompt.btnOK, False)
#If Simulate Then
            Return
#End If
            Dim il, orl, power As String
            Dim valStr As String
            Dim val() As String
            With VIV
                DisplayLiveValue(CalItem.Channel, CalItem.WaveLength, "------", "------", "------")
                Application.DoEvents()
                Do While Not StopLiveDisplay
                    If .MeasState = MeasState.IDLE Then .MeasStart()
                    .LiveMode = 1
                    valStr = .LiveModeValue
                    If valStr Is Nothing Then
                        .LiveMode = 1
                        Continue Do
                    End If
                    If valStr.Length = 0 Then
                        .LiveMode = 1
                        Continue Do
                    End If
                    val = valStr.Split(vbLf)
                    il = val(0)
                    If il.Contains("---") Then
                        .LiveMode = 1
                        Continue Do
                    End If
                    orl = val(1)
                    power = val(2)
                    If power.Contains("---") Then
                        .LiveMode = 1
                        Continue Do
                    End If
                    DisplayLiveValue(CalItem.Channel, CalItem.WaveLength, il, orl, power)
                    Application.DoEvents()
                    'If FrmRecJumperCalPrompt IsNot Nothing Then SetControlEnabled(FrmRecJumperCalPrompt.btnOK, True)
                    'If FrmMTJJumperCalPrompt IsNot Nothing Then SetControlEnabled(FrmMTJJumperCalPrompt.btnOK, True)
                Loop

            End With
        Catch ex As Exception
            Throw New Exception("TestPlan.RunTestGroup.LiveDisplay()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub SetControlEnabled(ByVal ctl As Control, ByVal enabled As Boolean)
        If ctl.InvokeRequired Then
            ctl.BeginInvoke(New Action(Of Control, Boolean)(AddressOf SetControlEnabled), ctl, enabled)
        Else
            ctl.Enabled = enabled
            ctl.Focus()
            ctl.Select()
        End If
    End Sub
    Private Sub DisplayLiveValue(channel As String, wavelength As String, il As String, orl As String, power As String)
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
    Private Sub SetupMeasurement(ByVal VIV As IVIAVI)
        Try
            With VIV
                ' Reference test
                .MeasFunction = 0
                ' J1 out
                .LaunchPort = 1
                .ORLSetup(1) = "0"
                .ORLSetup(2) = "0"
                ' Setup ORL Zone
                .ORLSetup(1) = "1,1,-0.5,0.5"
                If GUI.SelectedPhaseName = "System" Then
                    .ORLSetup(2) = "1,2,-0.5,0.5"
                End If
                ' Resets all Reference and DUT measurements
                '.MeasReset()
            End With
        Catch ex As Exception
            Throw New Exception("SetupMeasurement()::" & ex.Message)
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            For i As Integer = Me.fgCal.Rows.Fixed To Me.fgCal.Rows.Count - 1
                fgCal(i, 1) = True
            Next
        Catch ex As Exception
            Throw New Exception("SelectAllToolStripMenuItem_Click()::" & ex.Message)
        End Try
    End Sub

    Private Sub SelectNothingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNothingToolStripMenuItem.Click
        Try
            For i As Integer = Me.fgCal.Rows.Fixed To Me.fgCal.Rows.Count - 1
                fgCal(i, 1) = False
            Next
        Catch ex As Exception
            Throw New Exception("SelectNothingToolStripMenuItem_Click()::" & ex.Message)
        End Try
    End Sub

    Private Sub ReverseSelectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReverseSelectToolStripMenuItem.Click
        Try
            For i As Integer = Me.fgCal.Rows.Fixed To Me.fgCal.Rows.Count - 1
                fgCal(i, 1) = Not fgCal(i, 1)
            Next
        Catch ex As Exception
            Throw New Exception("ReverseSelectToolStripMenuItem_Click()::" & ex.Message)
        End Try
    End Sub

    Private Sub SelectAllInvalidToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllInvalidToolStripMenuItem.Click
        Try
            Dim calItem As CalibrateItem
            For i As Integer = Me.fgCal.Rows.Fixed To Me.fgCal.Rows.Count - 1
                calItem = CType(fgCal.Rows(i).UserData, CalibrateItem)
                fgCal(i, 1) = Not calItem.CalValid
            Next
        Catch ex As Exception
            Throw New Exception("SelectAllInvalidToolStripMenuItem_Click()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            abortFlag = True
        Catch ex As Exception
            Throw New Exception("btnAbort_Click()::" & ex.Message)
        End Try
    End Sub
End Class
