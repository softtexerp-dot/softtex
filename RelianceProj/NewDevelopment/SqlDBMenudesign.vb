Imports System.Data.Common
Imports System.Text
Imports DevExpress.XtraReports.Design
Imports Newtonsoft.Json.Linq

Public Class SqlDBMenudesign
    Public Datamenutable As DataTable
    Public DatauserMenu As DataTable
    Public DataMenuName As DataTable
    Public DataMstUser As DataTable
    Public InsertDataMenuNameTable As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


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
            Dim columnQueries As New List(Of String)

            If Not DefaltSoftTable.Columns.Contains("MenuId") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MenuID Number")
            End If

            If Not DefaltSoftTable.Columns.Contains("MenuPosition") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MenuPosition Number")
            End If

            If Not DefaltSoftTable.Columns.Contains("MenuPositionId") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MenuPositionId Number")
            End If

            If Not DefaltSoftTable.Columns.Contains("MainMenuPositionId") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MainMenuPositionId Number")
            End If

            If Not DefaltSoftTable.Columns.Contains("MenuIsSparate") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MenuIsSparate TEXT(20)")
            End If

            If Not DefaltSoftTable.Columns.Contains("MainMenuName") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MainMenuName TEXT(255)")
            End If

            If Not DefaltSoftTable.Columns.Contains("ShortCutKey") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN ShortCutKey TEXT(50)")
            End If

            If Not DefaltSoftTable.Columns.Contains("IconPath") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN IconPath TEXT(50)")
            End If

            If Not DefaltSoftTable.Columns.Contains("Tooltip") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN Tooltip TEXT(50)")
            End If

            If Not DefaltSoftTable.Columns.Contains("MenuType") Then
                columnQueries.Add("ALTER TABLE MenuTable ADD COLUMN MenuType TEXT(255)")
            End If

            For Each query As String In columnQueries
                RS = query
                SQLDBMENU_Save_Delete_Update()
            Next
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
        For Each dr1 As DataRow In DataMenuName.Select()
            Dim isMatch As Boolean = Datamenutable.Select("ID='" & dr1("MainId") & "' OR SUBID='" & dr1("MenuPositionId") & "'").Length > 0
            Dim exists As Boolean = FnlTbl.Select("ID='" & dr1("ID") & "'").Length > 0
            If isMatch = False AndAlso exists = False Then
                'FnlTbl.ImportRow(dr1)
                Dim _ActiveStatus As String = If(dr1("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
                RS = "Insert into MenuTable(MenuId,Menu,SUBID,ORDERNO,MenuPosition,SELECTFORM,MenuPositionId,MainMenuPositionId,MenuIsSparate,MainMenuName,ShortCutKey,IconPath,Tooltip,MenuType,Active_Status,OP10) Values(" & dr1("MainId") & ",'" & dr1("MenuName") & "','" & dr1("MenuPositionId") & "'," & dr1("MenuOrderNo") & "," & dr1("MenuPosition") & ",'" & dr1("SelectedFormName") & "'," & dr1("MenuPositionId") & "," & dr1("MainMenuPositionId") & ",'" & dr1("MenuIsSparate") & "','" & dr1("MainMenuName") & "','" & dr1("ShortCutKey") & "','" & dr1("IconPath") & "','" & dr1("Tooltip") & "','" & dr1("MenuType") & "','" & _ActiveStatus & "','New Menu')"
                SQLDBMENU_Save_Delete_Update()
            ElseIf isMatch = True Then
                RS = "UPDATE MenuTable SET MenuID =" & dr1("MainId") & ", SELECTFORM='" & dr1("SelectedFormName") & "',MenuPosition=" & dr1("MenuOrderNo") & ",MenuPositionId=" & dr1("MenuPositionId") & ",MainMenuPositionId=" & dr1("MainMenuPositionId") & ",MenuIsSparate='" & dr1("MenuIsSparate") & "',MainMenuName='" & dr1("MainMenuName") & "',ShortCutKey='" & dr1("ShortCutKey") & "',IconPath='" & dr1("IconPath") & "',Tooltip='" & dr1("Tooltip") & "',MenuType='" & dr1("MenuType") & "' where ID=" & dr1("MainId") & ""
                SQLDBMENU_Save_Delete_Update()
            End If
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
            'Har USER_ID ke liye _submenuid ko 8 se start karo
            For _submenuid As Integer = startSubMenuId To endSubMenuId
                For Each dr1 As DataRow In DatauserMenu.Select("USERID='" & dr("USER_ID") & "'")
                    If dr1("MENUID") = _submenuid Then
                        For Each dr2 As DataRow In DataMenuName.Select("MenuPositionId='" & _submenuid & "' and ActiveStatus='YES'")
                            '_USerWIseMEnuTbl.ImportRow(dr2)
                            Dim _ActiveStatus As String = If(dr2("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
                            RS = "Insert into UserMenu(menuId,userId,Active_Status) Values(" & dr2("MainId") & "," & dr("USER_ID") & ",'" & _ActiveStatus & "')"
                            SQLDBMENU_Save_Delete_Update()
                        Next
                    End If
                Next
            Next
        Next
    End Sub
End Class