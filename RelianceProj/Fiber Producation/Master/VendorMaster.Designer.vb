<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VendorMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorMaster))
        Me.Txtsection = New ctl_TextBox.ctl_TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Txt_Brand = New ctl_TextBox.ctl_TextBox()
        Me.txtEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.But_export = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Txt_MachineName = New ctl_TextBox.ctl_TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PNL_View = New System.Windows.Forms.Panel()
        Me.UC_Buttons1 = New RelianceProj.UC_Buttons()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNL_View.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Txtsection.Location = New System.Drawing.Point(162, 93)
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
        Me.Txtsection.Size = New System.Drawing.Size(248, 22)
        Me.Txtsection.SpacerString = ""
        Me.Txtsection.TabIndex = 82305
        Me.Txtsection.Tag = "TRANSPORT_MASTER"
        Me.Txtsection.TransparentBox = True
        Me.Txtsection.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
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
        Me.Txt_Brand.Location = New System.Drawing.Point(162, 66)
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
        Me.Txt_Brand.Size = New System.Drawing.Size(248, 22)
        Me.Txt_Brand.SpacerString = ""
        Me.Txt_Brand.TabIndex = 82304
        Me.Txt_Brand.Tag = "CITYMASTER"
        Me.Txt_Brand.TransparentBox = True
        Me.Txt_Brand.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
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
        Me.txtEntryNo.Location = New System.Drawing.Point(162, 14)
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
        Me.txtEntryNo.Size = New System.Drawing.Size(248, 22)
        Me.txtEntryNo.SpacerString = ""
        Me.txtEntryNo.TabIndex = 82302
        Me.txtEntryNo.Tag = "Main_account_master"
        Me.txtEntryNo.TransparentBox = True
        Me.txtEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
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
        Me.Txt_MachineName.Location = New System.Drawing.Point(162, 39)
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
        Me.Txt_MachineName.Size = New System.Drawing.Size(248, 22)
        Me.Txt_MachineName.SpacerString = ""
        Me.Txt_MachineName.TabIndex = 82303
        Me.Txt_MachineName.Tag = "STATEMASTER"
        Me.Txt_MachineName.TransparentBox = True
        Me.Txt_MachineName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(142, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 82331
        Me.Label17.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 82330
        Me.Label15.Text = "Vendor No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 14)
        Me.Label5.TabIndex = 82324
        Me.Label5.Text = "Vendor Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(142, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 82325
        Me.Label6.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 82322
        Me.Label2.Text = "Remark"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(142, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 82323
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(142, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 82321
        Me.Label4.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 14)
        Me.Label1.TabIndex = 82320
        Me.Label1.Text = "Vendor Name"
        '
        'PNL_View
        '
        Me.PNL_View.Controls.Add(Me.But_export)
        Me.PNL_View.Controls.Add(Me.But_print)
        Me.PNL_View.Controls.Add(Me.Btn_LayoutLoad)
        Me.PNL_View.Controls.Add(Me.BtnLayOutSave)
        Me.PNL_View.Controls.Add(Me.GridControl1)
        Me.PNL_View.Location = New System.Drawing.Point(954, 6)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(298, 195)
        Me.PNL_View.TabIndex = 82319
        Me.PNL_View.Visible = False
        '
        'UC_Buttons1
        '
        Me.UC_Buttons1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_Buttons1.Location = New System.Drawing.Point(0, 143)
        Me.UC_Buttons1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_Buttons1.Name = "UC_Buttons1"
        Me.UC_Buttons1.Size = New System.Drawing.Size(1008, 43)
        Me.UC_Buttons1.TabIndex = 82318
        '
        'VendorMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(546, 199)
        Me.Controls.Add(Me.Txtsection)
        Me.Controls.Add(Me.Txt_Brand)
        Me.Controls.Add(Me.txtEntryNo)
        Me.Controls.Add(Me.Txt_MachineName)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
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
        Me.Name = "VendorMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendor Master"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNL_View.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Txtsection As ctl_TextBox.ctl_TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Txt_Brand As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents But_export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Txt_MachineName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PNL_View As Panel
    Friend WithEvents UC_Buttons1 As UC_Buttons
End Class
