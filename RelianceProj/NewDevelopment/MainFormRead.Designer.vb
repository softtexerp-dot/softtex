<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFormRead
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFormRead))
        Me.BtnUpdatepos = New DevExpress.XtraEditors.SimpleButton()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.btnmovecontrol = New DevExpress.XtraEditors.SimpleButton()
        Me.PnlGrdView = New System.Windows.Forms.GroupBox()
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
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.Txt_ViewTO = New ctl_TextBox.ctl_TextBox()
        Me.Txt_ViewFrom = New ctl_TextBox.ctl_TextBox()
        Me.PnlGrdView.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnUpdatepos
        '
        Me.BtnUpdatepos.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdatepos.Appearance.Options.UseFont = True
        Me.BtnUpdatepos.Enabled = False
        Me.BtnUpdatepos.ImageOptions.Image = CType(resources.GetObject("BtnUpdatepos.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnUpdatepos.Location = New System.Drawing.Point(933, 3)
        Me.BtnUpdatepos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnUpdatepos.Name = "BtnUpdatepos"
        Me.BtnUpdatepos.Size = New System.Drawing.Size(142, 39)
        Me.BtnUpdatepos.TabIndex = 81926
        Me.BtnUpdatepos.Text = "SavePosition"
        Me.BtnUpdatepos.Visible = False
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(874, 93)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(228, 546)
        Me.PropertyGrid1.TabIndex = 81927
        Me.PropertyGrid1.Visible = False
        '
        'btnmovecontrol
        '
        Me.btnmovecontrol.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmovecontrol.Appearance.Options.UseFont = True
        Me.btnmovecontrol.Enabled = False
        Me.btnmovecontrol.ImageOptions.Image = CType(resources.GetObject("btnmovecontrol.ImageOptions.Image"), System.Drawing.Image)
        Me.btnmovecontrol.Location = New System.Drawing.Point(788, 3)
        Me.btnmovecontrol.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnmovecontrol.Name = "btnmovecontrol"
        Me.btnmovecontrol.Size = New System.Drawing.Size(142, 39)
        Me.btnmovecontrol.TabIndex = 81929
        Me.btnmovecontrol.Text = "MoveControl"
        Me.btnmovecontrol.Visible = False
        '
        'PnlGrdView
        '
        Me.PnlGrdView.BackColor = System.Drawing.Color.LightCyan
        Me.PnlGrdView.Controls.Add(Me.BtnExport)
        Me.PnlGrdView.Controls.Add(Me.SimpleButton2)
        Me.PnlGrdView.Controls.Add(Me.BtnPrint)
        Me.PnlGrdView.Controls.Add(Me.Btn_LayoutLoad)
        Me.PnlGrdView.Controls.Add(Me.BtnLayOutSave)
        Me.PnlGrdView.Controls.Add(Me.GridControl1)
        Me.PnlGrdView.Controls.Add(Me.lbl_To)
        Me.PnlGrdView.Controls.Add(Me.lbl_From)
        Me.PnlGrdView.Controls.Add(Me.Txt_ViewTO)
        Me.PnlGrdView.Controls.Add(Me.Txt_ViewFrom)
        Me.PnlGrdView.Location = New System.Drawing.Point(195, 75)
        Me.PnlGrdView.Name = "PnlGrdView"
        Me.PnlGrdView.Size = New System.Drawing.Size(134, 175)
        Me.PnlGrdView.TabIndex = 81931
        Me.PnlGrdView.TabStop = False
        Me.PnlGrdView.Visible = False
        '
        'BtnExport
        '
        Me.BtnExport.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Appearance.Options.UseFont = True
        Me.BtnExport.ImageOptions.Image = CType(resources.GetObject("BtnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExport.Location = New System.Drawing.Point(686, 12)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 35)
        Me.BtnExport.TabIndex = 81965
        Me.BtnExport.Text = "Export"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(523, 12)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(64, 34)
        Me.SimpleButton2.TabIndex = 81891
        Me.SimpleButton2.Text = "OK"
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.ImageOptions.Image = CType(resources.GetObject("BtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(593, 12)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 35)
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
        Me.GridControl1.Location = New System.Drawing.Point(6, 51)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(823, 523)
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
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_To.Location = New System.Drawing.Point(189, 23)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 81892
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_From.Location = New System.Drawing.Point(13, 24)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 81891
        Me.lbl_From.Text = "Date From:"
        '
        'Txt_ViewTO
        '
        Me.Txt_ViewTO._AllowSpace = True
        Me.Txt_ViewTO.AcceptsReturn = True
        Me.Txt_ViewTO.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ViewTO.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ViewTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ViewTO.Check_End_Date_Value_FY = "YES"
        Me.Txt_ViewTO.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ViewTO.ClearField = True
        Me.Txt_ViewTO.CustomInputTypeString = Nothing
        Me.Txt_ViewTO.Date_for_Database = Nothing
        Me.Txt_ViewTO.Date_Tag = Nothing
        Me.Txt_ViewTO.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewTO.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ViewTO.ExtraValue = ""
        Me.Txt_ViewTO.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ViewTO.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ViewTO.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ViewTO.ForeColor = System.Drawing.Color.Black
        Me.Txt_ViewTO.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.Txt_ViewTO.IsValidated = False
        Me.Txt_ViewTO.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_ViewTO.Location = New System.Drawing.Point(255, 20)
        Me.Txt_ViewTO.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ViewTO.MandatoryField = False
        Me.Txt_ViewTO.MaxDate = Nothing
        Me.Txt_ViewTO.MinDate = Nothing
        Me.Txt_ViewTO.Name = "Txt_ViewTO"
        Me.Txt_ViewTO.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewTO.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ViewTO.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ViewTO.RegularExpression = Nothing
        Me.Txt_ViewTO.RegularExpressionErrorMessage = Nothing
        Me.Txt_ViewTO.ShowMessage = False
        Me.Txt_ViewTO.Size = New System.Drawing.Size(95, 22)
        Me.Txt_ViewTO.SpacerString = ""
        Me.Txt_ViewTO.TabIndex = 81890
        Me.Txt_ViewTO.Tag = "BOOKNAME"
        Me.Txt_ViewTO.Text = "  /  /    "
        Me.Txt_ViewTO.TransparentBox = True
        Me.Txt_ViewTO.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_ViewFrom
        '
        Me.Txt_ViewFrom._AllowSpace = True
        Me.Txt_ViewFrom.AcceptsReturn = True
        Me.Txt_ViewFrom.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ViewFrom.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ViewFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ViewFrom.Check_End_Date_Value_FY = "YES"
        Me.Txt_ViewFrom.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ViewFrom.ClearField = True
        Me.Txt_ViewFrom.CustomInputTypeString = Nothing
        Me.Txt_ViewFrom.Date_for_Database = Nothing
        Me.Txt_ViewFrom.Date_Tag = Nothing
        Me.Txt_ViewFrom.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewFrom.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ViewFrom.ExtraValue = ""
        Me.Txt_ViewFrom.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ViewFrom.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ViewFrom.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ViewFrom.ForeColor = System.Drawing.Color.Black
        Me.Txt_ViewFrom.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.Txt_ViewFrom.IsValidated = False
        Me.Txt_ViewFrom.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_ViewFrom.Location = New System.Drawing.Point(96, 21)
        Me.Txt_ViewFrom.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ViewFrom.MandatoryField = False
        Me.Txt_ViewFrom.MaxDate = Nothing
        Me.Txt_ViewFrom.MinDate = Nothing
        Me.Txt_ViewFrom.Name = "Txt_ViewFrom"
        Me.Txt_ViewFrom.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewFrom.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ViewFrom.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ViewFrom.RegularExpression = Nothing
        Me.Txt_ViewFrom.RegularExpressionErrorMessage = Nothing
        Me.Txt_ViewFrom.ShowMessage = False
        Me.Txt_ViewFrom.Size = New System.Drawing.Size(95, 22)
        Me.Txt_ViewFrom.SpacerString = ""
        Me.Txt_ViewFrom.TabIndex = 81889
        Me.Txt_ViewFrom.Tag = "BOOKNAME"
        Me.Txt_ViewFrom.Text = "  /  /    "
        Me.Txt_ViewFrom.TransparentBox = True
        Me.Txt_ViewFrom.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'MainFormRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1104, 621)
        Me.Controls.Add(Me.PnlGrdView)
        Me.Controls.Add(Me.btnmovecontrol)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.BtnUpdatepos)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainFormRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form Read"
        Me.PnlGrdView.ResumeLayout(False)
        Me.PnlGrdView.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnUpdatepos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents btnmovecontrol As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PnlGrdView As GroupBox
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents Txt_ViewTO As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_ViewFrom As ctl_TextBox.ctl_TextBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
End Class
