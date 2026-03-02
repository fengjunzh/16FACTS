Option Strict Off
Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Partial Public Class product_mode_phase_stationService
    Public Function Add(model As FACTS.Model.product_mode_phase_station) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@product_mode_id", model.product_mode_id),
          New SqlParameter("@phase_station_main_id", model.phase_station_main_id),
          New SqlParameter("@descr", model.descr),
          New SqlParameter("@order_idx", model.order_idx),
          New SqlParameter("@default_selection", model.default_selection),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@validation", model.validation),
          New SqlParameter("@validation_date", model.validation_date),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3)
              }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_mode_phase_station_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.product_mode_phase_station) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_mode_id", model.product_mode_id),
        New SqlParameter("@phase_station_main_id", model.phase_station_main_id),
        New SqlParameter("@descr", model.descr),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@default_selection", model.default_selection),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }
            Return SqlHelper.runProcedureWithReturnValue("proc_product_mode_phase_station_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_mode_phase_station_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.product_mode_phase_station) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@product_mode_id", model.product_mode_id),
        New SqlParameter("@phase_station_main_id", model.phase_station_main_id),
        New SqlParameter("@descr", model.descr),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@default_selection", model.default_selection),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_mode_phase_station_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.product_mode_phase_station)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.product_mode_phase_station
            Dim mlist As New List(Of FACTS.Model.product_mode_phase_station)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_product_mode_phase_station_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.product_mode_phase_station
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.product_mode_phase_station
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_mode_phase_station
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_product_mode_phase_station_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_product_mode_phase_station_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.product_mode_phase_station
        Try
            Dim model As New FACTS.Model.product_mode_phase_station
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("product_mode_id") Then If Not (IsDBNull(row("product_mode_id"))) Then model.product_mode_id = Convert.ToInt32(row("product_mode_id"))
            If row.Table.Columns.Contains("phase_station_main_id") Then If Not (IsDBNull(row("phase_station_main_id"))) Then model.phase_station_main_id = Convert.ToInt32(row("phase_station_main_id"))
            If row.Table.Columns.Contains("descr") Then If Not (IsDBNull(row("descr"))) Then model.descr = Convert.ToString(row("descr"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("default_selection") Then If Not (IsDBNull(row("default_selection"))) Then model.default_selection = Convert.ToBoolean(row("default_selection"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.validation = Convert.ToBoolean(row("validation"))
            If row.Table.Columns.Contains("validation_date") Then If Not (IsDBNull(row("validation_date"))) Then model.validation_date = Convert.ToDateTime(row("validation_date"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("product_mode_phase_station.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
