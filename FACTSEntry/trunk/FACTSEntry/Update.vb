Public Class Update
	Inherits CATSFile.CATSFilePath

	Public Event EReportDownloadProgress(totalNum As Integer, currNum As Integer)
	Public Function CompareFileTime(file1Name As String, file2Name As String) As Integer
		Try

			If IO.File.Exists(file2Name) = False Then Return 1

			Return IO.File.GetLastWriteTime(file1Name).CompareTo(IO.File.GetLastWriteTime(file2Name))
			'Dim f1Info As New IO.FileInfo(file1Name)
			'Dim f2Info As New IO.FileInfo(file2Name)


			'Return f1Info.LastAccessTime.CompareTo(f2Info.CreationTime)

		Catch ex As Exception
			Throw New Exception("CompareFileModifyTime()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Private Function CheckFileUpdate(file1Name As String, file2Name As String) As Boolean
		Try
			If CompareFileTime(file1Name, file2Name) = 1 Then Return True

			Return False

		Catch ex As Exception
			Throw New Exception("CheckFileUpdate()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Public Function IsCatsFileUpdate(file As CATSFile.CATSFileEnum) As Boolean
		Try
			Select Case file
				Case CATSFile.CATSFileEnum.CATSAppServerXmls
					Return CheckFileUpdate(MyBase.ServerEntryDirectory & MyBase.CATSAppServerXmls, MyBase.LocalEntryDirectory & MyBase.CATSAppServerXmls)
				Case CATSFile.CATSFileEnum.CATSDbServerXmls
					Return CheckFileUpdate(MyBase.ServerEntryDirectory & MyBase.CATSDbServerXmls, MyBase.LocalEntryDirectory & MyBase.CATSDbServerXmls)
				Case CATSFile.CATSFileEnum.CATSApplicationsXmls
					Return CheckFileUpdate(MyBase.ServerEntryDirectory & MyBase.CATSApplicationsXmls, MyBase.LocalEntryDirectory & MyBase.CATSApplicationsXmls)
				Case CATSFile.CATSFileEnum.CATSEntryApplicationsXmls
					Return CheckFileUpdate(MyBase.ServerEntryDirectory & MyBase.CATSEntryApplicationsXmls, MyBase.LocalEntryDirectory & MyBase.CATSEntryApplicationsXmls)
				Case CATSFile.CATSFileEnum.CATSUpdateExe
					Return CheckFileUpdate(MyBase.ServerEntryDirectory & MyBase.CATSUpdateExe, MyBase.LocalEntryDirectory & MyBase.CATSUpdateExe)
				Case CATSFile.CATSFileEnum.MeExe
					Return CheckFileUpdate(MyBase.ServerEntryDirectory & MyBase.MeExe, MyBase.LocalEntryDirectory & MyBase.MeExe)
				Case Else
					Return False
			End Select
		Catch ex As Exception
			Throw New Exception("IsCatsFileUpdate()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Public Function DownLoadCATSFiles(file As CATSFile.CATSFileEnum) As Boolean
		Try
			Dim srcFile As String
			Dim desFile As String

			Select Case file
				Case CATSFile.CATSFileEnum.CATSAppServerXmls
					srcFile = MyBase.ServerEntryDirectory & MyBase.CATSAppServerXmls
					desFile = MyBase.LocalEntryDirectory & MyBase.CATSAppServerXmls
				Case CATSFile.CATSFileEnum.CATSDbServerXmls
					srcFile = MyBase.ServerEntryDirectory & MyBase.CATSDbServerXmls
					desFile = MyBase.LocalEntryDirectory & MyBase.CATSDbServerXmls
				Case CATSFile.CATSFileEnum.CATSApplicationsXmls
					srcFile = MyBase.ServerEntryDirectory & MyBase.CATSApplicationsXmls
					desFile = MyBase.LocalEntryDirectory & MyBase.CATSApplicationsXmls
				Case CATSFile.CATSFileEnum.CATSEntryApplicationsXmls
					srcFile = MyBase.ServerEntryDirectory & MyBase.CATSEntryApplicationsXmls
					desFile = MyBase.LocalEntryDirectory & MyBase.CATSEntryApplicationsXmls
				Case CATSFile.CATSFileEnum.CATSUpdateExe
					srcFile = MyBase.ServerEntryDirectory & MyBase.CATSUpdateExe
					desFile = MyBase.LocalEntryDirectory & MyBase.CATSUpdateExe
				Case Else
					Return False
			End Select

			If IO.File.Exists(srcFile) = False Then Return False
			IO.File.Copy(srcFile, desFile, True)

			Return True

		Catch ex As Exception
			Throw New Exception("DownLoadCATSFiles()" & vbCrLf & " at " & ex.Message)
		End Try
	End Function
	Public Function DownLoadCATSLibFiles() As Boolean
		Try
			Dim srcFile As String
			Dim desFile As String

			srcFile = MyBase.ServerEntryDirectory
			desFile = MyBase.LocalEntryDirectory

			Dim fileArray() As String
			Dim fInfo As IO.FileInfo
			Dim fileExt As String
			Dim fileName As String

			fileArray = IO.Directory.GetFiles(srcFile, "*.*", IO.SearchOption.TopDirectoryOnly)

			For Each file In fileArray
				fInfo = New IO.FileInfo(file)
				fileExt = fInfo.Extension
				fileName = fInfo.Name

				If fileExt.Contains("xmls") Then Continue For
				If fileExt.Contains("exe") Then Continue For

				If CheckFileUpdate(srcFile & fileName, desFile & fileName) = True Then IO.File.Copy(file, desFile & fileName)

			Next


		Catch ex As Exception
			Throw New Exception("DownLoadCATSLibFiles()" & vbCrLf & " at " & ex.Message)
		End Try

	End Function
	Public Sub UpdateCATSXmls()
		Try
			Dim cxM As New XmlOpera.Format.CATS.CATSElement
			Dim cxFac As New XmlOpera.Factory.CATS(MyBase.CATSXmlsFile)

			cxM = cxFac.Read

			Dim cdxM As XmlOpera.Format.CATSDbServer.CATSDbServerElement
			Dim cdxFac As New XmlOpera.Factory.CATSDbServer(MyBase.LocalEntryDirectory & MyBase.CATSDbServerXmls)
			cdxM = cdxFac.Read

			Dim strCnn As String = ""
			For Each fac In cdxM.FactoryElementList

				If fac.Location = cxM.Factory.Location Then
					For Each md In fac.ModeElementList
						If md.Name = "*" Then strCnn = md.ConnString
						If md.Name.Trim.ToUpper = cxM.TestBench.Mode.Trim.ToUpper Then
							strCnn = md.ConnString : Exit For
						End If
					Next
					Exit For
				End If
			Next

			If cxM.DataBase.ConnString <> strCnn Then
				cxM.DataBase.ConnString = strCnn
				cxFac.Write(cxM)
			End If


		Catch ex As Exception
			Throw New Exception("UpdateCATSXmls()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Public Sub UpdateCATSEntryApplicationsXmls()
		Try
			Dim cxM As XmlOpera.Format.CATS.CATSElement
			Dim cxFac As New XmlOpera.Factory.CATS(MyBase.CATSXmlsFile)
			cxM = cxFac.Read

			UpdateCATSEntryApplicationsXmls(cxM.Factory.Location, cxM.TestBench.Mode)

		Catch ex As Exception
			Throw New Exception("UpdateCATSEntryApplicationsXmls()" & vbCrLf & " at " & ex.Message)
		End Try


	End Sub
	Public Sub UpdateCATSEntryApplicationsXmls(factory As String, mode As String)
		Try
			Dim caxM As XmlOpera.Format.CATSApplications.CATSApplicationsElement
			Dim caxFac As New XmlOpera.Factory.CATSApplications(MyBase.LocalEntryDirectory & MyBase.CATSApplicationsXmls)
			caxM = caxFac.Read

			Dim ceaxM As XmlOpera.Format.CATSEntryApplications.CATSEntryApplicationsElement
			Dim ceaxFac As New XmlOpera.Factory.CATSEntryApplications(MyBase.LocalEntryDirectory & MyBase.CATSEntryApplicationsXmls)
			ceaxM = ceaxFac.Read

			Dim modeList As List(Of XmlOpera.Format.CATSApplications.ModeElement)
			Dim appList As List(Of XmlOpera.Format.CATSApplications.AppElement)
			Dim currAppList As New List(Of String)

			For Each app In ceaxM.AppElementList
				currAppList.Add(app.Name)
			Next

			ceaxM.AppElementList.Clear()


			modeList = caxM.FactoryElementList.Find(Function(o) o.Location = factory).ModeElementList
			If modeList Is Nothing Then modeList = caxM.FactoryElementList.Find(Function(o) o.Location = "*").ModeElementList
			If modeList Is Nothing Then Throw New Exception("Not found factory MODE list , factory ='" & factory & "' and '*'")

			appList = modeList.Find(Function(o) o.Name = mode).AppElementList
			If appList Is Nothing Then appList = modeList.Find(Function(o) o.Name = "*").AppElementList
			If appList Is Nothing Then Throw New Exception("Not found MODE application list , MODE ='" & mode & "' and '*'")

			Dim appItem As XmlOpera.Format.CATSEntryApplications.AppElement
			For Each app In currAppList
				For Each app_ref In appList
					If app_ref.Name.Trim.ToUpper = app.Trim.ToUpper Then
						appItem = New XmlOpera.Format.CATSEntryApplications.AppElement
						appItem.Name = app_ref.Name
						appItem.AliasName = app_ref.AliasName
						appItem.ServerPath = app_ref.ServerPath
						appItem.Exe = app_ref.Exe
						ceaxM.AppElementList.Add(appItem)
					End If
				Next
			Next

			ceaxFac.Write(ceaxM)


		Catch ex As Exception
			Throw New Exception("UpdateCATSEntryApplicationsXmls()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Private Sub DownLoadDirectory(srcDirectoryPath As String, desDirectoryPath As String)
		Try
			Dim fileList() As String
			Dim srcFilepath As String
			Dim desFilepath As String
			Dim srcFileInfo As IO.FileInfo
			Dim srcFileName As String
			Dim srcFileFullName As String
			Dim desFileFullName As String

			If srcDirectoryPath.EndsWith("\") = False Then srcDirectoryPath += "\"
			If desDirectoryPath.EndsWith("\") = False Then desDirectoryPath += "\"

			' get all files
			fileList = IO.Directory.GetFiles(srcDirectoryPath, "*.*", IO.SearchOption.AllDirectories)


			For Each file In fileList
				'get src file full path
				srcFileInfo = New IO.FileInfo(file)

				srcFileName = srcFileInfo.Name

				'get src file directory
				srcFilepath = srcFileInfo.DirectoryName & "\"
				desFilepath = desDirectoryPath & srcFilepath.Replace(srcDirectoryPath, "")

				'mkdir des directory
				If IO.Directory.Exists(desFilepath) = False Then IO.Directory.CreateDirectory(desFilepath)

				'compare src file & des file, if not equal copy
				srcFileFullName = srcFilepath & srcFileName
				desFileFullName = desFilepath & srcFileName

				If CompareFileTime(srcFileFullName, desFileFullName) > 0 Then
					IO.File.Copy(srcFileFullName, desFileFullName, True)
				End If

			Next

		Catch ex As Exception
			Throw New Exception("DownLoadDirectory()" & vbCrLf & " at " & ex.Message)
		End Try
	End Sub
	Public Function DownLoadApps() As Boolean
		Try

			If IO.File.Exists(MyBase.LocalEntryDirectory & MyBase.CATSEntryApplicationsXmls) = False Then
				Throw New Exception("Not found Application Items , please re-setting.")
			End If
			Dim ceaxM As XmlOpera.Format.CATSEntryApplications.CATSEntryApplicationsElement
			Dim ceaxFac As New XmlOpera.Factory.CATSEntryApplications(MyBase.LocalEntryDirectory & MyBase.CATSEntryApplicationsXmls)

			ceaxM = ceaxFac.Read

			If ceaxM.AppElementList Is Nothing Then Throw New Exception("Not found Application Items")

			Dim totalNum As Integer
			Dim currNum As Integer = 0

			totalNum = ceaxM.AppElementList.Count

			RaiseEvent EReportDownloadProgress(totalNum, currNum)
      For Each appM In ceaxM.AppElementList
        'If appM.SyncEnable = True Then DownLoadDirectory(MyBase.ServerMainDirectory & appM.ServerPath, MyBase.LocalApplicationDirectory & appM.Name)
        If appM.SyncEnable = True Then DownLoadDirectory(MyBase.ServerMainDirectory & appM.ServerPath, appM.LocalPath)
        currNum += 1
        RaiseEvent EReportDownloadProgress(totalNum, currNum)
      Next

			Return True
		Catch ex As Exception
			Throw New Exception("DownLoadApps()" & vbCrLf & " at " & ex.Message)
		End Try

	End Function
End Class
