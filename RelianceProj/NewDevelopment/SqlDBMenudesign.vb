Imports System.Data.Common
Imports System.Text
Imports DevExpress.XtraReports.Design
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb


Public Class SqlDBMenudesign
    Public Datamenutable As DataTable
    Public DatauserMenu As DataTable
    Public DataMenuName As DataTable
    Public DataMstUser As DataTable
    Public InsertDataMenuNameTable As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            RS = "SELECT top 1 * FROM MenuTable WHERE 1=1 and OP10='New Menu' ORDER BY Id"
            SQLDBMENU_CONNECT()
            If DefaltSoftTable IsNot Nothing AndAlso DefaltSoftTable.Rows.Count > 0 Then
                Exit Sub
            End If

            'Master MenuName Data
            RS = " SELECT * FROM MenuName WHERE 1=1 ORDER BY MainId"
            MenuDesign_QueryLoad()
            If DefaltSoftTable.Rows.Count > 0 Then
                DataMenuName = DefaltSoftTable.Copy
            End If

            'MenuTable Data
            RS = "SELECT * FROM MenuTable WHERE 1=1 ORDER BY Id"
            SQLDBMENU_CONNECT()
            If DefaltSoftTable IsNot Nothing Then
                Datamenutable = DefaltSoftTable.Copy

                If Not DefaltSoftTable.Columns.Contains("MenuPositionId") Then
                    RS = "ALTER TABLE MenuTable " &
     "ADD COLUMN MenuID Number, " &
     "MenuPosition Number, " &
     "MenuPositionId Number, " &
     "MainMenuPositionId Number, " &
     "MenuIsSparate TEXT(20), " &
     "MainMenuName TEXT(255), " &
     "ShortCutKey TEXT(50), " &
     "IconPath TEXT(50), " &
     "Tooltip TEXT(50), " &
     "MenuType TEXT(255)"
                    SQLDBMENU_Save_Delete_Update()
                End If
            End If


            'UserMenu Data
            RS = " SELECT MenuID,UserID,Active_Status,* FROM UserMenu WHERE 1=1 "
            SQLDBMENU_CONNECT()
            If DefaltSoftTable IsNot Nothing AndAlso DefaltSoftTable.Rows.Count > 0 Then
                DatauserMenu = DefaltSoftTable.Copy
            End If

            'MstUser Data
            RS = " SELECT User_Id,ActiveStatus,* FROM MstUser WHERE 1=1 ORDER BY Id"
            SQLDBMENU_CONNECT()
            If DefaltSoftTable IsNot Nothing AndAlso DefaltSoftTable.Rows.Count > 0 Then
                DataMstUser = DefaltSoftTable.Copy
            End If

            Dim FnlTbl As DataTable
            FnlTbl = DataMenuName.Clone
            'menu master data
            'For Each dr1 As DataRow In DataMenuName.Select("ActiveStatus='YES'")


            Dim _TmpSqlMenutbla As New DataTable
            _TmpSqlMenutbla = Datamenutable.Clone
            For Each dr1 As DataRow In Datamenutable.Select("SUBID = '0' and MENU <> '-'")
                _TmpSqlMenutbla.ImportRow(dr1)
            Next


            Dim _TmpSqlSubMenutbla As New DataTable
            _TmpSqlSubMenutbla = Datamenutable.Clone
            For Each dr1 As DataRow In Datamenutable.Select("SUBID <> '0' and MENU <> '-'")
                _TmpSqlSubMenutbla.ImportRow(dr1)
            Next

            RS = "delete from MenuTable "
            SQLDBMENU_Save_Delete_Update()



            For Each dr1 As DataRow In DataMenuName.Select()
                'Case 1 : MainId match
                For Each dr As DataRow In _TmpSqlMenutbla.Select("ID='" & dr1("MainId") & "'")
                    Dim _ActiveStatus As String = If(dr1("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
                    Dim command As New OleDb.OleDbCommand(RS, MSA_CONN)
                    If MSA_CONN.State = ConnectionState.Closed Then
                        MSA_CONN.Open()
                    End If
                    command.CommandText =
                "INSERT INTO MenuTable " &
                "(MenuId,Menu,SUBID,ORDERNO,MenuPosition,SELECTFORM," &
                "MenuPositionId,MainMenuPositionId,MenuIsSparate," &
                "MainMenuName,ShortCutKey,IconPath,Tooltip," &
                "MenuType,Active_Status,OP10) " &
                "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                    command.Parameters.AddWithValue("@MenuId", dr1("MainId"))
                    command.Parameters.AddWithValue("@Menu", dr1("MenuName").ToString())
                    command.Parameters.AddWithValue("@SUBID", dr1("MenuPositionId"))
                    command.Parameters.AddWithValue("@ORDERNO", dr1("MenuOrderNo"))
                    command.Parameters.AddWithValue("@MenuPosition", dr1("MenuPosition"))
                    command.Parameters.AddWithValue("@SELECTFORM", dr1("SelectedFormName").ToString())
                    command.Parameters.AddWithValue("@MenuPositionId", dr1("MenuPositionId"))
                    command.Parameters.AddWithValue("@MainMenuPositionId", dr1("MainMenuPositionId"))
                    command.Parameters.AddWithValue("@MenuIsSparate", dr1("MenuIsSparate").ToString())
                    command.Parameters.AddWithValue("@MainMenuName", dr1("MainMenuName").ToString())
                    command.Parameters.AddWithValue("@ShortCutKey", dr1("ShortCutKey").ToString())
                    command.Parameters.AddWithValue("@IconPath", dr1("IconPath").ToString())
                    command.Parameters.AddWithValue("@Tooltip", dr1("Tooltip").ToString())
                    command.Parameters.AddWithValue("@MenuType", dr1("MenuType").ToString())
                    command.Parameters.AddWithValue("@Active_Status", _ActiveStatus)
                    command.Parameters.AddWithValue("@OP10", "New Menu")
                    command.ExecuteNonQuery()
                Next
                For Each dr As DataRow In _TmpSqlMenutbla.Select("id='" & dr1("MainMenuPositionId") & "'")
                    Dim _ActiveStatus As String = If(dr1("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
                    Dim command As New OleDb.OleDbCommand(RS, MSA_CONN)
                    If MSA_CONN.State = ConnectionState.Closed Then
                        MSA_CONN.Open()
                    End If
                    command.CommandText =
                "INSERT INTO MenuTable " &
                "(MenuId,Menu,SUBID,ORDERNO,MenuPosition,SELECTFORM," &
                "MenuPositionId,MainMenuPositionId,MenuIsSparate," &
                "MainMenuName,ShortCutKey,IconPath,Tooltip," &
                "MenuType,Active_Status,OP10) " &
                "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                    command.Parameters.AddWithValue("@MenuId", dr1("MainId"))
                    command.Parameters.AddWithValue("@Menu", dr1("MenuName").ToString())
                    command.Parameters.AddWithValue("@SUBID", dr1("MenuPositionId"))
                    command.Parameters.AddWithValue("@ORDERNO", dr1("MenuOrderNo"))
                    command.Parameters.AddWithValue("@MenuPosition", dr1("MenuPosition"))
                    command.Parameters.AddWithValue("@SELECTFORM", dr1("SelectedFormName").ToString())
                    command.Parameters.AddWithValue("@MenuPositionId", dr1("MenuPositionId"))
                    command.Parameters.AddWithValue("@MainMenuPositionId", dr1("MainMenuPositionId"))
                    command.Parameters.AddWithValue("@MenuIsSparate", dr1("MenuIsSparate").ToString())
                    command.Parameters.AddWithValue("@MainMenuName", dr1("MainMenuName").ToString())
                    command.Parameters.AddWithValue("@ShortCutKey", dr1("ShortCutKey").ToString())
                    command.Parameters.AddWithValue("@IconPath", dr1("IconPath").ToString())
                    command.Parameters.AddWithValue("@Tooltip", dr1("Tooltip").ToString())
                    command.Parameters.AddWithValue("@MenuType", dr1("MenuType").ToString())
                    command.Parameters.AddWithValue("@Active_Status", _ActiveStatus)
                    command.Parameters.AddWithValue("@OP10", "New Menu")
                    command.ExecuteNonQuery()
                Next
            Next
            'user master data
            Dim Fnlmenutbl As DataTable
            Fnlmenutbl = DatauserMenu.Clone
            For Each dr As DataRow In DatauserMenu.Select
                For Each dr1 As DataRow In DataMenuName.Select("MainId='" & dr("MenuId") & "' ")
                    Fnlmenutbl.ImportRow(dr1)
                Next
            Next

            Dim _USerWIseMEnuTbl As New DataTable
            _USerWIseMEnuTbl = DataMenuName.Clone
            Dim startSubMenuId As Integer = 8
            Dim endSubMenuId As Integer = 23
            For Each dr As DataRow In DataMstUser.Select()
                'Step 1 : Header range (8 to 23) ke liye
                For _submenuid As Integer = startSubMenuId To endSubMenuId
                    For Each dr1 As DataRow In DatauserMenu.Select("USERID='" & dr("USER_ID") & "'")
                        If Val(dr1("MENUID")) = _submenuid Then
                            For Each dr2 As DataRow In DataMenuName.Select("MainMenuPositionId='" & _submenuid & "' AND ActiveStatus='YES'")
                                Dim _ActiveStatus As String =
                                    If(dr2("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
                                If MSA_CONN.State = ConnectionState.Closed Then
                                    MSA_CONN.Open()
                                End If
                                Dim command As New OleDb.OleDbCommand(RS, MSA_CONN)
                                command.CommandText =
                                    "INSERT INTO UserMenu " &
                                    "(MenuId, UserId, Active_Status) " &
                                    "VALUES (?,?,?)"
                                command.Parameters.Clear()
                                command.Parameters.AddWithValue("@MenuId", dr2("MainId"))
                                command.Parameters.AddWithValue("@UserId", dr("USER_ID"))
                                command.Parameters.AddWithValue("@Active_Status", _ActiveStatus)
                                command.ExecuteNonQuery()
                                command.Dispose()
                            Next
                        End If
                    Next
                Next
            Next
            MSA_CONN.Close()
            MessageBox.Show("Bulk Save Successfully")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            MSA_CONN.Close()
        End Try
    End Sub
End Class