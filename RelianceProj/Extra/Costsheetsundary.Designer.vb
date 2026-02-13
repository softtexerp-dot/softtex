<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Costsheetsundary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Costsheetsundary))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Lblsundrytype = New System.Windows.Forms.Label()
        Me.Lblsundaryname = New System.Windows.Forms.Label()
        Me.Txtaddless = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmbsundarytype = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Lblid = New System.Windows.Forms.Label()
        Me.Txtsundaryname = New ctl_TextBox.ctl_TextBox()
        Me.Txtcalcby = New ctl_TextBox.ctl_TextBox()
        Me.PnlGrdView = New System.Windows.Forms.GroupBox()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btn_View_Ok = New System.Windows.Forms.Button()
        Me.But_export = New System.Windows.Forms.Button()
        Me.But_print = New System.Windows.Forms.Button()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.Txt_ViewTO = New ctl_TextBox.ctl_TextBox()
        Me.Txt_ViewFrom = New ctl_TextBox.ctl_TextBox()
        Me.txtdefaultper = New ctl_TextBox.ctl_TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.PnlGrdView.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleDescription = "c"
        Me.GroupBox1.Controls.Add(Me.btnModify)
        Me.GroupBox1.Controls.Add(Me.btnView)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 173)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(405, 53)
        Me.GroupBox1.TabIndex = 81752
        Me.GroupBox1.TabStop = False
        '
        'btnModify
        '
        Me.btnModify.AccessibleDescription = "c"
        Me.btnModify.BackColor = System.Drawing.SystemColors.Menu
        Me.btnModify.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModify.Location = New System.Drawing.Point(67, 10)
        Me.btnModify.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(72, 38)
        Me.btnModify.TabIndex = 72
        Me.btnModify.Text = "Modify"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModify.UseVisualStyleBackColor = False
        '
        'btnView
        '
        Me.btnView.AccessibleDescription = "c"
        Me.btnView.BackColor = System.Drawing.SystemColors.Menu
        Me.btnView.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(220, 10)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(58, 39)
        Me.btnView.TabIndex = 74
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = "c"
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Menu
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(9, 11)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(52, 38)
        Me.btnAdd.TabIndex = 71
        Me.btnAdd.Text = "New"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "c"
        Me.btnSave.BackColor = System.Drawing.SystemColors.Menu
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(287, 11)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(53, 38)
        Me.btnSave.TabIndex = 75
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "c"
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Menu
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(147, 10)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 38)
        Me.btnDelete.TabIndex = 73
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "c"
        Me.btnClose.BackColor = System.Drawing.SystemColors.Menu
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(345, 11)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 38)
        Me.btnClose.TabIndex = 77
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Lblsundrytype
        '
        Me.Lblsundrytype.AutoSize = True
        Me.Lblsundrytype.Location = New System.Drawing.Point(13, 13)
        Me.Lblsundrytype.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblsundrytype.Name = "Lblsundrytype"
        Me.Lblsundrytype.Size = New System.Drawing.Size(105, 13)
        Me.Lblsundrytype.TabIndex = 81753
        Me.Lblsundrytype.Text = "Sundary Type :"
        '
        'Lblsundaryname
        '
        Me.Lblsundaryname.AutoSize = True
        Me.Lblsundaryname.Location = New System.Drawing.Point(13, 46)
        Me.Lblsundaryname.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblsundaryname.Name = "Lblsundaryname"
        Me.Lblsundaryname.Size = New System.Drawing.Size(110, 13)
        Me.Lblsundaryname.TabIndex = 81754
        Me.Lblsundaryname.Text = "Sundary Name :"
        '
        'Txtaddless
        '
        Me.Txtaddless._AllowSpace = True
        Me.Txtaddless.AcceptsReturn = True
        Me.Txtaddless.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txtaddless.BackColor = System.Drawing.Color.MistyRose
        Me.Txtaddless.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtaddless.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtaddless.Check_End_Date_Value_FY = "YES"
        Me.Txtaddless.Check_Start_Date_Value_FY = "YES"
        Me.Txtaddless.ClearField = True
        Me.Txtaddless.CustomInputTypeString = Nothing
        Me.Txtaddless.Date_for_Database = Nothing
        Me.Txtaddless.Date_Tag = Nothing
        Me.Txtaddless.EnterFocusColor = System.Drawing.Color.Transparent
        Me.Txtaddless.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txtaddless.ExtraValue = ""
        Me.Txtaddless.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtaddless.FontFocusColor = System.Drawing.Color.Blue
        Me.Txtaddless.FontLeaveColor = System.Drawing.Color.Black
        Me.Txtaddless.ForeColor = System.Drawing.Color.Black
        Me.Txtaddless.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txtaddless.IsValidated = False
        Me.Txtaddless.LeaveFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Txtaddless.Location = New System.Drawing.Point(135, 71)
        Me.Txtaddless.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txtaddless.MandatoryField = False
        Me.Txtaddless.MaxDate = Nothing
        Me.Txtaddless.MinDate = Nothing
        Me.Txtaddless.Name = "Txtaddless"
        Me.Txtaddless.NormalBorderColor = System.Drawing.Color.LightCoral
        Me.Txtaddless.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txtaddless.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txtaddless.ReadOnly = True
        Me.Txtaddless.RegularExpression = Nothing
        Me.Txtaddless.RegularExpressionErrorMessage = Nothing
        Me.Txtaddless.ShowMessage = False
        Me.Txtaddless.Size = New System.Drawing.Size(266, 22)
        Me.Txtaddless.SpacerString = "Add,Less"
        Me.Txtaddless.TabIndex = 3
        Me.Txtaddless.Tag = "VECHNO"
        Me.Txtaddless.Text = "ADD"
        Me.Txtaddless.TransparentBox = True
        Me.Txtaddless.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 81961
        Me.Label1.Text = "Add/Less :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 135)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 81962
        Me.Label2.Text = "Default Per(%) :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 103)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 81963
        Me.Label3.Text = "Calc. By :"
        '
        'Cmbsundarytype
        '
        Me.Cmbsundarytype.BackColor = System.Drawing.Color.MistyRose
        Me.Cmbsundarytype.FormattingEnabled = True
        Me.Cmbsundarytype.Items.AddRange(New Object() {"Yarn Sundary", "Weaving and Grey Cost", "Finish Cost", "Sales Cost"})
        Me.Cmbsundarytype.Location = New System.Drawing.Point(135, 12)
        Me.Cmbsundarytype.Name = "Cmbsundarytype"
        Me.Cmbsundarytype.Size = New System.Drawing.Size(266, 21)
        Me.Cmbsundarytype.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 13)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 81753
        Me.Label4.Text = "Sundary Type :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 46)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 13)
        Me.Label5.TabIndex = 81754
        Me.Label5.Text = "Sundary Name :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 75)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 81961
        Me.Label6.Text = "Add/Less :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 135)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 13)
        Me.Label7.TabIndex = 81962
        Me.Label7.Text = "Default Per(%) :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 103)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 81963
        Me.Label8.Text = "Calc. By :"
        '
        'Lblid
        '
        Me.Lblid.AutoSize = True
        Me.Lblid.Location = New System.Drawing.Point(139, 158)
        Me.Lblid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lblid.Name = "Lblid"
        Me.Lblid.Size = New System.Drawing.Size(0, 13)
        Me.Lblid.TabIndex = 81964
        Me.Lblid.Visible = False
        '
        'Txtsundaryname
        '
        Me.Txtsundaryname._AllowSpace = True
        Me.Txtsundaryname.AcceptsReturn = True
        Me.Txtsundaryname.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txtsundaryname.BackColor = System.Drawing.Color.MistyRose
        Me.Txtsundaryname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtsundaryname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtsundaryname.Check_End_Date_Value_FY = "YES"
        Me.Txtsundaryname.Check_Start_Date_Value_FY = "YES"
        Me.Txtsundaryname.ClearField = True
        Me.Txtsundaryname.CustomInputTypeString = Nothing
        Me.Txtsundaryname.Date_for_Database = Nothing
        Me.Txtsundaryname.Date_Tag = Nothing
        Me.Txtsundaryname.EnterFocusColor = System.Drawing.Color.PeachPuff
        Me.Txtsundaryname.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txtsundaryname.ExtraValue = ""
        Me.Txtsundaryname.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtsundaryname.FontFocusColor = System.Drawing.Color.Blue
        Me.Txtsundaryname.FontLeaveColor = System.Drawing.Color.Black
        Me.Txtsundaryname.ForeColor = System.Drawing.Color.Black
        Me.Txtsundaryname.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.AlphabetsOnly
        Me.Txtsundaryname.IsValidated = False
        Me.Txtsundaryname.LeaveFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Txtsundaryname.Location = New System.Drawing.Point(135, 42)
        Me.Txtsundaryname.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txtsundaryname.MandatoryField = False
        Me.Txtsundaryname.MaxDate = Nothing
        Me.Txtsundaryname.MinDate = Nothing
        Me.Txtsundaryname.Name = "Txtsundaryname"
        Me.Txtsundaryname.NormalBorderColor = System.Drawing.Color.LightCoral
        Me.Txtsundaryname.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txtsundaryname.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txtsundaryname.RegularExpression = Nothing
        Me.Txtsundaryname.RegularExpressionErrorMessage = Nothing
        Me.Txtsundaryname.ShowMessage = False
        Me.Txtsundaryname.Size = New System.Drawing.Size(266, 22)
        Me.Txtsundaryname.SpacerString = ""
        Me.Txtsundaryname.TabIndex = 2
        Me.Txtsundaryname.Tag = "VECHNO"
        Me.Txtsundaryname.TransparentBox = False
        Me.Txtsundaryname.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txtcalcby
        '
        Me.Txtcalcby._AllowSpace = True
        Me.Txtcalcby.AcceptsReturn = True
        Me.Txtcalcby.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txtcalcby.BackColor = System.Drawing.Color.MistyRose
        Me.Txtcalcby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcalcby.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcalcby.Check_End_Date_Value_FY = "YES"
        Me.Txtcalcby.Check_Start_Date_Value_FY = "YES"
        Me.Txtcalcby.ClearField = True
        Me.Txtcalcby.CustomInputTypeString = Nothing
        Me.Txtcalcby.Date_for_Database = Nothing
        Me.Txtcalcby.Date_Tag = Nothing
        Me.Txtcalcby.EnterFocusColor = System.Drawing.Color.PeachPuff
        Me.Txtcalcby.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txtcalcby.ExtraValue = ""
        Me.Txtcalcby.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcalcby.FontFocusColor = System.Drawing.Color.Blue
        Me.Txtcalcby.FontLeaveColor = System.Drawing.Color.Black
        Me.Txtcalcby.ForeColor = System.Drawing.Color.Black
        Me.Txtcalcby.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txtcalcby.IsValidated = False
        Me.Txtcalcby.LeaveFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Txtcalcby.Location = New System.Drawing.Point(135, 100)
        Me.Txtcalcby.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txtcalcby.MandatoryField = False
        Me.Txtcalcby.MaxDate = Nothing
        Me.Txtcalcby.MinDate = Nothing
        Me.Txtcalcby.Name = "Txtcalcby"
        Me.Txtcalcby.NormalBorderColor = System.Drawing.Color.LightCoral
        Me.Txtcalcby.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txtcalcby.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txtcalcby.ReadOnly = True
        Me.Txtcalcby.RegularExpression = Nothing
        Me.Txtcalcby.RegularExpressionErrorMessage = Nothing
        Me.Txtcalcby.ShowMessage = False
        Me.Txtcalcby.Size = New System.Drawing.Size(266, 22)
        Me.Txtcalcby.SpacerString = "Amount,Percentage"
        Me.Txtcalcby.TabIndex = 4
        Me.Txtcalcby.Tag = "VECHNO"
        Me.Txtcalcby.Text = "AMOUNT"
        Me.Txtcalcby.TransparentBox = True
        Me.Txtcalcby.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'PnlGrdView
        '
        Me.PnlGrdView.BackColor = System.Drawing.Color.LightCyan
        Me.PnlGrdView.Controls.Add(Me.Btn_LayoutLoad)
        Me.PnlGrdView.Controls.Add(Me.BtnLayOutSave)
        Me.PnlGrdView.Controls.Add(Me.GridControl1)
        Me.PnlGrdView.Controls.Add(Me.btn_View_Ok)
        Me.PnlGrdView.Controls.Add(Me.But_export)
        Me.PnlGrdView.Controls.Add(Me.But_print)
        Me.PnlGrdView.Controls.Add(Me.lbl_To)
        Me.PnlGrdView.Controls.Add(Me.lbl_From)
        Me.PnlGrdView.Controls.Add(Me.Txt_ViewTO)
        Me.PnlGrdView.Controls.Add(Me.Txt_ViewFrom)
        Me.PnlGrdView.Location = New System.Drawing.Point(626, 42)
        Me.PnlGrdView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlGrdView.Name = "PnlGrdView"
        Me.PnlGrdView.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlGrdView.Size = New System.Drawing.Size(148, 122)
        Me.PnlGrdView.TabIndex = 82004
        Me.PnlGrdView.TabStop = False
        Me.PnlGrdView.Visible = False
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(945, 14)
        Me.Btn_LayoutLoad.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(37, 32)
        Me.Btn_LayoutLoad.TabIndex = 81914
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(907, 14)
        Me.BtnLayOutSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(35, 32)
        Me.BtnLayOutSave.TabIndex = 81913
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl1.Location = New System.Drawing.Point(8, 51)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1097, 523)
        Me.GridControl1.TabIndex = 81898
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.FirstStage, Me.LayoutView1, Me.GridView2})
        '
        'FirstStage
        '
        Me.FirstStage.GridControl = Me.GridControl1
        Me.FirstStage.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.FirstStage.Name = "FirstStage"
        Me.FirstStage.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[False]
        Me.FirstStage.OptionsBehavior.Editable = False
        Me.FirstStage.OptionsEditForm.PopupEditFormWidth = 1067
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
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 1067
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
        Me.btn_View_Ok.Location = New System.Drawing.Point(740, 13)
        Me.btn_View_Ok.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_View_Ok.Name = "btn_View_Ok"
        Me.btn_View_Ok.Size = New System.Drawing.Size(76, 35)
        Me.btn_View_Ok.TabIndex = 81893
        Me.btn_View_Ok.Text = "Ok"
        Me.btn_View_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_View_Ok.UseVisualStyleBackColor = False
        '
        'But_export
        '
        Me.But_export.BackColor = System.Drawing.SystemColors.Menu
        Me.But_export.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_export.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.But_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.But_export.Location = New System.Drawing.Point(859, 12)
        Me.But_export.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.But_export.Name = "But_export"
        Me.But_export.Size = New System.Drawing.Size(45, 37)
        Me.But_export.TabIndex = 81895
        Me.But_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.But_export.UseVisualStyleBackColor = False
        '
        'But_print
        '
        Me.But_print.BackColor = System.Drawing.SystemColors.Menu
        Me.But_print.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.But_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.But_print.Location = New System.Drawing.Point(816, 12)
        Me.But_print.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(43, 36)
        Me.But_print.TabIndex = 81894
        Me.But_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.But_print.UseVisualStyleBackColor = False
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_To.Location = New System.Drawing.Point(252, 23)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(87, 14)
        Me.lbl_To.TabIndex = 81892
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_From.Location = New System.Drawing.Point(17, 24)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(111, 14)
        Me.lbl_From.TabIndex = 81891
        Me.lbl_From.Text = "Date From:"
        '
        'Txt_ViewTO
        '
        Me.Txt_ViewTO._AllowSpace = True
        Me.Txt_ViewTO.AcceptsReturn = True
        Me.Txt_ViewTO.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ViewTO.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ViewTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ViewTO.Check_End_Date_Value_FY = "YES"
        Me.Txt_ViewTO.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ViewTO.ClearField = True
        Me.Txt_ViewTO.CustomInputTypeString = Nothing
        Me.Txt_ViewTO.Date_for_Database = Nothing
        Me.Txt_ViewTO.Date_Tag = Nothing
        Me.Txt_ViewTO.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewTO.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ViewTO.ExtraValue = ""
        Me.Txt_ViewTO.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ViewTO.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ViewTO.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ViewTO.ForeColor = System.Drawing.Color.Black
        Me.Txt_ViewTO.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.Txt_ViewTO.IsValidated = False
        Me.Txt_ViewTO.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_ViewTO.Location = New System.Drawing.Point(340, 20)
        Me.Txt_ViewTO.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ViewTO.MandatoryField = False
        Me.Txt_ViewTO.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_ViewTO.MaxDate = Nothing
        Me.Txt_ViewTO.MinDate = Nothing
        Me.Txt_ViewTO.Name = "Txt_ViewTO"
        Me.Txt_ViewTO.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewTO.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ViewTO.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ViewTO.RegularExpression = Nothing
        Me.Txt_ViewTO.RegularExpressionErrorMessage = Nothing
        Me.Txt_ViewTO.ShowMessage = False
        Me.Txt_ViewTO.Size = New System.Drawing.Size(126, 22)
        Me.Txt_ViewTO.SpacerString = ""
        Me.Txt_ViewTO.TabIndex = 81890
        Me.Txt_ViewTO.Tag = "BOOKNAME"
        Me.Txt_ViewTO.Text = "  /  /    "
        Me.Txt_ViewTO.TransparentBox = True
        Me.Txt_ViewTO.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_ViewFrom
        '
        Me.Txt_ViewFrom._AllowSpace = True
        Me.Txt_ViewFrom.AcceptsReturn = True
        Me.Txt_ViewFrom.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ViewFrom.BackColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ViewFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ViewFrom.Check_End_Date_Value_FY = "YES"
        Me.Txt_ViewFrom.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ViewFrom.ClearField = True
        Me.Txt_ViewFrom.CustomInputTypeString = Nothing
        Me.Txt_ViewFrom.Date_for_Database = Nothing
        Me.Txt_ViewFrom.Date_Tag = Nothing
        Me.Txt_ViewFrom.EnterFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewFrom.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ViewFrom.ExtraValue = ""
        Me.Txt_ViewFrom.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ViewFrom.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ViewFrom.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ViewFrom.ForeColor = System.Drawing.Color.Black
        Me.Txt_ViewFrom.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.Txt_ViewFrom.IsValidated = False
        Me.Txt_ViewFrom.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.Txt_ViewFrom.Location = New System.Drawing.Point(128, 21)
        Me.Txt_ViewFrom.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ViewFrom.MandatoryField = False
        Me.Txt_ViewFrom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_ViewFrom.MaxDate = Nothing
        Me.Txt_ViewFrom.MinDate = Nothing
        Me.Txt_ViewFrom.Name = "Txt_ViewFrom"
        Me.Txt_ViewFrom.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Txt_ViewFrom.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ViewFrom.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ViewFrom.RegularExpression = Nothing
        Me.Txt_ViewFrom.RegularExpressionErrorMessage = Nothing
        Me.Txt_ViewFrom.ShowMessage = False
        Me.Txt_ViewFrom.Size = New System.Drawing.Size(126, 22)
        Me.Txt_ViewFrom.SpacerString = ""
        Me.Txt_ViewFrom.TabIndex = 81889
        Me.Txt_ViewFrom.Tag = "BOOKNAME"
        Me.Txt_ViewFrom.Text = "  /  /    "
        Me.Txt_ViewFrom.TransparentBox = True
        Me.Txt_ViewFrom.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtdefaultper
        '
        Me.txtdefaultper._AllowSpace = True
        Me.txtdefaultper.AcceptsReturn = True
        Me.txtdefaultper.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtdefaultper.BackColor = System.Drawing.Color.MistyRose
        Me.txtdefaultper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdefaultper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdefaultper.Check_End_Date_Value_FY = "YES"
        Me.txtdefaultper.Check_Start_Date_Value_FY = "YES"
        Me.txtdefaultper.ClearField = True
        Me.txtdefaultper.CustomInputTypeString = Nothing
        Me.txtdefaultper.Date_for_Database = Nothing
        Me.txtdefaultper.Date_Tag = Nothing
        Me.txtdefaultper.EnterFocusColor = System.Drawing.Color.PeachPuff
        Me.txtdefaultper.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtdefaultper.ExtraValue = ""
        Me.txtdefaultper.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdefaultper.FontFocusColor = System.Drawing.Color.Blue
        Me.txtdefaultper.FontLeaveColor = System.Drawing.Color.Black
        Me.txtdefaultper.ForeColor = System.Drawing.Color.Black
        Me.txtdefaultper.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.txtdefaultper.IsValidated = False
        Me.txtdefaultper.LeaveFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtdefaultper.Location = New System.Drawing.Point(135, 130)
        Me.txtdefaultper.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtdefaultper.MandatoryField = False
        Me.txtdefaultper.MaxDate = Nothing
        Me.txtdefaultper.MinDate = Nothing
        Me.txtdefaultper.Name = "txtdefaultper"
        Me.txtdefaultper.NormalBorderColor = System.Drawing.Color.LightCoral
        Me.txtdefaultper.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtdefaultper.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txtdefaultper.RegularExpression = Nothing
        Me.txtdefaultper.RegularExpressionErrorMessage = Nothing
        Me.txtdefaultper.ShowMessage = False
        Me.txtdefaultper.Size = New System.Drawing.Size(266, 22)
        Me.txtdefaultper.SpacerString = ""
        Me.txtdefaultper.TabIndex = 5
        Me.txtdefaultper.Tag = "VECHNO"
        Me.txtdefaultper.TransparentBox = True
        Me.txtdefaultper.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Costsheetsundary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(810, 316)
        Me.Controls.Add(Me.PnlGrdView)
        Me.Controls.Add(Me.Lblid)
        Me.Controls.Add(Me.txtdefaultper)
        Me.Controls.Add(Me.Txtcalcby)
        Me.Controls.Add(Me.Txtsundaryname)
        Me.Controls.Add(Me.Cmbsundarytype)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txtaddless)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Lblsundaryname)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lblsundrytype)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Costsheetsundary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costsheet Sundary Type"
        Me.GroupBox1.ResumeLayout(False)
        Me.PnlGrdView.ResumeLayout(False)
        Me.PnlGrdView.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnModify As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Lblsundrytype As Label
    Friend WithEvents Lblsundaryname As Label
    Friend WithEvents Txtaddless As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmbsundarytype As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Lblid As Label
    Friend WithEvents Txtsundaryname As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txtcalcby As ctl_TextBox.ctl_TextBox
    Friend WithEvents PnlGrdView As GroupBox
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_View_Ok As Button
    Friend WithEvents But_export As Button
    Friend WithEvents But_print As Button
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents Txt_ViewTO As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_ViewFrom As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtdefaultper As ctl_TextBox.ctl_TextBox
End Class
