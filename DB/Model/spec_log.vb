Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'spec_log
<Serializable()>
Public Class spec_log

	Private _id As Integer
	Private _product_main_id As Integer
	Private _mode_id As Integer
	Private _spec_main_id As Integer
	Private _phase_main_id As Integer
	Private _action As String
	Private _action_descr As String
	Private _date_time As DateTime
    Private _employee_id As Integer?
    Private _controller_id As Integer?
    Private _factory_id As Integer
    Private _stuffer_name As String
    Private _stuffer_version As String
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
	Public Property action() As String
		Get
			Return _action
		End Get
		Set(value As String)
			_action = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property action_descr() As String
		Get
			Return _action_descr
		End Get
		Set(value As String)
			_action_descr = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property date_time() As DateTime
		Get
			Return _date_time
		End Get
		Set(value As DateTime)
			_date_time = value
		End Set
	End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property employee_id() As Integer?
        Get
            Return _employee_id
        End Get
        Set(value As Integer?)
            _employee_id = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property controller_id() As Integer?
        Get
            Return _controller_id
        End Get
        Set(value As Integer?)
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
	Public Property stuffer_name() As String
		Get
			Return _stuffer_name
		End Get
		Set(value As String)
			_stuffer_name = value
		End Set
	End Property
	Public Property stuffer_version() As String
		Get
			Return _stuffer_version
		End Get
		Set(value As String)
			_stuffer_version = value
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
