Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class employee_funcService

    Public Function Add(model As FACTS.Model.employee_func) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
    New SqlParameter("@employee_id", model.employee_id),
    New SqlParameter("@func_main_id", model.func_main_id)
  }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_func_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("employee_func.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.employee_func) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@employee_id", model.employee_id),
  New SqlParameter("@func_main_id", model.func_main_id)
}
            Return SqlHelper.runProcedureWithReturnValue("proc_employee_func_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("employee_func.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_func_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("employee_func.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function DeleteByEmployeeId(employee_id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@employee_id", employee_id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_func_DeleteByEmployeeId", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("employee_func.DAL.DeleteByEmployeeId()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.employee_func) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@id", model.id),
  New SqlParameter("@employee_id", model.employee_id),
  New SqlParameter("@func_main_id", model.func_main_id)
}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_func_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("employee_func.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.employee_func)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.employee_func
            Dim mlist As New List(Of FACTS.Model.employee_func)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_employee_func_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.employee_func
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("employee_func.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.employee_func
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.employee_func
            Dim parameters As SqlParameter() = {
                              New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_employee_func_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("employee_func.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_employee_func_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("employee_func.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.employee_func
        Try
            Dim model As New FACTS.Model.employee_func
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("employee_id") Then If Not (IsDBNull(row("employee_id"))) Then model.employee_id = Convert.ToInt32(row("employee_id"))
            If row.Table.Columns.Contains("func_main_id") Then If Not (IsDBNull(row("func_main_id"))) Then model.func_main_id = Convert.ToInt32(row("func_main_id"))
            Return model
        Catch ex As Exception
            Throw New Exception("employee_func.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
