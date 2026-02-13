Imports System.ComponentModel.Design
Imports System.IO
Imports System.Text
Imports CrystalDecisions.Shared
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraVerticalGrid


Friend Class StoreConsumption_GridZooming

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
        txt_To.Text = obj_Party_Selection.GetFinancaleYearDate("")
        Txt_ViewType.Text = "Item Wise"
        Txt_ProcessStockDisplay.Text = "SUMMARY"
        If LEDGER_FORM_DISPALY_BY <> "BUTTONCALL" Then
            Me.Location = New Point(0, 0)
        End If

        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        If Txt_ProcessStockDisplay.Text = "SUMMARY" AndAlso
   (Txt_ViewType.Text = "Month+Loom Wise" Or Txt_ViewType.Text = "Month+Item Wise") Then
            ' 🔹 Month-based zooming case
            '_NewTmptbl = _Zooming_Load(txt_To.Date_for_Database)
            'Stock_Zooming_Load(_NewTmptbl)
            _NewTmptbl = _Zooming_Load(txt_To.Date_for_Database, "FIRST", "")
            Stock_Zooming_Load(_NewTmptbl)
        ElseIf (Txt_ProcessStockDisplay.Text = "SUMMARY" Or Txt_ProcessStockDisplay.Text = "DETAIL") AndAlso
               (Txt_ViewType.Text = "Loom Wise" Or Txt_ViewType.Text = "Item Wise" Or Txt_ViewType.Text = "Loom+Item Wise") Then
            ' 🔹 Other summary/detail case
            _NewTmptbl = _SummaryMonth_Load("FIRST", "")
            Stock_Summarymonth_Load(_NewTmptbl)

        End If

        AttachButtonFocusEvents(Me)
    End Sub
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        _CloseCheck = False
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)
        Dim _NewTmptbl As New DataTable
        Dim _NewTmptbl2 As New DataTable
        If Txt_ProcessStockDisplay.Text = "SUMMARY" AndAlso
   (Txt_ViewType.Text = "Month+Loom Wise" Or Txt_ViewType.Text = "Month+Item Wise") Then


            _NewTmptbl = _Zooming_Load(txt_To.Date_for_Database, "FIRST", "")
            _TmpMonthwiseTbl = _NewTmptbl.Copy
            Stock_Zooming_Load(_NewTmptbl)



        ElseIf (Txt_ProcessStockDisplay.Text = "SUMMARY" Or Txt_ProcessStockDisplay.Text = "DETAIL") AndAlso
               (Txt_ViewType.Text = "Loom Wise" Or Txt_ViewType.Text = "Item Wise" Or Txt_ViewType.Text = "Loom+Item Wise") Then

            ' 🔹 Remove old view (BandedGridView)
            GridControl1.MainView = Nothing
            GridControl1.ViewCollection.Clear()

            ' 🔹 Reset existing FirstStage GridView (no need to create new)
            FirstStage = New GridView(GridControl1)
            GridControl1.MainView = FirstStage
            GridControl1.ViewCollection.Add(FirstStage)

            ' 🔹 Remove all existing columns (if any)
            FirstStage.Columns.Clear()

            ' 🔹 Clear any existing bands or layouts
            GridControl1.LevelTree.Nodes.Clear()
            FirstStage.OptionsView.ShowFooter = True


            ' 🔹 Other summary/detail case
            _NewTmptbl2 = _SummaryMonth_Load("FIRST", "")
            Stock_Summarymonth_Load(_NewTmptbl2)

        End If

    End Sub


    Private Sub Stock_Zooming_Load(ByVal Stktbl As DataTable)

        If Stktbl.Rows.Count > 0 Then
            Display_Stage_No = 1
            NoOfstage = 1
            FirstStage.Columns.Clear()
            If Stktbl.Rows.Count > 0 Then

                GridControl1.DataSource = Stktbl.Copy
                Dim bandedView As New BandedGridView(GridControl1)
                GridControl1.MainView = bandedView
                GridControl1.ViewCollection.Add(bandedView)
                '_StgIRowNo = bandedView.FocusedRowHandle
                ' 🔹 Formatting options
                'Dim _ActivatedColName As String = ""
                'If bandedView IsNot Nothing AndAlso bandedView.FocusedColumn IsNot Nothing Then
                '    _ActivatedColName = bandedView.FocusedColumn.FieldName
                'End If
                'Dim _StgIRowNo As Integer = 0
                'If bandedView IsNot Nothing Then
                '    _StgIRowNo = bandedView.FocusedRowHandle
                'End If
                bandedView.OptionsView.ShowBands = True
                bandedView.OptionsView.ShowAutoFilterRow = True
                bandedView.OptionsBehavior.Editable = False
                bandedView.OptionsView.ShowFooter = True
                bandedView.BestFitColumns()
                ' Enable vertical scrolling
                bandedView.OptionsView.ColumnAutoWidth = False   ' Allows horizontal scroll if columns exceed width
                bandedView.OptionsView.ShowIndicator = True      ' Row indicator (optional)
                bandedView.OptionsView.ShowFooter = True         ' Footer if needed

                ' Enable scrolling
                bandedView.OptionsBehavior.Editable = False      ' Example: make read-only
                bandedView.OptionsView.ColumnAutoWidth = False   ' Prevent auto-stretch
                bandedView.OptionsView.EnableAppearanceEvenRow = True
                bandedView.OptionsView.EnableAppearanceOddRow = True

                ' Scroll settings
                bandedView.OptionsView.RowAutoHeight = True
                bandedView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                bandedView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always

                ' 🔹 Create GridBands
                Dim LoomNo As New GridBand() With {.Caption = "Loom No"}
                Dim Itemname As New GridBand() With {.Caption = "Item Name"}
                Dim Itemcode As New GridBand() With {.Caption = "Item Code"}
                Dim challanDate As New GridBand() With {.Caption = "Date"}
                Dim LoomNoCode As New GridBand() With {.Caption = "Loom No Code"}
                Select Case Txt_ViewType.Text

                    Case "Month+Loom Wise"
                        Dim colLoom As BandedGridColumn = AddBandedColumn(bandedView, "LoomNo", "")
                        LoomNo.Columns.Add(colLoom)
                        bandedView.Bands.Add(LoomNo)
                        Dim colLoomCode As BandedGridColumn = AddBandedColumn(bandedView, "LOOMNOCODE", "")
                        colLoomCode.Visible = False

                        'LoomNoCode.Columns.Add(colLoomCode)
                        'bandedView.Bands.Add(LoomNoCode)

                        ' ✅ Left align text
                        colLoom.AppearanceCell.Options.UseTextOptions = True
                        colLoom.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

                        ' ❌ Hide column header (only band header visible)
                        colLoom.Caption = ""
                        colLoom.OptionsColumn.ShowCaption = False

                    Case "Month+Item Wise"
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        Itemname.Columns.Add(colItem)
                        bandedView.Bands.Add(Itemname)

                        Dim colItemcode As BandedGridColumn = AddBandedColumn(bandedView, "ItemCode", "")
                        'Itemcode.Columns.Add(colItemcode)
                        'bandedView.Bands.Add(Itemcode)
                        colItemcode.Visible = False
                        colItemcode.OptionsColumn.ShowCaption = False
                        colItem.AppearanceCell.Options.UseTextOptions = True
                        colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        colItem.Caption = ""
                        colItem.OptionsColumn.ShowCaption = False

                    Case "Loom+Item Wise"
                        Dim colLoom As BandedGridColumn = AddBandedColumn(bandedView, "LoomNo", "")
                        Dim colLoomnocode As BandedGridColumn = AddBandedColumn(bandedView, "LOOMNOCODE", "")
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        LoomNo.Columns.Add(colLoom)
                        LoomNoCode.Columns.Add(colLoomnocode)
                        Itemname.Columns.Add(colItem)
                        bandedView.Bands.Add(LoomNo)
                        bandedView.Bands.Add(Itemname)
                        bandedView.Bands.Add(LoomNoCode)

                        For Each col In {colLoom, colItem}
                            col.AppearanceCell.Options.UseTextOptions = True
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                            col.Caption = ""
                            col.OptionsColumn.ShowCaption = False
                        Next

                    Case "Detail"
                        Dim colLoom As BandedGridColumn = AddBandedColumn(bandedView, "LoomNo", "")
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        Dim colItemCode As BandedGridColumn = AddBandedColumn(bandedView, "ItemCode", "")
                        Dim colDate As BandedGridColumn = AddBandedColumn(bandedView, "CHALLANDATE", "")
                        LoomNo.Columns.Add(colLoom)
                        Itemname.Columns.Add(colItem)
                        challanDate.Columns.Add(colDate)
                        Itemcode.Columns.Add(colItemCode)
                        bandedView.Bands.Add(LoomNo)
                        bandedView.Bands.Add(Itemname)
                        bandedView.Bands.Add(challanDate)
                        Itemcode.Columns.Add(colItemCode)
                        colItemCode.OptionsColumn.ShowCaption = False
                        For Each col In {colLoom, colItem, colDate}
                            col.AppearanceCell.Options.UseTextOptions = True
                            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                            col.Caption = ""
                            col.OptionsColumn.ShowCaption = False
                        Next

                    Case Else
                        Dim colItem As BandedGridColumn = AddBandedColumn(bandedView, "ItemName", "")
                        Itemname.Columns.Add(colItem)
                        bandedView.Bands.Add(Itemname)

                        colItem.AppearanceCell.Options.UseTextOptions = True
                        colItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        colItem.Caption = ""
                        colItem.OptionsColumn.ShowCaption = False
                End Select

                ' ✅ Optional: Make band headers bold and centered
                For Each band In bandedView.Bands
                    band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                    band.AppearanceHeader.Options.UseFont = True
                    band.AppearanceHeader.Options.UseTextOptions = True
                    band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                Next

                ' 🔹 MONTH BANDS (for Qty & Amt)
                Dim dt As DataTable = GridControl1.DataSource
                Dim monthNames As New List(Of String) From {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

                For Each m In monthNames
                    If dt.Columns.Contains(m & "_Qty") OrElse dt.Columns.Contains(m & "_Amt") Then
                        Dim band As New GridBand() With {.Caption = m}

                        If dt.Columns.Contains(m & "_Qty") Then
                            band.Columns.Add(AddBandedColumn(bandedView, m & "_Qty", "Qty"))
                        End If
                        If dt.Columns.Contains(m & "_Amt") Then
                            band.Columns.Add(AddBandedColumn(bandedView, m & "_Amt", "Amt"))
                        End If

                        band.AppearanceHeader.Options.UseTextOptions = True
                        band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        band.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                        band.AppearanceHeader.Font = New Font("Verdana", 8, FontStyle.Bold)
                        band.AppearanceHeader.BackColor = Color.LightGray

                        bandedView.Bands.Add(band)
                    End If
                Next

                ConfigureBandedGridView(bandedView)
                'bandedView.BestFitColumns()

                bandedView.FocusedRowHandle = _StgIRowNo
                'bandedView.FocusedColumn = bandedView.Columns(0)
                If bandedView.Columns("ItemName") IsNot Nothing Then
                    bandedView.FocusedColumn = bandedView.Columns("ItemName")
                End If
                If bandedView.Columns("Qty") IsNot Nothing Then
                    bandedView.FocusedColumn = bandedView.Columns("Qty")
                End If

                bandedView.OptionsBehavior.Editable = False
                bandedView.OptionsView.ColumnAutoWidth = False
                bandedView.OptionsView.RowAutoHeight = True
                bandedView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                bandedView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                bandedView.OptionsView.ShowBands = True


                bandedView.Focus()
                'FirstStage.OptionsBehavior.Editable = False
                FirstStage.BestFitColumns()
                'FirstStage.Focus()
            End If
        End If
    End Sub


    Private Sub Stock_Summarymonth_Load(ByVal Stktbl As DataTable)

        FirstStage.Columns.Clear()
        If Stktbl.Rows.Count > 0 Then
            Display_Stage_No = 1
            NoOfstage = 1
            Dim _ActivatedColName As String = ""
            If FirstStage IsNot Nothing AndAlso FirstStage.FocusedColumn IsNot Nothing Then
                _ActivatedColName = FirstStage.FocusedColumn.FieldName
            End If
            If Stktbl.Rows.Count > 0 Then
                GridControl1.DataSource = Stktbl.Copy
                DevGridFitColumnWiotScroll(GridControl1, FirstStage)
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Qty",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Qty")
            })
                End If
                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Amount",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Amount")
            })
                End If
                FirstStage.Appearance.FocusedRow.BackColor = FirstStage.Appearance.FocusedRow.BackColor.LightBlue
                FirstStage.Appearance.FocusedRow.BackColor = Color.LightBlue
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Month+Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Month+Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False
                    End Select
                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Month+Loom Wise"

                        Case "Month+Item Wise"

                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False
                    End Select
                End If
                ' 🔹 Right-align header text for Qty and Amount columns
                If FirstStage.Columns.ColumnByFieldName("EntryNo") IsNot Nothing Then
                    FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    FirstStage.Columns("EntryNo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                End If
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    FirstStage.Columns("Qty").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    FirstStage.Columns("Amount").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                'FirstStage.Columns("ItemCode").Visible = False
                FirstStage.OptionsBehavior.Editable = False
                FirstStage.FocusedRowHandle = _StgIRowNo
            End If
        End If
    End Sub
    Private Sub ConfigureBandedGridView(ByVal view As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        ' 🔹 Enable footer only once
        With view
            .OptionsView.ShowFooter = True
            .Appearance.FooterPanel.Font = New Font("Verdana", 8, FontStyle.Bold)
            .Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        End With


        Dim headerFont As New Font("Verdana", 8, FontStyle.Bold)
        Dim cellFont As New Font("Verdana", 8, FontStyle.Regular)


        For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In view.Columns
            'With col.AppearanceHeader
            '    .Font = headerFont
            '    .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '    .TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            '    .BackColor = Color.LightBlue
            '    .BackColor2 = Color.Navy
            '    .GradientMode = Drawing2D.LinearGradientMode.Vertical
            '    .ForeColor = Color.White
            'End With

            'With col.AppearanceCell
            '    .Font = cellFont
            '    .TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            'End With


            Select Case Type.GetTypeCode(col.ColumnType)
                Case TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.Single
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                Case Else
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            End Select


            If col.FieldName.ToLower().Contains("_qty") OrElse col.FieldName.ToLower().Contains("_amt") Then
                With col.SummaryItem
                    .SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .DisplayFormat = "{0:N2}"
                End With
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        Next


        'For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In view.Bands
        '    With band.AppearanceHeader
        '        .Font = headerFont
        '        .TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        '        .TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        '        .BackColor = Color.Khaki
        '        .BackColor2 = Color.Navy
        '        .GradientMode = Drawing2D.LinearGradientMode.Vertical
        '        .ForeColor = Color.White
        '    End With
        'Next
    End Sub



    Private Function AddBandedColumn(view As BandedGridView, fieldName As String, caption As String) As BandedGridColumn
        Dim col As New BandedGridColumn() With {
        .FieldName = fieldName,
        .Caption = caption,
        .Visible = True
    }
        view.Columns.Add(col)
        Return col
    End Function
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Qty", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Qty")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Amount", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Amount")})


        gridView.Appearance.GroupRow.BackColor = Color.LightGreen

    End Sub
    ' Private Function _Zooming_Load(ByVal _DateTo As String)
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
                ' Double single-quotes for dynamic SQL
                dateFilter = " AND A.CHALLANDATE >=  '" & txt_From.Date_for_Database & "' And A.CHALLANDATE <=  '" & txt_To.Date_for_Database & "'"
            End If
            If _EnterStage = "FIRST" Then
                'OrElse _EnterStage = "SECOND" 
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    If _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Month+Loom Wise"
                                filter = " AND C.LoomNo IS NOT NULL " & dateFilter
                                groupCols = "C.LoomNo, FORMAT(A.CHALLANDATE,''MMM''),A.LOOMNOCODE"
                                selectCols = "C.LoomNo,A.LOOMNOCODE"
                                orderCols = "LoomNo,LOOMNOCODE"

                            Case "Month+Item Wise"
                                filter = " AND B.ItemName IS NOT NULL " & dateFilter
                                groupCols = "B.ItemName,A.ItemCode, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "B.ItemName,A.ItemCode"
                                orderCols = "ItemName,ItemCode"
                            Case "Loom+Item Wise"
                                filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL " & dateFilter
                                groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "C.LoomNo, B.ItemName"
                                orderCols = "LoomNo, ItemName"

                            Case "Detail"
                                filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL " & dateFilter
                                groupCols = "C.LoomNo, B.ItemName, A.CHALLANDATE, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "C.LoomNo, B.ItemName, A.CHALLANDATE"
                                orderCols = "CHALLANDATE, LoomNo, ItemName"

                            Case Else
                                filter = dateFilter
                                groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "C.LoomNo, B.ItemName"
                                orderCols = "LoomNo, ItemName"
                        End Select
                    ElseIf _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Month+Loom Wise"
                                filter = " AND C.LoomNo IS NOT NULL " & dateFilter
                                groupCols = "C.LoomNo, FORMAT(A.CHALLANDATE,''MMM''),A.LOOMNOCODE"
                                selectCols = "C.LoomNo,A.LOOMNOCODE"
                                orderCols = "LoomNo,LOOMNOCODE"

                            Case "Month+Item Wise"
                                filter = " AND B.ItemName IS NOT NULL " & dateFilter
                                groupCols = "B.ItemName,A.ItemCode, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "B.ItemName,A.ItemCode"
                                orderCols = "ItemName,ItemCode"

                            Case "Loom+Item Wise"
                                filter = " AND C.LoomNo IS NOT NULL AND B.ItemName IS NOT NULL " & dateFilter
                                groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "C.LoomNo, B.ItemName"
                                orderCols = "LoomNo, ItemName"

                            Case Else
                                filter = dateFilter
                                groupCols = "C.LoomNo, B.ItemName, FORMAT(A.CHALLANDATE,''MMM'')"
                                selectCols = "C.LoomNo, B.ItemName"
                                orderCols = "LoomNo, ItemName"
                        End Select
                    End If


                    ' --- Build the dynamic SQL

                    .AppendLine("DECLARE @cols NVARCHAR(MAX);")
                    .AppendLine("DECLARE @query NVARCHAR(MAX);")

                    ' 🔹 Dynamic month-wise column list (Qty + Amt)
                    .AppendLine("SELECT @cols = STUFF((")
                    .AppendLine("    SELECT DISTINCT ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+'_Qty') + ',' + QUOTENAME(FORMAT(A.CHALLANDATE,'MMM')+'_Amt')")
                    .AppendLine("    FROM TRNCHALLAN A")
                    .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
                    .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
                    .AppendLine("    WHERE A.BOOKCODE='0001-000000155'" & filter)
                    .AppendLine("    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),1,1,'');")
                    .AppendLine("IF @cols IS NULL OR LEN(@cols)=0 SET @cols = '[NoData]';")

                    ' 🔹 Main PIVOT query (no extra GROUP BY after pivot)
                    .AppendLine("SET @query = '")
                    .AppendLine("SELECT " & orderCols & ", ' + @cols + '")
                    .AppendLine("FROM (")
                    .AppendLine("    SELECT " & selectCols & ", FORMAT(A.CHALLANDATE,''MMM'') + ''_Qty'' AS MonthType, SUM(A.MTR_WEIGHT) AS Value")
                    .AppendLine("    FROM TRNCHALLAN A")
                    .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
                    .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
                    .AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter.Replace("'", "''"))
                    .AppendLine("    GROUP BY " & groupCols)

                    .AppendLine("    UNION ALL")

                    .AppendLine("    SELECT " & selectCols & ", FORMAT(A.CHALLANDATE,''MMM'') + ''_Amt'' AS MonthType, SUM(A.AMOUNT) AS Value")
                    .AppendLine("    FROM TRNCHALLAN A")
                    .AppendLine("    LEFT JOIN MSTSTOREITEM B ON A.ITEMCODE=B.ITEMCODE")
                    .AppendLine("    LEFT JOIN MstLoomNo C ON A.LOOMNOCODE=C.LoomNoCode")
                    .AppendLine("    WHERE A.BOOKCODE = ''0001-000000155''" & filter.Replace("'", "''"))
                    .AppendLine("    GROUP BY " & groupCols)

                    .AppendLine(") AS SourceData")
                    .AppendLine("PIVOT (")
                    .AppendLine("    SUM(Value) FOR MonthType IN (' + @cols + ')")
                    .AppendLine(") AS PivotResult")
                    'If _EnterStage = "SECOND" Then
                    '    .Append(FilterString)
                    'End If

                    .AppendLine("ORDER BY " & orderCols & ";'")
                    .AppendLine("EXEC sp_executesql @query;")
                End If
            End If

        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _NewTmptbl As New DataTable
        Zoom_Stock_Table.Clear()
        Zoom_Stock_Table = DefaltSoftTable.Copy
        _NewTmptbl = DefaltSoftTable.Copy
        Return _NewTmptbl
    End Function

    Private Function _SummaryMonth_Load(ByRef _EnterStage As String, ByRef FilterString As String)
        Dim dateFilter = " AND A.CHALLANDATE >=  '" & txt_From.Date_for_Database & "' And A.CHALLANDATE <=  '" & txt_To.Date_for_Database & "'"
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            If _EnterStage = "FIRST" OrElse _EnterStage = "SECOND" Then
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    If _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                '.Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Item Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")

                            Case "Loom+Item Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")

                            Case Else
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")
                        End Select
                    ElseIf _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" C.LoomNo, ")
                                .Append(" A.LOOMNOCODE, ")
                                '.Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Item Wise"
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Loom+Item Wise"
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.LOOMNOCODE, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case Else
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")
                        End Select
                    End If



                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            .Append(" A.EntryNo, ")
                            .Append(" A.CHALLANDATE As Date, ")
                            .Append(" C.LoomNo, ")
                            .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                            .Append(" SUM(A.AMOUNT) AS Amount ")

                        Case "Item Wise"
                            .Append(" A.EntryNo, ")
                            .Append(" A.CHALLANDATE As Date, ")
                            .Append(" B.ITEMNAME AS ItemName, ")
                            '.Append(" A.ItemCode, ")
                            .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                            .Append(" SUM(A.AMOUNT) AS Amount ")

                        Case "Loom+Item Wise"
                            .Append(" A.EntryNo, ")
                            .Append(" A.CHALLANDATE As Date, ")
                            .Append(" C.LoomNo, ")
                            .Append(" A.LOOMNOCODE, ")
                            .Append(" B.ITEMNAME AS ItemName, ")
                            .Append(" A.ItemCode, ")
                            .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                            .Append(" SUM(A.AMOUNT) AS Amount ")

                        Case Else
                            .Append(" A.EntryNo, ")
                            .Append(" A.CHALLANDATE As Date, ")
                            .Append(" B.ITEMNAME AS ItemName, ")
                            .Append(" C.LoomNo, ")
                            '.Append(" A.ItemCode, ")
                            .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                            .Append(" SUM(A.AMOUNT) AS Amount ")
                    End Select
                Else
                    If _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                '.Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Item Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")

                            Case "Loom+Item Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")

                            Case Else
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")
                        End Select
                    ElseIf _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" C.LoomNo, ")
                                .Append(" A.LOOMNOCODE, ")
                                '.Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Item Wise"
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Loom+Item Wise"
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                .Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case Else
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")
                        End Select
                    End If
                End If

                .Append(" FROM ( ")
                .Append(" SELECT A.CHALLANDATE, A.MTR_WEIGHT, A.AMOUNT, A.ITEMCODE, A.EntryNo, A.LOOMNOCODE ")
                .Append(" FROM TRNCHALLAN AS A WHERE 1=1 ")
                .Append(dateFilter)
                .Append(FilterString)
                .Append(" AND A.BOOKCODE='0001-000000155' ")
                .Append(" ) AS A ")
                .Append(" LEFT JOIN MSTSTOREITEM AS B ON A.ITEMCODE=B.ITEMCODE ")
                .Append(" LEFT JOIN MstLoomNo AS C ON A.LOOMNOCODE=C.LoomNoCode ")

                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    If _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    ElseIf _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE,C.LoomNo,B.ITEMNAME, A.ItemCode, A.CHALLANDATE, A.EntryNo")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,C.LoomNo, A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE,A.MTR_WEIGHT,A.AMOUNT ,A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,A.CHALLANDATE, A.EntryNo,C.LoomNo   ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    End If


                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            .Append(" GROUP BY C.LoomNo, A.CHALLANDATE , A.EntryNo")
                            .Append(" ORDER BY C.LoomNo, A.CHALLANDATE ")

                        Case "Item Wise"
                            .Append(" GROUP BY B.ItemName, A.ItemCode, A.CHALLANDATE, A.EntryNo ")
                            .Append(" ORDER BY B.ItemName, A.CHALLANDATE ")

                        Case "Loom+Item Wise"
                            .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.CHALLANDATE,A.LOOMNOCODE, A.EntryNo ")
                            .Append(" ORDER BY C.LoomNo, B.ItemName, A.CHALLANDATE ")

                        Case Else
                            .Append(" GROUP BY B.ItemName, C.LoomNo, A.ItemCode, A.CHALLANDATE, A.EntryNo ")
                            .Append(" ORDER BY B.ItemName, C.LoomNo, A.CHALLANDATE ")
                    End Select

                Else
                    If _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    ElseIf _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE,C.LoomNo,B.ITEMNAME, A.ItemCode, A.CHALLANDATE, A.EntryNo")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,C.LoomNo, A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE,A.MTR_WEIGHT,A.AMOUNT ,A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,A.CHALLANDATE, A.EntryNo,C.LoomNo   ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    End If
                End If

            End If


        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _NewTmptbl2 As New DataTable
        Zoom_Stock_Table.Clear()
        Zoom_Stock_Table = DefaltSoftTable.Copy
        _NewTmptbl2 = DefaltSoftTable.Copy
        Return _NewTmptbl2
    End Function
    Private Function _ZoomMonth_Load(ByRef _EnterStage As String, ByRef FilterString As String)
        Dim dateFilter = " AND A.CHALLANDATE >=  '" & txt_From.Date_for_Database & "' And A.CHALLANDATE <=  '" & txt_To.Date_for_Database & "'"
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            If _EnterStage = "FIRST" OrElse _EnterStage = "SECOND" Then
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    If _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Month+Loom Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                '.Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Month+Item Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")
                        End Select
                    End If
                Else
                    If _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Month+Loom Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.LOOMNOCODE, ")
                                '.Append(" A.ItemCode, ")
                                .Append(" SUM(A.MTR_WEIGHT) AS Qty, ")
                                .Append(" SUM(A.AMOUNT) AS Amount ")

                            Case "Month+Item Wise"
                                .Append(" A.EntryNo, ")
                                .Append(" A.CHALLANDATE As Date, ")
                                .Append(" C.LoomNo, ")
                                .Append(" B.ITEMNAME AS ItemName, ")
                                .Append(" A.ItemCode, ")
                                .Append(" A.MTR_WEIGHT AS Qty, ")
                                .Append(" A.AMOUNT AS Amount ")
                        End Select
                    End If
                End If

                .Append(" FROM ( ")
                .Append(" SELECT A.CHALLANDATE, A.MTR_WEIGHT, A.AMOUNT, A.ITEMCODE, A.EntryNo, A.LOOMNOCODE ")
                .Append(" FROM TRNCHALLAN AS A WHERE 1=1 ")
                .Append(dateFilter)
                '.Append(FilterString)
                .Append(" AND A.BOOKCODE='0001-000000155' ")
                .Append(" ) AS A ")
                .Append(" LEFT JOIN MSTSTOREITEM AS B ON A.ITEMCODE=B.ITEMCODE ")
                .Append(" LEFT JOIN MstLoomNo AS C ON A.LOOMNOCODE=C.LoomNoCode ")

                ' 🔹 yahan par C.LoomNo='0' condition safely lagai gayi hai
                '.Append(" WHERE ISNULL(C.LoomNo,'')='0' ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    If _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    ElseIf _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Month+Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE,C.LoomNo,B.ITEMNAME, A.ItemCode, A.CHALLANDATE, A.EntryNo")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Month+Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,C.LoomNo, A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE,A.MTR_WEIGHT,A.AMOUNT ,A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,A.CHALLANDATE, A.EntryNo,C.LoomNo   ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    End If

                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            .Append(" GROUP BY C.LoomNo, A.CHALLANDATE , A.EntryNo")
                            .Append(" ORDER BY C.LoomNo, A.CHALLANDATE ")

                        Case "Item Wise"
                            .Append(" GROUP BY B.ItemName, A.ItemCode, A.CHALLANDATE, A.EntryNo ")
                            .Append(" ORDER BY B.ItemName, A.CHALLANDATE ")

                        Case "Loom+Item Wise"
                            .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.CHALLANDATE,A.LOOMNOCODE, A.EntryNo ")
                            .Append(" ORDER BY C.LoomNo, B.ItemName, A.CHALLANDATE ")

                        Case Else
                            .Append(" GROUP BY B.ItemName, C.LoomNo, A.ItemCode, A.CHALLANDATE, A.EntryNo ")
                            .Append(" ORDER BY B.ItemName, C.LoomNo, A.CHALLANDATE ")
                    End Select

                Else
                    If _EnterStage = "FIRST" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    ElseIf _EnterStage = "SECOND" Then
                        Select Case Txt_ViewType.Text
                            Case "Loom Wise"
                                .Append(" GROUP BY C.LoomNo,A.LOOMNOCODE,C.LoomNo,B.ITEMNAME, A.ItemCode, A.CHALLANDATE, A.EntryNo")
                                .Append(" ORDER BY C.LoomNo ")

                            Case "Item Wise"
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,C.LoomNo, A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY B.ItemName ")

                            Case "Loom+Item Wise"
                                .Append(" GROUP BY C.LoomNo, B.ItemName, A.ItemCode, A.LOOMNOCODE,A.MTR_WEIGHT,A.AMOUNT ,A.CHALLANDATE, A.EntryNo ")
                                .Append(" ORDER BY C.LoomNo, B.ItemName ")

                            Case Else
                                .Append(" GROUP BY B.ItemName, A.ItemCode,A.MTR_WEIGHT,A.AMOUNT,A.CHALLANDATE, A.EntryNo,C.LoomNo   ")
                                .Append(" ORDER BY B.ItemName ")
                        End Select
                    End If
                End If
            End If
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        ' 🔹 Remove old view (BandedGridView)
        GridControl1.MainView = Nothing
        GridControl1.ViewCollection.Clear()

        ' 🔹 Reset existing FirstStage GridView (no need to create new)
        FirstStage = New GridView(GridControl1)
        GridControl1.MainView = FirstStage
        GridControl1.ViewCollection.Add(FirstStage)

        ' 🔹 Remove all existing columns (if any)
        FirstStage.Columns.Clear()

        ' 🔹 Clear any existing bands or layouts
        GridControl1.LevelTree.Nodes.Clear()
        FirstStage.OptionsView.ShowFooter = True
        Dim _NewTmptbl2 As New DataTable
        Zoom_Stock_Table.Clear()
        Zoom_Stock_Table = DefaltSoftTable.Copy
        _NewTmptbl2 = DefaltSoftTable.Copy
        Return _NewTmptbl2
    End Function

    Private Sub btn_xl_Click(sender As Object, e As EventArgs) Handles btn_xl.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
    Private Sub But_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Consumption Report"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Txt_ViewType_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_ViewType.KeyDown
        If e.KeyCode = Keys.Enter Then
            But_ok.Focus()
        End If
    End Sub

    Private Sub Txt_ViewType_GotFocus(sender As Object, e As EventArgs) Handles Txt_ViewType.GotFocus
        Txt_ViewType.DroppedDown = True
    End Sub

