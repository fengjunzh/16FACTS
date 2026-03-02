Public Class SpecItemManager
	Public Shared Function Create(group_main_id As Integer, data As CATSConsoleModel.SpecItem) As Boolean
		Try
			If data Is Nothing Then Return True
			If data.item_detailM Is Nothing Then Return True


			Dim sd_id As Integer

			If data.item_detailM Is Nothing Then Return True
			Dim sdBll As New FACTS.BLL.spec_detailManager
			data.item_detailM.spec_detailM.group_main_id = group_main_id
			data.item_detailM.spec_detailM.validation_date = Now
			data.item_detailM.spec_detailM.invalidation_date = "2016-1-1"

			sd_id = sdBll.AddReturnId(data.item_detailM.spec_detailM)

			Return True

		Catch ex As Exception
			Throw New Exception("SpecItemManager.Create(int,SpecItem)::" & ex.Message)
		End Try
	End Function
End Class
