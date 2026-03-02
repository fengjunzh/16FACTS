Imports System.Xml.Serialization
Namespace XmlOpera
  Namespace Format

    Public Class CATSDbServer

      <XmlType("CATSDbServer")>
      Public Class CATSDbServerElement
        Implements System.ICloneable
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
          Dim resp As New CATSDbServerElement(_FactoryList)
          resp._ReleasedTime = _ReleasedTime
          Return CType(resp, Object)
        End Function
      End Class

      <XmlType("Factory")>
      Public Class FactoryElement
        Implements System.ICloneable

        Private _Location As String

        Private _ModeList As New List(Of ModeElement)
        Public Sub New()

        End Sub
        Public Sub New(location As String)
          _Location = location
        End Sub
        Private Sub New(modeList As List(Of ModeElement))
          For Each m In modeList
            _ModeList.Add(CType(m.Clone(), Object))
          Next
        End Sub
        <XmlAttribute("location")>
        Public Property Location As String
          Get
            Return _Location
          End Get
          Set(value As String)
            _Location = value
          End Set
        End Property

        <XmlElement("Mode")>
        Public Property ModeElementList As List(Of ModeElement)
          Get
            Return _ModeList
          End Get
          Set(value As List(Of ModeElement))
            _ModeList = value
          End Set
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
          Dim resp As New FactoryElement(Me.ModeElementList)
          resp.Location = Me.Location
          Return CType(resp, Object)
        End Function
      End Class

      <XmlType("Mode")>
      Public Class ModeElement
        Implements System.ICloneable

        Private _Name As String
        Private _ConnString As String
        Public Sub New()

        End Sub
        Public Sub New(name As String)
          _Name = name
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
        Public Property ConnString As String
          Get
            Return _ConnString
          End Get
          Set(value As String)
            _ConnString = value
          End Set
        End Property
        Public Function Clone() As Object Implements System.ICloneable.Clone
          Return CType(Me.MemberwiseClone, Object)
        End Function
      End Class

    End Class
  End Namespace
End Namespace

