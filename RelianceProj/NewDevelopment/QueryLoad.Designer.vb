<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryLoad
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
        Me.RTBQuery = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'RTBQuery
        '
        Me.RTBQuery.BackColor = System.Drawing.Color.Bisque
        Me.RTBQuery.Location = New System.Drawing.Point(10, 6)
        Me.RTBQuery.Name = "RTBQuery"
        Me.RTBQuery.Size = New System.Drawing.Size(1086, 569)
        Me.RTBQuery.TabIndex = 0
        Me.RTBQuery.Text = ""
        '
        'QueryLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1104, 621)
        Me.Controls.Add(Me.RTBQuery)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "QueryLoad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Query Structure"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RTBQuery As RichTextBox
End Class
