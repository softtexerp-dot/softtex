Imports System.IO
Imports System.Text
Imports CrystalDecisions.Shared
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting


Friend Class StoreConsumption_GridZooming

    Private CurDate As String = Now.Month.ToString & "/" & Now.Day.ToString & "/" & Now.Year.ToString
    Private Process_Date_Filter_Condition As String = ""
    Private SelectedAccountName As String = ""
    Private Display_Stage_No As Integer = 0
    Dim Zoom_Stock_Table As New DataTable
    Dim Zoom_Stock_Table_Secondstage As New DataTable
    Dim ThidTable As New DataTable
    Dim FourTable As New DataTable
    Dim FIveTable As New DataTable
    Dim _StgIRowNo As Integer = 1
    Dim _StgIIRowNo As Integer = 1
    Dim _StgThidRowNo As Integer = 1
    Dim _StgFourRowNo As Integer = 1
    Private obj_Party_Selection As New Multi_Selection_Master

    Dim _FILTERACCOUNTCODE As String = ""
    Dim _CloseCheck As Boolean = False

    Private Sub StoreConsumption_GridZooming_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If _CloseCheck = True Then
                Close()
                Me.Dispose(True)
            Else
                _CloseCheck = True
                txt_From.Focus()
            End If



        End If
    End Sub
    Private Sub StoreConsumption_GridZooming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        If LEDGER_FORM_DISPALY_BY <> "BUTTONCALL" Then
            Me.Location = New Point(0, 0)
        End If

        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)

        Dim _NewTmptbl As New DataTable
        _NewTmptbl = _Zooming_Load(txt_To.Date_for_Database)
        Stock_Zooming_Load(_NewTmptbl)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _CloseCheck = False
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)

        Dim _NewTmptbl As New DataTable
        _NewTmptbl = _Zooming_Load(txt_To.Date_for_Database)
        Stock_Zooming_Load(_NewTmptbl)

    End Sub

    Private Sub Stock_Zooming_Load(ByVal Stktbl As DataTable)
        If Stktbl.Rows.Count > 0 Then
            Display_Stage_No = 1

            FirstStage.Columns.Clear()
            If Stktbl.Rows.Count > 0 Then

                GridControl1.DataSource = Stktbl.Copy

                FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}"))
                FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0}"))

                FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("Amount").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                _DevGridColumSizeAutoAdjestWhiotTickmarck(GridControl1, FirstStage)

                AlignGroupSummaryInGroupRow(GridControl1, FirstStage)

                FirstStage.Focus()
                FirstStage.FocusedRowHandle = _StgIRowNo
            End If
        End If
    End Sub
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Qty", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Qty")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Amount", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Amount")})


        gridView.Appearance.GroupRow.BackColor = Color.LightGreen

    End Sub
    Private Function _Zooming_Load(ByVal _DateTo As String)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")

            If Txt_ViewType.Text = "Month+Loom Wise" Then
                .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
                .Append(" C.LoomNo, ")
                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                .Append(" SUM(A.AMOUNT) AS Amount ")
            ElseIf Txt_ViewType.Text = "Month+Item Wise" Then
                .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
                .Append(" B.ITEMNAME AS ItemName, ")
                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                .Append(" SUM(A.AMOUNT) AS Amount ")

            ElseIf Txt_ViewType.Text = "Loom+Item Wise" Then
                .Append(" C.LoomNo, ")
                .Append(" B.ITEMNAME AS ItemName, ")
                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                .Append(" SUM(A.AMOUNT) AS Amount ")
            ElseIf Txt_ViewType.Text = "Detail" Then
                .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
                .Append(" C.LoomNo, ")
                .Append(" B.ITEMNAME AS ItemName, ")
                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                .Append(" SUM(A.AMOUNT) AS Amount ")

            Else
                .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                .Append(" SUM(A.AMOUNT) AS Amount ")
            End If

            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append(" A.CHALLANDATE ")
            .Append(" ,A.MTR_WEIGHT ")
            .Append(" ,A.AMOUNT ")
            .Append(" ,A.ITEMCODE ")
            .Append(" ,A.LOOMNOCODE  ")
            .Append(" FROM ")
            .Append(" TRNCHALLAN as A ")
            .Append(" WHERE 1=1  ")
            .Append(" and A.BOOKCODE='0001-000000155'  ")
            .Append(" ) AS A ")
            .Append(" LEFT JOIN MSTSTOREITEM AS B ON A.ITEMCODE=B.ITEMCODE ")
            .Append(" LEFT JOIN MstLoomNo AS C ON A.LOOMNOCODE=C.LoomNoCode ")
            .Append(" GROUP BY  ")

            If Txt_ViewType.Text = "Month+Loom Wise" Then
                .Append(" C.LoomNo ")
                .Append(" ,MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
                .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy') ")
                .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM') ,C.LoomNo")
            ElseIf Txt_ViewType.Text = "Month+Item Wise" Then
                .Append(" B.ITEMNAME ")
                .Append(" ,MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
                .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy') ")
                .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM') , B.ITEMNAME ")
            ElseIf Txt_ViewType.Text = "Loom+Item Wise" Then
                .Append(" C.LoomNo, ")
                .Append(" B.ITEMNAME ")
                .Append(" ORDER BY C.LoomNo, B.ITEMNAME ")
            ElseIf Txt_ViewType.Text = "Detail" Then
                .Append(" MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
                .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy'), ")
                .Append(" C.LoomNo, ")
                .Append(" B.ITEMNAME ")
                .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM'),C.LoomNo, B.ITEMNAME ")
            Else
                .Append(" MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
                .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy') ")
                .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM') ")
            End If

        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _NewTmptbl As New DataTable
        Zoom_Stock_Table.Clear()
        Zoom_Stock_Table = DefaltSoftTable.Copy
        _NewTmptbl = DefaltSoftTable.Copy
        Return _NewTmptbl
    End Function

    Private Sub btn_xl_Click(sender As Object, e As EventArgs) Handles btn_xl.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub But_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Consumption Report"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Txt_ViewType_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ViewType.KeyDown
        If e.KeyCode = Keys.Enter Then
            But_ok.Focus()
        End If
    End Sub

    Private Sub Txt_ViewType_GotFocus(sender As Object, e As EventArgs) Handles Txt_ViewType.GotFocus
        Txt_ViewType.DroppedDown = True
    End Sub

#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub


#End Region


End Class