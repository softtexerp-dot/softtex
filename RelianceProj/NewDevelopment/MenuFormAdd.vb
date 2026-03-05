Imports System.Data.OleDb
Imports System.Reflection
Imports System.Text
Imports DevExpress.XtraBars.Customization
Friend Class MenuFormAdd

    Private obj_Party_Selection As New Multi_Selection_Master
    Private UC_Buttons1 As UC_Buttons

#Region "VARIABLE DECLARATION "
    Private DispMultiList As Boolean = False
    Private WithEvents txt_Sale_Purc_Code As New TextBox
    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "MainId"
    Private _TblName As String = "MenuName"
    Private _FrmLoad As Boolean = False
    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtAlter_Name As New TextBox
    'Private callSource As TypeClass.LoadSourceType
    Private DispList As Boolean = True
    Private Call_By_other As Boolean = False

    Private Last_Focused_Btn As String = ""
    Private old_Me_text As String = ""

    Private Return_Array_Values(0) As String
    Private Str_In_Account As String = ""
    Private Str_In_Group As String = ""
    Private Str_In_Challan As String = ""
    Private Str_In_Order As String = ""
    Private _BookTrtype As String = ""

    Private Str_In_Factory_Code As String = ""
    Private Str_In_Grey_Party_Code As String = ""
    Private Str_In_Sales_Party_Code As String = ""
    Private Str_In_Process_Code As String = ""
#End Region

#Region "QUERY SECTION"

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.* ")
            .Append(" FROM " & _TblName & " A WHERE 1=1 AND " & _KeyFieldName & " ='" & strKeyID & "'")
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


#Region "TABLE FIELD DECLARE "
    Private Sub defineColName()
        With _ColNames
            .Append("MainId")
            .Append(",MenuName")
            .Append(",MenuPositionId")
            .Append(",MenuOrderNo")
            .Append(",ActiveStatus")
            .Append(",MenuPosition")
            .Append(",MenuIsSparate")
            .Append(",MainMenuName")
            .Append(",SelectedFormName")
            .Append(",ShortCutKey")
        End With
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub MenuFormAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        _FrmLoad = True
        CreateButtonsControl()
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        AttachButtonFocusEvents(Me)
        _FrmLoad = False


        Dim x As Integer
        Dim y As Integer
        x = 200
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 55
        Me.Location = New Point(x, y)

        _FrmLoad = True
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")
        old_Me_text = Me.Text
        'Call Command_Button_Visibility("LOAD")
        'UC_Buttons1._ButtonEnableDisable("LOAD")
        Ctrl_Visible_False(Me.Controls)
        btnAdd.Focus()
        btnAdd.Select()
        _FrmLoad = False

        If Call_By_other = True Then
            Me.Location = New Drawing.Point((Me.Owner.Location.X + (Me.Owner.Width \ 2) - (Me.Width \ 2)), (Me.Owner.Location.Y + (Me.Owner.Height \ 2) - (Me.Height \ 2)))
            Me.Left = 177
            Me.Top = 80
        End If

    End Sub
    Private Sub CreateButtonsControl()

        UC_Buttons1 = New UC_Buttons()

        With UC_Buttons1
            .Name = "UC_Buttons1"
            .Dock = DockStyle.Bottom
            .Visible = True
        End With
        Me.Controls.Add(UC_Buttons1)
        UC_Buttons1.BringToFront()
        AddHandler UC_Buttons1.AddClick, AddressOf UC_Buttons1_AddClick
        AddHandler UC_Buttons1.EditClick, AddressOf UC_Buttons1_EditClick
        AddHandler UC_Buttons1.DeleteClick, AddressOf UC_Buttons1_DeleteClick
        'AddHandler UC_Buttons1.BackClick, AddressOf UC_Buttons1_BackClick
        'AddHandler UC_Buttons1.NextClick, AddressOf UC_Buttons1_NextClick
        AddHandler UC_Buttons1.SaveClick, AddressOf UC_Buttons1_SaveClick
        AddHandler UC_Buttons1.CloseClick, AddressOf UC_Buttons1_CloseClick
        AddHandler UC_Buttons1.ViewClick, AddressOf UC_Buttons1_ViewClick
        AddHandler UC_Buttons1.PrintClick, AddressOf UC_Buttons1_PrintClick
        AddHandler UC_Buttons1.ReportsClick, AddressOf UC_Buttons1_ReportsClick
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnPrint", "BtnReports")
    End Sub
    Private Sub Transport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True
            If _FORMMODE = "" Then
                Me.Close()
                Dispose(True)
            ElseIf _FORMMODE <> "" Then
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                'Call Command_Button_Visibility("LOAD")
                Call Ctrl_Visible_False(Me.Controls)
                'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)

                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                _FrmLoad = False
            End If
        End If
    End Sub
