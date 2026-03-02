<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBenchSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBenchSetting))
        Me.layoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.gbUploadProgram = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbProgram = New System.Windows.Forms.TextBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.gbHead = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbTestMode = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbPhaseStation = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbPigtail = New System.Windows.Forms.RadioButton()
        Me.rbConnector = New System.Windows.Forms.RadioButton()
        Me.rbSystem = New System.Windows.Forms.RadioButton()
        Me.gbInstrument = New System.Windows.Forms.GroupBox()
        Me.layoutNA = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbInstrumentType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIPAddress = New System.Windows.Forms.TextBox()
        Me.layoutIDN = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIDN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.layoutMisc = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCalHour = New System.Windows.Forms.TextBox()
        Me.btnInstrumentCk = New System.Windows.Forms.Button()
        Me.gbMisc = New System.Windows.Forms.GroupBox()
        Me.layoutOptions = New System.Windows.Forms.TableLayoutPanel()
        Me.ckSAPFailSafeMode = New System.Windows.Forms.CheckBox()
        Me.txtRetryCount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ckLiveMode = New System.Windows.Forms.CheckBox()
        Me.gbRecCal = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbRecJumperCalType = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbRecJumperLength = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.fgSwitchPortMapping = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.layoutMain.SuspendLayout()
        Me.gbUploadProgram.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.gbHead.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbInstrument.SuspendLayout()
        Me.layoutNA.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.layoutIDN.SuspendLayout()
        Me.layoutMisc.SuspendLayout()
        Me.gbMisc.SuspendLayout()
        Me.layoutOptions.SuspendLayout()
        Me.gbRecCal.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.fgSwitchPortMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'layoutMain
        '
        Me.layoutMain.ColumnCount = 1
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Controls.Add(Me.gbUploadProgram, 0, 2)
        Me.layoutMain.Controls.Add(Me.gbHead, 0, 0)
        Me.layoutMain.Controls.Add(Me.gbInstrument, 0, 1)
        Me.layoutMain.Controls.Add(Me.gbMisc, 0, 4)
        Me.layoutMain.Controls.Add(Me.gbRecCal, 0, 3)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(3, 3)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.RowCount = 6
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Size = New System.Drawing.Size(694, 351)
        Me.layoutMain.TabIndex = 0
        '
        'gbUploadProgram
        '
        Me.gbUploadProgram.Controls.Add(Me.TableLayoutPanel3)
        Me.gbUploadProgram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbUploadProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbUploadProgram.Location = New System.Drawing.Point(3, 188)
        Me.gbUploadProgram.Name = "gbUploadProgram"
        Me.gbUploadProgram.Size = New System.Drawing.Size(688, 46)
        Me.gbUploadProgram.TabIndex = 33
        Me.gbUploadProgram.TabStop = False
        Me.gbUploadProgram.Text = "Upload Program"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.tbProgram, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSelect, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(682, 26)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'tbProgram
        '
        Me.tbProgram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbProgram.Enabled = False
        Me.tbProgram.Location = New System.Drawing.Point(3, 3)
        Me.tbProgram.Name = "tbProgram"
        Me.tbProgram.Size = New System.Drawing.Size(636, 20)
        Me.tbProgram.TabIndex = 21
        Me.tbProgram.Text = "C:\CATS\test_application\ResultTransferTool\ResultTransferGUI.exe"
        '
        'btnSelect
        '
        Me.btnSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSelect.Location = New System.Drawing.Point(645, 3)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(34, 20)
        Me.btnSelect.TabIndex = 23
        Me.btnSelect.Text = "?"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'gbHead
        '
        Me.gbHead.Controls.Add(Me.TableLayoutPanel1)
        Me.gbHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbHead.Location = New System.Drawing.Point(3, 3)
        Me.gbHead.Name = "gbHead"
        Me.gbHead.Size = New System.Drawing.Size(688, 49)
        Me.gbHead.TabIndex = 0
        Me.gbHead.TabStop = False
        Me.gbHead.Text = "Head"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbTestMode, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbPhaseStation, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(682, 29)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Test Mode"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbTestMode
        '
        Me.cbTestMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbTestMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTestMode.FormattingEnabled = True
        Me.cbTestMode.Location = New System.Drawing.Point(78, 3)
        Me.cbTestMode.Name = "cbTestMode"
        Me.cbTestMode.Size = New System.Drawing.Size(96, 21)
        Me.cbTestMode.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(180, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 29)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Phase Station"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbPhaseStation
        '
        Me.cbPhaseStation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbPhaseStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPhaseStation.FormattingEnabled = True
        Me.cbPhaseStation.Items.AddRange(New Object() {"PreTest", "FinalTest"})
        Me.cbPhaseStation.Location = New System.Drawing.Point(269, 3)
        Me.cbPhaseStation.Name = "cbPhaseStation"
        Me.cbPhaseStation.Size = New System.Drawing.Size(104, 21)
        Me.cbPhaseStation.TabIndex = 3
        Me.cbPhaseStation.Text = "FinalTest"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbPigtail)
        Me.Panel1.Controls.Add(Me.rbConnector)
        Me.Panel1.Controls.Add(Me.rbSystem)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(399, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(274, 23)
        Me.Panel1.TabIndex = 4
        '
        'rbPigtail
        '
        Me.rbPigtail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbPigtail.AutoSize = True
        Me.rbPigtail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPigtail.Location = New System.Drawing.Point(198, 3)
        Me.rbPigtail.Name = "rbPigtail"
        Me.rbPigtail.Size = New System.Drawing.Size(59, 19)
        Me.rbPigtail.TabIndex = 0
        Me.rbPigtail.TabStop = True
        Me.rbPigtail.Text = "Pigtail"
        Me.rbPigtail.UseVisualStyleBackColor = True
        '
        'rbConnector
        '
        Me.rbConnector.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbConnector.AutoSize = True
        Me.rbConnector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConnector.Location = New System.Drawing.Point(99, 2)
        Me.rbConnector.Name = "rbConnector"
        Me.rbConnector.Size = New System.Drawing.Size(81, 19)
        Me.rbConnector.TabIndex = 0
        Me.rbConnector.TabStop = True
        Me.rbConnector.Text = "Connector"
        Me.rbConnector.UseVisualStyleBackColor = True
        '
        'rbSystem
        '
        Me.rbSystem.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbSystem.AutoSize = True
        Me.rbSystem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSystem.Location = New System.Drawing.Point(16, 2)
        Me.rbSystem.Name = "rbSystem"
        Me.rbSystem.Size = New System.Drawing.Size(65, 19)
        Me.rbSystem.TabIndex = 0
        Me.rbSystem.TabStop = True
        Me.rbSystem.Text = "System"
        Me.rbSystem.UseVisualStyleBackColor = True
        '
        'gbInstrument
        '
        Me.gbInstrument.Controls.Add(Me.layoutNA)
        Me.gbInstrument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbInstrument.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInstrument.Location = New System.Drawing.Point(3, 58)
        Me.gbInstrument.Name = "gbInstrument"
        Me.gbInstrument.Size = New System.Drawing.Size(688, 124)
        Me.gbInstrument.TabIndex = 1
        Me.gbInstrument.TabStop = False
        Me.gbInstrument.Text = "Instrument"
        '
        'layoutNA
        '
        Me.layoutNA.ColumnCount = 1
        Me.layoutNA.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutNA.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.layoutNA.Controls.Add(Me.layoutIDN, 0, 1)
        Me.layoutNA.Controls.Add(Me.layoutMisc, 0, 2)
        Me.layoutNA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layoutNA.Location = New System.Drawing.Point(3, 17)
        Me.layoutNA.Name = "layoutNA"
        Me.layoutNA.RowCount = 3
        Me.layoutNA.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.layoutNA.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.layoutNA.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutNA.Size = New System.Drawing.Size(682, 104)
        Me.layoutNA.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cbInstrumentType, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtIPAddress, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(676, 29)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 29)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbInstrumentType
        '
        Me.cbInstrumentType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbInstrumentType.FormattingEnabled = True
        Me.cbInstrumentType.Items.AddRange(New Object() {"MAP200_PCT"})
        Me.cbInstrumentType.Location = New System.Drawing.Point(78, 3)
        Me.cbInstrumentType.Name = "cbInstrumentType"
        Me.cbInstrumentType.Size = New System.Drawing.Size(94, 21)
        Me.cbInstrumentType.TabIndex = 2
        Me.cbInstrumentType.Text = "MAP20_PCT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(178, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 29)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "IP Address"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIPAddress.Location = New System.Drawing.Point(263, 3)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(410, 20)
        Me.txtIPAddress.TabIndex = 3
        '
        'layoutIDN
        '
        Me.layoutIDN.ColumnCount = 4
        Me.layoutIDN.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.layoutIDN.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.layoutIDN.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.layoutIDN.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutIDN.Controls.Add(Me.Label4, 2, 0)
        Me.layoutIDN.Controls.Add(Me.txtIDN, 3, 0)
        Me.layoutIDN.Controls.Add(Me.Label5, 0, 0)
        Me.layoutIDN.Controls.Add(Me.txtPort, 1, 0)
        Me.layoutIDN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutIDN.Location = New System.Drawing.Point(3, 38)
        Me.layoutIDN.Name = "layoutIDN"
        Me.layoutIDN.RowCount = 1
        Me.layoutIDN.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutIDN.Size = New System.Drawing.Size(676, 29)
        Me.layoutIDN.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(178, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 29)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "IDN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIDN
        '
        Me.txtIDN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtIDN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDN.Location = New System.Drawing.Point(263, 3)
        Me.txtIDN.Name = "txtIDN"
        Me.txtIDN.Size = New System.Drawing.Size(410, 22)
        Me.txtIDN.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 29)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Port"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPort
        '
        Me.txtPort.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(78, 3)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(94, 22)
        Me.txtPort.TabIndex = 7
        '
        'layoutMisc
        '
        Me.layoutMisc.ColumnCount = 4
        Me.layoutMisc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.layoutMisc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.layoutMisc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.layoutMisc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMisc.Controls.Add(Me.Label8, 0, 0)
        Me.layoutMisc.Controls.Add(Me.txtCalHour, 1, 0)
        Me.layoutMisc.Controls.Add(Me.btnInstrumentCk, 2, 0)
        Me.layoutMisc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMisc.Location = New System.Drawing.Point(3, 73)
        Me.layoutMisc.Name = "layoutMisc"
        Me.layoutMisc.RowCount = 1
        Me.layoutMisc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMisc.Size = New System.Drawing.Size(676, 28)
        Me.layoutMisc.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 28)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "CAL(h)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCalHour
        '
        Me.txtCalHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCalHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalHour.Location = New System.Drawing.Point(78, 3)
        Me.txtCalHour.Name = "txtCalHour"
        Me.txtCalHour.Size = New System.Drawing.Size(94, 22)
        Me.txtCalHour.TabIndex = 7
        Me.txtCalHour.Text = "1"
        Me.txtCalHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnInstrumentCk
        '
        Me.btnInstrumentCk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInstrumentCk.Location = New System.Drawing.Point(178, 3)
        Me.btnInstrumentCk.Name = "btnInstrumentCk"
        Me.btnInstrumentCk.Size = New System.Drawing.Size(79, 22)
        Me.btnInstrumentCk.TabIndex = 6
        Me.btnInstrumentCk.Text = "Check"
        Me.btnInstrumentCk.UseVisualStyleBackColor = True
        '
        'gbMisc
        '
        Me.gbMisc.Controls.Add(Me.layoutOptions)
        Me.gbMisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMisc.Location = New System.Drawing.Point(3, 292)
        Me.gbMisc.Name = "gbMisc"
        Me.gbMisc.Size = New System.Drawing.Size(688, 46)
        Me.gbMisc.TabIndex = 34
        Me.gbMisc.TabStop = False
        Me.gbMisc.Text = "Misc"
        '
        'layoutOptions
        '
        Me.layoutOptions.ColumnCount = 5
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutOptions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutOptions.Controls.Add(Me.ckSAPFailSafeMode, 0, 0)
        Me.layoutOptions.Controls.Add(Me.txtRetryCount, 3, 0)
        Me.layoutOptions.Controls.Add(Me.Label7, 2, 0)
        Me.layoutOptions.Controls.Add(Me.ckLiveMode, 1, 0)
        Me.layoutOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.layoutOptions.Location = New System.Drawing.Point(3, 17)
        Me.layoutOptions.Name = "layoutOptions"
        Me.layoutOptions.RowCount = 1
        Me.layoutOptions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutOptions.Size = New System.Drawing.Size(682, 26)
        Me.layoutOptions.TabIndex = 32
        '
        'ckSAPFailSafeMode
        '
        Me.ckSAPFailSafeMode.AutoSize = True
        Me.ckSAPFailSafeMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckSAPFailSafeMode.Location = New System.Drawing.Point(3, 3)
        Me.ckSAPFailSafeMode.Name = "ckSAPFailSafeMode"
        Me.ckSAPFailSafeMode.Size = New System.Drawing.Size(134, 20)
        Me.ckSAPFailSafeMode.TabIndex = 2
        Me.ckSAPFailSafeMode.Text = "SAP Fail Safe Mode"
        Me.ckSAPFailSafeMode.UseVisualStyleBackColor = True
        '
        'txtRetryCount
        '
        Me.txtRetryCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRetryCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetryCount.Location = New System.Drawing.Point(323, 3)
        Me.txtRetryCount.Name = "txtRetryCount"
        Me.txtRetryCount.Size = New System.Drawing.Size(34, 21)
        Me.txtRetryCount.TabIndex = 29
        Me.txtRetryCount.Text = "2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(243, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 26)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Retry Count:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ckLiveMode
        '
        Me.ckLiveMode.AutoSize = True
        Me.ckLiveMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckLiveMode.Location = New System.Drawing.Point(143, 3)
        Me.ckLiveMode.Name = "ckLiveMode"
        Me.ckLiveMode.Size = New System.Drawing.Size(94, 20)
        Me.ckLiveMode.TabIndex = 30
        Me.ckLiveMode.Text = "Live Mode"
        Me.ckLiveMode.UseVisualStyleBackColor = True
        '
        'gbRecCal
        '
        Me.gbRecCal.Controls.Add(Me.TableLayoutPanel4)
        Me.gbRecCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRecCal.Location = New System.Drawing.Point(3, 240)
        Me.gbRecCal.Name = "gbRecCal"
        Me.gbRecCal.Size = New System.Drawing.Size(688, 46)
        Me.gbRecCal.TabIndex = 35
        Me.gbRecCal.TabStop = False
        Me.gbRecCal.Text = "Receive Jumper Cal"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 7
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbRecJumperCalType, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label13, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tbRecJumperLength, 5, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(682, 26)
        Me.TableLayoutPanel4.TabIndex = 32
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(206, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 26)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Simulate Cal IL:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 26)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Rec. Jumper Cal Type:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbRecJumperCalType
        '
        Me.cbRecJumperCalType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbRecJumperCalType.FormattingEnabled = True
        Me.cbRecJumperCalType.Location = New System.Drawing.Point(126, 3)
        Me.cbRecJumperCalType.Name = "cbRecJumperCalType"
        Me.cbRecJumperCalType.Size = New System.Drawing.Size(74, 21)
        Me.cbRecJumperCalType.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(298, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 26)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "0.05"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(337, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(147, 26)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Simulate Rec Jumper Length:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbRecJumperLength
        '
        Me.tbRecJumperLength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbRecJumperLength.Location = New System.Drawing.Point(490, 3)
        Me.tbRecJumperLength.Name = "tbRecJumperLength"
        Me.tbRecJumperLength.Size = New System.Drawing.Size(37, 20)
        Me.tbRecJumperLength.TabIndex = 35
        Me.tbRecJumperLength.Text = "4.0"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(708, 383)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.layoutMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(700, 357)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.fgSwitchPortMapping)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(700, 357)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Switch Port Mapping Config"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'fgSwitchPortMapping
        '
        Me.fgSwitchPortMapping.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fgSwitchPortMapping.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Rows
        Me.fgSwitchPortMapping.ColumnInfo = "1,1,0,0,0,95,Columns:"
        Me.fgSwitchPortMapping.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgSwitchPortMapping.Location = New System.Drawing.Point(3, 3)
        Me.fgSwitchPortMapping.Name = "fgSwitchPortMapping"
        Me.fgSwitchPortMapping.Rows.Count = 1
        Me.fgSwitchPortMapping.Rows.DefaultSize = 19
        Me.fgSwitchPortMapping.Size = New System.Drawing.Size(694, 351)
        Me.fgSwitchPortMapping.StyleInfo = resources.GetString("fgSwitchPortMapping.StyleInfo")
        Me.fgSwitchPortMapping.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(576, 393)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 30)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Text = "Save and Exit"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FormBenchSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 435)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBenchSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bench Setting"
        Me.layoutMain.ResumeLayout(False)
        Me.gbUploadProgram.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.gbHead.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbInstrument.ResumeLayout(False)
        Me.layoutNA.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.layoutIDN.ResumeLayout(False)
        Me.layoutIDN.PerformLayout()
        Me.layoutMisc.ResumeLayout(False)
        Me.layoutMisc.PerformLayout()
        Me.gbMisc.ResumeLayout(False)
        Me.layoutOptions.ResumeLayout(False)
        Me.layoutOptions.PerformLayout()
        Me.gbRecCal.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.fgSwitchPortMapping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents layoutMain As TableLayoutPanel
    Friend WithEvents gbHead As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbTestMode As ComboBox
    Friend WithEvents gbInstrument As GroupBox
    Friend WithEvents layoutNA As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents cbInstrumentType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIPAddress As TextBox
    Friend WithEvents layoutIDN As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIDN As TextBox
    Friend WithEvents layoutMisc As TableLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCalHour As TextBox
    Friend WithEvents btnInstrumentCk As Button
    Friend WithEvents gbMisc As GroupBox
    Friend WithEvents layoutOptions As TableLayoutPanel
    Friend WithEvents ckSAPFailSafeMode As CheckBox
    Friend WithEvents gbUploadProgram As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents tbProgram As TextBox
    Friend WithEvents btnSelect As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbPhaseStation As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRetryCount As TextBox
    Friend WithEvents ckLiveMode As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbConnector As RadioButton
    Friend WithEvents rbSystem As RadioButton
    Friend WithEvents fgSwitchPortMapping As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents rbPigtail As RadioButton
    Friend WithEvents gbRecCal As GroupBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbRecJumperCalType As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents tbRecJumperLength As TextBox
End Class
