Imports System.Text

Public Class NewSelectionListQuery
    Public _strQuery As StringBuilder

#Region "Master Account Query"
    Public Function MstMasterAccount_Select(ByVal FilterString As String)
        _strQuery = New StringBuilder

        Try
            Dim BookGroupCode As String = ""
            Dim Str_In_BookGroupCode As String = ""

            sqL = "SELECT Group_Code_Filter_String  FROM MstBook WHERE BookCode='" & party_selection_book_code & "'"
            ConnDB()
            cmd = New SqlClient.SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Do While dr.Read = True
                BookGroupCode = Replace(dr("Group_Code_Filter_String").ToString, "'", "'")
            Loop
            cmd.Dispose()
            dr.Close()
            conn.Close()

            If BookGroupCode <> "" Then
                If (BookGroupCode).ToString.Trim.Length = 18 Then
                    Str_In_BookGroupCode = " AND A.GROUPCODE='" & Mid((BookGroupCode).ToString, 3, 14) & "' "
                Else
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "'", "'")
                    Str_In_BookGroupCode = " AND A.GROUPCODE IN " & Replace((BookGroupCode).ToString, "#", "'")
                End If
            End If
            If Str_In_BookGroupCode > "" Then Str_In_BookGroupCode = Str_In_BookGroupCode & " OR A.GROUPCODE ='0000-000000029'"

            With _strQuery
                .Append("SELECT")
                '.Append(" 'False' as TickMark,  ")
                .Append(" A.AccountName,")
                .Append(" B.CityName,")
                .Append(" A.ACCOUNTCODE,")
                .Append(" A.GROUPCODE,")
                .Append(" D.ACCOUNTNAME AS AgentName, ")
                .Append(" IIF(D.OP3='YES','YES',a.OP3) AS BlackList ")
                .Append(" FROM MstMasterAccount AS A ")
                .Append(" LEFT JOIN MSTCITY AS B ON B.CITYCODE = A.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS D ON D.ACCOUNTCODE = A.AGENTCODE ")
                .Append(" WHERE 1=1 ")
                .Append(Str_In_BookGroupCode)
                .Append(FilterString)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.AccountName")
            End With

            Str_In_BookGroupCode = ""
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString
    End Function

    Public Function MstYarnGroup_Single(ByVal FilterString As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" A.YarnTypeName AS YarnGroupName ")
                .Append(" ,'' as Remark ")
                .Append(" ,A.YarnTypeCode AS ACCOUNTCODE  ")
                .Append("  FROM MstYarnType A  ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.YarnTypeName ")
            End With
            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return _strQuery.ToString
    End Function
    Public Function MstStoreItem_Select(ByVal FilterString As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" A.ItemName AS ItemName ")
                .Append(" ,A.HSNCode as HsnCode ")
                .Append(" ,A.PartNo ")
                .Append(" ,A.Goods_Type as Location ")
                .Append(" ,A.ItemCode AS ACCOUNTCODE  ")
                .Append("  FROM MstStoreItem A  ")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP7,'YES') <> 'NO' ")
                .Append(FilterString)
                .Append(" ORDER BY A.ItemName ")
            End With

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString
    End Function
    Public Function MULTY_storeItem_SELECTION(ByVal _GROUPCODE As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ItemName AS ItemName ")
                .Append(" ,A.HSNCode as HsnCode ")
                .Append(" ,A.PartNo ")
                .Append(" ,A.Goods_Type as Location ")
                .Append(" ,A.ItemCode AS ACCOUNTCODE  ")
                .Append("  FROM MstStoreItem A  ")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP7,'YES') <> 'NO' ")
                .Append(_GROUPCODE)
                .Append(" ORDER BY A.ItemName ")
            End With

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return _strQuery.ToString
    End Function

    Public Function MstBookSelection(ByVal _FilterString As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.BookName ")
                .Append(" ,A.Bookcategory  ")
                .Append(" ,A.BookCode AS ACCOUNTCODE  ")
                .Append("  FROM MstBook A  ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.ACTIVE_STATUS ='YES'  ")
                .Append(_FilterString)
                .Append(" ORDER BY ISNULL(a.BookOrder,0) ,A.BOOKCATEGORY,A.BookName ")
            End With

            GROUP_WISE_MULTY_PARTY_SELECT = ""
            party_selection_book_code = ""
            GroupCodeFiletrCode = ""

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
        Return _strQuery.ToString
    End Function
#End Region

#Region "Extra Query"
    Public Function MstMasterAccount_BalanceWise(ByVal FilterString As String)
        Dim _StrQuer = New StringBuilder
        Try

            With _StrQuer
                .Append(" SELECT ")
                .Append(" ISNULL(A.ACCOUNTNAME,'') as AccountName ")
                .Append(" ,ISNULL(B.CITYNAME,'') as CityName ")
                .Append(" ,ISNULL(A.ACCOUNTCODE ,'') AS ACCOUNTCODE ")
                .Append(" ,ISNULL(D.ACCOUNTNAME,'') as AgentName ")
                .Append(" ,(CASE WHEN ROUND(ABS(SUM(Z.BALANCE)), 2) = 0 THEN '' ELSE FORMAT(ABS(SUM(Z.BALANCE)), 'N2') END) AS [Balance] ")
                .Append(" ,IIF(SUM (Z.BALANCE)=0,'',CASE WHEN SUM (Z.BALANCE)>0 THEN 'Dr' ELSE 'Cr' END) as DC ")
                .Append(" ,IIF(D.OP3='YES','YES',a.OP3) AS BlackList ")
                .Append(" FROM ")
                .Append(" ( ")
                .Append(" SELECT ")
                .Append(" A.ACCOUNTCODE ")
                .Append(" ,0 AS BALANCE ")
                .Append(" ,'' AS DC ")
                .Append(" FROM ")
                .Append(" MstMasterAccount A ")
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" E.ACCOUNTCODE ")
                .Append(" ,(ISNULL (SUM(E.debitamt ),NULL) - ISNULL(SUM(E.creditamt ),NULL)) AS BALANCE ")
                .Append(" , CASE WHEN SUM(E.debitamt )>SUM(E.creditamt ) THEN 'Dr' ELSE 'Cr' END AS DC ")
                .Append(" FROM ")
                .Append(" TrnLedger E ")
                .Append(" GROUP BY ")
                .Append(" E.ACCOUNTCODE ")
                .Append(" ) AS Z ")
                .Append(" LEFT JOIN MstMasterAccount A ON Z.ACCOUNTCODE=A.ACCOUNTCODE ")
                .Append(" LEFT JOIN MSTCITY B ON A.CITYCODE=B.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount D ON A.AGENTCODE=D.ACCOUNTCODE ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" GROUP BY ")
                .Append(" A.ACCOUNTCODE ")
                .Append(" ,A.OP3 ")
                .Append(" ,A.ACCOUNTNAME ")
                .Append(" ,B.CITYNAME ")
                .Append(" ,D.ACCOUNTNAME ")
                .Append(" ,D.OP3 ")
                .Append(" ORDER BY A.ACCOUNTNAME ")
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _StrQuer.ToString
    End Function
#End Region
End Class
