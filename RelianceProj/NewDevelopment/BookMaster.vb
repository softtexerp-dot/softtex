Imports System.Reflection
Imports System.Text

Public Class BookMaster
    Private obj_Party_Selection As New Multi_Selection_Master
    Private UC_Buttons1 As UC_Buttons
#Region "VARIABLE DECLARATION "
    Private DispMultiList As Boolean = False
    Private WithEvents txt_Sale_Purc_Code As New TextBox
    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues1 As New DataTable
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "BookId"
    'Private _TblName As String = "MstBook"
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
    Private _MenupositionId As Integer = 0
    Dim _FormCloseMode As Boolean = False
#End Region

#Region "QUERY SECTION"

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.* ")
            .Append(" FROM MstBook A WHERE 1=1 AND " & _KeyFieldName & " =" & strKeyID & "")
        End With
        Return _strQuery.ToString
    End Function
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO MstBook (" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE MstBook SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "" & _KeyFieldValue & "")
        End If
        getSaveQuery = _strQuery.ToString
    End Function
#End Region


#Region "TABLE FIELD DECLARE "
    Private Sub defineColName()
        With _ColNames
            .Append("BookId")
            .Append(",BookCode")
            .Append(",BookTrType")
            .Append(",BookName")
            .Append(",NATURE")
            .Append(",BEHAVIOUR")
            .Append(",alies")
            .Append(",BOOKCATEGORY")
            .Append(",ROW_FOR_DETAIL_PLAIN")
            .Append(",ROW_FOR_DETAIL_PRINTED")
            .Append(",ON_LINE_PRINTING")
            .Append(",DRCR")
            .Append(",BOOKORDER")
            .Append(",DisplayForm")
            .Append(",RCPT_ISSUE")
            .Append(",RptFileName_Plain")
            .Append(",RptFileName_Printed")
            .Append(",Group_Code_Filter_String")
            .Append(",REPORT_TITLE")
            .Append(",IDP")
            .Append(",DESIGN_SHADE_REQUIRED")
            .Append(",USE_FOR_YARN_STOCK")
            .Append(",USE_FOR_FINISH_STOCK")
            .Append(",GRADING_DESPATCH_BOOK")
            .Append(",STK_FILTER_STRING")
            .Append(",BookPreFix")
            .Append(",UseChallan")
            .Append(",ACTIVE_STATUS")
        End With
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub MenuFormAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
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
        ObjCls_General.CreateDataTable(tblFormValues1, _ColNames.ToString, "YES")
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
    Private Sub Transport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        Dim LASTCODE As String = ""
        Dim BookCode As String = ""
        RS = "SELECT TOP 1  * FROM MstBook  ORDER BY " & _KeyFieldName & " DESC"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_BookId.Text = DefaltSoftTable.Rows(0).Item("BookId") + 1
            If _FORMMODE = "DELETE" Then
                Txt_BookId.Text = DefaltSoftTable.Rows(0).Item("BookId")
                _KeyFieldValue = Txt_BookId.Text
            End If
        Else
            Txt_BookId.Text = 1
        End If
        BookCode = "0001" & "-" & Txt_BookId.Text.PadLeft(9, "0")
        Txt_BookCode.Text = BookCode
        ''txttrtype.Text = txttrtype.Text & Txt_BookId.Text
        'If Not txttrtype.Text.EndsWith(Txt_BookId.Text) Then
        '    txttrtype.Text &= Txt_BookId.Text
        'End If
    End Sub

#Region "ALTER FORM METHOD"
    Private Sub ALTER_FORM(ByVal strKeyID As String)

        Dim tblTmp As New DataTable
        _FORMMODE = "EDIT"
        RS = getAlter_Form_Query(strKeyID)
        MenuDesign_QueryLoad()
        tblTmp = DefaltSoftTable.Copy
        tblFormValues1.Rows.Clear()
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues1.ImportRow(dr)
        Next

        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblFormValues1)
        'Txt_BookCode.Text = tblFormValues1.Rows(0)("BookCode")
        'txttrtype.Text = tblFormValues1.Rows(0)("BookTrType")
        'Txt_BookName.Text = tblFormValues1.Rows(0)("BookName")
        'txtnature.Text = tblFormValues1.Rows(0)("Nature")
        'Txt_Behaviour.Text = tblFormValues1.Rows(0)("Behaviour")
        'Txt_Alies.Text = tblFormValues1.Rows(0)("alies")
        'Txt_Bookcategory.Text = tblFormValues1.Rows(0)("BOOKCATEGORY")
        'Txt_RcptIssue.Text = tblFormValues1.Rows(0)("RCPT_ISSUE")
        'Txt_RptFileNamePlain.Text = tblFormValues1.Rows(0)("BookName")
        'txtGroupCode.Text = tblFormValues1.Rows(0)("Group_Code_Filter_String")
        'txtReportTitle.Text = tblFormValues1.Rows(0)("REPORT_TITLE")
        'txtUseChallan.Text = tblFormValues1.Rows(0)("UseChallan")
        'Txt_MenuActive.Text = tblFormValues1.Rows(0)("ACTIVE_STATUS")
        If tblTmp.Rows.Count > 0 Then
            Txt_BookId.Focus()
            Txt_BookId.Text = tblTmp.Rows(0)("BookId")
            Txt_BookCode.Text = tblTmp.Rows(0)("BookCode")
            txttrtype.Text = tblTmp.Rows(0)("BookTrType")
            Txt_BookName.Text = tblTmp.Rows(0)("BookName")
            txtnature.Text = tblTmp.Rows(0)("Nature")
            Txt_Behaviour.Text = tblTmp.Rows(0)("Behaviour")
            Txt_Alies.Text = tblTmp.Rows(0)("alies")
            Txt_Bookcategory.Text = tblTmp.Rows(0)("BOOKCATEGORY")
            Txt_RcptIssue.Text = tblTmp.Rows(0)("RCPT_ISSUE")
            Txt_RptFileNamePlain.Text = tblTmp.Rows(0)("BookName")
            txtGroupCode.Text = tblTmp.Rows(0)("Group_Code_Filter_String")
            txtReportTitle.Text = tblTmp.Rows(0)("REPORT_TITLE")
            txtUseChallan.Text = tblTmp.Rows(0)("UseChallan")
            Txt_MenuActive.Text = tblTmp.Rows(0)("ACTIVE_STATUS")
            If tblTmp.Rows.Count = 0 Then
                ObjCls_General.Blank_Object(Me)
                Txt_MenuActive.Text = "YES"
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
            .Append("DELETE FROM MstBook WHERE " & _KeyFieldName & "=" & "" & _KeyFieldValue & "")
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

    Private Sub _MenuPositiomset()
        If _FORMMODE = "ADD" Then
            If Txt_BookId.Text.Trim > "" Then
                RS = "SELECT Max(A.BookId) As BookId FROM MstBook AS A WHERE 1=1 order by BookId desc "
                MenuDesign_QueryLoad()
                If DefaltSoftTable.Rows.Count > 0 AndAlso Not IsDBNull(DefaltSoftTable.Rows(0)("BookId")) AndAlso Val(DefaltSoftTable.Rows(0)("BookId")) > 0 Then
                    Txt_BookId.Text = Val(DefaltSoftTable.Rows(0)("BookId")) + 1
                Else
                    Txt_BookId.Text = 1
                End If
            End If
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
            Call Ctrl_Visible_True(Me.Controls)
            txtUseChallan.Text = "NO"
            Txt_MenuActive.Text = "NO"
            _GetMaxId()
            Txt_BookName.Focus()
            Txt_BookName.Select()
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
            RS = "SELECT TOP 1  * FROM MstBook ORDER BY " & _KeyFieldName & " DESC"
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                Txt_BookId.Text = DefaltSoftTable.Rows(0).Item("BookId")
                _KeyFieldValue = Txt_BookId.Text
            End If
            Call ALTER_FORM(Txt_BookId.Text)
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
            If Txt_BookId.Text = "" Then
                RS = "SELECT TOP 1  * FROM MstBook ORDER BY " & _KeyFieldName & " DESC"
            Else
                RS = "SELECT TOP 1  * FROM MstBook  where " & _KeyFieldName & "=" & Txt_BookId.Text & " ORDER BY " & _KeyFieldName & " DESC"
            End If
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                Txt_BookId.Text = DefaltSoftTable.Rows(0).Item("BookId")
                CurrentBackNumber = Txt_BookId.Text
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
            RS = "SELECT TOP 1  * FROM MstBook where " & _KeyFieldName & "=" & Txt_BookId.Text & "  ORDER BY " & _KeyFieldName & " DESC"
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                Txt_BookId.Text = DefaltSoftTable.Rows(0).Item("BookId")
                CurrentBackNumber = Txt_BookId.Text
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
        Dim BookCode As String = ""
        '_MenuPositiomset()
        If _FORMMODE = "ADD" Then
            _GetMaxId()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Txt_BookId.Text
            Else
                LASTCODE = "1"
            End If
        Else
            LASTCODE = Txt_BookId.Text
            _KeyFieldValue = LASTCODE
        End If
        BookCode = "0001" & "-" & LASTCODE.PadLeft(9, "0")
        tblFormValues1.Rows(0)(_KeyFieldName) = LASTCODE
        Dim txtmenuname As String = Txt_BookName.Text.Trim().ToLower()
        Dim properText As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtmenuname)
        Txt_BookCode.Text = BookCode
        tblFormValues1.Rows(0)("BookTrType") = txttrtype.Text
        tblFormValues1.Rows(0)("BookCode") = Txt_BookCode.Text
        tblFormValues1.Rows(0)("BookName") = properText.Replace("'", "''")
        tblFormValues1.Rows(0)("NATURE") = txtnature.Text
        tblFormValues1.Rows(0)("BEHAVIOUR") = Txt_Behaviour.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("alies") = Txt_Alies.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("BOOKCATEGORY") = Txt_Bookcategory.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("ROW_FOR_DETAIL_PLAIN") = "15"
        tblFormValues1.Rows(0)("ROW_FOR_DETAIL_PRINTED") = "15"
        tblFormValues1.Rows(0)("ON_LINE_PRINTING") = "NO"
        tblFormValues1.Rows(0)("DRCR") = ""
        tblFormValues1.Rows(0)("BOOKORDER") = "0"
        tblFormValues1.Rows(0)("DisplayForm") = ""
        tblFormValues1.Rows(0)("RCPT_ISSUE") = Txt_RcptIssue.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("RptFileName_Plain") = Txt_RptFileNamePlain.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("RptFileName_Printed") = Txt_RptFileNamePlain.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("Group_Code_Filter_String") = txtGroupCode.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("REPORT_TITLE") = txtReportTitle.Text.Replace("'", "''")
        tblFormValues1.Rows(0)("IDP") = ""
        tblFormValues1.Rows(0)("DESIGN_SHADE_REQUIRED") = "CURRENT DATE"
        tblFormValues1.Rows(0)("USE_FOR_YARN_STOCK") = ""
        tblFormValues1.Rows(0)("USE_FOR_FINISH_STOCK") = ""
        tblFormValues1.Rows(0)("GRADING_DESPATCH_BOOK") = ""
        tblFormValues1.Rows(0)("STK_FILTER_STRING") = ""
        tblFormValues1.Rows(0)("BookPreFix") = ""
        tblFormValues1.Rows(0)("UseChallan") = txtUseChallan.Text
        tblFormValues1.Rows(0)("ACTIVE_STATUS") = Txt_MenuActive.Text
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues1, FieldNameAndValues)
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
        Txt_BookId.Text = ""
        txttrtype.Text = ""
        Txt_BookName.Text = ""
        txtnature.Text = ""
        Txt_Behaviour.Text = ""
        Txt_Alies.Text = ""
        Txt_Bookcategory.Text = ""
        Txt_RcptIssue.Text = ""
        Txt_RptFileNamePlain.Text = ""
        txtGroupCode.Text = ""
        txtReportTitle.Text = ""
        txtUseChallan.Text = "NO"
        Txt_MenuActive.Text = "NO"
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

    Private Sub Txt_MenuId_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BookId.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_BookId.Text <> "" Then
                Call ALTER_FORM(Txt_BookId.Text)
            End If
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        View_Record()
    End Sub

