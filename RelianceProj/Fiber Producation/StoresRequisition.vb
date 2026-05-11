Imports System.Text
Imports DevExpress.XtraGrid

Friend Class StoresRequisition


    Private obj_Party_Selection As New Multi_Selection_Master
    Private ObjCls_General As New cls_FrmHandle.cls_frmHandle
    Private UnitName As String = ""
    Private UnitCode As String = ""
    Private WithEvents txtUnitCode As New TextBox
    Dim _UNiteWiseCode As String = ""


#Region "GRID STRING BUILDER VARIABLE "
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

#Region "GRID GENERAL VARIABLE "
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
    Private WithEvents txtstaticBookCode As New TextBox
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
    Private UseItemHead As String = "NO"
#End Region

#Region "GRID COL. DEFINE AND FORMATTING "
    Private Sub defineGridColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID,")
            .Append("ENTRYNO,")
            .Append("BOOKTRTYPE,")
            .Append("BOOKVNO,")
            .Append("BOOKCODE,")
            .Append("PACK_SLIP_NO,")
            .Append("PACK_SLIP_DATE,")
            .Append("OFFERBOOKVNO,")
            .Append("ACCOUNTCODE,")
            .Append("TRANSPORTCODE,")
            .Append("Y_LOTNO,")
            .Append("HEADERREMARK,")
            .Append("SRNO,")
            .Append("OFFERNO,")
            .Append("GROUPNAME,")
            .Append("ITEMNAME,")
            .Append("ITEMCODE,")

            .Append("COMPANYNAME,")
            .Append("CUTCODE,")
            .Append("CUTNAME,")
            .Append("DEPARTMENT,")
            .Append("COLORNAME,")
            .Append("DESCR,")
            .Append("DESIGNCODE,") 'department code
            .Append("CUTCODE1,")
            .Append("MTR_WEIGHT,")
            .Append("CUT_MTR,") ' GROSS RATE
            .Append("RDVALUE,") 'dis%
            .Append("WEIGHT,") 'dis amount
            .Append("RATE,")
            .Append("AMOUNT,")
            .Append("ROWREMARK,")
            .Append("PIECE_ID,")
            .Append("SHADECODE,") 'companycode
            .Append("Y_DELV_ACCOUNTCODE,")
            .Append("ACOFCODE,")
            .Append("GODOWNCODE,") 'GodOwnCode
            .Append("OP20,") 'BookName
            .Append("DESPATCHCODE")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("ENTRYNO:N,")
            .Append("CUT_MTR:N,")
            .Append("MTR_WEIGHT:N,")
            .Append("WEIGHT:N,")
            .Append("RATE:N,")
            .Append("RDVALUE:N,")
            .Append("PIECE_ID:N,")
            .Append("AMOUNT:N")
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
            .Append("OFFERNO:Off.No,")
            .Append("GROUPNAME:Group,")
            .Append("ITEMNAME:Item Name,")
            .Append("COMPANYNAME:Brand,")
            .Append("CUTNAME:UOM,")
            .Append("DEPARTMENT:DepartMent,")
            .Append("COLORNAME:Color,")
            .Append("DESCR:Descr,")
            .Append("MTR_WEIGHT:Qty,")
            .Append("CUT_MTR:Gross Rate,")
            .Append("RATE:Net Rate,")
            .Append("RDVALUE:Dis%,")
            .Append("WEIGHT:Dis Amt,")
            .Append("AMOUNT:Amount,")
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("OFFERNO:L,")
            .Append("ITEMNAME:L,")
            .Append("DEPARTMENT:L,")
            .Append("COLORNAME:L,")
            .Append("GROUPNAME:L,")
            .Append("CUTNAME:L,")
            .Append("RDVALUE:R,")
            .Append("CUT_MTR:R,")
            .Append("WEIGHT:R,")
            .Append("DESCR:L,")
            .Append("COMPANYNAME:L,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("AMOUNT:R,")
            .Append("ROWREMARK:L")
        End With


        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("OFFERNO:L,")
            .Append("ITEMNAME:L,")
            .Append("DEPARTMENT:L,")
            .Append("CUTNAME:L,")
            .Append("GROUPNAME:L,")
            .Append("COMPANYNAME:L,")
            .Append("COLORNAME:L,")
            .Append("RDVALUE:R,")
            .Append("WEIGHT:R,")
            .Append("CUT_MTR:R,")
            .Append("DESCR:L,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("AMOUNT:R,")
            .Append("ROWREMARK:L")
        End With


        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("ENTRYNO:N,")
            .Append("BOOKTRTYPE:N,")
            .Append("BOOKVNO:N,")
            .Append("BOOKCODE:N,")
            .Append("PACK_SLIP_NO:N,")
            .Append("PACK_SLIP_DATE:N,")
            .Append("OFFERNO:N,")
            .Append("GROUPNAME:N,")
            .Append("OFFERBOOKVNO:N,")
            .Append("ACCOUNTCODE:N,")
            .Append("TRANSPORTCODE:N,")
            .Append("Y_LOTNO:N,")
            .Append("HEADERREMARK:N,")
            .Append("DESPATCHCODE:N,")
            .Append("ACOFCODE:N,")
            .Append("SHADECODE:N,")
            .Append("CUT_MTR:N,")
            .Append("SRNO:Y,")
            .Append("ITEMNAME:Y,")
            .Append("ITEMCODE:N,")
            .Append("CUTNAME:Y,")
            .Append("DESCR:N,")
            .Append("RDVALUE:N,")
            .Append("WEIGHT:N,")
            .Append("DEPARTMENT:Y,")
            .Append("COLORNAME:N,")
            .Append("COMPANYNAME:Y,")
            .Append("DESIGNCODE:N,")
            .Append("CUTCODE1:N,")
            .Append("CUTCODE:N,")
            .Append("PIECE_ID:N,")
            .Append("MTR_WEIGHT:Y,")
            .Append("RATE:N,")
            .Append("AMOUNT:N,")
            .Append("ROWREMARK:Y,")
            .Append("GODOWNCODE:N,") 'GodownCode
            .Append("OP20:N,") 'BookName
            .Append("Y_DELV_ACCOUNTCODE:N") 'ITEMGROUPCODE
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("ITEMNAME:N,")
            .Append("DEPARTMENT:N,")
            .Append("GROUPNAME:N,")
            .Append("COMPANYNAME:N,")
            .Append("CUTNAME:N,")
            .Append("COLORNAME:N")
        End With


        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:4,")
            .Append("OFFERNO:6,")
            .Append("GROUPNAME:9,")
            .Append("ITEMNAME:15,")
            .Append("DEPARTMENT:10,")
            .Append("RDVALUE:5,")
            .Append("COLORNAME:6,")
            .Append("CUTNAME:6,")
            .Append("DESCR:15,")
            .Append("MTR_WEIGHT:8,")
            .Append("CUT_MTR:10,")
            .Append("RATE:10,")
            .Append("WEIGHT:10,")
            .Append("COMPANYNAME:9,")
            .Append("AMOUNT:8,")
            .Append("ROWREMARK:40")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("SRNO:0,")
            .Append("MTR_WEIGHT:0,")
            .Append("RATE:0,")
            .Append("RDVALUE:0,")
            .Append("CUT_MTR:0,")
            .Append("WEIGHT:0,")
            .Append("PIECE_ID:0,")
            .Append("AMOUNT:0")
        End With
        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y,")
            .Append("AMOUNT:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("MTR_WEIGHT:NO-2,")
            .Append("RATE:NO-2,")
            .Append("RDVALUE:NO-2,")
            .Append("WEIGHT:NO-2,")
            .Append("CUT_MTR:NO-2,")
            .Append("AMOUNT:NO-2")
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
    Private WithEvents txtgodowncode As New TextBox
    Private DispList As Boolean = False
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldName As String = "BOOKVNO"
    Private _KeyFieldValue As String = ""
    Private _ChallanTableName As String = "TrnPackingSlip"
    Private _ErrorMessage As String = ""
    Private _NewAddedRow As Boolean = False
    Private SRNO As Integer = 1
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _TmpDataTable As New DataTable
    Private _BookTrType As String = ""
    Private _BookCode As String = ""
    Private _StaticBookCode As String = ""
    Private _StaticBookName As String = ""
    Private _GodownCode As String = ""
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
#End Region

#Region "FORM VALIDATION "
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False

        If _BookCode.Trim = "" Then
            MsgBox("Invalid Book Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtGodownName.Focus()
            Exit Function
        ElseIf _StaticBookCode.Trim = "" Then
            MsgBox("Invalid Book Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Txt_BookName.Focus()
            Exit Function
        ElseIf txtChallanDate.Text = "  /  /    " Then
            MsgBox("Invalid Challan Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtChallanDate.Focus()
            Exit Function

        ElseIf Trim(txtChallanNo.Text) = "" Then
            MsgBox("Invalid Challan No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtChallanNo.Focus()
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





#Region "Form Load"
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub SamplerRateContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        PNL_View.Width = Me.Width
        PNL_View.Height = Me.Height
        PNL_View.Location = New Point(0, 0)
        GridControl1.Width = PNL_View.Width - 25
        GridControl1.Height = PNL_View.Height - 100
        GridControl1.Location = New Point(3, 53)
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)

        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text
        If _isCallerByOther = True Then
            UC_Buttons1._ButtonEnableDisable("EDIT")
            'Call Alter_Form(_KeyFieldValue)
        Else
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
        End If

    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports")
    End Sub

    Private Sub Fabric_Rate_Contract_Entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)


        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True
            If _FORMMODE = "" Then
                Me.Close()
            Else
                If PNL_View.Visible = True Then
                    PNL_View.Visible = False
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Exit Sub
                End If

                Select Case _STRTRNOBJECT
                    Case "GRDITEM"
                        _FrmLoad = True
                        'Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txtEntryNo.Focus()

                    Case Else
                        _FrmLoad = True
                        ObjCls_General.Blank_Object(Me)
                        Clear_Grid(GrdItem, 2)
                        'Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                        _FORMMODE = ""
                End Select
            End If

        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    Dim Total_Valid_Rows As Integer = 0
                    For I As Int16 = 1 To GrdItem.Rows - 1
                        If Val(GrdItem.Cell(I, _DataTableGrid.Columns.IndexOf("PROCESS_NET_RATE") + 1).Text) <> 0 Then
                            Total_Valid_Rows = Total_Valid_Rows + 1
                        End If
                    Next
                    If Total_Valid_Rows = 0 Then
                        MsgBox("Blank Item Detail, Can't Save", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                        Exit Sub
                    Else
                        _FrmLoad = True

                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        UC_Buttons1.BtnSave.Focus()
                    End If
                Case "BTNSAVE"
                    txtEntryNo.Focus()
                Case Else
                    If txtEntryNo.Text = "" Or Val(txtEntryNo.Text) = 0 Then
                        txtEntryNo.Focus()
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

                    Call Fill_Sr_No_Item(GrdItem, _DataTableGrid)
                    _FrmLoad = False
            End Select
        ElseIf e.KeyCode = Keys.PageUp Then
            If _FORMMODE = "EDIT" And Val(txtEntryNo.Text) > 1 And Last_Saved_Entry_No > 0 Then
                txtEntryNo.Text = Val(txtEntryNo.Text) - 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _ChallanTableName)
            End If
        ElseIf e.KeyCode = Keys.PageDown Then
            If _FORMMODE = "EDIT" And Last_Saved_Entry_No > 0 And Val(txtEntryNo.Text) < Last_Saved_Entry_No Then
                txtEntryNo.Text = Val(txtEntryNo.Text) + 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _ChallanTableName)
            End If
        End If
    End Sub

#End Region

#Region "Button Click"
    Private Sub Label_Value_Nil_Rest()
        lbl_Tot_Amt.Text = ""
        Lbl_Tot_Mtr_Weight.Text = ""
    End Sub
    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        _FORMMODE = "ADD"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Label_Value_Nil_Rest()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()

    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        _FORMMODE = "EDIT"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Label_Value_Nil_Rest()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        _FORMMODE = "DELETE"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Label_Value_Nil_Rest()
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) - 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)

            Call Validate_Entry_No(Book_Vno, _ChallanTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) + 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            Call Validate_Entry_No(Book_Vno, _ChallanTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        _FrmLoad = False
        _FORMMODE = "SAVE"
        SaveRecord()
    End Sub

    Private Sub UC_Buttons1_CloseClick() Handles UC_Buttons1.CloseClick
        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FORMMODE = "VIEW"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Label_Value_Nil_Rest()
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"
        RequisitionPrint.Show()
    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"
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
            sqL = "DELETE FROM TrnPackingSlip WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "' "
            sql_Data_Save_Delete_Update()
            _KeyFieldValue = 0
            _FORMMODE = "ADD"
            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Old_Date = txtChallanDate.Text
            ObjCls_General.Blank_Object(Me)
            txtChallanDate.Text = Old_Date
        Catch ex As Exception
            MsgBox("Error While Delete Entry")
        Finally
        End Try
        _FrmLoad = False
    End Sub

#End Region

#Region "Save Code "
    Private Sub SaveRecord()
        If _FORMMODE = "EDIT" Then
            Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
            If _userwrits = "N" Then
                MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
            MsgBox("Invalid Item Detail", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            GrdItem.Focus()
            GrdItem.Select()
            Exit Sub
        End If
        If txtAcOfCode.Text = "" Then
            txtAcOfCode.Text = "0000-000000001"
        End If
        If txtTr_code.Text = "" Then txtTr_code.Text = "0000-000000001"
        If txtUnitCode.Text = "" Then txtUnitCode.Text = "0001-000000091"
        If txtAccount_Code.Text = "" Then txtAccount_Code.Text = "0000-000000001"
        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)
        Generate_Date_For_DataBase(txtChallanDate)
        Call Fill_Grid_Records_Into_DataTables()
        Dim _LastID As Integer = -1
        Try
            _LastID = SAVE_INTO_DATABASE_SQL()
            Old_Date = txtChallanDate.Text
            Call Label_Value_Nil_Rest()
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

            ObjCls_General.Blank_Object(Me)
            txtChallanDate.Text = Old_Date
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)

            UC_Buttons1._ButtonEnableDisable("LOAD")
            UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        _DataTableGrid.Rows.Clear()

        For i As Int16 = 1 To GrdItem.Rows - 1
            If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text <> "" And Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) > 0 Then
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
            .Append("DESPATCHCODE,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("PACK_SLIP_NO,")
            .Append("PACK_SLIP_DATE,")
            .Append("AccountCode,")
            .Append("TransportCode,")
            .Append("ACOFCODE,")
            .Append("GODOWNCODE,")
            .Append("OP20,")
            .Append("HeaderRemark")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtDespatch_code.Text & ",")
            .Append(txtEntryNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(_BookCode & ",")
            .Append(txtChallanNo.Text & ",")
            .Append(txtChallanDate.Date_for_Database & ",")
            .Append(txtAccount_Code.Text & ",")
            .Append(txtTr_code.Text & ",")
            .Append(txtAcOfCode.Text & ",")
            .Append(_GodownCode & ",")
            .Append(Txt_BookName.Text & ",")
            .Append(txtHeader_Remark.Text)
        End With

        QueryDetailTable = ObjCls_General.GetQueryArray(_ChallanTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid
    End Function
    Private Function SAVE_INTO_DATABASE_SQL() As Integer
        Dim strQuery As String = ""
        Dim affected As Integer = 0
        Dim I As Integer = 0

        Try
            '---------------- Delete Previous Bill Sundry ----------------------------------'
            strQuery = "DELETE FROM TrnPackingSlip WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "' "

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
            Return affected
        Catch ex As Exception
            MsgBox("new error comes :" & ex.Message & "-" & strQuery)
            Throw ex
        Finally
        End Try
    End Function
#End Region


#Region "VIEW RECORD "

    Private Sub btn_View_Ok_Click_1(sender As Object, e As EventArgs)
        View_Record()
    End Sub
    Private Sub View_Record()
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""
        View_Filter_Condition = " AND  A.BOOKCODE='" & _BookCode & "' AND  A.GODOWNCODE='" & _GodownCode & "' AND  A.PACK_SLIP_DATE>='" & txt_From.Date_for_Database & "' AND  A.PACK_SLIP_DATE<='" & txt_To.Date_for_Database & "'"
        View_Order_By = " ORDER BY  A.PACK_SLIP_DATE,( A.ENTRYNO), A.SRNO "

        Dim Offer_Field_String As String = ""

        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append("  A.BookVno, ")
            .Append("  A.ENTRYNO as [Entry No], ")
            .Append("  A.PACK_SLIP_NO as [Challan No], ")
            .Append("  A.OP20 as [Book Name], ")
            .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') AS [Challan Date], ")
            .Append(" MstMasterAccount.accountname as [Party Name], ")
            .Append("  A.SRNO as [Sno], ")
            '.Append(" MSTSTOREITEMGROUP.GROUPNAME AS [Group Name], ")
            .Append(" MstFabricItem.ITENNAME as [Item Name], ")
            .Append(" K.subItemName  AS [Sub Item], ")
            .Append(" E.DEPARTMENTNAME  AS DEPARTMENT, ")
            '.Append(" F.ColorName AS Color,  ")
            .Append(" FORMAT( A.MTR_WEIGHT,'0.000') as [Quantity], ")
            '.Append(" MstCutMaster.cutname as [Unit], ")
            .Append(" FORMAT( A.RATE,'0.00') as [Gross Rate], ")
            '.Append("  A.RDVALUE as [Tax %],")
            .Append("  A.AMOUNT as [Amount],")
            .Append(" MstTransport.TransportName as [Transport], ")
            .Append(" C.accountname as [Agent Name], ")
            .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
            .Append("  A.HeaderRemark as [Remark] ")
            .Append(" FROM  ")
            .Append(" TrnPackingSlip AS A  ")
            .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
            .Append(" LEFT JOIN MstFabricItem ON A.ITEMCODE=MstFabricItem.ID   ")
            .Append(" LEFT JOIN MstMasterAccount ON A.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTTRANSPORT  ON A.TRANSPORTCODE=MSTTRANSPORT.ID   ")
            .Append(" LEFT JOIN MstMasterAccount AS C ON MstMasterAccount.AGENTCODE=C.ACCOUNTCODE   ")
            .Append(" LEFT JOIN Mst_Acof_Supply ON  A.ACOFCODE=Mst_Acof_Supply.ID   ")
            .Append(" LEFT JOIN MstCutMaster ON MstCutMaster.ID=A.CUTCODE ")
            .Append(" LEFT JOIN MstStoreSubItem K  ON  A.SHADECODE = K.subItemCode ")
            .Append(" LEFT JOIN MstDepartment E  ON A.DESIGNCODE=E.Departmentcode ")
            .Append(" LEFT JOIN MstColor F  ON  A.CUTCODE1=F.COLORCODE ")
            .Append(" WHERE 1=1 ")
            .Append(_UNiteWiseCode)
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With


        sqL = strQuery.ToString
        sql_connect_slect()

        FirstStage.Columns.Clear()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then

            GridControl1.DataSource = tblTmp

            FirstStage.Columns(0).Visible = False

            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)


            FirstStage.GroupRowHeight = 30
            FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

            FirstStage.Columns("Quantity").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            FirstStage.Columns("Quantity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0}"))
            FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0}"))


            AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
            PNL_View.Visible = True
            FirstStage.BestFitColumns()
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
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Quantity", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Quantity")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Amount", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Amount")})
        'gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Kata Mtrs", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Kata Mtrs")})

        gridView.Appearance.GroupRow.BackColor = Color.LightGreen
    End Sub

    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs)
        Dim _RptTiltle = " Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs)
        _DevExpressExcelExport(GridControl1)
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
            Validate_Entry_No(BookVno, _ChallanTableName)
        End If

        If _FORMMODE = "ADD" Then
            txtChallanNo.Text = txtEntryNo.Text
        End If

    End Sub
    Private Sub Validate_Entry_No(ByVal Book_Vno As String, ByVal Table_Name As String)
        _TransctionNo = 0
        strQuery = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " AS A  WHERE A.BOOKVNO='" & Book_Vno & "'  " & _UNiteWiseCode & ""
        sqL = strQuery
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = DefaltSoftTable.Rows(0).Item(0)
        End If

        If _TransctionNo > 0 Then
            If _FORMMODE = "ADD" Then
                MsgBox("Entry No. Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                txtEntryNo.Focus()
                txtEntryNo.Select()

            ElseIf _FORMMODE = "EDIT" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
                Change_Grid_Data = True
                GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                _FrmLoad = False
                txtChallanNo.Focus()
                txtChallanNo.Select()
            ElseIf _FORMMODE = "DELETE" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)
                If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Entry_SQL()
                End If

                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
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
            Else
                If _BookCode = "0001-000000153" Then
                    If _FORMMODE = "ADD" Then
                        txtChallanNo.Text = txtEntryNo.Text
                        Generate_Date_For_DataBase(txtChallanDate)
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT   A.*,")
            .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') as F_CHALLANDATE, ")
            .Append(" MstCity.cityname AS DESPATCH, ")
            .Append(" MstFabricItem.ITENNAME AS ITEMNAME, ")
            .Append(" MstMasterAccount.ACCOUNTNAME,  ")
            .Append(" MstTransport.ID AS TRANSPORTCODE ,MstTransport.TransportName, ")
            .Append(" C.accountname as agentname, ")
            .Append(" MstCutMaster.CUTNAME, ")
            .Append(" Mst_Acof_Supply.AC_NAME AS AcOfName, ")
            .Append(" E.DEPARTMENTNAME AS DEPARTMENT, ")
            .Append(" F.ColorName AS COLORNAME,  ")
            .Append(" K.subItemName  AS COMPANYNAME ")
            .Append(" FROM  ")
            .Append(" TrnPackingSlip AS A  ")
            .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
            .Append(" LEFT JOIN MstFabricItem ON A.ITEMCODE=MstFabricItem.ID   ")
            .Append(" LEFT JOIN MstMasterAccount ON A.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTTRANSPORT  ON A.TRANSPORTCODE=MSTTRANSPORT.ID   ")
            .Append(" LEFT JOIN MstMasterAccount AS C ON MstMasterAccount.AGENTCODE=C.ACCOUNTCODE   ")
            .Append(" LEFT JOIN Mst_Acof_Supply ON  A.ACOFCODE=Mst_Acof_Supply.ID   ")
            .Append(" LEFT JOIN MstCutMaster ON MstCutMaster.ID=A.CUTCODE ")
            .Append(" LEFT JOIN MstStoreSubItem K  ON  A.SHADECODE = K.subItemCode ")
            .Append(" LEFT JOIN MstDepartment E  ON A.DESIGNCODE=E.Departmentcode ")
            .Append(" LEFT JOIN MstColor F  ON  A.CUTCODE1=F.COLORCODE ")
            .Append(" WHERE 1=1  ")
            .Append(" AND  A.BOOKVNO='" & strKeyID & "'")
            .Append(" AND  A.GODOWNCODE='" & _GodownCode & "'")
            .Append(" ORDER BY  A.SRNO ")
        End With
        Return strQuery.ToString
    End Function
