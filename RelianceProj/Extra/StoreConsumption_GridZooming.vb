Imports System.IO
Imports System.Text
Imports CrystalDecisions.Shared
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
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

                'FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}"))
                'FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0}"))

                'FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                'FirstStage.Columns("Amount").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                'If FirstStage.Columns("Qty") IsNot Nothing Then
                '    FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n2}"))
                '    FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                'End If

                'If FirstStage.Columns("Amount") IsNot Nothing Then
                '    FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}"))
                '    FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                'End If

                ' 🔹 Use BandedGridView
                Dim bandedView As New BandedGridView(GridControl1)
                GridControl1.MainView = bandedView
                GridControl1.ViewCollection.Add(bandedView)

                ' 🔹 Create Bands
                Dim Itemname As New GridBand() With {.Caption = ""}
                Dim Jan As New GridBand() With {.Caption = "Jan"}
                Dim Feb As New GridBand() With {.Caption = "Feb"}
                Dim Mar As New GridBand() With {.Caption = "Mar"}
                Dim Apr As New GridBand() With {.Caption = "Apr"}
                Dim May As New GridBand() With {.Caption = "May"}
                Dim Jun As New GridBand() With {.Caption = "Jun"}
                Dim Jul As New GridBand() With {.Caption = "Jul"}
                Dim Aug As New GridBand() With {.Caption = "Aug"}
                Dim Sep As New GridBand() With {.Caption = "Sep"}
                Dim Oct As New GridBand() With {.Caption = "Oct"}
                Dim Nov As New GridBand() With {.Caption = "Nov"}
                Dim Dec As New GridBand() With {.Caption = "Dec"}

                bandedView.Bands.AddRange(New GridBand() {Itemname, Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec})

                ' 🔹 Add Columns to Bands

                Itemname.Columns.Add(AddBandedColumn(bandedView, "ItemName", ""))
                Jan.Columns.Add(AddBandedColumn(bandedView, "Jan,2025_Qty", "Qty"))
                Jan.Columns.Add(AddBandedColumn(bandedView, "Jan,2025_Amt", "Amt"))
                Feb.Columns.Add(AddBandedColumn(bandedView, "Feb,2025_Qty", "Qty"))
                Feb.Columns.Add(AddBandedColumn(bandedView, "Feb,2025_Amt", "Amt"))
                Mar.Columns.Add(AddBandedColumn(bandedView, "Mar,2025_Qty", "Qty"))
                Mar.Columns.Add(AddBandedColumn(bandedView, "Mar,2025_Amt", "Amt"))
                Apr.Columns.Add(AddBandedColumn(bandedView, "Apr,2025_Qty", "Qty"))
                Apr.Columns.Add(AddBandedColumn(bandedView, "Apr,2025_Amt", "Amt"))
                May.Columns.Add(AddBandedColumn(bandedView, "May,2025_Qty", "Qty"))
                May.Columns.Add(AddBandedColumn(bandedView, "May,2025_Amt", "Amt"))
                Jun.Columns.Add(AddBandedColumn(bandedView, "Jun,2025_Qty", "Qty"))
                Jun.Columns.Add(AddBandedColumn(bandedView, "Jun,2025_Amt", "Amt"))
                Jul.Columns.Add(AddBandedColumn(bandedView, "Jul,2025_Qty", "Qty"))
                Jul.Columns.Add(AddBandedColumn(bandedView, "Jul,2025_Amt", "Amt"))
                Aug.Columns.Add(AddBandedColumn(bandedView, "Aug,2025_Qty", "Qty"))
                Aug.Columns.Add(AddBandedColumn(bandedView, "Aug,2025_Amt", "Amt"))
                Sep.Columns.Add(AddBandedColumn(bandedView, "Sep,2025_Qty", "Qty"))
                Sep.Columns.Add(AddBandedColumn(bandedView, "Sep,2025_Amt", "Amt"))
                Oct.Columns.Add(AddBandedColumn(bandedView, "Oct,2025_Qty", "Qty"))
                Oct.Columns.Add(AddBandedColumn(bandedView, "Oct,2025_Amt", "Amt"))
                Nov.Columns.Add(AddBandedColumn(bandedView, "Nov,2025_Qty", "Qty"))
                Nov.Columns.Add(AddBandedColumn(bandedView, "Nov,2025_Amt", "Amt"))
                Dec.Columns.Add(AddBandedColumn(bandedView, "Dec,2025_Qty", "Qty"))
                Dec.Columns.Add(AddBandedColumn(bandedView, "Dec,2025_Amt", "Amt"))

                ' 🔹 Formatting options
                bandedView.OptionsView.ShowBands = True
                bandedView.OptionsView.ShowAutoFilterRow = True
                bandedView.OptionsBehavior.Editable = False
                bandedView.OptionsView.ShowFooter = True
                bandedView.BestFitColumns()
                '_DevGridColumSizeAutoAdjestWhiotTickmarck(GridControl1, FirstStage)

                'AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
                SetBandedGridViewAppearance(bandedView)
                ApplyFooterSummary(bandedView)
                FirstStage.Focus()
                FirstStage.FocusedRowHandle = _StgIRowNo
            End If
        End If
    End Sub
    Private Sub ApplyFooterSummary(ByVal bandedView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        bandedView.OptionsView.ShowFooter = True
        bandedView.Appearance.FooterPanel.Font = New Font("Verdana", 8, FontStyle.Bold)
        bandedView.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

        For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bandedView.Columns
            If col.FieldName.Contains("_Qty") OrElse col.FieldName.Contains("_Amt") Then
                col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                col.SummaryItem.DisplayFormat = "{0:N2}"
                col.AppearanceCell.Font = New Font("Verdana", 8, FontStyle.Regular)
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        Next
    End Sub
    Private Sub SetBandedGridViewAppearance(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        ' Set fonts and alignment for all bands and columns
        For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In view.Bands
            ' Band header
            band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center

            ' Columns inside the band
            For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In band.Columns
                ' Header font and alignment
                col.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center

                ' Cell font
                col.AppearanceCell.Font = New Font("Verdana", 8, FontStyle.Regular)
                col.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center

                ' Align numeric columns to right, others to left
                Select Case Type.GetTypeCode(col.ColumnType)
                    Case TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.Single
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Case Else
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                End Select
            Next
        Next
    End Sub


    Private Function AddBandedColumn(view As BandedGridView, fieldName As String, caption As String) As BandedGridColumn
        Dim col As New BandedGridColumn() With {
        .FieldName = fieldName,
        .Caption = caption,
        .Visible = True
    }
        view.Columns.Add(col)
        Return col
    End Function
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
            '.Append(" SELECT ")

            'If Txt_ViewType.Text = "Month+Loom Wise" Then
            '    .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
            '    .Append(" C.LoomNo, ")
            '    .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
            '    .Append(" SUM(A.AMOUNT) AS Amount ")
            'ElseIf Txt_ViewType.Text = "Month+Item Wise" Then
            '    .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
            '    .Append(" B.ITEMNAME AS ItemName, ")
            '    .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
            '    .Append(" SUM(A.AMOUNT) AS Amount ")

            'ElseIf Txt_ViewType.Text = "Loom+Item Wise" Then
            '    .Append(" C.LoomNo, ")
            '    .Append(" B.ITEMNAME AS ItemName, ")
            '    .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
            '    .Append(" SUM(A.AMOUNT) AS Amount ")
            'ElseIf Txt_ViewType.Text = "Detail" Then
            '    .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
            '    .Append(" C.LoomNo, ")
            '    .Append(" B.ITEMNAME AS ItemName, ")
            '    .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
            '    .Append(" SUM(A.AMOUNT) AS Amount ")

            'Else
            '    .Append(" FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy') AS MonthName, ")
            '    .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
            '    .Append(" SUM(A.AMOUNT) AS Amount ")
            'End If

            '.Append(" FROM ( ")
            '.Append(" SELECT ")
            '.Append(" A.CHALLANDATE ")
            '.Append(" ,A.MTR_WEIGHT ")
            '.Append(" ,A.AMOUNT ")
            '.Append(" ,A.ITEMCODE ")
            '.Append(" ,A.LOOMNOCODE  ")
            '.Append(" FROM ")
            '.Append(" TRNCHALLAN as A ")
            '.Append(" WHERE 1=1  ")
            '.Append(" and A.BOOKCODE='0001-000000155'  ")
            '.Append(" ) AS A ")
            '.Append(" LEFT JOIN MSTSTOREITEM AS B ON A.ITEMCODE=B.ITEMCODE ")
            '.Append(" LEFT JOIN MstLoomNo AS C ON A.LOOMNOCODE=C.LoomNoCode ")
            '.Append(" GROUP BY  ")

            'If Txt_ViewType.Text = "Month+Loom Wise" Then
            '    .Append(" C.LoomNo ")
            '    .Append(" ,MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
            '    .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy') ")
            '    .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM') ,C.LoomNo")
            'ElseIf Txt_ViewType.Text = "Month+Item Wise" Then
            '    .Append(" B.ITEMNAME ")
            '    .Append(" ,MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
            '    .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy') ")
            '    .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM') , B.ITEMNAME ")
            'ElseIf Txt_ViewType.Text = "Loom+Item Wise" Then
            '    .Append(" C.LoomNo, ")
            '    .Append(" B.ITEMNAME ")
            '    .Append(" ORDER BY C.LoomNo, B.ITEMNAME ")
            'ElseIf Txt_ViewType.Text = "Detail" Then
            '    .Append(" MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
            '    .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy'), ")
            '    .Append(" C.LoomNo, ")
            '    .Append(" B.ITEMNAME ")
            '    .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM'),C.LoomNo, B.ITEMNAME ")
            'Else
            '    .Append(" MONTH(A.CHALLANDATE), FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy'), ")
            '    .Append(" FORMAT(A.CHALLANDATE,'MM'), FORMAT(A.CHALLANDATE,'yyyy') ")
            '    .Append(" ORDER BY FORMAT(A.CHALLANDATE,'yyyy'), FORMAT(A.CHALLANDATE,'MM') ")
            'End If




            '--- Prepare filter and extra columns based on ViewType
            Dim filter As String = ""
            Dim extraCols As String = ""   ' columns to select and group by

            Dim groupCols As String = ""
            Dim selectCols As String = ""
            Select Case Txt_ViewType.Text
                Case "Month+Loom Wise"
                    filter = " AND C.LoomNo IS NOT NULL "
                    groupCols = "C.LoomNo, FORMAT(A.CHALLANDATE,''MMM,yyyy'')"
                    selectCols = "C.LoomNo"

                Case "Month+Item Wise"
                    filter = " AND B.ItemName IS NOT NULL "
                    groupCols = "B.ItemName, FORMAT(A.CHALLANDATE,''MMM,yyyy'')"
                    selectCols = "B.ItemName"

                Case "Loom+Item Wise"
                    filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL "
                    groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM,yyyy'')"
                    selectCols = "C.LoomNo, B.ItemName"

                Case "Detail"
                    filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL "
                    groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM,yyyy'')"
                    selectCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM,yyyy'') AS MonthName"

                Case Else
                    groupCols = "FORMAT(A.CHALLANDATE,''MMM,yyyy'')"
                    selectCols = "FORMAT(A.CHALLANDATE,''MMM,yyyy'') AS MonthName"
            End Select

            .AppendLine("DECLARE @cols NVARCHAR(MAX);")
            .AppendLine("DECLARE @query NVARCHAR(MAX);")

            ' --- Build dynamic month column list
            .AppendLine("SELECT @cols = STUFF((")
            .AppendLine("    SELECT DISTINCT ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy')+'_Qty')")
            .AppendLine("         + ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy')+'_Amt')")
            .AppendLine("    FROM TRNCHALLAN A")
            .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            .AppendLine("    WHERE A.BOOKCODE='0001-000000155'" & filter)
            .AppendLine("    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'');")

            .AppendLine("IF @cols IS NULL OR LEN(@cols)=0 SET @cols = '[NoData]';")

            ' --- Main dynamic pivot query
            .AppendLine("SET @query = '")
            .AppendLine("SELECT ItemName, LoomNo, MonthName, * FROM (")
            .AppendLine("    SELECT FORMAT(A.CHALLANDATE,''MMM,yyyy'') + ''_Qty'' AS MonthType,")
            .AppendLine("           SUM(A.MTR_WEIGHT) AS Value, B.ItemName, C.LoomNo, FORMAT(A.CHALLANDATE,''MMM,yyyy'') AS MonthName")
            .AppendLine("    FROM TRNCHALLAN A")
            .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            .AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter)
            .AppendLine("    GROUP BY FORMAT(A.CHALLANDATE,''MMM,yyyy''), B.ItemName, C.LoomNo")

            .AppendLine("    UNION ALL")

            .AppendLine("    SELECT FORMAT(A.CHALLANDATE,''MMM,yyyy'') + ''_Amt'' AS MonthType,")
            .AppendLine("           SUM(A.AMOUNT) AS Value, B.ItemName, C.LoomNo, FORMAT(A.CHALLANDATE,''MMM,yyyy'') AS MonthName")
            .AppendLine("    FROM TRNCHALLAN A")
            .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            .AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter)
            .AppendLine("    GROUP BY FORMAT(A.CHALLANDATE,''MMM,yyyy''), B.ItemName, C.LoomNo")
            .AppendLine(") AS SourceData")
            .AppendLine("PIVOT (")
            .AppendLine("    SUM(Value)")
            .AppendLine("    FOR MonthType IN (' + @cols + ')")
            .AppendLine(") AS PivotResult';")

            .AppendLine("EXEC sp_executesql @query;")

            '.AppendLine("DECLARE @cols NVARCHAR(MAX);")
            '.AppendLine("DECLARE @query NVARCHAR(MAX);")

            '' --- Build dynamic column list
            '.AppendLine("SELECT @cols = STUFF((")
            '.AppendLine("    SELECT DISTINCT ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy')+'_Qty')")
            '.AppendLine("         + ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy')+'_Amt')")
            '.AppendLine("    FROM TRNCHALLAN A")
            '.AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            '.AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            '.AppendLine("    WHERE A.BOOKCODE='0001-000000155'" & filter)
            '.AppendLine("    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'');")

            '.AppendLine("IF @cols IS NULL OR LEN(@cols)=0 SET @cols = '[NoData]';")

            '' --- Main pivot query
            '.AppendLine("SET @query = '")
            '.AppendLine("SELECT " & selectCols & ", * FROM (")
            '.AppendLine("    SELECT FORMAT(A.CHALLANDATE,''MMM,yyyy'') + ''_Qty'' AS MonthType,")
            '.AppendLine("           SUM(A.MTR_WEIGHT) AS Value, B.ItemName, C.LoomNo")
            '.AppendLine("    FROM TRNCHALLAN A")
            '.AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            '.AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            '.AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter)
            '.AppendLine("    GROUP BY " & groupCols)

            '.AppendLine("    UNION ALL")

            '.AppendLine("    SELECT FORMAT(A.CHALLANDATE,''MMM,yyyy'') + ''_Amt'' AS MonthType,")
            '.AppendLine("           SUM(A.AMOUNT) AS Value, B.ItemName, C.LoomNo")
            '.AppendLine("    FROM TRNCHALLAN A")
            '.AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            '.AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            '.AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter)
            '.AppendLine("    GROUP BY " & groupCols)

            '.AppendLine(") AS SourceData")
            '.AppendLine("PIVOT (")
            '.AppendLine("    SUM(Value)")
            '.AppendLine("    FOR MonthType IN (' + @cols + ')")
            '.AppendLine(") AS PivotResult;';")

            '.AppendLine("EXEC sp_executesql @query;")




            '.AppendLine("DECLARE @cols NVARCHAR(MAX);")
            '.AppendLine("DECLARE @query NVARCHAR(MAX);")

            ''--- Dynamic month columns
            '.AppendLine("SELECT @cols = STUFF((")
            '.AppendLine("    SELECT DISTINCT ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy')+'_Qty')")
            '.AppendLine("          + ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+','+FORMAT(A.CHALLANDATE,'yyyy')+'_Amt')")
            '.AppendLine("    FROM TRNCHALLAN A")
            '.AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            '.AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            '.AppendLine("    WHERE A.BOOKCODE='0001-000000155'" & filter)
            '.AppendLine("    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'');")

            '.AppendLine("IF @cols IS NULL OR LEN(@cols)=0 SET @cols = '[NoData]';")

            ''--- Dynamic pivot query
            '.AppendLine("SET @query = '")
            '.AppendLine("SELECT * FROM (")
            '.AppendLine("    SELECT FORMAT(A.CHALLANDATE,''MMM,yyyy'') + ''_'' + ''Qty'' AS MonthType,")
            '.AppendLine("           SUM(A.MTR_WEIGHT) AS Value,B.ItemName,c.LoomNo")
            '.AppendLine("    FROM TRNCHALLAN A")
            '.AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            '.AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            '.AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter)
            '.AppendLine("    GROUP BY  FORMAT(A.CHALLANDATE,''MMM,yyyy''),B.ItemName,c.LoomNo")

            '.AppendLine("    UNION ALL")

            '.AppendLine("    SELECT  FORMAT(A.CHALLANDATE,''MMM,yyyy'') + ''_'' + ''Amt'' AS MonthType,")
            '.AppendLine("           SUM(A.AMOUNT) AS Value,B.ItemName,c.LoomNo")
            '.AppendLine("    FROM TRNCHALLAN A")
            '.AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            '.AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            '.AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter)
            '.AppendLine("    GROUP BY FORMAT(A.CHALLANDATE,''MMM,yyyy''),B.ItemName,c.LoomNo")

            '.AppendLine(") AS SourceData")
            '.AppendLine("PIVOT (")
            '.AppendLine("    SUM(Value)")
            '.AppendLine("    FOR MonthType IN (' + @cols + ')")
            '.AppendLine(") AS PivotResult;';")

            '.AppendLine("EXEC sp_executesql @query;")


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