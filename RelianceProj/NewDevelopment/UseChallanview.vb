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
    Dim _Bookcode As String = ""
    Dim _Booktrtype As String = ""
    Dim _BookVNo As String = ""
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


    'Dim Grid1 As New FlexCell.Grid()
    'Private _DataTableGrid1 As New DataTable
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

    'Private _DataTableGrid2 As New DataTable
    'Private _DataTableGrid3 As New DataTable
    'Private _DataTableGrid4 As New DataTable
    'Private _DataTableGrid5 As New DataTable
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

    Private Sub UseChallanview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadDefaultData()
        AutoResizeGrid(PnlGrdView, GridControl1)
    End Sub

    Private Sub _LoadDefaultData()
        View_Record()
        Dim formType As String = ""
        Dim UseChallan As String = ""
        If _MainColumTbl.Rows.Count > 0 Then
            formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            FormNameValue = _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        FormNameValue = _getformName()
        Dim tblTmp1 As New DataTable
        Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
        If ctrl.Length > 0 Then
            Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
            _GetAlterData(Entytxt.Text)
        End If
        tblTmp1 = _GetFormQuery(FormNameValue, "USE CHALLAN")
        If tblTmp1.Rows.Count > 0 Then
            LoadViewData(tblTmp1, _Bookcode)
        End If
    End Sub
    Private Sub _GetAlterData(ByVal _EntryNo As Int64)
        Try
            Dim TableNames As New List(Of Tuple(Of String, String, String))
            'For Each dr As DataRow In _MainColumTbl.Select("DataBaseTable IS NOT NULL AND DataBaseTable<>''")
            For Each dr As DataRow In _MainColumTbl.Select("DataBaseTable IS NOT NULL AND DataBaseTable<>''", "Id ASC")
                Dim TableName As String = dr("DataBaseTable").ToString().Trim()
                Dim ColumnType As String = dr("ColumnType").ToString().Trim()
                Dim ctrlName As String = dr("CntrlName").ToString().Trim()
                If TableName <> "" Then
                    Dim Exists As Boolean = TableNames.Any(Function(x) _
                        x.Item1.Equals(TableName, StringComparison.OrdinalIgnoreCase) AndAlso
                        x.Item2.Equals(ColumnType, StringComparison.OrdinalIgnoreCase) AndAlso
                        x.Item3.Equals(ctrlName, StringComparison.OrdinalIgnoreCase))
                    If Not Exists Then
                        TableNames.Add(Tuple.Create(TableName, ColumnType, ctrlName))
                    End If
                End If
            Next
            Dim tblTmp As DataTable
            For Each item In TableNames
                Dim TableName As String = item.Item1
                Dim FiltColumnType As String = item.Item2
                Dim ctrlName As String = item.Item3
                If FiltColumnType = "TextBox" Then
                    Alter_EntryFormHeader(_EntryNo, TableName)
                ElseIf FiltColumnType = "Grid" Then
                    sqL = getAlter_Form_EntryQuery(_EntryNo, TableName, FiltColumnType)
                    sql_connect_slect()
                    tblTmp = DefaltSoftTable.Copy
                    'If tblTmp Is Nothing OrElse tblTmp.Rows.Count = 0 Then
                    '    MsgBox("No Record Found")
                    '    Exit Sub
                    'End If
                    Dim currentCtrl As Control = Nothing
                    Dim grd As FlexCell.Grid
                    Dim gridname As String = ctrlName
                    Dim ImagePaths As New Dictionary(Of Integer, String)
                    If Me.Controls.ContainsKey(gridname) Then
                        grd = Me.Controls(gridname)
                    End If
                    Dim _GridColmName As String()
                    If ctrlName = "Grid1" Then
                        _GridColmName = Grid1_Table_ColNames
                    ElseIf ctrlName = "Grid2" Then
                        _GridColmName = Grid2_Table_ColNames
                    ElseIf ctrlName = "Grid3" Then
                        _GridColmName = Grid3_Table_ColNames
                    ElseIf ctrlName = "Grid4" Then
                        _GridColmName = Grid4_Table_ColNames
                    ElseIf ctrlName = "Grid5" Then
                        _GridColmName = Grid5_Table_ColNames
                    End If
                    If gridname.StartsWith(ctrlName) Then
                        If tblTmp.Rows.Count > 0 Then
                            If grd IsNot Nothing Then
                                grd.Range(0, 0, grd.Rows - 1, grd.Cols - 1).DeleteByRow()
                                Fill_Records(tblTmp, _GridColmName, grd, 0, True, "", False)
                                grd.Rows = grd.Rows + 1
                                Call Fill_Sr_No_Item(grd, _DataTableGrid1)
                                Call Fill_Sr_No_Item(grd, _DataTableGrid2)
                                Call Fill_Sr_No_Item(grd, _DataTableGrid3)
                                Call Fill_Sr_No_Item(grd, _DataTableGrid4)
                                Call Fill_Sr_No_Item(grd, _DataTableGrid5)
                            End If
                        End If
                    End If
                    If tblTmp.Rows.Count > 0 Then
                        If _DataTableGrid1 IsNot Nothing AndAlso _DataTableGrid1.Columns.Count > 0 Then
                            CalculateDynamicColumnTotal(grd, _DataTableGrid1, tblTmp)
                            ApplyGridFormula(grd, _DataTableGrid1)
                            _GridColmTotal(grd, _DataTableGrid1)
                        End If
                        If _DataTableGrid2 IsNot Nothing AndAlso _DataTableGrid2.Rows.Count > 0 Then
                            CalculateDynamicColumnTotal(grd, _DataTableGrid2, tblTmp)
                            ApplyGridFormula(grd, _DataTableGrid2)
                            _GridColmTotal(grd, _DataTableGrid2)
                        End If
                        If _DataTableGrid3 IsNot Nothing AndAlso _DataTableGrid3.Rows.Count > 0 Then
                            CalculateDynamicColumnTotal(grd, _DataTableGrid3, tblTmp)
                            ApplyGridFormula(grd, _DataTableGrid3)
                            _GridColmTotal(grd, _DataTableGrid3)
                        End If
                        If _DataTableGrid4 IsNot Nothing AndAlso _DataTableGrid4.Rows.Count > 0 Then
                            CalculateDynamicColumnTotal(grd, _DataTableGrid4, tblTmp)
                            ApplyGridFormula(grd, _DataTableGrid4)
                            _GridColmTotal(grd, _DataTableGrid4)
                        End If
                        If _DataTableGrid5 IsNot Nothing AndAlso _DataTableGrid5.Rows.Count > 0 Then
                            CalculateDynamicColumnTotal(grd, _DataTableGrid5, tblTmp)
                            ApplyGridFormula(grd, _DataTableGrid5)
                            _GridColmTotal(grd, _DataTableGrid5)
                        End If

                    Else
                        MsgBox("Record Not Found")
                        'ObjCls_General.Blank_Object(Me)
                        'Clear_Grid(grd, 2)
                        'grd.Visible = False
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        End Try
    End Sub
    Private Function Alter_EntryFormHeader(ByVal Entryno As String, ByVal _FilterTableName As String) As DataTable
        Try
            _FrmLoad = True
            Dim tblTmp As New DataTable
            sqL = getAlter_Form_EntryQuery(Entryno, _FilterTableName, "")
            sql_connect_slect()
            tblTmp = DefaltSoftTable.Copy
            ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)
            If tblTmp.Rows.Count > 0 Then
                _BookVNo = tblTmp.Rows(0).Item("bookvno").ToString
            End If
            _FrmLoad = False
            Return tblTmp   ' 👈 yaha return kar diya
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        End Try
    End Function
    Private Function getAlter_Form_EntryQuery(ByVal EntryNo As String, ByVal _FilterTableName As String, ByVal FillColumnType As String) As String
        Dim leftJoin As New StringBuilder()
        Dim joinHeader As New StringBuilder()
        Dim filterCondition As String = ""
        If FillColumnType.Equals("Grid", StringComparison.OrdinalIgnoreCase) Then
            filterCondition = "ColumnType='Grid' AND " & "DataBaseTable='" & _FilterTableName.Replace("'", "''") & "'"
        Else
            filterCondition = "USEMASTER='YES' AND " & "MasterList > '' AND " & "DataBaseTable='" & _FilterTableName.Replace("'", "''") & "'"
        End If
        Dim gridRows() As DataRow = _MainColumTbl.Select(filterCondition)
        For Each dr As DataRow In gridRows
            Dim _CntrlName As String = ""
            If FillColumnType.Equals("Grid", StringComparison.OrdinalIgnoreCase) Then
                _CntrlName = dr("CntrlName").ToString().Trim()
                Dim visibleValue As String = dr("Visible").ToString().Trim()
                Dim designType As String = dr("FormDesignType").ToString().Trim()
                If Not visibleValue.Equals("Y", StringComparison.OrdinalIgnoreCase) Then
                    'Continue For
                End If
                If Not designType.Equals("GRID DETAIL DESIGN", StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If
            End If
            Dim databaseColumn As String = dr("DataBaseColumn").ToString().Trim()
            Dim _joinTableName As String = dr("JoinerTableName").ToString().Trim()
            Dim _JoinColumnName As String = dr("JoinerTableColumn").ToString().Trim()
            Dim _DatabaseHeaderName As String = dr("UserText").ToString().Trim()
            Dim _OppositCode As String = dr("OppMasterCode").ToString().Trim()
            Dim _SelectionMastrName As String = dr("MasterList").ToString().Trim()
            Dim res = GetAccountMaster(_DatabaseHeaderName, _OppositCode, _SelectionMastrName)
            If res IsNot Nothing Then
                If Not String.IsNullOrWhiteSpace(res.LeftJoin) Then
                    leftJoin.AppendLine(res.LeftJoin)
                End If
                If Not String.IsNullOrWhiteSpace(res.JoinHeader) Then
                    joinHeader.AppendLine(res.JoinHeader)
                End If
            End If
            If Not String.IsNullOrWhiteSpace(_joinTableName) AndAlso Not String.IsNullOrWhiteSpace(databaseColumn) AndAlso Not String.IsNullOrWhiteSpace(_JoinColumnName) Then
                Dim joinAlias As String = "J_" & _joinTableName.Replace(" ", "_")
                Dim joinText As String = " LEFT JOIN " & _joinTableName & " AS " & joinAlias & " ON A." & databaseColumn & " = " & joinAlias & "." & _JoinColumnName
                If leftJoin.ToString().IndexOf(" AS " & joinAlias & " ", StringComparison.OrdinalIgnoreCase) = -1 Then
                    leftJoin.AppendLine(joinText)
                End If
            End If
        Next
        _strQuery = New StringBuilder()
        With _strQuery
            .Append(" SELECT A.* ")
            .Append(joinHeader.ToString())
            .Append(" FROM " & _FilterTableName & " AS A ")
            .Append(leftJoin.ToString())
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _Bookcode.Replace("'", "''") & "' ")
            If _FORMMODE = "VIEW" Then
            Else
                .Append(" AND A.EntryNo=" & EntryNo)
            End If
            .Append(" ORDER BY A.EntryNo DESC")
        End With
        Return _strQuery.ToString()
    End Function
    Public Sub CalculateDynamicColumnTotal(grd As FlexCell.Grid, dt As DataTable, tmptbl As DataTable)
        'Dim ViewQueryTotal As String = GetQuery(tmptbl, "GRIDCOLUMSUM", "VIEW")
        Dim ViewQueryTotal As String = GetQuery(tmptbl, "GRIDCOLUMSUM", "TOTAL COLUMN")
        If String.IsNullOrWhiteSpace(ViewQueryTotal) Then Exit Sub
        Dim Columns() As String = ViewQueryTotal.Split(","c)

        allowedTotalCols_Grid_1.Clear()
        For Each col As String In Columns
            Dim cleanCol As String = col.Trim()
            Dim matchedCol = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = cleanCol.ToLower())
            If matchedCol IsNot Nothing Then
                allowedTotalCols_Grid_1.Add(matchedCol.ColumnName)
            End If
        Next
        _GridColmTotal(grd, dt)
    End Sub
    Private Sub View_Record()
        Try
            Dim EntryNo As Integer = 1
            Dim _Grid1ColNames As New StringBuilder()
            Dim _Grid1HeaderNames As New List(Of String)
            'MainLoadFormName = FormNameValue
            Dim View_Filter_Condition As String = " FormName='" & MainLoadFormName1 & "' "
            DynamicTabControl = Nothing
            CurrentTabPage = Nothing
            Dim CurrentDynamicTabControl As TabControl = Nothing
            Dim DynamicTabControls As New List(Of TabControl)
            If MainLoadFormName1 = "" Then
                '    BtnUpdatepos.Enabled = False
                '    btnmovecontrol.Enabled = False
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
                _Bookcode = dr("Bookcode").ToString()
                Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                Dim formtype As String = dr("FormType").ToString().Trim()
                If formtype = "ENTRY FORM" Then
                    If _FORMMODE = "EDIT" OrElse _FORMMODE = "DELETE" Then
                        EntryNo = _GetMaxEntryNo()
                    End If
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
                If _InputType.Equals("SpacerType", StringComparison.OrdinalIgnoreCase) Then
                    Dim lblSpacer As New Label()
                    lblSpacer.Name = "Lbl_" & Name
                    lblSpacer.Text = HeaderName
                    lblSpacer.AutoSize = False
                    lblSpacer.Width = 120
                    lblSpacer.Height = height
                    lblSpacer.Visible = dr("Visible").ToString().Trim().Equals("Y", StringComparison.OrdinalIgnoreCase)
                    lblSpacer.TextAlign = ContentAlignment.MiddleLeft
                    If leftPos < 0 Then
                        lblSpacer.Left = leftPos + 10
                    Else
                        lblSpacer.Left = leftPos
                    End If
                    lblSpacer.Top = topPos
                    If targetTabPage IsNot Nothing Then
                        targetTabPage.Controls.Add(lblSpacer)
                    Else
                        If CurrentDynamicTabControl Is Nothing Then
                            Me.Controls.Add(lblSpacer)
                        Else
                            Continue For
                        End If
                    End If
                    Dim cmb As New System.Windows.Forms.ComboBox()
                    cmb.Name = Name.Trim()
                    cmb.Left = leftPos + 130
                    cmb.Top = topPos
                    cmb.Width = width
                    cmb.Height = height
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList
                    cmb.TabIndex = Tabindex
                    cmb.Tag = colName
                    cmb.Visible = dr("Visible").ToString().Trim().Equals("Y", StringComparison.OrdinalIgnoreCase)
                    cmb.AccessibleName = colName
                    cmb.AccessibleDescription = colName
                    Dim spacerValue As String = ""
                    If _MainColumTbl.Columns.Contains("SpacerString") Then
                        If Not IsDBNull(dr("SpacerString")) Then
                            spacerValue = dr("SpacerString").ToString().Trim()
                        End If
                    End If
                    cmb.Items.Clear()
                    If spacerValue <> "" Then
                        For Each item As String In spacerValue.Split(","c)
                            Dim itemValue As String = item.Trim()
                            If itemValue <> "" Then
                                cmb.Items.Add(itemValue)
                            End If
                        Next
                    End If
                    If cmb.Items.Count > 0 Then
                        Dim gridColumnIndex As Integer = 0
                        If Not IsDBNull(dr("OrderNo")) Then
                            Integer.TryParse(dr("OrderNo").ToString(), gridColumnIndex)
                        End If
                        gridColumnIndex = gridColumnIndex Mod cmb.Items.Count
                        cmb.SelectedIndex = gridColumnIndex
                    Else
                        cmb.SelectedIndex = -1
                    End If
                    If targetTabPage IsNot Nothing Then
                        targetTabPage.Controls.Add(cmb)
                    Else
                        If CurrentDynamicTabControl Is Nothing Then
                            Me.Controls.Add(cmb)
                        Else
                            Continue For
                        End If
                    End If
                    AddHandler lblSpacer.MouseDown, AddressOf Control_MouseDown
                    AddHandler lblSpacer.MouseMove, AddressOf Control_MouseMove
                    AddHandler lblSpacer.MouseUp, AddressOf Control_MouseUp
                    AddHandler cmb.MouseDown, AddressOf Control_MouseDown
                    AddHandler cmb.MouseMove, AddressOf Control_MouseMove
                    AddHandler cmb.MouseUp, AddressOf Control_MouseUp
                    'AddHandler cmb.KeyDown, AddressOf SpacerComboBox_KeyDown
                    Continue For
                End If
                Dim NeedLabel As Boolean = True
                If colType.Equals("CheckBox", StringComparison.OrdinalIgnoreCase) OrElse colType.Equals("ImgAdd", StringComparison.OrdinalIgnoreCase) OrElse colType.Equals("ImgView", StringComparison.OrdinalIgnoreCase) OrElse colType.Equals("Grid", StringComparison.OrdinalIgnoreCase) OrElse colType.Equals("TabControl", StringComparison.OrdinalIgnoreCase) Then
                    NeedLabel = False
                End If
                If Name.Equals("Grid1", StringComparison.OrdinalIgnoreCase) OrElse Name.Equals("Grid2", StringComparison.OrdinalIgnoreCase) OrElse Name.Equals("Grid3", StringComparison.OrdinalIgnoreCase) OrElse Name.Equals("Grid4", StringComparison.OrdinalIgnoreCase) OrElse Name.Equals("Grid5", StringComparison.OrdinalIgnoreCase) Then
                    NeedLabel = False
                End If
                If visible.Equals("N", StringComparison.OrdinalIgnoreCase) Then
                    NeedLabel = False
                End If
                If HeaderName <> "" AndAlso NeedLabel Then
                    Dim lbl As New Label()
                    lbl.Name = "Lbl_" & Name
                    lbl.Text = HeaderName
                    lbl.Left = Math.Max(5, leftPos)
                    lbl.Top = topPos
                    lbl.Width = 120
                    lbl.Height = Math.Max(20, height)
                    lbl.TextAlign = ContentAlignment.MiddleLeft
                    lbl.AutoSize = False
                    If tabCountNo > 0 Then
                        If targetTabPage IsNot Nothing Then
                            targetTabPage.Controls.Add(lbl)
                        End If
                    Else
                        Me.Controls.Add(lbl)
                    End If
                    AddHandler lbl.MouseDown, AddressOf Control_MouseDown
                    AddHandler lbl.MouseMove, AddressOf Control_MouseMove
                    AddHandler lbl.MouseUp, AddressOf Control_MouseUp
                End If
                If colType.Equals("TextBox", StringComparison.OrdinalIgnoreCase) AndAlso visible.Equals("Y", StringComparison.OrdinalIgnoreCase) Then
                    Dim txt As New TextBox()
                    txt.Name = Name
                    txt.Left = leftPos + 130
                    txt.Top = topPos
                    txt.Width = width
                    txt.Height = height
                    txt.TabIndex = Tabindex
                    Dim userTextValue As String = dr("UserText").ToString().Trim()
                    Dim databaseColumn As String = dr("DataBaseColumn").ToString().Trim()
                    Dim useChallan As String = ""

                    If _MainColumTbl.Columns.Contains("UseChallan") AndAlso Not IsDBNull(dr("UseChallan")) Then
                        useChallan = dr("UseChallan").ToString().Trim()
                    End If

                    If userTextValue.StartsWith("Attach Image", StringComparison.OrdinalIgnoreCase) Then
                        txt.Tag = userTextValue
                        txt.AccessibleName = databaseColumn
                        txt.AccessibleDescription = ""
                    Else
                        'If _FORMMODE = "EDIT" Then
                        txt.AccessibleDescription = databaseColumn
                        'If databaseColumn.Equals("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) OrElse databaseColumn.StartsWith("NO COLUMN USE ", StringComparison.OrdinalIgnoreCase) Then
                        If dr("UseMaster").ToString().Trim().Equals("YES", StringComparison.OrdinalIgnoreCase) OrElse useChallan.Equals("YES", StringComparison.OrdinalIgnoreCase) Then
                            txt.Tag = userTextValue
                        Else
                            txt.Tag = databaseColumn
                        End If
                    End If
                    If _Readonly.Equals("Y", StringComparison.OrdinalIgnoreCase) Then
                        txt.ReadOnly = True
                    Else
                        txt.ReadOnly = False
                    End If
                    If tabCountNo > 0 Then
                        If targetTabPage IsNot Nothing Then
                            targetTabPage.Controls.Add(txt)
                        Else
                            Continue For
                        End If
                    Else
                        Me.Controls.Add(txt)
                    End If
                    If formtype = "ENTRY FORM" Then
                        If Tag = "ENTRYNO" Then
                            txtEntryno = Name
                            txt.Text = EntryNo
                            If _FORMMODE = "ADD" Then
                                EntryNo = _GetMaxEntryNo()
                                txt.Text = EntryNo + 1
                                txt.Focus()
                            End If
                            'AddHandler txt.KeyDown, AddressOf EntryNoControl_KeyDown
                        End If
                        If _InputType.Equals("DateBox", StringComparison.OrdinalIgnoreCase) Then
                            txt.MaxLength = 10
                            txt.Text = Today.ToString("dd/MM/yyyy")
                            AddHandler txt.KeyPress, AddressOf DateBox_KeyPress
                            AddHandler txt.Leave, AddressOf DateBox_Validate
                        End If
                        If _FORMMODE = "DELETE" Then
                            EntryNo = _GetMaxEntryNo()
                        End If
                    End If
                    AddHandler txt.MouseDown, AddressOf Control_MouseDown
                    AddHandler txt.MouseMove, AddressOf Control_MouseMove
                    AddHandler txt.MouseUp, AddressOf Control_MouseUp
                    AddHandler txt.KeyDown, AddressOf Control_KeyDown
                End If
                If colType.Equals("ImgAdd", StringComparison.OrdinalIgnoreCase) Then
                    Dim btn As New SimpleButton()
                    btn.Name = Name
                    btn.Left = leftPos + 130
                    btn.Top = topPos
                    btn.Width = 65
                    btn.Height = 30
                    btn.Text = HeaderName
                    btn.Font = New Font("Verdana", 10, FontStyle.Bold)
                    btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
                    Dim buttonNo As Integer = 0
                    If Name.StartsWith("ImgAdd", StringComparison.OrdinalIgnoreCase) Then
                        Dim numberPart As String = Name.Substring("ImgAdd".Length)
                        If Integer.TryParse(numberPart, buttonNo) Then
                            btn.Tag = "Attach Image" & buttonNo.ToString()
                        Else
                            btn.Tag = Tag
                        End If
                    Else
                        btn.Tag = Tag
                    End If
                    If tabCountNo > 0 Then
                        If targetTabPage IsNot Nothing Then
                            targetTabPage.Controls.Add(btn)
                        Else
                            Continue For
                        End If
                    Else
                        Me.Controls.Add(btn)
                    End If
                    AddHandler btn.MouseDown, AddressOf Control_MouseDown
                    AddHandler btn.MouseMove, AddressOf Control_MouseMove
                    AddHandler btn.MouseUp, AddressOf Control_MouseUp
                    'AddHandler btn.Click, AddressOf ButtonImgAdd_Click
                End If
                If colType.Equals("ImgView", StringComparison.OrdinalIgnoreCase) Then
                    Dim btn As New SimpleButton()
                    btn.Name = Name
                    btn.Left = leftPos + 130
                    btn.Top = topPos
                    btn.Width = 65
                    btn.Height = 30
                    btn.Text = HeaderName
                    btn.Font = New Font("Verdana", 10, FontStyle.Bold)
                    btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
                    Dim buttonNo As Integer = 0
                    If Name.StartsWith("ImgView", StringComparison.OrdinalIgnoreCase) Then
                        Dim numberPart As String = Name.Substring("ImgView".Length)
                        If Integer.TryParse(numberPart, buttonNo) Then
                            btn.Tag = "Attach Image" & buttonNo.ToString()
                        Else
                            btn.Tag = Tag
                        End If
                    Else
                        btn.Tag = Tag
                    End If
                    If tabCountNo > 0 Then
                        If targetTabPage IsNot Nothing Then
                            targetTabPage.Controls.Add(btn)
                        Else
                            Continue For
                        End If
                    Else
                        Me.Controls.Add(btn)
                    End If
                    AddHandler btn.MouseDown, AddressOf Control_MouseDown
                    AddHandler btn.MouseMove, AddressOf Control_MouseMove
                    AddHandler btn.MouseUp, AddressOf Control_MouseUp
                    'AddHandler btn.Click, AddressOf ButtonImgAdd_Click
                End If
                If colType.Equals("CheckBox", StringComparison.OrdinalIgnoreCase) Then
                    Dim chk As New CheckBox()
                    chk.Name = Name.Trim()
                    chk.Text = HeaderName
                    chk.Left = leftPos + 130
                    chk.Top = topPos
                    chk.Width = width
                    chk.Height = height
                    chk.TabIndex = Tabindex
                    chk.Tag = colName
                    chk.AccessibleName = colName
                    chk.AccessibleDescription = colName
                    If tabCountNo > 0 Then
                        If targetTabPage IsNot Nothing Then
                            targetTabPage.Controls.Add(chk)
                        Else
                            Continue For
                        End If
                    Else
                        Me.Controls.Add(chk)
                    End If
                    AddHandler chk.MouseDown, AddressOf Control_MouseDown
                    AddHandler chk.MouseMove, AddressOf Control_MouseMove
                    AddHandler chk.MouseUp, AddressOf Control_MouseUp
                End If
                If colType = "Grid" Then
                    Dim gridname As String = dr("CntrlName").ToString().Trim()
                    If gridname = "Grid1" Then
                        Dim grid1 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid1, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                        'Fill_Current_Row_Sr_No(_DataTableGrid1, grid1)
                        If grid1 IsNot Nothing Then
                            grid1.Visible = True
                            grid1.Enabled = True
                            Fill_Current_Row_Sr_No(_DataTableGrid1, grid1)
                        End If
                    ElseIf gridname = "Grid2" Then
                        Dim grid2 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid2, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                        If grid2 IsNot Nothing Then
                            grid2.Visible = True
                            grid2.Enabled = True
                            Fill_Current_Row_Sr_No(_DataTableGrid2, grid2)
                        End If
                    ElseIf gridname = "Grid3" Then
                        Dim grid3 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid3, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                        If grid3 IsNot Nothing Then
                            grid3.Visible = True
                            grid3.Enabled = True
                            Fill_Current_Row_Sr_No(_DataTableGrid3, grid3)
                        End If
                    ElseIf gridname = "Grid4" Then
                        Dim grid4 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid4, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                        If grid4 IsNot Nothing Then
                            grid4.Visible = True
                            grid4.Enabled = True
                            Fill_Current_Row_Sr_No(_DataTableGrid4, grid4)
                        End If
                    ElseIf gridname = "Grid5" Then
                        Dim grid5 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid5, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                        If grid5 IsNot Nothing Then
                            grid5.Visible = True
                            grid5.Enabled = True
                            Fill_Current_Row_Sr_No(_DataTableGrid5, grid5)
                        End If
                    End If
                End If
            Next
            sqL = "select * from mstbook where bookcode='" & _Bookcode & "'"
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                _Booktrtype = DefaltSoftTable.Rows(0).Item("booktrtype").ToString()
            Else
                MsgBox("Book Not Find Please Define Book", MsgBoxStyle.Critical)
            End If
