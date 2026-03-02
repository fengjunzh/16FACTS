<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConnectorSpecDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConnectorSpecDetail))
        Me.cbSpecNum = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fgConnSpec = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.gbOpticalSpec = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtConnectorType = New System.Windows.Forms.TextBox()
        CType(Me.fgConnSpec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOpticalSpec.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSpecNum
        '
        Me.cbSpecNum.FormattingEnabled = True
        Me.cbSpecNum.Location = New System.Drawing.Point(130, 15)
        Me.cbSpecNum.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbSpecNum.Name = "cbSpecNum"
        Me.cbSpecNum.Size = New System.Drawing.Size(248, 22)
        Me.cbSpecNum.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Spec Number:"
        '
        'fgConnSpec
        '
        Me.fgConnSpec.ColumnInfo = "1,1,0,0,0,105,Columns:"
        Me.fgConnSpec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgConnSpec.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross
        Me.fgConnSpec.Location = New System.Drawing.Point(4, 18)
        Me.fgConnSpec.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.fgConnSpec.Name = "fgConnSpec"
        Me.fgConnSpec.Rows.Count = 1
        Me.fgConnSpec.Rows.DefaultSize = 21
        Me.fgConnSpec.Size = New System.Drawing.Size(604, 279)
        Me.fgConnSpec.StyleInfo = resources.GetString("fgConnSpec.StyleInfo")
        Me.fgConnSpec.TabIndex = 6
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Location = New System.Drawing.Point(534, 427)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(93, 32)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(415, 427)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(93, 32)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Location = New System.Drawing.Point(296, 427)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(93, 32)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(177, 427)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(93, 32)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'gbOpticalSpec
        '
        Me.gbOpticalSpec.Controls.Add(Me.fgConnSpec)
        Me.gbOpticalSpec.Location = New System.Drawing.Point(18, 94)
        Me.gbOpticalSpec.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.gbOpticalSpec.Name = "gbOpticalSpec"
        Me.gbOpticalSpec.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.gbOpticalSpec.Size = New System.Drawing.Size(612, 300)
        Me.gbOpticalSpec.TabIndex = 3
        Me.gbOpticalSpec.TabStop = False
        Me.gbOpticalSpec.Text = "Optical Specifications"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Connector Type:"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(385, 14)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 25)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtConnectorType
        '
        Me.txtConnectorType.Enabled = False
        Me.txtConnectorType.Location = New System.Drawing.Point(130, 45)
        Me.txtConnectorType.Name = "txtConnectorType"
        Me.txtConnectorType.Size = New System.Drawing.Size(248, 22)
        Me.txtConnectorType.TabIndex = 9
        '
        'FormConnectorSpecDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 471)
        Me.Controls.Add(Me.txtConnectorType)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.gbOpticalSpec)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbSpecNum)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConnectorSpecDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "*Connector Specification Maitenance"
        CType(Me.fgConnSpec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOpticalSpec.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSpecNum As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents fgConnSpec As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnExit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents gbOpticalSpec As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents txtConnectorType As TextBox
End Class
