<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RawPurchaseReturnReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RawPurchaseReturnReport))
        Me.txtGodownName = New ctl_TextBox.ctl_TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.SuspendLayout()
        '
        'txtGodownName
        '
        Me.txtGodownName._AllowSpace = True
        Me.txtGodownName.AcceptsReturn = True
        Me.txtGodownName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtGodownName.BackColor = System.Drawing.Color.Honeydew
        Me.txtGodownName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGodownName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGodownName.Check_End_Date_Value_FY = "YES"
        Me.txtGodownName.Check_Start_Date_Value_FY = "YES"
        Me.txtGodownName.ClearField = True
        Me.txtGodownName.CustomInputTypeString = Nothing
        Me.txtGodownName.Date_for_Database = Nothing
        Me.txtGodownName.Date_Tag = Nothing
        Me.txtGodownName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtGodownName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.txtGodownName.ExtraValue = ""
        Me.txtGodownName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGodownName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtGodownName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtGodownName.ForeColor = System.Drawing.Color.Black
        Me.txtGodownName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtGodownName.IsValidated = False
        Me.txtGodownName.LeaveFocusColor = System.Drawing.Color.Honeydew
        Me.txtGodownName.Location = New System.Drawing.Point(168, 21)
        Me.txtGodownName.MandatoryColor = System.Drawing.Color.Honeydew
        Me.txtGodownName.MandatoryField = False
        Me.txtGodownName.MaxDate = Nothing
        Me.txtGodownName.MinDate = Nothing
        Me.txtGodownName.Name = "txtGodownName"
        Me.txtGodownName.NormalBorderColor = System.Drawing.Color.Honeydew
        Me.txtGodownName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtGodownName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtGodownName.ReadOnly = True
        Me.txtGodownName.RegularExpression = Nothing
        Me.txtGodownName.RegularExpressionErrorMessage = Nothing
        Me.txtGodownName.ShowMessage = False
        Me.txtGodownName.Size = New System.Drawing.Size(202, 22)
        Me.txtGodownName.SpacerString = ""
        Me.txtGodownName.TabIndex = 82249
        Me.txtGodownName.Tag = "BOOKNAME"
        Me.txtGodownName.TransparentBox = True
        Me.txtGodownName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(62, 21)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(76, 14)
        Me.Label50.TabIndex = 82258
        Me.Label50.Text = "Unit Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 82259
        Me.Label2.Text = ":"
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(160, 181)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(67, 37)
        Me.But_ok.TabIndex = 82252
        Me.But_ok.Text = "Ok"
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.ImageOptions.ImageUri.Uri = "Close"
        Me.BtnClose.Location = New System.Drawing.Point(231, 181)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(78, 37)
        Me.BtnClose.TabIndex = 82253
        Me.BtnClose.Text = "&Close"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 14)
        Me.Label1.TabIndex = 82257
        Me.Label1.Text = ":"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(149, 55)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(12, 14)
        Me.Label41.TabIndex = 82256
        Me.Label41.Text = ":"
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.Black
        Me.lbl_To.Location = New System.Drawing.Point(62, 89)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 82255
        Me.lbl_To.Text = "Date To"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.Black
        Me.lbl_From.Location = New System.Drawing.Point(62, 55)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 82254
        Me.lbl_From.Text = "Date From"
        '
        'txt_To
        '
        Me.txt_To._AllowSpace = True
        Me.txt_To.AcceptsReturn = True
        Me.txt_To.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_To.BackColor = System.Drawing.Color.Honeydew
        Me.txt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_To.Check_End_Date_Value_FY = "YES"
        Me.txt_To.Check_Start_Date_Value_FY = "YES"
        Me.txt_To.ClearField = True
        Me.txt_To.CustomInputTypeString = Nothing
        Me.txt_To.Date_for_Database = Nothing
        Me.txt_To.Date_Tag = Nothing
        Me.txt_To.EnterFocusColor = System.Drawing.Color.Honeydew
        Me.txt_To.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_To.ExtraValue = ""
        Me.txt_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_To.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_To.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_To.ForeColor = System.Drawing.Color.Black
        Me.txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_To.IsValidated = False
        Me.txt_To.LeaveFocusColor = System.Drawing.Color.Honeydew
        Me.txt_To.Location = New System.Drawing.Point(168, 89)
        Me.txt_To.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_To.MandatoryField = False
        Me.txt_To.MaxDate = Nothing
        Me.txt_To.MinDate = Nothing
        Me.txt_To.Name = "txt_To"
        Me.txt_To.NormalBorderColor = System.Drawing.Color.Honeydew
        Me.txt_To.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_To.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_To.RegularExpression = Nothing
        Me.txt_To.RegularExpressionErrorMessage = Nothing
        Me.txt_To.ShowMessage = False
        Me.txt_To.Size = New System.Drawing.Size(92, 22)
        Me.txt_To.SpacerString = ""
        Me.txt_To.TabIndex = 82251
        Me.txt_To.Tag = "BOOKNAME"
        Me.txt_To.Text = "  /  /    "
        Me.txt_To.TransparentBox = True
        Me.txt_To.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txt_From
        '
        Me.txt_From._AllowSpace = True
        Me.txt_From.AcceptsReturn = True
        Me.txt_From.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_From.BackColor = System.Drawing.Color.Honeydew
        Me.txt_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_From.Check_End_Date_Value_FY = "YES"
        Me.txt_From.Check_Start_Date_Value_FY = "YES"
        Me.txt_From.ClearField = True
        Me.txt_From.CustomInputTypeString = Nothing
        Me.txt_From.Date_for_Database = Nothing
        Me.txt_From.Date_Tag = Nothing
        Me.txt_From.EnterFocusColor = System.Drawing.Color.Honeydew
        Me.txt_From.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_From.ExtraValue = ""
        Me.txt_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_From.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_From.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_From.ForeColor = System.Drawing.Color.Black
        Me.txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_From.IsValidated = False
        Me.txt_From.LeaveFocusColor = System.Drawing.Color.Honeydew
        Me.txt_From.Location = New System.Drawing.Point(168, 55)
        Me.txt_From.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_From.MandatoryField = False
        Me.txt_From.MaxDate = Nothing
        Me.txt_From.MinDate = Nothing
        Me.txt_From.Name = "txt_From"
        Me.txt_From.NormalBorderColor = System.Drawing.Color.Honeydew
        Me.txt_From.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_From.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_From.RegularExpression = Nothing
        Me.txt_From.RegularExpressionErrorMessage = Nothing
        Me.txt_From.ShowMessage = False
        Me.txt_From.Size = New System.Drawing.Size(92, 22)
        Me.txt_From.SpacerString = ""
        Me.txt_From.TabIndex = 82250
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'RawPurchaseReturnReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(433, 238)
        Me.Controls.Add(Me.txtGodownName)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.lbl_To)
        Me.Controls.Add(Me.lbl_From)
        Me.Controls.Add(Me.txt_To)
        Me.Controls.Add(Me.txt_From)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RawPurchaseReturnReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raw Purchase Return Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtGodownName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
End Class
