Imports System.Text
Imports DevExpress.XtraBars.Customization

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
    Private WithEvents txtAlter_code As New TextBox
#End Region

    Private Sub MachineMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        txtBookCode.Text = "MMSS-000000001"
        _BookTrType = "MMSS1"
        _BookCode = txtBookCode.Text


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
        'strQuery = " SELECT  TOP 1 SUBSTRING(" & _KeyFieldName & ",6,10)  FROM " & _TblName & " WHERE LEFT(" & _KeyFieldName & ",4)='" & _SELECTEDCOMPANYCODE & "'" & " AND SHORTNAME='NEW QUALITY PLANNING'  ORDER BY " & _KeyFieldName & " DESC "
        strQuery = " SELECT  TOP 1 SUBSTRING(" & _KeyFieldName & ",6,10)  FROM " & _TblName & " WHERE LEFT(" & _KeyFieldName & ",4)<>'" & _SELECTEDCOMPANYCODE & "'" & " AND Group_master_finance='FIXED ASSETS MASTER'  ORDER BY " & _KeyFieldName & " DESC "
        Return strQuery.ToString
    End Function


    Public Function GetMaxCode() As String
        GetMaxCode = Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append("Schedule_id,") ' enqcode
            .Append("Group_master_finance,")
            .Append("Main_account_master,")
            .Append("STATEMASTER,")
            .Append("CITYMASTER,")
            '.Append("FORMAT(CONVERT(datetime, TRANSPORT_MASTER, 103), 'dd/MM/yyyy') As EntryDate,") 'Entry Date
            '.Append("FORMAT(CONVERT(datetime,MSTCUTMASTER, 103), 'dd/MM/yyyy') As ModifyDate,")   ' Modify Date
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
            .Append("MSTFABRIC_ITEM_CATEGORY")
            '.Append(" A.*  ")
            '.Append(" ,B.ITENNAME as ITEM")
            '.Append(" ,C.ACCOUNTNAME")
            '.Append(" ,D.Design_Name")
            '.Append(" ,E.SHADE")
            '.Append(" ,FORMAT(CONVERT(datetime, A.HSNCODE, 103), 'dd/MM/yyyy') AS E_EntryDate")
            '.Append(" ,FORMAT(CONVERT(datetime, A.CONVERFAC, 103), 'dd/MM/yyyy') AS E_Estmatedate")
            .Append("  FROM Vch_no")
            '.Append("  FROM MstItemBatchWise AS A ")
            '.Append("  LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID")
            '.Append("  LEFT JOIN MstMasterAccount AS C  ON A.TAXSLAB=C.ACCOUNTCODE")
            '.Append("  LEFT JOIN Mst_Fabric_Design AS D  ON A.COMPNAME=D.Design_code")
            '.Append("  LEFT JOIN Mst_Fabric_Shade AS E  ON A.PRIMERUNIT=E.ID")
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
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "'" & _KeyFieldValue & "'")
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
            .Append("TRANSPORT_MASTER,") 'Entry Date
            .Append("MSTCUTMASTER,")   ' Modify Date
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
            .Append("MSTFABRIC_ITEM_CATEGORY")
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
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()

    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        _FORMMODE = "EDIT"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        _FORMMODE = "DELETE"
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)

        Txt_MachineName.Visible = True
        Txt_MachineName.Focus()
        Txt_MachineName.Select()
    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then

            _FORMMODE = "EDIT"
            txtAlter_code.Text = ""
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)

            'Call Command_Button_Visibility("BTNEDIT")
            Call Ctrl_Visible_True(Me.Controls)


            sqL = GetMaxCode()
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0))
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If



            txtEntryNo.Focus()
            txtEntryNo.Select()
        End If

    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False
        If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) >= 1 Then
            txtEntryNo.Text = Val(txtEntryNo.Text) + 1
            Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            'Call Validate_Entry_No(Book_Vno, _ChallanTableName)
        End If
    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        _FrmLoad = False
        '_FORMMODE = "SAVE"
        SaveRecord()
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

        'txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        'Txt_MachineName.Visible = True
        'Txt_MachineName.Focus()
        'Txt_MachineName.Select()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"
        'ComparisonPrint.Show()
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
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
                txtEntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
            Else
                LASTCODE = "1"
                txtEntryNo.Text = "1"
            End If
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
            tblFormValues.Rows(0)("TRANSPORT_MASTER") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        If _FORMMODE = "EDIT" Then
            tblFormValues.Rows(0)("MSTCUTMASTER") = CDate(Date.Now).ToString("dd/MM/yyyy HH:mm:ss")
        End If
        tblFormValues.Rows(0)("MSTFABRICMASTER") = TxtBoolvalue.Text
        tblFormValues.Rows(0)("MSTFABRICHEAD") = txtdepreciation.Text
        tblFormValues.Rows(0)("MSTFABRICGROUP") = Txtspaceoccup.Text
        tblFormValues.Rows(0)("MSTYARNMASTER") = TxtL.Text
        tblFormValues.Rows(0)("MSTITEMGROUP") = TxtW.Text
        tblFormValues.Rows(0)("MSTITEMCOMPANY") = TxtCategory.Text
        tblFormValues.Rows(0)("MSTITEMMASTER") = TxtUOm.Text
        tblFormValues.Rows(0)("MST_BARCODE") = TxtHsn.Text
        tblFormValues.Rows(0)("MST_BATCHID") = TxtTaxRate.Text
        tblFormValues.Rows(0)("MSTINSURANCE") = TxtDepartMent.Text
        tblFormValues.Rows(0)("MSTFABRIC_ITEM_CATEGORY") = TxtAttachment.Text


        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        'ObjCls_General.MAKEQUERYFROMDATATABLE("ADD", tblFormValues, FieldNameAndValues)
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
        'Command_Button_Visibility("LOAD")
        'Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
        'End If
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
#End Region
End Class