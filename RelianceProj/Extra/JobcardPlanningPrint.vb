Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text

Public Class JobcardPlanningPrint
    Private obj_Party_Selection As New Multi_Selection_Master
    Dim _bookcode As String = ""
    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Coral
    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function
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
    Public Sub New()
        InitializeComponent()
        Me.GetAllControls(Me).OfType(Of Button)().ToList() _
          .ForEach(Sub(b)
                       b.Tag = Tuple.Create(b.ForeColor, b.BackColor)
                       AddHandler b.GotFocus, AddressOf b_GotFocus
                       AddHandler b.LostFocus, AddressOf b_LostFocus
                   End Sub)
    End Sub
#Region "VARIABLE DECLARE "
    Private Last_Clicked_Btn As Integer = 0
    Private _FrmLoad As Boolean
    Private DispList As Boolean = False
    Private DispMultiList As Boolean = False
    Private WithEvents txtBook_Code As New TextBox
    Private ReturnArrayValues_BillNo() As String
    Private strIn As String = ""
    Private Btn_No As Integer = 0
    Private RptTitle As String = ""
    Private Date_Range As String = ""
    Private rptFileName As String
    Private _TmpDataRow As DataRow
    Private _TmpDataTable As New DataTable
    Private Return_Array_Values(0) As String
    Private Str_In_Quality As String = ""
    Private Str_In_Design_No As String = ""
    Private Str_In_Shade_No As String = ""
    Private Str_In_Cut As String = ""
    Private WithEvents txt_LR_Date As New ctl_TextBox.ctl_TextBox
    Private Table_Selected_Labels As New DataTable
    Private Return_Multi_Selected_Array_Values() As String
#End Region


    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub StockInOut_GodownTransfer_Printing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmd_No_Wise.Focus()
        cmd_No_Wise.Select()
        Ctrl_Visibility(False)
        AttachButtonFocusEvents(Me)
        '_BookTrType = "JBPLN001"
        _bookcode = "JBPLN001-000000001"

    End Sub

#Region "CMD BTN CLICK EVENT "
    Private Sub button_focus()
        If Last_Clicked_Btn = 1 Then
            cmd_No_Wise.Focus()
        ElseIf Last_Clicked_Btn = 2 Then
            Cmd_JobNoWise.Focus()
        End If
    End Sub
    Private Sub cmd_No_Wise_Click(sender As Object, e As EventArgs) Handles cmd_No_Wise.Click
        Last_Clicked_Btn = 1
        Ask_Detail()
        sqL = "SELECT TOP 1 A.ENTRYNO FROM TrnReadyMadeProducation A WHERE A.BOOKCODE='" & _bookcode & "'  ORDER BY A.ENTRYNO DESC"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            txt_From.Text = DefaltSoftTable.Rows(0).Item(0)
            txt_To.Text = DefaltSoftTable.Rows(0).Item(0)
            txt_From.Focus()
        End If
    End Sub
    Private Sub Cmd_JobNoWise_Click(sender As Object, e As EventArgs) Handles Cmd_JobNoWise.Click
        Last_Clicked_Btn = 2
        Ask_Detail()
    End Sub
#End Region

#Region "Ask Detail "
    Private Sub Ask_Detail()
        Btn_Enabled_Code(False)
        Ctrl_Visibility(True)

        If Last_Clicked_Btn = 1 Or Last_Clicked_Btn = 2 Then
            lbl_Range1.Text = "From"
            lbl_Range2.Text = "To"
            txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
            txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.Normal
            txt_From.Text = 0
            txt_To.Text = 0
        Else
            lbl_Range1.Text = "Date From"
            lbl_Range2.Text = "Date To"
            txt_From.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
            txt_To.InputType = ctl_TextBox.ctl_TextBox.KTB_INPUTTYPES_SETTINGS.DateBox
            txt_From.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
            txt_To.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
        End If
    End Sub
#Region "TEXT BOX VISIBILITY CODE "
    Private Sub Ctrl_Visibility(ByVal Visible_Type As Boolean)
        txt_From.Enabled = Visible_Type
        txt_To.Enabled = Visible_Type
        btnOk.Enabled = Visible_Type
        txt_Stationary_Type.Enabled = Visible_Type
    End Sub
