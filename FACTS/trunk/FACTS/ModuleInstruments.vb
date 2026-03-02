Imports C1.Win.C1Chart
Imports FACTS.Model

Module ModuleInstruments
    Public WithEvents pInstCtrl As Instrument
    Public pCalIO As CalibrateIO
    Public Function InitializeInstrument(ByVal BenSet As CBenchSetting) As Boolean
        Try
#If Simulate Then
            Return True
#End If
            Dim IPAddr As String = BenSet.IpAddress
            Dim port As String = BenSet.Port
            gTestPlan.AddStatusMsg(String.Format("Open Instrument @{0}:{1}", IPAddr, port))
            Select Case BenSet.InstrumentType
                Case "MAP200_PCT"
                    pInstCtrl = New MAP200_PCT
                Case "MAP300_PCT"
                    pInstCtrl = New MAP300_PCT
                Case Else
                    Throw New Exception(String.Format("Type <{0}> not support!", BenSet.InstrumentType))
            End Select
            pInstCtrl.IPAddress = IPAddr
            pInstCtrl.PortNumber = port
            If pInstCtrl.Open = False Then Throw New Exception(String.Format("Fail to open {0}:{1}", pInstCtrl.IPAddress, pInstCtrl.PortNumber))
            gTestPlan.AddStatusMsg(String.Format("Open {0} ... OK", BenSet.InstrumentType))
            Return True
        Catch ex As Exception
            Throw New Exception("ModuleInstruments.InitializeInstrument()::" & ex.Message)
        End Try
    End Function
    Public Function InitializeCMR(ByVal BenSet As CBenchSetting) As Boolean
        Try
#If Simulate Then
            Return True
#End If
            Dim IPAddr As String = BenSet.IpAddress
            Dim port As String = "8100"
            gTestPlan.AddStatusMsg(String.Format("Init CMR @{0}:{1}", IPAddr, port))
            Select Case BenSet.InstrumentType
                Case "MAP200_PCT"
                    pInstCtrl = New MAP200_PCT
                Case "MAP300_PCT"
                    pInstCtrl = New MAP300_PCT
                Case Else
                    Throw New Exception(String.Format("Type <{0}> not support!", BenSet.InstrumentType))
            End Select
            pInstCtrl.IPAddress = IPAddr
            pInstCtrl.PortNumber = port
            If pInstCtrl.ConnectCMR = False Then Throw New Exception(String.Format("Fail to init {0}:{1}", pInstCtrl.IPAddress, pInstCtrl.PortNumber))
            gTestPlan.AddStatusMsg(String.Format("Init CMR ... OK", BenSet.InstrumentType))
            Return True
        Catch ex As Exception
            Throw New Exception("ModuleInstruments.InitializeCMR()::" & ex.Message)
        End Try
    End Function
    Public Function InitializeCMR(ipAddres As String, instrType As String) As Boolean
        Try
#If Simulate Then
            Return True
#End If
            gTestPlan.AddStatusMsg(String.Format("Init CMR @{0}:{1}", ipAddres, 8100))
            Select Case instrType
                Case "MAP200_PCT"
                    pInstCtrl = New MAP200_PCT
                Case "MAP300_PCT"
                    pInstCtrl = New MAP300_PCT
                Case Else
                    Throw New Exception(String.Format("Type <{0}> not support!", instrType))
            End Select
            pInstCtrl.IPAddress = ipAddres
            If pInstCtrl.ConnectCMR = False Then Throw New Exception(String.Format("Fail to init {0}:{1}", ipAddres, 8100))
            gTestPlan.AddStatusMsg(String.Format("Init CMR ... OK"))
            Return True
        Catch ex As Exception
            Throw New Exception("ModuleInstruments.InitializeCMR()::" & ex.Message)
        End Try
    End Function
    Public Function GetSilulateCalValue(ByVal waveLength As Integer) As String()
        Try
            Randomize()
            Dim res As String()

            Dim power, offset, length As Decimal

            power = Math.Round(CDec(200 * Rnd() + 5000) / 100, 2)
            offset = Math.Round(CDec(20 * Rnd() + 50) / 100, 2)
            length = Math.Round(CDec(40 * Rnd() + 400) / 100, 2)

            Threading.Thread.Sleep(1000)

            res = New String() {waveLength, power, offset, length}

            Return res

        Catch ex As Exception
            Return {0, 0, 0, 0}
        End Try
    End Function
    Public Function GetSilulateTestValue(ByVal waveLengthList As List(Of Integer)) As String()
        Try
            Randomize()
            Dim res As String()

            Dim il, length, rl1, rl2 As Decimal
            Dim measStr As String = ""

            For Each wl As Integer In waveLengthList
                il = Math.Round(CDec(5 * Rnd() + 20) / 100, 2)
                length = Math.Round(CDec(15 * Rnd() + 1500) / 100, 2)
                rl1 = Math.Round(CDec(600 * Rnd() + 6000) / 100, 2)
                rl2 = Math.Round(CDec(600 * Rnd() + 6000) / 100, 2)
                measStr += String.Format("{0},{1},{2},{3},{4},", wl, il, length, rl1, rl2)
            Next

            Threading.Thread.Sleep(1000)

            measStr = measStr.Substring(0, measStr.Length - 2)

            res = measStr.Split(",")

            Return res

        Catch ex As Exception
            Return {0, 0, 0, 0}
        End Try
    End Function

    Public Sub ExcuseStepCalibration(ByRef CalItem As CalibrateItem, ByVal VIV As IVIAVI)
        Try
            If CalItem.JumperType = numJumperType.Receive And gBenchSetting.RecJumperCalType = numJumperCalType.Simulate Then
                CalItem.Power = 0
                CalItem.Offset = 0.05
                CalItem.Length = gBenchSetting.RecJumperLength
                Return
            End If
            Dim measResArr As String() = Nothing
            Dim measResStr As String
            Dim power As Double
            Dim iStep As Integer

#If Simulate Then
            measResArr = GetSilulateCalValue(0)
#Else
            With VIV
                .MeasFunction = 0
                .MeasStart()
                Do
                    .WaitOPC(1)
                    If CalItem.JumperType = numJumperType.MTJ Then
                        measResStr = .MeasResAll().Trim
                    Else
                        measResStr = .MeasResAll(1).Trim
                    End If
                    measResArr = measResStr.Split(",")
                    iStep += 1
                    If iStep > 5 Then Exit Do
                Loop While (measResStr = String.Empty Or measResStr.Contains(",,,"))
            End With
#End If
#If Simulate Then
            Dim rnd As New Random
            CalItem.Power = rnd.Next(-450, -350) / 10
            CalItem.Offset = rnd.Next(5, 10) / 10
            CalItem.Length = rnd.Next(40, 42) / 10
#Else
            If measResStr = String.Empty Or measResStr.Contains(",,,") Then
                CalItem.Power = 0
                CalItem.Offset = 5
                CalItem.Length = 0
            Else
                If measResArr.Length = 4 And Double.TryParse(measResArr(1), power) Then
                    CalItem.Power = measResArr(1)
                    CalItem.Offset = measResArr(2)
                    CalItem.Length = measResArr(3)
                Else
                    CalItem.Power = 0
                    CalItem.Offset = 5
                    CalItem.Length = 0
                End If
            End If
#End If


        Catch ex As Exception
            Throw New Exception("ExcuseStepCalibration" & ex.Message)
        End Try
    End Sub
End Module
