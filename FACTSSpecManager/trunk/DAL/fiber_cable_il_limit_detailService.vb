Imports System.Data.SqlClient

Public Class fiber_cable_il_limit_detailService
	Public Function Add(model As FACTS.Model.fiber_cable_il_limit_detail) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@limit_id", model.Limit_id),
				New SqlParameter("@wave_length_id", model.Wave_length_id),
				New SqlParameter("@il_limit", model.Il_limit)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_fiber_cable_il_limit_detail_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.fiber_cable_il_limit_detail) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@limit_id", model.Limit_id),
				New SqlParameter("@wave_length_id", model.Wave_length_id),
				New SqlParameter("@il_limit", model.Il_limit)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_fiber_cable_il_limit_detail_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_fiber_cable_il_limit_detail_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.fiber_cable_il_limit_detail) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@limit_id", model.Limit_id),
				New SqlParameter("@wave_length_id", model.Wave_length_id),
				New SqlParameter("@il_limit", model.Il_limit)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_fiber_cable_il_limit_detail_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.fiber_cable_il_limit_detail)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.fiber_cable_il_limit_detail
			Dim mlist As New List(Of FACTS.Model.fiber_cable_il_limit_detail)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_fiber_cable_il_limit_detail_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.fiber_cable_il_limit_detail
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.fiber_cable_il_limit_detail
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.fiber_cable_il_limit_detail
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_fiber_cable_il_limit_detail_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.SelectById()::" & ex.Message)
		End Try
	End Function


	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_fiber_cable_il_limit_detail_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.fiber_cable_il_limit_detail
		Try
			Dim model As New FACTS.Model.fiber_cable_il_limit_detail
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("limit_id") Then If Not (IsDBNull(row("limit_id"))) Then model.Limit_id = Convert.ToInt32(row("limit_id"))
			If row.Table.Columns.Contains("wave_length_id") Then If Not (IsDBNull(row("wave_length_id"))) Then model.Wave_length_id = Convert.ToInt32(row("wave_length_id"))
			If row.Table.Columns.Contains("il_limit") Then If Not (IsDBNull(row("il_limit"))) Then model.Il_limit = Convert.ToDecimal(row("il_limit"))
			Return model
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_detail.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
