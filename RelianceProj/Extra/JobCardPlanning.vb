Imports System.IO
Imports System.Text
Imports DevExpress.Utils

Public Class JobCardPlanning
    Private _ColNames As New StringBuilder
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

#Region "GENERAL VARIABLE DECLARE "
    Private Last_Saved_Entry_No As Integer = 0

    Private _FrmLoad As Boolean = True
    Private WithEvents txtSalesman_code As New TextBox
    Private WithEvents txtAgent_code As New TextBox
    Private WithEvents txtAccount_Code As New TextBox
    Private WithEvents txtpaper_Code As New TextBox
    Private WithEvents txtpaperform_Code As New TextBox
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
    Private _KeyFieldName As String = "BOOKVNO"
    Private _TblName As String = "TrnReadyMadeProducation"
    Private tblFormValues As New DataTable
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _BookTrType As String = ""
    Private _BookCode As String = ""
    Private _BookVNo As String = ""
    Dim _lblEntryDate As String
    Private FieldNameAndValues(1) As String
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
#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("ENTRYNO,")
            .Append("BOOKTRTYPE,")
            .Append("BOOKVNO,")
            .Append("BOOKCODE,")
            .Append("CHALLAN_NO,")
            .Append("CHALLAN_DATE,")
            .Append("ACCOUNTCODE,")
            .Append("OP3,")
            .Append("DESIGNCODE,")
            .Append("SHADECODE,")
            .Append("LOTNO,")
            .Append("MONOGRAM_TYPE,")
            .Append("IMAGEPATH,")
            .Append("BATCHNO,")
            .Append("ITEMCODE,")
            .Append("HEADERREMARK,")
            .Append("TOTALMTR,")
            .Append("OP4,") 'Paper form
            .Append("OP5,") ' Paper
            .Append("OP7,") ' Machine size
            .Append("OP8") ' Remark
        End With
    End Sub
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

                If PNL_View.Visible = True Then
                    PNL_View.Visible = False
                    'Command_Button_Visibility("LOAD")
                    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visible_False(Me.Controls)
                    Exit Sub
                End If
                Select Case _STRTRNOBJECT
                    Case "GRID_RATE_DISP"


                    Case "TXTCHALLANDATE"
                        _FrmLoad = False
                        txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                        _FORMMODE = ""
                        ObjCls_General.Blank_Object(Me)
                        txtChallanDate.Text = ObjCls_General.GetTodayDate_British

                        _KeyFieldValue = 0
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                    Case Else
                        _FrmLoad = True
                        _FORMMODE = ""
                        ObjCls_General.Blank_Object(Me)
                        txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                        _KeyFieldValue = 0
                        Ctrl_Visible_False(Me.Controls)
                        UC_Buttons1._ButtonEnableDisable("LOAD")
                        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                        _FrmLoad = False
                End Select
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT
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
                    End If
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
        _FrmLoad = True
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")
        _old_Me_text = Me.Text

        If ReqStoreCategory = "NO" Or ReqStoreCategory = "N" Then
            UseItemHead = "NO"
        Else
            UseItemHead = "YES"
        End If

        If _isCallerByOther = True Then
            Call Alter_Form(_KeyFieldValue)
        End If
        'PictureBox1.Image = DefaltimageName
        _FrmLoad = False
        Me.Location = New Point(0, 0)
        Book_Name = "JobCardPlanning"
        txtBookCode.Text = "0001-000000001"
        _BookTrType = "JOBCPLAN0001"
        _BookCode = txtBookCode.Text
        AutoResizeGrid(PNL_View, GridControl1)
        Ctrl_Visible_False(Me.Controls)
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports")
    End Sub
#End Region

#Region "Button Click"
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
        Call Ctrl_Visible_True(Me.Controls)
        txtBookName_Validated()
        txtEntryNo.Focus()
        PictureBox1.ImageLocation = ""
        'txtEntryNo.Select()
        _FrmLoad = True
    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        Edit_From_View = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Call Ctrl_Visible_True(Me.Controls)
        Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        _FrmLoad = False
        _FORMMODE = "EDIT"
        Last_Focused_Btn = "EDIT"
        txtEntryNo.Visible = True
        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0))
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
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
        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0))
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If _FORMMODE = "DELETE" Then
            If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                Delete_Record()
                MsgBox("Records Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            End If
        End If
        txtBookCode.Text = Book_Code
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        _FORMMODE = "EDIT"
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) - 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            Call Validate_Entry_No(Book_Vno, _ChallanTableName)
            Call Ctrl_Visible_True(Me.Controls)
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        _FORMMODE = "EDIT"
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) + 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            Call Ctrl_Visible_True(Me.Controls)
            Call Validate_Entry_No(Book_Vno, _ChallanTableName)
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        End If
    End Sub

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
            _KeyFieldValue = 0
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
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
        Call View_Record()
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
            Dim TblTmp As New DataTable
            sqL = GetMaxCode()
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

