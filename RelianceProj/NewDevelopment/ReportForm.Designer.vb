<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportForm))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.btnmovecontrol = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnUpdatepos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Location = New System.Drawing.Point(4, 66)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(883, 552)
        Me.GridControl1.TabIndex = 81923
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FirstStage, Me.LayoutView1, Me.GridView2})
        '
        'FirstStage
        '
        Me.FirstStage.DetailHeight = 377
        Me.FirstStage.GridControl = Me.GridControl1
        Me.FirstStage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.FirstStage.Name = "FirstStage"
        Me.FirstStage.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.FirstStage.OptionsBehavior.Editable = False
        Me.FirstStage.OptionsEditForm.PopupEditFormWidth = 1067
        Me.FirstStage.OptionsFind.AlwaysVisible = True
        Me.FirstStage.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.FirstStage.OptionsView.ColumnAutoWidth = False
        Me.FirstStage.OptionsView.ShowAutoFilterRow = True
        Me.FirstStage.OptionsView.ShowFooter = True
        Me.FirstStage.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LayoutView1
        '
        Me.LayoutView1.DetailHeight = 377
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
        Me.GridView2.DetailHeight = 377
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 1067
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(988, 74)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(228, 546)
        Me.PropertyGrid1.TabIndex = 81928
        Me.PropertyGrid1.Visible = False
        '
        'btnmovecontrol
        '
        Me.btnmovecontrol.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmovecontrol.Appearance.Options.UseFont = True
        Me.btnmovecontrol.Enabled = False
        Me.btnmovecontrol.ImageOptions.Image = CType(resources.GetObject("btnmovecontrol.ImageOptions.Image"), System.Drawing.Image)
        Me.btnmovecontrol.Location = New System.Drawing.Point(913, 12)
        Me.btnmovecontrol.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnmovecontrol.Name = "btnmovecontrol"
        Me.btnmovecontrol.Size = New System.Drawing.Size(142, 39)
        Me.btnmovecontrol.TabIndex = 81931
        Me.btnmovecontrol.Text = "MoveControl"
        Me.btnmovecontrol.Visible = False
        '
        'BtnUpdatepos
        '
        Me.BtnUpdatepos.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdatepos.Appearance.Options.UseFont = True
        Me.BtnUpdatepos.Enabled = False
        Me.BtnUpdatepos.ImageOptions.Image = CType(resources.GetObject("BtnUpdatepos.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnUpdatepos.Location = New System.Drawing.Point(1058, 12)
        Me.BtnUpdatepos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnUpdatepos.Name = "BtnUpdatepos"
        Me.BtnUpdatepos.Size = New System.Drawing.Size(142, 39)
        Me.BtnUpdatepos.TabIndex = 81930
        Me.BtnUpdatepos.Text = "SavePosition"
        Me.BtnUpdatepos.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.ImageOptions.Image = CType(resources.GetObject("btnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(746, 12)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(111, 39)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(627, 12)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(111, 39)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "View"
        '
        'ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1216, 621)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnmovecontrol)
        Me.Controls.Add(Me.BtnUpdatepos)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.GridControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Form"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents btnmovecontrol As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnUpdatepos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
End Class
