Imports System.Text
Imports DevExpress.XtraGrid
Imports FlexCell

Public Class StoresPurchaseOrder
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
    Private _GodownCode As String = ""
    Private WithEvents txtgodowncode As New TextBox
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
    Private OfferApprove As String = ""

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
            .Append("CLEAR,")
            .Append("CLEAR_DATE,")
            .Append("CLEAR_REMARK,")
            .Append("SRNO,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("OfferNo,")
            .Append("OfferDate,")
            .Append("PartyOfferNo,")
            .Append("AgentOfferNo,")
            .Append("AccountCode,")
            .Append("TransportCode,")
            .Append("DespatchCode,")
            .Append("HeaderRemark,")
            .Append("Term1,")
            .Append("Term2,")
            .Append("Term3,")
            .Append("Term4,")
            .Append("despatchtocode,") 'party offer date
            .Append("ITEMGROUPCODE,")
            .Append("ITEMGROUPNAME,")
            .Append("YARN_DETAIL,") ' partno
            .Append("ITEMCODE,")
            .Append("ITEMNAME,")
            .Append("AGENTCODE,") ' location
            .Append("DEPARTMENTNAME,") ' DepartmentName
            .Append("LOOM_TYPE,") ' Departmancode
            .Append("SELVCODE,") 'HSNCODE
            .Append("REED,") 'gst rate
            .Append("SelvedgeName,")
            .Append("Process_Weight_Range,") 'GSM
            .Append("loomtype,")
            .Append("weavetypecode,") 'PARTYITEMNAME CODE
            .Append("loomtypecode,") ' MANUEL ENTRY SIZE
            .Append("CUTCODE,")
            .Append("CUTNAME,")
            .Append("DESCR,")
            .Append("DESIGNCODE,")
            .Append("DESIGNNO,")
            .Append("SHADECODE,")
            .Append("SHADENO,")
            .Append("MTR_WEIGHT,")
            .Append("LOTNO,")
            .Append("RATE,")
            .Append("GROSS_RATE,")
            .Append("RATE_DIS_PER,")
            .Append("NET_RATE,")
            .Append("PICK,")
            .Append("DENT,")
            .Append("PROCESSCODE,")
            .Append("RDVALUE,")
            .Append("RDON,") 'Fright
            .Append("CDVALUE,") 'Delivery
            .Append("CDON,")
            .Append("CANCEL_QTY,")
            .Append("PROCESSNAME,")
            .Append("WESTAGE,")
            .Append("LENGTH,")
            .Append("MONOGRAM_TYPE,")
            .Append("GODOWNCODE,")
            .Append("OP23,") 'APPROVE
            .Append("OP5,") ' comparisionno
            .Append("OP6,") ' compare bookno
            .Append("OP4,") 'Payment terms
            .Append("ROWREMARK")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("CANCEL_QTY:N,")
            .Append("RDVALUE:N,")
            .Append("CDVALUE:N,")
            .Append("Mtr_Weight:N,")
            .Append("REED:N,")
            .Append("GROSS_RATE:N,")
            .Append("Process_Weight_Range:N,")
            .Append("RATE_DIS_PER:N,")
            .Append("NET_RATE:N,")
            .Append("PICK:N,")
            .Append("WESTAGE:N,")
            .Append("LENGTH:N,")
            .Append("DENT:N,")
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
            .Append("ITEMGROUPNAME:Group,")
            .Append("ITEMNAME:Item Name,")
            .Append("MTR_WEIGHT:Quantity,")
            .Append("loomtype:Qlty Name,")
            .Append("loomtypecode:Size,")
            .Append("SELVCODE:HSnCode,")
            .Append("DEPARTMENTNAME:Department,")
            .Append("YARN_DETAIL:PartNo,")
            .Append("AGENTCODE:Location,")
            .Append("CUTNAME:Per,")
            .Append("GROSS_RATE:Rate,")
            .Append("REED:GSt%,")
            .Append("RATE_DIS_PER:CD%,")
            .Append("NET_RATE:Net Rate,")
            .Append("DENT:Amount,")
            .Append("LOTNO:RateOn,")
            .Append("SelvedgeName:Mill Name,")
            .Append("Process_Weight_Range:GSM,") 'GSM
            .Append("DESCR:Descr,")
            .Append("OP4,") 'Payment terms
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("ITEMGROUPNAME:L,")
            .Append("ITEMNAME:L,")
            .Append("CUTNAME:L,")
            .Append("SELVCODE:L,")
            .Append("YARN_DETAIL:L,")
            .Append("AGENTCODE:L,")
            .Append("DEPARTMENTNAME:L,")
            .Append("DESCR:L,")
            .Append("DESIGNNO:L,")
            .Append("loomtypecode:L,")
            .Append("SHADENO:L,")
            .Append("loomtype:L,")
            .Append("CANCEL_QTY:R,")
            .Append("MTR_WEIGHT:R,")
            .Append("GROSS_RATE:R,")
            .Append("RATE_DIS_PER:R,")
            .Append("NET_RATE:R,")
            .Append("DENT:R,")
            .Append("RATE:R,")
            .Append("PROCESSNAME:L,")
            .Append("LOTNO:C,")
            .Append("RDVALUE:R,")
            .Append("RDON:C,")  'Fright
            .Append("CDVALUE:R,") 'Delivery
            .Append("REED:R,")
            .Append("CDON:C,")
            .Append("SelvedgeName:L,")
            .Append("Process_Weight_Range:L,") 'GSM
            .Append("OP4:L,") 'Payment terms
            .Append("ROWREMARK:L")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("ITEMGROUPNAME:L,")
            .Append("ITEMNAME:L,")
            .Append("YARN_DETAIL:L,")
            .Append("AGENTCODE:L,")
            .Append("CUTNAME:L,")
            .Append("SELVCODE:L,")
            .Append("DEPARTMENTNAME:L,")
            .Append("DESCR:L,")
            .Append("SHADENO:L,")
            .Append("loomtypecode:L,")
            .Append("SelvedgeName:L,")
            .Append("Process_Weight_Range:L,") 'GSM
            .Append("loomtype:L,")
            .Append("CANCEL_QTY:R,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("GROSS_RATE:R,")
            .Append("RATE_DIS_PER:R,")
            .Append("NET_RATE:R,")
            .Append("DENT:R,")
            .Append("PROCESSNAME:L,")
            .Append("LOTNO:C,")
            .Append("RDVALUE:R,")
            .Append("REED:R,")
            .Append("RDON:C,") 'Fright
            .Append("CDVALUE:R,")  'Delivery
            .Append("CDON:C,")
            .Append("OP4:L,") 'Payment terms
            .Append("ROWREMARK:L")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("ACOFCODE:N,")
            .Append("CLEAR:N,")
            .Append("CLEAR_DATE:N,")
            .Append("CLEAR_REMARK:N,")
            .Append("SRNO:Y,")
            .Append("ENTRYNO:N,")
            .Append("BookTrtype:N,")
            .Append("WESTAGE:N,")
            .Append("MONOGRAM_TYPE:N,")
            .Append("LENGTH:N,")
            .Append("BOOKVNO:N,")
            .Append("BookCode:N,")
            .Append("OfferNo:N,")
            .Append("GODOWNCODE:N,")
            .Append("despatchtocode:N,")
            .Append("weavetypecode:N,")
            .Append("OfferDate:N,")
            .Append("PartyOfferNo:N,")
            .Append("AgentOfferNo:N,")
            .Append("AccountCode:N,")
            .Append("TransportCode:N,")
            .Append("DespatchCode:N,")
            .Append("HeaderRemark:N,")
            .Append("Term1:N,")
            .Append("Term2:N,")
            .Append("Term3:N,")
            .Append("Term4:N,")
            .Append("YARN_DETAIL:" & _PartNoCoumn & ",")
            .Append("AGENTCODE:" & _LocationColumn & ",")
            .Append("DEPARTMENTNAME:" & _DepartMentColumn & ",") ' DepartmentName
            .Append("LOOM_TYPE:N,") ' Departmancode
            .Append("loomtype:" & _PartyItemColoumn & ",")
            .Append("loomtypecode:" & _SizeManuelEntryColoumn & ",")
            .Append("SELVCODE:" & _HsnCodeColumn & ",")
            .Append("ITEMCODE:N,")
            .Append("ITEMNAME:Y,")
            .Append("ITEMGROUPCODE:N,")
            .Append("ITEMGROUPNAME:" & _GroupName & ",")
            .Append("SelvedgeName:" & _MillNameColoumn & ",")
            .Append("Process_Weight_Range:" & _GsmColumn & ",") 'GSM
            .Append("CUTCODE:N,")
            .Append("DESCR:Y,")
            .Append("DESIGNCODE:N,")
            .Append("DESIGNNO:N,")
            .Append("SHADECODE:N,")
            .Append("SHADENO:N,")
            .Append("CUTNAME:N,")
            .Append("MTR_WEIGHT:Y,")
            .Append("LOTNO:" & _RateOnColumn & ",")
            .Append("RATE:N,")
            .Append("GROSS_RATE:Y,")
            .Append("RATE_DIS_PER:" & _CdColumn & ",")
            .Append("REED:" & _GstRateColumn & ",")
            .Append("NET_RATE:Y,")
            .Append("PICK:N,")
            .Append("DENT:Y,")
            .Append("PROCESSCODE:N,")
            .Append("PROCESSNAME:N,")
            .Append("RDVALUE:N,")
            .Append("RDON:N,")
            .Append("CDVALUE:N,")
            .Append("CDON:N,")
            .Append("OP23:N,")
            .Append("OP5:N,") ' comparisionno
            .Append("OP6:N,") ' compare bookno
            .Append("CANCEL_QTY:N,")
            .Append("OP4:L,") 'Payment terms
            .Append("ROWREMARK:Y")
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("DEPARTMENTNAME:N,")
            .Append("ITEMGROUPNAME:N,")
            .Append("ITEMNAME:N,")
            .Append("PROCESSNAME:N,")
            .Append("CUTNAME:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:5,")
            .Append("ITEMGROUPNAME:15,")
            .Append("ITEMNAME:15,")
            .Append("CUTNAME:6,")
            .Append("loomtype:12,")
            .Append("DESCR:9,")
            .Append("MTR_WEIGHT:10,")
            .Append("GROSS_RATE:8,")
            .Append("RATE_DIS_PER:6,")
            .Append("DEPARTMENTNAME:8,")
            .Append("YARN_DETAIL:8,")
            .Append("AGENTCODE:8,")
            .Append("NET_RATE:8,")
            .Append("DENT:9,")
            .Append("LOTNO:5,")
            .Append("SELVCODE:8,")
            .Append("RDVALUE:4,")
            .Append("loomtypecode:8,")
            .Append("RDON:5,")
            .Append("CDVALUE:4,")
            .Append("CDON:5,")
            .Append("REED:5,")
            .Append("SelvedgeName:10,")
            .Append("Process_Weight_Range:8,") 'GSM
            .Append("CANCEL_QTY:8,")
            .Append("PROCESSNAME:14,")
            .Append("ROWREMARK:1")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("MTR_WEIGHT:0,")
            .Append("RATE:0,")
            .Append("REED:0,")
            .Append("Process_Weight_Range:0,")
            .Append("GROSS_RATE:0,")
            .Append("RATE_DIS_PER:0,")
            .Append("NET_RATE:0,")
            .Append("PICK:0,")
            .Append("DENT:0,")
            .Append("PCS_BALES:0,")
            .Append("RDVALUE:0,")
            .Append("RDON:0,")
            .Append("CDVALUE:0,")
            .Append("WESTAGE:0,")
            .Append("LENGTH:0,")
            .Append("CDON:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y")
            .Append(",SELVCODE:Y")
            .Append(",MTR_WEIGHT:Y")
            .Append(",LOTNO:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("MTR_WEIGHT:NO-2,")
            .Append("RATE:NO-2,")
            .Append("REED:NO-2,")
            .Append("Process_Weight_Range:NO-3,")
            .Append("GROSS_RATE:NO-2,")
            .Append("RATE_DIS_PER:NO-2,")
            .Append("NET_RATE:NO-2,")
            .Append("PICK:NO-2,")
            .Append("DENT:NO-2,")
            .Append("PCS_BALES:NO-0,")
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
        grdObj.Rows = 7
    End Sub
    Private Sub gridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
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
    Private _GroupName As String = ""
    Private _CdColumn As String = ""
    Private _HsnCodeColumn As String = ""
    Private _GstRateColumn As String = ""
    Private _MillNameColoumn As String = ""
    Private _GsmColumn As String = ""
    Private _RateOnColumn As String = ""
    Private _PartNoCoumn As String = ""
    Private _LocationColumn As String = ""
    Private _DepartMentColumn As String = ""
    Private _BookCode As String = ""
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
#End Region


#Region "Sundary Grid Define"

#Region "Global String Builder Variable for grid bill sundry Item "
    Private _gridbsunRowNo As Integer = 0
    Private _DatabaseTableNamebsun = "trninvoicesundry"
    Private _gridbsunColNames As New StringBuilder
    Private _gridbsunColType As New StringBuilder
    Private _gridbsunColValidate As New StringBuilder
    Private _gridbsunCol_FocusByPass As New StringBuilder
    Private _FieldbsunDefaultValues As New StringBuilder
    Private _FieldbsunHeader As New StringBuilder
    Private _FieldbsunHeaderAlignment As New StringBuilder
    Private _FieldbsunNotRequiredForSave As New StringBuilder
    Private _FieldbsunNotVisibile As New StringBuilder
    Private _FieldbsunWidthSet As New StringBuilder
    Private _FieldbsunLocked As New StringBuilder
    Private _FieldbsunMasking As New StringBuilder
    Private _FieldbsunAlignMent As New StringBuilder
    Private _FieldLedgerNotRequiredForSave As New StringBuilder

    '------------ Extra Fields ------------------------------
    Private _ExtrabsunFieldDataTable As New StringBuilder
    Private _ExtrabsunField_Values_DataTable As New StringBuilder

    Private _ExtrabsunFieldOthers As New StringBuilder
    Private _ExtrabsunField_Values_Others As New StringBuilder

    Private _FieldbsunNameSameValueCopy As New StringBuilder
    Private _FieldbsunNameForTotal As New StringBuilder

    Private gridbsun_Table_ColNames() As String
    Private _DataTablegridbsun As New DataTable




    Private _gridbsunLastColNo As Integer = 0
    Private _GridSundMaxRow As Integer = 10
    Private _DefaultColOfgridbsun As Integer = 0
    Private _LastKeyPressValue_BSun As Integer = 0
    Private SRNO_Item As Integer = 1


#End Region
    Private Sub GenerateTablebsun(ByRef gridbsunTable As DataTable, ByRef grdObj As Grid)
        ObjCls_General.CreateDataTable(gridbsunTable, Me._gridbsunColNames.ToString().ToUpper(), "NO", Me._gridbsunColType.ToString())
        grdObj.ExtendLastCol = True
        _gridbsunLastColNo = gridbsunTable.Columns.Count
        grdObj.Cols = gridbsunTable.Columns.Count + 1
        grdObj.Rows = _GridSundMaxRow
    End Sub
    Public Sub InitializeGridbsunConfiguration()

        '------ Bill Sundry Grid Setting ----
        _gridbsunColNames = New StringBuilder
        With _gridbsunColNames
            .Append("ID,")
            .Append("SP_ACCOUNTCODE,")
            .Append("TAX_ACCOUNTCODE,")
            .Append("TOTALADD,")
            .Append("TOTALLESS,")
            .Append("DEBITAMT,")
            .Append("AMOUNT_FOR_TAX,")
            .Append("CREDITAMT,")
            .Append("DRCR,")
            .Append("SALESACCOUNTCODE,")
            .Append("ACCOUNTCODE,")
            .Append("OPPACCOUNTCODE,")
            .Append("NARRATION,")
            .Append("MTRC,")
            .Append("ENTRYDATE,")
            .Append("TRANS_FOR,")
            .Append("SRNO,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("billno,")
            .Append("billdate,")
            .Append("finaccountCode,")
            .Append("SunCode,")
            .Append("autoroundoff,")
            .Append("commu_total,")
            .Append("LONGNARR,")
            .Append("tax_per,")
            .Append("sunnature,")
            .Append("financepost,")
            .Append("addlesstype,")
            .Append("sunname,")
            .Append("calcby,")
            .Append("CALCBY_ORG,")
            .Append("CALCON_ORG,")
            .Append("calcon,")
            .Append("DEFAULTRATE,")
            .Append("calcrate,")
            .Append("calcamount")
        End With

        _gridbsunColType = New StringBuilder
        With _gridbsunColType
            .Append("TOTALADD:N,")
            .Append("TOTALLESS:N,")
            .Append("DEBITAMT:N,")
            .Append("AMOUNT_FOR_TAX:N,")
            .Append("CREDITAMT:N,")
            .Append("SRNO:N,")
            .Append("ENTRYNO:N,")
            .Append("commu_total:N,")
            .Append("tax_per:N,")
            .Append("DEFAULTRATE:N,")
            .Append("calcrate:N,")
            .Append("calcamount:N")
        End With

        _gridbsunColValidate = New StringBuilder
        With _gridbsunColValidate
        End With

        _gridbsunCol_FocusByPass = New StringBuilder
        With _gridbsunCol_FocusByPass

        End With

        _FieldbsunHeader = New StringBuilder
        With _FieldbsunHeader
            .Append("SRNO:S.No,")
            .Append("Sunname:Sundry Name,")
            .Append("calcby:Calc. By,")
            .Append("calcon:Calc. On,")
            .Append("calcrate:Rate,")
            .Append("calcamount:Amount")
        End With

        _FieldbsunHeaderAlignment = New StringBuilder
        With _FieldbsunHeaderAlignment
            .Append("SRNO:L,")
            .Append("Sundname:L,")
            .Append("calcby:L,")
            .Append("calcon:L,")
            .Append("calcrate:R,")
            .Append("calcamount:R")
        End With

        _FieldbsunAlignMent = New StringBuilder
        With _FieldbsunAlignMent
            .Append("SRNO:L,")
            .Append("Sunname:L,")
            .Append("calcby:L,")
            .Append("calcon:L,")
            .Append("calcrate:R,")
            .Append("calcamount:R")
        End With

        _FieldbsunNotVisibile = New StringBuilder
        With _FieldbsunNotVisibile
            .Append("ID:N,")
            .Append("SP_ACCOUNTCODE:N,")
            .Append("TAX_ACCOUNTCODE:N,")
            .Append("ACCOUNTCODE:N,")
            .Append("OPPACCOUNTCODE:N,")
            .Append("DEBITAMT:N,")
            .Append("CREDITAMT:N,")
            .Append("DRCR:N,")
            .Append("AMOUNT_FOR_TAX:N,")
            .Append("TOTALADD:N,")
            .Append("TOTALLESS:N,")
            .Append("SALESACCOUNTCODE:N,")
            .Append("NARRATION:N,")
            .Append("MTRC:N,")
            .Append("ENTRYDATE:N,")
            .Append("TRANS_FOR:N,")
            .Append("SRNO:Y,")
            .Append("ENTRYNO:N,")
            .Append("BookTrtype:N,")
            .Append("BOOKVNO:N,")
            .Append("BookCode:N,")
            .Append("billno:N,")
            .Append("billdate:N,")
            .Append("tax_per:N,")
            .Append("sunnature:Y,")
            .Append("finaccountCode:N,")
            .Append("SunCode:N,")
            .Append("autoroundoff:N,")
            .Append("commu_total:N,")
            .Append("LONGNARR:N,")
            .Append("sunnature:N,")
            .Append("financepost:N,")
            .Append("addlesstype:N,")
            .Append("sunname:Y,")
            .Append("calcby:Y,")
            .Append("CALCBY_ORG:N,")
            .Append("CALCON_ORG:N,")
            .Append("calcon:Y,")
            .Append("DEFAULTRATE:N,")
            .Append("calcrate:Y,")
            .Append("calcamount:Y")
        End With

        _FieldbsunNotRequiredForSave = New StringBuilder
        With _FieldbsunNotRequiredForSave
            .Append("ID:N,")
            .Append("CALCBY_ORG:N,")
            .Append("CALCON_ORG:N,")
            .Append("SALESACCOUNTCODE:N,")
            .Append("TOTALADD:N,")
            .Append("TOTALLESS:N,")
            .Append("LONGNARR:N,")
            .Append("SUNNAME:N,")
            .Append("DEBITAMT:N,")
            .Append("CREDITAMT:N,")
            .Append("NARRATION:N,")
            .Append("DEFAULTRATE:N,")
            .Append("MTRC:N,")
            .Append("ENTRYDATE:N")
        End With

        _FieldbsunWidthSet = New StringBuilder
        With _FieldbsunWidthSet
            .Append("SRNO:6,")
            .Append("sunname:27,")
            .Append("calcby:13,")
            .Append("calcon:20,")
            .Append("calcrate:16,")
            .Append("calcamount:1")
        End With

        _FieldbsunDefaultValues = New StringBuilder
        With _FieldbsunDefaultValues
            .Append("TOTALADD:0,")
            .Append("TOTALLESS:0,")
            .Append("DEBITAMT:0,")
            .Append("AMOUNT_FOR_TAX:0,")
            .Append("CREDITAMT:0,")
            .Append("SRNO:0,")
            .Append("ENTRYNO:0,")
            .Append("commu_total:0,")
            .Append("tax_per:0,")
            .Append("DEFAULTRATE:0,")
            .Append("calcrate:0,")
            .Append("calcamount:0")
        End With

        _FieldbsunMasking = New StringBuilder
        With _FieldbsunMasking
            .Append("CALCRATE:NO-2,")
            .Append("commu_total:NO-2,")
            .Append("CALCAMOUNT:NO-2")
        End With

        _FieldbsunLocked = New StringBuilder
        With _FieldbsunLocked
            .Append("SUNNAME:Y,")
            .Append("CALCAMOUNT:Y,")
            .Append("SRNO:Y")
        End With

        gridbsun_Table_ColNames = _gridbsunColNames.ToString.ToUpper.Split(",")
    End Sub
    Private Sub gridFormattingSundary(ByRef gridbsunTable As DataTable, ByRef grdBsun As Grid)

        ' 🔹 Common font for header row
        Dim headerFont As New Font("Calibri", 11.25F, FontStyle.Bold)


        ' 🔹 Apply formatting to Sundry Grid
        With ObjCls_General
            ._LibGridFormatting(gridbsunTable, grdBsun, "VISIBLE", Me._FieldbsunNotVisibile.ToString().ToUpper())
            ._LibGridFormatting(gridbsunTable, grdBsun, "WIDTH", Me._FieldbsunWidthSet.ToString().ToUpper())
            ._LibGridFormatting(gridbsunTable, grdBsun, "HEADER", Me._FieldbsunHeader.ToString())
            ._LibGridFormatting(gridbsunTable, grdBsun, "LOCK", Me._FieldbsunLocked.ToString().ToUpper())
            ._LibGridFormatting(gridbsunTable, grdBsun, "MASK", Me._FieldbsunMasking.ToString().ToUpper())
            ._LibGridFormatting(gridbsunTable, grdBsun, "ALIGNMENT", Me._FieldbsunAlignMent.ToString().ToUpper())
            ._LibGridFormatting(gridbsunTable, grdBsun, "HALIGNMENT", Me._FieldbsunHeaderAlignment.ToString().ToUpper())
        End With

        ' 🔹 Set header font for Sundry Grid
        For colIndex As Integer = 0 To grdBsun.Cols - 1
            grdBsun.Cell(0, colIndex).Font = headerFont
        Next

    End Sub
    Public Shared Sub FillSundryGrid(bookCode As String, grdObj As FlexCell.Grid, columnNames As String(), dataTableGrid As DataTable)
        ' 🔹 Step 1: Load data from database
        Dim strQuery As String =
            "SELECT A.*, A.autoround AS autoroundoff, B.SUNNAME " &
            "FROM TRNBILLSUNDRY A " &
            "INNER JOIN MSTBILLSUNDRY B ON A.SUNCODE = B.SUNCODE " &
            "WHERE BOOKCODE = '" & bookCode & "' " &
            "ORDER BY A.SRNO"

        sqL = strQuery
        sql_connect_slect()
        Dim dataTable As DataTable = DefaltSoftTable.Copy

        ' 🔹 Step 2: Clear existing rows in grid
        grdObj.AutoRedraw = False
        grdObj.Range(0, 0, grdObj.Rows - 1, grdObj.Cols - 1).DeleteByRow()

        ' 🔹 Step 3: Fill new records
        Genral.Fill_Records(dataTable, columnNames, grdObj, 0, True, "", False, ",")

        ' 🔹 Step 4: Setup base values
        For i As Integer = 1 To grdObj.Rows - 1
            grdObj.Cell(i, dataTableGrid.Columns.IndexOf("SRNO") + 1).Text = i.ToString()

            Dim sunName As String = grdObj.Cell(i, dataTableGrid.Columns.IndexOf("SUNNAME") + 1).Text.Trim()

            If sunName <> "TOTAL TAXABLE AMOUNT" Then
                grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCBY_ORG") + 1).Text = grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCBY") + 1).Text
                grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCON_ORG") + 1).Text = grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCON") + 1).Text
                grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
            Else
                grdObj.Cell(i, dataTableGrid.Columns.IndexOf("SUNNAME") + 1).ForeColor = Color.Red
            End If
        Next


        ' 🔹 Step 5: Reset CALCON column color
        grdObj.Range(1, dataTableGrid.Columns.IndexOf("CALCON") + 1, grdObj.Rows - 1, dataTableGrid.Columns.IndexOf("CALCON") + 1).ForeColor = grdObj.BackColor1


        ' 🔹 Step 6: Apply default values
        For Each row As DataRow In dataTable.Select("DEFAULTCALCON <> 'NIL'")
            Dim sunCode As String = row("SUNCODE").ToString().Trim()
            Dim defaultCalcon As String = row("DEFAULTCALCON").ToString().Trim()
            Dim defaultRate As Double = Val(row("DEFAULTRATE").ToString())

            For i As Integer = 1 To grdObj.Rows - 1
                If grdObj.Cell(i, dataTableGrid.Columns.IndexOf("SUNCODE") + 1).Text.Trim() = sunCode Then
                    grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCBY") + 1).Text = defaultCalcon

                    If defaultCalcon <> "PER%" Then
                        grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCON") + 1).Text = defaultCalcon
                        grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCRATE") + 1).Text = defaultRate.ToString("0.00")
                    Else
                        grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCON") + 1).Text = row("CALCON").ToString()
                        grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCRATE") + 1).Text = defaultRate.ToString("0.00")

                        Dim sunName As String = grdObj.Cell(i, dataTableGrid.Columns.IndexOf("SUNNAME") + 1).Text.Trim()
                        If sunName = "TCS" AndAlso Genral.GetNumberOfDecimalPlaces(defaultRate.ToString()) > 2 Then
                            grdObj.Cell(i, dataTableGrid.Columns.IndexOf("CALCRATE") + 1).Text = defaultRate.ToString("0.000")
                        End If
                    End If
                    grdObj.Range(i, dataTableGrid.Columns.IndexOf("CALCON") + 1, i, dataTableGrid.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
                End If
            Next
        Next

        ' 🔹 Step 7: Finalize grid
        grdObj.AutoRedraw = True
        grdObj.Refresh()
    End Sub


#Region "GRID BILL SUNDRY EVENTS"
    Private Sub grdbsun_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles grdBsun.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub grdbsun_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles grdBsun.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        Dim Focus_Col_No As Integer = _DataTablegridbsun.Columns.IndexOf("CALCBY")

        If _RowNo < grdBsun.Rows - 1 Then
            If _ActivatedColName = "CALCBY" Then
                'SendKeys.Send("{F2}")
            ElseIf _ActivatedColName = "CALCON" Then
                If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                    If _LastKeyPressValue_BSun = 37 Then
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                Else
                    'SendKeys.Send("{F2}")
                End If
            ElseIf _ActivatedColName = "CALCRATE" Then
                If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                    If _LastKeyPressValue_BSun = 37 Then
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf _ActivatedColName = "CALCAMOUNT" Then
                If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                    If _LastKeyPressValue_BSun = 37 Then
                        SendKeys.Send("+{TAB}")
                    Else
                        SendKeys.Send("{TAB}")
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub grdbsun_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles grdBsun.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True

        If _ActivatedColName = "CALCBY" Then
            If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text <> "NIL" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
            Else
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = grdBsun.BackColor1
            End If
        End If
    End Sub
    Private Sub grdbsun_EnterRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.EnterRowEventArgs) Handles grdBsun.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True '-- Disable for cell change envent 
        If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("SRNO") + 1).Text = "" Then
            SRNO_Item = SRNO_Item + 1
        End If
        Fill_Serial_No()
        _FrmLoad = False
    End Sub
    Private Sub grdbsun_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBsun.GotFocus
        'If _FrmLoad = True Then Exit Sub
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        _FrmLoad = False
    End Sub
    Private Sub grdbsun_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBsun.LostFocus
        If _FrmLoad = True Then Exit Sub
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub grdbsun_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBsun.Validated
        If _FrmLoad = True Then Exit Sub
        grdBsun.Refresh()
    End Sub
    Private Sub grdbsun_LeaveRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveRowEventArgs) Handles grdBsun.LeaveRow
        If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row

        If _ActivatedColName = "CALCAMOUNT" Then
            Dim Sundry_Amount As Double = 0
            Sundry_Amount = Val(grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
            If Sundry_Amount = 0 Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("SRNO") + 1).SetFocus()
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub grdbsun_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdBsun.KeyPress
        If _FrmLoad = True Then Exit Sub

        If _ActivatedColName = "SUNNAME" Then

        ElseIf _ActivatedColName = "CALCBY" Then
            If e.KeyChar.ToString.ToUpper = "P" Then
                If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PCS"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PCS" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PICK"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PICK" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                Else
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                End If
            ElseIf e.KeyChar.ToString.ToUpper = "N" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
            ElseIf e.KeyChar.ToString.ToUpper = "M" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "MTRS"
            ElseIf e.KeyChar.ToString.ToUpper = "A" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "AMOUNT"
            ElseIf e.KeyChar.ToString.ToUpper = "K" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "KGS"
            ElseIf e.KeyChar.ToString.ToUpper = "P" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
            ElseIf e.KeyChar.ToString.ToUpper = "B" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "BALE"
            ElseIf Asc(e.KeyChar) = 32 Then
                If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "MTRS"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "MTRS" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "AMOUNT"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "AMOUNT" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PICK"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PICK" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "KGS"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "KGS" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "BALE"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "BALE" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
                ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
                End If
            End If
            If e.KeyChar = "N" Or e.KeyChar = "M" Or e.KeyChar = "A" Or e.KeyChar = "K" Or e.KeyChar = "P" Or e.KeyChar = "B" Or Asc(e.KeyChar) = 32 Then
                Total_For_All_Grid_And_Calculation()
            End If

            If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = grdBsun.BackColor1
            Else
                If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text
                Else
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                    Else
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text
                    End If
                End If
                grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
            End If

            e.Handled = True
        ElseIf _ActivatedColName = "CALCON" Then
            If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%" Then
                If e.KeyChar.ToString.ToUpper = "G" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "GROSS AMOUNT"
                ElseIf e.KeyChar.ToString.ToUpper = "N" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                ElseIf Asc(e.KeyChar) = 32 Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "GROSS AMOUNT" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "GROSS AMOUNT"
                    End If
                End If
            ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PCS" Then
                If e.KeyChar.ToString.ToUpper = "P" Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PCS" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PCS"
                    End If
                ElseIf Asc(e.KeyChar) = 32 Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PCS" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PCS"
                    End If
                End If
            ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PICK" Then
                If e.KeyChar.ToString.ToUpper = "P" Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PICK" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PICK"
                    End If
                ElseIf Asc(e.KeyChar) = 32 Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PICK" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PICK"
                    End If
                End If
            ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "MTRS" Then
                If e.KeyChar.ToString.ToUpper = "M" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "MTRS"
                ElseIf e.KeyChar.ToString.ToUpper = "P" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                ElseIf Asc(e.KeyChar) = 32 Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "MTRS" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "MTRS"
                    End If
                End If
            ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "KGS" Then
                If e.KeyChar.ToString.ToUpper = "K" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "KGS"
                ElseIf e.KeyChar.ToString.ToUpper = "P" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                ElseIf Asc(e.KeyChar) = 32 Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "KGS" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "KGS"
                    End If
                End If
            ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "BALE" Then
                If e.KeyChar.ToString.ToUpper = "B" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "BALE"
                ElseIf e.KeyChar.ToString.ToUpper = "P" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                ElseIf Asc(e.KeyChar) = 32 Then
                    If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "BALE" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%"
                    ElseIf grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PER%" Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "BALE"
                    End If
                End If
            End If

            If e.KeyChar = "M" Or e.KeyChar = "K" Or e.KeyChar = "B" Or e.KeyChar = "G" Or e.KeyChar = "N" Or Asc(e.KeyChar) = 32 Then
                Total_For_All_Grid_And_Calculation()
            End If
            e.Handled = True
        End If
    End Sub
    Private Sub grdbsun_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdBsun.KeyDown
        If _FrmLoad = True Then Exit Sub

        _LastKeyPressValue_BSun = e.KeyValue

        If _ActivatedColName = "CALCBY" Then
            If e.KeyCode = Keys.Delete Then
                e.Handled = True
                Exit Sub
            End If
            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
                Total_For_All_Grid_And_Calculation()

                If grdBsun.ActiveCell.Text = "NIL" Then
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = ""
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Locked = True
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Locked = True

                    If e.KeyCode = Keys.Enter Then
                        Dim Focus_Col_No As Integer = _DataTablegridbsun.Columns.IndexOf("CALCBY")
                        If grdBsun.ActiveCell.Row + 1 < grdBsun.Rows Then
                            grdBsun.Cell(grdBsun.ActiveCell.Row + 1, Focus_Col_No).SetFocus()
                        Else
                            If Val(Lvl_Grossamt.Text) > 0 Then
                                Set_Grid_Focus_To_Default_Field()
                                grdBsun.Cell(1, _DataTablegridbsun.Columns.IndexOf("CALCBY")).SetFocus()
                                '_FrmLoad = True
                                'btnSave.Focus()
                                Exit Sub
                            Else
                                grdBsun.Cell(1, Focus_Col_No).SetFocus()
                            End If
                        End If
                    End If
                    If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
                        e.Handled = True
                        Exit Sub
                    End If
                Else
                    If Val(grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text) = 0 And Val(grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text) = 0 Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("DEFAULTRATE") + 1).Text
                    End If
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Locked = False
                    grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Locked = False
                    If e.KeyCode = Keys.Enter Then
                        SendKeys.Send("{RIGHT}")
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "CALCON" Then
            If e.KeyCode = Keys.Delete Then
                e.Handled = True
                Exit Sub
            ElseIf e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
                Total_For_All_Grid_And_Calculation()
            End If
        ElseIf _ActivatedColName = "CALCRATE" Then
            If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
                Total_For_All_Grid_And_Calculation()

                If e.KeyCode = Keys.Enter Then
                    Dim Focus_Col_No As Integer = _DataTablegridbsun.Columns.IndexOf("CALCBY")
                    If grdBsun.ActiveCell.Row + 1 < grdBsun.Rows Then
                        grdBsun.Cell(grdBsun.ActiveCell.Row + 1, Focus_Col_No).SetFocus()
                    Else
                        If Val(Lvl_Grossamt.Text) > 0 Then
                            'btnSave.Focus()
                        Else
                            grdBsun.Cell(1, Focus_Col_No).SetFocus()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#End Region


    Private Sub Total_For_All_Grid_And_Calculation()
        Try
            If _FORMMODE = "VIEW" Then Exit Sub


            Dim Tot_Pcs As Double
            Dim Tot_Mtr As Double = 0
            Dim Tot_Weight As Double = 0
            Dim Tot_Amount As Double

            Dim add_Less As String = ""
            Dim Calc_By As String = ""
            Dim Calc_On As String = ""
            Dim ResultValue As Double
            Dim RateFigure As Double = 0
            Dim Tot As Double = 0
            Dim Dr_Cr As String = ""
            Dim Fin_Post As String = ""
            Dim Total_Bales As Double = 0
            Dim Current_CaseNo As String = ""
            Dim CaseNo_Exist As Boolean = False
            Dim Amount_Add As Double = 0
            Dim Amount_Less As Double = 0




            Dim Upper_Amount As Double = Val(Lvl_Grossamt.Text.ToString)
            Dim Upper_Pcs As Double = Val(Lbl_TotalPcs.Text.ToString)
            Dim Upper_Pick As Double = 0
            Dim Upper_Mtrs As Double = Val(Lbl_TotalPcs.Text.ToString)
            Dim Cummu_Total As Double = Val(Lvl_Grossamt.Text.ToString)
            Dim Upper_Weight As Double = 0
            Dim Upper_Bales As Double = 1

            Dim AmtForGST As Double = 0
            Dim GSTName As String = ""

            For i As Int16 = 1 To grdBsun.Rows - 1
                GSTName = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text
                If Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text) > 0 And grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text = "" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("ADDLESSTYPE") + 1).Text = ""
                End If

                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" And grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("ADDLESSTYPE") + 1).Text <> "TOTAL" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = ""
                End If

                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("ADDLESSTYPE") + 1).Text <> "" Then
                    Calc_By = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text.ToString.ToUpper
                    Calc_On = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text.ToString.ToUpper
                    RateFigure = Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text)
                    add_Less = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("ADDLESSTYPE") + 1).Text.ToString.ToUpper
                    ResultValue = 0

                    If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("ADDLESSTYPE") + 1).Text <> "TOTAL" Then
                        If Calc_By = "MTRS" Then
                            If Calc_On = "MTRS" Then
                                ResultValue = Math.Round((Upper_Mtrs * RateFigure), 2, MidpointRounding.AwayFromZero)
                            ElseIf Calc_On = "PER%" Then
                                ResultValue = Math.Round((Upper_Mtrs * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                            End If
                        ElseIf Calc_By = "AMOUNT" Then
                            ResultValue = RateFigure
                        ElseIf Calc_By = "PCS" Then
                            If Calc_On = "PCS" Then
                                ResultValue = Math.Round((Upper_Pcs * RateFigure), 2, MidpointRounding.AwayFromZero)
                            ElseIf Calc_On = "PER%" Then
                                ResultValue = Math.Round((Upper_Pcs * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                            End If
                        ElseIf Calc_By = "KGS" Then
                            If Calc_On = "KGS" Then
                                ResultValue = Math.Round((Upper_Weight * RateFigure), 2, MidpointRounding.AwayFromZero)
                            ElseIf Calc_On = "PER%" Then
                                ResultValue = Math.Round((Upper_Weight * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                            End If
                        ElseIf Calc_By = "PICK" Then
                            If Calc_On = "PICK" Then
                                ResultValue = Math.Round((Upper_Pick * RateFigure), 2, MidpointRounding.AwayFromZero)
                            ElseIf Calc_On = "PER%" Then
                                ResultValue = Math.Round((Upper_Pick * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                            End If
                        ElseIf Calc_By = "BALE" Then
                            If Calc_On = "BALE" Then
                                ResultValue = Math.Round((Upper_Bales * RateFigure), 2, MidpointRounding.AwayFromZero)
                            ElseIf Calc_On = "PER%" Then
                                ResultValue = Math.Round((Upper_Bales * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                            End If
                        ElseIf Calc_By = "PER%" Then
                            If Calc_On = "GROSS AMOUNT" Then
                                ResultValue = Math.Round((Upper_Amount * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                            ElseIf Calc_On = "NET AMOUNT" Then
                                If GSTName = "CGST" Or GSTName = "SGST" Or GSTName = "IGST" Then
                                    For P As Int16 = 1 To grdBsun.Rows - 1
                                        If grdBsun.Cell(P, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "TOTAL TAXABLE AMOUNT" Then
                                            AmtForGST = Val(grdBsun.Cell(P, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                                        End If
                                    Next
                                    ResultValue = Math.Round((AmtForGST * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                                Else
                                    ResultValue = Math.Round((Cummu_Total * RateFigure) / 100, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If
                        ElseIf Calc_By = "AMOUNT" Then
                            ResultValue = RateFigure
                        End If

                        If ResultValue > 0 Then
                            If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("autoroundoff") + 1).Text = "YES" Then
                                grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = Math.Round(ResultValue, 0, MidpointRounding.AwayFromZero)
                            Else
                                grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = Math.Round(ResultValue, 2, MidpointRounding.AwayFromZero)
                            End If
                        ElseIf ResultValue = 0 Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                        End If
                    End If

                    If add_Less = "ADD" Then
                        Tot = Tot + Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                        Cummu_Total = Cummu_Total + Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                        Amount_Add = Amount_Add + Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                        If Book_Row("DRCR").ToString = "Cr" Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DRCR") + 1).Text = "CR"
                        ElseIf Book_Row("DRCR").ToString = "Dr" Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DRCR") + 1).Text = "DR"
                        End If
                    ElseIf add_Less = "LESS" Then
                        Tot = Tot - Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                        Cummu_Total = Cummu_Total - Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                        Amount_Less = Amount_Less + Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text)
                        If Book_Row("DRCR").ToString = "Cr" Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DRCR") + 1).Text = "DR"
                        ElseIf Book_Row("DRCR").ToString = "Dr" Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DRCR") + 1).Text = "CR"
                        End If
                    ElseIf add_Less = "TOTAL" Then
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = Cummu_Total
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = Cummu_Total
                    End If

                    If Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text) > 0 Then
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("COMMU_TOTAL") + 1).Text = Math.Round(Cummu_Total, 2, MidpointRounding.AwayFromZero)
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("AMOUNT_FOR_TAX") + 1).Text = Math.Round(Cummu_Total - Val(grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text), 2, MidpointRounding.AwayFromZero)
                    Else
                        If add_Less <> "TOTAL" Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("COMMU_TOTAL") + 1).Text = "0.00"
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("AMOUNT_FOR_TAX") + 1).Text = "0.00"
                        End If
                    End If

                    Dr_Cr = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DRCR") + 1).Text
                    Fin_Post = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("FINANCEPOST") + 1).Text

                    If Fin_Post = "YES" Then
                        If Dr_Cr = "DR" Then
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DEBITAMT") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CREDITAMT") + 1).Text = ""
                        Else
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CREDITAMT") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text
                            grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DEBITAMT") + 1).Text = ""
                        End If
                    Else
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DEBITAMT") + 1).Text = ""
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CREDITAMT") + 1).Text = ""
                    End If
                End If
            Next

            'Dim RoundNetAmt As Double = 0
            'RoundNetAmt = Math.Round(Cummu_Total, 0, MidpointRounding.AwayFromZero)
            'Lbl_NetAmt.Text = RoundNetAmt.ToString("0.00")

            'lbl_Round_Off.Text = RoundNetAmt - Cummu_Total
            'lbl_Net_Amount_Figure.Text = RoundNetAmt
            'Label_Decimal_Setting()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Private Sub Set_Grid_Focus_To_Default_Field()

        grdBsun.Locked = True
        _DefaultColOfgridbsun = _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1
        grdBsun.Cell(1, _DefaultColOfgridbsun).SetFocus()

        Fill_Serial_No()

        grdBsun.Locked = False
    End Sub
    Private Sub Fill_Serial_No()
        If grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdBsun.Cell(grdBsun.ActiveCell.Row, _DataTablegridbsun.Columns.IndexOf("SRNO") + 1).Text = grdBsun.ActiveCell.Row 'SRNO_Sun
        End If

    End Sub

    Public Function getAlter_Form_Query_BillSundry_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*, ")
            .Append(" B.SUNNAME, ")
            .Append(" A.CALCBY AS CALCBY_ORG, ")
            .Append(" A.CALCON AS CALCON_ORG ")
            .Append(" FROM TRNINVOICESUNDRY A , ")
            .Append(" MSTBILLSUNDRY B ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.SUNCODE=B.SUNCODE")
            .Append(" AND A.BOOKVNO='" & strKeyID & "'")
            .Append(" ORDER BY SRNO ")
        End With
        Return _strQuery.ToString
    End Function
#End Region


#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False

        If txtGodownName.Text = "" Then
            MsgBox("Invalid Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtGodownName.Focus()
            Exit Function
        ElseIf _BookCode.Trim = "" Then
            MsgBox("Invalid Book Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtBookName.Focus()
            Exit Function
        ElseIf txtAccount_Code.Text = "" Or txtAccountName.Text = "" Then
            MsgBox("Invalid Party Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtAccountName.Focus()
            Exit Function
        ElseIf txtOfferDate.Text = "  /  /    " Then
            MsgBox("Invalid Offer Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtOfferDate.Focus()
            Exit Function
        ElseIf txtDespatch_code.Text = "" Or txtDespatch.Text = "" Then
            MsgBox("Invalid Despatch", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtDespatch.Focus()
            Exit Function
        ElseIf Trim(txtOfferNo.Text) = "" Then
            MsgBox("Invalid Offer No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtOfferNo.Focus()
            Exit Function
        ElseIf Trim(txtEntryNo.Text) = "" Or Val(txtEntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            Exit Function
        ElseIf txtTransportName.Text = "" Or txtTr_code.Text = "" Then
            MsgBox("Invalid Transport Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtTransportName.Focus()
            Exit Function
        ElseIf txtAcOfName.Text = "" Or txtAcOfCode.Text = "" Then
            MsgBox("Invalid Transport Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtAcOfName.Focus()
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
            If Pnl_Rate_Disp.Visible = True Then
                Pnl_Rate_Disp.Visible = False
                GrdItem.Focus()
                Exit Sub
            End If

            If _FORMMODE = "" Then
                CLOSE_MNU_LOAD()
            Else
                If PNL_View.Visible = True Then
                    PNL_View.Visible = False
                    'Command_Button_Visibility("LOAD")
                    UC_Buttons1._ButtonEnableDisable("LOAD")
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
                    'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
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
                        'Command_Button_Visibility("LOAD")
                        'Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
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
                        'Call Command_Button_Visibility("LOAD")
                        'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
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
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        txtTerm1.Focus()
                        txtTerm1.Select()
                    End If
                Case "GRDBSUN"
                    'btnSave.Focus()
                    'btnSave.Select()
                    UC_Buttons1.BtnSave.Focus()
                Case "BTNSAVE"
                    txtEntryNo.Focus()
                Case "TXTTERM1"
                    grdBsun.Focus()
                Case "TXTTERM2"
                    grdBsun.Focus()
                Case "TXTTERM3"
                    grdBsun.Focus()
                Case "TXTTERM4"
                    grdBsun.Focus()
                Case Else
                    If Trim(txtAccountName.Text) = "" Then
                        txtAccountName.Focus()
                    ElseIf txtEntryNo.Text = "" Or Val(txtEntryNo.Text) = 0 Then
                        txtEntryNo.Focus()
                    ElseIf Trim(txtDespatch.Text) = "" Then
                        txtDespatch.Focus()
                    ElseIf Trim(txtTransportName.Text) = "" Then
                        txtTransportName.Focus()
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
        PNL_View.Width = Me.Width
        PNL_View.Height = Me.Height
        PNL_View.Location = New Point(0, 0)

        GridControl1.Width = PNL_View.Width - 25
        GridControl1.Height = PNL_View.Height - 100
        GridControl1.Location = New Point(3, 53)


        Pnl_Rate_Disp.Width = 411
        Pnl_Rate_Disp.Height = 308
        Pnl_Rate_Disp.Location = New Point(598, 152)


        _FrmLoad = True
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")

        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call gridFormatting(_DataTableGrid, GrdItem)

        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        'GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text




        InitializeGridbsunConfiguration()
        ' 🔹 Step 1: Initialize grdBsun
        Dim grid As Grid = Me.grdBsun
        Me.GenerateTablebsun(Me._DataTablegridbsun, grid)
        gridFormattingSundary(_DataTablegridbsun, grid)
        Me.grdBsun = grid
        Me.grdBsun.Enabled = False
        Me.grdBsun.Column(0).Visible = False
        Me.grdBsun.Row(0).Height = 20S
        grdBsun.Rows = 2


        Lbl_Tot_Mtr_Weight.Text = ""
        Lbl_TotalPcs.Text = ""
        SetTotalObjectPosition("MTR_WEIGHT", _DataTableGrid, GrdItem, Lbl_Tot_Mtr_Weight, lbl_Total)

        If _isCallerByOther = True Then
            'btnSave.Visible = True
            Call Alter_Form(_KeyFieldValue)
        Else
            'Command_Button_Visibility("LOAD")
            UC_Buttons1._ButtonEnableDisable("LOAD")
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
            'btnAdd.Focus()
            'btnAdd.Select()
        End If

        _FrmLoad = False

    End Sub



#End Region

#Region "TOTAL ALL ROWS "
    Private Sub Total_Upto_All_Grid_All_Row()
        If _FrmLoad = True Then Exit Sub

        Dim Tot_Mtr_Weight As Double = 0
        Dim Tot_GrossAmt As Double = 0
        Dim _Qty As Double = 0
        Dim _NetRate As Double = 0
        Dim gstRate As Double = 0
        Dim NetAmount As Double = 0
        Dim GstAmount As Double = 0
        Dim _GrossAmt As Double = 0
        For j As Int16 = 1 To GrdItem.Rows - 1

            Dim DIS_PER As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("RATE_DIS_PER") + 1).Text)
            Dim GROSS_RATE As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("GROSS_RATE") + 1).Text)
            Dim NET_RATE = Math.Round((GROSS_RATE) - (GROSS_RATE * DIS_PER / 100), 2)
            GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text = NET_RATE


            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
            _Qty = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
            _NetRate = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text)
            gstRate = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("REED") + 1).Text)
            _GrossAmt = _Qty * _NetRate
            Tot_GrossAmt += _GrossAmt

            GstAmount = Math.Round(_GrossAmt * gstRate / 100, 2)

            GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("PICK") + 1).Text = _GrossAmt
            GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("DENT") + 1).Text = GstAmount + _GrossAmt

            NetAmount = NetAmount + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("DENT") + 1).Text)
        Next
        Lbl_Tot_Mtr_Weight.Text = Tot_Mtr_Weight
        Lbl_Tot_Mtr_Weight.Text = IIf(Tot_Mtr_Weight > 0, Format(Val(Lbl_Tot_Mtr_Weight.Text), "0.000"), "")

        Lvl_Grossamt.Text = Tot_GrossAmt
        Lvl_Grossamt.Text = IIf(Tot_GrossAmt > 0, Format(Val(Lvl_Grossamt.Text), "0.000"), "")


        Dim RoundNetAmt As Double = 0
        RoundNetAmt = Math.Round(NetAmount, 0, MidpointRounding.AwayFromZero)
        Lbl_NetAmt.Text = RoundNetAmt.ToString("0.00")


        Total_For_All_Grid_And_Calculation()
    End Sub
#End Region

#Region "COMMAND BUTTON VISIBILITY CODE "
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)

        LblHelipStrip.Text = "F1=Next Step,F3=Delete Row,0 Enter Rate Show Old Rate"

        Lvl_Grossamt.Text = "0.00"
        Lbl_NetAmt.Text = "0.00"
        Lbl_TotalPcs.Text = "0.00"
        OfferApprove = "NO"
        'If Visibility_Flag = "LOAD" Then
        '    btnSave.Enabled = False
        '    btnAdd.Enabled = True
        '    btnEdit.Enabled = True
        '    btnDelete.Enabled = True
        '    btnView.Enabled = True
        '    btnEdit.Enabled = True
        '    btnDelete.Enabled = True
        '    btnView.Enabled = True
        '    btnPrint.Enabled = True
        'ElseIf Visibility_Flag = "BTNADD" Then
        '    btnSave.Enabled = True
        '    btnAdd.Enabled = False
        '    btnEdit.Enabled = False
        '    btnDelete.Enabled = False
        '    btnView.Enabled = False
        '    btnPrint.Enabled = False
        'ElseIf Visibility_Flag = "BTNEDIT" Then
        '    btnSave.Enabled = True
        '    btnAdd.Enabled = False
        '    btnEdit.Enabled = False
        '    btnDelete.Enabled = False

        '    btnView.Enabled = False
        '    btnPrint.Enabled = False
        'ElseIf Visibility_Flag = "BTNDELETE" Then
        '    btnSave.Enabled = True
        '    btnAdd.Enabled = False
        '    btnEdit.Enabled = False
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    btnView.Enabled = False
        '    btnPrint.Enabled = False
        'ElseIf Visibility_Flag = "BTNVIEW" Then
        '    btnSave.Enabled = False
        '    btnAdd.Enabled = False
        '    btnEdit.Enabled = False
        '    btnDelete.Enabled = False
        '    btnView.Enabled = False
        '    btnPrint.Enabled = False
        'End If
    End Sub
#End Region

#Region "SET FOCUS LAST CLICKED BTN "
    'Private Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)
    '    _FORMMODE = ""
    '    If Last_Focused_Btn = "ADD" Then
    '        btnAdd.Focus()
    '    ElseIf Last_Focused_Btn = "EDIT" Then
    '        btnEdit.Focus()
    '    ElseIf Last_Focused_Btn = "DELETE" Then
    '        btnDelete.Focus()
    '    ElseIf Last_Focused_Btn = "VIEW" Then
    '        btnView.Focus()
    '    ElseIf Last_Focused_Btn = "SAVE" Then
    '        btnAdd.Focus()
    '    End If
    'End Sub
#End Region

#Region "Button Click Event "
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports")
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
            'Command_Button_Visibility("LOAD")
            'Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            UC_Buttons1._ButtonEnableDisable("LOAD")
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
        Else
            CLOSE_MNU_LOAD()

        End If
    End Sub
    Private Sub CLOSE_MNU_LOAD()
        'If LEDGER_ENTER_DISPLAY_FROM = "_CallOther" Then
        Me.Close()
        Me.Dispose(True)
        LEDGER_ENTER_DISPLAY_FROM = ""
        'Else
        '    If _GenralOrderLoadBy = "ORDERMENU" Then
        '        Close()
        '        Me.Dispose(True)
        '        Main_MDI_Frm.EntryToolStripMenuItem.ShowDropDown()
        '        Main_MDI_Frm.OfferToolStripMenuItem.ShowDropDown()
        '        Main_MDI_Frm.GeneralOrderToolStripMenuItem.Select()
        '        _GenralOrderLoadBy = ""
        '    Else
        'Close()
        '        Me.Dispose(True)
        'Main_MDI_Frm.StoreToolStripMenuItem.ShowDropDown()
        'Main_MDI_Frm.OrderEntryToolStripMenuItem1.Select()
        _GenralOrderLoadBy = ""
        '    End If
        'End If
    End Sub
    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If Validate_Form_Values() = True Then
    '        _FrmLoad = True
    '        SaveRecord()
    '        _FrmLoad = False
    '        If Edit_From_View = True Then
    '            _FORMMODE = "VIEW"
    '        End If
    '    End If
    'End Sub
    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Edit_From_View = False
    '    _FrmLoad = False

    '    _FORMMODE = "ADD"
    '    Last_Focused_Btn = "ADD"
    '    txtBookName.Visible = True
    '    Command_Button_Visibility("BTNADD")

    '    ObjCls_General.Blank_Object(Me)
    '    txt_Clear.Text = "NO"
    '    txtBookName.Text = Book_Name
    '    txtBookCode.Text = Book_Code

    '    txtBookName.Focus()
    '    txtBookName.Select()
    'End Sub
    'Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
    '    Edit_From_View = False
    '    _FrmLoad = False
    '    _FORMMODE = "EDIT"
    '    Last_Focused_Btn = "EDIT"
    '    txtBookName.Visible = True
    '    Command_Button_Visibility("BTNEDIT")

    '    ObjCls_General.Blank_Object(Me)

    '    txtBookName.Text = Book_Name
    '    txtBookCode.Text = Book_Code

    '    txtBookName.Focus()
    '    txtBookName.Select()
    'End Sub
    'Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    Edit_From_View = False
    '    _FrmLoad = False
    '    _FORMMODE = "DELETE"
    '    Last_Focused_Btn = "DELETE"
    '    txtBookName.Visible = True
    '    Command_Button_Visibility("BTNDELETE")

    '    ObjCls_General.Blank_Object(Me)

    '    txtBookName.Text = Book_Name
    '    txtBookCode.Text = Book_Code

    '    txtBookName.Focus()
    '    txtBookName.Select()
    'End Sub
    'Private Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
    '    _FrmLoad = False

    '    _FORMMODE = "VIEW"
    '    Last_Focused_Btn = "VIEW"
    '    txtBookName.Visible = True
    '    Command_Button_Visibility("BTNVIEW")

    '    txtBookName.Text = Book_Name
    '    txtBookCode.Text = Book_Code

    '    sqL = " SELECT  FORMAT( min(OfferDate), 'dd/MM/yyyy') AS OfferDate  FROM TrnOffer WHERE  BookCode='" & txtBookCode.Text & "'"
    '    sql_connect_slect()
    '    If DefaltSoftTable.Rows.Count > 0 Then
    '        For Each dr As DataRow In DefaltSoftTable.Select()
    '            If dr.IsNull("OfferDate") Then dr("OfferDate") = Main_MDI_Frm.FINE_YEAR_START.Text
    '        Next
    '        txt_From.Text = DefaltSoftTable.Rows(0).Item("OfferDate")
    '    Else
    '        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
    '    End If
    '    txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")


    '    Txt_EntryType.Text = "SUMMERY"


    '    txtBookName.Focus()
    '    txtBookName.Select()
    'End Sub
    'Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
    '    If _userwrits = "N" Then
    '        MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If
    '    Offer_Printing.FORM_SELECTION_BY.Text = "ENTRY_DATA_FORM"
    '    Offer_Printing.BOOKCATEGORY.Text = "OFFER"
    '    Offer_Printing.Lbl_BEHAVIOUR.Text = ""
    '    Offer_Printing.Txt_bookName.Text = ""
    '    Offer_Printing.Date_frm.Text = "0"
    '    Offer_Printing.Date_to.Text = "0"
    '    Offer_Printing.txt_Stationary_Type.Text = "PLAIN"
    '    Offer_Printing.txt_Paper_Size.Text = "FULL"
    '    Offer_Printing.txtFormat.Text = "1"

    '    Offer_Printing.cmd_No_Wise.Focus()
    '    Offer_Printing.ShowDialog()

    'End Sub



    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        Edit_From_View = False
        _FORMMODE = "ADD"
        _FrmLoad = False
        txtBookName.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txt_Clear.Text = "NO"
        txtBookName.Text = Book_Name
        txtBookCode.Text = Book_Code

        'txtBookName.Focus()
        'txtBookName.Select()
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        Edit_From_View = False
        _FORMMODE = "EDIT"
        _FrmLoad = False
        txtBookName.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtBookName.Text = Book_Name
        txtBookCode.Text = Book_Code

        'txtBookName.Focus()
        'txtBookName.Select()
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        Edit_From_View = False
        _FORMMODE = "DELETE"
        _FrmLoad = False
        txtBookName.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtBookName.Text = Book_Name
        txtBookCode.Text = Book_Code

        'txtBookName.Focus()
        'txtBookName.Select()
        txtGodownName.Visible = True
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) - 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            Call Validate_Entry_No(Book_Vno, _OfferTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) + 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            Call Validate_Entry_No(Book_Vno, _OfferTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            If Edit_From_View = True Then
                _FORMMODE = "VIEW"
            End If
        End If
    End Sub

    Private Sub UC_Buttons1_CloseClick() Handles UC_Buttons1.CloseClick
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
            'Command_Button_Visibility("LOAD")
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
            'AttachButtonFocusEvents(Me)
            'Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
        Else
            CLOSE_MNU_LOAD()
            Me.Close()
            Me.Dispose(True)
        End If
    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FORMMODE = "VIEW"
        _FrmLoad = False
        txtBookName.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtBookName.Text = Book_Name
        txtBookCode.Text = Book_Code
        sqL = " SELECT  FORMAT( min(OfferDate), 'dd/MM/yyyy') AS OfferDate  FROM TrnOffer WHERE  BookCode='" & txtBookCode.Text & "'"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            For Each dr As DataRow In DefaltSoftTable.Select()
                If dr.IsNull("OfferDate") Then dr("OfferDate") = Main_MDI_Frm.FINE_YEAR_START.Text
            Next
            txt_From.Text = DefaltSoftTable.Rows(0).Item("OfferDate")
        Else
            txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        End If
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Txt_EntryType.Text = "SUMMERY"
        'txtBookName.Focus()
        'txtBookName.Select()
        txtGodownName.Focus()
        txtGodownName.Select()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        Offer_Printing.FORM_SELECTION_BY.Text = "ENTRY_DATA_FORM"
        Offer_Printing.BOOKCATEGORY.Text = "OFFER"
        Offer_Printing.Lbl_BEHAVIOUR.Text = ""
        Offer_Printing.Txt_bookName.Text = ""
        Offer_Printing.Date_frm.Text = "0"
        Offer_Printing.Date_to.Text = "0"
        Offer_Printing.txt_Stationary_Type.Text = "PLAIN"
        Offer_Printing.txt_Paper_Size.Text = "FULL"
        Offer_Printing.txtFormat.Text = "1"
        Offer_Printing.cmd_No_Wise.Focus()
        Offer_Printing.ShowDialog()
    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"

    End Sub
#End Region

#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE "
    'Private Sub btnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.GotFocus
    '    btnAdd.BackColor = Color.Coral
    'End Sub
    'Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.LostFocus
    '    btnAdd.BackColor = Me.BackColor
    'End Sub

    'Private Sub btnEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.GotFocus
    '    btnEdit.BackColor = Color.Coral
    'End Sub
    'Private Sub btnEdit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.LostFocus
    '    btnEdit.BackColor = Me.BackColor
    'End Sub

    'Private Sub btnDelete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.GotFocus
    '    btnDelete.BackColor = Color.Coral
    'End Sub
    'Private Sub btnDelete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.LostFocus
    '    btnDelete.BackColor = Me.BackColor
    'End Sub
    'Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.GotFocus
    '    btnView.BackColor = Color.Coral
    'End Sub
    'Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.LostFocus
    '    btnView.BackColor = Me.BackColor
    'End Sub
    'Private Sub btnSave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.GotFocus
    '    btnSave.BackColor = Color.Coral
    'End Sub
    'Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.LostFocus
    '    btnSave.BackColor = Me.BackColor
    'End Sub
    'Private Sub btnPrint_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.GotFocus
    '    btnPrint.BackColor = Color.Coral
    'End Sub
    'Private Sub btnPrint_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.LostFocus
    '    btnPrint.BackColor = Me.BackColor
    'End Sub
    'Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.GotFocus
    '    btnClose.BackColor = Color.Coral
    'End Sub
    'Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.LostFocus
    '    btnClose.BackColor = Me.BackColor
    'End Sub
#End Region

#Region "Label Value Setting "
    Private Sub Label_Decimal_Setting()
        If Val(Lbl_TotalPcs.Text) > 0 Then
            Lbl_TotalPcs.Text = FormatNumber(Val(Lbl_TotalPcs.Text), 3, TriState.True, TriState.False, TriState.True)
        Else
            Lbl_TotalPcs.Text = ""
        End If

        If Val(Lbl_Tot_Mtr_Weight.Text) > 0 Then
            Lbl_Tot_Mtr_Weight.Text = FormatNumber(Val(Lbl_Tot_Mtr_Weight.Text), 3, TriState.False, TriState.False, TriState.True)
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If
    End Sub

    Private Sub Label_Value_Nil_Rest()
        Lbl_TotalPcs.Text = ""
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

        Try

            sqL = " DELETE FROM trnOffer WHERE BOOKVNO='" & _BookVNo & "' and GODOWNCODE='" & _GodownCode & "' "
            sql_Data_Save_Delete_Update()


            sqL = "DELETE FROM TRNINVOICESUNDRY WHERE BOOKVNO ='" & _BookVNo & "'"
            sql_Data_Save_Delete_Update()


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
        strQuery = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " WHERE BOOKVNO='" & Book_Vno & "' and GODOWNCODE='" & _GodownCode & "' "
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
                'btnSave.Enabled = True
                txtOfferNo.Focus()
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, grdBsun)
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice", MsgBoxStyle.Information, "Soft-Tex PRO")
                    Change_Grid_Data = False
                    txtAccountName.Enabled = False
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
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
                'Command_Button_Visibility("LOAD")
                UC_Buttons1._ButtonEnableDisable("LOAD")
                If _Last_Saved_Entry_No > 0 Then
                    'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Else
                    'btnAdd.Focus()
                End If
                _FrmLoad = False
            End If
        Else
            If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
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
            .Append(" SELECT  TrnOffer.*, ")
            .Append(" FORMAT(TrnOffer.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, ")
            .Append(" FORMAT(TrnOffer.OfferDate,'dd/MM/yyyy') as F_OFFERCLEARDATE, ")
            .Append(" MstCity.cityname AS DESPATCH, ")
            .Append(" B.ItemName AS ITEMNAME, ")
            .Append(" D.ACCOUNTNAME, ")
            .Append(" I.ACCOUNTNAME AS MILLNAME, ")
            .Append(" MstTransport.TransportName, ")
            .Append(" F.AC_NAME AS AcOfName ")
            '.Append(" ,G.ITEMNAME AS PARTYITEMNAME ")
            .Append(" ,H.GroupName AS ITEMGROUPNAME  ")
            .Append(" ,J.Departmentname AS DEPARTMENTNAME")
            .Append(" FROM ")
            .Append(" TRNOFFER")
            .Append(" LEFT JOIN MSTCITY ON TRNOFFER.DESPATCHCODE=MSTCITY.CITYCODE")
            .Append(" LEFT JOIN MstStoreItem as B ON TRNOFFER.ITEMCODE=B.ItemCode")
            .Append(" LEFT JOIN MstMasterAccount AS D ON TRNOFFER.ACCOUNTCODE=D.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTTRANSPORT ON TRNOFFER.TRANSPORTCODE=MSTTRANSPORT.ID")
            .Append(" LEFT JOIN Mst_Acof_Supply AS F ON TRNOFFER.ACOFCODE=F.ID")
            '.Append(" LEFT JOIN MSTSTOREITEM  AS G ON TRNOFFER.weavetypecode=G.ITEMCODE")
            .Append(" LEFT JOIN MstStoreItemGroup AS H ON B.ItemGroupCode=H.GroupCode")
            .Append(" LEFT JOIN MstMasterAccount AS  I ON TRNOFFER.SelvedgeName=I.ACCOUNTCODE")
            .Append(" LEFT JOIN MstDepartment AS J ON TRNOFFER.LOOM_TYPE =J.Departmentcode ")

            .Append(" WHERE 1=1 ")
            .Append(" AND TRNOFFER.BOOKVNO='" & strKeyID & "'")
            .Append(" AND  TRNOFFER.GODOWNCODE='" & _GodownCode & "'")
            .Append(" ORDER BY TRNOFFER.SRNO ")
        End With


        Return strQuery.ToString
    End Function
#End Region

#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)
        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy

        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)

        txtTr_code.Text = tblTmp.Rows(0)("TRANSPORTCODE").ToString
        txtAccountName.Text = tblTmp.Rows(0)("ACCOUNTNAME").ToString
        txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        txtDespatch_code.Text = tblTmp.Rows(0)("DESPATCHCODE").ToString
        txtOfferDate.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        txt_Clear_Date.Text = tblTmp.Rows(0)("F_OFFERCLEARDATE").ToString
        txtAcOfCode.Text = tblTmp.Rows(0)("ACOFCODE").ToString
        'Txt_PartOfferDate.Text = tblTmp.Rows(0)("
        '").ToString
        OfferApprove = tblTmp.Rows(0)("OP23").ToString


        If Txt_PartOfferDate.Text = "" Then Txt_PartOfferDate.Text = "  /  /    "
        Generate_Date_For_DataBase(txtOfferDate)

        Lbl_Tot_Mtr_Weight.Text = tblTmp.Compute("SUM(MTR_WEIGHT)", "").ToString
        'lbl_Tot_Bales.Text = tblTmp.Compute("SUM(PCS_BALES)", "").ToString

        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)
        GrdItem.Refresh()
        GrdItem.Visible = True


        '-------------  Load Data Into grid Bill Sundry-------------
        sqL = getAlter_Form_Query_BillSundry_Details(strKeyID)
        sql_connect_slect()
        Dim tblSundTmp As New DataTable
        tblSundTmp = DefaltSoftTable.Copy
        grdBsun.AutoRedraw = False
        grdBsun.Range(0, 0, grdBsun.Rows - 1, grdBsun.Cols - 1).DeleteByRow()
        _gridbsunRowNo = 0
        Fill_Records(tblSundTmp, gridbsun_Table_ColNames, grdBsun, _gridbsunRowNo, True, "", False)


        If tblSundTmp IsNot Nothing AndAlso tblSundTmp.Rows.Count = 0 Then
            FillSundryGrid(_BookCode, grdBsun, gridbsun_Table_ColNames, _DataTablegridbsun)
        End If

        GSTInfoFill()

        Total_Upto_All_Grid_All_Row()
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, grdBsun)
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
    Private Sub txtBookName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBookName.KeyPress
        If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub

        DispList = False
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then

            BOOK_CATGER = "OFFER"
            BOOK_BHEWAR = "GENERAL"
            'Party_selection.txtSearch.Text = txtBookName.Text
            'obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
            'txtBookName.Text = MULTY_SELECTION_COLOUM_1_DATA
            'txtBookCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            Dim _Filterstring As String = " AND A.BOOKCATEGORY='" & BOOK_CATGER & "' AND ( A.BEHAVIOUR ='" & BOOK_BHEWAR & "') "
            Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtBookName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtBookCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("BookName") Then txtBookName.Text = selected("BookName").ToString()
            End If
            _BookCode = txtBookCode.Text
            Book_Name = txtBookName.Text
            Book_Code = txtBookCode.Text


            If _BookCode <> "" Then
                Dim TmpTbl As New DataTable
                sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & _BookCode & "' "
                sql_connect_slect()
                TmpTbl = DefaltSoftTable.Copy


                If TmpTbl.Rows.Count > 0 Then
                    Book_Row = TmpTbl(0)
                    AcCode_Filter_String = TmpTbl(0)("GROUP_CODE_FILTER_STRING").ToString
                    _BookTrType = TmpTbl(0)("BOOKTRTYPE").ToString
                    _PartyItemColoumn = GetValueOrNo(Book_Row, "OP50")
                    _SizeManuelEntryColoumn = GetValueOrNo(Book_Row, "OP51")

                    _GroupName = GetValueOrNo(Book_Row, "OP55")
                    _CdColumn = GetValueOrNo(Book_Row, "OP56")
                    _HsnCodeColumn = GetValueOrNo(Book_Row, "OP57")
                    _GstRateColumn = GetValueOrNo(Book_Row, "OP58")
                    _MillNameColoumn = GetValueOrNo(Book_Row, "OP59")
                    _GsmColumn = GetValueOrNo(Book_Row, "OP60")
                    _RateOnColumn = GetValueOrNo(Book_Row, "OP68")
                    _PartNoCoumn = GetValueOrNo(Book_Row, "OP73")
                    _LocationColumn = GetValueOrNo(Book_Row, "OP74")
                    _DepartMentColumn = GetValueOrNo(Book_Row, "OP75")

                End If



                If _FORMMODE <> "VIEW" Then
                    _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    SendKeys.Send("{TAB}")
                Else
                    'SendKeys.Send("{ENTER}")
                    SendKeys.Send("{TAB}")
                End If

                Call defineGridColName()
                Call GenerateTable(_DataTableGrid, GrdItem)
                Call gridFormatting(_DataTableGrid, GrdItem)

                GrdItem.Rows = 2
                GrdItem.Column(0).Visible = False
                'GrdItem.Row(0).Height = 31
                GrdItem.DefaultRowHeight = 28



                InitializeGridbsunConfiguration()
                Dim grid As Grid = Me.grdBsun
                Me.GenerateTablebsun(Me._DataTablegridbsun, grid)
                gridFormattingSundary(_DataTablegridbsun, grid)
                Me.grdBsun = grid
                Me.grdBsun.Enabled = False
                Me.grdBsun.Column(0).Visible = False
                Me.grdBsun.Row(0).Height = 20S
                grdBsun.Rows = 2


            End If
        End If
        e.Handled = True
    End Sub

    Public Function EntryData_General_Offer_txtBookName_Validated(ByVal _BookCode As String) As String
        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT TOP 1 A.*, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_OFFERDATE, ")
            .Append(" B.ACCOUNTNAME,C.AC_NAME AS ACOFNAME,F.ACCOUNTNAME AS AGENTNAME,")
            .Append(" D.TRANSPORTNAME,E.CITYNAME AS DESPATCH ")
            .Append(" FROM TRNOFFER AS A")
            .Append(" left join MstMasterAccount AS B ON  A.ACCOUNTCODE=B.ACCOUNTCODE")
            .Append(" left join Mst_Acof_Supply AS C ON A.ACOFCODE=C.ID  ")
            .Append(" left join MSTTRANSPORT D ON  A.TRANSPORTCODE=D.id ")
            .Append(" left join MSTCITY E  ON  A.DESPATCHCODE=E.CITYCODE ")
            .Append(" left join MstMasterAccount AS F  ON B.AGENTCODE=F.ACCOUNTCODE")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" AND  A.GODOWNCODE='" & _GodownCode & "'")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return strQuery.ToString
    End Function


    Private Sub txtBookName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookName.Validated
        If _FrmLoad = True Then Exit Sub

        If txtBookCode.Text = "" Or _BookCode = "" Then
            txtBookName.Focus()
            txtBookName.Select()
            Exit Sub
        ElseIf txtgodowncode.Text = "" Then
            txtBookName.Focus()
            txtBookName.Select()
            Exit Sub
        Else
            Dim TmpTbl As New DataTable
            AcCode_Filter_String = Book_Row("GROUP_CODE_FILTER_STRING").ToString  'TmpTbl(0)("group_code_filter_string").ToString
            _BookTrType = Book_Row("BOOKTRTYPE").ToString

            Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
            Ctrl_Visibility_With_One_Grid(True, Me.Controls, grdBsun)


            Dim Str_Qry As String = EntryData_General_Offer_txtBookName_Validated(_BookCode)
            Dim TblTmp As New DataTable
            sqL = Str_Qry
            sql_connect_slect()
            TblTmp = DefaltSoftTable.Copy


            Dim Last_Entry_No As Integer = 0
            If TblTmp.Rows.Count > 0 Then
                Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
            End If


            GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
            grdBsun.Cell(1, _DataTablegridbsun.Columns.IndexOf("SRNO") + 1).SetFocus()


            If _FORMMODE = "ADD" Then
                txt_Clear.Visible = False
                txtEntryNo.Text = Last_Entry_No + 1
                If Last_Entry_No > 0 Then
                    ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, TblTmp)
                    txtAccountName.Text = TblTmp(0)("ACCOUNTNAME").ToString
                    txtOfferDate.Text = TblTmp(0)("F_OFFERDATE").ToString
                    txtAcOfName.Text = TblTmp(0)("ACOFNAME").ToString
                    txtAccount_Code.Text = TblTmp(0)("ACCOUNTCODE").ToString
                    txtAcOfCode.Text = TblTmp(0)("ACOFCODE").ToString
                    txtDespatch_code.Text = TblTmp(0)("DESPATCHCODE").ToString
                    txtTr_code.Text = TblTmp(0)("TRANSPORTCODE").ToString
                    txtEntryNo.Text = Last_Entry_No + 1
                Else
                    txtOfferDate.Text = ObjCls_General.GetTodayDate_British
                    txtEntryNo.Text = "1"
                End If
                Generate_Date_For_DataBase(txtOfferDate)

                FillSundryGrid(_BookCode, grdBsun, gridbsun_Table_ColNames, _DataTablegridbsun)


                txtEntryNo.Focus()
                txtEntryNo.Select()
            ElseIf _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                If Last_Entry_No = 0 Then
                    MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    'txtBookName.Focus()
                    'txtBookName.Select()
                    txtGodownName.Focus()
                    txtGodownName.Select()
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
                    'txtBookName.Focus()
                    'txtBookName.Select()
                    txtGodownName.Focus()
                    txtGodownName.Select()
                Else
                    View_Record()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Account Name Txt Box Events "
    Private Sub txtAccountName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountName.KeyPress
        If _FrmLoad = True Then Exit Sub

        Dim Str_Qry As String = ""

        Str_In_Group = Replace(Book_Row("GROUP_CODE_FILTER_STRING").ToString, "'", "'")
        AcCode_Filter_String = "AND A.GROUPCODE IN " & Str_In_Group & " "

        DispList = False
        If Asc(e.KeyChar) = 27 Then Exit Sub


        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            'party_selection_book_code = Book_Code
            'Party_selection.txtSearch.Text = txtAccountName.Text
            'Call obj_Party_Selection.Invoice_Party_Selection()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    txtAccountName.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtAccount_Code.Text = MULTY_SELECTION_COLOUM_3_DATA
            'End If
            'Return_Master_Name = txtAccountName.Text
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtAccountName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtAccount_Code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then txtAccountName.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If

        If txtAccount_Code.Text <> "" Then
            Str_Qry = "SELECT a.*,A.AGENTCODE,B.CITYCODE,B.CITYNAME,C.ACCOUNTNAME,D.TRANSPORTNAME,A.TRANSPORTID AS TRANSPORTCODE FROM MstMasterAccount A,MSTCITY B,MstMasterAccount C,MSTTRANSPORT D WHERE 1=1 AND A.ACCOUNTCODE='" & txtAccount_Code.Text & "' AND A.CITYCODE=B.CITYCODE AND A.AGENTCODE=C.ACCOUNTCODE AND A.TRANSPORTID=D.ID"
            sqL = Str_Qry
            sql_connect_slect()
            _TmpDataTable = DefaltSoftTable.Copy

            If _TmpDataTable.Rows.Count > 0 Then
                txtAgentName.Text = _TmpDataTable(0)("ACCOUNTNAME").ToString
                If txtDespatch.Text = "" Then
                    txtDespatch.Text = _TmpDataTable(0)("CITYNAME").ToString
                    txtDespatch_code.Text = _TmpDataTable(0)("CITYCODE").ToString
                End If
                If txtTr_code.Text = "" Then
                    txtTransportName.Text = _TmpDataTable(0)("TRANSPORTNAME").ToString
                    txtTr_code.Text = _TmpDataTable(0)("TRANSPORTCODE").ToString
                End If


                txtAgent_code.Text = _TmpDataTable(0)("AGENTCODE").ToString
            End If

