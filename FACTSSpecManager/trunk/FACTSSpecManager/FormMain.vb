Imports System
Imports System.Enum
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Reflection

Public Class FormMain

#Region "UserFunction"

    Private WriteOnly Property UManager As Boolean
        Set(value As Boolean)
            UManagerToolStripMenuItem.Enabled = value
        End Set
    End Property
    Private WriteOnly Property UPermission As Boolean
        Set(value As Boolean)
            UPrivilegeToolStripMenuItem.Enabled = value
        End Set
    End Property
    Private WriteOnly Property MProfile As Boolean
        Set(value As Boolean)
            MProfileToolStripMenuItem.Enabled = value
        End Set
    End Property
    Private WriteOnly Property MConnectorType As Boolean
        Set(value As Boolean)
            mnuConnectorTypeMaintain.Enabled = value
        End Set
    End Property
    Private WriteOnly Property MMode As Boolean
        Set(value As Boolean)
            MModeToolStripMenuItem.Enabled = value
        End Set
    End Property
    Private WriteOnly Property MSPEC As Boolean
        Set(value As Boolean)
            MSpecToolStripMenuItem.Enabled = value
        End Set
    End Property
    Private WriteOnly Property MBulkCopy As Boolean
        Set(value As Boolean)
            BulkCopyToolStripMenuItem.Enabled = value
        End Set
    End Property
    'Private WriteOnly Property MSPIM As Boolean
    '	Set(value As Boolean)
    '		MSPIMToolStripMenuItem.Enabled = value
    '	End Set
    'End Property
    Private Function GetUserLevels() As List(Of emUserLevel)
        Try
            Dim resp As New List(Of emUserLevel)

            Dim um As String
            Dim msg As String

            um = Environment.UserName.ToString.ToUpper
            msg = "USER:" & um & "["

            Dim cqefBll As New FACTS.BLL.cq_employee_funcManager
            Dim cqefML As List(Of FACTS.Model.cq_employee_func)

            cqefML = cqefBll.SelectAllByLoginName(um)
            If cqefML Is Nothing Then
                resp.Add(emUserLevel.NULL_USER)
                UserNameToolStripStatusLabel.Text = msg + " No authorization] "
                UserNameToolStripStatusLabel.BackColor = Color.Red
                Return resp
            End If

            For Each cqefM In cqefML

                resp.Add([Enum].Parse(GetType(emUserLevel), cqefM.M_func_main.name))
                msg += cqefM.M_func_main.name.ToString & " "

            Next
            msg = msg.TrimEnd()
            msg += "]"
            UserNameToolStripStatusLabel.Text = msg
            UserNameToolStripStatusLabel.BackColor = Color.White
            Return resp


        Catch ex As Exception
            Throw New Exception("GetUserLevels()::" & ex.Message)
        End Try

    End Function
    Private Sub SetUserFunction(ul As emUserLevel)
        Try

            Select Case ul
                Case emUserLevel.ADMIN_USER
                    UManager = True
                    UPermission = True
                    MConnectorType = True
                    MProfile = True
                    MMode = True
                    MSPEC = True
                    MBulkCopy = True
                Case emUserLevel.M_PROD_USER
                    MProfile = True
                Case emUserLevel.M_MODE_USER
                    MMode = True
                Case emUserLevel.M_SPEC_ADMIN_USER
                    MSPEC = True
                    'Case emUserLevel.M_SPEC_SPARA_USER
                    '	MSRLISO = True
                    'Case emUserLevel.M_SPEC_PIM_USER
                    '	MSPIM = True


            End Select
        Catch ex As Exception
            Throw New Exception("SetUserFunction()::" & ex.Message)
        End Try
    End Sub
    Private Sub SetUserFunctions(ulL As List(Of emUserLevel))
        Try
            UManager = False
            UPermission = False
            MConnectorType = False
            MProfile = False
            MMode = False
            MSPEC = False
            MBulkCopy = False

            For Each ul In ulL
                SetUserFunction(ul)
            Next

        Catch ex As Exception
            Throw New Exception("SetUserFunctions()::" & ex.Message)
        End Try
    End Sub
