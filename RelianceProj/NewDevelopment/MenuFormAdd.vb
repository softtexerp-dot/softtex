Imports System.Reflection
Imports System.Text
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
    Private CurrentBackNumber As Integer = 0
    Private _MainmenupositionId As Integer = 0
    Dim _FormCloseMode As Boolean = False
#End Region

#Region "QUERY SECTION"

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.* ")
            .Append(" FROM " & _TblName & " A WHERE 1=1 AND " & _KeyFieldName & " =" & strKeyID & "")
        End With
        Return _strQuery.ToString
    End Function
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "" & _KeyFieldValue & "")
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
            .Append(",MainMenuPositionId")
            .Append(",MenuOrderNo")
            .Append(",ActiveStatus")
            .Append(",MenuPosition")
            .Append(",MenuIsSparate")
            .Append(",MainMenuName")
            .Append(",SelectedFormName")
            .Append(",ShortCutKey")
            .Append(",MenuType")
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
        Ctrl_Visible_False(Me.Controls)
        _FrmLoad = False
        If Call_By_other = True Then
            Me.Location = New Drawing.Point((Me.Owner.Location.X + (Me.Owner.Width \ 2) - (Me.Width \ 2)), (Me.Owner.Location.Y + (Me.Owner.Height \ 2) - (Me.Height \ 2)))
            Me.Left = 177
            Me.Top = 80
        End If
        PnlGrdView.Width = Me.Width
        PnlGrdView.Height = Me.Height
        PnlGrdView.Location = New Point(0, 0)
        GridControl1.Width = PnlGrdView.Width - 25
        GridControl1.Height = PnlGrdView.Height - 100
        GridControl1.Location = New Point(3, 53)
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
        AddHandler UC_Buttons1.BackClick, AddressOf UC_Buttons1_BackClick
        AddHandler UC_Buttons1.NextClick, AddressOf UC_Buttons1_NextClick
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
            If PnlGrdView.Visible = True AndAlso _FORMMODE = "VIEW" Then
                PnlGrdView.Visible = False
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                Exit Sub
            ElseIf _FormCloseMode = False Then
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                _FormCloseMode = True
                'Exit Sub
            End If
            If MsgBox("Do You Want To Close(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Close ?") = MsgBoxResult.Yes Then
                _FrmLoad = True
                If _FormCloseMode = True Then
                    Me.Close()
                    Dispose(True)
                End If
            End If
        End If
    End Sub
#End Region
    Private Sub _GetMaxId()

        RS = "SELECT TOP 1  * FROM " & _TblName & "  ORDER BY " & _KeyFieldName & " DESC"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_MenuId.Text = DefaltSoftTable.Rows(0).Item("MainId") + 1
            If _FORMMODE = "DELETE" Then
                Txt_MenuId.Text = DefaltSoftTable.Rows(0).Item("MainId")
                _KeyFieldValue = Txt_MenuId.Text
            End If
        Else
            Txt_MenuId.Text = 1
        End If

    End Sub

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
        'Txt_MenuShortCutKey.Text = tblFormValues.Rows(0)("MenuType")
        If tblTmp.Rows.Count > 0 Then
            '    _BookTrtype = tblTmp(0)("BOOKTRTYPE").ToString
            '    Str_In_Group = Replace(tblTmp(0)("GROUP_CODE_FILTER_STRING").ToString, "#", "'")
            Txt_MenuId.Focus()
            Txt_MenuType.Text = tblTmp.Rows(0)("MenuType")
        Else
            If tblTmp.Rows.Count = 0 Then
                ObjCls_General.Blank_Object(Me)
                Txt_MenuType.Text = "SUB MENU"
                Txt_MenuActive.Text = "NO"
                Txt_MenuSepartor.Text = "False"
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                MsgBox("Record Not Found")
            End If
        End If
    End Sub
#End Region

