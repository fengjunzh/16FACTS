<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPRSPRLILItem
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveUp = New System.Windows.Forms.ToolStripButton()
        Me.btnMoveDown = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.fgTestItems = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.fgTestItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnClose, Me.btnMoveUp, Me.btnMoveDown, Me.btnDelete, Me.btnSave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 35)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnClose
        '
        Me.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnClose.Image = Global.FACTSSpecManager.My.Resources.Resources.exit_32px
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(68, 32)
        Me.btnClose.Text = "Close"
        Me.btnClose.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Enabled = False
        Me.btnMoveUp.Image = Global.FACTSSpecManager.My.Resources.Resources.arrow_Up_16xLG
        Me.btnMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(87, 32)
        Me.btnMoveUp.Text = "Move Up"
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Enabled = False
        Me.btnMoveDown.Image = Global.FACTSSpecManager.My.Resources.Resources.arrow_Down_16xLG
        Me.btnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(103, 32)
        Me.btnMoveDown.Text = "Move Down"
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.FACTSSpecManager.My.Resources.Resources.VSO_RecycleBin_16x
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 32)
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Image = Global.FACTSSpecManager.My.Resources.Resources.Save_16x
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 32)
        Me.btnSave.Text = "Save to Db"
        '
        'fgTestItems
        '
        Me.fgTestItems.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.fgTestItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgTestItems.ExtendLastCol = True
        Me.fgTestItems.Location = New System.Drawing.Point(0, 35)
        Me.fgTestItems.Name = "fgTestItems"
        Me.fgTestItems.Rows.Count = 1
        Me.fgTestItems.Rows.DefaultSize = 19
        Me.fgTestItems.Size = New System.Drawing.Size(1184, 726)
        Me.fgTestItems.TabIndex = 8
        '
        'FormPRSPRLILItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.fgTestItems)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPRSPRLILItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "*RL_IL >> Test Items"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.fgTestItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnClose As ToolStripButton
    Friend WithEvents btnMoveUp As ToolStripButton
    Friend WithEvents btnMoveDown As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents fgTestItems As C1.Win.C1FlexGrid.C1FlexGrid
End Class
