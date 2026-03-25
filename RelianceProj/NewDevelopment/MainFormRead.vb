Imports System.Text
Imports DevExpress.XtraEditors.TextEditController.Win32
Imports DevExpress.XtraGrid.Views
Imports FlexCell

Public Class MainFormRead
    Private _DatabaseTableName = "FormControl"
    Dim _ActivatedColName As String = ""

    Dim _MainColumTbl As New DataTable
    Dim isDragging As Boolean = False
    Dim dragOffset As POINT
    Dim _TableName As String = ""
    Dim _TblName As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = ""
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

    'Private _UniqueDisplayValues As New List(Of String)
    'Private _UniqueCodeValues As New List(Of String)
    Private _UniqueValues As New List(Of Tuple(Of String, String, String))
    Dim FormId As String = "0"
    Dim Id As String = "0"

    Dim _OldFormListtbl As New DataTable
    Private _DefaultColOfGrid As Integer = 0


    'Dim Grid1 As New FlexCell.Grid()
    Private _DataTableGrid1 As New DataTable
    Private Grid1_Table_ColNames() As String
    Private _Grid1ColNames As New StringBuilder
    Private _Grid1LastColNo As Integer = 0
    Private _Grid1ColType As New StringBuilder


    Private _DataTableGrid2 As New DataTable
    Private _DataTableGrid3 As New DataTable
    Private _DataTableGrid4 As New DataTable
    Private _DataTableGrid5 As New DataTable
    Private _RowNo As Integer
    Private _ColNo As Integer

    Private UC_Buttons1 As UC_Buttons
    Private _FORMMODE As String = ""
    Private _FrmLoad As Boolean = True
    Private Change_Grid_Data As Boolean = True
    Dim txtEntryno As String = ""
    Public MainLoadFormName As String = ""


    Dim _Bookcode As String = ""
    Dim _Booktrtype As String = ""
    Dim _BookVNo As String = ""

    Dim _FormCloseMode As Boolean = False
    Public Property FormNameValue As String
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



    Private Sub MainFormRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _FORMMODE = "LOAD"
        _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        Me.KeyPreview = True
        Me.Location = New POINT(0, 0)
        _FrmLoad = True
        CreateButtonsControl()
        AttachButtonFocusEvents(Me)
        PnlGrdView.Width = Me.Width
        PnlGrdView.Height = Me.Height
        PnlGrdView.Location = New POINT(0, 0)
        GridControl1.Width = PnlGrdView.Width - 25
        GridControl1.Height = PnlGrdView.Height - 100
        GridControl1.Location = New POINT(3, 53)
        _LoadDefaultData()
        Dim grd As FlexCell.Grid = TryCast(Me.Controls("Grid1"), FlexCell.Grid)
        If grd Is Nothing Then Exit Sub
        ApplyGridFormula(grd, _DataTableGrid1)
        Ctrl_Visible_False(Me.Controls)
        _FrmLoad = False
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
        CalculateDynamicColumnTotal(grd, _DataTableGrid1, tmptbl)
    End Sub



    Private Sub CreateButtonsControl()
        UC_Buttons1 = New UC_Buttons()
        With UC_Buttons1
            .Name = "UC_Buttons1"
            .Dock = DockStyle.Bottom
            .Visible = True
        End With
        Me.Controls.Add(UC_Buttons1)
        UC_Buttons1.BringToFront()
        AddHandler UC_Buttons1.AddClick, AddressOf UC_Buttons1_AddClick
        AddHandler UC_Buttons1.EditClick, AddressOf UC_Buttons1_EditClick
        AddHandler UC_Buttons1.DeleteClick, AddressOf UC_Buttons1_DeleteClick
        AddHandler UC_Buttons1.BackClick, AddressOf UC_Buttons1_BackClick
        AddHandler UC_Buttons1.NextClick, AddressOf UC_Buttons1_NextClick
        AddHandler UC_Buttons1.SaveClick, AddressOf UC_Buttons1_SaveClick
        AddHandler UC_Buttons1.CloseClick, AddressOf UC_Buttons1_CloseClick
        AddHandler UC_Buttons1.ViewClick, AddressOf UC_Buttons1_ViewClick
        AddHandler UC_Buttons1.PrintClick, AddressOf UC_Buttons1_PrintClick
        AddHandler UC_Buttons1.ReportsClick, AddressOf UC_Buttons1_ReportsClick
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnPrint", "BtnReports")
    End Sub
