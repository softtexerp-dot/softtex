Imports System.IO
Imports System.Text

Public Class JobCardPlanning
    Private obj_Party_Selection As New Multi_Selection_Master
    Private ObjCls_General As New cls_FrmHandle.cls_frmHandle
    Private WithEvents txtUnitCode As New TextBox
    Dim _UNiteWiseCode As String = ""
    Dim DefaltimageName

    Dim _SubItemColum As String = ""
    Dim _MRPColoum As String = ""
    Dim _UnitColoum As String = ""
    Dim _SizeColoum As String = ""
    Dim _ColorColoumn As String = ""
    Dim _dateSelection As String = ""

#Region "Form Load"
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
#End Region

#Region "GRID GENERAL VARIABLE "
    Private Grid_Table_ColNames() As String
    Private _RecordsKeyFieldName As String = "ID"
    Private _DataTableGrid As New DataTable
    Private _DefaultColOfGrid As Integer = 0
    Private _ActivatedColName As String = ""
    Private _RowNo As Integer = 0
    Private _ColNo As Integer = 0
    Private _GridLastColNo As Integer = 0
    Private _LastRow As Integer = 0
    Private _Last_Saved_Entry_No As Integer = 0
    Private _isCallerByOther As Boolean = False
    Private _old_Me_text As String = ""
    Private Last_Focused_Btn As String = ""
    Private WithEvents Txt_Dt As New ctl_TextBox.ctl_TextBox
    Private WithEvents txt_Name_For_Grid_Selection As New TextBox
    Private WithEvents txt_Code_For_Grid_Selection As New TextBox
    Private WithEvents txtAcOfCode As New TextBox
    Private WithEvents txtBookCode As New TextBox
    Private WithEvents txtSelvCode As New TextBox
    Private WithEvents txtLoomTypeCode As New TextBox
    Private WithEvents txtWeaveTypeCode As New TextBox
    Private WithEvents txtIamgePath As New TextBox

    Private Old_Date As String = ""
    Private Edit_From_View As Boolean = False
    Private Book_Name As String = ""
    Private Book_Code As String = ""
    Private AcCode_Filter_String As String = ""
    Private Book_Row As DataRow
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
            .Append("CHALLAN_NO,")
            .Append("CHALLAN_DATE,")
            .Append("OP2,")
            .Append("ACCOUNTCODE,")
            .Append("TRANSPORTCODE,")
            .Append("HEADERREMARK,")
            .Append("SRNO,")
            .Append("OP1,")

            .Append("VENDORNAME,")
            .Append("GROUPNAME,")
            .Append("DESIGNNAME,")
            .Append("SHADENAME,")
            .Append("ITEMCODE,")
            .Append("RDVALUE,") 'gst%
            .Append("DESCR,")
            .Append("DESIGNCODE,")
            .Append("PRODITEMNAME,")
            .Append("SUBITEMNAME,")
            .Append("TYPE,")
            .Append("SIZECODE,")
            .Append("DelvDays,") ' size l
            .Append("NO_OF_SET,") '  size W
            .Append("OP12,") 'GSM
            .Append("OP13,") 'Bundle
            .Append("OP14,") 'Pcs Bundle
            .Append("OP15,") 'Sheets
            .Append("HEADERMTR,") 'Total
            .Append("COLOUR,")
            .Append("QTY,")
            .Append("CONSUMPCSQTY,")
            .Append("ITEMNAME,")
            .Append("FINISHQUALITY,")
            .Append("OP4,") ' FINISH SIZE
            .Append("READYQTY,")
            .Append("RATE,")
            .Append("AMOUNT,")
            .Append("Mtr_Weight,")
            .Append("LOTNO,") 'TYPECODE
            .Append("MONOGRAM_TYPE,") 'SUBITEMCODE
            .Append("PRODITEMCODE,")
            '.Append("SIZECODE,")
            .Append("COLORCODE,")
            .Append("ITEMTYPE,")
            .Append("ROWREMARK,")
            .Append("IMAGEPATH,")
            .Append("DELIVERYCODE,")
            .Append("BATCHNO,")
            .Append("TOTALMTR,")
            .Append("HEADERMTR_Bal,")
            .Append("OP3,") 'ACOFCODE
            .Append("OP5,") 'GREY REMARK
            .Append("OP6,") 'finish quality code
            .Append("SHADECODE") 'subitemcode

        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("ENTRYNO:N,")
            .Append("RATE:N,")
            .Append("RDVALUE:N,")
            .Append("Mtr_Weight:N,")
            .Append("QTY:N,")
            .Append("TOTALMTR:N,")
            .Append("CONSUMPCSQTY:N,")
            .Append("OP11:N,")
            .Append("HEADERMTR_Bal:N,")
            .Append("READYQTY:N,")
            .Append("OP12:N,") 'GSM
            .Append("OP13:N,") 'Bundle
            .Append("OP14:N,") 'Pcs Bundle
            .Append("OP15:N,") 'Sheets
            .Append("HEADERMTR:N,") 'Total
            .Append("DelvDays:N,") ' size l
            .Append("NO_OF_SET:N,") '  size W
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
            .Append("OP1:Vender ChNo,")
            .Append("GROUPNAME:Group,")
            .Append("ITEMNAME:Finish Item,")
            .Append("OP4:Finish Size,")
            .Append("READYQTY:Finish Qty,")
            .Append("FINISHQUALITY:Quality,")
            .Append("DESIGNNAME:Design,")
            .Append("SHADENAME:Shade,")
            .Append("DESCR:Descr,")
            .Append("RATE:Rate,")
            .Append("RDVALUE:Gst%,")
            .Append("AMOUNT:Amount,")
            .Append("SUBITEMNAME:SubItem,")
            .Append("PRODITEMNAME:Paper/PP,")
            .Append("SIZECODE:Size,")
            .Append("COLOUR:Color,")
            .Append("CONSUMPCSQTY:Per Pcs Consum,")
            .Append("VENDORNAME:Vendor,")
            .Append("DelvDays:Size L,") ' size l
            .Append("NO_OF_SET:Size W,") '  size W
            .Append("TYPE:Type,")
            .Append("QTY:Weight,")
            .Append("OP12:Gsm,") 'GSM
            .Append("OP13:Bundle,") 'Bundle
            .Append("OP14:Pkt,") 'Pcs Bundle
            .Append("OP15:Sheet,") 'Sheets
            .Append("HEADERMTR:Qty,") 'Total
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("OP1:L,")
            .Append("ITEMNAME:L,")
            .Append("GROUPNAME:L,")
            .Append("VENDORNAME:L,")
            .Append("RDVALUE:L,")
            .Append("FINISHQUALITY:L,")
            .Append("READYQTY:C,")
            .Append("DESCR:L,")
            .Append("OP4:L,")
            .Append("DESIGNNAME:L,")
            .Append("SHADENAME:L,")
            .Append("SUBITEMNAME:L,")
            .Append("RATE:R,")
            .Append("AMOUNT:R,")
            .Append("SIZECODE:L,")
            .Append("DelvDays:C,") ' size l
            .Append("NO_OF_SET:C,") '  size W
            .Append("COLOUR:L,")
            .Append("OP12:C,") 'GSM
            .Append("OP13:C,") 'Bundle
            .Append("OP14:C,") 'Pcs Bundle
            .Append("OP15:C,") 'Sheets
            .Append("HEADERMTR:C,") 'Total
            .Append("PRODITEMNAME:L,")
            .Append("TYPE:C,")
            .Append("QTY:C,")
            .Append("CONSUMPCSQTY:C,")
            .Append("ROWREMARK:L")
        End With


        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("OP1:L,")
            .Append("ITEMNAME:L,")
            .Append("GROUPNAME:L,")
            .Append("VENDORNAME:L,")
            .Append("FINISHQUALITY:L,")
            .Append("RDVALUE:L,")
            .Append("READYQTY:C,")
            .Append("DESCR:L,")
            .Append("OP4:L,")
            .Append("DESIGNNAME:L,")
            .Append("SHADENAME:L,")
            .Append("SUBITEMNAME:L,")
            .Append("DelvDays:C,") ' size l
            .Append("NO_OF_SET:C,") '  size W
            .Append("RATE:R,")
            .Append("AMOUNT:R,")
            .Append("SIZECODE:L,")
            .Append("COLOUR:L,")
            .Append("OP12:C,") 'GSM
            .Append("OP13:C,") 'Bundle
            .Append("OP14:C,") 'Pcs Bundle
            .Append("OP15:C,") 'Sheets
            .Append("HEADERMTR:C,") 'Total
            .Append("PRODITEMNAME:L,")
            .Append("TYPE:C,")
            .Append("QTY:C,")
            .Append("CONSUMPCSQTY:C,")
            .Append("ROWREMARK:L")
        End With
        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("ENTRYNO:N,")
            .Append("BOOKTRTYPE:N,")
            .Append("BOOKVNO:N,")
            .Append("BOOKCODE:N,")
            .Append("CHALLAN_NO:N,")
            .Append("CHALLAN_DATE:N,")
            .Append("OP1:Y,")
            .Append("OP4:Y,")
            .Append("FINISHQUALITY:Y,")
            .Append("VENDORNAME:Y,")
            .Append("GROUPNAME:N,")
            .Append("OP2:N,")
            .Append("OP12:Y,") 'GSM
            .Append("OP13:Y,") 'Bundle
            .Append("OP14:Y,") 'Pcs Bundle
            .Append("OP15:Y,") 'Sheets
            .Append("HEADERMTR:Y,") 'Total
            .Append("READYQTY:Y,") 'Total
            .Append("ACCOUNTCODE:N,")
            .Append("TRANSPORTCODE:N,")
            .Append("HEADERREMARK:N,")
            .Append("SHADECODE:N,")
            .Append("ITEMTYPE:N,")
            .Append("SRNO:Y,")
            .Append("ITEMNAME:Y,")
            .Append("ITEMCODE:N,")
            .Append("BATCHNO:N,")
            .Append("DESCR:N,")
            .Append("HEADERMTR_Bal:N,")
            .Append("RDVALUE:N,")
            .Append("DESIGNCODE:N,")
            .Append("DESIGNNAME:N,")
            .Append("SHADENAME:N,")
            .Append("DELIVERYCODE:N,")
            .Append("ROWREMARK:Y,")
            .Append("PRODITEMNAME:Y,")
            .Append("SUBITEMNAME:N,")
            .Append("TYPE:N,")
            .Append("IMAGEPATH:N,")
            .Append("SIZECODE:Y,")
            .Append("COLOUR:N,")
            .Append("OP3:N,")
            .Append("OP6:N,")
            .Append("TOTALMTR:N,")
            .Append("DelvDays:Y,") ' size l
            .Append("NO_OF_SET:Y,") '  size W
            .Append("QTY:Y,")
            .Append("CONSUMPCSQTY:N,")
            .Append("RATE:Y,")
            .Append("AMOUNT:Y,")
            .Append("Mtr_Weight:N,")
            .Append("LOTNO:N,") 'TYPECODE
            .Append("MONOGRAM_TYPE:N,") 'SUBITEMCODE
            .Append("PRODITEMCODE:N,")
            .Append("OP5:N,")
            '.Append("SIZECODE:N,")
            .Append("COLORCODE:N")
        End With
        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("ITEMNAME:N,")
            .Append("GROUPNAME:N,")
            .Append("VENDORNAME:N,")
            .Append("SUBITEMNAME:N,")
            .Append("DESIGNNAME:N,")
            .Append("PRODITEMNAME:N,")
            .Append("FINISHQUALITY:N,")
            '.Append("SIZE:N,")
            .Append("COLOUR:N,")
            .Append("TYPE:N,")
            .Append("SHADENAME:N")
        End With
        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:4,")
            .Append("OP1:9,")
            .Append("VENDORNAME:7,")
            .Append("GROUPNAME:7,")
            .Append("ITEMNAME:11,")
            .Append("RDVALUE:5,")
            .Append("DESIGNNAME:10,")
            .Append("SHADENAME:10,")
            .Append("DESCR:15,")
            .Append("RATE:6,")
            .Append("FINISHQUALITY:7,")
            .Append("SUBITEMNAME:7,")
            .Append("PRODITEMNAME:10,")
            .Append("OP12:5,") 'GSM
            .Append("OP13:5,") 'Bundle
            .Append("OP14:5,") 'Pcs Bundle
            .Append("OP15:5,") 'Sheets
            .Append("HEADERMTR:8,") 'Weight
            .Append("SIZECODE:8,")
            .Append("OP4:8,")
            .Append("COLOUR:6,")
            .Append("CONSUMPCSQTY:11,")
            .Append("TYPE:8,")
            .Append("READYQTY:8,")
            .Append("DelvDays:5,") ' size l
            .Append("NO_OF_SET:5,") '  size W
            .Append("QTY:10,")
            .Append("AMOUNT:8,")
            .Append("ROWREMARK:10")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("SRNO:0,")
            .Append("RATE:0,")
            .Append("RDVALUE:0,")
            .Append("Mtr_Weight:0,")
            .Append("OP12:0,") 'GSM
            .Append("OP13:0,") 'Bundle
            .Append("OP14:0,") 'Pcs Bundle
            .Append("OP15:0,") 'Sheets
            .Append("HEADERMTR:0,") 'Weight
            .Append("QTY:0,")
            .Append("TOTALMTR:0,")
            .Append("CONSUMPCSQTY:0,")
            .Append("READYQTY:0,")
            .Append("HEADERMTR_Bal:0,")
            .Append("DelvDays:0,") ' size l
            .Append("NO_OF_SET:0,") '  size W
            .Append("AMOUNT:0")
        End With
        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y,")
            '.Append("HEADERMTR:Y,")
            .Append("VENDORNAME:Y,")
            .Append("FINISHQUALITY:Y,")
            .Append("AMOUNT:Y,")
            .Append("AMOUNT:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("RATE:NO-2,")
            .Append("QTY:NO-2,")
            .Append("OP12:NO-3,") 'GSM
            .Append("OP13:NO-0,") 'Bundle
            .Append("OP14:NO-0,") 'Pcs Bundle
            .Append("OP15:NO-0,") 'Sheets
            .Append("HEADERMTR:NO-0,") 'Weight
            .Append("CONSUMPCSQTY:NO-2,")
            .Append("DelvDays:NO-2,") ' size l
            .Append("NO_OF_SET:NO-2,") '  size W
            .Append("READYQTY:NO-2,")
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

    Private _FrmLoad As Boolean = True
    Private WithEvents txtSalesman_code As New TextBox
    Private WithEvents txtAgent_code As New TextBox
    Private WithEvents txtAccount_Code As New TextBox
    Private WithEvents txtAcOfCode_Code As New TextBox
    Private WithEvents txtSupp_code As New TextBox
    Private WithEvents txtTr_code As New TextBox
    Private WithEvents txtDespatch_code As New TextBox
    Private WithEvents txtByerCode As New TextBox
    Private WithEvents txtCuttingSizeCode As New TextBox
    Private WithEvents txtJobSizeCode As New TextBox
    Private WithEvents txtItemCode As New TextBox
    Private WithEvents txtSizeCode As New TextBox
    Private WithEvents txtVandorCode As New TextBox


    Private DispList As Boolean = False
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _ChallanTableName As String = "TrnReadyMadeProducation"
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _BookTrType As String = ""
    Private _BookCode As String = ""
    Private _BookVNo As String = ""
    Private Change_Grid_Data As Boolean = True
#End Region

#Region "FORM VALIDATION "
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False

        If _BookCode.Trim = "" Then
            MsgBox("Invalid Book Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            'txtBookName.Focus()
            Exit Function
        ElseIf txtAccount_Code.Text = "" Or txtAccountName.Text = "" Then
            MsgBox("Invalid Party Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtAccountName.Focus()
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

#Region "FORM EVENTS "
    Private Sub General_Challan_Entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
                _CloseForm()
            Else
                If PnlPendingChallan.Visible = True Then
                    PnlPendingChallan.Visible = False
                    GrdItem.Focus()
                    Exit Sub
                End If
                If PNL_View.Visible = True Then
                    PNL_View.Visible = False
                    'Command_Button_Visibility("LOAD")
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                    Exit Sub
                End If
                Select Case _STRTRNOBJECT
                    Case "GRID_RATE_DISP"
                        'Pnl_Rate_Disp.Visible = False
                        GrdItem.Focus()
                        GrdItem.Select()
                    Case "GRDITEM"
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txtEntryNo.Focus()
                    Case "TXTCHALLANDATE"
                        _FrmLoad = False
                        txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                        _FORMMODE = ""
                        ObjCls_General.Blank_Object(Me)
                        txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                        Clear_Grid(GrdItem, 2)
                        _KeyFieldValue = 0
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                    Case Else
                        _FrmLoad = True
                        _FORMMODE = ""
                        ObjCls_General.Blank_Object(Me)
                        txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
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
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                    End If
                Case "BTNSAVE"
                    txtEntryNo.Focus()
                Case Else
                    If Trim(txtAccountName.Text) = "" Then
                        txtAccountName.Focus()
                    ElseIf txtEntryNo.Text = "" Or Val(txtEntryNo.Text) = 0 Then
                        txtEntryNo.Focus()
                    ElseIf txtChallanDate.Text = "  /  /    " Then
                        txtChallanDate.Focus()
                    ElseIf Trim(txtChallanNo.Text) = "" Then
                        txtChallanNo.Focus()
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

    Private Sub General_Challan_Entry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UC_Buttons1._ButtonEnableDisable("LOAD")
        _FrmLoad = True
        sqL = "ALTER TABLE TrnReadyMadeProducation ALTER COLUMN HEADERMTR_Bal numeric(18,6) "
        sql_Data_Save_Delete_Update()
        PnlPendingChallan.Width = Me.Width
        PnlPendingChallan.Height = 424
        PnlPendingChallan.Location = New Point(0, 0)

        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)

        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text

        'Fill_Cmb_View()

        Lbl_Tot_Mtr_Weight.Text = ""
        lbl_Tot_Amt.Text = ""
        SetTotalObjectPosition("QTY", _DataTableGrid, GrdItem, Lbl_Tot_Mtr_Weight, lbl_Total)
        SetTotalObjectPosition("AMOUNT", _DataTableGrid, GrdItem, lbl_Tot_Amt, lbl_Total)
        SetTotalObjectPosition("HEADERMTR", _DataTableGrid, GrdItem, LblTotalSheet, lbl_Total)
        SetTotalObjectPosition("READYQTY", _DataTableGrid, GrdItem, Lbl_FinishQty, lbl_Total)

        If ReqStoreCategory = "NO" Or ReqStoreCategory = "N" Then
            UseItemHead = "NO"
        Else
            UseItemHead = "YES"
        End If

        If _isCallerByOther = True Then
            Call Alter_Form(_KeyFieldValue)
        Else
            'Command_Button_Visibility("LOAD")
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        End If

        _FrmLoad = False
        Me.Location = New Point(0, 0)
        Book_Name = "JobCardPlanning"
        txtBookCode.Text = "0001-000000001"
        _BookTrType = "JOBCPLAN0001"
        _BookCode = txtBookCode.Text
        AutoResizeGrid(PNL_View, GridControl1)
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports", "BtnBack", "BtnNext")
    End Sub
#End Region

#Region "TOTAL ALL ROWS "
    Private Sub Total_Upto_All_Grid_All_Row()
        If _FrmLoad = True Then Exit Sub

        Dim Tot_Mtr_Weight As Double = 0
        Dim Tot_Amt As Double = 0
        Dim Tot_ReadyQty As Double = 0
        Dim Tot_Sheet As Double = 0

        For j As Int16 = 1 To GrdItem.Rows - 1

#Region "GSM TO WEIGHT Calculation"
            Dim GSM As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("OP12") + 1).Text)
            Dim Bundle As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("OP13") + 1).Text)
            Dim PcsBundle As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("OP14") + 1).Text)
            Dim Sheets As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("OP15") + 1).Text)
            Dim SIZE As String = GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text
            Dim _GSMCalulationFormula As String = GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1).Text

            Dim Size_L As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("DELVDAYS") + 1).Text)
            Dim Size_W As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("NO_OF_SET") + 1).Text)
            Dim SheetAvgWt As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("HEADERMTR_Bal") + 1).Text)
            'Dim SheetAvgWte As Double = GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("HEADERMTR_Bal") + 1).Text

            If Sheets > 0 Then
                'If Bundle = 0 Then Bundle = 1
                'If GSM = 0 Then GSM = 1

                Dim _Tbundl As Double
                Dim _TotalSheet As Double

                If Bundle > 0 AndAlso PcsBundle > 0 Then
                    _Tbundl = Bundle * PcsBundle
                ElseIf PcsBundle > 0 Then
                    _Tbundl = PcsBundle
                Else
                    _Tbundl = 1   ' Default to 1 so Sheets counts as-is
                End If
                _TotalSheet = _Tbundl * Sheets
                'If Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("OP13") + 1).Text) > 0 Then
                GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("HEADERMTR") + 1).Text = _TotalSheet
                'End If
                _TotalSheet = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("HEADERMTR") + 1).Text)

                'Dim mathExpr As String = SIZE.Replace("X", "*")
                'Dim SIZEresult As Double = Convert.ToDouble(New DataTable().Compute(mathExpr, ""))

                'Dim result As Double = 0.00
                'result = Genral_Stor_Challan.EvaluateDynamicFormula(GSM, _GSMCalulationFormula)
                'Dim finalValue As Double = Convert.ToDouble(New DataTable().Compute(Result, ""))
                'Dim resultRounded As String = finalValue.ToString("F10")
                'result = resultRounded

                'Dim _caluqty As Double = (SIZEresult * resultRounded) * _TotalSheet


                'Dim _caluqty As Double = ((Size_L * Size_W) * resultRounded) * _TotalSheet
                'GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text = _caluqty
                GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text = _TotalSheet * SheetAvgWt

                'If GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("SYNSTATUS") + 1).Text = "YES" Then
                '    If Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) = 0 Then
                '        GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = _caluqty
                '    End If
                'Else
                '    GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = _caluqty
                'End If

            End If
