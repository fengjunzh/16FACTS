Public Class ItemDetail
	Public spec_detailM As New FACTS.Model.spec_detail

	Public Sub New()

	End Sub
	Public Sub New(spec_detail As FACTS.Model.spec_detail)
		Try
			spec_detailM = spec_detail

		Catch ex As Exception
			Throw New Exception("ItemDetail.New()::" & ex.Message)
		End Try
	End Sub
	Public Function CompareTo(value As ItemDetail) As Boolean
		Try
			'spec_detail 
			If spec_detailM.CompareTo(value.spec_detailM) = False Then Return False

			Return True

		Catch ex As Exception
			Throw New Exception("ItemDetail.CompareTo()::" & ex.Message)
		End Try

	End Function
End Class
Public Class SpecItem
	Public item_detailM As New ItemDetail
	Public Sub New(spec_detail As FACTS.Model.spec_detail)
		Try
			item_detailM = New ItemDetail(spec_detail)

		Catch ex As Exception
			Throw New Exception("SpecItem.New()::" & ex.Message)
		End Try
	End Sub
	Public Function CompareTo(value As SpecItem) As Boolean
		Try
			If item_detailM.CompareTo(value.item_detailM) = False Then Return False

			Return True

		Catch ex As Exception
			Throw New Exception("SpecItem.CompareTo()::" & ex.Message)
		End Try

	End Function
End Class

