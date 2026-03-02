Public Class connector_spec_detail
    Private _id As Integer
    Private _connector_spec_main_id As Integer
    Private _wave_length_id As Integer
    Private _il_limit As Decimal
    Private _rl_limit As Decimal
    Private _gen1 As String
    Private _gen2 As String
    Private _gen3 As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Connector_spec_main_id As Integer
        Get
            Return _connector_spec_main_id
        End Get
        Set(value As Integer)
            _connector_spec_main_id = value
        End Set
    End Property

    Public Property Wave_length_id As Integer
        Get
            Return _wave_length_id
        End Get
        Set(value As Integer)
            _wave_length_id = value
        End Set
    End Property

    Public Property Il_limit As Decimal
        Get
            Return _il_limit
        End Get
        Set(value As Decimal)
            _il_limit = value
        End Set
    End Property

    Public Property Rl_limit As Decimal
        Get
            Return _rl_limit
        End Get
        Set(value As Decimal)
            _rl_limit = value
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

    Public Property Gen3 As Integer
        Get
            Return _gen3
        End Get
        Set(value As Integer)
            _gen3 = value
        End Set
    End Property
End Class
