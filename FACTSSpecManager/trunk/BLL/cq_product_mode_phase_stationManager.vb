Imports System
Imports System.Collections.Generic

Public Class cq_product_mode_phase_stationManager
	Private _dal As New FACTS.DAL.cq_product_mode_phase_stationService
	Public Function SelectAllByProductModeId(product_mode_id As Integer, validation As Boolean, validity As Boolean) As List(Of Model.cq_product_mode_phase_station)
		Try
			Return _dal.SelectAllByProductModeId(product_mode_id, validation, validity)
		Catch ex As Exception
			Throw New Exception("cq_phase_station.BLL.SelectAllByProductModeId()::" & ex.Message)
		End Try
	End Function
End Class
