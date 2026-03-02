Imports System.Xml.Serialization
Namespace XmlOpera
  Namespace Format

		Public Class CATSApplications

			<XmlType("CATSApplications")>
			Public Class CATSApplicationsElement
				Implements ICloneable
				Private _ReleasedTime As DateTime
				Private _FactoryList As New List(Of FactoryElement)
				Public Sub New()

				End Sub
				Private Sub New(factoryList As List(Of FactoryElement))
					For Each fac In factoryList
						_FactoryList.Add(CType(fac.Clone, Object))
					Next
				End Sub
				Public Property ReleasedTime As DateTime
					Get
						Return _ReleasedTime
					End Get
					Set(value As DateTime)
						_ReleasedTime = value
					End Set
				End Property
				<XmlElement("Factory")>
				Public Property FactoryElementList As List(Of FactoryElement)
					Get
						Return _FactoryList
					End Get
					Set(value As List(Of FactoryElement))
						_FactoryList = value
					End Set
				End Property
				Public Function Clone() As Object Implements System.ICloneable.Clone
					Dim resp As New CATSApplicationsElement(Me.FactoryElementList)
					resp.ReleasedTime = Me.ReleasedTime
					Return resp
				End Function
			End Class

			<XmlType("App")>
			Public Class AppElement
				Implements ICloneable
				Private _Name As String
				Private _AliasName As String
				Private _ServerPath As String
				Private _LocalPath As String
				Private _SyncEnable As Boolean
				Private _Exe As String
				Public Property Name As String
					Get
						Return _Name
					End Get
					Set(value As String)
						_Name = value
					End Set
				End Property
				Public Property AliasName As String
					Get
						Return _AliasName
					End Get
					Set(value As String)
						_AliasName = value
					End Set
				End Property
				Public Property ServerPath As String
					Get
						Return IIf(_ServerPath.EndsWith("\"), _ServerPath, _ServerPath + "\")
					End Get
					Set(value As String)
						_ServerPath = IIf(value.EndsWith("\"), value, value + "\")
					End Set
				End Property
				Public Property LocalPath As String
					Get
						Return IIf(_LocalPath.EndsWith("\"), _LocalPath, _LocalPath + "\")
					End Get
					Set(value As String)
						_LocalPath = IIf(value.EndsWith("\"), value, value + "\")
					End Set
				End Property
				Public Property SyncEnable As Boolean
					Get
						Return _SyncEnable
					End Get
					Set(value As Boolean)
						_SyncEnable = value
					End Set
				End Property
				Public Property Exe As String
					Get
						Return _Exe
					End Get
					Set(value As String)
						_Exe = value
					End Set
				End Property
				Public Function Clone() As Object Implements System.ICloneable.Clone
					Return CType(Me.MemberwiseClone, Object)
				End Function
			End Class

			<XmlType("Mode")>
			Public Class ModeElement
				Implements ICloneable

				Private _Name As String
				Private _AppList As New List(Of AppElement)
				Public Sub New()

				End Sub
				Private Sub New(appElementList As List(Of AppElement))
					For Each app In appElementList
						_AppList.Add(CType(app.Clone, Object))
					Next
				End Sub
				<XmlAttribute("name")>
				Public Property Name As String
					Get
						Return _Name
					End Get
					Set(value As String)
						_Name = value
					End Set
				End Property
				<XmlElement("App")>
				Public Property AppElementList As List(Of AppElement)
					Get
						Return _AppList
					End Get
					Set(value As List(Of AppElement))
						_AppList = value
					End Set
				End Property
				Public Function Clone() As Object Implements System.ICloneable.Clone
					Dim resp As New ModeElement(Me.AppElementList)
					resp.Name = Me.Name
					Return CType(resp, Object)
				End Function
			End Class

			<XmlType("Factory")>
			Public Class FactoryElement
				Implements ICloneable
				Private _location As String
				Private _modeList As New List(Of ModeElement)
				Public Sub New()

				End Sub
				Private Sub New(modeElementList As List(Of ModeElement))
					For Each mode In modeElementList
						_modeList.Add(CType(mode.Clone, Object))
					Next
				End Sub
				<XmlAttribute("location")>
				Public Property Location As String
					Get
						Return _location
					End Get
					Set(value As String)
						_location = value
					End Set
				End Property
				<XmlElement("Mode")>
				Public Property ModeElementList As List(Of ModeElement)
					Get
						Return _modeList
					End Get
					Set(value As List(Of ModeElement))
						_modeList = value
					End Set
				End Property
				Public Function Clone() As Object Implements System.ICloneable.Clone
					Dim resp As New FactoryElement(Me.ModeElementList)
					resp.Location = Me.Location
					Return resp
				End Function
			End Class

		End Class

	End Namespace

End Namespace

