Imports System.Text

Public Class ReportForm
    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)

        GridControl1.Width = 974
        GridControl1.Height = 595
        GridControl1.Location = New Point(1, 1)
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs)
        Dim tblTmp = _GetQuery()
        REPORT_RPT_FILE_NAME = ""
        Dim RptTitle = ""
        'Dim Date_Range = "Date From:" & txt_From.Text & " To:" & txt_To.Text & " "
        'NewReportPrint(tblTmp, RptTitle, Date_Range)
    End Sub
    Private Function _GetQuery()

        'Generate_Date_For_DataBase(txt_From)
        'Generate_Date_For_DataBase(txt_To)
        _strQuery = New StringBuilder
        With _strQuery
            '.Append(" SELECT ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy

        Return tblTmp
    End Function

    Private Sub BtnExport_Click(sender As Object, e As EventArgs)
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub Btn_close_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub
End Class