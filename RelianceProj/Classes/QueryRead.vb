Module QueryRead

    Function GetQuery(ByVal fullText As String, ByVal sectionName As String) As String
        Dim startTag As String = "[" & sectionName & "]"
        Dim startPos As Integer = fullText.IndexOf(startTag)
        If startPos = -1 Then Return ""
        startPos += startTag.Length
        Dim endPos As Integer = fullText.IndexOf("[", startPos)
        If endPos = -1 Then
            endPos = fullText.Length
        End If
        Return fullText.Substring(startPos, endPos - startPos).Trim()
    End Function
End Module
