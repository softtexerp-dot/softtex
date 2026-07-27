Imports System.Text
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid

Public Class RawHeadApproval
    Private _TblName As String = "TrnPackingSlip"
    Private _KeyFieldName As String = "Id"
    Dim _CloseCheck As Boolean = False
    Private _BookCode As String = ""
    Private WithEvents txtUnitCode As New System.Windows.Forms.TextBox()
    Private Book_Row As DataRow
    Private AcCode_Filter_String As String = ""
    Private _FrmLoad As Boolean = True
    Dim dtSource As DataTable
    Private IsUpdating As Boolean = False
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
                    StatusFilter = " AND UPPER(A.OP24) = 'YES'"
                ElseIf UCase(txt_Status.Text.Trim) = "NO" Then
                    StatusFilter = " AND UPPER(A.OP24) = 'NO' "
                End If
            End If
            Dim _UserQuery As New StringBuilder()
            With _UserQuery
                .Append(" SELECT   ")
                .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') as Date, ")
                .Append(" A.Entryno AS EntryNo, ")
                .Append(" FORMAT( A.Mtr_weight,'0.00') AS Qty, ")
                .Append(" A.CUT_MTR AS GrossRate, ")
                .Append(" A.RDVALUE AS Dis, ")
                .Append(" A.WEIGHT AS Disamount, ")
                .Append(" A.RATE AS NetRate, ")
                .Append(" A.Amount AS Amount, ")
                .Append(" A.OP11 As Gst, ")
                .Append(" A.OP12 As Fright, ")
                .Append(" A.OP13 As Delivery, ")
                .Append(" A.OP4 As Paymentterms, ")
                .Append(" A.OP8 As Terms1,") 'Terms1
                .Append(" A.OP9 As Terms2,") 'Terms2
                .Append(" A.OP10 as Terms3,") 'Terms3
                .Append(" A.OP16 As Terms4,") 'Terms4
                .Append(" A.OP19 As Status, ")
                .Append(" A.OP24 As Status1, ")
                .Append(" A.Bookvno, ")
                .Append(" A.Godowncode, ")
                .Append(" A.Itemcode, ")
                .Append(" B.ItemName AS ITEMNAME, ")
                .Append(" C.ACCOUNTNAME As SupplierName,  ")
                .Append(" A.ACCOUNTCODE As SupplierCode,  ")
                .Append(" D.CUTNAME, ")
                '.Append(" F.DepartmentName, ")
                .Append(" FORMAT(A.ENTRYDATE,'yyyy-MM-dd HH:mm:ss.fff') AS F_ENTRYDATE,  ")
                .Append(" FORMAT(A.MODYFIDATE,'yyyy-MM-dd HH:mm:ss.fff') AS MODYFIDATE,  ")
                .Append(" H.TYPE_NAME  AS COMPANYNAME ")
                .Append(" ,CASE WHEN isnull(K.NetRate,0)=0 THEN B.Purchase_rate ELSE K.NetRate END AS LastPurchaseRate")
                .Append(" ,IIF(ISNULL(G.USEBOOKVNO,'')='','NO','YES') AS USEBY")
                .Append(" ,CASE WHEN ISDATE(A.OP25) = 1 THEN CONVERT(VARCHAR(10), CAST(A.OP25 AS DATETIME), 103)  ELSE '' END AS OP25,")  'Head Approval Date
                .Append("  CASE WHEN UPPER(A.OP24) = 'YES' THEN 'YES' ELSE 'NO' END AS Status2") 'Head Approval Status
                .Append(" ,CASE WHEN L.BOOKVNO IS NULL THEN 'NO'    ELSE 'YES'END AS Status3")
                .Append(" FROM  ")
                .Append(" " & _TblName & " AS A  ")
                .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
                .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE  ")
                .Append(" LEFT JOIN MstMasterAccount As C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstCutMaster As D ON D.ID=A.CUTCODE ")
                .Append(" LEFT JOIN MstStoreItemType H  ON  A.SHADECODE = H.TYPE_ID ")
                .Append(" LEFT JOIN (SELECT OP7 AS BOOKVNO ,AccountCode,DESIGNCODE,SHADECODE,GODOWNCODE,ITEMCODE FROM trnoffer WHERE BOOKTRTYPE in ('RAW10') GROUP BY OP7,ITEMCODE ,AccountCode,DESIGNCODE,SHADECODE,GODOWNCODE ) AS L ON  A.BOOKVNO = L.BOOKVNO and A.GodownCode = L.GodownCode and A.AccountCode = L.AccountCode and A.DESIGNCODE = L.DESIGNCODE and A.SHADECODE = L.SHADECODE  and A.ITEMCODE = L.ITEMCODE   ")
                .Append(" Left Join ( SELECT OP7 AS USEBOOKVNO,ITEMCODE AS USEITEMCODE  FROM TrnPackingSlip GROUP BY OP7,ITEMCODE ) AS G ON ( A.BOOKVNO=G.USEBOOKVNO AND A.ITEMCODE=G.USEITEMCODE ) ")
                .Append("  Left Join ( SELECT  OP19 AS TrueStatus,BOOKVNO  FROM TrnPackingSlip  WHERE OP19='YES' AND  BookTrType='RAW06' AND GodownCode='" & txtUnitCode.Text.Trim & "' GROUP BY OP19,BOOKVNO ) AS J ON ( A.BOOKVNO= J.BOOKVNO ) ")
                .Append(" Left Join ( ")
                .Append("     SELECT AccountCode, ItemCode, Rate AS NetRate ")
                .Append("     FROM ( ")
                .Append("         SELECT AccountCode, ")
                .Append("                ItemCode, ")
                .Append("                Rate, ")
                .Append("                ROW_NUMBER() OVER ( ")
                .Append("                    PARTITION BY AccountCode, ItemCode ")
                .Append("                    ORDER BY EntryDate DESC, EntryNo DESC ")
                .Append("                ) AS RN ")
                .Append("         FROM TrnPackingSlip ")
                .Append("         WHERE BookTrType='RAW09' ")
                .Append("           AND GodownCode='" & txtUnitCode.Text.Trim & "' ")
                .Append("     ) X ")
                .Append("     WHERE RN = 1 ")
                .Append(" ) AS K ")
                .Append(" ON ( A.AccountCode = K.AccountCode ")
                .Append("      AND A.ItemCode = K.ItemCode ) ")
                .Append(" WHERE 1=1  ")
                .Append(" And A.BOOKCODE='0001-000010016'  ")
                .Append(" And A.OP19='YES'  ") ' comaprison status
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
            dtSource = tblTmp.Copy()
            Dim dtPivot As New DataTable()
            ' Fixed Columns
            dtPivot.Columns.Add("EntryNo")
            dtPivot.Columns.Add("ItemName")
            dtPivot.Columns.Add("UOM")
            dtPivot.Columns.Add("LastPurchaseRate")
            dtPivot.Columns.Add("BOOKVNO")
            dtPivot.Columns.Add("ItemCode")
            dtPivot.Columns.Add("SupplierCode")
            dtPivot.Columns.Add("GodownCode")

            'dtPivot.Columns.Add("Brand")
            ' DISTINCT ACCOUNTNAME
            Dim accounts = dtSource.AsEnumerable().Select(Function(r) r("SupplierName").ToString()).Distinct().ToList()
            ' Dynamic Columns
            For Each acc In accounts
                dtPivot.Columns.Add(acc & "_Code")
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
                dtPivot.Columns.Add(acc & "_Terms1")
                dtPivot.Columns.Add(acc & "_Terms2")
                dtPivot.Columns.Add(acc & "_Terms3")
                dtPivot.Columns.Add(acc & "_Terms4")
                dtPivot.Columns.Add(acc & "_View")      ' <-- View Button
                dtPivot.Columns.Add(acc & "_Status", GetType(Boolean))
                dtPivot.Columns.Add(acc & "_Status1", GetType(Boolean))
                dtPivot.Columns.Add(acc & "_Status2", GetType(Boolean))
            Next
            ' DISTINCT ITEMS
            Dim items = dtSource.AsEnumerable().GroupBy(Function(r) New With {Key .ItemName = r("ITEMNAME").ToString(), Key .EntryNo = r("EntryNo").ToString(), Key .Brand = r("COMPANYNAME").ToString(), Key .CutName = r("CUTNAME").ToString(), Key .GodownCode = r("GodownCode").ToString()})
            For Each grp In items
                Dim newRow As DataRow = dtPivot.NewRow()
                Dim firstRow = grp.First()
                newRow("EntryNo") = firstRow("EntryNo").ToString()
                newRow("ItemName") = firstRow("ITEMNAME").ToString()
                newRow("UOM") = firstRow("CUTNAME").ToString()
                newRow("LastPurchaseRate") = firstRow("LastPurchaseRate").ToString()
                newRow("BOOKVNO") = firstRow("BOOKVNO").ToString()
                newRow("ItemCode") = firstRow("ItemCode").ToString()
                newRow("SupplierCode") = firstRow("SupplierCode").ToString()
                newRow("GodownCode") = firstRow("GodownCode").ToString()

                For Each r In grp
                    Dim acc As String = r("SupplierName").ToString()
                    newRow(acc & "_Code") = r("SupplierCode").ToString
                    newRow(acc & "_Brand") = r("COMPANYNAME").ToString
                    newRow(acc & "_Qty") = Format(Val(r("Qty")), "0.00")
                    newRow(acc & "_GrossRate") = Format(Val(r("GrossRate")), "0.00")
                    newRow(acc & "_Dis") = Format(Val(r("Dis")), "0.00")
                    newRow(acc & "_Rate") = Format(Val(r("NetRate")), "0.00")
                    newRow(acc & "_Amount") = Format(Val(r("Amount")), "0.00")
                    newRow(acc & "_GST") = Format(Val(r("GST")), "0.00")
                    newRow(acc & "_Fright") = Format(Val(r("Fright")), "0.00")
                    newRow(acc & "_Delivery") = Format(Val(r("Delivery")), "0.00")
                    newRow(acc & "_Paymentterms") = r("Paymentterms").ToString
                    newRow(acc & "_Terms1") = r("Terms1").ToString()
                    newRow(acc & "_Terms2") = r("Terms2").ToString()
                    newRow(acc & "_Terms3") = r("Terms3").ToString()
                    newRow(acc & "_Terms4") = r("Terms4").ToString()
                    newRow(acc & "_View") = "View"
                    Dim status As String = ""

                    If Not IsDBNull(r("Status")) Then
                        status = r("Status").ToString().Trim().ToUpper()
                    End If

                    If status = "YES" Then
                        newRow(acc & "_Status") = True
                    ElseIf status = "NO" Then
                        newRow(acc & "_Status") = False
                    End If
                    Dim status1 As String = ""
                    If Not IsDBNull(r("Status1")) Then
                        status1 = r("Status1").ToString().Trim().ToUpper()
                    End If

                    If status1 = "YES" Then
                        newRow(acc & "_Status1") = True

                    End If
                    Dim status2 As String = ""
                    If Not IsDBNull(r("Status2")) Then
                        status2 = r("Status2").ToString().Trim().ToUpper()
                    End If
                    If Not IsDBNull(r("Status2")) Then
                        status2 = r("Status2").ToString().Trim().ToUpper()
                    End If

                    If status2 = "YES" Then
                        newRow(acc & "_Status2") = True
                    ElseIf status2 = "NO" Then
                        newRow(acc & "_Status2") = False
                    End If
                Next
                dtPivot.Rows.Add(newRow)
            Next
            GridControl1.DataSource = dtPivot

            FirstStage.RefreshData()
            If dtPivot.Rows.Count > 0 Then
                Dim bandedView As New BandedGridView(GridControl1)
                GridControl1.MainView = bandedView
                GridControl1.ViewCollection.Add(bandedView)

                AddHandler bandedView.RowStyle, AddressOf bandedView_RowStyle
                AddHandler bandedView.RowCellStyle, AddressOf bandedView_RowCellStyle
                AddHandler bandedView.ShowingEditor, AddressOf bandedView_ShowingEditor

                Dim bandItem As New GridBand() With {.Caption = "Item Details"}
                bandItem.Columns.Add(AddBandedColumn(bandedView, "EntryNo", "EntryNo"))
                bandItem.Columns.Add(AddBandedColumn(bandedView, "ItemName", "Item"))
                bandItem.Columns.Add(AddBandedColumn(bandedView, "UOM", "UOM"))
                bandItem.Columns.Add(AddBandedColumn(bandedView, "LastPurchaseRate", "Last Purchase Rate"))
                bandedView.Bands.Add(bandItem)
                MinRateByRow.Clear()
                For i As Integer = 0 To dtPivot.Rows.Count - 1
                    Dim minRate As Decimal = Decimal.MaxValue
                    For Each acc In accounts
                        Dim colName As String = acc & "_Rate"
                        If dtPivot.Columns.Contains(colName) Then
                            If Not IsDBNull(dtPivot.Rows(i)(colName)) Then
                                Dim rate As Decimal = 0D
                                If Decimal.TryParse(dtPivot.Rows(i)(colName).ToString(), rate) Then
                                    If rate > 0 AndAlso rate < minRate Then
                                        minRate = rate
                                    End If
                                End If
                            End If
                        End If
                    Next
                    If minRate <> Decimal.MaxValue Then
                        MinRateByRow(i) = minRate
                    End If
                Next
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
                        Dim rateCol As BandedGridColumn = AddBandedColumn(bandedView, acc & "_Rate", "Net Rate")
                        band.Columns.Add(rateCol)
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
                    'If dtPivot.Columns.Contains(acc & "_Paymentterms") Then
                    '    band.Columns.Add(AddBandedColumn(bandedView, acc & "_Paymentterms", "Payment terms"))
                    'End If

                    Dim viewCol As BandedGridColumn = AddBandedColumn(bandedView, acc & "_View", "View")
                    Dim btnEdit As New RepositoryItemButtonEdit()
                    btnEdit.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                    'btnEdit.Buttons(0).Caption = "V"
                    btnEdit.Buttons.Clear()
                    Dim btn As New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                    btn.Caption = "View"
                    btnEdit.Buttons.Add(btn)
                    AddHandler btnEdit.ButtonClick, AddressOf PaymentTerms_ButtonClick
                    GridControl1.RepositoryItems.Add(btnEdit)
                    viewCol.ColumnEdit = btnEdit
                    band.Columns.Add(viewCol)

                    band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                    band.AppearanceHeader.Options.UseFont = True
                    band.AppearanceHeader.Options.UseTextOptions = True
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    bandedView.Bands.Add(band)
                    If dtPivot.Columns.Contains(acc & "_Status") Then
                        Dim statusCol As BandedGridColumn = AddBandedColumn(bandedView, acc & "_Status", "Department Approve Status")
                        Dim chkEdit As New RepositoryItemCheckEdit()
                        chkEdit.ValueChecked = True
                        chkEdit.ValueUnchecked = False
                        chkEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                        GridControl1.RepositoryItems.Add(chkEdit)
                        statusCol.ColumnEdit = chkEdit
                        band.Columns.Add(statusCol)
                    End If
                    If dtPivot.Columns.Contains(acc & "_Status2") Then
                        Dim statusCol As BandedGridColumn = AddBandedColumn(bandedView, acc & "_Status2", "Head Approve Status")
                        Dim chkEdit As New RepositoryItemCheckEdit()
                        chkEdit.ValueChecked = True
                        chkEdit.ValueUnchecked = False
                        chkEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                        GridControl1.RepositoryItems.Add(chkEdit)
                        statusCol.ColumnEdit = chkEdit
                        band.Columns.Add(statusCol)
                    End If
                Next
                'For Each col As BandedGridColumn In bandedView.Columns
                '    col.OptionsColumn.AllowEdit = False
                '    col.OptionsColumn.ReadOnly = True
                '    If col.FieldName.EndsWith("_Status") Then
                '        col.OptionsColumn.AllowEdit = True
                '        col.OptionsColumn.ReadOnly = False
                '    End If
                'Next

                For Each col As BandedGridColumn In bandedView.Columns
                    col.OptionsColumn.AllowEdit = False
                    col.OptionsColumn.ReadOnly = True
                    If col.FieldName.EndsWith("_View") Then
                        col.OptionsColumn.AllowEdit = True
                        col.OptionsColumn.ReadOnly = False
                    End If
                    If col.FieldName.EndsWith("_Status1") Then
                        col.OptionsColumn.AllowEdit = True
                        col.OptionsColumn.ReadOnly = False
                    End If
                Next
                bandedView.BestFitColumns()
                bandedView.OptionsView.ColumnAutoWidth = False
                bandedView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                bandedView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                bandedView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                bandedView.OptionsView.RowAutoHeight = False
                bandedView.OptionsView.ShowIndicator = True
                bandedView.OptionsView.ShowGroupPanel = False
                bandedView.OptionsBehavior.Editable = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub bandedView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim view As BandedGridView = CType(sender, BandedGridView)
        If view.FocusedColumn.FieldName.EndsWith("_View") Then
            Return    ' View button clickable rahega
        End If
        If view.FocusedColumn.FieldName.EndsWith("_Status") Then
            e.Cancel = True
        End If
        If view.FocusedColumn.FieldName.EndsWith("_Status2") Then
            e.Cancel = True
        End If
        For Each col As BandedGridColumn In view.Columns
            If col.FieldName.EndsWith("_Status") Then
                Dim val = view.GetRowCellValue(view.FocusedRowHandle, col)
                If val IsNot DBNull.Value AndAlso
               val IsNot Nothing AndAlso
               CBool(val) Then
                    e.Cancel = True
                    Return
                End If
            End If
            If col.FieldName.EndsWith("_Status2") Then
                Dim val = view.GetRowCellValue(view.FocusedRowHandle, col)
                If val IsNot DBNull.Value AndAlso
               val IsNot Nothing AndAlso
               CBool(val) Then
                    e.Cancel = True
                    Return
                End If
            End If
        Next

    End Sub
    Private Sub bandedView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        If e.RowHandle < 0 Then Exit Sub
        If Not e.Column.FieldName.EndsWith("_Rate") Then Exit Sub
        Dim view As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        Dim minRate As Decimal = Decimal.MaxValue
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
            If col.FieldName.EndsWith("_Rate") Then
                Dim rate As Decimal
                If Decimal.TryParse(Convert.ToString(view.GetRowCellValue(e.RowHandle, col)), rate) Then
                    If rate > 0 AndAlso rate < minRate Then
                        minRate = rate
                    End If
                End If
            End If
        Next
        Dim currentRate As Decimal
        If Decimal.TryParse(Convert.ToString(e.CellValue), currentRate) Then
            If currentRate = minRate Then
                e.Appearance.BackColor = Color.LightGreen
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If
        End If
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
    Private MinRateByRow As New Dictionary(Of Integer, Decimal)
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
    Private Sub PaymentTerms_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
        Dim view As BandedGridView = CType(GridControl1.MainView, BandedGridView)
        Dim colName As String = view.FocusedColumn.FieldName
        Dim supplier As String = colName.Replace("_View", "")
        Dim msg As String =
        "Payment Terms : " & Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Paymentterms")) & vbCrLf &
        "Terms 1 : " & Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms1")) & vbCrLf &
        "Terms 2 : " & Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms2")) & vbCrLf &
        "Terms 3 : " & Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms3")) & vbCrLf &
        "Terms 4 : " & Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms4"))
        Dim payment As String = Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Paymentterms"))
        Dim terms1 As String = Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms1"))
        Dim terms2 As String = Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms2"))
        Dim terms3 As String = Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms3"))
        Dim terms4 As String = Convert.ToString(view.GetFocusedRowCellValue(supplier & "_Terms4"))
        If payment <> "" OrElse terms1 <> "" OrElse terms2 <> "" OrElse terms3 <> "" OrElse terms4 <> "" Then
            MessageBox.Show(msg, supplier)
        End If
    End Sub
    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Try
            Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            For Each dr As DataRow In dt.Rows
                'If dr.RowState = DataRowState.Modified Then
                For Each col As DataColumn In dt.Columns
                        If col.ColumnName.EndsWith("_Status2") Then
                            Dim IsApproved As Boolean = False
                            If Not IsDBNull(dr(col)) Then
                                IsApproved = Convert.ToBoolean(dr(col))
                            End If

                            Dim cmd As New SqlClient.SqlCommand()
                            cmd.Connection = conn
                            cmd.CommandType = CommandType.Text
                            cmd.CommandTimeout = 420
                            cmd.CommandText = "UPDATE " & _TblName & " SET " & "OP24 = @OP24, " & "OP25 = @MODYFIDATE " &
                            "WHERE BOOKVNO = @BOOKVNO " &
                 " AND ACCOUNTCODE = @ACCOUNTCODE" &
                 " AND ITEMCODE = @ITEMCODE" &
                 " AND EntryNo = @EntryNo " &
                 " AND GODOWNCODE = @GODOWNCODE"

                        cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@OP24", If(IsApproved, "YES", "NO"))
                            cmd.Parameters.AddWithValue("@MODYFIDATE", If(IsApproved, Format(Now, "yyyy-MM-dd HH:mm:ss.fff"), DBNull.Value))
                        cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
                        cmd.Parameters.AddWithValue("@ACCOUNTCODE", dr("SupplierCode").ToString())
                            cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
                            cmd.Parameters.AddWithValue("@EntryNo", dr("EntryNo").ToString())
                        cmd.Parameters.AddWithValue("@GODOWNCODE", dr("GODOWNCODE").ToString())
                        cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        End If
                    Next
                'End If
            Next
            conn.Close()
            MessageBox.Show("Data Updated Successfully")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub FirstStage_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown, FirstStage.KeyDown
        Try
            If e.KeyCode = Keys.Space Then
                Dim view As BandedGridView = TryCast(GridControl1.FocusedView, BandedGridView)
                If view Is Nothing Then Exit Sub
                If Not view.FocusedColumn.FieldName.EndsWith("_Status2") Then Exit Sub
                '======== Row Lock Check ========
                Dim isLocked As Boolean = False

                For Each col As BandedGridColumn In view.Columns
                    If col.FieldName.EndsWith("_Status2") Then
                        'Dim val As Object = view.GetRowCellValue(view.FocusedRowHandle, col)
                        'If val IsNot DBNull.Value AndAlso val IsNot Nothing AndAlso CBool(val) Then
                        '    isLocked = True
                        '    Exit For
                        'End If
                        Dim codeColumn As String = col.FieldName.Replace("_Status2", "_Code")
                        Dim supplierCode1 As String = Convert.ToString(view.GetRowCellValue(view.FocusedRowHandle, codeColumn))
                        Dim bookVno1 As String = Convert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "BOOKVNO"))
                        Dim dr1() As DataRow = dtSource.Select("BOOKVNO='" & bookVno1 & "' AND SupplierCode='" & supplierCode1 & "'")
                        If dr1.Length > 0 Then
                            Dim status As String = dr1(0)("Status2").ToString().Trim().ToUpper()
                            If status = "YES" Then
                                isLocked = True
                                Exit For
                            Else
                                isLocked = False
                            End If
                        End If
                    End If
                Next

                If isLocked Then
                    e.SuppressKeyPress = True
                    e.Handled = True
                    Exit Sub
                End If
                Dim BookVno As String = Convert.ToString(view.GetFocusedRowCellValue("BOOKVNO"))
                Dim SupplierCode As String = Convert.ToString(view.GetFocusedRowCellValue("SupplierCode"))
                Dim dr() As DataRow = dtSource.Select("BOOKVNO='" & BookVno & "' And SupplierCode='" & SupplierCode & "'")
                If dr.Length > 0 Then
                    If IsDBNull(dr(0)("Status2")) Then Exit Sub
                End If
                Dim chkValue As Boolean = False
                If view.GetFocusedRowCellValue(view.FocusedColumn) IsNot DBNull.Value Then
                    chkValue = Not Convert.ToBoolean(view.GetFocusedRowCellValue(view.FocusedColumn))
                Else
                    chkValue = True
                End If

                IsUpdating = True
                If chkValue Then
                    ' Same BOOKVNO ki sab rows ke status uncheck
                    For i As Integer = 0 To view.RowCount - 1
                        If Convert.ToString(view.GetRowCellValue(i, "BOOKVNO")) = BookVno Then
                            For Each col As BandedGridColumn In view.Columns
                                If col.FieldName.EndsWith("_Status2") Then
                                    view.SetRowCellValue(i, col, False)
                                End If
                            Next
                        End If
                    Next
                    ' Ab selected supplier ko check karo
                    For i As Integer = 0 To view.RowCount - 1
                        If Convert.ToString(view.GetRowCellValue(i, "BOOKVNO")) = BookVno AndAlso Convert.ToString(view.GetRowCellValue(i, "SupplierCode")) = SupplierCode Then
                            view.SetRowCellValue(i, view.FocusedColumn, True)
                        End If
                    Next
                Else
                    ' Uncheck case
                    For i As Integer = 0 To view.RowCount - 1
                        If Convert.ToString(view.GetRowCellValue(i, "BOOKVNO")) = BookVno AndAlso Convert.ToString(view.GetRowCellValue(i, "SupplierCode")) = SupplierCode Then
                            view.SetRowCellValue(i, view.FocusedColumn, False)
                        End If
                    Next
                End If
                e.SuppressKeyPress = True
                e.Handled = True
            End If

        Finally
            IsUpdating = False
        End Try
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