#End Region
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        Finally
        End Try
    End Sub
#Region "GRID GENERAL FUNCTION"
    Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If
    End Sub
#End Region
    Public Function SetupFlexGrid(ByVal gridName As String, ByVal gridTable As DataTable, ByVal leftPos As Integer, ByVal topPos As Integer, ByVal width As Integer, ByVal height As Integer, ByVal tagValue As Object, ByVal TabIndex As Integer) As FlexCell.Grid
        If String.IsNullOrWhiteSpace(gridName) Then Return Nothing
        Dim grd As FlexCell.Grid = TryCast(Me.Controls(gridName), FlexCell.Grid)
        If grd Is Nothing Then
            grd = New FlexCell.Grid()
            grd.Name = gridName
            Me.Controls.Add(grd)
        End If
        ' Basic properties
        grd.Visible = True
        grd.Left = leftPos + 130
        grd.Top = topPos
        grd.Width = width
        grd.Height = height
        grd.Tag = tagValue
        grd.TabIndex = TabIndex
        grd.Enabled = False
        grd.SelectionBorderColor = Color.Red

        defineGridColName("Grid", gridName)
        If gridName = "Grid1" Then
            If _Grid1ColNames Is Nothing OrElse _Grid1ColNames.Length = 0 Then
                MsgBox("Column design is not available for '" & gridName & "'. Please configure the grid columns and try again.", "Grid Design Required", MessageBoxButtons.OK)
            End If
            GenerateTable(_DataTableGrid1, grd, _Grid1ColNames)
            GridFormatting(_DataTableGrid1, grd)
        ElseIf gridName = "Grid2" Then
            If _Grid2ColNames Is Nothing OrElse _Grid2ColNames.Length = 0 Then
                MsgBox("Column design is not available for '" & gridName & "'. Please configure the grid columns and try again.", "Grid Design Required", MessageBoxButtons.OK)
            End If
            GenerateTable(_DataTableGrid2, grd, _Grid2ColNames)
            GridFormatting(_DataTableGrid2, grd)
        ElseIf gridName = "Grid3" Then
            If _Grid3ColNames Is Nothing OrElse _Grid3ColNames.Length = 0 Then
                MsgBox("Column design is not available for '" & gridName & "'. Please configure the grid columns and try again.", "Grid Design Required", MessageBoxButtons.OK)
            End If
            GenerateTable(_DataTableGrid3, grd, _Grid3ColNames)
            GridFormatting(_DataTableGrid3, grd)
        ElseIf gridName = "Grid4" Then
            If _Grid4ColNames Is Nothing OrElse _Grid4ColNames.Length = 0 Then
                MsgBox("Column design is not available for '" & gridName & "'. Please configure the grid columns and try again.", "Grid Design Required", MessageBoxButtons.OK)
            End If
            GenerateTable(_DataTableGrid4, grd, _Grid4ColNames)
            GridFormatting(_DataTableGrid4, grd)
        ElseIf gridName = "Grid5" Then
            If _Grid5ColNames Is Nothing OrElse _Grid5ColNames.Length = 0 Then
                MsgBox("Column design is not available for '" & gridName & "'. Please configure the grid columns and try again.", "Grid Design Required", MessageBoxButtons.OK)
            End If
            GenerateTable(_DataTableGrid5, grd, _Grid5ColNames)
            GridFormatting(_DataTableGrid5, grd)
        End If
        RemoveHandler grd.MouseDown, AddressOf Control_MouseDown
        RemoveHandler grd.MouseMove, AddressOf Control_MouseMove
        RemoveHandler grd.MouseUp, AddressOf Control_MouseUp
        AddHandler grd.MouseDown, AddressOf Control_MouseDown
        AddHandler grd.MouseMove, AddressOf Control_MouseMove
        AddHandler grd.MouseUp, AddressOf Control_MouseUp
        AddHandler grd.KeyDown, AddressOf Control_KeyDown
        AddHandler grd.RowColChange, AddressOf Grid_RowColChange
        grd.Cell(1, gridTable.Columns.IndexOf("SRNO") + 1).SetFocus()
        FocusSetToGridDefaultColumn(grd, _DefaultColOfGrid)
        Return grd
    End Function

    Private Sub Grid_RowColChange(sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs)
        _ActivatedColName = Trim(UCase(sender.Cell(0, sender.ActiveCell.Col).TAG))
    End Sub

    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid, ByVal GrdgenColmName As StringBuilder)
        ObjCls_General.CreateDataTable(gridTable, GrdgenColmName.ToString.ToUpper, "NO", GrdgenColmName.ToString)
        'grdObj.ExtendLastCol = True
        _Grid1LastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 2
    End Sub


    Private Sub GridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj Is Nothing OrElse grdObj.Cols = 0 Then Exit Sub
        grdObj.AutoRedraw = False
        grdObj.FixedRows = 1
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _FieldNotVisibile.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _FieldHeader.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _FieldHeaderAlignment.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _FieldAlignMent.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _FieldMasking.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _FieldWidthSet.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _FieldLocked.ToString)
        Dim xFont As New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
        grdObj.AutoRedraw = True
        grdObj.Refresh()
    End Sub
    Private Sub defineGridColName(ByVal columnTypeFilter As String, ByVal ctrlname As String)

        _Grid1ColNames = New StringBuilder()
        _Grid2ColNames = New StringBuilder()
        _Grid3ColNames = New StringBuilder()
        _Grid4ColNames = New StringBuilder()
        _Grid5ColNames = New StringBuilder()
        _FieldHeader = New StringBuilder()
        _FieldHeaderAlignment = New StringBuilder()
        _FieldAlignMent = New StringBuilder()
        _FieldWidthSet = New StringBuilder()
        _FieldNotVisibile = New StringBuilder()
        _FieldLocked = New StringBuilder()
        _Grid1ColType = New StringBuilder()
        _FieldMasking = New StringBuilder()
        _FieldUseHeaderColumn = New StringBuilder()

        Dim filter As String = "ColumnType='" & columnTypeFilter.Replace("'", "''") & "' AND CntrlName='" & ctrlname.Replace("'", "''") & "'"

        Dim gridColNames As StringBuilder = Nothing

        Select Case ctrlname.ToUpper()
            Case "GRID1" : gridColNames = _Grid1ColNames
            Case "GRID2" : gridColNames = _Grid2ColNames
            Case "GRID3" : gridColNames = _Grid3ColNames
            Case "GRID4" : gridColNames = _Grid4ColNames
            Case "GRID5" : gridColNames = _Grid5ColNames
            Case Else : Exit Sub
        End Select

        For Each dr As DataRow In _MainColumTbl.Select(filter, "OrderNo")

            _TblName = dr("DataBaseTable").ToString().Trim()

            Dim colName As String = dr("DataBaseColumn").ToString().Trim()
            Dim colType As String = dr("ColumnType").ToString().Trim()
            Dim header As String = dr("UserText").ToString().Trim()
            Dim alignVal As String = dr("TextAlign").ToString().Trim().ToUpper()

            If alignVal = "" Then alignVal = "L"
            If dr("UseMaster").ToString().Trim().Equals("YES", StringComparison.OrdinalIgnoreCase) Then
                colName = header.Trim()
                If String.IsNullOrWhiteSpace(colName) Then
                    colName = dr("UserText").ToString().Trim()
                End If
                dr("DataBaseColumn") = colName
            End If
            If String.IsNullOrWhiteSpace(header) OrElse String.IsNullOrWhiteSpace(colName) Then Continue For
            'Grid Column Names
            If gridColNames.Length > 0 Then gridColNames.Append(",")
            gridColNames.Append(colName)
            'Header
            If _FieldHeader.Length > 0 Then _FieldHeader.Append(",")
            _FieldHeader.Append(colName & ":" & header)
            'Alignment
            If _FieldHeaderAlignment.Length > 0 Then _FieldHeaderAlignment.Append(",")
            _FieldHeaderAlignment.Append(colName & ":" & alignVal)
            If _FieldAlignMent.Length > 0 Then _FieldAlignMent.Append(",")
            _FieldAlignMent.Append(colName & ":" & alignVal)
            'Use Header Column
            Dim useHeader As String = dr("UseHeaderColumn").ToString().Trim()
            If _FieldUseHeaderColumn.Length > 0 Then _FieldUseHeaderColumn.Append(",")
            _FieldUseHeaderColumn.Append(colName & ":" & useHeader)
            'Width
            Dim widthVal As Integer = Val(dr("SizeWidth").ToString())
            If _FieldWidthSet.Length > 0 Then _FieldWidthSet.Append(",")
            _FieldWidthSet.Append(colName & ":" & widthVal)
            'Visible
            Dim visibleVal As String = dr("Visible").ToString().Trim().ToUpper()
            If visibleVal = "" Then visibleVal = "N"
            If _FieldNotVisibile.Length > 0 Then _FieldNotVisibile.Append(",")
            _FieldNotVisibile.Append(colName & ":" & visibleVal)
            'ReadOnly
            Dim lockVal As String = dr("ReadOnly").ToString().Trim().ToUpper()
            If lockVal = "" Then lockVal = "N"
            If _FieldLocked.Length > 0 Then _FieldLocked.Append(",")
            _FieldLocked.Append(colName & ":" & lockVal)
            'Input Type
            Dim inputType As String = dr("InputType").ToString().Trim().ToUpper()
            If inputType = "NUMERIC" Then
                colType = "N"
                If _Grid1ColType.Length > 0 Then _Grid1ColType.Append(",")
                _Grid1ColType.Append(colName & ":" & colType)
                Dim prec As Integer = Val(dr("Masking").ToString())
                Dim maskVal As String = "NO-" & prec
                If _FieldMasking.Length > 0 Then _FieldMasking.Append(",")
                _FieldMasking.Append(colName & ":" & maskVal)
            End If

            'SaveYN
            Dim saveYN As String = dr("SaveYN").ToString().Trim().ToUpper()
            If saveYN = "N" Then
                If _FieldNotRequiredForSave.Length > 0 Then
                    _FieldNotRequiredForSave.Append(",")
                End If

                _FieldNotRequiredForSave.Append(colName & ":" & saveYN)
            End If

        Next

        If ctrlname = "Grid1" Then
            Grid1_Table_ColNames = _Grid1ColNames.ToString().ToUpper().Split(",")

        ElseIf ctrlname = "Grid2" Then
            Grid2_Table_ColNames = _Grid2ColNames.ToString().ToUpper().Split(",")
        ElseIf ctrlname = "Grid3" Then
            Grid3_Table_ColNames = _Grid3ColNames.ToString().ToUpper().Split(",")
        ElseIf ctrlname = "Grid4" Then
            Grid4_Table_ColNames = _Grid4ColNames.ToString().ToUpper().Split(",")
        ElseIf ctrlname = "Grid5" Then
            Grid5_Table_ColNames = _Grid5ColNames.ToString().ToUpper().Split(",")
        End If

    End Sub
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        Dim ctrl As Control = TryCast(sender, Control)
        If ctrl Is Nothing Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TypeOf ctrl Is FlexCell.Grid Then
                Dim grd As FlexCell.Grid = DirectCast(ctrl, FlexCell.Grid)
                Dim gridDt As DataTable = Nothing
                If grd.Name = "Grid1" Then
                    gridDt = _DataTableGrid1
                ElseIf grd.Name = "Grid2" Then
                    gridDt = _DataTableGrid2
                ElseIf grd.Name = "Grid3" Then
                    gridDt = _DataTableGrid3
                ElseIf grd.Name = "Grid4" Then
                    gridDt = _DataTableGrid4
                ElseIf grd.Name = "Grid5" Then
                    gridDt = _DataTableGrid5
                End If
                If gridDt Is Nothing Then Exit Sub
                _ActivatedColName = Trim(UCase(grd.Cell(0, grd.ActiveCell.Col).Tag))
                Dim ActivetextName As String = grd.Cell(grd.ActiveCell.Row, gridDt.Columns.IndexOf(_ActivatedColName) + 1).Text
                If grd.Rows - 1 = grd.ActiveCell.Row Then
                    grd.Rows = grd.Rows + 1
                    Call Fill_Sr_No_Item(grd, gridDt)
                End If
                _savedefaultrowBlank(grd, gridDt)
                ApplyGridFormula(grd, gridDt)
                _GridColmTotal(grd, gridDt)
                RunActivatedColumnMasterSelection(_ActivatedColName, ActivetextName)
                SendKeys.Send("{TAB}")
            Else
                Dim ActivetextName As String = ctrl.Text
                RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)
                Me.SelectNextControl(ctrl, True, True, True, True)
            End If
        ElseIf e.KeyCode = Keys.Up Then
            If Not TypeOf ctrl Is FlexCell.Grid Then
                Dim ActivetextName As String = ctrl.Text
                Me.SelectNextControl(DirectCast(sender, Control), False, True, True, True)
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If Not TypeOf ctrl Is FlexCell.Grid Then
                Dim ActivetextName As String = ctrl.Text
                Me.SelectNextControl(ctrl, True, True, True, True)
            End If
        End If
    End Sub
    Private Sub RunActivatedColumnMasterSelection(ByVal ctrlmasterName As String, ByVal ActivetextName As String)
        For Each dr As DataRow In _MainColumTbl.Select("DataBaseColumn='" & ctrlmasterName & "'")
            Dim offmastercode As String = dr("OPPMASTERCODE").ToString()
            Dim masterName As String = dr("MASTERLIST").ToString()
            Dim ctrlNameStr As String = dr("CntrlName").ToString().Trim()
            Dim ctrl As Control = Me.Controls.Find(ctrlNameStr, True).FirstOrDefault()
            If offmastercode <> "" Then
                HandleMasterSelection(masterName, ctrlmasterName, offmastercode, ctrl, ActivetextName, "SINGLE")
            End If
        Next
    End Sub
    Private Sub _GridColmTotal(grd As FlexCell.Grid, dt As DataTable)
        Dim footerTop As Integer = grd.Top + grd.Height + 5
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.Controls(i) Is Label AndAlso Me.Controls(i).Name.StartsWith("lblTotal_") Then
                Me.Controls.RemoveAt(i)
            End If
        Next
        lblTotalText.Name = "lblTotal_Text"
        lblTotalText.Text = "Total"
        lblTotalText.Top = footerTop
        lblTotalText.Left = grd.Left
        lblTotalText.Width = 80
        lblTotalText.Font = New Font("Tahoma", 9, FontStyle.Bold)
        Me.Controls.Add(lblTotalText)
        Dim total As Double = 0
        Dim startLeft As Integer = grd.Left + 500
        Dim gap As Integer = 120
        Dim iCol As Integer = 0
        Dim isAnyTotalAvailable As Boolean = False
        If allowedTotalCols_Grid_1 IsNot Nothing AndAlso allowedTotalCols_Grid_1.Count > 0 Then
            For Each col As String In allowedTotalCols_Grid_1
                total = 0
                Dim colIndex As Integer = dt.Columns.IndexOf(col)
                If colIndex < 0 Then Continue For
                Dim gridColIndex As Integer = colIndex + 1
                For i As Integer = 1 To grd.Rows - 1
                    Dim GetValuegval = Val(grd.Cell(i, gridColIndex).Text)
                    total += GetValuegval
                Next
                Dim lbl As New Label()
                SetTotalObjectPosition(col, _DataTableGrid1, grd, lbl, lblTotalText)
                lbl.Name = "lblTotal_" & col
                lbl.Text = total.ToString("0.00")
                lbl.Top = footerTop
                lbl.Width = 80
                lbl.TextAlign = ContentAlignment.MiddleRight
                lbl.Font = New Font("Verdana", 9, FontStyle.Bold)
                Me.Controls.Add(lbl)
                If lbl.Text = 0 Then
                    lbl.Visible = False
                Else
                    lbl.Visible = True
                    isAnyTotalAvailable = True
                End If
                iCol += 1
            Next
            If isAnyTotalAvailable Then
                lblTotalText.Visible = True
                lblTotalText.Text = "Total"
            Else
                lblTotalText.Visible = False
            End If
        Else
            lblTotalText.Text = ""
            lblTotalText.Visible = False
        End If
    End Sub
    Private Sub ApplyGridFormula(grd As FlexCell.Grid, dt As DataTable)
        Dim formulaStr As String = GetQuery(tmptbl, "GRIDCOLUMMULTIPLY", "TOTAL COLUMN")
        If String.IsNullOrWhiteSpace(formulaStr) Then Exit Sub
        Dim formulas() As String = formulaStr.Split(","c)
        For Each formula As String In formulas
            formula = formula.Trim()
            If formula = "" Then Continue For
            Dim parts() As String = formula.Split("="c)
            If parts.Length <> 2 Then Continue For
            Dim leftPart As String = parts(0).Trim()
            Dim resultColName As String = parts(1).Trim()
            Dim operands() As String = leftPart.Split("*"c)
            If operands.Length <> 2 Then Continue For
            Dim col1Name As String = operands(0).Trim()
            Dim col2Name As String = operands(1).Trim()
            Dim col1 = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = col1Name.ToLower())
            Dim col2 = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = col2Name.ToLower())
            Dim colResult = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = resultColName.ToLower())
            If col1 Is Nothing Or col2 Is Nothing Or colResult Is Nothing Then Continue For
            Dim colIndex1 As Integer = dt.Columns.IndexOf(col1.ColumnName) + 1
            Dim colIndex2 As Integer = dt.Columns.IndexOf(col2.ColumnName) + 1
            Dim colResultIndex As Integer = dt.Columns.IndexOf(colResult.ColumnName) + 1
            Dim total As Double = 0
            For i As Integer = 1 To grd.Rows - 1
                Dim val1 As Double = 0
                Dim val2 As Double = 0
                Double.TryParse(grd.Cell(i, colIndex1).Text, val1)
                Double.TryParse(grd.Cell(i, colIndex2).Text, val2)
                Dim result As Double = val1 * val2
                grd.Cell(i, colResultIndex).Text = result.ToString("")
                grd.Cell(i, colResultIndex).Locked = True
            Next
            If total = 0 Then
                grd.Cell(grd.Rows - 1, colResultIndex).Text = ""
                grd.Cell(grd.Rows - 1, colResultIndex).Locked = True
            Else
                grd.Cell(grd.Rows - 1, colResultIndex).Text = total.ToString("0.00")
                grd.Cell(grd.Rows - 1, colResultIndex).Locked = True
            End If
            grd.Cell(grd.Rows - 1, colResultIndex).Locked = True
        Next
    End Sub
    Private Sub _savedefaultrowBlank(grd As FlexCell.Grid, dt As DataTable)
        Dim formulaStr As String = GetQuery(tmptbl, "SAVEMEDETORYCOLUMNNAME", "TOTAL COLUMN")
        If String.IsNullOrWhiteSpace(formulaStr) Then Exit Sub
        mandatoryCol = formulaStr.Trim().ToUpper()
        If String.IsNullOrWhiteSpace(mandatoryCol) Then Exit Sub
        For r As Integer = 1 To grd.Rows - 1
            Dim isRowBlank As Boolean = True
            For c As Integer = 1 To grd.Cols - 1
                Dim val As String = grd.Cell(r, c).Text.Trim()
                If val <> "" AndAlso val <> "0" AndAlso val <> "0.00" Then
                    isRowBlank = False
                    Exit For
                End If
            Next
            If isRowBlank Then Continue For
            For c As Integer = 1 To grd.Cols - 1
                If grd.Cell(0, c).Text.ToUpper() = mandatoryCol Then
                    Dim val As String = grd.Cell(r, c).Text.Trim()
                    If val = "" Then
                        grd.Cell(r, c).Text = "0"
                    End If
                End If
            Next
        Next
    End Sub

