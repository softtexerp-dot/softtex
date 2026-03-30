Public Class HelpForm
    Dim _FormCloseMode As Boolean = False
    Public SelectedMasterName As String
    Private Sub TodayDueBill_Click(sender As Object, e As EventArgs) Handles TodayDueBill.Click
        RTbView.Visible = True
        RTbView.Text = "[VIEWQUERY]-------Section Part

select * from YourMainTable as a
where 1=1
and  a.Bookcode= FilterBookcode --------Filter Replace
and  a.Billdate>=FilterFrom --------Filter Replace
and  a.Billdate<=FilterTO --------Filter Replace

and  a.MasterCode In ('FilterMasterlist1') --------Filter Replace
and  a.MasterCode In ('FilterMasterlist2') --------Filter Replace
and  a.MasterCode In ('FilterMasterlist3') --------Filter Replace
and  a.MasterCode In ('FilterMasterlist4') --------Filter Replace
and  a.MasterCode In ('FilterMasterlist5') --------Filter Replace

[ViewGridColumnTotal]-------Section Part
ENTRYNO,ID

[ViewGridColumnHide]-------Section Part
BOOKVNO,BOOKCODE
"
        RTbView.ReadOnly = True
        RTBPrint.Visible = False
        RTBMasterList.Visible = False
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

and  MasterCode In ('FilterMasterlist1') --------Filter Replace
and  MasterCode In ('FilterMasterlist2') --------Filter Replace
and  MasterCode In ('FilterMasterlist3') --------Filter Replace
and  MasterCode In ('FilterMasterlist4') --------Filter Replace
and  MasterCode In ('FilterMasterlist5') --------Filter Replace

ORDER BY LoomNo"

        RTbView.Visible = False
        RTBTotalColumn.Visible = False
        RTBMasterList.Visible = False
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
,ADJAMT*AMOUNT_ADD=BROKERAGE

[SAVEMEDETORYCOLUMNNAME]-------Section Part
ADJAMT"
        RTbView.Visible = False
        RTBPrint.Visible = False
        RTBMasterList.Visible = False
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
        Me.Location = New Point(0, 0)
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


        HighlightWord(rtb, "FilterMasterlist1", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist2", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist3", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist4", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist5", Color.Purple)

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
        HighlightWord(rtb, "FilterMasterlist1", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist2", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist3", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist4", Color.Purple)
        HighlightWord(rtb, "FilterMasterlist5", Color.Purple)
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
        Dim keywords() As String = {"SELECT", "FROM", "AS", "WHERE", "AND", "OR", "ORDER BY", "IN"}
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

    Private Sub AccordionControlElement2_Click(sender As Object, e As EventArgs) Handles AccordionControlElement2.Click
        RTBMasterList.Visible = True
        Dim res As JoinResult = GetAccountMaster("", "", "GET_LIST")
        Dim txt As String = "[MASTER NAME LIST]------ Selection Part" & vbCrLf & vbCrLf
        Dim i As Integer = 1
        For Each name As String In res.MasterList
            txt &= i.ToString() & ". " & name & vbCrLf
            i += 1
        Next
        RTBMasterList.Text = txt
        RTbView.Visible = False
        RTBPrint.Visible = False
        RTBTotalColumn.Visible = False
        RTBMasterList.ReadOnly = True
        ColorSectionsMasterlist(RTBMasterList)
    End Sub
    Private Sub ColorSectionsMasterlist(rtb As RichTextBox)
        ' 👉 Reset formatting
        rtb.SelectAll()
        rtb.SelectionColor = Color.DarkMagenta
        'rtb.SelectionFont = New Font(rtb.Font, FontStyle.Regular)
        ' 👉 Header highlight
        HighlightHeader(rtb, "[MASTER NAME LIST]------ Selection Part", Color.DarkBlue)
    End Sub
End Class