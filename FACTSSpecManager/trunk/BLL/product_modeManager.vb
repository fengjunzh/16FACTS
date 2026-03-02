Imports System
Imports System.Collections.Generic

Public Class product_modeManager

    Private _dal As New FACTS.DAL.product_modeService
    Public Function Add(model As Model.product_mode) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("product_mode.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.product_mode) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("product_mode.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("product_mode.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.product_mode) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("product_mode.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.product_mode)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("product_mode.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProductMainIdAndModeId(product_main_id As Integer, mode_id As Integer) As Model.product_mode
        Try
            Return _dal.SelectByProductMainIdAndModeId(product_main_id, mode_id)

        Catch ex As Exception
            Throw New Exception("product_mode.BLL.SelectByProductMainIdAndModeId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.product_mode
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("product_mode.BLL.SelectById()::" & ex.Message)
        End Try
    End Function

End Class
