Imports System
Imports System.Collections.Generic
Public Class cq_employee_funcManager
    Private _dal As New FACTS.DAL.cq_employee_funcSerivice
    Public Function SelectAllByLoginName(login_name As String) As List(Of Model.cq_employee_func)
    Try
      Return _dal.SelectAllByLoginName(login_name)
    Catch ex As Exception
      Throw New Exception("cq_employee_funcManager.BLL.SelectAllByLoginName()::" & ex.Message)
    End Try
  End Function
End Class
