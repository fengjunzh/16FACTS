Public Class FormRetry
    Public Property ReturnTestGroup As CTestGroup
    Public Property ReturnTestType As Short = 0
    Public Property ReturnRetryType As Short = 0
    Private startTime As DateTime
    Private testItem As TestItem
    Private testRes As TestResult
    Private product_main As FACTS.Model.product_main
    Private testPhase As TestPhaseRlIl
    Private T_spec As TestSpec
    Private RetryTime As Integer = 180
    Private ResultTraceDic As Dictionary(Of String, Trace)
    Private CAPE_Retry_Type As Boolean
    Private tires As CTestItem
    Public Sub New(tItem As TestItem, _tires As CTestItem, tRes As TestResult, productM As FACTS.Model.product_main, tPhase As TestPhaseRlIl, spec As TestSpec)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        testItem = tItem
        testRes = tRes
        product_main = productM
        testPhase = tPhase
        T_spec = spec
        tires = _tires
    End Sub
    Private Sub FormRetry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.tsslStatus.Text = String.Format("{0} <{1}>", testItem.ParentGroup, testItem)
        Me.Label1.Text = ""
        startTime = Now
        Timer1.Enabled = True
        If tires.MeasStatus = "F" And tires.Name.StartsWith("RL") And gBenchSetting.TestType = numTestType.System Then
            Label1.Visible = True
            Label1.Text = String.Format("ORL1 = {0}; ORL2 = {1}", tires.ORL1, tires.ORL2)
        Else
            Label1.Visible = False
        End If
    End Sub

    Private Sub btnRetry_Click(sender As Object, e As EventArgs) Handles btnRetry.Click
        If rbRetryCurrentBand.Checked = True Then
            ReturnRetryType = 0
            ReturnTestGroup = Nothing
        ElseIf rbRetryAll.Checked = True Then
            ReturnRetryType = 1
            ReturnTestGroup = Nothing
        End If

        ReturnTestType = 0

        Me.Close()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        ReturnTestType = 1
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ReturnTestType = 2
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim timeSpan As TimeSpan
            timeSpan = startTime.AddSeconds(RetryTime).Subtract(Now)
            Me.tsslTimeElapsed.Text = String.Format("Time Left <{0:00}:{1:00}:{2:00}>", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds)
            If timeSpan.TotalSeconds < 1 Then
                Me.btnContinue.PerformClick()
            End If
        Catch ex As Exception
            Timer1.Enabled = False
            MsgBox("Timer1_Tick() - " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Exception ")
        End Try
    End Sub
End Class