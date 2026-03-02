Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'product_family
<Serializable()>
Public Class product_family
Private _id As Integer
Private _order_idx As Integer
Private _family_name As String
Private _class_id As Integer
Private _validity As Boolean
Private _gen1 As String
Private _gen2 As String
Private _gen3 As String
Private _gen4 As String
Private _gen5 As Integer

''' <summary>
''' id
''' </summary>
    Public Property id() As Integer
       Get
           Return _id
       End Get
       Set(value As Integer)
          _id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property order_idx() As Integer
       Get
           Return _order_idx
       End Get
       Set(value As Integer)
          _order_idx = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property family_name() As String
       Get
           Return _family_name
       End Get
       Set(value As String)
          _family_name = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property class_id() As Integer
       Get
           Return _class_id
       End Get
       Set(value As Integer)
          _class_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property validity() As Boolean
       Get
           Return _validity
       End Get
       Set(value As Boolean)
          _validity = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property gen1() As String
       Get
           Return _gen1
       End Get
       Set(value As String)
          _gen1 = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property gen2() As String
       Get
           Return _gen2
       End Get
       Set(value As String)
          _gen2 = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property gen3() As String
       Get
           Return _gen3
       End Get
       Set(value As String)
          _gen3 = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property gen4() As String
       Get
           Return _gen4
       End Get
       Set(value As String)
          _gen4 = value
       End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property gen5() As Integer
        Get
            Return _gen5
        End Get
        Set(value As Integer)
            _gen5 = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _family_name
    End Function
End Class
