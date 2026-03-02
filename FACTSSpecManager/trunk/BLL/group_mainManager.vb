Imports System
Imports System.Collections.Generic
Imports FACTS

Public Class group_mainManager

    Private _dal As New FACTS.DAL.group_mainService
    Public Function Add(model As Model.group_main) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("group_main.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.group_main) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("group_main.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("group_main.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.group_main) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("group_main.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.group_main)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("group_main.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.group_main
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("group_main.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAllBySpecMainId(spec_main_id As Integer) As List(Of FACTS.Model.group_main)
        Try
            Return _dal.SelectAllBySpecMainId(spec_main_id)
        Catch ex As Exception
            Throw New Exception("group_main.BLL.SelectAllBySpecMainId()::" & ex.Message)
        End Try
    End Function
End Class
