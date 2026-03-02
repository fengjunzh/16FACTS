Public Class FormRecJumperCalPrompt
    Private StartTime As DateTime
    Private TSpan As TimeSpan
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub FormRecJumperCalPrompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pbLiveModeProgress.Minimum = 0
        Me.pbLiveModeProgress.Maximum = 300
        Me.pbLiveModeProgress.Value = 0
        StartTime = Now
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If pbLiveModeProgress.Value < pbLiveModeProgress.Maximum Then pbLiveModeProgress.Value += 1
            TSpan = DateTime.Now - StartTime
            Me.tsslTimeElapsed.Text = String.Format("{0:00}:{1:00}:{2:00} ", TSpan.Hours, TSpan.Minutes, TSpan.Seconds)
        Catch ex As Exception
            Throw New Exception("FormRecJumperCalPrompt.Timer1_Tick()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
End Class