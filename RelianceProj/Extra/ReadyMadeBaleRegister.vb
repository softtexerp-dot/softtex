Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports DevExpress.XtraGrid
Imports DevExpress.XtraRichEdit.Model
Imports ExcelDataReader
Friend Class ReadyMadeBaleRegister
    Private obj_Party_Selection As New Multi_Selection_Master
    Dim _BaleStkQty As Double = 0
#Region "FORM LOAD"

    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Coral
    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function
    Public Sub New()
        InitializeComponent()
        Me.GetAllControls(Me).OfType(Of Button)().ToList() _
          .ForEach(Sub(b)
                       b.Tag = Tuple.Create(b.ForeColor, b.BackColor)
                       AddHandler b.GotFocus, AddressOf b_GotFocus
                       AddHandler b.LostFocus, AddressOf b_LostFocus
                   End Sub)
    End Sub
    Private Sub b_LostFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, Button)
        Dim colors = DirectCast(b.Tag, Tuple(Of Color, Color))
        b.ForeColor = colors.Item1
        b.BackColor = colors.Item2
    End Sub
    Private Sub b_GotFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, Button)
        b.ForeColor = focusedForeColor
        b.BackColor = focusedBackColor
    End Sub


#End Region

#Region "GRID STRING BUILDER VARIABLE "
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
    Private _ActivatedColName_Out As String = ""
    Private _RowNo As Integer = 0
    Private _ColNo As Integer = 0
    Private _GridLastColNo As Integer = 0
    Private _LastRow As Integer = 0
    Private _Last_Saved_Entry_No As Integer = 0
    Private _isCallerByOther As Boolean = False
    Private _old_Me_text As String = ""
    Private Last_Focused_Btn As String = ""
    Private _AllowMoveFromCell As Boolean = True
    Private WithEvents Txt_Dt As New ctl_TextBox.ctl_TextBox
    Private WithEvents txt_Name_For_Grid_Selection As New TextBox
    Private WithEvents txt_Code_For_Grid_Selection As New TextBox
    Private WithEvents txtAcOfCode As New TextBox
    Private WithEvents txtBookCode As New TextBox
    Private WithEvents txtSelvCode As New TextBox
    Private WithEvents txtLoomTypeCode As New TextBox
    Private WithEvents txtWeaveTypeCode As New TextBox
    Private WithEvents txtDeleviryCode As New TextBox
    Private WithEvents txtIamgePath As New TextBox
    Private WithEvents HEADERITEMCODE As New TextBox

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
    Private _ITEMBOOKVNO As String = ""
    Private _ITEMDESC As String = ""

    Private _ItmBillNo As String = ""
    Private _ItmBillRate As String = ""
    Private _ItmBillPartyName As String = ""
    Private _ItmBillCaseNo As String = ""
#End Region

#Region "GRID COL. DEFINE AND FORMATTING "
    Private Sub defineGridColName()
        _GridColNames = New StringBuilder
        With _GridColNames
            .Append("ID,")
            .Append("ENTRYNO,")
            .Append("BOOKTRTYPE,")
            .Append("BOOKVNO,")
            .Append("BOOKCODE,")
            .Append("CHALLAN_NO,")
            .Append("CHALLAN_DATE,")
            .Append("VECHNO,")
            .Append("SRNO,")
            .Append("ITEMNAME,")
            .Append("DESIGNNAME,")
            .Append("ITEMCODE,")
            .Append("SHADECODE,")
            .Append("SHADENAME,")
            .Append("DESCR,")
            .Append("SIZE,")
            .Append("COLOUR,")
            .Append("BATCHNO,")
            .Append("QTY,")
            .Append("HEADERREMARK,")
            .Append("ROWREMARK,")
            .Append("SIZECODE,")
            .Append("DESIGNCODE,")
            .Append("COLORCODE")
        End With

        _GridColType = New StringBuilder
        With _GridColType
            .Append("SRNO:N,")
            .Append("QTY:N")
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
            .Append("ITEMNAME:Group Name,")
            .Append("DESIGNNAME:Item Name,")
            .Append("SHADENAME:Sub Name,")
            .Append("SIZE:Size,")
            .Append("COLOUR:Color,")
            .Append("BATCHNO:Bale No,")
            .Append("DESCR:Category,")
            .Append("QTY:Qty,")
            .Append("ROWREMARK:Remark")
        End With

        _FieldHeaderAlignment = New StringBuilder
        With _FieldHeaderAlignment
            .Append("SRNO:L,")
            .Append("COLOUR:L,")
            .Append("SIZE:C,")
            .Append("ITEMNAME:L,")
            .Append("DESIGNNAME:L,")
            .Append("SHADECODE:L,")
            .Append("SHADENAME:L,")
            .Append("BATCHNO:L,")
            .Append("DESCR:L,")
            .Append("QTY:R,")
            .Append("ROWREMARK:L")
        End With

        _FieldAlignMent = New StringBuilder
        With _FieldAlignMent
            .Append("SRNO:L,")
            .Append("ITEMNAME:L,")
            .Append("DESIGNNAME:L,")
            .Append("COLOUR:L,")
            .Append("SIZE:C,")
            .Append("BATCHNO:L,")
            .Append("SHADECODE:L,")
            .Append("SHADENAME:L,")
            .Append("DESCR:L,")
            .Append("QTY:R,")
            .Append("ROWREMARK:L")
        End With

        _FieldNotVisibile = New StringBuilder
        With _FieldNotVisibile
            .Append("ID:N,")
            .Append("ENTRYNO:N,")
            .Append("BOOKTRTYPE:N,")
            .Append("BOOKVNO:N,")
            .Append("BOOKCODE:N,")
            .Append("CHALLAN_NO:N,")
            .Append("CHALLAN_DATE:N,")
            .Append("VECHNO:N,")
            .Append("ITEMNAME:Y,")
            .Append("ITEMCODE:N,")
            .Append("COLOUR:Y,")
            .Append("DESIGNNAME:Y,")
            .Append("HEADERREMARK:N,")
            .Append("SHADECODE:N,")
            .Append("SHADENAME:Y,")
            .Append("SRNO:Y,")
            .Append("SIZE:Y,")
            .Append("BATCHNO:Y,")
            .Append("DESCR:Y,")
            .Append("QTY:Y,")
            .Append("SIZECODE:N,")
            .Append("COLORCODE:N,")
            .Append("DESIGNCODE:N,")
            .Append("ROWREMARK:Y")
        End With
        _FieldNotRequiredForSave = New StringBuilder
        With _FieldNotRequiredForSave
            .Append("ID:N,")
            .Append("ITEMNAME:N,")
            .Append("DESIGNNAME:N,")
            .Append("SHADENAME:N,")
            .Append("SIZE:N,")
            .Append("SHADENAME:N,")
            .Append("COLOUR:N")
        End With



        _FieldWidthSet = New StringBuilder
        With _FieldWidthSet
            .Append("SRNO:3,")
            .Append("ITEMNAME:12,")
            .Append("SIZE:6,")
            .Append("COLOUR:9,")
            .Append("SHADENAME:15,")
            .Append("BATCHNO:10,")
            .Append("DESCR:12,")
            .Append("QTY:8,")
            .Append("DESIGNNAME:12,")
            .Append("ROWREMARK:12")
        End With

        _FieldDefaultValues = New StringBuilder
        With _FieldDefaultValues
            .Append("SRNO:0,")
            .Append("QTY:0")
        End With

        _FieldLocked = New StringBuilder
        With _FieldLocked
            .Append("SRNO:Y")
        End With



        _FieldMasking = New StringBuilder
        With _FieldMasking
            .Append("QTY:NO-2")
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

    Private WithEvents txtAccount_Code As New TextBox
    Private WithEvents txtDespatch_code As New TextBox
    Private WithEvents txtTransport_code As New TextBox
    Private WithEvents txtItem_code As New TextBox
    Private WithEvents txtDesign_code As New TextBox
    Private WithEvents txtShade_code As New TextBox
    Private WithEvents txtProdItmCode_code As New TextBox


    Private DispList As Boolean = False

    Private _ErrorValue As String = ""
    Private _FORMMODE As String = ""
    Private _KeyFieldName As String = "BOOKVNO"
    Private _KeyFieldValue As String = ""
    Private _OfferTableName As String = "TrnReadyMadeProducation"
    Private _ErrorMessage As String = ""
    Private _NewAddedRow As Boolean = False
    Private SRNO As Integer = 1
    Private _TransctionNo As Integer = 0
    Private _LastEntryNo As Integer = 0
    Private _TmpDataTable As New DataTable
    Private _BookTrType As String = "READY1"
    Private _BookCode As String = "READY-000000001"
    Private _BookVNo As String = ""
    Private _TmpDataRow As DataRow
    Private Change_Grid_Data As Boolean = True
