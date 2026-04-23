Imports System.Data.Common
Imports System.Text

Public Class SqlDBMenudesign
    Public Datamenutable As DataTable
    Public DatauserMenu As DataTable
    Public DataMenuName As DataTable
    Public DataMstUser As DataTable
    Public InsertDataMenuNameTable As DataTable
    'Dim SaveQuery As String = ""
    'Private tblFormValues As New DataTable
    'Private _FORMMODE As String = ""
    'Private FieldNameAndValues(1) As String
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
        For Each dr As DataRow In Datamenutable.Select()
            For Each dr1 As DataRow In DataMenuName.Select("(MainId='" & dr("ID") & "' OR MenuPositionId='" & dr("ID") & "') AND ActiveStatus='YES'")
                Dim exists As Boolean = FnlTbl.Select("ID='" & dr1("ID") & "'").Length > 0
                If exists = False Then
                    FnlTbl.ImportRow(dr1)
                End If
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
        '_FORMMODE = "ADD"
        'ObjCls_General._InsertFormValueIntoDataTable(Me, tblFormValues)
        'ObjCls_General.MAKEQUERYFROMDATATABLE(_FORMMODE, tblFormValues, FieldNameAndValues)
        'SaveQuery = getSaveQuery()
        'RS = SaveQuery.ToString
        'MenuDesign_QuerySaveUpdateDelete()
    End Sub
    'Private Function getSaveQuery()
    '    _strQuery = New StringBuilder
    '    If _FORMMODE = "ADD" Then
    '        _strQuery.Append(" INSERT INTO " & _TblName & "(" & FieldNameAndValues(0) & ")  VALUES  (" & FieldNameAndValues(1) & ")")
    '    ElseIf _FORMMODE = "EDIT" Then
    '        _strQuery.Append(" UPDATE " & _TblName & " SET " & FieldNameAndValues(1) & " WHERE " & _KeyFieldName & "=" & "" & _KeyFieldValue & "")
    '    End If
    '    getSaveQuery = _strQuery.ToString
    'End Function
End Class