#End Region

    '#Region "COMMAND BUTTON VISIBILITY CODE "
    '    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
    '        If Visibility_Flag = "LOAD" Then
    '            btnSave.Enabled = False
    '            btnAdd.Enabled = True
    '            btnModify.Enabled = True
    '            'btnDelete.Enabled = True
    '            BtnView.Enabled = True
    '        ElseIf Visibility_Flag = "BTNADD" Then
    '            btnSave.Enabled = True
    '            btnAdd.Enabled = False
    '            btnModify.Enabled = False
    '            'btnDelete.Enabled = False
    '            BtnView.Enabled = False
    '        ElseIf Visibility_Flag = "BTNEDIT" Then
    '            btnSave.Enabled = True
    '            btnAdd.Enabled = False
    '            btnModify.Enabled = False
    '            'btnDelete.Enabled = False
    '            BtnView.Enabled = False
    '        ElseIf Visibility_Flag = "BTNDELETE" Then
    '            btnSave.Enabled = True
    '            btnAdd.Enabled = False
    '            btnModify.Enabled = False
    '            'btnDelete.Enabled = False
    '            BtnView.Enabled = False
    '        ElseIf Visibility_Flag = "BTNVIEW" Then
    '            btnSave.Enabled = False
    '            btnAdd.Enabled = False
    '            btnModify.Enabled = False
    '            'btnDelete.Enabled = False
    '            BtnView.Enabled = False
    '        End If

    '    End Sub
    '#End Region

    '#Region "SET FOCUS LAST CLICKED BTN"
    '    Private Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)
    '        If Last_Focused_Btn = "ADD" Then
    '            btnAdd.Focus()
    '        ElseIf Last_Focused_Btn = "MODIFY" Then
    '            btnModify.Focus()
    '        ElseIf Last_Focused_Btn = "DELETE" Then
    '            'btnDelete.Focus()
    '        ElseIf Last_Focused_Btn = "VIEW" Then
    '            BtnView.Focus()
    '        ElseIf Last_Focused_Btn = "SAVE" Then
    '            btnAdd.Focus()
    '        End If
    '    End Sub
    '#End Region

    '#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE"
    '    Private Sub btnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.GotFocus
    '        btnAdd.BackColor = Color.Coral
    '    End Sub
    '    Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.LostFocus
    '        btnAdd.BackColor = Me.BackColor
    '    End Sub
    '    Private Sub btnModify_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.GotFocus
    '        btnModify.BackColor = Color.Coral
    '    End Sub
    '    Private Sub btnModify_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.LostFocus
    '        btnModify.BackColor = Me.BackColor
    '    End Sub

    '    Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.GotFocus
    '        BtnView.BackColor = Color.Coral
    '    End Sub
    '    Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.LostFocus
    '        BtnView.BackColor = Me.BackColor
    '    End Sub
    '    Private Sub btnSave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.GotFocus
    '        btnSave.BackColor = Color.Coral
    '    End Sub
    '    Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.LostFocus
    '        btnSave.BackColor = Me.BackColor
    '    End Sub
    '    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.GotFocus
    '        btnClose.BackColor = Color.Coral
    '    End Sub
    '    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.LostFocus
    '        btnClose.BackColor = Me.BackColor
    '    End Sub
    '#End Region

