Imports System.Text

Public Class MismatchCosting
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
    'Private _FieldNameForTotal As New StringBuilder
    Private _DataTableGrid As New DataTable
    Private Grid_Table_ColNames() As String

    Private FirstGridTable As DataTable
    Dim IsDetailGridOpen As Boolean = False
#End Region


#Region "GRID STRING BUILDER VARIABLE PACKING"
    Private _WeavingGridColNames As New StringBuilder
    Private _WeavingGridColType As New StringBuilder
    Private _WeavingGridColValidate As New StringBuilder
    Private _WeavingGridCol_FocusByPass As New StringBuilder
    Private _WeavingFieldDefaultValues As New StringBuilder
    Private _WeavingFieldHeader As New StringBuilder
    Private _WeavingFieldHeaderAlignment As New StringBuilder
    Private _WeavingFieldNotRequiredForSave As New StringBuilder
    Private _WeavingFieldNotVisibile As New StringBuilder
    Private _WeavingFieldWidthSet As New StringBuilder
    Private _WeavingFieldLocked As New StringBuilder
    Private _WeavingFieldMasking As New StringBuilder
    Private _WeavingFieldAlignMent As New StringBuilder
    Private _WeavingExtraFieldDataTable As New StringBuilder
    Private _WeavingExtraField_Values_DataTable As New StringBuilder
    Private _WeavingExtraFieldOthers As New StringBuilder
    Private _WeavingExtraField_Values_Others As New StringBuilder
    Private _WeavingFieldNameSameValueCopy As New StringBuilder
    'Private _FieldNameForTotal As New StringBuilder
    Private _WeavingDataTableGrid As New DataTable
    Private WeavingGrid_Table_ColNames() As String
#End Region

#Region "GRID STRING BUILDER VARIABLE OVERHEAD"
    Private _FINISHGridColNames As New StringBuilder
    Private _FINISHGridColType As New StringBuilder
    Private _FINISHGridColValidate As New StringBuilder
    Private _FINISHGridCol_FocusByPass As New StringBuilder
    Private _FINISHFieldDefaultValues As New StringBuilder
    Private _FINISHFieldHeader As New StringBuilder
    Private _FINISHFieldHeaderAlignment As New StringBuilder
    Private _FINISHFieldNotRequiredForSave As New StringBuilder
    Private _FINISHFieldNotVisibile As New StringBuilder
    Private _FINISHFieldWidthSet As New StringBuilder
    Private _FINISHFieldLocked As New StringBuilder
    Private _FINISHFieldMasking As New StringBuilder
    Private _FINISHFieldAlignMent As New StringBuilder
    Private _FINISHExtraFieldDataTable As New StringBuilder
    Private _FINISHExtraField_Values_DataTable As New StringBuilder
    Private _FINISHExtraFieldOthers As New StringBuilder
    Private _FINISHExtraField_Values_Others As New StringBuilder
    Private _FINISHFieldNameSameValueCopy As New StringBuilder
    'Private _FieldNameForTotal As New StringBuilder
    Private _FINISHDataTableGrid As New DataTable
    Private FINISHGrid_Table_ColNames() As String
#End Region

#Region "GRID GENERAL VARIABLE"

    'Private _FindColIndex As Integer = 0
    'Private _ColTotal As Double = 0
    'Private _AutoIDField As String = "SRNO"
    Private _RecordsKeyFieldName As String = "ID"
    Private _FocusFields() As String

    Private _DefaultColOfGrid As Integer = 0
    'Private _GridRowNo As Integer = 0
    'Private _ReturnColNumber As Integer = -1
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
    Public _modetype As String = ""
    'Private WithEvents txtAgent_code As New TextBox
    Private WithEvents txtParty_code As New TextBox
    Private WithEvents txtSupp_code As New TextBox
    'Private WithEvents txtTr_code As New TextBox
    'Private WithEvents txtDespatch_code As New TextBox
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
    Private _BookTrType As String = "MX-CT"
    Private _BookCode As String = "0001-000000020"
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
    Public txt_yarn_exp_per As String = ""
    Public txt_yarn_exp_amt As String = ""
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False


        Validate_Form_Values = True
    End Function


