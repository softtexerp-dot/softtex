Imports System.ComponentModel
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class DepartmentApproval
    Private CurDate As String = Now.Month.ToString & "/" & Now.Day.ToString & "/" & Now.Year.ToString
    Private Process_Date_Filter_Condition As String = ""
    Private SelectedAccountName As String = ""
    Private Display_Stage_No As Integer = 0
    Dim Zoom_Stock_Table As New DataTable
    Dim Zoom_Stock_Table_Secondstage As New DataTable
    Dim ThidTable As New DataTable
    Dim FourTable As New DataTable
    Dim FIveTable As New DataTable
    Dim _StgIRowNo As Integer = 1
    Dim _StgIIRowNo As Integer = 1
    Dim _StgThidRowNo As Integer = 1
    Dim _StgFourRowNo As Integer = 1
    Private obj_Party_Selection As New Multi_Selection_Master

    Dim _FILTERACCOUNTCODE As String = ""
    Dim _CloseCheck As Boolean = False
    Dim _CommanFilterString As String = ""
    Dim SelectionType As String = ""
    Dim _CommanFirstStageActivColumn As String = ""
    Dim FactStockTable As New DataTable
    Dim SelectionOfView As String = ""
    Dim NoOfstage As Integer = 0
    Dim SummaryActiveClmQty As String = ""
    Dim SummaryActiveClmName As String = ""

    Dim _TmpMonthwiseTbl As New DataTable
    Private _TblName As String = "TrnPackingSlip"


    Private Sub StoreConsumption_GridZooming_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'If _CloseCheck = True Then
            '    Close()
            '    Me.Dispose(True)
            'Else
            '    _CloseCheck = True
            '    txt_From.Focus()
            'End If



        End If
    End Sub
    Private Sub StoreConsumption_GridZooming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Me.Location = New Point(0, 0)
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        _NewTmptbl = _Zooming_Load(txt_To.Date_for_Database, "FIRST", "")
        'Stock_Zooming_Load(_NewTmptbl)

        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _CloseCheck = False
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        Dim _NewTmptbl2 As New DataTable
        _Zooming_Load(txt_To.Date_for_Database, "FIRST", "")
    End Sub

    Private Function AddBandedColumn(view As BandedGridView, fieldName As String, caption As String, Optional colWidth As Integer = 100) As BandedGridColumn
        Dim col As New BandedGridColumn()
        col.FieldName = fieldName
        col.Caption = caption
        col.Visible = True
        ' WIDTH
        col.Width = colWidth
        view.Columns.Add(col)
        Return col
    End Function

    Private Function _Zooming_Load(ByVal _DateTo As String, ByRef _EnterStage As String, ByRef FilterString As String)

        _strQuery = New StringBuilder
        With _strQuery
            '--- Prepare filter and extra columns based on ViewType
            Dim filter As String = ""
            Dim extraCols As String = ""   ' columns to select and group by

            Dim groupCols As String = ""
            Dim selectCols As String = ""
            Dim orderCols As String = ""

            Dim dateFilter As String = ""
            If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
                dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "'"
            End If
            .Append(" SELECT   ")
            .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') as Date, ")
            .Append(" A.Entryno AS EntryNo, ")
            .Append(" A.Mtr_weight AS Qty, ")
            .Append(" A.CUT_MTR AS GrossRate, ")
            .Append(" A.RDVALUE AS Dis, ")
            .Append(" A.WEIGHT AS Disamount, ")
            .Append(" A.RATE AS NetRate, ")
            .Append(" A.Amount AS Amount, ")
            .Append(" A.OP11 As Gst, ")
            .Append(" A.OP12 As Fright, ")
            .Append(" A.OP13 As Delivery, ")
            .Append(" A.OP4 As Paymentterms, ")
            .Append(" A.OP19 As Status, ")
            .Append(" A.Bookvno, ")
            .Append(" A.Itemcode, ")
            .Append(" B.ItemName AS ITEMNAME, ")
            .Append(" C.ACCOUNTNAME As SupplierName,  ")
            .Append(" E.CUTNAME, ")
            '.Append(" F.DepartmentName, ")
            .Append(" FORMAT(A.ENTRYDATE,'yyyy-MM-dd HH:mm:ss.fff') AS F_ENTRYDATE,  ")
            .Append(" FORMAT(A.MODYFIDATE,'yyyy-MM-dd HH:mm:ss.fff') AS MODYFIDATE,  ")
            .Append(" H.TYPE_NAME  AS COMPANYNAME ")
            .Append(" ,IIF(ISNULL(G.USEBOOKVNO,'')='','NO','YES') AS USEBY")
            .Append(" FROM  ")
            .Append(" TrnPackingSlip AS A  ")
            .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE ")
            .Append(" LEFT JOIN MstMasterAccount As C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstCutMaster As E ON E.ID=A.CUTCODE ")
            .Append(" LEFT JOIN MstDepartment F  ON A.DESIGNCODE=F.Departmentcode ")
            .Append(" LEFT JOIN MstStoreItemType H ON  A.SHADECODE = H.TYPE_ID ")
            .Append(" Left Join ( SELECT OP7 AS USEBOOKVNO,ITEMCODE AS USEITEMCODE  FROM TrnPackingSlip GROUP BY OP7,ITEMCODE ) AS G ON ( A.BOOKVNO=G.USEBOOKVNO AND A.ITEMCODE=G.USEITEMCODE) ")
            .Append(" WHERE 1=1  ")
            .Append(" AND  A.BookTrType='CESS1'")
            '.Append(" AND  A.BOOKVNO='" & strKeyID & "'")
            .Append(dateFilter)
            .Append(" ORDER BY  A.Entryno ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _NewTmptbl As New DataTable
        _NewTmptbl = DefaltSoftTable.Copy

        Dim dtSource As DataTable = _NewTmptbl.Copy()
        Dim dtPivot As New DataTable()
        ' Fixed Columns
        dtPivot.Columns.Add("EntryNo")
        dtPivot.Columns.Add("ItemName")
        dtPivot.Columns.Add("UOM")
        dtPivot.Columns.Add("BOOKVNO")
        dtPivot.Columns.Add("ItemCode")
        'dtPivot.Columns.Add("Brand")
        ' DISTINCT ACCOUNTNAME
        Dim accounts = dtSource.AsEnumerable().Select(Function(r) r("SupplierName").ToString()).Distinct().ToList()
        ' Dynamic Columns
        For Each acc In accounts
            dtPivot.Columns.Add(acc & "_Brand")
            dtPivot.Columns.Add(acc & "_Qty")
            dtPivot.Columns.Add(acc & "_GrossRate")
            dtPivot.Columns.Add(acc & "_Dis")
            dtPivot.Columns.Add(acc & "_Rate")
            dtPivot.Columns.Add(acc & "_Amount")
            dtPivot.Columns.Add(acc & "_GST")
            dtPivot.Columns.Add(acc & "_Fright")
            dtPivot.Columns.Add(acc & "_Delivery")
            dtPivot.Columns.Add(acc & "_Paymentterms")
            dtPivot.Columns.Add(acc & "_Status", GetType(Boolean))
        Next
        ' DISTINCT ITEMS
        Dim items = dtSource.AsEnumerable().GroupBy(Function(r) r("ITEMNAME").ToString())
        For Each grp In items
            Dim newRow As DataRow = dtPivot.NewRow()
            Dim firstRow = grp.First()
            newRow("EntryNo") = firstRow("EntryNo").ToString()
            newRow("ItemName") = firstRow("ITEMNAME").ToString()
            newRow("UOM") = firstRow("CUTNAME").ToString()
            newRow("BOOKVNO") = firstRow("BOOKVNO").ToString()
            newRow("ItemCode") = firstRow("ItemCode").ToString()
            For Each r In grp
                Dim acc As String = r("SupplierName").ToString()
                newRow(acc & "_Brand") = r("COMPANYNAME").ToString
                newRow(acc & "_Qty") = Val(r("Qty"))
                newRow(acc & "_GrossRate") = Val(r("GrossRate"))
                newRow(acc & "_Dis") = Val(r("Dis"))
                newRow(acc & "_Rate") = Val(r("NetRate"))
                newRow(acc & "_Amount") = Val(r("Amount"))
                newRow(acc & "_GST") = Val(r("GST"))
                newRow(acc & "_Fright") = Val(r("Fright"))
                newRow(acc & "_Delivery") = Val(r("Delivery"))
                newRow(acc & "_Paymentterms") = r("Paymentterms").ToString
                If r("Status").ToString().Trim().ToUpper() = "NO" Then
                    newRow(acc & "_Status") = False
                Else
                    newRow(acc & "_Status") = True
                End If
            Next
            dtPivot.Rows.Add(newRow)
        Next
        GridControl1.DataSource = dtPivot
        If dtPivot.Rows.Count > 0 Then
            Dim bandedView As New BandedGridView(GridControl1)

            AddHandler bandedView.ShowingEditor, AddressOf bandedView_ShowingEditor
            GridControl1.MainView = bandedView
            GridControl1.ViewCollection.Add(bandedView)

            Dim bandItem As New GridBand() With {.Caption = "Item Details"}
            bandItem.Columns.Add(AddBandedColumn(bandedView, "EntryNo", "EntryNo"))
            bandItem.Columns.Add(AddBandedColumn(bandedView, "ItemName", "Item"))
            bandItem.Columns.Add(AddBandedColumn(bandedView, "UOM", "UOM"))
            bandedView.Bands.Add(bandItem)
            For Each acc In accounts
                Dim band As New GridBand()
                band.Caption = acc
                If dtPivot.Columns.Contains(acc & "_Brand") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Brand", "Brand"))
                End If
                If dtPivot.Columns.Contains(acc & "_Qty") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Qty", "Qty"))
                End If

                If dtPivot.Columns.Contains(acc & "_GrossRate") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_GrossRate", "Gross Rate"))
                End If
                If dtPivot.Columns.Contains(acc & "_Dis") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Dis", "Dis %"))
                End If
                If dtPivot.Columns.Contains(acc & "_Rate") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Rate", "Net Rate"))
                End If

                If dtPivot.Columns.Contains(acc & "_Amount") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Amount", "Amount"))
                End If
                If dtPivot.Columns.Contains(acc & "_GST") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_GST", "Gst"))
                End If
                If dtPivot.Columns.Contains(acc & "_Fright") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Fright", "Fright"))
                End If
                If dtPivot.Columns.Contains(acc & "_Delivery") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Delivery", "Delivery"))
                End If
                If dtPivot.Columns.Contains(acc & "_Paymentterms") Then
                    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Paymentterms", "Payment terms"))
                End If
                band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                band.AppearanceHeader.Options.UseFont = True
                band.AppearanceHeader.Options.UseTextOptions = True
                band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                bandedView.Bands.Add(band)
                If dtPivot.Columns.Contains(acc & "_Status") Then
                    Dim statusCol As BandedGridColumn = AddBandedColumn(bandedView, acc & "_Status", "Status")
                    Dim chkEdit As New RepositoryItemCheckEdit()
                    chkEdit.ValueChecked = True
                    chkEdit.ValueUnchecked = False
                    GridControl1.RepositoryItems.Add(chkEdit)
                    statusCol.ColumnEdit = chkEdit
                    band.Columns.Add(statusCol)
                End If
            Next
            For Each col As BandedGridColumn In bandedView.Columns
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
                If col.FieldName.EndsWith("_Status") Then
                    col.OptionsColumn.AllowEdit = True
                    col.OptionsColumn.ReadOnly = False
                End If
            Next
            bandedView.BestFitColumns()
            bandedView.OptionsView.ColumnAutoWidth = False
            bandedView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
            bandedView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
            bandedView.OptionsView.RowAutoHeight = False
            bandedView.OptionsView.ShowIndicator = True
            bandedView.OptionsView.ShowGroupPanel = False
            bandedView.OptionsBehavior.Editable = True
        End If
    End Function


    Private Sub btn_xl_Click(sender As Object, e As EventArgs) Handles btn_xl.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub But_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Department Approval By Head Report"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Txt_ViewType_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            But_ok.Focus()
        End If
    End Sub


#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub



    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        For Each dr As DataRow In dt.Rows

            For Each col As DataColumn In dt.Columns
                Dim statusValue As Boolean = False
                If col.ColumnName.EndsWith("_Status") Then
                    If Not IsDBNull(dr(col.ColumnName)) Then
                        statusValue = Convert.ToBoolean(dr(col.ColumnName))
                    End If
                End If

                If statusValue = True Then
                    Dim cmd As New SqlClient.SqlCommand()
                    cmd.Connection = conn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandTimeout = 420
                    'OP23 As Approval Date
                    'OP19 As Status Yes or No
                    cmd.CommandText = "UPDATE " & _TblName & " SET " & "OP19 = @OP19, " & "OP23 = @MODYFIDATE " & "WHERE BOOKVNO = @BOOKVNO " & "AND ITEMCODE = @ITEMCODE" & " AND EntryNo = @EntryNo"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@OP19", If(Convert.ToBoolean(dr(col.ColumnName)), "YES", "NO"))
                    cmd.Parameters.AddWithValue("@MODYFIDATE", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"))
                    cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
                    cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
                    cmd.Parameters.AddWithValue("@EntryNo", dr("EntryNo").ToString())
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                End If
            Next
        Next
        conn.Close()
        MessageBox.Show("Data Updated Successfully")
    End Sub

    Private Sub bandedView_ShowingEditor(sender As Object, e As CancelEventArgs)
        Dim view As BandedGridView = CType(sender, BandedGridView)
        If view.FocusedColumn.FieldName.EndsWith("_Status") Then
            Dim val As Boolean = False
            If view.GetFocusedValue() IsNot DBNull.Value Then
                val = Convert.ToBoolean(view.GetFocusedValue())
            End If
            ' TRUE = LOCK
            If val = True Then
                e.Cancel = True
            End If
        Else
            ' ALL OTHER COLUMNS LOCK
            e.Cancel = True
        End If
    End Sub
#End Region
End Class