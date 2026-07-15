Imports System.Text
Imports DevExpress.XtraBars.Customization

Public Class VendorMaster

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
    'Private WithEvents txtUOM_code As New TextBox
    'Private WithEvents txtdepartment_code As New TextBox
    Dim _lblEntryDate As String
#End Region
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub MachineMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
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

        txtBookCode.Text = "VVMM-000000001"
        _BookTrType = "VVMM1"
        _BookCode = txtBookCode.Text
        Ctrl_Visible_False(Me.Controls)
        _FrmLoad = False

        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable("LOAD")
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UC_Buttons1.HideButtons("BtnReports", "BtnBack", "BtnNext", "BtnPrint", "BtnDelete")
    End Sub
#Region "QUERY SECTION"

    Public Function Master_GetMaxCode(ByVal _KeyFieldName As String, ByVal _TblName As String, ByVal _SELECTEDCOMPANYCODE As String) As String
        'strQuery = " SELECT  TOP 1 SUBSTRING(" & _KeyFieldName & ",6,10),Main_account_master  FROM " & _TblName & " WHERE LEFT(" & _KeyFieldName & ",4)<>'" & _SELECTEDCOMPANYCODE & "'" & " AND Group_master_finance='VENDOR MASTER'  ORDER BY " & _KeyFieldName & " DESC "
        strQuery = " SELECT  TOP 1 Main_account_master  FROM " & _TblName & " WHERE  Group_master_finance='VENDOR MASTER'  ORDER BY " & _KeyFieldName & " DESC "
        Return strQuery.ToString
    End Function


    Public Function GetMaxCode() As String
        GetMaxCode = Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append("A.Schedule_id,")
            .Append("A.Main_account_master,") ' Vendor Id
            .Append("A.STATEMASTER,") 'Vendaor Name
            .Append("A.CITYMASTER,") 'Remark
            .Append("A.TRANSPORT_MASTER,") 'Vendor Code
            .Append("A.MST_YARN_SHADE,")
            .Append("MST_ACOF,") 'BooktrType
            .Append("MST_STORE_CATEGORY,") 'Bookcode
            .Append("MST_STORE_ITEM_CATEGORY,") 'Created By
            .Append("MST_STORE_ITEM_GROUP,") 'Checked By
            .Append("A.MSTCUTMASTER")
            .Append("  FROM Vch_no as A ")
            .Append("  WHERE 1=1")
            .Append("  AND A.Group_master_finance='VENDOR MASTER'")
            .Append("  AND A.Schedule_id='" & strKeyID & "'")
        End With
        Return _strQuery.ToString
    End Function
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "' and Group_master_finance='VENDOR MASTER' ")
        End If
        getSaveQuery = _strQuery.ToString
    End Function
