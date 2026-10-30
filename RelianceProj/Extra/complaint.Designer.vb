<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class complaint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(complaint))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCompName = New System.Windows.Forms.TextBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.btnaddfile = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblid = New System.Windows.Forms.Label()
        Me.Lblmobileno = New System.Windows.Forms.Label()
        Me.Txtsendername = New System.Windows.Forms.TextBox()
        Me.Txtmobileno = New System.Windows.Forms.TextBox()
        Me.Lblsendername = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 74)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Message"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name"
        '
        'txtCompName
        '
        Me.txtCompName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompName.Location = New System.Drawing.Point(142, 8)
        Me.txtCompName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtCompName.Name = "txtCompName"
        Me.txtCompName.Size = New System.Drawing.Size(300, 21)
        Me.txtCompName.TabIndex = 10
        '
        'txtMessage
        '
        Me.txtMessage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(142, 42)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(300, 86)
        Me.txtMessage.TabIndex = 1
        '
        'txtFilePath
        '
        Me.txtFilePath.Enabled = False
        Me.txtFilePath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilePath.Location = New System.Drawing.Point(141, 207)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(299, 21)
        Me.txtFilePath.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Error Image"
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(535, 202)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(77, 32)
        Me.But_ok.TabIndex = 12
        Me.But_ok.Text = "View"
        '
        'btnaddfile
        '
        Me.btnaddfile.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaddfile.Appearance.Options.UseFont = True
        Me.btnaddfile.ImageOptions.Image = CType(resources.GetObject("btnaddfile.ImageOptions.Image"), System.Drawing.Image)
        Me.btnaddfile.Location = New System.Drawing.Point(443, 202)
        Me.btnaddfile.Name = "btnaddfile"
        Me.btnaddfile.Size = New System.Drawing.Size(88, 32)
        Me.btnaddfile.TabIndex = 11
        Me.btnaddfile.Text = "Upload"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(191, 251)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 32)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.ImageOptions.Image = CType(resources.GetObject("btnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(287, 251)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(77, 32)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(466, 11)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(35, 14)
        Me.lblid.TabIndex = 12
        Me.lblid.Text = "lblid"
        '
        'Lblmobileno
        '
        Me.Lblmobileno.AutoSize = True
        Me.Lblmobileno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblmobileno.Location = New System.Drawing.Point(16, 176)
        Me.Lblmobileno.Name = "Lblmobileno"
        Me.Lblmobileno.Size = New System.Drawing.Size(70, 13)
        Me.Lblmobileno.TabIndex = 14
        Me.Lblmobileno.Text = "Mobile No"
        '
        'Txtsendername
        '
        Me.Txtsendername.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsendername.Location = New System.Drawing.Point(142, 140)
        Me.Txtsendername.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txtsendername.Name = "Txtsendername"
        Me.Txtsendername.Size = New System.Drawing.Size(300, 21)
        Me.Txtsendername.TabIndex = 2
        '
        'Txtmobileno
        '
        Me.Txtmobileno.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtmobileno.Location = New System.Drawing.Point(142, 172)
        Me.Txtmobileno.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txtmobileno.MaxLength = 10
        Me.Txtmobileno.Name = "Txtmobileno"
        Me.Txtmobileno.Size = New System.Drawing.Size(300, 21)
        Me.Txtmobileno.TabIndex = 3
        '
        'Lblsendername
        '
        Me.Lblsendername.AutoSize = True
        Me.Lblsendername.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblsendername.Location = New System.Drawing.Point(16, 140)
        Me.Lblsendername.Name = "Lblsendername"
        Me.Lblsendername.Size = New System.Drawing.Size(94, 13)
        Me.Lblsendername.TabIndex = 13
        Me.Lblsendername.Text = "Sender Name"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(145, 231)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(127, 18)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Normal Priority"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(123, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 82257
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(123, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 14)
        Me.Label5.TabIndex = 82258
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(123, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 82259
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(123, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 14)
        Me.Label7.TabIndex = 82260
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(123, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 14)
        Me.Label8.TabIndex = 82261
        Me.Label8.Text = ":"
        '
        'complaint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(621, 288)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Txtmobileno)
        Me.Controls.Add(Me.Txtsendername)
        Me.Controls.Add(Me.Lblmobileno)
        Me.Controls.Add(Me.Lblsendername)
        Me.Controls.Add(Me.lblid)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnaddfile)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.txtCompName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "complaint"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Complaint Detail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCompName As TextBox
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnaddfile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblid As Label
    Friend WithEvents Lblmobileno As Label
    Friend WithEvents Txtsendername As TextBox
    Friend WithEvents Txtmobileno As TextBox
    Friend WithEvents Lblsendername As Label
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
