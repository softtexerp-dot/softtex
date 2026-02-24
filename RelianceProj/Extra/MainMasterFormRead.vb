Imports System.Text
Imports CrystalDecisions.ReportAppServer.DataDefModel
Imports DevExpress.DataAccess.Sql
Imports DevExpress.Utils.Gesture
Imports DevExpress.Utils.VisualEffects
Imports DevExpress.XtraBars.Customization
Imports DevExpress.XtraEditors.TextEditController.Win32
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraRichEdit.Model
Imports FlexCell
Public Class MainMasterFormRead
    Private _DatabaseTableName = "FormControl"
    Dim _ActivatedColName As String = ""

    Dim _MainColumTbl As New DataTable
    Dim isDragging As Boolean = False
    Dim dragOffset As POINT
    Dim _TableName As String = ""
    Dim _TblName As String = ""
    Private _KeyFieldValue As String = ""
    Private _KeyFieldName As String = ""
    Private FieldNameAndValues(1) As String
    Private tblFormValues As New DataTable

    Private _FieldWidthSet As New StringBuilder
    Private _FieldHeader As New StringBuilder
    Private _FieldHeaderAlignment As New StringBuilder
    Private _FieldAlignMent As New StringBuilder
    Private _FieldNotVisibile As New StringBuilder
    Private _FieldLocked As New StringBuilder


    Private _FieldMasking As New StringBuilder

    Private _FieldUsemaster As New StringBuilder
    Private _Fieldmasterlist As New StringBuilder

    Private _FieldNotRequiredForSave As New StringBuilder
    Private _RecordsKeyFieldName As String = ""
    Private _ExtraFieldOthers As New StringBuilder
    Private _ExtraField_Values_Others As New StringBuilder
    Private _FieldDefaultValues As New StringBuilder

    Private isMoveMode As Boolean = False
    Private selectedCtrl As Control = Nothing
    Private _isLayoutApplied As Boolean = False

    'Private _UniqueDisplayValues As New List(Of String)
    'Private _UniqueCodeValues As New List(Of String)
    Private _UniqueValues As New List(Of Tuple(Of String, String, String))
    Dim FormId As String = "0"
    Dim Id As String = "0"

    Dim _OldFormListtbl As New DataTable
    Private _DefaultColOfGrid As Integer = 0


    'Dim Grid1 As New FlexCell.Grid()
    Private _DataTableGrid1 As New DataTable
    Private Grid1_Table_ColNames() As String
    Private _Grid1ColNames As New StringBuilder
    Private _Grid1LastColNo As Integer = 0
    Private _Grid1ColType As New StringBuilder


    Private _DataTableGrid2 As New DataTable
    Private _DataTableGrid3 As New DataTable
    Private _DataTableGrid4 As New DataTable
    Private _DataTableGrid5 As New DataTable
    Private _RowNo As Integer
    Private _ColNo As Integer

    'Dim Grid2 As New FlexCell.Grid()
    'Dim Grid3 As New FlexCell.Grid()
    'Dim Grid4 As New FlexCell.Grid()
    'Dim Grid5 As New FlexCell.Grid()

    Private UC_Buttons1 As UC_Buttons
    Private _FORMMODE As String = ""
    Private _FrmLoad As Boolean = True
    Private Change_Grid_Data As Boolean = True
    Dim txtEntryno As String = ""
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
            txtFormName.Focus()
            ' ADD mode ka logic yahan
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_EditClick()
        _FORMMODE = "EDIT"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "EDIT" Then
            txtFormName.Focus()
        End If
        Change_Grid_Data = True
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Function Alter_Form() As DataTable
        _FrmLoad = True
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query()
        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)
        If tblTmp.Rows.Count = 0 Then
            ObjCls_General.Blank_Object(Me)
            MsgBox("Record Not Found")
        End If
        _FrmLoad = False
        Return tblTmp
    End Function

    Private Sub UC_Buttons1_DeleteClick()
        _FrmLoad = True
        _FORMMODE = "DELETE"
        If MsgBox("Do You Want To Delete (Y/N)",
              MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2,
              "Delete ?") = MsgBoxResult.Yes Then
            'Call Delete_Entry()

        End If

        ObjCls_General.Blank_Object(Me)

        Ctrl_Visible_False(Me.Controls)

        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)

        _FrmLoad = False
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_BackClick()
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "EDIT" Then
            Dim LASTCODE As String = ""
            Dim formType As String = ""
            If _MainColumTbl.Rows.Count > 0 Then
                formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            End If
            If formType = "MASTER FORM" Then
                strQuery = GetMaxCode()
                sqL = strQuery
                sql_connect_slect()
                'If DefaltSoftTable.Rows.Count > 0 Then
                '    LASTCODE = Val(DefaltSoftTable.Rows(0).Item(0)) - 1
                'Else
                '    LASTCODE = "1"
                'End If
                'LASTCODE = _SELECTEDCOMPANYCODE & "-" & LASTCODE.PadLeft(9, "0")
                Dim num As Integer = 1

                If DefaltSoftTable.Rows.Count > 0 Then
                    num = Val(DefaltSoftTable.Rows(0).Item(0)) - 1
                End If
                LASTCODE = _SELECTEDCOMPANYCODE & "-" & num.ToString().PadLeft(9, "0")
                _KeyFieldValue = LASTCODE
                Dim tblTmp1 As DataTable = Alter_Form()
            End If
        End If
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_NextClick()
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "EDIT" Then
            Dim LASTCODE As String = ""
            Dim formType As String = ""
            If _MainColumTbl.Rows.Count > 0 Then
                formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
            End If
            If formType = "MASTER FORM" Then
                strQuery = GetMaxCode()
                sqL = strQuery
                sql_connect_slect()
                'If DefaltSoftTable.Rows.Count > 0 Then
                '    LASTCODE = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
                'Else
                '    LASTCODE = "1"
                'End If
                'LASTCODE = _SELECTEDCOMPANYCODE & "-" & LASTCODE.PadLeft(9, "0")
                Dim num As Integer = 1

                If DefaltSoftTable.Rows.Count > 0 Then
                    num = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
                End If
                LASTCODE = _SELECTEDCOMPANYCODE & "-" & num.ToString().PadLeft(9, "0")
                _KeyFieldValue = LASTCODE
                Dim tblTmp1 As DataTable = Alter_Form()
            End If
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_SaveClick()
        Dim EntryNo As String = ""
        _FrmLoad = False
        Dim Array_Opening(0, 4) As String
        Dim formType As String = ""
        Dim LASTCODE As String = ""
        SaveRecord()
        txtFormName.Focus()
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")

    End Sub
    Private Sub SaveRecord()
        Dim CompleteQuery As String = ""
        Dim SaveQuery As String = ""
        Dim strQuery As String = ""
        Dim LASTCODE As String = ""
        If _FORMMODE = "ADD" Then
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
        If _KeyFieldName <> "" Then
            tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
        End If
        'tblFormValues.Rows(0)("USEMASTERKEY") = "Y"
        ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        ' 🔹 Yaha UniqueValues add karna hai
        For Each item In _UniqueValues

            Dim ctrlName As String = item.Item1
            Dim offMasterCode As String = item.Item2
            Dim codeValue As String = item.Item3
            If tblFormValues.Columns.Contains(offMasterCode) Then
                tblFormValues.Rows(0)(offMasterCode) = codeValue
            End If
        Next
        'For Each item In _UniqueValues
        '    If tblFormValues.Columns.Contains(item.Item2) Then
        '        tblFormValues.Rows(0)(item.Item2) = item.Item3
        '    End If
        'Next
        ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        SaveQuery = getSaveQuery()
        sqL = SaveQuery
        sql_Data_Save_Delete_Update()
        MsgBox("Records Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        ObjCls_General.Blank_Object(Me)
        _FORMMODE = ""
        Ctrl_Visible_False(Me.Controls)
    End Sub
#Region "QUERY SECTION"
    Public Function GetMaxCode() As String
        GetMaxCode = obj_Party_Selection.Master_GetMaxCode(_KeyFieldName, _TblName, _SELECTEDCOMPANYCODE)
    End Function
    Private Function getAlter_Form_Query() As String
        Dim leftJoin As String = ""
        Dim joinHeader As String = ""


        For Each dr As DataRow In _MainColumTbl.Select("USEMASTER='YES' and MasterList > ''")
            Dim _DatabaseHeaderName As String = dr("Text").ToString()
            Dim _OppositCode As String = dr("OppMasterCode").ToString()
            Dim _SelectionMastrName As String = dr("MasterList").ToString()

            Dim res = GetAccountMaster(_DatabaseHeaderName, _OppositCode, _SelectionMastrName)

            leftJoin = res.LeftJoin
            joinHeader = res.JoinHeader
        Next

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.* ")
            .Append(joinHeader)
            .Append(" FROM " & _TblName & " as A")
            .Append(leftJoin)
            .Append(" WHERE 1=1 ")
            .Append(" And " & _KeyFieldName & " = " & "'" & _KeyFieldValue & "'")
            .Append(" ORDER BY ID DESC")
        End With
        Return _strQuery.ToString
    End Function
    'Private Function getAlter_Form_EntryQuery(ByVal EntryNo As String) As String
    '    Dim leftJoin As String = ""
    '    Dim joinHeader As String = ""


    '    For Each dr As DataRow In _MainColumTbl.Select("USEMASTER='YES' and MasterList > ''")
    '        Dim _DatabaseHeaderName As String = dr("Text").ToString()
    '        Dim _OppositCode As String = dr("OppMasterCode").ToString()
    '        Dim _SelectionMastrName As String = dr("MasterList").ToString()

    '        Dim res = GetAccountMaster(_DatabaseHeaderName, _OppositCode, _SelectionMastrName)

    '        leftJoin = res.LeftJoin
    '        joinHeader = res.JoinHeader
    '    Next



    '    _strQuery = New StringBuilder
    '    With _strQuery
    '        .Append(" SELECT A.*  ")
    '        .Append(joinHeader)
    '        .Append(" FROM " & _TblName & " as A ")
    '        .Append(leftJoin)
    '        .Append(" WHERE 1=1 ")
    '        .Append(" And EntryNo=" & EntryNo & "")
    '        .Append(" ORDER BY EntryNo DESC")
    '    End With
    '    Return _strQuery.ToString
    'End Function
    Private Function getSaveQuery()
        _strQuery = New StringBuilder
        If _FORMMODE = "ADD" Then
            _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
        ElseIf _FORMMODE = "EDIT" Then
            _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "= " & " '" & _KeyFieldValue & "'")
        End If
        getSaveQuery = _strQuery.ToString
    End Function
