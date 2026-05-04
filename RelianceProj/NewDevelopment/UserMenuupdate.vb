Imports System.Text

Public Class UserMenuupdate
    Private _TblName As String = "MenuTable"
    Private _KeyFieldName As String = "MenuId"
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = " Report From : User Menu Details "
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub UserMenuupdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        View_Record()
    End Sub
    Private Sub View_Record()
        Dim _UserQuery As New StringBuilder()
        With _UserQuery
            .Append("SELECT ")
            .Append(" MenuId")
            .Append(" ,Menu")
            .Append(" ,MenuPositionId")
            .Append(" ,MainMenuPositionId")
            .Append(" ,OrderNo ")
            .Append(" ,Active_Status As ActiveStatus")
            .Append(" ,MenuIsSparate ")
            .Append(" ,MenuPosition ")
            .Append(" ,MainMenuName")
            .Append(" ,SelectForm")
            .Append(" FROM MenuTable ")
            .Append(" WHERE 1=1 ")
            .Append(" AND Menu<>'-' ")
            .Append(" AND ACTIVE_STATUS='Y' ")
        End With

        RS = _UserQuery.ToString()
        SQLDBMENU_CONNECT()
        Dim tblTmp As DataTable
        tblTmp = DefaltSoftTable.Copy
        Dim Qty As String = ""
        If tblTmp.Rows.Count > 0 Then
            GridControl1.DataSource = tblTmp.Copy
            For Each dc As DataColumn In tblTmp.Columns
                Dim isEmptyOrZero As Boolean = True
                If dc.ColumnName.ToUpper() = "ID" Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                    Continue For
                End If
                For Each dr As DataRow In tblTmp.Rows
                    If Not IsDBNull(dr(dc)) Then
                        Dim val As String = dr(dc).ToString().Trim()
                        ' 🔴 अगर कोई value meaningful है → column visible रहेगा
                        If val <> "" AndAlso val <> "0" AndAlso val <> "0.00" Then
                            isEmptyOrZero = False
                            Exit For
                        End If
                    End If
                Next
                If isEmptyOrZero Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                End If
            Next
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
            Next

            ' Step 2: Sirf required columns editable
            FirstStage.Columns("Menu").OptionsColumn.AllowEdit = True
            FirstStage.Columns("OrderNo").OptionsColumn.AllowEdit = True
            FirstStage.Columns("MainMenuName").OptionsColumn.AllowEdit = True
            DevGridFitColumn(GridControl1, FirstStage)
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            GridControl1.BringToFront()
            FirstStage.OptionsBehavior.Editable = True
            FirstStage.OptionsBehavior.ReadOnly = False
            FirstStage.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
        For Each dr As DataRow In dt.Rows
            If dr.RowState = DataRowState.Modified Then
                Dim cmd As New OleDb.OleDbCommand(RS, MSA_CONN)
                If MSA_CONN.State = ConnectionState.Closed Then
                    MSA_CONN.Open()
                End If
                cmd.CommandText =
                    "UPDATE " & _TblName & " SET " &
                    "Menu = ?, " &
                    "OrderNo = ?, " &
                    "MainMenuName = ?, " &
                    "MenuIsSparate = ?, " &
                    "Active_Status = ? " &
                    "WHERE MenuId = ?"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("", dr("Menu").ToString())
                cmd.Parameters.AddWithValue("", dr("OrderNo"))
                cmd.Parameters.AddWithValue("", dr("MainMenuName").ToString())
                cmd.Parameters.AddWithValue("", dr("MenuIsSparate").ToString())
                cmd.Parameters.AddWithValue("", dr("ActiveStatus").ToString())
                ' WHERE condition
                cmd.Parameters.AddWithValue("", dr("MenuId"))
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Next
        MSA_CONN.Close()
        MessageBox.Show("Data Updated Successfully")
    End Sub
    Private Sub FirstStage_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown, FirstStage.KeyDown
        If e.KeyCode = Keys.Space Then
            If FirstStage.FocusedColumn.FieldName = "ActiveStatus" Then
                Dim currentValue As String = FirstStage.GetFocusedRowCellValue("ActiveStatus").ToString().ToUpper()
                If currentValue = "Y" Then
                    FirstStage.SetFocusedRowCellValue("ActiveStatus", "N")
                Else
                    FirstStage.SetFocusedRowCellValue("ActiveStatus", "Y")
                End If
                e.Handled = True
            End If
            If FirstStage.FocusedColumn.FieldName = "MenuIsSparate" Then
                Dim currentValue As Boolean = False
                If Not IsDBNull(FirstStage.GetFocusedRowCellValue("MenuIsSparate")) Then
                    currentValue = Convert.ToBoolean(FirstStage.GetFocusedRowCellValue("MenuIsSparate"))
                End If
                FirstStage.SetFocusedRowCellValue("MenuIsSparate", Not currentValue)
                e.Handled = True
            End If
        End If
    End Sub
End Class