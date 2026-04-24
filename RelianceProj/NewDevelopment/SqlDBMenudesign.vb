Imports System.Data.Common
Imports System.Text

Public Class SqlDBMenudesign
    Public Datamenutable As DataTable
    Public DatauserMenu As DataTable
    Public DataMenuName As DataTable
    Public DataMstUser As DataTable
    Public InsertDataMenuNameTable As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MenuTable Data
        RS = "SELECT * FROM MenuTable WHERE 1=1 ORDER BY Id"
        SQLDBMENU_CONNECT()
        If DefaltSoftTable IsNot Nothing Then
            Datamenutable = DefaltSoftTable.Copy
            If DefaltSoftTable.Columns.Contains("MenuId") = False Then
                RS = "ALTER TABLE MenuTable ADD COLUMN MenuId Number"
                SQLDBMENU_Save_Delete_Update()
            End If
        End If
        'UserMenu Data
        RS = " SELECT MenuID,UserID,Active_Status,* FROM UserMenu WHERE 1=1 "
        SQLDBMENU_CONNECT()
        If DefaltSoftTable IsNot Nothing Then
            DatauserMenu = DefaltSoftTable.Copy
        End If


        'MstUser Data
        RS = " SELECT User_Id,ActiveStatus,* FROM MstUser WHERE 1=1 ORDER BY Id"
        SQLDBMENU_CONNECT()
        If DefaltSoftTable IsNot Nothing Then
            DataMstUser = DefaltSoftTable.Copy
        End If

        'Master MenuName Data
        RS = " SELECT * FROM MenuName WHERE 1=1 ORDER BY MainId"
        MenuDesign_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            DataMenuName = DefaltSoftTable.Copy
        End If


        Dim FnlTbl As DataTable
        FnlTbl = DataMenuName.Clone
        'menu master data
        'For Each dr As DataRow In Datamenutable.Select()
        '    For Each dr1 As DataRow In DataMenuName.Select("(MainId='" & dr("ID") & "' OR MenuPositionId='" & dr("ID") & "') AND ActiveStatus='YES'")
        '        Dim exists As Boolean = FnlTbl.Select("ID='" & dr1("ID") & "'").Length > 0
        '        If exists = False Then
        '            FnlTbl.ImportRow(dr1)
        '        End If
        '    Next
        'Next

        For Each dr1 As DataRow In DataMenuName.Select("ActiveStatus='YES'")

            Dim isMatch As Boolean = Datamenutable.Select("ID='" & dr1("MainId") & "' OR SUBID='" & dr1("MenuPositionId") & "'").Length > 0
            If Datamenutable.Rows.Count > 0 AndAlso Datamenutable.Rows(0)("OP10").ToString().Trim() = "New Menu" Then
                Exit Sub
            End If
            Dim exists As Boolean = FnlTbl.Select("ID='" & dr1("ID") & "'").Length > 0
            If isMatch = False AndAlso exists = False Then
                'FnlTbl.ImportRow(dr1)
                Dim _ActiveStatus As String = If(dr1("ActiveStatus").ToString().Trim().ToUpper() = "YES", "Y", "N")
                RS = "Insert into MenuTable(MenuId,Menu,SUBID,ORDERNO,Active_Status,OP10) Values(" & dr1("MainId") & ",'" & dr1("MenuName") & "','" & dr1("MenuPositionId") & "'," & dr1("MenuOrderNo") & ",'" & _ActiveStatus & "','New Menu')"
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
                            RS = "Insert into UserMenu(menuId,userId,Active_Status) Values(" & _submenuid & "," & dr("USER_ID") & ",'" & _ActiveStatus & "')"
                            SQLDBMENU_Save_Delete_Update()
                        Next
                    End If
                Next
            Next
        Next
    End Sub
End Class