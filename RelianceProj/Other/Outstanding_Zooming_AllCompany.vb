Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.VisualBasic.CompilerServices
Imports DevExpress.CodeParser
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Browsing

Friend Class Outstanding_Zooming_AllCompany

    Dim _TmpDataTable As New DataTable

    Dim _StgIRowNo As Integer = 1
    Dim _StgIIRowNo As Integer = 1
    Dim _StgThidRowNo As Integer = 1
    Dim _StgFourRowNo As Integer = 1
    Dim CurntYearAllCompTbl As New DataTable



    Private Display_Stage_No As Integer = 0

    Private Sub Outstanding_Zooming_AllCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        PnlRemark.Width = 586
        PnlRemark.Height = 214
        PnlRemark.Location = New Point(579, 177)
        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")


        GridControl1.Width = Me.Width - 30


        GridControl2.Width = GridControl1.Width
        GridControl2.Height = GridControl1.Height
        GridControl2.Location = New Point(4, 48)



        CreateDropDownMenu()

    End Sub
    Private Sub Outstanding_Zooming_AllCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then


            If PnlRemark.Visible = True Then
                PnlRemark.Visible = False
                FirstStage.Focus()
                Exit Sub
            End If



            If GridControl2.Visible = True Then
                GridControl2.Visible = False
                FirstStage.Focus()
                Exit Sub
            End If



            If Display_Stage_No = 1 Or Display_Stage_No = 0 Then
                If MessageBox.Show("Do You Want To Exit?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Close()
                    Dispose(True)
                End If
            Else
                FirstStage.Focus()
            End If

        End If
    End Sub

    Public Function _GetDebtorsCreditrGrup(ByVal _SelectionType As String)
        _strQuery = New StringBuilder
        With _strQuery
            If _SelectionType = "DEBTORS" Then
                .Append("  SELECT A.GroupName,B.ScheduleName,A.GROUPCODE,A.GROUPCODE,A.GROUPCODE ")
                .Append("  FROM MstFinGroup A ,MstFinSchedule B ")
                .Append("  WHERE 1=1 AND (LEFT(A.GROUPNAME,14)='SUNDRY DEBTORS') AND A.SCHEDULECODE=B.SrNo")
                .Append("  ORDER BY A.GROUPNAME")
            ElseIf _SelectionType = "CREDITORS" Then
                .Append("  SELECT A.GroupName,B.ScheduleName,A.GROUPCODE,A.GROUPCODE,A.GROUPCODE ")
                .Append("  FROM MstFinGroup A ,MstFinSchedule B ")
                .Append("  WHERE 1=1 AND (LEFT(A.GROUPNAME,16)='SUNDRY CREDITORS') AND A.SCHEDULECODE=B.SrNo")
                .Append("  ORDER BY A.GROUPNAME")
            End If
        End With
        Return _strQuery.ToString
    End Function

    Public Function _GetCurrentYearCompanyTable()

        Dim _Tmptbl As New DataTable

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append(" Data_Folder_Name ")
            .Append(" ,Comp_Print_Name ")
            .Append(" FROM MSTCOMPANY ")
            .Append(" WHERE ")
            .Append(" COMP_FIN_YEAR_START >= #" & Format(CDate(Main_MDI_Frm.FINE_YEAR_START.Text), "dd/MM/yyyy") & "# ")
            .Append(" AND Comp_Fin_Year_End <= #" & Format(CDate(Main_MDI_Frm.FINE_YEAR_END.Text), "dd/MM/yyyy") & "# ")

        End With
        RS = _strQuery.ToString
        SQLDBMENU_CONNECT()
        _Tmptbl = DefaltSoftTable.Copy
        Return _Tmptbl
    End Function

    Public Function _GetAllCompanyOutstanding(ByVal _GropName As String)


        Dim _Tmptbl As New DataTable

        If CurntYearAllCompTbl.Rows.Count > 0 Then
            CurntYearAllCompTbl.Clear()
        End If

        CurntYearAllCompTbl = _GetCurrentYearCompanyTable()

        If _TmpDataTable.Rows.Count > 0 Then
            _TmpDataTable.Clear()
        End If


        Dim _FilterGroupCode As String = ""

        If _GropName <> "ALL" Then
            sqL = _GetDebtorsCreditrGrup(Txt_EntryType.Text)
            obj_Party_Selection.Multy_List_Load_Data()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                _FilterGroupCode = " AND E.GROUPNAME IN " & MULTY_SELECTION_COLOUM_1_DATA
            Else
                Exit Function
            End If
        End If


        For Each dr As DataRow In CurntYearAllCompTbl.Select
            Dim DataBaseName = dr("Data_Folder_Name").ToString
            Dim Comp_Print_Name = dr("Comp_Print_Name").ToString

            ' Step 1: Connect to master to check if database exists
            Dim checkConnStr = Main_MDI_Frm.TextBox1.Text
            Using checkConn As New SqlConnection(checkConnStr)
                Try
                    checkConn.Open()
                    Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = @DBName", checkConn)
                    checkCmd.Parameters.AddWithValue("@DBName", DataBaseName)
                    Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If exists = 0 Then
                        ' Database not found, skip to next
                        Continue For
                    End If
                Catch ex As Exception
                    ' Connection to master failed, skip this row
                    Continue For
                End Try
            End Using


            Dim _YearConn = _GetServerConnection(DataBaseName)
            NewYearConnection = New SqlConnection(_YearConn)
            Dim _BackYrTbl As New DataTable
            sqL = _GetQuery(Comp_Print_Name, DataBaseName, _FilterGroupCode)
            sql_Data_Select_NewYearConnection()
            _BackYrTbl = DefaltSoftTable.Copy

            If _TmpDataTable.Rows.Count = 0 Then
                _TmpDataTable = _BackYrTbl.Clone()
            End If

            If _BackYrTbl.Rows.Count > 0 Then
                For Each dr1 As DataRow In _BackYrTbl.Select
                    _TmpDataTable.ImportRow(dr1)
                Next
            End If
        Next

        FirstStage.Columns.Clear()
        If _TmpDataTable.Rows.Count = 0 Then
            MsgBox("Record Not Found", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Function
        End If




        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" * ")
            .Append(" ,format(Folodate,'dd/MM/yyyy') as f_Folodate ")
            .Append(" ,format(PaymentRemarkDate,'dd/MM/yyyy') as f_PaymentRemarkDate ")
            .Append(" from  PaymentFolo ")
        End With
        sqL = _strQuery.ToString
        PaymentFolo_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            For Each dr As DataRow In _TmpDataTable.Select
                For Each dr1 As DataRow In DefaltSoftTable.Select("Database='" & dr("DataBaseName").ToString & "'  and ACCOUNTCODE='" & dr("ACCOUNTCODE").ToString & "'  and BOOKVNO='" & dr("BOOKVNO").ToString & "'  ")
                    dr("FoloDate") = dr1("f_Folodate").ToString
                    dr("PymtRem") = dr1("PaymentRemark").ToString
                    dr("PymtDate") = dr1("f_PaymentRemarkDate").ToString
                    dr("GRRemark") = dr1("GrRemark").ToString
                    dr("OthRemark") = dr1("OtherRemark").ToString
                Next
            Next
        End If

        _Tmptbl = _TmpDataTable.Copy

        Return _Tmptbl

    End Function
    Private Sub Btn_View_Click(sender As Object, e As EventArgs) Handles Btn_View.Click

        GridControl2.Visible = False

        Dim _Tmptbl As New DataTable
        _Tmptbl = _GetAllCompanyOutstanding(Txt_GroupSelection.Text)

        Display_Stage_No = 0


        If Txt_ViewType.Text = "SUMMARY" Then
            If Txt_DataShowBy.Text = "PARTY" Then
                PartyWise_OutstandingFirstStage(_TmpDataTable, GridControl1, FirstStage)
            Else
                _OutstandingFirstStage(_TmpDataTable, GridControl1, FirstStage)
            End If
        Else
            _OutstandingQuery(_TmpDataTable, GridControl1, FirstStage)
        End If
    End Sub

#Region "Got Focus/Lost Focus"
    'Private Sub Btn_View_FocusChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_View.GotFocus, Btn_View.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub
    'Private Sub Btn_AddRemark_FocusChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_AddRemark.GotFocus, Btn_AddRemark.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub
    'Private Sub Btn_LayoutLoad_FocusChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_LayoutLoad.GotFocus, Btn_LayoutLoad.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub
    'Private Sub BtnLayOutSave_FocusChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BtnLayOutSave.GotFocus, BtnLayOutSave.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub
    'Private Sub Btn_Exl_Focus_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Exl.GotFocus, Btn_Exl.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub
    'Private Sub Btn_Print_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles Btn_Print.GotFocus, Btn_Print.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub
    'Private Sub BtnWhatsapp_Changed(ByVal sender As Object, ByVal e As EventArgs) Handles BtnWhatsapp.GotFocus, BtnWhatsapp.LostFocus
    '    Dim ctrl As Control = DirectCast(sender, Control)
    '    Color_Change(sender, If(ctrl.Focused, "GOT_FOCUS", "LOST_FOCUS"), Me, Color.Coral, Me.BackColor)
    'End Sub

#End Region



#Region "DataShow Agent Wise"
    Private Sub _OutstandingFirstStage(ByVal _TmpTable As DataTable, ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            Display_Stage_No = 1

            Dim query_1 = From row In _TmpTable
                          Order By row.Field(Of String)("AgentName")
                          Group row By
                                               AgentName = row.Field(Of String)("AgentName"),
                                               AgentCity = row.Field(Of String)("AgentCity"),
                                               DrCr = "",
                                               TickMark = "False",
                                               AgentMob = row.Field(Of String)("AgentMob")
                                               Into AgentNameGroup = Group
                          Select New With
                                               {
                                               Key TickMark, AgentName, AgentCity, AgentMob,
                                              .Balance = AgentNameGroup.Sum(Function(r) CDec(r("Balance"))),
                                               DrCr
                                               }
            Dim _FirstStageTbl = LINQToDataTable(query_1)

            gridView.Columns.Clear()

            Dim dataView As New DataView(_FirstStageTbl)
            dataView.Sort = "AgentName ASC"
            Dim dataTable As DataTable = dataView.ToTable()
            _FirstStageTbl = dataView.ToTable()

            For Each dr As DataRow In _FirstStageTbl.Select

                If dr("Balance") < 0 Then
                    dr("DrCr") = "Cr"
                Else
                    dr("DrCr") = "Dr"
                End If

                dr("Balance") = Format(dr("Balance"), "0.00")
                If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
            Next

            gridControl.DataSource = _FirstStageTbl.Copy

            Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl1.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            repositoryCheckEdit1.ValueChecked = "True"
            repositoryCheckEdit1.ValueUnchecked = "False"
            gridView.Columns("TickMark").ColumnEdit = repositoryCheckEdit1

            _DevGridColumSizeAutoAdjest(GridControl1, gridView)

            gridView.Columns("Balance").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            gridView.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
            gridView.Columns("AgentName").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "AgentName", "{0}"))

            gridView.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gridView.Columns("Balance").DisplayFormat.FormatString = "n2"
            'gridView.Columns("AGENTCODE").Visible = False


            gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Balance", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Balance")})
            Dim summaryItem = gridView.Columns("Balance").SummaryItem
            summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            summaryItem.DisplayFormat = "{0:n2}"


            gridView.ExpandAllGroups()
            gridView.GroupRowHeight = 30

            gridControl.Visible = True

            'gridView.Columns("TickMark").Width = 30

            'gridView.Columns("AgentName").Width = 500
            'gridView.Columns("AgentCity").Width = 250
            'gridView.Columns("AgentMob").Width = 200
            'gridView.Columns("Balance").Width = 200
            'gridView.Columns("DrCr").Width = 100
            gridView.Focus()
            FirstStage.FocusedRowHandle = _StgIRowNo
            gridView.MakeRowVisible(_StgIRowNo)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _Zooming_stage_II_Tbl(ByVal _AGENTCODE As String, ByVal _TmpTable As DataTable, ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)

        Try
            Display_Stage_No = 2
            Dim query_1 = From row In _TmpTable.Select("AgentName = '" & _AGENTCODE & "'")
                          Order By row.Field(Of String)("AgentName")
                          Group row By
                                               AgentName = row.Field(Of String)("AgentName"),
                                               AgentCity = row.Field(Of String)("AgentCity"),
                                               AgentMob = row.Field(Of String)("AgentMob"),
                                               PartyName = row.Field(Of String)("PartyName"),
                                               PartyMob = row.Field(Of String)("PartyMob"),
                                               PartyCity = row.Field(Of String)("PartyCity"),
                                               DrCr = "",
                                               TickMark = "False"
            Into AgentNameGroup = Group
                          Select New With
                                               {
                                               Key TickMark, PartyName, PartyCity, PartyMob, AgentName, AgentMob, AgentCity,
                                              .Balance = AgentNameGroup.Sum(Function(r) CDec(r("Balance"))),
                                               DrCr
                                               }
            Dim _FirstStageTbl = LINQToDataTable(query_1)

            gridView.Columns.Clear()

            Dim dataView As New DataView(_FirstStageTbl)
            dataView.Sort = "AgentName,PartyName ASC"
            Dim dataTable As DataTable = dataView.ToTable()
            _FirstStageTbl = dataView.ToTable()


            For Each dr As DataRow In _FirstStageTbl.Select
                If dr("Balance") < 0 Then
                    dr("DrCr") = "Cr"
                Else
                    dr("DrCr") = "Dr"
                End If
                dr("Balance") = Format(dr("Balance"), "0.00")
                If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
            Next

            gridControl.DataSource = _FirstStageTbl.Copy
            gridView.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
            gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
            gridView.RowHeight = 25

            Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl1.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            repositoryCheckEdit1.ValueChecked = "True"
            repositoryCheckEdit1.ValueUnchecked = "False"
            gridView.Columns("TickMark").ColumnEdit = repositoryCheckEdit1

            gridView.Columns("Balance").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            gridView.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
            gridView.Columns("AgentName").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "AgentName", "{0}"))

            gridView.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gridView.Columns("Balance").DisplayFormat.FormatString = "n2"

            'gridView.Columns("AGENTCODE").Visible = False
            'gridView.Columns("ACCOUNTCODE").Visible = False
            gridView.Columns("AgentMob").Visible = False

            gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Balance", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Balance")})
            Dim summaryItem = gridView.Columns("Balance").SummaryItem
            summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            summaryItem.DisplayFormat = "{0:n2}"

            gridView.ExpandAllGroups()
            gridView.GroupRowHeight = 30

            gridControl.Visible = True

            _DevGridColumSizeAutoAdjest(gridControl, gridView)

            'gridView.Columns("AgentName").Width = 200
            'gridView.Columns("AgentCity").Width = 150

            'gridView.Columns("PartyName").Width = 300
            'gridView.Columns("PartyCity").Width = 200
            'gridView.Columns("PartyMob").Width = 200
            'gridView.Columns("Balance").Width = 150
            'gridView.Columns("DrCr").Width = 100

            'gridView.BestFitColumns()
            'gridView.Columns("TickMark").Width = 30
            gridView.Focus()
            gridView.FocusedRowHandle = _StgIIRowNo
            gridView.MakeRowVisible(_StgIIRowNo)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _Zooming_stage_III_Tbl(ByVal _AGENTCODE As String, ByVal _ACCOUNTCODE As String, ByVal _TmpTable As DataTable, ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)

        Try
            Display_Stage_No = 3
            Dim _FirstStageTbl As DataTable
            _FirstStageTbl = _TmpTable.Clone

            For Each dr As DataRow In _TmpTable.Select("AgentName = '" & _AGENTCODE & "' AND PartyName = '" & _ACCOUNTCODE & "'")
                _FirstStageTbl.ImportRow(dr)
            Next
            _OutstandingQuery(_FirstStageTbl, GridControl1, FirstStage)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region


