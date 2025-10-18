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


                ' 🔹 Formatting options
                bandedView.OptionsView.ShowBands = True
                bandedView.OptionsView.ShowAutoFilterRow = True
                bandedView.OptionsBehavior.Editable = False
                bandedView.OptionsView.ShowFooter = True
                bandedView.BestFitColumns()
                ' Enable vertical scrolling
                bandedView.OptionsView.ColumnAutoWidth = False   ' Allows horizontal scroll if columns exceed width
                bandedView.OptionsView.ShowIndicator = True      ' Row indicator (optional)
                bandedView.OptionsView.ShowFooter = True         ' Footer if needed

                ' Enable scrolling
                bandedView.OptionsBehavior.Editable = False      ' Example: make read-only
                bandedView.OptionsView.ColumnAutoWidth = False   ' Prevent auto-stretch
                bandedView.OptionsView.EnableAppearanceEvenRow = True
                bandedView.OptionsView.EnableAppearanceOddRow = True

                ' Scroll settings
                bandedView.OptionsView.RowAutoHeight = True
                bandedView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                bandedView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always

                ' 🔹 Create GridBands
                Dim LoomNo As New GridBand() With {.Caption = "Loom No"}
                Dim Itemname As New GridBand() With {.Caption = "Item Name"}
                Dim challanDate As New GridBand() With {.Caption = "Date"}

                Select Case Txt_ViewType.Text

                    Case "Month+Loom Wise"
                        Dim colLoom As BandedGridColumn = AddBandedColumn(bandedView, "LoomNo", "")
                        LoomNo.Columns.Add(colLoom)
                        bandedView.Bands.Add(LoomNo)

                        ' ✅ Left align text
                        colLoom.AppearanceCell.Options.UseTextOptions = True
                        colLoom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

                        ' ❌ Hide column header (only band header visible)
                        colLoom.Caption = ""
                        colLoom.OptionsColumn.ShowCaption = False

                    Case "Month+Item Wise"
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        Itemname.Columns.Add(colItem)
                        bandedView.Bands.Add(Itemname)

                        colItem.AppearanceCell.Options.UseTextOptions = True
                        colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        colItem.Caption = ""
                        colItem.OptionsColumn.ShowCaption = False

                    Case "Loom+Item Wise"
                        Dim colLoom As BandedGridColumn = AddBandedColumn(bandedView, "LoomNo", "")
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        LoomNo.Columns.Add(colLoom)
                        Itemname.Columns.Add(colItem)
                        bandedView.Bands.Add(LoomNo)
                        bandedView.Bands.Add(Itemname)

                        For Each col In {colLoom, colItem}
                            col.AppearanceCell.Options.UseTextOptions = True
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                            col.Caption = ""
                            col.OptionsColumn.ShowCaption = False
                        Next

                    Case "Detail"
                        Dim colLoom As BandedGridColumn = AddBandedColumn(bandedView, "LoomNo", "")
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        Dim colDate As BandedGridColumn = AddBandedColumn(bandedView, "CHALLANDATE", "")
                        LoomNo.Columns.Add(colLoom)
                        Itemname.Columns.Add(colItem)
                        challanDate.Columns.Add(colDate)

                        bandedView.Bands.Add(LoomNo)
                        bandedView.Bands.Add(Itemname)
                        bandedView.Bands.Add(challanDate)

                        For Each col In {colLoom, colItem, colDate}
                            col.AppearanceCell.Options.UseTextOptions = True
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                            col.Caption = ""
                            col.OptionsColumn.ShowCaption = False
                        Next

                    Case Else
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        Itemname.Columns.Add(colItem)
                        bandedView.Bands.Add(Itemname)

                        colItem.AppearanceCell.Options.UseTextOptions = True
                        colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        colItem.Caption = ""
                        colItem.OptionsColumn.ShowCaption = False
                End Select

                ' ✅ Optional: Make band headers bold and centered
                For Each band In bandedView.Bands
                    band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                    band.AppearanceHeader.Options.UseFont = True
                    band.AppearanceHeader.Options.UseTextOptions = True
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                Next

                ' 🔹 MONTH BANDS (for Qty & Amt)
                Dim dt As DataTable = GridControl1.DataSource
                Dim monthNames As New List(Of String) From {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

                For Each m In monthNames
                    If dt.Columns.Contains(m & "_Qty") OrElse dt.Columns.Contains(m & "_Amt") Then
                        Dim band As New GridBand() With {.Caption = m}

                        If dt.Columns.Contains(m & "_Qty") Then
                            band.Columns.Add(AddBandedColumn(bandedView, m & "_Qty", "Qty"))
                        End If
                        If dt.Columns.Contains(m & "_Amt") Then
                            band.Columns.Add(AddBandedColumn(bandedView, m & "_Amt", "Amt"))
                        End If

                        band.AppearanceHeader.Options.UseTextOptions = True
                        band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                        band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                        band.AppearanceHeader.BackColor = Color.LightGray

                        bandedView.Bands.Add(band)
                    End If
                Next

                '_DevGridColumSizeAutoAdjestWhiotTickmarck(GridControl1, FirstStage)

                'AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
                SetBandedGridViewAppearance(bandedView)
                ApplyFooterSummary(bandedView)
                bandedView.BestFitColumns()
                FirstStage.Focus()
                FirstStage.BestFitColumns()
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
            ' 🔹 Set header background color
            band.AppearanceHeader.BackColor = Color.Khaki  ' Change to any color
            band.AppearanceHeader.BackColor2 = Color.Navy      ' Optional: for gradient
            band.AppearanceHeader.GradientMode = Drawing2D.LinearGradientMode.Vertical  ' Optional: gradient
            band.AppearanceHeader.ForeColor = Color.White
            ' Columns inside the band
            For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In band.Columns
                ' Header font and alignment
                col.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                col.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                ' 🔹 Set column header background color
                col.AppearanceHeader.BackColor = Color.LightBlue    ' Change as needed
                col.AppearanceHeader.BackColor2 = Color.Navy        ' Optional gradient
                col.AppearanceHeader.GradientMode = Drawing2D.LinearGradientMode.Vertical  ' Optional gradient
                col.AppearanceHeader.ForeColor = Color.White        ' Optional text color
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
            Dim orderCols As String = ""

            Dim dateFilter As String = ""

            If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
                ' Double single-quotes for dynamic SQL
                dateFilter = " AND A.CHALLANDATE >=  '" & txt_From.Date_for_Database & "' And A.CHALLANDATE <=  '" & txt_To.Date_for_Database & "'"
            End If

            Select Case Txt_ViewType.Text
                Case "Month+Loom Wise"
                    filter = " AND C.LoomNo IS NOT NULL " & dateFilter
                    groupCols = "C.LoomNo, FORMAT(A.CHALLANDATE,''MMM'')"
                    selectCols = "C.LoomNo, FORMAT(A.CHALLANDATE,''MMM'') AS MonthName"
                    orderCols = "LoomNo, MonthName"

                Case "Month+Item Wise"
                    filter = " AND B.ItemName IS NOT NULL " & dateFilter
                    groupCols = "B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                    selectCols = "B.ItemName, FORMAT(A.CHALLANDATE,''MMM'') AS MonthName"
                    orderCols = "ItemName, MonthName"

                Case "Loom+Item Wise"
                    filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL " & dateFilter
                    groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                    selectCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'') AS MonthName"
                    orderCols = "LoomNo, ItemName, MonthName"

                Case "Detail"
                    filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL " & dateFilter
                    groupCols = "C.LoomNo, B.ItemName,A.CHALLANDATE, FORMAT(A.CHALLANDATE,''MMM'')"
                    selectCols = "C.LoomNo, B.ItemName,A.CHALLANDATE, FORMAT(A.CHALLANDATE,''MMM'') AS MonthName"
                    orderCols = "CHALLANDATE,LoomNo, ItemName, MonthName"

                Case Else
                    filter = dateFilter
                    groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                    selectCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'') AS MonthName"
                    orderCols = "LoomNo, ItemName, MonthName"
            End Select

            ' --- Build the dynamic SQL
            .AppendLine("DECLARE @cols NVARCHAR(MAX);")
            .AppendLine("DECLARE @query NVARCHAR(MAX);")
            .AppendLine("SELECT @cols = STUFF((")
            .AppendLine("    SELECT DISTINCT ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+'_Qty') + ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+'_Amt')")
            .AppendLine("    FROM TRNCHALLAN A")
            .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            .AppendLine("    WHERE A.BOOKCODE='0001-000000155'" & filter)  ' <-- double quotes for SQL
            .AppendLine("    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'');")
            .AppendLine("IF @cols IS NULL OR LEN(@cols)=0 SET @cols = '[NoData]';")

            .AppendLine("SET @query = '")
            .AppendLine("SELECT " & orderCols & ", ' + @cols + '")
            .AppendLine("FROM (")
            .AppendLine("    SELECT " & selectCols & ", FORMAT(A.CHALLANDATE,''MMM'') + ''_Qty'' AS MonthType, SUM(A.MTR_WEIGHT) AS Value")
            .AppendLine("    FROM TRNCHALLAN A")
            .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            .AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter.Replace("'", "''"))
            .AppendLine("    GROUP BY " & groupCols)
            .AppendLine("    UNION ALL")
            .AppendLine("    SELECT " & selectCols & ", FORMAT(A.CHALLANDATE,''MMM'') + ''_Amt'' AS MonthType, SUM(A.AMOUNT) AS Value")
            .AppendLine("    FROM TRNCHALLAN A")
            .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
            .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
            .AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter.Replace("'", "''"))
            .AppendLine("    GROUP BY " & groupCols)
            .AppendLine(") AS SourceData")
            .AppendLine("PIVOT (SUM(Value) FOR MonthType IN (' + @cols + ')) AS PivotResult")
            .AppendLine("ORDER BY " & orderCols & ";'")

            .AppendLine("EXEC sp_executesql @query;")
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