#End Region
    Private Sub UC_Buttons1_CloseClick()

        If _FORMMODE = "" Then
            Me.Close()
            Exit Sub
        End If

        Me.Close()
        Me.Dispose(True)

    End Sub
    Private Sub UC_Buttons1_ViewClick()
        _FORMMODE = "VIEW"
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
    Private Sub Delete_Entry()
        _FrmLoad = True
        _strQuery = New StringBuilder
        Dim LASTCODE As String = ""
        Dim formType As String = ""
        If _MainColumTbl.Rows.Count > 0 Then
            formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
        End If
        If formType = "MASTER FORM" Then
            strQuery = GetMaxCode()
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                LASTCODE = Val(DefaltSoftTable.Rows(0).Item(0))
            Else
                LASTCODE = "1"
            End If
            LASTCODE = _SELECTEDCOMPANYCODE & "-" & LASTCODE.PadLeft(9, "0")
            _KeyFieldValue = LASTCODE
            If _KeyFieldName <> "" Then
                tblFormValues.Rows(0)(_KeyFieldName) = LASTCODE
            End If
        End If
        Try

            strQuery = "DELETE FROM " & _TblName & " WHERE " & _KeyFieldName & " = " & "'" & _KeyFieldValue & "'"

            sqL = strQuery.ToString
            sql_connect_slect1()
            '-----------------------------------------------------------------------
            '_FORMMODE = "ADD"
            MsgBox("Entry Successfully Deleted")
        Catch ex As Exception

            MsgBox("Error While Delete Entry")
        Finally
            cmd = Nothing
        End Try

        _FrmLoad = False
    End Sub

