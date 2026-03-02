<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPRBCCrossProduct
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
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pbCopyProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbModeSrc = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ckPhase = New System.Windows.Forms.CheckedListBox()
        Me.cbProductSrc = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProductDes = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLengthMeterDes = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstPhase = New System.Windows.Forms.ListBox()
        Me.cbModeDes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbFamily = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.AcceptsReturn = True
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtStatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStatus.Location = New System.Drawing.Point(2, 490)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.txtStatus.MaxLength = 0
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(686, 219)
        Me.txtStatus.TabIndex = 12
        Me.txtStatus.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbCopyProgress})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 738)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(690, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbCopyProgress
        '
        Me.pbCopyProgress.Name = "pbCopyProgress"
        Me.pbCopyProgress.Size = New System.Drawing.Size(675, 16)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(10, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 116
        Me.Label5.Text = "Product:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbModeSrc)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.ckPhase)
        Me.GroupBox1.Controls.Add(Me.cbProductSrc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 478)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Source"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(10, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Mode:"
        '
        'cbModeSrc
        '
        Me.cbModeSrc.BackColor = System.Drawing.Color.White
        Me.cbModeSrc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbModeSrc.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbModeSrc.ForeColor = System.Drawing.Color.Black
        Me.cbModeSrc.FormattingEnabled = True
        Me.cbModeSrc.Location = New System.Drawing.Point(12, 84)
        Me.cbModeSrc.Name = "cbModeSrc"
        Me.cbModeSrc.Size = New System.Drawing.Size(240, 21)
        Me.cbModeSrc.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(12, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 116
        Me.Label9.Text = "Product:"
        '
        'ckPhase
        '
        Me.ckPhase.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckPhase.FormattingEnabled = True
        Me.ckPhase.Location = New System.Drawing.Point(12, 135)
        Me.ckPhase.Name = "ckPhase"
        Me.ckPhase.Size = New System.Drawing.Size(240, 304)
        Me.ckPhase.TabIndex = 2
        '
        'cbProductSrc
        '
        Me.cbProductSrc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProductSrc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProductSrc.BackColor = System.Drawing.Color.White
        Me.cbProductSrc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbProductSrc.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbProductSrc.ForeColor = System.Drawing.Color.Black
        Me.cbProductSrc.FormattingEnabled = True
        Me.cbProductSrc.Location = New System.Drawing.Point(12, 37)
        Me.cbProductSrc.Name = "cbProductSrc"
        Me.cbProductSrc.Size = New System.Drawing.Size(240, 21)
        Me.cbProductSrc.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(12, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Phase:"
        '
        'txtProductDes
        '
        Me.txtProductDes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductDes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProductDes.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDes.Location = New System.Drawing.Point(167, 2)
        Me.txtProductDes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProductDes.Name = "txtProductDes"
        Me.txtProductDes.Size = New System.Drawing.Size(221, 22)
        Me.txtProductDes.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLengthMeterDes)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lstPhase)
        Me.GroupBox2.Controls.Add(Me.cbModeDes)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(423, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 478)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destination"
        '
        'txtLengthMeterDes
        '
        Me.txtLengthMeterDes.Location = New System.Drawing.Point(12, 37)
        Me.txtLengthMeterDes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLengthMeterDes.Name = "txtLengthMeterDes"
        Me.txtLengthMeterDes.Size = New System.Drawing.Size(240, 20)
        Me.txtLengthMeterDes.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(10, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Mode:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(10, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 13)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "Product Length(Meter):"
        '
        'lstPhase
        '
        Me.lstPhase.FormattingEnabled = True
        Me.lstPhase.Location = New System.Drawing.Point(12, 135)
        Me.lstPhase.Name = "lstPhase"
        Me.lstPhase.Size = New System.Drawing.Size(240, 303)
        Me.lstPhase.TabIndex = 2
        Me.lstPhase.TabStop = False
        '
        'cbModeDes
        '
        Me.cbModeDes.BackColor = System.Drawing.Color.White
        Me.cbModeDes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbModeDes.Font = New System.Drawing.Font("Consolas", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cbModeDes.ForeColor = System.Drawing.Color.Black
        Me.cbModeDes.FormattingEnabled = True
        Me.cbModeDes.Location = New System.Drawing.Point(12, 84)
        Me.cbModeDes.Name = "cbModeDes"
        Me.cbModeDes.Size = New System.Drawing.Size(240, 21)
        Me.cbModeDes.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Phase:"
        '
        'btnCopy
        '
        Me.btnCopy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCopy.Enabled = False
        Me.btnCopy.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(3, 202)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(144, 75)
        Me.btnCopy.TabIndex = 3
        Me.btnCopy.Text = "Copy To ->"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtProductDes, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbFamily, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExit, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(690, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 27)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Destination Product:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(392, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 27)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Family:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbFamily
        '
        Me.cbFamily.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbFamily.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFamily.FormattingEnabled = True
        Me.cbFamily.Location = New System.Drawing.Point(467, 2)
        Me.cbFamily.Margin = New System.Windows.Forms.Padding(2)
        Me.cbFamily.Name = "cbFamily"
        Me.cbFamily.Size = New System.Drawing.Size(146, 22)
        Me.cbFamily.TabIndex = 1
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExit.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(617, 2)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(71, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 266.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 2)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(686, 484)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnCopy, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(268, 2)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(150, 480)
        Me.TableLayoutPanel4.TabIndex = 10
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtStatus, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 488.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(690, 711)
        Me.TableLayoutPanel3.TabIndex = 14
        '
        'FormPRBCCrossProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 760)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPRBCCrossProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bulk Copy - Cross Product"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents txtStatus As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pbCopyProgress As ToolStripProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbModeSrc As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ckPhase As CheckedListBox
    Friend WithEvents cbProductSrc As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProductDes As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lstPhase As ListBox
    Friend WithEvents cbModeDes As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCopy As Button
    Friend WithEvents txtLengthMeterDes As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cbFamily As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
End Class
