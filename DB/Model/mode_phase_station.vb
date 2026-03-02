Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'mode_phase_station
<Serializable()>
Public Class mode_phase_station
Private _id As Integer
Private _mode_id As Integer
Private _phase_station_main_id As Integer
Private _descr As String
Private _order_idx As Integer
Private _default_selection As Boolean
Private _validity As Boolean
Private _validation As Boolean
Private _validation_date As DateTime
Private _gen1 As String
Private _gen2 As String
Private _gen3 As Integer

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
    Public Property phase_station_main_id() As Integer
       Get
           Return _phase_station_main_id
       End Get
       Set(value As Integer)
          _phase_station_main_id = value
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
    Public Property default_selection() As Boolean
       Get
           Return _default_selection
       End Get
       Set(value As Boolean)
          _default_selection = value
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
    Public Property gen3() As Integer
       Get
           Return _gen3
       End Get
       Set(value As Integer)
          _gen3 = value
       End Set
    End Property
End Class
