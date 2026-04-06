Imports System.Text

Module QueryRead
    Dim _TblName As String = "FormQueryMaster"
    Function GetQuery(ByVal dt As DataTable, ByVal sectionType As String, ByVal subsectionName As String) As String
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return ""
        Dim text As String = dt.Rows(0)("QueryText").ToString()
        Dim startTag As String = "[" & sectionType & "]"
        If subsectionName <> "" Then
            'startTag = "[" & sectionType & "_" & subsectionName & "]"
        End If
        Dim startPos As Integer = text.IndexOf(startTag)
        If startPos = -1 Then Return ""
        startPos += startTag.Length
        Dim endPos As Integer = text.IndexOf("[", startPos)
        If endPos = -1 Then
            endPos = text.Length
        End If
        Return text.Substring(startPos, endPos - startPos).Trim()
    End Function
    Public Function _GetFormQuery(ByVal _FormName As String, ByVal _Type As String)
        Dim _tmptbl As New DataTable
        _strQuery = New StringBuilder
        With _strQuery
            .Append("Select * FROM " & _TblName & " WHERE FormName='" & _FormName & "' and Type='" & _Type & "'")
        End With
        RS = _strQuery.ToString
        MenuDesign_QueryLoad()
        _tmptbl = DefaltSoftTable.Copy
        Return _tmptbl
    End Function
    Public Function _GetFormQueryReport(ByVal _FormName As String, ByVal _Type As String, ByVal _MainmasterId As String)
        Dim _tmptbl As New DataTable
        _strQuery = New StringBuilder
        With _strQuery
            .Append("Select * FROM " & _TblName & " WHERE FormName='" & _FormName & "' and Type='" & _Type & "' and MainMasterId=" & _MainmasterId & "")
        End With
        RS = _strQuery.ToString
        MenuDesign_QueryLoad()
        _tmptbl = DefaltSoftTable.Copy
        Return _tmptbl
    End Function
End Module