#Region "FILL SR NO"
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
        Next
    End Sub
#End Region
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

    Private Function _GetMaxEntryNo()
        Try
            Dim ENTRYNO As Int64 = 0
            Dim Tbltmp As DataTable
            Dim _strquery As New StringBuilder
            Dim ControlName As String = ""
            Dim controlTableRows() As DataRow = _MainColumTbl.Select("DataBaseColumn = 'ENTRYNO' AND " & "DataBaseTable IS NOT NULL AND DataBaseTable <> ''")
            If controlTableRows.Length > 0 Then
                ControlName = controlTableRows(0)("CntrlName").ToString().Trim()
            Else
                ControlName = ""
            End If
            If ControlName <> "" Then
                controlTableRows = _MainColumTbl.Select("CntrlName='" & ControlName.Replace("'", "''") & "' AND " & "DataBaseTable IS NOT NULL AND DataBaseTable<>''")
                If controlTableRows.Length > 0 Then
                    _TblName = controlTableRows(0)("DataBaseTable").ToString().Trim()
                Else
                    _TblName = ""
                End If
            Else
                _TblName = ""
            End If
            If String.IsNullOrWhiteSpace(_TblName) Then
                Return 0
            End If
            sqL = "SELECT TOP 1 ENTRYNO FROM " & _TblName & " WHERE BOOKCODE='" & _Bookcode.Replace("'", "''") & "' ORDER BY ENTRYNO DESC"
            sql_connect_slect()
            Tbltmp = DefaltSoftTable.Copy
            If Tbltmp.Rows.Count > 0 Then
                If Not IsDBNull(Tbltmp.Rows(0).Item(0)) Then
                    ENTRYNO = Val(Tbltmp.Rows(0).Item(0))
                End If
            End If
            Return ENTRYNO
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        End Try
    End Function
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
    Public Sub LoadViewData(ByVal tmptbl As DataTable, ByVal _Bookcode As String)
        Try
            'Generate_Date_For_DataBase(Txt_ViewFrom)
            'Generate_Date_For_DataBase(Txt_ViewTO)
            Dim ResultTable As New DataTable
            If tmptbl IsNot Nothing AndAlso tmptbl.Rows.Count > 0 AndAlso Not tmptbl.Columns.Contains("Mainid") Then
                ResultTable = tmptbl.Copy()
            Else
                Dim UseChallanFilter1 As String = " '" & _Bookcode & "' "
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
                GridControl1.DataSource = Nothing
                GridControl1.DataSource = ResultTable.Copy()
                ' Checkbox Row Selection
                FirstStage.OptionsSelection.MultiSelect = True
                FirstStage.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect

                FirstStage.OptionsSelection.EnableAppearanceFocusedCell = False
                FirstStage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
                AddHandler FirstStage.KeyDown, AddressOf FirstStage_KeyDown
                DevGridFitColumn(GridControl1, FirstStage)
                Dim SelectedData As New DataTable
                SelectedData = CType(GridControl1.DataSource, DataTable).Clone()
                Dim selectedRows() As Integer = FirstStage.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        Dim row As DataRow = FirstStage.GetDataRow(rowHandle)
                        If row IsNot Nothing Then
                            SelectedData.ImportRow(row)
                        End If
                    End If
                Next
                FirstStage.OptionsView.ShowFooter = True
                PnlGrdView.Visible = True
                BtnPrint.Visible = True
                BtnExport.Visible = True
                FirstStage.BestFitColumns()
                FirstStage.Focus()
                PnlGrdView.BringToFront()
                GridControl1.BringToFront()
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End Try
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
        'If e.KeyCode = Keys.Space Then
        '    e.Handled = True
        '    e.SuppressKeyPress = True
        '    Dim rowHandle As Integer = FirstStage.FocusedRowHandle
        '    If rowHandle >= 0 Then
        '        If FirstStage.IsRowSelected(rowHandle) Then
        '            FirstStage.UnselectRow(rowHandle)
        '        Else
        '            FirstStage.SelectRow(rowHandle)
        '        End If
        '    End If
        'End If
        If e.KeyCode = Keys.F12 Then
            e.Handled = True
            Dim SelectedData As New DataTable
            SelectedData = CType(GridControl1.DataSource, DataTable).Clone()
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
                ' Selected Data ko Header aur Grid me Fill karna
                Fill_SelectedData_To_Form(SelectedData)
                ' Selected Data
                'MessageBox.Show("Selected Rows: " & SelectedData.Rows.Count)
            Else
                MessageBox.Show("Please Select At Least One Row.")
            End If
        End If
    End Sub
    Private Sub Fill_SelectedData_To_Form(ByVal SelectedData As DataTable)
        Try
            Dim TableNames As New List(Of Tuple(Of String, String, String))
            'For Each dr As DataRow In _MainColumTbl.Select("DataBaseTable IS NOT NULL AND DataBaseTable<>''")
            For Each dr As DataRow In _MainColumTbl.Select("DataBaseTable IS NOT NULL AND DataBaseTable<>''", "Id ASC")
                Dim TableName As String = dr("DataBaseTable").ToString().Trim()
                Dim ColumnType As String = dr("ColumnType").ToString().Trim()
                Dim ctrlName As String = dr("CntrlName").ToString().Trim()
                If TableName <> "" Then
                    Dim Exists As Boolean = TableNames.Any(Function(x) _
                        x.Item1.Equals(TableName, StringComparison.OrdinalIgnoreCase) AndAlso
                        x.Item2.Equals(ColumnType, StringComparison.OrdinalIgnoreCase) AndAlso
                        x.Item3.Equals(ctrlName, StringComparison.OrdinalIgnoreCase))
                    If Not Exists Then
                        TableNames.Add(Tuple.Create(TableName, ColumnType, ctrlName))
                    End If
                End If
            Next
            For Each item In TableNames
                Dim TableName As String = item.Item1
                Dim FiltColumnType As String = item.Item2
                Dim ctrlName As String = item.Item3
                If FiltColumnType = "TextBox" Then
                    ' Header TextBox me SelectedData ki First Row Fill
                    If SelectedData.Rows.Count > 0 Then
                        Fill_Selected_Header(SelectedData.Rows(0))
                    End If
                ElseIf FiltColumnType = "Grid" Then
                    ' Selected Data Grid me Fill
                    Dim tblTmp As DataTable = SelectedData.Copy()
                    Dim grd As FlexCell.Grid = Nothing
                    Dim gridname As String = ctrlName
                    If Me.Controls.ContainsKey(gridname) Then
                        grd = TryCast(Me.Controls(gridname), FlexCell.Grid)
                    End If
                    If grd Is Nothing Then Continue For
                    Dim _GridColmName As String() = Nothing
                    Dim currentGridTable As DataTable = Nothing
                    Select Case ctrlName.ToUpperInvariant()
                        Case "GRID1"
                            _GridColmName = Grid1_Table_ColNames
                            currentGridTable = _DataTableGrid1
                        Case "GRID2"
                            _GridColmName = Grid2_Table_ColNames
                            currentGridTable = _DataTableGrid2
                        Case "GRID3"
                            _GridColmName = Grid3_Table_ColNames
                            currentGridTable = _DataTableGrid3
                        Case "GRID4"
                            _GridColmName = Grid4_Table_ColNames
                            currentGridTable = _DataTableGrid4
                        Case "GRID5"
                            _GridColmName = Grid5_Table_ColNames
                            currentGridTable = _DataTableGrid5
                    End Select

                    If _GridColmName Is Nothing Then Continue For
                    If tblTmp.Rows.Count > 0 Then
                        grd.Range(0, 0, grd.Rows - 1, grd.Cols - 1).DeleteByRow()
                        Fill_Records(tblTmp, _GridColmName, grd, 0, True, "", False)
                        grd.Rows = grd.Rows + 1
                        Fill_Sr_No_Item(grd, currentGridTable)
                        CalculateDynamicColumnTotal(grd, currentGridTable, tblTmp)
                        ApplyGridFormula(grd, currentGridTable)
                        _GridColmTotal(grd, currentGridTable)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        End Try

    End Sub
    Private Sub Fill_Selected_Header(ByVal selectedRow As DataRow)

        For Each ctrl As Control In GetAllControls(Me)

            If TypeOf ctrl Is TextBox Then

                Dim txt As TextBox = DirectCast(ctrl, TextBox)

                Dim columnName As String = txt.AccessibleDescription

                If String.IsNullOrWhiteSpace(columnName) Then
                    columnName = Convert.ToString(txt.Tag)
                End If

                If selectedRow.Table.Columns.Contains(columnName) Then

                    txt.Text = Convert.ToString(selectedRow(columnName))

                End If

            End If

        Next

    End Sub
    Private Iterator Function GetAllControls(parent As Control) As IEnumerable(Of Control)

        For Each ctrl As Control In parent.Controls

            Yield ctrl

            For Each child As Control In GetAllControls(ctrl)
                Yield child
            Next

        Next

    End Function
End Class