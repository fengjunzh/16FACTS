Imports System.Xml.Serialization
Namespace XmlOpera
    Namespace Format
        Public Class CATSAppServer

            <XmlType("CATSAppServer")>
            Public Class CATSAppServerElement
                Implements System.ICloneable
                Private _ReleasedTime As DateTime
                Private _Server As New ServerElement
                Public Sub New()

                End Sub
                Private Sub New(svr As ServerElement)
                    _Server = CType(svr.Clone, Object)
                End Sub
                Public Property ReleasedTime As DateTime
                    Get
                        Return _ReleasedTime
                    End Get
                    Set(value As DateTime)
                        _ReleasedTime = value
                    End Set
                End Property
                Public Property Server As ServerElement
                    Get
                        Return _Server
                    End Get
                    Set(value As ServerElement)
                        _Server = value
                    End Set
                End Property
                Public Function Clone() As Object Implements System.ICloneable.Clone
                    Dim resp As New CATSAppServerElement(_Server)
                    resp.ReleasedTime = _ReleasedTime
                    Return CType(resp, Object)
                End Function
            End Class

            <XmlType("Server")>
            Public Class ServerElement
                Implements System.ICloneable
                Private _Name As String
                Private _Path As String
                Public Property Name As String
                    Get
                        Return _Name
                    End Get
                    Set(value As String)
                        _Name = value
                    End Set
                End Property
                Public Property Path As String
                    Get
                        Return _Path
                    End Get
                    Set(value As String)
                        _Path = value
                    End Set
                End Property
                Public Function Clone() As Object Implements System.ICloneable.Clone
                    Return CType(Me.MemberwiseClone, Object)
                End Function
            End Class

        End Class
    End Namespace
End Namespace


