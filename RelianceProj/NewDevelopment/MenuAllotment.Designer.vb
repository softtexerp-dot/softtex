<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuAllotment
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
        Me.SelectionGridControl = New DevExpress.XtraGrid.GridControl()
        Me.SelectionGrid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtnAllot = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        CType(Me.SelectionGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectionGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectionGridControl
        '
        Me.SelectionGridControl.Location = New System.Drawing.Point(4, 1)
        Me.SelectionGridControl.MainView = Me.SelectionGrid
        Me.SelectionGridControl.Name = "SelectionGridControl"
        Me.SelectionGridControl.Size = New System.Drawing.Size(482, 538)
        Me.SelectionGridControl.TabIndex = 14
        Me.SelectionGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SelectionGrid, Me.LayoutView1, Me.GridView2})
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
        'LayoutView1
        '
        Me.LayoutView1.GridControl = Me.SelectionGridControl
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
        Me.GridView2.GridControl = Me.SelectionGridControl
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'BtnAllot
        '
        Me.BtnAllot.Location = New System.Drawing.Point(4, 563)
        Me.BtnAllot.Name = "BtnAllot"
        Me.BtnAllot.Size = New System.Drawing.Size(231, 39)
        Me.BtnAllot.TabIndex = 15
        Me.BtnAllot.Text = "Menu Allot"
        Me.BtnAllot.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(241, 563)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(231, 39)
        Me.BtnDelete.TabIndex = 16
        Me.BtnDelete.Text = "Menu Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'MenuAllotment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 614)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnAllot)
        Me.Controls.Add(Me.SelectionGridControl)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MenuAllotment"
        Me.Text = "MenuAllotment"
        CType(Me.SelectionGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectionGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SelectionGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents SelectionGrid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnAllot As Button
    Friend WithEvents BtnDelete As Button
End Class
