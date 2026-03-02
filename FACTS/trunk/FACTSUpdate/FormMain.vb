Public Class FormMain
	Private Sub SetFormSkin()
		Try
			Dim skinfile As String = "MacOS.ssk"
			Dim skin As New Sunisoft.IrisSkin.SkinEngine
			skin.SkinFile = Application.StartupPath & "\" & skinfile
			skin.Active = True

		Catch ex As Exception
			Throw New Exception("FormMain.SetFormSkin()::" & vbCrLf & "at" & ex.Message)
		End Try
	End Sub
	Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
		Try
			Threading.Thread.Sleep(1000)
			Dim cmdParas(0) As String
			Dim mainPath As String

			cmdParas = My.Application.CommandLineArgs.ToArray
			If cmdParas.Length = 0 Then
				Throw New Exception("FACTS Update error.")
			End If

			mainPath = cmdParas(0)
			SetFormSkin()
			Me.Show()

			ProgramUpdate(mainPath)

			End

		Catch ex As Exception
			MsgBox("FormMain.FormMain_Load()::" & vbCrLf & "at" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load FormMain")
			End
		End Try
	End Sub
	Private Sub ProgramUpdate(path As String)
		Try
			Dim srcP As String = path
			Dim desP As String = Application.StartupPath
			Dim fileName As String

			Dim fileArray() As String = IO.Directory.GetFiles(srcP)

			ProgressBar1.Minimum = 1
			ProgressBar1.Maximum = fileArray.Length + 1


			For Each file In fileArray
				fileName = New IO.FileInfo(file).Name
				If fileName.ToString.ToUpper.Contains(Application.ProductName.ToString.ToUpper) = False Then
					FileCopy(file, desP & "\" & fileName)
				End If
				ProgressBar1.Value += 1
				Threading.Thread.Sleep(200)
				My.Application.DoEvents()
			Next


		Catch ex As Exception
			Throw New Exception("FormMain.ProgramUpdate()::" & vbCrLf & "at" & ex.Message)
		End Try
	End Sub
End Class
