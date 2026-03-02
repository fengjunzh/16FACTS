Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class meas_phaseService
	Public Function Add(model As FACTS.Model.meas_phase) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {
			  New SqlParameter("@meas_main_id", model.meas_main_id),
			  New SqlParameter("@spec_main_id", model.spec_main_id),
			  New SqlParameter("@phase_main_id", model.phase_main_id),
			  New SqlParameter("@phase", model.phase),
			  New SqlParameter("@phase_status", model.phase_status),
			  New SqlParameter("@software_rev", model.software_rev),
			  New SqlParameter("@employee_id", model.employee_id),
			  New SqlParameter("@controller_id", model.controller_id),
			  New SqlParameter("@factory_id", model.factory_id),
			  New SqlParameter("@forced_status", model.forced_status),
			  New SqlParameter("@start_datetime", model.start_datetime),
			  New SqlParameter("@stop_datetime", model.stop_datetime),
			  New SqlParameter("@conn_time", model.conn_time),
			  New SqlParameter("@meas_time", model.meas_time),
			  New SqlParameter("@setup_time", model.setup_time),
			  New SqlParameter("@total_time", model.total_time),
			  New SqlParameter("@gen1", If(model.gen1.HasValue, model.gen1.Value, model.gen1)),
			  New SqlParameter("@gen2", model.gen2),
			  New SqlParameter("@gen3", model.gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_phase_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.Add()::" & ex.Message)
		End Try
	End Function
	Public Function AddReturnId(model As FACTS.Model.meas_phase) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {
			  New SqlParameter("@meas_main_id", model.meas_main_id),
			  New SqlParameter("@spec_main_id", model.spec_main_id),
			  New SqlParameter("@phase_main_id", model.phase_main_id),
			  New SqlParameter("@phase", model.phase),
			  New SqlParameter("@phase_status", model.phase_status),
			  New SqlParameter("@software_rev", model.software_rev),
			  New SqlParameter("@employee_id", model.employee_id),
			  New SqlParameter("@controller_id", model.controller_id),
			  New SqlParameter("@factory_id", model.factory_id),
			  New SqlParameter("@forced_status", model.forced_status),
			  New SqlParameter("@start_datetime", model.start_datetime),
			  New SqlParameter("@stop_datetime", model.stop_datetime),
			  New SqlParameter("@conn_time", model.conn_time),
			  New SqlParameter("@meas_time", model.meas_time),
			  New SqlParameter("@setup_time", model.setup_time),
			  New SqlParameter("@total_time", model.total_time),
			  New SqlParameter("@gen1", If(model.gen1.HasValue, model.gen1.Value, model.gen1)),
			  New SqlParameter("@gen2", model.gen2),
			  New SqlParameter("@gen3", model.gen3)
			}
			Return SqlHelper.runProcedureWithReturnValue("proc_meas_phase_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function
	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

			rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_phase_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)

		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.Delete()::" & ex.Message)
		End Try
	End Function
	Public Function Update(model As FACTS.Model.meas_phase) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {
			  New SqlParameter("@id", model.id),
			  New SqlParameter("@meas_main_id", model.meas_main_id),
			  New SqlParameter("@spec_main_id", model.spec_main_id),
			  New SqlParameter("@phase_main_id", model.phase_main_id),
			  New SqlParameter("@phase", model.phase),
			  New SqlParameter("@phase_status", model.phase_status),
			  New SqlParameter("@software_rev", model.software_rev),
			  New SqlParameter("@employee_id", model.employee_id),
			  New SqlParameter("@controller_id", model.controller_id),
			  New SqlParameter("@factory_id", model.factory_id),
			  New SqlParameter("@forced_status", model.forced_status),
			  New SqlParameter("@start_datetime", model.start_datetime),
			  New SqlParameter("@stop_datetime", model.stop_datetime),
			  New SqlParameter("@conn_time", model.conn_time),
			  New SqlParameter("@meas_time", model.meas_time),
			  New SqlParameter("@setup_time", model.setup_time),
			  New SqlParameter("@total_time", model.total_time),
			  New SqlParameter("@gen1", If(model.gen1.HasValue, model.gen1.Value, model.gen1)),
			  New SqlParameter("@gen2", model.gen2),
			  New SqlParameter("@gen3", model.gen3)
			}

			rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_phase_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.Update()::" & ex.Message)
		End Try
	End Function
	Public Function SelectAll() As List(Of FACTS.Model.meas_phase)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.meas_phase
			Dim mlist As New List(Of FACTS.Model.meas_phase)

			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("proc_meas_phase_SelectAll", parameters, "dt").Tables("dt")

			If dt.Rows.Count = 0 Then Return Nothing

			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.meas_phase
				model = DataRowToModel(row)
				mlist.Add(model)
			Next

			Return mlist

		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function
	Public Function SelectById(id As Integer) As FACTS.Model.meas_phase
		Try
			Dim dt As DataTable
			Dim model As New FACTS.Model.meas_phase
			Dim parameters As SqlParameter() = {
							  New SqlParameter("@id", id)}

			dt = SqlHelper.runProcedureWithDataset("proc_meas_phase_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing

			model = DataRowToModel(dt.Rows(0))
			Return model

		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet

			Dim parameters As SqlParameter() = {
			New SqlParameter("@where", whereString)}

			ds = SqlHelper.runProcedureWithDataset("proc_meas_phase_SelectByWhere", parameters, "dt")

			Return ds

		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByControllerId(controller_id As Integer) As List(Of FACTS.Model.meas_phase)
		Try
			Dim resp As New List(Of FACTS.Model.meas_phase)
			Dim respItem As FACTS.Model.meas_phase

			Dim dt As New DataTable

			dt = SelectByWhere("controller_id=" & controller_id).Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing

			For Each dr In dt.Rows
				respItem = DataRowToModel(dr)
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.SelectByControllerId()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByMeasMainId(meas_main_id As Integer) As List(Of FACTS.Model.meas_phase)
		Try
			Dim resp As New List(Of FACTS.Model.meas_phase)
			Dim respItem As FACTS.Model.meas_phase

			Dim dt As New DataTable

			dt = SelectByWhere("meas_main_id = " & meas_main_id).Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing

			For Each dr In dt.Rows
				respItem = DataRowToModel(dr)
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.SelectByMeasMainId()::" & ex.Message)
		End Try
	End Function
	Public Function DataRowToModel(row As DataRow) As FACTS.Model.meas_phase
		Try
			Dim model As New FACTS.Model.meas_phase
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("meas_main_id") Then If Not (IsDBNull(row("meas_main_id"))) Then model.meas_main_id = Convert.ToInt32(row("meas_main_id"))
			If row.Table.Columns.Contains("spec_main_id") Then If Not (IsDBNull(row("spec_main_id"))) Then model.spec_main_id = Convert.ToInt32(row("spec_main_id"))
			If row.Table.Columns.Contains("phase_main_id") Then If Not (IsDBNull(row("phase_main_id"))) Then model.phase_main_id = Convert.ToInt32(row("phase_main_id"))
			If row.Table.Columns.Contains("phase") Then If Not (IsDBNull(row("phase"))) Then model.phase = Convert.ToString(row("phase"))
			If row.Table.Columns.Contains("phase_status") Then If Not (IsDBNull(row("phase_status"))) Then model.phase_status = Convert.ToString(row("phase_status"))
			If row.Table.Columns.Contains("software_rev") Then If Not (IsDBNull(row("software_rev"))) Then model.software_rev = Convert.ToString(row("software_rev"))
			If row.Table.Columns.Contains("employee_id") Then If Not (IsDBNull(row("employee_id"))) Then model.employee_id = Convert.ToInt32(row("employee_id"))
			If row.Table.Columns.Contains("controller_id") Then If Not (IsDBNull(row("controller_id"))) Then model.controller_id = Convert.ToInt32(row("controller_id"))
			If row.Table.Columns.Contains("factory_id") Then If Not (IsDBNull(row("factory_id"))) Then model.factory_id = Convert.ToInt32(row("factory_id"))
			If row.Table.Columns.Contains("forced_status") Then If Not (IsDBNull(row("forced_status"))) Then model.forced_status = Convert.ToBoolean(row("forced_status"))
			If row.Table.Columns.Contains("start_datetime") Then If Not (IsDBNull(row("start_datetime"))) Then model.start_datetime = Convert.ToDateTime(row("start_datetime"))
			If row.Table.Columns.Contains("stop_datetime") Then If Not (IsDBNull(row("stop_datetime"))) Then model.stop_datetime = Convert.ToDateTime(row("stop_datetime"))
			If row.Table.Columns.Contains("conn_time") Then If Not (IsDBNull(row("conn_time"))) Then model.conn_time = Convert.ToInt32(row("conn_time"))
			If row.Table.Columns.Contains("meas_time") Then If Not (IsDBNull(row("meas_time"))) Then model.meas_time = Convert.ToInt32(row("meas_time"))
			If row.Table.Columns.Contains("setup_time") Then If Not (IsDBNull(row("setup_time"))) Then model.setup_time = Convert.ToInt32(row("setup_time"))
			If row.Table.Columns.Contains("total_time") Then If Not (IsDBNull(row("total_time"))) Then model.total_time = Convert.ToInt32(row("total_time"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToInt32(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
			Return model
		Catch ex As Exception
			Throw New Exception("meas_phase.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function
End Class
