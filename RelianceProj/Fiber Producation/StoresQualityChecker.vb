Imports System.Text

Public Class StoresQualityChecker
    'Private _TblName As String = "TrnPackingSlip"
    Private _TblName As String = "TrnPackingSlip"
    Private _KeyFieldName As String = "Id"
    Dim _CloseCheck As Boolean = False
    Private _BookCode As String = ""
    Private WithEvents txtUnitCode As New System.Windows.Forms.TextBox()
    Private Book_Row As DataRow
    Private AcCode_Filter_String As String = ""
    Private _FrmLoad As Boolean = True
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = " Report From : Quality Check Details "
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
        Try
            'If txt_Status.Text <> "ALL" AndAlso txtUnitCode.Text = "" Then
            '    MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            '    txtUnitName.Focus()
            '    Exit Sub
            'End If
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
            If txtUnitCode.Text.Trim <> "" Then
                Unitfilter = " AND A.GodownCode = '" & txtUnitCode.Text.Trim & "' "
            End If
            If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
                dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "'"
            End If
            If Not String.IsNullOrEmpty(txt_Status.Text) Then
                If UCase(txt_Status.Text.Trim) = "ALL" Then
                    StatusFilter = ""
                ElseIf UCase(txt_Status.Text.Trim) = "YES" Then
                    StatusFilter = " AND UPPER(A.OP19) = 'YES' "
                ElseIf UCase(txt_Status.Text.Trim) = "NO" Then
                    StatusFilter = " AND UPPER(A.OP19) = 'NO' "
                ElseIf UCase(txt_Status.Text.Trim) = "REJECTION" Then
                    StatusFilter = " AND UPPER(A.OP19) = 'REJECTION' "
                End If
            End If
            If UCase(TxtType.Text.Trim) = "ALL" Then
                TypeFilter = " AND ( " &
                     " (ISDATE(ISNULL(A.OP22,'1900-01-01 00:00:00.000')) = 1 " &
                     " AND CAST(ISNULL(A.OP22,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.OP22,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "') " &
                     " OR " &
                     " (CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "') " &
                     " ) " '&
                '" AND UPPER(A.OP19) IN ('YES') "
            ElseIf UCase(TxtType.Text.Trim) = "APPROVE" Then
                TypeFilter = " AND ISDATE(ISNULL(A.OP22,'1900-01-01 00:00:00.000')) = 1 " &
                     " AND CAST(ISNULL(A.OP22,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.OP22,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "' " '&
                '" AND UPPER(A.OP19) = 'YES' "
            ElseIf UCase(TxtType.Text.Trim) = "PENDING" Then
                TypeFilter = " AND CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "' " '&
                ' " AND UPPER(A.OP19) = 'YES' "
            End If
            Dim _UserQuery As New StringBuilder()
            With _UserQuery
                .Append(" SELECT   A.ENTRYNO As [Entry No],")
                .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') as Date, ")
                .Append(" CASE WHEN A.ENTRYDATE = '1900-01-01 00:00:00.000' THEN '' ")
                .Append(" ELSE FORMAT(A.ENTRYDATE,'dd/MM/yyyy hh:mm:ss.fff tt') END AS [Entry Date],")
                .Append(" A.PACK_SLIP_NO AS [Quality No],")
                .Append(" A.ITEMCODE,")
                .Append(" A.BOOKVNO,")  'BookVNO
                .Append(" A.AccountCode,")
                .Append(" A.DESIGNCODE,")
                .Append(" A.SHADECODE,")
                .Append(" A.CUTCODE,")
                .Append(" A.SRNO,")
                .Append(" A.GODOWNCODE,")
                .Append(" B.ItemName AS ItemName, ")
                .Append(" C.AccountName, ")
                .Append(" FORMAT( A.Mtr_weight,'0.00') AS Qty, ")
                .Append(" CASE WHEN ISDATE(A.OP22) = 1 THEN FORMAT(TRY_CAST(A.OP22 AS DATETIME),'dd/MM/yyyy hh:mm:ss.fff tt')  ELSE '' END AS ApprovalDate,")  'Head Approval Date
                .Append(" CASE ")
                .Append("     WHEN UPPER(ISNULL(A.OP19,'')) = 'YES' THEN 'YES' ")
                .Append("     WHEN UPPER(ISNULL(A.OP19,'')) = 'REJECTION' THEN 'REJECTION' ")
                .Append("     ELSE 'NO' ")
                .Append(" END AS Status ")
                .Append(" ,CASE WHEN L.BOOKVNO IS NULL THEN 'NO'    ELSE 'YES'END AS Status1")
                .Append(" FROM  ")
                .Append(" " & _TblName & " AS A  ")
                .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
                .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE  ")
                .Append(" LEFT JOIN MstMasterAccount As C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstCutMaster As D ON D.ID=A.CUTCODE ")
                .Append(" LEFT JOIN MstStoreItemType K  ON  A.SHADECODE = K.TYPE_ID ")
                .Append(" LEFT JOIN (SELECT OP7 AS BOOKVNO ,AccountCode,DESIGNCODE,SHADECODE,GODOWNCODE,ITEMCODE FROM TrnPackingSlip   WHERE BOOKTRTYPE in ('IPSS1') GROUP BY OP7,ITEMCODE ,AccountCode,DESIGNCODE,SHADECODE,GODOWNCODE ) AS L ON  A.BOOKVNO = L.BOOKVNO and A.GodownCode = L.GodownCode and A.AccountCode = L.AccountCode and A.DESIGNCODE = L.DESIGNCODE and A.SHADECODE = L.SHADECODE  and A.ITEMCODE = L.ITEMCODE   ")
                .Append(" WHERE 1=1  ")
                '.Append(" And A.BOOKCODE='GISS-000000001'  ")
                .Append(" And A.BOOKTRTYPE in ('GISS1')  ")
                '.Append(" And A.OP19='YES'  ") ' comaprison status
                .Append("  AND NOT EXISTS ")
                .Append("  (   ")
                .Append(" SELECT 1  ")
                .Append(" FROM TrnPackingSlip AS B  ")
                .Append(" WHERE ")
                .Append(" B.OP22 = A.BookVno ")
                .Append(" And B.ITEMCODE = A.ITEMCODE ")
                .Append(" And B.GODOWNCODE=A.GODOWNCODE ")
                .Append("  )")
                .Append(Unitfilter)
                .Append(dateFilter)
                .Append(StatusFilter)
                .Append(TypeFilter)
                .Append(" Order By A.EntryNo ")
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
                    If dc.ColumnName.ToUpper() = "ID" Or dc.ColumnName.ToUpper() = "ACCOUNTCODE" Or dc.ColumnName.ToUpper() = "ITEMCODE" Or dc.ColumnName.ToUpper() = "BOOKVNO" Or dc.ColumnName.ToUpper() = "DESIGNCODE" Or dc.ColumnName.ToUpper() = "SHADECODE" Or dc.ColumnName.ToUpper() = "CUTCODE" Or dc.ColumnName.ToUpper() = "SRNO" Or dc.ColumnName.ToUpper() = "GODOWNCODE" Then
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
                        'FirstStage.Columns(dc.ColumnName).Visible = False
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub bandedView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
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
        Try
            Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            For Each dr As DataRow In dt.Rows
                If dr.RowState = DataRowState.Modified Then
                    If Convert.ToBoolean(dr("IsOriginalApproval")) Then Continue For
                    Dim cmd As New SqlClient.SqlCommand()
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 420
                    cmd.CommandText = "UPDATE " & _TblName & " SET " & "OP19 = @OP19, " & "OP22 = @MODYFIDATE " &
                        "WHERE BOOKVNO = @BOOKVNO " &
                        "AND ACCOUNTCODE = @ACCOUNTCODE" &
             " AND ITEMCODE = @ITEMCODE" &
            " AND DESIGNCODE = @DESIGNCODE" &
            " AND SHADECODE = @SHADECODE" &
            " AND CUTCODE = @CUTCODE" &
            " AND SRNO = @SRNO" &
            " AND GODOWNCODE = @GODOWNCODE"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@OP19", dr("STATUS").ToString())
                    cmd.Parameters.AddWithValue("@MODYFIDATE", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"))
                    'cmd.Parameters.AddWithValue("@MODYFIDATE", If(dr("STATUS").ToString() = "YES", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"), DBNull.Value))
                    cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
                    cmd.Parameters.AddWithValue("@ACCOUNTCODE", dr("ACCOUNTCODE").ToString())
                    cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
                    cmd.Parameters.AddWithValue("@DESIGNCODE", dr("DESIGNCODE").ToString())
                    cmd.Parameters.AddWithValue("@SHADECODE", dr("SHADECODE").ToString())
                    cmd.Parameters.AddWithValue("@CUTCODE", dr("CUTCODE").ToString())
                    cmd.Parameters.AddWithValue("@SRNO", dr("SRNO").ToString())
                    cmd.Parameters.AddWithValue("@GODOWNCODE", dr("GODOWNCODE").ToString())
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                End If
            Next
            conn.Close()
            MessageBox.Show("Data Updated Successfully")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
                    FirstStage.SetFocusedRowCellValue("Status", "REJECTION")
                ElseIf currentValue = "NO" Then
                    FirstStage.SetFocusedRowCellValue("Status", "YES")
                ElseIf currentValue = "REJECTION" Then
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

    Private Sub HeadApproval_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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