#Region "DataShow Party Wise"
    Private Sub PartyWise_OutstandingFirstStage(ByVal _TmpTable As DataTable, ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            Display_Stage_No = 1

            Dim query_1 = From row In _TmpTable
                          Order By row.Field(Of String)("PartyName")
                          Group row By
                                               PartyName = row.Field(Of String)("PartyName"),
                                               PartyCity = row.Field(Of String)("PartyCity"),
                                               DrCr = "",
                                               TickMark = "False",
                                               PartyMob = row.Field(Of String)("PartyMob")
                                               Into PartyNameGroup = Group
                          Select New With
                                               {
                                               Key TickMark, PartyName, PartyCity, PartyMob,
                                              .Balance = PartyNameGroup.Sum(Function(r) CDec(r("Balance"))),
                                               DrCr
                                               }
            Dim _FirstStageTbl = LINQToDataTable(query_1)

            gridView.Columns.Clear()

            Dim dataView As New DataView(_FirstStageTbl)
            dataView.Sort = "PartyName ASC"
            Dim dataTable As DataTable = dataView.ToTable()
            _FirstStageTbl = dataView.ToTable()

            For Each dr As DataRow In _FirstStageTbl.Select

                If dr("Balance") < 0 Then
                    dr("DrCr") = "Cr"
                Else
                    dr("DrCr") = "Dr"
                End If

                dr("Balance") = Format(dr("Balance"), "0.00")
                If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
            Next

            gridControl.DataSource = _FirstStageTbl.Copy

            Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl1.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            repositoryCheckEdit1.ValueChecked = "True"
            repositoryCheckEdit1.ValueUnchecked = "False"
            gridView.Columns("TickMark").ColumnEdit = repositoryCheckEdit1

            _DevGridColumSizeAutoAdjest(GridControl1, gridView)

            gridView.Columns("Balance").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            gridView.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
            gridView.Columns("PartyName").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PartyName", "{0}"))

            gridView.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gridView.Columns("Balance").DisplayFormat.FormatString = "n2"
            'gridView.Columns("AGENTCODE").Visible = False


            gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Balance", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Balance")})
            Dim summaryItem = gridView.Columns("Balance").SummaryItem
            summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            summaryItem.DisplayFormat = "{0:n2}"


            gridView.ExpandAllGroups()
            gridView.GroupRowHeight = 30

            gridControl.Visible = True

            'gridView.Columns("TickMark").Width = 30

            'gridView.Columns("AgentName").Width = 500
            'gridView.Columns("AgentCity").Width = 250
            'gridView.Columns("AgentMob").Width = 200
            'gridView.Columns("Balance").Width = 200
            'gridView.Columns("DrCr").Width = 100

            gridView.Focus()
            gridView.FocusedRowHandle = _StgIRowNo
            gridView.MakeRowVisible(_StgIRowNo)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub PartyWise_Zooming_stage_II_Tbl(ByVal _ACCOUNTCODE As String, ByVal _TmpTable As DataTable, ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)

        Try
            Display_Stage_No = 2
            Dim _FirstStageTbl As DataTable
            _FirstStageTbl = _TmpTable.Clone

            For Each dr As DataRow In _TmpTable.Select("PartyName = '" & _ACCOUNTCODE & "'")
                _FirstStageTbl.ImportRow(dr)
            Next
            _OutstandingQuery(_FirstStageTbl, GridControl1, FirstStage)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region

    Private Function _GetQuery(ByVal Comp_Print_Name As String, ByVal DataBaseName As String, ByVal _FilterGroupCode As String)

        Dim CurDate As String = CDate(Date.Now).ToString("yyyy-MM-dd")
        If txt_High_Days.Text.Trim = "" Then txt_High_Days.Text = 0
        Dim _Query As String = ""

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" 'False' as TickMark, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" B.AGENTCODE, ")
            .Append(" A.BOOKVNO,")
            .Append(" '" & DataBaseName & "' as DataBaseName,")

            .Append(" B.ACCOUNTNAME AS PartyName,")
            .Append(" B.MOBILE AS PartyMob,")
            .Append(" C.ACCOUNTNAME AS AgentName,")
            .Append(" C.MOBILE AS AgentMob,")
            .Append(" A.BILLNO AS BillNo, ")
            .Append(" A.E_BILLDATE AS BillDate, ")

            .Append(" A.DUEDAYS AS [Days], ")
            .Append(" A.DEBITAMT AS [Debit], ")
            .Append(" A.CREDITAMT AS [Credit], ")
            .Append(" A.RUNBALANCEAMT AS [Balance], ")
            .Append(" SUM(a.RBALANCE) OVER(partition by B.ACCOUNTNAME ORDER BY B.ACCOUNTNAME,C.ACCOUNTNAME,A.BILLDATE,A.BILLNO  ROWS  UNBOUNDED PRECEDING)  [RunBalance], ")
            .Append(" CASE WHEN (SUM(a.RBALANCE) OVER(partition by B.ACCOUNTNAME ORDER BY B.ACCOUNTNAME,C.ACCOUNTNAME,A.BILLDATE,A.BILLNO  ROWS UNBOUNDED PRECEDING )>0) THEN 'Dr' ELSE 'Cr' END  AS [DrCr], ")
            '.Append(" M.OP5 AS RemarkDate, ")
            '.Append(" M.OP6 AS [Remark-1], ")
            '.Append(" M.OP3 AS [Remark-2], ")
            '.Append(" M.OP4 AS [Remark-3], ")


            .Append(" '' AS FoloDate, ")
            .Append(" '' AS PymtRem, ")
            .Append(" '' AS PymtDate, ")
            .Append(" '' AS GRRemark, ")
            .Append(" '' AS OthRemark, ")
            .Append(" '" & Comp_Print_Name & "' as ComAlies,")
            .Append(" E.GroupName,")
            .Append(" N.cityname AS PartyCity,")
            .Append(" O.cityname AS AgentCity,")
            .Append(" '' AS [D/C], ")
            .Append(" A.F_BillDate ")
            .Append(" ,isnull(B.BILLLIMIT,0) as SideDays ")


            .Append(" FROM ")
            .Append(" (")
            .Append(" SELECT A.ACCOUNTCODE,A.BILLNO, ")
            .Append(" A.BILLDATE as E_BILLDATE,")
            .Append(" A.BILLDATE as BILLDATE,")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') as F_BILLDATE,")
            .Append(" SUM(A.DEBITAMT) AS DEBITAMT, ")
            .Append(" SUM(A.CREDITAMT) AS CREDITAMT, ")
            '.Append(" ABS(SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS RUNBALANCEAMT, ")
            .Append(" (SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS RUNBALANCEAMT, ")
            '.Append(" ABS(SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS RBALANCE, ")
            .Append(" (SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS RBALANCE, ")
            .Append(" CASE WHEN (SUM(A.DEBITAMT)>SUM(A.CREDITAMT)) THEN 'Dr' ELSE 'Cr' END AS RUNDRCR,  ")
            .Append(" (0) AS BALANCEAMT,SPACE(2) AS DRCR, ")
            .Append(" DATEDIFF(DAY,A.BILLDATE,'" & CurDate & "') AS DUEDAYS , ")
            .Append(" A.BOOKVNO,LEFT(A.BOOKVNO,5) AS BOOKTRTYPE ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT A.ACCOUNTCODE,A.BILLNO,A.BILLDATE,A.DEBITAMT, ")
            .Append(" A.CREDITAMT,A.BOOKVNO,A.FINREMARK FROM TRNOUTSTANDING A ")
            .Append(" WHERE 1=1")
            '.Append(_AccountFilter)
            .Append(" AND (A.SUNCODE IS NULL OR A.SUNCODE='') ")
            .Append(" UNION ALL ")
            .Append(" SELECT A.ACCOUNTCODE,A.BILLNO,A.BILLDATE,A.DEBITAMT, ")
            .Append(" A.CREDITAMT,A.BOOKVNO,A.FinRemark FROM TRNOUTSTANDING A ")
            .Append(" WHERE 1=1")
            '.Append(_AccountFilter)
            .Append(" AND A.SUNCODE<>'0001-000000046' AND A.SUNCODE<>'' ")
            .Append(" ) AS A ")
            .Append(" GROUP BY A.ACCOUNTCODE,A.BOOKVNO, A.BILLNO, A.BILLDATE ")
            .Append(" HAVING ROUND((SUM(A.DEBITAMT)-SUM(A.CREDITAMT)),0)<>0 ")
            .Append(" ) AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE")
            .Append(" LEFT JOIN MstMasterAccount AS C ON B.AGENTCODE=C.ACCOUNTCODE")
            .Append(" Left Join MstFinGroup E ON B.GROUPCODE=E.GROUPCODE")
            .Append(" LEFT JOIN TRNINVOICEHEADER AS L ON A.BOOKVNO=L.BOOKVNO ")
            '.Append(" LEFT JOIN TrnOutstanding AS M ON ( A.BOOKVNO=M.BOOKVNO ")
            '.Append(" AND A.ACCOUNTCODE=M.ACCOUNTCODE )")
            .Append(" LEFT JOIN MstCity AS N ON B.CITYCODE=N.citycode ")
            .Append(" LEFT JOIN MstCity AS O ON C.CITYCODE=O.citycode ")

            .Append(" WHERE  1=1 ")

            .Append(_FilterGroupCode)

            .Append("AND B.BILLBYBILL ='BILL BY BILL'")

            If Txt_SideDayCarry.Text = "MANUAL" Then
                .Append(" AND A.DUEDAYS>=" & Val(txt_High_Days.Text))
            ElseIf Txt_SideDayCarry.Text = "MASTER" Then
                .Append((" AND (A.DUEDAYS>= ISNULL(B.CRDAYS,0)) "))
            End If

            If Txt_EntryType.Text = "DEBTORS" Then
                .Append(" AND (LEFT(E.GROUPNAME,14)='SUNDRY DEBTORS') ")
            ElseIf Txt_EntryType.Text = "CREDITORS" Then
                .Append(" AND (LEFT(E.GROUPNAME,16)='SUNDRY CREDITORS') ")
            End If
            .Append(" ORDER BY  B.ACCOUNTNAME,C.ACCOUNTNAME,A.BILLDATE, A.BILLNO")
        End With
        _Query = _strQuery.ToString()
        Return _Query
    End Function

    Private Sub _OutstandingQuery(ByVal _TmpTable As DataTable, ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)

        Try

            gridView.FindFilterText = ""
            gridView.Columns.Clear()
            If _TmpTable.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else


                Dim dataView As New DataView(_TmpTable)
                dataView.Sort = "PartyName,BillDate,BillNo ASC"
                Dim dataTable As DataTable = dataView.ToTable()
                _TmpTable = dataView.ToTable()


                For Each dr As DataRow In _TmpTable.Select
                    Dim Balance = Format(dr("Debit"), "0.00")
                    dr("Debit") = Balance
                    Balance = Format(dr("Credit"), "0.00")
                    dr("Credit") = Balance
                    Balance = Format(dr("Balance"), "0.00")
                    dr("Balance") = Balance
                    If Val(dr("Debit")) = 0 Then dr("Debit") = DBNull.Value
                    If Val(dr("Credit")) = 0 Then dr("Credit") = DBNull.Value
                    If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
                Next

                gridControl.DataSource = _TmpTable.Copy
                gridView.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
                gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)


                Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl1.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
                repositoryCheckEdit1.ValueChecked = "True"
                repositoryCheckEdit1.ValueUnchecked = "False"
                gridView.Columns("TickMark").ColumnEdit = repositoryCheckEdit1

                gridView.RowHeight = 25


                For Each Col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                    Col.AppearanceHeader.BackColor = Color.Khaki
                    Col.AppearanceHeader.BackColor2 = Color.Khaki

                    Col.AppearanceHeader.Options.UseForeColor = True
                    Col.AppearanceHeader.Options.UseBackColor = True
                Next


                gridView.Columns("Debit").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                gridView.Columns("Credit").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                gridView.Columns("Balance").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far


                gridView.Columns("Debit").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0}"))
                gridView.Columns("Credit").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0}"))
                gridView.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
                gridView.Columns("PartyCity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PartyCity", "{0}"))


                gridView.Columns("TickMark").Visible = False
                gridView.Columns("Debit").Visible = False
                gridView.Columns("Credit").Visible = False

                gridView.Columns("D/C").Visible = False
                gridView.Columns("ACCOUNTCODE").Visible = False
                gridView.Columns("AGENTCODE").Visible = False
                gridView.Columns("BOOKVNO").Visible = False
                gridView.Columns("DataBaseName").Visible = False
                gridView.Columns("RunBalance").Visible = False
                gridView.Columns("AgentCity").Visible = False
                'gridView.Columns("AgentMob").Visible = False
                'gridView.Columns("Dr/Cr").Visible = False


                gridView.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                gridView.Columns("Balance").DisplayFormat.FormatString = "n2"

                gridView.Columns("Debit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                gridView.Columns("Debit").DisplayFormat.FormatString = "n2"

                gridView.Columns("Credit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                gridView.Columns("Credit").DisplayFormat.FormatString = "n2"


                AlignGroupSummaryInGroupRow(gridControl, gridView)

                gridView.ExpandAllGroups()
                gridView.GroupRowHeight = 30

                gridControl.Visible = True
                gridView.BestFitColumns()
                gridView.Columns("TickMark").Width = 30
                gridView.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Debit", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Debit")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Credit", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Credit")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Balance", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Balance")})
        'gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Net Balance", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Net Balance")})

        Dim summaryItem = gridView.Columns("Balance").SummaryItem
        summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        summaryItem.DisplayFormat = "{0:n2}" ' "n2" = Number with comma and 2 decimal

        summaryItem = gridView.Columns("Credit").SummaryItem
        summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        summaryItem.DisplayFormat = "{0:n2}" ' "n2" = Number with comma and 2 decimal

        summaryItem = gridView.Columns("Debit").SummaryItem
        summaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        summaryItem.DisplayFormat = "{0:n2}" ' "n2" = Number with comma and 2 decimal




    End Sub
    Private Sub _RemarkPanelDisplay()
        Txt_Remark_1.Text = ""
        Txt_Remark_2.Text = ""
        Txt_Remark_3.Text = ""
        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        PnlRemark.Visible = True
        PnlRemark.BringToFront()
        txtRemarkDate.Focus()
        txtRemarkDate.SelectAll()
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Txt_ViewType.Text = "SUMMARY" Then
                If Txt_DataShowBy.Text = "PARTY" Then
                    Dim AGENTCODE As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PartyName").ToString()
                    If Display_Stage_No = 1 Or Display_Stage_No = 0 Then
                        LEDGER_FORM_DISPALY_BY = ""
                    ElseIf Display_Stage_No = 2 Then
                        PartyWise_OutstandingFirstStage(_TmpDataTable, GridControl1, FirstStage)
                    ElseIf Display_Stage_No = 3 Then

                    End If

                Else
                    Dim AGENTCODE As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "AgentName").ToString()
                    If Display_Stage_No = 1 Or Display_Stage_No = 0 Then
                        'Close()
                        'Dispose(True)
                        LEDGER_FORM_DISPALY_BY = ""

                    ElseIf Display_Stage_No = 2 Then

                        _OutstandingFirstStage(_TmpDataTable, GridControl1, FirstStage)
                    ElseIf Display_Stage_No = 3 Then

                        _Zooming_stage_II_Tbl(AGENTCODE, _TmpDataTable, GridControl1, FirstStage)
                    End If
                End If

            End If

        ElseIf e.KeyCode = Keys.F2 Then
            If Txt_DataShowBy.Text = "PARTY" AndAlso Txt_ViewType.Text = "SUMMARY" AndAlso Display_Stage_No = 2 Then
                _RemarkPanelDisplay()
            ElseIf Txt_DataShowBy.Text = "AGENT" AndAlso Txt_ViewType.Text = "SUMMARY" AndAlso Display_Stage_No = 3 Then
                _RemarkPanelDisplay()

            ElseIf Txt_ViewType.Text = "DETAIL" Then
                _RemarkPanelDisplay()
            End If

        ElseIf e.KeyCode = Keys.Enter Then
            _EnterKeyGridLoad()
        ElseIf e.KeyCode = Keys.Space Then
            If FirstStage.GetFocusedRowCellValue("TickMark") = "" Then
                FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "TickMark", "True")
            ElseIf FirstStage.GetFocusedRowCellValue("TickMark") = "True" Then
                FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "TickMark", "False")
            ElseIf FirstStage.GetFocusedRowCellValue("TickMark") = "False" Then
                FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "TickMark", "True")
            End If
        ElseIf e.KeyCode = Keys.F11 Then
            For i As Int64 = 0 To FirstStage.RowCount - 1
                If FirstStage.GetRowCellValue(i, "TickMark").ToString = True Then
                    FirstStage.SetRowCellValue(i, "TickMark", "False")
                Else
                    FirstStage.SetRowCellValue(i, "TickMark", "True")
                End If
            Next
        ElseIf e.KeyCode = Keys.F12 Then
            FirstStage.ActiveFilter.Clear()
        End If

    End Sub

    Private Sub _EnterKeyGridLoad()
        If Txt_DataShowBy.Text = "PARTY" AndAlso Txt_ViewType.Text = "SUMMARY" AndAlso Display_Stage_No = 2 Then
            _ViewRemarkGrid()
        ElseIf Txt_DataShowBy.Text = "AGENT" AndAlso Txt_ViewType.Text = "SUMMARY" AndAlso Display_Stage_No = 3 Then
            _ViewRemarkGrid()
        ElseIf Txt_ViewType.Text = "DETAIL" Then
            _ViewRemarkGrid()
        End If


        If Txt_ViewType.Text = "SUMMARY" Then
            If Txt_DataShowBy.Text = "PARTY" Then
                Dim AGENTCODE As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PartyName").ToString()
                If Display_Stage_No = 1 Then
                    _StgIRowNo = FirstStage.FocusedRowHandle
                    _StgIIRowNo = 1
                    _StgThidRowNo = 1
                    _StgFourRowNo = 1
                    PartyWise_Zooming_stage_II_Tbl(AGENTCODE, _TmpDataTable, GridControl1, FirstStage)
                End If
            Else
                Dim AGENTCODE As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "AgentName").ToString()
                If Display_Stage_No = 1 Then
                    _StgIRowNo = FirstStage.FocusedRowHandle
                    _StgIIRowNo = 1
                    _StgThidRowNo = 1
                    _StgFourRowNo = 1
                    _Zooming_stage_II_Tbl(AGENTCODE, _TmpDataTable, GridControl1, FirstStage)
                ElseIf Display_Stage_No = 2 Then
                    Dim ACCOUNTCODE As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PartyName").ToString()
                    _StgIIRowNo = FirstStage.FocusedRowHandle
                    _Zooming_stage_III_Tbl(AGENTCODE, ACCOUNTCODE, _TmpDataTable, GridControl1, FirstStage)
                End If

            End If
        End If

        Dim _ActivatedColName = FirstStage.FocusedColumn.FieldName


        'If _ActivatedColName = "FoloDate" Or _ActivatedColName = "PymtRem" Or _ActivatedColName = "PymtDate" Or _ActivatedColName = "GRRemark" Or _ActivatedColName = "OthRemark" Then

    End Sub
    Private Sub _ViewRemarkGrid()

        Dim DataBaseName = FirstStage.GetFocusedRowCellValue("DataBaseName").ToString
        Dim BOOKVNO As String = FirstStage.GetFocusedRowCellValue("BOOKVNO").ToString
        Dim ACCOUNTCODE As String = FirstStage.GetFocusedRowCellValue("ACCOUNTCODE").ToString
        _GetRemak(DataBaseName, ACCOUNTCODE, BOOKVNO)
    End Sub

    Private Sub _GetRemak(ByVal Database As String, ByVal Accountcode As String, ByVal bookvno As String)


        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" id ")
            .Append(" ,CompAlies ")
            .Append(" ,BillNo ")
            .Append(" ,BillDate ")
            .Append(" ,Amount ")
            .Append(" ,format(Folodate,'dd/MM/yyyy') as FirstFoloDate ")
            .Append(" ,format(PaymentRemarkDate,'dd/MM/yyyy') as PaymentRemarkDate ")
            .Append(" ,PaymentRemark ")
            .Append(" ,GrRemark ")
            .Append(" ,OtherRemark ")
            .Append(" from  PaymentFolo ")
            .Append(" WHERE 1=1 ")
            .Append(" AND Database='" & Database & "' ")
            .Append(" AND Accountcode='" & Accountcode & "' ")
            .Append(" AND bookvno='" & bookvno & "' ")
        End With
        sqL = _strQuery.ToString
        PaymentFolo_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then

            GridView1.Columns.Clear()
            GridControl2.DataSource = DefaltSoftTable.Copy

            _DevGridColumSizeAutoAdjestWhiotTickmarck(GridControl2, GridView1)

            GridView1.Columns("id").Visible = False


            GridControl2.Visible = True
            GridView1.Focus()

        End If
    End Sub

    Private Sub BtnRemarkClose_Click(sender As Object, e As EventArgs) Handles BtnRemarkClose.Click
        PnlRemark.Visible = False
    End Sub
    Private Sub BtnRemarkSave_Click(sender As Object, e As EventArgs) Handles BtnRemarkSave.Click



        If FirstStage.GetFocusedRowCellValue("FoloDate").ToString = "" Then
            FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "FoloDate", CDate(Date.Now).ToString("dd/MM/yyyy"))
        End If


        If txtRemarkDate.Text.Trim = "" Then txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")


        FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "PymtRem", Txt_Remark_1.Text)
        FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "PymtDate", txtRemarkDate.Text)
        FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "GRRemark", Txt_Remark_2.Text)
        FirstStage.SetRowCellValue(FirstStage.FocusedRowHandle, "OthRemark", Txt_Remark_3.Text)


        Dim DataBaseName = FirstStage.GetFocusedRowCellValue("DataBaseName").ToString
        Dim BOOKVNO As String = FirstStage.GetFocusedRowCellValue("BOOKVNO").ToString
        Dim ACCOUNTCODE As String = FirstStage.GetFocusedRowCellValue("ACCOUNTCODE").ToString
        Dim ComAlies As String = FirstStage.GetFocusedRowCellValue("ComAlies").ToString
        Dim BillNo As String = FirstStage.GetFocusedRowCellValue("BillNo").ToString
        Dim BillDate As String = FirstStage.GetFocusedRowCellValue("BillDate").ToString
        Dim FoloDate As String = FirstStage.GetFocusedRowCellValue("FoloDate").ToString
        Dim PymtRem As String = FirstStage.GetFocusedRowCellValue("PymtRem").ToString
        Dim PymtDate As String = FirstStage.GetFocusedRowCellValue("PymtDate").ToString
        Dim GRRemark As String = FirstStage.GetFocusedRowCellValue("GRRemark").ToString
        Dim OthRemark As String = FirstStage.GetFocusedRowCellValue("OthRemark").ToString
        Dim Balance As Double = FirstStage.GetFocusedRowCellValue("Balance").ToString
        Dim PartyName As String = FirstStage.GetFocusedRowCellValue("PartyName").ToString
        Dim PartyMob As String = FirstStage.GetFocusedRowCellValue("PartyMob").ToString
        Dim AgentName As String = FirstStage.GetFocusedRowCellValue("AgentName").ToString
        Dim AgentMob As String = FirstStage.GetFocusedRowCellValue("AgentMob").ToString






        'Dim _YearConn = _GetServerConnection(DataBaseName)
        'NewYearConnection = New SqlConnection(_YearConn)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" INSERT INTO PaymentFolo ( ")
            .Append(" [Database], bookvno, Accountcode, CompAlies, BillNo, BillDate, Amount, Folodate, PaymentRemark, PaymentRemarkDate, GrRemark, OtherRemark ")
            .Append(" ,PartyName ")
            .Append(" ,PartyMobNo ")
            .Append(" ,AgentName ")
            .Append(" ,AgentMobileNo ")
            .Append(" ) VALUES ( ")
            .Append(" '" & DataBaseName & "', ")
            .Append(" '" & BOOKVNO & "', ")
            .Append(" '" & ACCOUNTCODE & "', ")
            .Append(" '" & ComAlies & "', ")
            .Append(" '" & BillNo & "', ")
            .Append(" '" & Format(CDate(BillDate), "yyyy-MM-dd") & "', ")
            .Append(" '" & Val(Balance) & "', ")
            .Append(" '" & Format(CDate(FoloDate), "yyyy-MM-dd") & "', ")
            .Append(" '" & PymtRem & "', ")
            .Append(" '" & Format(CDate(PymtDate), "yyyy-MM-dd") & "', ")
            .Append(" '" & GRRemark & "', ")
            .Append(" '" & OthRemark & "' ")
            .Append(" ,'" & PartyName & "' ")
            .Append(" ,'" & PartyMob & "' ")
            .Append(" ,'" & AgentName & "' ")
            .Append(" ,'" & AgentMob & "' ")
            .Append(" ) ")

        End With
        sqL = _strQuery.ToString
        PaymentFolo_QuerySaveUpdateDelete()


        MsgBox("Remark Save Success", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        PnlRemark.Visible = False
    End Sub
    Private Sub PnlRemark_Validated(sender As Object, e As EventArgs) Handles PnlRemark.Validated
        PnlRemark.Visible = False
        FirstStage.Focus()
    End Sub

    Private Sub CreateDropDownMenu()
        Dim item1 As New DevExpress.XtraBars.BarButtonItem(BarManager1, "Only Agent")
        Dim item2 As New DevExpress.XtraBars.BarButtonItem(BarManager1, "Only Party")
        Dim item3 As New DevExpress.XtraBars.BarButtonItem(BarManager1, "Agent+Party")

        item1.Appearance.Options.UseFont = True
        item1.Appearance.Font = New Font("Verdana", 10, FontStyle.Bold)

        item2.Appearance.Options.UseFont = True
        item2.Appearance.Font = New Font("Verdana", 10, FontStyle.Bold)


        item3.Appearance.Options.UseFont = True
        item3.Appearance.Font = New Font("Verdana", 10, FontStyle.Bold)




        AddHandler item1.ItemClick, AddressOf OnlyAgent_Click
        AddHandler item2.ItemClick, AddressOf OnlyParty_Click
        AddHandler item3.ItemClick, AddressOf AgentParty_Click

        PopupMenu1.AddItem(item1)
        PopupMenu1.AddItem(item2)
        PopupMenu1.AddItem(item3)
    End Sub
    Private Sub BtnWhatsapp_Click(sender As Object, e As EventArgs) Handles BtnWhatsapp.Click
        PopupMenu1.ShowPopup(BtnWhatsapp.PointToScreen(New Point(0, BtnWhatsapp.Height)))
    End Sub

    Private Sub OnlyAgent_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        sendWhatsapp("OnlyAgent")
    End Sub

    Private Sub OnlyParty_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        sendWhatsapp("OnlyParty")
    End Sub

    Private Sub AgentParty_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        sendWhatsapp("Party+Agent")
    End Sub

    Private Sub sendWhatsapp(ByVal _OnlyAgent As String)
        Try
            If MsgBox("Do You Want Send WhatsApp", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "WhatsApp Sending ?") = MsgBoxResult.Yes Then
                Wait_Window_Show(Me, "WhatsApp Sending Please Wait...")

                Dim res As Boolean = False
                For i As Int64 = 0 To FirstStage.RowCount - 1
                    If FirstStage.GetRowCellValue(i, "TickMark").ToString = True Then
                        Dim _GetAgentTbl As New DataTable
                        Dim AccountName As String = ""
                        Dim AgentMob As String = ""

                        Dim PartyName As String = ""
                        Dim PartyMobNo As String = ""

                        If Txt_DataShowBy.Text = "AGENT" Then

                            AccountName = FirstStage.GetRowCellValue(i, "AgentName").ToString
                            AgentMob = FirstStage.GetRowCellValue(i, "AgentMob").ToString
                            If _OnlyAgent = "OnlyAgent" Then
                                REPORT_RPT_FILE_NAME = "Outstanding_3A"
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                Dim _AgentCodeGet = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim Filter_Condition = " AND B.AGENTCODE = '" & _AgentCodeGet & "'"
                                _GetAgentTbl = _GetData(Filter_Condition)
                                res = _PdfCraetAndWhatsappSend(_GetAgentTbl, AccountName, AgentMob)
                                _WhtsAppMessage(res)
                            ElseIf _OnlyAgent = "OnlyParty" Then
                                REPORT_RPT_FILE_NAME = "Outstanding_2dr"
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                Dim _AgentCodeGet = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim _MstTbl = _GetAgentNameToMasterCode(_AgentCodeGet)

                                For Each dr As DataRow In _MstTbl.Select
                                    Dim Filter_Condition = " AND B.ACCOUNTCODE = '" & dr("Accountcode") & "'"
                                    Dim _GetPName As String = dr("ACCOUNTNAME").ToString
                                    Dim _GetPmobile As String = dr("MOBILE").ToString
                                    If _GetAgentTbl.Rows.Count <> 0 Then
                                        _GetAgentTbl.Clear()
                                    End If
                                    _GetAgentTbl = _GetData(Filter_Condition)
                                    res = _PdfCraetAndWhatsappSend(_GetAgentTbl, _GetPName, _GetPmobile)
                                Next

                                _WhtsAppMessage(res)
                            ElseIf _OnlyAgent = "Party+Agent" Then
                                REPORT_RPT_FILE_NAME = "Outstanding_3A"
                                '  +++++++++ Send Agent Whatsapp ++++++++++++++
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                Dim _AgentCodeGet = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim Filter_Condition = " AND B.AGENTCODE = '" & _AgentCodeGet & "'"
                                _GetAgentTbl = _GetData(Filter_Condition)
                                _PdfCraetAndWhatsappSend(_GetAgentTbl, AccountName, AgentMob)
                                '  +++++++++ Send Agent Whatsapp Finish ++++++++++++++


                                '  +++++++++ Send Party Whatsapp  ++++++++++++++
                                Dim _MstTbl = _GetAgentNameToMasterCode(_AgentCodeGet)
                                REPORT_RPT_FILE_NAME = "Outstanding_2dr"
                                For Each dr As DataRow In _MstTbl.Select
                                    Filter_Condition = " AND B.ACCOUNTCODE = '" & dr("Accountcode") & "'"
                                    Dim _GetPName As String = dr("ACCOUNTNAME").ToString
                                    Dim _GetPmobile As String = dr("MOBILE").ToString
                                    If _GetAgentTbl.Rows.Count <> 0 Then
                                        _GetAgentTbl.Clear()
                                    End If
                                    _GetAgentTbl = _GetData(Filter_Condition)
                                    res = _PdfCraetAndWhatsappSend(_GetAgentTbl, _GetPName, _GetPmobile)
                                Next
                                '  +++++++++ Send Party Whatsapp Finish ++++++++++++++
                                _WhtsAppMessage(res)
                            End If

                        Else


                            AccountName = FirstStage.GetRowCellValue(i, "PartyName").ToString
                            PartyMobNo = FirstStage.GetRowCellValue(i, "PartyMob").ToString

                            If _OnlyAgent = "OnlyAgent" Then
                                REPORT_RPT_FILE_NAME = "Outstanding_3A"
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                Dim _AgentCodeGet = DefaltSoftTable.Rows(0).Item("AGENTCODE").ToString
                                Dim PACCOUNTCODE = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim _GetPName = DefaltSoftTable.Rows(0).Item("AGENTNAME").ToString
                                Dim _GetPmobile = DefaltSoftTable.Rows(0).Item("AGENTMOBILE").ToString
                                Dim Filter_Condition = " AND B.AGENTCODE = '" & _AgentCodeGet & "' AND B.ACCOUNTCODE = '" & PACCOUNTCODE & "'"
                                _GetAgentTbl = _GetData(Filter_Condition)
                                res = _PdfCraetAndWhatsappSend(_GetAgentTbl, AccountName, _GetPmobile)
                                _WhtsAppMessage(res)

                            ElseIf _OnlyAgent = "OnlyParty" Then
                                REPORT_RPT_FILE_NAME = "Outstanding_2dr"
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                Dim _AgentCodeGet = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim Filter_Condition = " AND B.ACCOUNTCODE = '" & _AgentCodeGet & "'"
                                _GetAgentTbl = _GetData(Filter_Condition)
                                res = _PdfCraetAndWhatsappSend(_GetAgentTbl, AccountName, PartyMobNo)
                                _WhtsAppMessage(res)

                            ElseIf _OnlyAgent = "Party+Agent" Then
                                '  +++++++++ Send Party Whatsapp  ++++++++++++++
                                REPORT_RPT_FILE_NAME = "Outstanding_2dr"
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                Dim _AgentCodeGet = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim Filter_Condition = " AND B.ACCOUNTCODE = '" & _AgentCodeGet & "'"
                                _GetAgentTbl = _GetData(Filter_Condition)
                                res = _PdfCraetAndWhatsappSend(_GetAgentTbl, AccountName, PartyMobNo)


                                '  +++++++++ Send Agent Whatsapp ++++++++++++++
                                REPORT_RPT_FILE_NAME = "Outstanding_3A"
                                sqL = _GetMasterCode(AccountName)
                                sql_Data_Select_NewYearConnection()
                                _AgentCodeGet = DefaltSoftTable.Rows(0).Item("AGENTCODE").ToString
                                Dim PACCOUNTCODE = DefaltSoftTable.Rows(0).Item("ACCOUNTCODE").ToString
                                Dim _GetPName = DefaltSoftTable.Rows(0).Item("AGENTNAME").ToString
                                Dim _GetPmobile = DefaltSoftTable.Rows(0).Item("AGENTMOBILE").ToString
                                Filter_Condition = " AND B.AGENTCODE = '" & _AgentCodeGet & "' AND B.ACCOUNTCODE = '" & PACCOUNTCODE & "'"
                                _GetAgentTbl = _GetData(Filter_Condition)
                                res = _PdfCraetAndWhatsappSend(_GetAgentTbl, AccountName, _GetPmobile)
                                _WhtsAppMessage(res)
                            End If


                        End If

                    End If
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Wait_Window_Hide()
        Finally
            Wait_Window_Hide()
        End Try
    End Sub

    Private Sub _WhtsAppMessage(ByVal Res As Boolean)
        If Res = True Then
            MessageBox.Show("WhatsApp Send Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("WhatsApp Send Faild", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Function _PdfCraetAndWhatsappSend(ByVal _GetAgentTbl As DataTable, ByVal AccountName As String, ByVal MobileNo As String)
        Try
            Dim Res As Boolean = False

            rptDS = New Report_set
            rptDS.Tables("rptTable").Clear()

            If Txt_DataShowBy.Text = "AGENT" Then
                Dim dataView As New DataView(_GetAgentTbl)
                dataView.Sort = "AGENTNAME,ACCOUNTNAME,OBILLDATE,BILLNO ASC"
                Dim dataTable As DataTable = dataView.ToTable()
                _GetAgentTbl = dataView.ToTable()
            Else
                Dim dataView As New DataView(_GetAgentTbl)
                dataView.Sort = "ACCOUNTNAME,OBILLDATE,BILLNO ASC"
                Dim dataTable As DataTable = dataView.ToTable()
                _GetAgentTbl = dataView.ToTable()
            End If



            If _GetAgentTbl.Rows.Count > 0 Then
                For Each dr1 As DataRow In _GetAgentTbl.Select
                    rptDS.Tables("rptTable").ImportRow(dr1)
                Next
            End If

            cryRpt = New ReportDocument
            strReportPath = _reportFileSelection(REPORT_RPT_FILE_NAME)
            cryRpt.Load(strReportPath)
            cryRpt.SetDataSource(rptDS)



            If REPORT_RPT_FILE_NAME = "Outstanding_3A" Then
                cryRpt.SetParameterValue("Allow_Page_Break_Agent", False)
                cryRpt.SetParameterValue("Allow_Page_Break_Party", True)
            Else

                cryRpt.SetParameterValue("Allow_Page_Break", True)

            End If

            Dim rptTitle As String = ""
            Dim strDateRange As String = ""
            cryRpt.SetParameterValue("Comp_name", COMPANY_NAME)
            cryRpt.SetParameterValue("rptTitle", rptTitle)
            cryRpt.SetParameterValue("strDateRange", strDateRange)


            CreateGUID()
            Dim Str_File_Name As String = ""
            AccountName = Replace((AccountName).ToString, "(", "").Replace("/", "")

            Dim PATH = My.Computer.FileSystem.SpecialDirectories.Desktop
            Dim D_path As String = PATH + "\Soft Tex Reports"
            If Not Directory.Exists(D_path) Then
                Directory.CreateDirectory(D_path)
            End If

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = D_path + "\" & AccountName & "-" + CreateGUID() & ".pdf"
            Str_File_Name = D_path + "\" & AccountName & "-" + CreateGUID() & ".pdf"
            '"d:\crystalExport.pdf"
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()

            Dim PdfPath As String = Str_File_Name
            Dim url As String = "http://uploads.softtexerp.com/api/web/DoUpload/"
            Dim UploadedPdfUrl = Report_viewer.UploadFile(url, PdfPath, PdfPath, "")

            Dim cache As Boolean = False

            If MobileNo.Trim > "" Then
                Res = _WhatsappSending(MobileNo, AccountName, cache, UploadedPdfUrl, 2)
            End If

            Return Res

        Catch ex As Exception
            MsgBox(ex.ToString)
            Wait_Window_Hide()
        Finally
        End Try
    End Function

    Private Function _GetData(ByVal Filter_Condition As String)
        Dim _GetAgentTbl As New DataTable

        For Each dr As DataRow In CurntYearAllCompTbl.Select
            Dim DataBaseName = dr("Data_Folder_Name").ToString
            Dim Comp_Print_Name = dr("Comp_Print_Name").ToString
            Dim _YearConn = _GetServerConnection(DataBaseName)
            NewYearConnection = New SqlConnection(_YearConn)


            Dim _AgentCodeGet As String = ""
            Dim _AccountCodeGet As String = ""



            Dim ORDER_BY_REPORT = " ORDER BY K.AGENTNAME,K.ACCOUNTNAME,K.OBILLDATE,K.BILLNO  "
            Dim _GetDataTbl As New DataTable
            sqL = Outstanding(Filter_Condition, ORDER_BY_REPORT, Comp_Print_Name)
            sql_Data_Select_NewYearConnection()
            _GetDataTbl = DefaltSoftTable.Copy
            If _GetAgentTbl.Rows.Count = 0 Then
                _GetAgentTbl = _GetDataTbl.Clone()
            End If
            If _GetDataTbl.Rows.Count > 0 Then
                For Each dr1 As DataRow In _GetDataTbl.Select
                    _GetAgentTbl.ImportRow(dr1)
                Next
            End If

        Next
        Return _GetAgentTbl
    End Function

    Private Function _GetMasterCode(ByVal _AccountName As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1")
            .Append(" A.ACCOUNTCODE")
            .Append(" ,A.AGENTCODE")
            .Append(" ,a.mobile")
            .Append(" ,B.ACCOUNTNAME AS AGENTNAME")
            .Append(" ,B.MOBILE AS AGENTMOBILE")
            .Append(" FROM MstMasterAccount AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.AGENTCODE =B.ACCOUNTCODE ")
            .Append(" WHERE 1=1  ")
            .Append(" AND  A.ACCOUNTNAME ='" & _AccountName & "'")
        End With
        Return _strQuery.ToString()
    End Function

    Private Function _GetAgentNameToMasterCode(ByVal FilterAgentcode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.ACCOUNTCODE")
            .Append(" ,A.ACCOUNTNAME")
            .Append(" ,a.mobile")
            .Append(" ,a.AGENTCODE")
            .Append(" ,B.MOBILE AS AGENTMOBILE")
            .Append(" FROM MstMasterAccount AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.AGENTCODE =B.ACCOUNTCODE ")
            .Append(" WHERE 1=1  ")
            .Append(" AND  A.AGENTCODE ='" & FilterAgentcode & "'")
        End With
        sqL = _strQuery.ToString()
        sql_connect_slect()
        Dim _Tmptbl As New DataTable
        _Tmptbl = DefaltSoftTable.Copy
        Return _Tmptbl
    End Function

    Private Function _GetPartyNameToAgentCode(ByVal FilterPartycode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" B.ACCOUNTCODE AS AGENTCODE")
            .Append(" ,B.ACCOUNTNAME")
            .Append(" ,B.mobile")
            .Append(" ,a.ACCOUNTCODE")
            .Append(" FROM MstMasterAccount AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.AGENTCODE =B.ACCOUNTCODE ")
            .Append(" WHERE 1=1  ")
            .Append(" AND  A.ACCOUNTCODE ='" & FilterPartycode & "'")
        End With
        sqL = _strQuery.ToString()
        sql_connect_slect()
        Dim _Tmptbl As New DataTable
        _Tmptbl = DefaltSoftTable.Copy
        Return _Tmptbl
    End Function

#Region "Save Grid Layout"
    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click
        Dim _RptTiltle = "Outstanding Report :"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub
    Private Sub Btn_Exl_Click(sender As Object, e As EventArgs) Handles Btn_Exl.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub
#End Region

    Public Function Outstanding(ByVal Filter_Condition As String, ByVal ORDER_BY_REPORT As String, ByVal Comp_Print_Name As String)

        Dim Date_Title = "As On Dated" + DateTime.Now.ToString("dd/MM/yyyy") + "(Pymt As On Dated :" + DateTime.Now.ToString("dd/MM/yyyy") + ")"

        Date_Formate1 = Main_MDI_Frm.FINE_YEAR_START.Text
        Date_Formate2 = DateTime.Now.ToString("dd/MM/yyyy")
        Date_Formate3 = DateTime.Now.ToString("dd/MM/yyyy")
        Date_Formate4 = DateTime.Now.ToString("dd/MM/yyyy")
        Date_Formate_set()

        Dim Date_Range As String = ""

        Dim Filter_Condition_Group As String = ""


        Date_Range = " AND A.BILLDATE<='" & Date_2 & "'"
        Dim str11 As String = " AND A.ADJVNODATE<='" & Date_3 & "' "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
            .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
            .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
            .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
            .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
            .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
            .Append(" '" & Comp_email & "'   AS COMP_EMAIL, ")
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append("'' as GROUPNAME, 00000000.00 AS RDVALUE,00000000.00 AS CDVALUE, ")
            .Append(" 00000000.00 AS CD,'' AS CDON, ")
            .Append(" " & Val(txt_High_Days.Text) & " AS PCS, ")
            .Append(" K.BILLNO +' / ' + '" & Comp_Print_Name & "' as BILLNO, ")
            .Append(" K.F_BILLDATE, ")
            .Append(" K.DUEDAYS, ")
            .Append(" CASE WHEN L.GROSS_AMOUNT>0 AND L.TOTAL_MTR_WEIGHT>0 THEN ROUND(L.GROSS_AMOUNT/L.TOTAL_MTR_WEIGHT,2) ELSE 00000000.00  END AS RATE, ")
            .Append(" K.BOOKTRTYPE, ")
            .Append(" K.REMARK, ")
            .Append(" K.BILLDATE, ")
            .Append(" K.BALANCE, ")
            .Append(" K.ACCOUNTCITYNAME, ")
            .Append(" K.AGENTCITYNAME, ")
            .Append(" K.PARTYNAME, ")
            .Append(" K.TINNO, ")
            .Append(" K.PANNO, ")
            .Append(" K.ACCOUNTNAME, ")
            .Append(" K.AGENTNAME, ")
            .Append(" L.HEADER_REMARK as itemcode, ")
            .Append(" L.OFFERNOANDDATE AS ACKNO, M.AC_NAME AS ACOFNAME, ")
            .Append(" K.ITEMREMARK, K.BOOKVNO, K.ACCOUNTCODE, ")
            .Append(" K.OBILLDATE,  ")
            .Append(" K.E_BILLDATE, K.DEBITAMT, ")
            .Append(" K.CREDITAMT, K.TDEBITAMT, ")
            .Append(" K.TCREDITAMT, ")
            .Append(" K.BALANCEAMT,  ")
            .Append(" K.DBALANCEAMT, ")
            .Append(" K.DRCR,  ")
            .Append(" K.DAY1, ")
            .Append(" K.DAY2, ")
            .Append(" K.DAY3, ")
            .Append(" K.DAY4, ")
            .Append(" K.MTR_WEIGHT, ")
            .Append(" K.BILLAMT,  ")
            .Append(" K.AGREF,  ")
            .Append(" K.OUTAMT,  ")
            .Append(" K.PYMTAMOUNT, ")
            .Append(" K.OLDGR, ")
            .Append(" K.ONAC, ")
            .Append(" K.RD,  ")
            .Append(" K.CD, ")
            .Append(" K.ADJAMT, ")
            .Append(" K.AGCOMM, ")
            .Append(" K.SUBAGCOMM, ")
            .Append(" K.INSURANCE, ")
            .Append(" K.GR, ")
            .Append(" K.INTEREST,  ")
            .Append(" K.GRONAC, ")
            .Append(" K.DDCOMM, ")
            .Append(" K.CLAIM,  ")
            .Append(" K.OTHER, ")
            .Append(" K.CRDAYS, ")
            .Append(" ISNULL(K.CRDAYS,0) AS JAN_WEIGHT, ") ' CRDAYS
            .Append(" (K.DISCOUNTDAYS)  AS STATE, ") 'DISCOUNTDAYS
            .Append(" (K.DEBITLIMIT) AS MAR_WEIGHT, ") 'DEBITLIMIT
            .Append(" (K.CREDITLIMIT ) AS APR_WEIGHT, ") 'CREDITLIMIT
            .Append(" '' AS WIDTH, ")
            .Append(" '' AS SUPPLIER_NAME, ")
            .Append(" L.OFFERNOANDDATE AS LABEL_LINE1_1, ") ' PURCHASES TO Sales Supplier Name
            .Append(" L.FINREMARK AS LABEL_LINE1_2, ") ' PURCHASES TO Sales Bill No
            .Append(" N.BOOKPREFIX,N.BEHAVIOUR,N.BEHAVIOUR AS WIDTH ")
            .Append(" ,K.MSMENO AS LABEL_LINE4_3 ") ' MSME NO
            .Append(" ,K.MSMETYPE AS LABEL_LINE4_4 ") ' MSME TYPE
            .Append(" ,K.COTPERSON AS LOTNO ") ' COTPERSON
            .Append(" ,K.PARTYADDRESS ")
            .Append(" ,K.COTPERMOBILE AS REMARK1 ") ' COTPERMOBILE

            .Append(" ,O.ACCOUNTNAME AS SUPPNAME")
            .Append(" ,L.OP2 AS SUPPCITYCODE")
            .Append(" ,L.BALE_PACKING_CHG AS T_PCS")
            .Append(" ,L.OTHER_ADD AS S_PCS")
            .Append(" ,L.OP16 AS S_MTR_WEIGHT")


            .Append(" FROM ((( ")
            .Append(" SELECT Z.*,FORMAT(OBILLDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            .Append((" DATEDIFF(DAY,Z.BILLDATE,'" & Date_4 & "') AS DUEDAYS, "))
            .Append(" SPACE(100) AS REMARK, ")
            .Append(" Z.BALANCEAMT AS   BALANCE, ")
            .Append(" C.CITYNAME AS ACCOUNTCITYNAME, ")
            .Append(" G.CITYNAME AS AGENTCITYNAME, ")
            .Append(" ISNULL(B.CRDAYS,0) AS CRDAYS, ")
            .Append(" ISNULL(B.BILLLIMIT,'0') AS DISCOUNTDAYS, ")
            .Append(" ISNULL(B.DRLIMIT,0) AS DEBITLIMIT, ")
            .Append(" ISNULL(B.CRLIMIT,0) AS CREDITLIMIT, ")
            .Append(" LTRIM(B.ACCOUNTNAME)+','+LTRIM(C.CITYNAME)+','+LTRIM(B.PHONE)+' '+LTRIM(B.MOBILE)  AS ACCOUNTNAME, ")
            .Append(" LTRIM(B.ACCOUNTNAME)+','+LTRIM(C.CITYNAME)+','+LTRIM(B.PHONE)+' '+LTRIM(B.MOBILE)  AS PARTYNAME, ")
            .Append(" B.GSTIN AS TINNO,B.PANNO, ")
            .Append(" B.OP35 AS MSMENO, ") ' MSME NO
            .Append(" B.OP36 AS MSMETYPE, ") ' MSME TYPE
            .Append(" B.COTPERSON , ") ' COTPERSON
            .Append(" isnull (B.ADDRESS1,'') +','+  isnull (B.ADDRESS2,'') +','+  isnull (B.ADDRESS3,'')   AS PARTYADDRESS, ")
            .Append(" B.COTPERMOBILE, ") 'COTPERMOBILE
            .Append(" LTRIM(F.ACCOUNTNAME)+','+isnull(LTRIM(G.CITYNAME),'')+','+isnull(LTRIM(F.PHONE),'')+' '+isnull(LTRIM(F.MOBILE),'')   AS AGENTNAME ")
            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
            .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
            .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
            .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
            .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
            .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
            .Append(" '" & Comp_email & "'   AS COMP_EMAIL, ")
            .Append(" SPACE(500) AS ITEMREMARK, A.BOOKVNO, A.ACCOUNTCODE, ")
            .Append(" A.BILLNO, LEFT(A.BOOKVNO,5) AS BOOKTRTYPE,  ")
            .Append("  SUM(A.DEBITAMT) AS DEBITAMT, ")
            .Append("  A.BILLDATE,A.BILLDATE AS E_BILLDATE, A.OBILLDATE,")

            .Append(" SUM(A.CREDITAMT) AS CREDITAMT, SUM(A.DEBITAMT) AS TDEBITAMT, ")
            .Append(" SUM(A.CREDITAMT) AS TCREDITAMT, ")
            .Append(" ABS(SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS   BALANCEAMT,  ")
            .Append(" ABS(SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS   DBALANCEAMT, ")
            .Append(" CASE WHEN SUM(A.DEBITAMT)>SUM(A.CREDITAMT) THEN 'Dr' ELSE 'Cr' END AS DRCR,  ")
            .Append(" 0 as DAY1,  ")
            .Append(" 0 as DAY2,  ")
            .Append(" 0 as DAY3,  ")
            .Append(" 0 as DAY4,  ")

            '.Append(String.Concat(New String() {" CASE WHEN DATEDIFF(DAY,A.BILLDATE,'", Date_4, "')<=", Conversions.ToString(Conversion.Val(Me.txt_Day1_2.Text)), " THEN SUM(A.DEBITAMT)-SUM(A.CREDITAMT) ELSE 0 END  AS DAY1, "}))
            '.Append(String.Concat(New String() {" CASE WHEN DATEDIFF(DAY,A.BILLDATE,'", Date_4, "')>=", Conversions.ToString(Conversion.Val(Me.txt_Day2_1.Text)), " AND  DATEDIFF(DAY,A.BILLDATE,'", Date_4, "')<=", Conversions.ToString(Conversion.Val(Me.txt_Day2_2.Text)), " THEN SUM(A.DEBITAMT)-SUM(A.CREDITAMT) ELSE 0 END  AS DAY2, "}))
            '.Append(String.Concat(New String() {" CASE WHEN DATEDIFF(DAY,A.BILLDATE,'", Date_4, "')>=", Conversions.ToString(Conversion.Val(Me.txt_Day3_1.Text)), " AND  DATEDIFF(DAY,A.BILLDATE,'", Date_4, "')<=", Conversions.ToString(Conversion.Val(Me.txt_Day3_2.Text)), " THEN SUM(A.DEBITAMT)-SUM(A.CREDITAMT) ELSE 0 END  AS DAY3, "}))
            '.Append(String.Concat(New String() {" CASE WHEN DATEDIFF(DAY,A.BILLDATE,'", Date_4, "')>=", Conversions.ToString(Conversion.Val(Me.txt_Day7_1.Text)), " THEN SUM(A.DEBITAMT)-SUM(A.CREDITAMT) ELSE 0 END  AS DAY4, "}))

            .Append(" SUM(A.QTY) AS MTR_WEIGHT, ")
            .Append(" SUM(A.BILLAMT) AS BILLAMT,  ")
            .Append(" SUM(A.AGREF) AS AGREF,  ")
            .Append(" SUM(A.BILLAMT)+SUM(A.ONAC) AS OUTAMT,  ")
            .Append(" SUM(A.PYMTAMOUNT)+SUM(A.ONAC) AS PYMTAMOUNT, ")
            .Append(" SUM(A.OLDAG) AS OLDAG,SUM(A.OLDGR) AS OLDGR, ")
            .Append(" SUM(A.TD) AS TD, SUM(A.ONAC) AS ONAC, ")
            .Append(" SUM(A.RD) AS RD,  ")
            .Append(" SUM(A.CD) AS CD, ")
            .Append(" SUM(A.ADJAMT)-SUM(A.INTEREST) AS   ADJAMT, ")
            .Append(" SUM(A.AGCOMM) AS   AGCOMM, ")
            .Append(" SUM(A.SUBAGCOMM) AS   SUBAGCOMM, ")
            .Append(" SUM(A.TDS) AS TDS, SUM(A.INSURANCE) AS   INSURANCE, ")
            .Append(" SUM(A.GR)+SUM(A.OLDGR) AS   GR, ")
            .Append(" SUM(A.INTEREST) AS   INTEREST,  ")
            .Append(" SUM(A.GRONAC) AS   GRONAC, ")
            .Append(" SUM(A.DDCOMM) AS   DDCOMM, ")
            .Append(" SUM(A.CLAIM) AS   CLAIM,  ")
            .Append(" SUM(A.OTHER)+SUM(A.CLAIM)+SUM(A.DDCOMM)+SUM(A.TDS)+SUM(A.INSURANCE) AS   OTHER ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT A.*, CASE WHEN A.SUNCODE='0001-000000040' THEN ADJAMT ELSE 0 END AS PYMTAMOUNT, ")
            .Append(" A.BILLDATE AS OBILLDATE, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000040' THEN ADJAMT ELSE 0 END AS AGREF,  ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000041' THEN ADJAMT ELSE 0 END AS ONAC,  ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000042' THEN ADJAMT ELSE 0 END AS RD, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000043' THEN ADJAMT ELSE 0 END AS CD, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000044' THEN ADJAMT ELSE 0 END AS AGCOMM, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000045' THEN ADJAMT ELSE 0 END AS SUBAGCOMM, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000046' THEN ADJAMT ELSE 0 END AS INTEREST,  ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000047' THEN ADJAMT ELSE 0 END AS TDS, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000048' THEN ADJAMT ELSE 0 END AS INSURANCE, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000049' THEN ADJAMT ELSE 0 END AS GR, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000050' THEN ADJAMT ELSE 0 END AS GRONAC, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000051' THEN ADJAMT ELSE 0 END AS DDCOMM, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000052' THEN ADJAMT ELSE 0 END AS CLAIM, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000053' THEN ADJAMT ELSE 0 END AS OTHER, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000054' THEN ADJAMT ELSE 0 END AS OLDAG, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000055' THEN ADJAMT ELSE 0 END AS TD, ")
            .Append(" CASE WHEN A.SUNCODE='0001-000000056' THEN ADJAMT ELSE 0 END AS OLDGR  ")
            .Append(" FROM ")
            .Append(" (SELECT A.* FROM trnoutstanding AS A,MstMasterAccount AS B WHERE 1=1 AND A.SUNCODE='' ")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(Filter_Condition)
            .Append(Date_Range)

            .Append(" UNION ALL ")
            .Append("  SELECT A.* FROM trnoutstanding AS A LEFT JOIN  MstMasterAccount AS B  ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" WHERE 1=1 ")
            .Append(Filter_Condition)
            .Append(Date_Range)
            .Append((" AND A.ADJVNODATE<='" & Date_3 & "'  AND A.SUNCODE>'' )  AS A)  AS A "))
            .Append(" WHERE(A.INTEREST = 0 ) ")
            .Append(" GROUP BY A.BOOKVNO, A.ACCOUNTCODE,A.BILLNO,A.OBILLDATE ")
            .Append(" , A.BILLDATE")

            .Append(" ) AS Z ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON Z.ACCOUNTCODE=B.ACCOUNTCODE")
            .Append(" LEFT JOIN MSTCITY AS C ON B.CITYCODE=C.CITYCODE ")
            .Append(" LEFT JOIN MstMasterAccount AS F ON B.AGENTCODE=F.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND Z.BALANCEAMT<>0 ")
            .Append(Filter_Condition)
            .Append(" )  AS K LEFT JOIN TRNINVOICEHEADER AS L ON K.BOOKVNO= L.BOOKVNO) ")
            .Append(" LEFT JOIN Mst_Acof_Supply As M On L.ACOFCODE=M.id) ")
            .Append(" LEFT JOIN MSTBOOK As N On L.BOOKTRTYPE=N.BOOKTRTYPE ")

            If Txt_EntryType.Text = "DEBTORS" Then
                .Append(" LEFT JOIN MstMasterAccount AS O ON L.OPP_ACCOUNTCODE=O.ACCOUNTCODE ")
            Else
                .Append(" LEFT JOIN MstMasterAccount AS O ON L.ACCOUNTCODE=O.ACCOUNTCODE ")
            End If
            .Append(" WHERE 1=1 ")
            .Append(ORDER_BY_REPORT)
        End With
        'sqL = _strQuery.ToString
        'sql_connect_slect()
        'Dim _Ttbl As New DataTable
        '_Ttbl = DefaltSoftTable.Copy

        Return _strQuery.ToString

    End Function

    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Delete Selected Bill Folo Remark", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Dim id As Int64 = GridView1.GetFocusedRowCellValue("id").ToString
                sqL = " DELETE FROM PaymentFolo WHERE ID=" & id & ""
                PaymentFolo_QuerySaveUpdateDelete()
                MsgBox("Delete Successfully", MsgBoxStyle.Information, "Soft-Tex PRO")
                _ViewRemarkGrid()
                '_EnterKeyGridLoad()
            End If
        End If
    End Sub
End Class