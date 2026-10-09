Imports System.Text
Imports DevExpress.XtraGrid
Imports FlexCell
Imports Microsoft.VisualBasic.CompilerServices
Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Image
Imports System.Security.Cryptography
Imports TaxProGST.JsonModels.GetProfileJson
Imports iTextSharp.text.pdf.events.IndexEvents

Friend Class PrintJobCardEntry

    Private obj_Party_Selection As New Multi_Selection_Master
#Region "FORM LOAD"

    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Coral
    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function
    Public Sub New()
        InitializeComponent()
        Me.GetAllControls(Me).OfType(Of Button)().ToList() _
          .ForEach(Sub(b)
                       b.Tag = Tuple.Create(b.ForeColor, b.BackColor)
                       AddHandler b.GotFocus, AddressOf b_GotFocus
                       AddHandler b.LostFocus, AddressOf b_LostFocus
                   End Sub)
    End Sub
    Private Sub b_LostFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, Button)
        Dim colors = DirectCast(b.Tag, Tuple(Of Color, Color))
        b.ForeColor = colors.Item1
        b.BackColor = colors.Item2
    End Sub
    Private Sub b_GotFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, Button)
        b.ForeColor = focusedForeColor
        b.BackColor = focusedBackColor
    End Sub


#End Region
#Region "Variable for grid bill"
    Private Frm_Closing_By_Close_Btn As Boolean = False
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
#End Region

#Region "GRID GENERAL VARIABLE"
    Private _griditemLastColNo As Integer = 0
    Private AlterKey_ID As String
    Private _FrmLoad = False
    Private griditem_Table_ColNames() As String

    Private Grid_Table_ColNames() As String
    Private _FindColIndex As Integer = 0
    Private _ColTotal As Double = 0
    Private _KeyFieldName As String = "BOOKVNO"
    'Private _TblName As String = "TrnProcessDyeingPlan"
    Private _DatabaseTableNameItem = "TrnPrinting_JobCardIssue"
    Private _KeyFieldValue As String = ""
    Private _AutoIDField As String = "SRNO"
    Private _RecordsKeyFieldName As String = "ID"

    Private _FocusFields() As String
    'Private _DataTablegriditem As New DataTable
    Private _DefaultColOfGrid As Integer = 0
    Private _GridRowNo As Integer = 0
    Private _ReturnColNumber As Integer = -1
    Private _ActivatedColName As String = ""
    Private _ActivatedColName_Out As String = ""
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
    Private WithEvents txtDeleviryCode As New TextBox
    Private WithEvents txtIamgePath As New TextBox
    Private WithEvents HEADERITEMCODE As New TextBox
    Private WithEvents txtTr_code As New TextBox
    Private WithEvents txtDespatch_code As New TextBox
    Private WithEvents txtDespatchGodown_code As New TextBox


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
    Private _ITEMBOOKVNO As String = ""
    Private _ITEMDESC As String = ""

    Private _ItmBillNo As String = ""
    Private _ItmBillRate As String = ""
    Private _ItmBillPartyName As String = ""
    Private _ItmBillCaseNo As String = ""
    Private _GridItemMaxRow As Integer = 2
    Private _DefaultColOfgriditem As Integer = 0
    Private _DefaultColOfgridbsun As Integer = 0

    Private _DataTablegriditem As New DataTable
    Private _BookVNo As String = ""

    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtAlter_Name As New TextBox
    Private WithEvents txtCityCode As New TextBox
    Private WithEvents txtAgentCode As New TextBox
    Private WithEvents txtAccount_Code As New TextBox
    Private WithEvents txtShadeCode As New TextBox
    Private WithEvents txtItemCode As New TextBox
    Private WithEvents txtDyeingBookvno As New TextBox
    Private WithEvents Txt_Shadecode As New TextBox
    Private WithEvents Txt_ProfileCode As New TextBox

    Private _griditemRowNo As Integer = 0
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private SRNO_Item As Integer = 1
    Private _LastCorrectRow_Item As Integer = 0
    Private _LastCorrectRow_Sundry As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private INNER_OUTER As String = "INNER"
    Private _FormMode As String = ""



    Private _TransctionNo As Integer = 0


    Private _BookTrType As String = "PR-DY"
    Private _BookCode As String = "PRDY-000000001"

    'Private Opp_BookTrtype As String = "FN-PD"
    'Private Opp_BookCode As String = "0001-000000762"


    Private Org_Finish_Rcpt_Tbl_Name As String = "TrnPrinting_JobCardIssue"

#End Region

#Region "Variable for griditem Item "
    Private _headerColNames As New StringBuilder
    Private _griditemColNames As New StringBuilder
    Private _griditemColType As New StringBuilder
    Private _griditemColValidate As New StringBuilder
    Private _griditemCol_FocusByPass As New StringBuilder

    Private _FielditemDefaultValues As New StringBuilder
    Private _FielditemHeader As New StringBuilder
    Private _FielditemHeaderAlignment As New StringBuilder
    Private _FielditemNotRequiredForSave As New StringBuilder
    Private _FielditemNotVisibile As New StringBuilder
    Private _FielditemWidthSet As New StringBuilder
    Private _FielditemLocked As New StringBuilder
    Private _FielditemMasking As New StringBuilder
    Private _FielditemAlignMent As New StringBuilder

    '------------ Extra Fields ------------------------------
    Private _ExtraFieldDataTable As New StringBuilder
    Private _ExtraField_Values_DataTable As New StringBuilder

    Private _ExtraFieldOthers As New StringBuilder
    Private _ExtraField_Values_Others As New StringBuilder

    Private _FieldNameSameValueCopy As New StringBuilder
    Private _FieldNameForTotal As New StringBuilder
#End Region
#Region "grid Coloum"

    Private Sub definegridColName()
        _griditemColNames = New StringBuilder
        With _griditemColNames
            .Append("EntryNo")
            .Append(",BookTrtype")
            .Append(",BookVno")
            .Append(",BookCode")
            .Append(",ChallanNo")
            .Append(",ChallanDate")
            .Append(",AccountCode")
            .Append(",HeaderRemark")
            .Append(",SrNo")
            .Append(",FabricItemName")
            .Append(",Fabric_ItemCode")
            .Append(",DESIGNSTATUS")
            .Append(",Flag")
            .Append(",Process_Beamlotno")
            .Append(",Fabric_ShadeCode")
            .Append(",PIECENO")
            .Append(",FD_PD")
            .Append(",GMtr")
            .Append(",Weight")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE")
            .Append(",GreyMode") ' PROFILE CODE -REMARK MASTER
            .Append(",detailremark")
            .Append(",Grey_Desp_Pcs_ID")
            .Append(",PROCESSCODE")
            .Append(",FACTORYCODE")
            .Append(",FINISH_REMARK_CODE")
            .Append(",SELVCODE")
            .Append(",FABRIC_DESIGNCODE")
            .Append(",IDP")
            .Append(",Sales_Challan_No")
            '.Append(",IMAGE_1") ' IMAGE PATH
            .Append(",LoomCode")
            .Append(",BeamNo")
            .Append(",LRNO")
            .Append(",VEHICLENO")
            .Append(",OP1") ' IMAGE PATH
            .Append(",MODIFYENTRY") '
            .Append(",BALENO") 'pieceno
        End With

        _griditemColType = New StringBuilder
        With _griditemColType
            .Append("GMtr:N")
            .Append(",Weight:N")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:N")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:N")

        End With


        _griditemColValidate = New StringBuilder
        With _griditemColValidate
        End With


        _griditemCol_FocusByPass = New StringBuilder
        With _griditemCol_FocusByPass
        End With


        _FielditemHeader = New StringBuilder
        With _FielditemHeader
            .Append("SrNo:Sr No")
            .Append(",FabricItemName:Item Name")
            .Append(",DESIGNSTATUS:Design Name")
            .Append(",PIECENO:Piece No")
            .Append(",GMtr:Qty")
            .Append(",Weight:Pcs")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:Pro Qty")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:Pro Pcs")
            .Append(",detailremark:Remark")
            .Append(",FD_PD:Change Des.")
        End With


        _FielditemHeaderAlignment = New StringBuilder
        With _FielditemHeaderAlignment
            .Append("SrNo:L")
            .Append(",PIECENO:L")
            .Append(",FD_PD:L")
            .Append(",FabricItemName:L")
            .Append(",DESIGNSTATUS:L")
            .Append(",GMtr:R")
            .Append(",Weight:R")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:R")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:R")
            .Append(",detailremark:L")
        End With


        _FielditemAlignMent = New StringBuilder
        With _FielditemAlignMent
            .Append("SrNo:L")
            .Append(",PIECENO:L")
            .Append(",FD_PD:L")
            .Append(",FabricItemName:L")
            .Append(",DESIGNSTATUS:L")
            .Append(",GMtr:R")
            .Append(",Weight:R")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:R")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:R")
            .Append(",detailremark:L")
        End With


        _FielditemNotVisibile = New StringBuilder
        With _FielditemNotVisibile
            .Append("PIECENO:Y")
            .Append(",SrNo:Y")
            .Append(",GMtr:Y")
            .Append(",Weight:Y")
            .Append(",Fabric_ShadeCode:N")
            .Append(",GreyMode:N")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:Y")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:Y")
            .Append(",detailremark:Y")
            .Append(",Grey_Desp_Pcs_ID:N")
            .Append(",EntryNo:N")
            .Append(",BookTrtype:N")
            .Append(",BookVno:N")
            .Append(",BookCode:N")
            .Append(",ChallanNo:N")
            .Append(",ChallanDate:N")
            .Append(",AccountCode:N")
            .Append(",HeaderRemark:N")
            .Append(",Fabric_ItemCode:N")
            .Append(",Flag:N")
            .Append(",Process_Beamlotno:N")
            .Append(",PROCESSCODE:N")
            .Append(",FACTORYCODE:N")
            .Append(",FINISH_REMARK_CODE:N")
            .Append(",SELVCODE:N")
            .Append(",FABRIC_DESIGNCODE:N")
            .Append(",IDP:N")
            .Append(",IMAGE_1:N")
            .Append(",Sales_Challan_No:N")
            .Append(",FabricItemName:Y")
            .Append(",DESIGNSTATUS:Y")
            .Append(",LoomCode:N")
            .Append(",BeamNo:N")
            .Append(",LRNO:N")
            .Append(",VEHICLENO:N")
            .Append(",OP1:N")
            .Append(",MODIFYENTRY:N")
            .Append(",BALENO:N")
        End With


        _FielditemNotRequiredForSave = New StringBuilder
        With _FielditemNotRequiredForSave
            .Append("FabricItemName:N,")
            .Append("MODIFYENTRY:N")
        End With

        _FielditemWidthSet = New StringBuilder
        With _FielditemWidthSet
            .Append("SrNo:4")
            .Append(",PIECENO:12")
            .Append(",FabricItemName:15")
            .Append(",DESIGNSTATUS:20")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:8")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:5")
            .Append(",GMtr:8")
            .Append(",FD_PD:10")
            .Append(",Weight:5")
            .Append(",detailremark:12")
        End With


        _FielditemDefaultValues = New StringBuilder
        With _FielditemDefaultValues
            .Append("GMtr:0")
            .Append(",Weight:0")
            .Append(",MTR_DESP_TO_PH_BY_OWN_PROD:0")
            .Append(",MTR_DESP_TO_PH_BY_GREY_PURCHASE:0")
        End With


        _FielditemMasking = New StringBuilder
        With _FielditemMasking
            .Append("GMtr:NO-2,")
            .Append("MTR_DESP_TO_PH_BY_OWN_PROD:NO-2,")
            .Append("MTR_DESP_TO_PH_BY_GREY_PURCHASE:NO-0,")
            .Append("Weight:NO-0")
        End With

        _FielditemLocked = New StringBuilder
        With _FielditemLocked
            .Append("FD_PD:Y")
            .Append(",GMtr:Y")
            .Append(",FabricItemName:Y")
            .Append(",DESIGNSTATUS:Y")
            .Append(",PIECENO:Y")
        End With

        Me.griditem_Table_ColNames = Me._griditemColNames.ToString().ToUpper().Split(New Char() {","c})

    End Sub

    Private Sub GenerateTableitem(ByRef griditemTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(griditemTable, _griditemColNames.ToString.ToUpper, "NO", _griditemColType.ToString)
        grdObj.ExtendLastCol = True
        _griditemLastColNo = griditemTable.Columns.Count
        grdObj.Cols = griditemTable.Columns.Count + 1
        grdObj.Rows = _GridItemMaxRow
    End Sub

    Private Sub gridFormatting(ByRef griditemTable As DataTable, ByRef gridbsunTable As DataTable, ByRef grdObj As FlexCell.Grid, ByRef grdObjbsun As FlexCell.Grid)
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)

        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "VISIBLE", _FielditemNotVisibile.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "WIDTH", _FielditemWidthSet.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "HEADER", _FielditemHeader.ToString)
        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "LOCK", _FielditemLocked.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "MASK", _FielditemMasking.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "ALIGNMENT", _FielditemAlignMent.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(griditemTable, grdObj, "HALIGNMENT", _FielditemHeaderAlignment.ToString.ToUpper)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub
    Private Sub Set_Grid_Focus_To_Default_Field()
        GrdItem.Locked = True
        _DefaultColOfgriditem = _DataTablegriditem.Columns.IndexOf("SRNO") + 1
        GrdItem.Cell(1, _DefaultColOfgriditem).SetFocus()
        Fill_Serial_No()
        GrdItem.Locked = False
    End Sub
    Private Sub Fill_Serial_No()
        Dim flag As Boolean = Operators.CompareString(Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, Me._DataTablegriditem.Columns.IndexOf("SRNO") + 1).Text, "", False) = 0
        If flag Then
            Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, Me._DataTablegriditem.Columns.IndexOf("SRNO") + 1).Text = Conversions.ToString(Me.GrdItem.ActiveCell.Row)
        End If

    End Sub

