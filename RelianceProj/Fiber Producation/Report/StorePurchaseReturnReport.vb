Imports System.Text

Public Class StorePurchaseReturnReport
    Dim _CheckFormLoad As Boolean = True
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub
    Private Sub View_Log_Book()
        Try
            Dim View_Filter_Condition As String = ""
            If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
                'View_Filter_Condition = " AND Z.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And Z.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "' "
                View_Filter_Condition = " AND S.PACK_SLIP_DATE >=  '" & txt_From.Text & "' And S.PACK_SLIP_DATE <=  '" & txt_To.Text & "' "
            End If
            _strQuery = New StringBuilder()
            'With _strQuery
            '    .Append(" SELECT ")
            '    .Append(" 'False' AS TickMark, ")
            '    '.Append(" a.PACK_SLIP_NO As [Req No], ")
            '    .Append(" B.ItemName AS ItemName, ")
            '    '.Append(" A.BOOKVNO As ID, ")
            '    '.Append(" Z.PACK_SLIP_DATE, ")
            '    .Append(" C.TYPE_NAME AS Brand, ")
            '    .Append(" C.TYPE_ID AS GROUPCODE, ")
            '    .Append(" D.CUTNAME AS UOM, ")
            '    .Append(" E.DEPARTMENTNAME AS DepartmentName, ")
            '    .Append(" E.Departmentcode AS CITYCODE, ")
            '    .Append(" Z.CUTCODE as CountCode, ")
            '    .Append(" Z.ITEMCODE As ItemCode, ")
            '    .Append(" FORMAT(SUM(Z.INQTY),'0.00') As InQty, ")
            '    .Append(" FORMAT(SUM(Z.OUTQTY),'0.00') As OutQty, ")
            '    .Append(" FORMAT(SUM(Z.INQTY)-SUM(Z.OUTQTY),'0.00') As Balance ")
            '    '.Append(" B.HSNCODE AS HsnCode ")
            '    .Append(" FROM ( ")
            '    .Append(" SELECT ")
            '    .Append(" A.Mtr_weight AS INQTY, ")
            '    .Append(" 0.00 AS OUTQTY, ")
            '    .Append(" A.BOOKVNO, ")
            '    .Append(" A.CUTCODE, ")
            '    .Append("   FORMAT(a.PACK_SLIP_DATE,'dd/MM/yyyy') As PACK_SLIP_DATE, ")
            '    .Append(" A.ITEMCODE, ")
            '    .Append(" A.DESIGNCODE, ")
            '    .Append(" A.SHADECODE ")
            '    .Append(" FROM TrnPackingSlip AS A ")
            '    .Append(" WHERE 1=1 ")
            '    .Append(" And A.Bookcode in ('STOP-000000001') ")
            '    .Append(" UNION ALL ")
            '    .Append(" SELECT ")
            '    .Append(" 0.00 AS INQTY, ")
            '    .Append(" A.Mtr_weight AS OUTQTY, ")
            '    .Append(" A.OP7 As BOOKVNO, ")
            '    .Append(" A.CUTCODE, ")
            '    .Append("   FORMAT(a.PACK_SLIP_DATE,'dd/MM/yyyy') As PACK_SLIP_DATE, ")
            '    .Append(" A.ITEMCODE, ")
            '    .Append(" A.DESIGNCODE, ")
            '    .Append(" A.SHADECODE ")
            '    .Append(" FROM TrnPackingSlip AS A ")
            '    .Append(" JOIN TrnPackingSlip AS B ON (A.OP7 = B.BOOKVNO AND A.ITEMCODE = B.ITEMCODE) ")
            '    .Append(" WHERE 1=1 ")
            '    .Append(" And A.Bookcode in ('PRSS-000000001','IDSS-000000001')  ")
            '    .Append(" ) AS Z ")
            '    '.Append(" LEFT JOIN ( ")
            '    '.Append(" SELECT ENTRYNO, ")
            '    '.Append(" PACK_SLIP_NO, ")
            '    '.Append(" PACK_SLIP_DATE, ")
            '    '.Append(" BOOKVNO ")
            '    '.Append(" FROM TrnPackingSlip As A")
            '    '.Append(" WHERE 1=1 ")
            '    '.Append(" GROUP BY ENTRYNO,  ")
            '    '.Append(" PACK_SLIP_NO, ")
            '    '.Append(" PACK_SLIP_DATE, ")
            '    '.Append(" BOOKVNO ")
            '    '.Append(" ) AS A ON (Z.BOOKVNO = A.BOOKVNO) ")
            '    .Append(" LEFT JOIN MstStoreItem AS B ON Z.ITEMCODE = B.ITEMCODE ")
            '    .Append(" LEFT JOIN MstStoreItemType AS C ON Z.SHADECODE = C.TYPE_ID ")
            '    .Append(" LEFT JOIN MstCutMaster AS D ON Z.CUTCODE = D.ID ")
            '    .Append(" LEFT JOIN MstDepartment AS E ON Z.DESIGNCODE = E.Departmentcode ")
            '    .Append(" WHERE 1=1 ")
            '    .Append(View_Filter_Condition)
            '    .Append(" GROUP BY ")
            '    '.Append(" A.PACK_SLIP_NO, ")
            '    '.Append(" Z.PACK_SLIP_DATE, ")
            '    '.Append(" A.BOOKVNO, ")
            '    '.Append(" Z.BOOKVNO, ")
            '    .Append(" Z.CUTCODE, ")
            '    .Append(" Z.ITEMCODE, ")
            '    .Append(" Z.DESIGNCODE, ")
            '    .Append(" Z.SHADECODE, ")
            '    .Append(" B.ItemName, ")
            '    '.Append(" B.HSNCODE, ")
            '    .Append(" C.TYPE_NAME, ")
            '    .Append(" C.TYPE_ID, ")
            '    .Append(" D.CUTNAME, ")
            '    .Append(" E.DEPARTMENTNAME, ")
            '    .Append(" E.Departmentcode ")
            '    .Append(" HAVING SUM(Z.INQTY) - SUM(Z.OUTQTY) <> 0 ")
            '    .Append(" ORDER BY")
            '    .Append(" E.DEPARTMENTNAME,")
            '    .Append(" B.ItemName ")

            'End With
            With _strQuery

                .Append(" WITH StockTrans AS ( ")

                .Append(" SELECT ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" A.BOOKVNO, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.CUTCODE, ")
                .Append(" A.DESIGNCODE, ")
                .Append(" A.SHADECODE, ")
                .Append(" A.Mtr_weight AS INQTY, ")
                .Append(" 0.00 AS OUTQTY ")
                .Append(" FROM TrnPackingSlip A ")
                .Append(" WHERE A.BOOKCODE = 'STOP-000000001' ")

                .Append(" UNION ALL ")

                .Append(" SELECT ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" A.OP7 AS BOOKVNO, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.CUTCODE, ")
                .Append(" A.DESIGNCODE, ")
                .Append(" A.SHADECODE, ")
                .Append(" 0.00 AS INQTY, ")
                .Append(" A.Mtr_weight AS OUTQTY ")
                .Append(" FROM TrnPackingSlip A ")
                .Append(" WHERE A.BOOKCODE IN ('PRSS-000000001','IDSS-000000001') ")

                .Append(" ) ")

                .Append(" SELECT ")
                .Append(" FORMAT(S.PACK_SLIP_DATE,'dd/MM/yyyy') AS [Date], ")
                .Append(" S.BOOKVNO, ")
                .Append(" B.ItemName, ")
                .Append(" C.TYPE_NAME AS Brand, ")
                .Append(" C.TYPE_ID AS GROUPCODE, ")
                .Append(" D.CUTNAME AS UOM, ")
                .Append(" E.DEPARTMENTNAME AS DepartmentName, ")
                .Append(" E.Departmentcode AS CITYCODE, ")
                .Append(" FORMAT(ISNULL(SUM(S.INQTY-S.OUTQTY) ")
                .Append(" OVER ( ")
                .Append(" PARTITION BY S.ITEMCODE ")
                .Append(" ORDER BY S.PACK_SLIP_DATE,  CAST(S.BOOKVNO AS VARCHAR(200)) ")
                .Append(" ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING ")
                .Append(" ),0),'0.00') AS Opening, ")

                .Append(" FORMAT(S.INQTY,'0.00') AS InQty, ")
                .Append(" FORMAT(S.OUTQTY,'0.00') AS OutQty, ")

                .Append(" FORMAT(SUM(S.INQTY-S.OUTQTY) ")
                .Append(" OVER ( ")
                .Append(" PARTITION BY S.ITEMCODE ")
                .Append(" ORDER BY S.PACK_SLIP_DATE, CAST(S.BOOKVNO AS VARCHAR(200)) ")
                .Append(" ),'0.00') AS Balance ")

                .Append(" FROM StockTrans S ")
                .Append(" LEFT JOIN MstStoreItem B ON S.ITEMCODE = B.ITEMCODE ")
                .Append(" LEFT JOIN MstStoreItemType C ")
                .Append(" ON S.SHADECODE = C.TYPE_ID ")

                .Append(" LEFT JOIN MstCutMaster D ")
                .Append(" ON S.CUTCODE = D.ID ")

                .Append(" LEFT JOIN MstDepartment E ")
                .Append(" ON S.DESIGNCODE = E.Departmentcode ")
                .Append(" WHERE 1=1 ")
                .Append(View_Filter_Condition)

                .Append(" ORDER BY ")
                .Append(" E.DEPARTMENTNAME, ")
                .Append(" B.ItemName, ")
                .Append(" S.PACK_SLIP_DATE, ")
                .Append(" S.BOOKVNO ")

            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim Tmp_Data_Table As New DataTable
            Tmp_Data_Table = DefaltSoftTable.Copy

            If Tmp_Data_Table.Rows.Count > 0 Then
                'Dim Date_Range = "Audit Report  From : " & txt_From.Text & " TO " & txt_To.Text
                Dim RptTitle = "Stores Purchase Return Stock Report :" & txt_From.Text & " TO " & txt_To.Text
                Dim Date_Range = ""
                If But_ok.Enabled = True Then
                    If txt_From.Text <> "" AndAlso txt_From.Text <> "" Then
                        REPORT_RPT_FILE_NAME = "StorePurchaseReturnStockReport_1"
                        NewReportPrint(Tmp_Data_Table, RptTitle, Date_Range)

                    End If
                End If
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub StorePurchaseReturnReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        Generate_Date_For_DataBase(txt_From)
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_To)
        txt_From.Focus()
    End Sub


    Private Sub StorePurchaseReturnReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If _CheckFormLoad = True Then
                _ButtonFocus()
            Else
                Me.Close()
                Me.Dispose(True)
            End If
        End If
    End Sub
    Private Sub _ButtonFocus()
        _CheckFormLoad = False
    End Sub

End Class