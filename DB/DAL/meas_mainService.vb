Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class meas_mainService

    Public Function Add(model As FACTS.Model.meas_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@product_sn_id", model.product_sn_id),
          New SqlParameter("@product_mode_id", model.product_mode_id),
          New SqlParameter("@mode", model.mode),
          New SqlParameter("@start_datetime", model.start_datetime),
          New SqlParameter("@stop_datetime", model.stop_datetime),
          New SqlParameter("@duration_minute", model.duration_minute),
          New SqlParameter("@meas_status", model.meas_status),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3)
        }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_main_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_main.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.meas_main) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_sn_id", model.product_sn_id),
        New SqlParameter("@product_mode_id", model.product_mode_id),
        New SqlParameter("@mode", model.mode),
        New SqlParameter("@start_datetime", model.start_datetime),
        New SqlParameter("@stop_datetime", model.stop_datetime),
        New SqlParameter("@duration_minute", model.duration_minute),
        New SqlParameter("@meas_status", model.meas_status),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_meas_main_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("meas_main.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_main_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("meas_main.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.meas_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@product_sn_id", model.product_sn_id),
        New SqlParameter("@product_mode_id", model.product_mode_id),
        New SqlParameter("@mode", model.mode),
        New SqlParameter("@start_datetime", model.start_datetime),
        New SqlParameter("@stop_datetime", model.stop_datetime),
        New SqlParameter("@duration_minute", model.duration_minute),
        New SqlParameter("@meas_status", model.meas_status),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_main_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_main.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.meas_main)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_main
            Dim mlist As New List(Of FACTS.Model.meas_main)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_meas_main_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_main
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_main.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.meas_main
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.meas_main
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_meas_main_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("meas_main.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProdSnId(id As Integer) As List(Of FACTS.Model.meas_main)
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.meas_main
            Dim mlist As New List(Of FACTS.Model.meas_main)
            dt = SelectByWhere("product_sn_id = " & id).Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing
            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_main
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_main.DAL.SelectByProdSnId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_meas_main_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("meas_main.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.meas_main
        Try
            Dim model As New FACTS.Model.meas_main
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("product_sn_id") Then If Not (IsDBNull(row("product_sn_id"))) Then model.product_sn_id = Convert.ToInt32(row("product_sn_id"))
            If row.Table.Columns.Contains("product_mode_id") Then If Not (IsDBNull(row("product_mode_id"))) Then model.product_mode_id = Convert.ToInt32(row("product_mode_id"))
            If row.Table.Columns.Contains("mode") Then If Not (IsDBNull(row("mode"))) Then model.mode = Convert.ToString(row("mode"))
            If row.Table.Columns.Contains("start_datetime") Then If Not (IsDBNull(row("start_datetime"))) Then model.start_datetime = Convert.ToDateTime(row("start_datetime"))
            If row.Table.Columns.Contains("stop_datetime") Then If Not (IsDBNull(row("stop_datetime"))) Then model.stop_datetime = Convert.ToDateTime(row("stop_datetime"))
            If row.Table.Columns.Contains("duration_minute") Then If Not (IsDBNull(row("duration_minute"))) Then model.duration_minute = Convert.ToInt32(row("duration_minute"))
            If row.Table.Columns.Contains("meas_status") Then If Not (IsDBNull(row("meas_status"))) Then model.meas_status = Convert.ToString(row("meas_status"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("meas_main.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
