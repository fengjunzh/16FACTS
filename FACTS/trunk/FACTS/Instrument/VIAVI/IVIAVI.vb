Public Interface IVIAVI
    ReadOnly Property WavelengthAvailable As String
    Property Wavelength As Integer
    ReadOnly Property ChannelAvailable As Integer
    Property Channel(group As Integer) As Integer
    Property WavelengthList As String
    Property MeasFunction As Integer
    Property LaunchPort As Integer
    Property MTJConnection As Integer
    Sub MeasStart()
    Sub MeasStop()
    ReadOnly Property MeasState As MeasState
    ReadOnly Property PCTState As Integer
    Sub LaunchPCT()
    Sub ExitPCT()
    ReadOnly Property MeasResAll(Optional recChannel As Integer = 0) As String
    ReadOnly Property CalibrationDate As DateTime
    ReadOnly Property FrontPanelDistance As String
    ReadOnly Property FrontPanelPowerRatio As String
    ReadOnly Property SwitchPathLength(channel As Integer) As String
    Sub FactoryCalMeasStart(stp As Integer)
    Sub FactoryCalMeasCommit(stp As Integer)
    Sub WaitOPC(timeOutSec As Integer)
    Function WaitOPCResponse(timeOutSec As Integer) As String
    Property MeasRange As Integer
    Property ReceiveJumperUsage As Integer
    Property DUTLengthEstimated As Double
    Property DUTLengthAuto As Boolean
    Property JumperLengthOverrideValue(group As Integer) As Double
    Property JumperLengthOverrideOption(group As Integer) As Integer
    Property JumperILOverrideValue(group As Integer) As Double
    Property JumperILOverrideOption(group As Integer) As Integer
    Sub ResetJumperSetttings(group As Integer)
    Property SelectChannelList(switch As Integer) As String
    Sub Reset()
    Property ActiveChannel As Integer
    Property LiveMode As Integer
    ReadOnly Property LiveModePower As String
    ReadOnly Property LiveModeLoss As String
    ReadOnly Property LiveModeORL As String
    ReadOnly Property AverageTimeAvailable As Integer
    Property AverageTime As Integer
    ReadOnly Property LiveModeValue As String
    Property ILOnly As Boolean
    Property ORLSetup(zone As Integer) As String
    ReadOnly Property MeasPower As Double
    Sub SetLowerPowerMode()
    Sub ResetJumperMeasuredValue(group As Integer)
    ReadOnly Property MeasLength As Double
    Sub MeasReset()
End Interface
Public Enum MeasState
    INIT = 0
    IDLE = 1
    BUSY = 2
    FAULT = 3
    SYSTEM = 4
End Enum
Public Enum InstrumentType
    NA = 0
    MAP200_PCT = 1
    MAP300_PCT = 2
End Enum
Public Enum numPFAState
    NA = 0
    P = 1
    F = 2
    A = 3
End Enum