#End Region



    Private Sub ReadyMadeGodownTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)

        If e.KeyCode = Keys.Delete And _FrmLoad = False Then
            Dim Txt_Box_Name As String = _STRTRNOBJECT.ToString.ToUpper
            If Txt_Box_Name = "TXTPROCESSNAME" Or Txt_Box_Name = "TXTDPROCESSNAME" Then
                SendKeys.Send("{BKSP}")
            End If
        End If

        If e.KeyCode = Keys.Escape Then

            If PNL_Stk.Visible = True Then
                PNL_Stk.Visible = False
                GrdItem.Focus()
                Exit Sub
            End If

            If PNL_View.Visible = True Then
                PNL_View.Visible = False
                Form_Ctrl_Visibility("LOAD")
                btnView.Focus()
                Exit Sub
            End If

            _FrmLoad = True
            If _FormMode = "" Then
                Me.Close()
                Me.Dispose(True)
                LEDGER_ENTER_DISPLAY_FROM = ""
            Else
                Select Case _STRTRNOBJECT
                    Case "CMBSEEK"
                        PNL_View.Visible = False
                        _FrmLoad = True
                        _FormMode = ""
                        Old_Date = txtBillDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtBillDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Form_Ctrl_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Case "TXT_FROM"
                        PNL_View.Visible = False
                        _FrmLoad = True
                        _FormMode = ""
                        ObjCls_General.Blank_Object(Me)
                        setDatesForReports(txt_From, txt_To)
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Form_Ctrl_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Case "TXT_TO"
                        PNL_View.Visible = False
                        _FrmLoad = True
                        _FormMode = ""
                        ObjCls_General.Blank_Object(Me)
                        setDatesForReports(txt_From, txt_To)
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Form_Ctrl_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Case "BTN_VIEW_OK"
                        PNL_View.Visible = False
                        _FrmLoad = True
                        _FormMode = ""
                        Old_Date = txtBillDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtBillDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Form_Ctrl_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Case "BTN_VIEW_PRINT"
                        PNL_View.Visible = False
                        _FrmLoad = True
                        _FormMode = ""
                        Old_Date = txtBillDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtBillDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Form_Ctrl_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Case "GRD_VIEW"
                        'cmbSeek.Focus()
                        'cmbSeek.Select()
                    Case "GRDITEM"
                        GrdItem.Cell(1, _DataTablegriditem.Columns.IndexOf("SRNO") + 1).SetFocus()
                        _FrmLoad = True
                        Total_For_Grid_Item_Fields()
                        txtBillDate.Focus()
                    Case "TXTCHALLANDATE"
                        _FrmLoad = True
                        txtBillDate.Text = ObjCls_General.GetTodayDate_British
                        _FormMode = ""
                        Old_Date = txtBillDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtBillDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        _KeyFieldValue = 0
                        Call Form_Ctrl_Visibility("LOAD")
                        Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        Label_Value_Nil_Rest()
                        _FrmLoad = False
                    Case Else
                        _FrmLoad = True
                        _FormMode = ""
                        Old_Date = txtBillDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtBillDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Form_Ctrl_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                End Select
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If _STRTRNOBJECT = "GRDITEM" Then
                'Call Show_Calculator_With_Grid(GrdItem, Me)
            ElseIf _STRTRNOBJECT = "GRDVIEW" Then
                'Call Show_Calculator_With_Grid(GrdItem, Me)
            Else
                'Call Show_Calculator_Without_Grid(Me)
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    _FrmLoad = True
                    Total_For_Grid_Item_Fields()
                    GrdItem.Cell(1, _DataTablegriditem.Columns.IndexOf("SRNO") + 1).SetFocus()
                    'If Val(lbl_Tot_Mtr_Weight.Text) = 0 Then
                    '	MsgBox("Blank Piece Detail, Can't Save", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    '	Exit Sub
                    'Else
                    _FrmLoad = True
                    Total_For_Grid_Item_Fields()
                    GrdItem.Cell(1, _DataTablegriditem.Columns.IndexOf("SRNO") + 1).SetFocus()
                    btnSave.Focus()
                    btnSave.Select()
                    'End If
                Case "BTNSAVE"
                    txtBillDate.Focus()
                Case Else
                    If txtEntryNo.Text = 0 Then
                        txtEntryNo.Focus()
                    ElseIf txtBillDate.Text = "  /  /    " Then
                        txtBillDate.Focus()
                    Else
                        _FrmLoad = True
                        GrdItem.Cell(1, _DataTablegriditem.Columns.IndexOf("SRNO") + 1).SetFocus()
                        GrdItem.Focus()
                        GrdItem.Select()
                    End If
            End Select
        ElseIf e.KeyCode = Keys.F3 Then
            'Select Case _STRTRNOBJECT
            '    Case "GRDITEM"
            '        GrdItem.Range(GrdItem.ActiveCell.Row, 0, GrdItem.ActiveCell.Row, GrdItem.Cols - 1).ClearAll()
            '        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("GMtr") + 1)).Text = ""
            '        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("Weight") + 1)).Text = ""
            'End Select
        ElseIf e.KeyCode = Keys.PageUp Then
            If _FormMode = "MODIFY" Or _FormMode = "EDIT" And Val(txtEntryNo.Text) > 1 Then
                txtEntryNo.Text = Val(txtEntryNo.Text) - 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, Org_Finish_Rcpt_Tbl_Name)
            End If
        ElseIf e.KeyCode = Keys.PageDown Then
            If _FormMode = "MODIFY" Or _FormMode = "EDIT" Then
                txtEntryNo.Text = Val(txtEntryNo.Text) + 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, Org_Finish_Rcpt_Tbl_Name)
            End If
        End If

    End Sub
    Private Sub Total_For_Grid_Item_Fields()
        Dim Tot_Mtr_Weight As Double = 0
        Dim _Gross_Amt As Double = 0
        Dim _Gst_amt As Double = 0
        Dim _Net_amt As Double = 0
        Dim Pcs As Double = 0

        For i As Integer = 1 To GrdItem.Rows - 1
            'GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("gross_rate") + 1).Text = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) * Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("rate") + 1).Text)
            'GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("taxamount") + 1).Text = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("gross_rate") + 1).Text) * Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("taxper") + 1).Text) / 100
            'GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("amount") + 1).Text = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("gross_rate") + 1).Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("taxamount") + 1).Text)
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).Text)
            If Val(GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).Text) > 0 Then
                Pcs = Pcs + 1
            End If


        Next



        If Tot_Mtr_Weight > 0 Then
            lbl_Tot_Mtr_Weight.Text = Format(Tot_Mtr_Weight, "0.00")
        Else
            lbl_Tot_Mtr_Weight.Text = ""
        End If

        If Pcs > 0 Then
            Lbl_Total_Pcs.Text = Format(Pcs, "0.00")
        Else
            Lbl_Total_Pcs.Text = ""
        End If



    End Sub

