<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserMenuForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserMenuForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SidePanel = New DevExpress.XtraEditors.SidePanel()
        Me.BtnSetting = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTodolist = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnMobileSyn = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOutstandingReminder = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SidePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Location = New System.Drawing.Point(3, 43)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(311, 365)
        Me.GridControl1.TabIndex = 19
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.Beige
        Me.GridView2.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView2.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue
        Me.GridView2.Appearance.Row.Options.UseBackColor = True
        Me.GridView2.DetailHeight = 431
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsCustomization.AllowFilter = False
        Me.GridView2.OptionsCustomization.CustomizationFormSnapMode = CType((((DevExpress.Utils.Controls.SnapMode.OwnerControl Or DevExpress.Utils.Controls.SnapMode.OwnerForm) _
            Or DevExpress.Utils.Controls.SnapMode.Screens) _
            Or DevExpress.Utils.Controls.SnapMode.SnapForms), DevExpress.Utils.Controls.SnapMode)
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 1200
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'SidePanel
        '
        Me.SidePanel.Appearance.BackColor = System.Drawing.Color.Azure
        Me.SidePanel.Appearance.Options.UseBackColor = True
        Me.SidePanel.Controls.Add(Me.BtnSetting)
        Me.SidePanel.Controls.Add(Me.BtnTodolist)
        Me.SidePanel.Controls.Add(Me.BtnMobileSyn)
        Me.SidePanel.Controls.Add(Me.BtnOutstandingReminder)
        Me.SidePanel.Controls.Add(Me.GridControl1)
        Me.SidePanel.Location = New System.Drawing.Point(359, 37)
        Me.SidePanel.Margin = New System.Windows.Forms.Padding(4)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(316, 414)
        Me.SidePanel.TabIndex = 24
        Me.SidePanel.Text = "SidePanel1"
        '
        'BtnSetting
        '
        Me.BtnSetting.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.BtnSetting.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetting.Appearance.Options.UseBackColor = True
        Me.BtnSetting.Appearance.Options.UseFont = True
        Me.BtnSetting.AutoSize = True
        Me.BtnSetting.ImageOptions.Image = CType(resources.GetObject("BtnSetting.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSetting.Location = New System.Drawing.Point(204, 6)
        Me.BtnSetting.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSetting.Name = "BtnSetting"
        Me.BtnSetting.Size = New System.Drawing.Size(38, 36)
        Me.BtnSetting.TabIndex = 23
        '
        'BtnTodolist
        '
        Me.BtnTodolist.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.BtnTodolist.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTodolist.Appearance.Options.UseBackColor = True
        Me.BtnTodolist.Appearance.Options.UseFont = True
        Me.BtnTodolist.AutoSize = True
        Me.BtnTodolist.ImageOptions.Image = CType(resources.GetObject("BtnTodolist.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnTodolist.Location = New System.Drawing.Point(138, 6)
        Me.BtnTodolist.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTodolist.Name = "BtnTodolist"
        Me.BtnTodolist.Size = New System.Drawing.Size(38, 36)
        Me.BtnTodolist.TabIndex = 22
        '
        'BtnMobileSyn
        '
        Me.BtnMobileSyn.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.BtnMobileSyn.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMobileSyn.Appearance.Options.UseBackColor = True
        Me.BtnMobileSyn.Appearance.Options.UseFont = True
        Me.BtnMobileSyn.AutoSize = True
        Me.BtnMobileSyn.ImageOptions.Image = CType(resources.GetObject("BtnMobileSyn.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnMobileSyn.Location = New System.Drawing.Point(72, 6)
        Me.BtnMobileSyn.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnMobileSyn.Name = "BtnMobileSyn"
        Me.BtnMobileSyn.Size = New System.Drawing.Size(38, 36)
        Me.BtnMobileSyn.TabIndex = 21
        '
        'BtnOutstandingReminder
        '
        Me.BtnOutstandingReminder.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.BtnOutstandingReminder.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOutstandingReminder.Appearance.Options.UseBackColor = True
        Me.BtnOutstandingReminder.Appearance.Options.UseFont = True
        Me.BtnOutstandingReminder.AutoSize = True
        Me.BtnOutstandingReminder.ImageOptions.Image = CType(resources.GetObject("BtnOutstandingReminder.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnOutstandingReminder.Location = New System.Drawing.Point(6, 6)
        Me.BtnOutstandingReminder.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnOutstandingReminder.Name = "BtnOutstandingReminder"
        Me.BtnOutstandingReminder.Size = New System.Drawing.Size(38, 36)
        Me.BtnOutstandingReminder.TabIndex = 20
        '
        'UserMenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.SidePanel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "UserMenuForm"
        Me.Text = "UserMenuForm"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SidePanel.ResumeLayout(False)
        Me.SidePanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SidePanel As DevExpress.XtraEditors.SidePanel
    Friend WithEvents BtnSetting As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnTodolist As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnMobileSyn As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOutstandingReminder As DevExpress.XtraEditors.SimpleButton
End Class
