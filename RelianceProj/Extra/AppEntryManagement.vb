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
    'Dim gst As String = "08AAECM5759M1ZT"    'Second textbox से
    Dim gst As String = "08DEMOGST123456"    'Second textbox से
    'Dim BookTrtype As String = "O0001"
    'Dim BookVno As String = "O0001*00000*0039*00000094"
    'Dim BookCode As String = "0001-000000121"
    'Dim EntryNo As String = "94"
    Dim BookTrtype As String = ""
    Dim BookVno As String = ""
    Dim BookCode As String = ""
    Dim EntryNo As String = ""
    Private CurrentImageUrl As String = ""
    Private CurrentImageBytes() As Byte = Nothing
    Private SpaceKeyPressed As Boolean = False

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
        End If
    End Sub

    Private Sub StoreConsumption_GridZooming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        _Zooming_Load()
        GridControl1.Focus()
    End Sub



    Private Sub _Zooming_Load()
        Using client As New HttpClient()

            Dim statustype As String = ""
            If TxtType.Text.Trim = "ORDER" Then
                statustype = "Finish Sales Offer Entry"
            End If
            If TxtType.Text.Trim = "INVOICE" Then
                statustype = "Finish Invoice Entry"
            End If
            Dim FromDate As String = DateTime.Parse(txt_From.Text).ToString("yyyy-MM-dd")
            Dim ToDate As String = DateTime.Parse(txt_To.Text).ToString("yyyy-MM-dd")
            Dim Status As String = txt_Status.Text.Trim.ToUpper()
            If Status.ToUpper() = "ALL" Then
                Status = ""
            End If
            Dim url As String = ""
            Dim response As String = ""
            If TxtType.Text = "LR UPDATE" Then
                url = "http://softtextileappapi.softtexerp.com/api/offersCreate/GetPendingLRUpdate?databaseName=" & dbName & "&gstno=" & gst & "&Status=" & Status
            Else
                url = "http://softtextileappapi.softtexerp.com/api/offersCreate/GetOffersAndInvoiceData?dbName=" & dbName & "&entryType=" & statustype & "&gstno=" & gst & "&fromDate=" & FromDate & "&toDate=" & ToDate & "&status=" & Status
            End If
            response = client.GetStringAsync(url).Result
            Dim json As JObject = JObject.Parse(response)
            If CBool(json("status")) Then
                If TxtType.Text = "LR UPDATE" Then
                    LoadLRUpdateData(json)
                ElseIf TxtType.Text.Trim = "ORDER" Then
                    LoadOffersData(json)
                ElseIf TxtType.Text.Trim = "INVOICE" Then
                    LoadInvoiceData(json)
                End If
            End If
        End Using
    End Sub
    Private Sub LoadLRUpdateData(ByVal json As JObject)
        Try
            Dim arr As JArray = CType(json("data"), JArray)
            Dim LRdtSource = New DataTable()
            LRdtSource.Columns.Clear()
            If json Is Nothing Then
                MessageBox.Show("No response was received from the API.", "API Response", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If json("data") Is Nothing OrElse json("data").Type = JTokenType.Null Then
                MessageBox.Show("No LR Update records were found.", "LR Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If arr Is Nothing Then
                MessageBox.Show("The LR Update data received from the API is not in a valid format.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            LRdtSource.Columns.Add("Id")
            LRdtSource.Columns.Add("DatabaseName")
            LRdtSource.Columns.Add("GstNo")
            LRdtSource.Columns.Add("CompanyCode")
            LRdtSource.Columns.Add("BookVno")
            LRdtSource.Columns.Add("BillNo")
            LRdtSource.Columns.Add("BillDate")
            LRdtSource.Columns.Add("AccountCode")
            LRdtSource.Columns.Add("AccountName")
            LRdtSource.Columns.Add("TransportCode")
            LRdtSource.Columns.Add("TransportName")
            LRdtSource.Columns.Add("EwayBillNo")
            LRdtSource.Columns.Add("DispatchCode")
            LRdtSource.Columns.Add("DispatchName")
            LRdtSource.Columns.Add("LRNo")
            LRdtSource.Columns.Add("LRDate")
            LRdtSource.Columns.Add("Remark")
            LRdtSource.Columns.Add("EntryNo")
            LRdtSource.Columns.Add("EntryDate")
            LRdtSource.Columns.Add("ViewImage")
            LRdtSource.Columns.Add("Status")
            LRdtSource.Columns.Add("ImageUrl")
            LRdtSource.Columns.Add("ImageId")
            Dim dtAcc As DataTable = GetDataTable("SELECT AccountCode, AccountName FROM MstMasterAccount")
            If dtAcc Is Nothing Then
                Throw New Exception("Unable to retrieve account master data. The MstMasterAccount data source returned no data.")
            End If
            Dim AccDict As New Dictionary(Of String, String)
            For Each row As DataRow In dtAcc.Rows
                Dim code As String = ""
                If Not IsDBNull(row("AccountCode")) Then
                    code = row("AccountCode").ToString().Trim()
                End If
                If code <> "" AndAlso Not AccDict.ContainsKey(code) Then
                    If IsDBNull(row("AccountName")) Then
                        AccDict.Add(code, "")
                    Else
                        AccDict.Add(code, row("AccountName").ToString())
                    End If
                End If
            Next
            Dim dtTransport As DataTable = GetDataTable("SELECT ID, TransportName FROM MSTTRANSPORT")
            If dtTransport Is Nothing Then
                Throw New Exception("Unable to retrieve transport master data. The MSTTRANSPORT data source returned no data.")
            End If
            Dim TransportDict As New Dictionary(Of String, String)
            For Each row As DataRow In dtTransport.Rows
                Dim code As String = ""
                If Not IsDBNull(row("ID")) Then
                    code = row("ID").ToString().Trim()
                End If
                If code <> "" AndAlso Not TransportDict.ContainsKey(code) Then
                    If IsDBNull(row("TransportName")) Then
                        TransportDict.Add(code, "")
                    Else
                        TransportDict.Add(code, row("TransportName").ToString())
                    End If
                End If
            Next
            Dim dtCity As DataTable = GetDataTable("SELECT CityCode, CityName FROM MSTCITY")
            If dtCity Is Nothing Then
                Throw New Exception("Unable to retrieve city master data. The MSTCITY data source returned no data.")
            End If
            Dim CityDict As New Dictionary(Of String, String)
            For Each row As DataRow In dtCity.Rows
                Dim code As String = ""
                If Not IsDBNull(row("CityCode")) Then
                    code = row("CityCode").ToString().Trim()
                End If
                If code <> "" AndAlso Not CityDict.ContainsKey(code) Then
                    If IsDBNull(row("CityName")) Then
                        CityDict.Add(code, "")
                    Else
                        CityDict.Add(code, row("CityName").ToString())
                    End If
                End If
            Next
            For Each r As JObject In arr
                If r Is Nothing Then Continue For
                Dim dr As DataRow = LRdtSource.NewRow()
                dr("Id") = GetJsonValue(r, "Id")
                dr("DatabaseName") = GetJsonValue(r, "DatabaseName")
                dr("GstNo") = GetJsonValue(r, "GstNo")
                dr("CompanyCode") = GetJsonValue(r, "CompanyCode")
                dr("BookVno") = GetJsonValue(r, "BookVno")
                dr("BillNo") = GetJsonValue(r, "BillNo")
                dr("BillDate") = GetJsonDate(r, "BillDate")
                dr("AccountCode") = GetJsonValue(r, "AccountCode")
                Dim accountCode As String = dr("AccountCode").ToString().Trim()
                If AccDict.ContainsKey(accountCode) Then
                    dr("AccountName") = AccDict(accountCode)
                Else
                    dr("AccountName") = ""
                End If
                dr("TransportCode") = GetJsonValue(r, "TransportCode")
                Dim transportCode As String = dr("TransportCode").ToString().Trim()
                If TransportDict.ContainsKey(transportCode) Then
                    dr("TransportName") = TransportDict(transportCode)
                Else
                    dr("TransportName") = ""
                End If
                dr("EwayBillNo") = GetJsonValue(r, "EwayBillNo")
                dr("DispatchCode") = GetJsonValue(r, "DispatchCode")
                Dim dispatchCode As String =
                dr("DispatchCode").ToString().Trim()
                If CityDict.ContainsKey(dispatchCode) Then
                    dr("DispatchName") = CityDict(dispatchCode)
                Else
                    dr("DispatchName") = ""
                End If
                dr("LRNo") = GetJsonValue(r, "LRNo")
                dr("LRDate") = GetJsonDate(r, "LRDate")
                dr("Remark") = GetJsonValue(r, "Remark")
                dr("EntryNo") = GetJsonValue(r, "EntryNo")
                dr("EntryDate") = GetJsonDate(r, "EntryDate")
                dr("Status") = GetJsonValue(r, "Status")
                dr("ImageUrl") = GetJsonValue(r, "ImageUrl")
                dr("ImageId") = GetJsonValue(r, "ImageId")
                dr("ViewImage") = "View"
                LRdtSource.Rows.Add(dr)
            Next
            LRdtSource.Columns.Add("SelectRow", GetType(Boolean))
            For Each dr As DataRow In LRdtSource.Rows
                dr("SelectRow") = False
            Next
            If GridControl1 Is Nothing Then
                Throw New Exception("Unable to initialize the grid. GridControl1 is not available.")
            End If
            GridControl1.DataSource = Nothing
            FirstStage.Columns.Clear()
            GridControl1.DataSource = LRdtSource.Copy
            If FirstStage Is Nothing Then
                Throw New Exception("Unable to initialize the grid view. The main GridView is not available.")
            End If
            FirstStage.OptionsView.ColumnAutoWidth = False
            FirstStage.OptionsBehavior.Editable = True
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
            Next
            Dim chk As New RepositoryItemCheckEdit
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
            chk.ValueChecked = True
            chk.ValueUnchecked = False
            GridControl1.RepositoryItems.Add(chk)
            With FirstStage.Columns("SelectRow")
                .ColumnEdit = chk
                .Visible = True
                .VisibleIndex = 0
                .OptionsColumn.AllowEdit = True
                .OptionsColumn.ReadOnly = False
            End With
            Dim btnViewImage As New RepositoryItemButtonEdit()
            btnViewImage.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            btnViewImage.Buttons.Clear()
            Dim btn As New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            btn.Caption = "View"
            btnViewImage.Buttons.Add(btn)
            GridControl1.RepositoryItems.Add(btnViewImage)
            With FirstStage.Columns("ViewImage")
                .ColumnEdit = btnViewImage
                .Caption = "Image"
                .Visible = True
                .OptionsColumn.AllowEdit = True
                .OptionsColumn.ReadOnly = False
                .Width = 80
            End With
            AddHandler btnViewImage.ButtonClick, AddressOf LRViewImage_ButtonClick
            FirstStage.Columns("Id").Visible = False
            FirstStage.Columns("BookVno").Visible = False
            FirstStage.Columns("DatabaseName").Visible = False
            FirstStage.Columns("GstNo").Visible = False
            FirstStage.Columns("CompanyCode").Visible = False
            FirstStage.Columns("AccountCode").Visible = False
            FirstStage.Columns("TransportCode").Visible = False
            FirstStage.Columns("DispatchCode").Visible = False
            FirstStage.Columns("ImageUrl").Visible = False
            FirstStage.Columns("ImageId").Visible = False
            FirstStage.BestFitColumns()
            '========================================
            ' EVENTS
            '========================================
            AddHandler FirstStage.KeyDown, AddressOf GridView1_KeyDown
            AddHandler FirstStage.KeyUp, AddressOf GridView1_KeyUp
            AddHandler FirstStage.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            MessageBox.Show("Unable to load LR Update data." & vbCrLf & vbCrLf & "Details: " & ex.Message, "LR Update Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LRViewImage_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Try
            Dim LRview As GridView = TryCast(GridControl1.MainView, GridView)
            If LRview Is Nothing Then Exit Sub
            Dim rowHandle As Integer = LRview.FocusedRowHandle
            If rowHandle < 0 Then Exit Sub
            Dim imageUrl As String = Convert.ToString(LRview.GetRowCellValue(rowHandle, "ImageUrl")).Trim()
            If String.IsNullOrWhiteSpace(imageUrl) Then
                MessageBox.Show("No image is available for this entry.", "Image Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Image Panel me show karna
            _ImageView_Click(imageUrl, "", "EDIT")
        Catch ex As Exception
            MessageBox.Show("Unable to load the image." & vbCrLf & vbCrLf & "Details: " & ex.Message, "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetJsonValue(ByVal r As JObject, ByVal fieldName As String) As String
        If r Is Nothing Then Return ""
        Dim token As JToken = r(fieldName)
        If token Is Nothing OrElse token.Type = JTokenType.Null Then
            Return ""
        End If
        Return token.ToString()
    End Function

    Private Function GetJsonDate(ByVal r As JObject, ByVal fieldName As String) As String
        If r Is Nothing Then Return ""
        Dim token As JToken = r(fieldName)
        If token Is Nothing OrElse token.Type = JTokenType.Null Then
            Return ""
        End If
        Dim dt As DateTime
        If DateTime.TryParse(token.ToString(), dt) Then
            Return dt.ToString("dd/MM/yyyy")
        End If
        Return ""
    End Function

    Private Sub LoadOffersData(ByVal json As JObject)
        Try
            Dim arr As JArray = CType(json("data"), JArray)
            Dim dtSource = New DataTable()
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
            Dim dtItem As DataTable =
            GetDataTable("SELECT ItemCode, ItemName FROM MstStoreItem")
            Dim ItemDict = dtItem.AsEnumerable().ToDictionary(Function(r) r("ItemCode").ToString(), Function(r) r("ItemName").ToString())
            Dim dtAcc As DataTable = GetDataTable("SELECT AccountCode, AccountName FROM MstMasterAccount")
            Dim AccDict = dtAcc.AsEnumerable().ToDictionary(Function(r) r("AccountCode").ToString(), Function(r) r("AccountName").ToString())
            Dim dtCity As DataTable = GetDataTable("SELECT CityCode, CityName FROM MSTCITY")
            Dim CityDict = dtCity.AsEnumerable().ToDictionary(Function(r) r("CityCode").ToString(), Function(r) r("CityName").ToString())
            Dim dtTransport As DataTable = GetDataTable("SELECT ID, TransportName FROM MSTTRANSPORT")
            Dim TransportDict = dtTransport.AsEnumerable().ToDictionary(Function(r) r("ID").ToString(), Function(r) r("TransportName").ToString())
            Dim dtSalesman As DataTable = GetDataTable("SELECT SalesmanCode, SalesmanName FROM MstSalesMan")
            Dim SalesmanDict = dtSalesman.AsEnumerable().ToDictionary(Function(r) r("SalesmanCode").ToString(), Function(r) r("SalesmanName").ToString())
            Dim dtCut As DataTable = GetDataTable("SELECT ID, CutName FROM MstCutMaster")
            Dim CutDict = dtCut.AsEnumerable().ToDictionary(Function(r) r("ID").ToString(), Function(r) r("CutName").ToString())
            Dim dtDesign As DataTable = GetDataTable("SELECT Design_Code, Design_Name FROM Mst_Fabric_Design")
            Dim DesignDict = dtDesign.AsEnumerable().ToDictionary(Function(r) r("Design_Code").ToString(), Function(r) r("Design_Name").ToString())
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
                dr("PartyOfferNo") = r("OfferNo").ToString()
                dr("HeaderRemark") = r("HeaderRemark").ToString()
                dr("Qty") = FormatDecimal(r("MeterWeight"))
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
            For Each dr As DataRow In dtSource.Rows
                dr("SelectRow") = False
            Next
            GridControl1.DataSource = Nothing
            FirstStage.Columns.Clear()
            GridControl1.DataSource = dtSource.Copy
            FirstStage.OptionsView.ColumnAutoWidth = False
            FirstStage.OptionsBehavior.Editable = True
            FirstStage.Columns("BookVno").Visible = False
            FirstStage.Columns("ItemCode").Visible = False
            FirstStage.Columns("AccountCode").Visible = False
            FirstStage.Columns("DespatchCode").Visible = False
            FirstStage.Columns("TransportCode").Visible = False
            FirstStage.Columns("SalesManCode").Visible = False
            FirstStage.Columns("CutCode").Visible = False
            FirstStage.Columns("DesignCode").Visible = False
            FirstStage.Columns("ShadeCode").Visible = False
            FirstStage.Columns("BookTrType").Visible = False
            FirstStage.Columns("BookCode").Visible = False
            FirstStage.Columns("OfferDate").Visible = False
            FirstStage.Columns("PartyOfferNo").Visible = False
            FirstStage.Columns("MeterWeight").Visible = False
            FirstStage.Columns("Pcs").Visible = False
            FirstStage.Columns("TaxPercentage").Visible = False
            FirstStage.Columns("TaxAmount").Visible = False
            FirstStage.Columns("DiscountPercentage").Visible = False
            FirstStage.Columns("DiscountAmount").Visible = False

            Dim chk As New RepositoryItemCheckEdit

            chk.NullStyle =
            DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked

            chk.ValueChecked = True
            chk.ValueUnchecked = False

            GridControl1.RepositoryItems.Add(chk)

            FirstStage.Columns("SelectRow").ColumnEdit = chk
            FirstStage.Columns("SelectRow").VisibleIndex = 0

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
            Next

            With FirstStage.Columns("SelectRow")
                .OptionsColumn.AllowEdit = True
                .OptionsColumn.ReadOnly = False
                .ColumnEdit = chk
            End With

            FirstStage.BestFitColumns()
            '========================================
            ' EVENTS
            '========================================
            AddHandler FirstStage.KeyDown, AddressOf GridView1_KeyDown
            AddHandler FirstStage.KeyUp, AddressOf GridView1_KeyUp
            AddHandler FirstStage.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading Offers/Invoice data." & vbCrLf & "Details: " & ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadInvoiceData(ByVal json As JObject)
        Try
            Dim arr As JArray = CType(json("data"), JArray)
            Dim dtSource = New DataTable()
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
            Dim dtItem As DataTable =
            GetDataTable("SELECT ItemCode, ItemName FROM MstStoreItem")
            Dim ItemDict = dtItem.AsEnumerable().ToDictionary(Function(r) r("ItemCode").ToString(), Function(r) r("ItemName").ToString())
            Dim dtAcc As DataTable = GetDataTable("SELECT AccountCode, AccountName FROM MstMasterAccount")
            Dim AccDict = dtAcc.AsEnumerable().ToDictionary(Function(r) r("AccountCode").ToString(), Function(r) r("AccountName").ToString())
            Dim dtCity As DataTable = GetDataTable("SELECT CityCode, CityName FROM MSTCITY")
            Dim CityDict = dtCity.AsEnumerable().ToDictionary(Function(r) r("CityCode").ToString(), Function(r) r("CityName").ToString())
            Dim dtTransport As DataTable = GetDataTable("SELECT ID, TransportName FROM MSTTRANSPORT")
            Dim TransportDict = dtTransport.AsEnumerable().ToDictionary(Function(r) r("ID").ToString(), Function(r) r("TransportName").ToString())
            Dim dtSalesman As DataTable = GetDataTable("SELECT SalesmanCode, SalesmanName FROM MstSalesMan")
            Dim SalesmanDict = dtSalesman.AsEnumerable().ToDictionary(Function(r) r("SalesmanCode").ToString(), Function(r) r("SalesmanName").ToString())
            Dim dtCut As DataTable = GetDataTable("SELECT ID, CutName FROM MstCutMaster")
            Dim CutDict = dtCut.AsEnumerable().ToDictionary(Function(r) r("ID").ToString(), Function(r) r("CutName").ToString())
            Dim dtDesign As DataTable = GetDataTable("SELECT Design_Code, Design_Name FROM Mst_Fabric_Design")
            Dim DesignDict = dtDesign.AsEnumerable().ToDictionary(Function(r) r("Design_Code").ToString(), Function(r) r("Design_Name").ToString())
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
                dr("PartyOfferNo") = r("OfferNo").ToString()
                dr("HeaderRemark") = r("HeaderRemark").ToString()
                dr("Qty") = FormatDecimal(r("MeterWeight"))
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
            For Each dr As DataRow In dtSource.Rows
                dr("SelectRow") = False
            Next
            GridControl1.DataSource = Nothing
            FirstStage.Columns.Clear()
            GridControl1.DataSource = dtSource.Copy
            FirstStage.OptionsView.ColumnAutoWidth = False
            FirstStage.OptionsBehavior.Editable = True
            FirstStage.Columns("BookVno").Visible = False
            FirstStage.Columns("ItemCode").Visible = False
            FirstStage.Columns("AccountCode").Visible = False
            FirstStage.Columns("DespatchCode").Visible = False
            FirstStage.Columns("TransportCode").Visible = False
            FirstStage.Columns("SalesManCode").Visible = False
            FirstStage.Columns("CutCode").Visible = False
            FirstStage.Columns("DesignCode").Visible = False
            FirstStage.Columns("ShadeCode").Visible = False
            FirstStage.Columns("BookTrType").Visible = False
            FirstStage.Columns("BookCode").Visible = False
            FirstStage.Columns("OfferDate").Visible = False
            FirstStage.Columns("PartyOfferNo").Visible = False
            FirstStage.Columns("MeterWeight").Visible = False
            FirstStage.Columns("Pcs").Visible = False
            FirstStage.Columns("TaxPercentage").Visible = False
            FirstStage.Columns("TaxAmount").Visible = False
            FirstStage.Columns("DiscountPercentage").Visible = False
            FirstStage.Columns("DiscountAmount").Visible = False

            Dim chk As New RepositoryItemCheckEdit

            chk.NullStyle =
            DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked

            chk.ValueChecked = True
            chk.ValueUnchecked = False

            GridControl1.RepositoryItems.Add(chk)

            FirstStage.Columns("SelectRow").ColumnEdit = chk
            FirstStage.Columns("SelectRow").VisibleIndex = 0

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
            Next

            With FirstStage.Columns("SelectRow")
                .OptionsColumn.AllowEdit = True
                .OptionsColumn.ReadOnly = False
                .ColumnEdit = chk
            End With

            FirstStage.BestFitColumns()
            '========================================
            ' EVENTS
            '========================================
            AddHandler FirstStage.KeyDown, AddressOf GridView1_KeyDown
            AddHandler FirstStage.KeyUp, AddressOf GridView1_KeyUp
            AddHandler FirstStage.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading Offers/Invoice data." & vbCrLf & "Details: " & ex.Message, "Data Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        ' Ek Space press ko sirf ek baar process kare
        If SpaceKeyPressed Then
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If
        SpaceKeyPressed = True
        Dim view As GridView = TryCast(sender, GridView)
        If view Is Nothing Then Exit Sub
        Dim RowHandle As Integer = view.FocusedRowHandle
        If RowHandle < 0 Then Exit Sub
        ' Sirf Status column par hi chale
        If view.FocusedColumn Is Nothing OrElse view.FocusedColumn.FieldName <> "Status" Then Exit Sub
        '---------------------------------------
        ' SelectRow check
        '---------------------------------------
        Dim IsChecked As Boolean = False
        Dim SelectValue As Object = view.GetRowCellValue(RowHandle, "SelectRow")
        If SelectValue IsNot Nothing AndAlso SelectValue IsNot DBNull.Value Then
            IsChecked = Convert.ToBoolean(SelectValue)
        End If
        ' Sirf checked row par status change ho
        If Not IsChecked Then
            MessageBox.Show("Please select the row before changing its status.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Handled = True
            e.SuppressKeyPress = True
            Exit Sub
        End If
        '---------------------------------------
        ' Current Status
        '---------------------------------------
        Dim CurrentStatus As String = Convert.ToString(view.GetRowCellValue(RowHandle, "Status")).Trim().ToUpper()
        '---------------------------------------
        ' Change Status
        '---------------------------------------
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
        'view.PostEditor()
        'view.UpdateCurrentRow()
        ' Space ko Grid ke default action tak jane se roke
        e.Handled = True
        e.SuppressKeyPress = True
    End Sub
    Private Sub GridView1_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Space Then
            SpaceKeyPressed = False
        End If
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Try
            Dim view As GridView = CType(sender, GridView)
            If view Is Nothing Then Exit Sub
            If e.RowHandle < 0 Then Exit Sub
            If e.Column Is Nothing Then Exit Sub
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
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateOfferStatusLR(Id As Integer, Status As String, RowIndex As Integer)
        Try
            Dim dt As DataTable = CType(GridControl1.DataSource, DataTable)
            Dim url As String = "http://softtextileappapi.softtexerp.com/api/offersCreate/UpdateLRStatus"
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
        Dim srno As Integer = 0
        For i As Integer = 0 To view.RowCount - 1
            Dim IsChecked As Boolean = False
            If Not IsDBNull(view.GetRowCellValue(i, "SelectRow")) Then
                IsChecked = Convert.ToBoolean(view.GetRowCellValue(i, "SelectRow"))
            End If
            If IsChecked Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                'EntryNo = Convert.ToInt32(view.GetRowCellValue(i, "EntryNo"))
                Dim Status As String = ""
                If TxtType.Text = "LR UPDATE" Then
                    Dim TmpTbl As New DataTable
                    Dim BOOKVNO As String = ""
                    sqL = "SELECT * FROM TrnInvoiceHeader WHERE BOOKVNO='" & view.GetRowCellValue(i, "BookVno").ToString() & "' "
                    sql_connect_slect()
                    TmpTbl = DefaltSoftTable.Copy
                    If TmpTbl.Rows.Count > 0 Then
                        BOOKVNO = TmpTbl(0)("BOOKVNO").ToString
                    End If
                    _strQuery = New StringBuilder
                    If BOOKVNO <> "" Then
                        Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
                        UpdateOfferStatusLR(Id, Status, i)
                        If Status = "APPROVE" Then
                            srno += 1
                            With _strQuery
                                .Append(" update TrnInvoiceHeader Set ")
                                .Append("PORTCODE='" & view.GetRowCellValue(i, "EntryNo").ToString() & "'")
                                .Append(",SHIPPINGBILLNO='" & view.GetRowCellValue(i, "ImageUrl").ToString() & "'")
                                .Append(" Where BOOKVNO='" & BOOKVNO & "'")
                            End With
                            sqL = _strQuery.ToString
                            sql_Data_Save_Delete_Update()
                            UpdatedCount += 1
                        Else
                            UpdatedCount += 1
                        End If
                    Else
                        MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        IsChecked = False
                        Exit Sub
                    End If
                ElseIf TxtType.Text.Trim = "ORDER" Then
                    If SaveApprovedOfferRow(view, i, srno) Then
                        UpdatedCount += 1
                    End If
                ElseIf TxtType.Text.Trim = "INVOICE" Then

                    If SaveApprovedInvoiceHeaderRow(view, i, srno) Then
                        'UpdatedCount += 1
                    End If
                    If SaveApprovedInvoiceDetailRow(view, i, srno) Then
                        'UpdatedCount += 1
                    End If
                    If SaveApprovedInvoiceSundryRow(view, i, srno) Then
                        'UpdatedCount += 1
                    End If
                    If SaveApprovedInvoiceTrnledgerRow(view, i, srno) Then
                        '    'UpdatedCount += 1
                    End If
                    If SaveApprovedInvoiceOutstandingRow(view, i, srno) Then
                        '    'UpdatedCount += 1
                    End If
                    UpdatedCount += 1
                    End If
                End If
        Next
        If UpdatedCount > 0 Then
            MessageBox.Show(TxtType.Text & " " & UpdatedCount & " row(s) updated successfully.")
        Else
            MessageBox.Show(TxtType.Text & " " & UpdatedCount & " row(s) updated successfully.")
            'MessageBox.Show("No row selected.")
        End If
        _Zooming_Load()
    End Sub
    Private Function SaveApprovedOfferRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
        Try

            Dim EntryNo As Integer = 1
            Dim Status As String = ""
            Dim IsChecked As Boolean = False
            strQuery = "SELECT ISNULL(MAX(ENTRYNO),0) + 1 AS ENTRYNO FROM TrnOffer AS A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
            Else
                EntryNo = 1
            End If
            If BookCode <> "" Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                Dim TmpTbl As New DataTable
                'sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                'sql_connect_slect()
                RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
                MenuDesign_QueryLoad()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                    BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                End If
                Status = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
            Else
                MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IsChecked = False
                Return False
            End If
            Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
            If Status <> "APPROVE" Then
                Return True
            End If
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
            srno += 1
            _strQuery = New StringBuilder
            With _strQuery
                .Append("INSERT INTO TrnOffer (")
                .Append("ENTRYNO")
                .Append(",BookTrtype")
                .Append(",BookVno")
                .Append(",BookCode")
                .Append(",OfferNo")
                .Append(",OfferDate")
                .Append(",PartyOfferNo")
                .Append(",ACOFCODE")
                .Append(",AccountCode")
                .Append(",TransportCode")
                .Append(",DespatchCode")
                .Append(",HeaderRemark")
                .Append(",SRNO")
                .Append(",ItemCode")
                .Append(",CutCode")
                .Append(",DesignCode")
                .Append(",ShadeCode")
                .Append(",Mtr_Weight")
                If TxtType.Text.Trim.ToUpper() = "ORDER" Then
                    .Append(",PICK_RATE")
                    .Append(",Rate")
                ElseIf TxtType.Text.Trim.ToUpper() = "INVOICE" Then
                    .Append(",PICK_RATE")
                    .Append(",Rate")
                End If
                .Append(",CDVALUE")
                .Append(",clear")
                .Append(",Gross_Rate")
                .Append(",Net_Rate")
                .Append(",SalesManCode")
                .Append(",MENDING_CHG")
                .Append(",Pcs_Bales")
                .Append(",AvgWeight")
                .Append(",RDVALUE")
                .Append(",Descr")
                .Append(",RowRemark")
                .Append(",LOTNO")
                .Append(",loomtype")
                .Append(",QTYMTR")
                .Append(",Process_Slab_Weight")
                .Append(",Process_Weight_Rate")
                .Append(",Process_Weight_Range")
                .Append(",Process_Net_Rate")
                .Append(",OP1")
                .Append(",cancel_Qty")
                .Append(",PICK")
                .Append(",WESTAGE")
                .Append(",NO_OF_BEAM")
                .Append(",EXTRA_CHG")
                .Append(",Process_Slab_Rate")
                .Append(",OP11")
                .Append(") VALUES (")
                .Append("'" & EntryNo & "'")
                .Append(",'" & BookTrtype & "'")
                .Append(",'" & BookVno & "'")
                .Append(",'" & BookCode & "'")
                .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                      "yyyy-MM-dd HH:mm:ss") & "'")
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
                If TxtType.Text.Trim.ToUpper() = "ORDER" Then
                    .Append(",'" & PickRate & "'")
                    .Append(",'0.00'")
                ElseIf TxtType.Text.Trim.ToUpper() = "INVOICE" Then
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
            '-------------------------------------------------------
            ' 10. Save
            '-------------------------------------------------------
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the offer data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "Offer Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    'Private Function SaveApprovedInvoiceHeaderRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
    '    Try
    '        Dim BookCode As String = view.GetRowCellValue(i, "BookCode").ToString().Trim()
    '        Dim BookTrtype As String = ""
    '        Dim BookVno As String = ""
    '        Dim EntryNo As Integer = 1
    '        Dim Status As String = ""
    '        '-------------------------------------------------------
    '        ' 1. Get Next EntryNo
    '        '-------------------------------------------------------
    '        strQuery = "SELECT ISNULL(MAX(ENTRYNO),0) + 1 AS ENTRYNO FROM TRNINVOICEHEADER AS A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
    '        sqL = strQuery
    '        sql_connect_slect()
    '        If DefaltSoftTable.Rows.Count > 0 Then
    '            EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
    '        Else
    '            EntryNo = 1
    '        End If
    '        '-------------------------------------------------------
    '        ' 2. Validate Book Code
    '        '-------------------------------------------------------
    '        If String.IsNullOrWhiteSpace(BookCode) Then
    '            MessageBox.Show("Book Code is missing. Please verify the Book Code.", "Book Code Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Return False
    '        End If
    '        Dim TmpTbl As New DataTable
    '        RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
    '        MenuDesign_QueryLoad()
    '        TmpTbl = DefaltSoftTable.Copy
    '        If TmpTbl.Rows.Count = 0 Then
    '            'MessageBox.Show("The specified Book Code was not found. Please verify the Book Code.", "Book Code Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            'Return False
    '        Else
    '            BookTrtype = TmpTbl.Rows(0)("BOOKTRTYPE").ToString()
    '            BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
    '        End If
    '        '-------------------------------------------------------
    '        ' 4. Get Status
    '        '-------------------------------------------------------
    '        Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
    '        '-------------------------------------------------------
    '        ' 5. Update Offer Status
    '        '-------------------------------------------------------
    '        Dim Id As String = view.GetRowCellValue(i, "Id").ToString()
    '        UpdateOfferStatus(Id, Status, i)
    '        '-------------------------------------------------------
    '        ' 6. Only APPROVE rows will be inserted
    '        '-------------------------------------------------------
    '        If Status <> "APPROVE" Then
    '            Return True
    '        End If
    '        '-------------------------------------------------------
    '        ' 7. Prepare Values
    '        '-------------------------------------------------------
    '        Dim QtyMtr As String = "0.00"
    '        Dim Rate As String = "0.00"
    '        Dim PickRate As String = "0.00"
    '        If Not IsDBNull(view.GetRowCellValue(i, "QtyMtr")) Then
    '            QtyMtr = Val(view.GetRowCellValue(i, "QtyMtr")).ToString("0.00")
    '        End If
    '        If Not IsDBNull(view.GetRowCellValue(i, "Rate")) Then
    '            Rate = Val(view.GetRowCellValue(i, "Rate")).ToString("0.00")
    '        End If
    '        If Not IsDBNull(view.GetRowCellValue(i, "PickRate")) Then
    '            PickRate = Val(view.GetRowCellValue(i, "PickRate")).ToString("0.00")
    '        End If
    '        '-------------------------------------------------------
    '        ' 8. SRNO
    '        '-------------------------------------------------------
    '        srno += 1
    '        '-------------------------------------------------------
    '        ' 9. Insert Query
    '        '-------------------------------------------------------
    '        _strQuery = New StringBuilder
    '        With _strQuery
    '            .Append("INSERT INTO TRNINVOICEHEADER (")
    '            .Append("ENTRYNO")
    '            .Append(",BookTrtype")
    '            .Append(",BookVno")
    '            .Append(",BookCode")
    '            .Append(",BILLNO")
    '            .Append(",BILLDATE")
    '            .Append(",LRDATE")
    '            .Append(",ACOFCODE")
    '            .Append(",AccountCode")
    '            .Append(",TransportCode")
    '            .Append(",DespatchCode")
    '            .Append(",Header_Remark")
    '            .Append(",SRNO")
    '            .Append(",TOTAL_MTR_WEIGHT")
    '            .Append(",GROSS_AMOUNT")
    '            .Append(",NET_AMOUNT")
    '            .Append(",TOTAL_BALES")
    '            .Append(",TOTAL_PCS")
    '            .Append(") VALUES (")
    '            .Append("'" & EntryNo & "'")
    '            .Append(",'" & BookTrtype & "'")
    '            .Append(",'" & BookVno & "'")
    '            .Append(",'" & BookCode & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
    '            .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
    '                                  "yyyy-MM-dd HH:mm:ss") & "'")
    '            .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
    '                                  "yyyy-MM-dd HH:mm:ss") & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "AcofCode").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "TransportCode").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "DespatchCode").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "HeaderRemark").ToString() & "'")
    '            .Append(",'" & srno & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "MeterWeight").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "Amount").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "NetAmount").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "TaxPercentage").ToString() & "'")
    '            .Append(",'" & view.GetRowCellValue(i, "Pcs").ToString() & "'")
    '            .Append(")")
    '        End With
    '        '-------------------------------------------------------
    '        ' 10. Save
    '        '-------------------------------------------------------
    '        sqL = _strQuery.ToString
    '        sql_Data_Save_Delete_Update()
    '        Return True
    '    Catch ex As Exception
    '        MessageBox.Show("An error occurred while saving the invoice header data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "Invoice Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    End Try
    'End Function
    Private Function SaveApprovedInvoiceHeaderRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
        Try

            Dim EntryNo As Integer = 1
            Dim Status As String = ""
            Dim IsChecked As Boolean = False
            strQuery = "SELECT ISNULL(MAX(ENTRYNO),0) + 1 AS ENTRYNO FROM TRNINVOICEHEADER AS A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
            Else
                EntryNo = 1
            End If
            If BookCode <> "" Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                Dim TmpTbl As New DataTable
                'sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                'sql_connect_slect()
                RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
                MenuDesign_QueryLoad()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                    BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                End If
                Status = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
            Else
                MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IsChecked = False
                Return False
            End If

            If view.GetRowCellValue(i, "Status") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(i, "Status")) Then
                Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
            End If
            If Status <> "APPROVE" Then
                Return True
            End If
            Dim OfferNo As String = ""
            If view.GetRowCellValue(i, "OfferNo") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(i, "OfferNo")) Then
                OfferNo = view.GetRowCellValue(i, "OfferNo").ToString().Trim()
            End If
            Dim TotalMtrWeight As Decimal = 0D
            Dim GrossAmount As Decimal = 0D
            Dim NetAmount As Decimal = 0D
            Dim TotalBales As Decimal = 0D
            Dim TotalPcs As Decimal = 0D
            For RowIndex As Integer = 0 To view.RowCount - 1
                Dim RowStatus As String = ""
                If view.GetRowCellValue(RowIndex, "Status") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(RowIndex, "Status")) Then
                    RowStatus = view.GetRowCellValue(RowIndex, "Status").ToString().Trim().ToUpper()
                End If
                If RowStatus = "APPROVE" Then
                    Dim RowOfferNo As String = ""
                    If view.GetRowCellValue(RowIndex, "OfferNo") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(RowIndex, "OfferNo")) Then
                        RowOfferNo = view.GetRowCellValue(RowIndex, "OfferNo").ToString().Trim()
                    End If
                    'Sirf same OfferNo ki rows ka total
                    If RowOfferNo = OfferNo Then
                        '-------------------------------------------
                        ' Meter Weight
                        '-------------------------------------------
                        If view.GetRowCellValue(RowIndex, "MeterWeight") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(RowIndex, "MeterWeight")) Then
                            TotalMtrWeight += Val(view.GetRowCellValue(RowIndex, "MeterWeight"))
                        End If
                        '-------------------------------------------
                        ' Gross Amount
                        '-------------------------------------------
                        If view.GetRowCellValue(RowIndex, "Amount") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(RowIndex, "Amount")) Then
                            GrossAmount += Val(view.GetRowCellValue(RowIndex, "Amount"))
                        End If
                        '-------------------------------------------
                        ' Net Amount
                        '-------------------------------------------
                        If view.GetRowCellValue(RowIndex, "NetAmount") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(RowIndex, "NetAmount")) Then
                            NetAmount += Val(view.GetRowCellValue(RowIndex, "NetAmount"))
                        End If
                        '-------------------------------------------
                        ' Total Pcs
                        '-------------------------------------------
                        If view.GetRowCellValue(RowIndex, "Pcs") IsNot Nothing AndAlso Not IsDBNull(view.GetRowCellValue(RowIndex, "Pcs")) Then
                            TotalPcs += Val(view.GetRowCellValue(RowIndex, "Pcs"))
                        End If
                    End If
                End If
            Next
            srno += 1
            _strQuery = New StringBuilder
            With _strQuery
                .Append("INSERT INTO TRNINVOICEHEADER (")
                .Append("ENTRYNO")
                .Append(",BookTrtype")
                .Append(",BookVno")
                .Append(",BookCode")
                .Append(",BILLNO")
                .Append(",BILLDATE")
                .Append(",LRDATE")
                .Append(",ACOFCODE")
                .Append(",AccountCode")
                .Append(",TransportCode")
                .Append(",DespatchCode")
                .Append(",Header_Remark")
                .Append(",SRNO")
                .Append(",TOTAL_MTR_WEIGHT")
                .Append(",GROSS_AMOUNT")
                .Append(",NET_AMOUNT")
                .Append(",TOTAL_BALES")
                .Append(",TOTAL_PCS")
                .Append(") VALUES (")
                .Append("'" & EntryNo & "'")
                .Append(",'" & BookTrtype & "'")
                .Append(",'" & BookVno & "'")
                .Append(",'" & BookCode & "'")
                .Append(",'" & OfferNo & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                  "yyyy-MM-dd HH:mm:ss") & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                  "yyyy-MM-dd HH:mm:ss") & "'")
                .Append(",'0000-000000001'")
                .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "TransportCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "DespatchCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "HeaderRemark").ToString() & "'")
                .Append(",'" & srno & "'")
                .Append(",'" & TotalMtrWeight.ToString("0.00") & "'")
                .Append(",'" & GrossAmount.ToString("0.00") & "'")
                .Append(",'" & NetAmount.ToString("0.00") & "'")
                .Append(",'" & TotalBales.ToString("0.00") & "'")
                .Append(",'" & TotalPcs.ToString("0.00") & "'")
                .Append(")")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the invoice header data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "Invoice Header Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function SaveApprovedInvoiceDetailRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
        Try
            Dim EntryNo As Integer = 1
            Dim Status As String = ""
            Dim IsChecked As Boolean = False
            strQuery = "SELECT ISNULL(MAX(ENTRYNO),0) + 1 AS ENTRYNO FROM trninvoicedetail AS A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
            Else
                EntryNo = 1
            End If
            If BookCode <> "" Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                Dim TmpTbl As New DataTable
                'sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                'sql_connect_slect()
                RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
                MenuDesign_QueryLoad()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                    BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                End If
                Status = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
            Else
                MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IsChecked = False
                Return False
            End If
            Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
            If Status <> "APPROVE" Then
                Return True
            End If
            '-------------------------------------------------------
            ' 7. Prepare Values
            '-------------------------------------------------------
            Dim Rate As String = "0.00"
            If Not IsDBNull(view.GetRowCellValue(i, "Rate")) Then
                Rate = Val(view.GetRowCellValue(i, "Rate")).ToString("0.00")
            End If
            '-------------------------------------------------------
            ' 8. SRNO
            '-------------------------------------------------------
            srno += 1
            '-------------------------------------------------------
            ' 9. Insert Query
            '-------------------------------------------------------
            _strQuery = New StringBuilder
            With _strQuery
                .Append("INSERT INTO trninvoicedetail (")
                .Append("ENTRYNO")
                .Append(",BookTrtype")
                .Append(",BookVno")
                .Append(",BookCode")
                .Append(",OfferNo")
                .Append(",BillDate")
                .Append(",AccountCode")
                .Append(",TransportCode")
                .Append(",DespatchCode")
                .Append(",SRNO")
                .Append(",ItemCode")
                .Append(",CutCode")
                .Append(",DesignCode")
                .Append(",ShadeCode")
                .Append(",Mtr_Weight")
                .Append(",Rate")
                .Append(",Gross_Rate")
                .Append(",NET_AMOUNT")
                .Append(",PCS")
                .Append(",Pcs_Bales")
                .Append(",taxper")
                .Append(",taxamount")
                .Append(",Amount")
                .Append(",Net_Rate")
                .Append(",RATE_DIS_PER")
                .Append(",OFFERENTRYNO")
                .Append(",OTHER_ADD")
                .Append(",OTHER_LESS")
                .Append(",CGST_TAX_RATE")
                .Append(",SGST_TAX_RATE")
                .Append(",IGST_TAX_RATE")
                .Append(",CGST_TAX_AMT")
                .Append(",SGST_TAX_AMT")
                .Append(",IGST_TAX_AMT")
                .Append(",AVGWEIGHT")
                .Append(",PICKRATE")
                .Append(",WEIGHT")
                .Append(",DIS_PER")
                .Append(",DIS_AMOUNT")
                .Append(",QTY")
                .Append(",RD")
                .Append(",CD")
                .Append(",CESS_TAX_RATE")
                .Append(",CESS_TAX_AMT")

                .Append(",Descr")
                .Append(",RowRemark")
                .Append(",LOTNO")
                .Append(",RATEON")
                .Append(",ROUND_OFF")
                .Append(",PICK")
                .Append(") VALUES (")
                .Append("'" & EntryNo & "'")
                .Append(",'" & BookTrtype & "'")
                .Append(",'" & BookVno & "'")
                .Append(",'" & BookCode & "'")
                .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                      "yyyy-MM-dd HH:mm:ss") & "'")
                .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "TransportCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "DespatchCode").ToString() & "'")
                .Append(",'" & srno & "'")
                .Append(",'" & view.GetRowCellValue(i, "ItemCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "CutCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "DesignCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "ShadeCode").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "MeterWeight").ToString() & "'")
                .Append(",'" & Rate & "'")
                .Append(",'" & view.GetRowCellValue(i, "Amount").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "NetAmount").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "Pcs").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "TaxPercentage").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "TaxAmount").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "TaxAmount").ToString() & "'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(",'" & view.GetRowCellValue(i, "DiscountPercentage").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "Description").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "RowRemark").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "QtyType").ToString() & "'")
                .Append(",'" & view.GetRowCellValue(i, "RateNo").ToString() & "'")
                .Append(",'0.00'")
                .Append(",'0.00'")
                .Append(")")
            End With
            '-------------------------------------------------------
            ' 10. Save
            '-------------------------------------------------------
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the invoice details data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "Invoice Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function SaveApprovedInvoiceSundryRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
        Try
            Dim EntryNo As Integer = 1
            Dim SP_ACCOUNTCODE As String = ""
            Dim TAX_ACCOUNTCODE As String = ""
            Dim AMOUNT_FOR_TAX As String = ""
            Dim DRCR As String = "DR"
            Dim OPPACCOUNTCODE As String = ""
            Dim TRANS_FOR As String = ""
            Dim FINACCOUNTCODE As String = ""
            Dim Status As String = ""
            Dim IsChecked As Boolean = False
            strQuery = "SELECT ISNULL(MAX(ENTRYNO),0) + 1 AS ENTRYNO FROM trninvoicesundry AS A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
            Else
                EntryNo = 1
            End If
            If BookCode <> "" Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                Dim TmpTbl As New DataTable
                'sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                'sql_connect_slect()
                RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
                MenuDesign_QueryLoad()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                    BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                End If
                Status = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
            Else
                MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IsChecked = False
                Return False
            End If
            Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
            If Status <> "APPROVE" Then
                Return True
            End If
            srno += 1
            _strQuery = New StringBuilder
            With _strQuery
                .Append("INSERT INTO trninvoicesundry (")
                .Append("SP_ACCOUNTCODE")
                .Append(",TAX_ACCOUNTCODE")
                .Append(",AMOUNT_FOR_TAX")
                .Append(",DRCR")
                .Append(",OPPACCOUNTCODE")
                .Append(",TRANS_FOR")
                .Append(",ENTRYNO")
                .Append(",BookTrtype")
                .Append(",BookVno")
                .Append(",BookCode")
                .Append(",BILLNO")
                .Append(",BILLDate")
                .Append(",AccountCode")
                .Append(",SRNO")
                .Append(",FINACCOUNTCODE")
                .Append(",SUNCODE")
                .Append(",AUTOROUNDOFF")
                .Append(",COMMU_TOTAL")
                .Append(",TAX_PER")
                .Append(",SUNNATURE")
                .Append(",FINANCEPOST")
                .Append(",ADDLESSTYPE")
                .Append(",CALCBY")
                .Append(",CALCON")
                .Append(",CALCRATE")
                .Append(",CALCAMOUNT")
                .Append(") select ")
                .Append("'" & SP_ACCOUNTCODE & "'")
                .Append(",'" & TAX_ACCOUNTCODE & "'")
                .Append("," & GetNumericValue(AMOUNT_FOR_TAX))
                .Append(",'" & DRCR & "'")
                .Append(",'" & OPPACCOUNTCODE & "'")
                .Append(",'" & TRANS_FOR & "'")
                .Append("," & GetNumericValue(EntryNo))
                .Append(",'" & BookTrtype & "'")
                .Append(",'" & BookVno & "'")
                .Append(",'" & BookCode & "'")
                .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                      "yyyy-MM-dd HH:mm:ss") & "'")
                .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
                .Append("," & GetNumericValue(srno))
                .Append(",'" & FINACCOUNTCODE & "'")
                .Append(",SUNCODE")
                .Append(",AUTOROUND")
                .Append(",0")
                .Append(",0")
                .Append(",SUNNATURE")
                .Append(",FINANCEPOST")
                .Append(",ADDLESSTYPE")
                .Append(",CALCBY")
                .Append(",CALCON")
                .Append(",0")
                .Append(",0")
                .Append(" FROM TrnBillSundry ")
                .Append(" Where 1=1 and BookCode='0001-000000029'")
                '.Append(" Where 1=1 and BookCode='" & BookCode & "'")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the invoice Sundry data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "Invoice Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function GetNumericValue(ByVal Value As String) As String
        Dim Number As Decimal
        If String.IsNullOrWhiteSpace(Value) Then
            Return "0"
        End If
        If Decimal.TryParse(Value.Trim(), Number) Then
            Return Number.ToString(Globalization.CultureInfo.InvariantCulture)
        End If
        Return "0"
    End Function


    Private Function SaveApprovedInvoiceTrnledgerRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
        Try
            Dim EntryNo As Integer = 1
            Dim DEBITAMT As Integer = 0
            Dim CREDITAMT As Integer = 0
            Dim DRCR As String = "CR"
            Dim OPPACCOUNTCODE As String = ""
            Dim NARRATION As String = ""
            Dim MTRC As String = ""
            Dim TRANS_FOR As String = "SUNDRY"
            Dim LONGNARR As String = ""

            Dim Status As String = ""
            Dim IsChecked As Boolean = False
            strQuery = "Select ISNULL(MAX(ENTRYNO),0) + 1 As ENTRYNO FROM trnledger As A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
            Else
                EntryNo = 1
            End If
            If BookCode <> "" Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                Dim TmpTbl As New DataTable
                'sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                'sql_connect_slect()
                RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
                MenuDesign_QueryLoad()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                    BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                End If
                Status = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
            Else
                MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IsChecked = False
                Return False
            End If
            Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
            If Status <> "APPROVE" Then
                Return True
            End If
            Dim Rate As String = "0.00"
            If Not IsDBNull(view.GetRowCellValue(i, "Rate")) Then
                Rate = Val(view.GetRowCellValue(i, "Rate")).ToString("0.00")
            End If
            srno += 1
            _strQuery = New StringBuilder
            With _strQuery
                .Append("INSERT INTO trnledger (")
                .Append("ENTRYNO")
                .Append(",BookTrtype")
                .Append(",BookVno")
                .Append(",BookCode")
                .Append(",BillNo")
                .Append(",BillDate")
                .Append(",AccountCode") ' account code
                .Append(",SRNO")
                .Append(",DEBITAMT")
                .Append(",CREDITAMT")
                .Append(",DRCR")
                .Append(",OPPACCOUNTCODE")
                .Append(",NARRATION")
                .Append(",MTRC")
                .Append(",TRANS_FOR")
                .Append(",LONGNARR")
                .Append(") VALUES (")
                .Append("'" & EntryNo & "'")
                .Append(",'" & BookTrtype & "'")
                .Append(",'" & BookVno & "'")
                .Append(",'" & BookCode & "'")
                .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                      "yyyy-MM-dd HH:mm:ss") & "'")
                .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
                .Append(",'" & srno & "'")
                .Append("," & GetNumericValue(DEBITAMT))
                .Append("," & GetNumericValue(CREDITAMT))
                .Append(",'" & DRCR & "'")
                .Append(",'" & OPPACCOUNTCODE & "'")
                .Append(",'" & NARRATION & "'")
                .Append(",'" & MTRC & "'")
                .Append(",'" & TRANS_FOR & "'")
                .Append(",'" & LONGNARR & "'")
                .Append(")")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the trnledger details data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "trnledger Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function SaveApprovedInvoiceOutstandingRow(view As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer, ByRef srno As Integer) As Boolean
        Try
            Dim EntryNo As Integer = 1
            Dim DEBITAMT As Integer = 0
            Dim BILLAMT As Integer = 0
            Dim QTY As Integer = 0
            Dim CREDITAMT As Integer = 0
            Dim DRCR As String = ""
            Dim OP1 As String = ""
            Dim OP2 As String = ""
            Dim Status As String = ""
            Dim IsChecked As Boolean = False
            strQuery = "Select ISNULL(MAX(ENTRYNO),0) + 1 As ENTRYNO FROM trnOutstanding As A WHERE A.BookTrType='" & BookTrtype & "' AND A.BookCode='" & BookCode & "'"
            sqL = strQuery
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                EntryNo = Val(DefaltSoftTable.Rows(0)("ENTRYNO"))
            Else
                EntryNo = 1
            End If
            If BookCode <> "" Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                Dim TmpTbl As New DataTable
                'sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "' "
                'sql_connect_slect()
                RS = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & BookCode & "'"
                MenuDesign_QueryLoad()
                TmpTbl = DefaltSoftTable.Copy

                If TmpTbl.Rows.Count > 0 Then
                    BookTrtype = TmpTbl(0)("BOOKTRTYPE").ToString
                    BookVno = Generate_Book_Vno(EntryNo, BookTrtype)
                End If
                Status = view.GetRowCellValue(i, "Status").ToString()
                UpdateOfferStatus(Id, Status, i)
            Else
                MessageBox.Show("Book Voucher Number mismatch. Please verify the BookVno.", "BookVno Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                IsChecked = False
                Return False
            End If
            Status = view.GetRowCellValue(i, "Status").ToString().Trim().ToUpper()
            If Status <> "APPROVE" Then
                Return True
            End If
            Dim Rate As String = "0.00"
            If Not IsDBNull(view.GetRowCellValue(i, "Rate")) Then
                Rate = Val(view.GetRowCellValue(i, "Rate")).ToString("0.00")
            End If
            srno += 1
            _strQuery = New StringBuilder
            With _strQuery
                .Append("INSERT INTO trnOutstanding (")
                .Append("ENTRYNO")
                .Append(",BookTrtype")
                .Append(",BookVno")
                .Append(",BookCode")
                .Append(",BillNo")
                .Append(",BillDate")
                .Append(",AccountCode")
                .Append(",SRNO")
                .Append(",DEBITAMT")
                .Append(",BILLAMT")
                .Append(",QTY")
                .Append(",CREDITAMT")
                .Append(",DRCR ")
                .Append(",OP1")
                .Append(",OP2")
                .Append(") VALUES (")
                .Append("'" & EntryNo & "'")
                .Append(",'" & BookTrtype & "'")
                .Append(",'" & BookVno & "'")
                .Append(",'" & BookCode & "'")
                .Append(",'" & view.GetRowCellValue(i, "OfferNo").ToString() & "'")
                .Append(",'" & Format(CDate(view.GetRowCellValue(i, "OfferDate")),
                                      "yyyy-MM-dd HH:mm:ss") & "'")
                .Append(",'" & view.GetRowCellValue(i, "AccountCode").ToString() & "'")
                .Append(",'" & srno & "'")
                .Append("," & GetNumericValue(DEBITAMT))
                .Append("," & GetNumericValue(BILLAMT))
                .Append("," & GetNumericValue(QTY))
                .Append("," & GetNumericValue(CREDITAMT))
                .Append(",'" & DRCR & "'")
                .Append(",'" & OP1 & "'")
                .Append(",'" & OP2 & "'")
                .Append(")")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            Return True
        Catch ex As Exception
            MessageBox.Show("An error occurred while saving the trnOutstanding details data." & vbCrLf & vbCrLf & "Error Details: " & ex.Message, "trnOutstanding Data Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub TxtType_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtType.KeyDown
        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Space Then
            If TxtType.Text = "LR UPDATE" Then
                BookCode = ""
                BookTrtype = ""
            Else
                If TxtType.Text.Trim = "ORDER" Then
                    BookCode = "0001-000010029"
                    BookTrtype = "ONL29"
                End If
                If TxtType.Text.Trim = "INVOICE" Then
                    BookCode = "0001-000010030"
                    BookTrtype = "ONL30"
                End If
            End If
        End If
    End Sub

    Private Sub TxtType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtType.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) OrElse e.KeyChar = " "c Then
            If TxtType.Text = "LR UPDATE" Then
                BookCode = ""
                BookTrtype = ""
            Else
                If TxtType.Text.Trim = "ORDER" Then
                    BookCode = "0001-000010029"
                    BookTrtype = "ONL29"
                End If
                If TxtType.Text.Trim = "INVOICE" Then
                    BookCode = "0001-000010030"
                    BookTrtype = "ONL30"
                End If
            End If
        End If
    End Sub
#End Region
End Class