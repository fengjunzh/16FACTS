Public Class fiber_cable_il_limit_category
    Private _id As Integer
    Private _limit_name As String
    Private _order_idx As Integer
    Private _descr As String
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

    Public Property Limit_name As String
        Get
            Return _limit_name
        End Get
        Set(value As String)
            _limit_name = value
        End Set
    End Property

    Public Property Order_idx As Integer
        Get
            Return _order_idx
        End Get
        Set(value As Integer)
            _order_idx = value
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
    Public Overrides Function ToString() As String
        Return Limit_name.ToString()
    End Function
End Class
