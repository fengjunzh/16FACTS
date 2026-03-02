Imports C1.Win.C1FlexGrid
Imports FACTS
Imports FACTS.Model
Imports FACTSSpecManager.GlobalVariable
Imports System.Drawing.Drawing2D

Public Class FormPRProfile
    Private m_product_log As String
    Public ReadOnly Property ProdModel As FACTS.Model.product_main
        Get
            Try
                Dim resp As FACTS.Model.product_main
                resp = cbProduct.SelectedItem
                If resp Is Nothing Then
                    resp = New FACTS.Model.product_main
                    resp.Product_name = cbProduct.Text.Trim.ToUpper
                    resp.Family = Me.cbFamily.Text
                End If
                pFamily = [Enum].Parse(GetType(Family), resp.Family)
                Return resp

            Catch ex As Exception
                Throw New Exception("GetProductModel()::" & ex.Message)
            End Try

        End Get
    End Property
    Private Property CustomerModel As FACTS.Model.customer
        Get
            Try
                Dim custModel As New FACTS.Model.customer
                custModel = cmbCustomer.SelectedItem
                If custModel Is Nothing Then Throw New Exception("customer=Nothing.")
                Return custModel
            Catch ex As Exception
                Throw New Exception("CustomerName.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As FACTS.Model.customer)
            Try
                cmbCustomer.SelectedItem = value
                cmbCustomer.Text = value.cust_name
            Catch ex As Exception
                Throw New Exception("CustomerName.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    Private Property ProdCustName As String
        Get
            Return txtCustName.Text.ToUpper.Trim
        End Get
        Set(value As String)
            txtCustName.Text = value
        End Set
    End Property
    Private Property ProdVersion As String
        Get
            Return txtVersion.Text.ToUpper.Trim
        End Get
        Set(value As String)
            txtVersion.Text = value
        End Set
    End Property
    Private Property Subunit As Integer
        Get
            Return nudSubunit.Value
        End Get
        Set(value As Integer)
            nudSubunit.Value = value
        End Set
    End Property
    Private Property FiberPerSubunit As Integer
        Get
            Return nudFiberPerSubunit.Value
        End Get
        Set(value As Integer)
            nudFiberPerSubunit.Value = value
        End Set
    End Property
    Private Property Length_m As Decimal
        Get
            Return Decimal.Parse(txtLength.Text)
        End Get
        Set(value As Decimal)
            txtLength.Text = value
        End Set
    End Property
    Private Property ProdDescr As String
        Get
            Return txtProdDescr.Text.ToUpper.Trim
        End Get
        Set(value As String)
            txtProdDescr.Text = value
        End Set
    End Property

    Private ReadOnly Property GetProdFamily As FACTS.Model.product_family
        Get
            Return CType(cbFamily.SelectedItem, FACTS.Model.product_family)
        End Get

    End Property
    Private WriteOnly Property SetProdFamily As String
        Set(value As String)
            Dim pfML As ComboBox.ObjectCollection
            Dim pfM As FACTS.Model.product_family

            pfML = cbFamily.Items

            For Each pfM In pfML
                If pfM.family_name.Trim.ToUpper = value.Trim.ToUpper Then
                    cbFamily.SelectedItem = pfM
                    Return
                End If
            Next

        End Set
    End Property
    Private Sub FormPRProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = FormMain

            LoadAllProducts()

            LoadCustomers()

            LoadFamilies()

            InitFgILLimit()

            LoadFiberCableIlCategory()

            LoadConnectorSpec()

        Catch ex As Exception
            MsgBox("FormPRProfile_Load()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Load Form Error")
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
            Throw New Exception("LoadFamilies()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadCustomers()
        Try
            Dim custModel As List(Of FACTS.Model.customer) = DbOperator.GetAllCustomers
            cmbCustomer.Items.AddRange(custModel.ToArray)
            If cmbCustomer.Items.Count >= 1 Then cmbCustomer.SelectedIndex = 0
        Catch ex As Exception
            Throw New Exception("LoadCustomers()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadAllProducts()
        Try
            Dim prodModel As List(Of FACTS.Model.product_main) = DbOperator.GetAllProducts

            cbProduct.Items.AddRange(prodModel.ToArray)

        Catch ex As Exception
            Throw New Exception("LoadAllProducts()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim prodId As Integer

            prodId = AddProductInfo()

            If prodId = 0 Then Return

            If cb1500Spec.SelectedItem IsNot Nothing Then
                Dim pcs1500M As New Model.product_connector_spec_1500
                Dim pcs1500Bll As New BLL.product_connector_spec_1500Manager
                With pcs1500M
                    .Connector_spec_main_id = CType(cb1500Spec.SelectedItem, Model.connector_spec_main).Id
                    .Product_main_id = prodId
                End With
                pcs1500Bll.Add(pcs1500M)
            End If

            If cb1501Spec.SelectedItem IsNot Nothing Then
                Dim pcs1501M As New Model.product_connector_spec_1501
                Dim pcs1501Bll As New BLL.product_connector_spec_1501Manager
                With pcs1501M
                    .Connector_spec_main_id = CType(cb1501Spec.SelectedItem, Model.connector_spec_main).Id
                    .Product_main_id = prodId
                End With
                pcs1501Bll.Add(pcs1501M)
            End If

            If Me.ckAddIL.Checked And Me.cbLimitName.SelectedItem IsNot Nothing Then
                Dim pciM As New Model.product_cable_il
                Dim pciBll As New BLL.product_cable_ilManager
                With pciM
                    .Product_main_id = prodId
                    .Limit_id = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id
                End With
                pciBll.Add(pciM)
            End If

            Dim plM As New FACTS.Model.product_log
            With plM
                .product_main_id = prodId
                .action = EmProductLogAction.Create.ToString
                .action_descr = ProdModel.Product_name & " > " & .action
            End With

            AddDb_product_log(plM)
            FormMain.tsslStaus.Text = plM.action_descr

            MsgBox("Success Add.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox("btnAdd_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Add Product Error")
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If MsgBox("Do you really want to update this product information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                UpdateProductInfo()

                If cb1500Spec.SelectedItem IsNot Nothing Then
                    Dim pcs1500M As Model.product_connector_spec_1500
                    Dim pcs1500Bll As New BLL.product_connector_spec_1500Manager
                    pcs1500M = pcs1500Bll.SelectByProdMainId(ProdModel.Id)
                    If pcs1500M Is Nothing Then
                        pcs1500M = New product_connector_spec_1500
                        With pcs1500M
                            .Connector_spec_main_id = CType(cb1500Spec.SelectedItem, Model.connector_spec_main).Id
                            .Product_main_id = ProdModel.Id
                        End With
                        pcs1500Bll.Add(pcs1500M)
                    Else
                        With pcs1500M
                            .Connector_spec_main_id = CType(cb1500Spec.SelectedItem, Model.connector_spec_main).Id
                        End With
                        pcs1500Bll.Update(pcs1500M)
                    End If
                End If

                If cb1501Spec.SelectedItem IsNot Nothing Then
                    Dim pcs1501M As Model.product_connector_spec_1501
                    Dim pcs1501Bll As New BLL.product_connector_spec_1501Manager
                    pcs1501M = pcs1501Bll.SelectByProdMainId(ProdModel.Id)
                    If pcs1501M Is Nothing Then
                        pcs1501M = New product_connector_spec_1501
                        With pcs1501M
                            .Connector_spec_main_id = CType(cb1501Spec.SelectedItem, Model.connector_spec_main).Id
                            .Product_main_id = ProdModel.Id
                        End With
                        pcs1501Bll.Add(pcs1501M)
                    Else
                        With pcs1501M
                            .Connector_spec_main_id = CType(cb1501Spec.SelectedItem, Model.connector_spec_main).Id
                        End With
                        pcs1501Bll.Update(pcs1501M)
                    End If
                End If

                If ckAddIL.Checked And Me.cbLimitName.SelectedItem IsNot Nothing Then
                    Dim pciM As Model.product_cable_il
                    Dim pciBll As New BLL.product_cable_ilManager
                    pciM = pciBll.SelectByProductMainId(ProdModel.Id)
                    If pciM Is Nothing Then
                        pciM = New Model.product_cable_il
                        With pciM
                            .Product_main_id = ProdModel.Id
                            .Limit_id = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id
                        End With
                        pciBll.Add(pciM)
                    Else
                        With pciM
                            .Limit_id = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id
                        End With
                        pciBll.Update(pciM)
                    End If
                End If

                Dim plM As New FACTS.Model.product_log
                With plM
                    .product_main_id = ProdModel.Id
                    .action = EmProductLogAction.Update.ToString
                    .action_descr = ProdModel.Product_name & " > " & .action
                End With

                AddDb_product_log(plM)
                FormMain.tsslStaus.Text = plM.action_descr

                MsgBox("Success update.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox("btnUpdate_Click()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Update Product Error")
        End Try
    End Sub
    Private Function AddProductInfo() As Integer
        Try
            Dim pdModel As New FACTS.Model.product_main
            Dim pdBll As New FACTS.BLL.product_mainManager

            If ProdModel.Product_name = "" Then Throw New Exception("The product name is null.")
            If Not (pdBll.SelectByProductName(ProdModel.Product_name) Is Nothing) Then
                Throw New Exception(ProdModel.Product_name & " already exists.")
            End If

            pdModel = GetProductInfo()

            If pdModel Is Nothing Then Return 0

            Return pdBll.AddReturnId(pdModel)

        Catch ex As Exception
            Throw New Exception("AddProductInfo()::" & ex.Message)
        End Try
    End Function
    Private Function GetProductInfo() As FACTS.Model.product_main
        Try
            Dim resp As New FACTS.Model.product_main
            With resp
                .Customer_id = CustomerModel.id
                .Product_name = ProdModel.Product_name
                .Cust_product_name = ProdCustName
                .Product_ver = ProdVersion
                .Product_desc = ProdDescr
                If cbFamily.SelectedItem Is Nothing Then
                    MsgBox("product family is null", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Exception")
                    Me.cbFamily.DroppedDown = True
                    Return Nothing
                End If
                .Family = GetProdFamily.family_name.Trim
                .Validity = ckProdValidity.Checked
                .Subunit = Subunit
                .Fiber_per_subunit = FiberPerSubunit
                .Length_m = Length_m
            End With

            Return resp

        Catch ex As Exception
            Throw New Exception("GetProductInfo()::" & ex.Message)
        End Try
    End Function
    Private Function UpdateProductInfo() As Boolean
        Try
            Dim pdModel As New FACTS.Model.product_main
            Dim pdBll As New FACTS.BLL.product_mainManager
            Dim product_main_id As Integer

            pdModel = pdBll.SelectByProductName(ProdModel.Product_name)
            If pdModel Is Nothing Then
                MsgBox("Not find product[" & ProdModel.Product_name & "], please add it before.")
                Return False
            End If
            product_main_id = pdModel.Id

            pdModel = GetProductInfo()
            pdModel.Id = product_main_id

            Return pdBll.Update(pdModel)

        Catch ex As Exception
            Throw New Exception("UpdateProductInfo()::" & ex.Message)
        End Try
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub cbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProduct.SelectedIndexChanged
        Try
            SetProductInfo(ProdModel)

            Dim pcs1500M As Model.product_connector_spec_1500
            Dim pcs1500Bll As New BLL.product_connector_spec_1500Manager
            pcs1500M = pcs1500Bll.SelectByProdMainId(ProdModel.Id)
            If pcs1500M IsNot Nothing Then
                Me.cb1500Spec.Text = (New BLL.connector_spec_mainManager).SelectById(pcs1500M.Connector_spec_main_id).Spec_num
            End If

            Dim pcs1501M As Model.product_connector_spec_1501
            Dim pcs1501Bll As New BLL.product_connector_spec_1501Manager
            pcs1501M = pcs1501Bll.SelectByProdMainId(ProdModel.Id)
            If pcs1501M IsNot Nothing Then
                Me.cb1501Spec.Text = (New BLL.connector_spec_mainManager).SelectById(pcs1501M.Connector_spec_main_id).Spec_num
            End If

            Dim pciM As Model.product_cable_il
            Dim pciBll As New BLL.product_cable_ilManager
            pciM = pciBll.SelectByProductMainId(ProdModel.Id)
            If pciM IsNot Nothing Then
                Me.ckAddIL.Checked = True
                Me.cbLimitName.Text = (New BLL.fiber_cable_il_limit_categoryManager).SelectById(pciM.Limit_id).Limit_name
            End If

            Dim pfBll As New FACTS.BLL.product_familyManager
            Dim pfM As FACTS.Model.product_family

            pfM = pfBll.SelectByFamily(ProdModel.Family.Trim)

            Dim plML As List(Of FACTS.Model.product_log)
            Dim plBll As New FACTS.BLL.product_logManager
            plML = plBll.SelectByProdMainId(ProdModel.Id)

            If plML IsNot Nothing Then
                Dim plM As FACTS.Model.product_log = plML.First

                Dim employeeM As FACTS.Model.employee
                Dim employeeBll As New FACTS.BLL.employeeManager
                employeeM = employeeBll.SelectById(plM.employee_id)

                If employeeM.name = "" Then
                    ProductLog = plM.action_descr & " by " & employeeM.login_name & " on " & plM.date_time
                Else
                    ProductLog = plM.action_descr & " by " & employeeM.name & " on " & plM.date_time
                End If
                FormMain.tsslStaus.Text = ProductLog
            End If

        Catch ex As Exception
            MsgBox("cbProduct_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Public Property ProductLog() As String
        Get
            Return m_product_log
        End Get
        Set(ByVal value As String)
            m_product_log = value
        End Set
    End Property
    Private Sub SetProductInfo(pm As FACTS.Model.product_main)
        Try
            Dim pdModel As New FACTS.Model.product_main
            Dim pdBll As New FACTS.BLL.product_mainManager
            Dim cBll As New FACTS.BLL.customerManager

            With pm
                ckProdValidity.Checked = pm.Validity
                CustomerModel = cBll.SelectById(pm.Customer_id)
                ProdCustName = pm.Cust_product_name
                ProdVersion = pm.Product_ver
                SetProdFamily = pm.Family
                Subunit = pm.Subunit
                FiberPerSubunit = pm.Fiber_per_subunit
                Length_m = pm.Length_m
                ProdDescr = pm.Product_desc
            End With
        Catch ex As Exception
            Throw New Exception("SetProductInfo()::" & ex.Message)
        End Try
    End Sub
    Private Sub InitFgILLimit()
        Try
            'set up grid
            fgILLimit.Clear(ClearFlags.Content)
            fgILLimit.Cols.Fixed = 1
            fgILLimit.Cols.Count = 3
            fgILLimit.Rows.Fixed = 1
            fgILLimit.Rows.Count = 1
            fgILLimit.Cols(1).Caption = "Wave Length(nm)"
            fgILLimit.Cols(2).Caption = "IL Limit(dB/1000m)"

            Dim cs As CellStyle
            cs = fgILLimit.Styles.Add("Alternate")
            cs.BackColor = Color.Azure

            FormatGrid(fgILLimit, 9, 9)

        Catch ex As Exception
            Throw New Exception("FormPRProfile.InitFgILLimit()::" & ex.Message)
        End Try
    End Sub
    Private Sub LoadFiberCableIlCategory()
        Try
            Dim fcilcML As List(Of Model.fiber_cable_il_limit_category)
            Dim fcilcBll As New BLL.fiber_cable_il_limit_categoryManager
            fcilcML = fcilcBll.SelectAll
            Me.cbLimitName.Items.Clear()
            Me.cbLimitName.Items.AddRange(fcilcML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormPRProfile.LoadFiberCableIlCategory()::" & ex.Message)
        End Try
    End Sub

    Private Sub cbLimitName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLimitName.SelectedIndexChanged
        Try
            If Me.cbLimitName.SelectedItem Is Nothing Then Return
            Dim limitId As Integer = CType(Me.cbLimitName.SelectedItem, Model.fiber_cable_il_limit_category).Id
            LoadILLimitTable(limitId)
        Catch ex As Exception
            MsgBox("FormPRProfile.cbLimitName_SelectedIndexChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Change Limit Type Error")
        End Try
    End Sub

    Private Sub ckAddIL_CheckedChanged(sender As Object, e As EventArgs) Handles ckAddIL.CheckedChanged
        Try
            Me.cbLimitName.Enabled = ckAddIL.Checked
            Me.btnCableILEdit.Enabled = ckAddIL.Checked
            Me.fgILLimit.Enabled = ckAddIL.Checked
        Catch ex As Exception
            MsgBox("ckAddIL_CheckedChanged()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub LoadILLimitTable(limitId As Integer)
        Try
            InitFgILLimit()
            Dim cqfcilML As List(Of Model.cq_fiber_cable_il_limit)
            Dim cqfcilBll As New BLL.cq_fiber_cable_il_limitManager
            cqfcilML = cqfcilBll.SelectAllByLimitId(limitId)

            If cqfcilML IsNot Nothing Then
                For Each cqfcil As Model.cq_fiber_cable_il_limit In cqfcilML
                    Dim r As Row
                    r = Me.fgILLimit.Rows.Add
                    r(1) = cqfcil.Wave_length
                    r(2) = cqfcil.Il_limit
                    r.UserData = cqfcil
                Next
            Else
                Dim wlML As List(Of Model.wave_length)
                Dim wlBll As New BLL.wave_lengthManager
                wlML = wlBll.SelectAll
                Dim r As Row
                For Each wl As Model.wave_length In wlML
                    r = Me.fgILLimit.Rows.Add
                    r(1) = wl.Wave_length
                    r(2) = 0.1
                    r.UserData = wl
                Next
            End If
            FormatGrid(fgILLimit, 9, 9)
        Catch ex As Exception
            Throw New Exception("FormPRProfile.LoadILLimitTable()::" & ex.Message)
        End Try
    End Sub

    Private Sub btnCableILEdit_Click(sender As Object, e As EventArgs) Handles btnCableILEdit.Click
        Dim frmFiberCableIL As New FormFiberCableIL
        frmFiberCableIL.ShowDialog()
    End Sub

    Private Sub fgILLimit_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fgILLimit.OwnerDrawCell
        Try
            If e.Row >= fgILLimit.Rows.Fixed And e.Col = fgILLimit.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - fgILLimit.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
            MsgBox("FormPRProfile.fgILLimit_OwnerDrawCell()::" & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub btnConnSpecEdit_Click(sender As Object, e As EventArgs) Handles btnConnSpecEdit.Click
        Dim specNum As String = ""
        If cb1500Spec.SelectedItem IsNot Nothing Then specNum = cb1500Spec.Text
        Dim frmConnectorSpec As New FormConnectorSpecDetail(specNum)
        frmConnectorSpec.ShowDialog()
        If frmConnectorSpec.DialogResult = DialogResult.OK Then
            LoadConnectorSpec()
        End If
    End Sub

    Private Sub LoadConnectorSpec()
        Try
            Dim csmBll As New BLL.connector_spec_mainManager
            Dim csmML As List(Of Model.connector_spec_main)
            csmML = csmBll.SelectAll
            Me.cb1500Spec.Items.Clear()
            Me.cb1501Spec.Items.Clear()
            Me.cb1500Spec.Items.AddRange(csmML.ToArray)
            Me.cb1501Spec.Items.AddRange(csmML.ToArray)
        Catch ex As Exception
            Throw New Exception("FormPRProfile.LoadConnectorSpec()::" & ex.Message)
        End Try
    End Sub
End Class