Option Strict Off
Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Public Class cq_phases_statusService
    Public Function SelectAll(product As String, serialNumber As String, mode As String) As List(Of FACTS.Model.cq_phases_status)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.cq_phases_status
            Dim mlist As New List(Of FACTS.Model.cq_phases_status)

            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_name", product),
        New SqlParameter("@product_serial_num", serialNumber),
         New SqlParameter("@mode", mode)
      }

            dt = SqlHelper.runProcedureWithDataset("[proc_cq_meas_phases_status]", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll(product As String, serialNumber As String, mode As String, phase_station_main_id As Integer) As List(Of FACTS.Model.cq_phases_status)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.cq_phases_status
            Dim mlist As New List(Of FACTS.Model.cq_phases_status)

            Dim parameters As SqlParameter() = {
        New SqlParameter("@product_name", product),
        New SqlParameter("@product_serial_num", serialNumber),
        New SqlParameter("@mode", mode),
        New SqlParameter("@phase_station_main_id", phase_station_main_id)
      }

            dt = SqlHelper.runProcedureWithDataset("[proc_cq_meas_phases_status_v3]", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByPhase(product As String, serialNumber As String, mode As String, phase As String) As FACTS.Model.cq_phases_status
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.cq_phases_status
            'Dim mlist As New List(Of CATS.Model.cq_phases_status)

            Dim parameters As SqlParameter() =
            {
                New SqlParameter("@product_name", product),
                New SqlParameter("@product_serial_num", serialNumber),
                New SqlParameter("@mode", mode),
                New SqlParameter("@phase", phase)
            }

            dt = SqlHelper.runProcedureWithDataset("[proc_cq_meas_phase_statusByPhase]", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing
            If dt.Rows.Count > 1 Then Throw New Exception("multi recorders")

            model = DataRowToModel(dt.Rows(0))

            Dim mpDAL As New FACTS.DAL.meas_phaseService
            model.M_meas_phase = mpDAL.SelectById(model.meas_phase_id)

            Return model

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.SelectByPhase()::" & ex.Message)
        End Try
    End Function

    Public Function SelectMostRecentPhaseStatus(product As String, serialNumber As String, mode As String, phase_station_main_id As Integer) As List(Of FACTS.Model.cq_phases_status)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.cq_phases_status
            Dim mlist As New List(Of FACTS.Model.cq_phases_status)

            Dim parameters As SqlParameter() =
            {
                New SqlParameter("@product_name", product),
                New SqlParameter("@product_serial_num", serialNumber),
                New SqlParameter("@mode", mode),
                New SqlParameter("@phase_station_main_id", phase_station_main_id)
            }

            dt = SqlHelper.runProcedureWithDataset("[proc_cq_meas_phases_status_v3]", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            Dim meas_phaseService As New meas_phaseService

            For Each row As DataRow In dt.Rows
                model = DataRowToModel(row)
                mlist.Add(model)
                model.M_meas_phase = meas_phaseService.SelectById(model.meas_phase_id)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("SelectMostRecentPhaseStatus()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAllPhaseStatusBySn(serialNumber As String, factory As String, testMode As String, phaseStation As String) As List(Of FACTS.Model.cq_phases_status)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.cq_phases_status
            Dim mlist As New List(Of FACTS.Model.cq_phases_status)

            Dim parameters As SqlParameter() =
            {
                New SqlParameter("@serialNumber", serialNumber),
                New SqlParameter("@Factory", factory),
                New SqlParameter("@testMode", testMode),
                New SqlParameter("@phaseStation", phaseStation)
            }

            dt = SqlHelper.runProcedureWithDataset("[ds_sn_phase_select]", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("SelectAllPhaseStatusBySn()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.cq_phases_status
        Try
            Dim model As New FACTS.Model.cq_phases_status

            If IsNothing(row) Then Return Nothing

            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.meas_phase_id = Convert.ToString(row("id"))
            If row.Table.Columns.Contains("phase") Then If Not (IsDBNull(row("phase"))) Then model.phase = Convert.ToString(row("phase"))
            If row.Table.Columns.Contains("phase_status") Then If Not (IsDBNull(row("phase_status"))) Then model.phase_status = Convert.ToString(row("phase_status"))
            If row.Table.Columns.Contains("start_datetime") Then If Not (IsDBNull(row("start_datetime"))) Then model.start_datetime = Convert.ToDateTime(row("start_datetime"))
            Return model

        Catch ex As Exception
            Throw New Exception("cq_phases_status.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function

End Class
