Public Class FormPRMode
	Private Sub LoadAllProducts()
		Try
			Dim prodModel As List(Of FACTS.Model.product_main) = DbOperator.GetAllProducts

			cbProduct.Items.AddRange(prodModel.ToArray)

		Catch ex As Exception
			Throw New Exception("LoadAllProducts()::" & ex.Message)
		End Try
	End Sub
	Private Function GetSelectedProduct() As FACTS.Model.product_main
		Try
			Dim resp As FACTS.Model.product_main
			resp = CType(cbProduct.SelectedItem, FACTS.Model.product_main)

			Return resp

		Catch ex As Exception
			Throw New Exception("FormPRMode.GetSelectedProduct()::" & ex.Message)
		End Try
	End Function
	Private Sub frmAddMode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		Try
			Me.MdiParent = FormMain
			LoadAllProducts()
			LoadComboxModes()
			ckModeValidity.Checked = True
		Catch ex As Exception
			MsgBox("FormLoad()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try

	End Sub
	Private Function GetUserModel() As FACTS.Model.cq_modes
		Try
			Dim resp As New FACTS.Model.cq_modes
			'Dim tmp As String

			'tmp = txtOrderId.Text.Trim

			'If IsNumeric(tmp) = False Then
			'	MsgBox("The Order Idx must be numberic and > 0.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
			'	Return Nothing
			'End If
			resp.order_idx = 1 'tmp

			Dim tmpItem As ComboxItem
			tmpItem = cmbMode.SelectedItem
			If tmpItem Is Nothing Then
				MsgBox("Please select one Mode.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
				Return Nothing
			End If
			resp.mode = tmpItem.Text
			resp.mode_id = tmpItem.Id

			'tmp = cmbValidity.Text.Trim
			'If tmp = "" Then
			'	MsgBox("Please select True/False for validity.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
			'	Return Nothing
			'End If
			resp.validity = ckModeValidity.Checked 'tmp

			Return resp

		Catch ex As Exception
			Throw New Exception("GetUserModel()::" & ex.Message)
		End Try
	End Function
	Private Function GetSelectedPhaseStations() As List(Of FACTS.Model.cq_mode_phase_station)
		Try
			Dim resp As New List(Of FACTS.Model.cq_mode_phase_station)


			For Each item In cklPhaseStation.CheckedItems
				resp.Add(CType(item, FACTS.Model.cq_mode_phase_station))
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetSelectedPhaseStations()::" & ex.Message)
		End Try
	End Function
	Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
		Try

			Dim pmM As New FACTS.Model.product_mode
			Dim pmBll As New FACTS.BLL.product_modeManager
			Dim modeModel As New FACTS.Model.mode
			Dim product_mode_id As Integer

			Dim cqML As List(Of FACTS.Model.cq_modes) = dgvMode.Tag
			Dim ucqM As FACTS.Model.cq_modes = GetUserModel()

			If ucqM Is Nothing Then Return


			For Each cqM In cqML
				If cqM.mode.Trim.ToUpper = ucqM.mode.Trim.ToUpper Then
					MsgBox("The mode [" & cqM.mode & "] have exist.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
					Exit Sub
				End If
			Next

			Dim product_main_id = GetSelectedProduct().id

			With pmM
				.mode_id = ucqM.mode_id
				.product_main_id = product_main_id
				.order_idx = ucqM.order_idx
				.validation = True
				.validation_date = Now
				.validity = ucqM.validity
			End With

			If MsgBox("Do you really want to add the new MODE?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
				product_mode_id = pmBll.AddReturnId(pmM)
				AddPhaseStation(product_mode_id, GetSelectedPhaseStations)
				LoadGridviewModes(GetSelectedProduct())
			End If

		Catch ex As Exception
			MsgBox("btnAdd_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub
	Private Sub AddPhaseStation(product_mode_id As Integer, phase_stationML As List(Of FACTS.Model.cq_mode_phase_station))
		Try
			Dim pmpsBll As New FACTS.BLL.product_mode_phase_stationManager
			Dim pmpsM As FACTS.Model.product_mode_phase_station

			Dim cqpmpsBll As New FACTS.BLL.cq_product_mode_phase_stationManager
			Dim cqpmpsML As List(Of FACTS.Model.cq_product_mode_phase_station)

			cqpmpsML = cqpmpsBll.SelectAllByProductModeId(product_mode_id, True, True)

			If cqpmpsML IsNot Nothing Then
				For Each cqpmps In cqpmpsML
					pmpsBll.Delete(cqpmps.M_product_mode_phase_station.id)
				Next
			End If

			For Each psM In phase_stationML

				pmpsM = New FACTS.Model.product_mode_phase_station
				pmpsM.product_mode_id = product_mode_id
				pmpsM.phase_station_main_id = psM.M_phase_station_main.id
				pmpsM.validity = True
				pmpsM.validation = True
				pmpsM.validation_date = Now
				pmpsBll.Add(pmpsM)

			Next

		Catch ex As Exception
			Throw New Exception("AddPhaseStation()::" & ex.Message)
		End Try
	End Sub
	Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
		Try
			Dim cqM As FACTS.Model.cq_modes
			Dim pmM As New FACTS.Model.product_mode
			Dim pmBll As New FACTS.BLL.product_modeManager

			Dim drs As DataGridViewSelectedRowCollection = dgvMode.SelectedRows
			If drs Is Nothing Then MsgBox("Please select one Mode which you want to update.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return
			If drs.Count = 0 Then MsgBox("Please select one Mode which you want to update.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return
			Dim ucqM As FACTS.Model.cq_modes = GetUserModel()

			cqM = drs(0).Tag

			If cqM.mode_id <> ucqM.mode_id Then MsgBox("The selected Mode mismatch between in grid box and in list box!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Return

			pmM = pmBll.SelectById(cqM.product_mode_id)

			With pmM
				'.mode_id = ucqM.mode_id
				'.order_idx = ucqM.order_idx
				.validity = ckModeValidity.Checked
				.validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
				'.validity = ckbValidity.Checked
			End With
			If MsgBox("Do you really want to update this Mode[" & cqM.mode & "]?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
				If pmBll.Update(pmM) = True Then
					AddPhaseStation(pmM.id, GetSelectedPhaseStations)
					MsgBox("Success update.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
				End If
				LoadGridviewModes(CType(cbProduct.SelectedItem, FACTS.Model.product_main))
			End If

		Catch ex As Exception
			MsgBox("btnUpdate_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub
	Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
		Try
			Dim cqM As FACTS.Model.cq_modes
			Dim pmBll As New FACTS.BLL.product_modeManager

			Dim drs As DataGridViewSelectedRowCollection = dgvMode.SelectedRows
			If drs Is Nothing Then MsgBox("Please select one Mode which you want to update.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return
			If drs.Count = 0 Then MsgBox("Please select one Mode which you want to update.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return

			cqM = drs(0).Tag

			If MsgBox("Do you really want to delete this Mode[" & cqM.mode & "]?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
				If pmBll.Delete(cqM.product_mode_id) = True Then
					MsgBox("Success delete.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
				End If
				LoadGridviewModes(GetSelectedProduct)
			End If

		Catch ex As Exception
			MsgBox("Delete item()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub

	Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub
	Private Sub LoadGridviewModes(pm As FACTS.Model.product_main)
		Try
			Dim cqmodeModel As List(Of FACTS.Model.cq_modes) = DbOperator.GetModesByProductId(pm.Id)

			Dim cqmodeBll As New FACTS.BLL.cq_modesManager


			dgvMode.Rows.Clear()

			Dim rowId As Integer

			For Each cqM As FACTS.Model.cq_modes In cqmodeModel
				rowId = dgvMode.Rows.Add()
				dgvMode.Rows(rowId).Cells(0).Value = cqM.order_idx
				dgvMode.Rows(rowId).Cells(1).Value = cqM.mode
				dgvMode.Rows(rowId).Cells(2).Value = cqM.validity.ToString
				dgvMode.Rows(rowId).Tag = cqM
			Next

			dgvMode.Tag = cqmodeModel


		Catch ex As Exception
			Throw New Exception("LoadModes()::" & ex.Message)
		End Try
	End Sub
	Private Sub cmbProduct_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbProduct.SelectedIndexChanged
		Try

			If cbProduct.SelectedItem Is Nothing Then Return

			LoadGridviewModes(GetSelectedProduct)

			If dgvMode.Rows.Count = 0 Then
				LoadPhaseStations(Nothing, 0)
				Return
			End If
			dgvMode.Rows(0).Selected = True
			ShowGridviewModeSlected(0)

			'ckbValidity.Checked = False
			'txtOrderIdx.Text = ""
		Catch ex As Exception
			MsgBox("Select product item()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub
	Private Sub LoadComboxModes()
		Try
			Dim cmbItem As ComboxItem
			Dim mBll As New FACTS.BLL.modeManager
			Dim mM As List(Of FACTS.Model.mode)
			mM = mBll.SelectAll
			cmbMode.Items.Clear()
			For Each m In mM
				cmbItem = New ComboxItem
				cmbItem.Id = m.id
				cmbItem.Text = m.mode
				cmbMode.Items.Add(cmbItem)
			Next
			'   cmbMode.SelectedValue = "PROD"
		Catch ex As Exception
			Throw New Exception("LoadComboxModes()::" & ex.Message)
		End Try
	End Sub
	Private Sub LoadPhaseStations(mode As String, product_mode_id As Integer)
		Try

			cklPhaseStation.Items.Clear()

			If mode Is Nothing Then Return
			'Dim psBll As New CATS.BLL.phase_station_mainManager
			Dim cqmpsBll As New FACTS.BLL.cq_mode_phase_stationManager
			Dim cqmpsML As List(Of FACTS.Model.cq_mode_phase_station)

			cqmpsML = cqmpsBll.SelectAllByMode(mode, True, True)

			'Dim psML As List(Of CATS.Model.phase_station_main) = psBll.SelectAll

			Dim cqpmpsBll As New FACTS.BLL.cq_product_mode_phase_stationManager
			Dim cqpmpsML As List(Of FACTS.Model.cq_product_mode_phase_station)

			cqpmpsML = cqpmpsBll.SelectAllByProductModeId(product_mode_id, True, True)


			'cklPhaseStation.Items.Clear()
			If cqmpsML Is Nothing Then Return

			For Each psM In cqmpsML
				If cqpmpsML Is Nothing Then
					cklPhaseStation.Items.Add(psM, False)
				Else
					If cqpmpsML.Find(Function(o) o.M_phase_station_main.id = psM.M_phase_station_main.id) Is Nothing Then
						cklPhaseStation.Items.Add(psM, False)
					Else
						cklPhaseStation.Items.Add(psM, True)
					End If
				End If

			Next


		Catch ex As Exception
			Throw New Exception("LoadPhaseStations()::" & ex.Message)
		End Try
	End Sub
	Private Sub ShowGridviewModeSlected(selRowIdx As Integer)
		Try
			'Dim cmbId As Integer


			If selRowIdx < 0 Then Return

			Dim cqM As FACTS.Model.cq_modes
			cqM = CType(dgvMode.Rows(selRowIdx).Tag, FACTS.Model.cq_modes)

			If cqM Is Nothing Then Return

			'txtOrderId.Text = cqM.order_idx
			LoadComboxModes()
			'Dim mBll As New CATS.BLL.modeManager
			'Dim mM As List(Of CATS.Model.mode)
			'mM = mBll.SelectAll
			'cmbMode.Items.Clear()
			'For Each m In mM
			'  cmbItem = New ComboxItem
			'  cmbItem.Id = m.id
			'  cmbItem.Text = m.mode
			'  cmbId = cmbMode.Items.Add(cmbItem)
			'Next
			cmbMode.Text = cqM.mode

			'cmbValidity.Items.Clear()
			'cmbValidity.Items.Add("True")
			'cmbValidity.Items.Add("False")
			'cmbValidity.Text = cqM.validity
			ckModeValidity.Checked = cqM.validity

			LoadPhaseStations(cqM.mode, cqM.product_mode_id)

		Catch ex As Exception
			Throw New Exception("ShowGridviewModeSlected()::" & ex.Message)
		End Try
	End Sub
	Private Sub dgvMode_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMode.CellClick
		Try
			Dim rowIdx As Integer = e.RowIndex

			ShowGridviewModeSlected(rowIdx)

		Catch ex As Exception
			MsgBox("dgvMode_CellClick()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub

	Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
		Try
			Dim tmpItem As ComboxItem = cmbMode.SelectedItem
			If tmpItem Is Nothing Then Return

			LoadPhaseStations(tmpItem.Text, 0)

		Catch ex As Exception

		End Try
	End Sub

	Private Sub btnSelAnything_Click(sender As Object, e As EventArgs) Handles btnSelAnything.Click
		Try
			For i As Integer = 0 To cklPhaseStation.Items.Count - 1
				cklPhaseStation.SetItemChecked(i, True)
			Next

		Catch ex As Exception

		End Try
	End Sub

	Private Sub btnSelNothing_Click(sender As Object, e As EventArgs) Handles btnSelNothing.Click
		Try
			For i As Integer = 0 To cklPhaseStation.Items.Count - 1
				cklPhaseStation.SetItemChecked(i, False)
			Next
		Catch ex As Exception

		End Try
	End Sub

	'Private Sub cmbMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
	'  Try
	'    Dim modeModel As CATS.Model.cq_modes

	'    modeModel = cmbMode.SelectedItem
	'    ckbValidity.Checked = modeModel.validity
	'    txtOrderIdx.Text = modeModel.order_idx

	'  Catch ex As Exception
	'    MsgBox("Select mode item()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
	'  End Try
	'End Sub
End Class