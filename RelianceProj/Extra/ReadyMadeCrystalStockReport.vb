Imports System.Text
Imports DevExpress.XtraPivotGrid

Friend Class ReadyMadeCrystalStockReport

    Dim _Selectionbutton As String

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub ReadyMadeCrystalStockReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        _ButtonEnable(True)
        _TextboxEnable(False)

    End Sub

    Private Sub _ButtonEnable(ByVal _GetEnable As Boolean)
        BtnItem.Enabled = _GetEnable
        BtnSIC.Enabled = _GetEnable
        BtnIC.Enabled = _GetEnable
    End Sub
    Private Sub _TextboxEnable(ByVal _GetEnable As Boolean)
        Txt_ProcessStockDisplay.Enabled = _GetEnable
        But_ok.Enabled = _GetEnable
        Txt_ProcessStockDisplay.Focus()
        Txt_ProcessStockDisplay.SelectAll()
    End Sub

    Private Sub _ButtonFocus()
        If _Selectionbutton = "Item Wise" Then
            BtnItem.Focus()
        ElseIf _Selectionbutton = "Item+Color Wise" Then
            BtnIC.Focus()
        ElseIf _Selectionbutton = "Item+SubItem+Color Wise" Then
            BtnSIC.Focus()
        End If
    End Sub
    Private Sub View_Log_Book()
        Try


            Dim View_Filter_Condition As String = ""
            Dim View_Order_By As String = ""
            Dim View_Query As String = ""
            Dim filterQuery As String = ""
            Dim selectExtraCols As String = ""
            Dim orderByQuery As String = ""
            Dim tempgrouping As String = ""
            Dim filteritemCode As String = ""
            If _Selectionbutton = "Item Wise" Then
                obj_Party_Selection.MULTY_storeItem_SELECTION("")
                If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                    Exit Sub
                End If
                filteritemCode = " AND Z.ITEMCODE IN " & MULTY_SELECTION_COLOUM_3_DATA
                selectExtraCols = " Z.ItemName, "
                tempgrouping = " GROUP BY Z.ItemName "
                orderByQuery = " ORDER BY Z.ItemName "

            ElseIf _Selectionbutton = "Item+Color Wise" Then
                obj_Party_Selection.MULTY_storeItem_SELECTION("")
                If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                    Exit Sub
                End If
                filteritemCode = " AND Z.ITEMCODE IN " & MULTY_SELECTION_COLOUM_3_DATA

                obj_Party_Selection.Multy_Color_Selection("")
                If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                    Exit Sub
                End If
                filteritemCode &= " AND Z.COLORCODE IN " & MULTY_SELECTION_COLOUM_3_DATA

                selectExtraCols = " Z.ItemName, Z.ColorName, "
                tempgrouping = " GROUP BY Z.ItemName, Z.ColorName "
                orderByQuery = " ORDER BY Z.ItemName, Z.ColorName "

            ElseIf _Selectionbutton = "Item+SubItem+Color Wise" Then
                obj_Party_Selection.MULTY_storeItem_SELECTION("")
                If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                    Exit Sub
                End If
                filteritemCode = " AND Z.ITEMCODE IN " & MULTY_SELECTION_COLOUM_3_DATA

                obj_Party_Selection.Multy_SubItem_Selection()
                If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                    Exit Sub
                End If
                filteritemCode &= " AND Z.SUBITEMCODE IN " & MULTY_SELECTION_COLOUM_3_DATA

                obj_Party_Selection.Multy_Color_Selection("")
                If MULTY_SELECTION_COLOUM_3_DATA = "" Then
                    Exit Sub
                End If
                filteritemCode &= " AND Z.COLORCODE IN " & MULTY_SELECTION_COLOUM_3_DATA

                selectExtraCols = " Z.ItemName, Z.SubItemName, Z.ColorName, "
                tempgrouping = " GROUP BY Z.ItemName, Z.SubItemName, Z.ColorName "
                orderByQuery = " ORDER BY Z.ItemName, Z.SubItemName, Z.ColorName "
            End If
            _strQuery = New StringBuilder()
            With _strQuery
                .Append("SELECT ")
                .Append(selectExtraCols)
                .Append("ISNULL(SUM(Z.[28]),0) AS [28], ")
                .Append("ISNULL(SUM(Z.[30]),0) AS [30], ")
                .Append("ISNULL(SUM(Z.[32]),0) AS [32], ")
                .Append("ISNULL(SUM(Z.[34]),0) AS [34], ")
                .Append("ISNULL(SUM(Z.[36]),0) AS [36], ")
                .Append("ISNULL(SUM(Z.[38]),0) AS [38], ")
                .Append("ISNULL(SUM(Z.[40]),0) AS [40], ")
                .Append("ISNULL(SUM(Z.[42]),0) AS [42], ")
                .Append("ISNULL(SUM(Z.[44]),0) AS [44], ")
                .Append("ISNULL(SUM(Z.[46]),0) AS [46], ")
                .Append("ISNULL(SUM(Z.[48]),0) AS [48], ")
                .Append("ISNULL(SUM(Z.[50]),0) AS [50], ")
                .Append("ISNULL(SUM(Z.[S]),0) AS [S], ")
                .Append("ISNULL(SUM(Z.[M]),0) AS [M], ")
                .Append("ISNULL(SUM(Z.[L]),0) AS [L], ")
                .Append("ISNULL(SUM(Z.[XL]),0) AS [XL], ")
                .Append("ISNULL(SUM(Z.[XXL]),0) AS [XXL], ")
                .Append("ISNULL(SUM(Z.[3XL]),0) AS [3XL], ")
                .Append("ISNULL(SUM(Z.[4XL]),0) AS [4XL], ")
                .Append("ISNULL(SUM(Z.[5XL]),0) AS [5XL], ")
                .Append("ISNULL(SUM(Z.[6XL]),0) AS [6XL], ")
                .Append(" ISNULL(SUM(Z.[28]),0) + ISNULL(SUM(Z.[30]),0) + ISNULL(SUM(Z.[32]),0) + ISNULL(SUM(Z.[34]),0) + ")
                .Append(" ISNULL(SUM(Z.[36]),0) + ISNULL(SUM(Z.[38]),0) + ISNULL(SUM(Z.[40]),0) + ISNULL(SUM(Z.[42]),0) + ")
                .Append(" ISNULL(SUM(Z.[44]),0) + ISNULL(SUM(Z.[46]),0) + ISNULL(SUM(Z.[48]),0) + ISNULL(SUM(Z.[50]),0) + ")
                .Append(" ISNULL(SUM(Z.[S]),0) + ISNULL(SUM(Z.[M]),0) + ISNULL(SUM(Z.[L]),0) + ISNULL(SUM(Z.[XL]),0) + ")
                .Append(" ISNULL(SUM(Z.[XXL]),0) + ISNULL(SUM(Z.[3XL]),0) + ISNULL(SUM(Z.[4XL]),0) + ISNULL(SUM(Z.[5XL]),0) + ISNULL(SUM(Z.[6XL]),0) AS Total ")
                .Append("FROM ( ")
                .Append("SELECT * FROM ( ")
                .Append("SELECT D.ItemName, C.ColorName, H.SubItemName, B.SizeName, (Z.InQty)-(Z.OutQty) AS PCS,Z.ITEMCODE, Z.SUBITEMCODE, Z.SIZECODE, Z.COLORCODE ")
                .Append("FROM( ")
                .Append("SELECT Z.ITEMCODE, Z.SUBITEMCODE, Z.SIZECODE, Z.COLORCODE, Z.TYPECODE, Z.StringBarcode, ISNULL(Z.Barcode,0) AS Barcode, ")
                .Append("(Z.InQty) AS InQty, (Z.OutQty) AS OutQty, (Z.InQty)-(Z.OutQty) AS Balance ")
                .Append("FROM( ")
                .Append("SELECT A.ITEMCODE, IIF(B.NATURE IN ('JOB-RCPT','JOB-PAID'),A.CUTCODE,A.SHADECODE) AS SUBITEMCODE, ")
                .Append("A.DESIGNCODE AS SIZECODE, A.CUTCODE1 AS COLORCODE, A.SAMPLE_IN_CASE AS TYPECODE, ")
                .Append("A.BarCode_LumpNo AS StringBarcode, A.BarCode_LumpNo AS Barcode, A.PCS AS InQty, 0.00 AS OutQty ")
                .Append("FROM TrnPackingSlip AS A LEFT JOIN MstBook AS B ON A.BOOKCODE = B.BOOKCODE ")
                .Append("WHERE B.NATURE IN ('JOB-RCPT','PURCHASE','SALES G.R.','JOB-PAID') AND B.BEHAVIOUR IN ('READYMADE') ")
                .Append("UNION ALL ")
                .Append("SELECT A.ITEMCODE, A.SHADECODE AS SUBITEMCODE, A.DESIGNCODE AS SIZECODE, A.CUTCODE1 AS COLORCODE, A.SAMPLE_IN_CASE AS TYPECODE, ")
                .Append("A.BarCode_LumpNo AS StringBarcode, A.BarCode_LumpNo AS Barcode, 0.00 AS InQty, A.PCS AS OutQty ")
                .Append("FROM TrnPackingSlip AS A LEFT JOIN MstBook AS B ON A.BOOKCODE = B.BOOKCODE ")
                .Append("WHERE B.NATURE IN ('SALES','PURCHASE G.R.') AND B.BEHAVIOUR IN ('READYMADE') ")
                .Append(") AS Z ")
                .Append("UNION ALL ")
                .Append("SELECT Z.ITEMCODE, Z.SUBITEMCODE, Z.SIZECODE, Z.COLORCODE, '0000-000000001' AS TYPECODE, ")
                .Append("ISNULL(Z.BarCode_LumpNo,0) AS StringBarcode, ISNULL(Z.BarCode_LumpNo,0) AS Barcode, (Z.InQty) AS InQty, (Z.OutQty) AS OutQty, (Z.InQty)-(Z.OutQty) AS Balance ")
                .Append("FROM( ")
                .Append("SELECT A.ITEMCODE, A.PROCESSCODE AS SUBITEMCODE, A.DESIGNCODE AS SIZECODE, A.SHADECODE AS COLORCODE, A.OFFERENTRYNO AS BarCode_LumpNo, ")
                .Append("A.MTR_WEIGHT AS InQty, 0.00 AS OutQty ")
                .Append("FROM trnInvoiceDetail AS A LEFT JOIN MstBook AS B ON A.BOOKCODE = B.BOOKCODE ")
                .Append("WHERE B.NATURE IN ('RCPT') AND B.BEHAVIOUR IN ('OPENING-GENRAL-STOCK') ")
                .Append(") AS Z ")
                .Append(") AS Z ")
                .Append("LEFT JOIN MSTSIZE B ON Z.SizeCode = B.SizeCode ")
                .Append("LEFT JOIN MstColor C ON Z.ColorCode = C.ColorCode ")
                .Append("LEFT JOIN MstStoreItem D ON Z.ITEMCODE = D.ItemCode ")
                .Append("LEFT JOIN MstStoreItemGroup M ON D.ItemGroupCode = M.GroupCode ")
                .Append("LEFT JOIN MstStoreSubItem H ON Z.SubItemCode = H.SubItemCode ")
                .Append(") d PIVOT (SUM(PCS) FOR SizeName IN ([28],[30],[32],[34],[36],[38],[40],[42],[44],[46],[48],[50],[S],[M],[L],[XL],[XXL],[3XL],[4XL],[5XL],[6XL])) piv ")
                .Append(") AS Z ")
                .Append(" where 1=1 ")
                .Append(filteritemCode)
                .Append(tempgrouping)
                If Txt_ProcessStockDisplay.Text <> "ALL" Then
                    .Append(" HAVING ")
                    .Append(" ISNULL(SUM(Z.[28]),0) + ISNULL(SUM(Z.[30]),0) + ISNULL(SUM(Z.[32]),0) + ISNULL(SUM(Z.[34]),0) + ")
                    .Append(" ISNULL(SUM(Z.[36]),0) + ISNULL(SUM(Z.[38]),0) + ISNULL(SUM(Z.[40]),0) + ISNULL(SUM(Z.[42]),0) + ")
                    .Append(" ISNULL(SUM(Z.[44]),0) + ISNULL(SUM(Z.[46]),0) + ISNULL(SUM(Z.[48]),0) + ISNULL(SUM(Z.[50]),0) + ")
                    .Append(" ISNULL(SUM(Z.[S]),0) + ISNULL(SUM(Z.[M]),0) + ISNULL(SUM(Z.[L]),0) + ISNULL(SUM(Z.[XL]),0) + ")
                    .Append(" ISNULL(SUM(Z.[XXL]),0) + ISNULL(SUM(Z.[3XL]),0) + ISNULL(SUM(Z.[4XL]),0) + ISNULL(SUM(Z.[5XL]),0) + ISNULL(SUM(Z.[6XL]),0) > 0 ")
                End If
                .Append(orderByQuery)
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim Tmp_Data_Table As New DataTable
            Tmp_Data_Table = DefaltSoftTable.Copy

            If Tmp_Data_Table.Rows.Count > 0 Then

                'Dim Date_Range = "Audit Report  From : " & txt_From.Text & " TO " & txt_To.Text
                Dim RptTitle = "ReadyMade Stock Report"
                Dim Date_Range = ""
                NewReportPrint(Tmp_Data_Table, RptTitle, Date_Range)
                _ButtonEnable(True)
                _TextboxEnable(False)
                _ButtonFocus()
            Else
                MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                _ButtonEnable(True)
                _TextboxEnable(False)
                _ButtonFocus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ReadyMadeCrystalStockReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        '    If e.KeyCode = Keys.Escape Then
        '        Dim result As DialogResult = MessageBox.Show(
        '"Do you really want to close?",
        '"Confirm Close",
        'MessageBoxButtons.YesNo,
        'MessageBoxIcon.Question
        ')

        '        If result = DialogResult.Yes Then
        '            Me.Close()   ' YES → close form
        '        End If
        '        ' NO → do nothing
        '    End If
    End Sub

    Private Sub BtnItem_Click(sender As Object, e As EventArgs) Handles BtnItem.Click
        _Selectionbutton = "Item Wise"
        REPORT_RPT_FILE_NAME = "ReadyMadeStockReport_1"
        _TextboxEnable(True)
    End Sub

    Private Sub BtnIC_Click(sender As Object, e As EventArgs) Handles BtnIC.Click
        _Selectionbutton = "Item+Color Wise"
        REPORT_RPT_FILE_NAME = "ReadyMadeStockReport_2"
        _TextboxEnable(True)
    End Sub

    Private Sub BtnSIC_Click(sender As Object, e As EventArgs) Handles BtnSIC.Click
        _Selectionbutton = "Item+SubItem+Color Wise"
        REPORT_RPT_FILE_NAME = "ReadyMadeStockReport_3"
        _TextboxEnable(True)
    End Sub

    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub
End Class