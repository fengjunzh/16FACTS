Imports C1.Win.C1FlexGrid
Module GlobalFunc
    Public Function SortListAsc(list As List(Of Decimal)) As List(Of Decimal)
        Try

            list.Sort(Function(x, y) x < y)

            Return list

        Catch ex As Exception
            Throw New Exception("SortListAsc()::" & ex.Message)
        End Try
    End Function
    Public Function SortListDesc(list As List(Of Decimal)) As List(Of Decimal)
        Try

            list.Sort(Function(x, y) x > y)

            Return list

        Catch ex As Exception
            Throw New Exception("SortListDesc()::" & ex.Message)
        End Try
    End Function
    Public Function SortListAsc(list As List(Of Short)) As List(Of Short)
        Try

            list.Sort(Function(x, y) x > y)

            Return list

        Catch ex As Exception
            Throw New Exception("SortListAsc()::" & ex.Message)
        End Try
    End Function
    Public Function SortArrayAsc(arry() As Decimal) As Decimal()
        Try
            Dim ub As Integer = arry.GetUpperBound(0)
            Dim lb As Integer = arry.GetLowerBound(0)
            Dim tmp As Decimal = 0

            For i = lb To ub - 1
                For j = lb + 1 To ub
                    If arry(i) > arry(j) Then
                        tmp = arry(i)
                        arry(i) = arry(j)
                        arry(j) = tmp
                    End If
                Next
            Next

            Return arry

        Catch ex As Exception
            Throw New Exception("SortArrayAsc()::" & ex.Message)
        End Try
    End Function
    Public Function SortListAsc(list As List(Of String)) As List(Of String)
        Try
            Dim resp As New List(Of String)
            Dim tlist As New List(Of Decimal)

            For Each l In list
                If IsNumeric(l) = True Then tlist.Add(CType(l, Decimal))
            Next

            If list.Count = tlist.Count Then
                tlist.Sort(Function(x, y) x < y)
                For Each tl In tlist
                    resp.Add(CType(tl, String))
                Next
                Return resp
            Else
                list.Sort(Function(x, y) String.Compare(x, y))
                Return list
            End If

        Catch ex As Exception
            Throw New Exception("SortListAsc()::" & ex.Message)
        End Try
    End Function
    Public Function SortListDesc(list As List(Of String)) As List(Of String)
        Try
            Dim resp As New List(Of String)
            Dim tlist As New List(Of Decimal)

            For Each l In list
                If IsNumeric(l) = True Then tlist.Add(CType(l, Decimal))
            Next

            If list.Count = tlist.Count Then
                tlist.Sort(Function(x, y) x > y)
                For Each tl In tlist
                    resp.Add(CType(tl, String))
                Next
                Return resp
            Else
                list.Sort(Function(x, y) String.Compare(y, x))
                Return list
            End If

        Catch ex As Exception
            Throw New Exception("SortListDesc()::" & ex.Message)
        End Try
    End Function
    Public Function SortArrayDesc(arry() As Decimal) As Decimal()
        Try
            Dim ub As Integer = arry.GetUpperBound(0)
            Dim lb As Integer = arry.GetLowerBound(0)
            Dim tmp As Decimal = 0

            For i = lb To ub - 1
                For j = lb + 1 To ub
                    If arry(i) < arry(j) Then
                        tmp = arry(i)
                        arry(i) = arry(j)
                        arry(j) = tmp
                    End If
                Next
            Next

            Return arry

        Catch ex As Exception
            Throw New Exception("SortArrayDesc()::" & ex.Message)
        End Try
    End Function

    Public Function GetDbFile(OpenFileDialog As OpenFileDialog) As String
        Try
            Dim resp As String = Nothing

            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each filepath In OpenFileDialog.FileNames
                    resp = filepath
                Next
            End If

            Return resp

        Catch ex As Exception
            Throw New Exception("GetDbFile()::" & ex.Message)
        End Try
    End Function
    Public Sub FormatGrid(flexGrid As C1FlexGrid, captionFontSize As Short, normalStyleFontSize As Short)
        Try
            'adding Three-Dimensional Text to a Header Row
            Dim tdt As C1.Win.C1FlexGrid.CellStyle
            tdt = flexGrid.Styles.Add("3DText")
            tdt.TextEffect = C1.Win.C1FlexGrid.TextEffectEnum.Raised
            flexGrid.Rows(0).Style = tdt

            'adding Row Numbers in a Fixed Column
            flexGrid.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

            flexGrid.Styles.Fixed.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            flexGrid.Styles.Fixed.Font = New Font("Consolas", captionFontSize, FontStyle.Bold)

            For Each col As C1.Win.C1FlexGrid.Column In flexGrid.Cols
                col.TextAlign = TextAlignEnum.LeftCenter
            Next

            'set the border style property
            flexGrid.Styles("Normal").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Flat
            flexGrid.Styles("Normal").Border.Color = Color.DarkGray
            flexGrid.Styles("Normal").Font = New Font("Consolas", normalStyleFontSize, FontStyle.Regular)

            flexGrid.AutoSizeRows()
            flexGrid.AutoSizeCols()

        Catch ex As Exception
            Throw New Exception("Common.FormatFlexGrid()::" & ex.Message)
        End Try
    End Sub
End Module
