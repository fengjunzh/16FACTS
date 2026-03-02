Friend Class XmlFileConvert

  Public Shared Sub ConvertXmlToXmls(xmlFile As String, ByRef xmlsFile As String)
    Try

      Dim ef As New Encryptor
      ef.EncryptFile(xmlFile, xmlsFile)

    Catch ex As Exception
      Throw New Exception("XmlFileConvert()" & vbCrLf & " at " & ex.Message)
    End Try
  End Sub
  Public Shared Function ConvertXmlsToXml(xmlsFile As String) As String
    Try
      Dim resp As String

      resp = GetTmpFileName(xmlsFile)

      Dim ef As New Encryptor
      ef.DecryptFile(xmlsFile, resp)

      Return resp

    Catch ex As Exception
      Throw New Exception("XmlFileConvert()" & vbCrLf & " at " & ex.Message)
    End Try
  End Function
  Public Shared Function GetTmpFileName(filePath As String) As String
    Dim fDirectory As String
    Dim fName As String
    fDirectory = GetFileDirectory(filePath)
    fName = System.Guid.NewGuid.ToString
    Return fDirectory & "\" & fName
  End Function
  Public Shared Function GetFileDirectory(filePath As String) As String
    Return New IO.FileInfo(filePath).DirectoryName
  End Function
End Class
