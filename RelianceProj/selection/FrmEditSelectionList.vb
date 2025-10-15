Imports System.Data.SqlClient

Public Class FrmEditSelectionList
    Inherits System.Windows.Forms.Form
    Private Old_Col_No As Integer = 0
    Private listsource As String
    Private seekdata As String, cnt As Integer, pname As String, ln As Integer, rws As Integer, FOUND As Boolean
    Private t1 As TextBox
    Private t2 As Control
    'Private lst_title As String, RelatedFrmString As TypeClass.MASTERTYPE
    Private strt_row As Integer = 0
    Private end_row As Double
    Private find_dir As Integer = 1
    Private PreviousFormName As Form
    Private First_Char As Boolean

    Private OFORM As Form
    'Friend WithEvents lbl_Seek As System.Windows.Forms.Label
    'Friend WithEvents lbl_Total As System.Windows.Forms.Label
    'Friend WithEvents Grid1 As FlexCell.Grid
    Private List_For_Transaction As String = ""



#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    Public Sub New(ByRef ownerfrm As Form, ByVal Datasource As String, ByRef txtkdata As TextBox, ByRef txtVdata As Control, Optional ByVal lsttitle As String = " ", Optional ByVal List_For As String = "")
        MyBase.New()
        OFORM = ownerfrm
        listsource = Datasource
        t1 = txtkdata
        t2 = txtVdata
        seekdata = t2.Text
        'lst_title = lsttitle
        InitializeComponent()
        PreviousFormName = ownerfrm
        List_For_Transaction = List_For
    End Sub
