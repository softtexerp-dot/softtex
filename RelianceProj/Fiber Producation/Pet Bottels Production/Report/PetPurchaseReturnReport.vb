Imports System.Text

Public Class PetPurchaseReturnReport
    Dim _CheckFormLoad As Boolean = True
    Private WithEvents txtgodowncode As New TextBox
    Private _FrmLoad As Boolean = True
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub
    Private Sub View_Log_Book()
        Try
            Dim View_Filter_Condition As String = ""
            Dim View_UnitFilter_Condition As String = ""
            If txtgodowncode.Text.Trim <> "" Then
                Dim Codes = "'" & txtgodowncode.Text.Replace(",", "','") & "'"
                View_UnitFilter_Condition = " AND S.GodownCode IN (" & Codes & ") "
            End If
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
                .Append(" WHERE A.BOOKCODE In ('0001-000010001','0001-000010009','0001-000010021') ")
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
                .Append(" WHERE A.BOOKCODE IN ('0001-000010003') ")
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
                .Append(View_UnitFilter_Condition)
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
                Dim RptTitle = "Pet Stock Report :" & txt_From.Text & " TO " & txt_To.Text
                Dim Date_Range = ""
                If But_ok.Enabled = True Then
                    If txt_From.Text <> "" AndAlso txt_From.Text <> "" Then
                        REPORT_RPT_FILE_NAME = "PetPurchaseReturnStockReport_1"
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
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub StorePurchaseReturnReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        _FrmLoad = False
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
            _FrmLoad = False
        End If
    End Sub
    Private Sub _ButtonFocus()
        _CheckFormLoad = False
    End Sub
    Private Sub txtBookName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGodownName.KeyPress
        If Asc(e.KeyChar) = 27 Then Exit Sub


        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then

            'Dim _Filterstring As String = " AND A.BOOKCATEGORY='FACTORY-BEAM'"
            'Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)

            Dim _Filterstring As String = " AND A.BOOKCATEGORY='FACTORY-BEAM'"
            Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)
            Dim ExtracolumnsToHide = {""}
            'Dim selected = MultyAccountSelectionForm(_LoadQuery, Nothing, txtGodownName.Text, "SINGLE")
            'Dim selectedList1 = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), txtGodownName.Text, "MULTY")
            Dim SelectedaccountCode As New List(Of String)
            Dim selectedList1 = MultyAccountSelectionForm(_LoadQuery, GetType(Store_Item), "", "MULTY", SelectedaccountCode, ExtracolumnsToHide)
            If selectedList1 IsNot Nothing AndAlso selectedList1.Count > 0 Then

                txtgodowncode.Text = ""
                txtGodownName.Text = ""

                For Each row As Dictionary(Of String, Object) In selectedList1

                    If row.ContainsKey("ACCOUNTCODE") Then
                        If txtgodowncode.Text <> "" Then txtgodowncode.Text &= ","
                        txtgodowncode.Text &= row("ACCOUNTCODE").ToString()
                    End If

                    If row.ContainsKey("BookName") Then
                        If txtGodownName.Text <> "" Then txtGodownName.Text &= ", "
                        txtGodownName.Text &= row("BookName").ToString()
                    End If

                Next

            End If
            txt_From.Focus()
            txt_From.Select()
        End If
    End Sub

#Region "DATE RANGE CHECK"
    Private Sub txt_From_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_From.Validated
        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information, "Soft-Tex PRO")
                txt_From.Focus()
                txt_From.Select()
            End If
        End If
    End Sub
    Private Sub txt_To_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_To.Validated
        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information, "Soft-Tex PRO")
                txt_To.Focus()
                txt_To.Select()
            End If
        End If
    End Sub
#End Region
End Class