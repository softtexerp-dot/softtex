Imports System.Text
Imports DevExpress.XtraGrid

Friend Class YarnPlaningEntry

#Region "GRID STRING BUILDER VARIABLE"
    Private Offer_Calc_By As String
    Private _GridColNames As New StringBuilder
    Private _GridColType As New StringBuilder
    Private _GridColValidate As New StringBuilder
    Private _GridCol_FocusByPass As New StringBuilder
    Private _FieldDefaultValues As New StringBuilder
    Private _FieldHeader As New StringBuilder
    Private _FieldHeaderAlignment As New StringBuilder
    Private _FieldNotRequiredForSave As New StringBuilder
    Private _FieldNotVisibile As New StringBuilder
    Private _FieldWidthSet As New StringBuilder
    Private _FieldLocked As New StringBuilder
    Private _FieldMasking As New StringBuilder
    Private _FieldAlignMent As New StringBuilder
    Private _ExtraFieldDataTable As New StringBuilder
    Private _ExtraField_Values_DataTable As New StringBuilder
    Private _ExtraFieldOthers As New StringBuilder
    Private _ExtraField_Values_Others As New StringBuilder
    Private _FieldNameSameValueCopy As New StringBuilder
    Private _FieldNameForTotal As New StringBuilder
#End Region

#Region "GRID GENERAL VARIABLE"
    Private Grid_Table_ColNames() As String
    Private _FindColIndex As Integer = 0
    Private _ColTotal As Double = 0
    Private _AutoIDField As String = "SRNO"
    Private _RecordsKeyFieldName As String = "ID"
    Private _FocusFields() As String
    Private _DataTableGrid As New DataTable
    Private _DefaultColOfGrid As Integer = 0
    Private _GridRowNo As Integer = 0
    Private _ReturnColNumber As Integer = -1
    Private _ActivatedColName As String = ""
    Private _RowNo As Integer = 0
    Private _ColNo As Integer = 0
    Private _GridLastColNo As Integer = 0
    Private _LastRow As Integer = 0
    Private _Last_Saved_Entry_No As Integer = 0
    Private _isCallerByOther As Boolean = False
    Private _old_Me_text As String = ""
    Private Last_Focused_Btn As String = ""
    Private _AllowMoveFromCell As Boolean = True
    Private WithEvents Txt_Dt As New ctl_TextBox.ctl_TextBox
    Private WithEvents txt_Name_For_Grid_Selection As New TextBox
    Private WithEvents txt_Code_For_Grid_Selection As New TextBox
    Private WithEvents txtAcOfCode As New TextBox
    Private WithEvents txtBookCode As New TextBox
    Private WithEvents txtSelvCode As New TextBox
    Private WithEvents txtLoomTypeCode As New TextBox
    Private WithEvents txtWeaveTypeCode As New TextBox

    Private Old_Date As String = ""
    Private Edit_From_View As Boolean = False
    Private Call_By_other As Boolean = False
    Private Book_Name As String = ""
    Private Book_Code As String = ""
    Private AcCode_Filter_String As String = ""
    Private Book_Row As DataRow
    Private Str_In_Group As String = ""

    Private Old_Col_No As Integer = 0
    Private Old_Col_No_Stk As Integer = 0
    Private FOUND As Boolean = False
    Private Return_Master_Name As String = ""
#End Region