#Region "Party Wise Sundary Feel"
            If _FORMMODE = "ADD" AndAlso _TmpDataTable.Rows.Count > 0 Then
                Dim Cd_Row_No As Integer = 0
                FillSundryGrid(_BookCode, grdBsun, gridbsun_Table_ColNames, _DataTablegridbsun)

                If Val(_TmpDataTable(0)("CD").ToString) > 0 Then
                    For I As Int16 = 1 To grdBsun.Rows - 1
                        If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text = "0000-000000003" Then
                            Cd_Row_No = I
                            If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text = "PER%"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            End If
                            grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = Val(_TmpDataTable(0)("CD").ToString)
                        End If
                    Next
                    If Cd_Row_No > 0 Then
                        If grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).ForeColor = Color.Black
                        End If
                    End If
                End If

                Dim TD_Row_No As Integer = 0
                If Val(_TmpDataTable(0)("COMME").ToString) > 0 Then
                    For I As Int16 = 1 To grdBsun.Rows - 1
                        If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text = "0001-000000002" Then
                            Cd_Row_No = I
                            If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text = "PER%"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            End If
                            grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = Val(_TmpDataTable(0)("COMME").ToString)
                        End If
                    Next
                    If TD_Row_No > 0 Then
                        If grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).ForeColor = Color.Black
                        End If
                    End If
                End If

                Dim Freight_Row_No As Integer = 0
                If Val(_TmpDataTable(0)("FREIGHT").ToString) > 0 Then
                    For I As Int16 = 1 To grdBsun.Rows - 1
                        If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text = "0000-000000005" Then
                            Freight_Row_No = I
                            If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "BALE"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text = "BALE"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "BALE"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "BALE"
                            End If
                            grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = Val(_TmpDataTable(0)("FREIGHT").ToString)
                        End If
                    Next
                    If Freight_Row_No > 0 Then
                        If grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "BALE"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "BALE"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "BALE"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).ForeColor = Color.Black
                        End If
                    End If
                End If
                'RD BY MASTER=============================
                TD_Row_No = 0
                If Val(_TmpDataTable(0)("RD").ToString) > 0 Then
                    For I As Integer = 1 To grdBsun.Rows - 1
                        If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text = "0000-000000002" Then
                            'If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "TRADE DISCOUNT" Then
                            Cd_Row_No = I
                            If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = (_TmpDataTable(0)("RDTYPE").ToString)
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text = (_TmpDataTable(0)("RDTYPE").ToString)
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            End If
                            grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = Val(_TmpDataTable(0)("RD").ToString)

                            If _TmpDataTable(0)("RDTYPE").ToString = "MTRS" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "MTRS"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "MTRS"
                            ElseIf _TmpDataTable(0)("RDTYPE").ToString = "PCS" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PCS"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "PCS"
                            Else
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            End If

                        End If
                    Next
                    If TD_Row_No > 0 Then
                        If grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).ForeColor = Color.Black
                        End If
                    End If
                End If



                'TDS BY MASTER=============================
                TD_Row_No = 0
                If Val(_TmpDataTable(0)("TDS").ToString) > 0 Then
                    For I As Integer = 1 To grdBsun.Rows - 1
                        If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text = "0001-000000005" Then
                            'If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "TRADE DISCOUNT" Then
                            Cd_Row_No = I
                            If grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "PER%"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text = "PER%"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            End If
                            grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = Val(_TmpDataTable(0)("TDS").ToString)

                            If _TmpDataTable(0)("RDTYPE").ToString = "MTRS" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "MTRS"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "MTRS"
                            ElseIf _TmpDataTable(0)("RDTYPE").ToString = "PCS" Then
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "PCS"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "PCS"
                            Else
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                                grdBsun.Cell(I, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            End If

                        End If
                    Next
                    If TD_Row_No > 0 Then
                        If grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL" Then
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text = "NET AMOUNT"
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).ForeColor = Color.Black
                            grdBsun.Cell(Cd_Row_No, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).ForeColor = Color.Black
                        End If
                    End If
                End If
            End If
