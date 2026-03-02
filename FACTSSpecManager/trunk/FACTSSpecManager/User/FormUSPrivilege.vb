Public Class FormUSPrivilege
	Private Sub LoadUsers()
		Try

			cmbUsers.Items.Clear()

			Dim eBll As New FACTS.BLL.employeeManager
			Dim eML As List(Of FACTS.Model.employee)

			eML = eBll.SelectAll

			' cmbUsers.Items.AddRange(eML.ToArray)
			For Each eM As FACTS.Model.employee In eML
				cmbUsers.Items.Add(eM)
			Next


		Catch ex As Exception
			Throw New Exception("LoadUsers()::" & ex.Message)
		End Try
	End Sub
	Private Sub FormPrivilege_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Me.MdiParent = FormMain
			LoadUsers()

		Catch ex As Exception

		End Try
	End Sub
	Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
		Try

			If cmbUsers.SelectedItem Is Nothing Then
				MsgBox("Please select user.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
				Exit Sub
			End If

			Dim eM As FACTS.Model.employee = cmbUsers.SelectedItem

			Dim cqeBll As New FACTS.BLL.cq_employee_funcManager
			Dim cqeML As List(Of FACTS.Model.cq_employee_func) = cqeBll.SelectAllByLoginName(eM.login_name)

			Dim fmBll As New FACTS.BLL.func_mainManager
			Dim fmML As List(Of FACTS.Model.func_main) = fmBll.SelectAll

			Dim rowIdx As Integer

			dgvPrivilege.Rows.Clear()
			For Each fmM In fmML
				rowIdx = dgvPrivilege.Rows.Add()
				dgvPrivilege.Rows(rowIdx).Cells(0).Value = rowIdx + 1
				dgvPrivilege.Rows(rowIdx).Cells(1).Value = fmM.name
				dgvPrivilege.Rows(rowIdx).Cells(2).Value = fmM.descr
				dgvPrivilege.Rows(rowIdx).Tag = fmM

				If cqeML Is Nothing Then Continue For

				For Each cqeM In cqeML
					If fmM.id = cqeM.func_main_id Then
						dgvPrivilege.Rows(rowIdx).Cells(3).Value = True
					End If
				Next
			Next

			' MsgBox(cqeML.Count)
		Catch ex As Exception

		End Try
	End Sub

	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		Try
			If cmbUsers.SelectedItem Is Nothing Then
				MsgBox("Please select user.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
				Exit Sub
			End If

			Dim eM As FACTS.Model.employee = cmbUsers.SelectedItem
			Dim fmM As FACTS.Model.func_main
			Dim efBll As New FACTS.BLL.employee_funcManager
			Dim efM As FACTS.Model.employee_func

			efBll.DeleteByEmployeeId(eM.id)

			For Each row As DataGridViewRow In dgvPrivilege.Rows
				If row.Cells(3).Value = True Then
					fmM = row.Tag
					efM = New FACTS.Model.employee_func
					efM.employee_id = eM.id
					efM.func_main_id = fmM.id
					efBll.Add(efM)
				End If

			Next

			MsgBox("Successfully added permissions for user " & eM.login_name & " .", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)

		Catch ex As Exception
			MsgBox("Failed to add permissions - " & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub
End Class