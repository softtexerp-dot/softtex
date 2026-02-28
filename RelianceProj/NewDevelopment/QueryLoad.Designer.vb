<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryLoad
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
        Me.RTBQuery = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_CntrlName = New ctl_TextBox.ctl_TextBox()
        Me.TxtType = New ctl_TextBox.ctl_TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Txt_Active = New ctl_TextBox.ctl_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'RTBQuery
        '
        Me.RTBQuery.BackColor = System.Drawing.Color.Bisque
        Me.RTBQuery.Location = New System.Drawing.Point(135, 79)
        Me.RTBQuery.Name = "RTBQuery"
        Me.RTBQuery.Size = New System.Drawing.Size(956, 450)
        Me.RTBQuery.TabIndex = 3
        Me.RTBQuery.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(115, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 16)
        Me.Label11.TabIndex = 81904
        Me.Label11.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 81903
        Me.Label1.Text = "Query Text"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 16)
        Me.Label2.TabIndex = 81906
        Me.Label2.Text = ":"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 81905
        Me.Label3.Text = "Cntrl Name"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(115, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 16)
        Me.Label4.TabIndex = 81908
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 81907
        Me.Label5.Text = "Type"
        '
        'Txt_CntrlName
        '
        Me.Txt_CntrlName._AllowSpace = True
        Me.Txt_CntrlName.AcceptsReturn = True
        Me.Txt_CntrlName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_CntrlName.BackColor = System.Drawing.SystemColors.Window
        Me.Txt_CntrlName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_CntrlName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CntrlName.Check_End_Date_Value_FY = "YES"
        Me.Txt_CntrlName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_CntrlName.ClearField = True
        Me.Txt_CntrlName.CustomInputTypeString = Nothing
        Me.Txt_CntrlName.Date_for_Database = Nothing
        Me.Txt_CntrlName.Date_Tag = Nothing
        Me.Txt_CntrlName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_CntrlName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.Txt_CntrlName.ExtraValue = ""
        Me.Txt_CntrlName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CntrlName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_CntrlName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_CntrlName.ForeColor = System.Drawing.Color.Black
        Me.Txt_CntrlName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_CntrlName.IsValidated = False
        Me.Txt_CntrlName.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.Txt_CntrlName.Location = New System.Drawing.Point(135, 51)
        Me.Txt_CntrlName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_CntrlName.MandatoryField = False
        Me.Txt_CntrlName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_CntrlName.MaxDate = "FinYearEndDate"
        Me.Txt_CntrlName.MaxLength = 12
        Me.Txt_CntrlName.MinDate = "FinYearStartDate"
        Me.Txt_CntrlName.Name = "Txt_CntrlName"
        Me.Txt_CntrlName.NormalBorderColor = System.Drawing.Color.Gray
        Me.Txt_CntrlName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_CntrlName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_CntrlName.RegularExpression = Nothing
        Me.Txt_CntrlName.RegularExpressionErrorMessage = Nothing
        Me.Txt_CntrlName.ShowMessage = False
        Me.Txt_CntrlName.Size = New System.Drawing.Size(955, 22)
        Me.Txt_CntrlName.SpacerString = ""
        Me.Txt_CntrlName.TabIndex = 2
        Me.Txt_CntrlName.Tag = "FormID"
        Me.Txt_CntrlName.TransparentBox = True
        Me.Txt_CntrlName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        Me.Txt_CntrlName.Visible = False
        '
        'TxtType
        '
        Me.TxtType._AllowSpace = True
        Me.TxtType.AcceptsReturn = True
        Me.TxtType.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtType.BackColor = System.Drawing.Color.Bisque
        Me.TxtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtType.Check_End_Date_Value_FY = "YES"
        Me.TxtType.Check_Start_Date_Value_FY = "YES"
        Me.TxtType.ClearField = True
        Me.TxtType.CustomInputTypeString = Nothing
        Me.TxtType.Date_for_Database = Nothing
        Me.TxtType.Date_Tag = Nothing
        Me.TxtType.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtType.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtType.ExtraValue = ""
        Me.TxtType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtType.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtType.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtType.ForeColor = System.Drawing.Color.Black
        Me.TxtType.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.TxtType.IsValidated = False
        Me.TxtType.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.TxtType.Location = New System.Drawing.Point(135, 18)
        Me.TxtType.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtType.MandatoryField = False
        Me.TxtType.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TxtType.MaxDate = "FinYearEndDate"
        Me.TxtType.MaxLength = 12
        Me.TxtType.MinDate = "FinYearStartDate"
        Me.TxtType.Name = "TxtType"
        Me.TxtType.NormalBorderColor = System.Drawing.Color.Gray
        Me.TxtType.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtType.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtType.ReadOnly = True
        Me.TxtType.RegularExpression = Nothing
        Me.TxtType.RegularExpressionErrorMessage = Nothing
        Me.TxtType.ShowMessage = False
        Me.TxtType.Size = New System.Drawing.Size(956, 22)
        Me.TxtType.SpacerString = "VIEW,PRINT,TOTAL COLUMN"
        Me.TxtType.TabIndex = 1
        Me.TxtType.Tag = ""
        Me.TxtType.Text = "VIEW"
        Me.TxtType.TransparentBox = True
        Me.TxtType.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(115, 541)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 16)
        Me.Label20.TabIndex = 82052
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
        Me.Txt_Active.Location = New System.Drawing.Point(136, 541)
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
        Me.Label7.Location = New System.Drawing.Point(18, 541)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 82051
        Me.Label7.Text = "Active"
        '
        'QueryLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1104, 611)
        Me.Controls.Add(Me.Txt_CntrlName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Txt_Active)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RTBQuery)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "QueryLoad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Structure"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RTBQuery As RichTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_CntrlName As ctl_TextBox.ctl_TextBox
    Friend WithEvents TxtType As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Txt_Active As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label7 As Label
End Class