#End Region
#Region "FORM VALIDATION"
    Private Function Validate_Form_Values() As Boolean
        Validate_Form_Values = False


        If txtChallan_Date.Text = "  /  /    " Then
            MsgBox("Invalid Challan Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtChallan_Date.Focus()
            Exit Function
        ElseIf Trim(txtChallanNo.Text) = "" Then
            MsgBox("Invalid Challan No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtChallanNo.Focus()
            Exit Function
        ElseIf Trim(txtEntryNo.Text) = "" Or Val(txtEntryNo.Text) = 0 Then
            MsgBox("Invalid Entry No.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            Exit Function
            'ElseIf Trim(txtAccountName.Text) = "" Then
            '    MsgBox("Invalid Account Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            '    txtAccountName.Focus()
            '    Exit Function
            'ElseIf Trim(Txt_ItemName.Text) = "" Then
            '    MsgBox("Invalid Item Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            '    Txt_ItemName.Focus()
            '    Exit Function
            'ElseIf Trim(Txt_ProdItemName.Text) = "" Or Val(Txt_ProdItemName.Text) = 0 Then
            '    MsgBox("Invalid Producation Item Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            '    Txt_ProdItemName.Focus()
            '    Exit Function

            'ElseIf Trim(Txt_TotalMtr.Text) = "" Or Val(Txt_TotalMtr.Text) = 0 Then
            '    MsgBox("Invalid Mtr", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            '    Txt_TotalMtr.Focus()
            '    Exit Function

        Else
            Validate_Form_Values = True
        End If
    End Function
#End Region
#Region "FORM EVENTS "
    Private Sub Yarn_Packing_Slip_Entry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim _STRTRNOBJECT As String = ""
        _STRTRNOBJECT = ActivatedControl(Me)

        If e.KeyCode = Keys.Delete And _FrmLoad = False Then
            Dim Txt_Box_Name As String = _STRTRNOBJECT.ToString.ToUpper
            If Txt_Box_Name = "TXTACCOUNTNAME" Or Txt_Box_Name = "TXTACOFNAME" _
                Or Txt_Box_Name = "TXTTRANSPORTNAME" Or Txt_Box_Name = "TXTDESPATCH" Then
                SendKeys.Send("{BKSP}")
            End If
        End If
#Region "Import Excel Option"
        If Txt_EntryType.Text = "INWARD" Then
            If e.Control AndAlso e.KeyCode = Keys.I Then
                PanlPropartiesWindow.Visible = Not PanlPropartiesWindow.Visible
                BtnBrowseExcel.Focus()
                e.SuppressKeyPress = True
            End If
        End If
#End Region
        If e.KeyCode = Keys.Escape Then
            _FrmLoad = True
            'If Pnl_Common_Work.Visible = True Then
            '    Pnl_Common_Work.Visible = False
            '    Txt_HeaderMtr.Focus()
            '    Txt_HeaderMtr.Select()
            'End If
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
                If PanlPropartiesWindow.Visible = True Then
                    PanlPropartiesWindow.Visible = False
                    'Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                    Exit Sub
                End If
                Select Case _STRTRNOBJECT
                    Case "GRDOUTS"
                        GrdItem.Focus()
                        GrdItem.Select()
                    Case "GRDITEM"
                        _FrmLoad = True
                        'Total_Upto_All_Grid_All_Row()
                        GrdItem.BoldFixedCell = False
                        txtEntryNo.Focus()
                    Case "TERM1"
                        txtEntryNo.Focus()
                    Case "TXTCHALLAN_DATE"
                        _FrmLoad = True
                        txtChallan_Date.Text = ObjCls_General.GetTodayDate_British
                        _FORMMODE = ""
                        Old_Date = txtChallan_Date.Text
                        ObjCls_General.Blank_Object(Me)
                        txtChallan_Date.Text = Old_Date
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
                        Old_Date = txtChallan_Date.Text
                        ObjCls_General.Blank_Object(Me)
                        txtChallan_Date.Text = Old_Date
                        Clear_Grid(GrdItem, 2)
                        'Label_Value_Nil_Rest()
                        _KeyFieldValue = 0
                        Call Command_Button_Visibility("LOAD")
                        'PictureBox1.Image = Textile.My.Resources.Resources.download
                        Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                        GrdItem.BoldFixedCell = False
                        _FrmLoad = False
                End Select
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
                    'If Val(Lbl_Tot_Net_Weight.Text) = 0 Then
                    '    MsgBox("Blank Item Detail, Can't Save", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    '    Exit Sub
                    'Else
                    _FrmLoad = True
                    'Total_Upto_All_Grid_All_Row()
                    GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                    btnSave.Focus()
                    btnSave.Select()
                    'End If
                Case "BTNSAVE"
                    txtEntryNo.Focus()
                Case "TXT_BALE_WEIGHT"

                Case Else
                    If txtEntryNo.Text = "" Or Val(txtEntryNo.Text) = 0 Then
                        txtEntryNo.Focus()
                    ElseIf txtChallan_Date.Text = "  /  /    " Then
                        txtChallan_Date.Focus()
                    Else
                        _FrmLoad = True
                        GrdItem.Cell(1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
                        GrdItem.Focus()
                        GrdItem.Select()
                        'GrdItem.ActiveCell.BackColor = Color.Transparent
                    End If
            End Select
        ElseIf e.KeyCode = Keys.F3 Then
            Select Case _STRTRNOBJECT
                Case "GRDITEM"
                    _FrmLoad = True
                    Delete_Row(GrdItem, _DataTableGrid)
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = ""
                    'Total_Upto_All_Grid_All_Row()
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
#Region "Import Excel Control"
    Private Sub BtnBrowseExcel_Click(sender As Object, e As EventArgs) Handles BtnBrowseExcel.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "Select Excel File"
            ofd.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls"
            If ofd.ShowDialog() = DialogResult.OK Then
                Dim txtFile As Control = FindControlRecursive(PanlPropartiesWindow, "TxtExcelFileName")
                If txtFile IsNot Nothing Then
                    txtFile.Text = ofd.FileName
                    ImportExcelData()
                End If
            End If
        End Using
    End Sub
    Private Function FindControlRecursive(parent As Control, controlName As String) As Control
        If parent Is Nothing Then Return Nothing
        Dim found As Control = parent.Controls(controlName)
        If found IsNot Nothing Then Return found
        For Each child As Control In parent.Controls
            found = FindControlRecursive(child, controlName)
            If found IsNot Nothing Then Return found
        Next
        Return Nothing
    End Function

    Private Sub ImportExcelData()
        Dim txtFile As Control = FindControlRecursive(PanlPropartiesWindow, "TxtExcelFileName")
        If txtFile Is Nothing OrElse String.IsNullOrWhiteSpace(txtFile.Text) Then
            MsgBox("Please select Excel file first.", "Soft-Tex PRO")
            Return
        End If
        If Not File.Exists(txtFile.Text) Then
            MsgBox("Excel file not found.", "Soft-Tex PRO")
            Return
        End If
        Try
            Dim excelTable As New DataTable()
            Using stream As FileStream = File.Open(txtFile.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)
                    Dim config As New ExcelDataSetConfiguration With {.ConfigureDataTable = Function(__) New ExcelDataTableConfiguration With {.UseHeaderRow = True}}
                    Dim ds As DataSet = reader.AsDataSet(config)
                    If ds.Tables.Count = 0 Then
                        MsgBox("Excel sheet mein data nahi hai.")
                        Return
                    End If
                    excelTable = ds.Tables(0).Copy()
                End Using
            End Using
            ' Master tables load karke codes set karein
            'SetExcelMasterCodes(excelTable)
            Dim isMasterValid As Boolean = SetExcelMasterCodes(excelTable)
            If Not isMasterValid Then
                Return
            End If
            ' Excel data ko FlexCell grid mein import karein
            ImportExcelToGrdItem(excelTable)
        Catch ex As Exception
            MsgBox("Excel Import Error: " & ex.Message, "Soft-Tex PRO")
        End Try
    End Sub
    Private Function SetExcelMasterCodes(ByVal dt As DataTable) As Boolean
        Try
            ' Excel header spaces/case normalize karne ke liye
            Dim GetColumnName As Func(Of DataTable, String, String) =
            Function(tbl As DataTable, requiredName As String) As String
                For Each col As DataColumn In tbl.Columns
                    If String.Equals(col.ColumnName.Trim().Replace(" ", "").Replace("_", ""), requiredName.Trim().Replace(" ", "").Replace("_", ""), StringComparison.OrdinalIgnoreCase) Then
                        Return col.ColumnName
                    End If
                Next
                Return Nothing
            End Function
            ' Excel ke name columns
            Dim designNameCol As String = GetColumnName(dt, "GroupName")
            Dim itemNameCol As String = GetColumnName(dt, "ItemName")
            Dim shadeNameCol As String = GetColumnName(dt, "SubName")
            Dim colorNameCol As String = GetColumnName(dt, "Color")
            Dim sizeNameCol As String = GetColumnName(dt, "Size")
            ' Required columns validation
            If designNameCol Is Nothing Then
                MsgBox("Excel mein 'Design Name' column nahi mila.")
                Return False
            End If
            If itemNameCol Is Nothing Then
                MsgBox("Excel mein 'ItemName' column nahi mila.")
                Return False
            End If
            If shadeNameCol Is Nothing Then
                MsgBox("Excel mein 'ShadeName' column nahi mila.")
                Return False
            End If
            If colorNameCol Is Nothing Then
                MsgBox("Excel mein 'ColorName' column nahi mila.")
                Return False
            End If
            If sizeNameCol Is Nothing Then
                MsgBox("Excel mein 'SizeName' column nahi mila.")
                Return False
            End If
            ' Code columns add karein
            Dim codeColumns As String() = {"DESIGNCODE", "ITEMCODE", "SHADECODE", "COLORCODE", "SIZECODE"}
            For Each colName As String In codeColumns
                If Not dt.Columns.Contains(colName) Then
                    dt.Columns.Add(colName, GetType(String))
                End If
            Next
            ' 1. GROUP MASTER
            sqL = "SELECT GroupCode, GroupName FROM MstStoreItemGroup"
            sql_connect_slect()
            Dim designTable As DataTable = DefaltSoftTable.Copy
            ' 2. ITEM MASTER
            sqL = "SELECT ItemCode, ItemName FROM MstStoreItem"
            sql_connect_slect()
            Dim itemTable As DataTable = DefaltSoftTable.Copy
            ' 3. SHADE MASTER
            sqL = "SELECT Subitemcode As ShadeCode, subitemName As ShadeName FROM MstStoreSubItem"
            sql_connect_slect()
            Dim shadeTable As DataTable = DefaltSoftTable.Copy
            ' 4. COLOR MASTER
            sqL = "SELECT ColorName, ColorCode FROM MstColor"
            sql_connect_slect()
            Dim colorTable As DataTable = DefaltSoftTable.Copy
            ' 5. SIZE MASTER
            sqL = "SELECT SizeCode, SizeName FROM MstSize"
            sql_connect_slect()
            Dim sizeTable As DataTable = DefaltSoftTable.Copy
            ' DESIGN LOOKUP
            Dim designLookup As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            For Each masterRow As DataRow In designTable.Rows
                If Not IsDBNull(masterRow("GroupName")) AndAlso Not IsDBNull(masterRow("GroupCode")) Then
                    Dim key As String = masterRow("GroupName").ToString().Trim()
                    Dim code As String = masterRow("GroupCode").ToString().Trim()
                    If key <> "" AndAlso Not designLookup.ContainsKey(key) Then
                        designLookup.Add(key, code)
                    End If
                End If
            Next
            ' ITEM LOOKUP
            Dim itemLookup As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            For Each masterRow As DataRow In itemTable.Rows
                If Not IsDBNull(masterRow("ItemName")) AndAlso
               Not IsDBNull(masterRow("ItemCode")) Then
                    Dim key As String = masterRow("ItemName").ToString().Trim()
                    Dim code As String = masterRow("ItemCode").ToString().Trim()
                    If key <> "" AndAlso Not itemLookup.ContainsKey(key) Then
                        itemLookup.Add(key, code)
                    End If
                End If
            Next
            ' SHADE LOOKUP
            Dim shadeLookup As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            For Each masterRow As DataRow In shadeTable.Rows
                If Not IsDBNull(masterRow("ShadeName")) AndAlso Not IsDBNull(masterRow("ShadeCode")) Then
                    Dim key As String = masterRow("ShadeName").ToString().Trim()
                    Dim code As String = masterRow("ShadeCode").ToString().Trim()
                    If key <> "" AndAlso Not shadeLookup.ContainsKey(key) Then
                        shadeLookup.Add(key, code)
                    End If
                End If
            Next
            ' COLOR LOOKUP
            Dim colorLookup As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            For Each masterRow As DataRow In colorTable.Rows
                If Not IsDBNull(masterRow("ColorName")) AndAlso Not IsDBNull(masterRow("ColorCode")) Then
                    Dim key As String = masterRow("ColorName").ToString().Trim()
                    Dim code As String = masterRow("ColorCode").ToString().Trim()
                    If key <> "" AndAlso Not colorLookup.ContainsKey(key) Then
                        colorLookup.Add(key, code)
                    End If
                End If
            Next
            ' SIZE LOOKUP
            Dim sizeLookup As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
            For Each masterRow As DataRow In sizeTable.Rows
                If Not IsDBNull(masterRow("SizeName")) AndAlso Not IsDBNull(masterRow("SizeCode")) Then
                    Dim key As String = masterRow("SizeName").ToString().Trim()
                    Dim code As String = masterRow("SizeCode").ToString().Trim()
                    If key <> "" AndAlso Not sizeLookup.ContainsKey(key) Then
                        sizeLookup.Add(key, code)
                    End If
                End If
            Next
            ' Excel rows mein master codes fill karein
            Dim RowNo As Integer = 1
            For Each dr As DataRow In dt.Rows
                Dim designName As String = If(IsDBNull(dr(designNameCol)), "", dr(designNameCol).ToString().Trim())
                Dim itemName As String = If(IsDBNull(dr(itemNameCol)), "", dr(itemNameCol).ToString().Trim())
                Dim shadeName As String = If(IsDBNull(dr(shadeNameCol)), "", dr(shadeNameCol).ToString().Trim())
                Dim colorName As String = If(IsDBNull(dr(colorNameCol)), "", dr(colorNameCol).ToString().Trim())
                Dim sizeName As String = If(IsDBNull(dr(sizeNameCol)), "", dr(sizeNameCol).ToString().Trim())
                ' Blank value validation
                Dim blankFields As New List(Of String)
                If designName = "" Then blankFields.Add("GroupName")
                If itemName = "" Then blankFields.Add("ItemName")
                If shadeName = "" Then blankFields.Add("SubName")
                If colorName = "" Then blankFields.Add("Color")
                If sizeName = "" Then blankFields.Add("Size")
                If blankFields.Count > 0 Then
                    MessageBox.Show("Excel Row: " & RowNo.ToString() & vbCrLf & vbCrLf & "The following required fields are blank:" & vbCrLf & String.Join(", ", blankFields) & vbCrLf & vbCrLf & "Please fill in the missing values and try again.", "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                ' Master matching validation
                If Not designLookup.ContainsKey(designName) Then
                    MessageBox.Show("Design/Group '" & designName & "' was not found in the master list." & vbCrLf & "Excel Row: " & (RowNo), "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                If Not itemLookup.ContainsKey(itemName) Then
                    MessageBox.Show("Item Name '" & itemName & "' was not found in the master list." & vbCrLf & "Excel Row: " & (RowNo), "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                If Not shadeLookup.ContainsKey(shadeName) Then
                    MessageBox.Show("Shade/Sub Item '" & shadeName & "' was not found in the master list." & vbCrLf & "Excel Row: " & (RowNo), "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                If Not colorLookup.ContainsKey(colorName) Then
                    MessageBox.Show("Color '" & colorName & "' was not found in the master list." & vbCrLf & "Excel Row: " & (RowNo), "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                If Not sizeLookup.ContainsKey(sizeName) Then
                    MessageBox.Show("Size '" & sizeName & "' was not found in the master list." & vbCrLf & "Excel Row: " & (RowNo), "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If


                Dim masterCode As String = ""
                ' GROUP CODE
                If designLookup.TryGetValue(designName, masterCode) Then
                    'dr("ITEMCODE") = masterCode
                    masterCode = designLookup(designName)
                    dr("ITEMCODE") = masterCode
                End If
                Dim colIndex As Integer = _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1
                If colIndex > 0 AndAlso colIndex < GrdItem.Cols Then
                    If RowNo >= 0 AndAlso RowNo < GrdItem.Rows Then
                        Dim gridCell = GrdItem.Cell(RowNo, colIndex)
                        If gridCell IsNot Nothing Then
                            gridCell.Text = masterCode
                        End If
                    End If
                End If
                ' ITEM CODE
                If itemLookup.TryGetValue(itemName, masterCode) Then
                    'dr("DESIGNCODE") = masterCode
                    masterCode = itemLookup(itemName)
                    dr("DESIGNCODE") = masterCode
                End If
                colIndex = _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1
                If colIndex > 0 AndAlso colIndex < GrdItem.Cols Then
                    If RowNo >= 0 AndAlso RowNo < GrdItem.Rows Then
                        Dim gridCell = GrdItem.Cell(RowNo, colIndex)
                        If gridCell IsNot Nothing Then
                            gridCell.Text = masterCode
                        End If
                    End If
                End If
                ' SHADE CODE
                If shadeLookup.TryGetValue(shadeName, masterCode) Then
                    'dr("SHADECODE") = masterCode
                    masterCode = shadeLookup(shadeName)
                    dr("SHADECODE") = masterCode
                End If
                colIndex = _DataTableGrid.Columns.IndexOf("SHADECODE") + 1
                If colIndex > 0 AndAlso colIndex < GrdItem.Cols Then
                    If RowNo >= 0 AndAlso RowNo < GrdItem.Rows Then
                        Dim gridCell = GrdItem.Cell(RowNo, colIndex)
                        If gridCell IsNot Nothing Then
                            gridCell.Text = masterCode
                        End If
                    End If
                End If
                ' COLOR CODE
                If colorLookup.TryGetValue(colorName, masterCode) Then
                    'dr("COLORCODE") = masterCode
                    masterCode = colorLookup(colorName)
                    dr("COLORCODE") = masterCode
                End If
                colIndex = _DataTableGrid.Columns.IndexOf("COLORCODE") + 1
                If colIndex > 0 AndAlso colIndex < GrdItem.Cols Then
                    If RowNo >= 0 AndAlso RowNo < GrdItem.Rows Then
                        Dim gridCell = GrdItem.Cell(RowNo, colIndex)
                        If gridCell IsNot Nothing Then
                            gridCell.Text = masterCode
                        End If
                    End If
                End If
                ' SIZE CODE
                If sizeLookup.TryGetValue(sizeName, masterCode) Then
                    'dr("SIZECODE") = masterCode
                    masterCode = sizeLookup(sizeName)
                    dr("SIZECODE") = masterCode
                End If
                colIndex = _DataTableGrid.Columns.IndexOf("SIZECODE") + 1
                If colIndex > 0 AndAlso colIndex < GrdItem.Cols Then
                    If RowNo >= 0 AndAlso RowNo < GrdItem.Rows Then
                        Dim gridCell = GrdItem.Cell(RowNo, colIndex)
                        If gridCell IsNot Nothing Then
                            gridCell.Text = masterCode
                        End If
                    End If
                End If
                ' Next Excel/Grid row
                RowNo += 1
            Next
            Dim totalQty As Decimal = 0D
            If dt.Columns.Contains("QTY") Then
                For Each dr As DataRow In dt.Rows
                    If Not IsDBNull(dr("QTY")) Then
                        Dim qty As Decimal
                        If Decimal.TryParse(dr("QTY").ToString(), qty) Then
                            totalQty += qty
                        End If
                    End If
                Next
            End If
            ' LblQty mein total set karein
            LblQty.Text = totalQty.ToString("0.00")
            Return True
        Catch ex As Exception
            MessageBox.Show("Excel Master Code Set Error: " & ex.Message, "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return True
        End Try
    End Function
    Private Sub ImportExcelToGrdItem(ByVal excelTable As DataTable)
        If excelTable Is Nothing OrElse excelTable.Rows.Count = 0 Then
            MsgBox("Excel file mein import karne ke liye rows nahi hain.")
            Return
        End If
        If _DataTableGrid Is Nothing OrElse _DataTableGrid.Columns.Count = 0 Then
            MsgBox("_DataTableGrid columns available nahi hain.")
            Return
        End If
        Try
            Dim matchedColumns As New Dictionary(Of Integer, Integer)
            For flexCol As Integer = 1 To GrdItem.Cols - 1
                ' Grid header blank ho to metadata se column name lein
                Dim gridColumnName As String = GrdItem.Cell(0, flexCol).Text.Trim().
                Replace(" ", "").Replace("_", "")
                If gridColumnName = "" AndAlso flexCol - 1 < _DataTableGrid.Columns.Count Then
                    gridColumnName = _DataTableGrid.Columns(flexCol - 1).ColumnName.Trim().Replace(" ", "").Replace("_", "")
                End If
                If gridColumnName = "" Then Continue For
                For excelCol As Integer = 0 To excelTable.Columns.Count - 1
                    Dim excelColumnName As String = excelTable.Columns(excelCol).ColumnName.Trim().Replace(" ", "").Replace("_", "")
                    If String.Equals(gridColumnName, excelColumnName, StringComparison.OrdinalIgnoreCase) Then
                        matchedColumns(flexCol) = excelCol
                        Exit For
                    End If
                Next
            Next
            If matchedColumns.Count = 0 Then
                MsgBox("The Excel column headers do not match the grid column headers. Please verify the column names and try again.", "Soft-Tex PRO", MessageBoxButtons.OK)
                Return
            End If
            If GrdItem.Rows > 1 Then
                GrdItem.Rows = 1
            End If
            For excelRow As Integer = 0 To excelTable.Rows.Count - 1
                Dim targetRow As Integer = excelRow + 1
                GrdItem.Rows = targetRow + 1
                For Each mapping As KeyValuePair(Of Integer, Integer) In matchedColumns
                    Dim flexCol As Integer = mapping.Key
                    Dim excelCol As Integer = mapping.Value
                    Dim value As Object = excelTable.Rows(excelRow)(excelCol)
                    If value Is Nothing OrElse IsDBNull(value) Then
                        GrdItem.Cell(targetRow, flexCol).Text = ""
                    Else
                        GrdItem.Cell(targetRow, flexCol).Text = Convert.ToString(value).Trim()
                    End If
                Next
            Next
            Dim srNoCol As Integer = -1
            For col As Integer = 1 To GrdItem.Cols - 1
                Dim header As String = GrdItem.Cell(0, col).Text.Trim().Replace(" ", "").Replace("_", "")
                If header = "" AndAlso col - 1 < _DataTableGrid.Columns.Count Then
                    header = _DataTableGrid.Columns(col - 1).ColumnName.Trim().Replace(" ", "").Replace("_", "")
                End If
                If String.Equals(header, "S.NO",
                             StringComparison.OrdinalIgnoreCase) Then
                    srNoCol = col
                    Exit For
                End If
            Next
            If srNoCol > 0 Then
                For rowIndex As Integer = 1 To GrdItem.Rows - 1
                    GrdItem.Cell(rowIndex, srNoCol).Text = rowIndex.ToString()
                Next
            End If
            PanlPropartiesWindow.Visible = False
            TxtExcelFileName.Text = ""
            MessageBox.Show(excelTable.Rows.Count.ToString() & " rows imported successfully.", "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Focus()
        Catch ex As Exception
            MessageBox.Show("Grid fill error: " & ex.Message, "Soft-Tex PRO", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub

    Private Sub ReadyMadeProducation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _FrmLoad = True
        Me.Location = New Point(0, 0)
        Call defineGridColName()
        Call GenerateTable(_DataTableGrid, GrdItem)
        Call GridFormatting(_DataTableGrid, GrdItem)

        AutoResizeGrid(PNL_View, GridControl1)
        AttachButtonFocusEvents(Me)
        LblQty.Text = ""


        SetTotalObjectPosition("QTY", _DataTableGrid, GrdItem, LblQty, LblTotal)

        GrdItem.Rows = 2
        GrdItem.Column(0).Visible = False
        GrdItem.Row(0).Height = 31
        GrdItem.DefaultRowHeight = 28
        _old_Me_text = Me.Text

        If _isCallerByOther = True Then
            btnSave.Visible = True
            Call Alter_Form(_KeyFieldValue)
        Else
            Command_Button_Visibility("LOAD")
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
            btnAdd.Focus()
            btnAdd.Select()
        End If

        _FrmLoad = False
    End Sub

#End Region
#Region "COMMAND BUTTON VISIBILITY CODE "
    Private Sub Command_Button_Visibility(ByVal Visibility_Flag As String)

        _ITEMBOOKVNO = ""
        _ITEMDESC = ""
        _ItmBillNo = ""
        _ItmBillRate = ""
        _ItmBillPartyName = ""
        _ItmBillCaseNo = ""
        'Lbl_BillNo.Text = ""
        Label_Decimal_Setting()
        'Lbl_UsedChalnNo.Text = ""

        If Visibility_Flag = "LOAD" Then
            'Label_Value_Nil_Rest()
            _FORMMODE = ""
            btnSave.Enabled = False
            btnAdd.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnModify.Enabled = True
            btnDelete.Enabled = True
            btnView.Enabled = True
            btnPrint.Enabled = True
        ElseIf Visibility_Flag = "BTNADD" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNEDIT" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNDELETE" Then
            btnSave.Enabled = True
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
        ElseIf Visibility_Flag = "BTNVIEW" Then
            btnSave.Enabled = False
            btnAdd.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnView.Enabled = False
            btnPrint.Enabled = False
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
            Old_Date = txtChallan_Date.Text
            ObjCls_General.Blank_Object(Me)
            Me.Text = _old_Me_text
            Clear_Grid(GrdItem, 2)
            'Label_Value_Nil_Rest()
            _KeyFieldValue = 0
            Command_Button_Visibility("LOAD")
            Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Else
            CLOSE_MNU_LOAD()
        End If
    End Sub
    Private Sub CLOSE_MNU_LOAD()
        Me.Close()
        Me.Dispose(True)
        LEDGER_ENTER_DISPLAY_FROM = ""
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If Lbl_UsedChalnNo.Text <> "" Then
        '    MsgBox("This Order Use For Challan Can't Modify/Delete", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        '    Exit Sub
        'End If
        Generate_Date_For_DataBase(txtChallan_Date)

        If Validate_Form_Values() = True Then
            _FrmLoad = True
            SaveRecord()
            _FrmLoad = False
            If Edit_From_View = True Then
                _FORMMODE = "VIEW"
            End If
        End If
    End Sub
    Private Sub TXt_ENtryType_Validated(sender As Object, e As EventArgs) Handles Txt_EntryType.Validated


        If Txt_EntryType.Text = "INWARD" Then
            _BookTrType = "READY1"
            _BookCode = "READY-000000001"
        Else
            _BookTrType = "READY2"
            _BookCode = "READY-000000002"
        End If


        Book_Code = _BookCode
        txtBookCode.Text = _BookCode


        Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated(_BookCode)
        Dim TblTmp As New DataTable
        Dim Last_Entry_No As Integer = 1
        sqL = Str_Qry
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO")) + 1
        End If

        If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
            Last_Entry_No = Last_Entry_No - 1


        End If

        txtEntryNo.Text = Last_Entry_No
        txtChallan_Date.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        GrdItem.Focus()
        GrdItem.Select()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        txtEntryNo.Focus()
        txtEntryNo.Select()


        If _FORMMODE = "VIEW" Then
            View_Record()
        End If


    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Edit_From_View = False
        _FrmLoad = False
        'Txt_HeaderMtr.Text = "0.00"
        _FORMMODE = "ADD"
        Last_Focused_Btn = "ADD"
        Dim _userwrits As String = obj_Party_Selection._userWrits("ADD")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        GrdItem.Enabled = True
        Clear_Grid(GrdItem, 2)
        'Lbl_UsedChalnNo.Text = ""
        _ITEMBOOKVNO = ""
        _ITEMDESC = ""
        _ItmBillNo = ""
        _ItmBillRate = ""
        _ItmBillPartyName = ""
        _ItmBillCaseNo = ""
        'Lbl_BillNo.Text = ""
        Label_Decimal_Setting()
        'txtBookName.Visible = True
        Command_Button_Visibility("BTNADD")
        'PictureBox1.Image = Textile.My.Resources.Resources.download
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        'ObjCls_General.Blank_Object(Me)
        'txtBookName.Text = Book_Name
        Txt_EntryType.Text = "INWARD"
        GrdItem.Focus()
        GrdItem.Select()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        Txt_EntryType.Focus()
        Txt_EntryType.Select()
    End Sub
    Public Function EntryData_Invoice_Entry_txtBookName_Validated(ByVal _BookCode As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.ENTRYNO")
            .Append(" FROM TrnReadyMadeProducation A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='" & _BookCode & "' ")
            .Append(" ORDER BY A.ENTRYNO DESC ")
        End With
        Return _strQuery.ToString
    End Function
    Private Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "EDIT"
        Last_Focused_Btn = "EDIT"
        'Txt_HeaderMtr.Text = "0.00"
        'txtBookName.Visible = True
        Command_Button_Visibility("BTNEDIT")
        Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        'PictureBox1.Image = Textile.My.Resources.Resources.download
        _ITEMBOOKVNO = ""
        _ITEMDESC = ""
        _ItmBillNo = ""
        _ItmBillRate = ""
        _ItmBillPartyName = ""
        _ItmBillCaseNo = ""
        Label_Decimal_Setting()
        GrdItem.Enabled = True
        Clear_Grid(GrdItem, 2)
        'Lbl_BillNo.Text = ""
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        'ObjCls_General.Blank_Object(Me)

        'Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated(_BookCode)
        'Dim TblTmp As New DataTable
        'Dim Last_Entry_No As Integer = 0
        'sqL = Str_Qry
        'sql_connect_slect()
        'If DefaltSoftTable.Rows.Count > 0 Then
        '    Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        'End If

        'txtEntryNo.Text = Last_Entry_No

        'txtChallan_Date.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        'Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        'GrdItem.Focus()
        'GrdItem.Select()
        'FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)


        ''txtBookName.Text = Book_Name
        'txtBookCode.Text = Book_Code
        Txt_EntryType.Text = "INWARD"
        GrdItem.Focus()
        GrdItem.Select()
        FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)
        Txt_EntryType.Focus()
        Txt_EntryType.Select()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Edit_From_View = False
        _FrmLoad = False
        _FORMMODE = "DELETE"
        Last_Focused_Btn = "DELETE"

        Dim _userwrits As String = obj_Party_Selection._userWrits("DELETE")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Txt_HeaderMtr.Text = "0.00"
        'txtBookName.Visible = True
        Command_Button_Visibility("BTNDELETE")
        'PictureBox1.Image = Textile.My.Resources.Resources.download
        GrdItem.Enabled = True
        Clear_Grid(GrdItem, 2)
        _ITEMBOOKVNO = ""
        _ITEMDESC = ""
        _ItmBillNo = ""
        _ItmBillRate = ""
        _ItmBillPartyName = ""
        _ItmBillCaseNo = ""
        Label_Decimal_Setting()
        Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
        'ObjCls_General.Blank_Object(Me)
        'Lbl_BillNo.Text = ""
        'Dim Str_Qry As String = EntryData_Invoice_Entry_txtBookName_Validated(_BookCode)
        'Dim TblTmp As New DataTable
        'Dim Last_Entry_No As Integer = 0
        'sqL = Str_Qry
        'sql_connect_slect()
        'If DefaltSoftTable.Rows.Count > 0 Then
        '    Last_Entry_No = Val(DefaltSoftTable.Rows(0).Item("ENTRYNO"))
        'End If

        'txtEntryNo.Text = Last_Entry_No

        'txtChallan_Date.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        'Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)

        'GrdItem.Focus()
        'GrdItem.Select()
        'FocusSetToGridDefaultColumn(GrdItem, _DefaultColOfGrid)


        'txtBookCode.Text = Book_Code
        Txt_EntryType.Text = "INWARD"
        Txt_EntryType.Focus()
        Txt_EntryType.Select()
    End Sub
    Private Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        _FrmLoad = False
        _FORMMODE = "VIEW"
        Last_Focused_Btn = "VIEW"

        Dim _userwrits As String = obj_Party_Selection._userWrits("VIEW")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'txtBookName.Visible = True
        Command_Button_Visibility("BTNVIEW")

        'txtBookName.Text = Book_Name
        txtBookCode.Text = Book_Code
        txt_From.Text = Main_MDI_Frm.FINE_YEAR_START.Text
        txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

        setDatesForReports(txt_From, txt_To)
        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)

        Txt_EntryType.Visible = True

        Txt_EntryType.Text = "INWARD"
        'txtEntryNo.Focus()
        'txtEntryNo.Select()
        Txt_EntryType.Focus()
        Txt_EntryType.Select()



    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, But_print.Click
        Dim _userwrits As String = obj_Party_Selection._userWrits("PRINT")
        If _userwrits = "N" Then
            MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If


        ReadyMadeProducation_ChallanPrinting.ShowDialog()


    End Sub
#End Region



#Region "DELETE CODE "
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
            sqL = " DELETE FROM TrnReadyMadeProducation WHERE BOOKVNO='" & _BookVNo & "'"
            sql_Data_Save_Delete_Update()
            _KeyFieldValue = 0
            _FORMMODE = "ADD"

#Region "Edit Log Save"
            Dim _EntryType As String = "Delete"
            _EditLog(_EntryType)
#End Region

            _LastEntryNo = 0
            MsgBox("Entry Successfully Deleted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Old_Date = txtChallan_Date.Text
            ObjCls_General.Blank_Object(Me)
            txtChallan_Date.Text = Old_Date
        Catch ex As Exception

            MsgBox("Error While Delete Entry")
        Finally
            cmd = Nothing
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
            If _FORMMODE = "ADD" Then
                txtChallanNo.Text = txtEntryNo.Text
            End If
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
                txtChallanNo.Focus()
                _DefaultColOfGrid = _DataTableGrid.Columns.IndexOf("SRNO") + 1
                Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
                If Is_Adjusted_Offer() = True Then
                    MsgBox("This Offer Is Adjusted In Invoice", MsgBoxStyle.Information, "Soft-Tex PRO")
                    Change_Grid_Data = False
                    txtChallan_Date.Enabled = False
                    GrdItem.Column(_DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Locked = True
                    GrdItem.Column(_DataTableGrid.Columns.IndexOf("CUTNAME") + 1).Locked = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtChallanNo.Focus()
                    txtChallanNo.Select()
                Else
                    Change_Grid_Data = True
                    GrdItem.Cell(1, _DefaultColOfGrid).SetFocus()
                    _FrmLoad = False
                    txtChallanNo.Focus()
                    txtChallanNo.Select()
                End If
            ElseIf _FORMMODE = "DELETE" Then
                _FrmLoad = True
                Call Alter_Form(Book_Vno)

                'If Lbl_UsedChalnNo.Text <> "" Then
                '    MsgBox("This Order Use For Challan Can't Modify/Delete", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                '    Exit Sub

                'Else
                If MsgBox("Do You Want To Delete(Y/N)", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                    Call Delete_Entry_SQL()
                End If
                'End If

                Clear_Grid(GrdItem, 2)
                'Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                Command_Button_Visibility("LOAD")
                'If _Last_Saved_Entry_No > 0 Then
                Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
                'Else
                '    btnAdd.Focus()
                'End If
                _FrmLoad = False
            End If
        Else
            If _FORMMODE = "EDIT" Or _FORMMODE = "DELETE" Then
                Clear_Grid(GrdItem, 2)
                'Label_Value_Nil_Rest()
                Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
                MsgBox("Entry No " + Trim(txtEntryNo.Text) + " Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                txtEntryNo.Visible = True
                txtEntryNo.Focus()
                txtEntryNo.Select()
            End If
        End If
    End Sub
#End Region


#Region "ALTER FORM QUERY "
    Private Function getAlter_Form_Query_Details(ByVal strKeyID As String) As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT A.*, ")
            .Append(" FORMAT(A.CHALLAN_DATE, 'dd/MM/yyyy') AS F_CHALLAN_DATE, ")
            .Append(" K.GroupName AS ITEMNAME, ")
            .Append(" L.SizeName AS SIZE, ")
            .Append(" M.ColorName AS COLOUR, ")
            .Append(" N.ItemName AS DESIGNNAME, ")
            .Append(" O.subItemName AS SHADENAME ")
            .Append(" FROM TrnReadyMadeProducation AS A ")
            .Append(" LEFT JOIN MstStoreItemGroup AS K ON A.ITEMCODE = K.GroupCode ")
            .Append(" LEFT JOIN MstSize AS L ON A.SIZECODE = L.SizeCode ")
            .Append(" LEFT JOIN MstColor AS M ON A.COLORCODE = M.ColorCode ")
            .Append(" LEFT JOIN MstStoreItem AS N ON A.DESIGNCODE = N.ItemCode ")
            .Append(" LEFT JOIN MstStoreSubItem AS O ON A.SHADECODE = O.subItemCode ")
            .Append(" WHERE A.BOOKCODE = '" & _BookCode & "' ")
            .Append("   AND A.BOOKVNO = '" & strKeyID & "' ")
            .Append(" ORDER BY A.SRNO ")
        End With
        Return _strQuery.ToString
    End Function
#End Region


#Region "ALTER FORM"
    Private Sub Alter_Form(ByVal strKeyID As String)
        _FrmLoad = True

        Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)
        Dim _strquery As New StringBuilder
        Dim tblTmp As New DataTable
        strQuery = getAlter_Form_Query_Details(strKeyID)
        sqL = strQuery
        sql_connect_slect()
        tblTmp = DefaltSoftTable.Copy

        If tblTmp.Rows.Count > 0 Then
            'ObjCls_General.Fill_DataBase_Value_Into_Form_Objects(Me, tblTmp)

            'txtAccount_Code.Text = tblTmp.Rows(0)("ACCOUNTCODE").ToString
            'txtAccountName.Text = tblTmp.Rows(0)("ACCOUNTNAME").ToString
            txtChallanNo.Text = tblTmp.Rows(0)("CHALLAN_NO").ToString
            txtChallan_Date.Text = tblTmp.Rows(0)("F_CHALLAN_DATE").ToString
            'txtDelivery_Name.Text = tblTmp.Rows(0)("DeleveryName").ToString
            'txtTransportName.Text = tblTmp.Rows(0)("TRANSPORTNAME").ToString
            'Txt_Vechno.Text = tblTmp.Rows(0)("VECHNO").ToString
            txtHeader_Remark.Text = tblTmp.Rows(0)("HEADERREMARK").ToString
            'txtDeleviryCode.Text = tblTmp.Rows(0)("DELIVERYCODE").ToString
            'txtTransport_code.Text = tblTmp.Rows(0)("TRANSPORTCODE").ToString
            'txtIamgePath.Text = tblTmp.Rows(0)("IMAGEPATH").ToString

            'Txt_HeadrItemName.Text = tblTmp.Rows(0)("ITEMNAME").ToString
            'HEADERITEMCODE.Text = tblTmp.Rows(0)("ITEMCODE").ToString
            'Txt_HeaderMtr.Text = tblTmp.Rows(0)("HEADERMTR").ToString
            'Txt_HEADERMTR_Bal.Text = tblTmp.Rows(0)("HEADERMTR_Bal").ToString
            '_ITEMBOOKVNO = tblTmp.Rows(0)("ITEMBOOKVNO").ToString
            '_ITEMDESC = tblTmp.Rows(0)("ITEMDESC").ToString
            'Lbl_BillNo.Text = tblTmp.Rows(0)("LOOM_TYPE").ToString


            'sqL = " select * FROM TrnPackingSlip WHERE OFFERBOOKVNO='" & strKeyID & "'"
            'sql_connect_slect()

            'If DefaltSoftTable.Rows.Count > 0 Then
            '    Dim _entryno As Integer = DefaltSoftTable.Rows(0).Item("ENTRYNO")
            '    Lbl_UsedChalnNo.Text = "Order Use Challan Entry No : " & _entryno.ToString
            'Else
            '    Lbl_UsedChalnNo.Text = ""
            'End If


            'If txtIamgePath.Text > "" Then
            '    PictureBox1.ImageLocation = txtIamgePath.Text
            '    PictureBox1.Load()
            'Else
            '    PictureBox1.Image = Textile.My.Resources.Resources.download
            'End If

            Generate_Date_For_DataBase(txtChallan_Date)



            GrdItem.Visible = False
            GrdItem.Range(0, 0, GrdItem.Rows - 1, GrdItem.Cols - 1).DeleteByRow()
            Fill_Records(tblTmp, Grid_Table_ColNames, GrdItem, 0, True, "", False)
            GrdItem.Refresh()
            GrdItem.Visible = True

            'GrdItem.Rows = GrdItem.Rows + 1
            GrdItem.Cell(GrdItem.Rows - 1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SetFocus()
            GrdItem.Range(GrdItem.Rows - 1, _DataTableGrid.Columns.IndexOf("SRNO") + 1, GrdItem.Rows - 1, _DataTableGrid.Columns.IndexOf("SRNO") + 1).SelectCells()

            Ctrl_Visibility_With_One_Grid(True, Me.Controls, GrdItem)
            _FrmLoad = False

            Label_Decimal_Setting()


        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtEntryNo.Focus()
            txtEntryNo.SelectAll()
            Exit Sub
        End If
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
        sqL = strQuery
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

#Region "GRID ITEM EVENTS "
    Private Sub grditem_Click(ByVal Sender As Object, ByVal e As System.EventArgs) Handles GrdItem.Click
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))
        _FrmLoad = False
    End Sub
    Private Sub grdItem_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles GrdItem.RowColChange
        If _FrmLoad = True Then Exit Sub
        _RowNo = e.Row
        _ColNo = e.Col
        _ActivatedColName = Trim(UCase(Sender.Cell(0, Sender.ActiveCell.Col).TAG))

        'GrdItem.ActiveCell.BackColor = Color.Transparent
    End Sub
    Private Sub grdItem_LeaveCell(ByVal Sender As Object, ByVal e As FlexCell.Grid.LeaveCellEventArgs) Handles GrdItem.LeaveCell
        If _FrmLoad = True Then Exit Sub
        If _AllowMoveFromCell = False Then e.Cancel = True
    End Sub
    Private Sub grdItem_EnterRow(ByVal Sender As Object, ByVal e As FlexCell.Grid.EnterRowEventArgs) Handles GrdItem.EnterRow
        If _FrmLoad = True Then Exit Sub
        _FrmLoad = True
        Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)



        _FrmLoad = False
    End Sub
    Private Sub grdItem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdItem.GotFocus
        _ActivatedColName = UCase(sender.Cell(0, sender.ActiveCell.Col).Tag)
        If Txt_EntryType.Text.Trim().ToUpper() = "OUTWARD" Then
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Locked = True
        Else
            GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Locked = False
        End If
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

        'If _ActivatedColName = "ROWREMARK" Then
        '    If GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = "" Then
        '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).SetFocus()
        '        e.Cancel = True
        '        Exit Sub
        '    ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = "" Then
        '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).SetFocus()
        '        e.Cancel = True
        '        Exit Sub
        '    ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = "" Then
        '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).SetFocus()
        '        e.Cancel = True
        '        Exit Sub
        '    ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = "" Then
        '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).SetFocus()
        '        e.Cancel = True
        '        Exit Sub
        '    ElseIf Val(GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NET_WEIGHT") + 1).Text) = 0 Then
        '        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("NET_WEIGHT") + 1).SetFocus()
        '        e.Cancel = True
        '        Exit Sub
        '    End If
        'End If
    End Sub

    Private Sub grditem_KeyPress(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GrdItem.KeyPress
        If _FrmLoad = True Then Exit Sub
        Dim Grp_By_ID As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("PROD_GROUP_BY_ID") + 1).Text
    End Sub

    Private Sub grditem_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItem.KeyDown
        If _FrmLoad = True Then Exit Sub
        Dim Current_Row As Integer = GrdItem.ActiveCell.Row

        If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1)).Text = "0000-000000001"
        If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1)).Text = "0000-000000001"
        If Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1)).Text = "" Then Me.GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1)).Text = "0000-000000001"

        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZE") + 1).Locked = True
        GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLOUR") + 1).Locked = True

        If _ActivatedColName = "ITEMNAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("ITEMNAME") + 1)).Text
                obj_Party_Selection.SINGLE_StoreItemGroup_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("ITEMNAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("ITEMCODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
            End If

            'ElseIf _ActivatedColName = "TOTALMTR" Or _ActivatedColName = "CONSUMPCSQTY" Then


        ElseIf _ActivatedColName = "SHADENAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SHADENAME") + 1)).Text
                obj_Party_Selection.SINGLE_store_Sub_Item_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SHADENAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SHADECODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
            End If
        ElseIf _ActivatedColName = "ITEMTYPE" Then
            If e.KeyCode = Keys.Space Then
                If GrdItem.Cell(GrdItem.ActiveCell.Row, (_DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1)).Text = "RUNNING" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, (_DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1)).Text = "CLOSED"
                ElseIf GrdItem.Cell(GrdItem.ActiveCell.Row, (_DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1)).Text = "CLOSED" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, (_DataTableGrid.Columns.IndexOf("ITEMTYPE") + 1)).Text = "RUNNING"
                End If
            End If
        ElseIf _ActivatedColName = "DESIGNNAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1)).Text

                obj_Party_Selection.SINGLE_storeItem_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
            End If
        ElseIf _ActivatedColName = "SHADENAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SHADENAME") + 1)).Text
                obj_Party_Selection.SINGLE_SHADE_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SHADENAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SHADECODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
            End If

        ElseIf _ActivatedColName = "PRODITEMNAME" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1)).Text
                obj_Party_Selection.SINGLE_storeItem_SELECTION()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("PRODITEMNAME") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("PRODITEMCODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
            End If
        ElseIf _ActivatedColName = "SIZE" Then
            If e.KeyCode = Keys.Enter Then
                Dim _oldSizeCode As String = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1)).Text
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZE") + 1)).Text
                obj_Party_Selection.Single_size_Selection()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZE") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
                Dim _NewSizeCode As String = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1)).Text
                If _oldSizeCode <> _NewSizeCode AndAlso Txt_EntryType.Text = "OUTWARD" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text = ""
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text = ""
                End If
            ElseIf e.KeyCode = Keys.F11 Then
                If Txt_EntryType.Text.Trim().ToUpper() = "OUTWARD" Then

                    _GetMultyStockList()
                End If
            End If

        ElseIf _ActivatedColName = "COLOUR" Then
            If e.KeyCode = Keys.Enter Then
                Dim _oldCode As String = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1)).Text
                Party_selection.txtSearch.Text = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLOUR") + 1)).Text
                obj_Party_Selection.Single_Color_Selection()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    txt_Name_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_1_DATA
                    txt_Code_For_Grid_Selection.Text = MULTY_SELECTION_COLOUM_3_DATA
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLOUR") + 1)).Text = txt_Name_For_Grid_Selection.Text
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1)).Text = txt_Code_For_Grid_Selection.Text
                End If
                Dim _NewCode As String = GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1)).Text
                If _oldCode <> _NewCode AndAlso Txt_EntryType.Text = "OUTWARD" Then
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text = ""
                    GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text = ""
                End If
            End If
        ElseIf _ActivatedColName = "QTY" Or _ActivatedColName = "RATE" Then
            If e.KeyCode = Keys.Enter Then
                Dim _QTY As Double = Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("QTY") + 1)).Text)
                Dim _RATE As Double = Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("RATE") + 1)).Text)

                If Txt_EntryType.Text.Trim().ToUpper() = "OUTWARD" Then

                    GetUpdatedStockTable(_BaleStkQty)
                    If _BaleStkQty < 0 Then
                        MsgBox("Bale Stock Not Available! Available Stock: " & (_BaleStkQty + Val(_QTY)).ToString("0.00"), MsgBoxStyle.Critical, "Soft-Tex PRO")
                        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("QTY") + 1)).Text = "0"
                        GetUpdatedStockTable(_BaleStkQty)
                        Exit Sub
                    End If
                End If

                Dim AMOUNT As Double = _QTY * _RATE
                If AMOUNT > 0 Then
                    GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("AMOUNT") + 1)).Text = AMOUNT
                End If
            End If
        ElseIf _ActivatedColName = "BATCHNO" Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Space Then
                If Txt_EntryType.Text = "OUTWARD" Then
                    If Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("QTY") + 1)).Text) = 0 Then
                        Dim _UpdatedStockTable As DataTable
                        _BaleStkQty = 0
                        _UpdatedStockTable = GetUpdatedStockTable(_BaleStkQty)

                        Dim ExtracolumnsToHide = {"DESIGNCODE", "SHADECODE", "SIZECODE", "COLORCODE", "BATCHNO"}
                        Dim selected1 = SingleAccountSelectionFormsingledatatable(_UpdatedStockTable, Nothing, GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text, "SINGLE", "YES", ExtracolumnsToHide)
                        If selected1 IsNot Nothing Then
                            If selected1.ContainsKey("BaleNo") Then GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("BATCHNO") + 1)).Text = selected1("BaleNo").ToString()
                        End If
                    End If
                End If
                Label_Decimal_Setting()
            ElseIf e.KeyCode = Keys.Delete Then
                GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("BATCHNO") + 1)).Text = ""
                GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("QTY") + 1)).Text = ""
                Label_Decimal_Setting()
            End If

        ElseIf _ActivatedColName = "ROWREMARK" Then
            If e.KeyCode = 13 Then
                If GrdItem.Rows - 1 = GrdItem.ActiveCell.Row Then
                    GrdItem.Rows = GrdItem.Rows + 1
                    Fill_Current_Row_Sr_No(_DataTableGrid, GrdItem)
                    If Val(GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text) = 0 Then
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("COLOUR") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLOUR") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("BATCHNO") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ROWREMARK") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ROWREMARK") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SIZE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZE") + 1).Text
                        GrdItem.Cell(GrdItem.ActiveCell.Row + 1, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text
                    End If
                End If
            End If
        End If




        Dim _UseMtr As Double = Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("AvgWeight") + 1)).Text)
        Dim _CurrentMtr As Double = Val(GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("TOTALMTR") + 1)).Text)
        Dim _BalanceMtr As Double = _UseMtr - _CurrentMtr

        GrdItem.Cell(Me.GrdItem.ActiveCell.Row, (Me._DataTableGrid.Columns.IndexOf("Mtr_Weight") + 1)).Text = _BalanceMtr

    End Sub

    Private Sub _GetMultyStockList()

        Dim activeRow As Integer = Me.GrdItem.ActiveCell.Row
        Dim colGroup As Integer = Me._DataTableGrid.Columns.IndexOf("ITEMCODE") + 1
        Dim colDesign As Integer = Me._DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1
        Dim colShade As Integer = Me._DataTableGrid.Columns.IndexOf("SHADECODE") + 1
        Dim colSize As Integer = Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1
        Dim colColor As Integer = Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1
        Dim colBatch As Integer = Me._DataTableGrid.Columns.IndexOf("BATCHNO") + 1
        Dim colQty As Integer = Me._DataTableGrid.Columns.IndexOf("QTY") + 1

        Dim _GroupCode As String = GrdItem.Cell(activeRow, colGroup).Text.Trim()
        Dim _ItemCode As String = GrdItem.Cell(activeRow, colDesign).Text.Trim()
        Dim _SubItemCode As String = GrdItem.Cell(activeRow, colShade).Text.Trim()
        Dim _SizeCode As String = GrdItem.Cell(activeRow, colSize).Text.Trim()
        Dim _COLORCODE As String = GrdItem.Cell(activeRow, colColor).Text.Trim()
        Dim _BATCHNO As String = GrdItem.Cell(activeRow, colBatch).Text.Trim()


        Dim ItemCode = " AND A.DESIGNCODE='" & _ItemCode & "' "
        Dim SizeCode = " AND A.SIZECODE='" & _SizeCode & "' "
        Dim COLORCODE = " AND A.COLORCODE='" & _COLORCODE & "'"
        Dim GroupCode = " AND A.ITEMCODE='" & _GroupCode & "' "
        Dim SubItemCode = " AND A.SHADECODE='" & _SubItemCode & "' "

        Dim DESCR As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text
        Dim DESIGNNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text
        Dim ITEMNAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text
        Dim SHADENAME As String = GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text


        Dim _GetQuery As String = _ChecStk(ItemCode, "", "", GroupCode, SubItemCode, "MULTY").ToString()
        sqL = _GetQuery
        sql_connect_slect()
        Dim dtResult As DataTable

        'Dim outBalanceQty = 0
        If DefaltSoftTable IsNot Nothing AndAlso DefaltSoftTable.Rows.Count > 0 Then

            ' 1. Grid ke sabhi items ki consumed quantity ko group karne ke liye Dictionary
            Dim gridConsumed As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase)

            For i As Integer = 1 To GrdItem.Rows - 1
                Dim dCode As String = GrdItem.Cell(i, colDesign).Text.Trim()
                Dim sCode As String = GrdItem.Cell(i, colShade).Text.Trim()
                Dim szCode As String = GrdItem.Cell(i, colSize).Text.Trim()
                Dim cCode As String = GrdItem.Cell(i, colColor).Text.Trim()
                Dim bNo As String = GrdItem.Cell(i, colBatch).Text.Trim()
                Dim qty As Decimal = Val(GrdItem.Cell(i, colQty).Text)

                ' Blank rows skip karein
                If Not String.IsNullOrEmpty(dCode) AndAlso qty > 0 Then
                    ' Sabhi attributes ko mila kar unique key banayein
                    Dim key As String = String.Format("{0}|{1}|{2}|{3}|{4}", dCode, sCode, szCode, cCode, bNo)

                    If gridConsumed.ContainsKey(key) Then
                        gridConsumed(key) += qty
                    Else
                        gridConsumed.Add(key, qty)
                    End If
                End If
            Next

            ' 2. Stock DataTable ki copy banayein
            dtResult = DefaltSoftTable.Copy()

            ' 3. DataTable ki sabhi rows par iterate karein aur balance adjust karein
            For Each row As DataRow In dtResult.Rows
                If row.RowState <> DataRowState.Deleted Then
                    Dim dCode As String = row("DESIGNCODE").ToString().Trim()
                    Dim sCode As String = row("SHADECODE").ToString().Trim()
                    Dim szCode As String = row("SIZECODE").ToString().Trim()
                    Dim cCode As String = row("COLORCODE").ToString().Trim()
                    Dim bNo As String = row("BATCHNO").ToString().Trim()

                    Dim key As String = String.Format("{0}|{1}|{2}|{3}|{4}", dCode, sCode, szCode, cCode, bNo)

                    ' Agar yeh combination grid me use hua hai
                    If gridConsumed.ContainsKey(key) Then
                        Dim usedQty As Decimal = gridConsumed(key)
                        Dim currentBalance As Decimal = Val(row("BALANCE"))

                        Dim newBalance As Decimal = currentBalance - usedQty

                        If newBalance <= 0 Then
                            row.Delete()
                        Else
                            row("BALANCE") = newBalance.ToString("0.00")
                        End If
                    End If
                End If
            Next

            ' 4. Deleted rows ko remove aur updates commit karein
            dtResult.AcceptChanges()



            Dim ExtracolumnsToHide = {"DESIGNCODE", "SHADECODE", "SIZECODE", "COLORCODE", "BATCHNO"}
            Dim selectedList1 = SingleAccountSelectionFormDatatable(dtResult, GetType(Master_frm), GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text, "MULTY", "YES", ExtracolumnsToHide)
            If selectedList1 IsNot Nothing Then
                Dim RowNo As Integer = GrdItem.ActiveCell.Row
                For Each rowDict As Dictionary(Of String, Object) In selectedList1
                    If rowDict IsNot Nothing AndAlso rowDict.ContainsKey("BATCHNO") Then
                        GrdItem.Cell(RowNo, (_DataTableGrid.Columns.IndexOf("QTY") + 1)).Text = rowDict("Balance").ToString()
                        GrdItem.Cell(RowNo, (_DataTableGrid.Columns.IndexOf("BATCHNO") + 1)).Text = rowDict("BaleNo").ToString()
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1).Text = _ItemCode
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("DESIGNNAME") + 1).Text = DESIGNNAME
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("COLOUR") + 1).Text = rowDict("Color").ToString()
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("DESCR") + 1).Text = DESCR
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("ITEMNAME") + 1).Text = ITEMNAME
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("ITEMCODE") + 1).Text = _GroupCode
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("COLORCODE") + 1).Text = rowDict("COLORCODE").ToString()
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = _SubItemCode
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("SHADENAME") + 1).Text = SHADENAME
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("SIZE") + 1).Text = rowDict("Size").ToString()
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("SIZECODE") + 1).Text = rowDict("SIZECODE").ToString()
                        GrdItem.Cell(RowNo, _DataTableGrid.Columns.IndexOf("SRNO") + 1).Text = RowNo

                        If RowNo >= GrdItem.Rows - 1 Then
                            GrdItem.Rows += 1
                        End If
                        RowNo += 1
                    End If
                Next

                Label_Decimal_Setting()

            End If
        Else
            MsgBox("Bale Stock Not Available!", MsgBoxStyle.Critical, "Soft-Tex PRO")
        End If
    End Sub

    Public Function GetUpdatedStockTable(ByRef outBalanceQty As Decimal) As DataTable
        outBalanceQty = 0
        Dim dtResult As New DataTable

        If GrdItem.ActiveCell Is Nothing OrElse GrdItem.Rows <= 1 Then
            Return dtResult
        End If

        Dim activeRow As Integer = Me.GrdItem.ActiveCell.Row
        Dim colGroup As Integer = Me._DataTableGrid.Columns.IndexOf("ITEMCODE") + 1
        Dim colDesign As Integer = Me._DataTableGrid.Columns.IndexOf("DESIGNCODE") + 1
        Dim colShade As Integer = Me._DataTableGrid.Columns.IndexOf("SHADECODE") + 1
        Dim colSize As Integer = Me._DataTableGrid.Columns.IndexOf("SIZECODE") + 1
        Dim colColor As Integer = Me._DataTableGrid.Columns.IndexOf("COLORCODE") + 1
        Dim colBatch As Integer = Me._DataTableGrid.Columns.IndexOf("BATCHNO") + 1
        Dim colQty As Integer = Me._DataTableGrid.Columns.IndexOf("QTY") + 1

        Dim _GroupCode As String = GrdItem.Cell(activeRow, colGroup).Text.Trim()
        Dim _ItemCode As String = GrdItem.Cell(activeRow, colDesign).Text.Trim()
        Dim _SubItemCode As String = GrdItem.Cell(activeRow, colShade).Text.Trim()
        Dim _SizeCode As String = GrdItem.Cell(activeRow, colSize).Text.Trim()
        Dim _COLORCODE As String = GrdItem.Cell(activeRow, colColor).Text.Trim()
        Dim _BATCHNO As String = GrdItem.Cell(activeRow, colBatch).Text.Trim()

        ' 2. Grid mein se total used qty calculate karein
        Dim _TotalQty As Decimal = 0
        For i As Integer = 1 To GrdItem.Rows - 1
            If GrdItem.Cell(i, colDesign).Text.Trim() = _ItemCode AndAlso
           GrdItem.Cell(i, colShade).Text.Trim() = _SubItemCode AndAlso
           GrdItem.Cell(i, colSize).Text.Trim() = _SizeCode AndAlso
           GrdItem.Cell(i, colColor).Text.Trim() = _COLORCODE AndAlso
           GrdItem.Cell(i, colBatch).Text.Trim() = _BATCHNO Then
                _TotalQty += Val(GrdItem.Cell(i, colQty).Text)
            End If
        Next


        Dim ItemCode = " AND A.DESIGNCODE='" & _ItemCode & "' "
        Dim SizeCode = " AND A.SIZECODE='" & _SizeCode & "' "
        Dim COLORCODE = " AND A.COLORCODE='" & _COLORCODE & "'"
        Dim GroupCode = " AND A.ITEMCODE='" & _GroupCode & "' "
        Dim SubItemCode = " AND A.SHADECODE='" & _SubItemCode & "' "


        Dim _GetQuery As String = _ChecStk(ItemCode, SizeCode, COLORCODE, GroupCode, SubItemCode, "").ToString()
        sqL = _GetQuery
        sql_connect_slect()

        If DefaltSoftTable IsNot Nothing AndAlso DefaltSoftTable.Rows.Count > 0 Then
            dtResult = DefaltSoftTable.Copy()
            Dim filterExpr As String = String.Format("DESIGNCODE = '{0}' AND SHADECODE = '{1}' AND SIZECODE = '{2}' AND COLORCODE = '{3}' AND BATCHNO = '{4}'",
                                                 _ItemCode.Replace("'", "''"),
                                                 _SubItemCode.Replace("'", "''"),
                                                 _SizeCode.Replace("'", "''"),
                                                 _COLORCODE.Replace("'", "''"),
                                                 _BATCHNO.Replace("'", "''"))

            Dim foundRows() As DataRow = dtResult.Select(filterExpr)
            If foundRows.Length > 0 Then
                For Each row As DataRow In foundRows
                    Dim currentBalance As Decimal = Val(row("BALANCE"))
                    Dim newBalance As Decimal = currentBalance - _TotalQty
                    outBalanceQty = newBalance
                    If newBalance <= 0 Then
                        row.Delete()
                    Else
                        row("BALANCE") = newBalance.ToString("0.00")
                    End If
                Next
                dtResult.AcceptChanges()
            End If
        End If

        Return dtResult
    End Function

    Private Function _ChecStk(ByVal _Itemcode As String, ByVal _SizeCode As String, ByVal _COLORCODE As String, ByVal _GroupCode As String, ByVal _SubItemCode As String, ByVal _SelectionType As String)

        Dim _GetQuery As String = ""

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT   ")

            If _SelectionType = "MULTY" Then
                .Append(" 'False' AS TickMark, ")
                .Append(" Z.BATCHNO AS JoinerBeamBookVno, ")
            End If
            '.Append(" K.GroupName AS ITEMNAME, ")
            '.Append(" N.ItemName AS DESIGNNAME, ")
            '.Append(" O.subItemName AS SHADENAME ")
            .Append(" Z.BATCHNO BaleNo, ")
            .Append(" L.SizeName AS Size, ")
            .Append(" M.ColorName AS Color ")
            .Append(" ,round (sum(Z.INQTY)-sum(Z.OUTQTY),2) AS Balance")
            .Append(" ,Z.COLORCODE  ")
            .Append(" ,Z.SIZECODE ")
            .Append(" ,Z.DESIGNCODE ")
            .Append(" ,Z.SHADECODE  ")
            .Append(" ,Z.BATCHNO  ")
            .Append(" FROM( ")
            .Append(" SELECT ")
            .Append(" A.ITEMCODE ")
            .Append(" ,A.COLORCODE  ")
            .Append(" ,A.SIZECODE ")
            .Append(" ,A.DESIGNCODE ")
            .Append(" ,A.SHADECODE  ")
            .Append(" ,A.BATCHNO  ")
            .Append(" ,SUM(A.QTY) AS INQTY ")
            .Append(" ,0.00 AS OUTQTY ")
            .Append(" FROM ")
            .Append(" TrnReadyMadeProducation AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='READY-000000001' ")
            .Append(_Itemcode)
            .Append(_SizeCode)
            .Append(_COLORCODE)
            .Append(_SubItemCode)
            '.Append(" AND A.ITEMCODE='" & _GroupCode & "' ")

            .Append(" GROUP BY ")
            .Append(" A.ITEMCODE ")
            .Append(" ,A.COLORCODE  ")
            .Append(" ,A.SIZECODE  ")
            .Append(" ,A.DESIGNCODE ")
            .Append(" ,A.BATCHNO  ")
            .Append(" ,A.SHADECODE  ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.ITEMCODE ")
            .Append(" ,A.COLORCODE  ")
            .Append(" ,A.SIZECODE  ")
            .Append(" ,A.DESIGNCODE ")
            .Append(" ,A.SHADECODE  ")
            .Append(" ,A.BATCHNO  ")
            .Append(" ,0.00 AS INQTY ")
            .Append(" ,SUM (A.QTY) AS OUTQTY ")
            .Append(" FROM ")
            .Append(" TrnReadyMadeProducation AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='READY-000000002' ")
            .Append(_Itemcode)
            .Append(_SizeCode)
            .Append(_COLORCODE)
            .Append(_SubItemCode)
            '.Append(" AND A.ITEMCODE='" & _GroupCode & "' ")
            .Append(" GROUP BY ")
            .Append(" A.ITEMCODE ")
            .Append(" ,A.COLORCODE  ")
            .Append(" ,A.SIZECODE  ")
            .Append(" ,A.DESIGNCODE ")
            .Append(" ,A.BATCHNO  ")
            .Append(" ,A.SHADECODE  ")
            .Append(" )AS Z ")

            '.Append(" LEFT JOIN MstStoreItemGroup AS K ON Z.ITEMCODE = K.GroupCode ")
            .Append(" LEFT JOIN MstSize AS L ON Z.SIZECODE = L.SizeCode ")
            .Append(" LEFT JOIN MstColor AS M ON Z.COLORCODE = M.ColorCode ")
            .Append(" LEFT JOIN MstStoreItem AS N ON Z.DESIGNCODE = N.ItemCode ")
            .Append(" LEFT JOIN MstStoreSubItem AS O ON Z.SHADECODE = O.subItemCode ")

            .Append(" WHERE 1=1   ")
            .Append(" GROUP BY ")
            .Append(" Z.BATCHNO  ")
            .Append(" ,Z.COLORCODE  ")
            .Append(" ,Z.SIZECODE ")
            .Append(" ,Z.DESIGNCODE ")
            .Append(" ,Z.SHADECODE  ")
            .Append(" ,Z.BATCHNO  ")
            .Append(" ,L.SizeName ")
            .Append(" ,M.ColorName ")
            .Append(" HAVING   sum(Z.INQTY) - sum(Z.OUTQTY)  > 0")
            .Append(" ORDER BY  ")
            .Append(" Z.BATCHNO  ")
        End With
        _GetQuery = _strQuery.ToString

        Return _GetQuery
    End Function
