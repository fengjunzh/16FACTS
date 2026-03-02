Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class mode_specService
    Public Function Add(model As FACTS.Model.mode_spec) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@product_mode_id", model.product_mode_id),
          New SqlParameter("@spec_main_id", model.spec_main_id),
          New SqlParameter("@order_idx", model.order_idx),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@validation_date", model.validation_date),
          New SqlParameter("@validation", model.validation),
          New SqlParameter("@status", model.status)
        }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_mode_spec_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.mode_spec) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_mode_id", model.product_mode_id),
        New SqlParameter("@spec_main_id", model.spec_main_id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@status", model.status)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_mode_spec_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_mode_spec_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.mode_spec) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@product_mode_id", model.product_mode_id),
        New SqlParameter("@spec_main_id", model.spec_main_id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@status", model.status)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_mode_spec_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.mode_spec)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.mode_spec
            Dim mlist As New List(Of FACTS.Model.mode_spec)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_mode_spec_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.mode_spec
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.mode_spec
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.mode_spec
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_mode_spec_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(product_mode_id As Integer, spec_main_id As Integer) As FACTS.Model.mode_spec
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.mode_spec

            dt = SelectByWhere("product_mode_id=" & product_mode_id & " and " & "spec_main_id=" & spec_main_id).Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.SelectById(product_mode_id,spec_main_id)::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProductModeId(product_mode_id As Integer) As List(Of FACTS.Model.mode_spec)
        Try
            Dim dt As DataTable
            Dim resp As New List(Of FACTS.Model.mode_spec)

            dt = SelectByWhere("product_mode_id=" & product_mode_id).Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row In dt.Rows
                resp.Add(DataRowToModel(row))
            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.SelectByProductModeId(product_mode_id)::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_mode_spec_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.mode_spec
        Try
            Dim model As New FACTS.Model.mode_spec
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("product_mode_id") Then If Not (IsDBNull(row("product_mode_id"))) Then model.product_mode_id = Convert.ToInt32(row("product_mode_id"))
            If row.Table.Columns.Contains("spec_main_id") Then If Not (IsDBNull(row("spec_main_id"))) Then model.spec_main_id = Convert.ToInt32(row("spec_main_id"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation_date") Then If Not (IsDBNull(row("validation_date"))) Then model.validation_date = Convert.ToDateTime(row("validation_date"))
            If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.validation = Convert.ToBoolean(row("validation"))
            If row.Table.Columns.Contains("status") Then If Not (IsDBNull(row("status"))) Then model.status = Convert.ToInt16(row("status"))
            Return model
        Catch ex As Exception
            Throw New Exception("mode_spec.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
