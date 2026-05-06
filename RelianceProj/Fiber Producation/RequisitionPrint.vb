Imports System.Text
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Customization

Public Class RequisitionPrint
    Dim _Selectionbutton As String
    Private WithEvents txtgodowncode As New TextBox
    Private _GodownCode As String = ""
    Private _BookCode As String = ""
    Private _BookTrType As String = ""
    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub
    Private Sub View_Log_Book()
        Try
            Dim View_Filter_Condition As String = ""
            If Txt_FromEntryNo.Text <> "" AndAlso Txt_ToEntryNo.Text <> "" Then
                View_Filter_Condition = "AND A.EntryNo>='" & Txt_FromEntryNo.Text & "' and A.EntryNo>='" & Txt_ToEntryNo.Text & "' and A.GodownCode='" & _GodownCode & "' and A.OP20='" & txtBookName.Text & "'"
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
                .Append(" MstFabricItem.ITENNAME as [Item Name], ")
                .Append(" K.subItemName  AS [Sub Item], ")
                .Append(" E.DEPARTMENTNAME  AS DEPARTMENT, ")
                .Append(" FORMAT( A.MTR_WEIGHT,'0.000') as [Quantity], ")
                .Append(" FORMAT( A.RATE,'0.00') as [Gross Rate], ")
                .Append("  A.AMOUNT as [Amount],")
                .Append(" MstTransport.TransportName as [Transport], ")
                .Append(" C.accountname as [Agent Name], ")
                .Append(" MstCutMaster.CUTNAME, ")
                .Append(" Mst_Acof_Supply.AC_NAME as [A/c Of Name], ")
                .Append(" G.BookName as [Unit Name], ")
                .Append("A.ROWREMARK As [RowRemark]")
                .Append("  A.HeaderRemark as [Remark] ")
                .Append(" FROM  ")
                .Append(" TrnPackingSlip AS A  ")
                .Append(" LEFT JOIN MSTCITY ON A.DESPATCHCODE=MSTCITY.CITYCODE  ")
                .Append(" LEFT JOIN MstFabricItem ON A.ITEMCODE=MstFabricItem.ID   ")
                .Append(" LEFT JOIN MstMasterAccount ON A.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTTRANSPORT  ON A.TRANSPORTCODE=MSTTRANSPORT.ID   ")
                .Append(" LEFT JOIN MstMasterAccount AS C ON MstMasterAccount.AGENTCODE=C.ACCOUNTCODE   ")
                .Append(" LEFT JOIN Mst_Acof_Supply ON  A.ACOFCODE=Mst_Acof_Supply.ID   ")
                .Append(" LEFT JOIN MstCutMaster ON MstCutMaster.ID=A.CUTCODE ")
                .Append(" LEFT JOIN MstStoreSubItem K  ON  A.SHADECODE = K.subItemCode ")
                .Append(" LEFT JOIN MstDepartment E  ON A.DESIGNCODE=E.Departmentcode ")
                .Append(" LEFT JOIN MstColor F  ON  A.CUTCODE1=F.COLORCODE ")
                .Append(" LEFT JOIN MstBook G  ON  A.GodownCode=G.BookCode ")
                .Append(" WHERE 1=1  ")
                .Append(" And A.Bookcode='RQSS-000000001' ")
                .Append(View_Filter_Condition)
                .Append(" ORDER BY  A.Id Desc ")
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim Tmp_Data_Table As New DataTable
            Tmp_Data_Table = DefaltSoftTable.Copy

            If Tmp_Data_Table.Rows.Count > 0 Then
                Txt_FromEntryNo.Text = Tmp_Data_Table.Rows(0)("EntryNo")
                Txt_ToEntryNo.Text = Tmp_Data_Table.Rows(0)("EntryNo")
                'Dim Date_Range = "Audit Report  From : " & txt_From.Text & " TO " & txt_To.Text
                Dim RptTitle = "Stores Requisition Report"
                Dim Date_Range = ""
                If But_ok.Enabled = True Then
                    If Txt_FromEntryNo.Text <> "" AndAlso Txt_ToEntryNo.Text <> "" Then
                        REPORT_RPT_FILE_NAME = "StoresRequisitionReport_" & Ctl_RptType.Text & ""
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
        Txt_FromEntryNo.Enabled = _GetEnable
        Txt_ToEntryNo.Enabled = _GetEnable
        Ctl_RptType.Enabled = _GetEnable
        But_ok.Enabled = _GetEnable
        'Txt_FromEntryNo.Focus()
        'Txt_FromEntryNo.SelectAll()
        txtunitName.Focus()
        txtunitName.SelectAll()
    End Sub

    Private Sub _ButtonFocus()
        If _Selectionbutton = "Entry No" Then
            BtnItem.Focus()
        End If
    End Sub

    Private Sub RequisitionPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'View_Log_Book()
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        _ButtonEnable(True)
        _TextboxEnable(False)
        txtunitName.ReadOnly = True
        txtBookName.ReadOnly = True
        Txt_FromEntryNo.ReadOnly = True
        Txt_ToEntryNo.ReadOnly = True
        Ctl_RptType.ReadOnly = True
    End Sub

    Private Sub BtnItem_Click(sender As Object, e As EventArgs) Handles BtnItem.Click
        _Selectionbutton = "Entry No"
        'REPORT_RPT_FILE_NAME = "ReadyMadeStockReport_1"
        View_Log_Book()
        _TextboxEnable(True)
        Txt_FromEntryNo.ReadOnly = False
        Txt_ToEntryNo.ReadOnly = False
        Ctl_RptType.ReadOnly = False
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Txt_FromEntryNo_OnVaidationError(_ErrorMsg As String) Handles Txt_FromEntryNo.OnVaidationError

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Txt_ToEntryNo_OnVaidationError(_ErrorMsg As String) Handles Txt_ToEntryNo.OnVaidationError

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Ctl_RptType_OnVaidationError(_ErrorMsg As String) Handles Ctl_RptType.OnVaidationError

    End Sub

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
        End If
        txtBookName.Focus()
        txtBookName.SelectAll()
    End Sub

    Private Sub txtBookName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBookName.KeyPress

        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            Dim _LoadQuery As String = "SELECT 'RQSS-000000001' AS ACCOUNTCODE, 'GENERAL' AS BookName " &
    "UNION ALL SELECT 'RQSS-000000002','PARTY WISE' " &
    "UNION ALL SELECT 'RQSS-000000003','AGENT WISE'"
            Dim selected = SingleAccountSelectionForm(_LoadQuery, Nothing, txtBookName.Text, "SINGLE")

            If selected IsNot Nothing Then
                If selected.ContainsKey("ACCOUNTCODE") Then _BookCode = selected("ACCOUNTCODE").ToString()
                If selected.ContainsKey("BookName") Then txtBookName.Text = selected("BookName").ToString()
            End If
            'Book_Name = txtgodownBookName.Text
            If _BookCode = "RQSS-000000001" Then
                _BookTrType = "RQSS1"
            ElseIf _BookCode = "RQSS-000000002" Then
                _BookTrType = "RQSS2"
            ElseIf _BookCode = "RQSS-000000003" Then
                _BookTrType = "RQSS3"
            End If
            SendKeys.Send("{TAB}")
        End If
        Txt_FromEntryNo.Focus()
        Txt_FromEntryNo.SelectAll()
        'e.Handled = True
    End Sub
End Class