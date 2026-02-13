Imports System.Text
Imports DevExpress.XtraGrid.Views
Imports FlexCell

Public Class MainFormRead
    Private _DatabaseTableName = "FormControl"
    Dim _ActivatedColName As String = ""

    Dim _MainColumTbl As New DataTable
    Dim isDragging As Boolean = False
    Dim dragOffset As Point

    Private _FieldWidthSet As New StringBuilder
    Private _FieldHeader As New StringBuilder
    Private _FieldHeaderAlignment As New StringBuilder
    Private _FieldAlignMent As New StringBuilder
    Private _FieldNotVisibile As New StringBuilder
    Private _FieldLocked As New StringBuilder


    Private _FieldMasking As New StringBuilder

    Private _FieldUsemaster As New StringBuilder
    Private _Fieldmasterlist As New StringBuilder

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

    Private Sub MainFormRead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        '_FrmLoad = True
        CreateButtonsControl()
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        AttachButtonFocusEvents(Me)
        '_FrmLoad = False
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

        Change_Grid_Data = True
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
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

        End If
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_NextClick()
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        If _FORMMODE = "EDIT" Then
            Call Ctrl_Visible_True(Me.Controls)
            UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_SaveClick()

        _FrmLoad = False
        Dim Array_Opening(0, 4) As String
        Dim Pcs_Row_No As Integer = 0
        Interaction.MsgBox("Records Successfully Saved",
                       MsgBoxStyle.Information,
                       "Soft-Tex PRO")

        ObjCls_General.Blank_Object(Me)

        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")

    End Sub
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
        Dim I As Integer = 0
        Dim _LastID As Integer = 0

        _strQuery = New StringBuilder

        Try
            'strQuery = "DELETE FROM " & _DatabaseTableNameItem & " WHERE FormID='" & Txt_FormId.Text & "'"
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


        If _MainColumTbl.Rows.Count > 0 Then

            For Each dr As DataRow In _MainColumTbl.Rows
                Dim colName As String = dr("DataBaseColumn").ToString().Trim()
                Dim header As String = dr("Text").ToString().Trim()
                Dim alignVal As String = dr("TextAlign").ToString().Trim().ToUpper()
                If alignVal = "" Then alignVal = "L"
                If header = "" OrElse colName = "" Then
                    Continue For
                End If
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

                ' Grid Col Names
                If _Grid1ColNames.Length > 0 Then
                    _Grid1ColNames.Append(",")
                End If
                _Grid1ColNames.Append(colName)
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

        Dim View_Filter_Condition = " AND  FormName='" & txtFormName.Text & "'  "
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
                Dim colType As String = dr("ColumnType").ToString()
                Dim HeaderName As String = dr("Text").ToString()
                Dim Name As String = dr("CntrlName").ToString()
                Dim Tabindex As Int64 = dr("Tabindex").ToString()
                FormId = dr("FormId").ToString()
                Id = dr("Id").ToString()
                leftPos = dr("LocationX").ToString()
                topPos = dr("LocationY").ToString()
                width = dr("SizeWidth").ToString()
                height = dr("SizeHeight").ToString()
                Dim Tag As String = dr("DataBaseColumn").ToString()
                Dim oppMasterCode As String = dr("OppMasterCode").ToString()
                ' 🏷 Label

                Dim lbl As New Label()
                lbl.Name = "Lbl_" & Name
                lbl.Text = HeaderName
                lbl.Left = leftPos
                lbl.Top = topPos
                lbl.AutoSize = False
                lbl.Width = 120   ' 🔒 fixed width for all labels
                lbl.TextAlign = ContentAlignment.MiddleRight
                Me.Controls.Add(lbl)
                AddHandler lbl.MouseDown, AddressOf Control_MouseDown
                AddHandler lbl.MouseMove, AddressOf Control_MouseMove
                AddHandler lbl.MouseUp, AddressOf Control_MouseUp

                ' 📝 TextBox sirf tab banao jab ColumnType TextBox ho
                If colType = "TextBox" AndAlso HeaderName > "" Then



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

                    AddHandler txt.MouseDown, AddressOf Control_MouseDown
                    AddHandler txt.MouseMove, AddressOf Control_MouseMove
                    AddHandler txt.MouseUp, AddressOf Control_MouseUp
                    'Master list Bind karne ke liye
                    AddHandler txt.KeyDown, AddressOf Control_KeyDown


                ElseIf colType = "Button" AndAlso HeaderName > "" Then
                    Dim btn As New Button()
                    btn.Name = Name
                    btn.Left = leftPos + 130
                    btn.Top = topPos
                    btn.Width = width
                    Me.Controls.Add(btn)
                    AddHandler btn.MouseDown, AddressOf Control_MouseDown
                    AddHandler btn.MouseMove, AddressOf Control_MouseMove
                    AddHandler btn.MouseUp, AddressOf Control_MouseUp

                ElseIf colType = "Grid" AndAlso HeaderName > "" Then
                    'Dim gridname As String = _MainColumTbl.Rows(0)("CntrlName").ToString()
                    Dim gridname As String = dr("CntrlName").ToString().Trim()
                    If gridname = "Grid1" Then
                        Dim grid1 As FlexCell.Grid = SetupFlexGrid1(gridname, _DataTableGrid1, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                    ElseIf gridname = "Grid2" Then
                        Dim grid2 As FlexCell.Grid = SetupFlexGrid1(gridname, _DataTableGrid2, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                    ElseIf gridname = "Grid3" Then
                        Dim grid3 As FlexCell.Grid = SetupFlexGrid1(gridname, _DataTableGrid3, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                    ElseIf gridname = "Grid4" Then
                        Dim grid4 As FlexCell.Grid = SetupFlexGrid1(gridname, _DataTableGrid4, leftPos, topPos, width, height, oppMasterCode, Tabindex)
                    ElseIf gridname = "Grid5" Then
                        Dim grid5 As FlexCell.Grid = SetupFlexGrid1(gridname, _DataTableGrid5, leftPos, topPos, width, height, oppMasterCode, Tabindex)

                    End If

                ElseIf colType = "ComboBox" AndAlso HeaderName > "" Then
                    Dim cmb As New ComboBox()


                    'AddHandler txt.KeyDown, AddressOf MoveNextOnEnter
                End If

                topPos += 35
            Next
#End Region
            BtnUpdatepos.Enabled = True
            btnmovecontrol.Enabled = True
        Else
            BtnUpdatepos.Enabled = False
            btnmovecontrol.Enabled = False
        End If

    End Sub
    Private Function SetupFlexGrid1(ByVal gridName As String, ByVal gridTable As DataTable, ByVal leftPos As Integer, ByVal topPos As Integer, ByVal width As Integer, ByVal height As Integer, ByVal tagValue As Object, ByVal TabIndex As Integer) As FlexCell.Grid
        If String.IsNullOrWhiteSpace(gridName) Then Return Nothing
        Dim grd As FlexCell.Grid = TryCast(Me.Controls(gridName), FlexCell.Grid)
        If grd Is Nothing Then
            grd = New FlexCell.Grid()
            grd.Name = gridName
            Me.Controls.Add(grd)
        End If
        ' Basic properties
        grd.Visible = True
        grd.Left = leftPos + 130
        grd.Top = topPos
        grd.Width = width
        grd.Height = height
        grd.Tag = tagValue
        grd.TabIndex = TabIndex
        defineGridColName()
        If gridName = "Grid1" Then
            GenerateTable(_DataTableGrid1, grd)
            GridFormatting(_DataTableGrid1, grd)
        ElseIf gridName = "Grid2" Then
            GenerateTable(_DataTableGrid2, grd)
            GridFormatting(_DataTableGrid2, grd)
        ElseIf gridName = "Grid3" Then
            GenerateTable(_DataTableGrid3, grd)
            GridFormatting(_DataTableGrid3, grd)
        ElseIf gridName = "Grid4" Then
            GenerateTable(_DataTableGrid4, grd)
            GridFormatting(_DataTableGrid4, grd)
        ElseIf gridName = "Grid5" Then
            GenerateTable(_DataTableGrid5, grd)
            GridFormatting(_DataTableGrid5, grd)
        End If
        RemoveHandler grd.MouseDown, AddressOf Control_MouseDown
        RemoveHandler grd.MouseMove, AddressOf Control_MouseMove
        RemoveHandler grd.MouseUp, AddressOf Control_MouseUp

        AddHandler grd.MouseDown, AddressOf Control_MouseDown
        AddHandler grd.MouseMove, AddressOf Control_MouseMove
        AddHandler grd.MouseUp, AddressOf Control_MouseUp

        AddHandler grd.KeyDown, AddressOf Control_KeyDown
        AddHandler grd.RowColChange, AddressOf Grid_RowColChange

        grd.Cell(1, gridTable.Columns.IndexOf("SRNO") + 1).SetFocus()
        FocusSetToGridDefaultColumn(grd, _DefaultColOfGrid)
        Return grd
    End Function


    Private Sub Grid_RowColChange(sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs)
        _ActivatedColName = Trim(UCase(sender.Cell(0, sender.ActiveCell.Col).TAG))
    End Sub

    'Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
    '    Dim ctrl As Control = TryCast(sender, Control)
    '    If ctrl Is Nothing Then Exit Sub

    '    ' 🔹 Agar sender FlexCell Grid hai
    '    If TypeOf ctrl Is FlexCell.Grid Then
    '        If e.KeyCode = Keys.Enter Then
    '            Dim gridName As String = ctrl.Name
    '            Dim grd As FlexCell.Grid = TryCast(Me.Controls(gridName), FlexCell.Grid)
    '            _ActivatedColName = Trim(UCase(sender.Cell(0, sender.ActiveCell.Col).TAG))
    '            Dim ActivetextName = grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(_ActivatedColName) + 1).Text
    '            RunActivatedColumnMasterSelection(_ActivatedColName, ActivetextName)
    '        End If
    '    Else
    '        If e.KeyCode = Keys.Enter Then
    '            Dim ActivetextName = ctrl.Text
    '            RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)
    '            SendKeys.Send("{TAB}")
    '        End If
    '    End If
    'End Sub
    Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)

        Dim ctrl As Control = TryCast(sender, Control)
        If ctrl Is Nothing Then Exit Sub

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True   ' Enter sound band

            ' 🔹 Grid case
            If TypeOf ctrl Is FlexCell.Grid Then

                Dim grd As FlexCell.Grid = DirectCast(ctrl, FlexCell.Grid)

                _ActivatedColName = Trim(UCase(grd.Cell(0, grd.ActiveCell.Col).Tag))
                Dim ActivetextName =
                grd.Cell(grd.ActiveCell.Row,
                _DataTableGrid1.Columns.IndexOf(_ActivatedColName) + 1).Text

                RunActivatedColumnMasterSelection(_ActivatedColName, ActivetextName)
                SendKeys.Send("{TAB}")
            Else

                ' 🔹 TextBox case
                Dim ActivetextName As String = ctrl.Text
                RunActivatedColumnMasterSelection(ctrl.Tag, ActivetextName)

                ' ✅ Proper focus move
                Me.SelectNextControl(ctrl, True, True, True, True)

            End If

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
        updatepossition(leftPos, topPos, height, width, ctrlName, FormId, Id)

    End Sub

    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _Grid1ColNames.ToString.ToUpper, "NO", _Grid1ColType.ToString)
        'grdObj.ExtendLastCol = True
        _Grid1LastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
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

    Private Sub MainFormRead_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub txtFormName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFormName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
            Party_selection.txtSearch.Text = txtFormName.Text
            obj_Party_Selection.SINGLE_Formname_SELECTION()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                txtFormName.Text = MULTY_SELECTION_COLOUM_1_DATA
                btnView.Focus()
            End If
        End If

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
                obj_Party_Selection.Bill_Agent_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)

            Case "CITY MASTER"
                obj_Party_Selection.SINGLE_City_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)

            Case "STATE MASTER"
                obj_Party_Selection.Single_State_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)

            Case "FABRIC ITEM MASTER"
                obj_Party_Selection.SINGLE_ITEM_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)

            Case "FABRIC DESIGN MASTER"
                obj_Party_Selection.SINGLE_DESIGN_SELECTION("")
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)

            Case "FABRIC SHADE MASTER"
                obj_Party_Selection.SINGLE_SHADE_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)

            Case "FABRIC SELVEDGE MASTER"
                obj_Party_Selection.Single_Selvedge_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "YARN MASTER"
                obj_Party_Selection.Single_Yarn_Type_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "YARN SHADE MASTER"
                obj_Party_Selection.SINGLE_YarnItem_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "GENRAL ITEM MASTER"
                    'obj_Party_Selection.SINGLE_ITEM_SELECTION()
                    'SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "SUBITEM MASTER"
                obj_Party_Selection.SINGLE_store_Sub_Item_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "SIZE MASTER"
                obj_Party_Selection.Single_size_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "COLOR MASTER"
                obj_Party_Selection.Single_Color_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "REMARK MASTER"
                obj_Party_Selection.SINGLE_Remark_SELECTION("")
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "PROCESS MASTER"
                obj_Party_Selection.Single_process_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "CUT MASTER"
                obj_Party_Selection.SINGLE_Cut_SELECTION("")
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "DEPARTMENT MASTER"
                obj_Party_Selection.Single_STORE_DEPARTMENT_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "POST MASTER"
                obj_Party_Selection.SINGLE_POST_SELECTION("")
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "EMPLOYEE MASTER"
                obj_Party_Selection.SINGLE_Employee_SELECTION("")
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "FABRIC GROUP MASTER"
                obj_Party_Selection.Single_Fabric_Item_Group_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "GODOWN MASTER"
                obj_Party_Selection.Single_Godown_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "GRADER MASTER"
                obj_Party_Selection.SINGLE_GRADER_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "INSURANCE MASTER"
                obj_Party_Selection.SINGLE_INSURANCE_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "LOOMNO MASTER"
                obj_Party_Selection.Single_LoomNo_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "SALESMAN MASTER"
                obj_Party_Selection.Single_SalesMan_Selection()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
            Case "TRANSPORT MASTER"
                obj_Party_Selection.SINGLE_TRANSPORT_SELECTION()
                SetGridValue(MULTY_SELECTION_COLOUM_1_DATA, MULTY_SELECTION_COLOUM_3_DATA, activeColName, offMasterCode, CntrlName)
        End Select

    End Sub
    Private Sub SetGridValue(ByVal displayValue As String, ByVal codeValue As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal ctrl As Control)
        If ctrl IsNot Nothing Then
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = DirectCast(ctrl, TextBox)
                txt.Text = displayValue
                'txt.Tag = codeValue

                txt.ReadOnly = True

                'If Not _UniqueValues.Any(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase) AndAlso String.Equals(x.Item2, offMasterCode, StringComparison.OrdinalIgnoreCase) AndAlso String.Equals(x.Item3, codeValue, StringComparison.OrdinalIgnoreCase)) Then
                '    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                'End If
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
                Call Fill_Sr_No_Item(grd, _DataTableGrid1)
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

        'Dim listByControl = _UniqueValues.Where(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase)).ToList()
    End Sub
