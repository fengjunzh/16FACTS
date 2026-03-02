<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPRBCCrossMode
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbProduct = New System.Windows.Forms.ComboBox()
        Me.cbModeSrc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.ckPhase = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstPhase = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbModeDes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(16, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Product:"
        '
        'cbProduct
        '
        Me.cbProduct.BackColor = System.Drawing.Color.White
        Me.cbProduct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbProduct.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbProduct.ForeColor = System.Drawing.Color.Black
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Location = New System.Drawing.Point(77, 26)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(208, 21)
        Me.cbProduct.TabIndex = 101
        '
        'cbModeSrc
        '
        Me.cbModeSrc.BackColor = System.Drawing.Color.White
        Me.cbModeSrc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbModeSrc.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbModeSrc.ForeColor = System.Drawing.Color.Black
        Me.cbModeSrc.FormattingEnabled = True
        Me.cbModeSrc.Location = New System.Drawing.Point(12, 38)
        Me.cbModeSrc.Name = "cbModeSrc"
        Me.cbModeSrc.Size = New System.Drawing.Size(240, 21)
        Me.cbModeSrc.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Mode:"
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(312, 80)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 51)
        Me.btnCopy.TabIndex = 108
        Me.btnCopy.Text = "Copy To ->"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'ckPhase
        '
        Me.ckPhase.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPhase.FormattingEnabled = True
        Me.ckPhase.Location = New System.Drawing.Point(12, 89)
        Me.ckPhase.Name = "ckPhase"
        Me.ckPhase.Size = New System.Drawing.Size(240, 304)
        Me.ckPhase.TabIndex = 109
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Phase:"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(312, 26)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 113
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckPhase)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbModeSrc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 406)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Source"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstPhase)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cbModeDes)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(411, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(266, 406)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destination"
        '
        'lstPhase
        '
        Me.lstPhase.FormattingEnabled = True
        Me.lstPhase.Location = New System.Drawing.Point(12, 89)
        Me.lstPhase.Name = "lstPhase"
        Me.lstPhase.Size = New System.Drawing.Size(242, 303)
        Me.lstPhase.TabIndex = 112
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Mode:"
        '
        'cbModeDes
        '
        Me.cbModeDes.BackColor = System.Drawing.Color.White
        Me.cbModeDes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbModeDes.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbModeDes.ForeColor = System.Drawing.Color.Black
        Me.cbModeDes.FormattingEnabled = True
        Me.cbModeDes.Location = New System.Drawing.Point(12, 38)
        Me.cbModeDes.Name = "cbModeDes"
        Me.cbModeDes.Size = New System.Drawing.Size(242, 21)
        Me.cbModeDes.TabIndex = 103
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Phase:"
        '
        'FormPRBCCrossMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 490)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbProduct)
        Me.Name = "FormPRBCCrossMode"
        Me.Text = "* Bulk Copy - Cross Mode"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
	Friend WithEvents cbProduct As ComboBox
	Friend WithEvents cbModeSrc As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents btnCopy As Button
	Friend WithEvents ckPhase As CheckedListBox
	Friend WithEvents Label3 As Label
	Friend WithEvents btnExit As Button
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents Label2 As Label
	Friend WithEvents cbModeDes As ComboBox
	Friend WithEvents Label4 As Label
	Friend WithEvents lstPhase As ListBox
End Class
