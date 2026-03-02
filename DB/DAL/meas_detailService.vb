Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class meas_detailService

    Public Function Add(model As FACTS.Model.meas_detail) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
    New SqlParameter("@meas_phase_id", model.meas_phase_id),
    New SqlParameter("@meas_group_id", model.meas_group_id),
    New SqlParameter("@order_idx", model.order_idx),
    New SqlParameter("@spec_detail_id", model.spec_detail_id),
    New SqlParameter("@meas_value", model.meas_value),
    New SqlParameter("@meas_string", model.meas_string),
    New SqlParameter("@meas_status", model.meas_status),
    New SqlParameter("@plot_path", model.plot_path),
    New SqlParameter("@trace_path", model.trace_path),
    New SqlParameter("@test_idx", model.test_idx),
    New SqlParameter("@last_test_flag", model.last_test_flag),
    New SqlParameter("@gen1", model.gen1),
    New SqlParameter("@gen2", model.gen2),
    New SqlParameter("@gen3", model.gen3)
  }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_detail_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.meas_detail) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@meas_phase_id", model.meas_phase_id),
  New SqlParameter("@meas_group_id", model.meas_group_id),
  New SqlParameter("@order_idx", model.order_idx),
  New SqlParameter("@spec_detail_id", model.spec_detail_id),
  New SqlParameter("@meas_value", model.meas_value),
  New SqlParameter("@meas_string", model.meas_string),
  New SqlParameter("@meas_status", model.meas_status),
  New SqlParameter("@plot_path", model.plot_path),
  New SqlParameter("@trace_path", model.trace_path),
  New SqlParameter("@test_idx", model.test_idx),
  New SqlParameter("@last_test_flag", model.last_test_flag),
  New SqlParameter("@gen1", model.gen1),
  New SqlParameter("@gen2", model.gen2),
  New SqlParameter("@gen3", model.gen3)
}
            Return SqlHelper.runProcedureWithReturnValue("proc_meas_detail_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
    Try
      Dim rowsAffected As Integer
      Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

      rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_detail_DeleteRow", parameters)
      Return IIf(rowsAffected > 0, True, False)

    Catch ex As Exception
      Throw New Exception("meas_detail.DAL.Delete()::" & ex.Message)
    End Try
  End Function
    Public Function Update(model As FACTS.Model.meas_detail) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@id", model.id),
  New SqlParameter("@meas_phase_id", model.meas_phase_id),
  New SqlParameter("@meas_group_id", model.meas_group_id),
  New SqlParameter("@order_idx", model.order_idx),
  New SqlParameter("@spec_detail_id", model.spec_detail_id),
  New SqlParameter("@meas_value", model.meas_value),
  New SqlParameter("@meas_string", model.meas_string),
  New SqlParameter("@meas_status", model.meas_status),
  New SqlParameter("@plot_path", model.plot_path),
  New SqlParameter("@trace_path", model.trace_path),
  New SqlParameter("@test_idx", model.test_idx),
  New SqlParameter("@last_test_flag", model.last_test_flag),
  New SqlParameter("@gen1", model.gen1),
  New SqlParameter("@gen2", model.gen2),
  New SqlParameter("@gen3", model.gen3)
}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_detail_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.meas_detail)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_detail
            Dim mlist As New List(Of FACTS.Model.meas_detail)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_meas_detail_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_detail
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function

    Public Function SelectBy_meas_phase_id(id As Integer) As List(Of FACTS.Model.meas_detail)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_detail
            Dim mlist As New List(Of FACTS.Model.meas_detail)

            dt = SelectByWhere("meas_phase_id = " & id).Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_detail
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.SelectBy_meas_phase_id()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.meas_detail
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.meas_detail
            Dim parameters As SqlParameter() = {
                              New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_meas_detail_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
    Try
      Dim ds As DataSet

      Dim parameters As SqlParameter() = {
            New SqlParameter("@where", whereString)}

      ds = SqlHelper.runProcedureWithDataset("proc_meas_detail_SelectByWhere", parameters, "dt")

      Return ds

    Catch ex As Exception
      Throw New Exception("meas_detail.DAL.SelectByWhere()::" & ex.Message)
    End Try
  End Function
    Public Function SelectBy_meas_group_id(meas_group_id As Integer) As List(Of FACTS.Model.meas_detail)
        Try
            Dim resp As New List(Of FACTS.Model.meas_detail)
            Dim respItem As FACTS.Model.meas_detail
            Dim dt As DataTable


            dt = SelectByWhere("meas_group_id=" & meas_group_id).Tables("dt")

            If dt Is Nothing Then Return Nothing
            If dt.Rows.Count = 0 Then Return Nothing

            For Each r As DataRow In dt.Rows
                respItem = New FACTS.Model.meas_detail
                respItem = DataRowToModel(r)
                resp.Add(respItem)
            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("meas_group.DAL.SelectBy_meas_group_id()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.meas_detail
        Try
            Dim model As New FACTS.Model.meas_detail
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("meas_phase_id") Then If Not (IsDBNull(row("meas_phase_id"))) Then model.meas_phase_id = Convert.ToInt32(row("meas_phase_id"))
            If row.Table.Columns.Contains("meas_group_id") Then If Not (IsDBNull(row("meas_group_id"))) Then model.meas_group_id = Convert.ToInt32(row("meas_group_id"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("spec_detail_id") Then If Not (IsDBNull(row("spec_detail_id"))) Then model.spec_detail_id = Convert.ToInt32(row("spec_detail_id"))
            If row.Table.Columns.Contains("meas_value") Then If Not (IsDBNull(row("meas_value"))) Then model.meas_value = Convert.ToDecimal(row("meas_value"))
            If row.Table.Columns.Contains("meas_string") Then If Not (IsDBNull(row("meas_string"))) Then model.meas_string = Convert.ToString(row("meas_string"))
            If row.Table.Columns.Contains("meas_status") Then If Not (IsDBNull(row("meas_status"))) Then model.meas_status = Convert.ToString(row("meas_status"))
            If row.Table.Columns.Contains("plot_path") Then If Not (IsDBNull(row("plot_path"))) Then model.plot_path = Convert.ToString(row("plot_path"))
            If row.Table.Columns.Contains("trace_path") Then If Not (IsDBNull(row("trace_path"))) Then model.trace_path = Convert.ToString(row("trace_path"))
            If row.Table.Columns.Contains("test_idx") Then If Not (IsDBNull(row("test_idx"))) Then model.test_idx = Convert.ToInt32(row("test_idx"))
            If row.Table.Columns.Contains("last_test_flag") Then If Not (IsDBNull(row("last_test_flag"))) Then model.last_test_flag = Convert.ToBoolean(row("last_test_flag"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("meas_detail.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function

End Class
