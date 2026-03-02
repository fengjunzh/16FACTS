<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPFDetail
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
        Me.layoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.fgMain = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNumber = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbTestPhase = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.layoutMain.SuspendLayout()
        CType(Me.fgMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'layoutMain
        '
        Me.layoutMain.ColumnCount = 1
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Controls.Add(Me.fgMain, 0, 1)
        Me.layoutMain.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(0, 0)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.RowCount = 2
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Size = New System.Drawing.Size(754, 428)
        Me.layoutMain.TabIndex = 1
        '
        'fgMain
        '
        Me.fgMain.AllowEditing = False
        Me.fgMain.AutoClipboard = True
        Me.fgMain.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.fgMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgMain.Location = New System.Drawing.Point(3, 40)
        Me.fgMain.Name = "fgMain"
        Me.fgMain.Rows.Count = 1
        Me.fgMain.Rows.DefaultSize = 19
        Me.fgMain.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgMain.Size = New System.Drawing.Size(748, 385)
        Me.fgMain.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbNumber, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSearch, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbTestPhase, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(748, 31)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SN or WO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbNumber
        '
        Me.tbNumber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNumber.Location = New System.Drawing.Point(107, 3)
        Me.tbNumber.Name = "tbNumber"
        Me.tbNumber.Size = New System.Drawing.Size(179, 24)
        Me.tbNumber.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(512, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(72, 25)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(292, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 31)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Test Phase:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbTestPhase
        '
        Me.cbTestPhase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTestPhase.FormattingEnabled = True
        Me.cbTestPhase.Location = New System.Drawing.Point(387, 3)
        Me.cbTestPhase.Name = "cbTestPhase"
        Me.cbTestPhase.Size = New System.Drawing.Size(119, 24)
        Me.cbTestPhase.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(754, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(708, 17)
        Me.tsslStatus.Spring = True
        '
        'FormPFDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 450)
        Me.Controls.Add(Me.layoutMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPFDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Show Pass Fail Detail"
        Me.layoutMain.ResumeLayout(False)
        CType(Me.fgMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents layoutMain As TableLayoutPanel
    Friend WithEvents fgMain As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents tbNumber As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cbTestPhase As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
End Class
