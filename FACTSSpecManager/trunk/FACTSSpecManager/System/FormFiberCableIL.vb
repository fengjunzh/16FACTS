Imports C1.Win.C1FlexGrid
Imports FACTS
Public Class FormFiberCableIL
    Private Sub InitFgILLimit()
        Try
            'set up grid
            fgILLimit.Clear(ClearFlags.Content)
            fgILLimit.Cols.Fixed = 1
            fgILLimit.Cols.Count = 3
            fgILLimit.Rows.Fixed = 1
            fgILLimit.Rows.Count = 1
            fgILLimit.Cols(1).Caption = "Wave Length(nm)"
            fgILLimit.Cols(2).Caption = "IL Limit(dB/1000m)"

            Dim cs As CellStyle
            cs = fgILLimit.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            fgILLimit.Cols(1).AllowEditing = False

            FormatGrid(fgILLimit, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormFiberCableIL.InitFgILLimit()::" & ex.Message)
        End Try
    End Sub

    Private Sub FormFiberCableIL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadFiberCableIlCategory()
        Catch ex As Exception
            MsgBox("FormFiberCableIL.FormFiberCableIL_Load()::" & ex.Message, MsgBoxStyle.Critical, "Load Form Error")
        End Try
    End Sub

    Private Sub LoadFiberCableIlCategory()
        Try
            Dim fcilcML As List(Of Model.fiber_cable_il_limit_category)
            Dim fcilcBll As New BLL.fiber_cable_il_limit_categoryManager
            fcilcML = fcilcBll.SelectAll
            Me.cbLimitName.Items.Clear()
            Me.cbLimitName.Items.AddRange(fcilcML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormFiberCableIL.LoadFiberCableIlCategory()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub fgILLimit_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgILLimit.OwnerDrawCell
        Try
            If e.Row >= fgILLimit.Rows.Fixed And e.Col = fgILLimit.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgILLimit.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormFiberCableIL.fgILLimit_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cbLimitName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLimitName.SelectedIndexChanged
        Try
            If Me.cbLimitName.SelectedItem Is Nothing Then Return
            Dim limitId As Integer = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id
            LoadILLimitTable(limitId)
        Catch ex As Exception
            MsgBox("FormFiberCableIL.cbLimitName_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Change Limit Type Error")
        End Try
    End Sub
    Private Sub LoadILLimitTable(limitId As Integer)
        Try
            InitFgILLimit()
            Dim cqfcilML As List(Of Model.cq_fiber_cable_il_limit)
            Dim cqfcilBll As New BLL.cq_fiber_cable_il_limitManager
            cqfcilML = cqfcilBll.SelectAllByLimitId(limitId)

            If cqfcilML IsNot Nothing Then
                For Each cqfcil As Model.cq_fiber_cable_il_limit In cqfcilML
                    Dim r As Row
                    r = Me.fgILLimit.Rows.Add
                    r(1) = cqfcil.Wave_length
                    r(2) = cqfcil.Il_limit
                    r.UserData = cqfcil
                Next
            Else
                Dim wlML As List(Of Model.wave_length)
                Dim wlBll As New BLL.wave_lengthManager
                wlML = wlBll.SelectAll
                Dim r As Row
                For Each wl As Model.wave_length In wlML
                    r = Me.fgILLimit.Rows.Add
                    r(1) = wl.Wave_length
                    r(2) = 0.1
                    r.UserData = wl
                Next
            End If
            FormatGrid(fgILLimit, 9, 9)
        Catch ex As Exception
            Throw New Exception("FormFiberCableIL.LoadILLimitTable()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If Me.cbLimitName.SelectedItem Is Nothing Then Return
            Dim limitId As Integer = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id

            Dim cqfcilML As List(Of Model.cq_fiber_cable_il_limit)
            Dim cqfcilBll As New BLL.cq_fiber_cable_il_limitManager
            cqfcilML = cqfcilBll.SelectAllByLimitId(limitId)
            Dim fcildBll As New BLL.fiber_cable_il_limit_detailManager
            Dim fcildM As Model.fiber_cable_il_limit_detail
            Dim wlM As Model.wave_length
            If cqfcilML IsNot Nothing Then
                MsgBox(String.Format("{IL limit {0}} already exists, you can only update value!", Me.cbLimitName.Text), MsgBoxStyle.Exclamation, "Add IL Limit Error")
                Me.btnUpdate.Select()
                Return
            Else
                For Each r As Row In Me.fgILLimit.Rows
                    fcildM = New Model.fiber_cable_il_limit_detail
                    wlM = CType(r.UserData, Model.wave_length)
                    If wlM Is Nothing Then Continue For
                    With fcildM
                        .Limit_id = limitId
                        .Wave_length_id = wlM.Id
                        .Il_limit = r(2)
                    End With
                    fcildBll.Add(fcildM)
                Next
            End If
            MsgBox("Add success", MsgBoxStyle.Information, "Add IL Limit")
        Catch ex As Exception
            MsgBox("FormFiberCableIL.btnAdd_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Add Fiber Cable IL Error")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Me.cbLimitName.SelectedItem Is Nothing Then Return
            Dim limitId As Integer = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id

            Dim cqfcilML As List(Of Model.cq_fiber_cable_il_limit)
            Dim cqfcilBll As New BLL.cq_fiber_cable_il_limitManager
            cqfcilML = cqfcilBll.SelectAllByLimitId(limitId)
            Dim fcildBll As New BLL.fiber_cable_il_limit_detailManager
            Dim fcildM As Model.fiber_cable_il_limit_detail
            Dim cqfcilM As Model.cq_fiber_cable_il_limit
            If cqfcilML Is Nothing Then
                MsgBox(String.Format("{IL limit {0}} not exists, you can only add value!", Me.cbLimitName.Text), MsgBoxStyle.Exclamation, "Update IL Limit Error")
                Me.btnAdd.Select()
                Return
            Else
                If MsgBox("Are you sure to update IL limit?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Update IL Limit") = DialogResult.No Then
                    Return
                End If
                For Each r As Row In Me.fgILLimit.Rows
                    fcildM = New Model.fiber_cable_il_limit_detail
                    cqfcilM = CType(r.UserData, Model.cq_fiber_cable_il_limit)
                    If cqfcilM Is Nothing Then Continue For
                    With fcildM
                        .Id = cqfcilM.Db_id
                        .Limit_id = cqfcilM.Limit_id
                        .Wave_length_id = cqfcilM.Wave_length_id
                        .Il_limit = r(2)
                    End With
                    fcildBll.Update(fcildM)
                Next
            End If
            MsgBox("Update success", MsgBoxStyle.Information, "Update IL Limit")
        Catch ex As Exception
            MsgBox("FormFiberCableIL.btnUpdate_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Update Fiber Cable IL Error")
        End Try
    End Sub
    Private Sub fgILLimit_AfterEdit(sender As Object, e As RowColEventArgs) Handles fgILLimit.AfterEdit
        Try
            If String.IsNullOrEmpty(fgILLimit(e.Row, e.Col)) Then
                MsgBox("il value is empty", MsgBoxStyle.Critical, "Set IL Value Error")
            Else
                If fgILLimit(e.Row, e.Col) <= 0 Then
                    MsgBox("il value must be bigger than 0", MsgBoxStyle.Critical, "Set IL Value Error")
                End If
            End If
        Catch ex As Exception
            MsgBox("FormFiberCableIL.fgILLimit_AfterEdit()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "After Edit Cell Error")
        End Try
    End Sub
End Class