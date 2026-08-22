<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChartForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Me.pnlTopHeader = New System.Windows.Forms.Panel()
        Me.cmbDimension = New System.Windows.Forms.ComboBox()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLoadData = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pnlViewToggle = New System.Windows.Forms.Panel()
        Me.btnViewPie = New System.Windows.Forms.Button()
        Me.btnViewBar = New System.Windows.Forms.Button()
        Me.btnViewLine = New System.Windows.Forms.Button()
        Me.btnViewTable = New System.Windows.Forms.Button()
        Me.pnlKPICards = New System.Windows.Forms.Panel()
        Me.pnlCardAmount = New System.Windows.Forms.Panel()
        Me.lblTotalAmountTitle = New System.Windows.Forms.Label()
        Me.lblTotalAmountVal = New System.Windows.Forms.Label()
        Me.pnlCardQty = New System.Windows.Forms.Panel()
        Me.lblTotalQtyTitle = New System.Windows.Forms.Label()
        Me.lblTotalQtyVal = New System.Windows.Forms.Label()
        Me.pnlTopBanner = New System.Windows.Forms.Panel()
        Me.lblTopBannerTitle = New System.Windows.Forms.Label()
        Me.lblTopBannerSub = New System.Windows.Forms.Label()
        Me.pnlMainViewContainer = New System.Windows.Forms.Panel()
        Me.pnlPieView = New System.Windows.Forms.Panel()
        Me.ChartPie = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlBarView = New System.Windows.Forms.Panel()
        Me.ChartBar = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlLineView = New System.Windows.Forms.Panel()
        Me.ChartLine = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlTableView = New System.Windows.Forms.Panel()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pnlTopHeader.SuspendLayout()
        Me.pnlViewToggle.SuspendLayout()
        Me.pnlKPICards.SuspendLayout()
        Me.pnlCardAmount.SuspendLayout()
        Me.pnlCardQty.SuspendLayout()
        Me.pnlTopBanner.SuspendLayout()
        Me.pnlMainViewContainer.SuspendLayout()
        Me.pnlPieView.SuspendLayout()
        CType(Me.ChartPie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarView.SuspendLayout()
        CType(Me.ChartBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLineView.SuspendLayout()
        CType(Me.ChartLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTableView.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTopHeader
        '
        Me.pnlTopHeader.BackColor = System.Drawing.Color.White
        Me.pnlTopHeader.Controls.Add(Me.cmbDimension)
        Me.pnlTopHeader.Controls.Add(Me.dtpFromDate)
        Me.pnlTopHeader.Controls.Add(Me.dtpToDate)
        Me.pnlTopHeader.Controls.Add(Me.btnLoadData)
        Me.pnlTopHeader.Controls.Add(Me.ProgressBar1)
        Me.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopHeader.Name = "pnlTopHeader"
        Me.pnlTopHeader.Size = New System.Drawing.Size(973, 55)
        Me.pnlTopHeader.TabIndex = 4
        '
        'cmbDimension
        '
        Me.cmbDimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDimension.Location = New System.Drawing.Point(15, 15)
        Me.cmbDimension.Name = "cmbDimension"
        Me.cmbDimension.Size = New System.Drawing.Size(140, 21)
        Me.cmbDimension.TabIndex = 0
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDate.Location = New System.Drawing.Point(165, 15)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpFromDate.TabIndex = 1
        '
        'dtpToDate
        '
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(275, 15)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpToDate.TabIndex = 2
        '
        'btnLoadData
        '
        Me.btnLoadData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadData.ForeColor = System.Drawing.Color.White
        Me.btnLoadData.Location = New System.Drawing.Point(385, 13)
        Me.btnLoadData.Name = "btnLoadData"
        Me.btnLoadData.Size = New System.Drawing.Size(90, 28)
        Me.btnLoadData.TabIndex = 3
        Me.btnLoadData.Text = "Refresh"
        Me.btnLoadData.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(485, 20)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(150, 14)
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Visible = False
        '
        'pnlViewToggle
        '
        Me.pnlViewToggle.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlViewToggle.Controls.Add(Me.btnViewPie)
        Me.pnlViewToggle.Controls.Add(Me.btnViewBar)
        Me.pnlViewToggle.Controls.Add(Me.btnViewLine)
        Me.pnlViewToggle.Controls.Add(Me.btnViewTable)
        Me.pnlViewToggle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlViewToggle.Location = New System.Drawing.Point(0, 55)
        Me.pnlViewToggle.Name = "pnlViewToggle"
        Me.pnlViewToggle.Size = New System.Drawing.Size(973, 45)
        Me.pnlViewToggle.TabIndex = 3
        '
        'btnViewPie
        '
        Me.btnViewPie.Location = New System.Drawing.Point(15, 8)
        Me.btnViewPie.Name = "btnViewPie"
        Me.btnViewPie.Size = New System.Drawing.Size(85, 30)
        Me.btnViewPie.TabIndex = 0
        Me.btnViewPie.Text = "✔️ Pie"
        '
        'btnViewBar
        '
        Me.btnViewBar.Location = New System.Drawing.Point(105, 8)
        Me.btnViewBar.Name = "btnViewBar"
        Me.btnViewBar.Size = New System.Drawing.Size(85, 30)
        Me.btnViewBar.TabIndex = 1
        Me.btnViewBar.Text = "📊 Bar"
        '
        'btnViewLine
        '
        Me.btnViewLine.Location = New System.Drawing.Point(195, 8)
        Me.btnViewLine.Name = "btnViewLine"
        Me.btnViewLine.Size = New System.Drawing.Size(85, 30)
        Me.btnViewLine.TabIndex = 2
        Me.btnViewLine.Text = "📈 Line"
        '
        'btnViewTable
        '
        Me.btnViewTable.Location = New System.Drawing.Point(285, 8)
        Me.btnViewTable.Name = "btnViewTable"
        Me.btnViewTable.Size = New System.Drawing.Size(85, 30)
        Me.btnViewTable.TabIndex = 3
        Me.btnViewTable.Text = "📋 Table"
        '
        'pnlKPICards
        '
        Me.pnlKPICards.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlKPICards.Controls.Add(Me.pnlCardAmount)
        Me.pnlKPICards.Controls.Add(Me.pnlCardQty)
        Me.pnlKPICards.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKPICards.Location = New System.Drawing.Point(0, 100)
        Me.pnlKPICards.Name = "pnlKPICards"
        Me.pnlKPICards.Size = New System.Drawing.Size(973, 70)
        Me.pnlKPICards.TabIndex = 2
        '
        'pnlCardAmount
        '
        Me.pnlCardAmount.BackColor = System.Drawing.Color.White
        Me.pnlCardAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardAmount.Controls.Add(Me.lblTotalAmountTitle)
        Me.pnlCardAmount.Controls.Add(Me.lblTotalAmountVal)
        Me.pnlCardAmount.Location = New System.Drawing.Point(15, 5)
        Me.pnlCardAmount.Name = "pnlCardAmount"
        Me.pnlCardAmount.Size = New System.Drawing.Size(260, 58)
        Me.pnlCardAmount.TabIndex = 0
        '
        'lblTotalAmountTitle
        '
        Me.lblTotalAmountTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblTotalAmountTitle.Location = New System.Drawing.Point(10, 8)
        Me.lblTotalAmountTitle.Name = "lblTotalAmountTitle"
        Me.lblTotalAmountTitle.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalAmountTitle.TabIndex = 0
        Me.lblTotalAmountTitle.Text = "Total Amount"
        '
        'lblTotalAmountVal
        '
        Me.lblTotalAmountVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmountVal.Location = New System.Drawing.Point(10, 28)
        Me.lblTotalAmountVal.Name = "lblTotalAmountVal"
        Me.lblTotalAmountVal.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalAmountVal.TabIndex = 1
        Me.lblTotalAmountVal.Text = "₹ 0.00"
        '
        'pnlCardQty
        '
        Me.pnlCardQty.BackColor = System.Drawing.Color.White
        Me.pnlCardQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardQty.Controls.Add(Me.lblTotalQtyTitle)
        Me.pnlCardQty.Controls.Add(Me.lblTotalQtyVal)
        Me.pnlCardQty.Location = New System.Drawing.Point(290, 5)
        Me.pnlCardQty.Name = "pnlCardQty"
        Me.pnlCardQty.Size = New System.Drawing.Size(260, 58)
        Me.pnlCardQty.TabIndex = 1
        '
        'lblTotalQtyTitle
        '
        Me.lblTotalQtyTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblTotalQtyTitle.Location = New System.Drawing.Point(10, 8)
        Me.lblTotalQtyTitle.Name = "lblTotalQtyTitle"
        Me.lblTotalQtyTitle.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalQtyTitle.TabIndex = 0
        Me.lblTotalQtyTitle.Text = "Total Quantity"
        '
        'lblTotalQtyVal
        '
        Me.lblTotalQtyVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalQtyVal.Location = New System.Drawing.Point(10, 28)
        Me.lblTotalQtyVal.Name = "lblTotalQtyVal"
        Me.lblTotalQtyVal.Size = New System.Drawing.Size(100, 23)
        Me.lblTotalQtyVal.TabIndex = 1
        Me.lblTotalQtyVal.Text = "0.00"
        '
        'pnlTopBanner
        '
        Me.pnlTopBanner.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.pnlTopBanner.Controls.Add(Me.lblTopBannerTitle)
        Me.pnlTopBanner.Controls.Add(Me.lblTopBannerSub)
        Me.pnlTopBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBanner.Location = New System.Drawing.Point(0, 170)
        Me.pnlTopBanner.Name = "pnlTopBanner"
        Me.pnlTopBanner.Size = New System.Drawing.Size(973, 55)
        Me.pnlTopBanner.TabIndex = 1
        '
        'lblTopBannerTitle
        '
        Me.lblTopBannerTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTopBannerTitle.ForeColor = System.Drawing.Color.White
        Me.lblTopBannerTitle.Location = New System.Drawing.Point(20, 8)
        Me.lblTopBannerTitle.Name = "lblTopBannerTitle"
        Me.lblTopBannerTitle.Size = New System.Drawing.Size(100, 23)
        Me.lblTopBannerTitle.TabIndex = 0
        Me.lblTopBannerTitle.Text = "TOP CATEGORY"
        '
        'lblTopBannerSub
        '
        Me.lblTopBannerSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTopBannerSub.Location = New System.Drawing.Point(20, 30)
        Me.lblTopBannerSub.Name = "lblTopBannerSub"
        Me.lblTopBannerSub.Size = New System.Drawing.Size(100, 23)
        Me.lblTopBannerSub.TabIndex = 1
        Me.lblTopBannerSub.Text = "Amt: ₹ 0.00   |   Qty: 0.00"
        '
        'pnlMainViewContainer
        '
        Me.pnlMainViewContainer.BackColor = System.Drawing.Color.White
        Me.pnlMainViewContainer.Controls.Add(Me.pnlPieView)
        Me.pnlMainViewContainer.Controls.Add(Me.pnlBarView)
        Me.pnlMainViewContainer.Controls.Add(Me.pnlLineView)
        Me.pnlMainViewContainer.Controls.Add(Me.pnlTableView)
        Me.pnlMainViewContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainViewContainer.Location = New System.Drawing.Point(0, 225)
        Me.pnlMainViewContainer.Name = "pnlMainViewContainer"
        Me.pnlMainViewContainer.Size = New System.Drawing.Size(973, 385)
        Me.pnlMainViewContainer.TabIndex = 0
        '
        'pnlPieView
        '
        Me.pnlPieView.Controls.Add(Me.ChartPie)
        Me.pnlPieView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPieView.Location = New System.Drawing.Point(0, 0)
        Me.pnlPieView.Name = "pnlPieView"
        Me.pnlPieView.Size = New System.Drawing.Size(973, 385)
        Me.pnlPieView.TabIndex = 0
        '
        'ChartPie
        '
        ChartArea1.Name = "PieArea"
        Me.ChartPie.ChartAreas.Add(ChartArea1)
        Me.ChartPie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartPie.Location = New System.Drawing.Point(0, 0)
        Me.ChartPie.Name = "ChartPie"
        Me.ChartPie.Size = New System.Drawing.Size(973, 385)
        Me.ChartPie.TabIndex = 0
        '
        'pnlBarView
        '
        Me.pnlBarView.Controls.Add(Me.ChartBar)
        Me.pnlBarView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBarView.Location = New System.Drawing.Point(0, 0)
        Me.pnlBarView.Name = "pnlBarView"
        Me.pnlBarView.Size = New System.Drawing.Size(973, 385)
        Me.pnlBarView.TabIndex = 1
        '
        'ChartBar
        '
        ChartArea2.Name = "BarArea"
        Me.ChartBar.ChartAreas.Add(ChartArea2)
        Me.ChartBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartBar.Location = New System.Drawing.Point(0, 0)
        Me.ChartBar.Name = "ChartBar"
        Me.ChartBar.Size = New System.Drawing.Size(973, 385)
        Me.ChartBar.TabIndex = 0
        '
        'pnlLineView
        '
        Me.pnlLineView.Controls.Add(Me.ChartLine)
        Me.pnlLineView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLineView.Location = New System.Drawing.Point(0, 0)
        Me.pnlLineView.Name = "pnlLineView"
        Me.pnlLineView.Size = New System.Drawing.Size(973, 385)
        Me.pnlLineView.TabIndex = 2
        '
        'ChartLine
        '
        ChartArea3.Name = "LineArea"
        Me.ChartLine.ChartAreas.Add(ChartArea3)
        Me.ChartLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartLine.Location = New System.Drawing.Point(0, 0)
        Me.ChartLine.Name = "ChartLine"
        Me.ChartLine.Size = New System.Drawing.Size(973, 385)
        Me.ChartLine.TabIndex = 0
        '
        'pnlTableView
        '
        Me.pnlTableView.Controls.Add(Me.lblSearch)
        Me.pnlTableView.Controls.Add(Me.txtSearch)
        Me.pnlTableView.Controls.Add(Me.DataGridView1)
        Me.pnlTableView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTableView.Location = New System.Drawing.Point(0, 0)
        Me.pnlTableView.Name = "pnlTableView"
        Me.pnlTableView.Size = New System.Drawing.Size(973, 385)
        Me.pnlTableView.TabIndex = 3
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(15, 12)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(100, 23)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(70, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 20)
        Me.txtSearch.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.Location = New System.Drawing.Point(0, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(973, 330)
        Me.DataGridView1.TabIndex = 2
        '
        'ChartForm
        '
        Me.ClientSize = New System.Drawing.Size(973, 610)
        Me.Controls.Add(Me.pnlMainViewContainer)
        Me.Controls.Add(Me.pnlTopBanner)
        Me.Controls.Add(Me.pnlKPICards)
        Me.Controls.Add(Me.pnlViewToggle)
        Me.Controls.Add(Me.pnlTopHeader)
        Me.Name = "ChartForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Analytics Dashboard"
        Me.pnlTopHeader.ResumeLayout(False)
        Me.pnlViewToggle.ResumeLayout(False)
        Me.pnlKPICards.ResumeLayout(False)
        Me.pnlCardAmount.ResumeLayout(False)
        Me.pnlCardQty.ResumeLayout(False)
        Me.pnlTopBanner.ResumeLayout(False)
        Me.pnlMainViewContainer.ResumeLayout(False)
        Me.pnlPieView.ResumeLayout(False)
        CType(Me.ChartPie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarView.ResumeLayout(False)
        CType(Me.ChartBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLineView.ResumeLayout(False)
        CType(Me.ChartLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTableView.ResumeLayout(False)
        Me.pnlTableView.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopHeader As System.Windows.Forms.Panel
    Friend WithEvents cmbDimension As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLoadData As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents pnlViewToggle As System.Windows.Forms.Panel
    Friend WithEvents btnViewPie As System.Windows.Forms.Button
    Friend WithEvents btnViewBar As System.Windows.Forms.Button
    Friend WithEvents btnViewLine As System.Windows.Forms.Button
    Friend WithEvents btnViewTable As System.Windows.Forms.Button
    Friend WithEvents pnlKPICards As System.Windows.Forms.Panel
    Friend WithEvents pnlCardAmount As System.Windows.Forms.Panel
    Friend WithEvents lblTotalAmountTitle As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmountVal As System.Windows.Forms.Label
    Friend WithEvents pnlCardQty As System.Windows.Forms.Panel
    Friend WithEvents lblTotalQtyTitle As System.Windows.Forms.Label
    Friend WithEvents lblTotalQtyVal As System.Windows.Forms.Label
    Friend WithEvents pnlTopBanner As System.Windows.Forms.Panel
    Friend WithEvents lblTopBannerTitle As System.Windows.Forms.Label
    Friend WithEvents lblTopBannerSub As System.Windows.Forms.Label
    Friend WithEvents pnlMainViewContainer As System.Windows.Forms.Panel
    Friend WithEvents pnlPieView As System.Windows.Forms.Panel
    Friend WithEvents ChartPie As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlBarView As System.Windows.Forms.Panel
    Friend WithEvents ChartBar As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlLineView As System.Windows.Forms.Panel
    Friend WithEvents ChartLine As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlTableView As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

End Class
