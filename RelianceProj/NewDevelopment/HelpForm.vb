Public Class HelpForm
    Dim _FormCloseMode As Boolean = False
    Private Sub TodayDueBill_Click(sender As Object, e As EventArgs) Handles TodayDueBill.Click
        RTbView.Visible = True
        RTbView.Text = "[VIEWQUERY]-------Section Part

select * from YourMainTable as a
where 1=1
and  a.Bookcode= FilterBookcode --------Filter Replace
and  a.Billdate>=FilterFrom --------Filter Replace
and  a.Billdate<=FilterTO --------Filter Replace

[ViewGridColumnTotal]-------Section Part
ENTRYNO,ID

[ViewGridColumnHide]-------Section Part
BOOKVNO,BOOKCODE
"
        RTbView.ReadOnly = True
        RTBPrint.Visible = False
        RTBTotalColumn.Visible = False
        ColorSections(RTbView)
    End Sub

    Private Sub UnFoloOutstanding_Click(sender As Object, e As EventArgs) Handles UnFoloOutstanding.Click
        RTBPrint.Visible = True
        RTBPrint.Text = "[PRINTQUERY]-------Section Part

SELECT * FROM YourMainTable 
where 1=1
and  Bookcode= FilterBookcode --------Filter Replace
and  Billdate>=FilterFrom --------Filter Replace
and  Billdate<=FilterTO --------Filter Replace

ORDER BY LoomNo"

        RTbView.Visible = False
        RTBTotalColumn.Visible = False
        RTBPrint.ReadOnly = True
        ColorSectionsPrint(RTBPrint)
    End Sub

    Private Sub DiscountFoloOutstanding_Click(sender As Object, e As EventArgs) Handles DiscountFoloOutstanding.Click
        RTBTotalColumn.Visible = True
        RTBTotalColumn.Text = "[GRIDCOLUMSUM]-------Section Part
ADJAMT
,AMOUNT_ADD
,AMOUNT_LESS

[GRIDCOLUMMULTIPLY]-------Section Part
ADJAMT*AMOUNT_ADD=AMOUNT_LESS

[SAVEMEDETORYCOLUMNNAME]-------Section Part
ADJAMT"
        RTbView.Visible = False
        RTBPrint.Visible = False
        RTBTotalColumn.ReadOnly = True
        ColorSectionsTotal(RTBTotalColumn)
    End Sub

    Private Sub HelpForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If _FormCloseMode = True Then
                Me.Close()
                Dispose(True)
            End If
        End If
    End Sub

    Private Sub HelpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ColorSections(rtb As RichTextBox)
        Dim txt As String = rtb.Text
        ' 👉 Default sab black
        rtb.SelectAll()
        rtb.SelectionColor = Color.Black
        'rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
        ' 👉 Section Headers
        HighlightHeader(rtb, "[VIEWQUERY]", Color.DarkBlue)
        HighlightHeader(rtb, "[ViewGridColumnTotal]", Color.DarkBlue)
        HighlightHeader(rtb, "[ViewGridColumnHide]", Color.DarkBlue)
        ' 👉 Section Content
        HighlightSectionContent(rtb, "[VIEWQUERY]", Color.Black)
        HighlightSectionContent(rtb, "[ViewGridColumnTotal]", Color.DarkGreen)
        HighlightSectionContent(rtb, "[ViewGridColumnHide]", Color.DarkGreen)
        ' 👉 SQL Keywords (sirf VIEWQUERY me)
        HighlightSQLKeywords(rtb)
        ' 👉 Filters highlight
        HighlightWord(rtb, "FilterBookcode", Color.Purple)
        HighlightWord(rtb, "FilterFrom", Color.Purple)
        HighlightWord(rtb, "FilterTO", Color.Purple)
    End Sub

    Private Sub ColorSectionsPrint(rtb As RichTextBox)
        Dim txt As String = rtb.Text
        ' 👉 Default sab black
        rtb.SelectAll()
        rtb.SelectionColor = Color.Black
        'rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
        ' 👉 Section Headers
        HighlightHeader(rtb, "[PRINTQUERY]", Color.DarkBlue)
        ' 👉 Section Content
        HighlightSectionContent(rtb, "[PRINTQUERY]", Color.Black)
        ' 👉 SQL Keywords (sirf VIEWQUERY me)
        HighlightSQLKeywords(rtb)
        ' 👉 Filters highlight
        HighlightWord(rtb, "FilterBookcode", Color.Purple)
        HighlightWord(rtb, "FilterFrom", Color.Purple)
        HighlightWord(rtb, "FilterTO", Color.Purple)
    End Sub
    Private Sub ColorSectionsTotal(rtb As RichTextBox)
        Dim txt As String = rtb.Text
        ' 👉 Default sab black
        rtb.SelectAll()
        rtb.SelectionColor = Color.Black
        'rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
        ' 👉 Section Headers
        HighlightHeader(rtb, "[GRIDCOLUMSUM]", Color.DarkBlue)
        HighlightHeader(rtb, "[GRIDCOLUMMULTIPLY]", Color.DarkBlue)
        HighlightHeader(rtb, "[SAVEMEDETORYCOLUMNNAME]", Color.DarkBlue)
        ' 👉 Section Content
        HighlightSectionContent(rtb, "[GRIDCOLUMSUM]", Color.DarkCyan)
        HighlightSectionContent(rtb, "[GRIDCOLUMMULTIPLY]", Color.DarkMagenta)
        HighlightSectionContent(rtb, "[SAVEMEDETORYCOLUMNNAME]", Color.Brown)
    End Sub
    Private Sub HighlightHeader(rtb As RichTextBox, textToFind As String, clr As Color)
        Dim index As Integer = rtb.Text.IndexOf(textToFind)
        If index >= 0 Then
            rtb.Select(index, textToFind.Length)
            rtb.SelectionColor = clr
            rtb.SelectionFont = New Font(rtb.Font, FontStyle.Bold)
        End If
    End Sub
    Private Sub HighlightSectionContent(rtb As RichTextBox, sectionName As String, clr As Color)
        Dim startIndex As Integer = rtb.Text.IndexOf(sectionName)
        If startIndex < 0 Then Exit Sub
        Dim nextIndex As Integer = rtb.Text.IndexOf("[", startIndex + 1)
        If nextIndex = -1 Then nextIndex = rtb.TextLength
        Dim contentStart As Integer = startIndex + sectionName.Length
        Dim length As Integer = nextIndex - contentStart
        rtb.Select(contentStart, length)
        rtb.SelectionColor = clr
    End Sub
    Private Sub HighlightSQLKeywords(rtb As RichTextBox)
        Dim keywords() As String = {"SELECT", "FROM", "AS", "WHERE", "AND", "OR", "ORDER BY"}
        For Each word In keywords
            HighlightWord(rtb, word, Color.Blue)
        Next
    End Sub
    Private Sub HighlightWord(rtb As RichTextBox, word As String, clr As Color)
        Dim startIndex As Integer = 0
        While startIndex < rtb.TextLength
            Dim index As Integer = rtb.Text.IndexOf(word, startIndex, StringComparison.OrdinalIgnoreCase)
            If index = -1 Then Exit While
            rtb.Select(index, word.Length)
            rtb.SelectionColor = clr
            startIndex = index + word.Length
        End While
    End Sub
End Class