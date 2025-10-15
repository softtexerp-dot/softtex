Imports System.Text

Friend Class NewQualityPlanEntry

    Private obj_Party_Selection As New Multi_Selection_Master

#Region "VARIABLE DECLARATION"
    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "ITEMNAME"
    Private _TblName As String = "MstItemBatchWise"
    Private _FrmLoad As Boolean = False
    Private WithEvents txtAlter_code As New TextBox
    Private WithEvents txtAlter_Name As New TextBox
    Private WithEvents txt_PartyCode As New TextBox
    Private WithEvents txt_ItemCode As New TextBox
    Private WithEvents txt_DesignCode As New TextBox
    Private WithEvents txt_ShadeCode As New TextBox
    Private DispList As Boolean = True
    Private Is_Call_By_Another As Boolean = False

    Private Last_Focused_Btn As String = ""
    Dim old_Me_text As String = ""
#End Region

#Region "QUERY SECTION"

    Public Function Master_GetMaxCode(ByVal _KeyFieldName As String, ByVal _TblName As String, ByVal _SELECTEDCOMPANYCODE As String) As String
        strQuery = " SELECT  TOP 1 SUBSTRING(" & _KeyFieldName & ",6,10)  FROM " & _TblName & " WHERE LEFT(" & _KeyFieldName & ",4)='" & _SELECTEDCOMPANYCODE & "'" & " AND SHORTNAME='NEW QUALITY PLANNING'  ORDER BY " & _KeyFieldName & " DESC "
        Return strQuery.ToString
    End Function


    Public Function GetMaxCode() As String
        GetMaxCode = Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function

    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append(" A.*  ")
            .Append(" ,B.ITENNAME as ITEM")
            .Append(" ,C.ACCOUNTNAME")
            .Append(" ,D.Design_Name")
            .Append(" ,E.SHADE")
            .Append(" ,FORMAT(CONVERT(datetime, A.HSNCODE, 103), 'dd/MM/yyyy') AS E_EntryDate")
            .Append(" ,FORMAT(CONVERT(datetime, A.CONVERFAC, 103), 'dd/MM/yyyy') AS E_Estmatedate")
            .Append("  FROM MstItemBatchWise AS A ")
            .Append("  LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID")
            .Append("  LEFT JOIN MstMasterAccount AS C  ON A.TAXSLAB=C.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS D  ON A.COMPNAME=D.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS E  ON A.PRIMERUNIT=E.ID")
            .Append("  WHERE 1=1")
            .Append("  AND A.SHORTNAME='NEW QUALITY PLANNING'")
            .Append("  AND A.ITEMNAME='" & strKeyID & "'")
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
            .Append("ITEMNAME,") ' enqcode
            .Append("ID,")
            .Append("HSNCODE,")
            .Append("TAXSLAB,")
            .Append("GROUPNAME,")
            .Append("COMPNAME,")
            .Append("PRIMERUNIT,")
            .Append("ALTUNIT,")
            .Append("CONVERFAC,")
            .Append("BATCHNO,")
            .Append("PURCHRATE,")
            .Append("SALERATE,")
            .Append("SHORTNAME,")
            .Append("MINSALE,")
            .Append("MRP")
        End With
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub Transport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If LEDGER_ENTER_DISPLAY_FROM = "_CallOther" Then
        '    Dim x As Integer = 0
        '    Dim y As Integer
        '    y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        '    Me.Location = New Point(x, y)
        'Else
        '    Me.Location = New Point(0, 0)
        'End If


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
        Call Command_Button_Visibility("LOAD")
        Ctrl_Visible_False(Me.Controls)
        btnAdd.Focus()
        btnAdd.Select()
        _FrmLoad = False



    End Sub

    Private Sub _closeMenu()

        If LEDGER_ENTER_DISPLAY_FROM = "_CallOther" Then
            Me.Close()
            Me.Dispose(True)
            LEDGER_ENTER_DISPLAY_FROM = ""
        Else
            Me.Close()
            Me.Dispose(True)
        End If

    End Sub
    Private Sub Transport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then

            If PNL_View.Visible = True Then
                PNL_View.Visible = False
                btnView.Enabled = True
                btnView.Focus()
                Exit Sub
            End If


            _FrmLoad = True
            If _FORMMODE = "" Then
                _closeMenu()
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
            _closeMenu()
        Else
            If _FORMMODE = "VIEW" Then
                _FORMMODE = ""
                PNL_View.Visible = False
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
        Txt_Clear.Text = "NO"
        Txt_PlanType.Text = "OWN"
        Txt_Moredetail.Text = "NO"

        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_EntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
        Else
            Txt_EntryNo.Text = "1"
        End If


        txtEntryDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Txt_EstmDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        Txt_EntryNo.Focus()
        Txt_EntryNo.Select()
    End Sub
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Last_Focused_Btn = "MODIFY"
        _FORMMODE = "EDIT"
        txtAlter_code.Text = ""
        Txt_Moredetail.Text = "NO"

        Call Command_Button_Visibility("BTNEDIT")
        Call Ctrl_Visible_True(Me.Controls)


        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_EntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0))
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If



        Txt_EntryNo.Focus()
        Txt_EntryNo.Select()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        _FrmLoad = False
        Last_Focused_Btn = "DELETE"
        _FORMMODE = "DELETE"
        txtAlter_code.Text = ""
        Call Command_Button_Visibility("BTNDELETE")
        Call Ctrl_Visible_True(Me.Controls)


        sqL = GetMaxCode()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_EntryNo.Text = Val(DefaltSoftTable.Rows(0).Item(0))
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        sqL = "SELECT*FROM MstItemBatchWise WHERE ID='" & Txt_EntryNo.Text & "'"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txtAlter_code.Text = DefaltSoftTable.Rows(0).Item("ITEMNAME").ToString
        End If

        Txt_EntryNo.Focus()
        Txt_EntryNo.Select()
    End Sub


    Private Sub Txt_EntryNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_EntryNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If _FORMMODE = "DELETE" Or _FORMMODE = "EDIT" Then

                sqL = "SELECT*FROM MstItemBatchWise WHERE ID='" & Txt_EntryNo.Text & "'"
                sql_connect_slect()
                If DefaltSoftTable.Rows.Count > 0 Then
                    txtAlter_code.Text = DefaltSoftTable.Rows(0).Item("ITEMNAME").ToString
                End If

                ALTER_FORM(txtAlter_code.Text)

                If _FORMMODE = "DELETE" Then
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Delete_Record()
                    End If
                End If


            End If
        End If
    End Sub