#Region "DELETE CODE"
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
#Region "TXT BOX ENTRY NO EVENT CODE "
    Private Sub txtEntryNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntryNo.Validated
        If _FrmLoad = True Then Exit Sub

        If Val(txtEntryNo.Text) = 0 Then
            If _FORMMODE = "ADD" Then
                MsgBox("Invalid Entry No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
                Exit Sub
            End If
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
                UC_Buttons1._ButtonEnableDisable(_FORMMODE)
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                _FrmLoad = False
                txtChallanNo.Focus()
                txtChallanNo.Select()
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
                MsgBox("Entry No " + Trim(txtEntryNo.Text) + " Not Found")
                txtEntryNo.Visible = True
                txtEntryNo.Focus()
                txtEntryNo.Select()
            Else
                If _BookCode = "0001-000000153" Then
                    If _FORMMODE = "ADD" Then
                        txtChallanNo.Text = txtEntryNo.Text
                        'txtChallanDate.Text = txtGR_Date.Text
                        'txtGR_No.Text = txtEntryNo.Text
                        Generate_Date_For_DataBase(txtChallanDate)
                    End If
                End If
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
            .Append(" I.ACCOUNTNAME AS BuyerName , ")
            .Append(" K.ItemName AS PRODITEMNAME , ")
            .Append(" M.GroupName,  ")
            .Append(" N.ACCOUNTNAME AS VenderName , ")
            .Append(" O.ACCOUNTNAME AS PaperForm , ")
            .Append(" P.ACCOUNTNAME AS Paper, ")
            .Append(" G.subItemName AS FINISHQUALITY ")
            .Append(" FROM TrnReadyMadeProducation AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem F ON A.ITEMCODE=F.ITEMCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply H ON A.OP3=H.ID ")
            .Append(" LEFT JOIN MstMasterAccount I ON A.DESIGNCODE=I.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem K ON A.PRODITEMCODE=K.ItemCode ")
            .Append(" LEFT JOIN MstStoreItemGroup M ON A.COLORCODE=M.GroupCode  ")
            .Append(" LEFT JOIN MstMasterAccount AS N ON A.DELIVERYCODE=N.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstStoreSubItem G  ON  A.OP6=G.subItemCode ")
            .Append(" LEFT JOIN MstMasterAccount O  ON  A.OP4=O.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstMasterAccount P  ON  A.OP5=P.ACCOUNTCODE ")
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
        Dim tblTmp As New DataTable
        sqL = getAlter_Form_Query_Details(strKeyID)
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        tblFormValues.Rows.Clear()
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues.ImportRow(dr)
        Next
        _KeyFieldValue = tblTmp.Rows(0)("BOOKVNO").ToString
        txtEntryNo.Text = tblTmp.Rows(0)("entryno").ToString
        txtAccountName.Text = tblTmp.Rows(0)("ACCOUNTNAME").ToString
        txtChallanNo.Text = tblTmp.Rows(0)("CHALLAN_NO").ToString
        txtChallanDate.Text = tblTmp.Rows(0)("F_CHALLAN_DATE").ToString
        txtHeader_Remark.Text = tblTmp.Rows(0)("HEADERREMARK").ToString
        Txt_PrintQty.Text = tblTmp.Rows(0)("TOTALMTR").ToString
        txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        Txt_ByerName.Text = tblTmp.Rows(0)("BUYERNAME").ToString
        Txt_CuttingSize.Text = tblTmp.Rows(0)("SHADECODE").ToString
        Txt_JobSize.Text = tblTmp.Rows(0)("LOTNO").ToString
        txtByerCode.Text = tblTmp.Rows(0)("DESIGNCODE").ToString
        txtItemCode.Text = tblTmp.Rows(0)("ITEMCODE").ToString
        Txt_Size.Text = tblTmp.Rows(0)("MONOGRAM_TYPE").ToString
        txtIamgePath.Text = tblTmp.Rows(0)("IMAGEPATH").ToString
        Txt_LaminDrip.Text = tblTmp.Rows(0)("BATCHNO").ToString
        Txt_AcoFName.Text = tblTmp.Rows(0)("AC_NAME").ToString
        txtAcOfCode_Code.Text = tblTmp.Rows(0)("OP3").ToString
        txtpaperform.Text = tblTmp.Rows(0)("PaperForm").ToString
        txtpaperform_Code.Text = tblTmp.Rows(0)("OP4").ToString
        txtpaper.Text = tblTmp.Rows(0)("Paper").ToString
        txtpaper_Code.Text = tblTmp.Rows(0)("OP5").ToString
        txtMachinesize.Text = tblTmp.Rows(0)("OP7").ToString
        txtRemark.Text = tblTmp.Rows(0)("OP8").ToString
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

#Region "Account Name Txt Box Events "
    Private Sub txtAccountName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountName.KeyPress
        If Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select(_FilterAccountcode)
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
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.SINGLE_ACC_OF_SELECTION(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Ac_master_info_frm), Txt_AcoFName.Text, "SINGLE")
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


