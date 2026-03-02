Imports System.Xml.Serialization
Namespace XmlOpera
	Namespace Factory
		Public Class CATSAppServer
			Private _xs As XmlSerializer
			Private _wr As System.IO.StreamWriter
			Private _rd As System.IO.StreamReader
			Private _fp As String
			Public Sub New(filePath As String)
				Try
					_xs = New XmlSerializer(GetType(Format.CATSAppServer.CATSAppServerElement))
					_fp = filePath
				Catch ex As Exception
					Throw New Exception("XmlOpera.CATSAppServer.New()" & vbCrLf & " at " & ex.Message)
				End Try

			End Sub
			Public Function Read() As Format.CATSAppServer.CATSAppServerElement
				Dim fn As String = XmlFileConvert.ConvertXmlsToXml(_fp)

				_rd = New System.IO.StreamReader(fn)

				Try
					Dim resp As New Format.CATSAppServer.CATSAppServerElement

					resp = _xs.Deserialize(_rd)

					Return resp

				Catch ex As Exception
					Throw New Exception("XmlOpera.CATSAppServer.Read()" & vbCrLf & " at " & ex.Message)
				Finally
					_rd.Close()
					IO.File.Delete(fn)
				End Try
			End Function
			Public Function Write(model As Format.CATSAppServer.CATSAppServerElement) As Boolean
				Dim fn As String = XmlFileConvert.GetTmpFileName(_fp)
				_wr = New System.IO.StreamWriter(fn)

				Try

					_xs.Serialize(_wr, model)
					Return True

				Catch ex As Exception
					Throw New Exception("XmlOpera.CATSAppServer.Write()" & vbCrLf & " at " & ex.Message)
				Finally
					_wr.Close()
					XmlFileConvert.ConvertXmlToXmls(fn, _fp)
					IO.File.Delete(fn)
				End Try
			End Function
		End Class
	End Namespace
End Namespace

