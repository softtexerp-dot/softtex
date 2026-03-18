Imports System.Text
Imports DevExpress.XtraRichEdit.Commands

Public Class QueryLoad

    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private _ErrorValue As String = ""
    Private _KeyFieldValue As String = "0"
    Private _KeyFieldName As String = "MainId"
    Private _KeyFormName As String = "FormName"
    Private _TblName As String = "FormQueryMaster"


    Private _FrmLoad As Boolean = True
    Private UC_Buttons1 As UC_Buttons
    Private Change_Grid_Data As Boolean = True
    Private _FORMMODE As String = ""
    Dim txtMainId As Integer = 0
    Dim GetformName As String = ""
    Dim filePath As String
    Private CurrentBackNumber As Integer = 0

    Private Sub QueryLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(5, 0)
        _FrmLoad = True
        TxtType.Text = "VIEW"
        Txt_Active.Text = "YES"
        GetformName = MainFormRead._getformName()
        If GetformName = "" Then
            GetformName = MainMasterFormRead._getformName()
        End If
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")
        CreateButtonsControl()
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        AttachButtonFocusEvents(Me)
        _FrmLoad = False
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
        AddHandler UC_Buttons1.BackClick, AddressOf UC_Buttons1_BackClick
        AddHandler UC_Buttons1.NextClick, AddressOf UC_Buttons1_NextClick
        AddHandler UC_Buttons1.DeleteClick, AddressOf UC_Buttons1_DeleteClick
        AddHandler UC_Buttons1.SaveClick, AddressOf UC_Buttons1_SaveClick
        AddHandler UC_Buttons1.CloseClick, AddressOf UC_Buttons1_CloseClick
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnPrint", "BtnReports", "BtnView")
    End Sub
#Region "Button Click"
    Private Sub UC_Buttons1_AddClick()
        Change_Grid_Data = True
        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            TxtType.Focus()
            Txt_CntrlName.Visible = False
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_EditClick()
        _FORMMODE = "EDIT"
        Txt_CntrlName.Visible = False
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        Dim LASTCODE As String = ""
        If _FORMMODE = "EDIT" Then
            TxtType.Focus()
            _GetMaxId()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item("MainId"))
            Else
                LASTCODE = 1
            End If
        Else
            LASTCODE = _KeyFieldValue
        End If
        If LASTCODE <> "" Then
            ALTER_FORM(LASTCODE)
        End If
        Change_Grid_Data = True
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_BackClick()
        _FrmLoad = False
        Dim LASTCODE As String = ""

        Call Ctrl_Visible_True(Me.Controls)
        Txt_CntrlName.Visible = False
        If _FORMMODE = "EDIT" Then
            TxtType.Focus()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item("MainId")) - 1
            Else
                LASTCODE = "1"
            End If
        End If
        If LASTCODE <> "" Then
            ALTER_FORM(LASTCODE)
        End If
        'Call Ctrl_Visible_True(Me.Controls)
        'UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_NextClick()
        Dim LASTCODE As String = ""
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "EDIT" Then
            TxtType.Focus()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item("MainId")) + 1
            Else
                LASTCODE = "1"
            End If
        End If
        If LASTCODE <> "" Then
            ALTER_FORM(LASTCODE)
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_DeleteClick()

        _FrmLoad = True

        _FORMMODE = "DELETE"

        _FrmLoad = False
        _GetMaxId()
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If txtMainId > 0 Then
            If (Mid(_KeyFieldValue, 1, 4)) = "0" Then
                MsgBox("It's A Default Record, Can't Delete", MsgBoxStyle.Critical, "Soft-Tex PRO")
            Else
                If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Record()
                End If

            End If
        End If
        Ctrl_Visible_True(Me.Controls)
        Change_Grid_Data = True
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub

    Private Sub UC_Buttons1_SaveClick()
        GetformName = MainFormRead._getformName()
        If GetformName = "" Then
            GetformName = MainMasterFormRead._getformName()
        End If
        If Validate_Form_Values() = False Then Exit Sub
        Dim SaveQuery As String = ""
        Dim LASTCODE As String = ""
        If _FORMMODE = "ADD" Then
            _GetMaxId()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item("MainId")) + 1
            Else
                LASTCODE = "1"
            End If
        Else
            LASTCODE = _KeyFieldValue
        End If
        tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
        tblFormValues.Rows(0)(_KeyFormName) = GetformName
        tblFormValues.Rows(0)("Type") = TxtType.Text.Trim()
        tblFormValues.Rows(0)("QueryText") = RTBQuery.Text
        tblFormValues.Rows(0)("CreateDate") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        tblFormValues.Rows(0)("Status") = Txt_Active.Text.Trim()
        tblFormValues.Rows(0)("CntrlName") = Txt_CntrlName.Text
        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        SaveQuery = getSaveQuery()
        'sqL = SaveQuery
        'sql_Data_Save_Delete_Update1()
        RS = SaveQuery.ToString
        MenuDesign_QuerySaveUpdateDelete()
        MessageBox.Show("Save Successfully")
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
        Call Ctrl_Visible_False(Me.Controls)
        Clear()
        'ObjCls_General.Blank_Object(Me)
    End Sub
    Private Sub Clear()
        Txt_Active.Text = "YES"
        TxtType.Text = "VIEW"
        RTBQuery.Text = ""
    End Sub

    Private Sub UC_Buttons1_CloseClick()

        If _FORMMODE = "" Then
            Me.Close()
            Exit Sub
        End If

        Me.Close()
        Me.Dispose(True)

    End Sub

    Private Sub txttype_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtType.KeyDown
        If TxtType.Text.Trim() = "TOTAL COLUMN" Then
            If e.KeyCode = Keys.Enter Then
                Label3.Visible = True
                Label2.Visible = True
                Txt_CntrlName.Visible = True
                'Exit Sub
            Else
                Label3.Visible = False
                Label2.Visible = False
                Txt_CntrlName.Visible = False
                'Exit Sub
            End If
        End If
    End Sub

