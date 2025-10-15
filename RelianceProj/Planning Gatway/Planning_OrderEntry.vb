Imports System.ComponentModel
Imports System.Text


Friend Class Planning_OrderEntry


    Private obj_Party_Selection As New Multi_Selection_Master

#Region "VARIABLE DECLARATION"
    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "BOOKVNO"
    Private _TblName As String = "TRNOFFER"
    Private _FrmLoad As Boolean = False
    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtAlter_Name As New TextBox

    Private WithEvents txt_ItemCode As New TextBox
    Private WithEvents txt_DesignCode As New TextBox
    Private WithEvents txt_ShadeCode As New TextBox
    Private WithEvents txtBookCode As New TextBox

    Private WithEvents txtSelvCode As New TextBox
    Private WithEvents txtDesignCode As New TextBox
    Private WithEvents txtShadeCode As New TextBox
    Private WithEvents txtLoomCode As New TextBox
    Public WithEvents txtItemCode As New TextBox
    Private WithEvents txtPartyCode As New TextBox
    Private WithEvents txtAgentCode As New TextBox

    Private DispList As Boolean = True
    Private Is_Call_By_Another As Boolean = False

    Private Last_Focused_Btn As String = ""
    Dim old_Me_text As String = ""

    Public _BookTrType As String = ""
    Private _BookCode As String = ""
    Private _BookVNo As String = ""
    Private AcCode_Filter_String As String = ""
    Private Book_Row As DataRow


    Private WithEvents txt_Reed As New TextBox
    Private WithEvents txt_Dent As New TextBox
    Private WithEvents txt_Pick As New TextBox
    Private WithEvents txt_ReedSpace As New TextBox
    Private WithEvents txt_Westage As New TextBox
    Private WithEvents Txt_NoOfPcs As New TextBox
    Private WithEvents txt_AvgWeight As New TextBox

#End Region

#Region "QUERY SECTION"

    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "'")
        End If
        getSaveQuery = _strQuery.ToString
    End Function
#End Region

#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("AVGWEIGHT,")
            .Append("ENTRYNO,")
            .Append("BOOKVNO,")
            .Append("BOOKTRTYPE,")
            .Append("BOOKCODE,")
            .Append("OFFERNO,")
            .Append("OFFERDATE,")
            .Append("ACCOUNTCODE,")
            .Append("PARTYOFFERNO,")
            .Append("AGENTCODE,")
            .Append("AGENTOFFERNO,")
            .Append("DESIGNNO,")
            .Append("DESCR,")
            .Append("LOTNO,")
            .Append("ITEMCODE,")
            .Append("REED,")
            .Append("DENT,")
            .Append("PICK,")
            .Append("REEDSPACE,")
            .Append("WESTAGE,")
            .Append("NO_OF_SET,")
            .Append("NO_OF_BEAM,")
            .Append("MTR_WEIGHT,")
            .Append("PICK_RATE,")
            .Append("MENDING_CHG,")
            .Append("EXTRA_CHG,")
            .Append("YARN_DELV_DATE,")
            .Append("LOOM_TYPE,")
            .Append("MONOGRAM_TYPE,")
            .Append("SELVCODE,")
            .Append("HEADERREMARK,")
            .Append("NO_OF_DESING,")
            .Append("NO_OF_SHADE,")
            .Append("despatchtocode,")
            .Append("processcode")
            .Append(",ACOFCODE")
            .Append(",TransportCode")
            .Append(",DespatchCode")
            .Append(",CutCode")
            .Append(",DesignCode")
            .Append(",ShadeCode")
            .Append(",clear")
            .Append(",cancel_Qty")
            .Append(",Rate")
            .Append(",Pcs_Bales")
            .Append(",PymtDays")
            .Append(",QTYMTR")
            .Append(",YARN_LOT_NO")
            .Append(",OP16")
            .Append(",RDVALUE")
            .Append(",OP10") ' USER ID
        End With
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub Transport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim x As Integer
        Dim y As Integer
        x = 0
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        Me.Location = New Point(x, y)


        PNL_View.Width = Me.Width
        PNL_View.Height = Me.Height
        GridControl1.Height = PNL_View.Height - 100
        GridControl1.Width = PNL_View.Width - 20
        PNL_View.Location = New Point(0, 0)

        old_Me_text = Me.Text
        _FrmLoad = True
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")
        Call Command_Button_Visibility("LOAD")
        Ctrl_Visible_False(Me.Controls)
        btnAdd.Focus()
        btnAdd.Select()
        _FrmLoad = False

        AttachButtonFocusEvents(Me)

    End Sub

    Private Sub _closeMenu()

        If LEDGER_ENTER_DISPLAY_FROM = "_CallOther" Then
            Me.Close()
            Me.Dispose(True)
            LEDGER_ENTER_DISPLAY_FROM = ""
        Else
            Me.Close()
            Me.Dispose(True)
        End If

    End Sub
    Private Sub Transport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)

        If e.KeyCode = Keys.Escape Then

            If PNL_View.Visible = True Then
                PNL_View.Visible = False
                btnView.Enabled = True
                btnView.Focus()
                Exit Sub
            End If


            _FrmLoad = True
            If _FORMMODE = "" Then
                _closeMenu()
            ElseIf _FORMMODE <> "" Then
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                Call Command_Button_Visibility("LOAD")
                Call Ctrl_Visible_False(Me.Controls)
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                _FrmLoad = False
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            If Mid(_STRTRNOBJECT, 1, 3) = "TXT" Then
                btnSave.Focus()
                btnSave.Select()
            Else
                txt_OfferNo.Focus()
                txt_OfferNo.Select()

            End If
        End If

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
        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNEDIT" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        End If
        If pub_User_add = "N" Then
            btnAdd.Enabled = False
        End If

        If pub_User_modify = "N" Then
            btnModify.Enabled = False
        End If

        If pub_User_delete = "N" Then
            btnDelete.Enabled = False
        End If

        If pub_User_view = "N" Then
            btnView.Enabled = False
        End If

        If pub_User_print = "N" Then
            'btnPrint.Enabled = False
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
        End If
    End Sub
