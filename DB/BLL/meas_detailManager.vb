Imports System
Imports System.Collections.Generic

Public Class meas_detailManager
    Private _dal As New FACTS.DAL.meas_detailService
    Public Function Add(model As Model.meas_detail) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.meas_detail) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.meas_detail) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.meas_detail)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectBy_meas_phase_id(meas_phase_id As Integer) As List(Of Model.meas_detail)
        Try
            Return _dal.SelectBy_meas_phase_id(meas_phase_id)

        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.SelectBy_meas_phase_id()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.meas_detail
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectBy_meas_group_id(meas_group_id As Integer) As List(Of FACTS.Model.meas_detail)
        Try
            Return _dal.SelectBy_meas_group_id(meas_group_id)
        Catch ex As Exception
            Throw New Exception("meas_detail.BLL.SelectBy_meas_group_id()::" & ex.Message)
        End Try
    End Function
End Class
