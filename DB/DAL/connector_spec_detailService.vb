Imports System.Data.SqlClient

Public Class connector_spec_detailService
	Public Function Add(model As FACTS.Model.connector_spec_detail) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@connector_spec_main_id", model.Connector_spec_main_id),
				New SqlParameter("@wave_length_id", model.Wave_length_id),
				New SqlParameter("@il_limit", model.Il_limit),
				New SqlParameter("@rl_limit", model.Rl_limit),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_spec_detail_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.connector_spec_detail) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@connector_spec_main_id", model.Connector_spec_main_id),
				New SqlParameter("@wave_length_id", model.Wave_length_id),
				New SqlParameter("@il_limit", model.Il_limit),
				New SqlParameter("@rl_limit", model.Rl_limit),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_connector_spec_detail_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_spec_detail_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.connector_spec_detail) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@connector_spec_main_id", model.Connector_spec_main_id),
				New SqlParameter("@wave_length_id", model.Wave_length_id),
				New SqlParameter("@il_limit", model.Il_limit),
				New SqlParameter("@rl_limit", model.Rl_limit),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_spec_detail_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.connector_spec_detail)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_spec_detail
			Dim mlist As New List(Of FACTS.Model.connector_spec_detail)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_spec_detail_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.connector_spec_detail
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.connector_spec_detail
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_spec_detail
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_spec_detail_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.SelectById()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByConnSpecMainId(conn_spec_main_id As Integer) As List(Of FACTS.Model.connector_spec_detail)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_spec_detail
			Dim mlist As New List(Of FACTS.Model.connector_spec_detail)
			dt = SelectByWhere("connector_spec_main_id = " & conn_spec_main_id).Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.connector_spec_detail
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.SelectByConnSpecMainId()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_connector_spec_detail_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.connector_spec_detail
		Try
			Dim model As New FACTS.Model.connector_spec_detail
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("connector_spec_main_id") Then If Not (IsDBNull(row("connector_spec_main_id"))) Then model.Connector_spec_main_id = Convert.ToInt32(row("connector_spec_main_id"))
			If row.Table.Columns.Contains("wave_length_id") Then If Not (IsDBNull(row("wave_length_id"))) Then model.Wave_length_id = Convert.ToInt32(row("wave_length_id"))
			If row.Table.Columns.Contains("il_limit") Then If Not (IsDBNull(row("il_limit"))) Then model.Il_limit = Convert.ToDecimal(row("il_limit"))
			If row.Table.Columns.Contains("rl_limit") Then If Not (IsDBNull(row("rl_limit"))) Then model.Rl_limit = Convert.ToDecimal(row("rl_limit"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToInt32(row("gen3"))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_spec_detail.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
