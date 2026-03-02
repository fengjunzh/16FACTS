Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Public Class cq_mode_phase_stationService
	Public Function SelectAllByMode(mode As String, validation As Boolean, validity As Boolean) As List(Of Model.cq_mode_phase_station)
		Try
			Dim dt As DataTable
			Dim resp As New List(Of FACTS.Model.cq_mode_phase_station)
			Dim respItem As FACTS.Model.cq_mode_phase_station


			Dim parameters As SqlParameter() = {
							  New SqlParameter("@mode", mode),
							  New SqlParameter("@validation", validation),
							  New SqlParameter("@validity", validity)}

			dt = SqlHelper.runProcedureWithDataset("proc_cq_phase_station_SelectByMode", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing

			For Each row As DataRow In dt.Rows
				'model = New CATS.Model.cq_criteria_detail
				respItem = DataRowToModel(row)
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("cq_mode_phase_station.DAL.SelectAllByMode()::" & ex.Message)
		End Try
	End Function
	Public Function DataRowToModel(row As DataRow) As FACTS.Model.cq_mode_phase_station
		Try
			Dim model As New FACTS.Model.cq_mode_phase_station
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.M_phase_station_main.id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("phase_station") Then If Not (IsDBNull(row("phase_station"))) Then model.M_phase_station_main.phase_station = Convert.ToString(row("phase_station"))
			If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.M_phase_station_main.order_idx = Convert.ToInt32(row("order_idx"))
			If row.Table.Columns.Contains("descr") Then If Not (IsDBNull(row("descr"))) Then model.M_phase_station_main.descr = Convert.ToString(row("descr"))
			If row.Table.Columns.Contains("ret_validity") Then If Not (IsDBNull(row("ret_validity"))) Then model.M_phase_station_main.ret_validity = Convert.ToBoolean(row("ret_validity"))
			If row.Table.Columns.Contains("meas_type") Then If Not (IsDBNull(row("meas_type"))) Then model.M_phase_station_main.meas_type = Convert.ToInt32(row("meas_type"))
			If row.Table.Columns.Contains("phase_station_func_id") Then If Not (IsDBNull(row("phase_station_func_id"))) Then model.M_phase_station_main.phase_station_func_id = Convert.ToInt32(row("phase_station_func_id"))
			If row.Table.Columns.Contains("phase_station_class_id") Then If Not (IsDBNull(row("phase_station_class_id"))) Then model.M_phase_station_main.phase_station_class_id = Convert.ToInt32(row("phase_station_class_id"))
			If row.Table.Columns.Contains("default_validity") Then If Not (IsDBNull(row("default_validity"))) Then model.M_phase_station_main.default_validity = Convert.ToBoolean(row("default_validity"))
			If row.Table.Columns.Contains("default_selection") Then If Not (IsDBNull(row("default_selection"))) Then model.M_mode_phase_station.default_selection = Convert.ToBoolean(row("default_selection"))
			If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.M_mode_phase_station.validity = Convert.ToBoolean(row("validity"))
			If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.M_mode_phase_station.validation = Convert.ToBoolean(row("validation"))

			Return model

		Catch ex As Exception
			Throw New Exception("cq_mode_phase_station.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function
End Class