#Region "Button Click"
    Private Sub UC_Buttons1_AddClick()
        Change_Grid_Data = True
        _FormCloseMode = False
        _FORMMODE = "ADD"
        _FrmLoad = False
        'Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            _BookVNo = ""
            Ctrl_Visible_True(Me.Controls)
            _LoadDefaultData()
            _GridEnable()
            'Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)

            'If ctrl.Length > 0 Then
            '    Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
            '    Entytxt.Focus()
            'End If
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_EditClick()
        _FORMMODE = "EDIT"
        _FrmLoad = False
        _FormCloseMode = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "EDIT" Then
            'txtFormName.Focus()
            Ctrl_Visible_True(Me.Controls)
            _LoadDefaultData()
            _GridEnable()
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub

    Private Function Alter_EntryForm(ByVal Entryno As String) As DataTable
        _FrmLoad = True
        Dim tblTmp As New DataTable
        Dim _strquery As New StringBuilder
        strQuery = getAlter_Form_EntryQuery(Entryno)
        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)
        For Each dr As DataRow In _MainColumTbl.Select("Columntype='TextBox'  AND (UseMaster='NO' OR (UseMaster='YES'AND (OppMasterCode<>'' or OppMasterCode='')))")
            Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
            Dim ctrlName As String = dr("CntrlName").ToString().Trim()
            Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
            Dim UseMaster As String = dr("UseMaster").ToString().Trim()
            Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
            Dim ctrl As Control = Me.Controls.Find(ctrlName, True).FirstOrDefault()
            If ctrl Is Nothing OrElse Not TypeOf ctrl Is TextBox Then Continue For
            Dim txt As TextBox = DirectCast(ctrl, TextBox)
            Dim value As String = txt.Text.Trim().Trim("'"c)
            If _InputType = "DateBox" Then
                value = Convert.ToDateTime(value).ToString("dd/MM/yyyy")
                txt.Text = value
            End If

            If UseMaster = "YES" Then
                'For Each dr1 As DataRow In tblTmp.Select()
                '    'Dim _HeaderNAme As String = dr("UserText").ToString()
                '    'Dim _HeaderNAme As String = dr("Text").ToString()
                '    'txt.Text = dr1(_HeaderNAme).ToString
                'Next
                Dim ActivetextName As String = ctrl.Text
                RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)
                Me.SelectNextControl(ctrl, True, True, True, True)
            End If
        Next
        If tblTmp.Rows.Count > 0 Then
            _BookVNo = tblTmp.Rows(0).Item("bookvno").ToString
        End If
        _FrmLoad = False
        Return tblTmp   ' 👈 yaha return kar diya
    End Function

    Private Sub UC_Buttons1_DeleteClick()
        _FrmLoad = True
        _FormCloseMode = False
        _FORMMODE = "DELETE"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "DELETE" Then
            'txtFormName.Focus()
        End If
        Dim EntryNo As Integer
        EntryNo = _GetMaxEntryNo()
        If EntryNo > 0 Then
            Dim txt As New TextBox()
            txt.Text = EntryNo
            txtEntryno = txt.Text
            Ctrl_Visible_True(Me.Controls)
        End If
        If MsgBox("Do You Want To Delete (Y/N)",
              MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              "Delete ?") = MsgBoxResult.Yes Then
            Call Delete_Entry()
        End If
        ObjCls_General.Blank_Object(Me)
        Ctrl_Visible_False(Me.Controls)
        Change_Grid_Data = True
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_BackClick()
        _FrmLoad = False
        _FormCloseMode = False
        If _FORMMODE = "EDIT" Then
            Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
            If ctrl.Length > 0 Then
                Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                If Entytxt.Text = "" Then
                Else
                    _GetAlterData(Entytxt.Text - 1)
                End If
            End If
        End If
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_NextClick()
        _FrmLoad = False
        _FormCloseMode = False
        If _FORMMODE = "EDIT" Then
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
            Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
            If ctrl.Length > 0 Then
                Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                If Entytxt.Text = "" Then
                Else
                    _GetAlterData(Entytxt.Text + 1)
                End If
            End If
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_SaveClick()
        Dim EntryNo As String = ""
        _FrmLoad = False
        Dim Array_Opening(0, 4) As String
        Dim formType As String = ""
        Dim LASTCODE As String = ""
        If _MainColumTbl.Rows.Count > 0 Then
            formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
        End If
        If formType = "ENTRY FORM" Then
            Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
            If ctrl.Length > 0 Then
                Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                sqL = "DELETE FROM " & _TblName & " WHERE BOOKCODE='" & _Bookcode & "' AND ENTRYNO =" & Entytxt.Text & "  "
                sql_Data_Save_Delete_Update()
            End If
            Call Fill_Grid_Records_Into_DataTables()
            GridDetailsSaveQuery(Array_Opening)
            For I = 0 To UBound(Array_Opening)
                If Array_Opening(I, 4) <> "" Then
                    strQuery = Array_Opening(I, 4)
                    sqL = strQuery.ToString
                    sql_Data_Save_Delete_Update()
                End If
            Next
            Dim Pcs_Row_No As Integer = 0
            Interaction.MsgBox("Records Successfully Saved",
                       MsgBoxStyle.Information,
                       "Soft-Tex PRO")
            ObjCls_General.Blank_Object(Me)
            For Each dr As DataRow In _MainColumTbl.Select("Columntype='Grid'")
                Dim gridname As String = dr("CntrlName").ToString().Trim()
                Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(gridname, True).FirstOrDefault(), FlexCell.Grid)
                If grd IsNot Nothing Then
                    Clear_Grid(grd, 2)
                End If
                'CalculateDynamicColumnTotal(grd, _DataTableGrid1, tmptbl)
                _GridColmTotal(grd, _DataTableGrid1)
            Next
        End If

        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub
    Private Sub UC_Buttons1_CloseClick()

        If _FORMMODE = "" Then
            Me.Close()
            Exit Sub
        End If

        Me.Close()
        Me.Dispose(True)

    End Sub
    Private Sub UC_Buttons1_ViewClick()
        _FrmLoad = False
        _FORMMODE = "VIEW"
        _FormCloseMode = False
        Dim _BookName As String = ""
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "VIEW" Then
            Ctrl_Visible_True(Me.Controls)
        End If

        Txt_ViewFrom.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        Txt_ViewTO.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        _LoadDefaultData()
        '_GridEnable()
        LoadViewData(tmptbl, _Bookcode)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_PrintClick()
        _FORMMODE = "PRINT"
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ' print logic yahan add kar sakte ho
    End Sub
    Private Sub UC_Buttons1_ReportsClick()
        _FORMMODE = "REPORTS"
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ' reports logic yahan add kar sakte ho
    End Sub
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click

    End Sub

    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        LoadViewData(tmptbl, _Bookcode)
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = " Report From :" & Txt_ViewFrom.Text & " To : " & Txt_ViewTO.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#End Region
#Region "QUERY SECTION"
    Private Function getAlter_Form_EntryQuery(ByVal EntryNo As String) As String
        Dim leftJoin As String = ""
        Dim joinHeader As String = ""
        For Each dr As DataRow In _MainColumTbl.Select("USEMASTER='YES' and MasterList > ''")
            Dim _DatabaseHeaderName As String = dr("UserText").ToString()
            'Dim _DatabaseHeaderName As String = dr("Text").ToString()
            Dim _OppositCode As String = dr("OppMasterCode").ToString()
            Dim _SelectionMastrName As String = dr("MasterList").ToString()
            Dim res = GetAccountMaster(_DatabaseHeaderName, _OppositCode, _SelectionMastrName)
            leftJoin = res.LeftJoin
            joinHeader = res.JoinHeader
        Next
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*  ")
            .Append(joinHeader)
            .Append(" FROM " & _TblName & " as A ")
            .Append(leftJoin)
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _Bookcode & "'  ")
            .Append(" And A.EntryNo=" & EntryNo & "")
            .Append(" ORDER BY EntryNo DESC")
        End With
        Return _strQuery.ToString
    End Function
