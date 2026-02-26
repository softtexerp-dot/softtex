Imports System.Text

Public Class PrintViewPage
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim tblTmp = _GetQuery()

        If tblTmp.Rows.Count > 0 Then
            REPORT_RPT_FILE_NAME = "Testing_1"
            Dim RptTitle = "Repert Titlle"
            Dim Date_Range = "Date From:" & txt_From.Text & " To:" & txt_To.Text & " "
            NewReportPrint(tblTmp, RptTitle, Date_Range)
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        End If
    End Sub
    Private Function _GetQuery()

        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        _strQuery = New StringBuilder
        With _strQuery
            'strQuery = "SELECT TOP 1 ENTRYNO FROM " & _TblName & "  WHERE BOOKCODE='" & _Bookcode & "' ORDER BY ENTRYNO DESC "
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy

        Return tblTmp
    End Function

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub PrintViewPage_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then

            If PnlView.Visible = True Then
                PnlView.Visible = False
                txt_From.Focus()
                Exit Sub
            End If
            Me.Close()
            Me.Dispose(True)

        End If
    End Sub

    Private Sub PrintViewPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        PnlView.Width = 974
        PnlView.Height = 595
        PnlView.Location = New Point(0, 40)

        'txt_From.Focus()
        'PnlView.Controls("txt_From").Focus()
    End Sub
End Class