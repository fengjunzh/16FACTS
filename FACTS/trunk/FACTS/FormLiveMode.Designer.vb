<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLiveMode
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
        Me.gbControl = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnSetWaveLength = New System.Windows.Forms.Button()
        Me.lblWaveLengthStatus = New System.Windows.Forms.Label()
        Me.btnSetChannel = New System.Windows.Forms.Button()
        Me.lblChStatus = New System.Windows.Forms.Label()
        Me.gbChannleSelector = New System.Windows.Forms.GroupBox()
        Me.nudChannels = New System.Windows.Forms.NumericUpDown()
        Me.flpWavelength = New System.Windows.Forms.FlowLayoutPanel()
        Me.gbWaveLengthSelector = New System.Windows.Forms.GroupBox()
        Me.gbIL = New System.Windows.Forms.GroupBox()
        Me.lblIL = New System.Windows.Forms.Label()
        Me.gbRL = New System.Windows.Forms.GroupBox()
        Me.lblRL = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPower = New System.Windows.Forms.Label()
        Me.gbControl.SuspendLayout()
        Me.gbChannleSelector.SuspendLayout()
        CType(Me.nudChannels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbWaveLengthSelector.SuspendLayout()
        Me.gbIL.SuspendLayout()
        Me.gbRL.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbControl
        '
        Me.gbControl.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.gbControl.Controls.Add(Me.btnExit)
        Me.gbControl.Controls.Add(Me.btnExecute)
        Me.gbControl.Controls.Add(Me.btnSetWaveLength)
        Me.gbControl.Controls.Add(Me.lblWaveLengthStatus)
        Me.gbControl.Controls.Add(Me.btnSetChannel)
        Me.gbControl.Controls.Add(Me.lblChStatus)
        Me.gbControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbControl.Location = New System.Drawing.Point(502, 12)
        Me.gbControl.Name = "gbControl"
        Me.gbControl.Size = New System.Drawing.Size(162, 479)
        Me.gbControl.TabIndex = 0
        Me.gbControl.TabStop = False
        Me.gbControl.Text = "Control"
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(27, 428)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(122, 34)
        Me.btnExit.TabIndex = 0
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnExecute
        '
        Me.btnExecute.Enabled = False
        Me.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExecute.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExecute.Location = New System.Drawing.Point(27, 241)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(122, 79)
        Me.btnExecute.TabIndex = 3
        Me.btnExecute.Text = "Start"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnSetWaveLength
        '
        Me.btnSetWaveLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetWaveLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetWaveLength.Location = New System.Drawing.Point(27, 116)
        Me.btnSetWaveLength.Name = "btnSetWaveLength"
        Me.btnSetWaveLength.Size = New System.Drawing.Size(122, 30)
        Me.btnSetWaveLength.TabIndex = 1
        Me.btnSetWaveLength.Text = "Set Wavelength"
        Me.btnSetWaveLength.UseVisualStyleBackColor = True
        '
        'lblWaveLengthStatus
        '
        Me.lblWaveLengthStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblWaveLengthStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWaveLengthStatus.Location = New System.Drawing.Point(11, 116)
        Me.lblWaveLengthStatus.Name = "lblWaveLengthStatus"
        Me.lblWaveLengthStatus.Size = New System.Drawing.Size(10, 30)
        Me.lblWaveLengthStatus.TabIndex = 0
        '
        'btnSetChannel
        '
        Me.btnSetChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetChannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetChannel.Location = New System.Drawing.Point(27, 22)
        Me.btnSetChannel.Name = "btnSetChannel"
        Me.btnSetChannel.Size = New System.Drawing.Size(122, 30)
        Me.btnSetChannel.TabIndex = 1
        Me.btnSetChannel.Text = "Set Channel"
        Me.btnSetChannel.UseVisualStyleBackColor = True
        '
        'lblChStatus
        '
        Me.lblChStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblChStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChStatus.Location = New System.Drawing.Point(11, 22)
        Me.lblChStatus.Name = "lblChStatus"
        Me.lblChStatus.Size = New System.Drawing.Size(10, 30)
        Me.lblChStatus.TabIndex = 0
        '
        'gbChannleSelector
        '
        Me.gbChannleSelector.Controls.Add(Me.nudChannels)
        Me.gbChannleSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbChannleSelector.Location = New System.Drawing.Point(13, 12)
        Me.gbChannleSelector.Name = "gbChannleSelector"
        Me.gbChannleSelector.Size = New System.Drawing.Size(479, 66)
        Me.gbChannleSelector.TabIndex = 1
        Me.gbChannleSelector.TabStop = False
        Me.gbChannleSelector.Text = "Channel Selector"
        '
        'nudChannels
        '
        Me.nudChannels.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudChannels.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.nudChannels.Location = New System.Drawing.Point(6, 22)
        Me.nudChannels.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudChannels.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudChannels.Name = "nudChannels"
        Me.nudChannels.Size = New System.Drawing.Size(499, 31)
        Me.nudChannels.TabIndex = 0
        Me.nudChannels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudChannels.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'flpWavelength
        '
        Me.flpWavelength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpWavelength.Location = New System.Drawing.Point(3, 17)
        Me.flpWavelength.Name = "flpWavelength"
        Me.flpWavelength.Size = New System.Drawing.Size(473, 80)
        Me.flpWavelength.TabIndex = 2
        '
        'gbWaveLengthSelector
        '
        Me.gbWaveLengthSelector.Controls.Add(Me.flpWavelength)
        Me.gbWaveLengthSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbWaveLengthSelector.Location = New System.Drawing.Point(13, 84)
        Me.gbWaveLengthSelector.Name = "gbWaveLengthSelector"
        Me.gbWaveLengthSelector.Size = New System.Drawing.Size(479, 100)
        Me.gbWaveLengthSelector.TabIndex = 3
        Me.gbWaveLengthSelector.TabStop = False
        Me.gbWaveLengthSelector.Text = "Wave Length Selector"
        '
        'gbIL
        '
        Me.gbIL.Controls.Add(Me.lblIL)
        Me.gbIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbIL.Location = New System.Drawing.Point(16, 206)
        Me.gbIL.Name = "gbIL"
        Me.gbIL.Size = New System.Drawing.Size(473, 73)
        Me.gbIL.TabIndex = 4
        Me.gbIL.TabStop = False
        Me.gbIL.Text = "IL Live Values(dB)"
        '
        'lblIL
        '
        Me.lblIL.AutoSize = True
        Me.lblIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIL.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIL.Location = New System.Drawing.Point(202, 28)
        Me.lblIL.Name = "lblIL"
        Me.lblIL.Size = New System.Drawing.Size(68, 31)
        Me.lblIL.TabIndex = 0
        Me.lblIL.Text = "------"
        '
        'gbRL
        '
        Me.gbRL.Controls.Add(Me.lblRL)
        Me.gbRL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRL.Location = New System.Drawing.Point(19, 285)
        Me.gbRL.Name = "gbRL"
        Me.gbRL.Size = New System.Drawing.Size(473, 100)
        Me.gbRL.TabIndex = 4
        Me.gbRL.TabStop = False
        Me.gbRL.Text = "RL Live Values(dB)"
        '
        'lblRL
        '
        Me.lblRL.AutoSize = True
        Me.lblRL.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRL.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRL.Location = New System.Drawing.Point(202, 42)
        Me.lblRL.Name = "lblRL"
        Me.lblRL.Size = New System.Drawing.Size(68, 31)
        Me.lblRL.TabIndex = 0
        Me.lblRL.Text = "------"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPower)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 391)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Power Live Values(dBm)"
        '
        'lblPower
        '
        Me.lblPower.AutoSize = True
        Me.lblPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPower.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPower.Location = New System.Drawing.Point(202, 42)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(68, 31)
        Me.lblPower.TabIndex = 0
        Me.lblPower.Text = "------"
        '
        'FormLiveMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 506)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbRL)
        Me.Controls.Add(Me.gbIL)
        Me.Controls.Add(Me.gbWaveLengthSelector)
        Me.Controls.Add(Me.gbChannleSelector)
        Me.Controls.Add(Me.gbControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLiveMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MAP-200 Live Mode"
        Me.gbControl.ResumeLayout(False)
        Me.gbChannleSelector.ResumeLayout(False)
        CType(Me.nudChannels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbWaveLengthSelector.ResumeLayout(False)
        Me.gbIL.ResumeLayout(False)
        Me.gbIL.PerformLayout()
        Me.gbRL.ResumeLayout(False)
        Me.gbRL.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbControl As GroupBox
    Friend WithEvents btnSetWaveLength As Button
    Friend WithEvents lblWaveLengthStatus As Label
    Friend WithEvents btnSetChannel As Button
    Friend WithEvents lblChStatus As Label
    Friend WithEvents gbChannleSelector As GroupBox
    Friend WithEvents nudChannels As NumericUpDown
    Friend WithEvents flpWavelength As FlowLayoutPanel
    Friend WithEvents gbWaveLengthSelector As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnExecute As Button
    Friend WithEvents gbIL As GroupBox
    Friend WithEvents lblIL As Label
    Friend WithEvents gbRL As GroupBox
    Friend WithEvents lblRL As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPower As Label
End Class
