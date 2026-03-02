Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'product_mode
<Serializable()>
Public Class product_mode
Private _id As Integer
Private _product_main_id As Integer
Private _mode_id As Integer
Private _order_idx As Integer
Private _validity As Boolean
Private _validation_date As DateTime
Private _validation As Boolean

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
    Public Property product_main_id() As Integer
       Get
           Return _product_main_id
       End Get
       Set(value As Integer)
          _product_main_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property mode_id() As Integer
       Get
           Return _mode_id
       End Get
       Set(value As Integer)
          _mode_id = value
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
    Public Property validation() As Boolean
       Get
           Return _validation
       End Get
       Set(value As Boolean)
          _validation = value
       End Set
    End Property
End Class
