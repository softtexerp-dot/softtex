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
        MasterMenuLoad.Show()

    End Sub

    Private Sub DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DToolStripMenuItem.Click
        HelpForm.Show()
    End Sub

    Private Sub QrcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QrcodeToolStripMenuItem.Click
        'GstApiLoginDetail.Show()
        UserMenuForm.Show()
    End Sub

    Private Sub ScanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanToolStripMenuItem.Click
        'QRCode
        'FrmQrCodescan.Show()
        MenuAllotment.Show()
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        'test.Show()
        SqlDBMenudesign.Show()
    End Sub


    Private Sub UserMenuUpdateToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UserMenuUpdateToolStripMenuItem1.Click
        UserMenuupdate.Show()
    End Sub

    Private Sub RequisitionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RequisitionToolStripMenuItem1.Click
        StoresRequisition.Show()
    End Sub

    Private Sub QuotationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuotationToolStripMenuItem1.Click
        QuotationEntry.Show()
    End Sub

    Private Sub ComparisonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComparisonToolStripMenuItem.Click
        ComparisonEntry.Show()
    End Sub

    Private Sub IssueToDepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IssueToDepartmentToolStripMenuItem.Click
        StoreIssueDepartment.Show()
    End Sub

    Private Sub StoreApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreApprovalToolStripMenuItem.Click
        StoreApproval.Show()
    End Sub

    Private Sub IndentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndentToolStripMenuItem.Click
        StoreIndentEntry.Show()
    End Sub

    Private Sub StockEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockEntryToolStripMenuItem.Click
        StockEntry.Show()
    End Sub

    Private Sub MachineMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MachineMasterToolStripMenuItem.Click
        MachineMaster.Show()
    End Sub

    Private Sub DepartMentApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartMentApprovalToolStripMenuItem.Click
        DepartmentApproval.Show()
    End Sub

    Private Sub HeadApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeadApprovalToolStripMenuItem.Click
        HeadApproval.Show()
    End Sub

    Private Sub StoresPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoresPOToolStripMenuItem.Click
        StoresPurchaseOrder.Show()
    End Sub

    Private Sub GateInwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GateInwardToolStripMenuItem.Click
        GateInward.Show()
    End Sub

    Private Sub QualityCheckerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QualityCheckerToolStripMenuItem.Click
        StoresQualityChecker.Show()
    End Sub

    Private Sub ApprovalRejectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApprovalRejectionToolStripMenuItem.Click
        StoreRejectionApproval.Show()
    End Sub

    Private Sub StorePurchaseReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StorePurchaseReturnToolStripMenuItem.Click
        StoresPurchaseReturn.Show()
    End Sub

    Private Sub StoreInwardAndPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreInwardAndPOToolStripMenuItem.Click
        StoreInwardandPO.Show()
    End Sub

    Private Sub StrorePurchaseReturnReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StrorePurchaseReturnReportToolStripMenuItem.Click
        StorePurchaseReturnReport.Show()
    End Sub

    Private Sub EnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnToolStripMenuItem.Click
        AppEntryManagement.Show()
    End Sub

    Private Sub PetStockEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetStockEntryToolStripMenuItem.Click
        PetStockEntry.Show()
    End Sub

    Private Sub PetRequisitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetRequisitionToolStripMenuItem.Click
        PetRequisition.Show()
    End Sub

    Private Sub PetIssueToMachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetIssueToMachineToolStripMenuItem.Click
        PetIssueDepartment.Show()
    End Sub

    Private Sub PetApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetApprovalToolStripMenuItem.Click
        PetApproval.Show()
    End Sub

    Private Sub PetIndentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetIndentToolStripMenuItem.Click
        PetIndent.Show()
    End Sub

    Private Sub PetQuotationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetQuotationToolStripMenuItem.Click
        PetQuotationEntry.Show()
    End Sub

    Private Sub PetComparisonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetComparisonToolStripMenuItem.Click
        PetComparisonEntry.Show()
    End Sub

    Private Sub PetMachineApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetMachineApprovalToolStripMenuItem.Click
        PetDepartmentApproval.Show()
    End Sub

    Private Sub PetHeadApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetHeadApprovalToolStripMenuItem.Click
        PetHeadApproval.Show()
    End Sub

    Private Sub PetGateInwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetGateInwardToolStripMenuItem.Click
        PetGateInward.Show()
    End Sub

    Private Sub PetPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetPOToolStripMenuItem.Click
        PetPurchaseOrder.Show()
    End Sub

    Private Sub PetQualityCheckerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetQualityCheckerToolStripMenuItem.Click
        PetQualityChecker.Show()
    End Sub

    Private Sub PetRejectionApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetRejectionApprovalToolStripMenuItem.Click
        PetRejectionApproval.Show()
    End Sub

    Private Sub PetPurcahseReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetPurcahseReturnToolStripMenuItem.Click
        PetPurchaseReturn.Show()
    End Sub

    Private Sub PetInwardAndPoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetInwardAndPoToolStripMenuItem.Click
        PetInwardAndPO.Show()
    End Sub

    Private Sub StockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockReportToolStripMenuItem.Click
        PetPurchaseReturnReport.Show()
    End Sub


    'Private Sub ReportselectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportselectionToolStripMenuItem.Click
    '    'ReportsSelectionSettingForm.Show()
    'End Sub

#End Region
End Class
