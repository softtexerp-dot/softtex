Imports DevExpress.XtraEditors

Public Class UC_Buttons
    Public Event AddClick()
    Public Event EditClick()
    Public Event SaveClick()
    Public Event BackClick()
    Public Event NextClick()
    Public Event CloseClick()
    Public Event DeleteClick()
    Public Event ViewClick()
    Public Event PrintClick()
    Public Event ReportsClick()
    Private ReadOnly ButtonOrder As String() = {"BtnAdd", "BtnEdit", "BtnBack", "BtnNext", "BtnDelete", "BtnView", "BtnSave", "BtnPrint", "BtnReports", "BtnClose"}

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        RaiseEvent AddClick()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        RaiseEvent EditClick()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        RaiseEvent SaveClick()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        RaiseEvent BackClick()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        RaiseEvent NextClick()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        RaiseEvent DeleteClick()
    End Sub
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        RaiseEvent ViewClick()
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        RaiseEvent PrintClick()
    End Sub

    Private Sub BtnReports_Click(sender As Object, e As EventArgs) Handles BtnReports.Click
        RaiseEvent ReportsClick()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        RaiseEvent CloseClick()
    End Sub

    Private Sub UC_Buttons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.AutoSize = False
                btn.Width = 90     ' FIXED SIZE
                btn.Height = 36
                btn.Dock = DockStyle.None
                btn.Anchor = AnchorStyles.Left Or AnchorStyles.Top
            End If
        Next
    End Sub

    Public Sub HideButtons(ParamArray names() As String)
        For Each btnName In names
            Dim btn As DevExpress.XtraEditors.SimpleButton =
            TryCast(Me.Controls(btnName), DevExpress.XtraEditors.SimpleButton)

            If btn IsNot Nothing Then
                btn.Visible = False
            End If
        Next

        RearrangeButtons()
    End Sub



    Private Sub HideButtonsRecursive(parent As Control, names() As String)
        For Each ctrl As Control In parent.Controls

            ' DevExpress SimpleButton check
            If TypeOf ctrl Is SimpleButton Then
                If names.Contains(ctrl.Name, StringComparer.OrdinalIgnoreCase) Then
                    ctrl.Visible = False
                End If
            End If

            ' nested controls check
            If ctrl.HasChildren Then
                HideButtonsRecursive(ctrl, names)
            End If

        Next
    End Sub

    Public Sub RearrangeButtons()
        Dim leftPos As Integer = 5
        Dim spacing As Integer = -1

        For Each btnName In ButtonOrder
            Dim btn As DevExpress.XtraEditors.SimpleButton =
                TryCast(Me.Controls(btnName), DevExpress.XtraEditors.SimpleButton)

            If btn IsNot Nothing AndAlso btn.Visible Then
                btn.Left = leftPos
                leftPos += btn.Width + spacing
            End If
        Next
    End Sub
    Public Sub SetButtonsEnabled(enabledButtons As String())
        For Each btnName In ButtonOrder
            Dim btn As DevExpress.XtraEditors.SimpleButton =
            TryCast(Me.Controls(btnName), DevExpress.XtraEditors.SimpleButton)

            If btn IsNot Nothing Then
                If enabledButtons.Contains(btnName) Then
                    btn.Enabled = True
                Else
                    btn.Enabled = False
                End If
            End If
        Next
    End Sub

    Public Sub _ButtonEnableDisable(ByVal _FormModeEnable)
        If _FormModeEnable = "ADD" Then
            SetButtonsEnabled({"BtnSave", "BtnClose"})
        ElseIf _FormModeEnable = "EDIT" Then
            SetButtonsEnabled({"BtnBack", "BtnNext", "BtnSave", "BtnClose"})
        ElseIf _FormModeEnable = "DELETE" Then
            SetButtonsEnabled({"BtnClose"})
        Else
            SetButtonsEnabled({"BtnAdd", "BtnEdit", "BtnDelete", "BtnView", "BtnPrint", "BtnReports", "BtnClose"})
        End If
    End Sub
    Public Sub Set_Focus_Last_Clicked_Btn(ByVal Last_Focused_Name As String)

        If Last_Focused_Name = "ADD" Then
            BtnAdd.Focus()
        ElseIf Last_Focused_Name = "EDIT" Then
            BtnEdit.Focus()
        ElseIf Last_Focused_Name = "DELETE" Then
            BtnDelete.Focus()
        ElseIf Last_Focused_Name = "VIEW" Then
            BtnView.Focus()
        ElseIf Last_Focused_Name = "SAVE" Then
            BtnAdd.Focus()
        ElseIf Last_Focused_Name = "LOAD" Then
            BtnAdd.Focus()
        End If
    End Sub
End Class
