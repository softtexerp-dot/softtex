Imports System.Text
Friend Class CoastSheet

    Private obj_Party_Selection As New Multi_Selection_Master


#Region "GRID STRING BUILDER VARIABLE"
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
    Private WithEvents txt_Name_For_Grid_Selection As New TextBox
    Private WithEvents txt_Code_For_Grid_Selection As New TextBox
    Private WithEvents txt_FabricItemCode As New TextBox
    Private Old_Date As String = ""
#End Region


#Region "GENERAL VARIABLE DECLARE"
    Private _FrmLoad As Boolean = True
    Private WithEvents txtAgent_code As New TextBox
    Private WithEvents txtParty_code As New TextBox
    Private WithEvents txtSupp_code As New TextBox
    Private WithEvents txtTr_code As New TextBox
    Private WithEvents txtDespatch_code As New TextBox
    Private DispList As Boolean = False
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldName As String = "BOOKVNO"
    Private _KeyFieldValue As String = ""
    Private _OfferTableName As String = "TRNFABRICCOST"
    Private _ErrorMessage As String = ""
    Private _NewAddedRow As Boolean = False
    Private SRNO As Integer = 1
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _TmpDataTable As New DataTable
    Private _BookTrType As String = "FS-OF"
    Private _BookCode As String = "0001-000000019"
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
#End Region

#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False

        If Val(TXT_Net_Sales_Cost.Text) = 0 Then
            MsgBox("Invalid Entry ")
            txt_Fabric_Item_name.Focus()
            txt_Fabric_Item_name.Select()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function
#End Region
#Region "SUB NEW"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region