#End Region
#Region "SUB NEW"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region
#Region "GRID COL. DEFINE AND FORMATTING Basic"
    Private Sub defineGridColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID,")
            .Append("FD_PD,")
            .Append("Pick,")
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Fabric_Item_Name,")
            .Append("Reed,")
            .Append("srno,")
            .Append("Yarn_For,")
            .Append("Dent,")
            .Append("PATTERN,")
            .Append("Yarn_Rate,")
            .Append("Avg_weight,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Finish_Cost,")
            .Append("yarn_Sub_Total_amt,")
            .Append("weav_cost,")
            .Append("process_cost,")
            .Append("finish_cost,")
            .Append("Fabric_Design_No,")
            .Append("OP1,")
            .Append("Yarn_Amount")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("EntryNo:N,")
            .Append("Reed:N,")
            .Append("srno:N,")
            .Append("PATTERN:N,")
            .Append("Yarn_Rate:N,")
            .Append("Avg_weight:N,")
            .Append("Net_Weaving_Cost:N,")
            .Append("Net_Finish_Cost:N,")
            .Append("yarn_Sub_Total_amt:N,")
            .Append("weav_cost:N,")
            .Append("process_cost:N,")
            .Append("finish_cost:N,")
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
            .Append("Yarn_For:Fabric For,")
            .Append("Dent:Cut,")
            .Append("Pattern:Pattern,")
            .Append("Yarn_Rate:Rate,")
            .Append("Avg_weight:GST Diff. %,")
            .Append("PROFIT_PER:(+/-)Wt,")
            .Append("Yarn_Amount:Amount")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("Yarn_For:L,")
            .Append("Dent:L,")
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
            .Append("Dent:L,")
            .Append("Pattern:R,")
            .Append("Yarn_Rate:R,")
            .Append("Avg_weight:R,")
            .Append("PROFIT_PER:R,")
            .Append("Yarn_Amount:R")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("FD_PD:N,")
            .Append("Pick:N,")
            .Append("Fabric_Design_No:N,")
            .Append("EntryNo:N,")
            .Append("Entry_Date:N,")
            .Append("Fabric_Item_Name:N,")
            .Append("Reed:N,")
            .Append("SRNO:Y,")
            .Append("Yarn_For:Y,")
            .Append("Dent:Y,")
            .Append("Pattern:N,")
            .Append("Yarn_Rate:Y,")
            .Append("Avg_weight:Y,")
            .Append("Yarn_Amount:Y,")
            .Append("Net_Weaving_Cost:N,")
            .Append("Net_Finish_Cost:N,")
            .Append("yarn_Sub_Total_amt:N,")
            .Append("weav_cost:N,")
            .Append("process_cost:N,")
            .Append("finish_cost:N,")
            .Append("OP1:N")
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("COUNTNAME:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:6,")
            .Append("Yarn_For:11,")
            .Append("Dent:15,")
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
            .Append("Dent:0,")
            .Append("Pick:0,")
            .Append("NET_WEAVING_COST:0,")
            .Append("NET_FINISH_COST:0,")
            .Append("YARN_SUB_TOTAL_AMT:0,")
            .Append("WEAV_COST:0,")
            .Append("FINISH_COST:0,")
            .Append("YARN_AMOUNT:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y,")
            '.Append("AVG_WEIGHT:Y,")
            .Append("Yarn_For:Y,")
            .Append("YARN_AMOUNT:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("Yarn_Rate:NO-2,")
            .Append("Dent:NO-2,")
            .Append("SRNO:NO-0,")
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

#Region "GRID COL. DEFINE AND FORMATTING PACKING"
    Private Sub defineGridColNameWeaving()
        _WeavingGridColNames = New StringBuilder
        With _WeavingGridColNames
            .Append("Fabric_Design_No,")
            .Append("Fabric_Item_Name,")
            .Append("yarn_for,")
            .Append("Dent,")
            .Append("Pick,")
            .Append("FD_PD,")
            .Append("Reed,")
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Finish_Cost,")
            .Append("yarn_Sub_Total_amt,")
            .Append("weav_cost,")
            .Append("finish_cost,")
            .Append("OP1,")
            .Append("OP2,") ' ItemCode
            .Append("Yarn_Amount")
        End With

        _WeavingGridColType = New StringBuilder
        With _WeavingGridColType
            '.Append("Fabric_Design_No:N,")
            '.Append("Fabric_Item_Name:N,")
            '.Append("yarn_for:N,")
            '.Append("Dent:N,")
            '.Append("Pick:N,")
            .Append("Reed:N,")
            .Append("Yarn_Amount:N")
        End With

        _WeavingGridColValidate = New StringBuilder
        With _WeavingGridColValidate
        End With

        _WeavingGridCol_FocusByPass = New StringBuilder
        With _WeavingGridCol_FocusByPass

        End With

        _WeavingFieldHeader = New StringBuilder
        With _WeavingFieldHeader
            .Append("yarn_for:Packing,")
            .Append("Dent:Qty,")
            .Append("Pick:Rate,")
            .Append("FD_PD:Calc. By,")
            .Append("Reed:GST Diff. %,")
            .Append("Yarn_Amount:Amount")
        End With

        _WeavingFieldHeaderAlignment = New StringBuilder
        With _WeavingFieldHeaderAlignment
            .Append("Fabric_Design_No:R,")
            .Append("Fabric_Item_Name:L,")
            .Append("yarn_for:L,")
            .Append("Dent:L,")
            .Append("Pick:L,")
            .Append("FD_PD:L,")
            .Append("Reed:R,")
            .Append("Yarn_Amount:R")
        End With

        _WeavingFieldAlignMent = New StringBuilder
        With _WeavingFieldAlignMent
            .Append("Fabric_Design_No:R,")
            .Append("Fabric_Item_Name:L,")
            .Append("yarn_for:L,")
            .Append("Dent:L,")
            .Append("Pick:L,")
            .Append("FD_PD:L,")
            .Append("Reed:R,")
            .Append("Yarn_Amount:R")
        End With

        _WeavingFieldNotVisibile = New StringBuilder
        With _WeavingFieldNotVisibile
            .Append("Fabric_Design_No:N,")
            .Append("Fabric_Item_Name:N,")
            .Append("yarn_for:Y,")
            .Append("Dent:Y,")
            .Append("Pick:Y,")
            .Append("FD_PD:Y,")
            .Append("Reed:Y,")
            .Append("EntryNo:N,")
            .Append("Entry_Date:N,")
            .Append("Net_Weaving_Cost:N,")
            .Append("Net_Finish_Cost:N,")
            .Append("yarn_Sub_Total_amt:N,")
            .Append("weav_cost:N,")
            .Append("finish_cost:N,")
            .Append("OP1:N,")
            .Append("OP2:N,")
            .Append("Yarn_Amount:Y")
        End With

        _WeavingFieldNotRequiredForSave = New StringBuilder
        With _WeavingFieldNotRequiredForSave

        End With

        _WeavingFieldWidthSet = New StringBuilder
        With _WeavingFieldWidthSet
            .Append("Fabric_Design_No:0,")
            .Append("Fabric_Item_Name:0,")
            .Append("yarn_for:23,")
            .Append("Dent:15,")
            .Append("Pick:13,")
            .Append("FD_PD:13,")
            .Append("Reed:15,")
            .Append("Yarn_Amount:10")
        End With

        _WeavingFieldDefaultValues = New StringBuilder
        With _WeavingFieldDefaultValues
            .Append("YARN_SUB_TOTAL_AMT:0,")
            .Append("NET_WEAVING_COST:0,")
            .Append("NET_FINISH_COST:0,")
            .Append("WEAV_COST:0,")
            .Append("FINISH_COST:0,")
            .Append("YARN_AMOUNT:0")
        End With

        _WeavingFieldLocked = New StringBuilder
        With _WeavingFieldLocked
            .Append("Fabric_Item_Name:Y,")
            .Append("yarn_for:Y,")
            '.Append("Dent:Y,")
            '.Append("Pick:Y,")
            '.Append("Reed:N,")
            .Append("FD_PD:Y,")
            .Append("Yarn_Amount:Y")
        End With

        _WeavingFieldMasking = New StringBuilder
        With _WeavingFieldMasking
            .Append("Dent:NO-2,")
            .Append("Pick:NO-2,")
            .Append("Reed:NO-2")
        End With

        With _WeavingFieldNameSameValueCopy

        End With

        WeavingGrid_Table_ColNames = _WeavingGridColNames.ToString.ToUpper.Split(",")

    End Sub



    Private Sub GenerateTableWeaving(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _WeavingGridColNames.ToString.ToUpper, "NO", _WeavingGridColType.ToString)
        grdObj.ExtendLastCol = True
        _GridLastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
    End Sub
    Private Sub GridFormattingWeaving(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _WeavingFieldNotVisibile.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _WeavingFieldWidthSet.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _WeavingFieldHeader.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _WeavingFieldLocked.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _WeavingFieldMasking.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _WeavingFieldAlignMent.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _WeavingFieldHeaderAlignment.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Regular)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub
#End Region
#Region "GRID COL. DEFINE AND FORMATTING OVERHEAD"


    Private Sub defineGridColNameFinish()
        _FINISHGridColNames = New StringBuilder
        With _FINISHGridColNames
            .Append("Fabric_Design_No,")
            .Append("Fabric_Item_Name,")
            .Append("yarn_for,")
            .Append("Dent,")
            .Append("Pick,")
            .Append("FD_PD,")
            .Append("Reed,")
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Finish_Cost,")
            .Append("yarn_Sub_Total_amt,")
            .Append("weav_cost,")
            .Append("finish_cost,")
            .Append("OP1,")
            .Append("Yarn_Amount")
        End With

        _FINISHGridColType = New StringBuilder
        With _FINISHGridColType
            '.Append("Fabric_Design_No:N,")
            '.Append("Fabric_Item_Name:N,")
            '.Append("yarn_for:N,")
            .Append("Dent:N,")
            .Append("Pick:N,")
            .Append("Reed:N,")
            .Append("Yarn_Amount:N")
        End With

        _FINISHGridColValidate = New StringBuilder
        With _FINISHGridColValidate
        End With

        _FINISHGridCol_FocusByPass = New StringBuilder
        With _WeavingGridCol_FocusByPass

        End With

        _FINISHFieldHeader = New StringBuilder
        With _FINISHFieldHeader
            .Append("yarn_for:Overhead,")
            .Append("Dent:Qty,")
            .Append("Pick:Rate,")
            .Append("FD_PD:Calc. By,")
            .Append("Reed:GST Diff. %,")
            .Append("Yarn_Amount:Amount")
        End With

        _FINISHFieldHeaderAlignment = New StringBuilder
        With _FINISHFieldHeaderAlignment
            .Append("Fabric_Design_No:R,")
            .Append("Fabric_Item_Name:L,")
            .Append("yarn_for:L,")
            .Append("Dent:L,")
            .Append("Pick:L,")
            .Append("FD_PD:L,")
            .Append("Reed:R,")
            .Append("Yarn_Amount:R")
        End With

        _FINISHFieldAlignMent = New StringBuilder
        With _FINISHFieldAlignMent
            .Append("Fabric_Design_No:R,")
            .Append("Fabric_Item_Name:L,")
            .Append("yarn_for:L,")
            .Append("Dent:L,")
            .Append("Pick:L,")
            .Append("FD_PD:L,")
            .Append("Reed:R,")
            .Append("Yarn_Amount:R")
        End With

        _FINISHFieldNotVisibile = New StringBuilder
        With _FINISHFieldNotVisibile
            .Append("Fabric_Design_No:N,")
            .Append("Fabric_Item_Name:N,")
            .Append("yarn_for:Y,")
            .Append("Dent:Y,")
            .Append("Pick:Y,")
            .Append("FD_PD:Y,")
            .Append("Reed:Y,")
            .Append("EntryNo:N,")
            .Append("Entry_Date:N,")
            .Append("Net_Weaving_Cost:N,")
            .Append("Net_Finish_Cost:N,")
            .Append("yarn_Sub_Total_amt:N,")
            .Append("weav_cost:N,")
            .Append("finish_cost:N,")
            .Append("OP1:N,")
            .Append("Yarn_Amount:Y")
        End With

        _FINISHFieldNotRequiredForSave = New StringBuilder
        With _FINISHFieldNotRequiredForSave

        End With

        _FINISHFieldWidthSet = New StringBuilder
        With _FINISHFieldWidthSet
            .Append("Fabric_Design_No:10,")
            .Append("Fabric_Item_Name:10,")
            .Append("yarn_for:30,")
            .Append("Dent:15,")
            .Append("Pick:13,")
            .Append("FD_PD:13,")
            .Append("Reed:12,")
            .Append("Yarn_Amount:10")
        End With

        _FINISHFieldDefaultValues = New StringBuilder
        With _FINISHFieldDefaultValues
            .Append("YARN_SUB_TOTAL_AMT:0,")
            .Append("NET_WEAVING_COST:0,")
            .Append("NET_FINISH_COST:0,")
            .Append("WEAV_COST:0,")
            .Append("FINISH_COST:0,")
            .Append("YARN_AMOUNT:0")
        End With

        _FINISHFieldLocked = New StringBuilder
        With _FINISHFieldLocked
            .Append("Fabric_Item_Name:Y,")
            .Append("yarn_for:Y,")
            '.Append("Dent:Y,")
            '.Append("Pick:Y,")
            '.Append("Reed:N,")
            .Append("FD_PD:Y,")
            .Append("Yarn_Amount:Y")
        End With

        _FINISHFieldMasking = New StringBuilder
        With _FINISHFieldMasking
            .Append("Dent:NO-2,")
            .Append("Pick:NO-2,")
            .Append("Reed:NO-2,")
            .Append("Yarn_Amount:NO-2")
        End With

        With _FINISHFieldNameSameValueCopy

        End With

        FINISHGrid_Table_ColNames = _FINISHGridColNames.ToString.ToUpper.Split(",")

    End Sub



    Private Sub GenerateTableFinish(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _FINISHGridColNames.ToString.ToUpper, "NO", _FINISHGridColType.ToString)
        grdObj.ExtendLastCol = True
        _GridLastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
    End Sub
    Private Sub GridFormattingFinish(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _FINISHFieldNotVisibile.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _FINISHFieldWidthSet.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _FINISHFieldHeader.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _FINISHFieldLocked.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _FINISHFieldMasking.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _FINISHFieldAlignMent.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _FINISHFieldHeaderAlignment.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Regular)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub
#End Region
#Region "Form Default values on Load"
    Private Sub DefineDafaultValues()
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST WHERE 1=1 And UPPER(ISNULL(OP1,'')) ='COSTING INFORMATION'  ORDER BY ENTRYNO DESC"
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
#Region "Form Default values on Load Packing"
    Private Sub DefineDafaultValuesWeaving()
        Dim _Fieldqry = New StringBuilder
        With _Fieldqry
            .Append("SELECT BEHAVIOUR as Fabric_Design_No")
            .Append(",BookName As Fabric_Item_Name")
            .Append(",RCPT_ISSUE As yarn_for")
            .Append(",NATURE As Dent")
            .Append(",Y_OWN_STK As Pick")
            .Append(",Y_JOB_PARTY_STK FD_RD")
            .Append(",Y_OWN_STK_FLD As Reed")
            .Append(",'' as EntryNo")
            .Append(",'' as Entry_Date")
            .Append(",'' as Net_Weaving_Cost")
            .Append(",'' as Net_Finish_Cost")
            .Append(",'' as yarn_Sub_Total_amt")
            .Append(",'' as weav_cost")
            .Append(",'' as finish_cost")
            .Append(",'' as OP1")
            .Append(", 0.00 AS Amount")
            .Append(" FROM Query1 where 1=1 and BookName='PACKING' and Y_JOB_WORKER_STK_OWN='Mismatch Cost Setting' and Y_JOB_PARTY_STK_FLD='YES' order by Bookorder")
        End With
        strQuery = _Fieldqry.ToString()
        sqL = strQuery
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            GrdWeavingcost.DataSource = DefaltSoftTable.Copy
        End If
        GrdWeavingcost.Locked = True
        GrdWeavingcost.BoldFixedCell = True
        GrdWeavingcost.Locked = False
    End Sub

#End Region

#Region "Form Default values on Load OverHead"
    Private Sub DefineDafaultValuesFinishcost()
        Dim _Fieldqry = New StringBuilder
        With _Fieldqry
            .Append("SELECT BEHAVIOUR as Fabric_Design_No")
            .Append(",BookName As Fabric_Item_Name")
            .Append(",RCPT_ISSUE As yarn_for")
            .Append(",NATURE As Dent")
            .Append(",Y_OWN_STK As Pick")
            .Append(",Y_JOB_PARTY_STK FD_RD")
            .Append(",Y_OWN_STK_FLD As Reed")
            .Append(",'' as EntryNo")
            .Append(",'' as Entry_Date")
            .Append(",'' as Net_Weaving_Cost")
            .Append(",'' as Net_Finish_Cost")
            .Append(",'' as yarn_Sub_Total_amt")
            .Append(",'' as weav_cost")
            .Append(",'' as finish_cost")
            .Append(",'' as OP1")
            .Append(", 0.00 AS Amount")
            .Append(" FROM Query1 where 1=1 and BookName='OVERHEAD' and Y_JOB_WORKER_STK_OWN='Mismatch Cost Setting' and Y_JOB_PARTY_STK_FLD='YES' order by Bookorder")
        End With
        strQuery = _Fieldqry.ToString()
        sqL = strQuery
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            GrdFinishcost.DataSource = DefaltSoftTable.Copy
        End If
        GrdFinishcost.Locked = True
        GrdFinishcost.BoldFixedCell = True
        GrdFinishcost.Locked = False
    End Sub

#End Region
#Region "FORM EVENTS"

    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub

    Private Sub Coastsheetentry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        _FrmLoad = False

        MismatchcostingType.InsertCostSheetSetting()
        UC_Buttons1._ButtonEnableDisable("LOAD")
        AttachButtonFocusEvents(Me)
        Me.Location = New Point(0, 0)
        _modetype = ""
        _addcoloum()


        pnl_Print.Width = 603
        pnl_Print.Height = 292
        pnl_Print.Location = New Point(175, 161)



        PnlGrdView.Width = Me.Width
        PnlGrdView.Height = Me.Height
        PnlGrdView.Location = New Point(0, 0)
        GridControl1.Width = PnlGrdView.Width - 25
        GridControl1.Height = PnlGrdView.Height - 100
        GridControl1.Location = New Point(3, 53)

        _FrmLoad = True
        'Grid Fabric Fill
        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)
        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 20
        _old_Me_text = Me.Text


        'Grid Packing fill
        'Call DefineDafaultValuesWeaving()
        Call defineGridColNameWeaving()
        Call GenerateTableWeaving(_WeavingDataTableGrid, GrdWeavingcost)
        Call GridFormattingWeaving(_WeavingDataTableGrid, GrdWeavingcost)
        GrdWeavingcost.Column(0).Visible = False
        GrdWeavingcost.Row(0).Height = 31
        GrdWeavingcost.DefaultRowHeight = 20

        'Grid OverHead fill
        Call DefineDafaultValuesFinishcost()
        Call defineGridColNameFinish()
        Call GenerateTableFinish(_FINISHDataTableGrid, GrdFinishcost)
        Call GridFormattingFinish(_FINISHDataTableGrid, GrdFinishcost)
        GrdFinishcost.Column(0).Visible = False
        GrdFinishcost.Row(0).Height = 31
        GrdFinishcost.DefaultRowHeight = 20


        If _isCallerByOther = True Then
            Call Alter_Form(_KeyFieldValue)
        Else
            Cost_Sheet_Ctrl_Visible_False()
        End If
        Ctrl_Visible_False(Me.Controls)
        _FrmLoad = False

    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports")
    End Sub
    Private Sub Coastsheetentry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)
        If e.KeyCode = Keys.Escape Then

            If pnl_Print.Visible = True Then
                pnl_Print.Visible = False
                Exit Sub
            End If
            _FrmLoad = True
            If _FORMMODE = "" Then
                Me.Close()
                Me.Dispose(True)
            Else
                'If PnlGrdView.Visible = True Then
                '    PnlGrdView.Visible = False
                '    Me.Text = _old_Me_text
                '    _FORMMODE = ""
                '    Exit Sub
                'End If
                Select Case _STRTRNOBJECT
                    Case "GRDITEM"
                        GrdItem.ActiveCell.BackColor = GrdItem.BackColor1
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txt_EntryNo.Focus()

                    Case "TXT_ENTRYNO"
                        _FrmLoad = True

                        txt_Entry_Date.Text = ObjCls_General.GetTodayDate_British

                        Old_Date = txt_Entry_Date.Text
                        txt_EntryNo.Focus()
                        Txt_ImportEntry.Text = ""
                        Txt_ImportEntry.Enabled = False
                        'ObjCls_General.Blank_Object(Me)
                        txt_Entry_Date.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Clear_Grid(GrdWeavingcost, 2)
                        Clear_Grid(GrdFinishcost, 2)
                        _KeyFieldValue = 0
                        Cost_Sheet_Ctrl_Visible_False()
                        GrdItem.BoldFixedCell = False
                        GrdWeavingcost.BoldFixedCell = False
                        GrdFinishcost.BoldFixedCell = False
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                        _FORMMODE = ""
                        _FrmLoad = False
                    Case "TXT_ENTRY_DATE"
                        _FrmLoad = True

                        txt_Entry_Date.Text = ObjCls_General.GetTodayDate_British

                        Old_Date = txt_Entry_Date.Text
                        txt_EntryNo.Focus()
                        Txt_ImportEntry.Text = ""
                        Txt_ImportEntry.Enabled = False
                        'ObjCls_General.Blank_Object(Me)
                        txt_Entry_Date.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Clear_Grid(GrdWeavingcost, 2)
                        Clear_Grid(GrdFinishcost, 2)
                        _KeyFieldValue = 0
                        Cost_Sheet_Ctrl_Visible_False()
                        GrdItem.BoldFixedCell = False
                        GrdWeavingcost.BoldFixedCell = False
                        GrdFinishcost.BoldFixedCell = False
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                        _FORMMODE = ""
                        _FrmLoad = False

                    Case Else
                        _FrmLoad = True

                        txt_Entry_Date.Text = ObjCls_General.GetTodayDate_British

                        Old_Date = txt_Entry_Date.Text
                        txt_EntryNo.Focus()
                        Txt_ImportEntry.Text = ""
                        Txt_ImportEntry.Enabled = False
                        'ObjCls_General.Blank_Object(Me)
                        txt_Entry_Date.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Clear_Grid(GrdWeavingcost, 2)
                        Clear_Grid(GrdFinishcost, 2)
                        _KeyFieldValue = 0
                        Cost_Sheet_Ctrl_Visible_False()
                        GrdItem.BoldFixedCell = False
                        GrdWeavingcost.BoldFixedCell = False
                        GrdFinishcost.BoldFixedCell = False
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                        _FORMMODE = ""
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
                    If (Val(txt_yarn_Sub_Total_amt.Text)) = 0 Then
                        MsgBox("Blank Count Detail, Can't Save")
                        Exit Sub
                    Else
                        _FrmLoad = True
                        GrdWeavingcost.ActiveCell.BackColor = GrdWeavingcost.BackColor1
                        GrdWeavingcost.Cell(1, _WeavingDataTableGrid.Columns.IndexOf("yarn_for") + 1).SetFocus()
                        GrdWeavingcost.Range(1, 0, GrdWeavingcost.Rows - 1, GrdWeavingcost.Cols - 1).BackColor = GrdWeavingcost.BackColor1
                        GrdWeavingcost.Focus()

                        _FrmLoad = False
                    End If
                Case "GRDWEAVINGCOST"
                    If (Val(TXT_Net_Weaving_Cost.Text)) = 0 Then
                        MsgBox("Blank Count Detail, Can't Save")
                        Exit Sub
                    Else
                        _FrmLoad = True
                        GrdFinishcost.ActiveCell.BackColor = GrdFinishcost.BackColor1
                        GrdFinishcost.Cell(1, _FINISHDataTableGrid.Columns.IndexOf("yarn_for") + 1).SetFocus()
                        GrdFinishcost.Range(1, 0, GrdFinishcost.Rows - 1, GrdFinishcost.Cols - 1).BackColor = GrdFinishcost.BackColor1
                        GrdFinishcost.Focus()

                        _FrmLoad = False
                    End If
                Case "GRDFINISHCOST"
                    'TXT_Net_Finish_Cost.Focus()
                    UC_Buttons1.BtnSave.Focus()
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
                Case Else

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
                Case "GRDWEAVINGCOST"
                    _FrmLoad = True
                    Delete_Row(GrdWeavingcost, _WeavingDataTableGrid)
                    GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = ""
                    GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text = ""
                    Call Fill_Sr_No_Item(GrdWeavingcost, _WeavingDataTableGrid)
                    _FrmLoad = False
                    Call Rate_Calc()
                    'Case "GRDFINISHCOST"
                    '    _FrmLoad = True
                    '    Delete_Row(GrdFinishcost, _FINISHDataTableGrid)
                    '    GrdFinishcost.Cell(GrdFinishcost.ActiveCell.Row, _FINISHDataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = ""
                    '    GrdFinishcost.Cell(GrdFinishcost.ActiveCell.Row, _FINISHDataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text = ""
                    '    Call Fill_Sr_No_Item(GrdFinishcost, _DataTableGrid)
                    '    _FrmLoad = False
                    '    Call Rate_Calc()
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
#End Region

