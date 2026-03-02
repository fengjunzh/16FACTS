Imports C1.Win.C1FlexGrid
Imports FACTS.BLL
Imports FACTS.Model

Public Class FormPFDetail
    Private serialNum As String
    Private PN As String

    Public Sub New(SN As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        serialNum = SN
    End Sub
    Private Sub FormPFDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitGridMain()
            LoadTestPhases()
            If Not String.IsNullOrEmpty(serialNum) Then Me.tbNumber.Text = serialNum
            If GUI.SelectedPhaseName IsNot Nothing Then cbTestPhase.Text = GUI.SelectedPhaseName

            ' Set PF style
            Dim cs As CellStyle
            cs = fgMain.Styles.Add("Red")
            cs.BackColor = Color.Red
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)
            cs = fgMain.Styles.Add("Green")
            cs.BackColor = Color.Green
            cs.ForeColor = Color.White
            cs.Font = New Font(Font.Bold, 9)

            Me.ActiveControl = Me.tbNumber
        Catch ex As Exception
            MsgBox("FormPFDetail_Load()::" & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub LoadTestPhases()
        Try
            Me.cbTestPhase.Items.Clear()
            Dim pmBll As New FACTS.BLL.phase_mainManager
            Dim tpML As List(Of FACTS.Model.phase_main) = pmBll.SelectAll
            If tpML Is Nothing Then Return
            cbTestPhase.Items.AddRange(tpML.ToArray)
        Catch ex As Exception
            Throw New Exception("LoadTestPhases()::" & ex.Message)
        End Try
    End Sub
    Private Sub InitGridMain()
        Try
            'set up grid
            fgMain.Clear()
            fgMain.Cols.Fixed = 1
            fgMain.Cols.Count = 7
            fgMain.Rows.Fixed = 1
            fgMain.Rows.Count = 1
            fgMain.Cols(1).Caption = "SN"
            fgMain.Cols(2).Caption = "PN"
            fgMain.Cols(3).Caption = "WO"
            fgMain.Cols(4).Caption = "Phase"
            fgMain.Cols(5).Caption = "Mode"
            fgMain.Cols(6).Caption = "Status"

            FormatGrid(fgMain, 9, 9)

        Catch ex As Exception
            Throw New Exception("InitGridMain()::" & ex.Message)
        End Try
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If cbTestPhase.SelectedIndex < 0 Then
                MsgBox("Please select a test phase.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            If String.IsNullOrEmpty(Me.tbNumber.Text) Then
                MsgBox("Please enter a valid serial number or work order.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim wo As String
            If Me.tbNumber.Text.StartsWith("600") Then
                wo = Me.tbNumber.Text
            Else
                wo = GetWOFromSN(Me.tbNumber.Text)
                If String.IsNullOrEmpty(wo) Then
                    MsgBox("No work order found for serial number " & Me.tbNumber.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
            InitGridMain()
            Dim cqpswBll As New FACTS.BLL.cq_product_sn_woManager
            Dim cqpswML As List(Of FACTS.Model.cq_product_sn_wo) = cqpswBll.SelectAllByWo(wo)
            If cqpswML Is Nothing Then Return
            PN = cqpswML.First.product_name
            Dim lstPhaseStatus As List(Of FACTS.Model.cq_phases_status)
            Dim cq_phstatus As New FACTS.BLL.cq_phases_statusManager
            Dim r As Row
            Dim TotalNum, PNum, FNum As Integer
            fgMain.Redraw = False
            For Each cq_pswM As cq_product_sn_wo In cqpswML
                lstPhaseStatus = cq_phstatus.SelectAll(cq_pswM.product_name, cq_pswM.product_serial_num, gBenchSetting.TestMode, gBenchSetting.TestPhaseStationMainId)
                If lstPhaseStatus Is Nothing Then Continue For
                Dim phase As String = DirectCast(Me.cbTestPhase.SelectedItem, phase_main).phase
                cq_pswM.phase_status = lstPhaseStatus.Find(Function(o) o.phase = phase).phase_status
                r = Me.fgMain.Rows.Add
                r(1) = cq_pswM.product_serial_num
                r(2) = PN
                r(3) = wo
                r(4) = phase
                r(5) = gBenchSetting.TestMode
                r(6) = cq_pswM.phase_status
                TotalNum += 1
                If cq_pswM.phase_status = numPFAState.P.ToString Then
                    PNum += 1
                Else
                    FNum += 1
                End If
            Next
            fgMain.Redraw = True
            FormatGrid(fgMain, 9, 9)
            Me.tsslStatus.Text = String.Format("Total: {0}, Pass: {1}, Fail: {2}", TotalNum, PNum, FNum)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("btnSearch_Click()::" & ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Function GetWOFromSN(sn As String) As String
        Dim wo As String = String.Empty
        Try
            Dim cqpswBll As New FACTS.BLL.cq_product_sn_woManager
            Dim cqpswM As FACTS.Model.cq_product_sn_wo = cqpswBll.SelectBySn(sn)
            If Not IsNothing(cqpswM) Then
                wo = cqpswM.product_wo
            End If
            Return wo
        Catch ex As Exception
            Throw New Exception("GetWOFromSN()::" & ex.Message)
        End Try
        Return wo
    End Function

    Private Sub fgMain_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgMain.OwnerDrawCell
        Try
            If e.Row >= fgMain.Rows.Fixed And e.Col = fgMain.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgMain.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
            If e.Col = 6 And e.Row >= fgMain.Rows.Fixed Then
                If fgMain(e.Row, 6) = "P" Then
                    e.Style = fgMain.Styles("Green")
                Else
                    e.Style = fgMain.Styles("Red")
                End If
            End If
        Catch ex As Exception
            MsgBox("fgMain_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
End Class