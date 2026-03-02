<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalibrate
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
        Me.btnStartCal = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.layoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.fgCal = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNothingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReverseSelectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllInvalidToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbLiveDisplay = New System.Windows.Forms.GroupBox()
        Me.lblPower = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblWavelength = New System.Windows.Forms.Label()
        Me.lblORL = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIL = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbReferenceLimits = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLimit3 = New System.Windows.Forms.Label()
        Me.lblLimit2 = New System.Windows.Forms.Label()
        Me.lblLimit1 = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslpbCal = New System.Windows.Forms.ToolStripProgressBar()
        Me.layoutMain.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.fgCal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMenu.SuspendLayout()
        Me.gbLiveDisplay.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbReferenceLimits.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStartCal
        '
        Me.btnStartCal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartCal.Location = New System.Drawing.Point(29, 14)
        Me.btnStartCal.Name = "btnStartCal"
        Me.btnStartCal.Size = New System.Drawing.Size(98, 24)
        Me.btnStartCal.TabIndex = 6
        Me.btnStartCal.Text = "Start Cal"
        Me.btnStartCal.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(29, 80)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(98, 24)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'layoutMain
        '
        Me.layoutMain.ColumnCount = 2
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163.0!))
        Me.layoutMain.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.layoutMain.Controls.Add(Me.Panel1, 1, 0)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(0, 0)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.RowCount = 1
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 415.0!))
        Me.layoutMain.Size = New System.Drawing.Size(1034, 415)
        Me.layoutMain.TabIndex = 10
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fgCal)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbLiveDisplay)
        Me.SplitContainer1.Size = New System.Drawing.Size(865, 409)
        Me.SplitContainer1.SplitterDistance = 289
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 13
        '
        'fgCal
        '
        Me.fgCal.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.fgCal.ContextMenuStrip = Me.cmsMenu
        Me.fgCal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgCal.ExtendLastCol = True
        Me.fgCal.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgCal.Location = New System.Drawing.Point(0, 0)
        Me.fgCal.Name = "fgCal"
        Me.fgCal.Rows.Count = 1
        Me.fgCal.Rows.DefaultSize = 19
        Me.fgCal.Size = New System.Drawing.Size(863, 287)
        Me.fgCal.TabIndex = 9
        '
        'cmsMenu
        '
        Me.cmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNothingToolStripMenuItem, Me.ReverseSelectToolStripMenuItem, Me.SelectAllInvalidToolStripMenuItem})
        Me.cmsMenu.Name = "cmsMenu"
        Me.cmsMenu.Size = New System.Drawing.Size(161, 92)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'SelectNothingToolStripMenuItem
        '
        Me.SelectNothingToolStripMenuItem.Name = "SelectNothingToolStripMenuItem"
        Me.SelectNothingToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SelectNothingToolStripMenuItem.Text = "Select Nothing"
        '
        'ReverseSelectToolStripMenuItem
        '
        Me.ReverseSelectToolStripMenuItem.Name = "ReverseSelectToolStripMenuItem"
        Me.ReverseSelectToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ReverseSelectToolStripMenuItem.Text = "Reverse Select"
        '
        'SelectAllInvalidToolStripMenuItem
        '
        Me.SelectAllInvalidToolStripMenuItem.Name = "SelectAllInvalidToolStripMenuItem"
        Me.SelectAllInvalidToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.SelectAllInvalidToolStripMenuItem.Text = "Select All Invalid"
        '
        'gbLiveDisplay
        '
        Me.gbLiveDisplay.Controls.Add(Me.lblPower)
        Me.gbLiveDisplay.Controls.Add(Me.Label6)
        Me.gbLiveDisplay.Controls.Add(Me.lblWavelength)
        Me.gbLiveDisplay.Controls.Add(Me.lblORL)
        Me.gbLiveDisplay.Controls.Add(Me.Label8)
        Me.gbLiveDisplay.Controls.Add(Me.Label3)
        Me.gbLiveDisplay.Controls.Add(Me.lblChannel)
        Me.gbLiveDisplay.Controls.Add(Me.Label5)
        Me.gbLiveDisplay.Controls.Add(Me.lblIL)
        Me.gbLiveDisplay.Controls.Add(Me.Label2)
        Me.gbLiveDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLiveDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLiveDisplay.Location = New System.Drawing.Point(0, 0)
        Me.gbLiveDisplay.Name = "gbLiveDisplay"
        Me.gbLiveDisplay.Size = New System.Drawing.Size(863, 113)
        Me.gbLiveDisplay.TabIndex = 1
        Me.gbLiveDisplay.TabStop = False
        Me.gbLiveDisplay.Text = "Live Display"
        '
        'lblPower
        '
        Me.lblPower.AutoSize = True
        Me.lblPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPower.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPower.Location = New System.Drawing.Point(624, 65)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(39, 20)
        Me.lblPower.TabIndex = 1
        Me.lblPower.Text = "------"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(562, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Power:"
        '
        'lblWavelength
        '
        Me.lblWavelength.AutoSize = True
        Me.lblWavelength.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelength.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblWavelength.Location = New System.Drawing.Point(548, 28)
        Me.lblWavelength.Name = "lblWavelength"
        Me.lblWavelength.Size = New System.Drawing.Size(39, 20)
        Me.lblWavelength.TabIndex = 1
        Me.lblWavelength.Text = "------"
        '
        'lblORL
        '
        Me.lblORL.AutoSize = True
        Me.lblORL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORL.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblORL.Location = New System.Drawing.Point(426, 65)
        Me.lblORL.Name = "lblORL"
        Me.lblORL.Size = New System.Drawing.Size(39, 20)
        Me.lblORL.TabIndex = 1
        Me.lblORL.Text = "------"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(445, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Wavelength:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(374, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ORL:"
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChannel.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblChannel.Location = New System.Drawing.Point(358, 28)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(39, 20)
        Me.lblChannel.TabIndex = 1
        Me.lblChannel.Text = "------"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(280, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Channel:"
        '
        'lblIL
        '
        Me.lblIL.AutoSize = True
        Me.lblIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIL.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIL.Location = New System.Drawing.Point(236, 65)
        Me.lblIL.Name = "lblIL"
        Me.lblIL.Size = New System.Drawing.Size(39, 20)
        Me.lblIL.TabIndex = 1
        Me.lblIL.Text = "------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(203, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "IL:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gbReferenceLimits)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnAbort)
        Me.Panel1.Controls.Add(Me.btnStartCal)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(874, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 409)
        Me.Panel1.TabIndex = 9
        '
        'gbReferenceLimits
        '
        Me.gbReferenceLimits.Controls.Add(Me.Label7)
        Me.gbReferenceLimits.Controls.Add(Me.lblLimit3)
        Me.gbReferenceLimits.Controls.Add(Me.lblLimit2)
        Me.gbReferenceLimits.Controls.Add(Me.lblLimit1)
        Me.gbReferenceLimits.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbReferenceLimits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbReferenceLimits.Location = New System.Drawing.Point(0, 295)
        Me.gbReferenceLimits.Name = "gbReferenceLimits"
        Me.gbReferenceLimits.Size = New System.Drawing.Size(157, 114)
        Me.gbReferenceLimits.TabIndex = 16
        Me.gbReferenceLimits.TabStop = False
        Me.gbReferenceLimits.Text = "Reference Limits"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Max Length Delta: 1.00 m"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLimit3
        '
        Me.lblLimit3.AutoSize = True
        Me.lblLimit3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimit3.Location = New System.Drawing.Point(8, 69)
        Me.lblLimit3.Name = "lblLimit3"
        Me.lblLimit3.Size = New System.Drawing.Size(92, 15)
        Me.lblLimit3.TabIndex = 0
        Me.lblLimit3.Text = "Length: >= 3.00"
        Me.lblLimit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLimit2
        '
        Me.lblLimit2.AutoSize = True
        Me.lblLimit2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimit2.Location = New System.Drawing.Point(8, 46)
        Me.lblLimit2.Name = "lblLimit2"
        Me.lblLimit2.Size = New System.Drawing.Size(112, 15)
        Me.lblLimit2.TabIndex = 0
        Me.lblLimit2.Text = "Offset Max: <= 3.00"
        Me.lblLimit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLimit1
        '
        Me.lblLimit1.AutoSize = True
        Me.lblLimit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimit1.Location = New System.Drawing.Point(8, 23)
        Me.lblLimit1.Name = "lblLimit1"
        Me.lblLimit1.Size = New System.Drawing.Size(113, 15)
        Me.lblLimit1.TabIndex = 0
        Me.lblLimit1.Text = "Offset Min: >= -0.03"
        Me.lblLimit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbort.Location = New System.Drawing.Point(29, 47)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(98, 24)
        Me.btnAbort.TabIndex = 6
        Me.btnAbort.Text = "Abort"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.tsslpbCal})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 415)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1034, 26)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(517, 21)
        Me.tsslStatus.Spring = True
        '
        'tsslpbCal
        '
        Me.tsslpbCal.Name = "tsslpbCal"
        Me.tsslpbCal.Size = New System.Drawing.Size(500, 20)
        '
        'FormCalibrate
        '
        Me.AcceptButton = Me.btnStartCal
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1034, 441)
        Me.Controls.Add(Me.layoutMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalibrate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Calibrate"
        Me.layoutMain.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.fgCal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMenu.ResumeLayout(False)
        Me.gbLiveDisplay.ResumeLayout(False)
        Me.gbLiveDisplay.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbReferenceLimits.ResumeLayout(False)
        Me.gbReferenceLimits.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStartCal As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents layoutMain As TableLayoutPanel
    Friend WithEvents gbReferenceLimits As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblLimit3 As Label
    Friend WithEvents lblLimit2 As Label
    Friend WithEvents lblLimit1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents tsslpbCal As ToolStripProgressBar
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents fgCal As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents gbLiveDisplay As GroupBox
    Friend WithEvents lblPower As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblWavelength As Label
    Friend WithEvents lblORL As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblChannel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblIL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmsMenu As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectNothingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReverseSelectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllInvalidToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAbort As Button
End Class
