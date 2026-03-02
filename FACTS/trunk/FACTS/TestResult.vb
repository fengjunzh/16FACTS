Imports System.Xml.Serialization
Imports System.IO
Imports System.Diagnostics
Imports FACTS.Model

Public Class CFlag
    Public InsertSN As Boolean
    Public MTS As Boolean
End Class
Public Class CTestMisc
    Public MIIOnline As Boolean
End Class
Public Class CHead
    Public SerialNumber As String
    Public ProductName As String
    Public WorkOrder As String
    Public ProductMainId As Int32
    Public ProductModeId As Int32
    Public ProductMode As String
    Public SpecMainId As Int32
    Public PhaseMainId As Int32
    Public PhaseName As String
    Public PhaseStationMainId As String
    Public SoftwareRev As String
    Public MeasStartTime As DateTime
    Public MeasStopTime As DateTime
    Public MeasStatus As String
    Public ConnectTime As Integer
    Public MeasTime As Integer
    Public SetupTime As Integer
    Public TotalTime As Integer
    Public UserName As String
    Public Factory As String
    Public Controller As String
End Class

<XmlType("Part")>
Public Class CPart
    Public Index As Int32
    Public Model As String
    Public SerialNumber As String
    Public Hardware As String
    Public Firmware As String
    Public Mode As String
    Public TiltMin As Double
    Public TiltMax As Double
End Class

<XmlType("Instrument")>
Public Class CInstrument
    Public Model As String
    Public SerialNumber As String
    Public Hardware As String
    Public Firmware As String
    Public Idn As String
End Class

<XmlType("Trace")>
Public Class CTrace
    Public Index As Int32
    Public TraceName As String
    Public TraceX1 As String
    Public TraceX2 As String
    Public TraceX3 As String
    Public TraceX4 As String
    Public TraceY1 As String
    Public TraceY2 As String
    Public TraceY3 As String
    Public TraceY4 As String
End Class

Public Class CExtend
    <XmlElement>
    Public MeasValue As New List(Of String)
End Class
Public Class CTestItem
    Public SpecDetailId As Int32
    Public OrderIdx As String
    Public ORL1 As Double
    Public ORL2 As Double
    Public MeasValue As Double
    Public MeasString As String
    Public MeasStatus As String
    Public PlotPath As String
    Public Gen1 As String = 0 'FreshTest
    Public Traces As New List(Of CTrace)
    Public TestExtend As New CExtend
    Private _Name As String
    ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    Public Sub New(ByVal item As TestItem)
        _Name = item.Name
        SpecDetailId = item.ID
        OrderIdx = item.order_idx
        MeasString = ""
    End Sub
    Public Sub New()
    End Sub
End Class

Public Class CTestGroup
    Public GroupMainId As Int32
    Public GroupName As String
    Public GroupStatus As String
    Public GroupId As Integer

    <XmlElement("TestItem")>
    Public TestItems As New List(Of CTestItem)

    Public Sub New()
    End Sub
    Public Sub New(ByVal group As TestGroup)
        GroupMainId = group.ID
        GroupName = group.Name
        GroupId = group.GroupId
    End Sub
    Public Overrides Function ToString() As String
        Return GroupName.ToString()
    End Function
End Class

Public Class CTestPhase
    <XmlElement("TestGroup")>
    Public TestGroups As New List(Of CTestGroup)

    Public Sub New()

    End Sub
