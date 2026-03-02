Imports C1.Win.C1FlexGrid
Imports FACTSSpecManager.FormPRSPRLIL

Public Class FormPRSPRLILItem
    Private m_TestitemList As List(Of FormPRSPRLIL.TestitemModel)
    Public Property product_main As FACTS.Model.product_main
    Public Property TestitemList As List(Of FormPRSPRLIL.TestitemModel)
        Get
            Return m_TestitemList
        End Get
        Set(value As List(Of FormPRSPRLIL.TestitemModel))
            m_TestitemList = value
            LoadFgTestitems(TestitemList)
        End Set
    End Property
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub InitFgTestItems()
        Try
            'set up grid
            fgTestItems.Clear(ClearFlags.All)
            fgTestItems.Cols.Fixed = 1
            fgTestItems.Cols.Count = 12
            fgTestItems.Rows.Fixed = 1
            fgTestItems.Rows.Count = 1
            fgTestItems.Cols(1).Caption = "Group Id"
            fgTestItems.Cols(2).Caption = "Test Group"
            fgTestItems.Cols(3).Caption = "Test Item"
            fgTestItems.Cols(4).Caption = "Subunit"
            fgTestItems.Cols(5).Caption = "Fiber"
            fgTestItems.Cols(6).Caption = "Wave Length"
            fgTestItems.Cols(7).Caption = "LL"
            fgTestItems.Cols(8).Caption = "UL"
            fgTestItems.Cols(9).Caption = "Unit"
            fgTestItems.Cols(10).Caption = "Required"
            fgTestItems.Cols(11).Caption = "Message"

            Dim cs As CellStyle = fgTestItems.Styles.Add("Required")
            cs.DataType = Type.GetType("System.Boolean")
            fgTestItems.Cols(10).Style = cs

            FormatGrid(fgTestItems, 9, 8)

        Catch ex As Exception
            Throw New Exception("FormPRSPRLILItem.InitFgTestItem()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
    Private Sub LoadFgTestitems(items As List(Of FormPRSPRLIL.TestitemModel))
        Try
            InitFgTestItems()
            Dim dr As Row
            For Each item In items
                dr = fgTestItems.Rows.Add
                dr(1) = item.group_order
                dr(2) = item.group_name
                dr(3) = item.meas_item
                dr(4) = item.sub_unit
                dr(5) = item.fiber
                dr(6) = item.wave_length
                dr(7) = item.limit_low
                dr(8) = item.limit_up
                dr(9) = item.limit_unit
                dr(10) = item.meas_required
                dr(11) = item.message
            Next
            FormatGrid(fgTestItems, 8, 8)
        Catch ex As Exception
            Throw New Exception("FormPRSPRLILItem.LoadFgTestitems()::" & ex.Message)
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If MsgBox("Do you really save the test items to CATS?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If

            Dim phaseM As FormPRSPRLIL.PhaseModel = FormPRSPRLIL.GetFgPhaseSelectedRowPhaseModel()

            Dim tiList As List(Of FormPRSPRLIL.TestitemModel) = GetFgTestitemList()

            Dim cmpStat As Short = CompareTestitemList(phaseM.M_testItemList, tiList)
            Dim phStatus As String = phaseM.status.ToUpper
            Dim msM As FACTS.Model.mode_spec

            If tiList Is Nothing Then MsgBox("The items is null, please add.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return
            If tiList.Count = 0 Then MsgBox("The items is null, please add.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return

            If phaseM.ISNEW = True Then

                '>> 5 RELEASE THE NEW SPEC_MAIN

                msM = CreateDbPhaseBox(phaseM, tiList)
                phaseM.M_cq_phases.mode_spec_id = msM.id
                phaseM.M_cq_phases.spec_main_id = msM.spec_main_id
                phaseM.M_cq_phases.phase_main_id = phaseM.M_phase.id

                FormPRSPRLIL.SetPhaseStatus(phaseM, FormPRSPRLIL.EmPhaseStatus.Release)

                MsgBox("The new specification have been added to CATS!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            Else
                If cmpStat = 0 Then
                    MsgBox("The test items are latest, will not update to CATS.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Return
                End If

                If cmpStat = 1 Then
                    If MsgBox("The items have been modified, will automatically create a new phase [" & phaseM.M_phase.ToString & "]." & vbCrLf &
                      "Do you want to continue ... ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        '>> 5 CREATE THE NEW SPEC_MAIN
                        msM = CreateDbPhaseBox(phaseM, tiList)

                        '>> 6 INVALID OLD ONE
                        FormPRSPRLIL.SetPhaseStatus(phaseM, FormPRSPRLIL.EmPhaseStatus.Invalid)

                        '>> 7 RELEASE THE NEW SPEC_MAIN
                        'phaseM.M_cq_phases.mode_spec_id = mode_spec_id
                        phaseM.M_cq_phases.mode_spec_id = msM.id
                        phaseM.M_cq_phases.spec_main_id = msM.spec_main_id

                        FormPRSPRLIL.SetPhaseStatus(phaseM, FormPRSPRLIL.EmPhaseStatus.Release)

                    End If
                End If
            End If

            FormPRSPRLIL.pbLoadTest.Minimum = 0
            FormPRSPRLIL.pbLoadTest.Value = 0
            FormPRSPRLIL.pbLoadTest.Maximum = 100
            FormPRSPRLIL.RefreshFgPhaseList()

        Catch ex As Exception
            MsgBox("FormPRSPRLILItem.btnSaveToDb_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Function GetFgTestitemList() As List(Of FormPRSPRLIL.TestitemModel)
        Try

            Dim resp As New List(Of FormPRSPRLIL.TestitemModel)
            Dim respItem As FormPRSPRLIL.TestitemModel
            Dim tmpRow As Row

            For Each row As Row In fgTestItems.Rows
                If row.Index < 1 Then Continue For
                tmpRow = row
                respItem = New FormPRSPRLIL.TestitemModel

                With respItem

                    .id = tmpRow(0)
                    .group_order = tmpRow(1)
                    .group_name = tmpRow(2)
                    .meas_item = tmpRow(3)
                    .sub_unit = tmpRow(4)
                    .fiber = tmpRow(5)
                    .wave_length = tmpRow(6)
                    .limit_low = tmpRow(7)
                    .limit_up = tmpRow(8)
                    .limit_unit = tmpRow(9)
                    .meas_required = tmpRow(10)
                    .message = tmpRow(11)
                    If IsNumeric(.id) = True And IsNumeric(.group_order) = True And .group_name <> "" Then resp.Add(respItem)

                End With

            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("FormPRSPRLILItem.GetFgTestitemList()::" & ex.Message)
        End Try
    End Function
    Private Function CompareTestitemList(tiML1 As List(Of FormPRSPRLIL.TestitemModel), tiML2 As List(Of FormPRSPRLIL.TestitemModel)) As Short '0-equal; 1-not equal 
        Try
            'same return 0
            'diff return 1
            If tiML1 Is Nothing And tiML2 IsNot Nothing Then Return 1
            If tiML1 IsNot Nothing And tiML2 Is Nothing Then Return 1
            If tiML1 Is Nothing And tiML2 Is Nothing Then Return 0

            Dim lst1Num As Integer = tiML1.Count - 1
            Dim lst2Num As Integer = tiML2.Count - 1

            If lst1Num <> lst2Num Then Return 1

            Dim lstI As Integer

            For lstI = 0 To lst1Num

                If tiML1.Item(lstI).group_order <> tiML2.Item(lstI).group_order Then Return 1
                If tiML1.Item(lstI).group_name <> tiML2.Item(lstI).group_name Then Return 1
                If tiML1.Item(lstI).meas_item <> tiML2.Item(lstI).meas_item Then Return 1
                If tiML1.Item(lstI).limit_low <> tiML2.Item(lstI).limit_low Then Return 1
                If tiML1.Item(lstI).limit_up <> tiML2.Item(lstI).limit_up Then Return 1
                If tiML1.Item(lstI).limit_unit <> tiML2.Item(lstI).limit_unit Then Return 1
                If tiML1.Item(lstI).sub_unit <> tiML2.Item(lstI).sub_unit Then Return 1
                If tiML1.Item(lstI).fiber <> tiML2.Item(lstI).fiber Then Return 1
                If tiML1.Item(lstI).wave_length <> tiML2.Item(lstI).wave_length Then Return 1
                If tiML1.Item(lstI).meas_required <> tiML2.Item(lstI).meas_required Then Return 1
                If tiML1.Item(lstI).message <> tiML2.Item(lstI).message Then Return 1

            Next

            Return 0

        Catch ex As Exception
            Throw New Exception("FormPRSPRLILItem.CompareTestitemList" & ex.Message)
        End Try
    End Function

    Private Function CreateDbPhaseBox(phaseM As FormPRSPRLIL.PhaseModel, testitemList As List(Of FormPRSPRLIL.TestitemModel)) As FACTS.Model.mode_spec

        Try

            '>> 1 ADD A NEW SPEC_MAIN
            '>> 2 ADD MODE_SPEC
            Dim resp As New FACTS.Model.mode_spec
            Dim cqM As FACTS.Model.cq_modes = FormPRSPRLIL.GetProductMode()
            Dim group_main_id As Integer
            Dim spec_detail_id As Integer
            Dim ordIdx As Integer = 1
            Dim mm_group_main_id As Integer

            resp = CreateDbPhase(cqM.product_mode_id, phaseM) ' phase is updating statue

            Dim gpM As FACTS.Model.group_main
            Dim sdM As FACTS.Model.spec_detail

            For Each ti In testitemList

                '>> 5 ADD GROUP
                gpM = New FACTS.Model.group_main
                With gpM
                    .spec_main_id = resp.spec_main_id
                    .group_id = ti.group_order
                    .order_idx = ti.group_order
                    .group_name = ti.group_name
                    .validity = True
                    .validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                End With

                group_main_id = DbOperator.ImportDb_group_main(gpM)
                If mm_group_main_id <> group_main_id Then
                    ordIdx = 1
                Else
                    ordIdx += 1
                End If
                mm_group_main_id = group_main_id

                '>> 6 ADD SPEC_DETAIL
                sdM = New FACTS.Model.spec_detail
                With sdM
                    .group_main_id = group_main_id
                    .order_idx = ordIdx
                    .meas_item = ti.meas_item
                    .limit_low = ti.limit_low
                    .limit_up = ti.limit_up
                    .limit_unit = ti.limit_unit
                    .Sub_unit = ti.sub_unit
                    .Fiber = ti.fiber
                    .Wave_length = ti.wave_length
                    .meas_required = ti.meas_required
                    .message = ti.message
                    .validity = True
                    .validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    .invalidation_date = "2016-1-1 00:00:00"
                End With
                spec_detail_id = DbOperator.ImportDb_spec_detail(sdM)
            Next

            'update product_mode
            Dim pmBll As New FACTS.BLL.product_modeManager
            Dim pmM As FACTS.Model.product_mode

            pmM = pmBll.SelectById(cqM.product_mode_id)
            pmM.validation_date = Now

            pmBll.Update(pmM)


            Dim slM As New FACTS.Model.spec_log
            Dim pM As FACTS.Model.product_main = FormPRSPRLIL.cbProduct.SelectedItem

            With slM
                .product_main_id = cqM.product_main_id
                .mode_id = cqM.mode_id
                .spec_main_id = resp.spec_main_id
                .phase_main_id = phaseM.M_phase.id
                .action = EmSpecLogAction.Create.ToString
                .action_descr = pM.product_name & " > " & cqM.mode & " > " & phaseM.M_phase.phase & " > " & .action
            End With

            DbOperator.AddDb_spec_log(slM)
            FormMain.tsslStaus.Text = slM.action_descr

            Return resp

        Catch ex As Exception
            Throw New Exception("CreateDbPhaseBox()::" & ex.Message)
        End Try
    End Function
    Private Function CreateDbPhase(product_mode_id As Integer, phaseM As FormPRSPRLIL.PhaseModel) As FACTS.Model.mode_spec

        Try
            Dim resp As New FACTS.Model.mode_spec
            Dim spec_main_id As Integer
            Dim mode_spec_id As Integer

            'add spec_main table
            Dim smM As New FACTS.Model.spec_main

            With smM
                .phase_main_id = phaseM.M_phase.id
                .only_test = False
                .manual_enable = False
                .allow_cust_limit = False
                .script = ""
                .invalidate_phase_ids = ""
                .spec_desc = ""
                .spec_version = phaseM.spec_ver
                .spec_revision = ""
                .change_note = ""
                .validity = True
                .validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                .descr = ""
            End With

            phaseM.M_cq_phases.spec_main_model = smM

            spec_main_id = DbOperator.ImportDb_spec_main(product_mode_id, phaseM.M_cq_phases)

            'add mode_spec table
            Dim msM As New FACTS.Model.mode_spec
            With msM
                .product_mode_id = product_mode_id 'pcM.M_Phase.M_cq_phases.product_mode_id
                .spec_main_id = spec_main_id 'pcM.M_Phase.M_cq_phases.spec_main_id
                .order_idx = phaseM.order
                .validity = False
                .validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
                .validation = True

            End With
            mode_spec_id = DbOperator.ImportDb_mode_spec(msM)

            resp.spec_main_id = spec_main_id
            resp.id = mode_spec_id

            Return resp

        Catch ex As Exception
            Throw New Exception("FormPRSPRLILItem.CreateDbPhase" & ex.Message)
        End Try
    End Function

    Private Sub fgTestItems_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgTestItems.OwnerDrawCell
        Try
            If e.Row >= fgTestItems.Rows.Fixed And e.Col = fgTestItems.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgTestItems.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            Throw New Exception("FormPRSPRLILItem.fgTestItems_OwnerDrawCell()::" & vbCrLf & " at " & ex.Message)
        End Try
    End Sub
End Class