#End Region
    Private Sub defineGridColName()
        _Grid1ColNames = New StringBuilder()
        _FieldHeader = New StringBuilder()
        _FieldHeaderAlignment = New StringBuilder()
        _FieldAlignMent = New StringBuilder()
        _FieldWidthSet = New StringBuilder()
        _FieldNotVisibile = New StringBuilder()
        _FieldLocked = New StringBuilder()
        _Grid1ColType = New StringBuilder()
        _FieldMasking = New StringBuilder()
        _FieldUsemaster = New StringBuilder()
        _Fieldmasterlist = New StringBuilder()
        _FieldNotRequiredForSave = New StringBuilder()
        If _MainColumTbl.Rows.Count > 0 Then

            For Each dr As DataRow In _MainColumTbl.Rows
                Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                Dim header As String = dr("Text").ToString().Trim()
                Dim alignVal As String = dr("TextAlign").ToString().Trim().ToUpper()
                If alignVal = "" Then alignVal = "L"
                If header = "" OrElse colName = "" Then
                    Continue For
                End If

                ' Grid Col Names
                If _Grid1ColNames.Length > 0 Then
                    _Grid1ColNames.Append(",")
                End If
                _Grid1ColNames.Append(colName)


                ' Field Header

                If header.Trim > "" Then
                    If _FieldHeader.Length > 0 Then
                        _FieldHeader.Append(",")
                    End If
                    _FieldHeader.Append(colName & ":" & header)
                End If
                ' Header Alignment
                If _FieldHeaderAlignment.Length > 0 Then
                    _FieldHeaderAlignment.Append(",")
                End If
                _FieldHeaderAlignment.Append(colName & ":" & alignVal)



                ' Field Alignment
                If _FieldAlignMent.Length > 0 Then
                    _FieldAlignMent.Append(",")
                End If
                _FieldAlignMent.Append(colName & ":" & alignVal)

                ' Width
                Dim widthVal As Int32 = dr("SizeWidth").ToString().Trim()
                If _FieldWidthSet.Length > 0 Then
                    _FieldWidthSet.Append(",")
                End If
                _FieldWidthSet.Append(colName & ":" & widthVal)

                ' Not Visible
                Dim visibleVal As String = dr("Visible").ToString().Trim().ToUpper()

                If header.Trim <> "" Then
                    If _FieldNotVisibile.Length > 0 Then
                        _FieldNotVisibile.Append(",")
                    End If
                    _FieldNotVisibile.Append(colName & ":" & visibleVal)
                End If

                ' Locked
                Dim lockVal As String = dr("ReadOnly").ToString().Trim().ToUpper()
                If lockVal = "" Then lockVal = "N"
                If _FieldLocked.Length > 0 Then
                    _FieldLocked.Append(",")
                End If
                _FieldLocked.Append(colName & ":" & lockVal)

                ' Col Type
                Dim colInputType As String = dr("InputType").ToString().Trim().ToUpper()
                Dim colType As String = dr("ColumnType").ToString().Trim().ToUpper()
                If colInputType = "Number" Then
                    colType = "N"
                    If _Grid1ColType.Length > 0 Then
                        _Grid1ColType.Append(",")
                    End If
                    _Grid1ColType.Append(colName & ":" & colType)
                End If

                ' Masking
                Dim prec As Integer = Val(dr("Masking"))
                If colInputType = "Number" Then
                    Dim maskVal As String = "NO-" & prec.ToString()
                    If _FieldMasking.Length > 0 Then
                        _FieldMasking.Append(",")
                    End If
                    _FieldMasking.Append(colName & ":" & maskVal)
                End If
                Dim notrequired As String = dr("SaveYN").ToString().Trim().ToUpper()
                If notrequired = "N" Then
                    If _FieldNotRequiredForSave.Length > 0 AndAlso Not _FieldNotRequiredForSave.ToString().EndsWith(",") Then
                        _FieldNotRequiredForSave.Append(",")
                    End If
                    _FieldNotRequiredForSave.Append(colName & ":" & notrequired)
                End If
                'default value set
                '_FieldDefaultValues = New StringBuilder
                'With _FieldDefaultValues
                '    .Append("Yarn_Rate:0,")
                '    .Append("pattern:0,")
                '    .Append("Avg_weight:0,")
                '    .Append("PROFIT_PER:0,")
                '    .Append("Yarn_Amount:0")
                '    .Append("VALUE_LOSS_PER_MTR:0")
                'End With
            Next
            Grid1_Table_ColNames = _Grid1ColNames.ToString.ToUpper.Split(",")
        End If
    End Sub
    Private Sub RemoveControlIfExists(ctrlName As String)

        Dim oldCtrl As Control = Me.Controls.Cast(Of Control)().FirstOrDefault(Function(c) c.Name = ctrlName)
        If oldCtrl IsNot Nothing Then
            Me.Controls.Remove(oldCtrl)
            oldCtrl.Dispose()
        End If
    End Sub

    Private Sub View_Record()
        Try



            Dim EntryNo As Integer = 1

            Dim _Grid1ColNames = New StringBuilder()

            Dim View_Filter_Condition = " AND  FormName='" & txtFormName.Text & "' "
            If txtFormName.Text <> "" Then
                If _MainColumTbl.Rows.Count > 0 Then
                    For Each dr As DataRow In _MainColumTbl.Select("CntrlId <> ''")

                        Dim Name As String = dr("CntrlName").ToString()
                        RemoveControlIfExists(Name)
                        RemoveControlIfExists("Lbl_" & Name)
                    Next
                End If
                _strQuery = New StringBuilder
                With _strQuery
                    .Append("Select * FROM " & _DatabaseTableName & " WHERE 1=1 ")
                    .Append(View_Filter_Condition)
                End With
                sqL = _strQuery.ToString
                sql_connect_slect1()
                _MainColumTbl = DefaltSoftTable.Copy
                Dim _UseMasterTabl As New DataTable
                _UseMasterTabl = _MainColumTbl.Clone
                For Each dr As DataRow In _MainColumTbl.Select("USEMASTER='YES'")
                    _UseMasterTabl.ImportRow(dr)
                Next
