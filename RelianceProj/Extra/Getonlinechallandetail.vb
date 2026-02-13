Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Newtonsoft.Json

Friend Class Getonlinechallandetail
    Public Pieceno As String
    Public graychallanno As String
    Public ProcessCode As String
    Dim dbName As String = "Accounts1_2410202510556"    'Top textbox या variable से
    Dim gst As String = "000000000000000"               'Second textbox से

    Private Sub Getonlinechallandetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Location = New Point(0, 0)
            AttachButtonFocusEvents(Me)
            'txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
            'txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
            'txt_From.Text = Now.ToString("dd/MM/yyyy")
            txt_From.Text = Now.ToString("26/11/2025")
            txt_To.Text = Now.ToString("dd/MM/yyyy")
            Me.BeginInvoke(New Action(Sub() txt_From.Focus()))
            'View_Getonlinechallendetail()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub View_Getonlinechallendetail()

        Dim Bookcode As String = ""
        Dim Entryfromdate As String = txt_From.Text
        Dim Entrytodate As String = txt_To.Text
        'Process Challan
        If Txt_ProcessStockDisplay.Text = "GRAY CHALLAN" Then
            Bookcode = "SCNB-000000002"
        Else
            Bookcode = "PRCB-000000001"
        End If
        'Dim challanList = LoadChallanData(dbName, gst)
        Dim challanList = LoadChallanData(dbName, gst, Bookcode, Entryfromdate, Entrytodate)
        Dim dt As DataTable = ConvertToDataTable(challanList)
        ' temptable column add kiye
        Dim tempCols As DataTable = CreateTempTable()
        ' --- Add tempTable columns at TOP (index 0 se) ---
        For i As Integer = tempCols.Columns.Count - 1 To 0 Step -1
            dt.Columns.Add(tempCols.Columns(i).ColumnName, GetType(String))
            dt.Columns(tempCols.Columns(i).ColumnName).SetOrdinal(0)
        Next
        ' Set Header captions
        Dim HeaderMap = GetHeaderMap()
        For Each row As DataRow In dt.Rows
            Dim party = row("accountName").ToString().Trim()
            Dim process = row("ProcessName").ToString().Trim()
            Dim item = row("ItemName").ToString().Trim()
            Dim design = row("DesignName").ToString().Trim()
            Dim shade = row("ShadeName").ToString().Trim()
            Dim selvedge = row("Selvedge").ToString().Trim()
            If party <> "" AndAlso AccountDict.ContainsKey(party) Then
                row("partycode") = AccountDict(party)
            End If
            If process <> "" AndAlso ProcessDict.ContainsKey(process) Then
                row("processcode") = ProcessDict(process)
            End If
            If item <> "" AndAlso ItemDict.ContainsKey(item) Then
                row("itemcode") = ItemDict(item)
            End If
            If design <> "" AndAlso DesignDict.ContainsKey(design) Then
                row("designcode") = DesignDict(design)
            End If
            If shade <> "" AndAlso ShadeDict.ContainsKey(shade) Then
                row("shadecode") = ShadeDict(shade)
            End If
            If selvedge <> "" AndAlso SelvedgeDict.ContainsKey(selvedge) Then
                row("selvedgecode") = SelvedgeDict(selvedge)
            End If


            If Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
                Pieceno = row("piece").ToString().Trim()
                graychallanno = row("challanNo").ToString().Trim()

                Dim GMtr As Decimal = Convert.ToDecimal(row("mtrWeight"))
                Dim PMtr As Decimal = Convert.ToDecimal(row("avgWeight"))
                Dim shrinkMtr As Decimal = Math.Round(GMtr - PMtr, 2)
                row("shrinkmtr") = shrinkMtr

                Dim shrinkPer As Decimal = 0
                If GMtr <> 0 Then
                    shrinkPer = Math.Round(((GMtr - PMtr) / GMtr) * 100, 2)
                End If
                row("shrinkper") = shrinkPer
            ElseIf Txt_ProcessStockDisplay.Text = "GRAY CHALLAN" Then
                'Pieceno = row("piece").ToString().Trim()
                'graychallanno = row("challanNo").ToString().Trim()
                Dim GMtr As Decimal = Convert.ToDecimal(row("mtrWeight"))
                Dim Weight As Decimal = Convert.ToDecimal(row("Weight"))
                Dim Avgweight As Decimal = Math.Round(Weight / GMtr, 3)
                row("avgWeight") = Avgweight
            End If
        Next




        GridControl1.DataSource = dt.Copy
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            BtnProcessRefresh.Visible = True
            btnsave.Enabled = True
        Else
            MessageBox.Show("No Records Found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnsave.Enabled = False
        End If
        'GridView1.PopulateColumns()
        'Column after add remove header Arrange karne ke liye
        Dim visibleIndex As Integer = 0

        For Each kvp In HeaderMap   ' ← Ye ORDER maintain karega
            Dim fieldName = kvp.Key
            Dim caption = kvp.Value

            If GridView1.Columns.ColumnByFieldName(fieldName) IsNot Nothing Then
                Dim col = GridView1.Columns(fieldName)
                col.Visible = True
                col.Caption = caption
                ' Important → custom order apply
                col.VisibleIndex = visibleIndex
                visibleIndex += 1
            End If
        Next

        ' --- STEP: Hide remaining columns not in list ---
        For Each col In GridView1.Columns
            If Not HeaderMap.ContainsKey(col.FieldName) Then
                col.Visible = False
            End If
        Next
        'Column hide karne ke liye
        Dim HiddenColumns As New List(Of String) From {
                             "entryNo",
                             "bookTrType",
                             "bookName",
                             "bookcode",
                             "date",
                             "bookVno",
                             "acofName"
                         }
        ',"processpcsid"
        'column width set karna 

        'Dim widthMap = GetColumnWidthMap()
        ''column ka align left right set karna
        'Dim alignMap = GetColumnAlignmentMap()
        'For Each col In GridView1.Columns
        '    If widthMap.ContainsKey(col.FieldName) Then
        '        'col.MinWidth = widthMap(col.FieldName)
        '        'col.MaxWidth = widthMap(col.FieldName)
        '        col.Width = widthMap(col.FieldName)
        '    End If
        '    'Column ka alignment  
        '    If alignMap.ContainsKey(col.FieldName) Then
        '        col.AppearanceCell.TextOptions.HAlignment = alignMap(col.FieldName)
        '        col.AppearanceHeader.TextOptions.HAlignment = alignMap(col.FieldName)
        '    End If
        'Next

        'Column ko visible true or false karne ke liye
        For Each col In GridView1.Columns
            ' ---- Hidden column check ----
            If HiddenColumns.Contains(col.FieldName) Then
                col.Visible = False
                Continue For
            End If
            If HeaderMap.ContainsKey(col.FieldName) Then
                col.Caption = HeaderMap(col.FieldName)    'Your custom header
                col.Visible = True
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Else
                col.Visible = False
            End If
            If Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then


                ' 🔒 Pehle sab columns ko NON-editable set karo
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True

                If col.FieldName = "avgWeight" Then
                    col.Caption = "PMtr"   ' <-- Yaha header name set hoga
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.OptionsColumn.AllowEdit = False           ' <-- Editable
                    col.OptionsColumn.ReadOnly = False          ' <-- Not Read-only
                    col.OptionsColumn.AllowFocus = True         ' <-- Cell focus allow
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "mtrWeight" Then
                    col.Caption = "GMtr"   ' <-- Yaha header name set hoga
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.OptionsColumn.AllowEdit = True          ' <-- Editable
                    col.OptionsColumn.ReadOnly = False          ' <-- Not Read-only
                    col.OptionsColumn.AllowFocus = True         ' <-- Cell focus allow
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "weight" Then
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "challanNo" Then
                    col.Caption = "Ps Challan No "   ' <-- Yaha header name set hoga
                End If
                If col.FieldName = "greyChallan" Then
                    col.Caption = "Grey Challan"
                End If

                If col.FieldName = "greyRecDate" Then
                    col.Caption = "Grey Date"
                    col.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
                    col.DisplayFormat.FormatString = "yyyy-MM-dd"
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                End If


                If col.FieldName = "shrinkmtr" Then
                    col.Caption = "Shk-Mtr"
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

                If col.FieldName = "shrinkper" Then
                    col.Caption = "Shk.%"
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "beamNo" Then
                    col.Caption = "Beam No"
                    col.Visible = True
                End If
                If col.FieldName = "partycode" Then
                    col.Visible = False
                End If
                If col.FieldName = "processcode" Then
                    col.Visible = False
                End If
                If col.FieldName = "itemcode" Then
                    col.Visible = False
                End If
                If col.FieldName = "designcode" Then
                    col.Visible = False
                End If
                If col.FieldName = "shadecode" Then
                    col.Visible = False
                End If
                If col.FieldName = "selvedgecode" Then
                    col.Visible = False
                End If
                If col.FieldName = "processpcsid" Then
                    col.Visible = False
                End If

                If col.FieldName = "oldgmtr" Then col.Visible = False
            ElseIf Txt_ProcessStockDisplay.Text = "GRAY CHALLAN" Then
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
                If col.FieldName = "avgWeight" Then
                    col.Caption = "avg Weight"   ' <-- Yaha header name set hoga
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.OptionsColumn.AllowEdit = False           ' <-- Editable
                    col.OptionsColumn.ReadOnly = False          ' <-- Not Read-only
                    col.OptionsColumn.AllowFocus = True         ' <-- Cell focus allow
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "mtrWeight" Then
                    col.Caption = "GMtr"   ' <-- Yaha header name set hoga
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.OptionsColumn.AllowEdit = True          ' <-- Editable
                    col.OptionsColumn.ReadOnly = False          ' <-- Not Read-only
                    col.OptionsColumn.AllowFocus = True         ' <-- Cell focus allow
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "weight" Then
                    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "n2"
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If col.FieldName = "oldgmtr" Then col.Visible = False
                If col.FieldName = "processpcsid" Then col.Visible = False
                If col.FieldName = "processpcsid" Then
                    col.Caption = "Grey Piece Id "
                End If
                If col.FieldName = "beamNo" Then
                    col.Caption = "Beam No"
                    col.Visible = True
                End If
                If col.FieldName = "challanNo" Then
                    col.Caption = "G Challan No "   ' <-- Yaha header name set hoga
                End If
                If col.FieldName = "greyChallan" Then
                    col.Visible = False
                End If
                If col.FieldName = "greyRecDate" Then
                    col.Visible = False
                End If
                If col.FieldName = "shrinkmtr" Then
                    col.Visible = False
                End If
                If col.FieldName = "shrinkper" Then
                    col.Visible = False
                End If
                If col.FieldName = "partycode" Then
                    col.Visible = False
                End If
                If col.FieldName = "processcode" Then
                    col.Visible = False
                End If
                If col.FieldName = "itemcode" Then
                    col.Visible = False
                End If
                If col.FieldName = "designcode" Then
                    col.Visible = False
                End If
                If col.FieldName = "shadecode" Then
                    col.Visible = False
                End If
                If col.FieldName = "selvedgecode" Then
                    col.Visible = False
                End If
                If col.FieldName = "processpcsid" Then
                    col.Visible = False
                End If

            End If
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            'col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Next



        With GridView1.Appearance.HeaderPanel
            .BackColor = Color.LightGray  ' Light grey
            .ForeColor = Color.Black
            .Font = New Font("Verdana", 9, FontStyle.Bold)
            .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        End With
        AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle

        'GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsBehavior.AutoPopulateColumns = True
        'Column searching option add karne ke liye
        GridView1.OptionsView.ShowAutoFilterRow = True
        'GridView1.OptionsView.ColumnAutoWidth = True
        GridView1.OptionsView.ShowFooter = True
        GridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        GridView1.BestFitColumns()
        GridView1.OptionsView.ColumnAutoWidth = False
        'GridView1.OptionsMenu.ShowFooterItem = True
        If GridView1.Columns.ColumnByFieldName("piece") IsNot Nothing Then
            GridView1.Columns("piece").Summary.Clear()
            GridView1.Columns("piece").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "piece", "{0}"))
            GridView1.GroupSummary.Clear()
            GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "piece", .SummaryType = DevExpress.Data.SummaryItemType.Count, .ShowInGroupColumnFooter = GridView1.Columns("piece")})
            GridView1.Columns("piece").Width = 40
        End If
        If GridView1.Columns.ColumnByFieldName("mtrWeight") IsNot Nothing Then
            GridView1.Columns("mtrWeight").Summary.Clear()
            GridView1.Columns("mtrWeight").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mtrWeight", "{0:n2}"))
            GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "mtrWeight", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("mtrWeight")})
            GridView1.Columns("mtrWeight").Width = 70
        End If
        If GridView1.Columns.ColumnByFieldName("weight") IsNot Nothing Then
            GridView1.Columns("weight").Summary.Clear()
            GridView1.Columns("weight").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "weight", "{0:n2}"))
            GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "weight", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("weight")})
            GridView1.Columns("weight").Width = 80
        End If
        If GridView1.Columns.ColumnByFieldName("avgWeight") IsNot Nothing Then
            GridView1.Columns("avgWeight").Summary.Clear()
            'GridView1.Columns("avgWeight").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "avgWeight", "{0:n2}"))
            'GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "avgWeight", .SummaryType = DevExpress.Data.SummaryItemType.Average, .ShowInGroupColumnFooter = GridView1.Columns("weight")})
            'GridView1.Columns("avgWeight").Width = 80
            GridView1.Columns("avgWeight").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "avgWeight", "{0:n2}"))
            GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "avgWeight", .SummaryType = DevExpress.Data.SummaryItemType.Average, .ShowInGroupColumnFooter = GridView1.Columns("weight")})
            GridView1.Columns("avgWeight").Width = 80

        End If
        If GridView1.Columns.ColumnByFieldName("shrinkmtr") IsNot Nothing Then
            GridView1.Columns("shrinkmtr").Summary.Clear()
            GridView1.Columns("shrinkmtr").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "shrinkmtr", "{0:n2}"))
            GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "shrinkmtr", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("weight")})
            GridView1.Columns("shrinkmtr").Width = 80
        End If

    End Sub