#Region "OFFER SAVE CODE"
    Private Sub SaveRecord()

        Generate_Date_For_DataBase(txt_Entry_Date)


        If _BookVNo = "" Then
            _BookVNo = Generate_Book_Vno(Val(txt_EntryNo.Text), _BookTrType)
        End If
        Call Fill_Grid_Records_Into_DataTables()
        Try
            SAVE_INTO_DATABASE()
            Old_Date = txt_Entry_Date.Text
            _Last_Saved_Entry_No = Val(txt_EntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex ERP")
            ObjCls_General.Blank_Object(Me)
            txt_Entry_Date.Text = Old_Date
            Cost_Sheet_Ctrl_Visible_False()
            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            _FrmLoad = True

            'Packing default load
            GrdWeavingcost.BoldFixedCell = False
            Clear_Grid(GrdWeavingcost, 2)
            Call DefineDafaultValuesWeaving()
            Call GridFormattingWeaving(_WeavingDataTableGrid, GrdWeavingcost)
            GrdWeavingcost.Column(0).Visible = False
            'OverHead default load
            GrdFinishcost.BoldFixedCell = False
            Clear_Grid(GrdFinishcost, 2)
            Call DefineDafaultValuesFinishcost()
            Call GridFormattingFinish(_FINISHDataTableGrid, GrdFinishcost)
            GrdFinishcost.Column(0).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow


        '--- Fill Fabric Grid Records -----------
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
        '---Fill Packing Grid Records-------------------
        Dim WeavingFieldDr As DataRow
        _WeavingDataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdWeavingcost.Rows - 1
            If Val(GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text) > 0 Then
                WeavingFieldDr = _WeavingDataTableGrid.NewRow
                For j As Int16 = 1 To GrdWeavingcost.Cols - 1
                    If WeavingFieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        WeavingFieldDr(j - 1) = Val(GrdWeavingcost.Cell(i, j).Text)
                    Else
                        WeavingFieldDr(j - 1) = (GrdWeavingcost.Cell(i, j).Text)
                    End If
                Next
                _WeavingDataTableGrid.Rows.Add(WeavingFieldDr)
            End If
        Next
        '---Fill OverHead Grid Records-------------------
        Dim FinishFieldDr As DataRow
        _FINISHDataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdFinishcost.Rows - 1
            If Val(GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("Dent") + 1).Text) > 0 Then
                FinishFieldDr = _FINISHDataTableGrid.NewRow
                For j As Int16 = 1 To GrdFinishcost.Cols - 1
                    If FinishFieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FinishFieldDr(j - 1) = Val(GrdFinishcost.Cell(i, j).Text)
                    Else
                        FinishFieldDr(j - 1) = (GrdFinishcost.Cell(i, j).Text)
                    End If
                Next
                _FINISHDataTableGrid.Rows.Add(FinishFieldDr)
            End If
        Next
    End Sub
    Private Function WeavingGridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        'Yarn grid records
        Dim WeavingQueryDetailTable As String = ""
        Dim strFilterString As String = ""
        Dim WeavingQuery_Auto_Grid(_WeavingDataTableGrid.Rows.Count, 4) As String
        'strFilterString = "Fabric_Design_No<>''"
        strFilterString = ""
        Dim yarntype As String = ""
        yarntype = "COSTING INFORMATION"
        Dim strtype As String = ""
        strtype = "PACKING"
        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Fabric_Item_Name,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Finish_Cost,")
            .Append("yarn_Sub_Total_amt,")
            .Append("weav_cost,")
            .Append("finish_cost,")
            .Append("OP1")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(GetNumericValue(txt_EntryNo.Text) & ",")
            .Append(txt_Entry_Date.Date_for_Database & ",")
            .Append(strtype & ",")
            .Append(GetNumericValue(TXT_Net_Weaving_Cost.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Finish_Cost.Text) & ",")
            .Append(GetNumericValue(txt_yarn_Sub_Total_amt.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Weaving_Cost.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Finish_Cost.Text) & ",")
            ' OP1 - NVARCHAR
            .Append(yarntype)
        End With

        WeavingQueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, WeavingQuery_Auto_Grid, _WeavingDataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        WeavingGridDetailsSaveQuery = WeavingQueryDetailTable & ";"
        arr_object = WeavingQuery_Auto_Grid

    End Function
    Private Function FinishGridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        'Yarn grid records
        Dim FinishQueryDetailTable As String = ""
        Dim strFilterString As String = ""
        Dim FinishQuery_Auto_Grid(_FINISHDataTableGrid.Rows.Count, 4) As String
        strFilterString = "Fabric_Design_No<>''"
        Dim yarntype As String = ""
        yarntype = "COSTING INFORMATION"
        Dim strtype As String = ""
        strtype = "OVERHEAD"
        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Fabric_Item_Name,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Finish_Cost,")
            .Append("yarn_Sub_Total_amt,")
            .Append("weav_cost,")
            .Append("finish_cost,")
            .Append("OP1")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            ' Numeric
            .Append(GetNumericValue(txt_EntryNo.Text) & ",")
            ' Date
            .Append(txt_Entry_Date.Date_for_Database & ",")
            .Append(strtype & ",")
            ' Numeric
            .Append(GetNumericValue(TXT_Net_Weaving_Cost.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Finish_Cost.Text) & ",")
            .Append(GetNumericValue(txt_yarn_Sub_Total_amt.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Weaving_Cost.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Finish_Cost.Text) & ",")
            ' NVARCHAR
            .Append(yarntype)
        End With

        FinishQueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, FinishQuery_Auto_Grid, _FINISHDataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        FinishGridDetailsSaveQuery = FinishQueryDetailTable & ";"
        arr_object = FinishQuery_Auto_Grid

    End Function
    Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        '------------------------ DETAILS Table --------------------------------
        Dim strFilterString As String
        Dim QueryDetailTable As String = ""

        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String
        strFilterString = "YARN_AMOUNT>0"
        Dim yarntype As String = ""
        yarntype = "COSTING INFORMATION"
        Dim strtype As String = ""
        strtype = "FABRIC"
        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("EntryNo,")
            .Append("Entry_Date,")
            .Append("Fabric_Item_Name,")
            .Append("Net_Weaving_Cost,")
            .Append("Net_Finish_Cost,")
            .Append("yarn_Sub_Total_amt,")
            .Append("weav_cost,")
            .Append("finish_cost,")
            .Append("Fabric_Design_No,")
            .Append("OP1,")
            .Append("process_cost")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            ' EntryNo - Numeric
            .Append(GetNumericValue(txt_EntryNo.Text) & ",")
            .Append(txt_Entry_Date.Date_for_Database & ",")
            .Append(strtype & ",")
            ' Numeric Fields
            .Append(GetNumericValue(TXT_Net_Weaving_Cost.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Finish_Cost.Text) & ",")
            .Append(GetNumericValue(txt_yarn_Sub_Total_amt.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Weaving_Cost.Text) & ",")
            .Append(GetNumericValue(TXT_Net_Finish_Cost.Text) & ",")
            ' Fabric Design No - NVARCHAR
            .Append("'" & txt_FabricItemCode.Text.Replace("'", "''") & "',")
            ' Process Cost - Numeric
            .Append(yarntype & ",")
            .Append(GetNumericValue(Lblprocesscost.Text))
        End With

        QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid

    End Function

    Private Function GetNumericValue(ByVal Value As String) As String
        Dim Number As Decimal
        If String.IsNullOrWhiteSpace(Value) Then
            Return "0"
        End If
        If Decimal.TryParse(Value.Trim(), Number) Then
            Return Number.ToString(System.Globalization.CultureInfo.InvariantCulture)
        End If
        Return "0"
    End Function

    Private Function SAVE_INTO_DATABASE() As Integer
        Dim strQuery As String = ""
        Dim I As Integer = 0


        Try
            '---------------- Delete Previous Bill Sundry ---------------------------------- '
            strQuery = "DELETE FROM TRNFABRICCOST WHERE ENTRYNO =" & txt_EntryNo.Text & " AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION' "
            sqL = strQuery.ToString
            sql_Data_Save_Delete_Update()


            'FABRIC Grid
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
            'Packing Grid
            Dim Array_Opening_weaving(0, 4) As String
            '------ INSERT RECORDS SALES INVOICE -------------------------------
            WeavingGridDetailsSaveQuery(Array_Opening_weaving)
            For I = 0 To UBound(Array_Opening_weaving)
                If Array_Opening_weaving(I, 4) <> "" Then
                    strQuery = Array_Opening_weaving(I, 4)
                    sqL = strQuery.ToString
                    sql_Data_Save_Delete_Update()
                End If
            Next

            'OverHead Grid
            Dim Array_Opening_Finish(0, 4) As String
            '------ INSERT RECORDS SALES INVOICE -------------------------------
            FinishGridDetailsSaveQuery(Array_Opening_Finish)
            For I = 0 To UBound(Array_Opening_Finish)
                If Array_Opening_Finish(I, 4) <> "" Then
                    strQuery = Array_Opening_Finish(I, 4)
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
#End Region

