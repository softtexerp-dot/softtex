Imports System.Management
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid

Friend Class SampleOrderOrDespatch
    Private obj_Party_Selection As New Multi_Selection_Master
    Private Offer_Tbl As New DataTable
    Dim _QtyColumn As String = ""
    Dim _BarcodeCoumn As String = ""
    Dim _PartyNameColumn As String = ""
    Dim _AcOfColumn As String = ""
    Dim _DespatchColumn As String = ""
    Dim _TransportColumn As String = ""
    Dim _Add1Column As String = ""
    Dim _Add2Column As String = ""
    Dim _Add3Column As String = ""
    Dim _CityColumn As String = ""
    Dim _MobileColumn As String = ""
    Dim _AgentColumn As String = ""
    Dim _AgentMobColumn As String = ""
    Dim _OrderColumn As String = ""
    Dim _DesignColumn As String = ""
    Dim defalt_button_PRINT_YES_NO As String = ""
    Dim ITEM_RATE_BY As String = ""
    Dim ALLOW_PRINT_YES_NO As String = ""
    Dim _totalRowInGrid As Int64 = 0
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
    Private WithEvents txt_OfferBookVno As New TextBox

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
            .Append("ACOFCODE,")
            .Append("CLEAR_REMARK,")
            .Append("SRNO,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("PartyOfferNo,")
            .Append("PymtDays,") ' BARCODE
            .Append("OfferNo,")
            .Append("OfferDate,")
            .Append("AgentOfferNo,")
            .Append("ACCOUNTNAME,")
            .Append("AccountCode,")
            .Append("ACOFNAME,")
            .Append("DESPATCHNAME,")
            .Append("TRANSPORTNAME,")
            .Append("TransportCode,")
            .Append("DespatchCode,")
            .Append("HeaderRemark,")
            .Append("Term1,")
            .Append("Term2,")
            .Append("Term3,")
            .Append("Term4,")
            .Append("ITEMGROUPCODE,")
            .Append("ITEMGROUPNAME,")
            .Append("ITEMCODE,")
            .Append("SHADENAME,")
            .Append("ITEMNAME,")
            .Append("CUTCODE,")
            .Append("CUTNAME,")
            .Append("DESCR,")
            .Append("DESIGNCODE,")
            .Append("DESIGNNAME,")
            .Append("SHADECODE,")
            .Append("MTR_WEIGHT,")
            .Append("LOTNO,")
            .Append("RATE,")
            .Append("GROSS_RATE,")
            .Append("RATE_DIS_PER,")
            .Append("NET_RATE,")
            .Append("PROCESSCODE,")
            .Append("RDVALUE,")
            .Append("RDON,")
            .Append("CDVALUE,")
            .Append("CDON,")
            .Append("CANCEL_QTY,")
            .Append("PROCESSNAME,")
            .Append("CLEAR,")
            .Append("ROWREMARK,")
            .Append("weavetypecode,")
            .Append("loomtypecode,")
            .Append("SELVCODE,")
            .Append("SelvedgeName,")
            .Append("DESIGNNO,") ' mobile
            .Append("AGENTCODE,")
            .Append("YARN_DETAIL")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("CANCEL_QTY:N,")
            .Append("RDVALUE:N,")
            .Append("CDVALUE:N,")
            .Append("PymtDays:N,")
            .Append("Mtr_Weight:N,")
            .Append("GROSS_RATE:N,")
            .Append("RATE_DIS_PER:N,")
            .Append("NET_RATE:N,")
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
            .Append("ITEMGROUPNAME:Item Category,")
            .Append("ACCOUNTNAME:Party Name,")
            .Append("ITEMNAME:Item Name,")
            .Append("MTR_WEIGHT:Quantity,")
            .Append("PARTYOFFERNO:OfferNo,")
            .Append("ACOFNAME:AcOf,")
            .Append("DESPATCHNAME:Despatch,")
            .Append("TRANSPORTNAME:Transport,")
            .Append("CUTNAME:Per,")
            .Append("CLEAR:Clear,")
            .Append("PymtDays:Barcode,")
            .Append("DESIGNNAME:Design,")
            .Append("SHADENAME:Type,")
            .Append("GROSS_RATE:Rate,")
            .Append("AGENTCODE:Agent,")
            .Append("YARN_DETAIL:AgentMob,")
            .Append("RATE_DIS_PER:Dis.%,")
            .Append("weavetypecode:Add 1,")
            .Append("loomtypecode:Add 2,")
            .Append("SELVCODE:Add 3,")
            .Append("SelvedgeName:City,")
            .Append("NET_RATE:Net Rate,")
            .Append("DESIGNNO:Mobile,")
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("ITEMGROUPNAME:L,")
            .Append("ITEMNAME:L,")
            .Append("ACOFNAME:L,")
            .Append("DESIGNNO:L,")
            .Append("DESPATCHNAME:L,")
            .Append("AGENTCODE:L,")
            .Append("YARN_DETAIL:L,")
            .Append("TRANSPORTNAME:L,")
            .Append("CUTNAME:L,")
            .Append("ACCOUNTNAME:L,")
            .Append("DESCR:L,")
            .Append("PymtDays:L,")
            .Append("weavetypecode:L,")
            .Append("loomtypecode:L,")
            .Append("SELVCODE:L,")
            .Append("SelvedgeName:L,")
            .Append("CLEAR:L,")
            .Append("DESIGNNAME:L,")
            .Append("PARTYOFFERNO:L,")
            .Append("SHADENAME:L,")
            .Append("CANCEL_QTY:R,")
            .Append("MTR_WEIGHT:R,")
            .Append("GROSS_RATE:R,")
            .Append("RATE_DIS_PER:R,")
            .Append("NET_RATE:R,")
            .Append("RATE:R,")
            .Append("PROCESSNAME:L,")
            .Append("LOTNO:C,")
            .Append("RDVALUE:R,")
            .Append("RDON:C,")
            .Append("CDVALUE:R,")
            .Append("CDON:C,")
            .Append("ROWREMARK:L")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("ITEMGROUPNAME:L,")
            .Append("ACOFNAME:L,")
            .Append("DESIGNNO:L,")
            .Append("DESPATCHNAME:L,")
            .Append("weavetypecode:L,")
            .Append("loomtypecode:L,")
            .Append("AGENTCODE:L,")
            .Append("YARN_DETAIL:L,")
            .Append("SELVCODE:L,")
            .Append("SelvedgeName:L,")
            .Append("TRANSPORTNAME:L,")
            .Append("ITEMNAME:L,")
            .Append("CUTNAME:L,")
            .Append("ACCOUNTNAME:L,")
            .Append("PymtDays:L,")
            .Append("PARTYOFFERNO:L,")
            .Append("CLEAR:L,")
            .Append("DESCR:L,")
            .Append("SHADENAME:L,")
            .Append("CANCEL_QTY:R,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("GROSS_RATE:R,")
            .Append("RATE_DIS_PER:R,")
            .Append("NET_RATE:R,")
            .Append("PROCESSNAME:L,")
            .Append("LOTNO:C,")
            .Append("RDVALUE:R,")
            .Append("RDON:C,")
            .Append("CDVALUE:R,")
            .Append("CDON:C,")
            .Append("ROWREMARK:L")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("ACOFCODE:N,")
            .Append("CLEAR:N,")
            .Append("CLEAR_REMARK:N,")
            .Append("SRNO:Y,")
            .Append("DESIGNNO:" & _MobileColumn & ",")
            .Append("ACCOUNTNAME:" & _PartyNameColumn & ",")
            .Append("ENTRYNO:N,")
            .Append("BookTrtype:N,")
            .Append("BOOKVNO:N,")
            .Append("BookCode:N,")
            .Append("OfferNo:N,")
            .Append("OfferDate:N,")
            .Append("PymtDays:" & _BarcodeCoumn & ",")
            .Append("MTR_WEIGHT:" & _QtyColumn & ",")
            .Append("PartyOfferNo:" & _OrderColumn & ",")
            .Append("CLEAR:N,")
            .Append("AgentOfferNo:N,")
            .Append("AccountCode:N,")
            .Append("TransportCode:N,")
            .Append("DespatchCode:N,")
            .Append("HeaderRemark:N,")
            .Append("Term1:N,")
            .Append("Term2:N,")
            .Append("Term3:N,")
            .Append("Term4:N,")
            .Append("ITEMCODE:N,")
            .Append("ITEMNAME:Y,")
            .Append("ITEMGROUPCODE:N,")
            .Append("ITEMGROUPNAME:N,")
            .Append("CUTCODE:N,")
            .Append("DESCR:N,")
            .Append("DESIGNCODE:N,")
            .Append("DESIGNNAME:" & _DesignColumn & ",")
            .Append("SHADECODE:N,")
            .Append("SHADENAME:Y,")
            .Append("CUTNAME:N,")
            .Append("LOTNO:N,")
            .Append("RATE:N,")
            .Append("AGENTCODE:" & _AgentColumn & ",")
            .Append("YARN_DETAIL:" & _AgentMobColumn & ",")
            .Append("GROSS_RATE:Y,")
            .Append("RATE_DIS_PER:N,")
            .Append("NET_RATE:N,")
            .Append("PROCESSCODE:N,")
            .Append("PROCESSNAME:N,")
            .Append("ACOFNAME:" & _AcOfColumn & ",")
            .Append("DESPATCHNAME:" & _DespatchColumn & ",")
            .Append("TRANSPORTNAME:" & _TransportColumn & ",")
            .Append("weavetypecode:" & _Add1Column & ",")
            .Append("loomtypecode:" & _Add2Column & ",")
            .Append("SELVCODE:" & _Add3Column & ",")
            .Append("SelvedgeName:" & _CityColumn & ",")
            .Append("RDVALUE:N,")
            .Append("RDON:N,")
            .Append("CDVALUE:N,")
            .Append("CDON:N,")
            .Append("CANCEL_QTY:N,")
            .Append("ROWREMARK:Y")
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("ITEMGROUPNAME:N,")
            .Append("ACOFNAME:N,")
            .Append("DESPATCHNAME:N,")
            .Append("TRANSPORTNAME:N,")
            .Append("ITEMNAME:N,")
            .Append("DESIGNNAME:N,")
            .Append("SHADENAME:N,")
            .Append("PROCESSNAME:N,")
            .Append("ACCOUNTNAME:N,")
            .Append("CUTNAME:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:5,")
            .Append("ITEMGROUPNAME:18,")
            .Append("ITEMNAME:12,")
            .Append("CUTNAME:6,")
            .Append("DESIGNNAME:10,")
            .Append("SHADENAME:10,")
            .Append("DESCR:10,")
            .Append("MTR_WEIGHT:6,")
            .Append("weavetypecode:6,")
            .Append("loomtypecode:6,")
            .Append("SELVCODE:6,")
            .Append("SelvedgeName:6,")
            .Append("GROSS_RATE:6,")
            .Append("RATE_DIS_PER:8,")
            .Append("ACCOUNTNAME:18,")
            .Append("NET_RATE:10,")
            .Append("LOTNO:8,")
            .Append("PymtDays:8,")
            .Append("PARTYOFFERNO:6,")
            .Append("ACOFNAME:8,")
            .Append("DESPATCHNAME:8,")
            .Append("TRANSPORTNAME:8,")
            .Append("RDVALUE:4,")
            .Append("RDON:5,")
            .Append("CDVALUE:4,")
            .Append("CDON:5,")
            .Append("CLEAR:5,")
            .Append("CANCEL_QTY:8,")
            .Append("DESIGNNO:8,")
            .Append("PROCESSNAME:14,")
            .Append("AGENTCODE:8,")
            .Append("YARN_DETAIL:8,")
            .Append("ROWREMARK:10")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("MTR_WEIGHT:0,")
            .Append("RATE:0,")
            .Append("GROSS_RATE:0,")
            .Append("RATE_DIS_PER:0,")
            .Append("NET_RATE:0,")
            .Append("PCS_BALES:0,")
            .Append("RDVALUE:0,")
            .Append("RDON:0,")
            .Append("PymtDays:0,")
            .Append("CDVALUE:0,")
            .Append("CDON:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y")
            .Append(",CLEAR:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("MTR_WEIGHT:NO-2,")
            .Append("RATE:NO-2,")
            .Append("GROSS_RATE:NO-2,")
            .Append("RATE_DIS_PER:NO-2,")
            .Append("NET_RATE:NO-2,")
            .Append("PCS_BALES:NO-0,")
            .Append("PymtDays:NO-0,")
            .Append("RDVALUE:NO-2,")
            .Append("CDVALUE:NO-2")
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
        grdObj.Rows = 200
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
    Private _BookCode As String = ""
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
    Private WithEvents txtPartyCode As New TextBox
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
    Private Sub Txt_UseOffer_Validated(sender As Object, e As EventArgs) Handles Txt_UseOffer.Validated

        If Txt_UseOffer.Text = "YES" Then
            _OrderColumn = "Y"
        Else
            _OrderColumn = "N"
        End If

        If _FORMMODE = "ADD" Then
            Call defineGridColName()
            Call GenerateTable(_DataTableGrid, GrdItem)
            Call GridFormatting(_DataTableGrid, GrdItem)
            GrdItem.Rows = 2
            GrdItem.Column(0).Visible = False
            GrdItem.Row(0).Height = 31
            GrdItem.DefaultRowHeight = 28
        Else
            Call defineGridColName()
            Call GenerateTable(_DataTableGrid, GrdItem)
            Call GridFormatting(_DataTableGrid, GrdItem)
            GrdItem.Rows = _totalRowInGrid + 2
            GrdItem.Column(0).Visible = False
            GrdItem.Row(0).Height = 31
            GrdItem.DefaultRowHeight = 28
        End If

    End Sub
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
                If PnlPendingOffer.Visible = True Then
                    PnlPendingOffer.Visible = False
                    GrdItem.Focus()
                    Exit Sub
                End If

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
                    Total_Upto_All_Grid_All_Row()
                    If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
                        MsgBox("Blank Item Detail, Can't Save", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                        Exit Sub
                    Else
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        txtTerm1.Focus()
                        txtTerm1.Select()
                    End If
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
                    If txtEntryNo.Text = "" Or Val(txtEntryNo.Text) = 0 Then
                        txtEntryNo.Focus()
                    ElseIf txtOfferDate.Text = "  /  /    " Then
                        txtOfferDate.Focus()
                    ElseIf Trim(txtOfferNo.Text) = "" Then
                        txtOfferNo.Focus()
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
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub General_Order_Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        PNL_View.Width = Me.Width
        PNL_View.Height = Me.Height
        PNL_View.Location = New Point(0, 0)
        GridControl1.Width = PNL_View.Width - 25
        GridControl1.Height = PNL_View.Height - 100
        GridControl1.Location = New Point(3, 53)
        PnlPendingOffer.Width = Me.Width
        PnlPendingOffer.Height = 526
        PnlPendingOffer.Location = New Point(0, 1)
        Book_Code = "0001-000000869"
        _BookCode = Book_Code
        txtBookCode.Text = Book_Code
        _BookTrType = "SM869"
        _FrmLoad = True
        _GetBookData()
        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)
        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text
        Lbl_Tot_Mtr_Weight.Text = ""
        lbl_Tot_Bales.Text = ""
        'SetTotalObjectPosition("MTR_WEIGHT", _DataTableGrid, GrdItem, Lbl_Tot_Mtr_Weight, lbl_Total)
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
    Private Sub _GetBookData()
        Dim _MstTbl As New DataTable

        _MstTbl = SampleBooking._GetMstBookConfig(_BookCode)
        If _MstTbl.Rows.Count > 0 Then
            Dim r As DataRow = _MstTbl(0)
            _QtyColumn = GetValueOrNo(r, "OP62")
            _BarcodeCoumn = GetValueOrNo(r, "OP63")
            _OrderColumn = GetValueOrNo(r, "OP64")
            _DesignColumn = GetValueOrNo(r, "OP66")
            _PartyNameColumn = GetValueOrNo(r, "OP86")
            _AcOfColumn = GetValueOrNo(r, "OP87")
            _DespatchColumn = GetValueOrNo(r, "OP88")
            _TransportColumn = GetValueOrNo(r, "OP89")
            _Add1Column = GetValueOrNo(r, "OP101")
            _Add2Column = GetValueOrNo(r, "OP102")
            _Add3Column = GetValueOrNo(r, "OP103")
            _CityColumn = GetValueOrNo(r, "OP104")
            _MobileColumn = GetValueOrNo(r, "OP105")
            _AgentColumn = GetValueOrNo(r, "OP106")
            _AgentMobColumn = GetValueOrNo(r, "OP107")
            ALLOW_PRINT_YES_NO = r("ON_LINE_PRINTING").ToString
            defalt_button_PRINT_YES_NO = r("YES_SELECTED_FOR_PRINTING").ToString
            ITEM_RATE_BY = r("ITEM_RATE_BY").ToString
        End If
        If _OrderColumn = "Y" Then
            Txt_UseOffer.Text = "YES"
        Else
            Txt_UseOffer.Text = "NO"
        End If
        If _FORMMODE = "ADD" Then
            Call defineGridColName()
            Call GenerateTable(_DataTableGrid, GrdItem)
            Call GridFormatting(_DataTableGrid, GrdItem)
            GrdItem.Rows = 2
            GrdItem.Column(0).Visible = False
            GrdItem.Row(0).Height = 31
            GrdItem.DefaultRowHeight = 28
        End If
    End Sub
#End Region

#Region "TOTAL ALL ROWS "
    Private Sub Total_Upto_All_Grid_All_Row()
        _totalRowInGrid = 0
        Dim Tot_Mtr_Weight As Double = 0
        For j As Int16 = 1 To GrdItem.Rows - 1
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
            _totalRowInGrid += 1
        Next
        Lbl_Tot_Mtr_Weight.Text = Tot_Mtr_Weight
        Lbl_Tot_Mtr_Weight.Text = IIf(Tot_Mtr_Weight > 0, Format(Val(Lbl_Tot_Mtr_Weight.Text), "0.000"), "")
    End Sub
#End Region

#Region "COMMAND BUTTON VISIBILITY CODE "
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
        If Visibility_Flag = "LOAD" Then
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnPrint.Enabled = True
        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNEDIT" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        End If
        If pub_User_add = "N" Then
            btnAdd.Enabled = False
        End If
        If pub_User_modify = "N" Then
            btnEdit.Enabled = False
        End If
        If pub_User_delete = "N" Then
            btnDelete.Enabled = False
        End If
        If pub_User_view = "N" Then
            btnView.Enabled = False
        End If
        If pub_User_print = "N" Then
            btnPrint.Enabled = False
        End If
    End Sub
#End Region
#Region "SET FOCUS LAST CLICKED BTN "
    Private Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)
        _FORMMODE = ""
        If Last_Focused_Btn = "ADD" Then
            btnAdd.Focus()
        ElseIf Last_Focused_Btn = "EDIT" Then
            btnEdit.Focus()
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
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Edit_From_View = False
        _FrmLoad = False

        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"
        txtEntryNo.Visible = True
        Command_Button_Visibility("BTNADD")

        ObjCls_General.Blank_Object(Me)

        _GetBookData()

        txtBookName_Validated()
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "EDIT"
        Last_Focused_Btn = "EDIT"
        txtEntryNo.Visible = True
        Command_Button_Visibility("BTNEDIT")

        ObjCls_General.Blank_Object(Me)
        _GetBookData()
        txtBookName_Validated()
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

        txtBookName_Validated()
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        _FrmLoad = False

        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        Command_Button_Visibility("BTNVIEW")

        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Txt_EntryType.Text = "SUMMERY"
        View_Record()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        Offer_Printing.FORM_SELECTION_BY.Text = "ENTRY_DATA_FORM"
        Offer_Printing.BOOKCATEGORY.Text = "OFFER"
        Offer_Printing.Lbl_BEHAVIOUR.Text = "SAMPLE"
        Offer_Printing.Txt_bookName.Text = ""
        Offer_Printing.Date_frm.Text = "0"
        Offer_Printing.Date_to.Text = "0"
        Offer_Printing.txt_Stationary_Type.Text = "PLAIN"
        Offer_Printing.txt_Paper_Size.Text = "FULL"
        Offer_Printing.txtFormat.Text = "1"

        Offer_Printing.cmd_No_Wise.Focus()
        Offer_Printing.ShowDialog()

    End Sub
#End Region
#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE "
    Private Sub btnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAdd.BackColor = Color.Coral
    End Sub
    Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnAdd.BackColor = Me.BackColor
    End Sub

    Private Sub btnEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnEdit.BackColor = Color.Coral
    End Sub
    Private Sub btnEdit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnEdit.BackColor = Me.BackColor
    End Sub

    Private Sub btnDelete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnDelete.BackColor = Color.Coral
    End Sub
    Private Sub btnDelete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnDelete.BackColor = Me.BackColor
    End Sub
    Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnView.BackColor = Color.Coral
    End Sub
    Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnView.BackColor = Me.BackColor
    End Sub
    Private Sub btnSave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.BackColor = Color.Coral
    End Sub
    Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnSave.BackColor = Me.BackColor
    End Sub
    Private Sub btnPrint_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnPrint.BackColor = Color.Coral
    End Sub
    Private Sub btnPrint_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnPrint.BackColor = Me.BackColor
    End Sub
    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClose.BackColor = Color.Coral
    End Sub
    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClose.BackColor = Me.BackColor
    End Sub

#End Region
#Region "Label Value Setting "
    Private Sub Label_Decimal_Setting()
        If Val(lbl_Tot_Bales.Text) > 0 Then
            lbl_Tot_Bales.Text = FormatNumber(Val(lbl_Tot_Bales.Text), 3, TriState.True, TriState.False, TriState.True)
        Else
            lbl_Tot_Bales.Text = ""
        End If

        If Val(Lbl_Tot_Mtr_Weight.Text) > 0 Then
            Lbl_Tot_Mtr_Weight.Text = FormatNumber(Val(Lbl_Tot_Mtr_Weight.Text), 3, TriState.False, TriState.False, TriState.True)
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If
    End Sub

    Private Sub Label_Value_Nil_Rest()
        lbl_Tot_Bales.Text = ""
        Lbl_Tot_Mtr_Weight.Text = ""
    End Sub
#End Region

#Region "DELETE CODE"
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        _FrmLoad = True
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).DeleteByRow()
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
        If _FORMMODE = "ADD" Then
            txtOfferNo.Text = txtEntryNo.Text
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
                txtOfferNo.Focus()
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
                    txtOfferNo.Focus()
                    txtOfferNo.Select()
                Else
                    Change_Grid_Data = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtOfferNo.Focus()
                    txtOfferNo.Select()
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
        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT  A.*, ")
            .Append(" FORMAT(A.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, ")
            .Append(" B.cityname AS DESPATCHNAME, ")
            .Append(" C.ITENNAME AS ITEMNAME, ")
            .Append(" D.ACCOUNTNAME, ")
            .Append(" E.TransportName, ")
            .Append(" F.AC_NAME AS ACOFNAME ")
            .Append(" ,G.Design_Name AS DESIGNNAME ")
            .Append(" ,H.RemarkName AS SHADENAME ")
            .Append(" FROM ")
            .Append("  TRNOFFER AS A")
            .Append("  Left Join MSTCITY  AS B ON A.DESPATCHCODE=B.CITYCODE ")
            .Append("  Left JOIN MstMasterAccount AS D  ON A.ACCOUNTCODE=D.ACCOUNTCODE ")
            .Append("  LEFT JOIN MSTTRANSPORT AS E  ON A.TRANSPORTCODE=E.ID  ")
            .Append("  Left Join Mst_Acof_Supply AS F  ON A.ACOFCODE=F.ID ")
            .Append("  LEFT JOIN MstFabricItem AS C  ON A.ITEMCODE=C.ID  ")
            .Append("  Left Join Mst_Fabric_Design AS G ON A.DESIGNCODE=G.Design_code ")
            .Append("  Left Join MstRemark AS H ON A.SHADECODE=H.RemarkCode ")
            .Append(" WHERE 1=1 ")
            .Append(" And A.BOOKVNO='" & strKeyID & "'")
            .Append(" ORDER BY A.SRNO ")
        End With

        Return strQuery.ToString
    End Function
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)
        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy

        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)


        'txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        txtPartyName.Text = tblTmp.Rows(0)("ACCOUNTNAME").ToString
        txtPartyCode.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        txtDespatch_code.Text = tblTmp.Rows(0)("DESPATCHCODE").ToString
        txtDespatchName.Text = tblTmp.Rows(0)("DESPATCHNAME").ToString
        txtTr_code.Text = tblTmp.Rows(0)("TRANSPORTCODE").ToString
        txtTransportName.Text = tblTmp.Rows(0)("TRANSPORTNAME").ToString
        txtOfferDate.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        txtAccoff.Text = tblTmp.Rows(0)("ACOFNAME").ToString
        txtAcOfCode.Text = tblTmp.Rows(0)("ACOFCODE").ToString

        Generate_Date_For_DataBase(txtOfferDate)

        Lbl_Tot_Mtr_Weight.Text = tblTmp.Compute("SUM(MTR_WEIGHT)", "").ToString
        'lbl_Tot_Bales.Text = tblTmp.Compute("SUM(PCS_BALES)", "").ToString

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


        Total_Upto_All_Grid_All_Row()
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

