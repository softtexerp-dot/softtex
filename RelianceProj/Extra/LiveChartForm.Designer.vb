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
        Me.MainPartywise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Partywise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Partywise2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Partywise3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.MainAgentwise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Agentwise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AgentWise2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AgentWise3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.MainCityWise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.CityWise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Citywise2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.CityWise3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.MainItemWise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.ItemWise1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Itemwise2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Itemwise3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Itemwise4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Itemwise5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.Itemwise6 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.MainMonthWise = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
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
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.MainPartywise, Me.MainAgentwise, Me.MainCityWise, Me.MainItemWise, Me.MainMonthWise})
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(234, 621)
        Me.AccordionControl1.TabIndex = 6
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'MainPartywise
        '
        Me.MainPartywise.Appearance.Default.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainPartywise.Appearance.Default.Options.UseFont = True
        Me.MainPartywise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainPartywise.Appearance.Normal.Options.UseFont = True
        Me.MainPartywise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.Partywise1, Me.Partywise2, Me.Partywise3})
        Me.MainPartywise.Expanded = True
        Me.MainPartywise.ImageOptions.Image = CType(resources.GetObject("MainPartywise.ImageOptions.Image"), System.Drawing.Image)
        Me.MainPartywise.Name = "MainPartywise"
        Me.MainPartywise.Text = "Party  Wise"
        '
        'Partywise1
        '
        Me.Partywise1.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise1.Appearance.Default.Options.UseFont = True
        Me.Partywise1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise1.Appearance.Normal.Options.UseFont = True
        Me.Partywise1.ImageOptions.Image = CType(resources.GetObject("Partywise1.ImageOptions.Image"), System.Drawing.Image)
        Me.Partywise1.Name = "Partywise1"
        Me.Partywise1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Partywise1.Text = "Party Wise"
        '
        'Partywise2
        '
        Me.Partywise2.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise2.Appearance.Default.Options.UseFont = True
        Me.Partywise2.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise2.Appearance.Normal.Options.UseFont = True
        Me.Partywise2.ImageOptions.Image = CType(resources.GetObject("Partywise2.ImageOptions.Image"), System.Drawing.Image)
        Me.Partywise2.Name = "Partywise2"
        Me.Partywise2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Partywise2.Text = "Party+Item Wise"
        '
        'Partywise3
        '
        Me.Partywise3.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Partywise3.Appearance.Normal.Options.UseFont = True
        Me.Partywise3.ImageOptions.Image = CType(resources.GetObject("Partywise3.ImageOptions.Image"), System.Drawing.Image)
        Me.Partywise3.Name = "Partywise3"
        Me.Partywise3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Partywise3.Text = "Month+Party Wise"
        '
        'MainAgentwise
        '
        Me.MainAgentwise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainAgentwise.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.MainAgentwise.Appearance.Normal.Options.UseFont = True
        Me.MainAgentwise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.Agentwise1, Me.AgentWise2, Me.AgentWise3})
        Me.MainAgentwise.ImageOptions.Image = CType(resources.GetObject("MainAgentwise.ImageOptions.Image"), System.Drawing.Image)
        Me.MainAgentwise.Name = "MainAgentwise"
        Me.MainAgentwise.Text = "Agent  Wise"
        '
        'Agentwise1
        '
        Me.Agentwise1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Agentwise1.Appearance.Normal.Options.UseFont = True
        Me.Agentwise1.ImageOptions.Image = CType(resources.GetObject("Agentwise1.ImageOptions.Image"), System.Drawing.Image)
        Me.Agentwise1.Name = "Agentwise1"
        Me.Agentwise1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Agentwise1.Text = "Agent Wise"
        '
        'AgentWise2
        '
        Me.AgentWise2.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentWise2.Appearance.Default.Options.UseFont = True
        Me.AgentWise2.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AgentWise2.Appearance.Normal.Options.UseFont = True
        Me.AgentWise2.ImageOptions.Image = CType(resources.GetObject("AgentWise2.ImageOptions.Image"), System.Drawing.Image)
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
        Me.AgentWise3.ImageOptions.Image = CType(resources.GetObject("AgentWise3.ImageOptions.Image"), System.Drawing.Image)
        Me.AgentWise3.Name = "AgentWise3"
        Me.AgentWise3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AgentWise3.Text = "Month+Agent Wise"
        '
        'MainCityWise
        '
        Me.MainCityWise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainCityWise.Appearance.Normal.Options.UseFont = True
        Me.MainCityWise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.CityWise1, Me.Citywise2, Me.CityWise3})
        Me.MainCityWise.ImageOptions.Image = CType(resources.GetObject("MainCityWise.ImageOptions.Image"), System.Drawing.Image)
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
        Me.Citywise2.ImageOptions.Image = CType(resources.GetObject("Citywise2.ImageOptions.Image"), System.Drawing.Image)
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
        'MainItemWise
        '
        Me.MainItemWise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainItemWise.Appearance.Normal.Options.UseFont = True
        Me.MainItemWise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.ItemWise1, Me.Itemwise2, Me.Itemwise3, Me.Itemwise4, Me.Itemwise5, Me.Itemwise6})
        Me.MainItemWise.ImageOptions.Image = CType(resources.GetObject("MainItemWise.ImageOptions.Image"), System.Drawing.Image)
        Me.MainItemWise.Name = "MainItemWise"
        Me.MainItemWise.Text = "Item  Wise"
        '
        'ItemWise1
        '
        Me.ItemWise1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemWise1.Appearance.Normal.Options.UseFont = True
        Me.ItemWise1.ImageOptions.Image = CType(resources.GetObject("ItemWise1.ImageOptions.Image"), System.Drawing.Image)
        Me.ItemWise1.Name = "ItemWise1"
        Me.ItemWise1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.ItemWise1.Text = "Item Wise"
        '
        'Itemwise2
        '
        Me.Itemwise2.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise2.Appearance.Normal.Options.UseFont = True
        Me.Itemwise2.ImageOptions.Image = CType(resources.GetObject("Itemwise2.ImageOptions.Image"), System.Drawing.Image)
        Me.Itemwise2.Name = "Itemwise2"
        Me.Itemwise2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Itemwise2.Text = "Month+Item Wise"
        '
        'Itemwise3
        '
        Me.Itemwise3.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise3.Appearance.Default.Options.UseFont = True
        Me.Itemwise3.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise3.Appearance.Normal.Options.UseFont = True
        Me.Itemwise3.ImageOptions.Image = CType(resources.GetObject("Itemwise3.ImageOptions.Image"), System.Drawing.Image)
        Me.Itemwise3.Name = "Itemwise3"
        Me.Itemwise3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Itemwise3.Text = "Design Wise"
        '
        'Itemwise4
        '
        Me.Itemwise4.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise4.Appearance.Default.Options.UseFont = True
        Me.Itemwise4.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise4.Appearance.Normal.Options.UseFont = True
        Me.Itemwise4.ImageOptions.Image = CType(resources.GetObject("Itemwise4.ImageOptions.Image"), System.Drawing.Image)
        Me.Itemwise4.Name = "Itemwise4"
        Me.Itemwise4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Itemwise4.Text = "Month+Item+Design"
        '
        'Itemwise5
        '
        Me.Itemwise5.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise5.Appearance.Default.Options.UseFont = True
        Me.Itemwise5.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise5.Appearance.Normal.Options.UseFont = True
        Me.Itemwise5.ImageOptions.Image = CType(resources.GetObject("Itemwise5.ImageOptions.Image"), System.Drawing.Image)
        Me.Itemwise5.Name = "Itemwise5"
        Me.Itemwise5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Itemwise5.Text = "Shade Wise"
        '
        'Itemwise6
        '
        Me.Itemwise6.Appearance.Default.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise6.Appearance.Default.Options.UseFont = True
        Me.Itemwise6.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Itemwise6.Appearance.Normal.Options.UseFont = True
        Me.Itemwise6.ImageOptions.Image = CType(resources.GetObject("Itemwise6.ImageOptions.Image"), System.Drawing.Image)
        Me.Itemwise6.Name = "Itemwise6"
        Me.Itemwise6.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.Itemwise6.Text = "Month+Item+Design+Shade"
        '
        'MainMonthWise
        '
        Me.MainMonthWise.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMonthWise.Appearance.Normal.Options.UseFont = True
        Me.MainMonthWise.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.MainMonthWise.ImageOptions.Image = CType(resources.GetObject("MainMonthWise.ImageOptions.Image"), System.Drawing.Image)
        Me.MainMonthWise.Name = "MainMonthWise"
        Me.MainMonthWise.Text = "Month  Wise"
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Appearance.Normal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccordionControlElement1.Appearance.Normal.Options.UseFont = True
        Me.AccordionControlElement1.ImageOptions.Image = CType(resources.GetObject("AccordionControlElement1.ImageOptions.Image"), System.Drawing.Image)
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement1.Text = "Month Wise"
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
        Me.pnlKPICards.Location = New System.Drawing.Point(234, 52)
        Me.pnlKPICards.Name = "pnlKPICards"
        Me.pnlKPICards.Size = New System.Drawing.Size(776, 2)
        Me.pnlKPICards.TabIndex = 9
        '
        'btnViewPie
        '
        Me.btnViewPie.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewPie.Appearance.Options.UseFont = True
        Me.btnViewPie.ImageOptions.Image = CType(resources.GetObject("btnViewPie.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewPie.Location = New System.Drawing.Point(437, 9)
        Me.btnViewPie.Name = "btnViewPie"
        Me.btnViewPie.Size = New System.Drawing.Size(81, 37)
        Me.btnViewPie.TabIndex = 4
        Me.btnViewPie.Text = "Pie"
        '
        'btnViewBar
        '
        Me.btnViewBar.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewBar.Appearance.Options.UseFont = True
        Me.btnViewBar.ImageOptions.Image = CType(resources.GetObject("btnViewBar.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewBar.Location = New System.Drawing.Point(524, 9)
        Me.btnViewBar.Name = "btnViewBar"
        Me.btnViewBar.Size = New System.Drawing.Size(79, 37)
        Me.btnViewBar.TabIndex = 5
        Me.btnViewBar.Text = "Bar"
        '
        'btnViewLine
        '
        Me.btnViewLine.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewLine.Appearance.Options.UseFont = True
        Me.btnViewLine.ImageOptions.Image = CType(resources.GetObject("btnViewLine.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewLine.Location = New System.Drawing.Point(609, 9)
        Me.btnViewLine.Name = "btnViewLine"
        Me.btnViewLine.Size = New System.Drawing.Size(74, 37)
        Me.btnViewLine.TabIndex = 6
        Me.btnViewLine.Text = "Line"
        '
        'btnViewTable
        '
        Me.btnViewTable.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTable.Appearance.Options.UseFont = True
        Me.btnViewTable.ImageOptions.Image = CType(resources.GetObject("btnViewTable.ImageOptions.Image"), System.Drawing.Image)
        Me.btnViewTable.Location = New System.Drawing.Point(686, 9)
        Me.btnViewTable.Name = "btnViewTable"
        Me.btnViewTable.Size = New System.Drawing.Size(83, 37)
        Me.btnViewTable.TabIndex = 7
        Me.btnViewTable.Text = "Table"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 3)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(340, 12)
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
        Me.pnlTopHeader.Location = New System.Drawing.Point(234, 0)
        Me.pnlTopHeader.Name = "pnlTopHeader"
        Me.pnlTopHeader.Size = New System.Drawing.Size(776, 52)
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
        Me.BtnView.TabIndex = 3
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
        Me.dtpToDate1.Location = New System.Drawing.Point(259, 18)
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
        Me.dtpToDate1.Size = New System.Drawing.Size(94, 22)
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
        Me.lblTopBannerSub.Size = New System.Drawing.Size(389, 23)
        Me.lblTopBannerSub.TabIndex = 1
        Me.lblTopBannerSub.Text = "Amt: ₹ 0.00   |   Qty: 0.00"
        '
        'lblTopBannerTitle
        '
        Me.lblTopBannerTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTopBannerTitle.ForeColor = System.Drawing.Color.White
        Me.lblTopBannerTitle.Location = New System.Drawing.Point(385, 5)
        Me.lblTopBannerTitle.Name = "lblTopBannerTitle"
        Me.lblTopBannerTitle.Size = New System.Drawing.Size(389, 23)
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
        Me.pnlTopBanner.Location = New System.Drawing.Point(234, 54)
        Me.pnlTopBanner.Name = "pnlTopBanner"
        Me.pnlTopBanner.Size = New System.Drawing.Size(776, 55)
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
        Me.DevExpressChartControl.Size = New System.Drawing.Size(772, 508)
        Me.DevExpressChartControl.TabIndex = 0
        '
        'pnlMainContent
        '
        Me.pnlMainContent.Controls.Add(Me.DevExpressChartControl)
        Me.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainContent.Location = New System.Drawing.Point(234, 109)
        Me.pnlMainContent.Name = "pnlMainContent"
        Me.pnlMainContent.Size = New System.Drawing.Size(776, 512)
        Me.pnlMainContent.TabIndex = 12
        '
        'pnlViewToggle
        '
        Me.pnlViewToggle.AutoSize = True
        Me.pnlViewToggle.BackColor = System.Drawing.Color.LightCyan
        Me.pnlViewToggle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlViewToggle.Location = New System.Drawing.Point(234, 52)
        Me.pnlViewToggle.Name = "pnlViewToggle"
        Me.pnlViewToggle.Size = New System.Drawing.Size(776, 0)
        Me.pnlViewToggle.TabIndex = 10
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
        Me.KeyPreview = True
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
    Friend WithEvents MainPartywise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Partywise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Itemwise5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Itemwise3 As DevExpress.XtraBars.Navigation.AccordionControlElement
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
    Friend WithEvents Partywise2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AgentWise2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AgentWise3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Itemwise4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Itemwise6 As DevExpress.XtraBars.Navigation.AccordionControlElement
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
    Friend WithEvents Partywise3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainAgentwise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Agentwise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainCityWise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents CityWise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Citywise2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents CityWise3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainItemWise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents ItemWise1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Itemwise2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents MainMonthWise As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
End Class