#End Region
#Region "GRID GENERAL FUNCTION "
    'Private Sub Fill_Current_Row_Sr_No(ByRef Data_Table_Obj As DataTable, ByRef grdObj As FlexCell.Grid)
    '    If grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
    '        grdObj.Cell(GrdItem.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
    '    End If

    '    If grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = "" Then
    '        grdObj.Cell(grdObj.ActiveCell.Row, Data_Table_Obj.Columns.IndexOf("SRNO") + 1).Text = grdObj.ActiveCell.Row
    '    End If
    'End Sub
    Private Sub Fill_Current_Row_Sr_No(
    ByRef Data_Table_Obj As DataTable,
    ByRef grdObj As FlexCell.Grid)

        Try
            Dim srNoIndex As Integer =
            Data_Table_Obj.Columns.IndexOf("SRNO") + 1

            If srNoIndex <= 0 Then Exit Sub

            ' Header row 0 hai, isliye data row 1 se start hoga
            For rowIndex As Integer = 1 To grdObj.Rows - 1

                grdObj.Cell(rowIndex, srNoIndex).Text =
                rowIndex.ToString()

            Next

        Catch ex As Exception
            MessageBox.Show("SRNO fill error: " & ex.Message)
        End Try

    End Sub


    Private Sub _TotalForAllGrid()
        For i As Int16 = 1 To GrdItem.Rows - 1
            Dim _QTY As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text)
            Dim _RATE As Double = Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("RATE") + 1).Text)
            'Dim _QTY As Double = Val(i, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text)
            'Dim _RATE As Double = Val(i, ((Me._DataTableGrid.Columns.IndexOf("RATE") + 1)).Text)
            Dim AMOUNT As Double = _QTY * _RATE
            If AMOUNT > 0 Then
                GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text = AMOUNT
            End If
        Next
    End Sub