#Region " Txt Header Remark Events "
    Private Sub Txt_PrintQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PrintQty.KeyDown
        If _FrmLoad = True Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            _SelectImage()
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
        If IsEntryDateLocked(txtChallanDate.Text) Then Exit Sub

        If txtAcOfCode.Text = "" Then txtAcOfCode.Text = "0000-000000001"
        If txtTr_code.Text = "" Then txtTr_code.Text = "0001-000000091"
        If txtUnitCode.Text = "" Then txtUnitCode.Text = "0001-000000091"
        If txtAccount_Code.Text = "" Then txtAccount_Code.Text = "0001-000000091"
        If txtVandorCode.Text = "" Then txtVandorCode.Text = "0001-000000091"
        If txtAcOfCode_Code.Text = "" Then txtAcOfCode_Code.Text = "0001-000000091"
        If txtItemCode.Text = "" Then txtItemCode.Text = "0001-000000001"
        If Txt_PrintQty.Text.Trim = "" Then Txt_PrintQty.Text = "0"
        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)
        Generate_Date_For_DataBase(txtChallanDate)
        Dim _LastID As Integer = -1
        Try

            Dim LASTCODE As String = ""
            If _FORMMODE = "ADD" Then
                strQuery = "DELETE FROM TrnReadyMadeProducation WHERE 1=1 AND BOOKVNO ='" & _BookVNo & "' and EntryNo='" & txtEntryNo.Text & "' "
                sqL = strQuery
                sql_Data_Save_Delete_Update()
                sqL = GetMaxCode()
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    LASTCODE = Val(DefaltSoftTable.Rows(0).Item("EntryNO")) + 1
                    txtEntryNo.Text = LASTCODE
                Else
                    LASTCODE = "1"
                    txtEntryNo.Text = LASTCODE
                End If
            Else
                'LASTCODE = _KeyFieldValue
                tblFormValues.Rows(0)(_KeyFieldName) = _BookVNo
            End If

            tblFormValues.Rows(0)("EntryNo") = txtEntryNo.Text
            tblFormValues.Rows(0)("BOOKTRTYPE") = _BookTrType
            tblFormValues.Rows(0)("BOOKCODE") = _BookCode
            tblFormValues.Rows(0)("BOOKVNO") = _BookVNo
            tblFormValues.Rows(0)("CHALLAN_NO") = txtChallanNo.Text
            If _FORMMODE = "ADD" Then
                tblFormValues.Rows(0)("CHALLAN_DATE") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
            End If
            If _FORMMODE = "EDIT" Then
                tblFormValues.Rows(0)("CHALLAN_DATE") = _lblEntryDate
            End If
            tblFormValues.Rows(0)("ACCOUNTCODE") = txtAccount_Code.Text
            tblFormValues.Rows(0)("OP3") = txtAcOfCode_Code.Text
            tblFormValues.Rows(0)("DESIGNCODE") = txtByerCode.Text
            tblFormValues.Rows(0)("SHADECODE") = Txt_CuttingSize.Text
            tblFormValues.Rows(0)("LOTNO") = Txt_JobSize.Text
            tblFormValues.Rows(0)("ITEMCODE") = txtItemCode.Text
            tblFormValues.Rows(0)("MONOGRAM_TYPE") = Txt_Size.Text
            tblFormValues.Rows(0)("IMAGEPATH") = txtIamgePath.Text
            tblFormValues.Rows(0)("BATCHNO") = Txt_LaminDrip.Text
            tblFormValues.Rows(0)("HEADERREMARK") = txtHeader_Remark.Text
            tblFormValues.Rows(0)("TOTALMTR") = Txt_PrintQty.Text
            tblFormValues.Rows(0)("OP4") = txtpaperform_Code.Text
            tblFormValues.Rows(0)("OP5") = txtpaper_Code.Text
            tblFormValues.Rows(0)("OP7") = txtMachinesize.Text
            tblFormValues.Rows(0)("OP8") = txtRemark.Text
            'ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
            ObjCls_General.MAKEQUERYFROMDATATABLE(Me._FORMMODE, Me.tblFormValues, Me.FieldNameAndValues, "", "", "")
            sqL = getSaveQuery()
            sql_Data_Save_Delete_Update()
