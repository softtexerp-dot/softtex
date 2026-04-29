Public Class Main_MDI_Frm

    Public LastOpenedMenuPath As String = ""

    Private Sub Main_MDI_Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SELECT_DATABSE()
        TextBox1.Text = databaseconnecton
        sqL = "select*from Creat_company"
        sql_connect_slect()
        COMPANY_TBL = DefaltSoftTable.Copy
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

    Private Sub DashbordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashbordToolStripMenuItem.Click
        PlanningGatway.Show()
    End Sub

    Private Sub StoreConsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreConsToolStripMenuItem.Click
        StoreConsumption_GridZooming.Show()

    End Sub

    Private Sub LogbookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogbookToolStripMenuItem.Click
        LogBookGridReport.Show()
    End Sub

    Private Sub ReadMadeStockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadMadeStockReportToolStripMenuItem.Click
        ReadyMadeCrystalStockReport.Show()
    End Sub

    Private Sub GetChallanDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetChallanDetailsToolStripMenuItem.Click
        Getonlinechallandetail.Show()
    End Sub

    Private Sub ComplaintdetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComplaintdetailToolStripMenuItem.Click
        ComplaintDetail.Show()
    End Sub

    Private Sub CostdetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CostdetailToolStripMenuItem.Click
        CoastSheet.Show()
    End Sub

    Private Sub CostdetailnewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CostdetailnewToolStripMenuItem.Click
        Coastsheetentry.Show()
    End Sub

    Private Sub SundaryTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SundaryTypeToolStripMenuItem.Click
        CostSundaryType.Show()
    End Sub

    Private Sub BlankRateUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlankRateUpdateToolStripMenuItem.Click
        StockBlankRateupdate.Show()
    End Sub

    Private Sub OfferWiseBeamStockreportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfferWiseBeamStockreportToolStripMenuItem.Click
        OfferwiseBeamstockRpt.Show()
    End Sub

    Private Sub TableformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableformToolStripMenuItem.Click
        MainFrmDesigner.Show()
    End Sub

    'Private Sub TableDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableDetailToolStripMenuItem.Click
    '    MainFormRead.Show()
    'End Sub

    'Private Sub MasterFormDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterFormDetailToolStripMenuItem.Click
    '    MainMasterFormRead.Show()
    'End Sub

    Private Sub QueryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QueryToolStripMenuItem.Click
        QueryLoad.Show()
    End Sub

    Private Sub MenuMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuMasterToolStripMenuItem.Click
        MenuFormAdd.Show()
    End Sub

    Private Sub MenuLoadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuLoadToolStripMenuItem.Click
        'MasterMenuLoad.Show()
        UserMenuForm.Show()
    End Sub

    Private Sub DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DToolStripMenuItem.Click
        HelpForm.Show()
    End Sub

    Private Sub QrcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QrcodeToolStripMenuItem.Click
        GstApiLoginDetail.Show()
    End Sub

    Private Sub ScanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanToolStripMenuItem.Click
        'FrmQrCodescan.Show()
        MenuAllotment.Show()
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        'test.Show()
        SqlDBMenudesign.Show()
    End Sub

    'Private Sub ReportselectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportselectionToolStripMenuItem.Click
    '    'ReportsSelectionSettingForm.Show()
    'End Sub

#End Region
End Class