#Region "Txt Book Name Events Code "
    Private Sub txtBookName_Validated()
        If _FrmLoad = True Then Exit Sub

        If txtBookCode.Text = "" Or _BookCode = "" Then

            Exit Sub
        Else
            Dim TmpTbl As New DataTable


            Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)


            Dim Str_Qry As String = obj_Party_Selection.EntryData_General_Offer_txtBookName_Validated(_BookCode)
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
                txtOfferDate.Text = ObjCls_General.GetTodayDate_British
                Generate_Date_For_DataBase(txtOfferDate)
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
                    Generate_Date_For_DataBase(txtOfferDate)
                    txtEntryNo.Focus()
                    txtEntryNo.Select()
                End If
            ElseIf _FORMMODE = "VIEW" Then
                If Last_Entry_No = 0 Then
                    MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    txtEntryNo.Focus()
                    txtEntryNo.Select()
                Else
                    View_Record()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Offer No Txt Box Events "
    Private Sub txtOfferNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfferNo.Validated
        If _FrmLoad = True Then Exit Sub

        _BookVNo = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
        Dim StrQryChl As String = ""

        sqL = "select count(bookvno) as tbkvno from trnoffer where OFFERNO='" & txtOfferNo.Text & "' AND  BOOKVNO<> '" & _BookVNo & "' AND BOOKCODE='" & _BookCode & "' "
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            StrQryChl = DefaltSoftTable.Rows(0).Item(0)
        End If

        If Val((StrQryChl)) > 0 Then
            MsgBox("Offer No. Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtOfferNo.Select()
            txtOfferNo.Focus()
        End If
    End Sub
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
    Private Sub grditem_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GrdItem.KeyPress
        If _FrmLoad = True Then Exit Sub
        GrdItem.ActiveCell.BackColor = Color.Transparent
        Dim KeyTyped As String = e.KeyChar
        Dim Col_Text As String = GrdItem.ActiveCell.Text
    End Sub
    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = "0000-000001008"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000003"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "NO"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "PCS"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("loomtype") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("loomtype") + 1).Text = "PCS"
        Dim PartyOfferBookvno As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AgentOfferNo") + 1).Text
        If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) = 0 Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = "1.00"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = txtPartyName.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = txtPartyCode.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text = txtAccoff.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text = txtAcOfCode.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text = txtDespatchName.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text = txtDespatch_code.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text = txtTransportName.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = txtTr_code.Text

        If _ActivatedColName = "CUTNAME" Then
        ElseIf _ActivatedColName = "PARTYOFFERNO" Then
            If e.KeyCode = Keys.Enter Then
                If PartyOfferBookvno = "" AndAlso _BookCode = "0001-000000869" Then
                    Dim _TmpOfferTbl As New DataTable
                    Dim _FilterBookvno As String = " AND A.BOOKVNO <> '" & _BookVNo & "' "
                    _TmpOfferTbl = _GetPendingOffer(_FilterBookvno)
                    _GetPendingOfferGridSetting(_TmpOfferTbl)

                    Dim searchValue As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PARTYOFFERNO") + 1).Text.ToString
                    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridView4
                    If searchValue = "" Then Exit Sub
                    ' ===== Row Loop & Find Matching Row =====
                    For i As Integer = 0 To view.RowCount - 1
                        Dim cellValue As String = Convert.ToString(view.GetRowCellValue(i, "OfferNo")) ' <-- Column Name Change kare
                        If cellValue IsNot Nothing AndAlso cellValue.ToUpper() = searchValue.ToUpper() Then
                            ' Row Focus Set
                            view.FocusedRowHandle = i
                            ' Row Select
                            view.SelectRow(i)
                            ' Row ko visible kare
                            view.MakeRowVisible(i)
                            Exit For
                        End If
                    Next
                End If
            ElseIf e.KeyCode = Keys.Delete Then
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AgentOfferNo") + 1).Text = ""
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PARTYOFFERNO") + 1).Text = ""
            End If
        ElseIf _ActivatedColName = "ACCOUNTNAME" Then
            If e.KeyCode = Keys.Enter AndAlso (_BarcodeCoumn = "N" Or _OrderColumn = "N") Then
                Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text
                obj_Party_Selection.Invoice_Party_Selection()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                    Dim _Accountcode As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text
                    _GetMasterData(_Accountcode)
                End If
            End If
        ElseIf _ActivatedColName = "ACOFNAME" Then
            If e.KeyCode = Keys.Enter AndAlso (_BarcodeCoumn = "N" Or _OrderColumn = "N") Then
                Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text
                obj_Party_Selection.SINGLE_ACC_OF_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                End If
            End If
        ElseIf _ActivatedColName = "DESPATCHNAME" Then
            If e.KeyCode = Keys.Enter AndAlso (_BarcodeCoumn = "N" Or _OrderColumn = "N") Then
                Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text
                obj_Party_Selection.SINGLE_City_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                End If
            End If
        ElseIf _ActivatedColName = "TRANSPORTNAME" Then
            If e.KeyCode = Keys.Enter AndAlso (_BarcodeCoumn = "N" Or _OrderColumn = "N") Then
                Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text
                obj_Party_Selection.SINGLE_City_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                End If
            End If
        ElseIf _ActivatedColName = "PYMTDAYS" Then
            If e.KeyCode = Keys.Enter AndAlso _BookCode = "0001-000000869" Then
                If _OrderColumn = "N" Then
                    Dim _FilterBArcode As String = ""
                    If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PYMTDAYS") + 1).Text > "" Then
                        _FilterBArcode = " AND a.PymtDays ='" & GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PYMTDAYS") + 1).Text & "'"
                    End If
                    _GetBarcodeWiseSample("", _FilterBArcode)
                Else
                    If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PARTYOFFERNO") + 1).Text > "" Then
                        Dim _StkTbl As New DataTable
                        Dim _BARCODE As Integer = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PYMTDAYS") + 1).Text)
                        Dim _TypeCode As String = ""

                        If _OrderColumn = "Y" Then
                            _TypeCode = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ItemCode") + 1).Text
                            _TypeCode = " and a.ItemCode='" & _TypeCode & "'"
                        Else
                            _TypeCode = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text
                            _TypeCode = " and a.shadecode='" & _TypeCode & "'"
                        End If
                        _StkTbl = _GetBarcodeWiseSample("", _TypeCode)
                    Else
                        MsgBox("Select Order No", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "ITEMNAME" Then
            If e.KeyCode = Keys.Enter AndAlso _BarcodeCoumn = "N" Then
                Dim SelectedaccountCode As New List(Of String)
                Dim Str_In_Store_Item As String = ""
                Dim _LoadQuery = NewSelectionList.MstFabricItem_Select("")
                Dim ExtracolumnsToHide = {""}
                SelectedaccountCode.Add(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text)
                Dim selectedList = MultyAccountSelectionForm(_LoadQuery, GetType(Fabric_Item_Master_Frm), "", "MULTY", SelectedaccountCode, ExtracolumnsToHide)
                Dim ROWNO As Integer = GrdItem.ActiveCell.Row
                Dim SHADENAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text
                Dim ShadeCode As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text
                Dim _ACCOUNTNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text
                Dim _ACCOUNTCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text
                Dim ACOFNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text
                Dim ACOFCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text
                Dim DESPATCHNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text
                Dim DESPATCHCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text
                Dim TRANSPORTNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text
                Dim TransportCode As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text
                If selectedList IsNot Nothing Then
                    For Each row As Dictionary(Of String, Object) In selectedList
                        Dim accountCode As String = ""
                        Dim ItemName As String = ""
                        If row.ContainsKey("ACCOUNTCODE") Then
                            accountCode = Convert.ToString(row("ACCOUNTCODE"))
                        End If
                        If row.ContainsKey("ItemName") Then
                            ItemName = Convert.ToString(row("ItemName"))
                        End If
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = ItemName
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = accountCode
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = SHADENAME
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text = ShadeCode
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = _ACCOUNTNAME
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = _ACCOUNTCODE
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = ROWNO
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text = ACOFNAME
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text = ACOFCODE
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text = DESPATCHNAME
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text = DESPATCHCODE
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text = TRANSPORTNAME
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = TransportCode
                        GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = "1.00"
                        _getRateList(ROWNO, _ACCOUNTCODE, accountCode)
                        ROWNO += 1
                        GrdItem.Rows = GrdItem.Rows + 1
                    Next
                    Total_Upto_All_Grid_All_Row()
                End If
            End If
            'End If
        ElseIf _ActivatedColName = "DESIGNNAME" Then
            If e.KeyCode = Keys.Enter AndAlso (_BarcodeCoumn = "N" Or _OrderColumn = "N") Then
                If Change_Grid_Data = True Then
                    Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text
                    If PartyOfferBookvno > "" AndAlso _BookCode = "0001-000000869" Then
                        _strQuery = New StringBuilder
                        With _strQuery
                            .Append(" SELECT ")
                            .Append(" I.Design_Name AS [Design Name], ")
                            .Append(" '' as Remark, ")
                            .Append(" a.DesignCode,")
                            .Append(" a.DesignCode,")
                            .Append(" a.DesignCode")
                            .Append(" FROM TRNOFFER A ,Mst_Fabric_Design I ")
                            .Append(" WHERE 1=1 ")
                            .Append(" AND A.DesignCode=I.Design_code ")
                            .Append(" AND A.CLEAR<>'YES' ")
                            .Append(" AND A.BOOKVNO='" & PartyOfferBookvno & "'")
                            .Append(" AND A.ITEMCODE='" & GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text & "'")
                            .Append(" GROUP BY I.Design_Name,A.DesignCode ")
                            .Append(" ORDER BY I.Design_Name ")
                        End With
                        sqL = _strQuery.ToString
                        obj_Party_Selection.Single_List_Load_Data()
                    Else
                        obj_Party_Selection.SINGLE_DESIGN_SELECTION(" And A.Item_Code ='" & GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text & "'")
                    End If
                    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DesignCode") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "SHADENAME" Then
            If e.KeyCode = Keys.Enter AndAlso _BarcodeCoumn = "N" Then
                '    If Change_Grid_Data = True Then
                Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text
                obj_Party_Selection.SINGLE_Remark_SELECTION("SAMPLE ORDER")
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                End If
            End If
            'End If
        ElseIf _ActivatedColName = "CLEAR" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "NO"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "NO" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "YES"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "YES" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CLEAR") + 1).Text = "NO"
                End If
            End If
        ElseIf _ActivatedColName = "ITEMGROUPNAME" Then
        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "MTR_WEIGHT" Then
            If e.KeyCode = Keys.Enter Then
                Call Total_Upto_All_Grid_All_Row()
            End If
        ElseIf _ActivatedColName = "RATE_DIS_PER" Then
        ElseIf _ActivatedColName = "GROSS_RATE" Then
        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                    GrdItem.Rows = GrdItem.Rows + 1
                    Dim SHADENAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text
                    Dim ShadeCode As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text
                    Dim ACCOUNTNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text
                    Dim ACCOUNTCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text
                    Dim ACOFNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text
                    Dim ACOFCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text
                    Dim DESPATCHNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text
                    Dim DESPATCHCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text
                    Dim TRANSPORTNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text
                    Dim TransportCode As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text
                    'GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = SHADENAME
                    'GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text = ShadeCode
                    If GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = "" Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = ACCOUNTNAME
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = ACCOUNTCODE
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text = ACOFNAME
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text = ACOFCODE
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text = DESPATCHNAME
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text = DESPATCHCODE
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text = TRANSPORTNAME
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = TransportCode
                    End If
                End If
                Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
            End If
        End If
    End Sub


    Private Sub _getRateList(ByVal _RowNo As Integer, ByVal accountCode As String, ByVal ItemCode As String)
        sqL = "select GROUPCODE from MstMasterAccount WHERE ACCOUNTCODE='" & accountCode & "'"
        sql_connect_slect()
        Dim _CheckAcountType As String = ""
        If DefaltSoftTable.Rows.Count > 0 Then
            If DefaltSoftTable.Rows(0).Item("GROUPCODE").ToString = "0000-000000052" Then
                _CheckAcountType = "AGENT"
            Else
                _CheckAcountType = "PARTY"
            End If
        End If
        _strQuery = New StringBuilder()
        _strQuery.Append("SELECT * FROM TrnRateContract ")
        _strQuery.Append("WHERE ITEMCODE = '").Append(ItemCode).Append("' ")
        Select Case ITEM_RATE_BY.Trim().ToUpper()
            Case "GENERAL RATE LIST"
                _strQuery.Append("AND BOOKCODE = '0001-000000159' ")
            Case "AGENT RATE LIST"
                _strQuery.Append("AND BOOKCODE = '0001-000000161' AND ACCOUNTCODE = '").Append(accountCode).Append("' ")
            Case "PARTY RATE LIST"
                _strQuery.Append("AND BOOKCODE = '0001-000000160' AND ACCOUNTCODE = '").Append(accountCode).Append("' ")
            Case "RATE LIST"
                If _CheckAcountType = "AGENT" Then
                    _strQuery.Append("AND BOOKCODE = '0001-000000161' AND ACCOUNTCODE = '").Append(accountCode).Append("' ")
                Else
                    _strQuery.Append("AND BOOKCODE = '0001-000000160' AND ACCOUNTCODE = '").Append(accountCode).Append("' ")
                End If
        End Select
        _strQuery.Append("ORDER BY OFFERDATE DESC")
        sqL = _strQuery.ToString()
        sql_connect_slect()
        Dim _tmptbl As New DataTable
        _tmptbl = DefaltSoftTable.Copy
        If _tmptbl.Rows.Count > 0 Then
            Dim _Cuttype As String = "LUMP"
            Dim columnName As String = ""
            Dim _RateListRate As Double = 0
            Select Case _Cuttype.Trim().ToUpper()
                Case "THAN" : columnName = "THAN_RATE"
                Case "LUMP(SINGLE)" : columnName = "Process_Weight_Rate"
                Case "LUMP(MIX)" : columnName = "Process_Slab_Weight"
                Case "RIGHT CUT" : columnName = "RIGHT_CUT_RATE"
                Case "SAFFARI" : columnName = "Process_Net_Rate"
                Case "LUMP" : columnName = "LUMP_RATE"
                Case Else : columnName = "TL_CUT_RATE"
            End Select
            ' Safe conversion check: Row aur Column exist karne par value assign karein
            If _tmptbl IsNot Nothing AndAlso _tmptbl.Rows.Count > 0 AndAlso _tmptbl.Columns.Contains(columnName) Then
                Dim cellVal As Object = _tmptbl.Rows(0)(columnName)
                If IsDBNull(cellVal) OrElse cellVal Is Nothing Then
                    _RateListRate = "0"
                Else
                    _RateListRate = Val(cellVal.ToString()).ToString()
                End If
            Else
                _RateListRate = "0"
            End If
            If Val(GrdItem.Cell(_RowNo, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text) = 0 Then
                GrdItem.Cell(_RowNo, _DataTableGrid.Columns.IndexOf("GROSS_RATE") + 1).Text = _RateListRate
                GrdItem.Cell(_RowNo, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text = _RateListRate
            End If
        End If
    End Sub
    Private Sub _GetMasterData(ByVal _partyaccountcode As String)
        Dim strQuery As New StringBuilder()
        With strQuery
            .Append(" SELECT ")
            .Append(" A.AGENTCODE, ")
            .Append(" B.CITYCODE, ")
            .Append(" B.CITYNAME, ")
            .Append(" C.ACCOUNTNAME as agentname, ")
            .Append(" C.MOBILE  AS AgentMobile,")
            .Append(" D.TRANSPORTNAME, ")
            .Append(" A.TRANSPORTID AS TRANSPORTCODE ")
            .Append(" ,a.ADDRESS1 ")
            .Append(" ,a.ADDRESS2 ")
            .Append(" ,a.ADDRESS3 ")
            .Append(" ,a.MOBILE ")
            .Append(" ,a.OP3 as PartyBlackList ")
            .Append(" ,c.OP3 as AgentBlackList ")
            .Append(" ,B.CITYNAME + '-' + a.PINCOD  + '-' + E.StateName as CityStateName ")
            .Append(" FROM MstMasterAccount A ")
            .Append(" LEFT JOIN MSTCITY B ON A.CITYCODE = B.CITYCODE ")
            .Append(" LEFT JOIN MstMasterAccount C ON A.AGENTCODE = C.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTTRANSPORT D ON A.TRANSPORTID = D.ID ")
            .Append(" LEFT JOIN MstState E ON B.stateid = E.stateid ")
            .Append(" WHERE A.ACCOUNTCODE = '" & _partyaccountcode & "' ")
        End With
        sqL = strQuery.ToString()
        sql_connect_slect()
        _TmpDataTable = DefaltSoftTable.Copy
        If _TmpDataTable.Rows.Count > 0 Then
            If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("weavetypecode") + 1).Text = "" Then
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("weavetypecode") + 1).Text = _TmpDataTable(0)("ADDRESS1").ToString
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("loomtypecode") + 1).Text = _TmpDataTable(0)("ADDRESS2").ToString
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SELVCODE") + 1).Text = _TmpDataTable(0)("ADDRESS3").ToString
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SelvedgeName") + 1).Text = _TmpDataTable(0)("CityStateName").ToString
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNO") + 1).Text = _TmpDataTable(0)("MOBILE").ToString
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AGENTCODE") + 1).Text = _TmpDataTable(0)("agentname").ToString
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_DETAIL") + 1).Text = _TmpDataTable(0)("AgentMobile").ToString
            End If
        End If
        Dim _ROW As Integer = GrdItem.ActiveCell.Row
    End Sub
    Private Function _GetBarcodeWiseSample(ByVal Filter_Condition As String, ByVal _TypeCode As String)
        Dim _OfferBookno As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AgentOfferNo") + 1).Text
        Dim _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append("  A.ItemCode  ")
            .Append(" ,A.DesignCode  ")
            .Append(" ,A.ShadeCode  ")
            .Append(" FROM TRNOFFER AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKVNO='" & _OfferBookno & "' ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim whereClauseItem As String = ""
        If DefaltSoftTable.Rows.Count > 0 Then
            Dim itemCodes As String = String.Join(",", DefaltSoftTable.AsEnumerable().Select(Function(row) "'" & row.Field(Of String)("ItemCode") & "'"))
            Dim DesignCode As String = String.Join(",", DefaltSoftTable.AsEnumerable().Select(Function(row) "'" & row.Field(Of String)("DesignCode") & "'"))
            Dim ShadeCode As String = String.Join(",", DefaltSoftTable.AsEnumerable().Select(Function(row) "'" & row.Field(Of String)("ShadeCode") & "'"))
            whereClauseItem = " AND a.ItemCode IN (" & itemCodes & ")" & " AND a.DesignCode IN (" & DesignCode & ")" & " AND a.ShadeCode IN (" & ShadeCode & ")"
        End If
        Dim _StkTbl As New DataTable
        _StkTbl = _GetBarcodeSmapleStock(Filter_Condition, whereClauseItem, _TypeCode)
        GridView4.Columns.Clear()
        If _StkTbl.Rows.Count > 0 Then
            Dim columnNames As String() = {"SampleRecQty", "DespatchQty", "Balance"}
            For Each dr As DataRow In _StkTbl.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
            Next
            GridControl3.DataSource = _StkTbl.Copy
            Lbl_PendingViewType.Text = "Pending Stock"
            GridView4.Columns("SampleRecQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SampleRecQty", "{0}"))
            GridView4.Columns("DespatchQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DespatchQty", "{0}"))
            GridView4.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
            GridView4.Columns("ItemCode").Visible = False
            GridView4.Columns("DesignCode").Visible = False
            GridView4.Columns("ShadeCode").Visible = False
            Dim rowsToHide As New List(Of Integer)
            AddHandler GridView4.CustomRowFilter, Sub(sender, e)
                                                      e.Visible = True
                                                      e.Handled = False
                                                  End Sub
            GridView4.RefreshData()
            For J As Integer = 0 To GridView4.RowCount - 1
                Dim barcodeGV As String = GridView4.GetRowCellValue(J, "Barcode")?.ToString().Trim()
                Dim barcodeBalance As Double = GridView4.GetRowCellValue(J, "Balance")?.ToString().Trim()
                Dim GridQty As Double = 0
                If Not String.IsNullOrEmpty(barcodeGV) Then
                    For K As Integer = 1 To GrdItem.Rows - 1
                        Dim barcodeItem As String = GrdItem.Cell(K, _DataTableGrid.Columns.IndexOf("PymtDays") + 1).Text.Trim()
                        If Val(barcodeGV) = Val(barcodeItem) Then
                            GridQty += Val(GrdItem.Cell(K, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text.Trim())
                            Dim value As Double = barcodeBalance - GridQty
                            GridView4.SetRowCellValue(J, "DespatchQty", GridQty)
                            GridView4.SetRowCellValue(J, "Balance", value)
                            If value = 0 AndAlso value > 1 Then
                                rowsToHide.Add(J)
                            End If
                            'Exit For
                        End If
                    Next
                End If
            Next
            AddHandler GridView4.CustomRowFilter, Sub(sender, e)
                                                      If rowsToHide.Contains(e.ListSourceRow) Then
                                                          e.Visible = False
                                                          e.Handled = True
                                                      End If
                                                  End Sub
            GridView4.RefreshData()
            DevGridFitColumn(GridControl3, GridView4)
            PnlPendingOffer.Visible = True
            PnlPendingOffer.BringToFront()
            GridView4.Focus()
            GridView4.SelectAll()
        Else
            MsgBox("Stock Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            PnlPendingOffer.Visible = False
        End If
    End Function
    Public Function _GetBarcodeSmapleStock(ByVal Filter_Condition As String, ByVal whereClauseItem As String, ByVal _TypeCode As String)

        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append("  z.Barcode ")
            .Append(" ,A.ITENNAME AS ItemName ")
            .Append(" ,B.Design_Name AS Design ")
            .Append(" ,C.RemarkName as Shade ")
            .Append(" ,SUM(Z.SampleRecQty) AS SampleRecQty ")
            .Append(" ,SUM(Z.DespatchQty) AS DespatchQty ")
            .Append(" ,SUM(Z.SampleRecQty)-SUM(Z.DespatchQty) AS Balance ")
            .Append(" ,Z.ItemCode")
            .Append(" ,Z.DesignCode")
            .Append(" ,Z.ShadeCode")
            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append("  A.ItemCode  ")
            .Append(" ,A.DesignCode  ")
            .Append(" ,A.ShadeCode  ")
            .Append(" ,A.Mtr_Weight AS SampleRecQty ")
            .Append(" ,0.00 as DespatchQty ")
            .Append(" ,a.PymtDays as Barcode ")
            .Append(" FROM TRNOFFER AS A ")
            .Append(" WHERE 1=1 ")
            .Append(Filter_Condition)
            .Append(whereClauseItem)
            .Append(_TypeCode)
            .Append(" AND A.BookCode ='0001-000000867' ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.ItemCode  ")
            .Append(" ,A.DesignCode  ")
            .Append(" ,A.ShadeCode  ")
            .Append(" ,0.00 AS SampleRecQty ")
            .Append(" ,A.Mtr_Weight AS DespatchQty ")
            .Append(" ,a.PymtDays as Barcode ")
            .Append(" FROM TRNOFFER AS A ")
            .Append(" WHERE 1=1 ")
            .Append(Filter_Condition)
            .Append(whereClauseItem)
            .Append(_TypeCode)
            .Append(" AND A.BookCode ='0001-000000869' ")
            .Append(" ) AS Z ")
            .Append(" LEFT JOIN MstFabricItem AS A ON Z.ItemCode =A.ID  ")
            .Append(" LEFT JOIN Mst_Fabric_Design  AS B ON Z.DesignCode  =B.Design_code  ")
            .Append(" LEFT JOIN  MstRemark AS C ON Z.ShadeCode =C.RemarkCode  ")
            .Append(" WHERE 1=1 ")
            .Append(" GROUP BY ")
            .Append("  A.ITENNAME  ")
            .Append(" ,B.Design_Name  ")
            .Append(" ,C.RemarkName ")
            .Append(" ,Z.Barcode")
            .Append(" ,Z.ItemCode")
            .Append(" ,Z.DesignCode")
            .Append(" ,Z.ShadeCode")
            .Append(" HAVING SUM(Z.SampleRecQty)-SUM(Z.DespatchQty)>0 ")
        End With
        sqL = strQuery.ToString
        sql_connect_slect()
        Dim _StkTbl As New DataTable
        _StkTbl = DefaltSoftTable.Copy
        Return _StkTbl
    End Function
    Private Sub _GetPendingOfferGridSetting(ByVal _TmpOfferTbl As DataTable)
        GridView4.Columns.Clear()
        If _TmpOfferTbl.Rows.Count > 0 Then
            Dim columnNames As String() = {"BookingQty", "DespatchQty", "Balance"}
            Dim itemCodes As String = String.Join("','", _TmpOfferTbl.AsEnumerable().Select(Function(r) r("ITEMCODE").ToString()).Distinct())
            _strQuery = New StringBuilder()
            _strQuery.Append(" SELECT ITEMCODE, LUMP_RATE ")
            _strQuery.Append(" FROM TrnRateContract ")
            _strQuery.Append(" WHERE BOOKCODE='0001-000000159' ")
            _strQuery.Append(" AND ITEMCODE IN ('" & itemCodes & "') ")
            _strQuery.Append(" ORDER BY OFFERDATE DESC ")
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim rateTable As DataTable = DefaltSoftTable.Copy()
            Dim rateDict = rateTable.AsEnumerable().GroupBy(Function(r) r("ITEMCODE").ToString()).ToDictionary(Function(g) g.Key, Function(g) g.First()("LUMP_RATE").ToString())
            For Each dr As DataRow In _TmpOfferTbl.Rows
                Dim itemCode As String = dr("ITEMCODE").ToString()
                If rateDict.ContainsKey(itemCode) Then
                    dr("Rate") = rateDict(itemCode)
                End If
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
            Next
            GridControl3.DataSource = _TmpOfferTbl.Copy
            Lbl_PendingViewType.Text = "Pending Offer"
            Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl1.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            repositoryCheckEdit1.ValueChecked = "True"
            repositoryCheckEdit1.ValueUnchecked = "False"
            GridView4.Columns("TickMark").ColumnEdit = repositoryCheckEdit1
            GridView4.Columns("TickMark").Width = 40
            GridView4.Columns("BookingQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BookingQty", "{0}"))
            GridView4.Columns("DespatchQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DespatchQty", "{0}"))
            GridView4.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
            'AlignGroupSummaryInGroupRow(GridControl3, GridView4)
            GridView4.Columns("BOOKVNO").Visible = False
            GridView4.Columns("AccountCode").Visible = False
            GridView4.Columns("ItemCode").Visible = False
            GridView4.Columns("DesignCode").Visible = False
            GridView4.Columns("ShadeCode").Visible = False
            GridView4.Columns("DESPATCHCODE").Visible = False
            GridView4.Columns("TRANSPORTCODE").Visible = False
            GridView4.Columns("ACOFCODE").Visible = False
            Dim rowsToHide As New List(Of Integer)
            AddHandler GridView4.CustomRowFilter, Sub(sender, e)
                                                      e.Visible = True
                                                      e.Handled = False
                                                  End Sub
            GridView4.RefreshData()
            For J As Integer = 0 To GridView4.RowCount - 1
                Dim barcodeGV As String = GridView4.GetRowCellValue(J, "OfferNo")?.ToString().Trim()
                Dim barcodeBalance As Double = GridView4.GetRowCellValue(J, "Balance")?.ToString().Trim()
                Dim TypeCode As String = GridView4.GetRowCellValue(J, "ShadeCode")?.ToString().Trim()
                Dim ItemCode As String = GridView4.GetRowCellValue(J, "ItemCode")?.ToString().Trim()
                Dim GridQty As Double = 0
                If Not String.IsNullOrEmpty(barcodeGV) Then
                    For K As Integer = 1 To GrdItem.Rows - 1
                        Dim barcodeItem As String = GrdItem.Cell(K, _DataTableGrid.Columns.IndexOf("PARTYOFFERNO") + 1).Text.Trim()
                        Dim GrdTypeCode As String = GrdItem.Cell(K, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text.Trim()
                        Dim GrdItemCode As String = GrdItem.Cell(K, _DataTableGrid.Columns.IndexOf("ItemCode") + 1).Text.Trim()
                        If Val(barcodeGV) = Val(barcodeItem) AndAlso GrdTypeCode = TypeCode AndAlso ItemCode = GrdItemCode Then
                            GridQty += Val(GrdItem.Cell(K, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text.Trim())
                            Dim value As Double = barcodeBalance - GridQty
                            GridView4.SetRowCellValue(J, "DespatchQty", GridQty)
                            GridView4.SetRowCellValue(J, "Balance", value)
                            If value = 0 Then
                                rowsToHide.Add(J)
                            End If
                            'Exit For
                        End If
                    Next
                End If
            Next
            AddHandler GridView4.CustomRowFilter, Sub(sender, e)
                                                      If rowsToHide.Contains(e.ListSourceRow) Then
                                                          e.Visible = False
                                                          e.Handled = True
                                                      End If
                                                  End Sub
            GridView4.RefreshData()
            PnlPendingOffer.Visible = True
            PnlPendingOffer.BringToFront()
            DevGridFitColumn(GridControl3, GridView4)
            GridView4.Focus()
        Else
            PnlPendingOffer.Visible = False
        End If
    End Sub
    Public Function _GetPendingOffer(ByVal _BookvnoFilter As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" 'False' as TickMark ")
            .Append(" ,Z.BOOKVNO ")
            .Append(" ,Z.AccountCode ")
            .Append(" ,Z.ItemCode ")
            .Append(" ,Z.DesignCode ")
            .Append(" ,Z.ShadeCode ")
            .Append(" ,E.OfferNo ")
            .Append(" ,E.OfferDate ")
            .Append(" ,D.ACCOUNTNAME AS PartyName ")
            .Append(" ,A.ITENNAME AS ItemName ")
            .Append(" ,B.Design_Name AS Design ")
            .Append(" ,C.RemarkName AS Shade ")
            .Append(" ,E.HEADERREMARK AS Remark ")
            .Append(" ,SUM(Z.BookQty) AS BookingQty ")
            .Append(" ,SUM(Z.DespatchQty) AS DespatchQty ")
            .Append(" ,SUM(Z.BookQty)-SUM(Z.DespatchQty) AS Balance ")
            .Append(" ,F.cityname AS DespatchName")
            .Append(" ,G.TransportName ")
            .Append(" ,H.AC_NAME  as AcOff ")
            .Append(" ,E.DESPATCHCODE")
            .Append(" ,E.TRANSPORTCODE ")
            .Append(" ,E.ACOFCODE")
            .Append(" ,E.Address_1 ")
            .Append(" ,E.Address_2 ")
            .Append(" ,E.Address_3 ")
            .Append(" ,E.AddressCity ")
            .Append(" ,E.Mobile ")
            .Append(" ,E.AgentName ")
            .Append(" ,E.AgentMobile ")
            .Append(" ,0.00 as Rate ")
            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append(" A.BOOKVNO ")
            .Append(" ,a.AccountCode ")
            .Append(" ,A.ItemCode ")
            .Append(" ,A.DesignCode ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,A.Mtr_Weight AS BookQty ")
            .Append(" ,0.00 as DespatchQty ")
            .Append(" FROM TRNOFFER AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" and a.clear ='NO' ")
            .Append(" AND A.BookCode ='0001-000000868' ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.AgentOfferNo AS BOOKVNO ")
            .Append(" ,a.AccountCode ")
            .Append(" ,A.ItemCode ")
            .Append(" ,A.DesignCode ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,0.00 AS BookQty ")
            .Append(" ,A.Mtr_Weight AS DespatchQty ")
            .Append(" FROM TRNOFFER AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BookCode ='0001-000000869' ")
            .Append(_BookvnoFilter)
            .Append(" ) AS Z ")
            .Append(" LEFT JOIN MstFabricItem AS A ON Z.ItemCode =A.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design  AS B ON Z.DesignCode  =B.Design_code ")
            .Append(" LEFT JOIN MstRemark AS C ON Z.ShadeCode =C.RemarkCode ")
            .Append(" LEFT JOIN MstMasterAccount AS D ON Z.AccountCode =D.ACCOUNTCODE ")
            .Append(" LEFT JOIN (SELECT BookVno,OfferNo,OfferDate,DESPATCHCODE,TRANSPORTCODE,ACOFCODE   ")
            .Append(" ,weavetypecode as Address_1 ")
            .Append(" ,loomtypecode  as Address_2 ")
            .Append(" ,SELVCODE as Address_3 ")
            .Append(" ,SelvedgeName as AddressCity ")
            .Append(" ,HEADERREMARK ")
            .Append(" ,DESIGNNO as Mobile ")
            .Append(" ,AGENTCODE as AgentName ")
            .Append(" ,YARN_DETAIL as AgentMobile ")
            .Append(" FROM TRNOFFER  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND BookCode ='0001-000000868' ")
            .Append(" GROUP BY  ")
            .Append(" BookVno,OfferNo,OfferDate,DESPATCHCODE,TRANSPORTCODE,ACOFCODE  ")
            .Append(" ,weavetypecode ")
            .Append(" ,loomtypecode ")
            .Append(" ,SELVCODE ")
            .Append(" ,DESIGNNO ")
            .Append(" ,SelvedgeName ")
            .Append(" ,HEADERREMARK ")
            .Append(" ,AGENTCODE ")
            .Append(" ,YARN_DETAIL ")
            .Append(" ) AS E ON Z.BookVno =E.BookVno ")
            .Append(" Left Join MSTCITY  AS F ON E.DESPATCHCODE=F.CITYCODE ")
            .Append(" LEFT JOIN MSTTRANSPORT AS G  ON E.TRANSPORTCODE=G.ID  ")
            .Append(" Left Join Mst_Acof_Supply AS H  ON E.ACOFCODE=H.ID ")
            .Append(" GROUP BY ")
            .Append(" A.ITENNAME ")
            .Append(" ,B.Design_Name ")
            .Append(" ,C.RemarkName ")
            .Append(" ,Z.AccountCode ")
            .Append(" ,Z.ItemCode ")
            .Append(" ,Z.DesignCode ")
            .Append(" ,Z.ShadeCode ")
            .Append(" ,D.ACCOUNTNAME ")
            .Append(" ,Z.BOOKVNO ")
            .Append(" ,E.OfferNo ")
            .Append(" ,E.OfferDate ")
            .Append(" ,F.cityname")
            .Append(" ,G.TransportName ")
            .Append(" ,H.AC_NAME ")
            .Append(" ,E.DESPATCHCODE")
            .Append(" ,E.TRANSPORTCODE ")
            .Append(" ,E.ACOFCODE")
            .Append(" ,E.Address_1 ")
            .Append(" ,E.Address_2 ")
            .Append(" ,E.Address_3 ")
            .Append(" ,E.AddressCity ")
            .Append(" ,E.HEADERREMARK ")
            .Append(" ,E.Mobile ")
            .Append(" ,E.AgentName ")
            .Append(" ,E.AgentMobile ")
            .Append(" HAVING SUM(Z.BookQty)-SUM(Z.DespatchQty)>0 ")
            .Append(" ORDER BY  ")
            .Append(" Z.BOOKVNO ")
            .Append(" ,E.OfferDate ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _TmpOfferTbl As New DataTable
        _TmpOfferTbl = DefaltSoftTable.Copy
        Return _TmpOfferTbl

    End Function
    Private Sub GridControl3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl3.KeyDown
        If e.KeyCode = Keys.Escape Then PnlPendingOffer.Visible = False
        If Lbl_PendingViewType.Text = "Pending Offer" Then
            If e.KeyCode = Keys.Space Then
                If GridView4.GetFocusedRowCellValue("TickMark") = "" Then
                    GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "TickMark", "True")
                ElseIf GridView4.GetFocusedRowCellValue("TickMark") = "True" Then
                    GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "TickMark", "False")
                ElseIf GridView4.GetFocusedRowCellValue("TickMark") = "False" Then
                    GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "TickMark", "True")
                End If
                SendKeys.Send("{HOME}")
                SendKeys.Send("{DOWN}")
            ElseIf e.KeyCode = Keys.F11 Then
                For i As Int64 = 0 To GridView4.RowCount - 1
                    If GridView4.GetRowCellValue(i, "TickMark").ToString = True Then
                        GridView4.SetRowCellValue(i, "TickMark", "False")
                    ElseIf GridView4.GetRowCellValue(i, "TickMark").ToString = False Then
                        GridView4.SetRowCellValue(i, "TickMark", "True")
                    End If
                Next
            ElseIf e.KeyCode = Keys.F12 Then
                GridView4.ActiveFilter.Clear()
                _InsertStockRowInGrid()
                PnlPendingOffer.Visible = False
                GrdItem.Focus()
                GrdItem.Select()
            End If
        Else
            If e.KeyCode = Keys.Enter Then
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PymtDays") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Barcode").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ItemName").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ItemCode") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ItemCode").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Design").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DesignCode") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "DesignCode").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Shade").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ShadeCode").ToString()
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Mtr_Weight") + 1).Text = 1
                If _OrderColumn = "N" Then
                    sqL = "SELECT * FROM MstFabricItem WHERE ID='" & GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "ItemCode").ToString() & "'"
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Gross_Rate") + 1).Text = DefaltSoftTable.Rows(0).Item("LUMPRATE")
                    End If
                End If
                PnlPendingOffer.Visible = False
                GrdItem.Focus()
                Total_Upto_All_Grid_All_Row()
                If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                    GrdItem.Rows = GrdItem.Rows + 1
                    Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                End If
                If _OrderColumn <> "N" Then
                    SendKeys.Send("{HOME}")
                    SendKeys.Send("{DOWN}")
                    SendKeys.Send("{RIGHT}")
                End If
            End If
        End If
    End Sub
    Private Sub _InsertStockRowInGrid()
        Dim ROWNO As Integer = GrdItem.ActiveCell.Row
        For i As Int64 = 0 To GridView4.RowCount - 1
            If GridView4.GetRowCellValue(i, "TickMark").ToString = True Then
                GrdItem.Rows = GrdItem.Rows + 1
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("AgentOfferNo") + 1).Text = GridView4.GetRowCellValue(i, "BOOKVNO").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("PARTYOFFERNO") + 1).Text = GridView4.GetRowCellValue(i, "OfferNo").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = GridView4.GetRowCellValue(i, "PartyName").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = GridView4.GetRowCellValue(i, "AccountCode").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = GridView4.GetRowCellValue(i, "ItemName").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ItemCode") + 1).Text = GridView4.GetRowCellValue(i, "ItemCode").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text = GridView4.GetRowCellValue(i, "Design").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DesignCode") + 1).Text = GridView4.GetRowCellValue(i, "DesignCode").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = GridView4.GetRowCellValue(i, "Shade").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ShadeCode") + 1).Text = GridView4.GetRowCellValue(i, "ShadeCode").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ROWREMARK") + 1).Text = GridView4.GetRowCellValue(i, "Remark").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DESPATCHNAME") + 1).Text = GridView4.GetRowCellValue(i, "DespatchName").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DESPATCHCODE") + 1).Text = GridView4.GetRowCellValue(i, "DESPATCHCODE").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACOFNAME") + 1).Text = GridView4.GetRowCellValue(i, "AcOff").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("ACOFCODE") + 1).Text = GridView4.GetRowCellValue(i, "ACOFCODE").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("TRANSPORTNAME") + 1).Text = GridView4.GetRowCellValue(i, "TransportName").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = GridView4.GetRowCellValue(i, "TRANSPORTCODE").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("weavetypecode") + 1).Text = GridView4.GetRowCellValue(i, "Address_1").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("loomtypecode") + 1).Text = GridView4.GetRowCellValue(i, "Address_2").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("SELVCODE") + 1).Text = GridView4.GetRowCellValue(i, "Address_3").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("SelvedgeName") + 1).Text = GridView4.GetRowCellValue(i, "AddressCity").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("DESIGNNO") + 1).Text = GridView4.GetRowCellValue(i, "Mobile").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("Gross_Rate") + 1).Text = GridView4.GetRowCellValue(i, "Rate").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("AGENTCODE") + 1).Text = GridView4.GetRowCellValue(i, "AgentName").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("YARN_DETAIL") + 1).Text = GridView4.GetRowCellValue(i, "AgentMobile").ToString()
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = ROWNO
                GrdItem.Cell(ROWNO, _DataTableGrid.Columns.IndexOf("Mtr_Weight") + 1).Text = 1.0
                ROWNO = ROWNO + 1
            End If
        Next
        Total_Upto_All_Grid_All_Row()
        PnlPendingOffer.Visible = False
        GrdItem.Focus()
    End Sub
    Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If
    End Sub