#End Region
    Private Sub SetFormSkin()
        Try
            'DiamondBlue.ssk

            Dim skinfile As String = "MacOS.ssk"
            Dim skin As New Sunisoft.IrisSkin.SkinEngine
            skin.SkinFile = Application.StartupPath & "\" & skinfile
            skin.Active = True

        Catch ex As Exception
            Throw New Exception("FormSkin()::" & ex.Message)
        End Try
    End Sub
    Private Sub AutoUpdate()
        Try
            Dim svrPath As String
            svrPath = My.Settings.UpdatePath
            If svrPath.EndsWith("\") = False Then svrPath += "\"

            Dim locPath As String = Application.StartupPath
            If locPath.EndsWith("\") = False Then locPath += "\"

            Dim updateFile = "FACTSUpdate.exe"
            If IO.File.Exists(svrPath & updateFile) = True Then
                FileCopy(svrPath & updateFile, locPath & updateFile)
            End If

            Dim appName As String = Application.ProductName

            Dim svrVersion As String = FileVersionInfo.GetVersionInfo(svrPath & appName & ".exe").ProductVersion
            Dim locVersion As String = Application.ProductVersion

            Dim svrVer As New Version(svrVersion)
            Dim locVer As New Version(locVersion)

            'If svrVersion > locVersion Then
            If svrVer.CompareTo(locVer) > 0 Then
                MsgBox("Found the new version , the software will automatically update!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Shell(locPath & "FACTSUpdate.exe " & svrPath, False)
                End
            End If

        Catch ex As Exception
            Throw New Exception("AutoUpdate()::" & ex.Message)
        End Try
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'SetFormSkin()

            Me.Text = gMyApplicationCaption
            Me.WindowState = FormWindowState.Maximized
            Me.Show()
            My.Application.DoEvents()

            AutoUpdate()

            Dim frm As New FormLogin
            frm.ShowDialog()

            pUserLevelList = GetUserLevels()
            SetUserFunctions(pUserLevelList)

        Catch ex As Exception
            MsgBox("CATSConsole Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End
        End Try
    End Sub
    Private Function OpenOnce(formName As String) As Boolean
        Try
            For Each form In Me.MdiChildren
                If form.Name = formName Then
                    form.Activate()
                    form.WindowState = FormWindowState.Maximized
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
            MsgBox("CATSConsole.OpenOnce()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Function
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MProfileToolStripMenuItem.Click
        If Not OpenOnce("FormPRProfile") Then
            FormPRProfile.Show()
            FormPRProfile.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub MModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MModeToolStripMenuItem.Click
        If Not OpenOnce("FormPRMode") Then
            FormPRMode.Show()
        End If
    End Sub

    Private Sub MSpecToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MSpecToolStripMenuItem.Click

    End Sub
    Private Sub FModeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'FormSYMode.Show()
    End Sub

    Private Sub UPrivilegeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPrivilegeToolStripMenuItem.Click
        FormUSPrivilege.Show()
    End Sub

    Private Sub MSRLISOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MSRLILToolStripMenuItem.Click
        If Not OpenOnce("FormPRSPRLIL") Then
            FormPRSPRLIL.Show()
            FormPRSPRLIL.WindowState = FormWindowState.Maximized
        End If
    End Sub
    Private Sub CrossModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrossModeToolStripMenuItem.Click
        FormPRBCCrossMode.Show()
    End Sub

    Private Sub CrossSystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrossSystemToolStripMenuItem.Click
        'FormPRBCCrossSystem.Show()
    End Sub

    Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem.Click
        'FormPRBCCrossSystemCustom.Show()
    End Sub

    Private Sub BatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem.Click
        'FormPRBCCrossSystem.Show()
    End Sub

    Private Sub UManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UManagerToolStripMenuItem.Click
        FormUSManager.Show()
    End Sub

    Private Sub mnuSwitchDatabase_Click(sender As Object, e As EventArgs) Handles CrossProductToolStripMenuItem.Click
        FormPRBCCrossProduct.Show()
    End Sub

    Private Sub SwitchDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSwitchDatabase.Click
        Try
            For Each form In Me.MdiChildren
                form.Close()
            Next
            Dim frm As New FormLogin
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox("FormMain.SwitchDatabaseToolStripMenuItem_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub mnuConnectorTypeMaintain_Click(sender As Object, e As EventArgs) Handles mnuConnectorTypeMaintain.Click
        Dim frmConnectorType As New FormConnectorType
        frmConnectorType.ShowDialog()
    End Sub

    Private Sub mnuFiberCableILLimitMaintain_Click(sender As Object, e As EventArgs) Handles mnuFiberCableILLimitMaintain.Click
        Dim frmFiberCableIL As New FormFiberCableIL
        frmFiberCableIL.ShowDialog()
    End Sub

    Private Sub menuConnectorSpec_Click(sender As Object, e As EventArgs) Handles menuConnectorSpec.Click
        Dim frmConnectorSpec As New FormConnectorSpecDetail
        frmConnectorSpec.ShowDialog()
    End Sub
End Class