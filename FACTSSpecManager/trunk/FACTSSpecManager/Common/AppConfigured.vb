Imports System.Configuration
Module AppConfigured
	Private Function DecryptorConnectionString(encryptorConnString As String) As String
		Try
			Dim strInput As String = encryptorConnString
			Dim fe As New Encryptor
			Return fe.DecryptStringFromString(strInput)

		Catch ex As Exception
			Throw New Exception("DecryptorConnectionString()" & ex.Message)
		End Try
	End Function
	Public Function GetConnString() As List(Of ComboxItem)
		Try
			Dim resp As New List(Of ComboxItem)
			Dim respItem As ComboxItem

			Dim connNum As Integer = ConfigurationManager.ConnectionStrings.Count
			Dim ci As ConnectionStringSettings

            For i As Integer = 1 To connNum - 1
                Try
                    ci = ConfigurationManager.ConnectionStrings.Item(i)
                    respItem = New ComboxItem
                    respItem.Text = ci.Name
                    respItem.Descr = DecryptorConnectionString(ci.ConnectionString)
                    resp.Add(respItem)
                Catch ex As Exception

                End Try

            Next

            Return resp
		Catch ex As Exception
			Throw New Exception("GetConnString()::" & ex.Message)
		End Try


	End Function
End Module