#Region "Validate Entry No "
    Private Sub Validate_Entry_No(ByVal Book_Vno As String, ByVal Table_Name As String)
        _TransctionNo = 0

        'sqL = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " WHERE BOOKVNO='" & Book_Vno & "'"
        sqL = "SELECT TOP 1 EntryNo FROM " & Table_Name & " WHERE EntryNo='" & txtEntryNo.Text & "'"
        sql_connect_slect()


        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = Val(DefaltSoftTable.Rows(0).Item(0))
        End If

        If _TransctionNo > 0 Then
            If _FormMode = "ADD" Then
                MsgBox("Entry No Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
            ElseIf _FormMode = "MODIFY" Or _FormMode = "EDIT" Then
                _FrmLoad = True
                Call ALTER_FORM(Book_Vno)
                btnSave.Enabled = True
                txtBillDate.Focus()
                _DefaultColOfGrid = _DataTablegriditem.Columns.IndexOf("SRNO") + 1
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

                'Change_Grid_Data = True
                GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                _FrmLoad = False
                txtBillDate.Focus()
                txtBillDate.Select()
            ElseIf _FormMode = "DELETE" Then
                _FrmLoad = True
                Call ALTER_FORM(Book_Vno)
                If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Entry_SQL()
                End If
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                Form_Ctrl_Visibility("LOAD")
                If Val(txtEntryNo.Text) > 0 Then
                    Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Else
                    btnAdd.Focus()
                End If
                _FormMode = ""
                _FrmLoad = False
            End If
        Else
            If _FormMode = "MODIFY" Or _FormMode = "EDIT" Or _FormMode = "DELETE" Then
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                txtEntryNo.Visible = True
                MsgBox("Entry No " + Trim(txtEntryNo.Text) + " Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
            End If
        End If
    End Sub
#End Region

#Region "Entry Delete System "


    Private Sub _deleteEntry()

        '_strQuery = New StringBuilder
        'With _strQuery
        '	.Append("UPDATE TrnGreyDesp_Process SET  ")
        '	.Append(" EntryNo =0 ")
        '	.Append(", Process_Entrydate ='' ")
        '	.Append(", Process_DyeingPlnNo ='' ")
        '	.Append(", Process_Dyeing_Bookvno ='' ")
        '	.Append(", Process_Beamlotno ='' ")
        '	.Append(", Process_ShadeCode ='' ")
        '	.Append(", Process_ShadeType ='' ")
        '	.Append(", Process_HeaderRemark ='' ")
        '	.Append(", Process_PcsIdSelect ='' ")
        '	.Append(", Process_DetailRemark ='' ")
        '	.Append(" WHERE  Process_EntryNo = '" & txtEntryNo.Text & "'")

        'End With
        'sqL = _strQuery.ToString
        'sql_Data_Save_Delete_Update()


        sqL = " DELETE FROM " & Org_Finish_Rcpt_Tbl_Name & " WHERE BOOKCODE='" & _BookCode & "' AND ENTRYNO=" & Val(txtEntryNo.Text) & ""
        sql_Data_Save_Delete_Update()



    End Sub


    Private Sub Delete_Entry_SQL()


        _FrmLoad = True
        Dim affected As Integer = 0
        Dim I As Integer = 0
        Dim _LastID As Integer = 0
        Dim Opp_Bookvno As String = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)


        Try
            _deleteEntry()


            'strQuery = " DELETE FROM " & Org_Finish_Rcpt_Tbl_Name & " WHERE BOOKTRTYPE='" & _BookTrType & "' AND ENTRYNO=" & txtEntryNo.Text & ""
            'sqL = strQuery
            'sql_Data_Save_Delete_Update()

            'strQuery = " DELETE FROM " & Org_Finish_Rcpt_Tbl_Name & " WHERE BOOKTRTYPE='" & _BookTrType & "' AND ENTRYNO=" & txtEntryNo.Text & ""
            'sqL = strQuery
            'sql_Data_Save_Delete_Update()



            _KeyFieldValue = 0
            _FormMode = ""
            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Old_Date = txtBillDate.Text
            ObjCls_General.Blank_Object(Me)
            txtBillDate.Text = Old_Date
        Catch ex As Exception
            MsgBox("Error While Delete Entry")
        Finally
            cmd = Nothing
        End Try

        _FrmLoad = False
    End Sub
#End Region

#Region "Alter"

    Private Sub ALTER_FORM(strKeyID As String)
        '_IRNNO = ""
        '_FrmLoad = True
        Dim tblTmp As New DataTable
        _BookVNo = strKeyID

        '-------------  Load Data Into grid Item-------------
        strQuery = getAlter_Form_Query_Item_Details(strKeyID)
        tblTmp = New DataTable
        sqL = strQuery
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then
            tblFormValues.Rows.Clear()
            GrdItem.AutoRedraw = False

            txtBillDate.Text = tblTmp.Rows(0)("BDATE").ToString
            txtAccount_Code.Text = tblTmp.Rows(0)("ProcessCode").ToString
            txtBookCode.Text = tblTmp.Rows(0)("BOOKCODE").ToString
            txtHeader_Remark.Text = tblTmp.Rows(0)("HEADERREMARK").ToString
            Txt_Shadecode.Text = tblTmp.Rows(0)("Process_ShadeCode").ToString
            txtDyeingBookvno.Text = tblTmp.Rows(0)("Process_Dyeing_Bookvno").ToString
            txtItemCode.Text = tblTmp.Rows(0)("fabric_ItemCode").ToString
            txtPartyName.Text = tblTmp.Rows(0)("ACCOUNTNAME").ToString
            Txt_EntrySelection.Text = tblTmp.Rows(0)("LRNO").ToString
            Txt_ProgNo.Text = tblTmp.Rows(0)("Sales_Challan_No").ToString
            Txt_Per.Text = tblTmp.Rows(0)("LoomCode").ToString
            Txt_Profile.Text = tblTmp.Rows(0)("BeamNo").ToString
            Txt_Status.Text = tblTmp.Rows(0)("VEHICLENO").ToString
            Txt_Profile.Text = tblTmp.Rows(0)("PROFILE").ToString
            Txt_ProfileCode.Text = tblTmp.Rows(0)("GreyMode").ToString


            SRNO_Item = Val(tblTmp.Compute("MAX(SRNO)", "").ToString)
            _LastCorrectRow_Item = tblTmp.Rows.Count
            lbl_Tot_Mtr_Weight.Text = tblTmp.Compute("SUM(GMtr)", "").ToString
            GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
            _griditemRowNo = 0
            GrdItem.AutoRedraw = False
            Fill_Records(tblTmp, griditem_Table_ColNames, GrdItem, _griditemRowNo, True, "", False)
            GrdItem.AutoRedraw = True
            GrdItem.Refresh()

            _LastEntryNo = txtEntryNo.Text

            Total_For_Grid_Item_Fields()
            Total_For_All_Grid_And_Calculation()
            'Label_Decimal_Setting()

            Fill_Sr_No_Item(GrdItem, _DataTablegriditem)

            '_FrmLoad = False

            Ctrl_Visibility_With_Two_Grid(True, Me.Controls, GrdItem, GrdItem)

            btnSave.Enabled = True
            txtBillDate.Focus()
        Else
            MsgBox("Error While Reading Records : ", MsgBoxStyle.Critical, "Soft-Tex PRO")
            Exit Sub
        End If
    End Sub

    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            'If Val(GrdObj.Cell(i, Data_Table.Columns.IndexOf("AMOUNT") + 1).Text) > 0 Then
            'If Val(GrdObj.Cell(i, Data_Table.Columns.IndexOf("No_Of_Beam") + 1).Text) > 0 Then
            GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
            'End If
        Next
    End Sub
    'Private Function getAlter_Form_Query_Header(strKeyID As String) As String
    '	Return EntryData_Invoice_Entry_Get_Alter_Form_Query_Header(strKeyID)
    'End Function
    Private Function getAlter_Form_Query_Item_Details(strKeyID As String) As String
        Return EntryData_Get_Invoice_Alter_Form_Query_Item_Details(Me._BookVNo, Val(txtEntryNo.Text))
    End Function
    Private Sub Total_For_All_Grid_And_Calculation()

    End Sub

    Private Function EntryData_Get_Invoice_Alter_Form_Query_Item_Details(_BookVNo As String, ByVal entry_no As String) As String
        If entry_no = Nothing Then entry_no = _BookVNo

        Dim strQuery As New StringBuilder
        With strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT (A.ChallanDate,'dd/MM/yyyy') as BDATE, ")
            .Append(" B.ITENNAME AS ITEMNAME , ")
            .Append(" B.ITENNAME AS FabricItemName , ")
            .Append(" C.ACCOUNTNAME  ")
            .Append(" ,D.SHADE AS SHADENO  ")
            .Append(" ,D.SHADE AS SHADENAME  ")
            .Append(" ,a.GMtr as GMtr ")
            .Append(" ,a.Weight as Weight ")
            .Append(" ,a.Grey_Desp_Pcs_ID ")
            .Append(" ,a.DetailRemark as detailremark ")
            .Append(" ,a.HeaderRemark AS HEADERREMARK ")
            .Append(" ,E.RemarkName AS PROFILE ")
            .Append(" ,'EDIT' AS MODIFYENTRY ")
            .Append(" FROM TrnPrinting_JobCardIssue A, ")
            .Append(" MstFabricItem B , MstMasterAccount C, ")
            .Append(" Mst_Fabric_Shade AS D ")
            .Append(" ,MstRemark AS E ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.Fabric_ShadeCode=D.ID ")
            .Append(" AND A.Fabric_ItemCode=B.ID ")
            .Append(" AND A.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" AND A.GreyMode=E.RemarkCode ")
            '.Append(" AND A.BOOKVNO='" & _BookVNo & "' ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & "  ")
            .Append(" AND A.ENTRYNO='" & entry_no & "'" & "  ")
            .Append(" ORDER BY SRNO ")
        End With
        Dim StrQry As String = strQuery.ToString
        Return strQuery.ToString
    End Function
#End Region

#Region "BUTTON CLICK"
    Private Sub Set_Focus_Last_Clicked_Btn(Last_Focused_Name As String)
        Dim flag As Boolean = Operators.CompareString(Me.Last_Focused_Btn, "ADD", False) = 0
        If flag Then
            Me.btnAdd.Focus()
        Else
            flag = (Operators.CompareString(Me.Last_Focused_Btn, "MODIFY", False) = 0 Or Operators.CompareString(Me.Last_Focused_Btn, "EDIT", False) = 0)
            If flag Then
                Me.btnEdit.Focus()
            Else
                flag = (Operators.CompareString(Me.Last_Focused_Btn, "DELETE", False) = 0)
                If flag Then
                    Me.btnDelete.Focus()
                Else
                    flag = (Operators.CompareString(Me.Last_Focused_Btn, "VIEW", False) = 0)
                    If flag Then
                        Me.btnView.Focus()
                    Else
                        flag = (Operators.CompareString(Me.Last_Focused_Btn, "PRINT", False) = 0)
                        If flag Then
                            Me.btnPrint.Focus()
                        Else
                            flag = (Operators.CompareString(Me.Last_Focused_Btn, "SAVE", False) = 0)
                            If flag Then
                                Me.btnAdd.Focus()
                            Else
                                Me.btnAdd.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Label_Value_Nil_Rest()
        Me.lbl_Tot_Mtr_Weight.Text = ""
        Me.Lbl_Total_Pcs.Text = ""
        'Me.lbl_Total_Gross_Amt.Text = ""
        'Me.lbl_Round_Off.Text = ""
        'Me.lbl_Net_Amount_Figure.Text = ""
        'Me.lbl_Total_TaxAble.Text = ""
        'Me.lbl_Total_CGST_Amt.Text = ""
        'Me.lbl_Total_SGST_Amt.Text = ""
        'Me.lbl_Total_IGST_Amt.Text = ""
    End Sub
    Private Sub _EnabledtXTbOX()
        Me.txtBillDate.Enabled = True
        Me.txtEntryNo.Enabled = True
        txtHeader_Remark.Enabled = True
    End Sub
    Private Sub _ImageLoad()
        'PictureBox1.Image = Textile.My.Resources.Resources._243e7ac1649e2548fa69fecbe3d412c0_copy

    End Sub
    Private Sub Form_Ctrl_Visibility(Visibility_Flag As String)
        txtEntryNo.Enabled = True
        txtBillDate.Enabled = True

        If _FormMode = "ADD" Then
            txtEntryNo.ReadOnly = True
        Else
            txtEntryNo.ReadOnly = False
        End If



        If Grid1.Rows > 1 Then Clear_Grid(Grid1, 1)

        _ImageLoad()
        'Txt_DispatchGodown.Enabled = True
        PNL_Stk.Visible = False
        Dim flag As Boolean = Operators.CompareString(Visibility_Flag.ToString().ToUpper(), "LOAD", False) = 0
        If flag Then
            Me.btnSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnView.Enabled = True
            Me.btnPrint.Enabled = True
            Me._FormMode = ""
            Dim visible_Flag As Boolean = False
            Dim controls As Control.ControlCollection = Me.Controls
            Dim grdItem As Grid = Me.GrdItem
            Dim grid As Grid = Me.GrdItem
            Genral.Ctrl_Visibility_With_Two_Grid(visible_Flag, controls, grdItem, grid)
            'Me.grdBsun = grid
            Me.GrdItem = grdItem
            Me.Label_Value_Nil_Rest()
            'Me.grdBsun.BackColor1 = Color.Transparent
            'Me.grdBsun.BackColor2 = Color.Transparent
            grid = Me.GrdItem
            Genral.Clear_Grid(grid, 2)
            Me.GrdItem = grid



            Me.Set_Grid_Focus_To_Default_Field()
            Me.Set_Focus_Last_Clicked_Btn(Me.Last_Focused_Btn)
            btnAdd.Focus()
        Else
            flag = (Operators.CompareString(Visibility_Flag.ToString().ToUpper(), "BTNADD", False) = 0)
            If flag Then
                _EnabledtXTbOX()

                Dim visible_Flag As Boolean = True
                Dim controls As Control.ControlCollection = Me.Controls
                Dim grdItem As Grid = Me.GrdItem
                Genral.Ctrl_Visibility_With_Two_Grid(visible_Flag, controls, grdItem, grdItem)

                Me.btnSave.Enabled = True
                Me.btnAdd.Enabled = False
                Me.btnEdit.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnView.Enabled = False
                Me.btnPrint.Enabled = False

            Else
                flag = (Operators.CompareString(Visibility_Flag.ToString().ToUpper(), "BTNEDIT", False) = 0 Or Operators.CompareString(Visibility_Flag.ToString().ToUpper(), "BTNDELETE", False) = 0)
                If flag Then
                    _EnabledtXTbOX()
                    Dim visible_Flag As Boolean = True
                    Dim controls As Control.ControlCollection = Me.Controls
                    Dim grdItem As Grid = Me.GrdItem
                    Genral.Ctrl_Visibility_With_Two_Grid(visible_Flag, controls, grdItem, grdItem)


                    Me.btnSave.Enabled = True
                    Me.btnAdd.Enabled = False
                    Me.btnEdit.Enabled = False
                    Me.btnDelete.Enabled = False
                    Me.btnView.Enabled = False
                    Me.btnPrint.Enabled = False
                Else
                    flag = (Operators.CompareString(Visibility_Flag.ToString().ToUpper(), "BTNVIEW", False) = 0)
                    If flag Then
                        Me.btnSave.Enabled = False
                        Me.btnAdd.Enabled = False
                        Me.btnEdit.Enabled = False
                        Me.btnDelete.Enabled = False
                        Me.btnView.Enabled = False
                        Me.btnPrint.Enabled = False
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub _TxtClear()
        'txtBillDate.Text = ""
        'txtAccountName.Text = ""
        txtHeader_Remark.Text = ""
        'Txt_ShadeNo.Text = ""
        Txt_Shadecode.Text = ""
        'Txt_ShadeType.Text = ""
        'Txt_DyenibgPlanNo.Text = ""
        txtDyeingBookvno.Text = ""
        'Txt_ItemName.Text = ""
        txtItemCode.Text = ""
        'Txt_processbeamLotNo.Text = ""
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '_IRNNO = ""
        'Me.AlreadyFinPosted = ""

        ObjCls_General.Blank_Object(Me)
        _TxtClear()
        Dim _userwrits As String = obj_Party_Selection._userWrits("ADD")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        _EnabledtXTbOX()
        Me._FormMode = "ADD"
        Me.Last_Focused_Btn = "ADD"
        Me.txtBookCode.Text = Me.Book_Code
        Me.Form_Ctrl_Visibility("BTNADD")


        Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated(_BookCode)
        Dim TblTmp As New DataTable
        Dim Last_Entry_No As Integer = 1
        sqL = Str_Qry
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            If IsDBNull(DefaltSoftTable.Rows(0).Item("ENTRYNO")) Then DefaltSoftTable.Rows(0).Item("ENTRYNO") = 1
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO")) + 1
        End If
        txtEntryNo.Text = Last_Entry_No
        txtBillDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        GrdItem.Focus()
        GrdItem.Select()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        Txt_Status.Text = "PRODUCTION"

        txtEntryNo.Focus()
        txtEntryNo.Select()


    End Sub
    Public Function EntryData_Invoice_Entry_txtBookName_Validated(ByVal _BookCode As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.EntryNo AS ENTRYNO")
            .Append(" FROM TrnPrinting_JobCardIssue A ")
            .Append(" WHERE 1=1 ")
            '.Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            .Append(" ORDER BY A.EntryNo DESC ")
        End With
        Return _strQuery.ToString
    End Function
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click


        ObjCls_General.Blank_Object(Me)
        _TxtClear()
        Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Me.AlreadyFinPosted = ""
        Me.Edit_From_View = False
        'Me._FrmLoad = False
        Me._FormMode = "EDIT"
        Me.Last_Focused_Btn = "EDIT"
        'Me.txtBookName.Visible = True
        Me.Form_Ctrl_Visibility("BTNEDIT")
        Dim obj As Object = Me
        ObjCls_General.Blank_Object(obj, "")

        Me.txtBookCode.Text = Me.Book_Code
        Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated(_BookCode)
        Dim TblTmp As New DataTable
        Dim Last_Entry_No As Integer = 0
        sqL = Str_Qry
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            If IsDBNull(DefaltSoftTable.Rows(0).Item("ENTRYNO")) Then DefaltSoftTable.Rows(0).Item("ENTRYNO") = 1
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        End If

        txtEntryNo.Text = Last_Entry_No

        txtBillDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        GrdItem.Focus()
        GrdItem.Select()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        txtEntryNo.Focus()
        txtEntryNo.Select()

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ObjCls_General.Blank_Object(Me)
        _TxtClear()
        Dim _userwrits As String = obj_Party_Selection._userWrits("DELETE")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'Me.AlreadyFinPosted = ""
        Me.Edit_From_View = False
        'Me._FrmLoad = False
        Me.Last_Focused_Btn = "DELETE"
        Me._FormMode = "DELETE"
        Me.Form_Ctrl_Visibility("BTNDELETE")
        'Me.txtBookName.Visible = True
        'Dim ObjCls_General As cls_FrmHandle = ObjCls_General
        Dim obj As Object = Me
        ObjCls_General.Blank_Object(obj, "")

        Me.txtBookCode.Text = Me.Book_Code
        Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated(_BookCode)
        Dim TblTmp As New DataTable
        Dim Last_Entry_No As Integer = 0
        sqL = Str_Qry
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO")).ToString
        End If

        txtEntryNo.Text = Last_Entry_No

        txtBillDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        GrdItem.Focus()
        GrdItem.Select()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        txtEntryNo.Focus()
        txtEntryNo.Select()

    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        'Me._FrmLoad = False
        Me._FormMode = "VIEW"
        Dim _userwrits As String = obj_Party_Selection._userWrits("VIEW")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Me.Last_Focused_Btn = "VIEW"
        'Me.txtBookName.Visible = True
        Me.Form_Ctrl_Visibility("BTNVIEW")
        'Me.txtBookName.Text = Me.Book_Name
        Me.txtBookCode.Text = Me.Book_Code
        Txt_EntryType.Text = "SUMMERY"
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Grid_View_Display()

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        _SaveStrat()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        JobCardPrinting.ShowDialog()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim flag As Boolean = Operators.CompareString(Me._FormMode, "VIEW", False) = 0
        If flag Then
            'Me._FrmLoad = True
            Me._FormMode = ""
            Me.txtBillDate.Text = ObjCls_General.GetTodayDate_British()
            'Me.txtLrDate.Text = ObjCls_General.GetTodayDate_British()
            'Dim ObjCls_General As cls_FrmHandle = ObjCls_General
            Dim obj As Object = Me
            ObjCls_General.Blank_Object(obj, "")
            Dim grid As Grid = Me.GrdItem
            Genral.Clear_Grid(grid, Me._GridItemMaxRow)
            Me.GrdItem = grid

            Dim visible_Flag As Boolean = False
            Dim controls As Control.ControlCollection = Me.Controls
            grid = Me.GrdItem
            Genral.Ctrl_Visibility_With_Two_Grid(visible_Flag, controls, grid, grid)
            Me.GrdItem = grid
            Me.Form_Ctrl_Visibility("LOAD")
            Me.Set_Focus_Last_Clicked_Btn(Me.Last_Focused_Btn)
            Me._FormMode = ""
        Else
            CLOSE_MNU_LOAD()
        End If
    End Sub
    Private Sub CLOSE_MNU_LOAD()
        If LEDGER_ENTER_DISPLAY_FROM = "BeamLotDyeingProg" Then
            LEDGER_ENTER_DISPLAY_FROM = ""
            Ledger_display_n.last_grid_select_()
            Close()
            Me.Dispose(True)
        ElseIf LEDGER_ENTER_DISPLAY_FROM = "BUTTON_CALL" Then
            Close()
            Me.Dispose(True)
        Else
            Me.Close()
            Me.Dispose(True)
            LEDGER_ENTER_DISPLAY_FROM = ""
        End If
    End Sub
    Public Sub _SaveStrat()
        If _FormMode = "EDIT" Then
            Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
            If _userwrits = "N" Then
                MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        Generate_Date_For_DataBase(txtBillDate)

        Me.Save_Invoice()
        Me._FormMode = ""

    End Sub
    Private Sub Save_Invoice()

        Generate_Date_For_DataBase(txtBillDate)


        'If txtS_P_AC_Code.Text = "" Then txtS_P_AC_Code.Text = "0000-000000001"
        If txtAcOfCode.Text = "" Then txtAcOfCode.Text = "0000-000000001"
        If txtAccount_Code.Text = "" Then txtAccount_Code.Text = "0000-000000001"
        If txtDespatch_code.Text = "" Then txtDespatch_code.Text = "0000-000000001"
        If txtTr_code.Text = "" Then txtTr_code.Text = "0000-000000001"
        If Txt_Shadecode.Text = "" Then Txt_Shadecode.Text = "0000-000000001"
        If Txt_ProfileCode.Text = "" Then Txt_ProfileCode.Text = "0000-000000001"
        'If txtIns_Comp_Code.Text = "" Then txtIns_Comp_Code.Text = "0000-000000001"


        Dim flag As Boolean = Operators.CompareString(Me._FormMode, "", False) = 0
        If flag Then
            Me._FormMode = Me.Last_Focused_Btn
            flag = (Operators.CompareString(Me.Last_Focused_Btn, "MODIFY", False) = 0)
            If flag Then
                Me._FormMode = "EDIT"
            End If
        End If



        Try

            Fill_Grid_Records_Into_DataTables()

            SAVE_INTO_DATABASE_SQL()





            obj_Party_Selection.Outstanding_Blank_Field_fill()
            Interaction.MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")

            Dim grid As Grid = Me.GrdItem
            Genral.Clear_Grid(grid, 2)
            Me.GrdItem = grid
            Genral.Clear_Grid(grid, 2)
            Me.Label_Value_Nil_Rest()
            ObjCls_General.Blank_Object(Me)
            Me.Form_Ctrl_Visibility("LOAD")
            Me.Set_Focus_Last_Clicked_Btn(Me.Last_Focused_Btn)
            Me._FormMode = ""
            'End If
        Catch ex As Exception
            Interaction.MsgBox(ex.Message, MsgBoxStyle.Information, "Soft-Tex PRO")
        End Try

    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------


        _DataTablegriditem.Rows.Clear()
        For i As Int16 = 1 To GrdItem.Rows - 1
            If Val(GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).Text) <> 0 And GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("DESIGNSTATUS") + 1).Text > "" Then
                FieldDr = _DataTablegriditem.NewRow
                For j As Int16 = 1 To GrdItem.Cols - 1
                    If FieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FieldDr(j - 1) = Val(GrdItem.Cell(i, j).Text)
                    Else
                        FieldDr(j - 1) = (GrdItem.Cell(i, j).Text)
                    End If
                Next
                _DataTablegriditem.Rows.Add(FieldDr)
            End If
        Next
        '----------------------------------------
    End Sub
    Private Function SAVE_INTO_DATABASE_SQL() As Integer

        Dim text As String = ""
        Dim num As Integer = 0

        Dim result As Integer

        Generate_Date_For_DataBase(txtBillDate)


        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)
        Dim Opp_BookVno As String = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)

        Dim strQuery As String = ""
        Dim affected As Integer = 0
        Dim I As Integer = 0

        Try
            '---------------- Delete Previous Bill Sundry ---------------------------------- '

            _deleteEntry()

            Dim Array_Opening(0, 4) As String
            Dim Pcs_Row_No As Integer = 0
            griditemDetailsSaveQuery(Array_Opening)
            For I = 0 To UBound(Array_Opening)
                If Array_Opening(I, 4) <> "" Then
                    strQuery = Array_Opening(I, 4)
                    sqL = strQuery.ToString
                    sql_Data_Save_Delete_Update()
                    'User_Log_Post(Org_Grecy_Desp_Tbl_Name, "GREY_DESP_PCS_ID", _DataTableGrid(Pcs_Row_No)("GREY_DESP_PCS_ID").ToString, _DataTableGrid(Pcs_Row_No)("PIECENO").ToString, _UserID, strQuery.ToString)
                    Pcs_Row_No = Pcs_Row_No + 1
                End If
            Next

            Dim _FolderName As String = "Image"
            Dim strServerName = _FolderFilePath(_FolderName)
            'Dim strServerName = _ImageFilePath()
            Dim folder As String = strServerName
            If Not System.IO.Directory.Exists(folder) Then
                System.IO.Directory.CreateDirectory(folder)
            End If




            'For Each DR As DataRow In _DataTablegriditem.Select
            '    If DR("OP1").ToString > "" Then ' IMAGEPATH
            '        Dim fileName = DR("DESIGNSTATUS").ToString
            '        Dim sSource = ""
            '        Dim sTarget = ""
            '        'If _FormMode = "EDIT" Then
            '        sTarget = strServerName & fileName
            '        'Else
            '        'sTarget = Lbl_DesignPath.Text & "\" & fileName
            '        'End If

            '        Dim LocX = 0 'x cord. of where crop starts
            '        Dim LocY = 0 'y  cord. of where crop starts
            '        Dim CropW = 1080 'Crop width
            '        Dim CropH = 768 'Crop height
            '        Dim CropRect As New Rectangle(LocX, LocY, CropW, CropH)
            '        PictureBox1.ImageLocation = sTarget
            '        PictureBox1.Load()
            '        Dim OriginalImage = PictureBox1.Image
            '        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
            '        'System.IO.File.Delete(strServerName & fileName)
            '        Using grp = Graphics.FromImage(CropImage)
            '            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            '            'CropImage.Save(strServerName & fileName)
            '            CropImage.Save("D:\Mahaveer\Textile\textile\bin\debug\Image2\" & fileName)
            '        End Using
            '    End If
            'Next








            For Each DR As DataRow In _DataTablegriditem.Select
                If DR("OP1").ToString > "" And DR("MODIFYENTRY").ToString = "" Then ' IMAGEPATH
                    Dim fileName = DR("DESIGNSTATUS").ToString
                    Dim sSource = ""
                    Dim sTarget = ""
                    'If _FormMode = "EDIT" Then
                    '    sTarget = strServerName & fileName
                    'Else
                    sTarget = Lbl_DesignPath.Text & "\" & fileName
                    'End If

                    Dim LocX = 0 'x cord. of where crop starts
                    Dim LocY = 0 'y  cord. of where crop starts
                    Dim CropW = 1080 'Crop width
                    Dim CropH = 768 'Crop height
                    Dim CropRect As New Rectangle(LocX, LocY, CropW, CropH)
                    PictureBox1.ImageLocation = sTarget
                    PictureBox1.Load()
                    Dim OriginalImage = PictureBox1.Image
                    Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
                    System.IO.File.Delete(strServerName & fileName)
                    Using grp = Graphics.FromImage(CropImage)
                        grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                        CropImage.Save(strServerName & fileName)
                        'CropImage.Save("D:\Mahaveer\Textile\textile\bin\debug\Image2\" & fileName)
                    End Using
                    'File.Copy(sSource, sTarget, True)
                End If
            Next




            Return affected
        Catch ex As Exception
        MsgBox("new error comes :" & ex.Message & "-" & strQuery)
        Throw ex
        Finally
        End Try
    End Function



    Private Function griditemDetailsSaveQuery(ByRef arr_object As String(,)) As String
        Try

            Dim array As String(,) = New String(Me._DataTablegriditem.Rows.Count + 1 - 1, 4) {}


            Dim text As String = "MTR_DESP_TO_PH_BY_OWN_PROD>0  "
            Me._ExtraFieldDataTable = New StringBuilder
            Dim extraFieldDataTable As StringBuilder = Me._ExtraFieldDataTable
            extraFieldDataTable.Append("ENTRYNO,")
            extraFieldDataTable.Append("BookTrtype,")
            extraFieldDataTable.Append("BOOKVNO,")
            extraFieldDataTable.Append("BookCode,")
            extraFieldDataTable.Append("ChallanDate,")
            extraFieldDataTable.Append("FACTORYCODE,")
            extraFieldDataTable.Append("FINISH_REMARK_CODE,")
            extraFieldDataTable.Append("SELVCODE,")
            extraFieldDataTable.Append("FABRIC_DESIGNCODE,")
            extraFieldDataTable.Append("IDP,")
            extraFieldDataTable.Append("AccountCode,")
            extraFieldDataTable.Append("LRNO,")
            extraFieldDataTable.Append("Sales_Challan_No,")
            extraFieldDataTable.Append("LoomCode,")
            extraFieldDataTable.Append("BeamNo,")
            extraFieldDataTable.Append("VEHICLENO,")
            extraFieldDataTable.Append("GreyMode,")
            extraFieldDataTable.Append("HeaderRemark")

            Me._ExtraField_Values_DataTable = New StringBuilder
            Dim extraField_Values_DataTable As StringBuilder = Me._ExtraField_Values_DataTable
            extraField_Values_DataTable.Append(Me.txtEntryNo.Text + ",")
            extraField_Values_DataTable.Append(Me._BookTrType + ",")
            extraField_Values_DataTable.Append(Me._BookVNo + ",")
            extraField_Values_DataTable.Append(Me._BookCode + ",")
            extraField_Values_DataTable.Append(Me.txtBillDate.Date_for_Database + ",")
            extraField_Values_DataTable.Append("0000-000000001,")
            extraField_Values_DataTable.Append("0000-000000001,")
            extraField_Values_DataTable.Append("0000-000000001,")
            extraField_Values_DataTable.Append("0000-000000001,")
            extraField_Values_DataTable.Append("YES,")
            extraField_Values_DataTable.Append(txtAccount_Code.Text + ",")
            extraField_Values_DataTable.Append(Txt_EntrySelection.Text + ",")
            extraField_Values_DataTable.Append(Txt_ProgNo.Text + ",")
            extraField_Values_DataTable.Append(Txt_Per.Text + ",")
            extraField_Values_DataTable.Append(Txt_Profile.Text + ",")
            extraField_Values_DataTable.Append(Txt_Status.Text + ",")
            extraField_Values_DataTable.Append(Txt_ProfileCode.Text + ",")
            extraField_Values_DataTable.Append(Me.txtHeader_Remark.Text)




            'Dim ObjCls_General As cls_FrmHandle = ObjCls_General
            Dim text2 As String = Conversions.ToString(Me._DatabaseTableNameItem)
            Dim text3 As String = "FORCELY_ADDED"
            Dim text4 As String = text
            Dim text5 As String = Me._FielditemNotRequiredForSave.ToString().ToUpper()
            Dim queryArray As String = ObjCls_General.GetQueryArray(text2, text3, text4, array, Me._DataTablegriditem, text5, Me._RecordsKeyFieldName, "", "", "N", Me._ExtraFieldDataTable.ToString().ToUpper(), Me._ExtraField_Values_DataTable.ToString().ToUpper(), Me._ExtraFieldOthers.ToString().ToUpper(), Me._ExtraField_Values_Others.ToString().ToUpper(), Me._FielditemDefaultValues.ToString().ToUpper())
            Dim result As String = queryArray + ";"
            arr_object = array
            Return result
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Function
    Public Shared Function ImageToBinary(ByVal imagePath As String) As Byte()
        Dim fileStream As FileStream = New FileStream(imagePath, FileMode.Open, FileAccess.Read)
        Dim buffer As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(buffer, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return buffer
    End Function
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub

    Private Sub ReadyMadeGodownTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PNL_Stk.Width = 603
        PNL_Stk.Height = 523
        PNL_Stk.Location = New Point(499, 5)



        PNL_View.Width = 1066
        PNL_View.Height = 584
        PNL_View.Location = New Point(3, 0)


        Me.Location = New Point(0, 0)
        Dim flag As Boolean

        Me.definegridColName()
        Dim grid As Grid = Me.GrdItem
        Me.GenerateTableitem(Me._DataTablegriditem, grid)
        Me.GrdItem = grid
        Me.gridFormatting(Me._DataTablegriditem, Me._DataTablegriditem, GrdItem, GrdItem)

        Me.GrdItem.Enabled = False

        Me.GrdItem.Column(0).Visible = False
        Me.GrdItem.Row(0).Height = 25S
        Continure_For_Inovice = True

        Me.Label_Value_Nil_Rest()
        flag = (Screen_Width < 1024 Or Screen_Height < 768)
        If flag Then
            Me.Refresh()
            Me.CenterToParent()
        End If


        If _isCallerByOther = True Then
            Me.btnAdd.Enabled = False
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            Me.btnView.Enabled = False
            Me.btnSave.Visible = True
            Me.btnSave.Enabled = True
            Me.btnPrint.Enabled = False
            Me.Form_Ctrl_Visibility("BTNEDIT")
            Me.ALTER_FORM(Me._KeyFieldValue)
            Me.GrdItem.Enabled = True
            'Me.grdBsun.Enabled = True
            Me._FormMode = "EDIT"
            Me.txtBillDate.Focus()
            Me.txtBillDate.[Select]()
        Else
            Me.Form_Ctrl_Visibility("LOAD")
            Me.btnAdd.Focus()
        End If


        If _BookCodeDataAudit = "Book Rewrite" Then
            Save_Invoice()
            LEDGER_ENTER_DISPLAY_FROM = ""
            _BookCodeDataAudit = ""
            Me.Close()
            Me.Dispose(True)
        End If

        'Me.old_Me_text = Me.Text

        Me.btnAdd.Focus()

    End Sub
#End Region

#Region "GRID ITEM EVENTS "
    Private Sub grditem_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        '_FrmLoad = False
    End Sub
    Private Sub grdItem_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        'If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))

        'GrdItem.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub grdItem_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        'If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
    End Sub
    Private Sub grdItem_EnterRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.EnterRowEventArgs) Handles GrdItem.EnterRow
        'If _FrmLoad = True Then Exit Sub
        '_FrmLoad = True
        Fill_Sr_No_Item(GrdItem, _DataTablegriditem)
        'GrdItem.ActiveCell.BackColor = Color.Transparent
        '_FrmLoad = False
    End Sub
    Private Sub grdItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        'GrdItem.ActiveCell.BackColor = Color.Transparent
        '_FrmLoad = False
    End Sub
    Private Sub grdItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.LostFocus
        'If _FrmLoad = True Then Exit Sub
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub grdItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Validated
        'If _FrmLoad = True Then Exit Sub
        GrdItem.Refresh()
    End Sub
    Private Sub grdItem_LeaveRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveRowEventArgs) Handles GrdItem.LeaveRow
        'If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row
    End Sub

    Private Sub grditem_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GrdItem.KeyPress
        'If _FrmLoad = True Then Exit Sub
        Dim Grp_By_ID As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("PROD_GROUP_BY_ID") + 1).Text
    End Sub

    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        'If _FrmLoad = True Then Exit Sub
        If e.KeyCode = Keys.Escape Then Exit Sub

        Dim Current_Row As Integer = GrdItem.ActiveCell.Row

        If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FABRIC_ITEMCODE") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FABRIC_ITEMCODE") + 1)).Text = "0000-000000001"
        If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FABRIC_SHADECODE") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FABRIC_SHADECODE") + 1)).Text = "0000-000000001"
        'If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("SHADENAME") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("SHADENAME") + 1)).Text = Txt_ShadeNo.Text
        If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("Fabric_ShadeCode") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("Fabric_ShadeCode") + 1)).Text = "0000-000000001"


        If _ActivatedColName = "ITEMNAME" Then
        ElseIf _ActivatedColName = "PIECENO" Then
            'If e.KeyCode = Keys.Enter Then
            '    If GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("PIECENO") + 1)).Text = "" Then
            '        Disp_Grd_Stk()
            '    End If
            'End If

        ElseIf _ActivatedColName = "MTR_DESP_TO_PH_BY_OWN_PROD" Then
            If GrdItem.Cell(GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "NO" Then
                GrdItem.Cell(GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1)).Locked = True
            Else
                GrdItem.Cell(GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1)).Locked = False
            End If
            If e.KeyCode = Keys.Enter Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "YES" Then
                    BREAK_LINE()
                End If
            End If
        ElseIf _ActivatedColName = "FD_PD" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "" Then
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "NO"
                ElseIf GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "NO" Then
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "YES"
                ElseIf GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "YES" Then
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("FD_PD") + 1)).Text = "NO"
                End If
            End If
        ElseIf _ActivatedColName = "DETAILREMARK" Then
            If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                'GrdItem.Rows = GrdItem.Rows + 1
                Fill_Sr_No_Item(GrdItem, _DataTablegriditem)
                'Dim Col_No As Integer = _DataTablegriditem.Columns.IndexOf("SRNO") + 1
                'Dim Col_No As Integer = _DataTablegriditem.Columns.IndexOf("No_Of_Beam")
                'GrdItem.Range(GrdItem.ActiveCell.Row, Col_No, GrdItem.ActiveCell.Row, Col_No).SelectCells()
            End If
        End If
        Total_For_Grid_Item_Fields()
    End Sub
    Private Sub BREAK_LINE()
        Dim CHALLAN_MTR As Double = Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("GMTR") + 1)).Text)
        Dim _breakMtr As Double = Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1)).Text)
        Dim _NewMtr As Double = 0
        '.Append(",GMtr:Qty")
        '.Append(",Weight:Pcs")
        '.Append(",MTR_DESP_TO_PH_BY_OWN_PROD:Pro Qty")


        If CHALLAN_MTR <> _breakMtr Then

            _NewMtr = CHALLAN_MTR - _breakMtr
            Dim _INDEX As Integer = 0
            Dim iRow = GrdItem.ActiveCell.Row = GrdItem.Rows - 1

            If iRow > GrdItem.ActiveCell.Row = GrdItem.Rows - 1 Then
                GrdItem.Rows = GrdItem.Rows + 1
                _INDEX = GrdItem.Rows - 1
            Else
                GrdItem.InsertRow(GrdItem.ActiveCell.Row + 1, 1)
                _INDEX = GrdItem.ActiveCell.Row + 1
            End If


            Dim Grey_Desp_Pcs_ID = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("Grey_Desp_Pcs_ID") + 1).Text
            Dim PIECENO = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("PIECENO") + 1).Text
            Dim GMtr = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text
            Dim MTR_DESP_TO_PH_BY_OWN_PROD = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).Text
            Dim FabricItemName = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("FabricItemName") + 1).Text
            Dim Weight = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("Weight") + 1).Text
            Dim MTR_DESP_TO_PH_BY_GREY_PURCHASE = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_GREY_PURCHASE") + 1).Text
            Dim FD_PD = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("FD_PD") + 1).Text
            Dim fabric_ItemCode = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("fabric_ItemCode") + 1).Text
            Dim PROCESSCODE = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("PROCESSCODE") + 1).Text
            Dim Fabric_ShadeCode = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("Fabric_ShadeCode") + 1).Text
            Dim Fabric_DesignCode = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("Fabric_DesignCode") + 1).Text
            Dim MainPcsNo = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("BALENO") + 1).Text



            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text = _breakMtr

            Dim Entered_Pcs_No_Of_Tp = 0
            For i As Integer = 1 To GrdItem.Rows - 1
                If Val(GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text) <> 0 Then
                    If GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("Grey_Desp_Pcs_ID") + 1).Text = Grey_Desp_Pcs_ID Then
                        Entered_Pcs_No_Of_Tp = Entered_Pcs_No_Of_Tp + 1
                    End If
                End If
            Next


            'GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("SrNo") + 1).Text = Grd_Item_Row_No
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("Grey_Desp_Pcs_ID") + 1).Text = Grey_Desp_Pcs_ID
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("PIECENO") + 1).Text = MainPcsNo & "-TP" & (Entered_Pcs_No_Of_Tp + 1).ToString
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text = _NewMtr
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).Text = _NewMtr
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("FabricItemName") + 1).Text = FabricItemName
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("Weight") + 1).Text = 1
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_GREY_PURCHASE") + 1).Text = 1
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("FD_PD") + 1).Text = "NO"
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("fabric_ItemCode") + 1).Text = fabric_ItemCode
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("PROCESSCODE") + 1).Text = PROCESSCODE
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("Fabric_ShadeCode") + 1).Text = Fabric_ShadeCode
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("Fabric_DesignCode") + 1).Text = Fabric_DesignCode
            GrdItem.Cell(_INDEX, _DataTablegriditem.Columns.IndexOf("BALENO") + 1).Text = MainPcsNo


        End If

    End Sub
