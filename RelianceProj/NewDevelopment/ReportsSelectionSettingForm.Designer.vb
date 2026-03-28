<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportsSelectionSettingForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportsSelectionSettingForm))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LblSelectedReportFormName = New System.Windows.Forms.Label()
        Me.BtnSaveMasterMenu = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_DeleteMasterItem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnInsertMasterItem = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnShrtCutRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.PnlNewReports = New System.Windows.Forms.Panel()
        Me.TxtReportFileName = New ctl_TextBox.ctl_TextBox()
        Me.Txt_ReportTitalName = New ctl_TextBox.ctl_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnReportNewClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnNewReportSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PnlQueryEdit = New System.Windows.Forms.Panel()
        Me.Txt_QueryEdit = New System.Windows.Forms.RichTextBox()
        Me.BtnQueryPanelHide = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_QuerySave = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_MasterSelection = New ctl_TextBox.ctl_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlNewReports.SuspendLayout()
        Me.PnlQueryEdit.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gray
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(521, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 23)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Selected Reports List"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 23)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "All Reports"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridControl2
        '
        Me.GridControl2.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(1, 2, 1, 2)
        Me.GridControl2.Location = New System.Drawing.Point(521, 87)
        Me.GridControl2.MainView = Me.GridView3
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(485, 543)
        Me.GridControl2.TabIndex = 20
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GridControl2
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsCustomization.CustomizationFormSnapMode = CType((((DevExpress.Utils.Controls.SnapMode.OwnerControl Or DevExpress.Utils.Controls.SnapMode.OwnerForm) _
            Or DevExpress.Utils.Controls.SnapMode.Screens) _
            Or DevExpress.Utils.Controls.SnapMode.SnapForms), DevExpress.Utils.Controls.SnapMode)
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(1, 2, 1, 2)
        Me.GridControl1.Location = New System.Drawing.Point(6, 87)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(420, 543)
        Me.GridControl1.TabIndex = 19
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsCustomization.CustomizationFormSnapMode = CType((((DevExpress.Utils.Controls.SnapMode.OwnerControl Or DevExpress.Utils.Controls.SnapMode.OwnerForm) _
            Or DevExpress.Utils.Controls.SnapMode.Screens) _
            Or DevExpress.Utils.Controls.SnapMode.SnapForms), DevExpress.Utils.Controls.SnapMode)
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseBackColor = True
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.ImageOptions.Image = CType(resources.GetObject("BtnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnClose.Location = New System.Drawing.Point(921, 9)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(83, 33)
        Me.BtnClose.TabIndex = 27
        Me.BtnClose.Text = "Close"
        '
        'LblSelectedReportFormName
        '
        Me.LblSelectedReportFormName.BackColor = System.Drawing.Color.SlateGray
        Me.LblSelectedReportFormName.ForeColor = System.Drawing.Color.White
        Me.LblSelectedReportFormName.Location = New System.Drawing.Point(2, 4)
        Me.LblSelectedReportFormName.Name = "LblSelectedReportFormName"
        Me.LblSelectedReportFormName.Size = New System.Drawing.Size(335, 25)
        Me.LblSelectedReportFormName.TabIndex = 26
        Me.LblSelectedReportFormName.Text = "Report Design Form"
        Me.LblSelectedReportFormName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSaveMasterMenu
        '
        Me.BtnSaveMasterMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSaveMasterMenu.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveMasterMenu.Appearance.Options.UseBackColor = True
        Me.BtnSaveMasterMenu.Appearance.Options.UseFont = True
        Me.BtnSaveMasterMenu.ImageOptions.Image = CType(resources.GetObject("BtnSaveMasterMenu.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSaveMasterMenu.Location = New System.Drawing.Point(834, 9)
        Me.BtnSaveMasterMenu.Name = "BtnSaveMasterMenu"
        Me.BtnSaveMasterMenu.Size = New System.Drawing.Size(83, 33)
        Me.BtnSaveMasterMenu.TabIndex = 23
        Me.BtnSaveMasterMenu.Text = "Save"
        '
        'Btn_DeleteMasterItem
        '
        Me.Btn_DeleteMasterItem.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.Btn_DeleteMasterItem.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_DeleteMasterItem.Appearance.Options.UseBackColor = True
        Me.Btn_DeleteMasterItem.Appearance.Options.UseFont = True
        Me.Btn_DeleteMasterItem.ImageOptions.Image = CType(resources.GetObject("Btn_DeleteMasterItem.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_DeleteMasterItem.Location = New System.Drawing.Point(432, 164)
        Me.Btn_DeleteMasterItem.Name = "Btn_DeleteMasterItem"
        Me.Btn_DeleteMasterItem.Size = New System.Drawing.Size(83, 29)
        Me.Btn_DeleteMasterItem.TabIndex = 22
        Me.Btn_DeleteMasterItem.Text = "Delete"
        '
        'BtnInsertMasterItem
        '
        Me.BtnInsertMasterItem.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnInsertMasterItem.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInsertMasterItem.Appearance.Options.UseBackColor = True
        Me.BtnInsertMasterItem.Appearance.Options.UseFont = True
        Me.BtnInsertMasterItem.ImageOptions.Image = CType(resources.GetObject("BtnInsertMasterItem.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnInsertMasterItem.Location = New System.Drawing.Point(432, 115)
        Me.BtnInsertMasterItem.Name = "BtnInsertMasterItem"
        Me.BtnInsertMasterItem.Size = New System.Drawing.Size(83, 29)
        Me.BtnInsertMasterItem.TabIndex = 21
        Me.BtnInsertMasterItem.Text = "Insert"
        '
        'BtnShrtCutRefresh
        '
        Me.BtnShrtCutRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnShrtCutRefresh.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnShrtCutRefresh.Appearance.Options.UseBackColor = True
        Me.BtnShrtCutRefresh.Appearance.Options.UseFont = True
        Me.BtnShrtCutRefresh.ImageOptions.Image = CType(resources.GetObject("BtnShrtCutRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnShrtCutRefresh.Location = New System.Drawing.Point(332, 56)
        Me.BtnShrtCutRefresh.Name = "BtnShrtCutRefresh"
        Me.BtnShrtCutRefresh.Size = New System.Drawing.Size(94, 31)
        Me.BtnShrtCutRefresh.TabIndex = 28
        Me.BtnShrtCutRefresh.Text = "Refresh"
        '
        'PnlNewReports
        '
        Me.PnlNewReports.BackColor = System.Drawing.Color.CadetBlue
        Me.PnlNewReports.Controls.Add(Me.Txt_MasterSelection)
        Me.PnlNewReports.Controls.Add(Me.Label10)
        Me.PnlNewReports.Controls.Add(Me.Label11)
        Me.PnlNewReports.Controls.Add(Me.TxtReportFileName)
        Me.PnlNewReports.Controls.Add(Me.Txt_ReportTitalName)
        Me.PnlNewReports.Controls.Add(Me.Label7)
        Me.PnlNewReports.Controls.Add(Me.Label6)
        Me.PnlNewReports.Controls.Add(Me.BtnReportNewClose)
        Me.PnlNewReports.Controls.Add(Me.BtnNewReportSave)
        Me.PnlNewReports.Controls.Add(Me.Label5)
        Me.PnlNewReports.Controls.Add(Me.Label4)
        Me.PnlNewReports.Controls.Add(Me.Label3)
        Me.PnlNewReports.Location = New System.Drawing.Point(322, 200)
        Me.PnlNewReports.Name = "PnlNewReports"
        Me.PnlNewReports.Size = New System.Drawing.Size(614, 220)
        Me.PnlNewReports.TabIndex = 29
        Me.PnlNewReports.Visible = False
        '
        'TxtReportFileName
        '
        Me.TxtReportFileName._AllowSpace = True
        Me.TxtReportFileName.AcceptsReturn = True
        Me.TxtReportFileName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtReportFileName.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtReportFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtReportFileName.Check_End_Date_Value_FY = "YES"
        Me.TxtReportFileName.Check_Start_Date_Value_FY = "YES"
        Me.TxtReportFileName.ClearField = True
        Me.TxtReportFileName.CustomInputTypeString = Nothing
        Me.TxtReportFileName.Date_for_Database = Nothing
        Me.TxtReportFileName.Date_Tag = Nothing
        Me.TxtReportFileName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtReportFileName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtReportFileName.ExtraValue = ""
        Me.TxtReportFileName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReportFileName.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtReportFileName.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtReportFileName.ForeColor = System.Drawing.Color.Black
        Me.TxtReportFileName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtReportFileName.IsValidated = False
        Me.TxtReportFileName.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.TxtReportFileName.Location = New System.Drawing.Point(181, 103)
        Me.TxtReportFileName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtReportFileName.MandatoryField = False
        Me.TxtReportFileName.MaxDate = Nothing
        Me.TxtReportFileName.MinDate = Nothing
        Me.TxtReportFileName.Name = "TxtReportFileName"
        Me.TxtReportFileName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.TxtReportFileName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtReportFileName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtReportFileName.RegularExpression = Nothing
        Me.TxtReportFileName.RegularExpressionErrorMessage = Nothing
        Me.TxtReportFileName.ShowMessage = False
        Me.TxtReportFileName.Size = New System.Drawing.Size(300, 22)
        Me.TxtReportFileName.SpacerString = ""
        Me.TxtReportFileName.TabIndex = 35
        Me.TxtReportFileName.Tag = "BOOKNAME"
        Me.TxtReportFileName.TransparentBox = True
        Me.TxtReportFileName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_ReportTitalName
        '
        Me.Txt_ReportTitalName._AllowSpace = True
        Me.Txt_ReportTitalName.AcceptsReturn = True
        Me.Txt_ReportTitalName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ReportTitalName.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_ReportTitalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ReportTitalName.Check_End_Date_Value_FY = "YES"
        Me.Txt_ReportTitalName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ReportTitalName.ClearField = True
        Me.Txt_ReportTitalName.CustomInputTypeString = Nothing
        Me.Txt_ReportTitalName.Date_for_Database = Nothing
        Me.Txt_ReportTitalName.Date_Tag = Nothing
        Me.Txt_ReportTitalName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_ReportTitalName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ReportTitalName.ExtraValue = ""
        Me.Txt_ReportTitalName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ReportTitalName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ReportTitalName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ReportTitalName.ForeColor = System.Drawing.Color.Black
        Me.Txt_ReportTitalName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_ReportTitalName.IsValidated = False
        Me.Txt_ReportTitalName.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_ReportTitalName.Location = New System.Drawing.Point(181, 67)
        Me.Txt_ReportTitalName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ReportTitalName.MandatoryField = False
        Me.Txt_ReportTitalName.MaxDate = Nothing
        Me.Txt_ReportTitalName.MinDate = Nothing
        Me.Txt_ReportTitalName.Name = "Txt_ReportTitalName"
        Me.Txt_ReportTitalName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_ReportTitalName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ReportTitalName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ReportTitalName.RegularExpression = Nothing
        Me.Txt_ReportTitalName.RegularExpressionErrorMessage = Nothing
        Me.Txt_ReportTitalName.ShowMessage = False
        Me.Txt_ReportTitalName.Size = New System.Drawing.Size(300, 22)
        Me.Txt_ReportTitalName.SpacerString = ""
        Me.Txt_ReportTitalName.TabIndex = 34
        Me.Txt_ReportTitalName.Tag = "BOOKNAME"
        Me.Txt_ReportTitalName.TransparentBox = True
        Me.Txt_ReportTitalName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(163, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(163, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = ":"
        '
        'BtnReportNewClose
        '
        Me.BtnReportNewClose.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnReportNewClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReportNewClose.Appearance.Options.UseBackColor = True
        Me.BtnReportNewClose.Appearance.Options.UseFont = True
        Me.BtnReportNewClose.ImageOptions.Image = CType(resources.GetObject("BtnReportNewClose.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnReportNewClose.Location = New System.Drawing.Point(297, 170)
        Me.BtnReportNewClose.Name = "BtnReportNewClose"
        Me.BtnReportNewClose.Size = New System.Drawing.Size(83, 33)
        Me.BtnReportNewClose.TabIndex = 42
        Me.BtnReportNewClose.Text = "Close"
        '
        'BtnNewReportSave
        '
        Me.BtnNewReportSave.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnNewReportSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNewReportSave.Appearance.Options.UseBackColor = True
        Me.BtnNewReportSave.Appearance.Options.UseFont = True
        Me.BtnNewReportSave.ImageOptions.Image = CType(resources.GetObject("BtnNewReportSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnNewReportSave.Location = New System.Drawing.Point(210, 170)
        Me.BtnNewReportSave.Name = "BtnNewReportSave"
        Me.BtnNewReportSave.Size = New System.Drawing.Size(83, 33)
        Me.BtnNewReportSave.TabIndex = 41
        Me.BtnNewReportSave.Text = "Save"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 16)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Report File Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Report Tital Name"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(496, 25)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "New Report Add"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PnlQueryEdit
        '
        Me.PnlQueryEdit.BackColor = System.Drawing.Color.Tan
        Me.PnlQueryEdit.Controls.Add(Me.Txt_QueryEdit)
        Me.PnlQueryEdit.Controls.Add(Me.BtnQueryPanelHide)
        Me.PnlQueryEdit.Controls.Add(Me.Btn_QuerySave)
        Me.PnlQueryEdit.Location = New System.Drawing.Point(704, 74)
        Me.PnlQueryEdit.Name = "PnlQueryEdit"
        Me.PnlQueryEdit.Size = New System.Drawing.Size(213, 223)
        Me.PnlQueryEdit.TabIndex = 30
        Me.PnlQueryEdit.Visible = False
        '
        'Txt_QueryEdit
        '
        Me.Txt_QueryEdit.Location = New System.Drawing.Point(3, 44)
        Me.Txt_QueryEdit.Name = "Txt_QueryEdit"
        Me.Txt_QueryEdit.Size = New System.Drawing.Size(1000, 579)
        Me.Txt_QueryEdit.TabIndex = 33
        Me.Txt_QueryEdit.Text = ""
        '
        'BtnQueryPanelHide
        '
        Me.BtnQueryPanelHide.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnQueryPanelHide.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQueryPanelHide.Appearance.Options.UseBackColor = True
        Me.BtnQueryPanelHide.Appearance.Options.UseFont = True
        Me.BtnQueryPanelHide.ImageOptions.Image = CType(resources.GetObject("BtnQueryPanelHide.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnQueryPanelHide.Location = New System.Drawing.Point(859, 8)
        Me.BtnQueryPanelHide.Name = "BtnQueryPanelHide"
        Me.BtnQueryPanelHide.Size = New System.Drawing.Size(83, 33)
        Me.BtnQueryPanelHide.TabIndex = 32
        Me.BtnQueryPanelHide.Text = "Close"
        '
        'Btn_QuerySave
        '
        Me.Btn_QuerySave.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_QuerySave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_QuerySave.Appearance.Options.UseBackColor = True
        Me.Btn_QuerySave.Appearance.Options.UseFont = True
        Me.Btn_QuerySave.ImageOptions.Image = CType(resources.GetObject("Btn_QuerySave.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_QuerySave.Location = New System.Drawing.Point(772, 8)
        Me.Btn_QuerySave.Name = "Btn_QuerySave"
        Me.Btn_QuerySave.Size = New System.Drawing.Size(83, 33)
        Me.Btn_QuerySave.TabIndex = 31
        Me.Btn_QuerySave.Text = "Save"
        '
        'Txt_MasterSelection
        '
        Me.Txt_MasterSelection._AllowSpace = True
        Me.Txt_MasterSelection.AcceptsReturn = True
        Me.Txt_MasterSelection.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MasterSelection.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_MasterSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MasterSelection.Check_End_Date_Value_FY = "YES"
        Me.Txt_MasterSelection.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MasterSelection.ClearField = True
        Me.Txt_MasterSelection.CustomInputTypeString = Nothing
        Me.Txt_MasterSelection.Date_for_Database = Nothing
        Me.Txt_MasterSelection.Date_Tag = Nothing
        Me.Txt_MasterSelection.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MasterSelection.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MasterSelection.ExtraValue = ""
        Me.Txt_MasterSelection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MasterSelection.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MasterSelection.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MasterSelection.ForeColor = System.Drawing.Color.Black
        Me.Txt_MasterSelection.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_MasterSelection.IsValidated = False
        Me.Txt_MasterSelection.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_MasterSelection.Location = New System.Drawing.Point(181, 134)
        Me.Txt_MasterSelection.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MasterSelection.MandatoryField = False
        Me.Txt_MasterSelection.MaxDate = Nothing
        Me.Txt_MasterSelection.MinDate = Nothing
        Me.Txt_MasterSelection.Name = "Txt_MasterSelection"
        Me.Txt_MasterSelection.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MasterSelection.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MasterSelection.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MasterSelection.ReadOnly = True
        Me.Txt_MasterSelection.RegularExpression = Nothing
        Me.Txt_MasterSelection.RegularExpressionErrorMessage = Nothing
        Me.Txt_MasterSelection.ShowMessage = False
        Me.Txt_MasterSelection.Size = New System.Drawing.Size(300, 22)
        Me.Txt_MasterSelection.SpacerString = ""
        Me.Txt_MasterSelection.TabIndex = 36
        Me.Txt_MasterSelection.Tag = "BOOKNAME"
        Me.Txt_MasterSelection.TransparentBox = True
        Me.Txt_MasterSelection.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(164, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 16)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 16)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Master Selection"
        '
        'ReportsSelectionSettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(1010, 634)
        Me.Controls.Add(Me.PnlQueryEdit)
        Me.Controls.Add(Me.PnlNewReports)
        Me.Controls.Add(Me.BtnShrtCutRefresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.LblSelectedReportFormName)
        Me.Controls.Add(Me.BtnSaveMasterMenu)
        Me.Controls.Add(Me.Btn_DeleteMasterItem)
        Me.Controls.Add(Me.BtnInsertMasterItem)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportsSelectionSettingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reports Selection Setting"
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlNewReports.ResumeLayout(False)
        Me.PnlNewReports.PerformLayout()
        Me.PnlQueryEdit.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LblSelectedReportFormName As Label
    Friend WithEvents BtnSaveMasterMenu As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_DeleteMasterItem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnInsertMasterItem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnShrtCutRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PnlNewReports As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnReportNewClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnNewReportSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtReportFileName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_ReportTitalName As ctl_TextBox.ctl_TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PnlQueryEdit As Panel
    Friend WithEvents Txt_QueryEdit As RichTextBox
    Friend WithEvents BtnQueryPanelHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_QuerySave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Txt_MasterSelection As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class
