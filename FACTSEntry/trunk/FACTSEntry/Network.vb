Public Class Network
  Public Shared Function CheckNetworkConnection(pcName As String) As Boolean
    Try
      If My.Computer.Network.Ping(pcName, 1000) = True Then Return True
      Return False
    Catch ex As Exception
      Return False
    End Try
  End Function
End Class
