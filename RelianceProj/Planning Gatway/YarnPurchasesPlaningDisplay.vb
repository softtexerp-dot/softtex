Imports DevExpress.CodeParser
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Text

Public Class YarnPurchasesPlaningDisplay
    Dim _MainTblYarn As DataTable
    Dim _SlecteedCountCode As String = ""

#Region "GRID STRING BUILDER VARIABLE"
    Private Offer_Calc_By As String
    Private _GridColNames As New StringBuilder
    Private _GridColType As New StringBuilder
    Private _GridColValidate As New StringBuilder
    Private _GridCol_FocusByPass As New StringBuilder
    Private _FieldDefaultValues As New StringBuilder
    Private _FieldHeader As New StringBuilder
    Private _FieldHeaderAlignment As New StringBuilder
    Private _FieldNotRequiredForSave As New StringBuilder
    Private _FieldNotVisibile As New StringBuilder
    Private _FieldWidthSet As New StringBuilder
    Private _FieldLocked As New StringBuilder
    Private _FieldMasking As New StringBuilder
    Private _FieldAlignMent As New StringBuilder
    Private _ExtraFieldDataTable As New StringBuilder
    Private _ExtraField_Values_DataTable As New StringBuilder
    Private _ExtraFieldOthers As New StringBuilder
    Private _ExtraField_Values_Others As New StringBuilder
    Private _FieldNameSameValueCopy As New StringBuilder
    Private _FieldNameForTotal As New StringBuilder
#End Region

#Region "GRID GENERAL VARIABLE"
    Private Grid_Table_ColNames() As String
    Private _FindColIndex As Integer = 0
    Private _ColTotal As Double = 0
    Private _AutoIDField As String = "SRNO"
    Private _RecordsKeyFieldName As String = "ID"
    Private _FocusFields() As String
    Private _DataTableGrid As New DataTable
    Private _DefaultColOfGrid As Integer = 0
    Private _GridRowNo As Integer = 0
    Private _ReturnColNumber As Integer = -1
    Private _ActivatedColName As String = ""
    Private _RowNo As Integer = 0
    Private _ColNo As Integer = 0
    Private _GridLastColNo As Integer = 0
    Private _LastRow As Integer = 0
    Private _Last_Saved_Entry_No As Integer = 0
    Public _isCallerByOther As Boolean = False
    Private _old_Me_text As String = ""
    Private Last_Focused_Btn As String = ""
    Private _AllowMoveFromCell As Boolean = True
    Private WithEvents Txt_Dt As New ctl_TextBox.ctl_TextBox
    Private WithEvents txt_Name_For_Grid_Selection As New TextBox
    Private WithEvents txt_Code_For_Grid_Selection As New TextBox
    Private WithEvents txtAcOfCode As New TextBox
    Private WithEvents txtSupplierCode As New TextBox
    Private WithEvents txtBookCode As New TextBox
    Private WithEvents txtSelvCode As New TextBox
    Private WithEvents txtLoomTypeCode As New TextBox
    Private WithEvents txtWeaveTypeCode As New TextBox

    Private Old_Date As String = ""
    Private Edit_From_View As Boolean = False
    Private Call_By_other As Boolean = False
    Private Book_Name As String = ""
    Private Book_Code As String = ""
    Private AcCode_Filter_String As String = ""
    Private Book_Row As DataRow
    Private Str_In_Group As String = ""

    Private Old_Col_No As Integer = 0
    Private Old_Col_No_Stk As Integer = 0
    Private FOUND As Boolean = False
    Private Return_Master_Name As String = ""
#End Region
#Region "GENERAL VARIABLE DECLARE "
    Private Last_Saved_Entry_No As Integer = 0
    Private DispMultiList As Boolean = False
    Private Return_Array_Values(0) As String
    Private Str_In_Party As String = ""
    Private Str_In_Mill As String = ""
    Private Str_In_Agent As String = ""
    Private Str_In_City As String = ""
    Private Str_In_SalesMan As String = ""

    Private _FrmLoad As Boolean = True
    Private WithEvents txtSalesman_code As New TextBox
    Private WithEvents txtAgent_code As New TextBox
    Private WithEvents txtAccount_Code As New TextBox
    Private WithEvents txtSupp_code As New TextBox
    Private WithEvents txtTr_code As New TextBox
    Private WithEvents txtDespatch_code As New TextBox
    Private DispList As Boolean = False
    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldName As String = "BOOKVNO"
    Private _KeyFieldValue As String = ""
    Private _OfferTableName As String = "TRNOFFER"
    Private _ErrorMessage As String = ""
    Private _NewAddedRow As Boolean = False
    Private SRNO As Integer = 1
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _TmpDataTable As New DataTable
    Private _BookTrType As String = ""
    Private _PartyItemColoumn As String = ""
    Private _SizeManuelEntryColoumn As String = ""
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
#End Region