#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        _CommanFilterString = ""
        Dim FilterString As String = ""
        If e.KeyCode = Keys.Enter Then

            Dim ItemCode = ""
            Dim LOOMNOCODE = ""
            Dim LOOMNO = ""
            If NoOfstage = 1 Then
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            _StgIRowNo = FirstStage.FocusedRowHandle
                            LOOMNOCODE = " and LOOMNOCODE='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "LOOMNOCODE").ToString & "'"
                            FilterString = LOOMNOCODE
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                        Case "Item Wise"
                            _StgIRowNo = FirstStage.FocusedRowHandle
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            FilterString = ItemCode
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                        Case "Loom+Item Wise"
                            _StgIRowNo = FirstStage.FocusedRowHandle
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            LOOMNOCODE = " and LOOMNOCODE='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "LOOMNOCODE").ToString & "'"
                            FilterString = ItemCode & LOOMNOCODE
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                        Case "Month+Loom Wise"
                            Dim bandedView As BandedGridView = CType(GridControl1.MainView, BandedGridView)
                            Dim loomValue As String = bandedView.GetRowCellValue(bandedView.FocusedRowHandle, "LoomNo").ToString()
                            Dim loomValue1 As String = bandedView.GetRowCellValue(bandedView.FocusedRowHandle, "LOOMNOCODE").ToString()
                            Dim focusedColumn As BandedGridColumn = TryCast(bandedView.FocusedColumn, BandedGridColumn)
                            _StgIRowNo = bandedView.FocusedRowHandle
                            Dim focusedRowHandle As Integer = bandedView.FocusedRowHandle
                            Dim cellValue As Object = bandedView.GetRowCellValue(focusedRowHandle, focusedColumn)
                            Dim cellText As String = If(cellValue IsNot Nothing, cellValue.ToString().Trim(), "")
                            Dim afocusedColumn As DevExpress.XtraGrid.Columns.GridColumn = bandedView.FocusedColumn
                            If afocusedColumn IsNot Nothing Then
                                Dim parentBand As GridBand = focusedColumn.OwnerBand
                                If parentBand IsNot Nothing Then
                                    If parentBand.ParentBand IsNot Nothing Then
                                        parentBand = parentBand.ParentBand
                                    End If
                                    Dim parentBandCaption As String = parentBand.Caption
                                    Dim firstThreeLetters As String = parentBandCaption.Substring(0, Math.Min(3, parentBandCaption.Length))
                                    Dim monthList As New List(Of String) From {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                                    Dim cleanCaption As String = parentBandCaption.Trim().Replace(" ", "").ToLower()
                                    If focusedColumn IsNot Nothing AndAlso bandedView.Columns.Contains(focusedColumn) Then
                                        bandedView.FocusedColumn = focusedColumn
                                    ElseIf focusedColumn IsNot Nothing AndAlso bandedView.Columns(focusedColumn.FieldName) IsNot Nothing Then
                                        bandedView.FocusedColumn = bandedView.Columns(focusedColumn.FieldName)
                                    End If
                                    bandedView.MakeRowVisible(bandedView.FocusedRowHandle)
                                    bandedView.FocusedColumn.VisibleIndex = bandedView.FocusedColumn.VisibleIndex
                                    If monthList.Contains(firstThreeLetters) Then
                                        If loomValue1 <> "" AndAlso cellText <> "" Then
                                            FilterString = " and C.LoomNoCODE='" & loomValue1 & "' AND FORMAT(A.CHALLANDATE,'MMM') = '" & firstThreeLetters & "'"
                                            NoOfstage = 2
                                            _GetMonthWiseStockSecondStage(FilterString)
                                        End If
                                    Else
                                        FilterString = " and C.LoomNoCODE='" & loomValue1 & "'"
                                        NoOfstage = 2
                                        _GetMonthWiseStockSecondStage(FilterString)
                                    End If
                                End If
                            End If
                        Case "Month+Item Wise"
                            Dim bandedView As BandedGridView = CType(GridControl1.MainView, BandedGridView)
                            Dim Itemname As String = bandedView.GetRowCellValue(bandedView.FocusedRowHandle, "ItemName").ToString()
                            Dim Itemcode1 As String = bandedView.GetRowCellValue(bandedView.FocusedRowHandle, "ItemCode").ToString()
                            Dim focusedColumn As BandedGridColumn = TryCast(bandedView.FocusedColumn, BandedGridColumn)
                            Dim focusedRowHandle As Integer = bandedView.FocusedRowHandle
                            _StgIRowNo = bandedView.FocusedRowHandle

                            ' 🔹 Get current cell value
                            Dim cellValue As Object = bandedView.GetRowCellValue(focusedRowHandle, focusedColumn)
                            ' 🔹 Convert to string safely
                            Dim cellText As String = If(cellValue IsNot Nothing, cellValue.ToString().Trim(), "")
                            Dim parentBand As GridBand = focusedColumn.OwnerBand
                            ' 🔹 Agar aur ek level upar hai (multi-row band header), to le lo
                            If parentBand.ParentBand IsNot Nothing Then
                                parentBand = parentBand.ParentBand
                            End If
                            ' 🔹 Get band caption (first header row name)
                            Dim parentBandCaption As String = parentBand.Caption
                            Dim firstThreeLetters As String = ""
                            If parentBandCaption.Length >= 3 Then
                                firstThreeLetters = parentBandCaption.Substring(0, 3)   ' 👈 पहले 3 अक्षर
                            Else
                                firstThreeLetters = parentBandCaption                   ' अगर 3 से कम हैं तो पूरा नाम
                            End If
                            Dim monthList As New List(Of String) From {
    "Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
}
                            firstThreeLetters = parentBand.Caption.Substring(0, Math.Min(3, parentBand.Caption.Length))
                            Dim cleanCaption As String = parentBandCaption.Trim().Replace(" ", "").ToLower()
                            ' 🔹 Month list me check karo
                            If monthList.Contains(firstThreeLetters) Then
                                If Itemname <> "" AndAlso cellText <> "" Then
                                    'FilterString = " and B.ItemName='" & Itemname & "' AND FORMAT(A.CHALLANDATE,'MMM') = '" & firstThreeLetters & "'"
                                    FilterString = " and A.ItemCode='" & Itemcode1 & "' AND FORMAT(A.CHALLANDATE,'MMM') = '" & firstThreeLetters & "'"
                                    NoOfstage = 2
                                    _GetMonthWiseStockSecondStage(FilterString)
                                End If
                            Else
                                'FilterString = " and B.ItemName='" & Itemname & "'"
                                FilterString = " and A.ItemCode='" & Itemcode1 & "'"
                                NoOfstage = 2
                                _GetMonthWiseStockSecondStage(FilterString)
                            End If

                        Case Else
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            FilterString = ItemCode
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                    End Select
                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            FilterString = ItemCode
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                        Case "Item Wise"
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            FilterString = ItemCode
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                        Case "Loom+Item Wise"
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            FilterString = ItemCode
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                        Case "Month+Loom Wise"

                        Case "Month+Item Wise"

                        Case Else
                            ItemCode = " and ItemCode='" & FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString & "'"
                            FilterString = ItemCode
                            NoOfstage = 2
                            _GetBeamWiseStockSecondStage(FilterString)
                    End Select
                End If
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            If NoOfstage = 2 Then
                NoOfstage = 1
                '_GetBeamWiseStockFirstStage(FilterString)
                Select Case Txt_ViewType.Text
                    Case "Month+Loom Wise", "Month+Item Wise"
                        ' 👉 अगर month-wise view में थे
                        '_GetMonthWiseStockSecondStage(FilterString)
                        'Dim _TmpTbl As New DataTable
                        '_TmpTbl = _Zooming_Load(txt_To.Date_for_Database, "FIRST", "")
                        Stock_Zooming_Load(_TmpMonthwiseTbl)
                    Case Else
                        ' 👉 बाकी सभी cases में normal first stage load
                        _GetBeamWiseStockFirstStage(FilterString)
                End Select
            End If
        End If
    End Sub
    Private Sub _GetMonthWiseStockSecondStage(ByVal FilterString As String)
        Try
            Dim _TmpTbl As New DataTable
            _TmpTbl = _ZoomMonth_Load("SECOND", FilterString)
            'Dim _ActivatedColName As String = ""
            'If FirstStage IsNot Nothing AndAlso FirstStage.FocusedColumn IsNot Nothing Then
            '    _ActivatedColName = FirstStage.FocusedColumn.FieldName
            'End If
            If _TmpTbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else

                FirstStage.Columns.Clear()
                GridControl1.DataSource = _TmpTbl.Copy

                DevGridFitColumnWiotScroll(GridControl1, FirstStage)
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Qty",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Qty")
            })
                End If
                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Amount",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Amount")
            })
                End If
                FirstStage.Appearance.FocusedRow.BackColor = FirstStage.Appearance.FocusedRow.BackColor.LightBlue
                FirstStage.Appearance.FocusedRow.BackColor = Color.LightBlue
                If FirstStage.Columns.ColumnByFieldName("EntryNo") IsNot Nothing Then
                    FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    FirstStage.Columns("EntryNo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                End If
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    FirstStage.Columns("Qty").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    FirstStage.Columns("Amount").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Month+Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Month+Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False
                    End Select
                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            'FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False

                    End Select
                End If
                FirstStage.OptionsBehavior.Editable = False

                GridControl1.Visible = True
                GridControl1.BringToFront()

                FirstStage.FocusedRowHandle = _StgIRowNo
                FirstStage.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _GetBeamWiseStockSecondStage(ByVal FilterString As String)
        Try

            Dim _TmpTbl As New DataTable
            _TmpTbl = _SummaryMonth_Load("SECOND", FilterString)
            Dim _ActivatedColName As String = ""
            If FirstStage IsNot Nothing AndAlso FirstStage.FocusedColumn IsNot Nothing Then
                _ActivatedColName = FirstStage.FocusedColumn.FieldName
            End If
            If _TmpTbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else

                FirstStage.Columns.Clear()
                GridControl1.DataSource = _TmpTbl.Copy

                DevGridFitColumnWiotScroll(GridControl1, FirstStage)
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Qty",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Qty")
            })
                End If
                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Amount",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Amount")
            })
                End If
                FirstStage.Appearance.FocusedRow.BackColor = FirstStage.Appearance.FocusedRow.BackColor.LightBlue
                FirstStage.Appearance.FocusedRow.BackColor = Color.LightBlue
                If FirstStage.Columns.ColumnByFieldName("EntryNo") IsNot Nothing Then
                    FirstStage.Columns("EntryNo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    FirstStage.Columns("EntryNo").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                End If
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    FirstStage.Columns("Qty").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If

                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    FirstStage.Columns("Amount").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End If
                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Month+Loom Wise"

                        Case "Month+Item Wise"

                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False
                    End Select
                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            'FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False

                    End Select
                End If

                GridControl1.Visible = True
                GridControl1.BringToFront()
                FirstStage.Focus()
                FirstStage.FocusedRowHandle = _StgIRowNo
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub _GetBeamWiseStockFirstStage(ByVal FilterString As String)
        Try

            Dim _TmpTbl As New DataTable
            _TmpTbl = _SummaryMonth_Load("FIRST", FilterString)

            If _TmpTbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else

                FirstStage.Columns.Clear()
                GridControl1.DataSource = _TmpTbl.Copy

                Dim _ActivatedColName As String = ""
                If FirstStage IsNot Nothing AndAlso FirstStage.FocusedColumn IsNot Nothing Then
                    _ActivatedColName = FirstStage.FocusedColumn.FieldName
                End If

                DevGridFitColumnWiotScroll(GridControl1, FirstStage)
                If FirstStage.Columns.ColumnByFieldName("Qty") IsNot Nothing Then
                    FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Qty",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Qty")
            })
                End If
                If FirstStage.Columns.ColumnByFieldName("Amount") IsNot Nothing Then
                    FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}"))
                    FirstStage.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {
                .FieldName = "Amount",
                .SummaryType = DevExpress.Data.SummaryItemType.Sum,
                .ShowInGroupColumnFooter = FirstStage.Columns("Amount")
            })
                End If
                FirstStage.Appearance.FocusedRow.BackColor = FirstStage.Appearance.FocusedRow.BackColor.LightBlue
                FirstStage.Appearance.FocusedRow.BackColor = Color.LightBlue

                If Txt_ProcessStockDisplay.Text = "SUMMARY" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False
                    End Select
                ElseIf Txt_ProcessStockDisplay.Text = "DETAIL" Then
                    Select Case Txt_ViewType.Text
                        Case "Loom Wise"
                            FirstStage.Columns("LOOMNOCODE").Visible = False
                        Case "Item Wise"
                            FirstStage.Columns("ItemCode").Visible = False
                        Case "Loom+Item Wise"
                            'FirstStage.Columns("LOOMNOCODE").Visible = False
                            FirstStage.Columns("ItemCode").Visible = False
                        Case Else
                            FirstStage.Columns("ItemCode").Visible = False

                    End Select
                End If
                GridControl1.Visible = True
                GridControl1.BringToFront()

                FirstStage.FocusedRowHandle = _StgIRowNo
                FirstStage.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


#End Region


End Class