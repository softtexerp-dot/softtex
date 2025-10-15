Imports System.Text

Friend Class DevGrigLayoutLoad
    Public _strQuery As StringBuilder
    Public _FormName As String
    Public ActiveFormName As Form
    Public gridName As DevExpress.XtraGrid.Views.Grid.GridView
    Private Sub DevGrigLayoutLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _LoadReport()

    End Sub

    Private Sub _LoadReport()

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" Schedule_id AS [File Name]")
            .Append(" ,Group_master_finance as [FileFullName]")
            .Append(" ,Main_account_master [FormName]")
            .Append(" ,STATEMASTER as [CompanyCode]")
            .Append(" from Vch_no ")
            .Append(" where 1=1 ")
            .Append(" AND Main_account_master='" & _FormName & "'")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _TmpTbl = DefaltSoftTable.Copy
        FirstStage.Columns.Clear()

        If _TmpTbl.Rows.Count > 0 Then
            GridControl1.DataSource = _TmpTbl
            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.GroupRowHeight = 30
            FirstStage.Columns(1).Visible = False
            FirstStage.Columns(2).Visible = False
            FirstStage.Columns(3).Visible = False
        Else
            MsgBox("File Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        End If

    End Sub

    Private Sub FirstStage_DoubleClick(sender As Object, e As EventArgs) Handles FirstStage.DoubleClick
        _GridLayoutFileName = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "FileFullName").ToString()
        Me.Close()
    End Sub

    Private Sub DevGrigLayoutLoad_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
            Dispose(True)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBox("Do You Want To Delete Report File(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
            sqL = " DELETE FROM Vch_no  WHERE  Group_master_finance='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "FileFullName").ToString() & "'"
            sql_Data_Save_Delete_Update()
            _LoadReport()
        End If


    End Sub
End Class