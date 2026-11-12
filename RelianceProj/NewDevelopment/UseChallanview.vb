Imports System.Text
Imports DevExpress.Utils.Frames
Imports DevExpress.XtraEditors

Public Class UseChallanview
    Private _DatabaseTableName = "FormControl"
    Dim _TblName As String = ""
    Private _KeyFieldName As String = ""
    Dim _MainColumTbl As New DataTable
    Public MainLoadFormName1 As String = ""
    Public Property FormNameValue As String
    Dim txtEntryno As String = ""
    'Dim _Bookcode As String = ""
    Dim _Bookcode As New List(Of String)
    'Dim _Booktrtype As String = ""
    Dim _BookVNo As String = ""
    Dim _Booktrtype As New List(Of String)
    'Dim _BookVNo As New List(Of String)
    Dim _ActivatedColName As String = ""
    Dim isDragging As Boolean = False
    Dim dragOffset As Point
    Dim _TableName As String = ""
    Private _KeyFieldValue As String = ""
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable

    Private _FieldWidthSet As New StringBuilder
    Private _FieldHeader As New StringBuilder
    Private _FieldHeaderAlignment As New StringBuilder
    Private _FieldAlignMent As New StringBuilder
    Private _FieldNotVisibile As New StringBuilder
    Private _FieldLocked As New StringBuilder


    Private _FieldMasking As New StringBuilder

    Private _FieldUsemaster As New StringBuilder
    Private _Fieldmasterlist As New StringBuilder
    Private _FieldNotRequiredForSave As New StringBuilder
    Private _RecordsKeyFieldName As String = ""
    Private _ExtraFieldOthers As New StringBuilder
    Private _ExtraField_Values_Others As New StringBuilder
    Private _FieldDefaultValues As New StringBuilder

    Private isMoveMode As Boolean = False
    Private selectedCtrl As Control = Nothing
    Private _isLayoutApplied As Boolean = False
    Dim FormId As String = "0"
    Dim Id As String = "0"

    Dim _OldFormListtbl As New DataTable
    Private _DefaultColOfGrid As Integer = 0
    Private Grid1_Table_ColNames() As String
    Private _Grid1ColNames As New StringBuilder
    Private _Grid1LastColNo As Integer = 0
    Private _Grid1ColType As New StringBuilder

    Private Grid2_Table_ColNames() As String
    Private _Grid2ColNames As New StringBuilder
    Private _Grid2LastColNo As Integer = 0
    Private _Grid2ColType As New StringBuilder

    Private Grid3_Table_ColNames() As String
    Private _Grid3ColNames As New StringBuilder
    Private _Grid3LastColNo As Integer = 0
    Private _Grid3ColType As New StringBuilder

    Private Grid4_Table_ColNames() As String
    Private _Grid4ColNames As New StringBuilder
    Private _Grid4LastColNo As Integer = 0
    Private _Grid4ColType As New StringBuilder

    Private Grid5_Table_ColNames() As String
    Private _Grid5ColNames As New StringBuilder
    Private _Grid5LastColNo As Integer = 0
    Private _Grid5ColType As New StringBuilder

    Private _RowNo As Integer
    Private _ColNo As Integer

    Private UC_Buttons1 As UC_Buttons
    Private _FORMMODE As String = ""
    Private _FrmLoad As Boolean = True
    Private Change_Grid_Data As Boolean = True

    Dim _FormCloseMode As Boolean = False
    Dim allText As String
    Dim tmptbl As New DataTable
    Dim lbl_Pcs_Total As Label
    Dim Label22 As Label

    Dim allowedTotalCols_Grid_1 As New List(Of String)
    Dim isRowBlank As Boolean = True
    Dim mandatoryCol As String = ""
    Private _PrevColIndex As Integer = -1
    Dim lblTotalText As New Label()
    Dim GetformName As String = ""
    Dim GetformId As Integer = 0
    Private DynamicTabControl As TabControl = Nothing
    Private CurrentTabPage As TabPage = Nothing
    Dim ImagePaths As New Dictionary(Of Integer, String)
    Private _FieldUseHeaderColumn As New StringBuilder()
    Public Property ParentForm As MainFormRead
    Private Sub UseChallanview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadDefaultData()
        AutoResizeGrid(PnlGrdView, GridControl1)
    End Sub
    Private Sub _LoadDefaultData()
        View_Record()
        Dim sw As New Stopwatch()
        Dim formType As String = ""
        Dim UseChallan As String = ""
        If _MainColumTbl.Rows.Count > 0 Then
            formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            FormNameValue = _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        FormNameValue = _getformName()
        Dim tblTmp1 As New DataTable
        ' Step 1: Query Load Time
        sw.Restart()
        tblTmp1 = _GetFormQuery(FormNameValue, "USE CHALLAN")
        sw.Stop()
        Debug.WriteLine("_GetFormQuery Time: " & sw.ElapsedMilliseconds & " ms")
        ' Step 2: Grid Load Time
        If tblTmp1.Rows.Count > 0 Then
            sw.Restart()
            LoadViewData(tblTmp1, _Bookcode)
            sw.Stop()
            Debug.WriteLine("LoadViewData Time: " & sw.ElapsedMilliseconds & " ms")
        End If
    End Sub

    Private Sub View_Record()
        Try
            Dim EntryNo As Integer = 1
            Dim _Grid1ColNames As New StringBuilder()
            Dim _Grid1HeaderNames As New List(Of String)
            Dim View_Filter_Condition As String = " FormName='" & MainLoadFormName1 & "' "
            DynamicTabControl = Nothing
            CurrentTabPage = Nothing
            Dim CurrentDynamicTabControl As TabControl = Nothing
            Dim DynamicTabControls As New List(Of TabControl)
            If MainLoadFormName1 = "" Then
                Exit Sub
            End If
            If _MainColumTbl IsNot Nothing AndAlso _MainColumTbl.Rows.Count > 0 Then
                For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                    Dim oldName As String = dr("CntrlName").ToString().Trim()
                    RemoveControlIfExists(oldName)
                    RemoveControlIfExists("Lbl_" & oldName)
                Next
            End If
            _strQuery = New StringBuilder()
            With _strQuery
                .Append("Select * FROM " & _DatabaseTableName & " WHERE ")
                .Append(View_Filter_Condition)
            End With
            RS = _strQuery.ToString
            MenuDesign_QueryLoad()
            _MainColumTbl = DefaltSoftTable.Copy
            Dim _UseMasterTabl As New DataTable
            _UseMasterTabl = _MainColumTbl.Clone()
            For Each dr As DataRow In _MainColumTbl.Select("USEMASTER='YES'")
                _UseMasterTabl.ImportRow(dr)
            Next