#End Region
#Region "TABLE FIELD DECLARE"
    Private Sub defineColName()
        With _ColNames
            .Append("Schedule_id,")
            .Append("Group_master_finance,")
            .Append("Main_account_master,") ' Vendor Id
            .Append("STATEMASTER,") 'Vendaor Name
            .Append("CITYMASTER,") 'Remark
            .Append("TRANSPORT_MASTER,") 'Vendor Code
            .Append("MSTCUTMASTER,") 'Entry Date
            .Append("MST_ACOF,") 'BooktrType
            .Append("MST_STORE_CATEGORY,") 'Bookcode
            .Append("MST_STORE_ITEM_CATEGORY,") 'Created By
            .Append("MST_STORE_ITEM_GROUP,") 'Checked By
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
            Txtsection.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
            Txtsection.Text = "VC" & Txtsection.Text.PadLeft(4, "0")
            Txtsection.ReadOnly = True
        Else
            txtEntryNo.Text = "1"
            Txtsection.Text = "1"
            Txtsection.Text = "VC" & Txtsection.Text.PadLeft(4, "0")
            Txtsection.ReadOnly = True
        End If
        'txtEntryNo.Visible = True
        'txtEntryNo.Focus()
        'txtEntryNo.Select()
        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()
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
        'txtEntryNo.Visible = True
        'txtEntryNo.Focus()
        'txtEntryNo.Select()
        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()
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
        'txtEntryNo.Visible = True
        'txtEntryNo.Focus()
        'txtEntryNo.Select()
        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) - 1
            txtAlter_code.Text = ""
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
            Call Ctrl_Visible_True(Me.Controls)
            'txtEntryNo.Focus()
            'txtEntryNo.Select()
            'Txt_MachineName.Visible = True
            Txt_MachineName.Focus()
            Txt_MachineName.Select()
        End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) + 1
            Call Ctrl_Visible_True(Me.Controls)
            'txtEntryNo.Focus()
            'txtEntryNo.Select()
            'Txt_MachineName.Visible = True
            Txt_MachineName.Focus()
            Txt_MachineName.Select()
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
        'txtEntryNo.Visible = True
        'txtEntryNo.Focus()
        'txtEntryNo.Select()
        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"
        VendorMasterPrint.Show()
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
        Dim VENDORCODE As String = ""
        If _FORMMODE = "ADD" Then
            sqL = GetMaxCode()
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
                txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
                Txtsection.Text = Val(DefaltSoftTable.Rows(0).Item("Main_account_master")) + 1
                Txtsection.Text = "VC" & Txtsection.Text.PadLeft(4, "0")
            Else
                LASTCODE = "1"
                txtEntryNo.Text = "1"
                Txtsection.Text = "1"
                Txtsection.Text = "VC" & Txtsection.Text.PadLeft(4, "0")

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
        tblFormValues.Rows(0)("Group_master_finance") = "VENDOR MASTER"
        If _FORMMODE = "ADD" Then
            tblFormValues.Rows(0)("MSTCUTMASTER") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        If _FORMMODE = "EDIT" Then
            tblFormValues.Rows(0)("MSTCUTMASTER") = _lblEntryDate
            tblFormValues.Rows(0)("MST_YARN_SHADE") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        tblFormValues.Rows(0)("MST_ACOF") = _BookTrType
        tblFormValues.Rows(0)("MST_STORE_CATEGORY") = _BookCode
        tblFormValues.Rows(0)("MST_STORE_ITEM_CATEGORY") = _CreatedBy 'Created By
        tblFormValues.Rows(0)("MST_STORE_ITEM_GROUP") = _CheckedBy 'Checked By
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
        UC_Buttons1._ButtonEnableDisable("LOAD")
        Ctrl_Visible_False(Me.Controls)
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub _EditLog(ByVal _EntryType As String)
        Dim BookType As String = "VENDOR MASTER"
        Dim _Item As String = ""
        Dim _Rate As String = ""
        Dim _qty As String = ""
        Dim _Rateon As String = ""
        Dim _ItemDetail As String = ""
        Dim _BarcodeNo As String = ""

        Dim _EditReason As String = ""
        Dim _PartyGstinno As String = ""
        _SaveUserEditLog(txtBookCode.Text,
                            "VENDOR MASTER",
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
                            "",
                            _PartyGstinno
                            )
    End Sub
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If Txt_MachineName.Text = "" Then
            MsgBox("Enter Vendor Name")
            Txt_MachineName.Focus()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function

    Private Sub MachineMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If PNL_View.Visible = True Then
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
                AttachButtonFocusEvents(Me)
                Call Ctrl_Visible_False(Me.Controls)
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

                sqL = "SELECT * FROM vch_no WHERE MAIN_ACCOUNT_MASTER='" & txtEntryNo.Text & "' and Group_master_finance='VENDOR MASTER' "
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    txtAlter_code.Text = DefaltSoftTable.Rows(0).Item("SCHEDULE_ID").ToString
                Else
                    MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Call Ctrl_Visible_False(Me.Controls)
                    Exit Sub
                End If

                ALTER_FORM(txtAlter_code.Text)

                If _FORMMODE = "DELETE" Then
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Delete ?") = MsgBoxResult.Yes Then
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
            .Append("DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "' and Group_master_finance='VENDOR MASTER' ")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        AttachButtonFocusEvents(Me)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
    End Sub

#End Region
#Region "VIEW RECORD"
    Private Sub View_Record()
        Try


            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append("A.Main_account_master As VendorNo,")
                .Append("A.STATEMASTER As VendorName,")
                .Append("A.CITYMASTER As Remark,")
                .Append("A.TRANSPORT_MASTER As VendorCode,")
                .Append("A.MST_YARN_SHADE As ModifiedDate,")
                .Append("A.MSTCUTMASTER As EntryDate")
                .Append("  FROM Vch_no as A ")
                .Append("  WHERE 1=1")
                .Append("  AND A.Group_master_finance='VENDOR MASTER'")
                .Append("  AND A.STATEMASTER='" & Txt_MachineName.Text & "'")
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

    Private Sub Txt_MachineName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MachineName.KeyPress
        If _FrmLoad = True Or Asc(e.KeyChar) = 27 Then Exit Sub
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            If _FORMMODE = "DELETE" Or _FORMMODE = "EDIT" Then
                Dim _Filterstring As String = " "
                Dim _LoadQuery = NewSelectionList.SINGLE_VENDORMASTER_SELECTION(_Filterstring)
                Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, Txt_MachineName.Text, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTCODE") Then Txtsection.Text = selected("ACCOUNTCODE").ToString()
                    If selected.ContainsKey("VendorName") Then Txt_MachineName.Text = selected("VendorName").ToString()
                End If
                '_BookCode = txtBookCode.Text
                'SendKeys.Send("{TAB}")

                sqL = "SELECT * FROM vch_no WHERE STATEMASTER='" & Txt_MachineName.Text & "' and Group_master_finance='VENDOR MASTER' "
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    txtAlter_code.Text = DefaltSoftTable.Rows(0).Item("SCHEDULE_ID").ToString
                Else
                    MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Call Ctrl_Visible_False(Me.Controls)
                    Exit Sub
                End If

                ALTER_FORM(txtAlter_code.Text)

                If _FORMMODE = "DELETE" Then
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Delete ?") = MsgBoxResult.Yes Then
                        Delete_Record()
                        MsgBox("Records Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    End If
                End If

                Txt_Brand.Focus()
            End If
        End If

        'e.Handled = True
    End Sub
#End Region
End Class