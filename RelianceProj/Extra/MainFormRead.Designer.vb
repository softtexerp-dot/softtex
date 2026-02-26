<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFormRead
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFormRead))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFormName = New ctl_TextBox.ctl_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnUpdatepos = New DevExpress.XtraEditors.SimpleButton()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnmovecontrol = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(861, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 16)
        Me.Label11.TabIndex = 81902
        Me.Label11.Text = ":"
        '
        'txtFormName
        '
        Me.txtFormName._AllowSpace = True
        Me.txtFormName.AcceptsReturn = True
        Me.txtFormName.AutoFormat = ctl_TextBox.ctl_TextBox.KTB_AUTOFORMAT_SETTINGS.None
        Me.txtFormName.BackColor = System.Drawing.Color.Bisque
        Me.txtFormName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormName.Check_End_Date_Value_FY = "YES"
        Me.txtFormName.Check_Start_Date_Value_FY = "YES"
        Me.txtFormName.ClearField = True
        Me.txtFormName.CustomInputTypeString = Nothing
        Me.txtFormName.Date_for_Database = Nothing
        Me.txtFormName.Date_Tag = Nothing
        Me.txtFormName.EnterFocusColor = System.Drawing.Color.Bisque
        Me.txtFormName.ERequired = ctl_TextBox.ctl_TextBox.EnterRequired.yes
        Me.txtFormName.ExtraValue = ""
        Me.txtFormName.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormName.FontFocusColor = System.Drawing.Color.Blue
        Me.txtFormName.FontLeaveColor = System.Drawing.Color.Black
        Me.txtFormName.ForeColor = System.Drawing.Color.Blue
        Me.txtFormName.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
        Me.txtFormName.IsValidated = False
        Me.txtFormName.LeaveFocusColor = System.Drawing.SystemColors.Window
        Me.txtFormName.Location = New System.Drawing.Point(878, 57)
        Me.txtFormName.MandatoryColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtFormName.MandatoryField = False
        Me.txtFormName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtFormName.MaxDate = "FinYearEndDate"
        Me.txtFormName.MaxLength = 12
        Me.txtFormName.MinDate = "FinYearStartDate"
        Me.txtFormName.Name = "txtFormName"
        Me.txtFormName.NormalBorderColor = System.Drawing.Color.Gray
        Me.txtFormName.NullDate = ctl_TextBox.ctl_TextBox.AllowNullDate.yes
        Me.txtFormName.Precision = ctl_TextBox.ctl_TextBox.KTB_PRECISION_SETTINGS.None
        Me.txtFormName.RegularExpression = Nothing
        Me.txtFormName.RegularExpressionErrorMessage = Nothing
        Me.txtFormName.ShowMessage = False
        Me.txtFormName.Size = New System.Drawing.Size(159, 22)
        Me.txtFormName.SpacerString = ""
        Me.txtFormName.TabIndex = 81901
        Me.txtFormName.Tag = "FormName"
        Me.txtFormName.TransparentBox = True
        Me.txtFormName.UpDownKeyRequired = ctl_TextBox.ctl_TextBox.ArrowKeyRequired.yes
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(764, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 81900
        Me.Label1.Text = "Form Name"
        '
        'btnView
        '
        Me.btnView.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Appearance.Options.UseFont = True
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(1045, 48)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(111, 39)
        Me.btnView.TabIndex = 81902
        Me.btnView.Text = "View"
        '
        'BtnUpdatepos
        '
        Me.BtnUpdatepos.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdatepos.Appearance.Options.UseFont = True
        Me.BtnUpdatepos.Enabled = False
        Me.BtnUpdatepos.ImageOptions.Image = CType(resources.GetObject("BtnUpdatepos.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnUpdatepos.Location = New System.Drawing.Point(1014, 3)
        Me.BtnUpdatepos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnUpdatepos.Name = "BtnUpdatepos"
        Me.BtnUpdatepos.Size = New System.Drawing.Size(142, 39)
        Me.BtnUpdatepos.TabIndex = 81926
        Me.BtnUpdatepos.Text = "SavePosition"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Location = New System.Drawing.Point(986, 93)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(228, 794)
        Me.PropertyGrid1.TabIndex = 81927
        Me.PropertyGrid1.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnmovecontrol
        '
        Me.btnmovecontrol.Appearance.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmovecontrol.Appearance.Options.UseFont = True
        Me.btnmovecontrol.Enabled = False
        Me.btnmovecontrol.ImageOptions.Image = CType(resources.GetObject("btnmovecontrol.ImageOptions.Image"), System.Drawing.Image)
        Me.btnmovecontrol.Location = New System.Drawing.Point(767, 3)
        Me.btnmovecontrol.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnmovecontrol.Name = "btnmovecontrol"
        Me.btnmovecontrol.Size = New System.Drawing.Size(142, 39)
        Me.btnmovecontrol.TabIndex = 81929
        Me.btnmovecontrol.Text = "MoveControl"
        '
        'MainFormRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1216, 621)
        Me.Controls.Add(Me.btnmovecontrol)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.BtnUpdatepos)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtFormName)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MainFormRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form Read"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFormName As ctl_TextBox.ctl_TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnUpdatepos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents btnmovecontrol As DevExpress.XtraEditors.SimpleButton
End Class
