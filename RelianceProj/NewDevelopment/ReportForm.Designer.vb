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
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.btnmovecontrol = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnUpdatepos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.SelectionGridControl = New DevExpress.XtraGrid.GridControl()
        Me.SelectionGrid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView2 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SelectionGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(988, 57)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(228, 626)
        Me.PropertyGrid1.TabIndex = 81928
        Me.PropertyGrid1.Visible = False
        '
        'btnmovecontrol
        '
        Me.btnmovecontrol.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmovecontrol.Appearance.Options.UseFont = True
        Me.btnmovecontrol.Enabled = False
        Me.btnmovecontrol.ImageOptions.Image = CType(resources.GetObject("btnmovecontrol.ImageOptions.Image"), System.Drawing.Image)
        Me.btnmovecontrol.Location = New System.Drawing.Point(916, 6)
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
        Me.BtnUpdatepos.Location = New System.Drawing.Point(1061, 6)
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
        Me.btnClose.Location = New System.Drawing.Point(710, 570)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 39)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(610, 570)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(80, 39)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "Ok"
        '
        'SelectionGridControl
        '
        Me.SelectionGridControl.Location = New System.Drawing.Point(1, 0)
        Me.SelectionGridControl.MainView = Me.SelectionGrid
        Me.SelectionGridControl.Name = "SelectionGridControl"
        Me.SelectionGridControl.Size = New System.Drawing.Size(482, 621)
        Me.SelectionGridControl.TabIndex = 1
        Me.SelectionGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SelectionGrid, Me.LayoutView2, Me.GridView1})
        '
        'SelectionGrid
        '
        Me.SelectionGrid.GridControl = Me.SelectionGridControl
        Me.SelectionGrid.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.SelectionGrid.Name = "SelectionGrid"
        Me.SelectionGrid.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.SelectionGrid.OptionsBehavior.Editable = False
        Me.SelectionGrid.OptionsFind.AlwaysVisible = True
        Me.SelectionGrid.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.SelectionGrid.OptionsView.ColumnAutoWidth = False
        Me.SelectionGrid.OptionsView.ShowAutoFilterRow = True
        Me.SelectionGrid.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LayoutView2
        '
        Me.LayoutView2.GridControl = Me.SelectionGridControl
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
        'GridView1
        '
        Me.GridView1.GridControl = Me.SelectionGridControl
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1216, 621)
        Me.Controls.Add(Me.SelectionGridControl)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnmovecontrol)
        Me.Controls.Add(Me.BtnUpdatepos)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Form"
        CType(Me.SelectionGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents btnmovecontrol As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnUpdatepos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SelectionGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents SelectionGrid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView2 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard2 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