#Region "GRID COL. DEFINE AND FORMATTING "
    Private Sub defineGridColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID,")
            .Append("SRNO,")
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("OfferDate,")
            .Append("ACCOUNTNAME,")
            .Append("ACCOUNTCODE,")
            .Append("ITEMCODE,")
            .Append("ITEMNAME,")
            .Append("OFFERNO,")
            .Append("SHADECODE,")
            .Append("SHADENO,")
            .Append("MTR_WEIGHT,")
            .Append("Descr,")
            .Append("RATE,")
            .Append("TransportCode,")
            .Append("AgentOfferNo,")
            .Append("ROWREMARK")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("Mtr_Weight:N,")
            .Append("RATE:N")
        End With

        _GridColValidate = New StringBuilder
        With _GridColValidate
        End With

        _GridCol_FocusByPass = New StringBuilder
        With _GridCol_FocusByPass

        End With

        _FieldHeader = New StringBuilder
        With _FieldHeader
            .Append("SRNO:S.No,")
            .Append("ACCOUNTNAME:Supplier,")
            .Append("ITEMNAME:Item Name,")
            .Append("MTR_WEIGHT:Qty,")
            .Append("Rate:Rate,")
            .Append("OfferNo:PlanNo,")
            .Append("DESCR:Stock Use,")
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("ITEMNAME:L,")
            .Append("ACCOUNTNAME:L,")
            .Append("SHADENO:L,")
            .Append("DESCR:L,")
            .Append("OfferNo:L,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("ROWREMARK:L")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("ITEMNAME:L,")
            .Append("ACCOUNTNAME:L,")
            .Append("SHADENO:L,")
            .Append("OfferNo:L,")
            .Append("DESCR:L,")
            .Append("MTR_WEIGHT:R,")
            .Append("RATE:R,")
            .Append("ROWREMARK:L")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("SRNO:Y,")
            .Append("ENTRYNO:N,")
            .Append("BookTrtype:N,")
            .Append("BOOKVNO:N,")
            .Append("BookCode:N,")
            .Append("OfferNo:Y,")
            .Append("ACCOUNTNAME:Y,")
            .Append("OfferDate:N,")
            .Append("AccountCode:N,")
            .Append("ITEMCODE:N,")
            .Append("ITEMNAME:Y,")
            .Append("DESCR:N,")
            .Append("SHADECODE:N,")
            .Append("SHADENO:N,")
            .Append("AgentOfferNo:N,")
            .Append("TransportCode:N,")
            .Append("MTR_WEIGHT:Y,")
            .Append("RATE:Y,")
            .Append("ROWREMARK:Y")
        End With

        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("ACCOUNTNAME:N,")
            .Append("ITEMNAME:N")
        End With

        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:7,")
            .Append("ACCOUNTNAME:30,")
            .Append("ITEMNAME:20,")
            .Append("MTR_WEIGHT:20,")
            .Append("RATE:10,")
            .Append("DESCR:15,")
            .Append("OfferNo:15,")
            .Append("ROWREMARK:8")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("MTR_WEIGHT:0,")
            .Append("RATE:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y,")
            .Append("DESCR:Y")
        End With

        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("MTR_WEIGHT:NO-2,")
            .Append("RATE:NO-2")
        End With

        With _FieldNameSameValueCopy

        End With

        Grid_Table_ColNames = _GridColNames.ToString.ToUpper.Split(",")
    End Sub
    Private Sub GenerateTable(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(gridTable, _GridColNames.ToString.ToUpper, "NO", _GridColType.ToString)
        grdObj.ExtendLastCol = True
        _GridLastColNo = gridTable.Columns.Count
        grdObj.Cols = gridTable.Columns.Count + 1
        grdObj.Rows = 7
    End Sub
    Private Sub GridFormatting(ByRef gridTable As DataTable, ByRef grdObj As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "VISIBLE", _FieldNotVisibile.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "WIDTH", _FieldWidthSet.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HEADER", _FieldHeader.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "LOCK", _FieldLocked.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "MASK", _FieldMasking.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "ALIGNMENT", _FieldAlignMent.ToString)
        Call ObjCls_General._LibGridFormatting(gridTable, grdObj, "HALIGNMENT", _FieldHeaderAlignment.ToString)
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
    End Sub
#End Region


    Private Sub YarnPurchasesPlaningDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, 0)

        Dim x As Integer
        Dim y As Integer
        x = 0
        y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        Me.Location = New Point(x, y)


        Book_Code = "YRNPO-000000002"
        txtBookCode.Text = Book_Code
        _BookTrType = "YPNO2"


        PNL_View.Width = Me.Width
        PNL_View.Height = Me.Height
        PNL_View.Location = New Point(0, 0)

        GridControl3.Width = PNL_View.Width - 25
        GridControl3.Height = PNL_View.Height - 100
        GridControl3.Location = New Point(3, 53)




        'Pnl_PlannimgSelection.Width = 402
        'Pnl_PlannimgSelection.Height = 546
        'Pnl_PlannimgSelection.Location = New Point(126, 26)


        _FrmLoad = True

        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)

        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text

        Lbl_Tot_Mtr_Weight.Text = ""

        SetTotalObjectPosition("MTR_WEIGHT", _DataTableGrid, GrdItem, Lbl_Tot_Mtr_Weight, lbl_Total)

        If _isCallerByOther = True Then
            _InsertAddButtonControl()
            GridView1.Focus()
        Else
            Command_Button_Visibility("LOAD")
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            btnAdd.Focus()
            btnAdd.Select()
        End If

        _FrmLoad = False

    End Sub

    Private Function _GetPlaniYarnCountQuery()
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" D.CountName  ")
            .Append(" ,D.CountCode  ")
            .Append(" ,sum(z.PurPlan)-sum(z.PurOrder)  as YarnPlanQty")
            .Append(" FROM (")
            .Append(" SELECT ")
            .Append(" A.ITEMCODE  ")
            .Append(" ,ISNULL(A.Mtr_Weight,0) as PurPlan")
            .Append(" ,0.00 as PurOrder")
            .Append(" FROM TrnOffer AS A ")
            .Append(" WHERE 1=1")
            .Append(" AND A.BookCode ='YRNPL-000000001' ")
            .Append("AND A.DESCR='PURCHASE' ")

            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" A.ITEMCODE  ")
            .Append(" ,0.00 as PurPlan")
            .Append(" ,ISNULL(A.Mtr_Weight,0) as PurOrder")
            .Append(" FROM TrnOffer AS A ")
            .Append(" ")
            .Append(" WHERE 1=1")
            .Append(" AND A.BookCode ='YRNPO-000000002' ")
            .Append(" ) AS Z  ")
            .Append(" LEFT JOIN MstYarnCount AS D ON Z.ITEMCODE=D.CountCode   ")
            .Append(" GROUP BY")
            .Append(" D.CountName  ")
            .Append(" ,D.CountCode  ")
            .Append(" HAVING sum(z.PurPlan)-sum(z.PurOrder)>0  ")
        End With

        Return _strQuery.ToString
    End Function
    Private Sub _GetYarnPlanQty()


        sqL = _GetPlaniYarnCountQuery()
        sql_connect_slect()
        Dim _ThidTable As New DataTable

        If _MainTblYarn IsNot Nothing Then
            _MainTblYarn.Clear()
        End If


        _ThidTable = DefaltSoftTable.Copy
        _MainTblYarn = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Pending Plan Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
        Else
            For Each dr As DataRow In _ThidTable.Select
                dr("YarnPlanQty") = SafeFormat(dr, "YarnPlanQty", "0.00")
            Next

            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy

            GridView1.Columns("CountCode").Visible = False

            DevGridFitColumn(GridControl2, GridView1)
            GridView1.Columns("YarnPlanQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "YarnPlanQty", "{0}"))
            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If

    End Sub

    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        _CountInfo()
    End Sub
    Private Sub GridControl2_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl2.MouseClick
        _CountInfo()
    End Sub
    Private Sub _CountInfo()
        Dim CountCode As String = String.Empty
        Dim val = GridView1.GetFocusedRowCellValue("CountCode")
        If val IsNot Nothing AndAlso Not IsDBNull(val) Then
            CountCode = val.ToString()
            _SlecteedCountCode = val.ToString()
            Txt_RequreQty.Text = GridView1.GetFocusedRowCellValue("YarnPlanQty")
            Txt_PurchaseQty.Text = GridView1.GetFocusedRowCellValue("YarnPlanQty")
        End If
        _GetOldOrderRateWise(CountCode)
        If _SlecteedCountCode > "" Then
            Dim whereClause = " AND D.CountCode ='" & _SlecteedCountCode & "'"
            Dim _Loadquery = _GetPlanningQuery(whereClause)
            _BookGrdSetting(_Loadquery)

            Pnl_PlannimgSelection.Visible = True
            Pnl_PlannimgSelection.BringToFront()
            Txt_SupplierName.Focus()
            Txt_SupplierName.SelectAll()
        End If

    End Sub
    Private Sub _GetOldOrderRateWise(ByVal _CountCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" B.ACCOUNTNAME as Supplier  ")
            .Append(" ,D.CountName  ")
            .Append(" ,D.CountCode  ")
            .Append(" ,ISNULL(SUM(A.Mtr_Weight),0) as OldPurQty")
            .Append(" ,A.Rate")
            .Append(" ,A.ACCOUNTCODE")
            .Append(" FROM TrnOffer AS A ")
            .Append(" LEFT JOIN MstYarnCount AS D ON A.ITEMCODE=D.CountCode ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE=B.ACCOUNTCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND A.BookCode ='0001-000000164' ")
            .Append(" AND A.ITEMCODE ='" & _CountCode & "' ")
            .Append(" GROUP BY  ")
            .Append(" B.ACCOUNTNAME  ")
            .Append(" ,D.CountName  ")
            .Append(" ,D.CountCode  ")
            .Append(" ,A.Rate")
            .Append(" ,A.ACCOUNTCODE")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        GridView2.Columns.Clear()
        GridView2.GridControl.DataSource = Nothing

        If _ThidTable.Rows.Count = 0 Then
            'MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            'Exit Sub
        Else
            For Each dr As DataRow In _ThidTable.Select
                dr("OldPurQty") = SafeFormat(dr, "OldPurQty", "0.00")
            Next


            GridControl1.DataSource = _ThidTable.Copy

            GridView2.Columns("CountCode").Visible = False
            GridView2.Columns("ACCOUNTCODE").Visible = False

            'DevGridFitColumn(GridControl2, GridView2)
            GridView2.Columns("OldPurQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OldPurQty", "{0}"))
            GridView2.Appearance.FocusedRow.BackColor = GridView2.Appearance.FocusedRow.BackColor.LightBlue
            GridView2.Columns("Supplier").Width = 120
            GridView2.Columns("CountName").Width = 80
            GridView2.Columns("OldPurQty").Width = 80
            GridView2.Columns("Rate").Width = 50

            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView2.Focus()
            GridView2.FocusedRowHandle = GridView2.GetVisibleRowHandle(0)
        End If
        GridView2.Focus()
    End Sub