#End Region
            Dim _Rqty As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("READYQTY") + 1).Text)
            Dim _RRate As Double = Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text)
            GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = _Rqty * _RRate
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text)
            Tot_Amt = Tot_Amt + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text)
            Tot_ReadyQty = Tot_ReadyQty + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("READYQTY") + 1).Text)
            Tot_Sheet = Tot_Sheet + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("HEADERMTR") + 1).Text)
        Next
        If Tot_Mtr_Weight > 0 Then
            Lbl_Tot_Mtr_Weight.Text = FormatNumber(Tot_Mtr_Weight, 2, TriState.True, TriState.False, TriState.True)
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If
        If Tot_Amt > 0 Then
            lbl_Tot_Amt.Text = FormatNumber(Tot_Amt, 2, TriState.True, TriState.False, TriState.True)
        Else
            lbl_Tot_Amt.Text = ""
        End If
        If Tot_ReadyQty > 0 Then
            Lbl_FinishQty.Text = FormatNumber(Tot_ReadyQty, 2, TriState.True, TriState.False, TriState.True)
        Else
            Lbl_FinishQty.Text = ""
        End If
        If Tot_Sheet > 0 Then
            LblTotalSheet.Text = FormatNumber(Tot_Sheet, 2, TriState.True, TriState.False, TriState.True)
        Else
            LblTotalSheet.Text = ""
        End If
    End Sub
