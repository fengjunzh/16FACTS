Public Class cq_fiber_cable_il_limit
    Private _db_id As Integer 'fiber_cable_il_limit.id
    Private _limit_id As Integer
    Private _limit_name As String
    Private _wave_length_id As Integer
    Private _wave_length As Integer
    Private _il_limit As Decimal
    Public Property Db_id As Integer
        Get
            Return _db_id
        End Get
        Set(value As Integer)
            _db_id = value
        End Set
    End Property
    Public Property Limit_id As Integer
        Get
            Return _limit_id
        End Get
        Set(value As Integer)
            _limit_id = value
        End Set
    End Property

    Public Property Limit_name As String
        Get
            Return _limit_name
        End Get
        Set(value As String)
            _limit_name = value
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

    Public Property Wave_length As Integer
        Get
            Return _wave_length
        End Get
        Set(value As Integer)
            _wave_length = value
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
End Class
