Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'meas_detail
<Serializable()>
Public Class meas_detail
Private _id As Integer
Private _meas_phase_id As Integer
Private _meas_group_id As Integer
Private _order_idx As Integer
Private _spec_detail_id As Integer
Private _meas_value As Decimal
Private _meas_string As String
Private _meas_status As String
Private _plot_path As String
Private _trace_path As String
Private _test_idx As Integer
Private _last_test_flag As Boolean
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
    Public Property meas_phase_id() As Integer
       Get
           Return _meas_phase_id
       End Get
       Set(value As Integer)
          _meas_phase_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property meas_group_id() As Integer
       Get
           Return _meas_group_id
       End Get
       Set(value As Integer)
          _meas_group_id = value
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
    Public Property spec_detail_id() As Integer
       Get
           Return _spec_detail_id
       End Get
       Set(value As Integer)
          _spec_detail_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property meas_value() As Decimal
       Get
           Return _meas_value
       End Get
       Set(value As Decimal)
          _meas_value = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property meas_string() As String
       Get
           Return _meas_string
       End Get
       Set(value As String)
          _meas_string = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property meas_status() As String
       Get
           Return _meas_status
       End Get
       Set(value As String)
          _meas_status = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property plot_path() As String
       Get
           Return _plot_path
       End Get
       Set(value As String)
          _plot_path = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property trace_path() As String
       Get
           Return _trace_path
       End Get
       Set(value As String)
          _trace_path = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property test_idx() As Integer
       Get
           Return _test_idx
       End Get
       Set(value As Integer)
          _test_idx = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property last_test_flag() As Boolean
       Get
           Return _last_test_flag
       End Get
       Set(value As Boolean)
          _last_test_flag = value
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
