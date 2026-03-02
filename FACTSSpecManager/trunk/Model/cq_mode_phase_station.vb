Imports System.Xml.Serialization
Public Class cq_mode_phase_station
	Public M_mode_phase_station As New mode_phase_station
	Public M_phase_station_main As New phase_station_main

	Public Overrides Function ToString() As String
		Return M_phase_station_main.phase_station
	End Function
End Class
