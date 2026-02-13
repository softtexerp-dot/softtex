Imports System.Text
Imports DevExpress.XtraGrid

Public Class StockBlankRateupdate
    Dim _BookCode As String = ""
    Dim Item_Code As String = ""



    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub

    Private Sub txtBookName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBookName.KeyDown
        If e.KeyCode = Keys.Enter Then
            BOOK_BHEWAR = ""
            BOOK_CATGER = "A.BOOKCATEGORY='PACKING SLIP' AND ( A.BEHAVIOUR ='FACTORY' OR A.BEHAVIOUR = 'GENERAL') AND A.BookTrType NOT IN('P0155','P0201','P0200','P0152','P0151','P0148')"
            BOOK_BHEWAR = "chq_printing"
            obj_Party_Selection.BOOK_SELECTION_FORM_NAME()
            If MULTY_SELECTION_COLOUM_3_DATA <> "" Then
                txtBookName.Text = MULTY_SELECTION_COLOUM_1_DATA
                txtBookName.ReadOnly = True
                _BookCode = MULTY_SELECTION_COLOUM_3_DATA
                btnView.Focus()
            End If
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        View_Record()
    End Sub
    Private Sub View_Record()
        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""
        View_Filter_Condition = " AND  A.BOOKCODE='" & _BookCode & "' And A.Net_Rate=0 "
        View_Order_By = " ORDER BY  A.CHALLANDATE,( A.ENTRYNO), A.SRNO "

        Dim Offer_Field_String As String = ""

        Dim strQuery = New StringBuilder
        With strQuery
            .Append(" SELECT ")
            .Append("  A.BookVno, ")
            .Append("  A.ENTRYNO as [Entry No], ")
            .Append("  A.challanno as [Challan No], ")
            .Append(" FORMAT( A.challandate,'dd/MM/yyyy') AS [Challan Date], ")
            .Append(" A.ItemCode, ")
            .Append(" MstMasterAccount.accountname as [Party Name], ")
            .Append("  A.SRNO as [Sno], ")
            .Append(" MSTSTOREITEMGROUP.GROUPNAME AS [Group Name], ")
            .Append(" A.OP11 AS Barcode, ")
            .Append(" MSTSTOREITEM.PartNo, ")
            .Append(" MSTSTOREITEM.ITEMNAME as [Item Name], ")
            .Append(" K.subItemName  AS [Sub Item], ")
            .Append(" A.REPAIR_GROUP_BY_ID AS Size, ")
            .Append(" F.ColorName AS Color,  ")
            .Append(" a.LOAN_GROUP_BY_ID AS Location, ")
            .Append(" FORMAT( A.Mtr_Weight,'0.000') as [Quantity], ")
            .Append(" MstCutMaster.cutname as [Unit], ")
            .Append(" FORMAT( A.GROSS_RATE,'0.00') as [Gross Rate], ")
            .Append("  A.RATE_DIS_PER as [Discount %],")
            .Append("  A.TAX_PER as [Tax %],")
            .Append("  A.NET_RATE as [Net Rate],")
            .Append("  A.AMOUNT as [Amount],")
            .Append(" MstTransport.TransportName as [Transport], ")
            .Append(" C.accountname as [Agent Name], ")
            .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
            .Append("  A.HeaderRemark as [Remark] ")
            .Append(" FROM      ")
            .Append(" TrnChallan as A        ")
            .Append(" LEFT JOIN MSTSTOREITEMGROUP ON A.ITEMGROUPCODE=MSTSTOREITEMGROUP.GROUPCODE ")
            .Append(" LEFT JOIN MstMasterAccount ON A.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
            .Append(" LEFT JOIN MSTTRANSPORT ON A.TRANSPORTCODE=MSTTRANSPORT.ID ")
            .Append(" LEFT JOIN MSTSTOREITEM ON A.ITEMCODE=MSTSTOREITEM.ITEMCODE ")
            .Append(" LEFT JOIN MstMasterAccount AS C ON  MstMasterAccount.AGENTCODE=C.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Acof_Supply ON A.ACOFCODE=Mst_Acof_Supply.ID ")
            .Append(" LEFT JOIN MstCutMaster  ON A.CUTCODE=MstCutMaster.ID ")
            .Append(" LEFT JOIN MstStoreSubItem K  ON  A.Repairing_Issue_ID = K.subItemCode ")
            .Append(" LEFT JOIN MstColor F  ON  A.Loan_Paid_ID=F.COLORCODE ")
            .Append(" WHERE 1=1 ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With


        sqL = strQuery.ToString
        sql_connect_slect()

        FirstStage.Columns.Clear()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then

            GridControl1.DataSource = tblTmp

            FirstStage.Columns(0).Visible = False

            FirstStage.Appearance.Row.Font = New Font("Verdana", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Verdana", 8, FontStyle.Bold)


            FirstStage.GroupRowHeight = 30
            FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Quantity").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Quantity").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Amount").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Net Rate").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            FirstStage.Columns("Quantity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0}"))
            FirstStage.Columns("Amount").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0}"))


            AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
            'PNL_View.Visible = True
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            'PNL_View.BringToFront()
            GridControl1.BringToFront()
            'Grid every column not editable mode
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In FirstStage.Columns
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
            Next
            'Column Hide 
            For i As Integer = 0 To tblTmp.Rows.Count - 1
                If Not IsDBNull(tblTmp.Rows(i)("ItemCode")) Then
                    Item_Code = tblTmp.Rows(i)("ItemCode").ToString()
                End If
            Next

            FirstStage.Columns("ItemCode").Visible = False
            FirstStage.Columns("Sno").Visible = False
            FirstStage.Columns("Group Name").Visible = False
            FirstStage.Columns("Sub Item").Visible = False
            FirstStage.Columns("Size").Visible = False
            FirstStage.Columns("Color").Visible = False
            FirstStage.Columns("Unit").Visible = False
            FirstStage.Columns("Gross Rate").Visible = False
            FirstStage.Columns("Discount %").Visible = False
            FirstStage.Columns("Tax %").Visible = False
            FirstStage.Columns("Amount").Visible = False
            FirstStage.Columns("Transport").Visible = False
            FirstStage.Columns("Agent Name").Visible = False
            FirstStage.Columns("A/c Of Name").Visible = False
            FirstStage.Columns("Remark").Visible = False
            FirstStage.Columns("Barcode").Visible = False
            'Column Editable Mode
            With FirstStage.Columns("Net Rate")
                .OptionsColumn.AllowEdit = True
                .OptionsColumn.ReadOnly = False
            End With
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            txtBookName.Focus()
        End If

    End Sub


    Private Sub View_RecordOldTransaction(ByVal _itemcode As String)
        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""

        Dim Offer_Field_String As String = ""

        Dim sb As New StringBuilder()
        sb.Append("SELECT ")
        sb.Append("A.CHALLANNO AS [Chl-No], ")
        sb.Append("CONVERT(VARCHAR(10), A.CHALLANDATE, 103) AS [Date], ")
        sb.Append(" D.ITEMNAME as [Item Name], ")
        sb.Append("FORMAT(A.MTR_WEIGHT, 'N3') AS [Quantity], ")
        sb.Append("FORMAT(A.GROSS_RATE, 'N2') AS [Gross Rate], ")
        sb.Append("B.ACCOUNTNAME AS [Party Name] ")
        sb.Append("FROM trnchallan AS A ")
        sb.Append("LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE = B.ACCOUNTCODE ")
        sb.Append("LEFT JOIN MstBook AS C ON A.BOOKCODE = C.BOOKCODE ")
        sb.Append(" LEFT JOIN MSTSTOREITEM  as D ON A.ITEMCODE=D.ITEMCODE ")
        sb.Append("WHERE 1=1 ")
        sb.Append(" AND A.ITEMCODE = '" & _itemcode & "' ")
        sb.Append(" AND C.BOOKCATEGORY='PACKING SLIP'  ")
        sb.Append(" AND C.RCPT_ISSUE='RCPT'  ")
        sb.Append(" AND A.GROSS_RATE >0  ")
        sb.Append("ORDER BY A.CHALLANDATE DESC")
        sqL = sb.ToString()
        sql_connect_slect()

        GridView1.Columns.Clear()
        Dim tblTmpOld As New DataTable
        tblTmpOld = DefaltSoftTable.Copy

        GridControl2.BringToFront()
        If tblTmpOld.Rows.Count > 0 Then
            GridControl2.DataSource = tblTmpOld
        End If

        GridView1.Appearance.Row.Font = New Font("Verdana", 8, FontStyle.Bold)
        GridView1.Appearance.HeaderPanel.Font = New Font("Verdana", 8, FontStyle.Bold)
        GridView1.GroupRowHeight = 30
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridView1.Columns
            col.OptionsColumn.AllowEdit = False
            col.OptionsColumn.ReadOnly = True
        Next
        GridView1.BestFitColumns()
        GridView1.Focus()
    End Sub

    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        'gridView.Columns(CStr(("Bale No"))).Group()

        'Enable this option to move group footer summaries to group rows under corresponding column headers
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        'Create group summary
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Quantity", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Quantity")})
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Amount", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Amount")})
        gridView.Appearance.GroupRow.BackColor = Color.LightGreen
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        savedata()
    End Sub
    Private Sub savedata()
        Wait_Window_Show(Me, "Stock Update Please Wait...")
        FirstStage.ActiveFilter.Clear()

        Dim prevItemName As String = ""
        Dim askOnce As Boolean = False
        Dim updateAllSame As Boolean = False
        For i As Integer = 0 To FirstStage.RowCount - 1
            Dim _RateCheck As Double = 0
            _RateCheck = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "Net Rate")), 0, FirstStage.GetRowCellValue(i, "Net Rate")))
            If _RateCheck > 0 Then

                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" UPDATE TrnChallan SET ")
                    .Append(" NET_RATE='" & FirstStage.GetRowCellValue(i, "Net Rate").ToString & "'")
                    .Append(" ,GROSS_RATE='" & FirstStage.GetRowCellValue(i, "Net Rate").ToString & "'")
                    .Append("  WHERE 1=1 ")
                    .Append("  and BOOKVNO='" & FirstStage.GetRowCellValue(i, "BookVno").ToString & "'")
                    .Append("  and OP11='" & FirstStage.GetRowCellValue(i, "Barcode").ToString & "'")
                    .Append("  and ItemCode='" & FirstStage.GetRowCellValue(i, "ItemCode").ToString & "'")
                End With
                sqL = _strQuery.ToString
                sql_Data_Save_Delete_Update()
            End If
        Next
        MsgBox("Record Successfully Update", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        Wait_Window_Hide()
        'FirstStage.Columns.Clear()
    End Sub

    Private Sub StockBlankRateupdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(0, 0)
        txtBookName.Focus()
        AttachButtonFocusEvents(Me)
    End Sub

    Private Sub StockBlankRateupdate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Do You Want To Exit?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim _RptTiltle = "Stock Blank Rate Update Report"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub Btn_close_Click(sender As Object, e As EventArgs) Handles Btn_close.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub FirstStage_ShownEditor(sender As Object, e As EventArgs) Handles FirstStage.ShownEditor
        AddHandler FirstStage.ActiveEditor.KeyDown, AddressOf ActiveEditor_KeyDown
    End Sub

    Private Sub ActiveEditor_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            FirstStage.CloseEditor()
            FirstStage.UpdateCurrentRow()
            e.Handled = True
            Dim result As DialogResult = MessageBox.Show("Same Item Name detected." & vbCrLf & "Do you want to update Net Rate for same items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Dim _Itemcode = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString()
                Dim NetRate As Double = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Net Rate").ToString()

                For i As Integer = 0 To FirstStage.RowCount - 1
                    Dim _RowItemcode = FirstStage.GetRowCellValue(i, "ItemCode").ToString()
                    If _RowItemcode = _Itemcode Then
                        Dim _RateCheck = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "Net Rate")), 0, FirstStage.GetRowCellValue(i, "Net Rate")))
                        If _RateCheck = 0 Then
                            FirstStage.SetRowCellValue(i, "Net Rate", NetRate)
                        End If
                    End If

                Next
            End If

        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        Dim _Itemcode As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString()
        View_RecordOldTransaction(_Itemcode)
    End Sub
End Class