#End Region

    Private Sub txtEntryNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntryNo.Validated
        'If _FrmLoad = True Then Exit Sub

        Dim Book_Vno As String = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)
        _BookVNo = Book_Vno

        If _FormMode = "ADD" Then
            If Val(txtEntryNo.Text) <= 0 Or txtEntryNo.Text = "" Then
                MsgBox("Invalid Entry No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()

            Else
                Validate_Entry_No(Book_Vno, Org_Finish_Rcpt_Tbl_Name)
                'If Txt_DyenibgPlanNo.Text = "" Then Txt_DyenibgPlanNo.Text = txtEntryNo.Text
                'txtBillDate.Text = txtEntryNo.Text
            End If
        ElseIf _FormMode = "MODIFY" Or _FormMode = "EDIT" Then
            If Val(txtEntryNo.Text) <= 0 Or txtEntryNo.Text = "" Then
                MsgBox("Invalid Entry No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            ElseIf txtBillDate.Text = "0" Then
                Grid_View_Display()
                Exit Sub
            ElseIf Val(txtEntryNo.Text) <> 0 Then
                Validate_Entry_No(Book_Vno, Org_Finish_Rcpt_Tbl_Name)
            End If
        ElseIf _FormMode = "DELETE" Then
            If Val(txtEntryNo.Text) <= 0 Or txtEntryNo.Text = "" Then
                MsgBox("Invalid Entry No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            ElseIf Val(txtEntryNo.Text) <> 0 Then
                Validate_Entry_No(Book_Vno, Org_Finish_Rcpt_Tbl_Name)
            End If
        End If

        'Stk_Calculate()

    End Sub

#Region "View Code "
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        'Dim _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        If e.KeyCode = Keys.Escape Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            Dim _ActBookvno As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Entry No").ToString()
            If _ActBookvno <> "" Then
                txtEntryNo.Text = _ActBookvno
                btnSave.Enabled = True
                btnSave.Visible = True
                PNL_View.Visible = False
                _FormMode = "EDIT"
                'Modify_From_View = True
                ALTER_FORM(_ActBookvno)
                txtEntryNo.Focus()
                txtEntryNo.Select()
                Exit Sub
            End If

        End If
    End Sub
    Private Sub btn_View_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_View_Ok.Click
        Grid_View_Display()
    End Sub
    Private Sub Grid_View_Display()

        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)

        Dim View_Filter_Condition = " AND A.CHALLANDATE>='" & txt_From.Date_for_Database & "' AND A.CHALLANDATE<='" & txt_To.Date_for_Database & "'  "
        Dim View_Order_By = " ORDER BY A.ENTRYNO,A.CHALLANDATE "


        _strQuery = New StringBuilder
        With _strQuery
            If Txt_EntryType.Text = "DETAIL" Then
                .Append(" SELECT  ")
                .Append(" A.entryno AS [Entry No] ")
                .Append(" ,FORMAT (A.ChallanDate,'dd/MM/yyyy') as Date")
                .Append(" ,B.ACCOUNTNAME AS [Party Name]")
                .Append(" ,a.PieceNo as [Piece No] ")
                .Append(" ,a.DESIGNSTATUS as [Design Name] ")
                .Append(" ,1 as Pcs ")
                .Append(" ,a.MTR_DESP_TO_PH_BY_OWN_PROD as [Pro Qty] ")
                .Append(" ,a.DetailRemark as [Remark] ")
                .Append(" FROM TrnPrinting_JobCardIssue A ")
                .Append(" ,MstMasterAccount AS B ")
                .Append(" WHERE 1=1 ")
                .Append(View_Filter_Condition)

                .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
                .Append(" AND A.BOOKCODE='PRDY-000000001' ")
                .Append("  ORDER BY A.ENTRYNO,A.CHALLANDATE ,A.SRNO")
            Else
                .Append(" SELECT  ")
                .Append(" A.entryno AS [Entry No] ")
                .Append(" ,FORMAT (A.ChallanDate,'dd/MM/yyyy') as Date")
                .Append(" ,B.ACCOUNTNAME AS [Party Name]")
                .Append(" ,COUNT(a.PieceNo) as Pcs ")
                .Append(" ,SUM (a.MTR_DESP_TO_PH_BY_OWN_PROD) as [Pro Qty] ")
                .Append(" FROM TrnPrinting_JobCardIssue A ")
                .Append(" ,MstMasterAccount AS B ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BOOKCODE='PRDY-000000001' ")
                .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
                .Append(View_Filter_Condition)

                .Append(" GROUP BY  ")
                .Append(" A.entryno ")
                .Append(",A.ChallanDate ,B.ACCOUNTNAME ")
                .Append(View_Order_By)
            End If

        End With
        sqL = _strQuery.ToString
        sql_connect_slect()

        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then

            FirstStage.Columns.Clear()
            GridControl1.DataSource = tblTmp


            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)


            FirstStage.GroupRowHeight = 30
            FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near


            FirstStage.Columns("Pcs").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Pro Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            FirstStage.Columns("Pcs").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pcs", "{0}"))
            FirstStage.Columns("Pro Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pro Qty", "{0}"))


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
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Pcs", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Pcs")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Pro Qty", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Pro Qty")})

        gridView.Appearance.GroupRow.BackColor = Color.LightGreen

    End Sub

    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles btn_View_Print.Click
        Dim _RptTiltle = " Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Export_Excel.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