#End Region
#Region " Txt Header Remark Events "
    Private Sub Txt_ReadyQty_KeyDown(sender As Object, e As KeyEventArgs)
        'If _FrmLoad = True Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            GrdItem.Focus()
            GrdItem.Select()
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "Save Code "
    Private Sub SaveRecord()

        If _FORMMODE = "EDIT" Then
            Dim _userwrits As String = obj_Party_Selection._userWrits("EDIT")
            If _userwrits = "N" Then
                MsgBox("Function Not Allow This User", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If


        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)



        If _FORMMODE = "ADD" Then
            _TransctionNo = 0
            _BookVNo = Generate_Book_Vno(txtEntryNo.Text, _BookTrType)
            sqL = "SELECT TOP 1 ENTRYNO FROM TrnReadyMadeProducation WHERE BOOKVNO='" + Me._BookVNo + "' AND BOOKCODE='" & txtBookCode.Text & "' ORDER BY ENTRYNO DESC"
            sql_connect_slect()
            If DefaltSoftTable.Rows.Count > 0 Then
                _TransctionNo = (DefaltSoftTable.Rows(0).Item(0))
            End If
            If _TransctionNo > 0 Then
                If DefaltSoftTable.Rows.Count > 0 Then

                    sqL = "SELECT TOP 1 ENTRYNO FROM TrnReadyMadeProducation WHERE  BOOKCODE='" & txtBookCode.Text & "' ORDER BY ENTRYNO DESC"
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        _TransctionNo = (DefaltSoftTable.Rows(0).Item(0) + 1)
                    End If
                End If
                txtEntryNo.Text = (_TransctionNo)
                txtChallanNo.Text = (_TransctionNo)
            End If
        End If

        _BookVNo = Generate_Book_Vno(Val(txtEntryNo.Text), _BookTrType)



        LblQty.Text = Replace(LblQty.Text, ",", "")

        _TotalForAllGrid()
        Call Fill_Grid_Records_Into_DataTables()
        Label_Decimal_Setting()


        If txtAcOfCode.Text = "" Then txtAcOfCode.Text = "0000-000000001"
        If txtAccount_Code.Text = "" Then txtAccount_Code.Text = "0000-000000001"
        If txtDeleviryCode.Text = "" Then txtDeleviryCode.Text = "0000-000000001"
        If txtTransport_code.Text = "" Then txtTransport_code.Text = "0000-000000001"

        Dim _LastID As Integer = -1
        Try

            _LastID = SAVE_INTO_DATABASE_SQL()


