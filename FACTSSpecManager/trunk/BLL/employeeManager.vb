Imports System
Imports System.Collections.Generic

Public Class employeeManager

    Private _dal As New FACTS.DAL.employeeService
    Public Function Add(model As Model.employee) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("employee.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.employee) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("employee.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("employee.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.employee) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("employee.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.employee)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("employee.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.employee
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("employee.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByLoginname(login_name As String) As FACTS.Model.employee
        Try
            Return _dal.SelectByLoginname(login_name)
        Catch ex As Exception
            Throw New Exception("employee.BLL.SelectByLoginname()::" & ex.Message)
        End Try
    End Function

End Class