#End Region

            GSTInfoFill()
        End If

        If txtAgentName.Text = "" Then
            MsgBox("Agent Name Not Found For Selected Account", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtAccountName.Focus()
            txtAccountName.Select()
        End If
    End Sub
    Private Sub GSTInfoFill()
        Dim GSTState As String = ""


        'txtSample_Type.Text = "GST"

        sqL = "SELECT TOP 1 A.STATENAME ,C.GSTIN, C.MOBILE  FROM MSTSTATE A,MSTCITY B,MstMasterAccount C WHERE 1=1 AND B.CITYCODE=C.CITYCODE AND C.ACCOUNTCODE='" & txtAccount_Code.Text & "' AND A.STATEID=B.STATEID "
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            GSTState = DefaltSoftTable.Rows(0).Item("STATENAME").ToString
            LblHelipStrip.Text = "GstNo : " & DefaltSoftTable(0)("GSTIN").ToString & " , Mob. : " & DefaltSoftTable(0)("MOBILE").ToString

        End If
        Dim INNER_OUTER As String = ""

        If GSTState <> "" AndAlso COMPANY_TBL.Rows(0).Item("STATE").ToString <> "" Then
            If GSTState = COMPANY_TBL.Rows(0).Item("STATE").ToString Then
                INNER_OUTER = "INNER"
            Else
                INNER_OUTER = "OUTER"
            End If
        End If


        If INNER_OUTER = "INNER" Then
            For i As Int16 = 1 To grdBsun.Rows - 1
                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "IGST" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                End If
                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "CGST" Or grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "SGST" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text
                    If _FORMMODE = "ADD" Then
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DEFAULTRATE") + 1).Text
                    End If
                End If
            Next
        ElseIf INNER_OUTER = "OUTER" Then
            For i As Int16 = 1 To grdBsun.Rows - 1
                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "CGST" Or grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "SGST" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                End If
                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "IGST" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text
                    If _FORMMODE = "ADD" Then
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DEFAULTRATE") + 1).Text
                    End If
                End If
            Next
        Else
            For i As Int16 = 1 To grdBsun.Rows - 1
                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "CGST" Or grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "SGST" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = "NIL"
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = ""
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCAMOUNT") + 1).Text = ""
                End If
                If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNNAME") + 1).Text = "IGST" Then
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCBY_ORG") + 1).Text
                    grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCON_ORG") + 1).Text
                    If _FORMMODE = "ADD" Then
                        grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("CALCRATE") + 1).Text = grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("DEFAULTRATE") + 1).Text
                    End If
                End If
            Next
        End If

        Total_For_All_Grid_And_Calculation()

    End Sub
    Private Sub txtAccountName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.Validated
        If _FrmLoad = True Then Exit Sub

        If txtAccountName.Text = "" Or txtAccount_Code.Text <> "" Then
            If Return_Master_Name <> "" Then
                txtAccountName.Text = Return_Master_Name
                Return_Master_Name = ""
            End If
        End If
        Return_Master_Name = ""

        If Trim(txtAccountName.Text) = "" Then
            MsgBox("Invalid Input", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtAccountName.Focus()
            txtAccountName.Select()
        End If
    End Sub
#End Region

#Region "A/c Of Txt Box Events"
    Private Sub txtAcOfName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAcOfName.KeyPress
        If _FrmLoad = True Then Exit Sub

        Dim Str_Qry As String = ""

        DispList = False
        If Asc(e.KeyChar) = 27 Then Exit Sub


        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            'Party_selection.txtSearch.Text = txtAcOfName.Text
            'obj_Party_Selection.SINGLE_ACC_OF_SELECTION()
            'txtAcOfName.Text = MULTY_SELECTION_COLOUM_1_DATA
            'txtAcOfCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            'Return_Master_Name = txtAcOfName.Text
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_ACC_OF_SELECTION(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtAcOfName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtAcOfCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("A/C Of") Then txtAcOfName.Text = selected("A/C Of").ToString()
            End If
            SendKeys.Send("{tab}")
        End If

        If _FORMMODE = "ADD" Then
            If txtAcOfCode.Text <> "." Then
                sqL = "SELECT A.CITY_CODE AS CITYCODE,B.CITYNAME FROM Mst_Acof_Supply A,MSTCITY B WHERE 1=1 AND A.ID='" & txtAcOfCode.Text & "' AND A.CITY_CODE=B.CITYCODE "
                sql_connect_slect()
                _TmpDataTable = DefaltSoftTable.Copy
                If _TmpDataTable.Rows.Count > 0 Then
                    If txtDespatch.Text = "" Then
                        txtDespatch.Text = _TmpDataTable(0)("CITYNAME").ToString
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtAcOfName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcOfName.Validated
        If _FrmLoad = True Then Exit Sub

        If txtAcOfName.Text = "" Or txtAcOfCode.Text <> "" Then
            If Return_Master_Name <> "" Then
                txtAcOfName.Text = Return_Master_Name
                Return_Master_Name = ""
            End If
        End If
        Return_Master_Name = ""

        If Trim(txtAcOfName.Text) = "" Then
            MsgBox("Invalid Input", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtAcOfName.Focus()
            txtAcOfName.Select()
        End If
    End Sub
#End Region

#Region "Despatch Txt Box Events"
    Private Sub txtDespatch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDespatch.KeyPress
        If _FrmLoad = True Then Exit Sub

        DispList = False
        If Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            'Party_selection.txtSearch.Text = txtDespatch.Text
            'obj_Party_Selection.SINGLE_City_SELECTION()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    txtDespatch.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtDespatch_code.Text = MULTY_SELECTION_COLOUM_3_DATA
            'End If
            'Return_Master_Name = txtDespatch.Text
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_City_SELECTION("")
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtDespatch.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtDespatch_code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("cityname") Then txtDespatch.Text = selected("cityname").ToString()
            End If
            SendKeys.Send("{tab}")
        End If

    End Sub
    Private Sub txtDespatch_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDespatch.Validated
        If _FrmLoad = True Then Exit Sub

        If txtDespatch.Text = "" Or txtDespatch_code.Text <> "" Then
            If Return_Master_Name <> "" Then
                txtDespatch.Text = Return_Master_Name
                Return_Master_Name = ""
            End If
        End If
        Return_Master_Name = ""

        If Trim(txtDespatch.Text) = "" Then
            MsgBox("Invalid Input", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtDespatch.Focus()
            txtDespatch.Select()
        End If
    End Sub
#End Region

#Region "Transport Txt Box Events "
    Private Sub txtTransportName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransportName.KeyPress
        If _FrmLoad = True Then Exit Sub

        DispList = False
        If Asc(e.KeyChar) = 27 Then Exit Sub


        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            'Party_selection.txtSearch.Text = txtTransportName.Text
            'obj_Party_Selection.SINGLE_TRANSPORT_SELECTION()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    txtTransportName.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtTr_code.Text = MULTY_SELECTION_COLOUM_3_DATA
            'End If
            'Return_Master_Name = txtTransportName.Text
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_TRANSPORT_SELECTION("")
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtTransportName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtTr_code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("TransportName") Then txtTransportName.Text = selected("TransportName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub txtTransportName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransportName.Validated
        If _FrmLoad = True Then Exit Sub

        If txtTransportName.Text = "" Or txtTr_code.Text <> "" Then
            If Return_Master_Name <> "" Then
                txtTransportName.Text = Return_Master_Name
                Return_Master_Name = ""
            End If
        End If
        Return_Master_Name = ""

        If Trim(txtTransportName.Text) = "" Or Trim(txtTr_code.Text) = "" Then
            MsgBox("Invalid Input", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtTransportName.Focus()
            txtTransportName.Select()
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
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("weavetypecode") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("weavetypecode") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOOM_TYPE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOOM_TYPE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "PCS"




        If _ActivatedColName = "CUTNAME" Then
            If e.KeyCode = Keys.Enter Then
                txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text
                txt_Code_For_Grid_Selection.Text = ""

                Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                obj_Party_Selection.SINGLE_Cut_SELECTION(" AND CATEGORY='STORE' ")
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA

                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = txt_Code_For_Grid_Selection.Text
                    Dim Cut_Name As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text
                    If txt_Name_For_Grid_Selection.Text <> "" Then
                        'SendKeys.Send("{ENTER}")
                    End If
                End If
            End If
            txt_Name_For_Grid_Selection.Text = ""
        ElseIf _ActivatedColName = "ITEMGROUPNAME" Then
            If e.KeyCode = Keys.Enter Then
                txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).Text
                txt_Code_For_Grid_Selection.Text = ""
                Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text
                obj_Party_Selection.SINGLE_StoreItemGroup_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA

                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = txt_Code_For_Grid_Selection.Text
                    If txt_Name_For_Grid_Selection.Text <> "" Then
                        'SendKeys.Send("{ENTER}")
                    End If
                End If
            End If
            txt_Name_For_Grid_Selection.Text = ""

        ElseIf _ActivatedColName = "LOTNO" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "PCS"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "PCS" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "KGS"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "KGS" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "PCS"
                End If
            End If
        ElseIf _ActivatedColName = "YARN_DETAIL" Then
            If e.KeyCode = Keys.Enter Then
                Dim REPAIRING_ISSUE_ID As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_DETAIL") + 1).Text
                Dim _filter As String = " and A.PartNo  ='" & REPAIRING_ISSUE_ID & "'"
                _FeelMasterInfo(_filter)

                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).SetFocus()
            End If
        ElseIf _ActivatedColName = "ITEMNAME" Then
            If e.KeyCode = Keys.Enter Then
                If Change_Grid_Data = True Then

                    'txt_Name_For_Grid_Selection.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
                    'txt_Code_For_Grid_Selection.Text = ""
                    'Party_selection.txtSearch.Text = txt_Name_For_Grid_Selection.Text

                    'If _GroupName = "Y" Then
                    '    Dim Item_Group_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text
                    '    GROUP_WISE_MULTY_PARTY_SELECT = " AND A.ITEMGROUPCODE='" & Item_Group_Code & "'"
                    'End If

                    'Dim _LoadQuery = NewSelectionList.MstStoreItem_Select(GROUP_WISE_MULTY_PARTY_SELECT)
                    'Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Store_Item), txt_Name_For_Grid_Selection.Text, "SINGLE")
                    'If selected IsNot Nothing Then
                    '    If selected.ContainsKey("ACCOUNTCODE") Then
                    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = selected("ACCOUNTCODE").ToString()
                    '    End If
                    '    If selected.ContainsKey("ItemName") Then
                    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = selected("ItemName").ToString()
                    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("HSNCODE") + 1).Text = selected("HsnCode").ToString()
                    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SELVCODE") + 1).Text = selected("HsnCode").ToString()
                    '    End If

                    '    Dim REPAIRING_ISSUE_ID As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
                    '    Dim _filter As String = " and A.ItemCode  ='" & REPAIRING_ISSUE_ID & "'"
                    '    _FeelMasterInfo(_filter)
                    'End If
                    Dim Rowno As Integer = GrdItem.ActiveCell.Row
                    ' Sirf 4 column list me show honge
                    Dim _filterBookvno As String = ""
                    Dim _StrQuery As New StringBuilder
                    With _StrQuery
                        .Append(" SELECT ")
                        .Append(" 'False' AS TickMark, ")
                        .Append(" A.Srno, ")
                        .Append(" A.PACK_SLIP_NO AS ComparisionNo, ")
                        .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy')  AS Date, ")
                        .Append(" E.AccountName AS AccountName, ")
                        .Append(" A.ITEMCODE as ACCOUNTCODE,")
                        .Append(" B.ItemName AS ItemName, ")
                        .Append(" a.BookVno As ItemCode ")
                        .Append(" FROM TrnPackingSlip AS A ")
                        .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE ")
                        .Append(" LEFT JOIN MstMasterAccount AS E ")
                        .Append(" ON A.ACCOUNTCODE = E.ACCOUNTCODE ")
                        .Append(" WHERE 1=1 ")
                        .Append(" and A.ACCOUNTCODE='" & txtAccount_Code.Text & "'")
                        .Append(" and A.Booktrtype='CESS1'")
                        .Append(" and A.OP24='YES'")
                        .Append("  AND NOT EXISTS ")
                        .Append("  (   ")
                        .Append(" SELECT 1  ")
                        .Append(" FROM TrnOffer AS B  ")
                        .Append(" WHERE ")
                        .Append(" B.OP6 = A.BookVno ")
                        .Append(" And B.ITEMCODE = A.ITEMCODE ")
                        .Append("  )")
                        '.Append(" AND A.BOOKVNO IN ('" & ReqBookvnorawData & "') ")
                    End With

                    'Dim _LoadQuery = _StrQuery.ToString
                    sqL = _StrQuery.ToString()
                    sql_connect_slect()
                    Dim _Tmptbl As DataTable = DefaltSoftTable.Copy
                    Dim _FItemcodeilter As String = ""
                    Dim ExtracolumnsToHide = {"Srno"}
                    'Dim selectedList1 = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP6") + 1).Text, "MULTY")
                    Dim selectedList1 = SingleAccountSelectionFormDatatable(_Tmptbl, Nothing, GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text, "MULTY", "YES", ExtracolumnsToHide)
                    If selectedList1 IsNot Nothing Then

                        For Each rowDict As Dictionary(Of String, Object) In selectedList1
                            If rowDict IsNot Nothing AndAlso rowDict.ContainsKey("ACCOUNTCODE") Then
                                _FItemcodeilter = rowDict("ACCOUNTCODE").ToString()
                                Dim BookVno = rowDict("ItemCode").ToString()
                                Dim comparisionno = rowDict("ComparisionNo").ToString()

                                Dim Srno = Val(rowDict("Srno").ToString())
                                Dim _DetailQuery As New StringBuilder
                                With _DetailQuery
                                    .Append(" SELECT ")
                                    .Append(" 'False' AS TickMark, ")
                                    .Append(" A.PACK_SLIP_NO AS QuotationNo, ")
                                    .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy')  AS Date, ")
                                    .Append(" E.AccountName AS AccountName, ")
                                    .Append(" A.AccountCode, ")
                                    .Append(" B.ItemName AS ItemName, ")
                                    .Append(" B.HSNCODE AS HsnCode, ")
                                    .Append(" A.Mtr_weight AS Qty, ")
                                    .Append(" A.CUT_MTR AS GrossRate, ")
                                    .Append(" A.RDVALUE AS Dis, ")
                                    .Append(" A.WEIGHT AS Disamount, ")
                                    .Append(" A.RATE AS NetRate, ")
                                    .Append(" A.Amount AS Amount, ")
                                    .Append(" C.TYPE_NAME AS CompanyName, ")
                                    .Append(" C.TYPE_ID AS SHADECODE, ")
                                    .Append(" D.CUTNAME AS CutName, ")
                                    .Append(" A.CUTCODE AS CUTCODE, ")
                                    .Append(" A.OP11 As gst, ")
                                    .Append(" A.OP12 As Fright, ")
                                    .Append(" A.OP13 As Delivery, ")
                                    .Append(" A.OP4 As [Payment terms], ")
                                    .Append(" A.ITEMCODE, ")
                                    .Append(" A.OP7, ")
                                    .Append(" A.BOOKVNO ")
                                    .Append(" FROM TrnPackingSlip AS A ")
                                    .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE")
                                    .Append(" LEFT JOIN MstStoreItemType C  ON  A.SHADECODE = C.TYPE_ID ")
                                    .Append(" LEFT JOIN MstCutMaster AS D ")
                                    .Append(" ON A.CUTCODE = D.ID ")
                                    .Append(" LEFT JOIN MstMasterAccount AS E ")
                                    .Append(" ON A.ACCOUNTCODE = E.ACCOUNTCODE ")
                                    .Append(" WHERE 1=1 ")
                                    .Append(" AND B.ITEMCODE='" & _FItemcodeilter & "' ")
                                    .Append(" AND a.BOOKVNO='" & BookVno & "' ")
                                    .Append(" AND a.Srno='" & Srno & "' ")

                                End With
                                Dim dt As New DataTable
                                sqL = _DetailQuery.ToString()
                                sql_connect_slect()
                                dt = DefaltSoftTable.Copy
                                If dt.Rows.Count > 0 Then
                                    For i As Integer = 0 To dt.Rows.Count - 1
                                        Dim dr As DataRow = dt.Rows(i)

                                        'GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PACK_SLIP_NO") + 1).Text = dr("QuotationNo").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP6") + 1).Text = dr("QuotationNo").ToString()
                                        ' GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP18") + 1).Text = dr("Date").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = dr("ITEMCODE").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = dr("ItemName").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("HSNCODE") + 1).Text = dr("HsnCode").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("SELVCODE") + 1).Text = dr("HsnCode").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = dr("Qty").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("Gross_Rate") + 1).Text = dr("GrossRate").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("RDVALUE") + 1).Text = dr("Dis").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("WEIGHT") + 1).Text = dr("disamount").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("Net_Rate") + 1).Text = dr("NetRate").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("DENT") + 1).Text = dr("Amount").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("COMPANYNAME") + 1).Text = dr("CompanyName").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = dr("SHADECODE").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = dr("CUTCODE").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = dr("CutName").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP11") + 1).Text = dr("gst").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("REED") + 1).Text = dr("gst").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("RDON") + 1).Text = dr("Fright").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("CDVALUE") + 1).Text = dr("Delivery").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP4") + 1).Text = dr("Payment terms").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP7") + 1).Text = dr("BOOKVNO").ToString()
                                        'GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP22") + 1).Text = dr("OP7").ToString()
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP5") + 1).Text = comparisionno
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("OP6") + 1).Text = BookVno
                                        GrdItem.Cell(Rowno, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = Rowno
                                        GrdItem.Rows = GrdItem.Rows + 1
                                        Rowno += 1
                                    Next
                                End If
                            End If
                        Next
                    End If
                    Call Total_Upto_All_Grid_All_Row()
                End If
            End If
        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "MTR_WEIGHT" Or _ActivatedColName = "NET_RATE" Or _ActivatedColName = "REED" Or _ActivatedColName = "RATE_DIS_PER" Then
            If e.KeyCode = Keys.Enter Then
                Call Total_Upto_All_Grid_All_Row()
            End If


        ElseIf _ActivatedColName = "GROSS_RATE" Then
            If e.KeyCode = Keys.Enter Then
                If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROSS_RATE") + 1).Text) = 0 Then
                    Rate_Display()
                End If
                Call Total_Upto_All_Grid_All_Row()
            End If

            Dim DIS_PER As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE_DIS_PER") + 1).Text)
            Dim GROSS_RATE As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROSS_RATE") + 1).Text)

            Dim NET_RATE = ((GROSS_RATE) - (GROSS_RATE * DIS_PER / 100))
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text = NET_RATE

            Dim QTY As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text)
            Dim AMOUNT As Double = QTY * NET_RATE
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = AMOUNT
        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdItem.ActiveCell.Row
                Dim CUTNAME As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text
                Dim ITEMNAME As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text

                Dim ITEMGROUPNAME As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).Text
                If ITEMGROUPNAME = "" Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = ""
                End If
                Dim ITEMGROUPCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text
                If ITEMNAME = "" Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = ""
                End If
                'If CUTNAME = "" Then
                '    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = ""
                'End If
                Dim CUTCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text
                Dim QTY As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
                Dim ITEMCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
                Dim NET_RATE As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text)


                If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then

                    GrdItem.Rows = GrdItem.Rows + 1
                    Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    SendKeys.Send("{DOWN}")
                    SendKeys.Send("{RIGHT}")
                End If
            End If
        End If
    End Sub
    Private Sub _FeelMasterInfo(ByVal _FilterCond As String)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*,")
            .Append(" ISNULL(A.VatTaxPer,0) AS VatTaxPer  ")
            .Append(" ,ISNULL(A.MRP,0) AS MRP")
            .Append(" ,B.GroupName ")
            .Append(" ,C.CUTNAME ")
            .Append(" ,ISNULL(B.OP2,0) AS GsmCalculation ")
            .Append(" ,H.Departmentname")
            .Append(" FROM MstStoreItem AS A ")
            .Append(" LEFT JOIN MstStoreItemGroup AS B ON A.ITEMGROUPCODE=B.GroupCode ")
            .Append(" LEFT JOIN MstCutMaster AS C ON A.CUTCODE=C.ID ")
            .Append(" LEFT JOIN MstDepartment AS H ON A.OP8 =H.Departmentcode ")
            .Append(" WHERE 1=1")
            .Append(_FilterCond)
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).Text = DefaltSoftTable.Rows(0).Item("GroupName").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = DefaltSoftTable.Rows(0).Item("ITEMGROUPCODE").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = DefaltSoftTable.Rows(0).Item("ItemName").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = DefaltSoftTable.Rows(0).Item("ITEMCODE").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AGENTCODE") + 1).Text = DefaltSoftTable.Rows(0).Item("Goods_Type").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TAX_PER") + 1).Text = DefaltSoftTable.Rows(0).Item("VatTaxPer")
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Consume_Amt") + 1).Text = DefaltSoftTable.Rows(0).Item("MRP")
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Repairing_Rcpt_ID") + 1).Text = DefaltSoftTable.Rows(0).Item("GsmCalculation").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = DefaltSoftTable.Rows(0).Item("CUTNAME").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = DefaltSoftTable.Rows(0).Item("CUTCODE").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("HSNCODE") + 1).Text = DefaltSoftTable.Rows(0).Item("HSNCODE").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("YARN_DETAIL") + 1).Text = DefaltSoftTable.Rows(0).Item("PartNo").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DEPARTMENTNAME") + 1).Text = DefaltSoftTable.Rows(0).Item("Departmentname").ToString
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOOM_TYPE") + 1).Text = DefaltSoftTable.Rows(0).Item("OP8").ToString
        Else
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOAN_GROUP_BY_ID") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TAX_PER") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Consume_Amt") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Repairing_Rcpt_ID") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("HSNCODE") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DEPARTMENTNAME") + 1).Text = ""
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOOM_TYPE") + 1).Text = ""
            'GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOAN_RCPT_ID") + 1).Text = ""
            SendKeys.Send("{HOME}")
            SendKeys.Send("{RIGHT}")
            'GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOAN_RCPT_ID") + 1).SetFocus()
        End If

    End Sub
    Private Sub Fill_Rate()
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000003"
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Text = "PCS"
        End If

        Dim Item_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text

        If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NET_RATE") + 1).Text) <> 0 Then
            Exit Sub
        End If

        If Item_Code <> "" Then
            strQuery = "SELECT * FROM TRNCHALLAN WHERE ITEMCODE='" & Item_Code & "' AND ACCOUNTCODE='" & txtAccount_Code.Text & "'  AND NET_RATE>0 ORDER BY ENTRYNO "
            sqL = strQuery
            sql_connect_slect()
            _TmpDataTable = DefaltSoftTable.Copy


            If _TmpDataTable.Rows.Count = 0 Then
                strQuery = "SELECT * FROM MSTITEM WHERE ITEMCODE='" & Item_Code & "'"
                sqL = strQuery
                sql_connect_slect()
                _TmpDataTable = DefaltSoftTable.Copy


                _TmpDataRow = _TmpDataTable.Rows(0)
                Dim Item_Rate As Double = Val(_TmpDataRow("SALE_RATE").ToString)
                If Item_Rate <> 0 And GrdItem.ActiveCell.Row >= 1 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROSS_RATE") + 1).Text = Item_Rate
                    MsgBox("Rate From Item Master Is :" + Trim(Item_Rate.ToString), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    MsgBox("Rate From Item Master Is :" + Trim(Item_Rate.ToString), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                End If
            Else
                _TmpDataRow = _TmpDataTable.Rows(_TmpDataTable.Rows.Count - 1)
                Dim Item_Rate As Double = Val(_TmpDataRow("GROSS_RATE".ToString))
                Dim Chl_No As String = _TmpDataRow("CHALLANNO".ToString)
                Dim Dis_Per As Double = Val(_TmpDataRow("RATE_DIS_PER").ToString)
                If Item_Rate <> 0 And GrdItem.ActiveCell.Row >= 1 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROSS_RATE") + 1).Text = Item_Rate
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE_DIS_PER") + 1).Text = Dis_Per
                    MsgBox("Rate From Last Challan Is :" + Trim(Item_Rate.ToString) + " And Challan No Is :" + Chl_No, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    MsgBox("Rate From Last Challan Is :" + Trim(Item_Rate.ToString) + " And Challan No Is :" + Chl_No, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
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
    End Sub
#End Region

#Region " Txt Header Remark Events "
    Private Sub txtHeader_Remark_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHeader_Remark.KeyDown
        If _FrmLoad = True Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            GrdItem.Focus()
            GrdItem.Select()
        End If
    End Sub
#End Region

#Region "Save Code "
    Private Sub SaveRecord()
        Try
            If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
                MsgBox("Invalid Item Detail", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                GrdItem.Focus()
                GrdItem.Select()
                Exit Sub
            End If

            If txtAcOfCode.Text = "" Then
                txtAcOfCode.Text = "0000-000000001"
            End If


            'If _FORMMODE = "ADD" Then
            '    Dim Str_Qry As String = obj_Party_Selection.EntryData_General_Offer_txtBookName_Validated(_BookCode)
            '    Dim TblTmp As New DataTable
            '    sqL = Str_Qry
            '    sql_connect_slect()
            '    TblTmp = DefaltSoftTable.Copy
            '    Dim Last_Entry_No As Integer = 0
            '    If TblTmp.Rows.Count > 0 Then
            '        Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
            '    End If
            '    If Last_Entry_No = txtEntryNo.Text Then
            '        txtEntryNo.Text = Last_Entry_No + 1
            '    End If
            'End If
            If _FORMMODE = "ADD" Then
                _TransctionNo = 0
                _BookVNo = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                sqL = "SELECT TOP 1 ENTRYNO FROM TRNOFFER WHERE BOOKVNO='" + Me._BookVNo + "' AND BOOKCODE='" & txtBookCode.Text & "' and GODOWNCODE='" & _GodownCode & "' ORDER BY ENTRYNO DESC"
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    _TransctionNo = (DefaltSoftTable.Rows(0).Item(0))
                End If
                If _TransctionNo > 0 Then
                    If DefaltSoftTable.Rows.Count > 0 Then

                        sqL = "SELECT TOP 1 ENTRYNO FROM TRNOFFER WHERE  BOOKCODE='" & txtBookCode.Text & "' and GODOWNCODE='" & _GodownCode & "' ORDER BY ENTRYNO DESC"
                        sql_connect_slect()
                        If DefaltSoftTable.Rows.Count > 0 Then
                            _TransctionNo = (DefaltSoftTable.Rows(0).Item(0) + 1)
                        End If
                    End If
                    txtEntryNo.Text = (_TransctionNo)
                    'txtChallanNo.Text = (_TransctionNo)
                End If
                _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)

            End If


            'Generate_Date_For_DataBase(txtChallanDate)



            _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)

            If txt_Clear_Date.Text = "  /  /    " Or txt_Clear_Date.Text = "" Then
                txt_Clear_Date.Text = txtOfferDate.Text
            End If

            Generate_Date_For_DataBase(txtOfferDate)
            Generate_Date_For_DataBase(txt_Clear_Date)


            Call Fill_Grid_Records_Into_DataTables()
            Dim _LastID As Integer = -1



            Call Fill_gridSund_Records_Into_DataTables()




            _LastID = SAVE_INTO_DATABASE_SQL()

            Old_Date = txtOfferDate.Text
            Call Label_Value_Nil_Rest()
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, grdBsun)

            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            'Call Command_Button_Visibility("LOAD")
            'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            UC_Buttons1._ButtonEnableDisable("LOAD")
            UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function gridSundryDetailsSaveQuery(ByRef arr_object(,) As String) As String
        '------------------------ DETAILS Table --------------------------------
        Dim strFilterString As String
        Dim QueryDetailTable As String = ""

        Dim Query_Auto_gridSun(_DataTablegridbsun.Rows.Count, 4) As String
        strFilterString = "SUNCODE<>''"

        'Dim _BookVNo As String = _BookvnoGenrate()

        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BOOKCODE,")
            .Append("BILLNO,")
            .Append("BILLDATE")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtEntryNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(_BookCode & ",")
            .Append(txtOfferNo.Text & ",")
            .Append(txtOfferDate.Date_for_Database & ",")
        End With

        QueryDetailTable = ObjCls_General.GetQueryArray(_DatabaseTableNamebsun, "FORCELY_ADDED", strFilterString, Query_Auto_gridSun, _DataTablegridbsun, _FieldbsunNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldbsunDefaultValues.ToString.ToUpper)
        gridSundryDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_gridSun
    End Function

    Private Sub Fill_gridSund_Records_Into_DataTables()
        Dim FieldDr As DataRow
        _DataTablegridbsun.Rows.Clear()
        For i As Int16 = 1 To grdBsun.Rows - 1
            If grdBsun.Cell(i, _DataTablegridbsun.Columns.IndexOf("SUNCODE") + 1).Text <> "" Then
                FieldDr = _DataTablegridbsun.NewRow
                For j As Int16 = 1 To grdBsun.Cols - 1
                    If FieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FieldDr(j - 1) = Val(grdBsun.Cell(i, j).Text)
                    Else
                        FieldDr(j - 1) = (grdBsun.Cell(i, j).Text)
                    End If
                Next
                _DataTablegridbsun.Rows.Add(FieldDr)
            End If
        Next
    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        _DataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdItem.Rows - 1
            If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text <> "" And Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) > 0 Then

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


        Lvl_Grossamt.Text = Lvl_Grossamt.Text.Replace(",", "")
        Lbl_NetAmt.Text = Lbl_NetAmt.Text.Replace(",", "")
        If OfferApprove = "" Then OfferApprove = "NO"

        Dim strFilterString As String
        Dim QueryDetailTable As String = ""

        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String

        strFilterString = "MTR_WEIGHT>0 "

        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("ACOFCODE,")
            .Append("DESPATCHCODE,")
            .Append("CLEAR,")
            .Append("CLEAR_DATE,")
            .Append("CLEAR_REMARK,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("OfferNo,")
            .Append("OfferDate,")
            .Append("PartyOfferNo,")
            .Append("AgentOfferNo,")
            .Append("AccountCode,")
            .Append("TransportCode,")
            .Append("HeaderRemark,")
            .Append("Term1,")
            .Append("Term2,")
            .Append("Term3,")
            .Append("despatchtocode,")
            .Append("WESTAGE,")
            .Append("LENGTH,")
            .Append("OP23,")
            .Append("MONOGRAM_TYPE,")
            .Append("GODOWNCODE,")
            .Append("Term4")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtAcOfCode.Text & ",")
            .Append(txtDespatch_code.Text & ",")
            .Append(txt_Clear.Text & ",")
            .Append(txt_Clear_Date.Date_for_Database & ",")
            .Append(txt_Clear_Remark.Text & ",")
            .Append(txtEntryNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(_BookCode & ",")
            .Append(txtOfferNo.Text & ",")
            .Append(txtOfferDate.Date_for_Database & ",")
            .Append(txtPartyOfferNo.Text & ",")
            .Append(txtAgentOfferNo.Text & ",")
            .Append(txtAccount_Code.Text & ",")
            .Append(txtTr_code.Text & ",")
            .Append(txtHeader_Remark.Text & ",")
            .Append(txtTerm1.Text & ",")
            .Append(txtTerm2.Text & ",")
            .Append(txtTerm3.Text & ",")
            .Append(txtDespatch_code.Text & ",")
            .Append(Lvl_Grossamt.Text & ",")
            .Append(Lbl_NetAmt.Text & ",")
            .Append(OfferApprove & ",")
            .Append(Txt_PartOfferDate.Text & ",")
            .Append(_GodownCode & ",")
            .Append(txtTerm4.Text)
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
            sqL = "DELETE FROM TRNOFFER WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "' and GODOWNCODE='" & _GodownCode & "'"
            sql_Data_Save_Delete_Update()


            sqL = "DELETE FROM TRNINVOICESUNDRY WHERE BOOKVNO ='" & _BookVNo & "'"
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


            Dim Array_Sundary(0, 4) As String
            '------ INSERT RECORDS SUNDRY DETAIL -------------------------------
            gridSundryDetailsSaveQuery(Array_Sundary)
            For I = 0 To UBound(Array_Sundary)
                If Array_Sundary(I, 4) <> "" Then
                    sqL = Array_Sundary(I, 4)
                    sql_Data_Save_Delete_Update()
                End If
            Next
            '------


        Catch ex As Exception

            MsgBox("new error comes :" & ex.Message & "-" & strQuery)
            Throw ex
        Finally
        End Try
    End Function

#End Region

#Region " RD/CD Txt Box Code "
    'Private Sub txtRDOn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRDOn.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CDVALUE") + 1).Text = txtCDRate.Text
    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CDON") + 1).Text = txtCDOn.Text
    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RDVALUE") + 1).Text = txtRDRate.Text
    '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RDON") + 1).Text = txtRDOn.Text
    '    End If
    'End Sub
    'Private Sub pnlRDCDInfo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlRDCDInfo.Validated
    '    pnlRDCDInfo.Visible = False
    '    GrdItem.Focus()
    '    GrdItem.Select()
    'End Sub
#End Region

#Region "VIEW RECORD "
    Private Sub View_Record()

        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)


        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""

        View_Filter_Condition = " AND TRNOFFER.BOOKCODE='" & _BookCode & "' AND TRNOFFER.OFFERDATE>='" & txt_From.Date_for_Database & "' AND TRNOFFER.OFFERDATE<='" & txt_To.Date_for_Database & "' "
        View_Order_By = " ORDER BY TRNOFFER.OFFERDATE,TRNOFFER.ENTRYNO,TRNOFFER.SRNO "


        _strQuery = New StringBuilder
        With _strQuery

            If Txt_EntryType.Text = "SUMMERY" Then

                .Append(" SELECT ")
                .Append(" TrnOffer.BookVno, ")
                .Append(" TrnOffer.ENTRYNO as [Entry No], ")
                .Append(" TrnOffer.OfferNo as [Offer No], ")
                .Append(" TrnOffer.OfferDate AS OfferDate, ")
                .Append(" MstMasterAccount.accountname as [Party Name], ")
                .Append(" MSTSTOREITEMGROUP.GROUPNAME AS [Group Name], ")
                .Append(" MSTSTOREITEM.ITEMNAME as [Item Name], ")
                .Append(" MstCutMaster.cutname as [Per], ")
                .Append(" sum(TrnOffer.Mtr_Weight) as [Quantity], ")
                .Append(" TrnOffer.Gross_Rate as [Rate],  ")
                .Append(" TrnOffer.RDVALUE AS Dis, ")
                .Append(" TrnOffer.DENT as [Amount],  ")
                .Append(" TrnOffer.Reed as [GST%],  ")
                .Append(" TrnOffer. RDON As Fright,  ")
                .Append(" TrnOffer.CDVALUE as Delivery,  ")
                .Append(" MstCity.cityname AS DESPATCH, ")
                .Append(" MstTransport.TransportName as [Transport], ")
                .Append(" a.accountname as [Agent Name], ")
                .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
                .Append(" TrnOffer.PartyOfferNo as [Party Offer No], ")
                .Append(" TrnOffer.AgentOfferNo as [Agent Of-No], ")
                .Append(" TrnOffer.HeaderRemark as [Remark], ")
                .Append(" sum(TrnOffer.cancel_Qty) as [Cancel Qty] ")
                .Append(" FROM TRNOFFER")
                .Append(" LEFT JOIN MSTSTOREITEM ON  TRNOFFER.ITEMCODE=MSTSTOREITEM.ITEMCODE ")
                .Append(" LEFT JOIN MSTSTOREITEMGROUP ON TRNOFFER.ITEMGROUPCODE=MSTSTOREITEMGROUP.GROUPCODE ")
                .Append(" LEFT JOIN MstMasterAccount ON TRNOFFER.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MSTTRANSPORT ON TRNOFFER.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" LEFT JOIN MstMasterAccount AS A ON MstMasterAccount.AGENTCODE=A.ACCOUNTCODE  ")
                .Append(" LEFT JOIN Mst_Acof_Supply ON TRNOFFER.ACOFCODE=Mst_Acof_Supply.ID ")
                .Append(" LEFT JOIN MstCutMaster  ON TRNOFFER.CUTCODE=MstCutMaster.ID  ")
                .Append(" LEFT JOIN MSTCITY ON TRNOFFER.DESPATCHCODE=MSTCITY.CITYCODE")
                '.Append(" LEFT JOIN MSTSTOREITEM  AS G ON TRNOFFER.weavetypecode=G.ITEMCODE")
                .Append(" WHERE 1=1 ")
                .Append(" AND  TRNOFFER.GODOWNCODE='" & _GodownCode & "' ")
                .Append(View_Filter_Condition)

                .Append(" GROUP BY ")

                .Append(" TrnOffer.BookVno, ")
                .Append(" TrnOffer.ENTRYNO , ")
                .Append(" TrnOffer.OfferNo , ")
                .Append(" TrnOffer.OfferDate , ")
                .Append(" MstMasterAccount.accountname , ")
                .Append(" MSTSTOREITEMGROUP.GROUPNAME , ")
                .Append(" MSTSTOREITEM.ITEMNAME , ")
                .Append(" MstCutMaster.cutname , ")
                .Append(" MstCity.cityname, ")
                .Append(" MstTransport.TransportName , ")
                .Append(" a.accountname , ")
                .Append(" TrnOffer.Gross_Rate ,  ")
                .Append(" TrnOffer.RDVALUE, ")
                .Append(" TrnOffer.DENT,  ")
                .Append(" TrnOffer.Reed,  ")
                .Append(" TrnOffer. RDON,  ")
                .Append(" TrnOffer.CDVALUE,  ")
                .Append(" Mst_Acof_Supply.AC_NAME , ")
                .Append(" TrnOffer.PartyOfferNo , ")
                .Append(" TrnOffer.AgentOfferNo, ")
                .Append(" TrnOffer.HeaderRemark  ")
                .Append(" ORDER BY TRNOFFER.OFFERDATE,TRNOFFER.ENTRYNO")


            Else
                .Append(" SELECT ")
                .Append(" TrnOffer.BookVno, ")
                .Append(" TrnOffer.ENTRYNO as [Entry No], ")
                .Append(" TrnOffer.OfferNo as [Offer No], ")
                .Append(" TrnOffer.OfferDate AS OfferDate, ")
                .Append(" MstMasterAccount.accountname as [Party Name], ")
                .Append(" TrnOffer.SRNO as [Sno], ")
                .Append(" MSTSTOREITEMGROUP.GROUPNAME AS [Group Name], ")
                .Append(" MSTSTOREITEM.ITEMNAME as [Item Name], ")
                '.Append(" G.ITEMNAME AS PartyItemName, ")
                .Append(" TrnOffer.loomtypecode AS Size, ")
                .Append(" MstCutMaster.cutname as [Per], ")
                .Append(" TrnOffer.Mtr_Weight as [Quantity], ")
                .Append(" TrnOffer.Gross_Rate as [Rate],  ")
                .Append(" TrnOffer.RDVALUE AS Dis, ")
                .Append(" TrnOffer.DENT as [Amount],  ")
                .Append(" TrnOffer.Reed as [GST%],  ")
                .Append(" TrnOffer. RDON As Fright,  ")
                .Append(" TrnOffer.CDVALUE as Delivery,  ")
                .Append(" MstCity.cityname AS DESPATCH, ")
                .Append(" MstTransport.TransportName as [Transport], ")
                .Append(" a.accountname as [Agent Name], ")
                .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
                .Append(" TrnOffer.PartyOfferNo as [Party Offer No], ")
                .Append(" TrnOffer.AgentOfferNo as [Agent Of-No], ")
                .Append(" TrnOffer.HeaderRemark as [Remark], ")
                .Append(" TrnOffer.cancel_Qty as [Cancel Qty], ")
                .Append(" TrnOffer.clear as [Clear] ")

                .Append(" FROM TRNOFFER")
                .Append(" LEFT JOIN MSTSTOREITEM ON  TRNOFFER.ITEMCODE=MSTSTOREITEM.ITEMCODE ")
                .Append(" LEFT JOIN MSTSTOREITEMGROUP ON TRNOFFER.ITEMGROUPCODE=MSTSTOREITEMGROUP.GROUPCODE ")
                .Append(" LEFT JOIN MstMasterAccount ON TRNOFFER.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MSTTRANSPORT ON TRNOFFER.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" LEFT JOIN MstMasterAccount AS A ON MstMasterAccount.AGENTCODE=A.ACCOUNTCODE  ")
                .Append(" LEFT JOIN Mst_Acof_Supply ON TRNOFFER.ACOFCODE=Mst_Acof_Supply.ID ")
                .Append(" LEFT JOIN MstCutMaster  ON TRNOFFER.CUTCODE=MstCutMaster.ID  ")
                .Append(" LEFT JOIN MSTCITY ON TRNOFFER.DESPATCHCODE=MSTCITY.CITYCODE")
                '.Append(" LEFT JOIN MSTSTOREITEM  AS G ON TRNOFFER.weavetypecode=G.ITEMCODE")
                .Append(" WHERE 1=1 ")
                .Append(" AND  TRNOFFER.GODOWNCODE='" & _GodownCode & "' ")
                .Append(View_Filter_Condition)
                .Append(" ORDER BY TRNOFFER.OFFERDATE,TRNOFFER.ENTRYNO,TRNOFFER.SRNO")

            End If
        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp = DefaltSoftTable.Copy

        FirstStage.Columns.Clear()
        If tblTmp.Rows.Count > 0 Then

            For Each dr As DataRow In tblTmp.Select
                Dim Qty As String = Format(dr("Quantity"), "0.00")
                dr("Quantity") = Qty
                Qty = Format(dr("Cancel Qty"), "0.00")
                dr("Cancel Qty") = Qty
            Next

            GridControl1.DataSource = tblTmp.Copy

            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)


            FirstStage.GroupRowHeight = 30
            FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near


            FirstStage.Columns("Quantity").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Cancel Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            FirstStage.Columns("Quantity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0}"))
            FirstStage.Columns("Cancel Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancel Qty", "{0}"))

            AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
            FirstStage.Columns(0).Visible = False



            PNL_View.BringToFront()
            PNL_View.Visible = True
            'FirstStage.BestFitColumns()
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
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Cancel Qty", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Cancel Qty")})

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


