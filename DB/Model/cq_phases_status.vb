Imports System.Xml.Serialization
Imports System
Public Class cq_phases_status
    Public meas_phase_id As Integer
    Public phase As String
    Public phase_status As String
    Public start_datetime As DateTime
    Public M_meas_phase As New FACTS.Model.meas_phase
End Class