#End Region

#Region "VIEW RECORD"
    Private Sub View_Record()
        Try


            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append(" a.ID as EntryNo")
                .Append(" ,FORMAT(CONVERT(datetime, A.HSNCODE, 103), 'dd/MM/yyyy') AS EntryDate")
                .Append(" ,C.ACCOUNTNAME as PartyName")
                .Append(" ,F.cityname as [City Name]")
                .Append(" ,C.GSTIN as [GSTIN]")
                .Append(" ,C.MOBILE as [Mobile]")
                .Append(" ,C.[ADDRESS1] as [Address 1]")
                .Append(" ,C.[ADDRESS2] as [Address 2]")
                .Append(" ,C.[ADDRESS3] as  [Address 3]")
                .Append(" ,G.ACCOUNTNAME as AgentName ")
                .Append(" ,B.ITENNAME as ItemName")
                .Append(" ,D.Design_Name as Design")
                .Append(" ,E.SHADE as Shade")
                .Append(" ,a.ALTUNIT as Qty")
                .Append(" ,FORMAT(CONVERT(datetime, A.CONVERFAC, 103), 'dd/MM/yyyy') AS EstimatedDelivery ")
                .Append(" ,a.BATCHNO as Remark1")
                .Append(" ,a.PURCHRATE as Remark2")
                .Append(" ,a.SALERATE as Remark3")
                .Append(" ,a.MRP as Clear")

                .Append("  FROM MstItemBatchWise AS A ")
                .Append("  LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID")
                .Append("  LEFT JOIN MstMasterAccount AS C  ON A.TAXSLAB=C.ACCOUNTCODE")
                .Append("  LEFT JOIN Mst_Fabric_Design AS D  ON A.COMPNAME=D.Design_code")
                .Append("  LEFT JOIN Mst_Fabric_Shade AS E  ON A.PRIMERUNIT=E.ID")
                .Append("  LEFT JOIN MstCity  AS F ON C.citycode=F.citycode ")
                .Append("  LEFT JOIN MstMasterAccount  AS G ON C.AGENTCODE=G.ACCOUNTCODE ")
                .Append("  WHERE 1=1")
                .Append("  AND A.SHORTNAME='NEW QUALITY PLANNING'")
                .Append("  ORDER BY a.ID ")
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
#End Region


