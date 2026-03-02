Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'mode_spec
<Serializable()>
Public Class mode_spec

  Private _id As Integer
  Private _product_mode_id As Integer
  Private _spec_main_id As Integer
  Private _order_idx As Integer
  Private _validity As Boolean
  Private _validation_date As DateTime
  Private _validation As Boolean
  Private _status As Short

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
  Public Property product_mode_id() As Integer
    Get
      Return _product_mode_id
    End Get
    Set(value As Integer)
      _product_mode_id = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property spec_main_id() As Integer
    Get
      Return _spec_main_id
    End Get
    Set(value As Integer)
      _spec_main_id = value
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
  Public Property status() As Short
    Get
      Return _status
    End Get
    Set(value As Short)
      _status = value
    End Set
  End Property
End Class
