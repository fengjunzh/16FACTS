Public Class fiber_cable_il_limit_detail
    Private _id As Integer
    Private _limit_id As Integer
    Private _wave_length_id As Integer
    Private _il_limit As Decimal

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
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

End Class