#End Region

#Region "COMMAND BUTTON VISIBILITY CODE "
    'Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
    '    'DefaltimageName = Textile.My.Resources.Resources.iamge
    '    LblBillNo.Text = ""
    '    PictureBox1.Image = DefaltimageName
    '    PnlPendingChallan.Visible = False
    '    If Visibility_Flag = "LOAD" Then
    '        btnSave.Enabled = False
    '        btnAdd.Enabled = True
    '        btnEdit.Enabled = True
    '        btnDelete.Enabled = True
    '        btnView.Enabled = True
    '        btnEdit.Enabled = True
    '        btnDelete.Enabled = True
    '        btnView.Enabled = True
    '        btnPrint.Enabled = True
    '    ElseIf Visibility_Flag = "BTNADD" Then
    '        btnSave.Enabled = True
    '        btnAdd.Enabled = False
    '        btnEdit.Enabled = False
    '        btnDelete.Enabled = False
    '        btnView.Enabled = False
    '        btnPrint.Enabled = False
    '    ElseIf Visibility_Flag = "BTNEDIT" Then
    '        btnSave.Enabled = True
    '        btnAdd.Enabled = False
    '        btnEdit.Enabled = False
    '        btnDelete.Enabled = False
    '        btnSave.Enabled = False
    '        btnView.Enabled = False
    '        btnPrint.Enabled = False
    '    ElseIf Visibility_Flag = "BTNDELETE" Then
    '        btnSave.Enabled = True
    '        btnAdd.Enabled = False
    '        btnEdit.Enabled = False
    '        btnSave.Enabled = False
    '        btnDelete.Enabled = False
    '        btnView.Enabled = False
    '        btnPrint.Enabled = False
    '    ElseIf Visibility_Flag = "BTNVIEW" Then
    '        btnSave.Enabled = False
    '        btnAdd.Enabled = False
    '        btnEdit.Enabled = False
    '        btnDelete.Enabled = False
    '        btnView.Enabled = False
    '        btnPrint.Enabled = False
    '    End If

    '    If pub_User_add = "N" Then
    '        btnAdd.Enabled = False
    '    End If

    '    If pub_User_modify = "N" Then
    '        btnEdit.Enabled = False
    '    End If

    '    If pub_User_delete = "N" Then
    '        btnDelete.Enabled = False
    '    End If

    '    If pub_User_view = "N" Then
    '        btnView.Enabled = False
    '    End If

    '    If pub_User_print = "N" Then
    '        btnPrint.Enabled = False
    '    End If

    'End Sub
#End Region