#Region "CTRL VISIBLE FALSE"
    Private Sub Cost_Sheet_Ctrl_Visible_False()
        GrdItem.Enabled = False
        GrdWeavingcost.Enabled = False
        GrdFinishcost.Enabled = False
        txt_EntryNo.Visible = False
        txt_Entry_Date.Visible = False
        TXT_Net_Weaving_Cost.Visible = False
        TXT_Net_Finish_Cost.Visible = False
        txt_yarn_Sub_Total_amt.Visible = False
        TXT_Net_Weaving_Cost.Visible = False
        TXT_Net_Finish_Cost.Visible = False
        Txt_ImportEntry.Visible = False
        Btn_CreatOverHeadItem.Visible = False
    End Sub
#End Region
#Region "CTRL VISIBLE TRUE"
    Private Sub Cost_Sheet_Ctrl_Visible_True()
        GrdItem.Enabled = True
        GrdWeavingcost.Enabled = True
        GrdFinishcost.Enabled = True
        txt_EntryNo.Visible = True
        txt_Entry_Date.Visible = True
        TXT_Net_Weaving_Cost.Visible = True
        TXT_Net_Finish_Cost.Visible = True
        txt_yarn_Sub_Total_amt.Visible = True
        TXT_Net_Weaving_Cost.Visible = True
        TXT_Net_Finish_Cost.Visible = True
        Txt_ImportEntry.Visible = True
        Btn_CreatOverHeadItem.Visible = True
    End Sub
#End Region

#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*,")
            .Append(" FORMAT(A.ENTRY_DATE,'dd/MM/yyyy') AS F_OFFERDATE")
            .Append(" FROM TRNFABRICCOST A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.ENTRYNO=" & Val(strKeyID) & " AND UPPER(ISNULL(A.OP1,''))='COSTING INFORMATION' ")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return _strQuery.ToString
    End Function
#End Region
#Region "ALTER FORM QUERY FABRIC"
    Private Function getAlter_FabricForm_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append("SELECT SRNO,Fabric_Design_No")
            .Append(",Fabric_Item_Name")
            .Append(",yarn_for")
            .Append(",Dent")
            .Append(",Yarn_Rate")
            .Append(",Avg_weight")
            .Append(",Yarn_Amount")
            .Append(",Pick")
            .Append(",Reed")
            .Append(",EntryNo")
            .Append(",Entry_Date")
            .Append(",Net_Weaving_Cost")
            .Append(",Net_Finish_Cost")
            .Append(",yarn_Sub_Total_amt")
            .Append(",weav_cost")
            .Append(",finish_cost")
            .Append(",OP1")
            .Append(", Yarn_Amount AS Amount")
            .Append(" FROM  TRNFABRICCOST")
            .Append(" WHERE 1=1  ")
            .Append(" AND ENTRYNO=" & Val(strKeyID) & " AND UPPER(ISNULL(OP1,''))= 'COSTING INFORMATION' and Fabric_Item_Name='FABRIC' ")
            .Append(" ORDER BY OTHEREXP_1 ")
        End With
        Return _strQuery.ToString
    End Function
