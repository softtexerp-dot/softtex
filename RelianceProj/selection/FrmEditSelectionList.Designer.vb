<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditSelectionList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEditSelectionList))
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.lbl_Seek = New System.Windows.Forms.Label()
        Me.Grid1 = New FlexCell.Grid()
        Me.SuspendLayout()
        '
        'lbl_Total
        '
        Me.lbl_Total.BackColor = System.Drawing.Color.Lavender
        Me.lbl_Total.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Total.Location = New System.Drawing.Point(254, 615)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(304, 22)
        Me.lbl_Total.TabIndex = 204
        Me.lbl_Total.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbl_Seek
        '
        Me.lbl_Seek.BackColor = System.Drawing.Color.Lavender
        Me.lbl_Seek.Font = New System.Drawing.Font("Trebuchet MS", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Seek.ForeColor = System.Drawing.Color.Red
        Me.lbl_Seek.Location = New System.Drawing.Point(3, 614)
        Me.lbl_Seek.Name = "lbl_Seek"
        Me.lbl_Seek.Size = New System.Drawing.Size(570, 23)
        Me.lbl_Seek.TabIndex = 203
        Me.lbl_Seek.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Grid1
        '
        Me.Grid1.AllowUserReorderColumn = True
        Me.Grid1.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.Grid1.AllowUserSort = True
        Me.Grid1.BackColor1 = System.Drawing.Color.Transparent
        Me.Grid1.BackColor2 = System.Drawing.Color.Transparent
        Me.Grid1.BackColorActiveCellSel = System.Drawing.Color.Khaki
        Me.Grid1.BackColorBkg = System.Drawing.Color.Transparent
        Me.Grid1.BackColorFixed = System.Drawing.Color.Khaki
        Me.Grid1.BackColorFixedSel = System.Drawing.Color.Khaki
        Me.Grid1.BackColorSel = System.Drawing.Color.SteelBlue
        Me.Grid1.BoldFixedCell = False
        Me.Grid1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grid1.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.Grid1.CellBorderColor = System.Drawing.Color.Azure
        Me.Grid1.CellBorderColorFixed = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Grid1.CheckedImage = CType(resources.GetObject("Grid1.CheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Cols = 5
        Me.Grid1.CommentIndicatorColor = System.Drawing.SystemColors.Highlight
        Me.Grid1.DefaultFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Grid1.DefaultRowHeight = CType(29, Short)
        Me.Grid1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.GridColor = System.Drawing.Color.DarkGray
        Me.Grid1.Location = New System.Drawing.Point(3, 3)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.Grid1.ScrollBars = FlexCell.ScrollBarsEnum.None
        Me.Grid1.SelectionBorderColor = System.Drawing.SystemColors.Highlight
        Me.Grid1.Size = New System.Drawing.Size(571, 605)
        Me.Grid1.TabIndex = 202
        Me.Grid1.UncheckedImage = CType(resources.GetObject("Grid1.UncheckedImage"), System.Drawing.Bitmap)
        Me.Grid1.Visible = False
        '
        'FrmEditSelectionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(576, 640)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.lbl_Seek)
        Me.Controls.Add(Me.Grid1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "FrmEditSelectionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selection List"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Total As System.Windows.Forms.Label
    Friend WithEvents lbl_Seek As System.Windows.Forms.Label
    Friend WithEvents Grid1 As FlexCell.Grid
End Class
