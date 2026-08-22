Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms.DataVisualization.Charting
Imports DevComponents.DotNetBar.Controls
'Imports Microsoft.Office.Interop.Excel
Public Class ChartForm
    ' 🔹 APNI LOCAL SQL CONNECTION STRING YAHA SET KAREIN
    'Private connectionString As String = "Server=localhost;Database=YOUR_DATABASE_NAME;Integrated Security=True;TrustServerCertificate=True;"
    Private connectionString As String = "Data Source=DESKTOP-TBSN6SV\SQLEXPRESS;database=Accounts39_142026103929;Integrated Security=SSPI;persist security info=True"

    Private mainDataTable As DataTable
    Private currentView As String = "PIE" ' Default view: PIE, BAR, LINE, TABLE

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
        ' Populating Dropdown for all requested chartTypes
        cmbDimension.Items.Clear()
        cmbDimension.Items.AddRange(New Object() {
            "CityWise",
            "City+ItemWise",
            "AgentWise",
            "PartyWise",
            "ItemWise",
            "ShadeWise",
            "DesignWise"
        })
        cmbDimension.SelectedIndex = 0

        ' Default Date Range
        dtpFromDate.Value = New DateTime(2026, 4, 1)
        dtpToDate.Value = New DateTime(2027, 3, 31)

        ' Set default view button style
        SetActiveButton(btnViewPie)
        ShowCurrentViewPanel("PIE")

        Dim buttons() As Button = {
        btnViewPie,
        btnViewBar,
        btnViewLine,
        btnViewTable
    }

        For Each btn As Button In buttons

            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor =
            Color.FromArgb(200, 210, 220)

        Next

    End Sub

    Private Async Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        Await FetchAndRenderData()
    End Sub

    ' 🔹 SQL DATA FETCH & UPDATE ENGINE
    Private Async Function FetchAndRenderData() As Task
        Try
            ProgressBar1.Style = ProgressBarStyle.Marquee
            ProgressBar1.Visible = True
            btnLoadData.Enabled = False

            Dim chartType As String = cmbDimension.SelectedItem.ToString()
            Dim fromDate As String = dtpFromDate.Value.ToString("yyyy-MM-dd")
            Dim toDate As String = dtpToDate.Value.ToString("yyyy-MM-dd")

            ' Dynamic Query Generate karein
            Dim sqlQuery As String = GetDynamicChartSqlQuery(chartType, fromDate, toDate)

            mainDataTable = New DataTable()

            ' SQL Execution Async
            Await Task.Run(Sub()
                               Using conn As New SqlConnection(connectionString)
                                   conn.Open()
                                   Using cmd As New SqlCommand(sqlQuery, conn)
                                       Using adapter As New SqlDataAdapter(cmd)
                                           adapter.Fill(mainDataTable)
                                       End Using
                                   End Using
                               End Using
                           End Sub)

            ' KPI Cards Update karein
            UpdateKPICards(mainDataTable)

            ' Current Active View Render karein
            RenderView()

        Catch ex As Exception
            MessageBox.Show("SQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ProgressBar1.Visible = False
            btnLoadData.Enabled = True
        End Try
    End Function

    ' 🔹 TOP KPI CARDS & HIGHLIGHT BANNER UPDATE
    Private Sub UpdateKPICards(ByVal dt As DataTable)
        'If dt Is Nothing OrElse dt.Rows.Count = 0 Then
        '    lblTotalAmountVal.Text = "₹ 0.00"
        '    lblTotalQtyVal.Text = "0.00"
        '    pnlTopBanner.Visible = False
        '    Exit Sub
        'End If

        '' Calculate Totals
        'Dim totalAmt As Double = Convert.ToDouble(If(dt.Compute("SUM(Amount)", ""), 0))
        'Dim totalQty As Double = Convert.ToDouble(If(dt.Compute("SUM(Qty)", ""), 0))

        'lblTotalAmountVal.Text = String.Format("₹ {0:N2}", totalAmt)
        'lblTotalQtyVal.Text = String.Format("{0:N2}", totalQty)

        '' Highlight Top #1 Category (e.g., BHILWARA)
        'Dim xCol As String = GetDimensionColumnName(dt)
        'Dim topRow As DataRow = dt.Rows(0)
        'Dim topName As String = topRow(xCol).ToString()
        'Dim topAmt As Double = Convert.ToDouble(topRow("Amount"))
        'Dim topQty As Double = Convert.ToDouble(topRow("Qty"))

        'lblTopBannerTitle.Text = topName.ToUpper()
        'lblTopBannerSub.Text = String.Format("Amt: ₹ {0:N2}   |   Qty: {1:N2}", topAmt, topQty)
        'pnlTopBanner.Visible = True
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then

            lblTotalAmountVal.Text = "₹ 0.00"
            lblTotalQtyVal.Text = "0.00"

            pnlTopBanner.Visible = False

            Exit Sub

        End If
        Dim totalAmt As Decimal = 0D
        Dim totalQty As Decimal = 0D

        If Not IsDBNull(dt.Compute("SUM(Amount)", "")) Then
            totalAmt = Convert.ToDecimal(dt.Compute("SUM(Amount)", ""))
        End If

        If Not IsDBNull(dt.Compute("SUM(Qty)", "")) Then
            totalQty = Convert.ToDecimal(dt.Compute("SUM(Qty)", ""))
        End If
        lblTotalAmountVal.AutoSize = True
        lblTotalQtyVal.AutoSize = True

        lblTotalAmountVal.Text = "₹ " & totalAmt.ToString("#,##0.00")
        lblTotalQtyVal.Text = totalQty.ToString("#,##0.00")
        Dim xCol As String = GetDimensionColumnName(dt)
        Dim topRow As DataRow = dt.Rows(0)
        Dim topName As String = topRow(xCol).ToString()
        Dim topAmt As Decimal = 0D
        Dim topQty As Decimal = 0D
        If Not IsDBNull(topRow("Amount")) Then
            topAmt = Convert.ToDecimal(topRow("Amount"))
        End If
        If Not IsDBNull(topRow("Qty")) Then
            topQty = Convert.ToDecimal(topRow("Qty"))
        End If
        lblTopBannerTitle.Text = topName.ToUpper()
        lblTopBannerSub.AutoSize = True
        lblTopBannerSub.Text = "Amt: ₹ " & topAmt.ToString("#,##0.00") & "   |   Qty: " & topQty.ToString("#,##0.00")
        pnlTopBanner.Visible = True
    End Sub

    ' 🔹 VIEW SWITCHING TOGGLE BUTTON HANDLERS (Pie, Bar, Line, Table)
    Private Sub btnViewPie_Click(sender As Object, e As EventArgs) Handles btnViewPie.Click
        currentView = "PIE"
        SetActiveButton(btnViewPie)
        ShowCurrentViewPanel("PIE")
        RenderView()
    End Sub

    Private Sub btnViewBar_Click(sender As Object, e As EventArgs) Handles btnViewBar.Click
        currentView = "BAR"
        SetActiveButton(btnViewBar)
        ShowCurrentViewPanel("BAR")
        RenderView()
    End Sub

    Private Sub btnViewLine_Click(sender As Object, e As EventArgs) Handles btnViewLine.Click
        currentView = "LINE"
        SetActiveButton(btnViewLine)
        ShowCurrentViewPanel("LINE")
        RenderView()
    End Sub

    Private Sub btnViewTable_Click(sender As Object, e As EventArgs) Handles btnViewTable.Click
        currentView = "TABLE"
        SetActiveButton(btnViewTable)
        ShowCurrentViewPanel("TABLE")
        RenderView()
    End Sub

    Private Sub SetActiveButton(ByVal activeBtn As Button)
        For Each btn As Button In {btnViewPie, btnViewBar, btnViewLine, btnViewTable}
            If btn Is activeBtn Then
                btn.BackColor = Color.FromArgb(227, 242, 253) ' Light Active Blue
                btn.ForeColor = Color.FromArgb(0, 102, 204)  ' Blue text
                btn.Font = New Font(btn.Font, FontStyle.Bold)
            Else
                btn.BackColor = Color.White
                btn.ForeColor = Color.DimGray
                btn.Font = New Font(btn.Font, FontStyle.Regular)
            End If
        Next
    End Sub

    Private Sub ShowCurrentViewPanel(ByVal viewType As String)
        pnlPieView.Visible = (viewType = "PIE")
        pnlBarView.Visible = (viewType = "BAR")
        pnlLineView.Visible = (viewType = "LINE")
        pnlTableView.Visible = (viewType = "TABLE")
    End Sub

    ' 🔹 RENDER ENGINE FOR SELECTED VIEW
    Private Sub RenderView()
        If mainDataTable Is Nothing OrElse mainDataTable.Rows.Count = 0 Then Exit Sub

        Dim xCol As String = GetDimensionColumnName(mainDataTable)

        Select Case currentView
            Case "PIE"
                RenderPieChart(xCol)
            Case "BAR"
                RenderBarChart(xCol)
            Case "LINE"
                RenderLineChart(xCol)
            Case "TABLE"
                RenderTable(xCol)
        End Select
    End Sub

    ' 1. DOUGHNUT / PIE CHART RENDER
    Private Sub RenderPieChart(ByVal xCol As String)
        ChartPie.Series.Clear()
        ChartPie.ChartAreas(0).Area3DStyle.Enable3D = False

        Dim s As New Series("PieSeries")
        s.ChartType = SeriesChartType.Doughnut
        s.CustomProperties = "DoughnutRadius=60"
        s.XValueMember = xCol
        s.YValueMembers = "Amount"
        s.IsValueShownAsLabel = False

        For i As Integer = 0 To mainDataTable.Rows.Count - 1
            Dim pIdx As Integer = s.Points.AddXY(mainDataTable.Rows(i)(xCol), mainDataTable.Rows(i)("Amount"))
            s.Points(pIdx).Color = colorPalette(i Mod colorPalette.Length)
        Next

        ChartPie.Series.Add(s)
    End Sub

    ' 2. BAR / COLUMN CHART RENDER
    Private Sub RenderBarChart(ByVal xCol As String)
        ChartBar.Series.Clear()
        Dim s As New Series("BarSeries")
        s.ChartType = SeriesChartType.Column
        s.XValueMember = xCol
        s.YValueMembers = "Amount"
        s.IsValueShownAsLabel = False

        For i As Integer = 0 To mainDataTable.Rows.Count - 1
            Dim pIdx As Integer = s.Points.AddXY(mainDataTable.Rows(i)(xCol), mainDataTable.Rows(i)("Amount"))
            s.Points(pIdx).Color = colorPalette(i Mod colorPalette.Length)
        Next

        ChartBar.Series.Add(s)
    End Sub

    ' 3. LINE / AREA CHART RENDER
    Private Sub RenderLineChart(ByVal xCol As String)
        ChartLine.Series.Clear()
        Dim s As New Series("LineSeries")
        s.ChartType = SeriesChartType.SplineArea ' Curved line with filled gradient
        s.Color = Color.FromArgb(3, 169, 244)
        s.BackSecondaryColor = Color.FromArgb(227, 242, 253)
        s.BackGradientStyle = GradientStyle.TopBottom
        s.BorderWidth = 4
        s.MarkerStyle = MarkerStyle.Circle
        s.MarkerSize = 10
        s.MarkerColor = Color.FromArgb(0, 102, 204)
        s.XValueMember = xCol
        s.YValueMembers = "Amount"

        ChartLine.Series.Add(s)
        ChartLine.DataSource = mainDataTable
        ChartLine.DataBind()
    End Sub

    ' 4. DATA TABLE / GRIDVIEW RENDER
    Private Sub RenderTable(ByVal xCol As String)
        DataGridView1.DataSource = mainDataTable
        If DataGridView1.Columns.Contains("Amount") Then
            DataGridView1.Columns("Amount").DefaultCellStyle.Format = "₹ #,##0.00"
        End If
        If DataGridView1.Columns.Contains("Qty") Then
            DataGridView1.Columns("Qty").DefaultCellStyle.Format = "#,##0.00"
        End If
    End Sub

    ' Real-time Table Search Box Filter
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If mainDataTable Is Nothing Then Exit Sub
        Dim dv As DataView = mainDataTable.DefaultView
        Dim xCol As String = GetDimensionColumnName(mainDataTable)
        If Not String.IsNullOrEmpty(txtSearch.Text) Then
            dv.RowFilter = String.Format("{0} LIKE '%{1}%'", xCol, txtSearch.Text.Replace("'", "''"))
        Else
            dv.RowFilter = ""
        End If
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

        Dim hasCity As Boolean = chartType.IndexOf("City", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasAgent As Boolean = chartType.IndexOf("Agent", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasParty As Boolean = chartType.IndexOf("Party", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasItem As Boolean = chartType.IndexOf("Item", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasShade As Boolean = chartType.IndexOf("Shade", StringComparison.OrdinalIgnoreCase) >= 0
        Dim hasDesign As Boolean = chartType.IndexOf("Design", StringComparison.OrdinalIgnoreCase) >= 0

        Dim innerSelects As New List(Of String) From {"top(10) SUM(A.MTR_WEIGHT) AS Qty", "SUM(A.RATE*A.MTR_WEIGHT) AS Amount"}
        Dim innerGroups As New List(Of String)()
        Dim outerSelects As New List(Of String) From {"SUM(Qty) AS Qty", "SUM(Amount) AS Amount"}
        Dim outerGroups As New List(Of String)()

        Dim needPartyJoin As Boolean = hasParty OrElse hasAgent OrElse Not String.IsNullOrEmpty(partyName) OrElse Not String.IsNullOrEmpty(partyCode) OrElse Not String.IsNullOrEmpty(agentName) OrElse Not String.IsNullOrEmpty(agentCode)
        Dim needAgentJoin As Boolean = hasAgent OrElse Not String.IsNullOrEmpty(agentName)
        Dim needCityJoin As Boolean = hasCity OrElse Not String.IsNullOrEmpty(cityName) OrElse Not String.IsNullOrEmpty(cityCode)
        Dim needDesignJoin As Boolean = hasDesign OrElse Not String.IsNullOrEmpty(designName) OrElse Not String.IsNullOrEmpty(designCode)

        Dim transTable As String = If(needDesignJoin, "TrnPackingSlip", "trnInvoiceDetail")
        Dim dateColumn As String = If(needDesignJoin, "A.PACK_SLIP_DATE", "A.BillDate")
        Dim bookFilter As String = If(needDesignJoin, "G.BOOKCATEGORY = 'PACKING SLIP'", "G.BOOKCATEGORY = 'INVOICE' AND G.NATURE = 'SALES'")

        Dim joins As New StringBuilder()
        joins.Append(" LEFT JOIN MSTBOOK AS G ON A.BOOKCODE = G.BOOKCODE ")

        If hasItem Then
            joins.Append(" LEFT JOIN MSTFABRICITEM AS ITEM ON A.ITEMCODE = ITEM.ID ")
            innerSelects.Add("ITEM.ITENNAME AS ItemName")
            innerGroups.Add("ITEM.ITENNAME")
            outerSelects.Add("ItemName")
            outerGroups.Add("ItemName")
        End If

        If hasShade Then
            joins.Append(" LEFT JOIN Mst_Fabric_Shade AS SHADE ON A.SHADECODE = SHADE.Id ")
            innerSelects.Add("SHADE.SHADE")
            innerGroups.Add("SHADE.SHADE")
            outerSelects.Add("SHADE")
            outerGroups.Add("SHADE")
        End If

        If hasCity OrElse needCityJoin Then
            joins.Append(" LEFT JOIN MSTCITY AS CITY ON A.DESPATCHCODE = CITY.citycode ")
            If hasCity Then
                innerSelects.Add("CITY.cityname")
                innerGroups.Add("CITY.cityname")
                outerSelects.Add("cityname")
                outerGroups.Add("cityname")
            End If
        End If

        If needPartyJoin Then
            joins.Append(" LEFT JOIN MstMasterAccount AS PARTY ON A.ACCOUNTCODE = PARTY.ACCOUNTCODE ")
            If hasParty Then
                innerSelects.Add("PARTY.ACCOUNTNAME AS PartyName")
                innerGroups.Add("PARTY.ACCOUNTNAME")
                outerSelects.Add("PartyName")
                outerGroups.Add("PartyName")
            End If
        End If

        If needAgentJoin Then
            joins.Append(" LEFT JOIN MstMasterAccount AS AGENT ON PARTY.AGENTCODE = AGENT.ACCOUNTCODE ")
            If hasAgent Then
                innerSelects.Add("AGENT.ACCOUNTNAME AS AgentName")
                innerGroups.Add("AGENT.ACCOUNTNAME")
                outerSelects.Add("AgentName")
                outerGroups.Add("AgentName")
            End If
        End If

        If needDesignJoin Then
            joins.Append(" LEFT JOIN Mst_Fabric_Design AS DESIGN ON A.DESIGNCODE = DESIGN.Design_code ")
            If hasDesign Then
                innerSelects.Add("DESIGN.Design_Name AS DesignName")
                innerGroups.Add("DESIGN.Design_Name")
                outerSelects.Add("DesignName")
                outerGroups.Add("DesignName")
            End If
        End If

        Dim whereClause As New StringBuilder()
        whereClause.Append($" WHERE {dateColumn} BETWEEN '{fromDate}' AND '{toDate}' AND {bookFilter} AND G.BEHAVIOUR = 'FINISH' ")

        If Not String.IsNullOrEmpty(partyName) Then whereClause.Append($" AND PARTY.ACCOUNTNAME = '{partyName}' ")
        If Not String.IsNullOrEmpty(partyCode) Then whereClause.Append($" AND PARTY.ACCOUNTCODE = '{partyCode}' ")
        If Not String.IsNullOrEmpty(cityName) Then whereClause.Append($" AND CITY.cityname = '{cityName}' ")
        If Not String.IsNullOrEmpty(cityCode) Then whereClause.Append($" AND CITY.citycode = '{cityCode}' ")
        If Not String.IsNullOrEmpty(agentName) Then whereClause.Append($" AND AGENT.ACCOUNTNAME = '{agentName}' ")
        If Not String.IsNullOrEmpty(agentCode) Then whereClause.Append($" AND PARTY.AGENTCODE = '{agentCode}' ")
        If Not String.IsNullOrEmpty(designName) Then whereClause.Append($" AND DESIGN.Design_Name = '{designName}' ")
        If Not String.IsNullOrEmpty(designCode) Then whereClause.Append($" AND DESIGN.Design_code = '{designCode}' ")

        Dim innerGroupByClause As String = If(innerGroups.Count > 0, "GROUP BY " & String.Join(", ", innerGroups), "")
        Dim outerGroupByClause As String = If(outerGroups.Count > 0, "GROUP BY " & String.Join(", ", outerGroups), "")

        Dim innerQuery As String = $"SELECT {String.Join(", ", innerSelects)} {vbCrLf}FROM {transTable} AS A {vbCrLf}{joins} {vbCrLf}{whereClause} {vbCrLf}{innerGroupByClause}"
        Dim orderBy As String = If(outerGroups.Count > 0, $"ORDER BY Z.{outerGroups(0)}", "")

        Dim finalQuery As String = $"SELECT {String.Join(", ", outerSelects)} {vbCrLf}FROM ({vbCrLf}{innerQuery}{vbCrLf}) AS Z {vbCrLf}{outerGroupByClause} {vbCrLf}{orderBy}"

        Return finalQuery
    End Function

    Public Sub SetConnectionString(ByVal connStr As String)
        Me.connectionString = connStr
    End Sub
End Class