#End Region


#Region "Greyt Stock Display System And Related Code "
    Private Function Stk_Calculate(ByVal _filterCode As String)
        Dim Tbl_Stk As New DataTable
        Dim Book_Code_Filter_String As String = ""
        sqL = Get_Process_Stock_Qry_For_Data(Book_Code_Filter_String, _filterCode, _BookVNo, Date_1)
        sql_connect_slect()
        Tbl_Stk = DefaltSoftTable.Copy
        Return Tbl_Stk
    End Function

    Private Sub _StkGridSetting(ByVal Tbl_Stk As DataTable)
        Try

            Dim query_2 = From row In Tbl_Stk
                          Where row.Field(Of String)("AccountCode") = txtAccount_Code.Text
                          Order By row.Field(Of String)("Chl-No"),
                                   row.Field(Of Date)("Chl-Date")
                          Group row By
            ItemName = row.Field(Of String)("Quality"),
            ChlNo = row.Field(Of String)("Chl-No"),
            BOOKVNO = row.Field(Of String)("BOOKVNO"),
            ChlDate = row.Field(Of Date)("Chl-Date"),
            ITEMCODE3 = row.Field(Of String)("GREY_FABRIC_ITEMCODE")
        Into AgentNameGroup = Group
                          Select New With
            {
            Key ChlNo, ChlDate, ItemName,
            .TotalQty = AgentNameGroup.Sum(Function(r) CDec(r("G-Mtrs (Balance)"))),
            ITEMCODE3, BOOKVNO
        }
            Dim _ChlWisTbl = LINQToDataTable(query_2)


            If Grd_Stk.Rows > 1 Then Clear_Grid(Grd_Stk, 2)

            lbl_Seek_Stk.Visible = True
            lbl_Seek_Stk.Text = ""
            lbl_T_Pcs_Stk.Text = ""
            lbl_T_Gmtr_Stk.Text = ""

            If _ChlWisTbl.Rows.Count > 0 Then
                Fill_Grid_With_DataTable(Grd_Stk, _ChlWisTbl)
            Else
                Grd_Stk.Rows = 2
                MsgBox("Stock Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                'txtAccountName.Focus()
                Exit Sub
            End If

            Grd_Stk.Column(5).Visible = False
            Grd_Stk.Column(6).Visible = False

            Grd_Stk.Column(1).Width = 100
            Grd_Stk.Column(2).Width = 100
            Grd_Stk.Column(3).Width = 150
            Grd_Stk.Column(4).Width = 150



            lbl_Seek_Stk.Text = ""
            PNL_Stk.Visible = True
            Grd_Stk.AutoRedraw = True
            PNL_Stk.BringToFront()
            Grd_Stk.Visible = True
            Grd_Stk.Refresh()
            Grd_Stk.Select()
            Grd_Stk.Focus()
            Grd_Stk.Cell(1, 2).SetFocus()
            SendKeys.Send("{DOWN}")
            SendKeys.Send("{UP}")

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        'Disp_Grd_Stk()

        Grd_Stk.Locked = True


    End Sub


    Private Function Get_Process_Stock_Qry_For_Data(ByVal Book_Code_Filter_String As String, ByVal Process_Code As String, ByVal Book_Vno As String, ByVal As_On_Dated As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" Z.GREY_DESP_PCS_ID1 AS Final_Grey_ID, ")
            .Append(" CASE WHEN Z.TOTAL_TP>0 THEN Z.PIECENO+'-TP'+CAST((Z.TOTAL_TP+1) AS VARCHAR) ELSE Z.PIECENO END  AS [Piece No], ")
            .Append(" ROUND(Z.BALMTR,3) AS [G-Mtrs (Balance)], ")
            .Append(" Space(1) as [Flag], ")
            .Append(" E.ITENNAME AS Quality, ")
            .Append(" Z.CHALLANNO AS [Chl-No], ")
            .Append(" (Z.CHALLANDATE) AS [Chl-Date], ")
            .Append(" C.ACCOUNTNAME AS Factory, ")
            .Append(" D.ACCOUNTNAME AS Party, ")
            .Append(" F.Design_Name AS [Design No], ")
            .Append(" G.SHADE AS [Shade No], ")
            .Append(" I.SELVEDGE_NAME AS Selvedge, ")
            .Append(" B.ACCOUNTNAME AS Process,  ")
            .Append(" ROUND(Z.BALMTR,3) AS ORG_BALMTR,")
            .Append(" CASE WHEN Z.TOTAL_TP>0 THEN Z.PIECENO+'-TP'+CAST((Z.TOTAL_TP+1) AS VARCHAR) ELSE Z.PIECENO END  AS ORG_PIECENO, ")
            .Append(" Z.TOTAL_TP AS PREV_TP_TOTAL,")
            .Append(" 0 AS CURRENT_TP_TOTAL,")
            .Append(" Z.FABRIC_ITEMCODE AS GREY_FABRIC_ITEMCODE,")
            .Append(" ROUND(Z.GMTR,3) AS ORG_GMTR,")
            .Append(" E.MAXSHRINK as MAX_SHRINK_PER,")
            .Append(" Z.FABRIC_DESIGNCODE AS DESIGNCODE,")
            .Append(" Z.FABRIC_SHADECODE AS SHADECODE,")
            .Append(" (Z.CHALLANDATE) AS F_CHALLANDATE,  ")
            .Append(" B.ACCOUNTNAME AS PROCESSNAME, C.ACCOUNTNAME AS FACTORYNAME, ")
            .Append(" D.ACCOUNTNAME AS PARTYNAME, E.ITENNAME AS FABRIC_ITEMNAME, E.WTPERMTR AS AVG_WEIGHT,  ")
            .Append(" E.WTVERIANCE AS AVG_WEIGHT_VARIANCE, F.Design_Name AS F_FABRIC_DESIGN_NO,  ")
            .Append(" G.SHADE AS F_FABRIC_SHADE_NO, H.REMARKNAME AS FINISHREMARK, I.SELVEDGE_NAME, ")
            .Append(" CASE WHEN Z.TOTAL_TP>0 THEN round(Z.BALMTR*Z.PCAVGWT,3) ELSE Z.WEIGHT END AS WEIGHT,Z.PCAVGWT ")
            .Append(" ,Z.SELVCODE ")
            .Append(" ,Z.AccountCode ") ' 37
            .Append(" ,Z.Flag ") '38
            .Append(" ,Z.Process_Beamlotno ") '39
            .Append(" ,Z.Sales_Challan_No ") '40
            .Append(" ,Z.BOOKVNO ") '41
            .Append(" FROM ")

            .Append(" ( ")

            .Append(" SELECT A.GREY_DESP_PCS_ID AS GREY_DESP_PCS_ID1, ")
            .Append(" A.PIECENO AS PIECENO,A.CHALLANNO,A.CHALLANDATE, ")
            .Append(" A.GMTR,A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0)+ISNULL(SUM(C.GMTR),0),3) AS BALMTR, ")
            .Append(" ROUND(SUM(B.GMTR),3) AS USED_GMTR, ")
            .Append(" COUNT(B.PIECENO) AS TOTAL_TP,A.FABRIC_ITEMCODE, ")
            .Append(" A.FABRIC_DESIGNCODE,A.FABRIC_SHADECODE,A.PROCESSCODE, ")
            .Append(" A.FACTORYCODE,A.ACCOUNTCODE,A.FINISH_REMARK_CODE, ")
            .Append(" A.SELVCODE,A.WEIGHT,A.PCAVGWT ")
            .Append(" ,A.Flag ")
            .Append(" ,A.Process_Beamlotno ")
            .Append(" ,A.Sales_Challan_No ")
            .Append(" ,A.BOOKVNO ")

            .Append(" FROM TrnPrinting_GreyRec AS A ")
            .Append(" LEFT JOIN TrnPrinting_JobCardIssue  AS B ")
            .Append(" ON (A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
            .Append(" AND B.BOOKVNO<>'" & Book_Vno & "' ")
            .Append(" )")

            .Append(" left JOIN TrnPrinting_GreyRec AS c ")
            .Append(" ON (A.GREY_DESP_PCS_ID=c.Grey_Rcpt_Pcs_ID ")
            .Append(" AND C.BOOKVNO<>'" & Book_Vno & "' ")
            .Append(" )")


            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE IN ('0001-000000106','0001-000000104') ")
            '.Append(" AND ( A.PROCESSCODE='" & Process_Code & "' ")
            .Append(Book_Code_Filter_String)
            .Append(Process_Code)
            '.Append(" AND A.IDP='YES'  ")
            .Append(" GROUP BY A.GREY_DESP_PCS_ID, A.PIECENO, A.GMTR, ")
            .Append(" A.CHALLANNO,A.CHALLANDATE,A.FABRIC_ITEMCODE, ")
            .Append(" A.FABRIC_DESIGNCODE,A.FABRIC_SHADECODE,A.PROCESSCODE, ")
            .Append(" A.FACTORYCODE,A.ACCOUNTCODE,A.FINISH_REMARK_CODE, ")
            .Append(" A.SELVCODE,A.WEIGHT,A.PCAVGWT ")
            .Append(" ,A.Flag ")
            .Append(" ,A.Process_Beamlotno ")
            .Append(" ,A.Sales_Challan_No ")
            .Append(" ,A.BOOKVNO ")

            .Append(" HAVING A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0)+ISNULL(SUM(C.GMTR),0),3)>0 ")

            .Append(" ) ")
            .Append("AS Z ")
            .Append(" LEFT JOIN  MstMasterAccount AS B ON Z.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN   MstMasterAccount AS C ON Z.FACTORYCODE=C.ACCOUNTCODE")
            .Append(" LEFT JOIN   MstMasterAccount AS D ON  Z.ACCOUNTCODE=D.ACCOUNTCODE ")
            .Append(" LEFT JOIN    MSTFABRICITEM AS E ON Z.FABRIC_ITEMCODE=E.ID")
            .Append(" LEFT JOIN   Mst_Fabric_Design AS F ON Z.FABRIC_DESIGNCODE=F.Design_code ")
            .Append(" LEFT JOIN   Mst_Fabric_Shade AS G ON Z.FABRIC_SHADECODE=G.ID ")
            .Append(" LEFT JOIN   MSTREMARK AS H ON  Z.FINISH_REMARK_CODE=H.REMARKCODE ")
            .Append(" LEFT JOIN   Mst_selvedge AS I ON Z.SELVCODE=I.ID")
            .Append(" WHERE 1=1 AND Z.BALMTR>0")
            '.Append(" ORDER BY Z.PIECENO")
            .Append(" ORDER BY ")
            .Append(" (cast((CASE WHEN Z.PIECENO NOT LIKE '%[^0-9]%' THEN Z.PIECENO END) as int)) ")
        End With

        Return _strQuery.ToString
    End Function
    Private Sub Disp_Grd_Stk(Optional ByVal Grd_Stk_Display As Boolean = True, Optional ByVal Stk_For_Grey_Challan As Boolean = False)
        Try


            Dim Total_Rcpt_Gmtr As Double = 0
            Dim Total_Pcs As Integer = 0
            Dim Entered_Pcs_No_Of_Tp As Integer = 0
            Dim Total_Gmtr As Double = 0
            Dim G_Chl_No As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("GREY_CHALLAN_NO") + 1).Text.Trim

            GrdItem.AutoRedraw = False
            Grd_Stk.AutoRedraw = False

            For j As Integer = 1 To Grd_Stk.Rows - 1
                Total_Rcpt_Gmtr = 0
                Entered_Pcs_No_Of_Tp = 0

                For i As Integer = 1 To GrdItem.Rows - 1
                    If Val(GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text) <> 0 Then
                        If GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("Grey_Desp_Pcs_ID") + 1).Text = Grd_Stk.Cell(j, 1).Text Then
                            Total_Rcpt_Gmtr = Total_Rcpt_Gmtr + Val(GrdItem.Cell(i, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text)
                            Entered_Pcs_No_Of_Tp = Entered_Pcs_No_Of_Tp + 1
                        End If
                    End If
                Next

                Grd_Stk.Cell(j, 3).Text = Val(Grd_Stk.Cell(j, 14).Text) - Total_Rcpt_Gmtr

                'If Entered_Pcs_No_Of_Tp > 0 Then
                Grd_Stk.Cell(j, 17).Text = Entered_Pcs_No_Of_Tp
                'End If

                If Entered_Pcs_No_Of_Tp > 0 Then
                    If Val(Grd_Stk.Cell(j, 16).Text) = 0 And Val(Grd_Stk.Cell(j, 17).Text) = 1 Then
                        Grd_Stk.Cell(j, 2).Text = Grd_Stk.Cell(j, 15).Text & "-TP" & (Entered_Pcs_No_Of_Tp + 1).ToString
                    Else
                        Grd_Stk.Cell(j, 2).Text = Mid(Grd_Stk.Cell(j, 2).Text, 1, Len(Grd_Stk.Cell(j, 2).Text) - 1) & (Val(Mid(Grd_Stk.Cell(j, 2).Text, Len(Grd_Stk.Cell(j, 2).Text), 1)) + 1).ToString
                    End If
                Else
                    Grd_Stk.Cell(j, 2).Text = Grd_Stk.Cell(j, 15).Text
                End If

                If Val(Grd_Stk.Cell(j, 3).Text) = 0 Then
                    Grd_Stk.Row(j).Visible = False
                Else
                    If Stk_For_Grey_Challan = True Then
                        If Grd_Stk.Cell(j, 6).Text.Trim = G_Chl_No Then
                            Grd_Stk.Row(j).Visible = True
                            Total_Pcs = Total_Pcs + 1
                            Total_Gmtr = Total_Gmtr + Val(Grd_Stk.Cell(j, 3).Text)
                        Else
                            Grd_Stk.Row(j).Visible = False
                        End If
                    Else
                        Grd_Stk.Row(j).Visible = True
                        Total_Pcs = Total_Pcs + 1
                        Total_Gmtr = Total_Gmtr + Val(Grd_Stk.Cell(j, 3).Text)
                    End If
                End If
            Next

            lbl_T_Pcs_Stk.Text = Total_Pcs.ToString & " Pcs"
            lbl_T_Gmtr_Stk.Text = FormatNumber(Total_Gmtr, 2, TriState.False, TriState.False, TriState.True)

            If Grd_Stk_Display = True Then
                lbl_Seek_Stk.Text = ""
                PNL_Stk.Visible = True
                PNL_Stk.BringToFront()
                Grd_Stk.Visible = True
                Grd_Stk.Select()
                Grd_Stk.Focus()
                Grd_Stk.Cell(1, 2).SetFocus()
                SendKeys.Send("{DOWN}")
                SendKeys.Send("{UP}")
            End If

            GrdItem.AutoRedraw = True
            Grd_Stk.AutoRedraw = True
            Grd_Stk.Refresh()


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Private Sub Grd_Stk_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grd_Stk.KeyDown
        If e.KeyCode = Keys.Enter Then
            'If Pcs_Select_System = "SINGLE" Or Pcs_Select_System.Length = 0 Then
            Stk_Piece_Value_Feed_In_Grid_Item(Grd_Stk.ActiveCell.Row, GrdItem.ActiveCell.Row)

            PNL_Stk.Visible = False
            Txt_ProgNo.Focus()
            Txt_ProgNo.SelectAll()

            'GrdItem.Select()
            'GrdItem.Focus()

            'GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).SetFocus()
            'GrdItem.Range(GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1, GrdItem.ActiveCell.Row, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).SelectCells()
            Exit Sub

        Else
            Dim Col_No As Integer = Grd_Stk.ActiveCell.Col
            Dim oldValue As String = Trim(lbl_Seek_Stk.Text)
            Dim billnovalue As String = Trim(lbl_Seek_Stk.Text)
            Dim keytyped As Integer
            Dim typevalue As String = ""
            keytyped = e.KeyCode
            If e.KeyCode = 48 Then
                keytyped = "0"
                typevalue = "0"
            End If
            If e.KeyCode >= 49 And e.KeyCode <= 57 Then
                keytyped = keytyped - 48
                typevalue = keytyped
            End If
            If keytyped >= 96 And keytyped <= 105 Then
                keytyped = keytyped - 48
                typevalue = Chr(keytyped)
            ElseIf keytyped = 110 Or keytyped = 190 Then
                typevalue = "."
            ElseIf keytyped = 191 Or keytyped = 111 Then
                typevalue = "/"
            ElseIf keytyped = 109 Or keytyped = 189 Then
                typevalue = "-"
            ElseIf keytyped >= 65 And keytyped <= 90 Then
                keytyped = e.KeyCode
                typevalue = Chr(keytyped)
            ElseIf keytyped = 46 Then
                billnovalue = ""
                typevalue = ""
                lbl_Seek_Stk.Text = billnovalue
                If Grd_Stk.Rows > 1 Then Grd_Stk.Range(1, Col_No, 1, Col_No).SelectCells()
                Grd_Stk.Focus()
                Grd_Stk.Select()
                SendKeys.Send("{UP}")
            ElseIf keytyped = 8 Then
                If Len(Trim(billnovalue)) > 1 Then
                    billnovalue = Mid(billnovalue, 1, Len(billnovalue) - 1)
                    typevalue = ""
                    lbl_Seek_Stk.Text = billnovalue
                Else
                    billnovalue = ""
                    typevalue = ""
                    lbl_Seek_Stk.Text = billnovalue
                    If Grd_Stk.Rows > 1 Then Grd_Stk.Range(1, Col_No, 1, Col_No).SelectCells()
                    Grd_Stk.Focus()
                    Grd_Stk.Select()
                    SendKeys.Send("{UP}")
                End If
            End If

            If typevalue <> "" Then
                lbl_Seek_Stk.Text = Trim(billnovalue) + typevalue
                billnovalue = lbl_Seek_Stk.Text
                SeekOutsBills_Stk(billnovalue)
                If FOUND = False Then
                    lbl_Seek_Stk.Text = oldValue
                    billnovalue = oldValue
                Else
                    oldValue = billnovalue
                End If
            End If
        End If
    End Sub
    Private Sub Stk_Piece_Value_Feed_In_Grid_Item(ByVal Grd_Stk_Row_No As Integer, ByVal Grd_Item_Row_No As Integer)
        Try
            Txt_EntrySelection.Text = Grd_Stk.Cell(Grd_Stk_Row_No, 1).Text
            Dim _BOOKVNO = Grd_Stk.Cell(Grd_Stk_Row_No, 6).Text
            Dim _FilterCode As String = " AND A.BOOKVNO= '" & _BOOKVNO & "'"
            Dim TBLSTK As DataTable = Stk_Calculate(_FilterCode)

            Grd_Item_Row_No = 1
            For Each dr As DataRow In TBLSTK.Select
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("SrNo") + 1).Text = Grd_Item_Row_No
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("Grey_Desp_Pcs_ID") + 1).Text = dr("Final_Grey_ID")
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("PIECENO") + 1).Text = dr("PIECE NO").ToString
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("BALENO") + 1).Text = dr("PIECE NO").ToString
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("GMtr") + 1).Text = dr("G-Mtrs (Balance)")
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_OWN_PROD") + 1).Text = dr("G-Mtrs (Balance)")
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("FabricItemName") + 1).Text = dr("Quality").ToString
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("Weight") + 1).Text = 1
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("MTR_DESP_TO_PH_BY_GREY_PURCHASE") + 1).Text = 1
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("FD_PD") + 1).Text = "NO"
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("fabric_ItemCode") + 1).Text = dr("GREY_FABRIC_ITEMCODE").ToString
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("PROCESSCODE") + 1).Text = txtAccount_Code.Text
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("Fabric_ShadeCode") + 1).Text = "0000-000000001"
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("Fabric_DesignCode") + 1).Text = "0000-000000001"
                GrdItem.Cell(Grd_Item_Row_No, _DataTablegriditem.Columns.IndexOf("Fabric_DesignCode") + 1).Text = dr("BOOKVNO").ToString
                GrdItem.Rows = GrdItem.Rows + 1
                Grd_Item_Row_No += 1
            Next
            Total_For_Grid_Item_Fields()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub SeekOutsBills_Stk(ByVal seekvalue As String)
        Dim pname As String, ln As Integer, rws As Integer, cnt As Integer
        Dim Col_No As Integer = Grd_Stk.ActiveCell.Col
        pname = Trim(seekvalue)
        ln = Len(pname)
        rws = Grd_Stk.Rows
        FOUND = False
        'Try

        For cnt = 1 To rws - 1
            If Grd_Stk.Row(cnt).Visible = True Then
                If Mid(Grd_Stk.Cell(cnt, Col_No).Text, 1, ln) = pname Then
                    Grd_Stk.Range(cnt, Grd_Stk.ActiveCell.Col, cnt, Grd_Stk.ActiveCell.Col).SelectCells()
                    FOUND = True
                    Exit For
                End If
            End If
        Next
        If FOUND = False Then
            Beep()
            seekvalue = Mid(pname, 1, ln - 1)
        End If
    End Sub

    Private Sub Grd_Stk_Focus_Set()
        If PNL_Stk.Visible = True Then
            Grd_Stk.Focus()
            Grd_Stk.Select()
        End If
    End Sub
    Private Sub Grd_Stk_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles Grd_Stk.RowColChange
        If Old_Col_No_Stk <> Grd_Stk.ActiveCell.Col Then
            lbl_Seek_Stk.Text = ""
            Old_Col_No_Stk = Grd_Stk.ActiveCell.Col
        End If
    End Sub
    Private Sub txtEntryNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntryNo.GotFocus
        If PNL_Stk.Visible = True Then
            Grd_Stk_Focus_Set()
        Else
            _FrmLoad = False
        End If
    End Sub

    Private Sub GrdItem_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrdItem.MouseClick
        Try


            'Dim _IMG() As Byte
            'Dim _IMAGENAME As String = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("DESIGNSTATUS") + 1)).Text
            'sqL = " SELECT IMAGE_1 FROM TrnPrinting_JobCardIssue WHERE DESIGNSTATUS='" & _IMAGENAME & "' "
            'sql_connect_slect()
            '_IMG = DefaltSoftTable.Rows(0).Item("IMAGE_1")
            'Dim MS As New MemoryStream(_IMG)
            'PictureBox1.Image = System.Drawing.Image.FromStream(MS, False)

            Dim _FolderName As String = "Image"
            Dim strServerName = _FolderFilePath(_FolderName)

            If GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("DESIGNSTATUS") + 1)).Text > "" Then
                PictureBox1.ImageLocation = strServerName & GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("DESIGNSTATUS") + 1)).Text
                PictureBox1.Load()
            Else
                _ImageLoad()
            End If



            If PNL_Stk.Visible = True Then
                PNL_Stk.Visible = False
                Grd_Stk.Focus()
                Grd_Stk.Select()
                SendKeys.Send("{tab}")
                SendKeys.Send("{f1}")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub Btn_DesignLoad_Click(sender As Object, e As EventArgs) Handles Btn_DesignLoad.Click
        FileSelection()
    End Sub

    Private Sub FileSelection()

        FolderBrowserDialog1.ShowDialog()
        Lbl_DesignPath.Text = FolderBrowserDialog1.SelectedPath.ToString


        Dim dt As New DataTable
        dt.Columns.Add("File Name")
        dt.Columns.Add("File Path")

        Dim sn As Integer = 1
        Dim filepath As String() = Directory.GetFiles(Lbl_DesignPath.Text)
        For item As Integer = 0 To filepath.Length - 1
            Dim file As New FileInfo(filepath(item))
            Dim dr As DataRow = dt.NewRow()
            dr("File Name") = file.Name
            dr("File Path") = Lbl_DesignPath.Text
            dt.Rows.Add(dr)
        Next


        Dim dataView1 As New DataView(dt)
        dataView1.Sort = "File Name ASC"
        dt = dataView1.ToTable()


        If Grid1.Rows > 1 Then Clear_Grid(Grid1, 1)

        Grid1.Range(0, 0, Grid1.Rows - 1, Grid1.Cols - 1).DeleteByRow()
        _griditemRowNo = 0
        Grid1.Locked = True
        Grid1.AutoRedraw = False
        Grid1.DataSource = dt
        'Fill_Records(dt, griditem_Table_ColNames, Grid1, _griditemRowNo, True, "", False)
        Grid1.AutoRedraw = True

        Grid1.Column(1).Alignment = FlexCell.AlignmentEnum.LeftGeneral
        Grid1.Column(1).Width = 320
        Grid1.Column(2).Visible = False

        Grid1.Refresh()
        Grid1.Focus()
        Grid1.Select()
    End Sub

    Private Sub Grid1_MouseClick(sender As Object, e As MouseEventArgs) Handles Grid1.MouseClick
        Try
            Dim _RowNo As Integer = Grid1.ActiveCell.Row

            'Dim LocX = 0 'x cord. of where crop starts
            'Dim LocY = 0 'y  cord. of where crop starts
            'Dim CropW = 1080 'Crop width
            'Dim CropH = 768 'Crop height
            'Dim CropRect As New Rectangle(LocX, LocY, CropW, CropH)
            'PictureBox1.ImageLocation = sTarget
            'Dim OriginalImage = PictureBox1.Image
            'Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
            'Using grp = Graphics.FromImage(CropImage)
            '    grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            '    CropImage.Save(sTarget)
            'End Using
            'PictureBox1.ImageLocation = sTarget
            PictureBox1.ImageLocation = Grid1.Cell(_RowNo, 2).Text & "/" & Grid1.Cell(_RowNo, 1).Text
            PictureBox1.Load()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub
    Private Sub Grid1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Grid1.MouseDoubleClick
        Dim _RowNo As Integer = Grid1.ActiveCell.Row
        Dim _FolderName As String = "Image"
        Dim strServerName = _FolderFilePath(_FolderName)

        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("DESIGNSTATUS") + 1)).Text = Grid1.Cell(_RowNo, 1).Text
        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("OP1") + 1)).Text = Grid1.Cell(_RowNo, 1).Text
        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("MODIFYENTRY") + 1)).Text = ""
        'GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTablegriditem.Columns.IndexOf("IMAGE_1") + 1)).Text = ms.ToArray()
    End Sub




    Private Sub txtPartyName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartyName.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = txtPartyName.Text
            GROUP_WISE_MULTY_PARTY_SELECT = " AND (LEFT(C.GROUPNAME,14)='SUNDRY DEBTORS' OR LEFT(C.GROUPNAME,16)='SUNDRY CREDITORS') "
            obj_Party_Selection.Invoice_Party_Selection()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                txtPartyName.Text = MULTY_SELECTION_COLOUM_1_DATA
                txtAccount_Code.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

