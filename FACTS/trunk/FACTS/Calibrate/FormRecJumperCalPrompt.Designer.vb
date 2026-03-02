<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRecJumperCalPrompt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblConPrompt = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pbLiveModeProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslTimeElapsed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConPrompt
        '
        Me.lblConPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConPrompt.Location = New System.Drawing.Point(60, 385)
        Me.lblConPrompt.Name = "lblConPrompt"
        Me.lblConPrompt.Size = New System.Drawing.Size(333, 40)
        Me.lblConPrompt.TabIndex = 14
        Me.lblConPrompt.Text = "Please connect switch output MTJ at channel 1 to OPM detector thru receive jumper" &
    ""
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(283, 448)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(97, 32)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(70, 448)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(97, 32)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Receive Test Jumper Reference"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.FACTS.My.Resources.Resources.ReceiveJumperCal
        Me.PictureBox1.ImageLocation = ""
        Me.PictureBox1.Location = New System.Drawing.Point(74, 67)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 300)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbLiveModeProgress, Me.tsslTimeElapsed})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 494)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(452, 26)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbLiveModeProgress
        '
        Me.pbLiveModeProgress.Name = "pbLiveModeProgress"
        Me.pbLiveModeProgress.Size = New System.Drawing.Size(330, 20)
        '
        'tsslTimeElapsed
        '
        Me.tsslTimeElapsed.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslTimeElapsed.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslTimeElapsed.Name = "tsslTimeElapsed"
        Me.tsslTimeElapsed.Size = New System.Drawing.Size(105, 21)
        Me.tsslTimeElapsed.Spring = True
        Me.tsslTimeElapsed.Text = "00:00:00"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'FormRecJumperCalPrompt
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(452, 520)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblConPrompt)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormRecJumperCalPrompt"
        Me.Opacity = 0.8R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblConPrompt As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pbLiveModeProgress As ToolStripProgressBar
    Friend WithEvents tsslTimeElapsed As ToolStripStatusLabel
    Friend WithEvents Timer1 As Timer
End Class
