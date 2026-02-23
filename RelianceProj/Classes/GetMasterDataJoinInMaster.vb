Imports DevExpress.CodeParser

Module GetMasterDataJoinInMaster
    Public Class JoinResult
        Public Property LeftJoin As String
        Public Property JoinHeader As String
    End Class

    Public Function GetAccountMaster(_DatabaseHeaderName As String, _OppositCode As String, _SelectionMastrName As String) As JoinResult

        Dim result As New JoinResult()

        If _SelectionMastrName = "ACCOUNT MASTER" Then
            result.JoinHeader = ",MstMasterAccount.Accountname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstMasterAccount ON A." & _OppositCode & " = MstMasterAccount.ACCOUNTCODE"
        ElseIf _SelectionMastrName = "AGENT MASTER" Then
            result.JoinHeader = ",MstMasterAccount.Accountname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstMasterAccount ON A." & _OppositCode & " = MstMasterAccount.ACCOUNTCODE"
        End If


        Return result
    End Function


End Module
