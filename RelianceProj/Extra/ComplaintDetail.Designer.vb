<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComplaintDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComplaintDetail))
        Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnAddcomplaint = New DevExpress.XtraEditors.SimpleButton()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gridControl1
        '
        Me.gridControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.gridControl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridControl1.Location = New System.Drawing.Point(4, 43)
        Me.gridControl1.MainView = Me.gridView1
        Me.gridControl1.Name = "gridControl1"
        Me.gridControl1.Size = New System.Drawing.Size(1007, 578)
        Me.gridControl1.TabIndex = 1
        Me.gridControl1.UseDisabledStatePainter = False
        Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
        '
        'gridView1
        '
        Me.gridView1.GridControl = Me.gridControl1
        Me.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gridView1.Name = "gridView1"
        Me.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Status"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"All", "Pending", "Cancel", "OK", "Solved", "Running", "Hold"})
        Me.ComboBox1.Location = New System.Drawing.Point(79, 11)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(125, 22)
        Me.ComboBox1.TabIndex = 3
        '
        'btnAddcomplaint
        '
        Me.btnAddcomplaint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddcomplaint.Appearance.Options.UseFont = True
        Me.btnAddcomplaint.ImageOptions.Image = CType(resources.GetObject("btnAddcomplaint.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAddcomplaint.Location = New System.Drawing.Point(209, 4)
        Me.btnAddcomplaint.Name = "btnAddcomplaint"
        Me.btnAddcomplaint.Size = New System.Drawing.Size(187, 36)
        Me.btnAddcomplaint.TabIndex = 6
        Me.btnAddcomplaint.Text = "Add Complaint"
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(403, 3)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(39, 36)
        Me.But_ok.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 82258
        Me.Label4.Text = ":"
        '
        'ComplaintDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1012, 621)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.btnAddcomplaint)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gridControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ComplaintDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Complaint Detail"
        CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents gridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnAddcomplaint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
End Class
