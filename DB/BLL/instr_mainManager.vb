Imports System
Imports System.Collections.Generic

Public Class instr_mainManager

    Private _dal As New FACTS.DAL.instr_mainService
    Public Function Add(model As Model.instr_main) As Boolean
        Try

            Return _dal.Add(model)

        Catch ex As Exception
            Throw New Exception("instr_main.BLL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As Model.instr_main) As Integer
        Try

            Return _dal.AddReturnId(model)

        Catch ex As Exception
            Throw New Exception("instr_main.BLL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Return _dal.Delete(id)
        Catch ex As Exception
            Throw New Exception("instr_main.BLL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As Model.instr_main) As Boolean
        Try
            Return _dal.Update(model)
        Catch ex As Exception
            Throw New Exception("instr_main.BLL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of Model.instr_main)
        Try
            Return _dal.SelectAll()

        Catch ex As Exception
            Throw New Exception("instr_main.BLL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As Model.instr_main
        Try
            Return _dal.SelectById(id)
        Catch ex As Exception
            Throw New Exception("instr_main.BLL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectBySN(sn As String) As List(Of Model.instr_main)
        Try
            Dim resp As New List(Of Model.instr_main)
            resp = _dal.SelectByFilter("serial_num ='" & sn & "'")
            If resp Is Nothing OrElse resp.Count = 0 Then Return Nothing
            'If resp.Count > 1 Then Throw New Exception("Find instrument (sn=" & sn & " ) -- more than one")
            'Return resp(0)
            Return resp

        Catch ex As Exception
            Throw New Exception("instr_main.BLL.SelectBySN()::" & ex.Message)
        End Try
    End Function
End Class
