Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports DevExpress.Utils.Extensions
Imports DevExpress.Xpo.DB
Imports DevExpress.Xpo.DB.Helpers
Imports DevExpress.XtraBars.Customization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.TextEditController.Win32
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraRichEdit.Import.OpenDocument
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
    Dim GetformId As Integer = 0
    Private DynamicTabControl As TabControl = Nothing
    Private CurrentTabPage As TabPage = Nothing
    Dim ImagePaths As New Dictionary(Of Integer, String)
    Private _FieldUseHeaderColumn As New StringBuilder()



    Private Sub MainFormRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        _FORMMODE = "LOAD"
        _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        Me.Location = New POINT(0, 0)
        _FrmLoad = True
        CreateButtonsControl()
        AttachButtonFocusEvents(Me)
        'Propaerties Grid
        PanlPropartiesWindow.Height = Me.Height - 80
        PropertyGrid1.Width = PanlPropartiesWindow.Width - 10
        PropertyGrid1.Height = PanlPropartiesWindow.Height - 55
        PanlPropartiesWindow.Location = New POINT(Me.Width - 320, 0)
        'View Report Grid
        PnlGrdView.Width = Me.Width
        PnlGrdView.Height = Me.Height
        PnlGrdView.Location = New POINT(0, 0)
        GridControl1.Width = PnlGrdView.Width - 25
        GridControl1.Height = PnlGrdView.Height - 100
        GridControl1.Location = New POINT(3, 53)
        _LoadDefaultData()
        For i As Integer = 1 To 5
            Dim gridName As String = "Grid" & i
            Dim grd As FlexCell.Grid = TryCast(Me.Controls(gridName), FlexCell.Grid)
            If grd Is Nothing Then
                Continue For
            End If
            Dim gridDt As DataTable = Nothing
            Select Case i
                Case 1
                    gridDt = _DataTableGrid1
                Case 2
                    gridDt = _DataTableGrid2
                Case 3
                    gridDt = _DataTableGrid3
                Case 4
                    gridDt = _DataTableGrid4
                Case 5
                    gridDt = _DataTableGrid5
            End Select
            If gridDt Is Nothing Then
                Continue For
            End If
            ApplyGridFormula(grd, gridDt)
            CalculateDynamicColumnTotal(grd, gridDt, tmptbl)
        Next
        Ctrl_Visible_Falseform(Me.Controls)
        _FrmLoad = False
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
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
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            _BookVNo = ""
            Ctrl_Visible_TrueForm(Me.Controls)
            _LoadDefaultData()
            _GridEnable()
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
            Ctrl_Visible_TrueForm(Me.Controls)
            _LoadDefaultData()
            _GridEnable()
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Function Alter_EntryFormHeader(ByVal Entryno As String, ByVal _FilterTableName As String) As DataTable
        Try
            _FrmLoad = True
            Dim tblTmp As New DataTable
            sqL = getAlter_Form_EntryQuery(Entryno, _FilterTableName, "")
            sql_connect_slect()
            tblTmp = DefaltSoftTable.Copy
            ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)
            For Each dr As DataRow In _MainColumTbl.Select("IsNull(CntrlId,0) <> 0")
                Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
                Dim ctrlName As String = dr("CntrlName").ToString().Trim()
                Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
                Dim UseMaster As String = dr("UseMaster").ToString().Trim()
                Dim ctrl As Control = Me.Controls.Find(ctrlName, True).FirstOrDefault()
                If ctrl Is Nothing Then Continue For
                Dim currentCtrl As Control = ctrl
                Dim columnType As String = ""
                If dr.Table.Columns.Contains("ColumnType") AndAlso Not IsDBNull(dr("ColumnType")) Then
                    columnType = dr("ColumnType").ToString().Trim()
                End If
                Dim dbColumn As String = ""
                If dr.Table.Columns.Contains("DataBaseColumn") AndAlso Not IsDBNull(dr("DataBaseColumn")) Then
                    dbColumn = dr("DataBaseColumn").ToString().Trim()
                End If
                If TypeOf currentCtrl Is TextBox Then
                    Dim txt As TextBox = DirectCast(currentCtrl, TextBox)
                    Dim tagText As String = ""
                    If txt.Tag IsNot Nothing Then
                        tagText = txt.Tag.ToString().Trim()
                    End If
                    If tagText.StartsWith("Attach Image", StringComparison.OrdinalIgnoreCase) Then
                        Dim imageColumn As String = ""
                        If txt.AccessibleName IsNot Nothing Then
                            imageColumn = txt.AccessibleName.ToString().Trim()
                        End If
                        If String.IsNullOrWhiteSpace(imageColumn) Then
                            imageColumn = dbColumn
                        End If
                        If Not String.IsNullOrWhiteSpace(imageColumn) AndAlso tblTmp.Columns.Contains(imageColumn) Then
                            Dim imagePath As String = ""
                            If Not IsDBNull(tblTmp.Rows(0)(imageColumn)) Then
                                imagePath = tblTmp.Rows(0)(imageColumn).ToString().Trim()
                            End If
                            txt.AccessibleDescription = imagePath
                            If imagePath <> "" Then
                                txt.Text = IO.Path.GetFileName(imagePath)
                            Else
                                txt.Text = ""
                            End If
                        End If
                    Else
                        Dim textColumn As String = ""
                        If txt.AccessibleDescription IsNot Nothing Then
                            textColumn = txt.AccessibleDescription.ToString().Trim()
                        End If
                        If String.IsNullOrWhiteSpace(textColumn) AndAlso txt.Tag IsNot Nothing Then
                            textColumn = txt.Tag.ToString().Trim()
                        End If
                        If tblTmp Is Nothing OrElse tblTmp.Rows.Count = 0 Then
                            'MsgBox("No Record Found")
                            Exit Function
                        End If
                        If Not textColumn.StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) AndAlso tblTmp.Columns.Contains(textColumn) Then
                            If Not IsDBNull(tblTmp.Rows(0)(textColumn)) Then
                                txt.Text = tblTmp.Rows(0)(textColumn).ToString()
                            Else
                                txt.Text = ""
                            End If
                        End If
                    End If
                ElseIf TypeOf currentCtrl Is System.Windows.Forms.CheckBox Then
                    Dim chk As System.Windows.Forms.CheckBox = DirectCast(currentCtrl, System.Windows.Forms.CheckBox)
                    Dim checkColumn As String = ""
                    If chk.Tag IsNot Nothing Then
                        checkColumn = chk.Tag.ToString().Trim()
                    End If
                    If String.IsNullOrWhiteSpace(checkColumn) AndAlso chk.AccessibleDescription IsNot Nothing Then
                        checkColumn = chk.AccessibleDescription.ToString().Trim()
                    End If
                    If Not String.IsNullOrWhiteSpace(checkColumn) AndAlso Not checkColumn.StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) AndAlso tblTmp.Columns.Contains(checkColumn) Then
                        Dim dbValue As String = ""
                        If Not IsDBNull(tblTmp.Rows(0)(checkColumn)) Then
                            dbValue = tblTmp.Rows(0)(checkColumn).ToString().Trim()
                        End If
                        If dbValue.Equals("YES", StringComparison.OrdinalIgnoreCase) OrElse dbValue.Equals("TRUE", StringComparison.OrdinalIgnoreCase) OrElse dbValue = "1" Then
                            chk.Checked = True
                        Else
                            chk.Checked = False
                        End If
                    End If
                ElseIf TypeOf currentCtrl Is System.Windows.Forms.ComboBox Then
                    Dim cmb As System.Windows.Forms.ComboBox = DirectCast(currentCtrl, System.Windows.Forms.ComboBox)
                    Dim comboColumn As String = ""
                    If cmb.Tag IsNot Nothing Then
                        comboColumn = cmb.Tag.ToString().Trim()
                    End If
                    If String.IsNullOrWhiteSpace(comboColumn) AndAlso cmb.AccessibleName IsNot Nothing Then
                        comboColumn = cmb.AccessibleName.ToString().Trim()
                    End If
                    If String.IsNullOrWhiteSpace(comboColumn) AndAlso cmb.AccessibleDescription IsNot Nothing Then
                        comboColumn = cmb.AccessibleDescription.ToString().Trim()
                    End If
                    If Not String.IsNullOrWhiteSpace(comboColumn) AndAlso Not comboColumn.StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) AndAlso tblTmp.Columns.Contains(comboColumn) Then
                        Dim dbValue As String = ""
                        If Not IsDBNull(tblTmp.Rows(0)(comboColumn)) Then
                            dbValue = tblTmp.Rows(0)(comboColumn).ToString().Trim()
                        End If
                        cmb.SelectedIndex = -1
                        If dbValue <> "" Then
                            Dim foundIndex As Integer = -1
                            For i As Integer = 0 To cmb.Items.Count - 1
                                If cmb.Items(i).ToString().Trim().Equals(dbValue, StringComparison.OrdinalIgnoreCase) Then
                                    foundIndex = i
                                    Exit For
                                End If
                            Next
                            If foundIndex >= 0 Then
                                cmb.SelectedIndex = foundIndex
                            Else
                                cmb.Items.Add(dbValue)
                                cmb.SelectedIndex = cmb.Items.Count - 1
                            End If
                        End If
                    End If
                ElseIf TypeOf currentCtrl Is TabControl Then
                    Dim tabCtrl As TabControl = DirectCast(currentCtrl, TabControl)
                    If tabCtrl IsNot Nothing Then
                        If tabCtrl.Tag Is Nothing AndAlso Not String.IsNullOrWhiteSpace(dbColumn) Then
                            tabCtrl.Tag = dbColumn
                        End If
                    End If
                ElseIf TypeOf currentCtrl Is DevExpress.XtraEditors.SimpleButton Then
                    Dim btn As DevExpress.XtraEditors.SimpleButton = DirectCast(currentCtrl, DevExpress.XtraEditors.SimpleButton)
                    Dim btnTag As String = ""
                    If btn.Tag IsNot Nothing Then
                        btnTag = btn.Tag.ToString().Trim()
                    End If
                    If btn.Name.IndexOf("ImgAdd", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        If btnTag.StartsWith("Attach Image", StringComparison.OrdinalIgnoreCase) Then
                            If Not String.IsNullOrWhiteSpace(dbColumn) Then
                                btn.AccessibleDescription = dbColumn
                            End If
                        End If
                    ElseIf btn.Name.IndexOf("ImgView", StringComparison.OrdinalIgnoreCase) >= 0 Then
                        If btnTag.StartsWith("Attach Image", StringComparison.OrdinalIgnoreCase) Then
                            If Not String.IsNullOrWhiteSpace(dbColumn) Then
                                btn.AccessibleDescription = dbColumn
                            End If
                        End If
                    End If
                End If
                If UseMaster = "YES" Then
                    RunActivatedColumnMasterSelection(ctrl.Tag, ctrl.Text)
                    Me.SelectNextControl(ctrl, True, True, True, True)
                End If
            Next
            If tblTmp.Rows.Count > 0 Then
                _BookVNo = tblTmp.Rows(0).Item("bookvno").ToString
            End If
            _FrmLoad = False
            Return tblTmp   ' 👈 yaha return kar diya
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        End Try
    End Function

    Private Sub UC_Buttons1_DeleteClick()
        _FrmLoad = True
        _FormCloseMode = False
        _FORMMODE = "DELETE"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        Dim EntryNo As Integer
        EntryNo = _GetMaxEntryNo()
        If EntryNo > 0 Then
            Dim txt As New TextBox()
            txt.Text = EntryNo
            txtEntryno = txt.Text
            Ctrl_Visible_TrueForm(Me.Controls)
        End If
        If _FORMMODE = "DELETE" Then
            'txtFormName.Focus()
            If MsgBox("Do You Want To Delete (Y/N)",
              MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              "Delete ?") = MsgBoxResult.Yes Then
                Call Delete_Entry()
            End If
            ObjCls_General.Blank_Object(Me)
            Ctrl_Visible_Falseform(Me.Controls)
        End If
        Change_Grid_Data = True
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
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
        Try
            Dim EntryNo As String = ""
            _FrmLoad = False
            Dim Array_Opening(0, 4) As String
            Dim formType As String = ""
            Dim LASTCODE As String = ""
            If _MainColumTbl.Rows.Count > 0 Then
                formType =
                    _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            End If
            If formType = "ENTRY FORM" Then
                Call Fill_Grid_Records_Into_DataTables()
                Dim AllQueries As String = GridDetailsSaveQuery(Array_Opening)
                If Not String.IsNullOrWhiteSpace(AllQueries) Then
                    Dim QueryList() As String = AllQueries.Split(New String() {";" & vbCrLf, ";" & vbLf}, StringSplitOptions.RemoveEmptyEntries)
                    For Each OneQuery As String In QueryList
                        Dim SingleQuery As String = OneQuery.Trim()
                        If SingleQuery = "" Then
                            Continue For
                        End If
                        sqL = SingleQuery
                        sql_Data_Save_Delete_Update()
                    Next
                End If
                Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
                If ctrl.Length > 0 Then
                    Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                    'Dim delQry As String = "DELETE FROM " & _TblName & " WHERE BOOKCODE='" & _Bookcode & "' AND ENTRYNO =" & Entytxt.Text
                    'ExecuteBatchWithTransaction(delQry, Array_Opening, 4)
                    Dim EntryMetaRows() As DataRow = _MainColumTbl.Select("CntrlName='" & txtEntryno.Replace("'", "''") & "' AND " & "DataBaseTable IS NOT NULL AND " & "DataBaseTable<>''")
                    If EntryMetaRows.Length > 0 Then
                        _TblName = EntryMetaRows(0)("DataBaseTable").ToString().Trim()
                    Else
                        _TblName = ""
                    End If
                    If Not String.IsNullOrWhiteSpace(_TblName) AndAlso Not String.IsNullOrWhiteSpace(Entytxt.Text.Trim()) Then
                        'Dim delQry As String = "DELETE FROM " & _TblName & " WHERE BOOKCODE='" & _Bookcode.Replace("'", "''") & "' AND ENTRYNO =" & Entytxt.Text.Trim()
                        'ExecuteBatchWithTransaction(delQry, Array_Opening, 4)
                    End If
                End If
                Dim Pcs_Row_No As Integer = 0
                Interaction.MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")
                ObjCls_General.Blank_Object(Me)
                For Each dr As DataRow In _MainColumTbl.Select("Columntype='Grid'")
                    Dim gridname As String = dr("CntrlName").ToString().Trim()
                    Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(gridname, True).FirstOrDefault(), FlexCell.Grid)
                    If grd IsNot Nothing Then
                        Clear_Grid(grd, 2)
                        '_GridColmTotal(grd, _DataTableGrid1)
                        Select Case grd.Name.ToUpper()
                            Case "GRID1"
                                _GridColmTotal(grd, _DataTableGrid1)
                            Case "GRID2"
                                _GridColmTotal(grd, _DataTableGrid2)
                            Case "GRID3"
                                _GridColmTotal(grd, _DataTableGrid3)
                            Case "GRID4"
                                _GridColmTotal(grd, _DataTableGrid4)
                            Case "GRID5"
                                _GridColmTotal(grd, _DataTableGrid5)
                        End Select
                    End If
                Next
            End If
            UC_Buttons1._ButtonEnableDisable("LOAD")
            UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
        Catch ex As Exception
            MsgBox("Failed to save transaction: " & ex.Message, MsgBoxStyle.Critical, "Transaction Error")
            Throw ex
        End Try
    End Sub

    Private Function GetAllControls(parent As Control) As List(Of Control)
        Dim result As New List(Of Control)
        If parent Is Nothing Then Return result
        For Each ctrl As Control In parent.Controls
            result.Add(ctrl)
            ' TabControl / Panel / GroupBox / UserControl etc.
            If ctrl.HasChildren Then
                result.AddRange(GetAllControls(ctrl))
            End If
        Next
        Return result
    End Function
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "= " & " '" & _KeyFieldValue & "'")
        End If
        getSaveQuery = _strQuery.ToString
    End Function

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
            Ctrl_Visible_TrueForm(Me.Controls)
        End If

        Txt_ViewFrom.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        Txt_ViewTO.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        _LoadDefaultData()
        '_GridEnable()
        'LoadViewData(tmptbl, _Bookcode)
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
    Private Function getAlter_Form_EntryQuery(ByVal EntryNo As String, ByVal _FilterTableName As String, ByVal FillColumnType As String) As String

        Dim DisplayText As String = ""
        Dim leftJoin As New StringBuilder()
        Dim joinHeader As New StringBuilder()
        Dim ControlName As String = ""
        If Not String.IsNullOrWhiteSpace(txtEntryno) Then
            ControlName = txtEntryno.Trim()
        End If
        'Dim columntype As String = "Grid then main table join table name as a = b DataBaseTable "
        Dim _joinTableName As String
        Dim _JoinColumnName As String
        Dim filterCondition As String
        If FillColumnType = "Grid" Then
            filterCondition = "JoinerTableName > '' AND DataBaseTable='" & _FilterTableName & "'"
        Else
            filterCondition = "USEMASTER='YES' AND MasterList > '' AND DataBaseTable='" & _FilterTableName & "'"
        End If
        For Each dr As DataRow In _MainColumTbl.Select(filterCondition)
            _joinTableName = dr("JoinerTableName").ToString().Trim()
            _JoinColumnName = dr("JoinerTableColumn").ToString().Trim()
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
            If _joinTableName <> "" AndAlso _JoinColumnName <> "" Then
                Dim joinAlias As String = "J_" & _joinTableName
                leftJoin.AppendLine(" LEFT JOIN " & _joinTableName & " AS " & joinAlias & " ON A." & _JoinColumnName & " = " & joinAlias & "." & _JoinColumnName)
            End If
        Next
        _strQuery = New StringBuilder()
        'If _FORMMODE = "VIEW" Then
        '    With _strQuery
        '        .Append(" SELECT A.* ")
        '        .Append(joinHeader.ToString())
        '        .Append(" FROM " & _FilterTableName & " AS A ")
        '        .Append(leftJoin.ToString())
        '        .Append(" WHERE 1=1 ")
        '        .Append(" AND A.BOOKCODE='" & _Bookcode & "' ")
        '        .Append(" AND A.EntryNo=" & EntryNo)
        '        .Append(" ORDER BY A.EntryNo DESC")
        '    End With
        'Else
        With _strQuery
                .Append(" SELECT A.* ")
                .Append(joinHeader.ToString())
                .Append(" FROM " & _FilterTableName & " AS A ")
                .Append(leftJoin.ToString())
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BOOKCODE='" & _Bookcode & "' ")
                .Append(" AND A.EntryNo=" & EntryNo)
                .Append(" ORDER BY A.EntryNo DESC")
            End With
        'End If
        Return _strQuery.ToString()
    End Function
