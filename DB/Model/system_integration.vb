Public Class system_integration
    Private _id As Integer
    Private _instr_serial_num As String
    Private _fpd_result As Boolean
    Private _fpd_finish_datetime As DateTime
    Private _fpp_result As Boolean
    Private _fpp_finish_datetime As DateTime
    Private _spl_result As Boolean
    Private _spl_finish_datetime As DateTime
    Private _spl_channel_num As Integer
    Private _gen1 As String
    Private _gen2 As String
    Private _gen3 As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Instr_serial_num As String
        Get
            Return _instr_serial_num
        End Get
        Set(value As String)
            _instr_serial_num = value
        End Set
    End Property

    Public Property Fpd_result As Boolean
        Get
            Return _fpd_result
        End Get
        Set(value As Boolean)
            _fpd_result = value
        End Set
    End Property

    Public Property Fpd_finish_datetime As Date
        Get
            Return _fpd_finish_datetime
        End Get
        Set(value As Date)
            _fpd_finish_datetime = value
        End Set
    End Property

    Public Property Fpp_result As Boolean
        Get
            Return _fpp_result
        End Get
        Set(value As Boolean)
            _fpp_result = value
        End Set
    End Property

    Public Property Fpp_finish_datetime As Date
        Get
            Return _fpp_finish_datetime
        End Get
        Set(value As Date)
            _fpp_finish_datetime = value
        End Set
    End Property

    Public Property Spl_result As Boolean
        Get
            Return _spl_result
        End Get
        Set(value As Boolean)
            _spl_result = value
        End Set
    End Property

    Public Property Spl_finish_datetime As Date
        Get
            Return _spl_finish_datetime
        End Get
        Set(value As Date)
            _spl_finish_datetime = value
        End Set
    End Property

    Public Property Spl_channel_num As Integer
        Get
            Return _spl_channel_num
        End Get
        Set(value As Integer)
            _spl_channel_num = value
        End Set
    End Property

    Public Property Gen1 As String
        Get
            Return _gen1
        End Get
        Set(value As String)
            _gen1 = value
        End Set
    End Property

    Public Property Gen2 As String
        Get
            Return _gen2
        End Get
        Set(value As String)
            _gen2 = value
        End Set
    End Property

    Public Property Gen3 As String
        Get
            Return _gen3
        End Get
        Set(value As String)
            _gen3 = value
        End Set
    End Property
End Class
