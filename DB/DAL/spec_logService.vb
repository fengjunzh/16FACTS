Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class spec_logService
	Public Function Add(model As FACTS.Model.spec_log) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {
		New SqlParameter("@product_main_id", model.product_main_id),
		New SqlParameter("@mode_id", model.mode_id),
		New SqlParameter("@spec_main_id", model.spec_main_id),
		New SqlParameter("@phase_main_id", model.phase_main_id),
		New SqlParameter("@action", model.action),
		New SqlParameter("@action_descr", model.action_descr),
		New SqlParameter("@date_time", model.date_time),
		New SqlParameter("@employee_id", IIf(model.employee_id.HasValue, model.employee_id, DBNull.Value)),
		New SqlParameter("@controller_id", IIf(model.controller_id.HasValue, model.controller_id, DBNull.Value)),
		New SqlParameter("@factory_id", model.factory_id),
		New SqlParameter("@stuffer_name", model.stuffer_name),
		New SqlParameter("@stuffer_version", model.stuffer_version),
		New SqlParameter("@gen1", model.gen1),
		New SqlParameter("@gen2", model.gen2),
		New SqlParameter("@gen3", model.gen3)
			}

			' parameters.First(Function(p) p.ParameterName = "@employee_id").SqlValue = IIf(model.employee_id.HasValue, DBNull.Value, model.employee_id)
			'parameters.First(Function(p) p.ParameterName = "@controller_id").SqlValue = IIf(model.controller_id.HasValue, DBNull.Value, model.employee_id)
			'        'New SqlParameter("@employee_id", SqlDbType.Int),
			''New SqlParameter("@controller_id", SqlDbType.Int),
			'parameters.First(Function(p) p.ParameterName = "@employee_id").SqlValue = 7
			'parameters.First(Function(p) p.ParameterName = "@controller_id").SqlValue = 86

			'parameters.First(Function(p) p.ParameterName = "@employee_id").SqlValue = IIf(model.employee_id.HasValue, DBNull.Value, model.employee_id)
			'parameters.First(Function(p) p.ParameterName = "@controller_id").SqlValue = IIf(model.controller_id.HasValue, DBNull.Value, model.employee_id)

			'Dim empPara As SqlParameter = New SqlParameter("@employee_id", SqlDbType.Int)
			'empPara.Value = IIf(model.employee_id.HasValue, DBNull.Value, model.employee_id)

			'Dim ctlPara As SqlParameter = New SqlParameter("@controller_id", SqlDbType.Int)
			'ctlPara.Value = IIf(model.controller_id.HasValue, DBNull.Value, model.employee_id)

			rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_spec_log_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("spec_log.DAL.Add()::" & ex.Message)
		End Try
	End Function
	Public Function AddReturnId(model As FACTS.Model.spec_log) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {
		New SqlParameter("@product_main_id", model.product_main_id),
		New SqlParameter("@mode_id", model.mode_id),
		New SqlParameter("@spec_main_id", model.spec_main_id),
		New SqlParameter("@phase_main_id", model.phase_main_id),
		New SqlParameter("@action", model.action),
		New SqlParameter("@action_descr", model.action_descr),
		New SqlParameter("@date_time", model.date_time),
		New SqlParameter("@employee_id", model.employee_id),
		New SqlParameter("@controller_id", model.controller_id),
		New SqlParameter("@factory_id", model.factory_id),
		New SqlParameter("@stuffer_name", model.stuffer_name),
		New SqlParameter("@stuffer_version", model.stuffer_version),
		New SqlParameter("@gen1", model.gen1),
		New SqlParameter("@gen2", model.gen2),
		New SqlParameter("@gen3", model.gen3)
			}
			Return SqlHelper.runProcedureWithReturnValue("proc_spec_log_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("spec_log.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function
	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

			rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_spec_log_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)

		Catch ex As Exception
			Throw New Exception("spec_log.DAL.Delete()::" & ex.Message)
		End Try
	End Function
	Public Function Update(model As FACTS.Model.spec_log) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() = {
		New SqlParameter("@id", model.id),
		New SqlParameter("@product_main_id", model.product_main_id),
		New SqlParameter("@mode_id", model.mode_id),
		New SqlParameter("@spec_main_id", model.spec_main_id),
		New SqlParameter("@phase_main_id", model.phase_main_id),
		New SqlParameter("@action", model.action),
		New SqlParameter("@action_descr", model.action_descr),
		New SqlParameter("@date_time", model.date_time),
		New SqlParameter("@employee_id", model.employee_id),
		New SqlParameter("@controller_id", model.controller_id),
		New SqlParameter("@factory_id", model.factory_id),
		New SqlParameter("@stuffer_name", model.stuffer_name),
		New SqlParameter("@stuffer_version", model.stuffer_version),
		New SqlParameter("@gen1", model.gen1),
		New SqlParameter("@gen2", model.gen2),
		New SqlParameter("@gen3", model.gen3)
			}

			rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_spec_log_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("spec_log.DAL.Update()::" & ex.Message)
		End Try
	End Function
	Public Function SelectAll() As List(Of FACTS.Model.spec_log)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.spec_log
			Dim mlist As New List(Of FACTS.Model.spec_log)

			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("proc_spec_log_SelectAll", parameters, "dt").Tables("dt")

			If dt.Rows.Count = 0 Then Return Nothing

			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.spec_log
				model = DataRowToModel(row)
				mlist.Add(model)
			Next

			Return mlist

		Catch ex As Exception
			Throw New Exception("spec_log.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function
	Public Function SelectById(id As Integer) As FACTS.Model.spec_log
		Try
			Dim dt As DataTable
			Dim model As New FACTS.Model.spec_log
			Dim parameters As SqlParameter() = {
						New SqlParameter("@id", id)}

			dt = SqlHelper.runProcedureWithDataset("proc_spec_log_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing

			model = DataRowToModel(dt.Rows(0))
			Return model

		Catch ex As Exception
			Throw New Exception("spec_log.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
            New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_spec_log_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("spec_log.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
	Public Function SelectBySpecMainId(id As Integer) As List(Of FACTS.Model.spec_log)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.spec_log
			Dim mlist As New List(Of FACTS.Model.spec_log)

			Dim parameters As SqlParameter() = {}
			dt = SelectByWhere("spec_main_id ='" & id & "' order by date_time desc").Tables("dt")

			If dt.Rows.Count = 0 Then Return Nothing

			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.spec_log
				model = DataRowToModel(row)
				mlist.Add(model)
			Next

			Return mlist

		Catch ex As Exception
			Throw New Exception("spec_log.DAL.SelectBySpecMainId()::" & ex.Message)
		End Try
	End Function
	Public Function DataRowToModel(row As DataRow) As FACTS.Model.spec_log
		Try
			Dim model As New FACTS.Model.spec_log
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("product_main_id") Then If Not (IsDBNull(row("product_main_id"))) Then model.product_main_id = Convert.ToInt32(row("product_main_id"))
			If row.Table.Columns.Contains("mode_id") Then If Not (IsDBNull(row("mode_id"))) Then model.mode_id = Convert.ToInt32(row("mode_id"))
			If row.Table.Columns.Contains("spec_main_id") Then If Not (IsDBNull(row("spec_main_id"))) Then model.spec_main_id = Convert.ToInt32(row("spec_main_id"))
			If row.Table.Columns.Contains("phase_main_id") Then If Not (IsDBNull(row("phase_main_id"))) Then model.phase_main_id = Convert.ToInt32(row("phase_main_id"))
			If row.Table.Columns.Contains("action") Then If Not (IsDBNull(row("action"))) Then model.action = Convert.ToString(row("action"))
			If row.Table.Columns.Contains("action_descr") Then If Not (IsDBNull(row("action_descr"))) Then model.action_descr = Convert.ToString(row("action_descr"))
			If row.Table.Columns.Contains("date_time") Then If Not (IsDBNull(row("date_time"))) Then model.date_time = Convert.ToDateTime(row("date_time"))
			If row.Table.Columns.Contains("employee_id") Then If Not (IsDBNull(row("employee_id"))) Then model.employee_id = Convert.ToInt32(row("employee_id"))
			If row.Table.Columns.Contains("controller_id") Then If Not (IsDBNull(row("controller_id"))) Then model.controller_id = Convert.ToInt32(row("controller_id"))
			If row.Table.Columns.Contains("factory_id") Then If Not (IsDBNull(row("factory_id"))) Then model.factory_id = Convert.ToInt32(row("factory_id"))
			If row.Table.Columns.Contains("stuffer_name") Then If Not (IsDBNull(row("stuffer_name"))) Then model.stuffer_name = Convert.ToString(row("stuffer_name"))
			If row.Table.Columns.Contains("stuffer_version") Then If Not (IsDBNull(row("stuffer_version"))) Then model.stuffer_version = Convert.ToString(row("stuffer_version"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
			Return model
		Catch ex As Exception
			Throw New Exception("spec_log.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function
End Class
