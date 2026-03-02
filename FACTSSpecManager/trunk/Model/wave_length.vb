Public Class wave_length
    Private _id As Integer
    Private _order_id As Integer
    Private _wave_length As Integer
    Private _class_id As Integer
    Private _validity As Boolean
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

    Public Property Order_id As Integer
        Get
            Return _order_id
        End Get
        Set(value As Integer)
            _order_id = value
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

    Public Property Class_id As Integer
        Get
            Return _class_id
        End Get
        Set(value As Integer)
            _class_id = value
        End Set
    End Property

    Public Property Validity As Boolean
        Get
            Return _validity
        End Get
        Set(value As Boolean)
            _validity = value
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
        Return Wave_length.ToString()
    End Function
End Class