#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False
        If txtOfferDate.Text = "  /  /    " Then
            MsgBox("Invalid Offer Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtOfferDate.Focus()
            Exit Function
        ElseIf Trim(txtEntryNo.Text) = "" Or Val(txtEntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            Exit Function
        Else
            Validate_Form_Values = True
        End If
    End Function
#End Region

#Region "FORM EVENTS "
    Private Sub Yarn_Offer_Entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)


        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True

            If _FORMMODE = "" Then
                CLOSE_MNU_LOAD()

            Else
                If PNL_View.Visible = True Then
                    PNL_View.Visible = False
                    Command_Button_Visibility("LOAD")
                    ObjCls_General.Blank_Object(Me)
                    Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                    Exit Sub
                End If

                'If Pnl_PlannimgSelection.Visible = True Then
                '    Pnl_PlannimgSelection.Visible = False
                '    GridView2.Focus()
                '    Exit Sub
                'End If



                Select Case _STRTRNOBJECT
                    Case "GRDITEM"
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txtEntryNo.Focus()
                    Case "TERM1"
                        txtEntryNo.Focus()
                    Case "TXTOFFERDATE"
                        _FrmLoad = True
                        txtOfferDate.Text = ObjCls_General.GetTodayDate_British
                        _FORMMODE = ""
                        Old_Date = txtOfferDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtOfferDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        _KeyFieldValue = 0
                        Command_Button_Visibility("LOAD")
                        Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                    Case Else
                        _FrmLoad = True
                        _FORMMODE = ""
                        Old_Date = txtOfferDate.Text
                        ObjCls_General.Blank_Object(Me)
                        txtOfferDate.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Call Command_Button_Visibility("LOAD")
                        Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                End Select
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            If Pnl_PlannimgSelection.Visible Then
                _FeeldataGridItem()
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            If _STRTRNOBJECT = "GRDITEM" Then
                'Call Show_Calculator_With_Grid(GrdItem, Me)
            ElseIf _STRTRNOBJECT = "GRD_VIEW" Then
                'Call Show_Calculator_With_Grid(grd_View, Me)
            Else
                'Call Show_Calculator_Without_Grid(Me)
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
                        MsgBox("Blank Item Detail, Can't Save", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                        Exit Sub
                    Else
                        _FrmLoad = True
                        Total_Upto_All_Grid_All_Row()
                        btnSave.Focus()
                    End If
                Case "GRID1"
                    GrdItem.Focus()
                Case "GRID2"
                    GrdItem.Focus()
                Case "BTNSAVE"
                    txtEntryNo.Focus()
                Case "TXTTERM1"
                    btnSave.Focus()
                    btnSave.Select()
                Case "TXTTERM2"
                    btnSave.Focus()
                    btnSave.Select()
                Case "TXTTERM3"
                    btnSave.Focus()
                    btnSave.Select()
                Case "TXTTERM4"
                    btnSave.Focus()
                    btnSave.Select()
                Case Else

                    If txtOfferDate.Text = "  /  /    " Then
                        txtOfferDate.Focus()
                    Else
                        _FrmLoad = True
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        GrdItem.Focus()
                        GrdItem.Select()
                    End If
            End Select
        ElseIf e.KeyCode = Keys.F3 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    _FrmLoad = True
                    Delete_Row(GrdItem, _DataTableGrid)
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = ""
                    Call Total_Upto_All_Grid_All_Row()
                    Call Fill_Sr_No_Item(GrdItem, _DataTableGrid)
                    _FrmLoad = False
            End Select
        ElseIf e.KeyCode = Keys.PageUp Then
            If _FORMMODE = "EDIT" And Val(txtEntryNo.Text) > 1 And Last_Saved_Entry_No > 0 Then
                txtEntryNo.Text = Val(txtEntryNo.Text) - 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _OfferTableName)
            End If
        ElseIf e.KeyCode = Keys.PageDown Then
            If _FORMMODE = "EDIT" And Last_Saved_Entry_No > 0 And Val(txtEntryNo.Text) < Last_Saved_Entry_No Then
                txtEntryNo.Text = Val(txtEntryNo.Text) + 1
                Dim Book_Vno As String = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
                Call Validate_Entry_No(Book_Vno, _OfferTableName)
            End If
        End If
    End Sub

#End Region

#Region "TOTAL ALL ROWS "
    Private Sub Total_Upto_All_Grid_All_Row()


        Dim Tot_Mtr_Weight As Double = 0
        For j As Int16 = 1 To GrdItem.Rows - 1
            Tot_Mtr_Weight = Tot_Mtr_Weight + Val(GrdItem.Cell(j, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
        Next
        Lbl_Tot_Mtr_Weight.Text = Tot_Mtr_Weight
        Lbl_Tot_Mtr_Weight.Text = IIf(Tot_Mtr_Weight > 0, Format(Val(Lbl_Tot_Mtr_Weight.Text), "0.000"), "")
    End Sub
#End Region

#Region "COMMAND BUTTON VISIBILITY CODE "
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)
        GridView1.Columns.Clear()
        GridView4.Columns.Clear()
        GridBooking.Columns.Clear()
        LblFeelQty.Text = "0.00"

        If Visibility_Flag = "LOAD" Then
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "btnModify" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
        End If
    End Sub
#End Region

#Region "SET FOCUS LAST CLICKED BTN "
    Private Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)
        _FORMMODE = ""
        If Last_Focused_Btn = "ADD" Then
            btnAdd.Focus()
        ElseIf Last_Focused_Btn = "EDIT" Then
            btnModify.Focus()
        ElseIf Last_Focused_Btn = "DELETE" Then
            btnDelete.Focus()
        ElseIf Last_Focused_Btn = "VIEW" Then
            btnView.Focus()
        ElseIf Last_Focused_Btn = "SAVE" Then
            btnAdd.Focus()
        End If
    End Sub
#End Region

#Region "Button Click Event "
    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If _FORMMODE = "VIEW" Then
            PNL_View.Visible = False
            _FrmLoad = True
            _FORMMODE = ""
            Old_Date = txtOfferDate.Text
            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
            Clear_Grid(GrdItem, 2)
            Label_Value_Nil_Rest()
            _KeyFieldValue = 0
            Command_Button_Visibility("LOAD")
            Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Else
            CLOSE_MNU_LOAD()
        End If
    End Sub


    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub CLOSE_MNU_LOAD()
        Me.Close()
        Me.Dispose(True)
        LEDGER_ENTER_DISPLAY_FROM = ""
        _GenralOrderLoadBy = ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            If Edit_From_View = True Then
                _FORMMODE = "VIEW"
            End If
        End If
    End Sub
    Public Function EntryData_Invoice_Entry_txtBookName_Validated(ByVal _BookCode As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.ENTRYNO")
            .Append(" FROM " & _OfferTableName & " AS  A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return _strQuery.ToString
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _InsertAddButtonControl()
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub

    Public Sub _InsertAddButtonControl()
        Edit_From_View = False
        _FrmLoad = False

        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"

        Command_Button_Visibility("BTNADD")

        ObjCls_General.Blank_Object(Me)
        txtBookCode.Text = Book_Code

        Dim Last_Entry_No As Integer = 1
        sqL = EntryData_Invoice_Entry_txtBookName_Validated(Book_Code)
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO")) + 1
        End If
        txtEntryNo.Text = Last_Entry_No
        txtOfferDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        _GetYarnPlanQty()
    End Sub
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "EDIT"
        Last_Focused_Btn = "EDIT"
        txtEntryNo.Visible = True
        Command_Button_Visibility("btnModify")

        ObjCls_General.Blank_Object(Me)

        txtBookCode.Text = Book_Code

        Dim Last_Entry_No As Integer = 1
        sqL = EntryData_Invoice_Entry_txtBookName_Validated(Book_Code)
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        End If
        txtEntryNo.Text = Last_Entry_No
        txtOfferDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        _GetYarnPlanQty()
        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "DELETE"
        Last_Focused_Btn = "DELETE"
        txtEntryNo.Visible = True
        Command_Button_Visibility("BTNDELETE")

        ObjCls_General.Blank_Object(Me)

        txtBookCode.Text = Book_Code


        Dim Last_Entry_No As Integer = 1
        sqL = EntryData_Invoice_Entry_txtBookName_Validated(Book_Code)
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        End If
        txtEntryNo.Text = Last_Entry_No
        txtOfferDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)

        txtEntryNo.Focus()
        txtEntryNo.Select()
    End Sub
    Private Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        _FrmLoad = False

        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"
        Command_Button_Visibility("BTNVIEW")

        txtBookCode.Text = Book_Code

        View_Record()
    End Sub

#End Region

#Region "BTN GOTFOCUS AND LOSTFOCUS COLOR CODE "
    Private Sub btnAdd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.GotFocus
        btnAdd.BackColor = Color.Coral
    End Sub
    Private Sub btnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.LostFocus
        btnAdd.BackColor = Me.BackColor
    End Sub

    Private Sub btnModify_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.GotFocus
        btnModify.BackColor = Color.Coral
    End Sub
    Private Sub btnModify_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.LostFocus
        btnModify.BackColor = Me.BackColor
    End Sub

    Private Sub btnDelete_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.GotFocus
        btnDelete.BackColor = Color.Coral
    End Sub
    Private Sub btnDelete_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.LostFocus
        btnDelete.BackColor = Me.BackColor
    End Sub
    Private Sub btnView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.GotFocus
        btnView.BackColor = Color.Coral
    End Sub
    Private Sub btnView_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.LostFocus
        btnView.BackColor = Me.BackColor
    End Sub
    Private Sub btnSave_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.GotFocus
        btnSave.BackColor = Color.Coral
    End Sub
    Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.LostFocus
        btnSave.BackColor = Me.BackColor
    End Sub
    Private Sub btnClose_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.GotFocus
        btnClose.BackColor = Color.Coral
    End Sub
    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.LostFocus
        btnClose.BackColor = Me.BackColor
    End Sub
#End Region

#Region "Label Value Setting "
    Private Sub Label_Decimal_Setting()

        If Val(Lbl_Tot_Mtr_Weight.Text) > 0 Then
            Lbl_Tot_Mtr_Weight.Text = FormatNumber(Val(Lbl_Tot_Mtr_Weight.Text), 3, TriState.False, TriState.False, TriState.True)
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If
    End Sub

    Private Sub Label_Value_Nil_Rest()
        Lbl_Tot_Mtr_Weight.Text = ""
    End Sub
#End Region

#Region "DELETE CODE"
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable)
        _FrmLoad = True
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).DeleteByRow()
        GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = GrdObj.ActiveCell.Row
        _FrmLoad = False
    End Sub

    Private Sub Delete_Entry_SQL()
        _FrmLoad = True
        Dim affected As Integer = 0
        Dim I As Integer = 0
        Dim _LastID As Integer = 0

        Try
            strQuery = " DELETE FROM trnOffer WHERE BOOKVNO='" & _BookVNo & "'"
            sqL = strQuery.ToString
            sql_Data_Save_Delete_Update()

            '-----------------------------------------------------------------------

            sqL = "DELETE FROM TRNOFFER WHERE 1=1 And LOOM_TYPE ='" & _BookVNo & "'"
            sql_Data_Save_Delete_Update()


            _KeyFieldValue = 0
            _FORMMODE = "ADD"

            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Old_Date = txtOfferDate.Text
            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
        Catch ex As Exception
            MsgBox("Error While Delete Entry")
        Finally
        End Try
        _FrmLoad = False
    End Sub
