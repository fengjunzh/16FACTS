Public Module DbOperator
    Public Enum EmSpecLogAction
        Create
        Invalid
        Release
        Delete
        Update
    End Enum
    Public Enum EmProductLogAction
        Create
        Update
    End Enum
    Public Sub SwitchCATSServer(selItem As ComboxItem)
        Try
            If selItem Is Nothing Then Return

            Dim CatsConn As New FACTS.BLL.CATSManager
            CatsConn.ActivateCATS(selItem.Descr)
            Dim factory As String = selItem.Text.Substring(0, selItem.Text.IndexOf("[") - 1)
            FormMain.Text = gMyApplicationCaption & " -- " & factory
        Catch ex As Exception
            Throw New Exception("SwitchCATSServer()::" & ex.Message)
        End Try
    End Sub
    Public Function GetAllCustomers() As List(Of FACTS.Model.customer)
        Try
            Dim resp As List(Of FACTS.Model.customer)
            Dim custBll As New FACTS.BLL.customerManager

            resp = custBll.SelectAll
            If resp Is Nothing Then resp = New List(Of FACTS.Model.customer)

            Return resp

        Catch ex As Exception
            Throw New Exception("GetAllCustomers()::" & ex.Message)
        End Try
    End Function
    Public Function GetAllProducts() As List(Of FACTS.Model.product_main)
        Try
            Dim resp As List(Of FACTS.Model.product_main)
            Dim prodBll As New FACTS.BLL.product_mainManager

            resp = prodBll.SelectAll
            If resp Is Nothing Then resp = New List(Of FACTS.Model.product_main)

            Return resp

        Catch ex As Exception
            Throw New Exception("GetAllProducts()::" & ex.Message)
        End Try
    End Function
    Public Function GetModesByProductId(product_main_id As Integer) As List(Of FACTS.Model.cq_modes)
        Try
            Dim resp As List(Of FACTS.Model.cq_modes)
            Dim cqmodeBll As New FACTS.BLL.cq_modesManager

            resp = cqmodeBll.SelectAllByProductMainId(product_main_id)
            If resp Is Nothing Then resp = New List(Of FACTS.Model.cq_modes)

            Return resp

        Catch ex As Exception
            Throw New Exception("GetModesByProductId()::" & ex.Message)
        End Try
    End Function
    '    Public Function GetAllPhases() As List(Of CATS.Model.phase_main)
    '        Try
    '            Dim resp As List(Of CATS.Model.phase_main)

    '            Dim pmBll As New CATS.BLL.phase_mainManager

    '            resp = pmBll.SelectAll
    '            If resp Is Nothing Then resp = New List(Of CATS.Model.phase_main)

    '            Return resp


    '        Catch ex As Exception
    '            Throw New Exception("GetAllPhases()::" & ex.Message)
    '        End Try
    '    End Function
    '    'Public Function GetAllProductPhaseValidity(product_mode_id As Integer, validity As Boolean) As List(Of CATS.Model.cq_phases)
    '    '  Try
    '    '    Dim resp As New List(Of CATS.Model.cq_phases)
    '    '    Dim phBll As New CATS.BLL.cq_phasesManager

    '    '    resp = phBll.SelectAllByProductModeIdValidity(product_mode_id, validity)

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("GetAllProductPhaseValidity()::" & ex.Message)
    '    '  End Try
    '    'End Function
    '    'Public Function GetAllProductPhaseValidation(product_mode_id As Integer, validation As Boolean) As List(Of CATS.Model.cq_phases)
    '    '  Try
    '    '    Dim resp As New List(Of CATS.Model.cq_phases)
    '    '    Dim phBll As New CATS.BLL.cq_phasesManager

    '    '    resp = phBll.SelectAllByProductModeIdValidation(product_mode_id, validation)

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("GetAllProductPhaseValidation()::" & ex.Message)
    '    '  End Try
    '    'End Function

    '    'Public Function GetProductPortsByProductId(product_main_id As Integer) As List(Of CATS.Model.product_port)
    '    '  Try
    '    '    Dim resp As New List(Of CATS.Model.product_port)

    '    '    Dim ppModel As List(Of CATS.Model.product_port)
    '    '    Dim ppBll As New CATS.BLL.product_portManager

    '    '    ppModel = ppBll.SelectAllByProductMainId(product_main_id)

    '    '    Dim tmpP As CATS.Model.product_port

    '    '    For Each p In ppModel
    '    '      tmpP = p
    '    '      If resp.Find(Function(o) o.port_name = tmpP.port_name) Is Nothing Then
    '    '        resp.Add(p)
    '    '      End If
    '    '    Next

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("GetProductPortsByProductId()::" & ex.Message)
    '    '  End Try
    '    'End Function
    '    Public Function GetDbProductInformationList(product_main_id As Integer) As List(Of CATS.Model.cq_product_port)
    '        Try

    '            Dim resp As List(Of CATS.Model.cq_product_port)
    '            Dim ppBll As New CATS.BLL.cq_product_portManager

    '            resp = ppBll.SelectByProductMainId(product_main_id)


    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductInformationList()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function GetDbProductPortExtendList(product_main_id As Integer) As List(Of CATS.Model.cq_product_port_extend)
    '        Try

    '            Dim resp As List(Of CATS.Model.cq_product_port_extend)
    '            Dim ppeBll As New CATS.BLL.cq_product_port_extendManager

    '            resp = ppeBll.SelectByProductMainId(product_main_id)

    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductPortExtendList()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function GetDbProductDistinctPortList(product_main_id As Integer) As List(Of CATS.Model.product_port)
    '        Try
    '            Dim resp As New List(Of CATS.Model.product_port)
    '            Dim ppBll As New CATS.BLL.product_portManager
    '            Dim ppML As New List(Of CATS.Model.product_port)

    '            ppML = ppBll.SelectAllByProductMainId(product_main_id)

    '            If ppML Is Nothing Then Return Nothing

    '            For Each ppM In ppML
    '                'Dim t As Object
    '                If resp.Find(Function(o) o.port_name = ppM.port_name) Is Nothing Then
    '                    resp.Add(ppM)
    '                End If
    '            Next

    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductDistinctPortList()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function GetDbProductDistinctPortExtendList(product_main_id As Integer) As List(Of CATS.Model.cq_product_port_extend)
    '        Try
    '            Dim resp As New List(Of CATS.Model.cq_product_port_extend)
    '            Dim ppeBll As New CATS.BLL.cq_product_port_extendManager
    '            Dim ppeML As New List(Of CATS.Model.cq_product_port_extend)

    '            ppeML = ppeBll.SelectByProductMainId(product_main_id)

    '            If ppeML Is Nothing Then Return Nothing

    '            For Each ppeM In ppeML
    '                If String.IsNullOrEmpty(ppeM.M_product_port.gen1) Then ppeM.M_product_port.gen1 = ppeM.M_product_port.band_id
    '                If resp.Find(Function(o) o.M_product_port.port_name = ppeM.M_product_port.port_name) Is Nothing Then
    '                    resp.Add(ppeM)
    '                End If
    '            Next

    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductDistinctPortExtendList()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function GetDbProductDistinctPortList(ppML As List(Of CATS.Model.cq_product_port)) As List(Of CATS.Model.product_port)
    '        Try
    '            If ppML Is Nothing Then Return Nothing
    '            Dim resp As New List(Of CATS.Model.product_port)

    '            For Each ppM In ppML
    '                If String.IsNullOrEmpty(ppM.M_product_port.gen1) Then ppM.M_product_port.gen1 = ppM.M_product_port.band_id
    '                If resp.Find(Function(o) o.port_name = ppM.M_product_port.port_name) Is Nothing Then
    '                    resp.Add(ppM.M_product_port)
    '                End If
    '            Next

    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductDistinctPortList()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function GetDbProductDistinctBandIdList(ppML As List(Of CATS.Model.cq_product_port)) As List(Of Integer)
    '        Try
    '            If ppML Is Nothing Then Return Nothing
    '            Dim resp As New List(Of Integer)

    '            For Each ppM In ppML
    '                If String.IsNullOrEmpty(ppM.M_product_port.gen1) Then ppM.M_product_port.gen1 = ppM.M_product_port.band_id
    '                If Not resp.Contains(ppM.M_product_port.band_id) Then
    '                    resp.Add(ppM.M_product_port.band_id)
    '                End If
    '            Next

    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductDistinctBandList()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function GetDbProductDistinctPortByBandId(ppML As List(Of CATS.Model.cq_product_port), bandId As Integer) As List(Of CATS.Model.product_port)
    '        Try
    '            If ppML Is Nothing Then Return Nothing
    '            Dim resp As New List(Of CATS.Model.product_port)

    '            For Each ppM In ppML
    '                If String.IsNullOrEmpty(ppM.M_product_port.gen1) Then ppM.M_product_port.gen1 = ppM.M_product_port.band_id
    '                If ppM.M_product_port.band_id <> bandId OrElse resp.Exists(Function(o) o.port_name = ppM.M_product_port.port_name) Then Continue For
    '                resp.Add(ppM.M_product_port)
    '            Next

    '            Return resp

    '        Catch ex As Exception
    '            Throw New Exception("GetDbProductDistinctPortByBandId()::" & ex.Message)
    '        End Try
    '    End Function
    '    'Public Function GetProductFreqbandsByProductId(product_main_id As Integer) As List(Of CATS.Model.product_frequency)
    '    '  Try
    '    '    Dim resp As New List(Of CATS.Model.product_frequency)

    '    '    Dim ppModel As List(Of CATS.Model.product_port)
    '    '    Dim ppBll As New CATS.BLL.product_portManager
    '    '    Dim pfBll As New CATS.BLL.product_frequencyManager

    '    '    ppModel = ppBll.SelectAllByProductMainId(product_main_id)

    '    '    Dim tmpP As CATS.Model.product_port

    '    '    For Each p In ppModel
    '    '      tmpP = p
    '    '      If resp.Find(Function(o) o.id = tmpP.prod_freq_ids) Is Nothing Then
    '    '        resp.Add(pfBll.SelectById(tmpP.prod_freq_ids))
    '    '      End If
    '    '    Next

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("GetProductFreqbandsByProductId()::" & ex.Message)
    '    '  End Try
    '    'End Function