#Region "Fill Piece Detail"
    Public Sub View_Piecedetail()
        Dim Book_Code_Filter_String As String = ""
        Dim StockListShow As String = ""
        Dim _DyeningStatus As String = ""
        Dim _BookCode As String = ""
        If _BookCode = "0001-000000116" Or _BookCode = "0001-000000661" Then
            Book_Code_Filter_String = " And (A.BOOKCODE='0001-000000135' OR A.BOOKCODE='0001-000000095' OR A.BOOKCODE='0001-000000654') "
        Else
            Book_Code_Filter_String = " AND A.BOOKCODE<>'0001-000000135' AND A.BOOKCODE<>'0001-000000095' AND A.BOOKCODE<>'0001-000000654' "
        End If
        'Date_Formate1 = txtChallanDate.Text
        Date_Formate_set()

        Dim _bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
        'Dim processName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "processName").ToString()

        'For i As Integer = 0 To GridView1.RowCount - 1
        '    Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
        '    Dim iprocessName As String = GridView1.GetRowCellValue(i, "processName").ToString()
        '    If ibookVno = _bookVno AndAlso processName = iprocessName Then
        '        GridView1.SetRowCellValue(i, "processcode", MULTY_SELECTION_COLOUM_3_DATA)
        '        GridView1.SetRowCellValue(i, "processName", MULTY_SELECTION_COLOUM_1_DATA)
        '    End If
        '    ProcessCode = MULTY_SELECTION_COLOUM_3_DATA
        'Next

        Book_Code_Filter_String = Book_Code_Filter_String

        sqL = obj_Party_Selection.Get_Process_Stock_Qry_For_Data_Entry(Book_Code_Filter_String, ProcessCode, _bookVno, Date_1, StockListShow, _DyeningStatus, "")
        sql_connect_slect()
        'Tbl_ProcessStk.Clear()
        Dim Tbl_Stk As New DataTable
        Tbl_Stk = DefaltSoftTable.Copy
        GridControl2.DataSource = Tbl_Stk

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GridView2   ' आपके GridControl2 का GridView

        ' वो कॉलम जिनको दिखाना है (क्रम से)
        Dim visibleCols As String() = {
            "Final_Grey_ID",
            "Piece No",
            "G-Mtrs (Balance)",
            "Quality",
            "Chl-No",
            "Chl-Date",
            "Factory",
            "Party",
            "Design No",
            "Shade No",
            "Selvedge",
            "Process",
            "ORG_BALMTR"
        }
        '"Flag",
        ' --- पहले सभी कॉलम hide ---
        view.OptionsView.ShowAutoFilterRow = True
        For i As Integer = 0 To view.Columns.Count - 1
            view.Columns(i).Visible = False
        Next

        ' --- फिर सिर्फ चाहिए वो कॉलम visible करें ---
        For Each colName In visibleCols
            If view.Columns.ColumnByFieldName(colName) IsNot Nothing Then
                view.Columns(colName).Visible = True
            End If
        Next

        ' --- Column Order भी Final_Grey_ID → ORG_BALMTR जैसे रखे ---
        Dim visibleIndex As Integer = 0
        For Each colName In visibleCols
            Dim col = view.Columns.ColumnByFieldName(colName)
            If col IsNot Nothing Then
                col.Visible = True
                col.VisibleIndex = visibleIndex
                visibleIndex += 1
                ' --- Add your filter condition here ---
                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            End If
        Next
        'view.Columns("Final_Grey_ID").Width = 120
        view.Columns("Final_Grey_ID").Visible = False
        view.Columns("Process").Visible = False
        view.Columns("Piece No").Width = 120
        GridView1.FocusedColumn = GridView1.Columns("Piece No")
        view.Columns("Chl-No").Width = 80
        view.Columns("Chl-Date").Width = 80
        GridView2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        GridView2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        GridView2.OptionsBehavior.Editable = False
        GridView2.OptionsView.ColumnAutoWidth = False
    End Sub
