Imports System.Text
Imports DevExpress.CodeParser

Public Class MainFrmDesigner

    Dim _DataBaseFileName As String = "Accounts24_342025104153"
    'Dim _DataBaseFileName As String = "CompanyDatabase"
    'Private _DatabaseTableNameItem = "FormCntrl"
    Private _DatabaseTableNameItem = "FormControl"

    Dim _FocusgridName As String = ""
    Dim _BookCode As String = ""
    Dim _LastBookCode As String = ""

    Private _FORMMODE As String = ""
    Private _FrmLoad As Boolean = True
    Private Change_Grid_Data As Boolean = True

    Dim ColumnTypeCounter As New Dictionary(Of String, Integer)
    Dim LocationY As Integer = 10


#Region "HEADER GRID COL. DEFINE AND FORMATTING "
#Region "GRID GENERAL VARIABLE "
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable

    Private _headerColNames As New StringBuilder

    Private Grid_Table_ColNames() As String
    Private Detail_Grid_Table_ColNames() As String
    Private _FindColIndex As Integer = 0
    Private _ColTotal As Double = 0
    Private _AutoIDField As String = "SRNO"
    Private _RecordsKeyFieldName As String = "ID"
    Private _FocusFields() As String
    Private _DataTableGrid As New DataTable
    Private Detail_DataTableGrid As New DataTable
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
    Private WithEvents Txt_Dt As New ctl_TextBox.ctl_TextBox
    Private Old_Date As String = ""
    Private Use_Design_Shade_In_Entry As Boolean = False
    Private SkipWeightToBeamNo As String = "NO"
    Private PickChange As String = "NO"
    Private PartyChange As String = "NO"
    Private ItemChange As String = "NO"
    Private SelvChange As String = "NO"
    Private ShadeChange As String = "NO"
    Private DesignChange As String = "NO"
    Private ShiftWiseProdEntry As String = "NO"
    Private FoldLockPer As Double = 0
#End Region
#Region "GRID STRING BUILDER VARIABLE "
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
    Private _FieldNameColmType As New StringBuilder
#End Region
    Private Sub Define_Grid_Item_ColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID")
            .Append(",CntrlType")
            .Append(",ColumnType")
            .Append(",CntrlName")
            .Append(",DataBaseTable")
            .Append(",UseMaster")
            .Append(",Masterlist")
            .Append(",OppMasterCode")
            .Append(",DataBaseColumn")
            .Append(",Text")
            .Append(",LocationX")
            .Append(",LocationY")
            .Append(",SizeHeight")
            .Append(",SizeWidth")
            .Append(",OrderNo")
            .Append(",Tabindex")
            .Append(",InputType")
            .Append(",SpacerString")
            .Append(",FormID")
            .Append(",FormName")
            .Append(",Cntrlid")
            .Append(",Fonts")
            .Append(",BackColor")
            .Append(",ForeColor")
            .Append(",CntrlssendtoType") ' front/Back
            .Append(",MainMenuName")
            .Append(",ParentMenu1")
            .Append(",Nature")
            .Append(",Beahviour")
            .Append(",BookCategory")
            .Append(",Active")
            .Append(",ShortCutKey")
            .Append(",FocusColor")
            .Append(",LostFocusColor")
            .Append(",Visible")
            .Append(",ReadOnly")
            .Append(",TextAlign")
            .Append(",Erequred")
            .Append(",Enabled")
            .Append(",MainFormSizeX")
            .Append(",MainFormLocationX")
            .Append(",MainFormSizeY")
            .Append(",MainFormLocationY")
            .Append(",BooKcode")
            .Append(",Precision") 'decimal
            .Append(",SaveYN")
            .Append(",FormDesignType")
            .Append(",Masking")
            .Append(",Managebook")

        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("OrderNo:N")
            .Append(",Tabindex:N")

        End With

        _GridColValidate = New StringBuilder
        With _GridColValidate
        End With

        _GridCol_FocusByPass = New StringBuilder
        With _GridCol_FocusByPass
        End With

        _FieldHeader = New StringBuilder
        With _FieldHeader
            .Append("CntrlName:GridName")
            .Append(",ColumnType:Column Type")
            .Append(",DataBaseTable:DataBase Table")
            .Append(",UseMaster:Use Master")
            .Append(",Masterlist:Master List")
            .Append(",OppMasterCode:OppMasterCode")
            .Append(",DataBaseColumn:DataBase Column")
            .Append(",Text:Header Name")
            .Append(",LocationX:LocationX")
            .Append(",LocationY:LocationY")
            .Append(",SizeHeight:Hight")
            .Append(",SizeWidth:Width")
            .Append(",Visible:Visible")
            .Append(",ReadOnly:ReadOnly")
            .Append(",TextAlign:Text Align")
            .Append(",OrderNo:Order No")
            .Append(",Tabindex:Tab Index")
            .Append(",InputType:Input Type")
            .Append(",SpacerString:Spacer String")
            .Append(",SaveYN:Save Y/N")
            .Append(",Masking:Decimal Value")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("ColumnType:L")
            .Append(",DataBaseTable:L")
            .Append(",CntrlName:L")
            .Append(",LocationX:L")
            .Append(",LocationY:L")
            .Append(",SizeHeight:L")
            .Append(",SizeWidth:L")
            .Append(",Visible:L")
            .Append(",ReadOnly:L")
            .Append(",TextAlign:L")
            .Append(",Text:L")
            .Append(",OrderNo:L")
            .Append(",Tabindex:L")
            .Append(",InputType:L")
            .Append(",UseMaster:L")
            .Append(",Masterlist:L")
            .Append(",OppMasterCode:L")
            .Append(",SpacerString:L")
            .Append(",SaveYN:L")
            .Append(",Masking:L")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("ColumnType:L")
            .Append(",DataBaseTable:L")
            .Append(",CntrlName:L")
            .Append(",LocationX:L")
            .Append(",LocationY:L")
            .Append(",SizeHeight:L")
            .Append(",SizeWidth:L")
            .Append(",Visible:L")
            .Append(",ReadOnly:L")
            .Append(",TextAlign:L")
            .Append(",Text:L")
            .Append(",OrderNo:L")
            .Append(",Tabindex:L")
            .Append(",InputType:L")
            .Append(",UseMaster:L")
            .Append(",Masterlist:L")
            .Append(",OppMasterCode:L")
            .Append(",SpacerString:L")
            .Append(",SaveYN:L")
            .Append(",Masking:L")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N")
            .Append(",FormID:N")
            .Append(",FormName:N")
            .Append(",Cntrlid:N")
            .Append(",LocationX:Y")
            .Append(",LocationY:Y")
            .Append(",SizeHeight:Y")
            .Append(",SizeWidth:Y")
            .Append(",CntrlName:Y")
            .Append(",Text:Y")
            .Append(",MainFormSizeX:N")
            .Append(",MainFormLocationX:N")
            .Append(",MainFormSizeY:N")
            .Append(",MainFormLocationY:N")
            .Append(",Bookcode:N")
            .Append(",Fonts:N")
            .Append(",BackColor:N")
            .Append(",ForeColor:N")
            .Append(",CntrlssendtoType:N") ' front/Back
            .Append(",ColumnType:Y")
            .Append(",DataBaseTable:Y")
            .Append(",DataBaseColumn:Y")
            .Append(",MainMenuName:N")
            .Append(",ParentMenu1:N")
            .Append(",Nature:N")
            .Append(",Beahviour:N")
            .Append(",BookCategory:N")
            .Append(",Active:N")
            .Append(",ShortCutKey:N")
            .Append(",OrderNo:Y")
            .Append(",FocusColor:N")
            .Append(",LostFocusColor:N")
            .Append(",Visible:Y")
            .Append(",ReadOnly:Y")
            .Append(",TextAlign:Y")
            .Append(",Tabindex:Y")
            .Append(",CntrlType:N")
            .Append(",InputType:Y")
            .Append(",SpacerString:Y")
            .Append(",Erequred:N")
            .Append(",Enabled:N")
            .Append(",FormDesignType:N")
            .Append(",UseMaster:Y")
            .Append(",Masterlist:Y")
            .Append(",OppMasterCode:Y")
            .Append(",SaveYN:Y")
            .Append(",Precision:N") 'decimal
            .Append(",Managebook:N")
        End With



        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("ColumnType:8")
            .Append(",DataBaseTable:11")
            .Append(",UseMaster:11")
            .Append(",Masterlist:13")
            .Append(",OppMasterCode:11")
            .Append(",DataBaseColumn:11")
            .Append(",CntrlName:11")
            .Append(",LocationX:8")
            .Append(",LocationY:8")
            .Append(",SizeHeight:8")
            .Append(",SizeWidth:8")
            .Append(",Visible:8")
            .Append(",ReadOnly:8")
            .Append(",TextAlign:8")
            .Append(",Text:10")
            .Append(",OrderNo:8")
            .Append(",Tabindex:8")
            .Append(",InputType:8")
            .Append(",SpacerString:10")
            .Append(",SaveYN:8")
            .Append(",Masking:10")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("OrderNo:0")
            .Append(",Tabindex:0")
            .Append(",LOCATIONX:0")
            .Append(",LOCATIONY:0")
            .Append(",SIZEHEIGHT:0")
            .Append(",SIZEWIDTH:0")
            .Append(",FORMDESIGNTYPE:Header Design")
            .Append(",Masking:0")
            .Append(",ReadOnly:Y")
            .Append(",TextAlign:Y")
            .Append(",SaveYN:Y")
            .Append(",Visible:N")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("ColumnType:Y")
            .Append(",CntrlName:Y")
            .Append(",DataBaseTable:Y")
            .Append(",INPUTTYPE:Y")
            .Append(",Usemaster:Y")
            .Append(",Visible:Y")
            .Append(",ReadOnly:Y")
            .Append(",TextAlign:Y")
            .Append(",SaveYN:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            '.Append("GMTR:NO-2,")
            .Append("OrderNo:NO-0")
            .Append(",SizeWidth:NO-0")
            .Append(",LocationX:NO-0")
            .Append(",LocationY:NO-0")
            .Append(",SizeHeight:NO-0")
            .Append(",Tabindex:NO-0")
        End With

        With _FieldNameSameValueCopy
        End With

        _FieldNameColmType = New StringBuilder
        With _FieldNameColmType
            .Append("DataBaseColumn:CMB")
            .Append(",OppMasterCode:CMB")
            .Append(",Masterlist:CMB")
        End With
        Grid_Table_ColNames = _GridColNames.ToString.ToUpper.Split(",")
    End Sub
    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _GridColNames.ToString.ToUpper, "NO", _GridColType.ToString)
        'grdObj.ExtendLastCol = True
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
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "COLTYPE", _FieldNameColmType.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub

#End Region


#Region "DETAIL GRID COL. DEFINE AND FORMATTING "

