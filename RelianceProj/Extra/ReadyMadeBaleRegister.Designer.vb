<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadyMadeBaleRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadyMadeBaleRegister))
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtChallanNo = New ctl_TextBox.ctl_TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtEntryNo = New ctl_TextBox.ctl_TextBox()
        Me.txtChallan_Date = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_EntryType = New ctl_TextBox.ctl_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_Grid_Header = New System.Windows.Forms.Label()
        Me.GrdItem = New FlexCell.Grid()
        Me.LblQty = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.Pnl_CmdBtnFun = New System.Windows.Forms.GroupBox()
        Me.Btn_ChqRegester = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModify = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtHeader_Remark = New ctl_TextBox.ctl_TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PNL_View = New System.Windows.Forms.GroupBox()
        Me.But_export = New DevExpress.XtraEditors.SimpleButton()
        Me.But_print = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_View_Ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Ctl_TextBox1 = New ctl_TextBox.ctl_TextBox()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.PanlPropartiesWindow = New System.Windows.Forms.GroupBox()
        Me.BtnBrowseExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtExcelFileName = New ctl_TextBox.ctl_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Pnl_CmdBtnFun.SuspendLayout()
        Me.PNL_View.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanlPropartiesWindow.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(10, 70)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(78, 14)
        Me.Label27.TabIndex = 81881
        Me.Label27.Text = "Challan No"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(130, 70)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(12, 14)
        Me.Label28.TabIndex = 81880
        Me.Label28.Text = ":"
        '
        'txtChallanNo
        '
        Me.txtChallanNo._AllowSpace = True
        Me.txtChallanNo.AcceptsReturn = True
        Me.txtChallanNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallanNo.BackColor = System.Drawing.Color.Lavender
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
        Me.txtChallanNo.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txtChallanNo.Location = New System.Drawing.Point(149, 70)
        Me.txtChallanNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtChallanNo.MandatoryField = False
        Me.txtChallanNo.MaxDate = Nothing
        Me.txtChallanNo.MinDate = Nothing
        Me.txtChallanNo.Name = "txtChallanNo"
        Me.txtChallanNo.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txtChallanNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallanNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallanNo.RegularExpression = Nothing
        Me.txtChallanNo.RegularExpressionErrorMessage = Nothing
        Me.txtChallanNo.ShowMessage = False
        Me.txtChallanNo.Size = New System.Drawing.Size(126, 22)
        Me.txtChallanNo.SpacerString = ""
        Me.txtChallanNo.TabIndex = 3
        Me.txtChallanNo.Tag = "CHALLAN_NO"
        Me.txtChallanNo.TransparentBox = True
        Me.txtChallanNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 14)
        Me.Label13.TabIndex = 81879
        Me.Label13.Text = "Entry No."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(130, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 14)
        Me.Label12.TabIndex = 81878
        Me.Label12.Text = ":"
        '
        'txtEntryNo
        '
        Me.txtEntryNo._AllowSpace = True
        Me.txtEntryNo.AcceptsReturn = True
        Me.txtEntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtEntryNo.BackColor = System.Drawing.Color.Lavender
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
        Me.txtEntryNo.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txtEntryNo.Location = New System.Drawing.Point(149, 40)
        Me.txtEntryNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtEntryNo.MandatoryField = False
        Me.txtEntryNo.MaxDate = Nothing
        Me.txtEntryNo.MinDate = Nothing
        Me.txtEntryNo.Name = "txtEntryNo"
        Me.txtEntryNo.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txtEntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtEntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtEntryNo.RegularExpression = Nothing
        Me.txtEntryNo.RegularExpressionErrorMessage = Nothing
        Me.txtEntryNo.ShowMessage = False
        Me.txtEntryNo.Size = New System.Drawing.Size(126, 24)
        Me.txtEntryNo.SpacerString = ""
        Me.txtEntryNo.TabIndex = 2
        Me.txtEntryNo.Tag = "ENTRYNO"
        Me.txtEntryNo.TransparentBox = True
        Me.txtEntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txtChallan_Date
        '
        Me.txtChallan_Date._AllowSpace = True
        Me.txtChallan_Date.AcceptsReturn = True
        Me.txtChallan_Date.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtChallan_Date.BackColor = System.Drawing.Color.Lavender
        Me.txtChallan_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChallan_Date.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChallan_Date.Check_End_Date_Value_FY = "YES"
        Me.txtChallan_Date.Check_Start_Date_Value_FY = "YES"
        Me.txtChallan_Date.ClearField = True
        Me.txtChallan_Date.CustomInputTypeString = Nothing
        Me.txtChallan_Date.Date_for_Database = Nothing
        Me.txtChallan_Date.Date_Tag = "F_CHALLAN_DATE"
        Me.txtChallan_Date.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtChallan_Date.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtChallan_Date.ExtraValue = ""
        Me.txtChallan_Date.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChallan_Date.FontFocusColor = System.Drawing.Color.Blue
        Me.txtChallan_Date.FontLeaveColor = System.Drawing.Color.Black
        Me.txtChallan_Date.ForeColor = System.Drawing.Color.Black
        Me.txtChallan_Date.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txtChallan_Date.IsValidated = False
        Me.txtChallan_Date.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txtChallan_Date.Location = New System.Drawing.Point(149, 94)
        Me.txtChallan_Date.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtChallan_Date.MandatoryField = False
        Me.txtChallan_Date.MaxDate = Nothing
        Me.txtChallan_Date.MaxLength = 6
        Me.txtChallan_Date.MinDate = Nothing
        Me.txtChallan_Date.Name = "txtChallan_Date"
        Me.txtChallan_Date.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txtChallan_Date.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtChallan_Date.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtChallan_Date.RegularExpression = Nothing
        Me.txtChallan_Date.RegularExpressionErrorMessage = Nothing
        Me.txtChallan_Date.ShowMessage = False
        Me.txtChallan_Date.Size = New System.Drawing.Size(126, 22)
        Me.txtChallan_Date.SpacerString = ""
        Me.txtChallan_Date.TabIndex = 4
        Me.txtChallan_Date.Tag = "CHALLAN_DATE"
        Me.txtChallan_Date.Text = "  /  /    "
        Me.txtChallan_Date.TransparentBox = True
        Me.txtChallan_Date.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 81876
        Me.Label1.Text = "Challan Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(130, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 14)
        Me.Label2.TabIndex = 81877
        Me.Label2.Text = ":"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(130, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 14)
        Me.Label3.TabIndex = 81886
        Me.Label3.Text = ":"
        '
        'Txt_EntryType
        '
        Me.Txt_EntryType._AllowSpace = True
        Me.Txt_EntryType.AcceptsReturn = True
        Me.Txt_EntryType.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_EntryType.BackColor = System.Drawing.Color.Lavender
        Me.Txt_EntryType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_EntryType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_EntryType.Check_End_Date_Value_FY = "YES"
        Me.Txt_EntryType.Check_Start_Date_Value_FY = "YES"
        Me.Txt_EntryType.ClearField = True
        Me.Txt_EntryType.CustomInputTypeString = Nothing
        Me.Txt_EntryType.Date_for_Database = Nothing
        Me.Txt_EntryType.Date_Tag = Nothing
        Me.Txt_EntryType.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_EntryType.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_EntryType.ExtraValue = ""
        Me.Txt_EntryType.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_EntryType.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_EntryType.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_EntryType.ForeColor = System.Drawing.Color.Black
        Me.Txt_EntryType.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Txt_EntryType.IsValidated = False
        Me.Txt_EntryType.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.Txt_EntryType.Location = New System.Drawing.Point(149, 12)
        Me.Txt_EntryType.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_EntryType.MandatoryField = False
        Me.Txt_EntryType.MaxDate = Nothing
        Me.Txt_EntryType.MinDate = Nothing
        Me.Txt_EntryType.Name = "Txt_EntryType"
        Me.Txt_EntryType.NormalBorderColor = System.Drawing.Color.Lavender
        Me.Txt_EntryType.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_EntryType.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_EntryType.RegularExpression = Nothing
        Me.Txt_EntryType.RegularExpressionErrorMessage = Nothing
        Me.Txt_EntryType.ShowMessage = False
        Me.Txt_EntryType.Size = New System.Drawing.Size(126, 22)
        Me.Txt_EntryType.SpacerString = "INWARD,OUTWARD"
        Me.Txt_EntryType.TabIndex = 1
        Me.Txt_EntryType.Tag = "VECHNO"
        Me.Txt_EntryType.Text = "INWARD"
        Me.Txt_EntryType.TransparentBox = True
        Me.Txt_EntryType.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 81885
        Me.Label4.Text = "Entry Type"
        '
        'lbl_Grid_Header
        '
        Me.lbl_Grid_Header.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lbl_Grid_Header.Font = New System.Drawing.Font("Trebuchet MS", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grid_Header.ForeColor = System.Drawing.Color.White
        Me.lbl_Grid_Header.Location = New System.Drawing.Point(2, 123)
        Me.lbl_Grid_Header.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Grid_Header.Name = "lbl_Grid_Header"
        Me.lbl_Grid_Header.Size = New System.Drawing.Size(1014, 23)
        Me.lbl_Grid_Header.TabIndex = 81887
        Me.lbl_Grid_Header.Text = "F1=Exit,F3=Delete Row,Size Coloumn F11=Multy Bale Selection"
        Me.lbl_Grid_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrdItem
        '
        Me.GrdItem.AllowUserReorderColumn = True
        Me.GrdItem.AllowUserResizing = FlexCell.ResizeEnum.None
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
        Me.GrdItem.DefaultFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrdItem.DefaultRowHeight = CType(25, Short)
        Me.GrdItem.DisplayRowNumber = True
        Me.GrdItem.EnableTabKey = False
        Me.GrdItem.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Light3D
        Me.GrdItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdItem.GridColor = System.Drawing.Color.SlateGray
        Me.GrdItem.Location = New System.Drawing.Point(2, 146)
        Me.GrdItem.MultiSelect = False
        Me.GrdItem.Name = "GrdItem"
        Me.GrdItem.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.GrdItem.ScrollBars = FlexCell.ScrollBarsEnum.None
        Me.GrdItem.SelectionBorderColor = System.Drawing.Color.Blue
        Me.GrdItem.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GrdItem.Size = New System.Drawing.Size(1014, 367)
        Me.GrdItem.TabIndex = 81888
        Me.GrdItem.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.GrdItem.UncheckedImage = CType(resources.GetObject("GrdItem.UncheckedImage"), System.Drawing.Bitmap)
        '
        'LblQty
        '
        Me.LblQty.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQty.Location = New System.Drawing.Point(518, 532)
        Me.LblQty.Name = "LblQty"
        Me.LblQty.Size = New System.Drawing.Size(70, 14)
        Me.LblQty.TabIndex = 81913
        Me.LblQty.Text = "0.00"
        Me.LblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.Location = New System.Drawing.Point(5, 532)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(49, 14)
        Me.LblTotal.TabIndex = 81910
        Me.LblTotal.Text = "Total :"
        '
        'Pnl_CmdBtnFun
        '
        Me.Pnl_CmdBtnFun.Controls.Add(Me.Btn_ChqRegester)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.btnClose)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.BtnPrint)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.btnSave)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.btnView)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.btnDelete)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.btnModify)
        Me.Pnl_CmdBtnFun.Controls.Add(Me.btnAdd)
        Me.Pnl_CmdBtnFun.Location = New System.Drawing.Point(2, 545)
        Me.Pnl_CmdBtnFun.Margin = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.Pnl_CmdBtnFun.Name = "Pnl_CmdBtnFun"
        Me.Pnl_CmdBtnFun.Padding = New System.Windows.Forms.Padding(2, 5, 2, 5)
        Me.Pnl_CmdBtnFun.Size = New System.Drawing.Size(1193, 52)
        Me.Pnl_CmdBtnFun.TabIndex = 81914
        Me.Pnl_CmdBtnFun.TabStop = False
        '
        'Btn_ChqRegester
        '
        Me.Btn_ChqRegester.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_ChqRegester.Appearance.Options.UseFont = True
        Me.Btn_ChqRegester.ImageOptions.Image = CType(resources.GetObject("Btn_ChqRegester.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_ChqRegester.Location = New System.Drawing.Point(632, 11)
        Me.Btn_ChqRegester.Name = "Btn_ChqRegester"
        Me.Btn_ChqRegester.Size = New System.Drawing.Size(143, 36)
        Me.Btn_ChqRegester.TabIndex = 82226
        Me.Btn_ChqRegester.Text = "Stock Display"
        '
        'btnClose
        '
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.ImageOptions.Image = CType(resources.GetObject("btnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(782, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 36)
        Me.btnClose.TabIndex = 82227
        Me.btnClose.Text = "Close"
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.ImageOptions.Image = CType(resources.GetObject("BtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(539, 11)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(87, 36)
        Me.BtnPrint.TabIndex = 82225
        Me.BtnPrint.Text = "Print"
        '
        'btnSave
        '
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(447, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 36)
        Me.btnSave.TabIndex = 82224
        Me.btnSave.Text = "Save"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(358, 11)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 36)
        Me.btnView.TabIndex = 82223
        Me.btnView.Text = "View"
        '
        'btnDelete
        '
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(261, 11)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(91, 36)
        Me.btnDelete.TabIndex = 82222
        Me.btnDelete.Text = "Delete"
        '
        'btnModify
        '
        Me.btnModify.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Appearance.Options.UseFont = True
        Me.btnModify.ImageOptions.Image = CType(resources.GetObject("btnModify.ImageOptions.Image"), System.Drawing.Image)
        Me.btnModify.Location = New System.Drawing.Point(169, 11)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(87, 36)
        Me.btnModify.TabIndex = 82221
        Me.btnModify.Text = "Modify"
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.ImageOptions.Image = CType(resources.GetObject("btnAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(89, 11)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(74, 36)
        Me.btnAdd.TabIndex = 82220
        Me.btnAdd.Text = "New"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(430, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(12, 14)
        Me.Label24.TabIndex = 81917
        Me.Label24.Text = ":"
        '
        'txtHeader_Remark
        '
        Me.txtHeader_Remark._AllowSpace = True
        Me.txtHeader_Remark.AcceptsReturn = True
        Me.txtHeader_Remark.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtHeader_Remark.BackColor = System.Drawing.Color.Lavender
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
        Me.txtHeader_Remark.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txtHeader_Remark.Location = New System.Drawing.Point(448, 9)
        Me.txtHeader_Remark.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtHeader_Remark.MandatoryField = False
        Me.txtHeader_Remark.MaxDate = Nothing
        Me.txtHeader_Remark.MinDate = Nothing
        Me.txtHeader_Remark.Name = "txtHeader_Remark"
        Me.txtHeader_Remark.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txtHeader_Remark.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtHeader_Remark.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtHeader_Remark.RegularExpression = Nothing
        Me.txtHeader_Remark.RegularExpressionErrorMessage = Nothing
        Me.txtHeader_Remark.ShowMessage = False
        Me.txtHeader_Remark.Size = New System.Drawing.Size(232, 22)
        Me.txtHeader_Remark.SpacerString = ""
        Me.txtHeader_Remark.TabIndex = 5
        Me.txtHeader_Remark.Tag = "HEADERREMARK"
        Me.txtHeader_Remark.TransparentBox = True
        Me.txtHeader_Remark.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(364, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(58, 14)
        Me.Label23.TabIndex = 81916
        Me.Label23.Text = "Remark"
        '
        'PNL_View
        '
        Me.PNL_View.BackColor = System.Drawing.Color.LightCyan
        Me.PNL_View.Controls.Add(Me.But_export)
        Me.PNL_View.Controls.Add(Me.But_print)
        Me.PNL_View.Controls.Add(Me.btn_View_Ok)
        Me.PNL_View.Controls.Add(Me.Btn_LayoutLoad)
        Me.PNL_View.Controls.Add(Me.BtnLayOutSave)
        Me.PNL_View.Controls.Add(Me.GridControl1)
        Me.PNL_View.Controls.Add(Me.Label36)
        Me.PNL_View.Controls.Add(Me.Ctl_TextBox1)
        Me.PNL_View.Controls.Add(Me.lbl_To)
        Me.PNL_View.Controls.Add(Me.lbl_From)
        Me.PNL_View.Controls.Add(Me.txt_To)
        Me.PNL_View.Controls.Add(Me.txt_From)
        Me.PNL_View.Location = New System.Drawing.Point(117, 223)
        Me.PNL_View.Name = "PNL_View"
        Me.PNL_View.Size = New System.Drawing.Size(891, 122)
        Me.PNL_View.TabIndex = 81918
        Me.PNL_View.TabStop = False
        Me.PNL_View.Visible = False
        '
        'But_export
        '
        Me.But_export.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_export.Appearance.Options.UseFont = True
        Me.But_export.ImageOptions.Image = CType(resources.GetObject("But_export.ImageOptions.Image"), System.Drawing.Image)
        Me.But_export.Location = New System.Drawing.Point(713, 16)
        Me.But_export.Name = "But_export"
        Me.But_export.Size = New System.Drawing.Size(90, 34)
        Me.But_export.TabIndex = 81895
        Me.But_export.Text = "Export"
        '
        'But_print
        '
        Me.But_print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_print.Appearance.Options.UseFont = True
        Me.But_print.ImageOptions.Image = CType(resources.GetObject("But_print.ImageOptions.Image"), System.Drawing.Image)
        Me.But_print.Location = New System.Drawing.Point(620, 16)
        Me.But_print.Name = "But_print"
        Me.But_print.Size = New System.Drawing.Size(90, 34)
        Me.But_print.TabIndex = 81893
        Me.But_print.Text = "Print"
        '
        'btn_View_Ok
        '
        Me.btn_View_Ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_View_Ok.Appearance.Options.UseFont = True
        Me.btn_View_Ok.ImageOptions.Image = CType(resources.GetObject("btn_View_Ok.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_View_Ok.Location = New System.Drawing.Point(553, 16)
        Me.btn_View_Ok.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_View_Ok.Name = "btn_View_Ok"
        Me.btn_View_Ok.Size = New System.Drawing.Size(64, 34)
        Me.btn_View_Ok.TabIndex = 81892
        Me.btn_View_Ok.Text = "OK"
        '
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(929, 17)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(119, 32)
        Me.Btn_LayoutLoad.TabIndex = 81914
        Me.Btn_LayoutLoad.Text = "Load Report"
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(806, 17)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(119, 32)
        Me.BtnLayOutSave.TabIndex = 81913
        Me.BtnLayOutSave.Text = "Save Report"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(7, 61)
        Me.GridControl1.MainView = Me.FirstStage
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1072, 519)
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
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(379, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(49, 14)
        Me.Label36.TabIndex = 81897
        Me.Label36.Text = "View :"
        '
        'Ctl_TextBox1
        '
        Me.Ctl_TextBox1._AllowSpace = True
        Me.Ctl_TextBox1.AcceptsReturn = True
        Me.Ctl_TextBox1.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Ctl_TextBox1.BackColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ctl_TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ctl_TextBox1.Check_End_Date_Value_FY = "YES"
        Me.Ctl_TextBox1.Check_Start_Date_Value_FY = "YES"
        Me.Ctl_TextBox1.ClearField = True
        Me.Ctl_TextBox1.CustomInputTypeString = Nothing
        Me.Ctl_TextBox1.Date_for_Database = Nothing
        Me.Ctl_TextBox1.Date_Tag = Nothing
        Me.Ctl_TextBox1.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Ctl_TextBox1.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Ctl_TextBox1.ExtraValue = ""
        Me.Ctl_TextBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ctl_TextBox1.FontFocusColor = System.Drawing.Color.Blue
        Me.Ctl_TextBox1.FontLeaveColor = System.Drawing.Color.Black
        Me.Ctl_TextBox1.ForeColor = System.Drawing.Color.Black
        Me.Ctl_TextBox1.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.Ctl_TextBox1.IsValidated = False
        Me.Ctl_TextBox1.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox1.Location = New System.Drawing.Point(436, 25)
        Me.Ctl_TextBox1.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Ctl_TextBox1.MandatoryField = False
        Me.Ctl_TextBox1.MaxDate = Nothing
        Me.Ctl_TextBox1.MinDate = Nothing
        Me.Ctl_TextBox1.Name = "Ctl_TextBox1"
        Me.Ctl_TextBox1.NormalBorderColor = System.Drawing.Color.LightCyan
        Me.Ctl_TextBox1.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Ctl_TextBox1.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Ctl_TextBox1.ReadOnly = True
        Me.Ctl_TextBox1.RegularExpression = Nothing
        Me.Ctl_TextBox1.RegularExpressionErrorMessage = Nothing
        Me.Ctl_TextBox1.ShowMessage = False
        Me.Ctl_TextBox1.Size = New System.Drawing.Size(91, 22)
        Me.Ctl_TextBox1.SpacerString = "SUMMERY,DETAIL"
        Me.Ctl_TextBox1.TabIndex = 81891
        Me.Ctl_TextBox1.Tag = "VECHNO"
        Me.Ctl_TextBox1.Text = "SUMMERY"
        Me.Ctl_TextBox1.TransparentBox = True
        Me.Ctl_TextBox1.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_To.Location = New System.Drawing.Point(211, 26)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 81892
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_From.Location = New System.Drawing.Point(13, 27)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 81891
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
        Me.txt_To.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_To.Location = New System.Drawing.Point(277, 23)
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
        Me.txt_To.TabIndex = 81890
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
        Me.txt_From.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txt_From.Location = New System.Drawing.Point(96, 24)
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
        Me.txt_From.TabIndex = 81889
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'PanlPropartiesWindow
        '
        Me.PanlPropartiesWindow.BackColor = System.Drawing.Color.PowderBlue
        Me.PanlPropartiesWindow.Controls.Add(Me.Label6)
        Me.PanlPropartiesWindow.Controls.Add(Me.Label5)
        Me.PanlPropartiesWindow.Controls.Add(Me.BtnBrowseExcel)
        Me.PanlPropartiesWindow.Controls.Add(Me.TxtExcelFileName)
        Me.PanlPropartiesWindow.Location = New System.Drawing.Point(72, 341)
        Me.PanlPropartiesWindow.Name = "PanlPropartiesWindow"
        Me.PanlPropartiesWindow.Size = New System.Drawing.Size(672, 53)
        Me.PanlPropartiesWindow.TabIndex = 81919
        Me.PanlPropartiesWindow.TabStop = False
        Me.PanlPropartiesWindow.Visible = False
        '
        'BtnBrowseExcel
        '
        Me.BtnBrowseExcel.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowseExcel.Appearance.Options.UseFont = True
        Me.BtnBrowseExcel.ImageOptions.Image = CType(resources.GetObject("BtnBrowseExcel.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnBrowseExcel.Location = New System.Drawing.Point(574, 13)
        Me.BtnBrowseExcel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBrowseExcel.Name = "BtnBrowseExcel"
        Me.BtnBrowseExcel.Size = New System.Drawing.Size(91, 34)
        Me.BtnBrowseExcel.TabIndex = 81893
        Me.BtnBrowseExcel.Text = "Select"
        '
        'TxtExcelFileName
        '
        Me.TxtExcelFileName._AllowSpace = True
        Me.TxtExcelFileName.AcceptsReturn = True
        Me.TxtExcelFileName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtExcelFileName.BackColor = System.Drawing.Color.Lavender
        Me.TxtExcelFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtExcelFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExcelFileName.Check_End_Date_Value_FY = "YES"
        Me.TxtExcelFileName.Check_Start_Date_Value_FY = "YES"
        Me.TxtExcelFileName.ClearField = True
        Me.TxtExcelFileName.CustomInputTypeString = Nothing
        Me.TxtExcelFileName.Date_for_Database = Nothing
        Me.TxtExcelFileName.Date_Tag = Nothing
        Me.TxtExcelFileName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtExcelFileName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtExcelFileName.ExtraValue = ""
        Me.TxtExcelFileName.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExcelFileName.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtExcelFileName.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtExcelFileName.ForeColor = System.Drawing.Color.Black
        Me.TxtExcelFileName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtExcelFileName.IsValidated = False
        Me.TxtExcelFileName.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.TxtExcelFileName.Location = New System.Drawing.Point(103, 17)
        Me.TxtExcelFileName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtExcelFileName.MandatoryField = False
        Me.TxtExcelFileName.MaxDate = Nothing
        Me.TxtExcelFileName.MinDate = Nothing
        Me.TxtExcelFileName.Name = "TxtExcelFileName"
        Me.TxtExcelFileName.NormalBorderColor = System.Drawing.Color.Lavender
        Me.TxtExcelFileName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtExcelFileName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtExcelFileName.RegularExpression = Nothing
        Me.TxtExcelFileName.RegularExpressionErrorMessage = Nothing
        Me.TxtExcelFileName.ShowMessage = False
        Me.TxtExcelFileName.Size = New System.Drawing.Size(462, 24)
        Me.TxtExcelFileName.SpacerString = ""
        Me.TxtExcelFileName.TabIndex = 3
        Me.TxtExcelFileName.Tag = "ENTRYNO"
        Me.TxtExcelFileName.TransparentBox = True
        Me.TxtExcelFileName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 14)
        Me.Label5.TabIndex = 81897
        Me.Label5.Text = "File Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(90, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 81898
        Me.Label6.Text = ":"
        '
        'ReadyMadeBaleRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1020, 600)
        Me.Controls.Add(Me.PanlPropartiesWindow)
        Me.Controls.Add(Me.PNL_View)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtHeader_Remark)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Pnl_CmdBtnFun)
        Me.Controls.Add(Me.LblQty)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.GrdItem)
        Me.Controls.Add(Me.lbl_Grid_Header)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_EntryType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtChallanNo)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtEntryNo)
        Me.Controls.Add(Me.txtChallan_Date)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadyMadeBaleRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ready Made Bale Register"
        Me.Pnl_CmdBtnFun.ResumeLayout(False)
        Me.PNL_View.ResumeLayout(False)
        Me.PNL_View.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanlPropartiesWindow.ResumeLayout(False)
        Me.PanlPropartiesWindow.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents txtChallanNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtEntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents txtChallan_Date As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_EntryType As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_Grid_Header As Label
    Friend WithEvents GrdItem As FlexCell.Grid
    Friend WithEvents LblQty As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents Pnl_CmdBtnFun As GroupBox
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
    Friend WithEvents Label36 As Label
    Friend WithEvents Ctl_TextBox1 As ctl_TextBox.ctl_TextBox
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModify As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_ChqRegester As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_View_Ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents But_export As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanlPropartiesWindow As GroupBox
    Friend WithEvents TxtExcelFileName As ctl_TextBox.ctl_TextBox
    Friend WithEvents BtnBrowseExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
End Class