#End Region

#Region "ALTER FORM QUERY PACKING"
    Private Function getAlter_PackingForm_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append("SELECT Fabric_Design_No")
            .Append(",Fabric_Item_Name")
            .Append(",yarn_for")
            .Append(",Dent")
            .Append(",Pick")
            .Append(",FD_PD")
            .Append(",Reed")
            .Append(",EntryNo")
            .Append(",Entry_Date")
            .Append(",Net_Weaving_Cost")
            .Append(",Net_Finish_Cost")
            .Append(",yarn_Sub_Total_amt")
            .Append(",weav_cost")
            .Append(",finish_cost")
            .Append(",OP1")
            .Append(", Yarn_Amount AS Amount")
            .Append(" FROM  TRNFABRICCOST")
            .Append(" WHERE 1=1  ")
            .Append(" AND ENTRYNO=" & Val(strKeyID) & " AND UPPER(ISNULL(OP1,''))= 'COSTING INFORMATION' and Fabric_Item_Name='PACKING' ")
            .Append(" ORDER BY OTHEREXP_1 ")
        End With
        Return _strQuery.ToString
    End Function
#End Region
#Region "ALTER FORM QUERY OVERHEAD"
    Private Function getAlter_OverHeadForm_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append("SELECT Fabric_Design_No")
            .Append(",Fabric_Item_Name")
            .Append(",yarn_for")
            .Append(",Dent")
            .Append(",Pick")
            .Append(",FD_PD")
            .Append(",Reed")
            .Append(",EntryNo")
            .Append(",Entry_Date")
            .Append(",Net_Weaving_Cost as NetWeavingCost")
            .Append(",Net_Finish_Cost As NetFinishCost")
            .Append(",yarn_Sub_Total_amt As yarnSubTotalamt")
            .Append(",weav_cost")
            .Append(",finish_cost")
            .Append(",OP1")
            .Append(", Yarn_Amount AS Amount")
            .Append(" FROM  TRNFABRICCOST")
            .Append(" WHERE 1=1  ")
            .Append(" AND ENTRYNO='" & Val(strKeyID) & "' AND UPPER(ISNULL(OP1,''))= 'COSTING INFORMATION' and Fabric_Item_Name='OVERHEAD' ")
            .Append(" ORDER BY OTHEREXP_1 ")
        End With
        Return _strQuery.ToString
    End Function
#End Region


#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        Try

            _FrmLoad = True

        Cost_Sheet_Ctrl_Visible_False()
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable

        strQuery = getAlter_Form_Query_Details(strKeyID)

        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy


        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)


        'txt_Fabric_Item_name.Text = tblTmp.Rows(0)("FABRIC_ITEM_NAME").ToString
        txt_Entry_Date.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        txt_FabricItemCode.Text = tblTmp.Rows(0)("Fabric_Design_No").ToString

        ' Fabric Grid
        strQuery = getAlter_FabricForm_Query_Details(strKeyID)
        Dim _yarnstrquery As New StringBuilder
        Dim tblTmpyarn As New DataTable

        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmpyarn = DefaltSoftTable.Copy
        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmpyarn, Grid_Table_ColNames, GrdItem, 0, True, "", False)
        txt_yarn_Sub_Total_amt.Text = tblTmpyarn.Compute("SUM(YARN_AMOUNT)", "").ToString
        GrdItem.Rows = GrdItem.Rows + 1

        GrdItem.Refresh()
        GrdItem.Visible = True

        'Packing grid
        Dim _Weavingstrquery As New StringBuilder
        Dim tblTmpWeaving As New DataTable

        strQuery = getAlter_PackingForm_Query_Details(strKeyID)

        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmpWeaving = DefaltSoftTable.Copy

            GrdWeavingcost.Visible = False
            GrdWeavingcost.Range(0, 0, GrdWeavingcost.Rows - 1, GrdWeavingcost.Cols - 1).DeleteByRow()
            Fill_Records(tblTmpWeaving, WeavingGrid_Table_ColNames, GrdWeavingcost, 0, True, "", False)
        GrdWeavingcost.Rows = GrdWeavingcost.Rows + 1

        GrdWeavingcost.Refresh()
        GrdWeavingcost.Visible = True

        'OverHead grid
        Dim _Finishstrquery As New StringBuilder
        Dim tblTmpfinishcost As New DataTable

        strQuery = getAlter_OverHeadForm_Query_Details(strKeyID)

        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmpfinishcost = DefaltSoftTable.Copy
            GrdFinishcost.Visible = False
            GrdFinishcost.Range(0, 0, GrdFinishcost.Rows - 1, GrdFinishcost.Cols - 1).DeleteByRow()
            Fill_Records(tblTmpfinishcost, FINISHGrid_Table_ColNames, GrdFinishcost, 0, True, "", False)
            GrdFinishcost.Rows = GrdFinishcost.Rows + 1

            GrdFinishcost.Refresh()
        GrdFinishcost.Visible = True
        Cost_Sheet_Ctrl_Visible_True()
            _FrmLoad = False
            Call Rate_Calc()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
            strQuery = " DELETE FROM trnfabriccost WHERE entryno=" & Val(txt_EntryNo.Text) & " AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION' "
            sqL = strQuery.ToString
            sql_Data_Save_Delete_Update()
            '-----------------------------------------------------------------------

            _KeyFieldValue = 0
            _FORMMODE = "ADD"

            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted")
            Old_Date = txt_Entry_Date.Text
            'ObjCls_General.Blank_Object(Me)
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

#Region "GRID ITEM EVENTS for Basic"

    Private Sub GrdItem_EnterRow(Sender As Object, e As FlexCell.Grid.EnterRowEventArgs) Handles GrdItem.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
        GrdItem.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub GrdItem_Click(Sender As Object, e As EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub GrdItem_RowColChange(Sender As Object, e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        GrdItem.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub GrdItem_LeaveCell(Sender As Object, e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
        GrdItem.ActiveCell.BackColor = GrdItem.BackColor1
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
    Private Sub GrdItem_Validated(sender As Object, e As EventArgs) Handles GrdItem.Validated
        If _FrmLoad = True Then Exit Sub
        GrdItem.Refresh()
    End Sub
    Private Sub GrdItem_LeaveRow(Sender As Object, e As FlexCell.Grid.LeaveRowEventArgs) Handles GrdItem.LeaveRow
        If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row
        Dim Dent As String = ""
        Dim Yarn_Rate As Double = 0

        Dent = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Dent") + 1).Text
        Yarn_Rate = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text)

        If Dent = "" Or Yarn_Rate = 0 Then
            If _ActivatedColName = "YARN_AMOUNT" Then
                e.Cancel = True
                If Dent = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Dent") + 1).SetFocus()
                    Exit Sub
                ElseIf Yarn_Rate = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).SetFocus()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Private Sub GrdItem_KeyPress(Sender As Object, e As KeyPressEventArgs) Handles GrdItem.KeyPress
        If _FrmLoad = True Then Exit Sub
        GrdItem.ActiveCell.BackColor = Color.Transparent

        If _ActivatedColName = "PATTERN" Then
            Rate_Calc()
        ElseIf _ActivatedColName = "YARN_FOR" Then
            Dim Yarn_For_Value As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf(_ActivatedColName) + 1).Text
            If Asc(e.KeyChar) = 32 Then
                If Yarn_For_Value = "" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "SUITING"
                ElseIf Yarn_For_Value = "SHIRTING" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "SUITING"
                ElseIf Yarn_For_Value = "SUITING" Then
                    e.Handled = True
                    GrdItem.ActiveCell.Text = "SHIRTING"
                End If
            End If
        End If
    End Sub
    Private Sub GrdItem_KeyDown(Sender As Object, e As KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub

        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text = "SUITING"
        If _ActivatedColName = "Dent" Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
                Dim Net_Cnt As Double = 0
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NETCOUNT") + 1).Text = Net_Cnt
                If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text) = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text = 1
                End If
                Rate_Calc()
            End If
        ElseIf _ActivatedColName = "AVG_WEIGHT" Then
            Call Rate_Calc()
        ElseIf _ActivatedColName = "YARN_RATE" Then
            Call Rate_Calc()
        ElseIf _ActivatedColName = "YARN_AMOUNT" Then
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdItem.ActiveCell.Row
                Dim Yarn_Amt As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
                Yarn_Amt = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
                If Yarn_Amt = 0 Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text = ""
                End If

                If Yarn_Amt <> 0 Then
                    If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                        GrdItem.Rows = GrdItem.Rows + 1
                        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    Else
                        GrdItem.Rows = GrdItem.Rows + 1
                        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    End If
                Else
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                End If
            End If
        End If
        Call Rate_Calc()
    End Sub
