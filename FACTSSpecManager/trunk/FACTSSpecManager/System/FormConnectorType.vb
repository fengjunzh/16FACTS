Imports C1.Win.C1FlexGrid
Imports FACTS
Public Class FormConnectorType
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Dim ctML As List(Of Model.connector_type)
            Dim ctBll As New BLL.connector_typeManager
            ctML = ctBll.SelectAll
            If Me.cbConnectorType.SelectedItem IsNot Nothing Then
                ctML = ctML.Where(Function(o) o.Connector_type = Me.cbConnectorType.Text).ToList
            End If
            LoadFgConnectorType(ctML)
        Catch ex As Exception
            MsgBox("FormConnectorType.btnRefresh_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Refresh Connector Type Error")
        End Try
    End Sub

    Private Sub FormConnectorType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadConnectorType()
            InitFgConnType()
            LoadConnectorFamily()
        Catch ex As Exception
            MsgBox("FormConnectorType.FormConnectorType_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load Form Error")
        End Try
    End Sub
    Private Sub InitFgConnType()
        Try
            'set up grid
            fgConnType.Clear(ClearFlags.Content)
            fgConnType.Cols.Fixed = 1
            fgConnType.Cols.Count = 6
            fgConnType.Rows.Fixed = 1
            fgConnType.Rows.Count = 1
            fgConnType.Cols(1).Caption = "Connector Type"
            fgConnType.Cols(2).Caption = "Connector Description"
            fgConnType.Cols(3).Caption = "Validity"
            fgConnType.Cols(4).Caption = "Family"
            fgConnType.Cols(5).Caption = "Factor"

            Dim cs As CellStyle
            cs = fgConnType.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            cs = fgConnType.Styles.Add("bool")
            cs.DataType = Type.GetType("System.Boolean")
            fgConnType.Cols(3).Style = cs

            FormatGrid(fgConnType, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormConnectorType.InitFgConnType()::" & ex.Message)
        End Try
    End Sub

    Private Sub fgConnType_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgConnType.OwnerDrawCell
        Try
            If e.Row >= fgConnType.Rows.Fixed And e.Col = fgConnType.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgConnType.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormConnectorType.fgConnType_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub LoadConnectorFamily()
        Try
            Dim cfML As List(Of Model.connector_family)
            Dim cfBll As New BLL.connector_familyManager
            cfML = cfBll.SelectAll
            Me.cbConnectorFamily.Items.Clear()
            Me.cbConnectorFamily.Items.AddRange(cfML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormConnectorType.LoadConnectorFamily()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadConnectorType()
        Try
            Dim ctML As List(Of Model.connector_type)
            Dim ctBll As New BLL.connector_typeManager
            ctML = ctBll.SelectAll
            Me.cbConnectorType.Items.Clear()
            If ctML Is Nothing Then Return
            Me.cbConnectorType.Items.AddRange(ctML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormConnectorType.LoadConnectorType()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadFgConnectorType(values As List(Of Model.connector_type))
        Try
            InitFgConnType()
            If values Is Nothing Then Return
            Dim r As Row
            For Each val As Model.connector_type In values
                r = Me.fgConnType.Rows.Add
                r(1) = val.Connector_type
                r(2) = val.Descr
                r(3) = val.Validaity
                r(4) = (New BLL.connector_familyManager).SelectById(val.Connector_family_id).Family_name
                r(5) = val.Factor
                r.UserData = val
            Next
            FormatGrid(fgConnType, 9, 9)
        Catch ex As Exception
            Throw New Exception("FormConnectorType.LoadFgConnectorType()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtConnectorType.Text.Length = 0 Then
                MsgBox("Please input conenctor type", MsgBoxStyle.Information, "Add Connector Type")
                Me.txtConnectorType.Select()
                Return
            End If
            Dim ctM As Model.connector_type
            Dim ctBll As New BLL.connector_typeManager
            ctM = ctBll.SelectByConnectorType(Me.txtConnectorType.Text)
            If ctM IsNot Nothing Then
                MsgBox(String.Format("Connector type {0} already exists", Me.txtConnectorType.Text), MsgBoxStyle.Information, "Add Connector Type")
                Me.txtConnectorType.Select()
                Return
            Else
                Dim cfM As Model.connector_family = CType(Me.cbConnectorFamily.SelectedItem, Model.connector_family)
                If cfM Is Nothing Then
                    MsgBox(String.Format("Please select one connector family"), MsgBoxStyle.Information, "Add Connector Type")
                    Me.cbConnectorFamily.Select()
                    Return
                End If
                ctM = New Model.connector_type
                With ctM
                    ctM.Connector_type = Me.txtConnectorType.Text
                    ctM.Descr = Me.txtDescr.Text
                    ctM.Connector_family_id = cfM.Id
                    ctM.Validaity = ckValidity.Checked
                    ctM.Factor = Integer.Parse(Me.txtFactor.Text)
                    ctBll.Add(ctM)
                End With
            End If
            MsgBox(String.Format("Add success"), MsgBoxStyle.Information, "Add Connector Type")
            Me.btnRefresh.PerformClick()
        Catch ex As Exception
            MsgBox("FormConnectorType.btnAdd_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Add Connector Type Error")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtConnectorType.Text.Length = 0 Then
                MsgBox("Please input conenctor type", MsgBoxStyle.Information, "Update Connector Type")
                Me.txtConnectorType.Select()
                Return
            End If
            Dim ctM As Model.connector_type
            Dim ctBll As New BLL.connector_typeManager
            ctM = ctBll.SelectByConnectorType(Me.txtConnectorType.Text)
            If ctM Is Nothing Then
                MsgBox(String.Format("Connector type {0} doesn't exist", Me.txtConnectorType.Text), MsgBoxStyle.Information, "Update Connector Type")
                Me.txtConnectorType.Select()
                Return
            Else
                Dim cfM As Model.connector_family = CType(Me.cbConnectorFamily.SelectedItem, Model.connector_family)
                If cfM Is Nothing Then
                    MsgBox(String.Format("Please select one connector family"), MsgBoxStyle.Information, "Update Connector Type")
                    Me.cbConnectorFamily.Select()
                    Return
                End If
                With ctM
                    ctM.Connector_type = Me.txtConnectorType.Text
                    ctM.Descr = Me.txtDescr.Text
                    ctM.Connector_family_id = cfM.Id
                    ctM.Validaity = ckValidity.Checked
                    ctM.Factor = Integer.Parse(Me.txtFactor.Text)
                    ctBll.Update(ctM)
                End With
            End If
            MsgBox(String.Format("Update success"), MsgBoxStyle.Information, "Update Connector Type")
            Me.btnRefresh.PerformClick()
        Catch ex As Exception
            MsgBox("FormConnectorType.btnUpdate_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Update Connector Type Error")
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub fgConnType_Click(sender As Object, e As EventArgs) Handles fgConnType.Click
        Try
            If Me.fgConnType.Row < 1 Then Return
            Dim r As Row = fgConnType.Rows(fgConnType.Row)
            Dim ctM As Model.connector_type = CType(r.UserData, Model.connector_type)
            If ctM Is Nothing Then Return
            Me.txtConnectorType.Text = ctM.Connector_type
            Me.ckValidity.Checked = ctM.Validaity
            Me.txtDescr.Text = ctM.Descr
            Me.cbConnectorFamily.Text = r(4)
            Me.txtFactor.Text = ctM.Factor
        Catch ex As Exception
            MsgBox("FormConnectorType.fgConnType_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Select Connector Type Error")
        End Try
    End Sub
End Class