Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'phase_main
<Serializable()>
Public Class phase_main
  Private _id As Integer
  Private _phase As String
  Private _order_idx As Integer
  Private _descr As String
  Private _function_id As Integer
  Private _class_id As Integer
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
  Public Property phase() As String
    Get
      Return _phase
    End Get
    Set(value As String)
      _phase = value
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
  Public Property descr() As String
    Get
      Return _descr
    End Get
    Set(value As String)
      _descr = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property function_id() As Integer
    Get
      Return _function_id
    End Get
    Set(value As Integer)
      _function_id = value
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
  Public Overrides Function ToString() As String
    Return _phase
  End Function
End Class
