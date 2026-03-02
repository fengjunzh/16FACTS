Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports FACTS.CalibrateItem
Imports FACTS.Model

Public MustInherit Class Calibrate
    Private _TestItems As List(Of TestItem)
    Private _TestPhase As TestPhaseRlIl
    Private _Product As FACTS.Model.product_main
    Private _IVIV As IVIAVI
    Public MustOverride Function DoCal() As Boolean
    Public MustOverride ReadOnly Property CalItems As List(Of CalibrateItem)
    Public Property TestItems As List(Of TestItem)
        Get
            Return _TestItems
        End Get
        Set(value As List(Of TestItem))
            _TestItems = value
        End Set
    End Property

    Public Property TestPhase As TestPhaseRlIl
        Get
            Return _TestPhase
        End Get
        Set(value As TestPhaseRlIl)
            _TestPhase = value
        End Set
    End Property

    Public Property Product As product_main
        Get
            Return _Product
        End Get
        Set(value As product_main)
            _Product = value
        End Set
    End Property

    Public Property IVIV As IVIAVI
        Get
            Return _IVIV
        End Get
        Set(value As IVIAVI)
            _IVIV = value
        End Set
    End Property

    Public ReadOnly Property IsCalValid() As Boolean
        Get
            Dim calF As New CalibrateIOFactory
            Dim calIO As CalibrateIO
            calIO = calF.CreateInstance()
            Dim calItem As CalibrateItem
            Dim allCalItems As List(Of CalibrateItem) = calIO.TotalItems

            For Each item As CalibrateItem In CalItems
                calItem = allCalItems.Find(Function(o) o.FileName = item.FileName)
                If calItem Is Nothing Then Return False
                If calItem.CalType <> [Enum].Parse(GetType(numCalibrateType), GUI.SelectedPhaseName) Then Return False
                If Now.Subtract(calItem.CalTime).TotalHours > gCalInterval Then Return False
                If calItem.CalType = numCalibrateType.System Then gRecJumperLength = calItem.RevJumperLength
            Next

            Return True
        End Get
    End Property
End Class

Public Class CalibrateItem
    Public Property CalType As numCalibrateType '1=System, 2=Connector
    Public Property FileName As String 'Channle + Wavelength ie. C1_WL850
    Public Property Channel As Integer
    Public Property WaveLength As Integer
    Public Property Power As Decimal
    Public Property Offset As Decimal
    Public Property Length As Decimal
    Public Property MTJLength As Decimal
    Public Property RevJumperLength As Decimal
    Public Property CalTime As DateTime
    Public Property Message As String
    Public Property CalValid As Boolean
    Public Property JumperType As numJumperType
    Public Property JumperCalType As numJumperCalType
    Public Property MTJConnection As numJumperConnectionType
    Public Overrides Function ToString() As String
        Return FileName.ToString()
    End Function
End Class
Public Enum numCalibrateType
    NA = 0
    System = 1
    Connector = 2
    Connector_A = 3
    Connector_B = 4
End Enum
Public Enum numJumperType
    NA = 0
    MTJ = 1
    Receive = 2
End Enum
Public Enum numTestType
    NA = 0
    System = 1
    Connector = 2
    Pigtail = 3
End Enum
Public Enum numJumperCalType
    NA = 0
    Simulate = 1
    Real = 2
End Enum
Public Enum numJumperConnectionType
    NA = 0
    SingleMTJ = 1
    DualMTJ = 2
End Enum