#Region "Rate Display System "
    Public Sub Fill_Rate_Grid(ByRef grd As Object, ByVal tempDT As DataTable)
        Dim i, j As Integer
        Try
            grd.Rows = tempDT.Rows.Count + 1
            grd.Cols = tempDT.Columns.Count + 1
            grd.Column(0).Visible = False

            For j = 1 To tempDT.Columns.Count
                grd.Cell(0, j).Text = tempDT.Columns(j - 1).ColumnName
            Next
            For i = 1 To tempDT.Rows.Count
                For j = 1 To tempDT.Columns.Count
                    If tempDT.Rows(i - 1).Item(j - 1).ToString <> "" Then
                        grd.Cell(i, j).Text = UCase(tempDT.Rows(i - 1).Item(j - 1))
                    End If
                Next
            Next

            grd.SelectionMode = FlexCell.SelectionModeEnum.ByRow
            grd.ExtendLastCol = True
            grd.Focus()

            grd.Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            tempDT = Nothing
        End Try
    End Sub

    Private Sub Rate_Display()
        Dim Item_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text

        '---------Master Rate Start
        strQuery = "SELECT * FROM MstStoreItem WHERE ITEMCODE='" & Item_Code & "'"
                sqL = strQuery
        sql_connect_slect()
        _TmpDataTable = DefaltSoftTable.Copy
        _TmpDataRow = _TmpDataTable.Rows(0)
        Dim Item_Master_Rate As Double = Val(_TmpDataRow("SALE_RATE").ToString)
        LBL_Master_Rate.Text = "Master Rate :" + FormatNumber(Item_Master_Rate, 2, TriState.True, TriState.False, TriState.False)
        '---------Master Rate Finish

        Dim Str_Qry As String
        sqL = "SELECT A.CHALLANNO AS [Chl-No],format(a.challandate,'dd/MM/yy') as [Date],format(a.qty,'0.000') as [Quantity],format(a.NET_RATE,'0.00') as [Net Rate],B.ACCOUNTNAME AS [Party Name]," & Item_Master_Rate & " as Master_rate from trnchallan as a,MstMasterAccount as b where a.accountcode=b.accountcode and a.accountcode='" & txtAccount_Code.Text & "' and a.itemcode='" & Item_Code & "' order by b.accountname,(a.challanno) desc "
        sql_connect_slect()
        _TmpDataTable = DefaltSoftTable.Copy
        If _TmpDataTable.Rows.Count = 0 Then
            sqL = "SELECT A.CHALLANNO AS [Chl-No],format(a.challandate,'dd/MM/yy') as [Date],format(a.qty,'0.000') as [Quantity],format(a.NET_RATE,'0.00') as [Net Rate],B.ACCOUNTNAME AS [Party Name]," & Item_Master_Rate & " as Master_rate from trnchallan as a,MstMasterAccount as b where a.accountcode=b.accountcode and a.itemcode='" & Item_Code & "' order by b.accountname,a.entryno desc "
            sql_connect_slect()
            _TmpDataTable = DefaltSoftTable.Copy
        End If


        Fill_Rate_Grid(Grid_Rate_Disp, _TmpDataTable)

        If _TmpDataTable.Rows.Count = 0 Then
            Grid_Rate_Disp.Rows = Grid_Rate_Disp.Rows + 1
        End If

        Grid_Rate_Disp.Column(1).Visible = True

        Grid_Rate_Disp.Column(1).Width = 50
        Grid_Rate_Disp.Column(2).Width = 70
        Grid_Rate_Disp.Column(3).Width = 70
        Grid_Rate_Disp.Column(4).Width = 70
        Grid_Rate_Disp.Column(5).Width = 100

        Grid_Rate_Disp.Column(1).Alignment = FlexCell.AlignmentEnum.LeftCenter
        Grid_Rate_Disp.Column(2).Alignment = FlexCell.AlignmentEnum.LeftCenter
        Grid_Rate_Disp.Column(3).Alignment = FlexCell.AlignmentEnum.RightCenter
        Grid_Rate_Disp.Column(4).Alignment = FlexCell.AlignmentEnum.RightCenter
        Grid_Rate_Disp.Column(5).Alignment = FlexCell.AlignmentEnum.LeftCenter

        Grid_Rate_Disp.Locked = True
        Pnl_Rate_Disp.Visible = True
        Pnl_Rate_Disp.BringToFront()
        Grid_Rate_Disp.Select()
        Grid_Rate_Disp.Focus()

        If Grid_Rate_Disp.Rows < 2 Then
            Grid_Rate_Disp.Rows = 2
            Grid_Rate_Disp.Cell(1, 6).Text = Item_Master_Rate
        End If

        Grid_Rate_Disp.Range(1, 1, 1, 1).SelectCells()
    End Sub

