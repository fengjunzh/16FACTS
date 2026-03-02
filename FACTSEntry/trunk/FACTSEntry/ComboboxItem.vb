Public Class ComboboxItem
	Private _Text As String
	Private _MiscMsg As Object
	Public Property Text As String
		Get
			Return _Text
		End Get
		Set(value As String)
			_Text = value
		End Set
	End Property
	Public Property MiscMsg As Object
		Get
			Return _MiscMsg
		End Get
		Set(value As Object)
			_MiscMsg = value
		End Set
	End Property
	Public Overrides Function ToString() As String
		Return _Text
	End Function
End Class