#Region "GRID COL. DEFINE AND FORMATTING"
    Private Sub defineGridColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID,")
            .Append("TOTAL_ENDS,")
            .Append("FD_PD,")
            .Append("LOOM,")
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Fabric_Item_Name,")
            .Append("Reed,")
            .Append("Dent,")
            .Append("Pick,")
            .Append("Reed_Space,")
            .Append("srno,")
            .Append("Yarn_For,")
            .Append("Countname,")
            .Append("NETCOUNT,")
            .Append("PATTERN,")
            .Append("Yarn_Rate,")
            .Append("Avg_weight,")
            .Append("PROFIT_PER,")
            .Append("countcode,")
            .Append("yarn_west_per,")
            .Append("yarn_west_amt,")
            .Append("Net_Yarn_Cost,")
            .Append("Weaving_rate_per_Pick,")
            .Append("Mending_Rate_Per_Mtr,")
            .Append("Monogram_Rate_Per_Mtr,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Grey_Cost,")
            .Append("Process_Rate_Per_Mtr,")
            .Append("Shrinkage_in_Per,")
            .Append("Net_Finish_Cost,")
            .Append("Sample_Exp_Per_Mtr,")
            .Append("Tour_Exp_Per_Mtr,")
            .Append("OverHead_Per_Mtr,")
            .Append("Grading_Exp_Per_Mtr,")
            .Append("Value_Loss_Per_Mtr	,")
            .Append("Packing_Exp_Per_Mtr,")
            .Append("Salary_Exp_Per_Mtr,")
            .Append("Credit_Days,")
            .Append("Interest_In_Per,")
            .Append("Mis_Exp_per_Mtr,")
            .Append("Agency_Comm_In_Per,")
            .Append("Profit_Rs_Per_Mtr,")
            .Append("Net_Sales_Cost,")
            .Append("yarn_Sub_Total_amt	,")
            .Append("yarn_exp_per,")
            .Append("yarn_int_per,")
            .Append("yarn_exp_amt,")
            .Append("yarn_int_amt,")
            .Append("Rate_per_Pick,")
            .Append("Mending_per_mtr,")
            .Append("mono_per_mtr,")
            .Append("SELV_PER_MTR,")
            .Append("per_pick_amt,")
            .Append("mend_amt,")
            .Append("selv_amt,")
            .Append("weav_cost,")
            .Append("grey_Cost	,")
            .Append("process_rate,")
            .Append("shrink_per,")
            .Append("process_amt,")
            .Append("shk_amt,")
            .Append("process_cost,")
            .Append("finish_cost,")
            .Append("over_exp_per_mtr,")
            .Append("interest_per,")
            .Append("agency_comm_per,")
            .Append("profit_rs,")
            .Append("grad_exp_amt,")
            .Append("value_loss_amt,")
            .Append("sample_amt,")
            .Append("tour_exp_amt,")
            .Append("over_amt,")
            .Append("packing_amt,")
            .Append("salary_amt,")
            .Append("credit_days_amt,")
            .Append("int_amt,")
            .Append("mis_amt,")
            .Append("agcomm_amt,")
            .Append("profit_amt,")
            .Append("sales_cost,")

            .Append("CdPerMtr,")
            .Append("AgencyPerMtr,")
            .Append("ProftPerMtr,")
            .Append("CdPerMtrAmt,")
            .Append("AgencyPerMtrAmt,")
            .Append("ProftPerMtrAmt,")
            .Append("Fabric_Design_No,")

            .Append("Yarn_Amount")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("EntryNo:N,")
            .Append("Reed:N,")
            .Append("Dent:N,")
            .Append("Pick:N,")
            .Append("Reed_Space:N,")
            .Append("srno:N,")
            .Append("NETCOUNT:N,")
            .Append("PATTERN:N,")
            .Append("TOTAL_ENDS:N,")
            .Append("Yarn_Rate:N,")
            .Append("Avg_weight:N,")
            .Append("PROFIT_PER:N,")
            .Append("yarn_west_per:N,")
            .Append("yarn_west_amt:N,")
            .Append("Net_Yarn_Cost:N,")
            .Append("Weaving_rate_per_Pick:N,")
            .Append("Mending_Rate_Per_Mtr:N,")
            .Append("Monogram_Rate_Per_Mtr:N,")
            .Append("Net_Weaving_Cost:N,")
            .Append("Net_Grey_Cost:N,")
            .Append("Process_Rate_Per_Mtr:N,")
            .Append("Shrinkage_in_Per:N,")
            .Append("Net_Finish_Cost:N,")
            .Append("Sample_Exp_Per_Mtr:N,")
            .Append("Tour_Exp_Per_Mtr:N,")
            .Append("OverHead_Per_Mtr:N,")
            .Append("Grading_Exp_Per_Mtr:N,")
            .Append("Value_Loss_Per_Mtr:N,")
            .Append("Packing_Exp_Per_Mtr:N,")
            .Append("Salary_Exp_Per_Mtr:N,")
            .Append("Credit_Days:N,")
            .Append("Interest_In_Per:N,")
            .Append("Mis_Exp_per_Mtr:N,")
            .Append("Agency_Comm_In_Per:N,")
            .Append("Profit_Rs_Per_Mtr:N,")
            .Append("Net_Sales_Cost:N,")
            .Append("yarn_Sub_Total_amt:N,")
            .Append("yarn_exp_per:N,")
            .Append("yarn_int_per:N,")
            .Append("yarn_exp_amt:N,")
            .Append("yarn_int_amt:N,")
            .Append("Rate_per_Pick:N,")
            .Append("Mending_per_mtr:N,")
            .Append("mono_per_mtr:N,")
            .Append("SELV_PER_MTR:N,")
            .Append("per_pick_amt:N,")
            .Append("mend_amt:N,")
            .Append("selv_amt:N,")
            .Append("weav_cost:N,")
            .Append("grey_Cost:N,")
            .Append("process_rate:N,")
            .Append("shrink_per:N,")
            .Append("process_amt:N,")
            .Append("shk_amt:N,")
            .Append("process_cost:N,")
            .Append("finish_cost:N,")
            .Append("over_exp_per_mtr:N,")
            .Append("interest_per:N,")
            .Append("agency_comm_per:N,")
            .Append("profit_rs:N,")
            .Append("grad_exp_amt:N,")
            .Append("value_loss_amt:N,")
            .Append("sample_amt:N,")
            .Append("tour_exp_amt:N,")
            .Append("over_amt:N,")
            .Append("packing_amt:N,")
            .Append("salary_amt:N,")
            .Append("credit_days_amt:N,")
            .Append("int_amt:N,")
            .Append("mis_amt:N,")
            .Append("agcomm_amt:N,")
            .Append("profit_amt:N,")
            .Append("sales_cost:N,")

            .Append("CdPerMtr:N,")
            .Append("AgencyPerMtr:N,")
            .Append("ProftPerMtr:N,")
            .Append("CdPerMtrAmt:N,")
            .Append("AgencyPerMtrAmt:N,")
            .Append("ProftPerMtrAmt:N,")

            .Append("Yarn_Amount:N")
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
            .Append("Yarn_For:Yarn For,")
            .Append("Countname:Count Name,")
            .Append("Pattern:Pattern,")
            .Append("Yarn_Rate:Rate,")
            .Append("Avg_weight:Avg-Wt,")
            .Append("PROFIT_PER:(+/-)Wt,")
            .Append("Yarn_Amount:Amount")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("Yarn_For:L,")
            .Append("Countname:L,")
            .Append("Pattern:R,")
            .Append("Yarn_Rate:R,")
            .Append("Avg_weight:R,")
            .Append("PROFIT_PER:R,")
            .Append("Yarn_Amount:R")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("Yarn_For:L,")
            .Append("Countname:L,")
            .Append("Pattern:R,")
            .Append("Yarn_Rate:R,")
            .Append("Avg_weight:R,")
            .Append("PROFIT_PER:R,")
            .Append("Yarn_Amount:R")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("TOTAL_ENDS:N,")
            .Append("FD_PD:N,")
            .Append("LOOM:N,")
            .Append("Fabric_Design_No:N,")
            .Append("EntryNo:N,")
            .Append("Entry_Date:N,")
            .Append("Fabric_Item_Name:N,")
            .Append("Reed:N,")
            .Append("Dent:N,")
            .Append("Pick:N,")
            .Append("Reed_Space:N,")
            .Append("NETCOUNT:N,")
            .Append("SRNO:Y,")
            .Append("Yarn_For:Y,")
            .Append("Countname:Y,")
            .Append("Pattern:Y,")
            .Append("Yarn_Rate:Y,")
            .Append("Avg_weight:Y,")
            .Append("PROFIT_PER:Y,")
            .Append("Yarn_Amount:Y,")
            .Append("countcode:N,")
            .Append("yarn_west_per:N,")
            .Append("yarn_west_amt:N,")
            .Append("Net_Yarn_Cost:N,")
            .Append("Weaving_rate_per_Pick:N,")
            .Append("Mending_Rate_Per_Mtr:N,")
            .Append("Monogram_Rate_Per_Mtr:N,")
            .Append("Net_Weaving_Cost:N,")
            .Append("Net_Grey_Cost:N,")
            .Append("Process_Rate_Per_Mtr:N,")
            .Append("Shrinkage_in_Per:N,")
            .Append("Net_Finish_Cost:N,")
            .Append("Sample_Exp_Per_Mtr:N,")
            .Append("Tour_Exp_Per_Mtr:N,")
            .Append("OverHead_Per_Mtr:N,")
            .Append("Grading_Exp_Per_Mtr:N,")
            .Append("Value_Loss_Per_Mtr	:N,")
            .Append("Packing_Exp_Per_Mtr:N,")
            .Append("Salary_Exp_Per_Mtr:N,")
            .Append("Credit_Days:N,")
            .Append("Interest_In_Per:N,")
            .Append("Mis_Exp_per_Mtr:N,")
            .Append("Agency_Comm_In_Per:N,")
            .Append("Profit_Rs_Per_Mtr:N,")
            .Append("Net_Sales_Cost:N,")
            .Append("yarn_Sub_Total_amt	:N,")
            .Append("yarn_exp_per:N,")
            .Append("yarn_int_per:N,")
            .Append("yarn_exp_amt:N,")
            .Append("yarn_int_amt:N,")
            .Append("Rate_per_Pick:N,")
            .Append("Mending_per_mtr:N,")
            .Append("mono_per_mtr:N,")
            .Append("SELV_PER_MTR:N,")
            .Append("per_pick_amt:N,")
            .Append("mend_amt:N,")
            .Append("selv_amt:N,")
            .Append("weav_cost:N,")
            .Append("grey_Cost	:N,")
            .Append("process_rate:N,")
            .Append("shrink_per:N,")
            .Append("process_amt:N,")
            .Append("shk_amt:N,")
            .Append("process_cost:N,")
            .Append("finish_cost:N,")
            .Append("over_exp_per_mtr:N,")
            .Append("interest_per:N,")
            .Append("agency_comm_per:N,")
            .Append("profit_rs:N,")
            .Append("grad_exp_amt:N,")
            .Append("value_loss_amt:N,")
            .Append("sample_amt:N,")
            .Append("tour_exp_amt:N,")
            .Append("over_amt:N,")
            .Append("packing_amt:N,")
            .Append("salary_amt:N,")
            .Append("credit_days_amt:N,")
            .Append("int_amt:N,")
            .Append("mis_amt:N,")
            .Append("agcomm_amt:N,")
            .Append("profit_amt:N,")
            .Append("CdPerMtr:N,")
            .Append("AgencyPerMtr:N,")
            .Append("ProftPerMtr:N,")
            .Append("CdPerMtrAmt:N,")
            .Append("AgencyPerMtrAmt:N,")
            .Append("ProftPerMtrAmt:N,")
            .Append("sales_cost:N")
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("COUNTNAME:N,")
            .Append("NETCOUNT:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:6,")
            .Append("Yarn_For:11,")
            .Append("Countname:15,")
            .Append("Pattern:11,")
            .Append("Yarn_Rate:15,")
            .Append("Avg_weight:15,")
            .Append("PROFIT_PER:12,")
            .Append("Yarn_Amount:1")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("Yarn_Rate:0,")
            .Append("pattern:0,")
            .Append("Avg_weight:0,")
            .Append("PROFIT_PER:0,")
            .Append("Yarn_Amount:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y,")
            .Append("AVG_WEIGHT:Y,")
            .Append("YARN_AMOUNT:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("Yarn_Rate:NO-2,")
            .Append("Avg_weight:NO-3,")
            .Append("PROFIT_PER:NO-3,")
            .Append("Yarn_Amount:NO-2")
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
        Dim xFont = New Font("Verdana", 9, FontStyle.Regular)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub
#End Region

#Region "Form Default values on Load"
    Private Sub DefineDafaultValues()
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST ORDER BY ENTRYNO DESC"
        txt_EntryNo.Text = 1
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txt_EntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
        End If


        _LastEntryNo = txt_EntryNo.Text

        ObjCls_General.Replace_Array_Values(_FocusFields, _GridCol_FocusByPass.ToString)

        If txt_Entry_Date.Text = "  /  /    " Then
            txt_Entry_Date.Text = IIf(Val(txt_EntryNo.Text) = 1, USERDATE_FinYearStartDate, ObjCls_General.GetTodayDate_British)
        End If

        txt_EntryNo.Focus()

        GrdItem.Locked = True
        _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
        GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
        GrdItem.BoldFixedCell = True
        GrdItem.Locked = False
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub FinishSalesOffer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)
        If e.KeyCode = Keys.Escape Then

            If pnl_Print.Visible = True Then
                pnl_Print.Visible = False
                Command_Button_Visibility("LOAD")
                Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Exit Sub
            End If


            _FrmLoad = True
            If _FORMMODE = "" Then
                Me.Close()
            Else


                If PnlGrdView.Visible = True Then
                    PnlGrdView.Visible = False
                    Command_Button_Visibility("LOAD")
                    Me.Text = _old_Me_text
                    _FORMMODE = ""
                    Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                    Exit Sub
                End If


                Select Case _STRTRNOBJECT
                    Case "GRDITEM"
                        GrdItem.ActiveCell.BackColor = GrdItem.BackColor1
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txt_EntryNo.Focus()
                    Case "TERM1"
                        txt_EntryNo.Focus()
                    Case "TXTOFFERDATE"
                        _FrmLoad = True
                        'txtEntryNo.Focus()
                        txt_Entry_Date.Text = ObjCls_General.GetTodayDate_British
                        _FORMMODE = ""
                        Old_Date = txt_Entry_Date.Text
                        ObjCls_General.Blank_Object(Me)
                        txt_Entry_Date.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        _KeyFieldValue = 0
                        Call Command_Button_Visibility("LOAD")
                        Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Cost_Sheet_Ctrl_Visible_False()
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                    Case Else
                        _FrmLoad = True
                        _FORMMODE = ""
                        Old_Date = txt_Entry_Date.Text
                        ObjCls_General.Blank_Object(Me)
                        txt_Entry_Date.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        _KeyFieldValue = 0
                        Call Command_Button_Visibility("LOAD")
                        Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Cost_Sheet_Ctrl_Visible_False()
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                End Select
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If _STRTRNOBJECT = "GRDITEM" Then
                'Call Show_Calculator_With_Grid(GrdItem, Me)
            ElseIf _STRTRNOBJECT = "GRDVIEW" Then
                'Call Show_Calculator_With_Grid(grdView, Me)
            Else
                'Call Show_Calculator_Without_Grid(Me)
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    If (Val(lbl_AvgWt.Text) + Val(txt_yarn_Sub_Total_amt.Text)) = 0 Then
                        MsgBox("Blank Count Detail, Can't Save")
                        Exit Sub
                    Else
                        _FrmLoad = True
                        GrdItem.ActiveCell.BackColor = GrdItem.BackColor1
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        GrdItem.Range(1, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).BackColor = GrdItem.BackColor1
                        txt_yarn_exp_per.Focus()
                        txt_yarn_exp_per.Select()
                        _FrmLoad = False
                    End If
                Case "BTNSAVE"
                    txt_EntryNo.Focus()
                Case "TXT_ENTRYNO"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case "TXT_ENTRY_DATE"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case "TXT_FABRIC_ITEM_NAME"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case "TXT_REED"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case "TXT_PICK"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case "TXT_DENT"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case "TXT_REED_SPACE"
                    _FrmLoad = True
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    GrdItem.Focus()
                    GrdItem.Select()
                    GrdItem.ActiveCell.BackColor = Color.Transparent
                Case Else
                    btnSave.Focus()
                    btnSave.Select()
            End Select
        ElseIf e.KeyCode = Keys.F3 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    _FrmLoad = True
                    Delete_Row(GrdItem, _DataTableGrid)
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = ""
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text = ""
                    Call Fill_Sr_No_Item(GrdItem, _DataTableGrid)
                    _FrmLoad = False
                    Call Rate_Calc()
            End Select
        End If
        End Sub

    Private Sub _addcoloum()

        Dim CHKCOLUM = False
        Dim COLOUM As String = ""

        sqL = " Select * FROM TrnFabricCost "
        sql_connect_slect()
        For Each column As DataColumn In DefaltSoftTable.Columns
            COLOUM = (column.ColumnName)
            If COLOUM = "CdPerMtr" Then
                CHKCOLUM = True
            End If
        Next
        If CHKCOLUM = False Then
            _strQuery = New System.Text.StringBuilder
            With _strQuery
                .Append("  ALTER TABLE TrnFabricCost add   ")
                .Append("   CdPerMtr numeric(18, 3) ")
                .Append("   ,CdPerMtrAmt numeric(18, 3) ")
                .Append("   ,AgencyPerMtr numeric(18, 3) ")
                .Append("   ,AgencyPerMtrAmt numeric(18, 3) ")
                .Append("   ,ProftPerMtr numeric(18, 3) ")
                .Append("   ,ProftPerMtrAmt numeric(18, 3) ")
                .Append("   ,OTHEREXP_6 numeric(18, 2) ")
                .Append("   ,OTHEREXP_7 numeric(18, 3) ")
                .Append("   ,OTHEREXP_8 numeric(18, 3) ")
                .Append("   ,OTHEREXP_9 numeric(18, 3) ")
                .Append("   ,OTHEREXP_10 numeric(18, 3) ")
                .Append("   ,OTHEREXP_11 numeric(18, 3) ")
                .Append("   ,OTHEREXP_12 numeric(18, 3) ")
                .Append("   ,OTHEREXP_13 numeric(18, 3) ")
                .Append("   ,OTHEREXP_14 numeric(18, 3) ")
                .Append("   ,OTHEREXP_15 numeric(18, 3) ")
                .Append("   ,OTHEREXP_16 numeric(18, 3) ")
                .Append("   ,OTHEREXP_17 numeric(18, 3) ")
                .Append("   ,OTHEREXP_18 numeric(18, 3) ")
                .Append("   ,OTHEREXP_19 numeric(18, 3) ")
                .Append("   ,OTHEREXP_20 numeric(18, 3) ")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
        End If

    End Sub


    Private Sub FinishSalesOffer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _addcoloum()
        'Fabric_Item_Master_Frm.ConstructionFildCreat()


        pnl_Print.Width = 449
        pnl_Print.Height = 303
        pnl_Print.Location = New Point(169, 118)


        PnlGrdView.Width = Me.Width
        PnlGrdView.Height = Me.Height
        PnlGrdView.Location = New Point(0, 0)

        GridControl1.Width = PnlGrdView.Width - 25
        GridControl1.Height = PnlGrdView.Height - 100
        GridControl1.Location = New Point(3, 53)


        _FrmLoad = True
        Me.Location = New Point(0, 0)
        '_RowLeaveColor = Me.BackColor
        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)

        GrdItem.Rows = 2

        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 20
        _old_Me_text = Me.Text
        If _isCallerByOther = True Then
            btnAdd.Visible = False
            btnModify.Visible = False
            btnDelete.Visible = False
            btnView.Visible = False
            btnSave.Visible = True
            Call Alter_Form(_KeyFieldValue)
        Else
            Call Command_Button_Visibility("LOAD")
            Cost_Sheet_Ctrl_Visible_False()
            btnAdd.Focus()
            btnAdd.Select()
        End If
        _FrmLoad = False

        'If Screen_Width < 1024 Or Screen_Height < 768 Then
        '    ResizeFormClass.SubResize(Me, 95, 83)
        '    Me.Height = ((gMDI.Height + 8) - (gMDI.mnuAgency.Height + gMDI.lbl_Footer_Main.Height * 3))
        '    Me.Refresh()
        '    Me.CenterToParent()
        'End If

    End Sub