#Region "Button Click Event "
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub

    Private Sub _CloseForm()
        Me.Close()
        Me.Dispose()
        _PrintingSelectionType = ""
    End Sub
    'Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    If _FORMMODE = "VIEW" Then
    '        PNL_View.Visible = False
    '        _FrmLoad = True
    '        _FORMMODE = ""
    '        Old_Date = txtChallanDate.Text
    '        ObjCls_General.Blank_Object(Me)
    '        txtChallanDate.Text = Old_Date
    '        Clear_Grid(GrdItem, 2)
    '        Label_Value_Nil_Rest()
    '        _KeyFieldValue = 0
    '        Command_Button_Visibility("LOAD")
    '        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    '        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
    '    Else

    '        _CloseForm()
    '    End If
    'End Sub
    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If _FORMMODE = "EDIT" Then
    '        Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
    '        If _userwrits = "N" Then
    '            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '            Exit Sub
    '        End If
    '    End If
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
    '    Dim _userwrits As String = obj_Party_Selection._userWrits("ADD")
    '    If _userwrits = "N" Then
    '        MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If
    '    _FORMMODE = "ADD"
    '    Last_Focused_Btn = "ADD"
    '    txtBookName.Visible = True
    '    Command_Button_Visibility("BTNADD")

    '    ObjCls_General.Blank_Object(Me)
    '    txtBookName.Text = Book_Name
    '    txtBookCode.Text = Book_Code



    '    txtBookName.Focus()
    '    txtBookName.Select()
    'End Sub
    'Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
    '    Edit_From_View = False
    '    Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
    '    If _userwrits = "N" Then
    '        MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If
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
    '    Dim _userwrits As String = obj_Party_Selection._userWrits("DELETE")
    '    If _userwrits = "N" Then
    '        MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If
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
    '    Dim _userwrits As String = obj_Party_Selection._userWrits("VIEW")
    '    If _userwrits = "N" Then
    '        MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If
    '    'cmbSeek.SelectedIndex = 0
    '    _FORMMODE = "VIEW"
    '    Last_Focused_Btn = "VIEW"
    '    txtBookName.Visible = True
    '    Command_Button_Visibility("BTNVIEW")

    '    txtBookName.Text = Book_Name
    '    txtBookCode.Text = Book_Code


    '    txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
    '    txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

    '    txtBookName.Focus()
    '    txtBookName.Select()
    'End Sub
    'Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
    '    If _userwrits = "N" Then
    '        MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
    '        Exit Sub
    '    End If

    '    Packing_JobCardPrinting.ShowDialog()
    'End Sub
#End Region
#Region "Button Click"
    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        Edit_From_View = False
        _FrmLoad = False
        Dim _userwrits As String = obj_Party_Selection._userWrits("ADD")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        _FORMMODE = "ADD"
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtBookName_Validated()
        txtEntryNo.Focus()
        'txtEntryNo.Select()
        _FrmLoad = True
    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        Edit_From_View = False
        Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        _FrmLoad = False
        _FORMMODE = "EDIT"
        Last_Focused_Btn = "EDIT"
        txtEntryNo.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtBookCode.Text = Book_Code
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        Edit_From_View = False
        Dim _userwrits As String = obj_Party_Selection._userWrits("DELETE")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        _FrmLoad = False
        _FORMMODE = "DELETE"
        Last_Focused_Btn = "DELETE"
        txtEntryNo.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)

        ObjCls_General.Blank_Object(Me)
        txtBookCode.Text = Book_Code
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    'Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
    '    _FrmLoad = False
    '    If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
    '        txtEntryNo.Text = Val(txtEntryNo.Text) - 1
    '        Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)

    '        Call Validate_Entry_No(Book_Vno, _ChallanTableName)
    '        BtnOpen.Visible = True
    '        BtnView1.Visible = True
    '        txtFilePath.Visible = False
    '        txtimageid.Visible = False
    '    End If
    'End Sub

    'Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
    '    _FrmLoad = False
    '    If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
    '        txtEntryNo.Text = Val(txtEntryNo.Text) + 1
    '        Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
    '        Call Validate_Entry_No(Book_Vno, _ChallanTableName)
    '        BtnOpen.Visible = True
    '        BtnView1.Visible = True
    '        txtFilePath.Visible = False
    '        txtimageid.Visible = False
    '    End If
    'End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        If _FORMMODE = "EDIT" Then
            Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
            If _userwrits = "N" Then
                MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
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
            Old_Date = txtChallanDate.Text
            ObjCls_General.Blank_Object(Me)
            txtChallanDate.Text = Old_Date
            Clear_Grid(GrdItem, 2)
            Label_Value_Nil_Rest()
            _KeyFieldValue = 0
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Else
            _CloseForm()
        End If
    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FrmLoad = False
        Dim _userwrits As String = obj_Party_Selection._userWrits("VIEW")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'cmbSeek.SelectedIndex = 0
        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        txtEntryNo.Visible = True
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        txtBookCode.Text = Book_Code
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        Packing_JobCardPrinting.ShowDialog()
    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"

    End Sub

#End Region
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
                txtChallanNo.Text = txtEntryNo.Text
                txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                Generate_Date_For_DataBase(txtChallanDate)
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
                    txtChallanNo.Text = txtEntryNo.Text
                    Generate_Date_For_DataBase(txtChallanDate)
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

#Region "Label Value Setting "
    Private Sub Label_Value_Nil_Rest()
        lbl_Tot_Amt.Text = ""
        Lbl_Tot_Mtr_Weight.Text = ""
    End Sub
#End Region