#End Region
    ' ---- Load Account Master ----
    Dim AccountDict As Dictionary(Of String, String) =
    sql_get_dict("SELECT AccountName, AccountCode FROM MstMasterAccount", "AccountName", "AccountCode")

    ' ---- Load Process Master ----
    Dim ProcessDict As Dictionary(Of String, String) =
    sql_get_dict("SELECT AccountName, AccountCode FROM MstMasterAccount", "AccountName", "AccountCode")

    ' ---- Load Item Master ----
    Dim ItemDict As Dictionary(Of String, String) =
    sql_get_dict("SELECT ItenName, Id FROM MstfabricItem", "ItenName", "Id")

    ' ---- Load Design Master ----
    Dim DesignDict As Dictionary(Of String, String) =
    sql_get_dict("SELECT Design_Name, Design_Code FROM Mst_Fabric_Design", "Design_Name", "Design_Code")

    ' ---- Load Shade Master ----
    Dim ShadeDict As Dictionary(Of String, String) =
    sql_get_dict("SELECT Shade, Id FROM Mst_Fabric_Shade", "Shade", "Id")

    ' ---- Load Selvedge Master ----
    Dim SelvedgeDict As Dictionary(Of String, String) =
    sql_get_dict("SELECT SELVEDGE_NAME, Id FROM Mst_selvedge", "SELVEDGE_NAME", "Id")

    ' ---- Load Process Pcs Id Master ----
    Dim ProcesspcsidDict As Dictionary(Of String, String) =
    sql_get_dict3("SELECT Grey_Desp_Pcs_ID,pieceno,ChallanNo,Processcode 
                    FROM TrnGreyDesp",
                  "pieceno",
                  "ChallanNo",
                  "ProcessCode")

    Public Function sql_get_dict(query As String, nameCol As String, codeCol As String) As Dictionary(Of String, String)
        Dim dict As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        sqL = query
        sql_connect_slect()
        For Each r As DataRow In DefaltSoftTable.Rows
            Dim n = r(nameCol).ToString().Trim()
            Dim c = r(codeCol).ToString().Trim()
            If Not dict.ContainsKey(n) Then
                dict.Add(n, c)
            End If
        Next
        Return dict

        Return dict
    End Function
    Function sql_get_dict3(query As String,
                       key1 As String,
                       key2 As String,
                       key3 As String) As Dictionary(Of String, String)

        Dim dict As New Dictionary(Of String, String)
        sqL = query
        Dim dt As DataTable = sql_connect_slect()

        For Each row As DataRow In dt.Rows
            Dim key As String = $"{row(key1)}|{row(key2)}|{row(key3)}"
            'Dim key As String = $"{row(key1)}&{row(key2)}&{row(key3)}"
            Dim value As String = row("Grey_Desp_Pcs_ID").ToString()
            If Not dict.ContainsKey(key) Then
                dict.Add(key, value)
            End If
        Next

        Return dict
    End Function
    Public Function ConvertToDataTable(Of T)(list As IList(Of T)) As DataTable
        Dim dt As New DataTable()
        Dim props = GetType(T).GetProperties()
        For Each p In props
            dt.Columns.Add(p.Name, If(p.PropertyType.IsGenericType AndAlso
                                  p.PropertyType.GetGenericTypeDefinition() = GetType(Nullable(Of )),
                                  Nullable.GetUnderlyingType(p.PropertyType),
                                  p.PropertyType))
        Next
        For Each item In list
            Dim row = dt.NewRow()
            For Each p In props
                row(p.Name) = If(p.GetValue(item, Nothing), DBNull.Value)
            Next
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

    Private Function CreateTempTable() As DataTable
        Dim dt As New DataTable()
        ''dt.Columns.Add("accountcode", GetType(String))
        dt.Columns.Add("shrinkmtr", GetType(String))
        dt.Columns.Add("shrinkper", GetType(String))
        dt.Columns.Add("partycode", GetType(String))
        dt.Columns.Add("processcode", GetType(String))
        dt.Columns.Add("itemcode", GetType(String))
        dt.Columns.Add("designcode", GetType(String))
        dt.Columns.Add("shadecode", GetType(String))
        dt.Columns.Add("selvedgecode", GetType(String))
        dt.Columns.Add("processpcsid", GetType(String))
        dt.Columns.Add("oldgmtr", GetType(String))
        Return dt
    End Function
    Public Function GetHeaderMap() As Dictionary(Of String, String)
        Return New Dictionary(Of String, String) From {
        {"entryNo", "ENo"},
        {"bookTrType", "Book TrType"},
        {"bookName", "Book Name"},
        {"bookcode", "Book Code"},
        {"date", "Date"},
        {"bookVno", "Book Vno"},
        {"acofName", "Ac Of Name"},
        {"challanNo", "Challan No"},
        {"challanDate", "Challan Date"},
        {"processName", "Process Name"},
        {"accountName", "Party Name"},
        {"itemName", "Item Name"},
        {"designName", "Design Name"},
        {"shadeName", "Shade Name"},
        {"selvedge", "Selvedge"},
        {"rate", "Rate"},
         {"fdPd", "FdPd"},
         {"piece", "Piece"},
        {"mtrWeight", "GMtr"},
        {"weight", "Weight"},
        {"avgWeight", "Avg Weight"},
        {"shrinkmtr", "shrinkmtr"},
        {"shrinkper", "shrinkper"},
        {"beamNo", "Beam No"},
        {"remark", "Remark"},
        {"greyChallan", "Ps challan"},
        {"greyRecDate", "Grey Date"},
        {"accountcode", "accountcode"},
        {"processcode", "processcode"},
        {"partycode", "partycode"},
        {"itemcode", "itemcode"},
        {"designcode", "designcode"},
        {"shadecode", "shadecode"},
        {"selvedgecode", "selvedgecode"},
        {"processpcsid", "processpcsid"},
        {"oldgmtr", "oldgmtr"}
    }
    End Function
    Public Function GetColumnWidthMap() As Dictionary(Of String, Integer)
        Return New Dictionary(Of String, Integer) From {
        {"entryNo", 40},
        {"bookTrType", 100},
        {"bookName", 100},
        {"bookcode", 100},
        {"date", 100},
        {"bookVno", 160},
        {"challanNo", 100},
        {"challanDate", 70},
        {"acofName", 100},
        {"processName", 180},
        {"accountName", 120},
        {"itemName", 200},
        {"designName", 160},
        {"shadeName", 80},
        {"selvedge", 50},
        {"rate", 60},
        {"fdPd", 40},
        {"piece", 100},
        {"mtrWeight", 100},
        {"weight", 100},
        {"avgWeight", 60},
        {"beamNo", 60},
        {"remark", 100},
        {"graychallan", 100},
        {"greyRecDate", 100},
        {"accountcode", 100},
        {"processcode", 100},
        {"partycode", 100},
        {"itemcode", 100},
        {"designcode", 100},
        {"shadecode", 100},
        {"selvedgecode", 100},
        {"processpcsid", 100}
    }

    End Function
    'Column ka alignment set karna
    Public Function GetColumnAlignmentMap() As Dictionary(Of String, DevExpress.Utils.HorzAlignment)
        Return New Dictionary(Of String, DevExpress.Utils.HorzAlignment) From {
        {"entryNo", DevExpress.Utils.HorzAlignment.Center},
        {"challanNo", DevExpress.Utils.HorzAlignment.Near},
        {"challanDate", DevExpress.Utils.HorzAlignment.Center},
        {"rate", DevExpress.Utils.HorzAlignment.Far},
        {"mtrWeight", DevExpress.Utils.HorzAlignment.Far},
        {"weight", DevExpress.Utils.HorzAlignment.Far},
        {"avgWeight", DevExpress.Utils.HorzAlignment.Far},
        {"piece", DevExpress.Utils.HorzAlignment.Center},
        {"fdPd", DevExpress.Utils.HorzAlignment.Center},
        {"bookTrType", DevExpress.Utils.HorzAlignment.Default},
        {"bookName", DevExpress.Utils.HorzAlignment.Default},
        {"bookcode", DevExpress.Utils.HorzAlignment.Default},
        {"date", DevExpress.Utils.HorzAlignment.Default},
        {"bookVno", DevExpress.Utils.HorzAlignment.Default},
        {"acofName", DevExpress.Utils.HorzAlignment.Default},
        {"processName", DevExpress.Utils.HorzAlignment.Default},
        {"accountName", DevExpress.Utils.HorzAlignment.Default},
        {"itemName", DevExpress.Utils.HorzAlignment.Default},
        {"designName", DevExpress.Utils.HorzAlignment.Default},
        {"shadeName", DevExpress.Utils.HorzAlignment.Default},
        {"selvedge", DevExpress.Utils.HorzAlignment.Default},
        {"remark", DevExpress.Utils.HorzAlignment.Default}
    }

    End Function
