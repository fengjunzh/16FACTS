Public Class SpecGroupManager

	Public Shared Function Create(spec_main_id As Integer, data As CATSConsoleModel.SpecGroup) As Integer
		Try
			If data Is Nothing Then Return True
			If data.group_mainM Is Nothing Then Return True
			If data.SpecItemML Is Nothing Then Throw New Exception("No spec items in group<" & data.group_mainM.group_name & ">")

			Dim gm_id As Integer

			Dim sgBll As New FACTS.BLL.group_mainManager

			'add group_main
			data.group_mainM.spec_main_id = spec_main_id
			gm_id = sgBll.AddReturnId(data.group_mainM)

			'for each add spec_detail
			For Each siM In data.SpecItemML
				CATSConsoleData.SpecItemManager.Create(gm_id, siM)
			Next

			Return True

		Catch ex As Exception
			Throw New Exception("SpecGroupManager.Create(int,SpecGroup)::" & ex.Message)
		End Try
	End Function
End Class