#End Region

#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        View_Record()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = " Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub txtGodownName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGodownName.KeyPress
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
            'SendKeys.Send("{TAB}")

            If _FORMMODE <> "VIEW" Then
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                SendKeys.Send("{TAB}")
            Else
                'SendKeys.Send("{ENTER}")
                SendKeys.Send("{TAB}")
            End If

            Call defineGridColName()
            Call GenerateTable(_DataTableGrid, GrdItem)
            Call gridFormatting(_DataTableGrid, GrdItem)

            GrdItem.Rows = 2
            GrdItem.Column(0).Visible = False
            'GrdItem.Row(0).Height = 31
            GrdItem.DefaultRowHeight = 28



            InitializeGridbsunConfiguration()
            Dim grid As Grid = Me.grdBsun
            Me.GenerateTablebsun(Me._DataTablegridbsun, grid)
            gridFormattingSundary(_DataTablegridbsun, grid)
            Me.grdBsun = grid
            Me.grdBsun.Enabled = False
            Me.grdBsun.Column(0).Visible = False
            Me.grdBsun.Row(0).Height = 20S
            grdBsun.Rows = 2

            'Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        End If
        e.Handled = True
    End Sub

    Private Sub txtGodownName_Validated(sender As Object, e As EventArgs) Handles txtGodownName.Validated
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, grdBsun)
        '_Validated()
    End Sub

#End Region
End Class