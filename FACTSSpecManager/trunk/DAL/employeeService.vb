Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Public Class employeeService
    Public Function Add(model As FACTS.Model.employee) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@emp_num", model.emp_num),
        New SqlParameter("@name", model.name),
        New SqlParameter("@login_name", model.login_name),
        New SqlParameter("@permission", model.permission),
        New SqlParameter("@department", model.department),
        New SqlParameter("@pwd", model.pwd),
        New SqlParameter("@user_level", model.user_level),
        New SqlParameter("@factory_id", model.factory_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("employee.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.employee) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@emp_num", model.emp_num),
        New SqlParameter("@name", model.name),
        New SqlParameter("@login_name", model.login_name),
        New SqlParameter("@permission", model.permission),
        New SqlParameter("@department", model.department),
        New SqlParameter("@pwd", model.pwd),
        New SqlParameter("@user_level", model.user_level),
        New SqlParameter("@factory_id", model.factory_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_employee_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("employee.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("employee.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.employee) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@emp_num", model.emp_num),
        New SqlParameter("@name", model.name),
        New SqlParameter("@login_name", model.login_name),
        New SqlParameter("@permission", model.permission),
        New SqlParameter("@department", model.department),
        New SqlParameter("@pwd", model.pwd),
        New SqlParameter("@user_level", model.user_level),
        New SqlParameter("@factory_id", model.factory_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_employee_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("employee.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.employee)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.employee
            Dim mlist As New List(Of FACTS.Model.employee)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_employee_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.employee
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("employee.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.employee
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.employee
            Dim parameters As SqlParameter() = {
                        New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_employee_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("employee.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_employee_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("employee.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByLoginname(login_name As String) As FACTS.Model.employee
        Try

            Dim dt As DataTable

            Dim model As New FACTS.Model.employee

            dt = SelectByWhere("login_name='" & login_name & "'").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))

            Return model

        Catch ex As Exception
            Throw New Exception("employee.DAL.SelectByLoginname()::" & ex.Message)
        End Try
    End Function
    Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.employee
        Try
            Dim model As New FACTS.Model.employee
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("emp_num") Then If Not (IsDBNull(row("emp_num"))) Then model.emp_num = Convert.ToString(row("emp_num"))
            If row.Table.Columns.Contains("name") Then If Not (IsDBNull(row("name"))) Then model.name = Convert.ToString(row("name"))
            If row.Table.Columns.Contains("login_name") Then If Not (IsDBNull(row("login_name"))) Then model.login_name = Convert.ToString(row("login_name"))
            If row.Table.Columns.Contains("permission") Then If Not (IsDBNull(row("permission"))) Then model.permission = Convert.ToBoolean(row("permission"))
            If row.Table.Columns.Contains("department") Then If Not (IsDBNull(row("department"))) Then model.department = Convert.ToString(row("department"))
            If row.Table.Columns.Contains("pwd") Then If Not (IsDBNull(row("pwd"))) Then model.pwd = Convert.ToString(row("pwd"))
            If row.Table.Columns.Contains("user_level") Then If Not (IsDBNull(row("user_level"))) Then model.user_level = Convert.ToString(row("user_level"))
            If row.Table.Columns.Contains("factory_id") Then If Not (IsDBNull(row("factory_id"))) Then model.factory_id = Convert.ToInt32(row("factory_id"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("employee.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