#End Region

#Region "Save Code "
    Private Function GetInvoiceDetailBarcode()
        Dim NXT_OFFERENTRYNO As Int64 = 1
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 isnull(PymtDays,0)  As MaxBarcode FROM TrnOffer as A ORDER BY PymtDays DESC ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            NXT_OFFERENTRYNO = Val(DefaltSoftTable.Rows(0).Item("MaxBarcode")) + 1
        End If
        Return NXT_OFFERENTRYNO
    End Function
    Private Sub SaveRecord()
        Total_Upto_All_Grid_All_Row()
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
            Dim Str_Qry As String = obj_Party_Selection.EntryData_General_Offer_txtBookName_Validated(_BookCode)
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
        Call Fill_Grid_Records_Into_DataTables()
        Dim _LastID As Integer = -1
        Try
            _LastID = SAVE_INTO_DATABASE_SQL()
            Old_Date = txtOfferDate.Text
            Call Label_Value_Nil_Rest()
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            If ALLOW_PRINT_YES_NO = "YES" Then
                If MsgBox("Print Invoice", MsgBoxStyle.YesNo + IIf((defalt_button_PRINT_YES_NO) = "YES", MsgBoxStyle.DefaultButton1, MsgBoxStyle.DefaultButton2) + MsgBoxStyle.Question, "Soft-Tex PRO") = MsgBoxResult.Yes Then
                    Dim inputValue As String = InputBox("Enter No Of Copy Print", "No Of Copy Print", "1", 350, 350)
                    If Not String.IsNullOrWhiteSpace(inputValue) Then
                        Try
                            _DirectPrintNoCopy = CInt(inputValue)
                            Offer_Printing._BOOKCODE.Text = _BookCode ' BOOK CODE
                            Offer_Printing.BOOKCATEGORY.Text = "OFFER"
                            Offer_Printing.SelectionButton = "Entry No. Wise"
                            Offer_Printing.Date_frm.Text = txtEntryNo.Text  ' ENTRY NO
                            Offer_Printing.Date_to.Text = txtEntryNo.Text   ' ENTRY NO
                            Offer_Printing.txt_Stationary_Type.Text = "PLAIN" ' PRINT FILE SELECT
                            RUN_TIME_PRINT = "DIRECT_PRINT"
                            sqL = "SELECT * FROM MstBook WHERE BookCode='" & _BookCode & "'"
                            sql_connect_slect()
                            If DefaltSoftTable.Rows.Count > 0 Then
                                Dim _PrintDefaltDetailSummary = DefaltSoftTable.Rows(0).Item("OP65").ToString
                                If _PrintDefaltDetailSummary = "SUMMARY" Then
                                    Offer_Printing.txt_PrnAllSundry.Text = "YES"
                                Else
                                    Offer_Printing.txt_PrnAllSundry.Text = "NO"
                                End If
                            End If
                            Offer_Printing.OK_BUTTON_CODE()
                        Catch ex As Exception
                            MessageBox.Show("Invalid input. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If
            End If
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
        Dim NXT_OFFERENTRYNO As Int64 = 1
        NXT_OFFERENTRYNO = GetInvoiceDetailBarcode()
        _DataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdItem.Rows - 1
            If _BarcodeCoumn = "Y" Then
                If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text <> "" AndAlso Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) > 0 AndAlso Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PymtDays") + 1).Text) > 0 Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Term1") + 1).Text = txtTerm1.Text
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Term2") + 1).Text = txtTerm2.Text
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Term3") + 1).Text = txtTerm3.Text
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Term4") + 1).Text = txtTerm4.Text
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
            Else
                If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text <> "" AndAlso Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) > 0 Then
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
        strFilterString = "MTR_WEIGHT>0"
        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("OfferNo,")
            .Append("OfferDate,")
            .Append("HeaderRemark,")
            .Append("Term1,")
            .Append("Term2,")
            .Append("Term3,")
            .Append("Term4")
        End With
        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtEntryNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(_BookCode & ",")
            .Append(txtOfferNo.Text & ",")
            .Append(txtOfferDate.Date_for_Database & ",")
            .Append(txtHeader_Remark.Text & ",")
            .Append(txtTerm1.Text.ToString & ",")
            .Append(txtTerm2.Text.ToString & ",")
            .Append(txtTerm3.Text.ToString & ",")
            .Append(txtTerm4.Text.ToString)
        End With
        QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid
    End Function
    Private Function SAVE_INTO_DATABASE_SQL() As Integer
        Dim strQuery As String = ""
        Dim I As Integer = 0

        Try
            '---------------- Delete Previous Bill Sundry ----------------------------------'
            strQuery = "DELETE FROM TRNOFFER WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "'"
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
    Private Sub btn_View_Ok_Click_1(sender As Object, e As EventArgs) Handles btn_View_Ok.Click
        View_Record()
    End Sub
    Private Sub View_Record()
        Try
            Generate_Date_For_DataBase(txt_From)
            Generate_Date_For_DataBase(txt_To)
            Dim View_Filter_Condition As String = ""
            Dim View_Order_By As String = ""
            View_Filter_Condition = " AND A.BOOKCODE='" & _BookCode & "' AND A.OFFERDATE>='" & txt_From.Date_for_Database & "' AND A.OFFERDATE<='" & txt_To.Date_for_Database & "' "
            View_Order_By = " ORDER BY A.OFFERDATE,A.ENTRYNO "
            Dim Offer_Field_String As String = ""
            If Txt_EntryType.Text = "DETAIL" Then
                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" SELECT ")
                    .Append(" A.BookVno, ")
                    .Append(" A.ENTRYNO as [Entry No], ")
                    .Append(" A.PartyOfferNo as [Party Offer No], ")
                    '.Append(" A.OfferNo as [Dis. No], ")
                    .Append(" A.OfferDate AS DisDate, ")
                    .Append(" B.accountname as [Party Name], ")
                    .Append(" E.TransportName as [Transport], ")
                    .Append(" C.accountname as [Agent Name], ")
                    .Append(" G.AC_NAME as [A/c Of Name], ")
                    .Append(" A.HeaderRemark as [Remark], ")
                    .Append(" A.PymtDays AS Barcode, ")
                    .Append(" A.SRNO as [Sno], ")
                    .Append(" F.ITENNAME as [Item Name], ")
                    .Append(" H.Design_Name AS Design, ")
                    .Append(" I.RemarkName AS Type, ")
                    .Append(" A.Mtr_Weight as Pcs, ")
                    .Append(" A.clear as [Clear] ")
                    .Append(" ,A.ROWREMARK as DetailRemark ")
                    .Append(" FROM TRNOFFER AS A ")
                    .Append(" Left Join MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
                    .Append(" LEFT JOIN MstMasterAccount AS C ON B.AGENTCODE=C.ACCOUNTCODE  ")
                    .Append(" Left Join MSTTRANSPORT AS E ON A.TRANSPORTCODE=E.ID  ")
                    .Append(" Left Join Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID ")
                    .Append(" LEFT JOIN MstFabricItem AS F  ON A.ITEMCODE=F.ID  ")
                    .Append(" Left Join Mst_Fabric_Design AS H ON A.DESIGNCODE=H.Design_code ")
                    .Append(" Left Join MstRemark AS I ON A.SHADECODE=I.RemarkCode ")
                    .Append(" WHERE 1=1 ")
                    .Append(View_Filter_Condition)
                    .Append(" ORDER BY A.OFFERDATE,A.ENTRYNO,A.SRNO   ")
                End With
            Else
                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" SELECT ")
                    .Append(" A.BookVno, ")
                    .Append(" A.ENTRYNO as [Entry No], ")
                    '.Append(" A.OfferNo as [Dis No], ")
                    .Append(" A.PartyOfferNo as [Party Offer No], ")
                    .Append(" A.OfferDate AS DisDate, ")
                    .Append(" B.accountname as [Party Name], ")
                    .Append(" E.TransportName as [Transport], ")
                    .Append(" C.accountname as [Agent Name], ")
                    .Append(" G.AC_NAME as [A/c Of Name], ")
                    .Append(" A.HeaderRemark as [Remark], ")
                    .Append(" SUM(A.Mtr_Weight) as Pcs ")
                    .Append(" ,A.ROWREMARK as DetailRemark ")
                    .Append(" FROM TRNOFFER AS A ")
                    .Append(" Left Join MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
                    .Append(" LEFT JOIN MstMasterAccount AS C ON B.AGENTCODE=C.ACCOUNTCODE  ")
                    .Append(" Left Join MSTTRANSPORT AS E ON A.TRANSPORTCODE=E.ID  ")
                    .Append(" Left Join Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID ")
                    .Append(" WHERE 1=1 ")
                    .Append(View_Filter_Condition)
                    .Append(" GROUP BY ")
                    .Append(" A.BookVno, ")
                    .Append(" A.ENTRYNO, ")
                    .Append(" A.OfferNo , ")
                    .Append(" A.OfferDate, ")
                    .Append(" B.accountname, ")
                    .Append(" E.TransportName, ")
                    .Append(" C.accountname, ")
                    .Append(" G.AC_NAME, ")
                    .Append(" A.PartyOfferNo, ")
                    .Append(" A.ROWREMARK, ")
                    .Append(" A.HeaderRemark ")
                    .Append(View_Order_By)
                End With
            End If
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim tblTmp As DataTable
            tblTmp = DefaltSoftTable.Copy
            FirstStage.Columns.Clear()
            If tblTmp.Rows.Count > 0 Then
                GridControl1.DataSource = tblTmp.Copy
                FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
                FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)
                FirstStage.GroupRowHeight = 30
                FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                FirstStage.Columns("Pcs").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("Pcs").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pcs", "{0}"))
                FirstStage.Columns("BookVno").Visible = False
                AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
                PNL_View.Visible = True
                FirstStage.BestFitColumns()
                FirstStage.Focus()
                PNL_View.BringToFront()
                GridControl1.BringToFront()
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        'gridView.Columns(CStr(("Bale No"))).Group()
        'Enable this option to move group footer summaries to group rows under corresponding column headers
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Pcs", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Pcs")})
        gridView.Appearance.GroupRow.BackColor = Color.LightGreen
    End Sub
    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Sample Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub
    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
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

    Private Sub Btn_Reports_Click(sender As Object, e As EventArgs)
        SampleOrderOrDespatchReports.ShowDialog()
    End Sub

