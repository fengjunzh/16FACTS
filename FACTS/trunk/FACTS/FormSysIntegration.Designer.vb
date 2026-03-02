<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSysIntegration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSysIntegration))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblSwitchPathIL = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSwitchPathLength = New System.Windows.Forms.Label()
        Me.lblSPLState = New System.Windows.Forms.Label()
        Me.lblFrontPanelPowerRatio = New System.Windows.Forms.Label()
        Me.lblFPPState = New System.Windows.Forms.Label()
        Me.lblFrontPanelDistance = New System.Windows.Forms.Label()
        Me.lblFPDState = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbFPD = New System.Windows.Forms.GroupBox()
        Me.btnFPDSaveNewValues = New System.Windows.Forms.Button()
        Me.lblFPDSaveNewValue = New System.Windows.Forms.Label()
        Me.btnFPDStartAdjustment = New System.Windows.Forms.Button()
        Me.lblFPDStatus = New System.Windows.Forms.Label()
        Me.fgFPD = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.gbFPP = New System.Windows.Forms.GroupBox()
        Me.btnFPPSaveNewValue = New System.Windows.Forms.Button()
        Me.lblFPPSaveNewValue = New System.Windows.Forms.Label()
        Me.btnFPPStartAdjustment = New System.Windows.Forms.Button()
        Me.lblFPPStatus = New System.Windows.Forms.Label()
        Me.fgFPP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.gbSPL = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudChannelNum = New System.Windows.Forms.NumericUpDown()
        Me.btnSPLSaveNewValue = New System.Windows.Forms.Button()
        Me.lblSPLSaveNewValue = New System.Windows.Forms.Label()
        Me.btnSPLStartAdjustment = New System.Windows.Forms.Button()
        Me.lblSPLStatus = New System.Windows.Forms.Label()
        Me.fgSPL = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslTimeElapsed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbFPD.SuspendLayout()
        CType(Me.fgFPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.gbFPP.SuspendLayout()
        CType(Me.fgFPP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.gbSPL.SuspendLayout()
        CType(Me.nudChannelNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgSPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(695, 426)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblSwitchPathIL)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.lblSwitchPathLength)
        Me.TabPage1.Controls.Add(Me.lblSPLState)
        Me.TabPage1.Controls.Add(Me.lblFrontPanelPowerRatio)
        Me.TabPage1.Controls.Add(Me.lblFPPState)
        Me.TabPage1.Controls.Add(Me.lblFrontPanelDistance)
        Me.TabPage1.Controls.Add(Me.lblFPDState)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(687, 397)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Status"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblSwitchPathIL
        '
        Me.lblSwitchPathIL.AutoSize = True
        Me.lblSwitchPathIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSwitchPathIL.Location = New System.Drawing.Point(157, 228)
        Me.lblSwitchPathIL.Name = "lblSwitchPathIL"
        Me.lblSwitchPathIL.Size = New System.Drawing.Size(225, 24)
        Me.lblSwitchPathIL.TabIndex = 1
        Me.lblSwitchPathIL.Text = "Switch Path IL Adjustment"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(126, 227)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 25)
        Me.Label6.TabIndex = 0
        '
        'lblSwitchPathLength
        '
        Me.lblSwitchPathLength.AutoSize = True
        Me.lblSwitchPathLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSwitchPathLength.Location = New System.Drawing.Point(157, 185)
        Me.lblSwitchPathLength.Name = "lblSwitchPathLength"
        Me.lblSwitchPathLength.Size = New System.Drawing.Size(269, 24)
        Me.lblSwitchPathLength.TabIndex = 1
        Me.lblSwitchPathLength.Text = "Switch Path Length Adjustment"
        '
        'lblSPLState
        '
        Me.lblSPLState.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSPLState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSPLState.Location = New System.Drawing.Point(126, 184)
        Me.lblSPLState.Name = "lblSPLState"
        Me.lblSPLState.Size = New System.Drawing.Size(25, 25)
        Me.lblSPLState.TabIndex = 0
        '
        'lblFrontPanelPowerRatio
        '
        Me.lblFrontPanelPowerRatio.AutoSize = True
        Me.lblFrontPanelPowerRatio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrontPanelPowerRatio.Location = New System.Drawing.Point(157, 142)
        Me.lblFrontPanelPowerRatio.Name = "lblFrontPanelPowerRatio"
        Me.lblFrontPanelPowerRatio.Size = New System.Drawing.Size(312, 24)
        Me.lblFrontPanelPowerRatio.TabIndex = 1
        Me.lblFrontPanelPowerRatio.Text = "Front Panel Power Ratio Adjustment"
        '
        'lblFPPState
        '
        Me.lblFPPState.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFPPState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFPPState.Location = New System.Drawing.Point(126, 141)
        Me.lblFPPState.Name = "lblFPPState"
        Me.lblFPPState.Size = New System.Drawing.Size(25, 25)
        Me.lblFPPState.TabIndex = 0
        '
        'lblFrontPanelDistance
        '
        Me.lblFrontPanelDistance.AutoSize = True
        Me.lblFrontPanelDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrontPanelDistance.Location = New System.Drawing.Point(157, 99)
        Me.lblFrontPanelDistance.Name = "lblFrontPanelDistance"
        Me.lblFrontPanelDistance.Size = New System.Drawing.Size(283, 24)
        Me.lblFrontPanelDistance.TabIndex = 1
        Me.lblFrontPanelDistance.Text = "Front Panel Distance Adjustment"
        '
        'lblFPDState
        '
        Me.lblFPDState.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFPDState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFPDState.Location = New System.Drawing.Point(126, 98)
        Me.lblFPDState.Name = "lblFPDState"
        Me.lblFPDState.Size = New System.Drawing.Size(25, 25)
        Me.lblFPDState.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gbFPD)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(687, 397)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Front Panel Distance Adjustment"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gbFPD
        '
        Me.gbFPD.Controls.Add(Me.btnFPDSaveNewValues)
        Me.gbFPD.Controls.Add(Me.lblFPDSaveNewValue)
        Me.gbFPD.Controls.Add(Me.btnFPDStartAdjustment)
        Me.gbFPD.Controls.Add(Me.lblFPDStatus)
        Me.gbFPD.Controls.Add(Me.fgFPD)
        Me.gbFPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFPD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFPD.Location = New System.Drawing.Point(3, 3)
        Me.gbFPD.Name = "gbFPD"
        Me.gbFPD.Size = New System.Drawing.Size(681, 391)
        Me.gbFPD.TabIndex = 0
        Me.gbFPD.TabStop = False
        Me.gbFPD.Text = "Front Panel Distance"
        '
        'btnFPDSaveNewValues
        '
        Me.btnFPDSaveNewValues.Enabled = False
        Me.btnFPDSaveNewValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFPDSaveNewValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFPDSaveNewValues.Location = New System.Drawing.Point(491, 65)
        Me.btnFPDSaveNewValues.Name = "btnFPDSaveNewValues"
        Me.btnFPDSaveNewValues.Size = New System.Drawing.Size(174, 30)
        Me.btnFPDSaveNewValues.TabIndex = 4
        Me.btnFPDSaveNewValues.Text = "Save New Values"
        Me.btnFPDSaveNewValues.UseVisualStyleBackColor = True
        '
        'lblFPDSaveNewValue
        '
        Me.lblFPDSaveNewValue.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFPDSaveNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFPDSaveNewValue.Location = New System.Drawing.Point(475, 65)
        Me.lblFPDSaveNewValue.Name = "lblFPDSaveNewValue"
        Me.lblFPDSaveNewValue.Size = New System.Drawing.Size(10, 30)
        Me.lblFPDSaveNewValue.TabIndex = 2
        '
        'btnFPDStartAdjustment
        '
        Me.btnFPDStartAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFPDStartAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFPDStartAdjustment.Location = New System.Drawing.Point(491, 17)
        Me.btnFPDStartAdjustment.Name = "btnFPDStartAdjustment"
        Me.btnFPDStartAdjustment.Size = New System.Drawing.Size(174, 30)
        Me.btnFPDStartAdjustment.TabIndex = 3
        Me.btnFPDStartAdjustment.Text = "&Start Adjustment"
        Me.btnFPDStartAdjustment.UseVisualStyleBackColor = True
        '
        'lblFPDStatus
        '
        Me.lblFPDStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFPDStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFPDStatus.Location = New System.Drawing.Point(475, 17)
        Me.lblFPDStatus.Name = "lblFPDStatus"
        Me.lblFPDStatus.Size = New System.Drawing.Size(10, 30)
        Me.lblFPDStatus.TabIndex = 2
        '
        'fgFPD
        '
        Me.fgFPD.AllowEditing = False
        Me.fgFPD.ColumnInfo = "1,1,0,0,0,100,Columns:"
        Me.fgFPD.Dock = System.Windows.Forms.DockStyle.Left
        Me.fgFPD.Enabled = False
        Me.fgFPD.Location = New System.Drawing.Point(3, 17)
        Me.fgFPD.Name = "fgFPD"
        Me.fgFPD.Rows.Count = 1
        Me.fgFPD.Rows.DefaultSize = 20
        Me.fgFPD.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgFPD.Size = New System.Drawing.Size(452, 371)
        Me.fgFPD.StyleInfo = resources.GetString("fgFPD.StyleInfo")
        Me.fgFPD.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.gbFPP)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(687, 397)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Front Panel Power Ration Adjustment"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'gbFPP
        '
        Me.gbFPP.Controls.Add(Me.btnFPPSaveNewValue)
        Me.gbFPP.Controls.Add(Me.lblFPPSaveNewValue)
        Me.gbFPP.Controls.Add(Me.btnFPPStartAdjustment)
        Me.gbFPP.Controls.Add(Me.lblFPPStatus)
        Me.gbFPP.Controls.Add(Me.fgFPP)
        Me.gbFPP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbFPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFPP.Location = New System.Drawing.Point(3, 3)
        Me.gbFPP.Name = "gbFPP"
        Me.gbFPP.Size = New System.Drawing.Size(681, 391)
        Me.gbFPP.TabIndex = 1
        Me.gbFPP.TabStop = False
        Me.gbFPP.Text = "Front Panel Power Ratio"
        '
        'btnFPPSaveNewValue
        '
        Me.btnFPPSaveNewValue.Enabled = False
        Me.btnFPPSaveNewValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFPPSaveNewValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFPPSaveNewValue.Location = New System.Drawing.Point(491, 65)
        Me.btnFPPSaveNewValue.Name = "btnFPPSaveNewValue"
        Me.btnFPPSaveNewValue.Size = New System.Drawing.Size(174, 30)
        Me.btnFPPSaveNewValue.TabIndex = 2
        Me.btnFPPSaveNewValue.Text = "Save New Values"
        Me.btnFPPSaveNewValue.UseVisualStyleBackColor = True
        '
        'lblFPPSaveNewValue
        '
        Me.lblFPPSaveNewValue.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFPPSaveNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFPPSaveNewValue.Location = New System.Drawing.Point(475, 65)
        Me.lblFPPSaveNewValue.Name = "lblFPPSaveNewValue"
        Me.lblFPPSaveNewValue.Size = New System.Drawing.Size(10, 30)
        Me.lblFPPSaveNewValue.TabIndex = 2
        '
        'btnFPPStartAdjustment
        '
        Me.btnFPPStartAdjustment.Enabled = False
        Me.btnFPPStartAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFPPStartAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFPPStartAdjustment.Location = New System.Drawing.Point(491, 17)
        Me.btnFPPStartAdjustment.Name = "btnFPPStartAdjustment"
        Me.btnFPPStartAdjustment.Size = New System.Drawing.Size(174, 30)
        Me.btnFPPStartAdjustment.TabIndex = 1
        Me.btnFPPStartAdjustment.Text = "&Start Adjustment"
        Me.btnFPPStartAdjustment.UseVisualStyleBackColor = True
        '
        'lblFPPStatus
        '
        Me.lblFPPStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblFPPStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFPPStatus.Location = New System.Drawing.Point(475, 17)
        Me.lblFPPStatus.Name = "lblFPPStatus"
        Me.lblFPPStatus.Size = New System.Drawing.Size(10, 30)
        Me.lblFPPStatus.TabIndex = 2
        '
        'fgFPP
        '
        Me.fgFPP.AllowEditing = False
        Me.fgFPP.ColumnInfo = "1,1,0,0,0,100,Columns:"
        Me.fgFPP.Dock = System.Windows.Forms.DockStyle.Left
        Me.fgFPP.Enabled = False
        Me.fgFPP.Location = New System.Drawing.Point(3, 17)
        Me.fgFPP.Name = "fgFPP"
        Me.fgFPP.Rows.Count = 1
        Me.fgFPP.Rows.DefaultSize = 20
        Me.fgFPP.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgFPP.Size = New System.Drawing.Size(452, 371)
        Me.fgFPP.StyleInfo = resources.GetString("fgFPP.StyleInfo")
        Me.fgFPP.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.gbSPL)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(687, 397)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Switch Path Length Adjustment"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'gbSPL
        '
        Me.gbSPL.Controls.Add(Me.Label1)
        Me.gbSPL.Controls.Add(Me.nudChannelNum)
        Me.gbSPL.Controls.Add(Me.btnSPLSaveNewValue)
        Me.gbSPL.Controls.Add(Me.lblSPLSaveNewValue)
        Me.gbSPL.Controls.Add(Me.btnSPLStartAdjustment)
        Me.gbSPL.Controls.Add(Me.lblSPLStatus)
        Me.gbSPL.Controls.Add(Me.fgSPL)
        Me.gbSPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbSPL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSPL.Location = New System.Drawing.Point(3, 3)
        Me.gbSPL.Name = "gbSPL"
        Me.gbSPL.Size = New System.Drawing.Size(681, 391)
        Me.gbSPL.TabIndex = 2
        Me.gbSPL.TabStop = False
        Me.gbSPL.Text = "Switch Path Length"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(491, 330)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Channel Number:"
        '
        'nudChannelNum
        '
        Me.nudChannelNum.Location = New System.Drawing.Point(491, 349)
        Me.nudChannelNum.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudChannelNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudChannelNum.Name = "nudChannelNum"
        Me.nudChannelNum.Size = New System.Drawing.Size(174, 21)
        Me.nudChannelNum.TabIndex = 4
        Me.nudChannelNum.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnSPLSaveNewValue
        '
        Me.btnSPLSaveNewValue.Enabled = False
        Me.btnSPLSaveNewValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSPLSaveNewValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSPLSaveNewValue.Location = New System.Drawing.Point(491, 65)
        Me.btnSPLSaveNewValue.Name = "btnSPLSaveNewValue"
        Me.btnSPLSaveNewValue.Size = New System.Drawing.Size(174, 30)
        Me.btnSPLSaveNewValue.TabIndex = 3
        Me.btnSPLSaveNewValue.Text = "Save New Values"
        Me.btnSPLSaveNewValue.UseVisualStyleBackColor = True
        '
        'lblSPLSaveNewValue
        '
        Me.lblSPLSaveNewValue.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSPLSaveNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSPLSaveNewValue.Location = New System.Drawing.Point(475, 65)
        Me.lblSPLSaveNewValue.Name = "lblSPLSaveNewValue"
        Me.lblSPLSaveNewValue.Size = New System.Drawing.Size(10, 30)
        Me.lblSPLSaveNewValue.TabIndex = 2
        '
        'btnSPLStartAdjustment
        '
        Me.btnSPLStartAdjustment.Enabled = False
        Me.btnSPLStartAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSPLStartAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSPLStartAdjustment.Location = New System.Drawing.Point(491, 17)
        Me.btnSPLStartAdjustment.Name = "btnSPLStartAdjustment"
        Me.btnSPLStartAdjustment.Size = New System.Drawing.Size(174, 30)
        Me.btnSPLStartAdjustment.TabIndex = 3
        Me.btnSPLStartAdjustment.Text = "&Start Adjustment"
        Me.btnSPLStartAdjustment.UseVisualStyleBackColor = True
        '
        'lblSPLStatus
        '
        Me.lblSPLStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSPLStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSPLStatus.Location = New System.Drawing.Point(475, 17)
        Me.lblSPLStatus.Name = "lblSPLStatus"
        Me.lblSPLStatus.Size = New System.Drawing.Size(10, 30)
        Me.lblSPLStatus.TabIndex = 2
        '
        'fgSPL
        '
        Me.fgSPL.AllowEditing = False
        Me.fgSPL.ColumnInfo = "1,1,0,0,0,100,Columns:"
        Me.fgSPL.Dock = System.Windows.Forms.DockStyle.Left
        Me.fgSPL.Location = New System.Drawing.Point(3, 17)
        Me.fgSPL.Name = "fgSPL"
        Me.fgSPL.Rows.Count = 1
        Me.fgSPL.Rows.DefaultSize = 20
        Me.fgSPL.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgSPL.Size = New System.Drawing.Size(452, 371)
        Me.fgSPL.StyleInfo = resources.GetString("fgSPL.StyleInfo")
        Me.fgSPL.TabIndex = 0
        '
        'btnDone
        '
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(713, 25)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(75, 46)
        Me.btnDone.TabIndex = 1
        Me.btnDone.Text = "&Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.pgBar, Me.tsslTimeElapsed})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 426)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(334, 19)
        Me.tsslStatus.Spring = True
        '
        'pgBar
        '
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(400, 18)
        '
        'tsslTimeElapsed
        '
        Me.tsslTimeElapsed.Name = "tsslTimeElapsed"
        Me.tsslTimeElapsed.Size = New System.Drawing.Size(49, 19)
        Me.tsslTimeElapsed.Text = "00:00:00"
        '
        'FormSysIntegration
        '
        Me.AcceptButton = Me.btnDone
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSysIntegration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MAP200 System Integration"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.gbFPD.ResumeLayout(False)
        CType(Me.fgFPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.gbFPP.ResumeLayout(False)
        CType(Me.fgFPP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.gbSPL.ResumeLayout(False)
        Me.gbSPL.PerformLayout()
        CType(Me.nudChannelNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgSPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lblSwitchPathIL As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblSwitchPathLength As Label
    Friend WithEvents lblSPLState As Label
    Friend WithEvents lblFrontPanelPowerRatio As Label
    Friend WithEvents lblFPPState As Label
    Friend WithEvents lblFrontPanelDistance As Label
    Friend WithEvents lblFPDState As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents gbFPD As GroupBox
    Friend WithEvents fgFPD As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents btnDone As Button
    Friend WithEvents btnFPDSaveNewValues As Button
    Friend WithEvents lblFPDSaveNewValue As Label
    Friend WithEvents btnFPDStartAdjustment As Button
    Friend WithEvents lblFPDStatus As Label
    Friend WithEvents gbFPP As GroupBox
    Friend WithEvents btnFPPSaveNewValue As Button
    Friend WithEvents lblFPPSaveNewValue As Label
    Friend WithEvents btnFPPStartAdjustment As Button
    Friend WithEvents lblFPPStatus As Label
    Friend WithEvents fgFPP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents gbSPL As GroupBox
    Friend WithEvents btnSPLSaveNewValue As Button
    Friend WithEvents lblSPLSaveNewValue As Label
    Friend WithEvents btnSPLStartAdjustment As Button
    Friend WithEvents lblSPLStatus As Label
    Friend WithEvents fgSPL As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents pgBar As ToolStripProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents nudChannelNum As NumericUpDown
    Friend WithEvents tsslTimeElapsed As ToolStripStatusLabel
End Class
