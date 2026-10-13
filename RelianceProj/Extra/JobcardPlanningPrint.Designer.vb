<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobcardPlanningPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobcardPlanningPrint))
        Me.Cmd_JobNoWise = New System.Windows.Forms.Button()
        Me.lbl_Paper_Size = New System.Windows.Forms.Label()
        Me.txt_Stationary_Type = New ctl_TextBox.ctl_TextBox()
        Me.lbl_Paper_Size_1 = New System.Windows.Forms.Label()
        Me.lbl_line2 = New System.Windows.Forms.Label()
        Me.lbl_line3 = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.lbl_Range2 = New System.Windows.Forms.Label()
        Me.lbl_Range1 = New System.Windows.Forms.Label()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.cmd_No_Wise = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Cmd_JobNoWise
        '
        Me.Cmd_JobNoWise.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Cmd_JobNoWise.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Cmd_JobNoWise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_JobNoWise.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_JobNoWise.ForeColor = System.Drawing.Color.Black
        Me.Cmd_JobNoWise.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_JobNoWise.Location = New System.Drawing.Point(1, 33)
        Me.Cmd_JobNoWise.Name = "Cmd_JobNoWise"
        Me.Cmd_JobNoWise.Size = New System.Drawing.Size(152, 34)
        Me.Cmd_JobNoWise.TabIndex = 81934
        Me.Cmd_JobNoWise.Text = "&Job No. Wise"
        Me.Cmd_JobNoWise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_JobNoWise.UseVisualStyleBackColor = False
        '
        'lbl_Paper_Size
        '
        Me.lbl_Paper_Size.AutoSize = True
        Me.lbl_Paper_Size.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Paper_Size.Location = New System.Drawing.Point(332, 85)
        Me.lbl_Paper_Size.Name = "lbl_Paper_Size"
        Me.lbl_Paper_Size.Size = New System.Drawing.Size(12, 14)
        Me.lbl_Paper_Size.TabIndex = 81947
        Me.lbl_Paper_Size.Text = ":"
        '
        'txt_Stationary_Type
        '
        Me.txt_Stationary_Type._AllowSpace = True
        Me.txt_Stationary_Type.AcceptsReturn = True
        Me.txt_Stationary_Type.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Stationary_Type.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_Stationary_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Stationary_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Stationary_Type.Check_End_Date_Value_FY = "YES"
        Me.txt_Stationary_Type.Check_Start_Date_Value_FY = "YES"
        Me.txt_Stationary_Type.ClearField = True
        Me.txt_Stationary_Type.CustomInputTypeString = Nothing
        Me.txt_Stationary_Type.Date_for_Database = Nothing
        Me.txt_Stationary_Type.Date_Tag = Nothing
        Me.txt_Stationary_Type.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Stationary_Type.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Stationary_Type.ExtraValue = ""
        Me.txt_Stationary_Type.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Stationary_Type.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Stationary_Type.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Stationary_Type.ForeColor = System.Drawing.Color.Black
        Me.txt_Stationary_Type.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.txt_Stationary_Type.IsValidated = False
        Me.txt_Stationary_Type.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_Stationary_Type.Location = New System.Drawing.Point(352, 85)
        Me.txt_Stationary_Type.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Stationary_Type.MandatoryField = False
        Me.txt_Stationary_Type.MaxDate = Nothing
        Me.txt_Stationary_Type.MinDate = Nothing
        Me.txt_Stationary_Type.Name = "txt_Stationary_Type"
        Me.txt_Stationary_Type.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_Stationary_Type.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Stationary_Type.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Stationary_Type.RegularExpression = Nothing
        Me.txt_Stationary_Type.RegularExpressionErrorMessage = Nothing
        Me.txt_Stationary_Type.ShowMessage = False
        Me.txt_Stationary_Type.Size = New System.Drawing.Size(85, 22)
        Me.txt_Stationary_Type.SpacerString = "PLAIN,PRINTED"
        Me.txt_Stationary_Type.TabIndex = 81938
        Me.txt_Stationary_Type.Tag = "BOOKNAME"
        Me.txt_Stationary_Type.Text = "PLAIN"
        Me.txt_Stationary_Type.TransparentBox = True
        Me.txt_Stationary_Type.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'lbl_Paper_Size_1
        '
        Me.lbl_Paper_Size_1.AutoSize = True
        Me.lbl_Paper_Size_1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Paper_Size_1.Location = New System.Drawing.Point(170, 85)
        Me.lbl_Paper_Size_1.Name = "lbl_Paper_Size_1"
        Me.lbl_Paper_Size_1.Size = New System.Drawing.Size(124, 14)
        Me.lbl_Paper_Size_1.TabIndex = 81946
        Me.lbl_Paper_Size_1.Text = "Rpt Format (1/2)"
        '
        'lbl_line2
        '
        Me.lbl_line2.AutoSize = True
        Me.lbl_line2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_line2.Location = New System.Drawing.Point(332, 22)
        Me.lbl_line2.Name = "lbl_line2"
        Me.lbl_line2.Size = New System.Drawing.Size(12, 14)
        Me.lbl_line2.TabIndex = 81945
        Me.lbl_line2.Text = ":"
        '
        'lbl_line3
        '
        Me.lbl_line3.AutoSize = True
        Me.lbl_line3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_line3.Location = New System.Drawing.Point(332, 52)
        Me.lbl_line3.Name = "lbl_line3"
        Me.lbl_line3.Size = New System.Drawing.Size(12, 14)
        Me.lbl_line3.TabIndex = 81944
        Me.lbl_line3.Text = ":"
        '
        'txt_To
        '
        Me.txt_To._AllowSpace = True
        Me.txt_To.AcceptsReturn = True
        Me.txt_To.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_To.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_To.Check_End_Date_Value_FY = "YES"
        Me.txt_To.Check_Start_Date_Value_FY = "YES"
        Me.txt_To.ClearField = True
        Me.txt_To.CustomInputTypeString = Nothing
        Me.txt_To.Date_for_Database = Nothing
        Me.txt_To.Date_Tag = Nothing
        Me.txt_To.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_To.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_To.ExtraValue = ""
        Me.txt_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_To.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_To.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_To.ForeColor = System.Drawing.Color.Black
        Me.txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_To.IsValidated = False
        Me.txt_To.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_To.Location = New System.Drawing.Point(352, 52)
        Me.txt_To.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_To.MandatoryField = False
        Me.txt_To.MaxDate = Nothing
        Me.txt_To.MinDate = Nothing
        Me.txt_To.Name = "txt_To"
        Me.txt_To.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_To.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_To.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_To.RegularExpression = Nothing
        Me.txt_To.RegularExpressionErrorMessage = Nothing
        Me.txt_To.ShowMessage = False
        Me.txt_To.Size = New System.Drawing.Size(106, 22)
        Me.txt_To.SpacerString = ""
        Me.txt_To.TabIndex = 81937
        Me.txt_To.Tag = "BOOKNAME"
        Me.txt_To.TransparentBox = True
        Me.txt_To.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'lbl_Range2
        '
        Me.lbl_Range2.AutoSize = True
        Me.lbl_Range2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Range2.Location = New System.Drawing.Point(170, 52)
        Me.lbl_Range2.Name = "lbl_Range2"
        Me.lbl_Range2.Size = New System.Drawing.Size(112, 14)
        Me.lbl_Range2.TabIndex = 81943
        Me.lbl_Range2.Text = "Ending Entry No"
        '
        'lbl_Range1
        '
        Me.lbl_Range1.AutoSize = True
        Me.lbl_Range1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Range1.Location = New System.Drawing.Point(170, 22)
        Me.lbl_Range1.Name = "lbl_Range1"
        Me.lbl_Range1.Size = New System.Drawing.Size(121, 14)
        Me.lbl_Range1.TabIndex = 81942
        Me.lbl_Range1.Text = "Starting Entry No"
        '
        'txt_From
        '
        Me.txt_From._AllowSpace = True
        Me.txt_From.AcceptsReturn = True
        Me.txt_From.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_From.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_From.Check_End_Date_Value_FY = "YES"
        Me.txt_From.Check_Start_Date_Value_FY = "YES"
        Me.txt_From.ClearField = True
        Me.txt_From.CustomInputTypeString = Nothing
        Me.txt_From.Date_for_Database = Nothing
        Me.txt_From.Date_Tag = Nothing
        Me.txt_From.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_From.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_From.ExtraValue = ""
        Me.txt_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_From.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_From.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_From.ForeColor = System.Drawing.Color.Black
        Me.txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_From.IsValidated = False
        Me.txt_From.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_From.Location = New System.Drawing.Point(352, 22)
        Me.txt_From.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_From.MandatoryField = False
        Me.txt_From.MaxDate = Nothing
        Me.txt_From.MinDate = Nothing
        Me.txt_From.Name = "txt_From"
        Me.txt_From.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_From.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_From.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_From.RegularExpression = Nothing
        Me.txt_From.RegularExpressionErrorMessage = Nothing
        Me.txt_From.ShowMessage = False
        Me.txt_From.Size = New System.Drawing.Size(106, 22)
        Me.txt_From.SpacerString = ""
        Me.txt_From.TabIndex = 81936
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'cmd_No_Wise
        '
        Me.cmd_No_Wise.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmd_No_Wise.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.cmd_No_Wise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_No_Wise.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_No_Wise.ForeColor = System.Drawing.Color.Black
        Me.cmd_No_Wise.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_No_Wise.Location = New System.Drawing.Point(1, 0)
        Me.cmd_No_Wise.Name = "cmd_No_Wise"
        Me.cmd_No_Wise.Size = New System.Drawing.Size(152, 34)
        Me.cmd_No_Wise.TabIndex = 81933
        Me.cmd_No_Wise.Text = "&Entry No. Wise"
        Me.cmd_No_Wise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_No_Wise.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(152, -3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1, 394)
        Me.Label3.TabIndex = 81941
        '
        'btnOk
        '
        Me.btnOk.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Appearance.Options.UseFont = True
        Me.btnOk.ImageOptions.Image = CType(resources.GetObject("btnOk.ImageOptions.Image"), System.Drawing.Image)
        Me.btnOk.Location = New System.Drawing.Point(352, 155)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(67, 37)
        Me.btnOk.TabIndex = 81939
        Me.btnOk.Text = "Ok"
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.ImageOptions.ImageUri.Uri = "Close"
        Me.btnClose.Location = New System.Drawing.Point(435, 155)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 37)
        Me.btnClose.TabIndex = 81940
        Me.btnClose.Text = "&Close"
        '
        'JobcardPlanningPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(599, 238)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Cmd_JobNoWise)
        Me.Controls.Add(Me.lbl_Paper_Size)
        Me.Controls.Add(Me.txt_Stationary_Type)
        Me.Controls.Add(Me.lbl_Paper_Size_1)
        Me.Controls.Add(Me.lbl_line2)
        Me.Controls.Add(Me.lbl_line3)
        Me.Controls.Add(Me.txt_To)
        Me.Controls.Add(Me.lbl_Range2)
        Me.Controls.Add(Me.lbl_Range1)
        Me.Controls.Add(Me.txt_From)
        Me.Controls.Add(Me.cmd_No_Wise)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "JobcardPlanningPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jobcard Planning Print"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cmd_JobNoWise As Button
    Friend WithEvents lbl_Paper_Size As Label
    Friend WithEvents txt_Stationary_Type As ctl_TextBox.ctl_TextBox
    Friend WithEvents lbl_Paper_Size_1 As Label
    Friend WithEvents lbl_line2 As Label
    Friend WithEvents lbl_line3 As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents lbl_Range2 As Label
    Friend WithEvents lbl_Range1 As Label
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents cmd_No_Wise As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
End Class
