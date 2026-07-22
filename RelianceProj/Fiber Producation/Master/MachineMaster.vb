Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports DevExpress.Drawing.Internal.Images
Imports DevExpress.Skins.SolidColorHelper
Imports DevExpress.XtraEditors

Public Class MachineMaster

#Region "VARIABLE DECLARATION"
    Private _ColNames As New StringBuilder
    Private _FrmLoad As Boolean = False
    Dim old_Me_text As String = ""
    Private _FORMMODE As String = ""
    Private tblFormValues As New DataTable
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "Schedule_id"
    Private _TblName As String = "Vch_no"
    Private FieldNameAndValues(1) As String
    Private WithEvents txtBookCode As New TextBox
    Private _BookVNo As String = ""
    Private _BookCode As String = ""
    Private _BookTrType As String = ""
    Private _CreatedBy As String = USER_ID
    Private _CheckedBy As String = ""
    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtUOM_code As New TextBox
    Private WithEvents txtdepartment_code As New TextBox
    Dim _lblEntryDate As String
    Public flagstring As String = ""
#End Region
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub MachineMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        'Dim x As Integer
        'Dim y As Integer
        'x = 0
        'y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        'Me.Location = New Point(x, y)

        'PNL_View.Width = Me.Width
        'PNL_View.Height = Me.Height
        'GridControl1.Height = PNL_View.Height - 100
        'GridControl1.Width = PNL_View.Width - 20
        'PNL_View.Location = New Point(0, 0)
        AutoResizeGrid(PNL_View, GridControl1)
        txtFilePath.Visible = False
        txtimageid.Visible = False
        old_Me_text = Me.Text
        _FrmLoad = True
        Call defineColName()
        ObjCls_General.CreateDataTable(tblFormValues, _ColNames.ToString, "YES")

        txtBookCode.Text = "MMSS-000000001"
        _BookTrType = "MMSS1"
        _BookCode = txtBookCode.Text
        BtnOpen.Visible = False
        BtnView.Visible = False

        Ctrl_Visible_False(Me.Controls)
        _FrmLoad = False

        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports")
    End Sub
#Region "QUERY SECTION"

    Public Function Master_GetMaxCode(ByVal _KeyFieldName As String, ByVal _TblName As String, ByVal _SELECTEDCOMPANYCODE As String) As String
        'strQuery = " SELECT  TOP 1 SUBSTRING(" & _KeyFieldName & ",6,10),Main_account_master  FROM " & _TblName & " WHERE LEFT(" & _KeyFieldName & ",4)<>'" & _SELECTEDCOMPANYCODE & "'" & " AND Group_master_finance='FIXED ASSETS MASTER'  ORDER BY " & _KeyFieldName & " DESC "
        strQuery = " SELECT  TOP 1 Main_account_master  FROM " & _TblName & " WHERE  Group_master_finance='FIXED ASSETS MASTER'  ORDER BY " & _KeyFieldName & " DESC "
        Return strQuery.ToString
    End Function


    Public Function GetMaxCode() As String
        GetMaxCode = Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append("A.Schedule_id,") ' enqcode
            '.Append("Group_master_finance,")
            .Append("A.Main_account_master,")
            .Append("A.STATEMASTER,")
            .Append("A.CITYMASTER,")
            .Append("A.TRANSPORT_MASTER,")
            .Append("A.MSTFABRICMASTER,")
            .Append("A.MSTFABRICHEAD,")
            .Append("A.MSTFABRICGROUP,")
            .Append("A.MSTYARNMASTER,")
            .Append("A.MSTITEMGROUP,")
            .Append("A.MSTITEMCOMPANY,")
            .Append("A.MSTITEMMASTER,")
            .Append("A.MST_BARCODE,")
            .Append("A.MST_BATCHID,")
            .Append("A.MSTINSURANCE,")
            .Append("A.MSTFABRIC_ITEM_CATEGORY,")
            .Append("B.CutName,")
            .Append("C.Departmentname,")
            .Append("A.MST_YARN_SHADE,")
            .Append("MST_ACOF,") 'BooktrType
            .Append("MST_STORE_CATEGORY,") 'Bookcode
            .Append("MST_STORE_ITEM_CATEGORY,") 'Created By
            .Append("MST_STORE_ITEM_GROUP,") 'Checked By
            .Append("MST_STORE_ITEM,") 'Checked By
            .Append("MST_STORE_ITEM_TYPE,") 'Image Id
            .Append("A.MSTCUTMASTER")
            .Append("  FROM Vch_no as A ")
            .Append("  LEFT JOIN MstCutMaster AS B  ON A.MSTITEMMASTER=B.ID")
            .Append(" left Join MstDepartment As C on A.MSTINSURANCE=C.Departmentcode ")
            .Append("  WHERE 1=1")
            .Append("  AND A.Group_master_finance='FIXED ASSETS MASTER'")
            .Append("  AND A.Schedule_id='" & strKeyID & "'")
        End With
        Return _strQuery.ToString
    End Function
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "' and Group_master_finance='FIXED ASSETS MASTER'")
        End If
        getSaveQuery = _strQuery.ToString
    End Function
