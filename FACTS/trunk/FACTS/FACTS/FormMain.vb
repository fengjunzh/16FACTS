
Public Class FormMain
    Private Sub FrmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        Me.ShowInTaskbar = False
        Me.Visible = False

        'AutoUpdate()

        gTestPlan = New TestPlan()
        gTestPlan.InitializeGui()

    End Sub
    Private Sub FrmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim frm As System.Windows.Forms.Form
        For Each frm In My.Application.OpenForms
            frm.Close()
        Next frm
    End Sub
    Private Sub AutoUpdate()
        Try
            ''Dim svrPath As String = My.Settings.UpdatePath
            'If svrPath.EndsWith("\") = False Then svrPath += "\"

            'Dim locPath As String = Application.StartupPath
            'If locPath.EndsWith("\") = False Then locPath += "\"

            'Dim updateFile = "CATSUpdate.exe"
            'If IO.File.Exists(svrPath & updateFile) = True Then
            '    FileCopy(svrPath & updateFile, locPath & updateFile)
            'End If

            'Dim appName As String = Application.ProductName

            'Dim svrVersion As String = FileVersionInfo.GetVersionInfo(svrPath & appName & ".exe").ProductVersion
            'Dim locVersion As String = Application.ProductVersion

            'Dim svrVer As New Version(svrVersion)
            'Dim locVer As New Version(locVersion)

            'If svrVer.CompareTo(locVer) > 0 Then
            '    MsgBox("Found the new version , the software will automatically update!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            '    Shell(locPath & "CATSTuningUpdate.exe " & svrPath, False)
            '    End
            'End If

        Catch ex As Exception
            Throw New Exception("AutoUpdate()::" & ex.Message)
        End Try
    End Sub
End Class
