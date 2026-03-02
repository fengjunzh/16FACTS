Imports System.Xml
Imports System.Xml.Serialization

Public MustInherit Class CalibrateIO
    Public MustOverride Function TotalItems() As List(Of CalibrateItem)
    Public MustOverride Function AddItem(calItem As CalibrateItem) As Boolean
    Public MustOverride Function SelectItem(calItem As CalibrateItem) As CalibrateItem
End Class
Public Class CalibrateIOFile
    Inherits CalibrateIO
    Public CalItems As New List(Of CalibrateItem)
    Private fileName As String = String.Format("{0}CalItems.xml", "C:\Andrew\test_system\")

    Public Sub Save()
        Try
            Dim XSerz As New XmlSerializer(Me.GetType)
            Dim StrmWt As New System.IO.StreamWriter(fileName)
            XSerz.Serialize(StrmWt, Me)
            StrmWt.Close()
        Catch ex As Exception
            Throw New Exception("CalibrateIOFile.Save() - " & ex.Message)
        End Try
    End Sub
    Public Shared Function CreateInstance(fileName As String) As CalibrateIOFile
        Try
            If IO.File.Exists(fileName) = False Then
                Return Nothing
            Else
                Dim CalIOFile As CalibrateIOFile = Nothing
                Using StrmRd As New System.IO.StreamReader(fileName)
                    Dim XSerz As New XmlSerializer(GetType(CalibrateIOFile))
                    CalIOFile = CType(XSerz.Deserialize(StrmRd), CalibrateIOFile)
                    StrmRd.Close()
                End Using
                Return CalIOFile
            End If
        Catch ex As Exception
            Throw New Exception(String.Format("CalibrateIOFile.CreateInstance() - Read file '{0}' fail!", fileName) & vbNewLine & ex.Message)
        End Try
    End Function

    Public Overrides Function AddItem(calItem As CalibrateItem) As Boolean
        Try
            Dim cItem As CalibrateItem = CalItems.Find(Function(o) o.FileName = calItem.FileName)
            Dim calItemidx As Integer
            If cItem Is Nothing Then
                CalItems.Add(calItem)
            Else
                calItemidx = CalItems.IndexOf(cItem)
                CalItems.Item(calItemidx) = calItem
            End If

            Save()

            Return True

        Catch ex As Exception
            Throw New Exception("CalibrateIOFile.Add() - " & ex.Message)
        End Try
    End Function
    Public Overrides Function TotalItems() As List(Of CalibrateItem)
        Try
            Return Me.CalItems
        Catch ex As Exception
            Throw New Exception("CalibrateIOFile.TotalItems() - " & ex.Message)
        End Try
    End Function
    Public Overrides Function SelectItem(calItem As CalibrateItem) As CalibrateItem
        Try
            Dim resp As CalibrateItem = CalItems.Find(Function(o) o.FileName = calItem.FileName)

            Return resp

        Catch ex As Exception
            Throw New Exception("CalibrateIOFile.SelectItem() - " & ex.Message)
        End Try
    End Function

End Class
