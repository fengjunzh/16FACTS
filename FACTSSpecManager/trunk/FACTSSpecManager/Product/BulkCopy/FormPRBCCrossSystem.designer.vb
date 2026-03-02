<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPRBCCrossSystem
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
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.progBarMode = New System.Windows.Forms.ProgressBar()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.progBarDB = New System.Windows.Forms.ProgressBar()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.lstErrMessage = New System.Windows.Forms.ListBox()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.progBarOverall = New System.Windows.Forms.ProgressBar()
		Me.ckDbList = New System.Windows.Forms.CheckedListBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.lstMessage = New System.Windows.Forms.ListBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.progBarPhase = New System.Windows.Forms.ProgressBar()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.ckModeList = New System.Windows.Forms.CheckedListBox()
		Me.txtProductList = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cmbSrcDb = New System.Windows.Forms.ComboBox()
		Me.btnCopy = New System.Windows.Forms.Button()
		Me.GroupBox2.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.Label11)
		Me.GroupBox2.Controls.Add(Me.progBarMode)
		Me.GroupBox2.Controls.Add(Me.Label10)
		Me.GroupBox2.Controls.Add(Me.progBarDB)
		Me.GroupBox2.Controls.Add(Me.Label9)
		Me.GroupBox2.Controls.Add(Me.lstErrMessage)
		Me.GroupBox2.Controls.Add(Me.Label8)
		Me.GroupBox2.Controls.Add(Me.progBarOverall)
		Me.GroupBox2.Controls.Add(Me.ckDbList)
		Me.GroupBox2.Controls.Add(Me.Label5)
		Me.GroupBox2.Controls.Add(Me.lstMessage)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Controls.Add(Me.Label6)
		Me.GroupBox2.Controls.Add(Me.progBarPhase)
		Me.GroupBox2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox2.ForeColor = System.Drawing.Color.Fuchsia
		Me.GroupBox2.Location = New System.Drawing.Point(430, 12)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(446, 621)
		Me.GroupBox2.TabIndex = 10
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Destination"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.ForeColor = System.Drawing.Color.Black
		Me.Label11.Location = New System.Drawing.Point(170, 137)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(61, 13)
		Me.Label11.TabIndex = 30
		Me.Label11.Text = "Each mode"
		'
		'progBarMode
		'
		Me.progBarMode.Location = New System.Drawing.Point(170, 153)
		Me.progBarMode.Name = "progBarMode"
		Me.progBarMode.Size = New System.Drawing.Size(266, 10)
		Me.progBarMode.TabIndex = 29
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.ForeColor = System.Drawing.Color.Black
		Me.Label10.Location = New System.Drawing.Point(170, 101)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(85, 13)
		Me.Label10.TabIndex = 28
		Me.Label10.Text = "Each database"
		'
		'progBarDB
		'
		Me.progBarDB.Location = New System.Drawing.Point(170, 117)
		Me.progBarDB.Name = "progBarDB"
		Me.progBarDB.Size = New System.Drawing.Size(266, 10)
		Me.progBarDB.TabIndex = 27
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label9.ForeColor = System.Drawing.Color.Black
		Me.Label9.Location = New System.Drawing.Point(9, 464)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(79, 13)
		Me.Label9.TabIndex = 26
		Me.Label9.Text = "Err Message:"
		'
		'lstErrMessage
		'
		Me.lstErrMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
		Me.lstErrMessage.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstErrMessage.FormattingEnabled = True
		Me.lstErrMessage.Location = New System.Drawing.Point(13, 480)
		Me.lstErrMessage.Name = "lstErrMessage"
		Me.lstErrMessage.Size = New System.Drawing.Size(427, 134)
		Me.lstErrMessage.TabIndex = 25
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.ForeColor = System.Drawing.Color.Black
		Me.Label8.Location = New System.Drawing.Point(170, 43)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(49, 13)
		Me.Label8.TabIndex = 24
		Me.Label8.Text = "Overall"
		'
		'progBarOverall
		'
		Me.progBarOverall.Location = New System.Drawing.Point(170, 59)
		Me.progBarOverall.Name = "progBarOverall"
		Me.progBarOverall.Size = New System.Drawing.Size(266, 15)
		Me.progBarOverall.TabIndex = 23
		'
		'ckDbList
		'
		Me.ckDbList.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ckDbList.FormattingEnabled = True
		Me.ckDbList.Location = New System.Drawing.Point(12, 45)
		Me.ckDbList.Name = "ckDbList"
		Me.ckDbList.Size = New System.Drawing.Size(152, 154)
		Me.ckDbList.TabIndex = 22
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.ForeColor = System.Drawing.Color.Black
		Me.Label5.Location = New System.Drawing.Point(10, 210)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(55, 13)
		Me.Label5.TabIndex = 21
		Me.Label5.Text = "Message:"
		'
		'lstMessage
		'
		Me.lstMessage.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lstMessage.FormattingEnabled = True
		Me.lstMessage.Location = New System.Drawing.Point(12, 226)
		Me.lstMessage.Name = "lstMessage"
		Me.lstMessage.Size = New System.Drawing.Size(428, 225)
		Me.lstMessage.TabIndex = 20
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Location = New System.Drawing.Point(170, 175)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(67, 13)
		Me.Label4.TabIndex = 19
		Me.Label4.Text = "Each phase"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.Color.Fuchsia
		Me.Label6.Location = New System.Drawing.Point(9, 29)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(55, 13)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "CATS Db:"
		'
		'progBarPhase
		'
		Me.progBarPhase.Location = New System.Drawing.Point(170, 189)
		Me.progBarPhase.Name = "progBarPhase"
		Me.progBarPhase.Size = New System.Drawing.Size(266, 10)
		Me.progBarPhase.TabIndex = 17
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.Label7)
		Me.GroupBox1.Controls.Add(Me.ckModeList)
		Me.GroupBox1.Controls.Add(Me.txtProductList)
		Me.GroupBox1.Controls.Add(Me.Label2)
		Me.GroupBox1.Controls.Add(Me.Label1)
		Me.GroupBox1.Controls.Add(Me.cmbSrcDb)
		Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
		Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(330, 621)
		Me.GroupBox1.TabIndex = 9
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Source"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(12, 476)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(37, 13)
		Me.Label7.TabIndex = 12
		Me.Label7.Text = "Mode:"
		'
		'ckModeList
		'
		Me.ckModeList.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ckModeList.FormattingEnabled = True
		Me.ckModeList.Items.AddRange(New Object() {"RD", "NPI", "PROD", "RETEST"})
		Me.ckModeList.Location = New System.Drawing.Point(15, 491)
		Me.ckModeList.Name = "ckModeList"
		Me.ckModeList.Size = New System.Drawing.Size(301, 109)
		Me.ckModeList.TabIndex = 11
		'
		'txtProductList
		'
		Me.txtProductList.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtProductList.Location = New System.Drawing.Point(12, 87)
		Me.txtProductList.Multiline = True
		Me.txtProductList.Name = "txtProductList"
		Me.txtProductList.Size = New System.Drawing.Size(304, 381)
		Me.txtProductList.TabIndex = 10
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 71)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(55, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Product:"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(55, 13)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "CATS Db:"
		'
		'cmbSrcDb
		'
		Me.cmbSrcDb.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbSrcDb.FormattingEnabled = True
		Me.cmbSrcDb.Location = New System.Drawing.Point(12, 40)
		Me.cmbSrcDb.Name = "cmbSrcDb"
		Me.cmbSrcDb.Size = New System.Drawing.Size(304, 21)
		Me.cmbSrcDb.TabIndex = 2
		'
		'btnCopy
		'
		Me.btnCopy.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCopy.ForeColor = System.Drawing.Color.Black
		Me.btnCopy.Location = New System.Drawing.Point(355, 20)
		Me.btnCopy.Name = "btnCopy"
		Me.btnCopy.Size = New System.Drawing.Size(62, 53)
		Me.btnCopy.TabIndex = 8
		Me.btnCopy.Text = "Copy >>"
		Me.btnCopy.UseVisualStyleBackColor = True
		'
		'FormPRBCCrossSystem
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(879, 645)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Controls.Add(Me.btnCopy)
		Me.Name = "FormPRBCCrossSystem"
		Me.Text = "* Bulk Copy - Cross System"
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents GroupBox2 As GroupBox
	Friend WithEvents ckDbList As CheckedListBox
	Friend WithEvents Label5 As Label
	Friend WithEvents lstMessage As ListBox
	Friend WithEvents Label4 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents progBarPhase As ProgressBar
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents Label7 As Label
	Friend WithEvents ckModeList As CheckedListBox
	Friend WithEvents txtProductList As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbSrcDb As ComboBox
	Friend WithEvents btnCopy As Button
	Friend WithEvents Label8 As Label
	Friend WithEvents progBarOverall As ProgressBar
	Friend WithEvents Label9 As Label
	Friend WithEvents lstErrMessage As ListBox
	Friend WithEvents Label10 As Label
	Friend WithEvents progBarDB As ProgressBar
	Friend WithEvents Label11 As Label
	Friend WithEvents progBarMode As ProgressBar
End Class
