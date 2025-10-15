<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecivedStoreRoom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecivedStoreRoom))
        Me.TxtMaster = New ctl_TextBox.ctl_TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtIDno = New ctl_TextBox.ctl_TextBox()
        Me.Grid_1 = New FlexCell.Grid()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblItemDisplay = New System.Windows.Forms.Label()
        Me.btn_XLExport = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PnlTrial = New System.Windows.Forms.Panel()
        Me.TxtTrialQty = New ctl_TextBox.ctl_TextBox()
        Me.TxtTrialItem = New ctl_TextBox.ctl_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblCustomerName = New System.Windows.Forms.Label()
        Me.PnlTrial.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtMaster
        '
        Me.TxtMaster._AllowSpace = True
        Me.TxtMaster.AcceptsReturn = True
        Me.TxtMaster.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtMaster.BackColor = System.Drawing.Color.Lavender
        Me.TxtMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMaster.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMaster.Check_End_Date_Value_FY = "YES"
        Me.TxtMaster.Check_Start_Date_Value_FY = "YES"
        Me.TxtMaster.ClearField = True
        Me.TxtMaster.CustomInputTypeString = Nothing
        Me.TxtMaster.Date_for_Database = Nothing
        Me.TxtMaster.Date_Tag = Nothing
        Me.TxtMaster.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtMaster.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.TxtMaster.ExtraValue = ""
        Me.TxtMaster.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaster.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtMaster.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtMaster.ForeColor = System.Drawing.Color.Black
        Me.TxtMaster.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtMaster.IsValidated = False
        Me.TxtMaster.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.TxtMaster.Location = New System.Drawing.Point(152, 59)
        Me.TxtMaster.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtMaster.MandatoryField = False
        Me.TxtMaster.MaxDate = Nothing
        Me.TxtMaster.MinDate = Nothing
        Me.TxtMaster.Name = "TxtMaster"
        Me.TxtMaster.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.TxtMaster.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtMaster.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtMaster.ReadOnly = True
        Me.TxtMaster.RegularExpression = Nothing
        Me.TxtMaster.RegularExpressionErrorMessage = Nothing
        Me.TxtMaster.ShowMessage = False
        Me.TxtMaster.Size = New System.Drawing.Size(276, 22)
        Me.TxtMaster.SpacerString = ""
        Me.TxtMaster.TabIndex = 81758
        Me.TxtMaster.Tag = "BOOKNAME"
        Me.TxtMaster.TransparentBox = True
        Me.TxtMaster.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(134, 59)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 14)
        Me.Label14.TabIndex = 81760
        Me.Label14.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(26, 59)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 14)
        Me.Label15.TabIndex = 81759
        Me.Label15.Text = "Master Name"
        '
        'TxtIDno
        '
        Me.TxtIDno._AllowSpace = True
        Me.TxtIDno.AcceptsReturn = True
        Me.TxtIDno.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtIDno.BackColor = System.Drawing.Color.Lavender
        Me.TxtIDno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIDno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtIDno.Check_End_Date_Value_FY = "YES"
        Me.TxtIDno.Check_Start_Date_Value_FY = "YES"
        Me.TxtIDno.ClearField = True
        Me.TxtIDno.CustomInputTypeString = Nothing
        Me.TxtIDno.Date_for_Database = Nothing
        Me.TxtIDno.Date_Tag = Nothing
        Me.TxtIDno.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtIDno.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.TxtIDno.ExtraValue = ""
        Me.TxtIDno.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIDno.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtIDno.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtIDno.ForeColor = System.Drawing.Color.Black
        Me.TxtIDno.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtIDno.IsValidated = False
        Me.TxtIDno.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.TxtIDno.Location = New System.Drawing.Point(152, 102)
        Me.TxtIDno.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtIDno.MandatoryField = False
        Me.TxtIDno.MaxDate = Nothing
        Me.TxtIDno.MinDate = Nothing
        Me.TxtIDno.Name = "TxtIDno"
        Me.TxtIDno.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.TxtIDno.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtIDno.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtIDno.RegularExpression = Nothing
        Me.TxtIDno.RegularExpressionErrorMessage = Nothing
        Me.TxtIDno.ShowMessage = False
        Me.TxtIDno.Size = New System.Drawing.Size(180, 22)
        Me.TxtIDno.SpacerString = ""
        Me.TxtIDno.TabIndex = 81761
        Me.TxtIDno.Tag = "BOOKNAME"
        Me.TxtIDno.TransparentBox = True
        Me.TxtIDno.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Grid_1
        '
        Me.Grid_1.AllowUserReorderColumn = True
        Me.Grid_1.AllowUserSort = True
        Me.Grid_1.BackColorActiveCellSel = System.Drawing.SystemColors.Highlight
        Me.Grid_1.BackColorBkg = System.Drawing.Color.White
        Me.Grid_1.BackColorFixed = System.Drawing.Color.Khaki
        Me.Grid_1.BackColorFixedSel = System.Drawing.Color.White
        Me.Grid_1.BoldFixedCell = False
        Me.Grid_1.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.Grid_1.CellBorderColor = System.Drawing.Color.Gray
        Me.Grid_1.CellBorderColorFixed = System.Drawing.Color.Gray
        Me.Grid_1.CheckedImage = CType(resources.GetObject("Grid_1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid_1.Cols = 10
        Me.Grid_1.CommentIndicatorColor = System.Drawing.Color.Blue
        Me.Grid_1.DefaultFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Grid_1.DefaultRowHeight = CType(28, Short)
        Me.Grid_1.DisplayRowNumber = True
        Me.Grid_1.EnableTabKey = False
        Me.Grid_1.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Light3D
        Me.Grid_1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid_1.GridColor = System.Drawing.Color.SlateGray
        Me.Grid_1.Location = New System.Drawing.Point(12, 227)
        Me.Grid_1.MultiSelect = False
        Me.Grid_1.Name = "Grid_1"
        Me.Grid_1.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.Grid_1.Rows = 1
        Me.Grid_1.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.Grid_1.SelectionBorderColor = System.Drawing.Color.Blue
        Me.Grid_1.Size = New System.Drawing.Size(718, 406)
        Me.Grid_1.TabIndex = 81762
        Me.Grid_1.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.Grid_1.UncheckedImage = CType(resources.GetObject("Grid_1.UncheckedImage"), System.Drawing.Bitmap)
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(29, 12)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(184, 20)
        Me.RadioButton1.TabIndex = 81763
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Complete Set Recived"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(269, 12)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(117, 20)
        Me.RadioButton2.TabIndex = 81764
        Me.RadioButton2.Text = "Trial Recived"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 14)
        Me.Label1.TabIndex = 81765
        Me.Label1.Text = "Stiching ID No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(134, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 81766
        Me.Label2.Text = ":"
        '
        'LblItemDisplay
        '
        Me.LblItemDisplay.AutoSize = True
        Me.LblItemDisplay.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblItemDisplay.ForeColor = System.Drawing.Color.Red
        Me.LblItemDisplay.Location = New System.Drawing.Point(152, 178)
        Me.LblItemDisplay.Name = "LblItemDisplay"
        Me.LblItemDisplay.Size = New System.Drawing.Size(124, 18)
        Me.LblItemDisplay.TabIndex = 81767
        Me.LblItemDisplay.Text = "Stiching ID No"
        '
        'btn_XLExport
        '
        Me.btn_XLExport.BackColor = System.Drawing.SystemColors.Menu
        Me.btn_XLExport.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_XLExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.btn_XLExport.Image = Global.Textile.My.Resources.Resources.excel
        Me.btn_XLExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_XLExport.Location = New System.Drawing.Point(554, 12)
        Me.btn_XLExport.Name = "btn_XLExport"
        Me.btn_XLExport.Size = New System.Drawing.Size(90, 38)
        Me.btn_XLExport.TabIndex = 81769
        Me.btn_XLExport.Text = "Export"
        Me.btn_XLExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_XLExport.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Menu
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.btnSave.Image = Global.Textile.My.Resources.Resources.SAVE
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(473, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 38)
        Me.btnSave.TabIndex = 81768
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Menu
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        'Me.btnClose.Image = Global.Textile.My.Resources.Resources.CLOSE
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(650, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 38)
        Me.btnClose.TabIndex = 81770
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'PnlTrial
        '
        Me.PnlTrial.Controls.Add(Me.TxtTrialQty)
        Me.PnlTrial.Controls.Add(Me.TxtTrialItem)
        Me.PnlTrial.Controls.Add(Me.Label5)
        Me.PnlTrial.Controls.Add(Me.Label6)
        Me.PnlTrial.Controls.Add(Me.Label3)
        Me.PnlTrial.Controls.Add(Me.Label4)
        Me.PnlTrial.Location = New System.Drawing.Point(434, 60)
        Me.PnlTrial.Name = "PnlTrial"
        Me.PnlTrial.Size = New System.Drawing.Size(305, 77)
        Me.PnlTrial.TabIndex = 81771
        '
        'TxtTrialQty
        '
        Me.TxtTrialQty._AllowSpace = True
        Me.TxtTrialQty.AcceptsReturn = True
        Me.TxtTrialQty.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtTrialQty.BackColor = System.Drawing.Color.Lavender
        Me.TxtTrialQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTrialQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTrialQty.Check_End_Date_Value_FY = "YES"
        Me.TxtTrialQty.Check_Start_Date_Value_FY = "YES"
        Me.TxtTrialQty.ClearField = True
        Me.TxtTrialQty.CustomInputTypeString = Nothing
        Me.TxtTrialQty.Date_for_Database = Nothing
        Me.TxtTrialQty.Date_Tag = Nothing
        Me.TxtTrialQty.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtTrialQty.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.no
        Me.TxtTrialQty.ExtraValue = ""
        Me.TxtTrialQty.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTrialQty.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtTrialQty.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtTrialQty.ForeColor = System.Drawing.Color.Black
        Me.TxtTrialQty.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtTrialQty.IsValidated = False
        Me.TxtTrialQty.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.TxtTrialQty.Location = New System.Drawing.Point(106, 41)
        Me.TxtTrialQty.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtTrialQty.MandatoryField = False
        Me.TxtTrialQty.MaxDate = Nothing
        Me.TxtTrialQty.MinDate = Nothing
        Me.TxtTrialQty.Name = "TxtTrialQty"
        Me.TxtTrialQty.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.TxtTrialQty.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtTrialQty.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtTrialQty.RegularExpression = Nothing
        Me.TxtTrialQty.RegularExpressionErrorMessage = Nothing
        Me.TxtTrialQty.ShowMessage = False
        Me.TxtTrialQty.Size = New System.Drawing.Size(104, 22)
        Me.TxtTrialQty.SpacerString = ""
        Me.TxtTrialQty.TabIndex = 81760
        Me.TxtTrialQty.Tag = "BOOKNAME"
        Me.TxtTrialQty.TransparentBox = True
        Me.TxtTrialQty.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'TxtTrialItem
        '
        Me.TxtTrialItem._AllowSpace = True
        Me.TxtTrialItem.AcceptsReturn = True
        Me.TxtTrialItem.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtTrialItem.BackColor = System.Drawing.Color.Lavender
        Me.TxtTrialItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTrialItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTrialItem.Check_End_Date_Value_FY = "YES"
        Me.TxtTrialItem.Check_Start_Date_Value_FY = "YES"
        Me.TxtTrialItem.ClearField = True
        Me.TxtTrialItem.CustomInputTypeString = Nothing
        Me.TxtTrialItem.Date_for_Database = Nothing
        Me.TxtTrialItem.Date_Tag = Nothing
        Me.TxtTrialItem.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtTrialItem.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtTrialItem.ExtraValue = ""
        Me.TxtTrialItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTrialItem.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtTrialItem.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtTrialItem.ForeColor = System.Drawing.Color.Black
        Me.TxtTrialItem.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtTrialItem.IsValidated = False
        Me.TxtTrialItem.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.TxtTrialItem.Location = New System.Drawing.Point(106, 7)
        Me.TxtTrialItem.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtTrialItem.MandatoryField = False
        Me.TxtTrialItem.MaxDate = Nothing
        Me.TxtTrialItem.MinDate = Nothing
        Me.TxtTrialItem.Name = "TxtTrialItem"
        Me.TxtTrialItem.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.TxtTrialItem.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtTrialItem.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtTrialItem.ReadOnly = True
        Me.TxtTrialItem.RegularExpression = Nothing
        Me.TxtTrialItem.RegularExpressionErrorMessage = Nothing
        Me.TxtTrialItem.ShowMessage = False
        Me.TxtTrialItem.Size = New System.Drawing.Size(190, 22)
        Me.TxtTrialItem.SpacerString = ""
        Me.TxtTrialItem.TabIndex = 81759
        Me.TxtTrialItem.Tag = "BOOKNAME"
        Me.TxtTrialItem.TransparentBox = True
        Me.TxtTrialItem.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(88, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 14)
        Me.Label5.TabIndex = 81764
        Me.Label5.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 14)
        Me.Label6.TabIndex = 81763
        Me.Label6.Text = "Item Qty"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(88, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 81762
        Me.Label3.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 14)
        Me.Label4.TabIndex = 81761
        Me.Label4.Text = "Item Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 14)
        Me.Label7.TabIndex = 81772
        Me.Label7.Text = "Customer Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 14)
        Me.Label8.TabIndex = 81773
        Me.Label8.Text = "Stich Item"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(134, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 14)
        Me.Label9.TabIndex = 81774
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(134, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 14)
        Me.Label10.TabIndex = 81775
        Me.Label10.Text = ":"
        '
        'LblCustomerName
        '
        Me.LblCustomerName.AutoSize = True
        Me.LblCustomerName.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCustomerName.ForeColor = System.Drawing.Color.Red
        Me.LblCustomerName.Location = New System.Drawing.Point(152, 147)
        Me.LblCustomerName.Name = "LblCustomerName"
        Me.LblCustomerName.Size = New System.Drawing.Size(124, 18)
        Me.LblCustomerName.TabIndex = 81776
        Me.LblCustomerName.Text = "Stiching ID No"
        '
        'RecivedStoreRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(742, 636)
        Me.Controls.Add(Me.LblCustomerName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PnlTrial)
        Me.Controls.Add(Me.btn_XLExport)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.LblItemDisplay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Grid_1)
        Me.Controls.Add(Me.TxtIDno)
        Me.Controls.Add(Me.TxtMaster)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecivedStoreRoom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recived Store Room Entry"
        Me.PnlTrial.ResumeLayout(False)
        Me.PnlTrial.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtMaster As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtIDno As ctl_TextBox.ctl_TextBox
    Friend WithEvents Grid_1 As FlexCell.Grid
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblItemDisplay As Label
    Friend WithEvents btn_XLExport As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents PnlTrial As Panel
    Friend WithEvents TxtTrialQty As ctl_TextBox.ctl_TextBox
    Friend WithEvents TxtTrialItem As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblCustomerName As Label
End Class
