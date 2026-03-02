Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class customerService
    Public Function Add(model As FACTS.Model.customer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@cust_name", model.cust_name),
          New SqlParameter("@cust_desc", model.cust_desc),
          New SqlParameter("@validity", model.validity)
        }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_customer_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("customer.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.customer) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@cust_name", model.cust_name),
        New SqlParameter("@cust_desc", model.cust_desc),
        New SqlParameter("@validity", model.validity)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_customer_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("customer.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_customer_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("customer.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.customer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@cust_name", model.cust_name),
        New SqlParameter("@cust_desc", model.cust_desc),
        New SqlParameter("@validity", model.validity)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_customer_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("customer.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.customer)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.customer
            Dim mlist As New List(Of FACTS.Model.customer)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_customer_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.customer
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("customer.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.customer
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.customer
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_customer_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("customer.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByName(name As String) As FACTS.Model.customer
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.customer

            dt = SelectByWhere("cust_name = '" & name & "'").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("customer.DAL.SelectByName()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_customer_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("customer.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.customer
        Try
            Dim model As New FACTS.Model.customer
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("cust_name") Then If Not (IsDBNull(row("cust_name"))) Then model.cust_name = Convert.ToString(row("cust_name"))
            If row.Table.Columns.Contains("cust_desc") Then If Not (IsDBNull(row("cust_desc"))) Then model.cust_desc = Convert.ToString(row("cust_desc"))
            If row.Table.Columns.Contains("validity") Then If Not (IsDBNull(row("validity"))) Then model.validity = Convert.ToBoolean(row("validity"))
            Return model
        Catch ex As Exception
            Throw New Exception("customer.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
