Imports System.Text

Public Class QuotationEntryPrint
    Dim _Selectionbutton As String
    Private WithEvents txtgodowncode As New TextBox
    Private _GodownCode As String = ""
    Private _BookCode As String = ""
    Private _BookTrType As String = ""
    Dim _CheckFormLoad As Boolean = True
    Private Sub txtunitName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtunitName.KeyPress
        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then

            Dim _Filterstring As String = " AND A.BOOKCATEGORY='FACTORY-BEAM'"
            Dim _LoadQuery = NewSelectionList.MstBookSelection(_Filterstring, True)
            Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtunitName.Text, "SINGLE")
            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then txtgodowncode.Text = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("BookName") Then txtunitName.Text = selected("BookName").ToString()
            End If
            _GodownCode = txtgodowncode.Text
            SendKeys.Send("{TAB}")
            CheckMaxEntry()
        End If
    End Sub

    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub
    Private Sub CheckMaxEntry()

        Dim View_Filter_Condition As String = ""

        View_Filter_Condition = " and a.BookTrtype='QESS1' and A.godowncode='" & _GodownCode & "' "

        _strQuery = New StringBuilder()
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.ENTRYNO")
            .Append(" FROM  ")
            .Append(" TrnPackingSlip AS A  ")
            .Append(" WHERE 1=1  ")
            .Append(View_Filter_Condition)
            .Append(" order by A.entryno DESC  ")
        End With

        sqL = _strQuery.ToString
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_FromEntryNo.Text = DefaltSoftTable.Rows(0).Item("entryno").ToString
            Txt_ToEntryNo.Text = Txt_FromEntryNo.Text
        End If

    End Sub
    Private Sub View_Log_Book()
        Try
            Dim View_Filter_Condition As String = ""
            If Txt_FromEntryNo.Text <> "" AndAlso Txt_ToEntryNo.Text <> "" Then
                View_Filter_Condition = "AND A.EntryNo>='" & Txt_FromEntryNo.Text & "' and A.EntryNo<='" & Txt_ToEntryNo.Text & "' and a.BookTrtype='QESS1' And A.godowncode='" & _GodownCode & "'  "
            End If
            _strQuery = New StringBuilder()
            With _strQuery
                .Append(" SELECT ")
                .Append("  A.BookVno, ")
                .Append("  A.ENTRYNO as [EntryNo], ")
                .Append("  A.PACK_SLIP_NO as [Challan No], ")
                .Append("  A.OP20 as [Book Name], ")
                .Append(" FORMAT( A.PACK_SLIP_DATE,'dd/MM/yyyy') AS [Challan Date], ")
                .Append(" MstMasterAccount.accountname as [Party Name], ")
                .Append("  A.SRNO as [Sno], ")
                .Append(" A.OP6 As [Ind No],")
                .Append(" B.ItemName as [Item Name], ")
                .Append(" K.TYPE_NAME AS [Sub Item], ")
                .Append(" E.DEPARTMENTNAME  AS DEPARTMENT, ")
                .Append(" A.MTR_WEIGHT as [Quantity], ")
                .Append(" FORMAT( A.RATE,'0.00') as [Net Rate], ")
                .Append("  A.AMOUNT as [Amount],")
                .Append("  A.CUT_MTR as [Gross Rate],")
                .Append("  A.RDVALUE as [Dis],")
                .Append("  A.WEIGHT as [Dis Amt],")
                .Append(" MstTransport.TransportName as [Transport], ")
                .Append(" C.accountname as [Agent Name], ")
                .Append(" MstCutMaster.CUTNAME, ")
                .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
                .Append(" G.BookName as [Unit Name], ")
                .Append(" A.ROWREMARK As [RowRemark],")
                .Append(" A.OP11 As [Gst%],")
                .Append(" A.OP12 As [Fright],")
                .Append(" A.OP13 As [Delivery],")
                .Append(" A.OP4 As [PaymentTerms],")
                .Append(" A.OP8 As Terms1,") 'Terms1
                .Append(" A.OP9 As Terms2,") 'Terms2
                .Append(" A.OP10 As Terms3,") 'Terms3
                .Append(" A.OP16 As Terms4,") 'Terms4
                .Append("  A.HeaderRemark as [Remark] ")
                .Append(" FROM  ")
                .Append(" TrnPackingSlip AS A  ")
                .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
                .Append(" LEFT JOIN  MstStoreItem As B ON A.ITEMCODE=B.ITEMCODE  ")
                .Append(" LEFT JOIN MstMasterAccount ON A.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTTRANSPORT  ON A.TRANSPORTCODE=MSTTRANSPORT.ID   ")
                .Append(" LEFT JOIN MstMasterAccount AS C ON MstMasterAccount.AGENTCODE=C.ACCOUNTCODE   ")
                .Append(" LEFT JOIN Mst_Acof_Supply ON  A.ACOFCODE=Mst_Acof_Supply.ID   ")
                .Append(" LEFT JOIN MstCutMaster ON MstCutMaster.ID=A.CUTCODE ")
                .Append(" LEFT JOIN MstStoreItemType K  ON  A.SHADECODE = K.TYPE_ID ")
                .Append(" LEFT JOIN MstDepartment E  ON A.DESIGNCODE=E.Departmentcode ")
                .Append(" LEFT JOIN MstColor F  ON  A.CUTCODE1=F.COLORCODE ")
                .Append(" LEFT JOIN MstBook G  ON  A.godowncode=G.BookCode ")
                .Append(" WHERE 1=1  ")
                .Append(View_Filter_Condition)
                .Append(" ORDER BY  A.Id Desc ")
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim Tmp_Data_Table As New DataTable
            Tmp_Data_Table = DefaltSoftTable.Copy

            If Tmp_Data_Table.Rows.Count > 0 Then
                'Dim Date_Range = "Audit Report  From : " & txt_From.Text & " TO " & txt_To.Text
                Dim RptTitle = "Quotation Entry Report"
                Dim Date_Range = ""
                If But_ok.Enabled = True Then
                    If Txt_FromEntryNo.Text <> "" AndAlso Txt_ToEntryNo.Text <> "" Then
                        REPORT_RPT_FILE_NAME = "QuotationEntryReport_" & Ctl_RptType.Text & ""
                        NewReportPrint(Tmp_Data_Table, RptTitle, Date_Range)
                        _ButtonEnable(True)
                        _TextboxEnable(False)
                        _ButtonFocus()
                    End If
                End If
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
    Private Sub _ButtonEnable(ByVal _GetEnable As Boolean)
        BtnItem.Enabled = _GetEnable
    End Sub
    Private Sub _TextboxEnable(ByVal _GetEnable As Boolean)
        txtunitName.Enabled = _GetEnable
        Txt_FromEntryNo.Enabled = _GetEnable
        Txt_ToEntryNo.Enabled = _GetEnable
        Ctl_RptType.Enabled = _GetEnable
        But_ok.Enabled = _GetEnable
        txtunitName.Focus()
        txtunitName.SelectAll()
    End Sub

    Private Sub _ButtonFocus()
        If _Selectionbutton = "Entry No" Then
            BtnItem.Focus()
        End If

        _CheckFormLoad = False
    End Sub

    Private Sub BtnItem_Click(sender As Object, e As EventArgs) Handles BtnItem.Click
        _Selectionbutton = "Entry No"
        _CheckFormLoad = True
        _TextboxEnable(True)
        Txt_FromEntryNo.ReadOnly = False
        Txt_ToEntryNo.ReadOnly = False
        Ctl_RptType.ReadOnly = False
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub QuotationEntryPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AttachButtonFocusEvents(Me)
        _ButtonEnable(True)
        _TextboxEnable(False)
        txtunitName.ReadOnly = True
        Txt_FromEntryNo.ReadOnly = True
        Txt_ToEntryNo.ReadOnly = True
        Ctl_RptType.ReadOnly = True
    End Sub

    Private Sub QuotationEntryPrint_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If _CheckFormLoad = True Then
                _ButtonEnable(True)
                _TextboxEnable(False)
                _ButtonFocus()
            Else
                Me.Close()
                Me.Dispose(True)
            End If
        End If
    End Sub
End Class