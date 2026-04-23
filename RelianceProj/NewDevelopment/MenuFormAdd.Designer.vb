<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MenuFormAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuFormAdd))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_MenuSepartor = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuActive = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuType = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuName = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuId = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuOrder = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuDisplayName = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuShortCutKey = New ctl_TextBox.ctl_TextBox()
        Me.Txt_MenuUnderMenuName = New ctl_TextBox.ctl_TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Txt_MenuPosition = New ctl_TextBox.ctl_TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Txt_UnderMenuPositionId = New ctl_TextBox.ctl_TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PnlGrdView = New System.Windows.Forms.GroupBox()
        Me.BtnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PnlGrdView.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(211, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 81812
        Me.Label6.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 14)
        Me.Label8.TabIndex = 81811
        Me.Label8.Text = "Menu ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 14)
        Me.Label1.TabIndex = 81814
        Me.Label1.Text = "Menu Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 79)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 81815
        Me.Label2.Text = "Menu Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 251)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 14)
        Me.Label3.TabIndex = 81816
        Me.Label3.Text = "Menu Order"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 135)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 14)
        Me.Label4.TabIndex = 81817
        Me.Label4.Text = "Insert Is Separator"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 195)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(163, 14)
        Me.Label5.TabIndex = 81818
        Me.Label5.Text = "Under Main Menu Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 282)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 14)
        Me.Label7.TabIndex = 81819
        Me.Label7.Text = "Display Form Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 310)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 14)
        Me.Label9.TabIndex = 81820
        Me.Label9.Text = "Short Cut Key"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 107)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 14)
        Me.Label10.TabIndex = 81821
        Me.Label10.Text = "Active"
        '
        'Txt_MenuSepartor
        '
        Me.Txt_MenuSepartor._AllowSpace = True
        Me.Txt_MenuSepartor.AcceptsReturn = True
        Me.Txt_MenuSepartor.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuSepartor.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuSepartor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuSepartor.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuSepartor.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuSepartor.ClearField = True
        Me.Txt_MenuSepartor.CustomInputTypeString = Nothing
        Me.Txt_MenuSepartor.Date_for_Database = Nothing
        Me.Txt_MenuSepartor.Date_Tag = Nothing
        Me.Txt_MenuSepartor.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuSepartor.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuSepartor.ExtraValue = ""
        Me.Txt_MenuSepartor.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuSepartor.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuSepartor.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuSepartor.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuSepartor.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_MenuSepartor.IsValidated = False
        Me.Txt_MenuSepartor.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuSepartor.Location = New System.Drawing.Point(230, 133)
        Me.Txt_MenuSepartor.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuSepartor.MandatoryField = False
        Me.Txt_MenuSepartor.MaxDate = Nothing
        Me.Txt_MenuSepartor.MinDate = Nothing
        Me.Txt_MenuSepartor.Name = "Txt_MenuSepartor"
        Me.Txt_MenuSepartor.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuSepartor.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuSepartor.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuSepartor.ReadOnly = True
        Me.Txt_MenuSepartor.RegularExpression = Nothing
        Me.Txt_MenuSepartor.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuSepartor.ShowMessage = False
        Me.Txt_MenuSepartor.Size = New System.Drawing.Size(72, 22)
        Me.Txt_MenuSepartor.SpacerString = "False,True"
        Me.Txt_MenuSepartor.TabIndex = 6
        Me.Txt_MenuSepartor.Tag = "MenuIsSparate"
        Me.Txt_MenuSepartor.Text = "False"
        Me.Txt_MenuSepartor.TransparentBox = True
        Me.Txt_MenuSepartor.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuActive
        '
        Me.Txt_MenuActive._AllowSpace = True
        Me.Txt_MenuActive.AcceptsReturn = True
        Me.Txt_MenuActive.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuActive.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuActive.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MenuActive.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuActive.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuActive.ClearField = True
        Me.Txt_MenuActive.CustomInputTypeString = Nothing
        Me.Txt_MenuActive.Date_for_Database = Nothing
        Me.Txt_MenuActive.Date_Tag = Nothing
        Me.Txt_MenuActive.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuActive.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuActive.ExtraValue = ""
        Me.Txt_MenuActive.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuActive.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuActive.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuActive.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuActive.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_MenuActive.IsValidated = False
        Me.Txt_MenuActive.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuActive.Location = New System.Drawing.Point(230, 105)
        Me.Txt_MenuActive.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuActive.MandatoryField = False
        Me.Txt_MenuActive.MaxDate = Nothing
        Me.Txt_MenuActive.MinDate = Nothing
        Me.Txt_MenuActive.Name = "Txt_MenuActive"
        Me.Txt_MenuActive.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuActive.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuActive.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuActive.ReadOnly = True
        Me.Txt_MenuActive.RegularExpression = Nothing
        Me.Txt_MenuActive.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuActive.ShowMessage = False
        Me.Txt_MenuActive.Size = New System.Drawing.Size(72, 22)
        Me.Txt_MenuActive.SpacerString = "YES,NO"
        Me.Txt_MenuActive.TabIndex = 5
        Me.Txt_MenuActive.Tag = "ActiveStatus"
        Me.Txt_MenuActive.Text = "YES"
        Me.Txt_MenuActive.TransparentBox = True
        Me.Txt_MenuActive.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuType
        '
        Me.Txt_MenuType._AllowSpace = True
        Me.Txt_MenuType.AcceptsReturn = True
        Me.Txt_MenuType.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuType.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MenuType.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuType.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuType.ClearField = True
        Me.Txt_MenuType.CustomInputTypeString = Nothing
        Me.Txt_MenuType.Date_for_Database = Nothing
        Me.Txt_MenuType.Date_Tag = Nothing
        Me.Txt_MenuType.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuType.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuType.ExtraValue = ""
        Me.Txt_MenuType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuType.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuType.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuType.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuType.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_MenuType.IsValidated = False
        Me.Txt_MenuType.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuType.Location = New System.Drawing.Point(230, 77)
        Me.Txt_MenuType.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuType.MandatoryField = False
        Me.Txt_MenuType.MaxDate = Nothing
        Me.Txt_MenuType.MinDate = Nothing
        Me.Txt_MenuType.Name = "Txt_MenuType"
        Me.Txt_MenuType.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuType.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuType.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuType.ReadOnly = True
        Me.Txt_MenuType.RegularExpression = Nothing
        Me.Txt_MenuType.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuType.ShowMessage = False
        Me.Txt_MenuType.Size = New System.Drawing.Size(114, 22)
        Me.Txt_MenuType.SpacerString = "MAIN MENU,SUB MENU,PARENT1,PARENT2"
        Me.Txt_MenuType.TabIndex = 3
        Me.Txt_MenuType.Tag = "BOOKNAME"
        Me.Txt_MenuType.Text = "MAIN MENU"
        Me.Txt_MenuType.TransparentBox = True
        Me.Txt_MenuType.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuName
        '
        Me.Txt_MenuName._AllowSpace = True
        Me.Txt_MenuName.AcceptsReturn = True
        Me.Txt_MenuName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuName.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuName.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuName.ClearField = True
        Me.Txt_MenuName.CustomInputTypeString = Nothing
        Me.Txt_MenuName.Date_for_Database = Nothing
        Me.Txt_MenuName.Date_Tag = Nothing
        Me.Txt_MenuName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuName.ExtraValue = ""
        Me.Txt_MenuName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuName.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_MenuName.IsValidated = False
        Me.Txt_MenuName.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuName.Location = New System.Drawing.Point(230, 49)
        Me.Txt_MenuName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuName.MandatoryField = False
        Me.Txt_MenuName.MaxDate = Nothing
        Me.Txt_MenuName.MinDate = Nothing
        Me.Txt_MenuName.Name = "Txt_MenuName"
        Me.Txt_MenuName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuName.RegularExpression = Nothing
        Me.Txt_MenuName.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuName.ShowMessage = False
        Me.Txt_MenuName.Size = New System.Drawing.Size(470, 22)
        Me.Txt_MenuName.SpacerString = ""
        Me.Txt_MenuName.TabIndex = 2
        Me.Txt_MenuName.Tag = "MenuName"
        Me.Txt_MenuName.TransparentBox = True
        Me.Txt_MenuName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuId
        '
        Me.Txt_MenuId._AllowSpace = True
        Me.Txt_MenuId.AcceptsReturn = True
        Me.Txt_MenuId.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuId.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuId.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuId.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuId.ClearField = True
        Me.Txt_MenuId.CustomInputTypeString = Nothing
        Me.Txt_MenuId.Date_for_Database = Nothing
        Me.Txt_MenuId.Date_Tag = Nothing
        Me.Txt_MenuId.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuId.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuId.ExtraValue = ""
        Me.Txt_MenuId.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuId.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuId.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuId.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuId.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SerialNumber
        Me.Txt_MenuId.IsValidated = False
        Me.Txt_MenuId.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuId.Location = New System.Drawing.Point(230, 19)
        Me.Txt_MenuId.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuId.MandatoryField = False
        Me.Txt_MenuId.MaxDate = Nothing
        Me.Txt_MenuId.MinDate = Nothing
        Me.Txt_MenuId.Name = "Txt_MenuId"
        Me.Txt_MenuId.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuId.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuId.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuId.RegularExpression = Nothing
        Me.Txt_MenuId.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuId.ShowMessage = False
        Me.Txt_MenuId.Size = New System.Drawing.Size(114, 22)
        Me.Txt_MenuId.SpacerString = ""
        Me.Txt_MenuId.TabIndex = 1
        Me.Txt_MenuId.Tag = "MainId"
        Me.Txt_MenuId.TransparentBox = True
        Me.Txt_MenuId.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuOrder
        '
        Me.Txt_MenuOrder._AllowSpace = True
        Me.Txt_MenuOrder.AcceptsReturn = True
        Me.Txt_MenuOrder.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuOrder.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuOrder.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuOrder.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuOrder.ClearField = True
        Me.Txt_MenuOrder.CustomInputTypeString = Nothing
        Me.Txt_MenuOrder.Date_for_Database = Nothing
        Me.Txt_MenuOrder.Date_Tag = Nothing
        Me.Txt_MenuOrder.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuOrder.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuOrder.ExtraValue = ""
        Me.Txt_MenuOrder.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuOrder.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuOrder.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuOrder.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuOrder.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SerialNumber
        Me.Txt_MenuOrder.IsValidated = False
        Me.Txt_MenuOrder.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuOrder.Location = New System.Drawing.Point(230, 249)
        Me.Txt_MenuOrder.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuOrder.MandatoryField = False
        Me.Txt_MenuOrder.MaxDate = Nothing
        Me.Txt_MenuOrder.MinDate = Nothing
        Me.Txt_MenuOrder.Name = "Txt_MenuOrder"
        Me.Txt_MenuOrder.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuOrder.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuOrder.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuOrder.RegularExpression = Nothing
        Me.Txt_MenuOrder.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuOrder.ShowMessage = False
        Me.Txt_MenuOrder.Size = New System.Drawing.Size(72, 22)
        Me.Txt_MenuOrder.SpacerString = ""
        Me.Txt_MenuOrder.TabIndex = 10
        Me.Txt_MenuOrder.Tag = "MenuOrderNo"
        Me.Txt_MenuOrder.TransparentBox = True
        Me.Txt_MenuOrder.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuDisplayName
        '
        Me.Txt_MenuDisplayName._AllowSpace = True
        Me.Txt_MenuDisplayName.AcceptsReturn = True
        Me.Txt_MenuDisplayName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuDisplayName.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuDisplayName.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuDisplayName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuDisplayName.ClearField = True
        Me.Txt_MenuDisplayName.CustomInputTypeString = Nothing
        Me.Txt_MenuDisplayName.Date_for_Database = Nothing
        Me.Txt_MenuDisplayName.Date_Tag = Nothing
        Me.Txt_MenuDisplayName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuDisplayName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuDisplayName.ExtraValue = ""
        Me.Txt_MenuDisplayName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuDisplayName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuDisplayName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuDisplayName.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuDisplayName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_MenuDisplayName.IsValidated = False
        Me.Txt_MenuDisplayName.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuDisplayName.Location = New System.Drawing.Point(230, 280)
        Me.Txt_MenuDisplayName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuDisplayName.MandatoryField = False
        Me.Txt_MenuDisplayName.MaxDate = Nothing
        Me.Txt_MenuDisplayName.MinDate = Nothing
        Me.Txt_MenuDisplayName.Name = "Txt_MenuDisplayName"
        Me.Txt_MenuDisplayName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuDisplayName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuDisplayName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuDisplayName.ReadOnly = True
        Me.Txt_MenuDisplayName.RegularExpression = Nothing
        Me.Txt_MenuDisplayName.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuDisplayName.ShowMessage = False
        Me.Txt_MenuDisplayName.Size = New System.Drawing.Size(470, 22)
        Me.Txt_MenuDisplayName.SpacerString = ""
        Me.Txt_MenuDisplayName.TabIndex = 11
        Me.Txt_MenuDisplayName.Tag = "SelectedFormName"
        Me.Txt_MenuDisplayName.TransparentBox = True
        Me.Txt_MenuDisplayName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuShortCutKey
        '
        Me.Txt_MenuShortCutKey._AllowSpace = True
        Me.Txt_MenuShortCutKey.AcceptsReturn = True
        Me.Txt_MenuShortCutKey.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuShortCutKey.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuShortCutKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuShortCutKey.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuShortCutKey.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuShortCutKey.ClearField = True
        Me.Txt_MenuShortCutKey.CustomInputTypeString = Nothing
        Me.Txt_MenuShortCutKey.Date_for_Database = Nothing
        Me.Txt_MenuShortCutKey.Date_Tag = Nothing
        Me.Txt_MenuShortCutKey.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuShortCutKey.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuShortCutKey.ExtraValue = ""
        Me.Txt_MenuShortCutKey.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuShortCutKey.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuShortCutKey.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuShortCutKey.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuShortCutKey.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_MenuShortCutKey.IsValidated = False
        Me.Txt_MenuShortCutKey.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuShortCutKey.Location = New System.Drawing.Point(230, 308)
        Me.Txt_MenuShortCutKey.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuShortCutKey.MandatoryField = False
        Me.Txt_MenuShortCutKey.MaxDate = Nothing
        Me.Txt_MenuShortCutKey.MinDate = Nothing
        Me.Txt_MenuShortCutKey.Name = "Txt_MenuShortCutKey"
        Me.Txt_MenuShortCutKey.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuShortCutKey.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuShortCutKey.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuShortCutKey.RegularExpression = Nothing
        Me.Txt_MenuShortCutKey.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuShortCutKey.ShowMessage = False
        Me.Txt_MenuShortCutKey.Size = New System.Drawing.Size(470, 22)
        Me.Txt_MenuShortCutKey.SpacerString = ""
        Me.Txt_MenuShortCutKey.TabIndex = 12
        Me.Txt_MenuShortCutKey.Tag = "ShortCutKey"
        Me.Txt_MenuShortCutKey.TransparentBox = True
        Me.Txt_MenuShortCutKey.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Txt_MenuUnderMenuName
        '
        Me.Txt_MenuUnderMenuName._AllowSpace = True
        Me.Txt_MenuUnderMenuName.AcceptsReturn = True
        Me.Txt_MenuUnderMenuName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuUnderMenuName.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuUnderMenuName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuUnderMenuName.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuUnderMenuName.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuUnderMenuName.ClearField = True
        Me.Txt_MenuUnderMenuName.CustomInputTypeString = Nothing
        Me.Txt_MenuUnderMenuName.Date_for_Database = Nothing
        Me.Txt_MenuUnderMenuName.Date_Tag = Nothing
        Me.Txt_MenuUnderMenuName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuUnderMenuName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuUnderMenuName.ExtraValue = ""
        Me.Txt_MenuUnderMenuName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuUnderMenuName.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuUnderMenuName.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuUnderMenuName.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuUnderMenuName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.Txt_MenuUnderMenuName.IsValidated = False
        Me.Txt_MenuUnderMenuName.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuUnderMenuName.Location = New System.Drawing.Point(230, 193)
        Me.Txt_MenuUnderMenuName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuUnderMenuName.MandatoryField = False
        Me.Txt_MenuUnderMenuName.MaxDate = Nothing
        Me.Txt_MenuUnderMenuName.MinDate = Nothing
        Me.Txt_MenuUnderMenuName.Name = "Txt_MenuUnderMenuName"
        Me.Txt_MenuUnderMenuName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuUnderMenuName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuUnderMenuName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuUnderMenuName.ReadOnly = True
        Me.Txt_MenuUnderMenuName.RegularExpression = Nothing
        Me.Txt_MenuUnderMenuName.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuUnderMenuName.ShowMessage = False
        Me.Txt_MenuUnderMenuName.Size = New System.Drawing.Size(470, 22)
        Me.Txt_MenuUnderMenuName.SpacerString = ""
        Me.Txt_MenuUnderMenuName.TabIndex = 8
        Me.Txt_MenuUnderMenuName.Tag = "MainMenuName"
        Me.Txt_MenuUnderMenuName.TransparentBox = True
        Me.Txt_MenuUnderMenuName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(211, 51)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 14)
        Me.Label11.TabIndex = 81834
        Me.Label11.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(211, 79)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 14)
        Me.Label12.TabIndex = 81835
        Me.Label12.Text = ":"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(211, 251)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 14)
        Me.Label13.TabIndex = 81836
        Me.Label13.Text = ":"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(211, 107)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 14)
        Me.Label14.TabIndex = 81837
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(211, 135)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 14)
        Me.Label15.TabIndex = 81838
        Me.Label15.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(211, 195)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 14)
        Me.Label16.TabIndex = 81839
        Me.Label16.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(211, 282)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 14)
        Me.Label17.TabIndex = 81840
        Me.Label17.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(211, 310)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 14)
        Me.Label18.TabIndex = 81841
        Me.Label18.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 165)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(99, 14)
        Me.Label19.TabIndex = 81843
        Me.Label19.Text = "Menu Position"
        '
        'Txt_MenuPosition
        '
        Me.Txt_MenuPosition._AllowSpace = True
        Me.Txt_MenuPosition.AcceptsReturn = True
        Me.Txt_MenuPosition.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_MenuPosition.BackColor = System.Drawing.Color.Bisque
        Me.Txt_MenuPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MenuPosition.Check_End_Date_Value_FY = "YES"
        Me.Txt_MenuPosition.Check_Start_Date_Value_FY = "YES"
        Me.Txt_MenuPosition.ClearField = True
        Me.Txt_MenuPosition.CustomInputTypeString = Nothing
        Me.Txt_MenuPosition.Date_for_Database = Nothing
        Me.Txt_MenuPosition.Date_Tag = Nothing
        Me.Txt_MenuPosition.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuPosition.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_MenuPosition.ExtraValue = ""
        Me.Txt_MenuPosition.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MenuPosition.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_MenuPosition.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_MenuPosition.ForeColor = System.Drawing.Color.Black
        Me.Txt_MenuPosition.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SerialNumber
        Me.Txt_MenuPosition.IsValidated = False
        Me.Txt_MenuPosition.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_MenuPosition.Location = New System.Drawing.Point(230, 161)
        Me.Txt_MenuPosition.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_MenuPosition.MandatoryField = False
        Me.Txt_MenuPosition.MaxDate = Nothing
        Me.Txt_MenuPosition.MinDate = Nothing
        Me.Txt_MenuPosition.Name = "Txt_MenuPosition"
        Me.Txt_MenuPosition.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_MenuPosition.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_MenuPosition.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_MenuPosition.ReadOnly = True
        Me.Txt_MenuPosition.RegularExpression = Nothing
        Me.Txt_MenuPosition.RegularExpressionErrorMessage = Nothing
        Me.Txt_MenuPosition.ShowMessage = False
        Me.Txt_MenuPosition.Size = New System.Drawing.Size(72, 22)
        Me.Txt_MenuPosition.SpacerString = ""
        Me.Txt_MenuPosition.TabIndex = 7
        Me.Txt_MenuPosition.Tag = "MenuPosition"
        Me.Txt_MenuPosition.TransparentBox = True
        Me.Txt_MenuPosition.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(211, 165)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(12, 14)
        Me.Label20.TabIndex = 81845
        Me.Label20.Text = ":"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(211, 225)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 14)
        Me.Label21.TabIndex = 81848
        Me.Label21.Text = ":"
        '
        'Txt_UnderMenuPositionId
        '
        Me.Txt_UnderMenuPositionId._AllowSpace = True
        Me.Txt_UnderMenuPositionId.AcceptsReturn = True
        Me.Txt_UnderMenuPositionId.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_UnderMenuPositionId.BackColor = System.Drawing.Color.Bisque
        Me.Txt_UnderMenuPositionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_UnderMenuPositionId.Check_End_Date_Value_FY = "YES"
        Me.Txt_UnderMenuPositionId.Check_Start_Date_Value_FY = "YES"
        Me.Txt_UnderMenuPositionId.ClearField = True
        Me.Txt_UnderMenuPositionId.CustomInputTypeString = Nothing
        Me.Txt_UnderMenuPositionId.Date_for_Database = Nothing
        Me.Txt_UnderMenuPositionId.Date_Tag = Nothing
        Me.Txt_UnderMenuPositionId.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_UnderMenuPositionId.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_UnderMenuPositionId.ExtraValue = ""
        Me.Txt_UnderMenuPositionId.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_UnderMenuPositionId.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_UnderMenuPositionId.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_UnderMenuPositionId.ForeColor = System.Drawing.Color.Black
        Me.Txt_UnderMenuPositionId.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SerialNumber
        Me.Txt_UnderMenuPositionId.IsValidated = False
        Me.Txt_UnderMenuPositionId.LeaveFocusColor = System.Drawing.Color.Bisque
        Me.Txt_UnderMenuPositionId.Location = New System.Drawing.Point(230, 221)
        Me.Txt_UnderMenuPositionId.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_UnderMenuPositionId.MandatoryField = False
        Me.Txt_UnderMenuPositionId.MaxDate = Nothing
        Me.Txt_UnderMenuPositionId.MinDate = Nothing
        Me.Txt_UnderMenuPositionId.Name = "Txt_UnderMenuPositionId"
        Me.Txt_UnderMenuPositionId.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.Txt_UnderMenuPositionId.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_UnderMenuPositionId.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_UnderMenuPositionId.ReadOnly = True
        Me.Txt_UnderMenuPositionId.RegularExpression = Nothing
        Me.Txt_UnderMenuPositionId.RegularExpressionErrorMessage = Nothing
        Me.Txt_UnderMenuPositionId.ShowMessage = False
        Me.Txt_UnderMenuPositionId.Size = New System.Drawing.Size(72, 22)
        Me.Txt_UnderMenuPositionId.SpacerString = ""
        Me.Txt_UnderMenuPositionId.TabIndex = 9
        Me.Txt_UnderMenuPositionId.Tag = "MenuPosition"
        Me.Txt_UnderMenuPositionId.TransparentBox = True
        Me.Txt_UnderMenuPositionId.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(13, 225)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 14)
        Me.Label22.TabIndex = 81847
        Me.Label22.Text = "Under Menu Id"
        '
        'PnlGrdView
        '
        Me.PnlGrdView.BackColor = System.Drawing.Color.LightCyan
        Me.PnlGrdView.Controls.Add(Me.BtnExport)
        Me.PnlGrdView.Controls.Add(Me.SimpleButton2)
        Me.PnlGrdView.Controls.Add(Me.BtnPrint)
        Me.PnlGrdView.Controls.Add(Me.Btn_LayoutLoad)
        Me.PnlGrdView.Controls.Add(Me.BtnLayOutSave)
        Me.PnlGrdView.Controls.Add(Me.GridControl1)
        Me.PnlGrdView.Location = New System.Drawing.Point(782, 12)
        Me.PnlGrdView.Name = "PnlGrdView"
        Me.PnlGrdView.Size = New System.Drawing.Size(86, 175)
        Me.PnlGrdView.TabIndex = 81938
        Me.PnlGrdView.TabStop = False
        Me.PnlGrdView.Visible = False
        '
        'BtnExport
        '
        Me.BtnExport.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Appearance.Options.UseFont = True
        Me.BtnExport.ImageOptions.Image = CType(resources.GetObject("BtnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExport.Location = New System.Drawing.Point(581, 10)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 35)
        Me.BtnExport.TabIndex = 81965
        Me.BtnExport.Text = "Export"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(414, 9)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(64, 34)
        Me.SimpleButton2.TabIndex = 81891
        Me.SimpleButton2.Text = "OK"
        Me.SimpleButton2.Visible = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.ImageOptions.Image = CType(resources.GetObject("BtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(485, 9)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 35)
        Me.BtnPrint.TabIndex = 81964
        Me.BtnPrint.Text = "Print"
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(814, 14)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(28, 32)
        Me.Btn_LayoutLoad.TabIndex = 81914
        Me.Btn_LayoutLoad.Visible = False
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(781, 14)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(26, 32)
        Me.BtnLayOutSave.TabIndex = 81913
        Me.BtnLayOutSave.Visible = False
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(6, 48)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(888, 562)
        Me.GridControl1.TabIndex = 81992
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
        'MenuFormAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(724, 439)
        Me.Controls.Add(Me.PnlGrdView)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Txt_UnderMenuPositionId)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Txt_MenuPosition)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Txt_MenuUnderMenuName)
        Me.Controls.Add(Me.Txt_MenuShortCutKey)
        Me.Controls.Add(Me.Txt_MenuDisplayName)
        Me.Controls.Add(Me.Txt_MenuOrder)
        Me.Controls.Add(Me.Txt_MenuId)
        Me.Controls.Add(Me.Txt_MenuName)
        Me.Controls.Add(Me.Txt_MenuType)
        Me.Controls.Add(Me.Txt_MenuActive)
        Me.Controls.Add(Me.Txt_MenuSepartor)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MenuFormAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Form"
        Me.PnlGrdView.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Txt_MenuSepartor As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuActive As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuType As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuId As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuOrder As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuDisplayName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuShortCutKey As ctl_TextBox.ctl_TextBox
    Friend WithEvents Txt_MenuUnderMenuName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Txt_MenuPosition As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Txt_UnderMenuPositionId As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents PnlGrdView As GroupBox
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
