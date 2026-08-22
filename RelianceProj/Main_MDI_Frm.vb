Imports SalesAnalyticsLib

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

    Private Sub PetRecievedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetRecievedToolStripMenuItem.Click
        PetRecievedtoDepartment.Show()
    End Sub

    Private Sub RawStockEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawStockEntryToolStripMenuItem.Click
        RawStockEntry.Show()
    End Sub

    Private Sub RawRequitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawRequitionToolStripMenuItem.Click
        RawRequisition.Show()
    End Sub

    Private Sub RawIssuetoMachineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawIssuetoMachineToolStripMenuItem.Click
        RawIssueDepartment.Show()
    End Sub

    Private Sub RawApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawApprovalToolStripMenuItem.Click
        RawApproval.Show()
    End Sub

    Private Sub RawIndentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawIndentToolStripMenuItem.Click
        RawIndent.Show()
    End Sub

    Private Sub RawQuotationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawQuotationToolStripMenuItem.Click
        RawQuotationEntry.Show()
    End Sub

    Private Sub RawCompariToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawCompariToolStripMenuItem.Click
        RawComparisonEntry.Show()
    End Sub

    Private Sub RawDepartmentApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawDepartmentApprovalToolStripMenuItem.Click
        RawDepartmentApproval.Show()
    End Sub

    Private Sub RawHeadApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawHeadApprovalToolStripMenuItem.Click
        RawHeadApproval.Show()
    End Sub

    Private Sub RawPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawPOToolStripMenuItem.Click
        RawPurchaseOrder.Show()
    End Sub

    Private Sub RawGateInwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawGateInwardToolStripMenuItem.Click
        RawGateInward.Show()
    End Sub

    Private Sub RawQualityCheckerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawQualityCheckerToolStripMenuItem.Click
        RawQualityChecker.Show()
    End Sub

    Private Sub RawRejectionApprovalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawRejectionApprovalToolStripMenuItem.Click
        RawRejectionApproval.Show()
    End Sub

    Private Sub RawPurchaseReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawPurchaseReturnToolStripMenuItem.Click
        RawPurchaseReturn.Show()
    End Sub

    Private Sub RawInwardAndPOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawInwardAndPOToolStripMenuItem.Click
        RawInwardAndPO.Show()
    End Sub

    Private Sub RawStockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawStockReportToolStripMenuItem.Click
        RawPurchaseReturnReport.Show()
    End Sub

    Private Sub RawToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawToolStripMenuItem.Click
        RawRecievedtoDepartment.Show()
    End Sub

    Private Sub StoreApprovalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StoreApprovalToolStripMenuItem1.Click
        IssuetodepartmentApproval.Show()
    End Sub

    Private Sub VendorMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendorMasterToolStripMenuItem.Click
        VendorMaster.Show()
    End Sub

    Private Sub PetApprovalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PetApprovalToolStripMenuItem1.Click
        PetIssuetodepartmentApproval.Show()
    End Sub

    Private Sub RawApprovalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RawApprovalToolStripMenuItem1.Click
        RawIssuetoDepartmentApproval.Show()
    End Sub

    Private Sub StoreBulkContractToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreBulkContractToolStripMenuItem.Click
        StoreBulkcontract.Show()
    End Sub

    Private Sub StoreWestageEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreWestageEntryToolStripMenuItem.Click
        StoreWestageEntry.Show()
    End Sub

    Private Sub PetBulkContractToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetBulkContractToolStripMenuItem.Click
        PetBulkContract.Show()
    End Sub

    Private Sub PetWestageentryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetWestageentryToolStripMenuItem.Click
        PetWestageEntry.Show()
    End Sub

    Private Sub RawBulkContractToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawBulkContractToolStripMenuItem.Click
        RawBulkContract.Show()
    End Sub

    Private Sub RawWestageEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RawWestageEntryToolStripMenuItem.Click
        RawWestageEntry.Show()
    End Sub

    Private Sub BookMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookMasterToolStripMenuItem.Click
        BookMaster.Show()
    End Sub

    Private Sub MismatchTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MismatchTypeToolStripMenuItem.Click
        MismatchcostingType.Show()
    End Sub

    Private Sub MismatchcostingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MismatchcostingToolStripMenuItem.Click
        MismatchCosting.Show()
    End Sub

    Private Sub ChartformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChartformToolStripMenuItem.Click
        'ChartForm.Show()
        Dim fromdate As String = FINE_YEAR_START.Text
        Dim todate As String = Now.ToString("dd/MM/yyyy")
        Dim myConnStr As String = "Data Source=DESKTOP-TBSN6SV\SQLEXPRESS;database=Accounts39_142026103929;Integrated Security=SSPI;persist security info=True"
        DashboardLauncher.ShowChartDashboard(myConnStr, Me, fromdate, todate)
    End Sub

    'Private Sub ReportselectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportselectionToolStripMenuItem.Click
    '    'ReportsSelectionSettingForm.Show()
    'End Sub

#End Region
End Class
