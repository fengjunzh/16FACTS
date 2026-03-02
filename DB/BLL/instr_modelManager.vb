Imports System
Imports System.Collections.Generic

Public Class instr_modelManager

    Private _dal As New FACTS.DAL.instr_modelService
    Public Function Add(model As Model.instr_model) As Boolean
    Try

      Return _dal.Add(model)

    Catch ex As Exception
      Throw New Exception("instr_model.BLL.Add()::" & ex.Message)
    End Try
  End Function
  Public Function AddReturnId(model As Model.instr_model) As Integer
    Try

      Return _dal.AddReturnId(model)

    Catch ex As Exception
      Throw New Exception("instr_model.BLL.AddReturnId()::" & ex.Message)
    End Try
  End Function
  Public Function Delete(id As Integer) As Boolean
    Try
      Return _dal.Delete(id)
    Catch ex As Exception
      Throw New Exception("instr_model.BLL.Delete()::" & ex.Message)
    End Try
  End Function
  Public Function Update(model As Model.instr_model) As Boolean
    Try
      Return _dal.Update(model)
    Catch ex As Exception
      Throw New Exception("instr_model.BLL.Update()::" & ex.Message)
    End Try
  End Function
  Public Function SelectAll() As List(Of Model.instr_model)
    Try
      Return _dal.SelectAll()

    Catch ex As Exception
      Throw New Exception("instr_model.BLL.SelectAll()::" & ex.Message)
    End Try
  End Function
  Public Function SelectById(id As Integer) As Model.instr_model
    Try
      Return _dal.SelectById(id)
    Catch ex As Exception
      Throw New Exception("instr_model.BLL.SelectById()::" & ex.Message)
    End Try
  End Function

End Class