#Region "DELETE CODE"
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        _FrmLoad = True
        'GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).DeleteByRow()
        'GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = GrdObj.ActiveCell.Row
        ' Delete the current row
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).DeleteByRow()

        ' If no rows remain, insert one new row
        If GrdObj.Rows <= 1 Then
            GrdObj.Rows = 2 ' 1 for header, 1 for new row
        Else
            ' Optional: Re-index SRNO for remaining rows
            For i As Integer = 1 To GrdObj.Rows - 1
                GrdObj.Cell(i, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = i.ToString()
            Next
        End If

        _FrmLoad = False
    End Sub
    Private Sub Delete_Entry_SQL()
        _FrmLoad = True
        Dim affected As Integer = 0
        Dim I As Integer = 0
        Dim _LastID As Integer = 0

        Try
            sqL = "DELETE FROM TrnReadyMadeProducation WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "' "
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
    Private Sub LoadLastEntryDetails()

        Dim TmpTbl As New DataTable

        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        _strQuery = New StringBuilder()

        With _strQuery
            .Append(" SELECT TOP 1 A.*, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" B.ACCOUNTNAME, F.ACCOUNTNAME AS AGENTNAME ")
            .Append(" FROM TrnReadyMadeProducation AS A, ")
            .Append(" MstMasterAccount AS B, MstMasterAccount AS F ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND B.AGENTCODE=F.ACCOUNTCODE ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            .Append(_UNiteWiseCode)
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With

        Dim Str_Qry As String = _strQuery.ToString()

        sqL = Str_Qry
        sql_connect_slect()

        Dim TblTmp As DataTable = DefaltSoftTable.Copy

        Dim Last_Entry_No As Integer = 0

        If TblTmp.Rows.Count > 0 Then
            Last_Entry_No = Val(TblTmp.Rows(0)("ENTRYNO").ToString())
        End If

        Select Case _FORMMODE.ToUpper()

            Case "ADD"

                If Last_Entry_No > 0 Then

                    txtEntryNo.Text = (Last_Entry_No + 1).ToString()

                    txtAccountName.Text =
                    TblTmp.Rows(0)("ACCOUNTNAME").ToString()

                    txtChallanDate.Text =
                    TblTmp.Rows(0)("F_CHALLANDATE").ToString()

                    txtAccount_Code.Text =
                    TblTmp.Rows(0)("ACCOUNTCODE").ToString()

                    If Book_Row("NATURE").ToString() <> "SALES" Then
                        txtChallanNo.Text = ""
                        txtAccount_Code.Text = ""
                        txtAccountName.Text = ""
                    End If

                Else

                    txtChallanDate.Text =
                    ObjCls_General.GetTodayDate_British()
                    Last_Entry_No = 1
                    txtEntryNo.Text = Last_Entry_No

                End If

                If _dateSelection = "LAST DATE" AndAlso
               TblTmp.Rows.Count > 0 Then

                    txtChallanDate.Text =
                    TblTmp.Rows(0)("F_CHALLANDATE").ToString()

                Else

                    txtChallanDate.Text =
                    ObjCls_General.GetTodayDate_British()

                End If

                Generate_Date_For_DataBase(txtChallanDate)

                GrdItem.Rows = 2

                Dim SrNoIndex As Integer =
                _DataTableGrid.Columns.IndexOf("SRNO")

                If SrNoIndex >= 0 Then
                    GrdItem.Cell(1, SrNoIndex + 1).SetFocus()
                End If

                'txtEntryNo.Focus()
                'txtEntryNo.Select()

            Case "EDIT", "DELETE"

                If Last_Entry_No = 0 Then

                    MsgBox("No Record Found",
                       MsgBoxStyle.Information + MsgBoxStyle.OkOnly,
                       "Soft-Tex PRO")

                    txtEntryNo.Focus()
                    txtEntryNo.Select()
                    Exit Sub

                End If

                txtEntryNo.Text = Last_Entry_No.ToString()
                Last_Saved_Entry_No = Last_Entry_No

                Generate_Date_For_DataBase(txtChallanDate)

                txtEntryNo.Focus()
                txtEntryNo.Select()

            Case "VIEW"

                If Last_Entry_No = 0 Then

                    MsgBox("No Record Found",
                       MsgBoxStyle.Information + MsgBoxStyle.OkOnly,
                       "Soft-Tex PRO")

                    txtEntryNo.Focus()
                    txtEntryNo.Select()

                Else

                    View_Record()

                End If

        End Select

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
                UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
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
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice, Can't Delete", MsgBoxStyle.Information, "Soft-Tex PRO")
                Else

                    If LblBillNo.Text > "" Then
                        MsgBox("Bill Generated Can't Delete", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Call Delete_Entry_SQL()
                    End If
                End If
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                If _Last_Saved_Entry_No > 0 Then
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                Else
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
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
            Else
                'If _BookCode = "0001-000000153" Then
                If _FORMMODE = "ADD" Then
                    If txtEntryNo.Text = "" Then
                        txtEntryNo.Text = 1
                    End If
                    txtChallanNo.Text = txtEntryNo.Text
                    'txtChallanDate.Text = txtGR_Date.Text
                    'txtGR_No.Text = txtEntryNo.Text
                    Generate_Date_For_DataBase(txtChallanDate)
                End If
                'End If
            End If
        End If

    End Sub
#End Region

#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLAN_DATE, ")
            .Append(" B.ACCOUNTNAME,F.ITEMNAME , ")
            .Append(" H.AC_NAME, ")
            .Append(" I.ACCOUNTNAME AS BUYERNAME , ")
            .Append(" K.ItemName AS PRODITEMNAME , ")
            .Append(" M.GroupName,  ")
            .Append(" N.ACCOUNTNAME AS VENDORNAME  ")
            .Append(" , G.subItemName AS FINISHQUALITY ")
            .Append(" FROM TrnReadyMadeProducation AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem F ON A.ITEMCODE=F.ITEMCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply H ON A.OP3=H.ID ")
            .Append(" LEFT JOIN MstMasterAccount I ON A.DESIGNCODE=I.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem K ON A.PRODITEMCODE=K.ItemCode ")
            .Append(" LEFT JOIN MstStoreItemGroup M ON A.COLORCODE=M.GroupCode  ")
            .Append(" LEFT JOIN MstMasterAccount AS N ON A.DELIVERYCODE=N.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstStoreSubItem G  ON  A.OP6=G.subItemCode ")

            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" AND A.BOOKVNO='" & strKeyID & "'")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return _strQuery.ToString
    End Function
#End Region

#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Dim tblTmp As New DataTable
        sqL = getAlter_Form_Query_Details(strKeyID)
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy



        txtEntryNo.Text = tblTmp.Rows(0)("entryno").ToString
        txtAccountName.Text = tblTmp.Rows(0)("ACCOUNTNAME").ToString
        txtChallanNo.Text = tblTmp.Rows(0)("CHALLAN_NO").ToString
        txtChallanDate.Text = tblTmp.Rows(0)("F_CHALLAN_DATE").ToString
        txtHeader_Remark.Text = tblTmp.Rows(0)("HEADERREMARK").ToString
        Txt_PrintQty.Text = tblTmp.Rows(0)("TOTALMTR").ToString


        txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString

        Txt_ByerName.Text = tblTmp.Rows(0)("BUYERNAME").ToString
        'Txt_CuttingSize.Text = tblTmp.Rows(0)("CUTTINGSIZE").ToString
        'Txt_JobSize.Text = tblTmp.Rows(0)("JOBSIZE").ToString
        'Txt_Size.Text = tblTmp.Rows(0)("SUBITEMNAME").ToString


        Txt_CuttingSize.Text = tblTmp.Rows(0)("SHADECODE").ToString
        Txt_JobSize.Text = tblTmp.Rows(0)("LOTNO").ToString

        txtByerCode.Text = tblTmp.Rows(0)("DESIGNCODE").ToString
        'txtCuttingSizeCode.Text = tblTmp.Rows(0)("SHADECODE").ToString
        'txtJobSizeCode.Text = tblTmp.Rows(0)("LOTNO").ToString
        txtItemCode.Text = tblTmp.Rows(0)("ITEMCODE").ToString
        Txt_Size.Text = tblTmp.Rows(0)("MONOGRAM_TYPE").ToString
        txtIamgePath.Text = tblTmp.Rows(0)("IMAGEPATH").ToString
        Txt_LaminDrip.Text = tblTmp.Rows(0)("BATCHNO").ToString
        Txt_AcoFName.Text = tblTmp.Rows(0)("AC_NAME").ToString
        txtAcOfCode_Code.Text = tblTmp.Rows(0)("OP3").ToString

        If txtIamgePath.Text <> "" Then
            Dim _FolderName As String = "Image"
            Dim strServerName = _FolderFilePath(_FolderName)
            Dim _FilePath As String = System.IO.Path.Combine(strServerName, txtIamgePath.Text)

            If System.IO.File.Exists(_FilePath) Then
                PictureBox1.ImageLocation = _FilePath
            Else
                PictureBox1.Image = DefaltimageName
            End If
        Else
            PictureBox1.Image = DefaltimageName
        End If



        Generate_Date_For_DataBase(txtChallanDate)
        'Generate_Date_For_DataBase(txtGR_Date)

        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)

        GrdItem.Refresh()
        GrdItem.Visible = True

        For i As Int16 = 1 To GrdItem.Rows - 1
            GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = i
        Next



        LblBillNo.Text = ""
        sqL = " SELECT TOP 1 BILLNO FROM TRNINVOICEDETAIL WHERE CHALLANBOOKVNO='" & tblTmp.Rows(0)("BOOKVNO").ToString & "' ORDER BY BOOKVNO DESC "
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            LblBillNo.Text = DefaltSoftTable(0).Item("BILLNO").ToString
            If LblBillNo.Text.Trim.Length > 0 Then
                LblBillNo.Text = "Bill No : " & LblBillNo.Text
                LblBillNo.Visible = True
            End If
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
            .Append(" SELECT A.OP2 AS OFFERBOOKVNO ")
            .Append(" FROM TRNINVOICEDETAIL A ")
            .Append(" WHERE A.ACCOUNTCODE='" & txtAccount_Code.Text & "' ")
            .Append(" AND A.OP2='" & _BookVNo & "' ")
        End With
        strQuery = _strQuery.ToString
        sqL = strQuery
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
    'Private Sub txtBookName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBookName.KeyPress
    '    If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub

    '    DispList = False
    '    If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then

    '        BOOK_CATGER = "PACKING SLIP"
    '        BOOK_BHEWAR = "READYMADE"
    '        Party_selection.txtSearch.Text = txtBookName.Text
    '        obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
    '        txtBookName.Text = MULTY_SELECTION_COLOUM_1_DATA
    '        txtBookCode.Text = MULTY_SELECTION_COLOUM_3_DATA
    '        _BookCode = txtBookCode.Text
    '        Book_Name = txtBookName.Text
    '        Book_Code = txtBookCode.Text

    '        If _BookCode <> "" Then
    '            Dim TmpTbl As New DataTable
    '            sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & _BookCode & "' "
    '            sql_connect_slect()
    '            TmpTbl = DefaltSoftTable.Copy

    '            If TmpTbl.Rows.Count > 0 Then
    '                Book_Row = TmpTbl(0)
    '                AcCode_Filter_String = TmpTbl(0)("GROUP_CODE_FILTER_STRING").ToString
    '                _BookTrType = TmpTbl(0)("BOOKTRTYPE").ToString

    '                _SubItemColum = TmpTbl(0)("OP19").ToString
    '                _MRPColoum = TmpTbl(0)("OP20").ToString
    '                _UnitColoum = TmpTbl(0)("OP211").ToString
    '                _SizeColoum = TmpTbl(0)("OP22").ToString
    '                _ColorColoumn = TmpTbl(0)("OP23").ToString
    '                _dateSelection = TmpTbl(0)("Y_LOAN").ToString

    '            End If

    '            If _FORMMODE <> "VIEW" Then
    '                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
    '                GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
    '                SendKeys.Send("{TAB}")
    '            Else
    '                'SendKeys.Send("{ENTER}")
    '                SendKeys.Send("{TAB}")
    '            End If
    '        End If


    '        Call defineGridColName()
    '        Call GenerateTable(_DataTableGrid, GrdItem)
    '        Call GridFormatting(_DataTableGrid, GrdItem)

    '        GrdItem.Rows = 2
    '        GrdItem.Column(0).Visible = False
    '        GrdItem.Row(0).Height = 31
    '        GrdItem.DefaultRowHeight = 28

    '    End If
    '    e.Handled = True
    'End Sub
    'Private Sub txtBookName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookName.Validated
    '    If _FrmLoad = True Then Exit Sub

    '    If txtBookCode.Text = "" Or _BookCode = "" Then
    '        txtBookName.Focus()
    '        txtBookName.Select()
    '        Exit Sub
    '    Else
    '        Dim TmpTbl As New DataTable
    '        AcCode_Filter_String = Book_Row("GROUP_CODE_FILTER_STRING").ToString  'TmpTbl(0)("group_code_filter_string").ToString
    '        _BookTrType = Book_Row("BOOKTRTYPE").ToString

    '        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)


    '        _strQuery = New StringBuilder
    '        With _strQuery
    '            .Append(" SELECT TOP 1 A.*, ")
    '            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
    '            .Append(" B.ACCOUNTNAME,F.ACCOUNTNAME AS AGENTNAME")
    '            .Append(" FROM TrnReadyMadeProducation AS A, MstMasterAccount AS B,  ")
    '            .Append(" MstMasterAccount AS F ")
    '            .Append(" WHERE 1=1 ")
    '            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
    '            .Append(" AND B.AGENTCODE=F.ACCOUNTCODE ")
    '            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
    '            .Append(_UNiteWiseCode)
    '            .Append(" ORDER BY A.ENTRYNO DESC ")
    '        End With

    '        Dim Str_Qry As String = _strQuery.ToString
    '        Dim TblTmp As New DataTable
    '        sqL = Str_Qry
    '        sql_connect_slect()
    '        TblTmp = DefaltSoftTable.Copy

    '        Dim Last_Entry_No As Integer = 0
    '        If TblTmp.Rows.Count > 0 Then
    '            Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
    '        End If

    '        If _FORMMODE = "ADD" Then
    '            txtEntryNo.Text = Last_Entry_No + 1
    '            If Last_Entry_No > 0 Then
    '                'ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, TblTmp)


    '                txtAccountName.Text = TblTmp(0)("ACCOUNTNAME").ToString
    '                txtChallanDate.Text = TblTmp(0)("F_CHALLANDATE").ToString
    '                'txtGR_Date.Text = TblTmp(0)("F_GR_DATE").ToString
    '                txtAccount_Code.Text = TblTmp(0)("ACCOUNTCODE").ToString


    '                txtEntryNo.Text = Last_Entry_No + 1

    '                If Book_Row("NATURE").ToString <> "SALES" Then
    '                    txtChallanNo.Text = ""
    '                    txtAccount_Code.Text = ""
    '                    txtAccountName.Text = ""
    '                End If
    '            Else
    '                txtChallanDate.Text = ObjCls_General.GetTodayDate_British
    '                txtEntryNo.Text = "1"

    '            End If


    '            If _dateSelection = "LAST DATE" Then
    '                txtChallanDate.Text = TblTmp(0)("F_CHALLANDATE").ToString
    '            Else
    '                txtChallanDate.Text = ObjCls_General.GetTodayDate_British
    '            End If


    '            'sqL = "SELECT TOP 1 ISNULL(GR_NO,0) AS GR_NO  FROM TrnReadyMadeProducation WHERE 1=1 ORDER BY GR_NO DESC "
    '            'sql_connect_slect()

    '            'If DefaltSoftTable.Rows.Count > 0 Then
    '            '    txtGR_No.Text = DefaltSoftTable.Rows(0).Item(0) + 1
    '            'Else
    '            '    txtGR_No.Text = 1
    '            'End If


    '            Generate_Date_For_DataBase(txtChallanDate)
    '            'Generate_Date_For_DataBase(txtGR_Date)
    '            GrdItem.Rows = 2
    '            GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
    '            txtEntryNo.Focus()
    '            txtEntryNo.Select()
    '        ElseIf _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
    '            If Last_Entry_No = 0 Then
    '                MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
    '                txtBookName.Focus()
    '                txtBookName.Select()
    '                Exit Sub
    '            Else
    '                txtEntryNo.Text = Last_Entry_No
    '                Last_Saved_Entry_No = Last_Entry_No
    '                Generate_Date_For_DataBase(txtChallanDate)
    '                txtEntryNo.Focus()
    '                txtEntryNo.Select()
    '            End If
    '        ElseIf _FORMMODE = "VIEW" Then
    '            If Last_Entry_No = 0 Then
    '                MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
    '                txtBookName.Focus()
    '                txtBookName.Select()
    '            Else
    '                View_Record()
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region

#Region "Account Name Txt Box Events "
    Private Sub txtAccountName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountName.KeyPress
        'If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            'party_selection_book_code = Book_Code
            'Party_selection.txtSearch.Text = txtAccountName.Text
            'Call obj_Party_Selection.Account_Selection()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    txtAccountName.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtAccount_Code.Text = MULTY_SELECTION_COLOUM_3_DATA
            '    Return_Master_Name = txtAccountName.Text
            'End If
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccountvendorcode_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtAccountName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtAccount_Code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then txtAccountName.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
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
    Private Sub Txt_AcoFName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_AcoFName.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Party_selection.txtSearch.Text = Txt_AcoFName.Text
            'Call obj_Party_Selection.SINGLE_ACC_OF_SELECTION()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    Txt_AcoFName.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtAcOfCode_Code.Text = MULTY_SELECTION_COLOUM_3_DATA
            'End If
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_ACC_OF_SELECTION(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), Txt_AcoFName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtAcOfCode_Code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("A/C Of") Then Txt_AcoFName.Text = selected("A/C Of").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

#End Region

#Region "Offer No Txt Box Events "
    Private Sub txtChallanNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChallanNo.Validated
        If _FrmLoad = True Then Exit Sub

        _BookVNo = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)

        Dim StrQryChl As String = ""

        'If Book_Row("NATURE").ToString <> "SALES" Then
        '    sqL = "SELECT count(bookvno) as tbkvno FROM TrnReadyMadeProducation WHERE CHALLAN_NO='" & txtChallanNo.Text & "' AND  BOOKVNO<> '" & _BookVNo & "' AND BOOKCODE='" & _BookCode & "' AND ACCOUNTCODE='" & txtAccount_Code.Text & "' "
        'Else
        sqL = "SELECT count(bookvno) as tbkvno FROM TrnReadyMadeProducation WHERE CHALLAN_NO='" & txtChallanNo.Text & "' AND  BOOKVNO<> '" & _BookVNo & "' AND BOOKCODE='" & _BookCode & "'  "
        'End If

        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            StrQryChl = DefaltSoftTable.Rows(0).Item(0)
        End If

        If Val((StrQryChl)) > 0 Then
            MsgBox("Challan No. Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtChallanNo.Select()
            txtChallanNo.Focus()
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
    End Sub

    Private Sub grditem_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GrdItem.KeyPress
        If _FrmLoad = True Then Exit Sub
    End Sub


    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub



        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = "0000-000000001"
        'If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MONOGRAM_TYPE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MONOGRAM_TYPE") + 1).Text = "0000-000000001"
        'If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = "0000-000000001"
        'If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DELIVERYCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DELIVERYCODE") + 1).Text = "0000-000000001"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP4") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP4") + 1).Text = txtHeader_Remark.Text



        Dim Col_Text As String = GrdItem.ActiveCell.Text

        If _ActivatedColName = "GROUPNAME" Then
            If e.KeyCode = Keys.Enter Then
                If Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text) = 0 Then
                    Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("GROUPNAME") + 1)).Text
                    obj_Party_Selection.SINGLE_StoreItemGroup_SELECTION()
                    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROUPNAME") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
                        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = MULTY_SELECTION_COLOUM_3_DATA
                    End If
                End If
            End If
        ElseIf _ActivatedColName = "OP12" Or _ActivatedColName = "OP13" Or _ActivatedColName = "OP14" Or _ActivatedColName = "OP15" Or _ActivatedColName = "OP16" Or _ActivatedColName = "READYQTY" Or _ActivatedColName = "RATE" Then
            If e.KeyCode = Keys.Enter Then
                Total_Upto_All_Grid_All_Row()
            End If
        ElseIf _ActivatedColName = "FINISHQUALITY" Then
            If e.KeyCode = Keys.Enter Then
                Dim _LoadQuery = NewSelectionList.SINGLE_store_Sub_Item_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Store_SubItem), GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("FINISHQUALITY") + 1).Text, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTCODE") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP6") + 1).Text = selected("ACCOUNTCODE").ToString()
                    If selected.ContainsKey("SubItemName") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("FINISHQUALITY") + 1).Text = selected("SubItemName").ToString()
                End If
            End If
        ElseIf _ActivatedColName = "ITEMNAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("ITEMNAME") + 1)).Text
                obj_Party_Selection.SINGLE_storeItem_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("ITEMNAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("ITEMCODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
            End If
        ElseIf _ActivatedColName = "PRODITEMNAME" Then
            If e.KeyCode = Keys.Enter AndAlso Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text) = 0 Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1)).Text
                Dim Item_Group_Code As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text
                GROUP_WISE_MULTY_PARTY_SELECT = " AND A.ITEMGROUPCODE='" & Item_Group_Code & "'"
                obj_Party_Selection.SINGLE_storeItem_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" SELECT ")
                    .Append(" ISNULL(A.VatTaxPer,0) AS VatTaxPer  ")
                    .Append(" ,ISNULL(A.MRP,0) AS MRP")
                    .Append(" ,A.Goods_Type ")
                    .Append(" ,B.GroupName ")
                    .Append(" ,ISNULL(B.OP2,0) AS GsmCalculation ")
                    .Append(" FROM MstStoreItem AS A ")
                    .Append(" LEFT JOIN MstStoreItemGroup AS B ON A.ITEMGROUPCODE=B.GroupCode ")
                    .Append(" WHERE A.ItemCode='" & GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text & "' ")
                End With
                sqL = _strQuery.ToString
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1).Text = DefaltSoftTable.Rows(0).Item("GsmCalculation").ToString
                End If
                Total_Upto_All_Grid_All_Row()
            End If
        ElseIf _ActivatedColName = "SIZECODE" Then
            If e.KeyCode = Keys.Enter Then
                'Party_selection.TextBox1.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZE") + 1)).Text
                'obj_Party_Selection.Single_size_Selection()
                'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                '    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                '    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                '    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZE") + 1)).Text = txt_Name_For_Grid_Selection.Text
                '    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                'End If
                Total_Upto_All_Grid_All_Row()
            End If
        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "DELVDAYS" Or _ActivatedColName = "NO_OF_SET" Then
            If e.KeyCode = Keys.Enter Then
                Total_Upto_All_Grid_All_Row()
            End If
        ElseIf _ActivatedColName = "OP1" Then
            If e.KeyCode = Keys.Enter AndAlso GrdItem.Cell(GrdItem.ActiveCell.Row, (_DataTableGrid.Columns.IndexOf("OP1") + 1)).Text = "" Then
                _GetPendingChallan()
            End If
        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                    'GrdItem.Rows = GrdItem.Rows + 1
                    _Inset_Data()
                    Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    Total_Upto_All_Grid_All_Row()
                End If
            End If
        End If
    End Sub


    Private Sub _Inset_Data()

        GrdItem.Rows = GrdItem.Rows + 1
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
        If Val(GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text) = 0 Then
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("COLOUR") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLOUR") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ROWREMARK") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ROWREMARK") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("CONSUMPCSQTY") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CONSUMPCSQTY") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SIZE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("AvgWeight") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("Mtr_Weight") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SUBITEMNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SUBITEMNAME") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("MONOGRAM_TYPE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MONOGRAM_TYPE") + 1).Text 'SUBITEMCODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("TYPE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("TYPE") + 1).Text
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("LOTNO") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("OP12") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP12") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("GROUPNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROUPNAME") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DELIVERYCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DELIVERYCODE") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("VENDORNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VENDORNAME") + 1).Text 'TYPECODE
            'GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("OP1") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP1") + 1).Text 'TYPECODE
            GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("OP2") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP2") + 1).Text 'TYPECODE
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
    Private Sub Txt_PrintQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PrintQty.KeyDown
        If _FrmLoad = True Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            _SelectImage()
            GrdItem.Focus()
            GrdItem.Select()
        End If
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

        If LblBillNo.Text > "" Then
            MsgBox("Bill Generated Can't Modify", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'If IsEntryDateLocked(txtChallanDate.Text) Then Exit Sub

        If txtAcOfCode.Text = "" Then txtAcOfCode.Text = "0000-000000001"
        If txtTr_code.Text = "" Then txtTr_code.Text = "0001-000000091"
        If txtUnitCode.Text = "" Then txtUnitCode.Text = "0001-000000091"
        If txtAccount_Code.Text = "" Then txtAccount_Code.Text = "0001-000000091"
        If txtVandorCode.Text = "" Then txtVandorCode.Text = "0001-000000091"
        If txtAcOfCode_Code.Text = "" Then txtAcOfCode_Code.Text = "0001-000000091"
        If Txt_PrintQty.Text.Trim = "" Then Txt_PrintQty.Text = "0"

        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)

        Total_Upto_All_Grid_All_Row()
        Generate_Date_For_DataBase(txtChallanDate)

        Call Fill_Grid_Records_Into_DataTables()

        Dim _LastID As Integer = -1
        Try
            _LastID = SAVE_INTO_DATABASE_SQL()

            'If _LastID > 0 Then
            Old_Date = txtChallanDate.Text
            Call Label_Value_Nil_Rest()
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")


            ObjCls_General.Blank_Object(Me)
            txtChallanDate.Text = Old_Date
            'txtGR_Date.Text = Old_Date
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)

            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            UC_Buttons1._ButtonEnableDisable("LOAD")
            UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
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
            If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text <> "" And Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text) > 0 Or Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("READYQTY") + 1).Text) > 0 Then
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
        If txtWeaveTypeCode.Text = "" Then txtWeaveTypeCode.Text = "0000-000000001"
        If txtByerCode.Text = "" Then txtByerCode.Text = "0000-000000001"
        If txtCuttingSizeCode.Text = "" Then txtCuttingSizeCode.Text = "0000-000000001"
        If txtJobSizeCode.Text = "" Then txtJobSizeCode.Text = "0000-000000001"
        If txtItemCode.Text = "" Then txtItemCode.Text = "0000-000000001"
        If txtSizeCode.Text = "" Then txtSizeCode.Text = "0000-000000001"
        Dim strFilterString As String
        Dim QueryDetailTable As String = ""
        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String
        strFilterString = "QTY>0 OR READYQTY>0 "
        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("DESPATCHCODE,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("CHALLAN_NO,")
            .Append("CHALLAN_DATE,")
            .Append("AccountCode,")
            .Append("TransportCode,")
            .Append("DESIGNCODE,") 'BYERCODE
            .Append("SHADECODE,") 'CUTTING SIZE
            .Append("LOTNO,") 'JOB SIZE
            '.Append("ITEMCODE,") 'ITEMCODE
            .Append("MONOGRAM_TYPE,") 'SIZE
            .Append("IMAGEPATH,")
            .Append("BATCHNO,")
            .Append("OP3,")
            .Append("TOTALMTR,")
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
            .Append(txtByerCode.Text & ",")
            .Append(Txt_CuttingSize.Text & ",")
            .Append(Txt_JobSize.Text & ",")
            .Append(Txt_Size.Text & ",")
            .Append(txtIamgePath.Text & ",")
            .Append(Txt_LaminDrip.Text & ",")
            .Append(txtAcOfCode_Code.Text & ",")
            .Append(Txt_PrintQty.Text & ",")
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
            strQuery = "DELETE FROM TrnReadyMadeProducation WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "' "
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

    Private Sub btn_View_Ok_Click_1(sender As Object, e As EventArgs) Handles btn_View_Ok.Click
        View_Record()
    End Sub
    Private Sub View_Record()
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""
        View_Filter_Condition = " AND  A.BOOKCODE='" & _BookCode & "' AND  A.CHALLAN_DATE>='" & txt_From.Date_for_Database & "' AND  A.CHALLAN_DATE<='" & txt_To.Date_for_Database & "'"
        View_Order_By = " ORDER BY  A.CHALLAN_DATE,( A.ENTRYNO), A.SRNO "
        Dim Offer_Field_String As String = ""
        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT  ")
            .Append(" a.BOOKVNO, ")
            .Append(" a.EntryNo, ")
            .Append(" a.CHALLAN_NO as JObNo, ")
            .Append(" A.CHALLAN_DATE AS JobDate, ")
            .Append(" B.ACCOUNTNAME as PrinterName, ")
            .Append(" H.AC_NAME as AcOf, ")
            .Append(" I.ACCOUNTNAME AS BuyerName , ")
            .Append(" a.SHADECODE as CuttingSize , ")
            .Append(" a.LOTNO as JobSize , ")
            .Append(" a.MONOGRAM_TYPE as QltyName , ")
            .Append(" a.BATCHNO as ProcessName , ")
            .Append(" a.HEADERREMARK as HedReamrk , ")
            .Append(" a.TOTALMTR as PrintQty , ")
            .Append(" F.itemName , ")
            .Append("A.OP1 as VenderChNo,")
            .Append("K.ItemName AS FinishItem , ")
            .Append("A.OP4 as FinishSize,")
            '.Append("A.READYQTY as FinishQty,")
            .Append("N.ACCOUNTNAME as Vendor,")
            .Append("A.DelvDays as SizeL,") ' size l
            .Append("A.NO_OF_SET as SizeW,") '  size W
            .Append("A.QTY as Weight,")
            .Append("A.OP12 as Gsm,") 'GSM
            .Append("A.OP13 as Bundle,") 'Bundle
            .Append("A.OP14 as Pkt,") 'Pcs Bundle
            .Append("A.OP15 as Sheet,") 'Sheets
            .Append("A.HEADERMTR as Qty,") 'Total
            .Append("A.RATE as Rate,")
            .Append("A.AMOUNT as Amount,")
            .Append("A.ROWREMARK as Remark")
            .Append(" FROM TrnReadyMadeProducation AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem F ON A.ITEMCODE=F.ITEMCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply H ON A.OP3=H.ID ")
            .Append(" LEFT JOIN MstMasterAccount I ON A.DESIGNCODE=I.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem K ON A.PRODITEMCODE=K.ItemCode ")
            '.Append(" LEFT JOIN MstStoreItemGroup M ON A.COLORCODE=M.GroupCode  ")
            .Append(" LEFT JOIN MstMasterAccount AS N ON A.DELIVERYCODE=N.ACCOUNTCODE  ")
            .Append(" WHERE 1=1 ")
            .Append(View_Filter_Condition)
            .Append(" ORDER BY a.EntryNo,A.SRNO ")
        End With
        sqL = strQuery.ToString
        sql_connect_slect()
        FirstStage.Columns.Clear()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then
            Dim columnNames As String() = {"Bundle", "Pkt", "Sheet", "Qty", "Weight", "Rate", "Amount"}
            For Each dr As DataRow In tblTmp.Rows
                For Each ColName In columnNames
                    dr(ColName) = SafeFormat(dr, ColName, "0.00", True)
                Next
            Next
            GridControl1.DataSource = tblTmp.Copy
            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Columns("BOOKVNO").Visible = False
            FirstStage.GroupRowHeight = 30
            'AlignGroupSummaryAuto(FirstStage, columnNames)
            PNL_View.Visible = True
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            PNL_View.BringToFront()
            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub


    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles btn_View_Print.Click
        Dim _RptTiltle = " Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles Btn_Export_Excel.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#End Region


#Region "DATE RANGE CHECK"
    Private Sub txtBillDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChallanDate.Validated

        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtChallanDate.Focus()
                txtChallanDate.Select()
            End If
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
    Private Sub _GetPendingChallan()
        Dim tblTmp As New DataTable
        Dim Filter_Condition = " AND A.ACOFCODE='" & txtAcOfCode_Code.Text & "'"
        Dim Filter_Condition_B = " AND A.OP3 ='" & txtAcOfCode_Code.Text & "'"
        tblTmp = Packing_GreyStockReprt.GetGreyStockQuery(Filter_Condition, Filter_Condition_B, "", "", "", "ENTRY", 0)
        GridView1.Columns.Clear()
        If tblTmp.Rows.Count > 0 Then
            For Each dr As DataRow In tblTmp.Select()
                If Not IsDBNull(dr("Pkt")) AndAlso IsNumeric(dr("Pkt")) Then
                    dr("Pkt") = Convert.ToInt32(dr("Pkt")).ToString("0")
                End If
                If Not IsDBNull(dr("Bundle")) AndAlso IsNumeric(dr("Bundle")) Then
                    dr("Bundle") = Convert.ToInt32(dr("Bundle")).ToString("0")
                End If
                If Not IsDBNull(dr("Sheets")) AndAlso IsNumeric(dr("Sheets")) Then
                    dr("Sheets") = Convert.ToInt32(dr("Sheets")).ToString("0")
                End If
                If Not IsDBNull(dr("BalSheet")) AndAlso IsNumeric(dr("BalSheet")) Then
                    dr("BalSheet") = Convert.ToDecimal(dr("BalSheet")).ToString("0.00")
                End If
                If Not IsDBNull(dr("SheetAvgWt")) AndAlso IsNumeric(dr("SheetAvgWt")) Then
                    dr("SheetAvgWt") = Convert.ToDecimal(dr("SheetAvgWt")).ToString("0.00000")
                End If
            Next
            'If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
            GridControl2.DataSource = tblTmp.Copy
            'Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl2.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            'repositoryCheckEdit1.ValueChecked = "True"
            'repositoryCheckEdit1.ValueUnchecked = "False"
            'GridView1.Columns("TickMark").ColumnEdit = repositoryCheckEdit1
            'GridView1.Columns("TickMark").Width = 30
            GridView1.Columns("BookVno").Visible = False
            GridView1.Columns("ItemCode").Visible = False
            GridView1.Columns("VendorCode").Visible = False
            GridView1.Columns("GsmCalculation").Visible = False
            'GridView1.Columns("GroupName").Visible = False
            GridView1.Columns("GroupCode").Visible = False
            GridView1.Columns("COMP_ADD1").Visible = False
            GridView1.Columns("COMP_ADD2").Visible = False
            GridView1.Columns("COMP_ADD3").Visible = False
            GridView1.Columns("COMP_ADD4").Visible = False
            GridView1.Columns("COMP_TIN").Visible = False
            GridView1.Columns("COMP_TEL_NO").Visible = False
            GridView1.Columns("COMP_EMAIL").Visible = False
            GridView1.Columns("HSNCode").Visible = False
            GridView1.Columns("TickMark").Visible = False
            GridView1.Columns("GstPer").Visible = False
            GridView1.Columns("ACOFCODE").Visible = False
            GridView1.Columns("SizeL").Visible = False
            GridView1.Columns("SizeW").Visible = False
            DevGridFitColumn(GridControl2, GridView1)
            PnlPendingChallan.Visible = True
            GridView1.Focus()
            PnlPendingChallan.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            PnlPendingChallan.Visible = False
            GrdItem.Focus()
        End If
    End Sub
    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        If e.KeyCode = Keys.Escape Then PnlPendingChallan.Visible = False
        If e.KeyCode = Keys.Enter Then
            Dim ChallanNo As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ChalNo").ToString()
            Dim ChallanNoBookvno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BookVno").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP1") + 1).Text = ChallanNo
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP2") + 1).Text = ChallanNoBookvno
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemCode").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "GsmCalculation").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("GROUPNAME") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "GroupName").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "GroupCode").ToString()
            'GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Size").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("HEADERMTR_Bal") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SheetAvgWt").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DELVDAYS") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SizeL").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NO_OF_SET") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SizeW").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP12") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Gsm").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP13") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Bundle").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP14") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Pkt").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP15") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Sheets").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("HEADERMTR") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BalSheet").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DELIVERYCODE") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "VendorCode").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("VENDORNAME") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Vendor").ToString()
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OP5") + 1).Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remark").ToString()
            Total_Upto_All_Grid_All_Row()
            PnlPendingChallan.Visible = False
            GrdItem.Focus()
        End If
    End Sub
    Private Sub Txt_ByerName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ByerName.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub

        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            'Party_selection.txtSearch.Text = Txt_ByerName.Text
            'Call obj_Party_Selection.Account_Selection()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    Txt_ByerName.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtByerCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            'End If
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccountvendorcode_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), Txt_ByerName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtByerCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then Txt_ByerName.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If

    End Sub
    Private Sub Txt_CuttingSize_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CuttingSize.KeyDown
        'If e.KeyCode = Keys.Escape Then Exit Sub

        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
        '    Party_selection.txtSearch.Text = Txt_CuttingSize.Text
        '    Call obj_Party_Selection.Single_size_Selection()
        '    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
        '        Txt_CuttingSize.Text = MULTY_SELECTION_COLOUM_1_DATA
        '        txtCuttingSizeCode.Text = MULTY_SELECTION_COLOUM_3_DATA
        '    End If
        '    SendKeys.Send("{tab}")
        'End If
    End Sub
    Private Sub Txt_JobSize_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_JobSize.KeyDown
        'If e.KeyCode = Keys.Escape Then Exit Sub

        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
        '    Party_selection.txtSearch.Text = Txt_JobSize.Text
        '    Call obj_Party_Selection.Single_size_Selection()
        '    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
        '        Txt_JobSize.Text = MULTY_SELECTION_COLOUM_1_DATA
        '        txtJobSizeCode.Text = MULTY_SELECTION_COLOUM_3_DATA
        '    End If
        '    SendKeys.Send("{tab}")
        'End If
    End Sub
    'Private Sub Txt_Size_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Size.KeyDown
    '    If e.KeyCode = Keys.Escape Then Exit Sub

    'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
    '    Party_selection.txtSearch.Text = Txt_Size.Text
    '    Call obj_Party_Selection.SINGLE_storeItem_SELECTION()
    '    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
    '        Txt_Size.Text = MULTY_SELECTION_COLOUM_1_DATA
    '        'txtSizeCode.Text = MULTY_SELECTION_COLOUM_3_DATA
    '    End If
    '    SendKeys.Send("{tab}")
    'End If
    'End Sub
    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        _SelectImage()
    End Sub

    Private Sub _SelectImage()
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            txtIamgePath.Text = fileName
            'txtIamgePath.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            PictureBox1.ImageLocation = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
            PictureBox1.Load()



            Dim pathSource As String = OpenFileDialog1.FileName


            Dim _FolderName As String = "Image"
            Dim strServerName = _FolderFilePath(_FolderName)
            Dim sSource As String = pathSource

            If sSource = "OpenFileDialog1" Then Exit Sub
            Dim sTarget As String = strServerName & fileName
            Dim folder As String = strServerName
            If Not System.IO.Directory.Exists(folder) Then
                System.IO.Directory.CreateDirectory(folder)
            End If
            File.Copy(sSource, sTarget, True)
        Else
            ' Optional: clear previous image or message
            'txtIamgePath.Text = ""
            'PictureBox1.Image = DefaltimageName
        End If

    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown

        If e.KeyCode = Keys.Escape Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            Dim _ActBookvno As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "BOOKVNO").ToString()
            If _ActBookvno <> "" Then
                UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("_FORMMODE")
                PNL_View.Visible = False
                _FORMMODE = "EDIT"
                _BookVNo = _ActBookvno
                Alter_Form(_ActBookvno)
                txtChallanDate.Focus()
                txtChallanDate.Select()
                Total_Upto_All_Grid_All_Row()
                Exit Sub
            End If
        End If
    End Sub
End Class