#Region "database"
    '    Public Class dbID
    '        Public virtualId As Integer
    '        Public dbId As Integer
    '        Public ordIdx As Integer
    '        'Public igen As Integer
    '        'Public sgen As String
    '    End Class
    '    'Public Enum emInventory
    '    '  Virtual = 0
    '    '  System = 1
    '    'End Enum
    '    'Public Class inventory_cq_phases
    '    '  Inherits CATS.Model.cq_phases
    '    '  Public inventory As emInventory
    '    'End Class
    '    'Public Class inventory_group_main
    '    '  Inherits CATS.Model.group_main
    '    '  Public inventory As emInventory
    '    'End Class
    '    'Public Class inventory_cq_spec_imd_details
    '    '  Inherits CATS.Model.cq_spec_imd_details
    '    '  Public inventory As emInventory
    '    'End Class
    '    'Public Class inventory_cfg_spara_main
    '    '  Inherits CATS.Model.cfg_spara_main
    '    '  Public inventory As emInventory
    '    'End Class
    '    'Public Class inventory_cfg_spara_channel
    '    '  Inherits CATS.Model.cfg_spara_channel
    '    '  Public inventory As emInventory
    '    'End Class
    '    'Public Class inventory_cfg_spara_trace
    '    '  Inherits CATS.Model.cfg_spara_trace
    '    '  Public inventory As emInventory
    '    'End Class
    Public Function ImportDb_spec_main(product_mode_id As Integer, dbItem As FACTS.Model.cq_phases) As Integer
        Try

            Return ImportDb_spec_main(dbItem)

        Catch ex As Exception
            Throw New Exception("ImportDb_spec_main()::" & ex.Message)
        End Try
    End Function

    Private Function ImportDb_spec_main(dbItem As FACTS.Model.cq_phases) As Integer
        Try
            'Dim resp As New dbID
            Dim smModel As FACTS.Model.spec_main
            Dim smBll As New FACTS.BLL.spec_mainManager
            'Dim spec_main_id As Integer


            'resp.virtualId = dbItem.spec_main_model.id
            'resp.ordIdx = dbItem.order_idx


            smModel = dbItem.spec_main_model
            smModel.validity = True
            'spec_main_id = smBll.AddReturnId(smModel)
            'resp.dbId = spec_main_id
            Return smBll.AddReturnId(smModel)

            'Return resp

        Catch ex As Exception
            Throw New Exception("ImportDb_spec_main()::" & ex.Message)
        End Try
    End Function
    '    Private Sub UpdateDb_spec_main(dbItem As CATS.Model.cq_phases)
    '        Try
    '            Dim resp As New dbID
    '            Dim smModel As CATS.Model.spec_main
    '            Dim smBll As New CATS.BLL.spec_mainManager

    '            smModel = smBll.SelectById(dbItem.spec_main_id)

    '            With smModel
    '                .spec_revision = dbItem.spec_main_model.spec_revision
    '                .spec_version = dbItem.spec_main_model.spec_version
    '            End With

    '            smBll.Update(smModel)

    '        Catch ex As Exception
    '            Throw New Exception("UpdateDb_spec_main()::" & ex.Message)
    '        End Try
    '    End Sub

    Public Function ImportDb_mode_spec(dbItem As FACTS.Model.mode_spec) As Integer
        Try
            Dim msBll As New FACTS.BLL.mode_specManager

            Return msBll.AddReturnId(dbItem)

        Catch ex As Exception
            Throw New Exception("ImportDb_mode_spec()::" & ex.Message)
        End Try
    End Function
    Public Sub UpdateDb_mode_spec(dbItem As FACTS.Model.mode_spec)
        Try
            Dim msBll As New FACTS.BLL.mode_specManager
            Dim msM As FACTS.Model.mode_spec

            msM = msBll.SelectById(dbItem.id)
            msM.order_idx = dbItem.order_idx
            msM.validation = dbItem.validation
            msM.validity = dbItem.validity
            'If (msM.validation And msM.validity) Then msM.validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
            msM.validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
            msBll.Update(msM)


        Catch ex As Exception
            Throw New Exception("UpdateDb_mode_spec()::" & ex.Message)
        End Try
    End Sub
    '    Public Function ImportDb_spec_main_algo(dbItem As CATS.Model.spec_main_algo_para) As Integer
    '        Try

    '            Dim smaBll As New CATS.BLL.spec_main_algo_paraManager

    '            Return smaBll.AddReturnId(dbItem)

    '        Catch ex As Exception
    '            Throw New Exception("ImportDb_spec_main_algo()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function UpdateDb_spec_main_algo(dbItem As CATS.Model.spec_main_algo_para) As Integer
    '        Try
    '            Dim smaM As CATS.Model.spec_main_algo_para
    '            Dim smaBll As New CATS.BLL.spec_main_algo_paraManager

    '            smaM = smaBll.SelectById(dbItem.id)

    '            smaM.algo_main_id = dbItem.algo_main_id

    '            Return smaBll.Update(smaM)

    '        Catch ex As Exception
    '            Throw New Exception("UpdateDb_spec_main_algo()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function ImportDb_spec_main_criteria(dbItem As CATS.Model.spec_main_criteria) As Integer
    '        Try

    '            Dim smcBll As New CATS.BLL.spec_main_criteriaManager

    '            Return smcBll.AddReturnId(dbItem)

    '        Catch ex As Exception
    '            Throw New Exception("ImportDb_spec_main_criteria()::" & ex.Message)
    '        End Try
    '    End Function
    '    Public Function UpdateDb_spec_main_algo(dbItem As CATS.Model.spec_main_criteria) As Integer
    '        Try
    '            Dim smcM As CATS.Model.spec_main_criteria
    '            Dim smcBll As New CATS.BLL.spec_main_criteriaManager

    '            smcM = smcBll.SelectById(dbItem.id)

    '            smcM.criteria_main_id = dbItem.criteria_main_id

    '            Return smcBll.Update(smcM)

    '        Catch ex As Exception
    '            Throw New Exception("UpdateDb_spec_main_algo()::" & ex.Message)
    '        End Try
    '    End Function

    '    'Public Sub ImportDb_mode_spec(product_mode_id As Integer, idList As List(Of dbID))
    '    '  Try
    '    '    Dim msModel As CATS.Model.mode_spec
    '    '    Dim msBll As New CATS.BLL.mode_specManager

    '    '    'Dim ordIdx As Integer = 1
    '    '    'add spec_main table

    '    '    For Each id In idList
    '    '      msModel = New CATS.Model.mode_spec
    '    '      With msModel
    '    '        .product_mode_id = product_mode_id
    '    '        .spec_main_id = id.dbId
    '    '        .order_idx = id.ordIdx
    '    '        .validity = True
    '    '        .validation_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
    '    '        .validation = False ' set true when groups&items release
    '    '      End With
    '    '      msBll.Add(msModel)
    '    '    Next

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_mode_spec_ns()::" & ex.Message)
    '    '  End Try
    '    'End Sub
    '    'Public Function ImportDb_spec_main(product_mode_id As Integer, dbItems As List(Of inventory_cq_phases)) As List(Of dbID)
    '    '  Try
    '    '    Dim dBphModel As List(Of CATS.Model.cq_phases)

    '    '    dBphModel = DbOperator.GetAllProductPhaseValidity(product_mode_id)

    '    '    'is exist record in database for new phase
    '    '    For Each gvm As inventory_cq_phases In dbItems
    '    '      If gvm.inventory = emInventory.System Then Continue For

    '    '      If dBphModel IsNot Nothing Then
    '    '        For Each dbm As CATS.Model.cq_phases In dBphModel
    '    '          If gvm.spec_main_model.phase_main_id = dbm.phase_main_id Then
    '    '            If gvm.validation = True Then
    '    '              Throw New Exception("The phase <" & gvm.phase & "> already release in system, you can run update function to modify.")
    '    '            Else
    '    '              Throw New Exception("The New phase <" & gvm.phase & "> already in system, continue add test items.")
    '    '            End If
    '    '          End If
    '    '        Next
    '    '      End If
    '    '    Next

    '    '    Return ImportDb_spec_main(dbItems)

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_spec_main()::" & ex.Message)
    '    '  End Try
    '    'End Function

    '    'Private Function ImportDb_spec_main(dbItems As List(Of inventory_cq_phases)) As List(Of dbID)
    '    '  Try
    '    '    Dim resp As New List(Of dbID)
    '    '    Dim respItem As dbID
    '    '    Dim tmpdi As inventory_cq_phases
    '    '    Dim smModel As CATS.Model.spec_main
    '    '    Dim smBll As New CATS.BLL.spec_mainManager
    '    '    Dim spec_main_id As Integer


    '    '    For Each di As inventory_cq_phases In dbItems
    '    '      tmpdi = di
    '    '      respItem = New dbID

    '    '      respItem.virtualId = tmpdi.spec_main_model.id
    '    '      respItem.ordIdx = di.order_idx

    '    '      If tmpdi.inventory = emInventory.System Then
    '    '        respItem.dbId = tmpdi.spec_main_model.id
    '    '      Else
    '    '        smModel = tmpdi.spec_main_model
    '    '        smModel.validity = True
    '    '        spec_main_id = smBll.AddReturnId(smModel)
    '    '        respItem.dbId = spec_main_id
    '    '      End If

    '    '      If resp.Where(Function(o) o.dbId = respItem.dbId And o.virtualId = respItem.virtualId).Count = 0 Then
    '    '        resp.Add(respItem)
    '    '      End If

    '    '    Next

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_spec_main()::" & ex.Message)
    '    '  End Try
    '    'End Function

    '    'Public Function ImportDb_cfg_spara_main(spec_mainIdList As List(Of dbID), dbItems As List(Of inventory_cfg_spara_main)) As List(Of dbID)
    '    '  Try
    '    '    Dim resp As New List(Of dbID)
    '    '    Dim respItem As dbID
    '    '    Dim tmpdi As inventory_cfg_spara_main

    '    '    For Each di In dbItems
    '    '      tmpdi = di

    '    '      respItem = New dbID
    '    '      respItem.virtualId = tmpdi.id

    '    '      If di.inventory = emInventory.System Then
    '    '        respItem.dbId = tmpdi.id
    '    '      Else
    '    '        Dim csmBll As New CATS.BLL.cfg_spara_mainManager

    '    '        tmpdi.spec_main_id = spec_mainIdList.Find(Function(o) o.virtualId = tmpdi.spec_main_id).dbId
    '    '        respItem.dbId = csmBll.AddReturnId(tmpdi)

    '    '      End If

    '    '      If resp.Where(Function(o) o.dbId = respItem.dbId And o.virtualId = respItem.virtualId).Count = 0 Then
    '    '        resp.Add(respItem)
    '    '      End If

    '    '    Next

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_cfg_spara_main()::" & ex.Message)
    '    '  End Try
    '    'End Function

    '    'Public Function ImportDb_cfg_spara_channel(cfg_spara_mainIdList As List(Of dbID), dbItems As List(Of inventory_cfg_spara_channel)) As List(Of dbID)
    '    '  Try
    '    '    Dim resp As New List(Of dbID)
    '    '    Dim respItem As dbID
    '    '    Dim tmpdi As inventory_cfg_spara_channel

    '    '    For Each di In dbItems
    '    '      tmpdi = di

    '    '      respItem = New dbID
    '    '      respItem.virtualId = tmpdi.id

    '    '      If di.inventory = emInventory.System Then
    '    '        respItem.dbId = tmpdi.id
    '    '      Else
    '    '        Dim cscBll As New CATS.BLL.cfg_spara_channelManager

    '    '        tmpdi.cfg_spara_main_id = cfg_spara_mainIdList.Find(Function(o) o.virtualId = tmpdi.cfg_spara_main_id).dbId
    '    '        respItem.dbId = cscBll.AddReturnId(tmpdi)

    '    '      End If

    '    '      If resp.Where(Function(o) o.dbId = respItem.dbId And o.virtualId = respItem.virtualId).Count = 0 Then
    '    '        resp.Add(respItem)
    '    '      End If

    '    '    Next

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_cfg_spara_channel()::" & ex.Message)
    '    '  End Try
    '    'End Function
    '    'Public Function ImportDb_cfg_spara_trace(cfg_spara_chIdList As List(Of dbID), dbItems As List(Of inventory_cfg_spara_trace)) As List(Of dbID)
    '    '  Try
    '    '    Dim resp As New List(Of dbID)
    '    '    Dim respItem As dbID
    '    '    Dim tmpdi As inventory_cfg_spara_trace

    '    '    For Each di In dbItems
    '    '      tmpdi = di

    '    '      respItem = New dbID
    '    '      respItem.virtualId = tmpdi.id

    '    '      If di.inventory = emInventory.System Then
    '    '        respItem.dbId = tmpdi.id
    '    '      Else
    '    '        Dim cstBll As New CATS.BLL.cfg_spara_traceManager

    '    '        tmpdi.cfg_spara_channel_id = cfg_spara_chIdList.Find(Function(o) o.virtualId = tmpdi.cfg_spara_channel_id).dbId
    '    '        respItem.dbId = cstBll.AddReturnId(tmpdi)

    '    '      End If

    '    '      If resp.Where(Function(o) o.dbId = respItem.dbId And o.virtualId = respItem.virtualId).Count = 0 Then
    '    '        resp.Add(respItem)
    '    '      End If

    '    '    Next

    '    '    Return resp

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_cfg_spara_trace()::" & ex.Message)
    '    '  End Try
    '    'End Function
    Public Function ImportDb_group_main(item As FACTS.Model.group_main) As Integer
        Try

            Dim gpBll As New FACTS.BLL.group_mainManager

            Return gpBll.AddReturnId(item)

        Catch ex As Exception
            Throw New Exception("ImportDb_group_main()::" & ex.Message)
        End Try
    End Function
    Public Function ImportDb_spec_detail(item As FACTS.Model.spec_detail) As Integer
        Try
            Dim sdBll As New FACTS.BLL.spec_detailManager

            Return sdBll.AddReturnId(item)

        Catch ex As Exception
            Throw New Exception("ImportDb_spec_detail()::" & ex.Message)
        End Try
    End Function
    '    Public Sub ImportDb_spec_imd_detail(item As CATS.Model.spec_imd_detail)
    '        Try
    '            Dim sidBll As New CATS.BLL.spec_imd_detailManager

    '            sidBll.Add(item)

    '        Catch ex As Exception
    '            Throw New Exception("ImportDb_spec_imd_detail()::" & ex.Message)
    '        End Try
    '    End Sub
    '    Public Sub ImportDb_spec_spara_detail(item As CATS.Model.spec_spara_detail)
    '        Try
    '            Dim sidBll As New CATS.BLL.spec_spara_detailManager

    '            sidBll.Add(item)

    '        Catch ex As Exception
    '            Throw New Exception("ImportDb_spec_spara_detail()::" & ex.Message)
    '        End Try
    '    End Sub
    '    Public Sub ImportDb_spec_spara_detail_tdr(item As CATS.Model.spec_spara_detail_tdr)
    '        Try
    '            Dim ssd_tdrBll As New CATS.BLL.spec_spara_detail_tdrManager

    '            ssd_tdrBll.Add(item)

    '        Catch ex As Exception
    '            Throw New Exception("ImportDb_spec_spara_detail_tdr()::" & ex.Message)
    '        End Try
    '    End Sub
    '    'Public Sub ImportDb_spec_imd_detail(dbItems As List(Of inventory_cq_spec_imd_details), spec_detailIdList As List(Of dbID))
    '    '  Try
    '    '    Dim tmpdi As inventory_cq_spec_imd_details

    '    '    For Each di In dbItems

    '    '      tmpdi = di

    '    '      If di.inventory = emInventory.System Then

    '    '      Else
    '    '        Dim sidBll As New CATS.BLL.spec_imd_detailManager
    '    '        Dim id As Integer

    '    '        '由Excel中虚拟ID找到数据库实际ID
    '    '        tmpdi.spec_imd_detail.spec_detail_id = spec_detailIdList.Find(Function(o) o.virtualId = tmpdi.spec_imd_detail.spec_detail_id).dbId
    '    '        'tmpdi.spec_imd_detail.cfg_imd_main_id = 7
    '    '        id = sidBll.Add(tmpdi.spec_imd_detail)

    '    '      End If

    '    '    Next

    '    '  Catch ex As Exception
    '    '    Throw New Exception("ImportDb_spec_imd_detail()::" & ex.Message)
    '    '  End Try
    '    'End Sub

    '    Public Sub UpdateDb_mode_spec_validation(product_mode_id As Integer, spec_main_id As Integer)
    '        Try
    '            Dim msModel As CATS.Model.mode_spec
    '            Dim msBll As New CATS.BLL.mode_specManager


    '            msModel = msBll.SelectById(product_mode_id, spec_main_id)
    '            msModel.validation = True
    '            msBll.Update(msModel)

    '        Catch ex As Exception
    '            Throw New Exception("UpdateDb_spec_main_validation()::" & ex.Message)
    '        End Try
    '    End Sub

    Public Sub AddDb_spec_log(slM As FACTS.Model.spec_log)
        Try
            Dim slBll As New FACTS.BLL.spec_logManager
            Dim userName As String = Environment.UserName.ToString.ToUpper
            Dim epM As FACTS.Model.employee = (New FACTS.BLL.employeeManager).SelectByLoginname(userName)

            slM.employee_id = epM.id
            slM.factory_id = epM.factory_id
            slM.date_time = Now
            slM.stuffer_name = Application.ProductName
            slM.stuffer_version = Application.ProductVersion

            Dim ctrlBll As New FACTS.BLL.controllerManager
            Dim ctrlM As New FACTS.Model.controller

            With ctrlM
                .name = My.Computer.Name.ToString.Trim
                .location = " "
                .owner_id = slM.employee_id
                .factory_id = slM.factory_id
                .gen1 = ""
                .gen2 = ""
                .gen3 = ""
            End With

            Dim controller_id As Integer = ctrlBll.AddReturnId(ctrlM)

            slM.controller_id = controller_id

            If slBll.Add(slM) = False Then Throw New Exception("add spec log message.")

        Catch ex As Exception
            Throw New Exception("AddDb_spec_log()::" & ex.Message)
        End Try
    End Sub
    Public Sub AddDb_product_log(plM As FACTS.Model.product_log)
        Try
            Dim plBll As New FACTS.BLL.product_logManager
            Dim userName As String = Environment.UserName.ToString.ToUpper
            Dim epM As FACTS.Model.employee = (New FACTS.BLL.employeeManager).SelectByLoginname(userName)


            Dim ctrlBll As New FACTS.BLL.controllerManager
            Dim ctrlM As New FACTS.Model.controller

            With ctrlM
                .name = My.Computer.Name.ToString.Trim
                .location = " "
                .owner_id = epM.id
                .factory_id = epM.factory_id
                .gen1 = ""
                .gen2 = ""
                .gen3 = ""
            End With

            Dim controller_id As Integer = ctrlBll.AddReturnId(ctrlM)

            With plM
                .date_time = Now
                .employee_id = epM.id
                .controller_id = controller_id
                .factory_id = epM.factory_id
                .stuffer_name = Application.ProductName
                .stuffer_version = Application.ProductVersion
            End With

            If plBll.Add(plM) = False Then Throw New Exception("add product log message.")

        Catch ex As Exception
            Throw New Exception("AddDb_product_log()::" & ex.Message)
        End Try
    End Sub
#End Region
End Module
