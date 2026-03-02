Public Class FormMain
    Private _skin As New Sunisoft.IrisSkin.SkinEngine
    Private WithEvents _CatsUpdate As Update
    Private Sub SetFormSkin()
        Try
            Dim skinfile As String = "MacOS.ssk"
            _skin.SkinFile = Application.StartupPath & "\" & skinfile
            _skin.Active = True
            My.Application.DoEvents()

        Catch ex As Exception
            Throw New Exception("FormSkin()::" & ex.Message)
        End Try
    End Sub

    Private Sub FormMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Me.Show()
            SetFormSkin()

            Dim ver As Version = My.Application.Info.Version

            Me.lblVersion.Text = "ver " & ver.Major & "." & ver.Minor & "." & ver.Build

            StartUp()

            ShowInterface()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub

#Region "Show GUI"
    Private Sub ShowInterfaceFactoryName(factoryName As String)
        lkbFactory.Text = factoryName
    End Sub
    Private Sub ShowInterfaceModeName(modeName As String)
        lkbMode.Text = modeName
    End Sub
    Private Sub ShowInterfacePCName()
        lkbPC.Text = My.Computer.Name
    End Sub
    Private Sub ShowInterfaceUserName()
        lkbUser.Text = Environment.UserName
    End Sub
    Private Sub ShowNetworkStatus(status As Boolean)
        Try
            If status = True Then
                lkbStatus.Text = "Online"
                lkbStatus.BackColor = Color.GreenYellow
            Else
                lkbStatus.Text = "Offline"
                lkbStatus.BackColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShowApplications(appFilePath As String)
        Try

            Dim appItem As ListViewItem

            Dim ceaxM As XmlOpera.Format.CATSEntryApplications.CATSEntryApplicationsElement
            Dim ceaxFac As New XmlOpera.Factory.CATSEntryApplications(appFilePath)

            ceaxM = ceaxFac.Read


            If ceaxM.AppElementList Is Nothing Then Throw New Exception("Not found Application Items")

            lvAppList.Items.Clear()
            For Each appM In ceaxM.AppElementList
                appItem = New ListViewItem
                appItem.Text = appM.AliasName
                appItem.ImageIndex = 1
                'appItem.Tag = appExeDirectory & appM.Name & "\" & appM.Exe
                If appM.LocalPath.EndsWith("\") = False Then appM.LocalPath += "\"
                appItem.Tag = appM.LocalPath & appM.Exe
                lvAppList.Items.Add(appItem)
            Next

        Catch ex As Exception
            Throw New Exception("ShowApplications()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub ShowInterface()
        Try
            If Not IO.Directory.Exists(_CatsUpdate.CATSXmlsFilePathDes) Then
                IO.Directory.CreateDirectory(_CatsUpdate.CATSXmlsFilePathDes)
            End If

            If IO.File.Exists(_CatsUpdate.CATSXmlsFileSource) Then
                If Not IO.File.Exists(_CatsUpdate.CATSXmlsFile) Then
                    IO.File.Copy(_CatsUpdate.CATSXmlsFileSource, _CatsUpdate.CATSXmlsFile)
                End If
            End If

            Dim catsXmlFac As New XmlOpera.Factory.CATS(_CatsUpdate.CATSXmlsFile)
            Dim catsXmlM As XmlOpera.Format.CATS.CATSElement = catsXmlFac.Read

            ShowInterfacePCName()
            ShowInterfaceUserName()

            If catsXmlM IsNot Nothing Then
                ShowInterfaceFactoryName(catsXmlM.Factory.Location)
                ShowInterfaceModeName(catsXmlM.TestBench.Mode)
            Else
                ShowInterfaceFactoryName("")
                ShowInterfaceModeName("")
            End If

            ShowApplications(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSEntryApplicationsXmls)

        Catch ex As Exception
            Throw New Exception("ShowInterface()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub ShowDownLoadProgress(totalNum As Integer, currNum As Integer) Handles _CatsUpdate.EReportDownloadProgress
        proSync.Maximum = totalNum
        proSync.Value = currNum
        Application.DoEvents()
    End Sub
#End Region
#Region "XML Doc"
    Private Sub UpdateUpdateExe(catsUpdate As Update)
        Try
            'copy update.exe to local
            If catsUpdate.IsCatsFileUpdate(CATSFile.CATSFileEnum.CATSUpdateExe) Then
                catsUpdate.DownLoadCATSFiles(CATSFile.CATSFileEnum.CATSUpdateExe)
            End If
        Catch ex As Exception
            Throw New Exception("UpdateUpdateExe()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    'Private Sub UpdateMeLib(catsUpdate As Update)
    '	Try
    '		'copy update.exe to local

    '		catsUpdate.DownLoadCATSLibFiles()

    '	Catch ex As Exception
    '		Throw New Exception("UpdateMeLib()" & vbCrLf & " at " & ex.Message)
    '	End Try
    'End Sub
    Private Sub UpdateMe(catsUpdate As Update)
        Try
            If catsUpdate.IsCatsFileUpdate(CATSFile.CATSFileEnum.MeExe) Then
                MsgBox("Found new verion , the software will automatically update !", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Dim cmd As String = catsUpdate.LocalEntryDirectory & catsUpdate.CATSUpdateExe & " " & catsUpdate.ServerEntryDirectory & " " & catsUpdate.LocalEntryDirectory & " " & catsUpdate.MeExe
                Shell(cmd, AppWinStyle.Hide, False, 5000)
                End
            End If
        Catch ex As Exception
            Throw New Exception("UpdateUpdateExe()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateAppServerXml(catsUpdate As Update)
        Try
            If catsUpdate.IsCatsFileUpdate(CATSFile.CATSFileEnum.CATSAppServerXmls) Then
                catsUpdate.DownLoadCATSFiles(CATSFile.CATSFileEnum.CATSAppServerXmls)
                MsgBox("The CATS server of test applications have been changed, CATSTestEntry will be closed then auto-switch to new server !", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                End
            End If
        Catch ex As Exception
            Throw New Exception("UpdateAppServerXml()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateDbServerXml(catsUpdate As Update)
        Try
            If catsUpdate.IsCatsFileUpdate(CATSFile.CATSFileEnum.CATSDbServerXmls) Then
                catsUpdate.DownLoadCATSFiles(CATSFile.CATSFileEnum.CATSDbServerXmls)
                catsUpdate.UpdateCATSXmls()
            End If
        Catch ex As Exception
            Throw New Exception("UpdateDbServerXml()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateApplicationsXml(catsUpdate As Update)
        Try
            If catsUpdate.IsCatsFileUpdate(CATSFile.CATSFileEnum.CATSApplicationsXmls) Then
                catsUpdate.DownLoadCATSFiles(CATSFile.CATSFileEnum.CATSApplicationsXmls)
                catsUpdate.UpdateCATSEntryApplicationsXmls()
            End If
        Catch ex As Exception
            Throw New Exception("UpdateApplicationsXml()" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
#End Region
    Private Sub StartUp()
        Try
            _CatsUpdate = New Update

            Dim appFac As New XmlOpera.Factory.CATSAppServer(_CatsUpdate.LocalEntryDirectory & _CatsUpdate.CATSAppServerXmls)
            Dim appM As XmlOpera.Format.CATSAppServer.CATSAppServerElement = appFac.Read

            If Network.CheckNetworkConnection(appM.Server.Name) = True Then
                _CatsUpdate.ServerMainDirectory = appM.Server.Name & "\" & appM.Server.Path

                'CATSAppServer.xmls
                UpdateAppServerXml(_CatsUpdate)

                'UpdateExe
                UpdateUpdateExe(_CatsUpdate)

                'update Me
                UpdateMe(_CatsUpdate)

                'update MeLib
                'UpdateMeLib(_CatsUpdate)

                'CATSDbServer.xmls
                UpdateDbServerXml(_CatsUpdate)

                'CATSApplications.xmls
                UpdateApplicationsXml(_CatsUpdate)

                'Read CATSEntryApplications.xmls , then down load apps to local
                _CatsUpdate.DownLoadApps()
                ShowNetworkStatus(True)

            Else
                ShowNetworkStatus(False)
                MsgBox("The CATS test applications server is offline now ! ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Try
            Dim idx As ListView.SelectedListViewItemCollection = lvAppList.SelectedItems
            Dim item As ListViewItem = idx(0)

            Shell(item.Tag, AppWinStyle.Hide, True, 10000)
            'Dim p As System.Diagnostics.ProcessStartInfo
            'Dim Proc As Process
            'p = New ProcessStartInfo(item.Tag)
            'p.WorkingDirectory = item.Tag
            'Proc = System.Diagnostics.Process.Start(p)

            End
        Catch ex As Exception
            MsgBox("btnRun_Click()" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
        Try
            Dim frm As New FormSetting(_CatsUpdate)
            frm.ShowDialog()
            StartUp()
            ShowInterface()
        Catch ex As Exception
            MsgBox("btnSetting_Click()" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub
End Class