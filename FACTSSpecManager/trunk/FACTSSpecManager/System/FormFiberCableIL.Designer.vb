<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFiberCableIL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFiberCableIL))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbLimitName = New System.Windows.Forms.ComboBox()
        Me.gbLimitTable = New System.Windows.Forms.GroupBox()
        Me.fgILLimit = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbLimitTable.SuspendLayout()
        CType(Me.fgILLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Limit Name:"
        '
        'cbLimitName
        '
        Me.cbLimitName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLimitName.FormattingEnabled = True
        Me.cbLimitName.Location = New System.Drawing.Point(101, 11)
        Me.cbLimitName.Name = "cbLimitName"
        Me.cbLimitName.Size = New System.Drawing.Size(121, 22)
        Me.cbLimitName.TabIndex = 1
        '
        'gbLimitTable
        '
        Me.gbLimitTable.Controls.Add(Me.fgILLimit)
        Me.gbLimitTable.Location = New System.Drawing.Point(12, 54)
        Me.gbLimitTable.Name = "gbLimitTable"
        Me.gbLimitTable.Size = New System.Drawing.Size(435, 305)
        Me.gbLimitTable.TabIndex = 2
        Me.gbLimitTable.TabStop = False
        Me.gbLimitTable.Text = "Limit Input"
        '
        'fgILLimit
        '
        Me.fgILLimit.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.fgILLimit.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.fgILLimit.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgILLimit.ColumnInfo = "1,1,0,0,0,105,Columns:"
        Me.fgILLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgILLimit.Location = New System.Drawing.Point(3, 18)
        Me.fgILLimit.Name = "fgILLimit"
        Me.fgILLimit.Rows.Count = 1
        Me.fgILLimit.Rows.DefaultSize = 21
        Me.fgILLimit.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.fgILLimit.Size = New System.Drawing.Size(429, 284)
        Me.fgILLimit.StyleInfo = resources.GetString("fgILLimit.StyleInfo")
        Me.fgILLimit.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(367, 391)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 30)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(265, 391)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 30)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(163, 391)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(80, 30)
        Me.btnUpdate.TabIndex = 4
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(61, 391)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 30)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'FormFiberCableIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 433)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.gbLimitTable)
        Me.Controls.Add(Me.cbLimitName)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFiberCableIL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "*Fiber Cable IL Limit Maintenance"
        Me.gbLimitTable.ResumeLayout(False)
        CType(Me.fgILLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbLimitName As ComboBox
    Friend WithEvents gbLimitTable As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents fgILLimit As C1.Win.C1FlexGrid.C1FlexGrid
End Class
