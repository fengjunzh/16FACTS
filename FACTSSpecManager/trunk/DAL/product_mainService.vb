Option Strict Off
Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Partial Public Class product_mainService

	Public Function Add(model As FACTS.Model.product_main) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
				{
					New SqlParameter("@customer_id", model.Customer_id),
					New SqlParameter("@product_name", model.Product_name),
					New SqlParameter("@cust_product_name", model.Cust_product_name),
					New SqlParameter("@product_ver", model.Product_ver),
					New SqlParameter("@product_desc", model.Product_desc),
					New SqlParameter("@family", model.Family),
					New SqlParameter("@validity", model.Validity),
					New SqlParameter("@sn_format", model.Sn_format),
					New SqlParameter("@sn_check", model.Sn_check),
					New SqlParameter("@subunit", model.Subunit),
					New SqlParameter("@fiber_per_subunit", model.Fiber_per_subunit),
					New SqlParameter("@length_m", model.Length_m),
					New SqlParameter("@gen1", model.Gen1),
					New SqlParameter("@gen2", model.Gen2),
					New SqlParameter("@gen3", model.Gen3),
					New SqlParameter("@gen4", model.Gen4),
					New SqlParameter("@gen5", model.Gen5)
				}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_product_main_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("product_main.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.product_main) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
				{
					New SqlParameter("@customer_id", model.Customer_id),
					New SqlParameter("@product_name", model.Product_name),
					New SqlParameter("@cust_product_name", model.Cust_product_name),
					New SqlParameter("@product_ver", model.Product_ver),
					New SqlParameter("@product_desc", model.Product_desc),
					New SqlParameter("@family", model.Family),
					New SqlParameter("@validity", model.Validity),
					New SqlParameter("@sn_format", model.Sn_format),
					New SqlParameter("@sn_check", model.Sn_check),
					New SqlParameter("@subunit", model.Subunit),
					New SqlParameter("@fiber_per_subunit", model.Fiber_per_subunit),
					New SqlParameter("@length_m", model.Length_m),
					New SqlParameter("@gen1", model.Gen1),
					New SqlParameter("@gen2", model.Gen2),
					New SqlParameter("@gen3", model.Gen3),
					New SqlParameter("@gen4", model.Gen4),
					New SqlParameter("@gen5", model.Gen5)
				}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_product_main_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("product_main.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
				{
					New SqlParameter("@id", id)
				}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_product_main_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("product_main.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.product_main) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
				{
					New SqlParameter("@id", model.Id),
					New SqlParameter("@customer_id", model.Customer_id),
					New SqlParameter("@product_name", model.Product_name),
					New SqlParameter("@cust_product_name", model.Cust_product_name),
					New SqlParameter("@product_ver", model.Product_ver),
					New SqlParameter("@product_desc", model.Product_desc),
					New SqlParameter("@family", model.Family),
					New SqlParameter("@validity", model.Validity),
					New SqlParameter("@sn_format", model.Sn_format),
					New SqlParameter("@sn_check", model.Sn_check),
					New SqlParameter("@subunit", model.Subunit),
					New SqlParameter("@fiber_per_subunit", model.Fiber_per_subunit),
					New SqlParameter("@length_m", model.Length_m),
					New SqlParameter("@gen1", model.Gen1),
					New SqlParameter("@gen2", model.Gen2),
					New SqlParameter("@gen3", model.Gen3),
					New SqlParameter("@gen4", model.Gen4),
					New SqlParameter("@gen5", model.Gen5)
				}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_product_main_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("product_main.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.product_main)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.product_main
			Dim mlist As New List(Of FACTS.Model.product_main)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_product_main_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.product_main
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("product_main.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.product_main
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.product_main
			Dim parameters As SqlParameter() =
				{
					New SqlParameter("@id", id)
				}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_product_main_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("product_main.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByProductName(product_name As String) As FACTS.Model.product_main
		Try
			Dim dt As DataTable
			Dim model As New FACTS.Model.product_main

			dt = SelectByWhere("product_name = '" & product_name & "'").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing

			model = DataRowToModel(dt.Rows(0))
			Return model

		Catch ex As Exception
			Throw New Exception("product_main.DAL.SelectByProductName()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
				{
					New SqlParameter("@where", whereString)
				}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_product_main_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("product_main.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.product_main
		Try
			Dim model As New FACTS.Model.product_main
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("customer_id") Then If Not (IsDBNull(row("customer_id"))) Then model.Customer_id = Convert.ToInt32(row("customer_id"))
			If row.Table.Columns.Contains("product_name") Then If Not (IsDBNull(row("product_name"))) Then model.Product_name = Convert.ToString(row("product_name"))
			If row.Table.Columns.Contains("cust_product_name") Then If Not (IsDBNull(row("cust_product_name"))) Then model.Cust_product_name = Convert.ToString(row("cust_product_name"))
			If row.Table.Columns.Contains("product_ver") Then If Not (IsDBNull(row("product_ver"))) Then model.Product_ver = Convert.ToString(row("product_ver"))
			If row.Table.Columns.Contains("product_desc") Then If Not (IsDBNull(row("product_desc"))) Then model.Product_desc = Convert.ToString(row("product_desc"))
			If row.Table.Columns.Contains("family") Then If Not (IsDBNull(row("family"))) Then model.Family = Convert.ToString(row("family"))
			If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.Validity = Convert.ToBoolean(row("validity"))
			If row.Table.Columns.Contains("sn_format") Then If Not (IsDBNull(row("sn_format"))) Then model.Sn_format = Convert.ToString(row("sn_format"))
			If row.Table.Columns.Contains("sn_check") Then If Not (IsDBNull(row("sn_check"))) Then model.Sn_check = Convert.ToBoolean(row("sn_check"))
			If row.Table.Columns.Contains("subunit") Then If Not (IsDBNull(row("subunit"))) Then model.Subunit = Convert.ToInt16(row("subunit"))
			If row.Table.Columns.Contains("fiber_per_subunit") Then If Not (IsDBNull(row("fiber_per_subunit"))) Then model.Fiber_per_subunit = Convert.ToInt16(row("fiber_per_subunit"))
			If row.Table.Columns.Contains("length_m") Then If Not (IsDBNull(row("length_m"))) Then model.Length_m = Convert.ToDecimal(row("length_m"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToString(row("gen3"))
			If row.Table.Columns.Contains("gen4") Then If Not (IsDBNull(row("gen4"))) Then model.Gen4 = Convert.ToString(row("gen4"))
			If row.Table.Columns.Contains("gen5") Then If Not (IsDBNull(row("gen5"))) Then model.Gen5 = Convert.ToInt32(row("gen5"))
			Return model
		Catch ex As Exception
			Throw New Exception("product_main.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function
End Class