#End Region



#Region "BTN CLICK/ENTER CODE"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If _FORMMODE = "" Then
            _closeMenu()
        Else
            If _FORMMODE = "VIEW" Then
                _FORMMODE = ""
                PNL_View.Visible = False
                Call Command_Button_Visibility("LOAD")
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Me.Text = old_Me_text
            Else
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
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
        'Call View_Record()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
        End If
    End Sub
    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"
        Call Command_Button_Visibility("BTNADD")
        Call Ctrl_Visible_True(Me.Controls)

        txt_Loom_Type.Text = "SINGLE"
        Txt_Moredetail.Text = "NO"

        txtChallanDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        txtBookName.Focus()
        txtBookName.Select()
    End Sub
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Last_Focused_Btn = "MODIFY"
        _FORMMODE = "EDIT"
        txtAlter_code.Text = ""
        Txt_Moredetail.Text = "NO"

        Call Command_Button_Visibility("BTNEDIT")
        Call Ctrl_Visible_True(Me.Controls)

        txtBookName.Focus()
        txtBookName.Select()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        _FrmLoad = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        txtAlter_code.Text = ""
        Call Command_Button_Visibility("BTNDELETE")
        Call Ctrl_Visible_True(Me.Controls)


        txtBookName.Focus()
        txtBookName.Select()
    End Sub


#End Region


