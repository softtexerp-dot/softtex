Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CompilerServices
Imports RestSharp
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Imports System.Net
Imports DevExpress.XtraGrid
Imports System.Data.SqlClient

Module Genral
    Public _strQuery As StringBuilder

    Public _GenralOrderLoadBy As String
    Public obj_Party_Selection As New Multi_Selection_Master
    Public NewSelectionList As New NewSelectionListQuery
    Public Round_Off_Merge_In_Sales_Purc As String = "NO"
    Public ObjCls_General As New cls_FrmHandle.cls_frmHandle
    Public Frm_Msg As New Wait_form
    Public Date_Formate1 As String
    Public Date_1 As String
    Public Date_Formate2 As String
    Public Date_2 As String
    Public Date_Formate3 As String
    Public Date_3 As String
    Public _GstDnCnAdgmentDetail As String
    Public Date_Formate4 As String
    Public Date_4 As String
    Public new_bill_date_check As String
    Public ImageViewePath As String = ""
    Public UnitWiseManage As String = ""
    Public Store_Manage_Unit_Wise As String = ""
    Public _SettingPanelPassword As String = ""
    Public _ProcessDyeningPlanPcsShow As String = ""
    Public _LedgerDateCurrentDate As String = ""
    Public _ProcessLotDyeningPlanEntryUse As String = ""
    Public CompanyCurrencyType As String = ""
    Public _ShadeLoadFabricListWise As String = ""
    Private WithEvents ALterDateBilldate As New ctl_TextBox.ctl_TextBox


    Public _ProcessStage = New String() {"ALL", "NO", "Washing", "Dyening", "Stenter", "Mechanical", "Folding", "Table Checking", "RT", "Decision", "Re Dyening", "OK", "YES"}
    Public _ProcessStage_2 = New String() {"NO", "Washing", "Dyening", "Stenter", "Mechanical", "Folding", "Table Checking", "RT", "Decision", "Re Dyening", "OK", "YES"}
    Public _ProcessStage_3 = New String() {"NO", "Washing", "Dyening", "Stenter", "Mechanical", "Folding", "Table Checking", "Re Dyening"}



    Public Function _GetPlanningIdtodata(ByVal PlanningNo As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append("  A.*")
            .Append(" ,FORMAT(CONVERT(datetime, A.HSNCODE, 103), 'dd/MM/yyyy') AS EntryDate")
            .Append(" ,B.ITENNAME as PlanItemName")
            .Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)) AS PlanningQty")
            .Append(" ,B.REED ")
            .Append(" ,B.OP22 AS Dent ")
            .Append(" ,B.PICK  ")
            .Append(" ,B.OP23 as ReedSpace  ")
            .Append(" ,D.Design_Name")
            .Append(" ,E.SHADE")
            .Append(" ,C.ACCOUNTNAME")
            .Append(" ,C.AGENTCODE")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID ")
            .Append("  LEFT JOIN Mst_Fabric_Design AS D  ON A.COMPNAME=D.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS E  ON A.PRIMERUNIT=E.ID")
            .Append("  LEFT JOIN MstMasterAccount AS C  ON A.TAXSLAB=C.ACCOUNTCODE")
            .Append(" WHERE 1=1")
            .Append(" and A.ID ='" & PlanningNo & "'")
            .Append(" AND MRP='NO'  ")
            .Append(" AND A.SHORTNAME='NEW QUALITY PLANNING'")
            .Append(" ORDER BY A.id ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _tmptbl As New DataTable
        _tmptbl = DefaltSoftTable.Copy
        Return _tmptbl
    End Function

    Public Sub _GetPlanningQuery(ByVal _FilterString As String)

        Party_selection.Label4.Text = "NewQualityPlanEntry"

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append("  A.ID AS EntryNo")
            .Append(" ,FORMAT(CONVERT(datetime, A.HSNCODE, 103), 'dd/MM/yyyy') AS EntryDate")
            .Append(" ,A.ID")
            .Append(" ,B.ITENNAME as ItemName")
            .Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)) AS PlanningQty")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID ")

            .Append(" WHERE 1=1")
            .Append(_FilterString)
            .Append(" AND MRP='NO'  ")
            .Append(" AND A.SHORTNAME='NEW QUALITY PLANNING'")
            .Append(" ORDER BY A.id ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Party_selection.dgw.DataSource = DefaltSoftTable.Copy
        Party_selection.dgw.Columns("ID").Visible = False
        Party_selection.dgw.Columns(0).Width = 100
        Party_selection.dgw.Columns(1).Width = 130
        Party_selection.dgw.Columns(3).Width = 250
        Party_selection.dgw.Columns(4).Width = 150
        Party_selection.Width = 644
        obj_Party_Selection.SELECTION_LIST_FIRST_SELECTION()
    End Sub


    Public Sub SaveLayout(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _FormName As String)
        Dim _FileName = InputBox("Enter Report Fille Name", "File Name", "", 350, 350)
        If _FileName > "" Then
            Dim _FullFileName = _FileName & CreateGUID() & ".xml"
            _SaveDevGridLayoutFormat(_FileName, _FullFileName, _FormName)
            gridView.SaveLayoutToXml(_FullFileName)
            _GridLayoutSave(_FullFileName)
            MsgBox("File Save Success", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        Else
            MsgBox("Report Not Save", MsgBoxStyle.Critical, "Soft-Tex PRO")
        End If
    End Sub

    Public Sub Load_GridLayout(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _FormName As String)
        DevGrigLayoutLoad._FormName = _FormName
        DevGrigLayoutLoad.ShowDialog()
        If _GridLayoutFileName > "" Then
            gridView.RestoreLayoutFromXml(_GridLayoutFileName)
            _GridLayoutFileName = ""
        End If
    End Sub
    Public Function CleanFileName(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return String.Empty
        End If

        Dim invalidChars As String = New String(Path.GetInvalidFileNameChars())
        Dim regex As New Regex("[" & Regex.Escape(invalidChars) & "]")
        Dim cleaned As String = regex.Replace(input, "")
        Return cleaned.Trim()
    End Function



    Public Sub ToggleTextBoxes(parent As Control, enable As Boolean)

        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Enabled = enable
            End If
            ' अगर अंदर और भी container (जैसे Panel, GroupBox, TabPage) हों
            'If ctrl.HasChildren Then
            '    ToggleTextBoxes(ctrl, enable)
            'End If
        Next

    End Sub
    Public Sub RunSQLNonQuery(query As String)
        sqL = query
        sql_Data_Save_Delete_Update()
    End Sub
    Public Sub _GradingBarcodeTableCreat()
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" 	IF OBJECT_ID('dbo.GradingBarcode','U') IS NULL ")
            .Append(" 	BEGIN ")
            .Append(" CREATE TABLE dbo.GradingBarcode ( ")
            .Append("  Piece_ID BIGINT PRIMARY KEY, ")
            .Append("  BarCode_LumpNo BIGINT  NULL, ")
            .Append("  BarCode_TagNo BIGINT  NULL, ")
            .Append("  CutCode NVARCHAR(50) NULL, ")
            .Append("  CreatedOn DATETIME DEFAULT GETDATE() ")
            .Append("  ) ")
            .Append(" END ")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()

        _BarcodeProducerCreater()

    End Sub

    Private Sub _BarcodeProducerCreater()


        _strQuery = New StringBuilder()
        With _strQuery




            .Append(" IF OBJECT_ID('dbo.InsertGradingBarcode','P') IS NULL ")
            .Append(" BEGIN ")
            .Append("     EXEC('CREATE PROCEDURE dbo.InsertGradingBarcode ")
            .Append("         @Count INT, ")
            .Append("         @CutCode NVARCHAR(50), ")
            .Append("         @Type NVARCHAR(10) ")
            .Append("     AS ")
            .Append("     BEGIN ")
            .Append("         SET NOCOUNT ON; ")

            ' 🔒 Locking for concurrency
            .Append("         EXEC sp_getapplock @Resource = ''InsertGradingBarcode'', @LockMode = ''Exclusive'', @LockOwner = ''Session'', @LockTimeout = 10000; ")


            .Append("         DECLARE @MaxPiece BIGINT; ")
            .Append("         DECLARE @MaxBarcode BIGINT; ")
            .Append("         DECLARE @StartPiece BIGINT; ")

            ' Max Piece_ID
            .Append("         SELECT @MaxPiece = MAX(Piece_ID) ")
            .Append("         FROM ( ")
            .Append("             SELECT ISNULL(Piece_ID,0) AS Piece_ID FROM dbo.GradingBarcode ")
            .Append("             UNION ALL ")
            .Append("             SELECT ISNULL(Piece_ID,0) AS Piece_ID FROM dbo.TrnGrading ")
            .Append("         ) t; ")

            ' Barcode logic according to @Type
            .Append("         IF @Type = ''LUMP'' ")
            .Append("         BEGIN ")
            .Append("             SELECT @MaxBarcode = MAX(BarCode) ")
            .Append("             FROM ( ")
            .Append("                 SELECT ISNULL(BarCode_LumpNo,0) AS BarCode FROM dbo.GradingBarcode ")
            .Append("                 UNION ALL ")
            .Append("                 SELECT ISNULL(BarCode_LumpNo,0) AS BarCode FROM dbo.TrnGrading ")
            .Append("             ) b; ")
            .Append("         END ")
            .Append("         ELSE ")
            .Append("         BEGIN ")
            .Append("             SELECT @MaxBarcode = MAX(BarCode) ")
            .Append("             FROM ( ")
            .Append("                 SELECT ISNULL(BarCode_TagNo,0) AS BarCode FROM dbo.GradingBarcode ")
            .Append("                 UNION ALL ")
            .Append("                 SELECT ISNULL(BarCode_TagNo,0) AS BarCode FROM dbo.TrnGrading ")
            .Append("             ) b; ")
            .Append("         END ")

            .Append("         SET @StartPiece = @MaxPiece; ")

            ' Generate numbers
            .Append("         ;WITH Numbers AS ( ")
            .Append("             SELECT TOP(@Count) ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn ")
            .Append("             FROM master..spt_values a CROSS JOIN master..spt_values b ")
            .Append("         ) ")
            .Append("         INSERT INTO dbo.GradingBarcode (Piece_ID, BarCode_LumpNo, BarCode_TagNo, CutCode) ")
            .Append("         SELECT ")
            .Append("             @MaxPiece + rn, ")
            .Append("             CASE WHEN @Type = ''LUMP'' THEN @MaxBarcode + rn ELSE 0 END, ")
            .Append("             CASE WHEN @Type = ''THAN'' THEN @MaxBarcode + rn ELSE 0 END, ")
            .Append("             @CutCode ")
            .Append("         FROM Numbers; ")

            ' Return newly inserted
            .Append("         SELECT Piece_ID, BarCode_LumpNo, BarCode_TagNo, CutCode, CreatedOn ")
            .Append("         FROM dbo.GradingBarcode ")
            .Append("         WHERE Piece_ID > @StartPiece ")
            .Append("         ORDER BY Piece_ID; ")

            ' Unlock
            .Append("         EXEC sp_releaseapplock @Resource = ''InsertGradingBarcode'', @LockOwner = ''Session''; ")

            .Append("     END ') ")
            .Append(" END ")
        End With
        sqL = _strQuery.ToString()
        sql_Data_Save_Delete_Update()
    End Sub


    Public Sub _BarcodeProducerAlter()
        _strQuery = New StringBuilder()
        With _strQuery
            .Append(" ALTER PROCEDURE dbo.InsertGradingBarcode ")
            .Append("     @Count INT, ")
            .Append("     @CutCode NVARCHAR(50), ")
            .Append("     @Type NVARCHAR(10) ")
            .Append(" AS ")
            .Append(" BEGIN ")
            .Append("     SET NOCOUNT ON; ")
            .Append(" 			 ")
            .Append("     EXEC sp_getapplock @Resource = 'InsertGradingBarcode', @LockMode = 'Exclusive', @LockOwner = 'Session', @LockTimeout = 10000; ")
            .Append(" 			 ")
            .Append("     DECLARE @MaxPiece BIGINT; ")
            .Append("     DECLARE @MaxBarcode BIGINT; ")
            .Append("     DECLARE @StartPiece BIGINT; ")
            .Append(" 			 ")
            .Append("     SELECT @MaxPiece = MAX(Piece_ID) ")
            .Append("     FROM ( ")
            .Append("         SELECT ISNULL(Piece_ID,0) AS Piece_ID FROM dbo.GradingBarcode ")
            .Append("         UNION ALL ")
            .Append("         SELECT ISNULL(Piece_ID,0) AS Piece_ID FROM dbo.TrnGrading ")
            .Append("     ) t; ")
            .Append(" 			 ")
            .Append("     IF @Type IN ('LUMP','THAN') ")
            .Append("     BEGIN ")
            .Append("         SELECT @MaxBarcode = MAX(BarCode) ")
            .Append("         FROM ( ")
            .Append("             SELECT ISNULL(CASE WHEN @Type = 'LUMP' THEN BarCode_LumpNo ELSE BarCode_TagNo END,0) AS BarCode ")
            .Append("             FROM dbo.GradingBarcode ")
            .Append("             UNION ALL ")
            .Append("             SELECT ISNULL(CASE WHEN @Type = 'LUMP' THEN BarCode_LumpNo ELSE BarCode_TagNo END,0) AS BarCode ")
            .Append("             FROM dbo.TrnGrading ")
            .Append("         ) b; ")
            .Append("     END ")
            .Append("     ELSE ")
            .Append("     BEGIN ")
            .Append("         SET @MaxBarcode = 0; ")
            .Append("     END ")
            .Append(" 			 ")
            .Append("     SET @StartPiece = @MaxPiece; ")
            .Append(" 			 ")
            .Append("     ;WITH Numbers AS ( ")
            .Append("         SELECT TOP(@Count) ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rn ")
            .Append("         FROM master..spt_values a CROSS JOIN master..spt_values b ")
            .Append("     ) ")
            .Append("     INSERT INTO dbo.GradingBarcode (Piece_ID, BarCode_LumpNo, BarCode_TagNo, CutCode) ")
            .Append("     SELECT ")
            .Append("         @MaxPiece + rn, ")
            .Append("         CASE WHEN @Type = 'LUMP' THEN @MaxBarcode + rn ELSE 0 END, ")
            .Append("         CASE WHEN @Type = 'THAN' THEN @MaxBarcode + rn ELSE 0 END, ")
            .Append("         @CutCode ")
            .Append("     FROM Numbers; ")
            .Append(" 			 ")
            .Append("     SELECT Piece_ID, BarCode_LumpNo, BarCode_TagNo, CutCode, CreatedOn ")
            .Append("     FROM dbo.GradingBarcode ")
            .Append("     WHERE Piece_ID > @StartPiece ")
            .Append("     ORDER BY Piece_ID; ")
            .Append(" 			 ")
            .Append("     EXEC sp_releaseapplock @Resource = 'InsertGradingBarcode', @LockOwner = 'Session'; ")
            .Append(" END			 ")
        End With

        sqL = _strQuery.ToString()
        sql_Data_Save_Delete_Update()
    End Sub
    Public Function InsertFabricPieces(count As Integer, cutCode As String, type As String) As DataTable
        '_BarcodeProducerCreater(type)
        Dim dt As New DataTable()

        Try
            Using con As New SqlConnection(SqlServerConnectionString)
                con.Open()
                Using cmd As New SqlCommand("InsertGradingBarcode", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Count", count)
                    cmd.Parameters.AddWithValue("@CutCode", cutCode)
                    cmd.Parameters.AddWithValue("@Type", type) ' 'LUMP' or 'THAN'

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
                con.Close()
            End Using

        Catch ex As Exception
            ' Handle exception
            Throw New Exception("Error inserting fabric pieces: " & ex.Message)
        End Try

        Return dt
    End Function




    Public Function SafeFormat(dr As DataRow, colName As String, format As String, Optional zeroAsNull As Boolean = False) As Object
        If dr.Table.Columns.Contains(colName) AndAlso Not IsDBNull(dr(colName)) Then
            Dim val As Double = Convert.ToDouble(dr(colName))
            ' ✅ Agar zeroAsNull true hai aur value 0 hai to DBNull return
            If val = 0 Then
                Return DBNull.Value
            End If
            Return val.ToString(format)
        End If
        Return DBNull.Value
    End Function




    Public Function SafeGetDecimal(dr As DataRow, columnName As String) As Decimal
        If dr Is Nothing OrElse Not dr.Table.Columns.Contains(columnName) Then
            Return 0D
        End If

        If dr.IsNull(columnName) OrElse String.IsNullOrWhiteSpace(dr(columnName).ToString()) Then
            Return 0D
        End If

        Dim result As Decimal = 0D
        Decimal.TryParse(dr(columnName).ToString(), result)
        Return result
    End Function


#Region "Button Focus Color change"
    Public Sub AttachButtonFocusEvents(ByVal _form As Form)
        AttachButtonFocusRecursive(_form, _form)
    End Sub
    Private Sub AttachButtonFocusRecursive(ByVal parent As Control, ByVal _form As Form)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is Button Then
                AddHandler ctrl.GotFocus, Sub(sender, e) Button_FocusChange(sender, e, _form)
                AddHandler ctrl.LostFocus, Sub(sender, e) Button_FocusChange(sender, e, _form)
            ElseIf ctrl.HasChildren Then
                AttachButtonFocusRecursive(ctrl, _form)
            End If
        Next
    End Sub
    Public Sub Button_FocusChange(sender As Object, e As EventArgs, ByVal _form As Form)
        Dim btn As Button = DirectCast(sender, Button)
        btn.BackColor = If(btn.Focused, Color.Coral, _form.BackColor)
    End Sub
#End Region


    Public Sub LogError(ex As Exception)
        Try

            Dim logDir As String = _FolderFilePath("MyAppLogs")

            If Not Directory.Exists(logDir) Then
                Directory.CreateDirectory(logDir)
            End If


            Dim logFileName As String = "ErrorLog_" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
            Dim logPath As String = Path.Combine(logDir, logFileName)


            For Each file As String In Directory.GetFiles(logDir, "ErrorLog_*.txt")
                Dim creationDate As DateTime = System.IO.File.GetCreationTime(file)
                If creationDate < DateTime.Now.AddDays(-60) Then
                    Try
                        System.IO.File.Delete(file)
                    Catch
                    End Try
                End If
            Next


            Dim st As New StackTrace()
            Dim callerMethod As String = If(st.FrameCount > 1, st.GetFrame(1).GetMethod().Name, "Unknown")
            Dim callerClass As String = If(st.FrameCount > 1, st.GetFrame(1).GetMethod().DeclaringType.Name, "Unknown")

            ' ✅ New log entry
            Dim sb As New Text.StringBuilder()
            sb.AppendLine("====================================")
            sb.AppendLine("Date & Time  : " & Now.ToString("dd-MM-yyyy HH:mm:ss"))
            sb.AppendLine("Form/Class   : " & callerClass)
            sb.AppendLine("Function     : " & callerMethod)
            sb.AppendLine("Error Message: " & ex.Message)
            sb.AppendLine("Stack Trace  : " & ex.StackTrace)
            sb.AppendLine("====================================")
            sb.AppendLine()

            File.AppendAllText(logPath, sb.ToString())
        Catch
            ' logging error ignore
        End Try
    End Sub








    Public Function GetValueOrNo(row As DataRow, colName As String) As String
        Dim val As Object = row(colName)
        If val Is Nothing OrElse val Is DBNull.Value Then Return "N"
        Dim str As String = val.ToString().Trim()
        If str = "" Then str = "N"
        If str = "NO" Then str = "N"
        If str = "YES" Then str = "Y"
        Return str
    End Function
    Public Function SingleAccountSelectionForm(loadQuery As String, masterFormType As Type, ByVal prefillSearch As String, ByVal GridViewType As String) As Dictionary(Of String, Object)
        Dim frm As New NewSelectionForm()
        frm.LoadQuery = loadQuery
        frm.F2MasterFormType = masterFormType
        frm.GridViewType = GridViewType
        If Not String.IsNullOrEmpty(prefillSearch) Then
            frm.txtSearch.Text = prefillSearch
        End If
        If frm.ShowDialog() = DialogResult.OK Then
            Return frm.SelectedRowValues
        End If
        Return Nothing
    End Function

    Public Function FlexGridSelectionForm(loadQuery As String, masterFormType As Type, ByVal prefillSearch As String, ByVal GridViewType As String) As Dictionary(Of String, Object)
        Dim frm As New NewFlexCellSelection()
        frm.LoadQuery = loadQuery
        frm.F2MasterFormType = masterFormType
        frm.GridViewType = GridViewType
        If Not String.IsNullOrEmpty(prefillSearch) Then
            frm.TxtSeek.Text = prefillSearch
        End If
        If frm.ShowDialog() = DialogResult.OK Then
            Return frm.SelectedRowValues
        End If
        Return Nothing
    End Function

    Public Function VbDataGridSelectionForm(loadQuery As String, masterFormType As Type, ByVal prefillSearch As String, ByVal GridViewType As String) As Dictionary(Of String, Object)
        Dim frm As New Party_selection()
        frm.LoadQuery = loadQuery
        frm.F2MasterFormType = masterFormType
        frm.GridViewType = GridViewType
        frm.GridSelect = "NEW SELECTION"


        If Not String.IsNullOrEmpty(prefillSearch) Then
            frm.txtSearch.Text = prefillSearch
        End If
        If frm.ShowDialog() = DialogResult.OK Then
            Return frm.SelectedRowValues
        End If
        Return Nothing
    End Function



    Public Function MultyAccountSelectionForm(loadQuery As String, masterFormType As Type, ByVal prefillSearch As String, ByVal GridViewType As String) As List(Of Dictionary(Of String, Object))
        Dim frm As New NewSelectionForm()
        frm.LoadQuery = loadQuery
        frm.F2MasterFormType = masterFormType
        frm.GridViewType = GridViewType

        If Not String.IsNullOrEmpty(prefillSearch) Then
            frm.txtSearch.Text = prefillSearch
        End If

        If frm.ShowDialog() = DialogResult.OK Then
            Return frm.SelectedRowValuesList
        End If

        Return Nothing
    End Function

    Public Function Replacement_Of_String(SourceString As String, strTemplateType As String, strFindString As String, strReplacementString As String) As String
        Dim result As String = SourceString
        Dim num As Integer = SourceString.IndexOf(strFindString.Trim())
        Try
            Dim flag As Boolean = num >= 0 And strReplacementString.Length > 0
            If flag Then
                result = SourceString.Remove(num, strReplacementString.Length).Insert(num, strReplacementString)
            End If
        Catch ex As Exception
        End Try
        Return result
    End Function
    Public Sub _DevGridColumSizeAutoAdjestWhiotTickmarck(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.RowHeight = 25
        gridView.OptionsView.ColumnAutoWidth = False
        gridView.BestFitColumns()
        ' Step 3: Calculate total best-fit width for only visible columns
        Dim totalBestWidth As Integer = 0
        Dim visibleCols As New List(Of DevExpress.XtraGrid.Columns.GridColumn)
        For Each col In gridView.Columns
            col.AppearanceHeader.BackColor = Color.Khaki
            col.AppearanceHeader.BackColor2 = Color.Khaki

            col.AppearanceHeader.Options.UseForeColor = True
            col.AppearanceHeader.Options.UseBackColor = True

            If col.Visible Then
                totalBestWidth += col.Width
                visibleCols.Add(col)
            End If
        Next
        ' Step 4: Available width (adjusted for scrollbar/indicator)
        Dim usableWidth As Integer = gridControl.ClientSize.Width - gridView.IndicatorWidth - 50
        ' Step 5: Resize only visible columns proportionally
        If totalBestWidth > 0 Then
            For Each col In visibleCols
                col.Width = CInt((col.Width / totalBestWidth) * usableWidth)
            Next
        End If

        For Each col In gridView.Columns
            ' Check if column field type is numeric
            If col.ColumnType Is GetType(Integer) OrElse
                   col.ColumnType Is GetType(Decimal) OrElse
                   col.ColumnType Is GetType(Double) OrElse
                   col.ColumnType Is GetType(Single) OrElse
                   col.ColumnType Is GetType(Long) Then
                ' Align header text to the right
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                ' Optionally: also align cell text to right
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        Next

    End Sub
    Public Sub DevGridSummeryAndHideColm(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal columnNames As String())
        For Each colName In columnNames
            Dim summary As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}")
            gridView.Columns(colName).Summary.Clear()
            gridView.Columns(colName).Summary.Add(summary)
            Dim total As Decimal = Convert.ToDecimal(gridView.Columns(colName).SummaryItem.SummaryValue)
            If total = 0D Then
                gridView.Columns(colName).Visible = False
            Else
                gridView.Columns(colName).Visible = True
            End If
        Next
    End Sub
    Public Sub DevGridFitColumnWiotScroll(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.RowHeight = 25
        gridView.OptionsView.ColumnAutoWidth = True
        gridView.BestFitColumns()
        ' Step 3: Calculate total best-fit width for only visible columns
        Dim totalBestWidth As Integer = 0
        Dim visibleCols As New List(Of DevExpress.XtraGrid.Columns.GridColumn)
        For Each col In gridView.Columns
            col.AppearanceHeader.BackColor = Color.Khaki
            col.AppearanceHeader.BackColor2 = Color.Khaki

            col.AppearanceHeader.Options.UseForeColor = True
            col.AppearanceHeader.Options.UseBackColor = True

            'If col.Visible Then
            '    totalBestWidth += col.Width
            '    visibleCols.Add(col)
            'End If
        Next
    End Sub
    Public Sub DevGridFitColumn(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.RowHeight = 25
        gridView.OptionsView.ColumnAutoWidth = False
        gridView.BestFitColumns()
        ' Step 3: Calculate total best-fit width for only visible columns
        Dim totalBestWidth As Integer = 0
        Dim visibleCols As New List(Of DevExpress.XtraGrid.Columns.GridColumn)
        For Each col In gridView.Columns
            col.AppearanceHeader.BackColor = Color.Khaki
            col.AppearanceHeader.BackColor2 = Color.Khaki

            col.AppearanceHeader.Options.UseForeColor = True
            col.AppearanceHeader.Options.UseBackColor = True

            'If col.Visible Then
            '    totalBestWidth += col.Width
            '    visibleCols.Add(col)
            'End If
        Next
    End Sub

    Public Sub _DevGridColumSizeAutoAdjest(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)


        gridView.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.RowHeight = 25
        gridView.OptionsView.ColumnAutoWidth = False

        Dim totalBestWidth As Integer = 0
        Dim visibleCols As New List(Of DevExpress.XtraGrid.Columns.GridColumn)


        For Each col In gridView.Columns
            col.AppearanceHeader.BackColor = Color.Khaki
            col.AppearanceHeader.BackColor2 = Color.Khaki
            col.AppearanceHeader.Options.UseForeColor = True
            col.AppearanceHeader.Options.UseBackColor = True

            If col.Visible Then
                If col.FieldName = "TickMark" Then
                    col.Width = 60 ' Set fixed width
                Else
                    totalBestWidth += col.Width
                    visibleCols.Add(col)
                End If
            End If
        Next

        ' Step 4: Available width minus fixed TickMark column and scrollbar
        Dim usableWidth As Integer = gridControl.ClientSize.Width - gridView.IndicatorWidth - 60 - 50

        ' Step 5: Resize only non-TickMark visible columns proportionally
        If totalBestWidth > 0 Then
            For Each col In visibleCols
                col.Width = CInt((col.Width / totalBestWidth) * usableWidth)
            Next
        End If


        For Each col In gridView.Columns
            ' Check if column field type is numeric
            If col.ColumnType Is GetType(Integer) OrElse
                   col.ColumnType Is GetType(Decimal) OrElse
                   col.ColumnType Is GetType(Double) OrElse
                   col.ColumnType Is GetType(Single) OrElse
                   col.ColumnType Is GetType(Long) Then
                ' Align header text to the right
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                ' Optionally: also align cell text to right
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        Next


    End Sub
    Public Function _GetBackYearDataBaseConnection()

        Dim Last_Year_Code As Integer = 0
        Dim txt_Dt_Box As New ctl_TextBox.ctl_TextBox
        Dim d As String = "01"
        Dim m As String = "04"
        Dim y As String = Mid(Main_MDI_Frm.FINE_YEAR_START.Text, 7)

        Dim Date_Start As String = d & "/" & m & "/" & y
        Dim BackDate_Start As String = "31/03" & "/" & y
        Date_Formate1 = Date_Start
        Date_Formate_set()

        Dim _Selected_Company_Code As String = COMPANY_TBL.Rows(0).Item("COMPANY_CODE")
        RS1 = " SELECT TOP 1 COMP_YEAR_CODE,Data_Folder_Name FROM MSTCOMPANY WHERE COMP_CODE= " & _Selected_Company_Code & " AND FORMAT(Comp_Fin_Year_End,'dd/MM/yyyy')= '" & BackDate_Start & "' "

        DB_CONNECT()
        MSA_CMD1 = New OleDb.OleDbCommand(RS1, MSA_CONN)
        MSA_CMD1.CommandType = CommandType.Text
        Dim ADP As New OleDb.OleDbDataAdapter(MSA_CMD1)
        Dim _BackYearDataTbl As New DataTable
        ADP.Fill(_BackYearDataTbl)
        MSA_CMD1.Dispose()
        MSA_CONN.Close()

        Return _BackYearDataTbl
    End Function
    Public Function _GetServerConnection(ByVal DataBaseName As String)

        Dim conn_address As String = ""
        Dim _serverName As String = sqlServerTbl(0).Item("SQLServerName")

        If sqlServerTbl(0).Item("OP1").ToString = "YES" Then ' SERVER BASE MODULE LOGIN
            conn_address = " Database=" & DataBaseName & ";Server=" & _serverName & ";user=" & sqlServerTbl(0).Item("UserName") & ";password=" & sqlServerTbl(0).Item("UserPassword") & ""
        Else
            If sqlServerTbl.Rows(0).Item("ServerPcName").ToString = Nothing Then
                conn_address = " Data Source=" & _serverName & ";" & "database=" & DataBaseName & ";" & "Integrated Security=SSPI;persist security info=True"
            Else
                conn_address = "  Data Source = " & _serverName & "  ;Initial Catalog= " & DataBaseName & " ;User ID= " & sqlServerTbl(0).Item("UserName") & " ;Password= " & sqlServerTbl(0).Item("UserPassword") & " "
            End If
        End If

        Return conn_address

    End Function
    Public Sub _GridLayoutSave(ByVal fileName As String)

        Dim _FolderName As String = "Grid Layouts"
        Dim strServerName = _FolderFilePath(_FolderName)

        Dim sSource As String = System.Windows.Forms.Application.StartupPath & "\" & fileName

        Dim sTarget As String = strServerName & fileName
        Dim folder As String = strServerName
        If Not System.IO.Directory.Exists(folder) Then
            System.IO.Directory.CreateDirectory(folder)
        End If
        File.Copy(sSource, sTarget, True)

    End Sub
    Public Sub _SaveDevGridLayoutFormat(_FileName As String, _FullFileName As String, _FormName As String)
        _ComapnyYearCode = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        _strQuery = New StringBuilder
        With _strQuery
            .Append("  INSERT INTO Vch_no( ")
            .Append(" Schedule_id")
            .Append(" ,Group_master_finance")
            .Append(" ,Main_account_master")
            .Append(" ,STATEMASTER")
            .Append(" ) VALUES ( ")
            .Append(" '" & _FileName & "' ")
            .Append(" ,'" & _FullFileName & "' ")
            .Append(" ,'" & _FormName & "' ")
            .Append(" ,'" & _ComapnyYearCode & "' ")
            .Append(" ) ")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()
    End Sub
    Public Function _CheckAlterDays(Billdate As String)
        Dim _AlterDaysCheck As Boolean = True
        Dim AlterDays As Integer = pub_Data_Alter_Days
        If AlterDays > 0 Then
            ALterDateBilldate.Text = Billdate
            Generate_Date_For_DataBase(ALterDateBilldate)
            Dim _Curdate As Date = CDate(Date.Now).ToString("yyyy-MM-dd")
            Dim _Billdate As Date = ALterDateBilldate.Date_for_Database
            Dim days As Integer = (_Curdate - _Billdate).Days
            If days > AlterDays Then
                _AlterDaysCheck = False
            End If
        End If

        Return _AlterDaysCheck
    End Function
    Public Function GetImageData(Image As PictureBox)
        Dim data As Byte()
        'Dim Image As PictureBox
        'Image.ImageLocation = ImagePath
        'Image.Load()

        'Create an empty stream in memory.
        Using stream As New IO.MemoryStream
            'Fill the stream with the binary data from the Image.
            Image.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)

            'Get an array of Bytes from the stream.
            data = stream.ToArray()
        End Using

        Return data
    End Function
    Public Sub _DevExpressPrintPrivew(ByVal PrintHeader As String, ByVal GridPrint As DevExpress.XtraGrid.Views.Grid.GridView)
        GridPrint.OptionsPrint.RtfPageHeader = PrintHeader
        GridPrint.ShowPrintPreview()
    End Sub
    Public Sub _DevExpressExcelExport(ByVal GridExport As DevExpress.XtraGrid.GridControl)

        Dim saveDialog As SaveFileDialog = New SaveFileDialog()
        saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx "

        If saveDialog.ShowDialog() <> DialogResult.Cancel Then
            Dim exportFilePath As String = saveDialog.FileName
            Dim fileExtenstion As String = New FileInfo(exportFilePath).Extension
            Select Case fileExtenstion
                Case ".xlsx"
                    GridExport.ExportToXlsx(exportFilePath)
                    Process.Start(exportFilePath)
            End Select
        End If

    End Sub

    Public Function _WhatsappSending(ByVal MobileNo As String, ByVal Message As String, ByVal cache As String, ByRef PdfUrl As String, ByRef contentType As String, Optional ByVal isDefaultCall As Boolean = False) As String
        Dim res As Boolean = False


        If _WhatsUpSend = "NO" Then
            MsgBox("User Not Allow Send WhatsUp", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Function
        End If


        sqL = " SELECT * FROM Creat_company"
        sql_connect_slect()
        Dim _TmpCompTbl As New DataTable
        _TmpCompTbl = DefaltSoftTable.Copy

        Dim defaultNumbers As New List(Of String)

        If _TmpCompTbl.Rows.Count > 0 Then
            defaultNumbers.Add(_TmpCompTbl.Rows(0).Item("OP5").ToString.Trim())
            defaultNumbers.Add(_TmpCompTbl.Rows(0).Item("OP6").ToString.Trim())
            defaultNumbers.Add(_TmpCompTbl.Rows(0).Item("OP7").ToString.Trim())
        End If

        sqL = " SELECT OP48 AS MOBILENO_2,OP49 AS MOBILENO_3 FROM MstMasterAccount WHERE MOBILE='" & MobileNo & "'"
        sql_connect_slect()
        For Each DR As DataRow In DefaltSoftTable.Select()
            Dim MOBILENO_2 = DR("MOBILENO_2").ToString().Trim()
            Dim MOBILENO_3 = DR("MOBILENO_3").ToString().Trim()
            If MOBILENO_2 > "" Then
                defaultNumbers.Add(MOBILENO_2)
            End If
            If MOBILENO_3 > "" Then
                defaultNumbers.Add(MOBILENO_3)
            End If
        Next


        If SendOnlyDefaltNoWhatsapp = "YES" Then
            MobileNo = SendWhatsappDefaltMobileNo
        End If

        defaultNumbers.Add(MobileNo)
        defaultNumbers.Add(SendWhatsappDefaltMobileNo)

        Dim cleanNumbers = defaultNumbers.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).Distinct()

        For Each MobileNo In cleanNumbers

            If _whatsappselectionmode = "MANUAL" Or _whatsappselectionmode = "USER WISE" Then
                Dim WhatsAppAPIURL As String = ""

                'If contentType = 2 Then
                '    'ITS PRIVATE SMS ++++++++++++++++++
                '    WhatsAppAPIURL = WhatsAppUrl & "apikey=" & WhatsAppKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache & "&pdf=" & PdfUrl
                'ElseIf contentType = 3 Then

                '    WhatsAppAPIURL = WhatsAppUrl & "apikey=" & WhatsAppKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache & "&img1=" & PdfUrl
                'Else
                '    'ITS PRIVATE SMS ++++++++++++++++++
                '    WhatsAppAPIURL = WhatsAppUrl & "apikey=" & WhatsAppKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache
                'End If

                If _whatsappselectionmode = "MANUAL" Then
                    WhatsAppAPIURL = _WhatsappCompanyWiseURLSelection("ITS PRIVATE", MobileNo, Message, cache, PdfUrl, contentType)
                Else
                    WhatsAppAPIURL = _WhatsappCompanyWiseURLSelection(_WhatsappSendCompany, MobileNo, Message, cache, PdfUrl, contentType)
                End If



                res = RecivedStoreRoom.SendSMS(WhatsAppAPIURL)
            ElseIf _whatsappselectionmode = "MANUAL-1" Or _whatsappselectionmode = "RANGER" Then

                Dim WhatsAppAPIURL As String = ""
                WhatsAppAPIURL = _WhatsappCompanyWiseURLSelection("EASY SENDER", MobileNo, Message, cache, PdfUrl, contentType)
                res = RecivedStoreRoom.SendSMS(WhatsAppAPIURL)

            ElseIf _whatsappselectionmode = "MANUAL-2" Then
                'one site up whatsapp send
                res = False
                If contentType = 1 Then
                    Dim _TmplateType = "msg"
                    Dim _MessageType = "text" ' text/file
                    Dim client = New RestClient(WhatsAppUrl)
                    Dim request = New RestRequest(Method.POST)
                    request.AlwaysMultipartFormData = True
                    request.AddParameter("templete", _TmplateType)
                    request.AddParameter("api", WhatsAppKey)
                    request.AddParameter("phone", "91" & MobileNo)
                    request.AddParameter("type", _MessageType)
                    request.AddParameter("msg", Message)
                    Dim response As RestResponse = client.Execute(request)
                    If response.StatusCode = System.Net.HttpStatusCode.OK Then
                        res = True
                    End If

                ElseIf contentType = 2 Then
                    res = False
                    Dim _TmplateType = "msg_media"
                    Dim _MessageType = "file" ' text/file
                    Dim client = New RestClient(WhatsAppUrl)
                    Dim request = New RestRequest(Method.POST)
                    request.AlwaysMultipartFormData = True
                    request.AddParameter("templete", _TmplateType)
                    request.AddParameter("api", WhatsAppKey)
                    request.AddParameter("phone", "91" & MobileNo)
                    request.AddParameter("type", _MessageType)
                    request.AddParameter("msg", COMPANY_NAME)
                    request.AddParameter("url", PdfUrl)
                    request.AddParameter("fileName", Message & CreateGUID())
                    request.AddParameter("mediaType", "pdf") ' pdf, png, jpeg
                    Dim response As RestResponse = client.Execute(request)
                    If response.StatusCode = System.Net.HttpStatusCode.OK Then
                        res = True
                    End If
                ElseIf contentType = 3 Then
                    res = False
                    Dim _TmplateType = "msg_media"
                    Dim _MessageType = "file" ' text/file
                    Dim client = New RestClient(WhatsAppUrl)
                    Dim request = New RestRequest(Method.POST)
                    request.AlwaysMultipartFormData = True
                    request.AddParameter("templete", _TmplateType)
                    request.AddParameter("api", WhatsAppKey)
                    request.AddParameter("phone", "91" & MobileNo)
                    request.AddParameter("type", _MessageType)
                    request.AddParameter("msg", COMPANY_NAME)
                    request.AddParameter("url", PdfUrl)
                    request.AddParameter("fileName", Message)
                    request.AddParameter("mediaType", "jpeg") ' pdf, png, jpeg
                    Dim response As RestResponse = client.Execute(request)
                    If response.StatusCode = System.Net.HttpStatusCode.OK Then
                        res = True
                    End If
                End If
            ElseIf _whatsappselectionmode = "DEAL" Then

                Dim WhatsAppAPIURL As String = ""
                If contentType = 2 Then
                    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=media&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & COMPANY_NAME & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
                ElseIf contentType = 3 Then
                    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=media&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & COMPANY_NAME & ".jpeg" & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken

                Else
                    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=text&message=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
                End If
                res = RecivedStoreRoom.SendSMS(WhatsAppAPIURL)
            Else
                Dim WhatsAppAPIURL As String = ""
                If contentType = 2 Then
                    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & Message & "&instance_id=66DABB2BE2987&access_token=66dabb1754844"
                Else
                    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&message=" & Message & "&instance_id=66DABB2BE2987&access_token=66dabb1754844"
                End If

                'If contentType = 2 Then
                '    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=media&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & Message & "&instance_id=684FF85238072&access_token=674455f3e2ac7"
                'Else
                '    WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=text&message=" & Message & "&instance_id=684FF85238072&access_token=674455f3e2ac7"
                'End If



                res = RecivedStoreRoom.SendSMS(WhatsAppAPIURL)
            End If
        Next
        Return res
    End Function
    Public Function _WhatsappCompanyWiseURLSelection(ByVal CompanyName As String, ByVal MobileNo As String, ByVal Message As String, ByVal cache As String, ByRef PdfUrl As String, ByRef contentType As String)
        Dim WhatsAppAPIURL As String = ""
        If CompanyName = "ITS PRIVATE" Then
            If contentType = 2 Then
                'ITS PRIVATE SMS ++++++++++++++++++
                WhatsAppAPIURL = WhatsAppUrl & "apikey=" & WhatsAppKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache & "&pdf=" & PdfUrl
            ElseIf contentType = 3 Then

                WhatsAppAPIURL = WhatsAppUrl & "apikey=" & WhatsAppKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache & "&img1=" & PdfUrl
            Else
                'ITS PRIVATE SMS ++++++++++++++++++
                WhatsAppAPIURL = WhatsAppUrl & "apikey=" & WhatsAppKey & "&mobile=" & MobileNo & "&msg=" & Message & "&cache=" & cache
            End If
        ElseIf CompanyName = "RANGER" Then
            If contentType = 2 Then
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
            Else
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&message=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
            End If
        ElseIf CompanyName = "DEAL" Then

            If contentType = 2 Then
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=media&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
            ElseIf contentType = 3 Then
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=media&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & Message & ".jpeg" & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken

            Else
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&type=text&message=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
            End If

        ElseIf CompanyName = "EASY SENDER" Then
            If contentType = 2 Then
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&message=" & Message & "&media_url=" & PdfUrl & "&filename=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
            Else
                WhatsAppAPIURL = WhatsAppUrl & "number=91" & MobileNo & "&message=" & Message & "&instance_id=" & WhatsAppKey & "&access_token=" & WhatsAppToken
            End If
        End If

        Return WhatsAppAPIURL
    End Function
    Public Function _reportFileQRcodeLoad(ByVal _report As String) As String
        Dim _SelectedReportFileName As String = ""
        If _ReportLoadOption = "YES" Then
            If _CheckServerPcs = True Then
                _SelectedReportFileName = (System.Windows.Forms.Application.StartupPath + "\QRCode Image\" & _report & ".png")
            Else
                _SelectedReportFileName = (_ServerPcPath + "\QRCode Image\" & _report & ".png")
            End If
        Else
            _SelectedReportFileName = (System.Windows.Forms.Application.StartupPath + "\QRCode Image\" & _report & ".png")
        End If

        Return _SelectedReportFileName
    End Function
    Public Function _FolderFilePath(ByVal _FolderName As String) As String
        Dim ImageFolderNmae As String = ""
        If _CheckServerPcs = True Then
            If Directory.Exists(System.Windows.Forms.Application.StartupPath & "\" & _FolderName) Then
            Else
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\" & _FolderName)
            End If
            ImageFolderNmae = (System.Windows.Forms.Application.StartupPath + "\" & _FolderName & "\")
        Else
            If Directory.Exists(_ServerPcPath & "\" & _FolderName) Then
            Else
                Directory.CreateDirectory(_ServerPcPath & "\" & _FolderName)
            End If

            ImageFolderNmae = (_ServerPcPath + "\" & _FolderName & "\")
        End If
        Return ImageFolderNmae
    End Function
    Public Function _TextFilePath(ByVal _FileName As String) As String
        Dim FilePath As String = ""

        If _CheckServerPcs = True Then
            ' Local path
            FilePath = Path.Combine(Application.StartupPath, _FileName)
        Else
            ' Server path
            FilePath = Path.Combine(_ServerPcPath, _FileName)
        End If

        If Not File.Exists(FilePath) Then
            Try
                File.WriteAllText(FilePath, "")
            Catch ex As Exception
                MessageBox.Show("Unable to create file: " & ex.Message)
            End Try
        End If

        Return FilePath
    End Function



    Public Function _reportFileSelection(ByVal _report As String) As String
        Dim _SelectedReportFileName As String = ""
        If _ReportLoadOption = "YES" Then
            If _CheckServerPcs = True Then
                _SelectedReportFileName = (System.Windows.Forms.Application.StartupPath + "\Reports\" & _report & ".rpt")
            Else
                _SelectedReportFileName = (_ServerPcPath + "\Reports\" & _report & ".rpt")
            End If
        Else
            _SelectedReportFileName = (System.Windows.Forms.Application.StartupPath + "\Reports\" & _report & ".rpt")
        End If

        Return _SelectedReportFileName
    End Function
    Public Function Next_Year_Exist(Optional Show_Message As Boolean = True) As Boolean
        Dim result As Boolean
        Dim d As String = "01"
        Dim m As String = "04"
        Dim y As String = Mid(Main_MDI_Frm.FINE_YEAR_END.Text, 7)
        Dim Date_Start As String = d & "/" & m & "/" & y
        Date_Formate1 = Date_Start
        Date_Formate_set()
        Dim _Selected_Company_Code As String = COMPANY_TBL.Rows(0).Item("COMPANY_CODE")
        RS1 = " SELECT TOP 1 COMP_YEAR_CODE,Data_Folder_Name FROM MSTCOMPANY WHERE COMP_CODE= " & _Selected_Company_Code & " AND FORMAT(COMP_FIN_YEAR_START,'dd/MM/yyyy')= '" & Date_Start & "' "
        DB_CONNECT()
        MSA_CMD1 = New OleDb.OleDbCommand(RS1, MSA_CONN)
        MSA_CMD1.CommandType = CommandType.Text
        Dim ADP As New OleDb.OleDbDataAdapter(MSA_CMD1)
        Dim TAB As New DataTable
        ADP.Fill(TAB)
        MSA_CMD1.Dispose()
        MSA_CONN.Close()
        Dim Next_Year_Code As Integer = 0

        Dim flag As Boolean = TAB.Rows.Count > 0
        If flag Then
            Next_Year_Database_Name = TAB.Rows(0).Item(1)
            result = flag
        Else
            result = False
            If Show_Message Then
                MsgBox("Next Year Not Found", MsgBoxStyle.Information, "Soft-Tex PRO")
            End If
        End If
        Return result
    End Function
    Public Sub ShowForm(WhichForm As Form)
        Try

            With WhichForm
                .ShowDialog()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub





    Public Sub ShowFormMDI(WhichForm As Form)
        Try
            With WhichForm
                .MdiParent = Main_MDI_Frm
                .Show()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub
    Public Sub ShowFormFromMenu(menuItem As ToolStripMenuItem, formToShow As Form)
        If menuItem Is Nothing OrElse formToShow Is Nothing Then Return

        Try
            ' Build menu path
            Dim path As New List(Of String)
            Dim current As ToolStripItem = menuItem

            While current IsNot Nothing
                path.Insert(0, current.Text)
                If TypeOf current.Owner Is ToolStripDropDownMenu Then
                    current = TryCast(current.OwnerItem, ToolStripItem)
                Else
                    Exit While
                End If
            End While

            Dim menuPath As String = String.Join(">", path)

            ' Show form with menu path
            With formToShow
                .MdiParent = Main_MDI_Frm
                .Tag = menuPath
                .Show()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Public Sub ShowFormMDI_NewCloseFunction(WhichForm As Form, LastOpenedMenuPath As String)
        Try
            With WhichForm
                .MdiParent = Main_MDI_Frm
                .Tag = LastOpenedMenuPath
                .Show()

            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

    End Sub


    Public Sub Wait_Window_Show(ByVal Owner_Form As Form, ByVal Msg_Str As String)
        'Frm_Msg = New Wait_Msg_Form
        If Not IsNothing(Frm_Msg) Then
            Frm_Msg = New Wait_form
            'Frm_Msg = New WaitForm1
        End If
        Frm_Msg.Label1.Text = Msg_Str
        Frm_Msg.Owner = Owner_Form
        Frm_Msg.Show()
        Frm_Msg.Refresh()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
    End Sub

    Public Sub Wait_Window_Hide()
        'Frm_Msg.Hide()
        Frm_Msg.Close()
        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Public Function check_FinYearDate(ByVal Enterdate As String) As String
        Dim enter_date As String

        Try
            Date_Formate1 = Enterdate
            Date_Formate2 = Main_MDI_Frm.FINE_YEAR_START.Text
            Date_Formate3 = Main_MDI_Frm.FINE_YEAR_END.Text
            Date_Formate_set()
            If Date_1 >= Date_2 And Date_1 <= Date_3 Then

            Else
                MsgBox("Date Range Between ( " + Date_Formate2 + " TO " + Date_Formate3 + " )", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                'Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return enter_date
    End Function
    Public Function RemoveCharacter(ByVal stringToCleanUp As Object, ByVal characterToRemove As Object) As String
        Return Strings.Replace(Conversions.ToString(stringToCleanUp), Conversions.ToString(characterToRemove), "", 1, -1, CompareMethod.Binary)
    End Function

    Public Function NumToWord(ByVal Num As Decimal) As String
        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord
    End Function
    Public Function cWordG3(ByVal Num As Decimal) As String
        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3
    End Function
    Public Function strReplicate(ByVal str As String, ByVal intD As Integer) As String
        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        Dim i As Integer
        strReplicate = ""
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate
    End Function
    Public Function cWord3(ByVal Num As Decimal) As String
        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3
    End Function
    Public Function retWord(ByVal Num As Decimal) As String
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"},
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"},
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord
    End Function
    Public Function AmtInWord(ByVal Num As Decimal) As String
        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " Rupees and " + cWord3(CDbl(strNumDec)) + "Paise", "Rupees")
        Else
            StrWord = NumToWord(CDbl(strNum))
        End If
        AmtInWord = StrWord & " Only"
        Return AmtInWord.ToString.Trim
    End Function

    Public Function IsFileOpen(file As FileInfo) As String
        Dim result As String = ""
        Try
            Dim fileStream As FileStream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            fileStream.Close()
            fileStream.Dispose()
        Catch ex As Exception
            result = ex.ToString()
        End Try
        Return result
    End Function
    Public Function ConvertImageFiletoBytes(ImageFilePath As String) As Byte()
        Dim flag As Boolean = String.IsNullOrEmpty(ImageFilePath)
        If flag Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
        End If
        Dim result As Byte()
        Try
            Dim fileInfo As FileInfo = New FileInfo(ImageFilePath)
            Dim length As Long = fileInfo.Length
            Dim fileStream As FileStream = New FileStream(ImageFilePath, FileMode.Open, FileAccess.Read)
            Dim binaryReader As BinaryReader = New BinaryReader(fileStream)
            Dim array As Byte() = binaryReader.ReadBytes(Convert.ToInt32(length))
            fileStream.Close()
            fileStream.Dispose()
            binaryReader.Close()
            result = array
        Catch ex As Exception
            result = Nothing
        End Try
        Return result
    End Function
    Public Function Set_Bill_Date() As String
        Dim max_date As String
        Dim dateTime1 As String = Main_MDI_Frm.FINE_YEAR_END.Text
        Dim dt1 As DateTime = Convert.ToDateTime(dateTime1)
        Dim format1 As String = "yyyy-MM-dd"
        Dim BILL_DATE As String = dt1.ToString(format1)
        max_date = BILL_DATE >= CDate(Date.Now).ToString("yyyy-MM-dd")

        If max_date = False Then
            new_bill_date_check = Main_MDI_Frm.FINE_YEAR_END.Text
        Else
            new_bill_date_check = CDate(Date.Now).ToString("dd/MM/yyyy")
        End If


        Return max_date
    End Function
    Public Function RemoveSpecialCharacter(ByVal Readlinevalue As String) As String
        Return Regex.Replace(Readlinevalue, ".[(),=\]\[;./~!@#$%^*+{}|:?\\\'""]", "")
    End Function
    Public Sub Generate_DataTable_For_Grid(ByRef GridDataTable As DataTable, ByRef grdObj As FlexCell.Grid, ByVal _gridColNames As StringBuilder, ByVal _gridColType As StringBuilder, ByVal _gridLastColNo As Integer, ByVal _GridMaxRow As Integer)
        ObjCls_General.CreateDataTable(GridDataTable, _gridColNames.ToString.ToUpper, "NO", _gridColType.ToString)

        grdObj.ExtendLastCol = True
        _gridLastColNo = GridDataTable.Columns.Count
        grdObj.Cols = GridDataTable.Columns.Count + 1
        grdObj.Rows = _GridMaxRow
    End Sub
    Public Sub Grid_Formatting(ByRef GridDataTable As DataTable, ByRef grdObj As FlexCell.Grid, ByVal _FieldGridNotVisibile As StringBuilder, ByVal _FieldGridWidthSet As StringBuilder, ByVal _FieldGridHeader As StringBuilder, ByVal _FieldGridLocked As StringBuilder, ByVal _FieldGridMasking As StringBuilder, ByVal _FieldGridAlignMent As StringBuilder, ByVal _FieldGridHeaderAlignment As StringBuilder)

        grdObj.AutoRedraw = False
        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "VISIBLE", _FieldGridNotVisibile.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "WIDTH", _FieldGridWidthSet.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "HEADER", _FieldGridHeader.ToString)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "LOCK", _FieldGridLocked.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "MASK", _FieldGridMasking.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "ALIGNMENT", _FieldGridAlignMent.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(GridDataTable, grdObj, "HALIGNMENT", _FieldGridHeaderAlignment.ToString.ToUpper)
        For i As Integer = 0 To grdObj.Cols - 1
            grdObj.Cell(0, i).Font = xFont
        Next
        grdObj.AutoRedraw = True
        grdObj.Refresh()
    End Sub
    Public Function Default_Grid_Focus_Fields(ByVal GrdObj As FlexCell.Grid, ByVal Column_Name As String, ByVal DataTable_Name As DataTable, ByVal Default_Column_No As Integer)
        Dim Activated_ColName As String = ""
        GrdObj.Locked = True
        Default_Column_No = 0
        Default_Column_No = DataTable_Name.Columns.IndexOf(Column_Name) + 1
        GrdObj.Cell(1, Default_Column_No).SetFocus()
        Activated_ColName = Column_Name
        GrdObj.Locked = False
        Return Activated_ColName
    End Function
    Public Sub Ctrl_Visible_True(ByVal coll As System.Windows.Forms.Control.ControlCollection)
        Dim ctl As Object
        For Each ctl In coll
            If ctl.hasChildren = True Then
                Call Ctrl_Visible_True(ctl.controls)
            ElseIf TypeOf ctl Is TextBox Then
                ctl.visible = True
            ElseIf TypeOf ctl Is ctl_TextBox.ctl_TextBox Then
                ctl.visible = True
            ElseIf TypeOf ctl Is FlexCell.Grid Then
                ctl.visible = True
                'ElseIf TypeOf ctl Is MultiColComboBox Then
                '    ctl.visible = True
            ElseIf TypeOf ctl Is System.Windows.Forms.ComboBox Then
                ctl.visible = True
            End If
        Next
    End Sub
    Public Sub Ctrl_Visible_False(ByVal coll As System.Windows.Forms.Control.ControlCollection)
        Dim ctl As Object
        For Each ctl In coll
            If ctl.hasChildren = True Then
                Call Ctrl_Visible_True(ctl.controls)
            ElseIf TypeOf ctl Is TextBox Then
                ctl.visible = False
            ElseIf TypeOf ctl Is ctl_TextBox.ctl_TextBox Then
                ctl.visible = False
            ElseIf TypeOf ctl Is FlexCell.Grid Then
                ctl.visible = False
                'ElseIf TypeOf ctl Is MultiColComboBox Then
                '    ctl.visible = False
            ElseIf TypeOf ctl Is System.Windows.Forms.ComboBox Then
                ctl.visible = False
            End If
        Next
    End Sub
    Public Function FORMAT_NUMERIC(ByVal DBvalue As Double, ByVal _DecimalPlaces As Integer) As Double
        Return FormatNumber(Val(DBvalue), _DecimalPlaces, TriState.True, TriState.False, TriState.False)
    End Function
    Public Function Get_Last_Entry_No_According_To_BookCode(ByVal _BookCode As String, ByVal DataBase_TableName As String) As Integer
        Get_Last_Entry_No_According_To_BookCode = 0
        strQuery = " SELECT TOP 1 ENTRYNO FROM " & DataBase_TableName & " WHERE BOOKCODE='" & _BookCode & "'" & " ORDER BY  BOOKVNO DESC "
        sqL = strQuery
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            Get_Last_Entry_No_According_To_BookCode = DefaltSoftTable.Rows(0).Item(0)
        End If
        Return Get_Last_Entry_No_According_To_BookCode
    End Function
    Public Function Check_Duplicate_Vno(ByVal CheckValue As String, ByVal TblName As String, ByVal Book_Code As String, ByVal LeaveKeyValue As String, ByVal Field_Name_For_Check As String, ByVal ENTRY_MODE As String, Optional ByVal Msg_First_Str As String = "") As Boolean
        Dim _ReturnValue As Integer = -1
        Dim _ErrorValue As String = ""
        Dim _TransctionNo As Integer = 0

        If ENTRY_MODE = "ADD" Then
            strQuery = "SELECT TOP  1 entryNO FROM " & TblName & " WHERE " & Field_Name_For_Check & "='" & CheckValue & "'  AND BOOKCODE='" & Book_Code & "' ORDER BY ENTRYNO DESC"
        Else
            strQuery = "SELECT TOP  1 entryNO FROM " & TblName & " WHERE " & Field_Name_For_Check & "='" & CheckValue & "'  AND BOOKCODE='" & Book_Code & "' AND BOOKVNO<>'" & LeaveKeyValue & "' ORDER BY ENTRYNO DESC"
        End If
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = DefaltSoftTable.Rows(0).Item(0)
        End If


        If _TransctionNo > 0 Then
            _ErrorValue = "Value Exist"
            MsgBox(IIf(Msg_First_Str = "", "Value", Msg_First_Str) & " Already Exist In  Entry No:" + Trim(Str(_TransctionNo)), MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        End If
        If _ErrorValue = "" Then
            Check_Duplicate_Vno = True
        Else
            _ErrorValue = Strings.Mid(_ErrorValue, 1, _ErrorValue.Length - 1)
            Check_Duplicate_Vno = False
        End If
    End Function
    Public Function GetMaxVoucherNo_According_To_BookCode(ByVal _BookCode As String, ByVal DataBase_TableName As String) As String
        Dim MaxNo As Integer = 0
        strQuery = " SELECT TOP 1  max (ENTRYNO) as ENTRYNO  FROM " & DataBase_TableName & " WHERE BOOKCODE='" & _BookCode & "'" & " "
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            For Each dr As DataRow In DefaltSoftTable.Select
                If dr.IsNull("ENTRYNO") Then dr("ENTRYNO") = 0
            Next
            MaxNo = DefaltSoftTable.Rows(0).Item(0) + 1
        Else
            MaxNo = 1
        End If
        Return MaxNo
    End Function
    Public Sub FocusSetToGridDefaultColumn(ByVal Grd_Obj As FlexCell.Grid, ByVal ColumnNo As Integer)
        Dim IsEnabledFalseGrid As Boolean = True

        If Grd_Obj.Enabled = False Then
            IsEnabledFalseGrid = False
        End If

        If Grd_Obj.Rows < 2 Then
            Grd_Obj.Rows = 2
        End If

        Grd_Obj.Cell(1, ColumnNo).SetFocus()
        Grd_Obj.Cell(1, ColumnNo).Text = "1"

        If IsEnabledFalseGrid = False Then
            Grd_Obj.Enabled = False
        End If
    End Sub
    Public Sub Ctrl_Visibility_With_One_Grid(ByVal Visible_Flag As Boolean, ByVal coll As System.Windows.Forms.Control.ControlCollection, ByRef grdObj1 As FlexCell.Grid)
        Dim ctl As Object
        For Each ctl In coll
            If ctl.hasChildren = True Then
                Call Ctrl_Visible_True(ctl.controls)
            ElseIf TypeOf ctl Is TextBox Then
                ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is ctl_TextBox.ctl_TextBox Then
                ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is FlexCell.Grid Then
                ctl.visible = Visible_Flag
                'ElseIf TypeOf ctl Is MultiColComboBox Then
                '    ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is System.Windows.Forms.ComboBox Then
                ctl.visible = Visible_Flag
            End If
        Next
        grdObj1.Enabled = Visible_Flag
    End Sub
    Public Sub Generate_Table(ByVal Grid_Maximun_Rows As Integer, ByVal Grid_Field_Types As StringBuilder, ByVal Grid_Field_Names As StringBuilder, ByRef Grid_Data_Table As DataTable, ByRef grdObj As FlexCell.Grid)
        ObjCls_General.CreateDataTable(Grid_Data_Table, Grid_Field_Names.ToString.ToUpper, "NO", Grid_Field_Types.ToString)
        grdObj.ExtendLastCol = True
        grdObj.Cols = Grid_Data_Table.Columns.Count + 1


        grdObj.Rows = Grid_Maximun_Rows

    End Sub
    Public Sub Grid_Field_Setting(ByVal Field_Name_Header_Alignment_String As StringBuilder, ByVal Field_Name_Alignment_String As StringBuilder, ByVal Field_Name_Masking_String As StringBuilder, ByVal Field_Name_Locked_String As StringBuilder, ByVal Field_Name_Header_String As StringBuilder, ByVal Field_Name_Width_String As StringBuilder, ByVal Field_Name_Not_Visibile_String As StringBuilder, ByVal Data_Table_Name As DataTable, ByVal Grid_Name As FlexCell.Grid)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "VISIBLE", Field_Name_Not_Visibile_String.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "WIDTH", Field_Name_Width_String.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "HEADER", Field_Name_Header_String.ToString)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "LOCK", Field_Name_Locked_String.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "MASK", Field_Name_Masking_String.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "ALIGNMENT", Field_Name_Alignment_String.ToString.ToUpper)
        Call ObjCls_General._LibGridFormatting(Data_Table_Name, Grid_Name, "HALIGNMENT", Field_Name_Header_Alignment_String.ToString.ToUpper)

        Dim xFont = New Font("Verdana", 9, FontStyle.Bold)
        For i As Integer = 0 To Grid_Name.Cols - 1
            Grid_Name.Cell(0, i).Font = xFont
        Next

    End Sub
    Public Sub Ctrl_Visibility_With_Two_Grid(ByVal Visible_Flag As Boolean, ByVal coll As System.Windows.Forms.Control.ControlCollection, ByRef grdObj1 As FlexCell.Grid, ByRef grdObj2 As FlexCell.Grid)
        Dim ctl As Object
        For Each ctl In coll
            If ctl.hasChildren = True Then
                Call Ctrl_Visible_True(ctl.controls)
            ElseIf TypeOf ctl Is TextBox Then
                ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is ctl_TextBox.ctl_TextBox Then
                ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is FlexCell.Grid Then
                ctl.visible = Visible_Flag
                'ElseIf TypeOf ctl Is MultiColComboBox Then
                '    ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is System.Windows.Forms.ComboBox Then
                ctl.visible = Visible_Flag
            End If
        Next
        grdObj1.Enabled = Visible_Flag
        grdObj2.Enabled = Visible_Flag
    End Sub

    Public Sub Ctrl_Visibility_OnlyTextbox(ByVal Visible_Flag As Boolean, ByVal coll As System.Windows.Forms.Control.ControlCollection)
        Dim ctl As Object
        For Each ctl In coll
            If ctl.hasChildren = True Then
                Call Ctrl_Visible_True(ctl.controls)
            ElseIf TypeOf ctl Is TextBox Then
                ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is ctl_TextBox.ctl_TextBox Then
                ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is FlexCell.Grid Then
                ctl.visible = Visible_Flag
                'ElseIf TypeOf ctl Is MultiColComboBox Then
                '    ctl.visible = Visible_Flag
            ElseIf TypeOf ctl Is System.Windows.Forms.ComboBox Then
                ctl.visible = Visible_Flag
            End If
        Next
    End Sub

    Public Sub Fill_Serial_No(ByVal GrdObj As FlexCell.Grid, ByVal DataTable_Name As DataTable, ByVal SrNo_VariableName As Integer)
        If GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = "" Then
            GrdObj.Cell(GrdObj.ActiveCell.Row, DataTable_Name.Columns.IndexOf("SRNO") + 1).Text = SrNo_VariableName
        End If
    End Sub
    Public Function Date_Check_According_To_Financial_Year(ByVal TxtBox As ctl_TextBox.ctl_TextBox, ByVal Frm_Load As Boolean) As Boolean
        Dim Valid_Date As Boolean = True

        Date_Formate1 = Main_MDI_Frm.FINE_YEAR_START.Text
        Date_Formate2 = Main_MDI_Frm.FINE_YEAR_END.Text
        Date_Formate_set()


        Dim St_Date As String = Date_1
        Dim Ed_Date As String = Date_2
        Dim d As String = Mid(TxtBox.Text, 1, 2)
        Dim m As String = Mid(TxtBox.Text, 4, 2)
        Dim y As String = Mid(TxtBox.Text, 7)

        If TxtBox.Text = "  /  /    " Then
            MsgBox("Invalid Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Exit Function
        End If

        If Len(Trim(TxtBox.Text)) < 10 Then
            TxtBox.Text = "  /  /    "
            MsgBox("Invalid Date", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            Exit Function
        End If

        Dim Final_Date As String = Val(d) & "-" & Strings.Mid(MonthName(Val(m)), 1, 3) & "-" & Val(y)

        If TxtBox.Text <> " " Then
            If St_Date <> "" Then
                If DateDiff(DateInterval.Day, CDate(St_Date), CDate(Final_Date)) < 0 Then
                    Valid_Date = False
                    MsgBox("Date Range Between (" & Date_Formate1 & " TO " & Date_Formate2 & ")", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    TxtBox.SelectionStart = 0
                    TxtBox.SelectionLength = TxtBox.TextLength
                End If
            End If

            If Ed_Date <> "" Then
                If DateDiff(DateInterval.Day, CDate(Ed_Date), CDate(Final_Date)) > 0 Then
                    Valid_Date = False
                    MsgBox("Date Range Between (" & Date_Formate1 & " TO " & Date_Formate2 & ")", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    TxtBox.SelectionStart = 0
                    TxtBox.SelectionLength = TxtBox.TextLength
                End If
            End If
        End If
        Return Valid_Date
    End Function
    Public Function Generate_Book_Vno(ByVal Entry_No As String, ByVal Book_Trtype As String)
        _ComapnyYearCode = COMPANY_TBL.Rows(0).Item("Comp_Year_Code").ToString.Trim.PadLeft(4, "0")
        Dim Book_Vno As String = Trim(Book_Trtype) & "*" & "00000" & "*" & _ComapnyYearCode.ToString.Trim.PadLeft(4, "0") & "*" & Entry_No.ToString.Trim.PadLeft(8, "0")
        Return Book_Vno
    End Function
    Public Function GetSql_Date_Formate_set(ByVal _GetDate As String)
        Dim _SQlDateForm As String = ""
        If _GetDate <> "" Then
            Dim dateTime1 As String = _GetDate
            Dim dt1 As DateTime = Convert.ToDateTime(dateTime1)
            Dim format1 As String = "yyyy-MM-dd"
            _SQlDateForm = dt1.ToString(format1)
        End If
        Return _SQlDateForm
    End Function
    Public Sub Date_Formate_set()
        Try
            If Date_Formate1 <> "" Then
                Dim dateTime1 As String = Date_Formate1
                Dim dt1 As DateTime = Convert.ToDateTime(dateTime1)
                Dim format1 As String = "yyyy-MM-dd"
                Date_1 = dt1.ToString(format1)
            End If

            If Date_Formate2 <> "" Then
                Dim dateTime2 As String = Date_Formate2
                Dim dt2 As DateTime = Convert.ToDateTime(dateTime2)
                Dim format2 As String = "yyyy-MM-dd"
                Date_2 = dt2.ToString(format2)
            End If

            If Date_Formate3 <> "" Then
                Dim dateTime3 As String = Date_Formate3
                Dim dt3 As DateTime = Convert.ToDateTime(dateTime3)
                Dim format3 As String = "yyyy-MM-dd"
                Date_3 = dt3.ToString(format3)
            End If
            If Date_Formate4 <> "" Then
                Dim dateTime4 As String = Date_Formate4
                Dim dt4 As DateTime = Convert.ToDateTime(dateTime4)
                Dim format4 As String = "yyyy-MM-dd"
                Date_4 = dt4.ToString(format4)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

    End Sub
    Public Sub Show_Help_Selection_list(ByVal Qry_For_Grid As String, ByRef ownerfrm As Form, ByRef ReturnText As Control, ByVal ReturnCode As TextBox, ByVal Frm_Title As String, ByVal List_For As String)
        Dim f1 As FrmEditSelectionList
        f1 = New FrmEditSelectionList(ownerfrm, Qry_For_Grid, ReturnCode, ReturnText, Frm_Title, List_For)
        f1.ShowDialog()
    End Sub
    Public Sub FillGrid(ByRef grd As FlexCell.Grid, ByVal datasource As String, Optional ByVal Fld_Name_Proper As Boolean = False)
        Dim i, j As Integer
        Dim tempDT As New DataTable

        sqL = datasource
        sql_connect_slect()
        tempDT = DefaltSoftTable.Copy


        'ConnDB()
        'cmd = New SqlClient.SqlCommand(datasource, conn)
        'cmd.CommandType = CommandType.Text
        'Dim ADP2 As New SqlDataAdapter(cmd)
        'ADP2.Fill(tempDT)
        'cmd.Dispose()
        'conn.Close()


        grd.Rows = tempDT.Rows.Count + 1
        grd.Cols = tempDT.Columns.Count + 1
        grd.Column(0).Visible = False
        grd.AutoRedraw = False
        For j = 1 To tempDT.Columns.Count
            If Fld_Name_Proper = True Then
                grd.Cell(0, j).Text = String_To_Proper(tempDT.Columns(j - 1).ColumnName.ToString)
            Else
                grd.Cell(0, j).Text = tempDT.Columns(j - 1).ColumnName
            End If

        Next

        For i = 1 To tempDT.Rows.Count
            For j = 1 To tempDT.Columns.Count
                If tempDT.Rows(i - 1).Item(j - 1).ToString <> "" Then
                    grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                End If
            Next
        Next

        grd.SelectionMode = FlexCell.SelectionModeEnum.ByRow
        grd.ExtendLastCol = True
        grd.Focus()
        grd.AutoRedraw = True
        grd.Refresh()
        tempDT = Nothing
    End Sub
    Public Sub Yes_No_Check(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal TxtBox As TextBox)
        Dim TypeChar As String = e.KeyChar.ToString.ToUpper

        If Asc(TypeChar) = 32 Then
            e.KeyChar = ""
            If Trim(TxtBox.Text) = "" Then
                TxtBox.Text = "YES"
            ElseIf Trim(TxtBox.Text) = "YES" Then

                TxtBox.Text = "NO"
            ElseIf Trim(TxtBox.Text) = "NO" Then
                TxtBox.Text = "YES"
            End If
        Else
            If TypeChar = "Y" Then
                TxtBox.Text = "YES"
                e.KeyChar = ""
            ElseIf TypeChar = "N" Then
                TxtBox.Text = "NO"
                e.KeyChar = ""
            End If
        End If
    End Sub
    Public Sub Y_N_Check(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal TxtBox As TextBox)
        Dim TypeChar As String = e.KeyChar.ToString.ToUpper

        If Asc(TypeChar) = 32 Then
            e.KeyChar = ""
            If Trim(TxtBox.Text) = "" Then
                TxtBox.Text = "Y"
            ElseIf Trim(TxtBox.Text) = "Y" Then

                TxtBox.Text = "N"
            ElseIf Trim(TxtBox.Text) = "N" Then
                TxtBox.Text = "Y"
            End If
        Else
            If TypeChar = "Y" Then
                TxtBox.Text = "Y"
                e.KeyChar = ""
            ElseIf TypeChar = "N" Then
                TxtBox.Text = "N"
                e.KeyChar = ""
            End If
        End If
    End Sub
    Public Function String_To_Proper(ByVal Str As String) As String
        Dim builder As StringBuilder = New StringBuilder
        Dim a As Int16
        Dim b As Int16

        ' Used For Holding Each Word Separated By A Space
        Dim Words() As String = Split(Str, " ")

        ' Loop Through All The Words In The String
        For a = 0 To Words.GetUpperBound(0)

            ' Loop Through All The Characters In The String
            For b = 0 To Words(a).Length - 1

                If b = 0 AndAlso Words(a)(b) <> " " Then
                    ' Make The First Character Uppercase
                    builder.Append(Char.ToUpper(Words(a)(b)))
                Else
                    ' Make The Other Characters Lowercase
                    builder.Append(Char.ToLower(Words(a)(b)))
                End If

                ' Add Spaces If Any Are Necessary
                If a <> Words.GetUpperBound(0) And b = Words(a).Length - 1 Then
                    builder.Append(" ")
                End If
            Next
        Next
        Return builder.ToString
    End Function
    Public Function CreateGUID()
        Dim tmpTemp As String = ""
        'tmpTemp = Application.StartupPath & "\" & Guid.NewGuid().ToString() & ".pdf"
        'tmpTemp = Now.Day.ToString & "-" & Month(Now()).ToString & "-" & Year(Now()).ToString & "-" & Hour(Now()).ToString & "-" & Minute(Now()) & "-" & Second(Now())
        tmpTemp = Now.Day.ToString & Month(Now()).ToString & Year(Now()).ToString & Hour(Now()).ToString & Minute(Now()) & Second(Now())
        CreateGUID = tmpTemp
    End Function

    Public Sub Clear_Grid(ByRef GrdObj As FlexCell.Grid, ByVal MaxRow As Integer)
        GrdObj.AutoRedraw = False
        Try

            If GrdObj.Rows > 1 Then ' More than just header
                With GrdObj
                    .Locked = False
                    .AutoRedraw = False
                    .Range(1, 1, .Rows - 1, .Cols - 1).DeleteByRow()
                    .AutoRedraw = True
                    .Rows = MaxRow
                    .Refresh()
                End With
            Else
                GrdObj.Rows = MaxRow ' Just adjust rows if needed
            End If



        Catch ex As Exception
            MsgBox(ex.Message & "===" & GrdObj.Rows & "==" & MaxRow)
        End Try
        GrdObj.AutoRedraw = True
        GrdObj.Refresh()
    End Sub
    Public Sub Fill_Grid_With_DataTable_In_Ledger(ByRef grd As FlexCell.Grid, ByRef tempDT As DataTable, Optional ByVal Fld_Name_Proper As Boolean = False)
        Dim i, j As Integer

        grd.AutoRedraw = False

        If grd.Rows > 1 Then Clear_Grid(grd, 2)

        grd.Rows = tempDT.Rows.Count + 1
        grd.Cols = tempDT.Columns.Count + 1
        grd.Column(0).Visible = False

        For j = 1 To tempDT.Columns.Count
            If Fld_Name_Proper = True Then
                grd.Cell(0, j).Text = String_To_Proper(tempDT.Columns(j - 1).ColumnName.ToString)
            Else
                grd.Cell(0, j).Text = tempDT.Columns(j - 1).ColumnName
            End If
        Next

        For i = 1 To tempDT.Rows.Count
            For j = 1 To tempDT.Columns.Count
                If tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.DOUBLE" Or tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.INT32" Then
                    If Val(tempDT.Rows(i - 1).Item(j - 1).ToString) <> 0 Then
                        grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                    End If
                ElseIf tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.BYTE[]" Then

                Else
                    If tempDT.Rows(i - 1).Item(j - 1).ToString <> "" Then
                        grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                    End If
                End If
            Next
        Next

        grd.AutoRedraw = True
        'grd.Focus()
        grd.Refresh()
    End Sub
    Public Sub Fill_Grid_With_DataTable_ledger(ByRef grd As FlexCell.Grid, ByRef tempDT As DataTable, Optional ByVal Fld_Name_Proper As Boolean = False)
        Dim i, j As Integer

        grd.AutoRedraw = False

        If grd.Rows > 1 Then Clear_Grid(grd, 2)

        grd.Rows = tempDT.Rows.Count + 1
        grd.Cols = tempDT.Columns.Count + 1
        grd.Column(0).Visible = False

        For j = 1 To tempDT.Columns.Count
            If Fld_Name_Proper = True Then
                grd.Cell(0, j).Text = String_To_Proper(tempDT.Columns(j - 1).ColumnName.ToString)
            Else
                grd.Cell(0, j).Text = tempDT.Columns(j - 1).ColumnName
            End If
        Next

        For i = 1 To tempDT.Rows.Count
            For j = 1 To tempDT.Columns.Count
                If tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.DOUBLE" Or tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.INT32" Then
                    If Val(tempDT.Rows(i - 1).Item(j - 1).ToString) <> 0 Then
                        grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                    End If
                ElseIf tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.BYTE[]" Then

                Else
                    If tempDT.Rows(i - 1).Item(j - 1).ToString <> "" Then
                        grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                    End If
                End If
            Next
        Next

        grd.AutoRedraw = True
        'grd.Focus()
        'grd.Refresh()
    End Sub
    Public Sub Fill_Grid_With_DataTable(ByRef grd As FlexCell.Grid, ByRef tempDT As DataTable, Optional ByVal Fld_Name_Proper As Boolean = False)
        Dim i, j As Integer

        grd.AutoRedraw = False

        If grd.Rows > 1 Then Clear_Grid(grd, 2)

        grd.Rows = tempDT.Rows.Count + 1
        grd.Cols = tempDT.Columns.Count + 1
        grd.Column(0).Visible = False

        For j = 1 To tempDT.Columns.Count
            If Fld_Name_Proper = True Then
                grd.Cell(0, j).Text = String_To_Proper(tempDT.Columns(j - 1).ColumnName.ToString)
            Else
                grd.Cell(0, j).Text = tempDT.Columns(j - 1).ColumnName
            End If
        Next

        For i = 1 To tempDT.Rows.Count
            For j = 1 To tempDT.Columns.Count
                If tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.DOUBLE" Or tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.INT32" Then
                    If Val(tempDT.Rows(i - 1).Item(j - 1).ToString) <> 0 Then
                        grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                    End If
                ElseIf tempDT.Columns(j - 1).DataType.ToString.ToUpper = "SYSTEM.BYTE[]" Then

                Else
                    If tempDT.Rows(i - 1).Item(j - 1).ToString <> "" Then
                        grd.Cell(i, j).Text = (tempDT.Rows(i - 1).Item(j - 1))
                    End If
                End If
            Next
        Next

        grd.AutoRedraw = True
        grd.Focus()
        grd.Refresh()
    End Sub
    Public Sub Fill_Records(ByVal TblName_Source As DataTable, ByVal _FieldName() As String, ByRef GrdObj As FlexCell.Grid, ByRef _rowNo As Integer, Optional ByVal _RowIncrement As Boolean = True, Optional ByVal strFieldBracket As String = "", Optional ByVal strLocked As Boolean = True, Optional ByVal strReplaceFields As String = ",")
        Dim _FindColIndex As Integer = 0
        Dim _Column_Type As String = ""
        Dim _RepalceFieldsString() As String
        Dim _ReplceFields_source(0) As String
        Dim _ReplceFields_Target(0) As String
        Dim _ReplaceIndex As Integer = 0

        GrdObj.AutoRedraw = False

        _RepalceFieldsString = strReplaceFields.ToString.ToUpper.Split("/")
        If UBound(_RepalceFieldsString) >= 1 Then
            _ReplceFields_source = _RepalceFieldsString(0).Split(":")
            _ReplceFields_Target = _RepalceFieldsString(1).Split(":")
        End If




        If _RowIncrement = True And TblName_Source.Rows.Count > 0 Then
            _rowNo = _rowNo + 1
        End If


        Dim _Table_FieldName As String = ""

        For Each dr As DataRow In TblName_Source.Rows

            If _RowIncrement = True Then
                GrdObj.Rows = _rowNo + 1
            End If


            For Each dc As DataColumn In dr.Table.Columns

                If strFieldBracket = "YES" Then
                    _Table_FieldName = "[" & dc.ColumnName.ToUpper & "]"
                    _FindColIndex = Array.IndexOf(_FieldName, _Table_FieldName)
                Else
                    _Table_FieldName = dc.ColumnName.ToUpper
                    _FindColIndex = Array.IndexOf(_FieldName, _Table_FieldName)
                End If

                If _FindColIndex >= 0 Then

                    _ReplaceIndex = -1


                    If Not _ReplceFields_source Is Nothing Then
                        _ReplaceIndex = Array.IndexOf(_ReplceFields_source, _Table_FieldName, 0)
                    End If

                    If _ReplaceIndex >= 0 Then
                        '_Column_Type = TblName_Source.Columns(_FindColIndex).DataType.ToString
                        ' --- repalce with user define other fields
                        GrdObj.Cell(_rowNo, _FindColIndex + 1).Text = dr(_ReplceFields_Target(_ReplaceIndex)).ToString
                        'If _Column_Type = "System.Int32" Or _Column_Type = "System.Decimal" Or _Column_Type = "System.Double" Then
                        '    If Val(GrdObj.Cell(_rowNo, _FindColIndex + 1).Text) = 0 Then
                        '        GrdObj.Cell(_rowNo, _FindColIndex + 1).Text = ""
                        '    End If
                        'End If
                        ' ---
                    Else
                        GrdObj.Cell(_rowNo, _FindColIndex + 1).Text = dr(dc.ColumnName).ToString
                        '_Column_Type = TblName_Source.Columns(_FindColIndex).DataType.ToString
                        'If _Table_FieldName = "CALCRATE" Or _Table_FieldName = "CALCAMOUNT" Then
                        'MsgBox(_Table_FieldName)
                        'MsgBox(_Column_Type)
                        'End If
                        'If _Column_Type = "System.Int32" Or _Column_Type = "System.Decimal" Or _Column_Type = "System.Double" Then
                        'If Val(GrdObj.Cell(_rowNo, _FindColIndex + 1).Text) = 0 Then
                        '    GrdObj.Cell(_rowNo, _FindColIndex + 1).Text = ""
                        'End If
                        'End If
                    End If

                End If

                If strLocked = True Then
                    GrdObj.Cell(_rowNo, _FindColIndex + 1).Locked = True
                End If
            Next

            If _RowIncrement = True Then
                _rowNo = _rowNo + 1
            End If
        Next

        GrdObj.AutoRedraw = True
        GrdObj.Refresh()


    End Sub
    Public Function GetLastDateOfMonth(ByVal intMonth As Integer, ByVal intYear As Integer) As Date
        GetLastDateOfMonth = DateSerial(intYear, intMonth + 1, 0)
    End Function

    Public Sub Generate_Date_For_DataBase(ByVal TxtBox As ctl_TextBox.ctl_TextBox)
        Dim d, m, y, DT As String
        DT = TxtBox.Text
        d = Mid(DT, 1, 2)
        m = Mid(DT, 4, 2)
        y = Mid(DT, 7)
        If Val(d) > 0 And Val(m) > 0 And Val(y) > 0 Then
            If Len(Trim(y)) = 0 Then y = Format(Now(), "yyyy")
            If Len(Trim(m)) = 0 Then m = Format(Now(), "MM")
            DT = d & "/" & m & "/" & y
            Dim FinalDate As String = ""
            FinalDate = Val(d) & "-" & Strings.Mid(MonthName(Val(m)), 1, 3) & "-" & Val(y)
            TxtBox.Date_for_Database = FinalDate
        End If
    End Sub
    Public Sub setDatesForReports(ByRef txtStartDtObject As ctl_TextBox.ctl_TextBox, ByRef txtEndDtObject As ctl_TextBox.ctl_TextBox)
        Try

            txtStartDtObject.Text = Main_MDI_Frm.FINE_YEAR_START.Text
            txtStartDtObject.Date_for_Database = Main_MDI_Frm.FINE_YEAR_START.Text

            txtEndDtObject.Text = IIf(CDate(ObjCls_General.GetTodayDate_SqlFormat) < CDate(Main_MDI_Frm.FINE_YEAR_END.Text), USERDATE_TodayDate, Main_MDI_Frm.FINE_YEAR_END.Text)
            txtEndDtObject.Date_for_Database = IIf(CDate(ObjCls_General.GetTodayDate_SqlFormat) < CDate(Main_MDI_Frm.FINE_YEAR_END.Text), ObjCls_General.GetTodayDate_SqlFormat, Main_MDI_Frm.FINE_YEAR_END.Text)

            txtStartDtObject.MinDate = Main_MDI_Frm.FINE_YEAR_START.Text
            txtStartDtObject.MaxDate = Main_MDI_Frm.FINE_YEAR_END.Text

            txtEndDtObject.MinDate = Main_MDI_Frm.FINE_YEAR_START.Text
            txtEndDtObject.MaxDate = Main_MDI_Frm.FINE_YEAR_END.Text

            Generate_Date_For_DataBase(txtStartDtObject)
            Generate_Date_For_DataBase(txtEndDtObject)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub
    Public Function Date_Is_Less_Than_Financial_Year_Start_Date(ByVal TxtBox As ctl_TextBox.ctl_TextBox, ByVal Frm_Load As Boolean) As Boolean
        Date_Is_Less_Than_Financial_Year_Start_Date = False
        FinYearStartDate = Main_MDI_Frm.FINE_YEAR_START.Text
        USERDATE_FinYearStartDate = Main_MDI_Frm.FINE_YEAR_START.Text

        Dim St_Date As String = FinYearStartDate
        Dim d As String = Mid(TxtBox.Text, 1, 2)
        Dim m As String = Mid(TxtBox.Text, 4, 2)
        Dim y As String = Mid(TxtBox.Text, 7, 4)

        Dim Final_Date As String = Val(d) & "-" & Strings.Mid(MonthName(Val(m)), 1, 3) & "-" & Val(y)

        If TxtBox.Text <> " " Then
            If St_Date <> "" Then
                If DateDiff(DateInterval.Day, CDate(St_Date), CDate(Final_Date)) < 0 Then
                    Date_Is_Less_Than_Financial_Year_Start_Date = True
                End If
            End If
        End If
        Return Date_Is_Less_Than_Financial_Year_Start_Date
    End Function
    Public Function ActivatedControl(ByVal frmObject As Form) As String

        Dim rtnString As String = ""
        Dim ThisControl As Object
        Dim _TypeOFControl As String = ""
        Dim _Position As Integer
        Dim _CONTROLNAME As String = ""

        ThisControl = frmObject.ActiveControl

        If Not ThisControl Is Nothing Then
            _TypeOFControl = UCase(ThisControl.GetType.ToString)
            _Position = _TypeOFControl.LastIndexOf(".")

            If _Position > 0 Then
                _TypeOFControl = Mid(_TypeOFControl, _Position + 2, _TypeOFControl.Length)
            End If
            _CONTROLNAME = UCase(ThisControl.NAME)
        End If

        Return _CONTROLNAME
    End Function
    Public Function Seek_In_Grid(ByVal GrdObj As FlexCell.Grid, ByVal seekvalue As String, ByVal Seek_ColNo As Integer)
        GrdObj.AutoRedraw = False

        Dim Found As Boolean = False
        Dim pname As String, ln As Integer, rws As Integer, cnt As Integer
        pname = Trim(seekvalue)
        ln = Len(pname)
        rws = GrdObj.Rows
        Try
            For cnt = 1 To rws - 1

                If GrdObj.Row(cnt).Visible = True Then
                    If Mid(GrdObj.Cell(cnt, Seek_ColNo).Text, 1, ln) = pname Then
                        GrdObj.Range(cnt, 0, cnt, GrdObj.Cols - 1).SelectCells()
                        Found = True
                        Exit For
                    End If
                End If
            Next
            If Found = False Then
                Beep()
                seekvalue = Mid(pname, 1, ln - 1)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        If Found = True Then
            GrdObj.TopRow = GrdObj.ActiveCell.Row
        End If

        GrdObj.AutoRedraw = True
        GrdObj.Refresh()

        Return Found
    End Function

    Public Function Send_Mail(ByVal smtp_server_name As String, ByVal from_Address As String, ByVal From_Password As String, ByVal File_Name_With_Path As String, ByVal To_Address As String, ByVal str_Subject As String, ByVal Message_Str As String, ByVal LstBox As ListBox) As Boolean
        Dim em As New Email.Email(smtp_server_name, from_Address, From_Password)
        Dim res As Email.Email.sendEmailResult

        em.SMTPPort = 587
        em.UseEncryption = True
        em.Tos.Add(To_Address)
        em.subject = str_Subject
        em.message = Message_Str


        If LstBox.Items.Count <> 0 Then
            For i As Int16 = 0 To LstBox.Items.Count - 1
                em.addAttachment(LstBox.Items.Item(i))
            Next
        End If


        res = em.sendEmail()
        Select Case res
            Case Email.Email.sendEmailResult.attachmentNotAvailable
                MsgBox("The attachment can't be found")
            Case Email.Email.sendEmailResult.noMessage
                MsgBox("Whats the point of sending an email with no message?")
            Case Email.Email.sendEmailResult.noSMTPDetails
                MsgBox("You need to supply the details for your SMTP server")
            Case Email.Email.sendEmailResult.noSubject
                MsgBox("You need to specify a subject")
            Case Email.Email.sendEmailResult.noToEmails
                MsgBox("You have to specify someone to send to")
            Case Email.Email.sendEmailResult.successful
                'MsgBox("You've got spam")
            Case Email.Email.sendEmailResult.unableToConnect
                MsgBox("Unable to connect to SMTP server")
            Case Email.Email.sendEmailResult.unknownError
                MsgBox("Ow no, what went wrong?")
        End Select

        If res.ToString.ToUpper = "SUCCESSFUL" Then
            Send_Mail = True
        Else
            Send_Mail = False
        End If

        If res.ToString.ToUpper = "SUCCESSFUL" Then
            Send_Mail = True
        Else
            Send_Mail = False
        End If
        Return Send_Mail
    End Function

    Public Function LINQToDataTable(Of T)(ByVal iEnumerableList As IEnumerable(Of T)) As DataTable
        Dim newDataTable As New DataTable()
        Dim thePropertyInfo As PropertyInfo() = Nothing

        If iEnumerableList Is Nothing Then
            Return newDataTable
        End If

        For Each item As T In iEnumerableList
            If thePropertyInfo Is Nothing Then

                thePropertyInfo = (DirectCast(item.[GetType](), Type)).GetProperties()

                For Each propInfo As PropertyInfo In thePropertyInfo

                    Dim columnDataType As Type = propInfo.PropertyType

                    If (columnDataType.IsGenericType) AndAlso (columnDataType.GetGenericTypeDefinition() Is GetType(Nullable(Of ))) Then

                        columnDataType = columnDataType.GetGenericArguments()(0)

                    End If

                    newDataTable.Columns.Add(New DataColumn(propInfo.Name, columnDataType))

                Next

            End If

            Dim dr As DataRow = newDataTable.NewRow()

            For Each pi As PropertyInfo In thePropertyInfo
                dr(pi.Name) = If(pi.GetValue(item, Nothing) Is Nothing, DBNull.Value, pi.GetValue(item, Nothing))
            Next

            newDataTable.Rows.Add(dr)
        Next
        Return newDataTable
    End Function

    Public Function DoesFieldExist(ByVal tblName As String, ByVal fldName As String) As Boolean
        sqL = "SELECT TOP 1 * FROM " & tblName & ""
        Dim dbTbl As New DataTable
        sql_connect_slect()
        dbTbl = DefaltSoftTable.Copy

        Dim i As Integer = dbTbl.Columns.IndexOf(fldName)
        If i = -1 Then
            'Field is missing
            DoesFieldExist = False

        Else
            'Field is there
            DoesFieldExist = True
        End If

        Return DoesFieldExist
    End Function

    Public Sub SetTotalObjectPosition_TextBox(ByVal strColName As String, ByVal _dataTableName As DataTable, ByVal Grd As FlexCell.Grid, ByVal lblTotalFieldObject As ctl_TextBox.ctl_TextBox, ByVal TotRemObject As Label, ByVal Formname As Form)

        Dim _FindColIndex As Integer = _dataTableName.Columns.IndexOf(strColName) + 1
        Dim _DecimalPlaces As Integer = Grd.Column(_FindColIndex).DecimalLength
        Dim _Alignment As String = Grd.Column(_FindColIndex).Alignment.ToString
        Dim _AlignEnum As Integer = 1

        If _Alignment.StartsWith("C") Then _AlignEnum = 2

        Dim cellRect As Rectangle = Grd.Cell(1, _FindColIndex).Bounds

        lblTotalFieldObject.AutoSize = False
        lblTotalFieldObject.TextAlign = _AlignEnum
        lblTotalFieldObject.Text = FormatNumber(0, _DecimalPlaces)

        ' Positioning relative to form
        Dim absLeft As Integer = Grd.Left + cellRect.Left
        Dim absTop As Integer = Grd.Top + cellRect.Top

        ' Add Parent container adjustment if needed
        If Not TypeOf Grd.Parent Is Form Then
            absLeft += Grd.Parent.Left
            absTop += Grd.Parent.Top
        End If

        lblTotalFieldObject.Left = absLeft
        lblTotalFieldObject.Top = TotRemObject.Top
        lblTotalFieldObject.Width = cellRect.Width
        lblTotalFieldObject.Height = TotRemObject.Height

        lblTotalFieldObject.Visible = True
        lblTotalFieldObject.BringToFront()

        ' Ensure added to Controls if not already
        If Not Formname.Controls.Contains(lblTotalFieldObject) Then
            Formname.Controls.Add(lblTotalFieldObject)
        End If
    End Sub

    Public Sub SetTotalObjectPosition(ByVal strColName As String, ByVal _dataTableName As DataTable, ByVal Grd As FlexCell.Grid, ByVal lblTotalFieldObject As Label, ByVal TotRemObject As Label)
        Dim _DecimalPlaces As Integer = 0
        Dim _fldAlignment As String = ""
        Dim _FieldAlignMentEnumValue As Integer = 0
        Dim _FindColIndex As Integer = 0

        '---- Field -1 
        _FindColIndex = _dataTableName.Columns.IndexOf(strColName) + 1
        _DecimalPlaces = Grd.Column(_FindColIndex).DecimalLength
        _fldAlignment = Grd.Column(_FindColIndex).Alignment.ToString

        If Strings.Left(_fldAlignment, 1) = "L" Then
            _FieldAlignMentEnumValue = 1

        ElseIf Strings.Left(_fldAlignment, 1) = "R" Then
            _FieldAlignMentEnumValue = 4
        ElseIf Strings.Left(_fldAlignment, 1) = "C" Then
            _FieldAlignMentEnumValue = 2
        Else
            _FieldAlignMentEnumValue = 256
        End If

        lblTotalFieldObject.AutoSize = False
        lblTotalFieldObject.Bounds = Grd.Cell(1, _FindColIndex).Bounds
        lblTotalFieldObject.Left = lblTotalFieldObject.Left + Grd.Left
        lblTotalFieldObject.Text = Strings.FormatNumber(0, 2)
        lblTotalFieldObject.Top = TotRemObject.Bounds.Top
        lblTotalFieldObject.Height = TotRemObject.Height
        lblTotalFieldObject.BackColor = TotRemObject.BackColor
        lblTotalFieldObject.TextAlign = _FieldAlignMentEnumValue  ' ContentAlignment.TopRight
        lblTotalFieldObject.BringToFront()
    End Sub
    Public Sub SetTotalObjectPosition_textBox(ByVal strColName As String, ByVal _dataTableName As DataTable, ByVal Grd As FlexCell.Grid, ByVal lblTotalFieldObject As TextBox, ByVal TotRemObject As Label)
        Dim _DecimalPlaces As Integer = 0
        Dim _fldAlignment As String = ""
        Dim _FieldAlignMentEnumValue As Integer = 0
        Dim _FindColIndex As Integer = 0

        '---- Field -1 
        _FindColIndex = _dataTableName.Columns.IndexOf(strColName) + 1
        _DecimalPlaces = Grd.Column(_FindColIndex).DecimalLength
        _fldAlignment = Grd.Column(_FindColIndex).Alignment.ToString

        If Strings.Left(_fldAlignment, 1) = "L" Then
            _FieldAlignMentEnumValue = 1

        ElseIf Strings.Left(_fldAlignment, 1) = "R" Then
            _FieldAlignMentEnumValue = 4
        ElseIf Strings.Left(_fldAlignment, 1) = "C" Then
            _FieldAlignMentEnumValue = 2
        Else
            _FieldAlignMentEnumValue = 256
        End If

        lblTotalFieldObject.AutoSize = False
        lblTotalFieldObject.Bounds = Grd.Cell(1, _FindColIndex).Bounds
        lblTotalFieldObject.Left = lblTotalFieldObject.Left + Grd.Left
        'lblTotalFieldObject.Text = Strings.FormatNumber(0, 2)
        lblTotalFieldObject.Top = TotRemObject.Bounds.Top
        lblTotalFieldObject.Height = TotRemObject.Height
        'lblTotalFieldObject.BackColor = TotRemObject.BackColor
        'lblTotalFieldObject.TextAlign = _FieldAlignMentEnumValue  ' ContentAlignment.TopRight
        lblTotalFieldObject.BringToFront()
    End Sub

    Public Sub Datatable_To_Excel(ByVal dtTemp As DataTable, ByRef xlsFileName As String)
        Dim current As DataColumn
        Dim enumerator As IEnumerator
        Dim enumerator2 As IEnumerator

        Dim Application As New Excel.Application
        Dim workbook As Excel.Workbook = Application.Workbooks.Add(Missing.Value)
        Dim activeSheet As Excel.Worksheet = DirectCast(workbook.ActiveSheet, Excel.Worksheet)
        Dim table As DataTable = dtTemp
        Dim num As Integer = 0
        Dim num2 As Integer = 0
        Try
            enumerator = table.Columns.GetEnumerator
            Do While enumerator.MoveNext
                current = DirectCast(enumerator.Current, DataColumn)
                num += 1
                Application.Cells._Default(1, num) = current.ColumnName
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Try
            enumerator2 = table.Rows.GetEnumerator
            Do While enumerator2.MoveNext
                Dim enumerator3 As IEnumerator
                Dim row As DataRow = DirectCast(enumerator2.Current, DataRow)
                num2 += 1
                num = 0
                Try
                    enumerator3 = table.Columns.GetEnumerator
                    Do While enumerator3.MoveNext
                        current = DirectCast(enumerator3.Current, DataColumn)
                        num += 1
                        Application.Cells._Default((num2 + 1), num) = RuntimeHelpers.GetObjectValue(row.Item(current.ColumnName))
                    Loop
                Finally
                    If TypeOf enumerator3 Is IDisposable Then
                        TryCast(enumerator3, IDisposable).Dispose()
                    End If
                End Try
            Loop
        Finally
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        activeSheet.Columns.AutoFit()


        Dim path As String = (System.Windows.Forms.Application.StartupPath & "\" & xlsFileName & ".xls")
        If File.Exists(path) Then
            File.Delete(path)
        End If
        workbook.SaveAs(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value)
        workbook.Close(Missing.Value, Missing.Value, Missing.Value)
        Application.Quit()

        Dim PATH1 = My.Computer.FileSystem.SpecialDirectories.Desktop
        Dim D_path1 As String = PATH1 + "\Soft Tex Reports"
        If Not Directory.Exists(D_path1) Then
            Directory.CreateDirectory(D_path1)
        End If

        Dim str2 As String = D_path1 & "\" & xlsFileName & ".xls"
        If File.Exists(str2) Then
            File.Delete(str2)
        End If
        My.Computer.FileSystem.CopyFile(path, str2, True)
    End Sub
    Public Sub Key_Press_Event_For_Grid_To_Check_Date(ByVal GrdObj As FlexCell.Grid, ByVal Data_Table As DataTable, ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Date_Field_Name As String)

        Dim KeyTypes As String = e.KeyChar.ToString.ToUpper
        Dim DateLen As Integer = Len(Trim(GrdObj.Cell(GrdObj.ActiveCell.Row, Data_Table.Columns.IndexOf(Date_Field_Name) + 1).Text))
        Dim DateLenNew As Integer = Len(Trim(GrdObj.Cell(GrdObj.ActiveCell.Row, Data_Table.Columns.IndexOf(Date_Field_Name) + 1).Text & e.KeyChar.ToString.ToUpper))
        Dim KeyAscValue As Integer = (Asc(e.KeyChar))
        Dim DateText As String = Trim(GrdObj.ActiveCell.Text)

        '********** BACK SPACE CODE START
        If KeyAscValue = 8 Then
            If DateLen > 0 Then
                'If DateLen = 3 Or DateLen = 6 Then
                'TxtBox.Text = Mid(DateText, 1, DateLen - 1)
                'Else
                GrdObj.ActiveCell.Text = Mid(DateText, 1, DateLen)
                'End If
                Exit Sub
            End If
        End If
        '********** BACK SPACE CODE FINISH

        If KeyAscValue <> 8 Then
            If KeyTypes <> "0" And KeyTypes <> "1" And KeyTypes <> "2" And KeyTypes <> "3" And KeyTypes <> "4" And KeyTypes <> "5" And KeyTypes <> "6" And KeyTypes <> "7" And KeyTypes <> "8" And KeyTypes <> "9" And KeyTypes <> "." And KeyTypes <> "/" Then
                e.KeyChar = ""
                Exit Sub
            End If
        End If

        If KeyAscValue = 13 Then
            Exit Sub
        End If

        If DateLenNew > 10 And KeyAscValue <> 8 Then
            If DateLen = 10 Then
                'TxtBox.Text = KeyTypes
            Else
                e.KeyChar = ""
                Exit Sub
            End If
        End If

        '********************************** DATE COMPLETE CHECK SYSTEM
        '********** DAYS VALUE CHECK SYSTEM START
        If DateLenNew = 1 Then
            If Val(KeyTypes) > 3 Then
                MsgBox("Invalid Day Of Date", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                e.KeyChar = ""
                Exit Sub
            End If
        ElseIf DateLenNew = 2 Then
            Dim NetDayText = GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper
            If NetDayText > 31 Or NetDayText < 0 Then
                MsgBox("Invalid Day Of Date", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                GrdObj.ActiveCell.Text = ""
                e.KeyChar = ""
                Exit Sub
            End If
            '********** DAYS VALUE CHECK SYSTEM FINISH

            '********** MONTH VALUE CHECK SYSTEM START
        ElseIf DateLenNew = 4 Then
            If Val(KeyTypes) > 1 Then
                MsgBox("Invalid Month", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                e.KeyChar = ""
                Exit Sub
            End If
        ElseIf DateLenNew = 5 Then
            Dim NetMonthText = Mid(Trim(GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper), 4, 2)
            If NetMonthText > 12 Or NetMonthText < 0 Then
                MsgBox("Invalid Month", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                GrdObj.ActiveCell.Text = Mid(DateText, 1, DateLen - 1)
                e.KeyChar = ""
                Exit Sub
            End If
            '********** MONTH VALUE CHECK SYSTEM FINISH

            '********** YEAR VALUE CHECK SYSTEM START
        ElseIf DateLenNew = 10 Then
            Dim NetYearText = Mid(Trim(GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper), 7, 4)
            If NetYearText < 0 Then
                MsgBox("Invalid Year", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                Exit Sub
            Else
                'Opeing_Bill_Date.Text = GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper
                'If CDate(Opeing_Bill_Date.Date_for_Database) >= CDate(USERDATE_FinYearStartDate31March) Then
                ' MsgBox("Invalid Date")
                'End If
            End If
        ElseIf DateLenNew > 10 Then
            GrdObj.ActiveCell.Text = Mid(DateText, 1, 10)
            e.KeyChar = ""
        End If
        '********** YEAR VALUE CHECK SYSTEM FINISH
        '********************************** DATE COMPLETE CHECK SYSTEM

        If DateLen = 1 Then
            If Val(GrdObj.ActiveCell.Text = GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper) > 31 Then
                MsgBox("Invalid Day Of Date", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                GrdObj.ActiveCell.Text = Mid(DateText, 1, DateLen - 1)
            ElseIf Val(GrdObj.ActiveCell.Text = GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper) < 0 Then
                MsgBox("Invalid Day Of Date", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                GrdObj.ActiveCell.Text = Mid(DateText, 1, DateLen - 1)
            Else
                GrdObj.ActiveCell.Text = GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper & "/"
                e.KeyChar = ""
            End If
        ElseIf DateLen = 2 Then
            If KeyTypes <> "/" Then
                e.KeyChar = ""
            End If
        ElseIf DateLen = 4 Then
            GrdObj.ActiveCell.Text = GrdObj.ActiveCell.Text & e.KeyChar.ToString.ToUpper & "/"
            e.KeyChar = ""
        ElseIf DateLen = 5 Then
            If KeyTypes <> "/" Then
                e.KeyChar = ""
            End If
        Else
            If KeyTypes <> "0" And KeyTypes <> "1" And KeyTypes <> "2" And KeyTypes <> "3" And KeyTypes <> "4" And KeyTypes <> "5" And KeyTypes <> "6" And KeyTypes <> "7" And KeyTypes <> "8" And KeyTypes <> "9" Then
                e.KeyChar = ""
            End If
        End If
    End Sub


    Public Sub Check_TextBox_Cannnot_Empty(ByVal TxtBox As ctl_TextBox.ctl_TextBox, ByVal FormLoad As Boolean)
        If FormLoad = True Then Exit Sub
        If TxtBox.Text = "" And TxtBox.InputType <> ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric Then
            MsgBox("Empty Not Allowed", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            TxtBox.Focus()
            TxtBox.Select()
        ElseIf Val(TxtBox.Text) = 0 And TxtBox.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DecimalNumeric Then
            MsgBox("Empty Not Allowed", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            TxtBox.Focus()
            TxtBox.Select()
        End If

        If TxtBox.TextAlign = HorizontalAlignment.Left Then
            TxtBox.Text = LTrim(TxtBox.Text)
        ElseIf TxtBox.TextAlign = HorizontalAlignment.Right Then
            TxtBox.Text = RTrim(TxtBox.Text)
        End If

    End Sub
    Public Function Check_Duplicate_Supplier_BillNo(ByVal Bill_No_Value As String, ByVal TblName As String, ByVal Book_Code_For_Check As String, ByVal Current_Book_Vno As String, ByVal Account_Code_For_Check As String) As Boolean
        Check_Duplicate_Supplier_BillNo = True
        Dim _TransctionNo As Integer = 0
        strQuery = "SELECT TOP 1 entryNO FROM " & TblName & " WHERE BILLNO='" & Bill_No_Value & "'  AND BOOKCODE='" & Book_Code_For_Check & "' AND BOOKVNO<>'" & Current_Book_Vno & "'  AND ACCOUNTCODE='" & Account_Code_For_Check & "' ORDER BY ENTRYNO DESC"
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _TransctionNo = (DefaltSoftTable.Rows(0).Item(0))
        End If
        If _TransctionNo > 0 Then
            Check_Duplicate_Supplier_BillNo = False
        End If
        Return Check_Duplicate_Supplier_BillNo
    End Function
    Public Sub Color_Change(ByRef Cmd_Btn As Button, ByVal Focus_Type As String, ByVal Frm_Name As Form, ByVal Got_Focus_Color As Color, ByVal Lost_Focus_Color As Color)
        If Focus_Type = "GOT_FOCUS" Then
            Cmd_Btn.BackColor = Got_Focus_Color
        ElseIf Focus_Type = "LOST_FOCUS" Then
            Cmd_Btn.BackColor = Lost_Focus_Color
        End If
    End Sub
    Public Function CheckDuplicateCaseNo(ByVal CheckValue As String, ByVal TblName As String, ByVal KeyField As String, ByVal LeaveKeyValue As String, Optional ByVal CodeValue As String = "")
        Dim _ReturnValue As String = ""
        Dim Code_String As String = IIf(CodeValue <> "", " AND ACCOUNTCODE='" & CodeValue & "' ", "")
        strQuery = "SELECT TOP  1 entryNO FROM " & TblName & " WHERE CASENO='" & CheckValue & "'  AND BOOKTRTYPE='" & KeyField & "' AND BOOKVNO<>'" & LeaveKeyValue & "' " & Code_String & " "
        sqL = strQuery
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _ReturnValue = (DefaltSoftTable.Rows(0).Item(0))
        End If
        Return _ReturnValue
    End Function
    Public Function GetNumberOfDecimalPlaces(ValueStr As String) As Integer
        Dim text As String = ValueStr.ToString().Trim()
        Dim num As Integer = text.IndexOf(".")
        Dim flag As Boolean = num = -1
        Dim result As Integer
        If flag Then
            result = 0
        Else
            ' The following expression was wrapped in a checked-expression
            result = text.Substring(num + 1).Length
        End If
        Return result
    End Function
    Public Function Get_Fabric_Quality_Mulit_List_Filter_String(ByVal Frm_From_Call As Form, ByVal Alies_Name As String, Optional ByVal Filter_Condition As String = "") As String
        Get_Fabric_Quality_Mulit_List_Filter_String = ""
        obj_Party_Selection.MULTY_ITEM_SELECTION()
        Dim Str_In_Quality As String = MULTY_SELECTION_COLOUM_3_DATA

        ReDim Preserve Selection_Return_Array_Values(0)
        If Str_In_Quality <> "" Then
            Get_Fabric_Quality_Mulit_List_Filter_String = " AND " & Trim(Alies_Name) & ".ID In  " & Str_In_Quality
        Else
            Get_Fabric_Quality_Mulit_List_Filter_String = ""
        End If

        Return Get_Fabric_Quality_Mulit_List_Filter_String
    End Function
    Public Sub _ImageView_Click(ByVal _IamgePath As String)
        Try

            Dim _FolderName As String = "Image"
            Dim strServerName = _FolderFilePath(_FolderName)
            Dim _FilePath As String = strServerName & _IamgePath
            If System.IO.File.Exists(_FilePath) = True Then
                Process.Start(_FilePath)
            Else
                MsgBox("File Does Not Exist")
            End If
            'If _IamgePath > "" Then
            '    Dim _FolderName As String = "Image"
            '    Dim strServerName = _FolderFilePath(_FolderName)
            '    ImageViewePath = strServerName & _IamgePath
            '    ImageViewer.ShowDialog()
            '    ImageViewePath = ""
            'Else
            '    MsgBox("Image Not Found", MsgBoxStyle.Information, "Soft-Tex PRO")
            '    Exit Sub
            'End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Public Sub NewReportPrint(ByVal _Tmptbl As DataTable, ByVal rptTitle As String, ByVal strDateRange As String)
        Try
            _ReportViewerTbl.Clear()
            _ReportViewerTbl = _Tmptbl.Copy

            Report_viewer.Close()
            Report_viewer.Dispose()
            strReportPath = ""
            strReportPath = _reportFileSelection(REPORT_RPT_FILE_NAME)
            If IO.File.Exists(strReportPath) Then
            Else
                MsgBox("File Not Found:" & strReportPath, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                REPORT_RPT_FILE_NAME = ""
                Exit Sub
            End If

            cryRpt = New ReportDocument


            cryRpt.Load(strReportPath)

            ' Set new database path for Access database
            Dim connectionInfo As New CrystalDecisions.Shared.ConnectionInfo()
            connectionInfo.ServerName = System.Windows.Forms.Application.StartupPath + "\Reports\PrintData.dll"
            connectionInfo.DatabaseName = ""
            connectionInfo.UserID = ""
            connectionInfo.Password = ""
            ' Apply new connection settings to all tables
            For Each table As CrystalDecisions.CrystalReports.Engine.Table In cryRpt.Database.Tables
                Dim logOnInfo As CrystalDecisions.Shared.TableLogOnInfo = table.LogOnInfo
                logOnInfo.ConnectionInfo = connectionInfo
                table.ApplyLogOnInfo(logOnInfo)
            Next

            _GeneratePrntTable(_Tmptbl, "PrintDataTable")

            cryRpt.VerifyDatabase()
            cryRpt.Refresh()

            cryRpt.SetDataSource(_Tmptbl)

            cryRpt.SetParameterValue("Comp_name", COMPANY_NAME)
            cryRpt.SetParameterValue("rptTitle", rptTitle)
            cryRpt.SetParameterValue("strDateRange", strDateRange)

            If RUN_TIME_PRINT = "DIRECT_PRINT" Then
                cryRpt.PrintToPrinter(_DirectPrintNoCopy, False, 0, 0)
                RUN_TIME_PRINT = ""
            Else

                'ShowFormMDI_ReportView(New Report_viewer, REPORT_RPT_FILE_NAME, cryRpt)

                Report_viewer.Text = REPORT_RPT_FILE_NAME
                Report_viewer.CrystalReportViewer1.ReportSource = cryRpt
                Report_viewer.CrystalReportViewer1.Zoom(1)
                Report_viewer.ShowDialog()
            End If
            EmailSubject = ""
            Report_viewer.Close()
            Report_viewer.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub NewReportPrint_FourDataTable(ByVal _Tmptbl_1 As DataTable, ByVal _Tmptbl_2 As DataTable, ByVal _Tmptbl_3 As DataTable, ByVal _Tmptbl_4 As DataTable, ByVal rptTitle As String, ByVal strDateRange As String)
        'Try
        _ReportViewerTbl.Clear()
        _ReportViewerTbl = _Tmptbl_1.Copy

        Report_viewer.Close()
        Report_viewer.Dispose()
        strReportPath = ""
        strReportPath = _reportFileSelection(REPORT_RPT_FILE_NAME)
        If IO.File.Exists(strReportPath) Then
        Else
            MsgBox("File Not Found:" & strReportPath, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            REPORT_RPT_FILE_NAME = ""
            Exit Sub
        End If

        cryRpt = New ReportDocument

        Report_viewer.Text = REPORT_RPT_FILE_NAME
        cryRpt.Load(strReportPath)

        ' Set new database path for Access database
        Dim connectionInfo As New CrystalDecisions.Shared.ConnectionInfo()
        connectionInfo.ServerName = System.Windows.Forms.Application.StartupPath + "\Reports\PrintData.dll"
        connectionInfo.DatabaseName = ""
        connectionInfo.UserID = ""
        connectionInfo.Password = ""
        ' Apply new connection settings to all tables
        For Each table As CrystalDecisions.CrystalReports.Engine.Table In cryRpt.Database.Tables
            Dim logOnInfo As CrystalDecisions.Shared.TableLogOnInfo = table.LogOnInfo
            logOnInfo.ConnectionInfo = connectionInfo
            table.ApplyLogOnInfo(logOnInfo)
        Next

        _GeneratePrntTable(_Tmptbl_1, "PrintDataTable")
        _GeneratePrntTable(_Tmptbl_2, "PrintDataTable_2")
        _GeneratePrntTable(_Tmptbl_3, "PrintDataTable_3")
        _GeneratePrntTable(_Tmptbl_4, "PrintDataTable_4")

        Dim MainReportData As New DataSet("MainReportDataSet")

        Dim dt1 = _Tmptbl_1.Copy()
        dt1.TableName = "PrintDataTable"

        Dim dt2 = _Tmptbl_2.Copy()
        dt2.TableName = "PrintDataTable_2"

        Dim dt3 = _Tmptbl_3.Copy()
        dt3.TableName = "PrintDataTable_3"

        Dim dt4 = _Tmptbl_4.Copy()
        dt4.TableName = "PrintDataTable_4"

        MainReportData.Tables.Add(dt1)
        MainReportData.Tables.Add(dt2)
        MainReportData.Tables.Add(dt3)
        MainReportData.Tables.Add(dt4)





        cryRpt.VerifyDatabase()
        cryRpt.Refresh()

        cryRpt.SetDataSource(MainReportData)

        cryRpt.SetParameterValue("Comp_name", COMPANY_NAME)
        cryRpt.SetParameterValue("rptTitle", rptTitle)
        cryRpt.SetParameterValue("strDateRange", strDateRange)

        If RUN_TIME_PRINT = "DIRECT_PRINT" Then
            cryRpt.PrintToPrinter(_DirectPrintNoCopy, False, 0, 0)
            RUN_TIME_PRINT = ""
        Else
            Report_viewer.CrystalReportViewer1.ReportSource = cryRpt
            Report_viewer.CrystalReportViewer1.Zoom(1)
            Report_viewer.ShowDialog()
        End If
        EmailSubject = ""
        Report_viewer.Close()
        Report_viewer.Dispose()

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'Finally
        'End Try
    End Sub

    Private Sub _GeneratePrntTable(ByVal _Tmptbl As DataTable, ByVal tableName As String)
        Try
            Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & System.Windows.Forms.Application.StartupPath + "\Reports\PrintData.dll;"
            Using PrintTblconn As New OleDbConnection(connString)
                PrintTblconn.Open()
                Dim PrintTblcmd As New OleDbCommand()
                PrintTblcmd.Connection = PrintTblconn

                Dim columnList As New List(Of String)()
                'Dim tableName As String = "PrintDataTable"

                For Each col As DataColumn In _Tmptbl.Columns
                    Dim colType As String = "TEXT(255)" ' Default to TEXT

                    If col.DataType Is GetType(Integer) Then
                        colType = "LONG"
                    ElseIf col.DataType Is GetType(Double) OrElse col.DataType Is GetType(Decimal) Then
                        colType = "DOUBLE"
                    ElseIf col.DataType Is GetType(Date) Then
                        colType = "DATETIME"
                    ElseIf col.DataType Is GetType(Boolean) Then
                        colType = "YESNO"
                    ElseIf col.DataType Is GetType(Byte()) Then
                        colType = "OLEOBJECT"
                    End If

                    columnList.Add($"[{col.ColumnName}] {colType}")
                Next



                ' Step 2: Drop Table if Exists
                Try
                    PrintTblcmd.CommandText = "DROP TABLE " & tableName
                    PrintTblcmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' Ignore error if table doesn't exist
                End Try

                Dim createTableSQL As String = "CREATE TABLE " & tableName & " (" & String.Join(",", columnList) & ")"
                PrintTblcmd.CommandText = createTableSQL
                PrintTblcmd.ExecuteNonQuery()
                PrintTblconn.Close()

                ' Now insert data
                'For Each row As DataRow In _Tmptbl.Rows
                '    Dim colNames = String.Join(",", _Tmptbl.Columns.Cast(Of DataColumn)().Select(Function(c) "[" & c.ColumnName & "]"))
                '    Dim paramNames = String.Join(",", _Tmptbl.Columns.Cast(Of DataColumn)().Select(Function(c) "?"))

                '    PrintTblcmd.CommandText = $"INSERT INTO [{tableName}] ({colNames}) VALUES ({paramNames})"
                '    PrintTblcmd.Parameters.Clear()

                '    For Each col As DataColumn In _Tmptbl.Columns
                '        PrintTblcmd.Parameters.AddWithValue("?", row(col.ColumnName))
                '    Next

                '    PrintTblcmd.ExecuteNonQuery()
                'Next


            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
        End Try
    End Sub

    Public Function _GetGradeTextFile()
        Dim filePath As String = System.Windows.Forms.Application.StartupPath & "\Grade.txt"
        Dim GradeList() As String = File.ReadAllLines(filePath)
        For Each line As String In GradeList
            Console.WriteLine(line)
        Next
        Return GradeList
    End Function

    Public Function _GetTextFile(ByVal FileName As String)
        Dim filePath As String = System.Windows.Forms.Application.StartupPath & "\" & FileName
        Dim GradeList() As String = File.ReadAllLines(filePath)
        For Each line As String In GradeList
            Console.WriteLine(line)
        Next
        Return GradeList
    End Function


    Function GetLocalIPAddress() As String
        Dim host As String = Dns.GetHostName()
        Dim ipList As IPAddress() = Dns.GetHostEntry(host).AddressList

        'For Each ip As IPAddress In ipList
        '    If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then

        '        Return ip.ToString() ' Return first IPv4 address

        '    End If
        'Next

        Return host

    End Function
End Module
