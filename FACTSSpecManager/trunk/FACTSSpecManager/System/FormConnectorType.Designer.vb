<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConnectorType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConnectorType))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbConnectorType = New System.Windows.Forms.ComboBox()
        Me.fgConnType = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.gbConnList = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbInput = New System.Windows.Forms.GroupBox()
        Me.cbConnectorFamily = New System.Windows.Forms.ComboBox()
        Me.ckValidity = New System.Windows.Forms.CheckBox()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFactor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConnectorType = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        CType(Me.fgConnType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConnList.SuspendLayout()
        Me.gbInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connector Type:"
        '
        'cbConnectorType
        '
        Me.cbConnectorType.FormattingEnabled = True
        Me.cbConnectorType.Location = New System.Drawing.Point(134, 12)
        Me.cbConnectorType.Name = "cbConnectorType"
        Me.cbConnectorType.Size = New System.Drawing.Size(221, 22)
        Me.cbConnectorType.TabIndex = 1
        '
        'fgConnType
        '
        Me.fgConnType.AllowEditing = False
        Me.fgConnType.ColumnInfo = "1,1,0,0,0,105,Columns:"
        Me.fgConnType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgConnType.Location = New System.Drawing.Point(3, 18)
        Me.fgConnType.Name = "fgConnType"
        Me.fgConnType.Rows.Count = 1
        Me.fgConnType.Rows.DefaultSize = 21
        Me.fgConnType.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgConnType.Size = New System.Drawing.Size(915, 349)
        Me.fgConnType.StyleInfo = resources.GetString("fgConnType.StyleInfo")
        Me.fgConnType.TabIndex = 2
        '
        'gbConnList
        '
        Me.gbConnList.Controls.Add(Me.fgConnType)
        Me.gbConnList.Location = New System.Drawing.Point(12, 49)
        Me.gbConnList.Name = "gbConnList"
        Me.gbConnList.Size = New System.Drawing.Size(921, 370)
        Me.gbConnList.TabIndex = 3
        Me.gbConnList.TabStop = False
        Me.gbConnList.Text = "Connector Type List"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(543, 564)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(80, 30)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(645, 564)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(80, 30)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(747, 564)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 30)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(849, 564)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 30)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Connector Type:"
        '
        'gbInput
        '
        Me.gbInput.Controls.Add(Me.cbConnectorFamily)
        Me.gbInput.Controls.Add(Me.ckValidity)
        Me.gbInput.Controls.Add(Me.txtDescr)
        Me.gbInput.Controls.Add(Me.Label5)
        Me.gbInput.Controls.Add(Me.Label3)
        Me.gbInput.Controls.Add(Me.txtFactor)
        Me.gbInput.Controls.Add(Me.Label4)
        Me.gbInput.Controls.Add(Me.txtConnectorType)
        Me.gbInput.Controls.Add(Me.Label2)
        Me.gbInput.Location = New System.Drawing.Point(15, 434)
        Me.gbInput.Name = "gbInput"
        Me.gbInput.Size = New System.Drawing.Size(915, 105)
        Me.gbInput.TabIndex = 3
        Me.gbInput.TabStop = False
        Me.gbInput.Text = "Input"
        '
        'cbConnectorFamily
        '
        Me.cbConnectorFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConnectorFamily.FormattingEnabled = True
        Me.cbConnectorFamily.Location = New System.Drawing.Point(556, 22)
        Me.cbConnectorFamily.Name = "cbConnectorFamily"
        Me.cbConnectorFamily.Size = New System.Drawing.Size(148, 22)
        Me.cbConnectorFamily.TabIndex = 3
        '
        'ckValidity
        '
        Me.ckValidity.AutoSize = True
        Me.ckValidity.Location = New System.Drawing.Point(398, 24)
        Me.ckValidity.Name = "ckValidity"
        Me.ckValidity.Size = New System.Drawing.Size(82, 18)
        Me.ckValidity.TabIndex = 2
        Me.ckValidity.Text = "Validity"
        Me.ckValidity.UseVisualStyleBackColor = True
        '
        'txtDescr
        '
        Me.txtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescr.Location = New System.Drawing.Point(119, 59)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(790, 22)
        Me.txtDescr.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Description:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(497, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Family:"
        '
        'txtFactor
        '
        Me.txtFactor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactor.Location = New System.Drawing.Point(779, 22)
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.Size = New System.Drawing.Size(130, 22)
        Me.txtFactor.TabIndex = 4
        Me.txtFactor.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(720, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Factor:"
        '
        'txtConnectorType
        '
        Me.txtConnectorType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConnectorType.Location = New System.Drawing.Point(119, 22)
        Me.txtConnectorType.Name = "txtConnectorType"
        Me.txtConnectorType.Size = New System.Drawing.Size(277, 22)
        Me.txtConnectorType.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(361, 11)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 25)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'FormConnectorType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 607)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.gbInput)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.gbConnList)
        Me.Controls.Add(Me.cbConnectorType)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConnectorType"
        Me.Text = "*Connector Type Maintenance"
        CType(Me.fgConnType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConnList.ResumeLayout(False)
        Me.gbInput.ResumeLayout(False)
        Me.gbInput.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbConnectorType As ComboBox
    Friend WithEvents fgConnType As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents gbConnList As GroupBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents gbInput As GroupBox
    Friend WithEvents cbConnectorFamily As ComboBox
    Friend WithEvents ckValidity As CheckBox
    Friend WithEvents txtDescr As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFactor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtConnectorType As TextBox
    Friend WithEvents btnRefresh As Button
End Class
