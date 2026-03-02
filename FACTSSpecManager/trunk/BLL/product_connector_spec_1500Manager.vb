Public Class product_connector_spec_1500Manager
	Private _dal As New FACTS.DAL.product_connector_spec_1500Service
	Public Function Add(model As FACTS.Model.product_connector_spec_1500) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.product_connector_spec_1500) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.product_connector_spec_1500) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.product_connector_spec_1500)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.product_connector_spec_1500
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByProdMainId(product_main_id As Integer) As FACTS.Model.product_connector_spec_1500
		Try
			Return _dal.SelectByProdMainId(product_main_id)
		Catch ex As Exception
			Throw New Exception("product_connector_spec_1500.BLL.SelectByProdMainId()::" & ex.Message)
		End Try
	End Function
End Class