#Region "Edit Log Save"
            Dim _EntryType As String = ""
            If _FORMMODE = "ADD" Then
                _EntryType = "Add"
            ElseIf _FORMMODE = "EDIT" Then
                _EntryType = "Edit"
            End If
            _EditLog(_EntryType)
#End Region



            Old_Date = txtChallan_Date.Text
            _Last_Saved_Entry_No = Val(txtEntryNo.Text)
            MsgBox("Record Successfully Saved", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

            ObjCls_General.Blank_Object(Me)
            txtChallan_Date.Text = Old_Date
            Ctrl_Visibility_With_One_Grid(False, Me.Controls, GrdItem)

            GrdItem.BoldFixedCell = False
            Clear_Grid(GrdItem, 2)
            Call Command_Button_Visibility("LOAD")
            Call Set_Focus_Last_Clicked_Btn(Last_Focused_Btn)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub _EditLog(ByVal _EntryType As String)
        Dim BookType As String = "Ready Made Bale Register"
        Dim _Item As String = ""
        Dim _Rate As String = ""
        Dim _qty As String = ""
        Dim _Rateon As String = ""
        Dim _ItemDetail As String = ""
        Dim _BarcodeNo As String = ""
        Dim _EditReason As String = ""
        Dim _PartyGstinno As String = ""
        _SaveUserEditLog(txtBookCode.Text,
                           Txt_EntryType.Text,
                            BookType,
                            txtEntryNo.Text,
                            txtChallanNo.Text,
                            CDate(Date.Now).ToString(),
                            Txt_EntryType.Text,
                            txtAccount_Code.Text,
                           "",
                            0.00,
                            _USERNAME,
                            _EntryType,
                            _EditReason,
                            CDate(Date.Now).ToString("yyyy-MM-dd"),
                            _BookVNo,
                            _ItemDetail,
                            txtChallan_Date.Text,
                            LblQty.Text,
                            _PartyGstinno
                            )
    End Sub
    Private Sub Fill_Grid_Records_Into_DataTables()
        Dim FieldDr As DataRow

        _DataTableGrid.Rows.Clear()

        For i As Integer = 1 To GrdItem.Rows - 1
            If Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text) > 0 Then
                FieldDr = _DataTableGrid.NewRow
                For j As Integer = 1 To GrdItem.Cols - 1
                    If FieldDr.Table.Columns(j - 1).DataType.ToString <> "System.String" Then
                        FieldDr(j - 1) = Val(GrdItem.Cell(i, j).Text)
                    Else
                        FieldDr(j - 1) = (GrdItem.Cell(i, j).Text)
                    End If
                Next
                _DataTableGrid.Rows.Add(FieldDr)
            End If
        Next

    End Sub
    Private Function GridDetailsSaveQuery(ByRef arr_object(,) As String) As String
        Dim strFilterString As String
        Dim QueryDetailTable As String = ""
        Dim Query_Auto_Grid(_DataTableGrid.Rows.Count, 4) As String

        strFilterString = "  QTY>0 "

        Date_Formate1 = txtChallan_Date.Text
        Date_Formate_set()

        _ExtraFieldDataTable = New StringBuilder
        With _ExtraFieldDataTable
            .Append("ENTRYNO,")
            .Append("BOOKTRTYPE,")
            .Append("BOOKVNO,")
            .Append("BOOKCODE,")
            .Append("CHALLAN_NO,")
            .Append("CHALLAN_DATE,")
            '.Append("ACCOUNTCODE,")
            '.Append("TRANSPORTCODE,")
            '.Append("DELIVERYCODE")
            '.Append("VECHNO,")
            '.Append("HEADERITEMCODE,")
            '.Append("HEADERMTR,")
            '.Append("HEADERMTR_Bal,")
            '.Append("ITEMBOOKVNO,")
            '.Append("IMAGEPATH")
            .Append("HEADERREMARK")
        End With

        _ExtraField_Values_DataTable = New StringBuilder
        With _ExtraField_Values_DataTable
            .Append(txtEntryNo.Text & ",")
            .Append(_BookTrType & ",")
            .Append(_BookVNo & ",")
            .Append(_BookCode & ",")
            .Append(txtChallanNo.Text & ",")
            .Append(Date_1 & ",")
            '.Append(txtAccount_Code.Text & ",")
            '.Append(txtTransport_code.Text & ",")
            '.Append(txtDeleviryCode.Text)
            '.Append(Txt_Vechno.Text & ",")
            '.Append(HEADERITEMCODE.Text & ",")
            '.Append(Txt_HeaderMtr.Text & ",")
            '.Append(Txt_HEADERMTR_Bal.Text & ",")
            '.Append(_ITEMBOOKVNO & ",")
            '.Append(txtIamgePath.Text & ",")
            .Append(txtHeader_Remark.Text)
        End With

        For Each dr As DataRow In _DataTableGrid.Select
            'dr("HEADERMTR") = Txt_HeaderMtr.Text
            'dr("HEADERMTR_Bal") = Txt_HEADERMTR_Bal.Text
            'dr("ITEMBOOKVNO") = _ITEMBOOKVNO
            'dr("IMAGEPATH") = txtIamgePath.Text
            dr("HEADERREMARK") = txtHeader_Remark.Text
            dr("VECHNO") = Txt_EntryType.Text
            'dr("HEADERITEMCODE") = HEADERITEMCODE.Text
            'dr("LOOM_TYPE") = Lbl_BillNo.Text
        Next





        QueryDetailTable = ObjCls_General.GetQueryArray(_OfferTableName, "FORCELY_ADDED", strFilterString, Query_Auto_Grid, _DataTableGrid, _FieldNotRequiredForSave.ToString.ToUpper, _RecordsKeyFieldName, "", "", "N", _ExtraFieldDataTable.ToString.ToUpper, _ExtraField_Values_DataTable.ToString.ToUpper, _ExtraFieldOthers.ToString.ToUpper, _ExtraField_Values_Others.ToString.ToUpper, _FieldDefaultValues.ToString.ToUpper)
        GridDetailsSaveQuery = QueryDetailTable & ";"
        arr_object = Query_Auto_Grid
    End Function

    Private Function SAVE_INTO_DATABASE_SQL() As Integer
        Dim strQuery As String = ""
        Dim affected As Integer = 0
        Dim I As Integer = 0

        Try
            '---------------- Delete Previous Bill Sundry ----------------------------------'
            strQuery = "DELETE FROM TrnReadyMadeProducation WHERE 1=1 And BOOKVNO ='" & _BookVNo & "'"
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
            Return affected
        Catch ex As Exception
            MsgBox("new error comes :" & ex.Message & "-" & strQuery)
            Throw ex
        Finally
        End Try
    End Function
