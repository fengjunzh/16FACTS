Public Class SCPIInstrument
    Inherits Instrument
    Private _VisaSession As TestTelnet.TelnetConnection = Nothing
    Public IDNString As String
    Protected ReadOnly Property VisaSession()
        Get
            If _VisaSession IsNot Nothing Then
                Return _VisaSession
            Else
                Throw New Exception("Access to Visa Session not possible because not intialized")
            End If
        End Get
    End Property


    Private ReadOnly Property MyModel() As String
        Get
            If MyBase.Model = "" Then
                Return MyBase.IPAddress
            Else
                Return MyBase.Model
            End If
        End Get
    End Property
    Public Overrides Function Open() As Boolean
        'Get Info Instrument
        Dim tmpInfo() As String
        Dim SCPIresp As String = ""
        Try
            _VisaSession = New TestTelnet.TelnetConnection(MyBase.IPAddress, MyBase.PortNumber)
            _VisaSession.WriteLine("*CLS")
            _VisaSession.WriteLine("*REM")
            _VisaSession.WriteLine("*IDN?")
            SCPIresp = _VisaSession.Read
            IDNString = SCPIresp
            tmpInfo = SCPIresp.Split(",")
            _Vendor = tmpInfo(0).Trim
            _ModelNumber = tmpInfo(1).Trim
            _SerialNumber = tmpInfo(2).Trim
            _FWRevision = tmpInfo(3).Trim
            Return True
        Catch exp As InvalidCastException
            Throw New Exception("Selected resource must be a message-based session")
        Catch exp As Exception
            Throw New Exception(String.Format("Got error message during opening address {0}:" +
            Environment.NewLine + "{1}" +
            Environment.NewLine + "SCPI string response: {2}", Me.IPAddress, exp.Message, SCPIresp))
        End Try
    End Function
    Public Overrides Function ConnectCMR() As Boolean
        Try
            _VisaSession = New TestTelnet.TelnetConnection(MyBase.IPAddress, 8100)
            Return True
        Catch ex As Exception
            Throw New Exception("SCPIInstrument.ConnectCMR()::" & ex.Message)
        End Try
    End Function
    Public Overrides Sub Close()
        If _VisaSession IsNot Nothing Then
            _VisaSession.DisConnect()
        End If
    End Sub
    Public Overridable Function SendSCPIComand(ByVal ComandString As String, Optional ByVal IsQueryCmd As Boolean = False) As String
        Dim resp As String = ""
        Dim IsWrite As Boolean = True

        Try
            'Check if query or write
            If ComandString.Contains("?") = True Or IsQueryCmd Then
                IsWrite = False
            End If

            _VisaSession.WriteLine(ComandString)

            If IsWrite = False Then
                resp = _VisaSession.Read
            End If

            Return resp
        Catch ex As Exception
            Throw New Exception("SCPIInstrument.SendSCPIComand()::" & ex.Message)
        End Try
    End Function

    Public Property Timeout() As Integer
        Get
            Try
                Return _VisaSession.Timeout
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Get
        Set(ByVal value As Integer)
            Try
                _VisaSession.Timeout = value
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Set
    End Property
End Class



