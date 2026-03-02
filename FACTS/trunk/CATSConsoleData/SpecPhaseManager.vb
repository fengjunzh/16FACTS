Public Class SpecPhaseManager
	Private Shared Function CreateSpecMain(data As FACTS.Model.spec_main) As Integer
		Try
			Dim smBll As New FACTS.BLL.spec_mainManager

			Return smBll.AddReturnId(data)

		Catch ex As Exception
			Throw New Exception("SpecModeManager.CreateSpecMain(int,spec_main)::" & ex.Message)
		End Try
	End Function
	''' <summary>
	''' 
	''' </summary>
	''' <param name="data"></param>
	''' <returns>spec_main_id</returns>
	Public Shared Function Create(data As CATSConsoleModel.SpecPhase) As Integer
		Try
			'Dim pf_id As Integer  'phase_function_id
			'Dim pm_id As Integer  'phase_main_id


			'add phase_function
			'pf_id = Create(func_name)


			'get phase_main
			Dim pmBll As New FACTS.BLL.phase_mainManager
			Dim pmM As FACTS.Model.phase_main

			pmM = pmBll.SelectByPhase(data.cq_phaseM.phase)  'phase,pf_idx,class_id,order_idx
			If pmM Is Nothing Then Throw New Exception("No find phase <" & data.cq_phaseM.phase & ">")

			'add spec_main
			Dim sm_id As Integer
			Dim smM As FACTS.Model.spec_main
			smM = data.cq_phaseM.spec_main_model
			smM.phase_main_id = pmM.id
			sm_id = CreateSpecMain(smM)

			'for each add group_main
			For Each sgM In data.SpecGroupML
				CATSConsoleData.SpecGroupManager.Create(sm_id, sgM)
			Next

			Return sm_id

		Catch ex As Exception
			Throw New Exception("SpecModeManager.Create(int,cq_modes)::" & ex.Message)
		End Try

	End Function
End Class
