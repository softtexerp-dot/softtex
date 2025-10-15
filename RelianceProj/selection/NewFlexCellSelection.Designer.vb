<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewFlexCellSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewFlexCellSelection))
        Me.TxtSeek = New System.Windows.Forms.TextBox()
        Me.SelectionGrid = New FlexCell.Grid()
        Me.SuspendLayout()
        '
        'TxtSeek
        '
        Me.TxtSeek.Location = New System.Drawing.Point(2, 3)
        Me.TxtSeek.Name = "TxtSeek"
        Me.TxtSeek.Size = New System.Drawing.Size(624, 23)
        Me.TxtSeek.TabIndex = 204
        '
        'SelectionGrid
        '
        Me.SelectionGrid.AllowUserReorderColumn = True
        Me.SelectionGrid.AllowUserResizing = FlexCell.ResizeEnum.Columns
        Me.SelectionGrid.AllowUserSort = True
        Me.SelectionGrid.BackColor1 = System.Drawing.Color.Transparent
        Me.SelectionGrid.BackColor2 = System.Drawing.Color.Transparent
        Me.SelectionGrid.BackColorActiveCellSel = System.Drawing.Color.Khaki
        Me.SelectionGrid.BackColorBkg = System.Drawing.Color.Transparent
        Me.SelectionGrid.BackColorFixed = System.Drawing.Color.Khaki
        Me.SelectionGrid.BackColorFixedSel = System.Drawing.Color.Khaki
        Me.SelectionGrid.BackColorSel = System.Drawing.Color.SteelBlue
        Me.SelectionGrid.BoldFixedCell = False
        Me.SelectionGrid.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SelectionGrid.BorderStyle = FlexCell.BorderStyleEnum.FixedSingle
        Me.SelectionGrid.CellBorderColor = System.Drawing.Color.Azure
        Me.SelectionGrid.CellBorderColorFixed = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SelectionGrid.CheckedImage = CType(resources.GetObject("SelectionGrid.CheckedImage"), System.Drawing.Bitmap)
        Me.SelectionGrid.Cols = 5
        Me.SelectionGrid.CommentIndicatorColor = System.Drawing.SystemColors.Highlight
        Me.SelectionGrid.DefaultFont = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.SelectionGrid.DefaultRowHeight = CType(29, Short)
        Me.SelectionGrid.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectionGrid.GridColor = System.Drawing.Color.DarkGray
        Me.SelectionGrid.Location = New System.Drawing.Point(2, 32)
        Me.SelectionGrid.Name = "SelectionGrid"
        Me.SelectionGrid.ReadonlyFocusRect = FlexCell.FocusRectEnum.Solid
        Me.SelectionGrid.ScrollBars = FlexCell.ScrollBarsEnum.Vertical
        Me.SelectionGrid.SelectionBorderColor = System.Drawing.SystemColors.Highlight
        Me.SelectionGrid.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        Me.SelectionGrid.Size = New System.Drawing.Size(571, 605)
        Me.SelectionGrid.TabIndex = 205
        Me.SelectionGrid.UncheckedImage = CType(resources.GetObject("SelectionGrid.UncheckedImage"), System.Drawing.Bitmap)
        '
        'NewFlexCellSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 641)
        Me.Controls.Add(Me.SelectionGrid)
        Me.Controls.Add(Me.TxtSeek)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewFlexCellSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selection List (F2=New,Ctrl+X=Export Excel)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSeek As TextBox
    Friend WithEvents SelectionGrid As FlexCell.Grid
End Class
