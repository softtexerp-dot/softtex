Imports System.Text
Imports DevExpress.XtraBars.Customization

Friend Class Costsheetsundary

    Private _FrmLoad As Boolean = True
    Private _FORMMODE As String = ""
    Private Change_Grid_Data As Boolean = True
    Private Last_Focused_Btn As String = ""
    Private _DefaultColOfGrid As Integer = 0
    Private _Last_Saved_Entry_No As Integer = 0
    Private _DataTableGrid As New DataTable
    Private _ExtraFieldDataTable As New StringBuilder
    Private _ExtraField_Values_DataTable As New StringBuilder
    Private _OfferTableName As String = "Query1"
    Private _FieldNotRequiredForSave As New StringBuilder
    Private _RecordsKeyFieldName As String = "ID"
    Private _ExtraFieldOthers As New StringBuilder
    Private _ExtraField_Values_Others As New StringBuilder
    Private _FieldDefaultValues As New StringBuilder
    Private _KeyFieldValue As String = ""
    Private _isCallerByOther As Boolean = False


    Private _ColNames As New StringBuilder
    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtAlter_Name As New TextBox
    Private tblFormValues As New DataTable
    Private _KeyFieldName As String = "BookCode"
    Private FieldNameAndValues(1) As String
    Private _TblName As String = "Query1"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Change_Grid_Data = True

        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"
        FormCtrl_Visible_True()
        'Call DefineDafaultValues()
        Call defineColName()
        Call Command_Button_Visibility("BTNADD")
        Call Ctrl_Visible_True(Me.Controls)
        Cmbsundarytype.Focus()
        Cmbsundarytype.Select()
    End Sub
#Region "CTRL VISIBLE TRUE"
    Private Sub FormCtrl_Visible_True()

        Cmbsundarytype.Visible = True
        Txtsundaryname.Visible = True
        Txtcalcby.Visible = True
        Txtaddless.Visible = True
        txtdefaultper.Visible = True

    End Sub
#End Region

#Region "Form Default values on Load"
    Private Sub defineColName()
        With _ColNames
            .Append("BookCode,")
            .Append("BookName,")
            .Append("RCPT_ISSUE,")
            .Append("NATURE,")
            .Append("Y_OWN_STK,")
            .Append("Y_OWN_STK_FLD")
        End With
    End Sub
    'Private Sub DefineDafaultValues()
    '    strQuery = "SELECT TOP 1 Id FROM " & _OfferTableName & " ORDER BY Id DESC"
    '    Lblid.Text = 1
    '    sqL = strQuery
    '    sql_connect_slect()
    '    If DefaltSoftTable.Rows.Count > 0 Then
    '        Lblid.Text = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
    '    End If
    '    'Lblid.Focus()
    'End Sub
#End Region
#Region "COMMAND BUTTON VISIBILITY CODE"
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
        If Visibility_Flag = "LOAD" Then
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            'btnPrint.Enabled = True
            btnSave.Enabled = False

        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            'btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNEDIT" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
            'btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            'btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            'btnPrint.Enabled = False
        End If
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        'Change_Grid_Data = True

        'Last_Focused_Btn = "MODIFY"
        '_FORMMODE = "EDIT"
        'Command_Button_Visibility("BTNEDIT")

        'strQuery = "SELECT TOP 1 Id FROM " & _OfferTableName & " ORDER BY Id DESC"
        'Lblid.Text.IndexOf("'")
        'Lblid.Text = 1

        'sqL = strQuery
        'sql_connect_slect()
        'If DefaltSoftTable.Rows.Count > 0 Then
        '    Lblid.Text = (DefaltSoftTable.Rows(0).Item(0))
        'End If

        Last_Focused_Btn = "MODIFY"
        _FORMMODE = "EDIT"

        txtAlter_code.Text = ""
        Own_Selection_List()
        If txtAlter_code.Text <> "" Then
            Command_Button_Visibility("BTNEDIT")
            Ctrl_Visible_True(Me.Controls)
            Alter_Form(txtAlter_code.Text)
            Cmbsundarytype.Focus()
            Cmbsundarytype.Select()
        Else
            _FORMMODE = ""
        End If


    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '_FrmLoad = False
        'Last_Focused_Btn = "DELETE"
        '_FORMMODE = "DELETE"
        'Command_Button_Visibility("BTNDELETE")
        'strQuery = "SELECT TOP 1 Id FROM " & _OfferTableName & " ORDER BY Id DESC"
        'Lblid.Text.IndexOf("'")
        'Lblid.Text = 1
        'sqL = strQuery
        'sql_connect_slect()
        'If DefaltSoftTable.Rows.Count > 0 Then
        '    Lblid.Text = (DefaltSoftTable.Rows(0).Item(0))
        'End If


        'If Lblid.Text <> "" Then
        '    'Lblid.Visible = True
        '    'Lblid.Focus()
        'Else
        '    MsgBox("No Record Found")
        '    FormCtrl_Visible_False()
        '    btnAdd.Focus()
        'End If
        _FrmLoad = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"

        Own_Selection_List()
        If txtAlter_code.Text <> "" Then
            Ctrl_Visible_True(Me.Controls)
            Call Alter_Form(txtAlter_code.Text)
            Call Command_Button_Visibility("BTNDELETE")
            If (Mid(_KeyFieldValue, 1, 4)) = "0000" Then
                MsgBox("It's A Default Record, Can't Delete", MsgBoxStyle.Critical, "Soft-Tex PRO")
            Else

                If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Record()
                End If

            End If
        End If
        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
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
        'sql_Data_Save_Delete_Update()
        'dbConnect.Fire_Query(_strQuery.ToString)
        'User_Log_Post(_TblName, _KeyFieldName, _KeyFieldValue, txtWeaveTypeName.Text, _UserID, _strQuery.ToString)
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
    End Sub
