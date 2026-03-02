<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPRSPRLIL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPRSPRLIL))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.cbMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbProduct = New System.Windows.Forms.ComboBox()
        Me.layoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.gbPhase = New System.Windows.Forms.GroupBox()
        Me.fgPhase = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDeletePhase = New System.Windows.Forms.Button()
        Me.pbLoadTest = New System.Windows.Forms.ProgressBar()
        Me.btnInvalid = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRelease = New System.Windows.Forms.Button()
        Me.btnViewItem = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ckFilterDelete = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ckFilterInvalid = New System.Windows.Forms.CheckBox()
        Me.ckFilterRelease = New System.Windows.Forms.CheckBox()
        Me.gbTestBand = New System.Windows.Forms.GroupBox()
        Me.fgTestBand = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtLengthLimit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLoadBands = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ckILOnly = New System.Windows.Forms.CheckBox()
        Me.btnLoaditems = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.layoutMain.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.gbPhase.SuspendLayout()
        CType(Me.fgPhase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.gbTestBand.SuspendLayout()
        CType(Me.fgTestBand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSubmit)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.cbMode)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cbProduct)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 35)
        Me.Panel1.TabIndex = 99
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(537, 5)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(80, 25)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(627, 5)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'cbMode
        '
        Me.cbMode.BackColor = System.Drawing.Color.White
        Me.cbMode.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbMode.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMode.ForeColor = System.Drawing.Color.Black
        Me.cbMode.FormattingEnabled = True
        Me.cbMode.Location = New System.Drawing.Point(359, 6)
        Me.cbMode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbMode.Name = "cbMode"
        Me.cbMode.Size = New System.Drawing.Size(164, 23)
        Me.cbMode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(316, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Mode:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(6, 11)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Product:"
        '
        'cbProduct
        '
        Me.cbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProduct.BackColor = System.Drawing.Color.White
        Me.cbProduct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbProduct.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProduct.ForeColor = System.Drawing.Color.Black
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Location = New System.Drawing.Point(71, 6)
        Me.cbProduct.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(239, 23)
        Me.cbProduct.TabIndex = 0
        '
        'layoutMain
        '
        Me.layoutMain.ColumnCount = 1
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Controls.Add(Me.Panel1, 0, 0)
        Me.layoutMain.Controls.Add(Me.splitMain, 0, 1)
        Me.layoutMain.Controls.Add(Me.Panel2, 0, 2)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(0, 0)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.RowCount = 3
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.layoutMain.Size = New System.Drawing.Size(1184, 761)
        Me.layoutMain.TabIndex = 100
        '
        'splitMain
        '
        Me.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.Location = New System.Drawing.Point(3, 44)
        Me.splitMain.Name = "splitMain"
        Me.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.gbPhase)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.gbTestBand)
        Me.splitMain.Size = New System.Drawing.Size(1178, 664)
        Me.splitMain.SplitterDistance = 304
        Me.splitMain.SplitterWidth = 10
        Me.splitMain.TabIndex = 100
        '
        'gbPhase
        '
        Me.gbPhase.Controls.Add(Me.fgPhase)
        Me.gbPhase.Controls.Add(Me.TableLayoutPanel7)
        Me.gbPhase.Controls.Add(Me.TableLayoutPanel2)
        Me.gbPhase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbPhase.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPhase.Location = New System.Drawing.Point(0, 0)
        Me.gbPhase.Name = "gbPhase"
        Me.gbPhase.Size = New System.Drawing.Size(1174, 300)
        Me.gbPhase.TabIndex = 0
        Me.gbPhase.TabStop = False
        Me.gbPhase.Text = "Test Phase"
        '
        'fgPhase
        '
        Me.fgPhase.ColumnInfo = "1,1,0,0,0,105,Columns:"
        Me.fgPhase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgPhase.Location = New System.Drawing.Point(3, 48)
        Me.fgPhase.Name = "fgPhase"
        Me.fgPhase.Rows.Count = 1
        Me.fgPhase.Rows.DefaultSize = 21
        Me.fgPhase.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgPhase.Size = New System.Drawing.Size(1168, 217)
        Me.fgPhase.StyleInfo = resources.GetString("fgPhase.StyleInfo")
        Me.fgPhase.TabIndex = 114
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 7
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnDeletePhase, 6, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.pbLoadTest, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnInvalid, 5, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnAdd, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnRelease, 4, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnViewItem, 3, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 265)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(1168, 32)
        Me.TableLayoutPanel7.TabIndex = 113
        '
        'btnDeletePhase
        '
        Me.btnDeletePhase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDeletePhase.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeletePhase.Location = New System.Drawing.Point(1092, 3)
        Me.btnDeletePhase.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDeletePhase.Name = "btnDeletePhase"
        Me.btnDeletePhase.Size = New System.Drawing.Size(72, 26)
        Me.btnDeletePhase.TabIndex = 7
        Me.btnDeletePhase.Text = "Delete"
        Me.btnDeletePhase.UseVisualStyleBackColor = True
        '
        'pbLoadTest
        '
        Me.pbLoadTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbLoadTest.Location = New System.Drawing.Point(4, 3)
        Me.pbLoadTest.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pbLoadTest.Name = "pbLoadTest"
        Me.pbLoadTest.Size = New System.Drawing.Size(740, 26)
        Me.pbLoadTest.TabIndex = 11
        '
        'btnInvalid
        '
        Me.btnInvalid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInvalid.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvalid.Location = New System.Drawing.Point(1012, 3)
        Me.btnInvalid.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnInvalid.Name = "btnInvalid"
        Me.btnInvalid.Size = New System.Drawing.Size(72, 26)
        Me.btnInvalid.TabIndex = 9
        Me.btnInvalid.Text = "Invalid"
        Me.btnInvalid.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAdd.Enabled = False
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(772, 3)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(72, 26)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "New..."
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRelease
        '
        Me.btnRelease.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRelease.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRelease.Location = New System.Drawing.Point(932, 3)
        Me.btnRelease.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(72, 26)
        Me.btnRelease.TabIndex = 8
        Me.btnRelease.Text = "Release"
        Me.btnRelease.UseVisualStyleBackColor = True
        '
        'btnViewItem
        '
        Me.btnViewItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnViewItem.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewItem.Location = New System.Drawing.Point(852, 3)
        Me.btnViewItem.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnViewItem.Name = "btnViewItem"
        Me.btnViewItem.Size = New System.Drawing.Size(72, 26)
        Me.btnViewItem.TabIndex = 10
        Me.btnViewItem.Text = "View Item"
        Me.btnViewItem.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ckFilterDelete, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ckFilterInvalid, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ckFilterRelease, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1168, 30)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'ckFilterDelete
        '
        Me.ckFilterDelete.AutoSize = True
        Me.ckFilterDelete.Checked = True
        Me.ckFilterDelete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckFilterDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckFilterDelete.Enabled = False
        Me.ckFilterDelete.Location = New System.Drawing.Point(304, 3)
        Me.ckFilterDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ckFilterDelete.Name = "ckFilterDelete"
        Me.ckFilterDelete.Size = New System.Drawing.Size(82, 24)
        Me.ckFilterDelete.TabIndex = 49
        Me.ckFilterDelete.Text = "Delete"
        Me.ckFilterDelete.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 30)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "Filter Option:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ckFilterInvalid
        '
        Me.ckFilterInvalid.AutoSize = True
        Me.ckFilterInvalid.Checked = True
        Me.ckFilterInvalid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckFilterInvalid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckFilterInvalid.Location = New System.Drawing.Point(214, 3)
        Me.ckFilterInvalid.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ckFilterInvalid.Name = "ckFilterInvalid"
        Me.ckFilterInvalid.Size = New System.Drawing.Size(82, 24)
        Me.ckFilterInvalid.TabIndex = 48
        Me.ckFilterInvalid.Text = "Invalid"
        Me.ckFilterInvalid.UseVisualStyleBackColor = True
        '
        'ckFilterRelease
        '
        Me.ckFilterRelease.AutoSize = True
        Me.ckFilterRelease.Checked = True
        Me.ckFilterRelease.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckFilterRelease.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckFilterRelease.Location = New System.Drawing.Point(124, 3)
        Me.ckFilterRelease.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ckFilterRelease.Name = "ckFilterRelease"
        Me.ckFilterRelease.Size = New System.Drawing.Size(82, 24)
        Me.ckFilterRelease.TabIndex = 47
        Me.ckFilterRelease.Text = "Release"
        Me.ckFilterRelease.UseVisualStyleBackColor = True
        '
        'gbTestBand
        '
        Me.gbTestBand.Controls.Add(Me.fgTestBand)
        Me.gbTestBand.Controls.Add(Me.TableLayoutPanel8)
        Me.gbTestBand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbTestBand.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.gbTestBand.Location = New System.Drawing.Point(0, 0)
        Me.gbTestBand.Name = "gbTestBand"
        Me.gbTestBand.Size = New System.Drawing.Size(1174, 346)
        Me.gbTestBand.TabIndex = 115
        Me.gbTestBand.TabStop = False
        Me.gbTestBand.Text = "Test Band"
        '
        'fgTestBand
        '
        Me.fgTestBand.ColumnInfo = "1,1,0,0,0,105,Columns:"
        Me.fgTestBand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgTestBand.Location = New System.Drawing.Point(3, 61)
        Me.fgTestBand.Name = "fgTestBand"
        Me.fgTestBand.Rows.Count = 1
        Me.fgTestBand.Rows.DefaultSize = 21
        Me.fgTestBand.Size = New System.Drawing.Size(1168, 282)
        Me.fgTestBand.StyleInfo = resources.GetString("fgTestBand.StyleInfo")
        Me.fgTestBand.TabIndex = 114
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(1168, 43)
        Me.TableLayoutPanel8.TabIndex = 114
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtLengthLimit)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.btnLoadBands)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1162, 37)
        Me.Panel3.TabIndex = 0
        '
        'txtLengthLimit
        '
        Me.txtLengthLimit.Location = New System.Drawing.Point(149, 7)
        Me.txtLengthLimit.Name = "txtLengthLimit"
        Me.txtLengthLimit.Size = New System.Drawing.Size(100, 22)
        Me.txtLengthLimit.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 14)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Length Limit Upper:"
        '
        'btnLoadBands
        '
        Me.btnLoadBands.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadBands.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadBands.Location = New System.Drawing.Point(1066, 4)
        Me.btnLoadBands.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnLoadBands.Name = "btnLoadBands"
        Me.btnLoadBands.Size = New System.Drawing.Size(92, 28)
        Me.btnLoadBands.TabIndex = 105
        Me.btnLoadBands.Text = "Load Band"
        Me.btnLoadBands.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ckILOnly)
        Me.Panel2.Controls.Add(Me.btnLoaditems)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 714)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1178, 44)
        Me.Panel2.TabIndex = 101
        '
        'ckILOnly
        '
        Me.ckILOnly.AutoSize = True
        Me.ckILOnly.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.ckILOnly.Location = New System.Drawing.Point(12, 14)
        Me.ckILOnly.Name = "ckILOnly"
        Me.ckILOnly.Size = New System.Drawing.Size(75, 18)
        Me.ckILOnly.TabIndex = 106
        Me.ckILOnly.Text = "IL Only"
        Me.ckILOnly.UseVisualStyleBackColor = True
        '
        'btnLoaditems
        '
        Me.btnLoaditems.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnLoaditems.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoaditems.Location = New System.Drawing.Point(1077, 7)
        Me.btnLoaditems.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnLoaditems.Name = "btnLoaditems"
        Me.btnLoaditems.Size = New System.Drawing.Size(91, 30)
        Me.btnLoaditems.TabIndex = 105
        Me.btnLoaditems.Text = "Load Item"
        Me.btnLoaditems.UseVisualStyleBackColor = True
        '
        'FormPRSPRLIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.layoutMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormPRSPRLIL"
        Me.Text = "*RL_IL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.layoutMain.ResumeLayout(False)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.gbPhase.ResumeLayout(False)
        CType(Me.fgPhase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.gbTestBand.ResumeLayout(False)
        CType(Me.fgTestBand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents cbMode As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cbProduct As ComboBox
    Friend WithEvents layoutMain As TableLayoutPanel
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents gbPhase As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ckFilterDelete As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ckFilterInvalid As CheckBox
    Friend WithEvents ckFilterRelease As CheckBox
    Friend WithEvents fgPhase As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents btnDeletePhase As Button
    Friend WithEvents pbLoadTest As ProgressBar
    Friend WithEvents btnInvalid As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRelease As Button
    Friend WithEvents btnViewItem As Button
    Friend WithEvents btnLoaditems As Button
    Friend WithEvents gbTestBand As GroupBox
    Friend WithEvents fgTestBand As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents btnLoadBands As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ckILOnly As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtLengthLimit As TextBox
    Friend WithEvents Label2 As Label
End Class
