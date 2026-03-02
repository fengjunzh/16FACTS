Imports System
Imports System.Collections.Generic

Public Class meas_mainManager

    Private _dal As New FACTS.DAL.meas_mainService
    Public Function Add(model As Model.meas_main) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("meas_main.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.meas_main) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("meas_main.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("meas_main.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.meas_main) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("meas_main.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.meas_main)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("meas_main.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.meas_main
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("meas_main.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProdSnId(id As Integer) As List(Of Model.meas_main)
        Try
            Return _dal.SelectByProdSnId(id)
        Catch ex As Exception
            Throw New Exception("meas_main.BLL.SelectByProdSnId()::" & ex.Message)
        End Try
    End Function
End Class
