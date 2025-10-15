Public Class Main_MDI_Frm

    Public LastOpenedMenuPath As String = ""



    Private Sub Main_MDI_Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SELECT_DATABSE()
        TextBox1.Text = "Data Source=DESKTOP-N7G62DM\HP;database=Accounts24_342025104153;Integrated Security=SSPI;persist security info=True"
    End Sub

#Region "Track Last Open Path"
    Public Sub TrackMenuPath(menuItem As ToolStripMenuItem)
        If menuItem Is Nothing Then Return

        Dim path As New List(Of String)
        Dim current As ToolStripItem = menuItem

        While current IsNot Nothing
            path.Insert(0, current.Text)
            If TypeOf current.Owner Is ToolStripDropDownMenu Then
                current = TryCast(current.OwnerItem, ToolStripItem)
            Else
                Exit While
            End If
        End While

        LastOpenedMenuPath = String.Join(">", path)
    End Sub
    Public Sub RestoreMenuFocus(menuPath As String, menuStrip As MenuStrip)
        If String.IsNullOrWhiteSpace(menuPath) Then Exit Sub

        Dim pathParts = menuPath.Split(">"c)
        Dim currentItems As ToolStripItemCollection = menuStrip.Items
        Dim parentDropDown As ToolStripDropDownItem = Nothing
        Dim lastItem As ToolStripItem = Nothing

        For Each part As String In pathParts
            Dim foundItem As ToolStripItem = currentItems.
                OfType(Of ToolStripItem)().
                FirstOrDefault(Function(item) item.Text = part)

            If foundItem IsNot Nothing Then
                lastItem = foundItem
                If TypeOf foundItem Is ToolStripDropDownItem Then
                    parentDropDown = CType(foundItem, ToolStripDropDownItem)
                    parentDropDown.ShowDropDown()
                    currentItems = parentDropDown.DropDownItems
                    parentDropDown.Select()
                Else
                    foundItem.Select()
                End If
            End If
        Next
        LastOpenedMenuPath = ""
    End Sub

    Private Sub Btn_Dashbord_Click(sender As Object, e As EventArgs) Handles Btn_Dashbord.Click
        PlanningGatway.Show()
    End Sub








#End Region
End Class