#End Region

#Region "COMMAND BUTTON VISIBILITY CODE"
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
        If Visibility_Flag = "LOAD" Then
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnPrint.Enabled = True
            btnSave.Enabled = False
            lbl_AvgWt.Text = ""
        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNEDIT" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNPRINT" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        End If
    End Sub
#End Region

#Region "SET FOCUS LAST CLICKED BTN"
    Private Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)
        If Last_Focused_Btn = "ADD" Then
            btnAdd.Focus()
        ElseIf Last_Focused_Btn = "MODIFY" Then
            btnModify.Focus()
        ElseIf Last_Focused_Btn = "DELETE" Then
            btnDelete.Focus()
        ElseIf Last_Focused_Btn = "VIEW" Then
            btnView.Focus()
        ElseIf Last_Focused_Btn = "SAVE" Then
            btnAdd.Focus()
        ElseIf Last_Focused_Btn = "PRINT" Then
            btnPrint.Focus()
        End If
    End Sub
#End Region

#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE"
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
    Private Sub BtnPrint_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.GotFocus
        btnPrint.BackColor = Color.Coral
    End Sub
    Private Sub BtnPrint_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.LostFocus
        btnPrint.BackColor = Me.BackColor
    End Sub
#End Region

#Region "OFFER SAVE CODE"
    Private Sub SaveRecord()

        Generate_Date_For_DataBase(txt_Entry_Date)


        If _BookVNo = "" Then
            _BookVNo = Generate_Book_Vno(Val(txt_EntryNo.Text), _BookTrType)
        End If
        Call Fill_Grid_Records_Into_DataTables()
        'Dim _LastID As Integer = -1
        Try
            SAVE_INTO_DATABASE()
            'If _LastID > 0 Then
            Old_Date = txt_Entry_Date.Text
            _Last_Saved_Entry_No = Val(txt_EntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex ERP")

            ''**** On Line Printing System Start
            'If MsgBox("Print", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Print ?") = MsgBoxResult.Yes Then
            '    Dim Dbl_Copy As String = "NO"
            '    If MsgBox("Dobule Copy", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Soft-Tex ERP") = MsgBoxResult.Yes Then
            '        Dbl_Copy = "YES"
            '    End If
            '    Dim Str_Qry As String = Indent_Printing.Get_Offer_Query(" AND A.BOOKVNO='" & _BookVNo & "' ", _BookCode)
            '    'Wait_Window_Show(Me, "Wait...")
            '    Indent_Printing.Offer_Preview(Dbl_Copy, "YES", Str_Qry, _BookCode, txt_Entry_Date.Text + " TO " + txt_Entry_Date.Text, True)
            '    'Wait_Window_Hide()
            'End If
            ''**** On Line Printing System Finish

            ObjCls_General.Blank_Object(Me)
            txt_Entry_Date.Text = Old_Date
            Cost_Sheet_Ctrl_Visible_False()
            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            Call Command_Button_Visibility("LOAD")
            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        _DataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdItem.Rows - 1
            If Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text) > 0 Then
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
        Dim strFilterString As String
        Dim QueryDetailTable As String = ""

        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String
        strFilterString = "YARN_AMOUNT>0"

        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("TOTAL_ENDS,")
            .Append("FD_PD,")
            .Append("LOOM,")
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Fabric_Item_Name,")
            .Append("Reed,")
            .Append("Dent,")
            .Append("Pick,")
            .Append("Reed_Space,")
            .Append("yarn_west_per,")
            .Append("yarn_west_amt,")
            .Append("Net_Yarn_Cost,")
            .Append("Weaving_rate_per_Pick,")
            .Append("Mending_Rate_Per_Mtr,")
            .Append("Monogram_Rate_Per_Mtr,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Grey_Cost,")
            .Append("Process_Rate_Per_Mtr,")
            .Append("Shrinkage_in_Per,")
            .Append("Net_Finish_Cost,")
            .Append("Sample_Exp_Per_Mtr,")
            .Append("Tour_Exp_Per_Mtr,")
            .Append("OverHead_Per_Mtr,")
            .Append("Grading_Exp_Per_Mtr,")
            .Append("Value_Loss_Per_Mtr	,")
            .Append("Packing_Exp_Per_Mtr,")
            .Append("Salary_Exp_Per_Mtr,")
            .Append("Credit_Days,")
            .Append("Interest_In_Per,")
            .Append("Mis_Exp_per_Mtr,")
            .Append("Agency_Comm_In_Per,")
            .Append("Profit_Rs_Per_Mtr,")
            .Append("Net_Sales_Cost,")
            .Append("yarn_Sub_Total_amt	,")
            .Append("yarn_exp_per,")
            .Append("yarn_int_per,")
            .Append("yarn_exp_amt,")
            .Append("yarn_int_amt,")
            .Append("Rate_per_Pick,")
            .Append("Mending_per_mtr,")
            .Append("mono_per_mtr,")
            .Append("SELV_PER_MTR,")
            .Append("per_pick_amt,")
            .Append("mend_amt,")
            .Append("selv_amt,")
            .Append("weav_cost,")
            .Append("grey_Cost	,")
            .Append("process_rate,")
            .Append("shrink_per,")
            .Append("process_amt,")
            .Append("shk_amt,")
            .Append("process_cost,")
            .Append("finish_cost,")
            .Append("over_exp_per_mtr,")
            .Append("interest_per,")
            .Append("agency_comm_per,")
            .Append("profit_rs,")
            .Append("grad_exp_amt,")
            .Append("value_loss_amt,")
            .Append("sample_amt,")
            .Append("tour_exp_amt,")
            .Append("over_amt,")
            .Append("packing_amt,")
            .Append("salary_amt,")
            .Append("credit_days_amt,")
            .Append("int_amt,")
            .Append("mis_amt,")
            .Append("agcomm_amt,")
            .Append("profit_amt,")
            .Append("CdPerMtr,")
            .Append("AgencyPerMtr,")
            .Append("ProftPerMtr,")
            .Append("CdPerMtrAmt,")
            .Append("AgencyPerMtrAmt,")
            .Append("ProftPerMtrAmt,")
            .Append("Fabric_Design_No,")
            .Append("sales_cost")

        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txt_Total_Ends.Text & ",")
            .Append(txt_FD_PD.Text & ",")
            .Append(txt_Loom.Text & ",")
            .Append(txt_EntryNo.Text & ",")
            .Append(txt_Entry_Date.Date_for_Database & ",")
            .Append(txt_Fabric_Item_name.Text & ",")
            .Append(txt_reed.Text & ",")
            .Append(txt_dent.Text & ",")
            .Append(txt_pick.Text & ",")
            .Append(txt_reed_space.Text & ",")
            .Append(txt_yarn_west_per.Text & ",")
            .Append(txt_yarn_west_amt.Text & ",")
            .Append(txt_Net_Yarn_Cost.Text & ",")
            .Append(txt_Weaving_rate_per_Pick.Text & ",")
            .Append(TXT_Mending_Rate_Per_Mtr.Text & ",")
            .Append(TXT_Monogram_Rate_Per_Mtr.Text & ",")
            .Append(TXT_Net_Weaving_Cost.Text & ",")
            .Append(TXT_Net_Grey_Cost.Text & ",")
            .Append(TXT_Process_Rate_Per_Mtr.Text & ",")
            .Append(TXT_Shrinkage_in_Per.Text & ",")
            .Append(TXT_Net_Finish_Cost.Text & ",")
            .Append(txt_sample_exp_per_mtr.Text & ",")
            .Append(txt_tour_exp_per_mtr.Text & ",")
            .Append(TXT_OverHead_Per_Mtr.Text & ",")
            .Append(txt_grading_exp_per_mtr.Text & ",")
            .Append(txt_VALUE_LOSS_PER_MTR.Text & ",")
            .Append(txt_packing_exp_per_mtr.Text & ",")
            .Append(txt_salary_exp_per_mtr.Text & ",")
            .Append(txt_credit_days.Text & ",")
            .Append(TXT_Interest_In_Per.Text & ",")
            .Append(txt_mis_exp_per_mtr.Text & ",")
            .Append(TXT_Agency_Comm_In_Per.Text & ",")
            .Append(TXT_Profit_Rs_Per_Mtr.Text & ",")
            .Append(TXT_Net_Sales_Cost.Text & ",")
            .Append(txt_yarn_Sub_Total_amt.Text & ",")
            .Append(txt_yarn_exp_per.Text & ",")
            .Append(txt_yarn_int_per.Text & ",")
            .Append(txt_yarn_exp_amt.Text & ",")
            .Append(txt_yarn_int_amt.Text & ",")
            .Append(txt_Weaving_rate_per_Pick.Text & ",")
            .Append(TXT_Mending_Rate_Per_Mtr.Text & ",")
            .Append(TXT_Monogram_Rate_Per_Mtr.Text & ",")
            .Append(txt_SELV_PER_MTR.Text & ",")
            .Append(txt_per_pick_amt.Text & ",")
            .Append(txt_mend_amt.Text & ",")
            .Append(txt_selv_amt.Text & ",")
            .Append(TXT_Net_Weaving_Cost.Text & ",")
            .Append(TXT_Net_Grey_Cost.Text & ",")
            .Append(TXT_Process_Rate_Per_Mtr.Text & ",")
            .Append(TXT_Shrinkage_in_Per.Text & ",")
            .Append(txt_process_amt.Text & ",")
            .Append(txt_shk_amt.Text & ",")
            .Append(txt_process_cost.Text & ",")
            .Append(TXT_Net_Finish_Cost.Text & ",")
            .Append(TXT_OverHead_Per_Mtr.Text & ",")
            .Append(TXT_Interest_In_Per.Text & ",")
            .Append(TXT_Agency_Comm_In_Per.Text & ",")
            .Append(TXT_Profit_Rs_Per_Mtr.Text & ",")
            .Append(txt_grad_exp_amt.Text & ",")
            .Append(txt_value_loss_amt.Text & ",")
            .Append(txt_sample_amt.Text & ",")
            .Append(txt_tour_exp_amt.Text & ",")
            .Append(txt_over_amt.Text & ",")
            .Append(txt_packing_amt.Text & ",")
            .Append(txt_salary_amt.Text & ",")
            .Append(txt_credit_days_amt.Text & ",")
            .Append(txt_int_amt.Text & ",")
            .Append(txt_mis_amt.Text & ",")
            .Append(txt_agcomm_amt.Text & ",")
            .Append(txt_process_amt.Text & ",")
            .Append(Txt_CdPerMtr.Text & ",")
            .Append(Txt_AgencyPerMtr.Text & ",")
            .Append(Txt_ProftPerMtr.Text & ",")
            .Append(Txt_CdPerMtrAmt.Text & ",")
            .Append(Txt_AgencyPerMtr_Amt.Text & ",")
            .Append(Txt_ProftPerMtr_Amt.Text & ",")
            .Append(txt_FabricItemCode.Text & ",")
            .Append(TXT_Net_Sales_Cost.Text)
        End With

        QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid

    End Function
    Private Function SAVE_INTO_DATABASE() As Integer
        Dim strQuery As String = ""
        Dim I As Integer = 0


        Try
            '---------------- Delete Previous Bill Sundry ---------------------------------- '
            strQuery = "DELETE FROM TRNFABRICCOST WHERE ENTRYNO =" & txt_EntryNo.Text & "  "
            sqL = strQuery.ToString
            sql_Data_Save_Delete_Update()


            Dim Array_Opening(0, 4) As String
            '------ INSERT RECORDS SALES INVOICE -------------------------------
            GridDetailsSaveQuery(Array_Opening)
            For I = 0 To UBound(Array_Opening)
                If Array_Opening(I, 4) <> "" Then
                    strQuery = Array_Opening(I, 4)
                    sqL = strQuery.ToString
                    sql_Data_Save_Delete_Update()
                End If
            Next

        Catch ex As Exception
            MsgBox("new error comes :" & ex.Message & "-" & strQuery)
            Throw ex
        Finally
            'cmd = Nothing
            'tran = Nothing
        End Try
        Return I
    End Function
