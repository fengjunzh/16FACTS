Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'employee
<Serializable()>
Public Class employee
	Private _id As Integer
	Private _emp_num As String
	Private _name As String
	Private _login_name As String
	Private _permission As Boolean
	Private _department As String
	Private _pwd As String
	Private _user_level As String
	Private _factory_id As Integer
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
	Public Property emp_num() As String
		Get
			Return _emp_num
		End Get
		Set(value As String)
			_emp_num = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property name() As String
		Get
			Return _name
		End Get
		Set(value As String)
			_name = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property login_name() As String
		Get
			Return _login_name
		End Get
		Set(value As String)
			_login_name = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property permission() As Boolean
		Get
			Return _permission
		End Get
		Set(value As Boolean)
			_permission = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property department() As String
		Get
			Return _department
		End Get
		Set(value As String)
			_department = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property pwd() As String
		Get
			Return _pwd
		End Get
		Set(value As String)
			_pwd = value
		End Set
	End Property

	''' <summary>
	''' id
	''' </summary>
	Public Property user_level() As String
		Get
			Return _user_level
		End Get
		Set(value As String)
			_user_level = value
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
		Return _login_name.ToString
	End Function
End Class