#End Region

#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = False
        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)
        sqL = strQuery
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        txtChallanNo.Text = tblTmp.Rows(0)("PACK_SLIP_NO").ToString
        txtChallanDate.Text = tblTmp.Rows(0)("F_CHALLANDATE").ToString
        txtHeader_Remark.Text = tblTmp.Rows(0)("HEADERREMARK").ToString
        txtTr_code.Text = tblTmp.Rows(0)("TRANSPORTCODE").ToString
        txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        txtDespatch_code.Text = tblTmp.Rows(0)("DESPATCHCODE").ToString
        txtChallanDate.Text = tblTmp.Rows(0)("F_CHALLANDATE").ToString
        txtAcOfCode.Text = tblTmp.Rows(0)("ACOFCODE").ToString
        Generate_Date_For_DataBase(txtChallanDate)
        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)

        GrdItem.Refresh()
        GrdItem.Visible = True

        For i As Int16 = 1 To GrdItem.Rows - 1
            GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = i
        Next
        Total_Upto_All_Grid_All_Row()
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        _FrmLoad = False
    End Sub
#End Region


#Region "TOTAL ALL ROWS "
    Private Sub Total_Upto_All_Grid_All_Row()
        If _FrmLoad = True Then Exit Sub

        Dim Tot_Mtr_Weight As Double = 0
        Dim Tot_Amt As Double = 0

        For j As Int16 = 1 To GrdItem.Rows - 1
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
            Tot_Amt = Tot_Amt + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text)
        Next

        If Tot_Mtr_Weight > 0 Then
            Lbl_Tot_Mtr_Weight.Text = FormatNumber(Tot_Mtr_Weight, 2, TriState.True, TriState.False, TriState.True)
        Else
            Lbl_Tot_Mtr_Weight.Text = "0.00"
        End If

        If Tot_Amt > 0 Then
            lbl_Tot_Amt.Text = FormatNumber(Tot_Amt, 2, TriState.True, TriState.False, TriState.True)
        Else
            lbl_Tot_Amt.Text = "0.00"
        End If

    End Sub
