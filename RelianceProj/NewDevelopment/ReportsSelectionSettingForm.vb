Imports System.IO
Imports System.Text
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReportsSelectionSettingForm

    Public _SeletedFormName As String
    Dim _ModiMAsterid As Int64 = 0
    Private Sub ReportsSelectionSettingForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If PnlNewReports.Visible = True Then
                PnlNewReports.Visible = False
                GridView3.Focus()
                Exit Sub
            End If

            If PnlQueryEdit.Visible = True Then
                PnlQueryEdit.Visible = False
                GridView2.Focus()
                Exit Sub
            End If


            Me.Close()
            Me.Dispose(True)
        ElseIf e.KeyCode = Keys.F2 Then

            PnlNewReports.Visible = True

            _ModiMAsterid = 0
            Txt_ReportTitalName.Text = ""
            TxtReportFileName.Text = ""
            Txt_FileName.Text = ""


            Txt_ReportTitalName.Focus()
            Txt_ReportTitalName.SelectAll()
        End If
    End Sub
    Private Sub ReportSelectionSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer
        x = 0
        'y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        y = (Screen_Height - Screen_Height) + MasterMenuLoad.MenuStrip1.Height + 30
        Me.Location = New Point(x, y)

        PnlNewReports.Width = 500
        PnlNewReports.Height = 290
        PnlNewReports.Location = New Point(216, 199)

        PnlQueryEdit.Width = 1006
        PnlQueryEdit.Height = 626
        PnlQueryEdit.Location = New Point(0, 0)

        '_SeletedFormName = ReportForm._getformName()

        _LoadQuery()

    End Sub

    Public Function DefaltReportLoad()
        Dim _Query = New StringBuilder
        With _Query
            .Append("SELECT ")
            .Append(" MainMasterId")
            .Append(",ReportsCountNo")
            .Append(",ReportsOrderNo as SrNo")
            .Append(",ReportMenuName as Reports")
            .Append(",ActiveStatus ")
            .Append(",SettingType ")
            .Append(",ReportFormName ")
            .Append(",ReportRptFileName")
            .Append(",QueryFileName")
            .Append(",QueryFullFileName")
            .Append(",MasterSelectionList")
            .Append(" FROM Reports ")
            .Append(" WHERE 1=1 ")
            .Append(" AND ReportFormName = '" & _SeletedFormName & "' ")
            .Append(" AND SettingType = 'ReportSelection' ")
            .Append(" ORDER by ReportsOrderNo ")
        End With
        Return _Query.ToString
    End Function
    Public Function SaveReportLoad()
        Dim _Query = New StringBuilder
        With _Query
            .Append(" SELECT ")
            .Append(" Schedule_id as MainMasterId")
            .Append(",Group_master_finance as ReportsCountNo")
            .Append(",Main_account_master as SrNo")
            .Append(",STATEMASTER as Reports")
            .Append(",CITYMASTER as ActiveStatus ")
            .Append(",TRANSPORT_MASTER as SettingType ")
            .Append(",MSTCUTMASTER as ReportFormName ")
            .Append(",MSTFABRICMASTER as ReportRptFileName")
            .Append(",MSTFABRICHEAD as QueryFileName")
            .Append(",MSTFABRICGROUP as QueryFullFileName")
            .Append(",MSTYARNMASTER as MasterSelectionList")
            .Append(" FROM Vch_no ")
            .Append(" WHERE 1=1 ")
            .Append(" AND MSTCUTMASTER = '" & _SeletedFormName & "' ")
            .Append(" AND TRANSPORT_MASTER = 'ReportSelection' ")
            .Append(" ORDER by CAST(Main_account_master AS INT)  ")
        End With
        Return _Query.ToString
    End Function
    Private Sub _LoadQuery()

