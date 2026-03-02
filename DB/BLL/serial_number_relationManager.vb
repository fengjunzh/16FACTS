Public Class serial_number_relationManager
	Private _dal As New FACTS.DAL.serial_number_relationService
	Public Function Add(model As FACTS.Model.serial_number_relation) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.serial_number_relation) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.serial_number_relation) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.serial_number_relation)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("serial_number_relation.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.serial_number_relation
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.BLL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectBySn(sn As String) As FACTS.Model.serial_number_relation
		Try
			Return _dal.SelectBySn(sn)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.BLL.SelectBySn()::" & ex.Message)
		End Try
	End Function
End Class
