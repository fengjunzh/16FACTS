Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'product_wo_sn
<Serializable()>
Public Class product_wo_sn
Private _id As Integer
Private _product_wo_id As Integer
Private _product_sn_id As Integer
Private _validity As Boolean
Private _validation As Boolean
Private _validation_date As DateTime
Private _gen1 As String
Private _gen2 As String
Private _gen3 As String

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
    Public Property product_wo_id() As Integer
       Get
           Return _product_wo_id
       End Get
       Set(value As Integer)
          _product_wo_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property product_sn_id() As Integer
       Get
           Return _product_sn_id
       End Get
       Set(value As Integer)
          _product_sn_id = value
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
    Public Property validation() As Boolean
       Get
           Return _validation
       End Get
       Set(value As Boolean)
          _validation = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property validation_date() As DateTime
       Get
           Return _validation_date
       End Get
       Set(value As DateTime)
          _validation_date = value
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
End Class