#Region "GRID STRING BUILDER VARIABLE "
    Private DetailOffer_Calc_By As String
    Private Detail_GridColNames As New StringBuilder
    Private Detail_GridColType As New StringBuilder
    Private Detail_GridColValidate As New StringBuilder
    Private Detail_GridCol_FocusByPass As New StringBuilder
    Private Detail_FieldDefaultValues As New StringBuilder
    Private Detail_FieldHeader As New StringBuilder
    Private Detail_FieldHeaderAlignment As New StringBuilder
    Private Detail_FieldNotRequiredForSave As New StringBuilder
    Private Detail_FieldNotVisibile As New StringBuilder
    Private Detail_FieldWidthSet As New StringBuilder
    Private Detail_FieldLocked As New StringBuilder
    Private Detail_FieldMasking As New StringBuilder
    Private Detail_FieldAlignMent As New StringBuilder
    Private Detail_ExtraFieldDataTable As New StringBuilder
    Private Detail_ExtraField_Values_DataTable As New StringBuilder
    Private Detail_ExtraFieldOthers As New StringBuilder
    Private Detail_ExtraField_Values_Others As New StringBuilder
    Private Detail_FieldNameSameValueCopy As New StringBuilder
    Private Detail_FieldNameForTotal As New StringBuilder
    Private Detail_FieldNameColmType As New StringBuilder
#End Region
    Private Sub Detail_Define_Grid_Item_ColName()
        Detail_GridColNames = New StringBuilder
        With Detail_GridColNames
            .Append("ID")
            .Append(",CntrlName")
            .Append(",CntrlType")
            .Append(",DataBaseTable")
            .Append(",UseMaster")
            .Append(",Masterlist")
            .Append(",OppMasterCode")
            .Append(",DataBaseColumn")
            .Append(",Text") 'header name
            .Append(",OrderNo")
            .Append(",SizeWidth")
            .Append(",Visible")
            .Append(",ReadOnly")
            .Append(",Precision") 'decimal
            .Append(",TextAlign")
            .Append(",InputType")
            .Append(",SizeHeight")
            .Append(",ColumnType")
            .Append(",LocationX")
            .Append(",LocationY")
            .Append(",Tabindex")
            .Append(",SpacerString")
            .Append(",FormID")
            .Append(",FormName")
            .Append(",Cntrlid")
            .Append(",Fonts")
            .Append(",BackColor")
            .Append(",ForeColor")
            .Append(",CntrlssendtoType") ' front/Back
            .Append(",MainMenuName")
            .Append(",ParentMenu1")
            .Append(",Nature")
            .Append(",Beahviour")
            .Append(",BookCategory")
            .Append(",Active")
            .Append(",ShortCutKey")
            .Append(",FocusColor")
            .Append(",LostFocusColor")
            .Append(",Erequred")
            .Append(",Enabled")
            .Append(",MainFormSizeX")
            .Append(",MainFormLocationX")
            .Append(",MainFormSizeY")
            .Append(",MainFormLocationY")
            .Append(",BookCode")
            .Append(",SaveYN")
            .Append(",FormDesignType")
            .Append(",Masking")
            .Append(",Managebook")
        End With

        Detail_GridColType = New StringBuilder
        With Detail_GridColType
            .Append("OrderNo:N")
            .Append(",Tabindex:N")
        End With

        Detail_GridColValidate = New StringBuilder
        With Detail_GridColValidate
        End With

        Detail_GridCol_FocusByPass = New StringBuilder
        With Detail_GridCol_FocusByPass
        End With

        Detail_FieldHeader = New StringBuilder
        With Detail_FieldHeader
            .Append("CntrlName:GridName")
            .Append(",ColumnType:Column Type")
            .Append(",DataBaseTable:DataBase Table")
            .Append(",DataBaseColumn:DataBase Column")
            .Append(",LocationX:LocationX")
            .Append(",LocationY:LocationY")
            .Append(",SizeHeight:Hight")
            .Append(",SaveYN:Save Y/N")
            .Append(",UseMaster:Use Master")
            .Append(",Masterlist:Master List")
            .Append(",OppMasterCode:OppMasterCode")
            .Append(",SizeWidth:Width")
            .Append(",Text:Header Name")
            .Append(",OrderNo:Order No")
            .Append(",TextAlign:Text Align")
            .Append(",Precision:Decimal")
            .Append(",Visible:Visible")
            .Append(",ReadOnly:ReadOnly")
            .Append(",Tabindex:Tab Index")
            .Append(",InputType:Input Type")
            .Append(",SpacerString:Spacer String")
            .Append(",Masking:Decimal Value")
        End With

        Detail_FieldHeaderAlignment = New StringBuilder
        With Detail_FieldHeaderAlignment
            .Append("ColumnType:L")
            .Append(",DataBaseTable:L")
            .Append(",CntrlName:L")
            .Append(",LocationX:L")
            .Append(",LocationY:L")
            .Append(",SizeHeight:L")
            .Append(",SizeWidth:L")
            .Append(",Text:L")
            .Append(",OrderNo:L")
            .Append(",Tabindex:L")
            .Append(",InputType:L")
            .Append(",SpacerString:L")
            .Append(",TextAlign:L")
            .Append(",Precision:L")
            .Append(",Visible:L")
            .Append(",ReadOnly:L")
            .Append(",SaveYN:L")
            .Append(",UseMaster:L")
            .Append(",Masterlist:L")
            .Append(",OppMasterCode:L")
            .Append(",DataBaseColumn:L")
            .Append(",Masking:R")
        End With

        Detail_FieldAlignMent = New StringBuilder
        With Detail_FieldAlignMent
            .Append("ColumnType:L")
            .Append(",DataBaseTable:L")
            .Append(",CntrlName:L")
            .Append(",LocationX:L")
            .Append(",LocationY:L")
            .Append(",SizeHeight:L")
            .Append(",SizeWidth:L")
            .Append(",Text:L")
            .Append(",OrderNo:L")
            .Append(",Tabindex:L")
            .Append(",InputType:L")
            .Append(",SpacerString:L")
            .Append(",TextAlign:L")
            .Append(",Precision:L")
            .Append(",Visible:L")
            .Append(",ReadOnly:L")
            .Append(",SaveYN:L")
            .Append(",UseMaster:L")
            .Append(",Masterlist:L")
            .Append(",OppMasterCode:L")
            .Append(",DataBaseColumn:L")
            .Append(",Masking:R")
        End With

        Detail_FieldNotVisibile = New StringBuilder
        With Detail_FieldNotVisibile
            .Append("ID:N")
            .Append(",FormID:N")
            .Append(",FormName:N")
            .Append(",Cntrlid:N")
            .Append(",LocationX:N")
            .Append(",LocationY:N")
            .Append(",SizeHeight:N")
            .Append(",SizeWidth:Y")
            .Append(",CntrlName:Y")
            .Append(",Text:Y")
            .Append(",MainFormSizeX:N")
            .Append(",MainFormLocationX:N")
            .Append(",MainFormSizeY:N")
            .Append(",MainFormLocationY:N")
            .Append(",Bookcode:N")
            .Append(",Fonts:N")
            .Append(",BackColor:N")
            .Append(",ForeColor:N")
            .Append(",CntrlssendtoType:N") ' front/Back
            .Append(",ColumnType:N")
            .Append(",DataBaseTable:Y")
            .Append(",DataBaseColumn:Y")
            .Append(",MainMenuName:N")
            .Append(",ParentMenu1:N")
            .Append(",Nature:N")
            .Append(",Beahviour:N")
            .Append(",BookCategory:N")
            .Append(",Active:N")
            .Append(",ShortCutKey:N")
            .Append(",OrderNo:Y")
            .Append(",FocusColor:N")
            .Append(",LostFocusColor:N")
            .Append(",Visible:Y")
            .Append(",Tabindex:N")
            .Append(",CntrlType:N")
            .Append(",InputType:Y")
            .Append(",SpacerString:N")
            .Append(",Erequred:N")
            .Append(",Enabled:N")
            .Append(",Precision:N") 'decimal
            .Append(",TextAlign:Y")
            .Append(",ReadOnly:Y")
            .Append(",SaveYN:Y")
            .Append(",UseMaster:Y")
            .Append(",Masterlist:Y")
            .Append(",OppMasterCode:Y")
            .Append(",Masking:Y")
            .Append(",FormDesignType:N")
            .Append(",Managebook:N")
        End With



        Detail_FieldNotRequiredForSave = New StringBuilder
        With Detail_FieldNotRequiredForSave
            .Append("ID:N")
        End With

        Detail_FieldWidthSet = New StringBuilder
        With Detail_FieldWidthSet
            .Append("ColumnType:8")
            .Append(",DataBaseTable:11")
            .Append(",DataBaseColumn:10")
            .Append(",CntrlName:8")
            .Append(",LocationX:8")
            .Append(",LocationY:8")
            .Append(",SizeHeight:8")
            .Append(",SizeWidth:6")
            .Append(",Text:11")
            .Append(",OrderNo:6")
            .Append(",Tabindex:8")
            .Append(",InputType:8")
            .Append(",SpacerString:8")
            .Append(",TextAlign:8")
            .Append(",Precision:8")
            .Append(",Visible:6")
            .Append(",ReadOnly:6")
            .Append(",SaveYN:8")
            .Append(",UseMaster:8")
            .Append(",Masterlist:13")
            .Append(",OppMasterCode:8")
            .Append(",Masking:10")
        End With

        Detail_FieldDefaultValues = New StringBuilder
        With Detail_FieldDefaultValues
            .Append("OrderNo:0")
            .Append(",Tabindex:0")
            .Append(",Masking:0")
        End With

        Detail_FieldLocked = New StringBuilder
        With Detail_FieldLocked
            .Append("ColumnType:Y")
            .Append(",CntrlName:N")
            .Append(",DataBaseTable:Y")
            .Append(",INPUTTYPE:Y")
            .Append(",Visible:Y")
            .Append(",ReadOnly:Y")
            .Append(",SaveYN:Y")
            .Append(",UseMaster:Y")
            .Append(",TextAlign:Y")
        End With

        Detail_FieldMasking = New StringBuilder
        With Detail_FieldMasking
            .Append("Masking:NO-0")
            .Append(",OrderNo:NO-0")
            .Append(",SizeWidth:NO-0")
        End With

        With Detail_FieldNameSameValueCopy
        End With

        Detail_FieldNameColmType = New StringBuilder
        With Detail_FieldNameColmType
            .Append("DataBaseColumn:CMB")
            .Append(",OppMasterCode:CMB")
            .Append(",Masterlist:CMB")
        End With
        Detail_Grid_Table_ColNames = Detail_GridColNames.ToString.ToUpper.Split(",")
    End Sub
    Private Sub Detail_GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, Detail_GridColNames.ToString.ToUpper, "NO", Detail_GridColType.ToString)
        'grdObj.ExtendLastCol = True
        _GridLastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
    End Sub
    Private Sub Detail_GridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", Detail_FieldNotVisibile.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", Detail_FieldWidthSet.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", Detail_FieldHeader.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", Detail_FieldLocked.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", Detail_FieldMasking.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", Detail_FieldAlignMent.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", Detail_FieldHeaderAlignment.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "COLTYPE", Detail_FieldNameColmType.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub

