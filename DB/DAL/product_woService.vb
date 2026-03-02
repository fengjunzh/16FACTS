Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class product_woService
    Public Function Add(model As FACTS.Model.product_wo) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@product_main_id", model.product_main_id),
          New SqlParameter("@wo_descr", model.wo_descr),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@validation", model.validation),
          New SqlParameter("@wo_status", model.wo_status),
          New SqlParameter("@register_date", model.register_date),
          New SqlParameter("@employee_id", model.employee_id),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3)
              }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_wo_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_wo.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.product_wo) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_main_id", model.product_main_id),
        New SqlParameter("@wo_descr", model.wo_descr),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@wo_status", model.wo_status),
        New SqlParameter("@register_date", model.register_date),
        New SqlParameter("@employee_id", model.employee_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }
            Return SqlHelper.runProcedureWithReturnValue("proc_product_wo_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("product_wo.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_wo_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("product_wo.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.product_wo) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@product_main_id", model.product_main_id),
        New SqlParameter("@wo_descr", model.wo_descr),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@wo_status", model.wo_status),
        New SqlParameter("@register_date", model.register_date),
        New SqlParameter("@employee_id", model.employee_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_wo_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_wo.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.product_wo)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.product_wo
            Dim mlist As New List(Of FACTS.Model.product_wo)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_product_wo_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.product_wo
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("product_wo.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.product_wo
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_wo
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_product_wo_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_wo.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWo(wo As String) As FACTS.Model.product_wo
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_wo
            dt = SelectByWhere("wo_descr = '" & wo & "'").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing
            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_wo.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_product_wo_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("product_wo.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.product_wo
        Try
            Dim model As New FACTS.Model.product_wo
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("product_main_id") Then If Not (IsDBNull(row("product_main_id"))) Then model.product_main_id = Convert.ToInt32(row("product_main_id"))
            If row.Table.Columns.Contains("wo_descr") Then If Not (IsDBNull(row("wo_descr"))) Then model.wo_descr = Convert.ToString(row("wo_descr"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.validation = Convert.ToBoolean(row("validation"))
            If row.Table.Columns.Contains("wo_status") Then If Not (IsDBNull(row("wo_status"))) Then model.wo_status = Convert.ToInt32(row("wo_status"))
            If row.Table.Columns.Contains("register_date") Then If Not (IsDBNull(row("register_date"))) Then model.register_date = Convert.ToDateTime(row("register_date"))
            If row.Table.Columns.Contains("employee_id") Then If Not (IsDBNull(row("employee_id"))) Then model.employee_id = Convert.ToInt32(row("employee_id"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("product_wo.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
