Public Class EventProgress
	Public Event ShowProgressHandler(process As Decimal, total As Decimal)

	Public Sub ShowProgress(progressValue As Decimal, totalValue As Decimal)
		RaiseEvent ShowProgressHandler(progressValue, totalValue)
	End Sub

End Class