#Region "Label or text box control visible form view"
                Dim _CntlMasterTabl As New DataTable
                _CntlMasterTabl = _MainColumTbl.Clone
                Dim topPos As Integer
                'Dim topPos As Integer = 20
                Dim leftPos As Integer
                Dim height As Integer
                Dim width As Integer
                For Each dr As DataRow In _MainColumTbl.Select("CntrlId <> ''")
                    Dim _InputType As String = dr("INPUTTYPE").ToString().Trim()
                    Dim usemasterkey As String = dr("USEMASTERKEY").ToString
                    Dim colType As String = dr("ColumnType").ToString()
                    Dim HeaderName As String = dr("Text").ToString()
                    Dim Name As String = dr("CntrlName").ToString()
                    Dim Tabindex As Int64 = dr("Tabindex").ToString()
                    Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                    _TblName = dr("DataBaseTable").ToString()
                    'Dim formtype As String = ""
                    'formtype = dr("FormType").ToString().Trim()
                    'If formtype = "ENTRY FORM" Then
                    '    'If _FORMMODE = "EDIT" Then
                    '    '    EntryNo = _GetMaxEntryNo()
                    '    'End If
                    'Else

                    'End If




                    If usemasterkey = "Y" Then
                        _KeyFieldName = colName
                    End If
                    ' Grid Col Names
                    If _Grid1ColNames.Length > 0 Then
                        _Grid1ColNames.Append(",")
                    End If
                    _Grid1ColNames.Append(colName)
                    Dim Tag As String = dr("DataBaseColumn").ToString()
                    Dim oppMasterCode As String = dr("OppMasterCode").ToString()
                    Dim ctrlName As String = dr("CntrlName").ToString().Trim()
                    FormId = dr("FormId").ToString()
                    Id = dr("Id").ToString()
                    If HeaderName > "" Then
                        leftPos = dr("LocationX").ToString()
                        topPos = dr("LocationY").ToString()
                        width = dr("SizeWidth").ToString()
                        height = dr("SizeHeight").ToString()
                        Dim lbl As New Label()
                        lbl.Name = "Lbl_" & Name
                        lbl.Text = HeaderName
                        If Name = "Grid1" Or Name = "Grid2" Or Name = "Grid3" Or Name = "Grid4" Or Name = "Grid5" Then
                            lbl.Visible = False
                        Else
                            lbl.Visible = True
                        End If
                        lbl.Left = leftPos
                        lbl.Top = topPos
                        lbl.AutoSize = False
                        lbl.Width = 120   ' 🔒 fixed width for all labels
                        lbl.TextAlign = ContentAlignment.MiddleRight
                        Me.Controls.Add(lbl)
                        AddHandler lbl.MouseDown, AddressOf Control_MouseDown
                        AddHandler lbl.MouseMove, AddressOf Control_MouseMove
                        AddHandler lbl.MouseUp, AddressOf Control_MouseUp
                        If colType = "TextBox" Then
                            Dim LblSize As Int16 = lbl.Width
                            Dim txt As New TextBox()
                            txt.Name = Name
                            txt.Left = leftPos + 130
                            txt.Top = topPos
                            txt.Width = width
                            txt.Height = height
                            txt.Tag = Tag
                            txt.TabIndex = Tabindex
                            Me.Controls.Add(txt)
                            If txt.TabIndex = 1 Then
                                txt.Focus()
                            End If
                            Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrlName, StringComparison.OrdinalIgnoreCase))
                            AddHandler txt.MouseDown, AddressOf Control_MouseDown
                            AddHandler txt.MouseMove, AddressOf Control_MouseMove
                            AddHandler txt.MouseUp, AddressOf Control_MouseUp
                            'Master list Bind karne ke liye
                            AddHandler txt.KeyDown, AddressOf Control_KeyDown
                        ElseIf colType = "Button" Then
                            Dim btn As New Button()
                            btn.Name = Name
                            btn.Left = leftPos + 130
                            btn.Top = topPos
                            btn.Width = width
                            Me.Controls.Add(btn)
                            AddHandler btn.MouseDown, AddressOf Control_MouseDown
                            AddHandler btn.MouseMove, AddressOf Control_MouseMove
                            AddHandler btn.MouseUp, AddressOf Control_MouseUp


                        ElseIf colType = "ComboBox" AndAlso HeaderName > "" Then
                            Dim cmb As New ComboBox()


                            'AddHandler txt.KeyDown, AddressOf MoveNextOnEnter
                        End If
                        topPos += 35
                    End If
                Next

                ObjCls_General.CreateDataTable(tblFormValues, _Grid1ColNames.ToString, "YES")

