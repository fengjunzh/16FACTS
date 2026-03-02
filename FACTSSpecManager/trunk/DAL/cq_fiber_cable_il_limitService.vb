Imports System.Data.SqlClient

Public Class cq_fiber_cable_il_limitService
    Public Function SelectAllByLimitId(limit_id As Integer) As List(Of FACTS.Model.cq_fiber_cable_il_limit)
        Try
            Dim dt As DataTable

            Dim model As FACTS.Model.cq_fiber_cable_il_limit
            Dim mlist As New List(Of FACTS.Model.cq_fiber_cable_il_limit)

            Dim parameters As SqlParameter() = {
                              New SqlParameter("@limit_id", limit_id)
            }

            dt = SqlHelper.runProcedureWithDataset("proc_cq_fiber_cable_il_limit_SelectAllByLimitId", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("cq_fiber_cable_il_limit.DAL.SelectAllBySelectAllByLimitIdProductModeId()::" & ex.Message)
        End Try
    End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.cq_fiber_cable_il_limit
        Try
            Dim model As New FACTS.Model.cq_fiber_cable_il_limit

            If IsNothing(row) Then Return Nothing

            If Not (IsDBNull(row("db_id"))) Then model.Db_id = Convert.ToInt32(row("db_id"))
            If Not (IsDBNull(row("limit_id"))) Then model.Limit_id = Convert.ToInt32(row("limit_id"))
            If Not (IsDBNull(row("limit_name"))) Then model.Limit_name = Convert.ToString(row("limit_name"))
            If Not (IsDBNull(row("wave_length_id"))) Then model.Wave_length_id = Convert.ToInt32(row("wave_length_id"))
            If Not (IsDBNull(row("wave_length"))) Then model.Wave_length = Convert.ToInt32(row("wave_length"))
            If Not (IsDBNull(row("il_limit"))) Then model.Il_limit = Convert.ToDecimal(row("il_limit"))

            Return model

        Catch ex As Exception
            Throw New Exception("cq_fiber_cable_il_limit.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