#Region "ENTRY NO VALIDATING"
    Private Sub txt_ENTRYNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_EntryNo.Validated
        If _FrmLoad = True Then Exit Sub

        ENTRYNO_Validated()

    End Sub
    Public Sub ENTRYNO_Validated()

        _BookVNo = Generate_Book_Vno(Val(txt_EntryNo.Text), _BookTrType)

        Dim Str_Qry As String = " SELECT * FROM TRNOFFER WHERE BOOKVNO='" & _BookVNo & "' "

        Dim dtTmp As New DataTable

        sqL = Str_Qry
        sql_connect_slect()
        dtTmp = DefaltSoftTable.Copy



        If _FORMMODE = "ADD" Then
            If dtTmp.Rows.Count > 0 Then
                MsgBox("Entry No. Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txt_EntryNo.Focus()
                txt_EntryNo.Select()
            Else
                txt_OfferNo.Text = txt_EntryNo.Text
            End If
        ElseIf _FORMMODE = "MODIFY" Or _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
            If dtTmp.Rows.Count > 0 Then

                txt_OfferNo.Text = dtTmp.Rows(0)("ENTRYNO").ToString
                Str_Qry = obj_Party_Selection.EntryData_Job_Offer_Entry_txt_ENTRYNO_Validated(_BookVNo)

                sqL = Str_Qry
                sql_connect_slect()
                dtTmp = DefaltSoftTable.Copy

                If dtTmp.Rows.Count > 0 Then
                    Ctrl_Visible_True(Me.Controls)
                    tblFormValues.Rows.Clear()
                    For Each dr As DataRow In dtTmp.Rows
                        tblFormValues.ImportRow(dr)
                    Next
                    ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblFormValues)
                    If dtTmp.Rows.Count > 0 Then
                        txtBookName.Text = dtTmp.Rows(0)("BOOKNAME").ToString
                        txtBookCode.Text = dtTmp.Rows(0)("BOOKCODE").ToString
                        _BookCode = txtBookCode.Text
                        txt_PartyName.Text = dtTmp.Rows(0)("PARTYNAME").ToString
                        txtChallanDate.Text = dtTmp.Rows(0)("F_OFFERDATE").ToString
                        Txt_RollingCharge.Text = dtTmp.Rows(0)("RDVALUE").ToString
                        txtItemCode.Text = dtTmp.Rows(0)("ITEMCODE").ToString
                        txtDesignCode.Text = dtTmp.Rows(0)("DESIGNCODE").ToString
                        txtShadeCode.Text = dtTmp.Rows(0)("SHADECODE").ToString
                        txtAgentCode.Text = dtTmp.Rows(0)("AGENTCODE").ToString
                        txtPartyCode.Text = dtTmp.Rows(0)("ACCOUNTCODE").ToString
                        txtSelvCode.Text = dtTmp.Rows(0)("SELVCODE").ToString
                        txtChallanDate.Text = dtTmp.Rows(0)("F_OFFERDATE").ToString
                        Txt_PlanningNo.Text = dtTmp.Rows(0)("OP16").ToString
                        txtLoomCode.Text = dtTmp.Rows(0)("YARN_LOT_NO").ToString

                        txt_Reed.Text = dtTmp.Rows(0)("REED").ToString
                        txt_Dent.Text = dtTmp.Rows(0)("DENT").ToString
                        txt_Pick.Text = dtTmp.Rows(0)("PICK").ToString
                        txt_ReedSpace.Text = dtTmp.Rows(0)("REEDSPACE").ToString
                        txt_Westage.Text = dtTmp.Rows(0)("WESTAGE").ToString
                        Txt_NoOfPcs.Text = dtTmp.Rows(0)("PymtDays").ToString
                        txt_AvgWeight.Text = dtTmp.Rows(0)("AVGWEIGHT").ToString

                    End If

                    txt_Mtr_Weight.Text = Format(Val(txt_Mtr_Weight.Text), "0.00")
                    txt_Pick_Rate.Text = Format(Val(txt_Pick_Rate.Text), "0.0000")
                    txt_Mending_Chg.Text = Format(Val(txt_Mending_Chg.Text), "0.00")
                    txt_Extra_Chg.Text = Format(Val(txt_Extra_Chg.Text), "0.00")
                    Txt_RollingCharge.Text = Format(Val(Txt_RollingCharge.Text), "0.00")

                    Generate_Date_For_DataBase(txtChallanDate)

                End If

                If _FORMMODE = "DELETE" Then
                    Ctrl_Visible_True(Me.Controls)
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Call Delete_Record()
                        MsgBox("Offer Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    End If
                    _FORMMODE = ""
                    ObjCls_General.Blank_Object(Me)
                    _KeyFieldValue = 0
                    txtChallanDate.Text = USERDATE_FinYearStartDate
                    Command_Button_Visibility("LOAD")
                    Ctrl_Visible_False(Me.Controls)
                    Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                    'Else
                    '    txtChallanDate.Focus()
                    '    txtChallanDate.Select()
                End If
            Else
                MsgBox("Offer No. Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txt_OfferNo.Focus()
                txt_OfferNo.Select()
            End If
        End If

    End Sub
#End Region


#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If txt_PartyName.Text = "" Then
            MsgBox("Enter Party Name")
            txt_PartyName.Focus()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function
#End Region

#Region "SAVE METHOD"
    Private Sub SaveRecord()

        If CheckCpuId = "VIEW" Then
            MsgBox("Software View Mode Save Function Not Work", MsgBoxStyle.Critical, "Soft-Tex PRO")
            Exit Sub
        End If


        If Validate_Form_Values() = False Then Exit Sub
        Dim CompleteQuery As String = ""
        Dim SaveQuery As String = ""
        Dim strQuery As String = ""
        Dim LASTCODE As String = ""
        If Val(txt_Dent.Text) = 0 Then
            txt_Dent.Text = "0"
        End If
        If Val(txt_Reed.Text) = 0 Then
            txt_Reed.Text = "0"
        End If
        If Val(txt_Pick.Text) = 0 Then
            txt_Pick.Text = "0"
        End If
        If Val(txt_Pick_Rate.Text) = 0 Then
            txt_Pick_Rate.Text = "0"
        End If
        If Val(txt_Westage.Text) = 0 Then
            txt_Westage.Text = "0"
        End If

        If Val(txt_AvgWeight.Text) = 0 Then
            txt_AvgWeight.Text = "0"
        End If

        If Val(txt_Mending_Chg.Text) = 0 Then
            txt_Mending_Chg.Text = "0"
        End If

        If Val(txt_Extra_Chg.Text) = 0 Then
            txt_Extra_Chg.Text = "0"
        End If

        If Val(txt_No_Of_Beam.Text) = 0 Then
            txt_No_Of_Beam.Text = "0"
        End If

        If Val(txt_No_Of_Set.Text) = 0 Then
            txt_No_Of_Set.Text = "0"
        End If

        If Val(txt_Mtr_Weight.Text) = 0 Then
            txt_Mtr_Weight.Text = "0"
        End If

        If Val(Ttx_CutMtrs.Text) = 0 Then
            Ttx_CutMtrs.Text = "0"
        End If

        If Val(Txt_NoOfPcs.Text) = 0 Then
            Txt_NoOfPcs.Text = "0"
        End If


        LASTCODE = txt_EntryNo.Text
        tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
        _KeyFieldValue = _BookVNo

        If txtAgentCode.Text = "" Then txtAgentCode.Text = "0000-000000001"
        If txtDesignCode.Text = "" Then txtDesignCode.Text = "0000-000000001"
        If txtShadeCode.Text = "" Then txtShadeCode.Text = "0000-000000001"
        If txtLoomCode.Text = "" Then txtLoomCode.Text = "0000-000000001"
        If txtSelvCode.Text = "" Then txtSelvCode.Text = "0000-000000001"
        If Txt_RollingCharge.Text = "" Then Txt_RollingCharge.Text = "0.00"


        Generate_Date_For_DataBase(txtChallanDate)


        tblFormValues.Rows(0)("ITEMCODE") = txtItemCode.Text
        tblFormValues.Rows(0)("BOOKTRTYPE") = _BookTrType
        tblFormValues.Rows(0)("BOOKCODE") = _BookCode
        tblFormValues.Rows(0)("BOOKVNO") = Generate_Book_Vno(Val(txt_EntryNo.Text), _BookTrType)
        tblFormValues.Rows(0)("OFFERDATE") = txtChallanDate.Date_for_Database
        tblFormValues.Rows(0)("YARN_DELV_DATE") = txtChallanDate.Date_for_Database
        tblFormValues.Rows(0)("ACCOUNTCODE") = txtPartyCode.Text
        tblFormValues.Rows(0)("AGENTCODE") = txtAgentCode.Text
        tblFormValues.Rows(0)("SELVCODE") = txtSelvCode.Text
        tblFormValues.Rows(0)("ACOFCODE") = "0000-000000001"
        tblFormValues.Rows(0)("TransportCode") = "0000-000000001"
        tblFormValues.Rows(0)("DespatchCode") = "0000-000000001"
        tblFormValues.Rows(0)("CutCode") = "0000-000000001"
        tblFormValues.Rows(0)("despatchtocode") = "0000-000000001"
        tblFormValues.Rows(0)("processcode") = "0000-000000001"
        tblFormValues.Rows(0)("DesignCode") = txtDesignCode.Text
        tblFormValues.Rows(0)("ShadeCode") = txtShadeCode.Text
        tblFormValues.Rows(0)("YARN_LOT_NO") = txtLoomCode.Text
        tblFormValues.Rows(0)("cancel_Qty") = 0
        tblFormValues.Rows(0)("Pcs_Bales") = 0
        tblFormValues.Rows(0)("NO_OF_DESING") = 1
        tblFormValues.Rows(0)("NO_OF_SHADE") = 1
        tblFormValues.Rows(0)("OP10") = USER_ID
        tblFormValues.Rows(0)("RDVALUE") = Txt_RollingCharge.Text
        tblFormValues.Rows(0)("REED") = txt_Reed.Text
        tblFormValues.Rows(0)("DENT") = txt_Dent.Text
        tblFormValues.Rows(0)("PICK") = txt_Pick.Text
        tblFormValues.Rows(0)("REEDSPACE") = txt_ReedSpace.Text
        tblFormValues.Rows(0)("WESTAGE") = txt_Westage.Text
        tblFormValues.Rows(0)("PymtDays") = Txt_NoOfPcs.Text
        tblFormValues.Rows(0)("AVGWEIGHT") = txt_AvgWeight.Text
        tblFormValues.Rows(0)("RATE") = txt_Pick_Rate.Text
        tblFormValues.Rows(0)("LOTNO") = "MTRS"



        If tblFormValues.Rows(0)("clear").ToString = "" Then tblFormValues.Rows(0)("clear") = "NO"

        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)

        sqL = getSaveQuery()
        sql_Data_Save_Delete_Update()


        MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        _KeyFieldValue = 0

        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
        ObjCls_General.Blank_Object(Me)

    End Sub

#End Region

#Region "DELETE RECORD"
    Private Sub Delete_Record()
        Dim _entryNo As Integer = 0
        _strQuery = New StringBuilder
        With _strQuery
            .Append("DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "'")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0


        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)


    End Sub
#End Region


#Region "SUB NEW"
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Txt_PartyName_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_PartyName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then

            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), txt_PartyName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtPartyCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("AccountName") Then txt_PartyName.Text = selected("AccountName").ToString()
            End If


            'Party_selection.txtSearch.Text = txt_PartyName.Text
            'obj_Party_Selection.Invoice_Party_Selection()
            'If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '    txt_PartyName.Text = MULTY_SELECTION_COLOUM_1_DATA
            '    txtPartyCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            'End If
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region


    Private Sub Txt_Moredetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Moredetail.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_Moredetail.Text = "NO" Then
                btnSave.Focus()
                btnSave.Select()
            Else
                txt_OfferNo.Focus()
                txt_OfferNo.Select()
            End If

        End If
    End Sub

