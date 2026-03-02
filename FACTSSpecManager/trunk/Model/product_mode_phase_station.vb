Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'product_mode_phase_station
<Serializable()>
Public Class product_mode_phase_station
	Private _id As Integer
	Private _product_mode_id As Integer
	Private _phase_station_main_id As Integer
	Private _descr As String
	Private _order_idx As Integer
	Private _default_selection As Boolean
	Private _validity As Boolean
	Private _validation As Boolean
	Private _validation_date As DateTime
	Private _gen1 As String
	Private _gen2 As String
	Private _gen3 As String
	Public Sub New()
		Try

		Catch ex As Exception
			Throw New Exception("product_model_phase_staion.New()::" & ex.Message)
		End Try
	End Sub
	Public Sub New(model As product_mode_phase_station)
		Try
			id = model.id
			product_mode_id = model.product_mode_id
			phase_station_main_id = model.phase_station_main_id
			descr = model.descr
			order_idx = model.order_idx
			default_selection = model.default_selection
			validity = model.validity
			validation = model.validation
			validation_date = model.validation_date
			gen1 = model.gen1
			gen2 = model.gen2
			gen3 = model.gen3
		Catch ex As Exception
			Throw New Exception("product_model_phase_staion.New(model)::" & ex.Message)
		End Try
	End Sub
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
	Public Property gen3() As String
		Get
			Return _gen3
		End Get
		Set(value As String)
			_gen3 = value
		End Set
	End Property
End Class
