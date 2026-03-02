Imports System
Imports System.Collections.Generic
Public Class controllerManager

    Private _dal As New FACTS.DAL.controllerService
    Public Function Add(model As Model.controller) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("controller.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.controller) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("controller.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("controller.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.controller) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("controller.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.controller)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("controller.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.controller
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("controller.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByName(name As String) As Model.controller
        Try
            Dim resp As New List(Of Model.controller)
            resp = _dal.SelectByFilter("Name ='" & name & "'")
            If resp Is Nothing OrElse resp.Count = 0 Then Return Nothing
            Return resp(0)
        Catch ex As Exception
            Throw New Exception("controller.BLL.SelectByName()::" & ex.Message)
        End Try
    End Function
End Class
