<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class YarnPlaningEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YarnPlaningEntry))
        Me.txtOfferDate = New ctl_TextBox.ctl_TextBox()
        Me.txtEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_PlanningNo = New ctl_TextBox.ctl_TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.GrdItem = New FlexCell.Grid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PNL_View = New System.Windows.Forms.Panel()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Lbl_Tot_Mtr_Weight = New System.Windows.Forms.Label()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView2 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView3 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModify = New DevExpress.XtraEditors.SimpleButton()
        Me.But_export = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.PNL_View.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtOfferDate
        '
        Me.txtOfferDate._AllowSpace = True
        Me.txtOfferDate.AcceptsReturn = True
        Me.txtOfferDate.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtOfferDate.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtOfferDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOfferDate.Check_End_Date_Value_FY = "YES"
        Me.txtOfferDate.Check_Start_Date_Value_FY = "YES"
        Me.txtOfferDate.ClearField = False
        Me.txtOfferDate.CustomInputTypeString = Nothing
        Me.txtOfferDate.Date_for_Database = Nothing
        Me.txtOfferDate.Date_Tag = "BDATE"
        Me.txtOfferDate.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtOfferDate.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtOfferDate.ExtraValue = ""
        Me.txtOfferDate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOfferDate.FontFocusColor = System.Drawing.Color.Blue
        Me.txtOfferDate.FontLeaveColor = System.Drawing.Color.Black
        Me.txtOfferDate.ForeColor = System.Drawing.Color.Black
        Me.txtOfferDate.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txtOfferDate.IsValidated = False
        Me.txtOfferDate.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtOfferDate.Location = New System.Drawing.Point(284, 6)
        Me.txtOfferDate.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtOfferDate.MandatoryField = False
        Me.txtOfferDate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtOfferDate.MaxDate = Nothing
        Me.txtOfferDate.MaxLength = 10
        Me.txtOfferDate.MinDate = Nothing
        Me.txtOfferDate.Name = "txtOfferDate"
        Me.txtOfferDate.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtOfferDate.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtOfferDate.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtOfferDate.RegularExpression = Nothing
        Me.txtOfferDate.RegularExpressionErrorMessage = Nothing
        Me.txtOfferDate.ShowMessage = False
        Me.txtOfferDate.Size = New System.Drawing.Size(117, 22)
        Me.txtOfferDate.SpacerString = ""
        Me.txtOfferDate.TabIndex = 2
        Me.txtOfferDate.Tag = "OfferDate"
        Me.txtOfferDate.Text = "  /  /    "
        Me.txtOfferDate.TransparentBox = True
        Me.txtOfferDate.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtEntryNo
        '
        Me.txtEntryNo._AllowSpace = True
        Me.txtEntryNo.AcceptsReturn = True
        Me.txtEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtEntryNo.BackColor = System.Drawing.Color.Bisque
        Me.txtEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntryNo.Check_End_Date_Value_FY = "YES"
        Me.txtEntryNo.Check_Start_Date_Value_FY = "YES"
        Me.txtEntryNo.ClearField = True
        Me.txtEntryNo.CustomInputTypeString = Nothing
        Me.txtEntryNo.Date_for_Database = Nothing
        Me.txtEntryNo.Date_Tag = Nothing
        Me.txtEntryNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtEntryNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtEntryNo.ExtraValue = ""
        Me.txtEntryNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txtEntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txtEntryNo.ForeColor = System.Drawing.Color.Blue
        Me.txtEntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtEntryNo.IsValidated = False
        Me.txtEntryNo.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtEntryNo.Location = New System.Drawing.Point(90, 6)
        Me.txtEntryNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtEntryNo.MandatoryField = False
        Me.txtEntryNo.MaxDate = Nothing
        Me.txtEntryNo.MinDate = Nothing
        Me.txtEntryNo.Name = "txtEntryNo"
        Me.txtEntryNo.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtEntryNo.RegularExpression = Nothing
        Me.txtEntryNo.RegularExpressionErrorMessage = Nothing
        Me.txtEntryNo.ShowMessage = False
        Me.txtEntryNo.Size = New System.Drawing.Size(117, 22)
        Me.txtEntryNo.SpacerString = ""
        Me.txtEntryNo.TabIndex = 1
        Me.txtEntryNo.Tag = "ENTRYNO"
        Me.txtEntryNo.TransparentBox = True
        Me.txtEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(76, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 81937
        Me.Label17.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(270, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 14)
        Me.Label16.TabIndex = 81936
        Me.Label16.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 14)
        Me.Label15.TabIndex = 81935
        Me.Label15.Text = "Entry No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(223, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 14)
        Me.Label11.TabIndex = 81934
        Me.Label11.Text = "Date"
        '
        'Txt_PlanningNo
        '
        Me.Txt_PlanningNo._AllowSpace = True
        Me.Txt_PlanningNo.AcceptsReturn = True
        Me.Txt_PlanningNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_PlanningNo.BackColor = System.Drawing.Color.Lavender
        Me.Txt_PlanningNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_PlanningNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PlanningNo.Check_End_Date_Value_FY = "YES"
        Me.Txt_PlanningNo.Check_Start_Date_Value_FY = "YES"
        Me.Txt_PlanningNo.ClearField = True
        Me.Txt_PlanningNo.CustomInputTypeString = Nothing
        Me.Txt_PlanningNo.Date_for_Database = Nothing
        Me.Txt_PlanningNo.Date_Tag = Nothing
        Me.Txt_PlanningNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_PlanningNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_PlanningNo.ExtraValue = ""
        Me.Txt_PlanningNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PlanningNo.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_PlanningNo.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_PlanningNo.ForeColor = System.Drawing.Color.Black
        Me.Txt_PlanningNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_PlanningNo.IsValidated = False
        Me.Txt_PlanningNo.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.Txt_PlanningNo.Location = New System.Drawing.Point(518, 6)
        Me.Txt_PlanningNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_PlanningNo.MandatoryField = False
        Me.Txt_PlanningNo.MaxDate = Nothing
        Me.Txt_PlanningNo.MaxLength = 250
        Me.Txt_PlanningNo.MinDate = Nothing
        Me.Txt_PlanningNo.Multiline = True
        Me.Txt_PlanningNo.Name = "Txt_PlanningNo"
        Me.Txt_PlanningNo.NormalBorderColor = System.Drawing.Color.Lavender
        Me.Txt_PlanningNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_PlanningNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_PlanningNo.ReadOnly = True
        Me.Txt_PlanningNo.RegularExpression = Nothing
        Me.Txt_PlanningNo.RegularExpressionErrorMessage = Nothing
        Me.Txt_PlanningNo.ShowMessage = False
        Me.Txt_PlanningNo.Size = New System.Drawing.Size(117, 22)
        Me.Txt_PlanningNo.SpacerString = ""
        Me.Txt_PlanningNo.TabIndex = 3
        Me.Txt_PlanningNo.Tag = "OFFERNO"
        Me.Txt_PlanningNo.TransparentBox = True
        Me.Txt_PlanningNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label76.Location = New System.Drawing.Point(408, 10)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(86, 14)
        Me.Label76.TabIndex = 81975
        Me.Label76.Text = "Planning No"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(504, 10)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(12, 14)
        Me.Label77.TabIndex = 81976
        Me.Label77.Text = ":"
        '
        'GrdItem
        '
        Me.GrdItem.AllowUserReorderColumn = True
        Me.GrdItem.AllowUserSort = True
        Me.GrdItem.BackColorActiveCellSel = System.Drawing.SystemColors.Highlight
        Me.GrdItem.BackColorBkg = System.Drawing.Color.White
        Me.GrdItem.BackColorFixed = System.Drawing.Color.Khaki
        Me.GrdItem.BackColorFixedSel = System.Drawing.Color.White
        Me.GrdItem.BoldFixedCell = False
        Me.GrdItem.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.GrdItem.CellBorderColor = System.Drawing.Color.Gray
        Me.GrdItem.CellBorderColorFixed = System.Drawing.Color.Gray
        Me.GrdItem.CheckedImage = CType(resources.GetObject("GrdItem.CheckedImage"), System.Drawing.Bitmap)
        Me.GrdItem.Cols = 15
        Me.GrdItem.CommentIndicatorColor = System.Drawing.Color.Blue
        Me.GrdItem.DefaultFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrdItem.DefaultRowHeight = CType(25, Short)
        Me.GrdItem.DisplayRowNumber = True
        Me.GrdItem.EnableTabKey = False
        Me.GrdItem.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Light3D
        Me.GrdItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdItem.GridColor = System.Drawing.Color.SlateGray
        Me.GrdItem.Location = New System.Drawing.Point(4, 321)
        Me.GrdItem.MultiSelect = False
        Me.GrdItem.Name = "GrdItem"
        Me.GrdItem.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.GrdItem.ScrollBars = FlexCell.ScrollBarsEnum.None
        Me.GrdItem.SelectionBorderColor = System.Drawing.Color.Blue
        Me.GrdItem.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GrdItem.Size = New System.Drawing.Size(1030, 223)
        Me.GrdItem.TabIndex = 21
        Me.GrdItem.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.GrdItem.UncheckedImage = CType(resources.GetObject("GrdItem.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 21)
        Me.Label1.TabIndex = 81981
        Me.Label1.Text = "Requred Yarn In Planning"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SaddleBrown
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(665, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(267, 21)
        Me.Label2.TabIndex = 81982
        Me.Label2.Text = "Yarn Plan Stock "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PNL_View
        '
        Me.PNL_View.Controls.Add(Me.But_export)
        Me.PNL_View.Controls.Add(Me.But_print)
        Me.PNL_View.Controls.Add(Me.Btn_LayoutLoad)
        Me.PNL_View.Controls.Add(Me.BtnLayOutSave)
        Me.PNL_View.Controls.Add(Me.GridControl1)
        Me.PNL_View.Location = New System.Drawing.Point(731, 346)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(261, 188)
        Me.PNL_View.TabIndex = 81983
        Me.PNL_View.Visible = False
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(203, 9)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(119, 32)
        Me.Btn_LayoutLoad.TabIndex = 81917
        Me.Btn_LayoutLoad.Text = "Load Report"
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(83, 9)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(119, 32)
        Me.BtnLayOutSave.TabIndex = 81916
        Me.BtnLayOutSave.Text = "Save Report"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(14, 49)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(319, 159)
        Me.GridControl1.TabIndex = 81900
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FirstStage, Me.LayoutView1, Me.GridView2})
        '
        'FirstStage
        '
        Me.FirstStage.GridControl = Me.GridControl1
        Me.FirstStage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.FirstStage.Name = "FirstStage"
        Me.FirstStage.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.FirstStage.OptionsBehavior.Editable = False
        Me.FirstStage.OptionsFind.AlwaysVisible = True
        Me.FirstStage.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.FirstStage.OptionsView.ColumnAutoWidth = False
        Me.FirstStage.OptionsView.ShowAutoFilterRow = True
        Me.FirstStage.OptionsView.ShowFooter = True
        Me.FirstStage.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LayoutView1
        '
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsBehavior.Editable = False
        Me.LayoutView1.OptionsFind.AlwaysVisible = True
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'Lbl_Tot_Mtr_Weight
        '
        Me.Lbl_Tot_Mtr_Weight.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tot_Mtr_Weight.Location = New System.Drawing.Point(401, 548)
        Me.Lbl_Tot_Mtr_Weight.Name = "Lbl_Tot_Mtr_Weight"
        Me.Lbl_Tot_Mtr_Weight.Size = New System.Drawing.Size(101, 18)
        Me.Lbl_Tot_Mtr_Weight.TabIndex = 81987
        Me.Lbl_Tot_Mtr_Weight.Text = "Total :"
        Me.Lbl_Tot_Mtr_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(14, 548)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(49, 14)
        Me.lbl_Total.TabIndex = 81986
        Me.lbl_Total.Text = "Total :"
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl2
        Me.GridView3.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsFind.AlwaysVisible = True
        Me.GridView3.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(4, 87)
        Me.GridControl2.MainView = Me.GridView1
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(660, 228)
        Me.GridControl2.TabIndex = 81988
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.LayoutView2, Me.GridView3})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl2
        Me.GridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LayoutView2
        '
        Me.LayoutView2.GridControl = Me.GridControl2
        Me.LayoutView2.Name = "LayoutView2"
        Me.LayoutView2.OptionsBehavior.Editable = False
        Me.LayoutView2.OptionsFind.AlwaysVisible = True
        Me.LayoutView2.TemplateCard = Me.LayoutViewCard2
        '
        'LayoutViewCard2
        '
        Me.LayoutViewCard2.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard2.Name = "LayoutViewCard1"
        '
        'GridControl3
        '
        Me.GridControl3.Location = New System.Drawing.Point(664, 87)
        Me.GridControl3.MainView = Me.GridView4
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(370, 228)
        Me.GridControl3.TabIndex = 81989
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4, Me.LayoutView3, Me.GridView5})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GridControl3
        Me.GridView4.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.Editable = False
        Me.GridView4.OptionsFind.AlwaysVisible = True
        Me.GridView4.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        Me.GridView4.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LayoutView3
        '
        Me.LayoutView3.GridControl = Me.GridControl3
        Me.LayoutView3.Name = "LayoutView3"
        Me.LayoutView3.OptionsBehavior.Editable = False
        Me.LayoutView3.OptionsFind.AlwaysVisible = True
        Me.LayoutView3.TemplateCard = Me.LayoutViewCard3
        '
        'LayoutViewCard3
        '
        Me.LayoutViewCard3.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard3.Name = "LayoutViewCard1"
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GridControl3
        Me.GridView5.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.Editable = False
        Me.GridView5.OptionsFind.AlwaysVisible = True
        Me.GridView5.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView5.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnView)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnModify)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 569)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1066, 53)
        Me.GroupBox1.TabIndex = 81990
        Me.GroupBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.ImageOptions.Image = CType(resources.GetObject("btnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(663, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 36)
        Me.btnClose.TabIndex = 81951
        Me.btnClose.Text = "Close"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(492, 11)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 36)
        Me.btnView.TabIndex = 81950
        Me.btnView.Text = "View"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(575, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 36)
        Me.btnSave.TabIndex = 81946
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(401, 11)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(91, 36)
        Me.btnDelete.TabIndex = 81949
        Me.btnDelete.Text = "Delete"
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.ImageOptions.Image = CType(resources.GetObject("btnAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(237, 11)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 36)
        Me.btnAdd.TabIndex = 81947
        Me.btnAdd.Text = "Add"
        '
        'btnModify
        '
        Me.btnModify.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Appearance.Options.UseFont = True
        Me.btnModify.ImageOptions.Image = CType(resources.GetObject("btnModify.ImageOptions.Image"), System.Drawing.Image)
        Me.btnModify.Location = New System.Drawing.Point(313, 11)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(87, 36)
        Me.btnModify.TabIndex = 81948
        Me.btnModify.Text = "Modify"
        '
        'But_export
        '
        Me.But_export.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_export.Appearance.Options.UseFont = True
        Me.But_export.ImageOptions.Image = CType(resources.GetObject("But_export.ImageOptions.Image"), System.Drawing.Image)
        Me.But_export.Location = New System.Drawing.Point(43, 9)
        Me.But_export.Name = "But_export"
        Me.But_export.Size = New System.Drawing.Size(39, 36)
        Me.But_export.TabIndex = 81951
        '
        'But_print
        '
        Me.But_print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.Appearance.Options.UseFont = True
        Me.But_print.ImageOptions.Image = CType(resources.GetObject("But_print.ImageOptions.Image"), System.Drawing.Image)
        Me.But_print.Location = New System.Drawing.Point(3, 9)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(39, 36)
        Me.But_print.TabIndex = 81950
        '
        'YarnPlaningEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1037, 621)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridControl3)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.Lbl_Tot_Mtr_Weight)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.PNL_View)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GrdItem)
        Me.Controls.Add(Me.Txt_PlanningNo)
        Me.Controls.Add(Me.Label76)
        Me.Controls.Add(Me.Label77)
        Me.Controls.Add(Me.txtOfferDate)
        Me.Controls.Add(Me.txtEntryNo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "YarnPlaningEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Yarn Planning Entry"
        Me.PNL_View.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtOfferDate As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_PlanningNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents GrdItem As FlexCell.Grid
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PNL_View As Panel
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Lbl_Tot_Mtr_Weight As Label
    Friend WithEvents lbl_Total As Label
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView2 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard2 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView3 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard3 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModify As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
End Class