#End Region

#Region "BTN CLICK/ENTER CODE"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If _FORMMODE = "" Then
            Me.Close()
        Else
            If _FORMMODE = "VIEW" Then
                PnlGrdView.Visible = False
                Call Command_Button_Visibility("LOAD")
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Me.Text = _old_Me_text
                _FORMMODE = ""
                'pnl_ItemGrid.Visible = True
                'pnl_Footer.Visible = True
                'pnl_Header.Height = 181
            Else
                _FORMMODE = ""
                Old_Date = txt_Entry_Date.Text
                ObjCls_General.Blank_Object(Me)
                txt_Entry_Date.Text = Old_Date
                _KeyFieldValue = 0
                Call Command_Button_Visibility("LOAD")
                Call Ctrl_Visible_False(Me.Controls)
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            End If
        End If
    End Sub
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        Call Command_Button_Visibility("BTNVIEW")


        sqL = "SELECT min(ENTRY_DATE) as ENTRY_DATE FROM TRNFABRICCOST"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_ViewFrom.Text = (DefaltSoftTable.Rows(0).Item("ENTRY_DATE"))
        End If

        'Txt_ViewFrom.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        Txt_ViewTO.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        Call View_Record()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            _FORMMODE = ""
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Change_Grid_Data = True

        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"
        Cost_Sheet_Ctrl_Visible_True()
        Call DefineDafaultValues()
        Call Command_Button_Visibility("BTNADD")
        If txt_Entry_Date.Text = "" Then txt_Entry_Date.Text = "  /  /    "
        Me.txt_Entry_Date.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        txt_EntryNo.Focus()
        txt_EntryNo.Select()
    End Sub
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Change_Grid_Data = True

        Last_Focused_Btn = "MODIFY"
        _FORMMODE = "EDIT"
        Command_Button_Visibility("BTNEDIT")
        txt_EntryNo.Visible = True
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST ORDER BY ENTRYNO DESC"
        txt_EntryNo.Text.IndexOf("'")
        txt_EntryNo.Text = 1

        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txt_EntryNo.Text = (DefaltSoftTable.Rows(0).Item(0))
        End If

        _LastEntryNo = txt_EntryNo.Text
        txt_EntryNo.Visible = True
        txt_EntryNo.Focus()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        _FrmLoad = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        Command_Button_Visibility("BTNDELETE")
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST ORDER BY ENTRYNO DESC"
        txt_EntryNo.Text.IndexOf("'")
        txt_EntryNo.Text = 1
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txt_EntryNo.Text = (DefaltSoftTable.Rows(0).Item(0))
        End If

        _LastEntryNo = txt_EntryNo.Text
        If txt_EntryNo.Text <> "" Then
            txt_EntryNo.Visible = True
            txt_EntryNo.Focus()
        Else
            MsgBox("No Record Found")
            Cost_Sheet_Ctrl_Visible_False()
            btnAdd.Focus()
        End If
    End Sub
#End Region

#Region "CTRL VISIBLE FALSE"
    Private Sub Cost_Sheet_Ctrl_Visible_False()
        GrdItem.Enabled = False

        txt_EntryNo.Visible = False
        txt_Entry_Date.Visible = False
        txt_Fabric_Item_name.Visible = False
        txt_reed.Visible = False
        txt_dent.Visible = False
        txt_pick.Visible = False
        txt_reed_space.Visible = False
        txt_yarn_west_per.Visible = False
        txt_yarn_west_amt.Visible = False
        txt_Net_Yarn_Cost.Visible = False
        txt_per_pick_amt.Visible = False
        TXT_Mending_Rate_Per_Mtr.Visible = False
        TXT_Monogram_Rate_Per_Mtr.Visible = False
        TXT_Net_Weaving_Cost.Visible = False
        TXT_Net_Grey_Cost.Visible = False
        TXT_Process_Rate_Per_Mtr.Visible = False
        TXT_Shrinkage_in_Per.Visible = False
        TXT_Net_Finish_Cost.Visible = False
        txt_sample_exp_per_mtr.Visible = False
        txt_tour_exp_per_mtr.Visible = False
        TXT_OverHead_Per_Mtr.Visible = False
        txt_grading_exp_per_mtr.Visible = False
        txt_VALUE_LOSS_PER_MTR.Visible = False
        txt_packing_exp_per_mtr.Visible = False
        txt_salary_exp_per_mtr.Visible = False
        txt_credit_days.Visible = False
        TXT_Interest_In_Per.Visible = False
        txt_mis_exp_per_mtr.Visible = False
        TXT_Agency_Comm_In_Per.Visible = False
        TXT_Profit_Rs_Per_Mtr.Visible = False
        TXT_Net_Sales_Cost.Visible = False
        txt_yarn_Sub_Total_amt.Visible = False
        txt_yarn_exp_per.Visible = False
        txt_yarn_int_per.Visible = False
        txt_yarn_exp_amt.Visible = False
        txt_yarn_int_amt.Visible = False
        txt_Weaving_rate_per_Pick.Visible = False
        TXT_Mending_Rate_Per_Mtr.Visible = False
        TXT_Monogram_Rate_Per_Mtr.Visible = False
        txt_SELV_PER_MTR.Visible = False
        txt_per_pick_amt.Visible = False
        txt_mend_amt.Visible = False
        txt_selv_amt.Visible = False
        TXT_Net_Weaving_Cost.Visible = False
        TXT_Net_Grey_Cost.Visible = False
        TXT_Process_Rate_Per_Mtr.Visible = False
        TXT_Shrinkage_in_Per.Visible = False
        txt_process_amt.Visible = False
        txt_shk_amt.Visible = False
        txt_process_cost.Visible = False
        TXT_Net_Finish_Cost.Visible = False
        TXT_OverHead_Per_Mtr.Visible = False
        TXT_Interest_In_Per.Visible = False
        TXT_Agency_Comm_In_Per.Visible = False
        TXT_Profit_Rs_Per_Mtr.Visible = False
        txt_grad_exp_amt.Visible = False
        txt_value_loss_amt.Visible = False
        txt_sample_amt.Visible = False
        txt_tour_exp_amt.Visible = False
        txt_over_amt.Visible = False
        txt_packing_amt.Visible = False
        txt_salary_amt.Visible = False
        txt_credit_days_amt.Visible = False
        txt_int_amt.Visible = False
        txt_mis_amt.Visible = False
        txt_agcomm_amt.Visible = False
        txt_profit_amt.Visible = False
        TXT_Net_Sales_Cost.Visible = False

        txt_FD_PD.Visible = False
        txt_Total_Ends.Visible = False
        txt_Loom.Visible = False
        TXT_Final_Grey_Cost.Visible = False
    End Sub
#End Region

