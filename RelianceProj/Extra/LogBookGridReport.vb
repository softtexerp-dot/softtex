
Imports System.Text
Imports DevExpress.XtraPivotGrid


Friend Class LogBookGridReport

    Private Sub LogBookGridReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")

        Me.Location = New Point(0, 0)

        View_Log_Book()

        PivotGridControl1.OptionsCustomization.AllowCustomizationForm = True
        PivotGridControl1.OptionsCustomization.AllowDrag = True
        ' ✅ Automatically show the field customization form (Field List)
        PivotGridControl1.FieldsCustomization()

        With PivotGridControl1
            .OptionsCustomization.AllowCustomizationForm = True
            .FieldsCustomization()  ' open the field list

            ' ✅ Get the customization form reference
            Dim custForm = .CustomizationForm
            If custForm IsNot Nothing Then
                custForm.Size = New Size(300, 554)     ' width × height
                custForm.StartPosition = FormStartPosition.Manual
                custForm.Location = New Point(804, 85)
                custForm.Text = "Filter Field List"
            End If
        End With

        AttachButtonFocusEvents(Me)
    End Sub



    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub

    Private Sub View_Log_Book()
        Try

            Generate_Date_For_DataBase(txt_From)
            Generate_Date_For_DataBase(txt_To)


            Dim View_Filter_Condition As String = ""
            Dim View_Order_By As String = ""
            Dim View_Query As String = ""

            View_Filter_Condition = " AND A.LOG_BOOK_DATE>='" & txt_From.Date_for_Database & "' AND A.LOG_BOOK_DATE<='" & txt_To.Date_for_Database & "'"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT Z.LOG_BOOK_DATE AS Date, ")
                .Append(" QUOTENAME(Format(Z.LOG_BOOK_DATE,'MMM')) AS Month, ")
                .Append(" z.LoomNo,  ")
                .Append(" ROUND(SUM(Z.A_SHIFT_EFFI)/SUM(Z.A_LM_CNT),2) AS AShiftEffi, ")
                .Append(" ROUND(SUM(Z.B_SHIFT_EFFI)/SUM(Z.B_LM_CNT),2) AS BShiftEffi, ")
                '.Append(" ROUND((ROUND(SUM(A_SHIFT_EFFI)/SUM(Z.A_LM_CNT),2)+ROUND(SUM(B_SHIFT_EFFI)/SUM(Z.B_LM_CNT),2))/2,2) AS AvgEffi, ")
                .Append("ROUND(IIF(ISNULL(SUM(Z.B_SHIFT_EFFI), 0) = 0,ROUND(SUM(Z.A_SHIFT_EFFI) / NULLIF(SUM(Z.A_LM_CNT), 0), 2),IIF(ISNULL(SUM(Z.A_SHIFT_EFFI), 0) = 0,ROUND(SUM(Z.B_SHIFT_EFFI) / NULLIF(SUM(Z.B_LM_CNT), 0), 2),ROUND((ROUND(SUM(Z.A_SHIFT_EFFI) / NULLIF(SUM(Z.A_LM_CNT), 0), 2) +ROUND(SUM(Z.B_SHIFT_EFFI) / NULLIF(SUM(Z.B_LM_CNT), 0), 2)) / 2,2))),2) AS AvgEffi,")
                .Append(" e.empname as Weavername,")
                ' BEAM GAT TIME
                'REMARK
                .Append(" SUM(Z.A_PICK) AS [A Pick], ")
                .Append(" SUM(Z.B_PICK) AS [B Pick], ")
                '.Append(" ROUND((SUM(Z.A_PICK)/SUM(Z.A_LM_CNT)+SUM(Z.B_PICK)/SUM(Z.B_LM_CNT))/2,0) AS [Avg Pick], ")
                .Append("IIF(SUM(Z.B_PICK) = 0,SUM(Z.A_PICK) / SUM(Z.A_LM_CNT),IIF(SUM(Z.A_PICK) = 0,SUM(Z.B_PICK) / SUM(Z.B_LM_CNT),((SUM(Z.A_PICK)/SUM(Z.A_LM_CNT) + SUM(Z.B_PICK)/SUM(Z.B_LM_CNT)) / 2))) AS [Avg Pick], ")
                .Append(" SUM(Z.A_SHIFT_PROD) AS [A Shift Prod], ")
                .Append(" SUM(Z.B_SHIFT_PROD) AS [B Shift Prod], ")
                .Append(" SUM(Z.A_SHIFT_PROD)+SUM(Z.B_SHIFT_PROD) AS [Total Prod], ")
                .Append(" Z.Beam_Fall as FallTime,  ")
                .Append(" Z.Remark_Narr as Remark,  ")
                'BEAM BALANCE
                .Append(" A.ACCOUNTNAME AS PartyName, ")
                .Append(" B.ITENNAME AS ItemName, ")
                .Append(" Z.BeamNo,  ")
                .Append(" Z.BeamNo2,  ")
                .Append(" isnull(Sum(Z.OP13),0) as BeamBalance,  ")
                'EXTRA LOOM
                .Append(" F.EMPNAME  AS SuperWiser,")
                .Append(" G.EMPNAME  AS Fitetr,")
                .Append(" H.EMPNAME  AS BeamGatter,")
                .Append(" z.EntryNo")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT  ")
                .Append(" A.SHIFT AS A_SHIFT ")
                .Append(" , A.PROD_MTR AS A_SHIFT_PROD,  ")
                .Append(" A.EFFI_PER AS A_SHIFT_EFFI ")
                .Append(" ,B.LOOMNO AS A_LOOMNO ")
                .Append(" ,A.PICK AS A_PICK, ")
                .Append(" A.ACCOUNTCODE AS A_ACCOUNTCODE ")
                .Append(" ,A.FABRIC_ITEMCODE AS A_FABRIC_ITEMCODE, ")
                .Append(" A.EMPCODE AS A_EMPCODE, ")
                .Append(" A.PICK*A.PROD_MTR AS A_PICK_MTR ")
                .Append(" ,1 AS A_LM_CNT, ")
                .Append(" A.LOG_BOOK_DATE, ")
                .Append(" '' AS B_SHIFT ")
                .Append(" , 0 AS B_SHIFT_PROD ")
                .Append(" , 0 AS B_SHIFT_EFFI ")
                .Append(" ,0 AS B_LOOMNO ")
                .Append(" , 0 AS B_PICK, ")
                .Append(" 0 AS B_PICK_MTR,1 AS B_LM_CNT, ")
                .Append(" '' AS B_ACCOUNTCODE,'' AS B_FABRIC_ITEMCODE,'' AS B_EMPCODE ")
                .Append(" ,A.FABRIC_ITEMCODE ")
                .Append(" ,A.ACCOUNTCODE ")
                .Append(" ,A.BeamNo  ")
                .Append(" ,A.OP5 AS BeamNo2 ")
                .Append(" ,B.LoomNo  ")
                .Append(" ,A.EntryNo  ")
                .Append(" ,A.EMPCODE as Weavercode  ")
                .Append(" ,A.OP2 as SUPERWISERCODE  ")
                .Append(" ,A.OP3 as FitterCode  ")
                .Append(" ,A.OP4 as BeamGatterCode  ")
                .Append(" ,A.Beam_Fall as Beam_Fall  ")
                .Append(" ,A.Remark_Narr as Remark_Narr  ")
                .Append(" ,A.OP13 as OP13  ")
                .Append(" FROM TRNLOGBOOK AS A,MSTLOOMNO AS B ")
                .Append(" WHERE 1=1 AND A.SHIFT='A'   AND  A.LOOMNOCODE=B.LOOMNOCODE AND A.EFFI_PER>0 ")
                .Append(View_Filter_Condition)
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" '' AS A_SHIFT ")
                .Append(" , 0 AS A_SHIFT_PROD ")
                .Append(" , 0 AS A_SHIFT_EFFI ")
                .Append(" ,0 AS A_LOOMNO ")
                .Append(" , 0 AS A_PICK ")
                .Append(" ,'' AS A_ACCOUNTCODE ")
                .Append(" ,'' AS A_FABRIC_ITEMCODE ")
                .Append(" ,'' AS A_EMPCODE ")
                .Append(" ,0 AS A_PICK_MTR ")
                .Append(" ,1 AS A_LM_CNT, ")
                .Append(" A.LOG_BOOK_DATE ")
                .Append(" , A.SHIFT AS B_SHIFT ")
                .Append(" , A.PROD_MTR AS B_SHIFT_PROD, ")
                .Append(" A.EFFI_PER AS B_SHIFT_EFFI ")
                .Append(" ,B.LOOMNO AS B_LOOMNO ")
                .Append(" ,A.PICK AS B_PICK ")
                .Append(" ,A.PICK*A.PROD_MTR AS B_PICK_MTR ")
                .Append(" ,1 AS B_LM_CNT ")
                .Append(" ,A.ACCOUNTCODE AS B_ACCOUNTCODE ")
                .Append(" ,A.FABRIC_ITEMCODE AS B_FABRIC_ITEMCODE ")
                .Append(" ,A.EMPCODE AS B_EMPCODE ")
                .Append(" ,A.FABRIC_ITEMCODE ")
                .Append(" ,A.ACCOUNTCODE ")
                .Append(" ,A.BeamNo  ")
                .Append(" ,A.OP5 AS BeamNo2 ")
                .Append(" ,B.LoomNo  ")
                .Append(" ,A.EntryNo  ")
                .Append(" ,A.EMPCODE as Weavercode  ")
                .Append(" ,A.OP2 as SUPERWISERCODE  ")
                .Append(" ,A.OP3 as FitterCode  ")
                .Append(" ,A.OP4 as BeamGatterCode  ")
                .Append(" ,A.Beam_Fall as Beam_Fall  ")
                .Append(" ,A.Remark_Narr as Remark_Narr  ")
                .Append(" ,A.OP13 as OP13  ")
                .Append(" FROM TRNLOGBOOK AS A,MSTLOOMNO AS B  ")
                .Append(" WHERE 1=1 AND A.SHIFT='B' AND  A.LOOMNOCODE=B.LOOMNOCODE  AND A.EFFI_PER>0 ")
                .Append(View_Filter_Condition)
                .Append(" ) ")
                .Append(" AS Z ")
                .Append(" left join MstMasterAccount A on A.ACCOUNTCODE=Z.ACCOUNTCODE ")
                .Append(" left join MSTFABRICITEM B  on B.id=Z.FABRIC_ITEMCODE  ")
                .Append(" left join MstEmployee e ON  Z.Weavercode=e.empcode  ")
                .Append(" left join MstEmployee F ON  Z.SUPERWISERCODE=F.EMPCODE  ")
                .Append(" left join MstEmployee G ON  Z.FitterCode=G.EMPCODE  ")
                .Append(" left join MstEmployee H ON  Z.BeamGatterCode=H.EMPCODE  ")
                .Append(" WHERE 1=1 ")
                .Append(" GROUP BY Z.LOG_BOOK_DATE ")
                .Append(" ,z.EntryNo ")
                .Append(" ,A.ACCOUNTNAME ")
                .Append(" ,B.ITENNAME ")
                .Append(" ,Z.BeamNo  ")
                .Append(" ,z.LoomNo  ")
                .Append(" ,z.BeamNo2  ")
                .Append(" ,e.empname ")
                .Append(" ,F.EMPNAME ")
                .Append(" ,G.EMPNAME ")
                .Append(" ,H.EMPNAME ")
                .Append(" ,Z.Beam_Fall ")
                .Append(" ,Z.Remark_Narr ")
                .Append(" ,Z.OP13 ")
                .Append(" ORDER BY  Z.LOG_BOOK_DATE ,z.LoomNo  ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim tblTmp = DefaltSoftTable.Copy
            Dim Qty As String = ""
            If tblTmp.Rows.Count > 0 Then
                PivotGridControl1.Fields.Clear()
                PivotGridControl1.DataSource = Nothing
                PivotGridControl1.DataSource = tblTmp
                ' 🔹 Define Fields
                Dim fDate As New PivotGridField("Date", PivotArea.RowArea)
                Dim fmonth As New PivotGridField("Month", PivotArea.RowArea)
                Dim fLoomNo As New PivotGridField("LoomNo", PivotArea.RowArea)
                Dim fPartyName As New PivotGridField("PartyName", PivotArea.RowArea)
                Dim fItemName As New PivotGridField("ItemName", PivotArea.RowArea)
                Dim fWeavername As New PivotGridField("Weavername", PivotArea.RowArea)
                Dim fFitetr As New PivotGridField("Fitetr", PivotArea.RowArea)
                Dim fSuperWiser As New PivotGridField("SuperWiser", PivotArea.RowArea)
                Dim fBeamFalltime As New PivotGridField("FallTime", PivotArea.RowArea)
                Dim fRemark As New PivotGridField("Remark", PivotArea.RowArea)
                ' 🔹 Summary Field
                Dim fAShiftEffi As New PivotGridField("AShiftEffi", PivotArea.DataArea)
                Dim fBShiftEffi As New PivotGridField("BShiftEffi", PivotArea.DataArea)
                Dim fAvgEffi As New PivotGridField("AvgEffi", PivotArea.DataArea)
                Dim fAShiftProd As New PivotGridField("A Shift Prod", PivotArea.DataArea)
                Dim fBShiftProd As New PivotGridField("B Shift Prod", PivotArea.DataArea)
                Dim fTotalProd As New PivotGridField("Total Prod", PivotArea.DataArea)
                Dim fapack As New PivotGridField("A Pick", PivotArea.DataArea)
                Dim fbpack As New PivotGridField("B Pick", PivotArea.DataArea)
                Dim favgpack As New PivotGridField("Avg Pick", PivotArea.DataArea)
                Dim fBeamBalance As New PivotGridField("BeamBalance", PivotArea.DataArea)
                ' 🔹 Summary Type
                fAShiftEffi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fBShiftEffi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fAvgEffi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
                fAShiftProd.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fBShiftProd.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fTotalProd.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fapack.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fbpack.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                favgpack.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
                fBeamBalance.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                'fBeamFalltime.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                ' 🔹 Friendly captions
                fDate.Caption = "Date"
                fmonth.Caption = "Month"
                fLoomNo.Caption = "Loom No"
                fItemName.Caption = "Item Name"
                fPartyName.Caption = "Party Name"
                fWeavername.Caption = "Weavername"
                fFitetr.Caption = "Fitetr"
                fSuperWiser.Caption = "SuperWiser"
                fRemark.Caption = "Remark"
                fBeamFalltime.Caption = "Beam FallTime"
                fBeamBalance.Caption = "Beam Balance"
                ' 🔹 Summary captions
                fAShiftEffi.Caption = "A Shift Effi"
                fBShiftEffi.Caption = "B Shift Effi"
                fAvgEffi.Caption = "Avg Effi"
                fapack.Caption = "A Pick"
                fbpack.Caption = "B Pick"
                favgpack.Caption = "Avg Pick"
                fAShiftProd.Caption = "A Shift Prod"
                fBShiftProd.Caption = "B Shift Prod"
                fTotalProd.Caption = "Total Prod"
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    fDate.Visible = False
                    fmonth.Visible = False
                    fItemName.Visible = False
                    fPartyName.Visible = False
                    fSuperWiser.Visible = False
                    fWeavername.Visible = False
                    fFitetr.Visible = False
                    fBeamFalltime.Visible = False
                    fRemark.Visible = False
                    fapack.Visible = True
                    fbpack.Visible = True
                    favgpack.Visible = True
                    fBeamBalance.Visible = True
                    fAShiftProd.Visible = True
                    fBShiftProd.Visible = True
                    fTotalProd.Visible = True
                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    fDate.Visible = True
                    fmonth.Visible = True
                    fItemName.Visible = True
                    fPartyName.Visible = True
                    fSuperWiser.Visible = False
                    fWeavername.Visible = False
                    fFitetr.Visible = False
                    fBeamFalltime.Visible = False
                    fRemark.Visible = False
                    fapack.Visible = True
                    fbpack.Visible = True
                    favgpack.Visible = True
                    fBeamBalance.Visible = True
                    fAShiftProd.Visible = True
                    fBShiftProd.Visible = True
                    fTotalProd.Visible = True
                End If
                ' 🔹 Add to Pivot
                PivotGridControl1.Fields.AddRange(New PivotGridField() {fDate, fmonth, fLoomNo, fItemName, fPartyName, fWeavername, fFitetr, fAShiftEffi, fSuperWiser, fBShiftEffi, fAvgEffi, fapack, fbpack, favgpack, fBeamFalltime, fRemark, fBeamBalance, fAShiftProd, fBShiftProd, fTotalProd})
                ' 🔹 Allow runtime field chooser
                PivotGridControl1.OptionsCustomization.AllowDrag = True
                PivotGridControl1.OptionsCustomization.AllowFilter = True
                PivotGridControl1.OptionsCustomization.AllowSort = True
                PivotGridControl1.OptionsCustomization.AllowExpand = True
                PivotGridControl1.OptionsCustomization.AllowCustomizationForm = True
                PivotGridControl1.OptionsCustomization.AllowEdit = False
                ' 🔹 Show Field Chooser (runtime में columns जोड़ने के लिए)
                PivotGridControl1.OptionsView.ShowDataHeaders = True
                PivotGridControl1.OptionsView.ShowFilterHeaders = True
                PivotGridControl1.OptionsView.ShowRowHeaders = True
                PivotGridControl1.OptionsView.ShowColumnHeaders = True
                ' 🔹 Auto update when user changes layout
                AddHandler PivotGridControl1.FieldAreaChanged, AddressOf Pivot_LayoutChanged
                PivotGridControl1.OptionsView.ShowDataHeaders = True
                PivotGridControl1.OptionsView.ShowFilterHeaders = True
                PivotGridControl1.OptionsView.ShowRowHeaders = True
                PivotGridControl1.OptionsView.ShowColumnHeaders = True

                PivotGridControl1.BestFit()

            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Pivot_LayoutChanged(sender As Object, e As PivotFieldEventArgs)
        Dim pivot = CType(sender, PivotGridControl)
        pivot.RefreshData()
    End Sub

    Private Sub PivotGridControl1_CustomCellDisplayText(sender As Object, e As PivotCellDisplayTextEventArgs) Handles PivotGridControl1.CustomCellDisplayText
        ' 🔹 Check if the cell is a Grand Total cell
        If e.ColumnValueType = PivotGridValueType.GrandTotal OrElse e.RowValueType = PivotGridValueType.GrandTotal Then
            ' 🔹 Remove ₹ sign from display text
            e.DisplayText = e.DisplayText.Replace("₹", "").Trim()
        End If
    End Sub

    Private Sub btn_xl_Click(sender As Object, e As EventArgs) Handles btn_xl.Click
        _DevPivotExpressExcelExport(PivotGridControl1)
    End Sub

    Private Sub But_print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Log Book Report"
        _DevPivotExpressPrintPreview(_RptTiltle, PivotGridControl1)
    End Sub

    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SavePivotLayout(PivotGridControl1, Me.Name)
    End Sub

    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_PivotLayout(PivotGridControl1, Me.Name)
    End Sub
End Class