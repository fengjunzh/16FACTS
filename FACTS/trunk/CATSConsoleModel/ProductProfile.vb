Public Class ProductProfile
	Public product_mainM As New FACTS.Model.product_main
	Public product_connector_spec_1500M As New FACTS.Model.product_connector_spec_1500
	Public product_connector_spec_1501M As New FACTS.Model.product_connector_spec_1501
	Public connector_spec_main As New FACTS.Model.connector_spec_main
	Public Sub New()

	End Sub
	Public Sub New(pmM As FACTS.Model.product_main)
		Try

			product_mainM = pmM

			product_connector_spec_1500M = (New FACTS.BLL.product_connector_spec_1500Manager).SelectByProdMainId(pmM.Id)

			product_connector_spec_1501M = (New FACTS.BLL.product_connector_spec_1501Manager).SelectByProdMainId(pmM.Id)


		Catch ex As Exception
			Throw New Exception("ProductProfile New()::" & ex.Message)
		End Try
	End Sub

	Public Function CompareTo(value As FACTS.Model.product_main) As Boolean
		Try
			If product_mainM.CompareTo(value) = False Then Return False
			Return True

		Catch ex As Exception
			Throw New Exception("ProductProfile.CompareTo(product_main)::" & ex.Message)
		End Try
	End Function

	Public Function CompareTo(value As ProductProfile) As Boolean
		Try

			'compare product_main
			If CompareTo(value.product_mainM) = False Then Return False

			Return True

		Catch ex As Exception
      Throw New Exception("ProductProfile.Compare(ProductProfile)::" & ex.Message)
    End Try

	End Function

End Class
