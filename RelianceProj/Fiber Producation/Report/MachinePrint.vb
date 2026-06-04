Imports System.Text

Public Class MachinePrint
    Dim _Selectionbutton As String
    Private WithEvents txtgodowncode As New TextBox
    Private _GodownCode As String = ""
    Private _BookCode As String = ""
    Private _BookTrType As String = ""
    Dim _CheckFormLoad As Boolean = True

    Private Sub But_ok_Click(sender As Object, e As EventArgs) Handles But_ok.Click
        View_Log_Book()
    End Sub
    Private Sub CheckMaxEntry()

        Dim View_Filter_Condition As String = ""

        View_Filter_Condition = " and a.Group_master_finance='FIXED ASSETS MASTER'  "

        _strQuery = New StringBuilder()
        With _strQuery
            .Append(" SELECT TOP 1 ")
            .Append(" A.MAIN_ACCOUNT_MASTER")
            .Append(" FROM  ")
            .Append(" vch_no AS A  ")
            .Append(" WHERE 1=1  ")
            .Append(View_Filter_Condition)
            .Append(" order by A.Main_account_master DESC  ")
        End With

        sqL = _strQuery.ToString
        sql_connect_slect()

        If DefaltSoftTable.Rows.Count > 0 Then
            Txt_FromEntryNo.Text = DefaltSoftTable.Rows(0).Item("MAIN_ACCOUNT_MASTER").ToString
            Txt_ToEntryNo.Text = Txt_FromEntryNo.Text
        End If

    End Sub
    Private Sub View_Log_Book()
        Try
            Dim View_Filter_Condition As String = ""
            If Txt_FromEntryNo.Text <> "" AndAlso Txt_ToEntryNo.Text <> "" Then
                View_Filter_Condition = "AND A.MAIN_ACCOUNT_MASTER>='" & Txt_FromEntryNo.Text & "' and A.MAIN_ACCOUNT_MASTER<='" & Txt_ToEntryNo.Text & "' and a.Group_master_finance='FIXED ASSETS MASTER' "
            End If
            _strQuery = New StringBuilder()
            With _strQuery
                .Append(" SELECT  ")
                .Append("A.Main_account_master As MachineNo,")
                .Append("A.STATEMASTER As MachineName,")
                .Append("A.CITYMASTER As Brand,")
                .Append("A.TRANSPORT_MASTER As Section,")
                .Append("A.MSTFABRICMASTER As BoolValue,")
                .Append("A.MSTFABRICHEAD As Depreciation,")
                .Append("A.MSTFABRICGROUP As SpaceOccupied,")
                .Append("A.MSTYARNMASTER AS L,")
                .Append("A.MSTITEMGROUP As W,")
                .Append("A.MSTITEMCOMPANY AS Category,")
                '.Append("A.MSTITEMMASTER,") ' cutcode
                .Append("A.MST_BARCODE As HSN,")
                .Append("A.MST_BATCHID As TaxRate,")
                '.Append("A.MSTINSURANCE,") ' Departmentcode
                .Append("A.MSTFABRIC_ITEM_CATEGORY,")
                .Append("B.CutName As UOM,")
                .Append("C.Departmentname As DepartmentName,")
                .Append("A.MST_YARN_SHADE As ModifiedDate,")
                .Append("A.MSTCUTMASTER As EntryDate")
                .Append("  FROM Vch_no as A ")
                .Append("  LEFT JOIN MstCutMaster AS B  ON A.MSTITEMMASTER=B.ID")
                .Append(" left Join MstDepartment As C on A.MSTINSURANCE=C.Departmentcode ")
                .Append("  WHERE 1=1")
                .Append(View_Filter_Condition)
                .Append(" ORDER BY  A.MAIN_ACCOUNT_MASTER Desc ")
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim Tmp_Data_Table As New DataTable
            Tmp_Data_Table = DefaltSoftTable.Copy

            If Tmp_Data_Table.Rows.Count > 0 Then
                'Dim Date_Range = "Audit Report  From : " & txt_From.Text & " TO " & txt_To.Text
                Dim RptTitle = "Fixed Assets Machine Parts Report"
                Dim Date_Range = ""
                If But_ok.Enabled = True Then
                    If Txt_FromEntryNo.Text <> "" AndAlso Txt_ToEntryNo.Text <> "" Then
                        REPORT_RPT_FILE_NAME = "MachinePartsReport_" & Ctl_RptType.Text & ""
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
        'txtunitName.Enabled = _GetEnable
        Txt_FromEntryNo.Enabled = _GetEnable
        Txt_ToEntryNo.Enabled = _GetEnable
        Ctl_RptType.Enabled = _GetEnable
        But_ok.Enabled = _GetEnable
        Txt_FromEntryNo.Focus()
        Txt_FromEntryNo.SelectAll()
    End Sub

    Private Sub _ButtonFocus()
        If _Selectionbutton = "Machine No" Then
            BtnItem.Focus()
        End If

        _CheckFormLoad = False
    End Sub

    Private Sub BtnItem_Click(sender As Object, e As EventArgs) Handles BtnItem.Click
        _Selectionbutton = "Machine No"
        _CheckFormLoad = True
        _TextboxEnable(True)
        Txt_FromEntryNo.ReadOnly = False
        Txt_ToEntryNo.ReadOnly = False
        Ctl_RptType.ReadOnly = False
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub
    Private Sub QuotationEntryPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        _ButtonEnable(True)
        _TextboxEnable(False)
        'txtunitName.ReadOnly = True
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

    Private Sub Txt_FromEntryNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_FromEntryNo.KeyPress

        If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 32 Then
            If Txt_FromEntryNo.Text <> "" Then
            Else
                SendKeys.Send("{TAB}")
                CheckMaxEntry()
            End If

        End If
    End Sub
End Class