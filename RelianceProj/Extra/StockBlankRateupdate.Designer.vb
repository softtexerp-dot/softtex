<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockBlankRateupdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockBlankRateupdate))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.txtBookName = New ctl_TextBox.ctl_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView4 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_close = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(349, 4)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(90, 35)
        Me.btnView.TabIndex = 81953
        Me.btnView.Text = "View"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(443, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 35)
        Me.btnSave.TabIndex = 81956
        Me.btnSave.Text = "Save"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(11, 16)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(82, 14)
        Me.Label51.TabIndex = 81955
        Me.Label51.Text = "Book Name"
        '
        'txtBookName
        '
        Me.txtBookName._AllowSpace = True
        Me.txtBookName.AcceptsReturn = True
        Me.txtBookName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtBookName.BackColor = System.Drawing.Color.Lavender
        Me.txtBookName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBookName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBookName.Check_End_Date_Value_FY = "YES"
        Me.txtBookName.Check_Start_Date_Value_FY = "YES"
        Me.txtBookName.ClearField = True
        Me.txtBookName.CustomInputTypeString = Nothing
        Me.txtBookName.Date_for_Database = Nothing
        Me.txtBookName.Date_Tag = Nothing
        Me.txtBookName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtBookName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtBookName.ExtraValue = ""
        Me.txtBookName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtBookName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtBookName.ForeColor = System.Drawing.Color.Black
        Me.txtBookName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.txtBookName.IsValidated = False
        Me.txtBookName.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txtBookName.Location = New System.Drawing.Point(129, 13)
        Me.txtBookName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtBookName.MandatoryField = False
        Me.txtBookName.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.txtBookName.MaxDate = Nothing
        Me.txtBookName.MaxLength = 8
        Me.txtBookName.MinDate = Nothing
        Me.txtBookName.Name = "txtBookName"
        Me.txtBookName.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txtBookName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtBookName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtBookName.RegularExpression = Nothing
        Me.txtBookName.RegularExpressionErrorMessage = Nothing
        Me.txtBookName.ShortcutsEnabled = False
        Me.txtBookName.ShowMessage = False
        Me.txtBookName.Size = New System.Drawing.Size(215, 22)
        Me.txtBookName.SpacerString = ""
        Me.txtBookName.TabIndex = 81952
        Me.txtBookName.Tag = "bookname"
        Me.txtBookName.TransparentBox = False
        Me.txtBookName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(113, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 81958
        Me.Label4.Text = ":"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(0, 3)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(881, 525)
        Me.GridControl1.TabIndex = 81960
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FirstStage, Me.LayoutView4, Me.GridView7})
        '
        'FirstStage
        '
        Me.FirstStage.DetailHeight = 377
        Me.FirstStage.GridControl = Me.GridControl1
        Me.FirstStage.Name = "FirstStage"
        Me.FirstStage.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.FirstStage.OptionsEditForm.PopupEditFormWidth = 1067
        Me.FirstStage.OptionsFind.AlwaysVisible = True
        Me.FirstStage.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.FirstStage.OptionsNavigation.EnterMoveNextColumn = True
        Me.FirstStage.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.FirstStage.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.FirstStage.OptionsView.ColumnAutoWidth = False
        Me.FirstStage.OptionsView.ShowAutoFilterRow = True
        Me.FirstStage.OptionsView.ShowFooter = True
        '
        'LayoutView4
        '
        Me.LayoutView4.DetailHeight = 377
        Me.LayoutView4.GridControl = Me.GridControl1
        Me.LayoutView4.Name = "LayoutView4"
        Me.LayoutView4.OptionsBehavior.Editable = False
        Me.LayoutView4.OptionsFind.AlwaysVisible = True
        Me.LayoutView4.TemplateCard = Me.LayoutViewCard4
        '
        'LayoutViewCard4
        '
        Me.LayoutViewCard4.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard4.Name = "LayoutViewCard1"
        '
        'GridView7
        '
        Me.GridView7.DetailHeight = 377
        Me.GridView7.GridControl = Me.GridControl1
        Me.GridView7.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsBehavior.Editable = False
        Me.GridView7.OptionsEditForm.PopupEditFormWidth = 1067
        Me.GridView7.OptionsFind.AlwaysVisible = True
        Me.GridView7.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView7.OptionsView.ShowAutoFilterRow = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(889, 557)
        Me.TabControl1.TabIndex = 81961
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GridControl1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(881, 530)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Rate Update"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GridControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(881, 530)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Old Transaction"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GridControl2
        '
        Me.GridControl2.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        GridLevelNode2.RelationName = "Level1"
        Me.GridControl2.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.GridControl2.Location = New System.Drawing.Point(0, 2)
        Me.GridControl2.MainView = Me.GridView1
        Me.GridControl2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(881, 527)
        Me.GridControl2.TabIndex = 81961
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.LayoutView1, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 377
        Me.GridView1.GridControl = Me.GridControl2
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 1067
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView1.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'LayoutView1
        '
        Me.LayoutView1.DetailHeight = 377
        Me.LayoutView1.GridControl = Me.GridControl2
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
        Me.GridView2.DetailHeight = 377
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 1067
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'BtnExport
        '
        Me.BtnExport.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Appearance.Options.UseFont = True
        Me.BtnExport.ImageOptions.Image = CType(resources.GetObject("BtnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExport.Location = New System.Drawing.Point(627, 4)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 35)
        Me.BtnExport.TabIndex = 81963
        Me.BtnExport.Text = "Export"
        '
        'Btn_close
        '
        Me.Btn_close.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_close.Appearance.Options.UseFont = True
        Me.Btn_close.ImageOptions.Image = CType(resources.GetObject("Btn_close.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_close.Location = New System.Drawing.Point(723, 4)
        Me.Btn_close.Name = "Btn_close"
        Me.Btn_close.Size = New System.Drawing.Size(90, 35)
        Me.Btn_close.TabIndex = 81964
        Me.Btn_close.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.ImageOptions.Image = CType(resources.GetObject("BtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(533, 4)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 35)
        Me.BtnPrint.TabIndex = 81962
        Me.BtnPrint.Text = "Print"
        '
        'StockBlankRateupdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 621)
        Me.Controls.Add(Me.BtnExport)
        Me.Controls.Add(Me.Btn_close)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBookName)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label51)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "StockBlankRateupdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StockBlankRateupdate"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label51 As Label
    Friend WithEvents txtBookName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView4 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard4 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_close As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
End Class
