Imports System.Net.Http

Public Class complaint
    Public flagstring As String = ""
    Private Async Sub SubmitComplaintAsync(ByVal falgstring As String)

        Dim postUrl As String = "http://softtexcomplaintapi.softtexerp.com/api/Complaint/AddOrUpdateComplaint"

        Try
            Using client As New HttpClient()
                Using form As New MultipartFormDataContent()
                    If flagstring = "update" Then
                        Dim idValue As Long = Convert.ToInt64(lblid.Text)
                        form.Add(New StringContent(idValue.ToString()), "Id")
                    End If

                    ' 🔹 TEXT FIELDS
                    Dim properCasepartyname As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCompName.Text.Trim().ToLower())
                    form.Add(New StringContent(properCasepartyname), "PartyName")
                    Dim properCaseMessage As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtMessage.Text.Trim().ToLower())
                    form.Add(New StringContent(properCaseMessage), "ErrorMassge")
                    form.Add(New StringContent(COMPANY_TBL.Rows(0).Item("GstNo")), "GstNo")
                    Dim propersendername As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Txtsendername.Text.Trim().ToLower())
                    form.Add(New StringContent(propersendername), "SenderName")
                    form.Add(New StringContent(Txtmobileno.Text), "SenderMobileNo")
                    Dim txtmodule As String = "Textile"
                    form.Add(New StringContent(txtmodule), "Module")
                    'Dim txtcompinfo As String = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtCompName.Text.Trim().ToLower())
                    'form.Add(New StringContent(txtcompinfo), "CompleteInforme")

                    ' 🔹 FILE (IMAGE)
                    Dim filePath As String = txtFilePath.Text.Trim()

                    ' 🔹 Update case me hi check
                    If flagstring = "update" Then
                        ' 👉 New image selected (local file)
                        If IO.File.Exists(filePath) Then
                            Dim fileBytes As Byte() = IO.File.ReadAllBytes(filePath)
                            Dim fileContent As New ByteArrayContent(fileBytes)
                            fileContent.Headers.ContentType = New Net.Http.Headers.MediaTypeHeaderValue("image/jpeg")
                            form.Add(fileContent, "ErrorImage", IO.Path.GetFileName(filePath))
                        Else
                            ' 👉 Old image (URL / API path) → kuch mat bhejo
                            ' API existing image hi rakhegi
                        End If

                    Else
                        ' 🔹 Save case me image mandatory
                        If IO.File.Exists(filePath) Then

                            Dim fileBytes As Byte() = IO.File.ReadAllBytes(filePath)
                            Dim fileContent As New ByteArrayContent(fileBytes)
                            fileContent.Headers.ContentType =
            New Net.Http.Headers.MediaTypeHeaderValue("image/jpeg")

                            form.Add(fileContent, "ErrorImage", IO.Path.GetFileName(filePath))
                        Else
                            'MessageBox.Show("❌ Please select image file.")
                            'Exit Sub
                        End If
                    End If

                    ' 🔹 POST API
                    Dim postResponse As HttpResponseMessage =
                    Await client.PostAsync(postUrl, form)

                    Dim result As String =
                    Await postResponse.Content.ReadAsStringAsync()

                    If postResponse.IsSuccessStatusCode Then
                        'MessageBox.Show("✅ Complaint submitted successfully!")
                        Dim responseJson As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Newtonsoft.Json.Linq.JObject)(result)
                        Dim message As String = If(responseJson("message")?.ToString(), If(responseJson("status")?.ToString(), "Complaint saved successfully!"))
                        MessageBox.Show("✅ " & message, "Success")
                        ComplaintDetail.LoadComplaints("")
                        Me.Close()   ' Complaint form close
                    Else
                        MessageBox.Show("❌ API Error:" & vbCrLf & result)
                        Me.Close()
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Error while submitting complaint." & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub complaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        txtCompName.Text = COMPANY_TBL.Rows(0).Item("Company_Name")
        txtCompName.ReadOnly = True
        txtMessage.Focus()

        Dim _user As String = _USERNAME
        Txtsendername.Text = _user
        'Me.AcceptButton = btnSave
        lblid.Visible = False
    End Sub
    Public Sub _ImageView_Click(ByVal _IamgePath As String, ByVal _flagstring As String)
        Try
            If flagstring = "save" Then
                Dim _FilePath As String = _IamgePath
                If System.IO.File.Exists(_FilePath) = True Then
                    Process.Start(_FilePath)
                Else
                    MsgBox("File Does Not Exist")
                End If
            ElseIf flagstring = "update" Then
                Dim _FilePath As String = _IamgePath
                If System.IO.File.Exists(_FilePath) = True Then
                    Process.Start(_FilePath)
                ElseIf _FilePath.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then
                    'Process.Start(New ProcessStartInfo(_FilePath) With {.UseShellExecute = True})
                    Dim frm As New Form With
                    {
                    .Text = "Preview",
                    .Width = 900,
                    .Height = 600,
                    .StartPosition = FormStartPosition.CenterScreen,
                    .FormBorderStyle = FormBorderStyle.FixedDialog,
                    .MaximizeBox = False,
                    .MinimizeBox = False
                    }

                    'Dim wb As New WebBrowser With
                    '{
                    ' .Dock = DockStyle.Fill,
                    ' .ScriptErrorsSuppressed = True
                    '}
                    'wb.Navigate(_FilePath)
                    Dim pic As New PictureBox With {
                            .Dock = DockStyle.Fill,
                            .SizeMode = PictureBoxSizeMode.Zoom,
                            .ImageLocation = _FilePath
                        }
                    frm.KeyPreview = True
                    frm.Controls.Add(pic)
                    'frm.Controls.Add(wb)
                    AddHandler frm.KeyDown,
                    Sub(s, e)
                        If e.KeyCode = Keys.Escape Then
                            frm.Close()
                        End If
                    End Sub
                    frm.ShowDialog()


                Else
                    MsgBox("File Does Not Exist")
                End If
            Else
                Dim _FilePath As String = _IamgePath
                If System.IO.File.Exists(_FilePath) = True Then
                    Process.Start(_FilePath)
                Else
                    MsgBox("File Does Not Exist")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnaddfile_Click(sender As Object, e As EventArgs) Handles btnaddfile.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Select File"
        ofd.Filter = "All Files (*.*)|*.*|PDF Files (*.pdf)|*.pdf|Image Files (*.jpg;*.png)|*.jpg;*.png"
        ofd.Multiselect = False

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = ofd.FileName
            Dim fileName As String = IO.Path.GetFileName(filePath)
            txtFilePath.Text = filePath
            'MessageBox.Show("Selected File: " & fileName)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If flagstring <> "update" Then
            flagstring = "save"
        End If
        If String.IsNullOrWhiteSpace(txtMessage.Text) Then
            MessageBox.Show("Please Enter Message!")
            txtMessage.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Txtsendername.Text) Then
            MessageBox.Show("Please Enter Sender Name!")
            Txtsendername.Focus()
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Txtmobileno.Text) Then
            MessageBox.Show("Please Enter Mobile No!")
            Txtmobileno.Focus()
            Exit Sub
        End If
        If flagstring = "save" Then
            SubmitComplaintAsync(flagstring)
        ElseIf flagstring = "update" Then
            SubmitComplaintAsync(flagstring)
        End If
        Me.Close()
    End Sub

    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _ImageView_Click(txtFilePath.Text, flagstring)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtCompName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompName.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True   ' 🔹 beep stop

            Dim ctrl As Control = CType(sender, Control)
            ctrl.Parent.SelectNextControl(ctrl, True, True, True, True)
        End If
    End Sub
    Private Sub txtMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessage.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True   ' 🔕 beep & newline stop

            Dim txt As TextBox = CType(sender, TextBox)
            txt.Parent.SelectNextControl(txt, True, True, True, True)
        End If
        If e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True
            txtMessage.Parent.SelectNextControl(txtMessage, True, True, True, True)
        End If
        If e.KeyCode = Keys.F4 Then
            txtMessage.Parent.SelectNextControl(txtMessage, True, True, True, True)
        End If
    End Sub

    Private Sub Txtmobileno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtmobileno.KeyPress
        ' Sirf numbers + Backspace allow
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtmobileno_Leave(sender As Object, e As EventArgs) Handles Txtmobileno.Leave
        Dim mobile As String = Txtmobileno.Text.Trim()

        If mobile = "" Then Exit Sub

        ' 10 digit check
        If mobile.Length <> 10 Then
            MessageBox.Show("Please Enter Mobile number 10 digit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Txtmobileno.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub Txtsendername_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtsendername.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True   ' 🔹 beep stop

            Dim ctrl As Control = CType(sender, Control)
            ctrl.Parent.SelectNextControl(ctrl, True, True, True, True)
        End If
    End Sub

    Private Sub Txtmobileno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtmobileno.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            e.SuppressKeyPress = True   ' 🔹 beep stop

            Dim ctrl As Control = CType(sender, Control)
            ctrl.Parent.SelectNextControl(ctrl, True, True, True, True)
        End If
    End Sub

    Private Sub complaint_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class