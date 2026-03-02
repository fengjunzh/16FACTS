Imports System.Xml.Serialization
Namespace XmlOpera
	Namespace Format
		Public Class CATS
			<XmlType("CATS")>
			Public Class CATSElement
				Implements ICloneable
				Private _Property As New PropertyElement
				Private _Factory As New FactoryElement
				Private _TestBench As New TestBenchElement
				Private _DataBase As New DataBaseElement
				Public Sub New()

				End Sub
				Private Sub New(property_ As PropertyElement, fac As FactoryElement, testBench As TestBenchElement, dataBase As DataBaseElement)
					_Property = property_.Clone
					_Factory = fac.Clone
					_TestBench = testBench.Clone
					_DataBase = dataBase.Clone
				End Sub
				<XmlElement("Property")>
				Public Property Property_ As PropertyElement
					Get
						Return _Property
					End Get
					Set(value As PropertyElement)
						_Property = value
					End Set
				End Property
				Public Property Factory As FactoryElement
					Get
						Return _Factory
					End Get
					Set(value As FactoryElement)
						_Factory = value
					End Set
				End Property
				Public Property TestBench As TestBenchElement
					Get
						Return _TestBench
					End Get
					Set(value As TestBenchElement)
						_TestBench = value
					End Set
				End Property
				Public Property DataBase As DataBaseElement
					Get
						Return _DataBase
					End Get
					Set(value As DataBaseElement)
						_DataBase = value
					End Set
				End Property
				Public Function Clone() As Object Implements System.ICloneable.Clone
					Dim resp As New CATSElement
					Return CType(resp.Clone, Object)
				End Function
			End Class
			<XmlType("Property")>
			Public Class PropertyElement
				Implements ICloneable

				Private _CreateTime As DateTime

				Public Property CreateTime As DateTime
					Get
						Return _CreateTime
					End Get
					Set(value As DateTime)
						_CreateTime = value
					End Set
				End Property

				Public Function Clone() As Object Implements System.ICloneable.Clone
					Return Me.MemberwiseClone()
				End Function
			End Class

			<XmlType("Factory")>
			Public Class FactoryElement
				Implements ICloneable

				Private _Location As String

				Public Property Location As String
					Get
						Return _Location
					End Get
					Set(value As String)
						_Location = value
					End Set
				End Property

				Public Function Clone() As Object Implements System.ICloneable.Clone
					Return Me.MemberwiseClone()
				End Function
			End Class

			<XmlType("TestBench")>
			Public Class TestBenchElement
				Implements ICloneable

				Private _Mode As String

				Public Property Mode As String
					Get
						Return _Mode
					End Get
					Set(value As String)
						_Mode = value
					End Set
				End Property

				Public Function Clone() As Object Implements System.ICloneable.Clone
					Return Me.MemberwiseClone()
				End Function
			End Class

			<XmlType("DataBase")>
			Public Class DataBaseElement
				Implements ICloneable

				Private _ConnString As String

				Public Property ConnString As String
					Get
						Return _ConnString
					End Get
					Set(value As String)
						_ConnString = value
					End Set
				End Property

				Public Function Clone() As Object Implements System.ICloneable.Clone
					Return Me.MemberwiseClone()
				End Function
			End Class

		End Class
	End Namespace
End Namespace

