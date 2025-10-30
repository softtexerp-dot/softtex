
Imports System.Text
Imports DevExpress.XtraPivotGrid


Friend Class LogBookGridReport

    Private Sub LogBookGridReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        Me.Location = New Point(0, 0)

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
                .Append(" z.LoomNo,  ")
                .Append(" ROUND(SUM(Z.A_SHIFT_EFFI)/SUM(Z.A_LM_CNT),2) AS AShiftEffi, ")
                .Append(" ROUND(SUM(Z.B_SHIFT_EFFI)/SUM(Z.B_LM_CNT),2) AS BShiftEffi, ")
                .Append(" ROUND((ROUND(SUM(A_SHIFT_EFFI)/SUM(Z.A_LM_CNT),2)+ROUND(SUM(B_SHIFT_EFFI)/SUM(Z.B_LM_CNT),2))/2,2) AS AvgEffi, ")
                .Append(" e.empname as Weavername,")
                ' BEAM GAT TIME
                'REMARK
                .Append(" SUM(Z.A_PICK) AS [A Pick], ")
                .Append(" SUM(Z.B_PICK) AS [B Pick], ")
                .Append(" ROUND((SUM(Z.A_PICK)/SUM(Z.A_LM_CNT)+SUM(Z.B_PICK)/SUM(Z.B_LM_CNT))/2,0) AS [Avg Pick], ")
                .Append(" SUM(Z.A_SHIFT_PROD) AS [A Shift Prod], ")
                .Append(" SUM(Z.B_SHIFT_PROD) AS [B Shift Prod], ")
                .Append(" SUM(Z.A_SHIFT_PROD)+SUM(Z.B_SHIFT_PROD) AS [Total Prod], ")
                'BEAM BALANCE
                .Append(" A.ACCOUNTNAME AS PartyName, ")
                .Append(" B.ITENNAME AS ItemName, ")
                .Append(" Z.BeamNo,  ")
                .Append(" Z.BeamNo2,  ")
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
                .Append(" ORDER BY  Z.LOG_BOOK_DATE ,z.LoomNo  ")
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()

            Dim tblTmp = DefaltSoftTable.Copy

            Dim Qty As String = ""
            If tblTmp.Rows.Count > 0 Then
                PivotGridControl1.DataSource = Nothing
                PivotGridControl1.DataSource = tblTmp

                ' 🔹 Define Fields
                Dim fDate As New PivotGridField("Date", PivotArea.RowArea)
                Dim fLoomNo As New PivotGridField("LoomNo", PivotArea.RowArea)
                Dim fPartyName As New PivotGridField("PartyName", PivotArea.RowArea)
                Dim fItemName As New PivotGridField("ItemName", PivotArea.RowArea)
                Dim fWeavername As New PivotGridField("Weavername", PivotArea.RowArea)
                Dim fFitetr As New PivotGridField("Fitetr", PivotArea.RowArea)
                Dim fSuperWiser As New PivotGridField("SuperWiser", PivotArea.RowArea)



                Dim fAShiftEffi As New PivotGridField("AShiftEffi", PivotArea.DataArea)
                Dim fBShiftEffi As New PivotGridField("BShiftEffi", PivotArea.DataArea)


                ' 🔹 Summary Type
                fAShiftEffi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
                fBShiftEffi.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum

                ' 🔹 Friendly captions
                fDate.Caption = "Date"
                fLoomNo.Caption = "Loom No"
                fItemName.Caption = "Item Name"
                fPartyName.Caption = "Party Name"
                fAShiftEffi.Caption = "A Shift Effi"
                fBShiftEffi.Caption = "B Shift Effi"
                fWeavername.Caption = "Weavername"
                fFitetr.Caption = "Fitetr"
                fSuperWiser.Caption = "SuperWiser"


                fDate.Visible = False
                fItemName.Visible = False
                fPartyName.Visible = False
                fSuperWiser.Visible = False
                fWeavername.Visible = False
                fFitetr.Visible = False



                ' 🔹 Add to Pivot
                PivotGridControl1.Fields.AddRange(New PivotGridField() {fDate, fLoomNo, fItemName, fPartyName, fWeavername, fFitetr, fAShiftEffi, fSuperWiser, fBShiftEffi})

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


End Class