#Region "Dynamic Form Controls"
            Dim _CntlMasterTabl As New DataTable
            _CntlMasterTabl = _MainColumTbl.Clone()
            Dim topPos As Integer = 0
            Dim leftPos As Integer = 0
            Dim height As Integer = 25
            Dim width As Integer = 100
            For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                Dim colType As String = dr("ColumnType").ToString().Trim()
                If Not colType.Equals("TabControl", StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If
                Dim Name As String = dr("CntrlName").ToString().Trim()
                Dim Tag As String = dr("DataBaseColumn").ToString().Trim()
                leftPos = Val(dr("LocationX").ToString())
                topPos = Val(dr("LocationY").ToString())
                width = Val(dr("SizeWidth").ToString())
                height = Val(dr("SizeHeight").ToString())
                Dim tabControl As New TabControl()
                Dim tabControlName As String = Name
                If String.IsNullOrWhiteSpace(tabControlName) Then
                    tabControlName = "TabControl"
                End If
                Dim baseName As String = tabControlName
                Dim counter As Integer = 1
                While Me.Controls.ContainsKey(tabControlName)
                    tabControlName = baseName & "_" & counter.ToString()
                    counter += 1
                End While
                tabControl.Name = tabControlName
                tabControl.Left = leftPos + 130
                tabControl.Top = topPos
                tabControl.Width = width
                tabControl.Height = height
                tabControl.Tag = Tag
                tabControl.TabIndex = TabIndex
                Dim tabNames As New List(Of String)
                If _MainColumTbl.Columns.Contains("TabName") Then
                    Dim tabNameValue As String = dr("TabName").ToString().Trim()
                    If tabNameValue <> "" Then
                        tabNames = tabNameValue.Split(","c).Select(Function(x) x.Trim()).Where(Function(x) x <> "").ToList()
                    End If
                End If
                Dim tabElements As Integer = 0
                If _MainColumTbl.Columns.Contains("TabElements") Then
                    Integer.TryParse(dr("TabElements").ToString().Trim(), tabElements)
                End If
                If tabElements <= 0 Then
                    tabElements = tabNames.Count
                End If
                For tabNo As Integer = 1 To tabElements
                    If tabNo > tabNames.Count Then
                        Exit For
                    End If
                    Dim tabCaption As String = tabNames(tabNo - 1).Trim()
                    If String.IsNullOrWhiteSpace(tabCaption) Then
                        Continue For
                    End If
                    Dim tabPage As New TabPage()
                    tabPage.Name = tabControl.Name & "_Tab" & tabNo.ToString()
                    tabPage.Text = tabCaption
                    tabPage.Tag = tabNo
                    tabControl.TabPages.Add(tabPage)
                Next
                Me.Controls.Add(tabControl)
                DynamicTabControls.Add(tabControl)
                If CurrentDynamicTabControl Is Nothing Then
                    CurrentDynamicTabControl = tabControl
                    DynamicTabControl = tabControl
                    If tabControl.TabPages.Count > 0 Then
                        tabControl.SelectedIndex = 0
                        CurrentTabPage = tabControl.TabPages(0)
                    End If
                End If
                AddHandler tabControl.SelectedIndexChanged,
                        Sub(sender As Object, e As EventArgs)
                            Dim tc As TabControl = TryCast(sender, TabControl)
                            If tc Is Nothing Then Return
                            If tc.SelectedTab Is Nothing Then Return
                            CurrentDynamicTabControl = tc
                            DynamicTabControl = tc
                            CurrentTabPage = tc.SelectedTab
                        End Sub
                AddHandler tabControl.MouseDown, AddressOf Control_MouseDown
                AddHandler tabControl.MouseMove, AddressOf Control_MouseMove
                AddHandler tabControl.MouseUp, AddressOf Control_MouseUp
            Next
            If DynamicTabControls.Count > 0 Then
                CurrentDynamicTabControl = DynamicTabControls(0)
                DynamicTabControl = DynamicTabControls(0)
                If DynamicTabControls(0).TabPages.Count > 0 Then
                    DynamicTabControls(0).SelectedIndex = 0
                    CurrentTabPage = DynamicTabControls(0).TabPages(0)
                End If
            End If
            For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
                Dim usemasterkey As String = dr("USEMASTERKEY").ToString().Trim()
                Dim colType As String = dr("ColumnType").ToString().Trim()
                Dim HeaderName As String = dr("UserText").ToString().Trim()
                Dim Name As String = dr("CntrlName").ToString().Trim()
                Dim visible As String = dr("Visible").ToString().Trim()
                Dim controlTableRows() As DataRow = _MainColumTbl.Select("CntrlName='" & Name.Replace("'", "''") & "' AND " & "DataBaseTable IS NOT NULL AND " & "DataBaseTable<>''")
                If controlTableRows.Length > 0 Then
                    _TblName = controlTableRows(0)("DataBaseTable").ToString().Trim()
                Else
                    _TblName = ""
                End If
                Dim Tabindex As Integer = 0
                Integer.TryParse(dr("Tabindex").ToString(), Tabindex)
                '_Bookcode = dr("Bookcode").ToString()
                _Bookcode.Clear()
                _Bookcode.Add(dr("Bookcode").ToString())
                Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                Dim formtype As String = dr("FormType").ToString().Trim()
                If formtype = "ENTRY FORM" Then
                End If
                If usemasterkey = "Y" Then
                    _KeyFieldName = colName
                End If
                Dim Tag As String = dr("DataBaseColumn").ToString()
                Dim oppMasterCode As String = dr("OppMasterCode").ToString()
                Dim _Readonly As String = dr("ReadOnly").ToString()
                FormId = dr("FormId").ToString()
                Id = dr("Id").ToString()
                If colType.Equals("TabControl", StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If
                leftPos = Val(dr("LocationX").ToString())
                topPos = Val(dr("LocationY").ToString())
                width = Val(dr("SizeWidth").ToString())
                height = Val(dr("SizeHeight").ToString())
                Dim tabCountNo As Integer = 0
                If _MainColumTbl.Columns.Contains("TabCountNo") Then
                    If Not IsDBNull(dr("TabCountNo")) Then
                        Integer.TryParse(dr("TabCountNo").ToString().Trim(), tabCountNo)
                    End If
                End If
                Dim targetTabControlName As String = ""
                If _MainColumTbl.Columns.Contains("TabControlName") Then
                    If Not IsDBNull(dr("TabControlName")) Then
                        targetTabControlName = dr("TabControlName").ToString().Trim()
                    End If
                End If
                Dim targetTabControl As TabControl = Nothing
                Dim targetTabPage As TabPage = Nothing
                Dim tabNo As Integer = 0
                Integer.TryParse(dr("TabCountNo").ToString().Trim(), tabNo)
                If targetTabControlName <> "" Then
                    For Each tc As TabControl In DynamicTabControls
                        For Each tp As TabPage In tc.TabPages
                            Dim pageNo As Integer = 0
                            Integer.TryParse(tp.Tag?.ToString(), pageNo)
                            If pageNo = tabNo Then
                                targetTabPage = tp
                                Exit For
                            End If
                        Next
                        If targetTabPage IsNot Nothing Then Exit For
                    Next
                End If
                If targetTabControl Is Nothing AndAlso DynamicTabControls.Count = 1 Then
                    targetTabControl = DynamicTabControls(0)
                End If
                'Dim targetTabPage As TabPage = Nothing
                If tabCountNo >= 1 AndAlso targetTabControl IsNot Nothing Then
                    If tabCountNo <= targetTabControl.TabPages.Count Then
                        targetTabPage = targetTabControl.TabPages(tabCountNo - 1)
                    End If
                End If
            Next
            Dim bookCodes As String = String.Join(",", _Bookcode.SelectMany(Function(x) x.Split(","c)).Select(Function(x) "'" & x.Trim().Replace("'", "''") & "'"))
            'sqL = "select * from mstbook where bookcode='" & _Bookcode & "'"
            sqL = "select * from mstbook where bookcode in (" & bookCodes & ")"
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                '_Booktrtype = DefaltSoftTable.Rows(0).Item("booktrtype").ToString()
                _Booktrtype.Clear()
                For Each dr As DataRow In DefaltSoftTable.Rows
                    _Booktrtype.Add(dr("booktrtype").ToString().Trim())
                Next
            Else
                MsgBox("Book Not Find Please Define Book", MsgBoxStyle.Critical)
            End If
#End Region
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        Finally
        End Try
    End Sub

    Private Sub DateBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If e.KeyChar = ChrW(Keys.Back) Then Exit Sub
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Exit Sub
        End If
        Dim pos As Integer = txt.SelectionStart
        If pos = 2 OrElse pos = 5 Then pos += 1
        If pos >= 10 Then
            e.Handled = True
            Exit Sub
        End If
        Dim value As String = txt.Text.PadRight(10, " "c)
        value = value.Remove(2, 1).Insert(2, "/")
        value = value.Remove(5, 1).Insert(5, "/")
        value = value.Remove(pos, 1).Insert(pos, e.KeyChar)
        txt.Text = value
        txt.SelectionStart = Math.Min(pos + 1, 10)
        e.Handled = True
    End Sub
    Private Sub DateBox_Validate(sender As Object, e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim dt As DateTime
        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = DateTime.Now.ToString("dd/MM/yyyy")
            Exit Sub
        End If
        If DateTime.TryParse(txt.Text, dt) Then
            txt.Text = dt.ToString("dd/MM/yyyy")
        Else
            MessageBox.Show("Invalid Date. Enter valid date in DD/MM/YYYY format.")
            txt.Focus()
        End If
    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If Not isMoveMode Then Exit Sub   ' ❌ move disabled
        isDragging = True
        selectedCtrl = DirectCast(sender, Control)
        dragOffset = e.Location
        If e.Button = MouseButtons.Left Then
            selectedCtrl = DirectCast(sender, Control)
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
    End Sub
    Private Sub RemoveControlIfExists(ctrlName As String)

        Dim oldCtrl As Control = Me.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Name = ctrlName)
        If oldCtrl IsNot Nothing Then
            Me.Controls.Remove(oldCtrl)
            oldCtrl.Dispose()
        End If
    End Sub
    Public Sub LoadViewData(ByVal tmptbl As DataTable, ByVal _Bookcode As List(Of String))
        Try
            'Generate_Date_For_DataBase(Txt_ViewFrom)
            'Generate_Date_For_DataBase(Txt_ViewTO)
            Dim ResultTable As New DataTable
            If tmptbl IsNot Nothing AndAlso tmptbl.Rows.Count > 0 AndAlso Not tmptbl.Columns.Contains("Mainid") Then
                ResultTable = tmptbl.Copy()
            Else
                'Dim UseChallanFilter1 As String = "'" & String.Join("','", _Bookcode) & "'"
                Dim UseChallanFilter1 As String = String.Join(",", _Bookcode.SelectMany(Function(x) x.Split(","c)).Select(Function(x) "'" & x.Trim() & "'"))
                Dim UseChallanFilter2 As String = ""
                Dim UseChallanFilter3 As String = ""
                Dim UseChallanFilter4 As String = ""
                Dim UseChallanFilter5 As String = ""
                Dim UseChallanFilter6 As String = ""
                Dim UseChallanFilter7 As String = ""
                Dim UseChallanFilter8 As String = ""
                Dim UseChallanFilter9 As String = ""
                Dim UseChallanFilter10 As String = ""
                Dim UseChallanViewQuery As String = GetQuery(tmptbl, "USECHALLANVIEWQUERY", "USE CHALLAN")
                If UseChallanViewQuery = "" Then
                    MsgBox("View Query Not Found")
                    Exit Sub
                End If
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter1", UseChallanFilter1)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter2", UseChallanFilter2)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter3", UseChallanFilter3)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter4", UseChallanFilter4)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter5", UseChallanFilter5)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter6", UseChallanFilter6)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter7", UseChallanFilter7)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter8", UseChallanFilter8)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter9", UseChallanFilter9)
                UseChallanViewQuery = UseChallanViewQuery.Replace("UseChallanFilter10", UseChallanFilter10)
                sqL = UseChallanViewQuery
                sql_connect_slect()
                If DefaltSoftTable IsNot Nothing Then
                    ResultTable = DefaltSoftTable.Copy()
                End If
            End If
            FirstStage.Columns.Clear()

            If ResultTable IsNot Nothing AndAlso ResultTable.Rows.Count > 0 Then
                'GridControl1.DataSource = Nothing
                ' Bind Data
                GridControl1.DataSource = ResultTable
                ' Checkbox Row Selection
                FirstStage.OptionsView.ColumnAutoWidth = False
                FirstStage.OptionsView.ShowGroupPanel = False
                FirstStage.OptionsView.EnableAppearanceEvenRow = False
                FirstStage.OptionsView.EnableAppearanceOddRow = False
                FirstStage.OptionsSelection.MultiSelect = True
                FirstStage.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
                FirstStage.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True
                FirstStage.OptionsSelection.EnableAppearanceFocusedCell = False
                FirstStage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
                FirstStage.OptionsView.ShowFooter = True
                RemoveHandler FirstStage.KeyDown, AddressOf FirstStage_KeyDown
                AddHandler FirstStage.KeyDown, AddressOf FirstStage_KeyDown
                DevGridFitColumn(GridControl1, FirstStage)
                PnlGrdView.Visible = True
                BtnPrint.Visible = True
                BtnExport.Visible = True
                PnlGrdView.BringToFront()
                GridControl1.BringToFront()
                ' Refresh Grid Layout
                FirstStage.LayoutChanged()
                ' Set Focus after binding
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End Try
    End Sub
    Private Sub FirstStage_MouseDown(sender As Object, e As MouseEventArgs) Handles FirstStage.MouseDown
        Dim hitInfo = FirstStage.CalcHitInfo(e.Location)
        If hitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator Then
            ' Allow normal row click
            Exit Sub
        End If
        If hitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            ' Normal cell click allowed
            Exit Sub
        End If
        If hitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator OrElse
       hitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column Then
            Exit Sub
        End If
    End Sub
    Public Function _getformName() As String
        If _MainColumTbl IsNot Nothing AndAlso _MainColumTbl.Rows.Count > 0 Then
            Return _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        Return ""
    End Function
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = " Report From : Use Challan View"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub FirstStage_KeyDown(sender As Object, e As KeyEventArgs) Handles FirstStage.KeyDown
        If e.KeyCode = Keys.Space Then
            e.Handled = True
            e.SuppressKeyPress = True
            Dim rowHandle As Integer = FirstStage.FocusedRowHandle
            If rowHandle >= 0 Then
                If FirstStage.IsRowSelected(rowHandle) Then
                    FirstStage.UnselectRow(rowHandle)
                Else
                    FirstStage.SelectRow(rowHandle)
                End If
            End If
        End If
        If e.KeyCode = Keys.F12 Then
            e.Handled = True
            e.SuppressKeyPress = True
            Dim SelectedData As DataTable = CType(GridControl1.DataSource, DataTable).Clone()
            Dim selectedRows() As Integer = FirstStage.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Dim row As DataRow = FirstStage.GetDataRow(rowHandle)
                    If row IsNot Nothing Then
                        SelectedData.ImportRow(row)
                    End If
                End If
            Next
            If SelectedData.Rows.Count > 0 Then
                If ParentForm IsNot Nothing AndAlso Not ParentForm.IsDisposed Then
                    ParentForm.Fill_SelectedData_To_Form(SelectedData)
                    Me.Close()
                Else
                    MessageBox.Show("Main Form Not Found.")
                End If
            Else
                MessageBox.Show("Please Select At Least One Row.")
            End If
        End If
    End Sub
    Private Sub UseChallanview_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ParentForm.BeginInvoke(New MethodInvoker(Sub()
                                                     If FirstStage.RowCount > 0 Then
                                                         ' First Row Focus
                                                         FirstStage.FocusedRowHandle = 0
                                                         ' First Visible Column Focus
                                                         If FirstStage.VisibleColumns.Count > 0 Then
                                                             FirstStage.FocusedColumn = FirstStage.VisibleColumns(0)
                                                         End If
                                                         ' Grid Keyboard Focus
                                                         FirstStage.Focus()
                                                     End If
                                                 End Sub))
    End Sub
End Class