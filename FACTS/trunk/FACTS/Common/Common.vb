Imports C1.Win.C1FlexGrid

Module Common
    Public gTestPlan As TestPlan = Nothing
    Public gBenchSetting As CBenchSetting = Nothing
    Public gSysIntegration As FACTS.Model.system_integration = Nothing
    Public gCfgFolder = "C:\Andrew\test_system"
    Public gBenchSettingFileName As String = "BenchSetting.xml"
    Public gSysIntegrationFileName As String = "SystemIntegration.xml"
    Public gCalItemsFileName As String = String.Format("{0}\CalItems.xml", gCfgFolder)
    Public GUI As FormGUI
    Public gSysIntegrationDays As Integer = 90
    Public gFamily As numFamily
    Public gConnectorFamily As numConnFamily
    Public gRecJumperLength As Decimal
    Public gCalInterval As Integer = 4
    Public gLocalSpecFolder As String = String.Format("{0}\LocalSpec", My.Application.Info.DirectoryPath)
    Public gAntSwmPortMapping As CSwitchPortMapping = Nothing
    Public Sub FormatGrid(flexGrid As C1FlexGrid, captionFontSize As Short, normalStyleFontSize As Short)
        Try
            'adding Three-Dimensional Text to a Header Row
            Dim tdt As C1.Win.C1FlexGrid.CellStyle
            tdt = flexGrid.Styles.Add("3DText")
            tdt.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Raised
            flexGrid.Rows(0).Style = tdt

            'adding Row Numbers in a Fixed Column
            flexGrid.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            flexGrid.Styles.Fixed.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            flexGrid.Styles.Fixed.Font = New Font("Arial", captionFontSize, FontStyle.Bold)

            For Each col As C1.Win.C1FlexGrid.Column In flexGrid.Cols
                col.TextAlign = TextAlignEnum.LeftCenter
            Next

            'set the border style property
            flexGrid.Styles("Normal").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            flexGrid.Styles("Normal").Border.Color = SystemColors.ControlDarkDark
            flexGrid.Styles("Normal").Border.Color = Color.DarkGray
            flexGrid.Styles("Normal").Font = New Font("Arial", normalStyleFontSize, FontStyle.Regular)

            flexGrid.AutoSizeRows()
            flexGrid.AutoSizeCols()

        Catch ex As Exception
            Throw New Exception("FormatGrid()::" & ex.Message)
        End Try
    End Sub

    Public Enum numFamily
        NA = 0
        MM = 1
        SM = 2
    End Enum

    Public Enum numConnFamily
        NA = 0
        NON_MPO = 1
        SINGLE_MPO = 2
        DUAL_MPO = 3
    End Enum

    Public Enum numModel
        MAP200_PCT = 0
        MAP300_PCT = 1
    End Enum

End Module
