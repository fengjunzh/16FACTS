Public Class connector_spec_detailManager
	Private _dal As New FACTS.DAL.connector_spec_detailService
	Public Function Add(model As FACTS.Model.connector_spec_detail) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.connector_spec_detail) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.connector_spec_detail) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.connector_spec_detail)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.connector_spec_detail
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByConnSpecMainId(conn_spec_main_id As Integer) As List(Of FACTS.Model.connector_spec_detail)
		Try
			Return _dal.SelectByConnSpecMainId(conn_spec_main_id)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.BLL.SelectByConnSpecMainId()::" & ex.Message)
		End Try
	End Function
End Class
