Imports System.Data.SqlClient

Public Class wave_lengthService
	Public Function Add(model As FACTS.Model.wave_length) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@order_id", model.Order_id),
				New SqlParameter("@wave_length", model.Wave_length),
				New SqlParameter("@class_id", model.Class_id),
				New SqlParameter("@validity", model.Validity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_wave_length_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.wave_length) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@order_id", model.Order_id),
				New SqlParameter("@wave_length", model.Wave_length),
				New SqlParameter("@class_id", model.Class_id),
				New SqlParameter("@validity", model.Validity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_wave_length_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_wave_length_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.wave_length) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@order_id", model.Order_id),
				New SqlParameter("@wave_length", model.Wave_length),
				New SqlParameter("@class_id", model.Class_id),
				New SqlParameter("@validity", model.Validity),
				New SqlParameter("@gen1", model.Gen1),
				New SqlParameter("@gen2", model.Gen2),
				New SqlParameter("@gen3", model.Gen3),
				New SqlParameter("@gen4", model.Gen4),
				New SqlParameter("@gen5", model.Gen5)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_wave_length_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.wave_length)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.wave_length
			Dim mlist As New List(Of FACTS.Model.wave_length)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_wave_length_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.wave_length
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.wave_length
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.wave_length
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_wave_length_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.SelectById()::" & ex.Message)
		End Try
	End Function
	Public Function SelectByWavelength(wl As String) As FACTS.Model.wave_length
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.wave_length
			dt = SelectByWhere("wave_length = '" & wl & "'").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.SelectByWavelength()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_wave_length_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.wave_length
		Try
			Dim model As New FACTS.Model.wave_length
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("order_id") Then If Not (IsDBNull(row("order_id"))) Then model.Order_id = Convert.ToInt32(row("order_id"))
			If row.Table.Columns.Contains("wave_length") Then If Not (IsDBNull(row("wave_length"))) Then model.Wave_length = Convert.ToInt32(row("wave_length"))
			If row.Table.Columns.Contains("class_id") Then If Not (IsDBNull(row("class_id"))) Then model.Class_id = Convert.ToInt32(row("class_id"))
			If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.Validity = Convert.ToBoolean(row("validity"))
			If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.Gen1 = Convert.ToString(row("gen1"))
			If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.Gen2 = Convert.ToString(row("gen2"))
			If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.Gen3 = Convert.ToString(row("gen3"))
			If row.Table.Columns.Contains("gen4") Then If Not (IsDBNull(row("gen4"))) Then model.Gen4 = Convert.ToString(row("gen4"))
			If row.Table.Columns.Contains("gen5") Then If Not (IsDBNull(row("gen5"))) Then model.Gen5 = Convert.ToInt32(row("gen5"))
			Return model
		Catch ex As Exception
			Throw New Exception("wave_length.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
