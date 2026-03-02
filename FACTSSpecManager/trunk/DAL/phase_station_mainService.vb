Option Strict Off
Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Partial Public Class phase_station_mainService
    Public Function Add(model As FACTS.Model.phase_station_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@order_idx", model.order_idx),
          New SqlParameter("@phase_station", model.phase_station),
          New SqlParameter("@descr", model.descr),
          New SqlParameter("@ret_validity", model.ret_validity),
          New SqlParameter("@meas_type", model.meas_type),
          New SqlParameter("@phase_station_func_id", model.phase_station_func_id),
          New SqlParameter("@phase_station_class_id", model.phase_station_class_id),
          New SqlParameter("@default_validity", model.default_validity),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@validation", model.validation),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3)
              }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_phase_station_main_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.phase_station_main) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@phase_station", model.phase_station),
        New SqlParameter("@descr", model.descr),
        New SqlParameter("@ret_validity", model.ret_validity),
        New SqlParameter("@meas_type", model.meas_type),
        New SqlParameter("@phase_station_func_id", model.phase_station_func_id),
        New SqlParameter("@phase_station_class_id", model.phase_station_class_id),
        New SqlParameter("@default_validity", model.default_validity),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }
            Return SqlHelper.runProcedureWithReturnValue("proc_phase_station_main_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_phase_station_main_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.phase_station_main) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@phase_station", model.phase_station),
        New SqlParameter("@descr", model.descr),
        New SqlParameter("@ret_validity", model.ret_validity),
        New SqlParameter("@meas_type", model.meas_type),
        New SqlParameter("@phase_station_func_id", model.phase_station_func_id),
        New SqlParameter("@phase_station_class_id", model.phase_station_class_id),
        New SqlParameter("@default_validity", model.default_validity),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_phase_station_main_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.phase_station_main)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.phase_station_main
            Dim mlist As New List(Of FACTS.Model.phase_station_main)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_phase_station_main_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.phase_station_main
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.phase_station_main
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.phase_station_main
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_phase_station_main_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByPhaseStationName(name As String) As FACTS.Model.phase_station_main
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.phase_station_main
            dt = SelectByWhere("phase_station = '" & name & "'").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.SelectByPhaseStationName()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_phase_station_main_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.phase_station_main
        Try
            Dim model As New FACTS.Model.phase_station_main
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("phase_station") Then If Not (IsDBNull(row("phase_station"))) Then model.phase_station = Convert.ToString(row("phase_station"))
            If row.Table.Columns.Contains("descr") Then If Not (IsDBNull(row("descr"))) Then model.descr = Convert.ToString(row("descr"))
            If row.Table.Columns.Contains("ret_validity") Then If Not (IsDBNull(row("ret_validity"))) Then model.ret_validity = Convert.ToBoolean(row("ret_validity"))
            If row.Table.Columns.Contains("meas_type") Then If Not (IsDBNull(row("meas_type"))) Then model.meas_type = Convert.ToInt32(row("meas_type"))
            If row.Table.Columns.Contains("phase_station_func_id") Then If Not (IsDBNull(row("phase_station_func_id"))) Then model.phase_station_func_id = Convert.ToInt32(row("phase_station_func_id"))
            If row.Table.Columns.Contains("phase_station_class_id") Then If Not (IsDBNull(row("phase_station_class_id"))) Then model.phase_station_class_id = Convert.ToInt32(row("phase_station_class_id"))
            If row.Table.Columns.Contains("default_validity") Then If Not (IsDBNull(row("default_validity"))) Then model.default_validity = Convert.ToBoolean(row("default_validity"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.validation = Convert.ToBoolean(row("validation"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("phase_station_main.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
