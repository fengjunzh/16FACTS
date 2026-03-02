Imports System
Imports System.Collections.Generic
Public Class cq_mode_phase_stationManager
	Private _dal As New FACTS.DAL.cq_mode_phase_stationService
	Public Function SelectAllByMode(mode As String, validation As Boolean, validity As Boolean) As List(Of Model.cq_mode_phase_station)
		Try
			Return _dal.SelectAllByMode(mode, validation, validity)
		Catch ex As Exception
			Throw New Exception("cq_mode_phase_stationManager.BLL.SelectAllByMode()::" & ex.Message)
		End Try
	End Function
End Class
