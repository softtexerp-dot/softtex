<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_MDI_Frm
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.FINE_YEAR_START = New System.Windows.Forms.Label()
        Me.FINE_YEAR_END = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DashbordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StoreConsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(830, 92)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(183, 23)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Visible = False
        '
        'FINE_YEAR_START
        '
        Me.FINE_YEAR_START.AutoSize = True
        Me.FINE_YEAR_START.Location = New System.Drawing.Point(828, 35)
        Me.FINE_YEAR_START.Name = "FINE_YEAR_START"
        Me.FINE_YEAR_START.Size = New System.Drawing.Size(97, 16)
        Me.FINE_YEAR_START.TabIndex = 8
        Me.FINE_YEAR_START.Text = "01/04/2025"
        Me.FINE_YEAR_START.Visible = False
        '
        'FINE_YEAR_END
        '
        Me.FINE_YEAR_END.AutoSize = True
        Me.FINE_YEAR_END.Location = New System.Drawing.Point(828, 61)
        Me.FINE_YEAR_END.Name = "FINE_YEAR_END"
        Me.FINE_YEAR_END.Size = New System.Drawing.Size(97, 16)
        Me.FINE_YEAR_END.TabIndex = 7
        Me.FINE_YEAR_END.Text = "31/03/2026"
        Me.FINE_YEAR_END.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DashbordToolStripMenuItem, Me.StoreConsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'DashbordToolStripMenuItem
        '
        Me.DashbordToolStripMenuItem.Name = "DashbordToolStripMenuItem"
        Me.DashbordToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.DashbordToolStripMenuItem.Text = "Dashbord"
        '
        'StoreConsToolStripMenuItem
        '
        Me.StoreConsToolStripMenuItem.Name = "StoreConsToolStripMenuItem"
        Me.StoreConsToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.StoreConsToolStripMenuItem.Text = "Store Consumption"
        '
        'Main_MDI_Frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 554)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.FINE_YEAR_START)
        Me.Controls.Add(Me.FINE_YEAR_END)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Main_MDI_Frm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents FINE_YEAR_START As Label
    Friend WithEvents FINE_YEAR_END As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DashbordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StoreConsToolStripMenuItem As ToolStripMenuItem
End Class
