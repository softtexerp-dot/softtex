Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.Drawing.Internal.Fonts.DXFontMetrics
Imports Microsoft.VisualBasic.CompilerServices
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Public Class Multi_Selection_Master

    Dim strQuery As StringBuilder
    Public _strQuery As StringBuilder

#Region "PRINTING"
    Public Sub company_dataset()
        Dim rptDScompany = New Report_set
        Dim DT As DataTable = rptDScompany.Tables("SoftTexCompanyTable")
        For Each dr As DataRow In COMPANY_TBL.Rows
            Dim DTROW1 As DataRow = DT.Rows.Add
            DTROW1("T1") = dr(0)
            DTROW1("T2") = dr(1)
            DTROW1("T3") = dr(2)
            DTROW1("T4") = dr(3)
            DTROW1("T5") = dr(4)
            DTROW1("T6") = dr(5)
            DTROW1("T7") = dr(6)
            DTROW1("T8") = dr(7)
            DTROW1("T9") = dr(8)
            DTROW1("T10") = dr(9)
            DTROW1("T11") = dr(10)
            DTROW1("T12") = dr(11)
            DTROW1("T13") = dr(12)
            DTROW1("T14") = dr(13)
            DTROW1("T15") = dr(14)
            DTROW1("T16") = dr(15)
            DTROW1("T17") = dr(16)
            DTROW1("T18") = dr(17)
            DTROW1("T19") = dr(18)
            DTROW1("T20") = dr(19)
            DTROW1("T21") = dr(20)
            DTROW1("T22") = dr(21)
            DTROW1("T23") = dr(22)
            DTROW1("T24") = dr(23)
            DTROW1("T25") = dr(24)
            DTROW1("T26") = dr(25)
            DTROW1("T27") = dr(26)
            DTROW1("T28") = dr(27)
            DTROW1("T29") = dr(28)
            DTROW1("T30") = dr(29)
            DTROW1("T31") = dr(30)
            DTROW1("T32") = dr(31)
            DTROW1("T33") = dr(32)
            DTROW1("T34") = dr(33)
            DTROW1("T35") = dr(34)
            DTROW1("T36") = dr(35)
            DTROW1("T37") = dr(36)
            DTROW1("T38") = dr(37)
            DTROW1("T39") = dr(38)
            DTROW1("T40") = dr(39)
            DTROW1("T41") = dr(40)
            DTROW1("T42") = dr(41)
            DTROW1("T43") = dr(42)
            DTROW1("T44") = dr(43)
            DTROW1("T45") = dr(44)
            DTROW1("T46") = dr(45)
            DTROW1("T47") = dr(46)
            DTROW1("T48") = dr(47)
            DTROW1("T49") = dr(48)
            DTROW1("T50") = dr(49)
            DTROW1("T51") = dr(50)
            DTROW1("T52") = dr(51)
            DTROW1("T53") = dr(52)
            DTROW1("T54") = dr(53)
            DTROW1("T55") = dr(54)
            DTROW1("T56") = dr(55)
            DTROW1("T57") = dr(56)
        Next
        rptDScompany.Tables("SoftTexCompanyTable").Merge(DT)
    End Sub
    Public Sub DirectReportUsePrint(ByVal rptTitle As String, ByVal strDateRange As String)
        Try
            Report_viewer.Close()
            Report_viewer.Dispose()

            strReportPath = ""
            strReportPath = _reportFileSelection(REPORT_RPT_FILE_NAME)

            'If _CheckServerPcs = True Then
            '    strReportPath = (System.Windows.Forms.Application.StartupPath + "\Reports\" & REPORT_RPT_FILE_NAME & ".rpt")
            'Else
            '    strReportPath = (_ServerPcPath + "\Reports\" & REPORT_RPT_FILE_NAME & ".rpt")
            'End If



            If IO.File.Exists(strReportPath) Then
            Else
                MsgBox("File Not Found:" & strReportPath, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                REPORT_RPT_FILE_NAME = ""
                Exit Sub
            End If

            cryRpt = New ReportDocument
            'cryRpt.Refresh()
            Report_viewer.Text = REPORT_RPT_FILE_NAME
            cryRpt.Load(strReportPath)
            cryRpt.SetDataSource(rptDS)

            If rptDS.Tables("rptTable").Rows.Count > 0 Then
                _ReportViewerTbl.Clear()
                _ReportViewerTbl = rptDS.Tables("rptTable").Copy
            End If


            cryRpt.SetParameterValue("Comp_name", COMPANY_NAME)
            cryRpt.SetParameterValue("rptTitle", rptTitle)
            cryRpt.SetParameterValue("strDateRange", strDateRange)

            If RUN_TIME_PRINT = "DIRECT_PRINT" Then
                cryRpt.PrintToPrinter(_DirectPrintNoCopy, False, 0, 0)
                RUN_TIME_PRINT = ""
            Else
                Report_viewer.CrystalReportViewer1.ReportSource = cryRpt
                Report_viewer.CrystalReportViewer1.Zoom(1)
                Report_viewer.ShowDialog()
            End If

            EmailSubject = ""
            Report_viewer.Close()
            Report_viewer.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub


    Public Sub Fill_Logo_in_DataTable(ByVal tblName As DataTable, ByVal _FileName As String, Optional ByVal AllFill As Boolean = False)

        'If Len(Trim(_CompanyDataRow("LOGO_FILE_NAME").ToString)) > 0 Then
        Dim Logo_File_Name As String = Application.StartupPath.ToString & "\QRCode Image\" & _FileName & ".png"

        If IO.File.Exists(Logo_File_Name) Then
            Dim m_Bitmap As Byte() = ConvertImageFiletoBytes(Logo_File_Name)

            If tblName.Rows.Count > 0 Then
                For Each dr As DataRow In tblName.Rows
                    dr("WEAVETYPE") = m_Bitmap
                    If AllFill = False Then Exit Sub
                Next
            End If
        End If
        'End If

    End Sub
    Public Sub Outstanding_Blank_Field_fill()

#Region "Opening Setting"

        sqL = " UPDATE TrnLedger SET OP1='-1' WHERE SUBSTRING (booktrtype,1,5) ='OP-VU'"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnLedger SET VOUCHER_ROW_ID=-1 where  SUBSTRING( booktrtype , 1,6)='OP-VU'"
        sql_Data_Save_Delete_Update()
#End Region



        sqL = " UPDATE TrnInvoiceHeader SET LRDATE=BILLDATE WHERE LRDATE ='1900-01-01 00:00:00.000'"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnLedger SET OP1='0' WHERE  OP1 IS NULL "
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET debitamt='0' WHERE  debitamt IS NULL "
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET creditamt='0' WHERE  creditamt IS NULL "
        sql_Data_Save_Delete_Update()


        sqL = " UPDATE TrnOutstanding SET  adjvnodate=''   WHERE adjvnodate IS NULL"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET  adjbookvno=''   WHERE adjbookvno IS NULL"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET  adjbookvno=''   WHERE adjbookvno='0'"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET  Intvnodate=''   WHERE Intvnodate IS NULL"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET  Intchqdddate=''   WHERE Intchqdddate IS NULL"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET  FinRemark=''   WHERE FinRemark IS NULL"
        sql_Data_Save_Delete_Update()

        sqL = " UPDATE TrnOutstanding SET  suncode=''   WHERE suncode IS NULL"
        sql_Data_Save_Delete_Update()

        sqL = "  update trninvoicesundry set calcrate =0 where calcamount=0"
        sql_Data_Save_Delete_Update()

    End Sub
    Public Function GetFinancaleYearDate(ByVal EndDate As String)
        Dim Date_frm As String = ""
        Dim Date_to As String = ""

        If EndDate = "" Then EndDate = CDate(Date.Now).ToString("dd/MM/yyyy")
        If COMPANY_TBL.Rows(0).Item("FINTO") > EndDate Then
            'Date_frm = CDate(dtBegin).ToString("dd/MM/yyyy")
            Date_to = EndDate
        Else
            'Date_frm = Main_MDI_Frm.FINE_YEAR_START.Text
            Date_to = Main_MDI_Frm.FINE_YEAR_END.Text
        End If
        Return Date_to
    End Function
#End Region



#Region "QUERY"

#Region "Inventroy Piece Status "
    Public Function Inventory_Piece_Status_Piece_Qry(ByVal Piece_No As String, ByVal Search_Type As String)
        Dim Search_Filter_String As String = ""

        If Search_Type = "PIECE NO" Then
            Search_Filter_String = " AND SUBSTRING(A.PIECENO,1," & Len(Trim(Piece_No)) & ")= '" & Piece_No & "' "
        ElseIf Search_Type = "GREY MTR" Then
            Search_Filter_String = " AND A.GMTR=" & Val(Piece_No) & "  "
        ElseIf Search_Type = "PROCESS BEAM NO" Then
            Search_Filter_String = " AND A.Process_Beamlotno= '" & Piece_No & "' "
        ElseIf Search_Type = "CHALLAN NO" Then
            Search_Filter_String = " AND A.CHALLANNO= '" & Piece_No & "' "
        Else
            Search_Filter_String = ""
        End If

        Dim _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.GREY_DESP_PCS_ID, ")
            .Append(" A.PIECENO AS [Piece No], ")
            .Append(" A.G_CHALLAN_NO AS [Grey Chl-No], ")
            .Append(" A.PROCESSNAME AS [Process Name], ")
            .Append(" Z.P_PIECENO AS [P-Piece No], ")
            .Append(" A.GMTR AS [Grey Mtrs], ")
            .Append(" Z.GMTR AS [P-Grey Mtrs], ")
            .Append(" Z.PMTR AS [Finish Mtrs], ")
            .Append(" Z.SHK_MTR AS [Shk Mtrs], ")
            .Append(" Z.SHK_PER AS [Shk %], ")
            .Append(" ' ' AS [Bal-Mtrs], ")
            .Append(" FORMAT(A.G_CHALLANDATE,'dd/MM/yyyy') AS [Grey Chl-Date], ")
            .Append(" A.G_ENTRYNO AS [Grey Entry No], ")
            .Append(" A.G_SRNO AS [Grey Sno], ")
            .Append(" A.WEIGHT AS [Weight], ")
            .Append(" A.PCAVGWT AS [Avg-Wt], ")
            .Append(" A.PICK AS [Pick], ")
            .Append(" A.PARTYNAME AS [Party Name], ")
            .Append(" A.ITEMNAME AS [Quality Name], ")
            .Append(" A.DESIGNNO AS [Design No], ")
            .Append(" A.SHADENO AS [Shade No], ")
            .Append(" a.FD_PD as FdPd, ")
            .Append(" a.Flag, ")
            .Append(" A.FACTORYNAME AS [Factory Name], ")
            .Append(" A.SALES_PARTYNAME AS [Sales Party Name], ")
            .Append(" A.ACOFNAME AS [Ac Of Name], ")
            .Append(" A.BookName as GreyBookName, ")

            .Append(" (Z.P_CHALLANDATE) AS [Process Chl-Date], ")
            .Append(" Z.P_ENTRYNO AS [Process Entry No] ,")
            .Append(" Z.P_CHALLANNO AS [Proc-Chl-No], ")
            .Append(" Z.RecBookName  ")


            .Append(" FROM ")
            .Append(" ( ")

            .Append(" SELECT A.GREY_DESP_PCS_ID, A.PIECENO , A.BEAMNO AS G_BEAMNO, ")
            .Append(" A.CHALLANNO AS G_CHALLAN_NO, A.CHALLANDATE AS G_CHALLANDATE, ")
            .Append(" A.ENTRYNO AS G_ENTRYNO, A.SRNO AS G_SRNO, A.GMTR,A.WEIGHT, ")
            .Append(" A.PCAVGWT, A.PICK, ")
            .Append(" B.ACCOUNTNAME AS PARTYNAME, G.ACCOUNTNAME AS PROCESSNAME, ")
            .Append(" C.ITENNAME AS ITEMNAME, D.Design_Name AS DESIGNNO, ")
            .Append(" E.SHADE AS SHADENO,H.ACCOUNTNAME AS FACTORYNAME, ")
            .Append(" I.ACCOUNTNAME AS SALES_PARTYNAME,J.AC_NAME AS ACOFNAME ")
            .Append(" ,K.BookName ")
            .Append(" ,a.FD_PD ")
            .Append(" ,A.Flag ")
            .Append(" FROM TRNGREYDESP AS A, MstMasterAccount AS B, ")
            .Append(" MSTFABRICITEM AS C, Mst_Fabric_Design AS D, ")
            .Append(" Mst_Fabric_Shade AS E, MstMasterAccount AS G,MstMasterAccount H,MstMasterAccount I,Mst_Acof_Supply J ")
            .Append(" ,MstBook as K ")
            .Append(" WHERE 1=1 ")
            .Append(Search_Filter_String)
            .Append(" AND A.PROCESSCODE=G.ACCOUNTCODE And A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.FABRIC_ITEMCODE=C.ID And A.FABRIC_DESIGNCODE=D.Design_code ")
            .Append(" AND A.FACTORYCODE=H.ACCOUNTCODE AND A.SALES_ACCOUNTCODE=I.ACCOUNTCODE ")
            .Append(" AND A.FABRIC_SHADECODE=E.ID AND A.ACOFCODE=J.ID ")
            .Append(" AND A.BOOKCODE=K.BOOKCODE ")


            .Append(" ) ")
            .Append(" AS A ")
            .Append(" LEFT JOIN ")
            .Append(" ( ")
            .Append(" SELECT A.PIECENO AS P_PIECENO,A.CHALLANNO AS P_CHALLANNO,A.GMTR,A.PMTR, ")
            .Append(" A.SHK_MTR,A.SHK_PER,A.ENTRYNO AS P_ENTRYNO, ")
            .Append(" A.CHALLANDATE AS P_CHALLANDATE,A.GREY_DESP_PCS_ID,B.BOOKNAME AS RecBookName FROM TRNFINISHRCPT AS A ,MstBook AS B WHERE  A.BOOKCODE=B.BOOKCODE ")
            .Append(" ) ")
            .Append(" AS Z ")
            .Append(" ON ")
            .Append(" A.GREY_DESP_PCS_ID=Z.GREY_DESP_PCS_ID  ")
            .Append(" ORDER BY A.GREY_DESP_PCS_ID,A.PIECENO,Z.P_PIECENO,Z.P_CHALLANDATE ")
        End With
        Return _strQuery.ToString
    End Function
#End Region


#Region "Pending Offer Query "

    Public Function Get_Pending_Offer_Qry_For_Offer_Data_Finish(ByVal Book_Code As String, ByVal Filter_Condition_Cut As String, ByVal Rpt_Type As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal BookVno_Filter_String As String, ByVal LessBy As String, ByVal AbvDays As Integer, ByVal FabGrouppFilter_packing As String, ByVal Last_Clicked_Btn As Integer) As String
        Dim CurDate As String = ObjCls_General.GetTodayDate_SqlFormat
        _strQuery = New StringBuilder
        With _strQuery
            If LessBy = "INVOICE" Then
                .Append(" SELECT ")
                .Append(" DATEDIFF(DAY,A.OfferDate,'" & CurDate & "') AS DUEDAYS, ")
                .Append(" SPACE(1000) AS REMARK,A.OfferDate, ")
                .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
                .Append(" (A.OfferDate) as F_OFFERDATE, A.PartyOfferNo, ")
                .Append(" A.ACOFCODE, A.AgentOfferNo, A.AccountCode, ")
                .Append(" A.TransportCode, A.DespatchCode, A.HeaderRemark, ")
                .Append(" A.ItemCode, A.CutCode,'' as DesignCode, ")
                .Append(" '' as ShadeCode, sum(A.Mtr_Weight) as Mtr_Weight,  ")
                .Append(" A.Rate,SUM(A.cancel_Qty) AS cancel_Qty, ")
                .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as Offer_Qty, ")
                .Append(" (0.0) AS Inv_Qty, ")
                .Append(" (0.0) AS ORDER_QTY, ")
                .Append(" (0.0) AS DESPATCH_QTY, ")
                .Append(" (0.0) AS BALANCE_QTY, ")
                .Append(" (0.0) AS PCS, ")
                .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as bal_qty, ")
                .Append(" A.clear, A.LOTNO, ")
                .Append(" B.cityname AS DESPATCH, ")
                .Append(" '' AS DESIGNNO,  ")
                .Append(" D.ITENNAME AS ITEMNAME, ")
                .Append(" E.ACCOUNTNAME, ")
                .Append(" '' AS SHADENO, ")
                .Append(" I.TransportName, ")
                .Append(" J.accountname as agentname, ")
                .Append(" K.AC_NAME AS AcOfName, ")
                .Append(" L.CUTNAME ")
                .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
                .Append(" ,A.AgentOfferNo AS PRINT_NARR")
                .Append(" FROM  ")
                .Append(" TRNOFFER A,MSTCITY B,MSTFABRICITEM D,MstMasterAccount E,")
                .Append(" MSTTRANSPORT I,MstMasterAccount J,Mst_Acof_Supply K,MstCutMaster L ")
                .Append(" WHERE 1=1  ")
                If Rpt_Type = "PENDING" Then
                    .Append(" AND A.CLEAR<>'YES' ")
                End If
                If AbvDays > 0 Then
                    .Append("AND DATEDIFF(DAY,A.OfferDate,'" & CurDate & "')>" & AbvDays & " ")
                End If
                .Append(" AND A.DESPATCHCODE=B.CITYCODE  ")
                .Append(" AND A.ITEMCODE=D.ID ")
                .Append(" AND A.ACCOUNTCODE=E.ACCOUNTCODE ")
                .Append(" AND A.TRANSPORTCODE=I.ID ")
                .Append(" AND E.AGENTCODE=J.ACCOUNTCODE ")
                .Append(" AND A.ACOFCODE=K.ID ")
                .Append(" AND A.CUTCODE=L.ID ")
                .Append(Filter_Condition_Cut)
                .Append(" AND A.BOOKCODE='" & Book_Code & "' ")
                .Append(" AND A.OFFERDATE>='" & Start_Dt & "'  AND A.OFFERDATE<='" & End_Dt & "' ")
                .Append(BookVno_Filter_String)
                .Append(FabGrouppFilter_packing)
                .Append(" GROUP BY ")
                .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
                .Append(" a.total_qty,A.PartyOfferNo, ")
                .Append(" A.ACOFCODE, A.AgentOfferNo, A.AccountCode, ")
                .Append(" A.TransportCode, A.DespatchCode, A.HeaderRemark, ")
                .Append(" A.ItemCode, A.CutCode, ")
                .Append(" A.Rate, ")
                .Append(" A.RowRemark, ")
                .Append(" A.clear, A.LOTNO, ")
                .Append(" B.cityname, ")
                .Append(" D.ITENNAME, ")
                .Append(" E.ACCOUNTNAME, ")
                .Append(" I.TransportName, ")
                .Append(" J.accountname, ")
                .Append(" K.AC_NAME , ")
                .Append(" L.CUTNAME ")
                .Append(" ,A.PartyOfferNo  ")
                .Append(" ,A.AgentOfferNo  ")
                .Append(" ORDER BY A.ENTRYNO ")
            Else
                .Append(" SELECT ")
                .Append(" A.RowRemark AS REMARK, ")
                .Append(" A.OfferDate, ")
                .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
                .Append(" (A.OfferDate) as F_OFFERDATE, A.PartyOfferNo, ")
                .Append(" A.ACOFCODE, A.AgentOfferNo, A.AccountCode, ")
                .Append(" A.TransportCode, A.DespatchCode, A.HeaderRemark, ")
                .Append(" A.ItemCode, A.CutCode,A.DesignCode, ")
                .Append("  sum(A.Mtr_Weight) as Mtr_Weight,  ")
                .Append(" A.Rate,SUM(A.cancel_Qty) AS cancel_Qty, ")
                .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as Offer_Qty, ")
                .Append(" (0.00) AS Inv_Qty, ")
                .Append(" (0.00) AS ORDER_QTY, ")
                .Append(" (0.00) AS DESPATCH_QTY, ")
                .Append(" (0.00) AS BALANCE_QTY, ")
                .Append(" (0.00) AS PCS, ")
                .Append(" (0.00) AS DEBITAMT, ")
                .Append(" (0.00) AS CREDITAMT, ")
                .Append(" (0.00) AS BALANCE, ")
                .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as bal_qty, ")
                .Append(" A.clear, A.LOTNO, ")
                .Append(" B.cityname AS DESPATCH, ")
                .Append(" C.Design_Name AS DESIGNNO,  ")
                .Append(" D.ITENNAME AS ITEMNAME, ")
                .Append(" E.ACCOUNTNAME, ")
                .Append(" '' AS ROWREMARK, ")
                .Append(" A.ShadeCode,H.SHADE AS SHADENO, ")
                .Append(" I.TransportName, ")
                .Append(" J.accountname as agentname, ")
                .Append(" K. AC_NAME AS AcOfName, ")
                .Append(" L.CUTNAME ")
                .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
                .Append(" ,A.AgentOfferNo AS PRINT_NARR")
                .Append(" ,'' AS BRANCH") ' LOCATION
                .Append(" ,'' AS LIA_GROUPNAME") ' GRADING PCS AND MTR
                .Append(" FROM  ")
                .Append(" TRNOFFER A,MSTCITY B,Mst_Fabric_Design C,MSTFABRICITEM D,MstMasterAccount E,")
                .Append(" MSTTRANSPORT I,MstMasterAccount J,Mst_Acof_Supply K,MstCutMaster L ")
                .Append(" ,Mst_Fabric_Shade H  ")

                .Append(" WHERE 1=1  ")
                If Rpt_Type = "PENDING" Then
                    .Append(" AND A.CLEAR<>'YES' ")
                End If
                .Append(" AND A.DESPATCHCODE=B.CITYCODE  ")
                .Append(" AND A.DESIGNCODE=C.Design_code ")
                .Append(" AND A.ITEMCODE=D.ID ")
                .Append(" AND A.ACCOUNTCODE=E.ACCOUNTCODE ")
                .Append(" AND A.SHADECODE=H.ID ")
                .Append(" AND A.TRANSPORTCODE=I.ID ")
                .Append(" AND E.AGENTCODE=J.ACCOUNTCODE ")
                .Append(" AND A.ACOFCODE=K.ID ")
                .Append(" AND A.CUTCODE=L.ID ")
                .Append(Filter_Condition_Cut)
                .Append(" AND A.BOOKCODE='" & Book_Code & "' ")
                .Append(" AND A.OFFERDATE>='" & Start_Dt & "'  AND A.OFFERDATE<='" & End_Dt & "' ")
                .Append(BookVno_Filter_String)
                .Append(" GROUP BY ")
                .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
                .Append(" a.total_qty,A.PartyOfferNo, ")
                .Append(" A.ACOFCODE, A.AgentOfferNo, A.AccountCode, ")
                .Append(" A.TransportCode, A.DespatchCode, A.HeaderRemark, ")
                .Append(" A.ItemCode, A.CutCode, ")
                .Append(" A.DesignCode, A.Rate, ")
                .Append(" A.RowRemark, ")
                .Append(" A.clear, A.LOTNO, ")
                .Append(" B.cityname, ")
                .Append(" C.Design_Name,  ")
                .Append(" D.ITENNAME, ")
                .Append(" E.ACCOUNTNAME, ")
                .Append(" A.ShadeCode,H.SHADE, ")
                .Append(" I.TransportName, ")
                .Append(" J.accountname, ")
                .Append(" K.AC_NAME, ")
                .Append(" L.CUTNAME ")
                .Append(" ,A.PartyOfferNo  ")
                .Append(" ,A.AgentOfferNo  ")
                .Append(" ORDER BY A.ENTRYNO ")
            End If
        End With
        Return _strQuery.ToString
    End Function
    Public Function Get_Pending_Offer_Qry_For_Invoice_Data_Finish(ByVal Filter_Condition_Cut As String, ByVal Filter_Condition_P_Slip As String, ByVal OfferBkTrtypeFilter As String, ByVal LessBy As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            If LessBy = "INVOICE" Then
                .Append(" SELECT ")
                .Append(" A.OFFERBOOKVNO, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" A.ITEMCODE,")
                .Append(" A.CUTCODE, ")
                .Append(" '' AS DESIGNCODE, ")
                .Append(" '' AS SHADECODE, ")
                .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, ")
                .Append(" SUM(A.PCS) AS PCS ")
                .Append(" FROM ")
                .Append(" TRNINVOICEDETAIL A ")
                .Append(" WHERE 1=1 ")
                .Append(OfferBkTrtypeFilter)
                .Append(Filter_Condition_Cut)
                .Append(Filter_Condition_P_Slip)
                .Append(" AND A.OFFERBOOKVNO IS NOT NULL AND A.OFFERBOOKVNO<>'' ")
                .Append(" GROUP BY ")
                .Append(" A.BOOKVNO,A.OFFERBOOKVNO,A.ACCOUNTCODE,A.ITEMCODE, ")
                .Append(" A.CUTCODE ")
            Else
                .Append(" SELECT ")
                .Append(" A.OFFERBOOKVNO, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" A.ITEMCODE,")
                .Append(" A.CUTCODE, ")
                .Append(" A.DESIGNCODE, ")
                .Append(" A.SHADECODE, ")
                .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, ")
                .Append(" SUM(A.PCS) AS PCS ")
                .Append(" FROM ")
                .Append(" TRNPACKINGSLIP A ")
                .Append(" WHERE 1=1 ")
                .Append(Filter_Condition_Cut)
                .Append(Filter_Condition_P_Slip)
                .Append(" AND A.OFFERBOOKVNO IS NOT NULL AND A.OFFERBOOKVNO<>''")
                .Append(" GROUP BY ")
                .Append(" A.BOOKVNO,A.OFFERBOOKVNO,A.ACCOUNTCODE,A.ITEMCODE, ")
                .Append(" A.CUTCODE,A.DESIGNCODE,A.SHADECODE ")
            End If
        End With
        Return _strQuery.ToString
    End Function

    Public Function Get_Pending_Offer_Qry_For_Offer_Data_Yarn(ByVal Book_Code As String, ByVal Filter_Condition_Cut As String, ByVal Rpt_Type As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal BookVno_Filter_String As String, ByVal _ManualLotNo As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            Dim cudate As String = Format(Date.Now, "yyyy-MM-dd")

            .Append(" SELECT ")
            .Append(" A.BOOKVNO ")
            .Append(" ,A.ENTRYNO ")
            .Append(" ,A.OfferNo ")
            .Append(" ,format(A.OfferDate,'dd/MM/yyyy') as F_OFFERDATE ")
            .Append(" ,E.ACCOUNTNAME ")
            .Append(" ,D.COUNTNAME AS ITEMNAME ")
            .Append(" ,K.YARN_SHADE_NAME AS SHADENO ")
            .Append(" ,SUM(A.Mtr_Weight)-SUM(A.cancel_Qty) as Offer_Qty ")
            .Append(" ,(0.0) AS Inv_Qty ")
            .Append(" ,sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as bal_qty ")
            .Append(" ,A.Clear ")
            .Append(" ,A.OfferDate ")
            .Append(" ,SPACE(1000) AS REMARK ")
            '.Append(" ,A.BookVno ")
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")
            .Append(" ,A.AccountCode ")
            .Append(" ,A.HeaderRemark ")
            .Append(" ,A.ItemCode ")
            .Append(" ,SUM(A.Mtr_Weight) as Mtr_Weight  ")
            .Append(" ,A.Rate ")
            .Append(" ,SUM(A.cancel_Qty) AS cancel_Qty ")
            .Append(" ,SUM(A.cancel_Qty) AS BALES ")
            .Append(" ,(0.0) AS ORDER_QTY ")
            .Append(" ,(0.0) AS DESPATCH_QTY ")
            .Append(" ,(0.0) AS BALANCE_QTY ")
            .Append(" ,(0.0) AS BALANCE ")
            .Append(" ,(0.0) AS PCS ")
            .Append(" ,A.clear as state ")
            .Append(" ,A.LOTNO ")
            .Append(" ,J.accountname as agentname")
            .Append(" , '' AS  BILLNO")
            .Append(" , '' AS ACOFNAME")
            .Append(" ,DATEDIFF(DAY,A.OfferDate,'" & cudate & "') AS day1  ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,0.000 AS TOTALAMOUNT ")
            '.Append(" ,'' as BILLNO ")
            .Append(" ,'' as BILLDATE ")
            .Append(" ,A.PartyOfferNo as SUPPNAME ")
            .Append(" ,L.ACCOUNTNAME AS SUPPLIER_NAME")
            .Append(" FROM  ")
            .Append(" TRNOFFER A,MSTYARNCOUNT D,MstMasterAccount E,")
            .Append(" MstMasterAccount J ")
            .Append(" ,MstYarnItemShade K ")
            .Append(" ,MstMasterAccount L ")

            .Append(" WHERE 1=1  ")
            If Rpt_Type = "PENDING" Then
                .Append(" AND A.CLEAR<>'YES' ")
            End If
            If _ManualLotNo > "" Then
                .Append(" AND A.YARN_LOT_NO='" & _ManualLotNo & "'")
            End If
            .Append(" AND A.ITEMCODE=D.COUNTCODE ")
            .Append(" AND A.ACCOUNTCODE=E.ACCOUNTCODE ")
            .Append(" AND A.SELVCODE=L.ACCOUNTCODE ")
            .Append(" AND E.AGENTCODE=J.ACCOUNTCODE ")
            .Append(" AND A.ShadeCode=K.ID ")

            .Append(" AND A.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND A.OFFERDATE>='" & Start_Dt & "'  AND A.OFFERDATE<='" & End_Dt & "' ")
            .Append(BookVno_Filter_String)
            .Append(" GROUP BY ")
            .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
            .Append(" a.total_qty,A.PartyOfferNo, ")
            .Append(" A.AgentOfferNo, A.AccountCode, ")
            .Append("  A.HeaderRemark, ")
            .Append(" A.ItemCode, ")
            .Append(" A.Rate, ")
            .Append(" A.RowRemark, ")
            .Append(" A.clear, A.LOTNO, ")
            .Append(" D.COUNTNAME, ")
            .Append(" E.ACCOUNTNAME, ")
            .Append(" J.accountname ")
            .Append(" ,K.YARN_SHADE_NAME ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,A.PartyOfferNo ")
            .Append(" ,L.ACCOUNTNAME ")
            '.Append(" ORDER BY A.ENTRYNO ")
            .Append(" ORDER BY A.OfferDate,A.ENTRYNO, D.COUNTNAME,E.ACCOUNTNAME,L.ACCOUNTNAME ")
        End With
        Return _strQuery.ToString
    End Function
    Public Function Get_Pending_Offer_Qry_For_Offer(ByVal Book_Code As String, ByVal Filter_Condition_Cut As String, ByVal Rpt_Type As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal BookVno_Filter_String As String, ByVal Order_By As String, ByVal _ManualLotNo As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            Dim cudate As String = Format(Date.Now, "yyyy-MM-dd")

            .Append(" SELECT ")
            .Append(" SPACE(1000) AS REMARK,A.OfferDate, ")
            .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
            .Append(" format(A.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, A.PartyOfferNo, ")
            .Append(" A.AgentOfferNo, A.AccountCode, ")
            .Append(" A.HeaderRemark, ")
            .Append(" A.ItemCode, ")
            .Append(" SUM(A.Mtr_Weight) as Mtr_Weight,  ")
            .Append(" A.Rate,SUM(A.cancel_Qty) AS cancel_Qty, ")
            .Append(" SUM(A.Mtr_Weight)-SUM(A.cancel_Qty) as Offer_Qty, ")
            .Append(" (0.0) AS Inv_Qty, ")
            .Append(" (0.0) AS ORDER_QTY, ")
            .Append(" (0.0) AS DESPATCH_QTY, ")
            .Append(" (0.0) AS BALANCE_QTY, ")
            .Append(" (0.0) AS PCS, ")
            .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as bal_qty, ")
            .Append(" A.clear, A.LOTNO, ")
            .Append(" D.COUNTNAME AS ITEMNAME, ")
            .Append(" E.ACCOUNTNAME, ")
            .Append(" J.accountname as agentname, '' AS  BILLNO, '' AS ACOFNAME,")
            .Append(" DATEDIFF(DAY,A.OfferDate,'" & cudate & "') AS day1  ")

            .Append(" ,K.YARN_SHADE_NAME AS SHADENO ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,0.000 AS TOTALAMOUNT ")
            .Append(" ,'' as BILLNO ")
            .Append(" ,'' as BILLDATE ")
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")

            .Append(" FROM  ")
            .Append(" TRNOFFER A,MSTYARNCOUNT D,MstMasterAccount E,")
            .Append(" MstMasterAccount J ")
            .Append(" ,MstYarnItemShade K ")



            .Append(" WHERE 1=1  ")
            If Rpt_Type = "PENDING" Then
                .Append(" AND A.CLEAR<>'YES' ")
            End If
            If _ManualLotNo > "" Then
                .Append(" AND A.YARN_LOT_NO='" & _ManualLotNo & "'")
            End If
            .Append(" AND A.ITEMCODE=D.COUNTCODE ")
            .Append(" AND A.ACCOUNTCODE=E.ACCOUNTCODE ")
            .Append(" AND E.AGENTCODE=J.ACCOUNTCODE ")
            .Append(" AND A.ShadeCode=K.ID ")

            .Append(" AND A.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND A.OFFERDATE>='" & Start_Dt & "'  AND A.OFFERDATE<='" & End_Dt & "' ")
            .Append(BookVno_Filter_String)
            .Append(" GROUP BY ")
            .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
            .Append(" a.total_qty,A.PartyOfferNo, ")
            .Append(" A.AgentOfferNo, A.AccountCode, ")
            .Append("  A.HeaderRemark, ")
            .Append(" A.ItemCode, ")
            .Append(" A.Rate, ")
            .Append(" A.RowRemark, ")
            .Append(" A.clear, A.LOTNO, ")
            .Append(" D.COUNTNAME, ")
            .Append(" E.ACCOUNTNAME, ")
            .Append(" J.accountname ")
            .Append(" ,K.YARN_SHADE_NAME ")
            .Append(" ,A.ShadeCode ")
            .Append(" ORDER BY " & Order_By)
        End With
        Return _strQuery.ToString
    End Function
    Public Function Get_Pending_Offer_Qry_For_Invoice_Yarn_detail(ByVal Offer_Nature As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.OFFERBOOKVNO, ")
            .Append(" A.OFFERBOOKVNO as BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" C.CountName AS ITEMNAME, ")
            .Append(" K.YARN_SHADE_NAME AS SHADENO, ")
            .Append(" A.ShadeCode, ")
            .Append(" SUM(A.MTR_WEIGHT) AS Inv_Qty, ")
            .Append(" SUM(A.PCS) AS PCS,A.RATE,A.BILLNO, B.ACCOUNTNAME,format(A.BILLDATE,'dd/MM/yyyy') as BILLDATE ")

            .Append(" ,0.0 AS Offer_Qty ")
            .Append(" ,0.0 AS BALANCE_QTY ")

            .Append(" FROM ")
            .Append(" TRNINVOICEDETAIL A,MstMasterAccount B ")
            .Append(" ,MstYarnItemShade K ")
            .Append(" ,MstYarnCount c ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.OFFERBOOKVNO IS NOT NULL AND A.OFFERBOOKVNO<>''")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE")
            .Append(" AND A.ShadeCode=K.ID ")
            .Append(" AND A.ITEMCODE=C.CountCode ")
            .Append(" GROUP BY ")
            .Append(" A.BOOKCODE,A.OFFERBOOKVNO,A.ACCOUNTCODE,A.ITEMCODE,A.RATE ,A.BILLNO, B.ACCOUNTNAME,A.BILLDATE ")
            .Append(" ,K.YARN_SHADE_NAME ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,C.CountName ")

            If Offer_Nature = "PURCHASE" Then
                .Append(" HAVING ")
                .Append(" A.BOOKCODE='0001-000000043' ")
                .Append(" OR A.BOOKCODE='0001-000000044' ")
                .Append(" OR A.BOOKCODE='0001-000000045' ")
                .Append(" OR A.BOOKCODE='0001-000000220' ")
                .Append(" OR A.BOOKCODE='0001-000000779' ")
            ElseIf Offer_Nature = "SALES" Then
                .Append(" HAVING ")
                .Append(" A.BOOKCODE='0001-000000037' ")
                .Append(" OR A.BOOKCODE='0001-000000038' ")
                .Append(" OR A.BOOKCODE='0001-000000039' ")
                .Append(" OR A.BOOKCODE='0001-000000221' ")
                .Append(" OR A.BOOKCODE='0001-000000778' ")
            End If
        End With
        Return _strQuery.ToString

    End Function
    Public Function Get_Pending_Offer_Qry_For_Invoice_Data_Yarn(ByVal Offer_Nature As String, ByVal _ManualLotNo As String) As String
        _strQuery = New StringBuilder
        'Dim cudate As String = Format(Date.Now, "yyyy-MM-dd")

        With _strQuery
            .Append(" SELECT ")
            .Append(" A.OFFERBOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.PCS) AS PCS,A.RATE,A.BILLNO, B.ACCOUNTNAME AS ACOFNAME,A.BILLDATE ")
            '.Append(" ,DATEDIFF(DAY,A.OfferDate,'" & cudate & "') AS day1  ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,C.YARN_SHADE_NAME ")
            .Append(" FROM ")
            .Append(" TRNINVOICEDETAIL A")
            .Append(" Left JOIN MstMasterAccount B ON A.factorycode=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstYarnItemShade as C ON A.ShadeCode=C.ID")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.OFFERBOOKVNO IS NOT NULL AND A.OFFERBOOKVNO<>''")
            .Append(" GROUP BY ")
            .Append(" A.BOOKCODE,A.OFFERBOOKVNO,A.ACCOUNTCODE,A.ITEMCODE,A.RATE ,A.BILLNO, B.ACCOUNTNAME,A.BILLDATE ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,C.YARN_SHADE_NAME ")
            If Offer_Nature = "PURCHASE" Then
                .Append(" HAVING ")
                .Append(" ( A.BOOKCODE='0001-000000043' ")
                .Append(" OR A.BOOKCODE='0001-000000044' ")
                .Append(" OR A.BOOKCODE='0001-000000045' ")
                .Append(" OR A.BOOKCODE='0001-000000220' ")
                .Append(" OR A.BOOKCODE='0001-000000779' ")
                .Append(" OR A.BOOKCODE='0001-000000635' ")
                .Append(" ) ")
            ElseIf Offer_Nature = "SALES" Then
                .Append(" HAVING ")
                .Append(" ( A.BOOKCODE='0001-000000037' ")
                .Append(" OR A.BOOKCODE='0001-000000038' ")
                .Append(" OR A.BOOKCODE='0001-000000039' ")
                .Append(" OR A.BOOKCODE='0001-000000221' ")
                .Append(" OR A.BOOKCODE='0001-000000778' ")
                .Append(" OR A.BOOKCODE='0001-000000603' ")
                .Append(" ) ")
            End If
        End With
        Return _strQuery.ToString
    End Function

    Public Function CLEARLIST_Get_Pending_Offer_Invoice_Data_Yarn(ByVal Offer_Nature As String, ByVal _ManualLotNo As String) As String
        _strQuery = New StringBuilder
        'Dim cudate As String = Format(Date.Now, "yyyy-MM-dd")

        With _strQuery
            .Append(" SELECT ")
            .Append(" A.OFFERBOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.PCS) AS PCS, B.ACCOUNTNAME AS ACOFNAME")
            '.Append(" ,DATEDIFF(DAY,A.OfferDate,'" & cudate & "') AS day1  ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,C.YARN_SHADE_NAME ")
            .Append(" FROM ")
            .Append(" TRNINVOICEDETAIL A,MstMasterAccount B ")
            .Append(" ,MstYarnItemShade as C ")

            .Append(" WHERE 1=1 ")

            .Append(" AND A.OFFERBOOKVNO IS NOT NULL AND A.OFFERBOOKVNO<>''")
            .Append(" AND A.factorycode=B.ACCOUNTCODE")
            .Append(" AND A.ShadeCode=C.ID")

            .Append(" GROUP BY ")
            .Append(" A.BOOKCODE,A.OFFERBOOKVNO,A.ACCOUNTCODE,A.ITEMCODE, B.ACCOUNTNAME ")
            .Append(" ,A.ShadeCode ")
            .Append(" ,C.YARN_SHADE_NAME ")
            If Offer_Nature = "PURCHASE" Then
                .Append(" HAVING ")
                .Append(" A.BOOKCODE='0001-000000043' ")
                .Append(" OR A.BOOKCODE='0001-000000044' ")
                .Append(" OR A.BOOKCODE='0001-000000045' ")
                .Append(" OR A.BOOKCODE='0001-000000220' ")
                .Append(" OR A.BOOKCODE='0001-000000779' ")
            ElseIf Offer_Nature = "SALES" Then
                .Append(" HAVING ")
                .Append(" A.BOOKCODE='0001-000000037' ")
                .Append(" OR A.BOOKCODE='0001-000000038' ")
                .Append(" OR A.BOOKCODE='0001-000000039' ")
                .Append(" OR A.BOOKCODE='0001-000000221' ")
                .Append(" OR A.BOOKCODE='0001-000000778' ")
            End If
        End With
        Return _strQuery.ToString
    End Function

    Public Function Get_Pending_Offer_Qry_For_Offer_Selection_Qry(ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal RptType As String) As String

        Dim Date_Filter_Condition_String As String = ""
        Date_Filter_Condition_String = " AND A.OFFERDATE>='" & Start_Dt & "'  AND A.OFFERDATE<='" & End_Dt & "' "
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append(" A.OFFERNO +'/'+  B.ACCOUNTNAME AS [Party Name], ")
            .Append(" (A.OFFERDATE) AS [Offer Date], ")
            .Append("  A.BOOKVNO,A.BOOKVNO,A.BOOKVNO ")
            .Append(" FROM TRNOFFER A,MstMasterAccount B ")
            .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.BOOKCODE='" & Book_Code & "' ")
            If RptType = "PENDING" Then
                .Append(" AND A.CLEAR<>'YES' ")
            End If
            .Append(Date_Filter_Condition_String)
            .Append(" GROUP BY A.ENTRYNO,A.BOOKVNO,A.OFFERNO,A.OFFERDATE,B.ACCOUNTNAME ")
            .Append(" ORDER BY A.ENTRYNO ")
        End With


        sqL = _strQuery.ToString
        MULTI_SELECTION_GRID_SETTING()



        Return _strQuery.ToString
    End Function
#End Region

#Region "Pending Offer Query "
    Public Function Get_Pending_Offer_Qry_For_Balance_CF_SQL(ByVal Start_Dt As String, ByVal End_Dt As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.PROCESSCODE,A.DELVDAYS,A.WEAVETYPECODE,A.LOOMTYPECODE,A.SELVCODE, ")
            .Append(" A.SALESMANCODE,A.REED,A.DENT,A.REEDSPACE,A.WESTAGE,A.LENGTH, ")
            .Append(" A.NO_OF_SET,A.NO_OF_BEAM,A.TOTAL_QTY,A.PAYMENT_DAYS,A.YARN_DETAIL, ")
            .Append(" A.AGENTCODE,A.PICK_RATE,A.MENDING_CHG,A.EXTRA_CHG,A.LOOM_TYPE, ")
            .Append(" A.MONOGRAM_TYPE,A.Gross_Rate,A.Rate_Dis_Per,A.Net_Rate, ")
            .Append(" A.ITEMGROUPCODE,A.Process_Net_Rate,A.Process_Weight_Range, ")
            .Append(" A.Process_Weight_Rate,A.Process_Slab_Weight, ")
            .Append(" A.Process_Slab_Rate,A.agentaccountcode, ")
            .Append(" A.BOOKCODE,A.BOOKTRTYPE,A.YARN_LOT_NO,A.YARN_SHADE_NO, ")
            .Append(" A.RDVALUE, A.RDON, A.CDVALUE, A.CDON, ")
            .Append(" A.TERM1,A.TERM2,A.TERM3,A.TERM4,A.LOOMTYPE,A.WEAVETYPE, ")
            .Append(" A.AVGWEIGHT,A.SELVEDGENAME,A.PYMTDAYS, ")
            .Append(" '' AS REMARK,A.OfferDate, ")
            .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
            .Append(" A.AGENTOFFERNO,A.PartyOfferNo, ")
            .Append(" A.ACOFCODE, A.AgentOfferNo, A.AccountCode, ")
            .Append(" A.TransportCode, A.DespatchCode, A.HeaderRemark, ")
            .Append(" A.ItemCode, A.CutCode,A.DesignCode, ")
            .Append(" A.ShadeCode, sum(A.Mtr_Weight) as Mtr_Weight, ")
            .Append(" A.Rate,SUM(A.cancel_Qty) AS cancel_Qty, ")
            .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as Offer_Qty, ")
            .Append(" '0.00' AS Inv_Qty, ")
            .Append(" '0.00' AS ORDER_QTY, ")
            .Append(" '0.00' AS DESPATCH_QTY, ")
            .Append(" '0.00' AS BALANCE_QTY, ")
            .Append(" '0.00' AS PCS, ")
            .Append(" sum(A.Mtr_Weight)-SUM(A.cancel_Qty) as bal_qty, ")
            .Append(" A.clear, A.LOTNO, ")
            .Append(" B.cityname AS DESPATCH, ")
            .Append(" C.Design_Name AS DESIGNNO, ")
            .Append(" D.ITENNAME AS ITEMNAME, ")
            .Append(" E.ACCOUNTNAME, ")
            .Append(" H.SHADE AS SHADENO, ")
            .Append(" I.TransportName, ")
            .Append(" J.accountname as agentname, ")
            .Append(" K.AC_NAME, ")
            .Append(" L.CUTNAME ")
            .Append(" FROM  ")
            .Append(" TRNOFFER A,MSTCITY B,Mst_Fabric_Design C,MSTFABRICITEM D,MstMasterAccount E,")
            .Append(" Mst_Fabric_Shade H,MSTTRANSPORT I,MstMasterAccount J,Mst_Acof_Supply K,MstCutMaster L ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.CLEAR<>'YES' ")
            .Append(" AND A.DESPATCHCODE=B.CITYCODE  ")
            .Append(" AND A.DESIGNCODE=C.Design_code ")
            .Append(" AND A.ITEMCODE=D.ID ")
            .Append(" AND A.ACCOUNTCODE=E.ACCOUNTCODE ")
            .Append(" AND A.SHADECODE=H.Id ")
            .Append(" AND A.TRANSPORTCODE=I.ID ")
            .Append(" AND E.AGENTCODE=J.ACCOUNTCODE ")
            .Append(" AND A.ACOFCODE=K.ID ")
            .Append(" AND A.CUTCODE=L.ID ")
            .Append(" AND A.OFFERDATE>='" & Start_Dt & "'  AND A.OFFERDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY ")
            .Append(" A.PROCESSCODE,A.DELVDAYS,A.WEAVETYPECODE,A.LOOMTYPECODE,A.SELVCODE,  A.SALESMANCODE, ")
            .Append(" A.REED, A.DENT, A.REEDSPACE, A.WESTAGE, A.LENGTH, A.NO_OF_SET, A.NO_OF_BEAM, ")
            .Append(" A.TOTAL_QTY, A.PAYMENT_DAYS, A.YARN_DETAIL, A.AGENTCODE, A.PICK_RATE, ")
            .Append(" A.MENDING_CHG, A.EXTRA_CHG, A.LOOM_TYPE, A.MONOGRAM_TYPE, A.Gross_Rate, A.Rate_Dis_Per, ")
            .Append(" A.Net_Rate, A.ITEMGROUPCODE, A.Process_Net_Rate, A.Process_Weight_Range, ")
            .Append(" A.Process_Weight_Rate,A.Process_Slab_Weight, A.Process_Slab_Rate, A.agentaccountcode, ")
            .Append(" A.AGENTOFFERNO,A.BOOKCODE,A.BOOKTRTYPE,A.YARN_LOT_NO,A.YARN_SHADE_NO, ")
            .Append(" A.RDVALUE, A.RDON, A.CDVALUE, A.CDON, ")
            .Append(" A.TERM1,A.TERM2,A.TERM3,A.TERM4,A.LOOMTYPE,A.WEAVETYPE, ")
            .Append(" A.AVGWEIGHT,A.SELVEDGENAME,A.PYMTDAYS, ")
            .Append(" A.ENTRYNO, A.BookVno, A.OfferNo,A.OfferDate, ")
            .Append(" A.BOOKCODE,a.total_qty,A.PartyOfferNo, ")
            .Append(" A.ACOFCODE, A.AgentOfferNo, A.AccountCode, ")
            .Append(" A.TransportCode, A.DespatchCode, A.HeaderRemark, ")
            .Append(" A.ItemCode, A.CutCode, ")
            .Append(" A.DesignCode, A.ShadeCode,A.Rate, ")
            .Append(" A.RowRemark, ")
            .Append(" A.clear, A.LOTNO, ")
            .Append(" B.cityname, ")
            .Append(" C.Design_Name,  ")
            .Append(" D.ITENNAME, ")
            .Append(" E.ACCOUNTNAME, ")
            .Append(" H.SHADE, ")
            .Append(" I.TransportName, ")
            .Append(" J.accountname, ")
            .Append(" K.AC_NAME, ")
            .Append(" L.CUTNAME ")
            .Append(" ORDER BY A.ENTRYNO ")
        End With
        Return _strQuery.ToString
    End Function
    Public Function Get_Pending_Offer_Qry_For_Invoice_Data_Finish_SQL(ByVal Filter_Condition_Cut As String, ByVal Filter_Condition_P_Slip As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.OFFERBOOKVNO, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" A.ITEMCODE,")
            .Append(" A.CUTCODE, ")
            .Append(" A.DESIGNCODE, ")
            .Append(" A.SHADECODE, ")
            .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.MTR_WEIGHT) AS CONMTRWEIGHT, ")
            .Append(" SUM(A.PCS) AS CONPCS, ")
            .Append(" SUM(A.PCS) AS PCS ")
            .Append(" FROM ")
            .Append(" TRNPACKINGSLIP A ")
            .Append(" WHERE 1=1 ")
            .Append(Filter_Condition_Cut)
            .Append(Filter_Condition_P_Slip)
            .Append(" AND A.OFFERBOOKVNO IS NOT NULL AND A.OFFERBOOKVNO<>''")
            .Append(" GROUP BY ")
            .Append(" A.BOOKVNO,A.OFFERBOOKVNO,A.ACCOUNTCODE,A.ITEMCODE, ")
            .Append(" A.CUTCODE,A.DESIGNCODE,A.SHADECODE ")
        End With
        Return _strQuery.ToString
    End Function

#End Region

#Region " query"

    Public Function EntryData_Is_Adjusted_Invoice(ByVal _BookVNo As String, ByVal AccountCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT BOOKVNO,SUNCODE,SUM(ADJAMT) AS ADJAMT,COUNT(A.BOOKVNO) AS TOTAL_BOOK_VNO ,")
            .Append(" DATEDIFF(day,A.BILLDATE,A.INTADVISEDATE) AS PDAYS, ")
            .Append(" (SUM(A.CREDITAMT)) AS CREDITAMT, ")
            .Append(" (ABS(SUM(A.DEBITAMT)-SUM(A.CREDITAMT))) AS BALANCE ")
            .Append(" FROM trnoutstanding A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
            .Append(" AND A.BOOKVNO='" & _BookVNo & "' ")
            .Append(" AND A.SUNCODE<>'0001-000000046' ")
            .Append(" GROUP BY SUNCODE,BOOKVNO,INTADVISEDATE,BILLDATE ")
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_Yarn_Packing_Slip_View_Record(ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.entryno AS [Entry No], ")
            .Append(" A.PACK_SLIP_NO AS [P-Slip No], ")
            .Append(" (A.pack_slip_date)  as [P-Slip Date], ")
            .Append(" b.accountname as [Party Name], ")
            .Append(" c.AC_NAME as [Ac Of Name], ")
            .Append(" d.cityname as [Desp-City], ")
            .Append(" e.transportname as [Transport Name], ")
            .Append(" f.accountname as [Agent Name], ")
            .Append(" g.COUNTNAME as [Item Name], ")
            .Append(" sum(a.pcs) as [Bags], ")
            .Append(" sum(a.mtr_weight) as [Weight], ")
            .Append(" a.rate as [Rate], ")
            .Append(" sum(a.amount) as [Amount] ")
            .Append(" from trnpackingslip a,MstMasterAccount b,Mst_Acof_Supply c,mstcity d, ")
            .Append(" msttransport e,MstMasterAccount f,mstyarncount g ")
            .Append(" WHERE 1=1 ")
            .Append(" and a.accountcode = b.accountcode ")
            .Append(" and a.acofcode = c.id ")
            .Append(" and a.despatchcode = d.citycode ")
            .Append(" and b.agentcode = f.accountcode ")
            .Append(" and a.transportcode = e.id ")
            .Append(" and a.itemcode = g.countcode ")
            .Append(View_Filter_Condition)
            .Append(" group by  ")
            .Append(" a.entryno,A.BOOKVNO,A.PACK_SLIP_NO ,A.pack_slip_date,")
            .Append(" b.accountname, c.AC_NAME, ")
            .Append(" d.cityname,e.transportname,f.accountname,g.countname, ")
            .Append(" a.rateon,a.rate ")
            .Append(View_Order_By)
        End With

        Return strQuery.ToString

    End Function
    Public Function EntryData_FinishPackingSlip_View_Record(ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.entryno AS [Entry No], ")
            .Append(" A.PACK_SLIP_NO AS [P-Slip No], ")
            .Append(" (A.pack_slip_date)  as [P-Slip Date], ")
            .Append(" b.accountname as [Party Name], ")
            .Append(" c.AC_NAME as [Ac Of Name], ")
            .Append(" d.cityname as [Despatch], ")
            .Append(" e.transportname as [Transport Name], ")
            .Append(" f.accountname as [Agent Name], ")
            .Append(" sum(a.pcs) as [Pcs], ")
            .Append(" sum(a.mtr_weight) as [Meters], ")
            .Append(" sum(a.amount) as [Amount], ")
            .Append(" a.bale_weight as [Bale Kgs] ")
            .Append(" from trnpackingslip a,MstMasterAccount b,Mst_Acof_Supply c,mstcity d, ")
            .Append(" msttransport e,MstMasterAccount f ")
            .Append(" WHERE 1=1 ")
            .Append(" and a.accountcode = b.accountcode ")
            .Append(" and a.acofcode = c.id ")
            .Append(" and a.despatchcode = d.citycode ")
            .Append(" and b.agentcode = f.accountcode ")
            .Append(" and a.transportcode = e.id ")
            .Append(View_Filter_Condition)
            .Append(" group by  ")
            .Append(" a.entryno,A.BOOKVNO,A.PACK_SLIP_NO ,A.pack_slip_date,b.accountname,c.AC_NAME, ")
            .Append(" d.cityname,e.transportname,f.accountname, ")
            .Append(" a.bale_weight ")
            .Append(View_Order_By)
        End With
        Return strQuery.ToString
    End Function

#Region "Get Opening Total Debit And Credit Total Qry "
    Public Function Get_Total_Debit_Opening_balance() As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT (SUM(A.DEBITAMT)-SUM(A.CREDITAMT)) AS BALANCE, ")
            .Append(" case when (SUM(A.DEBITAMT)>SUM(A.CREDITAMT) ) THEN 'Dr' ELSE 'Cr' END AS DRCR  ")
            '.Append(" D.SCHEDULENAME ")
            .Append(" FROM TRNLEDGER AS A, MstMasterAccount AS B, MSTFINGROUP AS C, MSTFINSCHEDULE AS D ")
            .Append(" WHERE A.ACCOUNTCODE=B.ACCOUNTCODE And B.GROUPCODE=C.GROUPCODE ")
            .Append(" And C.SCHEDULECODE=D.SrNo And A.BOOKCODE='0000-000000001' ")
            '.Append(" GROUP BY D.SCHEDULENAME ")
        End With
        Return strQuery.ToString
    End Function
#End Region

    Public Function EntryData_Get_Help_Qry(ByVal _BookCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT a.bookvno, ")
            .Append(" a.billno as [Bill No], ")
            .Append(" a.entryno as [Entry No], ")
            .Append(" (a.billdate) as [Bill Date], ")
            .Append(" b.accountname as [Party Name], ")
            .Append(" (a.net_amount) as [Bill Amount] ")
            .Append(" FROM trninvoiceheader a,MstMasterAccount b ")
            .Append(" WHERE 1=1 and a.accountcode=b.accountcode  ")
            .Append(" AND a.bookcode='" & _BookCode & "' ")
            .Append(" ORDER BY  a.billdate,(a.billno) ")
        End With
        Return strQuery.ToString
    End Function
    Public Function Get_Help_Qry_Grey_Challan_Entry(ByVal _BookCode As String, ByVal BkCate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT a.bookvno, ")
            .Append(" a.cHALLANNO as [Challan No], ")
            .Append(" a.entryno as [Entry No], ")
            .Append(" (a.challandate) as [Bill Date], ")
            .Append(" b.accountname as [Party Name], ")
            .Append(" sum(a.gmtr) as [Total Mtrs] ")
            .Append(" FROM trnGreyDesp a,MstMasterAccount b ")
            .Append(" WHERE 1=1 ")
            If BkCate = "OWN" Then
                .Append(" and a.accountcode=b.accountcode ")
            ElseIf BkCate = "JOB" Then
                If _BookCode = "0001-000000104" Then
                    .Append(" and a.factorycode=b.accountcode ")
                Else
                    .Append(" and a.accountcode=b.accountcode ")
                End If
            ElseIf BkCate = "SALES" Then
                .Append(" and a.sales_accountcode=b.accountcode ")
            ElseIf BkCate = "PURC" Then
                .Append(" and a.sales_accountcode=b.accountcode ")
            Else
                .Append(" and a.sales_accountcode=b.accountcode ")
            End If
            .Append(" AND a.bookcode='" & _BookCode & "' ")
            .Append(" group by a.bookvno,a.entryno,a.challanno, ")
            .Append(" a.challandate,b.accountname ")
            .Append(" ORDER BY a.entryno ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_FinishInvoice_Challan_ShadeWiseShow(ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Book_Transaction_Type As String, ByVal BookCode As String, ByVal _GradingDispatchShowFlagWise As String) As String

        strQuery = New StringBuilder
        With strQuery

            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" Z.PACK_SLIP_NO AS CHALLANNO, ")
            .Append(" (Z.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
            .Append(" Z.CUTNAME, ")
            .Append(" Z.ITENNAME, ")
            .Append(" Z.PCS, ")
            .Append(" Z.MTR_WEIGHT, ")
            .Append(" CASE WHEN (Z.CUTTYPE='FENT') THEN Z.MTR_WEIGHT ELSE Z.WEIGHT END AS WEIGHT, ")
            .Append(" Z.AC_NAME, ")
            .Append(" Z.TRANSPORTNAME, ")
            .Append(" Z.RATEON, ")
            .Append(" Z.TRANSPORTCODE, ")
            .Append(" Z.ACOFCODE, ")
            .Append(" Z.CUTCODE, ")
            .Append(" Z.ITEMCODE, ")
            .Append(" Z.BOOKVNO, ")
            .Append(" Z.ACCOUNTCODE, ")
            .Append(" Z.DESPATCHCODE, ")
            .Append(" Z.ACCOUNTNAME, ")
            .Append(" Z.DESPATCH, ")
            .Append(" '' AS AGENTCODE, ")
            .Append(" '' AS AGENTNAME, ")
            .Append(" Z.RATE,")
            .Append(" Z.OFFERNO, ")
            .Append(" '' AS DESCR,Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.BALE_WEIGHT,Z.PARTYOFFERNO ")
            .Append(" ,Z.DESIGNCODE  ")
            .Append(" ,Z.SHADECODE  ")
            .Append(" ,Z.RETAILORNAME  ")
            .Append(" ,Z.FOLD  ")
            .Append(" ,Z.CUT_MTR")
            .Append(" ,Z.YARD")
            .Append(" ,'' AS PackingType")
            .Append(" ,Z.SHADECODE as ShadeNo  ") ' 37
            .Append(" ,Z.Design_Name as designno  ") '38
            .Append(" ,Z.TotalBale  ") '39

            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT A.BOOKCODE ,'' as DESIGNCODE ,H.SHADE  as SHADECODE   ,ITEMCODE1,A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, ")
            .Append("  SUM(A.PCS) AS PCS, ")
            .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT,A.RATEON, ")
            .Append(" A.ITEMCODE, A.CUTCODE, A.DESPATCHCODE,A.BALE_WEIGHT, ")
            .Append(" A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE, ")
            .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME,A.HEADERREMARK, ")
            .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.CDON AS RETAILORNAME,A.RDVALUE AS FOLD ")
            .Append(" ,SUM(a.CDVALUE) AS CUT_MTR")
            .Append(" ,ISNULL(SUM(a.AVG_WEIGHT),0) AS YARD")
            .Append(" ,I.Design_Name")
            .Append(" ,ISNULL(A.OP14,0) AS  TotalBale")
            .Append(" FROM ((((((TRNPACKINGSLIP AS A ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
            .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.ITEMCODE=C.ID) ")
            .Append(" LEFT JOIN MstCutMaster AS D ON A.CUTCODE=D.ID) ")
            .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
            .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
            .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID  ")
            .Append(" LEFT JOIN Mst_Fabric_Shade AS H ON A.SHADECODE =H.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design AS I ON A.DESIGNCODE =I.Design_code ")
            .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
            .Append(" And (CUTCODE1='' Or CUTCODE1 Is Null) And (ITEMCODE1='' Or ITEMCODE1 Is Null)  ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" GROUP BY A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, A.ITEMCODE, A.CUTCODE, ")
            .Append(" A.DESPATCHCODE, A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE,A.HEADERREMARK,A.BALE_WEIGHT, ")
            .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.PARTYOFFERNO ")
            .Append("   ,A.BOOKCODE  ,ITEMCODE1 ,A.CDON ,A.RDVALUE ,H.SHADE")
            .Append(" ,I.Design_Name")
            .Append(" ,A.OP14")
            .Append(" UNION ALL   ")
            .Append(" SELECT *  ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT A.BOOKCODE ,'' as DESIGNCODE ,H.SHADE  as SHADECODE    ,ITEMCODE1,A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, ")

            .Append(" (SUM(A.MTR_WEIGHT) / SUBSTRING(D.CUTNAME, PATINDEX('%[0-9]%', D.CUTNAME), LEN(D.CUTNAME))) AS PCS , ")
            .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT, A.RATEON, A.ITEMCODE1 AS   ")
            .Append(" ITEMCODE, A.CUTCODE1 AS CUTCODE, A.DESPATCHCODE,A.BALE_WEIGHT, A.ACCOUNTCODE, A.TRANSPORTCODE, ")
            .Append(" A.ACOFCODE, A.BOOKVNO, 0 AS RATE, B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME,A.HEADERREMARK, ")
            .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.CDON AS RETAILORNAME ,A.RDVALUE AS FOLD")
            .Append(" ,SUM(a.CDVALUE) AS CUT_MTR")
            .Append(" ,ISNULL(SUM(a.AVG_WEIGHT),0) AS YARD")
            .Append(" ,I.Design_Name")
            .Append(" ,ISNULL(A.OP14,0) AS  TotalBale")
            .Append(" FROM ((((((TRNPACKINGSLIP AS A ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
            .Append(" LEFT JOIN MSTFABRICITEM AS C ON A.ITEMCODE1=C.ID) ")
            .Append(" LEFT JOIN MstCutMaster AS D ON A.CUTCODE1=D.ID) ")
            .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
            .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
            .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Shade AS H ON A.SHADECODE =H.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design AS I ON A.DESIGNCODE =I.Design_code ")
            .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
            .Append(" And A.CUTCODE1 Is Not Null ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" GROUP BY A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, A.ITEMCODE1, ")
            .Append(" A.CUTCODE1, A.DESPATCHCODE, A.ACCOUNTCODE,A.HEADERREMARK,A.BALE_WEIGHT, ")
            .Append(" A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO,B.ACCOUNTNAME, ")
            .Append("  C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE ")
            .Append(" ,A.BOOKCODE  ,ITEMCODE1,A.CDON ,A.RDVALUE ,H.SHADE ")
            .Append(" ,I.Design_Name")
            .Append(" ,A.OP14")
            .Append(" ) ")
            .Append(" AS Z ")
            .Append(" ) AS Z ")
            .Append(" WHERE 1=1 AND Z.ITEMCODE<>'' ")
            .Append(" ORDER BY Z.ENTRYNO, Z.ITENNAME,Z.CUTNAME ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_FinishInvoice_Challan_Selection_System(ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Book_Transaction_Type As String, ByVal BookCode As String, ByVal _GradingDispatchShowFlagWise As String, Optional ByVal _offerbookvno As String = "", Optional ByVal ChallanDisplayBy As String = "") As String
        strQuery = New StringBuilder
        With strQuery
            If Book_Transaction_Type = "PURCHASE" Or Book_Transaction_Type = "SALES G.R." Then
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" Z.PACK_SLIP_NO AS CHALLANNO, ")
                .Append(" (Z.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
                .Append(" Z.CUTNAME, ")
                .Append(" Z.ITENNAME, ")
                .Append(" Z.PCS, ")
                .Append(" Z.MTR_WEIGHT, ")
                .Append(" CASE WHEN (Z.CUTTYPE='FENT') THEN Z.MTR_WEIGHT ELSE Z.WEIGHT  END AS WEIGHT, ")
                .Append(" Z.AC_NAME, ")
                .Append(" Z.TRANSPORTNAME, ")
                .Append(" Z.RATEON, ")
                .Append(" Z.TRANSPORTCODE, ")
                .Append(" Z.ACOFCODE, ")
                .Append(" Z.CUTCODE, ")
                .Append(" Z.ITEMCODE, ")
                .Append(" Z.BOOKVNO, ")
                .Append(" Z.ACCOUNTCODE, ")
                .Append(" Z.DESPATCHCODE, ")
                .Append(" Z.ACCOUNTNAME, ")
                .Append(" Z.DESPATCH, ")
                .Append(" '' AS AGENTCODE, ")
                .Append(" '' AS AGENTNAME, ")
                .Append(" Z.RATE,")
                .Append(" Z.OFFERNO, ")
                .Append(" Z.DESCR,Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.BALE_WEIGHT,Z.PARTYOFFERNO ")
                .Append(" ,Z.DESIGNCODE  ")
                .Append(" ,Z.SHADECODE  ")
                .Append(" ,'' as RETAILORNAME  ")
                .Append(" ,0 as FOLD  ")
                .Append(" ,0 as CUT_MTR ")
                .Append(" ,'' as YARD")
                .Append(" ,'' AS PackingType")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT '' AS DESIGNCODE ,'' as  SHADECODE,A.OFFERNO,A.HEADERREMARK,A.OFFERBOOKVNO,A.BALE_WEIGHT,A.PARTYOFFERNO,A.ITEMCODE1,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, SUM(A.PCS) AS PCS, ")
                .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT, A.RATEON,")
                .Append(" A.ITEMCODE, A.CUTCODE, A.DESPATCHCODE, ")
                .Append(" A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE,")
                .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, ")
                .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE ")
                .Append(",'' AS DESCR")
                .Append(" FROM ((((((TRNPACKINGSLIP AS A ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
                .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.ITEMCODE=C.ID) ")
                .Append(" LEFT JOIN MstCutMaster AS D ON A.CUTCODE=D.ID) ")
                .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
                .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
                .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID  ")
                .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
                .Append(" And (CUTCODE1='' Or CUTCODE1 Is Null) And (ITEMCODE1='' Or ITEMCODE1 Is Null)  ")
                .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" GROUP BY A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, A.ITEMCODE, A.CUTCODE, ")
                .Append(" A.DESPATCHCODE, A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE, ")
                '.Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.DESIGNCODE ,A.SHADECODE,A.HEADERREMARK,A.BALE_WEIGHT,A.PARTYOFFERNO,A.ITEMCODE1 ")
                .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE ,A.HEADERREMARK,A.BALE_WEIGHT,A.PARTYOFFERNO,A.ITEMCODE1 ")
                .Append(" UNION ALL ")
                .Append(" SELECT '' AS DESIGNCODE ,'' as SHADECODE,A.OFFERNO,A.HEADERREMARK,A.OFFERBOOKVNO,A.BALE_WEIGHT,'' AS PARTYOFFERNO,''AS ITEMCODE1,A.ENTRYNO,A.CHALLANNO AS PACK_SLIP_NO, A.Bill_Chl_Date AS PACK_SLIP_DATE, SUM(A.PCS) AS PCS, ")
                .Append(" SUM(A.CHL_MTR) AS MTR_WEIGHT, (0.0) AS WEIGHT, '' AS RATEON,")
                .Append(" A.ITEMCODE, A.CUTCODE, A.DESPATCHCODE, ")
                .Append(" A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO,ISNULL(a.Tmp_Pcs,0) AS RATE,")
                .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, ")
                .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE ")
                If ChallanDisplayBy = "ITEM+DESIGN" Then
                    .Append(",H.Design_Name AS DESCR")
                Else
                    .Append(",'' AS DESCR")
                End If
                .Append(" FROM ((((((TRNGRADING AS A ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
                .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.ITEMCODE=C.ID) ")
                .Append(" LEFT JOIN MstCutMaster AS D ON A.CUTCODE=D.ID) ")
                .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
                .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
                .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID  ")
                If ChallanDisplayBy = "ITEM+DESIGN" Then
                    .Append(" LEFT JOIN Mst_Fabric_Design AS H ON A.DESIGNCODE=H.Design_code ")
                End If
                .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
                .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                .Append(" AND A.Bill_Chl_Date<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" GROUP BY A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.CHALLANNO, A.Bill_Chl_Date,A.ITEMCODE, A.CUTCODE, ")
                .Append(" A.DESPATCHCODE, A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, ")
                .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE ,A.HEADERREMARK,A.BALE_WEIGHT ")
                .Append(" ,a.Tmp_Pcs")
                If ChallanDisplayBy = "ITEM+DESIGN" Then
                    .Append(",A.DESIGNCODE,H.Design_Name")
                End If
                .Append(" ) AS Z ")
                .Append(" WHERE 1=1 AND Z.ITEMCODE<>'' ")
                .Append(" ORDER BY Z.ENTRYNO, Z.ITENNAME,Z.CUTNAME ")
            Else
                If BookCode = "0001-000000292" Then
                    .Append(" SELECT ")
                    .Append(" SPACE(1) AS MARK, ")
                    .Append(" A.DESPCHALLANNO AS CHALLANNO, ")
                    .Append(" (A.DESPCHALLANDATE) AS F_CHALLANDATE, ")
                    .Append(" 'ROLL' AS CUTNAME, ")
                    .Append(" CASE WHEN (A.DESPDESCR='') THEN C.ITENNAME ELSE A.DESPDESCR END  AS FABRIC_ITEMNAME, ")
                    .Append(" COUNT(A.LUMP_NO) AS PCS, ")
                    .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
                    .Append(" SUM(A.FWEIGHT) AS WEIGHT, ")
                    .Append(" A.DespHeaderRemark AS ACOFNAME, ")
                    .Append(" D.TRANSPORTNAME, ")
                    .Append(" 'MTR' AS RATEON, ")
                    .Append(" A.DESPTRANSPORTCODE, ")
                    .Append(" '0000-000000001' AS ACOFCODE, ")
                    .Append(" '0000-000000016' AS CUTCODE, ")
                    .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                    .Append(" A.DESPBOOKVNO AS BOOKVNO, ")
                    .Append(" A.DESPACCOUNTCODE, ")
                    .Append(" E.CITYCODE AS DESPATCHCODE, ")
                    .Append(" B.ACCOUNTNAME, ")
                    .Append(" E.CITYNAME AS DESPATCH, ")
                    .Append(" '' AS AGENTCODE, ")
                    .Append(" '' AS AGENTNAME, ")
                    .Append(" 0 AS RATE, ")
                    .Append(" A.DESPOFFERNO AS OFFERNO, ")
                    .Append(" A.GRADE AS DESCR,A.DESPOFFERBOOKVNO AS OFFERBOOKVNO ")
                    .Append(" ,'' as YARD")
                    .Append(" ,'' AS PackingType")
                    .Append(" FROM ((((TRNDENIMFOLDING AS A ")
                    .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.DESPBOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                    .Append(" LEFT JOIN MstMasterAccount AS B ON A.DESPACCOUNTCODE=B.ACCOUNTCODE) ")
                    .Append(" LEFT JOIN MSTFABRICITEM AS C ON A.FABRIC_ITEMCODE=C.ID) ")
                    .Append(" LEFT JOIN MSTTRANSPORT AS D ON A.DESPTRANSPORTCODE=D.ID) ")
                    .Append(" LEFT JOIN MSTCITY AS E ON B.CITYCODE=E.CITYCODE ")
                    .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
                    .Append(" AND A.DESPCHALLANNO<>0 ")
                    .Append(" AND A.DESPACCOUNTCODE='" & AccountCode & "'")
                    .Append(" GROUP BY ")
                    .Append(" E.CITYCODE,A.DESPOFFERNO,A.DESPDESCR, ")
                    .Append(" A.DESPOFFERBOOKVNO,A.DespHeaderRemark, ")
                    .Append(" A.DESPCHALLANNO , ")
                    .Append(" A.DESPCHALLANDATE, ")
                    .Append(" C.ITENNAME, ")
                    .Append(" D.TRANSPORTNAME, ")
                    .Append(" A.DESPTRANSPORTCODE, ")
                    .Append(" A.FABRIC_ITEMCODE, ")
                    .Append(" A.DESPBOOKVNO, ")
                    .Append(" A.DESPACCOUNTCODE, ")
                    .Append(" B.ACCOUNTNAME, ")
                    .Append(" A.GRADE,E.CITYNAME ")
                    .Append(" ORDER BY A.DESPCHALLANNO, C.ITENNAME,A.GRADE ")
                Else
                    sqL = "SELECT * FROM    TrnPackingSlip AS A WHERE   a.ENTRYNO = (SELECT MAX(a.ENTRYNO)  FROM TrnPackingSlip as a WHERE  1=1  " & Str_In_Challan_Book & " )"
                    sql_connect_slect()
                    Dim _SelectBookNo As String = ""
                    If DefaltSoftTable.Rows.Count > 0 Then
                        _SelectBookNo = DefaltSoftTable.Rows(0).Item("BOOKVNO").ToString
                    End If

                    sqL = " SELECT*FROM trnGrading WHERE 1=1 AND BOOKVNO='" & _SelectBookNo & "'"
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        .Append(" SELECT ")
                        .Append(" SPACE(1) AS MARK, ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" Z.PACK_SLIP_NO AS CHALLANNO, ")
                            .Append(" (Z.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
                            .Append(" Z.CUTNAME, ")
                            .Append(" Z.ITENNAME, ")
                            .Append(" SUM ( Z.PCS) AS PCS , ")
                            .Append(" SUM (Z.MTR_WEIGHT) AS MTR_WEIGHT, ")
                            .Append(" CASE WHEN (Z.CUTTYPE='FENT') THEN SUM (Z.MTR_WEIGHT) ELSE  SUM (Z.WEIGHT) END AS WEIGHT, ")
                            .Append(" Z.AC_NAME, ")
                            .Append(" Z.TRANSPORTNAME, ")
                            .Append(" Z.RATEON, ")
                            .Append(" Z.TRANSPORTCODE, ")
                            .Append(" Z.ACOFCODE, ")
                            .Append(" Z.CUTCODE, ")
                            .Append(" Z.ITEMCODE, ")
                            .Append(" Z.BOOKVNO, ")
                            .Append(" Z.ACCOUNTCODE, ")
                            .Append(" Z.DESPATCHCODE, ")
                            .Append(" Z.ACCOUNTNAME, ")
                            .Append(" Z.DESPATCH, ")
                            .Append(" '' AS AGENTCODE, ")
                            .Append(" '' AS AGENTNAME, ")
                            .Append(" Z.RATE,")
                            .Append(" Z.OFFERNO, ")
                            .Append(" '' AS DESCR,Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.BALE_WEIGHT,Z.PARTYOFFERNO ")
                            .Append(" ,Z.DESIGNCODE  ")
                            .Append(" ,Z.SHADECODE  ")
                            .Append(" ,Z.RETAILORNAME  ")
                            .Append(" ,Z.FOLD  ")
                            .Append(" ,SUM (Z.CUT_MTR) AS CUT_MTR")
                            .Append(" ,SUM (Z.YARD) AS YARD")
                            .Append(" ,Z.ENTRYNO ")
                            .Append(" ,Z.PackingType")

                        Else
                            .Append(" Z.PACK_SLIP_NO AS CHALLANNO, ")
                            .Append(" (Z.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
                            .Append(" Z.CUTNAME, ")
                            .Append(" Z.ITENNAME, ")
                            .Append(" Z.PCS, ")
                            .Append(" Z.MTR_WEIGHT, ")
                            .Append(" CASE WHEN (Z.CUTTYPE='FENT') THEN Z.MTR_WEIGHT ELSE Z.WEIGHT END AS WEIGHT, ")
                            .Append(" Z.AC_NAME, ")
                            .Append(" Z.TRANSPORTNAME, ")
                            .Append(" Z.RATEON, ")
                            .Append(" Z.TRANSPORTCODE, ")
                            .Append(" Z.ACOFCODE, ")
                            .Append(" Z.CUTCODE, ")
                            .Append(" Z.ITEMCODE, ")
                            .Append(" Z.BOOKVNO, ")
                            .Append(" Z.ACCOUNTCODE, ")
                            .Append(" Z.DESPATCHCODE, ")
                            .Append(" Z.ACCOUNTNAME, ")
                            .Append(" Z.DESPATCH, ")
                            .Append(" '' AS AGENTCODE, ")
                            .Append(" '' AS AGENTNAME, ")
                            .Append(" Z.RATE,")
                            .Append(" Z.OFFERNO, ")
                            If ChallanDisplayBy = "ITEM+DESIGN" Then
                                .Append(" Z.DESCR,")
                            Else
                                .Append(" '' AS DESCR,")
                            End If
                            .Append(" Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.BALE_WEIGHT,Z.PARTYOFFERNO ")
                            .Append(" ,Z.DESIGNCODE  ")
                            .Append(" ,Z.SHADECODE  ")
                            .Append(" ,Z.RETAILORNAME  ")
                            .Append(" ,Z.FOLD  ")
                            .Append(" ,Z.CUT_MTR")
                            .Append(" ,Z.YARD")
                            .Append(" ,Z.PackingType")
                            .Append(" ,Z.ChallanHsn")
                        End If
                        .Append(" FROM ")
                        .Append(" ( ")
                        .Append(" SELECT A.BOOKCODE ,'' as DESIGNCODE ,'' as SHADECODE ,'' as ITEMCODE1,A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append("  (1) AS PCS, ")
                        Else
                            .Append("  SUM(A.PCS) AS PCS, ")
                        End If
                        .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT,A.RATEON, ")
                        .Append(" A.ITEMCODE, A.CUTCODE, A.DESPATCHCODE,A.BALE_WEIGHT, ")
                        .Append(" A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE, ")
                        .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME,A.HEADERREMARK, ")
                        .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.CDON AS RETAILORNAME  ")
                        .Append("  ,SUM(A.RDVALUE) AS FOLD ")
                        .Append(" ,SUM(a.CDVALUE) AS CUT_MTR")
                        .Append(" ,ISNULL(SUM(a.AVG_WEIGHT),0) AS YARD")
                        .Append(" ,a.Y_LOTNO PackingType")
                        .Append(" ,a.OP5 ChallanHsn")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT AS FLAG")
                        End If
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",H.Design_Name AS DESCR")
                        End If
                        .Append(" FROM ((((((TRNPACKINGSLIP AS A ")
                        .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                        .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
                        .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.ITEMCODE=C.ID) ")
                        .Append(" LEFT JOIN MstCutMaster AS D ON A.CUTCODE=D.ID) ")
                        .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
                        .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
                        .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID  ")
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(" LEFT JOIN Mst_Fabric_Design AS H ON A.DESIGNCODE=H.Design_code ")
                        End If
                        .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")

                        .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                        .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                        .Append(Str_In_Challan_Book)
                        .Append(_offerbookvno)
                        .Append(" GROUP BY A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, A.ITEMCODE, A.CUTCODE, ")
                        .Append(" A.DESPATCHCODE, A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE,A.HEADERREMARK,A.BALE_WEIGHT, ")
                        .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.PARTYOFFERNO ")
                        .Append(",A.BOOKCODE,A.CDON ")
                        .Append(" ,a.Y_LOTNO ")
                        .Append(" ,a.OP5 ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(",A.WEIGHT")
                        End If

                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",A.DESIGNCODE,H.Design_Name")
                        End If
                        .Append(" UNION ALL   ")
                        .Append(" SELECT *  ")
                        .Append(" FROM ")
                        .Append(" ( ")
                        .Append(" SELECT A.BOOKCODE ,'' as DESIGNCODE ,'' as SHADECODE  ,'' as ITEMCODE1,A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append("  (1) AS PCS, ")
                        Else
                            .Append(" 0 AS PCS , ")
                        End If
                        .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT, A.RATEON, '' AS   ")
                        .Append(" ITEMCODE, '' AS CUTCODE, A.DESPATCHCODE,A.BALE_WEIGHT, A.ACCOUNTCODE, A.TRANSPORTCODE, ")
                        .Append(" A.ACOFCODE, A.BOOKVNO, 0 AS RATE, B.ACCOUNTNAME, '' as ITENNAME, '' as CUTNAME,A.HEADERREMARK, ")
                        .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,'' as CUTTYPE,A.CDON AS RETAILORNAME ,(A.RDVALUE) AS FOLD")
                        .Append(" ,SUM(a.CDVALUE) AS CUT_MTR")
                        .Append(" ,ISNULL(SUM(a.AVG_WEIGHT),0) AS YARD")
                        .Append(" ,a.Y_LOTNO PackingType")
                        .Append(" ,a.OP5 ChallanHsn")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT AS FLAG")
                        End If

                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",H.Design_Name AS DESCR")
                        End If
                        .Append(" FROM ((((TRNPACKINGSLIP AS A ")
                        .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                        .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
                        .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
                        .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
                        .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID ")
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(" LEFT JOIN Mst_Fabric_Design AS H ON A.DESIGNCODE=H.Design_code ")
                        End If
                        .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
                        .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                        .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                        .Append(Str_In_Challan_Book)
                        .Append(" GROUP BY A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, ")
                        .Append("  A.DESPATCHCODE, A.ACCOUNTCODE,A.HEADERREMARK,A.BALE_WEIGHT, ")
                        .Append(" A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO,B.ACCOUNTNAME, ")
                        .Append(" E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME ")
                        .Append(" ,A.BOOKCODE,A.CDON ")
                        .Append(" ,A.RDVALUE ")
                        .Append(" ,a.Y_LOTNO")
                        .Append(" ,a.OP5")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT")
                        End If
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",A.DESIGNCODE,H.Design_Name")
                        End If
                        .Append(" ) ")
                        .Append(" AS Z ")
                        .Append(" ) AS Z ")
                        .Append(" WHERE 1=1 AND Z.ITEMCODE<>'' ")

                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" GROUP BY  ")
                            .Append(" Z.ENTRYNO , ")
                            .Append(" Z.PACK_SLIP_NO , ")
                            .Append(" Z.PACK_SLIP_DATE, ")
                            .Append(" Z.CUTNAME, ")
                            .Append(" Z.ITENNAME, ")
                            .Append(" Z.CUTTYPE, ")
                            .Append(" Z.AC_NAME, ")
                            .Append(" Z.TRANSPORTNAME, ")
                            .Append(" Z.RATEON, ")
                            .Append(" Z.TRANSPORTCODE, ")
                            .Append(" Z.ACOFCODE, ")
                            .Append(" Z.CUTCODE, ")
                            .Append(" Z.ITEMCODE, ")
                            .Append(" Z.BOOKVNO, ")
                            .Append(" Z.ACCOUNTCODE, ")
                            .Append(" Z.DESPATCHCODE, ")
                            .Append(" Z.ACCOUNTNAME, ")
                            .Append(" Z.DESPATCH, ")
                            .Append(" Z.RATE,")
                            .Append(" Z.OFFERNO, ")
                            .Append(" Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.PARTYOFFERNO,Z.BALE_WEIGHT ")
                            .Append(" ,Z.DESIGNCODE  ")
                            .Append(" ,Z.SHADECODE  ")
                            .Append(" ,Z.RETAILORNAME  ")
                            .Append(" ,Z.FOLD  ")
                            .Append(" ,Z.PackingType")
                        End If
                        .Append(" ORDER BY Z.ENTRYNO, Z.ITENNAME,Z.CUTNAME ")
                    Else
                        .Append(" SELECT ")
                        .Append(" SPACE(1) AS MARK, ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" Z.PACK_SLIP_NO AS CHALLANNO, ")
                            .Append(" (Z.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
                            .Append(" Z.CUTNAME, ")
                            .Append(" Z.ITENNAME, ")
                            .Append(" SUM ( Z.PCS) AS PCS , ")
                            .Append(" SUM (Z.MTR_WEIGHT) AS MTR_WEIGHT, ")
                            .Append(" CASE WHEN (Z.CUTTYPE='FENT') THEN SUM (Z.MTR_WEIGHT) ELSE  SUM (Z.WEIGHT) END AS WEIGHT, ")
                            .Append(" Z.AC_NAME, ")
                            .Append(" Z.TRANSPORTNAME, ")
                            .Append(" Z.RATEON, ")
                            .Append(" Z.TRANSPORTCODE, ")
                            .Append(" Z.ACOFCODE, ")
                            .Append(" Z.CUTCODE, ")
                            .Append(" Z.ITEMCODE, ")
                            .Append(" Z.BOOKVNO, ")
                            .Append(" Z.ACCOUNTCODE, ")
                            .Append(" Z.DESPATCHCODE, ")
                            .Append(" Z.ACCOUNTNAME, ")
                            .Append(" Z.DESPATCH, ")
                            .Append(" '' AS AGENTCODE, ")
                            .Append(" '' AS AGENTNAME, ")
                            .Append(" Z.RATE,")
                            .Append(" Z.OFFERNO, ")
                            If ChallanDisplayBy = "ITEM+DESIGN" Then
                                .Append(" ,Z.DESCR")
                            Else
                                .Append(" ,'' AS DESCR")
                            End If
                            .Append(" ,Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.BALE_WEIGHT,Z.PARTYOFFERNO ")
                            .Append(" ,Z.DESIGNCODE  ")
                            .Append(" ,Z.SHADECODE  ")
                            .Append(" ,Z.RETAILORNAME  ")
                            .Append(" ,Z.FOLD  ")
                            .Append(" ,SUM (Z.CUT_MTR) AS CUT_MTR")
                            .Append(" ,SUM (Z.YARD) AS YARD")
                            .Append(" ,Z.ENTRYNO ")
                            .Append(" ,Z.PackingType")

                        Else
                            .Append(" Z.PACK_SLIP_NO AS CHALLANNO, ")
                            .Append(" (Z.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
                            .Append(" Z.CUTNAME, ")
                            .Append(" Z.ITENNAME, ")
                            .Append(" Z.PCS, ")
                            .Append(" Z.MTR_WEIGHT, ")
                            .Append(" CASE WHEN (Z.CUTTYPE='FENT') THEN Z.MTR_WEIGHT ELSE Z.WEIGHT END AS WEIGHT, ")
                            .Append(" Z.AC_NAME, ")
                            .Append(" Z.TRANSPORTNAME, ")
                            .Append(" Z.RATEON, ")
                            .Append(" Z.TRANSPORTCODE, ")
                            .Append(" Z.ACOFCODE, ")
                            .Append(" Z.CUTCODE, ")
                            .Append(" Z.ITEMCODE, ")
                            .Append(" Z.BOOKVNO, ")
                            .Append(" Z.ACCOUNTCODE, ")
                            .Append(" Z.DESPATCHCODE, ")
                            .Append(" Z.ACCOUNTNAME, ")
                            .Append(" Z.DESPATCH, ")
                            .Append(" '' AS AGENTCODE, ")
                            .Append(" '' AS AGENTNAME, ")
                            .Append(" Z.RATE,")
                            .Append(" Z.OFFERNO, ")
                            If ChallanDisplayBy = "ITEM+DESIGN" Then
                                .Append(" Z.DESCR,")
                            Else
                                .Append(" '' AS DESCR,")
                            End If
                            .Append(" Z.OFFERBOOKVNO, ")
                            .Append(" Z.HEADERREMARK, ")
                            .Append(" Z.BALE_WEIGHT,  ")
                            .Append(" Z.PARTYOFFERNO ")
                            .Append(" ,Z.DESIGNCODE  ")
                            .Append(" ,Z.SHADECODE  ")
                            .Append(" ,Z.RETAILORNAME  ")
                            .Append(" ,Z.FOLD  ")
                            .Append(" ,Z.CUT_MTR")
                            .Append(" ,Z.YARD")
                            .Append(" ,Z.PackingType")
                        End If
                        .Append(" FROM ")
                        .Append(" ( ")
                        .Append(" SELECT A.BOOKCODE ,'' as DESIGNCODE ,'' as SHADECODE ,'' as ITEMCODE1,A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append("  (1) AS PCS, ")
                        Else
                            .Append("  SUM(A.PCS) AS PCS, ")
                        End If
                        .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT,A.RATEON, ")
                        .Append(" A.ITEMCODE, A.CUTCODE, A.DESPATCHCODE,A.BALE_WEIGHT, ")
                        .Append(" A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE, ")
                        .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME,A.HEADERREMARK, ")
                        .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.CDON AS RETAILORNAME  ")
                        .Append("  ,(A.RDVALUE) AS FOLD ")
                        .Append(" ,SUM(a.CDVALUE) AS CUT_MTR")
                        .Append(" ,ISNULL(SUM(a.AVG_WEIGHT),0) AS YARD")
                        .Append(" ,A.Y_LOTNO AS PackingType")

                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT AS FLAG")
                        End If
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",H.Design_Name AS DESCR")
                        End If
                        .Append(" FROM ((((((TRNPACKINGSLIP AS A ")
                        .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                        .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
                        .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.ITEMCODE=C.ID) ")
                        .Append(" LEFT JOIN MstCutMaster AS D ON A.CUTCODE=D.ID) ")
                        .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
                        .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
                        .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID  ")
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(" LEFT JOIN Mst_Fabric_Design AS H ON A.DESIGNCODE=H.Design_code ")
                        End If
                        .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
                        .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                        .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                        .Append(Str_In_Challan_Book)
                        .Append(_offerbookvno)
                        .Append(" GROUP BY A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, A.ITEMCODE, A.CUTCODE, ")
                        .Append(" A.DESPATCHCODE, A.ACCOUNTCODE, A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO, A.RATE,A.HEADERREMARK,A.BALE_WEIGHT, ")
                        .Append(" B.ACCOUNTNAME, C.ITENNAME, D.CUTNAME, E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME,D.CUTTYPE,A.PARTYOFFERNO ")
                        .Append(" ,A.Y_LOTNO")
                        .Append("  ,A.BOOKCODE   ,A.CDON  ")
                        .Append("  ,A.RDVALUE  ")

                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",A.DESIGNCODE,H.Design_Name")
                        End If

                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT")
                        End If
                        .Append(" UNION ALL   ")
                        .Append(" SELECT *  ")
                        .Append(" FROM ")
                        .Append(" ( ")
                        .Append(" SELECT A.BOOKCODE ,'' as DESIGNCODE ,'' as SHADECODE  ,'' as ITEMCODE1,A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append("  (1) AS PCS, ")
                        Else
                            .Append(" 0 AS PCS , ")
                        End If
                        .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, SUM(A.WEIGHT) AS WEIGHT, A.RATEON, '' AS   ")
                        .Append(" ITEMCODE, '' AS CUTCODE, A.DESPATCHCODE,A.BALE_WEIGHT, A.ACCOUNTCODE, A.TRANSPORTCODE, ")
                        .Append(" A.ACOFCODE, A.BOOKVNO, 0 AS RATE, B.ACCOUNTNAME, '' as ITENNAME, '' as CUTNAME,A.HEADERREMARK, ")
                        .Append(" E.CITYNAME AS DESPATCH, F.TRANSPORTNAME, G.AC_NAME,'' as CUTTYPE,A.CDON AS RETAILORNAME ,sum(A.RDVALUE) AS FOLD")
                        .Append(" ,SUM(a.CDVALUE) AS CUT_MTR")
                        .Append(" ,ISNULL(SUM(a.AVG_WEIGHT),0) AS YARD")
                        .Append(" ,A.Y_LOTNO AS PackingType")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT AS FLAG")
                        End If
                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",H.Design_Name AS DESCR")
                        End If

                        .Append(" FROM ((((TRNPACKINGSLIP AS A ")
                        .Append(" LEFT JOIN TRNINVOICEDETAIL ON A.BOOKVNO=TRNINVOICEDETAIL.CHALLANBOOKVNO) ")
                        .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE) ")
                        .Append(" LEFT JOIN MSTCITY AS E ON A.DESPATCHCODE=E.CITYCODE) ")
                        .Append(" LEFT JOIN MSTTRANSPORT AS F ON A.TRANSPORTCODE=F.ID) ")
                        .Append(" LEFT JOIN Mst_Acof_Supply AS G ON A.ACOFCODE=G.ID ")

                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(" LEFT JOIN Mst_Fabric_Design AS H ON A.DESIGNCODE=H.Design_code ")
                        End If

                        .Append(" WHERE 1=1 And TRNINVOICEDETAIL.CHALLANBOOKVNO Is Null ")
                        .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                        .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                        .Append(Str_In_Challan_Book)
                        .Append(" GROUP BY A.PARTYOFFERNO,A.OFFERNO,A.OFFERBOOKVNO,A.ENTRYNO,A.PACK_SLIP_NO, A.PACK_SLIP_DATE, A.RATEON, ")
                        .Append("  A.DESPATCHCODE, A.ACCOUNTCODE,A.HEADERREMARK,A.BALE_WEIGHT, ")
                        .Append(" A.TRANSPORTCODE, A.ACOFCODE, A.BOOKVNO,B.ACCOUNTNAME, ")
                        .Append(" E.CITYNAME, F.TRANSPORTNAME, G.AC_NAME ")
                        .Append("   ,A.BOOKCODE  ,A.CDON  ")
                        '.Append("    ,A.RDVALUE  ")
                        .Append(" ,A.Y_LOTNO")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" ,A.WEIGHT")
                        End If

                        If ChallanDisplayBy = "ITEM+DESIGN" Then
                            .Append(",A.DESIGNCODE,H.Design_Name")
                        End If
                        .Append(" ) ")
                        .Append(" AS Z ")
                        .Append(" ) AS Z ")
                        .Append(" WHERE 1=1 AND Z.ITEMCODE<>'' ")
                        If _GradingDispatchShowFlagWise = "YES" Then
                            .Append(" GROUP BY  ")
                            .Append(" Z.ENTRYNO , ")
                            .Append(" Z.PACK_SLIP_NO , ")
                            .Append(" Z.PACK_SLIP_DATE, ")
                            .Append(" Z.CUTNAME, ")
                            .Append(" Z.ITENNAME, ")
                            .Append(" Z.CUTTYPE, ")
                            .Append(" Z.AC_NAME, ")
                            .Append(" Z.TRANSPORTNAME, ")
                            .Append(" Z.RATEON, ")
                            .Append(" Z.TRANSPORTCODE, ")
                            .Append(" Z.ACOFCODE, ")
                            .Append(" Z.CUTCODE, ")
                            .Append(" Z.ITEMCODE, ")
                            .Append(" Z.BOOKVNO, ")
                            .Append(" Z.ACCOUNTCODE, ")
                            .Append(" Z.DESPATCHCODE, ")
                            .Append(" Z.ACCOUNTNAME, ")
                            .Append(" Z.DESPATCH, ")
                            .Append(" Z.RATE,")
                            .Append(" Z.OFFERNO, ")
                            .Append(" Z.OFFERBOOKVNO,Z.HEADERREMARK,Z.PARTYOFFERNO,Z.BALE_WEIGHT ")
                            .Append(" ,Z.DESIGNCODE  ")
                            .Append(" ,Z.SHADECODE  ")
                            .Append(" ,Z.RETAILORNAME  ")
                            .Append(" ,Z.FOLD  ")
                            .Append(" ,Z.PackingType")
                            If ChallanDisplayBy = "ITEM+DESIGN" Then
                                .Append(" ,Z.DESCR")
                            End If
                        End If
                        .Append(" ORDER BY Z.ENTRYNO, Z.ITENNAME,Z.CUTNAME ")
                    End If
                End If
            End If
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Grey_Invoice_Entry_Due_Challan_Selection_Qry(ByVal _BookCode As String, ByVal _BookNature As String, ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal ITEM_RATE As String, ByVal YarnwtCal As String, ByVal _ChallanShowBy As String) As String
        strQuery = New StringBuilder

        With strQuery
            If _BookCode = "0001-000000034" Then
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.GMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" '' AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.GREY_RCPT_ACCOUNT_CODE AS ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" '' AS PROCESSCODE, ")
                .Append(" '' AS ACCOUNTNAME,'' AS PROCESSNAME, ")
                .Append(" '' AS SELVNAME, ")
                .Append(" '' AS FACTORYCHALLANNO ")
                .Append(" ,'' AS UNITCODE ")
                .Append(" ,'' AS ShadeCode ")
                .Append(" ,C.HSNCODE ")

                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE AS GreyShadeCode ")
                    .Append(" ,I.SHADE AS GreyShadeName ")
                    .Append(" ,'' AS GreyDesignCode ")
                    .Append(" ,'' AS GreyDesignName  ")

                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" ,'' AS GreyShadeCode ")
                    .Append(" ,'' AS GreyShadeName ")
                    .Append(" ,A.FABRIC_DESIGNCODE AS GreyDesignCode ")
                    .Append(" ,J.Design_Name AS GreyDesignName  ")

                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE AS GreyShadeCode ")
                    .Append(" ,I.SHADE AS GreyShadeName ")
                    .Append(" ,A.FABRIC_DESIGNCODE AS GreyDesignCode ")
                    .Append(" ,J.Design_Name AS GreyDesignName  ")
                Else
                    .Append(" ,'' AS GreyShadeCode ")
                    .Append(" ,'' AS GreyShadeName ")
                    .Append(" ,'' AS GreyDesignCode ")
                    .Append(" ,'' AS GreyDesignName  ")
                End If

                .Append(" FROM TRNGREYRCPT AS A")
                .Append(" Left Join MSTFABRICITEM AS C ON A.FABRIC_ITEMCODE=C.ID")
                .Append(" Left JOIN MstMasterAccount AS F ON  A.GREY_RCPT_ACCOUNT_CODE=F.ACCOUNTCODE")
                .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE ")
                .Append(" Left JOIN MstMasterAccount AS H  ON F.AGENTCODE=H.ACCOUNTCODE")


                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" Left JOIN Mst_Fabric_Shade AS I  ON A.FABRIC_SHADECODE=I.Id")
                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" Left JOIN Mst_Fabric_Design AS J  ON A.FABRIC_DESIGNCODE=J.Design_code")
                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" Left JOIN Mst_Fabric_Shade AS I  ON A.FABRIC_SHADECODE=I.Id")
                    .Append(" Left JOIN Mst_Fabric_Design AS J  ON A.FABRIC_DESIGNCODE=J.Design_code")
                End If

                .Append(" WHERE 1=1 ")
                .Append(" And A.GREY_RCPT_ACCOUNT_CODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(" AND A.BOOKCODE='0001-000000210' ")
                .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1 AND BOOKCODE='" & _BookCode & "' AND CHALLANBOOKVNO IS NOT NULL) ")
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,A.GREY_RCPT_ACCOUNT_CODE,F.CITYCODE,F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
                .Append(" ,C.HSNCODE ")

                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE ")
                    .Append(" ,I.SHADE  ")
                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" ,A.FABRIC_DESIGNCODE  ")
                    .Append(" ,J.Design_Name ")
                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE ")
                    .Append(" ,I.SHADE ")
                    .Append(" ,A.FABRIC_DESIGNCODE ")
                    .Append(" ,J.Design_Name  ")
                End If

                .Append(" ORDER BY LEN(A.CHALLANNO),A.CHALLANNO, C.ITENNAME ")
            Else

                .Append("  SELECT * FROM ( ")
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                If _BookNature = "SALES" Then
                    .Append(" LTRIM(A.CHALLANNO) + '/' + LTRIM(A.Sales_Challan_No) AS CHALLANNO, ")
                    .Append(" (A.SALES_DATE) AS F_CHALLANDATE, ")
                Else
                    .Append(" A.CHALLANNO AS CHALLANNO, ")
                    .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                End If
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.GMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                If ITEM_RATE = "GREY CHALLAN" Then
                    .Append(" A.GREY_RATE AS RATE, ")
                Else
                    .Append(" 0 AS RATE, ")
                End If

                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" J.SELVEDGE_NAME, ")
                .Append(" A.CHALLANNO AS FACTORYCHALLANNO ")
                .Append(" ,ISNULL(A.OP1,'')  AS UNITCODE ")
                If YarnwtCal = "YES" Then
                    .Append(" ,A.OP5 AS ShadeCode ")
                Else
                    .Append(" ,'' AS ShadeCode ")
                End If
                .Append(" ,C.HSNCODE ")

                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE AS GreyShadeCode ")
                    .Append(" ,K.SHADE AS GreyShadeName ")
                    .Append(" ,'' AS GreyDesignCode ")
                    .Append(" ,'' AS GreyDesignName  ")

                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" ,'' AS GreyShadeCode ")
                    .Append(" ,'' AS GreyShadeName ")
                    .Append(" ,A.FABRIC_DESIGNCODE AS GreyDesignCode ")
                    .Append(" ,L.Design_Name AS GreyDesignName  ")

                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE AS GreyShadeCode ")
                    .Append(" ,K.SHADE AS GreyShadeName ")
                    .Append(" ,A.FABRIC_DESIGNCODE AS GreyDesignCode ")
                    .Append(" ,L.Design_Name AS GreyDesignName  ")
                Else
                    .Append(" ,'' AS GreyShadeCode ")
                    .Append(" ,'' AS GreyShadeName ")
                    .Append(" ,'' AS GreyDesignCode ")
                    .Append(" ,'' AS GreyDesignName  ")
                End If

                .Append(" FROM TRNGREYDESP AS A")
                .Append(" LEFT JOIN MSTFABRICITEM AS C  ON  A.FABRIC_ITEMCODE=C.ID ")
                .Append(" LEFT JOIN MstMasterAccount AS F ON  A.ACCOUNTCODE=F.ACCOUNTCODE  ")
                .Append(" LEFT JOIN  MSTCITY AS G ON  F.CITYCODE=G.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS H  ON  F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS I ON  A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" LEFT JOIN Mst_selvedge J ON A.SELVCODE=J.ID")

                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" Left JOIN Mst_Fabric_Shade AS K  ON A.FABRIC_SHADECODE=K.Id")
                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" Left JOIN Mst_Fabric_Design AS L  ON A.FABRIC_DESIGNCODE=L.Design_code")
                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" Left JOIN Mst_Fabric_Shade AS K  ON A.FABRIC_SHADECODE=K.Id")
                    .Append(" Left JOIN Mst_Fabric_Design AS L  ON A.FABRIC_DESIGNCODE=L.Design_code")
                End If

                .Append(" WHERE 1=1  ")
                If _BookNature = "PURCAHSE" Then
                    .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                ElseIf _BookNature = "SALES" Then
                    .Append(" AND A.SALES_ACCOUNTCODE='" & AccountCode & "'")
                Else
                    .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                End If
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1 " & _BookCode & " AND CHALLANBOOKVNO IS NOT NULL   ) ")
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO,SALES_DATE, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,A.ACCOUNTCODE,F.CITYCODE,F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME,J.SELVEDGE_NAME,A.OP1 ")
                .Append(" ,C.HSNCODE ")

                If ITEM_RATE = "GREY CHALLAN" Then
                    .Append(" ,A.GREY_RATE ")
                End If

                If YarnwtCal = "YES" Then
                    .Append(" ,A.OP5 ")
                End If


                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE ")
                    .Append(" ,K.SHADE ")
                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" ,A.FABRIC_DESIGNCODE ")
                    .Append(" ,L.Design_Name ")
                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE ")
                    .Append(" ,K.SHADE ")
                    .Append(" ,A.FABRIC_DESIGNCODE ")
                    .Append(" ,L.Design_Name ")
                End If

                .Append(" UNION ALL ")

                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.GMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.Grey_Rcpt_Account_Code AS ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" J.SELVEDGE_NAME, ")
                .Append(" A.CHALLANNO AS FACTORYCHALLANNO ")
                .Append(" ,A.GODOWNCODE  AS UNITCODE ")
                .Append(" ,A.FABRIC_SHADECODE AS ShadeCode ")
                .Append(" ,C.HSNCODE ")

                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE AS GreyShadeCode ")
                    .Append(" ,K.SHADE AS GreyShadeName ")
                    .Append(" ,'' AS GreyDesignCode ")
                    .Append(" ,'' AS GreyDesignName  ")

                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" ,'' AS GreyShadeCode ")
                    .Append(" ,'' AS GreyShadeName ")
                    .Append(" ,A.FABRIC_DESIGNCODE AS GreyDesignCode ")
                    .Append(" ,L.Design_Name AS GreyDesignName  ")

                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE AS GreyShadeCode ")
                    .Append(" ,K.SHADE AS GreyShadeName ")
                    .Append(" ,A.FABRIC_DESIGNCODE AS GreyDesignCode ")
                    .Append(" ,L.Design_Name AS GreyDesignName  ")
                Else
                    .Append(" ,'' AS GreyShadeCode ")
                    .Append(" ,'' AS GreyShadeName ")
                    .Append(" ,'' AS GreyDesignCode ")
                    .Append(" ,'' AS GreyDesignName  ")
                End If

                .Append(" FROM TrnGreyRcpt AS A ")
                .Append(" LEFT JOIN MSTFABRICITEM AS C  ON  A.FABRIC_ITEMCODE=C.ID ")
                .Append(" LEFT JOIN MstMasterAccount AS F ON  A.Grey_Rcpt_Account_Code=F.ACCOUNTCODE  ")
                .Append(" LEFT JOIN  MSTCITY AS G ON  F.CITYCODE=G.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS H  ON  F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS I ON  A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" LEFT JOIN Mst_selvedge J ON A.SELVCODE=J.ID ")

                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" Left JOIN Mst_Fabric_Shade AS K  ON A.FABRIC_SHADECODE=K.Id")
                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" Left JOIN Mst_Fabric_Design AS L  ON A.FABRIC_DESIGNCODE=L.Design_code")
                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" Left JOIN Mst_Fabric_Shade AS K  ON A.FABRIC_SHADECODE=K.Id")
                    .Append(" Left JOIN Mst_Fabric_Design AS L  ON A.FABRIC_DESIGNCODE=L.Design_code")
                End If

                .Append(" WHERE 1=1  ")
                .Append(" AND A.Grey_Rcpt_Account_Code='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1 " & _BookCode & "  AND CHALLANBOOKVNO IS NOT NULL   ) ")
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,A.Grey_Rcpt_Account_Code,F.CITYCODE,F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME,J.SELVEDGE_NAME ")
                .Append(" ,A.FABRIC_SHADECODE ")
                .Append(" ,A.GODOWNCODE ")
                .Append(" ,C.HSNCODE ")
                If _ChallanShowBy = "ITEM+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE ")
                    .Append(" ,K.SHADE ")
                ElseIf _ChallanShowBy = "ITEM+DESIGN" Then
                    .Append(" ,A.FABRIC_DESIGNCODE ")
                    .Append(" ,L.Design_Name ")
                ElseIf _ChallanShowBy = "ITEM+DESIGN+SHADE" Then
                    .Append(" ,A.FABRIC_SHADECODE ")
                    .Append(" ,K.SHADE ")
                    .Append(" ,A.FABRIC_DESIGNCODE ")
                    .Append(" ,L.Design_Name ")
                End If
                .Append(" )AS Z ")
                .Append(" ORDER BY  LEN(Z.CHALLANNO),Z.CHALLANNO, Z.ITENNAME ")


                'If _BookNature = "SALES" Then
                '    .Append(" ORDER BY  LEN(A.SALES_CHALLAN_NO), A.SALES_CHALLAN_NO, C.ITENNAME ")
                'Else
                '    .Append(" ORDER BY  LEN(A.CHALLANNO),A.CHALLANNO, C.ITENNAME ")
                'End If
            End If
        End With

        Return strQuery.ToString
    End Function



    Public Function EntryData_Job_Invoice_RateByJobContract(ByVal _BookNature As String, ByVal _BookCode As String, ByVal AccountCode As String, ByVal Str_In_Challan_Book As String, ByVal BillDate As String) As String
        Dim ExistPkRtPrRtFld As Boolean = DoesFieldExist("TRNGREYDESP", "PICKRATE")
        strQuery = New StringBuilder
        With strQuery
            If _BookNature = "JOB-PAID" Then
                .Append(" SELECT Z.* ")
                .Append(" ,L.PROCESS_NET_RATE AS PICKRATECONTRACT ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" ROUND(SUM(A.GMTR),3) AS MTR_WEIGHT, ")
                .Append(" ROUND(SUM(A.WEIGHT),4) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" A.PICK, ")
                If ExistPkRtPrRtFld = True Then
                    .Append(" A.PICKRATE AS PICK_RATE, ")
                Else
                    .Append(" (0.0) AS PICK_RATE, ")
                End If
                .Append(" 0 AS MENDING_RATE, ")
                .Append(" ROUND((ROUND(SUM(A.WEIGHT),4)* A.WESTPER)/100,4) AS WEST_WEIGHT, ")
                .Append(" A.CHALLANDATE ")
                .Append(" ,A.BEAMNO ")
                .Append(" FROM TRNGREYDESP AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
                .Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
                .Append(" AND F.CITYCODE=G.CITYCODE ")
                .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(" AND A.FACTORYCODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" GROUP BY A.PICK,A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO,SALES_DATE, ")
                .Append(" A.WESTPER,A.FABRIC_ITEMCODE, A.BOOKVNO,A.ACCOUNTCODE,F.CITYCODE,F.ACCOUNTNAME, ")
                If ExistPkRtPrRtFld = True Then
                    .Append(" A.PICKRATE, ")
                End If
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME ")
                .Append(" ,A.BEAMNO ")
                .Append(" UNION ALL ")

                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" ROUND(SUM(A.GMTR),3) AS MTR_WEIGHT, ")
                .Append(" ROUND(SUM(A.WEIGHT),4) AS WEIGHT, ")
                .Append(" '' AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.GREY_RCPT_ACCOUNT_CODE AS ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" '' AS PROCESSCODE, ")
                .Append(" '' AS PROCESSNAME, ")
                .Append(" 0 AS PICK, ")
                .Append(" 0 AS PICK_RATE,0 AS MENDING_RATE, ")
                .Append(" ROUND((ROUND(SUM(A.WEIGHT),4)* A.WESTPER)/100,4) AS WEST_WEIGHT, ")
                .Append(" A.CHALLANDATE ")
                .Append(" ,A.BEAMNO ")
                .Append(" FROM TRNGREYRCPT AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
                .Append(" MSTCITY AS G,MstMasterAccount AS H ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.GREY_RCPT_ACCOUNT_CODE=F.ACCOUNTCODE ")
                .Append(" AND F.CITYCODE=G.CITYCODE ")
                .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(" AND A.GREY_RCPT_ACCOUNT_CODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(" AND (A.BOOKCODE='0001-000000062' OR A.BOOKCODE='0001-000000063') ")
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO, ")
                .Append(" A.WESTPER,A.FABRIC_ITEMCODE, A.BOOKVNO,A.GREY_RCPT_ACCOUNT_CODE,F.CITYCODE,F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE ")
                .Append(" ,A.BEAMNO ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL K ON (Z.BOOKVNO=K.CHALLANBOOKVNO AND K.BOOKCODE='" & _BookCode & "') ")


                .Append(" LEFT JOIN TrnRateContract AS L ON Z.BEAMNO = CAST(L.RDVALUE AS NVARCHAR) ")
                .Append(" And Z.ACCOUNTCODE=L.ACCOUNTCODE ")
                .Append(" And Z.BEAMNO= CAST(L.RDVALUE AS NVARCHAR) ")

                .Append(" WHERE 1=1 AND K.CHALLANBOOKVNO IS NULL ")
                .Append(" ORDER BY Z.CHALLANDATE,Z.BOOKVNO,Z.ITENNAME,Z.CHALLANNO ")
            ElseIf _BookNature = "JOB-RCPT" Then
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.GMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" A.PICK, ")
                .Append(" J.PICK_RATE,J.MENDING_RATE, ")
                .Append(" ROUND((ROUND(SUM(A.WEIGHT),4)* A.WESTPER)/100,4) AS WEST_WEIGHT ")
                .Append(" ,ISNULL(A.OP1,'')  AS UNITCODE ")
                .Append(" FROM ((((((TRNGREYDESP AS A ")
                .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.FABRIC_ITEMCODE=C.ID) ")
                .Append(" LEFT JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE) ")
                .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE) ")
                .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE) ")
                .Append(" LEFT JOIN MstMasterAccount AS I ON A.PROCESSCODE=I.ACCOUNTCODE) ")
                .Append(" LEFT JOIN TRNBEAMHEADER AS J ON A.BEAMNO=J.BEAMNO) ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL AS M ON A.BOOKVNO=M.CHALLANBOOKVNO ")
                '.Append(" FROM TRNGREYDESP AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
                '.Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
                '.Append(" ,TRNBEAMHEADER AS J ")
                .Append(" WHERE 1=1 ")
                '.Append(" AND A.BEAMNO=J.BEAMNO ")
                '.Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
                '.Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
                '.Append(" AND F.CITYCODE=G.CITYCODE ")
                '.Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                '.Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(" AND M.CHALLANBOOKVNO IS NULL ")
                '.Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
                .Append(" GROUP BY A.WESTPER,A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO,SALES_DATE, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,A.ACCOUNTCODE,F.CITYCODE,F.ACCOUNTNAME,A.PICK, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME, ")
                .Append(" J.PICK_RATE,J.MENDING_RATE ,A.OP1")
                .Append(" ORDER BY A.CHALLANDATE,A.CHALLANNO, C.ITENNAME ")
            End If
        End With
        Return strQuery.ToString
    End Function





    Public Function EntryData_Job_Invoice_Entry_txtUse_Challan_Validated(ByVal _BookNature As String, ByVal _BookCode As String, ByVal AccountCode As String, ByVal Str_In_Challan_Book As String, ByVal BillDate As String) As String
        Dim ExistPkRtPrRtFld As Boolean = DoesFieldExist("TRNGREYDESP", "PICKRATE")
        strQuery = New StringBuilder
        With strQuery
            If _BookNature = "JOB-PAID" Then
                .Append(" SELECT Z.* ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" ROUND(SUM(A.GMTR),3) AS MTR_WEIGHT, ")
                .Append(" ROUND(SUM(A.WEIGHT),4) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" A.PICK, ")
                If ExistPkRtPrRtFld = True Then
                    .Append(" A.PICKRATE AS PICK_RATE, ")
                Else
                    .Append(" (0.0) AS PICK_RATE, ")
                End If
                .Append(" 0 AS MENDING_RATE, ")
                .Append(" ROUND((ROUND(SUM(A.WEIGHT),4)* A.WESTPER)/100,4) AS WEST_WEIGHT, ")
                .Append(" A.CHALLANDATE ")
                .Append(" FROM TRNGREYDESP AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
                .Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
                .Append(" AND F.CITYCODE=G.CITYCODE ")
                .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(" AND A.FACTORYCODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" GROUP BY A.PICK,A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO,SALES_DATE, ")
                .Append(" A.WESTPER,A.FABRIC_ITEMCODE, A.BOOKVNO,A.ACCOUNTCODE,F.CITYCODE,F.ACCOUNTNAME, ")
                If ExistPkRtPrRtFld = True Then
                    .Append(" A.PICKRATE, ")
                End If
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME ")

                .Append(" UNION ALL ")

                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" ROUND(SUM(A.GMTR),3) AS MTR_WEIGHT, ")
                .Append(" ROUND(SUM(A.WEIGHT),4) AS WEIGHT, ")
                .Append(" '' AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.GREY_RCPT_ACCOUNT_CODE AS ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.ProcessCode AS PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" a.PICK, ")
                .Append(" 0 AS PICK_RATE,0 AS MENDING_RATE, ")
                .Append(" ROUND((ROUND(SUM(A.WEIGHT),4)* A.WESTPER)/100,4) AS WEST_WEIGHT, ")
                .Append(" A.CHALLANDATE ")
                .Append(" FROM TRNGREYRCPT AS A ")
                .Append(" LEFT JOIN MSTFABRICITEM AS C  ON A.FABRIC_ITEMCODE=C.ID ")
                .Append(" Left JOIN MstMasterAccount AS F ON A.GREY_RCPT_ACCOUNT_CODE=F.ACCOUNTCODE  ")
                .Append(" LEFT JOIN  MSTCITY AS G ON  F.CITYCODE=G.CITYCODE  ")
                .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MstMasterAccount AS I ON A.ProcessCode=I.ACCOUNTCODE  ")
                .Append(" WHERE 1=1 ")
                '.Append(" AND A.GREY_RCPT_ACCOUNT_CODE=F.ACCOUNTCODE ")
                '.Append(" AND F.CITYCODE=G.CITYCODE ")
                '.Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                '.Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(" AND A.GREY_RCPT_ACCOUNT_CODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(" AND (A.BOOKCODE='0001-000000062' OR A.BOOKCODE='0001-000000063') ")
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO, ")
                .Append(" A.WESTPER,A.FABRIC_ITEMCODE, A.BOOKVNO,A.GREY_RCPT_ACCOUNT_CODE,F.CITYCODE,F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,a.PICK ")
                .Append(" ,A.ProcessCode ")
                .Append(" ,I.ACCOUNTNAME")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL K ON (Z.BOOKVNO=K.CHALLANBOOKVNO AND K.BOOKCODE='" & _BookCode & "') ")
                .Append(" WHERE 1=1 AND K.CHALLANBOOKVNO IS NULL ")
                .Append(" ORDER BY Z.CHALLANDATE,Z.BOOKVNO,Z.ITENNAME,Z.CHALLANNO ")
            ElseIf _BookNature = "JOB-RCPT" Then
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.GMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" A.PICK, ")
                .Append(" J.PICK_RATE,J.MENDING_RATE, ")
                .Append(" ROUND((ROUND(SUM(A.WEIGHT),4)* A.WESTPER)/100,4) AS WEST_WEIGHT ")
                .Append(" ,ISNULL(A.OP1,'')  AS UNITCODE ")
                .Append(" FROM ((((((TRNGREYDESP AS A ")
                .Append(" LEFT JOIN  MSTFABRICITEM AS C ON A.FABRIC_ITEMCODE=C.ID) ")
                .Append(" LEFT JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE) ")
                .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE) ")
                .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE) ")
                .Append(" LEFT JOIN MstMasterAccount AS I ON A.PROCESSCODE=I.ACCOUNTCODE) ")
                .Append(" LEFT JOIN TRNBEAMHEADER AS J ON A.BEAMNO=J.BEAMNO) ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL AS M ON A.BOOKVNO=M.CHALLANBOOKVNO ")
                '.Append(" FROM TRNGREYDESP AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
                '.Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
                '.Append(" ,TRNBEAMHEADER AS J ")
                .Append(" WHERE 1=1 ")
                '.Append(" AND A.BEAMNO=J.BEAMNO ")
                '.Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
                '.Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
                '.Append(" AND F.CITYCODE=G.CITYCODE ")
                '.Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                '.Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(" AND M.CHALLANBOOKVNO IS NULL ")
                '.Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
                .Append(" GROUP BY A.WESTPER,A.CHALLANNO, A.CHALLANDATE,C.ITENNAME,A.SALES_CHALLAN_NO,SALES_DATE, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,A.ACCOUNTCODE,F.CITYCODE,F.ACCOUNTNAME,A.PICK, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME, ")
                .Append(" J.PICK_RATE,J.MENDING_RATE ,A.OP1")
                .Append(" ORDER BY A.CHALLANDATE,A.CHALLANNO, C.ITENNAME ")
            End If
        End With
        Return strQuery.ToString
    End Function

    Public Function _QueryChallanEmbroideryModule(ByVal BookNaure As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Str_In_Challan_Book As String, ByVal Rate_By As String) As String

        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" Z.* ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" (A.Bill_Chl_Date) AS F_CHALLANDATE, ")
            .Append(" 'LUMP' AS CUTNAME, ")
            .Append(" C.ITENNAME, ")
            .Append(" SUM(A.PCS) AS PCS, ")
            .Append(" SUM(A.CHECKED_MTR) AS MTR_WEIGHT, ")
            .Append(" 0.00 AS WEIGHT, ")
            .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
            .Append(" '' AS TRANSPORTNAME, ")
            .Append(" iif(A.OP52='','MTR',A.OP52) AS RATEON, ")
            .Append(" '' AS TRANSPORTCODE, ")
            .Append(" '' AS ACOFCODE, ")
            .Append(" '0000-000000007' AS CUTCODE, ")
            .Append(" A.ItemCode AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE AS ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.ACCOUNTCODE AS PROCESSCODE, ")
            .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
            .Append(" 0 AS PICK, ")
            .Append(" A.Tmp_Pcs AS PICK_RATE, ")
            .Append(" A.Bill_Chl_Date AS CHALLANDATE ")
            .Append(" ,C.DESCRP ")
            .Append(" ,'' AS FACTORYCODE ")
            .Append("   ,0.00 AS PCAVGWT ")
            .Append(" FROM trnGrading AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
            .Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
            '.Append(" ,TrnPrinting_JobProducation AS J ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=I.ACCOUNTCODE ")
            .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.ItemCode=C.ID ")
            '.Append(" AND A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")
            '.Append(" AND A.Lump_ID=J.Lump_ID ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.Bill_Chl_Date<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)

            .Append(" GROUP BY A.CHALLANNO, A.Bill_Chl_Date,C.ITENNAME, ")
            .Append(" A.ItemCode, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.ACCOUNTCODE,I.ACCOUNTNAME ")
            .Append(" ,C.DESCRP ")
            .Append(" ,A.Tmp_Pcs")
            .Append(" ,A.OP52")
            .Append(" ) ")
            .Append(" AS Z ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
            .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
            .Append(" ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME ")
        End With
        Return strQuery.ToString
    End Function


    Public Function EntryData_Process_Invoice_PrintingModule(ByVal BookNaure As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Str_In_Challan_Book As String, ByVal Rate_By As String) As String

        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" Z.* ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
            .Append(" 'LUMP' AS CUTNAME, ")
            .Append(" C.ITENNAME, ")
            .Append(" COUNT(A.PIECENO) AS PCS, ")
            .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
            .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
            .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
            .Append(" '' AS TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" '' AS TRANSPORTCODE, ")
            .Append(" '' AS ACOFCODE, ")
            .Append(" '0000-000000007' AS CUTCODE, ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.PROCESSCODE AS ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.PROCESSCODE, ")
            .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
            .Append(" 0 AS PICK, ")
            .Append(" J.PROCESSRATE AS PICK_RATE, ")
            .Append(" A.CHALLANDATE ")
            .Append(" ,C.DESCRP ")
            .Append(" ,'' AS FACTORYCODE ")
            .Append("   ,0.00 AS PCAVGWT ")
            .Append(" FROM TrnPrinting_SalesChallan AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
            .Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
            .Append(" ,TrnPrinting_JobProducation AS J ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
            .Append(" AND A.PROCESSCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.FABRIC_ITEMCODE=C.ID ")
            '.Append(" AND A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")
            .Append(" AND A.Lump_ID=J.Lump_ID ")
            .Append(" AND A.PROCESSCODE='" & AccountCode & "'")
            .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)

            .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
            .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME,J.PROCESSRATE ")
            .Append(" ,C.DESCRP ")
            .Append(" ) ")
            .Append(" AS Z ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
            .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
            .Append(" ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME ")
        End With
        Return strQuery.ToString
    End Function


    Public Function EntryData_Process_Invoice_ProcessModule(ByVal BookNaure As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Str_In_Challan_Book As String, ByVal Rate_By As String, ByVal _ChallShowAvgWtWise As String, ByVal _GeyChallanNoWise As String, ByVal _ChallanUseFor As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT*FROM( ")

#Region "Process Module"
            .Append(" SELECT Z.*FROM( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
            .Append(" 'LUMP' AS CUTNAME, ")
            .Append(" C.ITENNAME, ")
            .Append(" COUNT(A.PIECENO) AS PCS, ")
            .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
            .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
            .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
            .Append(" '' AS TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" '' AS TRANSPORTCODE, ")
            .Append(" '' AS ACOFCODE, ")
            .Append(" '0000-000000007' AS CUTCODE, ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.PROCESSCODE AS ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.PROCESSCODE, ")
            .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
            .Append(" 0 AS PICK, ")
            .Append(" isnull(J.PROCESSRATE,0) AS PICK_RATE, ")
            .Append(" A.CHALLANDATE ")
            .Append(" ,'' as  DESCRP ")
            .Append(" ,'' as FACTORYCODE ")

            If _ChallShowAvgWtWise = "NO" Then
                .Append(" ,0.00 AS PCAVGWT ")
            Else
                .Append(" ,J.PCAVGWT ")
            End If
            .Append(" ,'' as Baleno ")
            .Append(" ,'' as Lotno ")
            .Append(" ,0.00 as Than ")
            .Append(" ,0.00 as FinishMtr ")
            .Append(" ,0.00 as FoldShkMtr ")
            .Append(" ,0.00 as AvgThanMtr ")
            .Append(" ,'' AS GreyChallnDate ")
            .Append(" ,'' AS LRNO  ")
            .Append(" ,'' AS QUALITYNAME ")
            .Append(" ,'' AS COLOR  ")
            .Append(" ,'' AS EWAYBILLNO  ")

            If _GeyChallanNoWise = "YES" Then
                .Append(" ,A.Process_OT1 AS GreyChallanNo ")
                .Append(" ,FORMAT(A.OP21,'dd/MM/yyyy') AS GreyChallanDate ")
            Else
                .Append(" , ''  AS GreyChallanNo")
                .Append(" , '' as GreyChallanDate")
            End If

            .Append(" FROM TrnFinishRcpt_Process AS A")
            .Append(" LEFT JOIN MSTFABRICITEM AS C ON A.FABRIC_ITEMCODE=C.ID ")
            .Append(" LEFT JOIN MstMasterAccount AS F ON A.PROCESSCODE=F.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE ")
            .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE")
            .Append(" LEFT JOIN MstMasterAccount AS I ON A.PROCESSCODE=I.ACCOUNTCODE")
            .Append(" LEFT JOIN TrnGreyDesp_Process AS J  ON A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")

            .Append(" WHERE 1=1 ")
            .Append(" AND A.PROCESSCODE='" & AccountCode & "' ")
            .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
            .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME,isnull(J.PROCESSRATE,0), ")
            .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME ")




            If _ChallShowAvgWtWise <> "NO" Then
                .Append(" ,J.PCAVGWT ")
            End If

            If _GeyChallanNoWise = "YES" Then
                .Append(" ,A.Process_OT1 ")
                .Append(" ,A.OP21 ")
            End If

            .Append(" ) ")
            .Append(" AS Z ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
            .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
#End Region

            .Append(" UNION ALL ")

#Region "Rayon Module"
            .Append(" SELECT Z.* FROM ( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
            .Append(" 'LUMP' AS CUTNAME, ")
            .Append(" C.ITENNAME, ")
            .Append(" sum(A.DPR_RCPT_MTR) AS PCS, ")
            .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
            .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
            .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
            .Append(" '' AS TRANSPORTNAME, ")
            .Append(" ISNULL(A.Grey_Fold_Pcs_ID,'MTR') AS RATEON, ")
            .Append(" '' AS TRANSPORTCODE, ")
            .Append(" '' AS ACOFCODE, ")
            .Append(" '0000-000000007' AS CUTCODE, ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.PROCESSCODE AS ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.PROCESSCODE, ")
            .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
            .Append(" 0 AS PICK, ")
            .Append(" A.OP16 AS PICK_RATE, ")
            .Append(" A.CHALLANDATE as CHALLANDATE ")
            .Append(" ,'' as  DESCRP ")
            .Append(" ,'' as FACTORYCODE ")
            .Append(" ,0.00 as PCAVGWT ")
            .Append(" ,A.OP4 as Baleno ")
            .Append(" ,A.PROC_BEAMNO as Lotno ")
            .Append(" ,A.DPR_RCPT_MTR as Than ")
            .Append(" ,A.OP11 as FinishMtr ")
            .Append(" ,A.OP14 as FoldShkMtr ")
            .Append(" ,A.Grey_Transfer_Paid_Mtr as AvgThanMtr ")
            .Append(" ,A.OP6 AS GreyChallnDate ")
            .Append(" ,A.OP5 AS LRNO  ")
            .Append(" ,K.fabric_GroupName AS QUALITYNAME ")
            .Append(" ,A.OP8 AS COLOR  ")
            .Append(" ,A.Process_OT2 AS EWAYBILLNO  ")
            .Append(" ,''  AS GreyChallanNo")
            .Append(" ,'' as GreyChallanDate")
            .Append(" FROM Trn_Rayon_FinishRcpt_Process AS A")
            .Append(" LEFT JOIN MSTFABRICITEM AS C ON  A.FABRIC_ITEMCODE=C.ID")
            .Append(" LEFT JOIN MstMasterAccount AS F ON A.PROCESSCODE=F.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE")
            .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE")
            .Append(" Left JOIN MstMasterAccount AS I ON A.PROCESSCODE=I.ACCOUNTCODE ")
            .Append(" LEFT JOIN Trn_Rayon_GreyDesp_Process AS J ON A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID")
            .Append(" LEFT JOIN MstFabricGroup AS K  ON A.ProcessCode_Transfer=K.ID")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.PROCESSCODE='" & AccountCode & "' ")
            .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
            .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME,A.OP16 ")
            '.Append(" ,J.FACTORYCODE ")
            '.Append(" ,J.PCAVGWT ")
            .Append(" ,A.OP4 ")
            .Append(" ,A.PROC_BEAMNO ")
            .Append(" ,A.DPR_RCPT_MTR ")
            .Append(" ,A.OP11 ")
            .Append(" ,A.OP14 ")
            .Append(" ,A.OP6 ")
            .Append(" ,A.OP5 ")
            .Append(" ,A.OP8 ")
            .Append(" ,A.Grey_Fold_Pcs_ID ")
            .Append(" ,A.Grey_Transfer_Paid_Mtr ")
            .Append(" ,A.Process_OT2 ")
            .Append(" ,K.fabric_GroupName ")
            .Append(" )  AS Z ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
            .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
#End Region

            .Append(" UNION ALL ")

#Region "process Charge In Packing Slip Challan Embrodary"

            .Append(" SELECT Z.* FROM ( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.PACK_SLIP_NO AS CHALLANNO, ")
            .Append(" (A.PACK_SLIP_DATE) AS F_CHALLANDATE, ")
            .Append(" 'LUMP' AS CUTNAME, ")
            .Append(" C.ITENNAME, ")
            .Append(" sum(A.PCS) AS PCS, ")
            .Append(" SUM(A.MTR_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.RDVALUE) AS WEIGHT, ")
            .Append(" '' AS ACOFNAME, ")
            .Append(" '' AS TRANSPORTNAME, ")
            .Append(" ISNULL(A.RATEON,'MTR') AS RATEON, ")
            .Append(" '' AS TRANSPORTCODE, ")
            .Append(" '' AS ACOFCODE, ")
            .Append(" '0000-000000007' AS CUTCODE, ")
            .Append(" A.ITEMCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE AS ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.RATE AS RATE, ")
            .Append(" '' AS PROCESSCODE, ")
            .Append(" '' AS PROCESSNAME, ")
            .Append(" 0 AS PICK, ")
            .Append(" A.RATE AS PICK_RATE, ")
            .Append(" A.PACK_SLIP_DATE as CHALLANDATE ")
            .Append(" ,'' as  DESCRP ")
            .Append(" ,'' as FACTORYCODE ")
            .Append(" ,0.00 as PCAVGWT ")
            .Append(" ,'' as Baleno ")
            .Append(" ,'' as Lotno ")
            .Append(" ,0.00 as Than ")
            .Append(" ,0.00 as FinishMtr ")
            .Append(" ,0.00 as FoldShkMtr ")
            .Append(" ,0.00 as AvgThanMtr ")
            .Append(" ,'' AS GreyChallnDate ")
            .Append(" ,'' AS LRNO  ")
            .Append(" ,'' AS QUALITYNAME ")
            .Append(" ,'' AS COLOR  ")
            .Append(" ,'' AS EWAYBILLNO  ")
            .Append(" ,''  AS GreyChallanNo")
            .Append(" ,'' as GreyChallanDate")
            .Append(" FROM TrnPackingSlip AS A")
            .Append(" LEFT JOIN MSTFABRICITEM AS C ON  A.ITEMCODE=C.ID")
            .Append(" LEFT JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS G ON F.CITYCODE=G.CITYCODE")
            .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
            .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" GROUP BY A.PACK_SLIP_NO, A.PACK_SLIP_DATE,C.ITENNAME, ")
            .Append(" A.ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.ACCOUNTCODE ")
            .Append(" ,A.RATE ")
            .Append(" ,A.RATEON ")
            .Append(" )  AS Z ")
            .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
            .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
#End Region

            .Append(" ) AS Z ")
            If _ChallanUseFor = "RAYON" Then
                .Append(" ORDER BY Z.ITENNAME,z.Baleno,Z.CHALLANDATE,Z.CHALLANNO  ")
            Else
                .Append(" ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME ")
            End If

        End With


        Return strQuery.ToString

    End Function
    Public Function EntryData_Process_Invoice_RayonModule(ByVal BookNaure As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Str_In_Challan_Book As String, ByVal Rate_By As String) As String

        'strQuery = New StringBuilder
        'With strQuery
        '    .Append(" SELECT ")
        '    .Append(" Z.* ")
        '    .Append(" FROM ")
        '    .Append(" ( ")
        '    .Append(" SELECT ")
        '    .Append(" SPACE(1) AS MARK, ")
        '    .Append(" A.CHALLANNO AS CHALLANNO, ")
        '    .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
        '    .Append(" 'LUMP' AS CUTNAME, ")
        '    .Append(" C.ITENNAME, ")
        '    .Append(" sum(A.DPR_RCPT_MTR) AS PCS, ")
        '    .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
        '    .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
        '    .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
        '    .Append(" '' AS TRANSPORTNAME, ")
        '    .Append(" ISNULL(A.Grey_Fold_Pcs_ID,'MTR') AS RATEON, ")
        '    .Append(" '' AS TRANSPORTCODE, ")
        '    .Append(" '' AS ACOFCODE, ")
        '    .Append(" '0000-000000007' AS CUTCODE, ")
        '    .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
        '    .Append(" A.BOOKVNO, ")
        '    .Append(" A.PROCESSCODE AS ACCOUNTCODE, ")
        '    .Append(" F.CITYCODE AS DESPATCHCODE, ")
        '    .Append(" F.ACCOUNTNAME, ")
        '    .Append(" G.CITYNAME AS DESPATCH, ")
        '    .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
        '    .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
        '    .Append(" 0 AS RATE, ")
        '    .Append(" A.PROCESSCODE, ")
        '    .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
        '    .Append(" 0 AS PICK, ")
        '    .Append(" A.OP16 AS PICK_RATE, ")
        '    .Append("  FORMAT (A.CHALLANDATE,'dd/MM/yyyy') as CHALLANDATE ")
        '    .Append("   ,'' as  DESCRP ")
        '    .Append(" ,J.FACTORYCODE ")
        '    .Append(" ,J.PCAVGWT ")
        '    .Append(" ,A.OP4 as Baleno ")
        '    .Append(" ,A.PROC_BEAMNO as Lotno ")
        '    .Append(" ,A.DPR_RCPT_MTR as Than ")
        '    .Append(" ,A.OP11 as FinishMtr ")
        '    .Append(" ,A.OP14 as FoldShkMtr ")
        '    .Append(" ,A.Grey_Transfer_Paid_Mtr as AvgThanMtr ")
        '    .Append(" ,A.OP6 AS GreyChallnDate ") '38
        '    .Append(" ,A.OP5 AS LRNO ") '39
        '    .Append(" ,K.fabric_GroupName AS QUALITYNAME ") '40
        '    .Append(" ,A.OP8 AS COLOR ") '41

        '    .Append(" FROM Trn_Rayon_FinishRcpt_Process AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
        '    .Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I ")
        '    .Append(" ,Trn_Rayon_GreyDesp_Process AS J ")
        '    .Append(" ,MstFabricGroup AS K ")
        '    .Append(" WHERE 1=1 ")
        '    .Append(" AND A.ProcessCode_Transfer=K.ID ")
        '    .Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
        '    .Append(" AND A.PROCESSCODE=F.ACCOUNTCODE ")
        '    .Append(" AND F.CITYCODE=G.CITYCODE ")
        '    .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
        '    .Append(" AND A.FABRIC_ITEMCODE=C.ID ")
        '    .Append(" AND A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")
        '    .Append(" AND A.PROCESSCODE='" & AccountCode & "'")
        '    .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
        '    .Append(Str_In_Challan_Book)

        '    .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
        '    .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, ")
        '    .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME,A.OP16 ")
        '    .Append(" ,J.FACTORYCODE ")
        '    .Append(" ,J.PCAVGWT ")
        '    .Append(" ,A.OP4")
        '    .Append(" ,A.PROC_BEAMNO")
        '    .Append(" ,A.DPR_RCPT_MTR")
        '    .Append(" ,A.OP11")
        '    .Append(" ,A.OP14")
        '    .Append(" ,A.OP6")
        '    .Append(" ,A.OP5")
        '    .Append(" ,A.OP8")
        '    .Append(" ,A.Grey_Fold_Pcs_ID")
        '    .Append(" ,A.Grey_Transfer_Paid_Mtr")
        '    .Append(" ,K.fabric_GroupName ")
        '    .Append(" ) ")
        '    .Append(" AS Z ")
        '    .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
        '    .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
        '    .Append(" ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME ")

        'End With

        'Return strQuery.ToString

    End Function
    Public Function EntryData_Process_Invoice_txtUse_Challan_Validated(ByVal BookNaure As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Str_In_Challan_Book As String, ByVal Rate_By As String) As String
        strQuery = New StringBuilder
        With strQuery

            If Rate_By = "GREY CHALLAN" Then
                .Append(" SELECT ")
                .Append(" Z.* ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.PROCESSCODE AS ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" 0 AS PICK, ")
                .Append(" J.PROCESSRATE AS PICK_RATE, ")
                .Append(" A.CHALLANDATE ")
                .Append(" ,'' as  DESCRP ")
                .Append(" ,J.FACTORYCODE ")
                .Append("   ,0.00 AS PCAVGWT ")
                .Append(" FROM TRNFINISHRCPT AS A,MSTFABRICITEM AS C,MstMasterAccount AS F, ")
                .Append(" MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount AS I,TRNGREYDESP AS J ")
                .Append(" WHERE 1=1 AND A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")
                .Append(" AND A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" AND A.PROCESSCODE=F.ACCOUNTCODE ")
                .Append(" AND F.CITYCODE=G.CITYCODE ")
                .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" AND A.FABRIC_ITEMCODE=C.ID ")
                .Append(" AND A.PROCESSCODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME,J.PROCESSRATE, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME ")
                .Append(" ,J.FACTORYCODE ")
                .Append(" ) ")
                .Append(" AS Z ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
                .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
                .Append(" ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME ")

            ElseIf Rate_By = "PROCESS RATE CONTRACT" Then

                .Append("  	SELECT 	  ")
                .Append("  	Z.* 	  ")
                .Append("  	FROM 	  ")
                .Append("  	( 	  ")
                .Append("  	SELECT 	  ")
                .Append("  	SPACE(1) AS MARK, 	  ")
                .Append("  	A.CHALLANNO AS CHALLANNO, 	  ")
                .Append("  	(A.CHALLANDATE) AS F_CHALLANDATE, 	  ")
                .Append("  	'LUMP' AS CUTNAME, 	  ")
                .Append("  	C.ITENNAME, 	  ")
                .Append("  	COUNT(A.PIECENO) AS PCS, 	  ")
                .Append("  	SUM(A.PMTR) AS MTR_WEIGHT, 	  ")
                .Append("  	SUM(A.WEIGHT) AS WEIGHT, 	  ")
                .Append("  	I.ACCOUNTNAME AS ACOFNAME, 	  ")
                .Append("  	'' AS TRANSPORTNAME, 	  ")
                .Append("  	'MTR' AS RATEON, 	  ")
                .Append("  	'' AS TRANSPORTCODE, 	  ")
                .Append("  	'' AS ACOFCODE, 	  ")
                .Append("  	'0000-000000007' AS CUTCODE, 	  ")
                .Append("  	A.FABRIC_ITEMCODE AS ITEMCODE, 	  ")
                .Append("  	A.BOOKVNO, 	  ")
                .Append("  	A.PROCESSCODE AS ACCOUNTCODE, 	  ")
                .Append("  	F.CITYCODE AS DESPATCHCODE, 	  ")
                .Append("  	F.ACCOUNTNAME, 	  ")
                .Append("  	G.CITYNAME AS DESPATCH, 	  ")
                .Append("  	H.ACCOUNTCODE AS AGENTCODE, 	  ")
                .Append("  	H.ACCOUNTNAME AS AGENTNAME, 	  ")
                .Append("  	0 AS RATE, 	  ")
                .Append("  	A.PROCESSCODE, 	  ")
                .Append("  	I.ACCOUNTNAME AS PROCESSNAME, 	  ")
                .Append("  	0 AS PICK, 	  ")
                .Append("  	K.PROCESS_NET_RATE  AS PICK_RATE, 	  ")
                .Append("  	A.CHALLANDATE 	  ")
                .Append(" ,'' as  DESCRP ")
                .Append(" ,J.FACTORYCODE ")
                .Append("   ,0.00 AS PCAVGWT ")
                .Append(" FROM TRNFINISHRCPT AS A ")
                .Append(" LEFT JOIN MSTFABRICITEM AS C ON A.FABRIC_ITEMCODE=C.ID ")
                .Append(" LEFT JOIN MstMasterAccount AS F ON A.PROCESSCODE=F.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS I ON A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" LEFT JOIN TRNGREYDESP AS J ON  A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")
                .Append(" LEFT JOIN TrnRateContract AS K ON (J.FD_PD=K.RDON ")
                .Append(" AND J.CHALLANDATE<=K.DATE_TO ")
                .Append(" AND J.CHALLANDATE>=K.OFFERDATE ")
                .Append(" AND A.PROCESSCODE=K.AccountCode ")
                .Append(" AND A.FABRIC_ITEMCODE=K.ItemCode) ")
                .Append(" WHERE 1=1 ")
                .Append("   AND A.PROCESSCODE='" & AccountCode & "'")
                .Append("   AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append("  	GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, 	  ")
                .Append("  	A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, 	  ")
                .Append("  	G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME 	  ")
                .Append("  	,K.PROCESS_NET_RATE 	  ")
                .Append(" ,J.FACTORYCODE ")

                .Append("  	) 	  ")
                .Append("  	AS Z 	  ")
                .Append("  	LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO 	  ")
                .Append("  	WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL 	  ")
                .Append("  	ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME 	  ")
            Else
                .Append(" SELECT ")
                .Append(" Z.* ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" A.CHALLANNO AS CHALLANNO, ")
                .Append(" (A.CHALLANDATE) AS F_CHALLANDATE, ")
                .Append(" 'LUMP' AS CUTNAME, ")
                .Append(" C.ITENNAME, ")
                .Append(" COUNT(A.PIECENO) AS PCS, ")
                .Append(" SUM(A.PMTR) AS MTR_WEIGHT, ")
                .Append(" SUM(A.WEIGHT) AS WEIGHT, ")
                .Append(" I.ACCOUNTNAME AS ACOFNAME, ")
                .Append(" '' AS TRANSPORTNAME, ")
                .Append(" 'MTR' AS RATEON, ")
                .Append(" '' AS TRANSPORTCODE, ")
                .Append(" '' AS ACOFCODE, ")
                .Append(" '0000-000000007' AS CUTCODE, ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.PROCESSCODE AS ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" 0 AS RATE, ")
                .Append(" A.PROCESSCODE, ")
                .Append(" I.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" 0 AS PICK, ")
                .Append(" A.Grey_Transfer_Rcpt_Mtr AS PICK_RATE, ")
                .Append(" A.CHALLANDATE ")
                .Append(" ,STUFF((SELECT DISTINCT ', ' + B.PROC_BEAMNO ")
                .Append(" From TRNFINISHRCPT B Where B.CHALLANNO = A.CHALLANNO AND B.FABRIC_ITEMCODE = A.FABRIC_ITEMCODE ")
                .Append(" For Xml PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1, 2, '') AS DESCRP ")
                .Append(" ,'' as FACTORYCODE ")
                .Append("   ,0.00 AS PCAVGWT ")
                .Append(" FROM TRNFINISHRCPT AS A ")
                .Append(" LEFT JOIN MSTFABRICITEM AS C  ON  A.FABRIC_ITEMCODE=C.ID")
                .Append(" LEFT JOIN MstMasterAccount AS F ON  A.PROCESSCODE=F.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MSTCITY AS G  ON F.CITYCODE=G.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS H  ON F.AGENTCODE=H.ACCOUNTCODE  ")
                .Append(" Left JOIN MstMasterAccount AS I ON  A.PROCESSCODE=I.ACCOUNTCODE ")
                .Append(" Left JOIN TRNGREYDESP AS J  ON  A.GREY_DESP_PCS_ID=J.GREY_DESP_PCS_ID ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.PROCESSCODE='" & AccountCode & "'")
                .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" GROUP BY A.CHALLANNO, A.CHALLANDATE,C.ITENNAME, ")
                .Append(" A.FABRIC_ITEMCODE, A.BOOKVNO,F.CITYCODE,F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,A.PROCESSCODE,I.ACCOUNTNAME,A.Grey_Transfer_Rcpt_Mtr ")
                '.Append(" ,a.PROC_BEAMNO ")
                '.Append(" ,J.FACTORYCODE ")

                .Append(" ) ")
                .Append(" AS Z ")
                .Append(" LEFT JOIN TRNINVOICEDETAIL A ON A.CHALLANBOOKVNO=Z.BOOKVNO ")
                .Append(" WHERE 1=1 AND A.CHALLANBOOKVNO IS NULL ")
                .Append(" ORDER BY Z.CHALLANDATE,Z.CHALLANNO, Z.ITENNAME ")
            End If
        End With

        Return strQuery.ToString
    End Function

    Public Function Process_Challan_Entry_Alter_Form_Qry(ByVal _BookCode As String, ByVal strKeyID As String, ByVal entry_no As String) As String
        _strQuery = New StringBuilder
        If entry_no = 0 Then entry_no = strKeyID
        With _strQuery
            .Append(" SELECT A.*, ")
            .Append(" convert(varchar,  A.GPDATE, 103) AS F_GPDATE, ")
            .Append(" convert(varchar,  A.CHALLANDATE, 103) AS F_CHALLANDATE, ")
            .Append(" B.ACCOUNTNAME AS PROCESSNAME,E.ITENNAME AS FABRIC_ITEMNAME, ")
            .Append(" H.GMTR AS ORG_MTR,E.MAXSHRINK AS MAX_SHRINK_PER,H.CHALLANNO AS GREY_CHALLAN_NO, ")
            .Append(" F.Design_Name AS FABRIC_DESIGN_NO, G.SHADE AS FABRIC_SHADE_NO,I.ACCOUNTNAME AS GODOWNNAME ")
            .Append(" ,J.SELVEDGE_NAME AS SELVEDGENAME ")
            .Append(" ,K.ITENNAME AS FINISHITEMNAME ")


            .Append(" FROM TRNFINISHRCPT AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B  ON A.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTFABRICITEM AS E  ON A.FABRIC_ITEMCODE=E.ID  ")
            .Append(" LEFT JOIN  Mst_Fabric_Design AS F  ON A.FABRIC_DESIGNCODE=F.Design_code  ")
            .Append(" LEFT JOIN  Mst_Fabric_Shade AS G  ON   A.FABRIC_SHADECODE=G.ID ")
            .Append(" LEFT JOIN  TRNGREYDESP AS H   ON  A.GREY_DESP_PCS_ID=H.GREY_DESP_PCS_ID  ")
            .Append(" Left JOIN MstMasterAccount AS I  ON  A.GODOWNCODE=I.ACCOUNTCODE ")
            .Append(" LEFT JOIN  Mst_selvedge AS J   ON A.LRNO=J.ID  ")
            .Append(" LEFT JOIN MSTFABRICITEM AS K  ON A.OP7=K.ID  ")
            .Append(" WHERE 1=1  ")
            '.Append(" AND A.PROCESSCODE=B.ACCOUNTCODE ")
            '.Append(" AND A.FABRIC_ITEMCODE=E.ID ")
            '.Append(" AND A.FABRIC_DESIGNCODE=F.Design_code ")
            '.Append(" AND A.FABRIC_SHADECODE=G.ID ")
            '.Append(" AND A.LRNO=J.ID ")

            '.Append(" AND A.GREY_DESP_PCS_ID=H.GREY_DESP_PCS_ID ")
            '.Append(" AND A.GODOWNCODE=I.ACCOUNTCODE ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & "  ")
            .Append(" AND H.Bookcode<>'0001-000000114' ") 'SALES - BY GREY RETURN FROM P.H.
            .Append(" AND A.ENTRYNO='" & entry_no & "'" & "  ")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return _strQuery.ToString
    End Function
    'Public Function Last_Lump_ID_of_TrnFinishRcpt_Qry(ByVal Company_Code As String) As String
    '    _strQuery = New StringBuilder
    '    With _strQuery
    '        .Append(" SELECT TOP 1 ")
    '        .Append(" SUBSTRING(LUMP_ID,6,9) ")
    '        .Append(" FROM TrnFinishRcpt ")
    '        .Append(" WHERE 1=1 ")
    '        .Append(" AND LEFT(LUMP_ID,4)='" & Company_Code & "' ")
    '        .Append(" ORDER BY LUMP_ID DESC ")
    '    End With
    '    Return _strQuery.ToString
    'End Function

    'Public Function Last_Lump_No_of_TrnFinishRcpt_Qry() As String
    '    _strQuery = New StringBuilder
    '    With _strQuery
    '        .Append(" SELECT TOP 1 LUMP_NO ")
    '        .Append(" FROM TrnFinishRcpt ")
    '        .Append(" WHERE 1=1 ")
    '        .Append(" ORDER BY LUMP_NO DESC ")
    '    End With
    '    Return _strQuery.ToString
    'End Function
    Public Function Get_Process_Stock_Qry_For_Data_Entry(ByVal Book_Code_Filter_String As String, ByVal Process_Code As String, ByVal Book_Vno As String, ByVal As_On_Dated As String, ByVal StockListShow As String, ByVal _DyeningStatus As String, ByVal DisplayDevGrid As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")

            If DisplayDevGrid = "YES" Then
                .Append(" 'False' as TickMark, ")
            End If

            .Append(" Z.GREY_DESP_PCS_ID1 AS Final_Grey_ID, ")
            If StockListShow = "GREY CHALLAN WISE" Then
                .Append(" Z.CHALLANNO as [Grey ChlNo],")
            ElseIf StockListShow = "PROCESS BEAM WISE" Then
                .Append(" Z.Process_Beamlotno AS [Pro Lot No],")
            Else
                .Append(" CASE WHEN Z.TOTAL_TP>0 THEN Z.PIECENO+'-TP'+CAST((Z.TOTAL_TP+1) AS VARCHAR) ELSE Z.PIECENO END  AS [Piece No], ")
            End If

            .Append(" ROUND(Z.BALMTR,3) AS [G-Mtrs (Balance)], ")
            .Append(" Space(1) as [Flag], ")
            .Append(" E.ITENNAME AS Quality, ")
            .Append(" Z.CHALLANNO AS [Chl-No], ")
            .Append(" FORMAT(Z.CHALLANDATE,'dd/MM/yyyy') AS [Chl-Date], ")
            .Append(" C.ACCOUNTNAME AS Factory, ")
            .Append(" D.ACCOUNTNAME AS Party, ")
            .Append(" F.Design_Name AS [Design No], ")
            .Append(" G.SHADE AS [Shade No], ")
            .Append(" I.SELVEDGE_NAME AS Selvedge, ")
            .Append(" B.ACCOUNTNAME AS Process,  ")
            .Append(" ROUND(Z.BALMTR,3) AS ORG_BALMTR,")
            .Append(" CASE WHEN Z.TOTAL_TP>0 THEN Z.PIECENO+'-TP'+CAST((Z.TOTAL_TP+1) AS VARCHAR) ELSE Z.PIECENO END  AS ORG_PIECENO, ")
            .Append(" Z.TOTAL_TP AS PREV_TP_TOTAL,")
            .Append(" 0 AS CURRENT_TP_TOTAL,")
            .Append(" Z.FABRIC_ITEMCODE AS GREY_FABRIC_ITEMCODE,")
            .Append(" ROUND(Z.GMTR,3) AS ORG_GMTR,")
            .Append(" E.MAXSHRINK as MAX_SHRINK_PER,")
            .Append(" Z.FABRIC_DESIGNCODE AS DESIGNCODE,")
            .Append(" Z.FABRIC_SHADECODE AS SHADECODE,")
            .Append(" (Z.CHALLANDATE) AS F_CHALLANDATE  ")
            .Append(" ,B.ACCOUNTNAME AS PROCESSNAME ")
            .Append(" ,C.ACCOUNTNAME AS FACTORYNAME ")
            .Append(" ,D.ACCOUNTNAME AS PARTYNAME ")
            .Append(" ,E.ITENNAME AS FABRIC_ITEMNAME ")
            .Append(" ,E.WTPERMTR AS AVG_WEIGHT ")
            .Append(" ,E.WTVERIANCE AS AVG_WEIGHT_VARIANCE ")
            .Append(" ,F.Design_Name AS F_FABRIC_DESIGN_NO  ")
            .Append(" ,G.SHADE AS F_FABRIC_SHADE_NO ")
            .Append(" ,H.REMARKNAME AS FINISHREMARK ")
            .Append(" ,I.SELVEDGE_NAME ")
            .Append(" ,CASE WHEN Z.TOTAL_TP>0 THEN round(Z.BALMTR*Z.PCAVGWT,3) ELSE Z.WEIGHT END AS WEIGHT ")
            .Append(" ,Z.PCAVGWT ")
            .Append(" ,Z.SELVCODE ")
            .Append(" ,Z.Process_Beamlotno ")
            .Append(" ,Z.ProcessRate ")
            .Append(" ,Z.FD_PD ")
            .Append(" ,Z.Grey_Rate ")
            .Append(",Z.FACTORYCODE ") 'FACTORYCODE
            .Append(",Z.OfferEntryNo ") 'OfferEntryNo
            .Append(",Z. OFFERNO ") 'OFFERNO
            .Append(",Z.MillName") 'MillName
            .Append(",Z.MilLShadeCode") 'MilLShadeCode
            .Append(",Z.BEAMNO")
            .Append(",Z.DETAILREMARK")
            .Append(",CASE WHEN Z.TOTAL_TP>0 THEN Z.PIECENO+'-TP'+CAST((Z.TOTAL_TP+1) AS VARCHAR) ELSE Z.PIECENO END  AS [Piece No] ")
            .Append(" ,Z.Process_ShadeType ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT A.GREY_DESP_PCS_ID AS GREY_DESP_PCS_ID1, ")
            .Append(" A.PIECENO AS PIECENO,A.CHALLANNO,A.CHALLANDATE, ")
            .Append(" A.GMTR,A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0),3) AS BALMTR, ")
            .Append(" ROUND(SUM(B.GMTR),3) AS USED_GMTR, ")
            .Append(" COUNT(B.PIECENO) AS TOTAL_TP,A.FABRIC_ITEMCODE, ")
            .Append(" A.FABRIC_DESIGNCODE,A.FABRIC_SHADECODE,A.PROCESSCODE, ")
            .Append(" A.FACTORYCODE,A.ACCOUNTCODE,A.FINISH_REMARK_CODE, ")
            .Append(" A.SELVCODE,A.WEIGHT,A.PCAVGWT ")
            .Append(" ,A.Process_Beamlotno ")
            .Append(" ,ISNULL(A.ProcessRate,0 ) AS ProcessRate ")
            .Append(" ,ISNULL(A.Grey_Rate,0 ) AS Grey_Rate ")
            .Append(" ,A.FD_PD ")
            .Append(",A.OP16 AS OfferEntryNo ") 'OfferEntryNo
            .Append(",A.OP3 AS OFFERNO ") 'OFFERNO
            .Append(",A.OP17 AS MillName") 'MillName
            .Append(",A.OP18 AS MilLShadeCode") 'MilLShadeCode
            .Append(",A.BEAMNO")
            .Append(",A.DETAILREMARK")
            .Append(",ISNULL(A.Process_ShadeType,'') AS Process_ShadeType ")

            .Append(" FROM TRNGREYDESP AS A ")
            .Append(" LEFT JOIN TRNFINISHRCPT AS B ")
            .Append(" ON (A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
            '.Append(" And A.ProcessCode=B.ProcessCode ")
            .Append(" And B.BOOKVNO<>'" & Book_Vno & "' ")
            .Append(" )")
            .Append(" WHERE 1=1 ")
            .Append(" AND ( A.PROCESSCODE='" & Process_Code & "' ")
            .Append(Book_Code_Filter_String)
            .Append(" AND A.IDP='YES' ) ")
            If _DyeningStatus = "YES" Then
                .Append(" AND 1 = (CASE WHEN A.FD_PD ='PD' THEN (CASE WHEN A.Process_OT5='YES'  THEN 1 ELSE 0 END)")
                .Append(" WHEN A.FD_PD ='FD' THEN (CASE WHEN A.Process_OT5 IN ('YES','NO','') THEN 1 ELSE 1 END) ELSE 0 END)")
            End If
            .Append(" GROUP BY A.GREY_DESP_PCS_ID, A.PIECENO, A.GMTR, ")
            .Append(" A.CHALLANNO,A.CHALLANDATE,A.FABRIC_ITEMCODE, ")
            .Append(" A.FABRIC_DESIGNCODE,A.FABRIC_SHADECODE,A.PROCESSCODE, ")
            .Append(" A.FACTORYCODE,A.ACCOUNTCODE,A.FINISH_REMARK_CODE, ")
            .Append(" A.SELVCODE,A.WEIGHT,A.PCAVGWT ")
            .Append(" ,A.Process_Beamlotno ")
            .Append(" ,A.ProcessRate ")
            .Append(" ,A.Grey_Rate ")
            .Append(" ,A.FD_PD ")
            .Append(",A.OP16") 'OfferEntryNo
            .Append(",A.OP3") 'OFFERNO
            .Append(",A.OP17") 'MillName
            .Append(",A.OP18") 'MilLShadeCode
            .Append(",A.BEAMNO")
            .Append(",A.DETAILREMARK")
            .Append(",A.Process_ShadeType")
            .Append(" HAVING A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0),3)>0 ")
            .Append(" ) ")
            .Append("AS Z ")
            .Append(" LEFT JOIN  MstMasterAccount AS B ON Z.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN  MstMasterAccount AS C ON Z.FACTORYCODE=C.ACCOUNTCODE")
            .Append(" LEFT JOIN  MstMasterAccount AS D ON  Z.ACCOUNTCODE=D.ACCOUNTCODE ")
            .Append(" LEFT JOIN  MSTFABRICITEM AS E ON Z.FABRIC_ITEMCODE=E.ID")
            .Append(" LEFT JOIN  Mst_Fabric_Design AS F ON Z.FABRIC_DESIGNCODE=F.Design_code ")
            .Append(" LEFT JOIN  Mst_Fabric_Shade AS G ON Z.FABRIC_SHADECODE=G.ID ")
            .Append(" LEFT JOIN  MSTREMARK AS H ON  Z.FINISH_REMARK_CODE=H.REMARKCODE ")
            .Append(" LEFT JOIN  Mst_selvedge AS I ON Z.SELVCODE=I.ID")
            .Append(" WHERE 1=1 AND Z.BALMTR>0")
            .Append(" ORDER BY ")

            If StockListShow = "GREY CHALLAN WISE" Then
                .Append(" (cast((CASE WHEN Z.CHALLANNO NOT LIKE '%[^0-9]%' THEN Z.CHALLANNO END) as BigInt)) ")
                .Append(" ,(cast((CASE WHEN Z.PIECENO NOT LIKE '%[^0-9]%' THEN Z.PIECENO END) as BigInt)) ")
            ElseIf StockListShow = "PROCESS BEAM WISE" Then
                .Append(" (cast((CASE WHEN Z.Process_Beamlotno NOT LIKE '%[^0-9]%' THEN Z.Process_Beamlotno END) as BigInt)) ")
                .Append(" ,Z.PIECENO ")
            Else
                .Append("  Z.PIECENO")
            End If
        End With
        Return _strQuery.ToString
    End Function
#End Region


#End Region



#Region "Invoice Register Multy Selection"
    Public Sub MULTY_Process_SELECTION()


        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT   A.ACCOUNTNAME as [Process Name]  ")
                .Append(",B.CITYNAME as [City Name] ")
                .Append(",A.ACCOUNTCODE, A.ACCOUNTCODE ")
                .Append(",D.ACCOUNTNAME AS [Agent Name] ")
                .Append(" FROM MstMasterAccount AS A, MSTCITY AS B, MSTFINGROUP AS C, MstMasterAccount AS D ")
                .Append(" WHERE A.CITYCODE = B.CITYCODE   ")
                .Append(" AND A.GROUPCODE = C.GROUPCODE    ")
                .Append(" AND A.AGENTCODE = D.ACCOUNTCODE  ")
                .Append(" and A.GROUPCODE ='0000-000000039' ")
                .Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _strQuery.ToString
            MULTI_SELECTION_GRID_SETTING()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub BOOK_SELECTION_MULTY_INVOICE()
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()
            Party_selection_multy.TextBox1.SelectAll()


            If BOOK_BHEWAR = "" Then
                sqL = "SELECT A.BookName,A.BOOKCATEGORY as Remark, A.BookCode, A.BookCode,A.BookTrType from MstBook A WHERE A.BOOKCATEGORY=" & BOOK_CATGER & "  AND A.ACTIVE_STATUS ='YES'  ORDER BY A.BookName"
            ElseIf BOOK_BHEWAR = "MIX" Then
                sqL = "SELECT A.BookName,A.BOOKCATEGORY as Remark, A.BookCode, A.BookCode,A.BookTrType from MstBook A WHERE 1=1 " & BOOK_CATGER & " AND A.ACTIVE_STATUS ='YES' ORDER BY A.BookName"
            Else
                sqL = "SELECT A.BookName,A.BOOKCATEGORY as Remark, A.BookCode, A.BookCode,A.BookTrType from MstBook A WHERE A.BOOKCATEGORY='" & BOOK_CATGER & "' AND A.BEHAVIOUR ='" & BOOK_BHEWAR & "'  AND A.ACTIVE_STATUS ='" & ("YES") & "'ORDER BY A.BookName"
            End If

            If BOOK_BHEWAR = "ACTIVE_STATUS_YES" Then
                sqL = "SELECT A.BookName,A.BOOKCATEGORY as Remark, A.BookCode, A.BookCode,A.BookTrType from MstBook A WHERE A.BOOKCATEGORY='" & BOOK_CATGER & "' AND A.ACTIVE_STATUS ='YES' ORDER BY A.BookName"
            End If
            sql_connect_slect()

            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False

            Party_selection_multy.dgw.Columns(0).Width = 280
            Party_selection_multy.dgw.Columns(1).Width = 160
            Party_selection_multy.dgw.Columns(5).Width = 30

            Party_selection_multy.Width = 506
            Dim row As DataGridViewRow = Party_selection_multy.dgw.Rows(0)
            row.Height = 30
            'Party_selection_multy.dgw.Columns(0).HeaderText = "Book Name"
            'Party_selection_multy.dgw.Columns(1).HeaderText = "Remark"

            SELECTION_LIST_FIRST_multy_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Public Sub BOOK_SELECTION_FORM_NAME()
        Try

            If BOOK_BHEWAR = "" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE A.BOOKCATEGORY='" & BOOK_CATGER & "' AND A.ACTIVE_STATUS ='YES' ORDER BY A.BookName"
            ElseIf BOOK_BHEWAR = "PROCESS TRANSFER" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE" & BOOK_CATGER & " AND A.ACTIVE_STATUS ='YES' ORDER BY A.BOOKCATEGORY,A.BookName"
            ElseIf BOOK_BHEWAR = "PROCESS BOOK" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE A.BOOKCATEGORY='" & BOOK_CATGER & "' " & BOOK_TRTYPE & " AND A.ACTIVE_STATUS ='YES' ORDER BY A.BookName"
            ElseIf BOOK_BHEWAR = "chq_printing" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE " & BOOK_CATGER & " AND A.ACTIVE_STATUS ='YES' ORDER BY A.BOOKCATEGORY,A.BookName"
            ElseIf BOOK_BHEWAR = "BOOKMODIFY" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE " & BOOK_CATGER & " AND A.ACTIVE_STATUS ='YES' ORDER BY A.BOOKCATEGORY ,A.BookName "
            ElseIf BOOK_BHEWAR = "BOOKPRIFIX" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE" & BOOK_CATGER & " AND A.ACTIVE_STATUS ='YES' ORDER BY A.BOOKCATEGORY,A.BookName"
            Else
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE A.BOOKCATEGORY='" & BOOK_CATGER & "' AND ( A.BEHAVIOUR ='" & BOOK_BHEWAR & "') AND A.ACTIVE_STATUS ='YES' ORDER BY A.BookName"
            End If

            If BOOK_BHEWAR = "ACTIVE_STATUS_YES" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE A.BOOKCATEGORY='" & BOOK_CATGER & "'AND A.ACTIVE_STATUS ='YES'  ORDER BY A.BookName"
            End If


            If _MISSING_SERIES_BOOK_CATGER = "Missing_Series" Then
                sqL = "SELECT A.BookName as [Book Name],A.BOOKCATEGORY as [Remark] , A.BookCode,A.BookTrType, A.BookCode from MstBook A WHERE A.BOOKCATEGORY=" & BOOK_CATGER & " ORDER BY A.BookName"
            End If

            sql_connect_slect()
            Dim TAB_BOOK As New DataTable
            TAB_BOOK = DefaltSoftTable.Copy

            Party_selection.dgw.DataSource = TAB_BOOK
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Dim row As DataGridViewRow = Party_selection.dgw.Rows(0)
            row.Height = 30
            Party_selection.dgw.Columns(0).HeaderText = "Book Name"
            Party_selection.dgw.Columns(1).HeaderText = "Remark"

            SELECTION_LIST_FIRST_SELECTION()

            _MISSING_SERIES_BOOK_CATGER = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Public Sub MULTY_Agent_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            'sqL = "select A.ACCOUNTNAME AS AGENT,MC.cityname,A.ACCOUNTCODE,A.ACCOUNTCODE,A.ACCOUNTCODE from MstMasterAccount AS A iNNER JOIN MstCity AS MC ON A.CITYCODE=MC.citycode where A.GROUPCODE='0000-000000052'"


            _strQuery = New StringBuilder
            With _strQuery
                .Append(" select A.ACCOUNTNAME AS AGENT,MC.cityname,A.ACCOUNTCODE,A.ACCOUNTCODE,A.ACCOUNTCODE ")
                .Append("  from MstMasterAccount AS A iNNER JOIN MstCity AS MC ON A.CITYCODE=MC.citycode ")
                .Append("  where 1=1 AND A.GROUPCODE='0000-000000052' ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.ACCOUNTNAME")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = TAB

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 390
            Party_selection_multy.dgw.Columns(1).Width = 190
            Party_selection_multy.dgw.Columns(2).Width = 190
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "City Name"
            Party_selection_multy.dgw.Columns(2).HeaderText = "AccountCode"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            Party_selection_multy.dgw.Sort(Party_selection_multy.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_multy_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub LedgerBalanceWiseMultyPartySelection(ByVal _AccountFilterString As String)
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()


            _strQuery = New StringBuilder
            With _strQuery
                .Append(" WITH LedgerData AS ( ")
                .Append(" SELECT  ")
                .Append(" accountcode  ")
                .Append(" FROM TrnLedger  ")
                .Append(" GROUP BY accountcode ")
                .Append(" ) ")
                .Append(" SELECT DISTINCT  ")
                .Append(" A.ACCOUNTNAME AS [Account Name], ")
                .Append(" B.CityName, ")
                .Append(" D.ACCOUNTNAME AS [Agent Name], ")
                .Append(" Z.accountcode, ")
                .Append(" A.GROUPCODE ")
                .Append(" FROM LedgerData AS Z  ")
                .Append(" LEFT JOIN MstMasterAccount AS A ON Z.accountcode = A.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTCITY AS B  ON A.CITYCODE = B.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS D  ON A.AGENTCODE = D.ACCOUNTCODE ")
                .Append(" WHERE 1=1 ")
                .Append(_AccountFilterString)
                .Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False

            Party_selection_multy.dgw.Columns(0).Width = 320
            Party_selection_multy.dgw.Columns(1).Width = 100
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644

            SELECTION_LIST_FIRST_multy_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub MULTY_PARTY_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()

            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT   A.ACCOUNTNAME,B.CITYNAME, D.ACCOUNTNAME AS AGENTNAME, A.ACCOUNTCODE, A.GROUPCODE  ")
                .Append(" FROM MstMasterAccount AS A INNER JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
                .Append(" LEFT JOIN MSTFINGROUP AS C ON A.GROUPCODE=C.GROUPCODE")
                .Append(" LEFT JOIN  MstMasterAccount AS D  ON A.AGENTCODE=D.ACCOUNTCODE  WHERE 1=1 ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.ACCOUNTNAME")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()





            'Party_selection_multy.FirstStage.Columns.Clear()
            'Party_selection_multy.GridControl1.DataSource = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            'Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False

            Party_selection_multy.dgw.Columns(0).Width = 320
            Party_selection_multy.dgw.Columns(1).Width = 100
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "City Name"
            Party_selection_multy.dgw.Columns(2).HeaderText = "Agent Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            'Party_selection_multy.dgw.Sort(Party_selection_multy.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_multy_SELECTION()

            GROUP_WISE_MULTY_PARTY_SELECT = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_AgentWiseCity_SELECTION()
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append("  B.cityname,A.StateName,B.citycode,B.citycode,B.citycode  ")
            .Append("  from MstState as A , MstCity as B , MstMasterAccount C  ")
            .Append("  WHERE 1=1")
            .Append("  AND A.stateid = B.STATEID ")
            .Append("  AND C.CITYCODE = B.CITYCODE ")
            .Append(GROUP_WISE_MULTY_STATE_TO_CITY_SELECT)
            .Append("  GROUP  BY  B.cityname,A.StateName,B.citycode  ")
            .Append("  ORDER BY B.cityname  ")
        End With
        sqL = strQuery.ToString
        MULTI_SELECTION_GRID_SETTING()
        GROUP_WISE_MULTY_PARTY_SELECT = ""
    End Sub

    Public Sub MultyUnitSelection()
        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" Select ")
                .Append(" A.ToUnit as [Unit Type]")
                .Append(" ,A.ConversionFactor")
                .Append(" ,A.UnitID")
                .Append(" ,A.UnitID")
                .Append(" ,A.UnitID")
                .Append(" FROM MstUnitMaster A")
                .Append(" where 1=1 ")
                .Append(" AND A.IsActive='YES'")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY  A.FromUnit ")
            End With
            sqL = _strQuery.ToString
            MULTI_SELECTION_GRID_SETTING()
            GROUP_WISE_MULTY_PARTY_SELECT = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub


    Public Sub MULTY_City_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT B.cityname,A.StateName,B.citycode,B.citycode,B.citycode  ")
                .Append("  from MstState as A , MstCity as B   ")
                .Append("  WHERE ")
                .Append("  A.stateid = B.STATEID ")
                .Append(GROUP_WISE_MULTY_STATE_TO_CITY_SELECT)
                .Append("  ORDER BY B.cityname  ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 350
            Party_selection_multy.dgw.Columns(1).Width = 220
            Party_selection_multy.dgw.Columns(2).Width = 370
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "City Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "State Name"
            Party_selection_multy.dgw.Columns(2).HeaderText = "City Code"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
            GROUP_WISE_MULTY_STATE_TO_CITY_SELECT = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_State_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "select MSTS.StateName,MSTS.COUNTRY,CAST (MSTS.STATEID AS varchar) AS ID,CAST (MSTS.STATEID AS varchar) AS ID,CAST (MSTS.STATEID AS varchar) AS ID from MstState as [MSTS] ORDER BY MSTS.StateName "
            sql_connect_slect()
            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "State Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Country Name"
            Party_selection_multy.dgw.Columns(2).HeaderText = "State Id"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_TRANSPORT_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "SELECT A.TRANSPORTNAME,A.CITY,A.ID,A.ID,A.ID FROM MstTransport A  ORDER BY A.TRANSPORTNAME"
            sql_connect_slect()

            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644

            Party_selection_multy.dgw.Columns(0).HeaderText = "Transport Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "City Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_ACCOUNT_OF_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = " "

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT A.AC_NAME,B.cityname,A.ID,A.ID,A.ID ")
                .Append(" FROM Mst_Acof_Supply A,MstCity B  ")
                .Append(" WHERE  1=1  ")
                .Append(" AND A.CITY_CODE=B.citycode   ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.AC_NAME  ")

            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = TAB

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644

            Party_selection_multy.dgw.Columns(0).HeaderText = "Ac/Of Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "City Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_GROUP_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            Dim L1 = " SELECT A.GROUPNAME,B.ScheduleName,A.GROUPCODE,A.GROUPCODE,A.GROUPCODE "
            Dim L2 = " FROM MstFinGroup A ,MstFinSchedule B "
            Dim L3 = "  WHERE 1 = 1 And A.SCHEDULECODE = B.SrNo"
            Dim L4 = " ORDER BY GROUPNAME"

            sqL = L1 + L2 + L3 + L4
            sql_connect_slect()
            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30

            Party_selection_multy.Width = 644

            Party_selection_multy.dgw.Columns(0).HeaderText = "Group Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Schedule Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTI_SELECTION_GRID_SETTING()
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()
            MULTY_SELECTION_COLOUM_3_DATA = ""

            sql_connect_slect()

            If DefaltSoftTable.Rows.Count > 0 Then

                Dim _TMPTBL As New DataTable
                _TMPTBL = DefaltSoftTable.Copy

                Party_selection_multy.dgw.DataSource = _TMPTBL
                Dim Chk As New DataGridViewCheckBoxColumn()
                Party_selection_multy.dgw.Columns.Add(Chk)

                Party_selection_multy.dgw.Columns(2).Visible = False
                Party_selection_multy.dgw.Columns(3).Visible = False
                Party_selection_multy.dgw.Columns(4).Visible = False

                Party_selection_multy.dgw.Columns(0).Width = 280
                Party_selection_multy.dgw.Columns(1).Width = 160
                Party_selection_multy.dgw.Columns(5).Width = 30

                Party_selection_multy.Width = 506
                Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

                Dim row As DataGridViewRow = Party_selection_multy.dgw.Rows(0)
                row.Height = 30
                SELECTION_LIST_FIRST_multy_SELECTION()
            Else
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try


    End Sub
    Public Sub MULTY_GRADER_SELECTION()
        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT A.GraderName AS [Grader Name], ''as Remark ,A.GraderCode,A.GraderCode,A.GraderCode  ")
                .Append("  from MstGrader as A   ")
                .Append("  ORDER BY A.GraderCode  ")
            End With
            sqL = _strQuery.ToString
            MULTI_SELECTION_GRID_SETTING()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub MULTY_STORE_GROUP_SELECTION()
        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT A.GroupName AS [Group Name], ''as Remark ,A.GroupCode,A.GroupCode,A.GroupCode  ")
                .Append("  from MstStoreItemGroup as A   ")
                .Append("  ORDER BY A.GroupName  ")
            End With
            sqL = _strQuery.ToString
            MULTI_SELECTION_GRID_SETTING()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub

#End Region

#Region " FIRST SELECTION LIST "

    Public Sub Single_List_Load_Data_Four_Coloum()

        Try
            MULTY_SELECTION_COLOUM_1_DATA = ""
            MULTY_SELECTION_COLOUM_2_DATA = ""
            MULTY_SELECTION_COLOUM_3_DATA = ""
            MULTY_SELECTION_COLOUM_4_DATA = ""
            MULTY_SELECTION_COLOUM_5_DATA = ""
            MULTY_SELECTION_COLOUM_6_DATA = ""
            sql_connect_slect()

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            'Party_selection.dgw.Columns(0).Visible = False
            Party_selection.dgw.Columns(1).Visible = False
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            'Party_selection.dgw.Columns(3).Visible = True
            'Party_selection.dgw.Columns(4).Visible = True
            'Party_selection.dgw.Columns(5).Visible = True
            'Party_selection.dgw.Columns(6).Visible = True

            Party_selection.dgw.Columns(0).Width = 250
            Party_selection.dgw.Columns(4).Width = 120
            Party_selection.dgw.Columns(5).Width = 120
            Party_selection.dgw.Columns(6).Width = 120
            Party_selection.Width = 644

            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try


    End Sub
    Public Sub Single_List_Load_Data_Four_Coloum_FiveItem()

        Try
            MULTY_SELECTION_COLOUM_1_DATA = ""
            MULTY_SELECTION_COLOUM_2_DATA = ""
            MULTY_SELECTION_COLOUM_3_DATA = ""
            MULTY_SELECTION_COLOUM_4_DATA = ""
            MULTY_SELECTION_COLOUM_5_DATA = ""
            MULTY_SELECTION_COLOUM_6_DATA = ""

            sql_connect_slect()

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = True

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(3).Width = 120
            Party_selection.dgw.Columns(4).Width = 100
            Party_selection.Width = 644

            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub Single_List_Load_Data_Three_Coloum()
        Try
            MULTY_SELECTION_COLOUM_1_DATA = ""
            MULTY_SELECTION_COLOUM_2_DATA = ""
            MULTY_SELECTION_COLOUM_3_DATA = ""
            MULTY_SELECTION_COLOUM_4_DATA = ""
            MULTY_SELECTION_COLOUM_5_DATA = ""
            MULTY_SELECTION_COLOUM_6_DATA = ""

            sql_connect_slect()

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 330
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644

            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub Single_List_Load_Data()
        Try
            MULTY_SELECTION_COLOUM_1_DATA = ""
            MULTY_SELECTION_COLOUM_2_DATA = ""
            MULTY_SELECTION_COLOUM_3_DATA = ""
            MULTY_SELECTION_COLOUM_4_DATA = ""
            MULTY_SELECTION_COLOUM_5_DATA = ""
            MULTY_SELECTION_COLOUM_6_DATA = ""


            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            'Party_selection.dgw.Columns(4).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            SELECTION_LIST_FIRST_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub Single_List_ItemWise_shade_Selection(ByVal _ItemCode As String, ByVal _DesignCode As String)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT *  ")
            .Append(" from MstFabricItem  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND ID='" & _ItemCode & "' ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim ItemWiseShadeCode As String = ""
        If DefaltSoftTable.Rows.Count > 0 Then
            ItemWiseShadeCode = DefaltSoftTable.Rows(0).Item("OP11").ToString
        End If
        If ItemWiseShadeCode.Trim <> "(  )" And ItemWiseShadeCode.Trim > "" Then
            ItemWiseShadeCode = " AND A.id IN " + Strings.Replace(ItemWiseShadeCode, "#", "'", 1, -1, CompareMethod.Binary)

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.SHADE AS [Shade Name] ")
                .Append("  ,A.REMARK_COLOR as Remark ")
                .Append("  ,A.id as SHADECODE ")
                .Append("  ,A.id as SHADECODE ")
                .Append("  ,A.OP11 as [Extra Rate] ")
                .Append("  FROM Mst_Fabric_Shade as A ")
                .Append(" where 1=1")
                .Append(ItemWiseShadeCode)
                .Append(" ORDER BY  A.SHADE ")

            End With
            sqL = _strQuery.ToString
            obj_Party_Selection.Single_List_Load_Data()
        Else
            If _ShadeLoadFabricListWise <> "YES" Then
                obj_Party_Selection.SINGLE_SHADE_SELECTION()
            Else
                MsgBox("Shade Not Found In Item Master Account", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                MULTY_SELECTION_COLOUM_1_DATA = ""
                MULTY_SELECTION_COLOUM_2_DATA = ""
                MULTY_SELECTION_COLOUM_3_DATA = ""
                MULTY_SELECTION_COLOUM_4_DATA = ""
                MULTY_SELECTION_COLOUM_5_DATA = ""
                MULTY_SELECTION_COLOUM_6_DATA = ""
                Exit Sub
            End If
        End If
    End Sub
    Public Sub Multy_List_Load_Data()
        Try

            sql_connect_slect()

            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy
            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False


            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644

            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SELECTION_LIST_FIRST_SELECTION()
        Try
            If Party_selection.dgw.Rows.Count = 0 Then
                Party_selection.Label2.Text = ""
                Party_selection.Label3.Text = ""
                Party_selection.Label6.Text = ""
                Party_selection.Label7.Text = ""
                MULTY_SELECTION_COLOUM_1_DATA = ""
                MULTY_SELECTION_COLOUM_2_DATA = ""
                MULTY_SELECTION_COLOUM_3_DATA = ""
                'Party_selection.dgw.Rows.Add("Value 1", "Value 2", "Value3")

                'Party_selection.dgw.AllowUserToAddRows = True
                'Party_selection.dgw.Rows.Add()
                MsgBox("Record Not Found.", MsgBoxStyle.Information, "Soft-Tex PRO")
                SendKeys.Send("{UP}")
                Party_selection.Close()
                Party_selection.Dispose()
                Exit Sub
            End If

            Dim row As DataGridViewRow = Party_selection.dgw.Rows(0)
            row.Height = 30


            Party_selection.dgw.ClearSelection()
            If Party_selection.txtSearch.Text <> "" Then
                Dim s As String = Party_selection.txtSearch.Text
                For x As Integer = 0 To Party_selection.dgw.Rows.Count - 1
                    If CStr(Party_selection.dgw.Rows(x).Cells(0).Value).StartsWith(s) Then
                        Party_selection.dgw.FirstDisplayedScrollingRowIndex = x
                        Party_selection.dgw.Item(0, x).Selected = True
                        Party_selection.Label2.Text = Party_selection.dgw.SelectedRows(0).Cells(0).Value.ToString
                        Party_selection.Label3.Text = Party_selection.dgw.SelectedRows(0).Cells(2).Value.ToString
                        Party_selection.Label6.Text = Party_selection.dgw.SelectedRows(0).Cells(1).Value.ToString
                        MULTY_SELECTION_COLOUM_1_DATA = Party_selection.dgw.SelectedRows(0).Cells(0).Value.ToString
                        MULTY_SELECTION_COLOUM_2_DATA = Party_selection.dgw.SelectedRows(0).Cells(1).Value.ToString

                        Exit For
                    End If
                Next
            End If

            If Party_selection.txtSearch.Text = Party_selection.Label2.Text Then
            Else
                Party_selection.txtSearch.Text = ""
            End If
            If Party_selection.txtSearch.Text = "" Then
                Party_selection.dgw.FirstDisplayedScrollingRowIndex = 0
                Party_selection.dgw.Rows(0).Selected = True
                Party_selection.Label2.Text = Party_selection.dgw.SelectedRows(0).Cells(0).Value.ToString
                Party_selection.Label3.Text = Party_selection.dgw.SelectedRows(0).Cells(2).Value.ToString
                Party_selection.Label6.Text = Party_selection.dgw.SelectedRows(0).Cells(1).Value.ToString
                MULTY_SELECTION_COLOUM_1_DATA = Party_selection.dgw.SelectedRows(0).Cells(0).Value.ToString
                MULTY_SELECTION_COLOUM_2_DATA = Party_selection.dgw.SelectedRows(0).Cells(1).Value.ToString
            End If
            Party_selection.Owner = Main_MDI_Frm
            Party_selection.StartPosition = FormStartPosition.CenterParent

            Party_selection.dgw.Focus()
            Party_selection.ShowDialog()
            Party_selection.Close()
            Party_selection.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SELECTION_LIST_FIRST_multy_SELECTION()
        Try
            MULTY_SELECTION_COLOUM_3_DATA = ""

            If Party_selection_multy.dgw.Rows.Count = 0 Then
                Party_selection_multy.Label2.Text = ""
                Party_selection_multy.Label3.Text = ""
                Party_selection_multy.Label6.Text = ""
                Party_selection_multy.Label7.Text = ""
                MULTY_SELECTION_COLOUM_1_DATA = ""
                MULTY_SELECTION_COLOUM_2_DATA = ""
                MULTY_SELECTION_COLOUM_3_DATA = ""
                MsgBox("Record Not Found.", MsgBoxStyle.Information, "Soft-Tex PRO")
                SendKeys.Send("{UP}")
                Party_selection_multy.Close()
                Party_selection_multy.Dispose()
                Exit Sub
            End If

            Dim row As DataGridViewRow = Party_selection_multy.dgw.Rows(0)
            row.Height = 30

            Party_selection_multy.dgw.ClearSelection()
            If Party_selection_multy.TextBox1.Text <> "" Then
                Dim s As String = Party_selection_multy.TextBox1.Text
                For x As Integer = 0 To Party_selection_multy.dgw.Rows.Count - 1
                    If CStr(Party_selection_multy.dgw.Rows(x).Cells(1).Value).StartsWith(s).ToString Then
                        Party_selection_multy.dgw.FirstDisplayedScrollingRowIndex = x
                        Party_selection_multy.dgw.Item(0, x).Selected = True
                        Party_selection_multy.Label2.Text = Party_selection_multy.dgw.SelectedRows(0).Cells(1).Value.ToString
                        Party_selection_multy.Label3.Text = Party_selection_multy.dgw.SelectedRows(0).Cells(5).Value.ToString
                        Party_selection_multy.Label6.Text = Party_selection_multy.dgw.SelectedRows(0).Cells(2).Value.ToString
                        Exit For
                    End If
                Next
            End If


            If Party_selection_multy.TextBox1.Text = Party_selection_multy.Label2.Text Then
            Else
                Party_selection_multy.TextBox1.Text = ""
            End If

            Party_selection_multy.dgw.Focus()
            Party_selection_multy.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
#End Region

#Region "Multy Selection List"
    Public Sub MULTY_ITEM_SELECTION_TypeningWise(ByVal _SearchText As String)
        If _SearchText = Nothing Then _SearchText = ""

        Try
            'Party_selection_multy.dgw.CancelEdit()
            'Party_selection_multy.dgw.DataSource = Nothing
            'Party_selection_multy.dgw.Rows.Clear()

            'Party_selection_multy.TextBox1.SelectAll()


            If Book_Behaviour = "READYMADE" Then Book_Behaviour = "GENERAL"
            If Book_Behaviour = "RMC" Then Book_Behaviour = "GENERAL"


            If Book_Behaviour = "YARN" Then
                sqL = "SELECT A.CountName,A.HSNCode,A.CountCode,A.CountCode,A.CountCode FROM MstYarnCount A  WHERE 1=1  AND A.CountName Like '%" & _SearchText.ToString.Trim & "%'  ORDER BY A.CountName"
            ElseIf Book_Behaviour = "GENERAL" Then
                sqL = " SELECT  A.ITEMNAME AS [Item Name],A.HSNCode,A.ItemCode ,A.ItemCode ,A.ItemCode  FROM MSTSTOREITEM A  WHERE 1=1  AND A.ITENNAME Like '%" & _SearchText.ToString.Trim & "%'   ORDER BY A.ITEMNAME "
            Else
                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" SELECT A.ITENNAME,A.HSNCODE,A.ID,A.ID,A.ID  ")
                    .Append(" FROM MstFabricItem A ")
                    .Append(" WHERE 1=1 ")
                    .Append(" AND A.ITENNAME Like '%" & _SearchText.ToString.Trim & "%' ")
                    .Append(" ORDER BY A.ITENNAME ")
                End With
                sqL = _strQuery.ToString
            End If

            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = TAB
            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Item Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "HSN Code"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            'SELECTION_LIST_FIRST_multy_SELECTION()
            'Book_Behaviour = ""
            'GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'cmd.Dispose()
            'conn.Close()
        End Try
    End Sub
    Public Sub MULTY_ITEM_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()


            If Book_Behaviour = "READYMADE" Then Book_Behaviour = "GENERAL"
            If Book_Behaviour = "RMC" Then Book_Behaviour = "GENERAL"


            If Book_Behaviour = "YARN" Then
                sqL = "SELECT A.CountName,A.HSNCode,A.CountCode,A.CountCode,A.CountCode FROM MstYarnCount A  ORDER BY A.CountName"
            ElseIf Book_Behaviour = "GENERAL" Then
                sqL = " SELECT  A.ITEMNAME AS [Item Name],A.HSNCode,A.ItemCode ,A.ItemCode ,A.ItemCode  FROM MSTSTOREITEM A ORDER BY A.ITEMNAME "
            Else
                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" SELECT A.ITENNAME,A.HSNCODE,A.ID,A.ID,A.ID  ")
                    .Append(" FROM MstFabricItem A ")
                    .Append(" WHERE 1=1 ")
                    .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                    .Append(" ORDER BY A.ITENNAME ")
                End With
                sqL = _strQuery.ToString
            End If

            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = TAB
            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Item Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "HSN Code"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
            Book_Behaviour = ""
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_YARN_ITEM_SELECTION()

        Try
            'Party_selection_multy.dgw.CancelEdit()
            'Party_selection_multy.dgw.DataSource = Nothing
            'Party_selection_multy.dgw.Rows.Clear()
            'Party_selection_multy.TextBox1.SelectAll()


            sqL = "SELECT A.CountName,A.HSNCode,A.CountCode,A.CountCode,A.CountCode FROM MstYarnCount A  ORDER BY A.CountName"
            sql_connect_slect()
            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Item Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "HSN Code"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"



            SELECTION_LIST_FIRST_multy_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub MULTY_Cut_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "select CUTM.CUTNAME,CUTM.CUTTYPE,CUTM.ID,CUTM.ID,CUTM.ID from MstCutMaster as CUTM  ORDER BY CUTM.CUTNAME"
            sql_connect_slect()

            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Cut Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Cut Type"
            Party_selection_multy.dgw.Columns(2).HeaderText = "Cut Id"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_Design_SELECTION()
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "select Design_Name,Quality_Name,Design_code,Design_code,Design_code from Mst_Fabric_Design ORDER BY Design_Name"
            sql_connect_slect()

            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            'Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Design Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Quality Name"
            ' Party_selection_multy.dgw.Columns(2).HeaderText = "Design Code"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_Shade_SELECTION()
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "SELECT A.SHADE,A.REMARK_COLOR,A.Id,A.Id,A.Id FROM Mst_Fabric_Shade A ORDER BY A.SHADE"
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy

            Party_selection_multy.dgw.DataSource = TAB

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            'Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Shade"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Shade Type"
            Party_selection_multy.dgw.Columns(2).HeaderText = "Shade Code"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_SELVEDGE_SELECTION()
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "SELECT A.SELVEDGE_NAME,B.ITENNAME,A.ID,A.ID,A.ID FROM Mst_selvedge A INNER JOIN MstFabricItem B ON A.item_code=B.ID ORDER BY SELVEDGE_NAME"
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy

            Party_selection_multy.dgw.DataSource = TAB

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            'Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Selvedge Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Quality Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_BEAM_SELECTION()
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append(" Z.BEAMNO AS [Beam No], ")
                .Append(" '' AS [Remark], ")
                .Append(" Z.BEAMNO,Z.BEAMNO,Z.BEAMNO")
                .Append("  FROM (  ")
                .Append(" SELECT  ")
                .Append(" A.BEAMNO ")
                .Append(" FROM TRNGREYDESP A ")
                .Append(" UNION ALL  ")
                .Append(" SELECT  ")
                .Append(" A.BEAMNO ")
                .Append(" FROM TrnGreyRcpt A ")
                .Append(" ) AS Z ")
                .Append(" WHERE  Z.BEAMNO  >''")
                .Append(" GROUP BY Z.BEAMNO ")
                .Append(" ORDER BY Z.BEAMNO ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy

            Party_selection_multy.dgw.DataSource = TAB

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            'Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            'Party_selection_multy.dgw.Columns(0).HeaderText = "Selvedge Name"
            'Party_selection_multy.dgw.Columns(1).HeaderText = "Quality Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Sub MULTY_FABRIC_GROUP_SELECTION()

        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()
            sqL = "SELECT A.fabric_GroupName,B.FABRICHEAD,A.ID,A.ID,A.ID FROM MstFabricGroup A INNER JOIN MstFabricHead B ON A.fabric_HeadCode=B.ID  ORDER BY FABRICHEAD"
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy

            Party_selection_multy.dgw.DataSource = TAB

            Dim Chk As New DataGridViewCheckBoxColumn()

            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            'Party_selection_multy.dgw.Columns.Insert(5, checkBoxColumn)

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(0).HeaderText = "Fabric Group Name"
            Party_selection_multy.dgw.Columns(1).HeaderText = "Fabric Head Name"
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Public Function Challan_No_Selection_Qry_From_TrnGreyDesp() As String
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()

            Party_selection_multy.TextBox1.SelectAll()

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.CHALLANNO AS [Factory Challan No], ")
                .Append(" B.ACCOUNTNAME  AS [Factory], ")
                .Append(" B.ACCOUNTCODE ,A.CHALLANNO AS VALUECODE,B.ACCOUNTCODE  ")
                .Append(" FROM TRNGREYDESP A,MstMasterAccount B ")
                .Append(" WHERE 1=1 AND A.FACTORYCODE=B.ACCOUNTCODE ")
                .Append(" GROUP BY A.CHALLANNO,B.ACCOUNTNAME,B.ACCOUNTCODE  ")
                .Append(" ORDER BY LEN(A.CHALLANNO) , A.CHALLANNO ")
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy

            Party_selection_multy.dgw.DataSource = TAB
            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)
            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False
            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"
            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
        Return _strQuery.ToString

    End Function
    Public Function Beam_No_Selection_Qry_From_TrnGreyDesp() As String
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()
            Party_selection_multy.TextBox1.SelectAll()

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.BEAMNO AS [Beam No], ")
                .Append(" B.ACCOUNTNAME AS [Factory], ")
                .Append(" B.ACCOUNTCODE,A.BEAMNO AS VALUECODE,A.BEAMNO AS VALUECODE")
                .Append(" FROM TRNGREYDESP A,MstMasterAccount B ")
                .Append(" WHERE 1=1 AND A.FACTORYCODE=B.ACCOUNTCODE ")
                .Append(" GROUP BY A.BEAMNO,B.ACCOUNTNAME,B.ACCOUNTCODE  ")
                .Append(" ORDER BY LEN(A.BEAMNO) , A.BEAMNO ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy

            Party_selection_multy.dgw.DataSource = TAB
            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"
            SELECTION_LIST_FIRST_multy_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

        Return _strQuery.ToString
    End Function
    Public Function Get_Finance_Group_Filter_String() As String ' ZOOMING DISPLAY REPORT
        Get_Finance_Group_Filter_String = ""
        Try
            Party_selection_multy.dgw.CancelEdit()
            Party_selection_multy.dgw.DataSource = Nothing
            Party_selection_multy.dgw.Rows.Clear()
            Party_selection_multy.TextBox1.SelectAll()
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append(" A.GROUPNAME AS [Group Name], ")
                .Append(" B.SCHEDULENAME AS [Schedule Name], ")
                .Append(" A.GROUPCODE,A.GROUPCODE,A.GROUPCODE ")
                .Append(" FROM MSTFINGROUP A,MSTFINSCHEDULE B ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.SCHEDULECODE=B.SrNo ")
                .Append(" AND A.GROUPNAME LIKE 'SUNDRY%' ")
                .Append(" ORDER BY A.GROUPNAME,B.SCHEDULENAME ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = TAB
            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False

            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644
            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"
            SELECTION_LIST_FIRST_multy_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

        Return Get_Finance_Group_Filter_String
    End Function
    Public Sub MULTY_TAGNO_SELECTION(ByVal Filter_Condition_No As String)
        Try

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.BARCODE_TAGNO AS [Tag No], ")
                .Append(" A.Entryno AS [Entry No], ")
                .Append(" A.PIECE_ID AS VALUECODE, ")
                .Append(" A.PIECE_ID AS VALUECODE, ")
                .Append(" A.PIECE_ID AS VALUECODE ")
                .Append(" FROM TRNGRADING AS A ")
                .Append(" WHERE 1=1 ")
                .Append(Filter_Condition_No)
                .Append(" AND A.BARCODE_TAGNO<>0 ")
                .Append(" ORDER BY A.BARCODE_TAGNO ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy


            Party_selection_multy.dgw.DataSource = TAB
            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False


            Party_selection_multy.dgw.Columns(0).Width = 380
            Party_selection_multy.dgw.Columns(1).Width = 200
            Party_selection_multy.dgw.Columns(2).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644

            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"

            SELECTION_LIST_FIRST_multy_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Multy_LogBookWeaver_Selection()
        sqL = " SELECT A.EmpName as [Weaver Name], '' as Remark ,A.EmpCode,A.EmpCode,A.EmpCode FROM MstLogBookWeaver A  ORDER BY A.EmpName"
        Multy_List_Load_Data()
    End Sub
    Public Sub Multy_LoomNo_Selection()

        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" a.LOOMNO as [Loom No],a.rpm as [RPM], ")
            .Append(" a.LoomNoCode,a.LoomNoCode,a.LoomNoCode ")
            .Append(" FROM MSTLOOMNO as a ")
            .Append(" where 1=1 ")
            .Append(" ORDER BY CAST(A.LOOMNO AS INT) ")
        End With
        sqL = strQuery.ToString
        Multy_List_Load_Data()

    End Sub

    Public Sub Multy_LoomNoGroup_Selection()

        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" a.GROUP_NO as [Group Name],'' as Remark, ")
            .Append(" a.GROUP_NO,a.GROUP_NO,a.GROUP_NO ")
            .Append(" FROM MSTLOOMNO as a ")
            .Append(" where 1=1 ")
            .Append(" AND A.GROUP_NO > '' ")
            .Append(" GROUP BY ")
            .Append(" A.GROUP_NO ")
            .Append(" ORDER BY a.GROUP_NO ")
        End With
        sqL = strQuery.ToString
        Multy_List_Load_Data()

    End Sub


    Public Sub MULTY_storeItem_SELECTION(ByVal _GROUPCODE As String)
        Try
            Party_selection.Label4.Text = "MstStoreItem"
            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.ItemName AS ItemName ")
                .Append(" ,A.HSNCode as HsnCode ")
                .Append(" ,A.ItemCode ")
                .Append(" ,A.ItemCode ")
                .Append(" ,A.ItemCode ")
                .Append("  FROM MstStoreItem A  ")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP7,'YES') <> 'NO' ")
                .Append(_GROUPCODE)
                .Append(" ORDER BY A.ItemName ")
            End With
            sqL = _StrQuer.ToString
            sql_connect_slect()


            Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy

            Dim Chk As New DataGridViewCheckBoxColumn()
            Party_selection_multy.dgw.Columns.Add(Chk)

            Party_selection_multy.dgw.Columns(2).Visible = False
            Party_selection_multy.dgw.Columns(3).Visible = False
            Party_selection_multy.dgw.Columns(4).Visible = False

            Party_selection_multy.dgw.Columns(0).Width = 470
            Party_selection_multy.dgw.Columns(1).Width = 100
            Party_selection_multy.dgw.Columns(2).Width = 150
            'Party_selection_multy.dgw.Columns(3).Width = 150
            Party_selection_multy.dgw.Columns(5).Width = 30
            Party_selection_multy.Width = 644

            Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"


            SELECTION_LIST_FIRST_multy_SELECTION()

            GROUP_WISE_MULTY_PARTY_SELECT = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally


        End Try
    End Sub
    Public Sub Multy_Employee_SELECTION(ByVal strCondtion As String)
        Try
            Party_selection.Label4.Text = "Employee"

            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.EMPNAME As [Employee Name] ")
                .Append(" ,A.FATHERNAME as [Father Name] ")
                .Append(" ,A.EMPCODE ")
                .Append(" ,A.EMPCODE ")
                .Append(" ,A.EMPCODE ")
                .Append(" From MstEmployee A ")
                .Append(" Where 1 = 1 ")
                .Append(" " & strCondtion & " ")
                .Append(" ORDER BY A.EMPNAME ")
            End With
            sqL = _StrQuer.ToString
            Multy_List_Load_Data()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub MULTY_STORE_DEPARTMENT_Selection()
        Party_selection.Label4.Text = ""
        sqL = " SELECT a.Departmentname as [Dep. Name],a.Descr as Remark,A.Departmentcode,A.Departmentcode,A.Departmentcode FROM MstDepartment AS A ORDER BY Departmentname "
        Multy_List_Load_Data()
    End Sub
    Public Sub MULTY_SIZE_SELECTION(ByVal FilterString As String)
        Try
            Party_selection.Label4.Text = "Frm_SizeMaster"

            sqL = " SELECT a.SizeName as [Size Name],a.op1 as Remark,A.SizeCode,A.SizeCode,A.SizeCode FROM MstSize AS A  WHERE 1=1 " & FilterString & " ORDER BY SizeName "
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Multy_Color_Selection(ByVal FilterString As String)
        Try
            Party_selection.Label4.Text = "Frm_Color"
            sqL = " SELECT a.ColorName as [Color Name],'' as Remark,A.ColorCode,A.ColorCode,A.ColorCode FROM MstColor AS A  WHERE 1=1 " & FilterString & "  ORDER BY ColorName "
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub MULTY_Remark_SELECTION(ByVal _REMARKFOR As String, ByVal _FieldName As String)
        Try
            Party_selection.Label4.Text = "Remaek_frm"
            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.RemarkName AS " & _FieldName & " ,'' as [Other Remark]  ")
                .Append(" ,A.RemarkCode,A.RemarkName,A.RemarkCode ")
                .Append(" FROM MstRemark A ")
                .Append(" WHERE 1=1 AND ( Remark_For='" & _REMARKFOR & "' ")
                .Append(" OR REMARKCODE='0000-000000001') ")
                .Append(" ORDER BY A.RemarkName ")
            End With
            sqL = _StrQuer.ToString
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Multy_Stich_Master_Selection()
        Try
            Party_selection.Label4.Text = "StichingTailorMaster"
            sqL = " SELECT A.TAILORNAME as [Master Name], a.MOBILE as [MOBILE] ,A.TAILORCODE,A.TAILORCODE,A.TAILORCODE FROM STC_MstTailorMaster A  ORDER BY A.TAILORNAME"
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub



    Public Sub Multy_Yarn_Shade_selection()
        Try
            'Party_selection.Label4.Text = "StichingTailorMaster"
            sqL = "SELECT A.YARN_SHADE_NAME as [Yarn Shade],A.REMARK as Remark,A.ID,A.ID,A.ID FROM MstYarnItemShade A  ORDER BY A.YARN_SHADE_NAME"
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub


    Public Sub Multy_FinenceGroupAll(ByVal _GroupFilter)
        Try

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append(" A.GROUPNAME AS [Group Name], ")
                .Append(" B.SCHEDULENAME AS [Schedule Name], ")
                .Append(" A.GROUPCODE,A.GROUPCODE,A.GROUPCODE ")
                .Append(" FROM MSTFINGROUP A,MSTFINSCHEDULE B ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.SCHEDULECODE=B.SrNo ")
                .Append(_GroupFilter)
                '.Append(" AND A.GROUPNAME LIKE 'SUNDRY%' ")
                .Append(" ORDER BY A.GROUPNAME,B.SCHEDULENAME ")
            End With
            sqL = _strQuery.ToString
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Multy_Yarn_CountType_selection()
        Try

            sqL = " SELECT a.YarnTypeName as [Yarn Type],'' as Remark,A.YarnTypeCode,A.YarnTypeCode,A.YarnTypeCode FROM MstYarnType AS A ORDER BY YarnTypeName "
            Multy_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub



#End Region

#Region "Single Selection List"
    Public Sub Single_BankBranch_Selection()
        Party_selection.Label4.Text = "BankBranchName"
        sqL = " SELECT A.bankcashname as [Bank Name], '' as Remark ,A.bankcashcode,A.bankcashcode,A.bankcashcode FROM MstBankCashNames A  ORDER BY A.bankcashname"
        Single_List_Load_Data()
    End Sub
    Public Sub Single__MillShade_Selection()
        Try
            Party_selection.Label4.Text = "MillShade"
            Dim strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" a.SHADENAME + '(' + a.MILLNAME + ')' as [Shade]  ")
                .Append(" ,a.SHADETYPE as [Type]  ")
                .Append(" ,a.SHADECODE")
                .Append(" ,B.SHADE as [Fab. Shade]  ")
                .Append(" ,C.ITENNAME as [Fab. Item] ")
                .Append(" FROM MSTMILLSHADE as a ")
                .Append(" ,Mst_Fabric_Shade AS B")
                .Append(" ,MstFabricItem AS C")
                .Append(" where 1=1 ")
                .Append(" AND A.FABRICSHADECODE=B.ID")
                .Append(" AND A.OP2=C.ID")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY a.SHADENAME ")
            End With
            sqL = strQuery.ToString

            sql_connect_slect()

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            'Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(2).Visible = False

            'Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 300
            Party_selection.dgw.Columns(1).Width = 80
            Party_selection.dgw.Columns(3).Width = 100
            Party_selection.dgw.Columns(4).Width = 130
            Party_selection.Width = 644

            SELECTION_LIST_FIRST_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try


        'obj_Party_Selection.Single_List_Load_Data()

    End Sub
    Public Function Single_MillShade_Selection_ItemWiseShade(ByVal _ItemCode As String, ByVal _MillName As String)
        Dim _Query As String = ""
        Party_selection.Label4.Text = "MillShade"

        If _MillName > "" Then _MillName = " AND a.MILLNAME ='" & _MillName & "'"

        Dim _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT *  ")
            .Append(" from MstFabricItem  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND ID='" & _ItemCode & "' ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim ItemWiseShadeCode = DefaltSoftTable.Rows(0).Item("OP11").ToString
        If ItemWiseShadeCode.Trim <> "(  )" And ItemWiseShadeCode.Trim > "" Then

            ItemWiseShadeCode = Replace(ItemWiseShadeCode.ToString, "#", "'").Replace("#", "'")

            strQuery = New StringBuilder
            With strQuery

                .Append(" SELECT ")
                .Append(" a.SHADENAME + '(' + a.MILLNAME + ')' as [Shade]  ")
                .Append(" ,a.SHADETYPE as [Type]  ")
                .Append(" ,a.SHADECODE")
                .Append(" ,B.SHADE as [Fab. Shade]  ")
                .Append(" ,C.ITENNAME as [Fab. Item] ")
                .Append(" FROM MSTMILLSHADE as a ")
                .Append(" ,Mst_Fabric_Shade AS B")
                .Append(" ,MstFabricItem AS C")
                .Append(" where 1=1 ")
                .Append(" AND A.FABRICSHADECODE=B.ID")
                .Append(" AND A.OP2=C.ID")
                '.Append(" AND B.ID in " & ItemWiseShadeCode & "")
                .Append(" AND A.op2 = '" & _ItemCode & "' ")
                .Append(_MillName)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY a.SHADENAME ")
                '.Append(" ORDER BY cast(a.SHADENAME as unsigned)  ")
            End With
            _Query = strQuery.ToString

        End If


        'Single_List_Load_Data()
        'GROUP_WISE_MULTY_PARTY_SELECT = ""

        Return _Query
    End Function
    Public Sub Single_LoomNo_Selection()
        Party_selection.Label4.Text = "Loom_no_info"
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" a.LOOMNO as [Loom No],a.rpm as [RPM], ")
            .Append(" a.LoomNoCode,a.LoomNoCode,a.LoomNoCode ")
            .Append(" FROM MSTLOOMNO as a ")
            .Append(" where 1=1 ")
            .Append(GROUP_WISE_MULTY_PARTY_SELECT)
            .Append(" ORDER BY CAST(A.LOOMNO AS INT) ")
        End With
        sqL = strQuery.ToString
        Single_List_Load_Data()
        GROUP_WISE_MULTY_PARTY_SELECT = ""
    End Sub
    'Public Sub Single_Location_Selection()

    '    _strQuery = New StringBuilder
    '    With _strQuery
    '        .Append(" SELECT ")
    '        .Append(" ISNULL(OP16,'.') AS Location ")
    '        .Append(" ,'' AS REMARK ")
    '        .Append(" ,ISNULL(OP16,'.') AS Location ")
    '        .Append(" ,ISNULL(OP16,'.') AS Location ")
    '        .Append(" ,ISNULL(OP16,'.') AS Location ")
    '        .Append(" FROM trnGrading  ")
    '        .Append(" WHERE 1=1 ")
    '        .Append(" GROUP BY OP16 ")
    '        .Append(" ORDER BY OP16 ")
    '    End With
    '    sqL = _strQuery.ToString
    '    Single_List_Load_Data()
    'End Sub

    Public Sub Single_LoomType_Selection()

        Party_selection.Label4.Text = "Loom_Type"
        sqL = " SELECT A.LOOM_TYPE as [Loom Type], '' as Remark ,A.ID,A.ID,A.ID FROM MstLoomType A  ORDER BY A.LOOM_TYPE"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_SalesMan_Selection()
        Party_selection.Label4.Text = "SalesManAccountMaster"
        sqL = " SELECT A.salesmanname as [Saleman], '' as Remark ,A.salesmancode,A.salesmancode,A.salesmancode FROM MstSalesMan A  ORDER BY A.salesmanname"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_StichItem_Selection()
        Party_selection.Label4.Text = "StichingItem"
        sqL = " SELECT A.STICH_ITEM_NAME as [Item Name], '' as Remark ,A.STICHITEM_ID,A.STICHITEM_ID,A.STICHITEM_ID FROM STC_MstStichingItem A  ORDER BY A.STICH_ITEM_NAME"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_MasterWise_StichItem_Selection(ByRef MasterCode As String)
        Party_selection.Label4.Text = "StichingItem"
        sqL = " SELECT A.STICH_ITEM_NAME as [Item Name], a.CUSTOMER_RATE as [Stich Rate] ,A.STICHITEM_ID,A.STICHITEM_ID,A.STICHITEM_ID FROM STC_MstStichingItem A,STC_MstTailorMaster B WHERE 1=1 AND A.MASTER_ID=B.TAILORCODE AND A.MASTER_ID ='" & MasterCode & "' ORDER BY A.STICH_ITEM_NAME"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_Stich_Master_Selection()
        Party_selection.Label4.Text = "StichingTailorMaster"
        sqL = " SELECT A.TAILORNAME as [Master Name], a.MOBILE as [MOBILE] ,A.TAILORCODE,A.TAILORCODE,A.TAILORCODE FROM STC_MstTailorMaster A  ORDER BY A.TAILORNAME"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_Stich_GROUP_Selection()
        Party_selection.Label4.Text = "StichingItemGroup"
        sqL = " SELECT A.GROUP_NAME as [Group Name], a.REMARK as [Remark] ,A.GROUP_ID,A.GROUP_ID,A.GROUP_ID FROM STC_MstStichingItemGroup A  ORDER BY A.GROUP_NAME"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_Stich_Worker_Selection()
        Party_selection.Label4.Text = "STC_MstWorkerAccount"
        sqL = " SELECT A.WORKERNAME as [Worker Name], a.REMARK as [Remark] ,A.WORKERRCODE,A.WORKERRCODE,A.WORKERRCODE FROM STC_MstWorkerAccount A  ORDER BY A.WORKERNAME"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_YarnBlend_Selection()
        Party_selection.Label4.Text = "YarnBlend"
        sqL = " SELECT A.BLENDNAME as [Blend Name], '' as [Remark] ,A.BLENDCODE,A.BLENDCODE,A.BLENDCODE FROM MSTYARNBLEND A  ORDER BY A.BLENDNAME"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_LogBookWeaver_Selection()
        Party_selection.Label4.Text = "Weaver_Master"
        sqL = " SELECT A.EmpName as [Weaver Name], '' as Remark ,A.EmpCode,A.EmpCode,A.EmpCode FROM MstLogBookWeaver A  ORDER BY A.EmpName"
        Single_List_Load_Data()
    End Sub
    Public Sub Single_size_Selection()
        Party_selection.Label4.Text = "Frm_SizeMaster"
        sqL = " SELECT a.SizeName as [Size Name],a.op1 as Remark,A.SizeCode,A.SizeCode,A.SizeCode FROM MstSize AS A ORDER BY a.op11,SizeName "
        Single_List_Load_Data()
    End Sub

    Public Sub Single_Godown_Selection()
        Party_selection.Label4.Text = "GodownMaster"
        sqL = " SELECT a.GodownName as [Godown Name],'' as Remark,A.GodownCode,A.GodownCode,A.GodownCode FROM MstGodown AS A ORDER BY A.GodownName "
        Single_List_Load_Data()
    End Sub


    Public Sub Single_Fabric_Item_Group_Selection()
        Party_selection.Label4.Text = "Fabric_Group"
        sqL = " SELECT a.fabric_GroupName as [Group Name],'' as Remark,A.ID,A.ID,A.ID FROM MstFabricGroup AS A ORDER BY fabric_GroupName "
        Single_List_Load_Data()
    End Sub
    Public Sub Single_Color_Selection()
        Party_selection.Label4.Text = "Frm_Color"
        sqL = " SELECT a.ColorName as [Color Name],'' as Remark,A.ColorCode,A.ColorCode,A.ColorCode FROM MstColor AS A ORDER BY ColorName "
        Single_List_Load_Data()
    End Sub
    Public Sub Single_State_Selection()
        sqL = "select MSTS.StateName,MSTS.COUNTRY,CAST (MSTS.STATEID AS varchar) AS ID,CAST (MSTS.STATEID AS varchar) AS ID,CAST (MSTS.STATEID AS varchar) AS ID from MstState as [MSTS] ORDER BY MSTS.StateName "
        Single_List_Load_Data()
    End Sub
    Public Sub Single_STORE_DEPARTMENT_Selection()
        Party_selection.Label4.Text = "StoreDepartment"
        sqL = " SELECT a.Departmentname as [Dep. Name],a.Descr as Remark,A.Departmentcode,A.Departmentcode,A.Departmentcode FROM MstDepartment AS A ORDER BY Departmentname "
        Single_List_Load_Data()
    End Sub

    Public Sub Single_Yarn_Type_Selection()
        Party_selection.Label4.Text = "YarnTypeMaster"
        sqL = " SELECT a.YarnTypeName as [Yarn Type],'' as Remark,A.YarnTypeCode,A.YarnTypeCode,A.YarnTypeCode FROM MstYarnType AS A ORDER BY YarnTypeName "
        Single_List_Load_Data()
    End Sub

    Public Sub Single_BeamPipeNo_Selection(ByVal _FilterString As String)
        Party_selection.Label4.Text = "BeamPipeNoMaster"

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append("  CAST(A.BeamPipeNo AS INT) AS [Beam Pipe No], ")
            .Append("  ISNULL(A.SLAB, 0) AS Weight, ")
            .Append("  A.BeamPipeCode ")
            .Append("  ,A.BeamPipeCode ")
            .Append("  ,A.BeamPipeCode ")
            .Append(" FROM MstBeamPipeNo AS A ")
            .Append(" WHERE 1=1 ")
            .Append(_FilterString)
            .Append("  AND ISNUMERIC(A.BeamPipeNo) = 1 ")
            .Append("  AND A.BeamPipeNo NOT LIKE '%.%' ")
            .Append(" ORDER BY CAST(A.BeamPipeNo AS INT) ")
        End With
        sqL = _strQuery.ToString
        Single_List_Load_Data()
    End Sub




    Public Sub BILL_NO_WISE_SELECTION()
        Try
            Dim _strQuery As New StringBuilder
            With _strQuery
                .Append(" SELECT A.BILLNO AS [Bill No], FORMAT (A.billdate,'dd/MM/yyyy') AS [Bill Date],A.accountcode,")
                .Append(" A.accountcode,E.ACCOUNTNAME AS [AGENT NAME ]  ")
                .Append(" FROM TRNOUTSTANDING AS A, MstMasterAccount AS D, MstMasterAccount AS E")
                .Append(" WHERE A.accountcode = D.accountcode")
                .Append(" AND D.AGENTCODE = E.ACCOUNTCODE  ")
                .Append(" AND A.accountcode = '" & OUTSTANDING_RUNTIME_ACCOUNTCODE & "'  ")
                .Append(" GROUP BY   ")
                .Append(" A.BILLNO,A.billdate,A.accountcode,E.ACCOUNTNAME ")

            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim TAB As New DataTable
            TAB = DefaltSoftTable.Copy
            Party_selection.dgw.DataSource = TAB
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 150
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 330
            Party_selection.Width = 644
            SELECTION_LIST_FIRST_SELECTION()
            OUTSTANDING_RUNTIME_ACCOUNTCODE = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub DeliveryAt_Selection(ByVal _BookCode As String)
        Try
            Party_selection.Label4.Text = "Master_frm"

            Dim BookGroupCode As String = ""
            Dim Str_In_BookGroupCode As String = ""

            sqL = "SELECT Y_JOB_PARTY_STK_FLD  FROM MstBook WHERE BookCode='" & _BookCode & "'"
            sql_connect_slect()

            If DefaltSoftTable.Rows(0).Item("Y_JOB_PARTY_STK_FLD").ToString > "" Then
                If DefaltSoftTable.Rows(0).Item("Y_JOB_PARTY_STK_FLD") = "YES" Then DefaltSoftTable.Rows(0).Item("Y_JOB_PARTY_STK_FLD") = ""
                If DefaltSoftTable.Rows(0).Item("Y_JOB_PARTY_STK_FLD") = "NO" Then DefaltSoftTable.Rows(0).Item("Y_JOB_PARTY_STK_FLD") = ""

                'BookGroupCode = Replace(dr("Y_JOB_PARTY_STK_FLD").ToString, "'", "'")
                BookGroupCode = DefaltSoftTable.Rows(0).Item("Y_JOB_PARTY_STK_FLD").ToString
            End If

            If BookGroupCode <> "" Then
                If (BookGroupCode).ToString.Trim.Length = 18 Then
                    Str_In_BookGroupCode = " AND A.GROUPCODE='" & Mid((BookGroupCode).ToString, 3, 14) & "' "
                Else
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "'", "'")
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "#", "'")
                End If
            End If

            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT   A.ACCOUNTNAME,B.CITYNAME, A.ACCOUNTCODE, A.GROUPCODE, D.ACCOUNTNAME AS AGENTNAME  ")
                .Append(" FROM MstMasterAccount AS A LEFT JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
                .Append(" LEFT JOIN MSTFINGROUP AS C ON A.GROUPCODE=C.GROUPCODE")
                .Append(" LEFT JOIN  MstMasterAccount AS D  ON A.AGENTCODE=D.ACCOUNTCODE  WHERE 1=1 ")
                .Append(Str_In_BookGroupCode)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                '.Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            DefaltSoftTable.DefaultView.Sort = "ACCOUNTNAME ASC"
            DefaltSoftTable = DefaltSoftTable.DefaultView.ToTable

            Str_In_BookGroupCode = ""
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 330
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644
            Party_selection.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection.dgw.Columns(1).HeaderText = "City Name"
            Party_selection.dgw.Columns(4).HeaderText = "Agent Name"

            Party_selection.dgw.Sort(Party_selection.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub single_AccountSelectionBalanceWise()
        Try
            Party_selection.Label4.Text = "Master_frm"

            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT ")
                .Append(" ISNULL(A.ACCOUNTNAME,'') as [Account Name] ")
                .Append(" ,ISNULL(B.CITYNAME,'') as [City Name] ")
                .Append(" ,ISNULL(A.ACCOUNTCODE ,'') AS ACCOUNTCODE ")
                .Append(" ,ISNULL(D.ACCOUNTNAME,'') as [Agent Name] ")
                .Append(" ,(case when ABS (SUM (Z.BALANCE)) = 0 then '' else convert(varchar(30), ABS (SUM (Z.BALANCE))) end) as [Balance] ")
                .Append(" ,IIF(SUM (Z.BALANCE)=0,'',CASE WHEN SUM (Z.BALANCE)>0 THEN 'Dr' ELSE 'Cr' END) as DC ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" A.ACCOUNTCODE ")
                .Append(" ,0 AS BALANCE ")
                .Append(" ,'' AS DC ")
                .Append(" FROM ")
                .Append(" MstMasterAccount A ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" E.ACCOUNTCODE ")
                .Append(" ,(ISNULL (SUM(E.debitamt ),NULL) - ISNULL(SUM(E.creditamt ),NULL)) AS BALANCE ")
                .Append(" , CASE WHEN SUM(E.debitamt )>SUM(E.creditamt ) THEN 'Dr' ELSE 'Cr' END AS DC ")
                .Append(" FROM ")
                .Append(" TrnLedger E ")
                .Append(" GROUP BY ")
                .Append(" E.ACCOUNTCODE ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstMasterAccount A ON Z.ACCOUNTCODE=A.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTCITY B ON A.CITYCODE=B.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount D ON A.AGENTCODE=D.ACCOUNTCODE ")
                .Append(" WHERE 1=1 ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" GROUP BY ")
                .Append(" A.ACCOUNTCODE ")
                .Append(" ,A.ACCOUNTNAME ")
                .Append(" ,B.CITYNAME ")
                .Append(" ,D.ACCOUNTNAME ")
                .Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _StrQuer.ToString

            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            'Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(2).Visible = False

            Party_selection.dgw.Columns(4).Visible = True

            Party_selection.dgw.Columns(0).Width = 310
            Party_selection.dgw.Columns(1).Width = 100
            Party_selection.dgw.Columns(2).Width = 110
            Party_selection.dgw.Columns(3).Width = 100
            Party_selection.dgw.Columns(4).Width = 80
            Party_selection.dgw.Columns(5).Width = 30

            Party_selection.Width = 644
            Party_selection.dgw.Width = 644
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub



    Public Sub Account_Selection()
        Try
            Party_selection.Label4.Text = "Master_frm"

            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT   A.ACCOUNTNAME,B.CITYNAME, A.ACCOUNTCODE, A.GROUPCODE, D.ACCOUNTNAME AS AGENTNAME  ")
                .Append(" FROM MstMasterAccount AS A LEFT JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
                .Append(" LEFT JOIN MSTFINGROUP AS C ON A.GROUPCODE=C.GROUPCODE")
                .Append(" LEFT JOIN  MstMasterAccount AS D  ON A.AGENTCODE=D.ACCOUNTCODE  WHERE 1=1 ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                '.Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            DefaltSoftTable.DefaultView.Sort = "ACCOUNTNAME ASC"
            DefaltSoftTable = DefaltSoftTable.DefaultView.ToTable

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 330
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644
            Party_selection.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection.dgw.Columns(1).HeaderText = "City Name"
            Party_selection.dgw.Columns(4).HeaderText = "Agent Name"

            Party_selection.dgw.Sort(Party_selection.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub



    Public Sub Invoice_Party_Selection()
        Try
            Party_selection.Label4.Text = "Master_frm"

            Dim BookGroupCode As String = ""
            Dim Str_In_BookGroupCode As String = ""

            sqL = "SELECT Group_Code_Filter_String  FROM MstBook WHERE BookCode='" & party_selection_book_code & "'"
            ConnDB()
            cmd = New SqlClient.SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While dr.Read = True
                BookGroupCode = Replace(dr("Group_Code_Filter_String").ToString, "'", "'")
            Loop
            cmd.Dispose()
            dr.Close()
            conn.Close()

            If BookGroupCode <> "" Then
                If (BookGroupCode).ToString.Trim.Length = 18 Then
                    Str_In_BookGroupCode = " AND A.GROUPCODE='" & Mid((BookGroupCode).ToString, 3, 14) & "' "
                Else
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "'", "'")
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "#", "'")
                End If
            End If
            If Str_In_BookGroupCode > "" Then Str_In_BookGroupCode = Str_In_BookGroupCode & " OR A.GROUPCODE ='0000-000000029'"
            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT   A.ACCOUNTNAME,B.CITYNAME, A.ACCOUNTCODE, A.GROUPCODE, D.ACCOUNTNAME AS AGENTNAME  ")
                .Append(" FROM MstMasterAccount AS A LEFT JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
                .Append(" LEFT JOIN MSTFINGROUP AS C ON A.GROUPCODE=C.GROUPCODE")
                .Append(" LEFT JOIN  MstMasterAccount AS D  ON A.AGENTCODE=D.ACCOUNTCODE  WHERE 1=1 ")
                .Append(Str_In_BookGroupCode)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                '.Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            DefaltSoftTable.DefaultView.Sort = "ACCOUNTNAME ASC"
            DefaltSoftTable = DefaltSoftTable.DefaultView.ToTable

            Str_In_BookGroupCode = ""
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 330
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644
            Party_selection.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection.dgw.Columns(1).HeaderText = "City Name"
            Party_selection.dgw.Columns(4).HeaderText = "Agent Name"

            Party_selection.dgw.Sort(Party_selection.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub OnlineOrder_Party_Selection(ByVal SeletedFromName As String)
        Try
            Party_selection.Label4.Text = SeletedFromName

            Dim BookGroupCode As String = ""
            Dim Str_In_BookGroupCode As String = ""

            sqL = "SELECT Group_Code_Filter_String  FROM MstBook WHERE BookCode='" & party_selection_book_code & "'"
            ConnDB()
            cmd = New SqlClient.SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While dr.Read = True
                BookGroupCode = Replace(dr("Group_Code_Filter_String").ToString, "'", "'")
            Loop
            cmd.Dispose()
            dr.Close()
            conn.Close()

            If BookGroupCode <> "" Then
                If (BookGroupCode).ToString.Trim.Length = 18 Then
                    Str_In_BookGroupCode = " AND A.GROUPCODE='" & Mid((BookGroupCode).ToString, 3, 14) & "' "
                Else
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "'", "'")
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "#", "'")
                End If
            End If

            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT   A.ACCOUNTNAME,B.CITYNAME, A.ACCOUNTCODE, A.GROUPCODE, D.ACCOUNTNAME AS AGENTNAME  ")
                .Append(" FROM MstMasterAccount AS A LEFT JOIN MSTCITY AS B ON A.CITYCODE=B.CITYCODE")
                .Append(" LEFT JOIN MSTFINGROUP AS C ON A.GROUPCODE=C.GROUPCODE")
                .Append(" LEFT JOIN  MstMasterAccount AS D  ON A.AGENTCODE=D.ACCOUNTCODE  WHERE 1=1 ")
                .Append(Str_In_BookGroupCode)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                '.Append(" ORDER BY A.ACCOUNTNAME ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            DefaltSoftTable.DefaultView.Sort = "ACCOUNTNAME ASC"
            DefaltSoftTable = DefaltSoftTable.DefaultView.ToTable

            Str_In_BookGroupCode = ""
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 330
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644
            Party_selection.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection.dgw.Columns(1).HeaderText = "City Name"
            Party_selection.dgw.Columns(4).HeaderText = "Agent Name"

            Party_selection.dgw.Sort(Party_selection.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Bill_Agent_SELECTION()
        Try
            Party_selection.Label4.Text = "Agent_master"

            'sqL = "select MACC.ACCOUNTNAME AS AGENT,MC.cityname,MACC.ACCOUNTCODE,MACC.ACCOUNTCODE,MACC.ACCOUNTCODE from MstMasterAccount AS MACC iNNER JOIN MstCity AS MC ON MACC.CITYCODE=MC.citycode where MACC.GROUPCODE='0000-000000052'"
            sqL = "SELECT A.ACCOUNTNAME AS [Agent Name] ,B.GROUPNAME AS [Group Name],A.ACCOUNTCODE,A.ACCOUNTCODE,A.ACCOUNTCODE FROM MstMasterAccount A,MstFinGroup B  WHERE  1=1 AND A.GROUPCODE=B.GROUPCODE  AND A.GROUPCODE='0000-000000052' ORDER BY A.ACCOUNTNAME"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Single_process_Selection()
        Try
            Party_selection.Label4.Text = "Master_frm"
            Party_selection.txtSearch.SelectAll()
            sqL = "  SELECT   A.ACCOUNTNAME,B.CITYNAME, A.ACCOUNTCODE, A.GROUPCODE, D.ACCOUNTNAME AS AGENTNAME  FROM MstMasterAccount AS A, MSTCITY AS B, MSTFINGROUP AS C, MstMasterAccount AS D  WHERE (((A.CITYCODE)=[B].[CITYCODE])  AND ((A.GROUPCODE)=[C].[GROUPCODE])   AND ((A.AGENTCODE)=[D].[ACCOUNTCODE]) and (A.GROUPCODE ='0000-000000039')) "
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 330
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644
            Party_selection.dgw.Columns(0).HeaderText = "Account Name"
            Party_selection.dgw.Columns(1).HeaderText = "City Name"
            Party_selection.dgw.Columns(4).HeaderText = "Agent Name"

            Party_selection.dgw.Sort(Party_selection.dgw.Columns(0), ListSortDirection.Ascending)
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub Single_Selvedge_Selection()
        Try
            Party_selection.Label4.Text = "Selvedge"

            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.SELVEDGE_NAME as [Selvedge Name],B.ITENNAME as[Quality Name],A.ID,A.ID,A.ID")
                .Append(" FROM Mst_selvedge A LEFT JOIN MstFabricItem B ON A.item_code=B.ID")
                .Append(" WHERE 1=1 ")

                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" OR A.ID='0000-000000001' ")
                .Append(" ORDER BY SELVEDGE_NAME")
            End With
            sqL = _StrQuer.ToString
            sql_connect_slect()

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506

            Party_selection.dgw.Columns(0).HeaderText = "Selvedge Name"
            Party_selection.dgw.Columns(1).HeaderText = "Quality Name"

            SELECTION_LIST_FIRST_SELECTION()

            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Function QualitySelectionQuery(ByVal _FilterAccountCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.ITENNAME,A.HSNCODE,A.ID,A.ID,A.GROUPID ")
            .Append(" FROM MstFabricItem A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND ISNULL(A.OP10,'YES') <> 'NO' ")
            .Append(_FilterAccountCode)
            .Append(" ORDER BY A.ITENNAME")
        End With
        Return _strQuery.ToString
    End Function
    Public Sub MillWiseQualitySelection(ByVal _FilterAccountCode As String, ByVal SelectionType As String)

        Try
            Party_selection.Label4.Text = "Fabric_Item_Master_Frm"


            sqL = QualitySelectionQuery(_FilterAccountCode)
            sql_connect_slect()

            If SelectionType = "SINGLE" Then
                Party_selection.dgw.DataSource = DefaltSoftTable.Copy
                GROUP_WISE_MULTY_PARTY_SELECT = ""
                Party_selection.dgw.Columns(2).Visible = False
                Party_selection.dgw.Columns(3).Visible = False
                Party_selection.dgw.Columns(4).Visible = False
                Party_selection.dgw.Columns(0).Width = 350
                Party_selection.dgw.Columns(1).Width = 130
                Party_selection.Width = 506
                Party_selection.dgw.Columns(0).HeaderText = "Item Name"
                Party_selection.dgw.Columns(1).HeaderText = "HSN Code"
                SELECTION_LIST_FIRST_SELECTION()
                Party_selection.Close()
                Party_selection.Dispose()

            Else

                Party_selection_multy.dgw.DataSource = DefaltSoftTable.Copy
                Dim Chk As New DataGridViewCheckBoxColumn()
                Party_selection_multy.dgw.Columns.Add(Chk)
                Party_selection_multy.dgw.Columns(2).Visible = False
                Party_selection_multy.dgw.Columns(3).Visible = False
                Party_selection_multy.dgw.Columns(4).Visible = False
                Party_selection_multy.dgw.Columns(0).Width = 380
                Party_selection_multy.dgw.Columns(1).Width = 200
                Party_selection_multy.dgw.Columns(2).Width = 150
                Party_selection_multy.dgw.Columns(5).Width = 30
                Party_selection_multy.Width = 644
                Party_selection_multy.dgw.Columns(0).HeaderText = "Item Name"
                Party_selection_multy.dgw.Columns(1).HeaderText = "HSN Code"
                Party_selection_multy.dgw.Columns(5).HeaderText = "Chk"
                SELECTION_LIST_FIRST_multy_SELECTION()
            End If


            Book_Behaviour = ""
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub

    Public Sub SINGLE_ITEM_SELECTION()
        Try
            Party_selection.Label4.Text = "Fabric_Item_Master_Frm"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.ITENNAME,A.HSNCODE,A.ID,A.ID,A.GROUPID ")
                .Append(" FROM MstFabricItem A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP10,'YES')<>'NO'")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.ITENNAME")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""

            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(4).Visible = False
            Party_selection.dgw.Columns(0).Width = 350
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.Width = 506

            Party_selection.dgw.Columns(0).HeaderText = "Item Name"
            Party_selection.dgw.Columns(1).HeaderText = "HSN Code"

            SELECTION_LIST_FIRST_SELECTION()
            Party_selection.Close()
            Party_selection.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_ITEM_SELECTION_TypeingWise(ByVal _SearchText)

        Try
            If _SearchText = Nothing Then _SearchText = ""
            Party_selection.Label4.Text = "Fabric_Item_Master_Frm"

            sqL = "SELECT A.ITENNAME,A.HSNCODE,A.ID,A.ID,A.GROUPID FROM MstFabricItem A   WHERE A.ITENNAME LIKE '%" & _SearchText.ToString.Trim & "%'  ORDER BY A.ITENNAME"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""

            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 350
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.Width = 506

            Party_selection.dgw.Columns(0).HeaderText = "Item Name"
            Party_selection.dgw.Columns(1).HeaderText = "HSN Code"

            'SELECTION_LIST_FIRST_SELECTION()
            'Party_selection.Close()
            'Party_selection.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SINGLE_ITEM_DESCBARCODE_SELECTION()
        Party_selection.Label4.Text = "Fabric_Item_Master_Frm"
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" A.ITENNAME as [Item Name],A.DESCRP AS [Barcode] ")
            .Append(" ,A.ID,A.ID,A.GROUPID ")
            .Append(" FROM MstFabricItem as a ")
            .Append(" where 1=1 ")
            .Append(GROUP_WISE_MULTY_PARTY_SELECT)
            .Append(" ORDER BY ITENNAME ")
        End With
        sqL = strQuery.ToString
        Single_List_Load_Data()
        GROUP_WISE_MULTY_PARTY_SELECT = ""
    End Sub
    Public Sub SINGLE_Finish_Remark_SELECTION()
        Try
            Party_selection.Label4.Text = "Remaek_frm"
            If GROUP_WISE_MULTY_PARTY_SELECT <> "" Then
                GROUP_WISE_MULTY_PARTY_SELECT = " AND " & GROUP_WISE_MULTY_PARTY_SELECT
            End If

            sqL = "SELECT A.RemarkName,A.Remark_For,A.RemarkCode,A.RemarkCode,A.RemarkCode FROM MstRemark A  WHERE 1=1 " & GROUP_WISE_MULTY_PARTY_SELECT & " AND ISNULL(OP6,'') = '' ORDER BY A.RemarkName"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Remark"
            Party_selection.dgw.Columns(1).HeaderText = "Remark For"

            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_Location()
        Try

            Party_selection.Label4.Text = "RackMaster"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" ISNULL(LocationName,'.') AS Location ")
                .Append(" ,'' AS REMARK ")
                .Append(" ,LocationCode ")
                .Append(" ,LocationCode ")
                .Append(" ,LocationCode ")
                .Append(" FROM MstLocation ")
                .Append(" WHERE 1=1 ")
                .Append(" GROUP BY LocationName,LocationCode ")
                .Append(" ORDER BY LocationName ")
            End With
            sqL = _strQuery.ToString
            Single_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_Location_SELECTION(ByVal strCondtion As String)
        Try

            Party_selection.Label4.Text = "RackMaster"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT* FROM( ")
                .Append(" SELECT ")
                .Append(" ISNULL(OP16,'.') AS Location ")
                .Append(" ,'' AS REMARK ")
                .Append(" ,ISNULL(OP16,'.') AS Location1 ")
                .Append(" ,ISNULL(OP16,'.') AS Location2 ")
                .Append(" ,ISNULL(OP16,'.') AS Location3 ")
                .Append(" FROM trnGrading ")
                .Append(" WHERE 1=1 ")
                .Append(" GROUP BY OP16 ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" ISNULL(LocationName,'.') AS Location ")
                .Append(" ,'' AS REMARK ")
                .Append(" ,ISNULL(LocationName,'.') AS Location1 ")
                .Append(" ,ISNULL(LocationName,'.') AS Location2 ")
                .Append(" ,ISNULL(LocationName,'.') AS Location3 ")
                .Append(" FROM MstLocation ")
                .Append(" WHERE 1=1 ")
                .Append(" GROUP BY LocationName ")
                .Append(" ) AS Z ")
                .Append(" GROUP BY Location ,REMARK,Location1,Location2,Location3 ")
                .Append(" ORDER BY Location ")
            End With
            sqL = _strQuery.ToString
            Single_List_Load_Data()


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_POST_SELECTION(ByVal strCondtion As String)
        Try
            Party_selection.Label4.Text = "Post"
            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" POSTNAME as [Post] ")
                .Append(" ,descr as [Descr] ")
                .Append(" ,A.POSTCODE ")
                .Append(" ,A.POSTCODE ")
                .Append(" ,A.POSTCODE ")
                .Append(" ,A.POSTCODE ")
                .Append(" FROM MSTPOST A ")
                .Append("  WHERE 1=1  ")
                .Append(strCondtion)
                .Append("  ORDER BY A.POSTNAME ")
            End With
            sqL = _StrQuer.ToString
            Single_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SINGLE_EARNINGHEAD_SELECTION(ByVal strCondtion As String)
        Try
            Party_selection.Label4.Text = "EarningHead"
            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.EARN_HEAD_NAME AS [Earning Head Name] ")
                .Append(" ,'' as [Remark] ")
                .Append(" A.EARN_HEAD_CODE ")
                .Append(" A.EARN_HEAD_CODE ")
                .Append(" A.EARN_HEAD_CODE ")
                .Append(" FROM MstEarningHead A  ")
                .Append(" WHERE 1=1 ")
                .Append(strCondtion)
                .Append("  ORDER BY A.EARN_HEAD_NAME  ")
            End With
            sqL = _StrQuer.ToString
            Single_List_Load_Data()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SINGLE_DEDUCTIONHEAD_SELECTION(ByVal strCondtion As String)
        Try
            Party_selection.Label4.Text = "DeductionHead"
            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.DED_HEAD_NAME AS [Deduction Head Name]  ")
                .Append(" ,'' as [Remark]  ")
                .Append(" ,A.DED_HEAD_CODE  ")
                .Append(" ,A.DED_HEAD_CODE  ")
                .Append(" ,A.DED_HEAD_CODE  ")
                .Append(" FROM MstDeductionHead A  ")
                .Append(" WHERE 1=1  ")
                .Append(strCondtion)
                .Append(" ORDER BY A.DED_HEAD_NAME  ")
            End With
            sqL = _StrQuer.ToString
            Single_List_Load_Data()


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SINGLE_Employee_SELECTION(ByVal strCondtion As String)
        Try
            Party_selection.Label4.Text = "Employee"

            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.EMPNAME As [Employee Name] ")
                .Append(" ,A.FATHERNAME as [Father Name] ")
                .Append(" ,A.EMPCODE ")
                .Append(" ,A.EMPCODE ")
                .Append(" ,B.PostName ")
                .Append(" ,A.EMPCODE ")
                .Append(" From MstEmployee A ")
                .Append(" left join MSTPOST as B ON A.PostCode=B.postcode ")
                .Append(" Where 1 = 1 ")
                .Append(strCondtion)
                .Append(" ORDER BY A.EMPNAME ")
            End With
            sqL = _StrQuer.ToString
            Single_List_Load_Data_Three_Coloum()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_Remark_SELECTION(ByVal _REMARKFOR As String)
        Try
            Party_selection.Label4.Text = "Remaek_frm"
            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.RemarkName AS Remark ,'' as [Other Remark]  ")
                .Append(" ,A.RemarkCode,A.RemarkCode,A.RemarkCode ")
                .Append(" FROM MstRemark A ")
                .Append(" WHERE 1=1 AND ( Remark_For IN ('" & _REMARKFOR & "') ")
                .Append(" OR REMARKCODE='0000-000000001') ")
                .Append(" ORDER BY A.RemarkName ")
            End With
            sqL = _StrQuer.ToString
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_Voucher_Narration(ByVal BOOKCODE As String)
        Try
            Party_selection.Label4.Text = "narration_frm"


            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.Narration as Narration ,'' as Remark  ")
                .Append(" ,A.NarrCode,A.NarrCode,A.NarrCode ")
                .Append(" FROM MstNarration A WHERE 1=1 ")
                .Append(BOOKCODE)
                .Append(" ORDER BY A.Narration")
            End With

            sqL = _StrQuer.ToString
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_DESIGN_SELECTION(ByVal ITEMCODE_WISE As String)
        Try
            Party_selection.Label4.Text = "Fabric_design"


            _strQuery = New StringBuilder
            With _strQuery
                .Append("  Select A.Design_Name ")
                .Append(" ,B.ITENNAME ")
                .Append(" ,A.Design_code ")
                .Append(" ,A.Design_code ")
                .Append(" ,A.Design_code  ")
                .Append(" From Mst_Fabric_Design A ")
                .Append(" LEFT JOIN MstFabricItem B ON A.Item_Code=B.ID   ")
                .Append(" WHERE  1 = 1  ")
                .Append(ITEMCODE_WISE)
                .Append(" ORDER BY A.Design_Name ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy

            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Design No"
            Party_selection.dgw.Columns(1).HeaderText = "Quality Name"
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SingleUnitSelection()
        Party_selection.Label4.Text = "UnitMaster"

        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" Select ")
                .Append(" A.ToUnit as [Unit Type]")
                .Append(" ,A.ConversionFactor")
                .Append(" ,A.UnitID")
                .Append(" ,A.UnitID")
                .Append(" ,A.UnitID")
                .Append(" FROM MstUnitMaster A")
                .Append(" where 1=1 ")
                .Append(" AND A.IsActive='YES'")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY  A.FromUnit ")
            End With
            sqL = _strQuery.ToString
            obj_Party_Selection.Single_List_Load_Data()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SingleDesignToShadeSelection(ByVal DesignCode As String)
        Party_selection.Label4.Text = "Fabric_design"

        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" Select ")
                .Append(" A.SHADE As [Shade Name] ")
                .Append(" ,A.REMARK_COLOR As [Shade Type]")
                .Append(" ,A.Id")
                .Append(" ,A.OP3 As Remark ")
                .Append(" ,A.OP11 As [Extra Rate]")
                .Append(" FROM Mst_Fabric_Shade A")
                .Append(" LEFT JOIN Mst_Fabric_Design AS B ON A.ID=B.OP7  ")
                .Append(" where 1=1 ")
                .Append(DesignCode)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY  A.SHADE ")
            End With
            sqL = _strQuery.ToString
            obj_Party_Selection.Single_List_Load_Data_Four_Coloum_FiveItem()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SINGLE_SHADE_SELECTION(Optional ByVal MultyShadeOffer As String = "")
        Try
            Party_selection.Label4.Text = "Fabric_shade"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" Select ")
                .Append(" A.SHADE As [Shade Name] ")
                .Append(" ,A.REMARK_COLOR As [Shade Type]")
                .Append(" ,A.Id")
                .Append(" ,A.OP3 As Remark ")
                .Append(" ,A.OP11 As [Extra Rate]")
                .Append(" FROM Mst_Fabric_Shade A")
                .Append(" where 1=1 ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                '.Append(" ORDER BY  A.SHADE ")
                '.Append(" ORDER BY CASE WHEN A.SHADE NOT LIKE '%[^0-9]%' THEN CAST(A.SHADE AS INT) ELSE NULL END,A.SHADE")
                .Append(" ORDER BY TRY_CAST(LEFT(A.SHADE, PATINDEX('%[^0-9]%', A.SHADE + 'a') - 1) AS INT),A.SHADE")
            End With
            sqL = _strQuery.ToString
            obj_Party_Selection.Single_List_Load_Data_Four_Coloum_FiveItem()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_ACC_OF_SELECTION()
        Try
            Party_selection.Label4.Text = "Ac_master_info_frm"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" Select ")
                .Append(" A.AC_NAME As [A/C Of] ")
                .Append(" , C.ACCOUNTNAME As [Party Name] ")
                .Append(" , A.ID")
                .Append(" , A.ID")
                .Append(" , B.cityname As [City Name]")
                .Append(" FROM Mst_Acof_Supply A")
                .Append("  LEFT JOIN MstCity B  On A.CITY_CODE=B.citycode ")
                .Append("  LEFT JOIN MstMasterAccount As C  On  A.PART_NAME_ID=C.ACCOUNTCODE")
                .Append("  WHERE  1=1  ")

                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.AC_NAME")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy


            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False

            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 180
            Party_selection.dgw.Columns(4).Width = 150
            Party_selection.Width = 644


            SELECTION_LIST_FIRST_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_City_SELECTION()
        Try
            Party_selection.Label4.Text = "City_master_frm"

            _strQuery = New StringBuilder
            With _strQuery
                .Append("  Select B.cityname, A.StateName, B.citycode, B.citycode, B.citycode  ")
                .Append("  from MstState As A , MstCity As B   ")
                .Append("  WHERE ")
                .Append("  A.stateid = B.STATEID ")
                .Append("  ORDER BY B.cityname  ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy

            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "City Name"
            Party_selection.dgw.Columns(1).HeaderText = "State Name"
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Public Sub Single_Rack_Selection()
        Party_selection.Label4.Text = "RackMaster"
        sqL = " Select a.LocationName As [Rack Name],'' as Remark,A.LocationCode,A.LocationCode,A.LocationCode FROM MstLocation AS A ORDER BY A.LocationName "
        Single_List_Load_Data()
    End Sub

    Public Sub SingleFusionTreatmentSelection()
        Dim GradeTbl As New DataTable
        Dim Treatment = New DataColumn("Treatment Type", GetType(String))
        Dim Remark = New DataColumn("Remark", GetType(String))
        Dim Treatment1 = New DataColumn("Treatment1", GetType(String))
        Dim Treatment2 = New DataColumn("Treatment2", GetType(String))
        Dim Treatment3 = New DataColumn("Treatment3", GetType(String))

        GradeTbl.Columns.Add(Treatment)
        GradeTbl.Columns.Add(Remark)
        GradeTbl.Columns.Add(Treatment1)
        GradeTbl.Columns.Add(Treatment2)
        GradeTbl.Columns.Add(Treatment3)

        Dim GradeList() As String = _GetTextFile("FusionTratment.txt")

        For Each line As String In GradeList
            GradeTbl.Rows.Add(line, "", line, line, line)

        Next

        Party_selection.dgw.DataSource = GradeTbl
        Party_selection.dgw.Columns(2).Visible = False
        Party_selection.dgw.Columns(3).Visible = False
        Party_selection.dgw.Columns(0).Width = 280
        Party_selection.dgw.Columns(1).Width = 200
        Party_selection.Width = 506
        obj_Party_Selection.SELECTION_LIST_FIRST_SELECTION()

    End Sub
    Public Sub SingleGradeSelection()

        Dim GradeTbl As New DataTable
        Dim Grade = New DataColumn("Grade", GetType(String))
        Dim Remark = New DataColumn("Remark", GetType(String))
        Dim Grade1 = New DataColumn("Grade1", GetType(String))
        Dim Grade2 = New DataColumn("Grade2", GetType(String))
        Dim Grade3 = New DataColumn("Grade3", GetType(String))

        GradeTbl.Columns.Add(Grade)
        GradeTbl.Columns.Add(Remark)
        GradeTbl.Columns.Add(Grade1)
        GradeTbl.Columns.Add(Grade2)
        GradeTbl.Columns.Add(Grade3)

        Dim GradeList() As String = _GetGradeTextFile()

        For Each line As String In GradeList
            GradeTbl.Rows.Add(line, "", line, line, line)

        Next

        Party_selection.dgw.DataSource = GradeTbl
        Party_selection.dgw.Columns(2).Visible = False
        Party_selection.dgw.Columns(3).Visible = False
        Party_selection.dgw.Columns(0).Width = 280
        Party_selection.dgw.Columns(1).Width = 200
        Party_selection.Width = 506
        obj_Party_Selection.SELECTION_LIST_FIRST_SELECTION()


        '' Display DataTable contents
        'Console.WriteLine("Grades in DataTable:")
        'For Each row As DataRow In GradeTbl.Rows
        '    Console.WriteLine(row("Grade"))
        'Next

    End Sub

    Public Sub SINGLE_GRADER_SELECTION()
        Try
            Party_selection.Label4.Text = "Frm_Grader"

            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT A.GraderName, a.OP1 as MobileNo ,A.GraderCode,A.GraderCode,A.GraderCode   ")
                .Append("  from MstGrader as A   ")
                .Append("  ORDER BY  GraderName ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy

            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Grader Name"
            Party_selection.dgw.Columns(1).HeaderText = "MobileNo"
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Public Sub SINGLE_adjment_slection_list()
        Try
            sqL = "SELECT sunname,sunprnname,suncode,accountcode,suncode   FROM MstAdjTypes  " & GROUP_WISE_MULTY_PARTY_SELECT & " ORDER BY sunname"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Adj Name"
            Party_selection.dgw.Columns(1).HeaderText = "Alias"
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try

    End Sub
    Public Sub SINGLE_TRANSPORT_SELECTION()
        Try
            Party_selection.Label4.Text = "Transport_info_frm"

            sqL = "SELECT A.TRANSPORTNAME as [Transport Name] ,A.city as [City Name],A.ID,A.ID,A.GSTIN AS [Gst No] FROM MstTransport A  ORDER BY A.TRANSPORTNAME"
            obj_Party_Selection.Single_List_Load_Data_Three_Coloum()
            'sql_connect_slect()
            'Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            'Party_selection.dgw.Columns(2).Visible = False
            'Party_selection.dgw.Columns(3).Visible = False
            'Party_selection.dgw.Columns(0).Width = 280
            'Party_selection.dgw.Columns(1).Width = 200
            'Party_selection.Width = 506
            'Party_selection.dgw.Columns(0).HeaderText = "Transport Name"
            'Party_selection.dgw.Columns(1).HeaderText = "City Name"
            'SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_INSURANCE_SELECTION()
        Try
            Party_selection.Label4.Text = "Insurance_company_frm"

            sqL = "SELECT A.COMPANYNAME,A.POLICYNO,A.ID,A.ID,A.ID FROM MstInsuranceCompany A where a.TOPUPCOMPANY is null ORDER BY COMPANYNAME"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506

            Party_selection.dgw.Columns(0).HeaderText = "Company Name"
            Party_selection.dgw.Columns(1).HeaderText = "Police No"
            SELECTION_LIST_FIRST_SELECTION()


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_StoreItemGroup_SELECTION()
        Try
            Party_selection.Label4.Text = "Store_Item_Category"
            sqL = "SELECT A.GroupName,A.OP1 AS [Pur Rate],A.GroupCode,A.GroupCode,A.GroupCode  FROM MstStoreItemGroup A  ORDER BY A.GroupName"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Group Name"
            'Party_selection.dgw.Columns(1).HeaderText = "Remark"
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_YarnItem_SELECTION()
        Try
            Party_selection.Label4.Text = "Yarn_Item_Master_Frm"

            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT ")
                .Append(" A.CountName,A.HSNCode,A.CountCode,A.CountCode,A.CountCode ")
                .Append(" FROM MstYarnCount A")
                .Append(" WHERE 1=1 ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" AND ISNULL(A.OP4,'YES') <> 'NO' ")
                .Append(" ORDER BY A.CountName ")
            End With
            sqL = _StrQuer.ToString
            sql_connect_slect()

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506

            Party_selection.dgw.Columns(0).HeaderText = "Count Name"
            Party_selection.dgw.Columns(1).HeaderText = "HSN Code"
            SELECTION_LIST_FIRST_SELECTION()
            GROUP_WISE_MULTY_PARTY_SELECT = ""


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub SINGLE_YarnItem_SELECTION_TypeingWise(ByVal _SearchText)
        Try
            Party_selection.Label4.Text = "Yarn_Item_Master_Frm"

            Dim _StrQuer = New StringBuilder
            With _StrQuer
                .Append(" SELECT  ")
                .Append(" A.CountName,A.HSNCode,A.CountCode,A.CountCode,A.CountCode ")
                .Append(" FROM MstYarnCount A")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.CountName LIKE '%" & _SearchText.ToString.Trim & "%' ")
                .Append(" ORDER BY A.CountName ")
            End With
            sqL = _StrQuer.ToString
            sql_connect_slect()

            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506

            Party_selection.dgw.Columns(0).HeaderText = "Count Name"
            Party_selection.dgw.Columns(1).HeaderText = "HSN Code"


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub

    Public Sub SINGLE_store_Sub_Item_SELECTION()
        Try

            Party_selection.Label4.Text = "Store_SubItem"

            sqL = "SELECT A.SUBITEMNAME as [Sub Item Name],'' as Remark,A.subItemCode,A.subItemCode,A.subItemCode FROM MstStoreSubItem A WHERE 1=1  " & GROUP_WISE_MULTY_PARTY_SELECT & " ORDER BY A.SUBITEMNAME"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(4).Visible = False
            Party_selection.dgw.Columns(0).Width = 350
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.Width = 506
            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_storeItem_SELECTION()
        Try

            Party_selection.Label4.Text = "Store_Item"
            _strQuery = New StringBuilder
            With _strQuery
                .Append("  SELECT ")
                .Append(" A.ItemName as [Item Name] ")
                .Append(" ,B.GroupName as [Group Name] ")
                .Append(" ,A.ItemCode ")
                .Append(" ,A.Descr ")
                .Append(" ,A.Hsncode ")
                .Append(" FROM ")
                .Append(" MstStoreItem A  ")
                .Append(" LEFT JOIN MstStoreItemGroup  as B  ON  A.ItemGroupCode=B.GroupCode")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP7,'YES') <> 'NO' ")
                '.Append(" AND A.ItemGroupCode=B.GroupCode ")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.ItemName ")

            End With
            sqL = _strQuery.ToString()
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            'Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(4).Visible = True
            Party_selection.dgw.Columns(0).Width = 380
            Party_selection.dgw.Columns(1).Width = 80
            Party_selection.dgw.Columns(4).Width = 70
            Party_selection.dgw.Columns(3).Width = 70
            Party_selection.Width = 644

            GROUP_WISE_MULTY_PARTY_SELECT = ""

            SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_storeItem_SELECTION_TypeingWise(ByVal _SearchText)

        If _SearchText = Nothing Then _SearchText = ""
        Try
            Party_selection.Label4.Text = "MstStoreItem"

            sqL = "SELECT A.ItemName,A.HSNCode,A.ItemCode,A.ItemCode,A.ItemCode FROM MstStoreItem A WHERE 1=1  AND A.ITEMNAME LIKE '%" & _SearchText.ToString.Trim & "%'   ORDER BY A.ItemName"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(4).Visible = False
            Party_selection.dgw.Columns(0).Width = 350
            Party_selection.dgw.Columns(1).Width = 130
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Item Name"
            Party_selection.dgw.Columns(1).HeaderText = "HSN"
            'SELECTION_LIST_FIRST_SELECTION()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub SINGLE_FINENCE_GROUP_SELECTION()
        Try
            Party_selection.Label4.Text = "Group_frm"
            sqL = "Select A.GROUPNAME As [Group Name] ,B.ScheduleName As [Schedule Name] ,A.GROUPCODE,A.GROUPCODE,A.GROUPCODE FROM MstFinGroup A, MstFinSchedule B WHERE  1=1 And A.SCHEDULECODE=B.SrNo ORDER BY A.GROUPNAME"
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub SINGLE_Cut_SELECTION(ByVal CATEGORY As String)

        Try
            Party_selection.Label4.Text = "Cut_master_frm"

            sqL = "Select CUTM.CUTNAME,CUTM.CUTTYPE,CUTM.ID,CUTM.ID,CUTM.ID from MstCutMaster As CUTM where 1=1 " & CATEGORY & " ORDER BY CAST(CUTM.ORDERNO AS INT) "
            sql_connect_slect()
            Party_selection.dgw.DataSource = DefaltSoftTable.Copy
            Party_selection.dgw.Columns(2).Visible = False
            Party_selection.dgw.Columns(3).Visible = False
            Party_selection.dgw.Columns(0).Width = 280
            Party_selection.dgw.Columns(1).Width = 200
            Party_selection.Width = 506
            Party_selection.dgw.Columns(0).HeaderText = "Cut Name"
            Party_selection.dgw.Columns(1).HeaderText = "Cut Type"
            SELECTION_LIST_FIRST_SELECTION()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
#End Region

    Public Function Last_Grey_Desp_Pcs_ID_From_TrnGreyDesp_Table(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" Select TOP 1 SUBSTRING(Grey_Desp_Pcs_ID,6,15) ")
            .Append(" FROM TrnGreyDesp ")
            .Append(" WHERE 1=1 ")
            .Append(" And LEFT(Grey_Desp_Pcs_ID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY Grey_Desp_Pcs_ID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Transaction_Data_From_TrnGreyDesp_Table_According_To_BookCode(ByVal Book_Code As String, ByVal UNITCODE As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 A.*, convert(varchar,  A.CHALLANDATE, 103) AS F_CHALLANDATE, ")
            .Append(" convert(varchar,  A.SALES_DATE, 103)  AS F_SALES_DATE, ")
            .Append(" B.ACCOUNTNAME AS PROCESSNAME, C.ACCOUNTNAME AS FACTORYNAME, ")
            .Append(" D.ACCOUNTNAME AS PARTYNAME, E.ITENNAME AS FABRIC_ITEMNAME,E.WTPERMTR AS AVG_WEIGHT,E.WTVERIANCE AS AVG_WEIGHT_VARIANCE, ")
            .Append(" F.Design_Name AS FABRIC_DESIGN_NO, G.SHADE AS FABRIC_SHADE_NO, ")
            .Append(" H.REMARKNAME AS FINISHREMARK, I.SELVEDGE_NAME AS SELVNAME , (A.GMTR) AS F_GMTR, ")
            .Append(" (A.WEIGHT) AS F_WEIGHT,(A.PCAVGWT) AS F_PCAVGWT, ")
            .Append(" J.ACCOUNTNAME AS SALES_PARTY_NAME,K.AC_NAME AS SALES_ACOF_NAME ")

            .Append("  From TRNGREYDESP As A ")
            .Append("  Left Join  MstMasterAccount AS B ON A.PROCESSCODE=B.ACCOUNTCODE ")
            .Append("  Left Join   MstMasterAccount AS C ON A.FACTORYCODE=C.ACCOUNTCODE   ")
            .Append("  Left Join   MstMasterAccount AS D ON A.ACCOUNTCODE=D.ACCOUNTCODE  ")
            .Append("  Left Join    MSTFABRICITEM AS E ON  A.FABRIC_ITEMCODE=E.ID  ")
            .Append("  Left Join   Mst_Fabric_Design AS F ON A.FABRIC_DESIGNCODE=F.Design_code   ")
            .Append(" Left Join   Mst_Fabric_Shade AS G ON A.FABRIC_SHADECODE=G.ID  ")
            .Append("  Left Join   MSTREMARK AS H ON  A.FINISH_REMARK_CODE=H.REMARKCODE  ")
            .Append("  Left Join   Mst_selvedge AS I ON A.SELVCODE=I.ID ")
            .Append("  Left Join  MstMasterAccount AS J ON  A.SALES_ACCOUNTCODE=J.ACCOUNTCODE  ")
            .Append("  Left Join  Mst_Acof_Supply AS K ON A.ACOFCODE=K.ID   ")

            '.Append(" FROM TRNGREYDESP AS A, MstMasterAccount AS B, MstMasterAccount AS C, MstMasterAccount AS D, ")
            '.Append(" MSTFABRICITEM AS E, Mst_Fabric_Design AS F, Mst_Fabric_Shade AS G, MSTREMARK AS H, Mst_selvedge AS I, ")
            '.Append(" MstMasterAccount AS J,Mst_Acof_Supply AS K ")

            .Append(" WHERE 1=1 ")
            '.Append(" And A.PROCESSCODE=B.ACCOUNTCODE And A.FACTORYCODE=C.ACCOUNTCODE ")
            '.Append(" And A.SALES_ACCOUNTCODE=J.ACCOUNTCODE AND A.ACOFCODE=K.ID ")
            '.Append(" And A.ACCOUNTCODE=D.ACCOUNTCODE And ")
            '.Append(" A.FABRIC_ITEMCODE=E.ID And A.FABRIC_DESIGNCODE=F.Design_code ")
            '.Append(" And A.FABRIC_SHADECODE=G.ID And  A.FINISH_REMARK_CODE=H.REMARKCODE ")
            '.Append(" And A.SELVCODE=I.ID ")
            .Append(" AND A.BOOKCODE='" & Book_Code & "'" & "  ")
            .Append(UNITCODE)
            .Append(" ORDER BY ENTRYNO DESC ")
        End With
        Return _strQuery.ToString
    End Function
    Public Function Last_Piece_No_Accoring_To_Factory_Beam_No(ByVal Table_Name As String, ByVal Str_Beam_No As String, ByVal _BookCode As String, ByVal EntryNo As Integer, ByVal Factory_Filter_Condition As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 PIECENO,PICK,PICKRATE ")
            .Append(" FROM " & Table_Name & "  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND BEAMNO = '" & Str_Beam_No & "' ")
            .Append(" AND BOOKCODE='" & _BookCode & "' ")
            .Append(" AND ENTRYNO<>" & EntryNo & " ")
            .Append(Factory_Filter_Condition)
            .Append(" ORDER BY PIECENO DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Piece_No_Factory_Beam_No(ByVal Table_Name As String, ByVal Str_Beam_No As String, ByVal _BookCode As String, ByVal EntryNo As Integer, ByVal Factory_Filter_Condition As String, ByVal UNITCODE As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 PIECENO,PICK ")
            .Append(" FROM " & Table_Name & "  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND BEAMNO = '" & Str_Beam_No & "' ")
            .Append(" AND BOOKCODE='" & _BookCode & "' ")
            .Append(" AND ENTRYNO<>" & EntryNo & " ")
            .Append(" AND GODOWNCODE='" & UNITCODE & "' ")
            .Append(Factory_Filter_Condition)
            .Append(" ORDER BY PIECENO DESC ")
        End With
        Return _strQuery.ToString
    End Function


    Public Function Grey_Challan_Entry_Piece_Exist_Already_Qry(ByVal Tbl_Name As String, ByVal Pcs_No As String, ByVal Filter_String As String, ByVal Factory_Code_Filter_String As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" PIECENO ")
            .Append(" FROM " & Tbl_Name & " ")
            .Append(" WHERE 1=1 AND PIECENO='" & Pcs_No & "' AND ")
            .Append(Filter_String)
            .Append(Factory_Code_Filter_String)
            .Append(" ORDER BY PIECENO DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Grey_Challan_Entry_Grey_Stock_At_Factory_Qry(ByVal Book_Row_Filter_String As String, ByVal Filter_Condition As String, ByVal DsgShdFrom As String, ByVal _StockShowBaleNoWise As String) As String

        If _StockShowBaleNoWise = "YES" Then

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark ")
                .Append(" ,z.Quality ")
                .Append(" ,z.Selvedge ")
                .Append(" ,z.BaleNo  ")
                .Append(" ,COUNT(Z.[Piece No]) AS NoOfPcs ")
                .Append(" ,sum(z.Mtrs) as Mtrs ")
                .Append(" ,sum(z.Weight) as Weight ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" space(1) as [Flag], ")
                .Append(" a.pieceno AS [Piece No], ")
                .Append(" a.gmtr AS Mtrs,  ")
                .Append(" a.weight AS Weight, ")
                .Append(" a.pcavgwt AS [Avg-Wt], ")
                .Append(" A.pick AS Pick, ")
                .Append(" b.loomno AS [Lm-No], ")
                .Append(" C.Design_Name AS [Dsg-No], ")
                .Append(" a.beamno AS [Beam No], ")
                .Append(" D.SHADE AS [Shade], ")
                .Append(" a.Grey_Rcpt_Pcs_ID, ")
                .Append(" a.pieceno as pcs_no, ")
                .Append(" a.gmtr as g_mtr, ")
                .Append(" a.weight as g_weight, ")
                .Append(" a.fabric_itemcode, ")
                .Append(" a.selvcode, ")
                .Append(" a.beamno, ")
                .Append(" F.ITENNAME as Quality, ")
                .Append(" G.SELVEDGE_NAME as Selvedge, ")
                If DsgShdFrom = "FOLDING" Then
                    .Append(" A.FABRIC_DESIGNCODE, ")
                    .Append(" A.FABRIC_SHADECODE, ")
                Else
                    .Append(" E.FABRIC_DESIGNCODE, ")
                    .Append(" E.FABRIC_SHADECODE, ")
                End If
                .Append(" A.LOOMCODE,  ")
                .Append(" F.WTPERMTR AS avg_weight, ")
                .Append(" F.WTVERIANCE AS  avg_weight_variance, ")
                .Append(" E.YARN_WEST_PER, ")
                .Append(" A.PROCESS_REMARK as [Mending Remark] ")
                .Append(" ,A.Sales_Book_Vno AS BaleNo ")
                .Append(" ,A.Sales_Entry_No AS Fold ")
                .Append(" ,A.FOLDING_REMARK ")
                .Append(" ,isnull(A.Shift_A_Gmtr,0) as GreyRate ")
                .Append(" ,isnull(A.OP2,'')  as OfferNo ")
                .Append(" FROM trngreyrcpt AS a, mstloomno AS b, Mst_Fabric_Design AS c,  ")
                .Append(" Mst_Fabric_Shade AS d, trnbeamheader AS e,mstfabricitem AS F,Mst_selvedge AS G ")
                .Append(" WHERE 1=1 and a.loomcode=b.loomnocode And a.beamno=e.beamno ")
                .Append(" AND A.FABRIC_ITEMCODE=F.ID AND A.SELVCODE=G.ID ")
                .Append(" AND SUBSTRING(A.BOOKTRTYPE,1,2)='BM' ")
                If DsgShdFrom = "FOLDING" Then
                    .Append(" And A.fabric_designCode=C.Design_code And A.fabric_shadeCode=d.ID ")
                Else
                    .Append(" And e.fabric_designCode=C.Design_code And e.fabric_shadeCode=d.ID ")
                End If
                .Append(Book_Row_Filter_String)
                .Append(Filter_Condition)

                .Append(" UNION ALL ")

                .Append(" SELECT ")
                .Append(" space(1) as [Flag], ")
                .Append(" a.pieceno AS [Piece No], ")
                .Append(" a.gmtr AS Mtrs,  ")
                .Append(" a.weight AS Weight, ")
                .Append(" a.pcavgwt AS [Avg-Wt], ")
                .Append(" A.pick AS Pick,  ")
                .Append(" 0 AS [Lm-No], ")
                .Append(" C.Design_Name AS [Dsg-No], ")
                .Append(" a.beamno AS [Beam No], ")
                .Append(" D.SHADE AS [Shade], ")
                .Append(" a.Grey_Rcpt_Pcs_ID, ")
                .Append(" a.pieceno as pcs_no, ")
                .Append(" a.gmtr as g_mtr, ")
                .Append(" a.weight as g_weight, ")
                .Append(" a.fabric_itemcode, ")
                .Append(" a.selvcode, ")
                .Append(" a.beamno, ")
                .Append(" F.ITENNAME as Quality, ")
                .Append(" G.SELVEDGE_NAME as Selvedge, ")
                .Append(" A.FABRIC_DESIGNCODE, ")
                .Append(" A.FABRIC_SHADECODE, ")
                .Append(" '0000-000000001' AS LOOMCODE, ")
                .Append(" F.WTPERMTR AS avg_weight, ")
                .Append(" F.WTVERIANCE AS  avg_weight_variance, ")
                .Append(" (0) AS YARN_WEST_PER, ")
                .Append(" A.PROCESS_REMARK AS [Mending Remark] ")
                .Append(" ,A.Sales_Book_Vno AS BaleNo ")
                .Append(" ,A.Sales_Entry_No AS Fold ")
                .Append(" ,A.FOLDING_REMARK ")
                .Append(" ,isnull(A.Shift_A_Gmtr,0) as GreyRate ")
                .Append(" ,isnull(A.OP2,'')  as OfferNo ")
                .Append(" FROM trngreyrcpt AS a,Mst_Fabric_Design AS c,Mst_Fabric_Shade AS d, ")
                .Append(" mstfabricitem AS F,Mst_selvedge AS G ")
                .Append(" WHERE 1=1 And a.fabric_designCode=C.Design_code ")
                .Append(" AND A.FABRIC_ITEMCODE=F.ID AND A.SELVCODE=G.ID ")
                .Append(" And a.fabric_shadeCode=d.Id AND SUBSTRING(A.BOOKTRTYPE,1,2)<>'BM' ")
                .Append(Book_Row_Filter_String)
                .Append(Filter_Condition)
                .Append(" )  AS Z ")

                .Append(" LEFT JOIN TRNGREYDESP X ON X.Grey_Rcpt_Pcs_ID=Z.Grey_Rcpt_Pcs_ID ")
                .Append(" WHERE X.Grey_Rcpt_Pcs_ID IS NULL ")
                .Append("  GROUP BY ")
                .Append(" z.Quality ")
                .Append(" ,z.Selvedge ")
                .Append(" ,z.BaleNo ")
                .Append("  ORDER BY Z.BaleNo  ")
            End With

        Else
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT Z.* ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                '.Append(" space(1) as [Flag], ")
                .Append(" 'False' as TickMark, ")
                .Append(" a.pieceno AS [Piece No], ")
                .Append(" a.gmtr AS Mtrs,  ")
                .Append(" a.weight AS Weight, ")
                .Append(" a.pcavgwt AS [Avg-Wt], ")
                .Append(" A.pick AS Pick, ")
                .Append(" b.loomno AS [Lm-No], ")
                .Append(" C.Design_Name AS [Dsg-No], ")
                .Append(" a.beamno AS [Beam No], ")
                .Append(" D.SHADE AS [Shade], ")
                .Append(" a.Grey_Rcpt_Pcs_ID, ")
                .Append(" a.pieceno as pcs_no, ")
                .Append(" a.gmtr as g_mtr, ")
                .Append(" a.weight as g_weight, ")
                .Append(" a.fabric_itemcode, ")
                .Append(" a.selvcode, ")
                .Append(" a.beamno, ")
                .Append(" F.ITENNAME as Quality, ")
                .Append(" G.SELVEDGE_NAME as Selvedge, ")
                If DsgShdFrom = "FOLDING" Then
                    .Append(" A.FABRIC_DESIGNCODE, ")
                    .Append(" A.FABRIC_SHADECODE, ")
                Else
                    .Append(" E.FABRIC_DESIGNCODE, ")
                    .Append(" E.FABRIC_SHADECODE, ")
                End If
                .Append(" A.LOOMCODE,  ")
                .Append(" F.WTPERMTR AS avg_weight, ")
                .Append(" F.WTVERIANCE AS  avg_weight_variance, ")
                .Append(" E.YARN_WEST_PER, ")
                .Append(" A.PROCESS_REMARK + ' ' + A.FOLDING_REMARK as [Mending Remark] ")
                .Append(" ,'' AS BEAMOFFERNO ")
                .Append(" ,A.Sales_Book_Vno AS BaleNo ")
                .Append(" ,A.Sales_Entry_No AS Fold ")
                .Append(" ,A.FOLDING_REMARK ")
                .Append(" ,isnull(A.Shift_A_Gmtr,0) as GreyRate ")
                .Append(" ,isnull(A.OP2,'')  as OfferNo ")

                .Append(" FROM trngreyrcpt AS a")
                .Append(" LEFT JOIN  mstloomno AS b ON a.loomcode=b.loomnocode")
                .Append(" LEFT JOIN trnbeamheader AS e ON a.beamno=e.beamno")
                .Append(" LEFT JOIN mstfabricitem AS F ON A.FABRIC_ITEMCODE=F.ID")
                .Append(" LEFT JOIN Mst_selvedge AS G  ON A.SELVCODE=G.ID ")
                If DsgShdFrom = "FOLDING" Then
                    .Append(" LEFT JOIN  Mst_Fabric_Shade AS d ON A.fabric_shadeCode=d.ID")
                    .Append(" LEFT JOIN  Mst_Fabric_Design AS c ON A.fabric_designCode=C.Design_code   ")
                Else
                    .Append(" LEFT JOIN  Mst_Fabric_Shade AS d ON e.fabric_shadeCode=d.ID ")
                    .Append(" LEFT JOIN  Mst_Fabric_Design AS c ON e.fabric_designCode=C.Design_code ")
                End If

                .Append(" WHERE 1=1   ")
                .Append(" AND SUBSTRING(A.BOOKTRTYPE,1,2)='BM' ")
                .Append(Book_Row_Filter_String)
                .Append(Filter_Condition)
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                '.Append(" space(1) as [Flag], ")
                .Append(" 'False' as TickMark, ")
                .Append(" a.pieceno AS [Piece No], ")
                .Append(" a.gmtr AS Mtrs,  ")
                .Append(" a.weight AS Weight, ")
                .Append(" a.pcavgwt AS [Avg-Wt], ")
                .Append(" A.pick AS Pick,  ")
                .Append(" 0 AS [Lm-No], ")
                .Append(" C.Design_Name AS [Dsg-No], ")
                .Append(" a.beamno AS [Beam No], ")
                .Append(" D.SHADE AS [Shade], ")
                .Append(" a.Grey_Rcpt_Pcs_ID, ")
                .Append(" a.pieceno as pcs_no, ")
                .Append(" a.gmtr as g_mtr, ")
                .Append(" a.weight as g_weight, ")
                .Append(" a.fabric_itemcode, ")
                .Append(" a.selvcode, ")
                .Append(" a.beamno, ")
                .Append(" F.ITENNAME as Quality, ")
                .Append(" G.SELVEDGE_NAME as Selvedge, ")
                .Append(" A.FABRIC_DESIGNCODE, ")
                .Append(" A.FABRIC_SHADECODE, ")
                .Append(" '0000-000000001' AS LOOMCODE, ")
                .Append(" F.WTPERMTR AS avg_weight, ")
                .Append(" F.WTVERIANCE AS  avg_weight_variance, ")
                .Append(" (0) AS YARN_WEST_PER, ")
                .Append(" A.PROCESS_REMARK + ', ' + A.FOLDING_REMARK as [Mending Remark] ")
                .Append(" ,'' AS BEAMOFFERNO ")
                .Append(" ,A.Sales_Book_Vno AS BaleNo ")
                .Append(" ,A.Sales_Entry_No AS Fold ")
                .Append(" ,A.FOLDING_REMARK ")
                .Append(" ,isnull(A.Shift_A_Gmtr,0) as GreyRate ")
                .Append(" ,isnull(A.OP2,'')  as OfferNo ")
                .Append(" FROM trngreyrcpt AS a ")
                .Append(" LEFT JOIN Mst_Fabric_Design AS c ON a.fabric_designCode=C.Design_code")
                .Append(" Left JOIN Mst_Fabric_Shade AS d ON a.fabric_shadeCode=d.Id  ")
                .Append(" LEFT JOIN  mstfabricitem AS F ON A.FABRIC_ITEMCODE=F.ID ")
                .Append(" LEFT JOIN Mst_selvedge AS G ON A.SELVCODE=G.ID ")
                .Append(" WHERE 1=1 ")
                .Append(" And  SUBSTRING(A.BOOKTRTYPE,1,2)<>'BM' ")
                .Append(Book_Row_Filter_String)
                .Append(Filter_Condition)
                .Append(" )  AS Z ")
                .Append(" LEFT JOIN TRNGREYDESP X ON X.Grey_Rcpt_Pcs_ID=Z.Grey_Rcpt_Pcs_ID ")
                .Append(" WHERE X.Grey_Rcpt_Pcs_ID IS NULL ")
                .Append(" ORDER BY (Z.BEAMNO),Z.[Piece No] ")
            End With
        End If
        Return _strQuery.ToString
    End Function


    Public Function EntryData_General_Invoice_Entry_Due_Challan_Selection_Qry(ByVal _BookCode As String, ByVal _BookNature As String, ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" J.CUTNAME AS CUTNAME, ")
            .Append(" C.ITEMNAME, ")
            .Append(" A.PCS AS PCS, ")
            .Append(" A.MTR_WEIGHT AS MTR_WEIGHT, ")
            .Append(" (0) AS WEIGHT, ")
            .Append(" I.AC_NAME AS ACOFNAME, ")
            .Append(" K.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" '' AS TRANSPORTCODE, ")
            .Append(" I.ID AS ACOFCODE, ")
            .Append(" J.ID AS CUTCODE, ")
            .Append(" A.ITEMCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.NET_RATE AS RATE, ")
            .Append(" L.GROUPCODE AS ITEMGROUPCODE, ")
            .Append(" L.GROUPNAME AS PROCESSNAME,C.VATTAXPER AS TAXPER, ")
            .Append(" A.GROSS_RATE,A.RATE_DIS_PER,A.ROWREMARK,A.ENTRYNO,C.HSNCODE, ")
            .Append(" isnull(A.OP12,0) AS Gsm,") 'GSM
            .Append(" isnull(A.OP13,0) as Bundle,") 'Bundle
            .Append(" isnull(A.OP14,0) as PcsBundle,") 'Pcs Bundle
            .Append(" isnull(A.OP15,0) as Sheets,") 'Sheets
            .Append(" isnull(A.OP16,0) as Total") 'Total

            .Append(" FROM TRNCHALLAN AS A ")
            .Append(" LEFT JOIN MSTSTOREITEM AS C  ON  A.ITEMCODE=C.ITEMCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS H  ON  F.AGENTCODE=H.ACCOUNTCODE")
            .Append(" LEFT JOIN MstCutMaster J  ON  C.CUTCODE=J.ID ")
            .Append(" LEFT JOIN Mst_Acof_Supply I  ON  A.ACOFCODE=I.ID  ")
            .Append(" LEFT JOIN MSTTRANSPORT K  ON  A.TRANSPORTCODE=K.ID ")
            .Append(" LEFT JOIN  MSTSTOREITEMGROUP L  ON  C.ITEMGROUPCODE=L.GROUPCODE ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
            .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN ")
            .Append(" (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1  AND CHALLANBOOKVNO IS NOT NULL ) ")
            .Append(" ORDER BY A.BOOKVNO,A.SRNO ")
        End With
        Dim Str_Qry As String = strQuery.ToString
        Return strQuery.ToString
    End Function

    Public Function EntryData_ReadyMadeProducation_Qry(ByVal _BookCode As String, ByVal _BookNature As String, ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal _ShowAllParty As String, ByVal _ChallanBookcode As String) As String

        If _ChallanBookcode = "('0001-000000153')" Then

            strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" CAST(A.ENTRYNO as varchar(10))  + '/'+ A.challanno AS CHALLANNO, ")
                .Append(" FORMAT(A.challandate,'dd/MM/yyyy') AS F_CHALLANDATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" SUM( A.Mtr_Weight) AS [Prod Qty], ")
                .Append(" (0.0) AS [Rec Qty], ")
                .Append(" (0.0) AS [Balance], ")
                .Append(" M.SizeName AS Size, ")
                .Append(" N.ColorName AS Color, ")
                .Append(" A.GROSS_RATE AS RATE, ")
                .Append(" A.HEADERREMARK AS [Remark], ")
                .Append(" A.DESCR as [Descr], ")
                .Append(" A.ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" C.VATTAXPER AS TAXPER, ")
                .Append(" A.ROWREMARK, ")
                .Append(" A.ENTRYNO, ")
                .Append(" C.HSNCODE ")
                .Append(" ,A.REPAIR_GROUP_BY_ID AS SIZECODE")
                .Append(" ,A.ITEMGROUPCODE ")
                .Append(" ,Q.GROUPNAME ")
                .Append(" ,A.Loan_Paid_ID AS COLORCODE ")
                .Append(" ,P.subItemName  AS  [Sub Item] ")
                .Append(" ,A.Repairing_Issue_ID ") ' SUBITEMCODE
                .Append(" ,R.cutname  ")
                .Append(" ,A.CUTCODE ") ' CUTCODE
                .Append(" ,A.RATE_DIS_PER AS  Discount ")
                .Append(" ,A.TAX_PER ")
                .Append(" ,A.NET_RATE ")
                .Append(" ,A.AMOUNT ")
                .Append(" ,A.Consume_Amt ")
                .Append(" FROM TrnChallan AS A,MSTSTOREITEM AS C,MstMasterAccount AS F, ")
                .Append(" MSTCITY AS G,MstMasterAccount AS H ")
                .Append(" ,MstSize M ")
                .Append(" ,MstColor N ")
                .Append(" ,MSTSTOREITEMGROUP Q ")
                .Append(" ,MstStoreSubItem P ")
                .Append(" ,MstCutMaster R ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
                .Append(" AND F.CITYCODE=G.CITYCODE ")
                .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" AND A.ITEMCODE=C.ITEMCODE ")
                .Append(" AND A.REPAIR_GROUP_BY_ID=M.SizeCode ")
                .Append(" AND A.Loan_Paid_ID=N.ColorCode ")
                .Append(" AND A.ITEMGROUPCODE=Q.GROUPCODE ")
                .Append(" AND A.CUTCODE=R.ID  ")
                .Append(" AND A.Repairing_Issue_ID=P.subItemCode ")
                .Append(" AND A.challandate<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.BOOKVNO NOT IN ")
                .Append(" (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1  AND CHALLANBOOKVNO IS NOT NULL ) ")
                .Append(" GROUP BY ")
                .Append(" A.challanno , ")
                .Append(" A.challandate, ")
                .Append(" C.ITEMNAME, ")
                .Append(" M.SizeName, ")
                .Append(" N.ColorName, ")
                .Append(" A.RATE, ")
                .Append(" A.HEADERREMARK, ")
                .Append(" A.DESCR, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME, ")
                .Append(" H.ACCOUNTCODE, ")
                .Append(" H.ACCOUNTNAME, ")
                .Append(" C.VATTAXPER, ")
                .Append(" A.ROWREMARK,A.ENTRYNO,C.HSNCODE ")
                .Append(" ,A.REPAIR_GROUP_BY_ID ")
                .Append(" ,P.subItemName ")
                .Append(" ,A.CUTCODE ")
                .Append(" ,A.Loan_Paid_ID ")
                .Append(" ,A.ITEMGROUPCODE ")
                .Append(" ,R.cutname  ")
                .Append(" ,A.Repairing_Issue_ID ")
                .Append(" ,Q.GROUPNAME, ")
                .Append(" A.GROSS_RATE, ")
                .Append(" A.RATE_DIS_PER , ")
                .Append(" A.TAX_PER, ")
                .Append(" A.NET_RATE, ")
                .Append(" A.AMOUNT ")
                .Append(" ,A.Consume_Amt ")
                .Append(" ORDER BY A.challanno,A.challandate ")
            End With

        ElseIf _ChallanBookcode = "('0001-000000811')" Or _ChallanBookcode = "('0001-000000840')" Or _ChallanBookcode = "('0001-000000841')" Or _ChallanBookcode = "('0001-000000835')" Or _ChallanBookcode = "('0001-000000833')" Then

            strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" CAST(A.ENTRYNO as varchar(10))  + '/'+ A.PACK_SLIP_NO AS CHALLANNO, ")
                .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" SUM( A.PCS) AS [Prod Qty], ")
                .Append(" (0.0) AS [Rec Qty], ")
                .Append(" (0.0) AS [Balance], ")
                .Append(" M.SizeName AS Size, ")
                .Append(" N.ColorName AS Color, ")
                .Append(" A.RATE AS RATE, ")
                .Append(" A.HEADERREMARK AS [Remark], ")
                .Append(" A.DESCR as [Descr], ")
                .Append(" A.ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" A.DESPATCHCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" A.RDVALUE AS TAXPER, ")
                .Append(" A.ROWREMARK, ")
                .Append(" A.ENTRYNO, ")
                .Append(" C.HSNCODE ")
                .Append(" ,A.DESIGNCODE ")
                .Append(" ,A.shadecode ")
                .Append(" ,'' AS [Shade] ")
                .Append(" ,A.CUTCODE1 AS COLORCODE ")
                .Append(" ,P.subItemName  AS  [Sub Item] ")
                .Append(" ,A.CUTCODE ")
                .Append(" ,Q.CUTNAME ")
                .Append(" ,R.AC_NAME ")
                .Append(" ,A.ACOFCODE ")
                .Append(" ,S.TRANSPORTNAME ")
                .Append(" ,A.TRANSPORTCODE ")
                .Append(" ,0 AS RDON ")
                .Append(" ,ISNULL(A.BarCode_LumpNo,0) AS BarCode_LumpNo ")
                .Append(" ,A.SAMPLE_IN_CASE AS TYPECODE ")
                .Append(" ,A.OFFERBOOKVNO ")
                .Append(" ,A.CDVALUE ") ' CD%
                .Append(" ,A.PARENT_PIECE_ID ") 'MRP
                .Append(" ,A.BARCODE_TAGNO") 'MD%
                .Append(" ,A.OFFERNO ")

                .Append(" FROM TrnPackingSlip AS A ")
                .Append(" LEFT JOIN MSTSTOREITEM AS C  ON A.ITEMCODE=C.ITEMCODE")
                .Append(" LEFT JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTCITY AS G  ON A.DESPATCHCODE=G.CITYCODE")
                .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MstSize M  ON A.DESIGNCODE=M.SizeCode")
                .Append(" LEFT JOIN MstColor N ON A.CUTCODE1=N.ColorCode  ")
                .Append(" LEFT JOIN MstStoreSubItem P  ON A.SHADECODE=P.subItemCode ")
                .Append(" LEFT JOIN MstCutMaster Q  ON A.CUTCODE=Q.ID ")
                .Append(" LEFT JOIN Mst_Acof_Supply R  ON  A.ACOFCODE=R.ID ")
                .Append(" LEFT JOIN MstTransport S ON A.TRANSPORTCODE=S.ID  ")
                .Append(" WHERE 1=1 ")
                If _ShowAllParty <> "YES" Then
                    .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
                End If

                .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)

                .Append(" AND A.BOOKVNO NOT IN ")
                .Append(" (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1  AND CHALLANBOOKVNO IS NOT NULL ) ")
                .Append(" GROUP BY ")
                .Append(" A.PACK_SLIP_NO , ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" M.SizeName, ")
                .Append(" N.ColorName, ")
                .Append(" A.RATE, ")
                .Append(" A.HEADERREMARK, ")
                .Append(" A.DESCR, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" A.DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME, ")
                .Append(" H.ACCOUNTCODE, ")
                .Append(" H.ACCOUNTNAME, ")
                .Append(" C.VATTAXPER, ")
                .Append(" A.ROWREMARK,A.ENTRYNO,C.HSNCODE ")
                .Append(" ,A.DESIGNCODE ")
                .Append(" ,A.shadecode ")
                .Append(" ,A.RDVALUE")
                .Append(" ,A.CUTCODE1")
                .Append(" ,P.subItemName ")
                .Append(" ,Q.CUTNAME ")
                .Append(" ,R.AC_NAME ")
                .Append(" ,A.ACOFCODE ")
                .Append(" ,S.TRANSPORTNAME ")
                .Append(" ,A.TRANSPORTCODE ")
                .Append(" ,A.CUTCODE ") ' subitemcode
                .Append(" ,A.BarCode_LumpNo ")
                .Append(" ,A.SAMPLE_IN_CASE ")
                .Append(" ,A.OFFERBOOKVNO ")
                .Append(" ,A.CDVALUE ")
                .Append(" ,A.OFFERNO ")
                .Append(" ,A.PARENT_PIECE_ID ") 'MRP
                .Append(" ,A.BARCODE_TAGNO") 'MD%
                .Append(" ORDER BY A.PACK_SLIP_NO,A.PACK_SLIP_DATE ")
            End With

        ElseIf _ChallanBookcode = "('0001-000000786')" Then
            strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" CAST(A.ENTRYNO as varchar(10))  + '/'+ A.OFFERNO AS CHALLANNO, ")
                .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" SUM(A.PCS) AS [Prod Qty], ")
                .Append(" (0.0) AS [Rec Qty], ")
                .Append(" (0.0) AS [Balance], ")
                .Append(" M.SizeName AS Size, ")
                .Append(" N.ColorName AS Color, ")
                .Append(" A.RATE AS RATE, ")
                .Append(" A.HEADERREMARK AS [Remark], ")
                .Append(" A.DESCR as [Descr], ")
                .Append(" A.ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" C.VATTAXPER AS TAXPER, ")
                .Append(" A.ROWREMARK, ")
                .Append(" A.ENTRYNO, ")
                .Append(" C.HSNCODE ")
                .Append(" ,A.DESIGNCODE ")
                .Append(" ,A.shadecode ")
                .Append(" ,O.SHADE AS [Shade] ")
                .Append(" ,A.CUTCODE1 AS COLORCODE ")
                .Append(" ,P.subItemName  AS  [Sub Item] ")
                .Append(" ,A.CUTCODE ") ' subitemcode
                .Append(" ,S.TRANSPORTNAME ")
                .Append(" ,A.TRANSPORTCODE ")
                .Append(" ,A.RDON ") ' baleno
                .Append(" ,ISNULL(A.BarCode_LumpNo,0) AS BarCode_LumpNo ")
                .Append(" ,A.SAMPLE_IN_CASE AS TYPECODE ")
                .Append(" ,A.OFFERBOOKVNO ")
                .Append(" FROM TrnPackingSlip AS A ")
                .Append(" LEFT JOIN MSTSTOREITEM AS C ON A.ITEMCODE=C.ITEMCODE ")
                .Append(" Left JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS H ON  F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstSize M ON A.DESIGNCODE=M.SizeCode ")
                .Append(" LEFT JOIN MstColor N ON  A.CUTCODE1=N.ColorCode ")
                .Append(" LEFT JOIN Mst_Fabric_Shade O ON  A.SHADECODE=O.ID ")
                .Append(" LEFT JOIN MstStoreSubItem P ON A.CUTCODE=P.subItemCode  ")
                .Append(" LEFT JOIN MstTransport S ON A.TRANSPORTCODE=S.ID ")

                .Append(" WHERE 1=1 ")
                .Append(" AND (C.OP5 <> 'ACCESSORIES'  OR C.OP5 IS NULL)")
                If _ShowAllParty <> "YES" Then
                    .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
                End If
                .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.BOOKVNO NOT IN ")
                .Append(" (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1  AND CHALLANBOOKVNO IS NOT NULL ) ")
                .Append(" GROUP BY ")
                .Append(" A.OFFERNO , ")
                .Append(" A.PACK_SLIP_NO , ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" M.SizeName, ")
                .Append(" N.ColorName, ")
                .Append(" A.RATE, ")
                .Append(" A.HEADERREMARK, ")
                .Append(" A.DESCR, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME, ")
                .Append(" H.ACCOUNTCODE, ")
                .Append(" H.ACCOUNTNAME, ")
                .Append(" C.VATTAXPER, ")
                .Append(" A.ROWREMARK,A.ENTRYNO,C.HSNCODE ")
                .Append(" ,A.DESIGNCODE ")
                .Append(" ,A.shadecode ")
                .Append(" ,O.SHADE ,A.CUTCODE1")
                .Append(" ,P.subItemName ")
                .Append(" ,A.CUTCODE ") ' subitemcode
                .Append(" ,S.TRANSPORTNAME ")
                .Append(" ,A.TRANSPORTCODE ")
                .Append(" ,A.RDON ")
                .Append(" ,A.BarCode_LumpNo ")
                .Append(" ,A.SAMPLE_IN_CASE ")
                .Append(" ,A.OFFERBOOKVNO ")
                .Append(" ORDER BY A.ENTRYNO,A.PACK_SLIP_DATE ")
            End With


        Else
            strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" SPACE(1) AS MARK, ")
                .Append(" CAST(A.ENTRYNO as varchar(10))  + '/'+ A.PACK_SLIP_NO AS CHALLANNO, ")
                .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" SUM( A.PCS) AS [Prod Qty], ")
                .Append(" (0.0) AS [Rec Qty], ")
                .Append(" (0.0) AS [Balance], ")
                .Append(" M.SizeName AS Size, ")
                .Append(" N.ColorName AS Color, ")
                .Append(" A.RATE AS RATE, ")
                .Append(" A.HEADERREMARK AS [Remark], ")
                .Append(" A.DESCR as [Descr], ")
                .Append(" A.ITEMCODE AS ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE AS DESPATCHCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME AS DESPATCH, ")
                .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
                .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
                .Append(" C.VATTAXPER AS TAXPER, ")
                .Append(" A.ROWREMARK, ")
                .Append(" A.ENTRYNO, ")
                .Append(" C.HSNCODE ")
                .Append(" ,A.DESIGNCODE ")
                .Append(" ,A.shadecode ")
                .Append(" ,O.SHADE AS [Shade] ")
                .Append(" ,A.CUTCODE1 AS COLORCODE ")
                .Append(" ,P.subItemName  AS  [Sub Item] ")
                .Append(" ,A.CUTCODE ") ' subitemcode
                .Append(" ,S.TRANSPORTNAME ")
                .Append(" ,A.TRANSPORTCODE ")
                .Append(" ,A.RDON ") ' baleno
                .Append(" ,ISNULL(A.BarCode_LumpNo,0) AS BarCode_LumpNo ")
                .Append(" ,A.SAMPLE_IN_CASE AS TYPECODE ")
                .Append(" ,A.OFFERBOOKVNO ")
                .Append(" FROM TrnPackingSlip AS A,MSTSTOREITEM AS C,MstMasterAccount AS F, ")
                .Append(" MSTCITY AS G,MstMasterAccount AS H ")
                .Append(" ,MstSize M ")
                .Append(" ,MstColor N ")
                .Append(" ,Mst_Fabric_Shade O ")
                .Append(" ,MstStoreSubItem P ")
                .Append(" ,MstTransport S ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
                .Append(" AND F.CITYCODE=G.CITYCODE ")
                .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
                .Append(" AND A.ITEMCODE=C.ITEMCODE ")
                .Append(" AND A.DESIGNCODE=M.SizeCode ")
                .Append(" AND A.CUTCODE1=N.ColorCode ")
                .Append(" AND A.SHADECODE=O.ID ")
                .Append(" AND A.CUTCODE=P.subItemCode ")
                .Append(" AND A.TRANSPORTCODE=S.ID ")

                .Append(" AND (C.OP5 <> 'ACCESSORIES'  OR C.OP5 IS NULL)")

                If _ShowAllParty <> "YES" Then
                    .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
                End If

                .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
                .Append(Str_In_Challan_Book)
                .Append(" AND A.BOOKVNO NOT IN ")
                .Append(" (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1  AND CHALLANBOOKVNO IS NOT NULL ) ")
                .Append(" GROUP BY ")
                .Append(" A.PACK_SLIP_NO , ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" C.ITEMNAME, ")
                .Append(" M.SizeName, ")
                .Append(" N.ColorName, ")
                .Append(" A.RATE, ")
                .Append(" A.HEADERREMARK, ")
                .Append(" A.DESCR, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" F.CITYCODE, ")
                .Append(" F.ACCOUNTNAME, ")
                .Append(" G.CITYNAME, ")
                .Append(" H.ACCOUNTCODE, ")
                .Append(" H.ACCOUNTNAME, ")
                .Append(" C.VATTAXPER, ")
                .Append(" A.ROWREMARK,A.ENTRYNO,C.HSNCODE ")
                .Append(" ,A.DESIGNCODE ")
                .Append(" ,A.shadecode ")
                .Append(" ,O.SHADE ,A.CUTCODE1")
                .Append(" ,P.subItemName ")
                .Append(" ,A.CUTCODE ") ' subitemcode
                .Append(" ,S.TRANSPORTNAME ")
                .Append(" ,A.TRANSPORTCODE ")
                .Append(" ,A.RDON ")
                .Append(" ,A.BarCode_LumpNo ")
                .Append(" ,A.SAMPLE_IN_CASE ")
                .Append(" ,A.OFFERBOOKVNO ")
                .Append(" ORDER BY A.ENTRYNO,A.PACK_SLIP_DATE ")
            End With
        End If



        Dim Str_Qry As String = strQuery.ToString
        Return strQuery.ToString
    End Function

    Public Function EntryData_RMCChallan_Qry(ByVal _BookCode As String, ByVal _BookNature As String, ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.ENTRYNO AS CHALLANNO, ")
            .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" C.ITEMNAME, ")
            .Append(" A.RDVALUE AS [Qty], ")
            .Append(" A.CDVALUE AS RATE, ")
            .Append(" A.HEADERREMARK AS [Remark], ")
            .Append(" A.DESCR, ")
            .Append(" A.ITEMCODE1 AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" C.VATTAXPER AS TAXPER, ")
            .Append(" A.ENTRYNO ")
            .Append(" ,C.HSNCODE ")

            .Append(" FROM TrnPackingSlip AS A,MSTSTOREITEM AS C,MstMasterAccount AS F, ")
            .Append(" MSTCITY AS G,MstMasterAccount AS H ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE1=C.ITEMCODE ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
            .Append(" AND A.PACK_SLIP_DATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN ")
            .Append(" (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1  AND CHALLANBOOKVNO IS NOT NULL ) ")

            .Append(" GROUP BY ")
            .Append(" A.PACK_SLIP_NO , ")
            .Append(" A.PACK_SLIP_DATE, ")
            .Append(" C.ITEMNAME, ")
            .Append(" A.CDVALUE, ")
            .Append(" A.HEADERREMARK, ")
            .Append(" A.DESCR, ")
            .Append(" A.ITEMCODE1, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" F.CITYCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME, ")
            .Append(" H.ACCOUNTCODE, ")
            .Append(" H.ACCOUNTNAME, ")
            .Append(" C.VATTAXPER, ")
            .Append(" A.RDVALUE, ")
            .Append(" A.ENTRYNO,C.HSNCODE ")
            .Append(" ORDER BY A.ENTRYNO,A.PACK_SLIP_DATE ")
        End With
        Dim Str_Qry As String = strQuery.ToString
        Return strQuery.ToString
    End Function
    Public Function EntryData_Producation_Qry(ByVal _BookCode As String, ByVal _BookNature As String, ByVal Str_In_Challan_Book As String, ByVal AccountCode As String, ByVal BillDate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" p.ITEnNAME as [Fabric Item], ")
            .Append(" C.ITEMNAME, ")
            .Append(" A.QTY AS [Prod Qty], ")
            .Append(" (0.0) AS [Rec Qty], ")
            .Append(" A.QTY  AS [Balance], ")
            .Append(" M.SizeName AS Size, ")
            .Append(" N.ColorName AS Color, ")
            .Append(" A.RATE AS RATE, ")
            .Append(" A.BATCHNO AS [Batch No], ")
            .Append(" A.DESCR, ")
            .Append(" A.PRODITEMCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" F.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" C.VATTAXPER AS TAXPER, ")
            .Append(" A.ROWREMARK, ")
            .Append(" A.ENTRYNO, ")
            .Append(" C.HSNCODE ")
            .Append(" ,A.SIZECODE ")
            .Append(" ,A.COLORCODE ")
            .Append(" ,O.SHADE AS SHADENAME ")
            .Append(" ,A.SHADECODE ")
            .Append(" ,A.BATCHNO ")
            .Append(" ,A.ITEMCODE as FABRIC_ITEMCODE ")
            .Append(" ,A.DESIGNCODE as FABRIC_DESIGNCODE ")
            .Append(" ,Q.subItemName  AS  SubItem ")
            .Append(" ,R.RemarkName  AS Type ")
            .Append(" ,Q.subItemCode ")
            .Append(" ,R.RemarkCode AS TypeCode ")

            .Append(" FROM TrnReadyMadeProducation AS A")
            .Append(" LEFT JOIN MSTSTOREITEM AS C ON A.PRODITEMCODE=C.ITEMCODE  ")
            .Append(" Left JOIN MstMasterAccount AS F ON A.ACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE ")
            .Append(" LEFT JOIN MstMasterAccount AS H ON F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstSize M ON A.SizeCode=M.SizeCode  ")
            .Append(" LEFT JOIN MstColor N ON  A.ColorCode=N.ColorCode ")
            .Append(" LEFT JOIN Mst_Fabric_Shade O ON A.SHADECODE=O.ID  ")
            .Append(" LEFT JOIN MstFabricItem P ON A.ITEMCODE=P.ID  ")
            .Append(" LEFT JOIN MstStoreSubItem Q  ON  A.MONOGRAM_TYPE = Q.subItemCode ")
            .Append(" LEFT JOIN MstRemark R  ON  A.LOTNO=R.RemarkCode ")

            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "' ")
            .Append(" AND A.CHALLAN_DATE<='" & BillDate & "' ")
            .Append(Str_In_Challan_Book)
            '.Append(" AND A.BOOKCODE ='0001-000000703' ")
            .Append(" AND (C.OP5 ='SALES' OR  C.OP5 IS NULL)")
            .Append(" ORDER BY A.BOOKVNO,A.SRNO ")
        End With
        Dim Str_Qry As String = strQuery.ToString
        Return strQuery.ToString
    End Function

    Public Function Get_Interest_Bill_To_Bill_Invoice_Rpt_QryONAC(Int_Per_Manual As String, Side_Days_Manual As String, Pymt_Date_By As String, Bill_Date_By As String, Date_Range1 As String, Filter_Condition As String, Filter_Condition_BookVno As String, Order_By As String, Filter_Condition_BookVno_Opening As String, GSTRate As Double, IntInfoByMaster As String, _PaymentDate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" " & GSTRate & " AS GST, ")
            .Append(" Z.INT_PER, ")
            .Append(" Z.SIDEDAYS, ")
            .Append(" Z.dayscalcby, ")
            .Append(" Z.METHOD, ")
            .Append(" Z.PARTYNAME, ")
            .Append(" Z.PARTYSIDEDAYS,Z.INTERESTPER, ")
            .Append(" Z.AGENTNAME, ")
            .Append(" Z.BOOKCODE, Z.BOOKVNO, Z.BILLNO, Z.BILLDATE, ")
            .Append(" Z.F_BILLDATE,Z.F_BILLDATE AS F_RCPTDATE, ")
            .Append(" Z.BILL_SIDE_DAYS, Z.ACCOUNTCODE,Z.AGENTCODE, ")
            .Append(" Z.MTR_WEIGHT,Z.ADJAMT, ")
            .Append(" Z.DEBITAMT,Z.CREDITAMT, ")
            .Append(" Z.RD, Z.CD, Z.GR, Z.OTHER_DEDUCT, ")
            .Append(" Z.RCPT_DATE, Z.RCPTAMOUNT, ")
            .Append(" Z.LATEDAYS,Z.INTAMOUNT, ")
            .Append(" Z.BILL_BALANCE, Z.LATEDAYS_OF_BALANCE, ")
            .Append(" INT_OF_BILL_BALANCE, ALREADY_RCPT_INTEREST, ")
            .Append(" Z.INTVNODATE,Z.F_INTCHQDDDATE,Z.F_INTADVISEDATE,Z.INTCHQDDDATE, ")
            .Append(" NET_INTEREST ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(Int_Per_Manual)
            .Append(Side_Days_Manual)
            .Append(" '" & Pymt_Date_By & "' as dayscalcby, ")
            .Append(" '" & Bill_Date_By & "' as METHOD, ")
            .Append(" B.ACCOUNTNAME + ',' + C.CITYNAME AS PARTYNAME, ")
            .Append(" B.CRDAYS  AS PARTYSIDEDAYS,B.INTREST AS INTERESTPER, ")
            .Append(" F.ACCOUNTNAME + ',' + G.CITYNAME AS AGENTNAME, ")
            .Append(" A.BOOKCODE, A.BOOKVNO, A.BILLNO, A.BILLDATE, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            .Append(" 0  AS BILL_SIDE_DAYS, A.ACCOUNTCODE,B.AGENTCODE, ")
            .Append(" 0 AS MTR_WEIGHT,A.ADJAMT, ")
            .Append(" A.DEBITAMT,A.CREDITAMT, ")
            .Append(" (0) AS RD, (0) AS CD, (0) AS GR, (0) AS OTHER_DEDUCT, ")
            .Append(" SPACE(10) AS RCPT_DATE, (0) AS RCPTAMOUNT, ")
            .Append(" (0) AS LATEDAYS, (0) AS INTAMOUNT, ")
            .Append(" (0) AS BILL_BALANCE, (0) AS LATEDAYS_OF_BALANCE, ")
            .Append(" (0) AS INT_OF_BILL_BALANCE, (0) AS ALREADY_RCPT_INTEREST, ")
            .Append(" (0) AS NET_INTEREST,A.INTCHQDDDATE, ")
            .Append(" A.INTCHQDDDATE AS INTVNODATE,FORMAT(A.INTCHQDDDATE,'dd/MM/yyyy') AS F_INTCHQDDDATE,FORMAT(A.INTCHQDDDATE,'dd/MM/yyyy') AS F_INTADVISEDATE ")
            .Append(" FROM TRNOUTSTANDING A,MstMasterAccount B,MSTCITY C, ")
            .Append(" MstMasterAccount F,MSTCITY G ")
            .Append(" WHERE 1=1 AND A.SUNCODE='0001-000000041' ")
            .Append(" AND A.ACCOUNTCODE = B.ACCOUNTCODE ")
            .Append(" AND B.CITYCODE=C.CITYCODE ")
            .Append(" AND B.AGENTCODE=F.ACCOUNTCODE AND F.CITYCODE=G.CITYCODE ")
            .Append(Filter_Condition)
            .Append(Date_Range1)
            .Append(_PaymentDate)
            .Append(" ) ")
            .Append(" AS Z ")
        End With
        Dim Str_Qry As String = strQuery.ToString
        Return strQuery.ToString

    End Function
    Public Function Get_Interest_Bill_To_Bill_Invoice_Rpt_Qry(Int_Per_Manual As String, Side_Days_Manual As String, Pymt_Date_By As String, Bill_Date_By As String, Date_Range1 As String, Filter_Condition As String, Filter_Condition_BookVno As String, Order_By As String, Filter_Condition_BookVno_Opening As String, GSTRate As Double, IntInfoByMaster As String, _TdsPer As Double, _PaymentDate As String) As String


        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" '" & COMPANY_NAME & "'   AS COMP_NAME, ")
            .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
            .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
            .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
            .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
            .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
            .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
            .Append(" '" & Comp_email & "'   AS COMP_EMAIL, ")
            .Append(" " & (GSTRate) & "  AS GST, ")
            .Append(" " & (_TdsPer) & "  AS TDS, ")
            .Append(" Z.* FROM ")
            .Append(" ( ")
            .Append(" SELECT ")

            '"MANUAL,,"
            Dim flag As Boolean
            'Dim flag As Boolean = Operators.CompareString(IntInfoByMaster, "YES", False) = 0
            If IntInfoByMaster = "MASTER" Then
                .Append(" B.INTREST AS INT_PER, ")
                .Append(" B.CRDAYS AS SIDEDAYS, ")
            ElseIf IntInfoByMaster = "INVOICE" Then
                .Append(Int_Per_Manual)
                .Append(" A.SIDEDAYS AS SIDEDAYS, ")
            Else
                .Append(Int_Per_Manual)
                .Append(Side_Days_Manual)
            End If



            .Append(" '" & Pymt_Date_By & "' as dayscalcby, ")
            .Append(" '" & Bill_Date_By & "' as METHOD, ")
            .Append(" B.ACCOUNTNAME + ',' + C.CITYNAME AS PARTYNAME, ")
            .Append("  B.CRDAYS  AS PARTYSIDEDAYS,B.INTREST AS PARTYINTPER, ")
            .Append(" F.ACCOUNTNAME + ',' + G.CITYNAME AS AGENTNAME, ")
            .Append(" A.BOOKCODE, A.BOOKVNO, A.BILLNO, A.BILLDATE, ")
            flag = Operators.CompareString(Bill_Date_By, "BILL DATE", False) = 0
            If flag Then
                .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            Else
                .Append(" FORMAT(A.LRDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            End If
            .Append(" A.SIDEDAYS AS BILL_SIDE_DAYS, A.ACCOUNTCODE,B.AGENTCODE, ")
            .Append(" A.TOTAL_MTR_WEIGHT AS MTR_WEIGHT, ")
            .Append(" A.CGST_TAX_AMT + A.IGST_TAX_AMT + A.SGST_TAX_AMT AS GSTTAXAMT, ")
            .Append(" IIF(A.BOOKCODE='0000-000000001',A.ADJAMT,A.NET_AMOUNT) AS BILLAMT, ")
            .Append(" (0.0) AS RD, (0.0) AS CD, (0.0) AS GR, (0.0) AS OTHER_DEDUCT, ")
            .Append(" SPACE(10) AS RCPT_DATE, (0.0) AS RCPTAMOUNT, ")
            .Append(" (0.0) AS LATEDAYS, (0.0) AS INTAMOUNT, ")
            .Append(" (0.0) AS BILL_BALANCE, (0.0) AS LATEDAYS_OF_BALANCE, ")
            .Append(" (0.0) AS INT_OF_BILL_BALANCE, (0.0) AS ALREADY_RCPT_INTEREST, ")
            .Append(" (0.0) AS NET_INTEREST,H.BEHAVIOUR,A.ADJAMT AS TAXABLE ")
            .Append(" FROM TRNINVOICEHEADER A,MstMasterAccount B,MSTCITY C, ")
            .Append(" MstMasterAccount F,MSTCITY G,MSTBOOK H ")
            .Append(" WHERE 1=1 AND A.BOOKCODE<>'0000-000000001' ")
            .Append(" AND A.ACCOUNTCODE = B.ACCOUNTCODE ")
            .Append(" AND B.CITYCODE=C.CITYCODE AND A.BOOKCODE=H.BOOKCODE ")
            .Append(" AND B.AGENTCODE=F.ACCOUNTCODE AND F.CITYCODE=G.CITYCODE ")
            .Append(Date_Range1)
            .Append(Filter_Condition)
            .Append(Filter_Condition_BookVno)
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(Int_Per_Manual)
            .Append(Side_Days_Manual)
            .Append(" '" & Pymt_Date_By & "' as dayscalcby, ")
            .Append(" '" & Bill_Date_By & "' as METHOD, ")
            .Append(" B.ACCOUNTNAME + ',' + C.CITYNAME AS PARTYNAME, ")
            .Append("  B.CRDAYS  AS PARTYSIDEDAYS,B.INTREST AS PARTYINTPER, ")
            .Append(" F.ACCOUNTNAME + ',' + G.CITYNAME AS AGENTNAME, ")
            .Append(" A.BOOKCODE, A.BOOKVNO, A.BILLNO, A.BILLDATE, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            .Append(" 0  AS BILL_SIDE_DAYS, A.ACCOUNTCODE,B.AGENTCODE, ")
            .Append(" (0.0)  AS MTR_WEIGHT, ")
            .Append(" (0.0) AS GSTTAXAMT, ")
            .Append(" A.DEBITAMT + A.CREDITAMT AS BILLAMT, ")
            .Append(" (0.0) AS RD, (0.0) AS CD, (0.0) AS GR, (0.0) AS OTHER_DEDUCT, ")
            .Append(" SPACE(10) AS RCPT_DATE, (0.0) AS RCPTAMOUNT, ")
            .Append(" (0.0) AS LATEDAYS, (0.0) AS INTAMOUNT, ")
            .Append(" (0.0) AS BILL_BALANCE, (0.0) AS LATEDAYS_OF_BALANCE, ")
            .Append(" (0.0) AS INT_OF_BILL_BALANCE, (0.0) AS ALREADY_RCPT_INTEREST, ")
            .Append(" (0.0) AS NET_INTEREST,H.BEHAVIOUR,(0.0) AS TAXABLE ")
            .Append(" FROM TRNOUTSTANDING A,MstMasterAccount B,MSTCITY C, ")
            .Append(" MstMasterAccount F,MSTCITY G,MSTBOOK H ")
            .Append(" WHERE 1=1 AND A.BOOKCODE='0000-000000001' ")
            .Append(" AND A.ACCOUNTCODE = B.ACCOUNTCODE ")
            .Append(" AND B.CITYCODE=C.CITYCODE AND A.BOOKCODE=H.BOOKCODE ")
            .Append(" AND B.AGENTCODE=F.ACCOUNTCODE AND F.CITYCODE=G.CITYCODE ")
            .Append(Filter_Condition)
            .Append(Filter_Condition_BookVno_Opening)
            .Append(Date_Range1)
            .Append(_PaymentDate)
            .Append(" ) AS Z ")
            .Append(Order_By)
        End With
        Dim Str_Qry As String = strQuery.ToString
        Return strQuery.ToString
    End Function
    Public Function EntryData_GeneralInvoice_Offer(ByVal Book_Filter_String As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal ItemCode_FilterString As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append("  	SELECT 	  ")
            .Append("  	A.BOOKVNO, 	  ")
            .Append("  	A.OFFERNO AS [Offer No], 	  ")
            .Append("  	FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS [Offer Date], 	  ")
            .Append("  	B.ITEMNAME AS [Item Name], 	  ")
            .Append("  	C.CUTNAME AS [CUT], 	  ")
            .Append("  	SUM(A.MTR_WEIGHT) AS [Offer Qty], 	  ")
            .Append("  	'' AS [ADJ-QTY], 	  ")
            .Append("  	'' AS [BAL-QTY], 	  ")
            .Append("  	A.RATE AS  [Rate], 	  ")
            .Append("  	'' AS INV_QTY, 	  ")
            .Append("  	SUM(A.MTR_WEIGHT) AS Qty, 	  ")
            .Append("  	A.ITEMCODE, 	  ")
            .Append("  	A.CUTCODE, 	  ")
            .Append("  	'' AS BLANK_QTY	  ")
            .Append("  	,'MTR' AS LOTNO	  ")
            .Append("  	FROM 	  ")
            .Append("  	TRNOFFER AS A	  ")
            .Append("  	, MSTSTOREITEM AS B	  ")
            .Append("  	, MSTCUTMASTER AS C	  ")
            .Append("  	WHERE 1 = 1 	  ")
            .Append(Book_Filter_String)
            .Append("  	 AND A.ACCOUNTCODE='" & AccountCode & "' 	  ")
            .Append("  	AND A.OFFERDATE<='" & BillDate & "' 	  ")
            .Append(ItemCode_FilterString)
            .Append("  	AND A.CLEAR<>'YES' 	  ")
            .Append("  	AND A.ITEMCODE = B.ITEMCODE 	  ")
            .Append("  	AND A.CUTCODE = C.ID 	  ")
            .Append("  	GROUP BY 	  ")
            .Append("  	A.BOOKVNO	  ")
            .Append("  	,A.OFFERNO	  ")
            .Append("  	,A.OFFERDATE	  ")
            .Append("  	,B.ITEMNAME	  ")
            .Append("  	,C.CUTNAME	  ")
            .Append("  	,A.RATE	  ")
            .Append("  	,A.LOTNO	  ")
            .Append("  	,A.ITEMCODE	  ")
            .Append("  	,A.CUTCODE	  ")
            .Append("  	,A.LOOMTYPE 	  ")
            .Append("  	ORDER BY A.OFFERNO 	  ")

        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_FinishInvoice_Show_Finish_Offer(ByVal Book_Filter_String As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal ItemCode_FilterString As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" select a.bookvno, ")
            .Append(" a.offerNo as [Offer No], ")
            .Append(" Format(a.OfferDate,'dd/MM/yyyy') AS [Offer Date], ")
            .Append(" b.ITENNAME as [Item Name], ")
            .Append(" c.cutname as [Cut], ")
            .Append(" d.Design_Name as [Design No],")
            .Append(" e.SHADE as [Shade No],")
            .Append(" ISNULL (SUM(a.mtr_weight),0) as [Offer Qty],")
            .Append(" '' as [Adj-Qty], ")
            .Append(" '' as [Bal-Qty], ")
            .Append(" a.Rate AS   [Rate],")
            .Append(" IIF(a.LOTNO>'',a.LOTNO,'MTR') as  [Qty Type],")
            .Append(" '' as inv_qty, ")
            .Append(" ISNULL (SUM(a.mtr_Weight),0) as qty,")
            .Append(" A.ITEMCODE,")
            '.Append(" A.CUTCODE, SUBSTRING( A.LOOMTYPE,1,3) AS LOTNO, ")
            .Append(" A.CUTCODE, SUBSTRING( A.LOTNO,1,3) AS LOTNO, ")
            .Append(" '' AS BLANK_QTY,A.DESIGNCODE,A.SHADECODE,ISNULL (sum (A.AVGWEIGHT),0) AS [Avg. Wt.] ")
            .Append(" ,F.SELVEDGE_NAME AS [Selvedge] ")
            .Append(" ,A.SELVCODE ")

            .Append(" FROM TRNOFFER AS A, MSTFABRICITEM AS B, MstCutMaster AS C,Mst_Fabric_Design  AS D,Mst_Fabric_Shade E ")
            .Append(" ,Mst_selvedge F ")

            .Append(" where 1 = 1 ")
            .Append(" AND A.SELVCODE=F.ID ")
            .Append(" AND A.DESIGNCODE=D.Design_code ")
            .Append(" AND A.SHADECODE=E.id ")
            .Append(Book_Filter_String)
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.OFFERDATE<='" & BillDate & "' ")
            .Append(ItemCode_FilterString)
            .Append(" AND A.CLEAR<>'YES' ")
            .Append(" AND A.ITEMCODE = B.ID AND A.CUTCODE = C.ID ")
            .Append(" GROUP BY A.BOOKVNO,A.OFFERNO,A.OFFERDATE,B.ITENNAME,C.CUTNAME, ")
            .Append(" D.Design_Name,E.SHADE,A.RATE,A.LOTNO,A.ITEMCODE,A.CUTCODE, ")
            .Append(" A.DESIGNCODE,A.SHADECODE,a.loomtype,a.SELVCODE,F.SELVEDGE_NAME ")
            .Append(" ORDER BY A.OFFERNO ")
        End With
        Return strQuery.ToString

    End Function
    Public Function GetMaxCode(ByVal _ID As String, ByVal _TABLE As String) As String
        _ComapnyYearCode = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        GetMaxCode = Master_GetMaxCode(_ID, _TABLE, _ComapnyYearCode)
    End Function
    Public Function Master_GetMaxCode(ByVal _KeyFieldName As String, ByVal _TblName As String, ByVal _SELECTEDCOMPANYCODE As String) As String
        strQuery = New StringBuilder
        With strQuery
            strQuery.Append(" SELECT  TOP 1 SUBSTRING(" & _KeyFieldName & ",6,10)  FROM " & _TblName & " WHERE LEFT(" & _KeyFieldName & ",4)='" & _SELECTEDCOMPANYCODE & "'" & " ORDER BY " & _KeyFieldName & " DESC ")
        End With
        Return strQuery.ToString
    End Function
    Public Function Master_GetNameOtherThisEntry(ByVal _TblName As String, ByVal _KeyFieldName As String, ByVal _KeyFieldValue As String, ByVal strChkFieldName As String, ByVal strChkFieldValue As String) As String
        strQuery = New StringBuilder
        With strQuery
            strQuery.Append(" SELECT TOP 1 ID FROM " & _TblName & " WHERE  1=1 AND " & strChkFieldName & "='" & strChkFieldValue.ToString & "'" & " AND " & _KeyFieldName & "<>'" & _KeyFieldValue & "'")
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_Yarn_Offer_View_Record(ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" TrnOffer.BookVno, ")
            .Append(" TrnOffer.ENTRYNO as [Entry No], ")
            .Append(" TrnOffer.OfferNo as [Offer No], ")
            .Append(" FORMAT(TrnOffer.OfferDate,'dd/MM/yyyy') AS [Offer Date], ")
            .Append(" MstMasterAccount.accountname as [Party Name], ")
            .Append(" MstCity.cityname as [Despatch], ")
            .Append(" TrnOffer.SRNO as [Sno],  ")
            .Append(" Mstyarncount.countname as [Count Name], ")
            .Append(" TrnOffer.descr as [Descr], ")
            .Append(" TrnOffer.YARN_LOT_NO as [Lot No], ")
            .Append(" TrnOffer.YARN_SHADE_NO as [Shade No], ")
            .Append(" TrnOffer.Mtr_Weight as [Quantity], ")
            .Append(" TrnOffer.lotno as [Kgs/Bag], ")
            .Append(" TrnOffer.Descr as [Desc], ")
            .Append(" TrnOffer.Rate as [Rate],  ")
            .Append(" TrnOffer.RDValue as [RD ], ")
            .Append(" IIF(TrnOffer.RDValue<>0,TrnOffer.RDON,'') as [RD On], ")
            .Append(" TrnOffer.CDVALUE as [CD],  ")
            .Append(" IIF(TrnOffer.CDValue<>0,TrnOffer.CDON,'') as [CD On],  ")
            .Append(" TrnOffer.RowRemark as [Detail Remark], ")
            .Append(" MstTransport.TransportName as [Transport Name], ")
            .Append(" a.accountname as [Agent Name], ")
            .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
            .Append(" TrnOffer.PartyOfferNo as [Party Offer No], ")
            .Append(" TrnOffer.AgentOfferNo as [Agent Of-No], ")
            .Append(" TrnOffer.HeaderRemark as [Header Remark], ")
            .Append(" TrnOffer.Term1 as [Term 1], ")
            .Append(" TrnOffer.Term2 as [Term 2], ")
            .Append(" TrnOffer.Term3 as [Term 3], ")
            .Append(" TrnOffer.Term4 as [Term 4], ")
            .Append(" TrnOffer.cancel_Qty as [Cancel Qty], ")
            .Append(" TrnOffer.clear as [Clear], ")
            .Append(" TrnOffer.clear_Date as [Clear Date], ")
            .Append(" TrnOffer.clear_Remark as [Clear Remark] ")
            .Append(" FROM TRNOFFER, MSTCITY, MSTYARNCOUNT, ")
            .Append(" MstMasterAccount,MSTTRANSPORT, ")
            .Append(" MstMasterAccount AS A,Mst_Acof_Supply ")
            .Append(" WHERE 1=1 ")
            .Append(" And TRNOFFER.DESPATCHCODE=MSTCITY.CITYCODE ")
            .Append(" And TRNOFFER.ITEMCODE=MSTYARNCOUNT.COUNTCODE ")
            .Append(" And TRNOFFER.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" And TRNOFFER.TRANSPORTCODE=MSTTRANSPORT.ID ")
            .Append(" And MstMasterAccount.AGENTCODE=A.ACCOUNTCODE ")
            .Append(" And TRNOFFER.ACOFCODE=Mst_Acof_Supply.ID ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With

        Return strQuery.ToString
    End Function

    Public Function EntryData_FinishOfferEntry_View_Record(ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" TrnOffer.BookVno, ")
            .Append(" TrnOffer.ENTRYNO as [Entry No], ")
            .Append(" TrnOffer.OfferNo as [Offer No], ")
            .Append(" FORMAT(TrnOffer.OfferDate,'dd/MM/yyyy') AS [Offer Date], ")
            .Append(" MstMasterAccount.accountname as [Party Name], ")
            .Append(" MstCity.cityname as [Despatch], ")
            .Append(" TrnOffer.SRNO as [Sno],  ")
            .Append(" MstFabricItem.ITENNAME as [Item Name],  ")
            .Append(" MstCutMaster.cutname as [Cut], ")
            .Append(" Mst_Fabric_Design.Design_Name as [Design No], ")
            .Append(" Mst_Fabric_Shade.Shade as [Shade No], ")
            .Append(" TrnOffer.Mtr_Weight as [Quantity], ")
            .Append(" TrnOffer.lotno as [Mtr/Pcs/Bale], ")
            .Append(" TrnOffer.Descr as [Descr], ")
            .Append(" TrnOffer.Rate as [Rate],  ")
            .Append(" TrnOffer.RDValue as [RD ], ")
            .Append(" IIF(TrnOffer.RDValue<>0,TrnOffer.RDON,'') as [RD On], ")
            .Append(" TrnOffer.CDVALUE as [CD],  ")
            .Append(" IIF(TrnOffer.CDValue<>0,TrnOffer.CDON,'') as [CD On],  ")
            .Append(" TrnOffer.RowRemark as [Detail Remark], ")
            .Append(" MstTransport.TransportName as [Transport Name], ")
            .Append(" a.accountname as [Agent Name], ")
            .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
            .Append(" TrnOffer.PartyOfferNo as [Party Offer No], ")
            .Append(" TrnOffer.AgentOfferNo as [Agent Of-No], ")
            .Append(" TrnOffer.HeaderRemark as [Header Remark], ")
            .Append(" TrnOffer.Term1 as [Term 1], ")
            .Append(" TrnOffer.Term2 as [Term 2], ")
            .Append(" TrnOffer.Term3 as [Term 3], ")
            .Append(" TrnOffer.Term4 as [Term 4], ")
            .Append(" TrnOffer.cancel_Qty as [Cancel Qty], ")
            .Append(" TrnOffer.clear as [Clear], ")
            .Append(" TrnOffer.clear_Date as [Clear Date], ")
            .Append(" isnull( TrnOffer.clear_Remark ,'') as [Clear Remark] ")

            .Append(" FROM TRNOFFER, MSTCITY, Mst_Fabric_Design, MSTFABRICITEM, ")
            .Append(" MstMasterAccount,  Mst_Fabric_Shade, MSTTRANSPORT, ")
            .Append(" MstMasterAccount AS A,Mst_Acof_Supply,MstCutMaster ")
            .Append(" WHERE 1=1 ")
            .Append(" And TRNOFFER.DESPATCHCODE=MSTCITY.CITYCODE ")
            .Append(" And TRNOFFER.DESIGNCODE=Mst_Fabric_Design.Design_code  ")
            .Append(" And TRNOFFER.ITEMCODE=MSTFABRICITEM.ID ")
            .Append(" And TRNOFFER.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" And TRNOFFER.SHADECODE=Mst_Fabric_Shade.ID  ")
            .Append(" And TRNOFFER.TRANSPORTCODE=MSTTRANSPORT.ID ")
            .Append(" And MstMasterAccount.AGENTCODE=A.ACCOUNTCODE ")
            .Append(" And TRNOFFER.ACOFCODE=Mst_Acof_Supply.ID ")
            .Append(" AND TRNOFFER.CUTCODE=MstCutMaster.ID ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_job_Offer(ByVal Book_Filter_String As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal ItemCode_FilterString As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" select a.bookvno, ")
            .Append(" a.offerNo as [Offer No], ")
            .Append(" Format(a.OfferDate,'dd/MM/yyyy') AS [Offer Date], ")
            .Append(" b.ITENNAME as [Item Name], ")
            .Append(" c.cutname as [Cut], ")
            .Append(" d.Design_Name as [Design No],")
            .Append(" e.SHADE as [Shade No],")
            .Append(" SUM(a.mtr_weight) as [Offer Qty],")
            .Append(" '' as [Adj-Qty], ")
            .Append(" '' as [Bal-Qty], ")
            .Append(" a.Rate AS   [Rate],")
            .Append(" IIF(a.LOTNO>'',a.LOTNO,'MTRS') as  [Qty Type],")
            .Append(" '' as inv_qty, ")
            .Append(" SUM(a.mtr_Weight) as qty,")
            .Append(" A.ITEMCODE,")
            .Append(" A.CUTCODE, SUBSTRING( A.LOTNO,1,3) AS LOTNO, ")
            .Append(" '' AS BLANK_QTY,A.DESIGNCODE,A.SHADECODE,sum (A.AVGWEIGHT) AS [Avg. Wt.] ")
            .Append(" ,F.SELVEDGE_NAME AS [Selvedge] ")
            .Append(" ,A.SELVCODE ")

            .Append(" FROM TRNOFFER AS A, MSTFABRICITEM AS B, MstCutMaster AS C,Mst_Fabric_Design  AS D,Mst_Fabric_Shade E ")
            .Append(" ,Mst_selvedge F ")

            .Append(" where 1 = 1 ")
            .Append(" AND A.SELVCODE=F.ID ")
            .Append(" AND A.DESIGNCODE=D.Design_code ")
            .Append(" AND A.SHADECODE=E.id ")
            .Append(Book_Filter_String)
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.OFFERDATE<='" & BillDate & "' ")
            .Append(ItemCode_FilterString)
            .Append(" AND A.CLEAR<>'YES' ")
            .Append(" AND A.ITEMCODE = B.ID AND A.CUTCODE = C.ID ")
            .Append(" GROUP BY A.BOOKVNO,A.OFFERNO,A.OFFERDATE,B.ITENNAME,C.CUTNAME, ")
            .Append(" D.Design_Name,E.SHADE,A.RATE,A.LOTNO,A.ITEMCODE,A.CUTCODE, ")
            .Append(" A.DESIGNCODE,A.SHADECODE,a.loomtype,a.SELVCODE,F.SELVEDGE_NAME ")
            .Append(" ORDER BY A.OFFERNO ")
        End With
        Return strQuery.ToString

    End Function

#Region "Grey/Finish Folder Entry Data "
    Public Function Debit_Note_To_P_H_Alter_Form_Qry(ByVal Book_Code As String, ByVal Book_Vno As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" B.ACCOUNTNAME AS PROCESSNAME,E.ITENNAME AS  FABRIC_ITEMNAME, ")
            .Append(" H.GMTR AS ORG_MTR,E.MAXSHRINK AS MAX_SHRINK_PER,")
            .Append(" F.Design_Name AS FABRIC_DESIGN_NO, G.SHADE AS FABRIC_SHADE_NO ")
            .Append(" FROM TRNFINISHRCPT AS A,MstMasterAccount AS B, ")
            .Append(" MSTFABRICITEM AS E, Mst_Fabric_Design AS F, Mst_Fabric_Shade AS G, ")
            .Append(" TRNGREYDESP AS H ")
            .Append(" WHERE 1=1 AND A.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" AND A.FABRIC_ITEMCODE=E.ID ")
            .Append(" AND A.FABRIC_DESIGNCODE=F.Design_code ")
            .Append(" AND A.FABRIC_SHADECODE=G.ID ")
            .Append(" AND A.GREY_DESP_PCS_ID=H.GREY_DESP_PCS_ID ")
            .Append(" AND A.BOOKCODE='" & Book_Code & "'" & "  ")
            .Append(" AND A.BOOKVNO='" & Book_Vno & "'" & "  ")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return strQuery.ToString
    End Function

    Public Function Debit_Note_To_P_H_btn_Add_Modify_Delete_Click_Qry(ByVal Org_Finish_Rcpt_Tbl_Name As String, ByVal Txt_Dt As String, ByVal Book_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 A.ENTRYNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE ")
            .Append(" FROM " & Org_Finish_Rcpt_Tbl_Name & "  AS A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.CHALLANDATE>='" & Txt_Dt & "' ")
            .Append(" AND A.BOOKCODE='" & Book_Code & "'" & " ")
            .Append(" ORDER BY A.BOOKVNO DESC ")
        End With
        Return _strQuery.ToString
    End Function



    Public Function Get_Debit_Note_To_P_H_View_Query(ByVal Book_Code As String, ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.BOOKVNO, A.ENTRYNO AS [Entry No],")
            .Append(" B.ACCOUNTNAME AS [Process],")
            .Append(" A.CHALLANNO as [Challan No],")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS [Chl-Date],")
            .Append(" COUNT(A.PIECENO) AS [Pcs], ")
            .Append(" SUM(A.GMTR) AS [Grey Mtrs],")
            .Append(" SUM(A.PMTR) AS [D/N Mtrs],")
            .Append(" SUM(A.SHK_MTR) AS [Shk-Mtrs],")
            'If _CompanyDataRow("PROCESS_SHRINKAGE_CALC_BY").ToString = "PMTR" Then
            '    .Append(" ROUND(((SUM(A.GMTR)-SUM(A.PMTR))*100)/SUM(A.PMTR),2) AS [Shk %],")
            'Else
            .Append(" ROUND(((SUM(A.GMTR)-SUM(A.PMTR))*100)/SUM(A.GMTR),2) AS [Shk %],")
            'End If
            .Append(" SUM(A.GMTR) AS GREY_MTR,SUM(A.PMTR) AS FINISH_MTR,")
            .Append(" SUM(A.SHK_MTR) AS SHRINK_MTR ")
            .Append(" FROM TRNFINISHRCPT AS A, MstMasterAccount AS B ")
            .Append(" WHERE 1=1 And A.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" AND A.BOOKCODE='" & Book_Code & "' ")
            .Append(View_Filter_Condition)
            .Append(" GROUP BY A.BOOKVNO, A.ENTRYNO, A.CHALLANNO, A.CHALLANDATE,B.ACCOUNTNAME ")
            .Append(View_Order_By)
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Lump_ID_of_TrnFinishRcpt_Qry(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" SUBSTRING(LUMP_ID,6,9) ")
            .Append(" FROM TrnFinishRcpt ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(LUMP_ID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY LUMP_ID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Lump_ID_of_TrnDenimFolding_Qry(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" SUBSTRING(LUMP_ID,6,9) ")
            .Append(" FROM TrnDenimFolding ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(LUMP_ID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY LUMP_ID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Lump_No_of_TrnFinishRcpt_Qry() As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 LUMP_NO ")
            .Append(" FROM TrnFinishRcpt ")
            .Append(" WHERE 1=1 ")
            .Append(" ORDER BY LUMP_NO DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Lump_No_of_TrnDenimFolding_Qry() As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 LUMP_NO ")
            .Append(" FROM TrnDenimFolding ")
            .Append(" WHERE 1=1 ")
            .Append(" ORDER BY LUMP_NO DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Grey_Challan_Entry_Alter_Form_Qry(ByVal _BookCode As String, ByVal Book_Vno As String, ByVal EntryNo As Integer, ByVal UNITCODE As String) As String
        _strQuery = New StringBuilder
        If EntryNo = Nothing Then EntryNo = Book_Vno
        With _strQuery
            'If _BookCode = "0001-000000106" Then
            '    .Append(" SELECT A.*, convert(varchar,  A.CHALLANDATE, 103)  AS F_CHALLANDATE, ")
            '    .Append(" convert(varchar,  A.SALES_DATE, 103) AS F_SALES_DATE, ")
            '    .Append(" B.ACCOUNTNAME AS PROCESSNAME, C.ACCOUNTNAME AS FACTORYNAME, ")
            '    .Append(" D.ACCOUNTNAME AS PARTYNAME, E.ITENNAME AS FABRIC_ITEMNAME,E.WTPERMTR AS AVG_WEIGHT,E.WTVERIANCE AS AVG_WEIGHT_VARIANCE, ")
            '    .Append(" F.Design_Name AS FABRIC_DESIGN_NO, G.SHADE AS FABRIC_SHADE_NO, ")
            '    .Append(" H.REMARKNAME AS FINISHREMARK, I.SELVEDGE_NAME AS SELVNAME, (A.GMTR) AS F_GMTR, ")
            '    .Append(" (A.WEIGHT) AS F_WEIGHT,(A.PCAVGWT) AS F_PCAVGWT, ")
            '    .Append(" J.ACCOUNTNAME AS SALES_PARTY_NAME,K.AC_NAME AS SALES_ACOF_NAME ")
            '    .Append(" FROM TRNGREYDESP AS A, MstMasterAccount AS B, MstMasterAccount AS C, MstMasterAccount AS D, ")
            '    .Append(" MSTFABRICITEM AS E, Mst_Fabric_Design AS F, Mst_Fabric_Shade AS G, MSTREMARK AS H, Mst_selvedge AS I, ")
            '    .Append(" MstMasterAccount AS J,Mst_Acof_Supply AS K ")
            '    .Append(" WHERE 1=1 And A.PROCESSCODE=B.ACCOUNTCODE And A.FACTORYCODE=C.ACCOUNTCODE ")
            '    .Append(" And A.SALES_ACCOUNTCODE=J.ACCOUNTCODE AND A.ACOFCODE=I.ID ")
            '    .Append(" And A.ACCOUNTCODE=D.ACCOUNTCODE And ")
            '    .Append(" A.FABRIC_ITEMCODE=E.ID And A.FABRIC_DESIGNCODE=F.Design_code ")
            '    .Append(" And A.FABRIC_SHADECODE=G.ID And  A.FINISH_REMARK_CODE=H.REMARKCODE ")
            '    .Append(" And A.SELVCODE=I.ID ")
            '    .Append(" AND A.BOOKCODE='" & _BookCode & "'" & "  ")
            '    .Append(" AND A.ENTRYNO=" & EntryNo & "" & "  ")
            '    .Append(" ORDER BY A.SRNO ")
            'Else
            .Append(" SELECT A.*, convert(varchar,  A.CHALLANDATE, 103)  AS F_CHALLANDATE, ")
            .Append(" convert(varchar,  A.SALES_DATE, 103) AS F_SALES_DATE, ")
            .Append(" B.ACCOUNTNAME AS PROCESSNAME, C.ACCOUNTNAME AS FACTORYNAME, ")
            .Append(" D.ACCOUNTNAME AS PARTYNAME, E.ITENNAME AS FABRIC_ITEMNAME,E.WTPERMTR AS AVG_WEIGHT,E.WTVERIANCE AS AVG_WEIGHT_VARIANCE, ")
            .Append(" F.Design_Name AS FABRIC_DESIGN_NO1, G.SHADE AS FABRIC_SHADE_NO1, ")
            .Append(" H.REMARKNAME AS FINISHREMARK, I.SELVEDGE_NAME AS SELVNAME, (A.GMTR) AS F_GMTR, ")
            .Append(" (A.WEIGHT) AS F_WEIGHT,(A.PCAVGWT) AS F_PCAVGWT, ")
            .Append(" J.ACCOUNTNAME AS SALES_PARTY_NAME,K.AC_NAME AS SALES_ACOF_NAME ")
            .Append(" ,L.TRANSPORTNAME ")
            .Append(" ,M.SHADE AS OFFERSHADENAME ")
            .Append(" ,N.Design_Name AS OFFERDESIGNNAME ")
            .Append(" ,O.cityname AS DISPATCHNAME ")


            .Append(" FROM TRNGREYDESP AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstMasterAccount AS C ON A.FACTORYCODE=C.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS D ON A.ACCOUNTCODE=D.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTFABRICITEM AS E ON A.FABRIC_ITEMCODE=E.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design AS F ON A.FABRIC_DESIGNCODE=F.Design_code ")
            .Append(" LEFT JOIN Mst_Fabric_Shade AS G ON  A.FABRIC_SHADECODE=G.ID ")
            .Append(" LEFT JOIN MSTREMARK AS H ON A.FINISH_REMARK_CODE=H.REMARKCODE  ")
            .Append(" LEFT JOIN Mst_selvedge AS I ON A.SELVCODE=I.ID  ")
            .Append(" LEFT JOIN MstMasterAccount AS J ON A.SALES_ACCOUNTCODE=J.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Acof_Supply AS K  ON A.ACOFCODE=K.ID ")
            .Append(" LEFT JOIN MstTransport AS L  ON A.GODOWNCODE=L.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Shade AS M ON  A.OP5=M.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design AS N ON A.OP7=N.Design_code ")
            .Append(" LEFT JOIN MstCity AS O ON A.OP19=O.citycode ")


            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & "  ")
            .Append(" AND A.ENTRYNO=" & EntryNo & "" & "  ")
            .Append(UNITCODE)
            .Append(" ORDER BY A.SRNO ")
            'End If
        End With
        Return _strQuery.ToString
    End Function


    Public Function Last_Grey_Rcpt_Pcs_ID_From_trnProcessInventory_Table(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 SUBSTRING(pieceid,6,9) ")
            .Append(" FROM trnProcessInventory ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(pieceid,4)='" & Company_Code & "' ")
            .Append(" ORDER BY pieceid DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Grey_Desp_Pcs_ID_From_trnDenimGreyRcpt_Table(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 SUBSTRING(Grey_DESP_Pcs_ID,6,9) ")
            .Append(" FROM trnDenimGreyRcpt ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(Grey_DESP_Pcs_ID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY Grey_DESP_Pcs_ID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Process_Fold_Pcs_ID_From_trnProcessFolding_Table(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 SUBSTRING(Fold_Pcs_ID,6,9) ")
            .Append(" FROM TrnProcessFolding ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(Fold_Pcs_ID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY Fold_Pcs_ID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Grey_Issue_Pcs_ID_From_trnProcessInventory_Table(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 SUBSTRING(PieceID,6,9) ")
            .Append(" FROM trnProcessInventory ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(PieceID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY PieceID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Grey_Issue_Pcs_ID_From_trnDenimInventory_Table(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 SUBSTRING(PieceID,6,9) ")
            .Append(" FROM trnDenimInventory ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(PieceID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY PieceID DESC ")
        End With
        Return _strQuery.ToString
    End Function





    Public Function Grey_Return_View_Qry(ByVal PROCESS_SHRINKAGE_CALC_BY As String, ByVal _BookCode As String, ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.BOOKVNO, A.ENTRYNO AS [Entry No],")
            .Append(" B.ACCOUNTNAME AS [Process],")
            .Append(" A.CHALLANNO as [Challan No],")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS [Chl-Date],")
            .Append(" COUNT(A.PIECENO) AS [Pcs], ")
            .Append(" SUM(A.GMTR) AS [Grey Mtrs],")
            .Append(" SUM(A.PMTR) AS [Return Mtrs],")
            .Append(" SUM(A.SHK_MTR) AS [Shk-Mtrs],")
            If PROCESS_SHRINKAGE_CALC_BY = "PMTR" Then
                .Append(" ROUND(((SUM(A.GMTR)-SUM(A.PMTR))*100)/SUM(A.PMTR),2) AS [Shk %],")
            Else
                .Append(" ROUND(((SUM(A.GMTR)-SUM(A.PMTR))*100)/SUM(A.GMTR),2) AS [Shk %],")
            End If
            .Append(" SUM(A.GMTR) AS GREY_MTR,SUM(A.PMTR) AS FINISH_MTR,")
            .Append(" SUM(A.SHK_MTR) AS SHRINK_MTR ")
            .Append(" FROM TRNFINISHRCPT AS A, MstMasterAccount AS B ")
            .Append(" WHERE 1=1 And A.PROCESSCODE=B.ACCOUNTCODE ")

            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            .Append(View_Filter_Condition)
            .Append(" GROUP BY A.BOOKVNO, A.ENTRYNO, A.CHALLANNO, A.CHALLANDATE,B.ACCOUNTNAME ")
            .Append(View_Order_By)
        End With
        Return _strQuery.ToString
    End Function

    Public Function Last_Grey_Rcpt_Pcs_ID_Qry_From_TrnGreyRcpt(ByVal Company_Code As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 SUBSTRING(Grey_Rcpt_Pcs_ID,6,9) ")
            .Append(" FROM TrnGreyRcpt ")
            .Append(" WHERE 1=1 ")
            .Append(" AND LEFT(Grey_Rcpt_Pcs_ID,4)='" & Company_Code & "' ")
            .Append(" ORDER BY Grey_Rcpt_Pcs_ID DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Grey_Transfer_Alter_Form_Qry(ByVal _BookCode As String, ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" B.ACCOUNTNAME AS PROCESSNAME,E. ITENNAME AS FABRIC_ITEMNAME, ")
            .Append(" I.ACCOUNTNAME AS DPROCESSNAME, ")
            .Append(" H.GMTR AS ORG_MTR,E.MAXSHRINK AS MAX_SHRINK_PER,")
            .Append(" F.Design_Name AS FABRIC_DESIGN_NO, G.SHADE AS FABRIC_SHADE_NO ")
            .Append(" FROM TRNFINISHRCPT AS A,MstMasterAccount AS B, ")
            .Append(" MSTFABRICITEM AS E, Mst_Fabric_Design AS F, Mst_Fabric_Shade AS G, ")
            .Append(" TRNGREYDESP AS H,MstMasterAccount I ")
            .Append(" WHERE 1=1 AND A.PROCESSCODE=B.ACCOUNTCODE ")
            .Append(" AND A.ProcessCode_Transfer=I.ACCOUNTCODE ")
            .Append(" AND A.FABRIC_ITEMCODE=E.ID ")
            .Append(" AND A.FABRIC_DESIGNCODE=F.Design_code ")
            .Append(" AND A.FABRIC_SHADECODE=G.ID ")
            .Append(" AND A.GREY_DESP_PCS_ID=H.GREY_DESP_PCS_ID ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & "  ")
            .Append(" AND A.BOOKVNO='" & strKeyID & "'" & "  ")
            .Append(" ORDER BY A.SRNO ")
        End With

        Return _strQuery.ToString
    End Function
    Public Function Grey_Transfer_btn_Add_Modify_Delete_Click_Qry(ByVal Org_Finish_Rcpt_Tbl_Name As String, ByVal Txt_Dt As String, ByVal _BookCode As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 A.ENTRYNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE ")
            .Append(" FROM " & Org_Finish_Rcpt_Tbl_Name & "  AS A ")
            .Append(" WHERE 1=1  ")
            '.Append(" AND A.CHALLANDATE>='" & Txt_Dt & "' ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" ORDER BY A.BOOKVNO DESC ")
        End With
        Return _strQuery.ToString
    End Function


#End Region

#Region "MONTHLY SUMMRY"
    Public Function Get_Monthly_Summary_Sundry_Display_Qry_1(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal _DisplayType As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" F.BOOKNAME AS [Book Name], ")

            If _DisplayType = "MONTH WISE" Then
                .Append(" FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy') AS [Month Name], ")
            ElseIf _DisplayType = "DAY WISE" Then
                .Append(" FORMAT(E.BILLDATE,'dd/MM/yyyy') AS [Date Name], ")
            End If


            .Append(" ROUND(SUM(E.TOTAL_PCS),0) AS [Pcs], ")

            If Book_Behaviour = "YARN" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity] ")
                '.Append(" (0.00) AS [Quantity] ")
            ElseIf Book_Behaviour = "GENERAL" Then
                '.Append(" (0.00) AS [Weight] ")
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity] ")
            Else
                .Append(" round(SUM(E.TOTAL_WEIGHT),3) AS [Weight], ")
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity] ")
            End If


            .Append(" ,SUM(E.GROSS_AMOUNT) AS [Gross Amount] ")
            '.Append(" ,0.00 AS CD ")
            '.Append(" ,0.00 AS DISCOUNT ")
            '.Append(" ,0.00 AS RD ")
            '.Append(" ,0.00 AS COMMISSION ")
            '.Append(" ,0.00 AS [PACKING CHG] ")
            '.Append(" ,0.00 AS FREIGHT ")
            '.Append(" ,0.00 AS [OTHER (+)] ")
            '.Append(" ,0.00 AS [OTHER (-)] ")
            '.Append(" ,0.00 AS MENDING ")
            '.Append(" ,0.00 AS [MONO-CHG] ")
            '.Append(" ,0.00 AS [CARTAGE] ")
            '.Append(" ,0.00 AS [INS-CHG] ")
            '.Append(" ,0.00 AS [BALE CHG] ")
            '.Append(" ,0.00 AS [TOTAL TAXABLE AMOUNT] ")
            '.Append(" ,0.00 AS CGST ")
            '.Append(" ,0.00 AS SGST ")
            '.Append(" ,0.00 AS IGST ")
            '.Append(" ,0.00 AS TCS ")
            '.Append(" ,0.00 AS TCC ")
            '.Append(" ,0.00 AS [T.D.S.] ")
            '.Append(" ,0.00 AS [SCHEME ADD] ")
            .Append(" ,ROUND(SUM(E.ROUND_OFF),3) AS [Round Off] ")
            .Append(" ,ROUND(SUM(E.NET_AMOUNT),2) AS [Net Amount] ")
            .Append(" FROM ")
            .Append("  TRNINVOICEHEADER AS E  ")
            .Append(" Left Join MstMasterAccount AS C ON E.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" Left Join MSTCITY AS D ON C.CITYCODE=D.CITYCODE  ")
            .Append(" Left Join MstBook AS F  ON E.BOOKCODE=F.BOOKCODE ")
            .Append(" WHERE 1=1 ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")



            If _DisplayType = "MONTH WISE" Then
                .Append(" GROUP BY FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy'),FORMAT(E.BILLDATE,'MM'),FORMAT(E.BILLDATE,'yyyy') ")
                .Append(" ,F.BOOKNAME")
                .Append(" ORDER BY F.BOOKNAME,FORMAT(E.BILLDATE,'yyyy'),FORMAT(E.BILLDATE,'MM') ")

            ElseIf _DisplayType = "DAY WISE" Then
                .Append(" GROUP BY E.BILLDATE ")
                .Append(" ,F.BOOKNAME")
                .Append(" ORDER BY E.BILLDATE ")
            End If

        End With

        Return _strQuery.ToString
    End Function


    Public Function Get_Monthly_Summary_Sundry_Display_Qry_2(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" F.BOOKNAME AS [Book Name], ")
            .Append(" FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy') AS PARTYNAME, ")
            .Append(" FORMAT(E.BILLDATE,'MM') AS MONTH_NAME, ")
            .Append(" FORMAT(E.BILLDATE,'yyyy') AS YEAR_NAME, A.SUNPRNNAME, ")
            .Append(" ROUND(SUM(E.CALCAMOUNT),3) AS SUNDRY_AMOUNT ")
            .Append(" FROM MSTBILLSUNDRY AS A, TRNINVOICESUNDRY AS E ")
            .Append(" ,MstBook AS F ")
            .Append(" WHERE 1=1 AND A.SUNCODE=E.SUNCODE AND E.CALCAMOUNT>0  ")
            .Append(" AND E.BOOKCODE=F.BOOKCODE ")
            '.Append(" AND E.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY A.SUNPRNNAME, FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy'), ")
            .Append(" FORMAT(E.BILLDATE,'MM'), FORMAT(E.BILLDATE,'yyyy') ")
            .Append(" ,F.BOOKNAME")
            .Append(" ORDER BY F.BOOKNAME,FORMAT(E.BILLDATE,'MM'), FORMAT(E.BILLDATE,'yyyy') ")
        End With

        Return _strQuery.ToString
    End Function


    Public Function Get_Head_Summary_Sundry_Display_Qry_1(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal _DisplayType As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" F.BOOKNAME AS [Book Name], ")
            .Append(" C.ACCOUNTNAME AS [Account Name], ")
            '.Append(" FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy') AS [Month Name], ")
            .Append(" ROUND(SUM(E.TOTAL_PCS),0) AS [Pcs], ")

            If Book_Behaviour = "YARN" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity] ")
            ElseIf Book_Behaviour = "GENERAL" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity] ")
            Else
                .Append(" round(SUM(E.TOTAL_WEIGHT),3) AS [Weight], ")
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity] ")
            End If

            .Append(" ,SUM(E.GROSS_AMOUNT) AS [Gross Amount] ")
            '.Append(" ,0.00 AS CD ")
            '.Append(" ,0.00 AS DISCOUNT ")
            '.Append(" ,0.00 AS RD ")
            '.Append(" ,0.00 AS COMMISSION ")
            '.Append(" ,0.00 AS [PACKING CHG] ")
            '.Append(" ,0.00 AS FREIGHT ")
            '.Append(" ,0.00 AS [OTHER (+)] ")
            '.Append(" ,0.00 AS [OTHER (-)] ")
            '.Append(" ,0.00 AS MENDING ")
            '.Append(" ,0.00 AS [MONO-CHG] ")
            '.Append(" ,0.00 AS [CARTAGE] ")
            '.Append(" ,0.00 AS [INS-CHG] ")
            '.Append(" ,0.00 AS [BALE CHG] ")
            '.Append(" ,0.00 AS [TOTAL TAXABLE AMOUNT] ")
            '.Append(" ,0.00 AS CGST ")
            '.Append(" ,0.00 AS SGST ")
            '.Append(" ,0.00 AS IGST ")
            '.Append(" ,0.00 AS TCS ")
            '.Append(" ,0.00 AS TCC ")
            '.Append(" ,0.00 AS [T.D.S.] ")
            '.Append(" ,0.00 AS [SCHEME ADD] ")
            .Append(" ,ROUND(SUM(E.ROUND_OFF),3) AS [Round Off] ")
            .Append(" ,ROUND(SUM(E.NET_AMOUNT),2) AS [Net Amount] ")
            .Append(" FROM ")
            .Append("  TRNINVOICEHEADER AS E  ")
            .Append(" Left Join MstMasterAccount AS C ON E.OPP_ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" Left Join MSTCITY AS D ON C.CITYCODE=D.CITYCODE  ")
            .Append(" Left Join MstBook AS F  ON E.BOOKCODE=F.BOOKCODE ")
            .Append(" WHERE 1=1 ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")



            .Append(" GROUP BY ")
            .Append(" F.BOOKNAME")
            .Append(" ,C.ACCOUNTNAME")
            .Append(" ORDER BY F.BOOKNAME,C.ACCOUNTNAME ")

        End With

        Return _strQuery.ToString
    End Function




    Public Function Get_Head_Summary_Sundry_Display_Qry_2(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" H.BOOKNAME AS [Book Name], ")
            .Append(" G.ACCOUNTNAME AS PARTYNAME, ")
            .Append(" G.ACCOUNTNAME AS DAY_NAME, ")
            .Append(" A.SUNPRNNAME, ")
            .Append(" ROUND(SUM(E.CALCAMOUNT),3) AS SUNDRY_AMOUNT ")
            .Append(" ,FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy') AS MONTHNAME ")
            '.Append(" FROM MSTBILLSUNDRY A, TRNINVOICESUNDRY E,TRNINVOICEHEADER F, ")
            '.Append(" MstMasterAccount G ")
            '.Append(" ,MstBook AS H ")

            .Append(" FROM ")
            .Append(" MSTBILLSUNDRY A ")
            .Append(" LEFT JOIN TRNINVOICESUNDRY E ON A.SUNCODE=E.SUNCODE ")
            .Append(" LEFT JOIN TRNINVOICEHEADER F ON E.BOOKVNO=F.BOOKVNO ")
            .Append(" LEFT JOIN MstMasterAccount G ON F.OPP_ACCOUNTCODE=G.ACCOUNTCODE")
            .Append(" LEFT JOIN MstBook AS H ON F.BOOKCODE=H.BOOKCODE ")


            .Append(" WHERE 1=1  AND E.CALCAMOUNT>0  ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY A.SUNPRNNAME, G.ACCOUNTNAME ")
            .Append(" ,H.BOOKNAME")
            .Append(" ,FORMAT(E.BILLDATE,'MMMM') +','+ FORMAT(E.BILLDATE,'yyyy'), ")
            .Append(" FORMAT(E.BILLDATE,'MM'), FORMAT(E.BILLDATE,'yyyy') ")
            .Append(" ORDER BY G.ACCOUNTNAME ")
        End With

        Return _strQuery.ToString
    End Function

    Public Function Get_Day_Summary_Sundry_Display_Qry_1(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" FORMAT(E.BILLDATE,'dd/MM/yyyy') AS [Date Name], ")
            .Append(" ROUND(SUM(E.TOTAL_PCS),0) AS [Pcs], ")
            If Book_Behaviour = "YARN" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Weight], ")
                .Append(" (0.00) AS [Meters], ")
            ElseIf Book_Behaviour = "GENERAL" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity], ")
                .Append(" (0.00) AS [Qty], ")
            Else
                .Append(" round(SUM(E.TOTAL_WEIGHT),3) AS [Weight], ")
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Meters], ")
            End If
            .Append(" SUM(E.GROSS_AMOUNT) AS [Gross Amount], ")
            .Append(" ROUND(SUM(E.ROUND_OFF),3) AS [Round Off], ")
            .Append(" ROUND(SUM(E.NET_AMOUNT),2) AS [Net Amount] ")
            .Append(" FROM ")
            .Append(" MstMasterAccount AS C, MSTCITY AS D, TRNINVOICEHEADER AS E ")
            .Append(" WHERE 1=1 ")
            .Append(" And E.ACCOUNTCODE=C.ACCOUNTCODE And C.CITYCODE=D.CITYCODE ")
            '.Append(" AND E.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY E.BILLDATE ")
            .Append(" ORDER BY E.BILLDATE ")
        End With

        Return _strQuery.ToString
    End Function
    Public Function Get_Day_Summary_Sundry_Display_Qry_2(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" F.BOOKNAME AS [Book Name], ")
            .Append(" FORMAT(E.BILLDATE,'dd/MM/yyyy') AS PARTYNAME, ")
            .Append(" FORMAT(E.BILLDATE,'dd/MM/yyyy') AS DAY_NAME, ")
            .Append(" A.SUNPRNNAME, ")
            .Append(" ROUND(SUM(E.CALCAMOUNT),3) AS SUNDRY_AMOUNT ")
            .Append(" FROM MSTBILLSUNDRY AS A, TRNINVOICESUNDRY AS E ")
            .Append(" ,MstBook AS F ")

            .Append(" WHERE 1=1 AND A.SUNCODE=E.SUNCODE AND E.CALCAMOUNT>0  ")
            .Append(" AND E.BOOKCODE=F.BOOKCODE ")
            '.Append(" AND E.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY A.SUNPRNNAME, E.BILLDATE ")
            .Append(" ,F.BOOKNAME")
            .Append(" ORDER BY F.BOOKNAME,E.BILLDATE ")
        End With

        Return _strQuery.ToString
    End Function

    Public Function Get_Party_Summary_Sundry_Display_Qry_1(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal _SelectionListBy As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")

            If _SelectionListBy = "PARTY WISE" Then
                .Append(" C.ACCOUNTNAME AS [Party Name], ")
                .Append(" C.GSTREGTYPE AS [GST Type], ")
                .Append(" C.GSTIN AS [GSTIN], ")
                .Append(" LTRIM(F.GSTCODE)+'-'+LTRIM(F.STATENAME) AS [State], ")
            Else
                .Append(" G.ACCOUNTNAME AS [Agent Name], ")
                .Append(" G.GSTREGTYPE AS [GST Type], ")
                .Append(" G.GSTIN AS [GSTIN], ")
            End If

            .Append(" ROUND(SUM(E.TOTAL_PCS),0) AS [Pcs], ")
            If Book_Behaviour = "YARN" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Weight], ")
                .Append(" (0.00) AS [Meters], ")
            ElseIf Book_Behaviour = "GENERAL" Then
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Quantity], ")
                .Append(" (0.00) AS [Qty], ")
            Else
                .Append(" round(SUM(E.TOTAL_WEIGHT),3) AS [Weight], ")
                .Append(" round(SUM(E.TOTAL_MTR_WEIGHT),3) AS [Meters], ")
            End If
            .Append(" SUM(E.GROSS_AMOUNT) AS [Gross Amount], ")
            .Append(" ROUND(SUM(E.ROUND_OFF),3) AS [Round Off], ")
            .Append(" ROUND(SUM(E.NET_AMOUNT),2) AS [Net Amount] ")
            .Append(" FROM ")
            .Append(" MstMasterAccount AS C, MSTCITY AS D, TRNINVOICEHEADER AS E,MSTSTATE F ")
            .Append(" ,MstMasterAccount AS G ")
            .Append(" WHERE 1=1 AND D.STATEID=F.STATEID ")
            .Append(" And E.ACCOUNTCODE=C.ACCOUNTCODE And C.CITYCODE=D.CITYCODE ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" And C.AGENTCODE = G.ACCOUNTCODE  ")




            If _SelectionListBy = "PARTY WISE" Then
                .Append(" GROUP BY F.GSTCODE, ")
                .Append(" F.STATENAME, ")
                .Append(" C.ACCOUNTNAME,C.GSTREGTYPE,C.GSTIN ")
                .Append(" ORDER BY C.ACCOUNTNAME ")
            Else
                .Append(" GROUP BY ")
                .Append(" G.ACCOUNTNAME,G.GSTREGTYPE,G.GSTIN ")
                .Append(" ORDER BY G.ACCOUNTNAME ")
            End If



        End With

        Return _strQuery.ToString
    End Function
    Public Function Get_Party_Summary_Sundry_Display_Qry_2(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal _SelectionListBy As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            If _SelectionListBy = "PARTY WISE" Then
                .Append(" G.ACCOUNTNAME AS PARTYNAME, ")
                .Append(" G.ACCOUNTNAME AS DAY_NAME, ")
            Else
                .Append(" H.ACCOUNTNAME AS PARTYNAME, ")
                .Append(" H.ACCOUNTNAME AS DAY_NAME, ")
            End If

            .Append(" A.SUNPRNNAME, ")
            .Append(" ROUND(SUM(E.CALCAMOUNT),3) AS SUNDRY_AMOUNT ")
            .Append(" FROM MSTBILLSUNDRY A, TRNINVOICESUNDRY E,TRNINVOICEHEADER F, ")
            .Append(" MstMasterAccount G ")
            .Append(" ,MstMasterAccount H ")
            .Append(" WHERE 1=1 AND A.SUNCODE=E.SUNCODE AND E.CALCAMOUNT>0  ")
            .Append(" AND E.BOOKVNO=F.BOOKVNO AND F.ACCOUNTCODE=G.ACCOUNTCODE ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" AND G.AGENTCODE=H.ACCOUNTCODE  ")

            .Append(" GROUP BY A.SUNPRNNAME,")
            If _SelectionListBy = "PARTY WISE" Then
                .Append(" G.ACCOUNTNAME ")
                .Append(" ORDER BY G.ACCOUNTNAME ")
            Else
                .Append(" H.ACCOUNTNAME ")
                .Append(" ORDER BY H.ACCOUNTNAME ")
            End If

        End With
        Return _strQuery.ToString
    End Function
    Public Function Get_Bill_No_Summary_Sundry_Display_Qry_1(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String, ByVal ShowDelivery As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT E.BOOKVNO, ")
            .Append(" E.ENTRYNO AS [Entry No], ")
            .Append(" E.BILLNO AS [Bill No], ")
            .Append(" FORMAT(E.BILLDATE,'dd/MM/yyyy') AS [Bill Date], ")
            .Append(" C.ACCOUNTNAME AS [Party Name], ")
            .Append(" D.cityname AS [Party City], ")
            .Append(" G.cityname AS [Dispatch City], ")
            .Append(" H.TRANSPORTNAME AS [Transport Name], ")
            .Append(" C.PANNO AS [PAN No], ")
            .Append(" C.GSTIN AS [GSTIN], ")
            .Append(" LTRIM(F.GSTCODE)+'-'+LTRIM(F.STATENAME) AS [State], ")
            .Append(" E.LRNO AS [LR No], ")
            .Append(" ((E.TOTAL_PCS)) AS [Pcs], ")


            If Book_Behaviour = "YARN" Then
                .Append(" ((E.TOTAL_MTR_WEIGHT)) AS [Weight], ")
                .Append(" (0.00) AS [Meters], ")
            ElseIf Book_Behaviour = "GENERAL" Then
                .Append(" ((E.TOTAL_MTR_WEIGHT)) AS [Quantity], ")
                .Append(" (0.00) AS [Qty], ")
            Else
                .Append(" ((E.TOTAL_WEIGHT)) AS [Weight], ")
                .Append(" ((E.TOTAL_MTR_WEIGHT)) AS [Meters], ")
            End If

            .Append(" (E.GROSS_AMOUNT) AS [Gross Amount], ")
            .Append(" ((E.ROUND_OFF)) AS [Round Off], ")
            .Append(" ((E.NET_AMOUNT)) AS [Net Amount] ")


            If ShowDelivery = "YES" Then
                .Append(" ,J.ACCOUNTNAME AS [Delivery/Process] ")
                .Append(" ,J.GSTIN AS [Delivery At GSTIN] ")
                If Book_Code = "0001-000000033" Then
                    .Append(" ,K.ACCOUNTNAME AS [Factory Name] ")
                    .Append(" ,K.GSTIN AS [Factory GSTIN] ")
                End If
            End If


            .Append(" FROM ")
            .Append(" MstMasterAccount AS C, MSTCITY AS D, TRNINVOICEHEADER AS E,MSTSTATE F ")
            .Append(", MSTCITY AS G ")
            .Append(", MstTransport AS H ")

            If ShowDelivery = "YES" Then
                .Append(", trnInvoiceDetail AS I ")
                .Append(", MstMasterAccount AS J ")

                If Book_Code = "0001-000000033" Then
                    .Append(", MstMasterAccount AS K ")
                    .Append(", TrnGreyDesp AS L ")
                End If
            End If

            .Append(" WHERE 1=1 AND D.STATEID=F.STATEID ")
            .Append(" And  E.DESPATCHCODE=G.CITYCODE ")

            If ShowDelivery = "YES" Then
                .Append(" And  E.BOOKVNO=I.BOOKVNO ")
                If Book_Behaviour = "YARN" Then
                    .Append(" And  I.FACTORYCODE=J.ACCOUNTCODE ")
                Else
                    .Append(" And  I.PROCESSCODE=J.ACCOUNTCODE ")
                End If
                If Book_Code = "0001-000000033" Then
                    .Append(" And  I.challanbookvno=L.BOOKVNO ")
                    .Append(" And  L.FactoryCode=K.ACCOUNTCODE ")
                End If
            End If

            .Append(" And  E.TRANSPORTCODE=H.ID ")
            .Append(" And E.ACCOUNTCODE=C.ACCOUNTCODE And C.CITYCODE=D.CITYCODE ")
            '.Append(" AND E.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")

            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY C.PANNO,E.BOOKVNO,E.ENTRYNO,E.BILLNO,E.BILLDATE, ")
            .Append(" C.ACCOUNTNAME,C.GSTREGTYPE,C.GSTIN,F.GSTCODE,F.STATENAME ")
            .Append(" ,D.cityname ")
            .Append(" ,G.cityname ")
            .Append(" ,E.LRNO ")
            .Append(" ,H.TRANSPORTNAME ")

            .Append(" ,  ((E.TOTAL_PCS)) ")
            .Append(" ,  ((E.TOTAL_WEIGHT))  ")
            .Append(" ,  ((E.TOTAL_MTR_WEIGHT)) ")
            .Append(" ,  (E.GROSS_AMOUNT)  ")
            .Append(" ,  ((E.ROUND_OFF))  ")
            .Append(" ,  ((E.NET_AMOUNT)) ")

            If ShowDelivery = "YES" Then
                .Append(" ,J.ACCOUNTNAME")
                .Append(" ,J.GSTIN")

                If Book_Code = "0001-000000033" Then
                    .Append(" ,K.ACCOUNTNAME")
                    .Append(" ,K.GSTIN")
                End If
            End If
            .Append(" ORDER BY E.BILLDATE,E.ENTRYNO,C.ACCOUNTNAME ")
        End With

        Return _strQuery.ToString
    End Function
    Public Function Get_Bill_No_Summary_Sundry_Display_Qry_2(ByVal Book_Behaviour As String, ByVal Book_Code As String, ByVal Start_Dt As String, ByVal End_Dt As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" E.BOOKVNO AS BOOKVNO, ")
            .Append(" A.SUNPRNNAME, ")
            .Append(" isnull(ROUND(SUM(E.CALCAMOUNT),3),0) AS SUNDRY_AMOUNT ")
            .Append(" FROM MSTBILLSUNDRY A, TRNINVOICESUNDRY E,TRNINVOICEHEADER F, ")
            .Append(" MstMasterAccount G ")
            .Append(" WHERE 1= 1 And A.SUNCODE = E.SUNCODE And E.CALCAMOUNT > 0  ")
            .Append(" And E.BOOKVNO=F.BOOKVNO And F.ACCOUNTCODE=G.ACCOUNTCODE ")
            '.Append(" And E.BOOKCODE='" & Book_Code & "' ")
            .Append(" AND E.BOOKCODE ='" & Book_Code & "' ")
            .Append(" AND E.BILLDATE>='" & Start_Dt & "'  AND E.BILLDATE<='" & End_Dt & "' ")
            .Append(" GROUP BY A.SUNPRNNAME, E.BOOKVNO ")
            .Append(" ORDER BY E.BOOKVNO ")
        End With

        Return _strQuery.ToString
    End Function
    Public Function EntryData_Invoice_Entry_Get_Alter_Form_Query_Header(ByVal strKeyID As String, ByVal Book_Behaviour As String) As String
        strQuery = New StringBuilder
        With strQuery
            If Book_Behaviour = "STORE" Then
                .Append(" SELECT A.*,")
                .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS BDATE,")
                .Append(" FORMAT(LRDATE,'dd/MM/yyyy') AS LDATE,")
                .Append(" CASE WHEN (A.SHIPPINGBILLDATE IS NULL) THEN FORMAT(A.BILLDATE,'dd/MM/yyyy') ELSE FORMAT(A.SHIPPINGBILLDATE,'dd/MM/yyyy') END AS E_DATE, ")
                .Append(" B.BOOKNAME, C.ACCOUNTNAME,D.ACCOUNTNAME AS AGENTNAME,")
                .Append(" E.TRANSPORTNAME,F.CITYNAME AS DESPATCH,G.AC_NAME AS ACOFNAME, ")
                .Append(" H.ACCOUNTNAME AS SALES_PURC_NAME,C.GSTIN AS TINNO,C.GSTREGTYPE  AS VAT_DEALER")
                .Append(" ,FORMAT(SHIPPINGBILLDATE,'yyyy-MM-dd') AS S_SHIPPINGBILLDATE")
                .Append(" ,I.salesmanname AS SALEMANNAME")
                .Append(" ,J.ACCOUNTNAME AS JVACCOUNTNAME")

                .Append(" FROM TRNINVOICEHEADER A  ")
                .Append(" LEFT JOIN MSTBOOK B  ON A.BOOKCODE = B.BOOKCODE  ")
                .Append(" LEFT JOIN MstMasterAccount C ON  A.ACCOUNTCODE = C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstMasterAccount D ON  C.AGENTCODE = D.ACCOUNTCODE  ")
                .Append(" LEFT JOIN MSTTRANSPORT E ON  A.TRANSPORTCODE = E.ID  ")
                .Append(" LEFT JOIN MSTCITY F ON  A.DESPATCHCODE = F.CITYCODE  ")
                .Append(" LEFT JOIN Mst_Acof_Supply G ON  A.ACOFCODE = G.ID  ")
                .Append(" LEFT JOIN  MstMasterAccount H  ON A.OPP_ACCOUNTCODE = H.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstSalesMan I ON  A.VAT47NO = I.salesmancode  ")
                .Append(" LEFT JOIN MstMasterAccount J ON  A.DEC_LETTER_FLAG = J.ACCOUNTCODE ")

                .Append(" WHERE A.BOOKCODE = B.BOOKCODE ")
                .Append(" AND A.BOOKVNO='" & strKeyID & "'")
                .Append(" AND A.ACCOUNTCODE = C.ACCOUNTCODE ")
                .Append(" AND C.AGENTCODE = D.ACCOUNTCODE ")
                .Append(" AND A.TRANSPORTCODE = E.ID ")
                .Append(" AND A.DESPATCHCODE = F.CITYCODE ")
                .Append(" AND A.ACOFCODE = G.ID ")
                .Append(" AND A.OPP_ACCOUNTCODE = H.ACCOUNTCODE ")

            ElseIf Book_Behaviour = "READYMADE" Then
                .Append(" SELECT A.*,")
                .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS BDATE,")
                .Append(" FORMAT(LRDATE,'dd/MM/yyyy') AS LDATE,")
                .Append(" CASE WHEN (A.SHIPPINGBILLDATE IS NULL) THEN FORMAT(A.BILLDATE,'dd/MM/yyyy') ELSE FORMAT(A.SHIPPINGBILLDATE,'dd/MM/yyyy') END AS E_DATE, ")
                .Append(" B.BOOKNAME, C.ACCOUNTNAME,D.ACCOUNTNAME AS AGENTNAME,")
                .Append(" E.TRANSPORTNAME,F.CITYNAME AS DESPATCH,G.AC_NAME AS ACOFNAME, ")
                .Append(" H.ACCOUNTNAME AS SALES_PURC_NAME,C.TINNO  ")
                .Append(" FROM TRNINVOICEHEADER A ,MSTBOOK B ,MstMasterAccount C, ")
                .Append(" MstMasterAccount D,MSTTRANSPORT E,MSTCITY F,Mst_Acof_Supply G, ")
                .Append(" MstMasterAccount H ")
                .Append(" WHERE A.BOOKCODE = B.BOOKCODE ")
                .Append(" AND A.BOOKVNO='" & strKeyID & "'")
                .Append(" AND A.ACCOUNTCODE = C.ACCOUNTCODE ")
                .Append(" AND C.AGENTCODE = D.ACCOUNTCODE ")
                .Append(" AND A.TRANSPORTCODE = E.ID ")
                .Append(" AND A.DESPATCHCODE = F.CITYCODE ")
                .Append(" AND A.ACOFCODE = G.ACOFCODE ")
                .Append(" AND A.OPP_ACCOUNTCODE = H.ACCOUNTCODE ")
            ElseIf Book_Behaviour = "YARN" Then
                .Append(" SELECT A.*,")
                .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS BDATE,")
                .Append(" FORMAT(LRDATE,'dd/MM/yyyy') AS LDATE,")
                .Append(" CASE WHEN (A.SHIPPINGBILLDATE IS NULL) THEN FORMAT(A.BILLDATE,'dd/MM/yyyy') ELSE FORMAT(A.SHIPPINGBILLDATE,'dd/MM/yyyy') END AS E_DATE, ")
                .Append(" B.BOOKNAME, C.ACCOUNTNAME,D.ACCOUNTNAME AS AGENTNAME,")
                .Append(" E.TRANSPORTNAME,F.CITYNAME AS DESPATCH,G.AC_NAME AS ACOFNAME, ")
                .Append(" H.ACCOUNTNAME AS SALES_PURC_NAME,C.TINNO  ")
                .Append(" FROM TRNINVOICEHEADER A ,MSTBOOK B ,MstMasterAccount C, ")
                .Append(" MstMasterAccount D,MSTTRANSPORT E,MSTCITY F,Mst_Acof_Supply G, ")
                .Append(" MstMasterAccount H ")
                .Append(" WHERE A.BOOKCODE = B.BOOKCODE ")
                .Append(" AND A.BOOKVNO='" & strKeyID & "'")
                .Append(" AND A.ACCOUNTCODE = C.ACCOUNTCODE ")
                .Append(" AND A.AGENTCODE = D.ACCOUNTCODE ")
                .Append(" AND A.TRANSPORTCODE = E.ID ")
                .Append(" AND A.DESPATCHCODE = F.CITYCODE ")
                .Append(" AND A.ACOFCODE = G.ACOFCODE ")
                .Append(" AND A.OPP_ACCOUNTCODE = H.ACCOUNTCODE ")
            Else
                .Append(" SELECT A.*,")
                .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS BDATE,")
                .Append(" FORMAT(LRDATE,'dd/MM/yyyy') AS LDATE,")
                .Append(" CASE WHEN (A.SHIPPINGBILLDATE IS NULL) THEN FORMAT(A.BILLDATE,'dd/MM/yyyy') ELSE FORMAT(A.SHIPPINGBILLDATE,'dd/MM/yyyy') END AS E_DATE, ")
                .Append(" B.BOOKNAME, C.ACCOUNTNAME,D.ACCOUNTNAME AS AGENTNAME,")
                .Append(" E.TRANSPORTNAME,F.CITYNAME AS DESPATCH, ")
                .Append(" H.COMPANYNAME AS INS_COMP_NAME, ")
                .Append(" I.ACCOUNTNAME AS SALES_PURC_NAME,C.GSTIN AS TINNO ,G.[AC_NAME] AS ACOFNAME ")
                .Append(" FROM TRNINVOICEHEADER A ,MSTBOOK B ,MstMasterAccount C, ")
                .Append(" MstMasterAccount D,MSTTRANSPORT E,MSTCITY F, ")
                .Append(" MstInsuranceCompany H,MstMasterAccount I,Mst_Acof_Supply G")
                .Append(" WHERE A.BOOKCODE = B.BOOKCODE ")
                .Append(" AND A.BOOKVNO='" & strKeyID & "'")
                .Append(" AND A.INS_COMP_CODE = H.ID ")
                .Append(" AND A.ACCOUNTCODE = C.ACCOUNTCODE ")
                .Append(" AND C.AGENTCODE = D.ACCOUNTCODE ")
                .Append(" AND A.TRANSPORTCODE = E.ID ")
                .Append(" AND A.DESPATCHCODE = F.CITYCODE ")
                .Append(" AND A.ACOFCODE = G.ID ")
                .Append(" AND A.OPP_ACCOUNTCODE = I.ACCOUNTCODE ")

            End If
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Get_Invoice_Alter_Form_Query_Item_Details(ByVal _BookVNo As String, ByVal Book_Behaviour As String) As String
        strQuery = New StringBuilder

        With strQuery
            If Book_Behaviour = "YARN" Then
                .Append(" SELECT A.*, ")
                .Append(" B.COUNTNAME AS ITEMNAME, ")
                .Append(" C.CUTNAME,D.ACCOUNTNAME AS FACTORYNAME ")
                .Append(" FROM TRNINVOICEDETAIL A , ")
                .Append(" MSTYARNCOUNT B , MSTCUT C, ")
                .Append(" MstMasterAccount D ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.ITEMCODE=B.COUNTCODE ")
                .Append(" AND A.CUTCODE=C.CUTCODE ")
                .Append(" AND A.FACTORYCODE=D.ACCOUNTCODE ")
                .Append(" AND A.BOOKVNO='" & _BookVNo & "' ")
                .Append(" ORDER BY SRNO ")
            ElseIf Book_Behaviour = "READYMADE" Then
                .Append(" SELECT A.*, ")
                .Append(" B.ITEMNAME , ")
                .Append(" C.CUTNAME, ")
                .Append(" D.GROUPNAME AS CATEGORYNAME,")
                .Append(" D.GROUPCODE AS CATEGORYCODE, ")
                .Append(" E.SIZENAME ")
                .Append(" FROM TRNINVOICEDETAIL A, ")
                .Append(" MSTSTOREITEM B , MSTCUT C, ")
                .Append(" MstStoreItemGroup D ,MSTSIZE E ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.DESIGNCODE=E.SIZECODE ")
                .Append(" AND A.ITEMCODE=B.ITEMCODE ")
                .Append(" AND A.CUTCODE=C.CUTCODE ")
                .Append(" AND B.ITEMGROUPCODE=D.GROUPCODE ")
                .Append(" AND A.BOOKVNO='" & _BookVNo & "' ")
                .Append(" ORDER BY SRNO ")
            ElseIf Book_Behaviour = "STORE" Then
                .Append(" SELECT A.*, ")
                .Append(" B.ITEMNAME , ")
                .Append(" B.HSNCODE , ")
                .Append(" C.CUTNAME ")
                .Append(" ,D.GROUPNAME AS GROUPNAME")
                .Append(" FROM TRNINVOICEDETAIL A ")
                .Append(" LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE ")
                .Append(" LEFT JOIN  MstCutMaster C  ON A.CUTCODE=C.ID ")
                .Append(" LEFT JOIN MstStoreItemGroup D  ON  B.ITEMGROUPCODE=D.GROUPCODE")
                .Append(" WHERE 1=1 ")
                '.Append(" AND A.ITEMCODE=B.ITEMCODE ")
                '.Append(" AND A.CUTCODE=C.ID ")
                '.Append(" AND B.ITEMGROUPCODE=D.GROUPCODE ")
                .Append(" AND A.BOOKVNO='" & _BookVNo & "'")
                .Append(" ORDER BY SRNO ")
            ElseIf Book_Behaviour = "GENERAL" Then
                .Append(" SELECT A.*, ")
                .Append(" B.ITEMNAME , ")
                .Append(" C.CUTNAME, ")
                .Append(" D.GROUPNAME AS CATEGORYNAME,")
                .Append(" D.GROUPCODE AS CATEGORYCODE ")

                .Append(" FROM TRNINVOICEDETAIL A ")
                .Append(" LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE ")
                .Append(" LEFT JOIN  MstCutMaster C  ON A.CUTCODE=C.ID ")
                .Append(" LEFT JOIN MstStoreItemGroup D  ON  B.ITEMGROUPCODE=D.GROUPCODE")
                .Append(" WHERE 1=1 ")

                '.Append(" FROM TRNINVOICEDETAIL A ,")
                '.Append(" MSTSTOREITEM B , MSTCUT C,MstStoreItemGroup D ")
                '.Append(" WHERE 1=1 ")
                '.Append(" AND A.ITEMCODE=B.ITEMCODE ")
                '.Append(" AND A.CUTCODE=C.CUTCODE ")
                '.Append(" AND B.ITEMGROUPCODE=D.GROUPCODE ")
                .Append(" AND A.BOOKVNO='" & _BookVNo & "'")
                .Append(" ORDER BY SRNO ")
            ElseIf Book_Behaviour = "PROCESSING" Then
                .Append(" SELECT A.*, ")
                .Append(" B.ITEMNAME , ")
                .Append(" C.CUTNAME, ")
                .Append(" D.GROUPNAME AS CATEGORYNAME,")
                .Append(" D.GROUPCODE AS CATEGORYCODE ")
                .Append(" FROM TRNINVOICEDETAIL A ,")
                .Append(" MSTSTOREITEM B , MSTCUT C,MstStoreItemGroup D ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.ITEMCODE=B.ITEMCODE ")
                .Append(" AND A.CUTCODE=C.CUTCODE ")
                .Append(" AND B.ITEMGROUPCODE=D.GROUPCODE ")
                .Append(" AND A.BOOKVNO='" & _BookVNo & "'")
                .Append(" ORDER BY SRNO ")
            Else
                .Append(" SELECT A.*, ")
                .Append(" B.ITENNAME AS ITEMNAME , ")
                .Append(" C.CUTNAME,D.ACCOUNTNAME AS PROCESSNAME ")
                .Append(" FROM TRNINVOICEDETAIL A ,")
                .Append(" MstFabricItem B , MstCutMaster C, ")
                .Append(" MstMasterAccount D ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.ITEMCODE=B.ID")
                .Append(" AND A.CUTCODE=C.ID")
                .Append(" AND A.PROCESSCODE=D.ACCOUNTCODE")
                .Append(" AND A.BOOKVNO='" & _BookVNo & "'")
                .Append(" ORDER BY SRNO ")
            End If
        End With
        Dim StrQry As String = strQuery.ToString
        Return strQuery.ToString
    End Function
    Public Function EntryData_Invoice_Entry_Alter_Form_Query_BillSundry_Details(_BookVNo As String) As String
        Me.strQuery = New StringBuilder()
        Dim stringBuilder As StringBuilder = Me.strQuery
        stringBuilder.Append(" SELECT A.*, ")
        stringBuilder.Append(" B.SUNNAME, ")
        stringBuilder.Append(" A.CALCBY AS CALCBY_ORG, ")
        stringBuilder.Append(" A.CALCON AS CALCON_ORG ")
        stringBuilder.Append(" FROM TRNINVOICESUNDRY A , ")
        stringBuilder.Append(" MSTBILLSUNDRY B ")
        stringBuilder.Append(" WHERE 1=1 ")
        stringBuilder.Append(" AND A.SUNCODE=B.SUNCODE")
        stringBuilder.Append(" AND A.BOOKVNO='" + _BookVNo + "'")
        Dim flag As Boolean = Operators.CompareString(Strings.Mid(_BookVNo, 1, 5), "YT-SL", False) = 0
        If flag Then
            stringBuilder.Append(" AND A.CALCAMOUNT>0 ")
        End If
        stringBuilder.Append(" ORDER BY SRNO ")
        Return Me.strQuery.ToString()
    End Function
    Public Function EntryData_Invoice_Get_Help_Qry(ByVal _BookCode As String, ByVal Book_Behaviour As String) As String
        strQuery = New StringBuilder
        With strQuery
            If Book_Behaviour = "READYMADE" Then
                .Append(" SELECT ")
                .Append(" a.bookvno, ")
                .Append(" a.billno as [Bill No], ")
                .Append(" a.entryno as [Entry No], ")
                .Append(" format(a.billdate,'dd/MM/yy') as [Bill Date], ")
                .Append(" b.accountname as [Party Name], ")
                .Append(" format(c.amount,'0.00') as [Amount], ")
                .Append(" A.LRTHROUGH AS [Person Name], ")
                .Append(" A.FINREMARK AS [Mobile No], ")
                .Append(" A.DEC_LETTER_FLAG AS [Address], ")
                .Append(" C.OFFERENTRYNO AS [BarCode No], ")
                .Append(" D.GROUPNAME AS [Group Category], ")
                .Append(" E.ITEMNAME AS [Item Name] ")
                .Append(" FROM TRNINVOICEHEADER A,MstMasterAccount B, ")
                .Append(" TRNINVOICEDETAIL C, ")
                .Append(" MSTSTOREITEMGROUP D,MSTSTOREITEM E ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
                .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
                .Append(" AND A.BOOKVNO=C.BOOKVNO ")
                .Append(" AND C.CATEGORYCODE=D.GROUPCODE ")
                .Append(" AND C.ITEMCODE=E.ITEMCODE ")
                .Append(" ORDER BY A.ENTRYNO ")
            Else
                .Append(" SELECT a.bookvno, ")
                .Append(" a.billno as [Bill No], ")
                .Append(" a.entryno as [Entry No], ")
                .Append(" format(a.billdate,'dd/MM/yy') as [Bill Date], ")
                .Append(" b.accountname as [Party Name], ")
                .Append(" format(a.net_amount,'0.00') as [Bill Amount] ")
                .Append(" FROM trninvoiceheader a,MstMasterAccount b ")
                .Append(" WHERE 1=1 and a.accountcode=b.accountcode  ")
                .Append(" and a.bookcode='" & _BookCode & "' ")
                .Append(" order by a.billdate,val(a.billno) ")
            End If
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_General_Invoice_Get_Pending_Offer_Query(ByVal Offer_Calc_By As String, ByVal txtAccountCode As String, ByVal txtSupplierCode As String, ByVal Item_Code As String, ByVal Cut_Code As String, ByVal txtBillDate As String) As String
        strQuery = New StringBuilder
        If Offer_Calc_By = "BALE" Then
            With strQuery
                .Append(" SELECT a.bookvno, b.offerno, ")
                .Append(" sum(a.Creditbales)-sum(a.debitBales) AS balance, ")
                .Append(" A.ITEMCODE,A.CUTCODE,b.offerdate ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT a.bookvno, sum(a.pcs_Bales)-sum(a.CANCEL_QTY) as Creditbales,0 as DebitBales, ")
                .Append(" a.itemcode,a.cutcode ")
                .Append(" FROM trnoffer AS a ")
                .Append(" WHERE 1 = 1 and a.pcs_bales>0 ")
                .Append(" AND A.BOOKCODE='0001-000000019' ")
                .Append(" AND A.PARTYCODE='" & txtAccountCode & "'")
                .Append(" AND A.SUPPCODE='" & txtSupplierCode & "'")
                .Append(" AND A.ITEMCODE='" & Item_Code & "'")
                .Append(" AND A.CUTCODE='" & Cut_Code & "'")
                .Append(" AND A.OFFERDATE<='" & txtBillDate & "' ")
                .Append(" AND A.CLEAR<>'YES' ")
                .Append(" GROUP BY a.bookvno,a.itemcode,a.cutcode ")
                .Append(" UNION ALL ")
                .Append(" SELECT a.offerbookvno,0 as CreditBales,sum(a.pcs_bales) as DebitBales, ")
                .Append(" a.itemcode,a.cutcode ")
                .Append(" FROM trnInvoiceDetail a ")
                .Append(" WHERE 1=1  and a.pcs_bales>0 ")
                .Append(" AND A.PARTYCODE='" & txtAccountCode & "'")
                .Append(" AND A.SUPPCODE='" & txtSupplierCode & "'")
                .Append(" AND A.ITEMCODE='" & Item_Code & "'")
                .Append(" AND A.CUTCODE='" & Cut_Code & "'")
                .Append(" GROUP BY a.offerbookvno,a.itemcode,a.cutcode ")
                .Append(" ) ")
                .Append(" AS a,trnoffer as b ")
                .Append(" where 1=1 and a.bookvno=b.bookvno ")
                .Append(" GROUP BY a.bookvno,b.offerno,a.itemcode,a.cutcode,b.offerdate ")
                .Append(" having sum(a.Creditbales)-sum(a.debitBales)>0 ")
                .Append(" order by b.offerdate,b.offerno ")
            End With
        ElseIf Offer_Calc_By = "MTRS" Then
            With strQuery
                .Append(" SELECT a.bookvno, b.offerno, ")
                .Append(" format(sum(a.Creditbales)-sum(a.debitBales),'0.00') AS balance, ")
                .Append(" A.ITEMCODE,A.CUTCODE,b.offerdate ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT a.bookvno, sum(a.MTR_weight)-sum(a.cancel_qty) as Creditbales,0 as DebitBales, ")
                .Append(" a.itemcode,a.cutcode ")
                .Append(" FROM trnoffer AS a ")
                .Append(" WHERE 1 = 1 and a.pcs_bales>0 ")
                .Append(" AND A.BOOKCODE='0001-000000019' ")
                .Append(" AND A.PARTYCODE='" & txtAccountCode & "'")
                .Append(" AND A.SUPPCODE='" & txtSupplierCode & "'")
                .Append(" AND A.ITEMCODE='" & Item_Code & "'")
                .Append(" AND A.CUTCODE='" & Cut_Code & "'")
                .Append(" AND A.OFFERDATE<='" & txtBillDate & "' ")
                .Append(" AND A.CLEAR<>'YES' ")
                .Append(" GROUP BY a.bookvno,a.itemcode,a.cutcode ")
                .Append(" UNION ALL ")
                .Append(" SELECT a.offerbookvno,0 as CreditBales,sum(a.MTR_weight) as DebitBales, ")
                .Append(" a.itemcode,a.cutcode ")
                .Append(" FROM trnInvoiceDetail a ")
                .Append(" WHERE 1=1  and a.pcs_bales>0 ")
                .Append(" AND A.PARTYCODE='" & txtAccountCode & "'")
                .Append(" AND A.SUPPCODE='" & txtSupplierCode & "'")
                .Append(" AND A.ITEMCODE='" & Item_Code & "'")
                .Append(" AND A.CUTCODE='" & Cut_Code & "'")
                .Append(" GROUP BY a.offerbookvno,a.itemcode,a.cutcode ")
                .Append(" ) ")
                .Append(" AS a,trnoffer as b ")
                .Append(" where 1=1 and a.bookvno=b.bookvno ")
                .Append(" GROUP BY a.bookvno,b.offerno,a.itemcode,a.cutcode,b.offerdate ")
                .Append(" having sum(a.Creditbales)-sum(a.debitBales)>0 ")
                .Append(" order by b.offerdate,b.offerno ")
            End With
        End If

        Return strQuery.ToString
    End Function
    Public Function EntryData_Invoice_View_Qry(ByVal View_Filter_Condition As String, ByVal View_Order_By As String, ByVal Book_Behaviour As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.entryno AS [Entry No], ")
            .Append(" a.billno as [Bill No], ")
            .Append(" format(A.billdate,'dd/MM/yyyy')  as [Bill Date], ")
            .Append(" b.accountname as [Party Name], ")
            .Append(" a.total_pcs AS [Pcs], ")
            If Book_Behaviour = "YARN" Then
                .Append(" a.total_weight as [Meters], ")
                .Append(" a.total_mtr_weight as [Weight], ")
            Else
                .Append(" a.total_weight as [Weight], ")
                .Append(" a.total_mtr_weight as [Meters], ")
            End If
            .Append(" a.net_amount as [Net Amount] ")
            .Append(" FROM trninvoiceheader a,MstMasterAccount b ")
            .Append(" WHERE 1=1 ")
            .Append(" AND a.accountcode = b.accountcode ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_Invoice_Entry_Rate_Display(ByVal AccountCode As String, ByVal Item_Code As String, ByVal Cut_Code As String, ByVal BookCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT A.billno as [Bill No], ")
            .Append(" format(a.billdate,'dd/MM/yyyy') as [Bill Date], ")
            .Append(" c.itenname as [Item/Qlty Name], ")
            .Append(" d.CUTNAME as [Cut], ")
            .Append(" a.mtr_weight as [Quantity], ")
            .Append(" a.rate as [Rate], ")
            .Append(" a.rateon as [Rate On],")
            .Append(" b.accountname as [Party Name], ")
            .Append(" e.AC_NAME as [A/c Of Name] ")
            .Append(" from trninvoicedetail a, ")
            .Append(" MstMasterAccount b,mstfabricitem c,MstCutMaster d, ")
            .Append(" Mst_Acof_Supply e,trninvoiceheader f ")
            .Append(" where 1=1 ")
            .Append(" and a.accountcode=b.accountcode ")
            .Append(" and a.accountcode='" & AccountCode & "' ")
            .Append(" and a.itemcode='" & Item_Code & "' ")
            If Cut_Code <> "" Then
                .Append(" and a.cutcode='" & Cut_Code & "' ")
            End If
            .Append(" and a.bookcode='" & BookCode & "' ")
            .Append(" and a.itemcode=c.ID ")
            .Append(" and a.cutcode=d.ID ")
            .Append(" and f.acofcode=e.ID ")
            .Append(" and a.bookvno=f.bookvno ")
            .Append(" ORDER BY a.entryno DESC ")
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_General_Invoice_Show_Grey_Offer(ByVal txtAccountCode As String, ByVal Book_Filter_String As String, ByVal txtBillDate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" select a.bookvno, ")
            .Append(" a.offerNo as [Offer No], ")
            .Append(" format(a.OfferDate,'dd/MM/yy') AS [Offer Date], ")
            .Append(" b.ITENNAME as [Item Name], ")
            .Append(" c.cutname as [Cut], ")
            .Append(" d.Design_Name as [Design No],")
            .Append(" e.SHADE as [Shade No],")
            .Append(" SUM(a.mtr_weight) as [Offer Qty],")
            .Append(" '' as [Adj-Qty], ")
            .Append(" '' as [Bal-Qty], ")
            .Append(" format(a.Rate,'0.00') as [Rate],")
            .Append(" SUBSTRING(lotno,1,1) & lcase(mid(lotno,2,10)) as [Qty Type],")
            .Append(" '' as inv_qty, ")
            .Append(" SUM(a.mtr_Weight) as qty,")
            .Append(" A.ITEMCODE,")
            .Append(" A.CUTCODE,A.LOTNO, ")
            .Append(" '' AS BLANK_QTY,A.DESIGNCODE,A.SHADECODE ")
            .Append(" FROM TRNOFFER AS A, MSTFABRICITEM AS B, MstCutMaster AS C,Mst_Fabric_Design  AS D,Mst_Fabric_Shade E ")
            .Append(" where 1 = 1 ")
            .Append(" AND A.DESIGNCODE=D.Design_code ")
            .Append(" AND A.SHADECODE=E.SHADECODE ")
            .Append(Book_Filter_String)
            .Append(" AND A.ACCOUNTCODE='" & txtAccountCode & "'")
            .Append(" AND A.OFFERDATE<='" & txtBillDate & "' ")
            .Append(" AND A.CLEAR<>'YES' ")
            .Append(" AND A.ITEMCODE = B.ID AND A.CUTCODE = C.ID ")
            .Append(" GROUP BY A.BOOKVNO,A.OFFERNO,A.OFFERDATE,B.ITENNAME,C.CUTNAME, ")
            .Append(" D.Design_Name,E.SHADE,A.RATE,A.LOTNO,A.ITEMCODE,A.CUTCODE, ")
            .Append(" A.DESIGNCODE,A.SHADECODE ")
            .Append(" ORDER BY (A.OFFERNO) ")
        End With
        Return strQuery.ToString
    End Function
    Public Function Yarn_Invoice_Entry_txtBookName_Validated(ByVal _BookCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.ENTRYNO,")
            .Append(" A.BILLNO,")
            .Append(" A.BOOKTRTYPE,")
            .Append(" A.BOOKCODE,")
            .Append(" A.ACCOUNTCODE,")
            .Append(" A.OPP_ACCOUNTCODE,")
            .Append(" A.ACOFCODE,")
            .Append(" A.BILLDATE,")
            .Append(" A.SIDEDAYS,")
            .Append(" A.DESPATCHCODE,")
            .Append(" A.AGENTCODE,")
            .Append(" A.TRANSPORTCODE,")
            .Append(" A.PAYMENTMODE,")
            .Append(" A.HEADER_REMARK,")
            .Append(" A.USERID,")
            .Append(" A.USE_CHALLAN,")
            .Append(" A.LRTHROUGH,")
            .Append(" A.SAMPLETYPE,")
            .Append(" A.INSURED,")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS BDATE, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS LDATE, ")
            .Append(" CASE WHEN (A.SHIPPINGBILLDATE IS NULL) THEN FORMAT(A.BILLDATE,'dd/MM/yyyy') ELSE FORMAT(A.SHIPPINGBILLDATE,'dd/MM/yyyy') END AS E_DATE, ")
            .Append(" B.ACCOUNTNAME,F.ACCOUNTNAME AS AGENTNAME ")
            '.Append(" C.AC_NAME AS ACOFNAME ")
            .Append(" ,D.TRANSPORTNAME,E.CITYNAME AS DESPATCH,B.GSTREGTYPE AS VAT_DEALER ")
            .Append(" ,ISNULL(B.DRLIMIT,0) AS DEBITLIMIT ,ISNULL(B.CRLIMIT,0) AS CREDITLIMIT ")
            .Append(" FROM TRNINVOICEHEADER A, MstMasterAccount B ")
            '.Append("  ,Mst_Acof_Supply C ")
            .Append(" ,MSTTRANSPORT D,MSTCITY E,MstMasterAccount AS F ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND B.AGENTCODE=F.ACCOUNTCODE ")
            '.Append(" AND A.ACOFCODE=C.id ")
            .Append(" AND A.TRANSPORTCODE=D.id ")
            .Append(" AND A.DESPATCHCODE=E.CITYCODE ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_Invoice_Entry_txtBookName_Validated(ByVal _BookCode As String, Optional ByVal _DespatchFrom As String = "") As String

        strQuery = New StringBuilder
        With strQuery

            ' Step 1: Find the top entry 
            .Append(" WITH TopEntry AS ( ")
            .Append("     SELECT TOP 1 ENTRYNO ")
            .Append("     FROM TRNINVOICEHEADER  ")
            .Append("     WHERE 1=1 ")
            .Append("     AND BOOKCODE='" & _BookCode & "'" & " ")
            .Append("     ORDER BY ENTRYNO DESC ")
            .Append(" ) ")

            'Step 2: Join only the required rows 
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_BILLDATE, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS BDATE, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS LDATE, ")
            .Append(" CASE WHEN (A.SHIPPINGBILLDATE IS NULL) THEN FORMAT(A.BILLDATE,'dd/MM/yyyy') ELSE FORMAT(A.SHIPPINGBILLDATE,'dd/MM/yyyy') END AS E_DATE, ")
            .Append(" B.ACCOUNTNAME,F.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" C.AC_NAME AS ACOFNAME ")
            .Append(" ,D.TRANSPORTNAME,E.CITYNAME AS DESPATCH,B.GSTREGTYPE AS VAT_DEALER ")
            .Append(" ,ISNULL(B.DRLIMIT,0) AS DEBITLIMIT ,ISNULL(B.CRLIMIT,0) AS CREDITLIMIT ")

            If _DespatchFrom = "YES" Then
                .Append(" ,G.ACCOUNTNAME AS DESPATCHFROM ")
            Else
                .Append(" ,'' AS DESPATCHFROM ")

            End If
            .Append(" ,H.CITYNAME AS PARTYCITYNAME ")
            .Append(" FROM TRNINVOICEHEADER A ")
            .Append(" LEFT JOIN MstMasterAccount B ON A.ACCOUNTCODE = B.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Acof_Supply C ON A.ACOFCODE = C.id ")
            .Append(" LEFT JOIN MSTTRANSPORT D ON A.TRANSPORTCODE = D.id ")
            .Append(" LEFT JOIN MSTCITY E ON A.DESPATCHCODE = E.CITYCODE ")
            .Append(" LEFT JOIN MstMasterAccount F ON A.AGENTCODE = F.ACCOUNTCODE ")
            If _DespatchFrom = "YES" Then
                .Append(" LEFT JOIN MstMasterAccount AS G ON  A.SMS_SEND_YES_NO=G.ACCOUNTCODE")
            End If
            .Append(" LEFT JOIN MSTCITY H ON B.CITYCODE = H.CITYCODE ")
            .Append(" WHERE 1=1 AND A.ENTRYNO = (SELECT ENTRYNO FROM TopEntry) ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
        End With
        Return strQuery.ToString
    End Function


    Public Function Get_Offer_Query_Job(ByVal Filter_Condition As String, ByVal Book_Coode As String) As String
        Get_Offer_Query_Job = ""

        _strQuery = New StringBuilder

        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
            .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
            .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
            .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
            .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
            .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
            .Append(" '" & Comp_email & "'   AS COMP_EMAIL, ")
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append(" A.ENTRYNO AS OFFERNO,0 AS CASENO,A.BOOKVNO, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_ADVISEDATE, ")
            .Append(" FORMAT(A.YARN_DELV_DATE,'dd/MM/yyyy') AS F_billdate, ")
            .Append(" B.ACCOUNTNAME AS AGENTNAME,C.ACCOUNTNAME AS PARTYNAME,")
            .Append(" A.PARTYOFFERNO, ")
            .Append(" A.DESIGNNO ,A.LOTNO , ")
            .Append(" D.ITENNAME AS ITEMNAME,")
            .Append(" STR(A.REED) +'/'+ STR(A.DENT)  AS ALIES, ")
            .Append(" A.PICK AS PCS,A.REEDSPACE AS RD, ")
            .Append(" A.PICK_RATE  AS PICKRATE,WESTAGE AS CD, ")
            .Append(" A.LENGTH AS RCPTAMOUNT,A.NO_OF_SET AS SIDEDAYS, ")
            .Append(" A.MTR_WEIGHT AS BILLBALANCE, ")
            .Append(" E.SELVEDGE_NAME AS bankname, ")
            .Append(" A.HEADERREMARK AS REMARK ")
            .Append("  ,ISNULL(A.OP10,'') AS USERID ")
            .Append("  ,A.LOOM_TYPE AS LOOMCODE ")
            .Append("  ,A.EXTRA_CHG AS BAL_QTY ")
            .Append("  ,A.MENDING_CHG AS MENDING ")
            .Append("  ,A.AVGWEIGHT AS AVGWT ")
            .Append("  ,A.NO_OF_BEAM AS BALES ")
            .Append("  ,A.MONOGRAM_TYPE AS LABEL_LINE1_1 ")
            .Append("  ,A.AGENTOFFERNO  ")
            .Append("  ,A.DESCR   ")
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")
            .Append(" FROM TRNOFFER A ")
            .Append(" LEFT JOIN MstMasterAccount B ON A.AGENTCODE=B.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstMasterAccount C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTFABRICITEM D ON A.ITEMCODE=D.ID ")
            .Append(" LEFT JOIN Mst_selvedge E  ON A.SELVCODE=E.ID")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BOOKCODE='" & Book_Coode & "' ")
            .Append(Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO ")
        End With

        Get_Offer_Query_Job = _strQuery.ToString

        Return Get_Offer_Query_Job
    End Function

    Public Function Get_Offer_Query_Finish(ByVal Filter_Condition As String, ByVal Book_Coode As String) As String
        Get_Offer_Query_Finish = ""
        Dim _OfferMultyShadeSystem As String = ""
        sqL = "SELECT*FROM MSTBOOK WHERE BOOKCODE='" & Book_Coode & "'"
        sql_connect_slect()
        _OfferMultyShadeSystem = DefaltSoftTable.Rows(0).Item("GREY_STOCK_GD_RCPT_TITLE").ToString




        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append((" '" & Comp_Add1 & "'   AS COMP_ADD1, "))
            .Append((" '" & Comp_Add2 & "'   AS COMP_ADD2, "))
            .Append((" '" & Comp_Add3 & "'   AS COMP_ADD3, "))
            .Append((" '" & Comp_Add4 & "'   AS COMP_ADD4, "))
            .Append((" '" & Comp_Tin & "'   AS COMP_TIN, "))
            .Append((" '" & Comp_Cin & "'   AS COMP_CIN, "))
            .Append((" '" & Comp_Tan & "'   AS COMP_TAN, "))
            .Append((" '" & Comp_Pan & "'   AS COMP_PAN, "))
            .Append((" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, "))
            .Append((" '" & Comp_email & "'   AS COMP_EMAIL, "))
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))

            .Append(" A.*, FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_ADVISEDATE,")
            .Append(" B.ACCOUNTNAME AS PARTYNAME, B.ADDRESS1 +', '+ B.ADDRESS2 +', '+ B.ADDRESS3 AS PARTYADDRESS, B.GSTIN AS ACGSTIN, ")
            .Append(" B.ADDRESS3 AS ADDRESS,")
            .Append(" B.MOBILE AS MOBILENO,")
            .Append(" B.PANNO,")
            .Append(" L.CITYNAME AS PARTYCITYNAME,0 AS PCS,SPACE(25) AS DESIGNNO,")
            .Append(" C.CITYNAME AS DESPATCH,D.AC_NAME AS ACOFNAME, ")
            .Append(" D.ADD1 AS ACOFADDRESS,D.GSTIN AS ACOFTINNO, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME,E.ADDRESS1 +', '+ E.ADDRESS2 +', '+ E.ADDRESS3 AS AGENTADDRESS, ")
            .Append(" E.MOBILE AS SUPPMOBILENO,")
            .Append(" F.CITYNAME AS AGENTCITYNAME, ")
            .Append(" G.ITENNAME AS ITEMNAME, ")
            .Append(" H.CUTNAME AS CUTNAME,SPACE(500) AS REMARK, ")
            .Append(" I.TRANSPORTNAME AS TRANSPORTNAME,")
            .Append(" I.GSTIN AS TRANSPORTGSTIN ,")
            .Append(" I.PHONENO AS SUPPBANKACNO ,")
            .Append(" I.MOBILENO AS PARTYSUPPCODE ,")
            .Append(" ltrim (I.MOBILENO) + ',' + LTRIM (I.PHONENO) AS SUPPHONENO ,")
            .Append(" ltrim (I.MOBILENO) + ',' + LTRIM (I.PHONENO) AS SUPPCASENO ,")
            .Append(" J.Design_Name AS DESIGNNAME, ")
            .Append(" K.SHADE AS SHADENAME,K.SHADE AS SHADENO,0 AS CASENO ")
            .Append(" ,a.PICK AS GST ")
            .Append(" ,a.REEDSPACE AS TAXABLE ")
            .Append(" ,a.WESTAGE AS CGSTAMT ")
            .Append(" ,a.LENGTH AS NETAMOUNT ")
            .Append("  ,A.Process_Net_Rate AS DAY1") 'FRIGHT
            .Append("  ,A.Process_Weight_Range AS DAY2") 'CDPER
            .Append("  ,A.Process_Weight_Rate AS DAY3") 'CDVALUE
            .Append("  ,A.Process_Slab_Weight AS DAY4 ") 'OTHERADD
            .Append("  ,A.Process_Slab_Rate AS DAY5 ") 'OTHERLESS
            .Append("  ,A.YARN_DETAIL AS DEPARTMENTNAME ") 'MULTYSHADEREMARK
            .Append("  ,ISNULL(A.OP10,'') AS USERID ")
            .Append("  ,'' AS LABEL_LINE4_1 ") ' USER NAME
            .Append("  ,B.OP26 AS LABEL_LINE2_1 ") ' MASER REMARK-1
            .Append("  ,B.OP27 AS LABEL_LINE2_2 ") ' MASER REMARK-2
            .Append("  ,B.OP28 AS LABEL_LINE2_3 ") ' MASER REMARK-3
            .Append("  ,B.OP29 AS LABEL_LINE2_4 ") ' MASER REMARK-4
            .Append("  ,B.OP30 AS LABEL_LINE2_5 ") ' MASER REMARK-5
            .Append("  ,B.OP31 AS LABEL_LINE2_6 ") ' MASER REMARK-6
            .Append("  ,B.OP32 AS LABEL_LINE3_1 ") ' MASER REMARK-7
            .Append("  ,A.OP3 AS LABEL_LINE3_2 ") ' OFFER REMARK 1
            .Append("  ,A.OP4 AS LABEL_LINE3_3 ") ' OFFER REMARK 2
            .Append("  ,A.OP5 AS LABEL_LINE3_4 ") ' OFFER REMARK 3
            .Append("  ,B.CD AS DEBIT_OP ") ' MASTER CD
            .Append("  ,B.CDTYPE AS SHORTNARR ") ' MASTER CD TYPE
            .Append("  ,B.RD AS CREDIT_OP ") ' MASTER RD
            .Append("  ,B.RDTYPE  AS LONGNARR ") ' MASTER RD TYPE
            .Append("  ,B.COMME  AS COMMISSION ") ' Master Commession%
            .Append("  ,a.agentaccountcode  AS PRINT_VNO ") ' SHADE TYPE
            .Append("  ,a.PICK_RATE AS PICKRATE ") ' CUTS
            .Append("  ,a.MENDING_CHG AS MENDING ") ' PCS
            .Append("  ,a.EXTRA_CHG AS POSTAGE ") ' EXTRA RATE
            .Append("  ,a.OP6 AS S_RD_ON ") ' PRINT COMPANY INFO
            .Append("  ,a.NO_OF_SET AS GROSSAMOUNT ") ' GROSS RATE
            .Append("  ,''  AS METHOD ") 'TOTAL OUTSTANDING
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")
            .Append(" ,M.RemarkName AS LABEL_LINE1_1 ")
            .Append(" ,a.LENGTH as NETAMOUNT ")

            .Append(" FROM TRNOFFER AS A")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE")
            .Append(" LEFT JOIN MSTCITY AS C ON A.DESPATCHCODE=C.CITYCODE ")
            .Append(" LEFT JOIN Mst_Acof_Supply AS D  ON A.ACOFCODE=D.ID ")
            .Append(" LEFT JOIN MstMasterAccount AS E ON B.AGENTCODE=E.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS F ON E.CITYCODE=F.CITYCODE")
            .Append(" LEFT JOIN MSTFABRICITEM AS G ON A.ITEMCODE=G.ID  ")
            .Append(" LEFT JOIN MstCutMaster AS H  ON A.CUTCODE=H.ID ")
            .Append(" LEFT JOIN MSTTRANSPORT AS I ON A.TRANSPORTCODE=I.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design AS J ON A.DESIGNCODE=J.Design_code ")
            .Append(" LEFT JOIN Mst_Fabric_Shade AS K ON A.SHADECODE=K.ID")
            .Append(" LEFT JOIN MSTCITY AS L  ON B.CITYCODE=L.CITYCODE ")
            .Append(" Left Join MstRemark AS M ON A.SHADECODE=M.RemarkCode ")
            .Append(" WHERE 1=1 ")
            If _OfferMultyShadeSystem = "YES" Then
                .Append("  AND A.weavetype IS NULL  ")
            End If
            .Append(" AND A.BOOKCODE='" & Book_Coode & "' ")
            .Append(Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With
        Get_Offer_Query_Finish = _strQuery.ToString

        Return Get_Offer_Query_Finish
    End Function

    Public Function Get_Denim_Query_Finish(ByVal Filter_Condition As String, ByVal Book_Coode As String) As String
        Get_Denim_Query_Finish = ""

        _strQuery = New StringBuilder

        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append((" '" & Comp_Add1 & "'   AS COMP_ADD1, "))
            .Append((" '" & Comp_Add2 & "'   AS COMP_ADD2, "))
            .Append((" '" & Comp_Add3 & "'   AS COMP_ADD3, "))
            .Append((" '" & Comp_Add4 & "'   AS COMP_ADD4, "))
            .Append((" '" & Comp_Tin & "'   AS COMP_TIN, "))
            .Append((" '" & Comp_Cin & "'   AS COMP_CIN, "))
            .Append((" '" & Comp_Tan & "'   AS COMP_TAN, "))
            .Append((" '" & Comp_Pan & "'   AS COMP_PAN, "))
            .Append((" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, "))
            .Append((" '" & Comp_email & "'   AS COMP_EMAIL, "))
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append(" A.*, FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_ADVISEDATE,")
            .Append(" B.ACCOUNTNAME AS PARTYNAME, B.ADDRESS1 AS PARTYADDRESS,")
            .Append(" L.CITYNAME AS PARTYCITYNAME,0 AS PCS,SPACE(25) AS DESIGNNO,")
            .Append(" C.CITYNAME AS DESPATCH,D.AC_NAME AS ACOFNAME,A.ORDER_MTR AS MTR_WEIGHT, ")
            .Append(" D.ADD1AS ACOFADDRESS,D.GSTIN AS ACOFTINNO, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME,E.ADDRESS1 AS AGENTADDRESS, ")
            .Append(" F.CITYNAME AS AGENTCITYNAME, ")
            .Append(" G.ITENNAME AS ITEMNAME, ")
            .Append(" H.CUTNAME,SPACE(500) AS REMARK, ")
            .Append(" I.TRANSPORTNAME, ")
            .Append(" J.Design_Name AS DESIGNNAME, ")
            .Append(" K.SHADE AS SHADENAME,0 AS CASENO ")
            .Append("  ,ISNULL(A.OP10,'') AS USERID ")
            .Append("  ,''  AS METHOD ") 'TPOTAL OUTSTANDING
            .Append(" FROM TRNDENIMOFFER A,MstMasterAccount B,MSTCITY C,Mst_Acof_Supply D, ")
            .Append(" MstMasterAccount E,MSTCITY F,MSTFABRICITEM G,MstCutMaster H, ")
            .Append(" MSTTRANSPORT I,Mst_Fabric_Design J,Mst_Fabric_Shade K,MSTCITY L ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.DESPATCHCODE=C.CITYCODE ")
            .Append(" AND A.ACOFCODE=D.ID ")
            .Append(" AND B.AGENTCODE=E.ACCOUNTCODE ")
            .Append(" AND E.CITYCODE=F.CITYCODE ")
            .Append(" AND A.ITEMCODE=G.ID ")
            .Append(" AND A.CUTCODE=H.ID ")
            .Append(" AND A.TRANSPORTCODE=I.ID ")
            .Append(" AND A.DESIGNCODE=J.Design_code ")
            .Append(" AND A.SHADECODE=K.ID ")
            .Append(" AND B.CITYCODE=L.CITYCODE ")
            .Append(" AND A.BOOKCODE='" & Book_Coode & "' ")
            .Append(Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With
        Get_Denim_Query_Finish = _strQuery.ToString

        Return Get_Denim_Query_Finish
    End Function

    Public Function Get_Offer_Query_Grey(ByVal Filter_Condition As String, ByVal Book_Coode As String) As String
        Get_Offer_Query_Grey = ""

        _strQuery = New StringBuilder

        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append((" '" & Comp_Add1 & "'   AS COMP_ADD1, "))
            .Append((" '" & Comp_Add2 & "'   AS COMP_ADD2, "))
            .Append((" '" & Comp_Add3 & "'   AS COMP_ADD3, "))
            .Append((" '" & Comp_Add4 & "'   AS COMP_ADD4, "))
            .Append((" '" & Comp_Tin & "'   AS COMP_TIN, "))
            .Append((" '" & Comp_Cin & "'   AS COMP_CIN, "))
            .Append((" '" & Comp_Tan & "'   AS COMP_TAN, "))
            .Append((" '" & Comp_Pan & "'   AS COMP_PAN, "))
            .Append((" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, "))
            .Append((" '" & Comp_email & "'   AS COMP_EMAIL, "))
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append(" A.ENTRYNO, ")
            .Append(" A.BookTrtype, ")
            .Append(" A.BookVno, ")
            .Append(" A.BookCode, ")
            .Append(" A.OfferNo, ")
            .Append(" A.OfferDate, ")
            .Append(" A.PartyOfferNo, ")
            .Append(" A.ACOFCODE, ")
            .Append(" A.AgentOfferNo, ")
            .Append(" A.AccountCode, ")
            .Append(" A.TransportCode, ")
            .Append(" A.DespatchCode, ")
            .Append(" A.HeaderRemark, ")
            .Append(" A.SRNO, ")
            .Append(" A.ItemCode, ")
            .Append(" A.CutCode, ")
            .Append(" A.Descr, ")
            '.Append(" A.DesignCode, ")
            '.Append(" A.ShadeCode, ")
            '.Append(" A.ShadeNo, ")
            .Append(" A.Mtr_Weight, ")
            .Append(" A.Pcs_Bales, ")
            .Append(" A.Rate, ")
            .Append(" A.RDVALUE, ")
            .Append(" A.RDON, ")
            .Append(" A.CDVALUE, ")
            .Append(" A.CDON, ")
            .Append(" A.RowRemark, ")
            .Append(" A.Term1, ")
            .Append(" A.Term2, ")
            .Append(" A.Term3, ")
            .Append(" A.Term4, ")
            .Append(" A.loomtype, ")
            .Append(" A.weavetype, ")
            .Append(" A.AvgWeight, ")
            .Append(" A.PymtDays, ")
            .Append(" A.processcode, ")
            .Append(" A.DelvDays, ")
            .Append(" A.YARN_LOT_NO AS DESIGNNO, ")
            .Append(" A.LOTNO, ")
            .Append(" A.clear, ")
            .Append(" A.cancel_Qty, ")
            .Append(" A.weavetypecode, ")
            .Append(" A.loomtypecode, ")
            .Append(" A.SELVCODE, ")
            '.Append(" A.SelvedgeName, ")
            .Append(" A.despatchtocode, ")
            .Append(" A.clear_Date, ")
            .Append(" A.clear_Remark, ")
            .Append(" A.SalesManCode, ")
            .Append(" A.REED, ")
            .Append(" A.DENT, ")
            .Append(" A.PICK, ")
            .Append(" A.REEDSPACE, ")
            .Append(" A.WESTAGE, ")
            .Append(" A.LENGTH, ")
            .Append(" A.NO_OF_SET, ")
            .Append(" A.NO_OF_BEAM, ")
            .Append(" A.TOTAL_QTY, ")
            .Append(" A.PAYMENT_DAYS, ")
            .Append(" A.YARN_DETAIL, ")
            .Append(" A.AGENTCODE, ")
            .Append(" A.PICK_RATE, ")
            .Append(" A.MENDING_CHG AS PCS, ")
            .Append(" A.EXTRA_CHG, ")
            .Append(" A.YARN_DELV_DATE, ")
            .Append(" A.LOOM_TYPE, ")
            .Append(" A.MONOGRAM_TYPE, ")
            .Append(" A.Gross_Rate, ")
            .Append(" A.Rate_Dis_Per, ")
            .Append(" A.Net_Rate, ")
            .Append(" A.ITEMGROUPCODE, ")
            .Append(" A.Process_Net_Rate, ")
            .Append(" A.Process_Weight_Range, ")
            .Append(" A.Process_Weight_Rate, ")
            .Append(" A.Process_Slab_Weight, ")
            .Append(" A.Process_Slab_Rate, ")
            .Append(" A.agentaccountcode, ")
            .Append(" A.YARN_LOT_NO, ")
            .Append(" A.YARN_SHADE_NO, ")

            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_ADVISEDATE,")
            .Append(" B.ACCOUNTNAME AS PARTYNAME,LTRIM(B.GSTIN) AS ACCOUNTTINNO,")
            .Append(" B.ADDRESS1 +', '+ B.ADDRESS2 AS PARTYADDRESS, B.GSTIN AS ACGSTIN, ")
            .Append(" B.ADDRESS3 AS ADDRESS,")
            .Append(" B.MOBILE AS MOBILENO,")
            .Append(" L.CITYNAME AS PARTYCITYNAME,")
            .Append(" C.CITYNAME AS DESPATCH,D.AC_NAME AS ACOFNAME, ")
            .Append(" D.ADD1 AS ACOFADDRESS,D.GSTIN AS ACOFTINNO, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME,E.ADDRESS1 AS AGENTADDRESS, ")
            .Append(" F.CITYNAME AS AGENTCITYNAME, ")
            .Append(" G.ITENNAME AS ITEMNAME, ")
            .Append(" H.CUTNAME, ")
            .Append(" I.TRANSPORTNAME, ")
            .Append(" J.Design_Name AS DESIGNNAME, ")
            .Append(" K.SHADE AS SHADENAME,0 AS CASENO, ")
            .Append(" M.ACCOUNTNAME AS PROCESSNAME, ")
            .Append(" N.SELVEDGE_NAME AS SELVEDGENAME, ")
            .Append(" O.LOOM_TYPE AS LOOMTYPENAME, ")
            .Append(" A.NO_OF_DESING AS INV_QTY, ")
            .Append(" A.NO_OF_SHADE AS BAL_QTY, ")
            .Append(" A.QTYMTR AS PROX_BOX ")
            '.Append(" ,P.WEAVETYPENAME ")
            .Append(" ,a.PICK AS GST ")
            .Append(" ,a.REEDSPACE AS TAXABLE ")
            .Append(" ,a.WESTAGE AS CGSTAMT ")
            .Append(" ,a.LENGTH AS NETAMOUNT ")
            .Append("  ,ISNULL(A.OP10,'') AS USERID ")
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")

            .Append(" FROM TRNOFFER AS A,MstMasterAccount AS B,MSTCITY AS C,Mst_Acof_Supply AS D, ")
            .Append(" MstMasterAccount AS E,MSTCITY AS F,MSTFABRICITEM AS G,MstCutMaster AS H, ")
            .Append(" MSTTRANSPORT AS I,Mst_Fabric_Design AS J,Mst_Fabric_Shade AS K,MSTCITY AS L, ")
            .Append(" MstMasterAccount AS M,Mst_selvedge AS N,MSTLOOMTYPE AS O ")
            '.Append(" ,MSTWEAVETYPE AS P ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.SELVCODE=N.ID ")
            '.Append(" AND A.WEAVETYPECODE=P.WEAVETYPECODE ")
            .Append(" AND A.LOOMTYPECODE=O.ID ")
            .Append(" AND A.PROCESSCODE=M.ACCOUNTCODE ")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.DESPATCHCODE=C.CITYCODE ")
            .Append(" AND A.ACOFCODE=D.ID ")
            .Append(" AND B.AGENTCODE=E.ACCOUNTCODE ")
            .Append(" AND E.CITYCODE=F.CITYCODE ")
            .Append(" AND A.ITEMCODE=G.ID ")
            .Append(" AND A.CUTCODE=H.ID ")
            .Append(" AND A.TRANSPORTCODE=I.ID ")
            .Append(" AND A.DESIGNCODE=J.Design_code ")
            .Append(" AND A.SHADECODE=K.ID ")
            .Append(" AND B.CITYCODE=L.CITYCODE ")
            .Append(" AND A.BOOKCODE='" & Book_Coode & "' ")
            .Append(Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With

        Get_Offer_Query_Grey = _strQuery.ToString

        Return Get_Offer_Query_Grey
    End Function

    Public Function Get_Offer_Query_Yarn(ByVal Filter_Condition As String, ByVal Book_Coode As String) As String
        Get_Offer_Query_Yarn = ""
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append((" '" & Comp_Add1 & "'   AS COMP_ADD1, "))
            .Append((" '" & Comp_Add2 & "'   AS COMP_ADD2, "))
            .Append((" '" & Comp_Add3 & "'   AS COMP_ADD3, "))
            .Append((" '" & Comp_Add4 & "'   AS COMP_ADD4, "))
            .Append((" '" & Comp_Tin & "'   AS COMP_TIN, "))
            .Append((" '" & Comp_Cin & "'   AS COMP_CIN, "))
            .Append((" '" & Comp_Tan & "'   AS COMP_TAN, "))
            .Append((" '" & Comp_Pan & "'   AS COMP_PAN, "))
            .Append((" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, "))
            .Append((" '" & Comp_email & "'   AS COMP_EMAIL, "))
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append(" A.*,0 AS CASENO, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_ADVISEDATE, ")
            .Append(" B.ACCOUNTNAME AS PARTYNAME, ")
            .Append(" B.ADDRESS1 +', '+ B.ADDRESS2 AS PARTYADDRESS, B.GSTIN AS ACGSTIN, ")
            .Append(" B.ADDRESS3 AS ADDRESS,")
            .Append(" B.MOBILE AS MOBILENO,")
            .Append(" B.PANNO,")
            .Append(" L.CITYNAME AS PARTYCITYNAME, ")
            .Append(" C.CITYNAME AS DESPATCH,D.AC_NAME AS ACOFNAME, ")
            .Append(" D.ADD1 AS ACOFADDRESS,D.GSTIN AS ACOFTINNO, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME,E.ADDRESS1 AS AGENTADDRESS, ")
            .Append(" F.CITYNAME AS AGENTCITYNAME, ")
            .Append(" G.COUNTNAME AS ITEMNAME, ")
            .Append(" I.TRANSPORTNAME, ")
            .Append(" M.ACCOUNTNAME AS PROCESSNAME ")
            .Append(" ,a.PICK AS GST ")
            .Append(" ,a.REEDSPACE AS TAXABLE ")
            .Append(" ,a.WESTAGE AS CGSTAMT ")
            .Append(" ,a.LENGTH AS NETAMOUNT ")
            .Append(" ,N.YARN_SHADE_NAME AS SUPPCODE ")
            .Append(" ,A.PartyOfferNo AS SUPPNAME ")
            .Append(" ,A.YARN_LOT_NO AS H_BILLNO ")
            .Append(" ,O.ACCOUNTNAME AS SUPPLIER_NAME ") ' MILLNAME
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")
            .Append(" ,P.CountName as ITEMGROUPNAME ")
            .Append(" FROM TRNOFFER AS A ")
            .Append(" LEFT JOIN  MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN  MSTCITY AS C  ON A.DESPATCHCODE=C.CITYCODE  ")
            .Append(" LEFT JOIN  Mst_Acof_Supply AS D ON A.ACOFCODE=D.ID ")
            .Append(" LEFT JOIN  MstMasterAccount AS E ON  B.AGENTCODE=E.ACCOUNTCODE")
            .Append(" LEFT JOIN  MSTCITY AS F  ON E.CITYCODE=F.CITYCODE ")
            .Append(" LEFT JOIN  MSTYARNCOUNT AS G ON  A.ITEMCODE=G.COUNTCODE ")
            .Append(" LEFT JOIN  MSTTRANSPORT AS I ON A.TRANSPORTCODE=I.ID ")
            .Append(" LEFT JOIN  MSTCITY AS L ON B.CITYCODE=L.CITYCODE ")
            .Append(" LEFT JOIN  MstMasterAccount AS M ON A.PROCESSCODE=M.ACCOUNTCODE")
            .Append(" LEFT JOIN  MstYarnItemShade AS N ON A.ShadeCode=N.ID ")
            .Append(" LEFT JOIN  MstMasterAccount AS O ON  A.SELVCODE=O.ACCOUNTCODE ")
            .Append(" LEFT JOIN  MstYarnCount AS P ON A.SelvedgeName = P.CountCode ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BOOKCODE='" & Book_Coode & "' ")
            .Append(Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With
        Get_Offer_Query_Yarn = _strQuery.ToString
        Return Get_Offer_Query_Yarn
    End Function
    Public Function Get_Offer_Query_Store(ByVal Filter_Condition As String, ByVal Book_Coode As String) As String
        Get_Offer_Query_Store = ""

        _strQuery = New StringBuilder

        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append((" '" & Comp_Add1 & "'   AS COMP_ADD1, "))
            .Append((" '" & Comp_Add2 & "'   AS COMP_ADD2, "))
            .Append((" '" & Comp_Add3 & "'   AS COMP_ADD3, "))
            .Append((" '" & Comp_Add4 & "'   AS COMP_ADD4, "))
            .Append((" '" & Comp_Tin & "'   AS COMP_TIN, "))
            .Append((" '" & Comp_Cin & "'   AS COMP_CIN, "))
            .Append((" '" & Comp_Tan & "'   AS COMP_TAN, "))
            .Append((" '" & Comp_Pan & "'   AS COMP_PAN, "))
            .Append((" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, "))
            .Append((" '" & Comp_email & "'   AS COMP_EMAIL, "))
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append(" A.*,0 AS CASENO,FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_ADVISEDATE,")
            .Append(" B.ACCOUNTNAME AS PARTYNAME, B.ADDRESS1 AS PARTYADDRESS,B.MOBILE AS MOBILENO,")
            .Append(" L.CITYNAME AS PARTYCITYNAME,N.CUTNAME, ")
            .Append(" C.CITYNAME AS DESPATCH,D.AC_NAME AS ACOFNAME, ")
            .Append(" D.ADD1 AS ACOFADDRESS,D.GSTIN AS ACOFTINNO, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME,E.ADDRESS1 AS AGENTADDRESS, ")
            .Append(" F.CITYNAME AS AGENTCITYNAME, ")
            .Append(" G.ITEMNAME AS ITEMNAME, ")
            .Append(" I.TRANSPORTNAME,M.GROUPNAME  ")
            .Append(" ,a.GROSS_RATE AS GROSSAMOUNT  ")
            .Append(" ,a.WEAVETYPECODE AS LABEL_LINE1_1  ")
            .Append(" ,a.REED AS ONAC  ")
            .Append(" ,a.RATE_DIS_PER AS GR  ")
            .Append(" ,a.NET_RATE AS ALREADYPAID  ")
            .Append(" ,a.LENGTH AS TDS  ")
            .Append(" ,a.DESIGNNO AS LABEL_LINE1_2  ")
            .Append(" ,a.DENT AS INT_PER  ")
            .Append(" ,a.NO_OF_SET AS T_PCS  ")
            .Append(" ,a.LOTNO AS LOOMNO  ")
            .Append(" ,a.PICK AS OTHER1  ")
            .Append(" ,a.NO_OF_BEAM AS S_PCS  ")
            .Append(" ,a.REEDSPACE AS BILL_BALANCE  ")
            .Append(" ,a.WESTAGE AS DUECOMM  ")
            .Append(" ,a.RDVALUE AS ADVAMOUNT  ")
            .Append(" ,a.PAYMENT_DAYS AS LATE_DAYS  ")
            .Append(" ,A.PartyOfferNo  AS PRINT_VNO")
            .Append(" ,A.AgentOfferNo AS PRINT_NARR")
            .Append(" ,O.SizeName AS ASS_NAME ")
            .Append(" ,O.OP1 AS ASS_ACCOUNTNAME ")
            .Append(" ,P.ColorName AS ASS_CODE ")
            .Append(" ,Q.subItemName AS ASS_TYPE ")

            .Append(" FROM TRNOFFER AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS C ON A.DESPATCHCODE=C.CITYCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply AS D ON A.ACOFCODE=D.ID ")
            .Append(" LEFT JOIN MstMasterAccount AS E ON B.AGENTCODE=E.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTCITY AS F ON E.CITYCODE=F.CITYCODE  ")
            .Append(" LEFT JOIN MSTTRANSPORT AS I ON A.TRANSPORTCODE=I.ID ")
            .Append(" LEFT JOIN MSTCITY AS L ON B.CITYCODE=L.CITYCODE  ")
            .Append(" Left JOIN MSTSTOREITEM AS G ON A.ITEMCODE=G.ITEMCODE   ")
            .Append(" LEFT JOIN MSTSTOREITEMGROUP M ON G.ITEMGROUPCODE=M.GROUPCODE ")
            .Append(" Left JOIN MstCutMaster N ON A.CUTCODE=N.ID  ")
            .Append(" Left JOIN MstSize O ON A.DESIGNCODE=O.SizeCode  ")
            .Append(" Left JOIN MstColor P ON A.SELVCODE=P.ColorCode  ")
            .Append(" Left JOIN MstStoreSubItem Q ON A.SHADECODE=Q.subItemCode  ")

            .Append(" WHERE 1=1   ")
            .Append(" AND A.BOOKCODE='" & Book_Coode & "' ")
            .Append(Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With

        Get_Offer_Query_Store = _strQuery.ToString

        Return Get_Offer_Query_Store
    End Function
    Public Function Indent_Printing_Selection_Qry(ByVal Str_Condition As String, ByVal Offer_Book_Category As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            If Offer_Book_Category = "DENIM" Then
                .Append(" SELECT ")
                .Append(" A.OFFERNO + '/' + B.ACCOUNTNAME AS [Offer No/Party Name], ")
                .Append(" A.ENTRYNO AS [Entry No], ")
                .Append(" A.BOOKVNO AS VALUECODE, ")
                .Append(" A.BOOKVNO AS VALUECODE, ")
                .Append(" A.BOOKVNO AS VALUECODE ")
                .Append(" FROM TRNDENIMOFFER AS A,MstMasterAccount AS B ")
                .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
                .Append(Str_Condition)
                .Append(" GROUP BY A.BOOKVNO, A.OFFERNO, B.ACCOUNTNAME, A.ENTRYNO, B.ACCOUNTNAME ")
                .Append(" ORDER BY A.ENTRYNO ")
            Else
                .Append(" SELECT ")

                .Append(" A.OFFERNO + '/' + B.ACCOUNTNAME AS [Offer No/Party Name], ")
                .Append(" A.ENTRYNO AS [Entry No], ")
                .Append(" A.BOOKVNO AS VALUECODE, ")
                .Append(" A.BOOKVNO AS VALUECODE, ")
                .Append(" A.BOOKVNO AS VALUECODE ")
                .Append(" FROM TrnOffer AS A,MstMasterAccount AS B ")
                .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
                .Append(Str_Condition)
                .Append(" GROUP BY A.BOOKVNO, A.OFFERNO, B.ACCOUNTNAME, A.ENTRYNO, B.ACCOUNTNAME ")
                .Append(" ORDER BY A.ENTRYNO ")
            End If
        End With
        Return _strQuery.ToString
    End Function
    Public Function Finish_Stock_Report_Quality_Wise_Net_Total_Summary(Quality_Selected_String As String, Start_Dt As String, End_Dt As String, CalcOp As String, PR_BY_CHL As String) As String


        strQuery = New StringBuilder
        With strQuery

            .Append(" SELECT ")
            .Append(" '" + Comp_Add1 + "'   AS COMP_ADD1, ")
            .Append(" '" + Comp_Add2 + "'   AS COMP_ADD2, ")
            .Append(" '" + Comp_Add3 + "'   AS COMP_ADD3, ")
            .Append(" '" + Comp_Add4 + "'   AS COMP_ADD4, ")
            .Append(" '" + Comp_Tin + "'   AS COMP_TIN, ")
            .Append(" '" + Comp_Tel_no + "'   AS COMP_TEL_NO, ")
            .Append(" '" + Comp_email + "'   AS COMP_EMAIL, ")
            .Append(" Z.ITEMCODE,C.ITENNAME AS ITEMNAME,C.YARN_RATE AS THAN_RATE, ")
            .Append(" (0.0) AS NETAMOUNT, ")

            If PR_BY_CHL = "YES" Then
                .Append(" SUM(Z.INCOMING_MTR_WEIGHT) +SUM(Z.PURCHASE)+SUM(Z.SALES_GR)+SUM(Z.STK_ISSUE_WEIGHT) +SUM(Z.OPENING) AS INCOMING_MTR_WEIGHT, ")
            Else
                .Append(" SUM(Z.INCOMING_MTR_WEIGHT) AS INCOMING_MTR_WEIGHT, ")
            End If

            .Append(" SUM(Z.OUTGOING_MTR_WEIGHT) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" SUM(Z.OPENING) AS OPENING, ")
            .Append(" SUM(Z.PURCHASE) AS PURCHASE, ")
            .Append(" SUM(Z.PURCHASE_GR) AS PURCHASE_GR, ")
            .Append(" SUM(Z.SALES) AS SALES, ")
            .Append(" SUM(Z.SALES_GR) AS SALES_GR, ")

            If PR_BY_CHL = "YES" Then
                .Append(" SUM(Z.PROCESS_MTR_CHALLAN) AS PROCESS_MTR, ")
            Else
                .Append(" SUM(Z.PROCESS_MTR) AS PROCESS_MTR, ")
            End If

            .Append(" SUM(Z.OTHER) AS OTHER, ")
            .Append(" SUM(Z.SEND) AS SEND, ")
            .Append(" SUM(Z.INV_QTY) AS INV_QTY, ")
            .Append(" SUM(Z.STK_ISSUE_WEIGHT) AS STK_ISSUE_WEIGHT, ")

            .Append(" (0.0) AS BALANCE ")
            .Append(" ,D.fabric_GroupName AS GROUPNAME ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" B.ITEMCODE, ")

            If PR_BY_CHL = "YES" Then
                .Append(" 0.00 AS INCOMING_MTR_WEIGHT, ")
            Else
                .Append(" IIF(A.RCPT_ISSUE='IN',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS INCOMING_MTR_WEIGHT, ")

            End If

            .Append(" IIF(A.RCPT_ISSUE='OUT',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" IIF(A.BOOKCODE='0001-000000182',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OPENING, ")
            .Append(" IIF(A.NATURE='PURCHASE',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE, ")
            .Append(" IIF(A.NATURE='PURCHASE G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE_GR, ")
            .Append(" IIF(A.NATURE='SALES',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES, ")
            .Append(" IIF(A.NATURE='SALES G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES_GR, ")
            .Append(" IIF(A.BOOKCATEGORY='VALUE-LOSS',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OTHER, ")
            .Append(" (0.0) AS SEND, ")
            .Append(" IIF(A.BOOKCODE='0001-000000052' OR A.BOOKCODE='0001-000000608',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PROCESS_MTR, ")
            .Append(" IIF(A.BOOKCODE='0001-000000760',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS INV_QTY ")
            .Append(" ,IIF(A.BOOKCODE='0001-000000219' AND B.RDON='INVOICE',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS STK_ISSUE_WEIGHT ")
            .Append(" ,(0.0) AS PROCESS_MTR_CHALLAN ")
            .Append(" FROM MSTBOOK A,TRNINVOICEDETAIL B ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE=B.BOOKCODE ")
            .Append(" AND A.USE_FOR_FINISH_STOCK='YES' ")

            If CalcOp = "YES" Then
                .Append(String.Concat(New String() {" And B.BILLDATE >='", Start_Dt, "' AND B.BILLDATE<='", End_Dt, "' "}))
            Else
                .Append(" AND B.BILLDATE<='" + End_Dt + "' ")
            End If
            .Append(" GROUP BY B.ITEMCODE,A.RCPT_ISSUE,A.BOOKCODE,A.NATURE,A.BOOKCATEGORY ,B.RDON")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" (0.0) AS INCOMING_MTR_WEIGHT, ")
            .Append(" SUM(A.GMTR) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" (0.0) AS OPENING, ")
            .Append(" (0.0) AS PURCHASE, ")
            .Append(" (0.0) AS PURCHASE_GR, ")
            .Append(" (0.0) AS SALES, ")
            .Append(" (0.0) AS SALES_GR, ")
            .Append(" (0.0) AS OTHER, ")
            .Append(" SUM(A.GMTR) AS SEND, ")
            .Append(" (0.0) AS PROCESS_MTR, ")
            .Append(" (0.0) AS INV_QTY ")
            .Append(" ,(0.0) AS STK_ISSUE_WEIGHT ")
            .Append(" ,(0.0) AS PROCESS_MTR_CHALLAN ")
            .Append(" FROM TRNGREYDESP A,MSTBOOK B ")
            .Append(" WHERE 1=1 AND A.BOOKCODE=B.BOOKCODE ")
            .Append(" AND A.BOOKCODE='0001-000000135' ")
            .Append(" AND B.USE_FOR_FINISH_STOCK='YES' ")

            If CalcOp = "YES" Then
                .Append(String.Concat(New String() {" AND A.CHALLANDATE>='", Start_Dt, "' AND A.CHALLANDATE<='", End_Dt, "' "}))
            Else
                .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
            End If
            .Append(" GROUP BY A.FABRIC_ITEMCODE ")



            If PR_BY_CHL = "YES" Then
                .Append(" UNION ALL ")
                .Append(" SELECT  ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE,  ")
                .Append(" SUM(A.PMTR) AS INCOMING_MTR_WEIGHT,  ")
                .Append(" (0.00) AS OUTGOING_MTR_WEIGHT,  ")
                .Append(" (0.00) AS OPENING,  ")
                .Append(" (0.00) AS PURCHASE,  ")
                .Append(" (0.00) AS PURCHASE_GR,  ")
                .Append(" (0.00) AS SALES,  ")
                .Append(" (0.00) AS SALES_GR,  ")
                .Append(" (0.00) AS OTHER,  ")
                .Append(" (0.00) AS SEND,  ")
                .Append(" (0.00) AS PROCESS_MTR,  ")
                .Append(" (0.00) AS INV_QTY, ")
                .Append(" (0.00) AS STK_ISSUE_WEIGHT, ")
                .Append(" SUM(A.PMTR) AS PROCESS_MTR_CHALLAN ")
                .Append(" FROM TRNFINISHRCPT A ")
                .Append(" ,MSTBOOK B  ")
                .Append(" WHERE 1=1  ")
                .Append(" AND A.BOOKCODE=B.BOOKCODE  ")
                .Append(" AND A.BOOKCODE<>'0001-000000116' ")
                .Append(" AND B.BOOKCATEGORY='PROCESS-CHALLAN' ")

                If CalcOp = "YES" Then
                    .Append(String.Concat(New String() {" AND A.CHALLANDATE>='", Start_Dt, "' AND A.CHALLANDATE<='", End_Dt, "' "}))
                Else
                    .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
                End If
                .Append(" GROUP BY A.FABRIC_ITEMCODE ,A.BOOKCODE ")
            End If

            If CalcOp = "YES" Then
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" Z.ITEMCODE AS ITEMCODE, ")
                .Append(" ROUND(SUM(Z.INCOMING_MTR_WEIGHT),3)- ROUND(SUM(Z.OUTGOING_MTR_WEIGHT),3) AS INCOMING_MTR_WEIGHT, ")
                .Append(" (0.0) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" ROUND(SUM(Z.INCOMING_MTR_WEIGHT),3)- ROUND(SUM(Z.OUTGOING_MTR_WEIGHT),3) AS OPENING, ")
                .Append(" (0.0) AS PURCHASE, ")
                .Append(" (0.0) AS PURCHASE_GR, ")
                .Append(" (0.0) AS SALES, ")
                .Append(" (0.0) AS SALES_GR, ")
                .Append(" (0.0) AS OTHER, ")
                .Append(" (0.0) AS SEND, ")
                .Append(" (0.0) AS PROCESS_MTR, ")
                .Append(" (0.0) AS INV_QTY ")
                .Append(" ,(0.0) AS STK_ISSUE_WEIGHT ")
                .Append(" ,(0.0) AS PROCESS_MTR_CHALLAN ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" Z.ITEMCODE,C.ITENNAME AS ITEMNAME,C.YARN_RATE AS THAN_RATE, ")
                .Append(" (0.0) AS NETAMOUNT, ")
                .Append(" SUM(Z.INCOMING_MTR_WEIGHT) AS INCOMING_MTR_WEIGHT, ")
                .Append(" SUM(Z.OUTGOING_MTR_WEIGHT) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" SUM(Z.OPENING) AS OPENING, ")
                .Append(" SUM(Z.PURCHASE) AS PURCHASE, ")
                .Append(" SUM(Z.PURCHASE_GR) AS PURCHASE_GR, ")
                .Append(" SUM(Z.SALES) AS SALES, ")
                .Append(" SUM(Z.SALES_GR) AS SALES_GR, ")
                .Append(" SUM(Z.PROCESS_MTR) AS PROCESS_MTR, ")
                .Append(" SUM(Z.OTHER) AS OTHER, ")
                .Append(" SUM(Z.SEND) AS SEND, ")
                .Append(" (0.0) AS BALANCE ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" B.ITEMCODE, ")
                .Append(" IIF(A.RCPT_ISSUE='IN',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS INCOMING_MTR_WEIGHT, ")
                .Append(" IIF(A.RCPT_ISSUE='OUT',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" IIF(A.BOOKCODE='0001-000000182',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OPENING, ")
                .Append(" IIF(A.NATURE='PURCHASE',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE, ")
                .Append(" IIF(A.NATURE='PURCHASE G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE_GR, ")
                .Append(" IIF(A.NATURE='SALES',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES, ")
                .Append(" IIF(A.NATURE='SALES G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES_GR, ")
                .Append(" IIF(A.BOOKCATEGORY='VALUE-LOSS',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OTHER, ")
                .Append(" (0.0) AS SEND, ")
                .Append(" IIF(A.NATURE='JOB-PAID',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PROCESS_MTR ")
                .Append(" FROM MSTBOOK A,TRNINVOICEDETAIL B ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BOOKCODE=B.BOOKCODE ")
                .Append(" AND A.USE_FOR_FINISH_STOCK='YES' ")
                .Append(" AND B.BILLDATE<'" + Start_Dt + "' ")
                .Append(" GROUP BY B.ITEMCODE,A.RCPT_ISSUE,A.BOOKCODE,A.NATURE,A.BOOKCATEGORY ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" (0.0) AS INCOMING_MTR_WEIGHT, ")
                .Append(" SUM(A.GMTR) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" (0.0) AS OPENING, ")
                .Append(" (0.0) AS PURCHASE, ")
                .Append(" (0.0) AS PURCHASE_GR, ")
                .Append(" (0.0) AS SALES, ")
                .Append(" (0.0) AS SALES_GR, ")
                .Append(" (0.0) AS OTHER, ")
                .Append(" SUM(A.GMTR) AS SEND, ")
                .Append(" (0.0) AS PROCESS_MTR ")
                .Append(" FROM TRNGREYDESP A,MSTBOOK B ")
                .Append(" WHERE 1=1 AND A.BOOKCODE=B.BOOKCODE ")
                .Append(" AND A.BOOKCODE='0001-000000135' ")
                .Append(" AND B.USE_FOR_FINISH_STOCK='YES' ")
                .Append(" AND A.CHALLANDATE<'" + Start_Dt + "' ")
                .Append(" GROUP BY A.FABRIC_ITEMCODE ")
                .Append(" ) ")
                .Append(" AS Z,MSTFABRICITEM C ")
                .Append(" WHERE 1=1 ")
                .Append(" AND Z.ITEMCODE=C.ID ")
                .Append(Quality_Selected_String)
                .Append(" GROUP BY Z.ITEMCODE,C.ITENNAME,C.YARN_RATE ")
                .Append(" ) AS Z ")
                .Append(" GROUP BY Z.ITEMCODE ")
            End If


#Region "SEND DPR PROCESS HOUSE "
            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE,")
            .Append(" 0.00 AS INCOMING_MTR_WEIGHT, ")
            .Append("  SUM(GMTR) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" 0.00 AS OPENING, ")
            .Append(" 0.00 AS PURCHASE, ")
            .Append(" 0.00 AS PURCHASE_GR, ")
            .Append(" 0.00 AS SALES, ")
            .Append(" 0.00 AS SALES_GR, ")
            .Append(" 0.00 AS OTHER, ")
            .Append(" SUM(GMTR) AS SEND, ")
            .Append(" 0.00 AS PROCESS_MTR, ")
            .Append(" 0.00 AS INV_QTY, ")
            .Append(" 0.00 AS STK_ISSUE_WEIGHT, ")
            .Append(" 0.00 AS PROCESS_MTR_CHALLAN ")

            .Append(" FROM TrnGreyDesp AS A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BOOKCODE='0001-000000135' ")
            .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
            .Append(" GROUP BY A.FABRIC_ITEMCODE ")
#End Region

#Region "DPR PROCESS HOUSE REC "

            .Append(" UNION ALL ") ' 

            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" SUM(PMTR) AS INCOMING_MTR_WEIGHT, ")
            .Append(" 0.00  AS OUTGOING_MTR_WEIGHT, ")
            .Append(" 0.00 AS OPENING, ")
            .Append(" 0.00 AS PURCHASE, ")
            .Append(" 0.00 AS PURCHASE_GR, ")
            .Append(" 0.00 AS SALES, ")
            .Append(" 0.00 AS SALES_GR, ")
            .Append(" 0.00 AS OTHER, ")
            .Append(" 0.00 AS SEND, ")
            .Append(" SUM(PMTR)  AS PROCESS_MTR, ")
            .Append(" 0.00 AS INV_QTY, ")
            .Append(" 0.00 AS STK_ISSUE_WEIGHT, ")
            .Append(" 0.00 AS PROCESS_MTR_CHALLAN ")
            .Append(" FROM TRNFINISHRCPT AS A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BOOKCODE='0001-000000116' ")
            .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
            .Append(" GROUP BY A.FABRIC_ITEMCODE ")

#End Region

            .Append(" ) ")
            .Append(" AS Z  ")
            .Append(" LEFT JOIN MSTFABRICITEM C ON   Z.ITEMCODE=C.ID")
            .Append(" LEFT JOIN MstFabricGroup as D ON C.GROUPID=D.ID ")
            .Append(" WHERE 1=1 ")
            .Append(Quality_Selected_String)
            .Append(" GROUP BY Z.ITEMCODE,C.ITENNAME,C.YARN_RATE ")
            .Append(" ,D.fabric_GroupName")
            .Append(" ORDER BY C.ITENNAME ")

        End With

        Return strQuery.ToString()
    End Function
    Public Function Finish_Stock_Report_HSNCODE_Total_Summary(Quality_Selected_String As String, Start_Dt As String, End_Dt As String, CalcOp As String, PR_BY_CHL As String) As String

        strQuery = New StringBuilder
        With strQuery


            .Append(" SELECT ")
            .Append(" '" + Comp_Add1 + "'   AS COMP_ADD1, ")
            .Append(" '" + Comp_Add2 + "'   AS COMP_ADD2, ")
            .Append(" '" + Comp_Add3 + "'   AS COMP_ADD3, ")
            .Append(" '" + Comp_Add4 + "'   AS COMP_ADD4, ")
            .Append(" '" + Comp_Tin + "'   AS COMP_TIN, ")
            .Append(" '" + Comp_Tel_no + "'   AS COMP_TEL_NO, ")
            .Append(" '" + Comp_email + "'   AS COMP_EMAIL, ")
            .Append(" C.HSNCODE AS ITEMNAME,0 AS THAN_RATE, ")
            .Append(" (0.0) AS NETAMOUNT, ")
            If PR_BY_CHL = "YES" Then
                .Append(" SUM(Z.INCOMING_MTR_WEIGHT) +SUM(Z.PURCHASE)+SUM(Z.SALES_GR)+SUM(Z.STK_ISSUE_WEIGHT) +SUM(Z.OPENING) AS INCOMING_MTR_WEIGHT, ")
            Else
                .Append(" SUM(Z.INCOMING_MTR_WEIGHT) AS INCOMING_MTR_WEIGHT, ")
            End If
            .Append(" SUM(Z.OUTGOING_MTR_WEIGHT) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" SUM(Z.OPENING) AS OPENING, ")
            .Append(" SUM(Z.PURCHASE) AS PURCHASE, ")
            .Append(" SUM(Z.PURCHASE_GR) AS PURCHASE_GR, ")
            .Append(" SUM(Z.SALES) AS SALES, ")
            .Append(" SUM(Z.SALES_GR) AS SALES_GR, ")
            '.Append(" SUM(Z.PROCESS_MTR) AS PROCESS_MTR, ")

            If PR_BY_CHL = "YES" Then
                .Append(" SUM(Z.PROCESS_MTR_CHALLAN) AS PROCESS_MTR, ")
            Else
                .Append(" SUM(Z.PROCESS_MTR) AS PROCESS_MTR, ")
            End If

            .Append(" SUM(Z.OTHER) AS OTHER, ")
            .Append(" SUM(Z.SEND) AS SEND, ")
            .Append(" SUM(Z.INV_QTY) AS INV_QTY, ")
            .Append(" SUM(Z.STK_ISSUE_WEIGHT) AS STK_ISSUE_WEIGHT, ")
            .Append(" (0.0) AS BALANCE ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" B.ITEMCODE, ")

            If PR_BY_CHL = "YES" Then
                .Append(" 0.00 AS INCOMING_MTR_WEIGHT, ")
            Else
                .Append(" IIF(A.RCPT_ISSUE='IN',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS INCOMING_MTR_WEIGHT, ")
            End If

            .Append(" IIF(A.RCPT_ISSUE='OUT',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" IIF(A.BOOKCODE='0001-000000182',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OPENING, ")
            .Append(" IIF(A.NATURE='PURCHASE',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE, ")
            .Append(" IIF(A.NATURE='PURCHASE G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE_GR, ")
            .Append(" IIF(A.NATURE='SALES',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES, ")
            .Append(" IIF(A.NATURE='SALES G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES_GR, ")
            .Append(" IIF(A.BOOKCATEGORY='VALUE-LOSS',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OTHER, ")
            .Append(" (0.0) AS SEND, ")
            .Append(" IIF(A.BOOKCODE='0001-000000052' OR A.BOOKCODE='0001-000000608',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PROCESS_MTR, ")
            .Append(" IIF(A.BOOKCODE='0001-000000760',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS INV_QTY ")
            .Append(" ,IIF(A.BOOKCODE='0001-000000219',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS STK_ISSUE_WEIGHT ")
            .Append(" ,(0.0) AS PROCESS_MTR_CHALLAN ")
            .Append(" FROM MSTBOOK A,TRNINVOICEDETAIL B ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE=B.BOOKCODE ")
            .Append(" AND A.USE_FOR_FINISH_STOCK='YES' ")

            Dim flag As Boolean = Operators.CompareString(CalcOp, "YES", False) = 0
            If flag Then
                .Append(String.Concat(New String() {" AND B.BILLDATE>='", Start_Dt, "' AND B.BILLDATE<='", End_Dt, "' "}))
            Else
                .Append(" AND B.BILLDATE<='" + End_Dt + "' ")
            End If
            .Append(" GROUP BY B.ITEMCODE,A.RCPT_ISSUE,A.BOOKCODE,A.NATURE,A.BOOKCATEGORY ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" (0.0) AS INCOMING_MTR_WEIGHT, ")
            .Append(" SUM(A.GMTR) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" (0.0) AS OPENING, ")
            .Append(" (0.0) AS PURCHASE, ")
            .Append(" (0.0) AS PURCHASE_GR, ")
            .Append(" (0.0) AS SALES, ")
            .Append(" (0.0) AS SALES_GR, ")
            .Append(" (0.0) AS OTHER, ")
            .Append(" SUM(A.GMTR) AS SEND, ")
            .Append(" (0.0) AS PROCESS_MTR, ")
            .Append(" (0.0) AS INV_QTY ")
            .Append(" ,(0.0) AS STK_ISSUE_WEIGHT ")
            .Append(" ,(0.0) AS PROCESS_MTR_CHALLAN ")
            .Append(" FROM TRNGREYDESP A,MSTBOOK B ")
            .Append(" WHERE 1=1 AND A.BOOKCODE=B.BOOKCODE ")
            .Append(" AND A.BOOKCODE='0001-000000135' ")
            .Append(" AND B.USE_FOR_FINISH_STOCK='YES' ")
            flag = (Operators.CompareString(CalcOp, "YES", False) = 0)
            If flag Then
                .Append(String.Concat(New String() {" AND A.CHALLANDATE>='", Start_Dt, "' AND A.CHALLANDATE<='", End_Dt, "' "}))
            Else
                .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
            End If
            .Append(" GROUP BY A.FABRIC_ITEMCODE ")



            If PR_BY_CHL = "YES" Then
                .Append(" UNION ALL ")
                .Append(" SELECT  ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE,  ")
                .Append(" SUM(A.PMTR)  AS INCOMING_MTR_WEIGHT,  ")
                .Append(" (0.0) AS OUTGOING_MTR_WEIGHT,  ")
                .Append(" (0.0) AS OPENING,  ")
                .Append(" (0.0) AS PURCHASE,  ")
                .Append(" (0.0) AS PURCHASE_GR,  ")
                .Append(" (0.0) AS SALES,  ")
                .Append(" (0.0) AS SALES_GR,  ")
                .Append(" (0.0) AS OTHER,  ")
                .Append(" (0.0) AS SEND,  ")
                .Append(" (0.0) AS PROCESS_MTR,  ")
                .Append(" (0.0) AS INV_QTY, ")
                .Append(" (0.0) AS STK_ISSUE_WEIGHT, ")
                .Append(" SUM(A.PMTR) AS PROCESS_MTR_CHALLAN ")
                .Append(" FROM TRNFINISHRCPT A ")
                .Append(" ,MSTBOOK B  ")
                .Append(" WHERE 1=1  ")
                .Append(" AND A.BOOKCODE=B.BOOKCODE  ")
                .Append(" AND A.BOOKCODE<>'0001-000000116' ")
                .Append(" AND B.BOOKCATEGORY='PROCESS-CHALLAN' ")

                If CalcOp = "YES" Then
                    .Append(String.Concat(New String() {" AND A.CHALLANDATE>='", Start_Dt, "' AND A.CHALLANDATE<='", End_Dt, "' "}))
                Else
                    .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
                End If
                .Append(" GROUP BY A.FABRIC_ITEMCODE ,A.BOOKCODE ")
            End If



            flag = (Operators.CompareString(CalcOp, "YES", False) = 0)
            If flag Then
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" Z.ITEMCODE AS ITEMCODE, ")
                .Append(" ROUND(SUM(Z.INCOMING_MTR_WEIGHT),3)- ROUND(SUM(Z.OUTGOING_MTR_WEIGHT),3) AS INCOMING_MTR_WEIGHT, ")
                .Append(" (0.0) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" ROUND(SUM(Z.INCOMING_MTR_WEIGHT),3)- ROUND(SUM(Z.OUTGOING_MTR_WEIGHT),3) AS OPENING, ")
                .Append(" (0.0) AS PURCHASE, ")
                .Append(" (0.0) AS PURCHASE_GR, ")
                .Append(" (0.0) AS SALES, ")
                .Append(" (0.0) AS SALES_GR, ")
                .Append(" (0.0) AS OTHER, ")
                .Append(" (0.0) AS SEND, ")
                .Append(" (0.0) AS PROCESS_MTR, ")
                .Append(" (0.0) AS INV_QTY ")
                .Append(" ,(0.0) AS STK_ISSUE_WEIGHT ")
                .Append(" ,(0.0) AS PROCESS_MTR_CHALLAN ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" Z.ITEMCODE,C.ITENNAME AS ITEMNAME,C.YARN_RATE AS THAN_RATE, ")
                .Append(" (0.0) AS NETAMOUNT, ")
                .Append(" SUM(Z.INCOMING_MTR_WEIGHT) AS INCOMING_MTR_WEIGHT, ")
                .Append(" SUM(Z.OUTGOING_MTR_WEIGHT) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" SUM(Z.OPENING) AS OPENING, ")
                .Append(" SUM(Z.PURCHASE) AS PURCHASE, ")
                .Append(" SUM(Z.PURCHASE_GR) AS PURCHASE_GR, ")
                .Append(" SUM(Z.SALES) AS SALES, ")
                .Append(" SUM(Z.SALES_GR) AS SALES_GR, ")
                .Append(" SUM(Z.PROCESS_MTR) AS PROCESS_MTR, ")
                .Append(" SUM(Z.OTHER) AS OTHER, ")
                .Append(" SUM(Z.SEND) AS SEND, ")
                .Append(" (0.0) AS BALANCE ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" B.ITEMCODE, ")
                .Append(" IIF(A.RCPT_ISSUE='IN',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS INCOMING_MTR_WEIGHT, ")
                .Append(" IIF(A.RCPT_ISSUE='OUT',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" IIF(A.BOOKCODE='0001-000000182',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OPENING, ")
                .Append(" IIF(A.NATURE='PURCHASE',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE, ")
                .Append(" IIF(A.NATURE='PURCHASE G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PURCHASE_GR, ")
                .Append(" IIF(A.NATURE='SALES',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES, ")
                .Append(" IIF(A.NATURE='SALES G.R.',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS SALES_GR, ")
                .Append(" IIF(A.BOOKCATEGORY='VALUE-LOSS',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS OTHER, ")
                .Append(" (0.0) AS SEND, ")
                .Append(" IIF(A.NATURE='JOB-PAID',ROUND(SUM(B.MTR_WEIGHT),3),(0.0)) AS PROCESS_MTR ")
                .Append(" FROM MSTBOOK A,TRNINVOICEDETAIL B ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BOOKCODE=B.BOOKCODE ")
                .Append(" AND A.USE_FOR_FINISH_STOCK='YES' ")
                .Append(" AND B.BILLDATE<'" + Start_Dt + "' ")
                .Append(" GROUP BY B.ITEMCODE,A.RCPT_ISSUE,A.BOOKCODE,A.NATURE,A.BOOKCATEGORY ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
                .Append(" (0.0) AS INCOMING_MTR_WEIGHT, ")
                .Append(" SUM(A.GMTR) AS OUTGOING_MTR_WEIGHT, ")
                .Append(" (0.0) AS OPENING, ")
                .Append(" (0.0) AS PURCHASE, ")
                .Append(" (0.0) AS PURCHASE_GR, ")
                .Append(" (0.0) AS SALES, ")
                .Append(" (0.0) AS SALES_GR, ")
                .Append(" (0.0) AS OTHER, ")
                .Append(" SUM(A.GMTR) AS SEND, ")
                .Append(" (0.0) AS PROCESS_MTR ")
                .Append(" FROM TRNGREYDESP A,MSTBOOK B ")
                .Append(" WHERE 1=1 AND A.BOOKCODE=B.BOOKCODE ")
                .Append(" AND A.BOOKCODE='0001-000000135' ")
                .Append(" AND B.USE_FOR_FINISH_STOCK='YES' ")
                .Append(" AND A.CHALLANDATE<'" + Start_Dt + "' ")
                .Append(" GROUP BY A.FABRIC_ITEMCODE ")
                .Append(" ) ")
                .Append(" AS Z,MSTFABRICITEM C ")
                .Append(" WHERE 1=1 ")
                .Append(" AND Z.ITEMCODE=C.ID ")
                .Append(Quality_Selected_String)
                .Append(" GROUP BY Z.ITEMCODE,C.ITENNAME,C.YARN_RATE ")
                '.Append(" ORDER BY C.ITENNAME ")
                .Append(" ) AS Z ")
                .Append(" GROUP BY Z.ITEMCODE ")
            End If


#Region "SEND DPR PROCESS HOUSE "
            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE,")
            .Append(" 0.00 AS INCOMING_MTR_WEIGHT, ")
            .Append("  SUM(GMTR) AS OUTGOING_MTR_WEIGHT, ")
            .Append(" 0.00 AS OPENING, ")
            .Append(" 0.00 AS PURCHASE, ")
            .Append(" 0.00 AS PURCHASE_GR, ")
            .Append(" 0.00 AS SALES, ")
            .Append(" 0.00 AS SALES_GR, ")
            .Append(" 0.00 AS OTHER, ")
            .Append(" SUM(GMTR) AS SEND, ")
            .Append(" 0.00 AS PROCESS_MTR, ")
            .Append(" 0.00 AS INV_QTY, ")
            .Append(" 0.00 AS STK_ISSUE_WEIGHT, ")
            .Append(" 0.00 AS PROCESS_MTR_CHALLAN ")

            .Append(" FROM TrnGreyDesp AS A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BOOKCODE='0001-000000135' ")
            .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
            .Append(" GROUP BY A.FABRIC_ITEMCODE ")
#End Region

#Region "DPR PROCESS HOUSE REC "

            .Append(" UNION ALL ") ' 

            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE AS ITEMCODE, ")
            .Append(" SUM(PMTR) AS INCOMING_MTR_WEIGHT, ")
            .Append(" 0.00  AS OUTGOING_MTR_WEIGHT, ")
            .Append(" 0.00 AS OPENING, ")
            .Append(" 0.00 AS PURCHASE, ")
            .Append(" 0.00 AS PURCHASE_GR, ")
            .Append(" 0.00 AS SALES, ")
            .Append(" 0.00 AS SALES_GR, ")
            .Append(" 0.00 AS OTHER, ")
            .Append(" 0.00 AS SEND, ")
            .Append(" SUM(PMTR)  AS PROCESS_MTR, ")
            .Append(" 0.00 AS INV_QTY, ")
            .Append(" 0.00 AS STK_ISSUE_WEIGHT, ")
            .Append(" 0.00 AS PROCESS_MTR_CHALLAN ")
            .Append(" FROM TRNFINISHRCPT AS A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BOOKCODE='0001-000000116' ")
            .Append(" AND A.CHALLANDATE<='" + End_Dt + "' ")
            .Append(" GROUP BY A.FABRIC_ITEMCODE ")

#End Region



            .Append(" ) ")
            .Append(" AS Z,MSTFABRICITEM C ")
            .Append(" WHERE 1=1 ")
            .Append(" AND Z.ITEMCODE=C.ID ")
            .Append(Quality_Selected_String)
            .Append(" GROUP BY C.HSNCODE ")
            .Append(" ORDER BY C.HSNCODE ")
        End With

        Return strQuery.ToString()
    End Function
    Public Function EntryData_AlterQueryFinish_Stock_Transfer_Entry(ByVal _BookCode As String, ByVal strKeyID As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" B.ACCOUNTNAME AS WDRL_NAME,E.ITENNAME AS ITEMNAME,M.CUTNAME, ")
            .Append(" I.ACCOUNTNAME AS DESP_NAME,J.TRANSPORTNAME AS TRANSPORTNAME ,K.Design_Name AS DESIGNNAME,L.SHADE AS SHADENAME")
            .Append(" FROM TRNINVOICEDETAIL A,MstMasterAccount B, ")
            .Append(" MstFabricItem E,MstMasterAccount I ,MstTransport J,Mst_Fabric_Design K, Mst_Fabric_Shade L ,MstCutMaster M ")
            .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.DESPATCHCODE=I.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE=E.id ")
            .Append(" AND A.TRANSPORTCODE=J.id ")
            .Append(" AND A.DesignCode=K.Design_code ")
            .Append(" AND A.ShadeCode=L.id ")
            .Append(" AND A.CUTCODE=M.id ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & "  ")
            .Append(" AND A.BOOKVNO='" & strKeyID & "'" & "  ")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return strQuery.ToString

    End Function
    Public Function EntryData_FINISH_Stock_Transfer_Entry_Btn_Add_Mdify_Delete_Click_Code_Qry(ByVal Org_Finish_Rcpt_Tbl_Name As String, ByVal Txt_Dt As String, ByVal _BookCode As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 A.ENTRYNO, ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS F_CHALLANDATE ")
            .Append(" FROM " & Org_Finish_Rcpt_Tbl_Name & "  AS A ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.BILLDATE>='" & Txt_Dt & "' ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" ORDER BY A.BOOKVNO DESC ")
        End With
        Return _strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Stock_Transfer_Entry_Get_View_Query(ByVal _BookCode As String, ByVal PROCESS_SHRINKAGE_CALC_BY As String, ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT A.ENTRYNO AS [Entry No], ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS [Entry Date], ")
            .Append(" B.ACCOUNTNAME AS [Wdrl From],E.ITENNAME AS [Item Name], ")
            .Append(" I.ACCOUNTNAME AS [Delivered To],A.MTR_WEIGHT AS [Weight] ")
            .Append(" FROM TRNINVOICEDETAIL A,MstMasterAccount B, ")
            .Append(" MstFabricItem E,MstMasterAccount I ")
            .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.DESPATCHCODE=I.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE=E.ID ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            '.Append(View_Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.SRNO ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Stock_Transfer(ByVal _BookCode As String, ByVal PROCESS_SHRINKAGE_CALC_BY As String, ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT A.ENTRYNO AS [Entry No], ")
            .Append(" FORMAT(A.BILLDATE,'dd/MM/yyyy') AS [Entry Date], ")
            .Append(" B.ACCOUNTNAME AS [Wdrl From],E.CountName AS [Item Name], ")
            .Append(" I.ACCOUNTNAME AS [Delivered To],A.MTR_WEIGHT AS [Weight] ")
            .Append(" FROM TRNINVOICEDETAIL A,MstMasterAccount B, ")
            .Append(" MstYarnCount E,MstMasterAccount I ")
            .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.DESPATCHCODE=I.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE=E.CountCode ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            '.Append(View_Filter_Condition)
            .Append(" ORDER BY A.ENTRYNO,A.BILLDATE,A.SRNO ")
        End With
        Return strQuery.ToString
    End Function
    Public Function Get_Beam_No_Selection_Qry_From_TrnGreyChallan(StrCon As String) As String
        _strQuery = New StringBuilder()
        Dim stringBuilder As StringBuilder = _strQuery
        stringBuilder.Append(" SELECT ")
        stringBuilder.Append(" A.BEAMNO AS [Beam No], ")
        stringBuilder.Append(" '' AS [Remark], ")
        stringBuilder.Append(" A.BEAMNO AS VALUECODE, ")
        stringBuilder.Append(" A.BEAMNO AS VALUECODE, ")
        stringBuilder.Append(" A.BEAMNO AS VALUECODE ")
        stringBuilder.Append(" FROM TRNGREYDESP A ")
        stringBuilder.Append(" WHERE 1=1 ")
        stringBuilder.Append(StrCon)
        stringBuilder.Append(" GROUP BY A.BEAMNO ")
        stringBuilder.Append(" ORDER BY (A.BEAMNO) ")
        Return _strQuery.ToString()
    End Function
    Public Function Grey_Challan_Register_Factory_BeamNo_Qlty_Net_Total_Summary(BookName As String, Avg_Weight As String, Book_Code_Filter_Condition As String, Filter_Condition_Date_Vno As String, Factory_Filter_String As String, BeamNo_Filter_String As String) As String
        _strQuery = New StringBuilder()
        Dim stringBuilder As StringBuilder = _strQuery
        stringBuilder.Append(" SELECT ")
        stringBuilder.Append(" '" + Comp_Add1 + "'   AS COMP_ADD1, ")
        stringBuilder.Append(" '" + Comp_Add2 + "'   AS COMP_ADD2, ")
        stringBuilder.Append(" '" + Comp_Add3 + "'   AS COMP_ADD3, ")
        stringBuilder.Append(" '" + Comp_Add4 + "'   AS COMP_ADD4, ")
        stringBuilder.Append(" '" + Comp_Tin + "'   AS COMP_TIN, ")
        stringBuilder.Append(" '" + Comp_Tel_no + "'   AS COMP_TEL_NO, ")
        stringBuilder.Append(" '" + Comp_email + "'   AS COMP_EMAIL, ")
        stringBuilder.Append(" '" + (BookName) + "'   AS BOOKNAME, ")
        stringBuilder.Append(" COUNT(A.PIECENO) AS PCS,SUM(A.GMTR) AS GMTR,A.BEAMNO, ")
        Dim flag As Boolean = Operators.CompareString(Avg_Weight, "YES", False) = 0
        If flag Then
            stringBuilder.Append(" SUM(A.WEIGHT) AS WEIGHT, ")
            stringBuilder.Append(" ROUND(SUM(A.WEIGHT)/SUM(A.GMTR),4) AS AVGWT, ")
        Else
            stringBuilder.Append(" 0 AS WEIGHT, ")
            stringBuilder.Append(" 0 AS AVGWT, ")
        End If
        stringBuilder.Append(" ROUND(SUM(A.GMTR*A.PICK),3)/ROUND(SUM(A.GMTR),3) AS PICK, ")
        stringBuilder.Append(" C.ACCOUNTNAME,B.ITENNAME AS ITEMNAME ")
        stringBuilder.Append(" FROM TRNGREYDESP A,MstFabricItem B,MstMasterAccount C ")
        stringBuilder.Append(" WHERE 1=1 ")
        stringBuilder.Append(" AND A.BOOKCODE= '" & Book_Code_Filter_Condition & "' ")
        stringBuilder.Append(Filter_Condition_Date_Vno)
        stringBuilder.Append(Factory_Filter_String)
        stringBuilder.Append(BeamNo_Filter_String)
        stringBuilder.Append(" AND A.FACTORYCODE=C.ACCOUNTCODE ")
        stringBuilder.Append(" AND A.FABRIC_ITEMCODE=B.ID ")
        stringBuilder.Append(" GROUP BY C.ACCOUNTNAME,A.BEAMNO,B.ITENNAME ")
        stringBuilder.Append(" ORDER BY C.ACCOUNTNAME,(A.BEAMNO),B.ITENNAME ")
        Return _strQuery.ToString()
    End Function
    Public Function EntryData_AlterQueryFabricRateContract(ByVal strKeyID As String, ByVal ListType As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" TrnRateContract.*,FORMAT(TrnRateContract.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, ")

            If ListType = "FINISH FABRIC" Then
                .Append(" MstFabricItem.ItenName AS ITEMNAME, ")
            Else
                .Append(" B.IteMName AS ITEMNAME, ")
            End If

            .Append(" MstMasterAccount.ACCOUNTNAME ")
            .Append(" ,C.CUTNAME ")
            .Append(" FROM ")
            .Append(" TrnRateContract ")
            If ListType = "FINISH FABRIC" Then
                .Append(" LEFT JOIN MSTFABRICITEM ON TrnRateContract.ITEMCODE=MSTFABRICITEM.ID  ")
            Else
                .Append(" LEFT JOIN MstStoreItem as B ON TrnRateContract.ITEMCODE=B.ItemCode  ")
            End If
            .Append(" Left JOIN MstMasterAccount ON TrnRateContract.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE  ")
            .Append(" Left JOIN MstCutMaster C ON  TrnRateContract.agentaccountcode=C.ID  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND TrnRateContract.BOOKVNO='" & strKeyID & "'")
            If ListType = "FINISH FABRIC" Then
                .Append(" ORDER BY MstFabricItem.ItenName ")
            Else
                .Append(" ORDER BY B.IteMName  ")
            End If
        End With
        Return strQuery.ToString

    End Function

    Public Function EntryData_AlterQueryFabricRateContract_Process(ByVal strKeyID As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" TrnRateContract.*,FORMAT(TrnRateContract.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, ")
            .Append(" FORMAT(TrnRateContract.DATE_TO,'dd/MM/yyyy') as DATETO, ")
            .Append(" MstFabricItem.ItenName AS ITEMNAME, ")
            .Append(" MstMasterAccount.ACCOUNTNAME ")
            .Append(" FROM ")
            .Append(" TrnRateContract,MSTFABRICITEM,MstMasterAccount ")
            .Append(" WHERE 1=1 ")
            .Append(" AND TrnRateContract.ITEMCODE=MSTFABRICITEM.ID ")
            .Append(" AND TrnRateContract.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" AND TrnRateContract.BOOKVNO='" & strKeyID & "'")
            .Append(" ORDER BY TrnRateContract.SRNO ")
        End With
        Return strQuery.ToString

    End Function

    Public Function EntryData_AlterQueryFabricRateContract_JOB(ByVal strKeyID As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" A.*,FORMAT(A.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, ")
            .Append(" FORMAT(A.DATE_TO,'dd/MM/yyyy') as DATETO, ")
            .Append(" B.ItenName AS ITEMNAME, ")
            .Append(" C.ACCOUNTNAME ")
            .Append(" ,D.TRANSPORTNAME ")
            .Append(" ,E.CITYNAME ")
            .Append(" ,F.AC_NAME ")
            .Append(" ,G.CUTNAME ")
            .Append(" ,H.Design_Name AS DESIGNNAME ")
            .Append(" ,I.SHADE as SHADENAME ")
            .Append(" ,J.SELVEDGE_NAME as SELVNAME")
            .Append(" FROM ")
            .Append(" TrnRateContract AS A,MSTFABRICITEM AS B,MstMasterAccount AS C ")
            .Append(" , MstTransport as D ")
            .Append(" , MstCity as E ")
            .Append(" , Mst_Acof_Supply as F ")
            .Append(" , MstCutMaster as G ")
            .Append(" , Mst_Fabric_Design as H ")
            .Append(" , Mst_Fabric_Shade as I ")
            .Append(" , Mst_selvedge as J ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ITEMCODE=B.ID ")
            .Append(" AND A.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" AND A.OP4=D.ID ")
            .Append(" AND A.OP5= E.CITYCODE")
            .Append(" AND A.OP6=F.ID ")
            .Append(" AND A.OP7=G.ID ")
            .Append(" AND A.OP8=H.Design_code ")
            .Append(" AND A.OP9=I.ID ")
            .Append(" AND A.OP10= J.ID")
            .Append(" AND A.BOOKVNO='" & strKeyID & "'")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return strQuery.ToString

    End Function





    Public Function EntryData_ViewQueryFabricRateContract(ByVal View_Filter_Condition As String, ByVal View_Order_By As String, ByVal View_Type As String) As String

        If View_Type = "SUMMERY" Then
            strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" TrnRateContract.BookVno, ")
                .Append(" TrnRateContract.ENTRYNO as [Entry No], ")
                .Append(" MstMasterAccount.accountname as [Account Name], ")
                .Append(" FORMAT(TrnRateContract.OfferDate,'dd/MM/yyyy') AS [Eff-Date], ")
                .Append(" TrnRateContract.HEADERREMARK AS Remark ")

                .Append(" FROM TrnRateContract ")
                .Append(" LEFT JOIN MstFabricItem ON TrnRateContract.ITEMCODE=MSTFABRICITEM.ID ")
                .Append(" LEFT JOIN MstMasterAccount ON TrnRateContract.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE")
                .Append(" LEFT JOIN MstStoreItem as B ON TrnRateContract.ITEMCODE=B.ItemCode  ")
                .Append(" Left JOIN MstCutMaster C ON  TrnRateContract.agentaccountcode=C.ID  ")
                .Append(" WHERE 1=1 ")
                .Append(View_Filter_Condition)
                .Append(" GROUP BY ")
                .Append(" TrnRateContract.BookVno, ")
                .Append(" TrnRateContract.ENTRYNO, ")
                .Append(" MstMasterAccount.accountname, ")
                .Append(" TrnRateContract.OfferDate, ")
                .Append(" TrnRateContract.HEADERREMARK ")
                .Append(View_Order_By)
            End With
        Else

            strQuery = New StringBuilder
            With strQuery
                .Append(" SELECT ")
                .Append(" TrnRateContract.BookVno, ")
                .Append(" TrnRateContract.ENTRYNO as [Entry No], ")
                .Append(" MstMasterAccount.accountname as [Account Name], ")
                .Append(" FORMAT(TrnRateContract.OfferDate,'dd/MM/yyyy') AS [Eff-Date], ")
                .Append(" TrnRateContract.SRNO as [SrNo], ")
                .Append(" IIF (TrnRateContract.OP2='GENERAL ITEM', B.ItemName, MstFabricItem.IteNName) as [Item Name],")
                .Append(" C.CutName as Type, ")
                .Append(" TrnRateContract.Than_Rate as [Than Rate], ")
                .Append(" TrnRateContract.Lump_Rate as [Lump Rate], ")
                .Append(" TrnRateContract.Tl_Cut_Rate as [Cut Rate], ")
                .Append(" TrnRateContract.Right_Cut_Rate as [R-Cut Rate], ")
                .Append(" TrnRateContract.Grey_Rate as [Grey Rate] ")
                .Append(" FROM TrnRateContract ")
                .Append(" LEFT JOIN MstFabricItem ON TrnRateContract.ITEMCODE=MSTFABRICITEM.ID ")
                .Append(" LEFT JOIN MstMasterAccount ON TrnRateContract.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE")
                .Append(" LEFT JOIN MstStoreItem as B ON TrnRateContract.ITEMCODE=B.ItemCode  ")
                .Append(" Left JOIN MstCutMaster C ON  TrnRateContract.agentaccountcode=C.ID  ")
                .Append(" WHERE 1=1 ")
                .Append(View_Filter_Condition)
                .Append(View_Order_By)
            End With
        End If


        Return strQuery.ToString

    End Function
#End Region
#Region "Rate List Report Query"
    Public Function Get_Rpt_Rate_List_Printing_Qry(ByVal Book_Code As String, ByVal Filter_Condition_No As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
            .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
            .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
            .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
            .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
            .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
            .Append(" '" & Comp_email & "'   AS COMP_EMAIL, ")
            .Append(" A.THAN_RATE AS THAN_MTR,A.LUMP_RATE AS LUMP_MTR, A.TL_CUT_RATE AS TLRATE,A.RIGHT_CUT_RATE AS RIGHTCUT,A.GREY_RATE AS GREY_RATE,")
            .Append(" IIF (A.OP2='GENERAL ITEM', F.ItemName, B.IteNName)  AS ITEMNAME ")
            .Append(" ,C.ACCOUNTNAME,E.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" D.FABRIC_GROUPNAME AS GROUPNAME,B.NOOFSHADE AS DENT3, ")
            .Append(" B.FABRICTYP AS FD_PD,B.WIDTH,A.Process_Weight_Range AS AVGWT,A.DESCR, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_BILLDATE,A.TERM1,A.TERM2,A.TERM3,A.TERM4 ")
            .Append(" ,A.Process_Net_Rate AS SAFARIRATE ")
            .Append(" ,A.RDVALUE ") 'COMBORATE
            .Append(" ,ROW_NUMBER() Over (Order by BOOKVNO) As SRNO ")
            .Append(" ,G.CUTNAME ")
            .Append(" ,A.ROWREMARK AS REMARK ")
            .Append(" FROM TRNRATECONTRACT A ")
            .Append(" LEFT JOIN MSTFABRICITEM B on  A.ITEMCODE=B.ID  ")
            .Append(" LEFT JOIN MstMasterAccount C on  A.ACCOUNTCODE=C.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTFABRICGROUP D ON B.GROUPID=D.ID  ")
            .Append(" LEFT JOIN MstMasterAccount E ON C.AGENTCODE=E.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MstStoreItem as F ON A.ITEMCODE=F.ItemCode  ")
            .Append(" Left JOIN MstCutMaster G ON  A.agentaccountcode=G.ID  ")
            .Append(" WHERE 1=1 AND A.BOOKCODE='" & Book_Code & "' ")
            '.Append(" AND A.ITEMCODE=B.ID AND A.ACCOUNTCODE=C.ACCOUNTCODE ")
            '.Append(" AND B.GROUPID=D.ID ")
            '.Append(" AND C.AGENTCODE=E.ACCOUNTCODE ")
            .Append(Filter_Condition_No)
            .Append(" ORDER BY A.ENTRYNO, IIF (A.OP2='GENERAL ITEM', F.ItemName, B.IteNName) ")
        End With
        Dim RptQry As String = _strQuery.ToString
        Return _strQuery.ToString
    End Function
#End Region
    Public Function EntryData_AlterQuery_Gate_Pass(ByVal strKeyID As String, ByVal Book_Code As String) As String
        strQuery = New StringBuilder
        With strQuery
            If Book_Code = "0001-000000237" Then  'TEXTURISE
                .Append(" SELECT ")
                .Append(" TrnGatePass.*, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_GPDATE, ")
                .Append(" MstYarnCount.CountName AS ITEMNAME,A.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" MstMasterAccount.ACCOUNTNAME,MSTTRANSPORT.TRANSPORTNAME ")
                .Append(" FROM TrnGatePass,MSTYARNCOUNT,MstMasterAccount,MSTTRANSPORT,MstMasterAccount A ")
                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.ITEMCODE=MSTYARNCOUNT.COUNTCODE ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.BOOKVNO='" & strKeyID & "'")
                .Append(" ORDER BY TrnGatePass.SRNO ")
            ElseIf Book_Code = "0001-000000320" Then  'FINISH BY INVOICE
                .Append(" SELECT ")
                .Append(" TrnGatePass.*, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_GPDATE, ")
                .Append(" Msttransport.transportName AS ITEMNAME,A.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" MstMasterAccount.ACCOUNTNAME,B.TRANSPORTNAME ")
                .Append(" FROM TrnGatePass,MSTTRANSPORT,MstMasterAccount,MSTTRANSPORT B,MstMasterAccount A ")
                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.ITEMCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=B.ID ")
                .Append(" AND TrnGatePass.BOOKVNO='" & strKeyID & "'")
                .Append(" ORDER BY TrnGatePass.SRNO ")
            ElseIf Book_Code = "0001-000000236" Then  ' yarn gate pass
                .Append(" SELECT ")
                .Append(" TrnGatePass.*, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_GPDATE, ")
                .Append(" Msttransport.transportName AS ITEMNAME,A.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" MstMasterAccount.ACCOUNTNAME,B.TRANSPORTNAME ")
                .Append(" FROM TrnGatePass,MSTTRANSPORT,MstMasterAccount,MSTTRANSPORT B,MstMasterAccount A ")
                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.ITEMCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=B.ID ")
                .Append(" AND TrnGatePass.BOOKVNO='" & strKeyID & "'")
                .Append(" ORDER BY TrnGatePass.SRNO ")


            Else
                .Append(" SELECT ")
                .Append(" TrnGatePass.*, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_GPDATE, ")
                .Append(" MstFabricItem.IteNName AS ITEMNAME,A.ACCOUNTNAME AS PROCESSNAME, ")
                .Append(" MstMasterAccount.ACCOUNTNAME,MSTTRANSPORT.TRANSPORTNAME ")
                .Append(" FROM TrnGatePass,MSTFABRICITEM,MstMasterAccount,MSTTRANSPORT,MstMasterAccount A ")
                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.ITEMCODE=MSTFABRICITEM.ID ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.BOOKVNO='" & strKeyID & "'")
                .Append(" ORDER BY TrnGatePass.SRNO ")
            End If
        End With
        Return strQuery.ToString

    End Function

    Public Function EntryData_FinishInvoice_Get_Pending_Offer_Query(Offer_Calc_By As String, AccountCode As String, SupplierCode As String, ItemCode As String, CutCode As String, BillDate As String) As String
        Me.strQuery = New StringBuilder()
        Dim flag As Boolean = Operators.CompareString(Offer_Calc_By, "BALE", False) = 0
        If flag Then
            Dim stringBuilder As StringBuilder = Me.strQuery
            stringBuilder.Append(" SELECT a.bookvno, b.offerno, ")
            stringBuilder.Append(" sum(a.Creditbales)-sum(a.debitBales) AS balance, ")
            stringBuilder.Append(" A.ITEMCODE,A.CUTCODE,b.offerdate ")
            stringBuilder.Append(" FROM ")
            stringBuilder.Append(" ( ")
            stringBuilder.Append(" SELECT a.bookvno, sum(a.pcs_Bales)-sum(a.CANCEL_QTY) as Creditbales,0 as DebitBales, ")
            stringBuilder.Append(" a.itemcode,a.cutcode ")
            stringBuilder.Append(" FROM trnoffer AS a ")
            stringBuilder.Append(" WHERE 1 = 1 and a.pcs_bales>0 ")
            stringBuilder.Append(" AND A.BOOKCODE='0001-000000019' ")
            stringBuilder.Append(" AND A.PARTYCODE='" + AccountCode + "'")
            stringBuilder.Append(" AND A.SUPPCODE='" + SupplierCode + "'")
            stringBuilder.Append(" AND A.ITEMCODE='" + ItemCode + "'")
            stringBuilder.Append(" AND A.CUTCODE='" + CutCode + "'")
            stringBuilder.Append(" AND A.OFFERDATE<='" + BillDate + "' ")
            stringBuilder.Append(" AND A.CLEAR<>'YES' ")
            stringBuilder.Append(" GROUP BY a.bookvno,a.itemcode,a.cutcode ")
            stringBuilder.Append(" UNION ALL ")
            stringBuilder.Append(" SELECT a.offerbookvno,0 as CreditBales,sum(a.pcs_bales) as DebitBales, ")
            stringBuilder.Append(" a.itemcode,a.cutcode ")
            stringBuilder.Append(" FROM trnInvoiceDetail a ")
            stringBuilder.Append(" WHERE 1=1  and a.pcs_bales>0 ")
            stringBuilder.Append(" AND A.PARTYCODE='" + AccountCode + "'")
            stringBuilder.Append(" AND A.SUPPCODE='" + SupplierCode + "'")
            stringBuilder.Append(" AND A.ITEMCODE='" + ItemCode + "'")
            stringBuilder.Append(" AND A.CUTCODE='" + CutCode + "'")
            stringBuilder.Append(" GROUP BY a.offerbookvno,a.itemcode,a.cutcode ")
            stringBuilder.Append(" ) ")
            stringBuilder.Append(" AS a,trnoffer as b ")
            stringBuilder.Append(" WHERE 1=1 and a.bookvno=b.bookvno ")
            stringBuilder.Append(" GROUP BY a.bookvno,b.offerno,a.itemcode,a.cutcode,b.offerdate ")
            stringBuilder.Append(" HAVING sum(a.Creditbales)-sum(a.debitBales)>0 ")
            stringBuilder.Append(" ORDER BY b.offerdate,b.offerno ")
        Else
            flag = (Operators.CompareString(Offer_Calc_By, "MTRS", False) = 0)
            If flag Then
                Dim stringBuilder2 As StringBuilder = Me.strQuery
                stringBuilder2.Append(" SELECT a.bookvno, b.offerno, ")
                stringBuilder2.Append(" FORMAT(sum(a.Creditbales)-sum(a.debitBales),'0.00') AS balance, ")
                stringBuilder2.Append(" A.ITEMCODE,A.CUTCODE,b.offerdate ")
                stringBuilder2.Append(" FROM ")
                stringBuilder2.Append(" ( ")
                stringBuilder2.Append(" SELECT a.bookvno, sum(a.MTR_weight)-sum(a.cancel_qty) as Creditbales,0 as DebitBales, ")
                stringBuilder2.Append(" a.itemcode,a.cutcode ")
                stringBuilder2.Append(" FROM trnoffer AS a ")
                stringBuilder2.Append(" WHERE 1 = 1 and a.pcs_bales>0 ")
                stringBuilder2.Append(" AND A.BOOKCODE='0001-000000019' ")
                stringBuilder2.Append(" AND A.PARTYCODE='" + AccountCode + "'")
                stringBuilder2.Append(" AND A.SUPPCODE='" + SupplierCode + "'")
                stringBuilder2.Append(" AND A.ITEMCODE='" + ItemCode + "'")
                stringBuilder2.Append(" AND A.CUTCODE='" + CutCode + "'")
                stringBuilder2.Append(" AND A.OFFERDATE<='" + BillDate + "' ")
                stringBuilder2.Append(" AND A.CLEAR<>'YES' ")
                stringBuilder2.Append(" GROUP BY a.bookvno,a.itemcode,a.cutcode ")
                stringBuilder2.Append(" UNION ALL ")
                stringBuilder2.Append(" SELECT a.offerbookvno,0 as CreditBales,sum(a.MTR_weight) as DebitBales, ")
                stringBuilder2.Append(" a.itemcode,a.cutcode ")
                stringBuilder2.Append(" FROM trnInvoiceDetail a ")
                stringBuilder2.Append(" WHERE 1=1  and a.pcs_bales>0 ")
                stringBuilder2.Append(" AND A.PARTYCODE='" + AccountCode + "'")
                stringBuilder2.Append(" AND A.SUPPCODE='" + SupplierCode + "'")
                stringBuilder2.Append(" AND A.ITEMCODE='" + ItemCode + "'")
                stringBuilder2.Append(" AND A.CUTCODE='" + CutCode + "'")
                stringBuilder2.Append(" GROUP BY a.offerbookvno,a.itemcode,a.cutcode ")
                stringBuilder2.Append(" ) ")
                stringBuilder2.Append(" AS a,trnoffer as b ")
                stringBuilder2.Append(" WHERE 1=1 and a.bookvno=b.bookvno ")
                stringBuilder2.Append(" GROUP BY a.bookvno,b.offerno,a.itemcode,a.cutcode,b.offerdate ")
                stringBuilder2.Append(" HAVING sum(a.Creditbales)-sum(a.debitBales)>0 ")
                stringBuilder2.Append(" ORDER BY b.offerdate,b.offerno ")
            End If
        End If
        Return Me.strQuery.ToString()
    End Function

    Public Function Gate_Pass_Printing_Selection_Qry(ByVal Str_Condition) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.ENTRYNO AS [G P No], ")
            .Append(" B.ACCOUNTNAME AS [Party Name], ")
            .Append(" A.BOOKVNO AS VALUECODE, ")
            .Append(" A.BOOKVNO AS VALUECODE, ")
            .Append(" A.BOOKVNO AS VALUECODE ")
            .Append(" FROM TRNGATEPASS AS A,MstMasterAccount AS B ")
            .Append(" WHERE 1=1 AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(Str_Condition)
            .Append(" GROUP BY A.BOOKVNO, A.ENTRYNO, B.ACCOUNTNAME ")
            .Append(" ORDER BY A.ENTRYNO ")
        End With
        Return _strQuery.ToString
    End Function

    Public Function Get_Gate_Pass_Printing_Query(ByVal Filter_Condition As String, ByVal Book_Code As String) As String
        Get_Gate_Pass_Printing_Query = ""
        _strQuery = New StringBuilder

        With _strQuery
            If Book_Code = "0001-000000237" Then  'TEXTURISE
                .Append(" SELECT ")
                .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
                .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
                .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
                .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
                .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
                .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
                .Append(" '" & Comp_email & "'   AS COMP_EMAIL,'' as WEAVETYPE, ")
                .Append(" TrnGatePass.CHALLANNO,A.AC_NAME AS PROCESSNAME,TrnGatePass.headerremark, ")
                .Append(" TrnGatePass.entryno as caseno,TrnGatePass.entryno as offerno, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_ADVISEDATE, ")
                .Append(" MstYarnCount.CountName AS ITEMNAME,TrnGatePass.userid, ")
                .Append(" TrnGatePass.VEHICLE_REG_NO AS Y_LOTNO,TrnGatePass.BOOKVNO, ")
                .Append(" TrnGatePass.SRNO,TrnGatePass.PCS,TrnGatePass.MTR AS MTR_WEIGHT, ")
                .Append(" TrnGatePass.WEIGHT,TrnGatePass.FREIGHT,TrnGatePass.PAY_TYPE AS BEAMNO, ")
                .Append(" MstMasterAccount.ACCOUNTNAME AS PARTYNAME,MSTTRANSPORT.TRANSPORTNAME, ")
                .Append(" B.CITYNAME AS PARTYCITYNAME ")
                .Append(" ,0.00  as INV_QTY ")
                .Append(" ,MSTTRANSPORT.EMAIL AS OTHER1 ")

                .Append(" FROM TrnGatePass,MSTYARNCOUNT,MstMasterAccount,MSTTRANSPORT,Mst_Acof_Supply A,MSTCITY B ")
                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ID ")
                .Append(" AND MstMasterAccount.CITYCODE=B.CITYCODE ")
                .Append(" AND TrnGatePass.ITEMCODE=MSTYARNCOUNT.COUNTCODE ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.BOOKCODE='" & Book_Code & "' ")
                .Append(Filter_Condition)
                .Append(" ORDER BY TrnGatePass.entryno,TrnGatePass.SRNO ")
            ElseIf Book_Code = "0001-000000320" Then  'FINISH GATE PASS BY INVOICE 
                .Append(" SELECT ")
                .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
                .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
                .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
                .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
                .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
                .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
                .Append(" '" & Comp_email & "'   AS COMP_EMAIL,'' as WEAVETYPE, ")
                .Append(" A.ACCOUNTNAME AS PROCESSNAME,TrnGatePass.headerremark, ")
                .Append(" TrnGatePass.CHALLANNO,TrnGatePass.entryno as caseno,TrnGatePass.entryno as offerno, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_ADVISEDATE,TrnGatePass.userid, ")
                '.Append(" IIF(TrnGatePass.ROWREMARK<>'',TrnGatePass.ROWREMARK,MstFabricItem.ITENNAME) AS ITEMNAME, ")
                .Append(" TrnGatePass.VEHICLE_REG_NO AS Y_LOTNO,TrnGatePass.BOOKVNO, ")
                .Append(" TrnGatePass.SRNO,TrnGatePass.PCS,TrnGatePass.MTR AS MTR_WEIGHT, ")
                .Append(" TrnGatePass.WEIGHT,TrnGatePass.FREIGHT,TrnGatePass.PAY_TYPE AS BEAMNO, ")
                .Append(" C.ACCOUNTNAME ,MSTTRANSPORT.TRANSPORTNAME, ")
                .Append(" B.CITYNAME,F.CITYNAME AS PARTYCITYNAME,TrnGatePass.ROWREMARK ")
                '.Append(" ,COUNT (TrnGatePass.CHALLANNO) as INV_QTY ")
                .Append(" ,E.AC_NAME AS ACOFNAME ")
                .Append(" ,0.00  as INV_QTY ")
                .Append(" ,TrnGatePass.OP1 AS BILLNO ")
                .Append(" ,G.ACCOUNTNAME AS PARTYNAME ")
                .Append(" ,(TrnGatePass.OP11) as BALES ")
                .Append(" ,MSTTRANSPORT.EMAIL AS OTHER1 ")
                .Append(" FROM TrnGatePass,MSTTRANSPORT, ")
                .Append(" MstMasterAccount A,MSTCITY B,TRNINVOICEHEADER as D,MstMasterAccount C ")
                .Append(" ,Mst_Acof_Supply AS E ")
                .Append(" ,MSTCITY AS F ")
                .Append(" ,MstMasterAccount AS G ")

                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ACCOUNTCODE ")
                .Append(" AND D.DESPATCHCODE=B.CITYCODE ")
                .Append(" AND G.CITYCODE=F.CITYCODE ")
                .Append(" AND D.ACCOUNTCODE=C.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=G.ACCOUNTCODE ")
                .Append(" AND D.ACOFCODE=E.ID ")
                .Append(" AND TrnGatePass.CHALLANBOOKVNO=D.BOOKVNO ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.BOOKCODE='" & Book_Code & "' ")
                .Append(Filter_Condition)
                .Append(" ORDER BY ")
                .Append(" TrnGatePass.entryno,TrnGatePass.SRNO ")

            Else
                .Append(" SELECT ")
                .Append(" '" & Comp_Add1 & "'   AS COMP_ADD1, ")
                .Append(" '" & Comp_Add2 & "'   AS COMP_ADD2, ")
                .Append(" '" & Comp_Add3 & "'   AS COMP_ADD3, ")
                .Append(" '" & Comp_Add4 & "'   AS COMP_ADD4, ")
                .Append(" '" & Comp_Tin & "'   AS COMP_TIN, ")
                .Append(" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, ")
                .Append(" '" & Comp_email & "'   AS COMP_EMAIL,'' as WEAVETYPE, ")
                .Append(" A.ACCOUNTNAME AS PROCESSNAME,TrnGatePass.headerremark, ")
                .Append(" TrnGatePass.CHALLANNO,TrnGatePass.entryno as caseno,TrnGatePass.entryno as offerno, ")
                .Append(" FORMAT(TrnGatePass.GPDATE,'dd/MM/yyyy') as F_ADVISEDATE,TrnGatePass.userid, ")
                .Append(" IIF(TrnGatePass.ROWREMARK<>'',TrnGatePass.ROWREMARK,MstFabricItem.ITENNAME) AS ITEMNAME, ")
                .Append(" TrnGatePass.VEHICLE_REG_NO AS Y_LOTNO,TrnGatePass.BOOKVNO, ")
                .Append(" TrnGatePass.SRNO,TrnGatePass.PCS,TrnGatePass.MTR AS MTR_WEIGHT, ")
                .Append(" TrnGatePass.WEIGHT,TrnGatePass.FREIGHT,TrnGatePass.PAY_TYPE AS BEAMNO, ")
                .Append(" MstMasterAccount.ACCOUNTNAME AS PARTYNAME,MSTTRANSPORT.TRANSPORTNAME, ")
                .Append(" B.CITYNAME AS PARTYCITYNAME,TrnGatePass.ROWREMARK ")
                .Append(" ,0.00  as INV_QTY ")
                .Append(" ,MSTTRANSPORT.EMAIL AS OTHER1 ")
                .Append(" ,TrnGatePass.OP1 AS BILLNO ")
                .Append(" ,TrnGatePass.OP6 AS F_BILLDATE ")
                .Append(" ,TrnGatePass.OP7 AS LIA_TYPE ")
                .Append(" ,TrnGatePass.OP8 AS FD_PD ")
                .Append(" ,TrnGatePass.OP5 AS DESIGNNO ")

                .Append(" FROM TrnGatePass,MSTFABRICITEM,MstMasterAccount,MSTTRANSPORT,MstMasterAccount A,MSTCITY B ")
                .Append(" WHERE 1=1 AND TrnGatePass.PROCESSCODE=A.ACCOUNTCODE ")
                .Append(" AND MstMasterAccount.CITYCODE=B.CITYCODE ")
                .Append(" AND TrnGatePass.ITEMCODE=MSTFABRICITEM.ID ")
                .Append(" AND TrnGatePass.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" AND TrnGatePass.TRANSPORTCODE=MSTTRANSPORT.ID ")
                .Append(" AND TrnGatePass.BOOKCODE='" & Book_Code & "' ")
                .Append(Filter_Condition)
                .Append(" ORDER BY TrnGatePass.entryno,TrnGatePass.SRNO ")
            End If
        End With
        Get_Gate_Pass_Printing_Query = _strQuery.ToString
        Return Get_Gate_Pass_Printing_Query
    End Function
    Public Function EntryData_Opening_Stock_Entry_View_Record(ByVal Book_Behaviour As String, ByVal View_Filter_Condition As String, ByVal View_Order_By As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" TrnInvoiceDetail.BOOKVNO, ")
            .Append(" TrnInvoiceDetail.ENTRYNO as [Entry No], ")
            .Append(" MstMasterAccount.accountname as [Account Name], ")
            .Append(" FORMAT(TrnInvoiceDetail.BILLDATE,'dd/MM/yyyy') AS [Entry Date], ")
            .Append(" TrnInvoiceDetail.SRNO as [Sno], ")
            If Book_Behaviour = "OPENING-FINISH-STOCK" Then
                .Append(" MSTFABRICITEM.ITENNAME AS [Item Name], ")
            Else
                .Append(" MSTYARNCOUNT.COUNTNAME AS [Item Name], ")
            End If
            .Append(" TrnInvoiceDetail.MTR_WEIGHT AS [Quantity] ")
            .Append(" FROM ")
            .Append(" TrnInvoiceDetail,MstMasterAccount, ")
            If Book_Behaviour = "OPENING-FINISH-STOCK" Then
                .Append(" MSTFABRICITEM ")
            Else
                .Append(" MSTYARNCOUNT ")
            End If
            .Append(" WHERE 1=1 ")
            If Book_Behaviour = "OPENING-FINISH-STOCK" Then
                .Append(" AND TrnInvoiceDetail.ITEMCODE=MSTFABRICITEM.ID ")
            Else
                .Append(" AND TrnInvoiceDetail.ITEMCODE=MSTYARNCOUNT.COUNTCODE ")
            End If
            .Append(" AND TrnInvoiceDetail.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Job_Offer_Entry_View_Record(ByVal _BookCode As String, ByVal OfferDate As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append(" A.ENTRYNO AS [Offer No], ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS [Date], ")
            .Append(" C.ACCOUNTNAME AS [Party Name], ")
            .Append(" B.ACCOUNTNAME AS [Agent Name], ")
            .Append(" D.ITENNAME AS [Item Name], ")
            .Append(" F.Design_Name AS Design, ")
            .Append(" G.SHADE AS Shade, ")
            .Append(" H.LoomNo, ")
            .Append(" FORMAT(A.MTR_WEIGHT,'0.00') AS [Quantity] ")

            .Append(" FROM TRNOFFER A")
            .Append(" LEFT JOIN MstMasterAccount B ON A.AGENTCODE=B.ACCOUNTCODE")
            .Append(" LEFT JOIN MstMasterAccount C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTFABRICITEM D  ON A.ITEMCODE=D.ID ")
            .Append(" LEFT JOIN Mst_Fabric_Design F ON A.DESIGNCODE=F.Design_code ")
            .Append(" LEFT JOIN Mst_Fabric_Shade G ON A.SHADECODE=G.ID ")
            .Append(" LEFT JOIN MstLoomNo H ON A.YARN_LOT_NO=H.LoomNoCode ")

            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE= '" & _BookCode & "' ")
            .Append(" AND A.OFFERDATE>='" & OfferDate & "' ")
            .Append(" ORDER BY A.ENTRYNO ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Job_Offer_Entry_txt_ENTRYNO_Validated(ByVal _BookVNo As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_OFFERDATE, ")
            .Append(" FORMAT(A.YARN_DELV_DATE,'dd/MM/yyyy') AS F_YARN_DELV_DATE, ")
            .Append(" B.ACCOUNTNAME AS PARTYNAME, ")
            .Append(" C.ITENNAME AS ITEMNAME, ")
            .Append(" D.SELVEDGE_NAME AS SELVNAME, ")
            .Append(" E.ACCOUNTNAME AS AGENTNAME ")
            .Append(" ,F.Design_Name AS DESIGNNAME ")
            .Append(" ,G.SHADE AS SHADENAME ")
            .Append(" ,L.BOOKNAME	  ")
            .Append(" ,M.LoomNo	  ")
            .Append(" FROM TRNOFFER A")
            .Append(" LEFT JOIN MstMasterAccount B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTFABRICITEM C ON A.ITEMCODE=C.ID")
            .Append(" LEFT JOIN Mst_selvedge D ON A.SELVCODE=D.ID")
            .Append(" LEFT JOIN MstMasterAccount E ON A.AGENTCODE=E.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Fabric_Design F ON A.DESIGNCODE=F.Design_code ")
            .Append(" LEFT JOIN Mst_Fabric_Shade G ON A.SHADECODE=G.ID ")
            .Append(" LEFT JOIN MstBOOK AS L ON A.BOOKCODE=L.BOOKCODE  ")
            .Append(" LEFT JOIN MstLoomNo AS M ON A.YARN_LOT_NO=M.LoomNoCode  ")

            .Append(" WHERE 1=1 ")

            .Append(" AND BOOKVNO='" & _BookVNo & "'")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Job_Offer_Entry_txtBookName_Validated(ByVal _BookCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT TOP 1 A.*, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_OFFERDATE, ")
            .Append(" B.ACCOUNTNAME,F.ACCOUNTNAME AS AGENTNAME ")
            .Append(" FROM TRNOFFER AS A, MstMasterAccount AS B,MstMasterAccount AS F ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" AND A.AGENTCODE=F.ACCOUNTCODE ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_Show_Yarn_Offer(ByVal Book_Filter_String As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal _ActiveRowItemCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" select a.bookvno, ")
            .Append(" a.offerNo as [Offer No], ")
            .Append(" format(a.OfferDate,'dd/MM/yy') AS [Offer Date], ")
            .Append(" b.COUNTNAME as [Count Name], ")
            .Append(" a.descr as [Descr], ")
            .Append(" a.YARN_LOT_NO as [Lot No],")
            .Append(" a.YARN_SHADE_NO as [Shade No],")
            .Append(" SUM(a.mtr_weight)- SUM(A.cancel_Qty) as [Offer Qty],")
            .Append(" (0.0) as [Adj-Qty], ")
            .Append(" (0.0) as [Bal-Qty], ")
            .Append(" format(a.Rate,'0.0000') as [Rate],")
            .Append(" SUBSTRING(lotno,1,1) + (SUBSTRING(lotno,2,10)) as [Qty Type],")
            .Append(" (0.0) as inv_qty, ")
            .Append(" SUM(a.mtr_Weight)- SUM(A.cancel_Qty) as qty,")
            .Append(" A.ITEMCODE,")
            .Append(" A.CUTCODE, ")
            .Append(" A.LOTNO, ")
            .Append(" (0.0) AS BLANK_QTY, ")
            .Append(" A.DESIGNCODE, ")
            .Append(" A.SHADECODE, ")
            .Append(" RDVALUE, ")
            .Append(" RDON, ")
            .Append(" CDVALUE, ")
            .Append(" CDON, ")
            .Append(" A.ACCOUNTCODE ")
            .Append(" ,D.ACCOUNTNAME AS [Mill Name] ")
            .Append(" ,A.PartyOfferNo ")

            .Append(" FROM TRNOFFER AS A, MSTYARNCOUNT AS B, MstCutMaster AS C ")
            .Append(" ,MstMasterAccount D")
            .Append(" where 1 = 1 ")
            .Append(Book_Filter_String)
            .Append(_ActiveRowItemCode)
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.OFFERDATE<='" & BillDate & "' ")
            .Append(" AND A.CLEAR<>'YES' ")
            .Append(" AND A.ITEMCODE = B.COUNTCODE AND A.CUTCODE = C.ID ")
            .Append(" AND A.SELVCODE=D.ACCOUNTCODE ")
            .Append(" GROUP BY A.DESCR,A.BOOKVNO,A.OFFERNO,A.OFFERDATE, ")
            .Append(" B.COUNTNAME,C.CUTNAME,A.RATE,A.LOTNO,A.ITEMCODE,A.CUTCODE, ")
            .Append(" A.DESIGNCODE,A.SHADECODE,YARN_LOT_NO ,YARN_SHADE_NO, ")
            .Append(" A.RDVALUE,A.RDON,A.CDVALUE,A.CDON,A.ACCOUNTCODE,D.ACCOUNTNAME  ")
            .Append(" ,A.PartyOfferNo ")
            .Append(" ORDER BY a.OfferDate,A.OFFERNO ")
        End With

        Return strQuery.ToString
    End Function
    Public Function _userWrits(ByVal Buttonuse As String)
        Dim _selectmode As String = ""

        If Buttonuse = "ADD" Then
            _selectmode = _USERADD
        ElseIf Buttonuse = "EDIT" Then
            _selectmode = _USEREDIT
        ElseIf Buttonuse = "DELETE" Then
            _selectmode = _USERDELETE
        ElseIf Buttonuse = "VIEW" Then
            _selectmode = _USERVIEW
        ElseIf Buttonuse = "PRINT" Then
            _selectmode = _USERPRINT
        End If
        Return _selectmode
    End Function


    Public Function _CheckDeleteAccount(ByVal _table As String, ByVal _AccountType As String, ByVal Accountcode As String)
        Dim _AccountAvailabe As Boolean = False


        sqL = " select* from " & _table & " where " & _AccountType & " = '" & Accountcode & "' "
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            _AccountAvailabe = True
        End If

        If _AccountAvailabe = True Then
            _Accountactive = True
        End If
        Return _Accountactive

    End Function

#Region "YARN CHALLAN QUERY"

    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book37(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal billDate As String, ByVal Str_In_Challan_Book As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" IIF (SUM(A.TOTAL_BAGS) IS NULL ,SUM(A.BOX_NO),SUM(A.TOTAL_BAGS)) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" A.PROD_LOTNO AS [Lot No], ")
            .Append(" I.AC_NAME AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" A.ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.Rate AS RATE, ")
            .Append(" A.PROD_LOTNO, ")
            '.Append(" A.PROD_SHADENO AS PROD_SHADENO, ")
            '.Append(" IIF (A.DISPTYPE<> NULL ,A.PROD_SHADENO,J.YARN_SHADE_NAME)  AS PROD_SHADENO, ")
            .Append(" IIF ( A.DISPTYPE = '' OR A.DISPTYPE>'',A.PROD_SHADENO,J.YARN_SHADE_NAME)  AS PROD_SHADENO, ")
            .Append(" A.DELIVERY_AT, ")
            .Append(" A.DELIVERY_ACCOUNTCODE AS FACTORY_CODE, ")
            .Append(" K.ACCOUNTNAME  AS DELIVERYAT ")
            .Append(" ,'' AS SHADECODE ")
            .Append(" ,L.COUNTNAME AS QUALITYNAME ")
            .Append(" ,0.00 as GROSS_WEIGHT ")
            .Append(" FROM TRNTFODESPATCH AS A ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS C ON  A.ITEMCODE=C.COUNTCODE  ")
            .Append(" LEFT JOIN MSTTRANSPORT E ON  A.TRANSPORTCODE=E.ID ")
            .Append(" LEFT JOIN  MstMasterAccount AS F ON  A.ACCOUNTCODE=F.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS H ON  F.AGENTCODE=H.ACCOUNTCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply I  ON A.ACOFCODE=I.ID")
            .Append(" LEFT JOIN MstYarnItemShade as J  ON  A.PROD_SHADENO=J.ID ")
            .Append(" LEFT JOIN MstMasterAccount AS K ON  A.DELIVERY_ACCOUNTCODE=K.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS L ON  A.QUALITYCODE=L.COUNTCODE  ")
            .Append(" WHERE 1=1 ")
            .Append(_BookVNo)
            .Append(AccountCode)
            .Append(billDate)
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1 AND CHALLANBOOKVNO IS NOT NULL) ")
            .Append(" AND (A.OP1 ='NO' OR  A.OP1 IS NULL) ")
            .Append(" GROUP BY A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME,A.ACOFCODE,I.AC_NAME,A.DISPTYPE,")
            .Append(" A.ITEMCODE, A.BOOKVNO,A.PROD_LOTNO,A.PROD_SHADENO,J.YARN_SHADE_NAME, ")
            .Append(" E.TRANSPORTNAME,E.ID,DELIVERY_AT,A.ACCOUNTCODE, ")
            .Append(" F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,a.Rate ")
            .Append(" ,L.COUNTNAME ")
            .Append(" ,A.DELIVERY_ACCOUNTCODE ")
            .Append(" ,K.ACCOUNTNAME ")
            .Append(" ORDER BY  LEN(A.CHALLAN_NO),(A.CHALLAN_NO), C.COUNTNAME ")
            .Append(" ,IIF ( A.DISPTYPE = '' OR A.DISPTYPE>'',A.PROD_SHADENO,J.YARN_SHADE_NAME) ")
            .Append(" ,A.PROD_LOTNO")
        End With

        Return strQuery.ToString
    End Function

    Public Function QueryExportChallan(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal billDate As String, ByVal Str_In_Challan_Book As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" IIF (SUM(A.TOTAL_BAGS) IS NULL ,SUM(A.BOX_NO),SUM(A.TOTAL_BAGS)) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            '.Append(" A.PROD_LOTNO AS [Lot No], ")
            .Append("  '' AS [Lot No], ")
            .Append(" I.AC_NAME AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" A.ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.Rate AS RATE, ")
            '.Append(" A.PROD_LOTNO, ")
            .Append(" '' as PROD_LOTNO, ")
            '.Append(" IIF ( A.DISPTYPE = '' OR A.DISPTYPE>'',A.PROD_SHADENO,J.YARN_SHADE_NAME)  AS PROD_SHADENO, ")
            .Append(" '' PROD_SHADENO, ")
            .Append(" A.DELIVERY_AT, ")
            .Append(" A.DELIVERY_ACCOUNTCODE AS FACTORY_CODE, ")
            .Append(" K.ACCOUNTNAME  AS DELIVERYAT ")
            .Append(" ,'' AS SHADECODE ")
            .Append(" ,L.COUNTNAME AS QUALITYNAME ")
            .Append(" ,SUM(A.GROSS_WEIGHT) AS GROSS_WEIGHT ")
            .Append(" FROM TRNTFODESPATCH AS A ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS C ON  A.ITEMCODE=C.COUNTCODE  ")
            .Append(" LEFT JOIN MSTTRANSPORT E ON  A.TRANSPORTCODE=E.ID ")
            .Append(" LEFT JOIN  MstMasterAccount AS F ON  A.ACCOUNTCODE=F.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS H ON  F.AGENTCODE=H.ACCOUNTCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply I  ON A.ACOFCODE=I.ID")
            .Append(" LEFT JOIN MstYarnItemShade as J  ON  A.PROD_SHADENO=J.ID ")
            .Append(" LEFT JOIN MstMasterAccount AS K ON  A.DELIVERY_ACCOUNTCODE=K.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS L ON  A.QUALITYCODE=L.COUNTCODE  ")
            .Append(" WHERE 1=1 ")
            .Append(_BookVNo)
            .Append(AccountCode)
            .Append(billDate)
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1 AND CHALLANBOOKVNO IS NOT NULL) ")
            .Append(" AND (A.OP1 ='NO' OR  A.OP1 IS NULL) ")
            .Append(" GROUP BY A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME,A.ACOFCODE,I.AC_NAME,A.DISPTYPE,")
            .Append(" A.ITEMCODE, A.BOOKVNO,J.YARN_SHADE_NAME, ")
            .Append(" E.TRANSPORTNAME,E.ID,DELIVERY_AT,A.ACCOUNTCODE, ")
            .Append(" F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,a.Rate ")
            .Append(" ,L.COUNTNAME ")
            .Append(" ,A.DELIVERY_ACCOUNTCODE ")
            .Append(" ,K.ACCOUNTNAME ")
            '.Append(" ,A.PROD_LOTNO,A.PROD_SHADENO ")
            .Append(" ORDER BY  LEN(A.CHALLAN_NO),(A.CHALLAN_NO), C.COUNTNAME ")
            '.Append(" ,IIF ( A.DISPTYPE = '' OR A.DISPTYPE>'',A.PROD_SHADENO,J.YARN_SHADE_NAME) ")
            '.Append(" ,A.PROD_LOTNO")
        End With

        Return strQuery.ToString
    End Function


    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book56(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal BillDate As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            '.Append(" SUM(A.BAGS) AS PCS, ")
            '.Append(" SUM(A.ACTUAL_WEIGHT) AS MTR_WEIGHT, ")
            '.Append(" SUM(A.ACTUAL_WEIGHT) AS WEIGHT, ")
            .Append(" A.BAGS AS PCS, ")
            .Append(" A.ACTUAL_WEIGHT AS MTR_WEIGHT, ")
            .Append(" A.ACTUAL_WEIGHT AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            '.Append(" A.MERGE_SHADENO AS PROD_LOTNO,A.LOTNO_PALLETNO AS PROD_SHADENO ")
            .Append(" A.LOTNO,A.SHADENO,' '  AS DELIVERY_AT, ")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME ")
            .Append(" FROM TRNFACTORYYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPPLIER_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.BOOKVNO<>'" & _BookVNo & "' ")
            .Append(" AND A.SUPPLIER_CODE='" & AccountCode & "'")
            '.Append(" AND A.CHALLANDATE<=#" & BillDate & "# ")
            .Append(" AND A.BOOKCODE='0001-000000080' ")
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL GROUP BY CHALLANBOOKVNO) ")
            '.Append(" GROUP BY A.SUPP_CODE,A.CHALLANNO, A.CHALLANDATE,C.COUNTNAME,A.ENTRYNO, ")
            '.Append(" A.COUNTCODE, A.BOOKVNO,A.FACTORY_CODE,J.ACCOUNTNAME, ")
            '.Append(" A.LOTNO,A.SHADENO, ")
            '.Append(" E.TRANSPORTNAME,E.ID, ")
            '.Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ORDER BY A.CHALLANDATE,A.BOOKVNO,A.SRNO ")
        End With

        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book47(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal Str_In_Challan_Book As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" A.BAGS AS PCS, ")
            .Append(" A.ACTUAL_WEIGHT AS MTR_WEIGHT, ")
            .Append(" A.ACTUAL_WEIGHT AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.LOTNO,A.SHADENO,' '  AS DELIVERY_AT, ")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME, ")
            .Append(" '' AS SHADNO ")

            .Append(" FROM TRNFACTORYYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPPLIER_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.BOOKVNO<>'" & _BookVNo & "' ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
            '.Append(" AND A.CHALLANDATE<=#" & BillDate & "# ")
            '.Append(" AND A.BOOKCODE='0001-000000076' ")
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL    WHERE  CHALLANBOOKVNO IS NOT NULL GROUP BY CHALLANBOOKVNO) ")
            .Append(" ORDER BY A.CHALLANDATE,A.BOOKVNO,A.SRNO ")
        End With

        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book252(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal BillDate As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" MARK, ")
            .Append(" Z.CHALLANNO, ")
            .Append(" Z.F_CHALLANDATE, ")
            .Append(" Z.CUTNAME, ")
            .Append(" Z.COUNTNAME, ")
            .Append(" Z.PCS, ")
            .Append(" Z.MTR_WEIGHT, ")
            .Append(" Z.WEIGHT, ")
            .Append(" Z.ACOFNAME, ")
            .Append(" Z.TRANSPORTNAME, ")
            .Append(" Z.RATEON, ")
            .Append(" Z.TRANSPORTCODE, ")
            .Append(" Z.ACOFCODE, ")
            .Append(" Z.CUTCODE, ")
            .Append(" Z.ITEMCODE, ")
            .Append(" Z.BOOKVNO, ")
            .Append(" Z.ACCOUNTCODE, ")
            .Append(" Z.DESPATCHCODE, ")
            .Append(" Z.ACCOUNTNAME, ")
            .Append(" Z.DESPATCH, ")
            .Append(" Z.AGENTCODE, ")
            .Append(" Z.AGENTNAME, ")
            .Append(" Z.RATE, ")
            .Append(" Z.LOTNO,Z.SHADENO,Z.DELIVERY_AT,")
            .Append(" Z.FACTORY_CODE, ")
            .Append(" Z.FACTORYNAME,Z.LRNO ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.BAGS) AS PCS, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.LOTNO,A.SHADENO,' '  AS DELIVERY_AT,")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME,A.LRNO ")
            .Append(" FROM TRNDENIMYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPP_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.BOOKVNO<>'" & _BookVNo & "' ")
            .Append(" AND A.SUPPLIER_CODE='" & AccountCode & "'")
            .Append(" AND A.BOOKCODE='0001-000000203' ")
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
            .Append(" GROUP BY A.SUPP_CODE,A.CHALLANNO, A.CHALLANDATE,C.COUNTNAME,A.ENTRYNO, ")
            .Append(" A.COUNTCODE, A.BOOKVNO,A.FACTORY_CODE,J.ACCOUNTNAME, ")
            .Append(" A.LOTNO,A.SHADENO,A.LRNO, ")
            .Append(" E.TRANSPORTNAME,E.ID, ")
            .Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")

            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.BAGS) AS PCS, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.LOTNO,A.SHADENO,' '  AS DELIVERY_AT,")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME,A.LRNO ")
            .Append(" FROM TRNFACTORYYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPP_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.BOOKVNO<>'" & _BookVNo & "' ")
            .Append(" AND A.SUPPLIER_CODE='" & AccountCode & "'")
            .Append(" AND A.BOOKCODE='0001-000000074' ")
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
            .Append(" GROUP BY A.SUPP_CODE,A.CHALLANNO, A.CHALLANDATE,C.COUNTNAME,A.ENTRYNO, ")
            .Append(" A.COUNTCODE, A.BOOKVNO,A.FACTORY_CODE,J.ACCOUNTNAME, ")
            .Append(" A.LOTNO,A.SHADENO,A.LRNO, ")
            .Append(" E.TRANSPORTNAME,E.ID, ")
            .Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ) ")
            .Append(" AS Z ")
            .Append(" ORDER BY Z.CHALLANNO, Z.COUNTNAME ")
        End With

        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book40(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal billDate As String, ByVal Str_In_Challan_Book As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.TOTAL_BAGS) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.NET_WEIGHT) AS WEIGHT, ")
            .Append(" ' ' AS ACOFNAME, ")
            .Append(" ' ' AS TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" ' ' AS  TRANSPORTCODE, ")
            .Append(" ' ' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.PROD_LOTNO,A.PROD_SHADENO, ")
            .Append(" ' 'AS DELIVERYAT, ")
            .Append(" '' AS FACTORY_CODE, ")
            .Append(" ''  AS FACTORYNAME ")
            .Append(" ,'' AS SHADECODE ")
            .Append(" ,'' AS QUALITYNAME ")
            .Append(" ,0.00 as GROSS_WEIGHT ")
            .Append(" FROM TRNTFOPRODUCTION A,MSTYARNCOUNT C, ")
            .Append(" MstMasterAccount F,MSTCITY G,MstMasterAccount H ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE=C.COUNTCODE ")
            .Append(_BookVNo)
            .Append(AccountCode)
            .Append(billDate)
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
            .Append(" GROUP BY A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME, ")
            .Append(" A.ITEMCODE, A.BOOKVNO,A.PROD_LOTNO,A.PROD_SHADENO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ORDER BY (A.CHALLAN_NO), C.COUNTNAME ")
            .Append(" ,A.PROD_SHADENO,A.PROD_LOTNO ")
        End With

        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book43(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal billDate As String, ByVal Str_In_Challan_Book As String, ByVal _FllterOnlyAccountcode As String) As String

        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT * FROM( ")
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.TOTAL_BAGS) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.NET_WEIGHT) AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPPACCOUNTCODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.RATE, ")
            .Append(" A.LOTNO_PALLETNO AS PROD_LOTNO,A.MERGE_SHADENO AS PROD_SHADENO, ")
            .Append(" '' AS DELIVERYAT, ")
            .Append(" '' AS FACTORY_CODE, ")
            .Append(" '' AS FACTORYNAME,A.LRNO ")
            .Append(" ,'' AS QUALITYNAME ")
            .Append(" ,A.ENTRYNO ")
            .Append(" ,a.op4 as shadecode")
            .Append(" ,0.00 as GROSS_WEIGHT ")
            .Append(" FROM TRNTFOYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.SUPPACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(_BookVNo)
            .Append(AccountCode)
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
            .Append(" GROUP BY A.SUPPACCOUNTCODE,A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME, ")
            .Append(" A.ITEMCODE, A.BOOKVNO,A.LRNO, ")
            .Append(" A.PROD_LOTNO,A.PROD_SHADENO, ")
            .Append(" E.TRANSPORTNAME,E.ID,A.ENTRYNO, ")
            .Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ,A.MERGE_SHADENO ")
            .Append(" ,A.RATE ")
            .Append(" ,A.LOTNO_PALLETNO ")
            .Append(" ,a.op4 ")
            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.TOTAL_BAGS) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.NET_WEIGHT) AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.QUALITYCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPPACCOUNTCODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.RATE, ")
            .Append(" A.LOTNO_PALLETNO AS PROD_LOTNO,A.MERGE_SHADENO AS PROD_SHADENO, ")
            .Append(" '' AS DELIVERYAT, ")
            .Append(" '' AS FACTORY_CODE, ")
            .Append(" '' AS FACTORYNAME,A.LRNO ")
            .Append(" ,'' AS QUALITYNAME ")
            .Append(" ,A.ENTRYNO ")
            .Append(" ,a.op4 as shadecode")
            .Append(" ,0.00 as GROSS_WEIGHT ")
            .Append(" FROM TRNTFOPRODUCTION AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='0000-000000175' ")
            .Append(" AND A.SUPPACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            '.Append(" AND A.ITEMCODE=C.COUNTCODE ")
            .Append(" AND A.QUALITYCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(_BookVNo)
            .Append(AccountCode)
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
            .Append(" GROUP BY A.SUPPACCOUNTCODE,A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME, ")
            .Append(" A.QUALITYCODE, A.BOOKVNO,A.LRNO, ")
            .Append(" A.PROD_LOTNO,A.PROD_SHADENO, ")
            .Append(" E.TRANSPORTNAME,E.ID,A.ENTRYNO, ")
            .Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ,A.MERGE_SHADENO ")
            .Append(" ,A.RATE ")
            .Append(" ,A.LOTNO_PALLETNO ")
            .Append(" ,a.op4")

            .Append(" UNION ALL ")


            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" IIF (SUM(A.TOTAL_BAGS) IS NULL ,SUM(A.BOX_NO),SUM(A.TOTAL_BAGS)) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.NET_WEIGHT) AS WEIGHT, ")
            .Append(" I.AC_NAME AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" A.ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.Rate AS RATE, ")
            .Append(" '' as PROD_LOTNO, ")
            .Append(" '' PROD_SHADENO, ")
            .Append(" A.DELIVERY_AT, ")
            .Append(" A.DELIVERY_ACCOUNTCODE AS FACTORY_CODE, ")
            .Append(" '' AS FACTORYNAME, ")
            .Append(" '' AS LRNO, ")
            .Append(" L.COUNTNAME AS QUALITYNAME, ")
            .Append(" A.ENTRYNO, ")
            .Append(" '' AS SHADECODE, ")
            .Append(" SUM(A.GROSS_WEIGHT) AS GROSS_WEIGHT ")
            .Append(" FROM TRNTFODESPATCH AS A ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS C ON  A.ITEMCODE=C.COUNTCODE  ")
            .Append(" LEFT JOIN MSTTRANSPORT E ON  A.TRANSPORTCODE=E.ID ")
            .Append(" LEFT JOIN  MstMasterAccount AS F ON  A.ACCOUNTCODE=F.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTCITY AS G ON  F.CITYCODE=G.CITYCODE  ")
            .Append(" LEFT JOIN MstMasterAccount AS H ON  F.AGENTCODE=H.ACCOUNTCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply I  ON A.ACOFCODE=I.ID")
            .Append(" LEFT JOIN MstYarnItemShade as J  ON  A.PROD_SHADENO=J.ID ")
            .Append(" LEFT JOIN MstMasterAccount AS K ON  A.DELIVERY_ACCOUNTCODE=K.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS L ON  A.QUALITYCODE=L.COUNTCODE  ")
            .Append(" WHERE 1=1 ")
            .Append(_BookVNo)
            .Append(AccountCode)
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL WHERE 1=1 AND CHALLANBOOKVNO IS NOT NULL) ")
            .Append(" AND (A.OP1 ='NO' OR  A.OP1 IS NULL) ")
            .Append(" GROUP BY A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME,A.ACOFCODE,I.AC_NAME,A.DISPTYPE,")
            .Append(" A.ITEMCODE, A.BOOKVNO,J.YARN_SHADE_NAME, ")
            .Append(" E.TRANSPORTNAME,E.ID,DELIVERY_AT,A.ACCOUNTCODE, ")
            .Append(" F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME,a.Rate ")
            .Append(" ,L.COUNTNAME ")
            .Append(" ,A.DELIVERY_ACCOUNTCODE ")
            .Append(" ,A.ENTRYNO ")
            .Append(" ,K.ACCOUNTNAME ")


            .Append(" UNION ALL ")

            .Append(" select ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" A.BAGS AS PCS, ")
            .Append(" A.ACTUAL_WEIGHT AS MTR_WEIGHT, ")
            .Append(" A.ACTUAL_WEIGHT AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.GREY_MTR AS RATE, ")
            .Append(" A.LOTNO as PROD_LOTNO ")
            .Append(" ,A.SHADENO AS PROD_SHADENO ")
            .Append(" ,''  AS DELIVERY_AT, ")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME ")
            .Append(" ,'' as LRNO ")
            .Append(" ,'' AS QUALITYNAME ")
            .Append(" ,A.ENTRYNO ")
            .Append(" ,a.shadecode ")
            .Append(" ,0.00 as GROSS_WEIGHT ")
            .Append(" FROM TRNFACTORYYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPP_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.SUPPLIER_CODE='" & _FllterOnlyAccountcode & "' ")
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL  WHERE  CHALLANBOOKVNO IS NOT NULL ) ")

            .Append(" ) AS Z ")
            .Append(" ORDER BY (Z.ENTRYNO), Z.COUNTNAME ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book46(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal billDate As String, ByVal Str_In_Challan_Book As String) As String

        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLAN_NO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.TOTAL_BAGS) AS PCS, ")
            .Append(" SUM(A.NET_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.NET_WEIGHT) AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'MTR' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPPACCOUNTCODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" ' ' AS PROD_LOTNO,' ' AS PROD_SHADENO, ")
            .Append(" ' ' AS DELIVERY_AT, ")
            .Append(" '' AS FACTORY_CODE, ")
            .Append(" ''  AS FACTORYNAME,A.LRNO ")
            .Append(" FROM TRNTFOYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.SUPPACCOUNTCODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.ITEMCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.BOOKVNO<>'" & _BookVNo & "' ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            '.Append(" AND A.CHALLAN_DATE<=#" & billDate & "# ")
            .Append(Str_In_Challan_Book)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL) ")
            .Append(" GROUP BY A.SUPPACCOUNTCODE,A.CHALLAN_NO, A.CHALLAN_DATE,C.COUNTNAME, ")
            .Append(" A.ITEMCODE, A.BOOKVNO,A.LRNO, ")
            .Append(" A.PROD_LOTNO,A.PROD_SHADENO, ")
            .Append(" E.TRANSPORTNAME,E.ID, ")
            .Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE,G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ORDER BY VAL(A.CHALLAN_NO), C.COUNTNAME ")
        End With

        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book44(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal BillDate As String, ByVal BookCode_FilterString As String) As String

        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.BAGS) AS PCS, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS WEIGHT, ")
            .Append(" a.ENTRYNO, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" A.GREY_MTR AS RATE, ")
            .Append(" A.LOTNO,A.SHADENO,' '  AS DELIVERY_AT, ")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME ")
            .Append(" ,a.shadecode as PROD_SHADENO ")
            .Append(" FROM TRNFACTORYYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPP_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.SUPPLIER_CODE='" & AccountCode & "'")
            .Append(BookCode_FilterString)
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL  WHERE  CHALLANBOOKVNO IS NOT NULL ) ")
            .Append(" GROUP BY")
            .Append(" A.CHALLANNO , ")
            .Append(" A.CHALLANDATE, ")
            .Append(" C.COUNTNAME, ")
            .Append(" a.ENTRYNO, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" E.ID, ")
            .Append(" A.COUNTCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE , ")
            .Append(" G.CITYCODE , ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME , ")
            .Append(" H.ACCOUNTCODE , ")
            .Append(" H.ACCOUNTNAME , ")
            .Append(" A.GREY_MTR , ")
            .Append(" A.LOTNO,A.SHADENO, ")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME ")
            .Append(" ,a.shadecode ")
            .Append(" ORDER BY A.CHALLANDATE,A.BOOKVNO ")
        End With

        Return strQuery.ToString
    End Function
    Public Function EntryData_Yarn_Invoice_txtUse_Challan_Validated_Book38(ByVal _BookVNo As String, ByVal AccountCode As String, ByVal BillDate As String) As String
        strQuery = New StringBuilder

        With strQuery
            .Append(" SELECT ")
            .Append(" SPACE(1) AS MARK, ")
            .Append(" A.CHALLANNO AS CHALLANNO, ")
            .Append(" FORMAT(A.CHALLANDATE,'dd/MM/yyyy') AS F_CHALLANDATE, ")
            .Append(" 'BAGS' AS CUTNAME, ")
            .Append(" C.COUNTNAME, ")
            .Append(" SUM(A.BAGS) AS PCS, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS MTR_WEIGHT, ")
            .Append(" SUM(A.ACTUAL_WEIGHT) AS WEIGHT, ")
            .Append(" '.' AS ACOFNAME, ")
            .Append(" E.TRANSPORTNAME, ")
            .Append(" 'KGS' AS RATEON, ")
            .Append(" E.ID AS TRANSPORTCODE , ")
            .Append(" '0000-000000001' AS ACOFCODE, ")
            .Append(" '0000-000000001' AS CUTCODE, ")
            .Append(" A.COUNTCODE AS ITEMCODE, ")
            .Append(" A.BOOKVNO, ")
            .Append(" A.SUPP_CODE AS ACCOUNTCODE, ")
            .Append(" G.CITYCODE AS DESPATCHCODE, ")
            .Append(" F.ACCOUNTNAME, ")
            .Append(" G.CITYNAME AS DESPATCH, ")
            .Append(" H.ACCOUNTCODE AS AGENTCODE, ")
            .Append(" H.ACCOUNTNAME AS AGENTNAME, ")
            .Append(" 0 AS RATE, ")
            .Append(" A.LOTNO,A.SHADENO,' '  AS DELIVERY_AT, ")
            .Append(" A.FACTORY_CODE, ")
            .Append(" J.ACCOUNTNAME AS FACTORYNAME ")
            .Append(" ,'' as PROD_SHADENO ")
            .Append(" FROM TRNFACTORYYARN AS A,MSTYARNCOUNT AS C,MSTTRANSPORT E, ")
            .Append(" MstMasterAccount AS F,MSTCITY AS G,MstMasterAccount AS H,MstMasterAccount J ")
            .Append(" WHERE 1=1 AND A.FACTORY_CODE=J.ACCOUNTCODE ")
            .Append(" AND A.SUPP_CODE=F.ACCOUNTCODE ")
            .Append(" AND F.CITYCODE=G.CITYCODE ")
            .Append(" AND F.AGENTCODE=H.ACCOUNTCODE ")
            .Append(" AND A.COUNTCODE=C.COUNTCODE ")
            .Append(" AND A.TRANSPORTCODE=E.ID ")
            .Append(" AND A.BOOKVNO<>'" & _BookVNo & "' ")
            .Append(" AND A.ACCOUNTCODE='" & AccountCode & "'")
            .Append(" AND A.CHALLANDATE<='" & BillDate & "' ")
            .Append(" AND A.BOOKCODE='0001-000000146' ")
            .Append(" AND A.BOOKVNO NOT IN (SELECT CHALLANBOOKVNO AS BOOKVNO FROM TRNINVOICEDETAIL   WHERE  CHALLANBOOKVNO IS NOT NULL) ")
            .Append(" GROUP BY A.SUPP_CODE,A.CHALLANNO, A.CHALLANDATE,C.COUNTNAME,A.ENTRYNO, ")
            .Append(" A.COUNTCODE, A.BOOKVNO,A.FACTORY_CODE,J.ACCOUNTNAME, ")
            .Append(" A.LOTNO,A.SHADENO, ")
            .Append(" E.TRANSPORTNAME,E.ID, ")
            .Append(" A.ACCOUNTCODE,F.ACCOUNTNAME,G.CITYCODE, ")
            .Append(" G.CITYNAME,H.ACCOUNTCODE,H.ACCOUNTNAME ")
            .Append(" ORDER BY A.CHALLANDATE,A.BOOKVNO ")
        End With
        Return strQuery.ToString
    End Function



#End Region


    Public Function EntryData_General_Offer_getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT  TrnOffer.*, ")
            .Append(" FORMAT(TrnOffer.OfferDate,'dd/MM/yyyy') as F_OFFERDATE, ")
            .Append(" FORMAT(TrnOffer.OfferDate,'dd/MM/yyyy') as F_OFFERCLEARDATE, ")
            .Append(" MstCity.cityname AS DESPATCH, ")
            .Append(" B.Countname AS ITEMNAME, ")
            .Append(" D.ACCOUNTNAME, ")
            .Append(" MstTransport.TransportName, ")
            .Append(" F.AC_NAME AS AcOfName ")
            .Append(" ,G.ITEMNAME AS PARTYITEMNAME ")
            .Append(" FROM ")
            .Append(" TRNOFFER")
            .Append(" LEFT JOIN MSTCITY ON TRNOFFER.DESPATCHCODE=MSTCITY.CITYCODE")
            .Append(" LEFT JOIN MstYarnCount as B ON TRNOFFER.ITEMCODE=B.COUNTCODE")
            .Append(" LEFT JOIN MstMasterAccount AS D ON TRNOFFER.ACCOUNTCODE=D.ACCOUNTCODE  ")
            .Append(" LEFT JOIN MSTTRANSPORT ON TRNOFFER.TRANSPORTCODE=MSTTRANSPORT.ID")
            .Append(" LEFT JOIN Mst_Acof_Supply AS F ON TRNOFFER.ACOFCODE=F.ID")

            .Append(" LEFT JOIN MSTSTOREITEM  AS G ON TRNOFFER.weavetypecode=G.ITEMCODE")
            .Append(" WHERE 1=1 ")
            .Append(" AND TRNOFFER.BOOKVNO='" & strKeyID & "'")
            .Append(" ORDER BY TRNOFFER.SRNO ")
        End With
        Return strQuery.ToString
    End Function
    Public Function EntryData_General_Offer_txtBookName_Validated(ByVal _BookCode As String) As String
        strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT TOP 1 A.*, ")
            .Append(" FORMAT(A.OFFERDATE,'dd/MM/yyyy') AS F_OFFERDATE, ")
            .Append(" B.ACCOUNTNAME,C.AC_NAME AS ACOFNAME,F.ACCOUNTNAME AS AGENTNAME,")
            .Append(" D.TRANSPORTNAME,E.CITYNAME AS DESPATCH ")
            .Append(" FROM TRNOFFER AS A")
            .Append(" left join MstMasterAccount AS B ON  A.ACCOUNTCODE=B.ACCOUNTCODE")
            .Append(" left join Mst_Acof_Supply AS C ON A.ACOFCODE=C.ID  ")
            .Append(" left join MSTTRANSPORT D ON  A.TRANSPORTCODE=D.id ")
            .Append(" left join MSTCITY E  ON  A.DESPATCHCODE=E.CITYCODE ")
            .Append(" left join MstMasterAccount AS F  ON B.AGENTCODE=F.ACCOUNTCODE")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "'" & " ")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return strQuery.ToString
    End Function


End Class