#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If Txt_PartyName.Text = "" Then
            MsgBox("Enter Party Name")
            Txt_PartyName.Focus()
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

        If Txt_Qty.Text.Trim = "" Then Txt_Qty.Text = "0.00"

        Generate_Date_For_DataBase(txtEntryDate)
        Generate_Date_For_DataBase(Txt_EstmDate)



        If _FORMMODE = "ADD" Then
            ' *** Get Last Code According to Company Selected ***
            sqL = GetMaxCode()
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
        tblFormValues.Rows(0)("TAXSLAB") = txt_PartyCode.Text
        tblFormValues.Rows(0)("GROUPNAME") = txt_ItemCode.Text
        tblFormValues.Rows(0)("COMPNAME") = txt_DesignCode.Text
        tblFormValues.Rows(0)("PRIMERUNIT") = txt_ShadeCode.Text
        tblFormValues.Rows(0)("SHORTNAME") = "NEW QUALITY PLANNING"

        'tblFormValues.Rows(0)("HSNCODE") = txtEntryDate.Text
        'tblFormValues.Rows(0)("CONVERFAC") = Txt_EstmDate.Text


        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        'ObjCls_General.MAKEQUERYFROMDATATABLE("ADD", tblFormValues, FieldNameAndValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(Me._FORMMODE, Me.tblFormValues, Me.FieldNameAndValues, "", "", "")

        sqL = getSaveQuery()

        sql_Data_Save_Delete_Update()
        MsgBox("Records Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

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
        strQuery = getAlter_Form_Query(strKeyID)
        sqL = strQuery
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        tblFormValues.Rows.Clear()
        For Each dr As DataRow In tblTmp.Rows
            tblFormValues.ImportRow(dr)
        Next
        'ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblFormValues)
        If tblTmp.Rows.Count > 0 Then
            _KeyFieldValue = tblTmp.Rows(0).Item("ITEMNAME").ToString
            Txt_EntryNo.Text = tblTmp.Rows(0).Item("ID").ToString
            txtEntryDate.Text = tblTmp.Rows(0).Item("E_EntryDate").ToString
            Txt_PartyName.Text = tblTmp.Rows(0).Item("ACCOUNTNAME").ToString
            Txt_ItemName.Text = tblTmp.Rows(0).Item("ITEM").ToString
            Txt_DesignName.Text = tblTmp.Rows(0).Item("Design_Name").ToString
            Txt_ShadeName.Text = tblTmp.Rows(0).Item("SHADE").ToString
            Txt_Qty.Text = tblTmp.Rows(0).Item("ALTUNIT").ToString
            Txt_EstmDate.Text = tblTmp.Rows(0).Item("E_Estmatedate").ToString
            Txt_Remark_1.Text = tblTmp.Rows(0).Item("BATCHNO").ToString
            Txt_Remark_2.Text = tblTmp.Rows(0).Item("PURCHRATE").ToString
            Txt_Remark_3.Text = tblTmp.Rows(0).Item("SALERATE").ToString
            Txt_Clear.Text = tblTmp.Rows(0).Item("MRP").ToString
            Txt_PlanType.Text = tblTmp.Rows(0).Item("MINSALE").ToString


            txt_PartyCode.Text = tblTmp.Rows(0).Item("TAXSLAB").ToString
            txt_ItemCode.Text = tblTmp.Rows(0).Item("GROUPNAME").ToString
            txt_DesignCode.Text = tblTmp.Rows(0).Item("COMPNAME").ToString
            txt_ShadeCode.Text = tblTmp.Rows(0).Item("PRIMERUNIT").ToString
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
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0


        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
        Command_Button_Visibility("LOAD")
        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)


    End Sub
#End Region


#Region "SUB NEW"
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Txt_PartyName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PartyName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = Txt_PartyName.Text
            obj_Party_Selection.Invoice_Party_Selection()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_PartyName.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_PartyCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ItemName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = Txt_ItemName.Text
            obj_Party_Selection.SINGLE_ITEM_SELECTION()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_ItemName.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_ItemCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_DesignName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_DesignName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = Txt_DesignName.Text
            obj_Party_Selection.SINGLE_DESIGN_SELECTION(" And A.Item_Code ='" & txt_ItemCode.Text & "'")
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_DesignName.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_DesignCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Txt_ShadeName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ShadeName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = Txt_ShadeName.Text
            Dim _itemcode = txt_ItemCode.Text
            obj_Party_Selection.Single_List_ItemWise_shade_Selection(_itemcode, "")

            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_ShadeName.Text = MULTY_SELECTION_COLOUM_1_DATA
                txt_ShadeCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            End If
            SendKeys.Send("{TAB}")
        End If
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

    Private Sub Txt_Moredetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Moredetail.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_Moredetail.Text = "NO" Then
                btnSave.Focus()
                btnSave.Select()
            Else
                txtEntryDate.Focus()
                txtEntryDate.Select()
            End If

        End If
    End Sub
End Class