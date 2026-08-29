<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LiveChartForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LiveChartForm))
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.Partywise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement11 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement12 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AgentWise2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AgentWise3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.pnlCardAmount = New System.Windows.Forms.Panel()
        Me.lblTotalAmountTitle = New System.Windows.Forms.Label()
        Me.lblTotalAmountVal = New System.Windows.Forms.Label()
        Me.lblTotalQtyTitle = New System.Windows.Forms.Label()
        Me.lblTotalQtyVal = New System.Windows.Forms.Label()
        Me.pnlCardQty = New System.Windows.Forms.Panel()
        Me.pnlKPICards = New System.Windows.Forms.Panel()
        Me.btnViewPie = New DevExpress.XtraEditors.SimpleButton()
        Me.btnViewBar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnViewLine = New DevExpress.XtraEditors.SimpleButton()
        Me.btnViewTable = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pnlTopHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.dtpToDate1 = New ctl_TextBox.ctl_TextBox()
        Me.dtpFromDate1 = New ctl_TextBox.ctl_TextBox()
        Me.lblTopBannerSub = New System.Windows.Forms.Label()
        Me.lblTopBannerTitle = New System.Windows.Forms.Label()
        Me.pnlTopBanner = New System.Windows.Forms.Panel()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DevExpressChartControl = New DevExpress.XtraCharts.ChartControl()
        Me.pnlMainContent = New DevExpress.XtraEditors.PanelControl()
        Me.pnlViewToggle = New System.Windows.Forms.Panel()
        Me.MainAgentwise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Agentwaise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.MainCityWise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.CityWise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Citywise2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.CityWise3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.ItemWiseMain = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.ItemWise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement9 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.MainMonthWise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCardAmount.SuspendLayout()
        Me.pnlCardQty.SuspendLayout()
        Me.pnlTopHeader.SuspendLayout()
        Me.pnlTopBanner.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DevExpressChartControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlMainContent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMainContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.Partywise, Me.MainAgentwise, Me.MainCityWise, Me.ItemWiseMain, Me.MainMonthWise})
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(250, 621)
        Me.AccordionControl1.TabIndex = 6
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'Partywise
        '
        Me.Partywise.Appearance.Default.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise.Appearance.Default.Options.UseFont = True
        Me.Partywise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise.Appearance.Normal.Options.UseFont = True
        Me.Partywise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1, Me.AccordionControlElement5, Me.AccordionControlElement2})
        Me.Partywise.Expanded = True
        Me.Partywise.ImageOptions.Image = CType(resources.GetObject("Partywise.ImageOptions.Image"), System.Drawing.Image)
        Me.Partywise.Name = "Partywise"
        Me.Partywise.Text = "Party  Wise"
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement1.Appearance.Default.Options.UseFont = True
        Me.AccordionControlElement1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement1.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement1.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement1.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement1.Text = "Party Wise"
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement5.Appearance.Default.Options.UseFont = True
        Me.AccordionControlElement5.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement5.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement5.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement5.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "Party+Item Wise"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement3.Appearance.Default.Options.UseFont = True
        Me.AccordionControlElement3.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement3.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement3.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement3.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "Shade Wise"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement4.Appearance.Default.Options.UseFont = True
        Me.AccordionControlElement4.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement4.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement4.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement4.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "Design Wise"
        '
        'AccordionControlElement11
        '
        Me.AccordionControlElement11.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement11.Appearance.Default.Options.UseFont = True
        Me.AccordionControlElement11.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement11.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement11.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement11.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement11.Name = "AccordionControlElement11"
        Me.AccordionControlElement11.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement11.Text = "Month+Item+Design"
        '
        'AccordionControlElement12
        '
        Me.AccordionControlElement12.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement12.Appearance.Default.Options.UseFont = True
        Me.AccordionControlElement12.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement12.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement12.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement12.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement12.Name = "AccordionControlElement12"
        Me.AccordionControlElement12.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement12.Text = "Month+Item+Design+Shade"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement2.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement2.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement2.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement2.Text = "Month+Party Wise"
        '
        'AgentWise2
        '
        Me.AgentWise2.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentWise2.Appearance.Default.Options.UseFont = True
        Me.AgentWise2.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentWise2.Appearance.Normal.Options.UseFont = True
        Me.AgentWise2.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement6.ImageOptions.Image"), System.Drawing.Image)
        Me.AgentWise2.Name = "AgentWise2"
        Me.AgentWise2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AgentWise2.Text = "Agent+Item Wise"
        '
        'AgentWise3
        '
        Me.AgentWise3.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentWise3.Appearance.Default.Options.UseFont = True
        Me.AgentWise3.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentWise3.Appearance.Normal.Options.UseFont = True
        Me.AgentWise3.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement10.ImageOptions.Image"), System.Drawing.Image)
        Me.AgentWise3.Name = "AgentWise3"
        Me.AgentWise3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AgentWise3.Text = "Month+Agent Wise"
        '
        'pnlCardAmount
        '
        Me.pnlCardAmount.BackColor = System.Drawing.Color.White
        Me.pnlCardAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardAmount.Controls.Add(Me.lblTotalAmountTitle)
        Me.pnlCardAmount.Controls.Add(Me.lblTotalAmountVal)
        Me.pnlCardAmount.Location = New System.Drawing.Point(5, 2)
        Me.pnlCardAmount.Name = "pnlCardAmount"
        Me.pnlCardAmount.Size = New System.Drawing.Size(186, 52)
        Me.pnlCardAmount.TabIndex = 0
        '
        'lblTotalAmountTitle
        '
        Me.lblTotalAmountTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblTotalAmountTitle.Location = New System.Drawing.Point(-1, 6)
        Me.lblTotalAmountTitle.Name = "lblTotalAmountTitle"
        Me.lblTotalAmountTitle.Size = New System.Drawing.Size(184, 23)
        Me.lblTotalAmountTitle.TabIndex = 0
        Me.lblTotalAmountTitle.Text = "Total Amount"
        Me.lblTotalAmountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalAmountVal
        '
        Me.lblTotalAmountVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAmountVal.Location = New System.Drawing.Point(7, 26)
        Me.lblTotalAmountVal.Name = "lblTotalAmountVal"
        Me.lblTotalAmountVal.Size = New System.Drawing.Size(176, 23)
        Me.lblTotalAmountVal.TabIndex = 1
        Me.lblTotalAmountVal.Text = "₹ 0.00"
        Me.lblTotalAmountVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalQtyTitle
        '
        Me.lblTotalQtyTitle.ForeColor = System.Drawing.Color.Gray
        Me.lblTotalQtyTitle.Location = New System.Drawing.Point(3, 5)
        Me.lblTotalQtyTitle.Name = "lblTotalQtyTitle"
        Me.lblTotalQtyTitle.Size = New System.Drawing.Size(179, 23)
        Me.lblTotalQtyTitle.TabIndex = 0
        Me.lblTotalQtyTitle.Text = "Total Quantity"
        Me.lblTotalQtyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalQtyVal
        '
        Me.lblTotalQtyVal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalQtyVal.Location = New System.Drawing.Point(3, 28)
        Me.lblTotalQtyVal.Name = "lblTotalQtyVal"
        Me.lblTotalQtyVal.Size = New System.Drawing.Size(179, 23)
        Me.lblTotalQtyVal.TabIndex = 1
        Me.lblTotalQtyVal.Text = "0.00"
        Me.lblTotalQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCardQty
        '
        Me.pnlCardQty.BackColor = System.Drawing.Color.White
        Me.pnlCardQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCardQty.Controls.Add(Me.lblTotalQtyTitle)
        Me.pnlCardQty.Controls.Add(Me.lblTotalQtyVal)
        Me.pnlCardQty.Location = New System.Drawing.Point(195, 2)
        Me.pnlCardQty.Name = "pnlCardQty"
        Me.pnlCardQty.Size = New System.Drawing.Size(186, 52)
        Me.pnlCardQty.TabIndex = 1
        '
        'pnlKPICards
        '
        Me.pnlKPICards.BackColor = System.Drawing.Color.LightCyan
        Me.pnlKPICards.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlKPICards.Location = New System.Drawing.Point(250, 55)
        Me.pnlKPICards.Name = "pnlKPICards"
        Me.pnlKPICards.Size = New System.Drawing.Size(760, 2)
        Me.pnlKPICards.TabIndex = 9
        '
        'btnViewPie
        '
        Me.btnViewPie.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewPie.Appearance.Options.UseFont = True
        Me.btnViewPie.ImageOptions.Image = CType(resources.GetObject("btnViewPie.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewPie.Location = New System.Drawing.Point(439, 9)
        Me.btnViewPie.Name = "btnViewPie"
        Me.btnViewPie.Size = New System.Drawing.Size(69, 37)
        Me.btnViewPie.TabIndex = 4
        Me.btnViewPie.Text = "Pie"
        '
        'btnViewBar
        '
        Me.btnViewBar.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewBar.Appearance.Options.UseFont = True
        Me.btnViewBar.ImageOptions.Image = CType(resources.GetObject("btnViewBar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewBar.Location = New System.Drawing.Point(513, 9)
        Me.btnViewBar.Name = "btnViewBar"
        Me.btnViewBar.Size = New System.Drawing.Size(68, 37)
        Me.btnViewBar.TabIndex = 5
        Me.btnViewBar.Text = "Bar"
        '
        'btnViewLine
        '
        Me.btnViewLine.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewLine.Appearance.Options.UseFont = True
        Me.btnViewLine.ImageOptions.Image = CType(resources.GetObject("btnViewLine.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewLine.Location = New System.Drawing.Point(587, 9)
        Me.btnViewLine.Name = "btnViewLine"
        Me.btnViewLine.Size = New System.Drawing.Size(71, 37)
        Me.btnViewLine.TabIndex = 6
        Me.btnViewLine.Text = "Line"
        '
        'btnViewTable
        '
        Me.btnViewTable.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTable.Appearance.Options.UseFont = True
        Me.btnViewTable.ImageOptions.Image = CType(resources.GetObject("btnViewTable.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewTable.Location = New System.Drawing.Point(662, 9)
        Me.btnViewTable.Name = "btnViewTable"
        Me.btnViewTable.Size = New System.Drawing.Size(78, 37)
        Me.btnViewTable.TabIndex = 7
        Me.btnViewTable.Text = "Table"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(742, 19)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(14, 14)
        Me.ProgressBar1.TabIndex = 4
        Me.ProgressBar1.Visible = False
        '
        'pnlTopHeader
        '
        Me.pnlTopHeader.BackColor = System.Drawing.Color.LightCyan
        Me.pnlTopHeader.Controls.Add(Me.btnViewPie)
        Me.pnlTopHeader.Controls.Add(Me.Label1)
        Me.pnlTopHeader.Controls.Add(Me.btnViewBar)
        Me.pnlTopHeader.Controls.Add(Me.lbl_To)
        Me.pnlTopHeader.Controls.Add(Me.btnViewLine)
        Me.pnlTopHeader.Controls.Add(Me.Label41)
        Me.pnlTopHeader.Controls.Add(Me.btnViewTable)
        Me.pnlTopHeader.Controls.Add(Me.lbl_From)
        Me.pnlTopHeader.Controls.Add(Me.BtnView)
        Me.pnlTopHeader.Controls.Add(Me.dtpToDate1)
        Me.pnlTopHeader.Controls.Add(Me.dtpFromDate1)
        Me.pnlTopHeader.Controls.Add(Me.ProgressBar1)
        Me.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopHeader.Location = New System.Drawing.Point(250, 0)
        Me.pnlTopHeader.Name = "pnlTopHeader"
        Me.pnlTopHeader.Size = New System.Drawing.Size(760, 55)
        Me.pnlTopHeader.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(250, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 14)
        Me.Label1.TabIndex = 82257
        Me.Label1.Text = ":"
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.Black
        Me.lbl_To.Location = New System.Drawing.Point(193, 19)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 82256
        Me.lbl_To.Text = "Date To"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(86, 19)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(12, 14)
        Me.Label41.TabIndex = 82255
        Me.Label41.Text = ":"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.Black
        Me.lbl_From.Location = New System.Drawing.Point(7, 19)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 82254
        Me.lbl_From.Text = "Date From"
        '
        'BtnView
        '
        Me.BtnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnView.Appearance.Options.UseFont = True
        Me.BtnView.ImageOptions.Image = CType(resources.GetObject("BtnView.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(359, 9)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 37)
        Me.BtnView.TabIndex = 5
        Me.BtnView.Text = "View"
        '
        'dtpToDate1
        '
        Me.dtpToDate1._AllowSpace = True
        Me.dtpToDate1.AcceptsReturn = True
        Me.dtpToDate1.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.dtpToDate1.BackColor = System.Drawing.Color.LightCyan
        Me.dtpToDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpToDate1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpToDate1.Check_End_Date_Value_FY = "YES"
        Me.dtpToDate1.Check_Start_Date_Value_FY = "YES"
        Me.dtpToDate1.ClearField = True
        Me.dtpToDate1.CustomInputTypeString = Nothing
        Me.dtpToDate1.Date_for_Database = Nothing
        Me.dtpToDate1.Date_Tag = Nothing
        Me.dtpToDate1.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.dtpToDate1.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.dtpToDate1.ExtraValue = ""
        Me.dtpToDate1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate1.FontFocusColor = System.Drawing.Color.Blue
        Me.dtpToDate1.FontLeaveColor = System.Drawing.Color.Black
        Me.dtpToDate1.ForeColor = System.Drawing.Color.Black
        Me.dtpToDate1.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.dtpToDate1.IsValidated = False
        Me.dtpToDate1.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.dtpToDate1.Location = New System.Drawing.Point(258, 18)
        Me.dtpToDate1.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtpToDate1.MandatoryField = False
        Me.dtpToDate1.MaxDate = Nothing
        Me.dtpToDate1.MinDate = Nothing
        Me.dtpToDate1.Name = "dtpToDate1"
        Me.dtpToDate1.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.dtpToDate1.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.dtpToDate1.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.dtpToDate1.RegularExpression = Nothing
        Me.dtpToDate1.RegularExpressionErrorMessage = Nothing
        Me.dtpToDate1.ShowMessage = False
        Me.dtpToDate1.Size = New System.Drawing.Size(92, 22)
        Me.dtpToDate1.SpacerString = ""
        Me.dtpToDate1.TabIndex = 2
        Me.dtpToDate1.Tag = "BOOKNAME"
        Me.dtpToDate1.Text = "  /  /    "
        Me.dtpToDate1.TransparentBox = True
        Me.dtpToDate1.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'dtpFromDate1
        '
        Me.dtpFromDate1._AllowSpace = True
        Me.dtpFromDate1.AcceptsReturn = True
        Me.dtpFromDate1.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.dtpFromDate1.BackColor = System.Drawing.Color.LightCyan
        Me.dtpFromDate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpFromDate1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpFromDate1.Check_End_Date_Value_FY = "YES"
        Me.dtpFromDate1.Check_Start_Date_Value_FY = "YES"
        Me.dtpFromDate1.ClearField = True
        Me.dtpFromDate1.CustomInputTypeString = Nothing
        Me.dtpFromDate1.Date_for_Database = Nothing
        Me.dtpFromDate1.Date_Tag = Nothing
        Me.dtpFromDate1.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.dtpFromDate1.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.dtpFromDate1.ExtraValue = ""
        Me.dtpFromDate1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromDate1.FontFocusColor = System.Drawing.Color.Blue
        Me.dtpFromDate1.FontLeaveColor = System.Drawing.Color.Black
        Me.dtpFromDate1.ForeColor = System.Drawing.Color.Black
        Me.dtpFromDate1.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.dtpFromDate1.IsValidated = False
        Me.dtpFromDate1.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.dtpFromDate1.Location = New System.Drawing.Point(97, 18)
        Me.dtpFromDate1.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtpFromDate1.MandatoryField = False
        Me.dtpFromDate1.MaxDate = Nothing
        Me.dtpFromDate1.MinDate = Nothing
        Me.dtpFromDate1.Name = "dtpFromDate1"
        Me.dtpFromDate1.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.dtpFromDate1.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.dtpFromDate1.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.dtpFromDate1.RegularExpression = Nothing
        Me.dtpFromDate1.RegularExpressionErrorMessage = Nothing
        Me.dtpFromDate1.ShowMessage = False
        Me.dtpFromDate1.Size = New System.Drawing.Size(92, 22)
        Me.dtpFromDate1.SpacerString = ""
        Me.dtpFromDate1.TabIndex = 1
        Me.dtpFromDate1.Tag = "BOOKNAME"
        Me.dtpFromDate1.Text = "  /  /    "
        Me.dtpFromDate1.TransparentBox = True
        Me.dtpFromDate1.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'lblTopBannerSub
        '
        Me.lblTopBannerSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTopBannerSub.Location = New System.Drawing.Point(385, 30)
        Me.lblTopBannerSub.Name = "lblTopBannerSub"
        Me.lblTopBannerSub.Size = New System.Drawing.Size(373, 23)
        Me.lblTopBannerSub.TabIndex = 1
        Me.lblTopBannerSub.Text = "Amt: ₹ 0.00   |   Qty: 0.00"
        '
        'lblTopBannerTitle
        '
        Me.lblTopBannerTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTopBannerTitle.ForeColor = System.Drawing.Color.White
        Me.lblTopBannerTitle.Location = New System.Drawing.Point(385, 5)
        Me.lblTopBannerTitle.Name = "lblTopBannerTitle"
        Me.lblTopBannerTitle.Size = New System.Drawing.Size(371, 23)
        Me.lblTopBannerTitle.TabIndex = 0
        Me.lblTopBannerTitle.Text = "TOP CATEGORY"
        '
        'pnlTopBanner
        '
        Me.pnlTopBanner.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.pnlTopBanner.Controls.Add(Me.pnlCardQty)
        Me.pnlTopBanner.Controls.Add(Me.pnlCardAmount)
        Me.pnlTopBanner.Controls.Add(Me.lblTopBannerTitle)
        Me.pnlTopBanner.Controls.Add(Me.lblTopBannerSub)
        Me.pnlTopBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBanner.Location = New System.Drawing.Point(250, 57)
        Me.pnlTopBanner.Name = "pnlTopBanner"
        Me.pnlTopBanner.Size = New System.Drawing.Size(760, 55)
        Me.pnlTopBanner.TabIndex = 8
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'DevExpressChartControl
        '
        Me.DevExpressChartControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DevExpressChartControl.Legend.LegendID = -1
        Me.DevExpressChartControl.Legend.Name = "Default Legend"
        Me.DevExpressChartControl.Location = New System.Drawing.Point(2, 2)
        Me.DevExpressChartControl.Name = "DevExpressChartControl"
        Me.DevExpressChartControl.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.DevExpressChartControl.Size = New System.Drawing.Size(756, 505)
        Me.DevExpressChartControl.TabIndex = 0
        '
        'pnlMainContent
        '
        Me.pnlMainContent.Controls.Add(Me.DevExpressChartControl)
        Me.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainContent.Location = New System.Drawing.Point(250, 112)
        Me.pnlMainContent.Name = "pnlMainContent"
        Me.pnlMainContent.Size = New System.Drawing.Size(760, 509)
        Me.pnlMainContent.TabIndex = 12
        '
        'pnlViewToggle
        '
        Me.pnlViewToggle.AutoSize = True
        Me.pnlViewToggle.BackColor = System.Drawing.Color.LightCyan
        Me.pnlViewToggle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlViewToggle.Location = New System.Drawing.Point(250, 55)
        Me.pnlViewToggle.Name = "pnlViewToggle"
        Me.pnlViewToggle.Size = New System.Drawing.Size(760, 0)
        Me.pnlViewToggle.TabIndex = 10
        '
        'MainAgentwise
        '
        Me.MainAgentwise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainAgentwise.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.MainAgentwise.Appearance.Normal.Options.UseFont = True
        Me.MainAgentwise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.Agentwaise1, Me.AgentWise2, Me.AgentWise3})
        Me.MainAgentwise.Expanded = True
        Me.MainAgentwise.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement13.ImageOptions.Image"), System.Drawing.Image)
        Me.MainAgentwise.Name = "MainAgentwise"
        Me.MainAgentwise.Text = "Agent  Wise"
        '
        'Agentwaise1
        '
        Me.Agentwaise1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Agentwaise1.Appearance.Normal.Options.UseFont = True
        Me.Agentwaise1.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement17.ImageOptions.Image"), System.Drawing.Image)
        Me.Agentwaise1.Name = "Agentwaise1"
        Me.Agentwaise1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Agentwaise1.Text = "Agent Wise"
        '
        'MainCityWise
        '
        Me.MainCityWise.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainCityWise.Appearance.Normal.Options.UseFont = True
        Me.MainCityWise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.CityWise1, Me.Citywise2, Me.CityWise3})
        Me.MainCityWise.Expanded = True
        Me.MainCityWise.ImageOptions.Image = CType(resources.GetObject("CityWiseMain.ImageOptions.Image"), System.Drawing.Image)
        Me.MainCityWise.Name = "MainCityWise"
        Me.MainCityWise.Text = "City  Wise"
        '
        'CityWise1
        '
        Me.CityWise1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CityWise1.Appearance.Normal.Options.UseFont = True
        Me.CityWise1.ImageOptions.Image = CType(resources.GetObject("CityWise1.ImageOptions.Image"), System.Drawing.Image)
        Me.CityWise1.Name = "CityWise1"
        Me.CityWise1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.CityWise1.Text = "City Wise"
        '
        'Citywise2
        '
        Me.Citywise2.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Citywise2.Appearance.Normal.Options.UseFont = True
        Me.Citywise2.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement13.ImageOptions.Image1"), System.Drawing.Image)
        Me.Citywise2.Name = "Citywise2"
        Me.Citywise2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Citywise2.Text = "City+Item Wise"
        '
        'CityWise3
        '
        Me.CityWise3.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CityWise3.Appearance.Normal.Options.UseFont = True
        Me.CityWise3.ImageOptions.Image = CType(resources.GetObject("CityWise3.ImageOptions.Image"), System.Drawing.Image)
        Me.CityWise3.Name = "CityWise3"
        Me.CityWise3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.CityWise3.Text = "Month+City Wise"
        '
        'ItemWiseMain
        '
        Me.ItemWiseMain.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemWiseMain.Appearance.Normal.Options.UseFont = True
        Me.ItemWiseMain.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.ItemWise1, Me.AccordionControlElement9, Me.AccordionControlElement4, Me.AccordionControlElement11, Me.AccordionControlElement3, Me.AccordionControlElement12})
        Me.ItemWiseMain.Expanded = True
        Me.ItemWiseMain.ImageOptions.Image = CType(resources.GetObject("ItemWiseMain.ImageOptions.Image"), System.Drawing.Image)
        Me.ItemWiseMain.Name = "ItemWiseMain"
        Me.ItemWiseMain.Text = "Item  Wise"
        '
        'ItemWise1
        '
        Me.ItemWise1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemWise1.Appearance.Normal.Options.UseFont = True
        Me.ItemWise1.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement6.ImageOptions.Image1"), System.Drawing.Image)
        Me.ItemWise1.Name = "ItemWise1"
        Me.ItemWise1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.ItemWise1.Text = "Item Wise"
        '
        'AccordionControlElement9
        '
        Me.AccordionControlElement9.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement9.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement9.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement9.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement9.Name = "AccordionControlElement9"
        Me.AccordionControlElement9.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement9.Text = "Month+Item Wise"
        '
        'MainMonthWise
        '
        Me.MainMonthWise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMonthWise.Appearance.Normal.Options.UseFont = True
        Me.MainMonthWise.ImageOptions.Image = CType(resources.GetObject("MainMonthWise.ImageOptions.Image"), System.Drawing.Image)
        Me.MainMonthWise.Name = "MainMonthWise"
        Me.MainMonthWise.Text = "Month Wise"
        '
        'LiveChartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1010, 621)
        Me.Controls.Add(Me.pnlMainContent)
        Me.Controls.Add(Me.pnlTopBanner)
        Me.Controls.Add(Me.pnlKPICards)
        Me.Controls.Add(Me.pnlViewToggle)
        Me.Controls.Add(Me.pnlTopHeader)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "LiveChartForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Analytics Dashboard"
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCardAmount.ResumeLayout(False)
        Me.pnlCardQty.ResumeLayout(False)
        Me.pnlTopHeader.ResumeLayout(False)
        Me.pnlTopHeader.PerformLayout()
        Me.pnlTopBanner.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DevExpressChartControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlMainContent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMainContent.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents Partywise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents pnlCardAmount As Windows.Forms.Panel
    Friend WithEvents lblTotalAmountTitle As Windows.Forms.Label
    Friend WithEvents lblTotalAmountVal As Windows.Forms.Label
    Friend WithEvents lblTotalQtyTitle As Windows.Forms.Label
    Friend WithEvents lblTotalQtyVal As Windows.Forms.Label
    Friend WithEvents pnlCardQty As Windows.Forms.Panel
    Friend WithEvents pnlKPICards As Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As Windows.Forms.ProgressBar
    Friend WithEvents pnlTopHeader As Windows.Forms.Panel
    Friend WithEvents DevExpressGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnViewPie As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnViewBar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnViewLine As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnViewTable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTopBannerSub As Windows.Forms.Label
    Friend WithEvents lblTopBannerTitle As Windows.Forms.Label
    Friend WithEvents pnlTopBanner As Windows.Forms.Panel
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AgentWise2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AgentWise3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement11 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement12 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents dtpFromDate1 As ctl_TextBox.ctl_TextBox
    Friend WithEvents dtpToDate1 As ctl_TextBox.ctl_TextBox
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lbl_To As Windows.Forms.Label
    Friend WithEvents Label41 As Windows.Forms.Label
    Friend WithEvents lbl_From As Windows.Forms.Label
    Friend WithEvents DevExpressChartControl As DevExpress.XtraCharts.ChartControl
    Friend WithEvents pnlMainContent As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlViewToggle As Windows.Forms.Panel
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainAgentwise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Agentwaise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainCityWise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents CityWise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Citywise2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents CityWise3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents ItemWiseMain As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents ItemWise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement9 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainMonthWise As DevExpress.XtraBars.Navigation.AccordionControlElement
End Class
