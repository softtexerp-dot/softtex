<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMasterFormRead
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMasterFormRead))
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.BtnUpdatepos = New DevExpress.XtraEditors.SimpleButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnmovecontrol = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(871, 112)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(228, 525)
        Me.PropertyGrid1.TabIndex = 81935
        Me.PropertyGrid1.Visible = False
        '
        'BtnUpdatepos
        '
        Me.BtnUpdatepos.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdatepos.Appearance.Options.UseFont = True
        Me.BtnUpdatepos.Enabled = False
        Me.BtnUpdatepos.ImageOptions.Image = CType(resources.GetObject("BtnUpdatepos.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnUpdatepos.Location = New System.Drawing.Point(900, 13)
        Me.BtnUpdatepos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnUpdatepos.Name = "BtnUpdatepos"
        Me.BtnUpdatepos.Size = New System.Drawing.Size(142, 39)
        Me.BtnUpdatepos.TabIndex = 81934
        Me.BtnUpdatepos.Text = "SavePosition"
        Me.BtnUpdatepos.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnmovecontrol
        '
        Me.btnmovecontrol.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmovecontrol.Appearance.Options.UseFont = True
        Me.btnmovecontrol.Enabled = False
        Me.btnmovecontrol.ImageOptions.Image = CType(resources.GetObject("btnmovecontrol.ImageOptions.Image"), System.Drawing.Image)
        Me.btnmovecontrol.Location = New System.Drawing.Point(750, 12)
        Me.btnmovecontrol.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnmovecontrol.Name = "btnmovecontrol"
        Me.btnmovecontrol.Size = New System.Drawing.Size(142, 39)
        Me.btnmovecontrol.TabIndex = 81936
        Me.btnmovecontrol.Text = "MoveControl"
        Me.btnmovecontrol.Visible = False
        '
        'MainMasterFormRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1104, 621)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.BtnUpdatepos)
        Me.Controls.Add(Me.btnmovecontrol)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainMasterFormRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Master Form Read"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents BtnUpdatepos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents btnmovecontrol As DevExpress.XtraEditors.SimpleButton
End Class
