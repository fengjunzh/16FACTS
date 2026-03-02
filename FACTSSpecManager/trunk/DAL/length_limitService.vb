Imports System.Data.SqlClient
Public Class length_limitService
	Public Function Add(model As FACTS.Model.length_limit) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@length_range_lower", model.Length_range_lower),
				New SqlParameter("@length_range_upper", model.Length_range_upper),
				New SqlParameter("@length_limit_low", model.Length_limit_low),
				New SqlParameter("@length_limit_up", model.Length_limit_up)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_length_limit_Add", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.length_limit) As Integer
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@length_range_lower", model.Length_range_lower),
				New SqlParameter("@length_range_upper", model.Length_range_upper),
				New SqlParameter("@length_limit_low", model.Length_limit_low),
				New SqlParameter("@length_limit_up", model.Length_limit_up)
			}
			Return SqlHelper.runProcedureWithReturnValue("dbo.proc_length_limit_Add", parameters, rowsAffected)
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_length_limit_DeleteRow", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.length_limit) As Boolean
		Try
			Dim rowsAffected As Integer
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", model.Id),
				New SqlParameter("@length_range_lower", model.Length_range_lower),
				New SqlParameter("@length_range_upper", model.Length_range_upper),
				New SqlParameter("@length_limit_low", model.Length_limit_low),
				New SqlParameter("@length_limit_up", model.Length_limit_up)
			}
			rowsAffected = SqlHelper.runProcedureWithAffectedRow("dbo.proc_length_limit_Update", parameters)
			Return IIf(rowsAffected > 0, True, False)
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.length_limit)
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.length_limit
			Dim mlist As New List(Of FACTS.Model.length_limit)
			Dim parameters As SqlParameter() = {}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_length_limit_SelectAll", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			For Each row As DataRow In dt.Rows
				model = New FACTS.Model.length_limit
				model = DataRowToModel(row)
				mlist.Add(model)
			Next
			Return mlist
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.SelectAll()::" & ex.Message)
		End Try
	End Function


	Public Function SelectById(id As Integer) As FACTS.Model.length_limit
		Try
			Dim dt As DataTable
			Dim model As FACTS.Model.length_limit
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@id", id)
			}
			dt = SqlHelper.runProcedureWithDataset("dbo.proc_length_limit_SelectRow", parameters, "dt").Tables("dt")
			If dt.Rows.Count = 0 Then Return Nothing
			model = DataRowToModel(dt.Rows(0))
			Return model
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.SelectById()::" & ex.Message)
		End Try
	End Function


	Public Function SelectByWhere(whereString As String) As DataSet
		Try
			Dim ds As DataSet
			Dim parameters As SqlParameter() =
			{
				New SqlParameter("@where", whereString)
			}
			ds = SqlHelper.runProcedureWithDataset("dbo.proc_length_limit_SelectByWhere", parameters, "dt")
			Return ds
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.SelectByWhere()::" & ex.Message)
		End Try
	End Function


	Public Shared Function DataRowToModel(row As DataRow) As FACTS.Model.length_limit
		Try
			Dim model As New FACTS.Model.length_limit
			If IsNothing(row) Then Return Nothing
			If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.Id = Convert.ToInt32(row("id"))
			If row.Table.Columns.Contains("length_range_lower") Then If Not (IsDBNull(row("length_range_lower"))) Then model.Length_range_lower = Convert.ToInt32(row("length_range_lower"))
			If row.Table.Columns.Contains("length_range_upper") Then If Not (IsDBNull(row("length_range_upper"))) Then model.Length_range_upper = Convert.ToInt32(row("length_range_upper"))
			If row.Table.Columns.Contains("length_limit_low") Then If Not (IsDBNull(row("length_limit_low"))) Then model.Length_limit_low = Convert.ToDecimal(row("length_limit_low"))
			If row.Table.Columns.Contains("length_limit_up") Then If Not (IsDBNull(row("length_limit_up"))) Then model.Length_limit_up = Convert.ToDecimal(row("length_limit_up"))
			Return model
		Catch ex As Exception
			Throw New Exception("length_limit.DAL.DataRowToModel()::" & ex.Message)
		End Try
	End Function

End Class