#Region "BTN CLICK/ENTER CODE "
    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    If _FORMMODE = "" Then
    '        Me.Close()
    '        Dispose(True)
    '    Else
    '        If _FORMMODE = "VIEW" Then
    '            _FORMMODE = ""
    '            'PnlGrdView.Visible = False
    '            'grdView.Visible = False
    '            Call Command_Button_Visibility("LOAD")
    '            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    '            Me.Text = old_Me_text
    '        Else
    '            _FORMMODE = ""
    '            ObjCls_General.Blank_Object(Me)
    '            _KeyFieldValue = 0
    '            Call Command_Button_Visibility("LOAD")
    '            Call Ctrl_Visible_False(Me.Controls)
    '            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    '        End If
    '    End If
    'End Sub
    'Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
    '    _FORMMODE = "VIEW"
    '    Last_Focused_Btn = "VIEW"
    '    Call Command_Button_Visibility("BTNVIEW")
    '    'Call View_Record()
    'End Sub
    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    _FrmLoad = True
    '    SaveRecord()
    '    _FrmLoad = False
    'End Sub
    'Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    _FORMMODE = "ADD"
    '    Last_Focused_Btn = "ADD"
    '    Call Command_Button_Visibility("BTNADD")
    '    Call Ctrl_Visible_True(Me.Controls)

    '    Txt_MenuType.Text = "SUB MENU"
    '    Txt_MenuActive.Text = "NO"
    '    Txt_MenuSepartor.Text = "False"
    '    _GetMaxId()
    '    Txt_MenuName.Focus()
    '    Txt_MenuName.Select()
    'End Sub

    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click

    End Sub
    'Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    _FrmLoad = False
    '    Last_Focused_Btn = "DELETE"
    '    _FORMMODE = "DELETE"
    '    txtAlter_code.Text = ""
    '    Own_Selection_List()
    '    If txtAlter_code.Text <> "" Then
    '        Ctrl_Visible_True(Me.Controls)
    '        Call ALTER_FORM(txtAlter_code.Text)
    '        Call Command_Button_Visibility("BTNDELETE")
    '        If (Mid(_KeyFieldValue, 1, 4)) = "0000" Then
    '            MsgBox("It's A Default Record, Can't Delete", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
    '        Else
    '            If Delete_Sure_Check("PARTY", txtAlter_code.Text) = True Then
    '                If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
    '                    Call Delete_Record()
    '                End If
    '            Else
    '                MsgBox("Party/Supplier Exist Under This Transport", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
    '            End If
    '        End If
    '    End If
    '    ObjCls_General.Blank_Object(Me)
    '    _FORMMODE = ""
    '    Ctrl_Visible_False(Me.Controls)
    '    Command_Button_Visibility("LOAD")
    '    Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    'End Sub
    Private Sub _GetMaxId()

        RS = "SELECT TOP 1  * FROM " & _TblName & "  ORDER BY " & _KeyFieldName & " DESC"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_MenuId.Text = DefaltSoftTable.Rows(0).Item("MainId") + 1
        Else
            Txt_MenuId.Text = 1
        End If
    End Sub
#End Region


#Region "SAVE METHOD"
    Private Sub SaveRecord()

        If Txt_MenuOrder.Text.Trim = "" Then Txt_MenuOrder.Text = 1


        _MenuPositiomset()

        Dim SaveQuery As String = ""

        Dim Qry As New StringBuilder()
        Qry.Append("INSERT INTO MenuName (")
        Qry.Append("MainId")
        Qry.Append(",MenuName")
        Qry.Append(",MenuPositionId")
        Qry.Append(",MainMenuPositionId")
        Qry.Append(",MenuOrderNo")
        Qry.Append(",ActiveStatus")
        Qry.Append(",MenuPosition")
        Qry.Append(",MenuIsSparate")
        Qry.Append(",MainMenuName")
        Qry.Append(",SelectedFormName")
        Qry.Append(",ShortCutKey")
        Qry.Append(" ) VALUES (")
        Qry.Append(Val(Txt_MenuId.Text) & ", ") ' Ensure numeric
        Qry.Append("'" & Txt_MenuName.Text.Replace("'", "''") & "', ")
        Qry.Append(Val(Txt_UnderMenuPositionId.Text) & ", ") ' Ensure numeric
        Qry.Append(Val(Txt_UnderMenuPositionId.Text) & ", ") ' Ensure numeric
        Qry.Append(Val(Txt_MenuOrder.Text) & ", ") ' Ensure numeric
        Qry.Append("'" & Txt_MenuActive.Text.Replace("'", "''") & "',")
        Qry.Append(Val(Txt_MenuPosition.Text) & ",")
        Qry.Append("'" & Txt_MenuSepartor.Text.Replace("'", "''") & "', ")
        Qry.Append("'" & Txt_MenuUnderMenuName.Text.Replace("'", "''") & "', ")
        Qry.Append("'" & Txt_MenuDisplayName.Text.Replace("'", "''") & "', ")
        Qry.Append("'" & Txt_MenuShortCutKey.Text.Replace("'", "''") & "' ")
        Qry.Append(")")
        RS = Qry.ToString
        MenuDesign_QuerySaveUpdateDelete()

        MsgBox("Records Successfully Saved", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        _KeyFieldValue = 0

        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        'Command_Button_Visibility("LOAD")
        'Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")

    End Sub
#End Region

#Region "ALTER FORM METHOD"
    Private Sub ALTER_FORM(ByVal strKeyID As String)
        Dim tblTmp As New DataTable
        _FORMMODE = "EDIT"
        RS = getAlter_Form_Query(strKeyID)
        MenuDesign_QueryLoad()
        tblTmp = DefaltSoftTable.Copy


        tblFormValues.Rows.Clear()
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues.ImportRow(dr)
        Next

        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblFormValues)
        If tblTmp.Rows.Count > 0 Then
            _BookTrtype = tblTmp(0)("BOOKTRTYPE").ToString
            Str_In_Group = Replace(tblTmp(0)("GROUP_CODE_FILTER_STRING").ToString, "#", "'")

        End If
    End Sub