#Region "FILL SR NO"
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            'If Val(GrdObj.Cell(i, Data_Table.Columns.IndexOf("AMOUNT") + 1).Text) > 0 Then
            GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
            'End If
        Next
    End Sub
#End Region
    Private Sub updatepossition(ByVal leftpos As String, ByVal topPos As String, ByVal Height As String, ByVal Width As String, ByVal ctrlName As String, ByVal FormId As String, ByVal Id As String)
        _strQuery = New StringBuilder

        Try
            'strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & "  WHERE Text='" & ctrlName & "'"
            'strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & "  WHERE CntrlName='" & ctrlName & "' and FormId='" & FormId & "' and Id='" & Id & "'"
            If ctrlName = "Grid1" Or ctrlName = "Grid2" Or ctrlName = "Grid3" Or ctrlName = "Grid4" Or ctrlName = "Grid5" Then
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & "  WHERE CntrlName='" & ctrlName & "' and FormId='" & FormId & "'"
            Else
                strQuery = "UPDATE " & _DatabaseTableName & " Set LocationX=" & leftpos & ",LocationY=" & topPos & ",SizeHeight=" & Height & ",SizeWidth=" & Width & "  WHERE CntrlName='" & ctrlName & "' and FormId='" & FormId & "'"
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
End Class