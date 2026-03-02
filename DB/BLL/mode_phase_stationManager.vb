Imports System
Imports System.Collections.Generic

Public Class mode_phase_stationManager
    Private _dal As New FACTS.DAL.mode_phase_stationService
    Public Function Add(model As Model.mode_phase_station) As Boolean
      Try

        Return _dal.Add(model)

      Catch ex As Exception
        Throw New Exception("mode_phase_station.BLL.Add()::"& ex.Message)
      End Try
    End Function
   Public Function AddReturnId(model As Model.mode_phase_station) As Integer
      Try

        Return _dal.AddReturnId(model)

      Catch ex As Exception
        Throw New Exception("mode_phase_station.BLL.AddReturnId()::" & ex.Message)
      End Try
    End Function
  Public Function Delete(id As Integer) As Boolean
      Try
        Return _dal.Delete(id)
      Catch ex As Exception
        Throw New Exception("mode_phase_station.BLL.Delete()::" & ex.Message)
      End Try
    End Function
   Public Function Update(model As Model.mode_phase_station) As Boolean
      Try
        Return _dal.Update(model)
      Catch ex As Exception
        Throw New Exception("mode_phase_station.BLL.Update()::" & ex.Message)
      End Try
    End Function
    Public Function SelectAll() As List(Of Model.mode_phase_station)
      Try
        Return _dal.SelectAll()

      Catch ex As Exception
        Throw New Exception("mode_phase_station.BLL.SelectAll()::" & ex.Message)
      End Try
    End Function
    Public Function SelectById(id As Integer) As Model.mode_phase_station
       Try
        Return _dal.SelectById(id)
      Catch ex As Exception
        Throw New Exception("mode_phase_station.BLL.SelectById()::" & ex.Message)
      End Try
    End Function

  End Class
