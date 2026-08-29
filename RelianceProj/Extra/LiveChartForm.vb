Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.CodeParser
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Globalization

Public Class LiveChartForm
    ' 🔹 APNI LOCAL SQL CONNECTION STRING YAHA SET KAREIN
    Public Property ConnectionString As String = "Data Source=DESKTOP-TBSN6SV\SQLEXPRESS;database=Accounts39_142026103929;Integrated Security=SSPI;persist security info=True"
    'Public Property ConnectionString As String
    Public Property FromDate As String

    Public Property ToDate As String
    Private selectedDimension As String = "CityWise"
    Private mainDataTable As DataTable
    Private currentView As String = "PIE" ' Default view: PIE, BAR, LINE, TABLE

    Private maxChartAmount As Decimal = 0D
    Private maxChartColor As Color = Color.FromArgb(40, 53, 147)
    ' Har graph item ka color store karne ke liye
    Private chartPointColors As New Dictionary(Of String, Color)
    Private lastHoverArgument As String = ""
    Private hoveredSeriesPoint As SeriesPoint = Nothing
    Private normalBannerColor As Color = Color.White

    Private hoveredArgument As String = Nothing
    Private hoveredAmount As Decimal = 0D
    Private isChartHovered As Boolean = False
    'Bar chart ke liye
    Private hoveredBarIndex As Integer = -1
    Private currentChartXColumn As String = ""
    Private hoveredQty As Decimal = 0D
    ' Sleek UI Color Palette matching your images
    Private ReadOnly colorPalette As Color() = {
        Color.FromArgb(40, 53, 147),   ' Dark Navy Blue (#283593)
        Color.FromArgb(211, 47, 47),   ' Red (#D32F2F)
        Color.FromArgb(0, 137, 123),   ' Teal Green (#00897B)
        Color.FromArgb(123, 31, 162),  ' Purple (#7B1FA2)
        Color.FromArgb(255, 152, 0),   ' Orange (#FF9800)
        Color.FromArgb(3, 169, 244)    ' Light Blue (#03A9F4)
    }
    Private Sub ChartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        'dtpFromDate1.Text = FromDate
        'dtpToDate1.Text = ToDate
        dtpFromDate1.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        dtpToDate1.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(dtpFromDate1)
        Generate_Date_For_DataBase(dtpToDate1)
        Dim buttons() As DevExpress.XtraEditors.SimpleButton = {btnViewPie, btnViewBar, btnViewLine, btnViewTable}
        For Each btn As DevExpress.XtraEditors.SimpleButton In buttons
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
            btn.Appearance.BorderColor = Color.FromArgb(200, 210, 220)
            btn.Appearance.Options.UseBorderColor = True
        Next
        ' Set default view button style
        SetActiveViewButton(btnViewPie)
        ShowView("PIE")
    End Sub

    ' 🔹 SQL DATA FETCH & UPDATE ENGINE
    Private Async Function FetchAndRenderData() As Task
        Try
            ProgressBar1.Style = ProgressBarStyle.Marquee
            ProgressBar1.Visible = True
            BtnView.Enabled = False
            '==================================================
            ' Accordion se selected Dimension
            '==================================================
            Dim chartType As String = selectedDimension
            'Dim fromDate As String = dtpFromDate.Value.ToString("yyyy-MM-dd")
            'Dim toDate As String = dtpToDate.Value.ToString("yyyy-MM-dd")
            Dim fromDateValue As Date
            Dim toDateValue As Date
            If Not Date.TryParseExact(dtpFromDate1.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fromDateValue) Then
                MessageBox.Show("Please enter a valid From Date in dd/MM/yyyy format.")
                Exit Function
            End If
            If Not Date.TryParseExact(dtpToDate1.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, toDateValue) Then
                MessageBox.Show("Please enter a valid To Date in dd/MM/yyyy format.")
                Exit Function
            End If
            '==================================================
            ' Dynamic Query Generate
            ' Month Wise / Normal Wise
            '==================================================
            Dim sqlQuery As String = ""
            If chartType.IndexOf("Month", StringComparison.OrdinalIgnoreCase) >= 0 Then
                '----------------------------------------------
                ' MONTH WISE QUERY
                '----------------------------------------------
                'sqlQuery = GetDynamicChartMonthSqlQuery(chartType, Nothing, Nothing, fromDate:=fromDate, toDate:=toDate)
                sqlQuery = GetDynamicChartMonthSqlQuery(chartType, Nothing, Nothing, fromDate:=fromDateValue, toDate:=toDateValue)
            Else
                '----------------------------------------------
                ' NORMAL QUERY
                '----------------------------------------------
                sqlQuery = GetDynamicChartSqlQuery(chartType, fromDate:=fromDateValue, toDate:=toDateValue)
            End If
            '==================================================
            ' Data Load
            '==================================================
            mainDataTable = New DataTable()
            Await Task.Run(Sub()
                               Using conn As New SqlConnection(ConnectionString)
                                   conn.Open()
                                   Using cmd As New SqlCommand(sqlQuery, conn)
                                       cmd.CommandTimeout = 600
                                       Using adapter As New SqlDataAdapter(cmd)
                                           adapter.Fill(mainDataTable)
                                       End Using
                                   End Using
                               End Using
                           End Sub
        )
            '==================================================
            ' KPI Cards
            '==================================================
            UpdateKPICards(mainDataTable)
            '==================================================
            ' Current View Render
            '==================================================
            RenderCurrentView()
        Catch ex As Exception
            MessageBox.Show("Unable to load chart data. " & ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ProgressBar1.Visible = False
            BtnView.Enabled = True
        End Try
    End Function

    ' 🔹 RENDER ENGINE FOR SELECTED DEVEXPRESS VIEW
    Private Sub RenderCurrentView()
        If mainDataTable Is Nothing OrElse mainDataTable.Rows.Count = 0 Then
            Exit Sub
        End If
        ' City + Item / Party + Item etc. ke liye
        ' combined display column create/update karega
        Dim xCol As String = PrepareChartDisplayColumn(mainDataTable)
        Select Case currentView.ToUpper()
            Case "PIE"
                RenderDevExpressChart(ViewType.Doughnut, xCol)
            Case "BAR"
                RenderDevExpressChart(ViewType.Bar, xCol)
            Case "LINE"
                RenderDevExpressChart(ViewType.SplineArea, xCol)
            Case "TABLE"
                RenderDevExpressGrid()
        End Select
    End Sub

    Private Function PrepareChartDisplayColumn(ByVal dt As DataTable) As String
        If dt Is Nothing OrElse dt.Columns.Count = 0 Then
            Return ""
        End If
        Dim displayColumnName As String = "ChartLabel"
        If Not dt.Columns.Contains(displayColumnName) Then
            dt.Columns.Add(displayColumnName, GetType(String))
        End If
        For Each row As DataRow In dt.Rows
            Dim parts As New List(Of String)
            ' Blank values automatically skip hongi
            AddChartLabelPart(parts, row, "CityName")
            AddChartLabelPart(parts, row, "PartyName")
            AddChartLabelPart(parts, row, "AgentName")
            AddChartLabelPart(parts, row, "ItemName")
            AddChartLabelPart(parts, row, "Shade")
            AddChartLabelPart(parts, row, "DesignName")
            If parts.Count > 0 Then
                row(displayColumnName) = String.Join(" | ", parts)
            Else
                ' Agar koi bhi dimension value nahi hai
                ' fallback dimension column check karega
                Dim xCol As String = GetDimensionColumnName(dt)
                If Not String.IsNullOrWhiteSpace(xCol) AndAlso dt.Columns.Contains(xCol) AndAlso Not IsDBNull(row(xCol)) AndAlso Not String.IsNullOrWhiteSpace(row(xCol).ToString()) Then
                    row(displayColumnName) = row(xCol).ToString().Trim()
                Else
                    ' Blank row ko ChartLabel blank rakho
                    row(displayColumnName) = ""
                End If
            End If
        Next
        ' IMPORTANT:
        ' Chart mein blank labels wali rows nahi jaani chahiye
        Dim blankRows = dt.AsEnumerable().Where(Function(r) String.IsNullOrWhiteSpace(If(r.IsNull(displayColumnName), "", r(displayColumnName).ToString()))).ToList()
        For Each row In blankRows
            dt.Rows.Remove(row)
        Next
        dt.AcceptChanges()
        Return displayColumnName
    End Function
    Private Sub AddChartLabelPart(ByVal parts As List(Of String), ByVal row As DataRow, ByVal columnName As String)
        If Not row.Table.Columns.Contains(columnName) Then Exit Sub
        If IsDBNull(row(columnName)) Then Exit Sub
        Dim value As String = row(columnName).ToString().Trim()
        ' Blank / Empty / Spaces ko skip karega
        If String.IsNullOrWhiteSpace(value) Then Exit Sub
        parts.Add(value)
    End Sub
    ' 🔹 DEVEXPRESS CHART CONTROL RENDER ENGINE (Pie, Bar, Line)
    Private Sub RenderDevExpressChart(ByVal chartType As ViewType, ByVal xCol As String)
        If DevExpressChartControl Is Nothing Then Exit Sub
        If mainDataTable Is Nothing OrElse mainDataTable.Rows.Count = 0 Then Exit Sub
        '==========================================
        ' IMPORTANT: Enable Mouse Hit Testing
        '==========================================
        DevExpressChartControl.RuntimeHitTesting = True
        DevExpressChartControl.Series.Clear()
        '==========================================
        ' Find Maximum Amount
        '==========================================
        currentChartXColumn = xCol
        maxChartAmount = 0D
        Dim maxRow As DataRow = Nothing
        maxChartAmount = Convert.ToDecimal(mainDataTable.Compute("MAX(Amount)", ""))
        If mainDataTable IsNot Nothing AndAlso mainDataTable.Rows.Count > 0 Then
            Dim maxAmount As Decimal = Decimal.MinValue
            For Each row As DataRow In mainDataTable.Rows
                If Not IsDBNull(row("Amount")) Then
                    Dim amount As Decimal = Convert.ToDecimal(row("Amount"))
                    If amount > maxAmount Then
                        maxAmount = amount
                        maxRow = row
                    End If
                End If
            Next
            maxChartAmount = maxAmount
        End If
        If maxRow IsNot Nothing Then
            maxChartColor = Color.FromArgb(0, 137, 123)
            pnlTopBanner.BackColor = maxChartColor
            lblTopBannerTitle.ForeColor = Color.White
            lblTopBannerSub.ForeColor = Color.White
        End If
        '==========================================
        ' Create Series
        '==========================================
        Dim series As New Series("Sales Data", chartType)
        series.DataSource = mainDataTable
        series.ArgumentDataMember = xCol
        series.ValueDataMembers.AddRange(New String() {"Amount"})
        '==========================================
        ' IMPORTANT: Show Labels
        '==========================================
        series.LabelsVisibility = DefaultBoolean.True
        DevExpressChartControl.Series.Add(series)
        ' ==========================================
        ' Assign colors for each graph point
        ' ==========================================
        chartPointColors.Clear()
        For i As Integer = 0 To mainDataTable.Rows.Count - 1
            Dim argumentName As String = mainDataTable.Rows(i)(xCol).ToString()
            chartPointColors(argumentName) = colorPalette(i Mod colorPalette.Length)
        Next
        '==========================================
        ' Doughnut / PIE Settings
        '==========================================
        If chartType = ViewType.Doughnut Then
            Dim doughnutView As DoughnutSeriesView = TryCast(series.View, DoughnutSeriesView)
            If doughnutView IsNot Nothing Then
                doughnutView.HoleRadiusPercent = 60
                doughnutView.RuntimeExploding = True
                doughnutView.ExplodedDistancePercentage = 25
            End If
            series.Label.TextPattern = "{A}: {V:n2} ({VP:P0})"
            '==========================================
            ' Line Settings
            '==========================================
        ElseIf chartType = ViewType.SplineArea Then
            Dim splineAreaView As SplineAreaSeriesView = TryCast(series.View, SplineAreaSeriesView)
            If splineAreaView IsNot Nothing Then
                splineAreaView.MarkerVisibility = DefaultBoolean.True
                splineAreaView.Color = Color.FromArgb(3, 169, 244)
            End If
            series.LabelsVisibility = DefaultBoolean.True
        ElseIf chartType = ViewType.Spline Then
            Dim splineView As SplineSeriesView =
            TryCast(series.View, SplineSeriesView)
            If splineView IsNot Nothing Then
                splineView.MarkerVisibility = DefaultBoolean.True
                splineView.Color = Color.FromArgb(3, 169, 244)
            End If
            series.LabelsVisibility = DefaultBoolean.True
            '==========================================
            ' Bar Settings
            '==========================================
        ElseIf chartType = ViewType.Bar Then
            Dim barView As SideBySideBarSeriesView = TryCast(series.View, SideBySideBarSeriesView)
            If barView IsNot Nothing Then
                barView.ColorEach = True
                barView.BarWidth = 0.6
            End If
            '==========================================
            ' Show Label Above Bar
            '==========================================
            series.LabelsVisibility = DefaultBoolean.True

            Dim barLabel As SideBySideBarSeriesLabel =
        TryCast(series.Label, SideBySideBarSeriesLabel)

            If barLabel IsNot Nothing Then
                barLabel.Position = BarSeriesLabelPosition.Top
            End If
            series.Label.TextPattern = "{V:n2}"
        Else
            maxChartColor = Color.FromArgb(0, 137, 123)
            pnlTopBanner.BackColor = maxChartColor
            lblTopBannerTitle.ForeColor = Color.White
            lblTopBannerSub.ForeColor = Color.White
        End If
        DevExpressChartControl.RefreshData()
        DevExpressChartControl.Invalidate()
        '==========================================
        ' Attach Qty with each Chart Point
        '==========================================
        For Each point As SeriesPoint In series.Points
            Dim argumentName As String = Convert.ToString(point.Argument)
            Dim qty As Decimal = GetHoverQty(argumentName)
            point.Tag = qty
        Next
    End Sub

    Private Sub DevExpressChartControl_MouseMove(
    sender As Object,
    e As MouseEventArgs
) Handles DevExpressChartControl.MouseMove

        Try
            Dim chart As ChartControl = TryCast(sender, ChartControl)
            If chart Is Nothing Then Exit Sub

            Dim hitInfo As ChartHitInfo = chart.CalcHitInfo(e.X, e.Y)

            If hitInfo Is Nothing OrElse hitInfo.SeriesPoint Is Nothing Then
                Exit Sub
            End If

            '==========================================
            ' Selected Graph Point
            '==========================================
            Dim hoverName As String = hitInfo.SeriesPoint.Argument

            Dim hoverAmount As Decimal = 0D
            If hitInfo.SeriesPoint.Values IsNot Nothing AndAlso
           hitInfo.SeriesPoint.Values.Length > 0 Then

                hoverAmount = Convert.ToDecimal(hitInfo.SeriesPoint.Values(0))
            End If

            '==========================================
            ' Find Qty from DataTable
            '==========================================
            Dim hoverQty As Decimal = 0D

            If mainDataTable IsNot Nothing AndAlso
           mainDataTable.Columns.Contains("Qty") Then

                Dim foundRows() As DataRow =
                mainDataTable.Select(
                    "[" & currentChartXColumn & "] = '" &
                    hoverName.Replace("'", "''") & "'"
                )

                If foundRows.Length > 0 AndAlso
               Not IsDBNull(foundRows(0)("Qty")) Then

                    hoverQty = Convert.ToDecimal(foundRows(0)("Qty"))
                End If

            End If

            '==========================================
            ' Update Hover Banner
            '==========================================
            UpdateChartHoverBanner(
            hoverName,
            hoverAmount,
            hoverQty
        )

        Catch ex As Exception
            ' Optional: Debug.Print(ex.Message)
        End Try

    End Sub
    Private Sub DevExpressChartControl_MouseLeave(sender As Object, e As EventArgs) Handles DevExpressChartControl.MouseLeave
        isChartHovered = False
        hoveredArgument = Nothing
        pnlTopBanner.BackColor = maxChartColor
        lblTopBannerTitle.ForeColor = Color.White
        lblTopBannerSub.ForeColor = Color.White
        DevExpressChartControl.Invalidate()
    End Sub

    Private Sub HandleBarHover(chart As ChartControl, mouseLocation As Point)

        Try

            If mainDataTable Is Nothing OrElse
           mainDataTable.Rows.Count = 0 Then Exit Sub

            If chart.Series.Count = 0 Then Exit Sub

            Dim series As Series = chart.Series(0)

            '==================================================
            ' Chart Hit Information
            '==================================================
            Dim hitInfo As ChartHitInfo =
            chart.CalcHitInfo(mouseLocation)

            If hitInfo Is Nothing Then Exit Sub

            '==================================================
            ' BAR POINT FOUND
            '==================================================
            If hitInfo.SeriesPoint IsNot Nothing Then

                Dim point As SeriesPoint = hitInfo.SeriesPoint

                If point.Values Is Nothing OrElse
               point.Values.Length = 0 Then Exit Sub

                '-------------------------------
                ' Name / Argument
                '-------------------------------
                hoveredArgument = Convert.ToString(point.Argument)

                '-------------------------------
                ' Amount
                '-------------------------------
                hoveredAmount = Convert.ToDecimal(point.Values(0))

                '-------------------------------
                ' Qty from DataTable
                '-------------------------------
                hoveredQty = GetHoverQty(hoveredArgument)

                isChartHovered = True

                '-------------------------------
                ' Update Banner
                '-------------------------------
                UpdateChartHoverBanner(
                hoveredArgument,
                hoveredAmount,
                hoveredQty
            )

                chart.Invalidate()
                Exit Sub

            End If

            '==================================================
            ' If SeriesPoint is Nothing
            '==================================================
            If hitInfo.Series Is Nothing Then Exit Sub

            '==================================================
            ' Find closest bar
            '==================================================
            Dim bestPoint As SeriesPoint = Nothing
            Dim bestDistance As Double = Double.MaxValue

            For Each point As SeriesPoint In series.Points

                If point.Values Is Nothing OrElse
               point.Values.Length = 0 Then Continue For

                'Aapka existing closest-point logic yahan rahega

            Next

            If bestPoint Is Nothing Then Exit Sub

            '==================================================
            ' Get Name & Amount
            '==================================================
            hoveredArgument = Convert.ToString(bestPoint.Argument)
            hoveredAmount = Convert.ToDecimal(bestPoint.Values(0))

            '==================================================
            ' Get Qty
            '==================================================
            hoveredQty = GetHoverQty(hoveredArgument)

            isChartHovered = True

            '==================================================
            ' Banner
            '==================================================
            UpdateChartHoverBanner(
            hoveredArgument,
            hoveredAmount,
            hoveredQty
        )

            chart.Invalidate()

        Catch ex As Exception
            Debug.Print("HandleBarHover Error: " & ex.Message)
        End Try

    End Sub
    Private Function GetHoverQty(argumentName As String) As Decimal

        Try
            If mainDataTable Is Nothing OrElse
           mainDataTable.Rows.Count = 0 Then Return 0D

            If Not mainDataTable.Columns.Contains("Qty") Then Return 0D

            If String.IsNullOrWhiteSpace(currentChartXColumn) Then Return 0D

            For Each row As DataRow In mainDataTable.Rows

                If Convert.ToString(row(currentChartXColumn)).Trim() =
               argumentName.Trim() Then

                    If Not IsDBNull(row("Qty")) Then
                        Return Convert.ToDecimal(row("Qty"))
                    End If
                End If
            Next
        Catch ex As Exception
            Debug.Print("GetHoverQty Error: " & ex.Message)
        End Try
        Return 0D

    End Function



    Private Sub UpdateChartHoverBanner(
    hoverName As String,
    hoverAmount As Decimal,
    hoverQty As Decimal
)

        Try

            Dim selectedColor As Color = Color.LightGray

            If chartPointColors.ContainsKey(hoverName) Then
                selectedColor = chartPointColors(hoverName)
            End If

            Dim hoverColor As Color =
            ControlPaint.Light(selectedColor, 0.25F)

            '==========================================
            ' Maximum Amount Highlight
            '==========================================
            If Math.Abs(hoverAmount - maxChartAmount) < 0.0001D Then
                hoverColor = Color.FromArgb(0, 137, 123)
            End If

            '==========================================
            ' Update Banner
            '==========================================
            pnlTopBanner.BackColor = hoverColor

            lblTopBannerTitle.Text = hoverName

            lblTopBannerSub.Text = "Amt : " & hoverAmount.ToString("#,##0.00") & "  |   Qty : " & hoverQty.ToString("#,##0.00")

            lblTopBannerTitle.ForeColor = Color.White
            lblTopBannerSub.ForeColor = Color.White

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    ' 🔹 DEVEXPRESS GRID CONTROL (EXCEL-LIKE TABLE) RENDER
    Private Sub DevExpressChartControl_CustomDrawSeriesPoint(sender As Object, e As CustomDrawSeriesPointEventArgs) Handles DevExpressChartControl.CustomDrawSeriesPoint
        Try
            If e.SeriesPoint Is Nothing Then Exit Sub
            If e.SeriesPoint.Values Is Nothing OrElse e.SeriesPoint.Values.Length = 0 Then Exit Sub
            Dim argumentName As String = Convert.ToString(e.SeriesPoint.Argument)
            Dim pointValue As Decimal = Convert.ToDecimal(e.SeriesPoint.Values(0))
            Dim pointColor As Color = Color.LightGray
            '==========================================
            ' Normal Selected Color
            '==========================================
            If chartPointColors.ContainsKey(argumentName) Then
                pointColor = chartPointColors(argumentName)
            End If
            '==========================================
            ' Maximum Amount
            '==========================================
            If Math.Abs(pointValue - maxChartAmount) < 0.0001D Then
                pointColor = Color.FromArgb(0, 137, 123)
            End If
            '==========================================
            ' HOVERED POINT
            '==========================================
            If isChartHovered AndAlso String.Equals(argumentName, hoveredArgument, StringComparison.OrdinalIgnoreCase) Then
                ' Maximum already special color hai
                If Math.Abs(pointValue - maxChartAmount) < 0.0001D Then
                    pointColor = Color.FromArgb(0, 137, 123)
                Else
                    pointColor = ControlPaint.Light(pointColor, 0.25F)
                End If
            End If
            '==========================================
            ' Apply Color
            '==========================================
            If e.SeriesDrawOptions IsNot Nothing Then
                e.SeriesDrawOptions.Color = pointColor
            End If
            Dim amount As Decimal = 0D

            If e.SeriesPoint.Values IsNot Nothing AndAlso
           e.SeriesPoint.Values.Length > 0 Then

                amount = Convert.ToDecimal(e.SeriesPoint.Values(0))

            End If

            '==========================================
            ' Get Qty from DataTable
            '==========================================
            Dim qty As Decimal = GetHoverQty(argumentName)

            '==========================================
            ' Show Qty + Amount on all Graph Types
            '==========================================
            e.LabelText =
            argumentName & vbCrLf &
            "Amt: " & amount.ToString("#,##0.00") & vbCrLf &
            "Qty: " & qty.ToString("#,##0.00")

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RenderDevExpressGrid()
        Try
            ' ==============================
            ' 1. Validate Data
            ' ==============================
            If mainDataTable Is Nothing Then Exit Sub
            EnsureGridControl()
            ' ==============================
            ' 2. Ensure GridControl Exists
            ' ==============================
            If DevExpressGridControl Is Nothing Then
                MessageBox.Show("DevExpressGridControl Is Not initialized. Please add the GridControl To the form designer.", "Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            ' ==============================
            ' 3. Assign DataSource
            ' ==============================
            DevExpressGridControl.DataSource = mainDataTable
            ' ==============================
            ' 4. Get / Create GridView
            ' ==============================
            Dim gridView As GridView = TryCast(DevExpressGridControl.MainView, GridView)
            If gridView Is Nothing Then
                gridView = New GridView(DevExpressGridControl)

                DevExpressGridControl.MainView = gridView
                DevExpressGridControl.ViewCollection.Add(gridView)
            End If
            If gridView IsNot Nothing Then
                If gridView.Columns("ChartName") IsNot Nothing Then
                    gridView.Columns("ChartName").Visible = False
                End If
            End If
            ' ==============================
            ' 5. Grid Settings
            ' ==============================
            gridView.OptionsBehavior.Editable = False
            ' Auto Filter Row
            gridView.OptionsView.ShowAutoFilterRow = True
            gridView.OptionsView.ShowGroupPanel = False
            ' Find Panel
            gridView.OptionsFind.AlwaysVisible = True
            gridView.OptionsFind.FindMode = FindMode.Always
            ' Filtering
            gridView.OptionsCustomization.AllowFilter = True
            ' Column Size
            gridView.BestFitColumns()
            ' ==============================
            ' 6. Amount Format
            ' ==============================
            If gridView.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                gridView.Columns("Amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                gridView.Columns("Amount").DisplayFormat.FormatString = "₹ #,##0.00"
            End If
            ' ==============================
            ' 7. Qty Format
            ' ==============================
            If gridView.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                gridView.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                gridView.Columns("Qty").DisplayFormat.FormatString = "#,##0.00"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable To render grid: " & ex.Message, "Grid Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EnsureGridControl()
        If DevExpressGridControl Is Nothing Then
            DevExpressGridControl = New DevExpress.XtraGrid.GridControl()
            DevExpressGridControl.Name = "DevExpressGridControl"
            DevExpressGridControl.Dock = DockStyle.Fill
            pnlMainContent.Controls.Add(DevExpressGridControl)
        End If
        Dim gridView As GridView = TryCast(DevExpressGridControl.MainView, GridView)
        If gridView Is Nothing Then
            gridView = New GridView(DevExpressGridControl)
            DevExpressGridControl.MainView = gridView
        End If
    End Sub

    ' 🔹 TOP KPI CARDS & HIGHLIGHT BANNER UPDATE
    Private Sub UpdateKPICards(ByVal dt As DataTable)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            lblTotalAmountVal.Text = "₹ 0.00"
            lblTotalQtyVal.Text = "0.00"
            pnlTopBanner.Visible = False
            Exit Sub
        End If
        '==================================================
        ' TOTAL AMOUNT & QTY
        '==================================================
        Dim totalAmt As Decimal = 0D
        Dim totalQty As Decimal = 0D
        If Not IsDBNull(dt.Compute("SUM(Amount)", "")) Then
            totalAmt = Convert.ToDecimal(dt.Compute("SUM(Amount)", ""))
        End If
        If Not IsDBNull(dt.Compute("SUM(Qty)", "")) Then
            totalQty = Convert.ToDecimal(dt.Compute("SUM(Qty)", ""))
        End If
        lblTotalAmountVal.Text = "₹ " & totalAmt.ToString("#,##0.00")
        lblTotalQtyVal.Text = totalQty.ToString("#,##0.00")
        '==================================================
        ' TOP ROW
        '==================================================
        Dim topRow As DataRow = dt.Rows(0)
        ' City + Item + Party etc. ke according name
        Dim topName As String = GetCombinedDimensionName(topRow, dt)
        Dim topAmt As Decimal = 0D
        Dim topQty As Decimal = 0D
        If Not IsDBNull(topRow("Amount")) Then
            topAmt = Convert.ToDecimal(topRow("Amount"))
        End If
        If Not IsDBNull(topRow("Qty")) Then
            topQty = Convert.ToDecimal(topRow("Qty"))
        End If
        '==================================================
        ' BANNER
        '==================================================
        lblTopBannerTitle.Text = topName.ToUpper()
        lblTopBannerSub.AutoSize = True
        lblTopBannerSub.Text = "Amt: ₹ " & topAmt.ToString("#,##0.00") & "   |   Qty: " & topQty.ToString("#,##0.00")
        pnlTopBanner.Visible = True
        '==================================================
        ' GRAPH COLOR
        '==================================================
        If chartPointColors.ContainsKey(topName) Then
            maxChartColor = chartPointColors(topName)
        End If

    End Sub

    Private Function GetCombinedDimensionName(ByVal row As DataRow, ByVal dt As DataTable) As String
        Dim nameParts As New List(Of String)
        '==================================================
        ' Order important hai
        '==================================================
        If dt.Columns.Contains("CityName") Then
            If Not IsDBNull(row("CityName")) AndAlso
           Not String.IsNullOrWhiteSpace(row("CityName").ToString()) Then
                nameParts.Add(row("CityName").ToString().Trim())
            End If
        End If
        If dt.Columns.Contains("PartyName") Then
            If Not IsDBNull(row("PartyName")) AndAlso
           Not String.IsNullOrWhiteSpace(row("PartyName").ToString()) Then
                nameParts.Add(row("PartyName").ToString().Trim())
            End If
        End If
        If dt.Columns.Contains("AgentName") Then
            If Not IsDBNull(row("AgentName")) AndAlso
           Not String.IsNullOrWhiteSpace(row("AgentName").ToString()) Then
                nameParts.Add(row("AgentName").ToString().Trim())
            End If
        End If


        If dt.Columns.Contains("ItemName") Then
            If Not IsDBNull(row("ItemName")) AndAlso
           Not String.IsNullOrWhiteSpace(row("ItemName").ToString()) Then

                nameParts.Add(row("ItemName").ToString().Trim())
            End If
        End If


        If dt.Columns.Contains("Shade") Then
            If Not IsDBNull(row("Shade")) AndAlso
           Not String.IsNullOrWhiteSpace(row("Shade").ToString()) Then

                nameParts.Add(row("Shade").ToString().Trim())
            End If
        End If


        If dt.Columns.Contains("DesignName") Then
            If Not IsDBNull(row("DesignName")) AndAlso
           Not String.IsNullOrWhiteSpace(row("DesignName").ToString()) Then

                nameParts.Add(row("DesignName").ToString().Trim())
            End If
        End If


        '==================================================
        ' Combined Result
        '==================================================
        If nameParts.Count > 0 Then
            Return String.Join(" | ", nameParts)
        End If


        ' Fallback
        Dim xCol As String = GetDimensionColumnName(dt)

        If Not String.IsNullOrWhiteSpace(xCol) AndAlso
       dt.Columns.Contains(xCol) AndAlso
       Not IsDBNull(row(xCol)) Then

            Return row(xCol).ToString()
        End If

        Return "N/A"

    End Function

    ' 🔹 VIEW SWITCHING TOGGLE BUTTON HANDLERS (Pie, Bar, Line, Table)
    Private Async Sub btnViewPie_Click(sender As Object, e As EventArgs) Handles btnViewPie.Click
        currentView = "PIE"
        SetActiveViewButton(btnViewPie)
        ShowView("PIE")
        Await FetchAndRenderData()
    End Sub

    Private Async Sub btnViewBar_Click(sender As Object, e As EventArgs) Handles btnViewBar.Click
        currentView = "BAR"
        SetActiveViewButton(btnViewBar)
        ShowView("BAR")
        Await FetchAndRenderData()
    End Sub

    Private Async Sub btnViewLine_Click(sender As Object, e As EventArgs) Handles btnViewLine.Click
        currentView = "LINE"
        SetActiveViewButton(btnViewLine)
        ShowView("LINE")
        Await FetchAndRenderData()
    End Sub

    Private Async Sub btnViewTable_Click(sender As Object, e As EventArgs) Handles btnViewTable.Click
        currentView = "TABLE"
        SetActiveViewButton(btnViewTable)
        ShowView("TABLE")
        Await FetchAndRenderData()
    End Sub
    Private Async Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Await FetchAndRenderData()
    End Sub
    Private Sub SetActiveViewButton(ByVal activeBtn As SimpleButton)
        For Each btn As SimpleButton In {btnViewPie, btnViewBar, btnViewLine, btnViewTable}
            If btn Is activeBtn Then
                btn.Appearance.BackColor = Color.FromArgb(227, 242, 253) ' Light Blue Active
                btn.Appearance.ForeColor = Color.FromArgb(0, 102, 204)
                btn.Appearance.Font = New Font(btn.Appearance.Font, FontStyle.Bold)
            Else
                btn.Appearance.BackColor = Color.White
                btn.Appearance.ForeColor = Color.DimGray
                btn.Appearance.Font = New Font(btn.Appearance.Font, FontStyle.Regular)
            End If
        Next
    End Sub

    Private Sub ShowView(ByVal viewType As String)
        If DevExpressChartControl IsNot Nothing Then
            DevExpressChartControl.Visible = (viewType <> "TABLE")
        End If
        If DevExpressGridControl IsNot Nothing Then
            DevExpressGridControl.Visible = (viewType = "TABLE")
        End If

        RenderCurrentView()
    End Sub

    Private Function GetDimensionColumnName(ByVal dt As DataTable) As String
        For Each col As DataColumn In dt.Columns
            If col.ColumnName <> "Qty" AndAlso col.ColumnName <> "Amount" Then
                Return col.ColumnName
            End If
        Next
        Return dt.Columns(0).ColumnName
    End Function

    ' 🔹 DYNAMIC SQL QUERY GENERATOR (SUPPORTS ALL chartTypes)
    Private Function GetDynamicChartSqlQuery(ByVal chartType As String, ByVal fromDate As String, ByVal toDate As String, Optional ByVal partyName As String = Nothing, Optional ByVal partyCode As String = Nothing, Optional ByVal cityName As String = Nothing, Optional ByVal cityCode As String = Nothing, Optional ByVal agentName As String = Nothing, Optional ByVal agentCode As String = Nothing, Optional ByVal designName As String = Nothing, Optional ByVal designCode As String = Nothing) As String
        '==========================================================
        ' 1. DETERMINE CHART DIMENSIONS
        '==========================================================
        Dim hasCity As Boolean = chartType.IndexOf("City", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasAgent As Boolean = chartType.IndexOf("Agent", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasParty As Boolean = chartType.IndexOf("Party", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasItem As Boolean = chartType.IndexOf("Item", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasShade As Boolean = chartType.IndexOf("Shade", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasDesign As Boolean = chartType.IndexOf("Design", StringComparison.OrdinalIgnoreCase) >= 0
        '==========================================================
        ' 2. EXPLICIT CITY + ITEM
        '==========================================================
        Dim isCityItem As Boolean =
        chartType.IndexOf("CityItemWise", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
        chartType.IndexOf("City + ItemWise", StringComparison.OrdinalIgnoreCase) >= 0 OrElse
        chartType.IndexOf("City ItemWise", StringComparison.OrdinalIgnoreCase) >= 0
        If isCityItem Then
            hasCity = True
            hasItem = True
        End If
        If chartType.Replace(" ", "").Replace("+", "").Equals("CityItemWise", StringComparison.OrdinalIgnoreCase) Then
            hasCity = True
            hasItem = True
        End If
        '==========================================================
        ' 3. REQUIRED JOINS
        '==========================================================
        Dim needPartyJoin As Boolean = hasParty OrElse hasAgent OrElse Not String.IsNullOrWhiteSpace(partyName) OrElse Not String.IsNullOrWhiteSpace(partyCode) OrElse Not String.IsNullOrWhiteSpace(agentName) OrElse Not String.IsNullOrWhiteSpace(agentCode)
        Dim needAgentJoin As Boolean = hasAgent OrElse Not String.IsNullOrWhiteSpace(agentName) OrElse Not String.IsNullOrWhiteSpace(agentCode)
        Dim needCityJoin As Boolean = hasCity OrElse Not String.IsNullOrWhiteSpace(cityName) OrElse Not String.IsNullOrWhiteSpace(cityCode)
        Dim needDesignJoin As Boolean = hasDesign OrElse Not String.IsNullOrWhiteSpace(designName) OrElse Not String.IsNullOrWhiteSpace(designCode)
        '==========================================================
        ' 4. TRANSACTION TABLE
        '==========================================================
        Dim transTable As String
        Dim dateColumn As String
        Dim bookFilter As String
        If needDesignJoin Then
            ' Design data comes from Packing Slip
            transTable = "TrnPackingSlip"
            dateColumn = "A.PACK_SLIP_DATE"
            bookFilter = "G.BOOKCATEGORY = 'PACKING SLIP'"
        Else
            ' Normal sales data
            transTable = "trnInvoiceDetail"
            dateColumn = "A.BillDate"
            bookFilter =
            "G.BOOKCATEGORY = 'INVOICE' AND G.NATURE = 'SALES'"
        End If
        '==========================================================
        ' 5. SELECT / GROUP LISTS
        '==========================================================
        Dim innerSelects As New List(Of String)
        Dim innerGroups As New List(Of String)
        Dim outerSelects As New List(Of String)
        Dim outerGroups As New List(Of String)
        '==========================================================
        ' 6. MEASURES
        '==========================================================
        innerSelects.Add("SUM(A.MTR_WEIGHT) AS Qty")
        innerSelects.Add("SUM(A.RATE * A.MTR_WEIGHT) AS Amount")
        outerSelects.Add("SUM(Qty) AS Qty")
        outerSelects.Add("SUM(Amount) AS Amount")
        '==========================================================
        ' 7. JOINS
        '==========================================================
        Dim joins As New StringBuilder()
        '----------------------------------------------------------
        ' BOOK
        '----------------------------------------------------------
        joins.AppendLine(" LEFT JOIN MSTBOOK AS G " & " ON A.BOOKCODE = G.BOOKCODE ")
        '==========================================================
        ' 8. ITEM
        '==========================================================
        If hasItem Then
            joins.AppendLine(" LEFT JOIN MSTFABRICITEM AS ITEM " &
            " ON A.ITEMCODE = ITEM.ID ")
            innerSelects.Add("ITEM.ITENNAME AS ItemName")
            innerGroups.Add("ITEM.ITENNAME")
            outerSelects.Add("ItemName")
            outerGroups.Add("ItemName")
        End If
        '==========================================================
        ' 9. SHADE
        '==========================================================
        If hasShade Then
            joins.AppendLine(" LEFT JOIN Mst_Fabric_Shade AS SHADE " &
            " ON A.SHADECODE = SHADE.Id ")
            innerSelects.Add("SHADE.SHADE AS Shade")
            innerGroups.Add("SHADE.SHADE")
            outerSelects.Add("Shade")
            outerGroups.Add("Shade")
        End If
        '==========================================================
        ' 10. CITY
        '==========================================================
        If hasCity Then
            joins.AppendLine(" LEFT JOIN MSTCITY AS CITY " &
        " ON A.DESPATCHCODE = CITY.citycode ")
            innerSelects.Add("CITY.cityname AS CityName")
            innerGroups.Add("CITY.cityname")
            outerSelects.Add("CityName")
            outerGroups.Add("CityName")
        End If
        '==========================================================
        ' 11. PARTY
        '==========================================================
        If needPartyJoin Then
            joins.AppendLine(" LEFT JOIN MstMasterAccount AS PARTY " & " ON A.ACCOUNTCODE = PARTY.ACCOUNTCODE ")
            If hasParty Then
                innerSelects.Add("PARTY.ACCOUNTNAME AS PartyName")
                innerGroups.Add("PARTY.ACCOUNTNAME")
                outerSelects.Add("PartyName")
                outerGroups.Add("PartyName")
            End If
        End If
        '==========================================================
        ' 12. AGENT
        '==========================================================
        If needAgentJoin Then
            joins.AppendLine(" LEFT JOIN MstMasterAccount AS AGENT " & " ON PARTY.AGENTCODE = AGENT.ACCOUNTCODE ")
            If hasAgent Then
                innerSelects.Add("AGENT.ACCOUNTNAME AS AgentName")
                innerGroups.Add("AGENT.ACCOUNTNAME")
                outerSelects.Add("AgentName")
                outerGroups.Add("AgentName")
            End If
        End If
        '==========================================================
        ' 13. DESIGN
        '==========================================================
        If needDesignJoin Then
            joins.AppendLine(" LEFT JOIN Mst_Fabric_Design AS DESIGN " & " ON A.DESIGNCODE = DESIGN.Design_code ")
            If hasDesign Then
                innerSelects.Add("DESIGN.Design_Name AS DesignName")
                innerGroups.Add("DESIGN.Design_Name")
                outerSelects.Add("DesignName")
                outerGroups.Add("DesignName")
            End If
        End If
        '==========================================================
        ' 14. DATE CONVERSION
        '==========================================================
        Dim fromDateValue As Date
        Dim toDateValue As Date
        Try
            fromDateValue = Date.ParseExact(fromDate, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)
            toDateValue = Date.ParseExact(toDate, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)
        Catch ex As Exception
            MessageBox.Show("Invalid date format. Please use dd/MM/yyyy.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return String.Empty
        End Try
        '==========================================================
        ' 15. WHERE CLAUSE
        '==========================================================
        Dim whereClause As New StringBuilder()
        whereClause.AppendLine($" WHERE {dateColumn} >= '{fromDateValue:yyyyMMdd}' ")
        whereClause.AppendLine($" AND {dateColumn} < '{toDateValue.AddDays(1):yyyyMMdd}' ")
        whereClause.AppendLine($" AND {bookFilter} ")
        whereClause.AppendLine(" AND G.BEHAVIOUR = 'FINISH' ")
        '==========================================================
        ' 16. PARTY FILTER
        '==========================================================
        If Not String.IsNullOrWhiteSpace(partyName) Then
            whereClause.AppendLine($" AND PARTY.ACCOUNTNAME = '{partyName.Replace("'", "''")}' ")
        End If
        If Not String.IsNullOrWhiteSpace(partyCode) Then
            whereClause.AppendLine($" AND PARTY.ACCOUNTCODE = '{partyCode.Replace("'", "''")}' ")
        End If
        '==========================================================
        ' 17. CITY FILTER
        '==========================================================
        If Not String.IsNullOrWhiteSpace(cityName) Then
            whereClause.AppendLine($" AND CITY.cityname = '{cityName.Replace("'", "''")}' ")
        End If
        If Not String.IsNullOrWhiteSpace(cityCode) Then
            whereClause.AppendLine($" AND CITY.citycode = '{cityCode.Replace("'", "''")}' ")
        End If
        '==========================================================
        ' 18. AGENT FILTER
        '==========================================================
        If Not String.IsNullOrWhiteSpace(agentName) Then
            whereClause.AppendLine($" AND AGENT.ACCOUNTNAME = '{agentName.Replace("'", "''")}' ")
        End If
        If Not String.IsNullOrWhiteSpace(agentCode) Then
            whereClause.AppendLine($" AND PARTY.AGENTCODE = '{agentCode.Replace("'", "''")}' ")
        End If
        '==========================================================
        ' 19. DESIGN FILTER
        '==========================================================
        If Not String.IsNullOrWhiteSpace(designName) Then
            whereClause.AppendLine($" AND DESIGN.Design_Name = '{designName.Replace("'", "''")}' ")
        End If
        If Not String.IsNullOrWhiteSpace(designCode) Then
            whereClause.AppendLine($" AND DESIGN.Design_code = '{designCode.Replace("'", "''")}' ")
        End If
        '==========================================================
        ' 20. INNER GROUP BY
        '==========================================================
        Dim innerGroupByClause As String = ""
        If innerGroups.Count > 0 Then
            innerGroupByClause = " GROUP BY " & String.Join(", ", innerGroups)
        End If
        '==========================================================
        ' 21. OUTER GROUP BY
        '==========================================================
        Dim outerGroupByClause As String = ""
        If outerGroups.Count > 0 Then
            outerGroupByClause = " GROUP BY " & String.Join(", ", outerGroups)
        End If
        '==========================================================
        ' 22. INNER QUERY
        '==========================================================
        Dim innerQuery As String = $"SELECT {String.Join(", ", innerSelects)} " & $"FROM {transTable} AS A " & $"{joins} " & $"{whereClause} " & $"{innerGroupByClause}"
        '==========================================================
        ' 23. TOP 10 ONLY FOR CHART
        '==========================================================
        Dim selectTop As String = ""
        If Not String.Equals(currentView, "TABLE", StringComparison.OrdinalIgnoreCase) Then
            selectTop = "TOP (10) "
        End If
        '==========================================================
        ' 24. FINAL QUERY
        '==========================================================
        Dim finalQuery As String = $"SELECT {selectTop}" & $"{String.Join(", ", outerSelects)} " & $"FROM ( {innerQuery} ) AS Z " & $"{outerGroupByClause} " & $"ORDER BY SUM(Amount) DESC"
        Return finalQuery
    End Function

    Private Async Sub AccordionControl1_ElementClick(sender As Object, e As ElementClickEventArgs) Handles AccordionControl1.ElementClick
        ' Sirf leaf/menu item par click hone par
        If e.Element Is Nothing Then Exit Sub
        Select Case e.Element.Text.Trim()
            Case "City Wise"
                selectedDimension = "City"
            Case "City+Item Wise"
                selectedDimension = "City+Item"
            Case "Agent Wise"
                selectedDimension = "Agent"
            Case "Party Wise"
                selectedDimension = "Party"
            Case "Item Wise"
                selectedDimension = "Item"
            Case "Shade Wise"
                selectedDimension = "Shade"
            Case "Design Wise"
                selectedDimension = "Design"
            Case "Party+Item Wise"
                selectedDimension = "Party+Item"
            Case "Agent+Item Wise"
                selectedDimension = "Agent+Item"
            Case "Month Wise"
                selectedDimension = "Month"
            Case "Month+Item Wise"
                selectedDimension = "Month+Item"
            Case "Month+Party Wise"
                selectedDimension = "Month+Party"
            Case "Month+City Wise"
                selectedDimension = "Month+City"
            Case "Month+Agent Wise"
                selectedDimension = "Month+Agent"
            Case "Month+Item+Design"
                selectedDimension = "Month+Item+Design"
            Case "Month+Item+Design+Shade"
                selectedDimension = "Month+Item+Design+Shade"
            Case Else
                Exit Sub
        End Select
        Await FetchAndRenderData()
    End Sub

    'Month Wise
    Private Function GetDynamicChartMonthSqlQuery(chartType As String, allCode As String, role As String, Optional partyName As String = Nothing, Optional partyCode As String = Nothing, Optional cityName As String = Nothing, Optional cityCode As String = Nothing, Optional agentName As String = Nothing, Optional agentCode As String = Nothing, Optional designName As String = Nothing, Optional designCode As String = Nothing, Optional fromDate As Date? = Nothing, Optional toDate As Date? = Nothing) As String
        Try
            '==========================================================
            ' 1. NORMALIZE CHART TYPE
            '==========================================================
            Dim lowerType As String = If(chartType, "").Trim().ToLowerInvariant()
            '==========================================================
            ' 2. DIMENSION DETECTION
            '==========================================================
            Dim hasMonth As Boolean = lowerType.Contains("month")
            Dim hasCity As Boolean = lowerType.Contains("city")
            Dim hasAgent As Boolean = lowerType.Contains("agent")
            Dim hasParty As Boolean = lowerType.Contains("party")
            Dim hasItem As Boolean = lowerType.Contains("item") OrElse lowerType.Contains("itemname")
            Dim hasShade As Boolean = lowerType.Contains("shade")
            Dim hasDesign As Boolean = lowerType.Contains("design")
            '==========================================================
            ' 3. VIEW DETECTION
            '
            ' IMPORTANT:
            ' currentView se PIE / BAR / LINE / TABLE detect hoga
            '==========================================================
            Dim viewText As String = If(currentView, "").Trim().ToLowerInvariant()
            Dim isTable As Boolean = viewText.Contains("table")
            Dim isPie As Boolean = viewText.Contains("pie") OrElse viewText.Contains("doughnut")
            Dim isBar As Boolean = viewText.Contains("bar") OrElse viewText.Contains("column")
            Dim isLine As Boolean = viewText.Contains("line")
            '==========================================================
            ' 4. TOP 10
            '==========================================================
            Dim applyTop10 As Boolean = Not isTable AndAlso (isPie OrElse isBar OrElse isLine)
            '==========================================================
            ' 5. REQUIRED JOINS
            '==========================================================
            Dim needPartyJoin As Boolean = hasParty OrElse hasAgent OrElse String.Equals(role, "agent", StringComparison.OrdinalIgnoreCase) OrElse Not String.IsNullOrWhiteSpace(partyName) OrElse Not String.IsNullOrWhiteSpace(partyCode) OrElse Not String.IsNullOrWhiteSpace(agentName) OrElse Not String.IsNullOrWhiteSpace(agentCode)
            Dim needAgentJoin As Boolean = hasAgent OrElse Not String.IsNullOrWhiteSpace(agentName) OrElse Not String.IsNullOrWhiteSpace(agentCode)
            Dim needCityJoin As Boolean = hasCity OrElse Not String.IsNullOrWhiteSpace(cityName) OrElse Not String.IsNullOrWhiteSpace(cityCode)
            Dim needDesignJoin As Boolean = hasDesign OrElse Not String.IsNullOrWhiteSpace(designName) OrElse Not String.IsNullOrWhiteSpace(designCode)
            '==========================================================
            ' 6. TRANSACTION TABLE
            '==========================================================
            Dim transTable As String
            Dim dateColumn As String
            Dim bookFilter As String
            If needDesignJoin Then
                transTable = "TrnPackingSlip"
                dateColumn = "A.PACK_SLIP_DATE"
                bookFilter = "G.BOOKCATEGORY = 'PACKING SLIP'"
            Else
                transTable = "trnInvoiceDetail"
                dateColumn = "A.BillDate"
                bookFilter = "G.BOOKCATEGORY = 'INVOICE' " & "AND G.NATURE = 'SALES'"
            End If
            '==========================================================
            ' 7. SELECT / GROUP
            '==========================================================
            Dim selects As New List(Of String)
            Dim groups As New List(Of String)
            '==========================================================
            ' 8. MONTH
            '==========================================================
            If hasMonth Then
                selects.Add($"MONTH({dateColumn}) AS MonthNo")
                selects.Add($"UPPER(DATENAME(MONTH, {dateColumn})) AS Month")
                groups.Add($"MONTH({dateColumn})")
                groups.Add($"DATENAME(MONTH, {dateColumn})")
            End If
            '==========================================================
            ' 9. JOINS
            '==========================================================
            Dim joins As New StringBuilder()
            '----------------------------------------------------------
            ' BOOK
            '----------------------------------------------------------
            joins.AppendLine(" LEFT JOIN MSTBOOK AS G " & " ON A.BOOKCODE = G.BOOKCODE ")
            '----------------------------------------------------------
            ' CITY
            '----------------------------------------------------------
            If needCityJoin Then
                joins.AppendLine(" LEFT JOIN MSTCITY AS CITY " & " ON A.DESPATCHCODE = CITY.citycode ")
                If hasCity Then
                    selects.Add("CITY.cityname AS CityName")
                    groups.Add("CITY.cityname")
                End If
            End If
            '----------------------------------------------------------
            ' PARTY
            '----------------------------------------------------------
            If needPartyJoin Then
                joins.AppendLine(" LEFT JOIN MstMasterAccount AS PARTY " & " ON A.ACCOUNTCODE = PARTY.ACCOUNTCODE ")
                If hasParty Then
                    selects.Add("PARTY.ACCOUNTNAME AS PartyName")
                    groups.Add("PARTY.ACCOUNTNAME")
                End If
            End If
            '----------------------------------------------------------
            ' AGENT
            '----------------------------------------------------------
            If needAgentJoin Then
                joins.AppendLine(" LEFT JOIN MstMasterAccount AS AGENT " & " ON PARTY.AGENTCODE = AGENT.ACCOUNTCODE ")
                If hasAgent Then
                    selects.Add("AGENT.ACCOUNTNAME AS AgentName")
                    groups.Add("AGENT.ACCOUNTNAME")
                End If
            End If
            '----------------------------------------------------------
            ' ITEM
            '----------------------------------------------------------
            If hasItem Then
                joins.AppendLine(" LEFT JOIN MSTFABRICITEM AS ITEM " & " ON A.ITEMCODE = ITEM.ID ")
                selects.Add("ITEM.ITENNAME AS ItemName")
                groups.Add("ITEM.ITENNAME")
            End If
            '----------------------------------------------------------
            ' SHADE
            '----------------------------------------------------------
            If hasShade Then
                joins.AppendLine(" LEFT JOIN Mst_Fabric_Shade AS SHADE " & " ON A.SHADECODE = SHADE.Id ")
                selects.Add("SHADE.SHADE AS Shade")
                groups.Add("SHADE.SHADE")
            End If
            '----------------------------------------------------------
            ' DESIGN
            '----------------------------------------------------------
            If needDesignJoin Then
                joins.AppendLine(" LEFT JOIN Mst_Fabric_Design AS DESIGN " & " ON A.DESIGNCODE = DESIGN.Design_code ")
                If hasDesign Then
                    selects.Add("DESIGN.Design_Name AS DesignName")
                    groups.Add("DESIGN.Design_Name")
                End If
            End If
            '==========================================================
            ' 10. TOTALS
            '==========================================================
            selects.Add("SUM(A.MTR_WEIGHT) AS Qty")
            selects.Add("SUM(A.RATE * A.MTR_WEIGHT) AS Amount")
            '==========================================================
            ' 11. WHERE
            '==========================================================
            Dim whereClause As New StringBuilder()
            whereClause.AppendLine($" WHERE {bookFilter} ")
            whereClause.AppendLine(" AND G.BEHAVIOUR = 'FINISH' ")
            '==========================================================
            ' 12. DATE FILTER
            '==========================================================
            If fromDate.HasValue Then
                whereClause.AppendLine($" AND {dateColumn} >= '{fromDate.Value:yyyyMMdd}' ")
            End If
            If toDate.HasValue Then
                whereClause.AppendLine($" AND {dateColumn} < '{toDate.Value.AddDays(1):yyyyMMdd}' ")
            End If
            '==========================================================
            ' 13. ROLE FILTER
            '==========================================================
            If Not String.IsNullOrWhiteSpace(allCode) AndAlso Not String.Equals(allCode, "null", StringComparison.OrdinalIgnoreCase) Then
                If String.Equals(role, "agent", StringComparison.OrdinalIgnoreCase) Then
                    whereClause.AppendLine($" AND PARTY.AGENTCODE = '{allCode.Replace("'", "''")}' ")
                ElseIf String.Equals(role, "party", StringComparison.OrdinalIgnoreCase) Then
                    whereClause.AppendLine($" AND A.ACCOUNTCODE = '{allCode.Replace("'", "''")}' ")
                End If
            End If
            '==========================================================
            ' 14. PARTY FILTER
            '==========================================================
            If Not String.IsNullOrWhiteSpace(partyName) Then
                whereClause.AppendLine($" AND PARTY.ACCOUNTNAME = '{partyName.Replace("'", "''")}' ")
            End If
            If Not String.IsNullOrWhiteSpace(partyCode) Then
                whereClause.AppendLine($" AND PARTY.ACCOUNTCODE = '{partyCode.Replace("'", "''")}' ")
            End If
            '==========================================================
            ' 15. CITY FILTER
            '==========================================================
            If Not String.IsNullOrWhiteSpace(cityName) Then
                whereClause.AppendLine($" AND CITY.cityname = '{cityName.Replace("'", "''")}' ")
            End If
            If Not String.IsNullOrWhiteSpace(cityCode) Then
                whereClause.AppendLine($" AND CITY.citycode = '{cityCode.Replace("'", "''")}' ")
            End If
            '==========================================================
            ' 16. AGENT FILTER
            '==========================================================
            If Not String.IsNullOrWhiteSpace(agentName) Then
                whereClause.AppendLine($" AND AGENT.ACCOUNTNAME = '{agentName.Replace("'", "''")}' ")
            End If
            If Not String.IsNullOrWhiteSpace(agentCode) Then
                whereClause.AppendLine($" AND PARTY.AGENTCODE = '{agentCode.Replace("'", "''")}' ")
            End If
            '==========================================================
            ' 17. DESIGN FILTER
            '==========================================================
            If Not String.IsNullOrWhiteSpace(designName) Then
                whereClause.AppendLine($" AND DESIGN.Design_Name = '{designName.Replace("'", "''")}' ")
            End If
            If Not String.IsNullOrWhiteSpace(designCode) Then
                whereClause.AppendLine($" AND DESIGN.Design_code = '{designCode.Replace("'", "''")}' ")
            End If
            '==========================================================
            ' 18. BASE QUERY
            '
            ' IMPORTANT:
            ' ChartName ko yahan GROUP BY nahi karenge.
            ' Actual fields hi GROUP BY honge.
            '==========================================================
            Dim baseQuery As String = "SELECT " & String.Join(", ", selects) & " FROM " & transTable & " AS A " & joins.ToString() & whereClause.ToString()
            If groups.Count > 0 Then
                baseQuery &= " GROUP BY " & String.Join(", ", groups)
            End If
            '==========================================================
            ' 19. OUTER SELECT
            '==========================================================
            Dim chartParts As New List(Of String)
            '----------------------------------------------------------
            ' MONTH
            '----------------------------------------------------------
            If hasMonth Then
                chartParts.Add("UPPER(X.Month)")
            End If
            '----------------------------------------------------------
            ' CITY
            '----------------------------------------------------------
            If hasCity Then
                chartParts.Add("ISNULL(X.CityName, '')")
            End If
            '----------------------------------------------------------
            ' PARTY
            '----------------------------------------------------------
            If hasParty Then
                chartParts.Add("ISNULL(X.PartyName, '')")
            End If
            '----------------------------------------------------------
            ' AGENT
            '----------------------------------------------------------
            If hasAgent Then
                chartParts.Add("ISNULL(X.AgentName, '')")
            End If
            '----------------------------------------------------------
            ' ITEM
            '----------------------------------------------------------
            If hasItem Then
                chartParts.Add("ISNULL(X.ItemName, '')")
            End If
            '----------------------------------------------------------
            ' DESIGN
            '----------------------------------------------------------
            If hasDesign Then
                chartParts.Add("ISNULL(X.DesignName, '')")
            End If
            '----------------------------------------------------------
            ' SHADE
            '----------------------------------------------------------
            If hasShade Then
                chartParts.Add("ISNULL(X.Shade, '')")
            End If
            '==========================================================
            ' 20. CHART NAME
            '==========================================================
            Dim chartNameExpression As String
            If chartParts.Count > 0 Then
                chartNameExpression = String.Join(" + ' + ' + ", chartParts)
            Else
                chartNameExpression = "'TOTAL'"
            End If
            '==========================================================
            ' 21. FINAL QUERY
            '==========================================================
            Dim finalQuery As String
            If applyTop10 Then
                '======================================================
                ' PIE / BAR / LINE
                ' TOP 10 BY AMOUNT
                '======================================================
                finalQuery = "SELECT TOP (10) " & chartNameExpression & " AS ChartName, " & "X.Qty, " & "X.Amount " & "FROM (" & baseQuery & ") AS X " & "ORDER BY X.Amount DESC"
            Else
                '======================================================
                ' TABLE
                ' ALL RECORDS
                '======================================================
                If hasMonth Then
                    finalQuery = "SELECT " & chartNameExpression & " AS ChartName, " & "X.Qty, " & "X.Amount " & "FROM (" & baseQuery & ") AS X " & "ORDER BY X.MonthNo ASC, X.Amount DESC"
                Else
                    finalQuery = "SELECT " & chartNameExpression & " AS ChartName, " & "X.Qty, " & "X.Amount " & "FROM (" & baseQuery & ") AS X " & "ORDER BY X.Amount DESC"
                End If
            End If
            '==========================================================
            ' DEBUG
            '==========================================================
            Debug.WriteLine("==============================================")
            Debug.WriteLine("MONTH CHART SQL")
            Debug.WriteLine("ChartType  : " & chartType)
            Debug.WriteLine("CurrentView: " & currentView)
            Debug.WriteLine("Top10      : " & applyTop10.ToString())
            Debug.WriteLine("----------------------------------------------")
            Debug.WriteLine(finalQuery)
            Debug.WriteLine("==============================================")
            Return finalQuery
        Catch ex As Exception
            MessageBox.Show("Error while generating Month Chart SQL:" & Environment.NewLine & ex.Message, "SQL Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return String.Empty
        End Try
    End Function
    Public Sub SetConnectionString(ByVal connStr As String)
        Me.ConnectionString = connStr
    End Sub
End Class