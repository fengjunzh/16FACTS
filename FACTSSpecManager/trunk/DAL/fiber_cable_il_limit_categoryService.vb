Imports System.Data.SqlClient

Public Class fiber_cable_il_limit_categoryService
	Public Function Add(model As FACTS.Model.fiber_cable_il_limit_category) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@limit_name", model.Limit_name),
				New SqlParameter("@order_idx", model.Order_idx),
				New SqlParameter("@descr", model.Descr),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_fiber_cable_il_limit_category_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.fiber_cable_il_limit_category) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@limit_name", model.Limit_name),
				New SqlParameter("@order_idx", model.Order_idx),
				New SqlParameter("@descr", model.Descr),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_fiber_cable_il_limit_category_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_fiber_cable_il_limit_category_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.fiber_cable_il_limit_category) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@limit_name", model.Limit_name),
				New SqlParameter("@order_idx", model.Order_idx),
				New SqlParameter("@descr", model.Descr),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_fiber_cable_il_limit_category_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.fiber_cable_il_limit_category)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.fiber_cable_il_limit_category
			Dim mlist As New List(Of FACTS.Model.fiber_cable_il_limit_category)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_fiber_cable_il_limit_category_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.fiber_cable_il_limit_category
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.fiber_cable_il_limit_category
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.fiber_cable_il_limit_category
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_fiber_cable_il_limit_category_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.SelectById()::" & ex.Message)
		End Try
	End Function


	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_fiber_cable_il_limit_category_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.fiber_cable_il_limit_category
		Try
			Dim model As New FACTS.Model.fiber_cable_il_limit_category
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("limit_name") Then If Not (IsDBNull(row("limit_name"))) Then model.Limit_name = Convert.ToString(row("limit_name"))
			If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.Order_idx = Convert.ToInt32(row("order_idx"))
			If row.Table.Columns.Contains("descr") Then If Not (IsDBNull(row("descr"))) Then model.Descr = Convert.ToString(row("descr"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToInt32(row("gen3"))
			Return model
		Catch ex As Exception
			Throw New Exception("fiber_cable_il_limit_category.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