#End Region
#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("Schedule_id,") ' enqcode
            .Append("Group_master_finance,")
            .Append("Main_account_master,")
            .Append("STATEMASTER,")
            .Append("CITYMASTER,")
            .Append("TRANSPORT_MASTER,")
            .Append("MSTCUTMASTER,") 'Entry Date
            .Append("MSTFABRICMASTER,")
            .Append("MSTFABRICHEAD,")
            .Append("MSTFABRICGROUP,")
            .Append("MSTYARNMASTER,")
            .Append("MSTITEMGROUP,")
            .Append("MSTITEMCOMPANY,")
            .Append("MSTITEMMASTER,")
            .Append("MST_BARCODE,")
            .Append("MST_BATCHID,")
            .Append("MSTINSURANCE,")
            .Append("MSTFABRIC_ITEM_CATEGORY,")
            .Append("MST_ACOF,") 'BooktrType
            .Append("MST_STORE_CATEGORY,") 'Bookcode
            .Append("MST_STORE_ITEM_CATEGORY,") 'Created By
            .Append("MST_STORE_ITEM_GROUP,") 'Checked By
            .Append("MST_STORE_ITEM,") 'Image path
            .Append("MST_STORE_ITEM_TYPE,") 'Image Id
            .Append("MST_YARN_SHADE") ' Modify Date
        End With
    End Sub
#End Region

    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Report From :"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub
#Region "Button Click"

    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        _FORMMODE = "ADD"
        _FrmLoad = False
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        Call Ctrl_Visible_True(Me.Controls)
        'ObjCls_General.Blank_Object(Me)
        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
        Else
            txtEntryNo.Text = "1"
        End If
        txtEntryNo.Visible = True
        BtnOpen.Visible = True
        BtnView.Visible = True
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        _FORMMODE = "EDIT"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Call Ctrl_Visible_True(Me.Controls)
        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master"))
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        BtnOpen.Visible = True
        BtnView.Visible = True
        txtEntryNo.Visible = True
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        _FORMMODE = "DELETE"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master"))
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        txtEntryNo.Visible = True
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) - 1
            txtAlter_code.Text = ""
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
            Call Ctrl_Visible_True(Me.Controls)
            txtFilePath.Visible = False
            txtimageid.Visible = False
            BtnOpen.Visible = True
            BtnView.Visible = True
            txtEntryNo.Focus()
            txtEntryNo.Select()
        End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) + 1
            Call Ctrl_Visible_True(Me.Controls)
            BtnOpen.Visible = True
            BtnView.Visible = True
            txtFilePath.Visible = False
            txtimageid.Visible = False
            txtEntryNo.Focus()
            txtEntryNo.Select()
        End If
    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        _FrmLoad = True
        SaveRecord()
        _FrmLoad = False
    End Sub

    Private Sub UC_Buttons1_CloseClick() Handles UC_Buttons1.CloseClick

        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FORMMODE = "VIEW"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Call View_Record()
        txtEntryNo.Visible = True
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"
        MachinePrint.Show()
    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"
    End Sub

#End Region

