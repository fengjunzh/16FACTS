Imports System
Imports System.Collections.Generic
Imports FACTS

Public Class mode_specManager

    Private _dal As New FACTS.DAL.mode_specService
    Public Function Add(model As Model.mode_spec) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.mode_spec) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.mode_spec) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.mode_spec)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.mode_spec
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(product_mode_id As Integer, spec_main_id As Integer) As FACTS.Model.mode_spec
        Try
            Return _dal.SelectById(product_mode_id, spec_main_id)

        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.SelectById(product_mode_id,spec_main_id)::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProductModeId(product_mode_id As Integer) As List(Of FACTS.Model.mode_spec)
        Try
            Return _dal.SelectByProductModeId(product_mode_id)

        Catch ex As Exception
            Throw New Exception("mode_spec.BLL.SelectByProductModeId(product_mode_id)::" & ex.Message)
        End Try
    End Function
End Class
