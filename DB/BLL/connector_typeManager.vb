Public Class connector_typeManager
	Private _dal As New FACTS.DAL.connector_typeService
	Public Function Add(model As FACTS.Model.connector_type) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("connector_type.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.connector_type) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("connector_type.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.connector_type) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("connector_type.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.connector_type)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("connector_type.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.connector_type
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("connector_type.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByConnectorType(connector_type As String) As FACTS.Model.connector_type
		Try
			Return _dal.SelectByConnectorType(connector_type)
		Catch ex As Exception
			Throw New Exception("connector_type.BLL.SelectByConnectorType()::" & ex.Message)
		End Try
	End Function
End Class
