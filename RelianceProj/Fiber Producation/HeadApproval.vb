Imports System.Text

Public Class HeadApproval
    Private _TblName As String = "TrnPackingSlip"
    Private _KeyFieldName As String = "Id"
    Dim _CloseCheck As Boolean = False
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = " Report From : Approval By Plant Head Details "
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
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        Generate_Date_For_DataBase(txt_From)
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_To)
        View_Record()
    End Sub
    Private Sub View_Record()
        Try

            Dim dateFilter As String = ""
            Dim StatusFilter As String = ""
            Dim TypeFilter As String = ""
            If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
                dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "'"
            End If
            If Not String.IsNullOrEmpty(txt_Status.Text) Then
                If UCase(txt_Status.Text.Trim) = "ALL" Then
                    StatusFilter = ""
                ElseIf UCase(txt_Status.Text.Trim) = "YES" Then
                    StatusFilter = " AND UPPER(A.OP24) = 'YES'"
                ElseIf UCase(txt_Status.Text.Trim) = "NO" Then
                    StatusFilter = " AND UPPER(A.OP24) = 'NO' "
                End If
            End If
            If UCase(TxtType.Text.Trim) = "ALL" Then
                TypeFilter = " AND ( " &
                     " (ISDATE(ISNULL(A.OP25,'1900-01-01 00:00:00.000')) = 1 " &
                     " AND CAST(ISNULL(A.OP25,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.OP25,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "') " &
                     " OR " &
                     " (CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "') " &
                     " ) " '&
                '" AND UPPER(A.OP19) IN ('YES') "
            ElseIf UCase(TxtType.Text.Trim) = "APPROVE" Then
                TypeFilter = " AND ISDATE(ISNULL(A.OP25,'1900-01-01 00:00:00.000')) = 1 " &
                     " AND CAST(ISNULL(A.OP25,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.OP25,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "' " '&
                '" AND UPPER(A.OP19) = 'YES' "
            ElseIf UCase(TxtType.Text.Trim) = "PENDING" Then
                TypeFilter = " AND CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) >= '" & txt_From.Date_for_Database & "' " &
                     " AND CAST(ISNULL(A.ENTRYDATE,'1900-01-01 00:00:00.000') AS DATE) <= '" & txt_To.Date_for_Database & "' " '&
                ' " AND UPPER(A.OP19) = 'YES' "
            End If
            Dim _UserQuery As New StringBuilder()
            With _UserQuery
                .Append(" SELECT   A.ENTRYNO As [Approval No],")
                .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') as Date, ")
                .Append(" CASE WHEN A.ENTRYDATE = '1900-01-01 00:00:00.000' THEN '' ")
                .Append(" ELSE FORMAT(A.ENTRYDATE,'dd/MM/yyyy hh:mm:ss.fff tt') END AS [Entry Date],")
                .Append(" A.ITEMCODE,")
                .Append(" A.BOOKVNO,")  'BookVNO
                .Append(" A.AccountCode,")
                .Append(" A.DESIGNCODE,")
                .Append(" A.SHADECODE,")
                .Append(" A.CUTCODE,")
                .Append(" B.ItemName AS ItemName, ")
                .Append(" D.CUTNAME As UOM, ")  'UOM
                .Append(" C.AccountName, ")  'UOM
                .Append(" K.TYPE_NAME AS Brand ,")
                .Append(" FORMAT( A.Mtr_weight,'0.00') AS Qty, ")
                .Append("  FORMAT( A.CUT_MTR,'0.00') AS GrossRate, ")
                .Append(" FORMAT( A.RDVALUE,'0.00') AS Dis, ")
                .Append(" FORMAT( A.WEIGHT,'0.00') AS Disamount, ")
                .Append(" FORMAT( A.RATE,'0.00') AS NetRate, ")
                .Append(" FORMAT( A.Amount,'0.00') AS Amount, ")
                .Append(" FORMAT( A.OP11,'0.00') As Gst, ")
                .Append(" FORMAT( A.OP12,'0.00') As Fright, ")
                .Append(" FORMAT( A.OP13,'0.00') As Delivery, ")
                .Append(" A.OP4 As Paymentterms, ")
                .Append(" CASE WHEN ISDATE(A.OP25) = 1 THEN CONVERT(VARCHAR(10), CAST(A.OP25 AS DATETIME), 103)  ELSE '' END AS OP25,")  'Head Approval Date
                .Append("  CASE WHEN UPPER(A.OP24) = 'YES' THEN 'YES' ELSE 'NO' END AS Status") 'Head Approval Status
                .Append(" FROM  ")
                .Append(" " & _TblName & " AS A  ")
                .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
                .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE  ")
                .Append(" LEFT JOIN MstMasterAccount As C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstCutMaster As D ON D.ID=A.CUTCODE ")
                .Append(" LEFT JOIN MstStoreItemType K  ON  A.SHADECODE = K.TYPE_ID ")
                .Append(" WHERE 1=1  ")
                .Append(" And A.BOOKCODE='CESS-000000001'  ")
                .Append(" And A.OP19='YES'  ") ' comaprison status
                '.Append("  AND NOT EXISTS ")
                '.Append("  (   ")
                '.Append(" SELECT 1  ")
                '.Append(" FROM TrnPackingSlip AS B  ")
                '.Append(" WHERE ")
                '.Append(" B.OP7 = A.BookVno ")
                '.Append(" And B.ITEMCODE = A.ITEMCODE ")
                '.Append("  )")
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
                GridControl1.DataSource = tblTmp.Copy
                For Each dc As DataColumn In tblTmp.Columns
                    Dim isEmptyOrZero As Boolean = True
                    If dc.ColumnName.ToUpper() = "ID" Or dc.ColumnName.ToUpper() = "ACCOUNTCODE" Or dc.ColumnName.ToUpper() = "ITEMCODE" Or dc.ColumnName.ToUpper() = "BOOKVNO" Or dc.ColumnName.ToUpper() = "OP25" Or dc.ColumnName.ToUpper() = "DESIGNCODE" Or dc.ColumnName.ToUpper() = "SHADECODE" Or dc.ColumnName.ToUpper() = "CUTCODE" Then
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

    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Try
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
                    cmd.CommandText = "UPDATE " & _TblName & " SET " & "OP24 = @OP24, " & "OP25 = @MODYFIDATE " &
                        "WHERE BOOKVNO = @BOOKVNO " &
             " AND ACCOUNTCODE = @ACCOUNTCODE" &
             " AND ITEMCODE = @ITEMCODE" &
            " AND DESIGNCODE = @DESIGNCODE" &
            " AND SHADECODE = @SHADECODE" &
            " AND CUTCODE = @CUTCODE"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@OP24", dr("STATUS").ToString())
                    cmd.Parameters.AddWithValue("@MODYFIDATE", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"))
                    'cmd.Parameters.AddWithValue("@MODYFIDATE", If(dr("STATUS").ToString() = "YES", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"), DBNull.Value))
                    cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
                    cmd.Parameters.AddWithValue("@ACCOUNTCODE", dr("ACCOUNTCODE").ToString())
                    cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
                    cmd.Parameters.AddWithValue("@DESIGNCODE", dr("DESIGNCODE").ToString())
                    cmd.Parameters.AddWithValue("@SHADECODE", dr("SHADECODE").ToString())
                    cmd.Parameters.AddWithValue("@CUTCODE", dr("CUTCODE").ToString())
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
                Dim currentValue As String = FirstStage.GetFocusedRowCellValue("Status").ToString().ToUpper()
                If currentValue = "YES" Then
                    'FirstStage.SetFocusedRowCellValue("Status", "NO")
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
        End If
    End Sub
End Class