#End Region
#Region "Btn Visibility Code "
    Private Sub Btn_Enabled_Code(ByVal True_False_Type As Boolean)
        cmd_No_Wise.Enabled = True_False_Type
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim Filter_Condition_No As String = ""
        Str_In_Quality = ""

        If Last_Clicked_Btn = 1 Then
            Filter_Condition_No = " AND A.ENTRYNO>= " & Val(txt_From.Text) & " AND A.ENTRYNO<= " & Val(txt_To.Text) & " "
        ElseIf Last_Clicked_Btn = 2 Then
            Filter_Condition_No = " AND A.CHALLAN_NO>= '" & (txt_From.Text) & "' AND A.CHALLAN_NO<= '" & (txt_To.Text) & "' "
        End If

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_name & "'   AS COMP_NAME, ")
            .Append((" '" & Comp_Add1 & "'   AS COMP_ADD1, "))
            .Append((" '" & Comp_Add2 & "'   AS COMP_ADD2, "))
            .Append((" '" & Comp_Add3 & "'   AS COMP_ADD3, "))
            .Append((" '" & Comp_Add4 & "'   AS COMP_ADD4, "))
            .Append((" '" & Comp_Tin & "'   AS COMP_TIN, "))
            .Append((" '" & Comp_Cin & "'   AS COMP_CIN, "))
            .Append((" '" & Comp_Tan & "'   AS COMP_TAN, "))
            .Append((" '" & Comp_Pan & "'   AS COMP_PAN, "))
            .Append((" '" & Comp_Tel_no & "'   AS COMP_TEL_NO, "))
            .Append((" '" & Comp_email & "'   AS COMP_EMAIL, "))
            .Append((" '" & Comp_Subject & "'   AS COMP_SUBJECT, "))
            .Append((" '" & Comp_Bank_Name & "'   AS COMP_BANK_NAME, "))
            .Append((" '" & Comp_Bank_Ac_No & "'   AS COMP_BANK_AC_NO, "))
            .Append((" '" & Comp_Bank_IFSCode & "'   AS COMP_BANK_IFSCODE, "))
            .Append((" 'GSTIN: " & COMP_GSTIN & "'  AS COMP_GSTIN, "))
            .Append((" 'AADHAR NO:" & COMP_AADHARNO & "'  AS COMP_AADHARNO, "))
            .Append((" 'MSME NO: " & Comp_MSME_No & "'  AS COMP_STATECODE, "))
            .Append(" A.*, ")
            .Append(" FORMAT(A.CHALLAN_DATE,'dd/MM/yyyy') AS F_CHALLAN_DATE, ")
            .Append(" B.ACCOUNTNAME,F.ITEMNAME AS HEADERITEMNAME, ")
            .Append(" I.ACCOUNTNAME AS BUYERNAME , ")
            .Append(" N.ACCOUNTNAME AS SUPPLIERNAME , ")
            '.Append(" J.SizeName AS CUTTINGSIZE, ")
            .Append("a.SHADECODE as CUTTINGSIZE, ")
            .Append(" K.ItemName AS PRODITEMNAME , ")
            .Append(" a.LOTNO as JOBSIZE , ")
            .Append(" a.SIZECODE AS SIZE , ")
            .Append(" M.GroupName,  ")
            .Append(" H.AC_NAME, ")
            .Append(" O.subItemName  AS SUBITEMNAME, ")
            '.Append(" P.SizeName  AS JOBSIZE ,")
            .Append(" isnull(a.TOTALMTR,0) as PrintQty, ")
            .Append(" A.OP12 as Gsm,") 'GSM
            .Append(" A.OP13 as Bundle,") 'Bundle
            .Append(" A.OP14 as  NoOfPacket,") 'Pcs Bundle
            .Append(" A.OP15 as Packing,") 'Sheets
            .Append(" A.OP4,") 'Paper Form Code
            .Append(" A.OP5,") 'Paper Code
            .Append(" A.OP7 as Packing,") 'Machine Size
            .Append(" A.OP8 as Packing,") 'Remark
            .Append(" A.HEADERMTR as NoOfSheet,") 'Total
            .Append(" Q.ACCOUNTNAME AS PaperForm, ")
            .Append(" R.ACCOUNTNAME AS Paper ")
            '.Append(" ,CAST(NULL AS VARBINARY(MAX)) AS IMAGEBYTE ")
            .Append(" FROM TrnReadyMadeProducation AS A ")
            .Append(" LEFT JOIN MstMasterAccount AS B ON A.ACCOUNTCODE= B.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstStoreItem F  On  A.ITEMCODE=F.ITEMCODE  ")
            .Append(" LEFT JOIN MstMasterAccount I  On A.DESIGNCODE=I.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstSize j On   A.SHADECODE=J.SizeCode  ")
            .Append(" LEFT JOIN MstStoreItem K  On  A.PRODITEMCODE=K.ItemCode ")
            '.Append(" LEFT JOIN MstSize L On   A.SIZECODE=L.SizeCode ")
            .Append(" LEFT JOIN MstStoreItemGroup M  On A.COLORCODE=M.GroupCode  ")
            .Append(" LEFT JOIN MstStoreSubItem O  On  A.MONOGRAM_TYPE = O.subItemCode ")
            .Append(" LEFT JOIN MstSize P  On  A.LOTNO=P.SizeCode ")
            .Append(" LEFT JOIN Mst_Acof_Supply H  On  A.OP3=H.ID ")
            .Append(" LEFT JOIN MstMasterAccount N  On  A.DELIVERYCODE=N.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstMasterAccount Q  On  A.OP4=Q.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstMasterAccount R  On  A.OP5=R.ACCOUNTCODE ")
            .Append(" WHERE 1=1 ")
            .Append(Filter_Condition_No)
            .Append(" And A.BOOKCODE='" & _bookcode & "'" & " ")
            .Append(" ORDER BY a.entryno,A.SRNO ")

        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim Tmp_Data_Table As New DataTable
        Tmp_Data_Table = DefaltSoftTable.Copy
        If Tmp_Data_Table.Rows.Count > 0 Then

            Tmp_Data_Table.Columns.Add("IMAGEBYTE", GetType(Byte()))


            For Each row As DataRow In Tmp_Data_Table.Rows
                Dim _FolderName As String = "Image"
                Dim strServerName = _FolderFilePath(_FolderName)
                Dim _FilePath As String = strServerName & row("IMAGEPATH")
                Dim imagePath As String = _FilePath

                If File.Exists(imagePath) Then
                    row("IMAGEBYTE") = File.ReadAllBytes(imagePath)

                    Dim bytes As Byte() = row("IMAGEBYTE")

                    Using ms As New MemoryStream(bytes)
                        Dim org As Image = Image.FromStream(ms)

                        ' Always convert to high-quality PNG bitmap
                        Dim bmp As New Bitmap(org.Width, org.Height, PixelFormat.Format32bppArgb)

                        Using g As Graphics = Graphics.FromImage(bmp)
                            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality

                            g.DrawImage(org, 0, 0, org.Width, org.Height)
                        End Using

                        ' Save clean PNG to byte[] for dataset
                        Using ms2 As New MemoryStream()
                            bmp.Save(ms2, Imaging.ImageFormat.Png)
                            row("IMAGEBYTE") = ms2.ToArray()
                        End Using
                    End Using
                End If


            Next


            REPORT_RPT_FILE_NAME = "PackingProdplanJobCard_1"
            Dim RptTitle = "Job Card Planning"
            Dim Date_Range = ""


            Dim _TmpDataRow As DataRow
            Dim dsGroup_BookVno_Total As DataSet, dsHelper As dsHelper.DataSetHelper
            Dim _TmpBookVnRow As DataRow
            Dim RPTOBJ As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Dim Book_Vno As String = ""
            Dim No_Of_Row_For_Detail As Integer = 7

            Dim _NewTmpTbl As DataTable
            _NewTmpTbl = Tmp_Data_Table.Clone

            Dim Dbl_Copy As String = "NO"

            dsGroup_BookVno_Total = New DataSet

            dsHelper = New dsHelper.DataSetHelper(dsGroup_BookVno_Total)
            dsHelper.CreateGroupByTable("GROUP_TABLE", Tmp_Data_Table, "BOOKVNO")
            dsHelper.InsertGroupByInto(dsGroup_BookVno_Total.Tables!GROUP_TABLE, Tmp_Data_Table, "BOOKVNO", "", "BOOKVNO")

            Dim Book_Vno_Rows As Integer = 0
            Dim i As Integer = 0
            Dim Row_Cnt As Integer = 1

            For Each dr As DataRow In dsGroup_BookVno_Total.Tables("GROUP_TABLE").Rows
                If Len(dr("BOOKVNO").ToString) > 0 Then
                    ' First Copy Start
                    Book_Vno = Trim(dr("BOOKVNO").ToString)
                    Book_Vno_Rows = 0
                    For Each BkVno_DR As DataRow In Tmp_Data_Table.Select("BOOKVNO='" & Book_Vno & "' ", "")
                        _NewTmpTbl.ImportRow(BkVno_DR)
                        Book_Vno_Rows = Book_Vno_Rows + 1
                        Row_Cnt = Row_Cnt + 1
                    Next

                    If No_Of_Row_For_Detail > 0 And Book_Vno_Rows < No_Of_Row_For_Detail Then
                        _TmpDataRow = _NewTmpTbl.Rows(_NewTmpTbl.Rows.Count - 1)
                        For i = 1 To No_Of_Row_For_Detail - Book_Vno_Rows
                            _NewTmpTbl.ImportRow(_TmpDataRow)
                            _TmpBookVnRow = _NewTmpTbl.Rows(_NewTmpTbl.Rows.Count - 1)

                            '_TmpBookVnRow("CASENO") = Row_Cnt
                            _TmpBookVnRow("PRODITEMNAME") = ""
                            _TmpBookVnRow("GroupName") = ""
                            _TmpBookVnRow("Gsm") = 0
                            _TmpBookVnRow("NoOfPacket") = 0
                            _TmpBookVnRow("Bundle") = 0
                            _TmpBookVnRow("NoOfSheet") = 0
                            _TmpBookVnRow("Packing") = 0
                            _TmpBookVnRow("Qty") = 0
                            _TmpBookVnRow("SIZE") = ""
                            'Row_Cnt = Row_Cnt + 1
                        Next
                    End If
                    ' First Copy Finish

                    ' Second Copy Start
                    If Dbl_Copy = "YES" Then
                        Row_Cnt = 1
                        Book_Vno = Trim(dr("BOOKVNO").ToString)
                        Book_Vno_Rows = 0

                        For Each BkVno_DR As DataRow In Tmp_Data_Table.Select("BOOKVNO='" & Book_Vno & "' ", "")
                            BkVno_DR("BOOKVNO") = Trim(BkVno_DR("BOOKVNO").ToString) + "A"
                            _NewTmpTbl.ImportRow(BkVno_DR)
                            Book_Vno_Rows = Book_Vno_Rows + 1
                            Row_Cnt = Row_Cnt + 1
                        Next

                        If No_Of_Row_For_Detail > 0 And Book_Vno_Rows < No_Of_Row_For_Detail Then
                            _TmpDataRow = _NewTmpTbl.Rows(_NewTmpTbl.Rows.Count - 1)
                            For i = 1 To No_Of_Row_For_Detail - Book_Vno_Rows
                                _NewTmpTbl.ImportRow(_TmpDataRow)
                                _TmpBookVnRow = _NewTmpTbl.Rows(_NewTmpTbl.Rows.Count - 1)

                                '_TmpBookVnRow("CASENO") = Row_Cnt
                                _TmpBookVnRow("BILLNO") = ""
                                _TmpBookVnRow("F_BILLDATE") = ""
                                _TmpBookVnRow("BILLAMT") = 0
                                _TmpBookVnRow("RD") = 0
                                _TmpBookVnRow("CD") = 0
                                _TmpBookVnRow("GR") = 0
                                _TmpBookVnRow("AGCOMM") = 0
                                _TmpBookVnRow("OTHER") = 0
                                _TmpBookVnRow("INTAMT") = 0
                                _TmpBookVnRow("ALREADYPAID") = 0
                                _TmpBookVnRow("BILLAMT") = 0
                                _TmpBookVnRow("PYMTAMOUNT") = 0
                                _TmpBookVnRow("PCS_BALES") = 0
                                _TmpBookVnRow("BALANCE") = 0

                                _TmpBookVnRow("CUTNAME") = ""
                                _TmpBookVnRow("BOOKVNO") = Trim(Book_Vno) + "A"
                                _TmpBookVnRow("ITEMNAME") = ""
                                _TmpBookVnRow("SUPPCASENO") = ""
                                _TmpBookVnRow("CASENO") = ""
                                _TmpBookVnRow("DESCR") = ""
                                _TmpBookVnRow("SHADENO") = ""
                                _TmpBookVnRow("MTR_WEIGHT") = 0
                                _TmpBookVnRow("RATE") = 0
                                _TmpBookVnRow("RATEON") = ""
                                _TmpBookVnRow("ROWREMARK") = ""
                                _TmpBookVnRow("PROCESSNAME") = ""
                                _TmpBookVnRow("DESIGNNO") = ""
                                _TmpBookVnRow("LOTNO") = ""
                                _TmpBookVnRow("OFFERNO") = ""
                                _TmpBookVnRow("AVGWEIGHT") = 0
                                _TmpBookVnRow("PICKRATE") = 0
                                _TmpBookVnRow("RD") = 0
                                _TmpBookVnRow("RDON") = ""
                                _TmpBookVnRow("CD") = 0
                                _TmpBookVnRow("CDON") = ""
                                _TmpBookVnRow("PCS") = 0
                                _TmpBookVnRow("GROSSAMOUNT") = 0
                                _TmpBookVnRow("ASS_NAME") = ""
                                _TmpBookVnRow("ASS_CODE") = ""
                                _TmpBookVnRow("ASS_TYPE") = ""

                                _TmpBookVnRow("IGSTRATE") = 0
                                _TmpBookVnRow("CESSAMT") = 0
                                _TmpBookVnRow("EWAYBILLNO") = ""
                                _TmpBookVnRow("SUPPLIER_NAME") = ""
                                'Row_Cnt = Row_Cnt + 1
                            Next
                        End If
                    End If
                    ' Second Copy Finish
                End If
            Next


            NewReportPrint(_NewTmpTbl, RptTitle, Date_Range)
        Else
            MsgBox("No Record Found !", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        End If

        Ctrl_Visibility(False)
        Btn_Enabled_Code(True)
        button_focus()
    End Sub
#End Region
    Private Sub GradingBarCodeMergeReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Me.Dispose(True)
        End If
    End Sub

    Private Sub Cmd_btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose(True)
    End Sub
#End Region
End Class