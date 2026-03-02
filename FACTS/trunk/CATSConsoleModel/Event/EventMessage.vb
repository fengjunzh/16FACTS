Public Class EventMessage
	'Public Event myEvent As EventHandler
	Public Event ShowMessageHandler(msg As String)
	Public Sub ShowMessage(msg As String)
		RaiseEvent ShowMessageHandler(msg)
	End Sub

End Class
