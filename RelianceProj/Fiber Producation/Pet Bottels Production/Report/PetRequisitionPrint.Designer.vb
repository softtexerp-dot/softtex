<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PetRequisitionPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PetRequisitionPrint))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtunitName = New ctl_TextBox.ctl_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Ctl_RptType = New ctl_TextBox.ctl_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_ToEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnItem = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_FromEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(353, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 16)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(353, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 16)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(353, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 16)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(353, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 16)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = ":"
        '
        'txtunitName
        '
        Me.txtunitName._AllowSpace = True
        Me.txtunitName.AcceptsReturn = True
        Me.txtunitName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtunitName.BackColor = System.Drawing.Color.LightCyan
        Me.txtunitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtunitName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunitName.Check_End_Date_Value_FY = "YES"
        Me.txtunitName.Check_Start_Date_Value_FY = "YES"
        Me.txtunitName.ClearField = True
        Me.txtunitName.CustomInputTypeString = Nothing
        Me.txtunitName.Date_for_Database = Nothing
        Me.txtunitName.Date_Tag = Nothing
        Me.txtunitName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtunitName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtunitName.ExtraValue = ""
        Me.txtunitName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunitName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtunitName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtunitName.ForeColor = System.Drawing.Color.Black
        Me.txtunitName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtunitName.IsValidated = False
        Me.txtunitName.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtunitName.Location = New System.Drawing.Point(371, 33)
        Me.txtunitName.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtunitName.MandatoryField = False
        Me.txtunitName.MaxDate = Nothing
        Me.txtunitName.MinDate = Nothing
        Me.txtunitName.Name = "txtunitName"
        Me.txtunitName.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtunitName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtunitName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtunitName.RegularExpression = Nothing
        Me.txtunitName.RegularExpressionErrorMessage = Nothing
        Me.txtunitName.ShowMessage = False
        Me.txtunitName.Size = New System.Drawing.Size(125, 22)
        Me.txtunitName.SpacerString = ""
        Me.txtunitName.TabIndex = 34
        Me.txtunitName.Tag = "EntryNo"
        Me.txtunitName.TransparentBox = True
        Me.txtunitName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(225, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 16)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Unit Name"
        '
        'Ctl_RptType
        '
        Me.Ctl_RptType._AllowSpace = True
        Me.Ctl_RptType.AcceptsReturn = True
        Me.Ctl_RptType.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Ctl_RptType.BackColor = System.Drawing.Color.LightCyan
        Me.Ctl_RptType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ctl_RptType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ctl_RptType.Check_End_Date_Value_FY = "YES"
        Me.Ctl_RptType.Check_Start_Date_Value_FY = "YES"
        Me.Ctl_RptType.ClearField = True
        Me.Ctl_RptType.CustomInputTypeString = Nothing
        Me.Ctl_RptType.Date_for_Database = Nothing
        Me.Ctl_RptType.Date_Tag = Nothing
        Me.Ctl_RptType.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Ctl_RptType.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Ctl_RptType.ExtraValue = ""
        Me.Ctl_RptType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctl_RptType.FontFocusColor = System.Drawing.Color.Blue
        Me.Ctl_RptType.FontLeaveColor = System.Drawing.Color.Black
        Me.Ctl_RptType.ForeColor = System.Drawing.Color.Black
        Me.Ctl_RptType.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Ctl_RptType.IsValidated = False
        Me.Ctl_RptType.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Ctl_RptType.Location = New System.Drawing.Point(371, 111)
        Me.Ctl_RptType.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Ctl_RptType.MandatoryField = False
        Me.Ctl_RptType.MaxDate = Nothing
        Me.Ctl_RptType.MinDate = Nothing
        Me.Ctl_RptType.Name = "Ctl_RptType"
        Me.Ctl_RptType.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Ctl_RptType.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Ctl_RptType.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Ctl_RptType.ReadOnly = True
        Me.Ctl_RptType.RegularExpression = Nothing
        Me.Ctl_RptType.RegularExpressionErrorMessage = Nothing
        Me.Ctl_RptType.ShowMessage = False
        Me.Ctl_RptType.Size = New System.Drawing.Size(60, 22)
        Me.Ctl_RptType.SpacerString = "1,2,3"
        Me.Ctl_RptType.TabIndex = 37
        Me.Ctl_RptType.Tag = "Type"
        Me.Ctl_RptType.Text = "1"
        Me.Ctl_RptType.TransparentBox = True
        Me.Ctl_RptType.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(228, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 16)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "RPT Type"
        '
        'Txt_ToEntryNo
        '
        Me.Txt_ToEntryNo._AllowSpace = True
        Me.Txt_ToEntryNo.AcceptsReturn = True
        Me.Txt_ToEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ToEntryNo.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_ToEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ToEntryNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ToEntryNo.Check_End_Date_Value_FY = "YES"
        Me.Txt_ToEntryNo.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ToEntryNo.ClearField = True
        Me.Txt_ToEntryNo.CustomInputTypeString = Nothing
        Me.Txt_ToEntryNo.Date_for_Database = Nothing
        Me.Txt_ToEntryNo.Date_Tag = Nothing
        Me.Txt_ToEntryNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_ToEntryNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ToEntryNo.ExtraValue = ""
        Me.Txt_ToEntryNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ToEntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ToEntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ToEntryNo.ForeColor = System.Drawing.Color.Black
        Me.Txt_ToEntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_ToEntryNo.IsValidated = False
        Me.Txt_ToEntryNo.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_ToEntryNo.Location = New System.Drawing.Point(371, 84)
        Me.Txt_ToEntryNo.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_ToEntryNo.MandatoryField = False
        Me.Txt_ToEntryNo.MaxDate = Nothing
        Me.Txt_ToEntryNo.MinDate = Nothing
        Me.Txt_ToEntryNo.Name = "Txt_ToEntryNo"
        Me.Txt_ToEntryNo.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_ToEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ToEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ToEntryNo.RegularExpression = Nothing
        Me.Txt_ToEntryNo.RegularExpressionErrorMessage = Nothing
        Me.Txt_ToEntryNo.ShowMessage = False
        Me.Txt_ToEntryNo.Size = New System.Drawing.Size(60, 22)
        Me.Txt_ToEntryNo.SpacerString = ""
        Me.Txt_ToEntryNo.TabIndex = 36
        Me.Txt_ToEntryNo.Tag = "EntryNo"
        Me.Txt_ToEntryNo.TransparentBox = True
        Me.Txt_ToEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(225, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 16)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "To Entry No"
        '
        'BtnItem
        '
        Me.BtnItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnItem.ForeColor = System.Drawing.Color.Black
        Me.BtnItem.Location = New System.Drawing.Point(0, 23)
        Me.BtnItem.Name = "BtnItem"
        Me.BtnItem.Size = New System.Drawing.Size(219, 36)
        Me.BtnItem.TabIndex = 33
        Me.BtnItem.Tag = "Entry No"
        Me.BtnItem.Text = "&1. Entry No"
        Me.BtnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnItem.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(218, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1, 252)
        Me.Label3.TabIndex = 42
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(336, 212)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(67, 37)
        Me.But_ok.TabIndex = 38
        Me.But_ok.Text = "Ok"
        '
        'Txt_FromEntryNo
        '
        Me.Txt_FromEntryNo._AllowSpace = True
        Me.Txt_FromEntryNo.AcceptsReturn = True
        Me.Txt_FromEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_FromEntryNo.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_FromEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_FromEntryNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_FromEntryNo.Check_End_Date_Value_FY = "YES"
        Me.Txt_FromEntryNo.Check_Start_Date_Value_FY = "YES"
        Me.Txt_FromEntryNo.ClearField = True
        Me.Txt_FromEntryNo.CustomInputTypeString = Nothing
        Me.Txt_FromEntryNo.Date_for_Database = Nothing
        Me.Txt_FromEntryNo.Date_Tag = Nothing
        Me.Txt_FromEntryNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_FromEntryNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_FromEntryNo.ExtraValue = ""
        Me.Txt_FromEntryNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_FromEntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_FromEntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_FromEntryNo.ForeColor = System.Drawing.Color.Black
        Me.Txt_FromEntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_FromEntryNo.IsValidated = False
        Me.Txt_FromEntryNo.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_FromEntryNo.Location = New System.Drawing.Point(371, 56)
        Me.Txt_FromEntryNo.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_FromEntryNo.MandatoryField = False
        Me.Txt_FromEntryNo.MaxDate = Nothing
        Me.Txt_FromEntryNo.MinDate = Nothing
        Me.Txt_FromEntryNo.Name = "Txt_FromEntryNo"
        Me.Txt_FromEntryNo.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_FromEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_FromEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_FromEntryNo.RegularExpression = Nothing
        Me.Txt_FromEntryNo.RegularExpressionErrorMessage = Nothing
        Me.Txt_FromEntryNo.ShowMessage = False
        Me.Txt_FromEntryNo.Size = New System.Drawing.Size(60, 22)
        Me.Txt_FromEntryNo.SpacerString = ""
        Me.Txt_FromEntryNo.TabIndex = 35
        Me.Txt_FromEntryNo.Tag = "EntryNo"
        Me.Txt_FromEntryNo.TransparentBox = True
        Me.Txt_FromEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(225, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "From Entry No"
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.ImageOptions.ImageUri.Uri = "Close"
        Me.BtnClose.Location = New System.Drawing.Point(407, 212)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(78, 37)
        Me.BtnClose.TabIndex = 39
        Me.BtnClose.Text = "&Close"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightCyan
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(-1, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(513, 26)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Pet Requisition Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PetRequisitionPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(511, 274)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtunitName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Ctl_RptType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_ToEntryNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnItem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.Txt_FromEntryNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PetRequisitionPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pet Requisition Print"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtunitName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Ctl_RptType As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_ToEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnItem As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Txt_FromEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
End Class