#End Region
    Private Sub Fill_Grid_Records_Into_DataTables()
        Try
            _DataTableGrid1.Rows.Clear()
            _DataTableGrid2.Rows.Clear()
            _DataTableGrid3.Rows.Clear()
            _DataTableGrid4.Rows.Clear()
            _DataTableGrid5.Rows.Clear()
            Dim gridTableMap As New Dictionary(Of String, DataTable) From {{"Grid1", _DataTableGrid1}, {"Grid2", _DataTableGrid2}, {"Grid3", _DataTableGrid3}, {"Grid4", _DataTableGrid4}, {"Grid5", _DataTableGrid5}}
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
            Dim FinalQuery As New StringBuilder()
            Dim strFilterString As String = If(mandatoryCol <> "", mandatoryCol & ">0", "")
            If _BookVNo = "" Then _BookVNo = Generate_Book_Vno(Val(txtEntryno), _Booktrtype)
            Dim tables As New List(Of DataTable) From {_DataTableGrid1, _DataTableGrid2, _DataTableGrid3, _DataTableGrid4, _DataTableGrid5}
            Dim gridNames() As String = {"Grid1", "Grid2", "Grid3", "Grid4", "Grid5"}
            Dim ControlQueries As New List(Of String)
            Dim GridQueries As New List(Of String)
            '================ CONTROL TABLES ================
            Dim controlRows() As DataRow = _MainColumTbl.Select("(ColumnType='TextBox' OR ColumnType='CheckBox') AND DataBaseTable IS NOT NULL AND DataBaseTable<>''", "DataBaseTable,OrderNo")
            For Each tableGroup In controlRows.GroupBy(Function(r) r("DataBaseTable").ToString().Trim())
                Dim tableName As String = tableGroup.Key
                If String.IsNullOrWhiteSpace(tableName) Then Continue For
                Dim fields As New StringBuilder()
                Dim values As New StringBuilder()
                For Each dr As DataRow In tableGroup
                    Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
                    Dim ctrlName As String = dr("CntrlName").ToString().Trim()
                    If columnName.Equals("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) OrElse columnName.StartsWith("NO COLUMN USE ", StringComparison.OrdinalIgnoreCase) Then
                        Dim oppMasterCode As String = dr("OppMasterCode").ToString().Trim()
                        If Not String.IsNullOrWhiteSpace(oppMasterCode) Then
                            Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
                            If existingItem IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(existingItem.Item3.ToString().Trim()) Then
                                AddSqlField(fields, values, oppMasterCode, existingItem.Item3.ToString().Trim())
                            End If
                        End If
                        Continue For
                    End If
                    If columnName = "" Then Continue For
                    Dim ctrl As Control = Me.Controls.Find(ctrlName, True).FirstOrDefault()
                    If ctrl Is Nothing Then Continue For
                    AddSqlField(fields, values, columnName, GetControlValue(ctrl, dr("INPUTTYPE").ToString().Trim()))
                    Dim existingItem2 = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
                    If existingItem2 IsNot Nothing AndAlso existingItem2.Item2.ToString().Trim() <> "" Then
                        AddSqlField(fields, values, existingItem2.Item2.ToString().Trim(), existingItem2.Item3.ToString().Trim())
                    End If
                Next
                Dim tableColumns As New HashSet(Of String)(tableGroup.Where(Function(r) Not r("DataBaseColumn").ToString().Trim().StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase)).Select(Function(r) r("DataBaseColumn").ToString().Trim()), StringComparer.OrdinalIgnoreCase)
                If tableColumns.Contains("BOOKVNO") Then
                    AddSqlField(fields, values, "BOOKVNO", _BookVNo)
                End If
                If tableColumns.Contains("BOOKCODE") Then
                    AddSqlField(fields, values, "BOOKCODE", _Bookcode)
                End If
                If tableColumns.Contains("BOOKTRTYPE") Then
                    AddSqlField(fields, values, "BOOKTRTYPE", _Booktrtype)
                End If
                RemoveLastComma(fields)
                RemoveLastComma(values)
                If fields.Length > 0 Then
                    ControlQueries.Add("INSERT INTO " & tableName & "(" & fields.ToString().ToUpper() & ") VALUES (" & values.ToString() & ")")
                End If
            Next
            '================ GRID TABLES ================
            'For gridIndex As Integer = 0 To tables.Count - 1
            '    Dim gridDt As DataTable = tables(gridIndex)
            '    If gridDt Is Nothing OrElse gridDt.Rows.Count = 0 Then Continue For
            '    Dim gridName As String = gridNames(gridIndex)
            '    Dim gridRows() As DataRow = _MainColumTbl.Select("ColumnType='Grid' AND CntrlName='" & gridName.Replace("'", "''") & "' AND FormDesignType='GRID DETAIL DESIGN' AND DataBaseTable IS NOT NULL AND DataBaseTable<>''", "OrderNo")
            '    If gridRows.Length = 0 Then Continue For
            '    Dim tableName As String = gridRows(0)("DataBaseTable").ToString().Trim()
            '    If tableName = "" Then Continue For
            '    _TableName = tableName
            '    Dim Query_Auto_Grid(gridDt.Rows.Count - 1, 4) As String
            '    Dim usedGridRows() As DataRow = gridRows.Where(Function(r) Not r("DataBaseColumn").ToString().Trim().StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase)).ToArray()
            '    If usedGridRows.Length = 0 Then Continue For
            '    For r As Integer = 0 To gridDt.Rows.Count - 1
            '        For c As Integer = 0 To 4
            '            If c >= gridDt.Columns.Count Then
            '                Query_Auto_Grid(r, c) = ""
            '                Continue For
            '            End If

            '            Dim currentColumn As String =
            '    gridDt.Columns(c).ColumnName.Trim()

            '            Dim noColumnRow As DataRow =
            '    gridRows.FirstOrDefault(
            '        Function(x)
            '            Return String.Equals(
            '                x("DataBaseColumn").ToString().Trim(),
            '                currentColumn,
            '                StringComparison.OrdinalIgnoreCase) AndAlso
            '                currentColumn.StartsWith(
            '                    "NO COLUMN USE",
            '                    StringComparison.OrdinalIgnoreCase)
            '        End Function)

            '            If noColumnRow IsNot Nothing Then

            '                ' NO COLUMN USE row ka OppMasterCode
            '                Dim oppMasterCode As String =
            '        noColumnRow("OppMasterCode").ToString().Trim()

            '                If Not String.IsNullOrWhiteSpace(oppMasterCode) AndAlso
            '       gridDt.Columns.Contains(oppMasterCode) Then

            '                    ' OppMasterCode ki ACTUAL VALUE save hogi
            '                    Query_Auto_Grid(r, c) =
            '            gridDt.Rows(r)(oppMasterCode).ToString()

            '                Else
            '                    Query_Auto_Grid(r, c) = ""
            '                End If

            '            Else

            '                ' Normal grid column
            '                Query_Auto_Grid(r, c) =
            '        gridDt.Rows(r)(c).ToString()

            '            End If
            '        Next
            '    Next
            '    Dim fields As New StringBuilder()
            '    Dim values As New StringBuilder()
            '    For Each dr As DataRow In _MainColumTbl.Select("(ColumnType='TextBox' OR ColumnType='CheckBox') AND DataBaseTable='" & tableName.Replace("'", "''") & "'", "OrderNo")
            '        Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
            '        If columnName = "" OrElse columnName.StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) Then Continue For
            '        Dim ctrl As Control = Me.Controls.Find(dr("CntrlName").ToString().Trim(), True).FirstOrDefault()
            '        If ctrl Is Nothing Then Continue For
            '        AddSqlField(fields, values, columnName, GetControlValue(ctrl, dr("INPUTTYPE").ToString().Trim()))
            '    Next
            '    Dim gridColumns As New HashSet(Of String)(gridRows.Select(Function(r) r("DataBaseColumn").ToString().Trim()), StringComparer.OrdinalIgnoreCase)
            '    'If gridColumns.Contains("BOOKVNO") Then fields.Append("BOOKVNO,") : values.Append(_BookVNo & ",")
            '    'If gridColumns.Contains("BOOKCODE") Then fields.Append("BOOKCODE,") : values.Append(_Bookcode & ",")
            '    'If gridColumns.Contains("BOOKTRTYPE") Then fields.Append("BOOKTRTYPE,") : values.Append(_Booktrtype & ",")
            '    RemoveLastComma(fields)
            '    RemoveLastComma(values)
            '    Dim QueryDetailTable As String =
            '    ObjCls_General.GetQueryArray(tableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, gridDt, _FieldNotRequiredForSave.ToString().ToUpper(), _RecordsKeyFieldName, "", "", "N", fields.ToString().ToUpper(), values.ToString(), _ExtraFieldOthers.ToString().ToUpper(), _ExtraField_Values_Others.ToString().ToUpper(), _FieldDefaultValues.ToString().ToUpper())
            '    If Not String.IsNullOrWhiteSpace(QueryDetailTable) Then
            '        GridQueries.Add(QueryDetailTable.Trim())
            '    End If
            '    arr_object = Query_Auto_Grid
            'Next
            For gridIndex As Integer = 0 To tables.Count - 1
                Dim gridDt As DataTable = tables(gridIndex)
                If gridDt Is Nothing OrElse gridDt.Rows.Count = 0 Then Continue For
                Dim gridName As String = gridNames(gridIndex)
                Dim gridRows() As DataRow = _MainColumTbl.Select("ColumnType='Grid' AND CntrlName='" & gridName.Replace("'", "''") & "' AND FormDesignType='GRID DETAIL DESIGN' " & "AND DataBaseTable IS NOT NULL AND DataBaseTable<>''", "OrderNo")
                If gridRows.Length = 0 Then Continue For
                Dim tableName As String = gridRows(0)("DataBaseTable").ToString().Trim()
                If tableName = "" Then Continue For
                _TableName = tableName
                Dim SaveGridDt As DataTable = gridDt.Copy()
                For Each dr As DataRow In gridRows
                    Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
                    If Not columnName.StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) Then
                        Continue For
                    End If
                    Dim oppMasterCode As String = dr("OppMasterCode").ToString().Trim()
                    If String.IsNullOrWhiteSpace(oppMasterCode) Then Continue For
                    If SaveGridDt.Columns.Contains(oppMasterCode) Then
                        If SaveGridDt.Columns.Contains(columnName) Then
                            SaveGridDt.Columns.Remove(columnName)
                        End If
                    ElseIf SaveGridDt.Columns.Contains(columnName) Then
                        SaveGridDt.Columns(columnName).ColumnName = oppMasterCode
                    End If
                Next
                Dim usedGridRows() As DataRow = gridRows.Where(Function(r) Not r("DataBaseColumn").ToString().Trim().StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase)).ToArray()
                If usedGridRows.Length = 0 Then Continue For
                Dim Query_Auto_Grid(SaveGridDt.Rows.Count - 1, 4) As String
                For r As Integer = 0 To SaveGridDt.Rows.Count - 1
                    For c As Integer = 0 To 4
                        If c >= SaveGridDt.Columns.Count Then
                            Query_Auto_Grid(r, c) = ""
                        Else
                            Query_Auto_Grid(r, c) = SaveGridDt.Rows(r)(c).ToString()
                        End If
                    Next
                Next
                Dim fields As New StringBuilder()
                Dim values As New StringBuilder()
                For Each dr As DataRow In _MainColumTbl.Select("(ColumnType='TextBox' OR ColumnType='CheckBox') AND " & "DataBaseTable='" & tableName.Replace("'", "''") & "'", "OrderNo")
                    Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
                    If columnName = "" OrElse columnName.StartsWith("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) Then
                        Continue For
                    End If
                    Dim ctrl As Control = Me.Controls.Find(dr("CntrlName").ToString().Trim(), True).FirstOrDefault()
                    If ctrl Is Nothing Then Continue For
                    AddSqlField(fields, values, columnName, GetControlValue(ctrl, dr("INPUTTYPE").ToString().Trim()))
                Next
                Dim gridColumns As New HashSet(Of String)(gridRows.Select(Function(r) r("DataBaseColumn").ToString().Trim()), StringComparer.OrdinalIgnoreCase)
                If gridColumns.Contains("BOOKVNO") Then
                    fields.Append("BOOKVNO,")
                    values.Append(_BookVNo & ",")
                End If
                If gridColumns.Contains("BOOKCODE") Then
                    fields.Append("BOOKCODE,")
                    values.Append(_Bookcode & ",")
                End If
                If gridColumns.Contains("BOOKTRTYPE") Then
                    fields.Append("BOOKTRTYPE,")
                    values.Append(_Booktrtype & ",")
                End If
                RemoveLastComma(fields)
                RemoveLastComma(values)
                Dim QueryDetailTable As String = ObjCls_General.GetQueryArray(tableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, SaveGridDt, _FieldNotRequiredForSave.ToString().ToUpper(), _RecordsKeyFieldName, "", "", "N", fields.ToString().ToUpper(), values.ToString(), _ExtraFieldOthers.ToString().ToUpper(), _ExtraField_Values_Others.ToString().ToUpper(), _FieldDefaultValues.ToString().ToUpper())
                If Not String.IsNullOrWhiteSpace(QueryDetailTable) Then
                    GridQueries.Add(QueryDetailTable.Trim())
                End If
                arr_object = Query_Auto_Grid
            Next
            For Each q As String In ControlQueries.Concat(GridQueries)
                If String.IsNullOrWhiteSpace(q) Then Continue For
                If FinalQuery.Length > 0 Then FinalQuery.AppendLine()
                FinalQuery.AppendLine(q.TrimEnd(";"c) & ";")
            Next
            Return FinalQuery.ToString()
        Catch ex As Exception
            MsgBox(ex.ToString())
            Return ""
        End Try
    End Function
    Private Function GetControlValue(ctrl As Control, inputType As String) As String
        Dim value As String = ""
        If TypeOf ctrl Is CheckBox Then
            value = If(DirectCast(ctrl, CheckBox).Checked, "1", "0")
        ElseIf TypeOf ctrl Is TextBox Then
            value = DirectCast(ctrl, TextBox).Text.Trim().Trim("'"c)
            If inputType.Equals("DateBox", StringComparison.OrdinalIgnoreCase) AndAlso value <> "" Then
                Dim dt As DateTime
                value = If(DateTime.TryParse(value, dt), dt.ToString("yyyy-MM-dd"), "")
            End If
        End If
        Return value
    End Function

    Private Function SqlValue(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return "NULL"
        If IsNumeric(value) Then Return value
        Return "'" & value.Replace("'", "''") & "'"
    End Function

    Private Sub AddSqlField(ByVal fields As StringBuilder, ByVal values As StringBuilder, ByVal fieldName As String, ByVal value As String)
        fields.Append(fieldName).Append(",")
        values.Append(SqlValue(value)).Append(",")
    End Sub

    Private Sub RemoveLastComma(ByVal sb As StringBuilder)
        If sb.Length > 0 Then sb.Length -= 1
    End Sub
    ''' <summary>
    ''' Old first
    ''' </summary>
    ''' <param name="tmptbl"></param>
    ''' <param name="_Bookcode"></param>
    'Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
    '    Try
    '        _FieldNotVisibile = New StringBuilder()
    '        '------------------------ DETAILS Table --------------------------------
    '        Dim strFilterString As String = ""
    '        Dim QueryDetailTable As String = ""
    '        'Dim Query_Auto_Grid(_DataTableGrid1.Rows.Count, 4) As String
    '        Dim tables As New List(Of DataTable) From {_DataTableGrid1, _DataTableGrid2, _DataTableGrid3, _DataTableGrid4, _DataTableGrid5}
    '        Dim totalRows As Integer = tables.Sum(Function(t) If(t IsNot Nothing, t.Rows.Count, 0))
    '        If totalRows = 0 Then
    '            Exit Function
    '        End If
    '        Dim Query_Auto_Grid(totalRows - 1, 4) As String
    '        Dim rowIndex As Integer = 0
    '        'For Each dt As DataTable In tables
    '        '    If dt IsNot Nothing Then
    '        '        For Each dr As DataRow In dt.Rows
    '        '            Query_Auto_Grid(rowIndex, 0) = dr(0).ToString()
    '        '            Query_Auto_Grid(rowIndex, 1) = dr(1).ToString()
    '        '            Query_Auto_Grid(rowIndex, 2) = dr(2).ToString()
    '        '            Query_Auto_Grid(rowIndex, 3) = dr(3).ToString()
    '        '            Query_Auto_Grid(rowIndex, 4) = dr(4).ToString()
    '        '            rowIndex += 1
    '        '        Next
    '        '    End If
    '        'Next
    '        For Each dt As DataTable In tables
    '            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Continue For
    '            For Each dr As DataRow In dt.Rows
    '                If rowIndex >= totalRows Then Exit For
    '                For colIndex As Integer = 0 To 4
    '                    If colIndex < dt.Columns.Count Then
    '                        Query_Auto_Grid(rowIndex, colIndex) = dr(colIndex).ToString()
    '                    Else
    '                        Query_Auto_Grid(rowIndex, colIndex) = ""
    '                    End If
    '                Next
    '                rowIndex += 1
    '            Next
    '            If rowIndex >= totalRows Then Exit For
    '        Next
    '        If mandatoryCol <> "" Then
    '            strFilterString = mandatoryCol & ">0"
    '        End If
    '        Dim _extrafielddatatable As New StringBuilder()
    '        Dim _extrafield_values_datatable As New StringBuilder()
    '        For Each dr As DataRow In _MainColumTbl.Select("(ColumnType='TextBox' OR ColumnType='CheckBox') AND " & "(UseMaster='NO' OR " & "(UseMaster='YES' AND " & "(OppMasterCode<>'' OR OppMasterCode='')))")
    '            If _BookVNo = "" Then
    '                _BookVNo = Generate_Book_Vno(Val(txtEntryno), _Booktrtype)
    '            End If
    '            _TableName = dr("DataBaseTable").ToString().Trim()
    '            Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
    '            Dim ctrlName As String = dr("CntrlName").ToString().Trim()
    '            Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
    '            Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
    '            Dim ctrl As Control = Me.Controls.Find(ctrlName, True).FirstOrDefault()
    '            If ctrl Is Nothing Then
    '                Continue For
    '            End If
    '            Dim value As String = ""
    '            If TypeOf ctrl Is System.Windows.Forms.CheckBox Then
    '                Dim chk As System.Windows.Forms.CheckBox = DirectCast(ctrl, System.Windows.Forms.CheckBox)
    '                If chk.Checked Then
    '                    value = "1"
    '                Else
    '                    value = "0"
    '                End If
    '            ElseIf TypeOf ctrl Is TextBox Then
    '                Dim txt As TextBox = DirectCast(ctrl, TextBox)
    '                value = txt.Text.Trim().Trim("'"c)
    '                If _InputType.Equals("DateBox", StringComparison.OrdinalIgnoreCase) Then
    '                    If value <> "" Then
    '                        Dim dt As DateTime
    '                        If DateTime.TryParse(value, dt) Then
    '                            value = dt.ToString("yyyy-MM-dd")
    '                        Else
    '                            value = ""
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                Continue For
    '            End If
    '            _extrafielddatatable.Append(columnName & ",")
    '            If value = "" Then
    '                _extrafield_values_datatable.Append(value & ",")
    '            ElseIf IsNumeric(value) Then
    '                _extrafield_values_datatable.Append(value & ",")
    '            Else
    '                _extrafield_values_datatable.Append(value.Replace("'", "''") & ",")
    '            End If
    '            If existingItem IsNot Nothing Then
    '                Dim oppColumnName As String = existingItem.Item2
    '                Dim codeValue As String = existingItem.Item3
    '                If Not String.IsNullOrWhiteSpace(oppColumnName) Then
    '                    _extrafielddatatable.Append(oppColumnName & ",")
    '                    If String.IsNullOrWhiteSpace(codeValue) Then
    '                        _extrafield_values_datatable.Append("NULL,")
    '                    ElseIf IsNumeric(codeValue) Then
    '                        _extrafield_values_datatable.Append(codeValue & ",")
    '                    Else
    '                        _extrafield_values_datatable.Append(codeValue.Replace("'", "''") & ",")
    '                    End If
    '                End If
    '            End If
    '        Next
    '        ' 🔹 Add BookVno
    '        _extrafielddatatable.Append("BookVno,")
    '        _extrafield_values_datatable.Append("" & _BookVNo.Replace("'", "''") & ",")
    '        ' 🔹 Add BookCode
    '        _extrafielddatatable.Append("BookCode,")
    '        _extrafield_values_datatable.Append("" & _Bookcode.Replace("'", "''") & ",")
    '        ' 🔹 Add BookTrType
    '        _extrafielddatatable.Append("BookTrType,")
    '        _extrafield_values_datatable.Append("" & _Booktrtype.Replace("'", "''") & ",")
    '        ' 🔹 Remove last comma safely (ONLY ONCE)
    '        If _extrafielddatatable.Length > 0 Then
    '            _extrafielddatatable.Length -= 1
    '        End If
    '        If _extrafield_values_datatable.Length > 0 Then
    '            _extrafield_values_datatable.Length -= 1
    '        End If
    '        QueryDetailTable = ObjCls_General.GetQueryArray(_TableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid1, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _extrafielddatatable.ToString.ToUpper, _extrafield_values_datatable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
    '        GridDetailsSaveQuery = QueryDetailTable & ""
    '        arr_object = Query_Auto_Grid
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '    End Try
    'End Function


    Public Sub LoadViewData(ByVal tmptbl As DataTable, ByVal _Bookcode As String)
        Try
            Generate_Date_For_DataBase(Txt_ViewFrom)
            Generate_Date_For_DataBase(Txt_ViewTO)
            Dim ResultTable As New DataTable
            If tmptbl IsNot Nothing AndAlso tmptbl.Rows.Count > 0 AndAlso Not tmptbl.Columns.Contains("Mainid") Then
                ResultTable = tmptbl.Copy()
            Else
                Dim FilterBookcode As String = " '" & _Bookcode & "' "
                Dim FilterFrom As String = "'" & Txt_ViewFrom.Date_for_Database & "'"
                Dim FilterTO As String = " '" & Txt_ViewTO.Date_for_Database & "'"
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
                If DefaltSoftTable IsNot Nothing Then
                    ResultTable = DefaltSoftTable.Copy()
                End If
            End If
            FirstStage.Columns.Clear()
            If ResultTable IsNot Nothing AndAlso ResultTable.Rows.Count > 0 Then
                GridControl1.DataSource = Nothing
                GridControl1.DataSource = ResultTable.Copy()
                DevGridFitColumn(GridControl1, FirstStage)
                FirstStage.OptionsView.ShowFooter = True
                Dim ViewQueryTotal As String = GetQuery(tmptbl, "ViewGridColumnTotal", "VIEW")
                If ViewQueryTotal <> "" Then
                    Dim ColumnList As String = ViewQueryTotal
                    Dim Columns() As String = ColumnList.Split(","c)
                    For Each col As String In Columns
                        col = col.Trim()
                        If col <> "" AndAlso FirstStage.Columns.ColumnByFieldName(col) IsNot Nothing Then
                            FirstStage.Columns(col).Summary.Clear()
                            FirstStage.Columns(col).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col, "{0:n2}")
                        End If
                    Next
                End If
                Dim ViewQueryHide As String = GetQuery(tmptbl, "ViewGridColumnHide", "VIEW")
                If ViewQueryHide <> "" Then
                    Dim ColumnList As String = ViewQueryHide
                    Dim HideColumns() As String = ColumnList.Split(","c)
                    For Each col As String In HideColumns
                        col = col.Trim()
                        If col <> "" AndAlso FirstStage.Columns.ColumnByFieldName(col) IsNot Nothing Then
                            FirstStage.Columns(col).Visible = False
                        End If
                    Next
                End If
                PnlGrdView.Visible = True
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
#Region "DELETE CODE"
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        _FrmLoad = True
        If GrdObj.Cell(GrdObj.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf("SRNO") + 1).ForeColor <> Color.Red Then
            GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).DeleteByRow()
            GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = GrdObj.ActiveCell.Row
        End If
        _FrmLoad = False
    End Sub
    Private Sub Delete_Entry()
        Try
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
                MsgBox("Entry Successfully Deleted")
            Catch ex As Exception
                MsgBox("Error While Delete Entry")
            Finally
                cmd = Nothing
            End Try
            _FrmLoad = False
        Catch ex As Exception
            MsgBox("Error While Delete Entry")
        End Try
    End Sub
#End Region

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
        _FieldNotRequiredForSave = New StringBuilder()
        _FieldUseHeaderColumn = New StringBuilder()
        'Dim filter As String = "ColumnType='" & columnTypeFilter.Replace("'", "''") & "'"
        Dim filter As String = "ColumnType='" & columnTypeFilter.Replace("'", "''") & "' AND " & "CntrlName='" & ctrlname & "'"
        For Each dr As DataRow In _MainColumTbl.Select(filter, "OrderNo")
            _TblName = dr("DataBaseTable").ToString().Trim()
            Dim colName As String = dr("DataBaseColumn").ToString().Trim()
            Dim colType As String = dr("ColumnType").ToString().Trim()
            Dim header As String = dr("UserText").ToString().Trim()
            Dim alignVal As String = dr("TextAlign").ToString().Trim().ToUpper()
            Dim cntrlName As String = dr("CntrlName").ToString().Trim()
            If alignVal = "" Then
                alignVal = "L"
            End If
            If header = "" OrElse colName = "" Then
                Continue For
            End If
            'Dim saveYN As String = dr("SaveYN").ToString().Trim().ToUpper()
            'If saveYN = "N" Then
            '    Continue For
            'End If
            Select Case cntrlName.ToUpper()
                Case "GRID1"
                    If _Grid1ColNames.Length > 0 Then
                        _Grid1ColNames.Append(",")
                    End If
                    _Grid1ColNames.Append(colName)
                Case "GRID2"
                    If _Grid2ColNames.Length > 0 Then
                        _Grid2ColNames.Append(",")
                    End If
                    _Grid2ColNames.Append(colName)
                Case "GRID3"
                    If _Grid3ColNames.Length > 0 Then
                        _Grid3ColNames.Append(",")
                    End If
                    _Grid3ColNames.Append(colName)
                Case "GRID4"
                    If _Grid4ColNames.Length > 0 Then
                        _Grid4ColNames.Append(",")
                    End If
                    _Grid4ColNames.Append(colName)
                Case "GRID5"
                    If _Grid5ColNames.Length > 0 Then
                        _Grid5ColNames.Append(",")
                    End If
                    _Grid5ColNames.Append(colName)
            End Select
            If header <> "" Then
                If _FieldHeader.Length > 0 Then
                    _FieldHeader.Append(",")
                End If
                _FieldHeader.Append(colName & ":" & header)
            End If
            If _FieldHeaderAlignment.Length > 0 Then
                _FieldHeaderAlignment.Append(",")
            End If
            _FieldHeaderAlignment.Append(colName & ":" & alignVal)
            If _FieldAlignMent.Length > 0 Then
                _FieldAlignMent.Append(",")
            End If
            _FieldAlignMent.Append(colName & ":" & alignVal)
            'UseHeaderColumn
            Dim useHeaderColumnVal As String = dr("UseHeaderColumn").ToString().Trim()
            If _FieldUseHeaderColumn.Length > 0 Then
                _FieldUseHeaderColumn.Append(",")
            End If
            _FieldUseHeaderColumn.Append(colName & ":" & useHeaderColumnVal)
            Dim widthVal As Integer = Val(dr("SizeWidth").ToString().Trim())
            If _FieldWidthSet.Length > 0 Then
                _FieldWidthSet.Append(",")
            End If
            _FieldWidthSet.Append(colName & ":" & widthVal)
            Dim visibleVal As String = dr("Visible").ToString().Trim().ToUpper()
            If visibleVal = "" Then
                visibleVal = "N"
            End If
            If _FieldNotVisibile.Length > 0 Then
                _FieldNotVisibile.Append(",")
            End If
            _FieldNotVisibile.Append(colName & ":" & visibleVal)
            Dim lockVal As String = dr("ReadOnly").ToString().Trim().ToUpper()
            If lockVal = "" Then
                lockVal = "N"
            End If
            If _FieldLocked.Length > 0 Then
                _FieldLocked.Append(",")
            End If
            _FieldLocked.Append(colName & ":" & lockVal)
            Dim colInputType As String = dr("InputType").ToString().Trim().ToUpper()
            If colInputType = "NUMERIC" Then
                colType = "N"
                If _Grid1ColType.Length > 0 Then
                    _Grid1ColType.Append(",")
                End If
                _Grid1ColType.Append(colName & ":" & colType)
            End If
            Dim prec As Integer = Val(dr("Masking").ToString())
            If colInputType = "NUMERIC" Then
                Dim maskVal As String = "NO-" & prec.ToString()
                If _FieldMasking.Length > 0 Then
                    _FieldMasking.Append(",")
                End If
                _FieldMasking.Append(colName & ":" & maskVal)
            End If
            Dim notrequired As String = dr("SaveYN").ToString().Trim().ToUpper()
            If notrequired = "N" Then
                If _FieldNotRequiredForSave.Length > 0 Then
                    _FieldNotRequiredForSave.Append(",")
                End If
                _FieldNotRequiredForSave.Append(colName & ":" & notrequired)
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
            Dim _Grid1ColNames As New StringBuilder()
            Dim _Grid1HeaderNames As New List(Of String)
            Dim View_Filter_Condition As String = " AND FormName='" & MainLoadFormName & "' "
            DynamicTabControl = Nothing
            CurrentTabPage = Nothing
            Dim CurrentDynamicTabControl As TabControl = Nothing
            Dim DynamicTabControls As New List(Of TabControl)
            If MainLoadFormName = "" Then
                BtnUpdatepos.Enabled = False
                btnmovecontrol.Enabled = False
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
                .Append("Select * FROM " & _DatabaseTableName & " WHERE 1=1 ")
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
                    If _FORMMODE = "EDIT" OrElse
                       _FORMMODE = "DELETE" OrElse
                       _FORMMODE = "VIEW" Then
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
                    If userTextValue.StartsWith("Attach Image", StringComparison.OrdinalIgnoreCase) Then
                        txt.Tag = userTextValue
                        txt.AccessibleName = databaseColumn
                        txt.AccessibleDescription = ""
                    Else
                        If _FORMMODE = "EDIT" Then
                            txt.AccessibleDescription = databaseColumn
                            If databaseColumn.Equals("NO COLUMN USE", StringComparison.OrdinalIgnoreCase) OrElse databaseColumn.StartsWith("NO COLUMN USE ", StringComparison.OrdinalIgnoreCase) Then
                                txt.Tag = userTextValue
                            Else
                                txt.Tag = databaseColumn
                            End If
                        Else
                            txt.Tag = databaseColumn
                            txt.AccessibleDescription = databaseColumn
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
                            AddHandler txt.KeyDown, AddressOf EntryNoControl_KeyDown
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
                    If Me.SBimgadd.ImageOptions.Image IsNot Nothing Then
                        btn.ImageOptions.Image = New Bitmap(Me.SBimgadd.ImageOptions.Image)
                    End If
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
                    AddHandler btn.Click, AddressOf ButtonImgAdd_Click
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
                    If Me.SBImgView.ImageOptions.Image IsNot Nothing Then
                        btn.ImageOptions.Image = New Bitmap(Me.SBImgView.ImageOptions.Image)
                    End If
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
                    AddHandler btn.Click, AddressOf ButtonImgAdd_Click
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
            BtnUpdatepos.Enabled = True
            btnmovecontrol.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        Finally
        End Try
    End Sub
#Region "control view"
    Private Sub ButtonImgAdd_Click(sender As Object, e As EventArgs)
        If isMoveMode Then Exit Sub
        Dim btn As SimpleButton = TryCast(sender, SimpleButton)
        If btn Is Nothing Then Exit Sub
        Dim buttonText As String = btn.Text.Trim().ToUpper()
        If buttonText = "ADD" Then
            ImgAddImage(btn)
        ElseIf buttonText = "VIEW" Then
            ImgViewImage(btn)
        End If
    End Sub
    Private Sub ImgAddImage(btn As SimpleButton)
        Try
            If isMoveMode Then Exit Sub
            Dim flagstring As String = ""
            If _FORMMODE = "ADD" Then
                flagstring = "save"
            ElseIf _FORMMODE = "EDIT" Then
                flagstring = "update"
            End If
            If btn Is Nothing OrElse btn.Tag Is Nothing Then
                MessageBox.Show("Image TextBox reference not found.")
                Exit Sub
            End If
            Dim txt As TextBox = FindTextBoxByTag(Me, btn.Tag.ToString())
            If txt Is Nothing Then
                MessageBox.Show("Image TextBox not found." & vbCrLf & "Tag : " & btn.Tag.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Using ofd As New OpenFileDialog()
                ofd.Title = "Select Image"
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
                If ofd.ShowDialog() <> DialogResult.OK Then Exit Sub
                Dim imagePath As String = ofd.FileName.Trim()
                If String.IsNullOrWhiteSpace(imagePath) Then Exit Sub
                txt.AccessibleDescription = imagePath
                txt.Text = IO.Path.GetFileName(imagePath)
                If My.Computer.Network.IsAvailable Then
                    txt.Text = ""
                    'Dim resultPath As String = SubmitComplaintAsync(imagePath, flagstring, "", _FORMMODE)
                    Dim resultPath As String = UploadImageInServer(imagePath)
                    If Not String.IsNullOrWhiteSpace(resultPath) Then
                        resultPath = resultPath.Trim()
                        txt.AccessibleDescription = resultPath
                        txt.Text = resultPath
                    Else
                        txt.AccessibleDescription = imagePath
                        txt.Text = IO.Path.GetFileName(imagePath)
                    End If
                Else
                    txt.AccessibleDescription = imagePath
                    txt.Text = IO.Path.GetFileName(imagePath)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub ImgViewImage(btn As SimpleButton)
        Try
            If isMoveMode Then Exit Sub
            If btn.Tag Is Nothing Then
                MessageBox.Show("Image TextBox reference not found.")
                Exit Sub
            End If
            Dim txt As TextBox =
            FindTextBoxByTag(Me, btn.Tag.ToString())
            If txt Is Nothing Then
                MessageBox.Show("Image TextBox not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim imagePath As String = ""
            If txt.AccessibleDescription IsNot Nothing Then
                imagePath = txt.AccessibleDescription.ToString().Trim()
            End If
            If String.IsNullOrWhiteSpace(imagePath) Then
                MessageBox.Show("Please select an image first.", "Image", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If imagePath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) OrElse imagePath.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then
                ShowImagePopupFromUrl(imagePath)
            Else
                If Not IO.File.Exists(imagePath) Then
                    MessageBox.Show("Image file not found." & vbCrLf & imagePath, "Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                ShowImagePopup(imagePath)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function FindTextBoxByTag(parent As Control, searchTag As String) As TextBox
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                If ctrl.Tag IsNot Nothing AndAlso
               String.Equals(ctrl.Tag.ToString().Trim(), searchTag.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    Return DirectCast(ctrl, TextBox)
                End If
            End If
            If ctrl.HasChildren Then
                Dim foundTextBox As TextBox = FindTextBoxByTag(ctrl, searchTag)
                If foundTextBox IsNot Nothing Then
                    Return foundTextBox
                End If
            End If
        Next
        Return Nothing
    End Function
    Private Sub ShowImagePopupFromUrl(imageUrl As String)
        Try
            Dim frm As New Form()
            frm.Text = "Image Preview"
            frm.StartPosition = FormStartPosition.CenterParent
            frm.Width = 800
            frm.Height = 600
            Dim pic As New PictureBox()
            pic.Dock = DockStyle.Fill
            pic.SizeMode = PictureBoxSizeMode.Zoom
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(imageUrl)
            Using response As System.Net.WebResponse = request.GetResponse()
                Using stream As IO.Stream = response.GetResponseStream()
                    Using tempImage As System.Drawing.Image =
                    System.Drawing.Image.FromStream(stream)
                        pic.Image = New System.Drawing.Bitmap(tempImage)
                    End Using
                End Using
            End Using
            frm.Controls.Add(pic)
            frm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Unable to load image." & vbCrLf & ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ShowImagePopup(imagePath As String)
        Dim frm As New Form()
        frm.Text = "Image Preview"
        frm.StartPosition = FormStartPosition.CenterParent
        frm.Width = 800
        frm.Height = 600
        Dim pic As New PictureBox()
        pic.Dock = DockStyle.Fill
        pic.SizeMode = PictureBoxSizeMode.Zoom
        Using fs As New System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Using tempImage As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
                pic.Image = New System.Drawing.Bitmap(tempImage)
            End Using
        End Using
        frm.Controls.Add(pic)
        frm.ShowDialog()
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
            If Not String.IsNullOrWhiteSpace(txtEntryno) Then
                ControlName = txtEntryno.Trim()
            End If
            If ControlName <> "" Then
                Dim controlTableRows() As DataRow = _MainColumTbl.Select("CntrlName='" & ControlName.Replace("'", "''") & "' AND " & "DataBaseTable IS NOT NULL AND " & "DataBaseTable<>''")
                If controlTableRows.Length > 0 Then
                    _TblName = controlTableRows(0)("DataBaseTable").ToString().Trim()
                Else
                    _TblName = ""
                End If
            Else _TblName = ""
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
        'defineGridColName()
        'defineGridColName("TextBox", "")
        'defineGridColName("CheckBox", "")
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
            Else
                Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
                If ctrl.Length > 0 Then
                    Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
                    '_GetAlterData(Entytxt.Text)
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
                If MsgBox("Do You Want To Delete (Y/N)", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Entry()
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visible_Falseform(Me.Controls)
                    UC_Buttons1._ButtonEnableDisable("LOAD")
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                End If
            End If
        End If
    End Sub

    Private Sub _GetAlterData(ByVal _EntryNo As Int64)
        Try
            Dim TableNames As New List(Of Tuple(Of String, String, String))
            For Each dr As DataRow In _MainColumTbl.Select("DataBaseTable IS NOT NULL AND DataBaseTable<>''")
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
                    If tblTmp Is Nothing OrElse tblTmp.Rows.Count = 0 Then
                        MsgBox("No Record Found")
                        Exit Sub
                    End If
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
                        CalculateDynamicColumnTotal(grd, _DataTableGrid1, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid2, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid3, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid4, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid5, tmptbl)
                    Else
                        MsgBox("Record Not Found")
                        ObjCls_General.Blank_Object(Me)
                        Clear_Grid(grd, 2)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid1, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid2, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid3, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid4, tmptbl)
                        CalculateDynamicColumnTotal(grd, _DataTableGrid5, tmptbl)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Soft-Tex PRO")
        End Try
    End Sub
    Private Function GetAllControlsIncludingTabs(ByVal parent As Control) As List(Of Control)
        Dim result As New List(Of Control)
        For Each ctrl As Control In parent.Controls
            result.Add(ctrl)
            If TypeOf ctrl Is System.Windows.Forms.TabControl Then
                Dim tc As System.Windows.Forms.TabControl = DirectCast(ctrl, System.Windows.Forms.TabControl)
                For Each tp As System.Windows.Forms.TabPage In tc.TabPages
                    result.Add(tp)
                    If tp.HasChildren Then
                        result.AddRange(GetAllControlsIncludingTabs(tp))
                    End If
                Next
            ElseIf ctrl.HasChildren Then
                result.AddRange(GetAllControlsIncludingTabs(ctrl))
            End If
        Next
        Return result
    End Function
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
        'If _FORMMODE = "VIEW" Then
        '    Dim tblTmp1 As New DataTable
        '    Dim ctrl As Control() = Me.Controls.Find(txtEntryno, True)
        '    If ctrl.Length > 0 Then
        '        Dim Entytxt As TextBox = CType(ctrl(0), TextBox)
        '        tblTmp1 = Alter_EntryForm(Entytxt.Text)
        '    End If
        '    tmptbl = _GetFormQuery(FormNameValue, "VIEW")
        '    If tmptbl.Rows.Count > 0 Then
        '        LoadViewData(tmptbl, _Bookcode)
        '    Else
        '        LoadViewData(tblTmp1, _Bookcode)
        '    End If
        'ElseIf _FORMMODE = "LOAD" Then
        '    tmptbl = _GetFormQuery(FormNameValue, "TOTAL COLUMN")
        'End If
        isMoveMode = False
        isDragging = False
    End Sub
    'Private Function Alter_EntryForm(ByVal Entryno As String) As DataTable
    '    Dim TableNames As New List(Of Tuple(Of String, String, String))
    '    For Each dr As DataRow In _MainColumTbl.Select("DataBaseTable IS NOT NULL AND DataBaseTable<>''")
    '        Dim TableName As String = dr("DataBaseTable").ToString().Trim()
    '        Dim ColumnType As String = dr("ColumnType").ToString().Trim()
    '        Dim ctrlName As String = dr("CntrlName").ToString().Trim()
    '        If TableName <> "" Then
    '            Dim Exists As Boolean = TableNames.Any(Function(x) _
    '            x.Item1.Equals(TableName, StringComparison.OrdinalIgnoreCase) AndAlso
    '            x.Item2.Equals(ColumnType, StringComparison.OrdinalIgnoreCase) AndAlso
    '            x.Item3.Equals(ctrlName, StringComparison.OrdinalIgnoreCase))
    '            If Not Exists Then
    '                TableNames.Add(Tuple.Create(TableName, ColumnType, ctrlName))
    '            End If
    '        End If
    '    Next
    '    Dim tblTmp As New DataTable
    '    For Each item In TableNames
    '        Dim TableName As String = item.Item1
    '        Dim FiltColumnType As String = item.Item2
    '        Dim ctrlName As String = item.Item3
    '        Dim _strquery As New StringBuilder
    '        strQuery = getAlter_Form_EntryQuery(Entryno, TableName, FiltColumnType)
    '        sqL = strQuery.ToString
    '        sql_connect_slect()
    '        tblTmp = DefaltSoftTable.Copy
    '    Next
    '    _FrmLoad = True
    '    ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)
    '    For Each dr As DataRow In _MainColumTbl.Select("Columntype='TextBox'  AND (UseMaster='NO' OR (UseMaster='YES'AND (OppMasterCode<>'' or OppMasterCode='')))")
    '        Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
    '        Dim ctrlName As String = dr("CntrlName").ToString().Trim()
    '        Dim columnName As String = dr("DataBaseColumn").ToString().Trim()
    '        Dim UseMaster As String = dr("UseMaster").ToString().Trim()
    '        Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
    '        Dim ctrl As Control = Me.Controls.Find(ctrlName, True).FirstOrDefault()
    '        If ctrl Is Nothing OrElse Not TypeOf ctrl Is TextBox Then Continue For
    '        Dim txt As TextBox = DirectCast(ctrl, TextBox)
    '        Dim value As String = txt.Text.Trim().Trim("'"c)
    '        If _InputType = "DateBox" Then
    '            If value <> "" Then
    '                value = Convert.ToDateTime(value).ToString("dd/MM/yyyy")
    '                txt.Text = value
    '            End If
    '        End If
    '        If UseMaster = "YES" Then
    '            Dim ActivetextName As String = ctrl.Text
    '            RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)
    '            Me.SelectNextControl(ctrl, True, True, True, True)
    '        End If
    '    Next
    '    If tblTmp.Rows.Count > 0 Then
    '        _BookVNo = tblTmp.Rows(0).Item("bookvno").ToString
    '    End If
    '    _FrmLoad = False
    '    Return tblTmp   ' 👈 yaha return kar diya
    'End Function

    Private Sub MainFormRead_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)
        If e.KeyCode = Keys.Escape Then
            If _FORMMODE = "" Then
                Me.Close()
            Else
                If PnlGrdView.Visible = True AndAlso _FORMMODE = "VIEW" Then
                    PnlGrdView.Visible = False
                    UC_Buttons1._ButtonEnableDisable("LOAD")
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visible_Falseform(Me.Controls)
                    Exit Sub
                ElseIf PanlPropartiesWindow.Visible = True Then
                    PanlPropartiesWindow.Visible = False
                    'ElseIf _FormCloseMode = False Then
                    '    UC_Buttons1._ButtonEnableDisable("LOAD")
                    '    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                    '    ObjCls_General.Blank_Object(Me)
                    '    Ctrl_Visible_Falseform(Me.Controls)
                    '    _FormCloseMode = True
                    '    _FORMMODE = ""
                Else
                    Select Case _STRTRNOBJECT
                        Case "GRID1", "GRID2", "GRID3", "GRID4", "GRID5"
                            _FrmLoad = True
                            Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(_STRTRNOBJECT, True).FirstOrDefault(), FlexCell.Grid)
                            grd.BoldFixedCell = False
                            _FrmLoad = False
                            _FORMMODE = ""
                        Case Else
                            _FrmLoad = True
                            ObjCls_General.Blank_Object(Me)
                            For i As Integer = 1 To 5
                                Dim gridName As String = "GRID" & i.ToString()
                                Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(gridName, True).FirstOrDefault(), FlexCell.Grid)
                                If grd IsNot Nothing Then
                                    Clear_Grid(grd, 2)
                                    grd.BoldFixedCell = False
                                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, grd)
                                    grd.BoldFixedCell = False
                                End If
                            Next
                            _KeyFieldValue = 0
                            UC_Buttons1._ButtonEnableDisable("LOAD")
                            UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                            Ctrl_Visible_Falseform(Me.Controls)
                            _FrmLoad = False
                            _FORMMODE = ""
                    End Select
                End If
            End If
        ElseIf e.KeyCode = Keys.F6 Then
            PanlPropartiesWindow.Visible = True
            If PropertyGrid1.SelectedObject Is Nothing AndAlso Me.ActiveControl IsNot Nothing Then
                PropertyGrid1.SelectedObject = Me.ActiveControl
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.Q Then
            Dim entryformname As New QueryLoad()
            entryformname.GetformName = Me._getformName()
            entryformname.GetformId = _getformId()
            entryformname.Show()
            'QueryLoad.Show()
        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT

                Case "GRID1"
                    If _DataTableGrid2 IsNot Nothing AndAlso _DataTableGrid2.Columns.Count > 0 Then
                        _FrmLoad = True
                        Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find("GRID2", True).FirstOrDefault(), FlexCell.Grid)
                        If grd IsNot Nothing Then
                            grd.Cell(1, _DataTableGrid2.Columns.IndexOf("SRNO") + 2).SetFocus()
                            grd.Focus()
                        End If
                    ElseIf _DataTableGrid3 IsNot Nothing AndAlso _DataTableGrid3.Columns.Count > 0 Then
                        _FrmLoad = True
                        Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find("GRID3", True).FirstOrDefault(), FlexCell.Grid)
                        If grd IsNot Nothing Then
                            grd.Cell(1, _DataTableGrid3.Columns.IndexOf("SRNO") + 1).SetFocus()
                            grd.Focus()
                        End If
                    Else
                        UC_Buttons1.BtnSave.Focus()
                    End If
                Case "GRID2"
                    If _DataTableGrid3 IsNot Nothing AndAlso _DataTableGrid3.Columns.Count > 0 Then
                        _FrmLoad = True
                        Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find("GRID3", True).FirstOrDefault(), FlexCell.Grid)
                        If grd IsNot Nothing Then
                            grd.Cell(1, _DataTableGrid3.Columns.IndexOf("SRNO") + 1).SetFocus()
                            grd.Focus()
                        End If
                    Else
                        UC_Buttons1.BtnSave.Focus()
                    End If
                Case "GRID3"
                    If _DataTableGrid4 IsNot Nothing AndAlso _DataTableGrid4.Columns.Count > 0 Then
                        _FrmLoad = True
                        Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find("GRID4", True).FirstOrDefault(), FlexCell.Grid)
                        If grd IsNot Nothing Then
                            grd.Cell(1, _DataTableGrid4.Columns.IndexOf("SRNO") + 1).SetFocus()
                            grd.Focus()
                        End If
                    Else
                        UC_Buttons1.BtnSave.Focus()
                    End If
                Case "GRID4"
                    If _DataTableGrid5 IsNot Nothing AndAlso _DataTableGrid5.Columns.Count > 0 Then
                        _FrmLoad = True
                        Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find("GRID5", True).FirstOrDefault(), FlexCell.Grid)
                        If grd IsNot Nothing Then
                            grd.Cell(1, _DataTableGrid5.Columns.IndexOf("SRNO") + 1).SetFocus()
                            grd.Focus()
                        End If
                    Else
                        UC_Buttons1.BtnSave.Focus()
                    End If
                Case "GRID5"
                    UC_Buttons1.BtnSave.Focus()
                Case Else
                    If _DataTableGrid1 IsNot Nothing AndAlso _DataTableGrid1.Columns.Count > 0 Then
                        _FrmLoad = True
                        Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find("GRID1", True).FirstOrDefault(), FlexCell.Grid)
                        If grd IsNot Nothing Then
                            grd.Cell(1, _DataTableGrid1.Columns.IndexOf("SRNO") + 2).SetFocus()
                            grd.Focus()
                        End If
                    Else
                        UC_Buttons1.BtnSave.Focus()
                    End If
            End Select
        ElseIf e.KeyCode = Keys.F3 Then
            Select Case _STRTRNOBJECT
                Case "GRID1"
                    _FrmLoad = True
                    Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(_STRTRNOBJECT, True).FirstOrDefault(), FlexCell.Grid)
                    Delete_Row(grd, _DataTableGrid1)
                    Call Fill_Sr_No_Item(grd, _DataTableGrid1)
                    _FrmLoad = False
                Case "GRID2"
                    _FrmLoad = True
                    Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(_STRTRNOBJECT, True).FirstOrDefault(), FlexCell.Grid)
                    Delete_Row(grd, _DataTableGrid2)
                    Call Fill_Sr_No_Item(grd, _DataTableGrid2)
                    _FrmLoad = False
                Case "GRID3"
                    _FrmLoad = True
                    Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(_STRTRNOBJECT, True).FirstOrDefault(), FlexCell.Grid)
                    Delete_Row(grd, _DataTableGrid3)
                    Call Fill_Sr_No_Item(grd, _DataTableGrid3)
                    _FrmLoad = False
                Case "GRID4"
                    _FrmLoad = True
                    Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(_STRTRNOBJECT, True).FirstOrDefault(), FlexCell.Grid)
                    Delete_Row(grd, _DataTableGrid4)
                    Call Fill_Sr_No_Item(grd, _DataTableGrid4)
                    _FrmLoad = False
                Case "GRID5"
                    _FrmLoad = True
                    Dim grd As FlexCell.Grid = TryCast(Me.Controls.Find(_STRTRNOBJECT, True).FirstOrDefault(), FlexCell.Grid)
                    Delete_Row(grd, _DataTableGrid5)
                    Call Fill_Sr_No_Item(grd, _DataTableGrid5)
                    _FrmLoad = False
            End Select
        End If
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
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & " WHERE CntrlName='" & ctrlName & "' and FormId=" & FormId & ""
            Else
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & ",TabIndex=" & Tabindex & "  WHERE CntrlName='" & ctrlName & "' and FormId=" & FormId & ""
            End If
            RS = strQuery.ToString
            MenuDesign_QueryLoad()
        Catch ex As Exception
            MsgBox("Error While update Entry Design Position")
        Finally
            cmd = Nothing
        End Try
    End Sub
    Private Sub BtnUpdatepos_Click(sender As Object, e As EventArgs) Handles BtnUpdatepos.Click
        'For Each ctrl As Control In Me.Controls
        '    If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is Grid Then
        '        SaveControlPosition(ctrl)
        '    End If
        'Next
        SaveAllControlPositions(Me)
        isMoveMode = False
        isDragging = False
        MsgBox("Update Successfully")
        PanlPropartiesWindow.Visible = False
        Ctrl_Visible_TrueForm(Me.Controls)
    End Sub
    Private Sub SaveAllControlPositions(ByVal parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is Label OrElse TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is SimpleButton OrElse TypeOf ctrl Is FlexCell.Grid OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is TabControl OrElse TypeOf ctrl Is DevExpress.XtraTab.XtraTabControl Then
                SaveControlPosition(ctrl)
            End If
            If ctrl.HasChildren Then
                SaveAllControlPositions(ctrl)
            End If
        Next
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
            PanlPropartiesWindow.Visible = False
        End If
        If isMoveMode Then
            PanlPropartiesWindow.Visible = True
            If PropertyGrid1.SelectedObject Is Nothing AndAlso Me.ActiveControl IsNot Nothing Then
                PropertyGrid1.SelectedObject = Me.ActiveControl
            End If
        Else
            PanlPropartiesWindow.Visible = False
        End If
        Ctrl_Visible_TrueForm(Me.Controls)
        _GridEnable()
    End Sub


    Public Function _getformName() As String
        If _MainColumTbl IsNot Nothing AndAlso _MainColumTbl.Rows.Count > 0 Then
            Return _MainColumTbl.Rows(0)("FormName").ToString().Trim()
        End If
        Return ""
    End Function
    Public Function _getformId() As String
        If _MainColumTbl IsNot Nothing AndAlso _MainColumTbl.Rows.Count > 0 Then
            Return _MainColumTbl.Rows(0)("FormId").ToString().Trim()
        End If
        Return ""
    End Function
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            MasterMenuLoad.RestoreMenuFocus(Me.Tag, MasterMenuLoad.MenuStrip1)
        End If
    End Sub
End Class