#End Region
    Private Sub txtPartyOfferNo_KeyDown(sender As Object, e As KeyEventArgs)
        If txtOfferNo.Text.Trim = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            Offer_Validated()
        End If
    End Sub
    Private Sub Offer_Validated()
        _OfferSelection(txtOfferNo.Text.Trim, "")
        If Offer_Tbl.Rows.Count > 0 Then
            If Offer_Tbl(0)("CLEAR").ToString = "YES" Then
                MsgBox("It's A Clear Offer", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            End If
            txt_OfferBookVno.Text = Offer_Tbl(0)("BOOKVNO").ToString
        End If
    End Sub
    Public Function _OfferSelection(ByVal _OfferNo As String, ByVal _Accountcode As String)
        Dim Str_In_Offer_Book As String = " AND A.BOOKCODE IN " & Replace(Book_Row("OFFER_BOOK_CODE_FILTER_STRING").ToString, "#", "'")
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.OFFERNO , ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') as F_OFFERDATE , ")
            .Append(" D.ACCOUNTNAME, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" E.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.TRANSPORTCODE, ")
            .Append(" F.TRANSPORTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" A.DESPATCHCODE, ")
            .Append(" A.ACOFCODE, ")
            .Append(" H.AC_NAME AS ACOFNAME, ")
            .Append(" I.ITENNAME AS FABRIC_ITEMNAME, ")
            .Append(" I.ID AS ITEMCODE,A.CLEAR ")
            .Append(" ,A.CDON ")
            .Append(" ,A.OP6 ") 'PRINT COMP INFO
            .Append(" ,A.SHADECODE ")
            .Append(" ,A.HeaderRemark ")
            .Append(" ,A.DESIGNCODE ")
            .Append(" ,sum(A.Mtr_Weight) as Mtr_Weight ")
            .Append(" FROM TRNOFFER A,MstMasterAccount D,MSTFABRICITEM I, ")
            .Append(" MstMasterAccount E,MSTTRANSPORT F,MSTCITY G,Mst_Acof_Supply H ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ITEMCODE=I.ID ")
            .Append(" AND A.ACOFCODE=H.ID ")
            .Append(" AND A.DESPATCHCODE=G.CITYCODE ")
            .Append(" AND A.TRANSPORTCODE=F.ID ")
            .Append(" AND D.AGENTCODE=E.ACCOUNTCODE ")
            .Append(" AND A.ACCOUNTCODE=D.ACCOUNTCODE ")
            .Append(" AND A.CLEAR<>'YES' ")
            .Append(" AND  AND A.BOOKCODE='0001-000000868' ")
            .Append(_Accountcode)
            .Append(" AND A.OFFERNO='" & _OfferNo & "'")
            .Append(" GROUP BY A.BOOKVNO,A.OFFERNO,A.ENTRYNO,A.OFFERDATE,I.ITENNAME,I.ID, ")
            .Append(" D.ACCOUNTNAME,A.ACCOUNTCODE,E.ACCOUNTCODE ,E.ACCOUNTNAME,A.TRANSPORTCODE, ")
            .Append(" F.TRANSPORTNAME,G.CITYNAME,A.DESPATCHCODE,A.ACOFCODE,H.AC_NAME,A.CLEAR ")
            .Append(" ,A.CDON ")
            .Append(" ,A.OP6 ")
            .Append(" ,A.HeaderRemark ")
            .Append(" ,A.SHADECODE ")
            .Append(" ,A.DESIGNCODE ")
            .Append(" ORDER BY A.OFFERNO ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Offer_Tbl.Clear()
        Offer_Tbl = DefaltSoftTable.Copy
        Return Offer_Tbl
    End Function

    Private Sub txtPartyName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartyName.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub
        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space AndAlso (_BarcodeCoumn = "N" Or _OrderColumn = "N") Then
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccountvendorcode_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtPartyName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtPartyCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then txtPartyName.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtAccoff_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccoff.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_ACC_OF_SELECTION(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtAccoff.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtAcOfCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("A/C Of") Then txtAccoff.Text = selected("A/C Of").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtDespatchName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDespatchName.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_City_SELECTION(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtDespatchName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtDespatch_code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("cityname") Then txtDespatchName.Text = selected("cityname").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtTransportName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransportName.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_TRANSPORT_SELECTION(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtTransportName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtTr_code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("TransportName") Then txtTransportName.Text = selected("TransportName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

End Class