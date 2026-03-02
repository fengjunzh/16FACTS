Public Class connector_type
    Private _id As Integer
    Private _connector_type As String
    Private _descr As String
    Private _factor As Integer
    Private _connector_family_id As Integer
    Private _validaity As Boolean
    Private _gen1 As String
    Private _gen2 As String
    Private _gen3 As String
    Private _gen4 As String
    Private _gen5 As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Connector_type As String
        Get
            Return _connector_type
        End Get
        Set(value As String)
            _connector_type = value
        End Set
    End Property

    Public Property Descr As String
        Get
            Return _descr
        End Get
        Set(value As String)
            _descr = value
        End Set
    End Property

    Public Property Factor As Integer
        Get
            Return _factor
        End Get
        Set(value As Integer)
            _factor = value
        End Set
    End Property

    Public Property Connector_family_id As Integer
        Get
            Return _connector_family_id
        End Get
        Set(value As Integer)
            _connector_family_id = value
        End Set
    End Property

    Public Property Validaity As Boolean
        Get
            Return _validaity
        End Get
        Set(value As Boolean)
            _validaity = value
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

    Public Property Gen4 As String
        Get
            Return _gen4
        End Get
        Set(value As String)
            _gen4 = value
        End Set
    End Property

    Public Property Gen5 As Integer
        Get
            Return _gen5
        End Get
        Set(value As Integer)
            _gen5 = value
        End Set
    End Property
    Public Overrides Function ToString() As String
        Return Connector_type.ToString()
    End Function
End Class
