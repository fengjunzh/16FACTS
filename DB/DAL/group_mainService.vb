Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class group_mainService

    Public Function Add(model As FACTS.Model.group_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
    New SqlParameter("@spec_main_id", model.spec_main_id),
    New SqlParameter("@group_id", model.group_id),
    New SqlParameter("@group_name", model.group_name),
    New SqlParameter("@order_idx", model.order_idx),
    New SqlParameter("@descr", model.descr),
    New SqlParameter("@script", model.script),
    New SqlParameter("@message", model.message),
    New SqlParameter("@validity", model.validity),
    New SqlParameter("@validation_date", model.validation_date),
    New SqlParameter("@gen1", model.gen1),
    New SqlParameter("@gen2", model.gen2),
    New SqlParameter("@gen3", model.gen3)
  }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_group_main_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("group_main.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.group_main) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@spec_main_id", model.spec_main_id),
  New SqlParameter("@group_id", model.group_id),
  New SqlParameter("@group_name", model.group_name),
  New SqlParameter("@order_idx", model.order_idx),
  New SqlParameter("@descr", model.descr),
  New SqlParameter("@script", model.script),
  New SqlParameter("@message", model.message),
  New SqlParameter("@validity", model.validity),
  New SqlParameter("@validation_date", model.validation_date),
  New SqlParameter("@gen1", model.gen1),
  New SqlParameter("@gen2", model.gen2),
  New SqlParameter("@gen3", model.gen3)
}
            Return SqlHelper.runProcedureWithReturnValue("proc_group_main_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("group_main.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_group_main_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("group_main.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.group_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@id", model.id),
  New SqlParameter("@spec_main_id", model.spec_main_id),
  New SqlParameter("@group_id", model.group_id),
  New SqlParameter("@group_name", model.group_name),
  New SqlParameter("@order_idx", model.order_idx),
  New SqlParameter("@descr", model.descr),
  New SqlParameter("@script", model.script),
  New SqlParameter("@message", model.message),
  New SqlParameter("@validity", model.validity),
  New SqlParameter("@validation_date", model.validation_date),
  New SqlParameter("@gen1", model.gen1),
  New SqlParameter("@gen2", model.gen2),
  New SqlParameter("@gen3", model.gen3)
}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_group_main_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("group_main.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.group_main)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.group_main
            Dim mlist As New List(Of FACTS.Model.group_main)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_group_main_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.group_main
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("group_main.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.group_main
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.group_main
            Dim parameters As SqlParameter() = {
                              New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_group_main_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("group_main.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_group_main_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("group_main.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAllBySpecMainId(spec_main_id As Integer) As List(Of FACTS.Model.group_main)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.group_main
            Dim mlst As New List(Of FACTS.Model.group_main)
            dt = SelectByWhere("spec_main_id=" & spec_main_id).Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing
            For Each r As DataRow In dt.Rows
                model = DataRowToModel(r)
                mlst.Add(model)
            Next

            Return mlst

        Catch ex As Exception
            Throw New Exception("group_main.DAL.SelectAllBySpecMainId()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.group_main
        Try
            Dim model As New FACTS.Model.group_main
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("spec_main_id") Then If Not (IsDBNull(row("spec_main_id"))) Then model.spec_main_id = Convert.ToInt32(row("spec_main_id"))
            If row.Table.Columns.Contains("group_id") Then If Not (IsDBNull(row("group_id"))) Then model.group_id = Convert.ToInt32(row("group_id"))
            If row.Table.Columns.Contains("group_name") Then If Not (IsDBNull(row("group_name"))) Then model.group_name = Convert.ToString(row("group_name"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("descr") Then If Not (IsDBNull(row("descr"))) Then model.descr = Convert.ToString(row("descr"))
            If row.Table.Columns.Contains("script") Then If Not (IsDBNull(row("script"))) Then model.script = Convert.ToString(row("script"))
            If row.Table.Columns.Contains("message") Then If Not (IsDBNull(row("message"))) Then model.message = Convert.ToString(row("message"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation_date") Then If Not (IsDBNull(row("validation_date"))) Then model.validation_date = Convert.ToDateTime(row("validation_date"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("group_main.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
