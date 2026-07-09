Imports System.Text

Public Class RawApproval
    Private _TblName As String = "TrnPackingSlip"
    Private _KeyFieldName As String = "Id"
    Dim _CloseCheck As Boolean = False
    Private _BookCode As String = ""
    Private WithEvents txtUnitCode As New System.Windows.Forms.TextBox()
    Private Book_Row As DataRow
    Private AcCode_Filter_String As String = ""
    Private _FrmLoad As Boolean = True
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = "Raw Materials Report From : Approval By Plant Head Details "
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub StoreApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        _CloseCheck = True
        _FrmLoad = False
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        Generate_Date_For_DataBase(txt_From)
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_To)
        'View_Record()
    End Sub
    Private Sub View_Record()
        If txt_Status.Text = "ALL" AndAlso txtUnitCode.Text = "" Then
            MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtUnitName.Focus()
            Exit Sub
        End If
        If txtUnitCode.Text = "" Then
            MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtUnitName.Focus()
            Exit Sub
        End If
        Dim dateFilter As String = ""
        Dim StatusFilter As String = ""
        Dim TypeFilter As String = ""
        Dim Unitfilter As String = ""
        If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
            'dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "'"
        End If
        If Not String.IsNullOrEmpty(txt_Status.Text) Then
            If txtUnitCode.Text.Trim <> "" Then
                Unitfilter = " AND A.GodownCode = '" & txtUnitCode.Text.Trim & "' "
            End If
            If UCase(txt_Status.Text.Trim) = "ALL" Then
                StatusFilter = ""
                dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "' "

            ElseIf UCase(txt_Status.Text.Trim) = "YES" Then
                'StatusFilter = " AND UPPER(A.OP19) = 'YES' "
                StatusFilter = " AND ISDATE(ISNULL(A.OP22,'1900-01-01 00:00:00.000')) = 1 " &
                 " AND CAST(ISNULL(A.OP22,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                 " AND CAST(ISNULL(A.OP22,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "' " &
                 " AND UPPER(A.OP19) = 'YES' "

            ElseIf UCase(txt_Status.Text.Trim) = "NO" Then
                'StatusFilter = " AND UPPER(A.OP19) = 'NO' "
                StatusFilter = " AND CAST(ISNULL(A.PACK_SLIP_DATE,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                 " AND CAST(ISNULL(A.PACK_SLIP_DATE,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "' " &
                 " AND UPPER(A.OP19) = 'NO' "
            End If
        End If
        Dim _UserQuery As New StringBuilder()
        With _UserQuery
            .Append(" SELECT   A.ENTRYNO As [Entry No],")
            .Append(" FORMAT(A.PACK_SLIP_DATE,'dd/MM/yyyy') as Date, ")
            .Append(" CASE WHEN A.ENTRYDATE = '1900-01-01 00:00:00.000' THEN '' ")
            .Append(" ELSE FORMAT(A.ENTRYDATE,'dd/MM/yyyy hh:mm:ss.fff tt') END AS [Entry Date],")
            .Append(" A.PACK_SLIP_NO AS [Req. No],")
            .Append(" A.ITEMCODE,")
            .Append(" A.BOOKVNO,")
            .Append(" A.DESIGNCODE,")
            .Append(" A.SHADECODE,")
            .Append(" A.CUTCODE,")
            .Append(" A.GODOWNCODE,")
            .Append(" B.ItemName AS ItemName, ")
            .Append(" MstCutMaster.CUTNAME As UOM, ")
            .Append(" K.TYPE_NAME AS Brand, ")
            .Append(" FORMAT(SUM(Z.INQTY)-SUM(Z.OUTQTY),'0.00') AS Qty,")
            .Append(" CASE WHEN ISDATE(A.OP22)=1 THEN CONVERT(VARCHAR(10),CAST(A.OP22 AS DATETIME),103) ELSE '' END AS OP22,")
            .Append(" CASE WHEN UPPER(A.OP19)='YES' THEN 'YES' ELSE 'NO' END AS Status ")
            .Append(" ,CASE WHEN L.BOOKVNO IS NULL THEN 'NO'    ELSE 'YES'END AS Status1")
            .Append(" FROM (")
            .Append(" SELECT ")
            .Append(" BOOKVNO, ITEMCODE, DESIGNCODE, SHADECODE, CUTCODE, ")
            .Append(" MTR_WEIGHT AS INQTY, ")
            .Append(" 0.00 AS OUTQTY ")
            .Append(" FROM TrnPackingSlip ")
            .Append(" WHERE BOOKCODE='0001-000010012' ")
            .Append(" AND GodownCode = '" & txtUnitCode.Text.Trim & "'  ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" OP7 AS BOOKVNO, ITEMCODE, DESIGNCODE, SHADECODE, CUTCODE, ")
            .Append(" 0.00 AS INQTY, ")
            .Append(" MTR_WEIGHT AS OUTQTY ")
            .Append(" FROM TrnPackingSlip ")
            .Append(" WHERE BOOKCODE='0001-000010013' ")
            .Append(" AND GodownCode = '" & txtUnitCode.Text.Trim & "'  ")
            .Append(" ) Z ")
            .Append(" left JOIN " & _TblName & " A ")
            .Append(" ON (A.BOOKVNO = Z.BOOKVNO ")
            .Append(" AND A.ITEMCODE = Z.ITEMCODE ")
            .Append(" AND A.DESIGNCODE = Z.DESIGNCODE ")
            .Append(" AND A.SHADECODE = Z.SHADECODE ")
            .Append(" AND A.CUTCODE = Z.CUTCODE ")
            .Append(" AND A.BOOKCODE='0001-000010012') ")
            .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE ")
            .Append(" LEFT JOIN MstStoreItem B ON A.ITEMCODE=B.ITEMCODE ")
            .Append(" LEFT JOIN MstMasterAccount ON A.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTTRANSPORT ON A.TRANSPORTCODE=MSTTRANSPORT.ID ")
            .Append(" LEFT JOIN MstMasterAccount C ON MstMasterAccount.AGENTCODE=C.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Acof_Supply ON A.ACOFCODE=Mst_Acof_Supply.ID ")
            .Append(" LEFT JOIN MstCutMaster ON MstCutMaster.ID=A.CUTCODE ")
            .Append(" LEFT JOIN MstStoreItemType K ON A.SHADECODE=K.TYPE_ID ")
            .Append(" LEFT JOIN MstDepartment E ON A.DESIGNCODE=E.Departmentcode ")
            .Append(" LEFT JOIN MstColor F ON A.CUTCODE1=F.COLORCODE ")
            .Append(" LEFT JOIN (SELECT OP7 AS BOOKVNO ,AccountCode,DESIGNCODE,SHADECODE,GODOWNCODE,ITEMCODE FROM TrnPackingSlip   WHERE BOOKTRTYPE in ('RAW04') GROUP BY OP7,ITEMCODE ,AccountCode,DESIGNCODE,SHADECODE,GODOWNCODE ) AS L ON  A.BOOKVNO = L.BOOKVNO and A.GodownCode = L.GodownCode and A.AccountCode = L.AccountCode and A.DESIGNCODE = L.DESIGNCODE and A.SHADECODE = L.SHADECODE  and A.ITEMCODE = L.ITEMCODE   ")
            .Append(" WHERE 1=1 ")
            .Append(Unitfilter)
            .Append(dateFilter)
            .Append(StatusFilter)
            .Append(TypeFilter)
            .Append(" GROUP BY ")
            .Append(" A.ENTRYNO,")
            .Append(" A.GODOWNCODE,")
            .Append(" A.PACK_SLIP_DATE,")
            .Append(" A.ENTRYDATE,")
            .Append(" A.PACK_SLIP_NO,")
            .Append(" A.ITEMCODE,")
            .Append(" A.DESIGNCODE,")
            .Append(" A.SHADECODE,")
            .Append(" A.CUTCODE,")
            .Append(" A.BOOKVNO,")
            .Append(" B.ItemName,")
            .Append(" MstCutMaster.CUTNAME,")
            .Append(" K.TYPE_NAME,")
            .Append(" L.BOOKVNO,")
            .Append(" A.OP22,")
            .Append(" A.OP19 ")
            .Append(" HAVING SUM(Z.INQTY)-SUM(Z.OUTQTY) > 0 ")
            .Append(" ORDER BY A.ENTRYNO ")
        End With
        Dim tblTmp As DataTable
        sqL = _UserQuery.ToString()
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy
        Dim Qty As String = ""
        If tblTmp.Rows.Count > 0 Then
            If Not tblTmp.Columns.Contains("IsOriginalApproval") Then
                tblTmp.Columns.Add("IsOriginalApproval", GetType(Boolean))
            End If
            For Each dr As DataRow In tblTmp.Rows
                dr("IsOriginalApproval") = (Convert.ToString(dr("Status1")).Trim().ToUpper() = "YES")
            Next
            GridControl1.DataSource = tblTmp.Copy
            AddHandler FirstStage.RowStyle, AddressOf bandedView_RowStyle
            For Each dc As DataColumn In tblTmp.Columns
                Dim isEmptyOrZero As Boolean = True
                If dc.ColumnName.ToUpper() = "ID" Or dc.ColumnName.ToUpper() = "ITEMCODE" Or dc.ColumnName.ToUpper() = "BOOKVNO" Or dc.ColumnName.ToUpper() = "OP22" Or dc.ColumnName.ToUpper() = "DESIGNCODE" Or dc.ColumnName.ToUpper() = "SHADECODE" Or dc.ColumnName.ToUpper() = "CUTCODE" Or dc.ColumnName.ToUpper() = "GODOWNCODE" Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                    Continue For
                End If
                If dc.ColumnName.Equals("Entry Date", StringComparison.OrdinalIgnoreCase) Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                    Continue For
                End If
                For Each dr As DataRow In tblTmp.Rows
                    If Not IsDBNull(dr(dc)) Then
                        Dim val As String = dr(dc).ToString().Trim()
                        ' 🔴 अगर कोई value meaningful है → column visible रहेगा
                        If val <> "" AndAlso val <> "0" AndAlso val <> "0.00" Then
                            isEmptyOrZero = False
                            Exit For
                        End If
                    End If
                Next
                If isEmptyOrZero Then
                    FirstStage.Columns(dc.ColumnName).Visible = False
                End If
            Next
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
            Next

            ' Step 2: Sirf required columns editable
            'FirstStage.Columns("Menu").OptionsColumn.AllowEdit = True
            FirstStage.Columns("IsOriginalApproval").Visible = False
            FirstStage.Columns("Status1").Visible = False
            DevGridFitColumn(GridControl1, FirstStage)
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            GridControl1.BringToFront()
            FirstStage.OptionsBehavior.Editable = True
            FirstStage.OptionsBehavior.ReadOnly = False
            FirstStage.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Sub bandedView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView =
        CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.RowHandle < 0 Then Exit Sub

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
            If col.FieldName.EndsWith("Status1") Then
                Dim val As Object = view.GetRowCellValue(e.RowHandle, col)
                If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                    Dim status As String = val.ToString.Trim.ToUpper
                    If status = "TRUE" OrElse status = "1" OrElse status = "Y" OrElse status = "YES" Then
                        e.Appearance.ForeColor = Color.Red
                        e.HighPriority = True
                        'Exit For
                    End If
                End If

            ElseIf col.FieldName.EndsWith("Status") Then
                Dim val As Object = view.GetRowCellValue(e.RowHandle, col)
                If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                    Dim status As String = val.ToString.Trim.ToUpper
                    If status = "TRUE" OrElse status = "1" OrElse status = "Y" OrElse status = "YES" Then
                        e.Appearance.BackColor = Color.LemonChiffon
                        e.HighPriority = True
                        'Exit For
                    End If
                End If
            End If
        Next

    End Sub
    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        For Each dr As DataRow In dt.Rows
            If dr.RowState = DataRowState.Modified Then
                Dim cmd As New SqlClient.SqlCommand()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 420
                cmd.CommandText =
            "UPDATE " & _TblName & " SET " &
            "OP19 = @OP19, " &
            "OP22 = @MODYFIDATE " &
            " WHERE BOOKVNO = @BOOKVNO " &
            " AND ITEMCODE = @ITEMCODE" &
            " AND DESIGNCODE = @DESIGNCODE" &
            " AND SHADECODE = @SHADECODE" &
            " AND CUTCODE = @CUTCODE" &
            " AND GODOWNCODE = @GODOWNCODE"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@OP19", dr("STATUS").ToString())
                cmd.Parameters.AddWithValue("@MODYFIDATE", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"))
                cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
                cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
                cmd.Parameters.AddWithValue("@DESIGNCODE", dr("DESIGNCODE").ToString())
                cmd.Parameters.AddWithValue("@SHADECODE", dr("SHADECODE").ToString())
                cmd.Parameters.AddWithValue("@CUTCODE", dr("CUTCODE").ToString())
                cmd.Parameters.AddWithValue("@GODOWNCODE", dr("GODOWNCODE").ToString())
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End If
        Next
        conn.Close()
        MessageBox.Show("Data Updated Successfully")
    End Sub
    Private Sub FirstStage_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown, FirstStage.KeyDown
        If e.KeyCode = Keys.Space Then
            If FirstStage.FocusedColumn.FieldName = "Status" Then
                Dim IsOriginalApproval As Boolean = False
                If FirstStage.GetFocusedRowCellValue("IsOriginalApproval") IsNot DBNull.Value Then
                    IsOriginalApproval = Convert.ToBoolean(FirstStage.GetFocusedRowCellValue("IsOriginalApproval"))
                End If
                If IsOriginalApproval Then
                    e.Handled = True
                    Exit Sub
                End If
                Dim currentValue As String = FirstStage.GetFocusedRowCellValue("Status").ToString().ToUpper()
                If currentValue = "YES" Then
                    FirstStage.SetFocusedRowCellValue("Status", "NO")
                Else
                    FirstStage.SetFocusedRowCellValue("Status", "YES")
                End If
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _CloseCheck = True
        View_Record()
    End Sub

    Private Sub StoreApproval_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If _CloseCheck = True Then
                Close()
                Me.Dispose(True)
            Else
                _CloseCheck = True
                txt_From.Focus()
            End If
            _FrmLoad = False
        End If
    End Sub
#Region "Txt Book Name Events Code "
    Private Sub txtUnitName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitName.KeyPress
        If Asc(e.KeyChar) = 27 Then Exit Sub


        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            Dim _Filterstring As String = " AND A.BOOKCATEGORY='FACTORY-BEAM'"
            Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtUnitName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtUnitCode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("BookName") Then txtUnitName.Text = selected("BookName").ToString()
            End If
            '_BookCode = txtBookCode.Text
            SendKeys.Send("{TAB}")
            If _BookCode <> "" Then
                Dim TmpTbl As New DataTable
                sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & _BookCode & "' "
                sql_connect_slect()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    Book_Row = TmpTbl(0)
                    AcCode_Filter_String = TmpTbl(0)("GROUP_CODE_FILTER_STRING").ToString
                    '_BookTrType = TmpTbl(0)("BOOKTRTYPE").ToString
                End If

            End If
        End If
        'e.Handled = True
    End Sub
    Private Sub txtUnitName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUnitName.Validated
        '_Validated()
    End Sub
#End Region
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