#Region "SAVE METHOD"
    Private Sub SaveRecord()
        If Validate_Form_Values() = False Then Exit Sub
        Dim CompleteQuery As String = ""
        Dim SaveQuery As String = ""
        Dim strQuery As String = ""
        Dim LASTCODE As String = ""
        If _FORMMODE = "ADD" Then
            sqL = GetMaxCode()
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
                txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
            Else
                LASTCODE = "1"
                txtEntryNo.Text = "1"
            End If
            _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
            LASTCODE = _SELECTEDCOMPANYCODE & "-" & LASTCODE.PadLeft(9, "0")
        Else
            LASTCODE = _KeyFieldValue
        End If
        tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
        tblFormValues.Rows(0)("Main_account_master") = txtEntryNo.Text
        tblFormValues.Rows(0)("STATEMASTER") = Txt_MachineName.Text
        tblFormValues.Rows(0)("CITYMASTER") = Txt_Brand.Text
        tblFormValues.Rows(0)("TRANSPORT_MASTER") = Txtsection.Text
        tblFormValues.Rows(0)("Group_master_finance") = "FIXED ASSETS MASTER"
        If _FORMMODE = "ADD" Then
            tblFormValues.Rows(0)("MSTCUTMASTER") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        If _FORMMODE = "EDIT" Then
            tblFormValues.Rows(0)("MSTCUTMASTER") = _lblEntryDate
            tblFormValues.Rows(0)("MST_YARN_SHADE") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        tblFormValues.Rows(0)("MSTFABRICMASTER") = TxtBoolvalue.Text
        tblFormValues.Rows(0)("MSTFABRICHEAD") = txtdepreciation.Text
        tblFormValues.Rows(0)("MSTFABRICGROUP") = Txtspaceoccup.Text
        tblFormValues.Rows(0)("MSTYARNMASTER") = TxtL.Text
        tblFormValues.Rows(0)("MSTITEMGROUP") = TxtW.Text
        tblFormValues.Rows(0)("MSTITEMCOMPANY") = TxtCategory.Text
        If txtUOM_code.Text = "" Then
            tblFormValues.Rows(0)("MSTITEMMASTER") = "0000-000000001"
        Else
            tblFormValues.Rows(0)("MSTITEMMASTER") = txtUOM_code.Text
        End If
        If txtdepartment_code.Text = "" Then
            tblFormValues.Rows(0)("MSTINSURANCE") = "0000-000000001"
        Else
            tblFormValues.Rows(0)("MSTINSURANCE") = txtdepartment_code.Text
        End If
        tblFormValues.Rows(0)("MST_BARCODE") = TxtHsn.Text
        tblFormValues.Rows(0)("MST_BATCHID") = TxtTaxRate.Text
        tblFormValues.Rows(0)("MSTFABRIC_ITEM_CATEGORY") = TxtAttachment.Text
        tblFormValues.Rows(0)("MST_ACOF") = _BookTrType
        tblFormValues.Rows(0)("MST_STORE_CATEGORY") = _BookCode
        tblFormValues.Rows(0)("MST_STORE_ITEM_CATEGORY") = _CreatedBy 'Created By
        tblFormValues.Rows(0)("MST_STORE_ITEM_GROUP") = _CheckedBy 'Checked By
        'tblFormValues.Rows(0)("MST_STORE_ITEM") = txtFilePath.Text  'Image Path
        'tblFormValues.Rows(0)("MST_STORE_ITEM_TYPE") = txtimageid.Text  'Image Id
        tblFormValues.Rows(0)("MST_STORE_ITEM") = _Imagepath1  'Image Path
        tblFormValues.Rows(0)("MST_STORE_ITEM_TYPE") = _ImageId1 'Image Id
        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
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

        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        'TxtUOm.Enabled = True
        'TxtDepartMent.Enabled = True
    End Sub

    Private Sub _EditLog(ByVal _EntryType As String)
        Dim BookType As String = "FIXED ASSETS MASTER"
        Dim _Item As String = ""
        Dim _Rate As String = ""
        Dim _qty As String = ""
        Dim _Rateon As String = ""
        Dim _ItemDetail As String = ""
        Dim _BarcodeNo As String = ""

        Dim _EditReason As String = ""
        Dim _PartyGstinno As String = ""
        _SaveUserEditLog(txtBookCode.Text,
                            "FIXED ASSETS MASTER",
                            BookType,
                            txtEntryNo.Text,
                            "",
                            CDate(Date.Now).ToString(),
                            "",'txtAccountName.Text
                            "",'txtAccount_Code.Text
                            "",'txtDespatch.Text
                            0.00,
                            _USERNAME,
                            _EntryType,
                            _EditReason,
                            CDate(Date.Now).ToString("yyyy-MM-dd"),
                            _BookVNo,
                            _ItemDetail,
                            CDate(Date.Now).ToString("yyyy-MM-dd"),
                            txtdepreciation.Text,
                            _PartyGstinno
                            )
    End Sub
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If Txt_MachineName.Text = "" Then
            MsgBox("Enter Machine Name")
            Txt_MachineName.Focus()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function

    Private Sub MachineMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If PNL_View.Visible = True Then
                _FrmLoad = True
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                'Call Command_Button_Visibility("LOAD")
                AttachButtonFocusEvents(Me)
                Call Ctrl_Visible_False(Me.Controls)
                'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                _FrmLoad = False
                _FORMMODE = ""
                PNL_View.Visible = False
                Exit Sub
            End If
            _FrmLoad = True
            If _FORMMODE = "" Then
                Me.Close()
            ElseIf _FORMMODE <> "" Then
                _FrmLoad = True
                _FORMMODE = "LOAD"
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                'Call Command_Button_Visibility("LOAD")
                AttachButtonFocusEvents(Me)
                Call Ctrl_Visible_False(Me.Controls)
                'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                _FrmLoad = False
                _FORMMODE = ""
            End If
        End If
    End Sub

    Private Sub txtEntryNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEntryNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If _FORMMODE = "DELETE" Or _FORMMODE = "EDIT" Then

                sqL = "SELECT * FROM vch_no WHERE MAIN_ACCOUNT_MASTER='" & txtEntryNo.Text & "' and Group_master_finance='FIXED ASSETS MASTER' "
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    txtAlter_code.Text = DefaltSoftTable.Rows(0).Item("SCHEDULE_ID").ToString
                Else
                    MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Call Ctrl_Visible_False(Me.Controls)
                    'txtEntryNo.Visible = True
                    'txtEntryNo.Focus()
                    'txtEntryNo.Select()
                    Exit Sub
                End If

                ALTER_FORM(txtAlter_code.Text)

                If _FORMMODE = "DELETE" Then
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Delete_Record()
                        MsgBox("Records Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    End If
                End If


            End If
        End If
    End Sub
#End Region
#Region "ALTER FORM METHOD"
    Private Sub ALTER_FORM(ByVal strKeyID As String)
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query(strKeyID)
        sqL = strQuery
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        tblFormValues.Rows.Clear()
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues.ImportRow(dr)
        Next
        If tblTmp.Rows.Count > 0 Then
            _KeyFieldValue = tblTmp.Rows(0).Item("SCHEDULE_ID").ToString
            Dim EntryDate As String = tblTmp.Rows(0)("MSTCUTMASTER").ToString
            _lblEntryDate = Convert.ToString(tblTmp.Rows(0)("MSTCUTMASTER"))
            txtEntryNo.Text = tblTmp.Rows(0).Item("Main_account_master").ToString
            Txt_MachineName.Text = tblTmp.Rows(0).Item("STATEMASTER").ToString
            Txt_Brand.Text = tblTmp.Rows(0).Item("CITYMASTER").ToString
            Txtsection.Text = tblTmp.Rows(0).Item("TRANSPORT_MASTER").ToString
            TxtBoolvalue.Text = tblTmp.Rows(0).Item("MSTFABRICMASTER").ToString
            txtdepreciation.Text = tblTmp.Rows(0).Item("MSTFABRICHEAD").ToString
            Txtspaceoccup.Text = tblTmp.Rows(0).Item("MSTFABRICGROUP").ToString
            TxtL.Text = tblTmp.Rows(0).Item("MSTYARNMASTER").ToString
            TxtW.Text = tblTmp.Rows(0).Item("MSTITEMGROUP").ToString
            TxtCategory.Text = tblTmp.Rows(0).Item("MSTITEMCOMPANY").ToString
            TxtUOm.Text = tblTmp.Rows(0).Item("CutName").ToString
            txtUOM_code.Text = tblTmp.Rows(0).Item("MSTITEMMASTER").ToString
            TxtHsn.Text = tblTmp.Rows(0).Item("MST_BARCODE").ToString
            TxtTaxRate.Text = tblTmp.Rows(0).Item("MST_BATCHID").ToString
            TxtDepartMent.Text = tblTmp.Rows(0).Item("DepartmentName").ToString
            txtdepartment_code.Text = tblTmp.Rows(0).Item("MSTINSURANCE").ToString
            TxtAttachment.Text = tblTmp.Rows(0).Item("MSTFABRIC_ITEM_CATEGORY").ToString
            txtFilePath.Text = tblTmp.Rows(0).Item("MST_STORE_ITEM").ToString
            txtFilePath.Visible = False
            txtimageid.Text = tblTmp.Rows(0).Item("MST_STORE_ITEM_TYPE").ToString
            txtimageid.Visible = False
            _BookTrType = tblTmp.Rows(0).Item("MST_ACOF").ToString
            _BookCode = tblTmp.Rows(0).Item("MST_STORE_CATEGORY").ToString
            _CreatedBy = tblTmp.Rows(0).Item("MST_STORE_ITEM_CATEGORY").ToString 'Created By
            _CheckedBy = tblTmp.Rows(0).Item("MST_STORE_ITEM_GROUP").ToString 'Checked By
        End If
    End Sub
#End Region
#Region "DELETE RECORD"
    Private Sub Delete_Record()
        Dim _entryNo As Integer = 0
        _strQuery = New StringBuilder
        With _strQuery
            .Append("DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "' and Group_master_finance='FIXED ASSETS MASTER' ")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        'Command_Button_Visibility("LOAD")
        AttachButtonFocusEvents(Me)
        'Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
    End Sub

    Private Sub TxtUOm_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUOm.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim _LoadQuery = NewSelectionList.SINGLE_Cut_SELECTION("")
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Cut_master_frm), TxtUOm.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then
                    txtUOM_code.Text = selected("ACCOUNTCODE").ToString()
                End If
                If selected.ContainsKey("CUTNAME") Then
                    TxtUOm.Text = selected("CUTNAME").ToString()
                End If
            End If
            'TxtUOm.Enabled = False
            TxtHsn.Focus()
        End If
    End Sub

    Private Sub TxtDepartMent_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDepartMent.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim _LoadQuery = NewSelectionList.Single_STORE_DEPARTMENT_Selection("")
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(StoreDepartment), TxtDepartMent.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then
                    txtdepartment_code.Text = selected("ACCOUNTCODE").ToString()
                End If
                If selected.ContainsKey("DepName") Then
                    TxtDepartMent.Text = selected("DepName").ToString()
                End If
            End If
            'TxtDepartMent.Enabled = False
            BtnOpen.Focus()
        End If
    End Sub
#End Region
#Region "VIEW RECORD"
    Private Sub View_Record()
        Try


            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append("A.Main_account_master As MachineNo,")
                .Append("A.STATEMASTER As MachineName,")
                .Append("A.CITYMASTER As Brand,")
                .Append("A.TRANSPORT_MASTER As Section,")
                .Append("A.MSTFABRICMASTER As BoolValue,")
                .Append("A.MSTFABRICHEAD As Depreciation,")
                .Append("A.MSTFABRICGROUP As SpaceOccupied,")
                .Append("A.MSTYARNMASTER AS L,")
                .Append("A.MSTITEMGROUP As W,")
                .Append("A.MSTITEMCOMPANY AS Category,")
                '.Append("A.MSTITEMMASTER,") ' cutcode
                .Append("A.MST_BARCODE As HSN,")
                .Append("A.MST_BATCHID As TaxRate,")
                '.Append("A.MSTINSURANCE,") ' Departmentcode
                .Append("A.MSTFABRIC_ITEM_CATEGORY,")
                .Append("B.CutName As UOM,")
                .Append("C.Departmentname As DepartmentName,")
                .Append("A.MST_YARN_SHADE As ModifiedDate,")
                .Append("A.MSTCUTMASTER As EntryDate")
                .Append("  FROM Vch_no as A ")
                .Append("  LEFT JOIN MstCutMaster AS B  ON A.MSTITEMMASTER=B.ID")
                .Append(" left Join MstDepartment As C on A.MSTINSURANCE=C.Departmentcode ")
                .Append("  WHERE 1=1")
                .Append("  AND A.Group_master_finance='FIXED ASSETS MASTER'")
                .Append("  ORDER BY A.Main_account_master ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim tblTmp = DefaltSoftTable.Copy

            FirstStage.Columns.Clear()
            If tblTmp.Rows.Count > 0 Then
                GridControl1.DataSource = tblTmp
                FirstStage.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
                FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
                FirstStage.RowHeight = 25
                'FirstStage.GroupRowHeight = 30


                PNL_View.BringToFront()
                PNL_View.Visible = True

                FirstStage.BestFitColumns()
                FirstStage.Focus()


            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        'If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
        '    Dim pathSource As String = OpenFileDialog1.FileName
        '    Dim fileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        '    Dim sSource As String = pathSource
        '    If sSource = "OpenFileDialog1" Or sSource.Trim = "" Then Exit Sub
        '    TxtAttachment.Text = fileName
        '    SaveImageToLocalAndServer(sSource)
        'End If
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Select File"
        ofd.Filter = "All Files (*.*)|*.*|PDF Files (*.pdf)|*.pdf|Image Files (*.jpg;*.png)|*.jpg;*.png"
        ofd.Multiselect = False

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = ofd.FileName
            Dim fileName As String = IO.Path.GetFileName(filePath)
            txtFilePath.Text = filePath
            TxtAttachment.Text = fileName
            'MessageBox.Show("Selected File: " & fileName)
        End If
        'If txtFilePath.Text <> "" AndAlso TxtAttachment.Text <> "" Then
        If _FORMMODE = "ADD" Then
                flagstring = "save"
            SubmitComplaintAsync(txtFilePath.Text, flagstring, txtimageid.Text, _FORMMODE)
            txtFilePath.Visible = False
            txtimageid.Visible = False
        ElseIf _FORMMODE = "EDIT" Then
                flagstring = "update"
            SubmitComplaintAsync(txtFilePath.Text, flagstring, txtimageid.Text, _FORMMODE)
            txtFilePath.Visible = False
            txtimageid.Visible = False
        End If
        'End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        '_ImageView_Click(TxtAttachment.Text)
        If _FORMMODE = "ADD" Then
            flagstring = "save"
            _Imagepath1 = txtFilePath.Text
            _ImageId1 = txtimageid.Text
        ElseIf _FORMMODE = "EDIT" Then
            flagstring = "update"
            'ALTER_FORM(txtAlter_code.Text)
            If txtFilePath.Text = "" Then
                txtFilePath.Text = _Imagepath1
                txtimageid.Text = _ImageId1
            Else
                _Imagepath1 = txtFilePath.Text
                _ImageId1 = txtimageid.Text
            End If
        End If
        _ImageView_Click(_Imagepath1, flagstring, _FORMMODE)
    End Sub
    '    Public Sub _ImageView_Click(ByVal _IamgePath As String, ByVal _flagstring As String, ByVal _FORMMODE As String)
    '        Try
    '            If _FORMMODE = "ADD" Then

    '                flagstring = "save"
    '                Dim _FilePath As String = _IamgePath
    '                If System.IO.File.Exists(_FilePath) = True Then
    '                    'Process.Start(_FilePath)
    '                    'Dim frm As New Form With
    '                    '{
    '                    '.Text = "Preview",
    '                    '.Width = 900,
    '                    '.Height = 600,
    '                    '.StartPosition = FormStartPosition.CenterScreen,
    '                    '.FormBorderStyle = FormBorderStyle.FixedDialog,
    '                    '.MaximizeBox = False,
    '                    '.MinimizeBox = False
    '                    '}
    '                    'Dim pic As New PictureBox With {
    '                    '        .Dock = DockStyle.Fill,
    '                    '        .SizeMode = PictureBoxSizeMode.Zoom,
    '                    '        .ImageLocation = _FilePath
    '                    '    }
    '                    'frm.KeyPreview = True
    '                    'frm.Controls.Add(pic)
    '                    ''frm.Controls.Add(wb)
    '                    'AddHandler frm.KeyDown,
    '                    'Sub(s, e)
    '                    '    If e.KeyCode = Keys.Escape Then
    '                    '        frm.Close()
    '                    '    End If
    '                    'End Sub
    '                    'frm.ShowDialog()
    '                    Dim frm As New Form With {
    '   .Text = "Preview",
    '   .Width = 900,
    '   .Height = 600,
    '   .StartPosition = FormStartPosition.CenterScreen,
    '   .FormBorderStyle = FormBorderStyle.FixedDialog,
    '   .MaximizeBox = False,
    '   .MinimizeBox = False,
    '   .KeyPreview = True
    '}



    '                    ' Top Panel (Buttons के लिए)
    '                    Dim pnl As New Panel With {
    '    .Dock = DockStyle.Top,
    '    .Height = 45
    '}

    '                    frm.Controls.Add(pnl)

    '                    ' PictureBox
    '                    Dim pic As New PictureBox With {
    '    .Dock = DockStyle.Fill,
    '    .SizeMode = PictureBoxSizeMode.Zoom,
    '    .ImageLocation = _FilePath
    '}

    '                    frm.Controls.Add(pic)
    '                    Dim flp As New FlowLayoutPanel With {
    '    .Dock = DockStyle.Fill,
    '    .FlowDirection = FlowDirection.LeftToRight,
    '    .WrapContents = False
    '}


    '                    ' Panel हमेशा ऊपर रहे
    '                    pnl.BringToFront()
    '                    ' Download Button
    '                    Dim btnDownload As New SimpleButton With {
    '    .Text = "Download",
    '    .Width = 100,
    '    .Height = 30
    '}

    '                    Dim btnClose As New SimpleButton With {
    '    .Text = "Close",
    '    .Width = 100,
    '    .Height = 30
    '}
    '                    flp.Controls.Add(btnDownload)
    '                    flp.Controls.Add(btnClose)

    '                    ' Buttons Center
    '                    flp.Padding = New Padding((frm.ClientSize.Width - (btnDownload.Width + btnClose.Width + 15)) \ 2, 7, 0, 0)

    '                    pnl.Controls.Add(flp)
    '                    frm.Controls.Add(pnl)
    '                    ' Center Top Position

    '                    AddHandler frm.Shown,
    'Sub()

    '    Dim gap As Integer = 15
    '    Dim totalWidth As Integer = btnDownload.Width + btnClose.Width + gap

    '    btnDownload.Location = New Point((pnl.Width - totalWidth) \ 2, 7)
    '    btnClose.Location = New Point(btnDownload.Right + gap, 7)

    'End Sub
    '                    ' Download Button Click
    '                    AddHandler btnDownload.Click,
    '                    Sub()

    '                        If pic.Image Is Nothing Then
    '                            MessageBox.Show("No image available.")
    '                            Exit Sub
    '                        End If

    '                        Using sfd As New SaveFileDialog()
    '                            sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp"
    '                            sfd.FileName = IO.Path.GetFileName(_FilePath)

    '                            If sfd.ShowDialog() = DialogResult.OK Then

    '                                Select Case IO.Path.GetExtension(sfd.FileName).ToLower()
    '                                    Case ".jpg", ".jpeg"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
    '                                    Case ".png"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
    '                                    Case ".bmp"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
    '                                End Select

    '                                MessageBox.Show("Image downloaded successfully.")
    '                            End If
    '                        End Using

    '                    End Sub

    '                    ' Close Button
    '                    AddHandler btnClose.Click,
    '                    Sub()
    '                        frm.Close()
    '                    End Sub

    '                    ' ESC Key
    '                    AddHandler frm.KeyDown,
    '                    Sub(s, e)
    '                        If e.KeyCode = Keys.Escape Then
    '                            frm.Close()
    '                        End If
    '                    End Sub

    '                    frm.ShowDialog()
    '                Else
    '                    'Process.Start(_FilePath)
    '                    Dim frm As New Form With {
    '    .Text = "Preview",
    '    .Width = 900,
    '    .Height = 600,
    '    .StartPosition = FormStartPosition.CenterScreen,
    '    .FormBorderStyle = FormBorderStyle.FixedDialog,
    '    .MaximizeBox = False,
    '    .MinimizeBox = False,
    '    .KeyPreview = True
    '}



    '                    ' Top Panel (Buttons के लिए)
    '                    Dim pnl As New Panel With {
    '    .Dock = DockStyle.Top,
    '    .Height = 45
    '}

    '                    frm.Controls.Add(pnl)

    '                    ' PictureBox
    '                    Dim pic As New PictureBox With {
    '    .Dock = DockStyle.Fill,
    '    .SizeMode = PictureBoxSizeMode.Zoom,
    '    .ImageLocation = _FilePath
    '}

    '                    frm.Controls.Add(pic)
    '                    Dim flp As New FlowLayoutPanel With {
    '    .Dock = DockStyle.Fill,
    '    .FlowDirection = FlowDirection.LeftToRight,
    '    .WrapContents = False
    '}


    '                    ' Panel हमेशा ऊपर रहे
    '                    pnl.BringToFront()
    '                    ' Download Button
    '                    Dim btnDownload As New SimpleButton With {
    '    .Text = "Download",
    '    .Width = 100,
    '    .Height = 30
    '}

    '                    Dim btnClose As New SimpleButton With {
    '    .Text = "Close",
    '    .Width = 100,
    '    .Height = 30
    '}
    '                    flp.Controls.Add(btnDownload)
    '                    flp.Controls.Add(btnClose)

    '                    ' Buttons Center
    '                    flp.Padding = New Padding((frm.ClientSize.Width - (btnDownload.Width + btnClose.Width + 15)) \ 2, 7, 0, 0)

    '                    pnl.Controls.Add(flp)
    '                    frm.Controls.Add(pnl)
    '                    ' Center Top Position

    '                    AddHandler frm.Shown,
    'Sub()

    '    Dim gap As Integer = 15
    '    Dim totalWidth As Integer = btnDownload.Width + btnClose.Width + gap

    '    btnDownload.Location = New Point((pnl.Width - totalWidth) \ 2, 7)
    '    btnClose.Location = New Point(btnDownload.Right + gap, 7)

    'End Sub
    '                    ' Download Button Click
    '                    AddHandler btnDownload.Click,
    '                    Sub()

    '                        If pic.Image Is Nothing Then
    '                            MessageBox.Show("No image available.")
    '                            Exit Sub
    '                        End If

    '                        Using sfd As New SaveFileDialog()
    '                            sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp"
    '                            sfd.FileName = IO.Path.GetFileName(_FilePath)

    '                            If sfd.ShowDialog() = DialogResult.OK Then

    '                                Select Case IO.Path.GetExtension(sfd.FileName).ToLower()
    '                                    Case ".jpg", ".jpeg"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
    '                                    Case ".png"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
    '                                    Case ".bmp"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
    '                                End Select

    '                                MessageBox.Show("Image downloaded successfully.")
    '                            End If
    '                        End Using

    '                    End Sub

    '                    ' Close Button
    '                    AddHandler btnClose.Click,
    '                    Sub()
    '                        frm.Close()
    '                    End Sub

    '                    ' ESC Key
    '                    AddHandler frm.KeyDown,
    '                    Sub(s, e)
    '                        If e.KeyCode = Keys.Escape Then
    '                            frm.Close()
    '                        End If
    '                    End Sub

    '                    frm.ShowDialog()
    '                    'MsgBox("File Does Not Exist")
    '                End If
    '            ElseIf _FORMMODE = "EDIT" Then
    '                flagstring = "update"
    '                Dim _FilePath As String = _IamgePath
    '                If System.IO.File.Exists(_FilePath) = True Then
    '                    Process.Start(_FilePath)
    '                ElseIf _FilePath.StartsWith("HTTP", StringComparison.OrdinalIgnoreCase) Then
    '                    'Dim frm As New Form With
    '                    '{
    '                    '.Text = "Preview",
    '                    '.Width = 900,
    '                    '.Height = 600,
    '                    '.StartPosition = FormStartPosition.CenterScreen,
    '                    '.FormBorderStyle = FormBorderStyle.FixedDialog,
    '                    '.MaximizeBox = False,
    '                    '.MinimizeBox = False
    '                    '}
    '                    'Dim pic As New PictureBox With {
    '                    '        .Dock = DockStyle.Fill,
    '                    '        .SizeMode = PictureBoxSizeMode.Zoom,
    '                    '        .ImageLocation = _FilePath
    '                    '    }
    '                    'frm.KeyPreview = True
    '                    'frm.Controls.Add(pic)
    '                    ''frm.Controls.Add(wb)
    '                    'AddHandler frm.KeyDown,
    '                    'Sub(s, e)
    '                    '    If e.KeyCode = Keys.Escape Then
    '                    '        frm.Close()
    '                    '    End If
    '                    'End Sub
    '                    'frm.ShowDialog()
    '                    Dim frm As New Form With {
    '    .Text = "Preview",
    '    .Width = 900,
    '    .Height = 600,
    '    .StartPosition = FormStartPosition.CenterScreen,
    '    .FormBorderStyle = FormBorderStyle.FixedDialog,
    '    .MaximizeBox = False,
    '    .MinimizeBox = False,
    '    .KeyPreview = True
    '}



    '                    ' Top Panel (Buttons के लिए)
    '                    Dim pnl As New Panel With {
    '    .Dock = DockStyle.Top,
    '    .Height = 45
    '}

    '                    frm.Controls.Add(pnl)

    '                    ' PictureBox
    '                    Dim pic As New PictureBox With {
    '    .Dock = DockStyle.Fill,
    '    .SizeMode = PictureBoxSizeMode.Zoom,
    '    .ImageLocation = _FilePath
    '}

    '                    frm.Controls.Add(pic)
    '                    Dim flp As New FlowLayoutPanel With {
    '    .Dock = DockStyle.Fill,
    '    .FlowDirection = FlowDirection.LeftToRight,
    '    .WrapContents = False
    '}


    '                    ' Panel हमेशा ऊपर रहे
    '                    pnl.BringToFront()
    '                    ' Download Button
    '                    Dim btnDownload As New SimpleButton With {
    '    .Text = "Download",
    '    .Width = 100,
    '    .Height = 30
    '}

    '                    Dim btnClose As New SimpleButton With {
    '    .Text = "Close",
    '    .Width = 100,
    '    .Height = 30
    '}
    '                    flp.Controls.Add(btnDownload)
    '                    flp.Controls.Add(btnClose)

    '                    ' Buttons Center
    '                    flp.Padding = New Padding((frm.ClientSize.Width - (btnDownload.Width + btnClose.Width + 15)) \ 2, 7, 0, 0)

    '                    pnl.Controls.Add(flp)
    '                    frm.Controls.Add(pnl)
    '                    ' Center Top Position

    '                    AddHandler frm.Shown,
    'Sub()

    '    Dim gap As Integer = 15
    '    Dim totalWidth As Integer = btnDownload.Width + btnClose.Width + gap

    '    btnDownload.Location = New Point((pnl.Width - totalWidth) \ 2, 7)
    '    btnClose.Location = New Point(btnDownload.Right + gap, 7)

    'End Sub
    '                    ' Download Button Click
    '                    AddHandler btnDownload.Click,
    '                    Sub()

    '                        If pic.Image Is Nothing Then
    '                            MessageBox.Show("No image available.")
    '                            Exit Sub
    '                        End If

    '                        Using sfd As New SaveFileDialog()
    '                            sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp"
    '                            sfd.FileName = IO.Path.GetFileName(_FilePath)

    '                            If sfd.ShowDialog() = DialogResult.OK Then

    '                                Select Case IO.Path.GetExtension(sfd.FileName).ToLower()
    '                                    Case ".jpg", ".jpeg"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Jpeg)
    '                                    Case ".png"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Png)
    '                                    Case ".bmp"
    '                                        pic.Image.Save(sfd.FileName, Imaging.ImageFormat.Bmp)
    '                                End Select

    '                                MessageBox.Show("Image downloaded successfully.")
    '                            End If
    '                        End Using

    '                    End Sub

    '                    ' Close Button
    '                    AddHandler btnClose.Click,
    '                    Sub()
    '                        frm.Close()
    '                    End Sub

    '                    ' ESC Key
    '                    AddHandler frm.KeyDown,
    '                    Sub(s, e)
    '                        If e.KeyCode = Keys.Escape Then
    '                            frm.Close()
    '                        End If
    '                    End Sub

    '                    frm.ShowDialog()

    '                Else
    '                    MsgBox("File Does Not Exist")
    '                End If
    '            Else
    '                Dim _FilePath As String = _IamgePath
    '                If System.IO.File.Exists(_FilePath) = True Then
    '                    Process.Start(_FilePath)
    '                Else
    '                    MsgBox("File Does Not Exist")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    End Sub
#End Region
End Class