#Region "SELECTION GRID DETAIL "
#Region "SELECTION DETAIL GRID GENERAL VARIABLE "
    Private selectFieldNameAndValues(1) As String
    Private selecttblFormValues As New DataTable

    Private _selectheaderColNames As New StringBuilder

    Private selectGrid_Table_ColNames() As String
    Private selectDetail_Grid_Table_ColNames() As String
    Private _selectFindColIndex As Integer = 0
    Private _selectColTotal As Double = 0
    Private _selectAutoIDField As String = "SRNO"
    Private _selectRecordsKeyFieldName As String = "ID"
    Private _selectFocusFields() As String
    Private _selectDataTableGrid As New DataTable
    Private selectDetail_DataTableGrid As New DataTable
    Private _selectDefaultColOfGrid As Integer = 0
    Private _selectGridRowNo As Integer = 0
    Private _selectReturnColNumber As Integer = -1
    Private _selectActivatedColName As String = ""
    Private _selectRowNo As Integer = 0
    Private _selectColNo As Integer = 0
    Private _selectGridLastColNo As Integer = 0
    Private _selectLastRow As Integer = 0
    Private _selectLast_Saved_Entry_No As Integer = 0
    Private _selectisCallerByOther As Boolean = False
    Private _selectold_Me_text As String = ""
    Private selectLast_Focused_Btn As String = ""
    Private _selectAllowMoveFromCell As Boolean = True
    Private WithEvents selecttxt_Name_For_Grid_Selection As New TextBox
    Private WithEvents selecttxt_Code_For_Grid_Selection As New TextBox
    Private WithEvents selectTxt_Dt As New ctl_TextBox.ctl_TextBox
    Private selectOld_Date As String = ""
    Private selectUse_Design_Shade_In_Entry As Boolean = False
    Private selectSkipWeightToBeamNo As String = "NO"
    Private selectPickChange As String = "NO"
    Private selectPartyChange As String = "NO"
    Private selectItemChange As String = "NO"
    Private selectSelvChange As String = "NO"
    Private selectShadeChange As String = "NO"
    Private selectDesignChange As String = "NO"
    Private selectShiftWiseProdEntry As String = "NO"
    Private selectFoldLockPer As Double = 0
#End Region
#Region "SELCTION GRID DETAIL STRING BUILDER VARIABLE "
    Private selectOffer_Calc_By As String
    Private _selectGridColNames As New StringBuilder
    Private _selectGridColType As New StringBuilder
    Private _selectGridColValidate As New StringBuilder
    Private _selectGridCol_FocusByPass As New StringBuilder
    Private _selectFieldDefaultValues As New StringBuilder
    Private _selectFieldHeader As New StringBuilder
    Private _selectFieldHeaderAlignment As New StringBuilder
    Private _selectFieldNotRequiredForSave As New StringBuilder
    Private _selectFieldNotVisibile As New StringBuilder
    Private _selectFieldWidthSet As New StringBuilder
    Private _selectFieldLocked As New StringBuilder
    Private _selectFieldMasking As New StringBuilder
    Private _selectFieldAlignMent As New StringBuilder
    Private _selectExtraFieldDataTable As New StringBuilder
    Private _selectExtraField_Values_DataTable As New StringBuilder
    Private _selectExtraFieldOthers As New StringBuilder
    Private _selectExtraField_Values_Others As New StringBuilder
    Private _selectFieldNameSameValueCopy As New StringBuilder
    Private _selectFieldNameForTotal As New StringBuilder
    Private _selectFieldNameColmType As New StringBuilder
#End Region
    Private Sub selectDefine_Grid_Item_ColName()
        _selectGridColNames = New StringBuilder
        With _selectGridColNames
            .Append("Column_Name")
            .Append(",IsSelect")
        End With

        _selectGridColType = New StringBuilder
        With _selectGridColType
            .Append("IsSelect:Y")
        End With

        _selectGridColValidate = New StringBuilder
        With _selectGridColValidate
        End With

        _selectGridCol_FocusByPass = New StringBuilder
        With _selectGridCol_FocusByPass
        End With

        _selectFieldHeader = New StringBuilder
        With _selectFieldHeader

            .Append("Column_Name:DataBase Column")
            .Append(",IsSelect:Select")
        End With

        _selectFieldHeaderAlignment = New StringBuilder
        With _selectFieldHeaderAlignment

            .Append("Column_Name:L")

        End With

        _selectFieldAlignMent = New StringBuilder
        With _selectFieldAlignMent

            .Append("Column_Name:L")

        End With

        _selectFieldNotVisibile = New StringBuilder
        With _selectFieldNotVisibile
            '.Append("ID:N")
        End With



        _selectFieldNotRequiredForSave = New StringBuilder
        With _selectFieldNotRequiredForSave
            '.Append("ID:N")
        End With

        _selectFieldWidthSet = New StringBuilder
        With _selectFieldWidthSet
            .Append("Column_Name:50")
            .Append(",IsSelect:20")
        End With

        _selectFieldDefaultValues = New StringBuilder
        With _selectFieldDefaultValues
            '.Append("OrderNo:0")
        End With

        _selectFieldLocked = New StringBuilder
        With _selectFieldLocked
            .Append("Column_Name:Y")
        End With

        _selectFieldMasking = New StringBuilder
        With _selectFieldMasking
            '.Append("GMTR:NO-2,")
        End With

        With _selectFieldNameSameValueCopy
        End With

        _selectFieldNameColmType = New StringBuilder
        With _selectFieldNameColmType
            .Append("IsSelect:CHK")
        End With
        selectGrid_Table_ColNames = _selectGridColNames.ToString.ToUpper.Split(",")
    End Sub
    Private Sub selectGenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _selectGridColNames.ToString.ToUpper, "NO", _selectGridColType.ToString)
        'grdObj.ExtendLastCol = True
        _selectGridLastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
    End Sub
    Private Sub selectGridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _selectFieldNotVisibile.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _selectFieldWidthSet.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _selectFieldHeader.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _selectFieldLocked.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _selectFieldMasking.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _selectFieldAlignMent.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _selectFieldHeaderAlignment.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "COLTYPE", _selectFieldNameColmType.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub

#End Region
#Region "GRID KEY"
    Private Sub Grid1_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Grid1.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
    End Sub
    Private Sub Grid1_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles Grid1.RowColChange
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))

    End Sub
    Private Sub Grid1_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles Grid1.LeaveCell
        If _AllowMoveFromCell = False Then e.Cancel = True
    End Sub
    Private Sub Grid1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid1.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
    End Sub
    Private Sub Grid1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid1.LostFocus
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub Grid1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid1.Validated
        Grid1.Refresh()
    End Sub
    Private Sub Grid1_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub

        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("DataBaseTable") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("DataBaseTable") + 1).Text = CmbTableName.Text
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("LocationX") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("LocationX") + 1).Text = 50
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("LocationY") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("LocationY") + 1).Text = 10
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SizeHeight") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SizeHeight") + 1).Text = 20
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SizeWidth") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SizeWidth") + 1).Text = 10
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("Tabindex") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("Tabindex") + 1).Text = 1
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("InputType") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("InputType") + 1).Text = "Normal"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "Y"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N"
        If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("FormDesignType") + 1).Text = "" Then Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("FormDesignType") + 1).Text = "Grid Detail Design"

        If _ActivatedColName = "COLUMNTYPE" Then
            If e.KeyCode = Keys.Space Then
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Label"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Label" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Button"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Button" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Grid"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Grid" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox"

                End If
            End If
        ElseIf _ActivatedColName = "INPUTTYPE" And Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox" Then
            If e.KeyCode = Keys.Space Then
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Normal" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Number"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Number" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Normal"
                End If
            End If
        ElseIf _ActivatedColName = "VISIBLE" Then
            If e.KeyCode = Keys.Space Then
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "Y" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "N"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "N" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "Y"
                End If
            End If
        ElseIf _ActivatedColName = "TEXTALIGN" Then
            If e.KeyCode = Keys.Space Then
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "R"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "R" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "C"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "C" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L"

                End If
            End If
        ElseIf _ActivatedColName = "SAVEYN" Then
            If e.KeyCode = Keys.Space Then
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "N"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "N" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y"
                End If
            End If
        ElseIf _ActivatedColName = "USEMASTER" Then
            Dim masterListCol As Integer = Detail_DataTableGrid.Columns.IndexOf("MASTERLIST") + 1
            Dim gridCombo As Object = Grid1.ComboBox(masterListCol)
            Dim row As Integer = Grid1.ActiveCell.Row
            If e.KeyCode = Keys.Space Then
                Dim useMasterCol As Integer = Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1
                Dim useMasterValue As String = Grid1.Cell(row, useMasterCol).Text.Trim().ToUpper()
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "YES" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO"
                    Grid1.Cell(row, masterListCol).Locked = True
                    gridCombo.Items.Clear()
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "YES"
                    Grid1.Cell(row, masterListCol).Locked = False
                    FillUseMasterCombo(gridCombo)
                End If
            Else
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO" Then
                    Grid1.Cell(row, masterListCol).Locked = True
                    gridCombo.Items.Clear()
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "YES" Then
                    Grid1.Cell(row, masterListCol).Locked = False
                    FillUseMasterCombo(gridCombo)
                End If
            End If
            If Grid1.Rows - 1 = Grid1.ActiveCell.Row Then
                Grid1.Rows = Grid1.Rows + 1
                Grid1.Cell(Grid1.ActiveCell.Row + 1, Detail_DataTableGrid.Columns.IndexOf("CNTRLNAME") + 1).Text = Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("CNTRLNAME") + 1).Text
            End If
        ElseIf _ActivatedColName = "MASTERLIST" Then
            Dim _getcol As Integer = Grid1.ActiveCell.Col
            Grid1.ComboBox(_getcol).DropDown()
        ElseIf _ActivatedColName = "READONLY" Then
            If e.KeyCode = Keys.Space Then
                If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "Y" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N"
                ElseIf Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N" Then
                    Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "Y"
                End If
            End If
        ElseIf _ActivatedColName = "DATABASECOLUMN" Then
            Dim _getcol As Integer = Grid1.ActiveCell.Col
            Grid1.ComboBox(_getcol).DropDown()
            If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("DATABASECOLUMN") + 1).Text = "" Then
                Dim _TblName As String = Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("DATABASETABLE") + 1).Text
                sqL = "SELECT COLUMN_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" & _TblName & "' ORDER BY COLUMN_NAME "
                sql_connect_slect()
                Dim dtFiltered As DataTable
                'dtFiltered = GetFilteredColumnsFromGrid(Grid1, DefaltSoftTable)
                dtFiltered = View_RecordGridDetail()
                Dim cmb = Grid1.ComboBox(_getcol)
                cmb.DataSource = Nothing
                cmb.DisplayMember = ""
                cmb.DataSource = dtFiltered
                cmb.DisplayMember = "COLUMN_NAME"
            End If
        ElseIf _ActivatedColName = "OPPMASTERCODE" Then
            Dim _getcol As Integer = Grid1.ActiveCell.Col
            Grid1.ComboBox(_getcol).DropDown()
            If Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("DATABASECOLUMN") + 1).Text = "" Then
                Dim dtFiltered As DataTable
                dtFiltered = _GetAllColumName()
                Dim cmb = Grid1.ComboBox(_getcol)
                cmb.DataSource = Nothing
                cmb.DisplayMember = ""
                cmb.DataSource = dtFiltered
                cmb.DisplayMember = "COLUMN_NAME"
            Else
                Dim dtFiltered As DataTable
                dtFiltered = _GetAllColumName()
                Dim cmb = Grid1.ComboBox(_getcol)
                cmb.DataSource = Nothing
                cmb.DisplayMember = ""
                cmb.DataSource = dtFiltered
                cmb.DisplayMember = "COLUMN_NAME"
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            _FocusgridName = "Grid1"
            View_RecordGridDetail()
            Pnlview.Visible = True
        End If
        Call Fill_Sr_No_Item(Grid1, Detail_DataTableGrid)
    End Sub

    Private Function _GetAllColumName()

        _strQuery = New StringBuilder
        Dim _TblName As String = CmbTableName.Text
        With _strQuery
            .Append(" SELECT COLUMN_NAME,ORDINAL_POSITION As IsSelect  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" & _TblName & "'  ")
            .Append("ORDER BY COLUMN_NAME")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As DataTable
        tblTmp = DefaltSoftTable.Copy
        Return tblTmp
    End Function
    Private Function View_RecordGridDetail()

        _strQuery = New StringBuilder
        Dim _TblName As String = CmbTableName.Text
        With _strQuery
            .Append(" SELECT COLUMN_NAME,ORDINAL_POSITION As IsSelect  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" & _TblName & "'  ")
            .Append("ORDER BY COLUMN_NAME")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As DataTable
        tblTmp = DefaltSoftTable.Copy

        Clear_Grid(Grid3, 2)
        Dim dtFiltered As DataTable
        dtFiltered = GetFilteredColumnsFromGrid(GrdItem, DefaltSoftTable, _DataTableGrid)
        dtFiltered = GetFilteredColumnsFromGrid(Grid1, dtFiltered, Detail_DataTableGrid)
        Fill_Records(dtFiltered, selectGrid_Table_ColNames, Grid3, 0, True, "", False)

        For r As Integer = 1 To Grid3.Rows - 1
            If Val(Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text) = 1 Then
                Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text = 0
            End If
        Next
        Grid3.Focus()
        Grid3.Cell(1, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).SetFocus()
        Return dtFiltered
    End Function

