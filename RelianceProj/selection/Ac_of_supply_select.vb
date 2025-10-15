Imports System.Text
Imports DevExpress.XtraGrid
Imports FlexCell

Friend Class Ac_of_supply_select

    Private Sub Ac_of_supply_select_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Me.TopMost = True
        'Me.BringToFront()
    End Sub

    Private Sub Ac_of_supply_select_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Me.Dispose(True)
        End If
    End Sub

    Private Sub Ac_of_supply_select_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim x As Integer
        'Dim y As Integer
        'x = 0
        'y = (Screen_Height - Screen_Height) + Main_MDI_Frm.MenuStrip1.Height + 30
        Me.Location = New Point(0, 0)
        _LoadQuary()

    End Sub


    Private Sub _LoadQuary()

        _strQuery = New StringBuilder
        With _strQuery
            .Append("  	SELECT 	  ")
            .Append("  	A.AC_NAME AS [AC/OF Name]	  ")
            .Append("  	,A.GSTIN as [Gstin]	  ")
            .Append("  	,A.PHONENO as [Phone No]	  ")
            .Append("  	,B.cityname as [City Name]	  ")
            .Append("  	,D.ACCOUNTNAME as [ Party Name]	  ")
            .Append("  	,E.TRANSPORTNAME  as [Transport Name]	  ")
            .Append("  	FROM Mst_Acof_Supply A  	  ")
            .Append("  	LEFT JOIN  MstCity B ON A.CITY_CODE=B.citycode 	  ")
            .Append("  	LEFT JOIN   MstState C  ON  B.stateid=C.STATEID 	  ")
            .Append("  	LEFT JOIN  MstMasterAccount D ON A.PART_NAME_ID=D.ACCOUNTCODE  	  ")
            .Append("  	LEFT JOIN  MstTransport E ON  A.TRANSPOID=E.ID 	  ")
            .Append("  	ORDER BY A.AC_NAME  ")

        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim tblTmp = DefaltSoftTable.Copy

        FirstStage.Columns.Clear()
        If tblTmp.Rows.Count > 0 Then

            GridControl1.DataSource = tblTmp

            FirstStage.Appearance.Row.Font = New Font("Tahoma", 8, FontStyle.Bold)
            FirstStage.Appearance.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)

            FirstStage.GroupRowHeight = 30

            FirstStage.BestFitColumns()
            FirstStage.Focus()

            GridControl1.BringToFront()
        Else
            MsgBox("Record Not Found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If

    End Sub
    Private Sub But_print_Click(sender As Object, e As EventArgs) Handles But_print.Click
        Dim _RptTiltle = " Report From A/C Of Master"
        _DevExpressPrintPrivew(_RptTiltle, FirstStage)
    End Sub

    Private Sub But_export_Click(sender As Object, e As EventArgs) Handles But_export.Click
        _DevExpressExcelExport(GridControl1)
    End Sub

    Private Sub But_close_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
        Me.Dispose(True)
    End Sub



End Class