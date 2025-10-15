'Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.FindControl

'Imports System.Web.UI.WebControls
'Imports System.Windows.Forms
'Imports System.Text
'Imports System.ComponentModel
'Imports CrystalDecisions.CrystalReports.Engine
'Imports System.Runtime.CompilerServices
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.CrystalReports
'Imports System.Data.OleDb
Friend Class Party_selection_multy
    Dim FOUND As Boolean = True
    Dim _FormActive As Boolean = False
    Dim _FormLodWidtha As Integer = 0

    Dim _EnterSelectionCode As String = ""
    Dim _CityFilterTrue As Boolean = False
    Dim _tmptbl As New DataTable
    Dim _TmpDataRow As DataRow


#Region "FORM LOAD"
    Private Sub Party_selection_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Me.TopMost = True
        'Me.BringToFront()
    End Sub
    Private Sub Party_selection_multy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = 0
        Dim y As Integer = 0

        _FormLodWidtha = Me.Width
        _FormActive = True




        x = Screen.PrimaryScreen.WorkingArea.Width - 650
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        Me.Location = New Point(x, y)

        Me.Height = Screen_Height - 90
        GroupBox1.Height = Screen_Height - 90
        dgw.Height = Screen_Height - 170


        _MultyShadeTbl.Clear()


        If _tmptbl.Columns.Contains("Accountcode") Then
            _tmptbl.Columns.Remove("Accountcode") ' Remove existing column
            _tmptbl.Columns.Remove("AccountName") ' Remove existing column
            _tmptbl.Columns.Remove("Other") ' Remove existing column
        End If

        _tmptbl.Columns.Add("Accountcode", Type.GetType("System.String"))
        _tmptbl.Columns.Add("AccountName", Type.GetType("System.String"))
        _tmptbl.Columns.Add("Other", Type.GetType("System.String"))



        For Each tb As TextBox In GroupBox1.Controls.OfType(Of TextBox)()
            AddHandler tb.Enter, AddressOf TextBoxes_Enter
            AddHandler tb.Leave, AddressOf TextBoxes_Leave
        Next

        TextBox1.SelectAll()
        TextBox1.Focus()

        If Label1.Text = "utility_bookmaster_group_name_party" Then BOOK_INVOICE()
        If Label1.Text = "utility_bookmaster_DeliveryAt" Then DeliveryAt_INVOICE()
        If Label1.Text = "Challan_name_group_name_party" Then BOOK_MASTER_CHALLAN_LIST()
        If Label1.Text = "order_name_group_name_party" Then BOOK_MASTER_ORDER_BOOK_LIST()
        If Label1.Text = "Grey_Challan_Book_Master_FACTORY_name_party" Then GREY_CHALLAN_FACTORY_LIST()
        If Label1.Text = "Grey_Challan_Book_Master_GREYPARTY_name_party" Then GREY_CHALLAN_GREY_LIST()
        If Label1.Text = "Grey_Challan_Book_Master_SALES_name_party" Then GREY_CHALLAN_SALES_LIST()
        If Label1.Text = "Grey_Challan_Book_Master_PROCESS_name_party" Then GREY_CHALLAN_PROCESS_LIST()
        If Label1.Text = "Order_Book_Master_group_name_party" Then ORDER_BOOK_GROUP_LIST()
        If Label1.Text = "Packing_Slip_Book_Master_group_name_party" Then PACKING_SLIP_GROUP_NAME()
        If Label1.Text = "Packing_Slip_Book_Master_OFFER_name_party" Then PACKING_SLIP_OFFER_LIST()

        'Dim _ColumnName As String = ""
        'txtFilterType.Text = ""
        'For Each column As DataColumn In DefaltSoftTable.Columns
        '    If _ColumnName = "" Then
        '        _ColumnName = (column.ColumnName)
        '        txtFilterType.Text = _ColumnName
        '    Else
        '        _ColumnName = _ColumnName & "," & (column.ColumnName)
        '    End If
        'Next
        'txtFilterType.SpacerString = _ColumnName


    End Sub
#Region "FIREST SELECTION"
    Private Sub BOOK_INVOICE()
        'If Book_Master.TextBox32.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Book_Master.TextBox32.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        '    Label1.Text = ""
        '    Book_Master.TextBox32.Text = ""

        'End If
    End Sub

    Private Sub DeliveryAt_INVOICE()
        'If Book_Master.TxtDeliveryAtCode.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Book_Master.TxtDeliveryAtCode.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub



    Private Sub BOOK_MASTER_CHALLAN_LIST()
        'If Book_Master.TextBox34.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Book_Master.TextBox34.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub
    Private Sub BOOK_MASTER_ORDER_BOOK_LIST()

        'If Book_Master.TextBox35.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Book_Master.TextBox35.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub

#Region "GREY CHALLAN BOOK"
    Private Sub GREY_CHALLAN_FACTORY_LIST()
        'If Grey_Challan_Book_Master.TextBox42.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Grey_Challan_Book_Master.TextBox42.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub
    Private Sub GREY_CHALLAN_GREY_LIST()
        'If Grey_Challan_Book_Master.TextBox43.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Grey_Challan_Book_Master.TextBox43.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub
    Private Sub GREY_CHALLAN_SALES_LIST()
        'If Grey_Challan_Book_Master.TextBox44.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Grey_Challan_Book_Master.TextBox44.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub
    Private Sub GREY_CHALLAN_PROCESS_LIST()
        'If Grey_Challan_Book_Master.TextBox45.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Grey_Challan_Book_Master.TextBox45.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub
#End Region

#Region "ORDER BOOK MASTER"
    Private Sub ORDER_BOOK_GROUP_LIST()
        'If Order_Book_Master.TextBox20.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Order_Book_Master.TextBox20.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub
#End Region

#Region "GPACKING SLIP BOOK MASTER"

    Private Sub PACKING_SLIP_GROUP_NAME()
        'If Packing_Slip_Book_Master.TextBox20.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Packing_Slip_Book_Master.TextBox20.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub

    Private Sub PACKING_SLIP_OFFER_LIST()
        'If Packing_Slip_Book_Master.TextBox22.Text = "" Then
        'Else
        '    Dim group_code As String = ""
        '    group_code = Replace((Packing_Slip_Book_Master.TextBox22.Text).ToString, "#", "'")
        '    Dim group_code1 As String = Replace((group_code).ToString, "(", "")
        '    Dim group_code2 As String = Replace((group_code1).ToString, "'", "")
        '    Dim group_code3 As String = Replace((group_code2).ToString, ")", "")
        '    Dim OfValues As String
        '    OfValues = ""
        '    Dim cdd = Split(group_code3, ",")
        '    For Each i In cdd
        '        OfValues = i
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(3, j).Value = OfValues Then
        '                dgw.Rows(j).Cells(0).Value = 1
        '            End If
        '        Next
        '    Next
        'End If
    End Sub


#End Region

