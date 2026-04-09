Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout.Customization
Imports FlexCell

Public Class ReportForm
    Private _DatabaseTableName = "FormControl"
    Dim _MainColumTbl As New DataTable
    Public Property FormNameValue As String
    Private _FORMMODE As String = ""
    Dim tmptbl As New DataTable
    Dim _Bookcode As String = ""
    Private isMoveMode As Boolean = False
    Dim isDragging As Boolean = False
    Dim _TblName As String = ""
    Dim FormId As String = "0"
    Dim Id As String = "0"
    Private selectedCtrl As Control = Nothing
    Dim dragOffset As Point
    Public ReportFormLoadFormName As String = ""
    Dim _FormCloseMode As Boolean = False
    Dim Txt_ViewFrom As New ctl_TextBox.ctl_TextBox()
    Dim Txt_ViewTO As New ctl_TextBox.ctl_TextBox()
    Dim Txt_EntryNo As New ctl_TextBox.ctl_TextBox()
    Dim GetformName As String = ""
    Public Property _SeletedFormName As String
    Public _SeletedReportType As String

    Public Property GridViewType As String


    'Private masterListcode1 As New List(Of Tuple(Of String, String, String))
    'Private masterListcode2 As New List(Of Tuple(Of String, String, String))
    'Private masterListcode3 As New List(Of Tuple(Of String, String, String))
    'Private masterListcode4 As New List(Of Tuple(Of String, String, String))
    'Private masterListcode5 As New List(Of Tuple(Of String, String, String))
    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)

        Txt_ViewFrom.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        Txt_ViewTO.Text = Main_MDI_Frm.FINE_YEAR_END.Text
        'Txt_ViewTO.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        _LoadDefaultData()
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub _LoadDefaultData()
        View_Record()
        Dim formType As String = ""
        If _MainColumTbl.Rows.Count > 0 Then
            formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            FormNameValue = _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        FormNameValue = _getformName()
        _SeletedFormName = _getformName()
        If formType = "REPORT" Then
            LoadViewData(tmptbl)
        End If
        isMoveMode = False
        isDragging = False
    End Sub
    Public Sub LoadViewData(ByVal tmptbl As DataTable)
        'RS = DefaltReportLoad()
        Dim _Tblclon As New DataTable
        sqL = DefaltReportLoad()
        sql_connect_slect()
        'ReportsMenu_QueryLoad()
        _Tblclon = DefaltSoftTable.Copy
        SelectionGrid.Columns.Clear()
        SelectionGridControl.DataSource = _Tblclon
        _FormGridSetting()
    End Sub
    Private Sub _FormGridSetting()
        Try
            _DevGridColumSizeAutoAdjest(SelectionGridControl, SelectionGrid)
            SelectionGrid.Appearance.Row.Font = New Font("Verdana", 9, FontStyle.Bold)
            SelectionGrid.RowHeight = 30
            SelectionGrid.Columns("MainMasterId").Visible = False
            SelectionGrid.Columns("ReportsCountNo").Visible = False
            SelectionGrid.Columns("SettingType").Visible = False
            SelectionGrid.Columns("ActiveStatus").Visible = False
            SelectionGrid.Columns("ReportFormName").Visible = False
            SelectionGrid.Columns("ReportRptFileName").Visible = False
            SelectionGrid.Columns("QueryFileName").Visible = False
            SelectionGrid.Columns("QueryFullFileName").Visible = False
            SelectionGrid.Columns("MasterSelectionList").Visible = False
            SelectionGrid.Columns("SrNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            SelectionGrid.Columns("SrNo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            For Each Col As DevExpress.XtraGrid.Columns.GridColumn In SelectionGrid.Columns
                Col.AppearanceHeader.BackColor = Color.DarkGreen   'PrimaryDataGridViewColumnHeaderBackColor
                Col.AppearanceHeader.BackColor2 = Color.DarkGreen
                Col.AppearanceHeader.Options.UseForeColor = True
                Col.AppearanceHeader.Options.UseBackColor = True
                Col.AppearanceHeader.Font = New Font("Verdana", 9, FontStyle.Bold)
            Next
            SelectionGrid.Columns("SrNo").Width = 25
            SelectionGrid.Columns("Reports").Width = 230
            SelectionGrid.OptionsSelection.EnableAppearanceFocusedRow = True
            SelectionGrid.OptionsSelection.EnableAppearanceFocusedCell = False
            SelectionGrid.Appearance.FocusedRow.BackColor = Color.Orange
            SelectionGrid.Appearance.FocusedRow.ForeColor = Color.Black
            SelectionGrid.Appearance.FocusedRow.Options.UseBackColor = True
            SelectionGrid.Appearance.FocusedRow.Options.UseForeColor = True

            SelectionGrid.OptionsView.ShowIndicator = False
            SelectionGrid.OptionsFind.AlwaysVisible = False
            SelectionGrid.OptionsView.ShowGroupPanel = False
            ' Column width auto fit करने के लिए:
            SelectionGrid.OptionsView.ColumnAutoWidth = True
            ' Horizontal scroll को disable करने के लिए:
            SelectionGrid.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function DefaltReportLoad()
        Dim _Query = New StringBuilder
        With _Query
            .Append("SELECT ")
            .Append(" Schedule_id as MainMasterId")
            .Append(",Group_master_finance as ReportsCountNo")
            .Append(",Main_account_master as SrNo")
            .Append(",STATEMASTER as Reports")
            .Append(",CITYMASTER as ActiveStatus ")
            .Append(",TRANSPORT_MASTER as SettingType ")
            .Append(",MSTCUTMASTER as ReportFormName ")
            .Append(",MSTFABRICMASTER as ReportRptFileName")
            .Append(",MSTFABRICHEAD as QueryFileName")
            .Append(",MSTFABRICGROUP as QueryFullFileName")
            .Append(",MSTYARNMASTER as MasterSelectionList")
            .Append(" FROM Vch_no ")
            .Append(" WHERE 1=1 ")
            .Append(" AND MSTCUTMASTER = '" & _SeletedFormName & "' ")
            .Append(" AND TRANSPORT_MASTER = 'ReportSelection' ")
            .Append(" ORDER by CAST(Main_account_master AS INT)  ")
        End With
        Return _Query.ToString
    End Function

    Private Sub View_Record()
        Try
            Dim EntryNo As Integer = 1
            Dim _Grid1ColNames = New StringBuilder()
            Dim View_Filter_Condition = " AND  FormName='" & ReportFormLoadFormName & "' "
            If ReportFormLoadFormName <> "" Then
                If _MainColumTbl.Rows.Count > 0 Then
                    For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                        Dim Name As String = dr("CntrlName").ToString()
                        RemoveControlIfExists(Name)
                        RemoveControlIfExists("Lbl_" & Name)
                    Next
                End If
                _strQuery = New StringBuilder
                With _strQuery
                    .Append("Select * FROM " & _DatabaseTableName & " WHERE 1=1 ")
                    .Append(View_Filter_Condition)
                End With
                RS = _strQuery.ToString
                MenuDesign_QueryLoad()
                _MainColumTbl = DefaltSoftTable.Copy
#Region "Label or text box control visible form view"
                Dim _CntlMasterTabl As New DataTable
                _CntlMasterTabl = _MainColumTbl.Clone
                Dim topPos As Integer
                'Dim topPos As Integer = 20
                Dim leftPos As Integer
                Dim height As Integer
                Dim width As Integer
                For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                    Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
                    Dim usemasterkey As String = dr("USEMASTERKEY").ToString
                    Dim colType As String = dr("ColumnType").ToString()
                    Dim HeaderName As String = dr("UserText").ToString()
                    Dim Name As String = dr("CntrlName").ToString()
                    Dim visible As String = dr("Visible").ToString()
                    Dim Tabindex As Int64 = dr("Tabindex").ToString()
                    _Bookcode = dr("Bookcode").ToString()
                    Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                    _TblName = dr("DataBaseTable").ToString()
                    Dim formtype As String = ""
                    formtype = dr("FormType").ToString().Trim()
                    If formtype = "REPORT" Then
                    Else
                    End If
                    Dim Tag As String = dr("DataBaseColumn").ToString()
                    Dim oppMasterCode As String = dr("OppMasterCode").ToString()
                    Dim _Readonly As String = dr("ReadOnly").ToString()
                    FormId = dr("FormId").ToString()
                    Id = dr("Id").ToString()
                    If HeaderName > "" Then
                        leftPos = Convert.ToInt32(dr("LocationX"))
                        topPos = Convert.ToInt32(dr("LocationY"))
                        width = Convert.ToInt32(dr("SizeWidth"))
                        height = Convert.ToInt32(dr("SizeHeight"))
                        Dim lbl As New Label()
                        lbl.Name = "Lbl_" & Name
                        lbl.Text = HeaderName
                        If visible = "N" Then
                            lbl.Visible = False
                        Else
                            lbl.Visible = True
                        End If
                        If leftPos < 0 Then
                            'lbl.Left = Math.Max(5, leftPos)
                            lbl.Left = leftPos
                        Else
                            lbl.Left = leftPos
                        End If
                        lbl.Top = topPos
                        lbl.Width = 80   ' 🔒 fixed width for all labels
                        lbl.TextAlign = ContentAlignment.MiddleLeft
                        lbl.AutoSize = True
                        Me.Controls.Add(lbl)
                        AddHandler lbl.MouseDown, AddressOf Control_MouseDown
                        AddHandler lbl.MouseMove, AddressOf Control_MouseMove
                        AddHandler lbl.MouseUp, AddressOf Control_MouseUp
                        If colType = "TextBox" AndAlso visible = "Y" Then
                            Dim LblSize As Int16 = lbl.Width
                            'Dim txt As New TextBox()
                            Dim txt As New ctl_TextBox.ctl_TextBox()
                            txt.Name = Name
                            txt.Left = leftPos + 120
                            txt.Top = topPos
                            txt.Width = width
                            txt.Height = height
                            txt.Tag = Tag
                            txt.TabIndex = Tabindex
                            If _Readonly = "Y" Then
                                txt.ReadOnly = True
                            Else
                                txt.ReadOnly = False
                            End If
                            Me.Controls.Add(txt)
                            'If txt.TabIndex = 1 Then
                            '    txt.Focus()
                            '    SelectionGridControl.Focus()
                            'End If
                            If formtype = "REPORT" Then
                                If _InputType = "DateBox" Then
                                    If txt.Text.Trim() = "" Then
                                        If HeaderName.ToUpper().Contains("FROM") Then
                                            txt.Text = Main_MDI_Frm.FINE_YEAR_START.Text
                                            txt.ReadOnly = True
                                        ElseIf HeaderName.ToUpper().Contains("TO") Then
                                            txt.Text = Main_MDI_Frm.FINE_YEAR_END.Text
                                            txt.ReadOnly = True
                                        End If
                                    End If
                                    txt.MaxLength = 10
                                    'txt.Text = Today.ToString("dd/MM/yyyy")
                                    AddHandler txt.KeyPress, AddressOf DateBox_KeyPress
                                    AddHandler txt.Leave, AddressOf DateBox_Validate

                                End If

                                If _InputType = "Normal" Or _InputType = "Numeric" Then
                                    If txt.Text.Trim() = "" Then
                                        If HeaderName.ToUpper().Contains("ENTRYNO") Then
                                            'txt.Text = Txt_EntryNo.Text
                                            'txt.ReadOnly = True
                                        End If
                                    End If
                                End If

                                If _InputType = "SpacerType" Then
                                    'If Tabindex = 3 Then
                                    txt.InputType = 10 '"SpacerType"
                                        txt.SpacerString = dr("SpacerString").ToString().ToUpper
                                    'txt.Text = "YES"
                                    'End If
                                End If
                            Else
                            End If
                            AddHandler txt.MouseDown, AddressOf Control_MouseDown
                            AddHandler txt.MouseMove, AddressOf Control_MouseMove
                            AddHandler txt.MouseUp, AddressOf Control_MouseUp
                            AddHandler txt.KeyDown, AddressOf Control_KeyDown
                        End If
                        topPos += 35
                    End If
                Next
#End Region
                BtnUpdatepos.Enabled = True
                btnmovecontrol.Enabled = True

            Else
                BtnUpdatepos.Enabled = False
                btnmovecontrol.Enabled = False

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub DateBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        ' Sirf digit allow
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Exit Sub
        End If
        Dim txtBox As TextBox = DirectCast(sender, TextBox)

        ' Backspace allow
        If e.KeyChar = ChrW(Keys.Back) Then Exit Sub
        ' Max length 10 (DD/MM/YYYY)
        If txtBox.SelectionStart >= 10 Then
            e.Handled = True
            Exit Sub
        End If
        ' Overwrite Mode
        Dim pos As Integer = txtBox.SelectionStart
        ' Slash position skip kare
        If pos = 2 Or pos = 5 Then
            pos += 1
            txtBox.SelectionStart = pos
        End If
        txtBox.Text = txtBox.Text.Remove(pos, 1).Insert(pos, e.KeyChar)
        txtBox.SelectionStart = pos + 1
        e.Handled = True
    End Sub
    Private Sub DateBox_Validate(sender As Object, e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim dt As DateTime
        If DateTime.TryParseExact(txt.Text, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, dt) Then
            txt.Text = dt.ToString("dd/MM/yyyy")
        Else
            MessageBox.Show("Invalid Date. Enter valid date in DD/MM/YYYY format.")
            txt.Focus()
        End If
    End Sub

    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        Dim ctrl As Control = TryCast(sender, Control)
        If ctrl Is Nothing Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim ActivetextName As String = ctrl.Text
            Me.SelectNextControl(ctrl, True, True, True, True)
        ElseIf e.KeyCode = Keys.Up Then
            Dim ActivetextName As String = ctrl.Text
            Me.SelectNextControl(DirectCast(sender, Control), False, True, True, True)
        ElseIf e.KeyCode = Keys.Down Then
            Dim ActivetextName As String = ctrl.Text
            Me.SelectNextControl(ctrl, True, True, True, True)
        End If
    End Sub
    Private Sub RemoveControlIfExists(ctrlName As String)

        Dim oldCtrl As Control = Me.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Name = ctrlName)
        If oldCtrl IsNot Nothing Then
            Me.Controls.Remove(oldCtrl)
            oldCtrl.Dispose()
        End If
    End Sub
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If Not isMoveMode Then Exit Sub   ' ❌ move disabled
        isDragging = True
        selectedCtrl = DirectCast(sender, Control)
        dragOffset = e.Location
        If e.Button = MouseButtons.Left Then
            selectedCtrl = DirectCast(sender, Control)
            PropertyGrid1.SelectedObject = selectedCtrl
        End If
    End Sub
    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        If Not isMoveMode OrElse Not isDragging Then Exit Sub

        Dim ctrl As Control = DirectCast(sender, Control)
        ctrl.Left += e.X - dragOffset.X
        ctrl.Top += e.Y - dragOffset.Y
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        If Not isMoveMode Then Exit Sub
        isDragging = False
        SaveControlPosition(DirectCast(sender, Control))
    End Sub
    Private Sub SaveControlPosition(ctrl As Control)

        If ctrl Is Nothing Then Exit Sub
        Dim leftPos As Integer = ctrl.Left - 120
        Dim topPos As Integer = ctrl.Top
        Dim height As Integer = ctrl.Height
        Dim width As Integer = ctrl.Width
        Dim ctrlName As String = ctrl.Name
        Dim Tabindex As Integer = ctrl.TabIndex
        updatepossition(leftPos, topPos, height, width, ctrlName, Tabindex, FormId, Id)
    End Sub
    Private Sub updatepossition(ByVal leftpos As String, ByVal topPos As String, ByVal Height As String, ByVal Width As String, ByVal ctrlName As String, ByVal Tabindex As String, ByVal FormId As String, ByVal Id As String)
        _strQuery = New StringBuilder
        Try
            strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & ",TabIndex=" & Tabindex & "  WHERE CntrlName='" & ctrlName & "' and FormId=" & FormId & ""
            RS = strQuery.ToString
            MenuDesign_QueryLoad()
        Catch ex As Exception
            MsgBox("Error While update Entry")
        Finally
            cmd = Nothing
        End Try
    End Sub
    Public Function _getformName() As String
        If _MainColumTbl IsNot Nothing AndAlso _MainColumTbl.Rows.Count > 0 Then
            Return _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        Return ""
    End Function

    Private Sub ReportForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If PropertyGrid1.Visible = True Then
                PropertyGrid1.Visible = False
            End If
            If _FormCloseMode = False Then
                _FormCloseMode = True
                'Exit Sub
            End If
            If MsgBox("Do You Want To Close(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Close ?") = MsgBoxResult.Yes Then
                If _FormCloseMode = True Then
                    Me.Close()
                    Me.Dispose(True)
                End If
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            btnmovecontrol.Visible = True
            BtnUpdatepos.Visible = True
        ElseIf e.KeyCode = Keys.F4 Then
            PropertyGrid1.Visible = True
            If PropertyGrid1.SelectedObject Is Nothing AndAlso Me.ActiveControl IsNot Nothing Then
                PropertyGrid1.SelectedObject = Me.ActiveControl
            End If
        ElseIf Control.ModifierKeys = Keys.Control AndAlso e.KeyCode = Keys.F2 Then
            _PasswardWindow = ""
            Passward_Checker.ShowDialog()
            If _PasswardWindow <> _UserReportPassword Then
                MsgBox("Invalid Password.", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            End If
            ReportsSelectionSettingForm._SelectedFormName = Me._getformName()
            ReportsSelectionSettingForm.ShowDialog()
        End If
    End Sub

    Private Sub btnmovecontrol_Click(sender As Object, e As EventArgs) Handles btnmovecontrol.Click
        isMoveMode = True
        If isMoveMode = False Then
            'MessageBox.Show("Move mode enabled. Drag any control.")
            PropertyGrid1.Visible = False
        End If
        If isMoveMode Then
            PropertyGrid1.Visible = True

            If PropertyGrid1.SelectedObject Is Nothing AndAlso Me.ActiveControl IsNot Nothing Then
                PropertyGrid1.SelectedObject = Me.ActiveControl
            End If
        Else
            PropertyGrid1.Visible = False
        End If
        Ctrl_Visible_True(Me.Controls)
    End Sub

    Private Sub BtnUpdatepos_Click(sender As Object, e As EventArgs) Handles BtnUpdatepos.Click
        For Each ctrl As Control In Me.Controls
            ' sirf required controls
            If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox Then
                SaveControlPosition(ctrl)
            End If
        Next
        isMoveMode = False
        isDragging = False
        Ctrl_Visible_True(Me.Controls)
        PropertyGrid1.Visible = False
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        _FORMMODE = "VIEW"
        Dim valtype As Object = SelectionGrid.GetFocusedRowCellValue("Reports")
        Dim valreportName As Object = SelectionGrid.GetFocusedRowCellValue("ReportRptFileName")
        Dim valmasterlist As Object = SelectionGrid.GetFocusedRowCellValue("MasterSelectionList")
        Dim valueMainmasterId As Integer = SelectionGrid.GetFocusedRowCellValue("MainMasterId")
        Dim str As String = valmasterlist.ToString()
        Dim arr() As String = str.Split(","c)
        For Each item As String In arr
            'MsgBox(item.Trim())
            item.Trim()
        Next
        'tmptbl = _GetFormQuery(FormNameValue, valtype)
        tmptbl = _GetFormQueryReport(FormNameValue, valtype, valueMainmasterId)
        Generate_Date_For_DataBase(Txt_ViewFrom)
        Generate_Date_For_DataBase(Txt_ViewTO)
        Dim filterfrom As String = "'" & Txt_ViewFrom.Date_for_Database & "'"
        Dim filterto As String = " '" & Txt_ViewTO.Date_for_Database & "'"
        'Dim Entryno As Integer = " " & Txt_EntryNo.Text & "  "
        Dim filterMasterlist1 As String = ""
            Dim filterMasterlist2 As String = ""
            Dim filterMasterlist3 As String = ""
            Dim filterMasterlist4 As String = ""
            Dim filterMasterlist5 As String = ""
            ' 🔹 queries read
            Dim viewquery As String = GetQuery(tmptbl, "REPORTQUERY", valtype)
        If viewquery = "" Then
            If ReportFormLoadFormName = "" Then
                Exit Sub
            Else
                MsgBox("view query not found")
                Exit Sub
            End If
        End If

        viewquery = viewquery.Replace("FilterFrom", filterfrom)
        viewquery = viewquery.Replace("FilterTO", filterto)
        'viewquery = viewquery.Replace("EntryNo", Entryno)
        Dim inClausefilterMasterlist1 As String = ""
        If arr.Length > 0 AndAlso arr(0).Trim() <> "" Then
            filterMasterlist1 = arr(0).Replace("'", "").Trim()
            ' Master list display
            masterListcode1.Clear()
            HandleMultipleMasterSelection(filterMasterlist1, "MULTY")
            Dim cleanListfilterMasterlist1 = masterListcode1.Select(Function(t) "'" & t.Item1.Replace("'", "").Trim() & "'").Where(Function(x) x <> "''")
            inClausefilterMasterlist1 = String.Join(",", cleanListfilterMasterlist1)
            If String.IsNullOrWhiteSpace(inClausefilterMasterlist1) Then
                inClausefilterMasterlist1 = "()"
                Exit Sub
            End If
            viewquery = viewquery.Replace("FilterMasterlist1", "(" & inClausefilterMasterlist1 & ")")
        Else
            viewquery = viewquery.Replace("FilterMasterlist1", "('" & inClausefilterMasterlist1 & "')")
        End If
        Dim inClausefilterMasterlist2 As String = ""
        If arr.Length > 1 AndAlso arr(1).Trim() <> "" Then
            filterMasterlist2 = arr(1).Replace("'", "").Trim()
            masterListcode2.Clear()
            HandleMultipleMasterSelection(filterMasterlist2, "MULTY")
            Dim cleanListfilterMasterlist2 = masterListcode2.Select(Function(t) "'" & t.Item1.Replace("'", "").Trim() & "'").Where(Function(x) x <> "''")
            inClausefilterMasterlist2 = String.Join(",", cleanListfilterMasterlist2)

            If String.IsNullOrWhiteSpace(inClausefilterMasterlist2) Then
                inClausefilterMasterlist2 = "()"
                Exit Sub
            End If
            viewquery = viewquery.Replace("FilterMasterlist2", "(" & inClausefilterMasterlist2 & ")")
        Else
            viewquery = viewquery.Replace("FilterMasterlist2", "('" & inClausefilterMasterlist2 & "')")
        End If
        Dim inClausefilterMasterlist3 As String = ""
        If arr.Length > 2 AndAlso arr(2).Trim() <> "" Then
            filterMasterlist3 = arr(2).Replace("'", "").Trim()
            masterListcode3.Clear()
            HandleMultipleMasterSelection(filterMasterlist3, "MULTY")
            Dim cleanListfilterMasterlist3 = masterListcode3.Select(Function(t) "'" & t.Item1.Replace("'", "").Trim() & "'").Where(Function(x) x <> "''")
            inClausefilterMasterlist3 = String.Join(",", cleanListfilterMasterlist3)

            If String.IsNullOrWhiteSpace(inClausefilterMasterlist3) Then
                inClausefilterMasterlist3 = "()"
                Exit Sub
            End If
            viewquery = viewquery.Replace("FilterMasterlist3", "(" & inClausefilterMasterlist3 & ")")
        Else
            viewquery = viewquery.Replace("FilterMasterlist3", "('" & inClausefilterMasterlist3 & "')")
        End If
        Dim inClausefilterMasterlist4 As String = ""
        If arr.Length > 3 AndAlso arr(3).Trim() <> "" Then
            filterMasterlist4 = arr(3).Replace("'", "").Trim()
            masterListcode4.Clear()
            HandleMultipleMasterSelection(filterMasterlist4, "MULTY")
            Dim cleanListfilterMasterlist4 = masterListcode4.Select(Function(t) "'" & t.Item1.Replace("'", "").Trim() & "'").Where(Function(x) x <> "''")
            inClausefilterMasterlist4 = String.Join(",", cleanListfilterMasterlist4)

            If String.IsNullOrWhiteSpace(inClausefilterMasterlist4) Then
                inClausefilterMasterlist4 = "()"
                Exit Sub
            End If
            viewquery = viewquery.Replace("FilterMasterlist4", "(" & inClausefilterMasterlist4 & ")")
        Else
            viewquery = viewquery.Replace("FilterMasterlist4", "('" & inClausefilterMasterlist4 & "')")
        End If
        Dim inClausefilterMasterlist5 As String = ""
        If arr.Length > 4 AndAlso arr(4).Trim() <> "" Then
            filterMasterlist5 = arr(4).Replace("'", "").Trim()
            masterListcode5.Clear()
            HandleMultipleMasterSelection(filterMasterlist5, "MULTY")
            Dim cleanListfilterMasterlist5 = masterListcode5.Select(Function(t) "'" & t.Item1.Replace("'", "").Trim() & "'").Where(Function(x) x <> "''")
            inClausefilterMasterlist5 = String.Join(",", cleanListfilterMasterlist5)

            If String.IsNullOrWhiteSpace(inClausefilterMasterlist5) Then
                inClausefilterMasterlist5 = "()"
                Exit Sub
            End If
            viewquery = viewquery.Replace("FilterMasterlist5", "(" & inClausefilterMasterlist5 & ")")
        Else
            viewquery = viewquery.Replace("FilterMasterlist5", "('" & inClausefilterMasterlist5 & "')")
        End If

        sqL = viewquery
            sql_connect_slect()
            Dim resulttable As New DataTable
        resulttable = DefaltSoftTable.Copy
        Dim txt As New ctl_TextBox.ctl_TextBox()
        If resulttable.Rows.Count > 0 Then
            If TabIndex = 1 Then
                txt.Text = resulttable.Rows(0)("EntryNo").ToString()
            End If
            REPORT_RPT_FILE_NAME = valreportName
            Dim RptTitle = valtype
            Dim Date_Range = "Date From:" & Txt_ViewFrom.Text & " To:" & Txt_ViewTO.Text & " "
            NewReportPrint(resulttable, RptTitle, Date_Range)
        Else
            MsgBox("record not found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            MasterMenuLoad.RestoreMenuFocus(Me.Tag, MasterMenuLoad.MenuStrip1)
        End If
    End Sub

    Private Sub SelectionGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles SelectionGrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnView.Focus()
        End If
    End Sub

    Private Sub SelectionGrid_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles SelectionGrid.FocusedRowChanged
        Dim rowHandle As Integer = SelectionGrid.FocusedRowHandle
        ' 👉 Example: current row value
        Dim val = SelectionGrid.GetRowCellValue(rowHandle, "Reports")
    End Sub
End Class