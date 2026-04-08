Imports System.Net.Http
Imports System.Security.Policy
Imports System.Text
Imports DevExpress.DocumentServices.ServiceModel
Imports DevExpress.XtraRichEdit.Import.Html
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports QRCoder
Imports RestSharp


Public Class GstApiLoginDetail
    Dim configPath As String = _TextFilePath("MySettings.txt")
    Dim cfg As New TxtFileConfigManager(configPath)
    Dim _getOldPass As String = ""
    Private Async Sub GstApiLoginDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AttachButtonFocusEvents(Me)
        Dim data As WalletStats = Await GetWalletStats(COMPANY_GSTIN)
        If data IsNot Nothing Then
            LblCurrentBalance.Text = data.Balance
            LblRechargeTotAmt.Text = data.TotalRecharge
            lblUsedAmt.Text = data.UsedAmount
        End If
        Dim x As Integer
        Dim y As Integer
        x = 200
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 55
        Me.Location = New Point(x, y)
        RS = " SELECT* FROM MstCompany WHERE Comp_Code = " & COMPANY_TBL.Rows(0).Item("COMPANY_CODE") & ""
        SQLDBMENU_CONNECT()
        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_Api_User.Text = DefaltSoftTable.Rows(0).Item("GstApiUserName").ToString
            Txt_ApiPassword.Text = DefaltSoftTable.Rows(0).Item("GstApiUserPassword").ToString
            TxtWhatspApp.Text = DefaltSoftTable.Rows(0).Item("WhatsAppApiKey").ToString
            TxtWhatsappSelection.Text = DefaltSoftTable.Rows(0).Item("COMP_AADHARNO").ToString
            Txt_LoginId.Text = DefaltSoftTable.Rows(0).Item("ESI_BRANCHCODE").ToString
        End If
        sqL = " SELECT * FROM Creat_company"
        sql_connect_slect()
        Dim _TmpCompTbl As New DataTable
        _TmpCompTbl = DefaltSoftTable.Copy
        Txt_DefaltNo1.Text = _TmpCompTbl.Rows(0).Item("OP5").ToString
        Txt_DefaltNo2.Text = _TmpCompTbl.Rows(0).Item("OP6").ToString
        Txt_DefaltNo3.Text = _TmpCompTbl.Rows(0).Item("OP7").ToString
        _getOldPass = cfg.ReadSetting("RestPas", "UserId")
        ' ✅ Get meta Api
        Txt_ApiToken.Text = cfg.ReadSetting("MetaApi", "ApiToken")
        Txt_PhoneNoId.Text = cfg.ReadSetting("MetaApi", "PhoneNoId")
        Txt_textTempId.Text = cfg.ReadSetting("MetaApi", "TextTempId")
        Txt_PdfTempId.Text = cfg.ReadSetting("MetaApi", "PdfTempId")
        Txt_ImageTempId.Text = cfg.ReadSetting("MetaApi", "ImageTempId")
        Txt_ApiUrl.Text = cfg.ReadSetting("MetaApi", "ApiUrl")

        Txt_CompanyId.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Company Id")
        Txt_MetaWhtasappNo.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Meta Whatsapp No")
        Txt_MetaPhoneID.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Meta Phone Id")
        Txt_MetaTxtTemplate.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Text Temp Name")
        Txt_MetaPdfTemplate.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Pdf Temp Name")
        Txt_metaImageTemplate.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Image Temp Name")
        Txt_MetaUserId.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "user")
        Txt_MetaPassword.Text = _CompanyDatabaseSettingLoad("SOFT TEX META", "Password")
    End Sub


    Private Sub SaveData()
        Dim _strQuery = New StringBuilder
        With _strQuery
            .Append(" UPDATE MstCompany Set ")
            .Append(" GstApiUserName = '" & Txt_Api_User.Text & "' ")
            .Append(",GstApiUserPassword = '" & Txt_ApiPassword.Text & "'  ")
            .Append(",WhatsAppApiKey = '" & TxtWhatspApp.Text & "'  ")
            .Append(",COMP_AADHARNO = '" & TxtWhatsappSelection.Text & "'  ")
            .Append(",ESI_BRANCHCODE = '" & Txt_LoginId.Text & "'  ")
            .Append("WHERE Comp_Code = " & COMPANY_TBL.Rows(0).Item("COMPANY_CODE"))
            .Append("  ")
        End With
        RS = _strQuery.ToString
        SQLDBMENU_Save_Delete_Update()
        Dim _NewstrQuery = New StringBuilder
        With _NewstrQuery
            .Append(" UPDATE Creat_company Set ")
            .Append("  OP5 = '" & Txt_DefaltNo1.Text & "' ")
            .Append(" ,OP6 = '" & Txt_DefaltNo2.Text & "' ")
            .Append(" ,OP7 = '" & Txt_DefaltNo3.Text & "' ")
        End With
        sqL = _NewstrQuery.ToString
        sql_Data_Save_Delete_Update()
        If TxtWhatsappSelection.Text = "DEAL" Then
            _NewstrQuery = New StringBuilder
            With _NewstrQuery
                .Append(" UPDATE MstUser Set ")
                .Append("  WhatsAppUserAPI = '" & TxtWhatspApp.Text & "' ")
                .Append("  ,OP5 = '" & TxtWhatsappSelection.Text & "' ")
                .Append(" where 1=1  and USER_ID = " & USER_ID & " ")
            End With
            RS = _NewstrQuery.ToString
            SQLDBMENU_Save_Delete_Update()
        End If
        'hatna h
        'Main_MDI_Frm._loadWhatsappApiKey()
    End Sub
    Private Sub GstApiLoginDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
            Dispose(True)
        End If
    End Sub
    Private Sub Btn_BookWiseGstApi_Click(sender As Object, e As EventArgs) Handles Btn_BookWiseGstApi.Click
        'hatna h
        'BookWiseEwayBillSystem.ShowDialog()
    End Sub

    Private Sub BtnQrcodegenerate_Click(sender As Object, e As EventArgs) Handles BtnQrcodegenerate.Click
        TxtWhatsappSelection.Text = "DEAL"
        Txt_LoginId.Text = "68501ad036d15"
        Dim client = New RestSharp.RestClient("https://dealsms.in/api/create_instance?access_token=" & Txt_LoginId.Text)
        client.Timeout = -1
        Dim request = New RestSharp.RestRequest(RestSharp.Method.GET)
        Dim response = client.Execute(request)
        Console.WriteLine(response.Content)
        Dim _respo As String = (response.Content)
        Dim text1 = JObject.Parse(_respo)("status").ToString
        If text1 = "success" Then
            TxtWhatspApp.Text = JObject.Parse(_respo)("instance_id").ToString
        Else
            Interaction.MsgBox((JObject.Parse(_respo)("message")), MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        End If
        client = New RestSharp.RestClient("https://dealsms.in/api/get_qrcode?instance_id=" & TxtWhatspApp.Text & "&access_token=" & Txt_LoginId.Text)
        client.Timeout = -1
        request = New RestSharp.RestRequest(RestSharp.Method.GET)
        response = client.Execute(request)
        Console.WriteLine(response.Content)
        _respo = (response.Content)
        text1 = JObject.Parse(_respo)("status").ToString
        If text1 = "success" Then
            Dim rawBase64 As String = JObject.Parse(_respo)("base64").ToString
            ' Remove any "data:image/png;base64," or similar prefix
            If rawBase64.Contains(",") Then
                rawBase64 = rawBase64.Substring(rawBase64.IndexOf(",") + 1)
            End If
            Dim bytes() As Byte = Convert.FromBase64String(rawBase64)
            Using ms As New IO.MemoryStream(bytes)
                PictureBox1.Image = Image.FromStream(ms)
            End Using
        Else
            Interaction.MsgBox((JObject.Parse(_respo)("message")), MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        End If
        SaveData()
    End Sub

    Private Sub TxtRestoreOldPass_Validated(sender As Object, e As EventArgs) Handles TxtRestoreOldPass.Validated
        If _getOldPass = "" Then _getOldPass = "SOFTTEXERP"
        If _getOldPass <> TxtRestoreOldPass.Text.ToUpper Then
            MsgBox("Old Password Not Match", MsgBoxStyle.Information, "Soft-Tex PRO")
            TxtRestoreOldPass.Text = ""
            TxtRestoreNewPass.Text = ""
            TxtRestoreOldPass.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnMetWhtsappAccount_Click(sender As Object, e As EventArgs) Handles btnMetWhtsappAccount.Click
        'hatna h
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Company Id", Txt_CompanyId.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Meta Whatsapp No", Txt_MetaWhtasappNo.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Meta Phone Id", Txt_MetaPhoneID.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Text Temp Name", Txt_MetaTxtTemplate.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Pdf Temp Name", Txt_MetaPdfTemplate.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Image Temp Name", Txt_metaImageTemplate.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "user", Txt_MetaUserId.Text)
        'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Password", Txt_MetaPassword.Text)
        Dim controls = {New With {.txt = Txt_MetaUserId, .msg = "Enter Meta WhatsApp User ID"},
        New With {.txt = Txt_MetaPassword, .msg = "Enter Meta WhatsApp Password"},
        New With {.txt = Txt_MetaWhtasappNo, .msg = "Enter Meta WhatsApp Mobile No"},
        New With {.txt = Txt_MetaPhoneID, .msg = "Enter Meta WhatsApp Phone ID"},
        New With {.txt = Txt_MetaTxtTemplate, .msg = "Enter Meta WhatsApp Text Template Name"},
        New With {.txt = Txt_MetaPdfTemplate, .msg = "Enter Meta WhatsApp PDF Template Name"},
        New With {.txt = Txt_metaImageTemplate, .msg = "Enter Meta WhatsApp Image Template Name"}
        }
        For Each c In controls
            If c.txt.Text.Trim = "" Then
                MsgBox(c.msg, MsgBoxStyle.Critical, "Soft-Tex PRO")
                c.txt.Focus()
                Exit Sub
            End If
        Next
        Try
            Dim url As String = "http://softtexlicenseapi.softtexerp.com/api/WhatsApp/CompanyCreate"
            Dim data = New With {
                .CompanyName = COMPANY_NAME,
                .GSTNumber = COMPANY_GSTIN,
                .SendNumber = Txt_MetaWhtasappNo.Text,
                .PhoneNumberId = Txt_MetaPhoneID.Text,
                .UserId = Txt_MetaUserId.Text,
                .Password = Txt_MetaPassword.Text
            }
            Dim json As String = JsonConvert.SerializeObject(data)
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Add("accept", "*/*")
                Dim content As New StringContent(json, Encoding.UTF8, "application/json")
                Dim response = client.PostAsync(url, content).Result
                Dim result As String = response.Content.ReadAsStringAsync().Result
                If response.IsSuccessStatusCode Then
                    Dim obj = JObject.Parse(result)
                    Txt_CompanyId.Text = obj("CompanyId").ToString()
                    'hatna h
                    'ProcessDyeningSetting._SettingUpdate("SOFT TEX META", "Company Id", Txt_CompanyId.Text)
                Else
                    MsgBox("API Error : " & result)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Async Sub Txt_PhonePayQrCode_Click(sender As Object, e As EventArgs) Handles Txt_PhonePayQrCode.Click
        If Val(Txt_RechargeAmount.Text) > 0 Then
            Dim qrPath As String = Await GenerateRechargeQR(COMPANY_GSTIN, Txt_RechargeAmount.Text)
        Else
            MsgBox("Enter Amount", MsgBoxStyle.Information, "Soft-Tex PRO")
            Txt_RechargeAmount.Focus()
        End If
    End Sub

    Public Async Function GenerateRechargeQR(gstin As String, amount As Decimal) As Task(Of String)
        Dim url As String = "http://softtexlicenseapi.softtexerp.com/api/WhatsApp/RazorpayQRGenerateRecharge"
        Using client As New HttpClient()
            ' JSON Body
            Dim jsonBody As String = $"{{""CompanyGst"":""{gstin}"",""Amount"":{amount}}}"
            Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)
            Dim resString As String = Await response.Content.ReadAsStringAsync()
            If response.IsSuccessStatusCode Then
                Dim obj As JObject = JObject.Parse(resString)
                If obj("success").ToString() = "True" Then
                    FrmQrCodescan.ShowDialog()
                    Return obj("qrImage").ToString() ' only path return
                Else
                    Throw New Exception(obj("message").ToString())
                End If
            Else
                Throw New Exception("API Error: " & resString)
            End If
        End Using
    End Function

    Private Sub Txt_MetaPassword_MouseDown(sender As Object, e As MouseEventArgs) Handles Txt_MetaPassword.MouseDown
        If e.Button = MouseButtons.Right Then
            Exit Sub
        End If
    End Sub

    Private Sub Txt_MetaPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_MetaPassword.KeyDown
        If e.Control AndAlso (e.KeyCode = Keys.C Or e.KeyCode = Keys.V Or e.KeyCode = Keys.X) Then
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
        cfg.DeleteSetting("RestPas", "UserId")
        cfg.UpdateSetting("RestPas", "UserId", TxtRestoreNewPass.Text.ToUpper)
        'Meta Api 
        ' ✅ Delete Key
        cfg.DeleteSetting("MetaApi", "ApiUrl")
        cfg.DeleteSetting("MetaApi", "ApiToken")
        cfg.DeleteSetting("MetaApi", "PhoneNoId")
        cfg.DeleteSetting("MetaApi", "TextTempId")
        cfg.DeleteSetting("MetaApi", "PdfTempId")
        cfg.DeleteSetting("MetaApi", "ImageTempId")
        ' ✅ Add or Update
        cfg.UpdateSetting("MetaApi", "ApiUrl", Txt_ApiUrl.Text)
        cfg.UpdateSetting("MetaApi", "ApiToken", Txt_ApiToken.Text)
        cfg.UpdateSetting("MetaApi", "PhoneNoId", Txt_PhoneNoId.Text)
        cfg.UpdateSetting("MetaApi", "TextTempId", Txt_textTempId.Text)
        cfg.UpdateSetting("MetaApi", "PdfTempId", Txt_PdfTempId.Text)
        cfg.UpdateSetting("MetaApi", "ImageTempId", Txt_ImageTempId.Text)
        MsgBox("Update Success", MsgBoxStyle.Information, "Soft-Tex PRO")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
        Dispose(True)
    End Sub

    Private Async Sub RechargeBalance_Click(sender As Object, e As EventArgs) Handles RechargeBalance.Click
        Try
            Dim data As WalletStats = Await GetWalletStats(COMPANY_GSTIN)
            If data IsNot Nothing Then
                LblCurrentBalance.Text = data.Balance
                LblRechargeTotAmt.Text = data.TotalRecharge
                lblUsedAmt.Text = data.UsedAmount
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Async Function GetWalletStats(gstin As String) As Task(Of WalletStats)
        Dim Url As String = "http://softtexlicenseapi.softtexerp.com/api/WhatsApp/GetBYGstWalletStats/" & gstin
        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync(Url)
            Dim _respo As String = Await response.Content.ReadAsStringAsync()
            If response.IsSuccessStatusCode Then
                Dim jsonArr As JArray = JArray.Parse(_respo)
                If jsonArr.Count > 0 Then
                    Dim obj As JObject = jsonArr(0)
                    Dim result As New WalletStats With {
                        .Balance = obj("Balance").ToString(),
                        .TotalRecharge = obj("TotalRecharge").ToString(),
                        .UsedAmount = obj("UsedAmount").ToString()
                    }
                    Return result
                End If
            Else
                Throw New Exception("API Error: " & _respo)
            End If
        End Using
        Return Nothing
    End Function

    Public Class WalletStats
        Public Property Balance As String
        Public Property TotalRecharge As String
        Public Property UsedAmount As String
    End Class
End Class