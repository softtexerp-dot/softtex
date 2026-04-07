<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQrCodescan
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
        Me.components = New System.ComponentModel.Container()
        Me.LablePymtQrcode = New System.Windows.Forms.Label()
        Me.RecharheQrCode = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Lblcompany = New System.Windows.Forms.Label()
        CType(Me.RecharheQrCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LablePymtQrcode
        '
        Me.LablePymtQrcode.AutoSize = True
        Me.LablePymtQrcode.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LablePymtQrcode.ForeColor = System.Drawing.Color.DarkRed
        Me.LablePymtQrcode.Location = New System.Drawing.Point(12, 37)
        Me.LablePymtQrcode.Name = "LablePymtQrcode"
        Me.LablePymtQrcode.Size = New System.Drawing.Size(0, 14)
        Me.LablePymtQrcode.TabIndex = 81856
        '
        'RecharheQrCode
        '
        Me.RecharheQrCode.Location = New System.Drawing.Point(26, 76)
        Me.RecharheQrCode.Name = "RecharheQrCode"
        Me.RecharheQrCode.Size = New System.Drawing.Size(446, 815)
        Me.RecharheQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RecharheQrCode.TabIndex = 81855
        Me.RecharheQrCode.TabStop = False
        '
        'Timer1
        '
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(188, 911)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(55, 16)
        Me.lblStatus.TabIndex = 81857
        Me.lblStatus.Text = "lblmsg"
        '
        'Lblcompany
        '
        Me.Lblcompany.AutoSize = True
        Me.Lblcompany.Location = New System.Drawing.Point(150, 9)
        Me.Lblcompany.Name = "Lblcompany"
        Me.Lblcompany.Size = New System.Drawing.Size(156, 16)
        Me.Lblcompany.TabIndex = 81858
        Me.Lblcompany.Text = "Soft -N Technologies"
        '
        'FrmQrCodescan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(484, 961)
        Me.Controls.Add(Me.Lblcompany)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.LablePymtQrcode)
        Me.Controls.Add(Me.RecharheQrCode)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmQrCodescan"
        Me.Text = "Payment QR Code"
        CType(Me.RecharheQrCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LablePymtQrcode As Label
    Friend WithEvents RecharheQrCode As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblStatus As Label
    Friend WithEvents Lblcompany As Label
End Class
