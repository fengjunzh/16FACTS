Public Class product_connector_spec_1501
    Private _id As Integer
    Private _product_main_id As Integer
    Private _connector_spec_main_id As Integer

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

    Public Property Connector_spec_main_id As Integer
        Get
            Return _connector_spec_main_id
        End Get
        Set(value As Integer)
            _connector_spec_main_id = value
        End Set
    End Property
End Class
