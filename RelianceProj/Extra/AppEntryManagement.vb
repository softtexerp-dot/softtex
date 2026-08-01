Imports System.Net.Http
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class AppEntryManagement
    Private CurDate As String = Now.Month.ToString & "/" & Now.Day.ToString & "/" & Now.Year.ToString

    Dim _CloseCheck As Boolean = False
    Private IsUpdating As Boolean = False
    Dim dbName As String = "Accounts39_142026103929"    'Top textbox या variable से
    Dim gst As String = "08AAECM5759M1ZT"               'Second textbox से
    'Dim BookTrtype As String = "O0001"
    'Dim BookVno As String = "O0001*00000*0039*00000094"
    'Dim BookCode As String = "0001-000000121"
    'Dim EntryNo As String = "94"
    Dim BookTrtype As String = ""
    Dim BookVno As String = ""
    Dim BookCode As String = ""
    Dim EntryNo As String = ""
    Dim dtSource As DataTable

    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub StoreConsumption_GridZooming_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'If _CloseCheck = True Then
            Close()
            Me.Dispose(True)
            'Else
            '_CloseCheck = True
            txt_From.Focus()
            'End If
        End If
    End Sub

    Private Sub StoreConsumption_GridZooming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        '_CloseCheck = True
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        '_Zooming_Load()
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        '_CloseCheck = False
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        _Zooming_Load()
        GridControl1.Focus()
    End Sub



    Private Sub _Zooming_Load()
        'If txtUnitName.Text = "" Then
        '    MsgBox("Select Unit Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        '    txtUnitName.Focus()
        '    txtUnitName.Select()
        '    Exit Sub
        'End If
        Using client As New HttpClient()
            dtSource = New DataTable
            Dim statustype As String = ""
            If TxtType.Text.Trim = "ORDER" Then
                statustype = "Finish Sales Offer Entry"
                'pick_rate
            End If
            If TxtType.Text.Trim = "INVOICE" Then
                statustype = "Finish Invoice Entry"
                'Rate
            End If
            Dim FromDate As String = DateTime.Parse(txt_From.Text).ToString("yyyy-MM-dd")
            Dim ToDate As String = DateTime.Parse(txt_To.Text).ToString("yyyy-MM-dd")
            'fixed URL 
            'http://softtextileappapi.softtexerp.com/api/offersCreate/
            Dim Status As String = txt_Status.Text.Trim.ToUpper()
            If Status.ToUpper() = "ALL" Then
                Status = ""
            End If
            Dim url As String = "http://softtextileappapi.softtexerp.com/api/offersCreate/GetOffersAndInvoiceData?dbName=" & dbName & "&entryType=" & statustype & "&gstno=" & gst & "&fromDate=" & FromDate & "&toDate=" & ToDate & "&status=" & Status & ""
            Dim response As String = client.GetStringAsync(url).Result
            'Dim json As JObject = JObject.Parse(response)
            'Dim response = client.GetAsync(url).Result
            'response.EnsureSuccessStatusCode()
            'Dim json = response.Content.ReadAsStringAsync().Result
            Dim json As JObject = JObject.Parse(response)

            If CBool(json("status")) Then
                'If Convert.ToBoolean(json("status")) = True Then
                Dim arr As JArray = CType(json("data"), JArray)
                dtSource.Columns.Add("EntryNo")
                dtSource.Columns.Add("BookTrType")
                dtSource.Columns.Add("BookVno")
                dtSource.Columns.Add("BookCode")
                dtSource.Columns.Add("OfferDate")
                dtSource.Columns.Add("PartyOfferNo")
                dtSource.Columns.Add("MeterWeight")
                dtSource.Columns.Add("ItemCode")
                dtSource.Columns.Add("ItemName")
                dtSource.Columns.Add("AccountCode")
                dtSource.Columns.Add("AccountName")
                dtSource.Columns.Add("DespatchCode")
                dtSource.Columns.Add("DispatchName")
                dtSource.Columns.Add("TransportCode")
                dtSource.Columns.Add("TransportName")
                dtSource.Columns.Add("SalesManCode")
                dtSource.Columns.Add("SalesmanName")
                dtSource.Columns.Add("CutCode")
                dtSource.Columns.Add("UOM")
                dtSource.Columns.Add("DesignCode")
                dtSource.Columns.Add("DesignName")
                dtSource.Columns.Add("ShadeCode")
                dtSource.Columns.Add("Brand")
                dtSource.Columns.Add("OfferNo")
                dtSource.Columns.Add("HeaderRemark")
                dtSource.Columns.Add("Qty")
                dtSource.Columns.Add("Rate")
                dtSource.Columns.Add("Amount")
                dtSource.Columns.Add("NetAmount")
                dtSource.Columns.Add("MendingCharge")
                dtSource.Columns.Add("Pcs")
                dtSource.Columns.Add("PickRate")
                dtSource.Columns.Add("Status")
                dtSource.Columns.Add("Description")
                dtSource.Columns.Add("Remark")
                dtSource.Columns.Add("EntryType")
                dtSource.Columns.Add("TaxPercentage")
                dtSource.Columns.Add("TaxAmount")
                dtSource.Columns.Add("DiscountPercentage")
                dtSource.Columns.Add("DiscountAmount")
                dtSource.Columns.Add("RowRemark")
                dtSource.Columns.Add("QtyType")
                dtSource.Columns.Add("RateNo")
                dtSource.Columns.Add("QtyMtr")
                dtSource.Columns.Add("Id")
                'Item Master
                Dim dtItem As DataTable = GetDataTable("SELECT ItemCode, ItemName FROM MstStoreItem")
                Dim ItemDict = dtItem.AsEnumerable().ToDictionary(Function(r) r("ItemCode").ToString(), Function(r) r("ItemName").ToString())
                'Account Master
                Dim dtAcc As DataTable = GetDataTable("SELECT AccountCode, AccountName FROM MstMasterAccount")
                Dim AccDict = dtAcc.AsEnumerable().ToDictionary(Function(r) r("AccountCode").ToString(), Function(r) r("AccountName").ToString())
                'City Master
                Dim dtCity As DataTable = GetDataTable("SELECT CityCode, CityName FROM MSTCITY")
                Dim CityDict = dtCity.AsEnumerable().ToDictionary(Function(r) r("CityCode").ToString(), Function(r) r("CityName").ToString())
                'Transport Master
                Dim dtTransport As DataTable = GetDataTable("SELECT ID, TransportName FROM MSTTRANSPORT")
                Dim TransportDict = dtTransport.AsEnumerable().ToDictionary(Function(r) r("ID").ToString(), Function(r) r("TransportName").ToString())
                'Salesman Master
                Dim dtSalesman As DataTable = GetDataTable("SELECT SalesmanCode, SalesmanName FROM MstSalesMan")
                Dim SalesmanDict = dtSalesman.AsEnumerable().ToDictionary(Function(r) r("SalesmanCode").ToString(), Function(r) r("SalesmanName").ToString())
                'Cut Master
                Dim dtCut As DataTable = GetDataTable("SELECT ID, CutName FROM MstCutMaster")
                Dim CutDict = dtCut.AsEnumerable().ToDictionary(Function(r) r("ID").ToString(), Function(r) r("CutName").ToString())
                'Design Master
                Dim dtDesign As DataTable = GetDataTable("SELECT Design_Code, Design_Name FROM Mst_Fabric_Design")
                Dim DesignDict = dtDesign.AsEnumerable().ToDictionary(Function(r) r("Design_Code").ToString(), Function(r) r("Design_Name").ToString())
                'Shade Master
                Dim dtShade As DataTable = GetDataTable("SELECT ShadeCode, ShadeName FROM MstMillShade")
                Dim ShadeDict = dtShade.AsEnumerable().ToDictionary(Function(r) r("ShadeCode").ToString(), Function(r) r("ShadeName").ToString())

                For Each r As JObject In arr
                    Dim dr As DataRow = dtSource.NewRow()
                    dr("EntryNo") = r("EntryNo").ToString()
                    dr("BookVno") = r("BookVno").ToString()
                    dr("BookTrType") = r("BookTrType").ToString()
                    dr("BookCode") = r("BookCode").ToString()
                    dr("OfferDate") = r("OfferDate").ToString()
                    dr("PartyOfferNo") = r("PartyOfferNo").ToString()
                    dr("MeterWeight") = r("MeterWeight").ToString()
                    dr("ItemCode") = r("ItemCode").ToString()
                    dr("AccountCode") = r("AccountCode").ToString()
                    dr("DespatchCode") = r("DespatchCode").ToString()
                    dr("TransportCode") = r("TransportCode").ToString()
                    dr("SalesManCode") = r("SalesManCode").ToString()
                    dr("CutCode") = r("CutCode").ToString()
                    dr("DesignCode") = r("DesignCode").ToString()
                    dr("ShadeCode") = r("ShadeCode").ToString()
                    dr("ItemName") = If(ItemDict.ContainsKey(r("ItemCode").ToString()), ItemDict(r("ItemCode").ToString()), "")
                    dr("AccountName") = If(AccDict.ContainsKey(r("AccountCode").ToString()), AccDict(r("AccountCode").ToString()), "")
                    dr("DispatchName") = If(CityDict.ContainsKey(r("DespatchCode").ToString()), CityDict(r("DespatchCode").ToString()), "")
                    dr("TransportName") = If(TransportDict.ContainsKey(r("TransportCode").ToString()), TransportDict(r("TransportCode").ToString()), "")
                    dr("SalesmanName") = If(SalesmanDict.ContainsKey(r("SalesManCode").ToString()), SalesmanDict(r("SalesManCode").ToString()), "")
                    dr("UOM") = If(CutDict.ContainsKey(r("CutCode").ToString()), CutDict(r("CutCode").ToString()), "")
                    dr("DesignName") = If(DesignDict.ContainsKey(r("DesignCode").ToString()), DesignDict(r("DesignCode").ToString()), "")
                    dr("Brand") = If(ShadeDict.ContainsKey(r("ShadeCode").ToString()), ShadeDict(r("ShadeCode").ToString()), "")
                    dr("OfferNo") = r("OfferNo").ToString()
                    'dr("OfferNo") = r("EntryNo").ToString()
                    dr("PartyOfferNo") = r("OfferNo").ToString()
                    dr("HeaderRemark") = r("HeaderRemark").ToString()
                    dr("Qty") = FormatDecimal(r("MeterWeight"))
                    'dr("GrossRate") = Format(Convert.ToDecimal(r("PickRate").ToString()), "0.00")
                    dr("Amount") = FormatDecimal(r("GrossAmount").ToString())
                    dr("Rate") = FormatDecimal(r("Rate").ToString())
                    dr("NetAmount") = FormatDecimal(r("NetAmount").ToString())
                    dr("Pcs") = FormatDecimal(r("Pcs").ToString())
                    dr("MendingCharge") = FormatDecimal(r("MendingCharge").ToString())
                    dr("PickRate") = FormatDecimal(r("PickRate").ToString())
                    dr("Status") = r("Status").ToString()
                    dr("Description") = r("Description").ToString()
                    dr("Remark") = r("RowRemark").ToString()
                    dr("EntryType") = r("EntryType").ToString()
                    dr("TaxPercentage") = FormatDecimal(r("TaxPercentage").ToString())
                    dr("TaxAmount") = FormatDecimal(r("TaxAmount").ToString())
                    dr("DiscountPercentage") = FormatDecimal(r("DiscountPercentage").ToString())
                    dr("DiscountAmount") = FormatDecimal(r("DiscountAmount").ToString())
                    dr("RowRemark") = r("RowRemark").ToString()
                    dr("QtyType") = r("QtyType").ToString()
                    dr("RateNo") = r("RateNo").ToString()
                    dr("QtyMtr") = r("QtyMtr").ToString()
                    dr("Id") = r("Id").ToString()
                    dtSource.Rows.Add(dr)
                Next
                dtSource.Columns.Add("SelectRow", GetType(Boolean))
                Dim SelectedIds As New List(Of Integer)

                For Each dr As DataRow In dtSource.Rows
                    If Not IsDBNull(dr("SelectRow")) AndAlso Convert.ToBoolean(dr("SelectRow")) Then
                        SelectedIds.Add(Convert.ToInt32(dr("Id")))
                        dr("SelectRow") = True
                    Else
                        dr("SelectRow") = False
                    End If
                    'If Convert.ToBoolean(dr("SelectRow")) Then
                    '    Select Case dr("Status").ToString().ToUpper()
                    '        Case "PENDING"
                    '            dr("Status") = "HOLD"
                    '        Case "HOLD"
                    '            dr("Status") = "APPROVE"
                    '        Case "APPROVE"
                    '            dr("Status") = "CANCEL"
                    '        Case "CANCEL"
                    '            dr("Status") = "PENDING"
                    '    End Select
                    'End If
                Next
                GridControl1.DataSource = dtSource
                Dim view As GridView = CType(GridControl1.MainView, GridView)
                view.Columns("BookVno").Visible = False
                view.Columns("ItemCode").Visible = False
                view.Columns("AccountCode").Visible = False
                view.Columns("DespatchCode").Visible = False
                view.Columns("TransportCode").Visible = False
                view.Columns("SalesManCode").Visible = False
                view.Columns("CutCode").Visible = False
                view.Columns("DesignCode").Visible = False
                view.Columns("ShadeCode").Visible = False
                view.Columns("BookTrType").Visible = False
                view.Columns("BookCode").Visible = False
                view.Columns("OfferDate").Visible = False
                view.Columns("PartyOfferNo").Visible = False
                view.Columns("MeterWeight").Visible = False

                view.Columns("Pcs").Visible = False
                view.Columns("TaxPercentage").Visible = False
                view.Columns("TaxAmount").Visible = False
                view.Columns("DiscountPercentage").Visible = False
                view.Columns("DiscountAmount").Visible = False

                Dim chk As New RepositoryItemCheckEdit
                chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
                chk.ValueChecked = True
                chk.ValueUnchecked = False
                GridControl1.RepositoryItems.Add(chk)
                view.Columns("SelectRow").ColumnEdit = chk
                view.Columns("SelectRow").VisibleIndex = 0
                view = CType(GridControl1.MainView, GridView)

                view.OptionsView.ColumnAutoWidth = False
                view.OptionsBehavior.Editable = True
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                    col.OptionsColumn.AllowEdit = False
                    col.OptionsColumn.ReadOnly = True
                Next
                With view.Columns("SelectRow")
                    .OptionsColumn.AllowEdit = True
                    .OptionsColumn.ReadOnly = False
                    .ColumnEdit = chk
                End With
                'view.OptionsBehavior.Editable = True
                view.BestFitColumns()
                AddHandler view.KeyDown, AddressOf GridView1_KeyDown
                AddHandler view.RowCellStyle, AddressOf GridView1_RowCellStyle
            End If
        End Using
    End Sub
    Private Function GetDataTable(ByVal Query As String) As DataTable
        sqL = Query
        sql_connect_slect()
        Return DefaltSoftTable.Copy()
    End Function
    Private Function FormatDecimal(value As Object) As String
        Dim d As Decimal = 0D
        Decimal.TryParse(Convert.ToString(value), d)
        Return d.ToString("0.00")
    End Function

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Space Then Exit Sub
        Dim view As GridView = CType(sender, GridView)
        Dim RowHandle As Integer = view.FocusedRowHandle
        If RowHandle < 0 Then Exit Sub
        ' Sirf Status column par hi chale
        If view.FocusedColumn.FieldName <> "Status" Then Exit Sub
        Dim IsChecked As Boolean = False
        If Not IsDBNull(view.GetRowCellValue(RowHandle, "SelectRow")) Then
            IsChecked = Convert.ToBoolean(view.GetRowCellValue(RowHandle, "SelectRow"))
        End If
        ' Sirf checked row par hi status change ho
        If Not IsChecked Then
            MessageBox.Show("Please select the row before changing its status.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim CurrentStatus As String = Convert.ToString(view.GetRowCellValue(RowHandle, "Status")).Trim().ToUpper()
        Select Case CurrentStatus
            Case "PENDING"
                view.SetRowCellValue(RowHandle, "Status", "HOLD")
            Case "HOLD"
                view.SetRowCellValue(RowHandle, "Status", "APPROVE")
            Case "APPROVE"
                view.SetRowCellValue(RowHandle, "Status", "CANCEL")
            Case "CANCEL"
                view.SetRowCellValue(RowHandle, "Status", "PENDING")
            Case Else
                view.SetRowCellValue(RowHandle, "Status", "PENDING")
        End Select
        e.Handled = True
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim view As GridView = CType(sender, GridView)
        If e.RowHandle < 0 Then Exit Sub
        Dim Status As String = Convert.ToString(view.GetRowCellValue(e.RowHandle, "Status")).Trim.ToUpper()
        Select Case Status
            Case "PENDING"
                e.Appearance.BackColor = Color.FromArgb(255, 243, 205)   'Light Amber
                e.Appearance.ForeColor = Color.FromArgb(133, 100, 4)
            Case "HOLD"
                e.Appearance.BackColor = Color.FromArgb(255, 230, 204)   'Light Orange
                e.Appearance.ForeColor = Color.FromArgb(156, 87, 0)
            Case "APPROVE"
                e.Appearance.BackColor = Color.FromArgb(212, 237, 218)   'Light Green
                e.Appearance.ForeColor = Color.FromArgb(21, 87, 36)
            Case "CANCEL"
                e.Appearance.BackColor = Color.FromArgb(248, 215, 218)   'Light Red
                e.Appearance.ForeColor = Color.FromArgb(114, 28, 36)
            Case "ALL"
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
        End Select
    End Sub
    Private Sub UpdateOfferStatus(Id As Integer, Status As String, RowIndex As Integer)
        Try
            'Dim view As GridView = CType(GridControl1.MainView, GridView)
            Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
            Dim url As String = "http://softtextileappapi.softtexerp.com/api/offersCreate/UpdateOfferStatus"
            Dim requestBody = New With {
                .databaseName = dbName,
                .gstno = gst,
                .Id = Id,
                .Status = Status
            }
            Dim json As String = JsonConvert.SerializeObject(requestBody)
            Using client As New HttpClient()
                Dim content As New StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json")
                Dim response = client.PostAsync(url, content).Result
                If Not response.IsSuccessStatusCode Then
                    MessageBox.Show(response.Content.ReadAsStringAsync().Result)
                End If
                If response.IsSuccessStatusCode Then
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Txt_ViewType_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            But_ok.Focus()
        End If
    End Sub


#Region "Save Grid Layout"
    Private Sub btnviewupdate_Click(sender As Object, e As EventArgs) Handles btnviewupdate.Click
        Dim view As GridView = CType(GridControl1.MainView, GridView)

        Dim UpdatedCount As Integer = 0
        'If txtUnitName.Text <> "" Then
        Dim srno As Integer = 0
            For i As Integer = 0 To view.RowCount - 1
                Dim IsChecked As Boolean = False
                If Not IsDBNull(view.GetRowCellValue(i, "SelectRow")) Then
                    IsChecked = Convert.ToBoolean(view.GetRowCellValue(i, "SelectRow"))
                End If
                If IsChecked Then
                    Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                    'EntryNo = Convert.ToInt32(view.GetRowCellValue(i, "EntryNo"))

                    strQuery = "SELECT ISNULL(MAX(ENTRYNO),0) + 1 AS ENTRYNO FROM TrnOffer AS A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
                    sqL = strQuery
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
                    Else
                        EntryNo = 1
                    End If
                    If BookCode <> "" Then
                        Dim TmpTbl As New DataTable
                        sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                        sql_connect_slect()
                        TmpTbl = DefaltSoftTable.Copy

                        If TmpTbl.Rows.Count > 0 Then
                            BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                            BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                        End If
                    End If
                    Dim Status As String = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
                _strQuery = New StringBuilder
                    Dim QtyMtr As String = "0.00"
                    Dim Rate As String = "0.00"
                    Dim PickRate As String = "0.00"
                    If Not IsDBNull(view.GetRowCellValue(i, "QtyMtr")) Then
                        QtyMtr = Val(view.GetRowCellValue(i, "QtyMtr")).ToString("0.00")
                    End If
                    If Not IsDBNull(view.GetRowCellValue(i, "Rate")) Then
                        Rate = Val(view.GetRowCellValue(i, "Rate")).ToString("0.00")
                    End If
                    If Not IsDBNull(view.GetRowCellValue(i, "PickRate")) Then
                        PickRate = Val(view.GetRowCellValue(i, "PickRate")).ToString("0.00")
                    End If
                    If Status = "APPROVE" Then
                        srno += 1
                        With _strQuery
                            .Append(" insert into TrnOffer ( ")
                            .Append(" ENTRYNO")
                            .Append(" ,BookTrtype")
                            .Append(" ,BookVno")
                            .Append(" ,BookCode")
                            .Append(" ,OfferNo")
                            .Append(" ,OfferDate")
                            .Append(" ,PartyOfferNo")
                            .Append(" ,ACOFCODE")
                            .Append(" ,AccountCode")
                            .Append(" ,TransportCode")
                            .Append(" ,DespatchCode")
                            .Append(" ,HeaderRemark")
                            .Append(" ,SRNO")
                            .Append(" ,ItemCode")
                            .Append(" ,CutCode")
                            .Append(" ,DesignCode")
                            .Append(" ,ShadeCode")
                            .Append(" ,Mtr_Weight")
                            If TxtType.Text.Trim = "ORDER" Then
                                .Append(" ,PICK_RATE")
                                .Append(" ,Rate")
                            End If
                            If TxtType.Text.Trim = "INVOICE" Then
                                .Append(" ,PICK_RATE")
                                .Append(" ,Rate")
                            End If
                            .Append(" ,CDVALUE")
                            .Append(" ,clear")
                            .Append(" ,Gross_Rate")
                            .Append(" ,Net_Rate")
                            .Append(" ,SalesManCode")
                            .Append(" ,MENDING_CHG")
                            .Append(" ,Pcs_Bales")
                            .Append(" ,AvgWeight")
                            .Append(" ,RDVALUE")
                            .Append(" ,Descr")
                            .Append(" ,RowRemark")
                            .Append(" ,LOTNO")
                            .Append(" ,loomtype")
                            .Append(" ,QTYMTR")
                            .Append(" ,Process_Slab_Weight")
                            .Append(" ,Process_Weight_Rate")
                            .Append(" ,Process_Weight_Range")
                            .Append(" ,Process_Net_Rate")
                        .Append(" ,OP1") 'grid online BookVno
                        .Append(" ,cancel_Qty")
                        .Append(" ,PICK")
                        .Append(" ,WESTAGE")
                        .Append(" ,NO_OF_BEAM")
                        .Append(" ,EXTRA_CHG")
                        .Append(" ,Process_Slab_Rate")
                        .Append(" ,OP11")
                        .Append(" ) VALUES (")
                            .Append("'" & EntryNo & "'")
                            .Append(",'" & BookTrtype & "'")
                            .Append(",'" & BookVno & "'")
                            .Append(",'" & BookCode & "'")
                            .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
                            .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")), "yyyy-MM-dd HH:mm:ss") & "'")
                            .Append(",'" & view.GetRowCellValue(i, "PartyOfferNo").ToString() & "'")
                            .Append(",'0000-000000001'")
                            .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "TransportCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "DespatchCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "HeaderRemark").ToString() & "'")
                            .Append(",'" & srno & "'")
                            .Append(",'" & view.GetRowCellValue(i, "ItemCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "CutCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "DesignCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "ShadeCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "MeterWeight").ToString() & "'")
                            If TxtType.Text.Trim = "ORDER" Then
                                '.Append(",'" & view.GetRowCellValue(i, "PickRate").ToString() & "'")
                                .Append(",'" & PickRate & "'")
                                .Append(",'0.00'")
                            End If
                            If TxtType.Text.Trim = "INVOICE" Then
                                '.Append(",'" & view.GetRowCellValue(i, "Rate").ToString() & "'")
                                .Append(",'0.00'")
                                .Append(",'" & Rate & "'")
                            End If
                            .Append(",'" & view.GetRowCellValue(i, "DiscountAmount").ToString() & "'")
                            .Append(",'NO'")
                            .Append(",'" & view.GetRowCellValue(i, "Amount").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "NetAmount").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "SalesManCode").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "Pcs").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "TaxPercentage").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "TaxAmount").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "DiscountPercentage").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "Description").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "RowRemark").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "QtyType").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "RateNo").ToString() & "'")
                            .Append(",'" & QtyMtr & "'")
                            .Append(",'" & view.GetRowCellValue(i, "DiscountPercentage").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "DiscountAmount").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "TaxPercentage").ToString() & "'")
                            .Append(",'" & view.GetRowCellValue(i, "TaxAmount").ToString() & "'")
                        .Append(",'" & view.GetRowCellValue(i, "BookVno").ToString() & "'")
                        .Append(",'0.00'")
                        .Append(",'0.00'")
                        .Append(",'0.00'")
                        .Append(",'0.00'")
                        .Append(",'0.00'")
                        .Append(",'0.00'")
                        .Append(",'0.00'")
                        .Append(")")
                        End With
                        sqL = _strQuery.ToString
                    sql_Data_Save_Delete_Update()
                    UpdatedCount += 1
                    End If
                End If
        Next
        If UpdatedCount > 0 Then
            MessageBox.Show(UpdatedCount & " row(s) updated successfully.")
        Else
            MessageBox.Show("No row selected.")
        End If
        _Zooming_Load()
    End Sub

    Private Sub TxtType_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtType.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Space Then
            If TxtType.Text.Trim = "ORDER" Then
                BookCode = "0001-000010029"
                BookTrtype = "ONL29"
            End If
            If TxtType.Text.Trim = "INVOICE" Then
                BookCode = "0001-000010030"
                BookTrtype = "ONL30"
            End If
        End If
    End Sub

    Private Sub TxtType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtType.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) OrElse e.KeyChar = " "c Then
            If TxtType.Text.Trim = "ORDER" Then
                BookCode = "0001-000010029"
                BookTrtype = "ONL29"
            End If
            If TxtType.Text.Trim = "INVOICE" Then
                BookCode = "0001-000010030"
                BookTrtype = "ONL30"
            End If
        End If
    End Sub

    'Private Sub txtUnitName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitName.KeyPress
    '    If Asc(e.KeyChar) = 27 Then Exit Sub
    '    If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
    '        Dim _Filterstring As String = ""
    '        If TxtType.Text = "ORDER" Then
    '            _Filterstring = " AND A.BOOKCATEGORY='OFFER' and A.BEHAVIOUR='FINISH' and A.Nature='SALES' and A.ACTIVE_STATUS='YES'"
    '        ElseIf TxtType.Text = "INVOICE" Then
    '            _Filterstring = " AND A.BOOKCATEGORY='INVOICE' and A.BEHAVIOUR='FINISH' and A.Nature='PURCHASE' and A.ACTIVE_STATUS='YES'"
    '        End If
    '        Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)
    '        Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtUnitName.Text, "SINGLE")
    '        If selected IsNot Nothing Then
    '            If selected.ContainsKey("ACCOUNTCODE") Then BookCode = selected("ACCOUNTCODE").ToString()
    '            If selected.ContainsKey("BookName") Then txtUnitName.Text = selected("BookName").ToString()
    '        End If
    '        SendKeys.Send("{TAB}")
    '    End If
    'End Sub
#End Region
End Class