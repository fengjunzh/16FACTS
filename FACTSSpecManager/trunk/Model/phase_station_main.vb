Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'phase_station_main
<Serializable()>
Public Class phase_station_main
Private _id As Integer
Private _order_idx As Integer
Private _phase_station As String
Private _descr As String
Private _ret_validity As Boolean
Private _meas_type As Integer
Private _phase_station_func_id As Integer
Private _phase_station_class_id As Integer
Private _default_validity As Boolean
Private _validity As Boolean
Private _validation As Boolean
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
    Public Property phase_station() As String
       Get
           Return _phase_station
       End Get
       Set(value As String)
          _phase_station = value
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
    Public Property ret_validity() As Boolean
       Get
           Return _ret_validity
       End Get
       Set(value As Boolean)
          _ret_validity = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property meas_type() As Integer
       Get
           Return _meas_type
       End Get
       Set(value As Integer)
          _meas_type = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property phase_station_func_id() As Integer
       Get
           Return _phase_station_func_id
       End Get
       Set(value As Integer)
          _phase_station_func_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property phase_station_class_id() As Integer
       Get
           Return _phase_station_class_id
       End Get
       Set(value As Integer)
          _phase_station_class_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property default_validity() As Boolean
       Get
           Return _default_validity
       End Get
       Set(value As Boolean)
          _default_validity = value
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
		Return _phase_station
	End Function
End Class