#End Region
                BtnUpdatepos.Enabled = True
                btnmovecontrol.Enabled = True
            Else
                BtnUpdatepos.Enabled = False
                btnmovecontrol.Enabled = False
            End If
            Dim LASTCODE As String = ""
            If _FORMMODE = "EDIT" Then
                Dim formType As String = ""
                If _MainColumTbl.Rows.Count > 0 Then
                    formType = _MainColumTbl.Rows(0)("FormType").ToString().Trim()
                End If
                If formType = "MASTER FORM" Then
                    strQuery = GetMaxCode()
                    sqL = strQuery
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        LASTCODE = Val(DefaltSoftTable.Rows(0).Item(0))
                    Else
                        LASTCODE = "1"
                    End If
                    LASTCODE = _SELECTEDCOMPANYCODE & "-" & LASTCODE.PadLeft(9, "0")
                    _KeyFieldValue = LASTCODE
                    Dim tblTmp1 As DataTable = Alter_Form()
                End If
                'ElseIf _FORMMODE = "DELETE" Then
                '    Call Delete_Entry()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub Grid_RowColChange(sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs)
        _ActivatedColName = Trim(UCase(sender.Cell(0, sender.ActiveCell.Col).TAG))
    End Sub

    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        Dim ctrl As Control = TryCast(sender, Control)
        If ctrl Is Nothing Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim ActivetextName As String = ctrl.Text
            RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)
            Me.SelectNextControl(ctrl, True, True, True, True)
        ElseIf e.KeyCode = Keys.Up Then
            Dim ActivetextName As String = ctrl.Text
            Me.SelectNextControl(DirectCast(sender, Control), False, True, True, True)
        ElseIf e.KeyCode = Keys.Down Then
            Dim ActivetextName As String = ctrl.Text
            Me.SelectNextControl(ctrl, True, True, True, True)
        End If
    End Sub

    Private Sub RunActivatedColumnMasterSelection(ByVal ctrlmasterName As String, ByVal ActivetextName As String)

        For Each dr As DataRow In _MainColumTbl.Select("DataBaseColumn='" & ctrlmasterName & "'")
            Dim offmastercode As String = dr("OPPMASTERCODE").ToString()
            Dim masterName As String = dr("MASTERLIST").ToString()
            Dim ctrlNameStr As String = dr("CntrlName").ToString().Trim()
            Dim ctrl As Control = Me.Controls.Find(ctrlNameStr, True).FirstOrDefault()
            If offmastercode <> "" Then
                HandleMasterSelection(masterName, ctrlmasterName, offmastercode, ctrl, ActivetextName)
            End If
        Next

    End Sub
    Private Sub HandleControlAction(ByVal sender As Object)
        If isDragging Then
            HandleControlAction(sender)
        End If
    End Sub
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If Not isMoveMode Then Exit Sub   ' ❌ move disabled
        isDragging = True
        selectedCtrl = DirectCast(sender, Control)
        dragOffset = e.Location
        If e.Button = MouseButtons.Left Then
            selectedCtrl = DirectCast(sender, Control)
            PropertyGrid1.SelectedObject = selectedCtrl
        End If
    End Sub

    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        If Not isMoveMode OrElse Not isDragging Then Exit Sub

        Dim ctrl As Control = DirectCast(sender, Control)
        ctrl.Left += e.X - dragOffset.X
        ctrl.Top += e.Y - dragOffset.Y
    End Sub

    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        If Not isMoveMode Then Exit Sub
        isDragging = False
        SaveControlPosition(DirectCast(sender, Control))
    End Sub
    Private Sub SaveControlPosition(ctrl As Control)

        If ctrl Is Nothing Then Exit Sub
        Dim leftPos As Integer = ctrl.Left - 130
        Dim topPos As Integer = ctrl.Top
        Dim height As Integer = ctrl.Height
        Dim width As Integer = ctrl.Width
        Dim ctrlName As String = ctrl.Name
        Dim Tabindex As Integer = ctrl.TabIndex
        updatepossition(leftPos, topPos, height, width, ctrlName, Tabindex, FormId, Id)

    End Sub

    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _Grid1ColNames.ToString.ToUpper, "NO", _Grid1ColType.ToString)
        'grdObj.ExtendLastCol = True
        _Grid1LastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 2
    End Sub
    Private Sub GridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj Is Nothing OrElse grdObj.Cols = 0 Then Exit Sub
        grdObj.AutoRedraw = False
        grdObj.FixedRows = 1
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _FieldNotVisibile.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _FieldHeader.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _FieldHeaderAlignment.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _FieldAlignMent.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _FieldMasking.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _FieldWidthSet.ToString)
        ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _FieldLocked.ToString)
        Dim xFont As New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
        grdObj.AutoRedraw = True
        grdObj.Refresh()
    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        View_Record()
    End Sub
    Private Sub txtFormName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFormName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = txtFormName.Text
            obj_Party_Selection.SINGLE_FormnameMasterform_SELECTION()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                txtFormName.Text = MULTY_SELECTION_COLOUM_1_DATA
                btnView.Focus()
            End If
        End If
        isMoveMode = False
        isDragging = False
    End Sub

    Private Sub HandleMasterSelection(ByVal masterName As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal CntrlName As Control, ByVal ActivetextName As String)

        Select Case masterName

            Case "ACCOUNT MASTER"
                Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("AccountName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("AccountName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "AGENT MASTER"
                Dim _LoadQuery = NewSelectionList.Bill_Agent_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("AgentName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("AgentName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "CITY MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_City_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("cityname") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("cityname").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "STATE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_State_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("StateName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("StateName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_ITEM_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ITENNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ITENNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC DESIGN MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_DESIGN_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("DesignName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("DesignName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_SHADE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ShadeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ShadeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC SELVEDGE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Selvedge_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SelvedgeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SelvedgeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "YARN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Yarn_Type_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("YarnType") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("YarnType").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "YARN SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_YarnItem_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("CountName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("CountName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GENRAL ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_storeItem_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ItemName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ItemName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SUBITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_store_Sub_Item_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SubItemName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SubItemName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SIZE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_size_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SizeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SizeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "COLOR MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Color_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ColorName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ColorName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "REMARK MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Remark_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Remark") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Remark").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "PROCESS MASTER"
                Dim _LoadQuery = NewSelectionList.Single_process_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ACCOUNTNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "CUT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Cut_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("CUTNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("CUTNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "DEPARTMENT MASTER"
                Dim _LoadQuery = NewSelectionList.Single_STORE_DEPARTMENT_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("DepName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("DepName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "POST MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_POST_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Post") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Post").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "EMPLOYEE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Employee_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("EmployeeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("EmployeeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC GROUP MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Fabric_Item_Group_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GroupName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GroupName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GODOWN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Godown_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GodownName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GodownName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GRADER MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_GRADER_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GraderName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GraderName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "INSURANCE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_INSURANCE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("COMPANYNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("COMPANYNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "LOOMNO MASTER"
                Dim _LoadQuery = NewSelectionList.Single_LoomNo_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("LoomNo") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("LoomNo").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SALESMAN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_SalesMan_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Saleman") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Saleman").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "TRANSPORT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_TRANSPORT_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                If selected IsNot Nothing Then
                    If selected.ContainsKey("TransportName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("TransportName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
        End Select
    End Sub
    Private Sub SetGridValue(ByVal displayValue As String, ByVal codeValue As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal ctrl As Control)
        If ctrl IsNot Nothing Then
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = DirectCast(ctrl, TextBox)
                txt.Text = displayValue
                txt.ReadOnly = True
                Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase))
                If existingItem Is Nothing Then
                    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                Else
                    ' 🔹 Agar value update karni ho to replace karo
                    _UniqueValues.Remove(existingItem)
                    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                End If


            ElseIf TypeOf ctrl Is FlexCell.Grid Then
                Dim grd = DirectCast(ctrl, FlexCell.Grid)
                'Call Fill_Sr_No_Item(grd, _DataTableGrid1)
                If ctrl.Name = "Grid1" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid2" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid2.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid2.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid3" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid3.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid3.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid4" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid4.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid4.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid5" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid5.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid5.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                End If
            End If
        End If

        Dim listByControl = _UniqueValues.Where(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase)).ToList()
    End Sub
#Region "FILL SR NO"
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
        Next
    End Sub
#End Region
    Private Sub updatepossition(ByVal leftpos As String, ByVal topPos As String, ByVal Height As String, ByVal Width As String, ByVal ctrlName As String, ByVal Tabindex As String, ByVal FormId As String, ByVal Id As String)
        _strQuery = New StringBuilder
        Try
            If ctrlName = "Grid1" Or ctrlName = "Grid2" Or ctrlName = "Grid3" Or ctrlName = "Grid4" Or ctrlName = "Grid5" Then
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & "  WHERE CntrlName='" & ctrlName & "' and FormId='" & FormId & "'"
            Else
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & ",TabIndex=" & Tabindex & "  WHERE CntrlName='" & ctrlName & "' and FormId='" & FormId & "'"
            End If

            sqL = strQuery.ToString
            sql_connect_slect1()
        Catch ex As Exception

            MsgBox("Error While update Entry")
        Finally
            cmd = Nothing
        End Try
    End Sub
    Private Sub BtnUpdatepos_Click(sender As Object, e As EventArgs) Handles BtnUpdatepos.Click

        For Each ctrl As Control In Me.Controls
            ' sirf required controls
            If TypeOf ctrl Is Label OrElse
       TypeOf ctrl Is TextBox OrElse
       TypeOf ctrl Is Button OrElse TypeOf ctrl Is Grid Then
                SaveControlPosition(ctrl)
            End If
        Next
        PropertyGrid1.Visible = False
        txtFormName.Text = ""
        txtFormName.Focus()
        isMoveMode = False
        isDragging = False
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnmovecontrol.Click
        isMoveMode = True
        If isMoveMode = False Then
            'MessageBox.Show("Move mode enabled. Drag any control.")
            PropertyGrid1.Visible = False
        End If
        If isMoveMode Then
            PropertyGrid1.Visible = True

            If PropertyGrid1.SelectedObject Is Nothing AndAlso Me.ActiveControl IsNot Nothing Then
                PropertyGrid1.SelectedObject = Me.ActiveControl
            End If
        Else
            PropertyGrid1.Visible = False
        End If
    End Sub

    Private Sub MainMasterFormRead_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If PropertyGrid1.Visible = True Then
                PropertyGrid1.Visible = False
            Else
                Me.Close()
                Me.Dispose()
            End If
        End If
        If e.KeyCode = Keys.F4 Then
            PropertyGrid1.Visible = True

            If PropertyGrid1.SelectedObject Is Nothing AndAlso Me.ActiveControl IsNot Nothing Then
                PropertyGrid1.SelectedObject = Me.ActiveControl
            End If
        End If
    End Sub

    Private Sub MainMasterFormRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        Me.KeyPreview = True
        Me.Location = New POINT(0, 0)
        _FrmLoad = True
        CreateButtonsControl()
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        AttachButtonFocusEvents(Me)
        _FrmLoad = False
    End Sub
End Class