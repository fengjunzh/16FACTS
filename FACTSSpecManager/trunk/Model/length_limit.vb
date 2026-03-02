Public Class length_limit
    Private _id As Integer
    Private _length_range_lower As Integer
    Private _length_range_upper As Integer
    Private _length_limit_low As Decimal
    Private _length_limit_up As Decimal

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Length_range_lower As Integer
        Get
            Return _length_range_lower
        End Get
        Set(value As Integer)
            _length_range_lower = value
        End Set
    End Property

    Public Property Length_range_upper As Integer
        Get
            Return _length_range_upper
        End Get
        Set(value As Integer)
            _length_range_upper = value
        End Set
    End Property

    Public Property Length_limit_low As Decimal
        Get
            Return _length_limit_low
        End Get
        Set(value As Decimal)
            _length_limit_low = value
        End Set
    End Property

    Public Property Length_limit_up As Decimal
        Get
            Return _length_limit_up
        End Get
        Set(value As Decimal)
            _length_limit_up = value
        End Set
    End Property
End Class
