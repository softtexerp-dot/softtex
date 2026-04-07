Imports System.IO
Public Class TxtFileConfigManager

    Private ReadOnly _filePath As String

    Public Sub New(filePath As String)
        _filePath = filePath
        If Not File.Exists(_filePath) Then
            File.WriteAllText(_filePath, "")
        End If
    End Sub

    ' =========================
    ' Read Setting
    ' =========================
    Public Function ReadSetting(section As String, key As String) As String
        Dim lines = File.ReadAllLines(_filePath)
        Dim inSection As Boolean = False

        For Each line As String In lines
            Dim trimmedLine = line.Trim()

            ' सेक्शन पहचानो
            If trimmedLine.StartsWith("[") AndAlso trimmedLine.EndsWith("]") Then
                inSection = trimmedLine.Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase)

                ' सेक्शन के अंदर key=value ढूंढो
            ElseIf inSection AndAlso trimmedLine.Contains("=") Then
                Dim equalIndex As Integer = trimmedLine.IndexOf("="c)
                If equalIndex > 0 Then
                    Dim currentKey As String = trimmedLine.Substring(0, equalIndex).Trim()
                    Dim currentValue As String = trimmedLine.Substring(equalIndex + 1).Trim()

                    If currentKey.Equals(key, StringComparison.OrdinalIgnoreCase) Then
                        Return currentValue
                    End If
                End If
            End If
        Next


        Return Nothing
    End Function

    ' =========================
    ' Update/Add Setting
    ' =========================
    Public Sub UpdateSetting(section As String, key As String, newValue As String)
        Dim lines As List(Of String) = File.ReadAllLines(_filePath).ToList()
        Dim inSection As Boolean = False
        Dim updated As Boolean = False

        For i As Integer = 0 To lines.Count - 1
            Dim line = lines(i).Trim()

            ' Section check
            If line.StartsWith("[") AndAlso line.EndsWith("]") Then
                inSection = line.Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase)

                ' Key = Value line inside the section
            ElseIf inSection AndAlso line.Contains("=") Then
                Dim parts = line.Split("="c)
                Dim currentKey As String = parts(0).Trim()

                If currentKey.Equals(key, StringComparison.OrdinalIgnoreCase) Then
                    ' Handle values with multiple '='
                    Dim currentValue As String = String.Join("=", parts.Skip(1)).Trim()

                    ' Update line
                    lines(i) = currentKey & "=" & newValue
                    updated = True
                    Exit For
                End If
            End If
        Next

        If Not updated Then
            Dim sectionIndex = lines.FindIndex(Function(l) l.Trim().Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase))
            If sectionIndex >= 0 Then
                lines.Insert(sectionIndex + 1, key & "=" & newValue)
            Else
                lines.Add("[" & section & "]")
                lines.Add(key & "=" & newValue)
            End If
        End If

        File.WriteAllLines(_filePath, lines)
    End Sub

    ' =========================
    ' Delete Key
    ' =========================
    Public Sub DeleteSetting(section As String, key As String)
        Dim lines As List(Of String) = File.ReadAllLines(_filePath).ToList()
        Dim inSection As Boolean = False

        For i As Integer = 0 To lines.Count - 1
            Dim line = lines(i).Trim()

            ' Check if we're in the target section
            If line.StartsWith("[") AndAlso line.EndsWith("]") Then
                inSection = line.Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase)

            ElseIf inSection AndAlso line.Contains("=") Then
                ' Use IndexOf instead of Split
                Dim equalIndex As Integer = line.IndexOf("="c)
                If equalIndex > 0 Then
                    Dim currentKey As String = line.Substring(0, equalIndex).Trim()

                    If currentKey.Equals(key, StringComparison.OrdinalIgnoreCase) Then
                        lines.RemoveAt(i)
                        Exit For
                    End If
                End If
            End If
        Next


        File.WriteAllLines(_filePath, lines)
    End Sub

    ' =========================
    ' Delete Entire Section
    ' =========================
    Public Sub DeleteSection(section As String)
        Dim lines As List(Of String) = File.ReadAllLines(_filePath).ToList()
        Dim inSection As Boolean = False
        Dim startIdx As Integer = -1
        Dim endIdx As Integer = -1

        For i As Integer = 0 To lines.Count - 1
            Dim line = lines(i).Trim()

            If line.StartsWith("[") AndAlso line.EndsWith("]") Then
                If inSection Then
                    endIdx = i
                    Exit For
                End If

                If line.Equals("[" & section & "]", StringComparison.OrdinalIgnoreCase) Then
                    inSection = True
                    startIdx = i
                End If
            End If
        Next

        If inSection Then
            If endIdx = -1 Then endIdx = lines.Count
            lines.RemoveRange(startIdx, endIdx - startIdx)
            File.WriteAllLines(_filePath, lines)
        End If
    End Sub

End Class
