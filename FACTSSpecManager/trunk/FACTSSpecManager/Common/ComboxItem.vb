Public Class ComboxItem
	Private m_id As Integer
	Private m_descr As String
	Private m_text As String

	Public Property Id As Integer
		Get
			Return m_id
		End Get
		Set(value As Integer)
			m_id = value
		End Set
	End Property
	Public Property Text As String
		Get
			Return m_text
		End Get
		Set(value As String)
			m_text = value
		End Set
	End Property
	Public Property Descr As String
		Get
			Return m_descr
		End Get
		Set(value As String)
			m_descr = value
		End Set
	End Property
	Public Overrides Function ToString() As String
		Return m_text
	End Function
End Class
