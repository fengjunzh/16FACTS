Imports FACTS.CalibrateItem

Public Class Calibrate_DUAL_MPO
    Inherits Calibrate

    Public Sub New(productM As FACTS.Model.product_main, testPhase As TestPhaseRlIl, iVIV As IVIAVI)
        Me.Product = productM
        Me.TestPhase = testPhase
        Me.IVIV = iVIV
    End Sub

    Public Overrides ReadOnly Property CalItems As List(Of CalibrateItem)
        Get
            Try
                ' Get instrument wave lengths
                Dim waveLengthList As List(Of Integer) = TestPhase.TestGroupList.First.WavelengthList

                Dim resp As New List(Of CalibrateItem)
                Dim respItem As CalibrateItem

                For i As Integer = 1 To Product.Fiber_per_subunit
                    For Each wl As String In waveLengthList
                        respItem = New CalibrateItem
                        respItem.JumperType = numJumperType.MTJ
                        respItem.JumperCalType = numJumperCalType.Real
                        respItem.CalType = [Enum].Parse(GetType(numCalibrateType), GUI.SelectedPhaseName)
                        respItem.MTJConnection = numJumperConnectionType.SingleMTJ
                        respItem.Channel = i
                        respItem.WaveLength = Int(wl)
                        respItem.Message = String.Format("Please connect switch output MTJ at channel {0} to OPM detector", i)
                        respItem.FileName = String.Format("C{0}_WL{1}", respItem.Channel, respItem.WaveLength)
                        resp.Add(respItem)
                    Next
                Next

                For Each wl As String In waveLengthList
                    If TestPhase.Name = "System" Then
                        respItem = New CalibrateItem
                        respItem.JumperType = numJumperType.Receive
                        respItem.JumperCalType = gBenchSetting.RecJumperCalType
                        respItem.MTJConnection = numJumperConnectionType.DualMTJ
                        respItem.CalType = [Enum].Parse(GetType(numCalibrateType), GUI.SelectedPhaseName)
                        respItem.Channel = 1
                        respItem.WaveLength = Int(wl)
                        respItem.Message = String.Format("Please connect switch output MTJ at channel {0} to OPM detector thru receive jumper", 1)
                        respItem.FileName = String.Format("F{0}_C{1}_WL{2}_RecCal", 1, respItem.Channel, respItem.WaveLength)
                        resp.Add(respItem)
                    End If
                Next

                Return resp

            Catch ex As Exception
                Throw New Exception("Calibrate_DUAL_MPO.CalItems()::" & vbCrLf & " at " & ex.Message)
            End Try
        End Get
    End Property

    Public Overrides Function DoCal() As Boolean
        Try

            Dim frmCal As New FormCalibrate(CalItems, MyBase.Product, MyBase.TestPhase, MyBase.IVIV)
            frmCal.ShowDialog()

            Return True
        Catch ex As Exception
            Throw New Exception("Calibrate_DUAL_MPO.DoCal() - " & ex.Message)
        End Try
    End Function
End Class
