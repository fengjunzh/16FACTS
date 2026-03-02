Imports System
Imports System.Collections.Generic
Imports FACTS

Public Class spec_logManager
    Private _dal As New FACTS.DAL.spec_logService
    Public Function Add(model As Model.spec_log) As Boolean
      Try

        Return _dal.Add(model)

      Catch ex As Exception
        Throw New Exception("spec_log.BLL.Add()::"& ex.Message)
      End Try
    End Function
   Public Function AddReturnId(model As Model.spec_log) As Integer
      Try

        Return _dal.AddReturnId(model)

      Catch ex As Exception
        Throw New Exception("spec_log.BLL.AddReturnId()::" & ex.Message)
      End Try
    End Function
  Public Function Delete(id As Integer) As Boolean
      Try
        Return _dal.Delete(id)
      Catch ex As Exception
        Throw New Exception("spec_log.BLL.Delete()::" & ex.Message)
      End Try
    End Function
   Public Function Update(model As Model.spec_log) As Boolean
      Try
        Return _dal.Update(model)
      Catch ex As Exception
        Throw New Exception("spec_log.BLL.Update()::" & ex.Message)
      End Try
    End Function
    Public Function SelectAll() As List(Of Model.spec_log)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("spec_log.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectSpecMainId(id As Integer) As List(Of Model.spec_log)
        Try
            Return _dal.SelectBySpecMainId(id)

        Catch ex As Exception
            Throw New Exception("spec_log.BLL.SelectSpecMainId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.spec_log
       Try
        Return _dal.SelectById(id)
      Catch ex As Exception
        Throw New Exception("spec_log.BLL.SelectById()::" & ex.Message)
      End Try
    End Function

  End Class
