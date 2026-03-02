Public Class CalibrateIOFactory
    Public Function CreateInstance() As CalibrateIO
        Try
            Dim _CalibrateIOFile = CalibrateIOFile.CreateInstance(gCalItemsFileName)
            If _CalibrateIOFile Is Nothing Then
                _CalibrateIOFile = New CalibrateIOFile
                _CalibrateIOFile.Save()
            End If
            Return _CalibrateIOFile
        Catch ex As Exception
            Throw New Exception("CalibrateIOFactory.CreateInstance() - " & ex.Message)
        End Try
    End Function
End Class
