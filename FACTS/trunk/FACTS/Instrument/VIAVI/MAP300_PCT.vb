Imports System.Reflection
Imports System.Threading

Public Class MAP300_PCT
    Inherits SCPIInstrument
    Implements IVIAVI

    Private _ActiveChannel As Integer
    Private sessionConn As TestTelnet.TelnetConnection
    Private moduleNumber As Integer = Integer.MinValue
    Private sessionport As Integer = Integer.MinValue
    Private curAppName As String() = New String(1) {}
    Private selectedApplication As String = ""
    Private InstrType As InstrumentType = InstrumentType.MAP300_PCT
    Private GUIEnable As Boolean = False

    Private Function OneToTrue(ByVal isOne As String) As Boolean
        If isOne.EndsWith("1") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function TrueToOne(ByVal isTrue As Boolean) As String
        If isTrue Then
            Return 1
        Else
            Return 0
        End If
    End Function
    ''' <summary>
    ''' Initiates a measurement cycle
    ''' </summary>
    Public Sub MeasStart() Implements IVIAVI.MeasStart
        Try
            MyBase.SendSCPIComand(":MEASure:STARt")
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.MeasStart()::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Aborts the current measurement cycle, or turns off the pulsed laser if it is enabled
    ''' </summary>
    Public Sub MeasStop() Implements IVIAVI.MeasStop
        Try
            MyBase.SendSCPIComand(":MEASure:STOP")
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.MeasStop()::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Launches the PCT Super Application.
    ''' </summary>
    Public Sub LaunchPCT() Implements IVIAVI.LaunchPCT
        Try
            MyBase.SendSCPIComand(":SUP:LAUN PCT")
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.LaunchPCT()::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    Public Sub ExitPCT() Implements IVIAVI.ExitPCT
        Try
            MyBase.SendSCPIComand(":SUP:EXIT PCT")
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.ExitPCT()::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Starts a factory calibration measurement for the specified step
    ''' 1 = Front Panel distances
    ''' 2 = Front Panel IL/Ratio
    ''' 6 = 1xn Switch distances
    ''' </summary>
    ''' <param name="stp"></param>
    Public Sub FactoryCalMeasStart(stp As Integer) Implements IVIAVI.FactoryCalMeasStart
        Try
            MyBase.SendSCPIComand(String.Format(":FACTory:MEASure:STARt {0}", stp))
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.FactoryMeasStart()::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Commits the measured calibration step values to the EEPROM
    ''' </summary>
    ''' <param name="stp"></param>
    Public Sub FactoryCalMeasCommit(stp As Integer) Implements IVIAVI.FactoryCalMeasCommit
        Try
            MyBase.SendSCPIComand(String.Format(":FACTory:COMMit {0}", stp))
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.FactoryCalMeasCommit()::" & ex.Message)
        End Try
    End Sub

    Public Overloads Function WaitOPCResponse(timeOutSec As Integer) As String Implements IVIAVI.WaitOPCResponse
        Try
            Dim resp As String
            Dim tmpTimeout As Integer
            tmpTimeout = MyBase.Timeout
            MyBase.Timeout = timeOutSec * 1000
            resp = MyBase.SendSCPIComand("*OPC?")
            MyBase.Timeout = tmpTimeout
            Return resp
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.WaitOPC()::" & ex.Message)
        End Try
    End Function
    Public Overloads Sub WaitOPC(timeOutSec As Integer) Implements IVIAVI.WaitOPC
        Try
            Dim tmpTimeout As Integer
            tmpTimeout = MyBase.Timeout
            MyBase.Timeout = timeOutSec * 1000
            MyBase.SendSCPIComand("*OPC?")
            MyBase.Timeout = tmpTimeout
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.WaitOPC()::" & ex.Message)
        End Try
    End Sub
    Public Overloads Sub Reset() Implements IVIAVI.Reset
        Try
            Dim tmpTimeout As Integer
            tmpTimeout = MyBase.Timeout
            MyBase.Timeout = 45000
            MyBase.SendSCPIComand("Res")
            MyBase.Timeout = tmpTimeout
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.Reset()::" & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Query the available source wavelengths (nm)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property WavelengthAvailable As String Implements IVIAVI.WavelengthAvailable
        Get
            Try
                Return MyBase.SendSCPIComand(":SOURce:WAVelength:AVAilable?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.Wavelength.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the number of available channels for the specified channel group
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ChannelAvailable As Integer Implements IVIAVI.ChannelAvailable
        Get
            Try
                Return MyBase.SendSCPIComand(":PATH:CHANnel:AVAilable? 1")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.ChannelAvailable.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Get or Set the channel to use for the specified channel group
    ''' 1 = MTJ1
    ''' 2 = MTJ2
    ''' 3 = Receive
    ''' </summary>
    ''' <returns></returns>
    Public Property Channel(group As Integer) As Integer Implements IVIAVI.Channel
        Get
            Try
                Return MyBase.SendSCPIComand(":PATH:CHANnel? {0}", group)
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.Channel.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:CHANnel {0},{1}", group, value))
                ActiveChannel = value
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.Channel.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Get or Set the list of source wavelengths to use for measurement (nm).
    ''' </summary>
    ''' <returns></returns>
    Public Property WavelengthList As String Implements IVIAVI.WavelengthList
        Get
            Try
                Return MyBase.SendSCPIComand(":SOURce:LIST?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.WavelengthList.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As String)
            Try
                MyBase.SendSCPIComand(String.Format(":SOURce:LIST {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.WavelengthList.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Get or Set PCT measurement function
    ''' 0 = Reference Measurement
    ''' 1 = DUT Measurement
    ''' </summary>
    ''' <returns></returns>
    Public Property MeasFunction As Integer Implements IVIAVI.MeasFunction
        Get
            Try
                Return MyBase.SendSCPIComand(":SENSe:FUNCtion?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasFunction.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":SENSe:FUNCtion {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasFunction.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Get or Set the source launch port for a module with 2 outputs
    ''' 1 = J1 Out
    ''' 2 = J2 Out
    ''' </summary>
    ''' <returns></returns>
    Public Property LaunchPort As Integer Implements IVIAVI.LaunchPort
        Get
            Try
                Return MyBase.SendSCPIComand(":PATH:LAUNch?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LaunchPort.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:LAUNch {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LaunchPort.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Get or Set the MTJ connection mode
    ''' 1 = Single MTJ
    ''' 2 = Dual MTJ
    ''' </summary>
    ''' <returns></returns>
    Public Property MTJConnection As Integer Implements IVIAVI.MTJConnection
        Get
            Try
                Return MyBase.SendSCPIComand(":PATH:CONNection?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MTJConnection.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:CONNection {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MTJConnection.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query the PCT application state
    ''' 0 = INIT (initializing application)
    ''' 1 = IDLE (ready but not measuring)
    ''' 2 = BUSY (making a measurement)
    ''' 3 = FAULT (in fault state)
    ''' 4 = SYSTEM*
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MeasState As MeasState Implements IVIAVI.MeasState
        Get
            Try
                Return [Enum].Parse(GetType(MeasState), MyBase.SendSCPIComand(":MEASure:STATe?"))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasState.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the status of the PCT Super Application
    ''' 0 = PCT Super Application is not running
    ''' 1 = PCT Super Application is running
    ''' 2 = Specified Super Application name is not valid
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property PCTState As Integer Implements IVIAVI.PCTState
        Get
            Try
                Return MyBase.SendSCPIComand(":SUPer:STATus? PCT")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.PCTState.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query all measurement results for the current measurement setup
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property MeasResAll(Optional recChannel As Integer = 0) As String Implements IVIAVI.MeasResAll
        Get
            Try
                If recChannel > 0 Then
                    Return MyBase.SendSCPIComand(String.Format(":MEAS:ALL? {0},{1}", ActiveChannel, recChannel))
                Else
                    Return MyBase.SendSCPIComand(String.Format(":MEAS:ALL? {0}", ActiveChannel))
                End If
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasResAll.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the PCT module calibration date.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property CalibrationDate As Date Implements IVIAVI.CalibrationDate
        Get
            Try
                Return MyBase.SendSCPIComand(":FACT:CAL:DATe?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.CalibrationDate.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the Front Panel distances at each wavelength for the specified Internal Launch Fiber
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property FrontPanelDistance As String Implements IVIAVI.FrontPanelDistance
        Get
            Try
                Return MyBase.SendSCPIComand(":FACT:MEAS:FPD? 1")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.FrontPanelDistance.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the Front Panel Power Ratio at each wavelength for the specified Internal Launch Fiber
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property FrontPanelPowerRatio As String Implements IVIAVI.FrontPanelPowerRatio
        Get
            Try
                Return MyBase.SendSCPIComand(":FACT:MEAS:FPR? 1")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.FrontPanelDistance.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the 1xn Switch distances at each wavelength for the specified switch channel number
    ''' 1 = SW1
    ''' 2 = SW2
    ''' </summary>
    ''' <param name="channel"></param>
    ''' <returns></returns>
    Public ReadOnly Property SwitchPathLength(channel As Integer) As String Implements IVIAVI.SwitchPathLength
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":FACT:MEAS:SWD? {0},1", channel))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.SwitchPathLength.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query or set the selected source wavelength (nm)
    ''' </summary>
    ''' <returns></returns>
    Public Property Wavelength As Integer Implements IVIAVI.Wavelength
        Get
            Try
                Return MyBase.SendSCPIComand(":SOURce:WAVelength?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.Wavelength.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":SOURce:WAVelength {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.Wavelength.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the DUT measurement range in meters
    ''' </summary>
    ''' <returns></returns>
    Public Property MeasRange As Integer Implements IVIAVI.MeasRange
        Get
            Try
                Return MyBase.SendSCPIComand(":SENSe:RANGe?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasRange.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":SENSe:RANGe {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasRange.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the “receive” jumper usage
    ''' 0 = Do not use
    ''' 1 = Use receive jumper
    ''' </summary>
    ''' <returns></returns>
    Public Property ReceiveJumperUsage As Integer Implements IVIAVI.ReceiveJumperUsage
        Get
            Try
                Return MyBase.SendSCPIComand(":PATH:RECeive?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.ReceiveJumperUsage.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:RECeive {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.ReceiveJumperUsage.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the length value of the “DUT Length estimation”.
    ''' </summary>
    ''' <returns></returns>
    Public Property DUTLengthEstimated As Double Implements IVIAVI.DUTLengthEstimated
        Get
            Try
                Return MyBase.SendSCPIComand(":PATH:DUT:LENGth?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.DUTLengthEstimated.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Double)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:DUT:LENGth {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.DUTLengthEstimated.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the “DUT Length Estimation” usage
    ''' 0 = Disable DUT Auto length (Use estimated Length)
    ''' 1 = Enable DUT Auto Length
    ''' </summary>
    ''' <returns></returns>
    Public Property DUTLengthAuto As Boolean Implements IVIAVI.DUTLengthAuto
        Get
            Try
                Return OneToTrue(MyBase.SendSCPIComand(":PATH:DUT:LENGth:AUTO?"))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.DUTLengthAuto.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Boolean)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:DUT:LENGth:AUTO {0}", TrueToOne(value)))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.DUTLengthAuto.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the MTJ jumper Length override value
    ''' 1 = MTJ1
    ''' 2 = MTJ2
    ''' 3 = Receive MTJ
    ''' </summary>
    ''' <param name="group"></param>
    ''' <returns></returns>
    Public Property JumperLengthOverrideValue(group As Integer) As Double Implements IVIAVI.JumperLengthOverrideValue
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":PATH:JUMP:LENG? {0},{1}", group, ActiveChannel))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperLengthOverrideValue.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Double)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:JUMP:LENG {0},{1},{2}", group, ActiveChannel, value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperLengthOverrideValue.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the MTJ jumper Length override option. If it is set to AUTO, then the overrides will be ignored and the measured value will be used.
    ''' 1 = MTJ1
    ''' 2 = MTJ2
    ''' 3 = Receive MTJ
    ''' 0 = Use override value
    ''' 1 = Use measured value
    ''' </summary>
    ''' <param name="group"></param>
    ''' <returns></returns>
    Public Property JumperLengthOverrideOption(group As Integer) As Integer Implements IVIAVI.JumperLengthOverrideOption
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":PATH:JUMP:LENG:AUTO? {0},{1}", group, ActiveChannel))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperLengthOverrideOption.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:JUMP:LENG:AUTO {0},{1},{2}", group, ActiveChannel, value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperLengthOverrideOption.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the MTJ jumper IL override value
    ''' 1 = MTJ1
    ''' 2 = MTJ2
    ''' 3 = Receive MTJ
    ''' </summary>
    ''' <param name="group"></param>
    ''' <returns></returns>
    Public Property JumperILOverrideValue(group As Integer) As Double Implements IVIAVI.JumperILOverrideValue
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":PATH:JUMP:IL? {0},{1}", group, ActiveChannel))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperILOverrideValue.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Double)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:JUMP:IL {0},{1},{2}", group, ActiveChannel, value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperILOverrideValue.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query or set the MTJ jumper IL override option. If it is set to AUTO, then the overrides will be ignored and the measured value will be used
    ''' 1 = MTJ1
    ''' 2 = MTJ2
    ''' 3 = Receive MTJ
    ''' 0 = Use override value
    ''' 1 = Use measured value
    ''' </summary>
    ''' <param name="group"></param>
    ''' <returns></returns>

    Public Property JumperILOverrideOption(group As Integer) As Integer Implements IVIAVI.JumperILOverrideOption
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":PATH:JUMP:IL:AUTO? {0},{1}", group, ActiveChannel))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperLengthOverrideOption.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:JUMP:IL:AUTO {0},{1},{2}", group, ActiveChannel, value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.JumperLengthOverrideOption.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Reset the MTJ jumper to default settings
    ''' </summary>
    ''' <param name="group"></param>
    Public Sub ResetJumperSetttings(group As Integer) Implements IVIAVI.ResetJumperSetttings
        Try
            MyBase.SendSCPIComand(String.Format(":PATH:JUMPer:RESet {0},{1}", group, ActiveChannel))
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.ResetJumperSetttings::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Query or set the list of channels to use for the specified switch
    ''' </summary>
    ''' <param name="switch"></param>
    ''' <returns></returns>
    Public Property SelectChannelList(switch As Integer) As String Implements IVIAVI.SelectChannelList
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":PATH:LIST? {0}", switch))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.SelectChannelList.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As String)
            Try
                MyBase.SendSCPIComand(String.Format(":PATH:LIST {0},{1}", switch, value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.SelectChannelList.Set()::" & ex.Message)
            End Try
        End Set
    End Property


    Private Property ActiveChannel As Integer Implements IVIAVI.ActiveChannel
        Get
            Return _ActiveChannel
        End Get
        Set(value As Integer)
            _ActiveChannel = value
        End Set
    End Property
    ''' <summary>
    ''' Enable or disables the live mode or query if Live mode is enabled
    ''' </summary>
    ''' <returns></returns>
    Public Property LiveMode As Integer Implements IVIAVI.LiveMode
        Get
            Try
                Return MyBase.SendSCPIComand(":SENSe:POWer:MODE?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LiveMode.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":SENSe:POWer:MODE {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LiveMode.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Query the optical power value in dBm when Live mode is enabled
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LiveModePower As String Implements IVIAVI.LiveModePower
        Get
            Try
                Return MyBase.SendSCPIComand(":FETCh:POWer?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LiveModePower.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the insertion loss value in dB when Live mode is enabled. The calculation will use the reference value that was made for the current measurement setup
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LiveModeLoss As String Implements IVIAVI.LiveModeLoss
        Get
            Try
                Return MyBase.SendSCPIComand(":FETCh:LOSS?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LiveModeLoss.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the Optical Return Loss value in dB when Live mode is enabled. The calculation will use the reference value that was made for the current measurement setup
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LiveModeORL As String Implements IVIAVI.LiveModeORL
        Get
            Try
                Return MyBase.SendSCPIComand(":FETCh:ORL?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LiveModeORL.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    Public ReadOnly Property LiveModeLossValue As String Implements IVIAVI.LiveModeValue
        Get
            Try
                Return MyBase.SendSCPIComand(":FETCh:LOSS?;:FETCh:ORL?;:FETCh:POWer?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.LiveModeLossValue.Get()::" & ex.Message)
            End Try
        End Get
    End Property
    ''' <summary>
    ''' Query the available measurement averaging times in seconds
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property AverageTimeAvailable As Integer Implements IVIAVI.AverageTimeAvailable
        Get
            Return MyBase.SendSCPIComand(":SENSe:ATIMe:AVAilable?")
        End Get
    End Property
    ''' <summary>
    ''' Set the measurement averaging time in seconds
    ''' </summary>
    ''' <returns></returns>
    Public Property AverageTime As Integer Implements IVIAVI.AverageTime
        Get
            Try
                Return MyBase.SendSCPIComand(":SENSe:ATIMe?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.AverageTime.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Integer)
            Try
                MyBase.SendSCPIComand(String.Format(":SENSe:ATIMe {0}", value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.AverageTime.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Set or query the “IL Only” DUT measurement option
    ''' </summary>
    ''' <returns></returns>
    Public Property ILOnly As Boolean Implements IVIAVI.ILOnly
        Get
            Try
                Return OneToTrue(MyBase.SendSCPIComand(":SENSe:ILONly?"))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.ILOnly.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As Boolean)
            Try
                MyBase.SendSCPIComand(String.Format(":SENSe:ILONly {0}", TrueToOne(value)))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.ILOnly.Set()::" & ex.Message)
            End Try
        End Set
    End Property
    ''' <summary>
    ''' Sets up one of the two ORL zones or Query the ORL Zone setup
    ''' </summary>
    ''' <param name="zone"></param>
    ''' <returns></returns>
    Public Property ORLSetup(zone As Integer) As String Implements IVIAVI.ORLSetup
        Get
            Try
                Return MyBase.SendSCPIComand(String.Format(":MEASure:ORL:SETup? {0}", zone))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.SelectChannelList.Get()::" & ex.Message)
            End Try
        End Get
        Set(value As String)
            Try
                MyBase.SendSCPIComand(String.Format(":MEASure:ORL:SETup {0},{1}", zone, value))
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.SelectChannelList.Set()::" & ex.Message)
            End Try
        End Set
    End Property

    Public ReadOnly Property MeasPower As Double Implements IVIAVI.MeasPower
        Get
            Try
                Return MyBase.SendSCPIComand(":MEASure:POWer?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasPower.Get()::" & ex.Message)
            End Try
        End Get
    End Property

    Public ReadOnly Property MeasLength As Double Implements IVIAVI.MeasLength
        Get
            Try
                Return MyBase.SendSCPIComand(":MEASure:LENGth?")
            Catch ex As Exception
                Throw New Exception("MAP300_PCT.MeasLength.Get()::" & ex.Message)
            End Try
        End Get
    End Property

    Public Sub SetLowerPowerMode() Implements IVIAVI.SetLowerPowerMode
        Try
            MyBase.SendSCPIComand(String.Format(":FACT:CONF:LPOW 1"))
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.ILOnly.SetLowerPowerMode()::" & ex.Message)
        End Try
    End Sub
    Public Sub ResetJumperMeasuredValue(group As Integer) Implements IVIAVI.ResetJumperMeasuredValue
        Try
            MyBase.SendSCPIComand(String.Format(":PATH:JUMPer:RESet:MEASure {0}", group))
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.ResetJumperMeasuredValue::" & ex.Message)
        End Try
    End Sub

    Public Sub MeasReset() Implements IVIAVI.MeasReset
        Try
            MyBase.SendSCPIComand(String.Format(":MEASure:RESet"))
        Catch ex As Exception
            Throw New Exception("MAP300_PCT.MeasReset::" & ex.Message)
        End Try
    End Sub
End Class

