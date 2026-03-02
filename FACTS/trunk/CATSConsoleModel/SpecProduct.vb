Option Strict Off
Imports System
Imports System.Collections.Generic
Public Class SpecProduct
    Public productM As New ProductProfile
    Public TestModeL As New List(Of SpecMode)
    'Public EventShowProgress As CATSConsoleModel.EventProgress
    Public Sub New()

    End Sub
    Public Sub New(pmM As FACTS.Model.product_main, ShowProgressFunc As CATSConsoleModel.EventProgress.ShowProgressHandlerEventHandler)
        Try

            If pmM Is Nothing Then
                productM = Nothing
                TestModeL = Nothing
            Else

                productM = New ProductProfile(pmM)

                Dim cqmBll As New FACTS.BLL.cq_modesManager
                Dim cqmL As List(Of FACTS.Model.cq_modes)

                cqmL = cqmBll.SelectAllByProductMainId(pmM.Id)

                If cqmL Is Nothing Then Return
                Dim rc As Integer = 0

                TestModeL = New List(Of SpecMode)

                For Each cqm In cqmL
                    TestModeL.Add(New SpecMode(cqm))
                    rc += 1
                    'EventShowProgress.ShowProgress(rc, cqmL.Count)
                    If ShowProgressFunc IsNot Nothing Then ShowProgressFunc(rc, cqmL.Count)
                Next
            End If


        Catch ex As Exception
            Throw New Exception("SpecProduct.New()::" & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Public Function CompareTo(value As List(Of SpecMode)) As Boolean
        Try
            Dim fM As SpecMode

            If TestModeL.Count <> value.Count Then Return False

            For Each tm In TestModeL

                fM = value.Find(Function(o) o.cq_modeM.mode.Trim.ToUpper = tm.cq_modeM.mode.Trim.ToUpper)
                If fM Is Nothing Then Return False

                If tm.CompareTo(fM) = False Then Return False

            Next

            Return True

        Catch ex As Exception
            Throw New Exception("SpecProduct.CompareTo(List(Of SpecMode))::" & ex.Message)
        End Try

    End Function
    Public Function CompareTo(value As SpecProduct) As Boolean
        Try
            'compare product profile
            If productM.CompareTo(value.productM) = False Then Return False

            'compare test mode list
            If CompareTo(value.TestModeL) = False Then Return False

            Return True

        Catch ex As Exception
            Throw New Exception("SpecProduct.CompareTo(SpecProduct)::" & ex.Message)
        End Try

    End Function


End Class

