Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports RestSharp

Friend Class RecivedStoreRoom

    Private obj_Party_Selection As New Multi_Selection_Master
    Private WithEvents Txt_Master_code As New TextBox
    Private WithEvents Txt_Item_code As New TextBox
    Dim _Iddatatable As New DataTable

#Region "BUTTON COLOR"
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

    Private Sub RecivedStoreRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        DeifineGridCloum()
        LblItemDisplay.Text = ""
        LblCustomerName.Text = ""
    End Sub
    Private Sub RecivedStoreRoom_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Me.Dispose()
            '    Main_MDI_Frm.TailoringToolStripMenuItem.ShowDropDown()
            '    Main_MDI_Frm.RecivedStoreRoomToolStripMenuItem.Select()
        End If
    End Sub
    Private Sub DeifineGridCloum()

        Grid_1.Cols = 10




        Grid_1.Cell(0, 1).Text = "BookVno"
        Grid_1.Cell(0, 2).Text = "Stich ID"
        Grid_1.Cell(0, 3).Text = "Customer Name"
        Grid_1.Cell(0, 4).Text = "Stich Item"
        Grid_1.Cell(0, 5).Text = "Dress Status"
        Grid_1.Cell(0, 6).Text = "Qty"
        Grid_1.Cell(0, 7).Text = "ItemCode"
        Grid_1.Cell(0, 8).Text = "MOBILE"
        Grid_1.Cell(0, 9).Text = "NewDressItem"




        Grid_1.Column(1).Visible = False
        'Grid_1.Column(5).Visible = False
        Grid_1.Column(6).Visible = False
        Grid_1.Column(7).Visible = False
        Grid_1.Column(8).Visible = False
        Grid_1.Column(9).Visible = False

        Grid_1.Column(1).Alignment = FlexCell.AlignmentEnum.LeftGeneral
        Grid_1.Column(2).Alignment = FlexCell.AlignmentEnum.LeftGeneral
        Grid_1.Column(3).Alignment = FlexCell.AlignmentEnum.LeftGeneral
        Grid_1.Column(4).Alignment = FlexCell.AlignmentEnum.LeftGeneral
        Grid_1.Column(5).Alignment = FlexCell.AlignmentEnum.LeftGeneral

        Grid_1.Column(2).Width = 80
        Grid_1.Column(3).Width = 200
        Grid_1.Column(4).Width = 200
        Grid_1.Column(5).Width = 150
        Grid_1.Column(6).Width = 50


        'For i As Int16 = 1 To Grid_1.Rows - 1
        '    'If Grid_1.Cell(i, 7).Text = "Stiching Department" Then Grid_1.Cell(i, 7).BackColor = Color.RosyBrown
        '    If Grid_1.Cell(i, 7).Text = "Stiching Department" Then Grid_1.Cell(i, 7).ForeColor = Color.Red
        '    If Grid_1.Cell(i, 7).Text = "Trial Dress Stiching Department" Then Grid_1.Cell(i, 7).ForeColor = Color.Red
        '    If Grid_1.Cell(i, 7).Text = "Dress In Store Room" Then Grid_1.Cell(i, 7).ForeColor = Color.Chartreuse
        '    If Grid_1.Cell(i, 7).Text = "Trial Dress Recived In Store Room" Then Grid_1.Cell(i, 7).ForeColor = Color.Chartreuse
        '    If Grid_1.Cell(i, 7).Text = "Delevered To Customer" Then Grid_1.Cell(i, 7).ForeColor = Color.Khaki
        '    If Grid_1.Cell(i, 7).Text = "Trial Dress Delevered To Customer" Then Grid_1.Cell(i, 7).ForeColor = Color.Khaki
        'Next



        Grid_1.Refresh()
        Grid_1.Locked = True
        Grid_1.Visible = True


    End Sub



    Private Sub TxtMaster_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMaster.KeyPress
        If e.KeyChar = Chr(27) Then Exit Sub

        Party_selection.txtSearch.Text = TxtMaster.Text
        obj_Party_Selection.Single_Stich_Master_Selection()
        TxtMaster.Text = MULTY_SELECTION_COLOUM_1_DATA
        Txt_Master_code.Text = MULTY_SELECTION_COLOUM_3_DATA
        TxtIDno.Focus()
        TxtIDno.SelectAll()
    End Sub

    Private Sub TxtMaster_Validated(sender As Object, e As EventArgs) Handles TxtMaster.Validated
        If TxtMaster.Text = "" Then Txt_Master_code.Text = ""
    End Sub

    Private Sub TxtIDno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIDno.TextChanged
        If TxtIDno.Text = "" Then Exit Sub
        If TxtIDno.Text = "" Then LblItemDisplay.Text = ""
        If TxtIDno.Text = "" Then LblCustomerName.Text = ""


        If TxtMaster.Text = "" Then
            MsgBox("Select Master Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            TxtMaster.Focus()
            TxtMaster.SelectAll()
            Exit Sub
        End If
        load_quary()

    End Sub

    Private Sub TxtIDno_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtIDno.KeyDown
        If e.KeyCode = Keys.Enter Then

            If TxtMaster.Text = "" Then
                MsgBox("Select Master Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                TxtMaster.Focus()
                TxtMaster.SelectAll()
                Exit Sub
            End If

            If TxtIDno.Text = "" Then
                MsgBox("Enter Stich ID No", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                TxtIDno.Focus()
                TxtIDno.SelectAll()
                Exit Sub
            End If

            If RadioButton2.Checked = True Then
                If TxtTrialItem.Text = "" Then
                    MsgBox("Enter Item Name", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    TxtTrialItem.Focus()
                    TxtTrialItem.SelectAll()
                    Exit Sub
                End If

                If TxtTrialQty.Text = "" Then
                    MsgBox("Enter Qty", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                    TxtTrialQty.Focus()
                    TxtTrialQty.SelectAll()
                    Exit Sub
                End If
            End If


            load_quary()
            Dim _idTbl As New DataTable
            _idTbl = DefaltSoftTable.Copy

            If LblItemDisplay.Text > "" Then
                Grid_1.Rows = Grid_1.Rows + 1
                If RadioButton1.Checked = True Then
                    Grid_1.Cell(Grid_1.Rows - 1, 1).Text = _idTbl.Rows(0).Item("BookVno")
                    Grid_1.Cell(Grid_1.Rows - 1, 2).Text = _idTbl.Rows(0).Item("Stich ID")
                    Grid_1.Cell(Grid_1.Rows - 1, 3).Text = _idTbl.Rows(0).Item("Customer Name")
                    Grid_1.Cell(Grid_1.Rows - 1, 4).Text = _idTbl.Rows(0).Item("Stich Item")
                    Grid_1.Cell(Grid_1.Rows - 1, 5).Text = "Dress In Store Room"

                    If MsgBox("Do You Want Send WhatsApp Message", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "WhatsApp Message ?") = MsgBoxResult.Yes Then
                        sqL = " select* from mstbook where bookcode='0001-000000029'"
                        sql_connect_slect()
                        Dim _defalmsg As String = DefaltSoftTable.Rows(0).Item("SHOW_RD_CD_IN_ENTRY")
                        Dim _MESSAGE As String = " ID No.: " & _idTbl.Rows(0).Item("Stich ID") & " Name : " & _idTbl.Rows(0).Item("Customer Name") & "  " & _defalmsg
                        UploadSendWhatsUp(_idTbl.Rows(0).Item("MOBILE"), _MESSAGE)
                    End If

                Else
                    'Grid_1.Cell(Grid_1.Rows - 1, 1).Text = _idTbl.Rows(0).Item("BookVno")
                    Grid_1.Cell(Grid_1.Rows - 1, 2).Text = TxtIDno.Text
                    Grid_1.Cell(Grid_1.Rows - 1, 3).Text = _idTbl.Rows(0).Item("Customer Name")
                    Grid_1.Cell(Grid_1.Rows - 1, 4).Text = TxtTrialItem.Text
                    Grid_1.Cell(Grid_1.Rows - 1, 5).Text = "Trial Dress Recived In Store Room"
                    Grid_1.Cell(Grid_1.Rows - 1, 6).Text = TxtTrialQty.Text
                    Grid_1.Cell(Grid_1.Rows - 1, 7).Text = Txt_Item_code.Text
                    Grid_1.Cell(Grid_1.Rows - 1, 8).Text = _idTbl.Rows(0).Item("MOBILE")

                    Dim _onetimeLessCheck As Boolean = False

                    For Each dr As DataRow In _idTbl.Select
                        If _onetimeLessCheck = False Then
                            If Txt_Item_code.Text = dr("StichingItemCode") Then
                                _onetimeLessCheck = True
                                dr("Qty") = Val(dr("Qty") - Val(TxtTrialQty.Text))
                            End If
                        End If
                    Next
                    Dim Itememark As String = ""
                    Dim mark As String = ""

                    For Each dr As DataRow In _idTbl.Select
                        If dr("Qty") > 0 Then
                            Itememark = Itememark & mark & dr("STICH_ITEM_NAME") & "-" & dr("Qty")
                        End If
                        mark = "; "
                    Next

                    For Each dr As DataRow In _idTbl.Select
                        dr("NewDressItem") = Itememark
                    Next

                    Grid_1.Cell(Grid_1.Rows - 1, 9).Text = _idTbl.Rows(0).Item("NewDressItem")




                    If MsgBox("Do You Want Send WhatsApp Message", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "WhatsApp Message ?") = MsgBoxResult.Yes Then
                        sqL = " select* from mstbook where bookcode='0001-000000029'"
                        sql_connect_slect()
                        Dim _defalmsg As String = DefaltSoftTable.Rows(0).Item("SHOW_RD_CD_IN_ENTRY")
                        Dim _MESSAGE As String = " ID No.: " & _idTbl.Rows(0).Item("Stich ID") & " Name : " & _idTbl.Rows(0).Item("Customer Name") & "  " & _defalmsg
                        UploadSendWhatsUp(_idTbl.Rows(0).Item("MOBILE"), _MESSAGE)
                    End If

                End If


                PnlTrial.Visible = False
                RadioButton1.Checked = True
                LblItemDisplay.Text = ""
                LblCustomerName.Text = ""
                TxtIDno.Text = ""
                TxtIDno.Focus()
            End If
            LblItemDisplay.Text = ""
            LblCustomerName.Text = ""
        End If
    End Sub
    Public Sub load_quary()

        Try
            LblItemDisplay.Text = ""
            LblCustomerName.Text = ""
            Dim FIlterString As String = ""
            FIlterString = "   And C.stiching_Id ='" & TxtIDno.Text & "'"

            Dim _strQuery As New StringBuilder
            With _strQuery
                .Append("	Select c.*, 	")
                .Append("	C.BookVno 	")
                .Append("	,C.stiching_Id as  [Stich ID]	")
                .Append("	,C.CustomerName  AS [Customer Name] 	")
                .Append("	,C.TOTALITEM as [Stich Item]	")
                .Append("	,C.MOBILE,'' as NewDressItem ,D.STICH_ITEM_NAME	")
                .Append("	FROM 	")
                .Append("	STC_TrnStichingDetail C	,STC_MstStichingItem d ")
                .Append("	WHERE 1=1 	")
                .Append("	AND C.StichingItemCode =D.STICHITEM_ID	")
                .Append("  " & FIlterString & " ")
                .Append("  AND C.MasterCode='" & Txt_Master_code.Text & "' ")
                .Append("  AND C.DressStatus='Stiching Department' ")
                .Append("	ORDER BY C.CustomerName  	")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            _Iddatatable.Clear()
            LblItemDisplay.Text = ""
            LblCustomerName.Text = ""
            If DefaltSoftTable.Rows.Count = 0 Then
                LblCustomerName.Text = ""
                LblItemDisplay.Text = ""
                Exit Sub
            Else
                _Iddatatable = DefaltSoftTable.Copy
                LblCustomerName.Text = DefaltSoftTable.Rows(0).Item("Customer Name").ToString
                LblItemDisplay.Text = DefaltSoftTable.Rows(0).Item("Stich Item").ToString
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim CUDATE As String = CDate(Date.Now).ToString("yyyy-MM-dd")
        Dim _time As String = CDate(Date.Now).ToString("HH:mm:ss")

        For i As Integer = 1 To Grid_1.Rows - 1
            If Grid_1.Cell(i, 2).Text > "" Then
                If Grid_1.Cell(i, 5).Text = "Dress In Store Room" Then
                    Dim _strQuery As New StringBuilder
                    With _strQuery
                        .Append("	Update  STC_TrnStichingDetail SET 	")
                        .Append("	 DressStatus ='" & Grid_1.Cell(i, 5).Text & "'	")
                        .Append("	 ,LastUpdateDate ='" & CUDATE & "'	")
                        .Append("	 ,LastUpdateTime ='" & _time & "'	")
                        '.Append("	 ,TotalItem ='" & Grid_1.Cell(i, 9).Text & "'	")
                        .Append("	WHERE stiching_Id ='" & Grid_1.Cell(i, 2).Text & "' ")
                        .Append("	AND MasterCode='" & Txt_Master_code.Text & "'")
                        .Append("	AND DressStatus='" & "Stiching Department" & "'")

                    End With
                    sqL = _strQuery.ToString
                    sql_Data_Save_Delete_Update()
                ElseIf Grid_1.Cell(i, 5).Text = "Trial Dress Recived In Store Room" Then
                    Dim ENTRY_NO As Integer = 0
                    Dim _BOOKCODE As String = "0001-000000029"
                    Dim _BOOKTRTYPE As String = "TRL29"
                    Dim _STICHID As String = Grid_1.Cell(i, 2).Text
                    Dim _ITMQTY As String = Grid_1.Cell(i, 6).Text
                    Dim _ITMCODE As String = Grid_1.Cell(i, 7).Text
                    Dim _MOBILE As String = Grid_1.Cell(i, 8).Text
                    Dim _CUSTOMERNAME As String = Grid_1.Cell(i, 3).Text
                    Dim _DRESSSTATS As String = Grid_1.Cell(i, 5).Text
                    Dim _TotalItem As String = Grid_1.Cell(i, 4).Text


                    sqL = " SELECT TOP 1 ENTRYNO FROM STC_TrnStichingDetail WHERE BOOKCODE='" & _BOOKCODE & "' ORDER BY ENTRYNO DESC "
                    sql_connect_slect()
                    If DefaltSoftTable.Rows.Count > 0 Then
                        ENTRY_NO = Val(DefaltSoftTable.Rows(0).Item(0)) + 1
                    End If
                    Dim _BookVNo As String = Generate_Book_Vno(Val(ENTRY_NO), _BOOKTRTYPE)


                    Dim _strQuery3 As New StringBuilder
                    With _strQuery3
                        .Append("	Select c.*, 	")
                        .Append("	C.BookVno 	")
                        .Append("	,C.stiching_Id as  [Stich ID]	")
                        .Append("	,C.CustomerName  AS [Customer Name] 	")
                        .Append("	,C.TOTALITEM as [Stich Item]	")
                        .Append("	,C.MOBILE,'' as NewDressItem ,D.STICH_ITEM_NAME	")
                        .Append("	FROM 	")
                        .Append("	STC_TrnStichingDetail C	,STC_MstStichingItem d ")
                        .Append("	WHERE 1=1 	")
                        .Append("	AND C.StichingItemCode =D.STICHITEM_ID	")
                        .Append("  AND C.stiching_Id ='" & _STICHID & "'  ")
                    End With
                    sqL = _strQuery3.ToString
                    sql_connect_slect()
                    _Iddatatable.Clear()
                    _Iddatatable = DefaltSoftTable.Copy






                    ' load data selectd id group wise++++++++++++++++++++++++++++++++
                    Dim _nstrQuery1 = New StringBuilder
                    With _nstrQuery1
                        .Append(" 	SELECT	  ")
                        .Append(" 	C.GROUP_ID AS ITM_CODE1	  ")
                        .Append(" 	,C.GROUP_NAME AS ITM1	  ")
                        .Append(" 	,SUM (A.QTY) AS QTY1	  ")
                        .Append(" 	,E.GROUP_ID AS ITM_CODE2	  ")
                        .Append(" 	,E.GROUP_NAME AS ITM2	  ")
                        .Append(" 	,SUM (A.QTY) AS QTY2	  ")
                        .Append(" 	,G.GROUP_ID AS ITM_CODE3	  ")
                        .Append(" 	,G.GROUP_NAME AS ITM3	  ")
                        .Append(" 	,SUM (A.QTY) AS QTY3	  ")
                        .Append(" 	FROM	  ")
                        .Append(" 	STC_TrnStichingDetail A	  ")
                        .Append(" 	,STC_MstStichingItem B	  ")
                        .Append(" 	,STC_MstStichingItemGroup C	  ")
                        .Append(" 	,STC_MstStichingItem D	  ")
                        .Append(" 	,STC_MstStichingItemGroup E	  ")
                        .Append(" 	,STC_MstStichingItem F	  ")
                        .Append(" 	,STC_MstStichingItemGroup G	  ")
                        .Append(" 	WHERE 1=1	  ")
                        .Append(" 	AND A.StichingItemCode=B.STICHITEM_ID	  ")
                        .Append(" 	AND B.UNDER_GRP_1_ID=C.GROUP_ID	  ")
                        .Append(" 	AND A.StichingItemCode=D.STICHITEM_ID	  ")
                        .Append(" 	AND D.UNDER_GRP_2_ID=E.GROUP_ID	  ")
                        .Append(" 	AND A.StichingItemCode=F.STICHITEM_ID	  ")
                        .Append(" 	AND F.UNDER_GRP_3_ID=G.GROUP_ID	  ")
                        .Append(" 	AND A.STICHING_ID='" & _STICHID & "'	  ")
                        .Append(" 	GROUP BY C.GROUP_ID,C.GROUP_NAME,E.GROUP_NAME,E.GROUP_ID,G.GROUP_NAME,G.GROUP_ID	  ")
                        .Append(" 	ORDER BY  C.GROUP_NAME,E.GROUP_NAME,G.GROUP_NAME	  ")
                    End With

                    sqL = _nstrQuery1.ToString
                    sql_connect_slect()
                    Dim _TMPTBL As New DataTable
                    _TMPTBL = DefaltSoftTable.Copy

                    Dim _strQuery1 As New StringBuilder
                    With _strQuery1
                        .Append("	Select GROUP_ID,GROUP_NAME as [Item],0 AS [Book Qty],0 as [Rec Qty],0 as [Bal Qty]	")
                        .Append("	FROM STC_MstStichingItemGroup 	")
                        .Append("	ORDER BY  GROUP_NAME	")
                    End With
                    sqL = _strQuery1.ToString
                    sql_connect_slect()
                    Dim _GROUPTBL As New DataTable
                    _GROUPTBL = DefaltSoftTable.Copy

                    For Each dr As DataRow In _TMPTBL.Select
                        For Each dr1 As DataRow In _GROUPTBL.Select
                            If dr("ITM_CODE1") = dr1("GROUP_ID") Then
                                If dr("ITM_CODE1") <> "0000-000000001" Then
                                    dr1("Book Qty") = dr1("Book Qty") + dr("QTY1")
                                End If
                            End If

                            If dr("ITM_CODE2") = dr1("GROUP_ID") Then
                                If dr("ITM_CODE2") <> "0000-000000001" Then
                                    dr1("Book Qty") = dr1("Book Qty") + dr("QTY2")
                                End If
                            End If

                            If dr("ITM_CODE3") = dr1("GROUP_ID") Then
                                If dr("ITM_CODE3") <> "0000-000000001" Then
                                    dr1("Book Qty") = dr1("Book Qty") + dr("QTY3")
                                End If
                            End If
                        Next
                    Next
                    ' finish load data selectd id group wise++++++++++++++++++++++++++++++++







                    ' load Grid wise id group wise item ++++++++++++++++++++++++++++++++
                    Dim _recivedstrQuery = New StringBuilder
                    With _recivedstrQuery
                        .Append(" 	SELECT	  ")
                        .Append(" 	C.GROUP_ID AS ITM_CODE1	  ")
                        .Append(" 	,C.GROUP_NAME AS ITM1	  ")
                        .Append(" 	,0 as 	QTY1  ")
                        .Append(" 	,E.GROUP_ID AS ITM_CODE2	  ")
                        .Append(" 	,E.GROUP_NAME AS ITM2	  ")
                        .Append(" 	,0 as 	QTY2  ")
                        .Append(" 	,G.GROUP_ID AS ITM_CODE3	  ")
                        .Append(" 	,G.GROUP_NAME AS ITM3	  ")
                        .Append(" 	,0 as 	QTY3  ")
                        .Append(" 	FROM	  ")
                        .Append(" 	 STC_MstStichingItem B	  ")
                        .Append(" 	,STC_MstStichingItemGroup C	  ")
                        .Append(" 	,STC_MstStichingItem D	  ")
                        .Append(" 	,STC_MstStichingItemGroup E	  ")
                        .Append(" 	,STC_MstStichingItem F	  ")
                        .Append(" 	,STC_MstStichingItemGroup G	  ")
                        .Append(" 	WHERE 1=1	  ")
                        .Append(" 	AND B.UNDER_GRP_1_ID=C.GROUP_ID	  ")
                        .Append(" 	AND D.UNDER_GRP_2_ID=E.GROUP_ID	  ")
                        .Append(" 	AND F.UNDER_GRP_3_ID=G.GROUP_ID	  ")
                        .Append(" 	AND B.STICHITEM_ID='" & _ITMCODE & "'	  ")
                        .Append(" 	AND D.STICHITEM_ID='" & _ITMCODE & "'	  ")
                        .Append(" 	AND F.STICHITEM_ID='" & _ITMCODE & "'	  ")
                        .Append(" 	AND B.MASTER_ID='" & Txt_Master_code.Text & "'	  ")
                        .Append(" 	AND D.MASTER_ID='" & Txt_Master_code.Text & "'	  ")
                        .Append(" 	AND F.MASTER_ID='" & Txt_Master_code.Text & "'	  ")
                        .Append(" 	GROUP BY C.GROUP_ID,C.GROUP_NAME,E.GROUP_NAME,E.GROUP_ID,G.GROUP_NAME,G.GROUP_ID	  ")
                        .Append(" 	ORDER BY  C.GROUP_NAME,E.GROUP_NAME,G.GROUP_NAME	  ")
                    End With

                    sqL = _recivedstrQuery.ToString
                    sql_connect_slect()
                    Dim _RecivedTmpTable As New DataTable
                    _RecivedTmpTable = DefaltSoftTable.Copy

                    For Each dr As DataRow In _RecivedTmpTable.Select
                        If dr("ITM_CODE1") <> "0000-000000001" Then
                            dr("QTY1") = _ITMQTY
                        End If
                        If dr("ITM_CODE2") <> "0000-000000001" Then
                            dr("QTY2") = _ITMQTY
                        End If
                        If dr("ITM_CODE3") <> "0000-000000001" Then
                            dr("QTY4") = _ITMQTY
                        End If
                    Next

                    For Each dr As DataRow In _GROUPTBL.Select
                        For Each dr1 As DataRow In _RecivedTmpTable.Select
                            If dr1("ITM_CODE1") = dr("GROUP_ID") Then
                                dr("REC Qty") = dr1("QTY1")
                            End If
                            If dr1("ITM_CODE2") = dr("GROUP_ID") Then
                                dr("REC Qty") = dr1("QTY2")
                            End If
                            If dr1("ITM_CODE3") = dr("GROUP_ID") Then
                                dr("REC Qty") = dr1("QTY3")
                            End If

                        Next
                    Next
                    ' finis Grid wise id group wise item ++++++++++++++++++++++++++++++++









                    ' CHECK TRIAL & RECIVED QTY IN STORE ROOM ++++++++++++++++++++++++++++++++
                    Dim CHECKTRIAL = New StringBuilder
                    With CHECKTRIAL
                        .Append(" 	SELECT	  ")
                        .Append(" 	C.GROUP_ID AS ITM_CODE1	  ")
                        .Append(" 	,C.GROUP_NAME AS ITM1	  ")
                        .Append(" 	,SUM (A.QTY) AS QTY1	  ")
                        .Append(" 	,E.GROUP_ID AS ITM_CODE2	  ")
                        .Append(" 	,E.GROUP_NAME AS ITM2	  ")
                        .Append(" 	,SUM (A.QTY) AS QTY2	  ")
                        .Append(" 	,G.GROUP_ID AS ITM_CODE3	  ")
                        .Append(" 	,G.GROUP_NAME AS ITM3	  ")
                        .Append(" 	,SUM (A.QTY) AS QTY3	  ")
                        .Append(" 	FROM	  ")
                        .Append(" 	STC_TrnStichingDetail A	  ")
                        .Append(" 	,STC_MstStichingItem B	  ")
                        .Append(" 	,STC_MstStichingItemGroup C	  ")
                        .Append(" 	,STC_MstStichingItem D	  ")
                        .Append(" 	,STC_MstStichingItemGroup E	  ")
                        .Append(" 	,STC_MstStichingItem F	  ")
                        .Append(" 	,STC_MstStichingItemGroup G	  ")
                        .Append(" 	WHERE 1=1	  ")
                        .Append(" 	AND A.StichingItemCode=B.STICHITEM_ID	  ")
                        .Append(" 	AND B.UNDER_GRP_1_ID=C.GROUP_ID	  ")
                        .Append(" 	AND A.StichingItemCode=D.STICHITEM_ID	  ")
                        .Append(" 	AND D.UNDER_GRP_2_ID=E.GROUP_ID	  ")
                        .Append(" 	AND A.StichingItemCode=F.STICHITEM_ID	  ")
                        .Append(" 	AND F.UNDER_GRP_3_ID=G.GROUP_ID	  ")
                        .Append(" 	AND A.STICHING_ID='" & _STICHID & "'	  ")
                        .Append(" 	AND A.DressStatus IN ('Delevered To Customer','Trial Dress Recived In Store Room','Dress In Store Room')  ")
                        .Append(" 	GROUP BY C.GROUP_ID,C.GROUP_NAME,E.GROUP_NAME,E.GROUP_ID,G.GROUP_NAME,G.GROUP_ID	  ")
                        .Append(" 	ORDER BY  C.GROUP_NAME,E.GROUP_NAME,G.GROUP_NAME	  ")
                    End With

                    sqL = CHECKTRIAL.ToString
                    sql_connect_slect()
                    Dim _CHECKTRIALTMPTBL As New DataTable
                    _CHECKTRIALTMPTBL = DefaltSoftTable.Copy



                    For Each dr As DataRow In _CHECKTRIALTMPTBL.Select
                        For Each dr1 As DataRow In _GROUPTBL.Select
                            If dr("ITM_CODE1") = dr1("GROUP_ID") Then
                                If dr("ITM_CODE1") <> "0000-000000001" Then
                                    dr1("REC Qty") = dr1("REC Qty") + dr("QTY1")
                                End If
                            End If

                            If dr("ITM_CODE2") = dr1("GROUP_ID") Then
                                If dr("ITM_CODE2") <> "0000-000000001" Then
                                    dr1("REC Qty") = dr1("REC Qty") + dr("QTY2")
                                End If
                            End If

                            If dr("ITM_CODE3") = dr1("GROUP_ID") Then
                                If dr("ITM_CODE3") <> "0000-000000001" Then
                                    dr1("REC Qty") = dr1("REC Qty") + dr("QTY3")
                                End If
                            End If
                        Next
                    Next
                    ' FINISH CHECK TRIAL & RECIVED QTY IN STORE ROOM ++++++++++++++++++++++++++++++++




                    Dim _Finaltbl As New DataTable
                    _Finaltbl = _GROUPTBL.Clone

                    For Each dr As DataRow In _GROUPTBL.Select
                        dr("Bal Qty") = dr("Book Qty") - dr("REC Qty")
                        If dr("Bal Qty") > 0 Then
                            _Finaltbl.ImportRow(dr)
                        End If
                    Next


                    Dim Itememark As String = ""
                    Dim mark As String = ""
                    For Each dr As DataRow In _Finaltbl.Select
                        If dr("Bal Qty") > 0 Then
                            Itememark = Itememark & mark & dr("Item") & "-" & dr("Bal Qty")
                        End If
                        mark = "; "
                    Next


                    'Dim _trialtbl As New DataTable
                    '_trialtbl = _Iddatatable.Copy
                    'For ii As Int16 = 1 To Grid_1.Rows - 1
                    '    For Each dr As DataRow In _trialtbl.Select
                    '        If Grid_1.Cell(ii, 7).Text = dr("STICHINGITEMCODE") Then
                    '            dr("QTY") = dr("QTY") - Val(_ITMQTY)
                    '        End If
                    '    Next
                    'Next



                    'Dim Itememark As String = ""
                    'Dim mark As String = ""
                    'For Each dr As DataRow In _trialtbl.Select
                    '    If dr("Qty") > 0 Then
                    '        Itememark = Itememark & mark & dr("STICH_ITEM_NAME") & "-" & dr("Qty")
                    '    End If
                    '    mark = "; "
                    'Next



                    Dim _BILLNO As String = _Iddatatable.Rows(0).Item("BILLNO")
                    Dim _nstrQuery2 As New StringBuilder
                    With _nstrQuery2
                        .Append("	Update  STC_TrnStichingDetail SET 	")
                        '.Append("	 DressStatus ='" & Grid_1.Cell(i, 5).Text & "'	")
                        '.Append("	 ,LastUpdateDate ='" & CUDATE & "'	")
                        '.Append("	 ,LastUpdateTime ='" & _time & "'	")
                        .Append("	 TotalItem ='" & Itememark & "'	")
                        .Append("	WHERE stiching_Id ='" & Grid_1.Cell(i, 2).Text & "' ")
                        .Append("	AND MasterCode='" & Txt_Master_code.Text & "'")
                        .Append("	AND DressStatus='" & "Stiching Department" & "'")

                    End With
                    sqL = _nstrQuery2.ToString
                    sql_Data_Save_Delete_Update()




                    Dim _strQuery As New StringBuilder
                    With _strQuery
                        .Append(" INSERT INTO  STC_TrnStichingDetail ( 	")
                        .Append("  ENTRYNO")
                        .Append(" ,BOOKTRTYPE")
                        .Append(" ,BOOKCODE")
                        .Append(" ,BOOKVNO")
                        .Append(" ,MasterCode")
                        .Append(" ,stiching_Id")
                        .Append(" ,StichingItemCode")
                        .Append(" ,Qty")
                        .Append(" ,Rate")
                        .Append(" ,PatternCharge")
                        .Append(" ,Amount")
                        .Append(" ,CustomerName")
                        .Append(" ,Mobile")
                        .Append(" ,Remark")
                        .Append(" ,DefatStichRate")
                        .Append(" ,FinalStichRate")
                        .Append(" ,DressStatus")
                        .Append(" ,TailorBillNo")
                        .Append(" ,TailorBillDate")
                        .Append(" ,TailorPayment")
                        .Append(" ,TotalItem")
                        .Append(" ,PaymentType")
                        .Append(" ,LastUpdateDate")
                        .Append(" ,LastUpdateTime")
                        .Append(" ,StichUniqueID")
                        .Append(" ,SNO ")
                        .Append(" ,BILLNO")
                        .Append(" ,Bill_Date")
                        .Append(" ,Trial_Date")
                        .Append(" ,Despatch_Date")
                        .Append(" ,Funcation_Date")

                        .Append("  ) ")
                        .Append("  VALUES (  ")
                        .Append("'" & ENTRY_NO & "'" & ",")
                        .Append("'" & _BOOKTRTYPE & "'" & ",")
                        .Append("'" & _BOOKCODE & "'" & ",")
                        .Append("'" & _BookVNo & "'" & ",")
                        .Append("'" & Txt_Master_code.Text & "'" & ",")
                        .Append("'" & _STICHID & "'" & ",")
                        .Append("'" & _ITMCODE & "'" & ",")
                        .Append("'" & _ITMQTY & "'" & ",")
                        .Append("'" & 0 & "'" & ",")
                        .Append("'" & 0 & "'" & ",")
                        .Append("'" & 0 & "'" & ",")
                        .Append("'" & _CUSTOMERNAME & "'" & ",")
                        .Append("'" & _MOBILE & "'" & ",")
                        .Append("'" & "" & "'" & ",")
                        .Append("'" & 0 & "'" & ",")
                        .Append("'" & 0 & "'" & ",")
                        .Append("'" & _DRESSSTATS & "'" & ",")
                        .Append("'" & "" & "'" & ",")
                        .Append("'" & "" & "'" & ",")
                        .Append("'" & "" & "'" & ",")
                        .Append("'" & _TotalItem & "- " & _ITMQTY & "'" & ",")
                        .Append("'" & "" & "'" & ",")
                        .Append("'" & CUDATE & "'" & ",")
                        .Append("'" & _time & "'" & ",")
                        .Append("'" & 0 & "'" & ",")
                        .Append("'" & 1 & "'" & ",")
                        .Append("'" & _BILLNO & "'" & ",")
                        Date_Formate1 = _Iddatatable.Rows(0).Item("Bill_Date")
                        Date_Formate2 = _Iddatatable.Rows(0).Item("Trial_Date")
                        Date_Formate3 = _Iddatatable.Rows(0).Item("Despatch_Date")
                        Date_Formate4 = _Iddatatable.Rows(0).Item("Funcation_Date")
                        Date_Formate_set()
                        .Append("'" & Date_1 & "'" & ",")
                        .Append("'" & Date_2 & "'" & ",")
                        .Append("'" & Date_3 & "'" & ",")
                        .Append("'" & Date_4 & "'")
                        .Append(" ) ")
                    End With
                    sqL = _strQuery.ToString
                    sql_Data_Save_Delete_Update()
                End If
            End If
        Next

        MsgBox("Records Successfully Update", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")

        Grid_1.Column(6).Visible = False
        PnlTrial.Visible = False
        Clear_Grid(Grid_1, 2)
        RadioButton1.Checked = True
        LblItemDisplay.Text = ""
        LblCustomerName.Text = ""

        TxtIDno.Text = ""
        TxtMaster.Focus()
    End Sub
    Private Sub _lessReciveqty()




    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        Me.Dispose()
        'Main_MDI_Frm.TailoringToolStripMenuItem.ShowDropDown()
        'Main_MDI_Frm.RecivedStoreRoomToolStripMenuItem.Select()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Grid_1.Column(6).Visible = False
        PnlTrial.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PnlTrial.Visible = True

        Grid_1.Column(6).Visible = True
    End Sub

    Private Sub TxtTrialItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTrialItem.KeyPress
        Party_selection.txtSearch.Text = TxtTrialItem.Text
        sqL = " SELECT A.STICH_ITEM_NAME as [Item Name], '' as Remark ,A.STICHITEM_ID,A.STICHITEM_ID,A.STICHITEM_ID FROM STC_MstStichingItem A  WHERE MASTER_ID='" & Txt_Master_code.Text & "' ORDER BY A.STICH_ITEM_NAME"
        obj_Party_Selection.Single_List_Load_Data()

        TxtTrialItem.Text = MULTY_SELECTION_COLOUM_1_DATA
        Txt_Item_code.Text = MULTY_SELECTION_COLOUM_3_DATA
        TxtTrialQty.Focus()
        TxtTrialQty.SelectAll()
    End Sub

    Private Sub TxtTrialQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTrialQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtIDno.Focus()
            TxtIDno.SelectAll()
        End If
    End Sub

    Private Sub btn_XLExport_Click(sender As Object, e As EventArgs) Handles btn_XLExport.Click
        Try
            Dim Export_File_Name As String = ""

            Try
                If Grid_1.ExportToExcel(Export_File_Name, True, False) = True Then
                    MsgBox("Export Successfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                Else
                    MsgBox("Invalid File Name or File Path", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                End If
            Catch ex As Exception
                MsgBox("Invalid File Name or File Path", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
            End Try
            Grid_1.Focus()
            Grid_1.Select()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try
    End Sub

    Private Sub Grid_1_KeyDown(Sender As Object, e As KeyEventArgs) Handles Grid_1.KeyDown
        If e.KeyCode = Keys.Delete Then
            Grid_1.Locked = False
            Delete_Row(Grid_1)
        Else
            Grid_1.Locked = True
        End If
    End Sub
    Private Sub Delete_Row(ByVal GrdObj As FlexCell.Grid)
        GrdObj.Range(GrdObj.ActiveCell.Row, 0, GrdObj.ActiveCell.Row, GrdObj.Cols - 1).ClearText()
    End Sub

    Public Sub UploadSendWhatsUp(ByVal _SendNumber As String, ByVal _Message As String)
        Dim cache As Boolean = False
        Dim Message As String = _Message
        Dim MobileNo As String = _SendNumber
        Dim res As Boolean = False

        If MobileNo > "" Then
            If _whatsappselectionmode = "MANUAL" Then
                res = _WhatsappSending(MobileNo, Message, cache, "", 1)
            Else
                res = _WhatsappSending(MobileNo, Message, cache, "", 1)
            End If


            If res = True Then
                MessageBox.Show("WhatsApp Send Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("WhatsApp Send Faild", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MsgBox("WhatsApp Send Faild", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
        End If

    End Sub
    Public Function SendSMS(ByVal url As String) As Boolean
        Dim uploaded = False

        Try


            Dim client = New RestClient(url)
            Dim request As RestRequest = New RestRequest
            request.Method = 0
            request.AddHeader("content-type", "application/json")
            Dim response As RestResponse = client.Execute(request)
            Dim respons = response.Content
            If response.StatusCode = System.Net.HttpStatusCode.OK Then
                uploaded = True
            End If



            'Dim httpClient = New HttpClient()
            'Dim content = New MultipartFormDataContent()
            'Dim task = httpClient.GetAsync(url).ContinueWith(Function(t)
            '                                                     If t.Status = TaskStatus.RanToCompletion Then
            '                                                         Dim response = t.Result
            '                                                         If response.StatusCode = System.Net.HttpStatusCode.OK Then
            '                                                             uploaded = True
            '                                                         End If
            '                                                     End If
            '                                                 End Function)
            'task.Wait()
            'httpClient.Dispose()



        Catch ex As Exception
            uploaded = False
            Throw ex
        End Try

        Return uploaded
    End Function

End Class