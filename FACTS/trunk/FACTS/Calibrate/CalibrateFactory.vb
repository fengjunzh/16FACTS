Imports C1.Win.C1FlexGrid

Public Class CalibrateFactory
    Private Property testPhase As TestPhaseRlIl
    Public Property productMain As FACTS.Model.product_main
    Public Property iVIV As IVIAVI
    Public Sub New(product As FACTS.Model.product_main, testPhase As TestPhaseRlIl, iVIV As IVIAVI)
        Me.productMain = product
        Me.testPhase = testPhase
        Me.iVIV = iVIV
    End Sub
    Public Function CreateInstance() As Calibrate
        Try
            Dim resp As Calibrate

            Select Case gConnectorFamily
                Case numConnFamily.DUAL_MPO
                    resp = New Calibrate_DUAL_MPO(productMain, testPhase, iVIV)
                Case numConnFamily.NON_MPO
                    resp = New Calibrate_NON_MPO(productMain, testPhase, iVIV)
                Case Else
                    resp = New Calibrate_SINGLE_MPO(productMain, testPhase, iVIV)
            End Select

            Return resp

        Catch ex As Exception
            Throw New Exception("CalibrateFactory.CreateInstance() - " & IIf(ex.Message.Contains("Object reference"), "Please check you antenna type and select it !", ex.Message))
        End Try

    End Function
End Class
