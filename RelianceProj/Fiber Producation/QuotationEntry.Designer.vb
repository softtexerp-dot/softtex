<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuotationEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuotationEntry))
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtBookName = New ctl_TextBox.ctl_TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtChallanDate = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChallanNo = New ctl_TextBox.ctl_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAccountName = New ctl_TextBox.ctl_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Ctl_TextBox2 = New ctl_TextBox.ctl_TextBox()
        Me.GrdItem = New FlexCell.Grid()
        Me.UC_Buttons1 = New RelianceProj.UC_Buttons()
        Me.lbl_Grid_Header = New System.Windows.Forms.Label()
        Me.Lbl_Tot_Mtr_Weight = New System.Windows.Forms.Label()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.lbl_Tot_Amt = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtHeader_Remark = New ctl_TextBox.ctl_TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Txt_Fright = New ctl_TextBox.ctl_TextBox()
        Me.Txt_Deli = New ctl_TextBox.ctl_TextBox()
        Me.Txt_Delivery = New ctl_TextBox.ctl_TextBox()
        Me.Txt_PaymentTerms = New ctl_TextBox.ctl_TextBox()
        Me.PNL_View.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(125, 10)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(12, 14)
        Me.Label41.TabIndex = 81437
        Me.Label41.Text = ":"
        '
        'txtBookName
        '
        Me.txtBookName._AllowSpace = True
        Me.txtBookName.AcceptsReturn = True
        Me.txtBookName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtBookName.BackColor = System.Drawing.Color.LightCyan
        Me.txtBookName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBookName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBookName.Check_End_Date_Value_FY = "YES"
        Me.txtBookName.Check_Start_Date_Value_FY = "YES"
        Me.txtBookName.ClearField = True
        Me.txtBookName.CustomInputTypeString = Nothing
        Me.txtBookName.Date_for_Database = Nothing
        Me.txtBookName.Date_Tag = Nothing
        Me.txtBookName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtBookName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.txtBookName.ExtraValue = ""
        Me.txtBookName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtBookName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtBookName.ForeColor = System.Drawing.Color.Black
        Me.txtBookName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtBookName.IsValidated = False
        Me.txtBookName.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtBookName.Location = New System.Drawing.Point(138, 9)
        Me.txtBookName.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtBookName.MandatoryField = False
        Me.txtBookName.MaxDate = Nothing
        Me.txtBookName.MinDate = Nothing
        Me.txtBookName.Name = "txtBookName"
        Me.txtBookName.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtBookName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtBookName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtBookName.ReadOnly = True
        Me.txtBookName.RegularExpression = Nothing
        Me.txtBookName.RegularExpressionErrorMessage = Nothing
        Me.txtBookName.ShowMessage = False
        Me.txtBookName.Size = New System.Drawing.Size(202, 22)
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
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(6, 9)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(76, 14)
        Me.Label50.TabIndex = 81436
        Me.Label50.Text = "Unit Name"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(125, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 14)
        Me.Label20.TabIndex = 81435
        Me.Label20.Text = ":"
        '
        'txtChallanDate
        '
        Me.txtChallanDate._AllowSpace = True
        Me.txtChallanDate.AcceptsReturn = True
        Me.txtChallanDate.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallanDate.BackColor = System.Drawing.Color.LightCyan
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
        Me.txtChallanDate.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtChallanDate.Location = New System.Drawing.Point(138, 87)
        Me.txtChallanDate.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtChallanDate.MandatoryField = False
        Me.txtChallanDate.MaxDate = Nothing
        Me.txtChallanDate.MaxLength = 6
        Me.txtChallanDate.MinDate = Nothing
        Me.txtChallanDate.Name = "txtChallanDate"
        Me.txtChallanDate.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtChallanDate.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallanDate.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallanDate.RegularExpression = Nothing
        Me.txtChallanDate.RegularExpressionErrorMessage = Nothing
        Me.txtChallanDate.ShowMessage = False
        Me.txtChallanDate.Size = New System.Drawing.Size(98, 22)
        Me.txtChallanDate.SpacerString = ""
        Me.txtChallanDate.TabIndex = 4
        Me.txtChallanDate.Tag = "ChallanDate"
        Me.txtChallanDate.Text = "  /  /    "
        Me.txtChallanDate.TransparentBox = True
        Me.txtChallanDate.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 81433
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 81434
        Me.Label2.Text = ":"
        '
        'txtEntryNo
        '
        Me.txtEntryNo._AllowSpace = True
        Me.txtEntryNo.AcceptsReturn = True
        Me.txtEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtEntryNo.BackColor = System.Drawing.Color.LightCyan
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
        Me.txtEntryNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txtEntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txtEntryNo.ForeColor = System.Drawing.Color.Black
        Me.txtEntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtEntryNo.IsValidated = False
        Me.txtEntryNo.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtEntryNo.Location = New System.Drawing.Point(138, 35)
        Me.txtEntryNo.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtEntryNo.MandatoryField = False
        Me.txtEntryNo.MaxDate = Nothing
        Me.txtEntryNo.MinDate = Nothing
        Me.txtEntryNo.Name = "txtEntryNo"
        Me.txtEntryNo.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtEntryNo.RegularExpression = Nothing
        Me.txtEntryNo.RegularExpressionErrorMessage = Nothing
        Me.txtEntryNo.ShowMessage = False
        Me.txtEntryNo.Size = New System.Drawing.Size(98, 22)
        Me.txtEntryNo.SpacerString = ""
        Me.txtEntryNo.TabIndex = 2
        Me.txtEntryNo.Tag = "EntryNo"
        Me.txtEntryNo.TransparentBox = True
        Me.txtEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 14)
        Me.Label7.TabIndex = 81432
        Me.Label7.Text = "Entry No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(125, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 81440
        Me.Label3.Text = ":"
        '
        'txtChallanNo
        '
        Me.txtChallanNo._AllowSpace = True
        Me.txtChallanNo.AcceptsReturn = True
        Me.txtChallanNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallanNo.BackColor = System.Drawing.Color.LightCyan
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
        Me.txtChallanNo.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtChallanNo.Location = New System.Drawing.Point(138, 60)
        Me.txtChallanNo.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtChallanNo.MandatoryField = False
        Me.txtChallanNo.MaxDate = Nothing
        Me.txtChallanNo.MinDate = Nothing
        Me.txtChallanNo.Name = "txtChallanNo"
        Me.txtChallanNo.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtChallanNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallanNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallanNo.RegularExpression = Nothing
        Me.txtChallanNo.RegularExpressionErrorMessage = Nothing
        Me.txtChallanNo.ShowMessage = False
        Me.txtChallanNo.Size = New System.Drawing.Size(98, 22)
        Me.txtChallanNo.SpacerString = ""
        Me.txtChallanNo.TabIndex = 3
        Me.txtChallanNo.Tag = "EntryNo"
        Me.txtChallanNo.TransparentBox = True
        Me.txtChallanNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 81439
        Me.Label4.Text = "Quotation No"
        '
        'txtAccountName
        '
        Me.txtAccountName._AllowSpace = True
        Me.txtAccountName.AcceptsReturn = True
        Me.txtAccountName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtAccountName.BackColor = System.Drawing.Color.LightCyan
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
        Me.txtAccountName.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtAccountName.Location = New System.Drawing.Point(530, 12)
        Me.txtAccountName.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtAccountName.MandatoryField = False
        Me.txtAccountName.MaxDate = Nothing
        Me.txtAccountName.MinDate = Nothing
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtAccountName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtAccountName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtAccountName.RegularExpression = Nothing
        Me.txtAccountName.RegularExpressionErrorMessage = Nothing
        Me.txtAccountName.ShowMessage = False
        Me.txtAccountName.Size = New System.Drawing.Size(255, 22)
        Me.txtAccountName.SpacerString = ""
        Me.txtAccountName.TabIndex = 6
        Me.txtAccountName.Tag = "ACCOUNTNAME"
        Me.txtAccountName.TransparentBox = True
        Me.txtAccountName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(399, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 14)
        Me.Label5.TabIndex = 82141
        Me.Label5.Text = "Supplier Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(510, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 82142
        Me.Label6.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 14)
        Me.Label8.TabIndex = 82143
        Me.Label8.Text = "Selected Req No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(125, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 14)
        Me.Label9.TabIndex = 82144
        Me.Label9.Text = ":"
        '
        'Ctl_TextBox2
        '
        Me.Ctl_TextBox2._AllowSpace = True
        Me.Ctl_TextBox2.AcceptsReturn = True
        Me.Ctl_TextBox2.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Ctl_TextBox2.BackColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ctl_TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ctl_TextBox2.Check_End_Date_Value_FY = "YES"
        Me.Ctl_TextBox2.Check_Start_Date_Value_FY = "YES"
        Me.Ctl_TextBox2.ClearField = True
        Me.Ctl_TextBox2.CustomInputTypeString = Nothing
        Me.Ctl_TextBox2.Date_for_Database = Nothing
        Me.Ctl_TextBox2.Date_Tag = Nothing
        Me.Ctl_TextBox2.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Ctl_TextBox2.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.Ctl_TextBox2.ExtraValue = ""
        Me.Ctl_TextBox2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctl_TextBox2.FontFocusColor = System.Drawing.Color.Blue
        Me.Ctl_TextBox2.FontLeaveColor = System.Drawing.Color.Black
        Me.Ctl_TextBox2.ForeColor = System.Drawing.Color.Black
        Me.Ctl_TextBox2.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Ctl_TextBox2.IsValidated = False
        Me.Ctl_TextBox2.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox2.Location = New System.Drawing.Point(138, 115)
        Me.Ctl_TextBox2.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox2.MandatoryField = False
        Me.Ctl_TextBox2.MaxDate = Nothing
        Me.Ctl_TextBox2.MinDate = Nothing
        Me.Ctl_TextBox2.Name = "Ctl_TextBox2"
        Me.Ctl_TextBox2.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox2.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Ctl_TextBox2.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Ctl_TextBox2.RegularExpression = Nothing
        Me.Ctl_TextBox2.RegularExpressionErrorMessage = Nothing
        Me.Ctl_TextBox2.ShowMessage = False
        Me.Ctl_TextBox2.Size = New System.Drawing.Size(526, 22)
        Me.Ctl_TextBox2.SpacerString = ""
        Me.Ctl_TextBox2.TabIndex = 5
        Me.Ctl_TextBox2.Tag = "EntryNo"
        Me.Ctl_TextBox2.TransparentBox = True
        Me.Ctl_TextBox2.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'GrdItem
        '
        Me.GrdItem.AllowUserReorderColumn = True
        Me.GrdItem.AllowUserSort = True
        Me.GrdItem.BackColorActiveCellSel = System.Drawing.SystemColors.Highlight
        Me.GrdItem.BackColorBkg = System.Drawing.Color.White
        Me.GrdItem.BackColorFixed = System.Drawing.Color.Khaki
        Me.GrdItem.BackColorFixedSel = System.Drawing.Color.White
        Me.GrdItem.BoldFixedCell = False
        Me.GrdItem.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.GrdItem.CellBorderColor = System.Drawing.Color.Gray
        Me.GrdItem.CellBorderColorFixed = System.Drawing.Color.Gray
        Me.GrdItem.CheckedImage = CType(resources.GetObject("GrdItem.CheckedImage"), System.Drawing.Bitmap)
        Me.GrdItem.Cols = 15
        Me.GrdItem.CommentIndicatorColor = System.Drawing.Color.Blue
        Me.GrdItem.DefaultFont = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GrdItem.DefaultRowHeight = CType(24, Short)
        Me.GrdItem.DisplayRowNumber = True
        Me.GrdItem.EnableTabKey = False
        Me.GrdItem.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Light3D
        Me.GrdItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdItem.GridColor = System.Drawing.Color.SlateGray
        Me.GrdItem.Location = New System.Drawing.Point(7, 164)
        Me.GrdItem.MultiSelect = False
        Me.GrdItem.Name = "GrdItem"
        Me.GrdItem.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.GrdItem.ScrollBars = FlexCell.ScrollBarsEnum.None
        Me.GrdItem.SelectionBorderColor = System.Drawing.Color.Blue
        Me.GrdItem.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GrdItem.Size = New System.Drawing.Size(999, 268)
        Me.GrdItem.TabIndex = 11
        Me.GrdItem.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.GrdItem.UncheckedImage = CType(resources.GetObject("GrdItem.UncheckedImage"), System.Drawing.Bitmap)
        '
        'UC_Buttons1
        '
        Me.UC_Buttons1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_Buttons1.Location = New System.Drawing.Point(0, 576)
        Me.UC_Buttons1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_Buttons1.Name = "UC_Buttons1"
        Me.UC_Buttons1.Size = New System.Drawing.Size(1008, 43)
        Me.UC_Buttons1.TabIndex = 82154
        '
        'lbl_Grid_Header
        '
        Me.lbl_Grid_Header.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lbl_Grid_Header.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grid_Header.ForeColor = System.Drawing.Color.White
        Me.lbl_Grid_Header.Location = New System.Drawing.Point(7, 141)
        Me.lbl_Grid_Header.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Grid_Header.Name = "lbl_Grid_Header"
        Me.lbl_Grid_Header.Size = New System.Drawing.Size(999, 23)
        Me.lbl_Grid_Header.TabIndex = 82155
        Me.lbl_Grid_Header.Text = "F1=Exit,F3=Delete Row"
        Me.lbl_Grid_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Tot_Mtr_Weight
        '
        Me.Lbl_Tot_Mtr_Weight.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tot_Mtr_Weight.Location = New System.Drawing.Point(390, 435)
        Me.Lbl_Tot_Mtr_Weight.Name = "Lbl_Tot_Mtr_Weight"
        Me.Lbl_Tot_Mtr_Weight.Size = New System.Drawing.Size(101, 18)
        Me.Lbl_Tot_Mtr_Weight.TabIndex = 82158
        Me.Lbl_Tot_Mtr_Weight.Text = "Total :"
        Me.Lbl_Tot_Mtr_Weight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(3, 435)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(49, 14)
        Me.lbl_Total.TabIndex = 82157
        Me.lbl_Total.Text = "Total :"
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Tot_Amt
        '
        Me.lbl_Tot_Amt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tot_Amt.Location = New System.Drawing.Point(806, 435)
        Me.lbl_Tot_Amt.Name = "lbl_Tot_Amt"
        Me.lbl_Tot_Amt.Size = New System.Drawing.Size(94, 18)
        Me.lbl_Tot_Amt.TabIndex = 82159
        Me.lbl_Tot_Amt.Text = "Total :"
        Me.lbl_Tot_Amt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(507, 40)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(12, 14)
        Me.Label24.TabIndex = 82162
        Me.Label24.Text = ":"
        '
        'txtHeader_Remark
        '
        Me.txtHeader_Remark._AllowSpace = True
        Me.txtHeader_Remark.AcceptsReturn = True
        Me.txtHeader_Remark.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtHeader_Remark.BackColor = System.Drawing.Color.LightCyan
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
        Me.txtHeader_Remark.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txtHeader_Remark.Location = New System.Drawing.Point(530, 40)
        Me.txtHeader_Remark.MandatoryColor = System.Drawing.Color.LightCyan
        Me.txtHeader_Remark.MandatoryField = False
        Me.txtHeader_Remark.MaxDate = Nothing
        Me.txtHeader_Remark.MinDate = Nothing
        Me.txtHeader_Remark.Name = "txtHeader_Remark"
        Me.txtHeader_Remark.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.txtHeader_Remark.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtHeader_Remark.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtHeader_Remark.RegularExpression = Nothing
        Me.txtHeader_Remark.RegularExpressionErrorMessage = Nothing
        Me.txtHeader_Remark.ShowMessage = False
        Me.txtHeader_Remark.Size = New System.Drawing.Size(168, 22)
        Me.txtHeader_Remark.SpacerString = ""
        Me.txtHeader_Remark.TabIndex = 7
        Me.txtHeader_Remark.Tag = "HEADERREMARK"
        Me.txtHeader_Remark.TransparentBox = True
        Me.txtHeader_Remark.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(399, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 14)
        Me.Label23.TabIndex = 82161
        Me.Label23.Text = "Remark"
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
        Me.PNL_View.Location = New System.Drawing.Point(209, 218)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(455, 84)
        Me.PNL_View.TabIndex = 82163
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
        Me.btn_View_Ok.ForeColor = System.Drawing.Color.Black
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
        Me.Btn_Export_Excel.ForeColor = System.Drawing.Color.Black
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
        Me.btn_View_Print.ForeColor = System.Drawing.Color.Black
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
        Me.txt_To.BackColor = System.Drawing.Color.LightCyan
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
        Me.txt_To.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_To.Location = New System.Drawing.Point(266, 27)
        Me.txt_To.MandatoryColor = System.Drawing.Color.LightCyan
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
        Me.txt_From.BackColor = System.Drawing.Color.LightCyan
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
        Me.txt_From.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.txt_From.Location = New System.Drawing.Point(102, 27)
        Me.txt_From.MandatoryColor = System.Drawing.Color.LightCyan
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
        Me.txt_From.TabIndex = 81377
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(703, 463)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 14)
        Me.Label10.TabIndex = 82164
        Me.Label10.Text = "Gst"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(703, 488)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 14)
        Me.Label11.TabIndex = 82165
        Me.Label11.Text = "Fright"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(703, 517)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 14)
        Me.Label12.TabIndex = 82166
        Me.Label12.Text = "Delivery"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(703, 544)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 14)
        Me.Label13.TabIndex = 82167
        Me.Label13.Text = "Payment Terms"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(836, 463)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 14)
        Me.Label14.TabIndex = 82168
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(836, 488)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 14)
        Me.Label15.TabIndex = 82169
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(836, 517)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 14)
        Me.Label16.TabIndex = 82170
        Me.Label16.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(836, 544)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 82171
        Me.Label17.Text = ":"
        '
        'Txt_Fright
        '
        Me.Txt_Fright._AllowSpace = True
        Me.Txt_Fright.AcceptsReturn = True
        Me.Txt_Fright.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Fright.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_Fright.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Fright.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Fright.Check_End_Date_Value_FY = "YES"
        Me.Txt_Fright.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Fright.ClearField = True
        Me.Txt_Fright.CustomInputTypeString = Nothing
        Me.Txt_Fright.Date_for_Database = Nothing
        Me.Txt_Fright.Date_Tag = Nothing
        Me.Txt_Fright.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Fright.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Fright.ExtraValue = ""
        Me.Txt_Fright.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Fright.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Fright.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Fright.ForeColor = System.Drawing.Color.Black
        Me.Txt_Fright.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_Fright.IsValidated = False
        Me.Txt_Fright.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_Fright.Location = New System.Drawing.Point(856, 461)
        Me.Txt_Fright.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_Fright.MandatoryField = False
        Me.Txt_Fright.MaxDate = Nothing
        Me.Txt_Fright.MinDate = Nothing
        Me.Txt_Fright.Name = "Txt_Fright"
        Me.Txt_Fright.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_Fright.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Fright.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Fright.RegularExpression = Nothing
        Me.Txt_Fright.RegularExpressionErrorMessage = Nothing
        Me.Txt_Fright.ShowMessage = False
        Me.Txt_Fright.Size = New System.Drawing.Size(152, 22)
        Me.Txt_Fright.SpacerString = ""
        Me.Txt_Fright.TabIndex = 51
        Me.Txt_Fright.Tag = "HEADERREMARK"
        Me.Txt_Fright.TransparentBox = True
        Me.Txt_Fright.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_Deli
        '
        Me.Txt_Deli._AllowSpace = True
        Me.Txt_Deli.AcceptsReturn = True
        Me.Txt_Deli.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Deli.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_Deli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Deli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Deli.Check_End_Date_Value_FY = "YES"
        Me.Txt_Deli.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Deli.ClearField = True
        Me.Txt_Deli.CustomInputTypeString = Nothing
        Me.Txt_Deli.Date_for_Database = Nothing
        Me.Txt_Deli.Date_Tag = Nothing
        Me.Txt_Deli.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Deli.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Deli.ExtraValue = ""
        Me.Txt_Deli.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Deli.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Deli.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Deli.ForeColor = System.Drawing.Color.Black
        Me.Txt_Deli.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_Deli.IsValidated = False
        Me.Txt_Deli.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_Deli.Location = New System.Drawing.Point(856, 486)
        Me.Txt_Deli.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_Deli.MandatoryField = False
        Me.Txt_Deli.MaxDate = Nothing
        Me.Txt_Deli.MinDate = Nothing
        Me.Txt_Deli.Name = "Txt_Deli"
        Me.Txt_Deli.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_Deli.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Deli.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Deli.RegularExpression = Nothing
        Me.Txt_Deli.RegularExpressionErrorMessage = Nothing
        Me.Txt_Deli.ShowMessage = False
        Me.Txt_Deli.Size = New System.Drawing.Size(152, 22)
        Me.Txt_Deli.SpacerString = ""
        Me.Txt_Deli.TabIndex = 52
        Me.Txt_Deli.Tag = "HEADERREMARK"
        Me.Txt_Deli.TransparentBox = True
        Me.Txt_Deli.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_Delivery
        '
        Me.Txt_Delivery._AllowSpace = True
        Me.Txt_Delivery.AcceptsReturn = True
        Me.Txt_Delivery.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_Delivery.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_Delivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Delivery.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Delivery.Check_End_Date_Value_FY = "YES"
        Me.Txt_Delivery.Check_Start_Date_Value_FY = "YES"
        Me.Txt_Delivery.ClearField = True
        Me.Txt_Delivery.CustomInputTypeString = Nothing
        Me.Txt_Delivery.Date_for_Database = Nothing
        Me.Txt_Delivery.Date_Tag = Nothing
        Me.Txt_Delivery.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_Delivery.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_Delivery.ExtraValue = ""
        Me.Txt_Delivery.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Delivery.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_Delivery.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_Delivery.ForeColor = System.Drawing.Color.Black
        Me.Txt_Delivery.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_Delivery.IsValidated = False
        Me.Txt_Delivery.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_Delivery.Location = New System.Drawing.Point(856, 514)
        Me.Txt_Delivery.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_Delivery.MandatoryField = False
        Me.Txt_Delivery.MaxDate = Nothing
        Me.Txt_Delivery.MinDate = Nothing
        Me.Txt_Delivery.Name = "Txt_Delivery"
        Me.Txt_Delivery.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_Delivery.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_Delivery.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_Delivery.RegularExpression = Nothing
        Me.Txt_Delivery.RegularExpressionErrorMessage = Nothing
        Me.Txt_Delivery.ShowMessage = False
        Me.Txt_Delivery.Size = New System.Drawing.Size(152, 22)
        Me.Txt_Delivery.SpacerString = ""
        Me.Txt_Delivery.TabIndex = 53
        Me.Txt_Delivery.Tag = "HEADERREMARK"
        Me.Txt_Delivery.TransparentBox = True
        Me.Txt_Delivery.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_PaymentTerms
        '
        Me.Txt_PaymentTerms._AllowSpace = True
        Me.Txt_PaymentTerms.AcceptsReturn = True
        Me.Txt_PaymentTerms.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_PaymentTerms.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_PaymentTerms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_PaymentTerms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PaymentTerms.Check_End_Date_Value_FY = "YES"
        Me.Txt_PaymentTerms.Check_Start_Date_Value_FY = "YES"
        Me.Txt_PaymentTerms.ClearField = True
        Me.Txt_PaymentTerms.CustomInputTypeString = Nothing
        Me.Txt_PaymentTerms.Date_for_Database = Nothing
        Me.Txt_PaymentTerms.Date_Tag = Nothing
        Me.Txt_PaymentTerms.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_PaymentTerms.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_PaymentTerms.ExtraValue = ""
        Me.Txt_PaymentTerms.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PaymentTerms.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_PaymentTerms.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_PaymentTerms.ForeColor = System.Drawing.Color.Black
        Me.Txt_PaymentTerms.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_PaymentTerms.IsValidated = False
        Me.Txt_PaymentTerms.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_PaymentTerms.Location = New System.Drawing.Point(856, 542)
        Me.Txt_PaymentTerms.MandatoryColor = System.Drawing.Color.LightCyan
        Me.Txt_PaymentTerms.MandatoryField = False
        Me.Txt_PaymentTerms.MaxDate = Nothing
        Me.Txt_PaymentTerms.MinDate = Nothing
        Me.Txt_PaymentTerms.Name = "Txt_PaymentTerms"
        Me.Txt_PaymentTerms.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_PaymentTerms.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_PaymentTerms.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_PaymentTerms.RegularExpression = Nothing
        Me.Txt_PaymentTerms.RegularExpressionErrorMessage = Nothing
        Me.Txt_PaymentTerms.ShowMessage = False
        Me.Txt_PaymentTerms.Size = New System.Drawing.Size(152, 22)
        Me.Txt_PaymentTerms.SpacerString = ""
        Me.Txt_PaymentTerms.TabIndex = 54
        Me.Txt_PaymentTerms.Tag = "HEADERREMARK"
        Me.Txt_PaymentTerms.TransparentBox = True
        Me.Txt_PaymentTerms.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'QuotationEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1012, 621)
        Me.Controls.Add(Me.Txt_PaymentTerms)
        Me.Controls.Add(Me.Txt_Delivery)
        Me.Controls.Add(Me.Txt_Deli)
        Me.Controls.Add(Me.Txt_Fright)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PNL_View)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtHeader_Remark)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Lbl_Tot_Mtr_Weight)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.lbl_Tot_Amt)
        Me.Controls.Add(Me.lbl_Grid_Header)
        Me.Controls.Add(Me.UC_Buttons1)
        Me.Controls.Add(Me.GrdItem)
        Me.Controls.Add(Me.Ctl_TextBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtChallanNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.txtBookName)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtChallanDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEntryNo)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "QuotationEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quotation Entry"
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

    Friend WithEvents Label41 As Label
    Friend WithEvents txtBookName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txtChallanDate As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtChallanNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAccountName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Ctl_TextBox2 As ctl_TextBox.ctl_TextBox
    Friend WithEvents GrdItem As FlexCell.Grid
    Friend WithEvents UC_Buttons1 As UC_Buttons
    Friend WithEvents lbl_Grid_Header As Label
    Friend WithEvents Lbl_Tot_Mtr_Weight As Label
    Friend WithEvents lbl_Total As Label
    Friend WithEvents lbl_Tot_Amt As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txtHeader_Remark As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label23 As Label
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
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Txt_Fright As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_Deli As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_Delivery As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_PaymentTerms As ctl_TextBox.ctl_TextBox
End Class
