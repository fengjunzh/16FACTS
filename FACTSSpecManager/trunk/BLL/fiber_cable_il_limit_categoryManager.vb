Public Class fiber_cable_il_limit_categoryManager
	Private _dal As New FACTS.DAL.fiber_cable_il_limit_categoryService
	Public Function Add(model As FACTS.Model.fiber_cable_il_limit_category) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.fiber_cable_il_limit_category) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.fiber_cable_il_limit_category) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.fiber_cable_il_limit_category)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.fiber_cable_il_limit_category
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.BLL.SelectById()::" & ex.Message)
		End Try
	End Function

End Class
