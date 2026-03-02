Imports System
Imports System.Collections.Generic

Public Class phase_station_mainManager
    Private _dal As New FACTS.DAL.phase_station_mainService
    Public Function Add(model As Model.phase_station_main) As Boolean
      Try

        Return _dal.Add(model)

      Catch ex As Exception
        Throw New Exception("phase_station_main.BLL.Add()::"& ex.Message)
      End Try
    End Function
   Public Function AddReturnId(model As Model.phase_station_main) As Integer
      Try

        Return _dal.AddReturnId(model)

      Catch ex As Exception
        Throw New Exception("phase_station_main.BLL.AddReturnId()::" & ex.Message)
      End Try
    End Function
  Public Function Delete(id As Integer) As Boolean
      Try
        Return _dal.Delete(id)
      Catch ex As Exception
        Throw New Exception("phase_station_main.BLL.Delete()::" & ex.Message)
      End Try
    End Function
   Public Function Update(model As Model.phase_station_main) As Boolean
      Try
        Return _dal.Update(model)
      Catch ex As Exception
        Throw New Exception("phase_station_main.BLL.Update()::" & ex.Message)
      End Try
    End Function
    Public Function SelectAll() As List(Of Model.phase_station_main)
      Try
        Return _dal.SelectAll()

      Catch ex As Exception
        Throw New Exception("phase_station_main.BLL.SelectAll()::" & ex.Message)
      End Try
    End Function
    Public Function SelectById(id As Integer) As Model.phase_station_main
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("phase_station_main.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByPhaseStationName(name As String) As Model.phase_station_main
        Try
            Return _dal.SelectByPhaseStationName(name)
        Catch ex As Exception
            Throw New Exception("phase_station_main.BLL.SelectByPhaseStationName()::" & ex.Message)
        End Try
    End Function

End Class