#Region "CTRL VISIBLE TRUE"
    Private Sub Cost_Sheet_Ctrl_Visible_True()
        GrdItem.Enabled = True

        txt_EntryNo.Visible = True
        txt_Entry_Date.Visible = True
        txt_Fabric_Item_name.Visible = True
        txt_reed.Visible = True
        txt_dent.Visible = True
        txt_pick.Visible = True
        txt_reed_space.Visible = True
        txt_yarn_west_per.Visible = True
        txt_yarn_west_amt.Visible = True
        txt_Net_Yarn_Cost.Visible = True
        txt_per_pick_amt.Visible = True
        TXT_Mending_Rate_Per_Mtr.Visible = True
        TXT_Monogram_Rate_Per_Mtr.Visible = True
        TXT_Net_Weaving_Cost.Visible = True
        TXT_Net_Grey_Cost.Visible = True
        TXT_Process_Rate_Per_Mtr.Visible = True
        TXT_Shrinkage_in_Per.Visible = True
        TXT_Net_Finish_Cost.Visible = True
        txt_sample_exp_per_mtr.Visible = True
        txt_tour_exp_per_mtr.Visible = True
        TXT_OverHead_Per_Mtr.Visible = True
        txt_grading_exp_per_mtr.Visible = True
        txt_VALUE_LOSS_PER_MTR.Visible = True
        txt_packing_exp_per_mtr.Visible = True
        txt_salary_exp_per_mtr.Visible = True
        txt_credit_days.Visible = True
        TXT_Interest_In_Per.Visible = True
        txt_mis_exp_per_mtr.Visible = True
        TXT_Agency_Comm_In_Per.Visible = True
        TXT_Profit_Rs_Per_Mtr.Visible = True
        TXT_Net_Sales_Cost.Visible = True
        txt_yarn_Sub_Total_amt.Visible = True
        txt_yarn_exp_per.Visible = True
        txt_yarn_int_per.Visible = True
        txt_yarn_exp_amt.Visible = True
        txt_yarn_int_amt.Visible = True
        txt_Weaving_rate_per_Pick.Visible = True
        TXT_Mending_Rate_Per_Mtr.Visible = True
        TXT_Monogram_Rate_Per_Mtr.Visible = True
        txt_SELV_PER_MTR.Visible = True
        txt_per_pick_amt.Visible = True
        txt_mend_amt.Visible = True
        txt_selv_amt.Visible = True
        TXT_Net_Weaving_Cost.Visible = True
        TXT_Net_Grey_Cost.Visible = True
        TXT_Process_Rate_Per_Mtr.Visible = True
        TXT_Shrinkage_in_Per.Visible = True
        txt_process_amt.Visible = True
        txt_shk_amt.Visible = True
        txt_process_cost.Visible = True
        TXT_Net_Finish_Cost.Visible = True
        TXT_OverHead_Per_Mtr.Visible = True
        TXT_Interest_In_Per.Visible = True
        TXT_Agency_Comm_In_Per.Visible = True
        TXT_Profit_Rs_Per_Mtr.Visible = True
        txt_grad_exp_amt.Visible = True
        txt_value_loss_amt.Visible = True
        txt_sample_amt.Visible = True
        txt_tour_exp_amt.Visible = True
        txt_over_amt.Visible = True
        txt_packing_amt.Visible = True
        txt_salary_amt.Visible = True
        txt_credit_days_amt.Visible = True
        txt_int_amt.Visible = True
        txt_mis_amt.Visible = True
        txt_agcomm_amt.Visible = True
        txt_profit_amt.Visible = True
        TXT_Net_Sales_Cost.Visible = True
        txt_FD_PD.Visible = True
        txt_Total_Ends.Visible = True
        txt_Loom.Visible = True
        TXT_Final_Grey_Cost.Visible = True
    End Sub
#End Region


#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*,")
            .Append(" FORMAT(A.ENTRY_DATE,'dd/MM/yyyy') AS F_OFFERDATE,")
            .Append(" B.COUNTNAME ")
            .Append(" FROM TRNFABRICCOST A LEFT JOIN MSTYARNCOUNT B ON A.COUNTCODE=B.COUNTCODE")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.ENTRYNO=" & Val(strKeyID) & " ")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return _strQuery.ToString
    End Function
#End Region

#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Cost_Sheet_Ctrl_Visible_False()
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)

        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy

        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)

        txt_Fabric_Item_name.Text = tblTmp.Rows(0)("FABRIC_ITEM_NAME").ToString
        txt_Entry_Date.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        txt_FabricItemCode.Text = tblTmp.Rows(0)("Fabric_Design_No").ToString

        lbl_AvgWt.Text = tblTmp.Compute("SUM(AVG_WEIGHT)", "").ToString
        txt_yarn_Sub_Total_amt.Text = tblTmp.Compute("SUM(YARN_AMOUNT)", "").ToString

        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)
        GrdItem.Rows = GrdItem.Rows + 1

        GrdItem.Refresh()
        GrdItem.Visible = True

        Cost_Sheet_Ctrl_Visible_True()
        _FrmLoad = False
    End Sub
#End Region

#Region "GRID GENERAL FUNCTION"
    Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If

        If grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If
    End Sub
#End Region



#Region "TOTAL ALL ROWS"
    Private Sub Total_Upto_All_Grid_All_Row()
        Dim Tot_Mtr_Weight As Double = 0
        Dim Tot_Bale_Pcs As Double
        For j As Int16 = 0 To GrdItem.Rows - 1
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
            Tot_Bale_Pcs = Tot_Bale_Pcs + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("PCS_BALES") + 1).Text)
        Next
        'Lbl_Tot_Mtr_Weight.Text = Tot_Mtr_Weight
        'lbl_Tot_Bales.Text = Tot_Bale_Pcs
        'Lbl_Tot_Mtr_Weight.Text = IIf(Tot_Mtr_Weight > 0, Format(lbl_Tot_Bales.Text, "0.00"), "")
        'lbl_Tot_Bales.Text = IIf(Tot_Bale_Pcs > 0, Format(lbl_Tot_Bales.Text, "0"), "")
    End Sub
#End Region

#Region "DELETE CODE"
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        _FrmLoad = True
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).ClearText()
        GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = GrdObj.ActiveCell.Row
        _FrmLoad = False
    End Sub
    Private Sub Delete_Entry()
        _FrmLoad = True
        Dim I As Integer = 0
        Dim _LastID As Integer = 0

        _strQuery = New StringBuilder

        Try
            strQuery = " DELETE FROM trnfabriccost WHERE entryno=" & Val(txt_EntryNo.Text) & " "
            sqL = strQuery.ToString
            sql_Data_Save_Delete_Update()
            '-----------------------------------------------------------------------

            _KeyFieldValue = 0
            _FORMMODE = "ADD"

            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted")
            Old_Date = txt_Entry_Date.Text
            ObjCls_General.Blank_Object(Me)
            txt_Entry_Date.Text = Old_Date
        Catch ex As Exception

            MsgBox("Error While Delete Entry")
        Finally
            cmd = Nothing
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
        Dim CountCode As String = ""
        Dim Yarn_Rate As Double = 0

        CountCode = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COUNTCODE") + 1).Text
        Yarn_Rate = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text)

        If CountCode = "" Or Yarn_Rate = 0 Then
            If _ActivatedColName = "YARN_AMOUNT" Then
                e.Cancel = True
                If CountCode = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COUNTNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf Yarn_Rate = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).SetFocus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub grditem_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GrdItem.KeyPress
        If _FrmLoad = True Then Exit Sub

        If Validate_All_Upper_Rows_For_Grid_Item() = False Then
            If GrdItem.ActiveCell.Row > 1 Then
                MsgBox("Invalid Upper Record/Rows")
                e.KeyChar = ""
                Exit Sub
            End If
        End If

        GrdItem.ActiveCell.BackColor = Color.Transparent

        If _ActivatedColName = "PATTERN" Then
            Rate_Calc()
        ElseIf _ActivatedColName = "YARN_FOR" Then
            Dim Yarn_For_Value As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf(_ActivatedColName) + 1).Text
            If Asc(e.KeyChar) = 32 Then
                If Yarn_For_Value = "" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "WARP"
                ElseIf Yarn_For_Value = "WARP" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "WEFT"
                ElseIf Yarn_For_Value = "WEFT" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "MONO"
                ElseIf Yarn_For_Value = "MONO" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "SELV"
                ElseIf Yarn_For_Value = "SELV" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "LINO"
                ElseIf Yarn_For_Value = "LINO" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "WARP"

                End If
            Else
                If e.KeyChar.ToString.ToUpper = "W" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = e.KeyChar.ToString.ToUpper & "ARP"
                ElseIf e.KeyChar.ToString.ToUpper = "M" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = e.KeyChar.ToString.ToUpper & "ONO"
                ElseIf e.KeyChar.ToString.ToUpper = "S" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = e.KeyChar.ToString.ToUpper & "ELV"
                ElseIf e.KeyChar.ToString.ToUpper = "L" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = e.KeyChar.ToString.ToUpper & "INO"
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub
    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub

        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text = "WARP"

        If _ActivatedColName = "COUNTNAME" Then

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
                txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COUNTNAME") + 1).Text
                txt_Code_For_Grid_Selection.Text = ""
                Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                obj_Party_Selection.SINGLE_YarnItem_SELECTION()
                txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA

                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COUNTNAME") + 1).Text = txt_Name_For_Grid_Selection.Text
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COUNTCODE") + 1).Text = txt_Code_For_Grid_Selection.Text
                If txt_Name_For_Grid_Selection.Text <> "" Then
                    SendKeys.Send("{RIGHT}")
                End If
                txt_Name_For_Grid_Selection.Text = ""
                Dim Count_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COUNTCODE") + 1).Text
                Dim Str_Qry As String = "select top 1 netcount from mstyarncount where countcode='" & Count_Code & "'"
                Dim Net_Cnt As Double = 0
                sqL = Str_Qry
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    Net_Cnt = (DefaltSoftTable.Rows(0).Item(0))
                End If

                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NETCOUNT") + 1).Text = Net_Cnt

                If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text) = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text = 1
                End If
                Rate_Calc()
            End If
        ElseIf _ActivatedColName = "YARN_RATE" Then
            Dim Avg_Wt As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text)
            Dim Yarn_Rate As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text)
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text = Yarn_Rate * Avg_Wt
            Call Rate_Calc()
        ElseIf _ActivatedColName = "PROFIT_PER" Then
            If e.KeyCode = 13 Then
                Dim Avg_Wt As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text)
                Dim Yarn_Rate As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text)
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text = Yarn_Rate * Avg_Wt
                Call Rate_Calc()
            End If
        ElseIf _ActivatedColName = "YARN_AMOUNT" Then
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdItem.ActiveCell.Row
                Dim Count_Code As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("COUNTCODE") + 1).Text
                Dim Yarn_Amt As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
                If Count_Code = "" Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("COUNTNAME") + 1).Text = ""
                End If
                Yarn_Amt = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
                If Yarn_Amt = 0 Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text = ""
                End If

                If Count_Code <> "" And Yarn_Amt <> 0 Then
                    If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                        GrdItem.Rows = GrdItem.Rows + 1
                        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    End If
                Else
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                End If
            End If
        End If
    End Sub
    Private Function Validate_All_Upper_Rows_For_Grid_Item()
        Dim Return_Flag As Boolean = True
        If GrdItem.ActiveCell.Row > 1 Then
            Dim i As Integer = GrdItem.ActiveCell.Row - 1
            Dim Count_Code As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("countcode") + 1).Text
            Dim Yarn_Amt As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("yarn_amount") + 1).Text)
            Dim Yarn_Rate As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("yarn_rate") + 1).Text)
            If Count_Code = "" Or Yarn_Amt = 0 Or Yarn_Rate = 0 Then
                Return_Flag = False
            End If
        End If
        Return Return_Flag
    End Function
