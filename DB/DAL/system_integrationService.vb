Imports System.Data.SqlClient

Public Class system_integrationService
	Public Function Add(model As FACTS.Model.system_integration) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
{
New SqlParameter("@instr_serial_num", model.Instr_serial_num),
New SqlParameter("@fpd_result", model.Fpd_result),
New SqlParameter("@fpd_finish_datetime", model.Fpd_finish_datetime),
New SqlParameter("@fpp_result", model.Fpp_result),
New SqlParameter("@fpp_finish_datetime", model.Fpp_finish_datetime),
New SqlParameter("@spl_result", model.Spl_result),
New SqlParameter("@spl_finish_datetime", model.Spl_finish_datetime),
New SqlParameter("@spl_channel_num", model.Spl_channel_num),
New SqlParameter("@gen1", model.Gen1),
New SqlParameter("@gen2", model.Gen2),
New SqlParameter("@gen3", model.Gen3)
}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_system_integration_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.Add()::" & ex.Message)
		End Try
	End Function
	Public Function AddReturnId(model As FACTS.Model.system_integration) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
{
New SqlParameter("@instr_serial_num", model.Instr_serial_num),
New SqlParameter("@fpd_result", model.Fpd_result),
New SqlParameter("@fpd_finish_datetime", model.Fpd_finish_datetime),
New SqlParameter("@fpp_result", model.Fpp_result),
New SqlParameter("@fpp_finish_datetime", model.Fpp_finish_datetime),
New SqlParameter("@spl_result", model.Spl_result),
New SqlParameter("@spl_finish_datetime", model.Spl_finish_datetime),
New SqlParameter("@spl_channel_num", model.Spl_channel_num),
New SqlParameter("@gen1", model.Gen1),
New SqlParameter("@gen2", model.Gen2),
New SqlParameter("@gen3", model.Gen3)
}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_system_integration_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function
	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
{
New SqlParameter("@id", id)
}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_system_integration_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.Delete()::" & ex.Message)
		End Try
	End Function
	Public Function Update(model As FACTS.Model.system_integration) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
{
New SqlParameter("@id", model.Id),
New SqlParameter("@instr_serial_num", model.Instr_serial_num),
New SqlParameter("@fpd_result", model.Fpd_result),
New SqlParameter("@fpd_finish_datetime", model.Fpd_finish_datetime),
New SqlParameter("@fpp_result", model.Fpp_result),
New SqlParameter("@fpp_finish_datetime", model.Fpp_finish_datetime),
New SqlParameter("@spl_result", model.Spl_result),
New SqlParameter("@spl_finish_datetime", model.Spl_finish_datetime),
New SqlParameter("@spl_channel_num", model.Spl_channel_num),
New SqlParameter("@gen1", model.Gen1),
New SqlParameter("@gen2", model.Gen2),
New SqlParameter("@gen3", model.Gen3)
}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_system_integration_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.Update()::" & ex.Message)
		End Try
	End Function
	Public Function SelectAll() As List(Of FACTS.Model.system_integration)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.system_integration
			Dim mlist As New List(Of FACTS.Model.system_integration)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_system_integration_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.system_integration
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function
	Public Function SelectById(id As Integer) As FACTS.Model.system_integration
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.system_integration
			Dim parameters As SqlParameter() =
{
New SqlParameter("@id", id)
}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_system_integration_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectBySN(sn As String) As FACTS.Model.system_integration
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.system_integration
			dt = SelectByWhere("instr_serial_num = '" & sn & "'").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.SelectBySN()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
{
New SqlParameter("@where", whereString)
}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_system_integration_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function
	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.system_integration
		Try
			Dim model As New FACTS.Model.system_integration
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("instr_serial_num") Then If Not (IsDBNull(row("instr_serial_num"))) Then model.Instr_serial_num = Convert.ToString(row("instr_serial_num"))
			If row.Table.Columns.Contains("fpd_result") Then If Not (IsDBNull(row("fpd_result"))) Then model.Fpd_result = Convert.ToBoolean(row("fpd_result"))
			If row.Table.Columns.Contains("fpd_finish_datetime") Then If Not (IsDBNull(row("fpd_finish_datetime"))) Then model.Fpd_finish_datetime = Convert.ToDateTime(row("fpd_finish_datetime"))
			If row.Table.Columns.Contains("fpp_result") Then If Not (IsDBNull(row("fpp_result"))) Then model.Fpp_result = Convert.ToBoolean(row("fpp_result"))
			If row.Table.Columns.Contains("fpp_finish_datetime") Then If Not (IsDBNull(row("fpp_finish_datetime"))) Then model.Fpp_finish_datetime = Convert.ToDateTime(row("fpp_finish_datetime"))
			If row.Table.Columns.Contains("spl_result") Then If Not (IsDBNull(row("spl_result"))) Then model.Spl_result = Convert.ToBoolean(row("spl_result"))
			If row.Table.Columns.Contains("spl_finish_datetime") Then If Not (IsDBNull(row("spl_finish_datetime"))) Then model.Spl_finish_datetime = Convert.ToDateTime(row("spl_finish_datetime"))
			If row.Table.Columns.Contains("spl_channel_num") Then If Not (IsDBNull(row("spl_channel_num"))) Then model.Spl_channel_num = Convert.ToInt32(row("spl_channel_num"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToString(row("gen3"))
			Return model
		Catch ex As Exception
			Throw New Exception("system_integration.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function


End Class
