Public Class HelpForm
    Dim _FormCloseMode As Boolean = False
    Private Sub TodayDueBill_Click(sender As Object, e As EventArgs) Handles TodayDueBill.Click
        RTbView.Visible = True
        RTbView.Text = "[VIEWQUERY]

select * from YourMainTable as a
where 1=1
and  a.bookcode= FilterBookcode 
and  Billdate>=FilterFrom
and  Billdate<=FilterTO

[ViewGridColumnTotal]
ENTRYNO,ID

[ViewGridColumnHide]
BOOKVNO,BOOKCODE
"
        RTBPrint.Visible = False
        RTBTotalColumn.Visible = False
    End Sub

    Private Sub UnFoloOutstanding_Click(sender As Object, e As EventArgs) Handles UnFoloOutstanding.Click
        RTBPrint.Visible = True
        RTBPrint.Text = "[PRINTQUERY]

SELECT * FROM YourMainTable ORDER BY LoomNo"
        RTbView.Visible = False
        RTBTotalColumn.Visible = False
    End Sub

    Private Sub DiscountFoloOutstanding_Click(sender As Object, e As EventArgs) Handles DiscountFoloOutstanding.Click
        RTBTotalColumn.Visible = True
        RTBTotalColumn.Text = "[GRIDCOLUMSUM]
ADJAMT
,AMOUNT_ADD
,AMOUNT_LESS

[GRIDCOLUMMULTIPLY]
ADJAMT*AMOUNT_ADD=AMOUNT_LESS

[SAVEMEDETORYCOLUMNNAME]
ADJAMT"
        RTbView.Visible = False
        RTBPrint.Visible = False
    End Sub

    Private Sub HelpForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If _FormCloseMode = True Then
                Me.Close()
                Dispose(True)
            End If
        End If
    End Sub
End Class