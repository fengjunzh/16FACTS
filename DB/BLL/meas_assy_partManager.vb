Imports System
Imports System.Collections.Generic


Public Class meas_assy_partManager

    Private _dal As New FACTS.DAL.meas_assy_partService
    Public Function Add(model As Model.meas_assy_part) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.meas_assy_part) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.meas_assy_part) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.meas_assy_part)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByMeasPhaseId(id As Integer) As List(Of Model.meas_assy_part)
        Try
            Return _dal.SelectByMeasPhaseId(id)

        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.SelectByMeasPhaseId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.meas_assy_part
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("meas_assy_part.BLL.SelectById()::" & ex.Message)
        End Try
    End Function

End Class