#End Region

#Region "Txt Book Name Events Code "
    Private Sub txtBookName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGodownName.KeyPress
        If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub

        DispList = False
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then

            Dim _Filterstring As String = " AND A.BOOKCATEGORY='FACTORY-BEAM'"
            Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtGodownName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtgodowncode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("BookName") Then txtGodownName.Text = selected("BookName").ToString()
            End If
            _GodownCode = txtgodowncode.Text
            SendKeys.Send("{TAB}")

            Call defineGridColName()
            Call GenerateTable(_DataTableGrid, GrdItem)
            Call GridFormatting(_DataTableGrid, GrdItem)

            GrdItem.Rows = 2
            GrdItem.Column(0).Visible = False
            GrdItem.Row(0).Height = 31
            GrdItem.DefaultRowHeight = 28

            Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        End If

    End Sub

    Private Sub txtGodownName_Validated(sender As Object, e As EventArgs) Handles txtGodownName.Validated
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
    End Sub

    Private Sub Txt_BookName_Validated(sender As Object, e As EventArgs) Handles Txt_BookName.Validated
        _Validated()
    End Sub


    Private Sub _Validated()
        If _FrmLoad = True Then Exit Sub

        Dim TmpTbl As New DataTable
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 A.*, ")
            .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" B.ACCOUNTNAME,C.AC_NAME AS ACOFNAME,F.ACCOUNTNAME AS AGENTNAME,")
            .Append(" G.BooKName, ")
            .Append(" D.TRANSPORTNAME,E.CITYNAME AS DESPATCH ")
            .Append(" FROM TrnPackingSlip AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE = B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstMasterAccount AS F ON B.AGENTCODE = F.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Acof_Supply AS C ON A.ACOFCODE = C.ID ")
            .Append(" LEFT JOIN MSTTRANSPORT AS D ON A.TRANSPORTCODE = D.ID ")
            .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE = E.CITYCODE ")
            .Append(" LEFT JOIN MSTBook AS G ON A.GodownCode = G.BookCode ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" AND A.GODOWNCODE='" & txtgodowncode.Text & "'" & " ")
            .Append(" ORDER BY A.Id DESC ")
        End With

        Dim Str_Qry As String = _strQuery.ToString
        Dim TblTmp As New DataTable
        sqL = Str_Qry
        sql_connect_slect()
        TblTmp = DefaltSoftTable.Copy

        Dim Last_Entry_No As Integer = 0
        If TblTmp.Rows.Count > 0 Then
            Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
        End If

        If _FORMMODE = "ADD" Then
            txtEntryNo.Text = Last_Entry_No + 1
            If Last_Entry_No > 0 Then
                txtChallanDate.Text = TblTmp(0)("F_CHALLANDATE").ToString
                txtAccount_Code.Text = TblTmp(0)("ACCOUNTCODE").ToString
                txtAcOfCode.Text = TblTmp(0)("ACOFCODE").ToString
                txtDespatch_code.Text = TblTmp(0)("DESPATCHCODE").ToString
                txtTr_code.Text = TblTmp(0)("TRANSPORTCODE").ToString
                txtEntryNo.Text = Last_Entry_No + 1
            Else
                txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                txtEntryNo.Text = "1"
            End If
            txtChallanDate.Text = ObjCls_General.GetTodayDate_British
            Generate_Date_For_DataBase(txtChallanDate)
            GrdItem.Rows = 2
            GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
            txtEntryNo.Focus()
            txtEntryNo.Select()
        ElseIf _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
            If Last_Entry_No = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
                Exit Sub
            Else
                txtEntryNo.Text = Last_Entry_No
                Last_Saved_Entry_No = Last_Entry_No
                Generate_Date_For_DataBase(txtChallanDate)
                txtEntryNo.Focus()
                txtEntryNo.Select()
            End If
        ElseIf _FORMMODE = "VIEW" Then
            If Last_Entry_No = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                Txt_BookName.Focus()
                Txt_BookName.Select()
            Else
                View_Record()
            End If
        ElseIf _FORMMODE = "PRINT" Then
            If Last_Entry_No = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
            Else
                View_Record()
            End If
        End If
    End Sub
#End Region


#Region "GRID ITEM EVENTS "
    Private Sub grditem_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub

    Private Sub grdItem_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
    End Sub

    Private Sub grdItem_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True

        If _ActivatedColName = "TAX_PER" Then
            'MsgBox("GOPAL")
        End If
        If _ActivatedColName = "QTY" Or _ActivatedColName = "MTR_WEIGHT" Or _ActivatedColName = "RATE_DIS_PER" Or _ActivatedColName = "RATE" Or _ActivatedColName = "AMOUNT" Then
            Calc_Net_Rate()
        End If
    End Sub

    Private Sub grdItem_EnterRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.EnterRowEventArgs) Handles GrdItem.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
        _FrmLoad = False
    End Sub

    Private Sub grdItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
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
        Dim ITEMGROUPCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Y_DELV_ACCOUNTCODE") + 1).Text
        Dim QTY As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)

        If ITEMCODE = "" Or QTY = 0 Then
            If _ActivatedColName = "ROWREMARK" Then
                e.Cancel = True
                If ITEMCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf QTY = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).SetFocus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grditem_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GrdItem.KeyPress
        If _FrmLoad = True Then Exit Sub
    End Sub

    Private Sub Calc_Net_Rate()
        Dim Commu_Net_Rate As Double = 0
        Dim GROSS_RATE As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text)
        Dim TAX_PER As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RDVALUE") + 1).Text)
        Dim QTY As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)

        Dim AMOUNT As Double = Math.Round(QTY * GROSS_RATE, 2, MidpointRounding.AwayFromZero)
        Dim _GstTAxAmt As Double = AMOUNT * TAX_PER / 100
        AMOUNT = AMOUNT + _GstTAxAmt
        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = AMOUNT
        Call Total_Upto_All_Grid_All_Row()
    End Sub

    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub

        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Y_DELV_ACCOUNTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Y_DELV_ACCOUNTCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE1") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE1") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = "0000-000000001"

        Dim Col_Text As String = GrdItem.ActiveCell.Text

        If _ActivatedColName = "CUTNAME" Then
            If e.KeyCode = Keys.Enter Then
                'txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text
                'txt_Code_For_Grid_Selection.Text = ""
                'Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                'obj_Party_Selection.SINGLE_Cut_SELECTION(" AND CATEGORY='STORE' ")
                'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                '    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                '    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = txt_Name_For_Grid_Selection.Text
                '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = txt_Code_For_Grid_Selection.Text
                'End If
                Dim _StrQuery As New StringBuilder
                With _StrQuery
                    .Append(" SELECT ")
                    .Append(" B.CUTNAME AS UOM, ")
                    .Append(" '' as Remark, ")
                    .Append(" A.CUTCODE AS ACCOUNTCODE ")
                    .Append(" FROM TrnPackingSlip AS A ")
                    .Append(" LEFT JOIN MstCutMaster AS B ON A.CUTCODE = B.ID ")
                    .Append(" WHERE 1=1 ")
                    .Append(" AND A.Bookcode = '" & _BookCode & "' ")
                End With
                Dim _LoadQuery As String = _StrQuery.ToString()
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTCODE") Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = selected("ACCOUNTCODE").ToString()
                    End If
                    If selected.ContainsKey("UOM") Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = selected("UOM").ToString()
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "COMPANYNAME" Then
            If e.KeyCode = Keys.Enter Then
                txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COMPANYNAME") + 1).Text
                txt_Code_For_Grid_Selection.Text = ""
                Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                Dim _LoadQuery = NewSelectionList.SINGLE_INSURANCE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTCODE") Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = selected("ACCOUNTCODE").ToString()
                    End If
                    If selected.ContainsKey("COMPANYNAME") Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COMPANYNAME") + 1).Text = selected("COMPANYNAME").ToString()
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "ITEMNAME" Then
            If e.KeyCode = Keys.Enter Then
                If Change_Grid_Data = True Then
                    Dim Item_Group_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Y_DELV_ACCOUNTCODE") + 1).Text
                    txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
                    'txt_Code_For_Grid_Selection.Text = ""
                    'Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                    'obj_Party_Selection.SINGLE_ITEM_SELECTION()
                    'txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    'txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    ''End If
                    'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = txt_Name_For_Grid_Selection.Text
                    '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = txt_Code_For_Grid_Selection.Text
                    'End If
                    Dim _StrQuery As New StringBuilder
                    With _StrQuery
                        .Append(" SELECT ")
                        .Append(" B.ITENNAME AS ItemName, ")
                        .Append(" A.ITEMCODE AS ACCOUNTCODE ")
                        .Append(" FROM TrnPackingSlip AS A ")
                        .Append(" LEFT JOIN MstFabricItem AS B ON A.ITEMCODE = B.ID ")
                        .Append(" WHERE 1=1 ")
                        .Append(" AND A.Bookcode = '" & _BookCode & "'")
                    End With
                    Dim _LoadQuery As String = _StrQuery.ToString()
                    Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", "SINGLE")
                    If selected IsNot Nothing Then
                        If selected.ContainsKey("ACCOUNTCODE") Then
                            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = selected("ACCOUNTCODE").ToString()
                        End If

                        If selected.ContainsKey("ItemName") Then
                            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = selected("ItemName").ToString()
                        End If
                    End If
                    txt_Name_For_Grid_Selection.Text = ""
                End If
                txt_Name_For_Grid_Selection.Text = ""
            End If
        ElseIf _ActivatedColName = "DEPARTMENT" Then
            If e.KeyCode = Keys.Enter Then
                If Change_Grid_Data = True Then
                    txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DEPARTMENT") + 1).Text
                    'txt_Code_For_Grid_Selection.Text = ""
                    'Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                    'obj_Party_Selection.Single_STORE_DEPARTMENT_Selection()
                    'txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    'txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    ''End If
                    'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DEPARTMENT") + 1).Text = txt_Name_For_Grid_Selection.Text
                    '    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = txt_Code_For_Grid_Selection.Text
                    'End If
                    Dim _StrQuery As New StringBuilder
                    With _StrQuery
                        .Append(" SELECT ")
                        .Append(" B.Departmentname as [Dep. Name],")
                        .Append(" B.Descr as Remark, ")
                        .Append(" A.DesignCode AS ACCOUNTCODE ")
                        .Append(" FROM TrnPackingSlip AS A ")
                        .Append(" LEFT JOIN MstDepartment AS B ON A.DesignCode = B.Departmentcode ")
                        .Append(" WHERE 1=1 ")
                        .Append(" AND A.Bookcode = '" & _BookCode & "'")
                    End With
                    Dim _LoadQuery As String = _StrQuery.ToString()
                    Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", "SINGLE")
                    If selected IsNot Nothing Then
                        If selected.ContainsKey("ACCOUNTCODE") Then
                            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = selected("ACCOUNTCODE").ToString()
                        End If

                        If selected.ContainsKey("Dep. Name") Then
                            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DEPARTMENT") + 1).Text = selected("Dep. Name").ToString()
                        End If
                    End If
                    txt_Name_For_Grid_Selection.Text = ""
                End If
                txt_Name_For_Grid_Selection.Text = ""
            End If

        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "MTR_WEIGHT" Or _ActivatedColName = "RATE_DIS_PER" Or _ActivatedColName = "RATE" Or _ActivatedColName = "RDVALUE" Then
            If e.KeyCode = Keys.Enter Then
                If _ActivatedColName = "GROSS_RATE" Then
                    If Val(GrdItem.ActiveCell.Text) = 0 And Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) <> 0 Then
                        'Rate_Display()
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdItem.ActiveCell.Row
                Dim CUTNAME As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text
                Dim ITEMNAME As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
                If ITEMNAME = "" Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = ""
                End If
                Dim CUTCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text
                Dim QTY As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
                Dim ITEMCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
                Dim NET_RATE As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text)

                If QTY <> 0 And ITEMCODE <> "" And ITEMNAME <> "" Then
                    If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                        GrdItem.Rows = GrdItem.Rows + 1
                        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Fill_Rate()
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000005"
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = "PCS"
        End If

        Dim Item_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text

        If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text) <> 0 Then
            Exit Sub
        End If

        If Item_Code <> "" Then
            strQuery = "SELECT * FROM TRNCHALLAN WHERE ITEMCODE='" & Item_Code & "' AND ACCOUNTCODE='" & txtAccount_Code.Text & "' " & _UNiteWiseCode & "   AND GROSS_RATE>0 ORDER BY ENTRYNO "
            sqL = strQuery
            sql_connect_slect()
            _TmpDataTable = DefaltSoftTable.Copy


            If _TmpDataTable.Rows.Count = 0 Then
                strQuery = "SELECT * FROM MSTSTOREITEM WHERE ITEMCODE='" & Item_Code & "'"
                sqL = strQuery
                sql_connect_slect()
                _TmpDataTable = DefaltSoftTable.Copy

                _TmpDataRow = _TmpDataTable.Rows(0)
                Dim Item_Rate As Double = Val(_TmpDataRow("SALE_RATE").ToString)
                If Item_Rate <> 0 And GrdItem.ActiveCell.Row >= 1 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text = Item_Rate
                End If
            Else
                _TmpDataRow = _TmpDataTable.Rows(_TmpDataTable.Rows.Count - 1)
                Dim Item_Rate As Double = Val(_TmpDataRow("GROSS_RATE".ToString))
                Dim Chl_No As String = _TmpDataRow("CHALLANNO".ToString)
                Dim Dis_Per As Double = Val(_TmpDataRow("RATE_DIS_PER").ToString)
                If Item_Rate <> 0 And GrdItem.ActiveCell.Row >= 1 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text = Item_Rate
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE_DIS_PER") + 1).Text = Dis_Per
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

    Private Sub Ctl_BookName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_BookName.KeyPress
        If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub
        DispList = False
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            Dim selected = SelectBookType(Txt_BookName.Text)
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then
                    _BookCode = selected("ACCOUNTCODE").ToString()
                End If
                If selected.ContainsKey("BookName") Then
                    Txt_BookName.Text = selected("BookName").ToString()
                End If
            End If
            Select Case _BookCode
                Case "RQSS-000000001"
                    _BookTrType = "RQSS1"
                Case "RQSS-000000002"
                    _BookTrType = "RQSS2"
                Case "RQSS-000000003"
                    _BookTrType = "RQSS3"
            End Select
            SendKeys.Send("{TAB}")
            Call defineGridColName()
            Call GenerateTable(_DataTableGrid, GrdItem)
            Call GridFormatting(_DataTableGrid, GrdItem)
            GrdItem.Rows = 2
            GrdItem.Column(0).Visible = False
            GrdItem.Row(0).Height = 31
            GrdItem.DefaultRowHeight = 28
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = "Store Requisition Details"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub


    Public Function SelectBookType(ByVal SearchText As String) As Dictionary(Of String, Object)
        Dim _LoadQuery As String =
            "SELECT 'RQSS-000000001' AS ACCOUNTCODE, 'STORE' AS BookName " &
            "UNION ALL SELECT 'RQSS-000000002','RAW MATERIALS' " &
            "UNION ALL SELECT 'RQSS-000000003','PET BOTTELS'"
        Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, SearchText, "SINGLE")
        Return selected
    End Function

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        View_Record()
    End Sub
#End Region
End Class