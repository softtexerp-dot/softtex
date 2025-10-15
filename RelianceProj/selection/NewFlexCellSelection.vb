

Imports DevExpress.XtraRichEdit.Import.Doc

Friend Class NewFlexCellSelection
    ' Single Row Selection Result
    Public SelectedRowValues As New Dictionary(Of String, Object)()

    ' Multi Row Selection Result
    Public SelectedRowValuesList As New List(Of Dictionary(Of String, Object))()

    Public Property LoadQuery As String
    Public Property GridViewType As String
    Public Property F2MasterFormType As Type



    Private listsource As String
    Private seekdata As String, cnt As Integer, pname As String, ln As Integer, rws As Integer, FOUND As Boolean
    Private t1 As TextBox
    Private t2 As Control

    Private strt_row As Integer = 0
    Private end_row As Double
    Private find_dir As Integer = 1
    Private PreviousFormName As String
    Private First_Char As Boolean
    Private Sub NewFlexCellSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = 0
        Dim y As Integer = 0

        x = Screen.PrimaryScreen.WorkingArea.Width - 699
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 25
        Me.Location = New Point(x, y)

        SelectionGrid.Width = Me.Width - 25
        SelectionGrid.Height = Me.Height - 80
        TxtSeek.Width = Me.Width


        If String.IsNullOrEmpty(LoadQuery) Then
            MessageBox.Show("No query provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        LoadDataFromQuery()

        HideColumnsByNameAndAutoFit()

    End Sub
    Private Sub LoadDataFromQuery()
        Dim dt As New DataTable()
        sqL = LoadQuery.ToString
        sql_connect_slect()
        dt = DefaltSoftTable.Copy

        SelectionGrid.DataSource = dt.Copy
        SelectionGrid.Column(0).Visible = False

        rws = SelectionGrid.Rows
        If SelectionGrid.Rows > 1 Then SelectionGrid.Range(1, 1, 1, 2).SelectCells()
    End Sub
    Private Sub HideColumnsByNameAndAutoFit()
        Dim _TickMarkClm As String = ""
        If GridViewType = "SINGLE" Then
            _TickMarkClm = "TickMark"
        End If

        Dim columnsToHide As String() = {"ACCOUNTCODE", "CITYCODE", "GROUPCODE", "ID", _TickMarkClm, "BlackList"}

        ' Step 1: Hide columns
        For Each colName In columnsToHide
            Dim colIndex As Integer = -1
            For i As Integer = 0 To SelectionGrid.Cols - 1
                If SelectionGrid.Cell(0, i).Text.Trim().ToUpper() = colName.Trim().ToUpper() Then
                    colIndex = i
                    Exit For
                End If
            Next
            If colIndex >= 0 Then
                SelectionGrid.Column(colIndex).Visible = False
            End If
        Next

        ' Step 2: Auto fit remaining columns to total grid width
        Dim visibleColCount As Integer = 0
        For i As Integer = 0 To SelectionGrid.Cols - 1
            If SelectionGrid.Column(i).Visible Then
                visibleColCount += 1
            End If
        Next

        If visibleColCount > 0 Then
            Dim newWidth As Integer = SelectionGrid.Width \ visibleColCount
            For i As Integer = 0 To SelectionGrid.Cols - 1
                If SelectionGrid.Column(i).Visible Then
                    ' Set equal width
                    SelectionGrid.Column(i).Width = newWidth - 7

                    ' Header alignment to Left
                    SelectionGrid.Cell(0, i).Alignment = FlexCell.AlignmentEnum.LeftCenter
                End If
            Next
        End If

    End Sub

    Private Sub TxtSeek_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSeek.KeyPress
        If SelectionGrid.Rows = 1 Then e.Handled = True
    End Sub
    Private Sub TxtSeek_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSeek.TextChanged
        pname = Trim(TxtSeek.Text.ToUpper())
        ln = Len(pname)
        FOUND = False

        If ln = 1 Then
            strt_row = 1
            end_row = SelectionGrid.Rows - 1
        End If

        Try
            FOUND = SeekinGrid(SelectionGrid, pname, 1, strt_row, end_row, find_dir)
            If FOUND = False Then
                Beep()
                If Len(Trim(TxtSeek.Text)) > 0 Then
                    TxtSeek.Text = Mid(pname, 1, ln - 1)
                    TxtSeek.SelectionStart = Len(TxtSeek.Text)
                End If
            End If
        Catch ex As Exception
            ' Error ignore
        End Try
    End Sub


    Private Function SeekinGrid(ByRef SelectionGrid As FlexCell.Grid, ByVal data As String, ByVal colIndex As Integer, ByRef start As Integer, ByRef ending As Integer, Optional ByVal direction As Integer = 1) As Boolean
        Dim res As Boolean = False
        Dim temp, cnt As Integer
        Dim keepColorColumnIndex As Integer = 2 ' jis column ka color change nahi karna

        If data = "" Then
            res = True
            start = 1
            ending = SelectionGrid.Rows - 1
            GoTo SELECT_CELL
        End If

        If direction = 1 Then
            For cnt = start To ending
                Dim cellText As String = ""
                If Not SelectionGrid.Cell(cnt, colIndex) Is Nothing Then
                    cellText = SelectionGrid.Cell(cnt, colIndex).Text.ToUpper()
                End If

                If Mid(cellText, 1, Len(data)) = data Then
                    res = True
                    temp = cnt
                    start = cnt

                    ' Find last row matching
                    Do While temp <= SelectionGrid.Rows - 1
                        Dim nextText As String = ""
                        If Not SelectionGrid.Cell(temp, colIndex) Is Nothing Then
                            nextText = SelectionGrid.Cell(temp, colIndex).Text.ToUpper()
                        End If
                        If Mid(nextText, 1, Len(data)) <> data Then Exit Do
                        temp += 1
                    Loop
                    ending = temp - 1
                    Exit For
                End If
            Next
        End If

SELECT_CELL:
        If res = True Then
            ' Full row selection
            SelectionGrid.Range(start, 0, ending, SelectionGrid.Cols - 1).SelectCells()

            ' Reset specific column color
            For r As Integer = start To ending
                Dim originalBackColor As Color = SelectionGrid.Cell(r, keepColorColumnIndex).BackColor
                Dim originalForeColor As Color = SelectionGrid.Cell(r, keepColorColumnIndex).ForeColor
                SelectionGrid.Cell(r, keepColorColumnIndex).BackColor = originalBackColor
                SelectionGrid.Cell(r, keepColorColumnIndex).ForeColor = originalForeColor
            Next
        End If
        Return res
    End Function

    Private Sub TxtSeek_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSeek.KeyDown
        Try
            If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Then
                e.Handled = True
            ElseIf e.KeyCode = Keys.Home Then
                If SelectionGrid.Rows > 2 Then
                    SelectionGrid.Focus()
                    SelectionGrid.Range(1, 1, 1, 2).SelectCells()
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.End Then
                If SelectionGrid.Rows > 2 Then
                    SelectionGrid.Focus()
                    SelectionGrid.Range(SelectionGrid.Rows - 1, 1, SelectionGrid.Rows - 1, 2).SelectCells()
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.PageUp Then
                If SelectionGrid.Rows > 2 Then
                    If SelectionGrid.ActiveCell.Row > 25 Then
                        SelectionGrid.Focus()
                        SelectionGrid.Range(SelectionGrid.ActiveCell.Row - 24, 1, SelectionGrid.ActiveCell.Row - 24, 2).SelectCells()
                        e.Handled = True
                    Else
                        SelectionGrid.Focus()
                        SelectionGrid.Range(1, 1, 1, 2).SelectCells()
                        e.Handled = True
                    End If
                End If
            ElseIf e.KeyCode = Keys.PageDown Then
                If SelectionGrid.Rows > 2 Then
                    If SelectionGrid.ActiveCell.Row + 25 < SelectionGrid.Rows - 1 Then
                        SelectionGrid.Focus()
                        SelectionGrid.Range(SelectionGrid.ActiveCell.Row + 24, 1, SelectionGrid.ActiveCell.Row + 24, 2).SelectCells()
                        e.Handled = True
                    Else
                        SelectionGrid.Focus()
                        SelectionGrid.Range(SelectionGrid.Rows - 1, 1, SelectionGrid.Rows - 1, 2).SelectCells()
                        e.Handled = True
                    End If
                End If
            ElseIf e.KeyCode = Keys.Up Then
                SelectionGrid.Focus()
                'SelectionGrid.Range(SelectionGrid.ActiveCell.Row, 1, SelectionGrid.ActiveCell.Row, 2).SelectCells()
                e.Handled = True
            ElseIf e.KeyCode = Keys.Down Then
                SelectionGrid.Focus()
                'SelectionGrid.Range(SelectionGrid.ActiveCell.Row, 1, SelectionGrid.ActiveCell.Row, 2).SelectCells()
                e.Handled = True
            ElseIf e.KeyCode = Keys.F4 Then
                If SelectionGrid.Rows > 2 Then
                    Dim Title_Str As String = SelectionGrid.Cell(0, 3).Text
                    If Title_Str <> "" Then
                        Title_Str = "Enter " & Title_Str & " Value"
                    Else
                        Title_Str = "Enter Value For Filter Second Column"
                    End If
                    Dim Filter_Str As String = Trim(InputBox(Title_Str, Title_Str, "", Me.Left + 45, Me.Top + 200))
                    SelectionGrid.AutoRedraw = False
                    For I As Int16 = 1 To SelectionGrid.Rows - 1
                        If Filter_Str <> "" Then
                            If Mid(SelectionGrid.Cell(I, 3).Text, 1, Len(Filter_Str)) = Filter_Str Then
                                SelectionGrid.Row(I).Visible = True
                            Else
                                SelectionGrid.Row(I).Visible = False
                            End If
                        Else
                            SelectionGrid.Row(I).Visible = True
                        End If
                    Next
                    SelectionGrid.AutoRedraw = True
                    SelectionGrid.Refresh()
                End If
            ElseIf e.KeyCode = 13 Then
                If SelectionGrid.ActiveCell.Row > 0 Then
                    t2.Text = Trim(SelectionGrid.Cell(SelectionGrid.ActiveCell.Row, 2).Text)
                    t1.Text = SelectionGrid.Cell(SelectionGrid.ActiveCell.Row, 1).Text

                    Me.Close()
                Else
                    'MsgBox(SelectionGrid.ActiveCell.Row)
                    'MsgBox("Please select a company to move on ")
                    Me.Close()
                End If
            Else

                If e.KeyCode = 8 Then
                    find_dir = 0
                Else
                    find_dir = 1
                End If
                e.Handled = False


            End If
            'MsgBox("KEY")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub TxtSeek_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        TxtSeek.SelectionStart = Len(TxtSeek.Text)
    End Sub
    Private Sub SelectionGrid_DoubleClick(ByVal Sender As Object, ByVal e As System.EventArgs) Handles SelectionGrid.DoubleClick
        t2.Text = Trim(SelectionGrid.Cell(SelectionGrid.ActiveCell.Row, 2).Text)
        t1.Text = SelectionGrid.Cell(SelectionGrid.ActiveCell.Row, 1).Text
        Me.Close()
    End Sub
    Private Sub SelectionGrid_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SelectionGrid.KeyDown
        Try
            If e.KeyCode = 13 Then
                e.Handled = True
                t2.Text = Trim(SelectionGrid.Cell(SelectionGrid.ActiveCell.Row, 2).Text)
                t1.Text = SelectionGrid.Cell(SelectionGrid.ActiveCell.Row, 1).Text
                Me.Close()
            ElseIf Not (e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.F4) Then
                e.Handled = True
                TxtSeek.Focus()
                TxtSeek.Text = TxtSeek.Text & Chr(e.KeyCode)
                TxtSeek.SelectionStart = Len(TxtSeek.Text)
            ElseIf e.KeyCode = Keys.Home Then
                If SelectionGrid.Rows > 2 Then
                    SelectionGrid.Focus()
                    SelectionGrid.Range(1, 1, 1, 2).SelectCells()
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.End Then
                If SelectionGrid.Rows > 2 Then
                    SelectionGrid.Focus()
                    SelectionGrid.Range(SelectionGrid.Rows - 1, 1, SelectionGrid.Rows - 1, 2).SelectCells()
                    e.Handled = True
                End If
            ElseIf e.KeyCode = Keys.PageUp Then
                If SelectionGrid.Rows > 2 Then
                    If SelectionGrid.ActiveCell.Row > 23 Then
                        SelectionGrid.Focus()
                        SelectionGrid.Range(SelectionGrid.ActiveCell.Row - 22, 1, SelectionGrid.ActiveCell.Row - 22, 2).SelectCells()
                        e.Handled = True
                    Else
                        SelectionGrid.Focus()
                        SelectionGrid.Range(1, 1, 1, 2).SelectCells()
                        e.Handled = True
                    End If
                End If
            ElseIf e.KeyCode = Keys.PageDown Then
                If SelectionGrid.Rows > 2 Then
                    If SelectionGrid.ActiveCell.Row + 23 < SelectionGrid.Rows - 1 Then
                        SelectionGrid.Focus()
                        SelectionGrid.Range(SelectionGrid.ActiveCell.Row + 22, 1, SelectionGrid.ActiveCell.Row + 22, 2).SelectCells()
                        e.Handled = True
                    Else
                        SelectionGrid.Focus()
                        SelectionGrid.Range(SelectionGrid.Rows - 1, 1, SelectionGrid.Rows - 1, 2).SelectCells()
                        e.Handled = True
                    End If
                End If
            ElseIf e.KeyCode = Keys.F4 Then
                If SelectionGrid.Rows > 2 Then
                    Dim Title_Str As String = SelectionGrid.Cell(0, 3).Text
                    If Title_Str <> "" Then
                        Title_Str = "Enter " & Title_Str & " Value"
                    Else
                        Title_Str = "Enter Value For Filter Second Column"
                    End If
                    Dim Filter_Str As String = Trim(InputBox(Title_Str, Title_Str, "", Me.Left + 45, Me.Top + 200))
                    SelectionGrid.AutoRedraw = False
                    For I As Int16 = 1 To SelectionGrid.Rows - 1
                        If Filter_Str <> "" Then
                            If Mid(SelectionGrid.Cell(I, 3).Text, 1, Len(Filter_Str)) = Filter_Str Then
                                SelectionGrid.Row(I).Visible = True
                            Else
                                SelectionGrid.Row(I).Visible = False
                            End If
                        Else
                            SelectionGrid.Row(I).Visible = True
                        End If
                    Next
                    SelectionGrid.AutoRedraw = True
                    SelectionGrid.Refresh()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub FrmSelectionList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            't1.Text = ""
            't2.Text = ""
            e.Handled = True
            Me.Close()
        ElseIf e.KeyCode = Keys.F2 Then

        End If
    End Sub
End Class