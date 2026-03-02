Imports System.Data.SqlClient

Public Class connector_familyService
	Public Function Add(model As FACTS.Model.connector_family) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@family_name", model.Family_name),
				New SqlParameter("@order_idx", model.Order_idx),
				New SqlParameter("@class_id", model.Class_id),
				New SqlParameter("@validaity", model.Validaity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_family_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.connector_family) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@family_name", model.Family_name),
				New SqlParameter("@order_idx", model.Order_idx),
				New SqlParameter("@class_id", model.Class_id),
				New SqlParameter("@validaity", model.Validaity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_connector_family_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_family_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.connector_family) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@family_name", model.Family_name),
				New SqlParameter("@order_idx", model.Order_idx),
				New SqlParameter("@class_id", model.Class_id),
				New SqlParameter("@validaity", model.Validaity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_family_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.connector_family)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_family
			Dim mlist As New List(Of FACTS.Model.connector_family)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_family_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.connector_family
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.connector_family
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_family
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_family_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function Select1500ByProduct(product_name As String) As FACTS.Model.connector_family
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_family
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@product_name", product_name)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_family_1500_SelectByProduct", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.Select1500ByProduct()::" & ex.Message)
		End Try
	End Function
	Public Function Select1501ByProduct(product_name As String) As FACTS.Model.connector_family
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_family
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@product_name", product_name)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_family_1501_SelectByProduct", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.Select1501ByProduct()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_connector_family_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.connector_family
		Try
			Dim model As New FACTS.Model.connector_family
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("family_name") Then If Not (IsDBNull(row("family_name"))) Then model.Family_name = Convert.ToString(row("family_name"))
			If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.Order_idx = Convert.ToInt32(row("order_idx"))
			If row.Table.Columns.Contains("class_id") Then If Not (IsDBNull(row("class_id"))) Then model.Class_id = Convert.ToInt32(row("class_id"))
			If row.Table.Columns.Contains("validaity") Then If Not (IsDBNull(row("validaity"))) Then model.Validaity = Convert.ToBoolean(row("validaity"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToString(row("gen3"))
			If row.Table.Columns.Contains("gen4") Then If Not (IsDBNull(row("gen4"))) Then model.Gen4 = Convert.ToString(row("gen4"))
			If row.Table.Columns.Contains("gen5") Then If Not (IsDBNull(row("gen5"))) Then model.Gen5 = Convert.ToInt32(row("gen5"))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_family.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