#Region "DELETE RECORD"
    Private Sub Delete_Record()
        Dim _entryNo As Integer = 0
        _strQuery = New StringBuilder
        With _strQuery
            .Append("DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & "=" & "" & _KeyFieldValue & "")
        End With
        RS = _strQuery.ToString
        MenuDesign_QueryLoad()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
    End Sub
#End Region

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
            ElseIf Txt_MenuType.Text.Trim = "PARENT1" Then
                'Txt_MenuUnderMenuName.Text = Txt_MenuName.Text
                Txt_MenuPosition.Text = 2
                'Txt_UnderMenuPositionId.Text = 2
                '_MainmenupositionId = 1
                _MainmenupositionId = 2
            ElseIf Txt_MenuType.Text.Trim = "PARENT2" Then
                Txt_MenuPosition.Text = 3
            Else
                'If Txt_MenuPosition.Text.Trim = "" Then Txt_MenuPosition.Text = 1
                Txt_MenuPosition.Text = 1
            End If
            If Txt_UnderMenuPositionId.Text.Trim > "" Then
                'RS = "SELECT TOP 1 A.MenuOrderNo  FROM MenuName AS A WHERE A.MenuPositionId=" & Txt_UnderMenuPositionId.Text & " ORDER BY A.MenuPositionId DESC "
                RS = "SELECT MAX(A.MenuOrderNo) AS MenuOrderNo FROM " & _TblName & " AS A WHERE A.MenuPositionId=" & Txt_UnderMenuPositionId.Text & " "
                MenuDesign_QueryLoad()
                If Not IsDBNull(DefaltSoftTable.Rows(0)("MenuOrderNo")) AndAlso Val(DefaltSoftTable.Rows(0)("MenuOrderNo")) > 0 Then
                    Txt_MenuOrder.Text = Val(DefaltSoftTable.Rows(0)("MenuOrderNo")) + 1
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
            Qry.Append(" FROM " & _TblName & " AS A ")
            Qry.Append(" WHERE 1=1 ")
            'Qry.Append(" AND A.MenuPositionId=0 ")
            Qry.Append(" AND A.MainMenuPositionId=0 ")
            Qry.Append(" AND A.ActiveStatus='YES' ")
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
        If e.KeyCode = Keys.Enter AndAlso Txt_MenuType.Text.Trim = "PARENT1" Then
            Party_selection.txtSearch.Text = Txt_MenuUnderMenuName.Text
            Dim Qry As New StringBuilder()
            Qry.Append(" SELECT ")
            Qry.Append(" A.MenuName ")
            Qry.Append(" ,'' AS Remark ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" FROM " & _TblName & " AS A ")
            Qry.Append(" WHERE 1=1 ")
            'Qry.Append(" AND A.MenuPositionId=1 ")
            Qry.Append(" AND A.MainMenuPositionId=1 ")
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
        If e.KeyCode = Keys.Enter AndAlso Txt_MenuType.Text.Trim = "PARENT2" Then
            Party_selection.txtSearch.Text = Txt_MenuUnderMenuName.Text
            Dim Qry As New StringBuilder()
            Qry.Append(" SELECT ")
            Qry.Append(" A.MenuName ")
            Qry.Append(" ,'' AS Remark ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" ,A.MainId ")
            Qry.Append(" FROM " & _TblName & " AS A ")
            Qry.Append(" WHERE 1=1 ")
            'Qry.Append(" AND A.MenuPositionId=2 ")
            Qry.Append(" AND A.MainMenuPositionId=2 ")
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
        If e.KeyCode = Keys.Enter AndAlso Txt_MenuType.Text.Trim = "PARENT1" Then
            Party_selection.txtSearch.Text = Txt_MenuDisplayName.Text
            GetAllFormsAsDataTable()
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            Txt_MenuDisplayName.Text = ""
        End If
        If e.KeyCode = Keys.Enter AndAlso Txt_MenuType.Text.Trim = "PARENT2" Then
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

        Dim Qry As New StringBuilder()
        Qry.Append(" SELECT ")
        Qry.Append("Distinct(A.FormName) As FormName ")
        Qry.Append(" ,A.FormType AS Remark ")
        Qry.Append(" ,A.FormName ")
        Qry.Append(" ,A.FormName ")
        Qry.Append(" ,A.FormName ")
        Qry.Append(" FROM FormControl AS A ")
        Qry.Append(" WHERE 1=1 ")
        'sqL = Qry.ToString
        'sql_connect_slect1()
        RS = Qry.ToString
        MenuDesign_QueryLoad()
        Dim dt2 As New DataTable()
        dt2 = DefaltSoftTable.Copy
        For Each r As DataRow In dt2.Rows
            dt.Rows.Add(r("FormName"), r("Remark"), r("FormName"), r("FormName"), r("FormName"))
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
        _FormCloseMode = False
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
        Dim LASTCODE As String = ""
        _FORMMODE = "EDIT"
        _FormCloseMode = False
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "EDIT" Then
            '_GetMaxId()
            'Txt_MenuType.Text = "SUB MENU"
            'Txt_MenuActive.Text = "NO"
            'Txt_MenuSepartor.Text = "False"
            RS = "SELECT TOP 1  * FROM " & _TblName & " ORDER BY " & _KeyFieldName & " DESC"
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                Txt_MenuId.Text = DefaltSoftTable.Rows(0).Item("MainId")
                _KeyFieldValue = Txt_MenuId.Text
                'Else
                '    Txt_MenuId.Text = 1
            End If
            Call ALTER_FORM(Txt_MenuId.Text)
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub


    Private Sub UC_Buttons1_DeleteClick()
        _FrmLoad = True
        _FormCloseMode = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "DELETE" Then
            _GetMaxId()
            If _KeyFieldValue <> "" Then
                Ctrl_Visible_True(Me.Controls)
                If (Mid(_KeyFieldValue, 1, 4)) = "0000" Then
                    MsgBox("It's A Default Record, Can't Delete", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                Else
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Call Delete_Record()
                    End If

                End If
            End If
            ObjCls_General.Blank_Object(Me)
            Ctrl_Visible_False(Me.Controls)
        End If
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub
    Private Sub UC_Buttons1_BackClick()
        _FrmLoad = False
        _FormCloseMode = False
        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "EDIT" Then
            If Txt_MenuId.Text = "" Then
                RS = "SELECT TOP 1  * FROM " & _TblName & " ORDER BY " & _KeyFieldName & " DESC"
            Else
                RS = "SELECT TOP 1  * FROM " & _TblName & "  where " & _KeyFieldName & "=" & Txt_MenuId.Text & " ORDER BY " & _KeyFieldName & " DESC"
            End If
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                Txt_MenuId.Text = DefaltSoftTable.Rows(0).Item("MainId")
                CurrentBackNumber = Txt_MenuId.Text
                If CurrentBackNumber > 1 Then
                    CurrentBackNumber -= 1
                End If
            End If
            Call ALTER_FORM(CurrentBackNumber)
        End If
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_NextClick()
        _FrmLoad = False
        _FormCloseMode = False
        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "EDIT" Then
            RS = "SELECT TOP 1  * FROM " & _TblName & " where " & _KeyFieldName & "=" & Txt_MenuId.Text & "  ORDER BY " & _KeyFieldName & " DESC"
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                Txt_MenuId.Text = DefaltSoftTable.Rows(0).Item("MainId")
                CurrentBackNumber = Txt_MenuId.Text
                CurrentBackNumber += 1
            End If
            Call ALTER_FORM(CurrentBackNumber)
        End If
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_SaveClick()
        _FrmLoad = True
        Dim SaveQuery As String = ""
        Dim LASTCODE As String = ""
        If Txt_MenuOrder.Text.Trim = "" Then Txt_MenuOrder.Text = 1
        _MenuPositiomset()
        If _FORMMODE = "ADD" Then
            _GetMaxId()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Txt_MenuId.Text
            Else
                LASTCODE = "1"
            End If
        Else
            LASTCODE = DefaltSoftTable.Rows(0)("MainId")
            _KeyFieldValue = LASTCODE
        End If
        tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
        Dim txtmenuname As String = Txt_MenuName.Text.Trim().ToLower()
        Dim properText As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtmenuname)
        tblFormValues.Rows(0)("MenuName") = properText.Replace("'", "''")
        If _FORMMODE = "ADD" Then
            tblFormValues.Rows(0)("MenuPositionId") = Val(Txt_UnderMenuPositionId.Text.Replace("'", ""))
            If Txt_MenuType.Text.Trim = "PARENT1" Then
                tblFormValues.Rows(0)("MainMenuPositionId") = Val(_MainmenupositionId)
            Else
                tblFormValues.Rows(0)("MainMenuPositionId") = Val(Txt_UnderMenuPositionId.Text)
            End If
        Else
            Txt_UnderMenuPositionId.Text = tblFormValues.Rows(0)("MenuPositionId")
            Txt_UnderMenuPositionId.Text = tblFormValues.Rows(0)("MainMenuPositionId")
        End If
        tblFormValues.Rows(0)("MenuOrderNo") = Val(Txt_MenuOrder.Text)
        tblFormValues.Rows(0)("ActiveStatus") = Txt_MenuActive.Text
        tblFormValues.Rows(0)("MenuPosition") = Val(Txt_MenuPosition.Text)
        tblFormValues.Rows(0)("MenuIsSparate") = Txt_MenuSepartor.Text.Replace("'", "''")
        Dim txtmainmenuname As String = Txt_MenuUnderMenuName.Text.Trim().ToLower()
        Dim properTextmainmenu As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtmainmenuname)
        tblFormValues.Rows(0)("MainMenuName") = properTextmainmenu.Replace("'", "''")
        tblFormValues.Rows(0)("SelectedFormName") = Txt_MenuDisplayName.Text.Replace("'", "''")
        tblFormValues.Rows(0)("ShortCutKey") = Txt_MenuShortCutKey.Text.Replace("'", "''")
        tblFormValues.Rows(0)("MenuType") = Txt_MenuType.Text.Replace("'", "''")
        'ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        SaveQuery = getSaveQuery()
        RS = SaveQuery.ToString
        MenuDesign_QuerySaveUpdateDelete()
        If _FORMMODE = "ADD" Then
            MessageBox.Show("Save Successfully")
        Else
            MessageBox.Show("Update Successfully")
        End If

        Call Ctrl_Visible_False(Me.Controls)
        Clear()
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub
    Private Sub Clear()
        Txt_MenuId.Text = ""
        Txt_MenuName.Text = ""
        Txt_MenuType.Text = "SUB MENU"
        Txt_MenuActive.Text = "NO"
        Txt_MenuSepartor.Text = "False"
        Txt_MenuPosition.Text = ""
        Txt_MenuUnderMenuName.Text = ""
        Txt_UnderMenuPositionId.Text = ""
        Txt_MenuOrder.Text = ""
        Txt_MenuDisplayName.Text = ""
        Txt_MenuShortCutKey.Text = ""
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
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                Me.Text = old_Me_text
            Else
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                Call Ctrl_Visible_False(Me.Controls)
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
            View_Record()
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

    Private Sub Txt_MenuId_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_MenuId.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_MenuId.Text <> "" Then
                Call ALTER_FORM(Txt_MenuId.Text)
            End If
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        View_Record()
    End Sub

#End Region
    Private Sub View_Record()
        'RS = "SELECT MenuName.MainId, MenuName.MenuName, MenuName.MenuPositionId, MenuName.MainMenuPositionId, MenuName.MenuOrderNo, MenuName.ActiveStatus, MenuName.MenuPosition, MenuName.MainMenuName, MenuName.SelectedFormName, MenuName.ShortCutKey, MenuName.MenuType FROM " & _TblName & " ORDER BY " & _TblName & "." & _KeyFieldName & ";"
        RS = "SELECT * FROM " & _TblName & " where 1=1 ORDER BY " & _KeyFieldName & " ASC"
        MenuDesign_QueryLoad()
        Dim tblTmp As DataTable
        tblTmp = DefaltSoftTable.Copy
        FirstStage.Columns.Clear()
        Dim Qty As String = ""
        If tblTmp.Rows.Count > 0 Then
            GridControl1.DataSource = tblTmp.Copy
            For Each dc As DataColumn In tblTmp.Columns
                Dim isEmptyOrZero As Boolean = True
                If dc.ColumnName.ToUpper() = "ID" Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                    Continue For
                End If
                For Each dr As DataRow In tblTmp.Rows
                    If Not IsDBNull(dr(dc)) Then
                        Dim val As String = dr(dc).ToString().Trim()
                        ' 🔴 अगर कोई value meaningful है → column visible रहेगा
                        If val <> "" AndAlso val <> "0" AndAlso val <> "0.00" Then
                            isEmptyOrZero = False
                            Exit For
                        End If
                    End If
                Next
                If isEmptyOrZero Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                End If
            Next
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Dim _RptTiltle = " Report From :" & Txt_ViewFrom.Text & " To : " & Txt_ViewTO.Text
        Dim _RptTiltle = " Report From : Menu Details "
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
End Class