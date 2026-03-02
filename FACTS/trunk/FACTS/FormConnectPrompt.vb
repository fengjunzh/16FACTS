Imports C1.Win.C1Chart
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports FACTS.Model

Public Class FormConnectPrompt
    Public TextContent As String
    Private Sub frmConnectPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = TextContent
    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class