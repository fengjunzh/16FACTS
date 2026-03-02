Imports System.Xml.Serialization
Public Class FormSetting
	Private _CatsUpdate As Update
	Public Sub New(catsUpdate As Update)

		' This call is required by the designer.
		InitializeComponent()

		_CatsUpdate = catsUpdate
		' Add any initialization after the InitializeComponent() call.

	End Sub
	Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
		Try
			Dim selFactory As ComboboxItem = GetSelectedFactory()
			If selFactory Is Nothing Then Throw New Exception("selected Factory is null.")

			Dim selMode As ComboboxItem = GetSelectedMode()
			If selMode Is Nothing Then Throw New Exception("selected Mode is null.")

			Dim selAppList As List(Of ComboboxItem) = GetSelectedTestApplications()
			If selAppList.Count = 0 Then If MsgBox("Not select test applications , do you want continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return

			Dim catsFac As New XmlOpera.Factory.CATS(_CatsUpdate.CATSXmlsFile)
			Dim catsM As New XmlOpera.Format.CATS.CATSElement
			Dim factoryE As XmlOpera.Format.CATSDbServer.FactoryElement
			Dim modeE As XmlOpera.Format.CATSDbServer.ModeElement

			factoryE = CType(selFactory.MiscMsg, XmlOpera.Format.CATSDbServer.FactoryElement)
			catsM.Property_.CreateTime = Now
			catsM.Factory.Location = factoryE.Location
			catsM.TestBench.Mode = selMode.Text
			modeE = factoryE.ModeElementList.Find(Function(o) o.Name = selMode.Text)

			If modeE Is Nothing Then modeE = factoryE.ModeElementList.Find(Function(o) o.Name = "*")
			If modeE Is Nothing Then Throw New Exception("Not found Db connection string in DbServerXml, factory ='" & factoryE.Location & "', mode='" & modeE.Name & "' or '*'")

			catsM.DataBase.ConnString = modeE.ConnString
			catsFac.Write(catsM)

			Dim ceaFac As New XmlOpera.Factory.CATSEntryApplications(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSEntryApplicationsXmls)
			Dim ceaM As New XmlOpera.Format.CATSEntryApplications.CATSEntryApplicationsElement
			Dim ceaaM As XmlOpera.Format.CATSEntryApplications.AppElement
			Dim appE As XmlOpera.Format.CATSApplications.AppElement

			ceaM.ReleasedTime = Now
			For Each app In selAppList
				ceaaM = New XmlOpera.Format.CATSEntryApplications.AppElement
				appE = CType(app.MiscMsg, XmlOpera.Format.CATSApplications.AppElement)
				ceaaM.Name = appE.Name
				ceaaM.AliasName = appE.AliasName
        ceaaM.ServerPath = appE.ServerPath
        ceaaM.LocalPath = appE.LocalPath
        ceaaM.SyncEnable = appE.SyncEnable
				ceaaM.Exe = appE.Exe
				ceaM.AppElementList.Add(ceaaM)
			Next

			ceaFac.Write(ceaM)

			MsgBox("Success save the test bench profiles.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)

		Catch ex As Exception
			MsgBox("Failed to save the test bench profiles." & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub
	Private Function GetXmlFactorys() As List(Of ComboboxItem)
		Try
			Dim resp As New List(Of ComboboxItem)
			Dim respItem As ComboboxItem

			Dim cdsFac As New XmlOpera.Factory.CATSDbServer(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSDbServerXmls)
			Dim cdsM As XmlOpera.Format.CATSDbServer.CATSDbServerElement

			cdsM = cdsFac.Read

			If cdsM.FactoryElementList Is Nothing Then Return Nothing

			For Each item In cdsM.FactoryElementList
				respItem = New ComboboxItem
				respItem.Text = item.Location
				respItem.MiscMsg = item
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetAllFactorys()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Function GetSelectedFactory() As ComboboxItem
		Try
			Return cmbFactory.SelectedItem
		Catch ex As Exception
			Throw New Exception("GetSelectedFactory()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub LoadFactorys(factoryList As List(Of ComboboxItem), selFactoryName As String)
		Try

			cmbFactory.Items.Clear()
			For Each item In factoryList
				cmbFactory.Items.Add(item)
			Next

			Dim selFactoryItem As ComboboxItem
			selFactoryItem = factoryList.Find(Function(o) o.Text.ToUpper.Trim = selFactoryName.Trim.ToUpper)
			If selFactoryItem IsNot Nothing Then cmbFactory.SelectedItem = selFactoryItem

		Catch ex As Exception
			Throw New Exception("LoadFactorys()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Private Function GetDbModes(selFactory As ComboboxItem) As List(Of ComboboxItem)
		Try
			Dim resp As New List(Of ComboboxItem)
			Dim respItem As ComboboxItem

			If selFactory Is Nothing Then Return Nothing

			Dim factoryE As XmlOpera.Format.CATSDbServer.FactoryElement
			Dim modeE As XmlOpera.Format.CATSDbServer.ModeElement
			Dim connString As String

			factoryE = CType(selFactory.MiscMsg, XmlOpera.Format.CATSDbServer.FactoryElement)
			modeE = factoryE.ModeElementList.Find(Function(o) o.Name = "*")
			If modeE Is Nothing Then Throw New Exception("Not found connection string in DbServerXml , factory='" & factoryE.Location & "' , mode='*'")

			connString = modeE.ConnString

			Dim catsDb As New CATS.BLL.CATSManager
			catsDb.ActivateCATS(connString)

			Dim modeBll As New CATS.BLL.modeManager
			Dim modeML As New List(Of CATS.Model.mode)
			modeML = modeBll.SelectAll

			For Each modeItem In modeML
				respItem = New ComboboxItem
				respItem.Text = modeItem.mode
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetDbModes()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Function GetSelectedMode() As ComboboxItem
		Try
			Return cmbMode.SelectedItem
		Catch ex As Exception
			Throw New Exception("GetSelectedMode()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub LoadModes(modeList As List(Of ComboboxItem))
		Try
			cmbMode.Items.Clear()
			If modeList Is Nothing Then Return

			For Each item In modeList
				cmbMode.Items.Add(item)
			Next

		Catch ex As Exception
			Throw New Exception("LoadModes()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Private Sub LoadModes(modeList As List(Of ComboboxItem), selModeName As String)
		Try
			'If modeList Is Nothing Then Return

			LoadModes(modeList)

			If modeList Is Nothing Then Return

			Dim selModeItem As ComboboxItem
			selModeItem = modeList.Find(Function(o) o.Text.ToUpper.Trim = selModeName.Trim.ToUpper)
			If selModeItem Is Nothing Then Throw New Exception("Mode parameters have  updated.")

			cmbMode.SelectedItem = selModeItem

		Catch ex As Exception
			Throw New Exception("LoadModes()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub

	Private Function GetXmlTestApplications(selFactoryName As String, selModeName As String) As List(Of ComboboxItem)
		Try
			Dim caFac As New XmlOpera.Factory.CATSApplications(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSApplicationsXmls)
			Dim caM As XmlOpera.Format.CATSApplications.CATSApplicationsElement = caFac.Read

			If caM.FactoryElementList Is Nothing Then Throw New Exception("Factory is empty in ApplicationXml.")

			Dim facE As XmlOpera.Format.CATSApplications.FactoryElement

			facE = caM.FactoryElementList.Find(Function(o) o.Location = selFactoryName)
			If facE Is Nothing Then facE = caM.FactoryElementList.Find(Function(o) o.Location = "*")
			If facE Is Nothing Then Throw New Exception("Not found factory paras in ApplicationXml, factory ='" & selFactoryName & "' or '*'")

			Dim modeE As XmlOpera.Format.CATSApplications.ModeElement
			modeE = facE.ModeElementList.Find(Function(o) o.Name = selModeName)
			If modeE Is Nothing Then modeE = facE.ModeElementList.Find(Function(o) o.Name = "*")
			If modeE Is Nothing Then Throw New Exception("Not found mode paras , mode ='" & selModeName & "' or '*'")
			If modeE.AppElementList Is Nothing Then Throw New Exception("Not found any apps in ApplicationXml, factory ='" & selFactoryName & "' or '*', mode='" & selModeName & "' or '*'")

			Dim resp As New List(Of ComboboxItem)
			Dim respItem As ComboboxItem

			For Each app In modeE.AppElementList
				respItem = New ComboboxItem
				respItem.Text = app.Name
				respItem.MiscMsg = app
				resp.Add(respItem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetXmlTestApplications()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	'Public Sub LoadTestApplications(appList As List(Of ComboboxItem), Optional selEnable As Boolean = False)
	'	Try
	'		If appList Is Nothing Then Return

	'		cklTestapplication.Items.Clear()

	'		Dim ceaFac As New XmlOpera.Factory.CATSEntryApplications(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSEntryApplicationsXmls)
	'		Dim ceaM As XmlOpera.Format.CATSEntryApplications.CATSEntryApplicationsElement = ceaFac.Read

	'		For Each app In appList
	'			If ceaM.AppElementList.Find(Function(o) o.Name = app.Text) Is Nothing Then
	'				cklTestapplication.Items.Add(app, False)
	'			Else
	'				If selEnable = True Then
	'					cklTestapplication.Items.Add(app, True)
	'				Else
	'					cklTestapplication.Items.Add(app, False)
	'				End If
	'			End If

	'		Next

	'	Catch ex As Exception
	'		Throw New Exception("LoadTestApplications()" & vbCrLf & " at " & ex.Message)
	'	End Try
	'End Sub

	Public Sub LoadTestApplications(appList As List(Of ComboboxItem))
		Try
			If appList Is Nothing Then Return

			cklTestapplication.Items.Clear()

			'Dim ceaFac As New XmlOpera.Factory.CATSEntryApplications(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSEntryApplicationsXmls)
			'Dim ceaM As XmlOpera.Format.CATSEntryApplications.CATSEntryApplicationsElement = ceaFac.Read

			For Each app In appList
				'If ceaM.AppElementList.Find(Function(o) o.Name = app.Text) Is Nothing Then
				'	cklTestapplication.Items.Add(app, False)
				'Else
				'	If selEnable = True Then
				'		cklTestapplication.Items.Add(app, True)
				'	Else
				cklTestapplication.Items.Add(app, False)
				'	End If
				'End If

			Next

		Catch ex As Exception
			Throw New Exception("LoadTestApplications()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub

	Public Function GetSelectedTestApplications() As List(Of ComboboxItem)
		Try
			Dim resp As New List(Of ComboboxItem)

			If cklTestapplication.CheckedItems Is Nothing Then Return Nothing

			For Each ckitem As ComboboxItem In cklTestapplication.CheckedItems
				resp.Add(ckitem)
			Next

			Return resp

		Catch ex As Exception
			Throw New Exception("GetSelectedTestApplications()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Sub FormSetting_Load(sender As Object, e As EventArgs) Handles Me.Load
		Try
			Dim factoryList As List(Of ComboboxItem)
			'Dim modeList As List(Of ComboboxItem)
			Dim catsXmlFac As New XmlOpera.Factory.CATS(_CatsUpdate.CATSXmlsFile)
			Dim catsXmlM As XmlOpera.Format.CATS.CATSElement = catsXmlFac.Read

			factoryList = GetXmlFactorys()

			If catsXmlM IsNot Nothing Then
				LoadFactorys(factoryList, catsXmlM.Factory.Location)
			Else
				LoadFactorys(factoryList, "")
			End If


			'modeList = GetDbModes(cmbFactory.SelectedItem)
			'LoadModes(modeList, catsXmlM.TestBench.Mode)

		Catch ex As Exception
			MsgBox("FormSetting()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Private Sub cmbFactory_GotFocus(sender As Object, e As EventArgs) Handles cmbFactory.GotFocus
		cmbFactory.BackColor = Color.GreenYellow
	End Sub

	Private Sub cmbFactory_LostFocus(sender As Object, e As EventArgs) Handles cmbFactory.LostFocus
		cmbFactory.BackColor = Color.White
	End Sub
	Private Sub cmbFactory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFactory.SelectedIndexChanged
		Try
			cmbMode.SelectedItem = Nothing
			Dim modeList As List(Of ComboboxItem)

			modeList = GetDbModes(cmbFactory.SelectedItem)
			LoadModes(modeList)

		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub
	Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
		Try
			cklTestapplication.Items.Clear()

			Dim selFactory As ComboboxItem = cmbFactory.SelectedItem
			Dim selMode As ComboboxItem = cmbMode.SelectedItem

			If selMode Is Nothing Then Return

			Dim appList As List(Of ComboboxItem)
			appList = GetXmlTestApplications(selFactory.Text, selMode.Text)

			LoadTestApplications(appList)

			'Dim catsXmlFac As New XmlOpera.Factory.CATS(_CatsUpdate.CATSXmlsPath)
			'Dim catsXmlM As XmlOpera.Format.CATS.CATSElement = catsXmlFac.Read

			'If catsXmlM.Factory.Location = selFactory.Text And catsXmlM.TestBench.Mode = selMode.Text Then
			'	LoadTestApplications(appList, True)
			'Else
			'	LoadTestApplications(appList, False)
			'End If

		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
		End Try
	End Sub
End Class