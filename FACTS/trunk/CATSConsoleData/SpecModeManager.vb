Public Class SpecModeManager
	Private _EXISTED_MODEL As CATSConsoleModel.SpecMode
	Public EventShowProgress As New CATSConsoleModel.EventProgress
	Public EventShowMessage As New CATSConsoleModel.EventMessage
	Public WriteOnly Property ExistedModel As CATSConsoleModel.SpecMode
		Set(value As CATSConsoleModel.SpecMode)
			_EXISTED_MODEL = value
		End Set
	End Property
	Private Function CreateInstance(product_main_id As Integer, data As FACTS.Model.cq_modes) As Integer
		Try
			Dim resp As Integer 'product_mode_id

			Dim mdBll As New FACTS.BLL.modeManager
			Dim mdM As New FACTS.Model.mode
			Dim md_id As Integer

			'add Mode
			mdM.mode = data.mode
			mdM.validity = True
			md_id = mdBll.AddReturnId(mdM)

			Dim pmBll As New FACTS.BLL.product_modeManager
			Dim pmM As New FACTS.Model.product_mode


			pmM.product_main_id = product_main_id
			pmM.mode_id = md_id
			pmM.order_idx = data.order_idx
			pmM.validation = data.validation
			pmM.validity = data.validity
			pmM.validation_date = Now

			resp = pmBll.AddReturnId(pmM)

			Return resp

		Catch ex As Exception
			Throw New Exception("SpecModeManager.CreateInstance(Integer,cq_modes)::" & ex.Message)
		End Try

	End Function
	Private Sub UpdateValidationTime(product_mode_id As Integer)
		Try
			Dim pmBll As New FACTS.BLL.product_modeManager
			Dim pmM As FACTS.Model.product_mode

			pmM = pmBll.SelectById(product_mode_id)

			pmM.validation_date = Now

			pmBll.Update(pmM)

		Catch ex As Exception
			Throw New Exception("SpecModeManager.UpdateValidationTime(Integer)::" & ex.Message)
		End Try
	End Sub
	''' <summary>
	''' Add into product_mode table
	''' </summary>
	''' <param name="product_main_id"></param>
	''' <param name="data"></param>
	''' <returns>product_mode_id</returns>
	Private Function Create(product_main_id As Integer, data As FACTS.Model.cq_modes) As Integer
		Try

			If _EXISTED_MODEL Is Nothing Then
				'add mode
				Return CreateInstance(product_main_id, data)
			Else
				If _EXISTED_MODEL.cq_modeM.CompareTo(data) = True Then
					UpdateValidationTime(_EXISTED_MODEL.cq_modeM.product_mode_id)
					'update product_mode validation_datetime
					Return _EXISTED_MODEL.cq_modeM.product_mode_id
				Else
					'add mode
					Return CreateInstance(product_main_id, data)
				End If
			End If

		Catch ex As Exception
			Throw New Exception("SpecModeManager.Create(Integer,cq_modes)::" & ex.Message)
		End Try

	End Function
	Private Function Create(product_mode_id As Integer, ByVal phase_stationML As List(Of FACTS.Model.cq_product_mode_phase_station)) As Boolean
		Try
			Dim pmpsBll As New FACTS.BLL.product_mode_phase_stationManager

			If _EXISTED_MODEL IsNot Nothing Then
				If _EXISTED_MODEL.PhaseStationML IsNot Nothing Then
					For Each ps In _EXISTED_MODEL.PhaseStationML
						pmpsBll.Delete(ps.M_product_mode_phase_station.id)
					Next
				End If
			End If

			Dim psmBll As New FACTS.BLL.phase_station_mainManager
			Dim psmML As List(Of FACTS.Model.phase_station_main)
			psmML = psmBll.SelectAll

			If phase_stationML Is Nothing Then Return True

			Dim pmpsM As FACTS.Model.product_mode_phase_station
			Dim phase_station_mainMode As FACTS.Model.phase_station_main

			For Each ps In phase_stationML
				phase_station_mainMode = psmML.Find(Function(o) o.phase_station.Trim.ToUpper = ps.M_phase_station_main.phase_station.Trim.ToUpper)
				If phase_station_mainMode Is Nothing Then Throw New Exception("Not found phase_station=" & ps.M_phase_station_main.phase_station)

				pmpsM = New FACTS.Model.product_mode_phase_station(ps.M_product_mode_phase_station)
				pmpsM.product_mode_id = product_mode_id
				pmpsM.phase_station_main_id = phase_station_mainMode.id
				pmpsM.validation_date = Now

				pmpsBll.Add(pmpsM)

			Next

			Return True

		Catch ex As Exception
			Throw New Exception("SpecModeManager.Create(Integer,List(Of CATS.Model.cq_product_mode_phase_station))::" & ex.Message)
		End Try
	End Function
	Private Sub InvalidAllPhases(product_mode_id As Integer)
		Try
			Dim msBll As New FACTS.BLL.mode_specManager
			Dim msML As List(Of FACTS.Model.mode_spec)

			msML = msBll.SelectByProductModeId(product_mode_id)

			If msML Is Nothing Then Return

			For Each msM In msML
				msM.validity = False
				msM.validation = True
				msBll.Update(msM)
			Next

		Catch ex As Exception
			Throw New Exception("SpecModeManager.InvalidAllPhases(product_mode_id)::" & ex.Message)
		End Try
	End Sub
	Public Sub Create(product_main_id As Integer, data As CATSConsoleModel.SpecMode)
		Try

			Dim pmode_idx As Integer
			Dim spec_main_id As Integer
			Dim msBll As New FACTS.BLL.mode_specManager
			Dim msM As FACTS.Model.mode_spec
			Dim rc As Integer = 0

			'add into product_mode 
			pmode_idx = Create(product_main_id, data.cq_modeM)
			Create(pmode_idx, data.PhaseStationML)

			'invalid all spec_main in mode_spec 
			InvalidAllPhases(pmode_idx)

			'-- for each 
			For Each sm In data.TestPhaseML

				EventShowMessage.ShowMessage(">> Beginning copy phase/" & sm.cq_phaseM.phase & " ... ...")
				'-- add spec_main
				spec_main_id = CATSConsoleData.SpecPhaseManager.Create(sm)

				'-- add mode_spec
				msM = New FACTS.Model.mode_spec

				If sm.cq_phaseM.class_id = 1 Then 'RL/ISO
					msM.order_idx = 1
				ElseIf sm.cq_phaseM.class_id = 2 Then 'PIM
					msM.order_idx = 2
				Else
					msM.order_idx = sm.cq_phaseM.class_id
					'MsgBox("The phase.class_id not in list (1,2), will set to default value 9.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
				End If

				msM.product_mode_id = pmode_idx
				msM.spec_main_id = spec_main_id
				msM.status = 0
				msM.validation = True
				msM.validity = True
				msM.validation_date = Now

				msBll.Add(msM)

				rc += 1
				EventShowProgress.ShowProgress(rc, data.TestPhaseML.Count)
				EventShowMessage.ShowMessage(">> Finished copy phase/" & sm.cq_phaseM.phase)
			Next

		Catch ex As Exception
			Throw New Exception("SpecModeManager.Create(product_mode_id,CATSConsoleModel.SpecMode)::" & ex.Message)
		End Try
	End Sub

End Class
