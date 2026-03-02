Imports C1.Win.C1FlexGrid
Imports FACTS
Imports FACTS.Model

Public Class FormPRSPRLIL
    Private m_phaseModeList As List(Of PhaseModel)
    Private m_product_main_id As Integer
    Private m_product_main As FACTS.Model.product_main
    Private m_connector_spec_detail_1500List As New List(Of Model.connector_spec_detail)
    Private m_connector_spec_detail_1501List As New List(Of Model.connector_spec_detail)
    Private m_phase As String = Nothing
    Private m_length_limit_list As List(Of Model.length_limit)
    Private m_connector_family As numConnFamily
    Public Enum EmPhaseStatus
        '=> release: validity/true ; validation/true
        '=> updating: validity/false ; validation / true
        '=> invalid: validity/false ; validation / false
        NULL = 0
        Release = 1
        Invalid = 2
        Delete = 3
    End Enum
    Public Enum MeasType
        NA = 0
        RL = 1
        IL = 2
        Length = 3
    End Enum
    Public Class PhaseModel
        Public id As Integer
        Public M_phase As FACTS.Model.phase_main
        Public spec_ver As String
        Public order As Integer
        Public status As String 'release:green, invalid:red
        Public validation_date As DateTime
        Public M_cq_phases As New FACTS.Model.cq_phases
        Public M_testItemList As New List(Of TestitemModel)
        Public ISNEW As Boolean
    End Class
    Public Class TestitemModel
        Public id As Integer
        Public group_order As Integer
        Public group_name As String
        Public meas_item As String
        Public meas_type As MeasType
        Public sub_unit As Integer
        Public fiber As Integer
        Public wave_length As Integer
        Public limit_low As Single
        Public limit_up As Single
        Public limit_unit As String
        Public meas_required As Boolean
        Public message As String
        Public parent_tb As TestbandModel
    End Class
    Public Class TestbandModel
        Public required As Boolean
        Public group As String
        Public subunit As Integer
        Public fiber As Integer
        Public wave_length_list As New List(Of Integer)
        Public rl_limit As Single
        Public length_limit As Single
        Public il_limit As Single
        Public switch_end As Boolean
    End Class
    Private Class TestbandItem
        Public rl_il As New List(Of TestbandModel)
    End Class
    Public ReadOnly Property ProdModel As FACTS.Model.product_main
        Get
            Try
                Dim resp As FACTS.Model.product_main
                resp = cbProduct.SelectedItem
                Return resp

            Catch ex As Exception
                Throw New Exception("GetProductModel()::" & ex.Message)
            End Try

        End Get
    End Property
    Private Sub FormPRSPRLIL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = FormMain
            LoadProducts()
            cbProduct.Focus()
            InitFgPhase()
            InitFgTestBand()
            Me.splitMain.SplitterDistance = Me.splitMain.Height * 2 / 5
        Catch ex As Exception
            MsgBox("FormPRSPRLIL_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load Form Error")
            Me.Close()
        End Try
    End Sub
    Private Sub LoadProducts()
        Try
            Dim pmML As List(Of FACTS.Model.product_main)
            pmML = DbOperator.GetAllProducts
            If pmML Is Nothing Then Return
            cbProduct.Items.AddRange(pmML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.LoadProducts()::" & ex.Message)
        End Try
    End Sub
    Private Sub InitFgPhase()
        Try
            'set up grid
            fgPhase.Clear(ClearFlags.Content)
            fgPhase.Cols.Fixed = 1
            fgPhase.Cols.Count = 5
            fgPhase.Rows.Fixed = 1
            fgPhase.Rows.Count = 1
            fgPhase.Cols(1).Caption = "Phase"
            fgPhase.Cols(2).Caption = "Version"
            fgPhase.Cols(3).Caption = "Validaton Date"
            fgPhase.Cols(4).Caption = "Status"

            Dim pmBll As New FACTS.BLL.phase_mainManager
            Dim pmML As List(Of FACTS.Model.phase_main)
            Dim tmpML As New List(Of FACTS.Model.phase_main)

            pmML = pmBll.SelectAll()

            Dim phaseStr As String = String.Empty

            For Each phase In pmML
                phaseStr += "|" & phase.phase
            Next

            fgPhase.Cols(1).ComboList = phaseStr
            fgPhase.Cols(1).AllowEditing = True
            fgPhase.Cols(2).AllowEditing = True
            fgPhase.Cols(3).AllowEditing = False
            fgPhase.Cols(4).AllowEditing = False

            Dim cs As CellStyle = fgPhase.Styles.Add("Release")
            cs.BackColor = Color.GreenYellow

            cs = fgPhase.Styles.Add("Delete")
            cs.BackColor = Color.Gray

            cs = fgPhase.Styles.Add("Invalid")
            cs.BackColor = Color.Pink

            FormatGrid(fgPhase, 9, 8)
            fgPhase.Cols(1).Width *= 2

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.InitFgPhase()::" & ex.Message)
        End Try
    End Sub
    Public Function GetFgPhaseSelectedRowPhaseModel() As PhaseModel
        Try
            Dim rIdx As Integer = fgPhase.Row
            If rIdx < 1 Then Throw New Exception("Not select any phase...")

            Dim r As Row = fgPhase.Rows(rIdx)

            Dim pM As PhaseModel = CType(r.UserData, PhaseModel)
            If pM.ISNEW = False Then Return pM

            If r(1) Is Nothing Then Throw New Exception("PhaseList.Column('phase') is null.")

            Dim resp As New PhaseModel

            Dim pmBll As New FACTS.BLL.phase_mainManager

            resp.M_phase = pmBll.SelectByPhase(r(1))
            resp.spec_ver = r(2)
            resp.status = r(4)
            resp.ISNEW = True
            r.UserData = resp

            Return resp

        Catch ex As Exception
            Throw New Exception("GetFgPhaseSelectedRowPhaseModel()::" & ex.Message)
        End Try
    End Function
    Private Sub InitFgTestBand()
        Try
            'set up grid
            fgTestBand.Clear(ClearFlags.Content)
            fgTestBand.Cols.Fixed = 1
            fgTestBand.Cols.Count = 9
            fgTestBand.Rows.Fixed = 1
            fgTestBand.Rows.Count = 1
            fgTestBand.Cols(1).Caption = "Required"
            fgTestBand.Cols(2).Caption = "Group"
            fgTestBand.Cols(3).Caption = "Subunit"
            fgTestBand.Cols(4).Caption = "Fiber"
            fgTestBand.Cols(5).Caption = "Wave Length"
            fgTestBand.Cols(6).Caption = "IL_Limit_Upper"
            fgTestBand.Cols(7).Caption = "RL_Limit_Lower"
            fgTestBand.Cols(8).Caption = "LEN_Limit_Upper"

            Dim cs As CellStyle = fgTestBand.Styles.Add("Select")
            cs.DataType = Type.GetType("System.Boolean")
            fgTestBand.Cols(1).Style = cs

            FormatGrid(fgTestBand, 9, 8)

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.InitFgTestBand()::" & ex.Message)
        End Try
    End Sub
    Private Sub cbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProduct.SelectedIndexChanged
        Try
            Dim pModel As FACTS.Model.product_main

            pModel = cbProduct.SelectedItem
            m_product_main = pModel
            pFamily = [Enum].Parse(GetType(Family), m_product_main.Family)
            m_product_main_id = pModel.Id

            LoadModes(pModel)

            LoadWaveLengthList()

            m_connector_family = GetConnectorType()

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.cbProduct_SelectedIndexChanged()::" & ex.Message)
        End Try
    End Sub

    Private Sub LoadWaveLengthList()
        Try
            Dim pcs1500M As Model.product_connector_spec_1500
            Dim pcs1500Bll As New BLL.product_connector_spec_1500Manager
            pcs1500M = pcs1500Bll.SelectByProdMainId(ProdModel.Id)

            Dim csdBll As New BLL.connector_spec_detailManager
            m_connector_spec_detail_1500List = csdBll.SelectByConnSpecMainId(pcs1500M.Connector_spec_main_id)

            Dim pcs1501M As Model.product_connector_spec_1501
            Dim pcs1501Bll As New BLL.product_connector_spec_1501Manager
            pcs1501M = pcs1501Bll.SelectByProdMainId(ProdModel.Id)
            m_connector_spec_detail_1501List = csdBll.SelectByConnSpecMainId(pcs1501M.Connector_spec_main_id)

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.LoadWaveLengthList()::" & ex.Message)
        End Try
    End Sub

    Private Sub LoadModes(pmM As FACTS.Model.product_main)
        Try
            If pmM Is Nothing Then Throw New Exception("product is null.")

            Dim id As Integer = pmM.Id
            Dim cmM As List(Of FACTS.Model.cq_modes)
            cmM = DbOperator.GetModesByProductId(id)
            cbMode.Text = ""
            cbMode.Items.Clear()
            cbMode.Items.AddRange(cmM.ToArray)

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.LoadModes()::" & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim r As Row
            Dim phaseM As New PhaseModel

            r = fgPhase.Rows.Add()

            fgPhase.Row = r.Index

            phaseM.ISNEW = True
            phaseM.M_cq_phases.product_mode_id = CType(cbMode.SelectedItem, FACTS.Model.cq_modes).product_mode_id
            r.UserData = phaseM
            r(1) = "System"
            r(2) = "01A"
            r(3) = Now.ToString("yyyy-MM-dd HH:mm:ss")
            r(4) = "New..."

            m_phase = fgPhase(fgPhase.Row, 1)

            FormatGrid(fgPhase, 9, 8)
            fgPhase.Cols(1).Width *= 2

        Catch ex As Exception
            MsgBox("FormPRSPRLIL.btnAdd_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Me.pbLoadTest.Minimum = 0
            Me.pbLoadTest.Value = 0
            Me.pbLoadTest.Maximum = 100

            InitFgPhase()
            InitFgTestBand()

            RefreshFgPhaseList()

            m_phase = Nothing

            If fgPhase.Rows.Count > 1 Then
                fgPhase.Row = 1
                m_phase = fgPhase(fgPhase.Row, 1)
            End If

            btnAdd.Enabled = True

        Catch ex As Exception
            MsgBox("btnRefresh_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Public Sub RefreshFgPhaseList()

        Try
            If cbMode.SelectedItem Is Nothing Then Return

            Dim filterInt As Integer

            If ckFilterDelete.Checked = True Then filterInt += 1
            If ckFilterInvalid.Checked = True Then filterInt += 2
            If ckFilterRelease.Checked = True Then filterInt += 4

            m_phaseModeList = GetDbPhaseList(CType(cbMode.SelectedItem, FACTS.Model.cq_modes).product_mode_id, filterInt)

            InitFgPhase()

            LoadFgPhaseList(m_phaseModeList)

        Catch ex As Exception
            Throw New Exception("RefreshDvPhaseList()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadFgPhaseList(pML As List(Of PhaseModel))

        Try
            If pML Is Nothing Then Return

            Dim query = From pm In pML
                        Order By pm.status Descending, pm.M_cq_phases.validation_date Descending

            Dim r As Row
            Dim rIdx As Integer

            For Each pm In query.ToList

                pbLoadTest.Value += 1

                r = fgPhase.Rows.Add()
                rIdx = r.Index
                r.UserData = pm

                If pm.M_phase IsNot Nothing Then r(1) = pm.M_phase.ToString

                r(2) = pm.spec_ver
                r(3) = pm.validation_date
                r(4) = pm.status

                Dim eps As EmPhaseStatus

                eps = [Enum].Parse(GetType(EmPhaseStatus), pm.status)

                If eps = EmPhaseStatus.Release Then
                    fgPhase.SetCellStyle(rIdx, 4, fgPhase.Styles("Release"))
                ElseIf eps = EmPhaseStatus.Delete Then
                    fgPhase.SetCellStyle(rIdx, 4, fgPhase.Styles("Delete"))
                ElseIf eps = EmPhaseStatus.Invalid Then
                    fgPhase.SetCellStyle(rIdx, 4, fgPhase.Styles("Invalid"))
                End If
            Next

            FormatGrid(fgPhase, 9, 8)
            fgPhase.Cols(1).Width *= 2

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.LoadGvPhaseList" & ex.Message)
        End Try
    End Sub
    Private Function GetDbPhaseList(product_mode_id As Integer, filterInt As Byte) As List(Of PhaseModel)

        Try
            Dim resp As New List(Of PhaseModel)
            Dim respItem As PhaseModel

            Dim cqpBll As New FACTS.BLL.cq_phasesManager()
            Dim cqpML As New List(Of FACTS.Model.cq_phases)

            Dim id As Integer = 1
            Dim tmpML As List(Of FACTS.Model.cq_phases)

            ' Get phase [release&invalid]
            Dim s As String = Convert.ToString(filterInt, 2).ToString.PadLeft(3, "0")

            pbLoadTest.Value = 0

            If s.Substring(0, 1) = "1" Then 'Realsed
                tmpML = cqpBll.SelectAllByProductModeId(product_mode_id, True, True)
                If tmpML IsNot Nothing Then cqpML.AddRange(tmpML)
                pbLoadTest.Value += 1
            End If
            If s.Substring(1, 1) = "1" Then 'Invalid
                tmpML = cqpBll.SelectAllByProductModeId(product_mode_id, False, True)
                If tmpML IsNot Nothing Then cqpML.AddRange(tmpML)
                pbLoadTest.Value += 1
            End If
            If s.Substring(2, 1) = "1" Then 'Deleted
                tmpML = cqpBll.SelectAllByProductModeId(product_mode_id, False, False)
                If tmpML IsNot Nothing Then cqpML.AddRange(tmpML)
            End If

            If cqpML Is Nothing Then Return Nothing

            If filterInt = 6 Then
                Me.pbLoadTest.Maximum = cqpML.Count * 2 + 2
            Else
                Me.pbLoadTest.Maximum = cqpML.Count * 2 + 1
            End If

            For Each cqM In cqpML

                pbLoadTest.Value += 1

                respItem = New PhaseModel

                With respItem

                    .M_cq_phases = cqM
                    .id = id
                    .M_phase = (New FACTS.BLL.phase_mainManager).SelectById(cqM.phase_main_id)
                    .spec_ver = cqM.spec_main_model.spec_version
                    .order = cqM.order_idx
                    .status = GetPhaseStatus(cqM).ToString
                    .validation_date = cqM.validation_date
                    .ISNEW = False
                End With

                resp.Add(respItem)

                id += 1

            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.GetDbPhaseList" & ex.Message)
        End Try
    End Function
    Private Function GetPhaseStatus(cq_phasesModel As FACTS.Model.cq_phases) As EmPhaseStatus
        Try
            Dim rec As Int16 = 0

            If cq_phasesModel.validity = True Then rec += 1
            If cq_phasesModel.validation = True Then rec += 2

            If rec = 0 Then Return EmPhaseStatus.Delete
            If rec = 2 Then Return EmPhaseStatus.Invalid
            If rec = 3 Then Return EmPhaseStatus.Release

            Return EmPhaseStatus.NULL

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.GetPhaseStatus()::" & ex.Message)
        End Try
    End Function

    Private Sub cbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMode.SelectedIndexChanged
        Try
            If cbMode.SelectedItem Is Nothing Then Return
            btnAdd.Enabled = True
        Catch ex As Exception
            MsgBox("FormPRSPRLIL.cbMode_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub fgPhase_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgPhase.OwnerDrawCell
        Try
            If e.Row >= fgPhase.Rows.Fixed And e.Col = fgPhase.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgPhase.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormPRSPRLIL.fgPhase_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub fgTestBand_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgTestBand.OwnerDrawCell
        Try
            If e.Row >= fgTestBand.Rows.Fixed And e.Col = fgTestBand.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgTestBand.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormPRSPRLIL.fgTestBand_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnLoadBands_Click(sender As Object, e As EventArgs) Handles btnLoadBands.Click
        Try
            Dim tbML As List(Of TestbandModel) = GenerateTestbandList_RlIl()
            LoadFgTestbandList_RlIl(tbML)
        Catch ex As Exception
            MsgBox("FormPRSPRLIL.btnLoadBands_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub LoadFgTestbandList_RlIl(items As List(Of TestbandModel))
        Try
            If items Is Nothing Then Return
            If items.Count = 0 Then Return

            InitFgTestBand()

            Dim r As Row

            For Each item In items

                r = fgTestBand.Rows.Add()

                r(1) = item.required
                r(2) = item.group
                r(3) = item.subunit
                r(4) = item.fiber
                r(5) = String.Join(",", item.wave_length_list)
                r(6) = item.il_limit
                r(7) = item.rl_limit
                r(8) = item.length_limit

                r.UserData = item

            Next

            FormatGrid(fgTestBand, 9, 8)

        Catch ex As Exception
            Throw New Exception("LoadGvTestbandList_RlInIso()::" & ex.Message)
        End Try
    End Sub
    Private Function GenerateTestbandList_RlIl() As List(Of TestbandModel)
        Try
            If m_phase Is Nothing Then
                MsgBox("Please create a new phase or select a phase", MsgBoxStyle.Information, "Load Band")
                Return Nothing
            End If
            Dim resp As New List(Of TestbandModel)
            Dim respItem As TestbandModel
            Dim fiberId As Integer
            Dim waveLength As Integer
            Dim il1500Limit, il1501Limit As Double
            Dim rl1500Limit, rl1501Limit As Double
            Dim lengthLimitUpper As Double
            If IsNumeric(Me.txtLengthLimit.Text) Then
                lengthLimitUpper = Double.Parse(Me.txtLengthLimit.Text)
            Else
                m_length_limit_list = (New BLL.length_limitManager).SelectAll
                Dim query = From len In m_length_limit_list
                            Where m_product_main.Length_m >= len.Length_range_lower And m_product_main.Length_m <= len.Length_range_upper
                lengthLimitUpper = Math.Round(m_product_main.Length_m + query.Single.Length_limit_up, 3)
            End If

            If ProdModel.Fiber_per_subunit <= 2 Then
                For i As Integer = 1 To ProdModel.Subunit
                    For j As Integer = 1 To ProdModel.Fiber_per_subunit
                        fiberId += 1
                        respItem = New TestbandModel
                        With respItem
                            .required = True
                            .subunit = i
                            .fiber = fiberId
                            .group = IIf(m_phase = "System", String.Format("FIBER {0}", fiberId), String.Format("CONNECTOR {0}_A", fiberId))
                            For Each csd In m_connector_spec_detail_1500List
                                waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                il1500Limit = csd.Il_limit
                                rl1500Limit = csd.Rl_limit
                            Next
                            If m_connector_spec_detail_1501List IsNot Nothing Then
                                For Each csd In m_connector_spec_detail_1501List
                                    waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                    If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                    il1501Limit = csd.Il_limit
                                    rl1501Limit = csd.Rl_limit
                                Next
                            End If

                            If m_phase = "Connector" Then
                                .il_limit = il1500Limit
                                .rl_limit = Math.Abs(rl1500Limit)
                            Else
                                .il_limit = il1500Limit + il1501Limit
                                .rl_limit = Math.Round(Math.Abs(10 * Math.Log10(10 ^ (-Math.Abs(rl1500Limit) / 10) + 10 ^ (-Math.Abs(rl1501Limit) / 10))), 1)
                            End If
                            .length_limit = lengthLimitUpper
                        End With
                        resp.Add(respItem)

                        If m_phase = "Connector" Then
                            Dim connId As Integer
                            If ProdModel.Fiber_per_subunit = 2 Then
                                If fiberId = 1 Then connId = 2
                                If fiberId = 2 Then connId = 1
                            End If
                            respItem = New TestbandModel
                            With respItem
                                .required = True
                                .subunit = i
                                .fiber = connId
                                .group = String.Format("CONNECTOR {0}_B", connId)
                                If m_connector_spec_detail_1501List Is Nothing Then Continue For
                                For Each csd In m_connector_spec_detail_1501List
                                    .wave_length_list.Add((New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length)
                                    .il_limit = csd.Il_limit
                                    .rl_limit = csd.Rl_limit
                                Next
                                .length_limit = lengthLimitUpper
                            End With
                            resp.Add(respItem)
                        End If
                    Next
                Next
            Else
                If m_connector_family <> numConnFamily.NON_MPO Then
                    For i As Integer = 1 To ProdModel.Subunit
                        fiberId = i
                        respItem = New TestbandModel
                        With respItem
                            .required = True
                            .subunit = 1
                            .fiber = fiberId
                            If m_phase = "System" Then
                                .group = String.Format("FIBER {0}", fiberId)
                            ElseIf m_phase = "Connector" Then
                                .group = String.Format("CONNECTOR {0}_A", fiberId)
                            ElseIf m_phase = "Connector_A" Then
                                .group = String.Format("CONNECTOR {0}_A", fiberId)
                            ElseIf m_phase = "Connector_B" Then
                                .group = String.Format("CONNECTOR {0}_B", fiberId)
                            End If

                            For Each csd In m_connector_spec_detail_1500List
                                waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                il1500Limit = csd.Il_limit
                                rl1500Limit = csd.Rl_limit
                            Next
                            If m_connector_spec_detail_1501List IsNot Nothing Then
                                For Each csd In m_connector_spec_detail_1501List
                                    waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                    If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                    il1501Limit = csd.Il_limit
                                    rl1501Limit = csd.Rl_limit
                                Next
                            End If

                            If m_phase = "Connector" Then
                                .il_limit = il1500Limit
                                .rl_limit = Math.Abs(rl1500Limit)
                            ElseIf m_phase = "Connector_A" Then
                                .il_limit = il1500Limit
                                .rl_limit = Math.Abs(rl1500Limit)
                            ElseIf m_phase = "Connector_B" Then
                                .il_limit = il1501Limit
                                .rl_limit = Math.Abs(rl1501Limit)
                            Else
                                .il_limit = il1500Limit + il1501Limit
                                .rl_limit = Math.Round(Math.Abs(10 * Math.Log10(10 ^ (-Math.Abs(rl1500Limit) / 10) + 10 ^ (-Math.Abs(rl1501Limit) / 10))), 1)
                            End If
                            .length_limit = lengthLimitUpper
                        End With
                        resp.Add(respItem)
                    Next
                    If m_phase = "Connector" Then
                        For i As Integer = 1 To ProdModel.Fiber_per_subunit
                            fiberId = i
                            respItem = New TestbandModel
                            With respItem
                                .required = True
                                .subunit = 1
                                If fiberId = 1 Then .switch_end = True
                                .fiber = fiberId
                                .group = String.Format("CONNECTOR {0}_B", fiberId)
                                If m_connector_spec_detail_1501List Is Nothing Then Continue For
                                For Each csd In m_connector_spec_detail_1501List
                                    waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                    If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                    il1501Limit = csd.Il_limit
                                    rl1501Limit = csd.Rl_limit
                                Next
                                .il_limit = il1501Limit
                                .rl_limit = Math.Abs(rl1501Limit)
                                .length_limit = lengthLimitUpper
                            End With
                            resp.Add(respItem)
                        Next
                    End If
                Else 'NON_MPO
                    For i As Integer = 1 To ProdModel.Subunit
                        For j As Integer = 1 To ProdModel.Fiber_per_subunit
                            fiberId += 1
                            respItem = New TestbandModel
                            With respItem
                                .required = True
                                .subunit = i
                                .fiber = fiberId
                                If (fiberId - 1) Mod ProdModel.Fiber_per_subunit = 0 And fiberId > 1 Then .switch_end = True
                                If m_phase = "System" Then
                                    .group = String.Format("FIBER {0}", fiberId)
                                Else
                                    .group = String.Format("CONNECTOR {0}_A", fiberId)
                                End If

                                For Each csd In m_connector_spec_detail_1500List
                                    waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                    If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                    il1500Limit = csd.Il_limit
                                    rl1500Limit = csd.Rl_limit
                                Next
                                If m_connector_spec_detail_1501List IsNot Nothing Then
                                    For Each csd In m_connector_spec_detail_1501List
                                        waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                        If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                        il1501Limit = csd.Il_limit
                                        rl1501Limit = csd.Rl_limit
                                    Next
                                End If
                                If m_phase = "Connector" Then
                                    .il_limit = il1500Limit
                                    .rl_limit = Math.Abs(rl1500Limit)
                                Else
                                    .il_limit = il1500Limit + il1501Limit
                                    .rl_limit = Math.Round(Math.Abs(10 * Math.Log10(10 ^ (-Math.Abs(rl1500Limit) / 10) + 10 ^ (-Math.Abs(rl1501Limit) / 10))), 1)
                                End If
                                .length_limit = lengthLimitUpper
                            End With
                            resp.Add(respItem)
                        Next
                    Next

                    If m_phase = "Connector" Then
                        fiberId = 0
                        For i As Integer = 1 To ProdModel.Subunit
                            For j As Integer = 1 To ProdModel.Fiber_per_subunit
                                fiberId += 1
                                respItem = New TestbandModel
                                With respItem
                                    .required = True
                                    .subunit = 1
                                    If (fiberId - 1) Mod ProdModel.Fiber_per_subunit = 0 And fiberId > 1 Then .switch_end = True
                                    .fiber = fiberId
                                    .group = String.Format("CONNECTOR {0}_B", fiberId)
                                    If m_connector_spec_detail_1501List Is Nothing Then Continue For
                                    For Each csd In m_connector_spec_detail_1501List
                                        waveLength = (New BLL.wave_lengthManager).SelectById(csd.Wave_length_id).Wave_length
                                        If Not .wave_length_list.Contains(waveLength) Then .wave_length_list.Add(waveLength)
                                        il1501Limit = csd.Il_limit
                                        rl1501Limit = csd.Rl_limit
                                    Next
                                    .il_limit = il1501Limit
                                    .rl_limit = Math.Abs(rl1501Limit)
                                    .length_limit = lengthLimitUpper
                                End With
                                resp.Add(respItem)
                            Next
                        Next
                    End If
                End If
            End If

            Return resp

        Catch ex As Exception
            Throw New Exception("GenerateTestbandList_RlIl()::" & ex.Message)
        End Try
    End Function
    Private Function GetConnectorType() As numConnFamily
        Try
            Dim cf1500M As connector_family
            Dim cf1501M As connector_family

            Dim cfBll As New BLL.connector_familyManager
            cf1500M = cfBll.Select1500ByProduct(m_product_main.Product_name)
            cf1501M = cfBll.Select1501ByProduct(m_product_main.Product_name)

            If cf1500M.Family_name.Contains("MPO") And cf1501M.Family_name.Contains("MPO") Then
                Return numConnFamily.DUAL_MPO
            ElseIf Not cf1500M.Family_name.Contains("MPO") And Not cf1501M.Family_name.Contains("MPO") Then
                Return numConnFamily.NON_MPO
            End If

            Return numConnFamily.SINGLE_MPO
        Catch ex As Exception
            Throw New Exception("TestPlan.GetConnectorType()::" & ex.Message)
        End Try
    End Function
    Private Sub fgPhase_AfterEdit(sender As Object, e As RowColEventArgs) Handles fgPhase.AfterEdit
        Try
            If e.Col = 1 Then
                m_phase = fgPhase(e.Row, e.Col)
            End If
        Catch ex As Exception
            MsgBox("FormPRSPRLIL.fgPhase_AfterEdit()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnLoaditems_Click(sender As Object, e As EventArgs) Handles btnLoaditems.Click
        Try
            Dim tbML As List(Of TestbandModel)
            Dim itemList As New List(Of TestitemModel)

            tbML = GetFgTestbandList_RlIl()
            itemList = GenerateTestitemList_RLIl(tbML)

            FormPRSPRLILItem.TestitemList = itemList

            FormPRSPRLILItem.product_main = GetSelectedProduct()
            FormPRSPRLILItem.ShowDialog()

        Catch ex As Exception
            MsgBox("FormPRSPRLIL.btnLoaditems_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Function GetSelectedProduct() As FACTS.Model.product_main
        Try
            Dim resp As FACTS.Model.product_main
            resp = cbProduct.SelectedItem

            Return resp

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.GetSelectedProduct()::" & ex.Message)
        End Try
    End Function
    Private Function GetFgTestbandList_RlIl() As List(Of TestbandModel)
        Try
            Dim resp As New List(Of TestbandModel)
            Dim respItem As TestbandModel

            For Each r As Row In fgTestBand.Rows

                If r.Index < 1 Then Continue For

                If r(1) = False Then Continue For

                respItem = New TestbandModel

                With respItem
                    .required = r(1)
                    .group = r(2)
                    .subunit = r(3)
                    .fiber = r(4)
                    For Each wl In r(5).ToString.Split(",")
                        .wave_length_list.Add(wl)
                    Next
                    .il_limit = r(6)
                    .rl_limit = r(7)
                    .switch_end = CType(r.UserData, TestbandModel).switch_end
                    .length_limit = r(8)
                End With

                resp.Add(respItem)

            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("GetFgTestbandList_RlIl()::" & ex.Message)
        End Try

    End Function
    Private Function GenerateTestitemList_RLIl(testbandList As List(Of TestbandModel)) As List(Of TestitemModel)
        Try
            Dim resp As New List(Of TestitemModel)
            Dim itemId As Integer = 1
            Dim groupId As Integer = 1  'Phase. Group
            Dim tItemId As Integer = 1 'Item.Group.Item.Id
            Dim msg As String = ""

            Dim bandName As String = ""

            m_length_limit_list = (New BLL.length_limitManager).SelectAll
            Dim query = From len In m_length_limit_list
                        Where m_product_main.Length_m >= len.Length_range_lower And m_product_main.Length_m <= len.Length_range_upper

            If query.Count = 0 Then Throw New Exception("not found length limit")
            If query.Count > 1 Then Throw New Exception("found more than 1 length limit")

            Dim fcildML As List(Of Model.fiber_cable_il_limit_detail) = Nothing
            Dim pciM As Model.product_cable_il
            pciM = (New BLL.product_cable_ilManager).SelectByProductMainId(m_product_main_id)
            If pciM IsNot Nothing Then fcildML = (New BLL.fiber_cable_il_limit_detailManager).SelectByLimitId(pciM.Limit_id)
            Dim fcildM As Model.fiber_cable_il_limit_detail = Nothing
            Dim cableIl As Decimal
            Dim wlId As Integer
            For Each tb In testbandList
                If tb.switch_end = True Then msg = "Pause to change the end"
                For Each wl In tb.wave_length_list
                    If tb.required = False Then Continue For
                    wlId = (New BLL.wave_lengthManager).SelectByWavelength(wl).Id
                    If fcildML IsNot Nothing Then
                        fcildM = fcildML.Find(Function(o) o.Wave_length_id = wlId)
                        If fcildM IsNot Nothing Then cableIl = fcildM.Il_limit / 1000 * m_product_main.Length_m
                    End If
                    tItemId = 1
                    Dim respItem = New TestitemModel
                    With respItem
                        .id = itemId : itemId += 1
                        .group_order = groupId
                        .group_name = tb.group
                        .meas_item = IIf(m_phase = "Connector", String.Format("IL_S{0}_F{1}_C{2}_{3}", tb.subunit, tb.fiber, groupId, wl), String.Format("IL_S{0}_F{1}_{2}", tb.subunit, tb.fiber, wl))
                        .sub_unit = tb.subunit
                        .fiber = tb.fiber
                        .wave_length = wl
                        .limit_low = -0.03
                        .limit_up = Math.Round(tb.il_limit + cableIl, 3)
                        .limit_unit = "dB"
                        .meas_required = True
                        .message = msg
                        msg = ""
                    End With
                    resp.Add(respItem)

                    If ckILOnly.Checked = False Then
                        respItem = New TestitemModel
                        With respItem
                            .id = itemId : itemId += 1
                            .group_order = groupId
                            .group_name = tb.group
                            .meas_item = IIf(m_phase = "Connector", String.Format("RL_S{0}_F{1}_C{2}_{3}", tb.subunit, tb.fiber, groupId, wl), String.Format("RL_S{0}_F{1}_{2}", tb.subunit, tb.fiber, wl))
                            .sub_unit = tb.subunit
                            .fiber = tb.fiber
                            .wave_length = wl
                            .limit_low = Math.Round(tb.rl_limit, 3)
                            .limit_up = 99
                            .limit_unit = "dB"
                            .meas_required = True
                            .message = ""
                        End With
                        resp.Add(respItem)
                    End If

                    respItem = New TestitemModel
                    With respItem
                        .id = itemId : itemId += 1
                        .group_order = groupId
                        .group_name = tb.group
                        .meas_item = IIf(m_phase = "Connector", String.Format("LEN_S{0}_F{1}_C{2}_{3}", tb.subunit, tb.fiber, groupId, wl), String.Format("LEN_S{0}_F{1}_{2}", tb.subunit, tb.fiber, wl))
                        .sub_unit = tb.subunit
                        .fiber = tb.fiber
                        .wave_length = wl
                        .limit_low = Math.Round(m_product_main.Length_m + query.Single.Length_limit_low, 3)
                        .limit_up = tb.length_limit
                        .limit_unit = "M"
                        .meas_required = True
                        .message = ""
                    End With
                    resp.Add(respItem)
                Next
                groupId += 1
            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("GenerateTestitemList_RLIl()::" & ex.Message)
        End Try
    End Function
    Public Function GetProductMode() As FACTS.Model.cq_modes
        Try

            If cbMode.SelectedItem Is Nothing Then Throw New Exception("Please select one MODE.")

            Return CType(cbMode.SelectedItem, FACTS.Model.cq_modes)

        Catch ex As Exception
            Throw New Exception("FormPRSPRLIL.GetProductMode()::" & ex.Message)
        End Try
    End Function
    Public Sub SetPhaseStatus(phaseM As PhaseModel, status As EmPhaseStatus)

        Try
            Dim msM As New FACTS.Model.mode_spec
            Dim actionStr As String = ""
            With msM
                .id = phaseM.M_cq_phases.mode_spec_id
                .order_idx = phaseM.order
                If status = EmPhaseStatus.Release Then .validation = True : .validity = True : actionStr = EmSpecLogAction.Release.ToString
                If status = EmPhaseStatus.Invalid Then .validation = True : .validity = False : actionStr = EmSpecLogAction.Invalid.ToString
                If status = EmPhaseStatus.Delete Then .validation = False : .validity = False : actionStr = EmSpecLogAction.Delete.ToString
            End With

            DbOperator.UpdateDb_mode_spec(msM)

            Dim pModel As FACTS.Model.product_main = cbProduct.SelectedItem
            Dim cqM As FACTS.Model.cq_modes = GetProductMode()
            Dim slM As New FACTS.Model.spec_log
            With slM
                .product_main_id = pModel.Id
                .mode_id = cqM.mode_id
                .spec_main_id = phaseM.M_cq_phases.spec_main_id
                .phase_main_id = phaseM.M_cq_phases.phase_main_id
                .action = actionStr
                .action_descr = pModel.Product_name & " > " & cqM.mode & " > " & phaseM.M_phase.phase & " > " & actionStr
            End With

            DbOperator.AddDb_spec_log(slM)

        Catch ex As Exception
            Throw New Exception("SetPhaseStatus()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnRelease_Click(sender As Object, e As EventArgs) Handles btnRelease.Click
        Try
            Dim rIdx As Integer = fgPhase.Row
            If rIdx < 1 Then
                MsgBox("Please select one phase...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Return
            End If

            Dim phM As PhaseModel = CType(fgPhase.Rows(rIdx).UserData, PhaseModel)

            If MsgBox("Do you really release this phase to product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            SetPhaseStatus(phM, EmPhaseStatus.Release)

            Me.pbLoadTest.Minimum = 0
            Me.pbLoadTest.Value = 0
            Me.pbLoadTest.Maximum = 100

            RefreshFgPhaseList()

            MsgBox("Success to release this phase!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("btnRelease_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnViewItem_Click(sender As Object, e As EventArgs) Handles btnViewItem.Click
        Try
            Dim rowIdx As Integer = fgPhase.Row
            Dim pM As PhaseModel

            If rowIdx < 1 Then MsgBox("Please select one phase.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) : Return
            pM = fgPhase.Rows(rowIdx).UserData
            FormPRSPRLILItem.TestitemList = pM.M_testItemList
            FormPRSPRLILItem.product_main = GetSelectedProduct()
            FormPRSPRLILItem.Show()

        Catch ex As Exception
            MsgBox("btnViewItem_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnInvalid_Click(sender As Object, e As EventArgs) Handles btnInvalid.Click
        Try
            Dim rIdx As Integer = fgPhase.Row
            If rIdx < 1 Then
                MsgBox("Please select one phase...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Return
            End If

            Dim phM As PhaseModel = CType(fgPhase.Rows(rIdx).UserData, PhaseModel)
            If MsgBox("Do you really invalid this phase to product?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            SetPhaseStatus(phM, EmPhaseStatus.Invalid)

            Me.pbLoadTest.Minimum = 0
            Me.pbLoadTest.Value = 0
            Me.pbLoadTest.Maximum = 100

            RefreshFgPhaseList()

            MsgBox("Success to invalid this phase!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox("btnInvalid_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnDeletePhase_Click(sender As Object, e As EventArgs) Handles btnDeletePhase.Click
        Try
            Dim rIdx As Integer = fgPhase.Row
            If rIdx < 1 Then
                MsgBox("Please select one phase...", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Return
            End If

            Dim phM As PhaseModel = CType(fgPhase.Rows(rIdx).UserData, PhaseModel)

            If MsgBox("Do you really delete this phase?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            SetPhaseStatus(phM, EmPhaseStatus.Delete)

            Me.pbLoadTest.Minimum = 0
            Me.pbLoadTest.Value = 0
            Me.pbLoadTest.Maximum = 100

            RefreshFgPhaseList()

            MsgBox("Success to delete this phase!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("btnRelease_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub fgPhase_Click(sender As Object, e As EventArgs) Handles fgPhase.Click
        Try
            Dim r As Integer = Me.fgPhase.Row

            If r < 1 Then Return

            Dim row As Row = fgPhase.Rows(r)
            Dim pM As PhaseModel = CType(row.UserData, PhaseModel)

            If pM.ISNEW = True Then
                FormMain.tsslStaus.Text = "New"
                Return
            End If

            m_phase = fgPhase(fgPhase.Row, 1)

            Dim tbL As TestbandItem

            If pM.M_testItemList.Count = 0 Then
                pM.M_testItemList = GetDbTestitemList(pM.M_cq_phases.spec_main_id)
            End If

            tbL = GetObjTestbandList(pM.M_testItemList)

            LoadFgTestbandList_RlIl(tbL.rl_il)

            Dim specLogStr As String

            Dim slML As List(Of FACTS.Model.spec_log)
            Dim slBll As New FACTS.BLL.spec_logManager
            slML = slBll.SelectSpecMainId(pM.M_cq_phases.spec_main_id)
            If slML IsNot Nothing Then
                Dim query = From log In slML
                            Where (log.action = pM.status Or log.action = "SystemSync") Order By log.date_time Descending

                Dim slM As FACTS.Model.spec_log
                If query IsNot Nothing Then
                    If query.Any() = False Then
                        Return
                    End If
                    slM = query.First
                    Dim employeeM As FACTS.Model.employee
                    Dim employeeBll As New FACTS.BLL.employeeManager

                    If (slM.employee_id IsNot Nothing) Then
                        employeeM = employeeBll.SelectById(slM.employee_id)
                        If employeeM.name = "" Then
                            specLogStr = slM.action_descr & " by " & employeeM.login_name & " on " & slM.date_time
                        Else
                            specLogStr = slM.action_descr & " by " & employeeM.name & " on " & slM.date_time
                        End If
                    Else
                        specLogStr = slM.action_descr & " on " & slM.date_time
                    End If

                    FormMain.tsslStaus.Text = specLogStr
                End If
            Else
                FormMain.tsslStaus.Text = "Unknown"
            End If

        Catch ex As Exception
            MsgBox("fgPhase_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Function GetDbTestitemList(spec_main_id As Integer) As List(Of TestitemModel)
        Try
            Dim resp As New List(Of TestitemModel)
            Dim respItem As TestitemModel
            Dim gmBll As New FACTS.BLL.group_mainManager
            Dim gmML As List(Of FACTS.Model.group_main)
            Dim spec_detailML As List(Of Model.spec_detail)
            Dim spec_detailBll As New BLL.spec_detailManager

            Dim iId As Integer
            Dim gOrder As Integer

            gmML = gmBll.SelectAllBySpecMainId(spec_main_id)

            If gmML Is Nothing Then Return Nothing

            iId = 1
            gOrder = 1

            Me.pbLoadTest.Value = 0
            Me.pbLoadTest.Minimum = 0
            Me.pbLoadTest.Maximum = gmML.Count

            For Each gmM In gmML

                spec_detailML = spec_detailBll.SelectAllByGroupMainId(gmM.id)

                If spec_detailML Is Nothing Then Return Nothing

                Me.pbLoadTest.Value += 1

                For Each spec_detailM In spec_detailML

                    respItem = New TestitemModel

                    With respItem

                        .id = iId
                        .group_order = gOrder
                        .group_name = gmM.group_name
                        .meas_item = spec_detailM.meas_item
                        .sub_unit = spec_detailM.Sub_unit
                        .fiber = spec_detailM.Fiber
                        .wave_length = spec_detailM.Wave_length
                        .limit_low = spec_detailM.limit_low
                        .limit_up = spec_detailM.limit_up
                        .limit_unit = spec_detailM.limit_unit
                        .meas_required = spec_detailM.meas_required
                        .message = spec_detailM.message

                    End With

                    resp.Add(respItem)

                    iId += 1

                Next

                gOrder += 1

            Next

            Return resp

        Catch ex As Exception
            Throw New Exception("GetDbPhaseItemList" & ex.Message)
        End Try
    End Function
    Private Function GetObjTestbandList(tiML As List(Of TestitemModel)) As TestbandItem
        Try
            Dim resp As New TestbandItem
            Dim bandName As String

            Dim rlilMD As New Dictionary(Of String, TestbandModel)
            Dim rlilM As TestbandModel

            Dim ttype As String

            For Each tiM In tiML
                ttype = tiM.meas_item.Trim.ToUpper.Substring(0, 3)
                bandName = tiM.group_name
                Select Case ttype
                    Case "RL_"
                        rlilM = FindTestbandRlIl(bandName, rlilMD)
                        With rlilM
                            .subunit = tiM.sub_unit
                            .fiber = tiM.fiber
                            If Not .wave_length_list.Contains(tiM.wave_length) Then .wave_length_list.Add(tiM.wave_length)
                            .required = True
                            .group = bandName
                            .rl_limit = tiM.limit_low
                        End With
                    Case "IL_"
                        rlilM = FindTestbandRlIl(bandName, rlilMD)
                        With rlilM
                            .subunit = tiM.sub_unit
                            .fiber = tiM.fiber
                            If Not .wave_length_list.Contains(tiM.wave_length) Then .wave_length_list.Add(tiM.wave_length)
                            .required = True
                            .group = bandName
                            .il_limit = tiM.limit_up
                        End With
                    Case "LEN"
                        rlilM = FindTestbandRlIl(bandName, rlilMD)
                        With rlilM
                            .subunit = tiM.sub_unit
                            .fiber = tiM.fiber
                            If Not .wave_length_list.Contains(tiM.wave_length) Then .wave_length_list.Add(tiM.wave_length)
                            .required = True
                            .group = bandName
                            .length_limit = tiM.limit_up
                            Me.txtLengthLimit.Text = .length_limit
                        End With

                    Case Else
                        Throw New Exception("Found error item {" & tiM.id & ":" & tiM.meas_item & "}")
                End Select
            Next

            resp.rl_il.AddRange(rlilMD.Values)

            Return resp

        Catch ex As Exception
            Throw New Exception("GetObjTestbandList()::" & ex.Message)
        End Try
    End Function
    Private Function FindTestbandRlIl(bandName As String, ByRef libs As Dictionary(Of String, TestbandModel)) As TestbandModel
        Try
            Dim resp As New TestbandModel

            If libs.ContainsKey(bandName) = False Then
                libs.Add(bandName, resp)
            Else
                resp = libs(bandName)
            End If

            Return resp

        Catch ex As Exception
            Throw New Exception("FindTestbandRlIl()::" & ex.Message)
        End Try

    End Function

End Class

Public Enum numConnFamily
    NA = 0
    NON_MPO = 1
    SINGLE_MPO = 2
    DUAL_MPO = 3
End Enum