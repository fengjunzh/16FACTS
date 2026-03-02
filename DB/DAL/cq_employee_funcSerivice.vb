Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Public Class cq_employee_funcSerivice
    Public Function SelectAllByLoginName(login_name As String) As List(Of Model.cq_employee_func)
        Try
            Dim dt As DataTable
            Dim resp As New List(Of FACTS.Model.cq_employee_func)
            Dim respItem As FACTS.Model.cq_employee_func

            Dim parameters As SqlParameter() = {
                              New SqlParameter("@login_name", login_name)}

            dt = SqlHelper.runProcedureWithDataset("proc_cq_employee_func_SelectByLoginName", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                respItem = DataRowToModel(row)
                resp.Add(respItem)
            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("cq_employee_funcSerivice.DAL.SelectAllByLoginName()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.cq_employee_func
        Try
            Dim model As New FACTS.Model.cq_employee_func

            If IsNothing(row) Then Return Nothing

            model.M_employee = FACTS.DAL.employeeService.DataRowToModel(row)
            If row.Table.Columns.Contains("func_main_id") Then
                If Not (IsDBNull(row("func_main_id"))) Then model.func_main_id = Convert.ToInt32(row("func_main_id"))
                Dim fmBll As New FACTS.DAL.func_mainService

                model.M_func_main = fmBll.SelectById(model.func_main_id)
            Else
                model.M_func_main = Nothing
            End If

            Return model

        Catch ex As Exception
            Throw New Exception("cq_employee_funcSerivice.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
