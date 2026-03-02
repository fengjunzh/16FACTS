Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class product_wo_snService
    Public Function Add(model As FACTS.Model.product_wo_sn) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@product_wo_id", model.product_wo_id),
          New SqlParameter("@product_sn_id", model.product_sn_id),
          New SqlParameter("@validity", model.validity),
          New SqlParameter("@validation", model.validation),
          New SqlParameter("@validation_date", model.validation_date),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3)
              }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_wo_sn_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.product_wo_sn) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_wo_id", model.product_wo_id),
        New SqlParameter("@product_sn_id", model.product_sn_id),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }
            Return SqlHelper.runProcedureWithReturnValue("proc_product_wo_sn_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_wo_sn_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.product_wo_sn) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@product_wo_id", model.product_wo_id),
        New SqlParameter("@product_sn_id", model.product_sn_id),
        New SqlParameter("@validity", model.validity),
        New SqlParameter("@validation", model.validation),
        New SqlParameter("@validation_date", model.validation_date),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
            }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_product_wo_sn_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.product_wo_sn)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.product_wo_sn
            Dim mlist As New List(Of FACTS.Model.product_wo_sn)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_product_wo_sn_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.product_wo_sn
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.product_wo_sn
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_wo_sn
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_product_wo_sn_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProdWoId(prodWoId As Integer) As List(Of FACTS.Model.product_wo_sn)
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_wo_sn
            Dim mlist As New List(Of FACTS.Model.product_wo_sn)

            dt = SelectByWhere("product_wo_id = " & prodWoId).Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.product_wo_sn
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.SelectByProdWoId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByProductSnId(prodcut_sn_id As Integer) As FACTS.Model.product_wo_sn
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.product_wo_sn

            dt = SelectByWhere("product_sn_id = '" & prodcut_sn_id & "'").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing
            If dt.Rows.Count > 1 Then Throw New Exception("multi records")

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.SelectByProductSnId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_product_wo_sn_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.product_wo_sn
        Try
            Dim model As New FACTS.Model.product_wo_sn
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("product_wo_id") Then If Not (IsDBNull(row("product_wo_id"))) Then model.product_wo_id = Convert.ToInt32(row("product_wo_id"))
            If row.Table.Columns.Contains("product_sn_id") Then If Not (IsDBNull(row("product_sn_id"))) Then model.product_sn_id = Convert.ToInt32(row("product_sn_id"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            If row.Table.Columns.Contains("validation") Then If Not (IsDBNull(row("validation"))) Then model.validation = Convert.ToBoolean(row("validation"))
            If row.Table.Columns.Contains("validation_date") Then If Not (IsDBNull(row("validation_date"))) Then model.validation_date = Convert.ToDateTime(row("validation_date"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("product_wo_sn.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
