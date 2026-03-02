Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class product_modeService

    Public Function Add(model As FACTS.Model.product_mode) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@product_main_id", model.product_main_id),
          New SqlParameter("@mode_id", model.mode_id),
          New SqlParameter("@order_idx", model.order_idx),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@validation_date", model.validation_date),
          New SqlParameter("@validation", model.validation)
        }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_mode_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_mode.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.product_mode) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_main_id", model.product_main_id),
        New SqlParameter("@mode_id", model.mode_id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@validation", model.validation)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_product_mode_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("product_mode.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_mode_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("product_mode.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.product_mode) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@product_main_id", model.product_main_id),
        New SqlParameter("@mode_id", model.mode_id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@validation", model.validation)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_mode_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_mode.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.product_mode)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.product_mode
            Dim mlist As New List(Of FACTS.Model.product_mode)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_product_mode_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.product_mode
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("product_mode.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.product_mode
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_mode
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_product_mode_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_mode.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProductMainIdAndModeId(product_main_id As Integer, mode_id As Integer) As FACTS.Model.product_mode
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_mode

            dt = SelectByWhere("product_main_id = '" & product_main_id & "' And mode_id ='" & mode_id & "'").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing
            If dt.Rows.Count > 1 Then Throw New Exception("more than one product_mode")

            model = DataRowToModel(dt.Rows(0))

            Return model

        Catch ex As Exception
            Throw New Exception("product_mode.DAL.SelectByProductMainIdAndModeId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_product_mode_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("product_mode.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.product_mode
        Try
            Dim model As New FACTS.Model.product_mode
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("product_main_id") Then If Not (IsDBNull(row("product_main_id"))) Then model.product_main_id = Convert.ToInt32(row("product_main_id"))
            If row.Table.Columns.Contains("mode_id") Then If Not (IsDBNull(row("mode_id"))) Then model.mode_id = Convert.ToInt32(row("mode_id"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation_date") Then If Not (IsDBNull(row("validation_date"))) Then model.validation_date = Convert.ToDateTime(row("validation_date"))
            If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.validation = Convert.ToBoolean(row("validation"))
            Return model
        Catch ex As Exception
            Throw New Exception("product_mode.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
