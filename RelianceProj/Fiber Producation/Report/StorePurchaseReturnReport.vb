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
                View_Filter_Condition = " AND S.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And S.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "' "
            End If
            _strQuery = New StringBuilder()
            With _strQuery
                .Append(" WITH StockTrans AS ( ")
                .Append(" SELECT ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.CUTCODE, ")
                .Append(" A.DESIGNCODE, ")
                .Append(" A.SHADECODE, ")
                .Append(" A.GODOWNCODE, ")
                .Append(" A.Mtr_weight AS INQTY, ")
                .Append(" 0.00 AS OUTQTY ")
                .Append(" FROM TrnPackingSlip A ")
                .Append(" WHERE A.BOOKCODE In ('STOP-000000001','IPSS-000000001') ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.PACK_SLIP_DATE, ")
                .Append(" A.ACCOUNTCODE, ")
                .Append(" A.ITEMCODE, ")
                .Append(" A.CUTCODE, ")
                .Append(" A.DESIGNCODE, ")
                .Append(" A.SHADECODE, ")
                .Append(" A.GODOWNCODE, ")
                .Append(" 0.00 AS INQTY, ")
                .Append(" A.Mtr_weight AS OUTQTY ")
                .Append(" FROM TrnPackingSlip A ")
                .Append(" WHERE A.BOOKCODE IN ('IDSS-000000001') ")
                .Append(" ) ")
                .Append(" SELECT ")
                .Append(" B.ItemName, ")
                .Append(" C.TYPE_NAME AS Brand, ")
                .Append(" C.TYPE_ID AS GROUPCODE, ")
                .Append(" D.CUTNAME AS UOM, ")
                .Append(" E.DEPARTMENTNAME AS DepartmentName, ")
                .Append(" E.Departmentcode AS CITYCODE, ")
                .Append(" F.ACCOUNTNAME AS AccountName, ")
                .Append(" G.BookName, ")
                .Append(" SUM(Z.Opening) as  Opening, ")
                .Append(" SUM(Z.InQty) AS InQty, ")
                .Append(" SUM(Z.OutQty) AS OutQty, ")
                .Append(" (SUM(Z.Opening)+SUM(Z.InQty))-SUM(Z.OutQty) as  Balance ")
                .Append(" FROM ( ")
                .Append(" SELECT ")
                .Append(" s.ITEMCODE, ")
                .Append(" s.SHADECODE, ")
                .Append(" s.CUTCODE, ")
                .Append(" s.DESIGNCODE, ")
                .Append(" s.ACCOUNTCODE, ")
                .Append(" s.GODOWNCODE, ")
                .Append(" 0.00 as  Opening, ")
                .Append(" CAST(S.INQTY AS DECIMAL(18,2)) AS InQty, ")
                .Append(" CAST(S.OUTQTY AS DECIMAL(18,2)) AS OutQty ")
                .Append(" FROM StockTrans S ")
                .Append(" WHERE 1=1 ")
                .Append(View_Filter_Condition)
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" s.ITEMCODE, ")
                .Append(" s.SHADECODE, ")
                .Append(" s.CUTCODE, ")
                .Append(" s.DESIGNCODE, ")
                .Append(" s.ACCOUNTCODE, ")
                .Append(" s.GODOWNCODE, ")
                .Append("  CAST(S.INQTY AS DECIMAL(18,2))-CAST(S.OUTQTY AS DECIMAL(18,2)) as  Opening, ")
                .Append(" 0.00 AS InQty, ")
                .Append(" 0.00 AS OutQty ")
                .Append(" FROM StockTrans S ")
                .Append(" WHERE 1=1 ")
                .Append("  AND S.PACK_SLIP_DATE < '" & txt_From.Date_for_Database & "' ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstStoreItem B ON Z.ITEMCODE = B.ITEMCODE ")
                .Append(" LEFT JOIN MstStoreItemType C  ON Z.SHADECODE = C.TYPE_ID")
                .Append(" LEFT JOIN MstCutMaster D ON Z.CUTCODE = D.ID ")
                .Append(" LEFT JOIN MstDepartment E ON Z.DESIGNCODE = E.Departmentcode")
                .Append(" LEFT JOIN MstMasterAccount F ON Z.ACCOUNTCODE = F.ACCOUNTCODE  ")
                .Append(" Left Join MSTBook AS G ON Z.GodownCode = G.BookCode ")
                .Append(" WHERE 1=1 ")
                .Append(" GROUP BY ")
                .Append(" B.ItemName, ")
                .Append(" C.TYPE_NAME , ")
                .Append(" C.TYPE_ID , ")
                .Append(" D.CUTNAME, ")
                .Append(" E.DEPARTMENTNAME , ")
                .Append(" E.Departmentcode , ")
                .Append(" Z.GODOWNCODE , ")
                .Append(" G.BookName , ")
                .Append(" F.ACCOUNTNAME ")
                .Append(" ORDER BY ")
                .Append(" E.DEPARTMENTNAME, ")
                .Append(" B.ItemName ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim Tmp_Data_Table As New DataTable
            Tmp_Data_Table = DefaltSoftTable.Copy
            If Tmp_Data_Table.Rows.Count > 0 Then
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
            'If _CheckFormLoad = True Then
            '    _ButtonFocus()
            'Else
            Me.Close()
            Me.Dispose(True)
            'End If
        End If
    End Sub
    Private Sub _ButtonFocus()
        _CheckFormLoad = False
    End Sub
End Class