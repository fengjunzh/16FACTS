Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

Public Class product_main

    Private _id As Integer
    Private _customer_id As Integer
    Private _product_name As String
    Private _cust_product_name As String
    Private _product_ver As String
    Private _product_desc As String
    Private _family As String
    Private _validity As Boolean
    Private _sn_format As String
    Private _sn_check As Boolean
    Private _subunit As Integer
    Private _fiber_per_subunit
    Private _length_m As Decimal
    Private _gen1 As String
    Private _gen2 As String
    Private _gen3 As String
    Private _gen4 As String
    Private _gen5 As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Customer_id As Integer
        Get
            Return _customer_id
        End Get
        Set(value As Integer)
            _customer_id = value
        End Set
    End Property

    Public Property Product_name As String
        Get
            Return _product_name
        End Get
        Set(value As String)
            _product_name = value
        End Set
    End Property

    Public Property Cust_product_name As String
        Get
            Return _cust_product_name
        End Get
        Set(value As String)
            _cust_product_name = value
        End Set
    End Property

    Public Property Product_ver As String
        Get
            Return _product_ver
        End Get
        Set(value As String)
            _product_ver = value
        End Set
    End Property

    Public Property Product_desc As String
        Get
            Return _product_desc
        End Get
        Set(value As String)
            _product_desc = value
        End Set
    End Property

    Public Property Family As String
        Get
            Return _family
        End Get
        Set(value As String)
            _family = value
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

    Public Property Sn_format As String
        Get
            Return _sn_format
        End Get
        Set(value As String)
            _sn_format = value
        End Set
    End Property

    Public Property Sn_check As Boolean
        Get
            Return _sn_check
        End Get
        Set(value As Boolean)
            _sn_check = value
        End Set
    End Property
    Public Property Subunit As Integer
        Get
            Return _subunit
        End Get
        Set(value As Integer)
            _subunit = value
        End Set
    End Property
    Public Property Fiber_per_subunit As Object
        Get
            Return _fiber_per_subunit
        End Get
        Set(value As Object)
            _fiber_per_subunit = value
        End Set
    End Property
    Public Property Length_m As Decimal
        Get
            Return _length_m
        End Get
        Set(value As Decimal)
            _length_m = value
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

    Public Property Gen5 As String
        Get
            Return _gen5
        End Get
        Set(value As String)
            _gen5 = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Product_name
    End Function

    Public Function CompareTo(value As product_main) As Boolean
        Try

            If Customer_id <> value.Customer_id Then Return False
            If Product_name <> value.Product_name Then Return False
            If Validity <> value.Validity Then Return False
            If Subunit <> value.Subunit Then Return False
            If Fiber_per_subunit <> value.Fiber_per_subunit Then Return False
            If Length_m <> value.Length_m Then Return False

            Return True

        Catch ex As Exception
            Throw New Exception("product_main.CompareTo()::" & ex.Message)
        End Try

    End Function
End Class
