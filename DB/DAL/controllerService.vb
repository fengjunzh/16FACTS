Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class controllerService
    Public Function Add(model As FACTS.Model.controller) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@name", model.name),
        New SqlParameter("@location", model.location),
        New SqlParameter("@owner_id", model.owner_id),
        New SqlParameter("@factory_id", model.factory_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_controller_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("controller.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.controller) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@name", model.name),
        New SqlParameter("@location", model.location),
        New SqlParameter("@owner_id", model.owner_id),
        New SqlParameter("@factory_id", model.factory_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_controller_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("controller.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_controller_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("controller.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.controller) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@name", model.name),
        New SqlParameter("@location", model.location),
        New SqlParameter("@owner_id", model.owner_id),
        New SqlParameter("@factory_id", model.factory_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_controller_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("controller.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.controller)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.controller
            Dim mlist As New List(Of FACTS.Model.controller)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_controller_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.controller
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("controller.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.controller
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.controller
            Dim parameters As SqlParameter() = {
                        New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_controller_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("controller.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
            New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_controller_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("controller.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByFilter(whereString As String) As List(Of Model.controller)
        Try
            Dim resp As New List(Of Model.controller)
            Dim respItem As Model.controller

            Dim dt As DataTable

            dt = SelectByWhere(whereString).Tables("dt")

            If dt Is Nothing Then Return Nothing

            If dt.Rows.Count = 0 Then Return Nothing

            For Each dr In dt.Rows
                respItem = New Model.controller
                respItem = DataRowToModel(dr)
                resp.Add(respItem)
            Next

            Return resp


        Catch ex As Exception
            Throw New Exception("controller.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.controller
        Try
            Dim model As New FACTS.Model.controller
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("name") Then If Not (IsDBNull(row("name"))) Then model.name = Convert.ToString(row("name"))
            If row.Table.Columns.Contains("location") Then If Not (IsDBNull(row("location"))) Then model.location = Convert.ToString(row("location"))
            If row.Table.Columns.Contains("owner_id") Then If Not (IsDBNull(row("owner_id"))) Then model.owner_id = Convert.ToInt32(row("owner_id"))
            If row.Table.Columns.Contains("factory_id") Then If Not (IsDBNull(row("factory_id"))) Then model.factory_id = Convert.ToInt32(row("factory_id"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("controller.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
