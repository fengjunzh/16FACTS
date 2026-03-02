Imports System.Xml
Imports FACTS

Public Class TestSpec
    Private _id As Int32
    Private _data As DateTime
    Public TestPhaseList As List(Of TestPhase) = Nothing
    Public Property ID() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    Public Property ValidDate() As DateTime
        Get
            Return _data
        End Get
        Set(ByVal value As DateTime)
            _data = value
        End Set
    End Property

    ReadOnly Property TestPhaseNames() As String()
        Get
            If TestPhaseList Is Nothing Then Return Nothing
            Dim steps(TestPhaseList.Count - 1) As String
            For i As Integer = 0 To steps.Length - 1
                steps(i) = TestPhaseList(i).Name
            Next
            Return steps
        End Get
    End Property
    ReadOnly Property PhaseByName(ByVal name As String) As TestPhase
        Get
            Dim res As TestPhase = Nothing

            If TestPhaseList IsNot Nothing Then
                For Each phase As TestPhase In TestPhaseList
                    If phase.Name = name Then
                        res = phase
                        Exit For
                    End If
                Next
            End If
            Return res
        End Get
    End Property

    Public Sub New(ByVal filename As String)
        Try
            If My.Computer.FileSystem.FileExists(filename) Then
                Dim XDoc As New XmlDocument
                XDoc.Load(filename)
                Dim SpecNode As XmlNode = XDoc.DocumentElement.SelectSingleNode("/TestSpec")
                ID = Int32.Parse(SpecNode.Attributes("id").Value)
                ValidDate = DateTime.Parse(SpecNode.Attributes("date").Value)

                Dim phase As TestPhaseRlIl

                If SpecNode.ChildNodes.Count > 0 Then
                    If TestPhaseList Is Nothing Then TestPhaseList = New List(Of TestPhase)
                    For Each nd As XmlNode In SpecNode.ChildNodes
                        Select Case nd.Attributes("name").Value
                            Case "System"
                                phase = New TestPhaseRlIl(nd)
                                TestPhaseList.Add(phase)
                            Case "Connector"
                                phase = New TestPhaseRlIl(nd)
                                TestPhaseList.Add(phase)
                            Case Else
                                Continue For
                        End Select
                    Next
                End If

                XDoc = Nothing
            Else
                Throw New Exception(String.Format("File '{0}' is not found!", filename))
            End If
        Catch ex As Exception
            Throw New Exception("TestSpec()::" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub SaveXML(ByVal filename As String)
        Try
            Dim XDoc As New XmlDocument
            Dim rtnd As XmlNode = XDoc.CreateElement("TestSpec")

            Dim att As XmlAttribute = XDoc.CreateAttribute("id")
            att.Value = ID
            rtnd.Attributes.Append(att)

            att = XDoc.CreateAttribute("date")
            att.Value = ValidDate
            rtnd.Attributes.Append(att)

            If TestPhaseList IsNot Nothing Then
                For Each phase As TestPhase In TestPhaseList
                    Dim nd As XmlNode = phase.SaveXML(XDoc)
                    rtnd.AppendChild(nd)
                Next
            End If
            XDoc.AppendChild(rtnd)
            XDoc.Save(filename)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub New(ByVal cq_modes As Model.cq_modes, ByVal spec_main_id As Integer)
        Try
            With cq_modes
                ID = .product_mode_id
                ValidDate = .validation_date

                Dim cq_phasesManager As New BLL.cq_phasesManager()
                Dim cq_phasesList As List(Of Model.cq_phases) = cq_phasesManager.SelectAllByProductModeIdAll(.product_mode_id)
                cq_phasesList = cq_phasesList.Where(Function(o) o.spec_main_id = spec_main_id).ToList
                Dim phase As TestPhaseRlIl
                If cq_phasesList IsNot Nothing AndAlso cq_phasesList.Count > 0 Then
                    If TestPhaseList Is Nothing Then TestPhaseList = New List(Of TestPhase)
                    For Each ph As Model.cq_phases In cq_phasesList
                        Dim phasename As String = ph.phase
                        Select Case phasename
                            Case "System"
                                phase = New TestPhaseRlIl(ph)
                                TestPhaseList.Add(phase)
                            Case "Connector"
                                phase = New TestPhaseRlIl(ph)
                                TestPhaseList.Add(phase)
                            Case Else
                                Continue For
                        End Select
                    Next
                End If

            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub New(ByVal cq_modes As Model.cq_modes)
        Try
            With cq_modes
                ID = .product_mode_id
                ValidDate = .validation_date

                Dim cq_phasesManager As New BLL.cq_phasesManager()
                Dim cq_phasesList As List(Of Model.cq_phases) = cq_phasesManager.SelectAllByProductModeId(.product_mode_id)
                Dim phase As TestPhaseRlIl
                If cq_phasesList IsNot Nothing AndAlso cq_phasesList.Count > 0 Then
                    If TestPhaseList Is Nothing Then TestPhaseList = New List(Of TestPhase)
                    For Each ph As Model.cq_phases In cq_phasesList
                        Dim phasename As String = ph.phase
                        Select Case phasename
                            Case "System"
                                phase = New TestPhaseRlIl(ph)
                                TestPhaseList.Add(phase)
                            Case "Connector"
                                phase = New TestPhaseRlIl(ph)
                                TestPhaseList.Add(phase)
                            Case "Connector_A"
                                phase = New TestPhaseRlIl(ph)
                                TestPhaseList.Add(phase)
                            Case "Connector_B"
                                phase = New TestPhaseRlIl(ph)
                                TestPhaseList.Add(phase)
                            Case Else
                                Continue For
                        End Select
                    Next
                End If
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class

Public Class TestPhaseRlIl
    Inherits TestPhase
    Public TestGroupList As List(Of TestGroup) = Nothing
    ReadOnly Property TestGroupNames() As String()
        Get
            If TestGroupList Is Nothing Then Return Nothing
            Dim groups(TestGroupList.Count - 1) As String
            For i As Integer = 0 To groups.Length - 1
                groups(i) = TestGroupList(i).Name
            Next
            Return groups
        End Get
    End Property
    Public Sub New(ByVal NdPhase As XmlNode)
        MyBase.New(NdPhase)
        Try
            For Each nd As XmlNode In NdPhase
                Select Case nd.Name
                    Case "TestGroup"
                        If TestGroupList Is Nothing Then TestGroupList = New List(Of TestGroup)
                        Dim group As New TestGroup(nd, Me)
                        TestGroupList.Add(group)
                End Select
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Overrides Function SaveXML(ByVal XDoc As XmlDocument) As XmlNode
        Try
            Dim phnd As XmlNode = MyBase.SaveXML(XDoc)

            If TestGroupList IsNot Nothing Then
                For Each group As TestGroup In TestGroupList
                    Dim nd As XmlNode = group.SaveXML(XDoc)
                    phnd.AppendChild(nd)
                Next
            End If

            Return phnd
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Sub New(ByVal cq_phases As Model.cq_phases)
        MyBase.New(cq_phases)
        Try
            Dim cq_groupsManager As New BLL.cq_groupsManager()
            Dim cq_groupsList As List(Of Model.cq_groups) = cq_groupsManager.SelectAllBySpecMainId(cq_phases.spec_main_id)

            If cq_groupsList.Count > 0 Then
                TestGroupList = New List(Of TestGroup)
                For Each gp As Model.cq_groups In cq_groupsList
                    Dim group As New TestGroup(gp, Me)
                    TestGroupList.Add(group)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
End Class
Public Class TestPhase
    Private _id As Int32
    Private _date As DateTime
    Private _name As String
    Private _phaseID As Int32
    Private _versionSpec As String
    Public Selected As Boolean = False

    Public Property phaseID() As Int32
        Get
            Return _phaseID
        End Get
        Set(ByVal value As Int32)
            _phaseID = value
        End Set
    End Property

    Public Property ID() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    Public Property ValidDate() As DateTime
        Get
            Return _date
        End Get
        Set(ByVal value As DateTime)
            _date = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property


    Public Property VersionSpec As String
        Get
            Return _versionSpec
        End Get
        Set(value As String)
            _versionSpec = value
        End Set
    End Property
    Public Sub New(ByVal NdPhase As XmlNode)
        Try
            ID = Int32.Parse(NdPhase.Attributes("id").Value)
            phaseID = Int32.Parse(NdPhase.Attributes("phase_id").Value)
            ValidDate = DateTime.Parse(NdPhase.Attributes("date").Value)
            Name = NdPhase.Attributes("name").Value
            VersionSpec = NdPhase.Attributes("version").Value.ToUpper.Trim
        Catch ex As Exception
            Throw New Exception("TestPhase()::" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Overridable Function SaveXML(ByVal XDoc As XmlDocument) As XmlNode
        Try
            Dim nd As XmlNode = XDoc.CreateElement("TestPhase")
            Dim att As XmlAttribute = XDoc.CreateAttribute("id")
            att.Value = ID
            nd.Attributes.Append(att)
            att = XDoc.CreateAttribute("phase_id")
            att.Value = phaseID
            nd.Attributes.Append(att)
            att = XDoc.CreateAttribute("date")
            att.Value = ValidDate
            nd.Attributes.Append(att)

            att = XDoc.CreateAttribute("name")
            att.Value = Name
            nd.Attributes.Append(att)
            att = XDoc.CreateAttribute("version")
            att.Value = VersionSpec.ToUpper.Trim
            nd.Attributes.Append(att)
            Return nd

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub New(ByVal cq_phases As Model.cq_phases)
        Try
            With cq_phases
                ID = .spec_main_id
                phaseID = .phase_main_id
                ValidDate = .validation_date
                Name = .phase
                If .spec_main_model.spec_version Is Nothing Then
                    VersionSpec = ""
                Else
                    VersionSpec = .spec_main_model.spec_version.ToUpper.Trim
                End If

            End With

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class

Public Class TestGroup
    Private _id As Int32
    Private _data As DateTime
    Private _name As String
    Private _firstTestItem As TestItem
    Public TestItemList As List(Of TestItem) = Nothing
    Public ParentPhase As TestPhaseRlIl
    Public ConnectTime As Integer
    Public MeasTime As Integer
    Public Selected As Boolean = True
    Public GroupId As Integer
    Public WavelengthList As List(Of Integer) = Nothing
    Public WavelengthListStr As String
    Public Channel As Integer
    Public Property ID() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    Public Property ValidDate() As DateTime
        Get
            Return _data
        End Get
        Set(ByVal value As DateTime)
            _data = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    ReadOnly Property TestItemNames() As String()
        Get
            If TestItemList Is Nothing Then Return Nothing
            Dim Items(TestItemList.Count - 1) As String
            For i As Integer = 0 To Items.Length - 1
                Items(i) = TestItemList(i).Name
            Next
            Return Items
        End Get
    End Property

    ReadOnly Property FirstTestItem As TestItem
        Get
            Return Me.TestItemList.First
        End Get
    End Property

    Public Sub New(ByVal NdGroup As XmlNode, ByVal phse As TestPhaseRlIl)
        Try
            ParentPhase = phse
            ID = Int32.Parse(NdGroup.Attributes("id").Value)
            ValidDate = DateTime.Parse(NdGroup.Attributes("date").Value)
            Name = NdGroup.Attributes("name").Value
            GroupId = NdGroup.Attributes("groupId").Value

            If NdGroup.ChildNodes.Count > 0 Then
                TestItemList = New List(Of TestItem)
                For Each nd As XmlNode In NdGroup
                    Dim item As New TestItem(nd, Me)
                    TestItemList.Add(item)
                Next
            End If

            ParseTestGroup()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Public Function SaveXML(ByVal XDoc As XmlDocument) As XmlNode
        Try
            Dim gpnd As XmlNode = XDoc.CreateElement("TestGroup")

            Dim att As XmlAttribute = XDoc.CreateAttribute("id")
            att.Value = ID
            gpnd.Attributes.Append(att)

            att = XDoc.CreateAttribute("date")
            att.Value = ValidDate
            gpnd.Attributes.Append(att)

            att = XDoc.CreateAttribute("name")
            att.Value = Name
            gpnd.Attributes.Append(att)

            att = XDoc.CreateAttribute("groupId")
            att.Value = GroupId
            gpnd.Attributes.Append(att)

            If TestItemList IsNot Nothing Then
                For Each item As TestItem In TestItemList
                    Dim nd As XmlNode = item.SaveXML(XDoc)
                    gpnd.AppendChild(nd)
                Next
            End If
            Return gpnd

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub New(ByVal Group As Model.cq_groups, ByVal phse As TestPhaseRlIl)
        Try
            ParentPhase = phse
            With Group
                ID = .group_main_id
                ValidDate = .validation_date
                Name = .group_name
                GroupId = .group_id

                Dim spec_detailManager As New BLL.spec_detailManager()
                Dim spec_detailML As List(Of Model.spec_detail) = spec_detailManager.SelectAllByGroupMainId(.group_main_id)

                If spec_detailML IsNot Nothing AndAlso spec_detailML.Count > 0 Then
                    TestItemList = New List(Of TestItem)
                    For Each spec_detailM As Model.spec_detail In spec_detailML
                        Dim item As New TestItem(spec_detailM, Me)
                        TestItemList.Add(item)
                    Next
                End If

            End With

            ParseTestGroup()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ParseTestGroup()
        Try
            If WavelengthList Is Nothing Then WavelengthList = New List(Of Integer)
            For Each item As TestItem In Me.TestItemList
                If Not WavelengthList.Contains(item.wave_length) Then WavelengthList.Add(item.wave_length)
            Next
            Select Case gConnectorFamily
                Case numConnFamily.NON_MPO
                    If gTestPlan.product_main.Fiber_per_subunit > 2 Then
                        If Me.FirstTestItem.fiber Mod gTestPlan.product_main.Fiber_per_subunit = 0 Then
                            Channel = gTestPlan.product_main.Fiber_per_subunit
                        Else
                            Channel = Me.FirstTestItem.fiber Mod gTestPlan.product_main.Fiber_per_subunit
                        End If
                    Else
                        Channel = IIf(Me.FirstTestItem.fiber Mod 2 = 0, 2, 1)
                    End If
                Case numConnFamily.DUAL_MPO
                    Channel = Me.FirstTestItem.fiber
                Case numConnFamily.SINGLE_MPO
                    Channel = Me.FirstTestItem.fiber
                Case Else
                    Throw New Exception("Not recognized connector family")
            End Select
            WavelengthListStr = String.Join(",", WavelengthList.ToArray)
        Catch ex As Exception
            Throw New Exception("ParseTestGroup()::" & ex.Message)
        End Try
    End Sub
    Public Overrides Function ToString() As String
        Return Name.ToString()
    End Function
End Class

Public Class TestItem
    Private _id As Int32
    Private _name As String
    Public limit_low, limit_up As Double
    Public order_idx As Int32
    Public sub_unit As Integer
    Public fiber As Integer
    Public wave_length As Integer
    Public message As String
    Public ParentGroup As TestGroup
    Public meas_required As Boolean
    Public Selected As Boolean = True

    Public Property ID() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Sub New(ByVal NdItem As XmlNode, ByVal gp As TestGroup)
        Try
            ParentGroup = gp
            ID = Int32.Parse(NdItem.Attributes("id").Value)
            Name = NdItem.Attributes("name").Value
            For Each nd As XmlNode In NdItem
                If nd.Name = "add" Then
                    Dim keystr As String = nd.Attributes("key").Value
                    Dim valuestr As String = nd.Attributes("value").Value
                    Select Case keystr
                        Case "order_idx"
                            order_idx = Int32.Parse(valuestr)
                        Case "limit_low"
                            limit_low = Double.Parse(valuestr)
                        Case "limit_up"
                            limit_up = Double.Parse(valuestr)
                        Case "sub_unit"
                            sub_unit = Int32.Parse(valuestr)
                        Case "fiber"
                            fiber = Int32.Parse(valuestr)
                        Case "wave_length"
                            wave_length = Int32.Parse(valuestr)
                        Case "message"
                            message = valuestr
                        Case "meas_required"
                            meas_required = Boolean.Parse(valuestr)
                    End Select
                End If
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Function SaveXML(ByVal XDoc As XmlDocument) As XmlNode
        Try
            Dim itnd As XmlNode = XDoc.CreateElement("TestItem")

            Dim att As XmlAttribute = XDoc.CreateAttribute("id")
            att.Value = ID
            itnd.Attributes.Append(att)

            att = XDoc.CreateAttribute("name")
            att.Value = Name
            itnd.Attributes.Append(att)

            itnd.AppendChild(AddPara(XDoc, "order_idx", order_idx))
            itnd.AppendChild(AddPara(XDoc, "limit_low", limit_low))
            itnd.AppendChild(AddPara(XDoc, "limit_up", limit_up))
            itnd.AppendChild(AddPara(XDoc, "sub_unit", sub_unit))
            itnd.AppendChild(AddPara(XDoc, "fiber", fiber))
            itnd.AppendChild(AddPara(XDoc, "wave_length", wave_length))
            itnd.AppendChild(AddPara(XDoc, "message", message))
            itnd.AppendChild(AddPara(XDoc, "meas_required", meas_required))

            Return itnd

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function AddPara(ByVal XDoc As XmlDocument, ByVal key As String, ByVal value As String)
        Try
            Dim nd As XmlNode = XDoc.CreateElement("add")

            Dim att As XmlAttribute = XDoc.CreateAttribute("key")
            att.Value = key
            nd.Attributes.Append(att)

            att = XDoc.CreateAttribute("value")
            att.Value = value
            nd.Attributes.Append(att)
            Return nd
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub New(ByVal Item As Model.spec_detail, ByVal gp As TestGroup)
        Try
            ParentGroup = gp
            With Item
                ID = .id
                Name = .meas_item
                limit_low = .limit_low
                limit_up = .limit_up
                sub_unit = .Sub_unit
                fiber = .Fiber
                wave_length = .Wave_length
                order_idx = .order_idx
                meas_required = .meas_required
                message = .message
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Overrides Function ToString() As String
        Return Name.ToString()

    End Function
End Class