#End Region


#Region "TXT BOX ENTRY NO EVENT CODE"
    Private Sub txtEntryNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_EntryNo.KeyDown
        If _FrmLoad = True Then Exit Sub
        If e.KeyCode = Keys.PageDown Then
            If Val(txt_EntryNo.Text) < Val(_Last_Saved_Entry_No) Then
                txt_EntryNo.Text = Val(txt_EntryNo.Text) + 1
                Dim Book_Vno As String = Generate_Book_Vno(txt_EntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _OfferTableName)
                txt_EntryNo.Focus()
            End If
        ElseIf e.KeyCode = Keys.PageUp Then
            If Val(txt_EntryNo.Text) > 1 Then
                If Val(txt_EntryNo.Text) <= _Last_Saved_Entry_No Then
                    txt_EntryNo.Text = Val(txt_EntryNo.Text) - 1
                    Dim Book_Vno As String = Generate_Book_Vno(txt_EntryNo.Text, _BookTrType)
                    Call Validate_Entry_No(Book_Vno, _OfferTableName)
                    txt_EntryNo.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtEntryNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_EntryNo.Validated
        If _FrmLoad = True Then Exit Sub
        If Val(txt_EntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No")
            txt_EntryNo.Focus()
            txt_EntryNo.Select()
            Exit Sub
        Else
            Dim BookVno As String = Generate_Book_Vno(Val(txt_EntryNo.Text), _BookTrType)
            _BookVNo = BookVno
            Call Validate_Entry_No(BookVno, _OfferTableName)
        End If
        If _FORMMODE = "ADD" Then
            'If txtOfferNO.Text = "" Then
            '    txtOfferNO.Text = txtEntryNo.Text
            'End If
        End If
    End Sub
    Private Sub Validate_Entry_No(ByVal Book_Vno As String, ByVal Table_Name As String)

        strQuery = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " WHERE ENTRYNO=" & Val(txt_EntryNo.Text) & " "
        _TransctionNo = 0

        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = (DefaltSoftTable.Rows(0).Item(0))
        End If

        If _TransctionNo > 0 Then
            If _FORMMODE = "ADD" Then
                MsgBox("Entry No Already Exist")
                txt_EntryNo.Focus()
                txt_EntryNo.Select()
            ElseIf _FORMMODE = "EDIT" Then
                _FrmLoad = True
                Call Alter_Form(txt_EntryNo.Text)
                btnSave.Enabled = True
                txt_EntryNo.Focus()
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                Cost_Sheet_Ctrl_Visible_True()
                Change_Grid_Data = True
                GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                _FrmLoad = False
                Rate_Calc()
                txt_Entry_Date.Select()
                txt_Entry_Date.Select()
            ElseIf _FORMMODE = "DELETE" Then
                _FrmLoad = True
                Call Alter_Form(txt_EntryNo.Text)
                Rate_Calc()
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice, Can't Delete", MsgBoxStyle.Information, "Soft-Tex ERP")
                Else
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Call Delete_Entry()
                    End If
                End If
                Clear_Grid(GrdItem, 2)
                Call Cost_Sheet_Ctrl_Visible_False()
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
                Call Cost_Sheet_Ctrl_Visible_False()
                MsgBox("Entry No " + Trim(txt_EntryNo.Text) + " Not Found")
                txt_EntryNo.Visible = True
                txt_EntryNo.Focus()
                txt_EntryNo.Select()
            End If
        End If
    End Sub
#End Region


#Region "VIEW RECORD "
    Private Sub btn_View_Ok_Click(sender As Object, e As EventArgs) Handles btn_View_Ok.Click
        View_Record()
    End Sub
    Private Sub View_Record()



        Generate_Date_For_DataBase(Txt_ViewFrom)
        Generate_Date_For_DataBase(Txt_ViewTO)


        Dim View_Filter_Condition = " AND A.Entry_Date>='" & Txt_ViewFrom.Date_for_Database & "' AND A.Entry_Date<='" & Txt_ViewTO.Date_for_Database & "'  "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.EntryNo AS EntryNo")
            .Append(" ,format(A.Entry_Date ,'dd/MM/yyyy') as EntDate")
            .Append(" ,A.Fabric_Item_Name AS Item")
            .Append(" ,A.Reed ")
            .Append(" ,A.Dent")
            .Append(" ,A.Pick")
            .Append(" ,A.Reed_Space as ReadSp")
            .Append(" ,A.Net_Yarn_Cost as YarnCost")
            .Append(" ,A.Net_Weaving_Cost as GreyCost")
            .Append(" ,A.process_cost as ProcessCost")
            .Append(" ,a.Net_Sales_Cost as SalesCost")
            .Append(" FROM TrnFabricCost AS A ")
            .Append(" WHERE 1=1")

            .Append(View_Filter_Condition)
            .Append(" group BY ")
            .Append(" A.EntryNo")
            .Append(" ,A.Entry_Date")
            .Append(" ,A.Fabric_Item_Name")
            .Append(" ,A.Reed ")
            .Append(" ,A.Dent")
            .Append(" ,A.Pick")
            .Append(" ,A.Reed_Space ")
            .Append(" ,A.Net_Yarn_Cost ")
            .Append(" ,A.Net_Grey_Cost ")
            .Append(" ,A.Net_Finish_Cost ")
            .Append(" ,a.Net_Sales_Cost ")
            .Append(" ,a.Net_Weaving_Cost ")
            .Append(" ,a.process_cost ")

            .Append(" ORDER BY A.EntryNo,A.Entry_Date")


        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As DataTable

        tblTmp = DefaltSoftTable.Copy
        FirstStage.Columns.Clear()
        Dim Qty As String = ""
        If tblTmp.Rows.Count > 0 Then

            GridControl1.DataSource = tblTmp.Copy

            DevGridFitColumn(GridControl1, FirstStage)

            PnlGrdView.Visible = True
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            PnlGrdView.BringToFront()
            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        End If
    End Sub
#End Region

#Region "GRID VIEW EVENTS CODE"
    Private Sub grdView_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            PnlGrdView.Visible = False
            Call Command_Button_Visibility("LOAD")
            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Me.Text = _old_Me_text
            _FORMMODE = ""
        End If
    End Sub
#End Region

#Region "DATE RANGE CHECK"
    Private Sub txtOfferDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Entry_Date.Validated
        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information, "Soft-Tex ERP")
                txt_Entry_Date.Focus()
                txt_Entry_Date.Select()
            End If
        End If
    End Sub
#End Region


#Region "Check Adjustment Agnst Offer"
    Private Function Is_Adjusted_Offer() As Boolean
        Dim Total_Record As Integer = 0
        Dim Return_Value As Boolean = False
        Dim Tmp_Data_Table As New DataTable
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.OFFERBOOKVNO ")
            .Append(" FROM TRNINVOICEDETAIL A ")
            .Append(" WHERE A.PARTYCODE='" & txtParty_code.Text & "' ")
            .Append(" AND A.SUPPCODE='" & txtSupp_code.Text & "' ")
            .Append(" AND A.OFFERBOOKVNO='" & _BookVNo & "' ")
        End With
        strQuery = _strQuery.ToString


        sqL = _strQuery.ToString
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

    Private Sub txt_Loom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Loom.LostFocus
        If _FrmLoad = True Then Exit Sub
        GrdItem.Focus()
        GrdItem.Select()
    End Sub


#Region "VALIDATE ALL TEXT BOXES "
    Private Sub txt_yarn_exp_per_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_yarn_exp_per.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_yarn_int_per_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_yarn_int_per.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_yarn_west_per_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_yarn_west_per.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_Weaving_rate_per_Pick_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Weaving_rate_per_Pick.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_Mending_Rate_Per_Mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Mending_Rate_Per_Mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_Monogram_Rate_Per_Mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Monogram_Rate_Per_Mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_SELV_PER_MTR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SELV_PER_MTR.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_Process_Rate_Per_Mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Process_Rate_Per_Mtr.Validated
        Rate_Calc()
    End Sub

    Private Sub Txt_CdPerMtr_Validated(sender As Object, e As EventArgs) Handles Txt_CdPerMtr.Validated
        Rate_Calc()
    End Sub

    Private Sub Txt_AgencyPerMtr_Validated(sender As Object, e As EventArgs) Handles Txt_AgencyPerMtr.Validated
        Rate_Calc()
    End Sub

    Private Sub Txt_ProftPerMtr_Validated(sender As Object, e As EventArgs) Handles Txt_ProftPerMtr.Validated
        Rate_Calc()
    End Sub

    Private Sub TXT_Shrinkage_in_Per_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Shrinkage_in_Per.Validated
        Rate_Calc()
    End Sub

    Private Sub txt_grading_exp_per_mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_grading_exp_per_mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_VALUE_LOSS_PER_MTR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_VALUE_LOSS_PER_MTR.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_sample_exp_per_mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_sample_exp_per_mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_tour_exp_per_mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_tour_exp_per_mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_OverHead_Per_Mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_OverHead_Per_Mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_packing_exp_per_mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_packing_exp_per_mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_salary_exp_per_mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_salary_exp_per_mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_credit_days_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_credit_days.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_Interest_In_Per_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Interest_In_Per.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_mis_exp_per_mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_mis_exp_per_mtr.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_Agency_Comm_In_Per_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Agency_Comm_In_Per.Validated
        Rate_Calc()
    End Sub
    Private Sub TXT_Profit_Rs_Per_Mtr_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Profit_Rs_Per_Mtr.Validated
        Rate_Calc()
    End Sub
#End Region

