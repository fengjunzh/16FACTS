Public Class SpecPhase
	Public cq_phaseM As New FACTS.Model.cq_phases
	Public SpecGroupML As New List(Of SpecGroup)
	Public Sub New(cq_phase As FACTS.Model.cq_phases)
		Try
			cq_phaseM = cq_phase

			'get TestGroupL

			Dim gmBll As New FACTS.BLL.group_mainManager
			Dim gmML As List(Of FACTS.Model.group_main) = gmBll.SelectAllBySpecMainId(cq_phase.spec_main_id)
			If gmML Is Nothing Then Return

			For Each gmM In gmML
				SpecGroupML.Add(New SpecGroup(gmM))
			Next

		Catch ex As Exception
			Throw New Exception("SpecPhase.New()::" & ex.Message)
		End Try
	End Sub
	Public Function CompareTo(value As FACTS.Model.cq_phases) As Boolean
		Try
			If cq_phaseM.spec_main_model.CompareTo(value.spec_main_model) = False Then Return False

			Return True

		Catch ex As Exception
			Throw New Exception("SpecPhase.CompareTo()::" & ex.Message)
		End Try
	End Function
	Public Function CompareTo(value As List(Of SpecGroup)) As Boolean
		Try

			If SpecGroupML.Count <> value.Count Then Return False

			Dim sgM As SpecGroup

			For Each tp In SpecGroupML

				sgM = value.Find(Function(o) o.group_mainM.group_name.Trim.ToUpper = tp.group_mainM.group_name.Trim.ToUpper)

				If sgM Is Nothing Then Return False

				If tp.CompareTo(sgM) = False Then Return False

			Next

			Return True

		Catch ex As Exception
			Throw New Exception("Specphase.CompareTo(List(Of SpecGroup))::" & ex.Message)
		End Try
	End Function
	Public Function CompareTo(value As SpecPhase) As Boolean
		Try
			If cq_phaseM.CompareTo(value.cq_phaseM) = False Then Return False
			If CompareTo(SpecGroupML) = False Then Return False
			Return True

		Catch ex As Exception
			Throw New Exception("SpecPhase.CompareTo(SpecPhase)::" & ex.Message)
		End Try

	End Function
End Class