#End Region


    Private Sub TextBoxes_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, TextBox).BackColor = Color.Bisque
    End Sub
    Private Sub TextBoxes_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, TextBox).BackColor = Color.LightCyan
        DirectCast(sender, TextBox).ForeColor = Color.Blue
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Down Then
                SendKeys.Send("{DOWN}")
                dgw.Focus()
            End If

            If e.KeyCode = Keys.Up Then
                SendKeys.Send("{UP}")
                dgw.Focus()
            End If

            If e.KeyCode = Keys.F2 Then
            End If


            If e.KeyCode = Keys.F11 Then
                For j = dgw.RowCount - 1 To 0 Step -1
                    If dgw(0, j).Value = 0 Then
                        dgw(0, j).Value = 1
                    Else
                        dgw(0, j).Value = 0
                    End If
                Next
            End If

            If e.KeyCode = Keys.F12 Then
                listedit()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Try
            If e.KeyChar = Chr(27) Then
                If TextBox1.Text = "" Then
                    If _CityFilterTrue = True Then
                        dgw.DataSource = DefaltSoftTable.Copy
                        dgw.Focus()
                        _CityFilterTrue = False
                        Exit Sub
                    Else
                        Me.Close()
                        Me.Dispose(True)
                        Exit Sub
                    End If

                Else
                    TextBox1.Text = ""
                    Exit Sub
                End If
            End If

            If e.KeyChar = Chr(13) Then

                If dgw.CurrentRow.Cells(0).Value = 0 Then
                    dgw.CurrentRow.Cells(0).Value = 1
                    If _EnterSelectionCode = "" Then
                        _EnterSelectionCode = "'" & dgw.CurrentRow.Cells(5).Value.ToString & "'"
                    Else
                        _EnterSelectionCode = _EnterSelectionCode & ",'" & dgw.CurrentRow.Cells(5).Value.ToString & "'"
                    End If
                    _TmpDataRow = _tmptbl.NewRow
                    _TmpDataRow("Accountcode") = dgw.CurrentRow.Cells(4).Value.ToString
                    _TmpDataRow("AccountName") = dgw.CurrentRow.Cells(1).Value.ToString
                    _TmpDataRow("Other") = dgw.CurrentRow.Cells(2).Value.ToString
                    _tmptbl.Rows.Add(_TmpDataRow)

                    TextBox1.Focus()
                    TextBox1.SelectAll()
                    Exit Sub
                End If

                If dgw.CurrentRow.Cells(0).Value = 1 Then
                    dgw.CurrentRow.Cells(0).Value = 0
                    TextBox1.Focus()
                    TextBox1.SelectAll()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.CharacterCasing = CharacterCasing.Upper
        Dim s As String = ""
        Dim _SearchAny As Boolean = False

        'Dim _txtFilter As String()
        '_txtFilter = txtFilterType.SpacerString.ToString.Split(",")
        'Dim _ColmNo As Integer = 1
        'For i As Integer = 0 To _txtFilter.Length - 1
        '    Dim add As String = _txtFilter(i)
        '    If add = txtFilterType.Text Then
        '        _ColmNo = i
        '    End If
        'Next
        '_ColmNo = _ColmNo + 1


        'If _FormActive = True Then
        '    Dim _Tmptbl As New DataTable
        '    If _ItemSearchTypingWise = "YES" Then
        '        _SearchAny = True
        '        _Tmptbl = DefaltSoftTable.Clone
        '        Dim Col_Name_1 As String = "[" & txtFilterType.Text & "]"
        '        Dim Col_Name_2 As String = "[" & DefaltSoftTable.Columns(2).ColumnName & "]"
        '        Dim Total_Row As Integer = 0
        '        Dim Filter_Con As String = "(" & Col_Name_1 & " like '%" & TextBox1.Text.ToString.Trim & "%')"

        '        For Each dr As DataRow In DefaltSoftTable.Select(Filter_Con, Col_Name_1)
        '            _Tmptbl.ImportRow(dr)
        '            Total_Row = Total_Row + 1
        '        Next
        '        dgw.DataSource = _Tmptbl.Copy

        '        If _FormLodWidtha = 644 Then
        '        Else
        '            '_TwoColoumShow()
        '        End If

        '        dgw.Focus()
        '    End If
        'End If



        If _FormActive = True Then
            Dim _Tmptbl As New DataTable
            If _ItemSearchTypingWise = "YES" Then
                _SearchAny = True
                _Tmptbl = DefaltSoftTable.Clone
                Dim Col_Name_1 As String = "[" & DefaltSoftTable.Columns(0).ColumnName & "]"
                Dim Col_Name_2 As String = "[" & DefaltSoftTable.Columns(2).ColumnName & "]"
                Dim Total_Row As Integer = 0
                Dim Filter_Con As String = "(" & Col_Name_1 & " like '%" & TextBox1.Text.ToString.Trim & "%')"

                For Each dr As DataRow In DefaltSoftTable.Select(Filter_Con, Col_Name_1)
                    _Tmptbl.ImportRow(dr)
                    Total_Row = Total_Row + 1
                Next
                dgw.DataSource = _Tmptbl.Copy
                dgw.Focus()
                If _FormLodWidtha = 644 Then
                Else
                    _TwoColoumShow()
                End If
            End If

        End If





        If TextBox1.Text <> "" Then
            s = TextBox1.Text.Trim
            dgw.CurrentCell = Nothing
            For x As Integer = 0 To dgw.Rows.Count - 1
                If Not IsNothing(dgw.Rows(x).Cells(1).Value) AndAlso Not IsDBNull(dgw.Rows(x).Cells(1).Value) Then
                    If CStr(dgw.Rows(x).Cells(1).Value).StartsWith(s) Then
                        'If CStr(dgw.Rows(x).Cells(_ColmNo).Value).StartsWith(s) Then
                        dgw.FirstDisplayedScrollingRowIndex = x
                        dgw.Item(0, x).Selected = True
                        Label2.Text = dgw.SelectedCells(1).Value.ToString()
                        Label3.Text = dgw.SelectedCells(4).Value.ToString()
                        Label6.Text = dgw.SelectedCells(2).Value.ToString()
                        MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(1).Value.ToString()
                        MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(2).Value.ToString()
                        FOUND = True
                        Exit For
                        'Label7.Text = dgw.SelectedCells(5).Value.ToString()
                        'Exit Sub
                    End If
                End If
            Next
        End If

        If TextBox1.Text = Nothing Then
            dgw.CurrentCell = Nothing
            dgw.FirstDisplayedScrollingRowIndex = 0
            dgw.Rows(0).Selected = True
            If dgw.SelectedCells.Count > 1 AndAlso Not IsNothing(dgw.SelectedCells(1).Value) Then
                Label2.Text = dgw.SelectedCells(1).Value.ToString()
                Label3.Text = dgw.SelectedCells(4).Value.ToString()
                Label6.Text = dgw.SelectedCells(2).Value.ToString()
                MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(1).Value.ToString()
                MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(2).Value.ToString()
            End If
        End If

        'If _SearchAny = False Then
        '    pname = Trim(TextBox1.Text.ToUpper)
        '    ln = Len(pname)
        '    If FOUND = False Then
        '        '    Beep()
        '        If Len(Trim(TextBox1.Text)) > 0 Then TextBox1.Text = Mid(pname, 1, ln - 1)
        '        TextBox1.SelectionStart = Len(TextBox1.Text)
        '    End If
        'End If

    End Sub
    Private Sub _TwoColoumShow()
        If dgw.RowCount > 1 Then
            Dim Chk As New DataGridViewCheckBoxColumn()

            dgw.Columns.Add(Chk)

            dgw.Columns(2).Visible = False
            dgw.Columns(3).Visible = False
            dgw.Columns(4).Visible = False
            dgw.Columns(0).Width = 280
            dgw.Columns(1).Width = 160
            dgw.Columns(5).Width = 130
            Width = 506


        End If
    End Sub

    Private Sub dgw_RowHeightChanged(sender As Object, e As DataGridViewRowEventArgs) Handles dgw.RowHeightChanged
        dgw.RowTemplate.Height = 30
    End Sub
    Private Sub dgw_KeyDown(sender As Object, e As KeyEventArgs) Handles dgw.KeyDown
        If e.KeyCode = Keys.F2 Then
            'Call Master_open()

        ElseIf e.KeyCode = Keys.F12 Then
            listedit()
        ElseIf e.KeyCode = Keys.F11 Then
            If dgw.CurrentRow.Cells(0).Value = 0 Then
                For j = dgw.RowCount - 1 To 0 Step -1
                    dgw(0, j).Value = 1
                Next
            Else
                For j = dgw.RowCount - 1 To 0 Step -1
                    dgw(0, j).Value = 0
                Next
            End If


        ElseIf e.KeyCode = Keys.Enter Then

            If dgw.CurrentRow.Cells(0).Value = 0 Then
                dgw.CurrentRow.Cells(0).Value = 1
                If _EnterSelectionCode = "" Then
                    _EnterSelectionCode = "'" & dgw.CurrentRow.Cells(4).Value.ToString & "'"
                Else
                    _EnterSelectionCode = _EnterSelectionCode & ",'" & dgw.CurrentRow.Cells(4).Value.ToString & "'"
                End If

                _TmpDataRow = _tmptbl.NewRow
                _TmpDataRow("Accountcode") = dgw.CurrentRow.Cells(4).Value.ToString
                _TmpDataRow("AccountName") = dgw.CurrentRow.Cells(1).Value.ToString
                _TmpDataRow("Other") = dgw.CurrentRow.Cells(2).Value.ToString
                _tmptbl.Rows.Add(_TmpDataRow)

                SendKeys.Send("{HOME}")
                SendKeys.Send("{DOWN}")
                e.SuppressKeyPress = True
                    TextBox1.Focus()
                    TextBox1.SelectAll()
                    Exit Sub
                End If

                If dgw.CurrentRow.Cells(0).Value = 1 Then
                dgw.CurrentRow.Cells(0).Value = 0
                TextBox1.Focus()
                TextBox1.SelectAll()
                e.SuppressKeyPress = True
                Exit Sub
            End If
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
        End If
    End Sub
    Private Sub dgw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgw.KeyPress

        If e.KeyChar = Chr(27) Then
            TextBox1.Focus()
            Exit Sub
        ElseIf e.KeyChar = Chr(8) Then
            TextBox1.Focus()
            Exit Sub
        End If


        TextBox1.Text = TextBox1.Text + e.KeyChar
        TextBox1.SelectionStart = TextBox1.TextLength
        TextBox1.Focus()
        TextBox1.DeselectAll()

    End Sub
    Private Sub dgw_KeyUp(sender As Object, e As KeyEventArgs) Handles dgw.KeyUp
        Try
            'If dgw.CurrentRow.Cells(0).Value = 1 Then
            '    Label2.Text = dgw.SelectedCells(1).Value.ToString()
            'Label3.Text = dgw.SelectedCells(4).Value.ToString()
            'Label6.Text = dgw.SelectedCells(2).Value.ToString()
            'MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(1).Value.ToString()
            'MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(2).Value.ToString()
            'End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
        'Label7.Text = dgw.SelectedCells(5).Value.ToString()
    End Sub
    Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs) Handles dgw.MouseClick
        Label2.Text = dgw.SelectedCells(1).Value.ToString()
        Label3.Text = dgw.SelectedCells(4).Value.ToString()
        Label6.Text = dgw.SelectedCells(2).Value.ToString()
        MULTY_SELECTION_COLOUM_1_DATA = dgw.SelectedCells(1).Value.ToString()
        MULTY_SELECTION_COLOUM_2_DATA = dgw.SelectedCells(2).Value.ToString()
        'Label7.Text = dgw.SelectedCells(5).Value.ToString()
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
#End Region


