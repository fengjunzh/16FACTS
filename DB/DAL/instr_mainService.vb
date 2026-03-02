Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class instr_mainService

    Public Function Add(model As FACTS.Model.instr_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
    New SqlParameter("@instr_model_id", model.instr_model_id),
    New SqlParameter("@serial_num", model.serial_num),
    New SqlParameter("@instr_num", model.instr_num),
    New SqlParameter("@fw_version", model.fw_version),
    New SqlParameter("@hw_version", model.hw_version),
    New SqlParameter("@entry_date", model.entry_date),
    New SqlParameter("@location", model.location),
    New SqlParameter("@status", model.status),
    New SqlParameter("@employee_id", model.employee_id),
        New SqlParameter("@instr_idn", model.instr_idn)
  }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_instr_main_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("instr_main.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.instr_main) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@instr_model_id", model.instr_model_id),
  New SqlParameter("@serial_num", model.serial_num),
  New SqlParameter("@instr_num", model.instr_num),
  New SqlParameter("@fw_version", model.fw_version),
  New SqlParameter("@hw_version", model.hw_version),
  New SqlParameter("@entry_date", model.entry_date),
  New SqlParameter("@location", model.location),
  New SqlParameter("@status", model.status),
  New SqlParameter("@employee_id", model.employee_id),
          New SqlParameter("@instr_idn", model.instr_idn)
}
            Return SqlHelper.runProcedureWithReturnValue("proc_instr_main_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("instr_main.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_instr_main_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("instr_main.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.instr_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@id", model.id),
  New SqlParameter("@instr_model_id", model.instr_model_id),
  New SqlParameter("@serial_num", model.serial_num),
  New SqlParameter("@instr_num", model.instr_num),
  New SqlParameter("@fw_version", model.fw_version),
  New SqlParameter("@hw_version", model.hw_version),
  New SqlParameter("@entry_date", model.entry_date),
  New SqlParameter("@location", model.location),
  New SqlParameter("@status", model.status),
  New SqlParameter("@employee_id", model.employee_id),
          New SqlParameter("@instr_idn", model.instr_idn)
}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_instr_main_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("instr_main.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.instr_main)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.instr_main
            Dim mlist As New List(Of FACTS.Model.instr_main)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_instr_main_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.instr_main
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("instr_main.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.instr_main
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.instr_main
            Dim parameters As SqlParameter() = {
                              New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_instr_main_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("instr_main.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
            New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_instr_main_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("instr_main.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByFilter(whereString As String) As List(Of Model.instr_main)
        Try
            Dim resp As New List(Of Model.instr_main)
            Dim respItem As Model.instr_main

            Dim dt As DataTable

            dt = SelectByWhere(whereString).Tables("dt")

            If dt Is Nothing Then Return Nothing

            If dt.Rows.Count = 0 Then Return Nothing

            For Each dr In dt.Rows
                respItem = New Model.instr_main
                respItem = DataRowToModel(dr)
                resp.Add(respItem)
            Next

            Return resp


        Catch ex As Exception
            Throw New Exception("controller.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.instr_main
        Try
            Dim model As New FACTS.Model.instr_main
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("instr_model_id") Then If Not (IsDBNull(row("instr_model_id"))) Then model.instr_model_id = Convert.ToInt32(row("instr_model_id"))
            If row.Table.Columns.Contains("serial_num") Then If Not (IsDBNull(row("serial_num"))) Then model.serial_num = Convert.ToString(row("serial_num"))
            If row.Table.Columns.Contains("instr_num") Then If Not (IsDBNull(row("instr_num"))) Then model.instr_num = Convert.ToString(row("instr_num"))
            If row.Table.Columns.Contains("fw_version") Then If Not (IsDBNull(row("fw_version"))) Then model.fw_version = Convert.ToString(row("fw_version"))
            If row.Table.Columns.Contains("hw_version") Then If Not (IsDBNull(row("hw_version"))) Then model.hw_version = Convert.ToString(row("hw_version"))
            If row.Table.Columns.Contains("entry_date") Then If Not (IsDBNull(row("entry_date"))) Then model.entry_date = Convert.ToDateTime(row("entry_date"))
            If row.Table.Columns.Contains("location") Then If Not (IsDBNull(row("location"))) Then model.location = Convert.ToString(row("location"))
            If row.Table.Columns.Contains("status") Then If Not (IsDBNull(row("status"))) Then model.status = Convert.ToString(row("status"))
            If row.Table.Columns.Contains("employee_id") Then If Not (IsDBNull(row("employee_id"))) Then model.employee_id = Convert.ToInt32(row("employee_id"))
            If row.Table.Columns.Contains("instr_idn") Then If Not (IsDBNull(row("instr_idn"))) Then model.fw_version = Convert.ToString(row("instr_idn"))
            Return model
        Catch ex As Exception
            Throw New Exception("instr_main.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