#Region "Edit Log Save"
            Dim _EntryType As String = "Delete"
            _EditLog(_EntryType)
#End Region
            If _FORMMODE = "ADD" Then
                MsgBox("Record Successfully Saved!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            ElseIf _FORMMODE = "EDIT" Then
                MsgBox("Record Successfully Edited!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            End If
            Old_Date = txtChallanDate.Text
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            ObjCls_General.Blank_Object(Me)
            txtChallanDate.Text = Old_Date
            Ctrl_Visible_False(Me.Controls)
            AttachButtonFocusEvents(Me)
            UC_Buttons1._ButtonEnableDisable("LOAD")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub _EditLog(ByVal _EntryType As String)
        Dim BookType As String = "Job Card Planning"
        Dim _Item As String = ""
        Dim _Rate As String = ""
        Dim _qty As String = ""
        Dim _Rateon As String = ""
        Dim _ItemDetail As String = ""
        Dim _BarcodeNo As String = ""
        Dim _EditReason As String = ""
        Dim _PartyGstinno As String = ""
        _SaveUserEditLog(txtBookCode.Text, BookType, BookType, txtEntryNo.Text, "", CDate(Date.Now).ToString(), "", "", "", 0.00, _USERNAME, _EntryType, _EditReason, CDate(Date.Now).ToString("yyyy-MM-dd"), _BookVNo, _ItemDetail, CDate(Date.Now).ToString("yyyy-MM-dd"), txtRemark.Text, _PartyGstinno)
    End Sub
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "' and EntryNo='" & txtEntryNo.Text & "'")
        End If
        getSaveQuery = _strQuery.ToString
    End Function
    Public Function GetMaxCode() As String
        GetMaxCode = Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function
    Public Function Master_GetMaxCode(ByVal _KeyFieldName As String, ByVal _TblName As String, ByVal _SELECTEDCOMPANYCODE As String) As String
        strQuery = " SELECT  TOP 1 EntryNo  FROM " & _TblName & " ORDER BY " & _KeyFieldName & " DESC "
        Return strQuery.ToString
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
            .Append("O.ACCOUNTNAME as PaperForm,")
            .Append("P.ACCOUNTNAME as Paper,")
            .Append(" a.OP7 as MachineSize , ")
            .Append(" a.OP8 as Remark , ")
            .Append(" F.ItemName , ")
            .Append("A.OP1 as VenderChNo,")
            .Append("K.ItemName AS FinishItem , ")
            .Append("A.OP4 as FinishSize,")
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
            .Append(" LEFT JOIN MstMasterAccount AS N ON A.DELIVERYCODE=N.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS O ON A.OP4=O.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS P ON A.OP5=P.ACCOUNTCODE  ")
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
            AlignGroupSummaryAuto(FirstStage, columnNames)
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
    Private Sub Txt_ByerName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ByerName.KeyDown
        If e.KeyCode = Keys.Escape Then Exit Sub
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), Txt_ByerName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtByerCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then Txt_ByerName.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If

    End Sub

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
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Delete_Record()
        Dim _entryNo As Integer = 0
        _strQuery = New StringBuilder
        With _strQuery
            .Append("DELETE FROM " & _TblName & " WHERE EntryNO='" & txtEntryNo.Text & "' ")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub

    Private Sub txtpaperform_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpaperform.KeyPress
        If Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtpaperform.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtpaperform_Code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then txtpaperform.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub txtpaper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpaper.KeyPress
        If Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            Dim _FilterAccountcode As String = ""
            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select(_FilterAccountcode)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtpaper.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtpaper_Code.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then txtpaper.Text = selected("AccountName").ToString()
            End If
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class