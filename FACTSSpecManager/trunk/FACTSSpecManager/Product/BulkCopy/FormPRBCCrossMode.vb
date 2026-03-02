Public Class FormPRBCCrossMode
	Private Sub LoadProducts()
		Try
            Dim pm As List(Of FACTS.Model.product_main)
            pm = DbOperator.GetAllProducts
            cbProduct.Items.AddRange(pm.ToArray)

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossMode.LoadProducts()::" & ex.Message)
        End Try
    End Sub
    Private Sub FormBatchSpec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = FormMain
            LoadProducts()
        Catch ex As Exception
            Throw New Exception("FormPRBCCrossMode.FormBatchSpec_Load()::" & ex.Message)
        End Try

    End Sub
    Private Sub LoadModes(pmM As FACTS.Model.product_main)
        Try
            If pmM Is Nothing Then Throw New Exception("product is null.")

            Dim id As Integer = pmM.Id
            Dim cmM As List(Of FACTS.Model.cq_modes)
            cmM = DbOperator.GetModesByProductId(id)
            cbModeSrc.Text = ""
            cbModeSrc.Items.Clear()
            cbModeSrc.Items.AddRange(cmM.ToArray)

            cbModeDes.Text = ""
            cbModeDes.Items.Clear()
            cbModeDes.Items.AddRange(cmM.ToArray)

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossMode.LoadModes()::" & ex.Message)
        End Try
    End Sub
    Private Sub cbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProduct.SelectedIndexChanged
        Try
            Dim pModel As FACTS.Model.product_main

            ckPhase.Items.Clear()
            lstPhase.Items.Clear()

            pModel = cbProduct.SelectedItem
            If pModel Is Nothing Then Return

            LoadModes(pModel)

        Catch ex As Exception
            Throw New Exception("FormBatchSpec.cbProduct_SelectedIndexChanged()::" & ex.Message)
        End Try

    End Sub

    Private Sub cbModeSrc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModeSrc.SelectedIndexChanged
        Try
            Dim product_mode_id As Integer
            If cbModeSrc.SelectedItem Is Nothing Then Return

            product_mode_id = CType(cbModeSrc.SelectedItem, FACTS.Model.cq_modes).product_mode_id

            Dim cqpBll As New FACTS.BLL.cq_phasesManager()
            Dim cqpML As New List(Of FACTS.Model.cq_phases)

            ckPhase.Items.Clear()
            cqpML = cqpBll.SelectAllByProductModeId(product_mode_id, True, True)

            If cqpML Is Nothing Then Return

            For Each cqpM In cqpML
                ckPhase.Items.Add(cqpM, True)
            Next


        Catch ex As Exception
            Throw New Exception("FormBatchSpec.cbModeSrc_SelectedIndexChanged()::" & ex.Message)
        End Try
    End Sub

    Private Sub cbModeDes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModeDes.SelectedIndexChanged
        Try
            Dim product_mode_id As Integer
            If cbModeSrc.SelectedItem Is Nothing Then Return

            product_mode_id = CType(cbModeDes.SelectedItem, FACTS.Model.cq_modes).product_mode_id

            Dim cqpBll As New FACTS.BLL.cq_phasesManager()
            Dim cqpML As New List(Of FACTS.Model.cq_phases)

            lstPhase.Items.Clear()
            cqpML = cqpBll.SelectAllByProductModeId(product_mode_id, True, True)

            If cqpML Is Nothing Then Return

            For Each cqpM In cqpML
                lstPhase.Items.Add(cqpM)
            Next
        Catch ex As Exception
            Throw New Exception("FormBatchSpec.cbModeDes_SelectedIndexChanged()::" & ex.Message)
        End Try
    End Sub
    Public Sub DisablePhase(cqpML As List(Of FACTS.Model.cq_phases), phase_main_id As Integer)
        Try
            'Dim product_mode_id As Integer
            If cqpML Is Nothing Then Return

            Dim cqpBll As New FACTS.BLL.cq_phasesManager()
            Dim filterM As FACTS.Model.cq_phases


            filterM = cqpML.Find(Function(o) o.phase_main_id = phase_main_id)

            If filterM Is Nothing Then Return

            Dim msBll As New FACTS.BLL.mode_specManager
            Dim msM As FACTS.Model.mode_spec


            msM = msBll.SelectById(filterM.mode_spec_id)
            msM.validity = False
            msBll.Update(msM)



            'product_mode_id = CType(cbModeDes.SelectedItem, FACTS.Model.cq_modes).product_mode_id

            'cqpML = cqpBll.SelectAllByProductModeId(product_mode_id, True, True)


        Catch ex As Exception
            Throw New Exception("DisablePhase()::" & ex.Message)
        End Try
    End Sub
    Private Function isPhaseExist(phaseML As List(Of FACTS.Model.cq_phases), phaseID As Integer) As Boolean
        Try

            If phaseML Is Nothing Then Return False

            For Each ph In phaseML
                If ph.phase_main_id = phaseID Then DisablePhase(phaseML, phaseID)
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("isPhaseExist()::" & ex.Message)
        End Try

    End Function
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            If cbModeSrc.SelectedItem Is Nothing Then Return
            If cbModeDes.SelectedItem Is Nothing Then Return


            Dim cqpM As FACTS.Model.cq_phases

            Dim msBll As New FACTS.BLL.mode_specManager
            Dim msM As FACTS.Model.mode_spec
            'Dim mstM As FACTS.Model.mode_spec
            Dim cqmM As FACTS.Model.cq_modes
            Dim cqpDesML As New List(Of FACTS.Model.cq_phases)
            Dim cqpBll As New FACTS.BLL.cq_phasesManager

            cqmM = CType(cbModeDes.SelectedItem, FACTS.Model.cq_modes)
            cqpDesML = cqpBll.SelectAllByProductModeId(cqmM.product_mode_id, True, True)

            If MsgBox("Do you really copy the specifications to MODE<" & cqmM.mode & "> ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If

            lstPhase.Items.Clear()

            For Each phase In ckPhase.CheckedItems

                cqpM = CType(phase, FACTS.Model.cq_phases)

                Try

                    msM = New FACTS.Model.mode_spec
                    With msM
                        .product_mode_id = cqmM.product_mode_id
                        .spec_main_id = cqpM.spec_main_id
                        .order_idx = cqpM.order_idx
                        .validity = cqpM.validity
                        .validation_date = Now
                        .validation = cqpM.validation
                    End With

                    'mstM = msBll.SelectById(cqmM.product_mode_id, msM.spec_main_id)
                    'If mstM Is Nothing OrElse mstM.validation = False OrElse mstM.validity = False Then
                    isPhaseExist(cqpDesML, cqpM.phase_main_id)
                    msBll.Add(msM)
                    lstPhase.Items.Add(cqpM.phase & " == Success ")

                    Dim slM As New FACTS.Model.spec_log

                    With slM
                        .product_main_id = cqmM.product_main_id
                        .mode_id = cqmM.mode_id
                        .spec_main_id = msM.spec_main_id
                        .phase_main_id = cqpM.phase_main_id
                        .action = EmSpecLogAction.Release.ToString
                        .action_descr = cbProduct.Text & " > " & cqmM.mode & " > " & cqpM.phase & " > " & slM.action
                    End With

                    'update product_mode
                    Dim pmBll As New FACTS.BLL.product_modeManager
                    Dim pmM As FACTS.Model.product_mode

                    pmM = pmBll.SelectById(cqmM.product_mode_id)
                    pmM.validation_date = Now

                    pmBll.Update(pmM)

                    DbOperator.AddDb_spec_log(slM)

                Catch ex As Exception
                    lstPhase.Items.Add(cqpM.phase & " == Error " & ex.Message)
                End Try
            Next


        Catch ex As Exception
            MsgBox("FormBatchSpec.cbModeDes_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class