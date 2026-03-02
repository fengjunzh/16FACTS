Public Class length_limitManager
	Private _dal As New FACTS.DAL.length_limitService
	Public Function Add(model As FACTS.Model.length_limit) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("length_limit.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.length_limit) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("length_limit.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.length_limit) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("length_limit.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.length_limit)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("length_limit.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.length_limit
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("length_limit.BLL.SelectById()::" & ex.Message)
		End Try
	End Function

End Class
