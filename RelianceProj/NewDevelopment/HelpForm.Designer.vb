<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HelpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpForm))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.OutstandingCalendar = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.TodayDueBill = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.UnFoloOutstanding = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.DiscountFoloOutstanding = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.RTbView = New System.Windows.Forms.RichTextBox()
        Me.RTBPrint = New System.Windows.Forms.RichTextBox()
        Me.RTBTotalColumn = New System.Windows.Forms.RichTextBox()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.OutstandingCalendar})
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(200, 631)
        Me.AccordionControl1.TabIndex = 6
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'OutstandingCalendar
        '
        Me.OutstandingCalendar.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.TodayDueBill, Me.UnFoloOutstanding, Me.DiscountFoloOutstanding})
        Me.OutstandingCalendar.Expanded = True
        Me.OutstandingCalendar.ImageOptions.Image = CType(resources.GetObject("OutstandingCalendar.ImageOptions.Image"), System.Drawing.Image)
        Me.OutstandingCalendar.Name = "OutstandingCalendar"
        Me.OutstandingCalendar.Text = "Developer Help"
        '
        'TodayDueBill
        '
        Me.TodayDueBill.ImageOptions.Image = CType(resources.GetObject("TodayDueBill.ImageOptions.Image"), System.Drawing.Image)
        Me.TodayDueBill.Name = "TodayDueBill"
        Me.TodayDueBill.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.TodayDueBill.Text = "View"
        '
        'UnFoloOutstanding
        '
        Me.UnFoloOutstanding.ImageOptions.Image = CType(resources.GetObject("UnFoloOutstanding.ImageOptions.Image"), System.Drawing.Image)
        Me.UnFoloOutstanding.Name = "UnFoloOutstanding"
        Me.UnFoloOutstanding.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.UnFoloOutstanding.Text = "Print"
        '
        'DiscountFoloOutstanding
        '
        Me.DiscountFoloOutstanding.ImageOptions.Image = CType(resources.GetObject("DiscountFoloOutstanding.ImageOptions.Image"), System.Drawing.Image)
        Me.DiscountFoloOutstanding.Name = "DiscountFoloOutstanding"
        Me.DiscountFoloOutstanding.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.DiscountFoloOutstanding.Text = "Total Column"
        '
        'RTbView
        '
        Me.RTbView.Location = New System.Drawing.Point(206, 12)
        Me.RTbView.Name = "RTbView"
        Me.RTbView.Size = New System.Drawing.Size(1092, 609)
        Me.RTbView.TabIndex = 7
        Me.RTbView.Text = ""
        Me.RTbView.Visible = False
        '
        'RTBPrint
        '
        Me.RTBPrint.Location = New System.Drawing.Point(207, 12)
        Me.RTBPrint.Name = "RTBPrint"
        Me.RTBPrint.Size = New System.Drawing.Size(1094, 609)
        Me.RTBPrint.TabIndex = 8
        Me.RTBPrint.Text = ""
        Me.RTBPrint.Visible = False
        '
        'RTBTotalColumn
        '
        Me.RTBTotalColumn.Location = New System.Drawing.Point(206, 13)
        Me.RTBTotalColumn.Name = "RTBTotalColumn"
        Me.RTBTotalColumn.Size = New System.Drawing.Size(1094, 609)
        Me.RTBTotalColumn.TabIndex = 9
        Me.RTBTotalColumn.Text = ""
        Me.RTBTotalColumn.Visible = False
        '
        'HelpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 631)
        Me.Controls.Add(Me.RTBTotalColumn)
        Me.Controls.Add(Me.RTBPrint)
        Me.Controls.Add(Me.RTbView)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "HelpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Developer Help"
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents OutstandingCalendar As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents TodayDueBill As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents UnFoloOutstanding As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents DiscountFoloOutstanding As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents RTbView As RichTextBox
    Friend WithEvents RTBPrint As RichTextBox
    Friend WithEvents RTBTotalColumn As RichTextBox
End Class