#Region "ALL RATES CALC SYSTEM "
    Private Sub Calc_Total_Ends()
        Dim Reed_Value As Double = 0
        Dim Extra_Reed_Value As Double = 0
        Dim Dent_Value As Double = Val(txt_dent.Text)

        If Dent_Value > 2 Then
            Reed_Value = Val(txt_reed.Text) / 2
            Extra_Reed_Value = Reed_Value * (Dent_Value - 2)
            Reed_Value = Val(txt_reed.Text) + Extra_Reed_Value
        ElseIf Dent_Value = 2 Then
            Reed_Value = Val(txt_reed.Text) / Val(txt_dent.Text)
        End If

        Dim RS_Value As Double = Val(txt_reed_space.Text)

        If Dent_Value = 2 Then
            txt_Total_Ends.Text = (Reed_Value * RS_Value) * 2
        Else
            txt_Total_Ends.Text = (Reed_Value * RS_Value)
        End If
    End Sub
    Private Sub Rate_Calc()
        If _FrmLoad = True Then Exit Sub
        Calc_Total_Ends()

        If TXT_Mending_Rate_Per_Mtr.Text = "" Then TXT_Mending_Rate_Per_Mtr.Text = 0
        If txt_SELV_PER_MTR.Text = "" Then txt_SELV_PER_MTR.Text = 0
        If TXT_Monogram_Rate_Per_Mtr.Text = "" Then TXT_Monogram_Rate_Per_Mtr.Text = 0
        If Txt_AgencyPerMtr.Text = "" Then Txt_AgencyPerMtr.Text = 0
        If Txt_ProftPerMtr.Text = "" Then Txt_ProftPerMtr.Text = 0



        Dim Tot_AvgWt As Double = 0
        Dim Tot_Cost_Amt As Double = 0
        Dim Yarn_For As String = ""
        Dim Avg_Wt As Double = 0
        Dim Count_Code As String = ""
        Dim Str_Qry As String = ""
        Dim Net_Cnt As Double = 0
        Dim Net_Reed As Double = 0
        Dim Yarn_Rate As Double = 0
        Dim Total_Warp_Pattern As Double = 0
        Dim Total_Weft_Pattern As Double = 0
        Dim Row_Pattern As Double = 0
        If TXT_Final_Grey_Cost.Text = "" Then TXT_Final_Grey_Cost.Text = "0.00"
        For i As Int16 = 1 To GrdItem.Rows - 1
            Yarn_For = Trim(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text)
            If Yarn_For = "WARP" Then
                Total_Warp_Pattern = Total_Warp_Pattern + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text)
            End If
            If Yarn_For = "WEFT" Then
                Total_Weft_Pattern = Total_Weft_Pattern + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text)
            End If
        Next

        '------------------- yarn Start
        For i As Int16 = 1 To GrdItem.Rows - 1
            '--Avg Wt & Amt Start
            Row_Pattern = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text)
            Count_Code = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("COUNTCODE") + 1).Text
            Str_Qry = "Select top 1 netcount from mstyarncount where countcode='" & Count_Code & "'"
            Net_Cnt = 0
            sqL = Str_Qry
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                Net_Cnt = (DefaltSoftTable.Rows(0).Item(0))
            End If

            GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("NETCOUNT") + 1).Text = Net_Cnt
            Yarn_For = Trim(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text)
            If Yarn_For = "WARP" Then
                Net_Reed = (Val(txt_reed.Text) / 2) * Val(txt_dent.Text)
                Avg_Wt = (Net_Reed * Val(txt_reed_space.Text) * 0.64) / (Net_Cnt * 1000)
                Avg_Wt = (Avg_Wt / Total_Warp_Pattern) * Row_Pattern
                GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text = Avg_Wt
            ElseIf Yarn_For = "WEFT" Then
                Avg_Wt = (Val(txt_pick.Text) * Val(txt_reed_space.Text) * 0.6) / (Net_Cnt * 1000)
                Avg_Wt = (Avg_Wt / Total_Weft_Pattern) * Row_Pattern
                GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text = Avg_Wt
            End If

            Avg_Wt = (Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PROFIT_PER") + 1).Text))
            Yarn_Rate = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text)


            GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text = Yarn_Rate * Avg_Wt
            If Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text) = 0 Then
                GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text = ""
            End If

            Tot_AvgWt = Tot_AvgWt + (Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PROFIT_PER") + 1).Text))
            Tot_Cost_Amt = Tot_Cost_Amt + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
        Next
        '--Avg Wt & Amt Finish

        Tot_AvgWt = Math.Round(Tot_AvgWt, 3)
        Tot_Cost_Amt = Math.Round(Tot_Cost_Amt, 2)
        lbl_AvgWt.Text = FormatNumber(Tot_AvgWt, 3, TriState.True, TriState.False, TriState.False)
        txt_yarn_Sub_Total_amt.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)

        txt_Net_Yarn_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Grey_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Finish_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)

        txt_yarn_exp_amt.Text = FormatNumber(Math.Round(Val(txt_yarn_exp_per.Text) * Tot_Cost_Amt / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_yarn_exp_amt.Text)

        txt_Net_Yarn_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Grey_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Finish_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)


        txt_yarn_int_amt.Text = FormatNumber(Math.Round(Val(txt_yarn_int_per.Text) * Tot_Cost_Amt / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_yarn_int_amt.Text)


        txt_yarn_west_amt.Text = FormatNumber(Math.Round(Val(txt_yarn_west_per.Text) * Tot_Cost_Amt / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_yarn_west_amt.Text)

        txt_Net_Yarn_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Grey_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Finish_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)


        txt_Net_Yarn_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Grey_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Finish_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        '------------------- yarn Finish

        '------------------- Weaving Start

        Dim Weave_Rate As Double = FormatNumber(Math.Round(Val(txt_Weaving_rate_per_Pick.Text) * Val(txt_pick.Text), 3), 2, TriState.True, TriState.False, TriState.False)
        txt_per_pick_amt.Text = FormatNumber(Weave_Rate, 4, TriState.True, TriState.False, TriState.False)
        txt_mend_amt.Text = FormatNumber(Val(TXT_Mending_Rate_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_mono_amt.Text = FormatNumber(Val(TXT_Monogram_Rate_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_selv_amt.Text = FormatNumber(Val(txt_SELV_PER_MTR.Text), 2, TriState.True, TriState.False, TriState.False)


        Dim _proftcost As Double = (Weave_Rate + Val(TXT_Mending_Rate_Per_Mtr.Text) _
                                                            + Val(txt_Net_Yarn_Cost.Text) _
                                                            + Val(txt_SELV_PER_MTR.Text) _
                                                            + Val(TXT_Monogram_Rate_Per_Mtr.Text) _
                                                            + Val(Txt_ProftPerMtr_Amt.Text))


        'Dim _proftper As Double = _proftcost * Val(Txt_ProftPerMtr.Text) / 100

        'Txt_ProftPerMtr_Amt.Text = FormatNumber(Val(_proftper), 2, TriState.True, TriState.False, TriState.False)
        Txt_ProftPerMtr_Amt.Text = FormatNumber(Val(Txt_ProftPerMtr.Text), 2, TriState.True, TriState.False, TriState.False)

        'Dim _cdmtrper As Double = _proftcost + Txt_ProftPerMtr_Amt.Text
        Dim _cdmtrper As Double = _proftcost

        Dim _CDAMOUNT As Double = _cdmtrper * Val(Txt_CdPerMtr.Text) / 100



        'Txt_CdPerMtrAmt.Text = FormatNumber(Val(Txt_CdPerMtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Txt_CdPerMtrAmt.Text = FormatNumber(Val(_CDAMOUNT), 2, TriState.True, TriState.False, TriState.False)


        Dim _AGENCYPER As Double = _proftcost + Txt_CdPerMtrAmt.Text
        Dim _AGENCYAMT As Double = _AGENCYPER * Val(Txt_AgencyPerMtr.Text) / 100



        'Txt_AgencyPerMtr_Amt.Text = FormatNumber(Val(Txt_AgencyPerMtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Txt_AgencyPerMtr_Amt.Text = FormatNumber(Val(_AGENCYAMT), 2, TriState.True, TriState.False, TriState.False)




        TXT_Net_Weaving_Cost.Text = FormatNumber(Math.Round(Weave_Rate + Val(TXT_Mending_Rate_Per_Mtr.Text) _
                                                            + Val(txt_SELV_PER_MTR.Text) _
                                                            + Val(TXT_Monogram_Rate_Per_Mtr.Text _
                                                            + Val(Txt_CdPerMtrAmt.Text) _
                                                            + Val(Txt_AgencyPerMtr_Amt.Text) _
                                                            + Val(Txt_ProftPerMtr_Amt.Text)
                                                             ), 3), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(TXT_Net_Weaving_Cost.Text)



        TXT_Net_Grey_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Finish_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        '------------------- Weaving Finish

        If Val(TXT_Net_Grey_Cost.Text) > 0 Then TXT_Final_Grey_Cost.Text = TXT_Net_Grey_Cost.Text
        If Val(Tot_Cost_Amt) = 0 Then Tot_Cost_Amt = TXT_Final_Grey_Cost.Text

        '------------------- Processing/Finish Start
        txt_process_amt.Text = FormatNumber(Val(TXT_Process_Rate_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        'txt_shk_amt.Text = FormatNumber(Math.Round((Val(TXT_Net_Grey_Cost.Text) * Val(TXT_Shrinkage_in_Per.Text)) / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        txt_shk_amt.Text = FormatNumber(Math.Round((Val(TXT_Final_Grey_Cost.Text) * Val(TXT_Shrinkage_in_Per.Text)) / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        txt_process_cost.Text = FormatNumber(Val(txt_process_amt.Text) + Val(txt_shk_amt.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_process_cost.Text)

        TXT_Net_Finish_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        '------------------- Processing/Finish Finish


        '------------------- Sales Start
        txt_grad_exp_amt.Text = FormatNumber(Val(txt_grading_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_grad_exp_amt.Text)

        txt_value_loss_amt.Text = FormatNumber(Math.Round((Val(TXT_Net_Finish_Cost.Text) * Val(txt_VALUE_LOSS_PER_MTR.Text)) / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_value_loss_amt.Text)

        txt_sample_amt.Text = FormatNumber(Val(txt_sample_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_sample_amt.Text)

        txt_tour_exp_amt.Text = FormatNumber(Val(txt_tour_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_tour_exp_amt.Text)

        txt_over_amt.Text = FormatNumber(Val(TXT_OverHead_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_over_amt.Text)

        txt_packing_amt.Text = FormatNumber(Val(txt_packing_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_packing_amt.Text)

        txt_salary_amt.Text = FormatNumber(Val(txt_salary_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_salary_amt.Text)

        Dim Int_Calc_Amt As Double = Val(TXT_Net_Finish_Cost.Text) + Val(txt_grad_exp_amt.Text) + Val(txt_value_loss_amt.Text) + Val(txt_sample_amt.Text) + Val(txt_tour_exp_amt.Text) + Val(txt_over_amt.Text) + Val(txt_packing_amt.Text) + Val(txt_salary_amt.Text)
        txt_int_amt.Text = FormatNumber(Math.Round((Int_Calc_Amt * Val(TXT_Interest_In_Per.Text)) / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_int_amt.Text)

        txt_mis_amt.Text = FormatNumber(Val(txt_mis_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_mis_amt.Text)

        Dim Comm_Calc_Amt As Double = Int_Calc_Amt + Val(txt_int_amt.Text) + Val(txt_mis_amt.Text)
        txt_agcomm_amt.Text = FormatNumber(Math.Round((Comm_Calc_Amt * Val(TXT_Agency_Comm_In_Per.Text)) / 100, 2), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_agcomm_amt.Text)

        txt_profit_amt.Text = FormatNumber(Val(TXT_Profit_Rs_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        Tot_Cost_Amt = Tot_Cost_Amt + Val(txt_profit_amt.Text)

        TXT_Net_Sales_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        '------------------- Sales Finish


        '----------
        txt_yarn_exp_per.Text = FormatNumber(Val(txt_yarn_exp_per.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_yarn_west_per.Text = FormatNumber(Val(txt_yarn_west_per.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_yarn_int_per.Text = FormatNumber(Val(txt_yarn_int_per.Text), 2, TriState.True, TriState.False, TriState.False)

        txt_Weaving_rate_per_Pick.Text = FormatNumber(Val(txt_Weaving_rate_per_Pick.Text), 4, TriState.True, TriState.False, TriState.False)
        TXT_Mending_Rate_Per_Mtr.Text = FormatNumber(Val(TXT_Mending_Rate_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        TXT_Monogram_Rate_Per_Mtr.Text = FormatNumber(Val(TXT_Monogram_Rate_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_SELV_PER_MTR.Text = FormatNumber(Val(txt_SELV_PER_MTR.Text), 2, TriState.True, TriState.False, TriState.False)

        TXT_Process_Rate_Per_Mtr.Text = FormatNumber(Val(TXT_Process_Rate_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        TXT_Shrinkage_in_Per.Text = FormatNumber(Val(TXT_Shrinkage_in_Per.Text), 2, TriState.True, TriState.False, TriState.False)

        txt_grading_exp_per_mtr.Text = FormatNumber(Val(txt_grading_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_VALUE_LOSS_PER_MTR.Text = FormatNumber(Val(txt_VALUE_LOSS_PER_MTR.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_sample_exp_per_mtr.Text = FormatNumber(Val(txt_sample_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_tour_exp_per_mtr.Text = FormatNumber(Val(txt_tour_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        TXT_OverHead_Per_Mtr.Text = FormatNumber(Val(TXT_OverHead_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_packing_exp_per_mtr.Text = FormatNumber(Val(txt_packing_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_salary_exp_per_mtr.Text = FormatNumber(Val(txt_salary_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        TXT_Interest_In_Per.Text = FormatNumber(Val(TXT_Interest_In_Per.Text), 2, TriState.True, TriState.False, TriState.False)
        txt_mis_exp_per_mtr.Text = FormatNumber(Val(txt_mis_exp_per_mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        TXT_Agency_Comm_In_Per.Text = FormatNumber(Val(TXT_Agency_Comm_In_Per.Text), 2, TriState.True, TriState.False, TriState.False)
        TXT_Profit_Rs_Per_Mtr.Text = FormatNumber(Val(TXT_Profit_Rs_Per_Mtr.Text), 2, TriState.True, TriState.False, TriState.False)
        '----------
    End Sub
#End Region

    Private Sub TXT_Net_Sales_Cost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_Net_Sales_Cost.KeyDown
        If e.KeyCode = 13 Then
            btnSave.Focus()
            btnSave.Select()
        End If
    End Sub
    Private Sub txt_reed_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_reed.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_dent_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dent.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_pick_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_pick.Validated
        Rate_Calc()
    End Sub
    Private Sub txt_reed_space_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_reed_space.Validated
        Rate_Calc()
    End Sub

#Region "PRINT CODE "
    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        _strQuery = New StringBuilder
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*,A.FABRIC_ITEM_NAME AS ITEMNAME, ")
            .Append(" FORMAT(A.ENTRY_DATE,'dd/MM/yyyy') AS BILLDATE,")
            .Append(" B.COUNTNAME AS SHORTNARR,STR(B.PLY)+'/'+STR(B.YCOUNT) AS BOOKNAME,B.NETCOUNT ")
            .Append(",A.Avg_weight AS Avgweight ")
            .Append(",LTRIM (CAST(A.REED AS decimal(38,0)))  + '/' +LTRIM (CAST(A.DENT AS decimal(38,0)))  AS ACKNO ")
            .Append(",(A.REED/2) * A.DENT AS TLRATE ")
            .Append(" FROM TRNFABRICCOST A,MSTYARNCOUNT B ")
            .Append(" WHERE 1=1 AND A.COUNTCODE=B.COUNTCODE  ")
            .Append(" AND A.ENTRYNO>=" & Val(txt_From.Text) & " ")
            .Append(" AND A.ENTRYNO<=" & Val(txt_To.Text) & " ")
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With
        strQuery = _strQuery.ToString
        If txt_Print_For.Text = "FINISH" Then
            'Print_Preview(strQuery, IIf(txt_Paper_Type.Text = "PLAIN", "Fabric_Cost_Sheet_2", "Fabric_Cost_Sheet_1P"), "CONSTRUCTION/COST SHEET", "", True)
        Else
            'Print_Preview(strQuery, IIf(txt_Paper_Type.Text = "PLAIN", "Fabric_Cost_Sheet_1", "Fabric_Cost_Sheet_2P"), "CONSTRUCTION/COST SHEET", "", True)
        End If
        pnl_Print.Visible = False
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    End Sub

    Private Sub pnl_Print_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnl_Print.Validated
        pnl_Print.Visible = False
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    End Sub
#End Region

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST ORDER BY ENTRYNO DESC"
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txt_From.Text = Val(DefaltSoftTable.Rows(0).Item(0))
            txt_To.Text = Val(DefaltSoftTable.Rows(0).Item(0))
        End If
        If txt_Paper_Type.Text = "" Then txt_Paper_Type.Text = "PLAIN"
        If txt_Print_For.Text = "" Then txt_Print_For.Text = "FINISH"

        pnl_Print.Visible = True
        txt_From.Focus()
        txt_From.SelectAll()
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click

        pnl_Print.Visible = False

        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)

    End Sub

    Private Sub TXT_Final_Grey_Cost_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TXT_Final_Grey_Cost.Validating
        Rate_Calc()
    End Sub

    Private Sub txt_Fabric_Item_name_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Fabric_Item_name.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = txt_Fabric_Item_name.Text
            Party_selection.txtSearch.SelectAll()
            obj_Party_Selection.SINGLE_ITEM_SELECTION()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                txt_Fabric_Item_name.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_FabricItemCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If

            If _FORMMODE = "ADD" Then
                sqL = "SELECT*FROM MstFabricItem WHERE ID='" & txt_FabricItemCode.Text & "'"
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    txt_reed.Text = DefaltSoftTable.Rows(0).Item("REED").ToString
                    txt_dent.Text = DefaltSoftTable.Rows(0).Item("OP22").ToString
                    txt_pick.Text = DefaltSoftTable.Rows(0).Item("PICK").ToString
                    txt_reed_space.Text = DefaltSoftTable.Rows(0).Item("OP23").ToString
                    txt_FD_PD.Text = DefaltSoftTable.Rows(0).Item("FABRICTYP").ToString
                End If


                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" SELECT ")
                    .Append(" A.SRNO")
                    .Append(",A.Yarn_For")
                    .Append(",A.Pattern")
                    .Append(",A.Yarn_Rate")
                    .Append(",A.Avg_weight")
                    .Append(",A.PROFIT_PER")
                    .Append(",A.Yarn_Amount")
                    .Append(",A.CountCode")
                    .Append(",B.CountName")
                    .Append(" FROM MstFabricItemCons as a ")
                    .Append("  LEFT JOIN MstYarnCount AS B  ON A.CountCode=B.CountCode")
                    .Append(" WHERE 1=1 ")
                    .Append(" and a.Fabric_ItemCode ='" & txt_FabricItemCode.Text & "'")
                    .Append(" ORDER BY A.SRNO")
                End With

                sqL = _strQuery.ToString
                sql_connect_slect()
                Dim _consttbl As New DataTable
                _consttbl = DefaltSoftTable.Copy

                If _consttbl.Rows.Count > 0 Then
                    GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
                    Fill_Records(_consttbl, Grid_Table_ColNames, GrdItem, 0, True, "", False)
                    GrdItem.Rows = GrdItem.Rows + 1
                    Rate_Calc()
                End If
            End If

            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ImportEntry_Validated(sender As Object, e As EventArgs) Handles Txt_ImportEntry.Validated
        If _FORMMODE = "ADD" Then
            If Txt_ImportEntry.Text.Trim > "" Then
                Dim _OLDENTRYNO As Integer = txt_EntryNo.Text
                Dim _OLDDATE As String = txt_Entry_Date.Text

                Dim Book_Vno As String = Generate_Book_Vno(Txt_ImportEntry.Text, _BookTrType)
                'Call Validate_Entry_No(Book_Vno, _OfferTableName)
                Call Alter_Form(Txt_ImportEntry.Text)
                txt_EntryNo.Text = _OLDENTRYNO
                txt_Entry_Date.Text = _OLDDATE
                txt_EntryNo.Focus()

            End If
        End If

    End Sub

    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Cost Sheet Report From :" & Txt_ViewFrom.Text & " To : " & Txt_ViewTO.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        'OnLoomPlaningEntry.SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        'OnLoomPlaningEntry.Load_GridLayout(FirstStage, Me.Name)
    End Sub
#End Region
End Class