Imports System
Imports System.Collections.Generic
Public Class cq_phases_statusManager

    Private _dal As New FACTS.DAL.cq_phases_statusService
    Public Function SelectAll(product As String, serialNumber As String, mode As String) As List(Of Model.cq_phases_status)
        Try

            Return _dal.SelectAll(product, serialNumber, mode)

        Catch ex As Exception
            Throw New Exception("cq_phases_statusManager.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll(product As String, serialNumber As String, mode As String, phase_station_main_id As Integer) As List(Of FACTS.Model.cq_phases_status)
        Try
            Return _dal.SelectAll(product, serialNumber, mode, phase_station_main_id)

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByPhase(product As String, serialNumber As String, mode As String, phase As String) As FACTS.Model.cq_phases_status
        Try

            Return _dal.SelectByPhase(product, serialNumber, mode, phase)

        Catch ex As Exception
            Throw New Exception("cq_phases_statusManager.BLL.SelectByPhase()::" & ex.Message)
        End Try
    End Function
    Public Function SelectMostRecentPhaseStatus(product As String, serialNumber As String, mode As String, phase_station_main_id As Integer) As List(Of FACTS.Model.cq_phases_status)
        Try
            Return _dal.SelectMostRecentPhaseStatus(product, serialNumber, mode, phase_station_main_id)

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.SelectMostRecentPhaseStatus()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAllPhaseStatusBySn(serialNumber As String, factory As String, testMode As String, phaseStation As String) As List(Of FACTS.Model.cq_phases_status)
        Try
            Return _dal.SelectAllPhaseStatusBySn(serialNumber, factory, testMode, phaseStation)

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.SelectAllPhaseStatusBySn()::" & ex.Message)
        End Try
    End Function
End Class
