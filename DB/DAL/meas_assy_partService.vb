Imports System
Imports System.Data
Imports System.Text
Imports System.Data.SqlClient

Partial Public Class meas_assy_partService

    Public Function Add(model As FACTS.Model.meas_assy_part) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
    New SqlParameter("@meas_phase_id", model.meas_phase_id),
    New SqlParameter("@part_model", model.part_model),
    New SqlParameter("@part_sn", model.part_sn),
    New SqlParameter("@part_idx", model.part_idx),
    New SqlParameter("@part_hw", model.part_hw),
    New SqlParameter("@part_fw", model.part_fw),
    New SqlParameter("@part_tilt_min", model.part_tilt_min),
    New SqlParameter("@part_tilt_max", model.part_tilt_max),
    New SqlParameter("@part_desc", model.part_desc),
    New SqlParameter("@part_type", model.part_type)
  }
            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_assy_part_Add", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.Add()::" & ex.Message)
        End Try
    End Function
    Public Function AddReturnId(model As FACTS.Model.meas_assy_part) As Integer
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@meas_phase_id", model.meas_phase_id),
  New SqlParameter("@part_model", model.part_model),
  New SqlParameter("@part_sn", model.part_sn),
  New SqlParameter("@part_idx", model.part_idx),
  New SqlParameter("@part_hw", model.part_hw),
  New SqlParameter("@part_fw", model.part_fw),
  New SqlParameter("@part_tilt_min", model.part_tilt_min),
  New SqlParameter("@part_tilt_max", model.part_tilt_max),
  New SqlParameter("@part_desc", model.part_desc),
  New SqlParameter("@part_type", model.part_type)
}
            Return SqlHelper.runProcedureWithReturnValue("proc_meas_assy_part_Add", parameters, rowsAffected)
        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.AddReturnId()::" & ex.Message)
        End Try
    End Function
    Public Function Delete(id As Integer) As Boolean
    Try
      Dim rowsAffected As Integer
      Dim parameters As SqlParameter() = {New SqlParameter("@id", id)}

      rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_assy_part_DeleteRow", parameters)
      Return IIf(rowsAffected > 0, True, False)

    Catch ex As Exception
      Throw New Exception("meas_assy_part.DAL.Delete()::" & ex.Message)
    End Try
  End Function
    Public Function Update(model As FACTS.Model.meas_assy_part) As Boolean
        Try
            Dim rowsAffected As Integer
            Dim parameters As SqlParameter() = {
  New SqlParameter("@id", model.id),
  New SqlParameter("@meas_phase_id", model.meas_phase_id),
  New SqlParameter("@part_model", model.part_model),
  New SqlParameter("@part_sn", model.part_sn),
  New SqlParameter("@part_idx", model.part_idx),
  New SqlParameter("@part_hw", model.part_hw),
  New SqlParameter("@part_fw", model.part_fw),
  New SqlParameter("@part_tilt_min", model.part_tilt_min),
  New SqlParameter("@part_tilt_max", model.part_tilt_max),
  New SqlParameter("@part_desc", model.part_desc),
  New SqlParameter("@part_type", model.part_type)
}

            rowsAffected = SqlHelper.runProcedureWithAffectedRow("proc_meas_assy_part_Update", parameters)
            Return IIf(rowsAffected > 0, True, False)
        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.Update()::" & ex.Message)
        End Try
    End Function
    Public Function SelectAll() As List(Of FACTS.Model.meas_assy_part)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_assy_part
            Dim mlist As New List(Of FACTS.Model.meas_assy_part)

            Dim parameters As SqlParameter() = {}
            dt = SqlHelper.runProcedureWithDataset("proc_meas_assy_part_SelectAll", parameters, "dt").Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_assy_part
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.SelectAll()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByMeasPhaseId(id As Integer) As List(Of FACTS.Model.meas_assy_part)
        Try
            Dim dt As DataTable
            Dim model As FACTS.Model.meas_assy_part
            Dim mlist As New List(Of FACTS.Model.meas_assy_part)

            dt = SelectByWhere("meas_phase_id = " & id).Tables("dt")

            If dt.Rows.Count = 0 Then Return Nothing

            For Each row As DataRow In dt.Rows
                model = New FACTS.Model.meas_assy_part
                model = DataRowToModel(row)
                mlist.Add(model)
            Next

            Return mlist

        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.SelectByMeasPhaseId()::" & ex.Message)
        End Try
    End Function
    Public Function SelectById(id As Integer) As FACTS.Model.meas_assy_part
        Try
            Dim dt As DataTable
            Dim model As New FACTS.Model.meas_assy_part
            Dim parameters As SqlParameter() = {
                              New SqlParameter("@id", id)}

            dt = SqlHelper.runProcedureWithDataset("proc_meas_assy_part_SelectRow", parameters, "dt").Tables("dt")
            If dt.Rows.Count = 0 Then Return Nothing

            model = DataRowToModel(dt.Rows(0))
            Return model

        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.SelectById()::" & ex.Message)
        End Try
    End Function
    Public Function SelectByWhere(whereString As String) As DataSet
    Try
      Dim ds As DataSet

      Dim parameters As SqlParameter() = {
            New SqlParameter("@where", whereString)}

      ds = SqlHelper.runProcedureWithDataset("proc_meas_assy_part_SelectByWhere", parameters, "dt")

      Return ds

    Catch ex As Exception
      Throw New Exception("meas_assy_part.DAL.SelectByWhere()::" & ex.Message)
    End Try
  End Function
    Public Function DataRowToModel(row As DataRow) As FACTS.Model.meas_assy_part
        Try
            Dim model As New FACTS.Model.meas_assy_part
            If IsNothing(row) Then Return Nothing
            If row.Table.Columns.Contains("id") Then If Not (IsDBNull(row("id"))) Then model.id = Convert.ToInt32(row("id"))
            If row.Table.Columns.Contains("meas_phase_id") Then If Not (IsDBNull(row("meas_phase_id"))) Then model.meas_phase_id = Convert.ToInt32(row("meas_phase_id"))
            If row.Table.Columns.Contains("part_model") Then If Not (IsDBNull(row("part_model"))) Then model.part_model = Convert.ToString(row("part_model"))
            If row.Table.Columns.Contains("part_sn") Then If Not (IsDBNull(row("part_sn"))) Then model.part_sn = Convert.ToString(row("part_sn"))
            If row.Table.Columns.Contains("part_idx") Then If Not (IsDBNull(row("part_idx"))) Then model.part_idx = Convert.ToInt32(row("part_idx"))
            If row.Table.Columns.Contains("part_hw") Then If Not (IsDBNull(row("part_hw"))) Then model.part_hw = Convert.ToString(row("part_hw"))
            If row.Table.Columns.Contains("part_fw") Then If Not (IsDBNull(row("part_fw"))) Then model.part_fw = Convert.ToString(row("part_fw"))
            If row.Table.Columns.Contains("part_tilt_min") Then If Not (IsDBNull(row("part_tilt_min"))) Then model.part_tilt_min = Convert.ToDecimal(row("part_tilt_min"))
            If row.Table.Columns.Contains("part_tilt_max") Then If Not (IsDBNull(row("part_tilt_max"))) Then model.part_tilt_max = Convert.ToDecimal(row("part_tilt_max"))
            If row.Table.Columns.Contains("part_desc") Then If Not (IsDBNull(row("part_desc"))) Then model.part_desc = Convert.ToString(row("part_desc"))
            If row.Table.Columns.Contains("part_type") Then If Not (IsDBNull(row("part_type"))) Then model.part_type = Convert.ToString(row("part_type"))
            Return model
        Catch ex As Exception
            Throw New Exception("meas_assy_part.DAL.DataRowToModel()::" & ex.Message)
        End Try
    End Function
End Class
