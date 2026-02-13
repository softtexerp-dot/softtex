<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Grader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Grader))
        Me.Label204 = New System.Windows.Forms.Label()
        Me.Label203 = New System.Windows.Forms.Label()
        Me.Label202 = New System.Windows.Forms.Label()
        Me.Label201 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdView = New FlexCell.Grid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnlGrdView = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWeaveTypeName = New ctl_TextBox.ctl_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtMobileNo = New ctl_TextBox.ctl_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.PnlGrdView.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label204
        '
        Me.Label204.AutoSize = True
        Me.Label204.Location = New System.Drawing.Point(640, 202)
        Me.Label204.Name = "Label204"
        Me.Label204.Size = New System.Drawing.Size(155, 16)
        Me.Label204.TabIndex = 81769
        Me.Label204.Text = "frm_part_last-name"
        '
        'Label203
        '
        Me.Label203.AutoSize = True
        Me.Label203.Location = New System.Drawing.Point(640, 171)
        Me.Label203.Name = "Label203"
        Me.Label203.Size = New System.Drawing.Size(124, 16)
        Me.Label203.TabIndex = 81768
        Me.Label203.Text = "frm_part_label8"
        '
        'Label202
        '
        Me.Label202.AutoSize = True
        Me.Label202.Location = New System.Drawing.Point(640, 146)
        Me.Label202.Name = "Label202"
        Me.Label202.Size = New System.Drawing.Size(124, 16)
        Me.Label202.TabIndex = 81767
        Me.Label202.Text = "frm_part_label4"
        '
        'Label201
        '
        Me.Label201.AutoSize = True
        Me.Label201.Location = New System.Drawing.Point(640, 120)
        Me.Label201.Name = "Label201"
        Me.Label201.Size = New System.Drawing.Size(124, 16)
        Me.Label201.TabIndex = 81766
        Me.Label201.Text = "frm_part_label1"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.LightCyan
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(643, -7)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(120, 19)
        Me.TextBox3.TabIndex = 81763
        Me.TextBox3.Text = "id"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(640, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 81764
        Me.Label2.Text = "form selection"
        '
        'btnModify
        '
        Me.btnModify.BackColor = System.Drawing.SystemColors.Menu
        Me.btnModify.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModify.Location = New System.Drawing.Point(84, 11)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(85, 38)
        Me.btnModify.TabIndex = 6
        Me.btnModify.Text = "     Modify"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModify.UseVisualStyleBackColor = False
        '
        'btnView
        '
        Me.btnView.BackColor = System.Drawing.SystemColors.Menu
        Me.btnView.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(257, 10)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 39)
        Me.btnView.TabIndex = 8
        Me.btnView.Text = "     View"
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Menu
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(6, 11)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 38)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "      New"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Menu
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(332, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 38)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "       Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Menu
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(170, 11)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 38)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "      Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Menu
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(411, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 38)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "      Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnModify)
        Me.GroupBox1.Controls.Add(Me.btnView)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 53)
        Me.GroupBox1.TabIndex = 81762
        Me.GroupBox1.TabStop = False
        '
        'grdView
        '
        Me.grdView.AllowUserReorderColumn = True
        Me.grdView.AllowUserSort = True
        Me.grdView.AutoSize = True
        Me.grdView.BackColorActiveCellSel = System.Drawing.SystemColors.Highlight
        Me.grdView.BackColorBkg = System.Drawing.Color.White
        Me.grdView.BackColorFixed = System.Drawing.Color.Khaki
        Me.grdView.BackColorFixedSel = System.Drawing.Color.Khaki
        Me.grdView.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.grdView.CellBorderColor = System.Drawing.Color.White
        Me.grdView.CellBorderColorFixed = System.Drawing.Color.LightGray
        Me.grdView.CheckedImage = CType(resources.GetObject("grdView.CheckedImage"), System.Drawing.Bitmap)
        Me.grdView.Cols = 20
        Me.grdView.DefaultFont = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grdView.DefaultRowHeight = CType(26, Short)
        Me.grdView.DisplayRowNumber = True
        Me.grdView.EnableTabKey = False
        Me.grdView.FixedRowColStyle = FlexCell.FixedRowColStyleEnum.Light3D
        Me.grdView.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdView.GridColor = System.Drawing.Color.DarkGray
        Me.grdView.Location = New System.Drawing.Point(3, 7)
        Me.grdView.MultiSelect = False
        Me.grdView.Name = "grdView"
        Me.grdView.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.grdView.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.grdView.SelectionBorderColor = System.Drawing.Color.Red
        Me.grdView.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.grdView.Size = New System.Drawing.Size(482, 240)
        Me.grdView.TabIndex = 81748
        Me.grdView.TabKeyMoveTo = FlexCell.TabKeyMoveToEnum.CurrentRow
        Me.grdView.UncheckedImage = CType(resources.GetObject("grdView.UncheckedImage"), System.Drawing.Bitmap)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(640, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 81765
        Me.Label3.Text = "duplicate"
        '
        'PnlGrdView
        '
        Me.PnlGrdView.Controls.Add(Me.grdView)
        Me.PnlGrdView.Location = New System.Drawing.Point(378, 17)
        Me.PnlGrdView.Name = "PnlGrdView"
        Me.PnlGrdView.Size = New System.Drawing.Size(78, 95)
        Me.PnlGrdView.TabIndex = 81761
        Me.PnlGrdView.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 81759
        Me.Label1.Text = "Name"
        '
        'txtWeaveTypeName
        '
        Me.txtWeaveTypeName._AllowSpace = True
        Me.txtWeaveTypeName.AcceptsReturn = True
        Me.txtWeaveTypeName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtWeaveTypeName.BackColor = System.Drawing.Color.GhostWhite
        Me.txtWeaveTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWeaveTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWeaveTypeName.Check_End_Date_Value_FY = "YES"
        Me.txtWeaveTypeName.Check_Start_Date_Value_FY = "YES"
        Me.txtWeaveTypeName.ClearField = True
        Me.txtWeaveTypeName.CustomInputTypeString = Nothing
        Me.txtWeaveTypeName.Date_for_Database = Nothing
        Me.txtWeaveTypeName.Date_Tag = Nothing
        Me.txtWeaveTypeName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtWeaveTypeName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtWeaveTypeName.ExtraValue = ""
        Me.txtWeaveTypeName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeaveTypeName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtWeaveTypeName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtWeaveTypeName.ForeColor = System.Drawing.Color.Black
        Me.txtWeaveTypeName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtWeaveTypeName.IsValidated = False
        Me.txtWeaveTypeName.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.txtWeaveTypeName.Location = New System.Drawing.Point(146, 76)
        Me.txtWeaveTypeName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtWeaveTypeName.MandatoryField = False
        Me.txtWeaveTypeName.MaxDate = Nothing
        Me.txtWeaveTypeName.MinDate = Nothing
        Me.txtWeaveTypeName.Name = "txtWeaveTypeName"
        Me.txtWeaveTypeName.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.txtWeaveTypeName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtWeaveTypeName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtWeaveTypeName.RegularExpression = Nothing
        Me.txtWeaveTypeName.RegularExpressionErrorMessage = Nothing
        Me.txtWeaveTypeName.ShowMessage = False
        Me.txtWeaveTypeName.Size = New System.Drawing.Size(229, 22)
        Me.txtWeaveTypeName.SpacerString = ""
        Me.txtWeaveTypeName.TabIndex = 1
        Me.txtWeaveTypeName.Tag = "GraderName"
        Me.txtWeaveTypeName.TransparentBox = True
        Me.txtWeaveTypeName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(124, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 14)
        Me.Label4.TabIndex = 81760
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(49, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 14)
        Me.Label5.TabIndex = 81771
        Me.Label5.Text = "Mobile No"
        '
        'TxtMobileNo
        '
        Me.TxtMobileNo._AllowSpace = True
        Me.TxtMobileNo.AcceptsReturn = True
        Me.TxtMobileNo.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.TxtMobileNo.BackColor = System.Drawing.Color.GhostWhite
        Me.TxtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMobileNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMobileNo.Check_End_Date_Value_FY = "YES"
        Me.TxtMobileNo.Check_Start_Date_Value_FY = "YES"
        Me.TxtMobileNo.ClearField = True
        Me.TxtMobileNo.CustomInputTypeString = Nothing
        Me.TxtMobileNo.Date_for_Database = Nothing
        Me.TxtMobileNo.Date_Tag = Nothing
        Me.TxtMobileNo.EnterFocusColor = System.Drawing.Color.Bisque
        Me.TxtMobileNo.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.TxtMobileNo.ExtraValue = ""
        Me.TxtMobileNo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMobileNo.FontFocusColor = System.Drawing.Color.Blue
        Me.TxtMobileNo.FontLeaveColor = System.Drawing.Color.Black
        Me.TxtMobileNo.ForeColor = System.Drawing.Color.Black
        Me.TxtMobileNo.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.TxtMobileNo.IsValidated = False
        Me.TxtMobileNo.LeaveFocusColor = System.Drawing.Color.GhostWhite
        Me.TxtMobileNo.Location = New System.Drawing.Point(146, 119)
        Me.TxtMobileNo.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtMobileNo.MandatoryField = False
        Me.TxtMobileNo.MaxDate = Nothing
        Me.TxtMobileNo.MinDate = Nothing
        Me.TxtMobileNo.Name = "TxtMobileNo"
        Me.TxtMobileNo.NormalBorderColor = System.Drawing.Color.GhostWhite
        Me.TxtMobileNo.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.TxtMobileNo.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.TxtMobileNo.RegularExpression = Nothing
        Me.TxtMobileNo.RegularExpressionErrorMessage = Nothing
        Me.TxtMobileNo.ShowMessage = False
        Me.TxtMobileNo.Size = New System.Drawing.Size(229, 22)
        Me.TxtMobileNo.SpacerString = ""
        Me.TxtMobileNo.TabIndex = 2
        Me.TxtMobileNo.Tag = "OP1"
        Me.TxtMobileNo.TransparentBox = True
        Me.TxtMobileNo.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(127, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 14)
        Me.Label6.TabIndex = 81772
        Me.Label6.Text = ":"
        '
        'Frm_Grader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(500, 276)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtMobileNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label204)
        Me.Controls.Add(Me.Label203)
        Me.Controls.Add(Me.Label202)
        Me.Controls.Add(Me.Label201)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PnlGrdView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWeaveTypeName)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "Frm_Grader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grader Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.PnlGrdView.ResumeLayout(False)
        Me.PnlGrdView.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label204 As Label
    Friend WithEvents Label203 As Label
    Friend WithEvents Label202 As Label
    Friend WithEvents Label201 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnModify As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdView As FlexCell.Grid
    Friend WithEvents Label3 As Label
    Friend WithEvents PnlGrdView As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtWeaveTypeName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtMobileNo As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label6 As Label
End Class
