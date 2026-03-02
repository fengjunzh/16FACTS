Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'meas_phase
<Serializable()>
Public Class meas_phase
	Private _id As Integer
	Private _meas_main_id As Integer
	Private _spec_main_id As Integer
	Private _phase_main_id As Integer
	Private _phase As String
	Private _phase_status As String
	Private _software_rev As String
	Private _employee_id As Integer
	Private _controller_id As Integer
	Private _factory_id As Integer
	Private _forced_status As Boolean
	Private _start_datetime As DateTime
	Private _stop_datetime As DateTime
	Private _conn_time As Integer
	Private _meas_time As Integer
	Private _setup_time As Integer
	Private _total_time As Integer
	Private _gen1 As Integer?
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
	Public Property meas_main_id() As Integer
		Get
			Return _meas_main_id
		End Get
		Set(value As Integer)
			_meas_main_id = value
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
	Public Property phase_main_id() As Integer
		Get
			Return _phase_main_id
		End Get
		Set(value As Integer)
			_phase_main_id = value
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
	Public Property phase_status() As String
		Get
			Return _phase_status
		End Get
		Set(value As String)
			_phase_status = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property software_rev() As String
		Get
			Return _software_rev
		End Get
		Set(value As String)
			_software_rev = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property employee_id() As Integer
		Get
			Return _employee_id
		End Get
		Set(value As Integer)
			_employee_id = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property controller_id() As Integer
		Get
			Return _controller_id
		End Get
		Set(value As Integer)
			_controller_id = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property factory_id() As Integer
		Get
			Return _factory_id
		End Get
		Set(value As Integer)
			_factory_id = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property forced_status() As Boolean
		Get
			Return _forced_status
		End Get
		Set(value As Boolean)
			_forced_status = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property start_datetime() As DateTime
		Get
			Return _start_datetime
		End Get
		Set(value As DateTime)
			_start_datetime = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property stop_datetime() As DateTime
		Get
			Return _stop_datetime
		End Get
		Set(value As DateTime)
			_stop_datetime = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property conn_time() As Integer
		Get
			Return _conn_time
		End Get
		Set(value As Integer)
			_conn_time = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property meas_time() As Integer
		Get
			Return _meas_time
		End Get
		Set(value As Integer)
			_meas_time = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property setup_time() As Integer
		Get
			Return _setup_time
		End Get
		Set(value As Integer)
			_setup_time = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property total_time() As Integer
		Get
			Return _total_time
		End Get
		Set(value As Integer)
			_total_time = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property gen1() As Integer?
		Get
			Return _gen1
		End Get
		Set(value As Integer?)
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