#Region "👉 Json create"
    'Public Function LoadChallanData(dbName As String, companyGstNo As String) As List(Of ChallanItem)
    Public Function LoadChallanData(dbName As String, companyGstNo As String, bookcode As String, fromdate As String, todate As String) As List(Of ChallanItem)
        Dim sqlfromDate As String = DateTime.ParseExact(fromdate, "dd/MM/yyyy", Nothing).ToString("yyyy-MM-dd")
        Dim sqltoDate As String = DateTime.ParseExact(todate, "dd/MM/yyyy", Nothing).ToString("yyyy-MM-dd")
        Dim url As String = $"http://softtexbarcodemobileapi.softtexerp.com/api/BillScanner/get-challans?dbName={dbName}&companyGstNo={companyGstNo}&bookcode={bookcode}&fromDate={sqlfromDate}&toDate={sqltoDate}"

        Dim client As New WebClient()
        client.Headers.Add("accept", "*/*")

        Dim json As String = client.DownloadString(url)

        Dim response = JsonConvert.DeserializeObject(Of ChallanResponse)(json)

        Return response.data
    End Function
#End Region

#Region "👉 Modal function"
    Public Class ChallanResponse
        Public Property success As Boolean
        Public Property count As Integer
        Public Property data As List(Of ChallanItem)
    End Class
    Public Class ChallanItem
        Public Property entryNo As Integer
        Public Property bookTrType As String
        Public Property bookName As String
        Public Property bookVno As String
        Public Property challanNo As String
        Public Property challanDate As DateTime
        Public Property acofName As String
        Public Property accountName As String
        Public Property itemName As String
        Public Property designName As String
        Private _shadeName As String

        Public Property shadeName As String
            Get
                Return _shadeName
            End Get
            Set(value As String)
                If value Is Nothing _
            OrElse value.ToString().Trim().ToLower() = "null" _
            OrElse value.ToString().Trim() = "" Then

                    _shadeName = ""
                Else
                    _shadeName = value
                End If
            End Set
        End Property
        Public Property rate As Decimal
        Public Property mtrWeight As Decimal
        Public Property selvedge As String
        Private _remark As String
        Public Property remark As String
            Get
                Return _remark
            End Get
            Set(value As String)
                If value Is Nothing _
            OrElse value.ToString().Trim().ToLower() = "null" _
            OrElse value.ToString().Trim() = "" Then

                    _remark = ""
                Else
                    _remark = value
                End If
            End Set
        End Property
        Public Property greyChallan As String
        'Public Property greyRecDate As String
        Public Property greyRecDate As Nullable(Of DateTime)
        'DateTime
        Public Property avgWeight As Decimal
        Public Property weight As Decimal
        Public Property piece As String
        Public Property fdPd As String

        Public Property beamNo As String
        Public Property processName As String
        Public Property dbName As String
        Public Property companyGstNo As String


    End Class
#End Region

#Region "👉 Cell ka Text color change karne ke liye"
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) _
    Handles GridView1.RowCellStyle

        Dim view As GridView = CType(sender, GridView)

        ' Skip invalid rows (improves speed)
        If e.RowHandle < 0 Then Exit Sub

        ' --- 1) Read complete row only ONCE ---
        Dim row = view.GetDataRow(e.RowHandle)
        If row Is Nothing Then Exit Sub

        ' --- 2) Switch Case for best performance ---
        Select Case e.Column.FieldName

            Case "processName"
                If String.IsNullOrWhiteSpace(row("processcode").ToString()) Then
                    e.Appearance.ForeColor = Color.Red
                    'Else e.Appearance.ForeColor = Color.Empty
                End If

            Case "accountName"
                If String.IsNullOrWhiteSpace(row("partycode").ToString()) Then
                    e.Appearance.ForeColor = Color.Red
                End If

            Case "itemName"
                If String.IsNullOrWhiteSpace(row("itemcode").ToString()) Then
                    e.Appearance.ForeColor = Color.Red
                End If

            Case "designName"
                If String.IsNullOrWhiteSpace(row("designcode").ToString()) Then
                    e.Appearance.ForeColor = Color.Red
                End If

            Case "shadeName"

                If String.IsNullOrWhiteSpace(row("shadecode").ToString()) Then
                    e.Appearance.ForeColor = Color.Red
                End If
            Case "selvedge"
                If String.IsNullOrWhiteSpace(row("selvedgecode").ToString()) Then
                    e.Appearance.ForeColor = Color.Red
                End If

            Case "piece"
                If Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
                    If String.IsNullOrWhiteSpace(row("processpcsid").ToString()) Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
        End Select

    End Sub