#End Region

#Region "DELETE RECORD"
    Private Sub Delete_Record()
        'Dim _entryNo As Integer = 0
        '_strQuery = New StringBuilder
        'With _strQuery
        '    .Append("DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "'")
        'End With
        'sqL = _strQuery.ToString
        'sql_Data_Save_Delete_Update()


        'ObjCls_General.Blank_Object(Me)
        '_KeyFieldValue = 0
    End Sub
#End Region

    '#Region "SELECTION LIST CODE"
    '    Private Sub Own_Selection_List()
    '        If _FrmLoad = True Then Exit Sub

    '        Dim _lastkEyFieldValue As String = ""
    '        txtAlter_code.Text = ""
    '        txtAlter_Name.Text = ""

    '        BOOK_BHEWAR = "chq_printing"
    '        BOOK_CATGER = "  (BOOKCATEGORY='FACTORY-BEAM' OR BOOKCATEGORY='GREY-RCPT') "

    '        obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
    '        txtAlter_Name.Text = MULTY_SELECTION_COLOUM_1_DATA
    '        txtAlter_code.Text = MULTY_SELECTION_COLOUM_3_DATA

    '        _lastkEyFieldValue = _KeyFieldValue
    '        _KeyFieldValue = txtAlter_code.Text
    '    End Sub
    '#End Region

