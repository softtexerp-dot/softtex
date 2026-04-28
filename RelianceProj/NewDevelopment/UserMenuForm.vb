Imports System.Data.OleDb
Imports System.Text
Imports System.IO
Public Class UserMenuForm
    Private Topprevious_SubItem As ToolStripMenuItem
    Private FirstStep_SubItem As ToolStripMenuItem
    Private previous_SubItem As ToolStripMenuItem
    Private countShow As Integer = 0
    Dim menuformname As String = ""
    Private LastOpenedMenuPath As String = ""

    Private Sub UserMenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        previous_SubItem = Nothing
        Dim diffW As Integer = Me.Width - Me.ClientSize.Width
        Dim diffH As Integer = Me.Height - Me.ClientSize.Height
        Me.ClientSize = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height - diffH)
        Me.Location = New Point(-diffW / 2, 0)
        Dim n As Integer = Screen_Width - SidePanel.Width
        SidePanel.Height = Me.Height - 50
        SidePanel.Width = 316
        SidePanel.Location = New Point(n, Me.Location.Y + 33)
        GridControl1.Height = SidePanel.Height - 50
        GridControl1.Location = New Point(3, 43)
        MenuStrip1.Items.Clear()
        Dim _Query = New StringBuilder
        With _Query
            .Append("SELECT DISTINCT ")
            .Append("MenuTable.MenuId")
            .Append(",MenuTable.SUBID")
            .Append(",MenuTable.MenuPositionId")
            .Append(",MenuTable.MainMenuPositionId")
            .Append(",MenuTable.Menu")
            .Append(",MenuTable.OrderNo ")
            .Append(",MenuTable.Active_Status ")
            .Append(",MenuTable.MenuPosition ")
            .Append(",MenuTable.MenuIsSparate")
            .Append(",MenuTable.MainMenuName")
            .Append(",MenuTable.SelectForm")
            .Append(",UserMenu.MenuID As UsernMenuId")
            .Append(",MstUser.UserName")
            .Append(" FROM ( MenuTable")
            .Append(" Inner join UserMenu on MenuTable.MenuId=UserMenu.MenuId)")
            .Append(" Inner join MstUser on UserMenu.UserID=MstUser.User_ID")
            .Append(" WHERE 1=1 ")
            .Append(" And MenuTable.Active_Status='Y' ")
            .Append(" And UserMenu.UserID =1")
            .Append(" And MenuTable.Menu<>'-' ")
            .Append("order by MenuTable.MenuPositionId,MenuTable.OrderNo ")
        End With
        RS = _Query.ToString
        'MenuDesign_QueryLoad()
        SQLDBMENU_CONNECT()

        'Dim command As New OleDb.OleDbCommand(RS, MenuDesignConnection)
        'If MenuDesignConnection.State = ConnectionState.Closed Then
        '    MenuDesignConnection.Open()
        'End If
        Dim command As New OleDb.OleDbCommand(RS, MSA_CONN)
        If MSA_CONN.State = ConnectionState.Closed Then
            MSA_CONN.Open()
        End If
        Using reader As OleDbDataReader = command.ExecuteReader()
            Dim menuDictionary As New Dictionary(Of Integer, ToolStripMenuItem)
            While reader.Read()
                'Dim menuID As Integer = Convert.ToInt32(reader("MainId"))
                Dim menuID As Integer = Convert.ToInt32(reader("MenuId"))
                Dim parentMenuID As Object = If(IsDBNull(reader("MenuPositionId")), Nothing, Convert.ToInt32(reader("MenuPositionId")))
                'Dim parentMenuID As Object = If(IsDBNull(reader("MainMenuPositionId")), Nothing, Convert.ToInt32(reader("MainMenuPositionId")))
                'Dim menuName As String = reader("MenuName").ToString()
                Dim menuName As String = reader("Menu").ToString()
                Dim isSeparator As Boolean = Convert.ToBoolean(reader("MenuIsSparate"))
                'Dim SelectedFormName As String = reader("SelectedFormName").ToString()
                Dim SelectedFormName As String = reader("SelectForm").ToString()
                If isSeparator Then
                    Dim separator As New ToolStripSeparator()
                    If parentMenuID IsNot Nothing AndAlso menuDictionary.ContainsKey(CInt(parentMenuID)) Then
                        menuDictionary(CInt(parentMenuID)).DropDownItems.Add(separator)
                    End If
                Else
                    Dim newMenuItem As New ToolStripMenuItem(menuName)
                    newMenuItem.Tag = SelectedFormName
                    'newMenuItem.Tag = SelectedFormName & ":" & menuName
                    menuDictionary(menuID) = newMenuItem
                    AddHandler newMenuItem.Click, AddressOf MenuItem_Click
                    If parentMenuID <> 0 Then
                        If menuDictionary.ContainsKey(CInt(parentMenuID)) Then
                            menuDictionary(CInt(parentMenuID)).DropDownItems.Add(newMenuItem)
                        End If
                    Else
                        MenuStrip1.Items.Add(newMenuItem)
                    End If
                End If
            End While
        End Using
        'Connection close kar do
        'MenuDesignConnection.Close()
        MSA_CONN.Close()
        'ShortCutMenuLoad()
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As EventArgs)
        'Dim clickedMenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        'If clickedMenuItem.Tag > "" Then
        '    MessageBox.Show("You clicked: " & clickedMenuItem.Tag)
        'End If
        If Topprevious_SubItem Is Nothing Then
        Else
            If FirstStep_SubItem Is Nothing Then FirstStep_SubItem = sender
            Topprevious_SubItem = Nothing
        End If
        If Topprevious_SubItem Is Nothing Then Topprevious_SubItem = sender
        Dim mnuItem As ToolStripMenuItem
        mnuItem = sender
        previous_SubItem = sender
        If mnuItem.Tag <> "" Then
            Dim TagSplit As String()
            TagSplit = mnuItem.Tag.ToString.Split(":")
            Dim Frm_Name_For_Active As String = TagSplit(0)
            'Dim menuformname As String = TagSplit(1)
            Dim menuformname As String = ""
            Dim frm As New Form
            Dim asm = System.Reflection.Assembly.GetExecutingAssembly
            Dim myTypes As Type() = asm.GetTypes()
            For Each t As Type In myTypes
                If t.IsSubclassOf(GetType(System.Windows.Forms.Form)) AndAlso Frm_Name_For_Active = t.Name Then
                    frm = CType(Activator.CreateInstance(t), Form)
                    'frm.Show()
                End If
            Next
            If Frm_Name_For_Active.ToString.ToUpper = "COMPANY_CHANGE" Or Frm_Name_For_Active.ToString.ToUpper = "YEAR_CHANGE" Then
            Else
                frm.MdiParent = Me
            End If
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            If Frm_Name_For_Active.ToString.ToUpper = "COMPANY_CHANGE" Or Frm_Name_For_Active.ToString.ToUpper = "YEAR_CHANGE" Then
                frm.StartPosition = FormStartPosition.CenterScreen
            Else
                frm.StartPosition = FormStartPosition.Manual
            End If
            If Frm_Name_For_Active.ToString = "QuitWithBackup" Then
                Dim portfolioPath As String = My.Application.Info.DirectoryPath
                Dim Cur_Date As String = ""
                Dim Backup_Directory As String = Trim(Mid(portfolioPath, 1, 3)) + "SoftTex Agency Backup\" + Cur_Date
                If Not Directory.Exists(Backup_Directory) Then
                    Directory.CreateDirectory(Backup_Directory)
                End If
                Dim FILE_NAME As String = ""
                RS = "SELECT * FROM MstCompany "
                SQLDBMENU_CONNECT()
                Dim tbl As New DataTable
                tbl = DefaltSoftTable.Copy
                Dim Backup__OtherPcAddress As String = ""
                Dim _OtherPcAddress As String = ""
                For Each dr As DataRow In tbl.Select()
                    FILE_NAME = dr("Data_Folder_Name")
                    'Delete a file.  
                    If My.Computer.FileSystem.FileExists(Backup_Directory & "\" & FILE_NAME) Then
                        For i As Integer = 1 To 10
                            My.Computer.FileSystem.DeleteFile(Backup_Directory & "\" & FILE_NAME)
                            Exit For
                        Next
                    End If
                    sqL = ""
                    sqL = " backup database " & (dr("Data_Folder_Name") & "") & " to disk='" & Backup_Directory & "\" & (dr("Data_Folder_Name") & "") & "' "
                    sql_connect_slect()
                    If dr("COMP_CIN").ToString > Nothing Then
                        _OtherPcAddress = dr("COMP_CIN").ToString
                        Backup__OtherPcAddress = ((_OtherPcAddress)) + "SoftTex Agency Backup\"
                        If Not Directory.Exists(Backup__OtherPcAddress) Then
                            Directory.CreateDirectory(Backup__OtherPcAddress)
                        End If
                    End If
                Next
                If _OtherPcAddress > "" Then
                    My.Computer.FileSystem.CopyDirectory(Backup_Directory, Backup__OtherPcAddress, True)
                End If
                'Wait_Window_Hide()
                Close()
                Me.Dispose(True)
            ElseIf Frm_Name_For_Active.ToString = "QuitWithoutBackup" Then
                Close()
                Me.Dispose(True)
            Else
                If Frm_Name_For_Active.ToString.ToUpper = "COMPANY_CHANGE" Or Frm_Name_For_Active.ToString.ToUpper = "YEAR_CHANGE" Then
                    frm.ShowDialog()
                Else
                    sqL = "SELECT Distinct(FormType) As FormType FROM FormControl where FormName='" & Frm_Name_For_Active & "' "
                    RS = sqL.ToString
                    MenuDesign_QueryLoad()
                    Dim tbl As New DataTable
                    tbl = DefaltSoftTable.Copy
                    If tbl.Rows.Count > 0 Then
                        menuformname = tbl.Rows(0)("FormType")
                    End If
                    If menuformname = "MASTER FORM" Then
                        Dim Loadfrm As New MainMasterFormRead()
                        Loadfrm.MainMasterLoadFormName = Frm_Name_For_Active.ToString()
                        ShowFormFromMenu(TryCast(sender, ToolStripMenuItem), Loadfrm)
                    ElseIf menuformname = "REPORT" Then
                        Dim Reportfrm As New ReportForm()
                        Reportfrm.ReportFormLoadFormName = Frm_Name_For_Active.ToString
                        ShowFormFromMenu(TryCast(sender, ToolStripMenuItem), Reportfrm)
                    ElseIf menuformname = "ENTRY FORM" Then
                        Dim Entryfrm As New MainFormRead()
                        Entryfrm.MainLoadFormName = Frm_Name_For_Active.ToString
                        ShowFormFromMenu(TryCast(sender, ToolStripMenuItem), Entryfrm)
                    End If
                End If
            End If
        End If
    End Sub
    'Private Sub ShortCutMenuLoad()
    '    Dim _Query = New StringBuilder
    '    With _Query
    '        .Append(" SELECT ")
    '        .Append(" A.MenuName as ShortCutMenu  ")
    '        .Append(" ,IIF(A.ShortCutKey >'', A.ShortCutControlKey & '-' &  A.ShortCutKey,A.ShortCutControlKey  ) as ShortKey  ")
    '        .Append(" ,A.MenuFormName ")
    '        .Append(" FROM ShortCutMenuTable as A ")
    '        .Append(" WHERE 1=1 ")
    '        .Append(" ORDER by MenuOrderNo ")
    '    End With
    '    RS = _Query.ToString
    '    MenuDesign_QueryLoad()
    '    'GridView2.Columns.Clear()
    '    GridControl1.DataSource = DefaltSoftTable.Copy
    '    GridView2.Appearance.Row.Font = New Font("Verdana", 10, FontStyle.Bold)
    '    GridView2.RowHeight = 29
    '    GridView2.OptionsView.ShowIndicator = False
    '    GridView2.BestFitColumns()
    '    GridView2.VertScrollVisibility = False
    '    GridView2.HorzScrollVisibility = False
    '    GridView2.OptionsMenu.EnableColumnMenu = False
    '    GridView2.Columns("MenuFormName").Visible = False
    '    For Each Col As DevExpress.XtraGrid.Columns.GridColumn In GridView2.Columns
    '        Col.AppearanceHeader.BackColor = Color.DarkGreen   'PrimaryDataGridViewColumnHeaderBackColor
    '        Col.AppearanceHeader.BackColor2 = Color.DarkGreen
    '        'Col.AppearanceHeader.ForeColor = PrimaryDataGridViewColumnHeaderForeColor
    '        Col.AppearanceHeader.Options.UseForeColor = True
    '        Col.AppearanceHeader.Options.UseBackColor = True
    '    Next
    '    SidePanel.Visible = True
    'End Sub

    Private Sub UserMenuForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim Last_Selected_Control As Control = Last_Focused_Control(Me)
            If Last_Selected_Control Is Nothing Then Exit Sub

            If Mid(Last_Selected_Control.Name, 1, 3).ToString.ToUpper = "BTN" Then
                SendKeys.Send("%")
                Exit Sub
            End If
        End If
    End Sub
    Public Function Last_Focused_Control(ByVal frmObject As Form) As Control
        Dim ThisControl As Object
        ThisControl = frmObject.ActiveControl
        'If ThisControl = "" Then ThisControl = "frmMain"
        Return ThisControl
    End Function

    Private Sub frmMainMenu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Dim activeChild As Form = Me.ActiveMdiChild
        If (activeChild Is Nothing) Then
            'Select_Previous_menu()
            ExpandFullMenuPath(previous_SubItem)
        End If
    End Sub

    Private Sub ExpandFullMenuPath(ByVal menuItem As ToolStripMenuItem)
        If menuItem Is Nothing Then Exit Sub
        ' Parent chain expand
        Dim parent As ToolStripMenuItem = TryCast(menuItem.OwnerItem, ToolStripMenuItem)
        If parent IsNot Nothing Then
            ExpandFullMenuPath(parent)
            parent.ShowDropDown()
        End If
        ' Finally show current item dropdown
        If menuItem.HasDropDownItems Then
            menuItem.ShowDropDown()
        End If
        menuItem.Select()
    End Sub

    Private Sub GridView2_Click(sender As Object, e As EventArgs) Handles GridView2.Click
        Dim Frm_Name_For_Active = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "MenuFormName").ToString()
        _ShowMdiFrom(Frm_Name_For_Active)
        previous_SubItem = Nothing
        Topprevious_SubItem = Nothing
        FirstStep_SubItem = Nothing
    End Sub
    Private Sub _ShowMdiFrom(ByVal _FormName As String)
        Dim frm As New Form
        Dim asm = System.Reflection.Assembly.GetExecutingAssembly
        Dim myTypes As Type() = asm.GetTypes()
        For Each t As Type In myTypes
            If t.IsSubclassOf(GetType(System.Windows.Forms.Form)) AndAlso _FormName = t.Name Then
                frm = CType(Activator.CreateInstance(t), Form)
                'frm.Show()
            End If
        Next
        frm.MdiParent = Me
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        'frm.StartPosition = FormStartPosition.Manual
        frm.Show()
    End Sub
#Region "Track Last Open Path"
    Public Sub TrackMenuPath(menuItem As ToolStripMenuItem)
        If menuItem Is Nothing Then Return
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
        LastOpenedMenuPath = String.Join(">", path)
    End Sub
    Public Sub RestoreMenuFocus(menuPath As String, menuStrip As MenuStrip)
        If String.IsNullOrWhiteSpace(menuPath) Then Exit Sub

        Dim pathParts = menuPath.Split(">"c)
        Dim currentItems As ToolStripItemCollection = menuStrip.Items
        Dim parentDropDown As ToolStripDropDownItem = Nothing
        Dim lastItem As ToolStripItem = Nothing

        For Each part As String In pathParts
            Dim foundItem As ToolStripItem = currentItems.
                OfType(Of ToolStripItem)().
                FirstOrDefault(Function(item) item.Text = part)

            If foundItem IsNot Nothing Then
                lastItem = foundItem
                If TypeOf foundItem Is ToolStripDropDownItem Then
                    parentDropDown = CType(foundItem, ToolStripDropDownItem)
                    parentDropDown.ShowDropDown()
                    currentItems = parentDropDown.DropDownItems
                    parentDropDown.Select()
                Else
                    foundItem.Select()
                End If
            End If
        Next
        LastOpenedMenuPath = ""
    End Sub
#End Region
End Class