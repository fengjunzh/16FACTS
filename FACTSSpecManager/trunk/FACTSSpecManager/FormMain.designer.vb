<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPrivilegeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSystem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConnectorTypeMaintain = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuConnectorSpec = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiberCableILLimitMaintain = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSwitchDatabase = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSpecToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSRLILToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BulkCopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossSystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.UserNameToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslStaus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.UserToolStripMenuItem, Me.menuSystem, Me.ProductToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1052, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(47, 20)
        Me.ToolStripMenuItem1.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UManagerToolStripMenuItem, Me.UPrivilegeToolStripMenuItem})
        Me.UserToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.UserToolStripMenuItem.Text = "&User"
        '
        'UManagerToolStripMenuItem
        '
        Me.UManagerToolStripMenuItem.Name = "UManagerToolStripMenuItem"
        Me.UManagerToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.UManagerToolStripMenuItem.Text = "Manager"
        '
        'UPrivilegeToolStripMenuItem
        '
        Me.UPrivilegeToolStripMenuItem.Name = "UPrivilegeToolStripMenuItem"
        Me.UPrivilegeToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.UPrivilegeToolStripMenuItem.Text = "Privilege"
        '
        'menuSystem
        '
        Me.menuSystem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConnectorTypeMaintain, Me.menuConnectorSpec, Me.mnuFiberCableILLimitMaintain, Me.mnuSwitchDatabase})
        Me.menuSystem.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.menuSystem.Name = "menuSystem"
        Me.menuSystem.Size = New System.Drawing.Size(61, 20)
        Me.menuSystem.Text = "System"
        '
        'mnuConnectorTypeMaintain
        '
        Me.mnuConnectorTypeMaintain.Name = "mnuConnectorTypeMaintain"
        Me.mnuConnectorTypeMaintain.Size = New System.Drawing.Size(305, 22)
        Me.mnuConnectorTypeMaintain.Text = "*Connector Type Maintenance"
        '
        'menuConnectorSpec
        '
        Me.menuConnectorSpec.Name = "menuConnectorSpec"
        Me.menuConnectorSpec.Size = New System.Drawing.Size(305, 22)
        Me.menuConnectorSpec.Text = "*Connector Spec Maintenance"
        '
        'mnuFiberCableILLimitMaintain
        '
        Me.mnuFiberCableILLimitMaintain.Name = "mnuFiberCableILLimitMaintain"
        Me.mnuFiberCableILLimitMaintain.Size = New System.Drawing.Size(305, 22)
        Me.mnuFiberCableILLimitMaintain.Text = "*Fiber Cable IL Limit Maintenance"
        '
        'mnuSwitchDatabase
        '
        Me.mnuSwitchDatabase.Name = "mnuSwitchDatabase"
        Me.mnuSwitchDatabase.Size = New System.Drawing.Size(305, 22)
        Me.mnuSwitchDatabase.Text = "*Switch Database"
        '
        'ProductToolStripMenuItem
        '
        Me.ProductToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MProfileToolStripMenuItem, Me.MModeToolStripMenuItem, Me.MSpecToolStripMenuItem, Me.BulkCopyToolStripMenuItem})
        Me.ProductToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.ProductToolStripMenuItem.Name = "ProductToolStripMenuItem"
        Me.ProductToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.ProductToolStripMenuItem.Text = "&Product"
        '
        'MProfileToolStripMenuItem
        '
        Me.MProfileToolStripMenuItem.Name = "MProfileToolStripMenuItem"
        Me.MProfileToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MProfileToolStripMenuItem.Text = "*Profile"
        '
        'MModeToolStripMenuItem
        '
        Me.MModeToolStripMenuItem.Name = "MModeToolStripMenuItem"
        Me.MModeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MModeToolStripMenuItem.Text = "*Mode"
        '
        'MSpecToolStripMenuItem
        '
        Me.MSpecToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MSRLILToolStripMenuItem})
        Me.MSpecToolStripMenuItem.Name = "MSpecToolStripMenuItem"
        Me.MSpecToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MSpecToolStripMenuItem.Text = "*Specification"
        '
        'MSRLILToolStripMenuItem
        '
        Me.MSRLILToolStripMenuItem.Name = "MSRLILToolStripMenuItem"
        Me.MSRLILToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.MSRLILToolStripMenuItem.Text = "*RL_IL"
        '
        'BulkCopyToolStripMenuItem
        '
        Me.BulkCopyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrossModeToolStripMenuItem, Me.CrossProductToolStripMenuItem, Me.CrossSystemToolStripMenuItem})
        Me.BulkCopyToolStripMenuItem.Name = "BulkCopyToolStripMenuItem"
        Me.BulkCopyToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BulkCopyToolStripMenuItem.Text = "*Bulk Copy"
        '
        'CrossModeToolStripMenuItem
        '
        Me.CrossModeToolStripMenuItem.Name = "CrossModeToolStripMenuItem"
        Me.CrossModeToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CrossModeToolStripMenuItem.Text = "*Cross Mode"
        '
        'CrossProductToolStripMenuItem
        '
        Me.CrossProductToolStripMenuItem.Name = "CrossProductToolStripMenuItem"
        Me.CrossProductToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CrossProductToolStripMenuItem.Text = "*Cross Product"
        '
        'CrossSystemToolStripMenuItem
        '
        Me.CrossSystemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BatchToolStripMenuItem, Me.CustomToolStripMenuItem})
        Me.CrossSystemToolStripMenuItem.Name = "CrossSystemToolStripMenuItem"
        Me.CrossSystemToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CrossSystemToolStripMenuItem.Text = "*Cross System"
        Me.CrossSystemToolStripMenuItem.Visible = False
        '
        'BatchToolStripMenuItem
        '
        Me.BatchToolStripMenuItem.Name = "BatchToolStripMenuItem"
        Me.BatchToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.BatchToolStripMenuItem.Text = "*Batch"
        '
        'CustomToolStripMenuItem
        '
        Me.CustomToolStripMenuItem.Name = "CustomToolStripMenuItem"
        Me.CustomToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.CustomToolStripMenuItem.Text = "*Custom"
        '
        'statusStrip
        '
        Me.statusStrip.BackColor = System.Drawing.Color.White
        Me.statusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserNameToolStripStatusLabel, Me.tsslStaus})
        Me.statusStrip.Location = New System.Drawing.Point(0, 525)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(1052, 25)
        Me.statusStrip.TabIndex = 3
        Me.statusStrip.Text = "StatusStrip1"
        '
        'UserNameToolStripStatusLabel
        '
        Me.UserNameToolStripStatusLabel.AutoSize = False
        Me.UserNameToolStripStatusLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserNameToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserNameToolStripStatusLabel.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserNameToolStripStatusLabel.Name = "UserNameToolStripStatusLabel"
        Me.UserNameToolStripStatusLabel.Size = New System.Drawing.Size(300, 20)
        Me.UserNameToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsslStaus
        '
        Me.tsslStaus.Name = "tsslStaus"
        Me.tsslStaus.Size = New System.Drawing.Size(737, 20)
        Me.tsslStaus.Spring = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(669, 27)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 550)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "FACTS Spec Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents UPrivilegeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
	Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
	Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
	Friend WithEvents MProfileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents MModeToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents MSpecToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents MSRLILToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSystem As ToolStripMenuItem
    Friend WithEvents UserNameToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents UManagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BulkCopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrossModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CrossSystemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BatchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsslStaus As ToolStripStatusLabel
    Friend WithEvents CrossProductToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSwitchDatabase As ToolStripMenuItem
    Friend WithEvents mnuConnectorTypeMaintain As ToolStripMenuItem
    Friend WithEvents mnuFiberCableILLimitMaintain As ToolStripMenuItem
    Friend WithEvents menuConnectorSpec As ToolStripMenuItem
End Class
