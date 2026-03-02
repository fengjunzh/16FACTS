Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class product_familyService
    Public Function Add(model As FACTS.Model.product_family) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@order_idx", model.order_idx),
          New SqlParameter("@family_name", model.family_name),
          New SqlParameter("@class_id", model.class_id),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3),
          New SqlParameter("@gen4", model.gen4),
          New SqlParameter("@gen5", model.gen5)
              }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_family_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_family.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.product_family) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@family_name", model.family_name),
        New SqlParameter("@class_id", model.class_id),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3),
        New SqlParameter("@gen4", model.gen4),
        New SqlParameter("@gen5", model.gen5)
            }
            Return SqlHelper.runProcedureWithReturnValue("proc_product_family_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("product_family.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_family_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("product_family.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.product_family) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@family_name", model.family_name),
        New SqlParameter("@class_id", model.class_id),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3),
        New SqlParameter("@gen4", model.gen4),
        New SqlParameter("@gen5", model.gen5)
            }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_family_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_family.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.product_family)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.product_family
            Dim mlist As New List(Of FACTS.Model.product_family)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_product_family_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.product_family
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("product_family.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.product_family
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_family
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_product_family_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_family.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByFamily(familyName As String) As FACTS.Model.product_family
        Try

            Dim dt As DataTable

            dt = SelectByWhere("family_name='" & familyName & "'").Tables("dt")
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing

            Return DataRowToModel(dt.Rows(0))


        Catch ex As Exception
            Throw New Exception("product_family.DAL.SelectByFamily()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_product_family_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("product_family.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.product_family
        Try
            Dim model As New FACTS.Model.product_family
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("family_name") Then If Not (IsDBNull(row("family_name"))) Then model.family_name = Convert.ToString(row("family_name"))
            If row.Table.Columns.Contains("class_id") Then If Not (IsDBNull(row("class_id"))) Then model.class_id = Convert.ToInt32(row("class_id"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            If row.Table.Columns.Contains("gen4") Then If Not (IsDBNull(row("gen4"))) Then model.gen4 = Convert.ToString(row("gen4"))
            If row.Table.Columns.Contains("gen5") Then If Not (IsDBNull(row("gen5"))) Then model.gen5 = Convert.ToInt32(row("gen5"))
            Return model
        Catch ex As Exception
            Throw New Exception("product_family.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