#Region "Read Save Menu"
        sqL = SaveReportLoad()
        sql_connect_slect()
        Dim _SaveTbl As New DataTable
        _SaveTbl = DefaltSoftTable.Copy

        GridControl2.DataSource = _SaveTbl
        GridView3.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
        GridView3.RowHeight = 25
        GridView3.Columns("MainMasterId").Visible = False
        GridView3.Columns("ReportsCountNo").Visible = False
        GridView3.Columns("SettingType").Visible = False
        'GridView3.Columns("ActiveStatus").Visible = False
        GridView3.Columns("ReportFormName").Visible = False
        GridView3.Columns("ReportRptFileName").Visible = False
        GridView3.Columns("QueryFileName").Visible = False
        GridView3.Columns("QueryFullFileName").Visible = False
        GridView3.Columns("MasterSelectionList").Visible = False

        GridView3.Columns("MainMasterId").OptionsColumn.AllowEdit = False
        GridView3.Columns("ReportsCountNo").OptionsColumn.AllowEdit = False
        'GridView3.Columns("SrNo").OptionsColumn.AllowEdit = False
        GridView3.Columns("Reports").OptionsColumn.AllowEdit = False
        GridView3.Columns("ActiveStatus").OptionsColumn.AllowEdit = False
        GridView3.Columns("SettingType").OptionsColumn.AllowEdit = False
        GridView3.Columns("ReportFormName").OptionsColumn.AllowEdit = False
        GridView3.Columns("ReportRptFileName").OptionsColumn.AllowEdit = False
        GridView3.Columns("QueryFileName").OptionsColumn.AllowEdit = False
        GridView3.Columns("QueryFullFileName").OptionsColumn.AllowEdit = False
        GridView3.Columns("MasterSelectionList").OptionsColumn.AllowEdit = False
        'GridView3.BestFitColumns()

        GridView3.Columns("SrNo").Width = 25
        GridView3.Columns("Reports").Width = 180
        GridView3.Columns("ActiveStatus").Width = 30
        'GridView2.Columns("QueryFileName").Width = 50

        If _SaveTbl.Rows.Count > 0 Then
            For Each dr As DataRow In _SaveTbl.Select
                _UpdateeportIfModify(dr("MainMasterId").ToString, dr("Reports").ToString, dr("ReportRptFileName").ToString, dr("QueryFileName").ToString, dr("MasterSelectionList").ToString)
            Next
        End If