#Region "Txt Book Name Events Code "
    Private Sub txtBookName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBookName.KeyPress
        If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub

        If Asc(e.KeyChar) = 13 Then
            'BOOK_BHEWAR = "chq_printing"
            'BOOK_CATGER = " BOOKCATEGORY='OFFER' AND BEHAVIOUR='JOB-WEAVING'"
            'Party_selection.txtSearch.Text = txtBookName.Text
            'obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
            Dim _Filterstring As String = ""

            If LblHeader.Text = "Job Order Entry" Then
                _Filterstring = " AND A.BOOKCATEGORY='OFFER' AND A.BEHAVIOUR='JOB-WEAVING'"
            Else
                _Filterstring = " AND A.BOOKCATEGORY='OFFER' AND A.BEHAVIOUR='GREY'"
            End If



            Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtBookName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtBookCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("BookName") Then txtBookName.Text = selected("BookName").ToString()
            End If

            _BookCode = txtBookCode.Text
            _BookSetting()
            SendKeys.Send("{tab}")
        End If
        e.Handled = True
    End Sub

    Private Sub _BookSetting()
        If _BookCode <> "" Then
            Dim TmpTbl As New DataTable
            sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & _BookCode & "' "
            sql_connect_slect()
            TmpTbl = DefaltSoftTable.Copy


            If TmpTbl.Rows.Count > 0 Then
                Book_Row = TmpTbl(0)
                AcCode_Filter_String = TmpTbl(0)("GROUP_CODE_FILTER_STRING").ToString
                _BookTrType = TmpTbl(0)("BOOKTRTYPE").ToString
            End If
        End If
    End Sub
    Private Sub txtBookName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookName.Validated
        If _FrmLoad = True Then Exit Sub

        _BookSetting()

        If txtBookCode.Text = "" Or _BookCode = "" Then
            txtBookName.Focus()
            txtBookName.Select()
            Exit Sub
        Else
            Dim TmpTbl As New DataTable
            AcCode_Filter_String = Book_Row("GROUP_CODE_FILTER_STRING").ToString
            _BookTrType = Book_Row("BOOKTRTYPE").ToString

            Ctrl_Visible_True(Me.Controls)

            Dim Str_Qry As String = obj_Party_Selection.EntryData_Job_Offer_Entry_txtBookName_Validated(_BookCode)

            Dim TblTmp As New DataTable
            sqL = Str_Qry
            sql_connect_slect()
            TblTmp = DefaltSoftTable.Copy

            Dim Last_Entry_No As Integer = 0
            If TblTmp.Rows.Count > 0 Then
                Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
            End If

            If _FORMMODE = "ADD" Then
                txt_EntryNo.Text = Last_Entry_No + 1
                If Last_Entry_No > 0 Then
                    'ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, TblTmp)
                    'txt_PartyName.Text = TblTmp(0)("ACCOUNTNAME").ToString
                    'txtChallanDate.Text = TblTmp(0)("F_OFFERDATE").ToString
                    'txtPartyCode.Text = TblTmp(0)("ACCOUNTCODE").ToString
                    'txtAgentCode.Text = TblTmp(0)("AGENTCODE").ToString
                    'txtSelvCode.Text = TblTmp(0)("SELVCODE").ToString
                    'txtItemCode.Text = TblTmp(0)("ITEMCODE").ToString
                    txt_EntryNo.Text = Last_Entry_No + 1
                    Txt_PlanningNo.Text = ""
                Else
                    txtChallanDate.Text = ObjCls_General.GetTodayDate_British
                    txt_EntryNo.Text = "1"
                    txt_Loom_Type.Text = "SINGLE"
                End If

                txt_OfferNo.Text = txt_EntryNo.Text
                Generate_Date_For_DataBase(txtChallanDate)

                txt_EntryNo.Focus()
                txt_EntryNo.Select()
            ElseIf _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                If Last_Entry_No = 0 Then
                    MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    txtBookName.Focus()
                    txtBookName.Select()
                    Exit Sub
                Else
                    txt_EntryNo.Text = Last_Entry_No
                    Generate_Date_For_DataBase(txtChallanDate)
                    txt_EntryNo.Focus()
                    txt_EntryNo.Select()
                End If
            ElseIf _FORMMODE = "VIEW" Then
                If Last_Entry_No = 0 Then
                    MsgBox("No Record Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    txtBookName.Focus()
                    txtBookName.Select()
                Else
                    'View_Record()
                End If
            End If
        End If
    End Sub
#End Region

    Private Sub Txt_PlanningNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PlanningNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Party_selection.txtSearch.Text = Txt_PlanningNo.Text
            Dim _flitersting As String = " AND B.ID='" & txtItemCode.Text & "'"
            _GetPlanningQuery(_flitersting)
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_PlanningNo.Text = MULTY_SELECTION_COLOUM_1_DATA
                Dim _tmptbl As DataTable = _GetPlanningIdtodata(Txt_PlanningNo.Text)
                FeelPlanningData(_tmptbl)
            End If
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            Txt_PlanningNo.Text = ""
        End If
    End Sub
    Private Sub FeelPlanningData(ByVal _tmptbl As DataTable)
        If _tmptbl.Rows.Count > 0 Then
            txtItemCode.Text = _tmptbl.Rows(0).Item("GROUPNAME").ToString
            txtDesignCode.Text = _tmptbl.Rows(0).Item("COMPNAME").ToString
            txtShadeCode.Text = _tmptbl.Rows(0).Item("PRIMERUNIT").ToString
            Ttx_CutMtrs.Text = _tmptbl.Rows(0).Item("PlanningQty").ToString
            txt_Mtr_Weight.Text = _tmptbl.Rows(0).Item("PlanningQty").ToString
            txt_PartyName.Text = _tmptbl.Rows(0).Item("ACCOUNTNAME").ToString
            txtPartyCode.Text = _tmptbl.Rows(0).Item("TAXSLAB").ToString
            txtAgentCode.Text = _tmptbl.Rows(0).Item("AGENTCODE").ToString


            If _FORMMODE = "ADD" Then
                sqL = "SELECT*FROM MstFabricItem WHERE ID='" & txtItemCode.Text & "'"
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    txt_Reed.Text = DefaltSoftTable.Rows(0).Item("REED").ToString
                    txt_Dent.Text = DefaltSoftTable.Rows(0).Item("OP22").ToString
                    txt_Pick.Text = DefaltSoftTable.Rows(0).Item("PICK").ToString
                    txt_ReedSpace.Text = DefaltSoftTable.Rows(0).Item("OP23").ToString
                End If
            End If



        End If
    End Sub
    Private Sub txt_Loom_Type_Validated(sender As Object, e As EventArgs) Handles txt_Loom_Type.Validated
        If txt_Loom_Type.Text = "SINGLE" Then
            txt_No_Of_Set.Text = "1"
            txt_No_Of_Beam.Text = "1"
        ElseIf txt_Loom_Type.Text = "DOUBLE" Then
            txt_No_Of_Set.Text = "1"
            txt_No_Of_Beam.Text = "2"
        End If
    End Sub

End Class