Public Class FormMain
	Private _skin As New Sunisoft.IrisSkin.SkinEngine
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

	Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Me.Show()

			SetFormSkin()

			Dim cmdLineArgs() As String

			cmdLineArgs = My.Application.CommandLineArgs.ToArray

			Threading.Thread.Sleep(5000)

			Dim srcDir As String
			Dim desDir As String
			Dim startApp As String

			srcDir = cmdLineArgs(0)
			desDir = cmdLineArgs(1)
			startApp = cmdLineArgs(2)

			If srcDir.EndsWith("\") = False Then srcDir += "\"
			If desDir.EndsWith("\") = False Then desDir += "\"

			UpdateFACTSEntry(srcDir, desDir)

			Shell(desDir & startApp, AppWinStyle.Hide)

			End


		Catch ex As Exception
			MsgBox("Failed to update FACTSTestEntry.exe" & vbCrLf & " at " & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
			End
		End Try
	End Sub
	Public Function UpdateFACTSEntry(srcDirectory As String, desDirectory As String) As Boolean
		Try
			Dim fileArray() As String
			Dim fInfo As IO.FileInfo
			Dim fileExt As String
			Dim fileName As String
			Dim recNum As Integer

			fileArray = IO.Directory.GetFiles(srcDirectory, "*.*", IO.SearchOption.TopDirectoryOnly)


			ProgressBar1.Maximum = fileArray.Length
			ProgressBar1.Value = 0

			For Each file In fileArray

				fInfo = New IO.FileInfo(file)
				fileExt = fInfo.Extension
				fileName = fInfo.Name

				If fileExt.Contains("xmls") = False And fileName.Contains(My.Application.Info.ProductName) = False Then
					If IO.File.GetLastWriteTime(srcDirectory & fileName).CompareTo(IO.File.GetLastWriteTime(desDirectory & fileName)) > 0 Then
						IO.File.Copy(file, desDirectory & fileName, True)
					End If
				End If

				recNum += 1
				ProgressBar1.Value = recNum
				Threading.Thread.Sleep(50)

			Next

			Return True

		Catch ex As Exception
			Throw New Exception("UpdateFACTSEntry()" & vbCrLf & " at " & ex.Message)
		End Try

	End Function
End Class