#End Region
#Region "TXT BOX ENTRY NO EVENT CODE"
    Private Sub txt_EntryNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_EntryNo.KeyDown
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
    Private Sub txt_EntryNo_Validated(sender As Object, e As EventArgs) Handles txt_EntryNo.Validated

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

        strQuery = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " WHERE ENTRYNO=" & Val(txt_EntryNo.Text) & " AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION' "
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
                txt_EntryNo.Focus()
                Txt_ImportEntry.Enabled = False
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
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                    Else
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                    End If
                    Clear_Grid(GrdItem, 2)
                    Clear_Grid(GrdWeavingcost, 2)
                    Clear_Grid(GrdFinishcost, 2)
                    Call Cost_Sheet_Ctrl_Visible_False()
                End If
                _FrmLoad = False
            End If
        Else
            If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                Clear_Grid(GrdItem, 2)
                Clear_Grid(GrdWeavingcost, 2)
                Clear_Grid(GrdFinishcost, 2)
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
    Private Sub View_Record()



        Generate_Date_For_DataBase(Txt_ViewFrom)
        Generate_Date_For_DataBase(Txt_ViewTO)


        Dim View_Filter_Condition = " AND A.Entry_Date>='" & Txt_ViewFrom.Date_for_Database & "' AND A.Entry_Date<='" & Txt_ViewTO.Date_for_Database & "' AND UPPER(ISNULL(A.OP1,'')) = 'COSTING INFORMATION' "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" Distinct A.EntryNo AS EntryNo")
            .Append(" ,format(A.Entry_Date ,'dd/MM/yyyy') as Date")
            .Append(" ,A.Finish_Cost As Amount")
            .Append(" FROM TrnFabricCost AS A ")
            .Append(" WHERE 1=1")
            .Append(View_Filter_Condition)
            .Append(" group BY ")
            .Append(" A.EntryNo")
            .Append(" ,A.Entry_Date")
            .Append(" ,A.Fabric_Item_Name")
            .Append(" ,A.Yarn_For ")
            .Append(" ,A.Dent")
            .Append(" ,A.Yarn_Rate")
            .Append(" ,A.Pick ")
            .Append(" ,A.Avg_weight ")
            .Append(" ,A.Reed ")
            .Append(" ,A.Yarn_Amount ")
            .Append(" ,A.Finish_Cost ")
            .Append(" ,A.ID ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As DataTable

        tblTmp = DefaltSoftTable.Copy
        FirstStage.Columns.Clear()
        Dim Qty As String = ""
        If tblTmp.Rows.Count > 0 Then

            'GridControl1.DataSource = tblTmp.Copy
            FirstGridTable = tblTmp.Copy()

            GridControl1.DataSource = FirstGridTable.Copy()
            DevGridFitColumn(GridControl1, FirstStage)
            FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            PnlGrdView.Visible = True
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            PnlGrdView.BringToFront()
            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        End If
    End Sub
    Private Sub FirstStage_KeyDown(sender As Object, e As KeyEventArgs) Handles FirstStage.KeyDown
        If e.KeyCode = Keys.Escape Then

            '=========================================================
            ' SECOND GRID -> FIRST GRID
            '=========================================================
            If IsDetailGridOpen Then

                IsDetailGridOpen = False

                If FirstGridTable IsNot Nothing AndAlso FirstGridTable.Rows.Count > 0 Then

                    FirstStage.Columns.Clear()

                    GridControl1.DataSource = FirstGridTable.Copy()

                    DevGridFitColumn(GridControl1, FirstStage)

                    If FirstStage.Columns("EntryNo") IsNot Nothing Then
                        FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment =
                    DevExpress.Utils.HorzAlignment.Far
                    End If

                    If FirstStage.Columns("Amount") IsNot Nothing Then
                        FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment =
                    DevExpress.Utils.HorzAlignment.Far
                    End If

                    PnlGrdView.Visible = True
                    FirstStage.BestFitColumns()
                    FirstStage.Focus()

                    PnlGrdView.BringToFront()
                    GridControl1.BringToFront()

                    _FORMMODE = "VIEW"

                End If

                e.Handled = True
                Exit Sub
            End If


            '=========================================================
            ' FIRST GRID -> CLOSE + CLEAR
            '=========================================================
            If PnlGrdView.Visible = True Then

                PnlGrdView.Visible = False

                If FirstGridTable IsNot Nothing Then
                    FirstGridTable.Clear()
                End If

                GridControl1.DataSource = Nothing

                Me.Text = _old_Me_text
                _FORMMODE = ""

                e.Handled = True
                Exit Sub

            End If

        End If
        ' Amount column par Enter
        If e.KeyCode <> Keys.Enter Then Exit Sub
        If FirstStage.FocusedColumn Is Nothing Then Exit Sub
        If FirstStage.FocusedColumn.FieldName <> "Amount" Then Exit Sub
        Dim rowHandle As Integer = FirstStage.FocusedRowHandle
        If rowHandle < 0 Then Exit Sub
        Dim EntryNo As String = Convert.ToString(FirstStage.GetRowCellValue(rowHandle, "EntryNo")).Trim()
        If String.IsNullOrWhiteSpace(EntryNo) Then Exit Sub
        Show_FabricCost_Detail(EntryNo)
        IsDetailGridOpen = True
        e.Handled = True
    End Sub
    Private Sub Show_FabricCost_Detail(ByVal EntryNo As String)

        Try

            Dim View_Filter_Condition As String = " AND A.EntryNo='" & EntryNo.Replace("'", "''") & "' AND UPPER(ISNULL(A.OP1,'')) = 'COSTING INFORMATION' "
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.EntryNo AS EntryNo")
                .Append(" ,FORMAT(A.Entry_Date ,'dd/MM/yyyy') AS Date")
                .Append(" ,A.Fabric_Item_Name AS Type")
                .Append(" ,A.Yarn_For AS Name ")
                .Append(" ,A.Dent AS Qty")
                .Append(" ,ISNULL(A.Yarn_Rate, A.Pick) AS Rate")
                .Append(" ,ISNULL(A.Avg_weight, A.Reed) AS [GstDiff.%]")
                .Append(" ,A.Yarn_Amount AS Amount")
                .Append(" FROM TrnFabricCost AS A ")
                .Append(" WHERE 1=1")
                .Append(View_Filter_Condition)
                .Append(" GROUP BY ")
                .Append(" A.EntryNo")
                .Append(" ,A.Entry_Date")
                .Append(" ,A.Fabric_Item_Name")
                .Append(" ,A.Yarn_For ")
                .Append(" ,A.Dent")
                .Append(" ,A.Yarn_Rate")
                .Append(" ,A.Pick ")
                .Append(" ,A.Avg_weight ")
                .Append(" ,A.Reed ")
                .Append(" ,A.Yarn_Amount ")
                .Append(" ,A.Finish_Cost ")
                .Append(" ,A.ID ")
                .Append(" ORDER BY A.EntryNo,A.Entry_Date,A.ID")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim tblDetail As DataTable = DefaltSoftTable.Copy
            If tblDetail.Rows.Count = 0 Then
                MessageBox.Show("No detail records found for Entry No. " & EntryNo & ".", "Detail Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            ' Same GridControl par detail data show karega
            GridControl1.DataSource = tblDetail
            FirstStage.Columns.Clear()
            If tblDetail.Rows.Count > 0 Then

                GridControl1.DataSource = tblDetail.Copy

                DevGridFitColumn(GridControl1, FirstStage)
                If FirstStage.Columns("EntryNo") IsNot Nothing Then
                    FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If FirstStage.Columns("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If FirstStage.Columns("Rate") IsNot Nothing Then
                    FirstStage.Columns("Rate").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If FirstStage.Columns("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                PnlGrdView.Visible = True
                '_FORMMODE = "VIEW"
                FirstStage.BestFitColumns()
                FirstStage.Focus()
                PnlGrdView.BringToFront()
                GridControl1.BringToFront()
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            End If
        Catch ex As Exception
            MessageBox.Show("Unable to load costing detail." & vbCrLf & vbCrLf & "Details: " & ex.Message, "Detail Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
#End Region
#Region "GRID VIEW EVENTS CODE"
    Private Sub grdView_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            PnlGrdView.Visible = False
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
            .Append(" WHERE A.OFFERBOOKVNO='" & _BookVNo & "' ")
            '.Append(" WHERE A.PARTYCODE='" & txtParty_code.Text & "' ")
            '.Append(" AND A.SUPPCODE='" & txtSupp_code.Text & "' ")
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

    Private Sub txt_Loom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If _FrmLoad = True Then Exit Sub
        GrdItem.Focus()
        GrdItem.Select()
    End Sub

#Region "ALL RATES CALC SYSTEM "
    Private Sub Calc_Total_Ends()
        Dim Reed_Value As Double = 0
        Dim Extra_Reed_Value As Double = 0
        Dim Dent_Value As Double = 0

        If Dent_Value > 2 Then
            'Reed_Value = Val(txt_reed.Text) / 2
            Extra_Reed_Value = Reed_Value * (Dent_Value - 2)
            'Reed_Value = Val(txt_reed.Text) + Extra_Reed_Value
        ElseIf Dent_Value = 2 Then
            'Reed_Value = Val(txt_reed.Text) / Val(txt_dent.Text)
        End If

        'Dim RS_Value As Double = Val(txt_reed_space.Text)

        'If Dent_Value = 2 Then
        '    txt_Total_Ends.Text = (Reed_Value * RS_Value) * 2
        'Else
        '    txt_Total_Ends.Text = (Reed_Value * RS_Value)
        'End If
    End Sub
    Private Sub Rate_Calc()
        If _FrmLoad = True Then Exit Sub
        Calc_Total_Ends()
        Dim GrandTotal As Double = 0
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

        Dim CountNameValue As Decimal = 0D
        Dim YarnRateValue As Decimal = 0D
        Dim AvgWeightPercent As Decimal = 0D
        Dim YarnAmount As Decimal = 0D
        Dim AvgWeightValue As Decimal = 0D
        'If TXT_Final_Grey_Cost.Text = "" Then TXT_Final_Grey_Cost.Text = "0.00"
        For i As Int16 = 1 To GrdItem.Rows - 1
            Yarn_For = Trim(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text)
            If Yarn_For = "SUITING" Then
                Total_Warp_Pattern = Total_Warp_Pattern + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text)
            End If
            If Yarn_For = "SHIRTING" Then
                Total_Weft_Pattern = Total_Weft_Pattern + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PATTERN") + 1).Text)
            End If
        Next

        '------------------- yarn Start
        For i As Int16 = 1 To GrdItem.Rows - 1

            Decimal.TryParse(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Dent") + 1).Text, CountNameValue)
            Decimal.TryParse(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_RATE") + 1).Text, YarnRateValue)
            Decimal.TryParse(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AVG_WEIGHT") + 1).Text, AvgWeightValue)
            YarnAmount = CountNameValue * YarnRateValue

            ' AVG_WEIGHT percentage apply karein
            If AvgWeightValue <> 0 Then
                YarnAmount = YarnAmount + (YarnAmount * AvgWeightValue / 100D)
            End If


            GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text = YarnAmount.ToString("0.00")
            Tot_Cost_Amt = Tot_Cost_Amt + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
        Next
        GrandTotal += Tot_Cost_Amt
        txt_yarn_Sub_Total_amt.Text = FormatNumber(GrandTotal, 2, TriState.True, TriState.False, TriState.False)
        Dim subTotal As Decimal = GrandTotal
        Tot_Cost_Amt = 0D
        Dim PackingYarnAmount As Decimal = 0D
        Dim PackingCountNameValue As Decimal = 0D
        Dim PackingYarnRateValue As Decimal = 0D
        Dim PackingAvgWeightValue As Decimal = 0D
        For i As Int16 = 1 To GrdWeavingcost.Rows - 1
            PackingCountNameValue = 0D
            PackingYarnRateValue = 0D
            PackingAvgWeightValue = 0D
            Decimal.TryParse(GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("Dent") + 1).Text, PackingCountNameValue)
            Decimal.TryParse(GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("Pick") + 1).Text, PackingYarnRateValue)
            Decimal.TryParse(GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("Reed") + 1).Text, PackingAvgWeightValue)
            '----------------------------------------
            ' Calculate Amount
            '----------------------------------------
            If GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text.Trim().ToUpper() = "AMOUNT" Then
                ' AMOUNT = Previous SubTotal + Rate
                PackingYarnAmount = subTotal + PackingYarnRateValue
            Else
                ' Percentage calculation
                PackingYarnAmount = Math.Round((PackingYarnRateValue * subTotal) / 100D, 2)
            End If
            '----------------------------------------
            ' GST Diff %
            '----------------------------------------
            If PackingAvgWeightValue <> 0D Then
                PackingYarnAmount = PackingYarnAmount + (PackingYarnAmount * PackingAvgWeightValue / 100D)
            End If
            '----------------------------------------
            ' Set Yarn Amount
            '----------------------------------------
            PackingYarnAmount = Math.Round(PackingYarnAmount, 2)
            Dim yarnAmountCol As Integer = _WeavingDataTableGrid.Columns.IndexOf("Yarn_Amount") + 1
            GrdWeavingcost.Cell(i, yarnAmountCol).Text = PackingYarnAmount.ToString("0.00")
            '----------------------------------------
            ' IMPORTANT:
            ' AMOUNT me next row previous calculated amount
            ' se continue hogi.
            ' Percentage me subtotal me calculated amount add hoga.
            '----------------------------------------
            subTotal = PackingYarnAmount
            Tot_Cost_Amt = Tot_Cost_Amt + PackingYarnAmount
        Next

        TXT_Net_Weaving_Cost.Text = FormatNumber(Tot_Cost_Amt, 2, TriState.True, TriState.False, TriState.False)
        'GrandTotal += Tot_Cost_Amt
        Dim finishsubTotal As Decimal = GrandTotal
        Dim OverheadYarnAmount As Decimal = 0D
        Dim OverheadCountNameValue As Decimal = 0D
        Dim OverheadYarnRateValue As Decimal = 0D
        Dim OverheadAvgWeightValue As Decimal = 0D
        Dim FinishCost As Decimal = Val(TXT_Net_Weaving_Cost.Text)
        Tot_Cost_Amt = 0
        For i As Int16 = 1 To GrdFinishcost.Rows - 1
            Dim reedValue As Decimal = 0D
            Decimal.TryParse(GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("Dent") + 1).Text, OverheadCountNameValue)
            Decimal.TryParse(GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("Pick") + 1).Text, OverheadYarnRateValue)
            Decimal.TryParse(GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("Reed") + 1).Text, OverheadAvgWeightValue)
            ' COUNTNAME × YARN_RATE
            'OverheadYarnAmount = OverheadCountNameValue * OverheadYarnRateValue
            If GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "AMOUNT" And OverheadYarnRateValue>0 Then
                OverheadYarnAmount = OverheadYarnRateValue + FinishCost
            Else
                OverheadYarnAmount = Math.Round((OverheadYarnRateValue * FinishCost) / 100D, 2)
            End If
            If OverheadAvgWeightValue <> 0 Then
                OverheadYarnAmount = OverheadYarnAmount + (OverheadYarnAmount * OverheadAvgWeightValue / 100D)
            End If
            Dim colIndex As Integer = _FINISHDataTableGrid.Columns.IndexOf("Yarn_Amount") + 1
            GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("Yarn_Amount") + 1).Text = OverheadYarnAmount.ToString("0.00")
            FinishCost = OverheadYarnAmount
            Tot_Cost_Amt = Tot_Cost_Amt + Val(GrdFinishcost.Cell(i, _FINISHDataTableGrid.Columns.IndexOf("Yarn_Amount") + 1).Text)
            Lblprocesscost.Text = Tot_Cost_Amt
        Next
        GrandTotal += Tot_Cost_Amt
        ' TXT_Net_Finish_Cost.Text = FormatNumber(GrandTotal, 2, TriState.True, TriState.False, TriState.False)
        TXT_Net_Finish_Cost.Text = Tot_Cost_Amt
        'Dim Int_Calc_Amt As Double = Val(TXT_Net_Finish_Cost.Text)
        'If Val(Tot_Cost_Amt) = 0 Then Tot_Cost_Amt = TXT_Net_Finish_Cost.Text
        Dim salesubTotal As Decimal = GrandTotal
        Tot_Cost_Amt = 0
    End Sub
