Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic
Imports System.Data.SqlClient
Public Class cq_test_dataService
    Public Function SelectAllByMeasPhaseId(meas_phase_id As Integer) As List(Of FACTS.Model.cq_test_data)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.cq_test_data
            Dim mlist As New List(Of FACTS.Model.cq_test_data)

            Dim parameters As SqlParameter() = {
                                    New SqlParameter("@meas_phase_id", meas_phase_id)}

            dt = SqlHelper.runProcedureWithDataset("test_data_SelectByMeasPhaseId", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("cq_spec_spara_details.DAL.SelectAllByMeasPhaseId()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.cq_test_data
        Try
            Dim model As New FACTS.Model.cq_test_data
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("group_main_id") Then If Not (IsDBNull(row("group_main_id"))) Then model.Group_main_id = Convert.ToInt32(row("group_main_id"))
            If row.Table.Columns.Contains("group_status") Then If Not (IsDBNull(row("group_status"))) Then model.Group_status = Convert.ToString(row("Group_status"))
            If row.Table.Columns.Contains("meas_group_id") Then If Not (IsDBNull(row("meas_group_id"))) Then model.Meas_group_id = Convert.ToInt32(row("meas_group_id"))
            If row.Table.Columns.Contains("spec_detail_id") Then If Not (IsDBNull(row("spec_detail_id"))) Then model.Spec_detail_id = Convert.ToInt32(row("spec_detail_id"))
            If row.Table.Columns.Contains("meas_value") Then If Not (IsDBNull(row("meas_value"))) Then model.Meas_high_value = Convert.ToDecimal(row("meas_value"))
            If row.Table.Columns.Contains("meas_string") Then If Not (IsDBNull(row("meas_string"))) Then model.Meas_string = Convert.ToString(row("meas_string"))
            If row.Table.Columns.Contains("meas_status") Then If Not (IsDBNull(row("meas_status"))) Then model.Meas_detail_status = Convert.ToString(row("meas_status"))
            If row.Table.Columns.Contains("m2") Then If Not (IsDBNull(row("m2"))) Then model.Meas_low_value = Convert.ToDecimal(row("m2"))
            If row.Table.Columns.Contains("trace_name") Then If Not (IsDBNull(row("trace_name"))) Then model.Trace_name = Convert.ToString(row("trace_name"))
            If row.Table.Columns.Contains("x1_data") Then If Not (IsDBNull(row("x1_data"))) Then model.Meas_data_x1 = Convert.ToString(row("x1_data"))
            If row.Table.Columns.Contains("y1_data") Then If Not (IsDBNull(row("y1_data"))) Then model.Meas_data_y1 = Convert.ToString(row("y1_data"))
            If row.Table.Columns.Contains("spara") Then If Not (IsDBNull(row("spara"))) Then model.Spara = Convert.ToString(row("spara"))
            Return model
        Catch ex As Exception
            Throw New Exception("cq_test_dataService.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
