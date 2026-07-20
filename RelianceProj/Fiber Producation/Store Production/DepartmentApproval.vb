Imports System.Text
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
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
    Private IsUpdating As Boolean = False
    Dim dtSource As DataTable
    Private _BookCode As String = ""
    Private WithEvents txtUnitCode As New System.Windows.Forms.TextBox()
    Private Book_Row As DataRow
    Private AcCode_Filter_String As String = ""
    Private _FrmLoad As Boolean = True

    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub StoreConsumption_GridZooming_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub StoreConsumption_GridZooming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        _CloseCheck = True
        _FrmLoad = False
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _CloseCheck = False
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        Dim _NewTmptbl2 As New DataTable
        _Zooming_Load(txt_To.Date_for_Database)
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


    Private Function _Zooming_Load(ByVal _DateTo As String)
        'If txt_Status.Text <> "ALL" AndAlso txtUnitCode.Text = "" Then
        '    MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        '    txtUnitName.Focus()
        '    Exit Function
        'End If
        If txt_Status.Text = "ALL" AndAlso txtUnitCode.Text = "" Then
            MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtUnitName.Focus()
            Exit Function
        End If
        If txtUnitCode.Text = "" Then
            MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtUnitName.Focus()
            Exit Function
        End If
        _strQuery = New StringBuilder
        With _strQuery
            '--- Prepare filter and extra columns based on ViewType
            Dim filter As String = ""
            Dim extraCols As String = ""   ' columns to select and group by
            Dim groupCols As String = ""
            Dim selectCols As String = ""
            Dim orderCols As String = ""
            Dim Unitfilter As String = ""
            Dim dateFilter As String = ""
            If txtUnitCode.Text.Trim <> "" Then
                Unitfilter = " AND A.GodownCode = '" & txtUnitCode.Text.Trim & "' "
            End If
            If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
                dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "' "
            End If
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
            .Append(" Left Join ( SELECT OP7 AS USEBOOKVNO,ITEMCODE AS USEITEMCODE  FROM TrnPackingSlip GROUP BY OP7,ITEMCODE ) AS G ON ( A.BOOKVNO=G.USEBOOKVNO AND A.ITEMCODE=G.USEITEMCODE ) ")
            .Append("  Left Join ( SELECT  OP19 AS TrueStatus,BOOKVNO  FROM TrnPackingSlip  WHERE OP19='YES' AND  BookTrType='CESS1' AND GodownCode='" & txtUnitCode.Text.Trim & "' GROUP BY OP19,BOOKVNO ) AS J ON ( A.BOOKVNO= J.BOOKVNO ) ")
            .Append(" WHERE 1=1  ")
            .Append(" AND  A.BookTrType='CESS1'")
            '.Append(" AND  A.BOOKVNO='" & strKeyID & "'")
            If UCase(txt_Status.Text.Trim) = "NO" Then
                '.Append(" AND ISNULL(A.OP19,'') <> 'YES'")
                .Append(" AND (J.TrueStatus IS NULL OR J.TrueStatus = 'NO')")
            ElseIf UCase(txt_Status.Text.Trim) = "YES" Then
                .Append(" AND ISNULL(A.OP19,'') = 'YES'")
            ElseIf UCase(txt_Status.Text.Trim) = "ALL" Then
                ' Koi filter nahi lagana, YES aur NO dono records aayenge
            End If
            .Append(dateFilter)
            .Append(Unitfilter)
            .Append(" ORDER BY  A.Entryno ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _NewTmptbl As New DataTable
        _NewTmptbl = DefaltSoftTable.Copy

        dtSource = _NewTmptbl.Copy()
        Dim dtPivot As New DataTable()
        ' Fixed Columns
        dtPivot.Columns.Add("EntryNo")
        dtPivot.Columns.Add("ItemName")
        dtPivot.Columns.Add("UOM")
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
        Next
        ' DISTINCT ITEMS
        Dim items = dtSource.AsEnumerable().GroupBy(Function(r) New With {Key .ItemName = r("ITEMNAME").ToString(), Key .EntryNo = r("EntryNo").ToString(), Key .Brand = r("COMPANYNAME").ToString(), Key .CutName = r("CUTNAME").ToString(), Key .GodownCode = r("GodownCode").ToString()})
        For Each grp In items
            Dim newRow As DataRow = dtPivot.NewRow()
            Dim firstRow = grp.First()
            newRow("EntryNo") = firstRow("EntryNo").ToString()
            newRow("ItemName") = firstRow("ITEMNAME").ToString()
            newRow("UOM") = firstRow("CUTNAME").ToString()
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
                    Dim statusCol As BandedGridColumn = AddBandedColumn(bandedView, acc & "_Status", "Status")
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
            'GridControl1.Focus()
        End If
        Return _NewTmptbl
    End Function
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
    Private Sub bandedView_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)

        Dim view As BandedGridView = CType(sender, BandedGridView)

        If e.RowHandle < 0 Then Exit Sub

        'For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns

        '    If col.FieldName.EndsWith("_Status") Then

        '        Dim val As Object = view.GetRowCellValue(e.RowHandle, col)

        '        If val IsNot Nothing AndAlso
        '       val IsNot DBNull.Value AndAlso
        '       Convert.ToBoolean(val) = True Then

        '            e.Appearance.BackColor = Color.LemonChiffon
        '            e.Appearance.Options.UseBackColor = True
        '            e.HighPriority = True
        '            'Exit For

        '        End If

        '    End If

        'Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns

            ' Highest Priority
            If col.FieldName.EndsWith("_Status1") Then

                Dim val As Object = view.GetRowCellValue(e.RowHandle, col)

                If val IsNot Nothing AndAlso val IsNot DBNull.Value Then

                    Dim status As String = val.ToString().Trim().ToUpper()

                    If status = "TRUE" OrElse
                       status = "1" OrElse
                       status = "Y" OrElse
                       status = "YES" Then

                        e.Appearance.ForeColor = Color.Red
                        e.Appearance.Options.UseForeColor = True
                        e.HighPriority = True
                        Exit For        ' Red mil gaya to aur check karne ki zarurat nahi

                    End If

                End If

            End If

            ' Second Priority
            If col.FieldName.EndsWith("_Status") Then

                Dim val As Object = view.GetRowCellValue(e.RowHandle, col)

                If val IsNot Nothing AndAlso
                   val IsNot DBNull.Value AndAlso
                   Convert.ToBoolean(val) Then

                    e.Appearance.BackColor = Color.LemonChiffon
                    e.Appearance.Options.UseForeColor = True
                    e.HighPriority = True

                End If

            End If

        Next

    End Sub
    Private Sub bandedView_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'Dim view As BandedGridView = CType(sender, BandedGridView)


        'Dim view As BandedGridView = CType(sender, BandedGridView)
        'If view.FocusedColumn.FieldName.EndsWith("_Status") Then
        '    e.Cancel = True
        'End If
        'For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns

        '    If col.FieldName.EndsWith("_Status") Then

        '        Dim val As Object = view.GetFocusedRowCellValue(col)

        '        If val IsNot DBNull.Value AndAlso
        '           val IsNot Nothing AndAlso
        '           Convert.ToBoolean(val) Then

        '            e.Cancel = True   ' Row edit lock
        '            Exit For

        '        End If
        '    End If
        'Next
        Dim view As BandedGridView = CType(sender, BandedGridView)
        If view.FocusedColumn.FieldName.EndsWith("_View") Then
            Return    ' View button clickable rahega
        End If
        If view.FocusedColumn.FieldName.EndsWith("_Status") Then
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
        Next

    End Sub


    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        Try
            If e.KeyCode = Keys.Space Then
                Dim view As BandedGridView = TryCast(GridControl1.FocusedView, BandedGridView)
                If view Is Nothing Then Exit Sub
                If Not view.FocusedColumn.FieldName.EndsWith("_Status") Then Exit Sub
                '======== Row Lock Check ========
                Dim isLocked As Boolean = False

                For Each col As BandedGridColumn In view.Columns
                    If col.FieldName.EndsWith("_Status") Then
                        'Dim val As Object = view.GetRowCellValue(view.FocusedRowHandle, col)
                        'If val IsNot DBNull.Value AndAlso val IsNot Nothing AndAlso CBool(val) Then
                        '    isLocked = True
                        '    Exit For
                        'End If
                        Dim codeColumn As String = col.FieldName.Replace("_Status", "_Code")
                        Dim supplierCode1 As String = Convert.ToString(view.GetRowCellValue(view.FocusedRowHandle, codeColumn))
                        Dim bookVno1 As String = Convert.ToString(view.GetRowCellValue(view.FocusedRowHandle, "BOOKVNO"))
                        Dim dr1() As DataRow = dtSource.Select("BOOKVNO='" & bookVno1 & "' AND SupplierCode='" & supplierCode1 & "'")
                        If dr1.Length > 0 Then
                            Dim status As String = dr1(0)("Status").ToString().Trim().ToUpper()
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
                'Dim SupplierCode As String = ""
                'If view.FocusedColumn.FieldName.EndsWith("_Status") Then
                '    Dim codeColumn As String = view.FocusedColumn.FieldName.Replace("_Status", "_Code")
                '    SupplierCode = Convert.ToString(view.GetFocusedRowCellValue(codeColumn))
                'End If
                'Dim EntryNo As String = Convert.ToString(view.GetFocusedRowCellValue("EntryNo"))
                ' Status check
                Dim dr() As DataRow = dtSource.Select("BOOKVNO='" & BookVno & "' And SupplierCode='" & SupplierCode & "'")
                If dr.Length > 0 Then
                    If IsDBNull(dr(0)("Status")) Then Exit Sub
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
                                If col.FieldName.EndsWith("_Status") Then
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

    Private Sub btn_xl_Click(sender As Object, e As EventArgs) Handles btn_xl.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub But_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Department Approval By Head Report"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
        '_strQuery = New StringBuilder
        'With _strQuery
        '    Dim dateFilter As String = ""
        '    If Not String.IsNullOrEmpty(txt_From.Text) AndAlso Not String.IsNullOrEmpty(txt_To.Text) Then
        '        dateFilter = " AND A.PACK_SLIP_DATE >=  '" & txt_From.Date_for_Database & "' And A.PACK_SLIP_DATE <=  '" & txt_To.Date_for_Database & "'"
        '    End If
        '    .Append(" SELECT   ")
        '    .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') as Date, ")
        '    .Append(" A.Entryno AS EntryNo, ")
        '    .Append(" FORMAT( A.Mtr_weight,'0.00') AS Qty, ")
        '    .Append(" A.CUT_MTR AS GrossRate, ")
        '    .Append(" A.RDVALUE AS Dis, ")
        '    .Append(" A.WEIGHT AS Disamount, ")
        '    .Append(" A.RATE AS NetRate, ")
        '    .Append(" A.Amount AS Amount, ")
        '    .Append(" A.OP11 As Gst, ")
        '    .Append(" A.OP12 As Fright, ")
        '    .Append(" A.OP13 As Delivery, ")
        '    .Append(" A.OP4 As Paymentterms, ")
        '    .Append(" A.OP19 As Status, ")
        '    .Append(" A.Bookvno, ")
        '    .Append(" A.Itemcode, ")
        '    .Append(" B.ItemName AS ITEMNAME, ")
        '    .Append(" C.ACCOUNTNAME As SupplierName,  ")
        '    .Append(" A.ACCOUNTCODE As SupplierCode,  ")
        '    .Append(" E.CUTNAME, ")
        '    '.Append(" F.DepartmentName, ")
        '    .Append(" FORMAT(A.ENTRYDATE,'yyyy-MM-dd HH:mm:ss.fff') AS F_ENTRYDATE,  ")
        '    .Append(" FORMAT(A.MODYFIDATE,'yyyy-MM-dd HH:mm:ss.fff') AS MODYFIDATE,  ")
        '    .Append(" H.TYPE_NAME  AS COMPANYNAME ")
        '    .Append(" ,IIF(ISNULL(G.USEBOOKVNO,'')='','NO','YES') AS USEBY")
        '    .Append(" FROM  ")
        '    .Append(" TrnPackingSlip AS A  ")
        '    .Append(" LEFT JOIN MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE ")
        '    .Append(" LEFT JOIN MstMasterAccount As C ON A.ACCOUNTCODE=C.ACCOUNTCODE ")
        '    .Append(" LEFT JOIN MstCutMaster As E ON E.ID=A.CUTCODE ")
        '    .Append(" LEFT JOIN MstDepartment F  ON A.DESIGNCODE=F.Departmentcode ")
        '    .Append(" LEFT JOIN MstStoreItemType H ON  A.SHADECODE = H.TYPE_ID ")
        '    .Append(" Left Join ( SELECT OP7 AS USEBOOKVNO,ITEMCODE AS USEITEMCODE  FROM TrnPackingSlip GROUP BY OP7,ITEMCODE ) AS G ON ( A.BOOKVNO=G.USEBOOKVNO AND A.ITEMCODE=G.USEITEMCODE ) ")
        '    .Append(" WHERE 1=1  ")
        '    .Append(" AND  A.BookTrType='CESS1'")
        '    '.Append(" AND  A.BOOKVNO='" & strKeyID & "'")
        '    .Append(dateFilter)
        '    .Append(" ORDER BY  A.Entryno ")
        'End With
        'sqL = _strQuery.ToString
        'sql_connect_slect()
        'Dim _NewTmptbl As New DataTable
        '_NewTmptbl = DefaltSoftTable.Copy

        'dtSource = _NewTmptbl.Copy()
        'Dim dtPivot As New DataTable

        'dtPivot.Columns.Add("EntryNo")
        'dtPivot.Columns.Add("ItemName")
        'dtPivot.Columns.Add("UOM")
        'dtPivot.Columns.Add("BOOKVNO")

        'dtPivot.Columns.Add("SupplierName")
        'dtPivot.Columns.Add("Brand")
        'dtPivot.Columns.Add("Qty")
        'dtPivot.Columns.Add("GrossRate")
        'dtPivot.Columns.Add("Dis")
        'dtPivot.Columns.Add("Rate")
        'dtPivot.Columns.Add("Amount")
        'dtPivot.Columns.Add("GST")
        'dtPivot.Columns.Add("Fright")
        'dtPivot.Columns.Add("Delivery")
        'dtPivot.Columns.Add("Paymentterms")
        'dtPivot.Columns.Add("Status")
        'For Each r As DataRow In dtSource.Rows
        '    Dim newRow As DataRow = dtPivot.NewRow()
        '    newRow("EntryNo") = r("EntryNo")
        '    newRow("ItemName") = r("ITEMNAME")
        '    newRow("UOM") = r("CUTNAME")
        '    newRow("BOOKVNO") = r("BOOKVNO")
        '    newRow("SupplierName") = r("SupplierName")
        '    newRow("Brand") = r("COMPANYNAME")
        '    newRow("Qty") = r("Qty")
        '    newRow("GrossRate") = r("GrossRate")
        '    newRow("Dis") = r("Dis")
        '    newRow("Rate") = r("NetRate")
        '    newRow("Amount") = r("Amount")
        '    newRow("GST") = r("GST")
        '    newRow("Fright") = r("Fright")
        '    newRow("Delivery") = r("Delivery")
        '    newRow("Paymentterms") = r("Paymentterms")
        '    newRow("Status") = r("Status")
        '    dtPivot.Rows.Add(newRow)
        'Next
        'If dtPivot.Rows.Count > 0 Then
        '    'Dim Date_Range = "Audit Report  From : " & txt_From.Text & " TO " & txt_To.Text
        '    Dim RptTitle = "Department Approval Report"
        '    Dim Date_Range = ""
        '    If But_ok.Enabled = True Then
        '        If txt_From.Text <> "" AndAlso txt_To.Text <> "" Then
        '            REPORT_RPT_FILE_NAME = "DepartmentApprovalReport_1"
        '            NewReportPrint(dtPivot, RptTitle, Date_Range)
        '        End If
        '    End If
        'Else
        '    MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        'End If
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
        If conn.State = ConnectionState.Closed Then conn.Open()
        'Dim sql As String = "UPDATE " & _TblName & " SET " & "OP19 = @OP19, " & "OP23 = @MODYFIDATE WHERE BOOKVNO = @BOOKVNO " & "AND ITEMCODE = @ITEMCODE " & " And GodownCode=@GodownCode"
        Dim sql As String = "UPDATE " & _TblName & " SET " & "OP19 = @OP19, " & "OP23 = @MODYFIDATE WHERE BOOKVNO = @BOOKVNO " & "AND ITEMCODE = @ITEMCODE " & "AND EntryNo = @EntryNo " & "AND ACCOUNTCODE = @SupplierCode" & " And GodownCode=@GodownCode"
        'Dim sql As String = "UPDATE " & _TblName & " SET " & "OP19 = @OP19, " & "OP23 = @MODYFIDATE, " & "OP24 = @BOOKVNO " & " WHERE  ITEMCODE = @ITEMCODE " & "AND ISNULL(OP19,'NO') <> 'YES'"
        Using cmd As New SqlClient.SqlCommand(sql, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 420
            'For Each dr As DataRow In dt.Rows
            '    ' Check if any Status column is checked
            '    Dim SupplierCode As String = ""
            '    Dim IsApproved As Boolean = False
            '    'For Each col As DataColumn In dt.Columns
            '    '    If col.ColumnName.EndsWith("_Status") Then
            '    '        If Not IsDBNull(dr(col)) AndAlso Convert.ToBoolean(dr(col)) Then
            '    '            IsApproved = True
            '    '            Exit For
            '    '        End If
            '    '    End If
            '    '    If col.ColumnName.EndsWith("_Code") Then

            '    '        If Not IsDBNull(dr(col.ColumnName)) Then
            '    '            SupplierCode = dr(col.ColumnName).ToString()
            '    '            Exit For
            '    '        End If

            '    '    End If
            '    'Next
            '    For Each col As DataColumn In dt.Columns
            '        If col.ColumnName.EndsWith("_Status") Then
            '            If Not IsDBNull(dr(col)) AndAlso Convert.ToBoolean(dr(col)) Then
            '                IsApproved = True
            '                Dim codeColumn As String = col.ColumnName.Substring(0, col.ColumnName.Length - 7) & "_Code"
            '                If dt.Columns.Contains(codeColumn) Then
            '                    SupplierCode = dr(codeColumn).ToString()
            '                End If
            '                Exit For
            '            End If
            '        End If
            '    Next
            '    'Dim StatusValue As String = If(IsApproved, "YES", "NO")
            '    cmd.Parameters.Clear()
            '    'cmd.Parameters.AddWithValue("@OP19", StatusValue)
            '    cmd.Parameters.AddWithValue("@OP19", If(IsApproved, "YES", "NO"))
            '    If IsApproved Then
            '        cmd.Parameters.AddWithValue("@MODYFIDATE", Format(Now, "yyyy-MM-dd HH:mm:ss.fff"))
            '    End If
            '    cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
            '    cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
            '    cmd.Parameters.AddWithValue("@EntryNo", dr("EntryNo").ToString())
            '    cmd.Parameters.AddWithValue("@SupplierCode", SupplierCode)
            '    If IsApproved Then
            '    cmd.ExecuteNonQuery()
            '    End If
            'Next
            For Each dr As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns

                    If col.ColumnName.EndsWith("_Status") Then
                        Dim IsApproved As Boolean = False
                        If Not IsDBNull(dr(col)) Then
                            IsApproved = Convert.ToBoolean(dr(col))
                        End If
                        Dim codeColumn As String = col.ColumnName.Substring(0, col.ColumnName.Length - 7) & "_Code"
                        If dt.Columns.Contains(codeColumn) Then
                            Dim SupplierCode As String = Convert.ToString(dr(codeColumn))
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@OP19", If(IsApproved, "YES", "NO"))
                            cmd.Parameters.AddWithValue("@MODYFIDATE", If(IsApproved, Format(Now, "yyyy-MM-dd HH:mm:ss.fff"), DBNull.Value))
                            cmd.Parameters.AddWithValue("@BOOKVNO", dr("BOOKVNO").ToString())
                            cmd.Parameters.AddWithValue("@ITEMCODE", dr("ITEMCODE").ToString())
                            cmd.Parameters.AddWithValue("@EntryNo", dr("EntryNo").ToString())
                            cmd.Parameters.AddWithValue("@SupplierCode", SupplierCode)
                            cmd.Parameters.AddWithValue("@GodownCode", dr("GodownCode").ToString())
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                Next
            Next
        End Using
        conn.Close()
        MessageBox.Show("Data Updated Successfully")
        Generate_Date_For_DataBase(txt_To)
        _Zooming_Load(txt_To.Date_for_Database)
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