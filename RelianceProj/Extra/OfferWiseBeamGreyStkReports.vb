Imports System.Text
Imports DevExpress.XtraGrid

Friend Class OfferWiseBeamGreyStkReports


    Private obj_Party_Selection As New Multi_Selection_Master
    Private WithEvents txtAccountCode As New TextBox


    Private Sub OfferWiseBeamGreyStkReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        PnlView.Width = 974
        PnlView.Height = 595
        PnlView.Location = New Point(1, 1)


    End Sub

    Private Sub _OfferWiseGreyStkReport()

        Try
            Generate_Date_For_DataBase(txt_From)
            Generate_Date_For_DataBase(txt_To)



            obj_Party_Selection.MULTY_PARTY_SELECTION()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                txtAccountCode.Text = MULTY_SELECTION_COLOUM_3_DATA
            Else
                Exit Sub
            End If



            _strQuery = New StringBuilder
            With _strQuery

                .Append(" SELECT ")
                .Append(" Z.OfferNo ")
                .Append(" ,format(C.OfferDate,'dd/MM/yyyy') as [Date] ")
                .Append(" ,C.ENTRYNO as EntryNo ")
                .Append(" ,A.ACCOUNTNAME as [PartyName] ")
                .Append(" ,c.Pick ")
                .Append(" ,c.NO_OF_SET as [NoOfSet] ")
                .Append(" ,c.PICK_RATE as [Rate] ")
                .Append(" ,SUM (Z.OfferBeam) AS [OfferBeam] ")
                .Append(" ,SUM(Z.ReadyBeam) AS [ReadyBeam] ")
                .Append(" ,SUM(Z.OfferBeam)-SUM(Z.ReadyBeam) AS [BalanceBeam] ")
                .Append(" ,SUM(Z.OfferQty) AS [OfferQty] ")
                .Append(" ,SUM(Z.BeamLength) AS [BeamLength] ")
                .Append(" ,SUM(Z.OfferQty)-SUM(Z.BeamLength) AS [BalanceMtr] ")
                .Append(" ,SUM(Z.FOLDMTR) AS [ProdMtr] ")
                .Append(" ,SUM(Z.DISPMTR) AS [DisMtr] ")
                .Append(" ,SUM(Z.FOLDMTR)-SUM(Z.DISPMTR) AS [GreyStk] ")
                .Append(" ,SUM(Z.BeamLength)-(SUM(Z.FOLDMTR)) AS [PendProd] ")
                .Append(" FROM( ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.ITEMCODE ")
                .Append(" ,A.OfferNo ")
                .Append(" ,A.NO_OF_BEAM AS OfferBeam ")
                .Append(" ,0.00AS  ReadyBeam ")
                .Append(" ,(A.Mtr_Weight) AS OfferQty ")
                .Append(" ,0.00 AS BeamLength ")
                .Append(" ,0.00  AS FOLDMTR ")
                .Append(" ,0.00  AS DISPMTR ")
                .Append(" FROM ")
                .Append(" TrnOffer AS A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BookCode ='0001-000000124' ")
                .Append(" AND A.ACCOUNTCODE IN " & txtAccountCode.Text & " ")
                .Append(" AND A.OfferDate>='" & txt_From.Date_for_Database & "' AND A.OfferDate<='" & txt_To.Date_for_Database & "' ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.OfferNo ")
                .Append(" ,0.00 OfferBeam ")
                .Append(" ,COUNT(A.BEAMNO) AS  ReadyBeam ")
                .Append(" ,0.00 AS OfferQty ")
                .Append(" ,SUM(A.Beam_Length) AS BeamLength ")
                .Append(" ,0.00  AS FOLDMTR ")
                .Append(" ,0.00  AS DISPMTR ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.OfferNo>'' ")
                .Append(" AND A.OfferNo>'0' ")
                .Append(" AND A.ACCOUNTCODE IN " & txtAccountCode.Text & " ")
                .Append(" GROUP BY ")
                .Append(" A.OfferNo ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.OfferNo ")
                .Append(" ,0.00 AS OfferBeam ")
                .Append(" ,0.00 AS  ReadyBeam ")
                .Append(" ,0.00 AS OfferQty ")
                .Append(" ,0.00 AS BeamLength ")
                .Append(" ,SUM(B.GMTR) AS FOLDMTR ")
                .Append(" ,0.00 AS DISPMTR ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" LEFT JOIN TrnGreyRcpt AS B  ON A.BeamNo =B.BeamNo ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.OfferNo>'' ")
                .Append(" AND A.OfferNo>'0' ")
                .Append(" AND A.ACCOUNTCODE IN " & txtAccountCode.Text & " ")
                .Append(" GROUP BY ")
                .Append(" A.OfferNo ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.OfferNo ")
                .Append(" ,0.00 AS OfferBeam ")
                .Append(" ,0.00 AS  ReadyBeam ")
                .Append(" ,0.00 AS OfferQty ")
                .Append(" ,0.00 AS BeamLength ")
                .Append(" ,0.00 AS FOLDMTR ")
                .Append(" ,SUM(C.GMTR) AS DISPMTR ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" , TrnGreyDesp AS C ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BeamNo =C.BeamNo ")
                .Append(" AND A.OfferNo>'' ")
                .Append(" AND A.OfferNo>'0' ")
                .Append(" AND A.ACCOUNTCODE IN " & txtAccountCode.Text & " ")
                .Append(" GROUP BY ")
                .Append(" A.OfferNo ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstMasterAccount AS A ON A.ACCOUNTCODE =Z.ACCOUNTCODE ")
                .Append(" LEFT JOIN TrnOffer AS C ON Z.OfferNo =C.OfferNo ")
                .Append(" GROUP BY ")
                .Append(" Z.OfferNo ")
                .Append(" ,A.ACCOUNTNAME ")
                .Append(" ,C.OfferDate ")
                .Append(" ,C.ENTRYNO ")
                .Append(" ,c.NO_OF_SET ")
                .Append(" ,c.PICK_RATE ")
                .Append(" ,c.Pick ")
                .Append(" HAVING SUM(Z.OfferQty)-SUM(Z.BeamLength)>0 ")


            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim tblTmp As New DataTable
            tblTmp = DefaltSoftTable.Copy






            tblTmp = DefaltSoftTable.Copy
            FirstStage.Columns.Clear()
            Dim Qty As String = ""
            If tblTmp.Rows.Count > 0 Then
                For Each dr As DataRow In tblTmp.Select
                    Qty = Format(dr("NoOfSet"), "0.00")
                    dr("NoOfSet") = Qty
                    Qty = Format(dr("OfferBeam"), "0.00")
                    dr("OfferBeam") = Qty
                    Qty = Format(dr("ReadyBeam"), "0.00")
                    dr("ReadyBeam") = Qty
                    Qty = Format(dr("BalanceBeam"), "0.00")
                    dr("BalanceBeam") = Qty
                    Qty = Format(dr("OfferQty"), "0.00")
                    dr("OfferQty") = Qty
                    Qty = Format(dr("BeamLength"), "0.00")
                    dr("BeamLength") = Qty
                    Qty = Format(dr("BalanceMtr"), "0.00")
                    dr("BalanceMtr") = Qty
                    Qty = Format(dr("DisMtr"), "0.00")
                    dr("DisMtr") = Qty
                    Qty = Format(dr("GreyStk"), "0.00")
                    dr("GreyStk") = Qty
                    Qty = Format(dr("PendProd"), "0.00")
                    dr("PendProd") = Qty
                    Qty = Format(dr("ProdMtr"), "0.00")
                    dr("ProdMtr") = Qty

                    If Val(dr("NoOfSet")) = 0 Then dr("NoOfSet") = DBNull.Value
                    If Val(dr("OfferBeam")) = 0 Then dr("OfferBeam") = DBNull.Value
                    If Val(dr("ReadyBeam")) = 0 Then dr("ReadyBeam") = DBNull.Value
                    If Val(dr("BalanceBeam")) = 0 Then dr("BalanceBeam") = DBNull.Value
                    If Val(dr("OfferQty")) = 0 Then dr("OfferQty") = DBNull.Value
                    If Val(dr("BeamLength")) = 0 Then dr("BeamLength") = DBNull.Value
                    If Val(dr("BalanceMtr")) = 0 Then dr("BalanceMtr") = DBNull.Value
                    If Val(dr("DisMtr")) = 0 Then dr("DisMtr") = DBNull.Value
                    If Val(dr("GreyStk")) = 0 Then dr("GreyStk") = DBNull.Value
                    If Val(dr("PendProd")) = 0 Then dr("PendProd") = DBNull.Value
                    If Val(dr("ProdMtr")) = 0 Then dr("ProdMtr") = DBNull.Value
                Next

                GridControl1.DataSource = tblTmp

                FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
                FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)


                FirstStage.GroupRowHeight = 30

                FirstStage.Columns("NoOfSet").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NoOfSet", "{0}"))
                FirstStage.Columns("OfferBeam").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OfferBeam", "{0}"))
                FirstStage.Columns("ReadyBeam").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ReadyBeam", "{0}"))
                FirstStage.Columns("BalanceBeam").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceBeam", "{0}"))
                FirstStage.Columns("OfferQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OfferQty", "{0}"))
                FirstStage.Columns("BeamLength").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BeamLength", "{0}"))
                FirstStage.Columns("BalanceMtr").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceMtr", "{0}"))
                FirstStage.Columns("ProdMtr").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ProdMtr", "{0}"))
                FirstStage.Columns("DisMtr").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DisMtr", "{0}"))
                FirstStage.Columns("GreyStk").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GreyStk", "{0}"))
                FirstStage.Columns("PendProd").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PendProd", "{0}"))


                AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
                'FirstStage.Columns(0).Visible = False

                PnlView.Visible = True
                FirstStage.BestFitColumns()
                FirstStage.Focus()
                PnlView.BringToFront()
                GridControl1.BringToFront()
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'rptDS = New Report_set
        'rptDS.Tables("rptTable").Clear()
        'For Each dr As DataRow In tblTmp.Select()
        '    rptDS.Tables("rptTable").ImportRow(dr)
        'Next
        'Dim RptTitle = "Pending Order Beam Wise Stock Report"
        'Dim Date_Range = ""
        'REPORT_RPT_FILE_NAME = "OfferWiseBeamStkReport_1"
        'obj_Party_Selection.DirectReportUsePrint(RptTitle, Date_Range)

    End Sub
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        'gridView.Columns(CStr(("Bale No"))).Group()

        'Enable this option to move group footer summaries to group rows under corresponding column headers
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "NoOfSet", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("NoOfSet")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "OfferBeam", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("OfferBeam")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "ReadyBeam", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("ReadyBeam")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "BalanceBeam", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("BalanceBeam")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "OfferQty", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("OfferQty")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "BeamLength", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("BeamLength")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "BalanceMtr", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("BalanceMtr")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "ProdMtr", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("ProdMtr")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "DisMtr", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("DisMtr")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "GreyStk", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("GreyStk")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "PendProd", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("PendProd")})

        gridView.Appearance.GroupRow.BackColor = Color.LightGreen

    End Sub
    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = " Folding Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#Region "BUTTON CLICK EVENT"
    Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnView.BackColor = Color.Coral
    End Sub
    Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnView.BackColor = Me.BackColor
    End Sub

    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClose.BackColor = Color.Coral
    End Sub
    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClose.BackColor = Me.BackColor
    End Sub

    Private Sub OfferWiseBeamGreyStkReports_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then

            If PnlView.Visible = True Then
                PnlView.Visible = False
                txt_From.Focus()
                Exit Sub
            End If
            Me.Close()
            Me.Dispose(True)

        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        _OfferWiseGreyStkReport()
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region
End Class