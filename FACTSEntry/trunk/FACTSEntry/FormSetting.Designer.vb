<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetting
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSetting))
		Me.btnSave = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cmbFactory = New System.Windows.Forms.ComboBox()
		Me.cmbMode = New System.Windows.Forms.ComboBox()
		Me.cklTestapplication = New System.Windows.Forms.CheckedListBox()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'btnSave
		'
		Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnSave.Location = New System.Drawing.Point(206, 356)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(75, 25)
		Me.btnSave.TabIndex = 0
		Me.btnSave.Text = "Save"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(12, 31)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(47, 15)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Factory"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(12, 82)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(38, 15)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Mode"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(12, 140)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(94, 15)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "Test application:"
		'
		'cmbFactory
		'
		Me.cmbFactory.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbFactory.FormattingEnabled = True
		Me.cmbFactory.Location = New System.Drawing.Point(15, 47)
		Me.cmbFactory.Name = "cmbFactory"
		Me.cmbFactory.Size = New System.Drawing.Size(357, 24)
		Me.cmbFactory.TabIndex = 4
		'
		'cmbMode
		'
		Me.cmbMode.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbMode.FormattingEnabled = True
		Me.cmbMode.Location = New System.Drawing.Point(15, 98)
		Me.cmbMode.Name = "cmbMode"
		Me.cmbMode.Size = New System.Drawing.Size(357, 24)
		Me.cmbMode.TabIndex = 5
		'
		'cklTestapplication
		'
		Me.cklTestapplication.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cklTestapplication.FormattingEnabled = True
		Me.cklTestapplication.Location = New System.Drawing.Point(15, 156)
		Me.cklTestapplication.Name = "cklTestapplication"
		Me.cklTestapplication.Size = New System.Drawing.Size(357, 191)
		Me.cklTestapplication.TabIndex = 6
		'
		'btnExit
		'
		Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnExit.Location = New System.Drawing.Point(297, 356)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(75, 25)
		Me.btnExit.TabIndex = 7
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'FormSetting
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(384, 387)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.cklTestapplication)
		Me.Controls.Add(Me.cmbMode)
		Me.Controls.Add(Me.cmbFactory)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.btnSave)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormSetting"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Setting"
		Me.TopMost = True
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents cmbFactory As ComboBox
	Friend WithEvents cmbMode As ComboBox
	Friend WithEvents cklTestapplication As CheckedListBox
	Friend WithEvents btnExit As Button
End Class
