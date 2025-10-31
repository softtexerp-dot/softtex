<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogBookGridReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogBookGridReport))
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.PivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.Txt_ProcessStockDisplay = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_xl = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(681, 8)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(66, 36)
        Me.But_ok.TabIndex = 4
        Me.But_ok.Text = "Ok"
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.Location = New System.Drawing.Point(12, 54)
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.OptionsCustomization.AllowFilterInCustomizationForm = True
        Me.PivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized
        Me.PivotGridControl1.Size = New System.Drawing.Size(780, 555)
        Me.PivotGridControl1.TabIndex = 5
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_To.Location = New System.Drawing.Point(226, 19)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 81954
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_From.Location = New System.Drawing.Point(28, 19)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 81953
        Me.lbl_From.Text = "Date From:"
        '
        'txt_To
        '
        Me.txt_To._AllowSpace = True
        Me.txt_To.AcceptsReturn = True
        Me.txt_To.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_To.BackColor = System.Drawing.Color.LightCyan
        Me.txt_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_To.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_To.Check_End_Date_Value_FY = "YES"
        Me.txt_To.Check_Start_Date_Value_FY = "YES"
        Me.txt_To.ClearField = True
        Me.txt_To.CustomInputTypeString = Nothing
        Me.txt_To.Date_for_Database = Nothing
        Me.txt_To.Date_Tag = Nothing
        Me.txt_To.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.txt_To.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_To.ExtraValue = ""
        Me.txt_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_To.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_To.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_To.ForeColor = System.Drawing.Color.Black
        Me.txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_To.IsValidated = False
        Me.txt_To.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_To.Location = New System.Drawing.Point(292, 15)
        Me.txt_To.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_To.MandatoryField = False
        Me.txt_To.MaxDate = Nothing
        Me.txt_To.MinDate = Nothing
        Me.txt_To.Name = "txt_To"
        Me.txt_To.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txt_To.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_To.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_To.RegularExpression = Nothing
        Me.txt_To.RegularExpressionErrorMessage = Nothing
        Me.txt_To.ShowMessage = False
        Me.txt_To.Size = New System.Drawing.Size(95, 22)
        Me.txt_To.SpacerString = ""
        Me.txt_To.TabIndex = 2
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
        Me.txt_From.BackColor = System.Drawing.Color.LightCyan
        Me.txt_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_From.Check_End_Date_Value_FY = "YES"
        Me.txt_From.Check_Start_Date_Value_FY = "YES"
        Me.txt_From.ClearField = True
        Me.txt_From.CustomInputTypeString = Nothing
        Me.txt_From.Date_for_Database = Nothing
        Me.txt_From.Date_Tag = Nothing
        Me.txt_From.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.txt_From.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_From.ExtraValue = ""
        Me.txt_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_From.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_From.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_From.ForeColor = System.Drawing.Color.Black
        Me.txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_From.IsValidated = False
        Me.txt_From.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_From.Location = New System.Drawing.Point(111, 15)
        Me.txt_From.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_From.MandatoryField = False
        Me.txt_From.MaxDate = Nothing
        Me.txt_From.MinDate = Nothing
        Me.txt_From.Name = "txt_From"
        Me.txt_From.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txt_From.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_From.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_From.RegularExpression = Nothing
        Me.txt_From.RegularExpressionErrorMessage = Nothing
        Me.txt_From.ShowMessage = False
        Me.txt_From.Size = New System.Drawing.Size(95, 22)
        Me.txt_From.SpacerString = ""
        Me.txt_From.TabIndex = 1
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_ProcessStockDisplay
        '
        Me.Txt_ProcessStockDisplay._AllowSpace = True
        Me.Txt_ProcessStockDisplay.AcceptsReturn = True
        Me.Txt_ProcessStockDisplay.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ProcessStockDisplay.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Txt_ProcessStockDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ProcessStockDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ProcessStockDisplay.Check_End_Date_Value_FY = "YES"
        Me.Txt_ProcessStockDisplay.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ProcessStockDisplay.ClearField = True
        Me.Txt_ProcessStockDisplay.CustomInputTypeString = Nothing
        Me.Txt_ProcessStockDisplay.Date_for_Database = Nothing
        Me.Txt_ProcessStockDisplay.Date_Tag = Nothing
        Me.Txt_ProcessStockDisplay.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_ProcessStockDisplay.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ProcessStockDisplay.ExtraValue = ""
        Me.Txt_ProcessStockDisplay.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ProcessStockDisplay.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ProcessStockDisplay.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ProcessStockDisplay.ForeColor = System.Drawing.Color.Black
        Me.Txt_ProcessStockDisplay.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_ProcessStockDisplay.IsValidated = False
        Me.Txt_ProcessStockDisplay.LeaveFocusColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Txt_ProcessStockDisplay.Location = New System.Drawing.Point(517, 15)
        Me.Txt_ProcessStockDisplay.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ProcessStockDisplay.MandatoryField = False
        Me.Txt_ProcessStockDisplay.MaxDate = Nothing
        Me.Txt_ProcessStockDisplay.MinDate = Nothing
        Me.Txt_ProcessStockDisplay.Name = "Txt_ProcessStockDisplay"
        Me.Txt_ProcessStockDisplay.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Txt_ProcessStockDisplay.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ProcessStockDisplay.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ProcessStockDisplay.ReadOnly = True
        Me.Txt_ProcessStockDisplay.RegularExpression = Nothing
        Me.Txt_ProcessStockDisplay.RegularExpressionErrorMessage = Nothing
        Me.Txt_ProcessStockDisplay.ShowMessage = False
        Me.Txt_ProcessStockDisplay.Size = New System.Drawing.Size(87, 22)
        Me.Txt_ProcessStockDisplay.SpacerString = "Summary,Detail"
        Me.Txt_ProcessStockDisplay.TabIndex = 3
        Me.Txt_ProcessStockDisplay.Tag = "VECHNO"
        Me.Txt_ProcessStockDisplay.Text = "SUMMARY"
        Me.Txt_ProcessStockDisplay.TransparentBox = True
        Me.Txt_ProcessStockDisplay.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(430, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 81956
        Me.Label1.Text = "Selection :"
        '
        'btn_xl
        '
        Me.btn_xl.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xl.Appearance.Options.UseFont = True
        Me.btn_xl.ImageOptions.Image = CType(resources.GetObject("btn_xl.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_xl.Location = New System.Drawing.Point(795, 8)
        Me.btn_xl.Name = "btn_xl"
        Me.btn_xl.Size = New System.Drawing.Size(39, 36)
        Me.btn_xl.TabIndex = 81960
        '
        'But_print
        '
        Me.But_print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.Appearance.Options.UseFont = True
        Me.But_print.ImageOptions.Image = CType(resources.GetObject("But_print.ImageOptions.Image"), System.Drawing.Image)
        Me.But_print.Location = New System.Drawing.Point(753, 8)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(39, 36)
        Me.But_print.TabIndex = 81959
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(881, 8)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(40, 36)
        Me.Btn_LayoutLoad.TabIndex = 81958
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(837, 8)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(41, 36)
        Me.BtnLayOutSave.TabIndex = 81957
        '
        'LogBookGridReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 621)
        Me.Controls.Add(Me.btn_xl)
        Me.Controls.Add(Me.But_print)
        Me.Controls.Add(Me.Btn_LayoutLoad)
        Me.Controls.Add(Me.BtnLayOutSave)
        Me.Controls.Add(Me.Txt_ProcessStockDisplay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_To)
        Me.Controls.Add(Me.lbl_From)
        Me.Controls.Add(Me.txt_To)
        Me.Controls.Add(Me.txt_From)
        Me.Controls.Add(Me.PivotGridControl1)
        Me.Controls.Add(Me.But_ok)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "LogBookGridReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LogBookGridReport"
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_ProcessStockDisplay As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_xl As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
End Class
