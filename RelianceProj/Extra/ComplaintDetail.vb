Imports System.IO
Imports System.Net.Http
Imports DevExpress.XtraGrid.Views.Grid
Imports Newtonsoft.Json.Linq

Public Class ComplaintDetail
    Public flagstring As String = ""
    Public id As Int64 = "0"
    'Private WithEvents repoButtonView As RepositoryItemButtonEdit
    Private Sub btnAddcomplaint_Click(sender As Object, e As EventArgs) Handles btnAddcomplaint.Click
        complaint.flagstring = "save"
        complaint.Show()
    End Sub

    Private Sub ComplaintDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        'gridControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBox1.SelectedText = "All"
        If ComboBox1.SelectedItem IsNot Nothing Then
            LoadComplaints(ComboBox1.SelectedItem.ToString())
        Else
            LoadComplaints("")   ' ya default status
        End If
        ApplyGridStyle()
    End Sub
    Public Async Function LoadComplaints(filterStatus As String) As Task
        Dim GStNo As String = COMPANY_TBL.Rows(0).Item("GstNo")
        'Dim GStNo As String = "08GURUGST123456"
        'Dim apiUrl As String = "http://softtexcomplaintapi.softtexerp.com/api/Complaint/Complaints"
        Dim apiUrl As String = "http://softtexcomplaintapi.softtexerp.com/api/Complaint/CustomerComplaints?gstNo=" & GStNo & ""
        Try
            Using client As New HttpClient()
                client.DefaultRequestHeaders.Accept.Clear()
                client.DefaultRequestHeaders.Accept.Add(
                New Headers.MediaTypeWithQualityHeaderValue("*/*"))
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                If Not response.IsSuccessStatusCode Then
                    MessageBox.Show("Failed to fetch data")
                    Exit Function
                End If
                Dim jsonString As String = Await response.Content.ReadAsStringAsync()
                Dim jsonObj As JObject = JObject.Parse(jsonString)
                Dim dataArray As JArray = CType(jsonObj("Data"), JArray)
                Dim dt As New DataTable()
                ' 🔹 Columns (Grid me dikhane wale)
                dt.Columns.Add("TkNo", GetType(Integer))
                dt.Columns.Add("PartyName", GetType(String))
                dt.Columns.Add("Message", GetType(String))
                dt.Columns.Add("Module", GetType(String))
                dt.Columns.Add("AttedBy", GetType(String))
                dt.Columns.Add("ComplaintDate", GetType(DateTime))
                dt.Columns.Add("Status", GetType(String))
                dt.Columns.Add("SolveDate", GetType(DateTime))
                dt.Columns.Add("SolveRemark", GetType(String))
                dt.Columns.Add("SolvedBy", GetType(String))
                dt.Columns.Add("GstNo", GetType(String))
                dt.Columns.Add("SenderName", GetType(String))
                dt.Columns.Add("DbName", GetType(String))
                dt.Columns.Add("SenderMobileNo", GetType(String))
                dt.Columns.Add("Priority", GetType(Boolean))
                dt.Columns.Add("Complaint", GetType(String))
                dt.Columns.Add("ViewImage", GetType(String))
                dt.Columns.Add("Transfer", GetType(String))
                dt.Columns.Add("ApiImagePath", GetType(String))
                For Each item As JObject In dataArray
                    Dim row As DataRow = dt.NewRow()
                    row("TkNo") = item("Id")
                    row("PartyName") = item("PartyName")?.ToString()
                    row("Message") = item("ErrorMassge")?.ToString()
                    row("Module") = item("Module")?.ToString()
                    row("AttedBy") = item("AttedBy")?.ToString()
                    row("Status") = item("Status")?.ToString()
                    row("SolveRemark") = item("CompleteInforme")?.ToString()
                    row("SolvedBy") = item("SolvedBy")?.ToString()
                    row("GstNo") = item("GstNo")?.ToString()
                    'row("DbName") = item("DbName")?.ToString()
                    row("SenderName") = item("SenderName")?.ToString()
                    row("SenderMobileNo") = item("SenderMobileNo")?.ToString()
                    row("Priority") = If(item("Priority") IsNot Nothing, CBool(item("Priority")), False)
                    'row("ViewImage") = item("ErrorImage")?.ToString()

                    row("ViewImage") = "View"     ' view button code
                    row("Transfer") = If(item("TransferredData") IsNot Nothing, item("TransferredData").ToString(Newtonsoft.Json.Formatting.None), "[]")
                    row("ApiImagePath") = item("ErrorImage")   ' e.g. /Uploads/Complaints/xxx.png
                    ' Date handling
                    Dim compDate As DateTime
                    If DateTime.TryParse(item("ComplaintDate")?.ToString(), compDate) Then
                        row("ComplaintDate") = compDate
                    Else
                        row("ComplaintDate") = DBNull.Value
                    End If

                    Dim solveDate As DateTime
                    If DateTime.TryParse(item("SolveDate")?.ToString(), solveDate) Then
                        row("SolveDate") = solveDate
                    Else
                        row("SolveDate") = DBNull.Value
                    End If
                    Dim transferred As JToken = item("TransferredData")

                    If transferred IsNot Nothing AndAlso transferred.Type = JTokenType.Array AndAlso transferred.HasValues Then
                        Dim transfers As New List(Of String)
                        For Each t As JToken In transferred
                            transfers.Add($"{t("TransferredFrom")} → {t("TransferredTo")} ({t("Remark")}) [{t("TransferDate")}]")
                        Next
                        row("Complaint") = String.Join(Environment.NewLine, transfers)
                    Else
                        row("Complaint") = String.Empty   ' blank if empty array
                    End If
                    dt.Rows.Add(row)
                Next
                ' 🔹 Bind to GridControl
                gridControl1.DataSource = dt
                If dt IsNot Nothing AndAlso dt.Columns.Contains("TkNo") Then
                    Dim dv As DataView = dt.DefaultView
                    dv.Sort = "TkNo DESC"
                    dt = dv.ToTable()
                End If
                If gridControl1.DataSource IsNot Nothing Then
                    dt = TryCast(gridControl1.DataSource, DataTable)
                    If dt Is Nothing Then
                        Exit Function
                    End If
                    Dim selectedStatus As String = ComboBox1.Text   ' SAFE
                    Select Case selectedStatus
                        Case "Pending", "OK", "Running", "Cancel", "Hold"
                            dt.DefaultView.RowFilter = $"Status = '{selectedStatus}'"
                        Case Else
                            dt.DefaultView.RowFilter = ""   ' Show all
                    End Select
                End If
                gridView1.Columns("ComplaintDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                gridView1.Columns("ComplaintDate").DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt"
                gridView1.Columns("SolveDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                gridView1.Columns("SolveDate").DisplayFormat.FormatString = "dd-MM-yyyy hh:mm tt"
                gridView1.BestFitColumns()
                columnvisible()
                columnWidth()
                '🔹 View Button Repository (ONLY ONCE)
                viewbutton()
                TransferButton()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
#Region "View Button"
    Private Sub viewbutton()
        Dim repoButtonView As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        repoButtonView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        repoButtonView.Buttons.Clear()

        Dim btn As New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
        btn.Caption = "View"
        btn.Appearance.Font = New Font("Verdana", 8, FontStyle.Bold)
        btn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        btn.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        btn.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        repoButtonView.Buttons.Add(btn)

        gridControl1.RepositoryItems.Add(repoButtonView)

        If gridView1.Columns("ViewImage") IsNot Nothing Then
            gridView1.Columns("ViewImage").ColumnEdit = repoButtonView
            gridView1.Columns("ViewImage").OptionsColumn.AllowEdit = True
        End If

        AddHandler gridView1.RowCellStyle, Sub(s, e)
                                               If e.Column.FieldName <> "ViewImage" Then Exit Sub

                                               Dim gv As GridView = CType(s, GridView)
                                               Dim apiPath As String = Convert.ToString(gv.GetRowCellValue(e.RowHandle, "ApiImagePath"))

                                               If Not String.IsNullOrWhiteSpace(apiPath) Then
                                                   e.Appearance.BackColor = Color.LightGreen
                                               Else
                                                   e.Appearance.BackColor = Color.White
                                               End If
                                           End Sub

        AddHandler repoButtonView.ButtonClick,
Async Sub(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

    Dim gv As GridView = CType(gridControl1.MainView, GridView)
    'Dim gv As GridView = CType(gridView1, GridView)
    Dim rowHandle As Integer = gv.FocusedRowHandle
    If rowHandle < 0 Then Exit Sub
    Dim imagePath As String = Convert.ToString(gv.GetRowCellValue(rowHandle, "ApiImagePath"))
    If String.IsNullOrWhiteSpace(imagePath) Then
        MessageBox.Show("⚠ No image available.")
        Exit Sub
    End If
    Dim baseUrl As String = "http://softtexcomplaintapi.softtexerp.com/"
    Dim validUrl As String = If(imagePath.StartsWith("http", StringComparison.OrdinalIgnoreCase), imagePath, baseUrl & imagePath.TrimStart("/"c))
    Using httpclient As New HttpClient()
        Dim bytes = Await httpclient.GetByteArrayAsync(validUrl)
        Using ms As New MemoryStream(bytes)
            ShowZoomImage(Image.FromStream(ms))
        End Using
    End Using
End Sub
    End Sub
    Private Sub ShowZoomImage(img As Image)
        If img Is Nothing Then Exit Sub
        Dim frm As New Form With {
        .Text = "Complaint Receipt",
        .StartPosition = FormStartPosition.CenterScreen,
        .Size = New Size(1000, 700),
        .FormBorderStyle = FormBorderStyle.Sizable,
        .MaximizeBox = True,
        .MinimizeBox = False,
        .KeyPreview = True
    }
        Dim pic As New PictureBox With {.Image = img, .Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.Zoom, .BackColor = Color.Black}
        frm.Controls.Add(pic)
        AddHandler frm.KeyDown, Sub(s, e)
                                    If e.KeyCode = Keys.Escape Then
                                        frm.Close()
                                    End If
                                End Sub
        frm.ShowDialog()
    End Sub

#End Region
#Region "Transfer Complaint"
    Private Sub TransferButton()
        If gridView1.Columns.ColumnByFieldName("Transfer") Is Nothing Then
            Exit Sub
        End If
        Dim repoTransfer As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        repoTransfer.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        repoTransfer.Buttons.Clear()
        Dim btn As New DevExpress.XtraEditors.Controls.EditorButton(
        DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
        btn.Caption = "Transfer"
        repoTransfer.Buttons.Add(btn)
        gridControl1.RepositoryItems.Add(repoTransfer)
        With gridView1.Columns("Transfer")
            .ColumnEdit = repoTransfer
            .Visible = True
            .Width = 90
        End With
        AddHandler repoTransfer.ButtonClick, AddressOf TransferButton_Click
    End Sub
    Private Sub TransferButton_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim rowHandle As Integer = gridView1.FocusedRowHandle
        If rowHandle < 0 Then Exit Sub
        Dim complaintId As Integer = Convert.ToInt32(gridView1.GetRowCellValue(rowHandle, "TkNo"))
        Dim status As String = Convert.ToString(gridView1.GetRowCellValue(rowHandle, "Status"))
        If status.Equals("Solved", StringComparison.OrdinalIgnoreCase) Then
            MessageBox.Show("Solved complaint cannot be transferred.", "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ' Transfer column se JSON read karein
        Dim transferJson As String = Convert.ToString(gridView1.GetRowCellValue(rowHandle, "Transfer"))
        If String.IsNullOrWhiteSpace(transferJson) OrElse transferJson = "[]" Then
            MessageBox.Show("No transfer history available.", "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim transferArray As JArray
        Try
            transferArray = JArray.Parse(transferJson)
        Catch ex As Exception
            MessageBox.Show("Invalid transfer history data.", "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
        If transferArray.Count = 0 Then
            MessageBox.Show("No transfer history available.", "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ' Transfer history DataTable
        Dim transferList As New DataTable()
        transferList.Columns.Add("TransferredFrom", GetType(String))
        transferList.Columns.Add("TransferredTo", GetType(String))
        transferList.Columns.Add("Remark", GetType(String))
        transferList.Columns.Add("TransferDate", GetType(String))
        For Each t As JObject In transferArray
            Dim dr As DataRow = transferList.NewRow()
            dr("TransferredFrom") = If(t("TransferredFrom") IsNot Nothing, t("TransferredFrom").ToString(), "")
            dr("TransferredTo") = If(t("TransferredTo") IsNot Nothing, t("TransferredTo").ToString(), "")
            dr("Remark") = If(t("Remark") IsNot Nothing, t("Remark").ToString(), "")
            Dim transferDate As DateTime
            If DateTime.TryParse(If(t("TransferDate") IsNot Nothing, t("TransferDate").ToString(), ""), transferDate) Then
                dr("TransferDate") = transferDate.ToString("dd-MM-yyyy hh:mm tt")
            Else
                dr("TransferDate") = ""
            End If
            transferList.Rows.Add(dr)
        Next
        ' Popup Form
        Dim popup As New DevExpress.XtraEditors.XtraForm()
        popup.Text = "Transfer History - Complaint No: " & complaintId.ToString()
        popup.StartPosition = FormStartPosition.CenterScreen
        popup.Size = New Size(850, 400)
        popup.MinimizeBox = False
        popup.MaximizeBox = True
        Dim gc As New DevExpress.XtraGrid.GridControl()
        Dim gv As New DevExpress.XtraGrid.Views.Grid.GridView()
        gc.Dock = DockStyle.Fill
        gc.MainView = gv
        gc.ViewCollection.Add(gv)
        gc.DataSource = transferList
        gv.OptionsBehavior.Editable = False
        gv.OptionsView.ShowGroupPanel = False
        gv.OptionsView.ColumnAutoWidth = False
        gv.OptionsView.ShowAutoFilterRow = True
        gv.BestFitColumns()
        popup.Controls.Add(gc)
        popup.ShowDialog(Me)
    End Sub
#End Region
    Private Sub columnvisible()
        gridView1.Columns("PartyName").Width = 150
        gridView1.Columns("Message").Width = 450
        gridView1.Columns("TkNo").Visible = False
        gridView1.Columns("PartyName").Visible = False
        gridView1.Columns("Module").Visible = False
        gridView1.Columns("AttedBy").Visible = False
        'gridView1.Columns("SolveRemark").Visible = False
        gridView1.Columns("Priority").Visible = False
        gridView1.Columns("SolvedBy").Visible = False
        gridView1.Columns("GstNo").Visible = False
        gridView1.Columns("DbName").Visible = False
        gridView1.Columns("Complaint").Visible = False
        gridView1.Columns("ApiImagePath").Visible = False
        'column do not editable
        gridView1.Columns("Message").OptionsColumn.AllowEdit = False
        gridView1.Columns("Message").OptionsColumn.ReadOnly = True
        gridView1.Columns("ComplaintDate").OptionsColumn.AllowEdit = False
        gridView1.Columns("ComplaintDate").OptionsColumn.ReadOnly = True
        gridView1.Columns("Status").OptionsColumn.AllowEdit = False
        gridView1.Columns("Status").OptionsColumn.ReadOnly = True
        gridView1.Columns("SolveDate").OptionsColumn.AllowEdit = False
        gridView1.Columns("SolveDate").OptionsColumn.ReadOnly = True
        gridView1.Columns("SenderName").OptionsColumn.AllowEdit = False
        gridView1.Columns("SenderName").OptionsColumn.ReadOnly = True
        gridView1.Columns("SolveRemark").OptionsColumn.AllowEdit = False
        gridView1.Columns("SolveRemark").OptionsColumn.ReadOnly = True
        gridView1.Columns("SenderMobileNo").OptionsColumn.AllowEdit = False
        gridView1.Columns("SenderMobileNo").OptionsColumn.ReadOnly = True
    End Sub
    Private Sub columnWidth()
        gridView1.Columns("TkNo").Width = 80
        gridView1.Columns("PartyName").Width = 150
        Dim memoEdit As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        memoEdit.WordWrap = True
        memoEdit.ScrollBars = ScrollBars.Vertical

        gridControl1.RepositoryItems.Add(memoEdit)

        With gridView1.Columns("Message")
            .ColumnEdit = memoEdit
            .Width = 450
        End With
        gridView1.Columns("Message").AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        gridView1.OptionsView.RowAutoHeight = True
    End Sub

    Private Sub ApplyGridStyle()
        With gridView1.Appearance.HeaderPanel
            .Font = New Font("Verdana", 8, FontStyle.Bold)
            .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            .BackColor = Color.LightGray
        End With
        gridView1.Appearance.HeaderPanel.Options.UseFont = True
        gridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        'Row color
        gridView1.Appearance.Row.BackColor = Color.LightYellow
        'Row height
        'gridView1.RowHeight = 28
        'gridView1.Appearance.Row.Font = New Font("Verdana", 8.5F)
        gridView1.Appearance.Row.Options.UseFont = True

        'Both scroll allow
        gridView1.OptionsView.ColumnAutoWidth = False

        'gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        'gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always

        'grid auto filter option add karne ke liye
        gridView1.OptionsView.ShowAutoFilterRow = True

        'gridcotrol edit mode disable all column
        'gridView1.OptionsBehavior.Editable = False

    End Sub

    Private Sub gridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridView1.RowStyle
        If e.RowHandle >= 0 Then
            Dim value As Object = gridView1.GetRowCellValue(e.RowHandle, "Priority")
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                Dim isPriority As Boolean = False
                ' Handle both Boolean and String
                If TypeOf value Is Boolean Then
                    isPriority = CBool(value)
                Else
                    Boolean.TryParse(value.ToString(), isPriority)
                End If
                If isPriority Then
                    e.Appearance.BackColor = Color.Red
                    e.Appearance.ForeColor = Color.White
                    ' Prevent DevExpress overriding
                    e.HighPriority = True
                    e.Appearance.BackColor2 = Color.Red
                End If
            End If
        End If
        ' 🔹 Focused row style preserve
        If e.RowHandle = gridView1.FocusedRowHandle Then
            Dim val As Object = gridView1.GetRowCellValue(e.RowHandle, "Priority")
            If val IsNot Nothing AndAlso val.ToString().ToLower() = "true" Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
                e.HighPriority = True
            End If

        End If
    End Sub

    Private Sub gridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles gridView1.RowCellStyle
        ' Sirf Status column par color apply kare
        If e.Column.FieldName <> "Status" Then Exit Sub
        If e.RowHandle < 0 Then Exit Sub
        Dim status As String = Convert.ToString(gridView1.GetRowCellValue(e.RowHandle, "Status"))
        Select Case status
            Case "OK"
                e.Appearance.ForeColor = Color.Green
            Case "Pending"
                e.Appearance.ForeColor = Color.Red
            Case "Cancel"
                e.Appearance.ForeColor = Color.Blue
            Case "Running"
                e.Appearance.ForeColor = Color.LightYellow
            Case "Hold"
                e.Appearance.ForeColor = Color.Orange
            Case Else
                e.Appearance.ForeColor = Color.Black
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim dt As DataTable = TryCast(gridControl1.DataSource, DataTable)
        If dt Is Nothing Then Exit Sub
        Dim selectedStatus As String = ComboBox1.Text   ' SAFE
        If selectedStatus <> "" AndAlso selectedStatus <> "All" Then
            dt.DefaultView.RowFilter = $"Status = '{selectedStatus}'"
        Else
            dt.DefaultView.RowFilter = ""
        End If
    End Sub

    Private Sub gridView1_DoubleClick(sender As Object, e As EventArgs) Handles gridView1.DoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view Is Nothing Then Exit Sub
        If view.FocusedRowHandle < 0 Then Exit Sub
        complaint.Show()
        complaint.flagstring = "update"
        complaint.lblid.Text = Convert.ToInt64(view.GetFocusedRowCellValue("TkNo"))
        ' 🔹 Data fill into form
        complaint.txtCompName.Text = Convert.ToString(view.GetFocusedRowCellValue("PartyName"))
        complaint.txtMessage.Text = Convert.ToString(view.GetFocusedRowCellValue("Message"))
        complaint.txtFilePath.Text = Convert.ToString(view.GetFocusedRowCellValue("ApiImagePath"))
        complaint.Txtsendername.Text = Convert.ToString(view.GetFocusedRowCellValue("SenderName"))
        complaint.Txtmobileno.Text = Convert.ToString(view.GetFocusedRowCellValue("SenderMobileNo"))
        complaint.RadioButton1.Checked = Convert.ToString(view.GetFocusedRowCellValue("Priority"))
        complaint.btnSave.Text = "Update"
        complaint.btnSave.Width = 86
    End Sub

    Private Sub ComplaintDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

End Class