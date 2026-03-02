Imports System
Imports System.Collections.Generic

Public Class meas_instrManager
    Private _dal As New FACTS.DAL.meas_instrService
    Public Function Add(model As Model.meas_instr) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("meas_instr.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.meas_instr) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("meas_instr.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("meas_instr.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.meas_instr)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("meas_instr.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.meas_instr
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("meas_instr.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
End Class