#End Region

#Region "FILL SR NO"
    Private Sub Fill_Sr_No_Item(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable)
        Dim i As Integer = 0
        For i = 1 To GrdObj.Rows - 1
            If Val(GrdObj.Cell(i, Data_Table.Columns.IndexOf("AMOUNT") + 1).Text) > 0 Then
                GrdObj.Cell(i, Data_Table.Columns.IndexOf("SRNO") + 1).Text = i
            End If
        Next
    End Sub
#End Region

#Region "TXT BOX ENTRY NO EVENT CODE "
    Private Sub txtEntryNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntryNo.Validated
        If _FrmLoad = True Then Exit Sub

        If Val(txtEntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            txtEntryNo.Select()
            Exit Sub
        Else
            Dim BookVno As String = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)
            _BookVNo = BookVno
            Validate_Entry_No(BookVno, _OfferTableName)
        End If
    End Sub
    Private Sub Validate_Entry_No(ByVal Book_Vno As String, ByVal Table_Name As String)
        _TransctionNo = 0
        strQuery = "SELECT TOP 1 ENTRYNO FROM " & Table_Name & " WHERE BOOKVNO='" & Book_Vno & "'"
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = DefaltSoftTable.Rows(0).Item(0)
        End If



        If _TransctionNo > 0 Then
            If _FORMMODE = "ADD" Then
                MsgBox("Entry No. Already Exist", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Focus()
                txtEntryNo.Select()
            ElseIf _FORMMODE = "EDIT" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)
                btnSave.Enabled = True
                txtOfferDate.Focus()
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice", MsgBoxStyle.Information, "Soft-Tex PRO")
                    Change_Grid_Data = False
                    txtOfferDate.Enabled = False
                    GrdItem.Column(_DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Locked = True
                    GrdItem.Column(_DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Locked = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtOfferDate.Focus()
                    txtOfferDate.Select()
                Else
                    Change_Grid_Data = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtOfferDate.Focus()
                    txtOfferDate.Select()
                End If
            ElseIf _FORMMODE = "DELETE" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice, Can't Delete", MsgBoxStyle.Information, "Soft-Tex PRO")
                Else
                    If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                        Call Delete_Entry_SQL()
                    End If
                End If
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                Command_Button_Visibility("LOAD")
                If _Last_Saved_Entry_No > 0 Then
                    Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                Else
                    btnAdd.Focus()
                End If
                _FrmLoad = False
            End If
        Else
            If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                Clear_Grid(GrdItem, 2)
                Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                MsgBox("Entry No " + Trim(txtEntryNo.Text) + " Not Found")
                txtEntryNo.Visible = True
                txtEntryNo.Focus()
                txtEntryNo.Select()
            End If
        End If
    End Sub
#End Region

#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        Return obj_Party_Selection.EntryData_General_Offer_getAlter_Form_Query_Details(strKeyID)
    End Function
#End Region

#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)
        sqL = strQuery.ToString
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy

        'ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)

        txtTr_code.Text = tblTmp.Rows(0)("TRANSPORTCODE").ToString
        txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
        txtDespatch_code.Text = tblTmp.Rows(0)("DESPATCHCODE").ToString
        txtOfferDate.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        txtAcOfCode.Text = tblTmp.Rows(0)("ACOFCODE").ToString
        txtEntryNo.Text = tblTmp.Rows(0)("ENTRYNO").ToString
        txtOfferDate.Text = tblTmp.Rows(0)("F_OFFERDATE").ToString
        'Txt_PlanningNo.Text = tblTmp.Rows(0)("OFFERNO").ToString

        Generate_Date_For_DataBase(txtOfferDate)

        Lbl_Tot_Mtr_Weight.Text = tblTmp.Compute("SUM(MTR_WEIGHT)", "").ToString

        GrdItem.Visible = False
        GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
        Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)
        GrdItem.Refresh()
        GrdItem.Visible = True

        If Val(Lbl_Tot_Mtr_Weight.Text) > 0 Then
            Lbl_Tot_Mtr_Weight.Text = Format(Val(Lbl_Tot_Mtr_Weight.Text), "0.000")
        Else
            Lbl_Tot_Mtr_Weight.Text = ""
        End If

        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        _FrmLoad = False
    End Sub


#End Region

#Region "Check Adjustment Agnst Offer "
    Private Function Is_Adjusted_Offer() As Boolean
        Dim Total_Record As Integer = 0
        Dim Return_Value As Boolean = False
        Dim Tmp_Data_Table As New DataTable
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.OFFERBOOKVNO ")
            .Append(" FROM TRNINVOICEDETAIL A ")
            .Append(" WHERE A.ACCOUNTCODE='" & txtAccount_Code.Text & "' ")
            .Append(" AND A.OFFERBOOKVNO='" & _BookVNo & "' ")
        End With
        strQuery = _strQuery.ToString
        sqL = strQuery.ToString
        sql_connect_slect()
        Tmp_Data_Table = DefaltSoftTable.Copy

        Total_Record = Tmp_Data_Table.Rows.Count
        If Total_Record > 0 Then
            Return_Value = True
        Else
            Return_Value = False
        End If
        Return Return_Value
    End Function
#End Region


#Region "GRID ITEM EVENTS"
    Private Sub grditem_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub grdItem_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        GrdItem.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub grdItem_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
        GrdItem.ActiveCell.BackColor = GrdItem.BackColor1
    End Sub
    Private Sub grdItem_EnterRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.EnterRowEventArgs) Handles GrdItem.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
        GrdItem.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub grdItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        GrdItem.ActiveCell.BackColor = Color.Transparent
        _FrmLoad = False
    End Sub
    Private Sub grdItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.LostFocus
        If _FrmLoad = True Then Exit Sub
        _LastRow = sender.ActiveCell.Row
    End Sub
    Private Sub grdItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Validated
        If _FrmLoad = True Then Exit Sub
        GrdItem.Refresh()
    End Sub
    Private Sub grdItem_LeaveRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveRowEventArgs) Handles GrdItem.LeaveRow

        If _FrmLoad = True Then Exit Sub
        _LastRow = Sender.ActiveCell.Row

        Dim CUTCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text
        Dim ITEMCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
        Dim ITEMGROUPCODE As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text
        Dim QTY As Double = Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)

        If CUTCODE = "" Or ITEMCODE = "" Or QTY = 0 Or ITEMGROUPCODE = "" Then
            If _ActivatedColName = "ROWREMARK" Then
                e.Cancel = True
                If ITEMCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf ITEMGROUPCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf CUTCODE = "" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTNAME") + 1).SetFocus()
                    Exit Sub
                ElseIf QTY = 0 Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).SetFocus()
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMGROUPCODE") + 1).Text = "0000-000001008"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000003"
        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "" Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE"

        If _ActivatedColName = "ITEMNAME" Then
            'If e.KeyCode = Keys.Enter Then
            '    Dim _CountNAme As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
            '    Dim _LoadQuery = _GetPlaniYarnCountQuery()
            '    Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), _CountNAme, "SINGLE")
            '    If selected IsNot Nothing Then
            '        If selected.ContainsKey("CountCode") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = selected("CountCode").ToString()
            '        If selected.ContainsKey("CountName") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = selected("CountName").ToString()
            '    End If
            'End If
        ElseIf _ActivatedColName = "ACCOUNTNAME" Then
            'If e.KeyCode = Keys.Enter Then
            '    Dim AccountName As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text
            '    Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
            '    Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), AccountName, "SINGLE")
            '    If selected IsNot Nothing Then
            '        If selected.ContainsKey("ACCOUNTCODE") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = selected("ACCOUNTCODE").ToString()
            '        If selected.ContainsKey("AccountName") Then GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = selected("AccountName").ToString()
            '    End If

            'End If
        ElseIf _ActivatedColName = "OFFERNO" Then
            'If e.KeyCode = Keys.Enter Then
            '    Party_selection.txtSearch.Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OFFERNO") + 1).Text
            '    Dim codes As New List(Of String)
            '    For i As Integer = 0 To GridView1.RowCount - 1
            '        Dim val = GridView1.GetRowCellValue(i, "CountCode")
            '        If val IsNot Nothing AndAlso Not IsDBNull(val) Then
            '            codes.Add("'" & val.ToString().Replace("'", "''") & "'")
            '        End If
            '    Next
            '    Dim whereClause As String = ""
            '    If codes.Count > 0 Then
            '        whereClause = " AND D.CountCode IN (" & String.Join(",", codes) & ")"
            '    End If
            '    _GetPlanningQuery(whereClause)
            '    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("OFFERNO") + 1).Text = MULTY_SELECTION_COLOUM_1_DATA
            '    End If
            'End If
        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "MTR_WEIGHT" Then
            If e.KeyCode = Keys.Enter Then
                Call Total_Upto_All_Grid_All_Row()
            End If
            'ElseIf _ActivatedColName = "DESCR" Then
            '    If e.KeyCode = Keys.Space Then
            '        If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "" Then
            '            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE"
            '        ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE" Then
            '            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "FACTORY STOCK"
            '        ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "FACTORY STOCK" Then
            '            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "OPENING STOCK"
            '        ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "OPENING STOCK" Then
            '            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = "PURCHASE"


            '        End If
            '    End If
        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                Dim i As Integer = GrdItem.ActiveCell.Row
                Dim QTY As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text)
                Dim ITEMCODE As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
                If QTY <> 0 And ITEMCODE <> "" Then
                    If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                        GrdItem.Rows = GrdItem.Rows + 1
                        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    End If
                End If
            End If
        End If
    End Sub


