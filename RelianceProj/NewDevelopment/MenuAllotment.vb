Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid

Public Class MenuAllotment
    ' Single Row Selection Result
    Public SelectedRowValues As New Dictionary(Of String, Object)()

    ' Multi Row Selection Result
    Public SelectedRowValuesList As New List(Of Dictionary(Of String, Object))()
    Public DataMenuName As DataTable
    Dim DataUserMenu As New DataTable
    Public DataMstUser As DataTable
    Public Property GridViewType As String
    Private Sub MenuAllotment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer = 0
        Dim y As Integer = 0
        Me.Location = New Point(x, y)
        LoadDataFromQuery()
    End Sub
    Private Sub LoadDataFromQuery()
        Try
            Dim dt As New DataTable()
            Dim _Query As New StringBuilder()

            With _Query
                .Append("SELECT ")
                .Append(" MenuName")
                .Append(" ,MainId")
                .Append(" ,MenuPositionId")
                .Append(" ,MainMenuPositionId")
                .Append(" ,MenuOrderNo ")
                .Append(" ,MenuPosition ")
                .Append(" ,MainMenuName")
                .Append(" ,SelectedFormName")
                .Append(" ,ActiveStatus")
                .Append(" FROM MenuName ")
                .Append(" WHERE 1=1 ")
                .Append(" AND MainMenuPositionId=0 ")
                .Append(" AND MenuName<>'-' ")
                .Append(" AND ActiveStatus='YES' ")
            End With

            RS = _Query.ToString()
            MenuDesign_QueryLoad()

            If DefaltSoftTable.Rows.Count > 0 Then
                DataMenuName = DefaltSoftTable.Copy()
            End If
            Dim _UserQuery As New StringBuilder()

            With _UserQuery
                .Append("SELECT ")
                .Append(" MenuId")
                .Append(" ,Menu")
                .Append(" ,MenuPositionId")
                .Append(" ,MainMenuPositionId")
                .Append(" ,OrderNo ")
                .Append(" ,MenuPosition ")
                .Append(" ,MainMenuName")
                .Append(" ,SelectForm")
                .Append(" FROM MenuTable ")
                .Append(" WHERE 1=1 ")
                .Append(" AND MainMenuPositionId=0 ")
                .Append(" AND Menu<>'-' ")
                .Append(" AND ACTIVE_STATUS='Y' ")
            End With

            RS = _UserQuery.ToString()
            SQLDBMENU_CONNECT()

            If DefaltSoftTable.Rows.Count > 0 Then
                DataUserMenu = DefaltSoftTable.Copy()
            End If
            If Not DataMenuName.Columns.Contains("SrNo") Then
                DataMenuName.Columns.Add("SrNo", GetType(Integer))
            End If
            If Not DataMenuName.Columns.Contains("IsMatched") Then
                DataMenuName.Columns.Add("IsMatched", GetType(String))
            End If
            If Not DataMenuName.Columns.Contains("IsChecked") Then
                DataMenuName.Columns.Add("IsChecked", GetType(Boolean))
            End If
            For i As Integer = 0 To DataMenuName.Rows.Count - 1
                DataMenuName.Rows(i)("SrNo") = i + 1
                Dim isMatch As Boolean = DataUserMenu.Select("Menu='" & DataMenuName.Rows(i)("MenuName").ToString().Replace("'", "''") & "'").Length > 0
                If isMatch Then
                    DataMenuName.Rows(i)("IsMatched") = "Y"
                    DataMenuName.Rows(i)("IsChecked") = True
                Else
                    DataMenuName.Rows(i)("IsMatched") = "N"
                    DataMenuName.Rows(i)("IsChecked") = False
                End If
            Next
            SelectionGrid.Columns.Clear()
            SelectionGridControl.DataSource = DataMenuName

            Dim repositoryCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = TryCast(SelectionGridControl.RepositoryItems.Add("CheckEdit"), DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit)
            repositoryCheckEdit1.ValueChecked = True
            repositoryCheckEdit1.ValueUnchecked = False
            repositoryCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked


            AddHandler SelectionGrid.RowStyle,
                Sub(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
                    Dim view = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

                    If e.RowHandle >= 0 Then
                        Dim value = view.GetRowCellValue(e.RowHandle, "IsMatched")
                        If value IsNot Nothing AndAlso value.ToString() = "Y" Then
                            e.Appearance.BackColor = Color.LightGreen
                        End If
                    End If
                End Sub
            If GridViewType = "SINGLE" Then
                DevGridFitColumnWiotScroll(SelectionGridControl, SelectionGrid)
            Else
                _DevGridColumSizeAutoAdjest(SelectionGridControl, SelectionGrid)
            End If
            SelectionGrid.OptionsView.ColumnAutoWidth = True
            SelectionGrid.BestFitColumns()
            If SelectionGrid.Columns("IsChecked") IsNot Nothing Then
                With SelectionGrid.Columns("IsChecked")
                    .Caption = "Check"
                    .VisibleIndex = 0
                    .Width = 60
                    .ColumnEdit = repositoryCheckEdit1
                    .OptionsColumn.FixedWidth = True
                End With
            End If
            If SelectionGrid.Columns("SrNo") IsNot Nothing Then
                With SelectionGrid.Columns("SrNo")
                    .VisibleIndex = 1
                    .Caption = "SrNo"
                    .Width = 60
                    .OptionsColumn.FixedWidth = True
                End With
            End If
            HideColumnsByName()

            SelectionGrid.OptionsView.ShowIndicator = False
            SelectionGrid.OptionsFind.AlwaysVisible = False
            SelectionGrid.OptionsView.ShowGroupPanel = False

            With SelectionGrid.Appearance
                .FocusedRow.ForeColor = Color.Empty
                .FocusedRow.Options.UseForeColor = False
                .HideSelectionRow.ForeColor = Color.Empty
                .HideSelectionRow.Options.UseForeColor = False
                .SelectedRow.ForeColor = Color.Empty
                .SelectedRow.Options.UseForeColor = False
                .Row.ForeColor = Color.Black
            End With

            SelectionGrid.OptionsSelection.EnableAppearanceHotTrackedRow = False

            With SelectionGrid
                .OptionsSelection.EnableAppearanceFocusedCell = True
                .Appearance.FocusedCell.BackColor = Color.LightSkyBlue
                .Appearance.FocusedCell.ForeColor = Color.Black
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub HideColumnsByName()
        Try

            Dim _TickMarkClm As String = ""

            If GridViewType = "SINGLE" Then
                _TickMarkClm = "MainId"
            End If

            Dim columnsToHide As String() = {"MainId", "MenuPositionId", "MainMenuPositionId", "MenuOrderNo", "MenuPosition", _TickMarkClm, "BlackList", "MainMenuName", "SelectedFormName", "IsMatched", "ActiveStatus"}

            For Each colName In columnsToHide
                Dim col = SelectionGrid.Columns.ColumnByFieldName(colName)
                If col IsNot Nothing Then
                    col.Visible = False
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SelectionGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles SelectionGrid.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim rowHandle As Integer = SelectionGrid.FocusedRowHandle
                If rowHandle >= 0 Then
                    Dim currentValue As Object = SelectionGrid.GetRowCellValue(rowHandle, "IsChecked")
                    Dim isChecked As Boolean = False
                    If currentValue IsNot Nothing AndAlso currentValue IsNot DBNull.Value Then
                        Boolean.TryParse(currentValue.ToString(), isChecked)
                    End If
                    If isChecked = False Then
                        SelectionGrid.SetRowCellValue(rowHandle, "IsChecked", True)
                    Else
                        SelectionGrid.SetRowCellValue(rowHandle, "IsChecked", False)
                    End If
                End If
                e.Handled = True
                Dim nextRowHandle = SelectionGrid.FocusedRowHandle + 1
                If nextRowHandle < SelectionGrid.RowCount Then
                    SelectionGrid.FocusedRowHandle = nextRowHandle
                    SelectionGrid.FocusedColumn = SelectionGrid.VisibleColumns(0) ' Optional: focus first column
                End If
                e.Handled = True
                e.SuppressKeyPress = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        For Each dr As DataRow In DataMenuName.Rows
            'Sirf checked rows save hongi
            If Convert.ToBoolean(dr("IsChecked")) = True Then

                Dim _ActiveStatus As String =
                    If(dr("IsMatched").ToString() = "Y", "Y", "N")

                If MSA_CONN.State = ConnectionState.Closed Then
                    MSA_CONN.Open()
                End If
                Dim deleteCommand As New OleDb.OleDbCommand("", MSA_CONN)
                deleteCommand.CommandText = "DELETE FROM MenuTable WHERE MenuId = ?"
                deleteCommand.Parameters.Clear()
                deleteCommand.Parameters.AddWithValue("@MenuId", dr("MainId"))
                deleteCommand.ExecuteNonQuery()
                deleteCommand.Dispose()
                Dim command As New OleDb.OleDbCommand("", MSA_CONN)
                command.CommandText =
                    "INSERT INTO MenuTable " &
                    "(MenuId, Menu, SUBID, ORDERNO, MenuPosition, SELECTFORM, " &
                    "MenuPositionId, MainMenuPositionId, MainMenuName, Active_Status, OP10) " &
                    "VALUES (?,?,?,?,?,?,?,?,?,?,?)"
                command.Parameters.Clear()
                command.Parameters.AddWithValue("@MenuId", dr("MainId"))
                command.Parameters.AddWithValue("@Menu", dr("MenuName").ToString())
                command.Parameters.AddWithValue("@SUBID", dr("MenuPositionId"))
                command.Parameters.AddWithValue("@ORDERNO", dr("MenuOrderNo"))
                command.Parameters.AddWithValue("@MenuPosition", dr("MenuPosition"))
                command.Parameters.AddWithValue("@SELECTFORM", dr("SelectedFormName").ToString())
                command.Parameters.AddWithValue("@MenuPositionId", dr("MenuPositionId"))
                command.Parameters.AddWithValue("@MainMenuPositionId", dr("MainMenuPositionId"))
                command.Parameters.AddWithValue("@MainMenuName", dr("MainMenuName").ToString())
                command.Parameters.AddWithValue("@Active_Status", _ActiveStatus)
                command.Parameters.AddWithValue("@OP10", "New Menu")
                command.ExecuteNonQuery()
                command.Dispose()
            End If
        Next


        ''MstUser Data
        'RS = " SELECT User_Id,ActiveStatus,* FROM MstUser WHERE 1=1 ORDER BY Id"
        'SQLDBMENU_CONNECT()
        'If DefaltSoftTable IsNot Nothing AndAlso DefaltSoftTable.Rows.Count > 0 Then
        '    DataMstUser = DefaltSoftTable.Copy
        'End If

        ''user master data
        'Dim Fnlmenutbl As DataTable
        'Fnlmenutbl = DataUserMenu.Clone
        'For Each dr As DataRow In DataUserMenu.Select
        '    For Each dr1 As DataRow In DataMenuName.Select("MainId='" & dr("MenuId") & "' ")
        '        Fnlmenutbl.ImportRow(dr1)
        '    Next
        'Next

        'Dim _USerWIseMEnuTbl As New DataTable
        '_USerWIseMEnuTbl = DataMenuName.Clone
        'Dim startSubMenuId As Integer = 8
        'Dim endSubMenuId As Integer = 23
        'For Each dr As DataRow In DataMstUser.Select()
        '    'Step 1 : Header range (8 to 23) ke liye
        '    For _submenuid As Integer = startSubMenuId To endSubMenuId
        '        For Each dr1 As DataRow In DataUserMenu.Select("USERID='" & dr("USER_ID") & "'")
        '            If Val(dr1("MENUID")) = _submenuid Then
        '                For Each dr2 As DataRow In DataMenuName.Select("MainMenuPositionId='" & _submenuid & "' AND ActiveStatus='YES'")
        '                    Dim _ActiveStatus As String =
        '                            If(dr2("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
        '                    If MSA_CONN.State = ConnectionState.Closed Then
        '                        MSA_CONN.Open()
        '                    End If
        '                    Dim command As New OleDb.OleDbCommand(RS, MSA_CONN)
        '                    command.CommandText =
        '                            "INSERT INTO UserMenu " &
        '                            "(MenuId, UserId, Active_Status) " &
        '                            "VALUES (?,?,?)"
        '                    command.Parameters.Clear()
        '                    command.Parameters.AddWithValue("@MenuId", dr2("MainId"))
        '                    command.Parameters.AddWithValue("@UserId", dr("USER_ID"))
        '                    command.Parameters.AddWithValue("@Active_Status", _ActiveStatus)
        '                    command.ExecuteNonQuery()
        '                    command.Dispose()
        '                Next
        '            End If
        '        Next
        '    Next
        'Next
        If MSA_CONN.State = ConnectionState.Open Then
            MSA_CONN.Close()
        End If

        MessageBox.Show("Selected Menu Saved Successfully")
    End Sub
End Class