#End Region




#Region "VIEW RECORD "
    Private Sub btn_View_Ok_Click_1(sender As Object, e As EventArgs) Handles btn_View_Ok.Click
        View_Record()
    End Sub

    Private Sub View_Record()


        Generate_Date_For_DataBase(txt_From)
        Generate_Date_For_DataBase(txt_To)


        Dim View_Filter_Condition As String = ""

        View_Filter_Condition = " AND A.BOOKCODE='" & _BookCode & "' AND A.CHALLAN_DATE>='" & txt_From.Date_for_Database & "' AND A.CHALLAN_DATE<='" & txt_To.Date_for_Database & "'"

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" a.EntryNo,")
            .Append(" A.CHALLAN_DATE AS Date, ")
            .Append(" a.BATCHNO as BaleNo,")
            .Append(" A.SRNO AS SNo,")
            .Append(" a.DESCR as Category,")
            .Append(" K.GroupName AS ItemName, ")
            .Append(" L.SizeName AS Size, ")
            .Append(" M.ColorName AS Color, ")
            .Append(" N.ItemName AS Design, ")
            .Append(" O.subItemName AS SubName, ")
            .Append(" A.QTY AS Qty,")
            .Append(" A.ROWREMARK as Remark")
            .Append(" FROM TrnReadyMadeProducation AS A ")
            .Append(" LEFT JOIN MstStoreItemGroup AS K ON A.ITEMCODE = K.GroupCode ")
            .Append(" LEFT JOIN MstSize AS L ON A.SIZECODE = L.SizeCode ")
            .Append(" LEFT JOIN MstColor AS M ON A.COLORCODE = M.ColorCode ")
            .Append(" LEFT JOIN MstStoreItem AS N ON A.DESIGNCODE = N.ItemCode ")
            .Append(" LEFT JOIN MstStoreSubItem AS O ON A.SHADECODE = O.subItemCode ")
            .Append(" WHERE 1=1")
            .Append(View_Filter_Condition)
            .Append(" ORDER BY  a.EntryNo,A.SRNO ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()

        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy
        FirstStage.Columns.Clear()
        If tblTmp.Rows.Count > 0 Then
            GridControl1.DataSource = tblTmp.Copy

            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)

            FirstStage.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}"))
            PNL_View.Visible = True
            FirstStage.BestFitColumns()
            FirstStage.Focus()
            PNL_View.BringToFront()
            GridControl1.BringToFront()




        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Sub btn_View_Print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = "Bale Register Report From :" & txt_From.Text & " To : " & txt_To.Text
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub Btn_Export_Excel_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub
#End Region

