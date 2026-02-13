Imports System.Text
Friend Class Frm_Grader

    Private obj_Party_Selection As New Multi_Selection_Master

#Region "VARIABLE DECLARATION"
    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "GraderCode"
    Private _TblName As String = "MstGrader"
    Private _FrmLoad As Boolean = False
    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtAlter_Name As New TextBox
    Private DispList As Boolean = True
    Private Is_Call_By_Another As Boolean = False

    Private Last_Focused_Btn As String = ""
    Dim old_Me_text As String = ""
#End Region

#Region "QUERY SECTION"
    Public Function GetMaxCode() As String
        GetMaxCode = obj_Party_Selection.Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function
    Public Function GetName() As String
        GetName = obj_Party_Selection.Master_GetNameOtherThisEntry(_TblName, _KeyFieldName, _KeyFieldValue, "GraderName", txtWeaveTypeName.Text)
    End Function
    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT * FROM MstGrader WHERE 1=1 AND GraderCode='" & strKeyID & "'")
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


#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("GraderCode,")
            .Append("GraderName,")
            .Append("OP1")
        End With
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub Transport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If F2_OPEN_FROM = True Then
            Dim x As Integer = 0
            Dim y As Integer
            y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
            Me.Location = New Point(x, y)
        Else
            Me.Location = New Point(0, 0)
        End If

        PnlGrdView.Width = 494
        PnlGrdView.Height = 252
        PnlGrdView.Location = New Point(5, 8)


        old_Me_text = Me.Text
        _FrmLoad = True
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")
        Call Command_Button_Visibility("LOAD")
        Ctrl_Visible_False(Me.Controls)
        btnAdd.Focus()
        btnAdd.Select()
        _FrmLoad = False



    End Sub
    Private Sub Transport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True
            If _FORMMODE = "" Then
                If Label2.Text = "Frm_Grader" Then
                    Me.Close()
                    Me.Dispose(True)
                    'Main_MDI_Frm.MaterToolStripMenuItem.ShowDropDown()
                    'Main_MDI_Frm.WeaveTypeToolStripMenuItem1.Select()
                Else
                    Party_selection.Label1.Text = Label201.Text
                    Party_selection.Label4.Text = Label202.Text
                    Party_selection.Label8.Text = Label203.Text
                    Party_selection.txtSearch.Text = Label204.Text

                    Me.Close()
                    Me.Dispose(True)
                    Own_Selection_List()
                    'close_funcation_selection_list()
                End If
            ElseIf _FORMMODE <> "" Then
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                Call Command_Button_Visibility("LOAD")
                Call Ctrl_Visible_False(Me.Controls)
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                _FrmLoad = False
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

#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE"
    Private Sub btnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.GotFocus
        btnAdd.BackColor = Color.Coral
    End Sub
    Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.LostFocus
        btnAdd.BackColor = Me.BackColor
    End Sub
    Private Sub btnModify_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.GotFocus
        btnModify.BackColor = Color.Coral
    End Sub
    Private Sub btnModify_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.LostFocus
        btnModify.BackColor = Me.BackColor
    End Sub
    Private Sub btnDelete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.GotFocus
        btnDelete.BackColor = Color.Coral
    End Sub
    Private Sub btnDelete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.LostFocus
        btnDelete.BackColor = Me.BackColor
    End Sub
    Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.GotFocus
        btnView.BackColor = Color.Coral
    End Sub
    Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.LostFocus
        btnView.BackColor = Me.BackColor
    End Sub
    Private Sub btnSave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.GotFocus
        btnSave.BackColor = Color.Coral
    End Sub
    Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.LostFocus
        btnSave.BackColor = Me.BackColor
    End Sub
    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.GotFocus
        btnClose.BackColor = Color.Coral
    End Sub
    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.LostFocus
        btnClose.BackColor = Me.BackColor
    End Sub
#End Region




#Region "BTN CLICK/ENTER CODE"
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If _FORMMODE = "" Then


            If Label2.Text = "Frm_Grader" Then
                Me.Close()
                Me.Dispose(True)
                'Main_MDI_Frm.MaterToolStripMenuItem.ShowDropDown()
                'Main_MDI_Frm.WeaveTypeToolStripMenuItem1.Select()
            Else
                Party_selection.Label1.Text = Label201.Text
                Party_selection.Label4.Text = Label202.Text
                Party_selection.Label8.Text = Label203.Text
                Party_selection.txtSearch.Text = Label204.Text

                Me.Close()
                Me.Dispose(True)
                Own_Selection_List()
                'close_funcation_selection_list()
            End If



            'Me.Close()
            'Dispose(True)
            'Main_MDI_Frm.MaterToolStripMenuItem.ShowDropDown()
            'Main_MDI_Frm.WeaveTypeToolStripMenuItem1.Select()
        Else
            If _FORMMODE = "VIEW" Then
                _FORMMODE = ""
                PnlGrdView.Visible = False
                grdView.Visible = False
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
        Call View_Record()
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
        txtWeaveTypeName.Focus()
        txtWeaveTypeName.Select()
    End Sub
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Last_Focused_Btn = "MODIFY"
        _FORMMODE = "EDIT"
        txtAlter_code.Text = ""
        Own_Selection_List()
        If txtAlter_code.Text <> "" Then
            Command_Button_Visibility("BTNEDIT")
            Ctrl_Visible_True(Me.Controls)
            ALTER_FORM(txtAlter_code.Text)
            txtWeaveTypeName.Focus()
            txtWeaveTypeName.Select()
        Else
            _FORMMODE = ""
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        _FrmLoad = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        txtAlter_code.Text = ""
        Own_Selection_List()
        If txtAlter_code.Text <> "" Then
            Ctrl_Visible_True(Me.Controls)
            Call ALTER_FORM(txtAlter_code.Text)
            Call Command_Button_Visibility("BTNDELETE")
            If (Mid(_KeyFieldValue, 1, 4)) = "0000" Then
                MsgBox("It's A Default Record, Can't Delete", MsgBoxStyle.Critical, "Soft-Tex PRO")
            Else

                'If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                'Call Delete_Record()
                'End If

            End If
        End If
        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
    End Sub
