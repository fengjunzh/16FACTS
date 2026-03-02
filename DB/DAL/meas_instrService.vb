Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class meas_instrService
    Public Function Add(model As FACTS.Model.meas_instr) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@meas_phase_id", model.meas_phase_id),
        New SqlParameter("@instr_main_id", model.instr_main_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_instr_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.meas_instr) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
        New SqlParameter("@meas_phase_id", model.meas_phase_id),
        New SqlParameter("@instr_main_id", model.instr_main_id),
        New SqlParameter("@gen1", model.gen1),
        New SqlParameter("@gen2", model.gen2),
        New SqlParameter("@gen3", model.gen3)
      }
            Return SqlHelper.runProcedureWithReturnValue("proc_meas_instr_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_instr_DeleteRow", parameters)
            Return IIf(rowsAffected > 0, True, False)

        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.Delete()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.meas_instr)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_instr
            Dim mlist As New List(Of FACTS.Model.meas_instr)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_meas_instr_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_instr
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.meas_instr
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.meas_instr
            Dim parameters As SqlParameter() = {
                        New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_meas_instr_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
        Try
            Dim ds As DataSet

            Dim parameters As SqlParameter() = {
                  New SqlParameter("@where", whereString)}

            ds = SqlHelper.runProcedureWithDataset("proc_meas_instr_SelectByWhere", parameters, "dt")

            Return ds

        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.SelectByWhere()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.meas_instr

        Try
            Dim model As New FACTS.Model.meas_instr
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("meas_phase_id") Then If Not (IsDBNull(row("meas_phase_id"))) Then model.meas_phase_id = Convert.ToInt32(row("meas_phase_id"))
            If row.Table.Columns.Contains("instr_main_id") Then If Not (IsDBNull(row("instr_main_id"))) Then model.instr_main_id = Convert.ToInt32(row("instr_main_id"))
            If row.Table.Columns.Contains("gen1") Then If Not (IsDBNull(row("gen1"))) Then model.gen1 = Convert.ToString(row("gen1"))
            If row.Table.Columns.Contains("gen2") Then If Not (IsDBNull(row("gen2"))) Then model.gen2 = Convert.ToString(row("gen2"))
            If row.Table.Columns.Contains("gen3") Then If Not (IsDBNull(row("gen3"))) Then model.gen3 = Convert.ToString(row("gen3"))
            Return model
        Catch ex As Exception
            Throw New Exception("meas_instr.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
