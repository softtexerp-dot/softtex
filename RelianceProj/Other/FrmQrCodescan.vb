Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Public Class FrmQrCodescan
    Private Async Sub FrmQrCodescan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LablePymtQrcode.Text = "Please Do Not Close The Payment Form Manually It Will " & Environment.NewLine &
            "Close Automatically After The Payment Is Completed."

        ' ✅ QR Load
        Await LoadQRCode("08ABCPL1234A1ZY", GstApiLoginDetail.Txt_RechargeAmount.Text)
        'Await LoadQRCode(COMPANY_GSTIN, GstApiLoginDetail.Txt_RechargeAmount.Text)

        Timer1.Interval = 1000
        Timer1.Start()
        lblStatus.Text = "Waiting for Payment..."
        'MessageBox.Show("Please Do Not Close The Payment Form Manually. It Will Close Automatically After The Payment Is Completed.")

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

    'Private _isRunning As Boolean = True

    'Public Async Function StartChecking(gstin As String) As Task
    '    While _isRunning
    '        Try
    '            Dim obj As JObject = Await GetRechargeStatus(gstin)

    '            ' Yaha response handle karo
    '            If obj IsNot Nothing Then
    '                ' Example
    '                Dim status = obj("status")?.ToString()
    '                If status = "Approved" Then
    '                    _isRunning = False
    '                    MessageBox.Show("Payment Completed")
    '                    Exit While
    '                End If
    '            End If

    '        Catch ex As Exception
    '            ' Error handle
    '            Console.WriteLine(ex.Message)
    '        End Try

    '        ' 1 second wait
    '        Await Task.Delay(1000)
    '    End While
    'End Function

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            'Dim obj As JObject = Await GetRechargeStatus(COMPANY_GSTIN)
            Dim obj As JObject = Await GetRechargeStatus("08ABCPL1234A1ZY")
            If obj IsNot Nothing AndAlso obj("success").ToString() = "True" Then
                Dim status As String = obj("status").ToString()
                If status = "Approved" Then
                    Timer1.Stop()
                    MessageBox.Show("Payment Successful ✅")
                    ' Optional: amount ya transaction id use karo
                    ' Dim txnId = obj("transactionId").ToString()
                    Me.Close() ' form auto close

                ElseIf status = "Pending" Then
                    ' Optional: label me show karo instead of popup
                    'lblStatus.Text = obj("message").ToString() ' Waiting for Payment
                End If
            End If
        Catch ex As Exception
            ' Silent handle ya log
            ' MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class