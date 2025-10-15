Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Friend Class Report_viewer

    Private obj_Party_Selection As New Multi_Selection_Master

    Private toolTip1 As New ToolTip
    Private tabControl As TabControl
    'Dim cryRpt As New ReportDocument
    'Private Rpt_Source1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private Str_File_Name As String = ""
    Private QuickModeFileName As String = ""

    Dim _SendNumber As String = ""
    Private Sub Report_viewer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then

            If pnlGridView.Visible = True Then
                pnlGridView.Visible = False
                Exit Sub
            End If

            COMPANY_NAME = COMPANY_TBL.Rows(0).Item("COMPANY_NAME")
            Comp_name = COMPANY_NAME


            Me.Close()
            WhatsAppMobileNo = ""
        ElseIf e.KeyCode = Keys.F1 Then
            Process.Start(strReportPath)
        ElseIf e.KeyCode = Keys.F5 Then
            LEDGER_FORM_DISPALY_BY = "F5_DISPLAY_FORM"
            'ShowForm(New Ledger_display_n)
        ElseIf e.KeyCode = Keys.F6 Then
            LEDGER_ENTER_DISPLAY_FROM = "SUPER SEARCH"
            'ShowForm(New Quick_Search)
            LEDGER_ENTER_DISPLAY_FROM = ""
        ElseIf e.KeyCode = Keys.F8 Then

        ElseIf e.KeyCode = Keys.F9 Then
            System.Diagnostics.Process.Start("calc.exe")
        ElseIf e.KeyCode = Keys.F10 Then
            cryRpt.PrintToPrinter(1, False, 0, 0)
        ElseIf e.KeyCode = Keys.Left Then
            CrystalReportViewer1.ShowPreviousPage()
            CrystalReportViewer1.Focus()
            SendKeys.Send("{TAB}")
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Right Then
            CrystalReportViewer1.ShowNextPage()
            CrystalReportViewer1.Focus()
            SendKeys.Send("{TAB}")
            SendKeys.Send("{TAB}")

        ElseIf (e.KeyCode = Keys.G AndAlso e.Modifiers = Keys.Control) Then
            Try


                GridControl1.DataSource = _ReportViewerTbl
                'FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
                'FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)
                'FirstStage.GroupRowHeight = 30
                pnlGridView.Visible = True
                FirstStage.Focus()
                pnlGridView.BringToFront()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        ElseIf (e.KeyCode = Keys.X AndAlso e.Modifiers = Keys.Control) Then
            XLS_export()
        ElseIf (e.KeyCode = Keys.P AndAlso e.Modifiers = Keys.Control) Then
            Direct_Export_To_Pdf()
            MsgBox("Export Successfully, You Can See In Desktop Soft Tex Reports Folder", MsgBoxStyle.Information, "Soft-Tex PRO")
        ElseIf (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
            _Whatsapp()
        ElseIf (e.KeyCode = Keys.M AndAlso e.Modifiers = Keys.Control) Then
            _mail()

        End If
    End Sub
    Private Sub btn_pdf_Click(sender As Object, e As EventArgs) Handles btn_pdf.Click
        Direct_Export_To_Pdf()
        MsgBox("Export Successfully, You Can See In Desktop Soft Tex Reports Folder", MsgBoxStyle.Information, "Soft-Tex PRO")
    End Sub
    Private Sub But_export_Click(sender As Object, e As EventArgs) Handles But_export.Click
        XLS_export()
    End Sub
    Private Sub XLS_export()
        CreateGUID()
        Try
            Dim InputFileName As String = Interaction.InputBox("Input File Name", "Soft-Tex PRO", "", 350, 350).ToString().Trim().ToUpper()


            Dim PATH = My.Computer.FileSystem.SpecialDirectories.Desktop
            'Dim D_path As String = System.Windows.Forms.Application.StartupPath + "\Soft Tex Reports"
            Dim D_path As String = PATH + "\Soft Tex Reports"
            If Not Directory.Exists(D_path) Then
                Directory.CreateDirectory(D_path)
            End If


            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New ExcelFormatOptions

            Dim file_name As String = D_path + "\" & InputFileName & " " & EmailSubject & "-" + CreateGUID() & ".xls"

            CrDiskFileDestinationOptions.DiskFileName = file_name
            Str_File_Name = file_name
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.ExcelRecord
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()
            MsgBox("Export Successfully, You Can See In Desktop Soft Tex Reports Folder", MsgBoxStyle.Information, "Soft-Tex PRO")
            'Process.Start("EXCEL.EXE", Str_File_Name)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub btn_mail_Click(sender As Object, e As EventArgs) Handles btn_mail.Click
        _mail()
    End Sub
    Private Sub _mail()
        Direct_Export_To_Pdf()
        'mailform.lstbox_Attach.Items.Clear()
        'mailform.lstbox_Attach.Items.Add(Str_File_Name)
        'mailform.lstbox_Attach.Text = Str_File_Name
        'mailform.txt_To.Text = ""
        'If _MAILPARTY_TBL.Rows.Count <> 0 Then
        '    mailform.txt_To.Text = _MAILPARTY_TBL.Rows(0).Item(1)
        '    mailform.txt_Subject.Text = _MAILPARTY_TBL.Rows(0).Item(2)
        'End If

        ''mailform.txt_From.Text = COMPANY_TBL.Rows(0).Item("EMAIL")
        ''mailform.txt_From_Password.Text = COMPANY_TBL.Rows(0).Item("EMAIL_PASSWORD")
        'mailform.txt_Subject.Text = EmailSubject
        'mailform.ShowDialog()
    End Sub



    Public Function Direct_Export_To_Pdf()
        Dim _PdfFilePath As String = ""
        CreateGUID()
        Try
            Dim InputFileName As String = ""
            If _SendNumber = "" Then
                InputFileName = Interaction.InputBox("Input File Name", "Soft-Tex PRO", "", 350, 350).ToString().Trim().ToUpper()
            End If


            If EmailSubject <> "" Then
                EmailSubject = CleanFileName(EmailSubject)
                'EmailSubject = Replace((EmailSubject).ToString.Trim, "(", "").Replace("/", "")
                'EmailSubject = Replace((EmailSubject).ToString.Trim, ")", "").Replace("/", "")
            End If

            Dim PATH = My.Computer.FileSystem.SpecialDirectories.Desktop
            Dim D_path As String = PATH + "\Soft Tex Reports"
            If Not Directory.Exists(D_path) Then
                Directory.CreateDirectory(D_path)
            End If
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New _
            DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = D_path + "\" & InputFileName & " " & EmailSubject & "-" + CreateGUID() & ".pdf"
            Str_File_Name = D_path + "\" & InputFileName & " " & EmailSubject & "-" + CreateGUID() & ".pdf"
            '"d:\crystalExport.pdf"
            CrExportOptions = cryRpt.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            cryRpt.Export()

            _PdfFilePath = Str_File_Name

            Return _PdfFilePath
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Sub BtnWhatsapp_Click(sender As Object, e As EventArgs) Handles BtnWhatsapp.Click
        _Whatsapp()
    End Sub
    Private Sub _Whatsapp()

        Try

            If _WhatsUpSend = "NO" Then
                MsgBox("User Not Allow Send WhatsUp", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            End If


            If My.Computer.Network.IsAvailable Then
            Else
                MsgBox("Check Internet Connection Your Computer", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            End If

            _SendNumber = ""

            If MsgBox("Do You Want Send WhatsApp Manual Number", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "WhatsApp Message ?") = MsgBoxResult.Yes Then
                _SendNumber = Interaction.InputBox("Input WhatsUp Number ", "Soft-Tex PRO", WhatsAppMobileNo, 350, 350).ToString().Trim().ToUpper()
            Else
                _ManulNumberSelection()

                If MULTY_SELECTION_COLOUM_2_DATA > "" Then
                    If _CheckWhtaspOkNo = True Then
                        _SendNumber = MULTY_SELECTION_COLOUM_2_DATA
                    End If
                End If
            End If

            If _SendNumber > "" Then
                Dim _Str_File_Name As String = ""
                Str_File_Name = Direct_Export_To_Pdf()
                UploadSendWhatsUp(Str_File_Name, _SendNumber)
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Public Function _ManulNumberSelection()

        _strQuery = New StringBuilder
        With _strQuery
            .Append("  SELECT   A.ACCOUNTNAME[Account Name],A.MOBILE AS [Mobile No] , A.ACCOUNTCODE, A.GROUPCODE,B.CITYNAME as [City Name]  ")
            .Append(" FROM MstMasterAccount AS A INNER JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
            .Append(" WHERE A.MOBILE<>'' ")
            .Append(" AND  LEN( A.MOBILE)=10 ")
            '.Append(" ORDER BY A.ACCOUNTNAME ")
            .Append(" UNION ALL ")
            .Append("  SELECT   A.TRANSPORTNAME[Account Name],A.MOBILENO AS [Mobile No] , A.ID, A.ID,B.CITYNAME as [City Name]  ")
            .Append(" FROM MstTransport AS A INNER JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
            .Append(" WHERE A.MOBILENO<>'' ")
            .Append(" AND  LEN( A.MOBILENO)=10 ")
            .Append(" ORDER BY A.ACCOUNTNAME ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Party_selection.dgw.DataSource = DefaltSoftTable.Copy
        Party_selection.dgw.Columns(2).Visible = False
        Party_selection.dgw.Columns(3).Visible = False
        Party_selection.dgw.Columns(4).Visible = True
        Party_selection.dgw.Columns(0).Width = 330
        Party_selection.dgw.Columns(1).Width = 130
        Party_selection.dgw.Columns(4).Width = 150
        Party_selection.Width = 644
        obj_Party_Selection.SELECTION_LIST_FIRST_SELECTION()

    End Function


    Public Function UploadFile(ByVal url As String, ByVal filePath As String, ByVal srcFilename As String, ByVal destFileName As String) As String
        Dim uploaded = False
        Dim returnvalue = ""

        Try
            Dim httpClient = New HttpClient()
            Dim fileStream = File.Open(srcFilename, FileMode.Open)
            Dim fileInfo = New FileInfo(srcFilename)
            Dim content = New MultipartFormDataContent()
            content.Headers.Add("filePath", filePath)
            content.Headers.Add("SecretCode", "tbN9NDBPf5")
            content.Add(New StreamContent(fileStream), """file""", String.Format("""{0}""", destFileName & fileInfo.Extension))
            Dim task = httpClient.PostAsync(url, content).ContinueWith(Function(t)
                                                                           If t.Status = TaskStatus.RanToCompletion Then
                                                                               Dim response = t.Result
                                                                               returnvalue = response.Content.ReadAsStringAsync().Result
                                                                               If Not String.IsNullOrWhiteSpace(returnvalue) Then
                                                                                   returnvalue = returnvalue.Replace("""", "").Trim()
                                                                               End If
                                                                               If response.StatusCode = System.Net.HttpStatusCode.OK Then
                                                                                   uploaded = True
                                                                               End If
                                                                           End If
                                                                           fileStream.Dispose()
                                                                       End Function)
            task.Wait()
            httpClient.Dispose()
            Return returnvalue
        Catch ex As Exception
            uploaded = False
            Throw ex
        End Try

        Return String.Empty
    End Function

    Private Function SendSMS(ByVal url As String) As Boolean
        Dim uploaded = False

        Try
            Dim httpClient = New HttpClient()
            Dim content = New MultipartFormDataContent()
            Dim task = httpClient.GetAsync(url).ContinueWith(Function(t)
                                                                 If t.Status = TaskStatus.RanToCompletion Then
                                                                     Dim response = t.Result
                                                                     If response.StatusCode = System.Net.HttpStatusCode.OK Then
                                                                         uploaded = True
                                                                     End If
                                                                 End If
                                                             End Function)
            task.Wait()
            httpClient.Dispose()
        Catch ex As Exception
            uploaded = False
            Throw ex
        End Try

        Return uploaded
    End Function

    Public Sub UploadSendWhatsUp(ByVal Pdf_File_Name As String, ByVal mobno As String)


        Dim Input_value As String = ""
        Input_value = InputBox("Enter WhatsApp Message", "Enter WhatsApp Message", "", 350, 350)


        Dim APIKey As String = WhatsAppKey
        Dim BaseUrl As String = WhatsAppUrl



        Wait_Window_Show(Me, "WhatsApp Sending Please Wait...")


        Dim PdfPath As String = Pdf_File_Name
        Dim url As String = "http://uploads.softtexerp.com/api/web/DoUpload/"
        Dim UploadedPdfUrl = UploadFile(url, PdfPath, PdfPath, "")



        'Dim UploadedPdfUrl = "https://vehicle.codywebs.com/uploads/VehicleService/TPI03-01-2025-PM-10-30-51.pdf"






        Dim Message As String = ""
        If _whatsappselectionmode = "MANUAL" Or _whatsappselectionmode = "MANUAL-2" Or _whatsappselectionmode = "USER WISE" Then
            Message = Input_value.Trim + " (From : " & COMPANY_NAME + " )"
        Else
            If Input_value.Trim = "" Then
                If EmailSubject > "" Then
                    Message = EmailSubject & " (From : " & COMPANY_NAME + " )"
                Else
                    Message = COMPANY_NAME
                End If

            Else
                Message = Input_value.Trim + " (From : " & COMPANY_NAME + " )"
            End If
        End If





        'Dim Message As String = COMPANY_NAME & "-" & Input_value
        Dim cache As Boolean = False
        Dim MobileNo As String = mobno
        Dim PdfUrl As String = UploadedPdfUrl
        Dim res As Boolean = False

        'Dim WhatsAppAPIURL As String = BaseUrl & "apikey=" & APIKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache & "&pdf=" & PdfUrl
        'Dim res = SendSMS(WhatsAppAPIURL)



        If _whatsappselectionmode = "MANUAL" Or _whatsappselectionmode = "MANUAL-1" Or _whatsappselectionmode = "MANUAL-2" Or _whatsappselectionmode = "USER WISE" Or _whatsappselectionmode = "DEAL" Then
            res = _WhatsappSending(MobileNo, Message, cache, PdfUrl, 2)
        Else
            res = _WhatsappSending(MobileNo, Message, cache, PdfUrl, 2)

            'Message = COMPANY_NAME
            'res = _WhatsappSending(MobileNo, Message, cache, "", 1)
        End If


        If res = True Then
            MessageBox.Show("You Have Successfully File Send To WhatsApp", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("WhatsApp Send Faild", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Wait_Window_Hide()
    End Sub
    ' Report_viewer.vb

    Public Sub LoadReport(ByVal cryRpt As ReportDocument)
        Try
            CrystalReportViewer1.Zoom(1)
            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MsgBox("Error while loading report: " & ex.Message)
        End Try
    End Sub


    Private Sub Report_viewer_Load(sender As Object, e As EventArgs) Handles Me.Load

        FirstStage.Columns.Clear()
        pnlGridView.Width = 1346
        pnlGridView.Height = 691
        pnlGridView.Location = New Point(1, 1)





        Dim _cudate As Date = CDate(Date.Now)
        Dim _FinanceDate As Date = "2026-12-15"
        If _cudate > _FinanceDate Then
            MsgBox("Print Option Not Work,Contact To Software Vendors Mob-98295-64406,75975-50208", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Close()
            Dispose(True)
        End If
    End Sub
    Private Sub Report_viewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        WhatsAppMobileNo = ""
    End Sub

    Private Sub BtnGridXls_Click(sender As Object, e As EventArgs) Handles BtnGridXls.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
End Class