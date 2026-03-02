Public Class cq_product_sn_woManager
    Private _dal As New FACTS.DAL.cq_product_sn_woService
    Public Function SelectAllByWo(wo As String) As List(Of Model.cq_product_sn_wo)
        Try
            Return _dal.SelectAllByWo(wo)
        Catch ex As Exception
            Throw New Exception("cq_product_sn_wo.BLL.SelectAllByWo()::" & ex.Message)
        End Try
    End Function
    Public Function SelectBySn(sn As String) As Model.cq_product_sn_wo
        Try
            Return _dal.SelectBySn(sn)
        Catch ex As Exception
            Throw New Exception("cq_product_sn_wo.BLL.SelectBySn()::" & ex.Message)
        End Try
    End Function
End Class