#End Region
#Region "SELECTION LIST CODE"
    Private Sub Own_Selection_List()

        Dim _lastkEyFieldValue As String = ""
        txtAlter_code.Text = ""
        txtAlter_Name.Text = ""
        'obj_Party_Selection.SINGLE_Sundary_SELECTION()

        txtAlter_Name.Text = MULTY_SELECTION_COLOUM_1_DATA
        txtAlter_code.Text = MULTY_SELECTION_COLOUM_3_DATA
        _lastkEyFieldValue = _KeyFieldValue
        _KeyFieldValue = txtAlter_code.Text
    End Sub
#End Region
#Region "CTRL VISIBLE FALSE"
    Private Sub FormCtrl_Visible_False()
        Cmbsundarytype.Visible = False
        Txtsundaryname.Visible = False
        Txtcalcby.Visible = False
        Txtaddless.Visible = False
        txtdefaultper.Visible = False
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        Call Command_Button_Visibility("BTNVIEW")
        Call View_Record()
    End Sub
#End Region
#Region "VIEW RECORD "
    Private Sub View_Record()
        'Generate_Date_For_DataBase(Txt_ViewFrom)
        'Generate_Date_For_DataBase(Txt_ViewTO)


        'Dim View_Filter_Condition = " AND A.Entry_Date>='" & Txt_ViewFrom.Date_for_Database & "' AND A.Entry_Date<='" & Txt_ViewTO.Date_for_Database & "'  "
        Dim View_Filter_Condition = " AND A.BookCode='Cost Sheet Setting' "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.BookCode as [Cost Sheet Setting]")
            .Append(" ,A.BookName as [Sundary Type]")
            .Append(" ,A.RCPT_ISSUE as [Sundary Name] ")
            .Append(" ,A.NATURE as [Add/Less]")
            .Append(" ,A.Y_OWN_STK as [Clac by]")
            .Append(" ,A.Y_OWN_STK_FLD as [Default Per]")
            .Append(" FROM " & _OfferTableName & " AS A ")
            .Append(" WHERE 1=1")

            .Append(View_Filter_Condition)

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            _FORMMODE = ""
        End If
    End Sub
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If Cmbsundarytype.Text = "" Then
            MsgBox("Invalid Entry ")
            Cmbsundarytype.Focus()
            Exit Function
        End If

        If Val(txtdefaultper.Text) = 0 Then
            MsgBox("Invalid Entry ")

            Exit Function
        Else
            Validate_Form_Values = True
        End If
        If Val(Txtcalcby.Text) = 0 Then
            MsgBox("Invalid Entry ")

            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function