#Region "GRID COL. DEFINE AND FORMATTING "
    Private Sub defineGridColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID,")
            .Append("SRNO,")
            .Append("ENTRYNO,")
            .Append("OFFERNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("OfferDate,")
            .Append("ACCOUNTCODE,")
            .Append("ACCOUNTNAME,")
            .Append("LOTNO,")
            .Append("Descr,")
            .Append("ITEMCODE,")
            .Append("ITEMNAME,")
            .Append("SHADECODE,")
            .Append("SHADENO,")
            .Append("MTR_WEIGHT,")

            .Append("RATE,")
            .Append("ROWREMARK")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("Mtr_Weight:N,")
            .Append("RATE:N")
        End With

        _GridColValidate = New StringBuilder
        With _GridColValidate
        End With

        _GridCol_FocusByPass = New StringBuilder
        With _GridCol_FocusByPass

        End With

        _FieldHeader = New StringBuilder
        With _FieldHeader
            .Append("SRNO:S.No,")
            .Append("ITEMNAME:Item Name,")
            .Append("MTR_WEIGHT:Quantity,")
            .Append("ACCOUNTNAME:Party Name,")
            .Append("LOTNO:Own/Job,")
            .Append("Rate:Rate,")
            .Append("DESCR:Stock Use,")
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("ITEMNAME:L,")
            .Append("LOTNO:L,")
            .Append("SHADENO:L,")
            .Append("ACCOUNTNAME:L,")
            .Append("DESCR:L,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("ROWREMARK:L")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("ITEMNAME:L,")
            .Append("LOTNO:L,")
            .Append("SHADENO:L,")
            .Append("ACCOUNTNAME:L,")
            .Append("DESCR:L,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("ROWREMARK:L")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("SRNO:Y,")
            .Append("ENTRYNO:N,")
            .Append("BookTrtype:N,")
            .Append("BOOKVNO:N,")
            .Append("BookCode:N,")
            .Append("OfferNo:N,")
            .Append("OfferDate:N,")
            .Append("AccountCode:N,")
            .Append("ITEMCODE:N,")
            .Append("ITEMNAME:Y,")
            .Append("ACCOUNTNAME:Y,")
            .Append("LOTNO:Y,")
            .Append("DESCR:Y,")
            .Append("SHADECODE:N,")
            .Append("SHADENO:N,")
            .Append("MTR_WEIGHT:Y,")
            .Append("RATE:N,")
            .Append("ROWREMARK:Y")
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("ACCOUNTNAME:N,")
            .Append("ITEMNAME:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:7,")
            .Append("ACCOUNTNAME:20,")
            .Append("ITEMNAME:20,")
            .Append("LOTNO:10,")
            .Append("MTR_WEIGHT:8,")
            .Append("DESCR:12,")
            .Append("ROWREMARK:1")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("MTR_WEIGHT:0,")
            .Append("RATE:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y,")
            .Append("LOTNO:Y,")
            .Append("DESCR:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("MTR_WEIGHT:NO-2,")
            .Append("RATE:NO-2")
        End With

        With _FieldNameSameValueCopy

        End With

        Grid_Table_ColNames = _GridColNames.ToString.ToUpper.Split(",")
    End Sub
    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _GridColNames.ToString.ToUpper, "NO", _GridColType.ToString)
        grdObj.ExtendLastCol = True
        _GridLastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
    End Sub
    Private Sub GridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _FieldNotVisibile.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _FieldWidthSet.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _FieldHeader.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _FieldLocked.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _FieldMasking.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _FieldAlignMent.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _FieldHeaderAlignment.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub
#End Region

#Region "GENERAL VARIABLE DECLARE "
    Private Last_Saved_Entry_No As Integer = 0
    Private DispMultiList As Boolean = False
    Private Return_Array_Values(0) As String
    Private Str_In_Party As String = ""
    Private Str_In_Mill As String = ""
    Private Str_In_Agent As String = ""
    Private Str_In_City As String = ""
    Private Str_In_SalesMan As String = ""

    Private _FrmLoad As Boolean = True
    Private WithEvents txtSalesman_code As New TextBox
    Private WithEvents txtAgent_code As New TextBox
    Private WithEvents txtAccount_Code As New TextBox
    Private WithEvents txtSupp_code As New TextBox
    Private WithEvents txtTr_code As New TextBox
    Private WithEvents txtDespatch_code As New TextBox
    Private DispList As Boolean = False
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldName As String = "BOOKVNO"
    Private _KeyFieldValue As String = ""
    Private _OfferTableName As String = "TRNOFFER"
    Private _ErrorMessage As String = ""
    Private _NewAddedRow As Boolean = False
    Private SRNO As Integer = 1
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _TmpDataTable As New DataTable
    Private _BookTrType As String = ""
    Private _PartyItemColoumn As String = ""
    Private _SizeManuelEntryColoumn As String = ""
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
#End Region

#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If txtOfferDate.Text = "  /  /    " Then
            MsgBox("Invalid Offer Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtOfferDate.Focus()
            Exit Function
        ElseIf Trim(txtEntryNo.Text) = "" Or Val(txtEntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function
#End Region

#Region "FORM EVENTS "
    Private Sub Yarn_Offer_Entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)

        If e.KeyCode = Keys.Delete And _FrmLoad = False Then
            Dim Txt_Box_Name As String = _STRTRNOBJECT.ToString.ToUpper
            If Txt_Box_Name = "TXTACCOUNTNAME" Or Txt_Box_Name = "TXTACOFNAME" _
                Or Txt_Box_Name = "TXTTRANSPORTNAME" Or Txt_Box_Name = "TXTDESPATCH" Then
                SendKeys.Send("{BKSP}")
            End If
        End If

        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True

            If _FORMMODE = "" Then
                CLOSE_MNU_LOAD()

            Else
                If PNL_View.Visible = True Then
                    PNL_View.Visible = False
                    Command_Button_Visibility("LOAD")
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                    Exit Sub
                End If

                Select Case _STRTRNOBJECT
                    Case "GRDITEM"
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txtEntryNo.Focus()
                    Case "TERM1"
                        txtEntryNo.Focus()
                    Case "TXTOFFERDATE"
                        _FrmLoad = True
                        txtOfferDate.Text = ObjCls_General.GetTodayDate_British
                        _FORMMODE = ""
                        Old_Date = txtOfferDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtOfferDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        _KeyFieldValue = 0
                        Command_Button_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                    Case Else
                        _FrmLoad = True
                        _FORMMODE = ""
                        Old_Date = txtOfferDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtOfferDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Call Command_Button_Visibility("LOAD")
                        Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                End Select
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If _STRTRNOBJECT = "GRDITEM" Then
                'Call Show_Calculator_With_Grid(GrdItem, Me)
            ElseIf _STRTRNOBJECT = "GRD_VIEW" Then
                'Call Show_Calculator_With_Grid(grd_View, Me)
            Else
                'Call Show_Calculator_Without_Grid(Me)
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
                        MsgBox("Blank Item Detail, Can't Save", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                        Exit Sub
                    Else
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        btnSave.Focus()
                    End If
                Case "GRID1"
                    GrdItem.Focus()
                Case "GRID2"
                    GrdItem.Focus()
                Case "BTNSAVE"
                    txtEntryNo.Focus()
                Case "TXTTERM1"
                    btnSave.Focus()
                    btnSave.Select()
                Case "TXTTERM2"
                    btnSave.Focus()
                    btnSave.Select()
                Case "TXTTERM3"
                    btnSave.Focus()
                    btnSave.Select()
                Case "TXTTERM4"
                    btnSave.Focus()
                    btnSave.Select()
                Case Else

                    If txtOfferDate.Text = "  /  /    " Then
                        txtOfferDate.Focus()
                    ElseIf Trim(Txt_PlanningNo.Text) = "" Then
                        Txt_PlanningNo.Focus()
                    Else
                        _FrmLoad = True
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        GrdItem.Focus()
                        GrdItem.Select()
                    End If
            End Select
        ElseIf e.KeyCode = Keys.F3 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    _FrmLoad = True
                    Delete_Row(GrdItem, _DataTableGrid)
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = ""
                    Call Total_Upto_All_Grid_All_Row()
                    Call Fill_Sr_No_Item(GrdItem, _DataTableGrid)
                    _FrmLoad = False
            End Select
        ElseIf e.KeyCode = Keys.PageUp Then
            If _FORMMODE = "EDIT" And Val(txtEntryNo.Text) > 1 And Last_Saved_Entry_No > 0 Then
                txtEntryNo.Text = Val(txtEntryNo.Text) - 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _OfferTableName)
            End If
        ElseIf e.KeyCode = Keys.PageDown Then
            If _FORMMODE = "EDIT" And Last_Saved_Entry_No > 0 And Val(txtEntryNo.Text) < Last_Saved_Entry_No Then
                txtEntryNo.Text = Val(txtEntryNo.Text) + 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _OfferTableName)
            End If
        End If
    End Sub


    Private Sub General_Order_Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.Location = New Point(0, 0)


        Dim x As Integer
        Dim y As Integer
        x = 0
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        Me.Location = New Point(x, y)



        Book_Code = "YRNPL-000000001"
        txtBookCode.Text = Book_Code
        _BookTrType = "YPN01"


        PNL_View.Width = Me.Width
        PNL_View.Height = Me.Height
        PNL_View.Location = New Point(0, 0)

        GridControl1.Width = PNL_View.Width - 25
        GridControl1.Height = PNL_View.Height - 100
        GridControl1.Location = New Point(3, 53)


        _FrmLoad = True

        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)

        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text

        Lbl_Tot_Mtr_Weight.Text = ""

        SetTotalObjectPosition("MTR_WEIGHT", _DataTableGrid, GrdItem, Lbl_Tot_Mtr_Weight, lbl_Total)

        If _isCallerByOther = True Then
            btnSave.Visible = True
            Call Alter_Form(_KeyFieldValue)
        Else
            Command_Button_Visibility("LOAD")
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            btnAdd.Focus()
            btnAdd.Select()
        End If

        _FrmLoad = False

    End Sub

#End Region

#Region "TOTAL ALL ROWS "
    Private Sub Total_Upto_All_Grid_All_Row()
        If _FrmLoad = True Then Exit Sub

        Dim Tot_Mtr_Weight As Double = 0
        For j As Int16 = 1 To GrdItem.Rows - 1
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
        Next
        Lbl_Tot_Mtr_Weight.Text = Tot_Mtr_Weight
        Lbl_Tot_Mtr_Weight.Text = IIf(Tot_Mtr_Weight > 0, Format(Val(Lbl_Tot_Mtr_Weight.Text), "0.000"), "")
    End Sub
#End Region

#Region "COMMAND BUTTON VISIBILITY CODE "
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
        GridView1.Columns.Clear()
        GridView4.Columns.Clear()

        If Visibility_Flag = "LOAD" Then
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "btnModify" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        End If
    End Sub
#End Region

#Region "SET FOCUS LAST CLICKED BTN "
    Private Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)
        _FORMMODE = ""
        If Last_Focused_Btn = "ADD" Then
            btnAdd.Focus()
        ElseIf Last_Focused_Btn = "EDIT" Then
            btnModify.Focus()
        ElseIf Last_Focused_Btn = "DELETE" Then
            btnDelete.Focus()
        ElseIf Last_Focused_Btn = "VIEW" Then
            btnView.Focus()
        ElseIf Last_Focused_Btn = "SAVE" Then
            btnAdd.Focus()
        End If
    End Sub
#End Region

#Region "Button Click Event "
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If _FORMMODE = "VIEW" Then
            PNL_View.Visible = False
            _FrmLoad = True
            _FORMMODE = ""
            Old_Date = txtOfferDate.Text
            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
            Clear_Grid(GrdItem, 2)
            Label_Value_Nil_Rest()
            _KeyFieldValue = 0
            Command_Button_Visibility("LOAD")
            Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Else
            CLOSE_MNU_LOAD()
        End If
    End Sub


    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub CLOSE_MNU_LOAD()
        Me.Close()
        Me.Dispose(True)
        LEDGER_ENTER_DISPLAY_FROM = ""
        _GenralOrderLoadBy = ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            If Edit_From_View = True Then
                _FORMMODE = "VIEW"
            End If
        End If
    End Sub
    Public Function EntryData_Invoice_Entry_txtBookName_Validated(ByVal _BookCode As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.ENTRYNO")
            .Append(" FROM " & _OfferTableName & " AS  A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Edit_From_View = False
        _FrmLoad = False

        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"

        Command_Button_Visibility("BTNADD")

        ObjCls_General.Blank_Object(Me)
        txtBookCode.Text = Book_Code

        Dim Last_Entry_No As Integer = 1
        sqL = EntryData_Invoice_Entry_txtBookName_Validated(Book_Code)
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO")) + 1
        End If
        txtEntryNo.Text = Last_Entry_No
        txtOfferDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "EDIT"
        Last_Focused_Btn = "EDIT"
        txtEntryNo.Visible = True
        Command_Button_Visibility("btnModify")

        ObjCls_General.Blank_Object(Me)

        txtBookCode.Text = Book_Code

        Dim Last_Entry_No As Integer = 1
        sqL = EntryData_Invoice_Entry_txtBookName_Validated(Book_Code)
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        End If
        txtEntryNo.Text = Last_Entry_No
        txtOfferDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "DELETE"
        Last_Focused_Btn = "DELETE"
        txtEntryNo.Visible = True
        Command_Button_Visibility("BTNDELETE")

        ObjCls_General.Blank_Object(Me)

        txtBookCode.Text = Book_Code


        Dim Last_Entry_No As Integer = 1
        sqL = EntryData_Invoice_Entry_txtBookName_Validated(Book_Code)
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        End If
        txtEntryNo.Text = Last_Entry_No
        txtOfferDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        _FrmLoad = False

        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        Command_Button_Visibility("BTNVIEW")

        txtBookCode.Text = Book_Code

        View_Record()
    End Sub

#End Region

#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE "
    Private Sub btnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.GotFocus
        btnAdd.BackColor = Color.Coral
    End Sub
    Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.LostFocus
        btnAdd.BackColor = Me.BackColor
    End Sub

    Private Sub btnModify_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.GotFocus
        btnModify.BackColor = Color.Coral
    End Sub
    Private Sub btnModify_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.LostFocus
        btnModify.BackColor = Me.BackColor
    End Sub

    Private Sub btnDelete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.GotFocus
        btnDelete.BackColor = Color.Coral
    End Sub
    Private Sub btnDelete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.LostFocus
        btnDelete.BackColor = Me.BackColor
    End Sub
    Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.GotFocus
        btnView.BackColor = Color.Coral
    End Sub
    Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.LostFocus
        btnView.BackColor = Me.BackColor
    End Sub
    Private Sub btnSave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.GotFocus
        btnSave.BackColor = Color.Coral
    End Sub
    Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.LostFocus
        btnSave.BackColor = Me.BackColor
    End Sub
    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.GotFocus
        btnClose.BackColor = Color.Coral
    End Sub
    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.LostFocus
        btnClose.BackColor = Me.BackColor
    End Sub
#End Region

#Region "Label Value Setting "
    Private Sub Label_Decimal_Setting()

        If Val(Lbl_Tot_Mtr_Weight.Text) > 0 Then
            Lbl_Tot_Mtr_Weight.Text = FormatNumber(Val(Lbl_Tot_Mtr_Weight.Text), 3, TriState.False, TriState.False, TriState.True)
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If
    End Sub

    Private Sub Label_Value_Nil_Rest()
        Lbl_Tot_Mtr_Weight.Text = ""
    End Sub
#End Region

#Region "DELETE CODE"
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        _FrmLoad = True
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).ClearText()
        GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = GrdObj.ActiveCell.Row
        _FrmLoad = False
    End Sub

    Private Sub Delete_Entry_SQL()
        _FrmLoad = True
        Dim affected As Integer = 0
        Dim I As Integer = 0
        Dim _LastID As Integer = 0

        Try
            strQuery = " DELETE FROM trnOffer WHERE BOOKVNO='" & _BookVNo & "'"
            sqL = strQuery.ToString
            sql_Data_Save_Delete_Update()

            '-----------------------------------------------------------------------

            _KeyFieldValue = 0
            _FORMMODE = "ADD"

            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Old_Date = txtOfferDate.Text
            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
        Catch ex As Exception
            MsgBox("Error While Delete Entry")
        Finally
        End Try
        _FrmLoad = False
    End Sub
#End Region

#Region "FILL SR NO"
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            If Val(GrdObj.Cell(i, Data_Table.Columns.IndexOf("AMOUNT") + 1).Text) > 0 Then
                GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
            End If
        Next
    End Sub
#End Region

#Region "TXT BOX ENTRY NO EVENT CODE "
    Private Sub txtEntryNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntryNo.Validated
        If _FrmLoad = True Then Exit Sub

        If Val(txtEntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            txtEntryNo.Select()
            Exit Sub
        Else
            Dim BookVno As String = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)
            _BookVNo = BookVno
            Validate_Entry_No(BookVno, _OfferTableName)
        End If
    End Sub
    Private Sub Validate_Entry_No(ByVal Book_Vno As String, ByVal Table_Name As String)
        _TransctionNo = 0
        strQuery = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " WHERE BOOKVNO='" & Book_Vno & "'"
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = DefaltSoftTable.Rows(0).Item(0)
        End If



        If _TransctionNo > 0 Then
            If _FORMMODE = "ADD" Then
                MsgBox("Entry No. Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
            ElseIf _FORMMODE = "EDIT" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)
                btnSave.Enabled = True
                txtOfferDate.Focus()
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice", MsgBoxStyle.Information, "Soft-Tex PRO")
                    Change_Grid_Data = False
                    txtOfferDate.Enabled = False
                    GrdItem.Column(_DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Locked = True
                    GrdItem.Column(_DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Locked = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtOfferDate.Focus()
                    txtOfferDate.Select()
                Else
                    Change_Grid_Data = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtOfferDate.Focus()
                    txtOfferDate.Select()
                End If
            ElseIf _FORMMODE = "DELETE" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice, Can't Delete", MsgBoxStyle.Information, "Soft-Tex PRO")
                Else
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Call Delete_Entry_SQL()
                    End If
                End If
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                Command_Button_Visibility("LOAD")
                If _Last_Saved_Entry_No > 0 Then
                    Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Else
                    btnAdd.Focus()
                End If
                _FrmLoad = False
            End If
        Else
            If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                MsgBox("Entry No " + Trim(txtEntryNo.Text) + " Not Found")
                txtEntryNo.Visible = True
                txtEntryNo.Focus()
                txtEntryNo.Select()
            End If
        End If
    End Sub
#End Region

#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        Return obj_Party_Selection.EntryData_General_Offer_getAlter_Form_Query_Details(strKeyID)
    End Function
#End Region

#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)
        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy

        'ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)

        txtTr_code.Text = tblTmp.Rows(0)("TRANSPORTCODE").ToString
        txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        txtDespatch_code.Text = tblTmp.Rows(0)("DESPATCHCODE").ToString
        txtOfferDate.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        txtAcOfCode.Text = tblTmp.Rows(0)("ACOFCODE").ToString
        txtEntryNo.Text = tblTmp.Rows(0)("ENTRYNO").ToString
        txtOfferDate.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        Txt_PlanningNo.Text = tblTmp.Rows(0)("OFFERNO").ToString

        Generate_Date_For_DataBase(txtOfferDate)

        Lbl_Tot_Mtr_Weight.Text = tblTmp.Compute("SUM(MTR_WEIGHT)", "").ToString

        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)
        GrdItem.Refresh()
        GrdItem.Visible = True

        If Val(Lbl_Tot_Mtr_Weight.Text) > 0 Then
            Lbl_Tot_Mtr_Weight.Text = Format(Val(Lbl_Tot_Mtr_Weight.Text), "0.000")
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If
        If Txt_PlanningNo.Text > "" Then
            _GetYarnPlanQty()

        End If


        Dim _filter = GetActiveItemCode()
        Dim Tbl = _GetFactoryYarnPlanStock(_filter)
        _GridSetting(Tbl)

        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        _FrmLoad = False
    End Sub


#End Region

#Region "Check Adjustment Agnst Offer "
    Private Function Is_Adjusted_Offer() As Boolean
        Dim Total_Record As Integer = 0
        Dim Return_Value As Boolean = False
        Dim Tmp_Data_Table As New DataTable
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.OFFERBOOKVNO ")
            .Append(" FROM TRNINVOICEDETAIL A ")
            .Append(" WHERE A.ACCOUNTCODE='" & txtAccount_Code.Text & "' ")
            .Append(" AND A.OFFERBOOKVNO='" & _BookVNo & "' ")
        End With
        strQuery = _strQuery.ToString
        sqL = strQuery.ToString
        sql_connect_slect()
        Tmp_Data_Table = DefaltSoftTable.Copy

        Total_Record = Tmp_Data_Table.Rows.Count
        If Total_Record > 0 Then
            Return_Value = True
        Else
            Return_Value = False
        End If
        Return Return_Value
    End Function
#End Region


#Region "GRID ITEM EVENTS"
    Private Sub grditem_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub grdItem_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        GrdItem.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub grdItem_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
        GrdItem.ActiveCell.BackColor = GrdItem.BackColor1
    End Sub
    Private Sub grdItem_EnterRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.EnterRowEventArgs) Handles GrdItem.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
        GrdItem.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub grdItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        GrdItem.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub grdItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.LostFocus
        If _FrmLoad = True Then Exit Sub
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub grdItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Validated
        If _FrmLoad = True Then Exit Sub
        GrdItem.Refresh()
    End Sub
    Private Sub grdItem_LeaveRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveRowEventArgs) Handles GrdItem.LeaveRow

        If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row

        Dim CUTCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text
        Dim ITEMCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
        Dim ITEMGROUPCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text
        Dim QTY As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)

        If CUTCODE = "" Or ITEMCODE = "" Or QTY = 0 Or ITEMGROUPCODE = "" Then
            If _ActivatedColName = "ROWREMARK" Then
                e.Cancel = True
                If ITEMCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf ITEMGROUPCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf CUTCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf QTY = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).SetFocus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = "0000-000001008"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000003"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "OPENING STOCK"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "OWN"

        If _ActivatedColName = "ITEMNAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
                obj_Party_Selection.SINGLE_YarnItem_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                End If
                Dim _filter = GetActiveItemCode()
                Dim Tbl = _GetFactoryYarnPlanStock(_filter)
                _GridSetting(Tbl)
            End If
        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "MTR_WEIGHT" Then
            If e.KeyCode = Keys.Enter Then
                Call Total_Upto_All_Grid_All_Row()
            End If
        ElseIf _ActivatedColName = "ACCOUNTNAME" Then
            If e.KeyCode = Keys.Enter Then
                Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTCODE") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = selected("ACCOUNTCODE").ToString()
                    If selected.ContainsKey("AccountName") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = selected("AccountName").ToString()
                End If
            End If

        ElseIf _ActivatedColName = "LOTNO" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "OWN"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "OWN" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "JOB RCPT"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "JOB RCPT" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "JOB SEND"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "JOB SEND" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "GREY"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "GREY" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "OWN"
                End If
            End If
        ElseIf _ActivatedColName = "DESCR" Then
            'If e.KeyCode = Keys.Space Then
            'If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "" Then
            '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE"
            'ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE" Then
            '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "FACTORY STOCK"
            'ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "FACTORY STOCK" Then
            '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "OPENING STOCK"
            'ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "OPENING STOCK" Then
            '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE"
            'End If
            'End If
        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdItem.ActiveCell.Row
                Dim QTY As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
                Dim ITEMCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
                If QTY <> 0 And ITEMCODE <> "" Then
                    If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                        GrdItem.Rows = GrdItem.Rows + 1
                        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "GRID GENERAL FUNCTION "
    Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If

        If grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If
    End Sub
