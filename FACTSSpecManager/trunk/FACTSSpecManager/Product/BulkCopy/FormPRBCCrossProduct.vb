Imports FACTS
Public Class FormPRBCCrossProduct
    Private m_product_main_src As FACTS.Model.product_main
    Private m_product_main_des As FACTS.Model.product_main
    Private m_mode_des As FACTS.Model.mode
    Private m_product_mode_des As FACTS.Model.product_mode
    Private m_product_name_des As String
    Private m_product_mode_id_src As Integer
    Private Des_PN_Check_Done As Boolean = False


    Public Property ProductNameDes As String
        Get
            Return m_product_name_des
        End Get
        Set(value As String)
            m_product_name_des = value
        End Set
    End Property
    Public ReadOnly Property ProductFamilyDes As String
        Get
            Try
                If cbFamily.SelectedItem Is Nothing Then Return Nothing
                Return CType(cbFamily.SelectedItem, Model.product_family).family_name
            Catch ex As Exception
                Throw New Exception("Get ProductFamilyDes()::" & ex.Message)
            End Try
        End Get
    End Property
    Private Sub FormPRBCCrossProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadFamilies()
            'LoadAllProducts()
        Catch ex As Exception
            MsgBox("FormPRBCCrossProduct_Load()::" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub LoadFamilies()
        Try
            Dim pfBll As New FACTS.BLL.product_familyManager
            Dim pfML As New List(Of FACTS.Model.product_family)

            pfML = pfBll.SelectAll

            If pfML Is Nothing Then Return
            cbFamily.Items.Clear()
            cbFamily.Tag = pfML
            cbFamily.Items.AddRange(pfML.ToArray)

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.LoadFamilies()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadAllProducts()
        Try
            Dim prodModel As List(Of FACTS.Model.product_main) = DbOperator.GetAllProducts

            Dim query = From product In prodModel
                        Where product.Family = "Input Cable" Or product.Family = "ICBR" Or product.Family = "Infrastructure" Or product.Family = "Connector"

            If query Is Nothing Then Return
            If query.Count > 0 Then cbProductSrc.Items.AddRange(query.ToArray)
        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.LoadAllProducts()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadAllModesDes()
        Try

            Dim modeML As List(Of FACTS.Model.mode)
            Dim modeBll As New FACTS.BLL.modeManager
            modeML = modeBll.SelectAll()
            cbModeDes.Items.AddRange(modeML.ToArray)

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.LoadAllProducts()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadSrcModes(product_mainM As FACTS.Model.product_main)
        Try
            If product_mainM Is Nothing Then Throw New Exception("product is null.")

            Dim id As Integer = product_mainM.Id
            Dim cmM As List(Of FACTS.Model.cq_modes)
            cmM = DbOperator.GetModesByProductId(id)
            cbModeSrc.Text = ""
            cbModeSrc.Items.Clear()
            cbModeSrc.Items.AddRange(cmM.ToArray)

        Catch ex As Exception
            Throw New Exception("FormSparaSpec.LoadSrcModes()::" & ex.Message)
        End Try
    End Sub

    Private Sub cbProductSrc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductSrc.SelectedIndexChanged
        Try
            Dim product_mainM As FACTS.Model.product_main

            product_mainM = cbProductSrc.SelectedItem
            m_product_main_src = product_mainM
            LoadSrcModes(product_mainM)

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.cbProductSrc_SelectedIndexChanged()::" & ex.Message)
        End Try
    End Sub

    Private Sub cbModeSrc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModeSrc.SelectedIndexChanged
        Try
            If cbModeSrc.SelectedItem Is Nothing Then Return

            m_product_mode_id_src = CType(cbModeSrc.SelectedItem, FACTS.Model.cq_modes).product_mode_id

            Dim cqpBll As New FACTS.BLL.cq_phasesManager()
            Dim cqpML As New List(Of FACTS.Model.cq_phases)

            ckPhase.Items.Clear()
            cqpML = cqpBll.SelectAllByProductModeId(m_product_mode_id_src, True, True)

            If cqpML Is Nothing Then Return

            For Each cqpM In cqpML
                ckPhase.Items.Add(cqpM, True)
            Next

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.cbModeSrc_SelectedIndexChanged()::" & ex.Message)
        End Try
    End Sub


    Private Sub cbModeDes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModeDes.SelectedIndexChanged
        Try
            btnCopy.Enabled = False
            If ProductNameDes = "" Then
                MsgBox("please enter product name", MsgBoxStyle.Critical, MsgBoxStyle.OkOnly)
                Me.txtProductDes.Focus()
                Return
            End If

            lstPhase.Items.Clear()

            If cbModeDes.SelectedItem Is Nothing Then Return
            m_mode_des = CType(cbModeDes.SelectedItem, FACTS.Model.mode)

            If m_product_main_des Is Nothing Then btnCopy.Enabled = True : Return

            Dim product_modeM As FACTS.Model.product_mode
            Dim product_modeBll As New FACTS.BLL.product_modeManager

            product_modeM = product_modeBll.SelectByProductMainIdAndModeId(m_product_main_des.Id, m_mode_des.id)
            m_product_mode_des = product_modeM
            If product_modeM Is Nothing Then btnCopy.Enabled = True : Return

            Dim cqpBll As New FACTS.BLL.cq_phasesManager()
            Dim cqpML As New List(Of FACTS.Model.cq_phases)

            lstPhase.Items.Clear()
            cqpML = cqpBll.SelectAllByProductModeId(m_product_mode_des.id, True, True)

            If cqpML Is Nothing Then btnCopy.Enabled = True : Return

            For Each cqpM In cqpML
                lstPhase.Items.Add(cqpM)
            Next

            MsgBox("Product: " & ProductNameDes & vbCrLf & "Mode: " & m_mode_des.mode & vbCrLf & "already has phases!", MsgBoxStyle.Critical, MsgBoxStyle.OkOnly)
            Me.txtProductDes.SelectAll()
            Me.txtProductDes.Focus()
            btnCopy.Enabled = False

        Catch ex As Exception
            MsgBox("FormPRBCCrossProduct.cbModeDes_SelectedIndexChanged()::" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            If MsgBox("Do you really copy the specifications to:" & vbCrLf & "Product<" & ProductNameDes & "> " & vbCrLf & "MODE<" & m_mode_des.mode & ">", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return
            End If

            Dim product_main_id_des As Integer
            If m_product_main_src Is Nothing Then Return

            pbCopyProgress.Minimum = 0
            pbCopyProgress.Maximum = 4 + ckPhase.Items.Count * 2
            pbCopyProgress.Value = 0

            'copy product main, extention and CA profile
            m_product_main_des = GetDbProductProfile(ProductNameDes)
            If m_product_main_des Is Nothing Then
                product_main_id_des = AddDbProductProfile(m_product_main_src)
                AddStatusMsg(String.Format("Add product name = {0}, id = {1} succeed!", ProductNameDes, product_main_id_des))
            Else
                product_main_id_des = m_product_main_des.Id
                AddStatusMsg(String.Format("Product name = {0}, id = {1} already exists", ProductNameDes, product_main_id_des))
            End If

            pbCopyProgress.Value += 1

            ' add product log
            Dim plM As New FACTS.Model.product_log
            With plM
                .product_main_id = product_main_id_des
                .action = EmProductLogAction.Create.ToString
                .action_descr = ProductNameDes & " > " & .action
            End With

            AddDb_product_log(plM)
            pbCopyProgress.Value += 1
            AddStatusMsg(String.Format("Add product log succeed!"))

            If cbModeSrc.SelectedItem Is Nothing Then Return
            If cbModeDes.SelectedItem Is Nothing Then Return

            ' add product mode
            Dim product_mode_id As Integer = AddProductMode(product_main_id_des)
            AddStatusMsg(String.Format("Add product mode with id = {0} succeed!", product_mode_id))
            pbCopyProgress.Value += 1

            ' copy phase station
            If GetDbPhaseStation(product_mode_id) Is Nothing Then AddDbPhaseStation(product_mode_id, GetDbPhaseStation(m_product_mode_id_src))
            AddStatusMsg(String.Format("Add product phase station succeed!"))
            pbCopyProgress.Value += 1

            Dim cqpM As FACTS.Model.cq_phases

            Dim msBll As New FACTS.BLL.mode_specManager
            Dim msM As FACTS.Model.mode_spec

            Dim cqmM As FACTS.Model.cq_modes
            Dim cqmBll As New FACTS.BLL.cq_modesManager
            cqmM = cqmBll.SelectValidityByProductMainId(product_main_id_des).Find(Function(o) o.mode = Me.cbModeDes.Text)

            Dim cqpDesML As New List(Of FACTS.Model.cq_phases)
            Dim cqpBll As New FACTS.BLL.cq_phasesManager

            cqpDesML = cqpBll.SelectAllByProductModeId(cqmM.product_mode_id, True, True)

            lstPhase.Items.Clear()

            For Each phase In ckPhase.CheckedItems

                cqpM = CType(phase, FACTS.Model.cq_phases)

                Try
                    ' add mode spec
                    msM = New FACTS.Model.mode_spec
                    With msM
                        .product_mode_id = product_mode_id
                        .spec_main_id = cqpM.spec_main_id
                        .order_idx = cqpM.order_idx
                        .validity = cqpM.validity
                        .validation_date = Now
                        .validation = cqpM.validation
                    End With
                    isPhaseExist(cqpDesML, cqpM.phase_main_id)
                    msBll.Add(msM)
                    lstPhase.Items.Add(cqpM.phase & " == Success ")
                    pbCopyProgress.Value += 1
                    AddStatusMsg("Add phase " & cqpM.phase & " succeed!")

                    ' add spec log
                    Dim slM As New FACTS.Model.spec_log
                    With slM
                        .product_main_id = product_main_id_des
                        .mode_id = m_mode_des.id
                        .spec_main_id = msM.spec_main_id
                        .phase_main_id = cqpM.phase_main_id
                        .action = EmSpecLogAction.Release.ToString
                        .action_descr = ProductNameDes & " > " & m_mode_des.mode & " > " & cqpM.phase & " > " & slM.action
                    End With
                    DbOperator.AddDb_spec_log(slM)
                    pbCopyProgress.Value += 1
                    AddStatusMsg("Add spec log succeed!")

                Catch ex As Exception
                    lstPhase.Items.Add(cqpM.phase & " == Error " & ex.Message)
                End Try
            Next

            AddStatusMsg("Add success!")

        Catch ex As Exception
            MsgBox("FormPRBCCrossProduct.btnCopy_Click()::" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
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

        Catch ex As Exception
            Throw New Exception("DisablePhase()::" & ex.Message)
        End Try
    End Sub
    Private Function GetDbProductProfile(product_name As String) As FACTS.Model.product_main
        Try
            Dim resp As FACTS.Model.product_main
            Dim pdBll As New FACTS.BLL.product_mainManager
            resp = pdBll.SelectByProductName(product_name)

            Return resp

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.GetProductProfile()::" & ex.Message)
        End Try
    End Function
    Private Function AddDbProductProfile(product_main_src As FACTS.Model.product_main) As Integer
        Try
            Dim pdBll As New FACTS.BLL.product_mainManager
            product_main_src.Product_name = ProductNameDes
            Return pdBll.AddReturnId(product_main_src)

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.CopyProductProfile()::" & ex.Message)
        End Try
    End Function
    Private Function GetProductMode(product_main_id As Integer, mode As String) As FACTS.Model.cq_modes
        Try
            Dim resp As List(Of FACTS.Model.cq_modes)
            Dim cqmBll As New FACTS.BLL.cq_modesManager
            resp = cqmBll.SelectValidityByProductMainId(product_main_id)
            If resp Is Nothing Then Return Nothing
            Dim query = From item In resp
                        Where item.mode = mode

            If query Is Nothing Or query.Count = 0 Then Return Nothing

            Return query.First

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.GetProductModeList()::" & ex.Message)
        End Try
    End Function
    Private Function AddProductMode(product_main_id) As Integer
        Try
            Dim pmM As New FACTS.Model.product_mode
            Dim pmBll As New FACTS.BLL.product_modeManager
            Dim product_mode_id As Integer

            Dim modeDes As FACTS.Model.mode = cbModeDes.SelectedItem

            Dim cqM As FACTS.Model.cq_modes = GetProductMode(product_main_id, modeDes.mode.Trim.ToUpper)

            If cqM IsNot Nothing Then Return cqM.product_mode_id

            With pmM
                .mode_id = modeDes.id
                .product_main_id = product_main_id
                .order_idx = 1
                .validation = True
                .validation_date = Now
                .validity = modeDes.validity
            End With

            product_mode_id = pmBll.AddReturnId(pmM)

            Return product_mode_id

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.AddProductMode()::" & ex.Message)
        End Try
    End Function

    Private Sub AddStatusMsg(Msg As String, Optional ByVal NewLine As Boolean = True)
        Try
            With txtStatus
                Msg = String.Format("[{0:HH:mm:ss.fff}] {1}", Now, Msg)
                .AppendText(Msg)
                If NewLine Then .AppendText(vbNewLine)
                .SelectionStart = Len(.Text)
            End With
        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.AddStatusMsg()::" & ex.Message)
        End Try
    End Sub

    Private Function GetSimiliarProductList(productNameDes As String, ByRef lengthMeter As Decimal) As List(Of Model.product_main)
        Try
            Dim prodML As List(Of FACTS.Model.product_main) = DbOperator.GetAllProducts

            Dim lengthMeterDes As Double = 0

            If TryParseToLength(m_product_name_des, Me.cbFamily.Text, lengthMeterDes) = False Then
                If MsgBox("Fail to parse length from product name, would you like to enter product length manually!", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Parse Product Length") = MsgBoxResult.Yes Then
                    If Me.txtLengthMeterDes.TextLength = 0 Then
                        MsgBox("Product length is empty!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Parse Product Length")
                        Me.txtLengthMeterDes.Focus()
                        Return Nothing
                    End If
                    If Double.TryParse(Me.txtLengthMeterDes.Text, lengthMeterDes) = False Then
                        MsgBox("Parse Product Length", "Product length input is wrong!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
                        Me.txtLengthMeterDes.Focus()
                        Me.txtLengthMeterDes.SelectAll()
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End If

            lengthMeter = lengthMeterDes

            Dim productParts() As String = productNameDes.Split("-")
            Dim pmDesML As New List(Of FACTS.Model.product_main)
            Dim matchPattern As String = String.Empty
            For i As Integer = 0 To productParts.Count - 2
                matchPattern += productParts(i) + "-"
            Next

            Dim query = From product In prodML
                        Where product.Product_name.StartsWith(matchPattern) And product.Product_name <> m_product_name_des
                        Order By product.Product_name

            For Each product In query
                pmDesML.Add(product)
            Next

            Return pmDesML

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.GetSimiliarProductList()::" & ex.Message)
        End Try
    End Function
    Private Sub AddDbPhaseStation(product_mode_id As Integer, cqPhaseStationML As List(Of Model.cq_product_mode_phase_station))
        Try
            Dim pmpsBll As New FACTS.BLL.product_mode_phase_stationManager
            Dim pmpsM As FACTS.Model.product_mode_phase_station = Nothing

            For Each cqPhaseStation In cqPhaseStationML
                If pmpsM Is Nothing Then pmpsM = New FACTS.Model.product_mode_phase_station
                pmpsM.product_mode_id = product_mode_id
                pmpsM.phase_station_main_id = cqPhaseStation.M_phase_station_main.id
                pmpsM.validity = True
                pmpsM.validation = True
                pmpsM.validation_date = Now
                pmpsBll.Add(pmpsM)
            Next

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.AddDbPhaseStation()::" & ex.Message)
        End Try
    End Sub
    Private Function GetDbPhaseStation(product_mode_id As Integer) As List(Of Model.cq_product_mode_phase_station)
        Try
            Dim cqpmpsBll As New FACTS.BLL.cq_product_mode_phase_stationManager
            Dim cqpmpsML As List(Of FACTS.Model.cq_product_mode_phase_station)

            cqpmpsML = cqpmpsBll.SelectAllByProductModeId(product_mode_id, True, True)

            Return cqpmpsML

        Catch ex As Exception
            Throw New Exception("FormPRBCCrossProduct.GetDbPhaseStation()::" & ex.Message)
        End Try
    End Function


    Private Sub cbFamily_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFamily.SelectedIndexChanged
        Try
            cbProductSrc.Items.Clear()
            Dim lengthMeterDes As Decimal = 0
            cbProductSrc.Items.Clear()
            cbProductSrc.Text = ""
            Dim pmDesML As List(Of FACTS.Model.product_main) = GetSimiliarProductList(ProductNameDes, lengthMeterDes)
            If lengthMeterDes = 0 Then Return
            If pmDesML Is Nothing Then
                MsgBox("Don't find any matched product which spec can be copied", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Load Source Product")
                Exit Sub
            End If
            cbProductSrc.Items.AddRange(GetSimiliarProductList(ProductNameDes, lengthMeterDes).ToArray)
            cbModeSrc.Items.Clear()
            cbModeSrc.Text = ""
            ckPhase.Items.Clear()
            Me.txtLengthMeterDes.Text = lengthMeterDes
            Me.cbModeDes.Text = ""
            Me.cbModeDes.Items.Clear()
            LoadAllModesDes()
        Catch ex As Exception
            MsgBox("FormPRBCCrossProduct.cbFamily_SelectedIndexChanged()::" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub txtProductDes_Leave(sender As Object, e As EventArgs) Handles txtProductDes.Leave
        Try
            If Me.txtProductDes.Text = "" Then Return
            If Not Des_PN_Check_Done OrElse ProductNameDes <> Me.txtProductDes.Text.Trim.ToUpper Then
                Me.btnCopy.Enabled = False
                cbFamily.Text = ""
                Des_PN_Check_Done = True
                ProductNameDes = Me.txtProductDes.Text.Trim.ToUpper
                Dim product_mainBll As New FACTS.BLL.product_mainManager
                m_product_main_des = product_mainBll.SelectByProductName(ProductNameDes)
                If m_product_main_des Is Nothing Then Return
                If MsgBox("The product you want to copy already exists, do you still continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.No Then
                    Me.txtProductDes.Focus()
                    Me.txtProductDes.SelectAll()
                    Return
                Else
                    cbFamily.Items.Clear()
                    LoadFamilies()
                    cbFamily.Text = m_product_main_des.Family
                    Me.cbProductSrc.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox("FormPRBCCrossProduct.txtProductDes_TextChanged()::" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Public Function TryParseToLength(product_name As String, product_family As String, ByRef lengthMeter As Double) As Boolean
        Try
            Dim res As Boolean = False
            Dim splitPart As String() = product_name.Split("-")
            For Each part As String In splitPart
                If part.Contains("M") Then
                    If part.EndsWith("M") Then
                        If Double.TryParse(part.Remove(part.Length - 1, 1), lengthMeter) Then
                            res = True
                            Exit For
                        End If
                        'Else
                        '    If Double.TryParse(part.Replace("M", "."), length) Then
                        '        res = True
                        '        Exit For
                        '    End If
                    End If
                End If
            Next
            Return res
        Catch ex As Exception
            Throw New Exception("Length.TryParse()::" & ex.Message)
        End Try
    End Function
End Class