#Region "Save Grid Layout"
    Private Sub BtnLayOutSave_Click(sender As Object, e As EventArgs) Handles BtnLayOutSave.Click
        SaveLayout(FirstStage, Me.Name)
    End Sub
    Private Sub Btn_LayoutLoad_Click(sender As Object, e As EventArgs) Handles Btn_LayoutLoad.Click
        Load_GridLayout(FirstStage, Me.Name)
    End Sub
#End Region

#Region "DATE RANGE CHECK "
    Private Sub txtOfferDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChallan_Date.Validated
        If _FrmLoad = False Then
            If Date_Check_According_To_Financial_Year(sender, _FrmLoad) = False Then
                MsgBox("Invalid Date", MsgBoxStyle.Information, "Soft-Tex PRO")
                txtChallan_Date.Focus()
                txtChallan_Date.Select()
            End If
        End If
    End Sub
#End Region

    Private Sub txtChallanNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChallanNo.Validated
        If _FrmLoad = True Then Exit Sub

        If txtChallanNo.Text = "" Or Val(txtChallanNo.Text) = 0 Then
            MsgBox("Invalid Entry", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            txtChallanNo.Focus()
            txtChallanNo.Select()
        End If
    End Sub

    Private Sub Label_Decimal_Setting()


        'LblTotalMtr.Text = "0.00"
        'LblReadyQty.Text = "0.00"
        LblQty.Text = "0.00"
        'LblNetAmount.Text = "0.00"
        'Txt_HeaderMtr.Text = "0.00"
        'Txt_HEADERMTR_Bal.Text = "0.00"
        'If Txt_HeaderMtr.Text = "" Then Txt_HeaderMtr.Text = 0

        For i As Integer = 1 To GrdItem.Rows - 1

            If _ItmBillNo = "" Then
                _getItemDetail(_ITEMBOOKVNO)
            End If

            'GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("ITEMDESC") + 1)).Text = Mid(_ItmBillPartyName, 1, 3) & _ItmBillNo + _ItmBillCaseNo + Txt_HeadrItemName.Text + GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("SHADENAME") + 1)).Text + _ItmBillRate

            'Dim _Tota_Mtr As Double = Val(GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("TOTALMTR") + 1)).Text)
            Dim _Tota_Mtr As Double = Val(GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("QTY") + 1)).Text)
            Dim _CONSUMPCSQTY As Double = Val(GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("CONSUMPCSQTY") + 1)).Text)

            'Dim _QTY As Double = _Tota_Mtr / _CONSUMPCSQTY
            Dim _QTY As Double = _Tota_Mtr * _CONSUMPCSQTY
            If _QTY > 0 Then
                'GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("READYQTY") + 1)).Text = _QTY
                GrdItem.Cell(i, (Me._DataTableGrid.Columns.IndexOf("TOTALMTR") + 1)).Text = _QTY
            End If
            'LblTotalMtr.Text = CDbl(LblTotalMtr.Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("TOTALMTR") + 1).Text)
            'LblReadyQty.Text = CDbl(LblReadyQty.Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("READYQTY") + 1).Text)
            LblQty.Text = CDbl(LblQty.Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("QTY") + 1).Text)
            'LblNetAmount.Text = CDbl(LblNetAmount.Text) + Val(GrdItem.Cell(i, _DataTableGrid.Columns.IndexOf("AMOUNT") + 1).Text)
            'Txt_HEADERMTR_Bal.Text = CDbl(Txt_HeaderMtr.Text) - CDbl(LblTotalMtr.Text)
        Next


        'If Val(Txt_HeaderMtr.Text) > 0 Then
        '    Txt_HeaderMtr.Text = FormatNumber((Txt_HeaderMtr.Text), 2, TriState.True, TriState.False, TriState.True)
        'Else
        '    Txt_HeaderMtr.Text = "0.00"
        'End If

        'If Val(Txt_HEADERMTR_Bal.Text) > 0 Then
        '    Txt_HEADERMTR_Bal.Text = FormatNumber((Txt_HEADERMTR_Bal.Text), 2, TriState.True, TriState.False, TriState.True)
        'Else
        '    Txt_HEADERMTR_Bal.Text = "0.00"
        'End If


        'If Val(LblTotalMtr.Text) > 0 Then
        '    LblTotalMtr.Text = FormatNumber((LblTotalMtr.Text), 2, TriState.True, TriState.False, TriState.True)
        'Else
        '    LblTotalMtr.Text = "0.00"
        'End If

        'If Val(LblReadyQty.Text) > 0 Then
        '    LblReadyQty.Text = FormatNumber((LblReadyQty.Text), 2, TriState.True, TriState.False, TriState.True)
        'Else
        '    LblReadyQty.Text = "0.00"
        'End If


        If Val(LblQty.Text) > 0 Then
            LblQty.Text = FormatNumber((LblQty.Text), 2, TriState.True, TriState.False, TriState.True)
        Else
            LblQty.Text = "0.00"
        End If


        'If Val(LblNetAmount.Text) > 0 Then
        '    LblNetAmount.Text = FormatNumber((LblNetAmount.Text), 2, TriState.True, TriState.False, TriState.True)
        'Else
        '    LblNetAmount.Text = "0.00"
        'End If

    End Sub
    Private Sub _getItemDetail(ByVal BookVno As String)


        'Txt_HeadrItemName.Text = MULTY_SELECTION_COLOUM_1_DATA
        '    HEADERITEMCODE.Text = MULTY_SELECTION_COLOUM_3_DATA

        _strQuery = New System.Text.StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.BookVno ")
            .Append(" ,A.billno as [Bill No]")
            .Append(" ,format (A.billdate,'dd/MM/yyyy') as [Bill Date]")
            .Append(" ,B.ACCOUNTNAME as [Party Name]")
            .Append(" ,A.challanno as [Case No]")
            .Append(" ,SUM (A.mtr_weight) as [Qty]")
            .Append(" ,A.rate as [Rate]")
            .Append(" FROM trnInvoiceDetail AS A ")
            .Append(" ,MstMasterAccount AS B ")
            .Append(" where 1=1 ")
            .Append("  and a.accountcode =b.ACCOUNTCODE  ")
            .Append(" AND A.BookVno ='" & BookVno & "' ")
            .Append(" GROUP BY")
            .Append(" A.BookVno ")
            .Append(" ,A.billno ")
            .Append(" ,A.billdate")
            .Append(" ,B.ACCOUNTNAME")
            .Append(" ,A.challanno")
            .Append(" ,A.rate ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()


        If DefaltSoftTable.Rows.Count > 0 Then
            _ItmBillNo = DefaltSoftTable.Rows(0).Item("Bill No").ToString
            _ItmBillRate = DefaltSoftTable.Rows(0).Item("Rate").ToString
            _ItmBillPartyName = DefaltSoftTable.Rows(0).Item("Party Name").ToString
            _ItmBillCaseNo = DefaltSoftTable.Rows(0).Item("Case No").ToString
        End If


    End Sub

    Private Sub Btn_ChqRegester_Click(sender As Object, e As EventArgs) Handles Btn_ChqRegester.Click
        ShowFormMDI(New ReadyMadeBaleStock)
    End Sub
End Class