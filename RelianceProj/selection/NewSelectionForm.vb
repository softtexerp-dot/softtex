Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid

Public Class NewSelectionForm

    ' Single Row Selection Result
    Public SelectedRowValues As New Dictionary(Of String, Object)()

    ' Multi Row Selection Result
    Public SelectedRowValuesList As New List(Of Dictionary(Of String, Object))()


    Public Property LoadQuery As String
    Public Property GridViewType As String
    Public Property F2MasterFormType As Type

    Private Sub NewSelectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = 0
        Dim y As Integer = 0

        x = Screen.PrimaryScreen.WorkingArea.Width - 699
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 25
        Me.Location = New Point(x, y)

        SelectionGridControl.Width = Me.Width - 25
        SelectionGridControl.Height = Me.Height - 80
        txtSearch.Width = Me.Width


        If String.IsNullOrEmpty(LoadQuery) Then
            MessageBox.Show("No query provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If

        LoadDataFromQuery()

    End Sub

    Private Sub LoadDataFromQuery()
        Try
            Dim dt As New DataTable()
            sqL = LoadQuery.ToString
            sql_connect_slect()
            dt = DefaltSoftTable.Copy

            SelectionGrid.Columns.Clear()
            SelectionGridControl.DataSource = dt.Copy

            HideColumnsByName()

            If GridViewType = "SINGLE" Then
                DevGridFitColumnWiotScroll(SelectionGridControl, SelectionGrid)
            Else
                _DevGridColumSizeAutoAdjest(SelectionGridControl, SelectionGrid)
            End If



            SelectionGrid.OptionsView.ShowIndicator = False
            SelectionGrid.OptionsFind.AlwaysVisible = False
            SelectionGrid.OptionsView.ShowGroupPanel = False

            ' Column width auto fit करने के लिए:
            SelectionGrid.OptionsView.ColumnAutoWidth = True

            ' Horizontal scroll को disable करने के लिए:
            SelectionGrid.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never


            With SelectionGrid.Appearance
                .FocusedRow.ForeColor = Color.Empty
                .FocusedRow.Options.UseForeColor = False
                .HideSelectionRow.ForeColor = Color.Empty
                .HideSelectionRow.Options.UseForeColor = False
                .SelectedRow.ForeColor = Color.Empty
                .SelectedRow.Options.UseForeColor = False
                .Row.ForeColor = Color.Black ' Default for normal rows
            End With

            ' Disable HotTrack effect (mouse hover highlight)
            SelectionGrid.OptionsSelection.EnableAppearanceHotTrackedRow = False


            With SelectionGrid
                .OptionsSelection.EnableAppearanceFocusedCell = True
                .Appearance.FocusedCell.BackColor = Color.LightSkyBlue
                .Appearance.FocusedCell.ForeColor = Color.Black
            End With


            FocusGridRowBySearchText()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub FocusGridRowBySearchText()
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SelectionGrid

            If String.IsNullOrWhiteSpace(txtSearch.Text) Then Return

            Dim searchText As String = txtSearch.Text.Trim().ToLower()
            Dim firstCol As DevExpress.XtraGrid.Columns.GridColumn = view.VisibleColumns.FirstOrDefault()
            If firstCol IsNot Nothing Then
                For i As Integer = 0 To view.RowCount - 1
                    Dim cellValue As String = view.GetRowCellValue(i, firstCol).ToString().ToLower()
                    If cellValue.Contains(searchText) Then
                        view.FocusedRowHandle = i
                        Exit For
                    End If
                Next
            End If

            txtSearch.Focus()
            txtSearch.SelectAll()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SelectionGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles SelectionGrid.KeyDown
        Try
            If GridViewType = "SINGLE" Then

                If e.KeyCode = Keys.Enter Then
                    Dim rowHandle = SelectionGrid.FocusedRowHandle
                    If rowHandle >= 0 Then
                        _GridDataSelection(rowHandle)
                    End If
                End If
            Else
                If e.KeyCode = Keys.Enter Then
                    If SelectionGrid.GetFocusedRowCellValue("TickMark") = "" Then
                        SelectionGrid.SetRowCellValue(SelectionGrid.FocusedRowHandle, "TickMark", "True")
                    ElseIf SelectionGrid.GetFocusedRowCellValue("TickMark") = "True" Then
                        SelectionGrid.SetRowCellValue(SelectionGrid.FocusedRowHandle, "TickMark", "False")
                    ElseIf SelectionGrid.GetFocusedRowCellValue("TickMark") = "False" Then
                        SelectionGrid.SetRowCellValue(SelectionGrid.FocusedRowHandle, "TickMark", "True")
                    End If

                    ' Move to next row programmatically
                    Dim nextRowHandle = SelectionGrid.FocusedRowHandle + 1
                    If nextRowHandle < SelectionGrid.RowCount Then
                        SelectionGrid.FocusedRowHandle = nextRowHandle
                        SelectionGrid.FocusedColumn = SelectionGrid.VisibleColumns(0) ' Optional: focus first column
                    End If
                    e.Handled = True
                    e.SuppressKeyPress = True

                ElseIf e.KeyCode = Keys.F11 Then
                    _SelectAlldata()
                ElseIf e.KeyCode = Keys.F12 Then
                    _LoadSelectedData()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub _LoadSelectedData()
        SelectionGrid.ActiveFilter.Clear()
        _GridDataSelection(0)
    End Sub
    Private Sub _SelectAlldata()

        For i As Int64 = 0 To SelectionGrid.RowCount - 1
            If SelectionGrid.GetRowCellValue(i, "TickMark").ToString = True Then
                SelectionGrid.SetRowCellValue(i, "TickMark", "False")
            Else
                SelectionGrid.SetRowCellValue(i, "TickMark", "True")
            End If
        Next
    End Sub


    Private Sub _GridDataSelection(ByVal rowHandle)

        If GridViewType = "SINGLE" Then
            SelectedRowValues.Clear()

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In SelectionGrid.Columns
                Dim colName = col.FieldName
                Dim value = SelectionGrid.GetRowCellValue(rowHandle, colName)
                SelectedRowValues(colName) = If(value IsNot Nothing, value, "")
            Next

        Else ' MULTI
            SelectedRowValuesList.Clear()

            For i As Integer = 0 To SelectionGrid.RowCount - 1
                Dim isTicked As Boolean = False

                If Not IsDBNull(SelectionGrid.GetRowCellValue(i, "TickMark")) Then
                    isTicked = Convert.ToBoolean(SelectionGrid.GetRowCellValue(i, "TickMark"))
                End If

                If isTicked Then
                    Dim rowDict As New Dictionary(Of String, Object)

                    For Each col As DevExpress.XtraGrid.Columns.GridColumn In SelectionGrid.Columns
                        Dim colName = col.FieldName
                        Dim value = SelectionGrid.GetRowCellValue(i, colName)
                        rowDict(colName) = If(value IsNot Nothing, value, "")
                    Next

                    SelectedRowValuesList.Add(rowDict)
                End If
            Next


        End If


        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
    Private Sub HideColumnsByName()
        Try


            Dim _TickMarkClm As String = ""
            If GridViewType = "SINGLE" Then
                _TickMarkClm = "TickMark"
            Else

                Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(SelectionGridControl.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
                repositoryCheckEdit1.ValueChecked = "True"
                repositoryCheckEdit1.ValueUnchecked = "False"
                SelectionGrid.Columns("TickMark").ColumnEdit = repositoryCheckEdit1
            End If

            Dim columnsToHide As String() = {"ACCOUNTCODE", "CITYCODE", "GROUPCODE", "ID", _TickMarkClm, "BlackList", "CountCode", "ItemCode"}

            For Each colName In columnsToHide
                Dim col = SelectionGrid.Columns.ColumnByFieldName(colName)
                If col IsNot Nothing Then
                    col.Visible = False
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SelectionGrid_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles SelectionGrid.RowStyle
        Dim view As GridView = CType(sender, GridView)
        If e.RowHandle < 0 Then Return

        ' Get cell value for BlackList
        Dim blackListValue = view.GetRowCellValue(e.RowHandle, "BlackList")
        If blackListValue IsNot Nothing AndAlso blackListValue.ToString().Trim().ToUpper() = "YES" Then
            ' Apply red color regardless of focus or selection
            e.Appearance.ForeColor = Color.Red
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            e.HighPriority = True ' 🔑 ensures it overrides default hover/select styles
        End If
    End Sub

    Private Sub frmAccountSelect_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F2 AndAlso F2MasterFormType IsNot Nothing Then
                Me.Enabled = False

                Dim frmMaster As Form = CType(Activator.CreateInstance(F2MasterFormType), Form)
                frmMaster.StartPosition = FormStartPosition.CenterParent
                _callByOtherFrom = True
                Dim dialogResult = frmMaster.ShowDialog(Me)

                Me.Enabled = True
                Me.BringToFront()

                ' Refresh grid
                If Not String.IsNullOrEmpty(LoadQuery) Then
                    LoadDataFromQuery()
                End If

                If dialogResult = DialogResult.OK Then
                    ' Try to get the CreatedAccountName using reflection
                    Dim prop = frmMaster.GetType().GetProperty("CreatedAccountName")
                    If prop IsNot Nothing Then
                        Dim newAccount As String = CStr(prop.GetValue(frmMaster, Nothing))
                        If Not String.IsNullOrWhiteSpace(newAccount) Then
                            txtSearch.Text = newAccount
                            txtSearch.Focus()
                            txtSearch.SelectAll()

                            Application.DoEvents()
                            SendKeys.Flush()
                        End If
                    End If
                End If

            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
                Me.Dispose(True)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SelectionGrid

            If txtSearch.Text.Trim() = "" Then
                view.ActiveFilter.Clear()
            Else
                Dim firstCol As DevExpress.XtraGrid.Columns.GridColumn = view.VisibleColumns.FirstOrDefault()
                If firstCol IsNot Nothing Then
                    Dim filterText As String = txtSearch.Text.Replace("'", "''")
                    If GridViewType = "SINGLE" Then
                        view.ActiveFilterString = String.Format("Contains([{0}], '{1}')", view.VisibleColumns(0).FieldName, filterText)
                    ElseIf GridViewType = "MULTY" AndAlso view.VisibleColumns.Count > 1 Then
                        view.ActiveFilterString = String.Format("Contains([{0}], '{1}')", view.VisibleColumns(1).FieldName, filterText)
                    End If

                End If
            End If
            'SelectionGridControl.Focus()       ' Control-level focus
            'view.Focus()               ' View-level focus
            'If view.RowCount > 0 Then
            '    view.FocusedRowHandle = 0
            'End If
            If view.RowCount > 0 Then
                view.TopRowIndex = view.GetRowHandle(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles SelectionGrid.KeyDown
        Try
            ' Arrow keys → allow grid to move
            If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.F11 OrElse e.KeyCode = Keys.F12 Then
                Return
            End If

            If GridViewType = "MULTY" Then
                If e.KeyCode = Keys.Enter Then
                    Exit Sub
                End If
            End If


            txtSearch.Focus()

            Dim keyChar As Char = ChrW(e.KeyValue)
            If Char.IsLetterOrDigit(keyChar) OrElse Char.IsPunctuation(keyChar) OrElse Char.IsSymbol(keyChar) OrElse keyChar = " "c Then
                txtSearch.Text &= keyChar
                txtSearch.SelectionStart = txtSearch.Text.Length
                txtSearch.SelectionLength = 0
            End If
            e.Handled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SelectionGrid

            If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
                SelectionGridControl.Focus()
                view.Focus()
                e.Handled = True
            End If


            If GridViewType = "SINGLE" Then
                If e.KeyCode = Keys.Enter Then
                    Dim rowHandle = SelectionGrid.FocusedRowHandle
                    If rowHandle >= 0 Then
                        _GridDataSelection(rowHandle)
                    End If
                    e.Handled = True
                End If
            Else
                'SelectionGridControl.Focus()
                If e.KeyCode = Keys.F11 Then
                    _SelectAlldata()
                ElseIf e.KeyCode = Keys.F12 Then
                    _LoadSelectedData()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



End Class