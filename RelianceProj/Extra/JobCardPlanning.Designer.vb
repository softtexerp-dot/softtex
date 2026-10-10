<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobCardPlanning
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobCardPlanning))
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Txt_PrintQty = New ctl_TextBox.ctl_TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Txt_AcoFName = New ctl_TextBox.ctl_TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Txt_LaminDrip = New ctl_TextBox.ctl_TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Txt_Size = New ctl_TextBox.ctl_TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_JobSize = New ctl_TextBox.ctl_TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_CuttingSize = New ctl_TextBox.ctl_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_ByerName = New ctl_TextBox.ctl_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PNL_View = New System.Windows.Forms.GroupBox()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btn_View_Ok = New System.Windows.Forms.Button()
        Me.Btn_Export_Excel = New System.Windows.Forms.Button()
        Me.btn_View_Print = New System.Windows.Forms.Button()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtHeader_Remark = New ctl_TextBox.ctl_TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtAccountName = New ctl_TextBox.ctl_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtChallanNo = New ctl_TextBox.ctl_TextBox()
        Me.txtChallanDate = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UC_Buttons1 = New RelianceProj.UC_Buttons()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtpaperform = New ctl_TextBox.ctl_TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtpaper = New ctl_TextBox.ctl_TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtMachinesize = New ctl_TextBox.ctl_TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtRemark = New ctl_TextBox.ctl_TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNL_View.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(121, 390)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 14)
        Me.Label21.TabIndex = 82265
        Me.Label21.Text = ":"
        '
        'Txt_PrintQty
        '
        Me.Txt_PrintQty._AllowSpace = True
        Me.Txt_PrintQty.AcceptsReturn = True
        Me.Txt_PrintQty.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_PrintQty.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_PrintQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_PrintQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PrintQty.Check_End_Date_Value_FY = "YES"
        Me.Txt_PrintQty.Check_Start_Date_Value_FY = "YES"
        Me.Txt_PrintQty.ClearField = True
        Me.Txt_PrintQty.CustomInputTypeString = Nothing
        Me.Txt_PrintQty.Date_for_Database = Nothing
        Me.Txt_PrintQty.Date_Tag = Nothing
        Me.Txt_PrintQty.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_PrintQty.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_PrintQty.ExtraValue = ""
        Me.Txt_PrintQty.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PrintQty.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_PrintQty.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_PrintQty.ForeColor = System.Drawing.Color.Black
        Me.Txt_PrintQty.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.Txt_PrintQty.IsValidated = False
        Me.Txt_PrintQty.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_PrintQty.Location = New System.Drawing.Point(139, 386)
        Me.Txt_PrintQty.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_PrintQty.MandatoryField = False
        Me.Txt_PrintQty.MaxDate = Nothing
        Me.Txt_PrintQty.MinDate = Nothing
        Me.Txt_PrintQty.Name = "Txt_PrintQty"
        Me.Txt_PrintQty.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_PrintQty.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_PrintQty.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.Txt_PrintQty.RegularExpression = Nothing
        Me.Txt_PrintQty.RegularExpressionErrorMessage = Nothing
        Me.Txt_PrintQty.ShowMessage = False
        Me.Txt_PrintQty.Size = New System.Drawing.Size(255, 22)
        Me.Txt_PrintQty.SpacerString = ""
        Me.Txt_PrintQty.TabIndex = 82230
        Me.Txt_PrintQty.Tag = "TOTALMTR"
        Me.Txt_PrintQty.TransparentBox = True
        Me.Txt_PrintQty.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 390)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 14)
        Me.Label22.TabIndex = 82264
        Me.Label22.Text = "Print Qty"
        '
        'Txt_AcoFName
        '
        Me.Txt_AcoFName._AllowSpace = True
        Me.Txt_AcoFName.AcceptsReturn = True
        Me.Txt_AcoFName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_AcoFName.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_AcoFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_AcoFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AcoFName.Check_End_Date_Value_FY = "YES"
        Me.Txt_AcoFName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_AcoFName.ClearField = True
        Me.Txt_AcoFName.CustomInputTypeString = Nothing
        Me.Txt_AcoFName.Date_for_Database = Nothing
        Me.Txt_AcoFName.Date_Tag = Nothing
        Me.Txt_AcoFName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_AcoFName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.Txt_AcoFName.ExtraValue = ""
        Me.Txt_AcoFName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AcoFName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_AcoFName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_AcoFName.ForeColor = System.Drawing.Color.Black
        Me.Txt_AcoFName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.Txt_AcoFName.IsValidated = False
        Me.Txt_AcoFName.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_AcoFName.Location = New System.Drawing.Point(139, 164)
        Me.Txt_AcoFName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_AcoFName.MandatoryField = False
        Me.Txt_AcoFName.MaxDate = Nothing
        Me.Txt_AcoFName.MinDate = Nothing
        Me.Txt_AcoFName.Name = "Txt_AcoFName"
        Me.Txt_AcoFName.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_AcoFName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_AcoFName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_AcoFName.RegularExpression = Nothing
        Me.Txt_AcoFName.RegularExpressionErrorMessage = Nothing
        Me.Txt_AcoFName.ShowMessage = False
        Me.Txt_AcoFName.Size = New System.Drawing.Size(255, 22)
        Me.Txt_AcoFName.SpacerString = ""
        Me.Txt_AcoFName.TabIndex = 82223
        Me.Txt_AcoFName.Tag = "AC_NAME"
        Me.Txt_AcoFName.TransparentBox = True
        Me.Txt_AcoFName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 166)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 14)
        Me.Label14.TabIndex = 82262
        Me.Label14.Text = "AC/Of"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(121, 166)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 14)
        Me.Label15.TabIndex = 82263
        Me.Label15.Text = ":"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Ivory
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(419, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(504, 451)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 82259
        Me.PictureBox1.TabStop = False
        '
        'Txt_LaminDrip
        '
        Me.Txt_LaminDrip._AllowSpace = True
        Me.Txt_LaminDrip.AcceptsReturn = True
        Me.Txt_LaminDrip.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_LaminDrip.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_LaminDrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_LaminDrip.Check_End_Date_Value_FY = "YES"
        Me.Txt_LaminDrip.Check_Start_Date_Value_FY = "YES"
        Me.Txt_LaminDrip.ClearField = True
        Me.Txt_LaminDrip.CustomInputTypeString = Nothing
        Me.Txt_LaminDrip.Date_for_Database = Nothing
        Me.Txt_LaminDrip.Date_Tag = Nothing
        Me.Txt_LaminDrip.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_LaminDrip.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_LaminDrip.ExtraValue = ""
        Me.Txt_LaminDrip.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LaminDrip.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_LaminDrip.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_LaminDrip.ForeColor = System.Drawing.Color.Black
        Me.Txt_LaminDrip.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_LaminDrip.IsValidated = False
        Me.Txt_LaminDrip.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_LaminDrip.Location = New System.Drawing.Point(139, 313)
        Me.Txt_LaminDrip.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_LaminDrip.MandatoryField = False
        Me.Txt_LaminDrip.MaxDate = Nothing
        Me.Txt_LaminDrip.MinDate = Nothing
        Me.Txt_LaminDrip.Multiline = True
        Me.Txt_LaminDrip.Name = "Txt_LaminDrip"
        Me.Txt_LaminDrip.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_LaminDrip.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_LaminDrip.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_LaminDrip.RegularExpression = Nothing
        Me.Txt_LaminDrip.RegularExpressionErrorMessage = Nothing
        Me.Txt_LaminDrip.ShowMessage = False
        Me.Txt_LaminDrip.Size = New System.Drawing.Size(251, 41)
        Me.Txt_LaminDrip.SpacerString = ""
        Me.Txt_LaminDrip.TabIndex = 82228
        Me.Txt_LaminDrip.Tag = "BATCHNO"
        Me.Txt_LaminDrip.TransparentBox = True
        Me.Txt_LaminDrip.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(5, 326)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(59, 14)
        Me.Label18.TabIndex = 82257
        Me.Label18.Text = "Process"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(121, 326)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 14)
        Me.Label19.TabIndex = 82258
        Me.Label19.Text = ":"
        '
        'Txt_Size
        '
        Me.Txt_Size._AllowSpace = True
        Me.Txt_Size.AcceptsReturn = True
        Me.Txt_Size.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Size.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_Size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Size.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Size.Check_End_Date_Value_FY = "YES"
        Me.Txt_Size.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Size.ClearField = True
        Me.Txt_Size.CustomInputTypeString = Nothing
        Me.Txt_Size.Date_for_Database = Nothing
        Me.Txt_Size.Date_Tag = Nothing
        Me.Txt_Size.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Size.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Size.ExtraValue = ""
        Me.Txt_Size.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Size.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Size.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Size.ForeColor = System.Drawing.Color.Black
        Me.Txt_Size.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_Size.IsValidated = False
        Me.Txt_Size.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_Size.Location = New System.Drawing.Point(139, 289)
        Me.Txt_Size.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_Size.MandatoryField = False
        Me.Txt_Size.MaxDate = Nothing
        Me.Txt_Size.MinDate = Nothing
        Me.Txt_Size.Name = "Txt_Size"
        Me.Txt_Size.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_Size.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Size.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Size.RegularExpression = Nothing
        Me.Txt_Size.RegularExpressionErrorMessage = Nothing
        Me.Txt_Size.ShowMessage = False
        Me.Txt_Size.Size = New System.Drawing.Size(251, 22)
        Me.Txt_Size.SpacerString = ""
        Me.Txt_Size.TabIndex = 82227
        Me.Txt_Size.Tag = "MONOGRAM_TYPE"
        Me.Txt_Size.TransparentBox = True
        Me.Txt_Size.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 293)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 14)
        Me.Label16.TabIndex = 82255
        Me.Label16.Text = "Quality Name"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(121, 293)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 82256
        Me.Label17.Text = ":"
        '
        'Txt_JobSize
        '
        Me.Txt_JobSize._AllowSpace = True
        Me.Txt_JobSize.AcceptsReturn = True
        Me.Txt_JobSize.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_JobSize.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_JobSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_JobSize.Check_End_Date_Value_FY = "YES"
        Me.Txt_JobSize.Check_Start_Date_Value_FY = "YES"
        Me.Txt_JobSize.ClearField = True
        Me.Txt_JobSize.CustomInputTypeString = Nothing
        Me.Txt_JobSize.Date_for_Database = Nothing
        Me.Txt_JobSize.Date_Tag = Nothing
        Me.Txt_JobSize.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_JobSize.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_JobSize.ExtraValue = ""
        Me.Txt_JobSize.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_JobSize.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_JobSize.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_JobSize.ForeColor = System.Drawing.Color.Black
        Me.Txt_JobSize.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_JobSize.IsValidated = False
        Me.Txt_JobSize.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_JobSize.Location = New System.Drawing.Point(139, 254)
        Me.Txt_JobSize.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_JobSize.MandatoryField = False
        Me.Txt_JobSize.MaxDate = Nothing
        Me.Txt_JobSize.MinDate = Nothing
        Me.Txt_JobSize.Name = "Txt_JobSize"
        Me.Txt_JobSize.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_JobSize.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_JobSize.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_JobSize.RegularExpression = Nothing
        Me.Txt_JobSize.RegularExpressionErrorMessage = Nothing
        Me.Txt_JobSize.ShowMessage = False
        Me.Txt_JobSize.Size = New System.Drawing.Size(254, 22)
        Me.Txt_JobSize.SpacerString = ""
        Me.Txt_JobSize.TabIndex = 82226
        Me.Txt_JobSize.Tag = "LOTNO"
        Me.Txt_JobSize.TransparentBox = True
        Me.Txt_JobSize.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 14)
        Me.Label10.TabIndex = 82253
        Me.Label10.Text = "Job Size"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(121, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 14)
        Me.Label11.TabIndex = 82254
        Me.Label11.Text = ":"
        '
        'Txt_CuttingSize
        '
        Me.Txt_CuttingSize._AllowSpace = True
        Me.Txt_CuttingSize.AcceptsReturn = True
        Me.Txt_CuttingSize.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_CuttingSize.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_CuttingSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_CuttingSize.Check_End_Date_Value_FY = "YES"
        Me.Txt_CuttingSize.Check_Start_Date_Value_FY = "YES"
        Me.Txt_CuttingSize.ClearField = True
        Me.Txt_CuttingSize.CustomInputTypeString = Nothing
        Me.Txt_CuttingSize.Date_for_Database = Nothing
        Me.Txt_CuttingSize.Date_Tag = Nothing
        Me.Txt_CuttingSize.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_CuttingSize.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_CuttingSize.ExtraValue = ""
        Me.Txt_CuttingSize.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CuttingSize.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_CuttingSize.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_CuttingSize.ForeColor = System.Drawing.Color.Black
        Me.Txt_CuttingSize.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_CuttingSize.IsValidated = False
        Me.Txt_CuttingSize.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_CuttingSize.Location = New System.Drawing.Point(139, 220)
        Me.Txt_CuttingSize.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_CuttingSize.MandatoryField = False
        Me.Txt_CuttingSize.MaxDate = Nothing
        Me.Txt_CuttingSize.MinDate = Nothing
        Me.Txt_CuttingSize.Name = "Txt_CuttingSize"
        Me.Txt_CuttingSize.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_CuttingSize.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_CuttingSize.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_CuttingSize.RegularExpression = Nothing
        Me.Txt_CuttingSize.RegularExpressionErrorMessage = Nothing
        Me.Txt_CuttingSize.ShowMessage = False
        Me.Txt_CuttingSize.Size = New System.Drawing.Size(255, 22)
        Me.Txt_CuttingSize.SpacerString = ""
        Me.Txt_CuttingSize.TabIndex = 82225
        Me.Txt_CuttingSize.Tag = "SHADECODE"
        Me.Txt_CuttingSize.TransparentBox = True
        Me.Txt_CuttingSize.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 14)
        Me.Label8.TabIndex = 82251
        Me.Label8.Text = "Cutting Size"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(121, 224)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 14)
        Me.Label9.TabIndex = 82252
        Me.Label9.Text = ":"
        '
        'Txt_ByerName
        '
        Me.Txt_ByerName._AllowSpace = True
        Me.Txt_ByerName.AcceptsReturn = True
        Me.Txt_ByerName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ByerName.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_ByerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ByerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ByerName.Check_End_Date_Value_FY = "YES"
        Me.Txt_ByerName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ByerName.ClearField = True
        Me.Txt_ByerName.CustomInputTypeString = Nothing
        Me.Txt_ByerName.Date_for_Database = Nothing
        Me.Txt_ByerName.Date_Tag = Nothing
        Me.Txt_ByerName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_ByerName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.Txt_ByerName.ExtraValue = ""
        Me.Txt_ByerName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ByerName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ByerName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ByerName.ForeColor = System.Drawing.Color.Black
        Me.Txt_ByerName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.Txt_ByerName.IsValidated = False
        Me.Txt_ByerName.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_ByerName.Location = New System.Drawing.Point(139, 191)
        Me.Txt_ByerName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ByerName.MandatoryField = False
        Me.Txt_ByerName.MaxDate = Nothing
        Me.Txt_ByerName.MinDate = Nothing
        Me.Txt_ByerName.Name = "Txt_ByerName"
        Me.Txt_ByerName.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.Txt_ByerName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ByerName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ByerName.RegularExpression = Nothing
        Me.Txt_ByerName.RegularExpressionErrorMessage = Nothing
        Me.Txt_ByerName.ShowMessage = False
        Me.Txt_ByerName.Size = New System.Drawing.Size(255, 22)
        Me.Txt_ByerName.SpacerString = ""
        Me.Txt_ByerName.TabIndex = 82224
        Me.Txt_ByerName.Tag = "BUYERNAME"
        Me.Txt_ByerName.TransparentBox = True
        Me.Txt_ByerName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 82249
        Me.Label5.Text = "Client"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(121, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 82250
        Me.Label6.Text = ":"
        '
        'PNL_View
        '
        Me.PNL_View.Controls.Add(Me.Btn_LayoutLoad)
        Me.PNL_View.Controls.Add(Me.BtnLayOutSave)
        Me.PNL_View.Controls.Add(Me.GridControl1)
        Me.PNL_View.Controls.Add(Me.btn_View_Ok)
        Me.PNL_View.Controls.Add(Me.Btn_Export_Excel)
        Me.PNL_View.Controls.Add(Me.btn_View_Print)
        Me.PNL_View.Controls.Add(Me.lbl_To)
        Me.PNL_View.Controls.Add(Me.lbl_From)
        Me.PNL_View.Controls.Add(Me.txt_To)
        Me.PNL_View.Controls.Add(Me.txt_From)
        Me.PNL_View.Location = New System.Drawing.Point(669, 141)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(170, 183)
        Me.PNL_View.TabIndex = 82246
        Me.PNL_View.TabStop = False
        Me.PNL_View.Visible = False
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(825, 20)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(119, 32)
        Me.Btn_LayoutLoad.TabIndex = 81908
        Me.Btn_LayoutLoad.Text = "Load Report"
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(702, 20)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(119, 32)
        Me.BtnLayOutSave.TabIndex = 81907
        Me.BtnLayOutSave.Text = "Save Report"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(6, 58)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1001, 570)
        Me.GridControl1.TabIndex = 81889
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FirstStage, Me.LayoutView1, Me.GridView2})
        '
        'FirstStage
        '
        Me.FirstStage.GridControl = Me.GridControl1
        Me.FirstStage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.FirstStage.Name = "FirstStage"
        Me.FirstStage.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.FirstStage.OptionsBehavior.Editable = False
        Me.FirstStage.OptionsFind.AlwaysVisible = True
        Me.FirstStage.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.FirstStage.OptionsView.ColumnAutoWidth = False
        Me.FirstStage.OptionsView.ShowAutoFilterRow = True
        Me.FirstStage.OptionsView.ShowFooter = True
        Me.FirstStage.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'LayoutView1
        '
        Me.LayoutView1.GridControl = Me.GridControl1
        Me.LayoutView1.Name = "LayoutView1"
        Me.LayoutView1.OptionsBehavior.Editable = False
        Me.LayoutView1.OptionsFind.AlwaysVisible = True
        Me.LayoutView1.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Shade", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Nothing, "Balance Stock :{0}")})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'btn_View_Ok
        '
        Me.btn_View_Ok.BackColor = System.Drawing.SystemColors.Menu
        Me.btn_View_Ok.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_View_Ok.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_View_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_View_Ok.Location = New System.Drawing.Point(441, 19)
        Me.btn_View_Ok.Name = "btn_View_Ok"
        Me.btn_View_Ok.Size = New System.Drawing.Size(74, 35)
        Me.btn_View_Ok.TabIndex = 81777
        Me.btn_View_Ok.Text = "Ok"
        Me.btn_View_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_View_Ok.UseVisualStyleBackColor = False
        '
        'Btn_Export_Excel
        '
        Me.Btn_Export_Excel.BackColor = System.Drawing.SystemColors.Menu
        Me.Btn_Export_Excel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Export_Excel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Btn_Export_Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Export_Excel.Location = New System.Drawing.Point(608, 18)
        Me.Btn_Export_Excel.Name = "Btn_Export_Excel"
        Me.Btn_Export_Excel.Size = New System.Drawing.Size(90, 37)
        Me.Btn_Export_Excel.TabIndex = 81779
        Me.Btn_Export_Excel.Text = "Export"
        Me.Btn_Export_Excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Export_Excel.UseVisualStyleBackColor = False
        '
        'btn_View_Print
        '
        Me.btn_View_Print.BackColor = System.Drawing.SystemColors.Menu
        Me.btn_View_Print.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_View_Print.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn_View_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_View_Print.Location = New System.Drawing.Point(521, 18)
        Me.btn_View_Print.Name = "btn_View_Print"
        Me.btn_View_Print.Size = New System.Drawing.Size(81, 36)
        Me.btn_View_Print.TabIndex = 81778
        Me.btn_View_Print.Text = "Print"
        Me.btn_View_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_View_Print.UseVisualStyleBackColor = False
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.Location = New System.Drawing.Point(200, 30)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 81385
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.Location = New System.Drawing.Point(19, 30)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 81384
        Me.lbl_From.Text = "Date From:"
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
        Me.txt_To.EnterFocusColor = System.Drawing.Color.White
        Me.txt_To.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_To.ExtraValue = ""
        Me.txt_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_To.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_To.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_To.ForeColor = System.Drawing.Color.Black
        Me.txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_To.IsValidated = False
        Me.txt_To.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_To.Location = New System.Drawing.Point(266, 27)
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
        Me.txt_To.Size = New System.Drawing.Size(95, 22)
        Me.txt_To.SpacerString = ""
        Me.txt_To.TabIndex = 81378
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
        Me.txt_From.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_From.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_From.Check_End_Date_Value_FY = "YES"
        Me.txt_From.Check_Start_Date_Value_FY = "YES"
        Me.txt_From.ClearField = True
        Me.txt_From.CustomInputTypeString = Nothing
        Me.txt_From.Date_for_Database = Nothing
        Me.txt_From.Date_Tag = Nothing
        Me.txt_From.EnterFocusColor = System.Drawing.Color.White
        Me.txt_From.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_From.ExtraValue = ""
        Me.txt_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_From.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_From.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_From.ForeColor = System.Drawing.Color.Black
        Me.txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_From.IsValidated = False
        Me.txt_From.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txt_From.Location = New System.Drawing.Point(102, 27)
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
        Me.txt_From.Size = New System.Drawing.Size(95, 22)
        Me.txt_From.SpacerString = ""
        Me.txt_From.TabIndex = 81377
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(121, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 14)
        Me.Label12.TabIndex = 82239
        Me.Label12.Text = ":"
        '
        'txtEntryNo
        '
        Me.txtEntryNo._AllowSpace = True
        Me.txtEntryNo.AcceptsReturn = True
        Me.txtEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtEntryNo.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntryNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntryNo.Check_End_Date_Value_FY = "YES"
        Me.txtEntryNo.Check_Start_Date_Value_FY = "YES"
        Me.txtEntryNo.ClearField = True
        Me.txtEntryNo.CustomInputTypeString = Nothing
        Me.txtEntryNo.Date_for_Database = Nothing
        Me.txtEntryNo.Date_Tag = Nothing
        Me.txtEntryNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtEntryNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtEntryNo.ExtraValue = ""
        Me.txtEntryNo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txtEntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txtEntryNo.ForeColor = System.Drawing.Color.Black
        Me.txtEntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtEntryNo.IsValidated = False
        Me.txtEntryNo.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtEntryNo.Location = New System.Drawing.Point(139, 6)
        Me.txtEntryNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtEntryNo.MandatoryField = False
        Me.txtEntryNo.MaxDate = Nothing
        Me.txtEntryNo.MinDate = Nothing
        Me.txtEntryNo.Name = "txtEntryNo"
        Me.txtEntryNo.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtEntryNo.RegularExpression = Nothing
        Me.txtEntryNo.RegularExpressionErrorMessage = Nothing
        Me.txtEntryNo.ShowMessage = False
        Me.txtEntryNo.Size = New System.Drawing.Size(98, 24)
        Me.txtEntryNo.SpacerString = ""
        Me.txtEntryNo.TabIndex = 82217
        Me.txtEntryNo.Tag = "ENTRYNO"
        Me.txtEntryNo.TransparentBox = True
        Me.txtEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 14)
        Me.Label13.TabIndex = 82240
        Me.Label13.Text = "Entry No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 82238
        Me.Label7.Text = "Job No."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(121, 361)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(12, 14)
        Me.Label24.TabIndex = 82237
        Me.Label24.Text = ":"
        '
        'txtHeader_Remark
        '
        Me.txtHeader_Remark._AllowSpace = True
        Me.txtHeader_Remark.AcceptsReturn = True
        Me.txtHeader_Remark.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtHeader_Remark.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtHeader_Remark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeader_Remark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeader_Remark.Check_End_Date_Value_FY = "YES"
        Me.txtHeader_Remark.Check_Start_Date_Value_FY = "YES"
        Me.txtHeader_Remark.ClearField = True
        Me.txtHeader_Remark.CustomInputTypeString = Nothing
        Me.txtHeader_Remark.Date_for_Database = Nothing
        Me.txtHeader_Remark.Date_Tag = Nothing
        Me.txtHeader_Remark.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtHeader_Remark.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtHeader_Remark.ExtraValue = ""
        Me.txtHeader_Remark.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeader_Remark.FontFocusColor = System.Drawing.Color.Blue
        Me.txtHeader_Remark.FontLeaveColor = System.Drawing.Color.Black
        Me.txtHeader_Remark.ForeColor = System.Drawing.Color.Black
        Me.txtHeader_Remark.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtHeader_Remark.IsValidated = False
        Me.txtHeader_Remark.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtHeader_Remark.Location = New System.Drawing.Point(139, 357)
        Me.txtHeader_Remark.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtHeader_Remark.MandatoryField = False
        Me.txtHeader_Remark.MaxDate = Nothing
        Me.txtHeader_Remark.MinDate = Nothing
        Me.txtHeader_Remark.Name = "txtHeader_Remark"
        Me.txtHeader_Remark.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtHeader_Remark.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtHeader_Remark.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtHeader_Remark.RegularExpression = Nothing
        Me.txtHeader_Remark.RegularExpressionErrorMessage = Nothing
        Me.txtHeader_Remark.ShowMessage = False
        Me.txtHeader_Remark.Size = New System.Drawing.Size(251, 22)
        Me.txtHeader_Remark.SpacerString = ""
        Me.txtHeader_Remark.TabIndex = 82229
        Me.txtHeader_Remark.Tag = "HEADERREMARK"
        Me.txtHeader_Remark.TransparentBox = True
        Me.txtHeader_Remark.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(5, 361)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(90, 14)
        Me.Label23.TabIndex = 82236
        Me.Label23.Text = "Product Size"
        '
        'txtAccountName
        '
        Me.txtAccountName._AllowSpace = True
        Me.txtAccountName.AcceptsReturn = True
        Me.txtAccountName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtAccountName.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAccountName.Check_End_Date_Value_FY = "YES"
        Me.txtAccountName.Check_Start_Date_Value_FY = "YES"
        Me.txtAccountName.ClearField = True
        Me.txtAccountName.CustomInputTypeString = Nothing
        Me.txtAccountName.Date_for_Database = Nothing
        Me.txtAccountName.Date_Tag = Nothing
        Me.txtAccountName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtAccountName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.txtAccountName.ExtraValue = ""
        Me.txtAccountName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtAccountName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtAccountName.ForeColor = System.Drawing.Color.Black
        Me.txtAccountName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.txtAccountName.IsValidated = False
        Me.txtAccountName.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtAccountName.Location = New System.Drawing.Point(139, 139)
        Me.txtAccountName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtAccountName.MandatoryField = False
        Me.txtAccountName.MaxDate = Nothing
        Me.txtAccountName.MinDate = Nothing
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtAccountName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtAccountName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtAccountName.RegularExpression = Nothing
        Me.txtAccountName.RegularExpressionErrorMessage = Nothing
        Me.txtAccountName.ShowMessage = False
        Me.txtAccountName.Size = New System.Drawing.Size(255, 22)
        Me.txtAccountName.SpacerString = ""
        Me.txtAccountName.TabIndex = 82222
        Me.txtAccountName.Tag = "ACCOUNTNAME"
        Me.txtAccountName.TransparentBox = True
        Me.txtAccountName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 82234
        Me.Label3.Text = "Printer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 82235
        Me.Label4.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(121, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 82233
        Me.Label2.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(121, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 14)
        Me.Label20.TabIndex = 82231
        Me.Label20.Text = ":"
        '
        'txtChallanNo
        '
        Me.txtChallanNo._AllowSpace = True
        Me.txtChallanNo.AcceptsReturn = True
        Me.txtChallanNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallanNo.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallanNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChallanNo.Check_End_Date_Value_FY = "YES"
        Me.txtChallanNo.Check_Start_Date_Value_FY = "YES"
        Me.txtChallanNo.ClearField = True
        Me.txtChallanNo.CustomInputTypeString = Nothing
        Me.txtChallanNo.Date_for_Database = Nothing
        Me.txtChallanNo.Date_Tag = Nothing
        Me.txtChallanNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtChallanNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtChallanNo.ExtraValue = ""
        Me.txtChallanNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallanNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txtChallanNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txtChallanNo.ForeColor = System.Drawing.Color.Black
        Me.txtChallanNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtChallanNo.IsValidated = False
        Me.txtChallanNo.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChallanNo.Location = New System.Drawing.Point(139, 32)
        Me.txtChallanNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtChallanNo.MandatoryField = False
        Me.txtChallanNo.MaxDate = Nothing
        Me.txtChallanNo.MinDate = Nothing
        Me.txtChallanNo.Name = "txtChallanNo"
        Me.txtChallanNo.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChallanNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallanNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallanNo.RegularExpression = Nothing
        Me.txtChallanNo.RegularExpressionErrorMessage = Nothing
        Me.txtChallanNo.ShowMessage = False
        Me.txtChallanNo.Size = New System.Drawing.Size(98, 22)
        Me.txtChallanNo.SpacerString = ""
        Me.txtChallanNo.TabIndex = 82218
        Me.txtChallanNo.Tag = "CHALLANNO"
        Me.txtChallanNo.TransparentBox = True
        Me.txtChallanNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtChallanDate
        '
        Me.txtChallanDate._AllowSpace = True
        Me.txtChallanDate.AcceptsReturn = True
        Me.txtChallanDate.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallanDate.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChallanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallanDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChallanDate.Check_End_Date_Value_FY = "YES"
        Me.txtChallanDate.Check_Start_Date_Value_FY = "YES"
        Me.txtChallanDate.ClearField = True
        Me.txtChallanDate.CustomInputTypeString = Nothing
        Me.txtChallanDate.Date_for_Database = Nothing
        Me.txtChallanDate.Date_Tag = "F_CHALLANDATE"
        Me.txtChallanDate.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtChallanDate.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtChallanDate.ExtraValue = ""
        Me.txtChallanDate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallanDate.FontFocusColor = System.Drawing.Color.Blue
        Me.txtChallanDate.FontLeaveColor = System.Drawing.Color.Black
        Me.txtChallanDate.ForeColor = System.Drawing.Color.Black
        Me.txtChallanDate.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txtChallanDate.IsValidated = False
        Me.txtChallanDate.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChallanDate.Location = New System.Drawing.Point(139, 56)
        Me.txtChallanDate.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtChallanDate.MandatoryField = False
        Me.txtChallanDate.MaxDate = Nothing
        Me.txtChallanDate.MaxLength = 6
        Me.txtChallanDate.MinDate = Nothing
        Me.txtChallanDate.Name = "txtChallanDate"
        Me.txtChallanDate.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtChallanDate.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallanDate.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallanDate.RegularExpression = Nothing
        Me.txtChallanDate.RegularExpressionErrorMessage = Nothing
        Me.txtChallanDate.ShowMessage = False
        Me.txtChallanDate.Size = New System.Drawing.Size(98, 22)
        Me.txtChallanDate.SpacerString = ""
        Me.txtChallanDate.TabIndex = 82219
        Me.txtChallanDate.Tag = "CHALLANDATE"
        Me.txtChallanDate.Text = "  /  /    "
        Me.txtChallanDate.TransparentBox = True
        Me.txtChallanDate.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 82232
        Me.Label1.Text = "Job Date"
        '
        'UC_Buttons1
        '
        Me.UC_Buttons1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_Buttons1.Location = New System.Drawing.Point(-5, 462)
        Me.UC_Buttons1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_Buttons1.Name = "UC_Buttons1"
        Me.UC_Buttons1.Size = New System.Drawing.Size(1004, 43)
        Me.UC_Buttons1.TabIndex = 82383
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(121, 81)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(12, 14)
        Me.Label25.TabIndex = 82386
        Me.Label25.Text = ":"
        '
        'txtpaperform
        '
        Me.txtpaperform._AllowSpace = True
        Me.txtpaperform.AcceptsReturn = True
        Me.txtpaperform.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtpaperform.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtpaperform.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpaperform.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpaperform.Check_End_Date_Value_FY = "YES"
        Me.txtpaperform.Check_Start_Date_Value_FY = "YES"
        Me.txtpaperform.ClearField = True
        Me.txtpaperform.CustomInputTypeString = Nothing
        Me.txtpaperform.Date_for_Database = Nothing
        Me.txtpaperform.Date_Tag = Nothing
        Me.txtpaperform.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtpaperform.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtpaperform.ExtraValue = ""
        Me.txtpaperform.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpaperform.FontFocusColor = System.Drawing.Color.Blue
        Me.txtpaperform.FontLeaveColor = System.Drawing.Color.Black
        Me.txtpaperform.ForeColor = System.Drawing.Color.Black
        Me.txtpaperform.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txtpaperform.IsValidated = False
        Me.txtpaperform.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtpaperform.Location = New System.Drawing.Point(139, 78)
        Me.txtpaperform.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtpaperform.MandatoryField = False
        Me.txtpaperform.MaxDate = Nothing
        Me.txtpaperform.MinDate = Nothing
        Me.txtpaperform.Name = "txtpaperform"
        Me.txtpaperform.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtpaperform.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtpaperform.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txtpaperform.RegularExpression = Nothing
        Me.txtpaperform.RegularExpressionErrorMessage = Nothing
        Me.txtpaperform.ShowMessage = False
        Me.txtpaperform.Size = New System.Drawing.Size(251, 22)
        Me.txtpaperform.SpacerString = ""
        Me.txtpaperform.TabIndex = 82220
        Me.txtpaperform.Tag = "OP4"
        Me.txtpaperform.TransparentBox = True
        Me.txtpaperform.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(5, 80)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(84, 14)
        Me.Label26.TabIndex = 82385
        Me.Label26.Text = "Paper Form"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(121, 112)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(12, 14)
        Me.Label27.TabIndex = 82389
        Me.Label27.Text = ":"
        '
        'txtpaper
        '
        Me.txtpaper._AllowSpace = True
        Me.txtpaper.AcceptsReturn = True
        Me.txtpaper.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtpaper.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtpaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpaper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpaper.Check_End_Date_Value_FY = "YES"
        Me.txtpaper.Check_Start_Date_Value_FY = "YES"
        Me.txtpaper.ClearField = True
        Me.txtpaper.CustomInputTypeString = Nothing
        Me.txtpaper.Date_for_Database = Nothing
        Me.txtpaper.Date_Tag = Nothing
        Me.txtpaper.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtpaper.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtpaper.ExtraValue = ""
        Me.txtpaper.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpaper.FontFocusColor = System.Drawing.Color.Blue
        Me.txtpaper.FontLeaveColor = System.Drawing.Color.Black
        Me.txtpaper.ForeColor = System.Drawing.Color.Black
        Me.txtpaper.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txtpaper.IsValidated = False
        Me.txtpaper.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtpaper.Location = New System.Drawing.Point(139, 108)
        Me.txtpaper.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtpaper.MandatoryField = False
        Me.txtpaper.MaxDate = Nothing
        Me.txtpaper.MinDate = Nothing
        Me.txtpaper.Name = "txtpaper"
        Me.txtpaper.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtpaper.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtpaper.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txtpaper.RegularExpression = Nothing
        Me.txtpaper.RegularExpressionErrorMessage = Nothing
        Me.txtpaper.ShowMessage = False
        Me.txtpaper.Size = New System.Drawing.Size(255, 22)
        Me.txtpaper.SpacerString = ""
        Me.txtpaper.TabIndex = 82221
        Me.txtpaper.Tag = "OP5"
        Me.txtpaper.TransparentBox = True
        Me.txtpaper.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(5, 112)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 14)
        Me.Label28.TabIndex = 82388
        Me.Label28.Text = "Paper"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(121, 415)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(12, 14)
        Me.Label29.TabIndex = 82392
        Me.Label29.Text = ":"
        '
        'txtMachinesize
        '
        Me.txtMachinesize._AllowSpace = True
        Me.txtMachinesize.AcceptsReturn = True
        Me.txtMachinesize.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtMachinesize.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtMachinesize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachinesize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMachinesize.Check_End_Date_Value_FY = "YES"
        Me.txtMachinesize.Check_Start_Date_Value_FY = "YES"
        Me.txtMachinesize.ClearField = True
        Me.txtMachinesize.CustomInputTypeString = Nothing
        Me.txtMachinesize.Date_for_Database = Nothing
        Me.txtMachinesize.Date_Tag = Nothing
        Me.txtMachinesize.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtMachinesize.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtMachinesize.ExtraValue = ""
        Me.txtMachinesize.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMachinesize.FontFocusColor = System.Drawing.Color.Blue
        Me.txtMachinesize.FontLeaveColor = System.Drawing.Color.Black
        Me.txtMachinesize.ForeColor = System.Drawing.Color.Black
        Me.txtMachinesize.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txtMachinesize.IsValidated = False
        Me.txtMachinesize.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtMachinesize.Location = New System.Drawing.Point(139, 411)
        Me.txtMachinesize.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtMachinesize.MandatoryField = False
        Me.txtMachinesize.MaxDate = Nothing
        Me.txtMachinesize.MinDate = Nothing
        Me.txtMachinesize.Name = "txtMachinesize"
        Me.txtMachinesize.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtMachinesize.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtMachinesize.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txtMachinesize.RegularExpression = Nothing
        Me.txtMachinesize.RegularExpressionErrorMessage = Nothing
        Me.txtMachinesize.ShowMessage = False
        Me.txtMachinesize.Size = New System.Drawing.Size(254, 22)
        Me.txtMachinesize.SpacerString = ""
        Me.txtMachinesize.TabIndex = 82231
        Me.txtMachinesize.Tag = "OP7"
        Me.txtMachinesize.TransparentBox = True
        Me.txtMachinesize.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(5, 415)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(93, 14)
        Me.Label30.TabIndex = 82391
        Me.Label30.Text = "Machine Size"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(121, 439)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(12, 14)
        Me.Label31.TabIndex = 82395
        Me.Label31.Text = ":"
        '
        'txtRemark
        '
        Me.txtRemark._AllowSpace = True
        Me.txtRemark.AcceptsReturn = True
        Me.txtRemark.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtRemark.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemark.Check_End_Date_Value_FY = "YES"
        Me.txtRemark.Check_Start_Date_Value_FY = "YES"
        Me.txtRemark.ClearField = True
        Me.txtRemark.CustomInputTypeString = Nothing
        Me.txtRemark.Date_for_Database = Nothing
        Me.txtRemark.Date_Tag = Nothing
        Me.txtRemark.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtRemark.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtRemark.ExtraValue = ""
        Me.txtRemark.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.FontFocusColor = System.Drawing.Color.Blue
        Me.txtRemark.FontLeaveColor = System.Drawing.Color.Black
        Me.txtRemark.ForeColor = System.Drawing.Color.Black
        Me.txtRemark.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtRemark.IsValidated = False
        Me.txtRemark.LeaveFocusColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRemark.Location = New System.Drawing.Point(139, 435)
        Me.txtRemark.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtRemark.MandatoryField = False
        Me.txtRemark.MaxDate = Nothing
        Me.txtRemark.MinDate = Nothing
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.NormalBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRemark.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtRemark.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtRemark.RegularExpression = Nothing
        Me.txtRemark.RegularExpressionErrorMessage = Nothing
        Me.txtRemark.ShowMessage = False
        Me.txtRemark.Size = New System.Drawing.Size(255, 22)
        Me.txtRemark.SpacerString = ""
        Me.txtRemark.TabIndex = 82232
        Me.txtRemark.Tag = "OP8"
        Me.txtRemark.TransparentBox = True
        Me.txtRemark.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(5, 439)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(58, 14)
        Me.Label32.TabIndex = 82394
        Me.Label32.Text = "Remark"
        '
        'JobCardPlanning
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(925, 506)
        Me.Controls.Add(Me.PNL_View)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtMachinesize)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtpaper)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtpaperform)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.UC_Buttons1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Txt_PrintQty)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Txt_AcoFName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Txt_LaminDrip)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Txt_Size)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Txt_JobSize)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt_CuttingSize)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txt_ByerName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtEntryNo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtHeader_Remark)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtChallanNo)
        Me.Controls.Add(Me.txtChallanDate)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "JobCardPlanning"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Card Planning"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNL_View.ResumeLayout(False)
        Me.PNL_View.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label21 As Label
    Friend WithEvents Txt_PrintQty As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Txt_AcoFName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Txt_LaminDrip As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Txt_Size As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Txt_JobSize As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Txt_CuttingSize As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_ByerName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PNL_View As GroupBox
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_View_Ok As Button
    Friend WithEvents Btn_Export_Excel As Button
    Friend WithEvents btn_View_Print As Button
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label13 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtHeader_Remark As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtAccountName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtChallanNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtChallanDate As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents UC_Buttons1 As UC_Buttons
    Friend WithEvents Label25 As Label
    Friend WithEvents txtpaperform As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtpaper As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txtMachinesize As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtRemark As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label32 As Label
End Class