#End Region



        RS = DefaltReportLoad()
        Dim _Tblclon As New DataTable
        ReportsMenu_QueryLoad()
        _Tblclon = DefaltSoftTable.Copy

        GridControl1.DataSource = _Tblclon
        GridView2.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
        GridView2.RowHeight = 25
        GridView2.Columns("MainMasterId").Visible = False
        GridView2.Columns("ReportsCountNo").Visible = False
        GridView2.Columns("SettingType").Visible = False
        GridView2.Columns("ActiveStatus").Visible = False
        GridView2.Columns("ReportFormName").Visible = False
        GridView2.Columns("ReportRptFileName").Visible = False
        GridView2.Columns("QueryFileName").Visible = False
        GridView2.Columns("QueryFullFileName").Visible = False
        GridView2.Columns("MasterSelectionList").Visible = False

        GridView2.Columns("MainMasterId").OptionsColumn.AllowEdit = False
        GridView2.Columns("ReportsCountNo").OptionsColumn.AllowEdit = False
        GridView2.Columns("SrNo").OptionsColumn.AllowEdit = False
        GridView2.Columns("Reports").OptionsColumn.AllowEdit = False
        GridView2.Columns("ActiveStatus").OptionsColumn.AllowEdit = False
        GridView2.Columns("SettingType").OptionsColumn.AllowEdit = False
        GridView2.Columns("ReportFormName").OptionsColumn.AllowEdit = False
        GridView2.Columns("ReportRptFileName").OptionsColumn.AllowEdit = False
        GridView2.Columns("QueryFileName").OptionsColumn.AllowEdit = False
        GridView2.Columns("QueryFullFileName").OptionsColumn.AllowEdit = False
        GridView2.Columns("MasterSelectionList").OptionsColumn.AllowEdit = False
        'GridView2.BestFitColumns()

        GridView2.Columns("SrNo").Width = 25
        GridView2.Columns("Reports").Width = 180
        'GridView2.Columns("QueryFileName").Width = 50






    End Sub
    Private Sub BtnInsertMasterItem_Click(sender As Object, e As EventArgs) Handles BtnInsertMasterItem.Click
        MainMenuDataselect()
    End Sub
    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            MainMenuDataselect()
        ElseIf Control.ModifierKeys = Keys.Control AndAlso e.KeyCode = Keys.Q Then

            'PnlQueryEdit.Visible = True
            'Txt_QueryEdit.Focus()
            '_ModiMAsterid = GridView2.GetFocusedRowCellValue("MainMasterId")
            'Dim QueryFullFileName As String = GridView2.GetFocusedRowCellValue("QueryFullFileName").ToString
            'Dim QueryFileName As String = GridView2.GetFocusedRowCellValue("QueryFileName").ToString


            'Dim _filePath As String = System.Windows.Forms.Application.StartupPath & "\SystemDll\"
            'Dim fullFilePath As String = _filePath & QueryFullFileName

            'If File.Exists(fullFilePath) Then
            '    Dim content As String = File.ReadAllText(fullFilePath)
            '    Txt_QueryEdit.Text = content
            'Else
            '    Txt_QueryEdit.Text = ""
            'End If
            Dim ReportQuery As New ReportQueryLoad()
            ReportQuery.Show()
        End If
    End Sub
    Private Sub MainMenuDataselect()
        Dim MainMasterId As Integer = GridView2.GetFocusedRowCellValue("MainMasterId")
        Dim ReportsCountNo As Integer = GridView2.GetFocusedRowCellValue("ReportsCountNo")
        Dim SrNo As Integer = GridView2.GetFocusedRowCellValue("SrNo")
        Dim Reports As String = GridView2.GetFocusedRowCellValue("Reports").ToString
        Dim ActiveStatus As String = GridView2.GetFocusedRowCellValue("ActiveStatus").ToString
        Dim SettingType As String = GridView2.GetFocusedRowCellValue("SettingType").ToString
        Dim ReportFormName As String = GridView2.GetFocusedRowCellValue("ReportFormName").ToString
        Dim ReportRptFileName As String = GridView2.GetFocusedRowCellValue("ReportRptFileName").ToString
        Dim QueryFileName As String = GridView2.GetFocusedRowCellValue("QueryFileName").ToString
        Dim QueryFullFileName As String = GridView2.GetFocusedRowCellValue("QueryFullFileName").ToString
        Dim MasterSelectionList As String = GridView2.GetFocusedRowCellValue("MasterSelectionList").ToString

        Dim _checkAllReadySelect As Boolean = False
        For i As Integer = 0 To GridView3.RowCount - 1
            If MainMasterId = Val(GridView3.GetRowCellValue(i, "MainMasterId")) Then
                '_checkAllReadySelect = True
                GridView3.DeleteRow(i)
                'MsgBox("All Ready Selected", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                'Exit For
            End If
        Next

        If _checkAllReadySelect = False Then
            GridView3.AddNewRow()
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "MainMasterId", MainMasterId)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ReportsCountNo", ReportsCountNo)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "SrNo", SrNo)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "Reports", Reports)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ActiveStatus", ActiveStatus)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "SettingType", SettingType)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ReportFormName", ReportFormName)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ReportRptFileName", ReportRptFileName)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "QueryFileName", QueryFileName)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "QueryFullFileName", QueryFullFileName)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "MasterSelectionList", MasterSelectionList)

            GridView3.Focus()
            GridView3.SelectAll()

            GridView2.Focus()
            GridView2.SelectAll()
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        'MainMenuDataselect()

        _ModiMAsterid = GridView2.GetFocusedRowCellValue("MainMasterId")
        Dim Reports As String = GridView2.GetFocusedRowCellValue("Reports").ToString
        Dim ReportRptFileName As String = GridView2.GetFocusedRowCellValue("ReportRptFileName").ToString
        Dim QueryFileName As String = GridView2.GetFocusedRowCellValue("QueryFileName").ToString
        Dim MasterSelectionList As String = GridView2.GetFocusedRowCellValue("MasterSelectionList").ToString

        Txt_ReportTitalName.Text = Reports
        TxtReportFileName.Text = ReportRptFileName
        Txt_FileName.Text = QueryFileName
        Txt_MasterSelection.Text = MasterSelectionList

        PnlNewReports.Visible = True
        Txt_ReportTitalName.Focus()
        Txt_ReportTitalName.SelectAll()
    End Sub
    Private Sub GridView3_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GridView3.KeyDown
        Dim _ActivatedColName = GridView3.FocusedColumn.FieldName
        If _ActivatedColName = "ActiveStatus" Then
            If e.KeyCode = Keys.Space Then
                If GridView3.GetFocusedRowCellValue("ActiveStatus") = "YES" Then
                    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ActiveStatus", "NO")
                ElseIf GridView3.GetFocusedRowCellValue("ActiveStatus") = "" Then
                    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ActiveStatus", "YES")
                ElseIf GridView3.GetFocusedRowCellValue("ActiveStatus") = "NO" Then
                    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ActiveStatus", "YES")
                End If
            ElseIf e.KeyCode = Keys.Y Then
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ActiveStatus", "YES")
            ElseIf e.KeyCode = Keys.N Then
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "ActiveStatus", "NO")
            End If
        End If

        If e.KeyCode = Keys.Delete Then
            If MsgBox("Remove Reports Item (Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Delete ?") = MsgBoxResult.Yes Then
                GridView3.DeleteRow(GridView3.FocusedRowHandle)
            End If
        End If
    End Sub
    Private Sub Btn_DeleteMasterItem_Click(sender As Object, e As EventArgs) Handles Btn_DeleteMasterItem.Click
        If MsgBox("Remove Reports Item (Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Delete ?") = MsgBoxResult.Yes Then
            GridView3.DeleteRow(GridView3.FocusedRowHandle)
        End If
    End Sub
    Private Sub BtnSaveMasterMenu_Click(sender As Object, e As EventArgs) Handles BtnSaveMasterMenu.Click

        If MsgBox("Do You Want Save Reports", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Reports Save ?") = MsgBoxResult.Yes Then
            _saveSelectedReportList()
            MsgBox("Reports Save Success", MsgBoxStyle.Information, "Soft-Tex PRO")
        End If
    End Sub

    Private Sub _saveSelectedReportList()

        sqL = "Delete from Vch_no where MSTCUTMASTER='" & _SeletedFormName & "' "
        sql_Data_Save_Delete_Update()

        For i As Integer = 0 To GridView3.RowCount - 1
            If Val(GridView3.GetRowCellValue(i, "MainMasterId")) > 0 Then
                If GridView3.GetRowCellValue(i, "ActiveStatus").ToString() = "YES" Then
                    Dim _strQuery = New StringBuilder
                    With _strQuery
                        .Append("INSERT INTO Vch_no ( ")
                        .Append("Schedule_id")
                        .Append(",Group_master_finance")
                        .Append(",Main_account_master")
                        .Append(",STATEMASTER")
                        .Append(",CITYMASTER")
                        .Append(",TRANSPORT_MASTER")
                        .Append(",MSTCUTMASTER")
                        .Append(",MSTFABRICMASTER")
                        .Append(",MSTFABRICHEAD")
                        .Append(",MSTFABRICGROUP")
                        .Append(",MSTYARNMASTER")
                        .Append(" ) VALUES ( ")
                        .Append(" '" & GridView3.GetRowCellValue(i, "MainMasterId").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "ReportsCountNo").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "SrNo").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "Reports").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "ActiveStatus").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "SettingType").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "ReportFormName").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "ReportRptFileName").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "QueryFileName").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "QueryFullFileName").ToString() & "' ")
                        .Append(",'" & GridView3.GetRowCellValue(i, "MasterSelectionList").ToString() & "' ")
                        .Append(" ) ")
                    End With
                    sqL = _strQuery.ToString
                    sql_Data_Save_Delete_Update()
                End If
            End If
        Next
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
        Me.Dispose(True)
    End Sub
    Private Sub BtnShrtCutRefresh_Click(sender As Object, e As EventArgs) Handles BtnShrtCutRefresh.Click
        _LoadQuery()
    End Sub
    Private Sub BtnReportNewClose_Click(sender As Object, e As EventArgs) Handles BtnReportNewClose.Click
        PnlNewReports.Visible = False
        GridView3.Focus()
    End Sub

    Private Sub _UpdateeportIfModify(ByVal MainMasterId As Long, ByVal MenuName As String, ByVal RptFileName As String, ByVal QueryFileName As String, ByVal MasterSelectionList As String)

        Dim _Query = New StringBuilder
        With _Query
            .Append("UPDATE Reports  SET ")
            .Append("ReportMenuName='" & MenuName & "' ")
            .Append(",ReportRptFileName='" & RptFileName & "' ")
            .Append(",QueryFileName='" & QueryFileName & "'")
            .Append(",QueryFullFileName='" & QueryFileName & "'")
            .Append(",MasterSelectionList='" & MasterSelectionList & "'")
            .Append(" WHERE 1=1 ")
            .Append(" AND MainMasterId=" & MainMasterId & "")
        End With
        RS = _Query.ToString
        ReportsMenu_QuerySaveUpdateDelete()
        _ModiMAsterid = 0
    End Sub

    Private Sub BtnNewReportSave_Click(sender As Object, e As EventArgs) Handles BtnNewReportSave.Click

        If _ModiMAsterid > 0 Then


            Dim _Query = New StringBuilder
            With _Query
                .Append("UPDATE Vch_no  SET ")
                .Append("STATEMASTER='" & Txt_ReportTitalName.Text.Trim & "' ")
                .Append(",MSTFABRICMASTER='" & TxtReportFileName.Text.Trim & "' ")
                .Append(",MSTFABRICHEAD='" & Txt_FileName.Text.Trim & "'")
                .Append(",MSTFABRICGROUP='" & Txt_FileName.Text.Trim & "'")
                .Append(",MSTYARNMASTER='" & Txt_MasterSelection.Text.Trim & "'")
                .Append(" WHERE 1=1 ")
                .Append(" AND Schedule_id='" & _ModiMAsterid & "'")
            End With
            sqL = _Query.ToString
            sql_Data_Save_Delete_Update()


            _UpdateeportIfModify(_ModiMAsterid, Txt_ReportTitalName.Text.Trim, TxtReportFileName.Text.Trim, Txt_FileName.Text.Trim, Txt_MasterSelection.Text.Trim)
            MsgBox("Report Update Success", MsgBoxStyle.Information, "Soft-Tex PRO")
            _LoadQuery()
        Else

            RS = " delete FROM Reports WHERE 1=1 and MainMasterId =" & _ModiMAsterid & " "
            ReportsMenu_QueryLoad()


            RS = "SELECT TOP 1  MainMasterId  FROM Reports WHERE 1=1 ORDER BY MainMasterId DESC "
            Dim _TblMainMasterId As New DataTable
            ReportsMenu_QueryLoad()
            _TblMainMasterId = DefaltSoftTable.Copy
            Dim _MainMasterId As Integer = 1
            If _TblMainMasterId.Rows.Count > 0 Then
                _MainMasterId = _TblMainMasterId.Rows(0).Item("MainMasterId") + 1
            End If


            RS = "SELECT TOP 1  ReportsCountNo  FROM Reports WHERE 1=1 AND ReportFormName = '" & _SeletedFormName & "' ORDER BY ReportsCountNo DESC "
            Dim ReportsCountNo As New DataTable
            ReportsMenu_QueryLoad()
            ReportsCountNo = DefaltSoftTable.Copy
            Dim _ReportsCountNo As Integer = 1
            If ReportsCountNo.Rows.Count > 0 Then
                _ReportsCountNo = ReportsCountNo.Rows(0).Item("ReportsCountNo") + 1
            End If


            Dim _Query = New StringBuilder
            With _Query
                .Append("INSERT INTO Reports (")
                .Append(" MainMasterId")
                .Append(",ReportsCountNo")
                .Append(",ReportsOrderNo")
                .Append(",ReportMenuName")
                .Append(",ActiveStatus ")
                .Append(",SettingType ")
                .Append(",ReportFormName ")
                .Append(",ReportRptFileName")
                .Append(",QueryFileName")
                .Append(",QueryFullFileName")
                .Append(",MasterSelectionList")
                .Append(") VALUES (")
                .Append(" " & _MainMasterId & " ")
                .Append(" ," & _ReportsCountNo & " ")
                .Append(" ," & _ReportsCountNo & " ")
                .Append(" ,'" & Txt_ReportTitalName.Text.Trim & "' ")
                .Append(" ,'YES' ")
                .Append(" ,'ReportSelection' ")
                .Append(" ,'" & _SeletedFormName & "' ")
                .Append(" ,'" & TxtReportFileName.Text.Trim & "' ")
                .Append(" ,'" & Txt_FileName.Text.Trim & "' ")
                .Append(" ,'" & Txt_FileName.Text.Trim & "' ")
                .Append(" ,'" & Txt_MasterSelection.Text.Trim & "' ")
                .Append(" )")
            End With
            RS = _Query.ToString
            ReportsMenu_QuerySaveUpdateDelete()
            MsgBox("New Report Save Success", MsgBoxStyle.Information, "Soft-Tex PRO")
        End If



        PnlNewReports.Visible = False
        GridView2.Focus()
        GridView2.SelectAll()
        MainMenuDataselect()
        _saveSelectedReportList()
        Txt_MasterSelection.Text = ""
        Txt_ReportTitalName.Text = ""
        TxtReportFileName.Text = ""
        Txt_FileName.Text = ""
        _ModiMAsterid = 0
        _LoadQuery()
    End Sub
    Public Function _LoadReportOption()
        Dim _SaveTbl As New DataTable
        sqL = SaveReportLoad()
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _SaveTbl = DefaltSoftTable.Copy
        Else
            RS = DefaltReportLoad()
            ReportsMenu_QueryLoad()
            _SaveTbl = DefaltSoftTable.Copy
        End If
        Return _SaveTbl
    End Function
    Public Sub _FormGridSetting(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)

        gridView.Appearance.Row.Font = New Font("Verdana", 9, FontStyle.Bold)
        gridView.RowHeight = 30
        gridView.Columns("MainMasterId").Visible = False
        gridView.Columns("ReportsCountNo").Visible = False
        gridView.Columns("SettingType").Visible = False
        gridView.Columns("ActiveStatus").Visible = False
        gridView.Columns("ReportFormName").Visible = False
        gridView.Columns("ReportRptFileName").Visible = False
        gridView.Columns("QueryFileName").Visible = False
        gridView.Columns("QueryFullFileName").Visible = False
        gridView.Columns("MasterSelectionList").Visible = False

        gridView.Columns("SrNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        gridView.Columns("SrNo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


        For Each Col As DevExpress.XtraGrid.Columns.GridColumn In gridView.Columns
            Col.AppearanceHeader.BackColor = Color.DarkGreen   'PrimaryDataGridViewColumnHeaderBackColor
            Col.AppearanceHeader.BackColor2 = Color.DarkGreen
            Col.AppearanceHeader.Options.UseForeColor = True
            Col.AppearanceHeader.Options.UseBackColor = True
        Next

        gridView.Columns("SrNo").Width = 20
        gridView.Columns("Reports").Width = 230

    End Sub
    Private Sub Txt_MasterSelection_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_MasterSelection.KeyDown
        If e.KeyCode = Keys.Enter Then
            MasterselectionTable()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Txt_MasterSelection.Text = MULTY_SELECTION_COLOUM_3_DATA.Replace("(", "").Replace(")", "").Replace("'", "")
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Public Sub MasterselectionTable()
        Dim HSNType As New DataTable
        Dim HSN_Type = New DataColumn("MasterName", GetType(String))
        Dim Remark = New DataColumn("Remark", GetType(String))
        Dim HSN_Type1 = New DataColumn("MasterName1", GetType(String))
        Dim HSN_Type2 = New DataColumn("MasterName2", GetType(String))
        Dim HSN_Type3 = New DataColumn("MasterName3", GetType(String))

        HSNType.Columns.Add(HSN_Type)
        HSNType.Columns.Add(Remark)
        HSNType.Columns.Add(HSN_Type1)
        HSNType.Columns.Add(HSN_Type2)
        HSNType.Columns.Add(HSN_Type3)


        HSNType.Rows.Add("NONE", "", "NONE", "NONE", "NONE")
        HSNType.Rows.Add("ACCOUNT MASTER", "", "ACCOUNT MASTER", "ACCOUNT MASTER", "ACCOUNT MASTER")
        HSNType.Rows.Add("FABRIC ITEM", "", "FABRIC ITEM", "FABRIC ITEM", "FABRIC ITEM")
        HSNType.Rows.Add("FABRIC DESIGN", "", "FABRIC DESIGN", "FABRIC DESIGN", "FABRIC DESIGN")
        HSNType.Rows.Add("FABRIC SHADE", "", "FABRIC SHADE", "FABRIC SHADE", "FABRIC SHADE")
        HSNType.Rows.Add("CUT MASTER", "", "CUT MASTER", "CUT MASTER", "CUT MASTER")


        Party_selection_multy.dgw.DataSource = HSNType.Copy
        Party_selection_multy.dgw.Columns("MasterName1").Visible = False
        Party_selection_multy.dgw.Columns("MasterName2").Visible = False
        Party_selection_multy.dgw.Columns("MasterName3").Visible = False


        Dim Chk As New DataGridViewCheckBoxColumn()
        Party_selection_multy.dgw.Columns.Add(Chk)

        Party_selection_multy.dgw.Columns(0).Width = 380
        Party_selection_multy.dgw.Columns(1).Width = 200
        Party_selection_multy.dgw.Columns(2).Width = 150
        Party_selection_multy.dgw.Columns(5).Width = 30

        Party_selection_multy.Width = 644
        obj_Party_Selection.SELECTION_LIST_FIRST_multy_SELECTION()
    End Sub

    Private Sub SelectRptFile_Click(sender As Object, e As EventArgs) Handles SelectRptFile.Click
        OpenFileDialog1.ShowDialog()
        Dim pathSource As String = OpenFileDialog1.FileName
        Dim fileName As String = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        Txt_FileName.Text = fileName
    End Sub

    Private Sub BtnQueryPanelHide_Click(sender As Object, e As EventArgs) Handles BtnQueryPanelHide.Click
        PnlQueryEdit.Visible = False
    End Sub

    Private Sub Btn_QuerySave_Click(sender As Object, e As EventArgs) Handles Btn_QuerySave.Click
        If Txt_QueryEdit.Text > "" Then
            Dim _filePath As String = System.Windows.Forms.Application.StartupPath & "\SystemDll\"
            Dim fullFilePath As String = GridView2.GetFocusedRowCellValue("ReportFormName").ToString()
            Dim OldFileName As String = GridView2.GetFocusedRowCellValue("QueryFullFileName").ToString()
            _ModiMAsterid = GridView2.GetFocusedRowCellValue("MainMasterId")


            If fullFilePath.Length >= 7 Then
                fullFilePath = fullFilePath.Substring(0, 7) & CreateGUID() & ".sqm"
            Else
                fullFilePath = fullFilePath & CreateGUID() & ".sqm"
            End If


            ' Check if the file exists and delete it
            If System.IO.File.Exists(_filePath & OldFileName) Then
                System.IO.File.Delete(_filePath & OldFileName)
            End If


            System.IO.File.WriteAllText(_filePath & fullFilePath, Txt_QueryEdit.Text) ' Save as plain text


            RS = " UPDATE  Reports  SET QueryFullFileName='" & fullFilePath & "'   ,QueryFileName='" & fullFilePath & "'  WHERE 1=1 and MainMasterId =" & _ModiMAsterid & " "
            ReportsMenu_QuerySaveUpdateDelete()


            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "QueryFullFileName", fullFilePath)
            GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "QueryFileName", fullFilePath)


            MsgBox("Query Save", MsgBoxStyle.Information, "Soft-Tex PRO")
            PnlQueryEdit.Visible = False



            GridView2.Focus()
            GridView2.SelectAll()
            MainMenuDataselect()
            _saveSelectedReportList()

            _LoadQuery()
        Else
            MsgBox("Blank Query Can't Save", MsgBoxStyle.Information, "Soft-Tex PRO")

        End If

    End Sub


End Class