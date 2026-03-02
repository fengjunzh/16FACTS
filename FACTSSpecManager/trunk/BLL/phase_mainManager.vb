Imports System
Imports System.Collections.Generic

Public Class phase_mainManager
    Private _dal As New FACTS.DAL.phase_mainService
    Public Function Add(model As Model.phase_main) As Boolean
      Try

        Return _dal.Add(model)

      Catch ex As Exception
        Throw New Exception("phase_main.BLL.Add()::"& ex.Message)
      End Try
    End Function
   Public Function AddReturnId(model As Model.phase_main) As Integer
      Try

        Return _dal.AddReturnId(model)

      Catch ex As Exception
        Throw New Exception("phase_main.BLL.AddReturnId()::" & ex.Message)
      End Try
    End Function
  Public Function Delete(id As Integer) As Boolean
      Try
        Return _dal.Delete(id)
      Catch ex As Exception
        Throw New Exception("phase_main.BLL.Delete()::" & ex.Message)
      End Try
    End Function
   Public Function Update(model As Model.phase_main) As Boolean
      Try
        Return _dal.Update(model)
      Catch ex As Exception
        Throw New Exception("phase_main.BLL.Update()::" & ex.Message)
      End Try
    End Function
    Public Function SelectAll() As List(Of Model.phase_main)
      Try
        Return _dal.SelectAll()

      Catch ex As Exception
        Throw New Exception("phase_main.BLL.SelectAll()::" & ex.Message)
      End Try
    End Function
    Public Function SelectById(id As Integer) As Model.phase_main
       Try
        Return _dal.SelectById(id)
      Catch ex As Exception
        Throw New Exception("phase_main.BLL.SelectById()::" & ex.Message)
      End Try
    End Function
    Public Function SelectByPhase(phase As String) As FACTS.Model.phase_main
        Try
            Return _dal.SelectByPhase(phase)

        Catch ex As Exception
            Throw New Exception("phase_main.BLL.SelectByPhase()::" & ex.Message)
        End Try
    End Function

End Class
