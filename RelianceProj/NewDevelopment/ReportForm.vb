Imports System.Text
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.SqlServer.Management.Sdk.Sfc

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
    Dim GetformName As String = ""
    Public _SeletedFormName As String
    Public _SeletedReportType As String
    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        Txt_ViewFrom.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        Txt_ViewTO.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        _LoadDefaultData()
        'GridControl1.Width = 974
        'GridControl1.Height = 595
        GridControl1.Location = New Point(5, 60)
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
            'If _FORMMODE = "VIEW" Then
            tmptbl = _GetFormQuery(FormNameValue, "VIEW")
            LoadViewData(tmptbl, _Bookcode)
            'End If
        End If
        isMoveMode = False
        isDragging = False
    End Sub
    Public Sub LoadViewData(ByVal tmptbl As DataTable, ByVal _Bookcode As String)
        'RS = DefaltReportLoad()
        Dim _Tblclon As New DataTable
        sqL = DefaltReportLoad()
        sql_connect_slect()
        'ReportsMenu_QueryLoad()
        _Tblclon = DefaltSoftTable.Copy
        GridControl1.DataSource = _Tblclon
        FirstStage.Appearance.HeaderPanel.Font = New Font("Verdana", 9, FontStyle.Bold)
        FirstStage.Appearance.Row.Font = New Font("Verdana", 8, FontStyle.Bold)
        FirstStage.RowHeight = 25
        'FirstStage.Columns("MainMasterId").Visible = False
        'FirstStage.Columns("ReportsCountNo").Visible = False
        'FirstStage.Columns("SettingType").Visible = False
        'FirstStage.Columns("ActiveStatus").Visible = False
        'FirstStage.Columns("ReportFormName").Visible = False
        'FirstStage.Columns("ReportRptFileName").Visible = False
        'FirstStage.Columns("QueryFileName").Visible = False
        'FirstStage.Columns("QueryFullFileName").Visible = False
        'FirstStage.Columns("MasterSelectionList").Visible = False

        'FirstStage.Columns("MainMasterId").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("ReportsCountNo").OptionsColumn.AllowEdit = False
        FirstStage.Columns("SrNo").OptionsColumn.AllowEdit = False
        FirstStage.Columns("Reports").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("ActiveStatus").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("SettingType").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("ReportFormName").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("ReportRptFileName").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("QueryFileName").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("QueryFullFileName").OptionsColumn.AllowEdit = False
        'FirstStage.Columns("MasterSelectionList").OptionsColumn.AllowEdit = False
        FirstStage.BestFitColumns()
        FirstStage.Columns("SrNo").Width = 10
        FirstStage.Columns("Reports").Width = 180
        FirstStage.Columns("SrNo").AppearanceHeader.BackColor = Color.Green
        FirstStage.Columns("SrNo").AppearanceHeader.Options.UseBackColor = True
        FirstStage.Columns("Reports").AppearanceHeader.BackColor = Color.Green
        FirstStage.Columns("Reports").AppearanceHeader.Options.UseBackColor = True

        FirstStage.OptionsSelection.EnableAppearanceFocusedRow = True
        FirstStage.OptionsSelection.EnableAppearanceFocusedCell = False
        FirstStage.Appearance.FocusedRow.BackColor = Color.Orange
        FirstStage.Appearance.FocusedRow.ForeColor = Color.Black
        FirstStage.Appearance.FocusedRow.Options.UseBackColor = True
        FirstStage.Appearance.FocusedRow.Options.UseForeColor = True

    End Sub
    Private Sub FirstStage_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles FirstStage.FocusedRowChanged
        Dim rowHandle As Integer = FirstStage.FocusedRowHandle
        ' 👉 Example: current row value
        Dim val = FirstStage.GetRowCellValue(rowHandle, "Reports")

    End Sub
    Public Function DefaltReportLoad()
        Dim _Query = New StringBuilder
        'With _Query
        '    .Append("SELECT ")
        '    .Append(" MainMasterId")
        '    .Append(",ReportsCountNo")
        '    .Append(",ReportsOrderNo as SrNo")
        '    .Append(",ReportMenuName as Reports")
        '    .Append(",ActiveStatus ")
        '    .Append(",SettingType ")
        '    .Append(",ReportFormName ")
        '    .Append(",ReportRptFileName")
        '    .Append(",QueryFileName")
        '    .Append(",QueryFullFileName")
        '    .Append(",MasterSelectionList")
        '    .Append(" FROM Reports ")
        '    .Append(" WHERE 1=1 ")
        '    .Append(" AND ReportFormName = '" & _SeletedFormName & "' ")
        '    .Append(" AND SettingType = 'ReportSelection' ")
        '    .Append(" ORDER by ReportsOrderNo ")
        'End With

        With _Query
            .Append("SELECT ")
            .Append("Main_account_master as SrNo")
            .Append(",STATEMASTER as Reports")
            '.Append(",CITYMASTER ")
            .Append(" FROM Vch_no ")
            .Append(" WHERE 1=1 ")
            .Append(" AND MSTCUTMASTER = '" & _SeletedFormName & "' ")
            .Append(" AND TRANSPORT_MASTER = 'ReportSelection' ")
            .Append(" ORDER by Main_account_master ")
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
                    'For Each dr As DataRow In _MainColumTbl.Select("CntrlId <> ''")
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
                'sqL = _strQuery.ToString
                'sql_connect_slect1()
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
                            txt.Left = leftPos + 100
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
                            If txt.TabIndex = 1 Then
                                'txt.Focus()
                                GridControl1.Focus()
                            End If
                            If Tabindex = 1 Then
                                txt.Text = Main_MDI_Frm.FINE_YEAR_START.Text
                                'Generate_Date_For_DataBase(txt)
                            ElseIf Tabindex = 2 Then
                                txt.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                                'Generate_Date_For_DataBase(txt)
                            End If
                            If formtype = "REPORT" Then
                                If _InputType = "DateBox" Then
                                    txt.MaxLength = 10
                                    'txt.Text = Today.ToString("dd/MM/yyyy")
                                    AddHandler txt.KeyPress, AddressOf DateBox_KeyPress
                                    AddHandler txt.Leave, AddressOf DateBox_Validate
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
            'RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)
            'Me.SelectNextControl(ctrl.Tag, True, True, True, True)
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
        Dim leftPos As Integer = ctrl.Left - 100
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
            If _FORMMODE = "VIEW" Then

                Exit Sub
            ElseIf _FormCloseMode = False Then
                _FormCloseMode = True
                Exit Sub
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
            'ReportsSelectionSettingForm._SeletedFormName = Me.Name.ToString
            ReportsSelectionSettingForm._SeletedFormName = Me._getformName()
            ReportsSelectionSettingForm.ShowDialog()
        End If

        'If e.KeyCode = Keys.F2 Then
        'Dim reportloadquery As New ReportQueryLoad()
        '    reportloadquery.GetformName = Me._getformName()
        '    reportloadquery.Show()
        'End If
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
        '_LoadDefaultData()


        'FirstStage.Columns("QueryFileName").Width = 50
        'Generate_Date_For_DataBase(Txt_ViewFrom)
        'Generate_Date_For_DataBase(Txt_ViewTO)
        ''Dim FilterBookcode As String = " '" & _Bookcode & "' "
        'Dim FilterFrom As String = "'" & Txt_ViewFrom.Date_for_Database & "'"
        'Dim FilterTO As String = " '" & Txt_ViewTO.Date_for_Database & "'"
        '' 🔹 Queries Read
        'Dim ViewQuery As String = GetQuery(tmptbl, "VIEWQUERY", "VIEW")
        'If ViewQuery = "" Then
        '    If ReportFormLoadFormName = "" Then
        '        Exit Sub
        '    Else
        '        MsgBox("View Query Not Found")
        '        Exit Sub
        '    End If
        'End If
        ''ViewQuery = ViewQuery.Replace("FilterBookcode", FilterBookcode)
        'ViewQuery = ViewQuery.Replace("FilterFrom", FilterFrom)
        'ViewQuery = ViewQuery.Replace("FilterTO", FilterTO)
        'sqL = ViewQuery
        'sql_connect_slect()
        'Dim ResultTable As New DataTable
        'ResultTable = DefaltSoftTable.Copy
        'FirstStage.Columns.Clear()
        'If ResultTable.Rows.Count > 0 Then
        '    GridControl1.DataSource = ResultTable.Copy
        '    DevGridFitColumn(GridControl1, FirstStage)
        '    FirstStage.OptionsView.ShowFooter = True
        '    Dim ViewQueryTotal As String = GetQuery(tmptbl, "ViewGridColumnTotal", "VIEW")
        '    Dim ColumnList As String = ViewQueryTotal
        '    Dim Columns() As String = ColumnList.Split(","c)
        '    For Each col As String In Columns
        '        If FirstStage.Columns.ColumnByFieldName(col) IsNot Nothing Then
        '            'Total
        '            FirstStage.Columns(col).Summary.Clear()
        '            FirstStage.Columns(col).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col, "{0:n2}")
        '        End If
        '    Next
        '    ViewQueryTotal = GetQuery(tmptbl, "ViewGridColumnHide", "VIEW")
        '    ColumnList = ViewQueryTotal
        '    Dim HideColumns() As String = ColumnList.Split(","c)
        '    For Each col As String In HideColumns
        '        If FirstStage.Columns.ColumnByFieldName(col) IsNot Nothing Then
        '            'Hide
        '            FirstStage.Columns(col).Visible = False
        '        End If
        '    Next
        '    'PnlGrdView.Visible = True
        '    FirstStage.BestFitColumns()
        '    FirstStage.Focus()
        '    'PnlGrdView.BringToFront()
        '    GridControl1.BringToFront()
        'Else
        '    MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        '    'txtFormName.Focus()
        'End If
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

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        Dim valType As Object = FirstStage.GetFocusedRowCellValue("Reports")
        If e.Control AndAlso e.KeyCode = Keys.Q Then
            Dim reportloadquery As New ReportQueryLoad()
            reportloadquery._SeletedReportType = Convert.ToString(valType)
            reportloadquery.GetformName = Me._getformName()
            reportloadquery.ShowDialog()
        End If
    End Sub
End Class