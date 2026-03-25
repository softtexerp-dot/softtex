<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Passward_Checker
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Passward_Checker))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_Passward = New ctl_TextBox.ctl_TextBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 14)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Enter Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(130, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 14)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = ":"
        '
        'txt_Passward
        '
        Me.txt_Passward._AllowSpace = True
        Me.txt_Passward.AcceptsReturn = True
        Me.txt_Passward.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Passward.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_Passward.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Passward.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Passward.Check_End_Date_Value_FY = "YES"
        Me.txt_Passward.Check_Start_Date_Value_FY = "YES"
        Me.txt_Passward.ClearField = True
        Me.txt_Passward.CustomInputTypeString = Nothing
        Me.txt_Passward.Date_for_Database = Nothing
        Me.txt_Passward.Date_Tag = Nothing
        Me.txt_Passward.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Passward.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Passward.ExtraValue = ""
        Me.txt_Passward.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Passward.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Passward.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Passward.ForeColor = System.Drawing.Color.Black
        Me.txt_Passward.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_Passward.IsValidated = False
        Me.txt_Passward.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_Passward.Location = New System.Drawing.Point(148, 61)
        Me.txt_Passward.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Passward.MandatoryField = False
        Me.txt_Passward.MaxDate = Nothing
        Me.txt_Passward.MinDate = Nothing
        Me.txt_Passward.Name = "txt_Passward"
        Me.txt_Passward.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_Passward.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Passward.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Passward.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Passward.RegularExpression = Nothing
        Me.txt_Passward.RegularExpressionErrorMessage = Nothing
        Me.txt_Passward.ShowMessage = False
        Me.txt_Passward.Size = New System.Drawing.Size(218, 22)
        Me.txt_Passward.SpacerString = ""
        Me.txt_Passward.TabIndex = 1
        Me.txt_Passward.Tag = "BOOKNAME"
        Me.txt_Passward.TransparentBox = True
        Me.txt_Passward.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(248, 121)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(97, 39)
        Me.SimpleButton1.TabIndex = 277
        Me.SimpleButton1.Text = "Cancel"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(129, 121)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(97, 39)
        Me.btnView.TabIndex = 276
        Me.btnView.Text = "Ok"
        '
        'Passward_Checker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.ClientSize = New System.Drawing.Size(401, 189)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_Passward)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Passward_Checker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_Passward As ctl_TextBox.ctl_TextBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
End Class