#End Region

    Private Sub TXT_Net_Sales_Cost_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then

        End If
    End Sub
    Private Sub txt_reed_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Rate_Calc()
    End Sub
    Private Sub txt_dent_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Rate_Calc()
    End Sub
    Private Sub txt_pick_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Rate_Calc()
    End Sub
    Private Sub txt_reed_space_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Rate_Calc()
    End Sub
#Region "PRINT CODE "
    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click
        _strQuery = New StringBuilder
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.EntryNo AS EntryNo")
            .Append(" ,format(A.Entry_Date ,'dd/MM/yyyy') as Date")
            .Append(" ,A.Fabric_Item_Name AS Type")
            .Append(" ,A.yarn_for As Name ")
            .Append(" ,A.Dent As Qty")
            .Append(" ,ISNULL(A.Yarn_Rate, A.Pick) AS Rate")
            .Append(" ,ISNULL(A.Avg_weight, A.Reed) AS [GstDiff%]")
            .Append(" ,A.Yarn_Amount As Amount")
            .Append(" FROM TrnFabricCost AS A ")
            .Append(" WHERE 1=1")
            .Append(" AND A.ENTRYNO>=" & Val(txt_From.Text) & " ")
            .Append(" AND A.ENTRYNO<=" & Val(txt_To.Text) & " ")
            .Append(" AND A.Yarn_Amount<>'0.00'")
            .Append(" AND UPPER(ISNULL(OP1,''))= 'COSTING INFORMATION'")
            .Append(" group BY ")
            .Append(" A.EntryNo")
            .Append(" ,A.Entry_Date")
            .Append(" ,A.Fabric_Item_Name")
            .Append(" ,A.Yarn_For ")
            .Append(" ,A.Dent")
            .Append(" ,A.Yarn_Rate")
            .Append(" ,A.Pick ")
            .Append(" ,A.Avg_weight ")
            .Append(" ,A.Reed ")
            .Append(" ,A.Yarn_Amount ")
            .Append(" ,A.ID ")
            .Append(" ORDER BY ")
            .Append("  CASE WHEN A.Fabric_Item_Name = 'FABRIC' THEN 1  WHEN A.Fabric_Item_Name = 'PACKING' THEN 2    WHEN A.Fabric_Item_Name = 'OVERHEAD' THEN 3    ELSE 4    END,")
            .Append(" A.EntryNo,A.Entry_Date,A.ID")
        End With
        strQuery = _strQuery.ToString
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim Tmp_Data_Table As New DataTable
        Tmp_Data_Table = DefaltSoftTable.Copy

        Dim RptTitle = "Mix Match Costing Report"
            Dim Date_Range = ""
            If Btn_Print.Enabled = True Then
                If txt_From.Text <> "" AndAlso txt_To.Text <> "" Then
                    REPORT_RPT_FILE_NAME = "MixMatchCostingReport"
                    NewReportPrint(Tmp_Data_Table, RptTitle, Date_Range)
                End If
            End If

        'pnl_Print.Visible = False
    End Sub
    Private Sub pnl_Print_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnl_Print.Validated
        pnl_Print.Visible = False
    End Sub
#End Region
    Private Sub TXT_Final_Grey_Cost_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Rate_Calc()
    End Sub
#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        'OnLoomPlaningEntry.SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        'OnLoomPlaningEntry.Load_GridLayout(FirstStage, Me.Name)
    End Sub