End Class
Public Class TestResult
    Public Type As Byte
    Public ConnString As String
    Public Flag As New CFlag
    Public TestMisc As New CTestMisc
    Public Head As New CHead
    Public AssyParts As New List(Of CPart)
    Public TestInstruments As New List(Of CInstrument)
    Public TestPhase As New CTestPhase
    Private UploadProgram As String
    Public Sub New(ByVal Program As String)
        Type = 0
        Head.Controller = My.Computer.Name
        UploadProgram = Program
    End Sub
    Public Sub New()
    End Sub
    Public Function GetFinalPassFailStatus(groupNum As Integer) As numPFAState
        Try
            If Me.TestPhase.TestGroups.Count < groupNum Then Return numPFAState.A

            For Each group As CTestGroup In Me.TestPhase.TestGroups
                If group.GroupStatus = "F" Then
                    Return numPFAState.F
                End If
            Next

            Return numPFAState.P
        Catch ex As Exception
            Throw New Exception("TestResult.GetFinalPassFailStatus() - " & ex.Message)
        End Try
    End Function
    Public Function GetConenctorTestStatus(isSecondSn As Boolean)
        Try
            Dim groupNum As Integer = Me.TestPhase.TestGroups.Count
            Dim halfGroupNum As Integer = groupNum \ 2
            Dim startIdx As Integer = 0
            Dim stopIdx As Integer = groupNum - 1
            If isSecondSn Then startIdx = halfGroupNum
            If isSecondSn = False Then stopIdx = halfGroupNum - 1
            For i As Integer = startIdx To stopIdx
                Me.TestPhase.TestGroups(i).GroupStatus = "F"
                Return False
            Next
            Return True
        Catch ex As Exception
            Throw New Exception("TestResult.GetConenctorTestStatusString() - " & ex.Message)
        End Try
    End Function
    Public Function GetGroupStatus(groupName) As Boolean
        Try
            Dim group As CTestGroup = Me.TestPhase.TestGroups.Find(Function(o) o.GroupName = groupName)

            If group.TestItems.Count = 0 Then Return False

            For Each item As CTestItem In group.TestItems
                'If item.MeasStatus = "F" And Not item.Name.Trim.ToUpper.Contains("LEN") Then Return False
                If item.MeasStatus = "F" Then Return False
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("TestResult.GetGroupStatus() - " & ex.Message)
        End Try
    End Function
    Public Function GetPassCount() As Integer
        Try
            Dim resp As Integer
            For Each group As CTestGroup In Me.TestPhase.TestGroups
                If group.GroupStatus = "P" Then
                    resp += 1
                End If
            Next
            Return resp
        Catch ex As Exception
            Throw New Exception("TestResult.GetPassCount() - " & ex.Message)
        End Try
    End Function
    Public Function GetFailCount() As Integer
        Try
            Dim resp As Integer
            For Each group As CTestGroup In Me.TestPhase.TestGroups
                If group.GroupStatus = "F" Then
                    resp += 1
                End If
            Next
            Return resp
        Catch ex As Exception
            Throw New Exception("TestResult.GetFailCount() - " & ex.Message)
        End Try
    End Function

    Public Sub SaveToFile(ByVal filename As String, Optional ByVal isEncryptAndUpload As Boolean = False, Optional ByVal startResultTransferTool As Boolean = True)
        Try
            Dim xmlExtension As String = ".xml"
            Dim xmlFile As String = filename
            If xmlFile.ToLower.EndsWith(xmlExtension.ToLower) Then
                xmlFile = xmlFile.Substring(0, xmlFile.Length - xmlExtension.Length)
            End If
            xmlFile = xmlFile + xmlExtension

            Dim SZ As New XmlSerializer(Me.GetType)
            Using SrWt = New StreamWriter(xmlFile, False)
                SZ.Serialize(SrWt, Me)
            End Using

            If isEncryptAndUpload Then
                Dim datExtension As String = ".dat"
                Dim datFile As String = xmlFile.Replace(xmlExtension, datExtension)
                Dim content As String
                Using StRd = New StreamReader(xmlFile)
                    content = StRd.ReadToEnd()
                End Using
                Dim en As New Encryptor.Encryptor
                en.EncryptToFile(content, datFile)

                File.Delete(xmlFile)

                If startResultTransferTool Then
                    If UploadProgram = "" Then Exit Try
                    Dim ProgramInfo As New FileInfo(UploadProgram)
                    If ProgramInfo.Exists = False Then Exit Try
                    Dim DataInfo As New FileInfo(datFile)
                    If DataInfo.Exists = False Then Exit Try

                    Dim process As New Process
                    Dim startinfo As New ProcessStartInfo
                    With startinfo
                        .WindowStyle = ProcessWindowStyle.Hidden
                        .FileName = ProgramInfo.Name
                        .WorkingDirectory = ProgramInfo.DirectoryName
                        .Arguments = String.Format("-h ""-p:{0}""", DataInfo.DirectoryName)
                    End With

                    process.StartInfo = startinfo
                    process.Start()
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