#End Region

#Region "Save Code "
    Private Sub SaveRecord()
        If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
            MsgBox("Invalid Item Detail", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            GrdItem.Focus()
            GrdItem.Select()
            Exit Sub
        End If

        If txtAcOfCode.Text = "" Then
            txtAcOfCode.Text = "0000-000000001"
        End If


        If _FORMMODE = "ADD" Then
            Dim Str_Qry As String = obj_Party_Selection.EntryData_General_Offer_txtBookName_Validated(Book_Code)
            Dim TblTmp As New DataTable
            sqL = Str_Qry
            sql_connect_slect()
            TblTmp = DefaltSoftTable.Copy
            Dim Last_Entry_No As Integer = 0
            If TblTmp.Rows.Count > 0 Then
                Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
            End If
            If Last_Entry_No = txtEntryNo.Text Then
                txtEntryNo.Text = Last_Entry_No + 1
            End If
        End If

        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)

        Generate_Date_For_DataBase(txtOfferDate)

        Total_Upto_All_Grid_All_Row()

        Call Fill_Grid_Records_Into_DataTables()
        Dim _LastID As Integer = -1
        Try

            _LastID = SAVE_INTO_DATABASE_SQL()

            Old_Date = txtOfferDate.Text
            Call Label_Value_Nil_Rest()
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)

            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            Call Command_Button_Visibility("LOAD")
            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        _DataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdItem.Rows - 1
            If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text <> "" And Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) > 0 And GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text <> "" And GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text <> "" Then

                If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000001"
                End If

                FieldDr = _DataTableGrid.NewRow
                For j As Int16 = 1 To GrdItem.Cols - 1
                    If FieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FieldDr(j - 1) = Val(GrdItem.Cell(i, j).Text)
                    Else
                        FieldDr(j - 1) = (GrdItem.Cell(i, j).Text)
                    End If
                Next
                _DataTableGrid.Rows.Add(FieldDr)
            End If

        Next
        '----------------------------------------
    End Sub
    Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        '------------------------ DETAILS Table --------------------------------

        If txtSalesman_code.Text = "" Then
            txtSalesman_code.Text = "0000-000000001"
        End If

        If txtSelvCode.Text = "" Then
            txtSelvCode.Text = "0000-000000001"
        End If

        If txtLoomTypeCode.Text = "" Then
            txtLoomTypeCode.Text = "0000-000000001"
        End If

        If txtWeaveTypeCode.Text = "" Then
            txtWeaveTypeCode.Text = "0000-000000001"
        End If

        Dim strFilterString As String
        Dim QueryDetailTable As String = ""

        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String

        strFilterString = "MTR_WEIGHT>0 "

        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("ENTRYNO,")
            .Append("OFFERNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("OfferDate")

        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtEntryNo.Text & ",")
            .Append(Txt_PlanningNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(Book_Code & ",")
            .Append(txtOfferDate.Date_for_Database)
        End With

        QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid
    End Function

    Private Function SAVE_INTO_DATABASE_SQL() As Integer
        Dim strQuery As String = ""
        Dim I As Integer = 0

        Try
            '---------------- Delete Previous Bill Sundry ----------------------------------'
            strQuery = "DELETE FROM TRNOFFER WHERE 1=1 And BOOKVNO ='" & _BookVNo & "'"
            sqL = strQuery
            sql_Data_Save_Delete_Update()
            Dim Array_Opening(0, 4) As String
            '------ INSERT RECORDS SALES INVOICE -------------------------------
            GridDetailsSaveQuery(Array_Opening)
            For I = 0 To UBound(Array_Opening)
                If Array_Opening(I, 4) <> "" Then
                    strQuery = Array_Opening(I, 4)
                    sqL = strQuery
                    sql_Data_Save_Delete_Update()
                End If
            Next
        Catch ex As Exception

            MsgBox("new error comes :" & ex.Message & "-" & strQuery)
            Throw ex
        Finally
        End Try
    End Function

#End Region


#Region "VIEW RECORD "


    Private Sub View_Record()


        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""

        'View_Filter_Condition = " AND TRNOFFER.BOOKCODE='" & Book_Code & "' AND TRNOFFER.OFFERDATE>='" & txt_From.Date_for_Database & "' AND TRNOFFER.OFFERDATE<='" & txt_To.Date_for_Database & "' "
        View_Filter_Condition = " AND A.BOOKCODE='" & Book_Code & "' "
        View_Order_By = " ORDER BY A.OFFERDATE,A.ENTRYNO,A.SRNO "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.BookVno, ")
            .Append(" A.ENTRYNO as [Entry No], ")
            .Append(" A.OfferNo as PlanningNo, ")
            .Append(" A.OfferDate AS Date, ")
            .Append(" A.SRNO as [Sno], ")
            .Append(" B.CountName, ")
            .Append(" A.Mtr_Weight as Quantity ")
            .Append(" FROM TRNOFFER AS A")
            .Append(" LEFT JOIN MstYarnCount  AS B ON  A.ITEMCODE=B.CountCode ")
            .Append(" WHERE 1=1 ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp = DefaltSoftTable.Copy

        FirstStage.Columns.Clear()

        If tblTmp.Rows.Count > 0 Then

            For Each dr As DataRow In tblTmp.Select
                Dim Qty As String = Format(dr("Quantity"), "0.00")
                dr("Quantity") = Qty
            Next

            GridControl1.DataSource = tblTmp.Copy

            FirstStage.GroupRowHeight = 30
            FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

            FirstStage.Columns("Quantity").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            FirstStage.Columns("Quantity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0}"))

            AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
            FirstStage.Columns("BookVno").Visible = False

            DevGridFitColumn(GridControl1, FirstStage)

            PNL_View.BringToFront()
            PNL_View.Visible = True
            FirstStage.Focus()
            PNL_View.BringToFront()
            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If

    End Sub
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        'gridView.Columns(CStr(("Bale No"))).Group()

        'Enable this option to move group footer summaries to group rows under corresponding column headers
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Quantity", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Quantity")})

        gridView.Appearance.GroupRow.BackColor = Color.LightGreen

    End Sub
