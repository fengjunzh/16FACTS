Public Class SpecGroup
	Public group_mainM As New FACTS.Model.group_main
	Public SpecItemML As New List(Of SpecItem)

	Public Sub New(group_main As FACTS.Model.group_main)
		Try
			group_mainM = group_main

			Dim sdBll As New FACTS.BLL.spec_detailManager
			Dim sdML As New List(Of FACTS.Model.spec_detail)

			sdML = sdBll.SelectAllByGroupMainId(group_main.id)

			If sdML Is Nothing Then
				SpecItemML = Nothing
				Return
			End If

			For Each sdM In sdML
				SpecItemML.Add(New SpecItem(sdM))
			Next
		Catch ex As Exception
			Throw New Exception("SpecGroup.New()::" & ex.Message)
		End Try
	End Sub
	Public Function CompareTo(value As SpecGroup) As Boolean
		Try
			If SpecItemML.Count <> value.SpecItemML.Count Then Return False

			Return True

		Catch ex As Exception
			Throw New Exception("SpecGroup.CompareTo(SpecGroup)::" & ex.Message)
		End Try

	End Function
End Class
