Imports System.Data.SqlClient

Public Class connector_typeService
	Public Function Add(model As FACTS.Model.connector_type) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@connector_type", model.Connector_type),
				New SqlParameter("@descr", model.Descr),
				New SqlParameter("@factor", model.Factor),
				New SqlParameter("@connector_family_id", model.Connector_family_id),
				New SqlParameter("@validaity", model.Validaity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_type_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.connector_type) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@connector_type", model.Connector_type),
				New SqlParameter("@descr", model.Descr),
				New SqlParameter("@factor", model.Factor),
				New SqlParameter("@connector_family_id", model.Connector_family_id),
				New SqlParameter("@validaity", model.Validaity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_connector_type_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_type_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.connector_type) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@connector_type", model.Connector_type),
				New SqlParameter("@descr", model.Descr),
				New SqlParameter("@factor", model.Factor),
				New SqlParameter("@connector_family_id", model.Connector_family_id),
				New SqlParameter("@validaity", model.Validaity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_connector_type_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.connector_type)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_type
			Dim mlist As New List(Of FACTS.Model.connector_type)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_type_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.connector_type
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.connector_type
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_type
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_connector_type_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByConnectorType(connector_type As String) As FACTS.Model.connector_type
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.connector_type
			dt = SelectByWhere("connector_type = '" & connector_type & "'").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.SelectByConnectorType()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_connector_type_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.connector_type
		Try
			Dim model As New FACTS.Model.connector_type
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("connector_type") Then If Not (IsDBNull(row("connector_type"))) Then model.Connector_type = Convert.ToString(row("connector_type"))
			If row.Table.Columns.Contains("descr") Then If Not (IsDBNull(row("descr"))) Then model.Descr = Convert.ToString(row("descr"))
			If row.Table.Columns.Contains("factor") Then If Not (IsDBNull(row("factor"))) Then model.Factor = Convert.ToInt32(row("factor"))
			If row.Table.Columns.Contains("connector_family_id") Then If Not (IsDBNull(row("connector_family_id"))) Then model.Connector_family_id = Convert.ToInt32(row("connector_family_id"))
			If row.Table.Columns.Contains("validaity") Then If Not (IsDBNull(row("validaity"))) Then model.Validaity = Convert.ToBoolean(row("validaity"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToString(row("gen3"))
			If row.Table.Columns.Contains("gen4") Then If Not (IsDBNull(row("gen4"))) Then model.Gen4 = Convert.ToString(row("gen4"))
			If row.Table.Columns.Contains("gen5") Then If Not (IsDBNull(row("gen5"))) Then model.Gen5 = Convert.ToInt32(row("gen5"))
			Return model
		Catch ex As Exception
			Throw New Exception("connector_type.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