#Region "LIST EDIT"
    Public Function listedit()


        'Try
        '    Dim SLCT_LST_ITM As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then
        '            SLCT_LST_ITM = "1"
        '        End If
        '    Next
        '    If SLCT_LST_ITM = "" Then
        '        MsgBox("Please Select List Item", MsgBoxStyle.Information, "Soft-Tex PRO")
        '        Exit Function
        '    End If

        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    Dim Account_Name As String = ""

        '    Dim COLUM_2 As String = ""

        '    Dim CODE2 As String = ""
        '    Dim CODE3 As String = ""

        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            _TmpDataRow = _tmptbl.NewRow
        '            _TmpDataRow("Accountcode") = dgw.Rows(j).Cells(4).Value.ToString
        '            _TmpDataRow("AccountName") = dgw.Rows(j).Cells(1).Value.ToString
        '            _TmpDataRow("Other") = dgw.Rows(j).Cells(2).Value.ToString
        '            _tmptbl.Rows.Add(_TmpDataRow)

        '            If name_code = Nothing Then
        '                name_code = "'" + dgw.Rows(j).Cells(4).Value.ToString + "'"
        '                COLUM_2 = "'" + dgw.Rows(j).Cells(3).Value.ToString + "'"
        '                Account_Name = "'" + dgw.Rows(j).Cells(1).Value.ToString + "'"

        '            Else
        '                name_code = CODE + "'" + dgw.Rows(j).Cells(4).Value.ToString + "'"
        '                COLUM_2 = CODE2 + "'" + dgw.Rows(j).Cells(3).Value.ToString + "'"
        '                Account_Name = CODE3 + "'" + dgw.Rows(j).Cells(1).Value.ToString + "'"
        '            End If
        '        End If
        '        CODE = name_code + ","
        '        CODE2 = COLUM_2 + ","
        '        CODE3 = Account_Name + ","
        '    Next

        '    If _EnterSelectionCode > "" Then
        '        If _ItemSearchTypingWise = "YES" Then
        '            MULTY_SELECTION_COLOUM_3_DATA = "(" + name_code + "," + _EnterSelectionCode + ")"
        '            MULTY_SELECTION_COLOUM_1_DATA = "(" + Account_Name + ")"
        '        Else
        '            MULTY_SELECTION_COLOUM_3_DATA = "(" + name_code + ")"
        '            MULTY_SELECTION_COLOUM_1_DATA = "(" + Account_Name + ")"
        '        End If
        '    Else
        '        MULTY_SELECTION_COLOUM_3_DATA = "(" + name_code + ")"
        '        MULTY_SELECTION_COLOUM_1_DATA = "(" + Account_Name + ")"
        '    End If

        '    MULTY_SELECTION_COLOUM_4_DATA = "(" + COLUM_2 + ")"

        '    Dim pNewDataTable As DataTable
        'Dim pCurrentRowCopy As DataRow
        'Dim pColumnList As New List(Of String)
        'Dim pColumn As DataColumn
        '    'Build column list
        '    For Each pColumn In _tmptbl.Columns
        '        pColumnList.Add(pColumn.ColumnName)
        '    Next
        '    'Filter by all columns
        '    pNewDataTable = _tmptbl.DefaultView.ToTable(True, pColumnList.ToArray)
        '    _tmptbl = _tmptbl.Clone
        '    'Import rows into original table structure
        '    For Each pCurrentRowCopy In pNewDataTable.Rows
        '        _tmptbl.ImportRow(pCurrentRowCopy)
        '    Next

        '    _MultyShadeTbl = _tmptbl.Copy

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'Finally
        'End Try



        Try
            Dim SLCT_LST_ITM As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    SLCT_LST_ITM = "1"
                    Exit For
                End If
            Next
            If SLCT_LST_ITM = "" Then
                MsgBox("Please Select List Item", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Function
            End If

            Dim name_code_list As New List(Of String)
            Dim col2_list As New List(Of String)
            Dim accname_list As New List(Of String)

            _tmptbl.Rows.Clear()

            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    _TmpDataRow = _tmptbl.NewRow
                    _TmpDataRow("Accountcode") = dgw.Rows(j).Cells(4).Value.ToString
                    _TmpDataRow("AccountName") = dgw.Rows(j).Cells(1).Value.ToString
                    _TmpDataRow("Other") = dgw.Rows(j).Cells(2).Value.ToString
                    _tmptbl.Rows.Add(_TmpDataRow)

                    name_code_list.Add("'" & dgw.Rows(j).Cells(4).Value.ToString & "'")
                    col2_list.Add("'" & dgw.Rows(j).Cells(3).Value.ToString & "'")
                    accname_list.Add("'" & dgw.Rows(j).Cells(1).Value.ToString & "'")
                End If
            Next

            Dim name_code As String = String.Join(",", name_code_list)
            Dim COLUM_2 As String = String.Join(",", col2_list)
            Dim Account_Name As String = String.Join(",", accname_list)

            If _EnterSelectionCode > "" Then
                If _ItemSearchTypingWise = "YES" Then
                    MULTY_SELECTION_COLOUM_3_DATA = "(" & name_code & "," & _EnterSelectionCode & ")"
                    MULTY_SELECTION_COLOUM_1_DATA = "(" & Account_Name & ")"
                Else
                    MULTY_SELECTION_COLOUM_3_DATA = "(" & name_code & ")"
                    MULTY_SELECTION_COLOUM_1_DATA = "(" & Account_Name & ")"
                End If
            Else
                MULTY_SELECTION_COLOUM_3_DATA = "(" & name_code & ")"
                MULTY_SELECTION_COLOUM_1_DATA = "(" & Account_Name & ")"
            End If

            MULTY_SELECTION_COLOUM_4_DATA = "(" & COLUM_2 & ")"

            ' ---- Fast distinct rows ----
            Dim uniqueRows = _tmptbl.AsEnumerable().
        GroupBy(Function(r) New With {
                    Key .Accountcode = r.Field(Of String)("Accountcode"),
                    Key .AccountName = r.Field(Of String)("AccountName"),
                    Key .Other = r.Field(Of String)("Other")
                }).
        Select(Function(g) g.First()).CopyToDataTable()

            _tmptbl = uniqueRows.Copy()
            _MultyShadeTbl = _tmptbl.Copy()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try



        ' _Packing_Slip_Printing -------------------------------------------------------------------------------------------

        If Label1.Text = "Packing_Slip_Printing" Then
            _Packing_Slip_Printing()
        End If

        ' BOOK MASTER -------------------------------------------------------------------------------------------
        If Label8.Text = "Book_Master" Then
            utility_bookmaster_group_name()
        End If
        ' ORDER BOOK MASTER -------------------------------------------------------------------------------------------
        If Label8.Text = "Order_Book_Master" Then
            Order_Book_Master_group_name()
        End If
        ' PACKING SLIP BOOK MASTER -------------------------------------------------------------------------------------------
        If Label8.Text = "Packing_Slip_Book_Master" Then
            PACKING_SLIP_MASTER()
        End If
        ' GREY CHALLAN BOOK MASTER -------------------------------------------------------------------------------------------
        If Label8.Text = "Grey_Challan_Book_Master" Then
            GREY_CHALLAN_MASTER()
        End If

        ' FABRIC ITEM MASTER RATE LIST -------------------------------------------------------------------------------------------
        If Label8.Text = "Fabric_Item_Master_selection" Then
            FABRIC_ITEM_MASTER_RATE_LIST_PRINT()
        End If

        ' IT Confirmation Letter Printing -------------------------------------------------------------------------------------------
        If Label8.Text = "IT_printing" Then
            IT_Confirmation_Letter_Printing()
        End If


        ' INTREST REPORT_Printing -------------------------------------------------------------------------------------------
        If Label8.Text = "INTREST_Reports" Then
            INTREST_REPORT_Printing()
        End If

        'Insurance_Decl_Report -------------------------------------------------------------------------------------------
        If Label8.Text = "Insurance_Decl_Report" Then
            _Insurance_Decl_Report()
        End If

        'Transport_Register_Printing-------------------------------------------------------------------------------------------
        If Label8.Text = "Transport_Register_Printing" Then
            _Transport_Register_Printing()
        End If

        'Tds_Reports-------------------------------------------------------------------------------------------
        If Label8.Text = "Tds_Reports" Then
            _Tds_Reports()
        End If


        'Due_Piece_Grey_stk_Reports-------------------------------------------------------------------------------------------
        If Label8.Text = "Due_Piece_Grey_stk_Reports" Then
            _Due_Piece_Grey_stk_Reports()
        End If

        '_Grey_Process_Data_Display-------------------------------------------------------------------------------------------
        If Label8.Text = "Grey_Process_Data_Display" Then
            _Grey_Process_Data_Display()
        End If

        ' mis_Zooming_Summary -------------------------------------------------------------------------------------------
        If Label8.Text = "mis_Zooming_Summary" Then
            _mis_Zooming_Summary()
        End If

        ' MAILFORM  -------------------------------------------------------------------------------------------
        If Label8.Text = "MAILFORM" Then
            MAIL_ID_SELECT()
        End If


        ' REPORT GENERATOR FORM JAGDISH JI -------------------------------------------------------------------------------------------

        If Label8.Text = "Challan_Register_printing" Then
            Multy_Challan_Printing()
        End If

        If Label8.Text = "Challan_register_printing_multy_party" Then
            Multy_Challan_Printing()
        End If

        If Label8.Text = "Grey_Process_Challan_register_printing_multy_party" Then
            Grey_Process_Multy_Challan_Printing()
        End If

        If Label8.Text = "Invoice_Bill_register_printing_multy_party" Then
            Multy_Party_Bill_Printing()
        End If

        If Label8.Text = "Invoice_Bill_register_printing_multy_Agent" Then
            Multy_Agent_Bill_Printing()
        End If

        If Label8.Text = "Packing_Slip_Bill_register_printing_multy_Party" Then
            Multy_Packing_Slip_Bill_Printing()
        End If

        Me.Close()
        Me.Dispose(True)

        Return _MultyShadeTbl
    End Function

#End Region


#Region "selection"


    ' PACKING SLIP PRINT  -------------------------------------------------------------------------------------------
    Private Sub _Packing_Slip_Printing()
        Dim name_list As String = ""
        Dim name_code As String = ""
        Dim CODE As String = ""
        For j As Integer = 0 To dgw.RowCount - 1
            If dgw(0, j).Value = 1 Then

                If name_code = Nothing Then
                    name_code = "'" + dgw.Rows(j).Cells(4).Value + "'"
                Else
                    name_code = CODE + "'" + dgw.Rows(j).Cells(4).Value + "'"
                End If
            End If
            CODE = name_code + ","
        Next

        'If Label8.Text = "Packing_Slip_printing_Party_Wise" Then
        '    Packing_Slip_Printing.ACCOUNT_CODE.Text = "(" + name_code + ")"

        'ElseIf Label8.Text = "Packing_Slip_printing_Item_Wise" Then
        '    Packing_Slip_Printing.ITEM_CODE.Text = "(" + name_code + ")"
        'ElseIf Label8.Text = "Packing_Slip_printing_Cut_Wise" Then
        '    Packing_Slip_Printing.CUT_CODE.Text = "(" + name_code + ")"
        'ElseIf Label8.Text = "Packing_Slip_printing_Design_Wise" Then
        '    Packing_Slip_Printing.DESIGN_CODE.Text = "(" + name_code + ")"
        'ElseIf Label8.Text = "Packing_Slip_printing_Shade_Wise" Then
        '    Packing_Slip_Printing.SHADE_CODE.Text = "(" + name_code + ")"
        'ElseIf Label8.Text = "Packing_Slip_Group_selection" Then
        '    Packing_Slip_Printing.txtFabGrp_Code.Text = "(" + name_code + ")"

        'End If

    End Sub



    ' FABRIC ITEM RATE LIST PRINT -------------------------------------------------------------------------------------------
    Private Sub FABRIC_ITEM_MASTER_RATE_LIST_PRINT()
        'If Label1.Text = "Fabric_Item_Master_selection_PRINT" Then
        '    REPORT_RPT_FILE_NAME = ""
        '    REPORT_RPT_FILE_NAME = "ITEM_MASTER_PRINT"
        '    Offer_Printing.BOOKCATEGORY.Text = "FABRIC ITEM RATE LIST"

        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "'" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "'" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + ","
        '    Next

        '    Offer_Printing.COMPANY_INFORMATION_PRINT()



        '    sqL = "SELECT * FROM MstFabricItem WHERE  ID IN  " & "(" + name_code + ")" & " "
        '    ConnDB()
        '    cmd = New SqlClient.SqlCommand(sqL, conn)
        '    cmd.CommandType = CommandType.Text
        '    Dim ADP2 As New SqlDataAdapter(cmd)
        '    Dim TAB2 As New DataTable
        '    ADP2.Fill(TAB2)
        '    cmd.Dispose()
        '    conn.Close()


        '    If TAB2.Rows.Count = 0 Then
        '        MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
        '        Exit Sub
        '    Else
        '        For Each dr As DataRow In TAB2.Select()
        '            RS1 = "INSERT INTO Printing(T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15,T16,T17,T18,T19,T20,T21,T22,T23,T24,T25,T26,T27) VALUES('" & (dr(0) & "") & "','" & (dr(1) & "") & "','" & (dr(2) & "") & "','" & (dr(3) & "") & "','" & (dr(4) & "") & "','" & (dr(5) & "") & "','" & (dr(6) & "") & "','" & (dr(7) & "") & "','" & (dr(8) & "") & "','" & (dr(9) & "") & "','" & (dr(10) & "") & "','" & (dr(11) & "") & "','" & (dr(12) & "") & "','" & (dr(13) & "") & "','" & (dr(14) & "") & "','" & (dr(15) & "") & "','" & (dr(16) & "") & "','" & (dr(17) & "") & "','" & (dr(18) & "") & "','" & (dr(19) & "") & "','" & (dr(20) & "") & "','" & (dr(21) & "") & "','" & (dr(22) & "") & "','" & (dr(23) & "") & "','" & (dr(24) & "") & "','" & (dr(25) & "") & "','" & (dr(26) & "") & "')"
        '            DB_PRINTING()
        '            MSA_CMD1 = New OleDb.OleDbCommand(RS1, Printing_CONN)
        '            MSA_CMD1.ExecuteNonQuery()
        '            MSA_CMD1.Dispose()
        '            Printing_CONN.Close()
        '        Next
        '    End If
        '    Offer_Printing.REPORT_PINTING_OPTION()
        'End If
    End Sub

    ' Account_Master_Reports -------------------------------------------------------------------------------------------
    Private Sub _ACCOUNT_MASTER_PRINT()
        Dim name_list As String = ""
        Dim name_code As String = ""
        Dim CODE As String = ""
        For j As Integer = 0 To dgw.RowCount - 1
            If dgw(0, j).Value = 1 Then

                If name_code = Nothing Then
                    name_code = "'" + dgw.Rows(j).Cells(4).Value + "'"
                Else
                    name_code = CODE + "'" + dgw.Rows(j).Cells(4).Value + "'"
                End If
            End If
            CODE = name_code + ","
        Next

        MULTY_SELECTION_COLOUM_3_DATA = "(" + name_code + ")"


        'If Label1.Text = "Account_Master_Reports_AGENT" Then
        '    Account_Master_Reports.AGENTCODE.Text = "(" + name_code + ")"
        'ElseIf Label1.Text = "Account_Master_Reports_PARTY" Then
        '    Account_Master_Reports.PARTYCODE.Text = "(" + name_code + ")"
        'ElseIf Label1.Text = "Grey_Challan_VIEW" Then
        '    'Grey_Challan.VIEW_SELECTPARTYCODE.Text = "(" + name_code + ")"
        'ElseIf Label1.Text = "Process_Challan_VIEW" Then
        '    'Process_Challan.VIEW_SELECTPARTYCODE.Text = "(" + name_code + ")"
        'ElseIf Label1.Text = "Finish_packing_slip_VIEW" Then
        '    Finish_packing_slip.VIEW_SELECTPARTYCODE.Text = "(" + name_code + ")"
        'ElseIf Label1.Text = "Yarn_challan_entry_VIEW" Then
        '    Yarn_challan_entry.VIEW_SELECTPARTYCODE.Text = "(" + name_code + ")"
        'ElseIf Label1.Text = "Denium_roll_packing_slip_VIEW" Then
        '    Denium_roll_packing_slip.VIEW_SELECTPARTYCODE.Text = "(" + name_code + ")"
        'End If
    End Sub


    'MAIL FORM-------------------------------------------------------------------------------------------
    Private Sub MAIL_ID_SELECT()
        'If Label1.Text = "Grey_Process_Data_Display_FACTORY_CHALLAN_SELECTION" Then
        Dim name_list As String = ""
        Dim name_code As String = ""
        Dim CODE As String = ""
        For j As Integer = 0 To dgw.RowCount - 1
            If dgw(0, j).Value = 1 Then

                If name_code = Nothing Then
                    name_code = dgw.Rows(j).Cells(4).Value
                Else
                    name_code = CODE + dgw.Rows(j).Cells(4).Value
                End If
            End If
            CODE = name_code + ","
        Next

        'If mailform.txt_To.Text = "." Then mailform.txt_To.Text = ""

        'If mailform.txt_To.Text <> "" Then
        '    mailform.txt_To.Text = mailform.txt_To.Text + "," + name_code
        'Else
        '    mailform.txt_To.Text = name_code
        'End If
        Exit Sub
        'End If
    End Sub


    ' mis_Zooming_Summary -------------------------------------------------------------------------------------------
    Private Sub _mis_Zooming_Summary()
        If Label1.Text = "mis_Zooming_Summary_GROUP_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""

            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.GROUPCODE='" + dgw.Rows(j).Cells(4).Value + "'"

                    Else
                        name_code = CODE + " A.GROUPCODE='" + dgw.Rows(j).Cells(4).Value + "'"

                    End If
                End If
                CODE = name_code + " OR "

            Next
            'mis_Zooming_Summary.GROUP_CODE.Text = "( " + name_code + " )"
            Exit Sub
        End If

    End Sub

    ' BOOK MASTER -------------------------------------------------------------------------------------------
    Private Sub utility_bookmaster_group_name()
        If Label1.Text = "utility_bookmaster_group_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Book_Master.TextBox6.Text = name_list
            'Book_Master.TextBox32.Text = "(#" + name_code + "#)"
            Exit Sub
        End If

        If Label1.Text = "utility_bookmaster_DeliveryAt" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Book_Master.Txt_DeliveryAt.Text = name_list
            'Book_Master.TxtDeliveryAtCode.Text = "(#" + name_code + "#)"
            Exit Sub
        End If


        If Label1.Text = "Challan_name_group_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Book_Master.TextBox10.Text = name_list
            'Book_Master.TextBox34.Text = "(#" + name_code + "#)"
            Exit Sub
        End If

        If Label1.Text = "order_name_group_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Book_Master.TextBox12.Text = name_list
            'Book_Master.TextBox35.Text = "(#" + name_code + "#)"
            Exit Sub
        End If

    End Sub
    ' ORDER BOOK MASTER -------------------------------------------------------------------------------------------
    Private Sub Order_Book_Master_group_name()
        If Label1.Text = "Order_Book_Master_group_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Order_Book_Master.TextBox5.Text = name_list
            'Order_Book_Master.TextBox20.Text = "(#" + name_code + "#)"
            Exit Sub
        End If
    End Sub
    ' PACKING SLIP BOOK MASTER -------------------------------------------------------------------------------------------
    Private Sub PACKING_SLIP_MASTER()
        If Label1.Text = "Packing_Slip_Book_Master_group_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Packing_Slip_Book_Master.TextBox18.Text = name_list
            'Packing_Slip_Book_Master.TextBox20.Text = "(#" + name_code + "#)"
            Exit Sub
        End If


        If Label1.Text = "Packing_Slip_Book_Master_OFFER_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Packing_Slip_Book_Master.TextBox19.Text = name_list
            'Packing_Slip_Book_Master.TextBox22.Text = "(#" + name_code + "#)"
            Exit Sub
        End If

    End Sub
    ' GREY CHALLAN BOOK MASTER -------------------------------------------------------------------------------------------
    Private Sub GREY_CHALLAN_MASTER()
        If Label1.Text = "Grey_Challan_Book_Master_FACTORY_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Grey_Challan_Book_Master.TextBox4.Text = name_list
            'Grey_Challan_Book_Master.TextBox42.Text = "(#" + name_code + "#)"
            Exit Sub
        End If

        If Label1.Text = "Grey_Challan_Book_Master_GREYPARTY_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Grey_Challan_Book_Master.TextBox5.Text = name_list
            'Grey_Challan_Book_Master.TextBox43.Text = "(#" + name_code + "#)"
            Exit Sub
        End If
        If Label1.Text = "Grey_Challan_Book_Master_SALES_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Grey_Challan_Book_Master.TextBox6.Text = name_list
            'Grey_Challan_Book_Master.TextBox44.Text = "(#" + name_code + "#)"
            Exit Sub
        End If
        If Label1.Text = "Grey_Challan_Book_Master_PROCESS_name_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_list = "" Then
                        name_list = dgw.Rows(j).Cells(1).Value
                    Else
                        name_list = dgw.Rows(j).Cells(1).Value + "," + name_list
                    End If
                    If name_code = "" Then
                        name_code = dgw.Rows(j).Cells(4).Value
                    Else
                        name_code = dgw.Rows(j).Cells(4).Value + "#," + "#" + name_code
                    End If
                End If
            Next
            'Grey_Challan_Book_Master.TextBox7.Text = name_list
            'Grey_Challan_Book_Master.TextBox45.Text = "(#" + name_code + "#)"
            Exit Sub
        End If
    End Sub

    ' GST_Returen -------------------------------------------------------------------------------------------
    'Private Sub GST_Reture()
    '    If Label1.Text = "GST_Returen_Party_Name_Select" Then
    '        Dim name_list As String = ""
    '        Dim name_code As String = ""
    '        Dim CODE As String = ""

    '        For j As Integer = 0 To dgw.RowCount - 1

    '            If dgw(0, j).Value = 1 Then

    '                If name_code = Nothing Then
    '                    name_code = "k.accountcode='" + dgw.Rows(j).Cells(4).Value + "'"
    '                Else
    '                    name_code = CODE + "k.accountcode='" + dgw.Rows(j).Cells(4).Value + "'"
    '                End If
    '            End If
    '            CODE = name_code + " OR "
    '        Next
    '        GST_Returen.Party_Code.Text = name_code
    '        Exit Sub
    '    End If

    '    If Label1.Text = "GST_Returen_BOOK_SELECTION" Then
    '        Dim name_list As String = ""
    '        Dim name_code As String = ""
    '        Dim CODE As String = ""

    '        For j As Integer = 0 To dgw.RowCount - 1

    '            If dgw(0, j).Value = 1 Then

    '                If name_code = Nothing Then
    '                    name_code = "E.BOOKCODE='" + dgw.Rows(j).Cells(4).Value + "'"
    '                Else
    '                    name_code = CODE + "E.BOOKCODE='" + dgw.Rows(j).Cells(4).Value + "'"
    '                End If
    '            End If
    '            CODE = name_code + " OR "
    '        Next
    '        GST_Returen.Selection_Book_Code.Text = name_code
    '        Exit Sub
    '    End If

    'End Sub
    ' OUTSTANDING -------------------------------------------------------------------------------------------
    Private Sub OUTSTANDING()
        'If Label1.Text = "Outstanding_Reports_GROUP_SELECT" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim name_code2 As String = ""
        '    Dim CODE As String = ""
        '    Dim CODE2 As String = ""

        '    For j As Integer = 0 To dgw.RowCount - 1

        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = " B.GROUPCODE='" + dgw.Rows(j).Cells(4).Value + "'"
        '                name_code2 = " A.GROUPCODE='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + " B.GROUPCODE='" + dgw.Rows(j).Cells(4).Value + "'"
        '                name_code2 = CODE2 + " A.GROUPCODE='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '        CODE2 = name_code2 + " OR "
        '    Next
        '    Outstanding_Reports.GROUP_CODE.Text = "( " + name_code + " )"
        '    GROUP_WISE_MULTY_PARTY_SELECT = " AND " + "( " + name_code2 + " )"
        '    Exit Sub
        'End If


        'If Label1.Text = "Outstanding_Reports_INVOICE_BOOK_SELECT" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = " N.BOOKCODE='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + " N.BOOKCODE='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Outstanding_Reports.BOOK_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Outstanding_Reports_ACCOUNT_WISE" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then
        '            If name_code = Nothing Then
        '                name_code = " A.accountcode='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + " A.accountcode='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Outstanding_Reports.ACCOUNT_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Outstanding_Reports_AGENT_WISE" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim name_code2 As String = ""
        '    Dim CODE As String = ""
        '    Dim CODE2 As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then
        '            If name_code = Nothing Then
        '                name_code = " F.accountcode='" + dgw.Rows(j).Cells(4).Value + "'"
        '                name_code2 = " A.AGENTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + " F.accountcode='" + dgw.Rows(j).Cells(4).Value + "'"
        '                name_code2 = CODE2 + " A.AGENTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '        CODE2 = name_code2 + " OR "
        '    Next
        '    Outstanding_Reports.AGENT_CODE.Text = "( " + name_code + " )"

        '    GROUP_WISE_MULTY_PARTY_SELECT = " AND " + "( " + name_code2 + " )"
        '    Exit Sub
        'End If


        'If Label1.Text = "Outstanding_Reports_CITY_WISE" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim name_code2 As String = ""
        '    Dim CODE As String = ""
        '    Dim CODE2 As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then
        '            If name_code = Nothing Then
        '                name_code = " G.citycode ='" + dgw.Rows(j).Cells(4).Value + "'"

        '            Else
        '                name_code = CODE + " G.citycode ='" + dgw.Rows(j).Cells(4).Value + "'"

        '            End If
        '        End If
        '        CODE = name_code + " OR "

        '    Next
        '    Outstanding_Reports.CITY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


    End Sub
    ' IT_Confirmation_Letter_Printing -------------------------------------------------------------------------------------------
    Private Sub IT_Confirmation_Letter_Printing()
        If Label1.Text = "IT_Reports_ACCOUNT_WISE" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim name_code2 As String = ""
            Dim CODE As String = ""
            Dim CODE2 As String = ""
            For j As Integer = 0 To dgw.RowCount - 1

                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.ACCOUNTCODE='" + dgw.Rows(j).Cells(4).Value + "'"
                        name_code2 = " H.oppaccountcode='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.ACCOUNTCODE='" + dgw.Rows(j).Cells(4).Value + "'"
                        name_code2 = CODE2 + " H.oppaccountcode='" + dgw.Rows(j).Cells(4).Value + "'"

                    End If
                End If
                CODE = name_code + " OR "
                CODE2 = name_code2 + " OR "
            Next
            'IT_Confirmation.Account_cod.Text = "( " + name_code + " )"
            'IT_Confirmation.OPP_ACC_CODE.Text = "( " + name_code2 + " )"
            Exit Sub
        End If

        If Label1.Text = "IT_Reports_GROUP_WISE" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_code = Nothing Then
                        name_code = " A.GROUPCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.GROUPCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            GROUP_WISE_MULTY_PARTY_SELECT = " AND " + "( " + name_code + " )"
            Exit Sub
        End If



        If Label1.Text = "IT_Reports_AGENT_WISE" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_code = Nothing Then
                        name_code = " A.AGENTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.AGENTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            GROUP_WISE_MULTY_PARTY_SELECT = " AND " + "( " + name_code + " )"
            Exit Sub
        End If



    End Sub
    ' INTREST REPORT_Printing -------------------------------------------------------------------------------------------
    Private Sub INTREST_REPORT_Printing()
        If Label1.Text = "INTREST_Reports_ACCOUNT_WISE" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.ACCOUNTCODE='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.ACCOUNTCODE='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Interest_Report_UL.Label14.Text = "( " + name_code + " )"
            Exit Sub
        End If
    End Sub

    ' Insurance_Decl_Report-------------------------------------------------------------------------------------------
    Private Sub _Insurance_Decl_Report()
        If Label1.Text = "Insurance_Decl_Report_BOOK" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""

            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.BOOKCODE='" + dgw.Rows(j).Cells(4).Value + "'"

                    Else
                        name_code = CODE + " A.BOOKCODE='" + dgw.Rows(j).Cells(4).Value + "'"

                    End If
                End If
                CODE = name_code + " OR "

            Next
            'Insurance_Decl_Report.book_code.Text = "( " + name_code + " )"
            Exit Sub
        End If
    End Sub
    ' Insurance_Decl_Report-------------------------------------------------------------------------------------------
    Private Sub _Transport_Register_Printing()
        If Label1.Text = "Transport_Register_Printing_TRANSPORT" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.TRANSPORTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.TRANSPORTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Transport_Register_Printing.transort_code.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Transport_Register_Printing_ACCOUNT_WISE" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_code = Nothing Then
                        name_code = " A.ACCOUNTCODE='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Transport_Register_Printing.ACCOUN_CODE.Text = "( " + name_code + " )"
            Exit Sub
        End If
    End Sub
    ' Tds_Reports-------------------------------------------------------------------------------------------
    Private Sub _Tds_Reports()
        If Label1.Text = "Tds_Reports_BOOK" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.BookCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.BookCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Tds_Reports.book_code.Text = "( " + name_code + " )"
            Exit Sub
        End If
    End Sub
    ' Ac_Of_Report-------------------------------------------------------------------------------------------
    Private Sub _Ac_Of_Report()
        'If Label1.Text = "Ac_Of_Report_ACCOUNT_OF" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  B.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  B.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Ac_Of_Report.AC_OF_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Ac_Of_Report_QUALITY" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    If Book_Behaviour = "YARN" Then
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(0, j).Value = 1 Then
        '                If name_code = Nothing Then
        '                    name_code = "  C.COUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                Else
        '                    name_code = CODE + "  C.COUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                End If
        '            End If
        '            CODE = name_code + " OR "
        '        Next

        '    Else
        '        For j As Integer = 0 To dgw.RowCount - 1
        '            If dgw(0, j).Value = 1 Then
        '                If name_code = Nothing Then
        '                    name_code = "  C.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                Else
        '                    name_code = CODE + "  C.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                End If
        '            End If
        '            CODE = name_code + " OR "
        '        Next
        '    End If

        '    Ac_Of_Report.QULTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


        'If Label1.Text = "Ac_Of_Report_ACCOUNT_WISE" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Ac_Of_Report.PARTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Ac_Of_Report_CITY_WISE" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  G.CITYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  G.CITYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Ac_Of_Report.city_code.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

    End Sub
    'Grey_Challan_Register_Printing-------------------------------------------------------------------------------------------
    Private Sub _Grey_Challan_Register_Printing()
        'If Label1.Text = "Grey_Challan_Register_Printing_ITEM_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Grey_Challan_Register_Printing.QULTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If



        'If Label1.Text = "Grey_Challan_Register_Printing_PARTY_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then

        '                If Grey_Challan_Register_Printing.TextBox8.Text = "FACTORY" Then
        '                    name_code = "  A.FACTORYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PARTY" Then
        '                    name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "SALES PARTY" Then
        '                    name_code = "  A.SALES_ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PURC PARTY" Then
        '                    name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                Else
        '                    name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                End If
        '            Else
        '                If Grey_Challan_Register_Printing.TextBox8.Text = "FACTORY" Then
        '                    name_code = CODE + "  A.FACTORYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PARTY" Then
        '                    name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "SALES PARTY" Then
        '                    name_code = CODE + "  A.SALES_ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PURC PARTY" Then
        '                    name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                Else
        '                    name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                End If
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Grey_Challan_Register_Printing.PARTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If



        'If Label1.Text = "Grey_Challan_Register_Printing_PROCESS_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = " A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Grey_Challan_Register_Printing.PROCESSCODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


    End Sub
    'Process_Challan_Register-------------------------------------------------------------------------------------------
    Private Sub _Process_Challan_Register()
        'If Label1.Text = "Process_Challan_Register_ITEM_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Process_Challan_Register.QULTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


        'If Label1.Text = "Process_Challan_Register_DESIGN_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  A.Fabric_DesignCode ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.Fabric_DesignCode ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Process_Challan_Register.DESIGN_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Process_Challan_Register_SHADE_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  A.Fabric_ShadeCode ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.Fabric_ShadeCode ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Process_Challan_Register.SHADE_code.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If



        'If Label1.Text = "Process_Challan_Register_PARTY_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then

        '                If Grey_Challan_Register_Printing.TextBox8.Text = "FACTORY" Then
        '                    name_code = "  A.FACTORYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PARTY" Then
        '                    name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "SALES PARTY" Then
        '                    name_code = "  A.SALES_ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PURC PARTY" Then
        '                    name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                Else
        '                    name_code = "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                End If
        '            Else
        '                If Grey_Challan_Register_Printing.TextBox8.Text = "FACTORY" Then
        '                    name_code = CODE + "  A.FACTORYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PARTY" Then
        '                    name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "SALES PARTY" Then
        '                    name_code = CODE + "  A.SALES_ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                ElseIf Grey_Challan_Register_Printing.TextBox8.Text = "PURC PARTY" Then
        '                    name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                Else
        '                    name_code = CODE + "  A.ACCOUNTCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '                End If
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Process_Challan_Register.PARTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If



        'If Label1.Text = "Process_Challan_Register_PROCESS_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = " A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Process_Challan_Register.PROCESSCODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


    End Sub
    'Shrinkage_Reports-------------------------------------------------------------------------------------------
    'Private Sub _Shrinkage_Reports()
    'If Label1.Text = "Shrinkage_Reports_ITEM_SELECTION" Then
    '    Dim name_list As String = ""
    '    Dim name_code As String = ""
    '    Dim CODE As String = ""
    '    For j As Integer = 0 To dgw.RowCount - 1
    '        If dgw(0, j).Value = 1 Then

    '            If name_code = Nothing Then
    '                name_code = "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            Else
    '                name_code = CODE + "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            End If
    '        End If
    '        CODE = name_code + " OR "
    '    Next
    '    Shrinkage_Reports.QULTY_CODE.Text = "( " + name_code + " )"
    '    Exit Sub
    'End If


    'If Label1.Text = "Shrinkage_Reports_DESIGN_SELECTION" Then
    '    Dim name_list As String = ""
    '    Dim name_code As String = ""
    '    Dim CODE As String = ""
    '    For j As Integer = 0 To dgw.RowCount - 1
    '        If dgw(0, j).Value = 1 Then

    '            If name_code = Nothing Then
    '                name_code = "  A.Fabric_DesignCode ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            Else
    '                name_code = CODE + "  A.Fabric_DesignCode ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            End If
    '        End If
    '        CODE = name_code + " OR "
    '    Next
    '    Shrinkage_Reports.DESIGN_CODE.Text = "( " + name_code + " )"
    '    Exit Sub
    'End If

    'If Label1.Text = "Shrinkage_Reports_SHADE_SELECTION" Then
    '    Dim name_list As String = ""
    '    Dim name_code As String = ""
    '    Dim CODE As String = ""
    '    For j As Integer = 0 To dgw.RowCount - 1
    '        If dgw(0, j).Value = 1 Then

    '            If name_code = Nothing Then
    '                name_code = "  A.Fabric_ShadeCode ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            Else
    '                name_code = CODE + "  A.Fabric_ShadeCode ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            End If
    '        End If
    '        CODE = name_code + " OR "
    '    Next
    '    Shrinkage_Reports.SHADE_code.Text = "( " + name_code + " )"
    '    Exit Sub
    'End If



    'If Label1.Text = "Shrinkage_Reports_PROCESS_SELECTION" Then
    '    Dim name_list As String = ""
    '    Dim name_code As String = ""
    '    Dim CODE As String = ""
    '    For j As Integer = 0 To dgw.RowCount - 1
    '        If dgw(0, j).Value = 1 Then

    '            If name_code = Nothing Then
    '                name_code = " A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            Else
    '                name_code = CODE + "  A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
    '            End If
    '        End If
    '        CODE = name_code + " OR "
    '    Next
    '    Shrinkage_Reports.PROCESSCODE.Text = "( " + name_code + " )"
    '    Exit Sub
    'End If


    'End Sub
    'Due_Piece_Grey_stk_Reports-------------------------------------------------------------------------------------------
    Private Sub _Due_Piece_Grey_stk_Reports()
        If Label1.Text = "Due_Piece_Grey_stk_Reports_ITEM_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.QULTY_CODE.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Due_Piece_Grey_stk_Reports_DESIGN_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.Fabric_DesignCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.Fabric_DesignCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.DESIGN_CODE.Text = "( " + name_code + " )"
            Exit Sub
        End If

        If Label1.Text = "Due_Piece_Grey_stk_Reports_SHADE_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.Fabric_ShadeCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.Fabric_ShadeCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.SHADE_code.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Due_Piece_Grey_stk_Reports_SELVEDGE_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.SELVCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.SELVCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.SELVE_CODE.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Due_Piece_Grey_stk_Reports_BEAM_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.BEAMNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.BEAMNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.BEAM_NO.Text = "( " + name_code + " )"
            Exit Sub
        End If

        If Label1.Text = "Due_Piece_Grey_stk_Reports_PROCESS_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.PROCESSCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.PROCESSCODE.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Due_Piece_Grey_stk_Reports_FACTORY_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = " A.FACTORYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.FACTORYCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.FACTORY_CODE.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Due_Piece_Grey_stk_Reports_FACTORY_CHALLAN_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then
                    If name_code = Nothing Then
                        name_code = " A.BOOKVNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.BOOKVNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Due_Piece_Grey_stk_Reports.CHALLAN_NO.Text = "( " + name_code + " )"
            Exit Sub
        End If
    End Sub
    'Finish_Stock_Report-------------------------------------------------------------------------------------------
    Private Sub _Finish_Stock_Report()
        'If Label1.Text = "Finish_Stock_Report_ITEM_SELECTION" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  C.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  C.FABRIC_ITEMCODE ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Finish_Stock_Report.QULTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Finish_Stock_Report_ITEM_SELECTION_2" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  Z.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  Z.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Finish_Stock_Report.QULTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If

        'If Label1.Text = "Finish_Stock_Report_ITEM_SELECTION_3" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  M.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  M.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Finish_Stock_Report.QULTY_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


        'If Label1.Text = "Finish_Stock_Report_GROUP_CODE" Then
        '    Dim name_list As String = ""
        '    Dim name_code As String = ""
        '    Dim CODE As String = ""
        '    For j As Integer = 0 To dgw.RowCount - 1
        '        If dgw(0, j).Value = 1 Then

        '            If name_code = Nothing Then
        '                name_code = "  N.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            Else
        '                name_code = CODE + "  N.ID ='" + dgw.Rows(j).Cells(4).Value + "'"
        '            End If
        '        End If
        '        CODE = name_code + " OR "
        '    Next
        '    Finish_Stock_Report.GROUP_CODE.Text = "( " + name_code + " )"
        '    Exit Sub
        'End If


    End Sub

    '_Grey_Process_Data_Display-------------------------------------------------------------------------------------------
    Private Sub _Grey_Process_Data_Display()
        If Label1.Text = "Grey_Process_Data_Display_FACTORY_CHALLAN_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.CHALLANNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.CHALLANNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Grey_Process_Data_Display.CHALLAN_NO.Text = "( " + name_code + " )"
            Exit Sub
        End If


        If Label1.Text = "Grey_Process_Data_Display_FACTORY_BEAM_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "  A.BEAMNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + " A.BEAMNO ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Grey_Process_Data_Display.CHALLAN_NO.Text = "( " + name_code + " )"
            Exit Sub
        End If

        If Label1.Text = "Grey_Process_Data_Display_ITEM_SELECTION" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1
                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "   A.fabric_ItemCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    Else
                        name_code = CODE + "  A.fabric_ItemCode ='" + dgw.Rows(j).Cells(4).Value + "'"
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Grey_Process_Data_Display.CHALLAN_NO.Text = "( " + name_code + " )"
            Exit Sub
        End If

    End Sub



#End Region


#Region "SELECTION LIST FROM J"
    Private Sub Invoice_Detail_Printing_Party_Wise()
        'Dim name_list As String = ""
        'Dim name_code As String = ""
        'Dim CODE As String = ""
        'For j As Integer = 0 To dgw.RowCount - 1
        '    If dgw(0, j).Value = 1 Then

        '        If name_code = Nothing Then
        '            name_code = "'" + dgw.Rows(j).Cells(4).Value + "'"
        '        Else
        '            name_code = CODE + "'" + dgw.Rows(j).Cells(4).Value + "'"
        '        End If
        '    End If
        '    CODE = name_code + ","
        'Next

        'If Label1.Text = "Invoice_register_printing_ACCOUNT" Then
        '    Invoice_register_printing.ACCOUNT_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_register_printing_AGENT" Then
        '    Invoice_register_printing.AGENT_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_register_printing_QUALITY" Then
        '    Invoice_register_printing.QUALITY_CODE.Text = "( " + name_code + " )"
        'End If
    End Sub

    Private Sub Invoice_Register_Summary_Printing_()
        'Dim name_list As String = ""
        'Dim name_code As String = ""
        'Dim CODE As String = ""
        'For j As Integer = 0 To dgw.RowCount - 1
        '    If dgw(0, j).Value = 1 Then

        '        If name_code = Nothing Then
        '            name_code = "'" + dgw.Rows(j).Cells(4).Value + "'"
        '        Else
        '            name_code = CODE + "'" + dgw.Rows(j).Cells(4).Value + "'"
        '        End If
        '    End If
        '    CODE = name_code + ","
        'Next

        'If Label1.Text = "Invoice_Register_Summary_Printing_ACCOUNT" Then
        '    Invoice_Register_Summary_Printing.ACCOUNT_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_Register_Summary_Printing_AGENT" Then
        '    Invoice_Register_Summary_Printing.AGENT_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_Register_Summary_Printing_QUALITY" Then
        '    Invoice_Register_Summary_Printing.QUALITY_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_Register_Summary_Printing_CITY" Then
        '    Invoice_Register_Summary_Printing.CITY_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_Register_Summary_Printing_STATE" Then
        '    Invoice_Register_Summary_Printing.STATE_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "Invoice_Register_Summary_Printing_CUT_WISE" Then
        '    Invoice_Register_Summary_Printing.CUT_CODE.Text = "( " + name_code + " )"
        'ElseIf Label1.Text = "TB_Printing_AGENT" Then
        '    TB_Printing.ACCOUNT_CODE.Text = "( " + name_code + " )"


        'End If
    End Sub
    Private Sub Multy_Challan_Printing()
        If Label1.Text = "Challan_Printing_multy_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1

                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        'name_code = "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = "A.BOOKVNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    Else
                        'name_code = CODE + "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = CODE + "A.BOOKVNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Grey_Challan_Printing.BOOKVNO.Text = name_code
            Exit Sub
        End If
    End Sub
    Private Sub Grey_Process_Multy_Challan_Printing()
        If Label1.Text = "Grey_Process_Challan_Printing_multy_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1

                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        'name_code = "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = "TFR.BOOKVNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    Else
                        'name_code = CODE + "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = CODE + "TFR.BOOKVNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Process_Challan_Printing.BOOKVNO.Text = name_code
            Exit Sub
        End If
    End Sub
    Private Sub Multy_Party_Bill_Printing()
        If Label1.Text = "Invoice_Bill_Printing_multy_party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1

                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        'name_code = "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = "TIH.ENTRYNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    Else
                        'name_code = CODE + "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = CODE + "TIH.ENTRYNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Offer_Printing.lblentryno.Text = name_code
            Exit Sub
        End If
    End Sub
    Private Sub Multy_Agent_Bill_Printing()
        If Label1.Text = "Invoice_Bill_Printing_multy_Agent" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1

                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        'name_code = "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = "TIH.ENTRYNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    Else
                        'name_code = CODE + "trnGrey.EntryNo='" + CStr(dgw.Rows(j).Cells(4).Value + "'")
                        name_code = CODE + "TIH.ENTRYNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Offer_Printing.lblentryno.Text = name_code
            Exit Sub
        End If
    End Sub
    Private Sub Multy_Packing_Slip_Bill_Printing()
        If Label1.Text = "Packing_Slip_Bill_Printing_multy_Party" Then
            Dim name_list As String = ""
            Dim name_code As String = ""
            Dim CODE As String = ""
            For j As Integer = 0 To dgw.RowCount - 1

                If dgw(0, j).Value = 1 Then

                    If name_code = Nothing Then
                        name_code = "packSlip.ENTRYNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    Else
                        name_code = CODE + "packSlip.ENTRYNO='" + ((dgw.Rows(j).Cells(4).Value).ToString + "'")
                    End If
                End If
                CODE = name_code + " OR "
            Next
            'Offer_Printing.lblentryno.Text = name_code
            Exit Sub
        End If
    End Sub
#End Region




#Region " Grid Searching"
    Private Sub Party_selection_multy_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            pnl_Filter_Working.Visible = True
            lbl_Filter_Header.Text = "Enter " & String_To_Proper(dgw.Columns(2).Name)
            pnl_Filter_Working.BringToFront()
            txt_Filter_Text.Focus()
            txt_Filter_Text.Select()
            e.Handled = True
        End If
    End Sub

    Private Sub txt_Filter_Text_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Filter_Text.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_Filter_Text.Text <> "" Then
                _CityFilterTrue = True
                Dim Tmp_Tbl As New DataTable
                Tmp_Tbl = DefaltSoftTable.Clone
                Dim Col_Name_1 As String = "[" & dgw.Columns(0).Name & "]"
                Dim Col_Name_2 As String = "[" & dgw.Columns(2).Name & "]"
                Dim Total_Row As Integer = 0
                Dim Filter_Con As String = "(" & Col_Name_2 & " LIKE '" & txt_Filter_Text.Text & "*')"
                For Each dr As DataRow In DefaltSoftTable.Select(Filter_Con, Col_Name_2)
                    Tmp_Tbl.ImportRow(dr)
                    Total_Row = Total_Row + 1
                Next
                If Total_Row > 0 Then
                    TextBox1.Text = ""
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


#End Region


End Class