<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenuForm
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
        Me.TxtMenuName = New ctl_TextBox.ctl_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Txt_Active = New ctl_TextBox.ctl_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CtlorderNo = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Ctlshortkey = New ctl_TextBox.ctl_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtMenuName
        '
        Me.TxtMenuName._AllowSpace = True
        Me.TxtMenuName.AcceptsReturn = True
        Me.TxtMenuName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtMenuName.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMenuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMenuName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMenuName.Check_End_Date_Value_FY = "YES"
        Me.TxtMenuName.Check_Start_Date_Value_FY = "YES"
        Me.TxtMenuName.ClearField = True
        Me.TxtMenuName.CustomInputTypeString = Nothing
        Me.TxtMenuName.Date_for_Database = Nothing
        Me.TxtMenuName.Date_Tag = Nothing
        Me.TxtMenuName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtMenuName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtMenuName.ExtraValue = ""
        Me.TxtMenuName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMenuName.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtMenuName.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtMenuName.ForeColor = System.Drawing.Color.Black
        Me.TxtMenuName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtMenuName.IsValidated = False
        Me.TxtMenuName.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.TxtMenuName.Location = New System.Drawing.Point(136, 22)
        Me.TxtMenuName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtMenuName.MandatoryField = False
        Me.TxtMenuName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtMenuName.MaxDate = "FinYearEndDate"
        Me.TxtMenuName.MaxLength = 12
        Me.TxtMenuName.MinDate = "FinYearStartDate"
        Me.TxtMenuName.Name = "TxtMenuName"
        Me.TxtMenuName.NormalBorderColor = System.Drawing.Color.Gray
        Me.TxtMenuName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtMenuName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtMenuName.RegularExpression = Nothing
        Me.TxtMenuName.RegularExpressionErrorMessage = Nothing
        Me.TxtMenuName.ShowMessage = False
        Me.TxtMenuName.Size = New System.Drawing.Size(119, 22)
        Me.TxtMenuName.SpacerString = ""
        Me.TxtMenuName.TabIndex = 1
        Me.TxtMenuName.Tag = "MenuName"
        Me.TxtMenuName.TransparentBox = True
        Me.TxtMenuName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 16)
        Me.Label2.TabIndex = 81909
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 16)
        Me.Label3.TabIndex = 81908
        Me.Label3.Text = "Menu Name"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(116, 112)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 16)
        Me.Label20.TabIndex = 82055
        Me.Label20.Text = ":"
        '
        'Txt_Active
        '
        Me.Txt_Active._AllowSpace = True
        Me.Txt_Active.AcceptsReturn = True
        Me.Txt_Active.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Active.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_Active.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Active.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Active.Check_End_Date_Value_FY = "YES"
        Me.Txt_Active.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Active.ClearField = True
        Me.Txt_Active.CustomInputTypeString = Nothing
        Me.Txt_Active.Date_for_Database = Nothing
        Me.Txt_Active.Date_Tag = Nothing
        Me.Txt_Active.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Active.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Active.ExtraValue = ""
        Me.Txt_Active.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Active.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Active.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Active.ForeColor = System.Drawing.Color.Black
        Me.Txt_Active.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_Active.IsValidated = False
        Me.Txt_Active.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.Txt_Active.Location = New System.Drawing.Point(136, 111)
        Me.Txt_Active.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_Active.MandatoryField = False
        Me.Txt_Active.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_Active.MaxDate = "FinYearEndDate"
        Me.Txt_Active.MaxLength = 12
        Me.Txt_Active.MinDate = "FinYearStartDate"
        Me.Txt_Active.Name = "Txt_Active"
        Me.Txt_Active.NormalBorderColor = System.Drawing.Color.Gray
        Me.Txt_Active.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Active.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Active.ReadOnly = True
        Me.Txt_Active.RegularExpression = Nothing
        Me.Txt_Active.RegularExpressionErrorMessage = Nothing
        Me.Txt_Active.ShowMessage = False
        Me.Txt_Active.Size = New System.Drawing.Size(71, 22)
        Me.Txt_Active.SpacerString = "YES,NO"
        Me.Txt_Active.TabIndex = 4
        Me.Txt_Active.Tag = "Active"
        Me.Txt_Active.Text = "YES"
        Me.Txt_Active.TransparentBox = True
        Me.Txt_Active.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 82054
        Me.Label7.Text = "Active"
        '
        'CtlorderNo
        '
        Me.CtlorderNo._AllowSpace = True
        Me.CtlorderNo.AcceptsReturn = True
        Me.CtlorderNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.CtlorderNo.BackColor = System.Drawing.SystemColors.Window
        Me.CtlorderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlorderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CtlorderNo.Check_End_Date_Value_FY = "YES"
        Me.CtlorderNo.Check_Start_Date_Value_FY = "YES"
        Me.CtlorderNo.ClearField = True
        Me.CtlorderNo.CustomInputTypeString = Nothing
        Me.CtlorderNo.Date_for_Database = Nothing
        Me.CtlorderNo.Date_Tag = Nothing
        Me.CtlorderNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.CtlorderNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.CtlorderNo.ExtraValue = ""
        Me.CtlorderNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtlorderNo.FontFocusColor = System.Drawing.Color.Blue
        Me.CtlorderNo.FontLeaveColor = System.Drawing.Color.Black
        Me.CtlorderNo.ForeColor = System.Drawing.Color.Black
        Me.CtlorderNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SerialNumber
        Me.CtlorderNo.IsValidated = False
        Me.CtlorderNo.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.CtlorderNo.Location = New System.Drawing.Point(136, 50)
        Me.CtlorderNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CtlorderNo.MandatoryField = False
        Me.CtlorderNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CtlorderNo.MaxDate = "FinYearEndDate"
        Me.CtlorderNo.MaxLength = 12
        Me.CtlorderNo.MinDate = "FinYearStartDate"
        Me.CtlorderNo.Name = "CtlorderNo"
        Me.CtlorderNo.NormalBorderColor = System.Drawing.Color.Gray
        Me.CtlorderNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.CtlorderNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.CtlorderNo.RegularExpression = Nothing
        Me.CtlorderNo.RegularExpressionErrorMessage = Nothing
        Me.CtlorderNo.ShowMessage = False
        Me.CtlorderNo.Size = New System.Drawing.Size(119, 22)
        Me.CtlorderNo.SpacerString = ""
        Me.CtlorderNo.TabIndex = 2
        Me.CtlorderNo.Tag = "OrderNo"
        Me.CtlorderNo.TransparentBox = True
        Me.CtlorderNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(116, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 16)
        Me.Label1.TabIndex = 82058
        Me.Label1.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 82057
        Me.Label4.Text = "Order No"
        '
        'Ctlshortkey
        '
        Me.Ctlshortkey._AllowSpace = True
        Me.Ctlshortkey.AcceptsReturn = True
        Me.Ctlshortkey.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Ctlshortkey.BackColor = System.Drawing.SystemColors.Window
        Me.Ctlshortkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ctlshortkey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ctlshortkey.Check_End_Date_Value_FY = "YES"
        Me.Ctlshortkey.Check_Start_Date_Value_FY = "YES"
        Me.Ctlshortkey.ClearField = True
        Me.Ctlshortkey.CustomInputTypeString = Nothing
        Me.Ctlshortkey.Date_for_Database = Nothing
        Me.Ctlshortkey.Date_Tag = Nothing
        Me.Ctlshortkey.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Ctlshortkey.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Ctlshortkey.ExtraValue = ""
        Me.Ctlshortkey.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctlshortkey.FontFocusColor = System.Drawing.Color.Blue
        Me.Ctlshortkey.FontLeaveColor = System.Drawing.Color.Black
        Me.Ctlshortkey.ForeColor = System.Drawing.Color.Black
        Me.Ctlshortkey.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Ctlshortkey.IsValidated = False
        Me.Ctlshortkey.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.Ctlshortkey.Location = New System.Drawing.Point(136, 78)
        Me.Ctlshortkey.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Ctlshortkey.MandatoryField = False
        Me.Ctlshortkey.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Ctlshortkey.MaxDate = "FinYearEndDate"
        Me.Ctlshortkey.MaxLength = 12
        Me.Ctlshortkey.MinDate = "FinYearStartDate"
        Me.Ctlshortkey.Name = "Ctlshortkey"
        Me.Ctlshortkey.NormalBorderColor = System.Drawing.Color.Gray
        Me.Ctlshortkey.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Ctlshortkey.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Ctlshortkey.RegularExpression = Nothing
        Me.Ctlshortkey.RegularExpressionErrorMessage = Nothing
        Me.Ctlshortkey.ShowMessage = False
        Me.Ctlshortkey.Size = New System.Drawing.Size(119, 22)
        Me.Ctlshortkey.SpacerString = ""
        Me.Ctlshortkey.TabIndex = 3
        Me.Ctlshortkey.Tag = "Short_Cut_Key"
        Me.Ctlshortkey.TransparentBox = True
        Me.Ctlshortkey.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(116, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 16)
        Me.Label5.TabIndex = 82061
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 82060
        Me.Label6.Text = "Short Key"
        '
        'MainMenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1104, 621)
        Me.Controls.Add(Me.Ctlshortkey)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CtlorderNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Txt_Active)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtMenuName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainMenuForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainMenuForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtMenuName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Txt_Active As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CtlorderNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Ctlshortkey As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
