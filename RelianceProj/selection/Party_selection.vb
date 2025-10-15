Imports System.Windows.Controls
Imports Microsoft.Office.Interop


Friend Class Party_selection
    Dim _DUPLICAT_BILL_FND As String = ""
    Private obj_Party_Selection As New Multi_Selection_Master
    Private OFORM As Form
    Dim pname As String = ""
    Dim ln As Integer = 1
    Dim FOUND As Boolean = True
    Dim _FormLodWidtha As Integer = 0
    Dim _CityFilterTrue As Boolean = False
    Dim _FormActive As Boolean = False


    Public Property LoadQuery As String
    Public Property GridViewType As String
    Public Property GridSelect As String
    Public Property F2MasterFormType As Type


    ' Single Row Selection Result
    Public SelectedRowValues As New Dictionary(Of String, Object)()

    ' Multi Row Selection Result
    Public SelectedRowValuesList As New List(Of Dictionary(Of String, Object))()


#Region "FORM LOAD"
    Private Sub Party_selection_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If GridSelect = "NEW SELECTION" Then

            If e.KeyCode = Keys.F2 AndAlso F2MasterFormType IsNot Nothing Then
                If _USERMASTERMENU = "N" Then
                    MsgBox("Function Not Allow This User", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

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
            End If

        Else
            If e.KeyCode = Keys.F2 Then
                F2_OPEN_FROM = True
                _SelectionListName = ""
                If _USERMASTERMENU = "N" Then
                    MsgBox("Function Not Allow This User", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                Call Master_open()
            End If
        End If



        If e.KeyCode = Keys.F4 Then
            pnl_Filter_Working.Visible = True
            lbl_Filter_Header.Text = "Enter " & String_To_Proper(dgw.Columns(1).Name)
            pnl_Filter_Working.BringToFront()
            txt_Filter_Text.Focus()
            txt_Filter_Text.Select()
            e.Handled = True

        ElseIf (ModifierKeys = Keys.Control AndAlso e.KeyCode = Keys.X) Then

            Dim xlapp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet

            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlapp = New Excel.Application
            xlWorkBook = xlapp.Workbooks.Add(misValue)
            xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Excel.Worksheet)

            For k = 0 To dgw.ColumnCount - 1
                xlWorkSheet.Cells(1, k + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Cells(1, k + 1) = dgw.Columns(k).Name
            Next
            For i = 0 To dgw.RowCount - 1
                For j = 0 To dgw.ColumnCount - 1
                    xlWorkSheet.Cells(i + 2, j + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    xlWorkSheet.Cells(i + 2, j + 1) =
                    dgw(j, i).Value.ToString()
                Next
            Next

            Dim SaveFileDialog1 As New SaveFileDialog()
            SaveFileDialog1.Filter = "Execl files (*.xlsx)|*.xlsx"
            SaveFileDialog1.FilterIndex = 2
            SaveFileDialog1.RestoreDirectory = True
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                MsgBox("Save file success")
            Else
                Return
            End If
            xlWorkBook.Close()
            xlapp.Quit()

        End If
    End Sub

    Private Sub Party_selection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = 0
        Dim y As Integer = 0
        _FormLodWidtha = Me.Width
        _CheckWhtaspOkNo = False
        _FormActive = True
        'x = Screen.PrimaryScreen.WorkingArea.Width - 744
        x = Screen.PrimaryScreen.WorkingArea.Width - 644
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        Me.Location = New Point(x, y)

        Me.Height = Screen_Height - 90
        GroupBox1.Height = Screen_Height - 90
        dgw.Height = Screen_Height - 170


        pnl_Filter_Working.Visible = False



        If GridSelect = "NEW SELECTION" Then
            LoadDataFromQuery()
        End If


        txtSearch.Focus()
        txtSearch.Select()
        txtSearch.Select(0, txtSearch.Text.Length)
    End Sub
    Private Sub LoadDataFromQuery()

        sqL = LoadQuery.ToString
        sql_connect_slect()

        dgw.RowTemplate.Height = 30

        dgw.DataSource = DefaltSoftTable.Copy

        HideColumnsByNameAndAutoFit()


        dgw.Focus()

        FocusGridRowBySearchText()
    End Sub
    Private Sub FocusGridRowBySearchText()
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then Return

        Dim searchText As String = txtSearch.Text.Trim().ToUpper

        If dgw.Columns.Count > 0 Then
            Dim firstCol As DataGridViewColumn = dgw.Columns(0)
            For i As Integer = 0 To dgw.Rows.Count - 1
                If Not dgw.Rows(i).IsNewRow Then
                    Dim cellValue As String = dgw.Rows(i).Cells(firstCol.Index).Value.ToString().ToUpper()
                    If cellValue.Contains(searchText) Then
                        dgw.CurrentCell = dgw.Rows(i).Cells(firstCol.Index)
                        dgw.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                End If
            Next
        End If

        txtSearch.Focus()
        txtSearch.SelectAll()
    End Sub

    Private Sub HideColumnsByNameAndAutoFit()
        Dim _TickMarkClm As String = ""
        If GridViewType = "SINGLE" Then
            _TickMarkClm = "TickMark"
        End If

        Dim columnsToHide As String() = {"ACCOUNTCODE", "CITYCODE", "GROUPCODE", "ID", _TickMarkClm, "BlackList"}

        ' Step 1: Hide specified columns
        For Each colName In columnsToHide
            If dgw.Columns.Contains(colName) Then
                dgw.Columns(colName).Visible = False
            End If
        Next

        ' Step 2: Auto fit remaining columns equally
        Dim visibleColCount As Integer = dgw.Columns.GetColumnCount(DataGridViewElementStates.Visible)

        If visibleColCount > 0 Then
            Dim totalWidth As Integer = dgw.Width
            Dim standardWidth As Integer = totalWidth \ visibleColCount
            Dim extraWidth As Integer = standardWidth + 100 ' First column wider

            Dim firstVisibleSet As Boolean = False

            For Each col As DataGridViewColumn In dgw.Columns
                If col.Visible Then
                    If Not firstVisibleSet Then
                        col.Width = extraWidth
                        firstVisibleSet = True
                    Else
                        col.Width = standardWidth - 5
                    End If
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                End If
            Next
        End If

        ' Step 3: Set row height to 25
        'dgw.RowTemplate.Height = 30
        'For Each row As DataGridViewRow In dgw.Rows
        '    row.Height = 30
        'Next

    End Sub

    Private Sub txt_Filter_Text_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Filter_Text.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_Filter_Text.Text <> "" Then
                _CityFilterTrue = True
                Dim Tmp_Tbl As New DataTable
                Tmp_Tbl = DefaltSoftTable.Clone
                Dim Col_Name_1 As String = "[" & dgw.Columns(0).Name & "]"
                Dim Col_Name_2 As String = "[" & dgw.Columns(1).Name & "]"
                Dim Total_Row As Integer = 0
                Dim Filter_Con As String = "(" & Col_Name_2 & " LIKE '" & txt_Filter_Text.Text & "*')"
                For Each dr As DataRow In DefaltSoftTable.Select(Filter_Con, Col_Name_1)
                    Tmp_Tbl.ImportRow(dr)
                    Total_Row = Total_Row + 1
                Next
                If Total_Row > 0 Then
                    txtSearch.Text = ""
                    dgw.DataSource = Tmp_Tbl.Copy
                    dgw.Focus()
                Else
                    MsgBox("No Record Found For : " & txt_Filter_Text.Text, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                End If
            End If
            pnl_Filter_Working.Visible = False
            dgw.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{DOWN}")
        ElseIf e.KeyCode = 37 Then ' Left Arrow
            txtSearch.Focus()
            e.Handled = True
        ElseIf e.KeyCode = 39 Then 'Right Arrow
            txtSearch.Focus()
            e.Handled = True
        ElseIf e.KeyCode = Keys.Up Then

        ElseIf e.KeyCode = Keys.Enter Then

            If GridSelect = "NEW SELECTION" Then
                ' Arrow key navigation
                If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up Then
                    dgw.Focus()
                    e.Handled = True
                End If

                ' ENTER key for SINGLE mode
                If GridViewType = "SINGLE" Then
                    If e.KeyCode = Keys.Enter Then
                        If dgw.CurrentRow IsNot Nothing Then
                            Dim rowIndex As Integer = dgw.CurrentRow.Index
                            If rowIndex >= 0 Then
                                _GridDataSelection(rowIndex)
                            End If
                        End If
                        e.Handled = True
                    End If
                Else
                    dgw.Focus()
                    If e.KeyCode = Keys.F11 Then
                        _SelectAlldata()
                    ElseIf e.KeyCode = Keys.F12 Then
                        _LoadSelectedData()
                    End If
                End If
            End If



        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress

        FOUND = False
        If e.KeyChar = Chr(27) Then

            If txtSearch.Text = "" Then
                If _CityFilterTrue = True Then
                    dgw.DataSource = DefaltSoftTable.Copy
                    dgw.Focus()
                    _CityFilterTrue = False
                    Exit Sub
                Else
                    Label2.Text = ""
                    Label3.Text = ""
                    Label6.Text = ""
                    Label7.Text = ""
                    MULTY_SELECTION_COLOUM_1_DATA = ""
                    MULTY_SELECTION_COLOUM_2_DATA = ""
                    MULTY_SELECTION_COLOUM_3_DATA = ""
                    MULTY_SELECTION_COLOUM_4_DATA = ""
                    MULTY_SELECTION_COLOUM_5_DATA = ""
                    MULTY_SELECTION_COLOUM_6_DATA = ""
                    MULTY_SELECTION_COLOUM_7_DATA = ""
                    _CheckWhtaspOkNo = False
                    F2_OPEN_FROM = False
                    Me.Close()
                    Me.Dispose(True)
                    Exit Sub
                End If
            Else
                txtSearch.Text = ""
                Exit Sub
            End If
        End If

        If e.KeyChar = Chr(13) Then
            If dgw.SelectedCells.Count > 0 Then
                _GetGridData()
                _CheckWhtaspOkNo = True
                Call listedit()
                F2_OPEN_FROM = False
                Me.Close()
                Me.Dispose(True)
                Exit Sub

            Else
                txtSearch.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtSearch.SelectionStart = Len(txtSearch.Text)
    End Sub

    Private Sub _TwoColoumShow()
        If dgw.RowCount > 1 Then
            dgw.Columns(2).Visible = False
            dgw.Columns(3).Visible = False
            dgw.Columns(4).Visible = False
            dgw.Columns(0).Width = 280
            dgw.Columns(1).Width = 200
            Width = 506
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If GridSelect = "NEW SELECTION" Then
            Dim filterText As String = txtSearch.Text.Trim().Replace("'", "''")

            ' Assuming your DataGridView is named "SelectionGrid"
            Dim dt As DataTable = TryCast(dgw.DataSource, DataTable)

            If dt IsNot Nothing Then
                Dim dv As DataView = dt.DefaultView

                If filterText = "" Then
                    dv.RowFilter = ""
                Else
                    If GridViewType = "SINGLE" AndAlso dgw.Columns.Count > 0 Then
                        dv.RowFilter = String.Format("[{0}] LIKE '%{1}%'", dgw.Columns(0).Name, filterText)
                    ElseIf GridViewType = "MULTY" AndAlso dgw.Columns.Count > 1 Then
                        dv.RowFilter = String.Format("[{0}] LIKE '%{1}%'", dgw.Columns(1).Name, filterText)
                    End If
                End If

                dgw.ClearSelection()
                If dgw.Rows.Count > 0 Then
                    dgw.Rows(0).Selected = True
                    dgw.CurrentCell = dgw.Rows(0).Cells(0)
                End If
            End If


        Else


            Dim s As String = ""
            Dim _SearchAny As Boolean = False

            If _FormActive = True Then
            Dim _Tmptbl As New DataTable
            If _ItemSearchTypingWise = "YES" Then
                _SearchAny = True
                _Tmptbl = DefaltSoftTable.Clone
                Dim Col_Name_1 As String = "[" & DefaltSoftTable.Columns(0).ColumnName & "]"
                Dim Col_Name_2 As String = "[" & DefaltSoftTable.Columns(2).ColumnName & "]"
                Dim Total_Row As Integer = 0
                Dim Filter_Con As String = "(" & Col_Name_1 & " like '%" & txtSearch.Text.Trim & "%')"

                For Each dr As DataRow In DefaltSoftTable.Select(Filter_Con, Col_Name_1)
                    _Tmptbl.ImportRow(dr)
                    Total_Row = Total_Row + 1
                Next
                'Else
                '    _Tmptbl = DefaltSoftTable.Copy

                dgw.DataSource = _Tmptbl.Copy
                If _FormLodWidtha = 644 Then
                Else
                    _TwoColoumShow()
                End If
            End If
        End If

        If txtSearch.Text <> "" Then
            s = txtSearch.Text.Trim
            dgw.CurrentCell = Nothing
            For x As Integer = 0 To dgw.Rows.Count - 1
                If CStr(dgw.Rows(x).Cells(0).Value).StartsWith(s).ToString Then
                    dgw.FirstDisplayedScrollingRowIndex = x
                    dgw.Item(0, x).Selected = True
                    _GetGridData()
                    FOUND = True
                    Exit For
                End If
            Next
        End If

            If _SearchAny = False Then
                pname = Trim(txtSearch.Text.ToUpper)
                ln = Len(pname)
                If FOUND = False Then
                    '    Beep()
                    If Len(Trim(txtSearch.Text)) > 0 Then txtSearch.Text = Mid(pname, 1, ln - 1)
                    txtSearch.SelectionStart = Len(txtSearch.Text)
                End If
            End If
        End If

    End Sub

    Private Sub _GetGridData()

        Label2.Text = dgw.SelectedCells(0).Value.ToString()
        Label3.Text = dgw.SelectedCells(2).Value.ToString()
        Label6.Text = dgw.SelectedCells(1).Value.ToString()
        Label7.Text = dgw.SelectedCells(3).Value.ToString()
        MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(0).Value.ToString()
        MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(1).Value.ToString()
        MULTY_SELECTION_COLOUM_3_DATA = dgw.SelectedCells(2).Value.ToString()
        MULTY_SELECTION_COLOUM_4_DATA = dgw.SelectedCells(3).Value.ToString()
        MULTY_SELECTION_COLOUM_5_DATA = dgw.SelectedCells(4).Value.ToString()
        If GetListNoOfColumn = 4 Then
            MULTY_SELECTION_COLOUM_6_DATA = dgw.SelectedCells(5).Value.ToString()
            MULTY_SELECTION_COLOUM_7_DATA = dgw.SelectedCells(6).Value.ToString()
        End If
    End Sub


    Private Sub dgw_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseWheel
        Dim currentIndex As Integer = Me.dgw.FirstDisplayedScrollingRowIndex
        Dim scrollLines As Integer = SystemInformation.MouseWheelScrollLines

        Select Case e.Delta
            Case (120)
                Me.dgw.FirstDisplayedScrollingRowIndex = Math.Max(0, currentIndex - scrollLines)
            Case (-120)
                Me.dgw.FirstDisplayedScrollingRowIndex = currentIndex + scrollLines
        End Select
    End Sub
    Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs) Handles dgw.KeyDown
        If e.KeyCode = Keys.Down Then

        ElseIf e.KeyCode = 37 Then ' Left Arrow

        ElseIf e.KeyCode = 39 Then 'Right Arrow

        ElseIf e.KeyCode = Keys.Up Then
        ElseIf e.KeyCode = Keys.Home Then
            If ((dgw.Rows.Count > 0) AndAlso Created) Then
                Dim _row As Int32 = dgw.Rows.Count
                dgw(0, (dgw.Rows.Count - _row)).Selected = True
                dgw.FirstDisplayedScrollingRowIndex = dgw.SelectedRows(0).Index
            End If

        ElseIf e.KeyCode = Keys.End Then
            If ((dgw.Rows.Count > 0) AndAlso Created) Then
                dgw(0, (dgw.Rows.Count - 1)).Selected = True
                dgw.FirstDisplayedScrollingRowIndex = dgw.SelectedRows(0).Index
            End If

        ElseIf e.KeyCode = Keys.PageUp Then
        ElseIf e.KeyCode = Keys.PageDown Then
        ElseIf e.KeyCode = Keys.Enter Then

            If GridSelect = "NEW SELECTION" Then
                If GridViewType = "SINGLE" Then
                    If e.KeyCode = Keys.Enter Then
                        Dim rowHandle = dgw.CurrentRow.Index
                        If rowHandle >= 0 Then
                            _GridDataSelection(rowHandle)
                        End If
                    End If
                Else

                    If e.KeyCode = Keys.Enter Then
                        Dim dgv As DataGridView = CType(sender, DataGridView)

                        If dgv.CurrentRow IsNot Nothing Then
                            Dim rowIndex As Integer = dgv.CurrentRow.Index
                            Dim tickValue As String = If(dgv.Rows(rowIndex).Cells("TickMark").Value, "").ToString()

                            If tickValue = "" Then
                                dgv.Rows(rowIndex).Cells("TickMark").Value = "True"
                            ElseIf tickValue = "True" Then
                                dgv.Rows(rowIndex).Cells("TickMark").Value = "False"
                            ElseIf tickValue = "False" Then
                                dgv.Rows(rowIndex).Cells("TickMark").Value = "True"
                            End If

                            ' Move to next row programmatically
                            Dim nextRowIndex As Integer = rowIndex + 1
                            If nextRowIndex < dgv.Rows.Count Then
                                dgv.CurrentCell = dgv.Rows(nextRowIndex).Cells(0) ' Focus first column of next row
                            End If
                        End If

                        e.Handled = True
                        e.SuppressKeyPress = True

                    ElseIf e.KeyCode = Keys.F11 Then
                        _SelectAlldata()

                    ElseIf e.KeyCode = Keys.F12 Then
                        _LoadSelectedData()
                    End If
                End If
            Else
                _CheckWhtaspOkNo = True
                Call listedit()
                Me.Close()
                Me.Dispose(True)
                Exit Sub
            End If
        Else

            txtSearch.Focus()
            txtSearch.SelectAll()
        End If
    End Sub
    Private Sub _LoadSelectedData()
        _GridDataSelection(0)
    End Sub
    Private Sub _SelectAlldata()

        For i As Integer = 0 To dgw.Rows.Count - 1
            If Not dgw.Rows(i).IsNewRow Then
                Dim tickValue As String = If(dgw.Rows(i).Cells("TickMark").Value, "").ToString()

                If tickValue = "True" Then
                    dgw.Rows(i).Cells("TickMark").Value = "False"
                Else
                    dgw.Rows(i).Cells("TickMark").Value = "True"
                End If
            End If
        Next

    End Sub

    Private Sub _GridDataSelection(ByVal rowIndex As Integer)

        If GridViewType = "SINGLE" Then
            SelectedRowValues.Clear()

            ' Loop through all columns of DataGridView
            For Each col As DataGridViewColumn In dgw.Columns
                Dim colName As String = col.Name
                Dim value As Object = dgw.Rows(rowIndex).Cells(colName).Value
                SelectedRowValues(colName) = If(value IsNot Nothing, value, "")
            Next

        Else ' MULTI
            SelectedRowValuesList.Clear()

            For i As Integer = 0 To dgw.Rows.Count - 1
                Dim isTicked As Boolean = False

                If dgw.Rows(i).Cells("TickMark").Value IsNot Nothing AndAlso
               dgw.Rows(i).Cells("TickMark").Value.ToString() <> "" Then
                    isTicked = Convert.ToBoolean(dgw.Rows(i).Cells("TickMark").Value)
                End If

                If isTicked Then
                    Dim rowDict As New Dictionary(Of String, Object)

                    For Each col As DataGridViewColumn In dgw.Columns
                        Dim colName As String = col.Name
                        Dim value As Object = dgw.Rows(i).Cells(colName).Value
                        rowDict(colName) = If(value IsNot Nothing, value, "")
                    Next

                    SelectedRowValuesList.Add(rowDict)
                End If
            Next

        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


    Private Sub dgw_RowHeightChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgw.RowHeightChanged
        dgw.RowTemplate.Height = 30
    End Sub
    Private Sub dgw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgw.KeyPress
        If e.KeyChar = Chr(27) Then
            txtSearch.Focus()
            txtSearch.SelectAll()
            Exit Sub
        ElseIf e.KeyChar = Chr(8) Then
            txtSearch.Focus()
            txtSearch.SelectAll()
            Exit Sub
        ElseIf e.KeyChar = Chr(13) Then

        Else
            txtSearch.Text = txtSearch.Text + e.KeyChar
            txtSearch.SelectionStart = txtSearch.TextLength
            'Dim R As Integer = dgw.FirstDisplayedScrollingRowIndex
            'If dgw.Rows(R).Selected = False Then
            '    TextBox1.SelectAll()
            'End If
        End If
    End Sub
    Private Sub dgw_KeyUp(sender As Object, e As KeyEventArgs) Handles dgw.KeyUp
        If e.KeyCode = Keys.Enter Then
            _GetGridData()
            'Label2.Text = dgw.SelectedCells(0).Value.ToString()
            'Label3.Text = dgw.SelectedCells(2).Value.ToString()
            'Label6.Text = dgw.SelectedCells(1).Value.ToString()
            'Label7.Text = dgw.SelectedCells(3).Value.ToString()
            'MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(0).Value.ToString()
            'MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(1).Value.ToString()
            'MULTY_SELECTION_COLOUM_3_DATA = dgw.SelectedCells(2).Value.ToString()
            'MULTY_SELECTION_COLOUM_4_DATA = dgw.SelectedCells(3).Value.ToString()
            'MULTY_SELECTION_COLOUM_5_DATA = dgw.SelectedCells(4).Value.ToString()

            _CheckWhtaspOkNo = True
            e.SuppressKeyPress = True
        Else
            _GetGridData()
            'Label2.Text = dgw.SelectedCells(0).Value.ToString()
            'Label3.Text = dgw.SelectedCells(2).Value.ToString()
            'Label6.Text = dgw.SelectedCells(1).Value.ToString()
            'Label7.Text = dgw.SelectedCells(3).Value.ToString()
            'MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(0).Value.ToString()
            'MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(1).Value.ToString()
            'MULTY_SELECTION_COLOUM_3_DATA = dgw.SelectedCells(2).Value.ToString()
            'MULTY_SELECTION_COLOUM_4_DATA = dgw.SelectedCells(3).Value.ToString()
            'MULTY_SELECTION_COLOUM_5_DATA = dgw.SelectedCells(4).Value.ToString()
        End If

    End Sub
    Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs) Handles dgw.MouseClick
        _GetGridData()
        'Label2.Text = dgw.SelectedCells(0).Value.ToString()
        'Label3.Text = dgw.SelectedCells(2).Value.ToString()
        'Label6.Text = dgw.SelectedCells(1).Value.ToString()
        'Label7.Text = dgw.SelectedCells(3).Value.ToString()
        'MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(0).Value.ToString()
        'MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(1).Value.ToString()
        'MULTY_SELECTION_COLOUM_3_DATA = dgw.SelectedCells(2).Value.ToString()
        'MULTY_SELECTION_COLOUM_4_DATA = dgw.SelectedCells(3).Value.ToString()
        'MULTY_SELECTION_COLOUM_5_DATA = dgw.SelectedCells(4).Value.ToString()
    End Sub
#End Region

    Private Sub Master_open()

        If Label4.Text = "Master_frm" Then
            _NewMasterCreatForm = True
            F2_OPEN_FROM = True
            Me.Close()
            Me.Dispose(True)
            Master_frm.Owner = Main_MDI_Frm
            Master_frm.StartPosition = FormStartPosition.CenterParent
            Master_frm.ShowDialog(Me.Owner)
            Exit Sub
        End If
        'If Label4.Text = "Agent_master" Then
        '    _NewMasterCreatForm = True
        '    F2_OPEN_FROM = True
        '    Me.Close()
        '    Me.Dispose(True)

        '    Agent_master.Owner = Main_MDI_Frm
        '    Agent_master.StartPosition = FormStartPosition.CenterParent
        '    Agent_master.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Ac_master_info_frm" Then
        '    _NewMasterCreatForm = True
        '    Ac_master_info_frm.Label201.Text = Label1.Text
        '    Ac_master_info_frm.Label202.Text = Label4.Text
        '    Ac_master_info_frm.Label203.Text = Label8.Text
        '    Ac_master_info_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Ac_master_info_frm.Owner = Main_MDI_Frm
        '    Ac_master_info_frm.StartPosition = FormStartPosition.CenterParent
        '    Ac_master_info_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "City_master_frm" Then
        '    _NewMasterCreatForm = True
        '    City_master_frm.Label201.Text = Label1.Text
        '    City_master_frm.Label202.Text = Label4.Text
        '    City_master_frm.Label203.Text = Label8.Text
        '    City_master_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    City_master_frm.Owner = Main_MDI_Frm
        '    City_master_frm.StartPosition = FormStartPosition.CenterParent
        '    City_master_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "State_master_frm" Then
        '    _NewMasterCreatForm = True
        '    State_master_frm.Label201.Text = Label1.Text
        '    State_master_frm.Label202.Text = Label4.Text
        '    State_master_frm.Label203.Text = Label8.Text
        '    State_master_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    State_master_frm.Owner = Main_MDI_Frm
        '    State_master_frm.StartPosition = FormStartPosition.CenterParent
        '    State_master_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Transport_info_frm" Then
        '    _NewMasterCreatForm = True

        '    Transport_info_frm.Label201.Text = Label1.Text
        '    Transport_info_frm.Label202.Text = Label4.Text
        '    Transport_info_frm.Label203.Text = Label8.Text
        '    Transport_info_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Transport_info_frm.Owner = Main_MDI_Frm
        '    Transport_info_frm.StartPosition = FormStartPosition.CenterParent
        '    Transport_info_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Cut_master_frm" Then
        '    _NewMasterCreatForm = True
        '    Cut_master_frm.Label201.Text = Label1.Text
        '    Cut_master_frm.Label202.Text = Label4.Text
        '    Cut_master_frm.Label203.Text = Label8.Text
        '    Cut_master_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Cut_master_frm.Owner = Main_MDI_Frm
        '    Cut_master_frm.StartPosition = FormStartPosition.CenterParent
        '    Cut_master_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If


        'If Label4.Text = "Fabric_design" Then
        '    _NewMasterCreatForm = True
        '    Fabric_design.Label201.Text = Label1.Text
        '    Fabric_design.Label202.Text = Label4.Text
        '    Fabric_design.Label203.Text = Label8.Text
        '    Fabric_design.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_design.Owner = Main_MDI_Frm
        '    Fabric_design.StartPosition = FormStartPosition.CenterParent
        '    Fabric_design.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Fabric_Group" Then
        '    _NewMasterCreatForm = True
        '    Fabric_Group.Label201.Text = Label1.Text
        '    Fabric_Group.Label202.Text = Label4.Text
        '    Fabric_Group.Label203.Text = Label8.Text
        '    Fabric_Group.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_Group.Owner = Main_MDI_Frm
        '    Fabric_Group.StartPosition = FormStartPosition.CenterParent
        '    Fabric_Group.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Fabric_Head" Then
        '    _NewMasterCreatForm = True
        '    Fabric_Head.Label201.Text = Label1.Text
        '    Fabric_Head.Label202.Text = Label4.Text
        '    Fabric_Head.Label203.Text = Label8.Text
        '    Fabric_Head.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_Head.Owner = Main_MDI_Frm
        '    Fabric_Head.StartPosition = FormStartPosition.CenterParent
        '    Fabric_Head.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Fabric_Item_Category" Then
        '    _NewMasterCreatForm = True
        '    Fabric_Item_Category.Label201.Text = Label1.Text
        '    Fabric_Item_Category.Label202.Text = Label4.Text
        '    Fabric_Item_Category.Label203.Text = Label8.Text
        '    Fabric_Item_Category.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_Item_Category.Owner = Main_MDI_Frm
        '    Fabric_Item_Category.StartPosition = FormStartPosition.CenterParent
        '    Fabric_Item_Category.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Fabric_Item_Master_Frm" Then
        '    _NewMasterCreatForm = True
        '    Fabric_Item_Master_Frm.Label201.Text = Label1.Text
        '    Fabric_Item_Master_Frm.Label202.Text = Label4.Text
        '    Fabric_Item_Master_Frm.Label203.Text = Label8.Text
        '    Fabric_Item_Master_Frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_Item_Master_Frm.Owner = Main_MDI_Frm
        '    Fabric_Item_Master_Frm.StartPosition = FormStartPosition.CenterParent
        '    Fabric_Item_Master_Frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Fabric_shade" Then
        '    _NewMasterCreatForm = True
        '    Fabric_shade.Label201.Text = Label1.Text
        '    Fabric_shade.Label202.Text = Label4.Text
        '    Fabric_shade.Label203.Text = Label8.Text
        '    Fabric_shade.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_shade.Owner = Main_MDI_Frm
        '    Fabric_shade.StartPosition = FormStartPosition.CenterParent
        '    Fabric_shade.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Selvedge" Then
        '    _NewMasterCreatForm = True
        '    Selvedge.Label201.Text = Label1.Text
        '    Selvedge.Label202.Text = Label4.Text
        '    Selvedge.Label203.Text = Label8.Text
        '    Selvedge.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Selvedge.Owner = Main_MDI_Frm
        '    Selvedge.StartPosition = FormStartPosition.CenterParent
        '    Selvedge.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Insurance_company_frm" Then
        '    _NewMasterCreatForm = True
        '    Insurance_company_frm.Label201.Text = Label1.Text
        '    Insurance_company_frm.Label202.Text = Label4.Text
        '    Insurance_company_frm.Label203.Text = Label8.Text
        '    Insurance_company_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Insurance_company_frm.Owner = Main_MDI_Frm
        '    Insurance_company_frm.StartPosition = FormStartPosition.CenterParent
        '    Insurance_company_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Group_frm" Then
        '    _NewMasterCreatForm = True
        '    Group_frm.Label201.Text = Label1.Text
        '    Group_frm.Label202.Text = Label4.Text
        '    Group_frm.Label203.Text = Label8.Text
        '    Group_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Group_frm.Owner = Main_MDI_Frm
        '    Group_frm.StartPosition = FormStartPosition.CenterParent
        '    Group_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Master_frm" Then
        '    _NewMasterCreatForm = True
        '    Master_frm.Label201.Text = Label1.Text
        '    Master_frm.Label202.Text = Label4.Text
        '    Master_frm.Label203.Text = Label8.Text
        '    Master_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Master_frm.Owner = Main_MDI_Frm
        '    Master_frm.StartPosition = FormStartPosition.CenterParent
        '    Master_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Schedule_frm" Then
        '    _NewMasterCreatForm = True
        '    Schedule_frm.Label201.Text = Label1.Text
        '    Schedule_frm.Label202.Text = Label4.Text
        '    Schedule_frm.Label203.Text = Label8.Text
        '    Schedule_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Schedule_frm.Owner = Main_MDI_Frm
        '    Schedule_frm.StartPosition = FormStartPosition.CenterParent
        '    Schedule_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Store_Item" Then

        '    Store_Item.Label201.Text = Label1.Text
        '    Store_Item.Label202.Text = Label4.Text
        '    Store_Item.Label203.Text = Label8.Text
        '    Store_Item.Label204.Text = ""
        '    _NewMasterCreatForm = True
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_Item.Owner = Main_MDI_Frm
        '    Store_Item.StartPosition = FormStartPosition.CenterParent
        '    Store_Item.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Store_Item_Category" Then
        '    _NewMasterCreatForm = True
        '    Store_Item_Category.Label201.Text = Label1.Text
        '    Store_Item_Category.Label202.Text = Label4.Text
        '    Store_Item_Category.Label203.Text = Label8.Text
        '    Store_Item_Category.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_Item_Category.Owner = Main_MDI_Frm
        '    Store_Item_Category.StartPosition = FormStartPosition.CenterParent
        '    Store_Item_Category.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If
        'If Label4.Text = "Store_Item_Type" Then
        '    _NewMasterCreatForm = True
        '    Store_Item_Type.Label201.Text = Label1.Text
        '    Store_Item_Type.Label202.Text = Label4.Text
        '    Store_Item_Type.Label203.Text = Label8.Text
        '    Store_Item_Type.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_Item_Type.Owner = Main_MDI_Frm
        '    Store_Item_Type.StartPosition = FormStartPosition.CenterParent
        '    Store_Item_Type.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Yarn_Item_Master_Frm" Then
        '    _NewMasterCreatForm = True
        '    Yarn_Item_Master_Frm.Label201.Text = Label1.Text
        '    Yarn_Item_Master_Frm.Label202.Text = Label4.Text
        '    Yarn_Item_Master_Frm.Label203.Text = Label8.Text
        '    Yarn_Item_Master_Frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Yarn_Item_Master_Frm.Owner = Main_MDI_Frm
        '    Yarn_Item_Master_Frm.StartPosition = FormStartPosition.CenterParent
        '    Yarn_Item_Master_Frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Yarn_Item_shade" Then
        '    _NewMasterCreatForm = True
        '    Yarn_Item_shade.Label201.Text = Label1.Text
        '    Yarn_Item_shade.Label202.Text = Label4.Text
        '    Yarn_Item_shade.Label203.Text = Label8.Text
        '    Yarn_Item_shade.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Yarn_Item_shade.Owner = Main_MDI_Frm
        '    Yarn_Item_shade.StartPosition = FormStartPosition.CenterParent
        '    Yarn_Item_shade.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "narration_frm" Then
        '    _NewMasterCreatForm = True
        '    narration_frm.Label201.Text = Label1.Text
        '    narration_frm.Label202.Text = Label4.Text
        '    narration_frm.Label203.Text = Label8.Text
        '    narration_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    narration_frm.Owner = Main_MDI_Frm
        '    narration_frm.StartPosition = FormStartPosition.CenterParent
        '    narration_frm.ShowDialog(Me.Owner)
        '    Exit Sub
        'End If

        'If Label4.Text = "Remaek_frm" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Remaek_frm.Owner = Main_MDI_Frm
        '    Remaek_frm.StartPosition = FormStartPosition.CenterParent
        '    Remaek_frm.ShowDialog(Me.Owner)
        '    Exit Sub

        'ElseIf Label4.Text = "Loom_Type" Then
        '    _NewMasterCreatForm = True
        '    Loom_Type.Label201.Text = Label1.Text
        '    Loom_Type.Label202.Text = Label4.Text
        '    Loom_Type.Label203.Text = Label8.Text
        '    Loom_Type.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    LEDGER_ENTER_DISPLAY_FROM = "Loom_Type"
        '    Loom_Type.Owner = Main_MDI_Frm
        '    Loom_Type.StartPosition = FormStartPosition.CenterParent
        '    Loom_Type.ShowDialog(Me.Owner)
        '    Exit Sub
        'ElseIf Label4.Text = "Loom_no_info" Then
        '    _NewMasterCreatForm = True
        '    Loom_no_info.Label201.Text = Label1.Text
        '    Loom_no_info.Label202.Text = Label4.Text
        '    Loom_no_info.Label203.Text = Label8.Text
        '    Loom_no_info.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Loom_no_info"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Loom_no_info.Owner = Main_MDI_Frm
        '    Loom_no_info.StartPosition = FormStartPosition.CenterParent
        '    Loom_no_info.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Weaver_Master" Then
        '    _NewMasterCreatForm = True
        '    Weaver_Master.Label201.Text = Label1.Text
        '    Weaver_Master.Label202.Text = Label4.Text
        '    Weaver_Master.Label203.Text = Label8.Text
        '    Weaver_Master.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Weaver_Master"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Weaver_Master.Owner = Main_MDI_Frm
        '    Weaver_Master.StartPosition = FormStartPosition.CenterParent
        '    Weaver_Master.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Frm_SizeMaster" Then
        '    _NewMasterCreatForm = True
        '    Frm_SizeMaster.Label201.Text = Label1.Text
        '    Frm_SizeMaster.Label202.Text = Label4.Text
        '    Frm_SizeMaster.Label203.Text = Label8.Text
        '    Frm_SizeMaster.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Frm_SizeMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_SizeMaster.Owner = Main_MDI_Frm
        '    Frm_SizeMaster.StartPosition = FormStartPosition.CenterParent
        '    Frm_SizeMaster.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Frm_Color" Then
        '    _NewMasterCreatForm = True
        '    Frm_Color.Label201.Text = Label1.Text
        '    Frm_Color.Label202.Text = Label4.Text
        '    Frm_Color.Label203.Text = Label8.Text
        '    Frm_Color.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Frm_Color"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_Color.Owner = Main_MDI_Frm
        '    Frm_Color.StartPosition = FormStartPosition.CenterParent
        '    Frm_Color.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Frm_Grader" Then
        '    _NewMasterCreatForm = True
        '    Frm_Grader.Label201.Text = Label1.Text
        '    Frm_Grader.Label202.Text = Label4.Text
        '    Frm_Grader.Label203.Text = Label8.Text
        '    Frm_Grader.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Frm_Color"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_Grader.Owner = Main_MDI_Frm
        '    Frm_Grader.StartPosition = FormStartPosition.CenterParent
        '    Frm_Grader.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "SalesManAccountMaster" Then
        '    _NewMasterCreatForm = True
        '    SalesManAccountMaster.Label201.Text = Label1.Text
        '    SalesManAccountMaster.Label202.Text = Label4.Text
        '    SalesManAccountMaster.Label203.Text = Label8.Text
        '    SalesManAccountMaster.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "SalesManAccountMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    SalesManAccountMaster.Owner = Main_MDI_Frm
        '    SalesManAccountMaster.StartPosition = FormStartPosition.CenterParent
        '    SalesManAccountMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Remaek_frm" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "Remaek_frm"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Remaek_frm.Owner = Main_MDI_Frm
        '    Remaek_frm.StartPosition = FormStartPosition.CenterParent
        '    Remaek_frm.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "MillShade" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "MillShade"
        '    Me.Close()
        '    Me.Dispose(True)
        '    MillShade.Owner = Main_MDI_Frm
        '    MillShade.StartPosition = FormStartPosition.CenterParent
        '    MillShade.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "StoreDepartment" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "StoreDepartment"
        '    Me.Close()
        '    Me.Dispose(True)
        '    StoreDepartment.Owner = Main_MDI_Frm
        '    StoreDepartment.StartPosition = FormStartPosition.CenterParent
        '    StoreDepartment.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Frm_AccountMaster" Then
        '    _NewMasterCreatForm = True
        '    Frm_AccountMaster.Label201.Text = Label1.Text
        '    Frm_AccountMaster.Label202.Text = Label4.Text
        '    Frm_AccountMaster.Label203.Text = Label8.Text
        '    Frm_AccountMaster.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "Frm_AccountMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_AccountMaster.Owner = Main_MDI_Frm
        '    Frm_AccountMaster.StartPosition = FormStartPosition.CenterParent
        '    Frm_AccountMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "BankBranchName" Then
        '    _NewMasterCreatForm = True
        '    BankBranchName.Label201.Text = Label1.Text
        '    BankBranchName.Label202.Text = Label4.Text
        '    BankBranchName.Label203.Text = Label8.Text
        '    BankBranchName.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "BankBranchName"
        '    Me.Close()
        '    Me.Dispose(True)
        '    BankBranchName.Owner = Main_MDI_Frm
        '    BankBranchName.StartPosition = FormStartPosition.CenterParent
        '    BankBranchName.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Store_Item_Category" Then
        '    _NewMasterCreatForm = True
        '    Store_Item_Category.Label201.Text = Label1.Text
        '    Store_Item_Category.Label202.Text = Label4.Text
        '    Store_Item_Category.Label203.Text = Label8.Text
        '    Store_Item_Category.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Store_Item_Category"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_Item_Category.Owner = Main_MDI_Frm
        '    Store_Item_Category.StartPosition = FormStartPosition.CenterParent
        '    Store_Item_Category.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Store_SubItem" Then
        '    _NewMasterCreatForm = True
        '    Store_SubItem.Label201.Text = Label1.Text
        '    Store_SubItem.Label202.Text = Label4.Text
        '    Store_SubItem.Label203.Text = Label8.Text
        '    Store_SubItem.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Store_SubItem"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_SubItem.Owner = Main_MDI_Frm
        '    Store_SubItem.StartPosition = FormStartPosition.CenterParent
        '    Store_SubItem.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "YarnTypeMaster" Then
        '    _NewMasterCreatForm = True
        '    YarnTypeMaster.Label201.Text = Label1.Text
        '    YarnTypeMaster.Label202.Text = Label4.Text
        '    YarnTypeMaster.Label203.Text = Label8.Text
        '    YarnTypeMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "MstYarnType"
        '    Me.Close()
        '    Me.Dispose(True)
        '    YarnTypeMaster.Owner = Main_MDI_Frm
        '    YarnTypeMaster.StartPosition = FormStartPosition.CenterParent
        '    YarnTypeMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "GodownMaster" Then
        '    _NewMasterCreatForm = True
        '    GodownMaster.Label201.Text = Label1.Text
        '    GodownMaster.Label202.Text = Label4.Text
        '    GodownMaster.Label203.Text = Label8.Text
        '    GodownMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "GodownMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    GodownMaster.Owner = Main_MDI_Frm
        '    GodownMaster.StartPosition = FormStartPosition.CenterParent
        '    GodownMaster.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "BeamPipeNoMaster" Then
        '    _NewMasterCreatForm = True
        '    BeamPipeNoMaster.Label201.Text = Label1.Text
        '    BeamPipeNoMaster.Label202.Text = Label4.Text
        '    BeamPipeNoMaster.Label203.Text = Label8.Text
        '    BeamPipeNoMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "BeamPipeNoMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    BeamPipeNoMaster.Owner = Main_MDI_Frm
        '    BeamPipeNoMaster.StartPosition = FormStartPosition.CenterParent
        '    BeamPipeNoMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "RackMaster" Then
        '    _NewMasterCreatForm = True
        '    RackMaster.Label201.Text = Label1.Text
        '    RackMaster.Label202.Text = Label4.Text
        '    RackMaster.Label203.Text = Label8.Text
        '    RackMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "RackMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    RackMaster.Owner = Main_MDI_Frm
        '    RackMaster.StartPosition = FormStartPosition.CenterParent
        '    RackMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Employee" Then
        '    _NewMasterCreatForm = True
        '    Employee.Label201.Text = Label1.Text
        '    Employee.Label202.Text = Label4.Text
        '    Employee.Label203.Text = Label8.Text
        '    Employee.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Employee"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Employee.Owner = Main_MDI_Frm
        '    Employee.StartPosition = FormStartPosition.CenterParent
        '    Employee.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Fabric_Group" Then
        '    _NewMasterCreatForm = True
        '    Fabric_Group.Label201.Text = Label1.Text
        '    Fabric_Group.Label202.Text = Label4.Text
        '    Fabric_Group.Label203.Text = Label8.Text
        '    Fabric_Group.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Fabric_Group"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Fabric_Group.Owner = Main_MDI_Frm
        '    Fabric_Group.StartPosition = FormStartPosition.CenterParent
        '    Fabric_Group.ShowDialog(Me.Owner)
        'End If

        'If Label4.Text = "Remaek_frm" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    Remaek_frm.Owner = Main_MDI_Frm
        '    Remaek_frm.StartPosition = FormStartPosition.CenterParent
        '    Remaek_frm.ShowDialog(Me.Owner)
        '    Exit Sub

        'ElseIf Label4.Text = "Loom_Type" Then
        '    _NewMasterCreatForm = True
        '    Loom_Type.Label201.Text = Label1.Text
        '    Loom_Type.Label202.Text = Label4.Text
        '    Loom_Type.Label203.Text = Label8.Text
        '    Loom_Type.Label204.Text = ""
        '    Me.Close()
        '    Me.Dispose(True)
        '    LEDGER_ENTER_DISPLAY_FROM = "Loom_Type"
        '    Loom_Type.Owner = Main_MDI_Frm
        '    Loom_Type.StartPosition = FormStartPosition.CenterParent
        '    Loom_Type.ShowDialog(Me.Owner)
        '    Exit Sub
        'ElseIf Label4.Text = "Loom_no_info" Then
        '    _NewMasterCreatForm = True
        '    Loom_no_info.Label201.Text = Label1.Text
        '    Loom_no_info.Label202.Text = Label4.Text
        '    Loom_no_info.Label203.Text = Label8.Text
        '    Loom_no_info.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Loom_no_info"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Loom_no_info.Owner = Main_MDI_Frm
        '    Loom_no_info.StartPosition = FormStartPosition.CenterParent
        '    Loom_no_info.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Weaver_Master" Then
        '    _NewMasterCreatForm = True
        '    Weaver_Master.Label201.Text = Label1.Text
        '    Weaver_Master.Label202.Text = Label4.Text
        '    Weaver_Master.Label203.Text = Label8.Text
        '    Weaver_Master.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Weaver_Master"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Weaver_Master.Owner = Main_MDI_Frm
        '    Weaver_Master.StartPosition = FormStartPosition.CenterParent
        '    Weaver_Master.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Frm_SizeMaster" Then
        '    _NewMasterCreatForm = True
        '    Frm_SizeMaster.Label201.Text = Label1.Text
        '    Frm_SizeMaster.Label202.Text = Label4.Text
        '    Frm_SizeMaster.Label203.Text = Label8.Text
        '    Frm_SizeMaster.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Frm_SizeMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_SizeMaster.Owner = Main_MDI_Frm
        '    Frm_SizeMaster.StartPosition = FormStartPosition.CenterParent
        '    Frm_SizeMaster.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Frm_Color" Then
        '    _NewMasterCreatForm = True
        '    Frm_Color.Label201.Text = Label1.Text
        '    Frm_Color.Label202.Text = Label4.Text
        '    Frm_Color.Label203.Text = Label8.Text
        '    Frm_Color.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Frm_Color"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_Color.Owner = Main_MDI_Frm
        '    Frm_Color.StartPosition = FormStartPosition.CenterParent
        '    Frm_Color.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Frm_Grader" Then
        '    _NewMasterCreatForm = True
        '    Frm_Grader.Label201.Text = Label1.Text
        '    Frm_Grader.Label202.Text = Label4.Text
        '    Frm_Grader.Label203.Text = Label8.Text
        '    Frm_Grader.Label204.Text = ""
        '    'LEDGER_ENTER_DISPLAY_FROM = "Frm_Color"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_Grader.Owner = Main_MDI_Frm
        '    Frm_Grader.StartPosition = FormStartPosition.CenterParent
        '    Frm_Grader.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "SalesManAccountMaster" Then
        '    _NewMasterCreatForm = True
        '    SalesManAccountMaster.Label201.Text = Label1.Text
        '    SalesManAccountMaster.Label202.Text = Label4.Text
        '    SalesManAccountMaster.Label203.Text = Label8.Text
        '    SalesManAccountMaster.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "SalesManAccountMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    SalesManAccountMaster.Owner = Main_MDI_Frm
        '    SalesManAccountMaster.StartPosition = FormStartPosition.CenterParent
        '    SalesManAccountMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Remaek_frm" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "Remaek_frm"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Remaek_frm.Owner = Main_MDI_Frm
        '    Remaek_frm.StartPosition = FormStartPosition.CenterParent
        '    Remaek_frm.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "MillShade" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "MillShade"
        '    Me.Close()
        '    Me.Dispose(True)
        '    MillShade.Owner = Main_MDI_Frm
        '    MillShade.StartPosition = FormStartPosition.CenterParent
        '    MillShade.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "StoreDepartment" Then
        '    _NewMasterCreatForm = True
        '    Remaek_frm.Label201.Text = Label1.Text
        '    Remaek_frm.Label202.Text = Label4.Text
        '    Remaek_frm.Label203.Text = Label8.Text
        '    Remaek_frm.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "StoreDepartment"
        '    Me.Close()
        '    Me.Dispose(True)
        '    StoreDepartment.Owner = Main_MDI_Frm
        '    StoreDepartment.StartPosition = FormStartPosition.CenterParent
        '    StoreDepartment.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Frm_AccountMaster" Then
        '    _NewMasterCreatForm = True
        '    Frm_AccountMaster.Label201.Text = Label1.Text
        '    Frm_AccountMaster.Label202.Text = Label4.Text
        '    Frm_AccountMaster.Label203.Text = Label8.Text
        '    Frm_AccountMaster.Label204.Text = ""
        '    LEDGER_FORM_DISPALY_BY = "Frm_AccountMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Frm_AccountMaster.Owner = Main_MDI_Frm
        '    Frm_AccountMaster.StartPosition = FormStartPosition.CenterParent
        '    Frm_AccountMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "BankBranchName" Then
        '    _NewMasterCreatForm = True
        '    BankBranchName.Label201.Text = Label1.Text
        '    BankBranchName.Label202.Text = Label4.Text
        '    BankBranchName.Label203.Text = Label8.Text
        '    BankBranchName.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "BankBranchName"
        '    Me.Close()
        '    Me.Dispose(True)
        '    BankBranchName.Owner = Main_MDI_Frm
        '    BankBranchName.StartPosition = FormStartPosition.CenterParent
        '    BankBranchName.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Store_Item_Category" Then
        '    _NewMasterCreatForm = True
        '    Store_Item_Category.Label201.Text = Label1.Text
        '    Store_Item_Category.Label202.Text = Label4.Text
        '    Store_Item_Category.Label203.Text = Label8.Text
        '    Store_Item_Category.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Store_Item_Category"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_Item_Category.Owner = Main_MDI_Frm
        '    Store_Item_Category.StartPosition = FormStartPosition.CenterParent
        '    Store_Item_Category.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Store_SubItem" Then
        '    _NewMasterCreatForm = True
        '    Store_SubItem.Label201.Text = Label1.Text
        '    Store_SubItem.Label202.Text = Label4.Text
        '    Store_SubItem.Label203.Text = Label8.Text
        '    Store_SubItem.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Store_SubItem"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Store_SubItem.Owner = Main_MDI_Frm
        '    Store_SubItem.StartPosition = FormStartPosition.CenterParent
        '    Store_SubItem.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "GodownMaster" Then
        '    _NewMasterCreatForm = True
        '    GodownMaster.Label201.Text = Label1.Text
        '    GodownMaster.Label202.Text = Label4.Text
        '    GodownMaster.Label203.Text = Label8.Text
        '    GodownMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "GodownMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    GodownMaster.Owner = Main_MDI_Frm
        '    GodownMaster.StartPosition = FormStartPosition.CenterParent
        '    GodownMaster.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "BeamPipeNoMaster" Then
        '    _NewMasterCreatForm = True
        '    BeamPipeNoMaster.Label201.Text = Label1.Text
        '    BeamPipeNoMaster.Label202.Text = Label4.Text
        '    BeamPipeNoMaster.Label203.Text = Label8.Text
        '    BeamPipeNoMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "BeamPipeNoMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    BeamPipeNoMaster.Owner = Main_MDI_Frm
        '    BeamPipeNoMaster.StartPosition = FormStartPosition.CenterParent
        '    BeamPipeNoMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "RackMaster" Then
        '    _NewMasterCreatForm = True
        '    RackMaster.Label201.Text = Label1.Text
        '    RackMaster.Label202.Text = Label4.Text
        '    RackMaster.Label203.Text = Label8.Text
        '    RackMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "RackMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    RackMaster.Owner = Main_MDI_Frm
        '    RackMaster.StartPosition = FormStartPosition.CenterParent
        '    RackMaster.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "Employee" Then
        '    _NewMasterCreatForm = True
        '    Employee.Label201.Text = Label1.Text
        '    Employee.Label202.Text = Label4.Text
        '    Employee.Label203.Text = Label8.Text
        '    Employee.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "Employee"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Employee.Owner = Main_MDI_Frm
        '    Employee.StartPosition = FormStartPosition.CenterParent
        '    Employee.ShowDialog(Me.Owner)

        'ElseIf Label4.Text = "UnitMaster" Then
        '    _NewMasterCreatForm = True
        '    UnitMaster.Label201.Text = Label1.Text
        '    UnitMaster.Label202.Text = Label4.Text
        '    UnitMaster.Label203.Text = Label8.Text
        '    UnitMaster.Label204.Text = ""
        '    LEDGER_ENTER_DISPLAY_FROM = "UnitMaster"
        '    Me.Close()
        '    Me.Dispose(True)
        '    UnitMaster.Owner = Main_MDI_Frm
        '    UnitMaster.StartPosition = FormStartPosition.CenterParent
        '    UnitMaster.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "Post" Then
        '    _NewMasterCreatForm = True
        '    LEDGER_ENTER_DISPLAY_FROM = "_CallOther"
        '    Me.Close()
        '    Me.Dispose(True)
        '    Post.Owner = Main_MDI_Frm
        '    Post.StartPosition = FormStartPosition.CenterParent
        '    Post.ShowDialog(Me.Owner)
        'ElseIf Label4.Text = "NewQualityPlanEntry" Then
        '_NewMasterCreatForm = True
        '    LEDGER_ENTER_DISPLAY_FROM = "_CallOther"
        '    Me.Close()
        '    Me.Dispose(True)
        '    NewQualityPlanEntry.Owner = Main_MDI_Frm
        '    NewQualityPlanEntry.StartPosition = FormStartPosition.CenterParent
        '    NewQualityPlanEntry.ShowDialog(Me.Owner)


        'End If

    End Sub

    Private Sub listedit()
        Try

#Region "book master "
            'sundry_selection---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Sundry_frm" Then
                sundry_selection()
            End If

            'book master---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Book_Master" Then
                bk_master_selection()
            End If

            ' DEFINE bill sundary---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Define_bill_sundry" Then
                bill_sundary_define()
            End If
            ' ORDER BOOK MASTER---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Order_Book_Master" Then
                ORDER_BOOK_MASTER_SELECTION()
            End If

            'PACKING BOOK MASTER---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Packing_Slip_Book_Master" Then
                PACKING_SLIP_MASTER_SELECTION()
            End If

            'GREY CHALLAN MASTER---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Grey_Challan_Book_Master" Then
                GREY_CHALLAN_MASTER_SELECTION()
            End If

            'PROCESS CHALLAN MASTER---------------------------------------------------------------------------------------------------------------
            If Label8.Text = "Process_challan_book_master" Then
                PROCESS_CHLLAN_MASTER_SELECTION()
            End If
#End Region


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub






#Region "Sundry_frm"
    Private Sub sundry_selection()
        'If Label1.Text = "Sundry_frm_modify" Then
        '    Bill_Sundry_Master.TextBox1.Text = Label2.Text
        '    Bill_Sundry_Master.Label4.Text = Label2.Text
        '    Bill_Sundry_Master.TextBox2.Text = Label6.Text
        '    Bill_Sundry_Master.TextBox3.Text = Label3.Text
        '    Exit Sub
        'End If
    End Sub
#End Region

#Region "book master"
    Private Sub bk_master_selection()
        'If Label1.Text = "Book_Master_ac_name" Then
        '    Book_Master.TextBox8.Text = Label2.Text
        '    Book_Master.TextBox33.Text = Label3.Text
        '    Exit Sub
        'End If
        'If Label1.Text = "Book_Master_modify" Then
        '    Book_Master.TextBox36.Text = Label3.Text
        '    Exit Sub
        'End If
    End Sub
#End Region

#Region "bill sundary define"
    Private Sub bill_sundary_define()
        'If Label1.Text = "Bill_sundry_book_select" Then
        '    Define_bill_sundry.TextBox3.Text = Label3.Text
        '    Define_bill_sundry.TextBox1.Text = Label2.Text
        '    Exit Sub
        'End If

        'If Label1.Text = "Define_bill_sundry_SUNDARY_NAME" Then
        '    Define_bill_sundry.DataGridView2.CurrentRow.Cells(1).Value = Label2.Text
        '    Define_bill_sundry.DataGridView2.CurrentRow.Cells(11).Value = Label3.Text
        '    Exit Sub
        'End If
        'If Label1.Text = "Define_bill_sundry_ac_name" Then
        '    Define_bill_sundry.DataGridView2.CurrentRow.Cells(9).Value = Label2.Text
        '    Define_bill_sundry.DataGridView2.CurrentRow.Cells(12).Value = Label3.Text
        '    Exit Sub
        'End If


    End Sub
#End Region

#Region "ORDER BOOK MASTER"
    Private Sub ORDER_BOOK_MASTER_SELECTION()
        'If Label1.Text = "Order_Book_Master_modify" Then
        '    Order_Book_Master.TextBox19.Text = Label3.Text
        '    Order_Book_Master.TextBox1.Text = Label2.Text
        '    Exit Sub
        'End If
    End Sub
#End Region


#Region "PACKING SLIP MASTER"
    Private Sub PACKING_SLIP_MASTER_SELECTION()
        'If Label1.Text = "Packing_Slip_Book_Master_modify" Then
        '    Packing_Slip_Book_Master.TextBox21.Text = Label3.Text
        '    Packing_Slip_Book_Master.TextBox1.Text = Label2.Text
        '    Exit Sub
        'End If
    End Sub
#End Region

#Region "PROCESS CHALLAN MASTER"
    Private Sub PROCESS_CHLLAN_MASTER_SELECTION()
        'If Label1.Text = "Process_challan_book_master_modify" Then
        '    Process_challan_book_master.TextBox15.Text = Label3.Text
        '    Process_challan_book_master.TextBox1.Text = Label2.Text
        '    Exit Sub
        'End If
    End Sub
#End Region

#Region "GREY CHALLAN MASTER"
    Private Sub GREY_CHALLAN_MASTER_SELECTION()
        'If Label1.Text = "Grey_Challan_Book_Master_modify" Then
        '    Grey_Challan_Book_Master.TextBox41.Text = Label3.Text
        '    Grey_Challan_Book_Master.TextBox1.Text = Label2.Text
        '    Exit Sub
        'End If
    End Sub
#End Region



End Class