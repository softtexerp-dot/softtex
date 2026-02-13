<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Getonlinechallandetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Getonlinechallandetail))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Txt_ProcessStockDisplay = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_To = New System.Windows.Forms.Label()
        Me.lbl_From = New System.Windows.Forms.Label()
        Me.txt_To = New ctl_TextBox.ctl_TextBox()
        Me.txt_From = New ctl_TextBox.ctl_TextBox()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txtbookname = New DevExpress.XtraEditors.TextEdit()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.lblBookcode = New System.Windows.Forms.Label()
        Me.BtnProcessRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.piecepanel = New System.Windows.Forms.Panel()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtbookname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.piecepanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(0, 48)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1183, 573)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
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
        Me.Txt_ProcessStockDisplay.Location = New System.Drawing.Point(443, 16)
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
        Me.Txt_ProcessStockDisplay.Size = New System.Drawing.Size(136, 22)
        Me.Txt_ProcessStockDisplay.SpacerString = "Gray Challan,Process Challan"
        Me.Txt_ProcessStockDisplay.TabIndex = 81959
        Me.Txt_ProcessStockDisplay.Tag = "VECHNO"
        Me.Txt_ProcessStockDisplay.Text = "GRAY CHALLAN"
        Me.Txt_ProcessStockDisplay.TransparentBox = True
        Me.Txt_ProcessStockDisplay.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(345, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 14)
        Me.Label1.TabIndex = 81963
        Me.Label1.Text = "Challan Type :"
        '
        'lbl_To
        '
        Me.lbl_To.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_To.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_To.Location = New System.Drawing.Point(185, 19)
        Me.lbl_To.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_To.Name = "lbl_To"
        Me.lbl_To.Size = New System.Drawing.Size(65, 14)
        Me.lbl_To.TabIndex = 81962
        Me.lbl_To.Text = "Date To:"
        '
        'lbl_From
        '
        Me.lbl_From.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_From.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_From.Location = New System.Drawing.Point(6, 20)
        Me.lbl_From.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_From.Name = "lbl_From"
        Me.lbl_From.Size = New System.Drawing.Size(83, 14)
        Me.lbl_From.TabIndex = 81961
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
        Me.txt_To.Location = New System.Drawing.Point(250, 16)
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
        Me.txt_To.TabIndex = 81958
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
        Me.txt_From.Location = New System.Drawing.Point(89, 16)
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
        Me.txt_From.TabIndex = 81957
        Me.txt_From.Tag = "BOOKNAME"
        Me.txt_From.Text = "  /  /    "
        Me.txt_From.TransparentBox = True
        Me.txt_From.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(824, 7)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(66, 36)
        Me.But_ok.TabIndex = 81961
        Me.But_ok.Text = "Ok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(581, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 14)
        Me.Label2.TabIndex = 81964
        Me.Label2.Text = "Save BookName:"
        '
        'Txtbookname
        '
        Me.Txtbookname.Location = New System.Drawing.Point(699, 18)
        Me.Txtbookname.Name = "Txtbookname"
        Me.Txtbookname.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.Txtbookname.Properties.Appearance.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtbookname.Properties.Appearance.Options.UseBackColor = True
        Me.Txtbookname.Properties.Appearance.Options.UseFont = True
        Me.Txtbookname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.Txtbookname.Size = New System.Drawing.Size(122, 20)
        Me.Txtbookname.TabIndex = 81960
        '
        'btnsave
        '
        Me.btnsave.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Appearance.Options.UseFont = True
        Me.btnsave.Enabled = False
        Me.btnsave.ImageOptions.Image = CType(resources.GetObject("btnsave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnsave.Location = New System.Drawing.Point(1023, 6)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(82, 36)
        Me.btnsave.TabIndex = 81965
        Me.btnsave.Text = "Save"
        '
        'lblBookcode
        '
        Me.lblBookcode.AutoSize = True
        Me.lblBookcode.Location = New System.Drawing.Point(1108, 17)
        Me.lblBookcode.Name = "lblBookcode"
        Me.lblBookcode.Size = New System.Drawing.Size(82, 14)
        Me.lblBookcode.TabIndex = 81966
        Me.lblBookcode.Text = "lblBookcode"
        Me.lblBookcode.Visible = False
        '
        'BtnProcessRefresh
        '
        Me.BtnProcessRefresh.Appearance.BackColor = System.Drawing.Color.Snow
        Me.BtnProcessRefresh.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProcessRefresh.Appearance.ForeColor = System.Drawing.Color.Black
        Me.BtnProcessRefresh.Appearance.Options.UseBackColor = True
        Me.BtnProcessRefresh.Appearance.Options.UseFont = True
        Me.BtnProcessRefresh.Appearance.Options.UseForeColor = True
        Me.BtnProcessRefresh.AutoSize = True
        Me.BtnProcessRefresh.Enabled = False
        Me.BtnProcessRefresh.ImageOptions.Image = CType(resources.GetObject("BtnProcessRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnProcessRefresh.Location = New System.Drawing.Point(892, 6)
        Me.BtnProcessRefresh.Name = "BtnProcessRefresh"
        Me.BtnProcessRefresh.Size = New System.Drawing.Size(129, 36)
        Me.BtnProcessRefresh.TabIndex = 82211
        Me.BtnProcessRefresh.Text = "Piece Match"
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(4, 14)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(648, 379)
        Me.GridControl2.TabIndex = 82212
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.GridControl2.Visible = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'piecepanel
        '
        Me.piecepanel.BackColor = System.Drawing.Color.DarkSlateGray
        Me.piecepanel.Controls.Add(Me.GridControl2)
        Me.piecepanel.Location = New System.Drawing.Point(523, 71)
        Me.piecepanel.Name = "piecepanel"
        Me.piecepanel.Size = New System.Drawing.Size(655, 396)
        Me.piecepanel.TabIndex = 82213
        Me.piecepanel.Visible = False
        '
        'Getonlinechallandetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1184, 621)
        Me.Controls.Add(Me.piecepanel)
        Me.Controls.Add(Me.BtnProcessRefresh)
        Me.Controls.Add(Me.lblBookcode)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Txtbookname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_ProcessStockDisplay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_To)
        Me.Controls.Add(Me.lbl_From)
        Me.Controls.Add(Me.txt_To)
        Me.Controls.Add(Me.txt_From)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.GridControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Name = "Getonlinechallandetail"
        Me.Text = "Get Online Challan Detail"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtbookname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.piecepanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Txt_ProcessStockDisplay As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_To As Label
    Friend WithEvents lbl_From As Label
    Friend WithEvents txt_To As ctl_TextBox.ctl_TextBox
    Friend WithEvents txt_From As ctl_TextBox.ctl_TextBox
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Txtbookname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblBookcode As Label
    Friend WithEvents BtnProcessRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents piecepanel As Panel
End Class
