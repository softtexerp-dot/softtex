Imports System.Text
Imports DevExpress.XtraGrid

Public Class OfferwiseBeamstockRpt
    Private obj_Party_Selection As New Multi_Selection_Master
    Private WithEvents txtAccountCode As New TextBox
    Dim _CommanFilterString As String = ""
    Dim NoOfstage As Integer = 0
    Private Sub _OfferWiseGreyStkReport()
        Try

            Dim tblTmp = _GetQuery()
            FirstStage.Columns.Clear()
            Dim Qty As String = ""
            If tblTmp.Rows.Count > 0 Then
                For Each dr As DataRow In tblTmp.Select
                    'Qty = Format(dr("NoOfSet"), "0.00")
                    If Not IsDBNull(dr("NoOfSet")) Then
                        Qty = Format(Val(dr("NoOfSet").ToString()), "0.00")
                    Else
                        Qty = "0.00"
                    End If
                    dr("NoOfSet") = Qty
                    Qty = Format(dr("OfferBeam"), "0.00")
                    dr("OfferBeam") = Qty
                    'Qty = Format(dr("ReadyBeam"), "0.00")
                    If Not IsDBNull(dr("ReadyBeam")) Then
                        Qty = Format(Val(dr("ReadyBeam").ToString()), "0.00")
                    Else
                        Qty = "0.00"
                    End If
                    'dr("ReadyBeam") = Qty
                    Qty = Format(dr("BalanceBeam"), "0.00")
                    dr("BalanceBeam") = Qty
                    Qty = Format(dr("OfferQty"), "0.00")
                    dr("OfferQty") = Qty
                    'Qty = Format(dr("BeamLength"), "0.00")
                    If Not IsDBNull(dr("BeamLength")) Then
                        Qty = Format(Val(dr("BeamLength").ToString()), "0.00")
                    Else
                        Qty = "0.00"
                    End If
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
                FirstStage.Columns("OfferNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("OfferNo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("Pick").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("NoOfSet").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("OfferBeam").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("ReadyBeam").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("BalanceBeam").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("OfferQty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("BeamLength").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("BalanceMtr").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("ProdMtr").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("DisMtr").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("GreyStk").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                FirstStage.Columns("PendProd").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

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
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

        Dim tblTmp = _GetQuery()

        If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
            If tblTmp.Rows.Count > 0 Then
                REPORT_RPT_FILE_NAME = "OfferwiseBeamStockReport_1"
                Dim RptTitle = "Offer Wise Beam Summary Stock Report"
                Dim Date_Range = "Date From:" & txt_From.Text & " To:" & txt_To.Text & " "
                NewReportPrint(tblTmp, RptTitle, Date_Range)
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            End If
        Else
            If tblTmp.Rows.Count > 0 Then
                REPORT_RPT_FILE_NAME = "OfferwiseBeamStockReport_2"
                Dim RptTitle = "Offer Wise Beam Detail Stock Report"
                Dim Date_Range = "Date From:" & txt_From.Text & " To:" & txt_To.Text & " "
                NewReportPrint(tblTmp, RptTitle, Date_Range)
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            End If
        End If

    End Sub
    Private Function _GetQuery()

        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        _strQuery = New StringBuilder
        With _strQuery
            If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                .Append(" SELECT ")
                .Append(" isnull(C.offerno,0) OfferNo ")
                .Append(" ,Isnull(Format(C.offerdate, 'dd/MM/yyyy'),'') as [Date] ")
                .Append(" ,isnull(C.entryno ,0) as EntryNo ")
                .Append(" ,A.ACCOUNTNAME as [PartyName] ")
                .Append(" ,Max(z.pick) As Pick ")
                .Append(" ,isnull(c.no_of_set,0) as [NoOfSet] ")
                .Append(" ,isnull(c.pick_rate,0) as [Rate] ")
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
                .Append(" ,A.BookVno as OfferBookVno")
                .Append(" ,A.NO_OF_BEAM AS OfferBeam ")
                .Append(" ,0.00 AS  ReadyBeam ")
                .Append(" ,(A.Mtr_Weight) AS OfferQty ")
                .Append(" ,0.00 AS BeamLength ")
                .Append(" ,0.00  AS FOLDMTR ")
                .Append(" ,0.00  AS DISPMTR ")
                .Append(" ,0.00  AS Pick ")
                .Append(" FROM ")
                .Append(" TrnOffer AS A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BookCode ='0001-000000124' ")
                .Append(" AND A.OfferDate>='" & txt_From.Date_for_Database & "' AND A.OfferDate<='" & txt_To.Date_for_Database & "' ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.OP17 As OfferBookVno ")
                .Append(" ,0.00 OfferBeam ")
                .Append(" ,COUNT(A.BEAMNO) AS  ReadyBeam ")
                .Append(" ,0.00 AS OfferQty ")
                .Append(" ,SUM(A.Beam_Length) AS BeamLength ")
                .Append(" ,0.00  AS FOLDMTR ")
                .Append(" ,0.00  AS DISPMTR ")
                .Append(" ,0.00  AS Pick ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.OP17>'' ")
                .Append(" GROUP BY ")
                .Append(" A.OfferNo ")
                .Append(" ,A.OP17 ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.OP17 As OfferBookVno ")
                .Append(" ,0.00 AS OfferBeam ")
                .Append(" ,0.00 AS  ReadyBeam ")
                .Append(" ,0.00 AS OfferQty ")
                .Append(" ,0.00 AS BeamLength ")
                .Append(" ,SUM(B.GMTR) AS FOLDMTR ")
                .Append(" ,0.00 AS DISPMTR ")
                .Append(" ,0.00 AS Pick ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" LEFT JOIN TrnGreyRcpt AS B  ON A.BeamNo =B.BeamNo ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.OP17>'' ")
                .Append(" GROUP BY ")
                .Append(" A.OfferNo ")
                .Append(" ,A.OP17 ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.OP17 As OfferBookVno ")
                .Append(" ,0.00 AS OfferBeam ")
                .Append(" ,0.00 AS  ReadyBeam ")
                .Append(" ,0.00 AS OfferQty ")
                .Append(" ,0.00 AS BeamLength ")
                .Append(" ,0.00 AS FOLDMTR ")
                .Append(" ,SUM(C.GMTR) AS DISPMTR ")
                .Append(" ,C.Pick AS Pick ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" , TrnGreyDesp AS C ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BeamNo =C.BeamNo ")
                .Append(" AND A.OP17>'' ")
                .Append(" GROUP BY ")
                .Append(" A.OfferNo ")
                .Append(" ,A.OP17 ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode,C.Pick ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstMasterAccount AS A ON A.ACCOUNTCODE =Z.ACCOUNTCODE ")
                .Append(" LEFT JOIN TrnOffer AS C ON Z.OfferBookVno =C.BookVNo ")
                .Append(" GROUP BY ")
                .Append(" Z.OfferBookVno ")
                .Append(" ,C.OfferNo ")
                .Append(" ,A.ACCOUNTNAME ")
                .Append(" ,C.OfferDate ")
                .Append(" ,C.ENTRYNO ")
                .Append(" ,c.NO_OF_SET ")
                .Append(" ,c.PICK_RATE ")
                .Append(" HAVING SUM(Z.OfferQty)-SUM(Z.BeamLength)>0 ")
            ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                .Append(" SELECT ")
                .Append(" isnull(C.offerno,0) AS OfferNo ")
                .Append(" ,Z.BeamNo ")
                .Append(" ,CASE WHEN ISNULL(Z.EntryNo,0) = 0 THEN ISNULL(FORMAT(C.OfferDate,'dd/MM/yyyy'),'') ELSE ISNULL(FORMAT(Z.WarpDate,'dd/MM/yyyy'),'') END AS [Date] ")
                .Append(" ,CASE WHEN ISNULL(Z.EntryNo,0) = 0 THEN ISNULL(C.entryno,0) ELSE ISNULL(Z.entryno,0) END AS EntryNo ")
                .Append(" ,A.AccountName AS [PartyName] ")
                .Append(" ,Max(z.pick) AS Pick ")
                .Append(" ,isnull(C.No_Of_Set,0) AS [NoOfSet] ")
                .Append(" ,isnull(C.Pick_Rate,0) AS [Rate] ")
                .Append(" ,SUM(Z.OfferBeam) AS [OfferBeam] ")
                .Append(" ,SUM(Z.ReadyBeam) AS [ReadyBeam] ")
                .Append(" ,SUM(Z.OfferBeam)-SUM(Z.ReadyBeam) AS [BalanceBeam] ")
                .Append(" ,SUM(Z.OfferQty) AS [OfferQty] ")
                .Append(" ,SUM(Z.BeamLength) AS [BeamLength] ")
                .Append(" ,SUM(Z.OfferQty)-SUM(Z.BeamLength) AS [BalanceMtr] ")
                .Append(" ,SUM(Z.FOLDMTR) AS [ProdMtr] ")
                .Append(" ,SUM(Z.DISPMTR) AS [DisMtr] ")
                .Append(" ,SUM(Z.FOLDMTR)-SUM(Z.DISPMTR) AS [GreyStk] ")
                .Append(" ,SUM(Z.BeamLength)-SUM(Z.FOLDMTR) AS [PendProd] ")
                .Append(" FROM ( ")
                '================ OFFER =================
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.ItemCode ")
                .Append(" ,A.BookVno AS OfferBookVno ")
                .Append(" ,A.No_Of_Beam AS OfferBeam ")
                .Append(" ,0 AS ReadyBeam ")
                .Append(" ,A.Mtr_Weight AS OfferQty ")
                .Append(" ,0 AS BeamLength ")
                .Append(" ,0 AS FOLDMTR ")
                .Append(" ,0 AS DISPMTR ")
                .Append(" ,'' AS BeamNo ")
                .Append(" ,'' AS WarpDate ")
                .Append(" ,0 AS EntryNo ")
                .Append(" ,0 As Pick ")
                .Append(" FROM TrnOffer AS A ")
                .Append(" WHERE 1=1 ")
                .Append(" And a.clear<>'YES' ")
                .Append(" AND A.BookCode ='0001-000000124' ")
                .Append(" AND A.OfferDate>='" & txt_From.Date_for_Database & "' ")
                .Append(" AND A.OfferDate<='" & txt_To.Date_for_Database & "' ")
                .Append(" UNION ALL ")
                '================ READY BEAM =================
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ItemCode ")
                .Append(" ,A.OP17 AS OfferBookVno ")
                .Append(" ,0 AS OfferBeam ")
                .Append(" ,COUNT(A.BeamNo) AS ReadyBeam ")
                .Append(" ,0 AS OfferQty ")
                .Append(" ,SUM(A.Beam_Length) AS BeamLength ")
                .Append(" ,0 AS FOLDMTR ")
                .Append(" ,0 AS DISPMTR ")
                .Append(" ,A.BeamNo ")
                .Append(" ,A.WarpDate ")
                .Append(" ,A.EntryNo ")
                .Append(" ,0 As Pick ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" WHERE A.OP17<>'' ")
                .Append(" GROUP BY A.OP17,A.BeamNo,A.WarpDate,A.EntryNo ")
                .Append(" ,A.AccountCode,A.Fabric_ItemCode ")
                .Append(" UNION ALL ")
                '================ PRODUCTION =================
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ItemCode ")
                .Append(" ,A.OP17 AS OfferBookVno ")
                .Append(" ,0 AS OfferBeam ")
                .Append(" ,0 AS ReadyBeam ")
                .Append(" ,0 AS OfferQty ")
                .Append(" ,0 AS BeamLength ")
                .Append(" ,SUM(B.GMTR) AS FOLDMTR ")
                .Append(" ,0 AS DISPMTR ")
                .Append(" ,A.BeamNo ")
                .Append(" ,A.WarpDate ")
                .Append(" ,A.EntryNo ")
                .Append(" ,0 As Pick ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" LEFT JOIN TrnGreyRcpt AS B ON A.BeamNo=B.BeamNo ")
                .Append(" WHERE A.OP17<>'' ")
                .Append(" GROUP BY A.OP17,A.BeamNo,A.WarpDate,A.EntryNo ")
                .Append(" ,A.AccountCode,A.Fabric_ItemCode ")
                .Append(" UNION ALL ")
                '================ DISPATCH =================
                .Append(" SELECT ")
                .Append(" A.AccountCode ")
                .Append(" ,A.Fabric_ItemCode AS ItemCode ")
                .Append(" ,A.OP17 AS OfferBookVno ")
                .Append(" ,0 AS OfferBeam ")
                .Append(" ,0 AS ReadyBeam ")
                .Append(" ,0 AS OfferQty ")
                .Append(" ,0 AS BeamLength ")
                .Append(" ,0 AS FOLDMTR ")
                .Append(" ,SUM(C.GMTR) AS DISPMTR ")
                .Append(" ,A.BeamNo ")
                .Append(" ,A.WarpDate ")
                .Append(" ,A.EntryNo ")
                .Append(" ,C.Pick ")
                .Append(" FROM TrnBeamHeader AS A ")
                .Append(" INNER JOIN TrnGreyDesp AS C ON A.BeamNo=C.BeamNo ")
                .Append(" WHERE A.OP17<>'' ")
                .Append(" GROUP BY A.OP17,A.BeamNo,A.WarpDate,A.EntryNo ")
                .Append(" ,A.AccountCode,A.Fabric_ItemCode,C.Pick ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstMasterAccount AS A ON A.AccountCode=Z.AccountCode ")
                .Append(" LEFT JOIN TrnOffer AS C ON Z.OfferBookVno=C.BookVno ")
                .Append(" Where c.clear<>'YES' ")
                .Append(" GROUP BY ")
                .Append(" Z.OfferBookVno,C.OfferNo ")
                .Append(" ,Z.WarpDate,Z.EntryNo,Z.BeamNo ")
                .Append(" ,A.AccountName ")
                .Append(" ,C.OfferDate,C.EntryNo ")
                .Append(" ,C.No_Of_Set,C.Pick_Rate ")
            End If
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy

        Return tblTmp
    End Function
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

    Private Sub OfferwiseBeamstockRpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        PnlView.Width = 974
        PnlView.Height = 595
        PnlView.Location = New Point(1, 1)
        Txt_ProcessStockDisplay.Text = "SUMMARY"
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
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        _OfferWiseGreyStkReport()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub OfferwiseBeamstockRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
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

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#End Region
End Class