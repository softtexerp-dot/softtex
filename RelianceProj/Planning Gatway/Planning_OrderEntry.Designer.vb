<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Planning_OrderEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Planning_OrderEntry))
        Me.Txt_RollingCharge = New ctl_TextBox.ctl_TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Ttx_CutMtrs = New ctl_TextBox.ctl_TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txt_Loom_Type = New ctl_TextBox.ctl_TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txt_Extra_Chg = New ctl_TextBox.ctl_TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txt_Mending_Chg = New ctl_TextBox.ctl_TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_No_Of_Beam = New ctl_TextBox.ctl_TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txt_EntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtBookName = New ctl_TextBox.ctl_TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txt_PartyName = New ctl_TextBox.ctl_TextBox()
        Me.lll = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txt_Mtr_Weight = New ctl_TextBox.ctl_TextBox()
        Me.txt_No_Of_Set = New ctl_TextBox.ctl_TextBox()
        Me.txt_Pick_Rate = New ctl_TextBox.ctl_TextBox()
        Me.txtChallanDate = New ctl_TextBox.ctl_TextBox()
        Me.txt_OfferNo = New ctl_TextBox.ctl_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Moredetail = New ctl_TextBox.ctl_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_HeaderRemark = New ctl_TextBox.ctl_TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.LblHeader = New System.Windows.Forms.Label()
        Me.PNL_View = New System.Windows.Forms.Panel()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Txt_PlanningNo = New ctl_TextBox.ctl_TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModify = New DevExpress.XtraEditors.SimpleButton()
        Me.But_export = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.PNL_View.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_RollingCharge
        '
        Me.Txt_RollingCharge._AllowSpace = True
        Me.Txt_RollingCharge.AcceptsReturn = True
        Me.Txt_RollingCharge.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_RollingCharge.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_RollingCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_RollingCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_RollingCharge.Check_End_Date_Value_FY = "YES"
        Me.Txt_RollingCharge.Check_Start_Date_Value_FY = "YES"
        Me.Txt_RollingCharge.ClearField = True
        Me.Txt_RollingCharge.CustomInputTypeString = Nothing
        Me.Txt_RollingCharge.Date_for_Database = Nothing
        Me.Txt_RollingCharge.Date_Tag = Nothing
        Me.Txt_RollingCharge.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_RollingCharge.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_RollingCharge.ExtraValue = ""
        Me.Txt_RollingCharge.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RollingCharge.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_RollingCharge.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_RollingCharge.ForeColor = System.Drawing.Color.Black
        Me.Txt_RollingCharge.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.Txt_RollingCharge.IsValidated = False
        Me.Txt_RollingCharge.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_RollingCharge.Location = New System.Drawing.Point(622, 217)
        Me.Txt_RollingCharge.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_RollingCharge.MandatoryField = False
        Me.Txt_RollingCharge.MaxDate = Nothing
        Me.Txt_RollingCharge.MaxLength = 70
        Me.Txt_RollingCharge.MinDate = Nothing
        Me.Txt_RollingCharge.Name = "Txt_RollingCharge"
        Me.Txt_RollingCharge.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_RollingCharge.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_RollingCharge.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.Txt_RollingCharge.RegularExpression = Nothing
        Me.Txt_RollingCharge.RegularExpressionErrorMessage = Nothing
        Me.Txt_RollingCharge.ShowMessage = False
        Me.Txt_RollingCharge.Size = New System.Drawing.Size(106, 22)
        Me.Txt_RollingCharge.SpacerString = ""
        Me.Txt_RollingCharge.TabIndex = 28
        Me.Txt_RollingCharge.Tag = "RDVALUE"
        Me.Txt_RollingCharge.TransparentBox = True
        Me.Txt_RollingCharge.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(609, 221)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(12, 14)
        Me.Label71.TabIndex = 81971
        Me.Label71.Text = ":"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(457, 221)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(156, 14)
        Me.Label72.TabIndex = 81970
        Me.Label72.Text = "Rolling Charges (P/M)"
        '
        'Ttx_CutMtrs
        '
        Me.Ttx_CutMtrs._AllowSpace = True
        Me.Ttx_CutMtrs.AcceptsReturn = True
        Me.Ttx_CutMtrs.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Ttx_CutMtrs.BackColor = System.Drawing.Color.GhostWhite
        Me.Ttx_CutMtrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ttx_CutMtrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ttx_CutMtrs.Check_End_Date_Value_FY = "YES"
        Me.Ttx_CutMtrs.Check_Start_Date_Value_FY = "YES"
        Me.Ttx_CutMtrs.ClearField = True
        Me.Ttx_CutMtrs.CustomInputTypeString = Nothing
        Me.Ttx_CutMtrs.Date_for_Database = Nothing
        Me.Ttx_CutMtrs.Date_Tag = Nothing
        Me.Ttx_CutMtrs.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Ttx_CutMtrs.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Ttx_CutMtrs.ExtraValue = ""
        Me.Ttx_CutMtrs.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ttx_CutMtrs.FontFocusColor = System.Drawing.Color.Blue
        Me.Ttx_CutMtrs.FontLeaveColor = System.Drawing.Color.Black
        Me.Ttx_CutMtrs.ForeColor = System.Drawing.Color.Black
        Me.Ttx_CutMtrs.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.Ttx_CutMtrs.IsValidated = False
        Me.Ttx_CutMtrs.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Ttx_CutMtrs.Location = New System.Drawing.Point(168, 153)
        Me.Ttx_CutMtrs.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Ttx_CutMtrs.MandatoryField = False
        Me.Ttx_CutMtrs.MaxDate = Nothing
        Me.Ttx_CutMtrs.MaxLength = 70
        Me.Ttx_CutMtrs.MinDate = Nothing
        Me.Ttx_CutMtrs.Name = "Ttx_CutMtrs"
        Me.Ttx_CutMtrs.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Ttx_CutMtrs.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Ttx_CutMtrs.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.Ttx_CutMtrs.RegularExpression = Nothing
        Me.Ttx_CutMtrs.RegularExpressionErrorMessage = Nothing
        Me.Ttx_CutMtrs.ShowMessage = False
        Me.Ttx_CutMtrs.Size = New System.Drawing.Size(106, 22)
        Me.Ttx_CutMtrs.SpacerString = ""
        Me.Ttx_CutMtrs.TabIndex = 5
        Me.Ttx_CutMtrs.Tag = "QTYMTR"
        Me.Ttx_CutMtrs.TransparentBox = True
        Me.Ttx_CutMtrs.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(145, 157)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(12, 14)
        Me.Label62.TabIndex = 81969
        Me.Label62.Text = ":"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.Location = New System.Drawing.Point(16, 163)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(36, 14)
        Me.Label63.TabIndex = 81968
        Me.Label63.Text = "Mtrs"
        '
        'txt_Loom_Type
        '
        Me.txt_Loom_Type._AllowSpace = True
        Me.txt_Loom_Type.AcceptsReturn = True
        Me.txt_Loom_Type.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Loom_Type.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_Loom_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Loom_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Loom_Type.Check_End_Date_Value_FY = "YES"
        Me.txt_Loom_Type.Check_Start_Date_Value_FY = "YES"
        Me.txt_Loom_Type.ClearField = True
        Me.txt_Loom_Type.CustomInputTypeString = Nothing
        Me.txt_Loom_Type.Date_for_Database = Nothing
        Me.txt_Loom_Type.Date_Tag = Nothing
        Me.txt_Loom_Type.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Loom_Type.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Loom_Type.ExtraValue = ""
        Me.txt_Loom_Type.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Loom_Type.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Loom_Type.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Loom_Type.ForeColor = System.Drawing.Color.Black
        Me.txt_Loom_Type.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.txt_Loom_Type.IsValidated = False
        Me.txt_Loom_Type.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_Loom_Type.Location = New System.Drawing.Point(168, 228)
        Me.txt_Loom_Type.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Loom_Type.MandatoryField = False
        Me.txt_Loom_Type.MaxDate = Nothing
        Me.txt_Loom_Type.MaxLength = 70
        Me.txt_Loom_Type.MinDate = Nothing
        Me.txt_Loom_Type.Name = "txt_Loom_Type"
        Me.txt_Loom_Type.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_Loom_Type.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Loom_Type.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Loom_Type.RegularExpression = Nothing
        Me.txt_Loom_Type.RegularExpressionErrorMessage = Nothing
        Me.txt_Loom_Type.ShowMessage = False
        Me.txt_Loom_Type.Size = New System.Drawing.Size(106, 22)
        Me.txt_Loom_Type.SpacerString = "SINGLE,DOUBLE, S-AND-D "
        Me.txt_Loom_Type.TabIndex = 8
        Me.txt_Loom_Type.Tag = "LOOM_TYPE"
        Me.txt_Loom_Type.Text = "SINGLE"
        Me.txt_Loom_Type.TransparentBox = True
        Me.txt_Loom_Type.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(16, 232)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(79, 14)
        Me.Label53.TabIndex = 81967
        Me.Label53.Text = "Loom Type"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(145, 232)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(12, 14)
        Me.Label54.TabIndex = 81966
        Me.Label54.Text = ":"
        '
        'txt_Extra_Chg
        '
        Me.txt_Extra_Chg._AllowSpace = True
        Me.txt_Extra_Chg.AcceptsReturn = True
        Me.txt_Extra_Chg.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Extra_Chg.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_Extra_Chg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Extra_Chg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Extra_Chg.Check_End_Date_Value_FY = "YES"
        Me.txt_Extra_Chg.Check_Start_Date_Value_FY = "YES"
        Me.txt_Extra_Chg.ClearField = True
        Me.txt_Extra_Chg.CustomInputTypeString = Nothing
        Me.txt_Extra_Chg.Date_for_Database = Nothing
        Me.txt_Extra_Chg.Date_Tag = Nothing
        Me.txt_Extra_Chg.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Extra_Chg.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Extra_Chg.ExtraValue = ""
        Me.txt_Extra_Chg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Extra_Chg.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Extra_Chg.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Extra_Chg.ForeColor = System.Drawing.Color.Black
        Me.txt_Extra_Chg.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_Extra_Chg.IsValidated = False
        Me.txt_Extra_Chg.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_Extra_Chg.Location = New System.Drawing.Point(168, 202)
        Me.txt_Extra_Chg.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Extra_Chg.MandatoryField = False
        Me.txt_Extra_Chg.MaxDate = Nothing
        Me.txt_Extra_Chg.MaxLength = 70
        Me.txt_Extra_Chg.MinDate = Nothing
        Me.txt_Extra_Chg.Name = "txt_Extra_Chg"
        Me.txt_Extra_Chg.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_Extra_Chg.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Extra_Chg.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txt_Extra_Chg.RegularExpression = Nothing
        Me.txt_Extra_Chg.RegularExpressionErrorMessage = Nothing
        Me.txt_Extra_Chg.ShowMessage = False
        Me.txt_Extra_Chg.Size = New System.Drawing.Size(106, 22)
        Me.txt_Extra_Chg.SpacerString = ""
        Me.txt_Extra_Chg.TabIndex = 7
        Me.txt_Extra_Chg.Tag = "EXTRA_CHG"
        Me.txt_Extra_Chg.TransparentBox = True
        Me.txt_Extra_Chg.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(145, 206)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(12, 14)
        Me.Label48.TabIndex = 81965
        Me.Label48.Text = ":"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(16, 206)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(100, 14)
        Me.Label49.TabIndex = 81964
        Me.Label49.Text = "Extra Charges"
        '
        'txt_Mending_Chg
        '
        Me.txt_Mending_Chg._AllowSpace = True
        Me.txt_Mending_Chg.AcceptsReturn = True
        Me.txt_Mending_Chg.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Mending_Chg.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_Mending_Chg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Mending_Chg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mending_Chg.Check_End_Date_Value_FY = "YES"
        Me.txt_Mending_Chg.Check_Start_Date_Value_FY = "YES"
        Me.txt_Mending_Chg.ClearField = True
        Me.txt_Mending_Chg.CustomInputTypeString = Nothing
        Me.txt_Mending_Chg.Date_for_Database = Nothing
        Me.txt_Mending_Chg.Date_Tag = Nothing
        Me.txt_Mending_Chg.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Mending_Chg.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Mending_Chg.ExtraValue = ""
        Me.txt_Mending_Chg.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mending_Chg.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Mending_Chg.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Mending_Chg.ForeColor = System.Drawing.Color.Black
        Me.txt_Mending_Chg.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_Mending_Chg.IsValidated = False
        Me.txt_Mending_Chg.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_Mending_Chg.Location = New System.Drawing.Point(622, 191)
        Me.txt_Mending_Chg.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Mending_Chg.MandatoryField = False
        Me.txt_Mending_Chg.MaxDate = Nothing
        Me.txt_Mending_Chg.MaxLength = 70
        Me.txt_Mending_Chg.MinDate = Nothing
        Me.txt_Mending_Chg.Name = "txt_Mending_Chg"
        Me.txt_Mending_Chg.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_Mending_Chg.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Mending_Chg.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txt_Mending_Chg.RegularExpression = Nothing
        Me.txt_Mending_Chg.RegularExpressionErrorMessage = Nothing
        Me.txt_Mending_Chg.ShowMessage = False
        Me.txt_Mending_Chg.Size = New System.Drawing.Size(106, 22)
        Me.txt_Mending_Chg.SpacerString = ""
        Me.txt_Mending_Chg.TabIndex = 27
        Me.txt_Mending_Chg.Tag = "MENDING_CHG"
        Me.txt_Mending_Chg.TransparentBox = True
        Me.txt_Mending_Chg.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(609, 195)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(12, 14)
        Me.Label19.TabIndex = 81963
        Me.Label19.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(457, 195)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(108, 14)
        Me.Label24.TabIndex = 81962
        Me.Label24.Text = "Mending (P/M)"
        '
        'txt_No_Of_Beam
        '
        Me.txt_No_Of_Beam._AllowSpace = True
        Me.txt_No_Of_Beam.AcceptsReturn = True
        Me.txt_No_Of_Beam.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_No_Of_Beam.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_No_Of_Beam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_No_Of_Beam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_No_Of_Beam.Check_End_Date_Value_FY = "YES"
        Me.txt_No_Of_Beam.Check_Start_Date_Value_FY = "YES"
        Me.txt_No_Of_Beam.ClearField = True
        Me.txt_No_Of_Beam.CustomInputTypeString = Nothing
        Me.txt_No_Of_Beam.Date_for_Database = Nothing
        Me.txt_No_Of_Beam.Date_Tag = Nothing
        Me.txt_No_Of_Beam.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_No_Of_Beam.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_No_Of_Beam.ExtraValue = ""
        Me.txt_No_Of_Beam.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_No_Of_Beam.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_No_Of_Beam.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_No_Of_Beam.ForeColor = System.Drawing.Color.Black
        Me.txt_No_Of_Beam.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_No_Of_Beam.IsValidated = False
        Me.txt_No_Of_Beam.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_No_Of_Beam.Location = New System.Drawing.Point(622, 163)
        Me.txt_No_Of_Beam.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_No_Of_Beam.MandatoryField = False
        Me.txt_No_Of_Beam.MaxDate = Nothing
        Me.txt_No_Of_Beam.MaxLength = 70
        Me.txt_No_Of_Beam.MinDate = Nothing
        Me.txt_No_Of_Beam.Name = "txt_No_Of_Beam"
        Me.txt_No_Of_Beam.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_No_Of_Beam.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_No_Of_Beam.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_No_Of_Beam.RegularExpression = Nothing
        Me.txt_No_Of_Beam.RegularExpressionErrorMessage = Nothing
        Me.txt_No_Of_Beam.ShowMessage = False
        Me.txt_No_Of_Beam.Size = New System.Drawing.Size(98, 22)
        Me.txt_No_Of_Beam.SpacerString = ""
        Me.txt_No_Of_Beam.TabIndex = 26
        Me.txt_No_Of_Beam.Tag = "NO_OF_BEAM"
        Me.txt_No_Of_Beam.TransparentBox = True
        Me.txt_No_Of_Beam.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(609, 167)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(12, 14)
        Me.Label46.TabIndex = 81961
        Me.Label46.Text = ":"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(457, 167)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(93, 14)
        Me.Label47.TabIndex = 81960
        Me.Label47.Text = "No Of Beams"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(17, 81)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(68, 14)
        Me.Label34.TabIndex = 81959
        Me.Label34.Text = "Entry No."
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(145, 81)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(12, 14)
        Me.Label38.TabIndex = 81958
        Me.Label38.Text = ":"
        '
        'txt_EntryNo
        '
        Me.txt_EntryNo._AllowSpace = True
        Me.txt_EntryNo.AcceptsReturn = True
        Me.txt_EntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_EntryNo.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_EntryNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_EntryNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_EntryNo.Check_End_Date_Value_FY = "YES"
        Me.txt_EntryNo.Check_Start_Date_Value_FY = "YES"
        Me.txt_EntryNo.ClearField = True
        Me.txt_EntryNo.CustomInputTypeString = Nothing
        Me.txt_EntryNo.Date_for_Database = Nothing
        Me.txt_EntryNo.Date_Tag = Nothing
        Me.txt_EntryNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_EntryNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_EntryNo.ExtraValue = ""
        Me.txt_EntryNo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_EntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_EntryNo.ForeColor = System.Drawing.Color.Black
        Me.txt_EntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_EntryNo.IsValidated = False
        Me.txt_EntryNo.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_EntryNo.Location = New System.Drawing.Point(168, 76)
        Me.txt_EntryNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_EntryNo.MandatoryField = False
        Me.txt_EntryNo.MaxDate = Nothing
        Me.txt_EntryNo.MinDate = Nothing
        Me.txt_EntryNo.Name = "txt_EntryNo"
        Me.txt_EntryNo.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_EntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_EntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_EntryNo.RegularExpression = Nothing
        Me.txt_EntryNo.RegularExpressionErrorMessage = Nothing
        Me.txt_EntryNo.ShowMessage = False
        Me.txt_EntryNo.Size = New System.Drawing.Size(98, 24)
        Me.txt_EntryNo.SpacerString = ""
        Me.txt_EntryNo.TabIndex = 2
        Me.txt_EntryNo.Tag = "ENTRYNO"
        Me.txt_EntryNo.TransparentBox = True
        Me.txt_EntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(145, 56)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(12, 14)
        Me.Label41.TabIndex = 81957
        Me.Label41.Text = ":"
        '
        'txtBookName
        '
        Me.txtBookName._AllowSpace = True
        Me.txtBookName.AcceptsReturn = True
        Me.txtBookName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtBookName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtBookName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBookName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBookName.Check_End_Date_Value_FY = "YES"
        Me.txtBookName.Check_Start_Date_Value_FY = "YES"
        Me.txtBookName.ClearField = True
        Me.txtBookName.CustomInputTypeString = Nothing
        Me.txtBookName.Date_for_Database = Nothing
        Me.txtBookName.Date_Tag = Nothing
        Me.txtBookName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtBookName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtBookName.ExtraValue = ""
        Me.txtBookName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtBookName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtBookName.ForeColor = System.Drawing.Color.Black
        Me.txtBookName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtBookName.IsValidated = False
        Me.txtBookName.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txtBookName.Location = New System.Drawing.Point(168, 52)
        Me.txtBookName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtBookName.MandatoryField = False
        Me.txtBookName.MaxDate = Nothing
        Me.txtBookName.MinDate = Nothing
        Me.txtBookName.Name = "txtBookName"
        Me.txtBookName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtBookName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtBookName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtBookName.RegularExpression = Nothing
        Me.txtBookName.RegularExpressionErrorMessage = Nothing
        Me.txtBookName.ShowMessage = False
        Me.txtBookName.Size = New System.Drawing.Size(272, 22)
        Me.txtBookName.SpacerString = ""
        Me.txtBookName.TabIndex = 1
        Me.txtBookName.Tag = "BOOKNAME"
        Me.txtBookName.TransparentBox = True
        Me.txtBookName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label50.Location = New System.Drawing.Point(16, 56)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(82, 14)
        Me.Label50.TabIndex = 81956
        Me.Label50.Text = "Book Name"
        '
        'txt_PartyName
        '
        Me.txt_PartyName._AllowSpace = True
        Me.txt_PartyName.AcceptsReturn = True
        Me.txt_PartyName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_PartyName.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_PartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PartyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_PartyName.Check_End_Date_Value_FY = "YES"
        Me.txt_PartyName.Check_Start_Date_Value_FY = "YES"
        Me.txt_PartyName.ClearField = True
        Me.txt_PartyName.CustomInputTypeString = Nothing
        Me.txt_PartyName.Date_for_Database = Nothing
        Me.txt_PartyName.Date_Tag = Nothing
        Me.txt_PartyName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_PartyName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_PartyName.ExtraValue = ""
        Me.txt_PartyName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PartyName.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_PartyName.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_PartyName.ForeColor = System.Drawing.Color.Black
        Me.txt_PartyName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_PartyName.IsValidated = False
        Me.txt_PartyName.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_PartyName.Location = New System.Drawing.Point(168, 128)
        Me.txt_PartyName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_PartyName.MandatoryField = False
        Me.txt_PartyName.MaxDate = Nothing
        Me.txt_PartyName.MaxLength = 70
        Me.txt_PartyName.MinDate = Nothing
        Me.txt_PartyName.Name = "txt_PartyName"
        Me.txt_PartyName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_PartyName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_PartyName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_PartyName.RegularExpression = Nothing
        Me.txt_PartyName.RegularExpressionErrorMessage = Nothing
        Me.txt_PartyName.ShowMessage = False
        Me.txt_PartyName.Size = New System.Drawing.Size(272, 22)
        Me.txt_PartyName.SpacerString = ""
        Me.txt_PartyName.TabIndex = 4
        Me.txt_PartyName.Tag = "PARTYNAME"
        Me.txt_PartyName.TransparentBox = True
        Me.txt_PartyName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'lll
        '
        Me.lll.AutoSize = True
        Me.lll.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lll.Location = New System.Drawing.Point(16, 132)
        Me.lll.Name = "lll"
        Me.lll.Size = New System.Drawing.Size(85, 14)
        Me.lll.TabIndex = 81955
        Me.lll.Text = "Party Name"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(145, 132)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(12, 14)
        Me.Label36.TabIndex = 81954
        Me.Label36.Text = ":"
        '
        'txt_Mtr_Weight
        '
        Me.txt_Mtr_Weight._AllowSpace = True
        Me.txt_Mtr_Weight.AcceptsReturn = True
        Me.txt_Mtr_Weight.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Mtr_Weight.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_Mtr_Weight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Mtr_Weight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mtr_Weight.Check_End_Date_Value_FY = "YES"
        Me.txt_Mtr_Weight.Check_Start_Date_Value_FY = "YES"
        Me.txt_Mtr_Weight.ClearField = True
        Me.txt_Mtr_Weight.CustomInputTypeString = Nothing
        Me.txt_Mtr_Weight.Date_for_Database = Nothing
        Me.txt_Mtr_Weight.Date_Tag = Nothing
        Me.txt_Mtr_Weight.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Mtr_Weight.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Mtr_Weight.ExtraValue = ""
        Me.txt_Mtr_Weight.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mtr_Weight.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Mtr_Weight.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Mtr_Weight.ForeColor = System.Drawing.Color.Black
        Me.txt_Mtr_Weight.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_Mtr_Weight.IsValidated = False
        Me.txt_Mtr_Weight.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_Mtr_Weight.Location = New System.Drawing.Point(622, 245)
        Me.txt_Mtr_Weight.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Mtr_Weight.MandatoryField = False
        Me.txt_Mtr_Weight.MaxDate = Nothing
        Me.txt_Mtr_Weight.MaxLength = 70
        Me.txt_Mtr_Weight.MinDate = Nothing
        Me.txt_Mtr_Weight.Name = "txt_Mtr_Weight"
        Me.txt_Mtr_Weight.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_Mtr_Weight.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Mtr_Weight.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txt_Mtr_Weight.ReadOnly = True
        Me.txt_Mtr_Weight.RegularExpression = Nothing
        Me.txt_Mtr_Weight.RegularExpressionErrorMessage = Nothing
        Me.txt_Mtr_Weight.ShowMessage = False
        Me.txt_Mtr_Weight.Size = New System.Drawing.Size(106, 22)
        Me.txt_Mtr_Weight.SpacerString = ""
        Me.txt_Mtr_Weight.TabIndex = 29
        Me.txt_Mtr_Weight.Tag = "MTR_WEIGHT"
        Me.txt_Mtr_Weight.TransparentBox = True
        Me.txt_Mtr_Weight.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txt_No_Of_Set
        '
        Me.txt_No_Of_Set._AllowSpace = True
        Me.txt_No_Of_Set.AcceptsReturn = True
        Me.txt_No_Of_Set.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_No_Of_Set.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_No_Of_Set.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_No_Of_Set.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_No_Of_Set.Check_End_Date_Value_FY = "YES"
        Me.txt_No_Of_Set.Check_Start_Date_Value_FY = "YES"
        Me.txt_No_Of_Set.ClearField = True
        Me.txt_No_Of_Set.CustomInputTypeString = Nothing
        Me.txt_No_Of_Set.Date_for_Database = Nothing
        Me.txt_No_Of_Set.Date_Tag = Nothing
        Me.txt_No_Of_Set.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_No_Of_Set.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_No_Of_Set.ExtraValue = ""
        Me.txt_No_Of_Set.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_No_Of_Set.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_No_Of_Set.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_No_Of_Set.ForeColor = System.Drawing.Color.Black
        Me.txt_No_Of_Set.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_No_Of_Set.IsValidated = False
        Me.txt_No_Of_Set.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_No_Of_Set.Location = New System.Drawing.Point(622, 137)
        Me.txt_No_Of_Set.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_No_Of_Set.MandatoryField = False
        Me.txt_No_Of_Set.MaxDate = Nothing
        Me.txt_No_Of_Set.MaxLength = 70
        Me.txt_No_Of_Set.MinDate = Nothing
        Me.txt_No_Of_Set.Name = "txt_No_Of_Set"
        Me.txt_No_Of_Set.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_No_Of_Set.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_No_Of_Set.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_No_Of_Set.RegularExpression = Nothing
        Me.txt_No_Of_Set.RegularExpressionErrorMessage = Nothing
        Me.txt_No_Of_Set.ShowMessage = False
        Me.txt_No_Of_Set.Size = New System.Drawing.Size(98, 22)
        Me.txt_No_Of_Set.SpacerString = ""
        Me.txt_No_Of_Set.TabIndex = 25
        Me.txt_No_Of_Set.Tag = "NO_OF_SET"
        Me.txt_No_Of_Set.TransparentBox = True
        Me.txt_No_Of_Set.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txt_Pick_Rate
        '
        Me.txt_Pick_Rate._AllowSpace = True
        Me.txt_Pick_Rate.AcceptsReturn = True
        Me.txt_Pick_Rate.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Pick_Rate.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_Pick_Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Pick_Rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Pick_Rate.Check_End_Date_Value_FY = "YES"
        Me.txt_Pick_Rate.Check_Start_Date_Value_FY = "YES"
        Me.txt_Pick_Rate.ClearField = True
        Me.txt_Pick_Rate.CustomInputTypeString = Nothing
        Me.txt_Pick_Rate.Date_for_Database = Nothing
        Me.txt_Pick_Rate.Date_Tag = Nothing
        Me.txt_Pick_Rate.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Pick_Rate.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Pick_Rate.ExtraValue = ""
        Me.txt_Pick_Rate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Pick_Rate.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Pick_Rate.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Pick_Rate.ForeColor = System.Drawing.Color.Black
        Me.txt_Pick_Rate.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txt_Pick_Rate.IsValidated = False
        Me.txt_Pick_Rate.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_Pick_Rate.Location = New System.Drawing.Point(168, 177)
        Me.txt_Pick_Rate.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Pick_Rate.MandatoryField = False
        Me.txt_Pick_Rate.MaxDate = Nothing
        Me.txt_Pick_Rate.MaxLength = 70
        Me.txt_Pick_Rate.MinDate = Nothing
        Me.txt_Pick_Rate.Name = "txt_Pick_Rate"
        Me.txt_Pick_Rate.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_Pick_Rate.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Pick_Rate.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.FourDecimal
        Me.txt_Pick_Rate.RegularExpression = Nothing
        Me.txt_Pick_Rate.RegularExpressionErrorMessage = Nothing
        Me.txt_Pick_Rate.ShowMessage = False
        Me.txt_Pick_Rate.Size = New System.Drawing.Size(106, 22)
        Me.txt_Pick_Rate.SpacerString = ""
        Me.txt_Pick_Rate.TabIndex = 6
        Me.txt_Pick_Rate.Tag = "PICK_RATE"
        Me.txt_Pick_Rate.TransparentBox = True
        Me.txt_Pick_Rate.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtChallanDate
        '
        Me.txtChallanDate._AllowSpace = True
        Me.txtChallanDate.AcceptsReturn = True
        Me.txtChallanDate.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallanDate.BackColor = System.Drawing.Color.GhostWhite
        Me.txtChallanDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallanDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChallanDate.Check_End_Date_Value_FY = "YES"
        Me.txtChallanDate.Check_Start_Date_Value_FY = "YES"
        Me.txtChallanDate.ClearField = True
        Me.txtChallanDate.CustomInputTypeString = Nothing
        Me.txtChallanDate.Date_for_Database = Nothing
        Me.txtChallanDate.Date_Tag = Nothing
        Me.txtChallanDate.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtChallanDate.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtChallanDate.ExtraValue = ""
        Me.txtChallanDate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallanDate.FontFocusColor = System.Drawing.Color.Blue
        Me.txtChallanDate.FontLeaveColor = System.Drawing.Color.Black
        Me.txtChallanDate.ForeColor = System.Drawing.Color.Black
        Me.txtChallanDate.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txtChallanDate.IsValidated = False
        Me.txtChallanDate.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txtChallanDate.Location = New System.Drawing.Point(622, 78)
        Me.txtChallanDate.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtChallanDate.MandatoryField = False
        Me.txtChallanDate.MaxDate = Nothing
        Me.txtChallanDate.MaxLength = 70
        Me.txtChallanDate.MinDate = Nothing
        Me.txtChallanDate.Name = "txtChallanDate"
        Me.txtChallanDate.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtChallanDate.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallanDate.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallanDate.RegularExpression = Nothing
        Me.txtChallanDate.RegularExpressionErrorMessage = Nothing
        Me.txtChallanDate.ShowMessage = False
        Me.txtChallanDate.Size = New System.Drawing.Size(98, 22)
        Me.txtChallanDate.SpacerString = ""
        Me.txtChallanDate.TabIndex = 23
        Me.txtChallanDate.Tag = "OFFERDATE"
        Me.txtChallanDate.Text = "  /  /    "
        Me.txtChallanDate.TransparentBox = True
        Me.txtChallanDate.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txt_OfferNo
        '
        Me.txt_OfferNo._AllowSpace = True
        Me.txt_OfferNo.AcceptsReturn = True
        Me.txt_OfferNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_OfferNo.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_OfferNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_OfferNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_OfferNo.Check_End_Date_Value_FY = "YES"
        Me.txt_OfferNo.Check_Start_Date_Value_FY = "YES"
        Me.txt_OfferNo.ClearField = True
        Me.txt_OfferNo.CustomInputTypeString = Nothing
        Me.txt_OfferNo.Date_for_Database = Nothing
        Me.txt_OfferNo.Date_Tag = Nothing
        Me.txt_OfferNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_OfferNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_OfferNo.ExtraValue = ""
        Me.txt_OfferNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_OfferNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_OfferNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_OfferNo.ForeColor = System.Drawing.Color.Black
        Me.txt_OfferNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_OfferNo.IsValidated = False
        Me.txt_OfferNo.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_OfferNo.Location = New System.Drawing.Point(622, 52)
        Me.txt_OfferNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_OfferNo.MandatoryField = False
        Me.txt_OfferNo.MaxDate = Nothing
        Me.txt_OfferNo.MaxLength = 70
        Me.txt_OfferNo.MinDate = Nothing
        Me.txt_OfferNo.Name = "txt_OfferNo"
        Me.txt_OfferNo.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_OfferNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_OfferNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_OfferNo.RegularExpression = Nothing
        Me.txt_OfferNo.RegularExpressionErrorMessage = Nothing
        Me.txt_OfferNo.ShowMessage = False
        Me.txt_OfferNo.Size = New System.Drawing.Size(98, 22)
        Me.txt_OfferNo.SpacerString = ""
        Me.txt_OfferNo.TabIndex = 22
        Me.txt_OfferNo.Tag = "OFFERNO"
        Me.txt_OfferNo.TransparentBox = True
        Me.txt_OfferNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(609, 249)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 14)
        Me.Label11.TabIndex = 81953
        Me.Label11.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(145, 181)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(12, 14)
        Me.Label22.TabIndex = 81952
        Me.Label22.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 187)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 14)
        Me.Label17.TabIndex = 81951
        Me.Label17.Text = "Rate"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(609, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 14)
        Me.Label14.TabIndex = 81950
        Me.Label14.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(457, 249)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 14)
        Me.Label13.TabIndex = 81949
        Me.Label13.Text = "Total Meters"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(457, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 14)
        Me.Label12.TabIndex = 81948
        Me.Label12.Text = "No Of Sets"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(609, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 14)
        Me.Label5.TabIndex = 81947
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(609, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 81946
        Me.Label4.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(457, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 14)
        Me.Label2.TabIndex = 81945
        Me.Label2.Text = "Order Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(457, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 14)
        Me.Label1.TabIndex = 81944
        Me.Label1.Text = "Order No."
        '
        'Txt_Moredetail
        '
        Me.Txt_Moredetail._AllowSpace = True
        Me.Txt_Moredetail.AcceptsReturn = True
        Me.Txt_Moredetail.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Moredetail.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_Moredetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Moredetail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Moredetail.Check_End_Date_Value_FY = "YES"
        Me.Txt_Moredetail.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Moredetail.ClearField = True
        Me.Txt_Moredetail.CustomInputTypeString = Nothing
        Me.Txt_Moredetail.Date_for_Database = Nothing
        Me.Txt_Moredetail.Date_Tag = Nothing
        Me.Txt_Moredetail.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Moredetail.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.Txt_Moredetail.ExtraValue = ""
        Me.Txt_Moredetail.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Moredetail.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Moredetail.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Moredetail.ForeColor = System.Drawing.Color.Black
        Me.Txt_Moredetail.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_Moredetail.IsValidated = False
        Me.Txt_Moredetail.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_Moredetail.Location = New System.Drawing.Point(168, 253)
        Me.Txt_Moredetail.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_Moredetail.MandatoryField = False
        Me.Txt_Moredetail.MaxDate = Nothing
        Me.Txt_Moredetail.MaxLength = 70
        Me.Txt_Moredetail.MinDate = Nothing
        Me.Txt_Moredetail.Name = "Txt_Moredetail"
        Me.Txt_Moredetail.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_Moredetail.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Moredetail.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Moredetail.RegularExpression = Nothing
        Me.Txt_Moredetail.RegularExpressionErrorMessage = Nothing
        Me.Txt_Moredetail.ShowMessage = False
        Me.Txt_Moredetail.Size = New System.Drawing.Size(106, 22)
        Me.Txt_Moredetail.SpacerString = "NO,YES"
        Me.Txt_Moredetail.TabIndex = 9
        Me.Txt_Moredetail.Tag = ""
        Me.Txt_Moredetail.Text = "NO"
        Me.Txt_Moredetail.TransparentBox = True
        Me.Txt_Moredetail.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 257)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 14)
        Me.Label3.TabIndex = 81975
        Me.Label3.Text = "Insert More Detail"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(145, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 81974
        Me.Label6.Text = ":"
        '
        'txt_HeaderRemark
        '
        Me.txt_HeaderRemark._AllowSpace = True
        Me.txt_HeaderRemark.AcceptsReturn = True
        Me.txt_HeaderRemark.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_HeaderRemark.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_HeaderRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_HeaderRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_HeaderRemark.Check_End_Date_Value_FY = "YES"
        Me.txt_HeaderRemark.Check_Start_Date_Value_FY = "YES"
        Me.txt_HeaderRemark.ClearField = True
        Me.txt_HeaderRemark.CustomInputTypeString = Nothing
        Me.txt_HeaderRemark.Date_for_Database = Nothing
        Me.txt_HeaderRemark.Date_Tag = Nothing
        Me.txt_HeaderRemark.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_HeaderRemark.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_HeaderRemark.ExtraValue = ""
        Me.txt_HeaderRemark.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_HeaderRemark.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_HeaderRemark.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_HeaderRemark.ForeColor = System.Drawing.Color.Black
        Me.txt_HeaderRemark.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txt_HeaderRemark.IsValidated = False
        Me.txt_HeaderRemark.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_HeaderRemark.Location = New System.Drawing.Point(622, 104)
        Me.txt_HeaderRemark.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_HeaderRemark.MandatoryField = False
        Me.txt_HeaderRemark.MaxDate = Nothing
        Me.txt_HeaderRemark.MaxLength = 250
        Me.txt_HeaderRemark.MinDate = Nothing
        Me.txt_HeaderRemark.Multiline = True
        Me.txt_HeaderRemark.Name = "txt_HeaderRemark"
        Me.txt_HeaderRemark.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txt_HeaderRemark.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_HeaderRemark.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_HeaderRemark.RegularExpression = Nothing
        Me.txt_HeaderRemark.RegularExpressionErrorMessage = Nothing
        Me.txt_HeaderRemark.ShowMessage = False
        Me.txt_HeaderRemark.Size = New System.Drawing.Size(261, 22)
        Me.txt_HeaderRemark.SpacerString = ""
        Me.txt_HeaderRemark.TabIndex = 24
        Me.txt_HeaderRemark.Tag = "HEADERREMARK"
        Me.txt_HeaderRemark.TransparentBox = True
        Me.txt_HeaderRemark.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(604, 108)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(12, 14)
        Me.Label32.TabIndex = 81978
        Me.Label32.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(457, 108)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 14)
        Me.Label28.TabIndex = 81977
        Me.Label28.Text = "Remarks"
        '
        'LblHeader
        '
        Me.LblHeader.BackColor = System.Drawing.Color.DarkSlateGray
        Me.LblHeader.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeader.ForeColor = System.Drawing.Color.White
        Me.LblHeader.Location = New System.Drawing.Point(1, 3)
        Me.LblHeader.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(882, 27)
        Me.LblHeader.TabIndex = 81979
        Me.LblHeader.Text = "Grey Order Entry"
        Me.LblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PNL_View
        '
        Me.PNL_View.Controls.Add(Me.But_export)
        Me.PNL_View.Controls.Add(Me.But_print)
        Me.PNL_View.Controls.Add(Me.Btn_LayoutLoad)
        Me.PNL_View.Controls.Add(Me.BtnLayOutSave)
        Me.PNL_View.Controls.Add(Me.GridControl1)
        Me.PNL_View.Location = New System.Drawing.Point(781, 190)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(92, 130)
        Me.PNL_View.TabIndex = 81980
        Me.PNL_View.Visible = False
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(203, 9)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(119, 32)
        Me.Btn_LayoutLoad.TabIndex = 81917
        Me.Btn_LayoutLoad.Text = "Load Report"
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(83, 9)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(119, 32)
        Me.BtnLayOutSave.TabIndex = 81916
        Me.BtnLayOutSave.Text = "Save Report"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(3, 46)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(222, 134)
        Me.GridControl1.TabIndex = 81900
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
        'Txt_PlanningNo
        '
        Me.Txt_PlanningNo._AllowSpace = True
        Me.Txt_PlanningNo.AcceptsReturn = True
        Me.Txt_PlanningNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_PlanningNo.BackColor = System.Drawing.Color.GhostWhite
        Me.Txt_PlanningNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_PlanningNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PlanningNo.Check_End_Date_Value_FY = "YES"
        Me.Txt_PlanningNo.Check_Start_Date_Value_FY = "YES"
        Me.Txt_PlanningNo.ClearField = True
        Me.Txt_PlanningNo.CustomInputTypeString = Nothing
        Me.Txt_PlanningNo.Date_for_Database = Nothing
        Me.Txt_PlanningNo.Date_Tag = Nothing
        Me.Txt_PlanningNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_PlanningNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_PlanningNo.ExtraValue = ""
        Me.Txt_PlanningNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PlanningNo.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_PlanningNo.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_PlanningNo.ForeColor = System.Drawing.Color.Black
        Me.Txt_PlanningNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_PlanningNo.IsValidated = False
        Me.Txt_PlanningNo.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_PlanningNo.Location = New System.Drawing.Point(168, 103)
        Me.Txt_PlanningNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_PlanningNo.MandatoryField = False
        Me.Txt_PlanningNo.MaxDate = Nothing
        Me.Txt_PlanningNo.MaxLength = 250
        Me.Txt_PlanningNo.MinDate = Nothing
        Me.Txt_PlanningNo.Multiline = True
        Me.Txt_PlanningNo.Name = "Txt_PlanningNo"
        Me.Txt_PlanningNo.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_PlanningNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_PlanningNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_PlanningNo.ReadOnly = True
        Me.Txt_PlanningNo.RegularExpression = Nothing
        Me.Txt_PlanningNo.RegularExpressionErrorMessage = Nothing
        Me.Txt_PlanningNo.ShowMessage = False
        Me.Txt_PlanningNo.Size = New System.Drawing.Size(142, 22)
        Me.Txt_PlanningNo.SpacerString = ""
        Me.Txt_PlanningNo.TabIndex = 3
        Me.Txt_PlanningNo.Tag = "OP16"
        Me.Txt_PlanningNo.TransparentBox = True
        Me.Txt_PlanningNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(145, 107)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(12, 14)
        Me.Label68.TabIndex = 81983
        Me.Label68.Text = ":"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(17, 107)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(86, 14)
        Me.Label69.TabIndex = 81982
        Me.Label69.Text = "Planning No"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnView)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnModify)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 335)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 53)
        Me.GroupBox1.TabIndex = 81984
        Me.GroupBox1.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.ImageOptions.Image = CType(resources.GetObject("btnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(556, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 36)
        Me.btnClose.TabIndex = 81951
        Me.btnClose.Text = "Close"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(385, 12)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 36)
        Me.btnView.TabIndex = 81950
        Me.btnView.Text = "View"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(468, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 36)
        Me.btnSave.TabIndex = 81946
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(294, 12)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(91, 36)
        Me.btnDelete.TabIndex = 81949
        Me.btnDelete.Text = "Delete"
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.ImageOptions.Image = CType(resources.GetObject("btnAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(130, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 36)
        Me.btnAdd.TabIndex = 81947
        Me.btnAdd.Text = "Add"
        '
        'btnModify
        '
        Me.btnModify.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Appearance.Options.UseFont = True
        Me.btnModify.ImageOptions.Image = CType(resources.GetObject("btnModify.ImageOptions.Image"), System.Drawing.Image)
        Me.btnModify.Location = New System.Drawing.Point(206, 12)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(87, 36)
        Me.btnModify.TabIndex = 81948
        Me.btnModify.Text = "Modify"
        '
        'But_export
        '
        Me.But_export.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_export.Appearance.Options.UseFont = True
        Me.But_export.ImageOptions.Image = CType(resources.GetObject("But_export.ImageOptions.Image"), System.Drawing.Image)
        Me.But_export.Location = New System.Drawing.Point(43, 7)
        Me.But_export.Name = "But_export"
        Me.But_export.Size = New System.Drawing.Size(39, 36)
        Me.But_export.TabIndex = 81951
        '
        'But_print
        '
        Me.But_print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.Appearance.Options.UseFont = True
        Me.But_print.ImageOptions.Image = CType(resources.GetObject("But_print.ImageOptions.Image"), System.Drawing.Image)
        Me.But_print.Location = New System.Drawing.Point(3, 7)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(39, 36)
        Me.But_print.TabIndex = 81950
        '
        'Planning_OrderEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(885, 393)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Txt_PlanningNo)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.PNL_View)
        Me.Controls.Add(Me.LblHeader)
        Me.Controls.Add(Me.txt_HeaderRemark)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Txt_Moredetail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txt_RollingCharge)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.Label72)
        Me.Controls.Add(Me.Ttx_CutMtrs)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.txt_Loom_Type)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.txt_Extra_Chg)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.txt_Mending_Chg)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_No_Of_Beam)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txt_EntryNo)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.txtBookName)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.txt_PartyName)
        Me.Controls.Add(Me.lll)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txt_Mtr_Weight)
        Me.Controls.Add(Me.txt_No_Of_Set)
        Me.Controls.Add(Me.txt_Pick_Rate)
        Me.Controls.Add(Me.txtChallanDate)
        Me.Controls.Add(Me.txt_OfferNo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Planning_OrderEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planning Order Entry"
        Me.PNL_View.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_RollingCharge As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Ttx_CutMtrs As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents txt_Loom_Type As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents txt_Extra_Chg As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents txt_Mending_Chg As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txt_No_Of_Beam As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents txt_EntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents txtBookName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents txt_PartyName As ctl_TextBox.ctl_TextBox
    Friend WithEvents lll As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents txt_Mtr_Weight As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_No_Of_Set As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_Pick_Rate As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtChallanDate As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_OfferNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Moredetail As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_HeaderRemark As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents LblHeader As Label
    Friend WithEvents PNL_View As Panel
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Txt_PlanningNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label68 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModify As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
End Class