#End Region
#Region "QUERY SECTION"
    'Public Function GetMaxCode() As String
    '    GetMaxCode = obj_Party_Selection.Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    'End Function
    Private Sub _GetMaxId()
        RS = "SELECT TOP 1  * FROM " & _TblName & "  ORDER BY " & _KeyFieldName & " DESC"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            If _FORMMODE = "DELETE" Or _FORMMODE = "EDIT" Then
                txtMainId = DefaltSoftTable.Rows(0).Item("MainId")
                _KeyFieldValue = txtMainId
            Else
                txtMainId = DefaltSoftTable.Rows(0).Item("MainId") + 1
            End If
        Else
            txtMainId = 1
        End If
    End Sub
    Public Function GetName() As String
        RS = "SELECT TOP 1 FormName FROM " & _TblName & "  WHERE  1=1 AND Type='" & TxtType.Text & "'" & " AND FormName='" & GetformName & "'"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            GetName = DefaltSoftTable.Rows(0).Item("FormName").ToString()
        End If
        Return GetName
    End Function
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
#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("MainId,")
            .Append("FormName,")
            .Append("Type,")
            .Append("QueryText,")
            .Append("CreateDate,")
            .Append("Status,")
            .Append("CntrlName")
        End With
    End Sub
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Dim tblTmp As New DataTable
        Validate_Form_Values = False
        If _FORMMODE = "EDIT" Then
            Validate_Form_Values = True
        Else
            GetName()
            tblTmp = DefaltSoftTable.Copy
            If tblTmp.Rows.Count > 0 Then
                If tblTmp.Rows(0).Item("FormName") = GetformName Then
                    MsgBox("This Form Name " & GetformName & " Type of " & TxtType.Text.Trim() & " Already Exist!")
                    TxtType.Focus()
                    Exit Function
                Else
                    Validate_Form_Values = True
                End If
            Else
                Validate_Form_Values = True
            End If
        End If


    End Function
#End Region
#Region "ALTER FORM METHOD"
    Private Sub ALTER_FORM(ByVal strKeyID As String)
        Dim tblTmp As New DataTable
        '_FORMMODE = "EDIT"
        RS = getAlter_Form_Query(strKeyID)
        MenuDesign_QueryLoad()
        tblTmp = DefaltSoftTable
        tblFormValues.Rows.Clear()

        If tblTmp.Rows.Count > 0 Then
            txtMainId = tblTmp.Rows(0).Item("MainId")
            _KeyFieldValue = txtMainId
            TxtType.Text = tblTmp.Rows(0).Item("Type").ToString()
            RTBQuery.Text = tblTmp.Rows(0).Item("QueryText").ToString()
            Txt_Active.Text = tblTmp.Rows(0).Item("Status").ToString()
            If tblTmp.Rows(0).Item("CntrlName").ToString() <> "" Then
                Txt_CntrlName.Text = tblTmp.Rows(0).Item("CntrlName").ToString()
                Txt_CntrlName.Visible = True
                Label3.Visible = True
                Label2.Visible = True
            Else
                Txt_CntrlName.Text = ""
                Txt_CntrlName.Visible = False
                Txt_CntrlName.Enabled = True
                Label3.Visible = False
                Label2.Visible = False
            End If

        Else
            If tblTmp.Rows.Count = 0 Then
                ObjCls_General.Blank_Object(Me)
                RTBQuery.Text = ""
                Txt_CntrlName.Visible = False
                Label3.Visible = False
                Label2.Visible = False
                Txt_Active.Text = "YES"
                TxtType.Text = "VIEW"
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                'Call Ctrl_Visible_False(Me.Controls)
                MsgBox("Record Not Found")
            End If
        End If
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues.ImportRow(dr)
        Next

        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblFormValues)
    End Sub
#End Region

#Region "DELETE RECORD"
    Private Sub Delete_Record()
        Dim _entryNo As Integer = 0
        _strQuery = New StringBuilder
        With _strQuery
            .Append("DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "'")
        End With
        'sqL = _strQuery.ToString
        'sql_Data_Save_Delete_Update1()
        RS = _strQuery.ToString
        MenuDesign_QuerySaveUpdateDelete()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
        Call Ctrl_Visible_False(Me.Controls)
    End Sub

    Private Sub QueryLoad_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MsgBox("Do You Want To Close(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Close ?") = MsgBoxResult.Yes Then
                _FrmLoad = True
                If _FORMMODE = "" Then
                    Me.Close()
                    Dispose(True)
                ElseIf _FORMMODE <> "" Then
                    _FORMMODE = ""
                    ObjCls_General.Blank_Object(Me)
                    _KeyFieldValue = 0
                    Call Ctrl_Visible_False(Me.Controls)
                    'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                    UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                    _FrmLoad = False
                End If
            End If
        End If
    End Sub
#End Region
End Class