Public Class FormUSManager
	Public Class EmployeeFactory
		Inherits FACTS.Model.employee
		Public factory As String

		Public Sub New(empModel As FACTS.Model.employee)
			Me.id = empModel.id
			Me.emp_num = empModel.emp_num
			Me.name = empModel.name
			Me.login_name = empModel.login_name
			Me.permission = empModel.permission
			Me.department = empModel.department
			Me.pwd = empModel.pwd
			Me.user_level = empModel.user_level
			Me.factory_id = empModel.factory_id
			Me.gen1 = empModel.gen1
			Me.gen2 = empModel.gen2
			Me.gen3 = empModel.gen3
		End Sub
	End Class
	Private Sub FormUSManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.MdiParent = FormMain
	End Sub
	Private Function GetFactoryModelList() As List(Of FACTS.Model.factory)
		Try
			Dim fmBll As New FACTS.BLL.factoryManager
			Dim fmML As List(Of FACTS.Model.factory)

			fmML = fmBll.SelectAll

			Return fmML

		Catch ex As Exception
			Throw New Exception("GetFactoryModelList()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub LoadGvEmployee(valueList As List(Of EmployeeFactory))
		Try
			Dim rIdx As Integer

			dgvEmployee.Rows.Clear()

			For Each v In valueList

				rIdx = dgvEmployee.Rows.Add()
				dgvEmployee.Rows(rIdx).Cells(0).Value = v.login_name

				dgvEmployee.Rows(rIdx).Cells(1).Value = v.factory

				dgvEmployee.Rows(rIdx).Cells(2).Value = v.department

				dgvEmployee.Rows(rIdx).Tag = v

			Next

		Catch ex As Exception
			Throw New Exception("LoadGvEmployee()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Private Function GetDbEmployeeList() As List(Of EmployeeFactory)
		Try
			Dim resp As New List(Of EmployeeFactory)
			Dim respItem As EmployeeFactory

			Dim eBll As New FACTS.BLL.employeeManager
			Dim eML As List(Of FACTS.Model.employee)

			eML = eBll.SelectAll

			Dim fctoryML As List(Of FACTS.Model.factory) = GetFactoryModelList()
			Dim strFactory As String

			For Each empM In eML
				If fctoryML Is Nothing Then
					strFactory = ""
				Else
					strFactory = fctoryML.Find(Function(o) o.id = empM.factory_id).name
				End If

				respItem = New EmployeeFactory(empM)
				respItem.factory = strFactory
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetDbEmployeeList()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Function FilterEmployeeList(employeeList As List(Of EmployeeFactory), login_name As String, factory As String) As List(Of EmployeeFactory)
		Try
			Dim resp As IEnumerable(Of EmployeeFactory)

			Dim strLoginName As String
			Dim strFactory As String

			strLoginName = login_name.Trim.ToUpper
			strFactory = factory.Trim.ToUpper

			If strLoginName <> "" And strFactory = "" Then
				resp = employeeList.Where(Function(o) o.login_name.ToString.ToUpper.Trim.Contains(strLoginName.ToUpper.Trim))
			ElseIf strLoginName = "" And strFactory <> "" Then
				resp = employeeList.Where(Function(o) o.factory.ToString.ToUpper.Trim.Contains(strFactory.ToUpper.Trim))
			ElseIf strLoginName <> "" And strFactory <> "" Then
				resp = employeeList.Where(Function(o) o.factory.ToString.ToUpper.Trim.Contains(strFactory.ToUpper.Trim) And o.login_name.ToString.ToUpper.Trim.Contains(strLoginName.ToUpper.Trim))

			Else
				resp = employeeList
			End If


			Return resp.ToList

		Catch ex As Exception
			Throw New Exception("FilterEmployeeList()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub
	Private Sub LoadFactoryCombox()
		Try
			Dim factoryML As List(Of FACTS.Model.factory) = GetFactoryModelList()
			Dim fComboxItem As ComboxItem

			cmbFactory.Items.Clear()

			For Each fM In factoryML
				fComboxItem = New ComboxItem
				fComboxItem.Id = fM.id
				fComboxItem.Text = fM.name
				cmbFactory.Items.Add(fComboxItem)
			Next
		Catch ex As Exception

		End Try
	End Sub
	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Try
			Dim empML As List(Of EmployeeFactory)
			LoadFactoryCombox()
			empML = GetDbEmployeeList()
			empML = FilterEmployeeList(empML, txtFilterLoginName.Text, txtFilterFactory.Text)
			LoadGvEmployee(empML)

		Catch ex As Exception
			MsgBox("btnRefresh_Click()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub

	Private Sub dgvEmployee_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployee.CellClick
		Try
			Dim rowIdx As Integer = e.RowIndex

			If rowIdx = -1 Then Return

			Dim empM As EmployeeFactory = dgvEmployee.Rows(rowIdx).Tag

			txtLoginName.Text = empM.login_name
			txtDepartment.Text = empM.department
			cmbFactory.Text = empM.factory



		Catch ex As Exception

		End Try
	End Sub
	Private Function GetUserInput() As EmployeeFactory
		Try
			Dim strLoginName As String = txtLoginName.Text.Trim.ToUpper
			If strLoginName = "" Then Throw New Exception("empty login name")

			Dim strDepartment As String = txtDepartment.Text.Trim.ToUpper
			'If strDepartment = "" Then Throw New Exception("empty department")

			Dim factoryM As ComboxItem = cmbFactory.SelectedItem
			If factoryM Is Nothing Then Throw New Exception("empty factory name")

			Dim empM As New FACTS.Model.employee
			empM.login_name = strLoginName
			empM.department = strDepartment
			empM.factory_id = factoryM.Id

			Dim resp As New EmployeeFactory(empM)
			resp.factory = factoryM.Text

			Return resp

		Catch ex As Exception
			Throw New Exception("GetUserInput()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
		Try

			Dim EFM As EmployeeFactory
			EFM = GetUserInput()

			Dim empBll As New FACTS.BLL.employeeManager
			Dim empM As FACTS.Model.employee

			empM = empBll.SelectByLoginname(EFM.login_name)
			If empM IsNot Nothing Then Throw New Exception("The login name have exist.")

			empM = New FACTS.Model.employee
			empM.login_name = EFM.login_name
			empM.department = EFM.department
			empM.factory_id = EFM.factory_id

			empBll.Add(empM)

			MsgBox("Success create employee information !", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)


		Catch ex As Exception
			MsgBox("Failed create employee information ." & vbCrLf & " at " & ex.Message)
		End Try
	End Sub

	Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
		Try

			Dim EFM As EmployeeFactory
			EFM = GetUserInput()

			Dim empBll As New FACTS.BLL.employeeManager
			Dim empM As New FACTS.Model.employee

			empM = empBll.SelectByLoginname(EFM.login_name)
			empM.department = EFM.department
			empM.factory_id = EFM.factory_id

			empBll.Update(empM)

			MsgBox("Success update employee information !", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)


		Catch ex As Exception
			MsgBox("Failed update employee information ." & vbCrLf & " at " & ex.Message)
		End Try
	End Sub

	Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
		Try

			Dim EFM As EmployeeFactory
			EFM = GetUserInput()

			Dim empBll As New FACTS.BLL.employeeManager
			Dim empM As FACTS.Model.employee

			empM = empBll.SelectByLoginname(EFM.login_name)
			If empM IsNot Nothing Then Throw New Exception("The login name have exist.")

			If MsgBox("Do you really want to delete this employee in system?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return

			empBll.Delete(empM.id)

			MsgBox("Success delete employee !", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)


		Catch ex As Exception
			MsgBox("Failed delete employee information ." & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
End Class