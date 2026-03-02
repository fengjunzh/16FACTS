Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class instr_modelService

    Public Function Add(model As FACTS.Model.instr_model) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
    New SqlParameter("@name", model.name),
    New SqlParameter("@model_num", model.model_num),
    New SqlParameter("@start_freq", model.start_freq),
    New SqlParameter("@stop_freq", model.stop_freq),
    New SqlParameter("@type", model.type),
    New SqlParameter("@instr_vendor_id", model.instr_vendor_id)
  }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_instr_model_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("instr_model.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.instr_model) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@name", model.name),
  New SqlParameter("@model_num", model.model_num),
  New SqlParameter("@start_freq", model.start_freq),
  New SqlParameter("@stop_freq", model.stop_freq),
  New SqlParameter("@type", model.type),
  New SqlParameter("@instr_vendor_id", model.instr_vendor_id)
}
            Return SqlHelper.runProcedureWithReturnValue("proc_instr_model_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("instr_model.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_instr_model_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("instr_model.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.instr_model) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@id", model.id),
  New SqlParameter("@name", model.name),
  New SqlParameter("@model_num", model.model_num),
  New SqlParameter("@start_freq", model.start_freq),
  New SqlParameter("@stop_freq", model.stop_freq),
  New SqlParameter("@type", model.type),
  New SqlParameter("@instr_vendor_id", model.instr_vendor_id)
}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_instr_model_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("instr_model.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.instr_model)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.instr_model
            Dim mlist As New List(Of FACTS.Model.instr_model)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_instr_model_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.instr_model
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("instr_model.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.instr_model
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.instr_model
            Dim parameters As SqlParameter() = {
                              New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_instr_model_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("instr_model.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_instr_model_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("instr_model.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.instr_model
        Try
            Dim model As New FACTS.Model.instr_model
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("name") Then If Not (IsDBNull(row("name"))) Then model.name = Convert.ToString(row("name"))
            If row.Table.Columns.Contains("model_num") Then If Not (IsDBNull(row("model_num"))) Then model.model_num = Convert.ToString(row("model_num"))
            If row.Table.Columns.Contains("start_freq") Then If Not (IsDBNull(row("start_freq"))) Then model.start_freq = Convert.ToDecimal(row("start_freq"))
            If row.Table.Columns.Contains("stop_freq") Then If Not (IsDBNull(row("stop_freq"))) Then model.stop_freq = Convert.ToDecimal(row("stop_freq"))
            If row.Table.Columns.Contains("type") Then If Not (IsDBNull(row("type"))) Then model.type = Convert.ToString(row("type"))
            If row.Table.Columns.Contains("instr_vendor_id") Then If Not (IsDBNull(row("instr_vendor_id"))) Then model.instr_vendor_id = Convert.ToInt32(row("instr_vendor_id"))
            Return model
        Catch ex As Exception
            Throw New Exception("instr_model.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