#End Region

#Region "GRID GENERAL FUNCTION "
    Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
        If grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If

        If grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
            grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
        End If
    End Sub
#End Region

#Region "Save Code "
    Private Sub SaveRecord()
        If Val(Lbl_Tot_Mtr_Weight.Text) = 0 Then
            MsgBox("Invalid Item Detail", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            GrdItem.Focus()
            GrdItem.Select()
            Exit Sub
        End If

        If txtAcOfCode.Text = "" Then
            txtAcOfCode.Text = "0000-000000001"
        End If


        If _FORMMODE = "ADD" Then
            Dim Str_Qry As String = obj_Party_Selection.EntryData_General_Offer_txtBookName_Validated(Book_Code)
            Dim TblTmp As New DataTable
            sqL = Str_Qry
            sql_connect_slect()
            TblTmp = DefaltSoftTable.Copy
            Dim Last_Entry_No As Integer = 0
            If TblTmp.Rows.Count > 0 Then
                Last_Entry_No = Val(TblTmp(0)("ENTRYNO").ToString)
            End If
            If Last_Entry_No = txtEntryNo.Text Then
                txtEntryNo.Text = Last_Entry_No + 1
            End If
        End If

        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)

        Generate_Date_For_DataBase(txtOfferDate)

        Total_Upto_All_Grid_All_Row()

        Call Fill_Grid_Records_Into_DataTables()
        Dim _LastID As Integer = -1
        Try

            _LastID = SAVE_INTO_DATABASE_SQL()

            Old_Date = txtOfferDate.Text
            Call Label_Value_Nil_Rest()
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

            ObjCls_General.Blank_Object(Me)
            txtOfferDate.Text = Old_Date
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)

            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            Call Command_Button_Visibility("LOAD")
            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow
        '--- Fill Items Grid Records -----------
        _DataTableGrid.Rows.Clear()
        For i As Int16 = 1 To GrdItem.Rows - 1
            If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text <> "" And Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text) > 0 Then

                If GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "" Then
                    GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("CUTCODE") + 1).Text = "0000-000000001"
                End If

                FieldDr = _DataTableGrid.NewRow
                For j As Int16 = 1 To GrdItem.Cols - 1
                    If FieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FieldDr(j - 1) = Val(GrdItem.Cell(i, j).Text)
                    Else
                        FieldDr(j - 1) = (GrdItem.Cell(i, j).Text)
                    End If
                Next
                _DataTableGrid.Rows.Add(FieldDr)
            End If

        Next
        '----------------------------------------
    End Sub
    Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        '------------------------ DETAILS Table --------------------------------

        If txtSalesman_code.Text = "" Then
            txtSalesman_code.Text = "0000-000000001"
        End If

        If txtSelvCode.Text = "" Then
            txtSelvCode.Text = "0000-000000001"
        End If

        If txtLoomTypeCode.Text = "" Then
            txtLoomTypeCode.Text = "0000-000000001"
        End If

        If txtWeaveTypeCode.Text = "" Then
            txtWeaveTypeCode.Text = "0000-000000001"
        End If

        Dim strFilterString As String
        Dim QueryDetailTable As String = ""

        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String

        strFilterString = "MTR_WEIGHT>0 "

        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("ENTRYNO,")
            .Append("BookTrtype,")
            .Append("BOOKVNO,")
            .Append("BookCode,")
            .Append("DESCR,")
            .Append("OfferDate")

        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtEntryNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(Book_Code & ",")
            .Append("YARN PLANNING ENTRY" & ",")
            .Append(txtOfferDate.Date_for_Database)
        End With

        QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid
    End Function

    Private Function SAVE_INTO_DATABASE_SQL() As Integer
        Dim strQuery As String = ""
        Dim I As Integer = 0

        Try
            '---------------- Delete Previous Bill Sundry ----------------------------------'
            strQuery = "DELETE FROM TRNOFFER WHERE 1=1 And BOOKVNO ='" & _BookVNo & "'"
            sqL = strQuery
            sql_Data_Save_Delete_Update()
            Dim Array_Opening(0, 4) As String
            '------ INSERT RECORDS SALES INVOICE -------------------------------
            GridDetailsSaveQuery(Array_Opening)
            For I = 0 To UBound(Array_Opening)
                If Array_Opening(I, 4) <> "" Then
                    strQuery = Array_Opening(I, 4)
                    sqL = strQuery
                    sql_Data_Save_Delete_Update()
                End If
            Next


            _PalanningOfferGenerate()

        Catch ex As Exception

            MsgBox("new error comes :" & ex.Message & "-" & strQuery)
            Throw ex
        Finally
        End Try
    End Function


    Private Sub _PalanningOfferGenerate()
        Dim _YarnPurBookcode As String = "0001-000000164"
        Dim _YarnPurTrtype As String = "O0164"

        Dim _MaxEntryNo As Integer = 0
        sqL = " SELECT TOP 1 ENTRYNO FROM TRNOFFER WHERE BOOKCODE='" & _YarnPurBookcode & "' ORDER BY ENTRYNO DESC"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _MaxEntryNo = DefaltSoftTable.Rows(0).Item("ENTRYNO")
        End If




        '--- Output DataTable structure बनाना
        Dim dtResult As New DataTable()
        dtResult.Columns.Add("AccountCode", GetType(String))
        dtResult.Columns.Add("ITEMCODE", GetType(String))
        dtResult.Columns.Add("Rate", GetType(Decimal))
        dtResult.Columns.Add("Mtr_Weight", GetType(Decimal))
        dtResult.Columns.Add("entryno", GetType(Integer))

        '--- Dictionary for grouping
        Dim groups As New Dictionary(Of String, Decimal)


        For i As Int16 = 1 To GrdItem.Rows - 1
            Dim accountCode As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text
            Dim countCode As String = GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
            Dim rate As Decimal = 0
            Decimal.TryParse(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text, rate)
            Dim yarnQty As Decimal = 0
            Decimal.TryParse(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("Mtr_Weight") + 1).Text, yarnQty)

            If String.IsNullOrWhiteSpace(accountCode) Then Continue For

            '--- Unique Key: AccountCode|ItemCode|Rate
            Dim key As String = accountCode & "|" & countCode & "|" & rate.ToString("0.00")

            If groups.ContainsKey(key) Then
                groups(key) += yarnQty
            Else
                groups(key) = yarnQty
            End If
        Next

        '--- Dictionary से DataTable भरना
        For Each kvp In groups
            Dim parts() As String = kvp.Key.Split("|"c)
            Dim row As DataRow = dtResult.NewRow()
            row("AccountCode") = parts(0)
            row("ITEMCODE") = parts(1)
            row("Rate") = Convert.ToDecimal(parts(2))
            row("Mtr_Weight") = kvp.Value
            row("entryno") = 0
            dtResult.Rows.Add(row)
        Next

        Dim dv As New DataView(dtResult)
        dv.Sort = "AccountCode ASC"
        dtResult = dv.ToTable()

        For Each DR As DataRow In dtResult.Select

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT TOP 1 ENTRYNO FROM TRNOFFER ")
                .Append(" WHERE BOOKCODE='" & _YarnPurBookcode & "'  ")
                .Append(" AND LOOM_TYPE= '" & _BookVNo & "' ")
                .Append(" AND ACCOUNTCODE= '" & DR("AccountCode").ToString & "' ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                DR("ENTRYNO") = DefaltSoftTable.Rows(0).Item("ENTRYNO")
            End If

        Next



        sqL = "DELETE FROM TRNOFFER WHERE 1=1 And LOOM_TYPE ='" & _BookVNo & "'"
        sql_Data_Save_Delete_Update()

        Dim _PlanBookVNo As String = ""
        Dim _OrderentryNo As Int64 = 0
        Dim Srno As Int64 = 1
        Dim _ACCOUNTCODE As String = ""

        Dim groupedAccounts = dtResult.AsEnumerable().GroupBy(Function(r) r.Field(Of String)("ACCOUNTCODE"))
        For Each grp In groupedAccounts
            _ACCOUNTCODE = grp.Key
            Srno = 1

            Dim _NewEntryNoCheck As Boolean = False

            For Each DR As DataRow In dtResult.Select(" accountcode ='" & _ACCOUNTCODE & "'")
                _ACCOUNTCODE = DR("ACCOUNTCODE")

                If DR("ENTRYNO") > 0 Then
                    _PlanBookVNo = Generate_Book_Vno(DR("ENTRYNO"), _YarnPurTrtype)
                    _OrderentryNo = DR("ENTRYNO")
                Else
                    If _NewEntryNoCheck = False Then
                        _MaxEntryNo += 1
                        _PlanBookVNo = Generate_Book_Vno(Val(_MaxEntryNo), _YarnPurTrtype)
                        _OrderentryNo = _MaxEntryNo
                        _NewEntryNoCheck = True
                    End If
                End If

                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" INSERT INTO TRNOFFER ( ")
                    .Append(" ENTRYNO")
                    .Append(" ,BookTrtype")
                    .Append(" ,BookVno")
                    .Append(" ,BookCode")
                    .Append(" ,OfferDate")
                    .Append(" ,SRNO")
                    .Append(" ,ItemCode")
                    .Append(" ,Descr")
                    .Append(" ,Mtr_Weight")
                    .Append(" ,OfferNo")
                    .Append(" ,ACCOUNTCODE")
                    .Append(" ,LOOM_TYPE")
                    .Append(" ,MONOGRAM_TYPE")
                    .Append(" ,CutCode")
                    .Append(" ,Rate")
                    .Append(" ,loomtype")
                    .Append(" ,LOTNO")
                    .Append(" ,clear")
                    .Append(" ,cancel_Qty")
                    .Append(" ,processcode")
                    .Append(" ,SELVCODE")
                    .Append(" ,ACOFCODE")
                    .Append(" ,DespatchCode")
                    .Append(" ,ShadeCode")
                    .Append(" ,TransportCode")
                    .Append(" ,SelvedgeName")
                    .Append(" ,AGENTCODE")
                    .Append(" ) VALUES (")
                    .Append(" '" & _OrderentryNo & "'")
                    .Append(" ,'" & _YarnPurTrtype & "'")
                    .Append(" ,'" & _PlanBookVNo & "'")
                    .Append(" ,'" & _YarnPurBookcode & "'")
                    .Append(" ,'" & txtOfferDate.Date_for_Database & "'")
                    .Append(" ,'" & Srno & "'")
                    .Append(" ,'" & DR("ITEMCODE").ToString & "'")
                    .Append(" ,'YARN PLANNING ENTRY'")
                    .Append(" ,'" & DR("Mtr_Weight").ToString & "'")
                    .Append(" ,'" & _OrderentryNo & "'")
                    .Append(" ,'" & DR("AccountCode").ToString & "'")
                    .Append(" ,'" & _BookVNo & "'")
                    .Append(" ,'" & txtEntryNo.Text & "'")
                    .Append(" ,'0000-000000007'")
                    .Append(" ,'" & DR("RATE").ToString & "'")
                    .Append(" ,'KGS'")
                    .Append(" ,'KGS'")
                    .Append(" ,'NO'")
                    .Append(" ,'0'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" ,'0000-000000001'")
                    .Append(" )")
                End With
                sqL = _strQuery.ToString
                sql_Data_Save_Delete_Update()

                Srno += 1

            Next
        Next



    End Sub
#End Region


#Region "VIEW RECORD "


    Private Sub View_Record()


        Dim View_Filter_Condition As String = ""
        Dim View_Order_By As String = ""

        'View_Filter_Condition = " AND TRNOFFER.BOOKCODE='" & Book_Code & "' AND TRNOFFER.OFFERDATE>='" & txt_From.Date_for_Database & "' AND TRNOFFER.OFFERDATE<='" & txt_To.Date_for_Database & "' "
        View_Filter_Condition = " AND A.BOOKCODE='" & Book_Code & "' "
        View_Order_By = " ORDER BY A.OFFERDATE,A.ENTRYNO,A.SRNO "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.BookVno, ")
            .Append(" A.ENTRYNO as [Entry No], ")
            .Append(" A.OfferNo as PlanningNo, ")
            .Append(" A.OfferDate AS Date, ")
            .Append(" A.SRNO as [Sno], ")
            .Append(" B.CountName, ")
            .Append(" A.Mtr_Weight as Quantity ")
            .Append(" FROM TRNOFFER AS A")
            .Append(" LEFT JOIN MstYarnCount  AS B ON  A.ITEMCODE=B.CountCode ")
            .Append(" WHERE 1=1 ")
            .Append(View_Filter_Condition)
            .Append(View_Order_By)
        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp = DefaltSoftTable.Copy

        FirstStage.Columns.Clear()

        If tblTmp.Rows.Count > 0 Then

            For Each dr As DataRow In tblTmp.Select
                Dim Qty As String = Format(dr("Quantity"), "0.00")
                dr("Quantity") = Qty
            Next

            GridControl1.DataSource = tblTmp.Copy

            FirstStage.GroupRowHeight = 30
            FirstStage.Columns("Entry No").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            FirstStage.Columns("Entry No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

            FirstStage.Columns("Quantity").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            FirstStage.Columns("Quantity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0}"))

            AlignGroupSummaryInGroupRow(GridControl1, FirstStage)
            FirstStage.Columns("BookVno").Visible = False

            DevGridFitColumn(GridControl1, FirstStage)

            PNL_View.BringToFront()
            PNL_View.Visible = True
            FirstStage.Focus()
            PNL_View.BringToFront()
            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If

    End Sub
    Public Sub AlignGroupSummaryInGroupRow(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        'gridView.Columns(CStr(("Bale No"))).Group()

        'Enable this option to move group footer summaries to group rows under corresponding column headers
        gridView.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        gridView.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Quantity", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = gridView.Columns("Quantity")})

        gridView.Appearance.GroupRow.BackColor = Color.LightGreen

    End Sub
#End Region

#Region "DATE RANGE CHECK"
    Private Sub txtOfferDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfferDate.Validated
        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information, "Soft-Tex PRO")
                txtOfferDate.Focus()
                txtOfferDate.Select()
            End If
        End If
    End Sub
#End Region
    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub


#Region "Book Entry"
    Private Sub GridControl1_EditorKeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        _SupplierInfo()

        If e.KeyCode = Keys.F2 Then
            'Dim CountCode As String = String.Empty
            'Dim val = GridView2.GetFocusedRowCellValue("CountCode")
            'If val IsNot Nothing AndAlso Not IsDBNull(val) Then
            '    CountCode = val.ToString()
            'End If
            'Dim whereClause = " AND D.CountCode ='" & _SlecteedCountCode & "'"
            'Dim _Loadquery = _GetPlanningQuery(whereClause)
            '_BookGrdSetting(_Loadquery)

            'Pnl_PlannimgSelection.Visible = True
            'Pnl_PlannimgSelection.BringToFront()
            'Txt_SupplierName.Focus()
            'Txt_SupplierName.SelectAll()

        End If
    End Sub

    Public Function GetPlanQuery() As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append(" A.AgentOfferNo AS PlanBookVno ")
            .Append(" ,a.ItemCode as CountCode   ")
            .Append(" ,a.Mtr_Weight as RequirQty ")
            .Append(" ,0.00  PlanQty ")
            .Append(" ,A.ACCOUNTCODE ")
            .Append(" FROM TrnOffer  AS A  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND DESCR in ('PURCHASE') ")
            .Append(" AND Bookcode='YRNPL-000000001'   ")
            .Append(" UNION ALL ")
            .Append(" SELECT  ")
            .Append(" A.AgentOfferNo AS PlanBookVno ")
            .Append(" ,a.ItemCode as CountCode   ")
            .Append(" ,0.00 as RequirQty ")
            .Append(" ,a.Mtr_Weight  PlanQty ")
            .Append(" ,A.ACCOUNTCODE ")
            .Append(" FROM TrnOffer  AS A  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND Bookcode='YRNPO-000000002'   ")
        End With
        Return _strQuery.ToString
    End Function
    Public Function _GetPlanningQuery(ByVal _FilterString As String)

        Dim getDefaltQuery As String = GetPlanQuery()

        _strQuery = New StringBuilder
        With _strQuery

            .Append(" SELECT ")
            .Append(" 'False' as TickMark ")
            .Append(" ,b.id as ENo ")
            .Append(" ,Z.PlanBookVno ")
            .Append(" ,FORMAT(CONVERT(datetime, B.PlanDate, 103), 'dd/MM/yyyy') AS Date ")
            .Append(" ,D.CountName  ")
            .Append(" ,z.CountCode  ")
            .Append(" ,z.ACCOUNTCODE  ")
            .Append(" ,C.AccountName  ")
            .Append(" ,sum(z.RequirQty )-SUM(z.PlanQty ) as RequirQty ")
            .Append(" ,0.00 as SelectQty  ")
            .Append(" FROM ( ")
            .Append(getDefaltQuery)
            .Append(" ) AS Z ")
            .Append(" LEFT JOIN MstYarnCount AS D ON z.CountCode=D.CountCode  ")
            .Append(" left join (SELECT ID,HSNCODE as PlanDate,ITEMNAME AS BOOKVNO FROM MstItemBatchWise GROUP BY ID,HSNCODE,ITEMNAME) AS B ON  B.BOOKVNO=Z.PlanBookVno  ")
            .Append(" left join MstMasterAccount AS C ON Z.ACCOUNTCODE=C.ACCOUNTCODE ")
            .Append(" WHERE 1=1")
            .Append(" and b.ID >0")
            .Append(_FilterString)
            .Append(" GROUP BY ")
            .Append(" B.ID ")
            .Append(" ,B.PlanDate ")
            .Append(" ,D.CountName  ")
            .Append(" ,z.CountCode  ")
            .Append(" ,z.PlanBookVno  ")
            .Append(" ,z.ACCOUNTCODE  ")
            .Append(" ,C.AccountName  ")
            .Append(" HAVING sum(z.RequirQty )-SUM(z.PlanQty )>0 ")
            .Append(" ORDER BY B.ID ")
        End With
        Return _strQuery.ToString
    End Function
    Private Sub _BookGrdSetting(ByVal _Loadquery As String)
        sqL = _Loadquery
        sql_connect_slect()
        Dim _TmpTbl As New DataTable
        _TmpTbl = DefaltSoftTable.Copy
        GridBooking.GridControl.DataSource = Nothing

        If _TmpTbl.Rows.Count = 0 Then
            MsgBox("No Pending Plan Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
        Else
            For Each dr As DataRow In _TmpTbl.Select
                dr("RequirQty") = SafeFormat(dr, "RequirQty", "0.00")
            Next

            GridBooking.Columns.Clear()
            GridControl4.DataSource = _TmpTbl.Copy


            Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = TryCast(GridControl4.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
            repositoryCheckEdit1.ValueChecked = "True"
            repositoryCheckEdit1.ValueUnchecked = "False"
            GridBooking.Columns("TickMark").ColumnEdit = repositoryCheckEdit1
            GridBooking.Columns("TickMark").Width = 30



            GridBooking.Columns("CountCode").Visible = False
            GridBooking.Columns("ACCOUNTCODE").Visible = False
            GridBooking.Columns("AccountName").Visible = False
            GridBooking.Columns("PlanBookVno").Visible = False


            ' पूरे grid को editable allow करो
            GridBooking.OptionsBehavior.Editable = True

            ' बाकी सभी columns को read-only करो
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridBooking.Columns
                col.OptionsColumn.AllowEdit = False
                col.OptionsColumn.ReadOnly = True
            Next

            ' सिर्फ SelectQty को editable allow करो
            With GridBooking.Columns("SelectQty")
                .OptionsColumn.AllowEdit = True
                .OptionsColumn.ReadOnly = False
            End With


            'DevGridFitColumn(GridControl4, GridBooking)
            GridBooking.Columns("RequirQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RequirQty", "{0}"))
            GridBooking.Appearance.FocusedRow.BackColor = GridBooking.Appearance.FocusedRow.BackColor.LightBlue

            AddHandler GridBooking.CellValueChanged, AddressOf GridBooking_CellValueChanged
            AddHandler GridBooking.RowUpdated, AddressOf GridBooking_RowUpdated


            GridBooking.Focus()
            'GridBooking.BestFitColumns()
            GridBooking.Columns("ENo").Width = 40
            GridBooking.Columns("Date").Width = 70
            GridBooking.Columns("CountName").Width = 90
            GridBooking.Columns("RequirQty").Width = 60
            GridBooking.Columns("SelectQty").Width = 60
            GridBooking.FocusedRowHandle = GridBooking.GetVisibleRowHandle(0)
        End If
    End Sub
    Private Sub GridBooking_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        If e.Column.FieldName = "SelectQty" Then
            UpdateSelectQtyTotal()
        End If
    End Sub
    Private Sub GridBooking_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs)
        UpdateSelectQtyTotal()
    End Sub
    Private Sub UpdateSelectQtyTotal()
        Dim total As Decimal = 0

        'For i As Integer = 0 To GridBooking.RowCount - 1
        '    Dim val = GridBooking.GetRowCellValue(i, "SelectQty")
        '    If val IsNot Nothing AndAlso IsNumeric(val) Then
        '        total += Convert.ToDecimal(val)
        '    End If
        'Next

        'LblFeelQty.Text = total.ToString("0.00")

    End Sub
    Private Sub GridControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles GridControl1.MouseClick
        _SupplierInfo()
    End Sub
    Private Sub _SupplierInfo()
        Txt_SupplierName.Text = ""
        txtSupplierCode.Text = ""
        LblFeelQty.Text = "0.00"
        TxtRate.Text = "0.00"
        Dim CountCode As String = String.Empty
        Dim val = GridView2.GetFocusedRowCellValue("PartyName")
        If val IsNot Nothing AndAlso Not IsDBNull(val) Then
            Txt_SupplierName.Text = val.ToString()
            txtSupplierCode.Text = GridView2.GetFocusedRowCellValue("ACCOUNTCODE")
            CountCode = GridView2.GetFocusedRowCellValue("CountCode")
        End If
    End Sub

    Private Sub Txt_SupplierName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_SupplierName.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim AccountName As String = Txt_SupplierName.Text
            Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
            Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), AccountName, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("AccountName") Then Txt_SupplierName.Text = selected("AccountName").ToString()
                If selected.ContainsKey("ACCOUNTCODE") Then txtSupplierCode.Text = selected("ACCOUNTCODE").ToString()
            End If
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub _FeeldataGridItem()
        _GetTotal()

        Dim feelQty As Decimal = 0
        Dim purchaseQty As Decimal = 0

        Decimal.TryParse(LblFeelQty.Text, feelQty)
        Decimal.TryParse(Txt_RequreQty.Text, purchaseQty)


        If Txt_SupplierName.Text = "" Then
            MsgBox("Selct Supplier", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Txt_SupplierName.Focus()
            Txt_SupplierName.SelectAll()
            Exit Sub
        End If

        If feelQty <> purchaseQty Then
            MsgBox("Pur Qty Or Selected Qty Mis Match", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Exit Sub
        End If


        If GridBooking.IsEditing Then
            GridBooking.PostEditor()
        End If
        GridBooking.ActiveFilter.Clear()
        Dim Blnk_Row_No As Int64 = 0

        Blnk_Row_No = GrdItem.Rows - 1

        If TxtRate.Text = "" Then TxtRate.Text = "0.00"

        Dim _ExtraYarnQty As Double = Val(Txt_PurchaseQty.Text) - Val(Txt_RequreQty.Text)


        Dim _Countcode As String = ""
        Dim _CountName As String = ""



        For i As Int64 = 0 To GridBooking.RowCount - 1
            If GridBooking.GetRowCellValue(i, "SelectQty") > 0 Then
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("OFFERNO") + 1).Text = Convert.ToString(GridBooking.GetRowCellValue(i, "ENo"))
                'GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = txtSupplierCode.Text
                'GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = Txt_SupplierName.Text

                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = txtSupplierCode.Text
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = GridBooking.GetRowCellValue(i, "ACCOUNTCODE").ToString
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = GridBooking.GetRowCellValue(i, "AccountName").ToString
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("AgentOfferNo") + 1).Text = GridBooking.GetRowCellValue(i, "PlanBookVno").ToString


                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = GridBooking.GetRowCellValue(i, "CountCode").ToString
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = GridBooking.GetRowCellValue(i, "CountName").ToString
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text = TxtRate.Text
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = GridBooking.GetRowCellValue(i, "SelectQty").ToString
                GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = Blnk_Row_No
                _CountName = GridBooking.GetRowCellValue(i, "CountName").ToString
                _Countcode = GridBooking.GetRowCellValue(i, "CountCode").ToString
                GrdItem.Rows = GrdItem.Rows + 1
                Blnk_Row_No += 1
            End If

        Next

        If _ExtraYarnQty > 0 Then
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("OFFERNO") + 1).Text = "0"
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("TransportCode") + 1).Text = txtSupplierCode.Text
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ACCOUNTCODE") + 1).Text = txtSupplierCode.Text
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ACCOUNTNAME") + 1).Text = Txt_SupplierName.Text
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = _Countcode
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = _CountName
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text = TxtRate.Text
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("MTR_WEIGHT") + 1).Text = _ExtraYarnQty
            GrdItem.Cell(Blnk_Row_No, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = Blnk_Row_No
            GrdItem.Rows = GrdItem.Rows + 1
            Blnk_Row_No += 1
        End If



        'Pnl_PlannimgSelection.Visible = False
        GridView2.Focus()
        Call Total_Upto_All_Grid_All_Row()
    End Sub

    Private Sub GridControl4_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl4.KeyDown
        If e.KeyCode = Keys.Space Then

            If GridBooking.GetFocusedRowCellValue("TickMark") = "" Then
                GridBooking.SetRowCellValue(GridBooking.FocusedRowHandle, "TickMark", "True")
                Dim _ReqQty As Double = GridBooking.GetRowCellValue(GridBooking.FocusedRowHandle, "RequirQty")
                If Val(GridBooking.GetRowCellValue(GridBooking.FocusedRowHandle, "SelectQty")) = 0 Then
                    GridBooking.SetRowCellValue(GridBooking.FocusedRowHandle, "SelectQty", _ReqQty)
                End If
            ElseIf GridBooking.GetFocusedRowCellValue("TickMark") = "True" Then
                GridBooking.SetRowCellValue(GridBooking.FocusedRowHandle, "TickMark", "False")
                GridBooking.SetRowCellValue(GridBooking.FocusedRowHandle, "SelectQty", "0.00")
            ElseIf GridBooking.GetFocusedRowCellValue("TickMark") = "False" Then
                GridBooking.SetRowCellValue(GridBooking.FocusedRowHandle, "TickMark", "True")
                Dim _ReqQty As Double = GridBooking.GetRowCellValue(GridBooking.FocusedRowHandle, "RequirQty")
                If Val(GridBooking.GetRowCellValue(GridBooking.FocusedRowHandle, "SelectQty")) = 0 Then
                    GridBooking.SetRowCellValue(GridBooking.FocusedRowHandle, "SelectQty", _ReqQty)
                End If
            End If
            _GetTotal()


        ElseIf e.KeyCode = Keys.F11 Then
            For i As Int64 = 0 To GridBooking.RowCount - 1
                If GridBooking.GetRowCellValue(i, "TickMark").ToString = True Then
                    GridBooking.SetRowCellValue(i, "TickMark", "False")
                Else
                    GridBooking.SetRowCellValue(i, "TickMark", "True")
                End If
            Next
        ElseIf e.KeyCode = Keys.F12 Then
            GridBooking.ActiveFilter.Clear()
            _GetTotal()

        End If
    End Sub

    Private Sub _GetTotal()
        Dim total As Decimal = 0
        'SendKeys.Send("{TAB}")
        For i As Integer = 0 To GridBooking.RowCount - 1
            If GridBooking.GetRowCellValue(i, "TickMark") = True Then
                Dim val = GridBooking.GetRowCellValue(i, "SelectQty")
                If val IsNot Nothing AndAlso IsNumeric(val) Then
                    total += Convert.ToDecimal(val)
                End If
            End If

        Next
        total = Convert.ToDecimal(total)
        LblFeelQty.Text = total.ToString("0.00")
    End Sub
#End Region


End Class