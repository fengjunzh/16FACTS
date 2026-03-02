Public Class SpecMode
	Public cq_modeM As New FACTS.Model.cq_modes
	Public TestPhaseML As New List(Of SpecPhase)
	Public PhaseStationML As New List(Of FACTS.Model.cq_product_mode_phase_station)
	Public EventShowProgress As New CATSConsoleModel.EventProgress
	Public Sub New()

	End Sub
	Public Sub New(cq_mode As FACTS.Model.cq_modes)
		Try
			cq_modeM = cq_mode

			'get TestPhaseML
			Dim cqpBll As New FACTS.BLL.cq_phasesManager
			Dim cqpML As List(Of FACTS.Model.cq_phases) = cqpBll.SelectAllByProductModeId(cq_mode.product_mode_id, True, True)

			Dim cqpmpsBll As New FACTS.BLL.cq_product_mode_phase_stationManager
			Dim cqpmpsML As List(Of FACTS.Model.cq_product_mode_phase_station) = cqpmpsBll.SelectAllByProductModeId(cq_mode.product_mode_id, True, True)

			PhaseStationML = cqpmpsML

			If cqpML Is Nothing Then Return
			Dim rc As Integer = 0

			TestPhaseML = New List(Of SpecPhase)

			For Each cqpM In cqpML
				TestPhaseML.Add(New SpecPhase(cqpM))
				rc += 1
				EventShowProgress.ShowProgress(rc, cqpML.Count)
			Next

		Catch ex As Exception
			Throw New Exception("SpecMode.New()::" & ex.Message)
		End Try
	End Sub
	Public Function CompareTo(value As SpecMode) As Boolean
		Try

			Return CompareTo(value.TestPhaseML)

		Catch ex As Exception
			Throw New Exception("SpecMode.Compare(SpecMode)::" & ex.Message)
		End Try
	End Function
	Public Function CompareTo(value As List(Of SpecPhase)) As Boolean
		Try

			Dim fM As SpecPhase

			If TestPhaseML.Count <> value.Count Then Return False

			For Each tp In TestPhaseML

				fM = value.Find(Function(o) o.cq_phaseM.phase.Trim.ToUpper = tp.cq_phaseM.phase.Trim.ToUpper)

				If fM Is Nothing Then Return False

				If tp.CompareTo(fM) = False Then Return False

			Next

			Return True

		Catch ex As Exception
			Throw New Exception("SpecMode.CompareTo(List(Of SpecPhase))::" & ex.Message)
		End Try

	End Function

End Class

