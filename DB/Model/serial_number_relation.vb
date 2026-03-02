Public Class serial_number_relation
    Private _id As Integer
    Private _serial_number_1 As String
    Private _serial_number_2 As String
    Private _register_datetime As DateTime
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

    Public Property Serial_number_1 As String
        Get
            Return _serial_number_1
        End Get
        Set(value As String)
            _serial_number_1 = value
        End Set
    End Property

    Public Property Serial_number_2 As String
        Get
            Return _serial_number_2
        End Get
        Set(value As String)
            _serial_number_2 = value
        End Set
    End Property

    Public Property Register_datetime As Date
        Get
            Return _register_datetime
        End Get
        Set(value As Date)
            _register_datetime = value
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
