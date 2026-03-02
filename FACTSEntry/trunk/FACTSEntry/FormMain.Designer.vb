<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup(" ●  Local Test System", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("●  CATS Test Application", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.lvAppList = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnRun = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lkbStatus = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.lkbUser = New System.Windows.Forms.LinkLabel()
        Me.lkbPC = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lkbMode = New System.Windows.Forms.LinkLabel()
        Me.lkbFactory = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.proSync = New System.Windows.Forms.ProgressBar()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvAppList
        '
        Me.lvAppList.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.lvAppList.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvAppList.Alignment = System.Windows.Forms.ListViewAlignment.Left
        Me.lvAppList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvAppList.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lvAppList.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAppList.ForeColor = System.Drawing.Color.Black
        Me.lvAppList.FullRowSelect = True
        ListViewGroup1.Header = " ●  Local Test System"
        ListViewGroup1.Name = "lvgSystem"
        ListViewGroup2.Header = "●  CATS Test Application"
        ListViewGroup2.Name = "lvgTestApplication"
        Me.lvAppList.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        Me.lvAppList.HideSelection = False
        Me.lvAppList.LabelWrap = False
        Me.lvAppList.LargeImageList = Me.ImageList1
        Me.lvAppList.Location = New System.Drawing.Point(6, 44)
        Me.lvAppList.MultiSelect = False
        Me.lvAppList.Name = "lvAppList"
        Me.lvAppList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lvAppList.Scrollable = False
        Me.lvAppList.ShowGroups = False
        Me.lvAppList.ShowItemToolTips = True
        Me.lvAppList.Size = New System.Drawing.Size(281, 342)
        Me.lvAppList.TabIndex = 1
        Me.lvAppList.UseCompatibleStateImageBehavior = False
        Me.lvAppList.View = System.Windows.Forms.View.Tile
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "setting_48px.png")
        Me.ImageList1.Images.SetKeyName(1, "fiber-64.ico")
        Me.ImageList1.Images.SetKeyName(2, "setting_32px.png")
        '
        'btnRun
        '
        Me.btnRun.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRun.Location = New System.Drawing.Point(262, 465)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(105, 30)
        Me.btnRun.TabIndex = 2
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(98, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(284, 28)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "FACTS Test System Entry"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.lkbStatus)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnSetting)
        Me.GroupBox1.Controls.Add(Me.lkbUser)
        Me.GroupBox1.Controls.Add(Me.lkbPC)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lkbMode)
        Me.GroupBox1.Controls.Add(Me.lkbFactory)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 433)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current System Setting"
        '
        'lkbStatus
        '
        Me.lkbStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkbStatus.ForeColor = System.Drawing.Color.Blue
        Me.lkbStatus.LinkColor = System.Drawing.Color.Black
        Me.lkbStatus.Location = New System.Drawing.Point(112, 75)
        Me.lkbStatus.Name = "lkbStatus"
        Me.lkbStatus.Size = New System.Drawing.Size(90, 16)
        Me.lkbStatus.TabIndex = 14
        Me.lkbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Running status:"
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(12, 24)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(206, 26)
        Me.btnSetting.TabIndex = 12
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'lkbUser
        '
        Me.lkbUser.AutoSize = True
        Me.lkbUser.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkbUser.ForeColor = System.Drawing.Color.Blue
        Me.lkbUser.LinkColor = System.Drawing.Color.Black
        Me.lkbUser.Location = New System.Drawing.Point(93, 143)
        Me.lkbUser.Name = "lkbUser"
        Me.lkbUser.Size = New System.Drawing.Size(0, 16)
        Me.lkbUser.TabIndex = 11
        Me.lkbUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lkbPC
        '
        Me.lkbPC.AutoSize = True
        Me.lkbPC.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkbPC.ForeColor = System.Drawing.Color.Blue
        Me.lkbPC.LinkColor = System.Drawing.Color.Black
        Me.lkbPC.Location = New System.Drawing.Point(93, 109)
        Me.lkbPC.Name = "lkbPC"
        Me.lkbPC.Size = New System.Drawing.Size(0, 16)
        Me.lkbPC.TabIndex = 10
        Me.lkbPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Login User:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "PC Name:"
        '
        'lkbMode
        '
        Me.lkbMode.AutoSize = True
        Me.lkbMode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkbMode.ForeColor = System.Drawing.Color.Blue
        Me.lkbMode.LinkColor = System.Drawing.Color.Black
        Me.lkbMode.Location = New System.Drawing.Point(93, 211)
        Me.lkbMode.Name = "lkbMode"
        Me.lkbMode.Size = New System.Drawing.Size(0, 16)
        Me.lkbMode.TabIndex = 3
        Me.lkbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lkbFactory
        '
        Me.lkbFactory.AutoSize = True
        Me.lkbFactory.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkbFactory.ForeColor = System.Drawing.Color.Blue
        Me.lkbFactory.LinkColor = System.Drawing.Color.Black
        Me.lkbFactory.Location = New System.Drawing.Point(93, 177)
        Me.lkbFactory.Name = "lkbFactory"
        Me.lkbFactory.Size = New System.Drawing.Size(0, 16)
        Me.lkbFactory.TabIndex = 2
        Me.lkbFactory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 211)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Mode:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Factory:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.proSync)
        Me.GroupBox2.Controls.Add(Me.lvAppList)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(242, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 392)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Launch Test Application"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Syncing:"
        '
        'proSync
        '
        Me.proSync.Location = New System.Drawing.Point(70, 24)
        Me.proSync.Name = "proSync"
        Me.proSync.Size = New System.Drawing.Size(217, 14)
        Me.proSync.TabIndex = 7
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(413, 465)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(105, 30)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblVersion.Location = New System.Drawing.Point(486, 44)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(43, 15)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "xx.xx.xx"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(547, 507)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRun)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvAppList As System.Windows.Forms.ListView
  Friend WithEvents btnRun As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents lkbMode As System.Windows.Forms.LinkLabel
  Friend WithEvents lkbFactory As System.Windows.Forms.LinkLabel
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents lkbUser As System.Windows.Forms.LinkLabel
	Friend WithEvents lkbPC As System.Windows.Forms.LinkLabel
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents btnExit As System.Windows.Forms.Button
	Friend WithEvents proSync As System.Windows.Forms.ProgressBar
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents btnSetting As Button
	Friend WithEvents lkbStatus As LinkLabel
	Friend WithEvents Label7 As Label
	Friend WithEvents lblVersion As Label
End Class
