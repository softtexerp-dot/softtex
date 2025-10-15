<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Report_viewer
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.BtnWhatsapp = New System.Windows.Forms.Button()
        Me.btn_mail = New System.Windows.Forms.Button()
        Me.btn_pdf = New System.Windows.Forms.Button()
        Me.But_export = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlGridView = New System.Windows.Forms.Panel()
        Me.BtnGridXls = New System.Windows.Forms.Button()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlGridView.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1354, 733)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'BtnWhatsapp
        '
        Me.BtnWhatsapp.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnWhatsapp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWhatsapp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.BtnWhatsapp.Image = Global.Textile.My.Resources.Resources.whatsapp
        Me.BtnWhatsapp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnWhatsapp.Location = New System.Drawing.Point(672, 6)
        Me.BtnWhatsapp.Name = "BtnWhatsapp"
        Me.BtnWhatsapp.Size = New System.Drawing.Size(31, 30)
        Me.BtnWhatsapp.TabIndex = 188
        Me.BtnWhatsapp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnWhatsapp.UseVisualStyleBackColor = False
        '
        'btn_mail
        '
        Me.btn_mail.BackColor = System.Drawing.SystemColors.Menu
        Me.btn_mail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_mail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.btn_mail.Image = Global.Textile.My.Resources.Resources.gmail
        Me.btn_mail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_mail.Location = New System.Drawing.Point(564, 6)
        Me.btn_mail.Name = "btn_mail"
        Me.btn_mail.Size = New System.Drawing.Size(35, 30)
        Me.btn_mail.TabIndex = 186
        Me.btn_mail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_mail.UseVisualStyleBackColor = False
        '
        'btn_pdf
        '
        Me.btn_pdf.BackColor = System.Drawing.SystemColors.Menu
        Me.btn_pdf.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pdf.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.btn_pdf.Image = Global.Textile.My.Resources.Resources.iconfinder_pdf_272711
        Me.btn_pdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_pdf.Location = New System.Drawing.Point(635, 6)
        Me.btn_pdf.Name = "btn_pdf"
        Me.btn_pdf.Size = New System.Drawing.Size(35, 30)
        Me.btn_pdf.TabIndex = 185
        Me.btn_pdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pdf.UseVisualStyleBackColor = False
        '
        'But_export
        '
        Me.But_export.BackColor = System.Drawing.SystemColors.Menu
        Me.But_export.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_export.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.But_export.Image = Global.Textile.My.Resources.Resources.excel
        Me.But_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.But_export.Location = New System.Drawing.Point(601, 6)
        Me.But_export.Name = "But_export"
        Me.But_export.Size = New System.Drawing.Size(33, 30)
        Me.But_export.TabIndex = 183
        Me.But_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.But_export.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(709, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(483, 26)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "F10 For Printing,Ctrl+M=Mail,Ctrl+P=Pdf,Ctrl+W=WhatsApp"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlGridView
        '
        Me.pnlGridView.BackColor = System.Drawing.Color.Wheat
        Me.pnlGridView.Controls.Add(Me.BtnGridXls)
        Me.pnlGridView.Controls.Add(Me.GridControl1)
        Me.pnlGridView.Location = New System.Drawing.Point(0, 113)
        Me.pnlGridView.Name = "pnlGridView"
        Me.pnlGridView.Size = New System.Drawing.Size(889, 588)
        Me.pnlGridView.TabIndex = 191
        Me.pnlGridView.Visible = False
        '
        'BtnGridXls
        '
        Me.BtnGridXls.BackColor = System.Drawing.SystemColors.Menu
        Me.BtnGridXls.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGridXls.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.BtnGridXls.Image = Global.Textile.My.Resources.Resources.excel
        Me.BtnGridXls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGridXls.Location = New System.Drawing.Point(7, 3)
        Me.BtnGridXls.Name = "BtnGridXls"
        Me.BtnGridXls.Size = New System.Drawing.Size(65, 30)
        Me.BtnGridXls.TabIndex = 81890
        Me.BtnGridXls.Text = "Xls"
        Me.BtnGridXls.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGridXls.UseVisualStyleBackColor = False
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(7, 38)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1335, 641)
        Me.GridControl1.TabIndex = 81889
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
        'Report_viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 733)
        Me.Controls.Add(Me.pnlGridView)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnWhatsapp)
        Me.Controls.Add(Me.btn_mail)
        Me.Controls.Add(Me.btn_pdf)
        Me.Controls.Add(Me.But_export)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "Report_viewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Printing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlGridView.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents Ledger_21 As Textile.Ledger_2
    Friend WithEvents But_export As System.Windows.Forms.Button
    Friend WithEvents btn_pdf As System.Windows.Forms.Button
    Friend WithEvents btn_mail As System.Windows.Forms.Button
    Friend WithEvents BtnWhatsapp As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlGridView As Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtnGridXls As Button
End Class
