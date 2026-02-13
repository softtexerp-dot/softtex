<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Grading_RateUpdater
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Grading_RateUpdater))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView4 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView7 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Cmb_ViewType = New System.Windows.Forms.ComboBox()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        GridLevelNode1.RelationName = "Level1"
        Me.GridControl1.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridControl1.Location = New System.Drawing.Point(4, 53)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(930, 564)
        Me.GridControl1.TabIndex = 12
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FirstStage, Me.LayoutView4, Me.GridView7})
        '
        'FirstStage
        '
        Me.FirstStage.GridControl = Me.GridControl1
        Me.FirstStage.Name = "FirstStage"
        Me.FirstStage.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.FirstStage.OptionsFind.AlwaysVisible = True
        Me.FirstStage.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.FirstStage.OptionsNavigation.EnterMoveNextColumn = True
        Me.FirstStage.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.FirstStage.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.FirstStage.OptionsView.ColumnAutoWidth = False
        Me.FirstStage.OptionsView.ShowAutoFilterRow = True
        Me.FirstStage.OptionsView.ShowFooter = True
        '
        'LayoutView4
        '
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
        Me.GridView7.GridControl = Me.GridControl1
        Me.GridView7.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView7.Name = "GridView7"
        Me.GridView7.OptionsBehavior.Editable = False
        Me.GridView7.OptionsFind.AlwaysVisible = True
        Me.GridView7.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView7.OptionsView.ShowAutoFilterRow = True
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label51.Location = New System.Drawing.Point(9, 15)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(44, 14)
        Me.Label51.TabIndex = 81865
        Me.Label51.Text = "Show"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(263, 4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 36)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "View"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(345, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 36)
        Me.btnSave.TabIndex = 81951
        Me.btnSave.Text = "Save"
        '
        'Cmb_ViewType
        '
        Me.Cmb_ViewType.FormattingEnabled = True
        Me.Cmb_ViewType.Items.AddRange(New Object() {"Finish Rate", "Process Rate", "Gray Rate", "All Rate"})
        Me.Cmb_ViewType.Location = New System.Drawing.Point(59, 11)
        Me.Cmb_ViewType.Name = "Cmb_ViewType"
        Me.Cmb_ViewType.Size = New System.Drawing.Size(181, 24)
        Me.Cmb_ViewType.TabIndex = 1
        '
        'Grading_RateUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 621)
        Me.Controls.Add(Me.Cmb_ViewType)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.Label51)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Grading_RateUpdater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grading Rate Updater"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView4 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard4 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView7 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label51 As Label
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Cmb_ViewType As ComboBox
End Class