#End Region
    Private Sub Fill_Grid_Records_Into_DataTables()
        Try
            'Dim FieldDr As DataRow
            '--- Fill Items Grid Records -----------
            _DataTableGrid1.Rows.Clear()
            _DataTableGrid2.Rows.Clear()
            _DataTableGrid3.Rows.Clear()
            _DataTableGrid4.Rows.Clear()
            _DataTableGrid5.Rows.Clear()

            Dim gridTableMap As New Dictionary(Of String, DataTable) From {
        {"Grid1", _DataTableGrid1},
        {"Grid2", _DataTableGrid2},
        {"Grid3", _DataTableGrid3},
        {"Grid4", _DataTableGrid4},
        {"Grid5", _DataTableGrid5}
    }

            Dim distinctGrids = _MainColumTbl.AsEnumerable().Where(Function(r) r("Columntype").ToString() = "Grid").Select(Function(r) r("CntrlName").ToString()).Distinct()
            For Each gridname As String In distinctGrids
                Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(gridname, True).FirstOrDefault(), FlexCell.Grid)
                If grd Is Nothing Then Continue For
                If Not gridTableMap.ContainsKey(gridname) Then Continue For
                Dim dt As DataTable = gridTableMap(gridname)
                dt.Rows.Clear()
                For i As Integer = 1 To grd.Rows - 1
                    If Val(grd.Cell(i, _DataTableGrid1.Columns.IndexOf(mandatoryCol) + 1).Text) > 0 Then
                        Dim FieldDr As DataRow = dt.NewRow()
                        Dim isRowBlank As Boolean = True
                        For j As Integer = 1 To grd.Cols - 1
                            Dim cellValue As String = grd.Cell(i, j).Text.Trim()
                            If cellValue <> "" Then
                                isRowBlank = False
                            End If
                            If dt.Columns(j - 1).DataType IsNot GetType(String) Then
                                FieldDr(j - 1) = If(cellValue = "", DBNull.Value, Val(cellValue))
                            Else
                                FieldDr(j - 1) = cellValue
                            End If
                        Next
                        If Not isRowBlank Then
                            dt.Rows.Add(FieldDr)
                        End If
                    Else
                        Dim FieldDr As DataRow = dt.NewRow()
                        Dim isRowBlank As Boolean = True
                        For j As Integer = 1 To grd.Cols - 1
                            Dim cellValue As String = grd.Cell(i, j).Text.Trim()
                            If cellValue <> "" Then
                                isRowBlank = False
                            End If
                            If dt.Columns(j - 1).DataType IsNot GetType(String) Then
                                FieldDr(j - 1) = If(cellValue = "", DBNull.Value, Val(cellValue))
                            Else
                                FieldDr(j - 1) = cellValue
                            End If
                        Next
                        If Not isRowBlank Then
                            dt.Rows.Add(FieldDr)
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        Try
            _FieldNotVisibile = New StringBuilder()
            '------------------------ DETAILS Table --------------------------------
            Dim strFilterString As String = ""
            Dim QueryDetailTable As String = ""
            'Dim Query_Auto_Grid(_DataTableGrid1.Rows.Count, 4) As String
            Dim tables As New List(Of DataTable) From {
        _DataTableGrid1,
        _DataTableGrid2,
        _DataTableGrid3,
        _DataTableGrid4,
        _DataTableGrid5
    }
            Dim totalRows As Integer = tables.Sum(Function(t) If(t IsNot Nothing, t.Rows.Count, 0))
            If totalRows = 0 Then
                Exit Function
            End If
            Dim Query_Auto_Grid(totalRows - 1, 4) As String
            Dim rowIndex As Integer = 0
            'For Each dt As DataTable In tables
            '    If dt IsNot Nothing Then
            '        For Each dr As DataRow In dt.Rows
            '            Query_Auto_Grid(rowIndex, 0) = dr(0).ToString()
            '            Query_Auto_Grid(rowIndex, 1) = dr(1).ToString()
            '            Query_Auto_Grid(rowIndex, 2) = dr(2).ToString()
            '            Query_Auto_Grid(rowIndex, 3) = dr(3).ToString()
            '            Query_Auto_Grid(rowIndex, 4) = dr(4).ToString()
            '            rowIndex += 1
            '        Next
            '    End If
            'Next
            For Each dt As DataTable In tables
                If dt Is Nothing OrElse dt.Rows.Count = 0 Then Continue For
                For Each dr As DataRow In dt.Rows
                    If rowIndex >= totalRows Then Exit For
                    For colIndex As Integer = 0 To 4
                        If colIndex < dt.Columns.Count Then
                            Query_Auto_Grid(rowIndex, colIndex) = dr(colIndex).ToString()
                        Else
                            Query_Auto_Grid(rowIndex, colIndex) = ""
                        End If
                    Next
                    rowIndex += 1
                Next
                If rowIndex >= totalRows Then Exit For
            Next
            If mandatoryCol <> "" Then
                strFilterString = mandatoryCol & ">0"
            End If
            Dim _extrafielddatatable As New StringBuilder()
            Dim _extrafield_values_datatable As New StringBuilder()
            For Each dr As DataRow In _MainColumTbl.Select("Columntype='TextBox' AND (UseMaster='NO' OR (UseMaster='YES'AND (OppMasterCode<>'' or OppMasterCode='')))")
                If _BookVNo = "" Then
                    _BookVNo = Generate_Book_Vno(Val(txtEntryno), _Booktrtype)
                End If
                _TableName = dr("DataBaseTable").ToString().Trim()
                Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
                Dim ctrlName As String = dr("CntrlName").ToString().Trim()
                Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
                Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
                Dim ctrl As Control = Me.Controls.Find(ctrlName, True).FirstOrDefault()
                If ctrl Is Nothing OrElse Not TypeOf ctrl Is TextBox Then Continue For
                Dim txt As TextBox = DirectCast(ctrl, TextBox)
                _extrafielddatatable.Append(columnName & ",")
                Dim value As String = txt.Text.Trim().Trim("'"c)
                If _InputType = "DateBox" Then
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd")
                End If

                If value = "" Then
                    _extrafield_values_datatable.Append(value & ",")
                ElseIf IsNumeric(value) Then
                    _extrafield_values_datatable.Append(value & ",")
                Else
                    If existingItem IsNot Nothing Then
                        _extrafield_values_datatable.Append("" & value.Replace("'", "''") & ",")
                    Else
                        _extrafield_values_datatable.Append("" & value.Replace("'", "''") & ",")
                    End If
                End If
                ' 🔹 OppMasterCode Column Add (If Exists)
                If existingItem IsNot Nothing Then
                    Dim oppColumnName As String = existingItem.Item2   ' OppMasterCode
                    Dim codeValue As String = existingItem.Item3       ' CodeValue
                    If Not String.IsNullOrWhiteSpace(oppColumnName) Then
                        _extrafielddatatable.Append(oppColumnName & ",")
                        If String.IsNullOrWhiteSpace(codeValue) Then
                            _extrafield_values_datatable.Append("NULL,")
                        ElseIf IsNumeric(codeValue) Then
                            _extrafield_values_datatable.Append(codeValue & ",")
                        Else
                            _extrafield_values_datatable.Append("" & codeValue.Replace("'", "''") & ",")
                        End If
                    End If
                End If
            Next
            ' 🔹 Add BookVno
            _extrafielddatatable.Append("BookVno,")
            _extrafield_values_datatable.Append("" & _BookVNo.Replace("'", "''") & ",")

            ' 🔹 Add BookCode
            _extrafielddatatable.Append("BookCode,")
            _extrafield_values_datatable.Append("" & _Bookcode.Replace("'", "''") & ",")

            ' 🔹 Add BookTrType
            _extrafielddatatable.Append("BookTrType,")
            _extrafield_values_datatable.Append("" & _Booktrtype.Replace("'", "''") & ",")
            ' 🔹 Remove last comma safely (ONLY ONCE)
            If _extrafielddatatable.Length > 0 Then
                _extrafielddatatable.Length -= 1
            End If

            If _extrafield_values_datatable.Length > 0 Then
                _extrafield_values_datatable.Length -= 1
            End If
            QueryDetailTable = ObjCls_General.GetQueryArray(_TableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid1, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _extrafielddatatable.ToString.ToUpper, _extrafield_values_datatable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
            GridDetailsSaveQuery = QueryDetailTable & ""
            arr_object = Query_Auto_Grid
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Function

    Public Sub LoadViewData(ByVal tmptbl As DataTable, ByVal _Bookcode As String)
        Generate_Date_For_DataBase(Txt_ViewFrom)
        Generate_Date_For_DataBase(Txt_ViewTO)
        'Txt_ViewFrom.Focus()
        'Txt_ViewFrom.Select()
        Dim FilterBookcode As String = " '" & _Bookcode & "' "
        Dim FilterFrom As String = "'" & Txt_ViewFrom.Date_for_Database & "'"
        Dim FilterTO As String = " '" & Txt_ViewTO.Date_for_Database & "'"
        ' 🔹 Queries Read
        Dim ViewQuery As String = GetQuery(tmptbl, "VIEWQUERY", "VIEW")
        If ViewQuery = "" Then
            If MainLoadFormName = "" Then
                Exit Sub
            Else
                MsgBox("View Query Not Found")
                Exit Sub
            End If
        End If
        ViewQuery = ViewQuery.Replace("FilterBookcode", FilterBookcode)
        ViewQuery = ViewQuery.Replace("FilterFrom", FilterFrom)
        ViewQuery = ViewQuery.Replace("FilterTO", FilterTO)
        sqL = ViewQuery
        sql_connect_slect()
        Dim ResultTable As New DataTable
        ResultTable = DefaltSoftTable.Copy
        FirstStage.Columns.Clear()
        If ResultTable.Rows.Count > 0 Then
            GridControl1.DataSource = ResultTable.Copy
            DevGridFitColumn(GridControl1, FirstStage)
            FirstStage.OptionsView.ShowFooter = True
            Dim ViewQueryTotal As String = GetQuery(tmptbl, "ViewGridColumnTotal", "VIEW")
            Dim ColumnList As String = ViewQueryTotal
            Dim Columns() As String = ColumnList.Split(","c)
            For Each col As String In Columns
                If FirstStage.Columns.ColumnByFieldName(col) IsNot Nothing Then
                    'Total
                    FirstStage.Columns(col).Summary.Clear()
                    FirstStage.Columns(col).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col, "{0:n2}")
                End If
            Next
            ViewQueryTotal = GetQuery(tmptbl, "ViewGridColumnHide", "VIEW")
            ColumnList = ViewQueryTotal
            Dim HideColumns() As String = ColumnList.Split(","c)
            For Each col As String In HideColumns
                If FirstStage.Columns.ColumnByFieldName(col) IsNot Nothing Then
                    'Hide
                    FirstStage.Columns(col).Visible = False
                End If
            Next
            PnlGrdView.Visible = True
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            PnlGrdView.BringToFront()
            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            'txtFormName.Focus()
        End If
    End Sub

    Private Sub Delete_Entry()
        _FrmLoad = True
        Dim I As Integer = 0
        Dim _LastID As Integer = 0
        _strQuery = New StringBuilder
        Try
            Dim EntryNO As String = _GetMaxEntryNo()
            If EntryNO > 0 Then
                strQuery = "DELETE FROM " & _TblName & " WHERE   BOOKCODE='" & _Bookcode & "'  AND EntryNo='" & EntryNO & "' "
            End If
            sqL = strQuery.ToString
            sql_connect_slect()
            '-----------------------------------------------------------------------
            '_FORMMODE = "ADD"
            MsgBox("Entry Successfully Deleted")
        Catch ex As Exception
            MsgBox("Error While Delete Entry")
        Finally
            cmd = Nothing
        End Try
        _FrmLoad = False
    End Sub
    Private Sub defineGridColName()
        _Grid1ColNames = New StringBuilder()
        _FieldHeader = New StringBuilder()
        _FieldHeaderAlignment = New StringBuilder()
        _FieldAlignMent = New StringBuilder()
        _FieldWidthSet = New StringBuilder()
        _FieldNotVisibile = New StringBuilder()
        _FieldLocked = New StringBuilder()
        _Grid1ColType = New StringBuilder()
        _FieldMasking = New StringBuilder()
        _FieldUsemaster = New StringBuilder()
        _Fieldmasterlist = New StringBuilder()
        _FieldNotRequiredForSave = New StringBuilder()
        If _MainColumTbl.Rows.Count > 0 Then

            For Each dr As DataRow In _MainColumTbl.Select("", "OrderNo")
                Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                Dim colType As String = dr("ColumnType").ToString().Trim()
                Dim header As String = dr("UserText").ToString().Trim()
                'Dim header As String = dr("Text").ToString().Trim()
                Dim alignVal As String = dr("TextAlign").ToString().Trim().ToUpper()
                If alignVal = "" Then alignVal = "L"
                If header = "" OrElse colName = "" Then
                    Continue For
                End If

                ' Grid Col Names
                If _Grid1ColNames.Length > 0 Then
                    _Grid1ColNames.Append(",")
                End If
                _Grid1ColNames.Append(colName)


                ' Field Header

                If header.Trim > "" Then
                    If _FieldHeader.Length > 0 Then
                        _FieldHeader.Append(",")
                    End If
                    _FieldHeader.Append(colName & ":" & header)
                End If
                ' Header Alignment
                If _FieldHeaderAlignment.Length > 0 Then
                    _FieldHeaderAlignment.Append(",")
                End If
                _FieldHeaderAlignment.Append(colName & ":" & alignVal)



                ' Field Alignment
                If _FieldAlignMent.Length > 0 Then
                    _FieldAlignMent.Append(",")
                End If
                _FieldAlignMent.Append(colName & ":" & alignVal)

                ' Width
                Dim widthVal As Int32 = dr("SizeWidth").ToString().Trim()
                If _FieldWidthSet.Length > 0 Then
                    _FieldWidthSet.Append(",")
                End If
                _FieldWidthSet.Append(colName & ":" & widthVal)

                ' Not Visible
                Dim visibleVal As String = dr("Visible").ToString().Trim().ToUpper()

                If header.Trim <> "" Then
                    If colType = "TextBox" Then
                        If visibleVal = "Y" Then
                            visibleVal = "N"
                        End If
                    End If
                    If _FieldNotVisibile.Length > 0 Then
                        _FieldNotVisibile.Append(",")
                    End If
                    _FieldNotVisibile.Append(colName & ":" & visibleVal)
                End If

                ' Locked
                Dim lockVal As String = dr("ReadOnly").ToString().Trim().ToUpper()
                If lockVal = "" Then lockVal = "N"
                If _FieldLocked.Length > 0 Then
                    _FieldLocked.Append(",")
                End If
                _FieldLocked.Append(colName & ":" & lockVal)

                ' Col Type
                Dim colInputType As String = dr("InputType").ToString().Trim().ToUpper()
                'Dim colType As String = dr("ColumnType").ToString().Trim().ToUpper()
                If colInputType = "NUMERIC" Then
                    colType = "N"
                    If _Grid1ColType.Length > 0 Then
                        _Grid1ColType.Append(",")
                    End If
                    _Grid1ColType.Append(colName & ":" & colType)
                End If

                ' Masking
                Dim prec As Integer = Val(dr("Masking"))
                If colInputType = "NUMERIC" Then
                    Dim maskVal As String = "NO-" & prec.ToString()
                    If _FieldMasking.Length > 0 Then
                        _FieldMasking.Append(",")
                    End If
                    _FieldMasking.Append(colName & ":" & maskVal)
                End If
                Dim notrequired As String = dr("SaveYN").ToString().Trim().ToUpper()
                If notrequired = "N" Then
                    If _FieldNotRequiredForSave.Length > 0 AndAlso Not _FieldNotRequiredForSave.ToString().EndsWith(",") Then
                        _FieldNotRequiredForSave.Append(",")
                    End If
                    _FieldNotRequiredForSave.Append(colName & ":" & notrequired)
                End If
                'default value set
                '_FieldDefaultValues = New StringBuilder
                'With _FieldDefaultValues
                '    .Append("Yarn_Rate:0,")
                '    .Append("pattern:0,")
                '    .Append("Avg_weight:0,")
                '    .Append("PROFIT_PER:0,")
                '    .Append("Yarn_Amount:0")
                '    .Append("VALUE_LOSS_PER_MTR:0")
                'End With
            Next
            Grid1_Table_ColNames = _Grid1ColNames.ToString.ToUpper.Split(",")
        End If
    End Sub
    Private Sub RemoveControlIfExists(ctrlName As String)

        Dim oldCtrl As Control = Me.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Name = ctrlName)
        If oldCtrl IsNot Nothing Then
            Me.Controls.Remove(oldCtrl)
            oldCtrl.Dispose()
        End If
    End Sub

    Private Sub View_Record()
        Try
            Dim EntryNo As Integer = 1
            Dim _Grid1ColNames = New StringBuilder()
            Dim View_Filter_Condition = " AND  FormName='" & MainLoadFormName & "' "
            If MainLoadFormName <> "" Then
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
                Dim _UseMasterTabl As New DataTable
                _UseMasterTabl = _MainColumTbl.Clone
                For Each dr As DataRow In _MainColumTbl.Select("USEMASTER='YES'")
                    _UseMasterTabl.ImportRow(dr)
                Next
