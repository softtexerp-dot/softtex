Imports System.Net.Http
Imports System.Text
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraRichEdit.Import.Html
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class AppEntryManagement
    Private CurDate As String = Now.Month.ToString & "/" & Now.Day.ToString & "/" & Now.Year.ToString
    'Private Process_Date_Filter_Condition As String = ""
    'Private SelectedAccountName As String = ""
    'Private Display_Stage_No As Integer = 0
    'Dim Zoom_Stock_Table As New DataTable
    'Dim Zoom_Stock_Table_Secondstage As New DataTable
    'Dim ThidTable As New DataTable
    'Dim FourTable As New DataTable
    'Dim FIveTable As New DataTable
    'Dim _StgIRowNo As Integer = 1
    'Dim _StgIIRowNo As Integer = 1
    'Dim _StgThidRowNo As Integer = 1
    'Dim _StgFourRowNo As Integer = 1
    'Private obj_Party_Selection As New Multi_Selection_Master

    'Dim _FILTERACCOUNTCODE As String = ""
    '
    'Dim _CommanFilterString As String = ""
    'Dim SelectionType As String = ""
    'Dim _CommanFirstStageActivColumn As String = ""
    'Dim FactStockTable As New DataTable
    'Dim SelectionOfView As String = ""
    'Dim NoOfstage As Integer = 0
    'Dim SummaryActiveClmQty As String = ""
    'Dim SummaryActiveClmName As String = ""

    'Dim _TmpMonthwiseTbl As New DataTable
    Dim _CloseCheck As Boolean = False
    Private IsUpdating As Boolean = False
    Dim dbName As String = "Accounts39_142026103929"    'Top textbox या variable से
    Dim gst As String = "08AAECM5759M1ZT"               'Second textbox से
    Dim dtSource As DataTable

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
        _CloseCheck = True
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        txt_To.Text = Now.ToString("dd/MM/yyyy")
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        _Zooming_Load()
        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _CloseCheck = False
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        Dim _NewTmptbl2 As New DataTable
        _Zooming_Load()
    End Sub



    Private Sub _Zooming_Load()
        dtSource = New DataTable
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
            'fixed URL 
            'http://softtextileappapi.softtexerp.com/api/offersCreate/
            Dim url As String =
            "http://softtextileappapi.softtexerp.com/api/offersCreate/GetOffersAndInvoiceData?dbName=" & dbName & "&entryType=" & statustype & "&gstno=" & gst & "&fromDate=" & FromDate & "&toDate=" & ToDate & "&status=" & txt_Status.Text.Trim & ""
            Dim response As String = client.GetStringAsync(url).Result
            Dim json As JObject = JObject.Parse(response)
            If Convert.ToBoolean(json("status")) = True Then
                Dim arr As JArray = CType(json("data"), JArray)
                dtSource.Columns.Add("EntryNo")
                dtSource.Columns.Add("BookVno")
                dtSource.Columns.Add("ItemCode")
                dtSource.Columns.Add("ItemName")
                dtSource.Columns.Add("AccountCode")
                dtSource.Columns.Add("AccountName")
                dtSource.Columns.Add("OfferNo")
                dtSource.Columns.Add("Qty")
                dtSource.Columns.Add("GrossRate")
                dtSource.Columns.Add("Amount")
                dtSource.Columns.Add("Status")
                dtSource.Columns.Add("Description")
                dtSource.Columns.Add("Id")

                For Each r As JObject In arr
                    Dim dr As DataRow = dtSource.NewRow()
                    dr("EntryNo") = r("EntryNo").ToString()
                    dr("BookVno") = r("BookVno").ToString()
                    sqL = "SELECT ItemName FROM MstStoreItem WHERE ItemCode='" & r("ItemCode").ToString() & "'"
                    sql_connect_slect()

                    If DefaltSoftTable.Rows.Count > 0 Then
                        dr("ItemName") = DefaltSoftTable.Rows(0).Item("ItemName").ToString()
                    End If
                    dr("ItemCode") = r("ItemCode").ToString()
                    dr("AccountCode") = r("AccountCode").ToString()
                    sqL = "SELECT AccountName FROM MstMasterAccount WHERE AccountCode='" & r("AccountCode").ToString() & "'"
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        dr("AccountName") = DefaltSoftTable.Rows(0).Item("AccountName").ToString()
                    End If
                    dr("OfferNo") = r("OfferNo").ToString()

                    dr("Qty") = r("MeterWeight").ToString()
                    dr("GrossRate") = r("PickRate").ToString()
                    dr("Amount") = r("NetAmount").ToString()

                    dr("Status") = r("Status").ToString()
                    dr("Description") = r("Description").ToString()
                    dr("Id") = r("Id").ToString()
                    dtSource.Rows.Add(dr)

                Next
                dtSource.Columns.Add("SelectRow", GetType(Boolean))

                'For Each dr As DataRow In dtSource.Rows

                '    If dr("Status").ToString.ToUpper = "APPROVED" Then
                '        dr("SelectRow") = True
                '    Else
                '        dr("SelectRow") = False
                '    End If

                'Next
                Dim SelectedIds As New List(Of Integer)

                For Each dr As DataRow In dtSource.Rows
                    If Not IsDBNull(dr("SelectRow")) AndAlso Convert.ToBoolean(dr("SelectRow")) Then
                        SelectedIds.Add(Convert.ToInt32(dr("Id")))
                    End If
                Next
                GridControl1.DataSource = dtSource
                Dim view As GridView = CType(GridControl1.MainView, GridView)
                Dim chk As New RepositoryItemCheckEdit
                chk.ValueChecked = True
                chk.ValueUnchecked = False
                GridControl1.RepositoryItems.Add(chk)
                view.Columns("SelectRow").ColumnEdit = chk
                view.Columns("SelectRow").VisibleIndex = 0
                view = CType(GridControl1.MainView, GridView)
                AddHandler view.CellValueChanged, AddressOf GridView_CellValueChanged
                AddHandler view.KeyDown, AddressOf GridView1_KeyDown
            End If

        End Using
    End Sub
    Private Sub GridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

        If e.Column.FieldName <> "SelectRow" Then Exit Sub
        Dim view As GridView = CType(sender, GridView)
        Dim Id As Integer =
        Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "Id"))
        Dim Status As String = txt_Status.Text.Trim
        'If(CBool(e.Value), "APPROVED", "PENDING")
        'UpdateOfferStatus(Id, Status)
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode <> Keys.Space Then Exit Sub

        Dim view As GridView = CType(sender, GridView)

        Dim RowHandle As Integer = view.FocusedRowHandle

        If RowHandle < 0 Then Exit Sub

        Dim CurrentStatus As String =
        view.GetRowCellValue(RowHandle, "Status").ToString.Trim.ToUpper

        Select Case CurrentStatus

            Case "PENDING"
                view.SetRowCellValue(RowHandle, "Status", "HOLD")

            Case "HOLD"
                view.SetRowCellValue(RowHandle, "Status", "CANCEL")

            Case "CANCEL"
                view.SetRowCellValue(RowHandle, "Status", "PENDING")

        End Select

        e.Handled = True

    End Sub
    Private Sub UpdateOfferStatus(Id As Integer, Status As String)
        Try
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
                Dim result As String = response.Content.ReadAsStringAsync().Result
                If response.IsSuccessStatusCode Then
                    '_strQuery = New StringBuilder
                    'With _strQuery
                    '    .Append(" insert into TrnOffer ( ")
                    '    .Append(" ENTRYNO")
                    '    .Append(" ,BookTrtype")
                    '    .Append(" ,BookVno")
                    '    .Append(" ,BookCode")
                    '    .Append(" ,OfferNo")
                    '    .Append(" ,OfferDate")
                    '    .Append(" ,PartyOfferNo")
                    '    .Append(" ,ACOFCODE")
                    '    .Append(" ,AccountCode")
                    '    .Append(" ,TransportCode")
                    '    .Append(" ,DespatchCode")
                    '    .Append(" ,HeaderRemark")
                    '    .Append(" ,SRNO")
                    '    .Append(" ,ItemCode")
                    '    .Append(" ,CutCode")
                    '    .Append(" ,DesignCode")
                    '    .Append(" ,ShadeCode")
                    '    .Append(" ,Mtr_Weight")
                    '    .Append(" ,Rate")
                    '    .Append(" ,CDVALUE")
                    '    .Append(" ,clear")
                    '    .Append(" ,Gross_Rate")
                    '    .Append(" ,Net_Rate")
                    '    .Append(" ,ITEMGROUPCODE")
                    '    .Append(" ) VALUES (")
                    '    .Append("'" & Last_Entry_No & "'")
                    '    .Append(",'" & _SalesBookTrtype & "'")
                    '    .Append(",'" & _BookVno & "'")
                    '    .Append(",'" & _SalesBookCode & "'")
                    '    .Append(",'" & Last_Entry_No & "'")
                    '    .Append(",'" & _CuDate & "'")
                    '    .Append(",'" & OnlineOrderIdDetail & "'")
                    '    .Append(",'0000-000000001'")
                    '    .Append(",'" & ACCOUNTCODE & "'")
                    '    .Append(",'0000-000000001'")
                    '    .Append(",'0000-000000001'")
                    '    .Append(",'" & CatlokOrderDate & "'")
                    '    .Append(",'1'")
                    '    .Append(",'" & ItemCode & "'")
                    '    .Append(",'0000-000000003'")
                    '    .Append(",'0000-000000001'")
                    '    .Append(",'0000-000000001'")
                    '    .Append(",'" & Quantity & "'")
                    '    .Append(",'" & Price & "'")
                    '    .Append(",'0'")
                    '    .Append(",'NO'")
                    '    .Append(",'" & Price & "'")
                    '    .Append(",'" & Price & "'")
                    '    .Append(",'" & ItemGroupCode & "'")
                    '    .Append(" )")
                    'End With
                    'sqL = _strQuery.ToString
                    'sql_Data_Save_Delete_Update()



                    MessageBox.Show("Status Updated Successfully")
                Else
                    MessageBox.Show(result)
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

        For i As Integer = 0 To view.RowCount - 1
            Dim IsChecked As Boolean = False
            If Not IsDBNull(view.GetRowCellValue(i, "SelectRow")) Then
                IsChecked = Convert.ToBoolean(view.GetRowCellValue(i, "SelectRow"))
            End If
            If IsChecked Then
                Dim Id As Integer = Convert.ToInt32(view.GetRowCellValue(i, "Id"))
                'Dim Status As String = txt_Status.Text.Trim
                Dim Status As String = view.GetRowCellValue(i, "Status").ToString()

                UpdateOfferStatus(Id, Status)
            End If
        Next
        MessageBox.Show("Status Updated Successfully")
        Generate_Date_For_DataBase(txt_To)
        _Zooming_Load()
    End Sub
#End Region
End Class