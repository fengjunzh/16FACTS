<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCATS = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbConnString = New System.Windows.Forms.ComboBox()
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCATS)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.cbConnString)
        Me.GroupBox1.Controls.Add(Me.BtnConnect)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 321)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'lblCATS
        '
        Me.lblCATS.AutoSize = True
        Me.lblCATS.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCATS.Location = New System.Drawing.Point(6, 300)
        Me.lblCATS.Name = "lblCATS"
        Me.lblCATS.Size = New System.Drawing.Size(115, 13)
        Me.lblCATS.TabIndex = 8
        Me.lblCATS.Text = "FACTS Spec Manager"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(496, 287)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(68, 25)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(176, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CATS Server:"
        '
        'cbConnString
        '
        Me.cbConnString.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConnString.FormattingEnabled = True
        Me.cbConnString.Location = New System.Drawing.Point(179, 135)
        Me.cbConnString.Name = "cbConnString"
        Me.cbConnString.Size = New System.Drawing.Size(221, 22)
        Me.cbConnString.TabIndex = 3
        '
        'BtnConnect
        '
        Me.BtnConnect.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConnect.Location = New System.Drawing.Point(410, 287)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(68, 25)
        Me.BtnConnect.TabIndex = 2
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.FACTSSpecManager.My.Resources.Resources.ANDREW_logo_250x47
        Me.PictureBox1.Location = New System.Drawing.Point(6, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(249, 51)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'FormLogin
        '
        Me.AcceptButton = Me.BtnConnect
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(582, 323)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents btnExit As Button
	Friend WithEvents Label1 As Label
    Friend WithEvents cbConnString As ComboBox
    Friend WithEvents BtnConnect As Button
    Friend WithEvents lblCATS As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