#Region "Label or text box control visible form view"
                Dim _CntlMasterTabl As New DataTable
                _CntlMasterTabl = _MainColumTbl.Clone
                Dim topPos As Integer
                'Dim topPos As Integer = 20
                Dim leftPos As Integer
                Dim height As Integer
                Dim width As Integer
                'For Each dr As DataRow In _MainColumTbl.Select("CntrlId <> ''")
                For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                    Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
                    Dim usemasterkey As String = dr("USEMASTERKEY").ToString
                    Dim colType As String = dr("ColumnType").ToString()
                    'Dim HeaderName As String = dr("Text").ToString()
                    Dim HeaderName As String = dr("UserText").ToString()
                    Dim Name As String = dr("CntrlName").ToString()
                    Dim visible As String = dr("Visible").ToString()
                    Dim Tabindex As Int64 = dr("Tabindex").ToString()
                    _Bookcode = dr("Bookcode").ToString()
                    '_FormName = dr("FormName").ToString().Trim()

                    Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                    _TblName = dr("DataBaseTable").ToString()
                    Dim formtype As String = ""
                    formtype = dr("FormType").ToString().Trim()
                    If formtype = "ENTRY FORM" Then
                        If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Or _FORMMODE = "VIEW" Then
                            EntryNo = _GetMaxEntryNo()
                        End If
                    Else

                    End If
                    If usemasterkey = "Y" Then
                        _KeyFieldName = colName
                    End If
                    ' Grid Col Names
                    If _Grid1ColNames.Length > 0 Then
                        _Grid1ColNames.Append(",")
                    End If
                    _Grid1ColNames.Append(colName)
                    Dim Tag As String = dr("DataBaseColumn").ToString()
                    Dim oppMasterCode As String = dr("OppMasterCode").ToString()
                    Dim _Readonly As String = dr("ReadOnly").ToString()
                    FormId = dr("FormId").ToString()
                    Id = dr("Id").ToString()
                    If HeaderName > "" Then
                        'leftPos = dr("LocationX").ToString()
                        'topPos = dr("LocationY").ToString()
                        'width = dr("SizeWidth").ToString()
                        'height = dr("SizeHeight").ToString()
                        leftPos = Convert.ToInt32(dr("LocationX"))
                        topPos = Convert.ToInt32(dr("LocationY"))
                        width = Convert.ToInt32(dr("SizeWidth"))
                        height = Convert.ToInt32(dr("SizeHeight"))
                        Dim lbl As New Label()
                        lbl.Name = "Lbl_" & Name
                        lbl.Text = HeaderName
                        If Name = "Grid1" Or Name = "Grid2" Or Name = "Grid3" Or Name = "Grid4" Or Name = "Grid5" Then
                            lbl.Visible = False
                        ElseIf visible = "N" Then
                            lbl.Visible = False
                        Else
                            lbl.Visible = True
                        End If
                        'lbl.Left = leftPos + 50
                        If leftPos < 0 Then
                            'lbl.Left = 5
                            lbl.Left = Math.Max(5, leftPos)
                        Else
                            lbl.Left = leftPos
                        End If
                        'lbl.Left = leftPos
                        lbl.Top = topPos
                        lbl.Width = 120   ' 🔒 fixed width for all labels
                        lbl.TextAlign = ContentAlignment.MiddleLeft
                        lbl.AutoSize = True
                        Me.Controls.Add(lbl)
                        AddHandler lbl.MouseDown, AddressOf Control_MouseDown
                        AddHandler lbl.MouseMove, AddressOf Control_MouseMove
                        AddHandler lbl.MouseUp, AddressOf Control_MouseUp
                        If colType = "TextBox" AndAlso visible = "Y" Then
                            Dim LblSize As Int16 = lbl.Width
                            Dim txt As New TextBox()
                            txt.Name = Name
                            txt.Left = leftPos + 130
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
                                txt.Focus()
                            End If
                            If formtype = "ENTRY FORM" Then
                                If Tag = "ENTRYNO" Then
                                    txtEntryno = Name
                                    txt.Text = EntryNo
                                    If _FORMMODE = "ADD" Then
                                        EntryNo = _GetMaxEntryNo()
                                        txt.Text = EntryNo + 1
                                    End If
                                    AddHandler txt.KeyDown, AddressOf EntryNoControl_KeyDown
                                End If
                                If _InputType = "DateBox" Then
                                    txt.MaxLength = 10
                                    txt.Text = Today.ToString("dd/MM/yyyy")
                                    AddHandler txt.KeyPress, AddressOf DateBox_KeyPress
                                    AddHandler txt.Leave, AddressOf DateBox_Validate
                                End If
                                If _FORMMODE = "DELETE" Then
                                    EntryNo = _GetMaxEntryNo()
                                    'txt.Text = EntryNo
                                End If
                            Else
                            End If
                            AddHandler txt.MouseDown, AddressOf Control_MouseDown
                            AddHandler txt.MouseMove, AddressOf Control_MouseMove
                            AddHandler txt.MouseUp, AddressOf Control_MouseUp
                            'Master list Bind karne ke liye
                            AddHandler txt.KeyDown, AddressOf Control_KeyDown
                        ElseIf colType = "Button" Then
                            Dim btn As New Button()
                            btn.Name = Name
                            btn.Left = leftPos + 130
                            btn.Top = topPos
                            btn.Width = width
                            Me.Controls.Add(btn)
                            AddHandler btn.MouseDown, AddressOf Control_MouseDown
                            AddHandler btn.MouseMove, AddressOf Control_MouseMove
                            AddHandler btn.MouseUp, AddressOf Control_MouseUp
                        ElseIf colType = "Grid" Then
                            Dim gridname As String = dr("CntrlName").ToString().Trim()
                            If gridname = "Grid1" Then
                                Dim grid1 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid1, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                                Fill_Current_Row_Sr_No(_DataTableGrid1, grid1)
                            ElseIf gridname = "Grid2" Then
                                Dim grid2 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid2, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                                'Fill_Current_Row_Sr_No(_DataTableGrid2, grid2)
                            ElseIf gridname = "Grid3" Then
                                Dim grid3 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid3, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                                'Fill_Current_Row_Sr_No(_DataTableGrid3, grid3)
                            ElseIf gridname = "Grid4" Then
                                Dim grid4 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid4, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                                'Fill_Current_Row_Sr_No(_DataTableGrid4, grid4)
                            ElseIf gridname = "Grid5" Then
                                Dim grid5 As FlexCell.Grid = SetupFlexGrid(gridname, _DataTableGrid5, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                                'Fill_Current_Row_Sr_No(_DataTableGrid5, grid5)
                            End If

                        ElseIf colType = "ComboBox" AndAlso HeaderName > "" Then
                            Dim cmb As New ComboBox()
                            'AddHandler txt.KeyDown, AddressOf MoveNextOnEnter
                        End If
                        topPos += 35
                    End If
                Next
                sqL = "select * from mstbook where bookcode='" & _Bookcode & "'"
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    _Booktrtype = DefaltSoftTable.Rows(0).Item("booktrtype").ToString
                Else
                    MsgBox("Book Not Find Please Define Book", MsgBoxStyle.Critical)
                End If
                ObjCls_General.CreateDataTable(tblFormValues, _Grid1ColNames.ToString, "YES")
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

    Private Function _GetMaxEntryNo()
        Dim ENTRYNO As Int64 = 0
        Dim Tbltmp As DataTable
        Dim _strquery As New StringBuilder
        strQuery = "SELECT TOP 1 ENTRYNO FROM " & _TblName & "  WHERE BOOKCODE='" & _Bookcode & "' ORDER BY ENTRYNO DESC "
        sqL = strQuery
        sql_connect_slect()
        Tbltmp = DefaltSoftTable.Copy
        '_DataTableGrid1 = Tbltmp
        If Tbltmp.Rows.Count > 0 Then
            ENTRYNO = Val(Tbltmp.Rows(0).Item(0))
        End If
        Return ENTRYNO
    End Function
#Region "GRID GENERAL FUNCTION"
    Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If
    End Sub
#End Region
    Private Function SetupFlexGrid(ByVal gridName As String, ByVal gridTable As DataTable, ByVal leftPos As Integer, ByVal topPos As Integer, ByVal width As Integer, ByVal height As Integer, ByVal tagValue As Object, ByVal TabIndex As Integer) As FlexCell.Grid
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
        'grd.CellBorderColorFixed = Color.Red
        'grd.CellBorderColor = Color.Red
        grd.SelectionBorderColor = Color.Red
        defineGridColName()
        If gridName = "Grid1" Then
            GenerateTable(_DataTableGrid1, grd)
            GridFormatting(_DataTableGrid1, grd)
        ElseIf gridName = "Grid2" Then
            GenerateTable(_DataTableGrid2, grd)
            GridFormatting(_DataTableGrid2, grd)
        ElseIf gridName = "Grid3" Then
            GenerateTable(_DataTableGrid3, grd)
            GridFormatting(_DataTableGrid3, grd)
        ElseIf gridName = "Grid4" Then
            GenerateTable(_DataTableGrid4, grd)
            GridFormatting(_DataTableGrid4, grd)
        ElseIf gridName = "Grid5" Then
            GenerateTable(_DataTableGrid5, grd)
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
    Private _PrevRow As Integer = -1
    Private _PrevCol As Integer = -1
    Private Sub Grid_RowColChange(sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs)
        _ActivatedColName = Trim(UCase(sender.Cell(0, sender.ActiveCell.Col).TAG))
    End Sub

    Private Sub EntryNoControl_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If _FORMMODE = "EDIT" Then
                Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
                If ctrl.Length > 0 Then
                    Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                    _GetAlterData(Entytxt.Text)
                End If
            End If
            If _FORMMODE = "VIEW" Then
                Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
                If ctrl.Length > 0 Then
                    Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                    _GetAlterData(Entytxt.Text)
                    'PrintViewPage.Show()
                End If
            End If
            If _FORMMODE = "DELETE" Then
                If MsgBox("Do You Want To Delete (Y/N)",
                  MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
                  "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Entry()
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visible_False(Me.Controls)
                    UC_Buttons1._ButtonEnableDisable("LOAD")
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                End If
            End If
        End If
    End Sub

    Private Sub _GetAlterData(ByVal _EntryNo As Int64)
        Dim tblTmp As DataTable = Alter_EntryForm(_EntryNo)
        Dim grd As FlexCell.Grid
        Dim gridname As String = ""
        'For Each dr As DataRow In _MainColumTbl.Select("CntrlId <> ''")
        For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
            gridname = dr("CntrlName").ToString().Trim()
            If gridname.StartsWith("Grid1") Then
                grd = TryCast(Me.Controls(gridname), FlexCell.Grid)
            End If
            If tblTmp.Rows.Count > 0 Then
                If gridname.StartsWith("Grid1") Then
                    If grd IsNot Nothing Then
                        grd.Range(0, 0, grd.Rows - 1, grd.Cols - 1).DeleteByRow()
                        Fill_Records(tblTmp, Grid1_Table_ColNames, grd, 0, True, "", False)
                        grd.Rows = grd.Rows + 1
                        Call Fill_Sr_No_Item(grd, _DataTableGrid1)
                    End If
                End If
            End If
        Next
        If tblTmp.Rows.Count > 0 Then
            CalculateDynamicColumnTotal(grd, _DataTableGrid1, tmptbl)
        Else
            MsgBox("Record Not Found")
            ObjCls_General.Blank_Object(Me)
            Clear_Grid(grd, 2)
            CalculateDynamicColumnTotal(grd, _DataTableGrid1, tmptbl)
            'UC_Buttons1._ButtonEnableDisable("LOAD")
            'UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
            'Ctrl_Visible_False(Me.Controls)
        End If
    End Sub
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        Dim ctrl As Control = TryCast(sender, Control)
        If ctrl Is Nothing Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TypeOf ctrl Is FlexCell.Grid Then
                Dim grd As FlexCell.Grid = DirectCast(ctrl, FlexCell.Grid)
                _ActivatedColName = Trim(UCase(grd.Cell(0, grd.ActiveCell.Col).Tag))
                Dim ActivetextName = grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(_ActivatedColName) + 1).Text
                If grd.Rows - 1 = grd.ActiveCell.Row Then
                    grd.Rows = grd.Rows + 1
                    Call Fill_Sr_No_Item(grd, _DataTableGrid1)
                End If
                _savedefaultrowBlank(grd, _DataTableGrid1)
                ApplyGridFormula(grd, _DataTableGrid1)
                _GridColmTotal(grd, _DataTableGrid1)
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
    Private Function IsNumericColumn(colName As String) As Boolean
        Return _Grid1ColType.ToString().Contains(colName & ":N")
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

    Private Sub _GridColmTotal(grd As FlexCell.Grid, dt As DataTable)

        Dim footerTop As Integer = grd.Top + grd.Height + 5   ' grid ke niche
        ' 🔁 Purane labels remove
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.Controls(i) Is Label AndAlso Me.Controls(i).Name.StartsWith("lblTotal_") Then
                Me.Controls.RemoveAt(i)
            End If
        Next
        ' 👉 TOTAL text label

        lblTotalText.Name = "lblTotal_Text"
        lblTotalText.Text = "Total"
        lblTotalText.Top = footerTop
        lblTotalText.Left = grd.Left
        lblTotalText.Width = 80
        lblTotalText.Font = New Font("Tahoma", 9, FontStyle.Bold)
        Me.Controls.Add(lblTotalText)
        ' ✅ Valid columns filter
        Dim total As Double = 0
        Dim startLeft As Integer = grd.Left + 500
        Dim gap As Integer = 120
        Dim iCol As Integer = 0
        Dim isAnyTotalAvailable As Boolean = False   ' 🔥 Flag

        If allowedTotalCols_Grid_1 IsNot Nothing AndAlso allowedTotalCols_Grid_1.Count > 0 Then
            For Each col As String In allowedTotalCols_Grid_1
                total = 0   ' 🔥 yaha reset karo
                Dim colIndex As Integer = dt.Columns.IndexOf(col)
                If colIndex < 0 Then Continue For
                Dim gridColIndex As Integer = colIndex + 1
                ' 🔁 Total calculate
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
                    isAnyTotalAvailable = True   ' 🔥 Important
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
    Private Sub _savedefaultrowBlank(grd As FlexCell.Grid, dt As DataTable)
        Dim formulaStr As String = GetQuery(tmptbl, "SAVEMEDETORYCOLUMNNAME", "TOTAL COLUMN")
        If String.IsNullOrWhiteSpace(formulaStr) Then Exit Sub
        mandatoryCol = formulaStr.Trim().ToUpper()
        If String.IsNullOrWhiteSpace(mandatoryCol) Then Exit Sub
        For r As Integer = 1 To grd.Rows - 1
            Dim isRowBlank As Boolean = True   ' 👉 yaha reset karo
            ' 👉 check row blank
            For c As Integer = 1 To grd.Cols - 1
                Dim val As String = grd.Cell(r, c).Text.Trim()
                If val <> "" AndAlso val <> "0" AndAlso val <> "0.00" Then
                    isRowBlank = False
                    Exit For
                End If
            Next
            ' 👉 blank row skip
            If isRowBlank Then Continue For
            ' 👉 mandatory column blank ho to 0 set karo
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
    'Private Sub ApplyGridFormula(grd As FlexCell.Grid, dt As DataTable)
    '    'Dim formulaStr As String = GetQuery(tmptbl, "GRIDCOLUMMULTIPLY", "VIEW")
    '    Dim formulaStr As String = GetQuery(tmptbl, "GRIDCOLUMMULTIPLY", "TOTAL COLUMN")
    '    If String.IsNullOrWhiteSpace(formulaStr) Then Exit Sub
    '    ' 👉 Example: ADJAMT*AMOUNT_ADD=AMOUNT_LESS
    '    Dim parts() As String = formulaStr.Split("="c)
    '    If parts.Length <> 3 Then Exit Sub
    '    Dim leftPart As String = parts(0)
    '    Dim resultColName As String = parts(1).Trim()
    '    Dim operands() As String = leftPart.Split("*"c)
    '    If operands.Length <> 3 Then Exit Sub
    '    Dim col1Name As String = operands(0).Trim()
    '    Dim col2Name As String = operands(1).Trim()
    '    ' 👉 Column match (case-insensitive)
    '    Dim col1 = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = col1Name.ToLower())
    '    Dim col2 = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = col2Name.ToLower())
    '    Dim colResult = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = resultColName.ToLower())
    '    If col1 Is Nothing Or col2 Is Nothing Or colResult Is Nothing Then Exit Sub
    '    ' 👉 FlexCell index
    '    Dim colIndex1 As Integer = dt.Columns.IndexOf(col1.ColumnName) + 1
    '    Dim colIndex2 As Integer = dt.Columns.IndexOf(col2.ColumnName) + 1
    '    Dim colResultIndex As Integer = dt.Columns.IndexOf(colResult.ColumnName) + 1
    '    Dim total As Double = 0

    '    ' 🔁 Row-wise calculation
    '    For i As Integer = 1 To grd.Rows - 1
    '        Dim val1 As Double = 0
    '        Dim val2 As Double = 0
    '        Double.TryParse(grd.Cell(i, colIndex1).Text, val1)
    '        Double.TryParse(grd.Cell(i, colIndex2).Text, val2)
    '        Dim result As Double = val1 * val2
    '        grd.Cell(i, colResultIndex).Text = result.ToString("")
    '    Next
    '    If total = 0 Then
    '        grd.Cell(grd.Rows - 1, colResultIndex).Text = ""
    '        grd.Cell(grd.Rows - 1, colResultIndex).Locked = True
    '    Else
    '        grd.Cell(grd.Rows - 1, colResultIndex).Text = total.ToString("0.00")
    '        grd.Cell(grd.Rows - 1, colResultIndex).Locked = True
    '    End If
    '    'If colResultIndex > 1 Then
    '    '    grd.Cell(grd.Rows - 1, colResultIndex - 1).Text = ""
    '    'End If
    'End Sub
    Private Sub ApplyGridFormula(grd As FlexCell.Grid, dt As DataTable)
        Dim formulaStr As String = GetQuery(tmptbl, "GRIDCOLUMMULTIPLY", "TOTAL COLUMN")
        If String.IsNullOrWhiteSpace(formulaStr) Then Exit Sub
        ' 👉 Step 1: Multiple formulas split by comma
        Dim formulas() As String = formulaStr.Split(","c)
        ' 🔁 Loop all formulas
        For Each formula As String In formulas
            formula = formula.Trim()
            If formula = "" Then Continue For
            ' 👉 Example: ADJAMT*AMOUNT_ADD=AMOUNT_LESS
            Dim parts() As String = formula.Split("="c)
            If parts.Length <> 2 Then Continue For
            Dim leftPart As String = parts(0).Trim()
            Dim resultColName As String = parts(1).Trim()
            ' 👉 Split operands (*)
            Dim operands() As String = leftPart.Split("*"c)
            If operands.Length <> 2 Then Continue For
            Dim col1Name As String = operands(0).Trim()
            Dim col2Name As String = operands(1).Trim()
            ' 👉 Column match (case-insensitive)
            Dim col1 = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = col1Name.ToLower())
            Dim col2 = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = col2Name.ToLower())
            Dim colResult = dt.Columns.Cast(Of DataColumn)().FirstOrDefault(Function(c) c.ColumnName.ToLower() = resultColName.ToLower())
            If col1 Is Nothing Or col2 Is Nothing Or colResult Is Nothing Then Continue For
            ' 👉 FlexCell index
            Dim colIndex1 As Integer = dt.Columns.IndexOf(col1.ColumnName) + 1
            Dim colIndex2 As Integer = dt.Columns.IndexOf(col2.ColumnName) + 1
            Dim colResultIndex As Integer = dt.Columns.IndexOf(colResult.ColumnName) + 1
            Dim total As Double = 0
            ' 🔁 Row-wise calculation
            For i As Integer = 1 To grd.Rows - 1
                Dim val1 As Double = 0
                Dim val2 As Double = 0
                Double.TryParse(grd.Cell(i, colIndex1).Text, val1)
                Double.TryParse(grd.Cell(i, colIndex2).Text, val2)
                Dim result As Double = val1 * val2
                grd.Cell(i, colResultIndex).Text = result.ToString("")
                grd.Cell(i, colResultIndex).Locked = True
            Next
            ' 👉 Footer total
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
    Private Sub RunActivatedColumnMasterSelection(ByVal ctrlmasterName As String, ByVal ActivetextName As String)
        For Each dr As DataRow In _MainColumTbl.Select("DataBaseColumn='" & ctrlmasterName & "'")
            Dim offmastercode As String = dr("OPPMASTERCODE").ToString()
            Dim masterName As String = dr("MASTERLIST").ToString()
            Dim ctrlNameStr As String = dr("CntrlName").ToString().Trim()
            Dim ctrl As Control = Me.Controls.Find(ctrlNameStr, True).FirstOrDefault()
            If offmastercode <> "" Then
                HandleMasterSelection(masterName, ctrlmasterName, offmastercode, ctrl, ActivetextName)
            End If
        Next
    End Sub
    Private Sub HandleControlAction(ByVal sender As Object)
        If isDragging Then
            HandleControlAction(sender)
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
        Dim leftPos As Integer = ctrl.Left - 130
        Dim topPos As Integer = ctrl.Top
        Dim height As Integer = ctrl.Height
        Dim width As Integer = ctrl.Width
        Dim ctrlName As String = ctrl.Name
        Dim Tabindex As Integer = ctrl.TabIndex
        updatepossition(leftPos, topPos, height, width, ctrlName, Tabindex, FormId, Id)
    End Sub

    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _Grid1ColNames.ToString.ToUpper, "NO", _Grid1ColType.ToString)
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
    Private Sub _LoadDefaultData()
        View_Record()
        Dim formType As String = ""
        If _MainColumTbl.Rows.Count > 0 Then
            formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            FormNameValue = _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        FormNameValue = _getformName()
        If formType = "ENTRY FORM" Then
            If _FORMMODE = "EDIT" Then
                Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
                If ctrl.Length > 0 Then
                    Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                    Entytxt.Focus()
                    Entytxt.SelectAll()
                End If
            End If
        End If

        If _FORMMODE = "VIEW" Then
            tmptbl = _GetFormQuery(FormNameValue, "VIEW")
            LoadViewData(tmptbl, _Bookcode)
        ElseIf _FORMMODE = "LOAD" Then
            tmptbl = _GetFormQuery(FormNameValue, "TOTAL COLUMN")
        End If
        isMoveMode = False
        isDragging = False
    End Sub

    Private Sub MainFormRead_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If PropertyGrid1.Visible = True Then
                PropertyGrid1.Visible = False
            End If
            If PnlGrdView.Visible = True AndAlso _FORMMODE = "VIEW" Then
                PnlGrdView.Visible = False
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                Exit Sub
            ElseIf _FormCloseMode = False Then
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
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
        ElseIf e.KeyCode = Keys.F2 Then
            Dim entryformname As New QueryLoad()
            entryformname.GetformName = Me._getformName()
            entryformname.Show()
            'QueryLoad.Show()
        End If
    End Sub
    Private Sub HandleMasterSelection(ByVal masterName As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal CntrlName As Control, ByVal ActivetextName As String)
        Select Case masterName
            Case "ACCOUNT MASTER"
                Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("AccountName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("AccountName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "AGENT MASTER"
                Dim _LoadQuery = NewSelectionList.Bill_Agent_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("AgentName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("AgentName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "CITY MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_City_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("cityname") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("cityname").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "STATE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_State_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("StateName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("StateName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_ITEM_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ITENNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ITENNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC DESIGN MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_DESIGN_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("DesignName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("DesignName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_SHADE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ShadeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ShadeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC SELVEDGE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Selvedge_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SelvedgeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SelvedgeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "YARN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Yarn_Type_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("YarnType") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("YarnType").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "YARN SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_YarnItem_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("CountName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("CountName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GENRAL ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_storeItem_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ItemName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ItemName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SUBITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_store_Sub_Item_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SubItemName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SubItemName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SIZE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_size_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SizeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SizeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "COLOR MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Color_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ColorName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ColorName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "REMARK MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Remark_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Remark") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Remark").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "PROCESS MASTER"
                Dim _LoadQuery = NewSelectionList.Single_process_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ACCOUNTNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "CUT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Cut_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("CUTNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("CUTNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "DEPARTMENT MASTER"
                Dim _LoadQuery = NewSelectionList.Single_STORE_DEPARTMENT_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("DepName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("DepName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "POST MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_POST_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Post") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Post").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "EMPLOYEE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Employee_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("EmployeeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("EmployeeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC GROUP MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Fabric_Item_Group_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GroupName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GroupName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GODOWN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Godown_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GodownName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GodownName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GRADER MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_GRADER_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GraderName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GraderName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "INSURANCE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_INSURANCE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("COMPANYNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("COMPANYNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "LOOMNO MASTER"
                Dim _LoadQuery = NewSelectionList.Single_LoomNo_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("LoomNo") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("LoomNo").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SALESMAN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_SalesMan_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Saleman") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Saleman").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "TRANSPORT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_TRANSPORT_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("TransportName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("TransportName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "BOOK MASTER"
                Dim _LoadQuery = NewSelectionList.MstBookSelection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("BookName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("BookName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
        End Select
    End Sub
    Private Sub SetGridValue(ByVal displayValue As String, ByVal codeValue As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal ctrl As Control)
        If ctrl IsNot Nothing Then
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = DirectCast(ctrl, TextBox)
                txt.Text = displayValue
                txt.ReadOnly = True
                Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase))
                If existingItem Is Nothing Then
                    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                Else
                    ' 🔹 Agar value update karni ho to replace karo
                    _UniqueValues.Remove(existingItem)
                    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                End If
            ElseIf TypeOf ctrl Is FlexCell.Grid Then
                Dim grd = DirectCast(ctrl, FlexCell.Grid)
                If ctrl.Name = "Grid1" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid2" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid2.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid2.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid3" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid3.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid3.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid4" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid4.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid4.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid5" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid5.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid5.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                End If
            End If
        End If

        'Dim listByControl = _UniqueValues.Where(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase)).ToList()
    End Sub
#Region "FILL SR NO"
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
        Next
    End Sub
#End Region
    Private Sub updatepossition(ByVal leftpos As String, ByVal topPos As String, ByVal Height As String, ByVal Width As String, ByVal ctrlName As String, ByVal Tabindex As String, ByVal FormId As String, ByVal Id As String)
        _strQuery = New StringBuilder
        Try
            If ctrlName = "Grid1" Or ctrlName = "Grid2" Or ctrlName = "Grid3" Or ctrlName = "Grid4" Or ctrlName = "Grid5" Then
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & "  WHERE CntrlName='" & ctrlName & "' and FormId=" & FormId & ""
            Else
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & ",TabIndex=" & Tabindex & "  WHERE CntrlName='" & ctrlName & "' and FormId=" & FormId & ""
            End If
            'sqL = strQuery.ToString
            'sql_connect_slect1()
            RS = strQuery.ToString
            MenuDesign_QueryLoad()
        Catch ex As Exception
            MsgBox("Error While update Entry")
        Finally
            cmd = Nothing
        End Try
    End Sub
    Private Sub BtnUpdatepos_Click(sender As Object, e As EventArgs) Handles BtnUpdatepos.Click

        For Each ctrl As Control In Me.Controls
            ' sirf required controls
            If TypeOf ctrl Is Label OrElse
       TypeOf ctrl Is TextBox OrElse
       TypeOf ctrl Is Button OrElse TypeOf ctrl Is Grid Then
                SaveControlPosition(ctrl)
            End If
        Next
        isMoveMode = False
        isDragging = False
        Ctrl_Visible_True(Me.Controls)
        PropertyGrid1.Visible = False
        'txtFormName.Text = ""
        'txtFormName.Focus()
    End Sub

    Private Sub _GridEnable()
        'Dim grd As FlexCell.Grid = TryCast(Me.Controls("Grid1"), FlexCell.Grid)
        'grd.Enabled = True
        For i As Integer = 1 To 5
            Dim grd As FlexCell.Grid = TryCast(Me.Controls("Grid" & i), FlexCell.Grid)
            If grd IsNot Nothing Then
                grd.Enabled = True
            End If
        Next
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnmovecontrol.Click
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
        _GridEnable()
    End Sub


    Public Function _getformName() As String
        If _MainColumTbl IsNot Nothing AndAlso _MainColumTbl.Rows.Count > 0 Then
            'MsgBox(_MainColumTbl.Rows(0)("FormName").ToString().Trim())
            Return _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        Return ""
    End Function
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            MasterMenuLoad.RestoreMenuFocus(Me.Tag, MasterMenuLoad.MenuStrip1)
        End If
    End Sub
End Class