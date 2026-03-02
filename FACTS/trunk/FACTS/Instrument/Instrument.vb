'*********************************************************************
' Parent class Instrument  
'
' Depedences:
' 1) AndrewIntegratedProducts.SC3-2.0
' 2) AndrewIntegratedProducts.USBFixture-1.0
' 3) NetworkAnalyzer_AgilentPNA835x  is used
' 4) NationalInstruments.Common and NationalInstruments.VisaNS for SCPI Instruments
'
' The configuration of the class depends on an XML file
' The new method requires:
' 1) an object that implements IDataTransfer
' 2) filepath of XML file
' 3) Instrumentgroup object that is a List of Instrument objects
'
' Version       Date            Comments
' ---------------------------------------
' 1.0           10 Aug. 07      First Release
' 2.0           10 Oct.07       Added SC3 Hydra Control and USB Hydra Switch Box
'*********************************************************************
Public MustInherit Class Instrument
    Private _Address As String
    Private _Port As String
    Protected _SerialNumber As String
    Protected _ModelNumber As String
    Protected _FWRevision As String
    Protected _Vendor As String
    Public Event SentMessage(ByVal Message As String)
    Protected Sub GenerateEventSentMessage(ByVal Message As String)
        'System.Windows.Forms.MessageBox.Show(Message)
        RaiseEvent SentMessage(Message)
    End Sub

    Public Name As String

    Public Property IPAddress() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property
    Public Property PortNumber As String
        Get
            Return _Port
        End Get
        Set(value As String)
            _Port = value
        End Set
    End Property
    Public Property Serial_Number() As String
        Get
            Return _SerialNumber
        End Get
        Set(value As String)
            _SerialNumber = value
        End Set
    End Property
    Public Property Model() As String
        Get
            Return _ModelNumber
        End Get
        Set(value As String)
            _ModelNumber = value
        End Set
    End Property
    Public Property FW_Revision() As String
        Get
            Return _FWRevision
        End Get
        Set(value As String)
            _FWRevision = value
        End Set
    End Property
    Public Property Vendor() As String
        Get
            Return _Vendor
        End Get
        Set(value As String)
            _Vendor = value
        End Set
    End Property
    MustOverride Function Open() As Boolean
    MustOverride Sub Close()
    MustOverride Function ConnectCMR() As Boolean

    Public Sub New()

    End Sub
End Class
