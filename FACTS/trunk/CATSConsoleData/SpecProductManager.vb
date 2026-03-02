Public Class SpecProductManager
	Private _EXISTED_MODEL As CATSConsoleModel.SpecProduct
	'Public WithEvents RaiseMessage As CATSConsoleModel.EventMessageHandler
	Public EventShowMessage As New CATSConsoleModel.EventMessage
	Public EventShowModeProgress As New CATSConsoleModel.EventProgress
	Public EventShowPhaseProgress As New CATSConsoleModel.EventProgress
	Public WriteOnly Property ExistedModel As CATSConsoleModel.SpecProduct
		Set(value As CATSConsoleModel.SpecProduct)
			_EXISTED_MODEL = value
		End Set
	End Property
	Private Sub ShowPhaseProgress(progressValue As Decimal, totalValue As Decimal)
		EventShowPhaseProgress.ShowProgress(progressValue, totalValue)
	End Sub
	Public Function Create(data As CATSConsoleModel.SpecProduct) As Boolean
		Try
			'productM.Create()
			Dim pm_id As Integer
			Dim ppmBll As New ProductProfileManager
			Dim smmBll As New SpecModeManager
			Dim msg As String
			Dim rc As Integer = 0

			'add product profile
			ppmBll.ExistedModel = Nothing
			If _EXISTED_MODEL IsNot Nothing Then ppmBll.ExistedModel = _EXISTED_MODEL.productM

			pm_id = ppmBll.Create(data.productM)

			'for each to adding test modes
			AddHandler smmBll.EventShowProgress.ShowProgressHandler, AddressOf ShowPhaseProgress
			AddHandler smmBll.EventShowMessage.ShowMessageHandler, AddressOf EventShowMessage.ShowMessage

			For Each tm In data.TestModeL

				msg = ">> Beginning copy mode/" & tm.cq_modeM.mode & " ..."
				EventShowMessage.ShowMessage(msg)
				'AddHandler smmBll.EventShowProgress.ShowProgressHandler, AddressOf ShowPhaseProgress
				'AddHandler smmBll.EventShowMessage.ShowMessageHandler, AddressOf EventShowMessage.ShowMessage
				smmBll.ExistedModel = Nothing

				If _EXISTED_MODEL IsNot Nothing Then
					If _EXISTED_MODEL.TestModeL IsNot Nothing Then
						For Each tmed In _EXISTED_MODEL.TestModeL
							If tm.cq_modeM.mode.ToUpper.Trim = tmed.cq_modeM.mode.ToUpper.Trim Then
								smmBll.ExistedModel = tmed
							End If
						Next
					End If
				End If

				smmBll.Create(pm_id, tm)
				rc += 1
				EventShowModeProgress.ShowProgress(rc, data.TestModeL.Count)
				msg = ">> Finished copy mode/" & tm.cq_modeM.mode
				EventShowMessage.ShowMessage(msg)
			Next

			Return True

		Catch ex As Exception
			Throw New Exception("SpecProductManager.Create(SpecProduct)::" & ex.Message)
		End Try

	End Function
End Class
