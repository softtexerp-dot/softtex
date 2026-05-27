<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachineMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MachineMaster))
        Me.UC_Buttons1 = New RelianceProj.UC_Buttons()
        Me.PNL_View = New System.Windows.Forms.Panel()
        Me.But_export = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MachineName = New ctl_TextBox.ctl_TextBox()
        Me.Txt_Brand = New ctl_TextBox.ctl_TextBox()
        Me.Txtsection = New ctl_TextBox.ctl_TextBox()
        Me.TxtBoolvalue = New ctl_TextBox.ctl_TextBox()
        Me.txtdepreciation = New ctl_TextBox.ctl_TextBox()
        Me.Txtspaceoccup = New ctl_TextBox.ctl_TextBox()
        Me.TxtCategory = New ctl_TextBox.ctl_TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtL = New ctl_TextBox.ctl_TextBox()
        Me.TxtW = New ctl_TextBox.ctl_TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtUOm = New ctl_TextBox.ctl_TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TxtHsn = New ctl_TextBox.ctl_TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtDepartMent = New ctl_TextBox.ctl_TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TxtAttachment = New ctl_TextBox.ctl_TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtTaxRate = New ctl_TextBox.ctl_TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.PNL_View.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UC_Buttons1
        '
        Me.UC_Buttons1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_Buttons1.Location = New System.Drawing.Point(2, 580)
        Me.UC_Buttons1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_Buttons1.Name = "UC_Buttons1"
        Me.UC_Buttons1.Size = New System.Drawing.Size(1008, 43)
        Me.UC_Buttons1.TabIndex = 82234
        '
        'PNL_View
        '
        Me.PNL_View.Controls.Add(Me.But_export)
        Me.PNL_View.Controls.Add(Me.But_print)
        Me.PNL_View.Controls.Add(Me.Btn_LayoutLoad)
        Me.PNL_View.Controls.Add(Me.BtnLayOutSave)
        Me.PNL_View.Controls.Add(Me.GridControl1)
        Me.PNL_View.Location = New System.Drawing.Point(712, 90)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(298, 195)
        Me.PNL_View.TabIndex = 82235
        Me.PNL_View.Visible = False
        '
        'But_export
        '
        Me.But_export.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_export.Appearance.Options.UseFont = True
        Me.But_export.ImageOptions.Image = CType(resources.GetObject("But_export.ImageOptions.Image"), System.Drawing.Image)
        Me.But_export.Location = New System.Drawing.Point(43, 8)
        Me.But_export.Name = "But_export"
        Me.But_export.Size = New System.Drawing.Size(39, 36)
        Me.But_export.TabIndex = 81949
        '
        'But_print
        '
        Me.But_print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.Appearance.Options.UseFont = True
        Me.But_print.ImageOptions.Image = CType(resources.GetObject("But_print.ImageOptions.Image"), System.Drawing.Image)
        Me.But_print.Location = New System.Drawing.Point(3, 8)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(39, 36)
        Me.But_print.TabIndex = 81948
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
        Me.GridControl1.Location = New System.Drawing.Point(3, 46)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(222, 134)
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
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 202)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(114, 14)
        Me.Label27.TabIndex = 82266
        Me.Label27.Text = "Assets Category"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(139, 202)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(12, 14)
        Me.Label28.TabIndex = 82267
        Me.Label28.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 174)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(112, 14)
        Me.Label25.TabIndex = 82264
        Me.Label25.Text = "Space Occupied"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(141, 174)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(12, 14)
        Me.Label26.TabIndex = 82265
        Me.Label26.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(141, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 82263
        Me.Label17.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 14)
        Me.Label15.TabIndex = 82261
        Me.Label15.Text = "Machine No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 14)
        Me.Label9.TabIndex = 82255
        Me.Label9.Text = "Depreciation(%)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(141, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 14)
        Me.Label10.TabIndex = 82256
        Me.Label10.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 14)
        Me.Label7.TabIndex = 82253
        Me.Label7.Text = "Bool Value"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(141, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 14)
        Me.Label8.TabIndex = 82254
        Me.Label8.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 82251
        Me.Label5.Text = "Section"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 82252
        Me.Label6.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 14)
        Me.Label2.TabIndex = 82249
        Me.Label2.Text = "Make/Brand"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(141, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 82250
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(141, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 82248
        Me.Label4.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 14)
        Me.Label1.TabIndex = 82247
        Me.Label1.Text = "Machine Name"
        '
        'txtEntryNo
        '
        Me.txtEntryNo._AllowSpace = True
        Me.txtEntryNo.AcceptsReturn = True
        Me.txtEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtEntryNo.BackColor = System.Drawing.Color.LightCyan
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
        Me.txtEntryNo.ForeColor = System.Drawing.Color.Black
        Me.txtEntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtEntryNo.IsValidated = False
        Me.txtEntryNo.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtEntryNo.Location = New System.Drawing.Point(161, 5)
        Me.txtEntryNo.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtEntryNo.MandatoryField = False
        Me.txtEntryNo.MaxDate = Nothing
        Me.txtEntryNo.MinDate = Nothing
        Me.txtEntryNo.Name = "txtEntryNo"
        Me.txtEntryNo.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtEntryNo.RegularExpression = Nothing
        Me.txtEntryNo.RegularExpressionErrorMessage = Nothing
        Me.txtEntryNo.ShowMessage = False
        Me.txtEntryNo.Size = New System.Drawing.Size(229, 22)
        Me.txtEntryNo.SpacerString = ""
        Me.txtEntryNo.TabIndex = 1
        Me.txtEntryNo.Tag = "Main_account_master"
        Me.txtEntryNo.TransparentBox = True
        Me.txtEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MachineName
        '
        Me.Txt_MachineName._AllowSpace = True
        Me.Txt_MachineName.AcceptsReturn = True
        Me.Txt_MachineName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MachineName.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_MachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MachineName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MachineName.Check_End_Date_Value_FY = "YES"
        Me.Txt_MachineName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MachineName.ClearField = True
        Me.Txt_MachineName.CustomInputTypeString = Nothing
        Me.Txt_MachineName.Date_for_Database = Nothing
        Me.Txt_MachineName.Date_Tag = Nothing
        Me.Txt_MachineName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MachineName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MachineName.ExtraValue = ""
        Me.Txt_MachineName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MachineName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MachineName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MachineName.ForeColor = System.Drawing.Color.Black
        Me.Txt_MachineName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_MachineName.IsValidated = False
        Me.Txt_MachineName.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_MachineName.Location = New System.Drawing.Point(161, 32)
        Me.Txt_MachineName.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_MachineName.MandatoryField = False
        Me.Txt_MachineName.MaxDate = Nothing
        Me.Txt_MachineName.MinDate = Nothing
        Me.Txt_MachineName.Name = "Txt_MachineName"
        Me.Txt_MachineName.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_MachineName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MachineName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MachineName.RegularExpression = Nothing
        Me.Txt_MachineName.RegularExpressionErrorMessage = Nothing
        Me.Txt_MachineName.ShowMessage = False
        Me.Txt_MachineName.Size = New System.Drawing.Size(229, 22)
        Me.Txt_MachineName.SpacerString = ""
        Me.Txt_MachineName.TabIndex = 2
        Me.Txt_MachineName.Tag = "STATEMASTER"
        Me.Txt_MachineName.TransparentBox = True
        Me.Txt_MachineName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_Brand
        '
        Me.Txt_Brand._AllowSpace = True
        Me.Txt_Brand.AcceptsReturn = True
        Me.Txt_Brand.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Brand.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_Brand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Brand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Brand.Check_End_Date_Value_FY = "YES"
        Me.Txt_Brand.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Brand.ClearField = True
        Me.Txt_Brand.CustomInputTypeString = Nothing
        Me.Txt_Brand.Date_for_Database = Nothing
        Me.Txt_Brand.Date_Tag = Nothing
        Me.Txt_Brand.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Brand.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Brand.ExtraValue = ""
        Me.Txt_Brand.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Brand.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Brand.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Brand.ForeColor = System.Drawing.Color.Black
        Me.Txt_Brand.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_Brand.IsValidated = False
        Me.Txt_Brand.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_Brand.Location = New System.Drawing.Point(161, 59)
        Me.Txt_Brand.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_Brand.MandatoryField = False
        Me.Txt_Brand.MaxDate = Nothing
        Me.Txt_Brand.MinDate = Nothing
        Me.Txt_Brand.Name = "Txt_Brand"
        Me.Txt_Brand.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_Brand.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Brand.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Brand.RegularExpression = Nothing
        Me.Txt_Brand.RegularExpressionErrorMessage = Nothing
        Me.Txt_Brand.ShowMessage = False
        Me.Txt_Brand.Size = New System.Drawing.Size(229, 22)
        Me.Txt_Brand.SpacerString = ""
        Me.Txt_Brand.TabIndex = 3
        Me.Txt_Brand.Tag = "CITYMASTER"
        Me.Txt_Brand.TransparentBox = True
        Me.Txt_Brand.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txtsection
        '
        Me.Txtsection._AllowSpace = True
        Me.Txtsection.AcceptsReturn = True
        Me.Txtsection.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txtsection.BackColor = System.Drawing.Color.LightCyan
        Me.Txtsection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtsection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtsection.Check_End_Date_Value_FY = "YES"
        Me.Txtsection.Check_Start_Date_Value_FY = "YES"
        Me.Txtsection.ClearField = True
        Me.Txtsection.CustomInputTypeString = Nothing
        Me.Txtsection.Date_for_Database = Nothing
        Me.Txtsection.Date_Tag = Nothing
        Me.Txtsection.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txtsection.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txtsection.ExtraValue = ""
        Me.Txtsection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsection.FontFocusColor = System.Drawing.Color.Blue
        Me.Txtsection.FontLeaveColor = System.Drawing.Color.Black
        Me.Txtsection.ForeColor = System.Drawing.Color.Black
        Me.Txtsection.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txtsection.IsValidated = False
        Me.Txtsection.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txtsection.Location = New System.Drawing.Point(161, 86)
        Me.Txtsection.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txtsection.MandatoryField = False
        Me.Txtsection.MaxDate = Nothing
        Me.Txtsection.MinDate = Nothing
        Me.Txtsection.Name = "Txtsection"
        Me.Txtsection.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txtsection.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txtsection.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txtsection.RegularExpression = Nothing
        Me.Txtsection.RegularExpressionErrorMessage = Nothing
        Me.Txtsection.ShowMessage = False
        Me.Txtsection.Size = New System.Drawing.Size(229, 22)
        Me.Txtsection.SpacerString = ""
        Me.Txtsection.TabIndex = 4
        Me.Txtsection.Tag = "TRANSPORT_MASTER"
        Me.Txtsection.TransparentBox = True
        Me.Txtsection.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'TxtBoolvalue
        '
        Me.TxtBoolvalue._AllowSpace = True
        Me.TxtBoolvalue.AcceptsReturn = True
        Me.TxtBoolvalue.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtBoolvalue.BackColor = System.Drawing.Color.LightCyan
        Me.TxtBoolvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBoolvalue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBoolvalue.Check_End_Date_Value_FY = "YES"
        Me.TxtBoolvalue.Check_Start_Date_Value_FY = "YES"
        Me.TxtBoolvalue.ClearField = True
        Me.TxtBoolvalue.CustomInputTypeString = Nothing
        Me.TxtBoolvalue.Date_for_Database = Nothing
        Me.TxtBoolvalue.Date_Tag = Nothing
        Me.TxtBoolvalue.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtBoolvalue.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtBoolvalue.ExtraValue = ""
        Me.TxtBoolvalue.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoolvalue.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtBoolvalue.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtBoolvalue.ForeColor = System.Drawing.Color.Black
        Me.TxtBoolvalue.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.TxtBoolvalue.IsValidated = False
        Me.TxtBoolvalue.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtBoolvalue.Location = New System.Drawing.Point(161, 114)
        Me.TxtBoolvalue.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtBoolvalue.MandatoryField = False
        Me.TxtBoolvalue.MaxDate = Nothing
        Me.TxtBoolvalue.MinDate = Nothing
        Me.TxtBoolvalue.Name = "TxtBoolvalue"
        Me.TxtBoolvalue.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtBoolvalue.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtBoolvalue.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtBoolvalue.RegularExpression = Nothing
        Me.TxtBoolvalue.RegularExpressionErrorMessage = Nothing
        Me.TxtBoolvalue.ShowMessage = False
        Me.TxtBoolvalue.Size = New System.Drawing.Size(229, 22)
        Me.TxtBoolvalue.SpacerString = ""
        Me.TxtBoolvalue.TabIndex = 5
        Me.TxtBoolvalue.Tag = "MSTFABRICMASTER"
        Me.TxtBoolvalue.TransparentBox = True
        Me.TxtBoolvalue.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtdepreciation
        '
        Me.txtdepreciation._AllowSpace = True
        Me.txtdepreciation.AcceptsReturn = True
        Me.txtdepreciation.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtdepreciation.BackColor = System.Drawing.Color.LightCyan
        Me.txtdepreciation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdepreciation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdepreciation.Check_End_Date_Value_FY = "YES"
        Me.txtdepreciation.Check_Start_Date_Value_FY = "YES"
        Me.txtdepreciation.ClearField = True
        Me.txtdepreciation.CustomInputTypeString = Nothing
        Me.txtdepreciation.Date_for_Database = Nothing
        Me.txtdepreciation.Date_Tag = Nothing
        Me.txtdepreciation.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtdepreciation.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtdepreciation.ExtraValue = ""
        Me.txtdepreciation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdepreciation.FontFocusColor = System.Drawing.Color.Blue
        Me.txtdepreciation.FontLeaveColor = System.Drawing.Color.Black
        Me.txtdepreciation.ForeColor = System.Drawing.Color.Black
        Me.txtdepreciation.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txtdepreciation.IsValidated = False
        Me.txtdepreciation.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtdepreciation.Location = New System.Drawing.Point(161, 143)
        Me.txtdepreciation.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtdepreciation.MandatoryField = False
        Me.txtdepreciation.MaxDate = Nothing
        Me.txtdepreciation.MinDate = Nothing
        Me.txtdepreciation.Name = "txtdepreciation"
        Me.txtdepreciation.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtdepreciation.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtdepreciation.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtdepreciation.RegularExpression = Nothing
        Me.txtdepreciation.RegularExpressionErrorMessage = Nothing
        Me.txtdepreciation.ShowMessage = False
        Me.txtdepreciation.Size = New System.Drawing.Size(229, 22)
        Me.txtdepreciation.SpacerString = ""
        Me.txtdepreciation.TabIndex = 6
        Me.txtdepreciation.Tag = "MSTFABRICHEAD"
        Me.txtdepreciation.TransparentBox = True
        Me.txtdepreciation.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txtspaceoccup
        '
        Me.Txtspaceoccup._AllowSpace = True
        Me.Txtspaceoccup.AcceptsReturn = True
        Me.Txtspaceoccup.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txtspaceoccup.BackColor = System.Drawing.Color.LightCyan
        Me.Txtspaceoccup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtspaceoccup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtspaceoccup.Check_End_Date_Value_FY = "YES"
        Me.Txtspaceoccup.Check_Start_Date_Value_FY = "YES"
        Me.Txtspaceoccup.ClearField = True
        Me.Txtspaceoccup.CustomInputTypeString = Nothing
        Me.Txtspaceoccup.Date_for_Database = Nothing
        Me.Txtspaceoccup.Date_Tag = Nothing
        Me.Txtspaceoccup.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txtspaceoccup.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txtspaceoccup.ExtraValue = ""
        Me.Txtspaceoccup.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtspaceoccup.FontFocusColor = System.Drawing.Color.Blue
        Me.Txtspaceoccup.FontLeaveColor = System.Drawing.Color.Black
        Me.Txtspaceoccup.ForeColor = System.Drawing.Color.Black
        Me.Txtspaceoccup.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.Txtspaceoccup.IsValidated = False
        Me.Txtspaceoccup.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txtspaceoccup.Location = New System.Drawing.Point(159, 171)
        Me.Txtspaceoccup.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txtspaceoccup.MandatoryField = False
        Me.Txtspaceoccup.MaxDate = Nothing
        Me.Txtspaceoccup.MinDate = Nothing
        Me.Txtspaceoccup.Name = "Txtspaceoccup"
        Me.Txtspaceoccup.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txtspaceoccup.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txtspaceoccup.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txtspaceoccup.RegularExpression = Nothing
        Me.Txtspaceoccup.RegularExpressionErrorMessage = Nothing
        Me.Txtspaceoccup.ShowMessage = False
        Me.Txtspaceoccup.Size = New System.Drawing.Size(149, 22)
        Me.Txtspaceoccup.SpacerString = ""
        Me.Txtspaceoccup.TabIndex = 7
        Me.Txtspaceoccup.Tag = "MSTFABRICGROUP"
        Me.Txtspaceoccup.TransparentBox = True
        Me.Txtspaceoccup.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'TxtCategory
        '
        Me.TxtCategory._AllowSpace = True
        Me.TxtCategory.AcceptsReturn = True
        Me.TxtCategory.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtCategory.BackColor = System.Drawing.Color.LightCyan
        Me.TxtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCategory.Check_End_Date_Value_FY = "YES"
        Me.TxtCategory.Check_Start_Date_Value_FY = "YES"
        Me.TxtCategory.ClearField = True
        Me.TxtCategory.CustomInputTypeString = Nothing
        Me.TxtCategory.Date_for_Database = Nothing
        Me.TxtCategory.Date_Tag = Nothing
        Me.TxtCategory.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtCategory.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtCategory.ExtraValue = ""
        Me.TxtCategory.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCategory.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtCategory.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtCategory.ForeColor = System.Drawing.Color.Black
        Me.TxtCategory.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtCategory.IsValidated = False
        Me.TxtCategory.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtCategory.Location = New System.Drawing.Point(159, 200)
        Me.TxtCategory.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtCategory.MandatoryField = False
        Me.TxtCategory.MaxDate = Nothing
        Me.TxtCategory.MinDate = Nothing
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtCategory.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtCategory.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtCategory.RegularExpression = Nothing
        Me.TxtCategory.RegularExpressionErrorMessage = Nothing
        Me.TxtCategory.ShowMessage = False
        Me.TxtCategory.Size = New System.Drawing.Size(149, 22)
        Me.TxtCategory.SpacerString = ""
        Me.TxtCategory.TabIndex = 10
        Me.TxtCategory.Tag = "MSTITEMCOMPANY"
        Me.TxtCategory.TransparentBox = True
        Me.TxtCategory.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(311, 171)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(15, 14)
        Me.Label19.TabIndex = 82280
        Me.Label19.Text = "L"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(377, 171)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 14)
        Me.Label20.TabIndex = 82281
        Me.Label20.Text = ":"
        '
        'TxtL
        '
        Me.TxtL._AllowSpace = True
        Me.TxtL.AcceptsReturn = True
        Me.TxtL.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtL.BackColor = System.Drawing.Color.LightCyan
        Me.TxtL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtL.Check_End_Date_Value_FY = "YES"
        Me.TxtL.Check_Start_Date_Value_FY = "YES"
        Me.TxtL.ClearField = True
        Me.TxtL.CustomInputTypeString = Nothing
        Me.TxtL.Date_for_Database = Nothing
        Me.TxtL.Date_Tag = Nothing
        Me.TxtL.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtL.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtL.ExtraValue = ""
        Me.TxtL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtL.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtL.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtL.ForeColor = System.Drawing.Color.Black
        Me.TxtL.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.TxtL.IsValidated = False
        Me.TxtL.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtL.Location = New System.Drawing.Point(386, 169)
        Me.TxtL.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtL.MandatoryField = False
        Me.TxtL.MaxDate = Nothing
        Me.TxtL.MinDate = Nothing
        Me.TxtL.Name = "TxtL"
        Me.TxtL.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtL.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtL.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtL.RegularExpression = Nothing
        Me.TxtL.RegularExpressionErrorMessage = Nothing
        Me.TxtL.ShowMessage = False
        Me.TxtL.Size = New System.Drawing.Size(129, 22)
        Me.TxtL.SpacerString = ""
        Me.TxtL.TabIndex = 8
        Me.TxtL.Tag = "MSTYARNMASTER"
        Me.TxtL.TransparentBox = True
        Me.TxtL.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'TxtW
        '
        Me.TxtW._AllowSpace = True
        Me.TxtW.AcceptsReturn = True
        Me.TxtW.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtW.BackColor = System.Drawing.Color.LightCyan
        Me.TxtW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtW.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtW.Check_End_Date_Value_FY = "YES"
        Me.TxtW.Check_Start_Date_Value_FY = "YES"
        Me.TxtW.ClearField = True
        Me.TxtW.CustomInputTypeString = Nothing
        Me.TxtW.Date_for_Database = Nothing
        Me.TxtW.Date_Tag = Nothing
        Me.TxtW.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtW.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtW.ExtraValue = ""
        Me.TxtW.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtW.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtW.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtW.ForeColor = System.Drawing.Color.Black
        Me.TxtW.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.TxtW.IsValidated = False
        Me.TxtW.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtW.Location = New System.Drawing.Point(557, 169)
        Me.TxtW.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtW.MandatoryField = False
        Me.TxtW.MaxDate = Nothing
        Me.TxtW.MinDate = Nothing
        Me.TxtW.Name = "TxtW"
        Me.TxtW.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtW.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtW.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtW.RegularExpression = Nothing
        Me.TxtW.RegularExpressionErrorMessage = Nothing
        Me.TxtW.ShowMessage = False
        Me.TxtW.Size = New System.Drawing.Size(149, 22)
        Me.TxtW.SpacerString = ""
        Me.TxtW.TabIndex = 9
        Me.TxtW.Tag = "MSTITEMGROUP"
        Me.TxtW.TransparentBox = True
        Me.TxtW.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(513, 171)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(21, 14)
        Me.Label21.TabIndex = 82283
        Me.Label21.Text = "W"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(538, 171)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(12, 14)
        Me.Label22.TabIndex = 82284
        Me.Label22.Text = ":"
        '
        'TxtUOm
        '
        Me.TxtUOm._AllowSpace = True
        Me.TxtUOm.AcceptsReturn = True
        Me.TxtUOm.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtUOm.BackColor = System.Drawing.Color.LightCyan
        Me.TxtUOm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUOm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUOm.Check_End_Date_Value_FY = "YES"
        Me.TxtUOm.Check_Start_Date_Value_FY = "YES"
        Me.TxtUOm.ClearField = True
        Me.TxtUOm.CustomInputTypeString = Nothing
        Me.TxtUOm.Date_for_Database = Nothing
        Me.TxtUOm.Date_Tag = Nothing
        Me.TxtUOm.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtUOm.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtUOm.ExtraValue = ""
        Me.TxtUOm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUOm.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtUOm.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtUOm.ForeColor = System.Drawing.Color.Black
        Me.TxtUOm.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtUOm.IsValidated = False
        Me.TxtUOm.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtUOm.Location = New System.Drawing.Point(394, 202)
        Me.TxtUOm.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtUOm.MandatoryField = False
        Me.TxtUOm.MaxDate = Nothing
        Me.TxtUOm.MinDate = Nothing
        Me.TxtUOm.Name = "TxtUOm"
        Me.TxtUOm.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtUOm.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtUOm.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtUOm.RegularExpression = Nothing
        Me.TxtUOm.RegularExpressionErrorMessage = Nothing
        Me.TxtUOm.ShowMessage = False
        Me.TxtUOm.Size = New System.Drawing.Size(278, 22)
        Me.TxtUOm.SpacerString = ""
        Me.TxtUOm.TabIndex = 11
        Me.TxtUOm.Tag = ""
        Me.TxtUOm.TransparentBox = True
        Me.TxtUOm.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(311, 206)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 14)
        Me.Label23.TabIndex = 82286
        Me.Label23.Text = "UOM"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(376, 206)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(12, 14)
        Me.Label24.TabIndex = 82287
        Me.Label24.Text = ":"
        '
        'TxtHsn
        '
        Me.TxtHsn._AllowSpace = True
        Me.TxtHsn.AcceptsReturn = True
        Me.TxtHsn.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtHsn.BackColor = System.Drawing.Color.LightCyan
        Me.TxtHsn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtHsn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtHsn.Check_End_Date_Value_FY = "YES"
        Me.TxtHsn.Check_Start_Date_Value_FY = "YES"
        Me.TxtHsn.ClearField = True
        Me.TxtHsn.CustomInputTypeString = Nothing
        Me.TxtHsn.Date_for_Database = Nothing
        Me.TxtHsn.Date_Tag = Nothing
        Me.TxtHsn.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtHsn.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtHsn.ExtraValue = ""
        Me.TxtHsn.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHsn.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtHsn.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtHsn.ForeColor = System.Drawing.Color.Black
        Me.TxtHsn.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtHsn.IsValidated = False
        Me.TxtHsn.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtHsn.Location = New System.Drawing.Point(159, 237)
        Me.TxtHsn.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtHsn.MandatoryField = False
        Me.TxtHsn.MaxDate = Nothing
        Me.TxtHsn.MinDate = Nothing
        Me.TxtHsn.Name = "TxtHsn"
        Me.TxtHsn.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtHsn.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtHsn.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtHsn.RegularExpression = Nothing
        Me.TxtHsn.RegularExpressionErrorMessage = Nothing
        Me.TxtHsn.ShowMessage = False
        Me.TxtHsn.Size = New System.Drawing.Size(149, 22)
        Me.TxtHsn.SpacerString = ""
        Me.TxtHsn.TabIndex = 12
        Me.TxtHsn.Tag = "MST_BARCODE"
        Me.TxtHsn.TransparentBox = True
        Me.TxtHsn.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 238)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(36, 14)
        Me.Label29.TabIndex = 82289
        Me.Label29.Text = "HSN"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(139, 238)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(12, 14)
        Me.Label30.TabIndex = 82290
        Me.Label30.Text = ":"
        '
        'TxtDepartMent
        '
        Me.TxtDepartMent._AllowSpace = True
        Me.TxtDepartMent.AcceptsReturn = True
        Me.TxtDepartMent.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtDepartMent.BackColor = System.Drawing.Color.LightCyan
        Me.TxtDepartMent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDepartMent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDepartMent.Check_End_Date_Value_FY = "YES"
        Me.TxtDepartMent.Check_Start_Date_Value_FY = "YES"
        Me.TxtDepartMent.ClearField = True
        Me.TxtDepartMent.CustomInputTypeString = Nothing
        Me.TxtDepartMent.Date_for_Database = Nothing
        Me.TxtDepartMent.Date_Tag = Nothing
        Me.TxtDepartMent.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtDepartMent.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtDepartMent.ExtraValue = ""
        Me.TxtDepartMent.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDepartMent.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtDepartMent.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtDepartMent.ForeColor = System.Drawing.Color.Black
        Me.TxtDepartMent.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtDepartMent.IsValidated = False
        Me.TxtDepartMent.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtDepartMent.Location = New System.Drawing.Point(157, 269)
        Me.TxtDepartMent.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtDepartMent.MandatoryField = False
        Me.TxtDepartMent.MaxDate = Nothing
        Me.TxtDepartMent.MinDate = Nothing
        Me.TxtDepartMent.Name = "TxtDepartMent"
        Me.TxtDepartMent.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtDepartMent.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtDepartMent.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtDepartMent.RegularExpression = Nothing
        Me.TxtDepartMent.RegularExpressionErrorMessage = Nothing
        Me.TxtDepartMent.ShowMessage = False
        Me.TxtDepartMent.Size = New System.Drawing.Size(149, 22)
        Me.TxtDepartMent.SpacerString = ""
        Me.TxtDepartMent.TabIndex = 14
        Me.TxtDepartMent.Tag = ""
        Me.TxtDepartMent.TransparentBox = True
        Me.TxtDepartMent.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 269)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(85, 14)
        Me.Label31.TabIndex = 82292
        Me.Label31.Text = "Department"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(137, 271)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(12, 14)
        Me.Label32.TabIndex = 82293
        Me.Label32.Text = ":"
        '
        'TxtAttachment
        '
        Me.TxtAttachment._AllowSpace = True
        Me.TxtAttachment.AcceptsReturn = True
        Me.TxtAttachment.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtAttachment.BackColor = System.Drawing.Color.LightCyan
        Me.TxtAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAttachment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAttachment.Check_End_Date_Value_FY = "YES"
        Me.TxtAttachment.Check_Start_Date_Value_FY = "YES"
        Me.TxtAttachment.ClearField = True
        Me.TxtAttachment.CustomInputTypeString = Nothing
        Me.TxtAttachment.Date_for_Database = Nothing
        Me.TxtAttachment.Date_Tag = Nothing
        Me.TxtAttachment.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtAttachment.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtAttachment.ExtraValue = ""
        Me.TxtAttachment.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAttachment.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtAttachment.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtAttachment.ForeColor = System.Drawing.Color.Black
        Me.TxtAttachment.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtAttachment.IsValidated = False
        Me.TxtAttachment.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtAttachment.Location = New System.Drawing.Point(159, 302)
        Me.TxtAttachment.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtAttachment.MandatoryField = False
        Me.TxtAttachment.MaxDate = Nothing
        Me.TxtAttachment.MinDate = Nothing
        Me.TxtAttachment.Name = "TxtAttachment"
        Me.TxtAttachment.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtAttachment.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtAttachment.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtAttachment.RegularExpression = Nothing
        Me.TxtAttachment.RegularExpressionErrorMessage = Nothing
        Me.TxtAttachment.ShowMessage = False
        Me.TxtAttachment.Size = New System.Drawing.Size(149, 22)
        Me.TxtAttachment.SpacerString = ""
        Me.TxtAttachment.TabIndex = 15
        Me.TxtAttachment.Tag = "MSTFABRIC_ITEM_CATEGORY"
        Me.TxtAttachment.TransparentBox = True
        Me.TxtAttachment.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(12, 304)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(128, 14)
        Me.Label33.TabIndex = 82295
        Me.Label33.Text = "Image Attachment"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(139, 304)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(12, 14)
        Me.Label34.TabIndex = 82296
        Me.Label34.Text = ":"
        '
        'TxtTaxRate
        '
        Me.TxtTaxRate._AllowSpace = True
        Me.TxtTaxRate.AcceptsReturn = True
        Me.TxtTaxRate.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtTaxRate.BackColor = System.Drawing.Color.LightCyan
        Me.TxtTaxRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTaxRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTaxRate.Check_End_Date_Value_FY = "YES"
        Me.TxtTaxRate.Check_Start_Date_Value_FY = "YES"
        Me.TxtTaxRate.ClearField = True
        Me.TxtTaxRate.CustomInputTypeString = Nothing
        Me.TxtTaxRate.Date_for_Database = Nothing
        Me.TxtTaxRate.Date_Tag = Nothing
        Me.TxtTaxRate.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtTaxRate.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtTaxRate.ExtraValue = ""
        Me.TxtTaxRate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTaxRate.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtTaxRate.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtTaxRate.ForeColor = System.Drawing.Color.Black
        Me.TxtTaxRate.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.TxtTaxRate.IsValidated = False
        Me.TxtTaxRate.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TxtTaxRate.Location = New System.Drawing.Point(393, 242)
        Me.TxtTaxRate.MandatoryColor = System.Drawing.Color.LightCyan
        Me.TxtTaxRate.MandatoryField = False
        Me.TxtTaxRate.MaxDate = Nothing
        Me.TxtTaxRate.MinDate = Nothing
        Me.TxtTaxRate.Name = "TxtTaxRate"
        Me.TxtTaxRate.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.TxtTaxRate.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtTaxRate.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtTaxRate.RegularExpression = Nothing
        Me.TxtTaxRate.RegularExpressionErrorMessage = Nothing
        Me.TxtTaxRate.ShowMessage = False
        Me.TxtTaxRate.Size = New System.Drawing.Size(279, 22)
        Me.TxtTaxRate.SpacerString = ""
        Me.TxtTaxRate.TabIndex = 13
        Me.TxtTaxRate.Tag = "MST_BATCHID"
        Me.TxtTaxRate.TransparentBox = True
        Me.TxtTaxRate.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(311, 244)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(65, 14)
        Me.Label35.TabIndex = 82298
        Me.Label35.Text = "Tax Rate"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(375, 244)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(12, 14)
        Me.Label36.TabIndex = 82299
        Me.Label36.Text = ":"
        '
        'MachineMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1012, 621)
        Me.Controls.Add(Me.TxtTaxRate)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.TxtAttachment)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.TxtDepartMent)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TxtHsn)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.TxtUOm)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TxtW)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TxtL)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.Txtspaceoccup)
        Me.Controls.Add(Me.txtdepreciation)
        Me.Controls.Add(Me.TxtBoolvalue)
        Me.Controls.Add(Me.Txtsection)
        Me.Controls.Add(Me.Txt_Brand)
        Me.Controls.Add(Me.Txt_MachineName)
        Me.Controls.Add(Me.txtEntryNo)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PNL_View)
        Me.Controls.Add(Me.UC_Buttons1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MachineMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixed Assets Master"
        Me.PNL_View.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UC_Buttons1 As UC_Buttons
    Friend WithEvents PNL_View As Panel
    Friend WithEvents But_export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MachineName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_Brand As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txtsection As ctl_TextBox.ctl_TextBox
    Friend WithEvents TxtBoolvalue As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtdepreciation As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txtspaceoccup As ctl_TextBox.ctl_TextBox
    Friend WithEvents TxtCategory As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TxtL As ctl_TextBox.ctl_TextBox
    Friend WithEvents TxtW As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtUOm As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents TxtHsn As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents TxtDepartMent As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents TxtAttachment As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents TxtTaxRate As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
End Class
