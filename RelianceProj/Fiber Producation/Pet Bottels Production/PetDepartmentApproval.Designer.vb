<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PetDepartmentApproval
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PetDepartmentApproval))
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtUnitName = New ctl_TextBox.ctl_TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Status = New ctl_TextBox.ctl_TextBox()
        Me.btnviewupdate = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_xl = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(597, 16)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(12, 14)
        Me.Label41.TabIndex = 82254
        Me.Label41.Text = ":"
        '
        'txtUnitName
        '
        Me.txtUnitName._AllowSpace = True
        Me.txtUnitName.AcceptsReturn = True
        Me.txtUnitName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtUnitName.BackColor = System.Drawing.Color.LightCyan
        Me.txtUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitName.Check_End_Date_Value_FY = "YES"
        Me.txtUnitName.Check_Start_Date_Value_FY = "YES"
        Me.txtUnitName.ClearField = True
        Me.txtUnitName.CustomInputTypeString = Nothing
        Me.txtUnitName.Date_for_Database = Nothing
        Me.txtUnitName.Date_Tag = Nothing
        Me.txtUnitName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtUnitName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.txtUnitName.ExtraValue = ""
        Me.txtUnitName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtUnitName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtUnitName.ForeColor = System.Drawing.Color.Black
        Me.txtUnitName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtUnitName.IsValidated = False
        Me.txtUnitName.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtUnitName.Location = New System.Drawing.Point(607, 15)
        Me.txtUnitName.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtUnitName.MandatoryField = False
        Me.txtUnitName.MaxDate = Nothing
        Me.txtUnitName.MinDate = Nothing
        Me.txtUnitName.Name = "txtUnitName"
        Me.txtUnitName.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtUnitName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtUnitName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtUnitName.ReadOnly = True
        Me.txtUnitName.RegularExpression = Nothing
        Me.txtUnitName.RegularExpressionErrorMessage = Nothing
        Me.txtUnitName.ShowMessage = False
        Me.txtUnitName.Size = New System.Drawing.Size(155, 22)
        Me.txtUnitName.SpacerString = ""
        Me.txtUnitName.TabIndex = 82241
        Me.txtUnitName.Tag = "BOOKNAME"
        Me.txtUnitName.TransparentBox = True
        Me.txtUnitName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(520, 15)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(76, 14)
        Me.Label50.TabIndex = 82253
        Me.Label50.Text = "Unit Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(465, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 82252
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(361, 15)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 14)
        Me.Label3.TabIndex = 82251
        Me.Label3.Text = "Approve Status"
        '
        'txt_Status
        '
        Me.txt_Status._AllowSpace = True
        Me.txt_Status.AcceptsReturn = True
        Me.txt_Status.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Status.BackColor = System.Drawing.Color.LightCyan
        Me.txt_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Status.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Status.Check_End_Date_Value_FY = "YES"
        Me.txt_Status.Check_Start_Date_Value_FY = "YES"
        Me.txt_Status.ClearField = True
        Me.txt_Status.CustomInputTypeString = Nothing
        Me.txt_Status.Date_for_Database = Nothing
        Me.txt_Status.Date_Tag = Nothing
        Me.txt_Status.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Status.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Status.ExtraValue = ""
        Me.txt_Status.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Status.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Status.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Status.ForeColor = System.Drawing.Color.Black
        Me.txt_Status.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.txt_Status.IsValidated = False
        Me.txt_Status.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_Status.Location = New System.Drawing.Point(481, 13)
        Me.txt_Status.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Status.MandatoryField = False
        Me.txt_Status.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_Status.MaxDate = Nothing
        Me.txt_Status.MinDate = Nothing
        Me.txt_Status.Name = "txt_Status"
        Me.txt_Status.NormalBorderColor = System.Drawing.Color.White
        Me.txt_Status.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Status.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Status.ReadOnly = True
        Me.txt_Status.RegularExpression = Nothing
        Me.txt_Status.RegularExpressionErrorMessage = Nothing
        Me.txt_Status.ShortcutsEnabled = False
        Me.txt_Status.ShowMessage = False
        Me.txt_Status.Size = New System.Drawing.Size(33, 22)
        Me.txt_Status.SpacerString = "NO,YES,ALL"
        Me.txt_Status.TabIndex = 82240
        Me.txt_Status.Tag = "OP19"
        Me.txt_Status.Text = "NO"
        Me.txt_Status.TransparentBox = True
        Me.txt_Status.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'btnviewupdate
        '
        Me.btnviewupdate.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewupdate.Appearance.Options.UseFont = True
        Me.btnviewupdate.ImageOptions.Image = CType(resources.GetObject("btnviewupdate.ImageOptions.Image"), System.Drawing.Image)
        Me.btnviewupdate.Location = New System.Drawing.Point(845, 5)
        Me.btnviewupdate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnviewupdate.Name = "btnviewupdate"
        Me.btnviewupdate.Size = New System.Drawing.Size(96, 36)
        Me.btnviewupdate.TabIndex = 82250
        Me.btnviewupdate.Text = "Update"
        '
        'btn_xl
        '
        Me.btn_xl.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xl.Appearance.Options.UseFont = True
        Me.btn_xl.ImageOptions.Image = CType(resources.GetObject("btn_xl.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_xl.Location = New System.Drawing.Point(990, 5)
        Me.btn_xl.Name = "btn_xl"
        Me.btn_xl.Size = New System.Drawing.Size(39, 36)
        Me.btn_xl.TabIndex = 82249
        '
        'But_print
        '
        Me.But_print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.Appearance.Options.UseFont = True
        Me.But_print.ImageOptions.Image = CType(resources.GetObject("But_print.ImageOptions.Image"), System.Drawing.Image)
        Me.But_print.Location = New System.Drawing.Point(948, 5)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(39, 36)
        Me.But_print.TabIndex = 82248
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(768, 5)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(70, 36)
        Me.But_ok.TabIndex = 82242
        Me.But_ok.Text = "OK"
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(1076, 5)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(40, 36)
        Me.Btn_LayoutLoad.TabIndex = 82247
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(1032, 5)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(41, 36)
        Me.BtnLayOutSave.TabIndex = 82246
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(2, 47)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1136, 589)
        Me.GridControl1.TabIndex = 82245
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
        'txt_From
        '
        Me.txt_From._AllowSpace = True
        Me.txt_From.AcceptsReturn = True
        Me.txt_From.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_From.BackColor = System.Drawing.Color.LightCyan
        Me.txt_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_From.Check_End_Date_Value_FY = "YES"
        Me.txt_From.Check_Start_Date_Value_FY = "YES"
        Me.txt_From.ClearField = True
        Me.txt_From.CustomInputTypeString = Nothing
        Me.txt_From.Date_for_Database = Nothing
        Me.txt_From.Date_Tag = Nothing
        Me.txt_From.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.txt_From.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_From.ExtraValue = ""
        Me.txt_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_From.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_From.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_From.ForeColor = System.Drawing.Color.Black
        Me.txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_From.IsValidated = False
        Me.txt_From.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_From.Location = New System.Drawing.Point(90, 12)
        Me.txt_From.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_From.MandatoryField = False
        Me.txt_From.MaxDate = Nothing
        Me.txt_From.MinDate = Nothing
        Me.txt_From.Name = "txt_From"
        Me.txt_From.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txt_From.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_From.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_From.RegularExpression = Nothing
        Me.txt_From.RegularExpressionErrorMessage = Nothing
        Me.txt_From.ShowMessage = False
        Me.txt_From.Size = New System.Drawing.Size(100, 22)
        Me.txt_From.SpacerString = ""
        Me.txt_From.TabIndex = 82238
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txt_To
        '
        Me.txt_To._AllowSpace = True
        Me.txt_To.AcceptsReturn = True
        Me.txt_To.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_To.BackColor = System.Drawing.Color.LightCyan
        Me.txt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_To.Check_End_Date_Value_FY = "YES"
        Me.txt_To.Check_Start_Date_Value_FY = "YES"
        Me.txt_To.ClearField = True
        Me.txt_To.CustomInputTypeString = Nothing
        Me.txt_To.Date_for_Database = Nothing
        Me.txt_To.Date_Tag = Nothing
        Me.txt_To.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.txt_To.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_To.ExtraValue = ""
        Me.txt_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_To.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_To.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_To.ForeColor = System.Drawing.Color.Black
        Me.txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_To.IsValidated = False
        Me.txt_To.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_To.Location = New System.Drawing.Point(263, 12)
        Me.txt_To.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_To.MandatoryField = False
        Me.txt_To.MaxDate = Nothing
        Me.txt_To.MinDate = Nothing
        Me.txt_To.Name = "txt_To"
        Me.txt_To.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txt_To.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_To.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_To.RegularExpression = Nothing
        Me.txt_To.RegularExpressionErrorMessage = Nothing
        Me.txt_To.ShowMessage = False
        Me.txt_To.Size = New System.Drawing.Size(91, 22)
        Me.txt_To.SpacerString = ""
        Me.txt_To.TabIndex = 82239
        Me.txt_To.Tag = "BOOKNAME"
        Me.txt_To.Text = "  /  /    "
        Me.txt_To.TransparentBox = True
        Me.txt_To.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_To.Location = New System.Drawing.Point(197, 14)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 82244
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_From.Location = New System.Drawing.Point(9, 13)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 82243
        Me.lbl_From.Text = "Date From:"
        '
        'PetDepartmentApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1141, 641)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.txtUnitName)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_Status)
        Me.Controls.Add(Me.btnviewupdate)
        Me.Controls.Add(Me.btn_xl)
        Me.Controls.Add(Me.But_print)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.Btn_LayoutLoad)
        Me.Controls.Add(Me.BtnLayOutSave)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.txt_From)
        Me.Controls.Add(Me.txt_To)
        Me.Controls.Add(Me.lbl_To)
        Me.Controls.Add(Me.lbl_From)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PetDepartmentApproval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pet Machine Approval"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label41 As Label
    Friend WithEvents txtUnitName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_Status As ctl_TextBox.ctl_TextBox
    Friend WithEvents btnviewupdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_xl As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
End Class
