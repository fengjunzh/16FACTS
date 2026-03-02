Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'group_main
<Serializable()>
Public Class group_main
Private _id As Integer
Private _spec_main_id As Integer
Private _group_id As Integer
Private _group_name As String
Private _order_idx As Integer
Private _descr As String
Private _script As String
Private _message As String
Private _validity As Boolean
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
    Public Property group_id() As Integer
       Get
           Return _group_id
       End Get
       Set(value As Integer)
          _group_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property group_name() As String
       Get
           Return _group_name
       End Get
       Set(value As String)
          _group_name = value
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
    Public Property script() As String
       Get
           Return _script
       End Get
       Set(value As String)
          _script = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property message() As String
       Get
           Return _message
       End Get
       Set(value As String)
          _message = value
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
