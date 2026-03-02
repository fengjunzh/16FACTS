Imports C1.Win.C1FlexGrid
Imports FACTS
Imports FACTS.Model

Public Class FormConnectorSpecDetail
    Private specNumber As String
    ReadOnly Property CSModel As connector_spec_main
        Get
            If Me.cbSpecNum.SelectedItem Is Nothing Then Return Nothing
            Return CType(Me.cbSpecNum.SelectedItem, Model.connector_spec_main)
        End Get
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(specNum As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        specNumber = specNum
    End Sub


    Private Sub FormConnectorSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitFgConnSpec()
            LoadConnectorSpecMain()
            If specNumber IsNot Nothing Then
                If specNumber.Length > 0 Then Me.cbSpecNum.Text = specNumber
            End If
        Catch ex As Exception
            MsgBox("FormConnectorSpecDetail.FormConnectorSpec_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load Form Error")
        End Try
    End Sub
    Private Sub InitFgConnSpec()
        Try
            'set up grid
            fgConnSpec.Clear(ClearFlags.Content)
            fgConnSpec.Cols.Fixed = 1
            fgConnSpec.Cols.Count = 5
            fgConnSpec.Rows.Fixed = 1
            fgConnSpec.Rows.Count = 1
            fgConnSpec.Cols(1).Caption = "Select"
            fgConnSpec.Cols(2).Caption = "Wave Length"
            fgConnSpec.Cols(3).Caption = "IL Limit"
            fgConnSpec.Cols(4).Caption = "RL_Limit"

            Dim cs As CellStyle
            cs = fgConnSpec.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            cs = fgConnSpec.Styles.Add("bool")
            cs.DataType = Type.GetType("System.Boolean")
            fgConnSpec.Cols(1).Style = cs

            FormatGrid(fgConnSpec, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormConnectorSpecDetail.InitFgConnSpec()::" & ex.Message)
        End Try
    End Sub

    Private Sub LoadConnectorSpecMain()
        Try
            Dim csmML As List(Of Model.connector_spec_main)
            Dim csmBll As New BLL.connector_spec_mainManager
            csmML = csmBll.SelectAll
            If csmML Is Nothing Then Return
            Me.cbSpecNum.Items.Clear()
            Me.cbSpecNum.Items.AddRange(csmML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormConnectorSpecDetail.InitFgConnSpec()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            Dim frmConnectorSpecMain As New FormConnectorSpecMain
            frmConnectorSpecMain.ShowDialog()
            If frmConnectorSpecMain.DialogResult = DialogResult.OK Then
                LoadConnectorSpecMain()
                Me.cbSpecNum.Text = FormConnectorSpecMain.txtSpecNum.Text
            End If
        Catch ex As Exception
            MsgBox("FormConnectorSpecDetail.btnNew_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Create New Spec Number")
        End Try
    End Sub

    Private Sub cbSpecNum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSpecNum.SelectedIndexChanged
        Try
            InitFgConnSpec()
            If Me.cbSpecNum.SelectedItem Is Nothing Then Return
            Dim ctId As Integer = CSModel.Connector_type_id
            Me.txtConnectorType.Text = (New BLL.connector_typeManager).SelectById(ctId).Connector_type
            Dim csdML As List(Of Model.connector_spec_detail)
            Dim csdBll As New BLL.connector_spec_detailManager
            csdML = csdBll.SelectByConnSpecMainId(CSModel.Id)

            Dim r As Row
            Dim wlML As List(Of Model.wave_length) = (New BLL.wave_lengthManager).SelectAll
            For Each wl As Model.wave_length In wlML
                r = Me.fgConnSpec.Rows.Add
                r(1) = False
                r(2) = wl.Wave_length
                r(3) = ""
                r(4) = ""
                r.UserData = wl
            Next

            Dim csdM As Model.connector_spec_detail
            If csdML IsNot Nothing Then
                For Each r In Me.fgConnSpec.Rows
                    If r.Index < 1 Then Continue For
                    csdM = csdML.Find(Function(o) o.Wave_length_id = CType(r.UserData, Model.wave_length).Id)
                    If csdM IsNot Nothing Then
                        r(1) = True
                        r(3) = csdM.Il_limit
                        r(4) = csdM.Rl_limit
                    End If
                Next
            End If
            FormatGrid(fgConnSpec, 9, 9)
        Catch ex As Exception
            MsgBox("FormConnectorSpecDetail.cbSpecNum_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Create New Spec Number")
        End Try
    End Sub

    Private Sub fgConnSpec_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgConnSpec.OwnerDrawCell
        Try
            If e.Row >= fgConnSpec.Rows.Fixed And e.Col = fgConnSpec.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgConnSpec.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormConnectorSpecDetail.fgConnSpec_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim csdBll As New BLL.connector_spec_detailManager
            Dim csdML As List(Of Model.connector_spec_detail) = csdBll.SelectByConnSpecMainId(CSModel.Id)

            If csdML IsNot Nothing Then
                For Each m As Model.connector_spec_detail In csdML
                    csdBll.Delete(m.Id)
                Next
            End If

            Dim csdM As Model.connector_spec_detail
            csdML = New List(Of Model.connector_spec_detail)
            For Each r As Row In Me.fgConnSpec.Rows
                If r.Index < 1 Then Continue For
                If r(1) = False Then Continue For
                If String.IsNullOrEmpty(r(3)) Then Continue For
                If String.IsNullOrEmpty(r(4)) Then Continue For
                csdM = New Model.connector_spec_detail
                With csdM
                    .Connector_spec_main_id = CSModel.Id
                    .Wave_length_id = CType(r.UserData, Model.wave_length).Id
                    .Il_limit = r(3)
                    .Rl_limit = r(4)
                End With
                csdML.Add(csdM)
            Next

            If csdML.Count = 0 Then MsgBox("Nothing to add", MsgBoxStyle.Information, "Add Connector Spec") : Return

            For Each m As Model.connector_spec_detail In csdML
                csdBll.Add(m)
            Next

            MsgBox("Add success", MsgBoxStyle.Information, "Add Connector Spec")
        Catch ex As Exception
            MsgBox("FormConnectorSpecDetail.btnAdd_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Create Connector Spec")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim csdBll As New BLL.connector_spec_detailManager
            Dim csdML As List(Of Model.connector_spec_detail) = csdBll.SelectByConnSpecMainId(CSModel.Id)

            If csdML IsNot Nothing Then
                For Each m As Model.connector_spec_detail In csdML
                    csdBll.Delete(m.Id)
                Next
            End If

            Dim csdM As Model.connector_spec_detail
            csdML = New List(Of Model.connector_spec_detail)
            For Each r As Row In Me.fgConnSpec.Rows
                If r.Index < 1 Then Continue For
                If r(1) = False Then Continue For
                If String.IsNullOrEmpty(r(3)) Then Continue For
                If String.IsNullOrEmpty(r(4)) Then Continue For
                csdM = New Model.connector_spec_detail
                With csdM
                    .Connector_spec_main_id = CSModel.Id
                    .Wave_length_id = CType(r.UserData, Model.wave_length).Id
                    .Il_limit = r(3)
                    .Rl_limit = r(4)
                End With
                csdML.Add(csdM)
            Next

            If csdML.Count = 0 Then MsgBox("Nothing to update", MsgBoxStyle.Information, "Update Connector Spec") : Return

            For Each m As Model.connector_spec_detail In csdML
                csdBll.Add(m)
            Next

            MsgBox("Update success", MsgBoxStyle.Information, "Update Connector Spec")
        Catch ex As Exception
            MsgBox("FormConnectorSpecDetail.btnUpdate_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Update Connector Spec")
        End Try
    End Sub
End Class