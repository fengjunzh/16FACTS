Public Class CATSProfile
	Private _name As String
	Private _user As String
	Private _password As String
	Private _connString As String
	Public Property Name As String
		Get
			Return _name
		End Get
		Set(value As String)
			_name = value
		End Set
	End Property

	Public Property User As String
		Get
			Return _user
		End Get
		Set(value As String)
			_user = value
		End Set
	End Property

	Public Property Password As String
		Get
			Return _password
		End Get
		Set(value As String)
			_password = value
		End Set
	End Property

	Public Property ConnString As String
		Get
			Return _connString
		End Get
		Set(value As String)
			_connString = value
		End Set
	End Property
End Class