#End Region
#Region "GRID ITEM EVENTS FOR PACKING"
    Private Sub GrdWeavingcost_EnterRow(Sender As Object, e As FlexCell.Grid.EnterRowEventArgs) Handles GrdWeavingcost.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True

        GrdWeavingcost.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub GrdWeavingcost_Click(Sender As Object, e As EventArgs) Handles GrdWeavingcost.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub GrdWeavingcost_RowColChange(Sender As Object, e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdWeavingcost.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        GrdWeavingcost.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub GrdWeavingcost_LeaveCell(Sender As Object, e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdWeavingcost.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
        GrdWeavingcost.ActiveCell.BackColor = GrdWeavingcost.BackColor1
    End Sub
    Private Sub GrdWeavingcost_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdWeavingcost.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        GrdWeavingcost.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub GrdWeavingcost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdWeavingcost.LostFocus
        If _FrmLoad = True Then Exit Sub
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub GrdWeavingcost_Validated(sender As Object, e As EventArgs) Handles GrdWeavingcost.Validated
        If _FrmLoad = True Then Exit Sub
        GrdWeavingcost.Refresh()
    End Sub
    Private Sub GrdWeavingcost_LeaveRow(Sender As Object, e As FlexCell.Grid.LeaveRowEventArgs) Handles GrdWeavingcost.LeaveRow
        If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row
    End Sub
    Private Sub GrdWeavingcost_KeyDown(Sender As Object, e As KeyEventArgs) Handles GrdWeavingcost.KeyDown
        If _FrmLoad = True Then Exit Sub
        If GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "" Then GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "PER"
        If _ActivatedColName = "YARN_FOR" Then

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
                txt_Name_For_Grid_Selection.Text = GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text
                txt_Code_For_Grid_Selection.Text = ""
                Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                obj_Party_Selection.SINGLE_storeItem_SELECTION()
                txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA

                GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("YARN_FOR") + 1).Text = txt_Name_For_Grid_Selection.Text
                GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("OP2") + 1).Text = txt_Code_For_Grid_Selection.Text

                Rate_Calc()
            End If
        ElseIf _ActivatedColName = "FD_PD" Then
            If e.KeyCode = Keys.Space Then
                If GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "AMOUNT" Then
                    GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "PER"
                ElseIf GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "PER" Then
                    GrdWeavingcost.Cell(GrdWeavingcost.ActiveCell.Row, _WeavingDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "AMOUNT"
                End If
            End If
            Rate_Calc()
        ElseIf _ActivatedColName = "Pick" Then

            Rate_Calc()
        ElseIf _ActivatedColName = "REED" Then
            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send("{DOWN}")
            '    SendKeys.Send("{LEFT}")
            'End If
            If e.KeyCode = Keys.F1 Then
                GrdWeavingcost.ActiveCell.BackColor = GrdWeavingcost.BackColor1
                GrdWeavingcost.Cell(1, _WeavingDataTableGrid.Columns.IndexOf("Reed") + 1).SetFocus()
                GrdWeavingcost.Range(1, 0, GrdWeavingcost.Rows - 1, GrdWeavingcost.Cols - 1).BackColor = GrdWeavingcost.BackColor1
                GrdWeavingcost.Focus()
            End If
        ElseIf _ActivatedColName = "YARN_AMOUNT" Then
            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send("{DOWN}")
            '    SendKeys.Send("{LEFT}")
            'End If
            If e.KeyCode = Keys.F1 Then
                GrdWeavingcost.ActiveCell.BackColor = GrdWeavingcost.BackColor1
                GrdWeavingcost.Cell(1, _WeavingDataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).SetFocus()
                GrdWeavingcost.Range(1, 0, GrdWeavingcost.Rows - 1, GrdWeavingcost.Cols - 1).BackColor = GrdWeavingcost.BackColor1
                GrdWeavingcost.Focus()
            End If
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdWeavingcost.ActiveCell.Row
                Dim Yarn_Amt As Double = Val(GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
                Yarn_Amt = Val(GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).Text)
                If Yarn_Amt <> 0 Then
                    If GrdWeavingcost.Rows - 1 = GrdWeavingcost.ActiveCell.Row Then
                        GrdWeavingcost.Rows = GrdWeavingcost.Rows + 1
                        Fill_Current_Row_Sr_No(_WeavingDataTableGrid, GrdWeavingcost)
                    Else
                        GrdWeavingcost.Rows = GrdWeavingcost.Rows + 1
                        Fill_Current_Row_Sr_No(_WeavingDataTableGrid, GrdWeavingcost)
                    End If
                Else
                    GrdWeavingcost.Cell(i, _WeavingDataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                End If
            End If
        End If

        Rate_Calc()
    End Sub

#End Region
#Region "GRID ITEM EVENTS FOR OVERHEAD"
    Private Sub GrdFinishcost_EnterRow(Sender As Object, e As FlexCell.Grid.EnterRowEventArgs) Handles GrdFinishcost.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True

        GrdFinishcost.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub GrdFinishcost_Click(Sender As Object, e As EventArgs) Handles GrdFinishcost.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub GrdFinishcost_RowColChange(Sender As Object, e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdFinishcost.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        GrdFinishcost.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub GrdFinishcost_LeaveCell(Sender As Object, e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdFinishcost.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
        GrdFinishcost.ActiveCell.BackColor = GrdFinishcost.BackColor1
    End Sub
    Private Sub GrdFinishcost_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdFinishcost.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        GrdFinishcost.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub GrdFinishcost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdFinishcost.LostFocus
        If _FrmLoad = True Then Exit Sub
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub GrdFinishcost_Validated(sender As Object, e As EventArgs) Handles GrdFinishcost.Validated
        If _FrmLoad = True Then Exit Sub
        GrdFinishcost.Refresh()
    End Sub
    Private Sub GrdFinishcost_LeaveRow(Sender As Object, e As FlexCell.Grid.LeaveRowEventArgs) Handles GrdFinishcost.LeaveRow
        If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row
    End Sub
    Private Sub GrdFinishcost_KeyDown(Sender As Object, e As KeyEventArgs) Handles GrdFinishcost.KeyDown
        If _FrmLoad = True Then Exit Sub

        If _ActivatedColName = "Dent" Then
            Rate_Calc()

        ElseIf _ActivatedColName = "Pick" Then
            Rate_Calc()
        ElseIf _ActivatedColName = "REED" Then
            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send("{DOWN}")
            '    SendKeys.Send("{LEFT}")
            'End If
            'If e.KeyCode = Keys.F1 Then
            '    GrdFinishcost.ActiveCell.BackColor = GrdFinishcost.BackColor1
            '    GrdFinishcost.Cell(1, _FINISHDataTableGrid.Columns.IndexOf("Reed") + 1).SetFocus()
            '    GrdFinishcost.Range(1, 0, GrdFinishcost.Rows - 1, GrdFinishcost.Cols - 1).BackColor = GrdFinishcost.BackColor1
            '    GrdFinishcost.Focus()
            'End If
        ElseIf _ActivatedColName = "YARN_AMOUNT" Then
            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send("{DOWN}")
            '    SendKeys.Send("{LEFT}")
            'End If
            'If e.KeyCode = Keys.F1 Then
            '    GrdFinishcost.ActiveCell.BackColor = GrdFinishcost.BackColor1
            '    GrdFinishcost.Cell(1, _FINISHDataTableGrid.Columns.IndexOf("YARN_AMOUNT") + 1).SetFocus()
            '    GrdFinishcost.Range(1, 0, GrdFinishcost.Rows - 1, GrdFinishcost.Cols - 1).BackColor = GrdFinishcost.BackColor1
            '    GrdFinishcost.Focus()
            'End If
        ElseIf _ActivatedColName = "FD_PD" Then
            If e.KeyCode = Keys.Space Then
                If GrdFinishcost.Cell(GrdFinishcost.ActiveCell.Row, _FINISHDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "AMOUNT" Then
                    GrdFinishcost.Cell(GrdFinishcost.ActiveCell.Row, _FINISHDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "PER"
                ElseIf GrdFinishcost.Cell(GrdFinishcost.ActiveCell.Row, _FINISHDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "PER" Then
                    GrdFinishcost.Cell(GrdFinishcost.ActiveCell.Row, _FINISHDataTableGrid.Columns.IndexOf("FD_PD") + 1).Text = "AMOUNT"
                End If
            End If
            Rate_Calc()
        End If

        Rate_Calc()
    End Sub

#End Region
#Region "Button Click"
    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Change_Grid_Data = True

        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"
        Cost_Sheet_Ctrl_Visible_True()
        Call DefineDafaultValues()
        If txt_Entry_Date.Text = "" Then txt_Entry_Date.Text = "  /  /    "
        Me.txt_Entry_Date.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Txt_ImportEntry.Enabled = True
        Call DefineDafaultValuesFinishcost()
        Call defineGridColNameFinish()
        Call GenerateTableFinish(_FINISHDataTableGrid, GrdFinishcost)
        Call GridFormattingFinish(_FINISHDataTableGrid, GrdFinishcost)
        GrdFinishcost.Column(0).Visible = False
        GrdFinishcost.Row(0).Height = 31
        GrdFinishcost.DefaultRowHeight = 20
        txt_EntryNo.Focus()
        txt_EntryNo.Select()
    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        Last_Focused_Btn = "EDIT"
        _FORMMODE = "EDIT"
        txt_EntryNo.Visible = True
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST where 1=1 AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION' ORDER BY ENTRYNO DESC"
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
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        Call DefineDafaultValuesFinishcost()
        Call defineGridColNameFinish()
        Call GenerateTableFinish(_FINISHDataTableGrid, GrdFinishcost)
        Call GridFormattingFinish(_FINISHDataTableGrid, GrdFinishcost)
        GrdFinishcost.Column(0).Visible = False
        GrdFinishcost.Row(0).Height = 31
        GrdFinishcost.DefaultRowHeight = 20
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
        Change_Grid_Data = True
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        _FrmLoad = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST where 1=1 AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION' ORDER BY ENTRYNO DESC"
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
        End If
        Call DefineDafaultValuesFinishcost()
        Call defineGridColNameFinish()
        Call GenerateTableFinish(_FINISHDataTableGrid, GrdFinishcost)
        Call GridFormattingFinish(_FINISHDataTableGrid, GrdFinishcost)
        GrdFinishcost.Column(0).Visible = False
        GrdFinishcost.Row(0).Height = 31
        GrdFinishcost.DefaultRowHeight = 20
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
        _FrmLoad = False
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txt_EntryNo.Text) > 1 Then
            txt_EntryNo.Text = Val(txt_EntryNo.Text) - 1
            Dim Book_Vno As String = Generate_Book_Vno(txt_EntryNo.Text, _BookTrType)
            Call Validate_Entry_No(Book_Vno, _OfferTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txt_EntryNo.Text) >= 1 Then
            txt_EntryNo.Text = Val(txt_EntryNo.Text) + 1
            Dim Book_Vno As String = Generate_Book_Vno(txt_EntryNo.Text, _BookTrType)
            Call Validate_Entry_No(Book_Vno, _OfferTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        _FrmLoad = False
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            _FORMMODE = ""
        End If
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub

    Private Sub UC_Buttons1_CloseClick() Handles UC_Buttons1.CloseClick
        If _FORMMODE = "" Then
            Me.Close()
            Me.Dispose(True)
        Else
            If _FORMMODE = "VIEW" Then
                PnlGrdView.Visible = False
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                Me.Text = _old_Me_text
                _FORMMODE = ""
            Else
                _FORMMODE = ""
                Old_Date = txt_Entry_Date.Text
                ObjCls_General.Blank_Object(Me)
                txt_Entry_Date.Text = Old_Date
                _KeyFieldValue = 0
                Call Ctrl_Visible_False(Me.Controls)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
            End If
        End If
        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FORMMODE = "VIEW"
        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        sqL = "SELECT min(ENTRY_DATE) as ENTRY_DATE FROM TRNFABRICCOST where 1=1 AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION'"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_ViewFrom.Text = (DefaltSoftTable.Rows(0).Item("ENTRY_DATE"))
        End If
        Txt_ViewTO.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        Call View_Record()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"
        strQuery = "SELECT TOP 1 ENTRYNO FROM TRNFABRICCOST where 1=1 AND UPPER(ISNULL(OP1,'')) = 'COSTING INFORMATION' ORDER BY ENTRYNO DESC"
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txt_From.Text = Val(DefaltSoftTable.Rows(0).Item(0))
            txt_To.Text = Val(DefaltSoftTable.Rows(0).Item(0))
        End If
        If txt_Paper_Type.Text = "" Then txt_Paper_Type.Text = "PLAIN"


        pnl_Print.Visible = True
        txt_From.Focus()
        txt_From.SelectAll()
    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"
    End Sub

    Private Sub btn_View_Ok_Click(sender As Object, e As EventArgs) Handles btn_View_Ok.Click
        View_Record()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = "Mix Match Costing Report From :" & Txt_ViewFrom.Text & " To : " & Txt_ViewTO.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub Btn_CreatOverHeadItem_Click(sender As Object, e As EventArgs) Handles Btn_CreatOverHeadItem.Click
        MismatchcostingType.ShowDialog()
    End Sub

#End Region
End Class