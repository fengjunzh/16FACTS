Imports System.Data.SqlClient


Public Class cq_product_sn_woService
	Public Function SelectAllByWo(wo As String) As List(Of Model.cq_product_sn_wo)
		Try
			Dim dt As DataTable
			Dim resp As New List(Of FACTS.Model.cq_product_sn_wo)
			Dim respItem As FACTS.Model.cq_product_sn_wo
			Dim parameters As SqlParameter() = {New SqlParameter("@WorkOrder", wo)}

			dt = SqlHelper.runProcedureWithDataset("select_cq_product_sn_wo_by_wo", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				respItem = DataRowToModel(row)
				resp.Add(respItem)
			Next
			Return resp
		Catch ex As Exception
			Throw New Exception("cq_product_sn_wo.DAL.SelectAllByWo()::" & ex.Message)
		End Try
	End Function
	Public Function SelectBySn(sn As String) As Model.cq_product_sn_wo
		Try
			Dim dt As DataTable
			Dim resp As FACTS.Model.cq_product_sn_wo
			Dim parameters As SqlParameter() = {New SqlParameter("@SN", sn)}

			dt = SqlHelper.runProcedureWithDataset("select_cq_product_sn_wo_by_sn", parameters, "dt").Tables("dt")

			If dt.Rows.Count = 0 Then Return Nothing

			resp = DataRowToModel(dt.Rows(0))

			Return resp
		Catch ex As Exception
			Throw New Exception("cq_product_sn_wo.DAL.SelectAllBySn()::" & ex.Message)
		End Try
	End Function
	Public Function DataRowToModel(row As DataRow) As FACTS.Model.cq_product_sn_wo
		Try
			Dim model As New FACTS.Model.cq_product_sn_wo
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("product_sn_id") Then If Not (IsDBNull(row("product_sn_id"))) Then model.product_sn_id = Convert.ToInt32(row("product_sn_id"))
			If row.Table.Columns.Contains("product_wo_id") Then If Not (IsDBNull(row("product_wo_id"))) Then model.product_wo_id = Convert.ToInt32(row("product_wo_id"))
			If row.Table.Columns.Contains("product_main_id") Then If Not (IsDBNull(row("product_main_id"))) Then model.product_main_id = Convert.ToInt32(row("product_main_id"))
			If row.Table.Columns.Contains("product_name") Then If Not (IsDBNull(row("product_name"))) Then model.product_name = Convert.ToString(row("product_name"))
			If row.Table.Columns.Contains("product_serial_num") Then If Not (IsDBNull(row("product_serial_num"))) Then model.product_serial_num = Convert.ToString(row("product_serial_num"))
			If row.Table.Columns.Contains("wo_descr") Then If Not (IsDBNull(row("wo_descr"))) Then model.product_wo = Convert.ToString(row("wo_descr"))
			Return model
		Catch ex As Exception
			Throw New Exception("cq_product_sn_wo.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function
End Class











