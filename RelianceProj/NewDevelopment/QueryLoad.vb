Imports System.Text

Public Class QueryLoad

    Private _FrmLoad As Boolean = True
    Private UC_Buttons1 As UC_Buttons
    Private Change_Grid_Data As Boolean = True
    Private _FORMMODE As String = ""

    Dim GetformName As String = ""

    Private Sub QueryLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Location = New Point(5, 0)
        _FrmLoad = True
        'GetformName = MainFormRead._getformName()
        'MsgBox(GetformName)
        CreateButtonsControl()
        Ctrl_Visible_False(Me.Controls)
        UC_Buttons1._ButtonEnableDisable("LOAD")
        AttachButtonFocusEvents(Me)
        _FrmLoad = False
    End Sub
    Private Sub CreateButtonsControl()

        UC_Buttons1 = New UC_Buttons()

        With UC_Buttons1
            .Name = "UC_Buttons1"
            .Dock = DockStyle.Bottom
            .Visible = True
        End With
        Me.Controls.Add(UC_Buttons1)
        UC_Buttons1.BringToFront()
        AddHandler UC_Buttons1.AddClick, AddressOf UC_Buttons1_AddClick
        AddHandler UC_Buttons1.EditClick, AddressOf UC_Buttons1_EditClick
        AddHandler UC_Buttons1.DeleteClick, AddressOf UC_Buttons1_DeleteClick
        AddHandler UC_Buttons1.SaveClick, AddressOf UC_Buttons1_SaveClick
        AddHandler UC_Buttons1.CloseClick, AddressOf UC_Buttons1_CloseClick
    End Sub
    Private Sub SamplerRateContract_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UC_Buttons1.HideButtons("BtnPrint", "BtnReports", "BtnBack", "BtnNext", "BtnView")
    End Sub
#Region "Button Click"
    Private Sub UC_Buttons1_AddClick()
        Change_Grid_Data = True
        _FORMMODE = "ADD"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "ADD" Then
            RTBQuery.Focus()
            'RTBQuery.Text = GetformName
            GetformName = MainFormRead._getformName()
        End If
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub
    Private Sub UC_Buttons1_EditClick()
        _FORMMODE = "EDIT"
        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "EDIT" Then
            RTBQuery.Focus()
        End If
        Change_Grid_Data = True
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub


    Private Sub UC_Buttons1_DeleteClick()

        _FrmLoad = True

        _FORMMODE = "DELETE"

        _FrmLoad = False
        Call Ctrl_Visible_True(Me.Controls)
        UC_Buttons1._ButtonEnableDisable(_FORMMODE)
        If _FORMMODE = "DELETE" Then
            RTBQuery.Focus()
        End If

        Change_Grid_Data = True
        UC_Buttons1.Set_Focus_Last_Clicked_Btn(_FORMMODE)
    End Sub

    Private Sub UC_Buttons1_SaveClick()
        RTBQuery.Focus()
        Dim folderPath As String = "D:\RelianceProj\RelianceProj\Setting"

        ' 🔹 Folder exist nahi kare to create karo
        If Not IO.Directory.Exists(folderPath) Then
            IO.Directory.CreateDirectory(folderPath)
        End If

        Dim safeFileName As String = String.Concat(GetformName.Split(IO.Path.GetInvalidFileNameChars()))
        Dim filePath As String = IO.Path.Combine(folderPath, safeFileName & ".ste")

        ' 🔹 1️⃣ Read (agar file exist kare)
        Dim oldContent As String = ""

        If IO.File.Exists(filePath) Then
            oldContent = IO.File.ReadAllText(filePath)
        End If

        ' 🔹 2️⃣ Replace (Overwrite)
        Dim newContent As String = "Form Name: " & GetformName & Environment.NewLine &
                            "Updated On: " & DateTime.Now.ToString()

        IO.File.WriteAllText(filePath, newContent)

        MessageBox.Show("File Save Successfully")
        UC_Buttons1._ButtonEnableDisable("LOAD")
        UC_Buttons1.Set_Focus_Last_Clicked_Btn("LOAD")

    End Sub
    Private Sub UC_Buttons1_CloseClick()

        If _FORMMODE = "" Then
            Me.Close()
            Exit Sub
        End If

        Me.Close()
        Me.Dispose(True)

    End Sub

    Private Sub Delete_Entry()
        _FrmLoad = True
        Dim I As Integer = 0
        Dim _LastID As Integer = 0
        _strQuery = New StringBuilder
        Try

            'strQuery = "DELETE FROM " & _TblName & " WHERE   BOOKCODE='" & _Bookcode & "'  AND EntryNo='" & EntryNO & "' "

            sqL = strQuery.ToString
            sql_connect_slect()
            '-----------------------------------------------------------------------
            '_FORMMODE = "ADD"
            MsgBox("Entry Successfully Deleted")
        Catch ex As Exception

            MsgBox("Error While Delete Entry")
        Finally
            cmd = Nothing
        End Try

        _FrmLoad = False
    End Sub

#End Region
End Class