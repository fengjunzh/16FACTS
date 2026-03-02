Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Partial Public Class meas_groupService
    Public Function Add(model As FACTS.Model.meas_group) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
          New SqlParameter("@meas_phase_id", model.meas_phase_id),
          New SqlParameter("@order_idx", model.order_idx),
          New SqlParameter("@group_main_id", model.group_main_id),
          New SqlParameter("@group_status", model.group_status),
          New SqlParameter("@test_idx", model.test_idx),
          New SqlParameter("@last_test_flag", model.last_test_flag),
          New SqlParameter("@gen1", model.gen1),
          New SqlParameter("@gen2", model.gen2),
          New SqlParameter("@gen3", model.gen3)
        }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_group_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_group.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.meas_group) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@meas_phase_id", model.meas_phase_id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@group_main_id", model.group_main_id),
        New SqlParameter("@group_status", model.group_status),
        New SqlParameter("@test_idx", model.test_idx),
        New SqlParameter("@last_test_flag", model.last_test_flag),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_meas_group_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("meas_group.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_group_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("meas_group.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function Update(model As FACTS.Model.meas_group) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@id", model.id),
        New SqlParameter("@meas_phase_id", model.meas_phase_id),
        New SqlParameter("@order_idx", model.order_idx),
        New SqlParameter("@group_main_id", model.group_main_id),
        New SqlParameter("@group_status", model.group_status),
        New SqlParameter("@test_idx", model.test_idx),
        New SqlParameter("@last_test_flag", model.last_test_flag),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_group_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_group.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.meas_group)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_group
            Dim mlist As New List(Of FACTS.Model.meas_group)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_meas_group_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_group
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_group.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.meas_group
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.meas_group
            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_meas_group_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("meas_group.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_meas_group_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("meas_group.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function SelectBy_meas_phase_id(meas_phase_id As Integer) As List(Of FACTS.Model.meas_group)
        Try
            Dim resp As New List(Of FACTS.Model.meas_group)
            Dim respItem As FACTS.Model.meas_group
            Dim dt As DataTable


            dt = SelectByWhere("meas_phase_id=" & meas_phase_id).Tables("dt")

            If dt Is Nothing Then Return Nothing
            If dt.Rows.Count = 0 Then Return Nothing

            For Each r As DataRow In dt.Rows
                respItem = New FACTS.Model.meas_group
                respItem = DataRowToModel(r)
                resp.Add(respItem)
            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("meas_group.DAL.SelectBy_meas_phase_id()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.meas_group
        Try
            Dim model As New FACTS.Model.meas_group
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("meas_phase_id") Then If Not (IsDBNull(row("meas_phase_id"))) Then model.meas_phase_id = Convert.ToInt32(row("meas_phase_id"))
            If row.Table.Columns.Contains("order_idx") Then If Not (IsDBNull(row("order_idx"))) Then model.order_idx = Convert.ToInt32(row("order_idx"))
            If row.Table.Columns.Contains("group_main_id") Then If Not (IsDBNull(row("group_main_id"))) Then model.group_main_id = Convert.ToInt32(row("group_main_id"))
            If row.Table.Columns.Contains("group_status") Then If Not (IsDBNull(row("group_status"))) Then model.group_status = Convert.ToString(row("group_status"))
            If row.Table.Columns.Contains("test_idx") Then If Not (IsDBNull(row("test_idx"))) Then model.test_idx = Convert.ToInt32(row("test_idx"))
            If row.Table.Columns.Contains("last_test_flag") Then If Not (IsDBNull(row("last_test_flag"))) Then model.last_test_flag = Convert.ToBoolean(row("last_test_flag"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("meas_group.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
