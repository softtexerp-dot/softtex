Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Public Class FrmQrCodescan
    Private Async Sub FrmQrCodescan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' ✅ QR Load
        Await LoadQRCode(COMPANY_GSTIN, GstApiLoginDetail.Txt_RechargeAmount.Text)
        Timer1.Interval = 1000
        Timer1.Start()
        lblStatus.Text = "Waiting for Payment..."
    End Sub
    Public Async Function LoadQRCode(gstin As String, amount As Decimal) As Task
        Dim url As String = "http://softtexlicenseapi.softtexerp.com/api/WhatsApp/RazorpayQRGenerateRecharge"
        Using client As New HttpClient()
            Dim jsonBody As String = $"{{""CompanyGst"":""{gstin}"",""Amount"":{amount}}}"
            Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)
            Dim resString As String = Await response.Content.ReadAsStringAsync()
            If response.IsSuccessStatusCode Then
                Dim obj As JObject = JObject.Parse(resString)
                If obj("success").ToString() = "True" Then
                    Dim qrPath As String = obj("qrImage").ToString()
                    Dim fullUrl As String = "http://softtexlicenseapi.softtexerp.com" & qrPath
                    ' ✅ QR Code show
                    RecharheQrCode.SizeMode = PictureBoxSizeMode.StretchImage
                    RecharheQrCode.Load(fullUrl)
                Else
                    Throw New Exception(obj("message").ToString())
                End If
            Else
                Throw New Exception("API Error: " & resString)
            End If
        End Using
    End Function
    Public Async Function GetRechargeStatus(gstin As String) As Task(Of JObject)
        Dim url As String = "http://softtexlicenseapi.softtexerp.com/api/WhatsApp/GetRechargeStatusByGst/" & gstin
        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync(url)
            Dim resString As String = Await response.Content.ReadAsStringAsync()
            If response.IsSuccessStatusCode Then
                Return JObject.Parse(resString)
            Else
                Throw New Exception("API Error: " & resString)
            End If
        End Using
    End Function

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim obj As JObject = Await GetRechargeStatus(COMPANY_GSTIN)
            If obj IsNot Nothing AndAlso obj("success").ToString() = "True" Then
                Dim status As String = obj("status").ToString()
                If status = "Approved" Then
                    Timer1.Stop()
                    lblStatus.Text = obj("message").ToString()
                    MessageBox.Show("Payment Successful ✅")
                    Me.Close() ' form auto close
                ElseIf status = "Pending" Then
                    lblStatus.Text = obj("message").ToString()
                End If
            End If
        Catch ex As Exception
            ' Silent handle ya log
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class