#End Region
#Region "👉 Grid Control Enter key down"
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyCode = Keys.Enter Then

            If GridView1.FocusedColumn Is Nothing Then Exit Sub
            If GridView1.RowCount = 0 Then Exit Sub
            If GridView1.FocusedColumn.FieldName = "processName" Then
                obj_Party_Selection.Single_process_Selection()

                If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                    If MessageBox.Show("Replace All Account?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
                        Dim processName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "processName").ToString()

                        For i As Integer = 0 To GridView1.RowCount - 1
                            Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                            Dim iprocessName As String = GridView1.GetRowCellValue(i, "processName").ToString()
                            If ibookVno = bookVno AndAlso processName = iprocessName Then
                                GridView1.SetRowCellValue(i, "processcode", MULTY_SELECTION_COLOUM_3_DATA)
                                GridView1.SetRowCellValue(i, "processName", MULTY_SELECTION_COLOUM_1_DATA)
                            End If
                            ProcessCode = MULTY_SELECTION_COLOUM_3_DATA
                        Next
                        If Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
                            BtnProcessRefresh.Visible = True
                            BtnProcessRefresh.Enabled = True
                        Else
                            BtnProcessRefresh.Visible = True
                            BtnProcessRefresh.Enabled = False
                        End If

                    End If
                Else
                    Exit Sub
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "accountName" Then
                obj_Party_Selection.Invoice_Party_Selection()
                If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                    If MessageBox.Show("Replace All Party Account?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
                        Dim partyName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "accountName").ToString()

                        For i As Integer = 0 To GridView1.RowCount - 1
                            Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                            Dim ipartyName As String = GridView1.GetRowCellValue(i, "accountName").ToString()
                            If ibookVno = bookVno AndAlso partyName = ipartyName Then
                                GridView1.SetRowCellValue(i, "partycode", MULTY_SELECTION_COLOUM_3_DATA)
                                GridView1.SetRowCellValue(i, "accountName", MULTY_SELECTION_COLOUM_1_DATA)
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "itemName" Then
                obj_Party_Selection.SINGLE_ITEM_SELECTION()

                If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                    If MessageBox.Show("Replace All ItemName?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
                        Dim itemName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "itemName").ToString()

                        For i As Integer = 0 To GridView1.RowCount - 1
                            Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                            Dim iitemName As String = GridView1.GetRowCellValue(i, "itemName").ToString()
                            If ibookVno = bookVno AndAlso itemName = iitemName Then
                                GridView1.SetRowCellValue(i, "itemcode", MULTY_SELECTION_COLOUM_3_DATA)
                                GridView1.SetRowCellValue(i, "itemName", MULTY_SELECTION_COLOUM_1_DATA)
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "designName" Then
                'Dim itemCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "itemcode")
                Dim itemCodeValue As String = Convert.ToString(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "itemcode")).Trim()
                Dim itemCode As String = " And A.Item_Code = '" & itemCodeValue & "'"
                obj_Party_Selection.SINGLE_DESIGN_SELECTION(itemCode)
                If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                    If MessageBox.Show("Replace All DesignName?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
                        Dim designName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "designName").ToString()

                        For i As Integer = 0 To GridView1.RowCount - 1
                            Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                            Dim idesignName As String = GridView1.GetRowCellValue(i, "designName").ToString()
                            If ibookVno = bookVno AndAlso designName = idesignName Then
                                GridView1.SetRowCellValue(i, "designcode", MULTY_SELECTION_COLOUM_3_DATA)
                                GridView1.SetRowCellValue(i, "designName", MULTY_SELECTION_COLOUM_1_DATA)
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "shadeName" Then
                obj_Party_Selection.SINGLE_SHADE_SELECTION()

                If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                    If MessageBox.Show("Replace All ShadeName?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
                        Dim shadeName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "shadeName").ToString()

                        For i As Integer = 0 To GridView1.RowCount - 1
                            Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                            Dim ishadeName As String = GridView1.GetRowCellValue(i, "shadeName").ToString()
                            If ibookVno = bookVno AndAlso shadeName = ishadeName Then
                                GridView1.SetRowCellValue(i, "shadecode", MULTY_SELECTION_COLOUM_3_DATA)
                                GridView1.SetRowCellValue(i, "shadeName", MULTY_SELECTION_COLOUM_1_DATA)
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
            ElseIf GridView1.FocusedColumn.FieldName = "selvedge" Then
                obj_Party_Selection.Single_Selvedge_Selection()
                If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                    If MessageBox.Show("Replace All Selvedge?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim bookVno As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "bookVno").ToString()
                        Dim selvedgeName As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "selvedge").ToString()

                        For i As Integer = 0 To GridView1.RowCount - 1
                            Dim ibookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                            Dim iselvedgeName As String = GridView1.GetRowCellValue(i, "selvedge").ToString()
                            If ibookVno = bookVno AndAlso selvedgeName = iselvedgeName Then
                                GridView1.SetRowCellValue(i, "selvedgecode", MULTY_SELECTION_COLOUM_3_DATA)
                                GridView1.SetRowCellValue(i, "selvedge", MULTY_SELECTION_COLOUM_1_DATA)
                            End If
                        Next
                    End If
                Else
                    Exit Sub
                End If
            End If
            If Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
                If GridView1.FocusedColumn.FieldName = "piece" Then
                    For i As Integer = 0 To GridView1.RowCount - 1
                        Dim processcodeValue As Object = GridView1.GetRowCellValue(i, "processcode")
                        Dim processcode As String = If(processcodeValue Is Nothing OrElse processcodeValue Is DBNull.Value, "", processcodeValue.ToString().Trim())
                        If processcode = "" Then
                            MessageBox.Show("Please select Process Name First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                            GridView1.FocusedRowHandle = i
                            GridView1.FocusedColumn = GridView1.Columns("processName")
                            Exit Sub
                        End If
                    Next
                    Dim processpcsid_val As String =
        GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "processpcsid").ToString().Trim()

                    ' If processpcsid = "" → Text was RED
                    If processpcsid_val = "" Then
                        View_Piecedetail()
                        piecepanel.Visible = True
                        GridControl2.Visible = True

                        If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                            Exit Sub
                        End If

                    Else
                        ' If Red nahi tha → hide
                        piecepanel.Visible = False
                        GridControl2.Visible = False
                    End If

                Else
                    piecepanel.Visible = False
                    GridControl2.Visible = False
                End If
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            If piecepanel.Visible = True Then
                piecepanel.Visible = False
            Else
                Me.Close()
            End If

        End If
    End Sub
#End Region
#Region "👉 Grid data show"
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        Dim BookCode As String = ""
        View_Getonlinechallendetail()
        Fill_Pcs_ID()
    End Sub
