Public Class FormProcess
  Public Sub AutoWidth()
    With Label1
      Width = CreateGraphics.MeasureString(.Text, .Font).Width * (.Text.Length + 2) / .Text.Length
    End With
  End Sub

  Private Sub FormProcess_Load(sender As Object, e As EventArgs) Handles Me.Load
    With Screen.PrimaryScreen.WorkingArea
      Left = .Width \ 2 - Width \ 2
      Top = .Height \ 2 - Height \ 2
    End With
  End Sub
End Class