Imports System.Xml.Serialization
Namespace XmlOpera
  Namespace Factory
		Public Class CATSApplications
			Private _xs As XmlSerializer
			Private _wr As System.IO.StreamWriter
			Private _rd As System.IO.StreamReader
			Private _fp As String
			Public Sub New(filePath As String)
				Try
					_xs = New XmlSerializer(GetType(Format.CATSApplications.CATSApplicationsElement))
					_fp = filePath
				Catch ex As Exception
					Throw New Exception("XmlOpera.CATSApplications.New()" & vbCrLf & " at " & ex.Message)
				End Try

			End Sub
			Public Function Read() As Format.CATSApplications.CATSApplicationsElement
				Dim fn As String = XmlFileConvert.ConvertXmlsToXml(_fp)

				_rd = New System.IO.StreamReader(fn)

				Try
					Dim resp As New Format.CATSApplications.CATSApplicationsElement

					resp = _xs.Deserialize(_rd)

					Return resp

				Catch ex As Exception
					Throw New Exception("XmlOpera.CATSApplications.Read()" & vbCrLf & " at " & ex.Message)
				Finally
					_rd.Close()
					IO.File.Delete(fn)
				End Try
			End Function
			Public Function Write(model As Format.CATSApplications.CATSApplicationsElement) As Boolean
				Dim fn As String = XmlFileConvert.GetTmpFileName(_fp)
				_wr = New System.IO.StreamWriter(fn)

				Try

					_xs.Serialize(_wr, model)
					Return True

				Catch ex As Exception
					Throw New Exception("XmlOpera.CATSApplications.Write()" & vbCrLf & " at " & ex.Message)
				Finally
					_wr.Close()
					XmlFileConvert.ConvertXmlToXmls(fn, _fp)
					IO.File.Delete(fn)
				End Try
			End Function
		End Class
	End Namespace
End Namespace


