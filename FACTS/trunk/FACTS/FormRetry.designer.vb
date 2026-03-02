<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRetry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRetry))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslTimeElapsed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.rbRetryAll = New System.Windows.Forms.RadioButton()
        Me.rbRetryCurrentBand = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRetry = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "reconnect.png")
        Me.ImageList1.Images.SetKeyName(1, "retest.png")
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExit.Location = New System.Drawing.Point(457, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(94, 28)
        Me.btnExit.TabIndex = 30
        Me.btnExit.Text = "Exit Test"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnContinue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnContinue.Location = New System.Drawing.Point(357, 3)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(94, 28)
        Me.btnContinue.TabIndex = 29
        Me.btnContinue.Text = "Continue Test"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTimeElapsed, Me.tsslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 174)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(560, 22)
        Me.StatusStrip1.TabIndex = 31
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslTimeElapsed
        '
        Me.tsslTimeElapsed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.tsslTimeElapsed.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslTimeElapsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslTimeElapsed.Name = "tsslTimeElapsed"
        Me.tsslTimeElapsed.Size = New System.Drawing.Size(272, 17)
        Me.tsslTimeElapsed.Spring = True
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(272, 17)
        Me.tsslStatus.Spring = True
        '
        'rbRetryAll
        '
        Me.rbRetryAll.AutoSize = True
        Me.rbRetryAll.BackColor = System.Drawing.SystemColors.Window
        Me.rbRetryAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRetryAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rbRetryAll.Location = New System.Drawing.Point(12, 52)
        Me.rbRetryAll.Name = "rbRetryAll"
        Me.rbRetryAll.Size = New System.Drawing.Size(375, 20)
        Me.rbRetryAll.TabIndex = 2
        Me.rbRetryAll.Text = "Retry test all items of all bands/ 重新测试所有项目"
        Me.rbRetryAll.UseVisualStyleBackColor = False
        '
        'rbRetryCurrentBand
        '
        Me.rbRetryCurrentBand.AutoSize = True
        Me.rbRetryCurrentBand.BackColor = System.Drawing.SystemColors.Window
        Me.rbRetryCurrentBand.Checked = True
        Me.rbRetryCurrentBand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRetryCurrentBand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rbRetryCurrentBand.Location = New System.Drawing.Point(12, 26)
        Me.rbRetryCurrentBand.Name = "rbRetryCurrentBand"
        Me.rbRetryCurrentBand.Size = New System.Drawing.Size(401, 20)
        Me.rbRetryCurrentBand.TabIndex = 1
        Me.rbRetryCurrentBand.TabStop = True
        Me.rbRetryCurrentBand.Text = "Retry test all items of current band / 重新测试当前频段"
        Me.rbRetryCurrentBand.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rbRetryCurrentBand)
        Me.GroupBox1.Controls.Add(Me.rbRetryAll)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(554, 128)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Retry Option"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnRetry, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnContinue, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExit, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 137)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(554, 34)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'btnRetry
        '
        Me.btnRetry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRetry.Location = New System.Drawing.Point(257, 3)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(94, 28)
        Me.btnRetry.TabIndex = 28
        Me.btnRetry.Text = "Retry Test"
        Me.btnRetry.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(560, 174)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'FormRetry
        '
        Me.AcceptButton = Me.btnRetry
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(560, 196)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRetry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Retry"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnExit As Button
    Friend WithEvents btnContinue As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslTimeElapsed As ToolStripStatusLabel
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents rbRetryAll As RadioButton
    Friend WithEvents rbRetryCurrentBand As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnRetry As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label1 As Label
End Class
