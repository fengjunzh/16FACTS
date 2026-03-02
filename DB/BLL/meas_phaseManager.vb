Imports System
Imports System.Collections.Generic

Public Class meas_phaseManager

    Private _dal As New FACTS.DAL.meas_phaseService
    Public Function Add(model As Model.meas_phase) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.meas_phase) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.meas_phase) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.meas_phase)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.meas_phase
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByControllerId(controller_id As Integer) As List(Of FACTS.Model.meas_phase)
        Try
            Return _dal.SelectByControllerId(controller_id)
        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.SelectByControllerId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByMeasMainId(meas_main_id As Integer) As List(Of FACTS.Model.meas_phase)
        Try
            Return _dal.SelectByMeasMainId(meas_main_id)
        Catch ex As Exception
            Throw New Exception("meas_phase.BLL.SelectByMeasMainId()::" & ex.Message)
        End Try
    End Function
End Class
