Public Class product_cable_il
    Private _id As Integer
    Private _product_main_id As Integer
    Private _limit_id As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Product_main_id As Integer
        Get
            Return _product_main_id
        End Get
        Set(value As Integer)
            _product_main_id = value
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
End Class
