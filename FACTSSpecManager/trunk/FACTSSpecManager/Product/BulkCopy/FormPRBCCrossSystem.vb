Public Class FormPRBCCrossSystem
	Public _logFilePath As String
	Public _logErrFilePath As String
	Private Sub LoadSourceDbConnstrings(control As Windows.Forms.ComboBox, connL As List(Of ComboxItem))
		Try

			control.Items.Clear()
			For Each itm In connL
				control.Items.Add(itm)
			Next

		Catch ex As Exception
			Throw New Exception("LoadSourceDbConnstrings()::" & ex.Message)
		End Try
	End Sub
	Private Sub LoadDestinationDbConnstrings(control As Windows.Forms.CheckedListBox, connL As List(Of ComboxItem))
		Try
			control.Items.Clear()
			For Each itm In connL
				control.Items.Add(itm)
			Next

		Catch ex As Exception
			Throw New Exception("LoadDestinationDbConnstrings()::" & ex.Message)
		End Try
	End Sub
	Private Function GetProductList() As List(Of String)
		Try
			Dim resp As New List(Of String)

			For Each prod In txtProductList.Lines
				If prod.Trim <> "" Then resp.Add(prod.Trim.ToUpper)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetProductList()::" & ex.Message)
		End Try

	End Function
	Private Function GetSelectionModeList() As List(Of String)
		Try
			Dim resp As New List(Of String)
			Dim tmpList As CheckedListBox.CheckedItemCollection

			tmpList = ckModeList.CheckedItems

			For Each tmp In tmpList
				resp.Add(tmp)
			Next
			'resp = tmpList.GetEnumerator

			Return resp

		Catch ex As Exception
			Throw New Exception("GetSelectionModeList()::" & ex.Message)
		End Try
	End Function
	Private Function GetSelectionSourceDb() As ComboxItem
		Try
			Dim resp As New ComboxItem
			If cmbSrcDb.SelectedItem Is Nothing Then Return Nothing

			resp = cmbSrcDb.SelectedItem

			Return resp

		Catch ex As Exception
			Throw New Exception("GetSelectionSourceDb()::" & ex.Message)
		End Try

	End Function
	Private Function GetSelectionDestinationDbList() As List(Of ComboxItem)
		Try
			Dim resp As New List(Of ComboxItem)
			Dim tmpList As CheckedListBox.CheckedItemCollection

			tmpList = ckDbList.CheckedItems

			For Each tmp In tmpList
				resp.Add(tmp)
			Next
			'resp = tmpList.GetEnumerator

			Return resp

		Catch ex As Exception
			Throw New Exception("GetSelectionDestinationDbList()::" & ex.Message)
		End Try
	End Function
	Public Sub AddLog(msg As String)
		Dim fw As New IO.StreamWriter(_logFilePath, True)
		Try

			fw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss:fff") & " > " & msg)

		Catch ex As Exception
			fw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss:fff") & " > " & ex.Message)
		Finally
			fw.Close()
		End Try
	End Sub
	Public Sub AddErrLog(msg As String)
		Dim fw As New IO.StreamWriter(_logErrFilePath, True)
		Try

			fw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss:fff") & " > " & msg)

		Catch ex As Exception
			fw.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss:fff") & " > " & ex.Message)
		Finally
			fw.Close()
		End Try
	End Sub
	Public Sub ShowOverallProgress(progressValue As Decimal, totalValue As Decimal)
		progBarOverall.Maximum = totalValue
		progBarOverall.Value = progressValue

		Application.DoEvents()
	End Sub
	Public Sub ShowDBProgress(progressValue As Decimal, totalValue As Decimal)
		progBarDB.Maximum = totalValue
		progBarDB.Value = progressValue
		Application.DoEvents()
	End Sub
	Public Sub ShowModeProgress(progressValue As Decimal, totalValue As Decimal)
		progBarMode.Maximum = totalValue
		progBarMode.Value = progressValue

		Application.DoEvents()
	End Sub
	Public Sub ShowPhaseProgress(progressValue As Decimal, totalValue As Decimal)
		progBarPhase.Maximum = totalValue
		progBarPhase.Value = progressValue

		Application.DoEvents()
	End Sub
	'Public Sub ShowGetSpecsProgress(progressValue As Decimal, totalValue As Decimal)
	'	progBarSpec.Maximum = totalValue
	'	progBarSpec.Value = progressValue
	'	Application.DoEvents()
	'End Sub
	Public Sub ShowMessage(msg As String)
		lstMessage.Items.Add(msg)
		lstMessage.SelectedIndex = lstMessage.Items.Count - 1
		Application.DoEvents()
		AddLog(msg)
	End Sub
	Public Sub ShowErrMessage(msg As String)
		lstErrMessage.Items.Add(msg)
		lstErrMessage.SelectedIndex = lstErrMessage.Items.Count - 1
		Application.DoEvents()
		AddErrLog(msg)
	End Sub
	Private Function GetSelectionProfiles(specProductModel As CATSConsoleModel.SpecProduct, modeList As List(Of String)) As CATSConsoleModel.SpecProduct
		Try
			Dim resp As New CATSConsoleModel.SpecProduct

			resp.productM = specProductModel.productM

			For Each specMode In specProductModel.TestModeL

				If modeList.Find(Function(o) o.ToUpper.Trim = specMode.cq_modeM.mode.ToUpper.Trim) <> "" Then
					resp.TestModeL.Add(specMode)
				End If
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetSelectionProfiles()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
		Try

			btnCopy.Enabled = False

			Dim logDir As String = Application.StartupPath & "\log\"
			If IO.Directory.Exists(logDir) = False Then IO.Directory.CreateDirectory(logDir)

			_logFilePath = logDir & Now.ToString("yyyyMMddHHMMss") & ".log"
			_logErrFilePath = logDir & Now.ToString("yyyyMMddHHMMss") & ".errlog"

			'get all products
			Dim productList As New List(Of String)
			productList = GetProductList()
			If productList Is Nothing Then MsgBox("Please input products !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Return

			Dim modeList As List(Of String)
			modeList = GetSelectionModeList()
			If modeList Is Nothing Then MsgBox("Please select MODE !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Return
			If modeList.Count = 0 Then MsgBox("Please select MODE !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Return

			Dim srcDbConn As ComboxItem
			srcDbConn = GetSelectionSourceDb()
			If srcDbConn Is Nothing Then MsgBox("Please select source database connection.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Return


			Dim desDbConnList As List(Of ComboxItem)
			desDbConnList = GetSelectionDestinationDbList()
			If desDbConnList Is Nothing Then MsgBox("Please select destination database connection.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) : Return

			Dim pmM As FACTS.Model.product_main
			Dim pmBll As New FACTS.BLL.product_mainManager
			Dim spsM As CATSConsoleModel.SpecProduct

			Dim prodProgressIndex As Integer = 0

			ShowOverallProgress(0, productList.Count)
			For Each pName In productList

				'get source spec
				ShowMessage(">> Switch  DB  to <" & srcDbConn.Text & "> ...")
				SwitchCATSServer(srcDbConn)

				ShowMessage(">> [" & srcDbConn.Text & "] Start to get spec  <" & pName & "> ...")
				pmM = pmBll.SelectByProductName(pName)
				spsM = New CATSConsoleModel.SpecProduct(pmM, Nothing)

				If spsM Is Nothing Then ShowErrMessage("[" & srcDbConn.Text & "] not found spec , product <" & pName & ">") : Continue For

				Dim srcSpecProduct As CATSConsoleModel.SpecProduct = GetSelectionProfiles(spsM, modeList)

				ShowMessage(">> Start to copy product <" & pName & "> ... ")
				'loop each database

				Dim DbProgressIndex As Integer = 0
				ShowDBProgress(0, desDbConnList.Count)

				For Each DbConnect In desDbConnList

					ShowMessage(">> Switch DB to  <" & DbConnect.Text & "> ...")
					SwitchCATSServer(DbConnect)

					'get destination spec
					ShowMessage(">> [" & DbConnect.Text & "] Start to get spec  ...")
					pmM = pmBll.SelectByProductName(pName)
					Dim spdM As New CATSConsoleModel.SpecProduct(pmM, Nothing)
					Dim spmBll As New CATSConsoleData.SpecProductManager

					AddHandler spmBll.EventShowModeProgress.ShowProgressHandler, AddressOf ShowModeProgress
					AddHandler spmBll.EventShowPhaseProgress.ShowProgressHandler, AddressOf ShowPhaseProgress
					AddHandler spmBll.EventShowMessage.ShowMessageHandler, AddressOf ShowMessage


					spmBll.ExistedModel = spdM
					ShowMessage(">> [" & DbConnect.Text & "] Stop to get spec  ...")


					ShowMessage(">> [" & DbConnect.Text & "] Start to copy spec  ...")
					'loop each mode
					spmBll.Create(srcSpecProduct)

					ShowMessage(">> [" & DbConnect.Text & "] Stop to copy spec  ...")

					DbProgressIndex += 1
					ShowDBProgress(DbProgressIndex, desDbConnList.Count)
				Next

				prodProgressIndex += 1
				ShowOverallProgress(prodProgressIndex, productList.Count)

			Next


			MsgBox("The copying log have been saved  in '" & logDir & "'.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)

		Catch ex As Exception
			ShowErrMessage(ex.Message)
			MsgBox("Copy profiles()" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		Finally
			SwitchCATSServer(pActivedDb)
			btnCopy.Enabled = True
		End Try
	End Sub
	Private Sub LoadDbConnstrings(control As Windows.Forms.ComboBox, connL As List(Of ComboxItem))
		Try

			control.Items.Clear()
			For Each itm In connL
				control.Items.Add(itm)
			Next

		Catch ex As Exception
			Throw New Exception("LoadDbConnstrings()::" & ex.Message)
		End Try
	End Sub
	Private Sub FormPRBCCrossSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Me.MdiParent = FormMain

			Dim connML As List(Of ComboxItem)
			connML = GetConnString()

			LoadSourceDbConnstrings(cmbSrcDb, connML)
			LoadDestinationDbConnstrings(ckDbList, connML)


		Catch ex As Exception
			MsgBox("FrmCrossSystemDuplicate_Load." & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub
End Class