#Region "SUB NEW"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub New(ByVal C_By_Other As String)
        InitializeComponent()
        If C_By_Other = "YES" Then
            Call_By_other = True
        End If
    End Sub

    Private Sub Txt_MenuType_Validated(sender As Object, e As EventArgs) Handles Txt_MenuType.Validated
        _MenuPositiomset()
    End Sub

    Private Sub _MenuPositiomset()
        If _FORMMODE = "ADD" Then
            If Txt_MenuType.Text = "MAIN MENU" Then
                Txt_MenuPosition.Text = 0
                Txt_MenuUnderMenuName.Text = Txt_MenuName.Text
                Txt_UnderMenuPositionId.Text = 0
            Else

                If Txt_MenuPosition.Text.Trim = "" Then Txt_MenuPosition.Text = 1
            End If


            If Txt_UnderMenuPositionId.Text.Trim > "" Then
                RS = "SELECT TOP 1 A.MenuOrderNo  FROM MenuName AS A WHERE A.MenuPositionId=" & Txt_UnderMenuPositionId.Text & " ORDER BY A.MenuPositionId DESC "
                MenuDesign_QueryLoad()
                If DefaltSoftTable.Rows.Count > 0 Then
                    Txt_MenuOrder.Text = DefaltSoftTable.Rows(0).Item("MenuOrderNo") + 1
                Else
                    Txt_MenuOrder.Text = 1
                End If
            End If
        End If


    End Sub

    Private Sub Txt_MenuUnderMenuName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_MenuUnderMenuName.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Txt_MenuType.Text = "SUB MENU" Then
            Party_selection.txtSearch.Text = Txt_MenuUnderMenuName.Text
            Dim Qry As New StringBuilder()
            Qry.Append(" SELECT ")
            Qry.Append(" A.MenuName ")
            Qry.Append(" ,'' AS Remark ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" FROM MenuName AS A ")
            Qry.Append(" WHERE 1=1 ")
            Qry.Append(" AND A.MenuPositionId=0 ")
            Qry.Append(" ORDER BY A.MenuName ")
            RS = Qry.ToString
            MenuDesign_QueryLoad()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Dim row As DataGridViewRow = Party_selection.dgw.Rows(0)
            row.Height = 30
            obj_Party_Selection.SELECTION_LIST_FIRST_SELECTION()

            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_MenuUnderMenuName.Text = MULTY_SELECTION_COLOUM_1_DATA
                Txt_UnderMenuPositionId.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If

            _MenuPositiomset()


            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            Txt_MenuUnderMenuName.Text = ""
        End If
    End Sub

    Private Sub Txt_MenuDisplayName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_MenuDisplayName.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Txt_MenuType.Text = "SUB MENU" Then
            Party_selection.txtSearch.Text = Txt_MenuDisplayName.Text

            GetAllFormsAsDataTable()

            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            Txt_MenuDisplayName.Text = ""
        End If
    End Sub
    Private Sub GetAllFormsAsDataTable()
        Dim dt As New DataTable()
        dt.Columns.Add("FormName", GetType(String))
        dt.Columns.Add("Remark", GetType(String))
        dt.Columns.Add("FormName1", GetType(String))
        dt.Columns.Add("FormName2", GetType(String))
        dt.Columns.Add("FormName3", GetType(String))


        Dim asm As Assembly = Assembly.GetExecutingAssembly()
        For Each t As Type In asm.GetTypes()
            If t.BaseType IsNot Nothing AndAlso t.BaseType.Equals(GetType(Form)) Then
                dt.Rows.Add(t.Name.ToUpper, "", t.Name, t.Name, t.Name)
            End If
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "FormName ASC"
        dt = dv.ToTable()

        Party_selection.dgw.DataSource = dt.Copy
        Party_selection.dgw.Columns(2).Visible = False
        Party_selection.dgw.Columns(3).Visible = False
        Party_selection.dgw.Columns(0).Width = 280
        Party_selection.dgw.Columns(1).Width = 200
        Party_selection.Width = 506
        Dim row As DataGridViewRow = Party_selection.dgw.Rows(0)
        row.Height = 30
        obj_Party_Selection.SELECTION_LIST_FIRST_SELECTION()

        If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            Txt_MenuDisplayName.Text = MULTY_SELECTION_COLOUM_3_DATA
        End If

    End Sub

#End Region

#Region "Button Click"
    Private Sub UC_Buttons1_AddClick()

        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            Last_Focused_Btn = "ADD"
            'Call Command_Button_Visibility("BTNADD")
            Call Ctrl_Visible_True(Me.Controls)
            Txt_MenuType.Text = "SUB MENU"
            Txt_MenuActive.Text = "NO"
            Txt_MenuSepartor.Text = "False"
            _GetMaxId()
            Txt_MenuName.Focus()
            Txt_MenuName.Select()
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_EditClick()
        _FORMMODE = "EDIT"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "EDIT" Then

        End If

        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub


    Private Sub UC_Buttons1_DeleteClick()

        _FrmLoad = True
        _FORMMODE = "DELETE"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "DELETE" Then

        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    'Private Sub UC_Buttons1_BackClick()
    '    _FrmLoad = False
    '    Call Ctrl_Visible_True(Me.Controls)
    '    If _FORMMODE = "EDIT" Then

    '    End If
    '    Call Ctrl_Visible_True(Me.Controls)
    '    UC_Buttons1._ButtonEnableDisable(_FORMMODE)
    '    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    'End Sub
    'Private Sub UC_Buttons1_NextClick()
    '    _FrmLoad = False
    '    Call Ctrl_Visible_True(Me.Controls)
    '    If _FORMMODE = "EDIT" Then
    '        Call Ctrl_Visible_True(Me.Controls)
    '        UC_Buttons1._ButtonEnableDisable(_FORMMODE)

    '    End If
    '    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    'End Sub
    Private Sub UC_Buttons1_SaveClick()
        _FrmLoad = True
        SaveRecord()
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub

    Private Sub UC_Buttons1_CloseClick()

        If _FORMMODE = "" Then
            Me.Close()
            Exit Sub
        Else
            If _FORMMODE = "VIEW" Then
                _FORMMODE = ""
                'PnlGrdView.Visible = False
                'grdView.Visible = False
                'Call Command_Button_Visibility("LOAD")
                'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                Me.Text = old_Me_text
            Else
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                'Call Command_Button_Visibility("LOAD")
                Call Ctrl_Visible_False(Me.Controls)
                'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
            End If

        End If

        'Me.Close()
        Me.Dispose(True)

    End Sub
    Private Sub UC_Buttons1_ViewClick()
        _FrmLoad = False
        _FORMMODE = "VIEW"
        Dim _BookName As String = ""

        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "VIEW" Then
            _FORMMODE = "VIEW"
            Last_Focused_Btn = "VIEW"
            'Call Command_Button_Visibility("BTNVIEW")
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        End If
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_PrintClick()
        _FORMMODE = "PRINT"
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ' print logic yahan add kar sakte ho
    End Sub
    Private Sub UC_Buttons1_ReportsClick()
        _FORMMODE = "REPORTS"
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ' reports logic yahan add kar sakte ho
    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MainMenuAndSubMenuDesign.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'New_MDI_From.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Start_Frm.CopySoftDesignerDllIfNotExists()
    End Sub
End Class