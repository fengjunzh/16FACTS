<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSetup
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
        Me.btnInitializeHardware = New System.Windows.Forms.Button()
        Me.lblHardwareInit = New System.Windows.Forms.Label()
        Me.gbDUTMeasRange = New System.Windows.Forms.GroupBox()
        Me.rbRange6 = New System.Windows.Forms.RadioButton()
        Me.rbRange5 = New System.Windows.Forms.RadioButton()
        Me.rbRange4 = New System.Windows.Forms.RadioButton()
        Me.rbRange3 = New System.Windows.Forms.RadioButton()
        Me.rbRange2 = New System.Windows.Forms.RadioButton()
        Me.rbRange1 = New System.Windows.Forms.RadioButton()
        Me.lblDUTMeasRange = New System.Windows.Forms.Label()
        Me.lblSystemIntegeration = New System.Windows.Forms.Label()
        Me.btnSysIntegration = New System.Windows.Forms.Button()
        Me.lblSetupComplete = New System.Windows.Forms.Label()
        Me.btnSetupComplete = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.btnRetMAP = New System.Windows.Forms.Button()
        Me.btnLiveMode = New System.Windows.Forms.Button()
        Me.gbDUTMeasRange.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInitializeHardware
        '
        Me.btnInitializeHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInitializeHardware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitializeHardware.Location = New System.Drawing.Point(23, 12)
        Me.btnInitializeHardware.Name = "btnInitializeHardware"
        Me.btnInitializeHardware.Size = New System.Drawing.Size(223, 30)
        Me.btnInitializeHardware.TabIndex = 4
        Me.btnInitializeHardware.Text = "Initialize Hardware"
        Me.btnInitializeHardware.UseVisualStyleBackColor = True
        '
        'lblHardwareInit
        '
        Me.lblHardwareInit.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblHardwareInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHardwareInit.Location = New System.Drawing.Point(7, 12)
        Me.lblHardwareInit.Name = "lblHardwareInit"
        Me.lblHardwareInit.Size = New System.Drawing.Size(10, 30)
        Me.lblHardwareInit.TabIndex = 2
        '
        'gbDUTMeasRange
        '
        Me.gbDUTMeasRange.Controls.Add(Me.rbRange1)
        Me.gbDUTMeasRange.Controls.Add(Me.rbRange6)
        Me.gbDUTMeasRange.Controls.Add(Me.rbRange5)
        Me.gbDUTMeasRange.Controls.Add(Me.rbRange4)
        Me.gbDUTMeasRange.Controls.Add(Me.rbRange3)
        Me.gbDUTMeasRange.Controls.Add(Me.rbRange2)
        Me.gbDUTMeasRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDUTMeasRange.Location = New System.Drawing.Point(23, 115)
        Me.gbDUTMeasRange.Name = "gbDUTMeasRange"
        Me.gbDUTMeasRange.Size = New System.Drawing.Size(224, 100)
        Me.gbDUTMeasRange.TabIndex = 7
        Me.gbDUTMeasRange.TabStop = False
        Me.gbDUTMeasRange.Text = "DUT Measurement Range"
        '
        'rbRange6
        '
        Me.rbRange6.AutoSize = True
        Me.rbRange6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange6.Location = New System.Drawing.Point(112, 71)
        Me.rbRange6.Name = "rbRange6"
        Me.rbRange6.Size = New System.Drawing.Size(111, 19)
        Me.rbRange6.TabIndex = 0
        Me.rbRange6.Text = "4,730 - 9,480 m"
        Me.rbRange6.UseVisualStyleBackColor = True
        '
        'rbRange5
        '
        Me.rbRange5.AutoSize = True
        Me.rbRange5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange5.Location = New System.Drawing.Point(112, 46)
        Me.rbRange5.Name = "rbRange5"
        Me.rbRange5.Size = New System.Drawing.Size(111, 19)
        Me.rbRange5.TabIndex = 0
        Me.rbRange5.Text = "1,880 - 4,730 m"
        Me.rbRange5.UseVisualStyleBackColor = True
        '
        'rbRange4
        '
        Me.rbRange4.AutoSize = True
        Me.rbRange4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange4.Location = New System.Drawing.Point(113, 21)
        Me.rbRange4.Name = "rbRange4"
        Me.rbRange4.Size = New System.Drawing.Size(110, 19)
        Me.rbRange4.TabIndex = 0
        Me.rbRange4.Text = "   930 - 1,880 m"
        Me.rbRange4.UseVisualStyleBackColor = True
        '
        'rbRange3
        '
        Me.rbRange3.AutoSize = True
        Me.rbRange3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange3.Location = New System.Drawing.Point(12, 71)
        Me.rbRange3.Name = "rbRange3"
        Me.rbRange3.Size = New System.Drawing.Size(91, 19)
        Me.rbRange3.TabIndex = 0
        Me.rbRange3.Text = "455 - 930 m"
        Me.rbRange3.UseVisualStyleBackColor = True
        '
        'rbRange2
        '
        Me.rbRange2.AutoSize = True
        Me.rbRange2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange2.Location = New System.Drawing.Point(12, 46)
        Me.rbRange2.Name = "rbRange2"
        Me.rbRange2.Size = New System.Drawing.Size(91, 19)
        Me.rbRange2.TabIndex = 0
        Me.rbRange2.Text = "170 - 455 m"
        Me.rbRange2.UseVisualStyleBackColor = True
        '
        'rbRange1
        '
        Me.rbRange1.AutoSize = True
        Me.rbRange1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRange1.Location = New System.Drawing.Point(12, 21)
        Me.rbRange1.Name = "rbRange1"
        Me.rbRange1.Size = New System.Drawing.Size(89, 19)
        Me.rbRange1.TabIndex = 0
        Me.rbRange1.Text = "    0 - 170 m"
        Me.rbRange1.UseVisualStyleBackColor = True
        '
        'lblDUTMeasRange
        '
        Me.lblDUTMeasRange.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblDUTMeasRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDUTMeasRange.Location = New System.Drawing.Point(7, 147)
        Me.lblDUTMeasRange.Name = "lblDUTMeasRange"
        Me.lblDUTMeasRange.Size = New System.Drawing.Size(10, 47)
        Me.lblDUTMeasRange.TabIndex = 2
        '
        'lblSystemIntegeration
        '
        Me.lblSystemIntegeration.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSystemIntegeration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSystemIntegeration.Location = New System.Drawing.Point(7, 62)
        Me.lblSystemIntegeration.Name = "lblSystemIntegeration"
        Me.lblSystemIntegeration.Size = New System.Drawing.Size(10, 30)
        Me.lblSystemIntegeration.TabIndex = 2
        '
        'btnSysIntegration
        '
        Me.btnSysIntegration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSysIntegration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSysIntegration.Location = New System.Drawing.Point(23, 62)
        Me.btnSysIntegration.Name = "btnSysIntegration"
        Me.btnSysIntegration.Size = New System.Drawing.Size(223, 30)
        Me.btnSysIntegration.TabIndex = 5
        Me.btnSysIntegration.Text = "System Integeration"
        Me.btnSysIntegration.UseVisualStyleBackColor = True
        '
        'lblSetupComplete
        '
        Me.lblSetupComplete.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSetupComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSetupComplete.Location = New System.Drawing.Point(6, 243)
        Me.lblSetupComplete.Name = "lblSetupComplete"
        Me.lblSetupComplete.Size = New System.Drawing.Size(10, 30)
        Me.lblSetupComplete.TabIndex = 2
        '
        'btnSetupComplete
        '
        Me.btnSetupComplete.Enabled = False
        Me.btnSetupComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetupComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetupComplete.Location = New System.Drawing.Point(23, 243)
        Me.btnSetupComplete.Name = "btnSetupComplete"
        Me.btnSetupComplete.Size = New System.Drawing.Size(223, 30)
        Me.btnSetupComplete.TabIndex = 16
        Me.btnSetupComplete.Text = "SETUP COMPLETE"
        Me.btnSetupComplete.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(289, 243)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(223, 30)
        Me.btnDone.TabIndex = 17
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.pgBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 293)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(524, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(207, 17)
        Me.tsslStatus.Spring = True
        '
        'pgBar
        '
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(300, 16)
        '
        'btnRetMAP
        '
        Me.btnRetMAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRetMAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetMAP.Location = New System.Drawing.Point(289, 12)
        Me.btnRetMAP.Name = "btnRetMAP"
        Me.btnRetMAP.Size = New System.Drawing.Size(223, 30)
        Me.btnRetMAP.TabIndex = 20
        Me.btnRetMAP.Text = "Reset MAP"
        Me.btnRetMAP.UseVisualStyleBackColor = True
        '
        'btnLiveMode
        '
        Me.btnLiveMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLiveMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiveMode.Location = New System.Drawing.Point(289, 62)
        Me.btnLiveMode.Name = "btnLiveMode"
        Me.btnLiveMode.Size = New System.Drawing.Size(223, 30)
        Me.btnLiveMode.TabIndex = 20
        Me.btnLiveMode.Text = "Live Mode"
        Me.btnLiveMode.UseVisualStyleBackColor = True
        '
        'FormSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 315)
        Me.Controls.Add(Me.btnLiveMode)
        Me.Controls.Add(Me.btnRetMAP)
        Me.Controls.Add(Me.gbDUTMeasRange)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnSetupComplete)
        Me.Controls.Add(Me.lblSetupComplete)
        Me.Controls.Add(Me.btnSysIntegration)
        Me.Controls.Add(Me.lblSystemIntegeration)
        Me.Controls.Add(Me.lblDUTMeasRange)
        Me.Controls.Add(Me.btnInitializeHardware)
        Me.Controls.Add(Me.lblHardwareInit)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MAP Setup"
        Me.gbDUTMeasRange.ResumeLayout(False)
        Me.gbDUTMeasRange.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnInitializeHardware As Button
    Friend WithEvents lblHardwareInit As Label
    Friend WithEvents gbDUTMeasRange As GroupBox
    Friend WithEvents rbRange6 As RadioButton
    Friend WithEvents rbRange5 As RadioButton
    Friend WithEvents rbRange4 As RadioButton
    Friend WithEvents rbRange3 As RadioButton
    Friend WithEvents rbRange2 As RadioButton
    Friend WithEvents rbRange1 As RadioButton
    Friend WithEvents lblDUTMeasRange As Label
    Friend WithEvents lblSystemIntegeration As Label
    Friend WithEvents btnSysIntegration As Button
    Friend WithEvents lblSetupComplete As Label
    Friend WithEvents btnSetupComplete As Button
    Friend WithEvents btnDone As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents pgBar As ToolStripProgressBar
    Friend WithEvents btnRetMAP As Button
    Friend WithEvents btnLiveMode As Button
End Class
