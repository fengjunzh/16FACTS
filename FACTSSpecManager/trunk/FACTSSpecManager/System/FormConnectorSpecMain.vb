Imports FACTS

Public Class FormConnectorSpecMain
    Private Sub FormConnectorSpecMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadConnectorType()

        Catch ex As Exception
            MsgBox("FormConnectorSpecMain.FormConnectorSpecMain_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load Form Error")
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
            Throw New Exception("FormConnectorSpecMain.LoadConnectorType()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim specNum As String = Me.txtSpecNum.Text
            If specNum.Length = 0 Then
                MsgBox("Please input spec number", MsgBoxStyle.Exclamation, "Save Connector Spec Number")
                Me.txtSpecNum.Select()
                Return
            End If
            Dim csmM As Model.connector_spec_main
            Dim csmBll As New BLL.connector_spec_mainManager
            csmM = csmBll.SelectBySpecNum(specNum)

            If csmM IsNot Nothing Then
                MsgBox(String.Format("Spec number {0} already exists!", specNum), MsgBoxStyle.Exclamation, "Save Connector Spec Number")
                Me.txtSpecNum.SelectAll()
                Return
            Else
                csmM = New Model.connector_spec_main
                With csmM
                    .Spec_num = specNum
                    .Connector_type_id = CType(Me.cbConnectorType.SelectedItem, Model.connector_type).Id
                    .Validaity = True
                End With
                csmBll.Add(csmM)
            End If

            MsgBox("Save Success", MsgBoxStyle.Information, "Save Connector Spec Number")

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MsgBox("FormConnectorSpecMain.btnSave_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Save Connector Spec Main")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class