#End Region

#Region "Challan Selection"
    Private Sub Txt_EntrySelection_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_EntrySelection.KeyDown
        'If e.KeyCode = Keys.Escape Then Exit Sub
        'If e.KeyCode = Keys.Enter Then
        '    If Txt_EntrySelection.Text.Trim = "" Then
        '        If _FormMode = "ADD" Then
        '            _StkGridSetting(Stk_Calculate(""))
        '        End If
        '    Else
        '        SendKeys.Send("{tab}")

        '    End If

        'ElseIf e.KeyCode = Keys.Delete Then
        '    Txt_EntrySelection.Text = ""
        'End If
    End Sub

    Private Sub Txt_Profile_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Profile.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = Txt_Profile.Text
            obj_Party_Selection.SINGLE_Remark_SELECTION("PRINTING PROFILE")
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_Profile.Text = MULTY_SELECTION_COLOUM_1_DATA
                Txt_ProfileCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtPartyName_Validated(sender As Object, e As EventArgs) Handles txtPartyName.Validated
        If _FormMode = "ADD" Then
            _StkGridSetting(Stk_Calculate(""))
        End If
    End Sub



#End Region
#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub
#End Region

    Private Sub txtBillDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBillDate.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtBillDate.Focus()
                txtBillDate.Select()
            End If
        End If
    End Sub

End Class