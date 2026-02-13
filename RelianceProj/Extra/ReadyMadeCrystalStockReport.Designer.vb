<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadyMadeCrystalStockReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadyMadeCrystalStockReport))
        Me.RecentlyUsedItemsComboBox1 = New DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox()
        Me.DesignRepositoryItemComboBox1 = New DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_ProcessStockDisplay = New ctl_TextBox.ctl_TextBox()
        Me.But_ok = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnItem = New System.Windows.Forms.Button()
        Me.BtnIC = New System.Windows.Forms.Button()
        Me.BtnSIC = New System.Windows.Forms.Button()
        CType(Me.RecentlyUsedItemsComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DesignRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RecentlyUsedItemsComboBox1
        '
        Me.RecentlyUsedItemsComboBox1.AppearanceDropDown.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.RecentlyUsedItemsComboBox1.AppearanceDropDown.Options.UseFont = True
        Me.RecentlyUsedItemsComboBox1.AutoHeight = False
        Me.RecentlyUsedItemsComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RecentlyUsedItemsComboBox1.Name = "RecentlyUsedItemsComboBox1"
        '
        'DesignRepositoryItemComboBox1
        '
        Me.DesignRepositoryItemComboBox1.AutoHeight = False
        Me.DesignRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DesignRepositoryItemComboBox1.Name = "DesignRepositoryItemComboBox1"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.IndianRed
        Me.Label1.Location = New System.Drawing.Point(-17, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(531, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ready Made Stock Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.ImageOptions.ImageUri.Uri = "Close"
        Me.BtnClose.Location = New System.Drawing.Point(388, 208)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(78, 37)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "&Close"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Stock View :"
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
        Me.Txt_ProcessStockDisplay.Location = New System.Drawing.Point(328, 48)
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
        Me.Txt_ProcessStockDisplay.Size = New System.Drawing.Size(138, 22)
        Me.Txt_ProcessStockDisplay.SpacerString = "ONLY STOCK,ALL"
        Me.Txt_ProcessStockDisplay.TabIndex = 6
        Me.Txt_ProcessStockDisplay.Tag = "VECHNO"
        Me.Txt_ProcessStockDisplay.Text = "ONLY STOCK"
        Me.Txt_ProcessStockDisplay.TransparentBox = True
        Me.Txt_ProcessStockDisplay.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'But_ok
        '
        Me.But_ok.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.But_ok.Appearance.Options.UseFont = True
        Me.But_ok.ImageOptions.Image = CType(resources.GetObject("But_ok.ImageOptions.Image"), System.Drawing.Image)
        Me.But_ok.Location = New System.Drawing.Point(321, 208)
        Me.But_ok.Name = "But_ok"
        Me.But_ok.Size = New System.Drawing.Size(67, 37)
        Me.But_ok.TabIndex = 7
        Me.But_ok.Text = "Ok"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(220, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1, 283)
        Me.Label3.TabIndex = 12
        '
        'BtnItem
        '
        Me.BtnItem.Location = New System.Drawing.Point(1, 24)
        Me.BtnItem.Name = "BtnItem"
        Me.BtnItem.Size = New System.Drawing.Size(219, 36)
        Me.BtnItem.TabIndex = 1
        Me.BtnItem.Tag = "1"
        Me.BtnItem.Text = "&1. Item Wise"
        Me.BtnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnItem.UseVisualStyleBackColor = True
        '
        'BtnIC
        '
        Me.BtnIC.Location = New System.Drawing.Point(1, 60)
        Me.BtnIC.Name = "BtnIC"
        Me.BtnIC.Size = New System.Drawing.Size(219, 36)
        Me.BtnIC.TabIndex = 2
        Me.BtnIC.Tag = "2"
        Me.BtnIC.Text = "&2. Item+Color Wise"
        Me.BtnIC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIC.UseVisualStyleBackColor = True
        '
        'BtnSIC
        '
        Me.BtnSIC.Location = New System.Drawing.Point(1, 97)
        Me.BtnSIC.Name = "BtnSIC"
        Me.BtnSIC.Size = New System.Drawing.Size(219, 36)
        Me.BtnSIC.TabIndex = 3
        Me.BtnSIC.Tag = "3"
        Me.BtnSIC.Text = "&3. Item+SubItem+Color Wise"
        Me.BtnSIC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSIC.UseVisualStyleBackColor = True
        '
        'ReadyMadeCrystalStockReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(511, 274)
        Me.Controls.Add(Me.BtnSIC)
        Me.Controls.Add(Me.BtnIC)
        Me.Controls.Add(Me.BtnItem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.But_ok)
        Me.Controls.Add(Me.Txt_ProcessStockDisplay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "ReadyMadeCrystalStockReport"
        Me.Text = "Ready Made StockReport"
        CType(Me.RecentlyUsedItemsComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DesignRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_ProcessStockDisplay As ctl_TextBox.ctl_TextBox
    Friend WithEvents But_ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RecentlyUsedItemsComboBox1 As DevExpress.XtraReports.UserDesigner.RecentlyUsedItemsComboBox
    Friend WithEvents DesignRepositoryItemComboBox1 As DevExpress.XtraReports.UserDesigner.DesignRepositoryItemComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnItem As Button
    Friend WithEvents BtnIC As Button
    Friend WithEvents BtnSIC As Button
End Class
