Public Class product_cable_ilManager
	Private _dal As New FACTS.DAL.product_cable_ilService
	Public Function Add(model As FACTS.Model.product_cable_il) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("product_cable_il.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.product_cable_il) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("product_cable_il.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.product_cable_il) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("product_cable_il.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.product_cable_il)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("product_cable_il.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.product_cable_il
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("product_cable_il.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByProductMainId(product_main_id As Integer) As FACTS.Model.product_cable_il
		Try
			Return _dal.SelectByProductMainId(product_main_id)
		Catch ex As Exception
			Throw New Exception("product_cable_il.BLL.SelectByProductMainId()::" & ex.Message)
		End Try
	End Function
End Class
