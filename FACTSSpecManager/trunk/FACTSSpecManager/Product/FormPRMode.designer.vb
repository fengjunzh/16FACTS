<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPRMode
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSelNothing = New System.Windows.Forms.Button()
        Me.btnSelAnything = New System.Windows.Forms.Button()
        Me.ckModeValidity = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cklPhaseStation = New System.Windows.Forms.CheckedListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvMode = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbProduct = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.btnSelNothing)
        Me.GroupBox1.Controls.Add(Me.btnSelAnything)
        Me.GroupBox1.Controls.Add(Me.ckModeValidity)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cklPhaseStation)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.cmbMode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnUpdate)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 404)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'btnSelNothing
        '
        Me.btnSelNothing.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelNothing.Location = New System.Drawing.Point(403, 130)
        Me.btnSelNothing.Name = "btnSelNothing"
        Me.btnSelNothing.Size = New System.Drawing.Size(106, 25)
        Me.btnSelNothing.TabIndex = 52
        Me.btnSelNothing.Text = "Select Nothing"
        Me.btnSelNothing.UseVisualStyleBackColor = True
        '
        'btnSelAnything
        '
        Me.btnSelAnything.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelAnything.Location = New System.Drawing.Point(403, 90)
        Me.btnSelAnything.Name = "btnSelAnything"
        Me.btnSelAnything.Size = New System.Drawing.Size(106, 25)
        Me.btnSelAnything.TabIndex = 51
        Me.btnSelAnything.Text = "Select Anything"
        Me.btnSelAnything.UseVisualStyleBackColor = True
        '
        'ckModeValidity
        '
        Me.ckModeValidity.AutoSize = True
        Me.ckModeValidity.Checked = True
        Me.ckModeValidity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckModeValidity.Location = New System.Drawing.Point(253, 38)
        Me.ckModeValidity.Name = "ckModeValidity"
        Me.ckModeValidity.Size = New System.Drawing.Size(74, 17)
        Me.ckModeValidity.TabIndex = 50
        Me.ckModeValidity.Text = "Validity"
        Me.ckModeValidity.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Phase station:"
        '
        'cklPhaseStation
        '
        Me.cklPhaseStation.CheckOnClick = True
        Me.cklPhaseStation.FormattingEnabled = True
        Me.cklPhaseStation.Location = New System.Drawing.Point(18, 90)
        Me.cklPhaseStation.Name = "cklPhaseStation"
        Me.cklPhaseStation.Size = New System.Drawing.Size(368, 289)
        Me.cklPhaseStation.TabIndex = 48
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(403, 325)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(106, 25)
        Me.btnDelete.TabIndex = 47
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'cmbMode
        '
        Me.cmbMode.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Location = New System.Drawing.Point(18, 34)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(229, 21)
        Me.cmbMode.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Mode:"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(403, 364)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(106, 25)
        Me.btnExit.TabIndex = 35
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(403, 286)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(106, 25)
        Me.btnUpdate.TabIndex = 33
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(403, 247)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(106, 25)
        Me.btnAdd.TabIndex = 32
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgvMode
        '
        Me.dgvMode.AllowUserToAddRows = False
        Me.dgvMode.AllowUserToDeleteRows = False
        Me.dgvMode.BackgroundColor = System.Drawing.Color.White
        Me.dgvMode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dgvMode.Location = New System.Drawing.Point(15, 82)
        Me.dgvMode.MultiSelect = False
        Me.dgvMode.Name = "dgvMode"
        Me.dgvMode.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray
        Me.dgvMode.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMode.Size = New System.Drawing.Size(526, 107)
        Me.dgvMode.TabIndex = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "Order Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "Mode"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Validity"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Mode list In System:"
        '
        'cbProduct
        '
        Me.cbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProduct.BackColor = System.Drawing.Color.White
        Me.cbProduct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbProduct.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProduct.ForeColor = System.Drawing.Color.Black
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Location = New System.Drawing.Point(15, 29)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(315, 21)
        Me.cbProduct.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Product:"
        '
        'FormPRMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(553, 611)
        Me.Controls.Add(Me.dgvMode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbProduct)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormPRMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "*Mode"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents btnExit As Button
	Friend WithEvents btnUpdate As Button
	Friend WithEvents btnAdd As Button
	Friend WithEvents cmbMode As ComboBox
	Friend WithEvents Label3 As Label
	Friend WithEvents ListBox1 As ListBox
	Friend WithEvents btnDelete As Button
	Friend WithEvents cklPhaseStation As CheckedListBox
	Friend WithEvents dgvMode As DataGridView
	Friend WithEvents Label2 As Label
	Friend WithEvents cbProduct As ComboBox
	Friend WithEvents Label9 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents ckModeValidity As CheckBox
	Friend WithEvents Column1 As DataGridViewTextBoxColumn
	Friend WithEvents Column2 As DataGridViewTextBoxColumn
	Friend WithEvents Column3 As DataGridViewTextBoxColumn
	Friend WithEvents btnSelNothing As Button
	Friend WithEvents btnSelAnything As Button
End Class
