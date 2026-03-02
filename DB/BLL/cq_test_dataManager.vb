Public Class cq_test_dataManager
    Private _dal As New FACTS.DAL.cq_test_dataService
    Public Function SelectAllByMeasPhaseId(meas_phase_id As Integer) As List(Of Model.cq_test_data)
        Try

            Return _dal.SelectAllByMeasPhaseId(meas_phase_id)

        Catch ex As Exception
            Throw New Exception("cq_test_data.BLL.SelectAllByMeasPhaseId()::" & ex.Message)
        End Try
    End Function
End Class
