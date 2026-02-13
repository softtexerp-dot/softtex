Imports DevExpress.XtraEditors.Repository
Imports System.Text

Public Class Grading_RateUpdater

    Private Sub Packing_JobCard_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not String.IsNullOrWhiteSpace(Me.Tag) Then
            Main_MDI_Frm.RestoreMenuFocus(Me.Tag, Main_MDI_Frm.MenuStrip1)
        End If
    End Sub

    Private Sub Grading_RateUpdater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        AttachButtonFocusEvents(Me)
        Cmb_ViewType.Focus()
        Cmb_ViewType.Text = "Finish Rate"
    End Sub
    Private Sub Grading_RateUpdater_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If MessageBox.Show("Do You Want To Exit?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        getAlter_Form_Query_Details()
    End Sub

    Private Sub getAlter_Form_Query_Details()
        Dim _FilterBy As String = ""
        Dim _FilterByCutMark As String = ""

        If Cmb_ViewType.Text = "Finish Rate" Then
            _FilterBy = " AND ISNULL(trngrading.Tmp_Pcs,0) = 0"
        ElseIf Cmb_ViewType.Text = "Process Rate" Then
            _FilterBy = " AND ISNULL(trngrading.OP32,0) = 0"
        ElseIf Cmb_ViewType.Text = "Gray Rate" Then
            _FilterBy = " AND ISNULL(trngrading.OP31,0) = 0"
        ElseIf Cmb_ViewType.Text = "All Rate" Then
            _FilterBy = " AND ( ISNULL(trngrading.Tmp_Pcs,0) = 0 OR ISNULL(trngrading.OP32,0) = 0 OR ISNULL(trngrading.OP31,0) = 0 )"
        End If

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT DISTINCT  ")
            .Append("  Z.EntryNo ")
            .Append(" ,Z.BILL_CHL_DATE as Date ")
            .Append(" ,Z.ITEMCODE ")
            .Append(" ,Z.DESIGNCODE ")
            .Append(" ,Z.SHADECODE ")
            .Append(" ,Z.GRADERCODE")
            .Append(" ,Z.PIECE_ID")
            .Append(" ,Z.BOOKVNO")
            .Append(" ,Z.SrNo")
            .Append(" ,Z.ItemName")
            .Append(" ,Z.CutName")
            .Append(" ,Z.DESIGNNO as Design")
            .Append(" ,Z.DesignGroup")
            .Append(" ,Z.SHADENO as Shade")
            .Append(" ,Z.DESCR as LotNO ")
            .Append(" ,Z.PIECENO as Pieceno ")
            .Append(" ,Z.BARCODE_LUMPNO as LumpTagNo ")
            .Append(" ,Z.BARCODE_TAGNO as ThanTagNo ")
            .Append(" ,Z.GRADE as Grade ")
            .Append(" ,Z.OP3 as FdPd ")
            .Append(" ,isnull(Z.CHL_MTR,0) as ChlMtr ")
            .Append(" ,Z.CHECKED_MTR as KataMtr ")
            .Append(" ,isnull(Z.Tmp_Pcs,0) as FinishRate")
            .Append(" ,isnull(z.OP31,0) AS GrayRate ")
            .Append(" ,isnull(z.OP32,0) AS ProcessRate ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" trngrading.*, ")
            .Append(" convert(varchar,  trngrading.BILL_CHL_DATE, 103)   AS F_BILL_CHL_DATE, ")
            .Append(" convert(varchar,  trngrading.GP_DATE, 103)   AS F_GP_DATE, ")
            .Append(" convert(varchar,  trngrading.LRDATE, 103)   AS F_LRDATE, ")
            .Append(" MstCity.cityname AS DESPATCH, ")
            .Append(" Mst_Fabric_Design.Design_Name AS DESIGNNO, ")
            .Append(" s.fabric_GroupName AS DesignGroup, ")
            .Append(" MstFabricItem.ITENNAME AS ITEMNAME, ")
            .Append(" MstMasterAccount.ACCOUNTNAME, ")
            .Append(" Mst_Fabric_Shade.SHADE AS SHADENO, ")
            .Append(" MstTransport.TransportName, ")
            .Append(" a.accountname as agentname, ")
            .Append(" Mst_Acof_Supply.AC_NAME, ")
            .Append(" MstCutMaster.CUTName ")
            .Append(" ,M.GraderName ")
            .Append(" ,R.GraderName AS FolderName ")
            .Append(" ,N.ACCOUNTNAME AS GodownName ")
            .Append(" ,ISNULL(MstMasterAccount.OP17, 0) AS LRate ")
            .Append(" ,ISNULL(MstMasterAccount.OP19, 0) AS HLumpRate ")
            .Append(" ,ISNULL(MstMasterAccount.OP21,0) AS ThanRate ")
            .Append(" FROM ( ")


            .Append(" SELECT ")
            .Append(" Y.PIECE_ID ")
            .Append(" , SUM(Y.Checked_mtr) AS CHK_MTR, ")
            .Append(" SUM(Y.CUTTING_MTR) AS CUT_MTR ")
            .Append(" FROM ")
            .Append(" ( ")
            .Append(" SELECT ")
            .Append(" A.PIECE_ID, A.mtr as Checked_mtr,0.00 AS CUTTING_MTR ")
            .Append(" FROM TRNGRADING A,MstCutMaster B ")
            .Append(" WHERE 1=1 AND LEFT(A.BOOKTRTYPE,1)<>'P' ")
            .Append(" AND LEFT(A.BOOKTRTYPE,1)<>'R' ")
            .Append(" AND A.CutCode=B.ID ")
            .Append(" AND B.CUTTYPE NOT IN ('FENT','T/L') ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.PARENT_PIECE_ID AS PIECE_ID, ")
            .Append(" 0.00 AS Checked_mtr,SUM(A.MTR) AS CUTTING_MTR ")
            .Append(" FROM TRNGRADING A ")
            .Append(" WHERE 1=1 ")
            .Append(" GROUP BY A.PARENT_PIECE_ID  ")
            .Append(" ) AS Y ")
            .Append(" GROUP BY Y.PIECE_ID ")
            .Append(" HAVING SUM(Checked_mtr)-SUM(CUTTING_MTR)>0 ")
            .Append(" ) AS Z ")

            .Append(" LEFT JOIN TRNGRADING  ON  TRNGRADING.Piece_ID =Z.Piece_ID  ")
            .Append(" LEFT JOIN MSTCITY ON trngrading.DESPATCHCODE=MSTCITY.CITYCODE  ")
            .Append(" LEFT JOIN Mst_Fabric_Design ON trngrading.DESIGNCODE=Mst_Fabric_Design.Design_code ")
            .Append(" LEFT JOIN MSTFABRICITEM ON trngrading.ITEMCODE=MSTFABRICITEM.ID  ")
            .Append(" LEFT JOIN MstMasterAccount ON trngrading.ACCOUNTCODE=MstMasterAccount.ACCOUNTCODE")
            .Append(" LEFT JOIN Mst_Fabric_Shade ON  trngrading.SHADECODE=Mst_Fabric_Shade.ID  ")
            .Append(" LEFT JOIN MSTTRANSPORT ON trngrading.TRANSPORTCODE=MSTTRANSPORT.ID  ")
            .Append(" LEFT JOIN MstMasterAccount AS A ON MstMasterAccount.AGENTCODE=A.ACCOUNTCODE  ")
            .Append(" LEFT JOIN Mst_Acof_Supply ON  trngrading.ACOFCODE=Mst_Acof_Supply.ID  ")
            .Append(" LEFT JOIN MstCutMaster ON  trngrading.CUTCODE=MstCutMaster.ID ")
            .Append(" LEFT JOIN MstGrader AS M ON  trngrading.GRADERCODE=M.GraderCode  ")
            .Append(" LEFT JOIN MstMasterAccount AS N  ON  trngrading.SYNSTATUS=N.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstGrader AS R  ON trngrading.OP8=R.GraderCode  ")
            .Append(" LEFT JOIN MstFabricGroup S ON trngrading.OP10=S.ID    ")

            .Append(" WHERE 1=1  ")

            .Append(_FilterBy)
            .Append(_FilterByCutMark)
            .Append(" ) ")
            .Append(" AS Z  ")

            .Append(" ORDER BY Z.EntryNo ,Z.SRNO ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()

        FirstStage.Columns.Clear()
        Dim tblTmp As New DataTable
        tblTmp = DefaltSoftTable.Copy
        If tblTmp.Rows.Count > 0 Then

            GridControl1.DataSource = tblTmp.Copy

            FirstStage.Columns("GRADERCODE").Visible = False
            FirstStage.Columns("BOOKVNO").Visible = False
            FirstStage.Columns("PIECE_ID").Visible = False
            FirstStage.Columns("SrNo").Visible = False
            FirstStage.Columns("ITEMCODE").Visible = False
            FirstStage.Columns("DESIGNCODE").Visible = False
            FirstStage.Columns("SHADECODE").Visible = False
            FirstStage.Columns("DesignGroup").Visible = False
            FirstStage.Columns("FdPd").Visible = False
            FirstStage.Columns("Grade").Visible = False
            FirstStage.Columns("LotNO").Visible = False
            FirstStage.Columns("KataMtr").Visible = False


            If Cmb_ViewType.Text = "Finish Rate" Then
                FirstStage.Columns("GrayRate").Visible = False
                FirstStage.Columns("ProcessRate").Visible = False
            ElseIf Cmb_ViewType.Text = "Process Rate" Then
                FirstStage.Columns("GrayRate").Visible = False
                FirstStage.Columns("FinishRate").Visible = False
            ElseIf Cmb_ViewType.Text = "Gray Rate" Then
                FirstStage.Columns("ProcessRate").Visible = False
                FirstStage.Columns("FinishRate").Visible = False
            End If

            FirstStage.Columns("EntryNo").OptionsColumn.AllowEdit = False
            FirstStage.Columns("Date").OptionsColumn.AllowEdit = False
            FirstStage.Columns("SrNo").OptionsColumn.AllowEdit = False
            FirstStage.Columns("ItemName").OptionsColumn.AllowEdit = False
            FirstStage.Columns("CutName").OptionsColumn.AllowEdit = False
            FirstStage.Columns("Design").OptionsColumn.AllowEdit = False
            FirstStage.Columns("Shade").OptionsColumn.AllowEdit = False
            FirstStage.Columns("Pieceno").OptionsColumn.AllowEdit = False
            FirstStage.Columns("LumpTagNo").OptionsColumn.AllowEdit = False
            FirstStage.Columns("ThanTagNo").OptionsColumn.AllowEdit = False
            FirstStage.Columns("Grade").OptionsColumn.AllowEdit = False
            FirstStage.Columns("ChlMtr").OptionsColumn.AllowEdit = False
            FirstStage.Columns("KataMtr").OptionsColumn.AllowEdit = False
            FirstStage.Columns("FdPd").OptionsColumn.AllowEdit = False
            FirstStage.Columns("PIECE_ID").OptionsColumn.AllowEdit = False
            FirstStage.Columns("BOOKVNO").OptionsColumn.AllowEdit = False
            FirstStage.Columns("LotNO").OptionsColumn.AllowEdit = False
            FirstStage.Columns("ITEMCODE").OptionsColumn.AllowEdit = False
            FirstStage.Columns("DESIGNCODE").OptionsColumn.AllowEdit = False
            FirstStage.Columns("SHADECODE").OptionsColumn.AllowEdit = False

            FirstStage.BestFitColumns()
            FirstStage.Focus()
            GridControl1.BringToFront()

        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        savedata()
    End Sub
    Private Sub savedata()
        Wait_Window_Show(Me, "Stock Update Please Wait...")
        FirstStage.ActiveFilter.Clear()

        For i As Integer = 0 To FirstStage.RowCount - 1
            Dim lump As Double = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "LumpTagNo")), 0, FirstStage.GetRowCellValue(i, "LumpTagNo")))
            Dim than As Double = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "ThanTagNo")), 0, FirstStage.GetRowCellValue(i, "ThanTagNo")))
            Dim _RateCheck As Double = 0

            If Cmb_ViewType.Text = "Finish Rate" Then
                _RateCheck = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "FinishRate")), 0, FirstStage.GetRowCellValue(i, "FinishRate")))
            ElseIf Cmb_ViewType.Text = "Process Rate" Then
                _RateCheck = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "ProcessRate")), 0, FirstStage.GetRowCellValue(i, "ProcessRate")))
            ElseIf Cmb_ViewType.Text = "Gray Rate" Then
                _RateCheck = Convert.ToDouble(If(IsDBNull(FirstStage.GetRowCellValue(i, "GrayRate")), 0, FirstStage.GetRowCellValue(i, "GrayRate")))
            End If


            If (lump > 0 OrElse than > 0) AndAlso _RateCheck > 0 Then
                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" UPDATE TRNGRADING SET ")

                    .Append(" Tmp_Pcs='" & FirstStage.GetRowCellValue(i, "FinishRate").ToString & "'  ")
                    .Append(" ,OP31='" & FirstStage.GetRowCellValue(i, "GrayRate").ToString & "'  ")
                    .Append(" ,OP32='" & FirstStage.GetRowCellValue(i, "ProcessRate").ToString & "'  ")

                    .Append("  WHERE 1=1 ")
                    .Append("  and BOOKVNO='" & FirstStage.GetRowCellValue(i, "BOOKVNO").ToString & "'")
                    .Append("  and PIECE_ID='" & FirstStage.GetRowCellValue(i, "PIECE_ID").ToString & "' ")
                    .Append("  and BARCODE_LUMPNO='" & FirstStage.GetRowCellValue(i, "LumpTagNo").ToString & "' ")
                    .Append("  and BARCODE_TAGNO='" & FirstStage.GetRowCellValue(i, "ThanTagNo").ToString & "' ")

                End With
                sqL = _strQuery.ToString
                sql_Data_Save_Delete_Update()
            End If
        Next
        MsgBox("Record Successfully Update", MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        Wait_Window_Hide()
        'FirstStage.Columns.Clear()

    End Sub

    Private Sub Cmb_ViewType_KeyDown(sender As Object, e As KeyEventArgs) Handles Cmb_ViewType.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnView.Focus()

        End If
    End Sub


End Class