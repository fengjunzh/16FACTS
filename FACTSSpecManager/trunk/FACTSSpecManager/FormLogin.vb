Imports System.Configuration
Public Class FormLogin
	Private Sub Startup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			lblCATS.Text = "FACTS Spec Manager ver" & Application.ProductVersion & " Developed by CATS Team."

			Dim connNum As Integer = ConfigurationManager.ConnectionStrings.Count
			'Dim ci As ConnectionStringSettings
			'Dim cItem As ComboxItem

			Dim connList As List(Of ComboxItem) = GetConnString()

			For Each conn In connList
				cbConnString.Items.Add(conn)
			Next

			Me.cbConnString.SelectedIndex = 0

		Catch ex As Exception
			MsgBox("CATSConsole start up." & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub

	Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles BtnConnect.Click
		Try
			Dim cItem As ComboxItem = cbConnString.SelectedItem
			If cItem Is Nothing Then
				MsgBox("Please select one item!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
				Return
			End If

			SwitchCATSServer(cItem)

			pActivedDb = cItem
			Me.Close()

		Catch ex As Exception
			MsgBox("Select connectiong string()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		End
	End Sub
End Class