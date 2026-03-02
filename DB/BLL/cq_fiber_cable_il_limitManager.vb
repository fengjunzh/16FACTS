Public Class cq_fiber_cable_il_limitManager
    Private _dal As New FACTS.DAL.cq_fiber_cable_il_limitService
    Public Function SelectAllByLimitId(limit_id As Integer) As List(Of Model.cq_fiber_cable_il_limit)
        Try
            Return _dal.SelectAllByLimitId(limit_id)
        Catch ex As Exception
            Throw New Exception("cq_fiber_cable_il_limitManager.BLL.SelectAllByLimitId()::" & ex.Message)
        End Try
    End Function
End Class
