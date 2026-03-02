Public Class connector_family
    Private _id As Integer
    Private _family_name As String
    Private _order_idx As Integer
    Private _class_id As Integer
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

    Public Property Family_name As String
        Get
            Return _family_name
        End Get
        Set(value As String)
            _family_name = value
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

    Public Property Class_id As Integer
        Get
            Return _class_id
        End Get
        Set(value As Integer)
            _class_id = value
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
        Return Family_name.ToString()
    End Function
End Class