#End Region


    Public Function GetFilteredColumnsFromGrid(grid As Object, masterTable As DataTable, ByVal _selectrdGrid As DataTable) As DataTable

        Dim selectedCols As New List(Of String)

        Dim colIndex As Integer = _selectrdGrid.Columns.IndexOf("DATABASECOLUMN") + 1

        If colIndex <= 0 Then Return masterTable.Copy()

        ' 1. Collect values from that column
        For i As Integer = 1 To grid.Rows - 1
            Dim val As String = grid.Cell(i, colIndex).Text
            If Not String.IsNullOrWhiteSpace(val) Then
                selectedCols.Add(val.Trim())
            End If
        Next

        ' 2. Copy master table
        Dim dtFiltered As DataTable = masterTable.Copy()

        ' 3. Remove matching COLUMN_NAME rows
        For i As Integer = dtFiltered.Rows.Count - 1 To 0 Step -1
            If selectedCols.Contains(dtFiltered.Rows(i)("COLUMN_NAME").ToString()) Then
                dtFiltered.Rows.RemoveAt(i)
            End If
        Next

        Return dtFiltered
    End Function

#End Region


    Private Sub MainFrmDesigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        _addcoloum()
        Ctl_Managebybook.Text = "NO"


        Pnlview.Width = Me.Width
        Pnlview.Height = Me.Height
        Pnlview.Location = New Point(800, 0)

        Grid3.Width = Pnlview.Width - 820
        Grid3.Height = Pnlview.Height - 110
        'Grid3.Location = New Point(600, 0)


        Me.Location = New Point(0, 0)
        GetTblName(_DataBaseFileName)
        Define_Grid_Item_ColName()
        GenerateTable(_DataTableGrid, GrdItem)
        GridFormatting(_DataTableGrid, GrdItem)
        Clear_Grid(GrdItem, 2)
        GrdItem.Rows = 2
        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        Detail_Define_Grid_Item_ColName()
        Detail_GenerateTable(Detail_DataTableGrid, Grid1)
        Detail_GridFormatting(Detail_DataTableGrid, Grid1)
        Clear_Grid(Grid1, 2)
        Grid1.Rows = 2
        Grid1.Cell(1, Detail_DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
        FocusSetToGridDefaultColumn(Grid1, _DefaultColOfGrid)

        _FrmLoad = True

        selectDefine_Grid_Item_ColName()
        selectGenerateTable(_selectDataTableGrid, Grid3)
        selectGridFormatting(_selectDataTableGrid, Grid3)
        Clear_Grid(Grid3, 2)
        Grid3.Rows = 2
        Grid3.Cell(1, _selectDataTableGrid.Columns.IndexOf("ISSELECT") + 1).SetFocus()
        FocusSetToGridDefaultColumn(Grid3, _DefaultColOfGrid)


        _FrmLoad = False
        'Change_Grid_Data = False
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        TabControl1.Enabled = False
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnPrint", "BtnReports", "BtnView")
    End Sub
    Private Sub _addcoloum()

        Dim CHKCOLUM = False
        Dim COLOUM As String = ""

        sqL = " Select * FROM " & _DatabaseTableNameItem & " "
        sql_connect_slect1()
        For Each column As DataColumn In DefaltSoftTable.Columns
            COLOUM = (column.ColumnName)
            If COLOUM = "TextAlign" Then
                CHKCOLUM = True
            End If
        Next
        If CHKCOLUM = False Then
            _strQuery = New System.Text.StringBuilder
            With _strQuery
                .Append("  ALTER TABLE " & _DatabaseTableNameItem & " add   ")
                .Append(" TextAlign VARCHAR(20) NULL ")
                .Append(" ,ReadOnly VARCHAR(20) NULL ")
                .Append(" ,SaveYN VARCHAR(20) Default 'Y' ")
                .Append(" ,UseMaster VARCHAR(20) DEFAULT 'YES' ")
                .Append(" ,Masking NUMERIC(18,0) NOT NULL DEFAULT (0) ")
                .Append(" ,OppMasterCode VARCHAR(250) NULL ")
                .Append(" ,Masterlist VARCHAR(250) NULL ")
                .Append(" ,ManageBook VARCHAR(20) DEFAULT 'NO' ")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update1()
        End If

    End Sub

#Region "Save Data"
    Private Function griditemDetailsSaveQuery(ByRef arr_object As String(,)) As String
        Dim result As String = ""
        Try

            Dim array As String(,) = New String(Me._DataTableGrid.Rows.Count + 1 - 1, 4) {}


            Dim text As String = "ColumnType>'' "
            Me._ExtraFieldDataTable = New StringBuilder
            Dim extraFieldDataTable As StringBuilder = Me._ExtraFieldDataTable
            extraFieldDataTable.Append("FormID,")
            extraFieldDataTable.Append("FormName,")
            extraFieldDataTable.Append("DataBaseName,")
            extraFieldDataTable.Append("MainMenuName,")
            extraFieldDataTable.Append("ParentMenu1,")
            'extraFieldDataTable.Append("Nature,")
            'extraFieldDataTable.Append("Beahviour,")
            'extraFieldDataTable.Append("BookCategory,")
            extraFieldDataTable.Append("Active,")
            extraFieldDataTable.Append("ShortCutKey,")
            extraFieldDataTable.Append("MainFormSizeX,")
            extraFieldDataTable.Append("MainFormLocationX,")
            extraFieldDataTable.Append("MainFormSizeY,")
            extraFieldDataTable.Append("MainFormLocationY,")
            extraFieldDataTable.Append("Bookcode,")
            extraFieldDataTable.Append("ManageBook,")
            extraFieldDataTable.Append("FormDesignType")
            extraFieldDataTable.Append("OrderNo")




            Me._ExtraField_Values_DataTable = New StringBuilder
            Dim extraField_Values_DataTable As StringBuilder = Me._ExtraField_Values_DataTable
            extraField_Values_DataTable.Append(Txt_FormId.Text + ",")
            extraField_Values_DataTable.Append(txtFormName.Text + ",")
            extraField_Values_DataTable.Append(CmbTableName.Text + ",")
            extraField_Values_DataTable.Append(Txt_MenuName.Text + ",")
            extraField_Values_DataTable.Append(Txt_PerentMenuName.Text + ",")
            'extraField_Values_DataTable.Append(Cmb_Nature.Text + ",")
            'extraField_Values_DataTable.Append(Cmb_Beahviour.Text + ",")
            'extraField_Values_DataTable.Append(Cmb_BookCategory.Text + ",")
            extraField_Values_DataTable.Append(Txt_Active.Text + ",")
            extraField_Values_DataTable.Append(Txt_ShortCutKey.Text + ",")
            extraField_Values_DataTable.Append(Txt_mainFormSize.Text + ",")
            extraField_Values_DataTable.Append(Txt_MainFormLocation.Text + ",")
            extraField_Values_DataTable.Append(TxtMainFormSizeY.Text + ",")
            extraField_Values_DataTable.Append(TxtMainFormLocaY.Text + ",")
            extraField_Values_DataTable.Append(_BookCode.ToString().Trim() + ",")
            extraField_Values_DataTable.Append(Ctl_Managebybook.Text + ",")
            extraField_Values_DataTable.Append("HEADER DESIGN" + "")

            'Dim ObjCls_General As cls_FrmHandle = ObjCls_General
            Dim text2 As String = _DatabaseTableNameItem
            Dim text3 As String = "FORCELY_ADDED"
            Dim text4 As String = text
            Dim text5 As String = _FieldNotRequiredForSave.ToString().ToUpper()
            Dim queryArray As String = ObjCls_General.GetQueryArray(text2, text3, text4, array, Me._DataTableGrid, text5, Me._RecordsKeyFieldName, "", "", "N", Me._ExtraFieldDataTable.ToString().ToUpper(), Me._ExtraField_Values_DataTable.ToString().ToUpper(), Me._ExtraFieldOthers.ToString().ToUpper(), Me._ExtraField_Values_Others.ToString().ToUpper(), _FieldDefaultValues.ToString().ToUpper())
            result = queryArray + ";"
            arr_object = array

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return result
    End Function

    Private Function Detail_griditemDetailsSaveQuery(ByRef arr_object As String(,)) As String
        Dim result As String = ""
        Try

            Dim array As String(,) = New String(Me.Detail_DataTableGrid.Rows.Count + 1 - 1, 4) {}


            Dim text As String = "DataBaseColumn>'' "
            Me._ExtraFieldDataTable = New StringBuilder
            Dim extraFieldDataTable As StringBuilder = Me._ExtraFieldDataTable
            extraFieldDataTable.Append("FormID,")
            extraFieldDataTable.Append("FormName,")
            extraFieldDataTable.Append("DataBaseName,")
            extraFieldDataTable.Append("MainMenuName,")
            extraFieldDataTable.Append("ParentMenu1,")
            'extraFieldDataTable.Append("Nature,")
            'extraFieldDataTable.Append("Beahviour,")
            'extraFieldDataTable.Append("BookCategory,")
            extraFieldDataTable.Append("Active,")
            extraFieldDataTable.Append("ShortCutKey,")
            extraFieldDataTable.Append("MainFormSizeX,")
            extraFieldDataTable.Append("MainFormLocationX,")
            extraFieldDataTable.Append("MainFormSizeY,")
            extraFieldDataTable.Append("MainFormLocationY,")
            extraFieldDataTable.Append("Bookcode,")
            extraFieldDataTable.Append("ManageBook,")
            extraFieldDataTable.Append("FormDesignType")
            extraFieldDataTable.Append("OrderNo")




            Me._ExtraField_Values_DataTable = New StringBuilder
            Dim extraField_Values_DataTable As StringBuilder = Me._ExtraField_Values_DataTable
            extraField_Values_DataTable.Append(Txt_FormId.Text + ",")
            extraField_Values_DataTable.Append(txtFormName.Text + ",")
            extraField_Values_DataTable.Append(CmbTableName.Text + ",")
            extraField_Values_DataTable.Append(Txt_MenuName.Text + ",")
            extraField_Values_DataTable.Append(Txt_PerentMenuName.Text + ",")
            'extraField_Values_DataTable.Append(Cmb_Nature.Text + ",")
            'extraField_Values_DataTable.Append(Cmb_Beahviour.Text + ",")
            'extraField_Values_DataTable.Append(Cmb_BookCategory.Text + ",")
            extraField_Values_DataTable.Append(Txt_Active.Text + ",")
            extraField_Values_DataTable.Append(Txt_ShortCutKey.Text + ",")
            extraField_Values_DataTable.Append(Txt_mainFormSize.Text + ",")
            extraField_Values_DataTable.Append(Txt_MainFormLocation.Text + ",")
            extraField_Values_DataTable.Append(TxtMainFormSizeY.Text + ",")
            extraField_Values_DataTable.Append(TxtMainFormLocaY.Text + ",")
            extraField_Values_DataTable.Append(_BookCode.ToString().Trim() + ",")
            extraField_Values_DataTable.Append(Ctl_Managebybook.Text + ",")
            extraField_Values_DataTable.Append("Grid Detail Design" + "")


            Dim text2 As String = _DatabaseTableNameItem
            Dim text3 As String = "FORCELY_ADDED"
            Dim text4 As String = text
            Dim text5 As String = Detail_FieldNotRequiredForSave.ToString().ToUpper()
            Dim queryArray As String = ObjCls_General.GetQueryArray(text2, text3, text4, array, Me.Detail_DataTableGrid, text5, Me._RecordsKeyFieldName, "", "", "N", Me._ExtraFieldDataTable.ToString().ToUpper(), Me._ExtraField_Values_DataTable.ToString().ToUpper(), Me.Detail_ExtraFieldOthers.ToString().ToUpper(), Me.Detail_ExtraField_Values_Others.ToString().ToUpper(), Detail_FieldDefaultValues.ToString().ToUpper())
            result = queryArray + ";"
            arr_object = array

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return result
    End Function



    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        _DataTableGrid.Rows.Clear()


        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.Cntrlid ")
            .Append(" FROM " & _DatabaseTableNameItem & " A ")
            .Append(" WHERE 1=1 ")
            .Append(" ORDER BY A.Cntrlid DESC ")
        End With
        Dim TblTmp As New DataTable
        Dim Last_Cntrlid As Integer = 1
        sqL = _strQuery.ToString
        sql_connect_slect1()
        If DefaltSoftTable.Rows.Count > 0 Then
            If IsDBNull(DefaltSoftTable.Rows(0).Item("Cntrlid")) Then DefaltSoftTable.Rows(0).Item("Cntrlid") = 1
            Last_Cntrlid = Val(DefaltSoftTable.Rows(0).Item("Cntrlid")) + 1
        End If


        Dim ColumnTypeCount As New Dictionary(Of String, Integer)
        For i As Int16 = 1 To GrdItem.Rows - 1
            'Dim _ColumnType As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ColumnType") + 1).Text
            'If Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Cntrlid") + 1).Text) = 0 Then
            '    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Cntrlid") + 1).Text = Last_Cntrlid
            '    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CntrlName") + 1).Text = _ColumnType & Last_Cntrlid.ToString
            'End If
            Dim _ColumnType As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ColumnType") + 1).Text
            If Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Cntrlid") + 1).Text) = 0 Then
                If Not ColumnTypeCounter.ContainsKey(_ColumnType) Then
                    ColumnTypeCounter(_ColumnType) = 1
                Else
                    ColumnTypeCounter(_ColumnType) += 1
                End If

                ' 🔴 Grid limit check
                If _ColumnType = "Grid" AndAlso ColumnTypeCounter(_ColumnType) > 5 Then
                    MessageBox.Show("Grid type maximum 5 hi allowed hai.", "Limit Reached",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit For   ' loop se bahar
                End If

                Dim NewCntrlId As Integer = ColumnTypeCounter(_ColumnType)
                GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Cntrlid") + 1).Text = NewCntrlId
                GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CntrlName") + 1).Text = _ColumnType & NewCntrlId.ToString()

            End If

            If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ColumnType") + 1).Text > "" Then
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

            Last_Cntrlid = Last_Cntrlid + 1
        Next
        '----------------------------------------
    End Sub
    Private Sub Detail_Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        Detail_DataTableGrid.Rows.Clear()
        For i As Int16 = 1 To Grid1.Rows - 1
            If Grid1.Cell(i, Detail_DataTableGrid.Columns.IndexOf("DataBaseColumn") + 1).Text > "" Then
                FieldDr = Detail_DataTableGrid.NewRow
                For j As Int16 = 1 To Grid1.Cols - 1

                    If FieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FieldDr(j - 1) = Val(Grid1.Cell(i, j).Text)
                    Else
                        FieldDr(j - 1) = (Grid1.Cell(i, j).Text)
                    End If


                Next
                Detail_DataTableGrid.Rows.Add(FieldDr)
            End If

            'Last_Cntrlid = Last_Cntrlid + 1
        Next
        '----------------------------------------
    End Sub
#End Region
    Private Sub _ClearTex()
        txtFormName.Text = ""
        Txt_mainFormSize.Text = ""
        TxtMainFormSizeY.Text = ""
        Txt_MainFormLocation.Text = ""
        TxtMainFormLocaY.Text = ""
        CmbTableName.Text = ""
        Txt_MenuName.Text = ""
        Txt_PerentMenuName.Text = ""
        'Cmb_Nature.Text = ""
        'Cmb_Beahviour.Text = ""
        'Cmb_BookCategory.Text = ""
        Txt_Active.Text = "YES"
        Txt_ShortCutKey.Text = ""
        Ctl_BookName.Text = ""
        Ctl_Managebybook.Text = "NO"
    End Sub
#Region "CTRL VISIBLE FALSE"
    'Private Sub Cost_Sheet_Ctrl_Visible_False()
    '    GrdItem.Enabled = False
    '    Grid1.Enabled = False
    '    Grid2.Enabled = False
    '    Txt_FormId.Visible = False
    '    txtFormName.Visible = False
    '    Txt_mainFormSize.Visible = False
    '    TxtMainFormSizeY.Visible = False
    '    Txt_MainFormLocation.Visible = False
    '    TxtMainFormLocaY.Visible = False
    '    CmbTableName.Visible = False
    '    Txt_MenuName.Visible = False
    '    Txt_PerentMenuName.Visible = False
    '    'Cmb_Nature.Visible = False
    '    'Cmb_Beahviour.Visible = False
    '    'Cmb_BookCategory.Visible = False
    '    Txt_Active.Visible = False
    '    Txt_ShortCutKey.Visible = False
    '    Ctl_BookName.Visible = False
    '    Ctl_Managebybook.Visible = False
    '    'Txt_OrderNo.Visible = False

    'End Sub
#End Region
#Region "CTRL VISIBLE TRUE"
    'Private Sub Cost_Sheet_Ctrl_Visible_True()
    '    GrdItem.Enabled = True
    '    Grid1.Enabled = True
    '    Grid2.Enabled = True
    '    Txt_FormId.Visible = True
    '    txtFormName.Visible = True
    '    Txt_mainFormSize.Visible = True
    '    TxtMainFormSizeY.Visible = True
    '    Txt_MainFormLocation.Visible = True
    '    TxtMainFormLocaY.Visible = True
    '    CmbTableName.Visible = True
    '    Txt_MenuName.Visible = True
    '    Txt_PerentMenuName.Visible = True
    '    'Cmb_Nature.Visible = True
    '    'Cmb_Beahviour.Visible = True
    '    'Cmb_BookCategory.Visible = True
    '    Txt_Active.Visible = True
    '    Txt_ShortCutKey.Visible = True
    '    Ctl_BookName.Visible = True
    '    Ctl_Managebybook.Visible = True
    '    'Txt_OrderNo.Visible = True

    'End Sub
#End Region
    Private Sub GetTblName(ByVal dbName As String)
        sqL = "Select  TABLE_NAME From INFORMATION_SCHEMA.TABLES Where TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='" & dbName & "' order by TABLE_NAME"
        Dim _Tmptbl As DataTable = sql_connect_slect()

        CmbTableName.DataSource = _Tmptbl.Copy
        CmbTableName.DisplayMember = "TABLE_NAME"


        'sqL = "SELECT NATURE FROM MSTBOOK  WHERE 1=1 AND NATURE>'' GROUP BY NATURE order by NATURE "
        'Dim _NatuTbl As DataTable = sql_connect_slect()

        'Cmb_Nature.DataSource = _NatuTbl.Copy
        'Cmb_Nature.DisplayMember = "NATURE"



        'sqL = "SELECT BEHAVIOUR FROM MSTBOOK  WHERE 1=1 AND BEHAVIOUR>'' GROUP BY BEHAVIOUR  ORDER BY BEHAVIOUR "
        'Dim _BeahTbl As DataTable = sql_connect_slect()
        'Cmb_Beahviour.DataSource = _BeahTbl.Copy
        'Cmb_Beahviour.DisplayMember = "BEHAVIOUR"


        'sqL = "SELECT BOOKCATEGORY FROM MSTBOOK  WHERE 1=1 AND BOOKCATEGORY>'' GROUP BY BOOKCATEGORY ORDER BY BOOKCATEGORY"
        'Dim _BookcatTbl As DataTable = sql_connect_slect()
        'Cmb_BookCategory.DataSource = _BookcatTbl.Copy
        'Cmb_BookCategory.DisplayMember = "BOOKCATEGORY"
    End Sub
#Region " COMBO BOX FOCUS SET"
    Private Sub CmbTableName_GotFocus(sender As Object, e As EventArgs) Handles CmbTableName.GotFocus
        CmbTableName.DroppedDown = True
    End Sub
    'Private Sub Cmb_Nature_GotFocus(sender As Object, e As EventArgs)
    '    Cmb_Nature.DroppedDown = True
    'End Sub
    'Private Sub Cmb_BookCategory_GotFocus(sender As Object, e As EventArgs)
    '    Cmb_BookCategory.DroppedDown = True
    'End Sub
    'Private Sub Cmb_Beahviou_GotFocus(sender As Object, e As EventArgs)
    '    Cmb_Beahviour.DroppedDown = True
    'End Sub
    Private Sub CmbTableName_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbTableName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_MenuName.Focus()
            Txt_MenuName.Select()
        End If
    End Sub
    Private Sub Cmb_Nature_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cmb_Beahviou_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cmb_BookCategory_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


#End Region

#Region "GRID KEY"
    Private Sub GrdItem_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
    End Sub
    Private Sub GrdItem_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))

    End Sub
    Private Sub GrdItem_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        If _AllowMoveFromCell = False Then e.Cancel = True
    End Sub
    Private Sub GrdItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
    End Sub
    Private Sub GrdItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.LostFocus
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub GrdItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Validated
        GrdItem.Refresh()
    End Sub
    Private Sub GrdItem_KeyDown(Sender As Object, e As KeyEventArgs) Handles GrdItem.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub

        'If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "GRIDDETAIL"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DataBaseTable") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DataBaseTable") + 1).Text = CmbTableName.Text
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LocationX") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LocationX") + 1).Text = 10
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LocationY") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LocationY") + 1).Text = 10
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SizeHeight") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SizeHeight") + 1).Text = 20
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SizeWidth") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SizeWidth") + 1).Text = 100
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "N"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OrderNo") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OrderNo") + 1).Text = 1
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Tabindex") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Tabindex") + 1).Text = 1
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("InputType") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("InputType") + 1).Text = "Normal"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("FormDesignType") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("FormDesignType") + 1).Text = "HEADER DESIGN"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO"

        If _ActivatedColName = "COLUMNTYPE" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Label"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Label" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Button"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Button" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Grid"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "Grid" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "ComboBox"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "ComboBox" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox"

                End If
            End If
        ElseIf _ActivatedColName = "INPUTTYPE" And GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "GRIDDETAIL" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Normal" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "DateBox"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "DateBox" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "SpacerType"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "SpacerType" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Numeric"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Numeric" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("INPUTTYPE") + 1).Text = "Normal"
                End If
            End If

        ElseIf _ActivatedColName = "VISIBLE" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "Y" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "N"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "N" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "Y"
                End If
            End If
        ElseIf _ActivatedColName = "TEXTALIGN" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "R"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "R" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "C"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "C" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L"

                End If
            End If
        ElseIf _ActivatedColName = "SAVEYN" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text.Trim().ToUpper() = "Y" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "N"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text.Trim().ToUpper() = "N" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y"
                End If
            End If
        ElseIf _ActivatedColName = "USEMASTER" Then
            Dim masterListCol As Integer = _DataTableGrid.Columns.IndexOf("MASTERLIST") + 1
            Dim gridCombo As Object = GrdItem.ComboBox(masterListCol)
            Dim useMasterCol As Integer = _DataTableGrid.Columns.IndexOf("USEMASTER") + 1
            Dim row As Integer = GrdItem.ActiveCell.Row
            If e.KeyCode = Keys.Space Then
                Dim useMasterValue As String = GrdItem.Cell(row, useMasterCol).Text.Trim().ToUpper()
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "YES" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO"
                    GrdItem.Cell(row, masterListCol).Locked = True
                    gridCombo.Items.Clear()
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "YES"
                    GrdItem.Cell(row, masterListCol).Locked = False
                    FillUseMasterCombo(gridCombo)
                End If
            Else
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO" Then
                    GrdItem.Cell(row, masterListCol).Locked = True
                    gridCombo.Items.Clear()
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "YES" Then
                    GrdItem.Cell(row, masterListCol).Locked = False
                    FillUseMasterCombo(gridCombo)
                End If
            End If
        ElseIf _ActivatedColName = "MASTERLIST" Then
            Dim _getcol As Integer = GrdItem.ActiveCell.Col
            GrdItem.ComboBox(_getcol).DropDown()
        ElseIf _ActivatedColName = "READONLY" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "Y" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "Y"
                End If
            End If
        ElseIf _ActivatedColName = "DATABASECOLUMN" Then
            Dim _getcol As Integer = GrdItem.ActiveCell.Col
            GrdItem.ComboBox(_getcol).DropDown()
            If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DATABASECOLUMN") + 1).Text = "" Then
                Dim _TblName As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DATABASETABLE") + 1).Text
                sqL = "SELECT COLUMN_NAME,ORDINAL_POSITION As IsSelect   FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" & _TblName & "' ORDER BY COLUMN_NAME "
                sql_connect_slect()
                Dim dtFiltered As DataTable
                'dtFiltered = GetFilteredColumnsFromGrid(GrdItem, DefaltSoftTable)
                dtFiltered = View_RecordGridDetail()
                Dim cmb = GrdItem.ComboBox(_getcol)
                cmb.DataSource = Nothing
                cmb.DisplayMember = ""

                cmb.DataSource = dtFiltered
                cmb.DisplayMember = "COLUMN_NAME"
            End If

        ElseIf _ActivatedColName = "OPPMASTERCODE" Then
            Dim _getcol As Integer = GrdItem.ActiveCell.Col
            GrdItem.ComboBox(_getcol).DropDown()
            If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DATABASECOLUMN") + 1).Text = "" Then

                Dim dtFiltered As DataTable
                dtFiltered = _GetAllColumName()
                Dim cmb = GrdItem.ComboBox(_getcol)
                cmb.DataSource = Nothing
                cmb.DisplayMember = ""

                cmb.DataSource = dtFiltered
                cmb.DisplayMember = "COLUMN_NAME"
            Else
                Dim dtFiltered As DataTable
                dtFiltered = _GetAllColumName()
                Dim cmb = GrdItem.ComboBox(_getcol)
                cmb.DataSource = Nothing
                cmb.DisplayMember = ""

                cmb.DataSource = dtFiltered
                cmb.DisplayMember = "COLUMN_NAME"
            End If

        ElseIf _ActivatedColName = "SPACERSTRING" Then
            If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                GrdItem.Rows = GrdItem.Rows + 1
            End If
        End If

        If e.KeyCode = Keys.F9 Then
            _FocusgridName = "GrdItem"
            View_RecordGridDetail()
            Pnlview.Visible = True
        End If
    End Sub
    Public Sub FillUseMasterCombo(ByVal cmb As Object)

        cmb.Items.Clear()

        Dim masters As String() = {
        "ACCOUNT MASTER",
        "AGENT MASTER",
        "CITY MASTER",
        "STATE MASTER",
        "FABRIC ITEM MASTER",
        "FABRIC DESIGN MASTER",
        "FABRIC SHADE MASTER",
        "FABRIC SELVEDGE MASTER",
        "YARN MASTER",
        "YARN SHADE MASTER",
        "GENRAL ITEM MASTER",
        "SUBITEM MASTER",
        "SIZE MASTER",
        "COLOR MASTER",
        "REMARK MASTER",
        "PROCESS MASTER",
        "CUT MASTER",
        "DEPARTMENT MASTER",
        "POST MASTER",
        "EMPLOYEE MASTER",
        "FABRIC GROUP MASTER",
        "GODOWN MASTER",
        "GRADER MASTER",
        "INSURANCE MASTER",
        "LOOMNO MASTER",
        "SALESMAN MASTER",
        "TRANSPORT MASTER"
    }

        Dim sortedMasters = masters.OrderBy(Function(x) x).ToArray()
        cmb.Items.AddRange(sortedMasters)
        cmb.SelectedIndex = 0   ' optional
    End Sub
    Private Sub MainFrmDesigner_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)

        If e.KeyCode = Keys.F3 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    Delete_Row(GrdItem, _DataTableGrid)
                    If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                        GrdItem.Rows = GrdItem.Rows + 1
                    End If

                Case "GRID1"
                    Delete_Row(Grid1, Detail_DataTableGrid)
                    If Grid1.Rows - 1 = Grid1.ActiveCell.Row Then
                        Grid1.Rows = Grid1.Rows + 1
                    End If
                    Call Fill_Sr_No_Item(Grid1, Detail_DataTableGrid)
            End Select
        ElseIf e.KeyCode = Keys.Escape Then
            If Pnlview.Visible = True Then
                Pnlview.Visible = False
            Else
                If MsgBox("Do You Want To Close(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Close ?") = MsgBoxResult.Yes Then

                    Me.Close()
                    Me.Dispose()
                Else
                    Txt_FormId.Focus()
                    _ClearTex()
                    Call Ctrl_Visible_True(Me.Controls)
                    Clear_Grid(GrdItem, 2)
                    Clear_Grid(Grid1, 2)
                End If
            End If

        End If
    End Sub

    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).DeleteByRow()
        GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = GrdObj.ActiveCell.Row
    End Sub
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Try
            Dim i As Integer = 0
            For i = 1 To GrdObj.Rows - 1
                If GrdObj.Cell(i, Data_Table.Columns.IndexOf("ORDERNO") + 1).Text = "" Then
                    GrdObj.Cell(i, Data_Table.Columns.IndexOf("ORDERNO") + 1).Text = i
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub LoadFormDesign()

        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Grid1.Range(0, 0, Grid1.Rows - 1, Grid1.Cols - 1).DeleteByRow()
        Clear_Grid(GrdItem, 2)
        Clear_Grid(Grid1, 2)
        Dim View_Filter_Condition = ""
        'and BookCode='" & _BookCode & "'
        If Ctl_ImpformId.Text <> "" Then
            View_Filter_Condition = " AND  FormId='" & Ctl_ImpformId.Text & "'  "
        ElseIf Txt_FormId.Text <> "" Then
            View_Filter_Condition = " AND  FormId='" & Txt_FormId.Text & "' "

        End If
        'If _FORMMODE = "EDIT" Then
        '    View_Filter_Condition = " AND  FormId='" & Txt_FormId.Text & "' and BookCode='" & _BookCode & "' "
        'End If
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT *,B.BookName,B.Bookcode ")
            .Append(" FROM " & _DatabaseTableNameItem & " ")
            .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
            .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
            .Append(" where 1=1 ")
            .Append(View_Filter_Condition)
            .Append(" AND  FormDesignType='HEADER DESIGN' ")
        End With
        sqL = _strQuery.ToString
        Dim tblTmp As New DataTable
        sql_connect_slect1()
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then

            FillHeaderControls(tblTmp.Rows(0))

            Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT *,B.BookName,B.Bookcode ")
                .Append(" FROM " & _DatabaseTableNameItem & " ")
                .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
                .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
                .Append(" where 1=1 ")
                .Append(View_Filter_Condition)
                .Append(" AND  FormDesignType='Grid Detail Design' ")
                .Append(" ORDER BY OrderNo ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect1()

            Fill_Records(DefaltSoftTable, Detail_Grid_Table_ColNames, Grid1, 0, True, "", False)
        Else
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT *,B.BookName,B.Bookcode ")
                .Append(" FROM " & _DatabaseTableNameItem & " ")
                .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
                .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
                .Append(" where 1=1 ")
                .Append(View_Filter_Condition)
                .Append(" AND  FormDesignType='Grid Detail Design' ")
                .Append(" ORDER BY OrderNo ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect1()
            tblTmp = DefaltSoftTable.Copy

            If tblTmp.Rows.Count > 0 Then
                FillHeaderControls(tblTmp.Rows(0))
                Fill_Records(DefaltSoftTable, Detail_Grid_Table_ColNames, Grid1, 0, True, "", False)
            Else
                If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                    MsgBox("From Id " + Trim(Txt_FormId.Text) + " Not Found")
                    'Txt_FormId.Visible = True
                    Txt_FormId.Focus()
                    Txt_FormId.Select()
                    _ClearTex()
                    Clear_Grid(GrdItem, 2)
                    Clear_Grid(Grid1, 2)
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                End If
            End If

        End If
    End Sub

    Private Sub LoadFormDesignAfteredit(ByVal _Bookcode As String)

        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Grid1.Range(0, 0, Grid1.Rows - 1, Grid1.Cols - 1).DeleteByRow()
        Clear_Grid(GrdItem, 2)
        Clear_Grid(Grid1, 2)
        Dim View_Filter_Condition = ""

        If _Bookcode <> "" Then
            View_Filter_Condition = " AND  FormId='" & Txt_FormId.Text & "' and " & _DatabaseTableNameItem & ".BookCode='" & _Bookcode & "' "
        Else
            View_Filter_Condition = " AND  FormId='" & Txt_FormId.Text & "' "
        End If


        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT *,B.BookName,B.Bookcode ")
            .Append(" FROM " & _DatabaseTableNameItem & " ")
            .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
            .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
            .Append(" where 1=1 ")
            .Append(View_Filter_Condition)
            .Append(" AND  FormDesignType='HEADER DESIGN' ")
        End With
        sqL = _strQuery.ToString
        Dim tblTmp As New DataTable
        sql_connect_slect1()
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then

            FillHeaderControls(tblTmp.Rows(0))

            Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT *,B.BookName,B.Bookcode ")
                .Append(" FROM " & _DatabaseTableNameItem & " ")
                .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
                .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
                .Append(" where 1=1 ")
                .Append(View_Filter_Condition)
                .Append(" AND  FormDesignType='Grid Detail Design' ")
                .Append(" ORDER BY OrderNo ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect1()

            Fill_Records(DefaltSoftTable, Detail_Grid_Table_ColNames, Grid1, 0, True, "", False)
        Else
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT *,B.BookName,B.Bookcode ")
                .Append(" FROM " & _DatabaseTableNameItem & " ")
                .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
                .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
                .Append(" where 1=1 ")
                .Append(View_Filter_Condition)
                .Append(" AND  FormDesignType='Grid Detail Design' ")
                .Append(" ORDER BY OrderNo ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect1()
            tblTmp = DefaltSoftTable.Copy

            If tblTmp.Rows.Count > 0 Then
                FillHeaderControls(tblTmp.Rows(0))
                Fill_Records(DefaltSoftTable, Detail_Grid_Table_ColNames, Grid1, 0, True, "", False)
            Else
                If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                    MsgBox("From Id " + Trim(Txt_FormId.Text) + " Not Found")
                    'Txt_FormId.Visible = True
                    Txt_FormId.Focus()
                    Txt_FormId.Select()
                    _ClearTex()
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                End If
            End If

        End If
    End Sub
    Private Sub FillHeaderControls(r As DataRow)
        If Ctl_ImpformId.Text <> "" Then
            Txt_FormId.Text = Convert.ToDecimal(r("FormId")).ToString("0")
        End If

        txtFormName.Text = r("FormName").ToString()
        CmbTableName.Text = r("DataBaseTable").ToString()
        Txt_MenuName.Text = r("MainMenuName").ToString()
        Txt_PerentMenuName.Text = r("ParentMenu1").ToString()
        'Cmb_Nature.Text = r("Nature").ToString()
        'Cmb_Beahviour.Text = r("Beahviour").ToString()
        'Cmb_BookCategory.Text = r("BookCategory").ToString()
        Txt_Active.Text = r("Active").ToString()
        Txt_ShortCutKey.Text = r("ShortCutKey").ToString()
        'Txt_OrderNo.Text = r("OrderNo").ToString()
        Txt_mainFormSize.Text = r("MainFormSizeX").ToString()
        Txt_MainFormLocation.Text = r("MainFormLocationX").ToString()
        TxtMainFormSizeY.Text = r("MainFormSizeY").ToString()
        TxtMainFormLocaY.Text = r("MainFormLocationY").ToString()
        '_BookCode = r("BookCode").ToString()
        _LastBookCode = r("BookCode").ToString()
        Ctl_BookName.ReadOnly = True
        Ctl_Managebybook.Text = r("ManageBook").ToString().Trim()

        If Ctl_ImpformId.Text <> "" Then
            'Ctl_BookName.Text = r("BookName").ToString()
            Ctl_BookName.ReadOnly = False
        End If



    End Sub
    Public Function EntryData_Invoice_Entry_txtBookName_Validated() As String
        Dim View_Filter_Condition = ""
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.FormID,A.BookCode ")
            .Append(" FROM " & _DatabaseTableNameItem & " A ")
            .Append(" WHERE 1=1 ")
            .Append(View_Filter_Condition)
            .Append(" ORDER BY A.FormID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Private Sub Close__Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub Txt_FormId_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_FormId.KeyDown
        'If _FORMMODE = "" AndAlso Txt_FormId.Text.Trim > "" Then
        '    _FORMMODE = "EDIT"
        'End If
        If e.KeyCode = Keys.Enter Then
            If _FORMMODE = "EDIT" AndAlso Txt_FormId.Text.Trim > "" Then
                Dim _Tmptbla As New DataTable
                _Tmptbla = _checkForm()
                If _Tmptbla.Rows.Count > 0 Then
                Else
                    MsgBox("Record Not Found")
                    Txt_FormId.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Delete_Entry()
        _FrmLoad = True
        Dim I As Integer = 0
        Dim _LastID As Integer = 0

        _strQuery = New StringBuilder

        Try
            strQuery = "DELETE FROM " & _DatabaseTableNameItem & " WHERE FormID='" & Txt_FormId.Text & "'"
            sqL = strQuery.ToString
            sql_connect_slect1()
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

    Private Sub Grid3_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid3.KeyDown
        If e.KeyCode = Keys.F11 Then
            For r As Integer = 1 To Grid3.Rows - 1
                If Val(Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text) = 1 Then
                    Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text = 0
                Else
                    Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text = 1
                End If
            Next

        ElseIf e.KeyCode = Keys.F12 Then
            'selection list for Header grid

            If _FocusgridName = "GrdItem" Then
                Dim _ActiverownoHeader As Integer = GrdItem.ActiveCell.Row
                If _ActiverownoHeader > 0 Then
                    'Dim colIndexCT As Integer = _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1
                    'Dim firstValue As String = GrdItem.Cell(_ActiverownoHeader, colIndexCT).Text.Trim()
                    'Dim baseName As String = New String(firstValue.TakeWhile(Function(c) Not Char.IsDigit(c)).ToArray())
                    'If baseName = "" Then
                    '    baseName = "TextBox"
                    'End If

                    Dim _BaseName As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text

                    For r As Integer = 1 To Grid3.Rows - 1
                        If Val(Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text) = 1 Then
                            Dim _ColmName As String = Grid3.Cell(r, _selectDataTableGrid.Columns.IndexOf("Column_Name") + 1).Text
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = _BaseName.ToString()
                            'GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "GRIDDETAIL"
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("DATABASECOLUMN") + 1).Text = _ColmName
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("DataBaseTable") + 1).Text = CmbTableName.Text
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("LocationX") + 1).Text = 10
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("LocationY") + 1).Text = LocationY
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("SizeHeight") + 1).Text = 20
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("SizeWidth") + 1).Text = 100
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("OrderNo") + 1).Text = _ActiverownoHeader
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("Tabindex") + 1).Text = _ActiverownoHeader
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "N"
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L"
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y"
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("InputType") + 1).Text = "Normal"
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N"
                            GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("FormDesignType") + 1).Text = "HEADER DESIGN"
                            'GrdItem.Cell(_ActiverownoHeader, _DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO"


                            Dim row As Integer = _ActiverownoHeader
                            Dim col As Integer = _DataTableGrid.Columns.IndexOf("USEMASTER") + 1

                            Dim val As String = GrdItem.Cell(row, col).Text

                            ' Clean value (remove spaces)
                            val = val.Trim().ToUpper()

                            If val = "YES" Then
                                GrdItem.Cell(row, col).Text = "YES"
                            Else
                                GrdItem.Cell(row, col).Text = "NO"
                            End If
                            ' Control name ke sath numbering
                            'GrdItem.Cell(_ActiverownoHeader, colIndexCT).Text = baseName & (_ActiverownoHeader).ToString()


                            GrdItem.Rows = GrdItem.Rows + 1
                            _ActiverownoHeader = _ActiverownoHeader + 1
                            LocationY = LocationY + 30
                        End If
                    Next
                    GrdItem.Focus()
                End If
            ElseIf _FocusgridName = "Grid1" Then
                'selection list for Detail grid
                Dim _Activerowno As Integer = Grid1.ActiveCell.Row
                If _Activerowno > 0 Then
                    Dim _BaseName As String = Grid1.Cell(Grid1.ActiveCell.Row, Detail_DataTableGrid.Columns.IndexOf("CntrlName") + 1).Text

                    For r As Integer = 1 To Grid3.Rows - 1
                        If Val(Grid3.Cell(r, selectGrid_Table_ColNames.ToList.IndexOf("ISSELECT") + 1).Text) = 1 Then
                            Dim _ColmName As String = Grid3.Cell(r, _selectDataTableGrid.Columns.IndexOf("Column_Name") + 1).Text

                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("CntrlName") + 1).Text = _BaseName.ToString()
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("DATABASECOLUMN") + 1).Text = _ColmName
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("COLUMNTYPE") + 1).Text = "TextBox"
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("DataBaseTable") + 1).Text = CmbTableName.Text
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("LocationX") + 1).Text = 50
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("LocationY") + 1).Text = 10
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("SizeHeight") + 1).Text = 20
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("SizeWidth") + 1).Text = 10
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("Tabindex") + 1).Text = _Activerowno
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("OrderNo") + 1).Text = _Activerowno
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("InputType") + 1).Text = "Normal"
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("VISIBLE") + 1).Text = "Y"
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("TEXTALIGN") + 1).Text = "L"
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("SAVEYN") + 1).Text = "Y"
                            'Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1).Text = "NO"
                            Dim row As Integer = _Activerowno
                            Dim col As Integer = Detail_DataTableGrid.Columns.IndexOf("USEMASTER") + 1

                            Dim val As String = Grid1.Cell(row, col).Text

                            ' Clean value (remove spaces)
                            val = val.Trim().ToUpper()

                            If val = "YES" Then
                                Grid1.Cell(row, col).Text = "YES"
                            Else
                                Grid1.Cell(row, col).Text = "NO"
                            End If
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("READONLY") + 1).Text = "N"
                            Grid1.Cell(_Activerowno, Detail_DataTableGrid.Columns.IndexOf("FormDesignType") + 1).Text = "Grid Detail Design"

                            Grid1.Rows = Grid1.Rows + 1
                            _Activerowno = _Activerowno + 1
                        End If
                    Next
                    Grid1.Focus()
                End If
            End If
            Pnlview.Visible = False
        ElseIf e.KeyCode = Keys.Escape Then
            Pnlview.Visible = False
        End If
    End Sub