#End Region

    Private Sub FrmEditSelectionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        Dim y As Integer
        x = Screen.PrimaryScreen.WorkingArea.Width - 650
        y = Screen.PrimaryScreen.WorkingArea.Height - 680
        Me.Location = New Point(x, y)

        lbl_Seek.Top = Me.Height - (lbl_Seek.Height + lbl_Seek.Height + 15)
        lbl_Total.Top = Me.Height - (lbl_Total.Height + lbl_Total.Height + 15)
        Grid1.Height = Me.Height - (lbl_Seek.Height + lbl_Seek.Height + lbl_Seek.Height)

        Call Fill_Help_Grid(Grid1, listsource)

        If Grid1.Rows < 2 Then
            Grid1.Rows = 2
        End If

        Grid1.Range(0, 0, 0, Grid1.Cols - 1).FontName = "Tahoma"
        Grid1.Range(0, 0, 0, Grid1.Cols - 1).FontBold = True
        Grid1.Range(0, 0, 0, Grid1.Cols - 1).FontSize = 11
        Grid1.Row(0).Height = 35
        Grid1.SelectionMode = FlexCell.SelectionModeEnum.ByCell
        Grid1.Column(1).Visible = False

        Grid1.Focus()
        Grid1.Select()
        Old_Col_No = Grid1.ActiveCell.Col


        Grid1.Column(4).Width = 100

        If List_For_Transaction = "DENIM WARPING" Then
            Grid1.Range(1, 1, 1, 1).SelectCells()
        Else
            Grid1.Range(1, 2, 1, 2).SelectCells()
        End If


        Grid1.Locked = True
        Grid1.Visible = True
    End Sub
    Private Sub Grid1_DoubleClick(ByVal Sender As Object, ByVal e As System.EventArgs) Handles Grid1.DoubleClick
        't2.Text = Trim(Grid1.Cell(Grid1.ActiveCell.Row, 2).Text)
        't1.Text = Grid1.Cell(Grid1.ActiveCell.Row, 1).Text
        'Me.Close()
    End Sub

    Private Sub grid1_KeyDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            t2.Text = Trim(Grid1.Cell(Grid1.ActiveCell.Row, 2).Text)
            t1.Text = Grid1.Cell(Grid1.ActiveCell.Row, 1).Text
            Zero_edit_invoice = 0
            Zero_edit_invoice = Grid1.Cell(Grid1.ActiveCell.Row, 3).Text
            For i As Int16 = 0 To Grid1.Cols - 1
                If i <= 10 Then
                    MultiReturnSelectionListArrayValues(i) = Grid1.Cell(Grid1.ActiveCell.Row, i).Text
                End If
            Next

            Me.Close()
            Me.Dispose()
        End If

        Dim Col_No As Integer = Grid1.ActiveCell.Col
        Dim oldValue As String = Trim(lbl_Seek.Text)
        Dim billnovalue As String = Trim(lbl_Seek.Text)
        Dim keytyped As Integer
        Dim typevalue As String = ""
        keytyped = e.KeyCode
        If e.KeyCode = 48 Then
            keytyped = "0"
            typevalue = "0"
        End If
        If e.KeyCode >= 49 And e.KeyCode <= 57 Then
            keytyped = keytyped - 48
            typevalue = keytyped
        End If
        If keytyped >= 96 And keytyped <= 105 Then
            keytyped = keytyped - 48
            typevalue = Chr(keytyped)
        ElseIf keytyped = 110 Or keytyped = 190 Then
            typevalue = "."
        ElseIf keytyped = 191 Or keytyped = 111 Then
            typevalue = "/"
        ElseIf keytyped = 109 Or keytyped = 189 Then
            typevalue = "-"
        ElseIf keytyped >= 65 And keytyped <= 90 Then
            keytyped = e.KeyCode
            typevalue = Chr(keytyped)
        ElseIf keytyped = 46 Then
            billnovalue = ""
            typevalue = ""
            lbl_Seek.Text = billnovalue
            If Grid1.Rows > 1 Then Grid1.Range(1, Col_No, 1, Col_No).SelectCells()
            Grid1.Focus()
            Grid1.Select()
            SendKeys.Send("{UP}")
        ElseIf keytyped = 8 Then
            If Len(Trim(billnovalue)) > 1 Then
                billnovalue = Mid(billnovalue, 1, Len(billnovalue) - 1)
                typevalue = ""
                lbl_Seek.Text = billnovalue
            Else
                billnovalue = ""
                typevalue = ""
                lbl_Seek.Text = billnovalue
                If Grid1.Rows > 1 Then Grid1.Range(1, Col_No, 1, Col_No).SelectCells()
                Grid1.Focus()
                Grid1.Select()
                SendKeys.Send("{UP}")
            End If
        End If

        If typevalue <> "" Then
            lbl_Seek.Text = Trim(billnovalue) + typevalue
            billnovalue = lbl_Seek.Text
            SeekOutsBills(billnovalue)
            If FOUND = False Then
                lbl_Seek.Text = oldValue
                billnovalue = oldValue
            Else
                oldValue = billnovalue
                Grid1.TopRow = Grid1.ActiveCell.Row
            End If
        End If
    End Sub
    Private Sub SeekOutsBills(ByVal seekvalue As String)
        Grid1.AutoRedraw = False
        Dim pname As String, ln As Integer, rws As Integer, cnt As Integer
        Dim Col_No As Integer = Grid1.ActiveCell.Col
        pname = Trim(seekvalue)
        ln = Len(pname)
        rws = Grid1.Rows
        FOUND = False

        For cnt = 1 To rws - 1
            If Grid1.Row(cnt).Visible = True Then
                If Mid(Grid1.Cell(cnt, Col_No).Text, 1, ln) = pname Then
                    Grid1.Range(cnt, Grid1.ActiveCell.Col, cnt, Grid1.ActiveCell.Col).SelectCells()
                    FOUND = True
                    Grid1.TopRow = cnt
                    Exit For
                End If
            End If
        Next

        If FOUND = False Then
            Beep()
            seekvalue = Mid(pname, 1, ln - 1)
        End If
        Grid1.Refresh()
        Grid1.AutoRedraw = True
    End Sub
    Private Sub grid1_RowColChange(ByVal Sender As Object, ByVal e As FlexCell.Grid.RowColChangeEventArgs) Handles Grid1.RowColChange
        If Old_Col_No <> Grid1.ActiveCell.Col Then
            lbl_Seek.Text = ""
            Old_Col_No = Grid1.ActiveCell.Col
        End If
    End Sub
    Private Sub FrmSelectionList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            t1.Text = ""
            t2.Text = ""
            e.Handled = True
            Me.Close()
        End If
    End Sub
    Private Sub Fill_Help_Grid(ByRef grd As Object, ByVal datasource As String)
        Dim i, j As Integer
        Dim tempDT As New DataTable

        Grid1.AutoRedraw = False

        ConnDB()
        cmd = New SqlClient.SqlCommand(datasource, conn)
        cmd.CommandType = CommandType.Text
        Dim ADP As New SqlDataAdapter(cmd)
        ADP.Fill(tempDT)
        cmd.Dispose()
        conn.Close()


        'dbConnect.Fill_Data_Tables(datasource, tempDT)



        grd.Rows = tempDT.Rows.Count + 1
        grd.Cols = tempDT.Columns.Count + 1
        grd.Column(0).Visible = False

        For j = 1 To tempDT.Columns.Count
            grd.Cell(0, j).Text = String_To_Proper(tempDT.Columns(j - 1).ColumnName)
        Next

        If tempDT.Rows.Count > 0 Then
            For i = 1 To tempDT.Rows.Count
                For j = 1 To tempDT.Columns.Count
                    If tempDT.Rows(i - 1).Item(j - 1).ToString <> "" Then
                        grd.Cell(i, j).Text = UCase(tempDT.Rows(i - 1).Item(j - 1))
                    End If
                Next
            Next
        End If

        If List_For_Transaction = "INVOICE" Then
            Grid1.Column(2).Width = 95
            Grid1.Column(3).Width = 90
            Grid1.Column(4).Width = 80
            Grid1.Column(5).Width = 165
            Grid1.Column(6).Width = 115

            Grid1.Column(1).Alignment = FlexCell.AlignmentEnum.LeftCenter
            Grid1.Column(2).Alignment = FlexCell.AlignmentEnum.LeftCenter
            Grid1.Column(3).Alignment = FlexCell.AlignmentEnum.LeftCenter
            Grid1.Column(4).Alignment = FlexCell.AlignmentEnum.LeftCenter
            Grid1.Column(5).Alignment = FlexCell.AlignmentEnum.LeftCenter
            Grid1.Column(6).Alignment = FlexCell.AlignmentEnum.RightCenter
            If Grid1.Cols > 6 Then
                For c As Int16 = 7 To Grid1.Cols - 1
                    Grid1.Column(c).Width = 120
                    Grid1.Column(c).Alignment = FlexCell.AlignmentEnum.LeftCenter
                    Grid1.Column(c).Visible = False
                Next
            End If
        ElseIf List_For_Transaction = "DENIM WARPING" Then
            For c As Int16 = 1 To Grid1.Cols - 1
                Grid1.Column(c).Width = 100
                Grid1.Column(c).Alignment = FlexCell.AlignmentEnum.LeftCenter
            Next
            'Grid1.Column(8).Visible = False
        End If
        Grid1.AutoRedraw = True
        Grid1.Refresh()
    End Sub
End Class