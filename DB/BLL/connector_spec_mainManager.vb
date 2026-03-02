Public Class connector_spec_mainManager
	Private _dal As New FACTS.DAL.connector_spec_mainService
	Public Function Add(model As FACTS.Model.connector_spec_main) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("connector_spec_main.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.connector_spec_main) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("connector_spec_main.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("connector_spec_main.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.connector_spec_main) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("connector_spec_main.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.connector_spec_main)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("connector_spec_main.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.connector_spec_main
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("connector_spec_main.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectBySpecNum(spec_num As String) As FACTS.Model.connector_spec_main
		Try
			Return _dal.SelectBySpecNum(spec_num)
		Catch ex As Exception
			Throw New Exception("connector_spec_main.BLL.SelectBySpecNum()::" & ex.Message)
		End Try
	End Function
End Class
