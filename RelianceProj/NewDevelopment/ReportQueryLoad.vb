Imports System.Text


Public Class ReportQueryLoad
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
    'Dim GetformName As String = ""
    Public Property GetformName As String
    Dim filePath As String
    Private CurrentBackNumber As Integer = 0
    'Public _SeletedReportType As String
    Public Property _SeletedReportType As String

    Private Sub ReportQueryLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 60)
        _FrmLoad = True
        'MsgBox(_SeletedReportType)
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")
        CreateButtonsControl()
        'Ctrl_Visible_False(Me.Controls)
        'UC_Buttons1._ButtonEnableDisable("LOAD")
        Call Ctrl_Visible_True(Me.Controls)
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
        'AddHandler UC_Buttons1.AddClick, AddressOf UC_Buttons1_AddClick
        'AddHandler UC_Buttons1.EditClick, AddressOf UC_Buttons1_EditClick
        'AddHandler UC_Buttons1.BackClick, AddressOf UC_Buttons1_BackClick
        'AddHandler UC_Buttons1.NextClick, AddressOf UC_Buttons1_NextClick
        'AddHandler UC_Buttons1.DeleteClick, AddressOf UC_Buttons1_DeleteClick
        AddHandler UC_Buttons1.SaveClick, AddressOf UC_Buttons1_SaveClick
        AddHandler UC_Buttons1.CloseClick, AddressOf UC_Buttons1_CloseClick
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnAdd", "BtnEdit", "BtnBack", "BtnNext", "BtnDelete", "BtnPrint", "BtnReports", "BtnView")
    End Sub
#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("MainId,")
            .Append("FormName,")
            .Append("Type,")
            .Append("QueryText,")
            .Append("CreateDate,")
            .Append("Status,")
            .Append("MainMasterId,")
            .Append("CntrlName")
        End With
    End Sub
#End Region
#Region "Button Click"
    Private Sub UC_Buttons1_AddClick()
        Change_Grid_Data = True
        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            RTBQuery.Focus()
            'TxtType.Focus()
            'Txt_CntrlName.Visible = False
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub

    Private Sub UC_Buttons1_SaveClick()
        'GetformName = ReportForm._getformName()
        _FORMMODE = "ADD"
        If Validate_Form_Values() = False Then Exit Sub
        Dim SaveQuery As String = ""
        Dim LASTCODE As String = ""
        If _FORMMODE = "ADD" Then
            RS = "Delete FROM " & _TblName & "  WHERE  1=1 AND MainMasterId=" & ReportsSelectionSettingForm._ModiMAsterid & " and FormName='" & ReportsSelectionSettingForm._LoadFormName.ToString() & "' "
            MenuDesign_QuerySaveUpdateDelete()
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
        If String.IsNullOrEmpty(GetformName()) Then
            tblFormValues.Rows(0)(_KeyFormName) = ReportsSelectionSettingForm._LoadFormName.ToString()
        Else
            tblFormValues.Rows(0)(_KeyFormName) = GetformName()
        End If
        tblFormValues.Rows(0)("Type") = _SeletedReportType
        tblFormValues.Rows(0)("QueryText") = RTBQuery.Text
        tblFormValues.Rows(0)("CreateDate") = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        tblFormValues.Rows(0)("Status") = "Yes"
        tblFormValues.Rows(0)("MainMasterId") = ReportsSelectionSettingForm._ModiMAsterid.ToString().Replace("'", "").Trim()
        tblFormValues.Rows(0)("CntrlName") = ""
        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        SaveQuery = getSaveQuery()
        RS = SaveQuery.ToString
        MenuDesign_QuerySaveUpdateDelete()
        MessageBox.Show("Save Successfully")
    End Sub
    Private Sub Clear()
        'Txt_Active.Text = "YES"
        'TxtType.Text = "VIEW"
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
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Dim tblTmp As New DataTable
        Validate_Form_Values = False

        Validate_Form_Values = True
    End Function
#End Region
#Region "QUERY SECTION"
    'Public Function GetMaxCode() As String
    '    GetMaxCode = obj_Party_Selection.Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    'End Function
    Private Sub _GetMaxId()
        RS = "SELECT TOP 1  * FROM " & _TblName & "  ORDER BY " & _KeyFieldName & " DESC"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtMainId = DefaltSoftTable.Rows(0).Item("MainId") + 1
        Else
            txtMainId = 1
        End If
    End Sub
    Public Function GetName() As String
        RS = "SELECT TOP 1 FormName,QueryText FROM " & _TblName & "  WHERE  1=1 AND Type='" & _SeletedReportType & "' and MainMasterId=" & ReportsSelectionSettingForm._ModiMAsterid & ""
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            GetName = DefaltSoftTable.Rows(0).Item("FormName").ToString()
            RTBQuery.Text = DefaltSoftTable.Rows(0).Item("QueryText").ToString()
            RTBQuery.Visible = True
        End If
        Return GetName
    End Function

    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        getSaveQuery = _strQuery.ToString
    End Function

    Private Sub ReportQueryLoad_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
End Class