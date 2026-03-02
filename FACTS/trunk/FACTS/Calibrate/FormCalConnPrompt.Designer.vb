<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalConnPrompt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCalConnPrompt))
        Me.lblConPrompt = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pbLiveModeProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslTimeElapsed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConPrompt
        '
        Me.lblConPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConPrompt.Location = New System.Drawing.Point(89, 403)
        Me.lblConPrompt.Name = "lblConPrompt"
        Me.lblConPrompt.Size = New System.Drawing.Size(285, 40)
        Me.lblConPrompt.TabIndex = 9
        Me.lblConPrompt.Text = "Please connect switch output MTJ at channel 1 to OPM detector"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(289, 468)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(97, 32)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(76, 468)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(97, 32)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Master Test Jumper Reference"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.FACTS.My.Resources.Resources.Channe1Cal
        Me.PictureBox1.ImageLocation = ""
        Me.PictureBox1.Location = New System.Drawing.Point(80, 87)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(300, 300)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbLiveModeProgress, Me.tsslTimeElapsed})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(462, 26)
        Me.StatusStrip1.TabIndex = 16
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
        Me.tsslTimeElapsed.Size = New System.Drawing.Size(115, 21)
        Me.tsslTimeElapsed.Spring = True
        Me.tsslTimeElapsed.Text = "00:00:00"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Channe1Cal.png")
        Me.ImageList1.Images.SetKeyName(1, "Channel2Cal.png")
        Me.ImageList1.Images.SetKeyName(2, "Channe3Cal.png")
        Me.ImageList1.Images.SetKeyName(3, "Channe4Cal.png")
        Me.ImageList1.Images.SetKeyName(4, "Channel5Cal.png")
        Me.ImageList1.Images.SetKeyName(5, "Channe6Cal.png")
        Me.ImageList1.Images.SetKeyName(6, "Channe7Cal.png")
        Me.ImageList1.Images.SetKeyName(7, "Channe8Cal.png")
        Me.ImageList1.Images.SetKeyName(8, "Channel9Cal.png")
        Me.ImageList1.Images.SetKeyName(9, "Channel10Cal.png")
        Me.ImageList1.Images.SetKeyName(10, "Channel11Cal.png")
        Me.ImageList1.Images.SetKeyName(11, "Channel12Cal.png")
        Me.ImageList1.Images.SetKeyName(12, "Channel13Cal.png")
        Me.ImageList1.Images.SetKeyName(13, "Channel14Cal.png")
        Me.ImageList1.Images.SetKeyName(14, "Channel15Cal.png")
        Me.ImageList1.Images.SetKeyName(15, "Channel16Cal.png")
        Me.ImageList1.Images.SetKeyName(16, "Channel17Cal.png")
        Me.ImageList1.Images.SetKeyName(17, "Channel18Cal.png")
        Me.ImageList1.Images.SetKeyName(18, "Channel19Cal.png")
        Me.ImageList1.Images.SetKeyName(19, "Channel20Cal.png")
        Me.ImageList1.Images.SetKeyName(20, "Channel21Cal.png")
        Me.ImageList1.Images.SetKeyName(21, "Channel22Cal.png")
        Me.ImageList1.Images.SetKeyName(22, "Channel23Cal.png")
        Me.ImageList1.Images.SetKeyName(23, "Channel24Cal.png")
        '
        'FormCalConnPrompt
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(462, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblConPrompt)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalConnPrompt"
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
    Friend WithEvents ImageList1 As ImageList
End Class
