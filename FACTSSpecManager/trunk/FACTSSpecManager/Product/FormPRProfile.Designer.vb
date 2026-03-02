<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPRProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPRProfile))
        Me.layoutToolsMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbProduct = New System.Windows.Forms.ComboBox()
        Me.ckProdValidity = New System.Windows.Forms.CheckBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.layoutBasic = New System.Windows.Forms.TableLayoutPanel()
        Me.nudSubunit = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProdDescr = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLength = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbFamily = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudFiberPerSubunit = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb1500Spec = New System.Windows.Forms.ComboBox()
        Me.cb1501Spec = New System.Windows.Forms.ComboBox()
        Me.gbBasic = New System.Windows.Forms.GroupBox()
        Me.gbConnectorSpecNum = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnConnSpecEdit = New System.Windows.Forms.Button()
        Me.gbFiberCableIL = New System.Windows.Forms.GroupBox()
        Me.fgILLimit = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnCableILEdit = New System.Windows.Forms.Button()
        Me.cbLimitName = New System.Windows.Forms.ComboBox()
        Me.ckAddIL = New System.Windows.Forms.CheckBox()
        Me.layoutToolsMenu.SuspendLayout()
        Me.layoutBasic.SuspendLayout()
        CType(Me.nudSubunit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFiberPerSubunit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBasic.SuspendLayout()
        Me.gbConnectorSpecNum.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbFiberCableIL.SuspendLayout()
        CType(Me.fgILLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutToolsMenu
        '
        Me.layoutToolsMenu.ColumnCount = 12
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.layoutToolsMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutToolsMenu.Controls.Add(Me.Label7, 0, 0)
        Me.layoutToolsMenu.Controls.Add(Me.cbProduct, 1, 0)
        Me.layoutToolsMenu.Controls.Add(Me.ckProdValidity, 2, 0)
        Me.layoutToolsMenu.Controls.Add(Me.btnAdd, 4, 0)
        Me.layoutToolsMenu.Controls.Add(Me.btnExit, 10, 0)
        Me.layoutToolsMenu.Controls.Add(Me.btnUpdate, 6, 0)
        Me.layoutToolsMenu.Controls.Add(Me.btnDelete, 8, 0)
        Me.layoutToolsMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.layoutToolsMenu.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layoutToolsMenu.Location = New System.Drawing.Point(0, 0)
        Me.layoutToolsMenu.Name = "layoutToolsMenu"
        Me.layoutToolsMenu.RowCount = 1
        Me.layoutToolsMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutToolsMenu.Size = New System.Drawing.Size(1184, 31)
        Me.layoutToolsMenu.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 31)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Product:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbProduct
        '
        Me.cbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbProduct.BackColor = System.Drawing.Color.White
        Me.cbProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbProduct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbProduct.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProduct.ForeColor = System.Drawing.Color.Black
        Me.cbProduct.FormattingEnabled = True
        Me.cbProduct.Location = New System.Drawing.Point(116, 3)
        Me.cbProduct.Name = "cbProduct"
        Me.cbProduct.Size = New System.Drawing.Size(281, 23)
        Me.cbProduct.TabIndex = 0
        '
        'ckProdValidity
        '
        Me.ckProdValidity.AutoSize = True
        Me.ckProdValidity.BackColor = System.Drawing.Color.White
        Me.ckProdValidity.Checked = True
        Me.ckProdValidity.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckProdValidity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckProdValidity.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckProdValidity.Location = New System.Drawing.Point(403, 3)
        Me.ckProdValidity.Name = "ckProdValidity"
        Me.ckProdValidity.Size = New System.Drawing.Size(89, 25)
        Me.ckProdValidity.TabIndex = 1
        Me.ckProdValidity.Text = "Validity"
        Me.ckProdValidity.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAdd.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(533, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(64, 25)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExit.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(803, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 25)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnUpdate.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(623, 3)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(64, 25)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(713, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 25)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'layoutBasic
        '
        Me.layoutBasic.ColumnCount = 2
        Me.layoutBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112.0!))
        Me.layoutBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutBasic.Controls.Add(Me.nudSubunit, 1, 4)
        Me.layoutBasic.Controls.Add(Me.Label4, 0, 7)
        Me.layoutBasic.Controls.Add(Me.txtProdDescr, 1, 7)
        Me.layoutBasic.Controls.Add(Me.Label9, 0, 0)
        Me.layoutBasic.Controls.Add(Me.cmbCustomer, 1, 0)
        Me.layoutBasic.Controls.Add(Me.Label2, 0, 1)
        Me.layoutBasic.Controls.Add(Me.txtCustName, 1, 1)
        Me.layoutBasic.Controls.Add(Me.Label3, 0, 2)
        Me.layoutBasic.Controls.Add(Me.txtVersion, 1, 2)
        Me.layoutBasic.Controls.Add(Me.Label8, 0, 4)
        Me.layoutBasic.Controls.Add(Me.Label1, 0, 6)
        Me.layoutBasic.Controls.Add(Me.txtLength, 1, 6)
        Me.layoutBasic.Controls.Add(Me.Label5, 0, 3)
        Me.layoutBasic.Controls.Add(Me.cbFamily, 1, 3)
        Me.layoutBasic.Controls.Add(Me.Label6, 0, 5)
        Me.layoutBasic.Controls.Add(Me.nudFiberPerSubunit, 1, 5)
        Me.layoutBasic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutBasic.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layoutBasic.Location = New System.Drawing.Point(3, 18)
        Me.layoutBasic.Name = "layoutBasic"
        Me.layoutBasic.RowCount = 9
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutBasic.Size = New System.Drawing.Size(391, 709)
        Me.layoutBasic.TabIndex = 2
        '
        'nudSubunit
        '
        Me.nudSubunit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudSubunit.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudSubunit.Location = New System.Drawing.Point(115, 115)
        Me.nudSubunit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSubunit.Name = "nudSubunit"
        Me.nudSubunit.Size = New System.Drawing.Size(273, 22)
        Me.nudSubunit.TabIndex = 4
        Me.nudSubunit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 200)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Descr:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtProdDescr
        '
        Me.txtProdDescr.BackColor = System.Drawing.Color.White
        Me.txtProdDescr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdDescr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtProdDescr.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProdDescr.ForeColor = System.Drawing.Color.Black
        Me.txtProdDescr.Location = New System.Drawing.Point(115, 199)
        Me.txtProdDescr.Multiline = True
        Me.txtProdDescr.Name = "txtProdDescr"
        Me.txtProdDescr.Size = New System.Drawing.Size(273, 194)
        Me.txtProdDescr.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 28)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Customer:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCustomer
        '
        Me.cmbCustomer.BackColor = System.Drawing.Color.White
        Me.cmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCustomer.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.FormattingEnabled = True
        Me.cmbCustomer.Location = New System.Drawing.Point(115, 3)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(273, 22)
        Me.cmbCustomer.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 28)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cust Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCustName
        '
        Me.txtCustName.BackColor = System.Drawing.Color.White
        Me.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCustName.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustName.ForeColor = System.Drawing.Color.Black
        Me.txtCustName.Location = New System.Drawing.Point(115, 31)
        Me.txtCustName.Name = "txtCustName"
        Me.txtCustName.Size = New System.Drawing.Size(273, 22)
        Me.txtCustName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 28)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Version:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVersion
        '
        Me.txtVersion.BackColor = System.Drawing.Color.White
        Me.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVersion.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersion.ForeColor = System.Drawing.Color.Black
        Me.txtVersion.Location = New System.Drawing.Point(115, 59)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(273, 22)
        Me.txtVersion.TabIndex = 2
        Me.txtVersion.Text = "01"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 28)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Subunits:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 28)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Length(m):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLength
        '
        Me.txtLength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLength.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLength.Location = New System.Drawing.Point(115, 171)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(273, 22)
        Me.txtLength.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 28)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Family:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbFamily
        '
        Me.cbFamily.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFamily.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFamily.FormattingEnabled = True
        Me.cbFamily.Location = New System.Drawing.Point(115, 87)
        Me.cbFamily.Name = "cbFamily"
        Me.cbFamily.Size = New System.Drawing.Size(273, 22)
        Me.cbFamily.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 28)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Fibers per Subunit:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudFiberPerSubunit
        '
        Me.nudFiberPerSubunit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nudFiberPerSubunit.Location = New System.Drawing.Point(115, 143)
        Me.nudFiberPerSubunit.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFiberPerSubunit.Name = "nudFiberPerSubunit"
        Me.nudFiberPerSubunit.Size = New System.Drawing.Size(273, 22)
        Me.nudFiberPerSubunit.TabIndex = 31
        Me.nudFiberPerSubunit.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 28)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Spec Num 1500:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(3, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 28)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Spec Num 1501:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cb1500Spec
        '
        Me.cb1500Spec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cb1500Spec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb1500Spec.FormattingEnabled = True
        Me.cb1500Spec.Location = New System.Drawing.Point(122, 3)
        Me.cb1500Spec.Name = "cb1500Spec"
        Me.cb1500Spec.Size = New System.Drawing.Size(223, 22)
        Me.cb1500Spec.TabIndex = 34
        '
        'cb1501Spec
        '
        Me.cb1501Spec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cb1501Spec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb1501Spec.FormattingEnabled = True
        Me.cb1501Spec.Location = New System.Drawing.Point(122, 31)
        Me.cb1501Spec.Name = "cb1501Spec"
        Me.cb1501Spec.Size = New System.Drawing.Size(223, 22)
        Me.cb1501Spec.TabIndex = 35
        '
        'gbBasic
        '
        Me.gbBasic.Controls.Add(Me.layoutBasic)
        Me.gbBasic.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbBasic.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBasic.Location = New System.Drawing.Point(0, 31)
        Me.gbBasic.Name = "gbBasic"
        Me.gbBasic.Size = New System.Drawing.Size(397, 730)
        Me.gbBasic.TabIndex = 3
        Me.gbBasic.TabStop = False
        Me.gbBasic.Text = "Basic"
        '
        'gbConnectorSpecNum
        '
        Me.gbConnectorSpecNum.Controls.Add(Me.TableLayoutPanel1)
        Me.gbConnectorSpecNum.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbConnectorSpecNum.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbConnectorSpecNum.Location = New System.Drawing.Point(397, 31)
        Me.gbConnectorSpecNum.Name = "gbConnectorSpecNum"
        Me.gbConnectorSpecNum.Size = New System.Drawing.Size(385, 730)
        Me.gbConnectorSpecNum.TabIndex = 4
        Me.gbConnectorSpecNum.TabStop = False
        Me.gbConnectorSpecNum.Text = "Connector Spec Number"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cb1500Spec, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cb1501Spec, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnConnSpecEdit, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(379, 709)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnConnSpecEdit
        '
        Me.btnConnSpecEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnConnSpecEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnSpecEdit.Image = Global.FACTSSpecManager.My.Resources.Resources.Maintenance
        Me.btnConnSpecEdit.Location = New System.Drawing.Point(351, 3)
        Me.btnConnSpecEdit.Name = "btnConnSpecEdit"
        Me.btnConnSpecEdit.Size = New System.Drawing.Size(25, 22)
        Me.btnConnSpecEdit.TabIndex = 36
        Me.btnConnSpecEdit.UseVisualStyleBackColor = True
        '
        'gbFiberCableIL
        '
        Me.gbFiberCableIL.Controls.Add(Me.fgILLimit)
        Me.gbFiberCableIL.Controls.Add(Me.btnCableILEdit)
        Me.gbFiberCableIL.Controls.Add(Me.cbLimitName)
        Me.gbFiberCableIL.Controls.Add(Me.ckAddIL)
        Me.gbFiberCableIL.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbFiberCableIL.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbFiberCableIL.Location = New System.Drawing.Point(782, 31)
        Me.gbFiberCableIL.Name = "gbFiberCableIL"
        Me.gbFiberCableIL.Size = New System.Drawing.Size(305, 730)
        Me.gbFiberCableIL.TabIndex = 5
        Me.gbFiberCableIL.TabStop = False
        Me.gbFiberCableIL.Text = "Fiber Cable IL Limit"
        '
        'fgILLimit
        '
        Me.fgILLimit.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgILLimit.AllowEditing = False
        Me.fgILLimit.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.None
        Me.fgILLimit.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.fgILLimit.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgILLimit.ColumnInfo = "1,1,0,0,0,105,Columns:"
        Me.fgILLimit.Enabled = False
        Me.fgILLimit.Location = New System.Drawing.Point(10, 76)
        Me.fgILLimit.Name = "fgILLimit"
        Me.fgILLimit.Rows.Count = 1
        Me.fgILLimit.Rows.DefaultSize = 21
        Me.fgILLimit.Size = New System.Drawing.Size(289, 241)
        Me.fgILLimit.StyleInfo = resources.GetString("fgILLimit.StyleInfo")
        Me.fgILLimit.TabIndex = 4
        '
        'btnCableILEdit
        '
        Me.btnCableILEdit.Enabled = False
        Me.btnCableILEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCableILEdit.Image = Global.FACTSSpecManager.My.Resources.Resources.Maintenance
        Me.btnCableILEdit.Location = New System.Drawing.Point(177, 45)
        Me.btnCableILEdit.Name = "btnCableILEdit"
        Me.btnCableILEdit.Size = New System.Drawing.Size(25, 22)
        Me.btnCableILEdit.TabIndex = 3
        Me.btnCableILEdit.UseVisualStyleBackColor = True
        '
        'cbLimitName
        '
        Me.cbLimitName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLimitName.Enabled = False
        Me.cbLimitName.FormattingEnabled = True
        Me.cbLimitName.Location = New System.Drawing.Point(10, 45)
        Me.cbLimitName.Name = "cbLimitName"
        Me.cbLimitName.Size = New System.Drawing.Size(161, 22)
        Me.cbLimitName.TabIndex = 2
        '
        'ckAddIL
        '
        Me.ckAddIL.AutoSize = True
        Me.ckAddIL.Location = New System.Drawing.Point(10, 22)
        Me.ckAddIL.Name = "ckAddIL"
        Me.ckAddIL.Size = New System.Drawing.Size(187, 18)
        Me.ckAddIL.TabIndex = 1
        Me.ckAddIL.Text = "Add IL for Cable Length"
        Me.ckAddIL.UseVisualStyleBackColor = True
        '
        'FormPRProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 761)
        Me.Controls.Add(Me.gbFiberCableIL)
        Me.Controls.Add(Me.gbConnectorSpecNum)
        Me.Controls.Add(Me.gbBasic)
        Me.Controls.Add(Me.layoutToolsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormPRProfile"
        Me.Text = "*Product Proifle"
        Me.layoutToolsMenu.ResumeLayout(False)
        Me.layoutToolsMenu.PerformLayout()
        Me.layoutBasic.ResumeLayout(False)
        Me.layoutBasic.PerformLayout()
        CType(Me.nudSubunit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFiberPerSubunit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBasic.ResumeLayout(False)
        Me.gbConnectorSpecNum.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.gbFiberCableIL.ResumeLayout(False)
        Me.gbFiberCableIL.PerformLayout()
        CType(Me.fgILLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents layoutToolsMenu As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents cbProduct As ComboBox
    Friend WithEvents ckProdValidity As CheckBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents layoutBasic As TableLayoutPanel
    Friend WithEvents nudSubunit As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProdDescr As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbCustomer As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCustName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtVersion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLength As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbFamily As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents nudFiberPerSubunit As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cb1500Spec As ComboBox
    Friend WithEvents cb1501Spec As ComboBox
    Friend WithEvents gbBasic As GroupBox
    Friend WithEvents gbConnectorSpecNum As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnConnSpecEdit As Button
    Friend WithEvents gbFiberCableIL As GroupBox
    Friend WithEvents fgILLimit As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnCableILEdit As Button
    Friend WithEvents cbLimitName As ComboBox
    Friend WithEvents ckAddIL As CheckBox
End Class
