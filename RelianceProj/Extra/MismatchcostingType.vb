Imports System.Data.SqlClient
Imports System.Text

Public Class MismatchcostingType
    Private obj_Party_Selection As New Multi_Selection_Master
#Region "VARIABLE DECLARATION"
    Private _ColNames As New StringBuilder
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = "BEHAVIOUR"
    Private _TblName As String = "Query1"
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
        GetName = obj_Party_Selection.Master_GetNameOtherThisEntry(_TblName, _KeyFieldName, _KeyFieldValue, "RCPT_ISSUE", Txtsundaryname.Text)
    End Function
    Private Function getAlter_Form_Query(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT * FROM " & _TblName & " WHERE 1=1 AND BEHAVIOUR='" & strKeyID & "' and Y_JOB_WORKER_STK_OWN = 'Mismatch Cost Setting'")
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
            .Append("BEHAVIOUR,")
            .Append("BookName,")
            .Append("RCPT_ISSUE,")
            .Append("NATURE,")
            .Append("Y_OWN_STK,")
            .Append("Y_OWN_STK_FLD,")
            .Append("Y_JOB_WORKER_STK_OWN,")
            .Append("BOOKORDER,")
            .Append("Y_JOB_PARTY_STK_FLD")
        End With
    End Sub
#End Region

#Region "FORM EVENTS"
    Private Sub Transport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InsertCostSheetSetting()
        Me.KeyPreview = True
        _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
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
        'Call Command_Button_Visibility("LOAD")
        Ctrl_Visible_False(Me.Controls)
        _FrmLoad = False
        UC_Buttons1._ButtonEnableDisable("LOAD")

        AttachButtonFocusEvents(Me)
    End Sub

    Public Sub InsertCostSheetSetting()
        Try
            Using con As New SqlConnection(Module2.SqlServerConnectionString)
                con.Open()
                Dim _strQuery As New StringBuilder()

                With _strQuery
                    .AppendLine("IF NOT EXISTS (")
                    .AppendLine(" SELECT 1 FROM " & _TblName & "")
                    .AppendLine(" WHERE BEHAVIOUR = @BEHAVIOUR")
                    .AppendLine(" AND BookName = @BookName")
                    .AppendLine(" AND Y_JOB_WORKER_STK_OWN = 'Mismatch Cost Setting'")
                    .AppendLine(")")
                    .AppendLine("INSERT INTO " & _TblName & "")
                    .AppendLine("(BEHAVIOUR, BookName, RCPT_ISSUE, NATURE,")
                    .AppendLine(" Y_OWN_STK, Y_OWN_STK_FLD,")
                    .AppendLine(" Y_JOB_WORKER_STK_OWN, BOOKORDER, Y_JOB_PARTY_STK_FLD)")
                    .AppendLine("VALUES")
                    .AppendLine("(@BEHAVIOUR, @BookName, @RCPT_ISSUE, @NATURE,")
                    .AppendLine(" @Y_OWN_STK, 0.00, 'Mismatch Cost Setting', 0, 'YES')")
                End With

                Dim sql As String = _strQuery.ToString()
                Dim data As New List(Of Object()) From {
                                        New Object() {"0000-000000002", "OVERHEAD", "OVERHEAD", "1.00", "0.00"},
                                        New Object() {"0000-000000003", "OVERHEAD", "LABOUR", "1.00", "0.00"},
                                        New Object() {"0000-000000004", "OVERHEAD", "LESS DISCOUNT", "1.00", "0.00"},
                                        New Object() {"0000-000000005", "OVERHEAD", "LESS COMMISSION", "1.00", "0.00"},
                                        New Object() {"0000-000000006", "OVERHEAD", "SELLING RATE %", "1.00", "0.00"},
                                        New Object() {"0000-000000007", "OVERHEAD", "NETT PROFIT IN PCS", "1.00", "0.00"},
                    New Object() {"0000-000000008", "OVERHEAD", "NETT PROFIT IN", "1.00", "0.00"}
                                    }
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.Add("@BEHAVIOUR", SqlDbType.VarChar)
                    cmd.Parameters.Add("@BookName", SqlDbType.VarChar)
                    cmd.Parameters.Add("@RCPT_ISSUE", SqlDbType.VarChar)
                    cmd.Parameters.Add("@NATURE", SqlDbType.VarChar)
                    cmd.Parameters.Add("@Y_OWN_STK", SqlDbType.VarChar)

                    For Each row In data
                        cmd.Parameters("@BEHAVIOUR").Value = row(0)
                        cmd.Parameters("@BookName").Value = row(1)
                        cmd.Parameters("@RCPT_ISSUE").Value = row(2)
                        cmd.Parameters("@NATURE").Value = row(3)
                        cmd.Parameters("@Y_OWN_STK").Value = row(4)

                        cmd.ExecuteNonQuery()
                    Next
                End Using
                con.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnPrint", "BtnReports", "BtnBack", "BtnNext")
    End Sub
    Private Sub Transport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True
            Me.Close()
            If _FORMMODE = "" Then
                'If Label2.Text = "Frm_Grader" Then
                Me.Close()
                Me.Dispose(True)
            End If
        End If
    End Sub

#End Region

#Region "Button Click"
    Private Sub UC_Buttons1_AddClick() Handles UC_Buttons1.AddClick
        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtSundaryType.Text = "OVERHEAD"
        txtAddless.Text = "0.00"
        txtCalcby.Text = "0.00"
        txtdefaultper.Text = "0.00"
        TxtOrderno.Text = "0"
        TxtStatus.Text = "YES"
        txtSundaryType.Focus()
        txtSundaryType.Select()
    End Sub
    Private Sub UC_Buttons1_EditClick() Handles UC_Buttons1.EditClick
        _FORMMODE = "EDIT"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtAlter_code.Text = ""
        txtSundaryType.Text = "OVERHEAD"
        txtSundaryType.Visible = True
        txtAddless.Text = "0.00"
        txtCalcby.Text = "0.00"
        txtdefaultper.Text = "0.00"
        TxtOrderno.Text = "0"
        TxtStatus.Text = "YES"
        txtSundaryType.Focus()
        txtSundaryType.Select()
    End Sub
    Private Sub UC_Buttons1_DeleteClick() Handles UC_Buttons1.DeleteClick
        _FORMMODE = "DELETE"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        ObjCls_General.Blank_Object(Me)
        txtAlter_code.Text = ""
        txtSundaryType.Text = "OVERHEAD"
        txtSundaryType.Visible = True

        txtAddless.Text = "0.00"
        txtCalcby.Text = "0.00"
        txtdefaultper.Text = "0.00"
        TxtOrderno.Text = "0"
        TxtStatus.Text = "YES"
        txtSundaryType.Focus()
        txtSundaryType.Select()

    End Sub
    Private Sub UC_Buttons1_BackClick() Handles UC_Buttons1.BackClick
        _FrmLoad = False
        'If _FORMMODE = "EDIT" AndAlso Val(txtEntryNo.Text) > 1 Then
        '    txtEntryNo.Text = Val(txtEntryNo.Text) - 1
        '    Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
        '    Call Validate_Entry_No(Book_Vno, _OfferTableName)
        'End If
    End Sub

    Private Sub UC_Buttons1_NextClick() Handles UC_Buttons1.NextClick
        _FrmLoad = False

    End Sub

    Private Sub UC_Buttons1_SaveClick() Handles UC_Buttons1.SaveClick
        _FrmLoad = False
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
        End If
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
    End Sub

    Private Sub UC_Buttons1_CloseClick() Handles UC_Buttons1.CloseClick
        If _FORMMODE = "" Then


            If Label2.Text = "Frm_Grader" Then
                Me.Close()
                Me.Dispose(True)

            Else

            End If
        Else
            If _FORMMODE = "VIEW" Then
                _FORMMODE = ""
                PnlGrdView.Visible = False
                grdView.Visible = False
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
                Me.Text = old_Me_text
            Else
                _FORMMODE = ""
                ObjCls_General.Blank_Object(Me)
                _KeyFieldValue = 0
                Call Ctrl_Visible_False(Me.Controls)
                UC_Buttons1._ButtonEnableDisable("LOAD")
                UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")
            End If
        End If
        Me.Close()
        Me.Dispose(True)

    End Sub

    Private Sub UC_Buttons1_ViewClick() Handles UC_Buttons1.ViewClick
        _FORMMODE = "VIEW"
        View_Record()
    End Sub

    Private Sub UC_Buttons1_PrintClick() Handles UC_Buttons1.PrintClick
        _FORMMODE = "PRINT"

    End Sub

    Private Sub UC_Buttons1_ReportsClick() Handles UC_Buttons1.ReportsClick
        _FORMMODE = "REPORTS"

    End Sub

#End Region




#Region "VIEW RECORD"
    Private Sub View_Record()
        Dim View_Filter_Condition = " AND A.Y_JOB_WORKER_STK_OWN='Mismatch Cost Setting' "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.BEHAVIOUR As [SNo.]")
            .Append(" ,A.BookName as [Sundary Type]")
            .Append(" ,A.RCPT_ISSUE as [Sundary Name] ")
            .Append(" ,A.NATURE as [Add/Less]")
            .Append(" ,A.Y_OWN_STK as [Clac. By]")
            .Append(" ,A.Y_OWN_STK_FLD as [Percentage]")
            .Append(" FROM " & _TblName & " AS A ")
            .Append(" WHERE 1=1")

            .Append(View_Filter_Condition)

        End With
        strQuery = _strQuery.ToString
        FillGrid(grdView, strQuery)

        For i As Int16 = 1 To grdView.Rows - 1
            grdView.Cell(i, 1).Text = i
        Next

        grdView.Column(0).Visible = False
        grdView.Column(1).Visible = True

        grdView.Column(1).Width = 30
        grdView.Column(2).Width = 120
        grdView.Column(6).Width = 90
        grdView.Column(0).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(1).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(2).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(3).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(4).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(5).Alignment = FlexCell.AlignmentEnum.LeftCenter
        grdView.Column(6).Alignment = FlexCell.AlignmentEnum.RightCenter
        grdView.ExtendLastCol = False

        Me.Text = old_Me_text + Space(30) + " List of All Record"
        grdView.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        grdView.ScrollBars = FlexCell.ScrollBarsEnum.Both
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
            'Call Command_Button_Visibility("LOAD")
            'Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Me.Text = old_Me_text
            _FORMMODE = ""
        End If
    End Sub
#End Region

#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        strQuery = GetName()
        If Txtsundaryname.Text = "" Then
            MsgBox("Invalid Sundary Name")
            txtSundaryType.Focus()
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
        tblFormValues.Rows(0)("Y_JOB_WORKER_STK_OWN") = "Mismatch Cost Setting"
        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        SaveQuery = getSaveQuery()
        sqL = SaveQuery
        sql_Data_Save_Delete_Update()
        MsgBox("Records Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
    End Sub

#End Region

#Region "ALTER FORM METHOD"
    Private Sub ALTER_FORM(ByVal strKeyID As String)
        Dim tblTmp As New DataTable
        '_FORMMODE = "EDIT"
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
        'sql_Data_Save_Delete_Update()
        ObjCls_General.Blank_Object(Me)
        _KeyFieldValue = 0
    End Sub
#End Region

#Region "SELECTION LIST CODE"
    Private Sub Own_Selection_List()

        Dim _lastkEyFieldValue As String = ""
        txtAlter_code.Text = ""
        txtAlter_Name.Text = ""
        obj_Party_Selection.SINGLE_MixMatch_SELECTION(txtSundaryType.Text)
        txtAlter_Name.Text = MULTY_SELECTION_COLOUM_1_DATA
        txtAlter_code.Text = MULTY_SELECTION_COLOUM_3_DATA
        _lastkEyFieldValue = _KeyFieldValue
        _KeyFieldValue = txtAlter_code.Text
        txtSundaryType.Text = MULTY_SELECTION_COLOUM_1_DATA
    End Sub
#End Region

#Region "NAME VALIDATE"
    Private Sub Txtsundaryname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsundaryname.Validated
        If Trim(Txtsundaryname.Text) <> "" Then
            strQuery = GetName()
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                MsgBox("Sundary Name Already Exist")
                Txtsundaryname.Text = ""
                Txtsundaryname.Focus()

            End If
        Else
            If _FORMMODE = "ADD" Or _FORMMODE = "EDIT" Then
                Check_TextBox_Cannnot_Empty(sender, _FrmLoad)
            End If

        End If
    End Sub
#End Region

#Region "SUB NEW"
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub txtSundaryType_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSundaryType.KeyDown
        If _FORMMODE = "ADD" Then

        Else
            If e.KeyCode = Keys.Enter Then
                If txtSundaryType.Text <> "" Then
                    Own_Selection_List()
                    If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                        txtSundaryType.Text = MULTY_SELECTION_COLOUM_1_DATA
                        ALTER_FORM(txtAlter_code.Text)
                        SendKeys.Send("{TAB}")
                        If _FORMMODE = "DELETE" Then
                            If txtAlter_code.Text <> "" Then
                                If (Mid(_KeyFieldValue, 1, 4)) = "0000" Then
                                    MsgBox("It's A Default Record, Can't Delete", MsgBoxStyle.Critical, "Soft-Tex PRO")
                                Else

                                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Delete ?") = MsgBoxResult.Yes Then
                                        Call Delete_Record()
                                    Else
                                        ObjCls_General.Blank_Object(Me)
                                        Ctrl_Visible_False(Me.Controls)
                                        UC_Buttons1._ButtonEnableDisable("LOAD")

                                        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
                                    End If
                                End If
                            End If
                        End If
                    Else
                        _FORMMODE = ""
                    End If
                End If

            End If
        End If
    End Sub

#End Region
End Class