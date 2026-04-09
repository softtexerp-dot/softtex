Imports Microsoft.Web.WebView2.WinForms

Public Class test
    Private Sub test_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebView2.Location = New Point(0, 0)
        WebView2.Size = New Size(1219, 615)
        'WebView2.Source = New Uri("https://softtexerp.in/")
        'WebView2.Source = New Uri("http://softtexlicenseadmin.softtexerp.com/login")
        WebView2.Source = New Uri("http://softtexlicenseadmin.softtexerp.com/whatsapp-dashboard")
    End Sub
End Class