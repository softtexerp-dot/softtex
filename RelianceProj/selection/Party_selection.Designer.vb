<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Party_selection
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgw = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New ctl_TextBox.ctl_TextBox()
        Me.pnl_Filter_Working = New System.Windows.Forms.Panel()
        Me.lbl_Filter_Header = New System.Windows.Forms.Label()
        Me.txt_Filter_Text = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnl_Filter_Working.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgw
        '
        Me.dgw.AllowUserToAddRows = False
        Me.dgw.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgw.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgw.BackgroundColor = System.Drawing.Color.White
        Me.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgw.ColumnHeadersHeight = 25
        Me.dgw.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgw.EnableHeadersVisualStyles = False
        Me.dgw.GridColor = System.Drawing.Color.Gray
        Me.dgw.Location = New System.Drawing.Point(7, 41)
        Me.dgw.Margin = New System.Windows.Forms.Padding(4)
        Me.dgw.MultiSelect = False
        Me.dgw.Name = "dgw"
        Me.dgw.ReadOnly = True
        Me.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgw.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgw.RowHeadersVisible = False
        Me.dgw.RowHeadersWidth = 25
        Me.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgw.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgw.RowTemplate.Height = 25
        Me.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgw.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgw.Size = New System.Drawing.Size(613, 600)
        Me.dgw.TabIndex = 155
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.pnl_Filter_Working)
        Me.GroupBox1.Controls.Add(Me.dgw)
        Me.GroupBox1.Location = New System.Drawing.Point(0, -6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 644)
        Me.GroupBox1.TabIndex = 174
        Me.GroupBox1.TabStop = False
        '
        'txtSearch
        '
        Me.txtSearch._AllowSpace = True
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtSearch.BackColor = System.Drawing.Color.LightCyan
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Check_End_Date_Value_FY = "YES"
        Me.txtSearch.Check_Start_Date_Value_FY = "YES"
        Me.txtSearch.ClearField = True
        Me.txtSearch.CustomInputTypeString = Nothing
        Me.txtSearch.Date_for_Database = Nothing
        Me.txtSearch.Date_Tag = Nothing
        Me.txtSearch.EnterFocusColor = System.Drawing.Color.White
        Me.txtSearch.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.txtSearch.ExtraValue = ""
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.FontFocusColor = System.Drawing.Color.Maroon
        Me.txtSearch.FontLeaveColor = System.Drawing.Color.Black
        Me.txtSearch.ForeColor = System.Drawing.Color.Black
        Me.txtSearch.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtSearch.IsValidated = False
        Me.txtSearch.LeaveFocusColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(4, 12)
        Me.txtSearch.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSearch.MandatoryField = False
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSearch.MaxDate = Nothing
        Me.txtSearch.MinDate = Nothing
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.NormalBorderColor = System.Drawing.Color.White
        Me.txtSearch.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtSearch.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtSearch.RegularExpression = Nothing
        Me.txtSearch.RegularExpressionErrorMessage = Nothing
        Me.txtSearch.ShowMessage = False
        Me.txtSearch.Size = New System.Drawing.Size(616, 22)
        Me.txtSearch.SpacerString = ""
        Me.txtSearch.TabIndex = 81356
        Me.txtSearch.Tag = "WEIGHT"
        Me.txtSearch.TransparentBox = True
        Me.txtSearch.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'pnl_Filter_Working
        '
        Me.pnl_Filter_Working.BackColor = System.Drawing.Color.Khaki
        Me.pnl_Filter_Working.Controls.Add(Me.lbl_Filter_Header)
        Me.pnl_Filter_Working.Controls.Add(Me.txt_Filter_Text)
        Me.pnl_Filter_Working.Location = New System.Drawing.Point(86, 215)
        Me.pnl_Filter_Working.Name = "pnl_Filter_Working"
        Me.pnl_Filter_Working.Size = New System.Drawing.Size(337, 97)
        Me.pnl_Filter_Working.TabIndex = 156
        Me.pnl_Filter_Working.Visible = False
        '
        'lbl_Filter_Header
        '
        Me.lbl_Filter_Header.Font = New System.Drawing.Font("Trebuchet MS", 12.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Filter_Header.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_Filter_Header.Location = New System.Drawing.Point(7, 15)
        Me.lbl_Filter_Header.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Filter_Header.Name = "lbl_Filter_Header"
        Me.lbl_Filter_Header.Size = New System.Drawing.Size(323, 23)
        Me.lbl_Filter_Header.TabIndex = 81356
        Me.lbl_Filter_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Filter_Text
        '
        Me.txt_Filter_Text._AllowSpace = True
        Me.txt_Filter_Text.AcceptsReturn = True
        Me.txt_Filter_Text.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Filter_Text.BackColor = System.Drawing.Color.White
        Me.txt_Filter_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Filter_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Filter_Text.Check_End_Date_Value_FY = "YES"
        Me.txt_Filter_Text.Check_Start_Date_Value_FY = "YES"
        Me.txt_Filter_Text.ClearField = True
        Me.txt_Filter_Text.CustomInputTypeString = Nothing
        Me.txt_Filter_Text.Date_for_Database = Nothing
        Me.txt_Filter_Text.Date_Tag = Nothing
        Me.txt_Filter_Text.EnterFocusColor = System.Drawing.Color.White
        Me.txt_Filter_Text.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.txt_Filter_Text.ExtraValue = ""
        Me.txt_Filter_Text.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Filter_Text.FontFocusColor = System.Drawing.Color.Maroon
        Me.txt_Filter_Text.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Filter_Text.ForeColor = System.Drawing.Color.Black
        Me.txt_Filter_Text.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_Filter_Text.IsValidated = False
        Me.txt_Filter_Text.LeaveFocusColor = System.Drawing.Color.White
        Me.txt_Filter_Text.Location = New System.Drawing.Point(11, 56)
        Me.txt_Filter_Text.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Filter_Text.MandatoryField = False
        Me.txt_Filter_Text.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_Filter_Text.MaxDate = Nothing
        Me.txt_Filter_Text.MinDate = Nothing
        Me.txt_Filter_Text.Name = "txt_Filter_Text"
        Me.txt_Filter_Text.NormalBorderColor = System.Drawing.Color.White
        Me.txt_Filter_Text.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Filter_Text.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Filter_Text.RegularExpression = Nothing
        Me.txt_Filter_Text.RegularExpressionErrorMessage = Nothing
        Me.txt_Filter_Text.ShowMessage = False
        Me.txt_Filter_Text.Size = New System.Drawing.Size(319, 22)
        Me.txt_Filter_Text.SpacerString = ""
        Me.txt_Filter_Text.TabIndex = 81355
        Me.txt_Filter_Text.Tag = "WEIGHT"
        Me.txt_Filter_Text.TransparentBox = True
        Me.txt_Filter_Text.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 16)
        Me.Label2.TabIndex = 176
        Me.Label2.Text = "Selected Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "Selected id"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 250)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 16)
        Me.Label4.TabIndex = 179
        Me.Label4.Text = "New Form Open"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 16)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "COLOUM2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 181
        Me.Label7.Text = "COLOUM4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 16)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "FOCUS FORM NAME"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(786, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 272)
        Me.Panel1.TabIndex = 183
        Me.Panel1.Visible = False
        '
        'Party_selection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(629, 640)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Party_selection"
        Me.Text = "Selection List (F2=New,Ctrl+X=Export Excel)"
        CType(Me.dgw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnl_Filter_Working.ResumeLayout(False)
        Me.pnl_Filter_Working.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgw As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnl_Filter_Working As System.Windows.Forms.Panel
    Friend WithEvents lbl_Filter_Header As System.Windows.Forms.Label
    Friend WithEvents txt_Filter_Text As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtSearch As ctl_TextBox.ctl_TextBox
End Class
