Imports System.Data.SqlClient

Public Class product_cable_ilService
	Public Function Add(model As FACTS.Model.product_cable_il) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@product_main_id", model.Product_main_id),
				New SqlParameter("@limit_id", model.Limit_id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_product_cable_il_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.product_cable_il) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@product_main_id", model.Product_main_id),
				New SqlParameter("@limit_id", model.Limit_id)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_product_cable_il_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_product_cable_il_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.product_cable_il) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@product_main_id", model.Product_main_id),
				New SqlParameter("@limit_id", model.Limit_id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_product_cable_il_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.product_cable_il)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.product_cable_il
			Dim mlist As New List(Of FACTS.Model.product_cable_il)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_product_cable_il_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.product_cable_il
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.product_cable_il
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.product_cable_il
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_product_cable_il_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.SelectById()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByProductMainId(product_main_id As Integer) As FACTS.Model.product_cable_il
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.product_cable_il
			dt = SelectByWhere("product_main_id = " & product_main_id).Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.SelectByProductMainId()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_product_cable_il_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.product_cable_il
		Try
			Dim model As New FACTS.Model.product_cable_il
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("product_main_id") Then If Not (IsDBNull(row("product_main_id"))) Then model.Product_main_id = Convert.ToInt32(row("product_main_id"))
			If row.Table.Columns.Contains("limit_id") Then If Not (IsDBNull(row("limit_id"))) Then model.Limit_id = Convert.ToInt32(row("limit_id"))
			Return model
		Catch ex As Exception
			Throw New Exception("product_cable_il.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
