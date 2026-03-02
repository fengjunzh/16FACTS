Imports System.Text.RegularExpressions

Public Class TestPlan
    Private GUI As FormGUI
    Public Sub InitializeGui()
        Try
            GUI = New FormGUI

            Dim folder As String = My.Application.Info.DirectoryPath
            Environment.CurrentDirectory = folder

            '    With My.Application.Info.Version
            '        SW_Version = String.Format("{0}.{1}.{2}.{3}", .Major, .Minor, .Build, .Revision)
            '    End With
            '    GUI.SW_Name = "S Parameter"
            '    GUI.SW_Version = SW_Version
            '    GUI.INI_File = String.Format("{0}\CATS SPara.ini", Application.StartupPath)
            '    GUI.repeatEnabled = False

            '    GUI.DefineToolsMenu("Bench Setting")
            '    GUI.DefineToolsMenu("View Traces")
            '    GUI.DefineToolsMenu("View Debug Report")
            '    GUI.DefineToolsMenu("Debug Tools")
            '    GUI.DefineToolsMenu("Unit History")
            '    GUI.DefineToolsMenu("MII")
            '    GUI.CalButtonVisable = True
            '    GUI.ShowInterface()
            '    If My.Computer.FileSystem.DirectoryExists(gCfgFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(gCfgFolder)
            '    End If

            '    Dim cfgfile As String = String.Format("{0}\{1}", gCfgFolder, ConnFile)

            '    Dim src_connfile As New CATS_XML(ConnFile)
            '    Dim dest_connfile As New CATS_XML(cfgfile)

            '    If src_connfile > dest_connfile AndAlso My.Computer.FileSystem.FileExists(ConnFile) Then
            '        File.Copy(ConnFile, cfgfile, True)
            '    End If

            '    If My.Computer.FileSystem.DirectoryExists(RetConfigFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(RetConfigFolder)
            '    End If

            '    If My.Computer.FileSystem.FileExists(cfgfile) = False Then
            '        Throw New Exception(String.Format("The file '{0}' not found!", ConnFile))
            '    End If

            '    dest_connfile = Nothing
            '    dest_connfile = New CATS_XML(cfgfile)
            '    ConnStr = dest_connfile.ConnString
            '    gConnStr = ConnStr

            '    Dim serverName As String = String.Empty
            '    Dim database As String = String.Empty
            '    Dim reg As Regex = New Regex("Data Source=(\S+)")
            '    Dim match As Match = reg.Match(ConnStr.Split(";")(0))
            '    If match.Success Then serverName = match.Groups(1).Value.ToUpper
            '    reg = New Regex("Initial Catalog=(\S+)")
            '    match = reg.Match(ConnStr.Split(";")(1))
            '    If match.Success Then database = match.Groups(1).Value.ToUpper
            '    GUI.DatabaseName = String.Format("{0}_{1}", serverName, database)

            '    Dim CatsConn As New CATS.BLL.CATSManager
            '    CatsConn.ActivateCATS(ConnStr)

            '    factoryName = dest_connfile.Location

            '    Dim factoryM As CATS.Model.factory
            '    Dim factoryBll As New CATS.BLL.factoryManager
            '    factoryM = factoryBll.SelectByFactory(factoryName)
            '    GUI.PlantCode = factoryM.code
            '    gPlantCode = [Enum].Parse(GetType(numPlantCode), factoryM.code)

            '    'VersionControl()

            '    If My.Computer.FileSystem.DirectoryExists(DataFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(DataFolder)
            '    End If

            '    If My.Computer.FileSystem.DirectoryExists(gCalFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(gCalFolder)
            '    End If

            '    If My.Computer.FileSystem.DirectoryExists(SnPFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(SnPFolder)
            '    End If

            '    If My.Computer.FileSystem.DirectoryExists(LocalSpecFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(LocalSpecFolder)
            '    End If

            '    If My.Computer.FileSystem.DirectoryExists(gAntSwmPortMappingFolder) = False Then
            '        My.Computer.FileSystem.CreateDirectory(gAntSwmPortMappingFolder)
            '    End If

            '    Dim localCalFolder As String = String.Format("{0}\CalData", My.Application.Info.DirectoryPath)
            '    If My.Computer.FileSystem.DirectoryExists(localCalFolder) Then
            '        My.Computer.FileSystem.CopyDirectory(localCalFolder, gCalFolder, True)
            '        My.Computer.FileSystem.DeleteDirectory(localCalFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
            '    End If

            '    GUI.AntSwmPortMappingPath = gAntSwmPortMappingFolder

            '    factoryName = dest_connfile.Location

            '    BenchSetting = CBenchSetting.CreateInstance(SettingFileName)
            '    If BenchSetting Is Nothing Then
            '        Dim BenSet As New FormBench(SettingFileName)
            '        BenSet.ShowDialog()
            '    End If

            '    BenchSetting = CBenchSetting.CreateInstance(SettingFileName)
            '    gBenchSetting = BenchSetting
            '    If BenchSetting IsNot Nothing Then
            '        GUI.ModeName = BenchSetting.TestMode
            '        GUI.MiiStatus = BenchSetting.MiiOnLine
            '        GUI.PhaseStation = BenchSetting.TestPhaseStation
            '        TestPhaseStationMainId = BenchSetting.TestPhaseStationMainId
            '        GUI.SAPFailSafeMode = BenchSetting.SAPFailSafeMode
            '        GUI.Factory = factoryName
            '        gIsWithSwitch = BenchSetting.SwitchMatrix.Enable
            '        GUI.IsWithSwitch = gIsWithSwitch
            '        GUI.Pattern_Launch = BenchSetting.AutoLanuchPattern
            '        GUI.Pattern_Path = BenchSetting.PatternProgramPath
            '        GUI.Pattern_Mode = BenchSetting.TestMode
            '        gRetryCount = BenchSetting.RetryCount
            '    End If

            '    gTestOptions = CTestOptions.CreateInstance(TestOptionsSettingFileName)
            '    If gTestOptions Is Nothing Then
            '        gTestOptions = New CTestOptions
            '        gTestOptions.MeasFormat = NAMeasFormat.NALOGM
            '        gTestOptions.Scale = CATS_SPara.Scale.Custom
            '        gTestOptions.RPOS = 8
            '        gTestOptions.RLVL = -15
            '        gTestOptions.PDIV = 10
            '        gTestOptions.PolarPDIV = 0.33
            '        gTestOptions.Save(TestOptionsSettingFileName)
            '    End If

            '    InitializeCalibrateIO()

            '    InitialFolder()
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
    End Sub

End Class