#End Region
    Private Sub View_Record()
        RS = "SELECT * FROM MstBook where 1=1 ORDER BY " & _KeyFieldName & " ASC"
        MenuDesign_QueryLoad()
        Dim tblTmp As DataTable
        tblTmp = DefaltSoftTable.Copy
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
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
            Next

            ' Step 2: Sirf required columns editable
            FirstStage.Columns("BookName").OptionsColumn.AllowEdit = True
            FirstStage.Columns("NATURE").OptionsColumn.AllowEdit = True
            FirstStage.Columns("BEHAVIOUR").OptionsColumn.AllowEdit = True
            FirstStage.Columns("alies").OptionsColumn.AllowEdit = True
            FirstStage.Columns("BOOKCATEGORY").OptionsColumn.AllowEdit = True
            FirstStage.Columns("RCPT_ISSUE").OptionsColumn.AllowEdit = True
            FirstStage.Columns("RptFileName_Plain").OptionsColumn.AllowEdit = True
            FirstStage.Columns("Group_Code_Filter_String").OptionsColumn.AllowEdit = True
            FirstStage.Columns("REPORT_TITLE").OptionsColumn.AllowEdit = True
            DevGridFitColumn(GridControl1, FirstStage)
            PnlGrdView.Visible = True

            FirstStage.BestFitColumns()
            FirstStage.Focus()
            PnlGrdView.BringToFront()
            GridControl1.BringToFront()
            FirstStage.OptionsBehavior.Editable = True
            FirstStage.OptionsBehavior.ReadOnly = False
            FirstStage.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Dim _RptTiltle = " Report From :" & Txt_ViewFrom.Text & " To : " & Txt_ViewTO.Text
        Dim _RptTiltle = " Report From : Book Details "
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub FirstStage_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown, FirstStage.KeyDown
        If e.KeyCode = Keys.Space Then
            If FirstStage.FocusedColumn.FieldName = "UseChallan" Then
                Dim currentValue As String = FirstStage.GetFocusedRowCellValue("UseChallan").ToString().ToUpper()
                If currentValue = "YES" Then
                    FirstStage.SetFocusedRowCellValue("UseChallan", "NO")
                Else
                    FirstStage.SetFocusedRowCellValue("UseChallan", "YES")
                End If
                e.Handled = True
            End If
            If FirstStage.FocusedColumn.FieldName = "ACTIVE_STATUS" Then
                Dim currentValue As String = FirstStage.GetFocusedRowCellValue("ACTIVE_STATUS").ToString().ToUpper()
                If currentValue = "YES" Then
                    FirstStage.SetFocusedRowCellValue("ACTIVE_STATUS", "NO")
                Else
                    FirstStage.SetFocusedRowCellValue("ACTIVE_STATUS", "YES")
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
        For Each dr As DataRow In dt.Rows
            If dr.RowState = DataRowState.Modified Then
                Dim cmd As New OleDb.OleDbCommand(RS, MenuDesignConnection)
                If MenuDesignConnection.State = ConnectionState.Closed Then
                    MenuDesignConnection.Open()
                End If
                cmd.CommandText =
                    "UPDATE MstBook SET " &
                    "BookName = ?, " &
                    "NATURE = ?, " &
                    "BEHAVIOUR = ?, " &
                    "alies = ?, " &
                    "BOOKCATEGORY = ?, " &
                    "RCPT_ISSUE = ?, " &
                    "RptFileName_Plain = ?, " &
                    "Group_Code_Filter_String = ?, " &
                    "REPORT_TITLE = ?, " &
                    "UseChallan = ?, " &
                    "ACTIVE_STATUS = ? " &
                    "WHERE BookId = ?"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("", dr("BookName").ToString())
                cmd.Parameters.AddWithValue("", dr("NATURE"))
                cmd.Parameters.AddWithValue("", dr("BEHAVIOUR").ToString())
                cmd.Parameters.AddWithValue("", dr("alies").ToString())
                cmd.Parameters.AddWithValue("", dr("BOOKCATEGORY"))
                cmd.Parameters.AddWithValue("", dr("RCPT_ISSUE"))
                cmd.Parameters.AddWithValue("", dr("RptFileName_Plain"))
                cmd.Parameters.AddWithValue("", dr("Group_Code_Filter_String"))
                cmd.Parameters.AddWithValue("", dr("REPORT_TITLE"))
                cmd.Parameters.AddWithValue("", dr("UseChallan"))
                cmd.Parameters.AddWithValue("", dr("ACTIVE_STATUS").ToString())
                ' WHERE condition
                cmd.Parameters.AddWithValue("", dr("BookId"))
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Next
        MenuDesignConnection.Close()
        MessageBox.Show("Data Updated Successfully")
    End Sub

    Private Sub Txt_BookName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_BookName.KeyDown
        Dim words() As String = Txt_BookName.Text.Trim().Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

        Dim result As String = ""

        For Each word As String In words
            result &= word.Substring(0, 1).ToUpper()
        Next

        ' 01 ya dusre TextBox ki value append karna
        txttrtype.Text = result & Txt_BookId.Text
    End Sub
    'Private Sub _NewBookCreate(book As BookInfo)

    '    _strQuery = New StringBuilder
    '    With _strQuery
    '        .Append(" INSERT INTO MstBook ")
    '        .Append(" ( ")
    '        .Append(" BookCode,BookTrType,BookName,NATURE ")
    '        .Append(" ,BEHAVIOUR,alies,BOOKCATEGORY ")
    '        .Append(" ,RptFileName_Plain,RptFileName_Printed ")
    '        .Append(" ,ROW_FOR_DETAIL_PLAIN,ROW_FOR_DETAIL_PRINTED,ON_LINE_PRINTING ")
    '        .Append(" ,DRCR ")
    '        .Append(" ,BOOKORDER ")
    '        .Append(" ,DisplayForm ")
    '        .Append(" ,RCPT_ISSUE ")
    '        .Append(" ,UseChallan ")
    '        .Append(" ,Y_OWN_STK ")
    '        .Append(" ,UseOFFER ")
    '        .Append(" ,ACTIVE_STATUS ")
    '        .Append(" ,OFFER_LESS_BY ")
    '        .Append(" ,Group_Code_Filter_String ")
    '        .Append(" ,REPORT_TITLE ")
    '        .Append(" ,IDP ")
    '        .Append(" ,DESIGN_SHADE_REQUIRED ")
    '        .Append(" ,USE_FOR_YARN_STOCK ")
    '        .Append(" ,USE_FOR_FINISH_STOCK ")
    '        .Append(" ,GRADING_DESPATCH_BOOK ")
    '        .Append(" ,STK_FILTER_STRING ")
    '        .Append(" ,BookPreFix ")
    '        .Append(" ) ")
    '        .Append(" VALUES ")
    '        .Append(" ( ")
    '        .Append("'" & book.BookCode & "'")
    '        .Append(",'" & book.BookTrType & "'")
    '        .Append(",'" & book.BookName & "'")
    '        .Append(",'" & book.Nature & "'")
    '        .Append(",'" & book.Behaviour & "'")
    '        .Append(",'" & book.Alies & "'")
    '        .Append(",'" & book.BookCategory & "'")
    '        .Append(",'" & book.RptFileNamePlain & "'")
    '        .Append(",'" & book.RptFileNamePlain & "'")
    '        .Append(" ,'15'")
    '        .Append(" ,'15'")
    '        .Append(" ,'NO'")
    '        .Append(",'" & book.DrCr & "'")
    '        .Append(",'" & book.BookOrder & "'")
    '        .Append(",'" & book.DisplayFormName & "'")
    '        .Append(",'" & book.RcptIssue & "'")
    '        .Append(",'" & book.UseChallan & "'")
    '        .Append(",'" & book.YOwnStk & "'")
    '        .Append(",'" & book.UseOffer & "'")
    '        .Append(",'" & book.ActiveStatus & "'")
    '        .Append(",'" & book.OfferLessBy & "'")
    '        .Append(",'" & book.GroupCode & "'")
    '        .Append(",'" & book.ReportTitle & "'")
    '        .Append(",'" & book.Idp & "'")
    '        .Append(",'" & book.DesignShadeRequired & "'")
    '        .Append(",'" & book.UseForYarnStock & "'")
    '        .Append(",'" & book.UseForFinishStock & "'")
    '        .Append(",'" & book.GradingDespatchBook & "'")
    '        .Append(",'" & book.StkFilterString & "'")
    '        .Append(",'" & book.BookPreFix & "'")
    '        .Append(" ) ")
    '    End With
    '    sqL = _strQuery.ToString
    '    sql_Data_Save_Delete_Update()

    'End Sub
    'Public Class BookInfo
    '    Public Property BookCode As String = ""
    '    Public Property BookTrType As String = ""
    '    Public Property BookName As String = ""
    '    Public Property Nature As String = ""
    '    Public Property Behaviour As String = ""
    '    Public Property Alies As String = ""
    '    Public Property BookCategory As String = ""
    '    Public Property RptFileNamePlain As String = ""
    '    Public Property DrCr As String = ""
    '    Public Property BookOrder As String = "0"
    '    Public Property DisplayFormName As String = ""
    '    Public Property RcptIssue As String = ""
    '    Public Property UseChallan As String = ""
    '    Public Property YOwnStk As String = ""
    '    Public Property UseOffer As String = ""
    '    Public Property ActiveStatus As String = ""
    '    Public Property OfferLessBy As String = ""
    '    Public Property GroupCode As String = ""
    '    Public Property ReportTitle As String = ""
    '    Public Property Idp As String = ""
    '    Public Property DesignShadeRequired As String = "CURRENT DATE"
    '    Public Property UseForYarnStock As String = ""
    '    Public Property UseForFinishStock As String = ""
    '    Public Property GradingDespatchBook As String = ""
    '    Public Property StkFilterString As String = ""
    '    Public Property BookPreFix As String = ""
    'End Class
End Class
