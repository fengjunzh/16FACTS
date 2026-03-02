Imports System.Data.SqlClient

Public Class serial_number_relationService
	Public Function Add(model As FACTS.Model.serial_number_relation) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@serial_number_1", model.Serial_number_1),
				New SqlParameter("@serial_number_2", model.Serial_number_2),
				New SqlParameter("@register_datetime", model.Register_datetime),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_serial_number_relation_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.serial_number_relation) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@serial_number_1", model.Serial_number_1),
				New SqlParameter("@serial_number_2", model.Serial_number_2),
				New SqlParameter("@register_datetime", model.Register_datetime),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_serial_number_relation_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_serial_number_relation_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.serial_number_relation) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@serial_number_1", model.Serial_number_1),
				New SqlParameter("@serial_number_2", model.Serial_number_2),
				New SqlParameter("@register_datetime", model.Register_datetime),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_serial_number_relation_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.serial_number_relation)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.serial_number_relation
			Dim mlist As New List(Of FACTS.Model.serial_number_relation)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_serial_number_relation_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.serial_number_relation
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectBySn(sn As String) As FACTS.Model.serial_number_relation
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.serial_number_relation
			dt = SelectByWhere("serial_number_1 = '" & sn & "' or serial_number_2 = '" & sn & "'").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.SelectBySn()::" & ex.Message)
		End Try
	End Function
	Public Function SelectById(id As Integer) As FACTS.Model.serial_number_relation
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.serial_number_relation
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_serial_number_relation_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.SelectById()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_serial_number_relation_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.serial_number_relation
		Try
			Dim model As New FACTS.Model.serial_number_relation
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("serial_number_1") Then If Not (IsDBNull(row("serial_number_1"))) Then model.Serial_number_1 = Convert.ToString(row("serial_number_1"))
			If row.Table.Columns.Contains("serial_number_2") Then If Not (IsDBNull(row("serial_number_2"))) Then model.Serial_number_2 = Convert.ToString(row("serial_number_2"))
			If row.Table.Columns.Contains("register_datetime") Then If Not (IsDBNull(row("register_datetime"))) Then model.Register_datetime = Convert.ToDateTime(row("register_datetime"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToString(row("gen3"))
			Return model
		Catch ex As Exception
			Throw New Exception("serial_number_relation.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
