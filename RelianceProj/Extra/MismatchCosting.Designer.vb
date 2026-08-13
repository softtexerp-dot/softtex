<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MismatchCosting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MismatchCosting))
        Me.Lblprocesscost = New System.Windows.Forms.Label()
        Me.UC_Buttons1 = New RelianceProj.UC_Buttons()
        Me.GrdFinishcost = New FlexCell.Grid()
        Me.GrdWeavingcost = New FlexCell.Grid()
        Me.pnl_Print = New System.Windows.Forms.Panel()
        Me.Btn_Print = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.txt_Paper_Type = New ctl_TextBox.ctl_TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.txt_Entry_Date = New ctl_TextBox.ctl_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.Txt_ViewFrom = New ctl_TextBox.ctl_TextBox()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.FirstStage = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutView1 = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.Btn_LayoutLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLayOutSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PnlGrdView = New System.Windows.Forms.GroupBox()
        Me.BtnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_View_Ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Txt_ViewTO = New ctl_TextBox.ctl_TextBox()
        Me.txt_EntryNo = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_Net_Weaving_Cost = New ctl_TextBox.ctl_TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXT_Net_Finish_Cost = New ctl_TextBox.ctl_TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txt_yarn_Sub_Total_amt = New ctl_TextBox.ctl_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GrdItem = New FlexCell.Grid()
        Me.lblTotRem = New System.Windows.Forms.Label()
        Me.Txt_ImportEntry = New ctl_TextBox.ctl_TextBox()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Btn_CreatOverHeadItem = New DevExpress.XtraEditors.SimpleButton()
        Me.pnl_Print.SuspendLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlGrdView.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lblprocesscost
        '
        Me.Lblprocesscost.AutoSize = True
        Me.Lblprocesscost.Location = New System.Drawing.Point(1074, 579)
        Me.Lblprocesscost.Name = "Lblprocesscost"
        Me.Lblprocesscost.Size = New System.Drawing.Size(116, 16)
        Me.Lblprocesscost.TabIndex = 82105
        Me.Lblprocesscost.Text = "Lblprocesscost"
        Me.Lblprocesscost.Visible = False
        '
        'UC_Buttons1
        '
        Me.UC_Buttons1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_Buttons1.Location = New System.Drawing.Point(4, 572)
        Me.UC_Buttons1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_Buttons1.Name = "UC_Buttons1"
        Me.UC_Buttons1.Size = New System.Drawing.Size(939, 44)
        Me.UC_Buttons1.TabIndex = 82104
        '
        'GrdFinishcost
        '
        Me.GrdFinishcost.BackColorBkg = System.Drawing.Color.White
        Me.GrdFinishcost.BackColorFixed = System.Drawing.Color.Khaki
        Me.GrdFinishcost.BackColorFixedSel = System.Drawing.Color.Khaki
        Me.GrdFinishcost.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.GrdFinishcost.CellBorderColor = System.Drawing.Color.Cornsilk
        Me.GrdFinishcost.CellBorderColorFixed = System.Drawing.Color.Black
        Me.GrdFinishcost.CheckedImage = Nothing
        Me.GrdFinishcost.Cols = 15
        Me.GrdFinishcost.DefaultFont = New System.Drawing.Font("Verdana", 8.25!)
        Me.GrdFinishcost.DisplayRowNumber = True
        Me.GrdFinishcost.Enabled = False
        Me.GrdFinishcost.EnableTabKey = False
        Me.GrdFinishcost.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdFinishcost.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GrdFinishcost.Location = New System.Drawing.Point(663, 128)
        Me.GrdFinishcost.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GrdFinishcost.MultiSelect = False
        Me.GrdFinishcost.Name = "GrdFinishcost"
        Me.GrdFinishcost.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.GrdFinishcost.SelectionBorderColor = System.Drawing.Color.Crimson
        Me.GrdFinishcost.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GrdFinishcost.Size = New System.Drawing.Size(442, 418)
        Me.GrdFinishcost.TabIndex = 82046
        Me.GrdFinishcost.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.GrdFinishcost.UncheckedImage = Nothing
        '
        'GrdWeavingcost
        '
        Me.GrdWeavingcost.BackColorBkg = System.Drawing.Color.White
        Me.GrdWeavingcost.BackColorFixed = System.Drawing.Color.Khaki
        Me.GrdWeavingcost.BackColorFixedSel = System.Drawing.Color.Khaki
        Me.GrdWeavingcost.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.GrdWeavingcost.CellBorderColor = System.Drawing.Color.Cornsilk
        Me.GrdWeavingcost.CellBorderColorFixed = System.Drawing.Color.Black
        Me.GrdWeavingcost.CheckedImage = Nothing
        Me.GrdWeavingcost.Cols = 15
        Me.GrdWeavingcost.DefaultFont = New System.Drawing.Font("Verdana", 8.25!)
        Me.GrdWeavingcost.DisplayRowNumber = True
        Me.GrdWeavingcost.Enabled = False
        Me.GrdWeavingcost.EnableTabKey = False
        Me.GrdWeavingcost.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdWeavingcost.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GrdWeavingcost.Location = New System.Drawing.Point(16, 279)
        Me.GrdWeavingcost.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GrdWeavingcost.MultiSelect = False
        Me.GrdWeavingcost.Name = "GrdWeavingcost"
        Me.GrdWeavingcost.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.GrdWeavingcost.SelectionBorderColor = System.Drawing.Color.Crimson
        Me.GrdWeavingcost.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GrdWeavingcost.Size = New System.Drawing.Size(641, 269)
        Me.GrdWeavingcost.TabIndex = 82044
        Me.GrdWeavingcost.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.GrdWeavingcost.UncheckedImage = Nothing
        '
        'pnl_Print
        '
        Me.pnl_Print.BackColor = System.Drawing.Color.SkyBlue
        Me.pnl_Print.Controls.Add(Me.Btn_Print)
        Me.pnl_Print.Controls.Add(Me.BtnClose)
        Me.pnl_Print.Controls.Add(Me.Label101)
        Me.pnl_Print.Controls.Add(Me.txt_Paper_Type)
        Me.pnl_Print.Controls.Add(Me.Label102)
        Me.pnl_Print.Controls.Add(Me.Label103)
        Me.pnl_Print.Controls.Add(Me.Label104)
        Me.pnl_Print.Controls.Add(Me.Label105)
        Me.pnl_Print.Controls.Add(Me.txt_To)
        Me.pnl_Print.Controls.Add(Me.txt_From)
        Me.pnl_Print.Controls.Add(Me.Label106)
        Me.pnl_Print.Controls.Add(Me.Label107)
        Me.pnl_Print.Location = New System.Drawing.Point(201, 211)
        Me.pnl_Print.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnl_Print.Name = "pnl_Print"
        Me.pnl_Print.Size = New System.Drawing.Size(605, 311)
        Me.pnl_Print.TabIndex = 82099
        Me.pnl_Print.Visible = False
        '
        'Btn_Print
        '
        Me.Btn_Print.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Print.Appearance.Options.UseFont = True
        Me.Btn_Print.ImageOptions.Image = CType(resources.GetObject("Btn_Print.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_Print.Location = New System.Drawing.Point(226, 228)
        Me.Btn_Print.Name = "Btn_Print"
        Me.Btn_Print.Size = New System.Drawing.Size(90, 35)
        Me.Btn_Print.TabIndex = 81840
        Me.Btn_Print.Text = "Print"
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.ImageOptions.SvgImage = CType(resources.GetObject("BtnClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnClose.Location = New System.Drawing.Point(321, 228)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(90, 35)
        Me.BtnClose.TabIndex = 81894
        Me.BtnClose.Text = "Close"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.Location = New System.Drawing.Point(239, 153)
        Me.Label101.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(12, 14)
        Me.Label101.TabIndex = 81347
        Me.Label101.Text = ":"
        '
        'txt_Paper_Type
        '
        Me.txt_Paper_Type._AllowSpace = True
        Me.txt_Paper_Type.AcceptsReturn = True
        Me.txt_Paper_Type.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Paper_Type.BackColor = System.Drawing.Color.Lavender
        Me.txt_Paper_Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Paper_Type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Paper_Type.Check_End_Date_Value_FY = "YES"
        Me.txt_Paper_Type.Check_Start_Date_Value_FY = "YES"
        Me.txt_Paper_Type.ClearField = True
        Me.txt_Paper_Type.CustomInputTypeString = Nothing
        Me.txt_Paper_Type.Date_for_Database = Nothing
        Me.txt_Paper_Type.Date_Tag = Nothing
        Me.txt_Paper_Type.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Paper_Type.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Paper_Type.ExtraValue = ""
        Me.txt_Paper_Type.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Paper_Type.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Paper_Type.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Paper_Type.ForeColor = System.Drawing.Color.Black
        Me.txt_Paper_Type.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.SpacerType
        Me.txt_Paper_Type.IsValidated = False
        Me.txt_Paper_Type.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txt_Paper_Type.Location = New System.Drawing.Point(285, 153)
        Me.txt_Paper_Type.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Paper_Type.MandatoryField = False
        Me.txt_Paper_Type.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_Paper_Type.MaxDate = Nothing
        Me.txt_Paper_Type.MaxLength = 70
        Me.txt_Paper_Type.MinDate = Nothing
        Me.txt_Paper_Type.Name = "txt_Paper_Type"
        Me.txt_Paper_Type.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txt_Paper_Type.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Paper_Type.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Paper_Type.RegularExpression = Nothing
        Me.txt_Paper_Type.RegularExpressionErrorMessage = Nothing
        Me.txt_Paper_Type.ShortcutsEnabled = False
        Me.txt_Paper_Type.ShowMessage = False
        Me.txt_Paper_Type.Size = New System.Drawing.Size(158, 22)
        Me.txt_Paper_Type.SpacerString = "PLAIN,PRINT"
        Me.txt_Paper_Type.TabIndex = 81338
        Me.txt_Paper_Type.Tag = "LETTNO"
        Me.txt_Paper_Type.Text = "PLAIN"
        Me.txt_Paper_Type.TransparentBox = True
        Me.txt_Paper_Type.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label102.Location = New System.Drawing.Point(124, 153)
        Me.Label102.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(82, 14)
        Me.Label102.TabIndex = 81335
        Me.Label102.Text = "Paper Type"
        '
        'Label103
        '
        Me.Label103.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label103.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.White
        Me.Label103.Location = New System.Drawing.Point(-3, 2)
        Me.Label103.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(606, 27)
        Me.Label103.TabIndex = 81346
        Me.Label103.Text = "Mix Match Costing Printing System"
        Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.Location = New System.Drawing.Point(239, 83)
        Me.Label104.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(12, 14)
        Me.Label104.TabIndex = 81345
        Me.Label104.Text = ":"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label105.Location = New System.Drawing.Point(239, 117)
        Me.Label105.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(12, 14)
        Me.Label105.TabIndex = 81344
        Me.Label105.Text = ":"
        '
        'txt_To
        '
        Me.txt_To._AllowSpace = True
        Me.txt_To.AcceptsReturn = True
        Me.txt_To.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_To.BackColor = System.Drawing.Color.Lavender
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
        Me.txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.txt_To.IsValidated = False
        Me.txt_To.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txt_To.Location = New System.Drawing.Point(285, 117)
        Me.txt_To.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_To.MandatoryField = False
        Me.txt_To.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_To.MaxDate = Nothing
        Me.txt_To.MaxLength = 70
        Me.txt_To.MinDate = Nothing
        Me.txt_To.Name = "txt_To"
        Me.txt_To.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txt_To.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_To.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_To.RegularExpression = Nothing
        Me.txt_To.RegularExpressionErrorMessage = Nothing
        Me.txt_To.ShortcutsEnabled = False
        Me.txt_To.ShowMessage = False
        Me.txt_To.Size = New System.Drawing.Size(158, 22)
        Me.txt_To.SpacerString = ""
        Me.txt_To.TabIndex = 81337
        Me.txt_To.Tag = "LETTNO"
        Me.txt_To.TransparentBox = True
        Me.txt_To.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'txt_From
        '
        Me.txt_From._AllowSpace = True
        Me.txt_From.AcceptsReturn = True
        Me.txt_From.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_From.BackColor = System.Drawing.Color.Lavender
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
        Me.txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.txt_From.IsValidated = False
        Me.txt_From.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txt_From.Location = New System.Drawing.Point(285, 83)
        Me.txt_From.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_From.MandatoryField = False
        Me.txt_From.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txt_From.MaxDate = Nothing
        Me.txt_From.MaxLength = 70
        Me.txt_From.MinDate = Nothing
        Me.txt_From.Name = "txt_From"
        Me.txt_From.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txt_From.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_From.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_From.RegularExpression = Nothing
        Me.txt_From.RegularExpressionErrorMessage = Nothing
        Me.txt_From.ShortcutsEnabled = False
        Me.txt_From.ShowMessage = False
        Me.txt_From.Size = New System.Drawing.Size(158, 22)
        Me.txt_From.SpacerString = ""
        Me.txt_From.TabIndex = 81336
        Me.txt_From.Tag = "LETTNO"
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.Location = New System.Drawing.Point(124, 83)
        Me.Label106.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(63, 14)
        Me.Label106.TabIndex = 81343
        Me.Label106.Text = "No From"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.Location = New System.Drawing.Point(124, 117)
        Me.Label107.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(45, 14)
        Me.Label107.TabIndex = 81342
        Me.Label107.Text = "No To"
        '
        'txt_Entry_Date
        '
        Me.txt_Entry_Date._AllowSpace = True
        Me.txt_Entry_Date.AcceptsReturn = True
        Me.txt_Entry_Date.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_Entry_Date.BackColor = System.Drawing.Color.Lavender
        Me.txt_Entry_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Entry_Date.Check_End_Date_Value_FY = "YES"
        Me.txt_Entry_Date.Check_Start_Date_Value_FY = "YES"
        Me.txt_Entry_Date.ClearField = True
        Me.txt_Entry_Date.CustomInputTypeString = Nothing
        Me.txt_Entry_Date.Date_for_Database = Nothing
        Me.txt_Entry_Date.Date_Tag = "F_OFFERDATE"
        Me.txt_Entry_Date.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_Entry_Date.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_Entry_Date.ExtraValue = ""
        Me.txt_Entry_Date.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Entry_Date.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_Entry_Date.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_Entry_Date.ForeColor = System.Drawing.Color.Black
        Me.txt_Entry_Date.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
        Me.txt_Entry_Date.IsValidated = False
        Me.txt_Entry_Date.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txt_Entry_Date.Location = New System.Drawing.Point(175, 62)
        Me.txt_Entry_Date.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_Entry_Date.MandatoryField = False
        Me.txt_Entry_Date.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.txt_Entry_Date.MaxDate = Nothing
        Me.txt_Entry_Date.MinDate = Nothing
        Me.txt_Entry_Date.Name = "txt_Entry_Date"
        Me.txt_Entry_Date.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txt_Entry_Date.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_Entry_Date.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_Entry_Date.RegularExpression = Nothing
        Me.txt_Entry_Date.RegularExpressionErrorMessage = Nothing
        Me.txt_Entry_Date.ShortcutsEnabled = False
        Me.txt_Entry_Date.ShowMessage = False
        Me.txt_Entry_Date.Size = New System.Drawing.Size(125, 22)
        Me.txt_Entry_Date.SpacerString = ""
        Me.txt_Entry_Date.TabIndex = 82041
        Me.txt_Entry_Date.Tag = "entry_date"
        Me.txt_Entry_Date.Text = "  /  /    "
        Me.txt_Entry_Date.TransparentBox = True
        Me.txt_Entry_Date.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 14)
        Me.Label2.TabIndex = 82086
        Me.Label2.Text = "Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(138, 62)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 14)
        Me.Label10.TabIndex = 82088
        Me.Label10.Text = ":"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label30.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(15, 259)
        Me.Label30.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(640, 19)
        Me.Label30.TabIndex = 82070
        Me.Label30.Text = " Packing Calculation System"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Btn_LayoutLoad
        '
        Me.Btn_LayoutLoad.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_LayoutLoad.Appearance.Options.UseFont = True
        Me.Btn_LayoutLoad.ImageOptions.Image = CType(resources.GetObject("Btn_LayoutLoad.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_LayoutLoad.Location = New System.Drawing.Point(990, 13)
        Me.Btn_LayoutLoad.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Btn_LayoutLoad.Name = "Btn_LayoutLoad"
        Me.Btn_LayoutLoad.Size = New System.Drawing.Size(37, 32)
        Me.Btn_LayoutLoad.TabIndex = 81914
        Me.Btn_LayoutLoad.Visible = False
        '
        'BtnLayOutSave
        '
        Me.BtnLayOutSave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLayOutSave.Appearance.Options.UseFont = True
        Me.BtnLayOutSave.ImageOptions.Image = CType(resources.GetObject("BtnLayOutSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnLayOutSave.Location = New System.Drawing.Point(950, 13)
        Me.BtnLayOutSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnLayOutSave.Name = "BtnLayOutSave"
        Me.BtnLayOutSave.Size = New System.Drawing.Size(35, 32)
        Me.BtnLayOutSave.TabIndex = 81913
        Me.BtnLayOutSave.Visible = False
        '
        'PnlGrdView
        '
        Me.PnlGrdView.BackColor = System.Drawing.Color.LightCyan
        Me.PnlGrdView.Controls.Add(Me.BtnExport)
        Me.PnlGrdView.Controls.Add(Me.BtnPrint)
        Me.PnlGrdView.Controls.Add(Me.btn_View_Ok)
        Me.PnlGrdView.Controls.Add(Me.Btn_LayoutLoad)
        Me.PnlGrdView.Controls.Add(Me.BtnLayOutSave)
        Me.PnlGrdView.Controls.Add(Me.GridControl1)
        Me.PnlGrdView.Controls.Add(Me.lbl_To)
        Me.PnlGrdView.Controls.Add(Me.lbl_From)
        Me.PnlGrdView.Controls.Add(Me.Txt_ViewTO)
        Me.PnlGrdView.Controls.Add(Me.Txt_ViewFrom)
        Me.PnlGrdView.Location = New System.Drawing.Point(808, 18)
        Me.PnlGrdView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlGrdView.Name = "PnlGrdView"
        Me.PnlGrdView.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlGrdView.Size = New System.Drawing.Size(335, 66)
        Me.PnlGrdView.TabIndex = 82079
        Me.PnlGrdView.TabStop = False
        Me.PnlGrdView.Visible = False
        '
        'BtnExport
        '
        Me.BtnExport.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExport.Appearance.Options.UseFont = True
        Me.BtnExport.ImageOptions.Image = CType(resources.GetObject("BtnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExport.Location = New System.Drawing.Point(853, 12)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(90, 34)
        Me.BtnExport.TabIndex = 81893
        Me.BtnExport.Text = "Export"
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.ImageOptions.Image = CType(resources.GetObject("BtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnPrint.Location = New System.Drawing.Point(757, 12)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 34)
        Me.BtnPrint.TabIndex = 81892
        Me.BtnPrint.Text = "Print"
        '
        'btn_View_Ok
        '
        Me.btn_View_Ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_View_Ok.Appearance.Options.UseFont = True
        Me.btn_View_Ok.ImageOptions.Image = CType(resources.GetObject("btn_View_Ok.ImageOptions.Image"), System.Drawing.Image)
        Me.btn_View_Ok.Location = New System.Drawing.Point(686, 12)
        Me.btn_View_Ok.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_View_Ok.Name = "btn_View_Ok"
        Me.btn_View_Ok.Size = New System.Drawing.Size(64, 34)
        Me.btn_View_Ok.TabIndex = 81891
        Me.btn_View_Ok.Text = "OK"
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
        'txt_EntryNo
        '
        Me.txt_EntryNo._AllowSpace = True
        Me.txt_EntryNo.AcceptsReturn = True
        Me.txt_EntryNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_EntryNo.BackColor = System.Drawing.Color.Lavender
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
        Me.txt_EntryNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EntryNo.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_EntryNo.FontLeaveColor = System.Drawing.Color.Black
        Me.txt_EntryNo.ForeColor = System.Drawing.Color.Black
        Me.txt_EntryNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.txt_EntryNo.IsValidated = False
        Me.txt_EntryNo.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txt_EntryNo.Location = New System.Drawing.Point(175, 33)
        Me.txt_EntryNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_EntryNo.MandatoryField = False
        Me.txt_EntryNo.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.txt_EntryNo.MaxDate = Nothing
        Me.txt_EntryNo.MaxLength = 8
        Me.txt_EntryNo.MinDate = Nothing
        Me.txt_EntryNo.Name = "txt_EntryNo"
        Me.txt_EntryNo.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txt_EntryNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_EntryNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txt_EntryNo.RegularExpression = Nothing
        Me.txt_EntryNo.RegularExpressionErrorMessage = Nothing
        Me.txt_EntryNo.ShortcutsEnabled = False
        Me.txt_EntryNo.ShowMessage = False
        Me.txt_EntryNo.Size = New System.Drawing.Size(125, 22)
        Me.txt_EntryNo.SpacerString = ""
        Me.txt_EntryNo.TabIndex = 82040
        Me.txt_EntryNo.Tag = "entryno"
        Me.txt_EntryNo.TransparentBox = True
        Me.txt_EntryNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 35)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 82080
        Me.Label1.Text = "Entry No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(136, 35)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 82081
        Me.Label4.Text = ":"
        '
        'TXT_Net_Weaving_Cost
        '
        Me.TXT_Net_Weaving_Cost._AllowSpace = True
        Me.TXT_Net_Weaving_Cost.AcceptsReturn = True
        Me.TXT_Net_Weaving_Cost.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TXT_Net_Weaving_Cost.BackColor = System.Drawing.Color.Lavender
        Me.TXT_Net_Weaving_Cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_Net_Weaving_Cost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_Net_Weaving_Cost.Check_End_Date_Value_FY = "YES"
        Me.TXT_Net_Weaving_Cost.Check_Start_Date_Value_FY = "YES"
        Me.TXT_Net_Weaving_Cost.ClearField = True
        Me.TXT_Net_Weaving_Cost.CustomInputTypeString = Nothing
        Me.TXT_Net_Weaving_Cost.Date_for_Database = Nothing
        Me.TXT_Net_Weaving_Cost.Date_Tag = Nothing
        Me.TXT_Net_Weaving_Cost.Enabled = False
        Me.TXT_Net_Weaving_Cost.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TXT_Net_Weaving_Cost.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TXT_Net_Weaving_Cost.ExtraValue = ""
        Me.TXT_Net_Weaving_Cost.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Net_Weaving_Cost.FontFocusColor = System.Drawing.Color.Blue
        Me.TXT_Net_Weaving_Cost.FontLeaveColor = System.Drawing.Color.Red
        Me.TXT_Net_Weaving_Cost.ForeColor = System.Drawing.Color.Red
        Me.TXT_Net_Weaving_Cost.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.TXT_Net_Weaving_Cost.IsValidated = False
        Me.TXT_Net_Weaving_Cost.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.TXT_Net_Weaving_Cost.Location = New System.Drawing.Point(496, 551)
        Me.TXT_Net_Weaving_Cost.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TXT_Net_Weaving_Cost.MandatoryField = False
        Me.TXT_Net_Weaving_Cost.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TXT_Net_Weaving_Cost.MaxDate = Nothing
        Me.TXT_Net_Weaving_Cost.MaxLength = 8
        Me.TXT_Net_Weaving_Cost.MinDate = Nothing
        Me.TXT_Net_Weaving_Cost.Name = "TXT_Net_Weaving_Cost"
        Me.TXT_Net_Weaving_Cost.NormalBorderColor = System.Drawing.Color.Lavender
        Me.TXT_Net_Weaving_Cost.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TXT_Net_Weaving_Cost.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.TXT_Net_Weaving_Cost.RegularExpression = Nothing
        Me.TXT_Net_Weaving_Cost.RegularExpressionErrorMessage = Nothing
        Me.TXT_Net_Weaving_Cost.ShortcutsEnabled = False
        Me.TXT_Net_Weaving_Cost.ShowMessage = False
        Me.TXT_Net_Weaving_Cost.Size = New System.Drawing.Size(149, 22)
        Me.TXT_Net_Weaving_Cost.SpacerString = ""
        Me.TXT_Net_Weaving_Cost.TabIndex = 82045
        Me.TXT_Net_Weaving_Cost.Tag = "Net_Weaving_Cost"
        Me.TXT_Net_Weaving_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_Net_Weaving_Cost.TransparentBox = True
        Me.TXT_Net_Weaving_Cost.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(16, 554)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(355, 14)
        Me.Label13.TabIndex = 82072
        Me.Label13.Text = "Total"
        '
        'TXT_Net_Finish_Cost
        '
        Me.TXT_Net_Finish_Cost._AllowSpace = True
        Me.TXT_Net_Finish_Cost.AcceptsReturn = True
        Me.TXT_Net_Finish_Cost.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TXT_Net_Finish_Cost.BackColor = System.Drawing.Color.Lavender
        Me.TXT_Net_Finish_Cost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_Net_Finish_Cost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_Net_Finish_Cost.Check_End_Date_Value_FY = "YES"
        Me.TXT_Net_Finish_Cost.Check_Start_Date_Value_FY = "YES"
        Me.TXT_Net_Finish_Cost.ClearField = True
        Me.TXT_Net_Finish_Cost.CustomInputTypeString = Nothing
        Me.TXT_Net_Finish_Cost.Date_for_Database = Nothing
        Me.TXT_Net_Finish_Cost.Date_Tag = Nothing
        Me.TXT_Net_Finish_Cost.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TXT_Net_Finish_Cost.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TXT_Net_Finish_Cost.ExtraValue = ""
        Me.TXT_Net_Finish_Cost.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Net_Finish_Cost.FontFocusColor = System.Drawing.Color.Blue
        Me.TXT_Net_Finish_Cost.FontLeaveColor = System.Drawing.Color.Black
        Me.TXT_Net_Finish_Cost.ForeColor = System.Drawing.Color.Red
        Me.TXT_Net_Finish_Cost.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric
        Me.TXT_Net_Finish_Cost.IsValidated = False
        Me.TXT_Net_Finish_Cost.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.TXT_Net_Finish_Cost.Location = New System.Drawing.Point(986, 552)
        Me.TXT_Net_Finish_Cost.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TXT_Net_Finish_Cost.MandatoryField = False
        Me.TXT_Net_Finish_Cost.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.TXT_Net_Finish_Cost.MaxDate = Nothing
        Me.TXT_Net_Finish_Cost.MaxLength = 8
        Me.TXT_Net_Finish_Cost.MinDate = Nothing
        Me.TXT_Net_Finish_Cost.Name = "TXT_Net_Finish_Cost"
        Me.TXT_Net_Finish_Cost.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TXT_Net_Finish_Cost.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TXT_Net_Finish_Cost.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.TXT_Net_Finish_Cost.ReadOnly = True
        Me.TXT_Net_Finish_Cost.RegularExpression = Nothing
        Me.TXT_Net_Finish_Cost.RegularExpressionErrorMessage = Nothing
        Me.TXT_Net_Finish_Cost.ShortcutsEnabled = False
        Me.TXT_Net_Finish_Cost.ShowMessage = False
        Me.TXT_Net_Finish_Cost.Size = New System.Drawing.Size(125, 22)
        Me.TXT_Net_Finish_Cost.SpacerString = ""
        Me.TXT_Net_Finish_Cost.TabIndex = 82047
        Me.TXT_Net_Finish_Cost.Tag = "Net_Finish_Cost"
        Me.TXT_Net_Finish_Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_Net_Finish_Cost.TransparentBox = True
        Me.TXT_Net_Finish_Cost.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label22.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(663, 108)
        Me.Label22.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(442, 20)
        Me.Label22.TabIndex = 82063
        Me.Label22.Text = "Overhead Calculation System"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label62
        '
        Me.Label62.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Red
        Me.Label62.Location = New System.Drawing.Point(527, 236)
        Me.Label62.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(11, 14)
        Me.Label62.TabIndex = 82060
        Me.Label62.Text = ":"
        '
        'txt_yarn_Sub_Total_amt
        '
        Me.txt_yarn_Sub_Total_amt._AllowSpace = True
        Me.txt_yarn_Sub_Total_amt.AcceptsReturn = True
        Me.txt_yarn_Sub_Total_amt.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txt_yarn_Sub_Total_amt.BackColor = System.Drawing.Color.Lavender
        Me.txt_yarn_Sub_Total_amt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_yarn_Sub_Total_amt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_yarn_Sub_Total_amt.Check_End_Date_Value_FY = "YES"
        Me.txt_yarn_Sub_Total_amt.Check_Start_Date_Value_FY = "YES"
        Me.txt_yarn_Sub_Total_amt.ClearField = True
        Me.txt_yarn_Sub_Total_amt.CustomInputTypeString = Nothing
        Me.txt_yarn_Sub_Total_amt.Date_for_Database = Nothing
        Me.txt_yarn_Sub_Total_amt.Date_Tag = Nothing
        Me.txt_yarn_Sub_Total_amt.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txt_yarn_Sub_Total_amt.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txt_yarn_Sub_Total_amt.ExtraValue = ""
        Me.txt_yarn_Sub_Total_amt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_yarn_Sub_Total_amt.FontFocusColor = System.Drawing.Color.Blue
        Me.txt_yarn_Sub_Total_amt.FontLeaveColor = System.Drawing.Color.Red
        Me.txt_yarn_Sub_Total_amt.ForeColor = System.Drawing.Color.Red
        Me.txt_yarn_Sub_Total_amt.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.txt_yarn_Sub_Total_amt.IsValidated = False
        Me.txt_yarn_Sub_Total_amt.LeaveFocusColor = System.Drawing.Color.Lavender
        Me.txt_yarn_Sub_Total_amt.Location = New System.Drawing.Point(544, 234)
        Me.txt_yarn_Sub_Total_amt.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt_yarn_Sub_Total_amt.MandatoryField = False
        Me.txt_yarn_Sub_Total_amt.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.txt_yarn_Sub_Total_amt.MaxDate = Nothing
        Me.txt_yarn_Sub_Total_amt.MaxLength = 8
        Me.txt_yarn_Sub_Total_amt.MinDate = Nothing
        Me.txt_yarn_Sub_Total_amt.Name = "txt_yarn_Sub_Total_amt"
        Me.txt_yarn_Sub_Total_amt.NormalBorderColor = System.Drawing.Color.Lavender
        Me.txt_yarn_Sub_Total_amt.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txt_yarn_Sub_Total_amt.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.TwoDecimal
        Me.txt_yarn_Sub_Total_amt.RegularExpression = Nothing
        Me.txt_yarn_Sub_Total_amt.RegularExpressionErrorMessage = Nothing
        Me.txt_yarn_Sub_Total_amt.ShortcutsEnabled = False
        Me.txt_yarn_Sub_Total_amt.ShowMessage = False
        Me.txt_yarn_Sub_Total_amt.Size = New System.Drawing.Size(111, 22)
        Me.txt_yarn_Sub_Total_amt.SpacerString = ""
        Me.txt_yarn_Sub_Total_amt.TabIndex = 82043
        Me.txt_yarn_Sub_Total_amt.Tag = "yarn_Sub_Total_amt"
        Me.txt_yarn_Sub_Total_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_yarn_Sub_Total_amt.TransparentBox = True
        Me.txt_yarn_Sub_Total_amt.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(641, 19)
        Me.Label3.TabIndex = 82058
        Me.Label3.Text = "Fabric Calculation System( F1=Next Step,F3=Delete Row)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GrdItem
        '
        Me.GrdItem.BackColorBkg = System.Drawing.Color.White
        Me.GrdItem.BackColorFixed = System.Drawing.Color.Khaki
        Me.GrdItem.BackColorFixedSel = System.Drawing.Color.Khaki
        Me.GrdItem.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.GrdItem.CellBorderColor = System.Drawing.Color.Cornsilk
        Me.GrdItem.CellBorderColorFixed = System.Drawing.Color.Black
        Me.GrdItem.CheckedImage = Nothing
        Me.GrdItem.Cols = 15
        Me.GrdItem.DefaultFont = New System.Drawing.Font("Verdana", 8.25!)
        Me.GrdItem.DisplayRowNumber = True
        Me.GrdItem.Enabled = False
        Me.GrdItem.EnableTabKey = False
        Me.GrdItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdItem.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GrdItem.Location = New System.Drawing.Point(16, 128)
        Me.GrdItem.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GrdItem.MultiSelect = False
        Me.GrdItem.Name = "GrdItem"
        Me.GrdItem.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.GrdItem.SelectionBorderColor = System.Drawing.Color.Crimson
        Me.GrdItem.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Me.GrdItem.Size = New System.Drawing.Size(641, 102)
        Me.GrdItem.TabIndex = 82042
        Me.GrdItem.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.GrdItem.UncheckedImage = Nothing
        '
        'lblTotRem
        '
        Me.lblTotRem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRem.ForeColor = System.Drawing.Color.Red
        Me.lblTotRem.Location = New System.Drawing.Point(22, 237)
        Me.lblTotRem.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotRem.Name = "lblTotRem"
        Me.lblTotRem.Size = New System.Drawing.Size(225, 15)
        Me.lblTotRem.TabIndex = 82057
        Me.lblTotRem.Text = "Total"
        '
        'Txt_ImportEntry
        '
        Me.Txt_ImportEntry._AllowSpace = True
        Me.Txt_ImportEntry.AcceptsReturn = True
        Me.Txt_ImportEntry.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.Txt_ImportEntry.BackColor = System.Drawing.Color.Lavender
        Me.Txt_ImportEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ImportEntry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ImportEntry.Check_End_Date_Value_FY = "YES"
        Me.Txt_ImportEntry.Check_Start_Date_Value_FY = "YES"
        Me.Txt_ImportEntry.ClearField = True
        Me.Txt_ImportEntry.CustomInputTypeString = Nothing
        Me.Txt_ImportEntry.Date_for_Database = Nothing
        Me.Txt_ImportEntry.Date_Tag = Nothing
        Me.Txt_ImportEntry.EnterFocusColor = System.Drawing.Color.Bisque
        Me.Txt_ImportEntry.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.Txt_ImportEntry.ExtraValue = ""
        Me.Txt_ImportEntry.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ImportEntry.FontFocusColor = System.Drawing.Color.Blue
        Me.Txt_ImportEntry.FontLeaveColor = System.Drawing.Color.Black
        Me.Txt_ImportEntry.ForeColor = System.Drawing.Color.Black
        Me.Txt_ImportEntry.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.IntegerNumeric
        Me.Txt_ImportEntry.IsValidated = False
        Me.Txt_ImportEntry.LeaveFocusColor = System.Drawing.Color.LightCyan
        Me.Txt_ImportEntry.Location = New System.Drawing.Point(175, 6)
        Me.Txt_ImportEntry.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Txt_ImportEntry.MandatoryField = False
        Me.Txt_ImportEntry.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Txt_ImportEntry.MaxDate = Nothing
        Me.Txt_ImportEntry.MaxLength = 8
        Me.Txt_ImportEntry.MinDate = Nothing
        Me.Txt_ImportEntry.Name = "Txt_ImportEntry"
        Me.Txt_ImportEntry.NormalBorderColor = System.Drawing.Color.SkyBlue
        Me.Txt_ImportEntry.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.Txt_ImportEntry.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.Txt_ImportEntry.RegularExpression = Nothing
        Me.Txt_ImportEntry.RegularExpressionErrorMessage = Nothing
        Me.Txt_ImportEntry.ShortcutsEnabled = False
        Me.Txt_ImportEntry.ShowMessage = False
        Me.Txt_ImportEntry.Size = New System.Drawing.Size(125, 22)
        Me.Txt_ImportEntry.SpacerString = ""
        Me.Txt_ImportEntry.TabIndex = 82078
        Me.Txt_ImportEntry.Tag = "IMPORTENTRYNO"
        Me.Txt_ImportEntry.TransparentBox = True
        Me.Txt_ImportEntry.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label111
        '
        Me.Label111.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.ForeColor = System.Drawing.Color.Blue
        Me.Label111.Location = New System.Drawing.Point(14, 9)
        Me.Label111.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(217, 17)
        Me.Label111.TabIndex = 82077
        Me.Label111.Text = "Import Old Entry No :"
        '
        'Btn_CreatOverHeadItem
        '
        Me.Btn_CreatOverHeadItem.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_CreatOverHeadItem.Appearance.Options.UseFont = True
        Me.Btn_CreatOverHeadItem.ImageOptions.Image = CType(resources.GetObject("Btn_CreatOverHeadItem.ImageOptions.Image"), System.Drawing.Image)
        Me.Btn_CreatOverHeadItem.Location = New System.Drawing.Point(901, 70)
        Me.Btn_CreatOverHeadItem.Name = "Btn_CreatOverHeadItem"
        Me.Btn_CreatOverHeadItem.Size = New System.Drawing.Size(204, 35)
        Me.Btn_CreatOverHeadItem.TabIndex = 82106
        Me.Btn_CreatOverHeadItem.Text = "Create Overhead Item"
        '
        'MismatchCosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1112, 624)
        Me.Controls.Add(Me.Btn_CreatOverHeadItem)
        Me.Controls.Add(Me.pnl_Print)
        Me.Controls.Add(Me.Lblprocesscost)
        Me.Controls.Add(Me.UC_Buttons1)
        Me.Controls.Add(Me.GrdFinishcost)
        Me.Controls.Add(Me.GrdWeavingcost)
        Me.Controls.Add(Me.txt_Entry_Date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.PnlGrdView)
        Me.Controls.Add(Me.txt_EntryNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXT_Net_Weaving_Cost)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TXT_Net_Finish_Cost)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.txt_yarn_Sub_Total_amt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GrdItem)
        Me.Controls.Add(Me.lblTotRem)
        Me.Controls.Add(Me.Txt_ImportEntry)
        Me.Controls.Add(Me.Label111)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MismatchCosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mix Match Costing"
        Me.pnl_Print.ResumeLayout(False)
        Me.pnl_Print.PerformLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FirstStage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlGrdView.ResumeLayout(False)
        Me.PnlGrdView.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lblprocesscost As Label
    Friend WithEvents UC_Buttons1 As UC_Buttons
    Friend WithEvents GrdFinishcost As FlexCell.Grid
    Friend WithEvents GrdWeavingcost As FlexCell.Grid
    Friend WithEvents pnl_Print As Panel
    Friend WithEvents Label101 As Label
    Friend WithEvents txt_Paper_Type As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label102 As Label
    Friend WithEvents Label103 As Label
    Friend WithEvents Label104 As Label
    Friend WithEvents Label105 As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label106 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents txt_Entry_Date As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents Txt_ViewFrom As ctl_TextBox.ctl_TextBox
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents FirstStage As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutView1 As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents Btn_LayoutLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnLayOutSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PnlGrdView As GroupBox
    Friend WithEvents Txt_ViewTO As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_EntryNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXT_Net_Weaving_Cost As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXT_Net_Finish_Cost As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents txt_yarn_Sub_Total_amt As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GrdItem As FlexCell.Grid
    Friend WithEvents lblTotRem As Label
    Friend WithEvents Txt_ImportEntry As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label111 As Label
    Friend WithEvents btn_View_Ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_Print As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btn_CreatOverHeadItem As DevExpress.XtraEditors.SimpleButton
End Class
