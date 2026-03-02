<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGUI
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGUI))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslUserName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslPCName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslPlant = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslSAPFailSafeMode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslDatabaseName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.tsslMode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslTestType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslInstrumentState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslRetryCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslCycleTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenchSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowPFDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MAP200LiveModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StabilityMonitorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.layoutMain = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.layoutTest = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.splitLiveMode = New System.Windows.Forms.SplitContainer()
        Me.fgTestItems = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cmsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNothingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UploadTestDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbLiveDisplay = New System.Windows.Forms.GroupBox()
        Me.lblPower = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblWavelength = New System.Windows.Forms.Label()
        Me.lblORL = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIL = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.layoutPhaseGroup = New System.Windows.Forms.TableLayoutPanel()
        Me.fgTestGroups = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fgTestPhases = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.layoutTools = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSN2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSN1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtPN = New System.Windows.Forms.TextBox()
        Me.CmdCAL = New System.Windows.Forms.Button()
        Me.CmdRunAll = New System.Windows.Forms.Button()
        Me.CmdAbort = New System.Windows.Forms.Button()
        Me.ckLoadTestData = New System.Windows.Forms.CheckBox()
        Me.ckLoadPFQ = New System.Windows.Forms.CheckBox()
        Me.gbAssemblyInfo = New System.Windows.Forms.GroupBox()
        Me.layoutAssemblyInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl1500Connector = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl1501Connector = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblSubunits = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblFiberPerSubunit = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblWO = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblPF = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip3 = New System.Windows.Forms.StatusStrip()
        Me.pbProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.layoutMain.SuspendLayout()
        Me.layoutTest.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.splitLiveMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitLiveMode.Panel1.SuspendLayout()
        Me.splitLiveMode.Panel2.SuspendLayout()
        Me.splitLiveMode.SuspendLayout()
        CType(Me.fgTestItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMain.SuspendLayout()
        Me.gbLiveDisplay.SuspendLayout()
        Me.layoutPhaseGroup.SuspendLayout()
        CType(Me.fgTestGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgTestPhases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.layoutTools.SuspendLayout()
        Me.gbAssemblyInfo.SuspendLayout()
        Me.layoutAssemblyInfo.SuspendLayout()
        Me.StatusStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslUserName, Me.tsslPCName, Me.tsslPlant, Me.tsslSAPFailSafeMode, Me.tsslDatabaseName})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 732)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslUserName
        '
        Me.tsslUserName.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslUserName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslUserName.Name = "tsslUserName"
        Me.tsslUserName.Size = New System.Drawing.Size(203, 19)
        Me.tsslUserName.Spring = True
        Me.tsslUserName.Text = "User: FENZHANG"
        '
        'tsslPCName
        '
        Me.tsslPCName.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslPCName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslPCName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslPCName.Name = "tsslPCName"
        Me.tsslPCName.Size = New System.Drawing.Size(203, 19)
        Me.tsslPCName.Spring = True
        Me.tsslPCName.Text = "PC Name: ASZ-BGRTPH2"
        '
        'tsslPlant
        '
        Me.tsslPlant.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslPlant.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslPlant.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslPlant.Name = "tsslPlant"
        Me.tsslPlant.Size = New System.Drawing.Size(203, 19)
        Me.tsslPlant.Spring = True
        Me.tsslPlant.Text = "Plant: ASZ"
        '
        'tsslSAPFailSafeMode
        '
        Me.tsslSAPFailSafeMode.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslSAPFailSafeMode.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslSAPFailSafeMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslSAPFailSafeMode.Name = "tsslSAPFailSafeMode"
        Me.tsslSAPFailSafeMode.Size = New System.Drawing.Size(203, 19)
        Me.tsslSAPFailSafeMode.Spring = True
        Me.tsslSAPFailSafeMode.Text = "SAPFailSafeMode: ON"
        '
        'tsslDatabaseName
        '
        Me.tsslDatabaseName.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslDatabaseName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslDatabaseName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslDatabaseName.Name = "tsslDatabaseName"
        Me.tsslDatabaseName.Size = New System.Drawing.Size(203, 19)
        Me.tsslDatabaseName.Spring = True
        Me.tsslDatabaseName.Text = "DB Name： S400PDB0001.FACTS"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslMode, Me.tsslTestType, Me.tsslInstrumentState, Me.tsslRetryCount, Me.tsslCycleTime})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 756)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(1034, 24)
        Me.StatusStrip2.TabIndex = 1
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'tsslMode
        '
        Me.tsslMode.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslMode.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslMode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslMode.Name = "tsslMode"
        Me.tsslMode.Size = New System.Drawing.Size(203, 19)
        Me.tsslMode.Spring = True
        Me.tsslMode.Text = "Mode: PROD"
        '
        'tsslTestType
        '
        Me.tsslTestType.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslTestType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tsslTestType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsslTestType.Name = "tsslTestType"
        Me.tsslTestType.Size = New System.Drawing.Size(203, 19)
        Me.tsslTestType.Spring = True
        Me.tsslTestType.Text = "Test Type"
        '
        'tsslInstrumentState
        '
        Me.tsslInstrumentState.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslInstrumentState.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslInstrumentState.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslInstrumentState.Name = "tsslInstrumentState"
        Me.tsslInstrumentState.Size = New System.Drawing.Size(203, 19)
        Me.tsslInstrumentState.Spring = True
        Me.tsslInstrumentState.Text = "Ready"
        '
        'tsslRetryCount
        '
        Me.tsslRetryCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslRetryCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslRetryCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tsslRetryCount.Name = "tsslRetryCount"
        Me.tsslRetryCount.Size = New System.Drawing.Size(203, 19)
        Me.tsslRetryCount.Spring = True
        Me.tsslRetryCount.Text = "Retry Count"
        '
        'tsslCycleTime
        '
        Me.tsslCycleTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslCycleTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tsslCycleTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsslCycleTime.Name = "tsslCycleTime"
        Me.tsslCycleTime.Size = New System.Drawing.Size(203, 19)
        Me.tsslCycleTime.Spring = True
        Me.tsslCycleTime.Text = "Cycle Time"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.UtilitiesToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1034, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.QuitToolStripMenuItem.Text = "&Quit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BenchSettingToolStripMenuItem, Me.ShowPFDetailToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'BenchSettingToolStripMenuItem
        '
        Me.BenchSettingToolStripMenuItem.Name = "BenchSettingToolStripMenuItem"
        Me.BenchSettingToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BenchSettingToolStripMenuItem.Text = "Bench Setting"
        '
        'ShowPFDetailToolStripMenuItem
        '
        Me.ShowPFDetailToolStripMenuItem.Name = "ShowPFDetailToolStripMenuItem"
        Me.ShowPFDetailToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ShowPFDetailToolStripMenuItem.Text = "Show PF Detail"
        '
        'UtilitiesToolStripMenuItem
        '
        Me.UtilitiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetupToolStripMenuItem, Me.ToolStripSeparator1, Me.MAP200LiveModeToolStripMenuItem, Me.StabilityMonitorToolStripMenuItem})
        Me.UtilitiesToolStripMenuItem.Name = "UtilitiesToolStripMenuItem"
        Me.UtilitiesToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.UtilitiesToolStripMenuItem.Text = "&Utilities"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SetupToolStripMenuItem.Text = "&Setup"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'MAP200LiveModeToolStripMenuItem
        '
        Me.MAP200LiveModeToolStripMenuItem.Name = "MAP200LiveModeToolStripMenuItem"
        Me.MAP200LiveModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.MAP200LiveModeToolStripMenuItem.Text = "MAP-200 Live Mode"
        '
        'StabilityMonitorToolStripMenuItem
        '
        Me.StabilityMonitorToolStripMenuItem.Name = "StabilityMonitorToolStripMenuItem"
        Me.StabilityMonitorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.StabilityMonitorToolStripMenuItem.Text = "Stability Monitor"
        Me.StabilityMonitorToolStripMenuItem.Visible = False
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'layoutMain
        '
        Me.layoutMain.ColumnCount = 1
        Me.layoutMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.Controls.Add(Me.TxtStatus, 0, 3)
        Me.layoutMain.Controls.Add(Me.layoutTest, 0, 2)
        Me.layoutMain.Controls.Add(Me.layoutTools, 0, 0)
        Me.layoutMain.Controls.Add(Me.gbAssemblyInfo, 0, 1)
        Me.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutMain.Location = New System.Drawing.Point(0, 24)
        Me.layoutMain.Name = "layoutMain"
        Me.layoutMain.RowCount = 4
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.layoutMain.Size = New System.Drawing.Size(1034, 708)
        Me.layoutMain.TabIndex = 28
        '
        'TxtStatus
        '
        Me.TxtStatus.AcceptsReturn = True
        Me.TxtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.TxtStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtStatus.Location = New System.Drawing.Point(3, 598)
        Me.TxtStatus.MaxLength = 0
        Me.TxtStatus.Multiline = True
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.ReadOnly = True
        Me.TxtStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtStatus.Size = New System.Drawing.Size(1028, 107)
        Me.TxtStatus.TabIndex = 10
        '
        'layoutTest
        '
        Me.layoutTest.ColumnCount = 2
        Me.layoutTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 322.0!))
        Me.layoutTest.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutTest.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.layoutTest.Controls.Add(Me.layoutPhaseGroup, 0, 0)
        Me.layoutTest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutTest.Location = New System.Drawing.Point(3, 186)
        Me.layoutTest.Name = "layoutTest"
        Me.layoutTest.RowCount = 1
        Me.layoutTest.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutTest.Size = New System.Drawing.Size(1028, 406)
        Me.layoutTest.TabIndex = 11
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.splitLiveMode, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(325, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(700, 400)
        Me.TableLayoutPanel2.TabIndex = 29
        '
        'splitLiveMode
        '
        Me.splitLiveMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.splitLiveMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitLiveMode.Location = New System.Drawing.Point(3, 3)
        Me.splitLiveMode.Name = "splitLiveMode"
        Me.splitLiveMode.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitLiveMode.Panel1
        '
        Me.splitLiveMode.Panel1.Controls.Add(Me.fgTestItems)
        '
        'splitLiveMode.Panel2
        '
        Me.splitLiveMode.Panel2.Controls.Add(Me.gbLiveDisplay)
        Me.splitLiveMode.Size = New System.Drawing.Size(694, 394)
        Me.splitLiveMode.SplitterDistance = 298
        Me.splitLiveMode.SplitterWidth = 5
        Me.splitLiveMode.TabIndex = 0
        '
        'fgTestItems
        '
        Me.fgTestItems.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.fgTestItems.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgTestItems.ColumnInfo = resources.GetString("fgTestItems.ColumnInfo")
        Me.fgTestItems.ContextMenuStrip = Me.cmsMain
        Me.fgTestItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgTestItems.ExtendLastCol = True
        Me.fgTestItems.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgTestItems.Location = New System.Drawing.Point(0, 0)
        Me.fgTestItems.Name = "fgTestItems"
        Me.fgTestItems.Rows.Count = 1
        Me.fgTestItems.Rows.DefaultSize = 19
        Me.fgTestItems.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgTestItems.Size = New System.Drawing.Size(692, 296)
        Me.fgTestItems.StyleInfo = resources.GetString("fgTestItems.StyleInfo")
        Me.fgTestItems.TabIndex = 28
        '
        'cmsMain
        '
        Me.cmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectAllToolStripMenuItem, Me.SelectNothingToolStripMenuItem, Me.ToolStripSeparator2, Me.UploadTestDataToolStripMenuItem})
        Me.cmsMain.Name = "cmsMain"
        Me.cmsMain.Size = New System.Drawing.Size(164, 76)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'SelectNothingToolStripMenuItem
        '
        Me.SelectNothingToolStripMenuItem.Name = "SelectNothingToolStripMenuItem"
        Me.SelectNothingToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SelectNothingToolStripMenuItem.Text = "Select Nothing"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(160, 6)
        '
        'UploadTestDataToolStripMenuItem
        '
        Me.UploadTestDataToolStripMenuItem.Name = "UploadTestDataToolStripMenuItem"
        Me.UploadTestDataToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.UploadTestDataToolStripMenuItem.Text = "Upload Test Data"
        '
        'gbLiveDisplay
        '
        Me.gbLiveDisplay.Controls.Add(Me.lblPower)
        Me.gbLiveDisplay.Controls.Add(Me.Label6)
        Me.gbLiveDisplay.Controls.Add(Me.lblWavelength)
        Me.gbLiveDisplay.Controls.Add(Me.lblORL)
        Me.gbLiveDisplay.Controls.Add(Me.Label8)
        Me.gbLiveDisplay.Controls.Add(Me.Label3)
        Me.gbLiveDisplay.Controls.Add(Me.lblChannel)
        Me.gbLiveDisplay.Controls.Add(Me.Label5)
        Me.gbLiveDisplay.Controls.Add(Me.lblIL)
        Me.gbLiveDisplay.Controls.Add(Me.Label2)
        Me.gbLiveDisplay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbLiveDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLiveDisplay.Location = New System.Drawing.Point(0, 0)
        Me.gbLiveDisplay.Name = "gbLiveDisplay"
        Me.gbLiveDisplay.Size = New System.Drawing.Size(692, 89)
        Me.gbLiveDisplay.TabIndex = 0
        Me.gbLiveDisplay.TabStop = False
        Me.gbLiveDisplay.Text = "Live Display"
        '
        'lblPower
        '
        Me.lblPower.AutoSize = True
        Me.lblPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPower.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPower.Location = New System.Drawing.Point(520, 60)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(39, 20)
        Me.lblPower.TabIndex = 1
        Me.lblPower.Text = "------"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(458, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Power:"
        '
        'lblWavelength
        '
        Me.lblWavelength.AutoSize = True
        Me.lblWavelength.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWavelength.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblWavelength.Location = New System.Drawing.Point(444, 23)
        Me.lblWavelength.Name = "lblWavelength"
        Me.lblWavelength.Size = New System.Drawing.Size(39, 20)
        Me.lblWavelength.TabIndex = 1
        Me.lblWavelength.Text = "------"
        '
        'lblORL
        '
        Me.lblORL.AutoSize = True
        Me.lblORL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORL.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblORL.Location = New System.Drawing.Point(322, 60)
        Me.lblORL.Name = "lblORL"
        Me.lblORL.Size = New System.Drawing.Size(39, 20)
        Me.lblORL.TabIndex = 1
        Me.lblORL.Text = "------"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(341, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Wavelength:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(270, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ORL:"
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChannel.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblChannel.Location = New System.Drawing.Point(254, 23)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(39, 20)
        Me.lblChannel.TabIndex = 1
        Me.lblChannel.Text = "------"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(176, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Channel:"
        '
        'lblIL
        '
        Me.lblIL.AutoSize = True
        Me.lblIL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIL.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIL.Location = New System.Drawing.Point(132, 60)
        Me.lblIL.Name = "lblIL"
        Me.lblIL.Size = New System.Drawing.Size(39, 20)
        Me.lblIL.TabIndex = 1
        Me.lblIL.Text = "------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(99, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "IL:"
        '
        'layoutPhaseGroup
        '
        Me.layoutPhaseGroup.ColumnCount = 1
        Me.layoutPhaseGroup.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutPhaseGroup.Controls.Add(Me.fgTestGroups, 0, 1)
        Me.layoutPhaseGroup.Controls.Add(Me.fgTestPhases, 0, 0)
        Me.layoutPhaseGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutPhaseGroup.Location = New System.Drawing.Point(3, 3)
        Me.layoutPhaseGroup.Name = "layoutPhaseGroup"
        Me.layoutPhaseGroup.RowCount = 2
        Me.layoutPhaseGroup.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.layoutPhaseGroup.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutPhaseGroup.Size = New System.Drawing.Size(316, 400)
        Me.layoutPhaseGroup.TabIndex = 27
        '
        'fgTestGroups
        '
        Me.fgTestGroups.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.fgTestGroups.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgTestGroups.ColumnInfo = resources.GetString("fgTestGroups.ColumnInfo")
        Me.fgTestGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgTestGroups.ExtendLastCol = True
        Me.fgTestGroups.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgTestGroups.Location = New System.Drawing.Point(3, 103)
        Me.fgTestGroups.Name = "fgTestGroups"
        Me.fgTestGroups.Rows.Count = 1
        Me.fgTestGroups.Rows.DefaultSize = 19
        Me.fgTestGroups.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgTestGroups.Size = New System.Drawing.Size(310, 294)
        Me.fgTestGroups.StyleInfo = resources.GetString("fgTestGroups.StyleInfo")
        Me.fgTestGroups.TabIndex = 25
        '
        'fgTestPhases
        '
        Me.fgTestPhases.AllowEditing = False
        Me.fgTestPhases.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
        Me.fgTestPhases.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgTestPhases.ColumnInfo = resources.GetString("fgTestPhases.ColumnInfo")
        Me.fgTestPhases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgTestPhases.ExtendLastCol = True
        Me.fgTestPhases.HighLight = C1.Win.C1FlexGrid.HighLightEnum.WithFocus
        Me.fgTestPhases.Location = New System.Drawing.Point(3, 3)
        Me.fgTestPhases.Name = "fgTestPhases"
        Me.fgTestPhases.Rows.Count = 1
        Me.fgTestPhases.Rows.DefaultSize = 19
        Me.fgTestPhases.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.fgTestPhases.Size = New System.Drawing.Size(310, 94)
        Me.fgTestPhases.StyleInfo = resources.GetString("fgTestPhases.StyleInfo")
        Me.fgTestPhases.TabIndex = 26
        '
        'layoutTools
        '
        Me.layoutTools.ColumnCount = 8
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 327.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.layoutTools.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutTools.Controls.Add(Me.Label1, 0, 1)
        Me.layoutTools.Controls.Add(Me.txtSN2, 1, 1)
        Me.layoutTools.Controls.Add(Me.Label7, 0, 0)
        Me.layoutTools.Controls.Add(Me.txtSN1, 1, 0)
        Me.layoutTools.Controls.Add(Me.Label4, 2, 0)
        Me.layoutTools.Controls.Add(Me.TxtPN, 3, 0)
        Me.layoutTools.Controls.Add(Me.CmdCAL, 4, 0)
        Me.layoutTools.Controls.Add(Me.CmdRunAll, 5, 0)
        Me.layoutTools.Controls.Add(Me.CmdAbort, 6, 0)
        Me.layoutTools.Controls.Add(Me.ckLoadTestData, 7, 0)
        Me.layoutTools.Controls.Add(Me.ckLoadPFQ, 7, 1)
        Me.layoutTools.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutTools.Location = New System.Drawing.Point(3, 3)
        Me.layoutTools.Name = "layoutTools"
        Me.layoutTools.RowCount = 2
        Me.layoutTools.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutTools.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.layoutTools.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.layoutTools.Size = New System.Drawing.Size(1028, 59)
        Me.layoutTools.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(3, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(44, 30)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "SN 2"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSN2
        '
        Me.txtSN2.AcceptsReturn = True
        Me.txtSN2.BackColor = System.Drawing.SystemColors.Window
        Me.txtSN2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSN2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSN2.Enabled = False
        Me.txtSN2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSN2.Location = New System.Drawing.Point(53, 32)
        Me.txtSN2.MaxLength = 0
        Me.txtSN2.Name = "txtSN2"
        Me.txtSN2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSN2.Size = New System.Drawing.Size(227, 22)
        Me.txtSN2.TabIndex = 2
        Me.txtSN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 29)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "SN 1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSN1
        '
        Me.txtSN1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSN1.Enabled = False
        Me.txtSN1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.txtSN1.Location = New System.Drawing.Point(53, 3)
        Me.txtSN1.Name = "txtSN1"
        Me.txtSN1.Size = New System.Drawing.Size(227, 22)
        Me.txtSN1.TabIndex = 1
        Me.txtSN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(286, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(38, 29)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "PN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPN
        '
        Me.TxtPN.AcceptsReturn = True
        Me.TxtPN.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtPN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtPN.Enabled = False
        Me.TxtPN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPN.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtPN.Location = New System.Drawing.Point(330, 3)
        Me.TxtPN.MaxLength = 0
        Me.TxtPN.Name = "TxtPN"
        Me.TxtPN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPN.Size = New System.Drawing.Size(321, 22)
        Me.TxtPN.TabIndex = 3
        Me.TxtPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CmdCAL
        '
        Me.CmdCAL.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCAL.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdCAL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmdCAL.Enabled = False
        Me.CmdCAL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCAL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdCAL.Location = New System.Drawing.Point(657, 3)
        Me.CmdCAL.Name = "CmdCAL"
        Me.CmdCAL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdCAL.Size = New System.Drawing.Size(79, 23)
        Me.CmdCAL.TabIndex = 5
        Me.CmdCAL.Text = "&Calibrate(F3)"
        Me.CmdCAL.UseVisualStyleBackColor = False
        '
        'CmdRunAll
        '
        Me.CmdRunAll.BackColor = System.Drawing.SystemColors.Control
        Me.CmdRunAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdRunAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmdRunAll.Enabled = False
        Me.CmdRunAll.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdRunAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdRunAll.Location = New System.Drawing.Point(742, 3)
        Me.CmdRunAll.Name = "CmdRunAll"
        Me.CmdRunAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdRunAll.Size = New System.Drawing.Size(79, 23)
        Me.CmdRunAll.TabIndex = 4
        Me.CmdRunAll.Text = "&Run (F2)"
        Me.CmdRunAll.UseVisualStyleBackColor = False
        '
        'CmdAbort
        '
        Me.CmdAbort.BackColor = System.Drawing.SystemColors.Control
        Me.CmdAbort.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdAbort.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CmdAbort.Enabled = False
        Me.CmdAbort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAbort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdAbort.Location = New System.Drawing.Point(827, 3)
        Me.CmdAbort.Name = "CmdAbort"
        Me.CmdAbort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdAbort.Size = New System.Drawing.Size(78, 23)
        Me.CmdAbort.TabIndex = 6
        Me.CmdAbort.Text = "&Abort Test"
        Me.CmdAbort.UseVisualStyleBackColor = False
        '
        'ckLoadTestData
        '
        Me.ckLoadTestData.AutoSize = True
        Me.ckLoadTestData.Checked = True
        Me.ckLoadTestData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckLoadTestData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckLoadTestData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckLoadTestData.Location = New System.Drawing.Point(911, 3)
        Me.ckLoadTestData.Name = "ckLoadTestData"
        Me.ckLoadTestData.Size = New System.Drawing.Size(114, 23)
        Me.ckLoadTestData.TabIndex = 7
        Me.ckLoadTestData.Text = "Load Test Data"
        Me.ckLoadTestData.UseVisualStyleBackColor = True
        '
        'ckLoadPFQ
        '
        Me.ckLoadPFQ.AutoSize = True
        Me.ckLoadPFQ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ckLoadPFQ.Location = New System.Drawing.Point(911, 32)
        Me.ckLoadPFQ.Name = "ckLoadPFQ"
        Me.ckLoadPFQ.Size = New System.Drawing.Size(114, 24)
        Me.ckLoadPFQ.TabIndex = 22
        Me.ckLoadPFQ.Text = "Load PFQ"
        Me.ckLoadPFQ.UseVisualStyleBackColor = True
        '
        'gbAssemblyInfo
        '
        Me.gbAssemblyInfo.Controls.Add(Me.layoutAssemblyInfo)
        Me.gbAssemblyInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbAssemblyInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAssemblyInfo.Location = New System.Drawing.Point(3, 68)
        Me.gbAssemblyInfo.Name = "gbAssemblyInfo"
        Me.gbAssemblyInfo.Size = New System.Drawing.Size(1028, 112)
        Me.gbAssemblyInfo.TabIndex = 13
        Me.gbAssemblyInfo.TabStop = False
        Me.gbAssemblyInfo.Text = "Assembly Information"
        '
        'layoutAssemblyInfo
        '
        Me.layoutAssemblyInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.layoutAssemblyInfo.ColumnCount = 6
        Me.layoutAssemblyInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.layoutAssemblyInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.layoutAssemblyInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140.0!))
        Me.layoutAssemblyInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.layoutAssemblyInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.layoutAssemblyInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 348.0!))
        Me.layoutAssemblyInfo.Controls.Add(Me.Label9, 0, 0)
        Me.layoutAssemblyInfo.Controls.Add(Me.lbl1500Connector, 1, 0)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label10, 2, 0)
        Me.layoutAssemblyInfo.Controls.Add(Me.lbl1501Connector, 3, 0)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label11, 4, 0)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblSubunits, 5, 0)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label13, 0, 1)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label15, 2, 1)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label16, 4, 1)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblLength, 3, 1)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblDescription, 5, 1)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblFiberPerSubunit, 1, 1)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label18, 0, 2)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label14, 2, 2)
        Me.layoutAssemblyInfo.Controls.Add(Me.Label17, 4, 2)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblWO, 1, 2)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblTotal, 3, 2)
        Me.layoutAssemblyInfo.Controls.Add(Me.lblPF, 5, 2)
        Me.layoutAssemblyInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.layoutAssemblyInfo.Location = New System.Drawing.Point(3, 18)
        Me.layoutAssemblyInfo.Name = "layoutAssemblyInfo"
        Me.layoutAssemblyInfo.RowCount = 3
        Me.layoutAssemblyInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.layoutAssemblyInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.layoutAssemblyInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.layoutAssemblyInfo.Size = New System.Drawing.Size(1022, 91)
        Me.layoutAssemblyInfo.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 30)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "1500 Connector_A:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl1500Connector
        '
        Me.lbl1500Connector.AutoSize = True
        Me.lbl1500Connector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl1500Connector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1500Connector.Location = New System.Drawing.Point(145, 1)
        Me.lbl1500Connector.Name = "lbl1500Connector"
        Me.lbl1500Connector.Size = New System.Drawing.Size(144, 30)
        Me.lbl1500Connector.TabIndex = 1
        Me.lbl1500Connector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(296, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 30)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "1501 Connector_B:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl1501Connector
        '
        Me.lbl1501Connector.AutoSize = True
        Me.lbl1501Connector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl1501Connector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1501Connector.Location = New System.Drawing.Point(437, 1)
        Me.lbl1501Connector.Name = "lbl1501Connector"
        Me.lbl1501Connector.Size = New System.Drawing.Size(144, 30)
        Me.lbl1501Connector.TabIndex = 1
        Me.lbl1501Connector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(588, 1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 30)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Subunits:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSubunits
        '
        Me.lblSubunits.AutoSize = True
        Me.lblSubunits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSubunits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubunits.Location = New System.Drawing.Point(719, 1)
        Me.lblSubunits.Name = "lblSubunits"
        Me.lblSubunits.Size = New System.Drawing.Size(342, 30)
        Me.lblSubunits.TabIndex = 0
        Me.lblSubunits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 30)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fiber per Subunit:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(296, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(134, 30)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Length(m):"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(588, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(124, 30)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Description:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLength
        '
        Me.lblLength.AutoSize = True
        Me.lblLength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLength.Location = New System.Drawing.Point(437, 32)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(144, 30)
        Me.lblLength.TabIndex = 2
        Me.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(719, 32)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(342, 30)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFiberPerSubunit
        '
        Me.lblFiberPerSubunit.AutoSize = True
        Me.lblFiberPerSubunit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFiberPerSubunit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiberPerSubunit.Location = New System.Drawing.Point(145, 32)
        Me.lblFiberPerSubunit.Name = "lblFiberPerSubunit"
        Me.lblFiberPerSubunit.Size = New System.Drawing.Size(144, 30)
        Me.lblFiberPerSubunit.TabIndex = 0
        Me.lblFiberPerSubunit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label18.Location = New System.Drawing.Point(4, 63)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(134, 27)
        Me.Label18.TabIndex = 3
        Me.Label18.Text = "Work Order Number:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label14.Location = New System.Drawing.Point(296, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(134, 27)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Total Test:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label17.Location = New System.Drawing.Point(588, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 27)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Pass/Fail:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWO
        '
        Me.lblWO.AutoSize = True
        Me.lblWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblWO.Location = New System.Drawing.Point(145, 63)
        Me.lblWO.Name = "lblWO"
        Me.lblWO.Size = New System.Drawing.Size(144, 27)
        Me.lblWO.TabIndex = 5
        Me.lblWO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.Location = New System.Drawing.Point(437, 63)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(144, 27)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPF
        '
        Me.lblPF.AutoSize = True
        Me.lblPF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPF.Location = New System.Drawing.Point(719, 63)
        Me.lblPF.Name = "lblPF"
        Me.lblPF.Size = New System.Drawing.Size(342, 27)
        Me.lblPF.TabIndex = 5
        Me.lblPF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'StatusStrip3
        '
        Me.StatusStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbProgress})
        Me.StatusStrip3.Location = New System.Drawing.Point(0, 780)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.Size = New System.Drawing.Size(1034, 25)
        Me.StatusStrip3.TabIndex = 29
        Me.StatusStrip3.Text = "StatusStrip3"
        '
        'pbProgress
        '
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(1010, 19)
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'FormGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 805)
        Me.Controls.Add(Me.layoutMain)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormGUI"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.layoutMain.ResumeLayout(False)
        Me.layoutMain.PerformLayout()
        Me.layoutTest.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.splitLiveMode.Panel1.ResumeLayout(False)
        Me.splitLiveMode.Panel2.ResumeLayout(False)
        CType(Me.splitLiveMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitLiveMode.ResumeLayout(False)
        CType(Me.fgTestItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMain.ResumeLayout(False)
        Me.gbLiveDisplay.ResumeLayout(False)
        Me.gbLiveDisplay.PerformLayout()
        Me.layoutPhaseGroup.ResumeLayout(False)
        CType(Me.fgTestGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgTestPhases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.layoutTools.ResumeLayout(False)
        Me.layoutTools.PerformLayout()
        Me.gbAssemblyInfo.ResumeLayout(False)
        Me.layoutAssemblyInfo.ResumeLayout(False)
        Me.layoutAssemblyInfo.PerformLayout()
        Me.StatusStrip3.ResumeLayout(False)
        Me.StatusStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslUserName As ToolStripStatusLabel
    Friend WithEvents tsslPCName As ToolStripStatusLabel
    Friend WithEvents tsslPlant As ToolStripStatusLabel
    Friend WithEvents tsslSAPFailSafeMode As ToolStripStatusLabel
    Friend WithEvents tsslDatabaseName As ToolStripStatusLabel
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents tsslMode As ToolStripStatusLabel
    Friend WithEvents tsslCycleTime As ToolStripStatusLabel
    Friend WithEvents tsslInstrumentState As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BenchSettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UtilitiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MAP200LiveModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StabilityMonitorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents layoutMain As TableLayoutPanel
    Public WithEvents TxtStatus As TextBox
    Friend WithEvents layoutTest As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents layoutPhaseGroup As TableLayoutPanel
    Friend WithEvents fgTestGroups As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgTestPhases As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents layoutTools As TableLayoutPanel
    Public WithEvents TxtPN As TextBox
    Public WithEvents Label1 As Label
    Public WithEvents Label4 As Label
    Public WithEvents CmdCAL As Button
    Public WithEvents txtSN2 As TextBox
    Public WithEvents CmdRunAll As Button
    Public WithEvents CmdAbort As Button
    Friend WithEvents ckLoadTestData As CheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents splitLiveMode As SplitContainer
    Friend WithEvents fgTestItems As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents gbLiveDisplay As GroupBox
    Friend WithEvents lblIL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPower As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblORL As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblWavelength As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblChannel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSN1 As TextBox
    Friend WithEvents cmsMain As ContextMenuStrip
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectNothingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents UploadTestDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsslTestType As ToolStripStatusLabel
    Friend WithEvents gbAssemblyInfo As GroupBox
    Friend WithEvents layoutAssemblyInfo As TableLayoutPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents lbl1500Connector As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl1501Connector As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblSubunits As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblFiberPerSubunit As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblLength As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblWO As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblPF As Label
    Friend WithEvents tsslRetryCount As ToolStripStatusLabel
    Friend WithEvents StatusStrip3 As StatusStrip
    Friend WithEvents pbProgress As ToolStripProgressBar
    Friend WithEvents ckLoadPFQ As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ShowPFDetailToolStripMenuItem As ToolStripMenuItem
End Class
