Friend Class Passward_Checker
    Private Sub Passward_Checker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    '    Me.Close()
    '    Me.Dispose(True)
    'End Sub

    'Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
    '    _PasswardWindow = txt_Passward.Text.Trim
    '    Me.Close()
    '    Me.Dispose(True)
    'End Sub

    Private Sub Passward_Checker_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Me.Dispose(True)
        End If
    End Sub


    Private Sub btnOk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnView.BackColor = Color.Coral
    End Sub
    Private Sub btnOk_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnView.BackColor = Me.BackColor
    End Sub


    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        SimpleButton1.BackColor = Color.Coral
    End Sub
    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        SimpleButton1.BackColor = Me.BackColor
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        _PasswardWindow = txt_Passward.Text.Trim
        Me.Close()
        Me.Dispose(True)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
        Me.Dispose(True)
    End Sub
End Class