#End Region



#Region "Button Click"
    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        _ClearTex()
        Change_Grid_Data = True
        TabControl1.Enabled = True
        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            _FrmLoad = False
            Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated()
            Dim TblTmp As New DataTable
            Dim Last_Entry_No As Integer = 1
            sqL = Str_Qry
            sql_connect_slect1()
            If DefaltSoftTable.Rows.Count > 0 Then
                If IsDBNull(DefaltSoftTable.Rows(0).Item("FormID")) Then DefaltSoftTable.Rows(0).Item("FormID") = 1
                Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("FormID")) + 1
            End If
            Txt_FormId.Text = Last_Entry_No
            Txt_FormId.Focus()
            Txt_FormId.Select()
        End If

    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick

        _FORMMODE = "EDIT"
        TabControl1.Enabled = True
        Dim View_Filter_Condition = ""
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated()
        Dim Last_Entry_No As Integer = 1
        sqL = Str_Qry
        sql_connect_slect1()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("FormID"))
        End If
        Txt_FormId.Text = Last_Entry_No
        Txt_FormId.Focus()
        Txt_FormId.Select()
        Ctl_BookName.Focus()

        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        Change_Grid_Data = True
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        _FrmLoad = True
        TabControl1.Enabled = True
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        Dim Last_Entry_No As Integer = 1
        Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated()
        sqL = Str_Qry
        sql_connect_slect1()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("FormID"))
        End If
        Txt_FormId.Text = Last_Entry_No

        Txt_FormId.Focus()
        Txt_FormId.Select()

        If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
            Call Delete_Entry()
        End If
        If Txt_FormId.Text <> "" Then
            Txt_FormId.Visible = True
            Txt_FormId.Focus()
            Txt_FormId.Text = Last_Entry_No + 1
            _ClearTex()
            Call Ctrl_Visible_True(Me.Controls)
            Clear_Grid(GrdItem, 2)
            Clear_Grid(Grid1, 2)

            '_FORMMODE = "DELETE"
        Else
            MsgBox("No Record Found")

        End If
        'UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("Load")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
        _FrmLoad = False
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        _ClearTex()
        TabControl1.Enabled = True
        Call Ctrl_Visible_True(Me.Controls)
        Clear_Grid(GrdItem, 2)
        Clear_Grid(Grid1, 2)
        If _FORMMODE = "EDIT" AndAlso Val(Txt_FormId.Text) > 1 Then
            Txt_FormId.Text = Val(Txt_FormId.Text) - 1
        End If
        Ctl_BookName.Text = ""
        Ctl_BookName.Focus()
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        _ClearTex()
        TabControl1.Enabled = True
        Call Ctrl_Visible_True(Me.Controls)
        Clear_Grid(GrdItem, 2)
        Clear_Grid(Grid1, 2)
        If _FORMMODE = "EDIT" AndAlso Val(Txt_FormId.Text) >= 1 Then
            Txt_FormId.Text = Val(Txt_FormId.Text) + 1
            Ctl_BookName.Text = ""
            Ctl_BookName.Focus()

            Call Ctrl_Visible_True(Me.Controls)
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        End If

    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        _FrmLoad = False
        Fill_Grid_Records_Into_DataTables()
        Dim Array_Opening(0, 4) As String
        Dim Pcs_Row_No As Integer = 0
        If _BookCode <> "" Then
            sqL = "DELETE FROM " & _DatabaseTableNameItem & " WHERE FormID='" & Txt_FormId.Text & "' and Bookcode='" & _BookCode & "'"
        Else
            sqL = "DELETE FROM " & _DatabaseTableNameItem & " WHERE FormID='" & Txt_FormId.Text & "'"
        End If

        sql_Data_Save_Delete_Update1()


        griditemDetailsSaveQuery(Array_Opening)
        For I = 0 To UBound(Array_Opening)
            If Array_Opening(I, 4) <> "" Then
                strQuery = Array_Opening(I, 4)
                sqL = strQuery.ToString

                sql_Data_Save_Delete_Update1()
                Pcs_Row_No = Pcs_Row_No + 1
            End If
        Next



        Detail_Fill_Grid_Records_Into_DataTables()
        Detail_griditemDetailsSaveQuery(Array_Opening)
        For I = 0 To UBound(Array_Opening)
            If Array_Opening(I, 4) <> "" Then
                strQuery = Array_Opening(I, 4)
                sqL = strQuery.ToString
                'sql_Data_Save_Delete_Update()
                sql_Data_Save_Delete_Update1()
                Pcs_Row_No = Pcs_Row_No + 1
            End If
        Next


        Interaction.MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")
        ObjCls_General.Blank_Object(Me)
        GrdItem.BoldFixedCell = False
        Clear_Grid(GrdItem, 2)
        Grid1.BoldFixedCell = False
        Clear_Grid(Grid1, 2)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub

    Private Sub UC_Buttons1_CloseClick() Handles UC_Buttons1.CloseClick
        If _FORMMODE = "" Then
            Me.Close()
        End If
        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FORMMODE = "VIEW"
        _FORMMODE = "VIEW"

    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"

    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"
    End Sub

    Private Function _checkForm()
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT B.BookName,B.Bookcode ")
            .Append(" FROM " & _DatabaseTableNameItem & " ")
            .Append(" left Join " & _DataBaseFileName & ".dbo.MstBook as B ")
            .Append(" on " & _DatabaseTableNameItem & ".Bookcode COLLATE Latin1_General_CI_AS=B.Bookcode")
            .Append(" where 1=1 ")
            .Append(" AND  FormId='" & Txt_FormId.Text & "'")
            .Append(" AND  FormDesignType='HEADER DESIGN' ")
            .Append(" group by  ")
            .Append(" B.BookName,B.Bookcode ")
        End With
        sqL = _strQuery.ToString
        Dim tblTmp As New DataTable
        sql_connect_slect1()
        Dim _Tmptbla As New DataTable
        _Tmptbla = DefaltSoftTable.Copy
        Return _Tmptbla
    End Function


    Private Sub Ctl_BookName_KeyDown(sender As Object, e As KeyEventArgs) Handles Ctl_BookName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            BOOK_BHEWAR = ""
            If _FORMMODE = "EDIT" AndAlso Txt_FormId.Text > "" Then
                Dim View_Filter_Condition As String = ""
                Dim _Tmptbla As New DataTable
                _Tmptbla = _checkForm()
                _BookCode = ""
                If _Tmptbla IsNot Nothing AndAlso _Tmptbla.Rows.Count > 0 Then
                    If Not IsDBNull(_Tmptbla.Rows(0)("BookName")) AndAlso _Tmptbla.Rows(0)("BookName").ToString().Trim() <> "" Then
                        For Each dr As DataRow In _Tmptbla.Rows
                            _BookCode &= "'" & dr("BookCode").ToString() & "',"
                        Next

                        If _BookCode <> "" Then
                            _BookCode = _BookCode.TrimEnd(","c)
                        End If
                        BOOK_CATGER = " A.BookCode in(" & _BookCode & ")"
                        BOOK_BHEWAR = "chq_printing"
                        obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
                        If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                            Ctl_BookName.Text = MULTY_SELECTION_COLOUM_1_DATA
                            Ctl_BookName.ReadOnly = True
                            _BookCode = MULTY_SELECTION_COLOUM_3_DATA
                            Ctl_Managebybook.Focus()
                        End If
                    Else
                        BOOK_CATGER = ""
                    End If
                End If
                LoadFormDesignAfteredit(_BookCode)
            Else
                BOOK_CATGER = ""
                BOOK_BHEWAR = "BOOKMODIFY"
                If Ctl_Managebybook.Text = "YES" Then
                    obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
                    If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                        Ctl_BookName.Text = MULTY_SELECTION_COLOUM_1_DATA
                        Ctl_BookName.ReadOnly = True
                        _BookCode = MULTY_SELECTION_COLOUM_3_DATA
                        'Ctl_Managebybook.Focus()
                        Txt_mainFormSize.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Ctl_ImpformId_KeyDown(sender As Object, e As KeyEventArgs) Handles Ctl_ImpformId.KeyDown
        If Ctl_ImpformId.Text <> "" Then
            Change_Grid_Data = True
            _FORMMODE = "ADD"
            _FrmLoad = False
            Call Ctrl_Visible_True(Me.Controls)
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
            Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated()
            Dim Last_Entry_No As Integer = 1
            sqL = Str_Qry
            sql_connect_slect1()
            If DefaltSoftTable.Rows.Count > 0 Then
                Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("FormID"))
            End If
        End If
        If e.KeyCode = Keys.Enter AndAlso _FORMMODE = "ADD" Then
            LoadFormDesign()
        End If
    End Sub

    Private Sub Txt_ShortCutKey_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ShortCutKey.KeyDown
        If e.KeyCode = Keys.Enter Then
            GrdItem.Focus()
            GrdItem.Select()
        End If

    End Sub

    Private Sub Ctl_Managebybook_TextChanged(sender As Object, e As EventArgs) Handles Ctl_Managebybook.TextChanged

        If Ctl_Managebybook.Text = "YES" Then
            Ctl_BookName.Focus()
        End If
    End Sub


#End Region
End Class