#End Region
#Region "OFFER SAVE CODE"
    Private Sub SaveRecord()

        ''Generate_Date_For_DataBase(txt_Entry_Date)

        ''Dim _LastID As Integer = -1
        'Try
        '    SAVE_INTO_DATABASE()
        '    'If _LastID > 0 Then

        '    _Last_Saved_Entry_No = Val(Lblid.Text)
        '    MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex ERP")

        '    ObjCls_General.Blank_Object(Me)

        '    Call Command_Button_Visibility("LOAD")
        '    Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
        '    'End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        If Validate_Form_Values() = False Then Exit Sub
        Dim CompleteQuery As String = ""
        Dim SaveQuery As String = ""
        Dim strQuery As String = ""
        Dim LASTCODE As String = ""
        If _FORMMODE = "ADD" Then
            strQuery = GetMaxCode()
            sqL = strQuery
            sql_connect_slect()


            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
            Else
                LASTCODE = "1"
            End If
            LASTCODE = _SELECTEDCOMPANYCODE & "-" & LASTCODE.PadLeft(9, "0")
        Else
            LASTCODE = _KeyFieldValue
        End If
        tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        SaveQuery = getSaveQuery()
        sqL = SaveQuery
        sql_Data_Save_Delete_Update()
        MsgBox("Records Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    End Sub

    'Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
    '    '------------------------ DETAILS Table --------------------------------
    '    Dim strFilterString As String
    '    Dim QueryDetailTable As String = ""
    '    Dim BookCode As String = "Cost Sheet Setting"
    '    Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String
    '    strFilterString = "BookCode='" & BookCode & "'"

    '    _ExtraFieldDataTable = New StringBuilder
    '    With _ExtraFieldDataTable
    '        .Append("Id,")
    '        .Append("BookCode,")
    '        .Append("BookName,")
    '        .Append("RCPT_ISSUE,")
    '        .Append("NATURE,")
    '        .Append("Y_OWN_STK")
    '        .Append("Y_OWN_STK_FLD")
    '    End With

    '    _ExtraField_Values_DataTable = New StringBuilder
    '    With _ExtraField_Values_DataTable
    '        .Append(Lblid.Text & ",")
    '        .Append(BookCode & ",")
    '        .Append(Cmbsundarytype.Text & ",")
    '        .Append(Txtsundaryname.Text & ",")
    '        .Append(Txtaddless.Text & ",")
    '        .Append(Txtcalcby.Text & ",")
    '        .Append(txtdefaultper.Text & "")
    '    End With

    '    QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
    '    GridDetailsSaveQuery = QueryDetailTable & ";"
    '    arr_object = Query_Auto_Grid

    'End Function
    'Private Function SAVE_INTO_DATABASE() As Integer
    '    Dim strQuery As String = ""
    '    Dim I As Integer = 0


    '    Try
    '        '---------------- Delete Previous Bill Sundry ---------------------------------- '
    '        strQuery = "DELETE FROM " & _OfferTableName & " WHERE Id =" & Lblid.Text & "  "
    '        sqL = strQuery.ToString
    '        sql_Data_Save_Delete_Update()


    '        Dim Array_Opening(0, 4) As String
    '        '------ INSERT RECORDS SALES INVOICE -------------------------------
    '        GridDetailsSaveQuery(Array_Opening)
    '        For I = 0 To UBound(Array_Opening)
    '            If Array_Opening(I, 4) <> "" Then
    '                strQuery = Array_Opening(I, 4)
    '                sqL = strQuery.ToString
    '                sql_Data_Save_Delete_Update()
    '            End If
    '        Next

    '    Catch ex As Exception
    '        MsgBox("new error comes :" & ex.Message & "-" & strQuery)
    '        Throw ex
    '    Finally
    '        'cmd = Nothing
    '        'tran = Nothing
    '    End Try
    '    Return I
    'End Function
#End Region

#Region "QUERY SECTION"
    Public Function GetMaxCode() As String
        GetMaxCode = obj_Party_Selection.Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function
    Public Function GetName() As String
        GetName = obj_Party_Selection.Master_GetNameOtherThisEntry(_TblName, _KeyFieldName, _KeyFieldValue, "BookName", Cmbsundarytype.Text)
    End Function
    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT * FROM Query1 WHERE 1=1 AND BookCode='" & strKeyID & "'")
        End With
        Return _strQuery.ToString
    End Function
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If _FORMMODE = "" Then
            Me.Close()
        Else
            If _FORMMODE = "VIEW" Then
                PnlGrdView.Visible = False
                Call Command_Button_Visibility("LOAD")
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                'Me.Text = _old_Me_text
                _FORMMODE = ""
                'pnl_ItemGrid.Visible = True
                'pnl_Footer.Visible = True
                'pnl_Header.Height = 181
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

    Private Sub Txtcalcby_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcalcby.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdefaultper_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdefaultper.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Costsheetsundary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlGrdView.Width = Me.Width
        PnlGrdView.Height = Me.Height
        PnlGrdView.Location = New Point(0, 0)

        GridControl1.Width = PnlGrdView.Width - 25
        GridControl1.Height = PnlGrdView.Height - 100
        GridControl1.Location = New Point(3, 53)

        _FrmLoad = True
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        If _isCallerByOther = True Then
            btnAdd.Visible = False
            btnModify.Visible = False
            btnDelete.Visible = False
            btnView.Visible = False
            btnSave.Visible = True
            Call Alter_Form(_KeyFieldValue)
        Else
            Call Command_Button_Visibility("LOAD")
            FormCtrl_Visible_False()
            btnAdd.Focus()
            btnAdd.Select()
        End If
    End Sub

#End Region
#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        FormCtrl_Visible_False()
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable

        strQuery = getAlter_Form_Query_Details(strKeyID)

        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy


        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)

        FormCtrl_Visible_True()
        _FrmLoad = False
    End Sub
#End Region
#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*")
            .Append(" FROM " & _OfferTableName & " A")
            .Append(" WHERE 1=1  ")
        End With
        Return _strQuery.ToString
    End Function
#End Region
End Class