<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookMaster))
        Me.PnlGrdView = New System.Windows.Forms.GroupBox()
        Me.btnviewupdate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Txt_Bookcategory = New ctl_TextBox.ctl_TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Txt_Behaviour = New ctl_TextBox.ctl_TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_Alies = New ctl_TextBox.ctl_TextBox()
        Me.Txt_RptFileNamePlain = New ctl_TextBox.ctl_TextBox()
        Me.Txt_RcptIssue = New ctl_TextBox.ctl_TextBox()
        Me.Txt_BookId = New ctl_TextBox.ctl_TextBox()
        Me.Txt_BookName = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuActive = New ctl_TextBox.ctl_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtnature = New ctl_TextBox.ctl_TextBox()
        Me.txtUseChallan = New ctl_TextBox.ctl_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGroupCode = New ctl_TextBox.ctl_TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtReportTitle = New ctl_TextBox.ctl_TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txttrtype = New ctl_TextBox.ctl_TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Txt_BookCode = New ctl_TextBox.ctl_TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.PnlGrdView.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlGrdView
        '
        Me.PnlGrdView.BackColor = System.Drawing.Color.LightCyan
        Me.PnlGrdView.Controls.Add(Me.btnviewupdate)
        Me.PnlGrdView.Controls.Add(Me.BtnExport)
        Me.PnlGrdView.Controls.Add(Me.SimpleButton2)
        Me.PnlGrdView.Controls.Add(Me.BtnPrint)
        Me.PnlGrdView.Controls.Add(Me.Btn_LayoutLoad)
        Me.PnlGrdView.Controls.Add(Me.BtnLayOutSave)
        Me.PnlGrdView.Controls.Add(Me.GridControl1)
        Me.PnlGrdView.Location = New System.Drawing.Point(727, 12)
        Me.PnlGrdView.Name = "PnlGrdView"
        Me.PnlGrdView.Size = New System.Drawing.Size(482, 545)
        Me.PnlGrdView.TabIndex = 81973
        Me.PnlGrdView.TabStop = False
        Me.PnlGrdView.Visible = False
        '
        'btnviewupdate
        '
        Me.btnviewupdate.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewupdate.Appearance.Options.UseFont = True
        Me.btnviewupdate.ImageOptions.Image = CType(resources.GetObject("btnviewupdate.ImageOptions.Image"), System.Drawing.Image)
        Me.btnviewupdate.Location = New System.Drawing.Point(382, 11)
        Me.btnviewupdate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnviewupdate.Name = "btnviewupdate"
        Me.btnviewupdate.Size = New System.Drawing.Size(96, 34)
        Me.btnviewupdate.TabIndex = 81993
        Me.btnviewupdate.Text = "Update"
        '
        'BtnExport
        '
        Me.BtnExport.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Appearance.Options.UseFont = True
        Me.BtnExport.ImageOptions.Image = CType(resources.GetObject("BtnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExport.Location = New System.Drawing.Point(581, 11)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 34)
        Me.BtnExport.TabIndex = 81965
        Me.BtnExport.Text = "Export"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(310, 11)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(64, 34)
        Me.SimpleButton2.TabIndex = 81891
        Me.SimpleButton2.Text = "OK"
        Me.SimpleButton2.Visible = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.ImageOptions.Image = CType(resources.GetObject("BtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(485, 11)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 34)
        Me.BtnPrint.TabIndex = 81964
        Me.BtnPrint.Text = "Print"
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(814, 14)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(28, 32)
        Me.Btn_LayoutLoad.TabIndex = 81914
        Me.Btn_LayoutLoad.Visible = False
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(781, 14)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(26, 32)
        Me.BtnLayOutSave.TabIndex = 81913
        Me.BtnLayOutSave.Visible = False
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(6, 48)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(465, 491)
        Me.GridControl1.TabIndex = 81992
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
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(205, 216)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 14)
        Me.Label21.TabIndex = 81972
        Me.Label21.Text = ":"
        '
        'Txt_Bookcategory
        '
        Me.Txt_Bookcategory._AllowSpace = True
        Me.Txt_Bookcategory.AcceptsReturn = True
        Me.Txt_Bookcategory.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Bookcategory.BackColor = System.Drawing.Color.Bisque
        Me.Txt_Bookcategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Bookcategory.Check_End_Date_Value_FY = "YES"
        Me.Txt_Bookcategory.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Bookcategory.ClearField = True
        Me.Txt_Bookcategory.CustomInputTypeString = Nothing
        Me.Txt_Bookcategory.Date_for_Database = Nothing
        Me.Txt_Bookcategory.Date_Tag = Nothing
        Me.Txt_Bookcategory.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Bookcategory.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Bookcategory.ExtraValue = ""
        Me.Txt_Bookcategory.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bookcategory.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Bookcategory.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Bookcategory.ForeColor = System.Drawing.Color.Black
        Me.Txt_Bookcategory.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.Txt_Bookcategory.IsValidated = False
        Me.Txt_Bookcategory.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Bookcategory.Location = New System.Drawing.Point(224, 212)
        Me.Txt_Bookcategory.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_Bookcategory.MandatoryField = False
        Me.Txt_Bookcategory.MaxDate = Nothing
        Me.Txt_Bookcategory.MinDate = Nothing
        Me.Txt_Bookcategory.Name = "Txt_Bookcategory"
        Me.Txt_Bookcategory.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_Bookcategory.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Bookcategory.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Bookcategory.RegularExpression = Nothing
        Me.Txt_Bookcategory.RegularExpressionErrorMessage = Nothing
        Me.Txt_Bookcategory.ShowMessage = False
        Me.Txt_Bookcategory.Size = New System.Drawing.Size(470, 22)
        Me.Txt_Bookcategory.SpacerString = ""
        Me.Txt_Bookcategory.TabIndex = 8
        Me.Txt_Bookcategory.Tag = "MenuPosition"
        Me.Txt_Bookcategory.TransparentBox = True
        Me.Txt_Bookcategory.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 216)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 14)
        Me.Label22.TabIndex = 81971
        Me.Label22.Text = "Bookcategory"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(205, 156)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 14)
        Me.Label20.TabIndex = 81970
        Me.Label20.Text = ":"
        '
        'Txt_Behaviour
        '
        Me.Txt_Behaviour._AllowSpace = True
        Me.Txt_Behaviour.AcceptsReturn = True
        Me.Txt_Behaviour.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Behaviour.BackColor = System.Drawing.Color.Bisque
        Me.Txt_Behaviour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Behaviour.Check_End_Date_Value_FY = "YES"
        Me.Txt_Behaviour.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Behaviour.ClearField = True
        Me.Txt_Behaviour.CustomInputTypeString = Nothing
        Me.Txt_Behaviour.Date_for_Database = Nothing
        Me.Txt_Behaviour.Date_Tag = Nothing
        Me.Txt_Behaviour.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Behaviour.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Behaviour.ExtraValue = ""
        Me.Txt_Behaviour.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Behaviour.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Behaviour.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Behaviour.ForeColor = System.Drawing.Color.Black
        Me.Txt_Behaviour.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.Txt_Behaviour.IsValidated = False
        Me.Txt_Behaviour.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Behaviour.Location = New System.Drawing.Point(224, 152)
        Me.Txt_Behaviour.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_Behaviour.MandatoryField = False
        Me.Txt_Behaviour.MaxDate = Nothing
        Me.Txt_Behaviour.MinDate = Nothing
        Me.Txt_Behaviour.Name = "Txt_Behaviour"
        Me.Txt_Behaviour.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_Behaviour.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Behaviour.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Behaviour.RegularExpression = Nothing
        Me.Txt_Behaviour.RegularExpressionErrorMessage = Nothing
        Me.Txt_Behaviour.ShowMessage = False
        Me.Txt_Behaviour.Size = New System.Drawing.Size(470, 22)
        Me.Txt_Behaviour.SpacerString = ""
        Me.Txt_Behaviour.TabIndex = 6
        Me.Txt_Behaviour.Tag = "MenuPosition"
        Me.Txt_Behaviour.TransparentBox = True
        Me.Txt_Behaviour.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 156)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 14)
        Me.Label19.TabIndex = 81969
        Me.Label19.Text = "Behaviour"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(205, 270)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 14)
        Me.Label18.TabIndex = 81968
        Me.Label18.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(205, 354)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 81967
        Me.Label17.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(205, 186)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 14)
        Me.Label16.TabIndex = 81966
        Me.Label16.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(205, 376)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 14)
        Me.Label14.TabIndex = 81964
        Me.Label14.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(205, 242)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 14)
        Me.Label13.TabIndex = 81963
        Me.Label13.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(205, 123)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 14)
        Me.Label12.TabIndex = 81962
        Me.Label12.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(205, 95)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 14)
        Me.Label11.TabIndex = 81961
        Me.Label11.Text = ":"
        '
        'Txt_Alies
        '
        Me.Txt_Alies._AllowSpace = True
        Me.Txt_Alies.AcceptsReturn = True
        Me.Txt_Alies.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Alies.BackColor = System.Drawing.Color.Bisque
        Me.Txt_Alies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Alies.Check_End_Date_Value_FY = "YES"
        Me.Txt_Alies.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Alies.ClearField = True
        Me.Txt_Alies.CustomInputTypeString = Nothing
        Me.Txt_Alies.Date_for_Database = Nothing
        Me.Txt_Alies.Date_Tag = Nothing
        Me.Txt_Alies.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Alies.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.Txt_Alies.ExtraValue = ""
        Me.Txt_Alies.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Alies.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Alies.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Alies.ForeColor = System.Drawing.Color.Black
        Me.Txt_Alies.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.Txt_Alies.IsValidated = False
        Me.Txt_Alies.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Alies.Location = New System.Drawing.Point(224, 184)
        Me.Txt_Alies.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_Alies.MandatoryField = False
        Me.Txt_Alies.MaxDate = Nothing
        Me.Txt_Alies.MinDate = Nothing
        Me.Txt_Alies.Name = "Txt_Alies"
        Me.Txt_Alies.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_Alies.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Alies.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Alies.RegularExpression = Nothing
        Me.Txt_Alies.RegularExpressionErrorMessage = Nothing
        Me.Txt_Alies.ShowMessage = False
        Me.Txt_Alies.Size = New System.Drawing.Size(470, 22)
        Me.Txt_Alies.SpacerString = ""
        Me.Txt_Alies.TabIndex = 7
        Me.Txt_Alies.Tag = "MainMenuName"
        Me.Txt_Alies.TransparentBox = True
        Me.Txt_Alies.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_RptFileNamePlain
        '
        Me.Txt_RptFileNamePlain._AllowSpace = True
        Me.Txt_RptFileNamePlain.AcceptsReturn = True
        Me.Txt_RptFileNamePlain.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_RptFileNamePlain.BackColor = System.Drawing.Color.Bisque
        Me.Txt_RptFileNamePlain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_RptFileNamePlain.Check_End_Date_Value_FY = "YES"
        Me.Txt_RptFileNamePlain.Check_Start_Date_Value_FY = "YES"
        Me.Txt_RptFileNamePlain.ClearField = True
        Me.Txt_RptFileNamePlain.CustomInputTypeString = Nothing
        Me.Txt_RptFileNamePlain.Date_for_Database = Nothing
        Me.Txt_RptFileNamePlain.Date_Tag = Nothing
        Me.Txt_RptFileNamePlain.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_RptFileNamePlain.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_RptFileNamePlain.ExtraValue = ""
        Me.Txt_RptFileNamePlain.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RptFileNamePlain.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_RptFileNamePlain.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_RptFileNamePlain.ForeColor = System.Drawing.Color.Black
        Me.Txt_RptFileNamePlain.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphaNumeric
        Me.Txt_RptFileNamePlain.IsValidated = False
        Me.Txt_RptFileNamePlain.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_RptFileNamePlain.Location = New System.Drawing.Point(224, 268)
        Me.Txt_RptFileNamePlain.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_RptFileNamePlain.MandatoryField = False
        Me.Txt_RptFileNamePlain.MaxDate = Nothing
        Me.Txt_RptFileNamePlain.MinDate = Nothing
        Me.Txt_RptFileNamePlain.Name = "Txt_RptFileNamePlain"
        Me.Txt_RptFileNamePlain.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_RptFileNamePlain.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_RptFileNamePlain.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_RptFileNamePlain.RegularExpression = Nothing
        Me.Txt_RptFileNamePlain.RegularExpressionErrorMessage = Nothing
        Me.Txt_RptFileNamePlain.ShowMessage = False
        Me.Txt_RptFileNamePlain.Size = New System.Drawing.Size(470, 22)
        Me.Txt_RptFileNamePlain.SpacerString = ""
        Me.Txt_RptFileNamePlain.TabIndex = 10
        Me.Txt_RptFileNamePlain.Tag = "ShortCutKey"
        Me.Txt_RptFileNamePlain.TransparentBox = True
        Me.Txt_RptFileNamePlain.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_RcptIssue
        '
        Me.Txt_RcptIssue._AllowSpace = True
        Me.Txt_RcptIssue.AcceptsReturn = True
        Me.Txt_RcptIssue.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_RcptIssue.BackColor = System.Drawing.Color.Bisque
        Me.Txt_RcptIssue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_RcptIssue.Check_End_Date_Value_FY = "YES"
        Me.Txt_RcptIssue.Check_Start_Date_Value_FY = "YES"
        Me.Txt_RcptIssue.ClearField = True
        Me.Txt_RcptIssue.CustomInputTypeString = Nothing
        Me.Txt_RcptIssue.Date_for_Database = Nothing
        Me.Txt_RcptIssue.Date_Tag = Nothing
        Me.Txt_RcptIssue.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_RcptIssue.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_RcptIssue.ExtraValue = ""
        Me.Txt_RcptIssue.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RcptIssue.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_RcptIssue.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_RcptIssue.ForeColor = System.Drawing.Color.Black
        Me.Txt_RcptIssue.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.Txt_RcptIssue.IsValidated = False
        Me.Txt_RcptIssue.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_RcptIssue.Location = New System.Drawing.Point(224, 240)
        Me.Txt_RcptIssue.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_RcptIssue.MandatoryField = False
        Me.Txt_RcptIssue.MaxDate = Nothing
        Me.Txt_RcptIssue.MinDate = Nothing
        Me.Txt_RcptIssue.Name = "Txt_RcptIssue"
        Me.Txt_RcptIssue.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_RcptIssue.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_RcptIssue.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_RcptIssue.RegularExpression = Nothing
        Me.Txt_RcptIssue.RegularExpressionErrorMessage = Nothing
        Me.Txt_RcptIssue.ShowMessage = False
        Me.Txt_RcptIssue.Size = New System.Drawing.Size(470, 22)
        Me.Txt_RcptIssue.SpacerString = ""
        Me.Txt_RcptIssue.TabIndex = 9
        Me.Txt_RcptIssue.Tag = "MenuOrderNo"
        Me.Txt_RcptIssue.TransparentBox = True
        Me.Txt_RcptIssue.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_BookId
        '
        Me.Txt_BookId._AllowSpace = True
        Me.Txt_BookId.AcceptsReturn = True
        Me.Txt_BookId.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_BookId.BackColor = System.Drawing.Color.Bisque
        Me.Txt_BookId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_BookId.Check_End_Date_Value_FY = "YES"
        Me.Txt_BookId.Check_Start_Date_Value_FY = "YES"
        Me.Txt_BookId.ClearField = True
        Me.Txt_BookId.CustomInputTypeString = Nothing
        Me.Txt_BookId.Date_for_Database = Nothing
        Me.Txt_BookId.Date_Tag = Nothing
        Me.Txt_BookId.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_BookId.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_BookId.ExtraValue = ""
        Me.Txt_BookId.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_BookId.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_BookId.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_BookId.ForeColor = System.Drawing.Color.Black
        Me.Txt_BookId.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SerialNumber
        Me.Txt_BookId.IsValidated = False
        Me.Txt_BookId.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_BookId.Location = New System.Drawing.Point(224, 19)
        Me.Txt_BookId.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_BookId.MandatoryField = False
        Me.Txt_BookId.MaxDate = Nothing
        Me.Txt_BookId.MinDate = Nothing
        Me.Txt_BookId.Name = "Txt_BookId"
        Me.Txt_BookId.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_BookId.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_BookId.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_BookId.RegularExpression = Nothing
        Me.Txt_BookId.RegularExpressionErrorMessage = Nothing
        Me.Txt_BookId.ShowMessage = False
        Me.Txt_BookId.Size = New System.Drawing.Size(72, 22)
        Me.Txt_BookId.SpacerString = ""
        Me.Txt_BookId.TabIndex = 1
        Me.Txt_BookId.Tag = "MainId"
        Me.Txt_BookId.TransparentBox = True
        Me.Txt_BookId.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_BookName
        '
        Me.Txt_BookName._AllowSpace = True
        Me.Txt_BookName.AcceptsReturn = True
        Me.Txt_BookName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_BookName.BackColor = System.Drawing.Color.Bisque
        Me.Txt_BookName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_BookName.Check_End_Date_Value_FY = "YES"
        Me.Txt_BookName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_BookName.ClearField = True
        Me.Txt_BookName.CustomInputTypeString = Nothing
        Me.Txt_BookName.Date_for_Database = Nothing
        Me.Txt_BookName.Date_Tag = Nothing
        Me.Txt_BookName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_BookName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_BookName.ExtraValue = ""
        Me.Txt_BookName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_BookName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_BookName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_BookName.ForeColor = System.Drawing.Color.Black
        Me.Txt_BookName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_BookName.IsValidated = False
        Me.Txt_BookName.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_BookName.Location = New System.Drawing.Point(224, 93)
        Me.Txt_BookName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_BookName.MandatoryField = False
        Me.Txt_BookName.MaxDate = Nothing
        Me.Txt_BookName.MinDate = Nothing
        Me.Txt_BookName.Name = "Txt_BookName"
        Me.Txt_BookName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_BookName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_BookName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_BookName.RegularExpression = Nothing
        Me.Txt_BookName.RegularExpressionErrorMessage = Nothing
        Me.Txt_BookName.ShowMessage = False
        Me.Txt_BookName.Size = New System.Drawing.Size(470, 22)
        Me.Txt_BookName.SpacerString = ""
        Me.Txt_BookName.TabIndex = 4
        Me.Txt_BookName.Tag = "MenuName"
        Me.Txt_BookName.TransparentBox = True
        Me.Txt_BookName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuActive
        '
        Me.Txt_MenuActive._AllowSpace = True
        Me.Txt_MenuActive.AcceptsReturn = True
        Me.Txt_MenuActive.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuActive.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MenuActive.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuActive.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuActive.ClearField = True
        Me.Txt_MenuActive.CustomInputTypeString = Nothing
        Me.Txt_MenuActive.Date_for_Database = Nothing
        Me.Txt_MenuActive.Date_Tag = Nothing
        Me.Txt_MenuActive.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuActive.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuActive.ExtraValue = ""
        Me.Txt_MenuActive.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuActive.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuActive.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuActive.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuActive.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_MenuActive.IsValidated = False
        Me.Txt_MenuActive.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuActive.Location = New System.Drawing.Point(224, 380)
        Me.Txt_MenuActive.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuActive.MandatoryField = False
        Me.Txt_MenuActive.MaxDate = Nothing
        Me.Txt_MenuActive.MinDate = Nothing
        Me.Txt_MenuActive.Name = "Txt_MenuActive"
        Me.Txt_MenuActive.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuActive.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuActive.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuActive.ReadOnly = True
        Me.Txt_MenuActive.RegularExpression = Nothing
        Me.Txt_MenuActive.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuActive.ShowMessage = False
        Me.Txt_MenuActive.Size = New System.Drawing.Size(72, 22)
        Me.Txt_MenuActive.SpacerString = "NO,YES"
        Me.Txt_MenuActive.TabIndex = 14
        Me.Txt_MenuActive.Tag = "ActiveStatus"
        Me.Txt_MenuActive.Text = "NO"
        Me.Txt_MenuActive.TransparentBox = True
        Me.Txt_MenuActive.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 382)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 14)
        Me.Label10.TabIndex = 81960
        Me.Label10.Text = "Active"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 270)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 14)
        Me.Label9.TabIndex = 81959
        Me.Label9.Text = "Rpt File Name Plain"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 354)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 14)
        Me.Label7.TabIndex = 81958
        Me.Label7.Text = "Use Challan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 186)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 81957
        Me.Label5.Text = "Alies"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 242)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 81955
        Me.Label3.Text = "Rcpt Issue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 123)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 81954
        Me.Label2.Text = "Nature"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 95)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 81953
        Me.Label1.Text = "Book Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 14)
        Me.Label8.TabIndex = 81951
        Me.Label8.Text = "Book ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(205, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 81952
        Me.Label6.Text = ":"
        '
        'txtnature
        '
        Me.txtnature._AllowSpace = True
        Me.txtnature.AcceptsReturn = True
        Me.txtnature.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtnature.BackColor = System.Drawing.Color.Bisque
        Me.txtnature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnature.Check_End_Date_Value_FY = "YES"
        Me.txtnature.Check_Start_Date_Value_FY = "YES"
        Me.txtnature.ClearField = True
        Me.txtnature.CustomInputTypeString = Nothing
        Me.txtnature.Date_for_Database = Nothing
        Me.txtnature.Date_Tag = Nothing
        Me.txtnature.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtnature.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtnature.ExtraValue = ""
        Me.txtnature.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnature.FontFocusColor = System.Drawing.Color.Blue
        Me.txtnature.FontLeaveColor = System.Drawing.Color.Black
        Me.txtnature.ForeColor = System.Drawing.Color.Black
        Me.txtnature.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.txtnature.IsValidated = False
        Me.txtnature.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.txtnature.Location = New System.Drawing.Point(224, 121)
        Me.txtnature.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtnature.MandatoryField = False
        Me.txtnature.MaxDate = Nothing
        Me.txtnature.MinDate = Nothing
        Me.txtnature.Name = "txtnature"
        Me.txtnature.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtnature.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtnature.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtnature.RegularExpression = Nothing
        Me.txtnature.RegularExpressionErrorMessage = Nothing
        Me.txtnature.ShowMessage = False
        Me.txtnature.Size = New System.Drawing.Size(470, 22)
        Me.txtnature.SpacerString = ""
        Me.txtnature.TabIndex = 5
        Me.txtnature.Tag = "MenuPosition"
        Me.txtnature.TransparentBox = True
        Me.txtnature.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtUseChallan
        '
        Me.txtUseChallan._AllowSpace = True
        Me.txtUseChallan.AcceptsReturn = True
        Me.txtUseChallan.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtUseChallan.BackColor = System.Drawing.Color.Bisque
        Me.txtUseChallan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUseChallan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUseChallan.Check_End_Date_Value_FY = "YES"
        Me.txtUseChallan.Check_Start_Date_Value_FY = "YES"
        Me.txtUseChallan.ClearField = True
        Me.txtUseChallan.CustomInputTypeString = Nothing
        Me.txtUseChallan.Date_for_Database = Nothing
        Me.txtUseChallan.Date_Tag = Nothing
        Me.txtUseChallan.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtUseChallan.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtUseChallan.ExtraValue = ""
        Me.txtUseChallan.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUseChallan.FontFocusColor = System.Drawing.Color.Blue
        Me.txtUseChallan.FontLeaveColor = System.Drawing.Color.Black
        Me.txtUseChallan.ForeColor = System.Drawing.Color.Black
        Me.txtUseChallan.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.txtUseChallan.IsValidated = False
        Me.txtUseChallan.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.txtUseChallan.Location = New System.Drawing.Point(224, 352)
        Me.txtUseChallan.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtUseChallan.MandatoryField = False
        Me.txtUseChallan.MaxDate = Nothing
        Me.txtUseChallan.MinDate = Nothing
        Me.txtUseChallan.Name = "txtUseChallan"
        Me.txtUseChallan.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtUseChallan.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtUseChallan.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtUseChallan.ReadOnly = True
        Me.txtUseChallan.RegularExpression = Nothing
        Me.txtUseChallan.RegularExpressionErrorMessage = Nothing
        Me.txtUseChallan.ShowMessage = False
        Me.txtUseChallan.Size = New System.Drawing.Size(72, 22)
        Me.txtUseChallan.SpacerString = "NO,YES"
        Me.txtUseChallan.TabIndex = 13
        Me.txtUseChallan.Tag = "ActiveStatus"
        Me.txtUseChallan.Text = "NO"
        Me.txtUseChallan.TransparentBox = True
        Me.txtUseChallan.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(205, 298)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 81978
        Me.Label4.Text = ":"
        '
        'txtGroupCode
        '
        Me.txtGroupCode._AllowSpace = True
        Me.txtGroupCode.AcceptsReturn = True
        Me.txtGroupCode.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtGroupCode.BackColor = System.Drawing.Color.Bisque
        Me.txtGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGroupCode.Check_End_Date_Value_FY = "YES"
        Me.txtGroupCode.Check_Start_Date_Value_FY = "YES"
        Me.txtGroupCode.ClearField = True
        Me.txtGroupCode.CustomInputTypeString = Nothing
        Me.txtGroupCode.Date_for_Database = Nothing
        Me.txtGroupCode.Date_Tag = Nothing
        Me.txtGroupCode.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtGroupCode.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtGroupCode.ExtraValue = ""
        Me.txtGroupCode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupCode.FontFocusColor = System.Drawing.Color.Blue
        Me.txtGroupCode.FontLeaveColor = System.Drawing.Color.Black
        Me.txtGroupCode.ForeColor = System.Drawing.Color.Black
        Me.txtGroupCode.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtGroupCode.IsValidated = False
        Me.txtGroupCode.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.txtGroupCode.Location = New System.Drawing.Point(224, 296)
        Me.txtGroupCode.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtGroupCode.MandatoryField = False
        Me.txtGroupCode.MaxDate = Nothing
        Me.txtGroupCode.MinDate = Nothing
        Me.txtGroupCode.Name = "txtGroupCode"
        Me.txtGroupCode.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtGroupCode.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtGroupCode.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtGroupCode.RegularExpression = Nothing
        Me.txtGroupCode.RegularExpressionErrorMessage = Nothing
        Me.txtGroupCode.ShowMessage = False
        Me.txtGroupCode.Size = New System.Drawing.Size(470, 22)
        Me.txtGroupCode.SpacerString = ""
        Me.txtGroupCode.TabIndex = 11
        Me.txtGroupCode.Tag = "ShortCutKey"
        Me.txtGroupCode.TransparentBox = True
        Me.txtGroupCode.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 298)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 14)
        Me.Label15.TabIndex = 81977
        Me.Label15.Text = "Group Code"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(205, 326)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 14)
        Me.Label23.TabIndex = 81981
        Me.Label23.Text = ":"
        '
        'txtReportTitle
        '
        Me.txtReportTitle._AllowSpace = True
        Me.txtReportTitle.AcceptsReturn = True
        Me.txtReportTitle.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtReportTitle.BackColor = System.Drawing.Color.Bisque
        Me.txtReportTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReportTitle.Check_End_Date_Value_FY = "YES"
        Me.txtReportTitle.Check_Start_Date_Value_FY = "YES"
        Me.txtReportTitle.ClearField = True
        Me.txtReportTitle.CustomInputTypeString = Nothing
        Me.txtReportTitle.Date_for_Database = Nothing
        Me.txtReportTitle.Date_Tag = Nothing
        Me.txtReportTitle.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtReportTitle.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtReportTitle.ExtraValue = ""
        Me.txtReportTitle.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReportTitle.FontFocusColor = System.Drawing.Color.Blue
        Me.txtReportTitle.FontLeaveColor = System.Drawing.Color.Black
        Me.txtReportTitle.ForeColor = System.Drawing.Color.Black
        Me.txtReportTitle.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.txtReportTitle.IsValidated = False
        Me.txtReportTitle.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.txtReportTitle.Location = New System.Drawing.Point(224, 324)
        Me.txtReportTitle.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtReportTitle.MandatoryField = False
        Me.txtReportTitle.MaxDate = Nothing
        Me.txtReportTitle.MinDate = Nothing
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtReportTitle.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtReportTitle.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtReportTitle.RegularExpression = Nothing
        Me.txtReportTitle.RegularExpressionErrorMessage = Nothing
        Me.txtReportTitle.ShowMessage = False
        Me.txtReportTitle.Size = New System.Drawing.Size(470, 22)
        Me.txtReportTitle.SpacerString = ""
        Me.txtReportTitle.TabIndex = 12
        Me.txtReportTitle.Tag = "ShortCutKey"
        Me.txtReportTitle.TransparentBox = True
        Me.txtReportTitle.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(7, 326)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 14)
        Me.Label24.TabIndex = 81980
        Me.Label24.Text = "Report Title"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(205, 69)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(12, 14)
        Me.Label25.TabIndex = 81984
        Me.Label25.Text = ":"
        '
        'txttrtype
        '
        Me.txttrtype._AllowSpace = True
        Me.txttrtype.AcceptsReturn = True
        Me.txttrtype.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txttrtype.BackColor = System.Drawing.Color.Bisque
        Me.txttrtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttrtype.Check_End_Date_Value_FY = "YES"
        Me.txttrtype.Check_Start_Date_Value_FY = "YES"
        Me.txttrtype.ClearField = True
        Me.txttrtype.CustomInputTypeString = Nothing
        Me.txttrtype.Date_for_Database = Nothing
        Me.txttrtype.Date_Tag = Nothing
        Me.txttrtype.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txttrtype.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txttrtype.ExtraValue = ""
        Me.txttrtype.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttrtype.FontFocusColor = System.Drawing.Color.Blue
        Me.txttrtype.FontLeaveColor = System.Drawing.Color.Black
        Me.txttrtype.ForeColor = System.Drawing.Color.Black
        Me.txttrtype.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphaNumeric
        Me.txttrtype.IsValidated = False
        Me.txttrtype.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.txttrtype.Location = New System.Drawing.Point(224, 67)
        Me.txttrtype.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txttrtype.MandatoryField = False
        Me.txttrtype.MaxDate = Nothing
        Me.txttrtype.MinDate = Nothing
        Me.txttrtype.Name = "txttrtype"
        Me.txttrtype.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txttrtype.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txttrtype.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txttrtype.RegularExpression = Nothing
        Me.txttrtype.RegularExpressionErrorMessage = Nothing
        Me.txttrtype.ShowMessage = False
        Me.txttrtype.Size = New System.Drawing.Size(470, 22)
        Me.txttrtype.SpacerString = ""
        Me.txttrtype.TabIndex = 3
        Me.txttrtype.Tag = "MenuName"
        Me.txttrtype.TransparentBox = True
        Me.txttrtype.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(7, 69)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(94, 14)
        Me.Label26.TabIndex = 81983
        Me.Label26.Text = "Book Tr Type"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(204, 46)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(12, 14)
        Me.Label27.TabIndex = 81987
        Me.Label27.Text = ":"
        '
        'Txt_BookCode
        '
        Me.Txt_BookCode._AllowSpace = True
        Me.Txt_BookCode.AcceptsReturn = True
        Me.Txt_BookCode.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_BookCode.BackColor = System.Drawing.Color.Bisque
        Me.Txt_BookCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_BookCode.Check_End_Date_Value_FY = "YES"
        Me.Txt_BookCode.Check_Start_Date_Value_FY = "YES"
        Me.Txt_BookCode.ClearField = True
        Me.Txt_BookCode.CustomInputTypeString = Nothing
        Me.Txt_BookCode.Date_for_Database = Nothing
        Me.Txt_BookCode.Date_Tag = Nothing
        Me.Txt_BookCode.Enabled = False
        Me.Txt_BookCode.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_BookCode.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_BookCode.ExtraValue = ""
        Me.Txt_BookCode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_BookCode.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_BookCode.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_BookCode.ForeColor = System.Drawing.Color.Black
        Me.Txt_BookCode.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.Txt_BookCode.IsValidated = False
        Me.Txt_BookCode.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_BookCode.Location = New System.Drawing.Point(223, 43)
        Me.Txt_BookCode.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_BookCode.MandatoryField = False
        Me.Txt_BookCode.MaxDate = Nothing
        Me.Txt_BookCode.MinDate = Nothing
        Me.Txt_BookCode.Name = "Txt_BookCode"
        Me.Txt_BookCode.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_BookCode.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_BookCode.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_BookCode.RegularExpression = Nothing
        Me.Txt_BookCode.RegularExpressionErrorMessage = Nothing
        Me.Txt_BookCode.ShowMessage = False
        Me.Txt_BookCode.Size = New System.Drawing.Size(471, 22)
        Me.Txt_BookCode.SpacerString = ""
        Me.Txt_BookCode.TabIndex = 2
        Me.Txt_BookCode.Tag = "MenuName"
        Me.Txt_BookCode.TransparentBox = True
        Me.Txt_BookCode.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(6, 43)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 14)
        Me.Label28.TabIndex = 81986
        Me.Label28.Text = "Book Code"
        '
        'BookMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(732, 515)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Txt_BookCode)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txttrtype)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtReportTitle)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGroupCode)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtUseChallan)
        Me.Controls.Add(Me.txtnature)
        Me.Controls.Add(Me.PnlGrdView)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Txt_Bookcategory)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Txt_Behaviour)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt_Alies)
        Me.Controls.Add(Me.Txt_RptFileNamePlain)
        Me.Controls.Add(Me.Txt_RcptIssue)
        Me.Controls.Add(Me.Txt_BookId)
        Me.Controls.Add(Me.Txt_BookName)
        Me.Controls.Add(Me.Txt_MenuActive)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "BookMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BookMaster"
        Me.PnlGrdView.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnlGrdView As GroupBox
    Friend WithEvents btnviewupdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label21 As Label
    Friend WithEvents Txt_Bookcategory As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Txt_Behaviour As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_Alies As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_RptFileNamePlain As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_RcptIssue As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_BookId As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_BookName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuActive As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtnature As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtUseChallan As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtGroupCode As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtReportTitle As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txttrtype As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Txt_BookCode As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label28 As Label
End Class