#End Region
#Region "👉 Save All grid data "
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        'If GridView1.FocusedColumn Is Nothing Then Exit Sub
        If GridView1.RowCount = 0 Then
            MessageBox.Show("No record found.")
            GridControl1.DataSource = Nothing    'या खाली DT
            btnsave.Enabled = True
            Exit Sub
        End If
        If lblBookcode.Text = "" Or lblBookcode.Text = "lblBookcode" Then
            MessageBox.Show("Please select BookName", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
            Txtbookname.Focus()
            Exit Sub
        End If
        'Red color column check 
        For i As Integer = 0 To GridView1.RowCount - 1
            Dim val As Object = GridView1.GetRowCellValue(i, "processcode")

            Dim processcode As String =
            If(val Is Nothing OrElse val Is DBNull.Value, "", val.ToString().Trim())
            If processcode = "" Then
                MessageBox.Show("ProcessName cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns("processName")
                Exit Sub
            End If

            Dim valparty As Object = GridView1.GetRowCellValue(i, "partycode")
            Dim partycode As String = If(valparty Is Nothing OrElse valparty Is DBNull.Value, "", valparty.ToString().Trim())
            If partycode = "" Then
                MessageBox.Show("PartyName cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns("accountName")
                Exit Sub
            End If
            Dim valitem As Object = GridView1.GetRowCellValue(i, "itemcode")
            Dim itemcode As String = If(valitem Is Nothing OrElse valitem Is DBNull.Value, "", valitem.ToString().Trim())
            If itemcode = "" Then
                MessageBox.Show("ItemName cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns("itemName")
                Exit Sub
            End If

            Dim dcObj As Object = GridView1.GetRowCellValue(i, "designcode")
            Dim designcode As String = ""

            If dcObj IsNot Nothing AndAlso dcObj IsNot DBNull.Value Then
                designcode = dcObj.ToString().Trim()
            End If

            If designcode = "" Then
                MessageBox.Show("DesignName cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns("designName")
                Exit Sub
            End If

            Dim shadeVal As Object = GridView1.GetRowCellValue(i, "shadecode")
            Dim shadecode As String = If(shadeVal Is Nothing OrElse shadeVal Is DBNull.Value, "", shadeVal.ToString().Trim())
            If shadecode = "" Then
                MessageBox.Show("ShadeName cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns("shadeName")
                Exit Sub
            End If

            Dim cellValue As Object = GridView1.GetRowCellValue(i, "selvedgecode")
            Dim selvedgecode As String = If(cellValue Is Nothing OrElse cellValue Is DBNull.Value, "", cellValue.ToString().Trim())
            If selvedgecode = "" Then
                MessageBox.Show("Selvedge cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                GridView1.FocusedRowHandle = i
                GridView1.FocusedColumn = GridView1.Columns("selvedge")
                Exit Sub
            End If
            If Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
                Dim pcsidValue As Object = GridView1.GetRowCellValue(i, "processpcsid")
                Dim pcsidcode As String = If(pcsidValue Is Nothing OrElse pcsidValue Is DBNull.Value, "", pcsidValue.ToString().Trim())
                If pcsidcode = "" Then
                    MessageBox.Show("Process Pcs Id cannot match Master!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.None)
                    GridView1.FocusedRowHandle = i
                    GridView1.FocusedColumn = GridView1.Columns("piece")
                    Exit Sub
                End If
            End If
        Next
        If MessageBox.Show("Are You Sure Save Online Challan Detail?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            If Txt_ProcessStockDisplay.Text = "GRAY CHALLAN" Then
                SaveGreyChallan()
            ElseIf Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
                SaveProcessChallan()
            End If
        Else
            ' ❌ NO pressed → Nothing will execute
            Exit Sub
        End If
    End Sub
#End Region
#Region "👉 Save Grey challan "
    Public Sub SaveGreyChallan()
        sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & lblBookcode.Text & "'"
        sql_connect_slect()

        Dim _Booktrtype As String = ""
        If DefaltSoftTable.Rows.Count > 0 Then
            _Booktrtype = DefaltSoftTable.Rows(0).Item("BookTrType").ToString
        End If

        Dim _EntryNo As Integer = 1
        sqL = "SELECT TOP 1 ENTRYNO FROM TrnGreyDesp WHERE BOOKCODE='" & lblBookcode.Text & "' ORDER BY ENTRYNO DESC"
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            _EntryNo = DefaltSoftTable.Rows(0).Item("ENTRYNO") + 1
        End If

        Dim BookCode As String = lblBookcode.Text
        Dim _BookVno As String = Generate_Book_Vno(_EntryNo, _Booktrtype)


        _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        Dim Srno As Int64 = 0
        ' Auto PcsID
        Dim savegreydata As Boolean = False
        Dim Last_ID_Number As Integer = Fill_Pcs_ID()
        For i As Integer = 0 To GridView1.RowCount - 1
            Srno = Srno + 1
            If GridView1.IsDataRow(i) Then

                Dim greyPcsId As String = _SELECTEDCOMPANYCODE & "-" & Last_ID_Number.ToString.PadLeft(9, "0")

                Dim ChallanNo As String = GridView1.GetRowCellValue(i, "challanNo").ToString()
                Dim ChallanDate As String = ""

                If Not IsDBNull(GridView1.GetRowCellValue(i, "challanDate")) Then
                    ChallanDate = Format(CDate(GridView1.GetRowCellValue(i, "challanDate")), "yyyy-MM-dd")
                End If
                Dim salesDate As String = ""

                If Not IsDBNull(GridView1.GetRowCellValue(i, "challanDate")) Then
                    salesDate = Format(CDate(GridView1.GetRowCellValue(i, "challanDate")), "yyyy-MM-dd")
                End If
                Dim AcOfCode As String = GridView1.GetRowCellValue(i, "acofName").ToString()
                Dim ProcessCode As String = GridView1.GetRowCellValue(i, "processcode").ToString()
                Dim partyCode As String = GridView1.GetRowCellValue(i, "partycode").ToString()
                Dim ItemCode As String = GridView1.GetRowCellValue(i, "itemcode").ToString()
                Dim DesignCode As String = GridView1.GetRowCellValue(i, "designcode").ToString()
                Dim ShadeCode As String = GridView1.GetRowCellValue(i, "shadecode").ToString()
                Dim SelvedgeCode As String = GridView1.GetRowCellValue(i, "selvedgecode").ToString()
                Dim FdPd As String = GridView1.GetRowCellValue(i, "fdPd").ToString()
                Dim Gmtr As String = GridView1.GetRowCellValue(i, "mtrWeight").ToString()
                Dim Weight As String = GridView1.GetRowCellValue(i, "weight").ToString()
                Dim AvgWeight As String = GridView1.GetRowCellValue(i, "avgWeight").ToString()
                'Dim Remark As String = GridView1.GetRowCellValue(i, "remark").ToString()
                Dim RemarkObj = GridView1.GetRowCellValue(i, "remark")
                Dim Remark As String = If(RemarkObj Is Nothing OrElse IsDBNull(RemarkObj), "", RemarkObj.ToString())
                Dim Piece As String = GridView1.GetRowCellValue(i, "piece").ToString()
                Dim Rate As String = GridView1.GetRowCellValue(i, "rate").ToString()
                Dim FactoryCode As String = partyCode
                Dim SalesAccountCode As String = "0000-000000001"
                Dim FinishRemarkCode As String = "0000-000000001"
                Dim GridBookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                Dim beamNo As String = GridView1.GetRowCellValue(i, "beamNo").ToString()
                Dim WestPer As String = "0"
                Dim Flag As String = "1"
                Dim OP1 As String = "0001-000000091"
                Dim OP5 As String = "0000-000000001"
                Dim LoomCode As String = "0000-000000001"
                Dim GODOWNCODE As String = "0000-000000001"
                Dim pick As String = "0"
                Dim q As New StringBuilder
                With q
                    .Append(" INSERT INTO TrnGreyDesp ( ")
                    .Append(" EntryNo, BookTrtype, BookVno, BookCode, ChallanNo, ChallanDate, AcOfCode, ")
                    .Append(" ProcessCode, accountcode, fabric_ItemCode, Fabric_DesignCode, Fabric_ShadeCode, SelvCode, ")
                    .Append(" FD_PD, GMtr, Weight, PcAvgWt, detailremark, OP21, FactoryCode, Sales_AccountCode, PieceNo, ")
                    .Append(" Grey_Rate, Grey_Desp_Pcs_ID,IDP,Srno,BeamNo,WestPer,Finish_Remark_Code,Sales_Date,Flag,OP1,OP5,LoomCode,GODOWNCODE,Pick,")
                    .Append(" MTR_DESP_TO_PH_BY_OWN_PROD,MTR_DESP_TO_PH_BY_GREY_PURCHASE,MTR_DESP_TO_PH_BY_JOB_PROD,MTR_DESP_TO_PH_BY_GREY_SALE_RETURN,MTR_DESP_TO_PH_BY_OPENING,")
                    .Append(" MTR_GREY_SALES_BY_OWN_PROD,MTR_GREY_SALES_BY_JOB_PROD,MTR_GREY_SALES_BY_GREY_PURCHASE,MTR_DESP_TO_JOB_PARTY_JOB_FACTORY,MTR_DESP_TO_PH_BY_PH_GREY_RETURN,")
                    .Append(" MTR_GREY_SALES_BY_GREY_SALES_RETURN,MTR_GREY_SALES_BY_PH_GREY_RETURN,WT_DESP_TO_PH_BY_OWN_PROD,WT_DESP_TO_PH_BY_GREY_PURCHASE,WT_DESP_TO_PH_BY_JOB_PROD ,WT_DESP_TO_PH_BY_GREY_SALE_RETURN,")
                    .Append(" WT_DESP_TO_PH_BY_OPENING,WT_DESP_TO_JOB_PARTY_OWN_FACTORY,WT_GREY_SALES_BY_OWN_PROD,WT_GREY_SALES_BY_JOB_PROD,WT_GREY_SALES_BY_GREY_PURCHASE,")
                    .Append(" WT_DESP_TO_JOB_PARTY_JOB_FACTORY,WT_DESP_TO_PH_BY_PH_GREY_RETURN,WT_GREY_SALES_BY_GREY_SALES_RETURN,WT_GREY_SALES_BY_PH_GREY_RETURN")
                    .Append(" ) VALUES ( ")
                    .Append(" '" & _EntryNo & "', ")
                    .Append(" '" & _Booktrtype & "', ")
                    .Append(" '" & _BookVno & "', ")
                    .Append(" '" & BookCode & "', ")
                    .Append(" '" & ChallanNo & "', ")
                    .Append(" '" & ChallanDate & "', ")
                    .Append(" '" & AcOfCode & "', ")
                    .Append(" '" & ProcessCode & "', ")
                    .Append(" '" & partyCode & "', ")
                    .Append(" '" & ItemCode & "', ")
                    .Append(" '" & DesignCode & "', ")
                    .Append(" '" & ShadeCode & "', ")
                    .Append(" '" & SelvedgeCode & "', ")
                    .Append(" '" & FdPd & "', ")
                    .Append(" '" & Gmtr & "', ")
                    .Append(" '" & Weight & "', ")
                    .Append(" '" & AvgWeight & "', ")
                    .Append(" '" & Remark & "', ")
                    .Append(" '" & GridBookVno & "', ")
                    .Append(" '" & FactoryCode & "', ")
                    .Append(" '" & SalesAccountCode & "', ")
                    .Append(" '" & Piece & "', ")
                    .Append(" '" & Rate & "', ")
                    .Append(" '" & greyPcsId & "', ")
                    .Append(" 'YES',")
                    .Append(" " & Srno & ", ")
                    .Append(" '" & beamNo & "',")
                    .Append(" '" & WestPer & "', ")
                    .Append(" '" & FinishRemarkCode & "', ")
                    .Append(" '" & salesDate & "', ")
                    .Append(" " & Flag & ", ")
                    .Append(" '" & OP1 & "', ")
                    .Append(" '" & OP5 & "', ")
                    .Append(" '" & LoomCode & "', ")
                    .Append(" '" & GODOWNCODE & "', ")
                    .Append(" " & pick & ", ")
                    .Append(" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 ")
                    .Append(" ); ")
                End With

                sqL = q.ToString()
                sql_Data_Save_Delete_Update()

                Last_ID_Number += 1
            End If
            savegreydata = True
        Next

        MsgBox("Online Grey Challan Detail Save Success", MsgBoxStyle.Information, "Success")
        Txtbookname.Text = ""
        If savegreydata = True Then
            DeleteSelectedBookVno()
        End If
        View_Getonlinechallendetail()
        'Fill_Pcs_ID()
    End Sub
#End Region
#Region "👉 Save Process challan "
    Public Sub SaveProcessChallan()
        sqL = "SELECT * FROM MSTBOOK WHERE BOOKCODE='" & lblBookcode.Text & "'"
        sql_connect_slect()

        Dim _Booktrtype As String = ""
        If DefaltSoftTable.Rows.Count > 0 Then
            _Booktrtype = DefaltSoftTable.Rows(0).Item("BookTrType").ToString
        End If

        Dim _EntryNo As Integer = 1
        sqL = "SELECT TOP 1 ENTRYNO FROM trnFinishRcpt WHERE BOOKCODE='" & lblBookcode.Text & "' ORDER BY ENTRYNO DESC"
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            _EntryNo = DefaltSoftTable.Rows(0).Item("ENTRYNO") + 1
        End If
        Dim BookCode As String = lblBookcode.Text
        Dim Srno As Int64 = 0
        Dim LumpNo As Int64 = 0
        Dim _BookVno As String = Generate_Book_Vno(_EntryNo, _Booktrtype)
        Dim Last_ID_Number As Integer = Fill_processPcs_ID()
        Dim saveprocessdata As Boolean = False
        For i As Integer = 0 To GridView1.RowCount - 1
            If GridView1.IsDataRow(i) Then
                Srno = Srno + 1
                LumpNo = LumpNo + 1
                Dim ChallanNo As String = GridView1.GetRowCellValue(i, "challanNo").ToString()
                Dim ChallanDate As String = ""

                ' Convert ChallanDate to SQL Format
                If Not IsDBNull(GridView1.GetRowCellValue(i, "challanDate")) Then
                    ChallanDate = Format(CDate(GridView1.GetRowCellValue(i, "challanDate")), "yyyy-MM-dd")
                End If
                Dim gpDate As String = ""

                ' Convert ChallanDate to SQL Format
                If Not IsDBNull(GridView1.GetRowCellValue(i, "challanDate")) Then
                    gpDate = Format(CDate(GridView1.GetRowCellValue(i, "challanDate")), "yyyy-MM-dd")
                End If

                Dim ProcessCode As String = GridView1.GetRowCellValue(i, "processcode").ToString()
                Dim ItemCode As String = GridView1.GetRowCellValue(i, "itemcode").ToString()
                Dim DesignCode As String = GridView1.GetRowCellValue(i, "designcode").ToString()
                Dim factoryCode As String = GridView1.GetRowCellValue(i, "partycode").ToString()
                Dim SelvedgeCode As String = GridView1.GetRowCellValue(i, "selvedgecode").ToString()
                Dim ShadeCode As String = GridView1.GetRowCellValue(i, "shadecode").ToString()
                Dim Gmtr As String = GridView1.GetRowCellValue(i, "mtrWeight").ToString()
                Dim Pmtr As String = GridView1.GetRowCellValue(i, "avgWeight").ToString()
                Dim Weight As String = GridView1.GetRowCellValue(i, "weight").ToString()
                'Dim Remark As String = GridView1.GetRowCellValue(i, "remark").ToString()
                Dim RemarkObj = GridView1.GetRowCellValue(i, "remark")
                Dim Remark As String = If(RemarkObj Is Nothing OrElse IsDBNull(RemarkObj), "", RemarkObj.ToString())
                Dim Piece As String = GridView1.GetRowCellValue(i, "piece").ToString()
                Dim Rate As String = GridView1.GetRowCellValue(i, "rate").ToString()
                Dim GridBookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString()
                Dim greyPcsId As String = GridView1.GetRowCellValue(i, "processpcsid").ToString()
                Dim greychallan As String = GridView1.GetRowCellValue(i, "greyChallan").ToString()
                Dim greyRecDate As String = GridView1.GetRowCellValue(i, "greyRecDate").ToString()
                Dim ShkMtr As String = GridView1.GetRowCellValue(i, "shrinkmtr").ToString()
                Dim ShkPer As String = GridView1.GetRowCellValue(i, "shrinkper").ToString()
                Dim OldGmtr As String = GridView1.GetRowCellValue(i, "oldgmtr").ToString()
                Dim beamNo As String = GridView1.GetRowCellValue(i, "beamNo").ToString()
                Dim LumpID As String = _SELECTEDCOMPANYCODE & "-" & Last_ID_Number.ToString.PadLeft(9, "0")
                Dim GODOWNCODE As String = "0000-000000001"
                Dim HeaderRemark As String = ""
                Dim Debitnotemtr As Int64 = "0"
                Dim greyreturnmtr As Int64 = "0"
                Dim greytransfermtr As Int64 = "0"
                Dim Gpno As Int64 = "0"
                Dim SqlQuery As New StringBuilder
                With SqlQuery
                    .Append(" INSERT INTO trnFinishRcpt ( ")
                    .Append(" EntryNo, BookTrtype, BookVno, BookCode, ChallanNo, ChallanDate,  ")
                    .Append(" ProcessCode,  fabric_ItemCode, Fabric_DesignCode, Fabric_ShadeCode,  ")
                    .Append(" GMtr,PMtr, Weight,  detailremark, OP21, PieceNo, ")
                    .Append(" Grey_Desp_Pcs_ID,OP9,OP1,Shk_Mtr,Shk_Per,OP10,Srno,Proc_BeamNo,Lump_ID,Lump_No,GPDate,DPR_Rcpt_Mtr,Finish_Rcpt_Mtr,OP2,GODOWNCODE,LRNO,")
                    .Append(" HeaderRemark,Debit_Note_Mtr,Grey_Return_Mtr,Grey_Transfer_Rcpt_Mtr,GPNO")
                    .Append(" ) VALUES ( ")
                    .Append(" '" & _EntryNo & "', ")
                    .Append(" '" & _Booktrtype & "', ")
                    .Append(" '" & _BookVno & "', ")
                    .Append(" '" & BookCode & "', ")
                    .Append(" '" & ChallanNo & "', ")
                    .Append(" '" & ChallanDate & "', ")
                    .Append(" '" & ProcessCode & "', ")
                    .Append(" '" & ItemCode & "', ")
                    .Append(" '" & DesignCode & "', ")
                    .Append(" '" & ShadeCode & "', ")
                    .Append(" '" & Gmtr & "', ")
                    .Append(" '" & Pmtr & "', ")
                    .Append(" '" & Weight & "', ")
                    .Append(" '" & Remark & "', ")
                    .Append(" '" & GridBookVno & "', ")
                    .Append(" '" & Piece & "', ")
                    .Append(" '" & greyPcsId & "', ")
                    .Append(" '" & greychallan & "', ")
                    .Append(" '" & greyRecDate & "', ")
                    .Append(" '" & ShkMtr & "', ")
                    .Append(" '" & ShkPer & "',")
                    .Append(" '" & OldGmtr & "', ")
                    .Append(" '" & Srno & "', ")
                    .Append(" '" & beamNo & "', ")
                    .Append(" '" & LumpID & "', ")
                    .Append(" '" & LumpNo & "', ")
                    .Append(" '" & gpDate & "', ")
                    .Append(" 0,'" & Pmtr & "','" & factoryCode & "','" & GODOWNCODE & "', '" & SelvedgeCode & "',")
                    .Append(" '" & HeaderRemark & "','" & Debitnotemtr & "','" & greyreturnmtr & "','" & greytransfermtr & "',,'" & Gpno & "'")
                    .Append(" ); ")
                End With
                sqL = SqlQuery.ToString()
                sql_Data_Save_Delete_Update()
            End If
            saveprocessdata = True
        Next
        MsgBox("Online Process Challan Detail Save Success", MsgBoxStyle.Information, "Success")
        Txtbookname.Text = ""
        'If saveprocessdata = True Then
        '    DeleteSelectedBookVno()
        'End If
        View_Getonlinechallendetail()
        'ProcessFill_Pcs_ID()
    End Sub
    Public Function DeleteSelectedBookVno() As Boolean
        Try
            ' 1. UNIQUE BookVno list create
            Dim bookVnoList As New HashSet(Of String)()

            For i As Integer = 0 To GridView1.RowCount - 1
                Dim GridBookVno As String = GridView1.GetRowCellValue(i, "bookVno").ToString().Trim()

                If GridBookVno <> "" Then
                    bookVnoList.Add(GridBookVno)
                End If
            Next

            If bookVnoList.Count = 0 Then
                MessageBox.Show("No BookVno found to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' 2. Convert to comma-separated string
            'Dim csvBookVno As String = String.Join(",", bookVnoList.ToArray())
            Dim bookVnoArray As String = String.Join(""",""", bookVnoList)

            ' 3. JSON body create
            'Dim deleteJson As String = $"{{""BookVno"": [""{csvBookVno}""]}}"
            Dim deleteJson As String = $"{{""BookVno"": [""{bookVnoArray}""]}}"
            ' 4. API URL
            Dim apiUrl As String = $"http://softtexbarcodemobileapi.softtexerp.com/api/BillScanner/delete-challans?dbName={dbName}&companyGstNo={gst}"

            ' 5. POST Request (No Await)
            Using client As New HttpClient()
                Dim content As New StringContent(deleteJson, Encoding.UTF8, "application/json")

                Dim response As HttpResponseMessage = client.PostAsync(apiUrl, content).Result
                Dim result As String = response.Content.ReadAsStringAsync().Result

                'MessageBox.Show("API Response: " & result, "Delete Response", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using

            Return True

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

#End Region
#Region "👉 Bookname enter key selection"
    Private Sub Txtbookname_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtbookname.KeyDown
        'BOOK_BHEWAR = "BOOKMODIFY"
        'BOOK_CATGER = ""
        BOOK_BHEWAR = ""
        'BOOK_CATGER = "GREY-CHALLAN"
        If Txt_ProcessStockDisplay.Text = "GRAY CHALLAN" Then
            BOOK_CATGER = "GREY-CHALLAN"
        ElseIf Txt_ProcessStockDisplay.Text = "PROCESS CHALLAN" Then
            BOOK_CATGER = "PROCESS-CHALLAN"
            BOOK_BHEWAR = "PROCESS BOOK"
        End If
        obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
        If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
            Txtbookname.Text = MULTY_SELECTION_COLOUM_1_DATA
            Txtbookname.ReadOnly = True
            lblBookcode.Text = MULTY_SELECTION_COLOUM_3_DATA
            But_ok.Focus()
            'lblmsge.Visible = True
        End If
    End Sub
#End Region
#Region "👉 PCS ID Generate Logic (Grey_Desp_Pcs_ID Auto Fill)"
    Private Function Fill_Pcs_ID()

        Dim Last_ID_Number As Integer = 0

        Try
            _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
            Dim Pcs_ID As String = ""
            '_ComapnyYearCode = _ComapnyYearCode.ToString.Trim.PadLeft(4, "0")
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT TOP 1 SUBSTRING(Grey_Desp_Pcs_ID,6,15) ")
                .Append(" FROM TrnGreyDesp ")
                .Append(" WHERE 1=1 ")
                .Append(" AND LEFT(Grey_Desp_Pcs_ID,4)='" & _SELECTEDCOMPANYCODE & "' ")
                .Append(" ORDER BY Grey_Desp_Pcs_ID DESC ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            Dim Str_Qry As String = ""
            If DefaltSoftTable.Rows.Count > 0 Then
                Str_Qry = DefaltSoftTable.Rows(0).Item(0)
                Last_ID_Number = Val(Str_Qry) + 1
            Else
                Last_ID_Number = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return Last_ID_Number
    End Function
    Private Function Fill_processPcs_ID()

        Dim Last_ID_Number As Integer = 0

        Try
            _SELECTEDCOMPANYCODE = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
            Dim Pcs_ID As String = ""
            '_ComapnyYearCode = _ComapnyYearCode.ToString.Trim.PadLeft(4, "0")
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT TOP 1 SUBSTRING(Grey_Desp_Pcs_ID,6,15) ")
                .Append(" FROM TrnFinishRcpt ")
                .Append(" WHERE 1=1 ")
                .Append(" AND LEFT(Grey_Desp_Pcs_ID,4)='" & _SELECTEDCOMPANYCODE & "' ")
                .Append(" ORDER BY Grey_Desp_Pcs_ID DESC ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()

            Dim Str_Qry As String = ""
            If DefaltSoftTable.Rows.Count > 0 Then
                Str_Qry = DefaltSoftTable.Rows(0).Item(0)
                Last_ID_Number = Val(Str_Qry) + 1
            Else
                Last_ID_Number = 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return Last_ID_Number
    End Function
#End Region
#Region "👉 Button Refresh for New Process Pcs Id"
    Private Sub BtnProcessRefresh_Click(sender As Object, e As EventArgs) Handles BtnProcessRefresh.Click
        Dim Last_PcsID_Number As Integer = 0
        Dim rowHandle = GridView1.FocusedRowHandle

        For i As Integer = 0 To GridView1.RowCount - 1
            Dim _Pieceno = Convert.ToString(GridView1.GetRowCellValue(i, "piece"))
            Dim _graychallanno = Convert.ToString(GridView1.GetRowCellValue(i, "challanNo"))
            Dim _ProcessCode = Convert.ToString(GridView1.GetRowCellValue(i, "processcode"))
            Dim lookupKey As String = $"{_Pieceno}|{_graychallanno}|{_ProcessCode}"
            'Dim lookupKey As String = $"{_Pieceno}&{_graychallanno}&{_ProcessCode}"
            If ProcesspcsidDict.ContainsKey(lookupKey) Then
                GridView1.SetRowCellValue(i, "processpcsid", ProcesspcsidDict(lookupKey))
            End If
        Next
        GridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle
        GridView1.FocusedColumn = GridView1.Columns("mtrWeight")
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If GridView2.FocusedColumn Is Nothing Then Exit Sub
        If GridView2.RowCount = 0 Then Exit Sub
        If GridView2.FocusedColumn.FieldName = "Piece No" Then

            If MULTY_SELECTION_COLOUM_3_DATA <> "" Then

                'If MessageBox.Show("Replace ProcesspcsId?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim _newpcsId As String = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Final_Grey_ID").ToString()
                Dim _newpieceno As String = GridView2.GetFocusedRowCellValue("Piece No").ToString()
                Dim _newgreychallan As String = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Chl-No").ToString()
                Dim _newgreydate As String = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Chl-Date").ToString()
                Dim _newGmtr As String = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "G-Mtrs (Balance)").ToString()
                ' Convert dd/MM/yyyy → SQL yyyy-MM-dd
                Dim _sqlgreyDate As String = ""
                Dim tempDate As Date
                If Date.TryParseExact(_newgreydate, "dd/MM/yyyy",
                      Globalization.CultureInfo.InvariantCulture,
                      Globalization.DateTimeStyles.None,
                      tempDate) Then

                    _sqlgreyDate = tempDate.ToString("yyyy-MM-dd")
                End If
                Dim rowHandle As Integer = GridView1.FocusedRowHandle
                If rowHandle < 0 Then Exit Sub

                Dim _oldpieceno As String = GridView1.GetFocusedRowCellValue("piece").ToString()

                sqL = "SELECT COUNT(*) as cnt FROM trnFinishRcpt WHERE Grey_Desp_Pcs_ID='" & _newpcsId & "'"
                sql_connect_slect()

                Dim tpCount As Integer = 0
                If DefaltSoftTable.Rows.Count > 0 Then
                    tpCount = Convert.ToInt32(DefaltSoftTable.Rows(0).Item("cnt"))
                End If
                tpCount += 1
                Dim finalTP As String = "-TP" & tpCount
                Dim newPieceNo As String = _newpieceno & finalTP
                GridView1.SetRowCellValue(rowHandle, "processpcsid", _newpcsId)
                GridView1.SetRowCellValue(rowHandle, "piece", newPieceNo)
                GridView1.SetRowCellValue(rowHandle, "greyChallan", _newgreychallan)
                GridView1.SetRowCellValue(rowHandle, "greyRecDate", _sqlgreyDate)
                GridView1.SetRowCellValue(rowHandle, "mtrWeight", _newGmtr)
                GridView1.SetRowCellValue(rowHandle, "oldgmtr", _newGmtr)
                piecepanel.Visible = False
                Dim GMtr As Decimal = Convert.ToDecimal(GridView1.GetRowCellValue(rowHandle, "mtrWeight"))
                Dim PMtr As Decimal = Convert.ToDecimal(GridView1.GetRowCellValue(rowHandle, "avgWeight"))

                Dim shrinkMtr As Decimal = Math.Round(GMtr - PMtr, 2)
                GridView1.SetRowCellValue(rowHandle, "shrinkmtr", shrinkMtr)

                Dim shrinkPer As Decimal = 0
                If GMtr <> 0 Then
                    shrinkPer = Math.Round(((GMtr - PMtr) / GMtr) * 100, 2)
                End If
                GridView1.SetRowCellValue(rowHandle, "shrinkper", shrinkPer)
                AddHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
                'End If

            Else
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            piecepanel.Visible = False
        End If
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

        ' 👉 Sirf jab mtrWeight change ho tab calculation chale
        If e.Column.FieldName = "mtrWeight" Then
            Dim rowHandle As Integer = GridView1.FocusedRowHandle
            If rowHandle < 0 Then Exit Sub

            Dim GMtr As Decimal = Convert.ToDecimal(GridView1.GetRowCellValue(rowHandle, "mtrWeight"))
            Dim PMtr As Decimal = Convert.ToDecimal(GridView1.GetRowCellValue(rowHandle, "avgWeight"))

            Dim shrinkMtr As Decimal = Math.Round(GMtr - PMtr, 2)
            Dim shrinkPer As Decimal = If(GMtr <> 0, Math.Round(((GMtr - PMtr) / GMtr) * 100, 2), 0)

            GridView1.SetRowCellValue(rowHandle, "shrinkmtr", shrinkMtr)
            GridView1.SetRowCellValue(rowHandle, "shrinkper", shrinkPer)
        End If

    End Sub
#End Region

End Class