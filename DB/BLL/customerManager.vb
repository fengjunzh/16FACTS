Imports System
Imports System.Collections.Generic

Public Class customerManager

    Private _dal As New FACTS.DAL.customerService
    Public Function Add(model As Model.customer) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("customer.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.customer) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("customer.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("customer.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.customer) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("customer.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.customer)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("customer.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.customer
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("customer.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByName(name As String) As FACTS.Model.customer
        Try
            Return _dal.SelectByName(name)
        Catch ex As Exception
            Throw New Exception("customer.BLL.SelectByName()::" & ex.Message)
        End Try
    End Function
End Class