#End Region

#Region "DATE RANGE CHECK"
    Private Sub txtOfferDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfferDate.Validated
        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information, "Soft-Tex PRO")
                txtOfferDate.Focus()
                txtOfferDate.Select()
            End If
        End If
    End Sub
#End Region



    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = " Yarn Plan Report :"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub
#End Region

    Private Sub Txt_PlanningNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PlanningNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Party_selection.txtSearch.Text = Txt_PlanningNo.Text
            'Job_Order._GetPlanningQuery("")
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    Txt_PlanningNo.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    _GetYarnPlanQty()
            'End If
            'Dim _filter = GetActiveItemCode()
            'Dim Tbl = _GetFactoryYarnPlanStock(_filter)
            '_GridSetting(Tbl)
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            Txt_PlanningNo.Text = ""
        End If


    End Sub

    Private Sub _GetYarnPlanQty()

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" B.Yarn_For AS YarnFor  ")
            .Append(" ,D.CountName  ")
            .Append(" ,B.Pattern  ")
            .Append(" ,B.Avg_weight as AvgWt  ")

            .Append(" ,B.Yarn_Rate as Rate  ")
            .Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3))* ISNULL(B.Avg_weight,0) as YarnPlanQty")
            '.Append(" ,ISNULL(SUM(E.Mtr_Weight),0) as YarnOrderQty")
            '.Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3))* ISNULL(B.Avg_weight,0)-ISNULL(SUM(E.Mtr_Weight),0) as YarnBalQty")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN MstYarnCount AS D ON B.CountCode=D.CountCode ")
            '.Append(" LEFT JOIN TrnOffer AS E ON (A.ID=ISNULL(NULLIF(E.OP16, ''), 0) AND B.CountCode=E.ITEMCODE)  ")

            .Append(" WHERE 1=1")
            .Append(" AND A.ID='" & Txt_PlanningNo.Text & "' ")
            .Append(" AND A.MRP='NO'  ")
            .Append(" GROUP BY  ")
            .Append(" B.Yarn_For  ")
            .Append(" ,D.CountName  ")
            .Append(" ,B.Pattern  ")
            .Append(" ,B.Avg_weight  ")
            .Append(" ,B.Yarn_Rate  ")
            .Append(" ,a.ALTUNIT ")


        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else
            For Each dr As DataRow In _ThidTable.Select
                dr("YarnPlanQty") = Convert.ToDouble(dr("YarnPlanQty")).ToString("0.00")
                If Val(dr("YarnPlanQty")) = 0 Then dr("YarnPlanQty") = DBNull.Value
            Next
            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy

            GridView1.OptionsView.ShowIndicator = False
            GridView1.OptionsFind.AlwaysVisible = False
            GridView1.OptionsView.ShowGroupPanel = False


            GridView1.Columns("YarnPlanQty").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            DevGridFitColumn(GridControl2, GridView1)
            GridView1.Columns("YarnPlanQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "YarnPlanQty", "{0}"))
            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()

        End If

    End Sub
    Private Function GetActiveItemCode()
        Dim itemCodes As New List(Of String)
        For i As Int16 = 1 To GrdItem.Rows - 1
            Dim code As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
            If Not String.IsNullOrWhiteSpace(code) Then
                itemCodes.Add("'" & code.Replace("'", "''") & "'")  ' SQL-safe quoting
            End If
        Next

        Dim whereIn As String = ""
        If itemCodes.Count > 0 Then
            whereIn = "AND Z.ITEMCODE IN (" & String.Join(",", itemCodes) & ")"
        End If
        Return whereIn
    End Function

    Public Function _GetFactoryYarnPlanStock(ByVal whereIn As String)
        Dim _ThidTable As New DataTable
        If whereIn > "" Then
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.CountName  ")
                .Append(" ,Z. Accountcode ")
                .Append(" ,SUM(Z.YarnPlanQty)-SUM(Z.YarnUseQty)+sum(z.OrderBalance) AS YarnInStk ")
                .Append(" FROM ( ")
                .Append(" SELECT  ")
                .Append(" A. ItemCode ")
                .Append(" ,A. Accountcode ")
                .Append(" ,ISNULL((A.Mtr_Weight),0) as YarnPlanQty ")
                .Append(" ,0.00 as YarnUseQty ")
                .Append(" ,0.00 as OrderBalance ")
                .Append(" FROM  ")
                .Append(" TrnOffer AS A   ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BookCode ='YRNPL-000000001'  ")
                .Append(" AND A.DESCR='OPENING STOCK' ")
                .Append(" AND ISNULL((A.Mtr_Weight),0)>0  ")
                .Append(" UNION ALL ")
                .Append(" SELECT  ")
                .Append(" A. ItemCode ")
                .Append(" ,A. Accountcode ")
                .Append(" ,0.00 AS YarnPlanQty ")
                .Append(" ,ISNULL((A.Mtr_Weight),0) as YarnUseQty ")
                .Append(" ,0.00 as OrderBalance ")
                .Append(" FROM  ")
                .Append(" TrnOffer AS A   ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BookCode ='YRNPL-000000001'  ")
                .Append(" AND A.DESCR='FACTORY STOCK' ")
                .Append(" AND ISNULL((A.Mtr_Weight),0)>0  ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" X.ItemCode ")
                .Append(" ,X.Accountcode ")
                .Append(" ,0.00 as YarnPlanQty ")
                .Append(" ,0.00 as YarnUseQty ")
                .Append(" ,SUM(X.YarnPurQty)-SUM(X.YarnOrderQty) AS OrderBalance ")
                .Append(" FROM ( ")
                .Append(" SELECT  ")
                .Append(" A.ItemCode ")
                .Append(" ,A.Accountcode ")
                .Append(" ,ISNULL((A.Mtr_Weight),0) as YarnOrderQty ")
                .Append(" ,0.00 as YarnPurQty ")
                .Append(" FROM  ")
                .Append(" TrnOffer AS A   ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BookCode ='YRNPL-000000001'  ")
                .Append(" AND A.DESCR='PURCHASE' ")
                .Append(" AND ISNULL((A.Mtr_Weight),0)>0  ")
                .Append(" UNION ALL ")
                .Append(" SELECT  ")
                .Append("  A.COUNTCODE AS ItemCode ")
                .Append(" ,A.Accountcode ")
                .Append(" ,0.00 as YarnOrderQty ")
                .Append(" ,ISNULL((A.ACTUAL_WEIGHT),0) as YarnPurQty ")
                .Append(" FROM  ")
                .Append(" TrnFactoryYarn AS A   ")
                .Append(" ,TrnOffer as B ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.offerbookvno =B.BookVno  ")
                .Append(" AND A.COUNTCODE=B.ItemCode ")
                .Append(" AND ISNULL((A.ACTUAL_WEIGHT),0)>0  ")
                .Append(" ) AS X ")
                .Append(" GROUP BY  ")
                .Append(" X.ItemCode ")
                .Append(" ,X.Accountcode ")
                .Append(" HAVING  SUM(X.YarnPurQty)-SUM(X.YarnOrderQty)>0 ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstYarnCount AS A ON Z.ItemCode=A.CountCode ")
                .Append(" where 1=1 ")
                .Append(whereIn)
                .Append(" GROUP BY  ")
                .Append(" Z.ItemCode ")
                .Append(" ,Z.Accountcode ")
                .Append(" ,A.CountName  ")
                .Append(" HAVING  SUM(Z.YarnPlanQty)-SUM(Z.YarnUseQty)>0 ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            _ThidTable = DefaltSoftTable.Copy
        End If
        Return _ThidTable
    End Function

    Private Sub _GridSetting(ByVal _ThidTable As DataTable)
        If _ThidTable.Rows.Count = 0 Then
            'MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
        Else
            For Each dr As DataRow In _ThidTable.Select
                dr("YarnInStk") = Convert.ToDouble(dr("YarnInStk")).ToString("0.00")

                If Val(dr("YarnInStk")) = 0 Then dr("YarnInStk") = DBNull.Value
            Next
            GridView4.Columns.Clear()
            GridControl3.DataSource = _ThidTable.Copy
            GridView4.Columns("YarnInStk").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            GridView4.OptionsView.ShowIndicator = False
            GridView4.OptionsFind.AlwaysVisible = False
            GridView4.OptionsView.ShowGroupPanel = False

            GridView4.Columns("Accountcode").Visible = False

            DevGridFitColumn(GridControl2, GridView4)
            GridView4.Columns("YarnInStk").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "YarnInStk", "{0}"))
            GridView4.Appearance.FocusedRow.BackColor = GridView4.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
        End If
    End Sub
End Class