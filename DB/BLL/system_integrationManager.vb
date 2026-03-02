Public Class system_integrationManager
	Private _dal As New FACTS.DAL.system_integrationService
	Public Function Add(model As FACTS.Model.system_integration) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("system_integration.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.system_integration) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("system_integration.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.system_integration) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("system_integration.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.system_integration)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("system_integration.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.system_integration
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("system_integration.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectBySN(sn As String) As FACTS.Model.system_integration
		Try
			Return _dal.SelectBySN(sn)
		Catch ex As Exception
			Throw New Exception("system_integration.BLL.SelectBySN()::" & ex.Message)
		End Try
	End Function

End Class