#End Region


#Region "VIEW RECORD"
    Private Sub View_Record()
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT 0 AS Sno,a.GraderName AS [Grader Name] ")
            .Append(" FROM Frm_Grader as a ")
            .Append(" ORDER BY a.GraderName ")
        End With
        strQuery = _strQuery.ToString
        FillGrid(grdView, strQuery)

        For i As Int16 = 1 To grdView.Rows - 1
            grdView.Cell(i, 1).Text = i
        Next

        grdView.Column(0).Visible = False
        grdView.Column(1).Visible = True

        grdView.Column(1).Width = 50
        grdView.Column(2).Width = 320

        grdView.Column(0).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(1).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(2).Alignment = FlexCell.AlignmentEnum.LeftCenter

        grdView.ExtendLastCol = False

        Me.Text = old_Me_text + Space(30) + " List of All Record"
        grdView.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        grdView.ScrollBars = FlexCell.ScrollBarsEnum.None
        PnlGrdView.BringToFront()
        PnlGrdView.Visible = True
        grdView.Visible = True
        grdView.Locked = True
        grdView.Focus()
        grdView.Select()
        SendKeys.Send("{DOWN}")
    End Sub
#End Region

#Region "GRID EVENTS CODE"
    Private Sub grdView_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdView.KeyDown
        If e.KeyCode = Keys.Escape Then
            PnlGrdView.Visible = False
            grdView.Visible = False
            Call Command_Button_Visibility("LOAD")
            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Me.Text = old_Me_text
            _FORMMODE = ""
        End If
    End Sub
#End Region

#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        strQuery = GetName()
        If txtWeaveTypeName.Text = "" Then
            MsgBox("Invalid Grader Name")
            txtWeaveTypeName.Focus()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function
#End Region

#Region "SAVE METHOD"
    Private Sub SaveRecord()

        If Validate_Form_Values() = False Then Exit Sub




        Dim CompleteQuery As String = ""
        Dim SaveQuery As String = ""
        Dim strQuery As String = ""
        Dim LASTCODE As String = ""
        If _FORMMODE = "ADD" Then
            ' *** Get Last Code According to Company Selected ***
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

        'Dim _LastID As Integer = -1
        'Try
        '    _LastID = dbConnect.Fire_Query(SaveQuery.ToString)
        'Catch ex As Exception
        '    _LastID = -1
        '    MsgBox(ex.Message)
        'End Try
        'If _LastID > 0 Then
        '    If Master_Copy_To_Another_Company = True Then
        '        Master_Save_To_All_Company(SaveQuery.ToString)
        '    End If
        '    User_Log_Post(_TblName, _KeyFieldName, LASTCODE, txtWeaveTypeName.Text, _UserID, SaveQuery)

        MsgBox("Records Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        '    _KeyFieldValue = 0
        'End If

        'If Is_Call_By_Another = True Then
        '    New_F2_Created_Value = txtWeaveTypeName.Text
        '    Me.Close()
        'Else
        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
        'End If
    End Sub

#End Region

#Region "ALTER FORM METHOD"
    Private Sub ALTER_FORM(ByVal strKeyID As String)
        Dim tblTmp As New DataTable
        _FORMMODE = "EDIT"
        strQuery = getAlter_Form_Query(strKeyID)
        sqL = strQuery
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        tblFormValues.Rows.Clear()
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues.ImportRow(dr)
        Next
        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblFormValues)
        If tblTmp.Rows.Count > 0 Then
        End If
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
        obj_Party_Selection.SINGLE_GRADER_SELECTION()
        txtAlter_Name.Text = MULTY_SELECTION_COLOUM_1_DATA
        txtAlter_code.Text = MULTY_SELECTION_COLOUM_3_DATA
        _lastkEyFieldValue = _KeyFieldValue
        _KeyFieldValue = txtAlter_code.Text


        'If Is_Call_By_Another = True Then Exit Sub
        'If _FrmLoad = True Then Exit Sub

        'Dim _lastkEyFieldValue As String = ""
        'txtAlter_code.Text = ""
        'txtAlter_Name.Text = ""
        'Call SL1.Selection_list_Single(Me, TypeClass.MASTERTYPE.WEAVE_TYPE, txtAlter_Name, txtAlter_code, , Me.Name)
        '_lastkEyFieldValue = _KeyFieldValue
        '_KeyFieldValue = txtAlter_code.Text
    End Sub
#End Region

#Region "NAME VALIDATE"
    Private Sub txtTransportName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeaveTypeName.Validated
        If Len(Trim(txtWeaveTypeName.Text)) > 0 Then
            strQuery = GetName()
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                MsgBox("Grader Type Name Already Exist")
                txtWeaveTypeName.Focus()
            End If

            'If Val(dbConnect.ExecuteScaller(strQuery)) > 0 Then
            '    MsgBox("Weave Type Name Already Exist")
            '    txtWeaveTypeName.Focus()
            'End If
        Else
            Check_TextBox_Cannnot_Empty(sender, _FrmLoad)
        End If
    End Sub
#End Region

#Region "SUB NEW"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub



#End Region
End Class