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
                .Append(" 'False' as TickMark")
                .Append(" ,A.AccountName")
                .Append(" ,B.CityName")
                .Append(" ,A.ACCOUNTCODE")
                .Append(" ,A.GROUPCODE")
                .Append(" ,D.ACCOUNTNAME AS AgentName ")
                .Append(" ,IIF(D.OP3='YES','YES',a.OP3) AS BlackList ")
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


    Public Function MstMasterAccountvendorcode_Select(ByVal FilterString As String)
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
                .Append(" 'False' as TickMark")
                .Append(" ,A.AccountName")
                .Append(" ,B.CityName")
                'Vendor code
                .Append(" ,isnull(E.TRANSPORT_MASTER,'') As VendorCode")
                .Append(" ,A.ACCOUNTCODE")
                .Append(" ,A.GROUPCODE")
                .Append(" ,D.ACCOUNTNAME AS AgentName ")
                .Append(" ,IIF(D.OP3='YES','YES',a.OP3) AS BlackList ")
                .Append(" FROM MstMasterAccount AS A ")
                .Append(" LEFT JOIN MSTCITY AS B ON B.CITYCODE = A.CITYCODE ")
                .Append(" LEFT JOIN MstMasterAccount AS D ON D.ACCOUNTCODE = A.AGENTCODE ")
                'Vendor code Query
                .Append(" LEFT JOIN Vch_no AS E ON E.TRANSPORT_MASTER = A.OP133 ")
                .Append(" And E.Group_master_finance='VENDOR MASTER' ")
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

    Public Function SINGLE_ACC_OF_SELECTION(ByVal FilterString As String)
        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" Select ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.AC_NAME As [A/C Of] ")
                .Append(" , C.ACCOUNTNAME As [Party Name] ")
                .Append(" , A.ID As ACCOUNTCODE")
                .Append(" , A.ID")
                .Append(" , B.cityname As [City Name]")
                .Append(" FROM Mst_Acof_Supply A")
                .Append("  LEFT JOIN MstCity B  On A.CITY_CODE=B.citycode ")
                .Append("  LEFT JOIN MstMasterAccount As C  On  A.PART_NAME_ID=C.ACCOUNTCODE")
                .Append("  WHERE  1=1  ")
                .Append(FilterString)
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.AC_NAME")
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
    Public Function MstYarnGroup_Single(ByVal FilterString As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.YarnTypeName AS YarnGroupName ")
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
    Public Function Bill_Agent_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ACCOUNTNAME AS AgentName ")
                .Append(" ,B.GROUPNAME AS GroupName ")
                .Append(" ,A.ACCOUNTCODE ")
                .Append(" FROM MstMasterAccount A ")
                .Append(" INNER JOIN MstFinGroup B ON A.GROUPCODE = B.GROUPCODE ")
                .Append(" WHERE 1=1 ")
                .Append(" And A.GROUPCODE='0000-000000052'")
                .Append(FilterString)
                .Append(" ORDER BY A.ACCOUNTNAME ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_City_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append("  Select  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,B.cityname ")
                .Append(" ,A.StateName ")
                .Append(" ,B.citycode as ACCOUNTCODE")
                .Append(" from MstState As A , MstCity As B   ")
                .Append("  WHERE ")
                .Append("  A.stateid = B.STATEID ")
                .Append(FilterString)
                .Append("  ORDER BY B.cityname  ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_State_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,MSTS.StateName ")
                .Append(" ,MSTS.COUNTRY ")
                .Append(" ,CAST(MSTS.STATEID AS varchar) AS ACCOUNTCODE ")
                .Append(" FROM MstState AS MSTS ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY MSTS.StateName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_ITEM_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ITENNAME ")
                .Append(" ,A.HSNCODE")
                .Append(" ,A.ID as ACCOUNTCODE")
                .Append(" ,A.GROUPID")
                .Append(" FROM MstFabricItem A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP10,'YES')<>'NO'")
                .Append(GROUP_WISE_MULTY_PARTY_SELECT)
                .Append(" ORDER BY A.ITENNAME")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function

    Public Function SINGLE_DESIGN_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append("  Select ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.Design_Name as DesignName")
                .Append(" ,B.ITENNAME ")
                .Append(" ,A.Design_code as ACCOUNTCODE")
                .Append(" From Mst_Fabric_Design A ")
                .Append(" LEFT JOIN MstFabricItem B ON A.Item_Code=B.ID   ")
                .Append(" WHERE  1 = 1  ")
                .Append(FilterString)
                .Append(" ORDER BY A.Design_Name ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_SHADE_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" Select ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.SHADE As ShadeName ")
                .Append(" ,A.REMARK_COLOR As ShadeType")
                .Append(" ,A.Id as ACCOUNTCODE")
                .Append(" ,A.OP3 As Remark ")
                .Append(" ,A.OP11 As ExtraRate")
                .Append(" FROM Mst_Fabric_Shade A")
                .Append(" where 1=1 ")
                .Append(FilterString)
                '.Append(" ORDER BY  A.SHADE ")
                '.Append(" ORDER BY CASE WHEN A.SHADE NOT LIKE '%[^0-9]%' THEN CAST(A.SHADE AS INT) ELSE NULL END,A.SHADE")
                .Append(" ORDER BY TRY_CAST(LEFT(A.SHADE, PATINDEX('%[^0-9]%', A.SHADE + 'a') - 1) AS INT),A.SHADE")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_Selvedge_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.SELVEDGE_NAME as SelvedgeName")
                .Append(" ,B.ITENNAME as QualityName")
                .Append(" ,A.ID as ACCOUNTCODE")
                .Append(" FROM Mst_selvedge A LEFT JOIN MstFabricItem B ON A.item_code=B.ID")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" OR A.ID='0000-000000001' ")
                .Append(" ORDER BY SELVEDGE_NAME")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_Yarn_Type_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.YarnTypeName as YarnType")
                .Append(" ,'' as Remark")
                .Append(" ,A.YarnTypeCode As ACCOUNTCODE")
                .Append(" FROM MstYarnType A ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY YarnTypeName")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_YarnItem_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.CountName ")
                .Append(" ,A.HSNCode")
                .Append(" ,A.CountCode As ACCOUNTCODE")
                .Append(" FROM MstYarnCount A")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" AND ISNULL(A.OP4,'YES') <> 'NO' ")
                .Append(" ORDER BY A.CountName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_storeItem_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append("  SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ItemName as ItemName ")
                .Append(" ,B.GroupName as GroupName ")
                .Append(" ,A.ItemCode As ACCOUNTCODE")
                .Append(" ,A.OP10 As PartCode")
                .Append(" ,A.Descr ")
                .Append(" ,A.Hsncode ")
                .Append(" FROM ")
                .Append(" MstStoreItem A  ")
                .Append(" LEFT JOIN MstStoreItemGroup  as B  ON  A.ItemGroupCode=B.GroupCode")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP7,'YES') <> 'NO' ")
                '.Append(" AND A.ItemGroupCode=B.GroupCode ")
                .Append(FilterString)
                .Append(" ORDER BY A.ItemName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_store_Sub_Item_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append("  SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.SUBITEMNAME as SubItemName ")
                .Append(",'' as Remark")
                .Append(" ,A.subItemCode as ACCOUNTCODE")
                .Append(" FROM ")
                .Append(" MstStoreSubItem A  ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.SUBITEMNAME ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_size_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append("  SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.SizeName as SizeName ")
                .Append(",a.op1 as Remark")
                .Append(" ,A.SizeCode As ACCOUNTCODE")
                .Append(" FROM ")
                .Append(" MstSize AS A ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY a.op11,a.SizeName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_Color_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append("  SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.ColorName as ColorName")
                .Append(",'' as Remark")
                .Append(" ,A.ColorCode As ACCOUNTCODE")
                .Append(" FROM ")
                .Append(" MstColor AS A ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY a.ColorName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_Remark_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.RemarkName AS Remark ")
                .Append(" ,'' as OtherRemark  ")
                .Append(" ,A.RemarkCode As ACCOUNTCODE")
                .Append(" FROM MstRemark A ")
                .Append(" WHERE 1=1 AND ( Remark_For IN ('" & FilterString & "') ")
                .Append(" OR REMARKCODE='0000-000000001') ")
                .Append(" ORDER BY A.RemarkName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_process_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ACCOUNTNAME  ")
                .Append(" ,B.CITYNAME ")
                .Append(" , A.ACCOUNTCODE As ACCOUNTCODE ")
                .Append(" , A.GROUPCODE ")
                .Append(" ,D.ACCOUNTNAME AS AGENTNAME ")
                .Append(" FROM MstMasterAccount AS A, MSTCITY AS B, MSTFINGROUP AS C, MstMasterAccount AS D ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" AND (((A.CITYCODE)=[B].[CITYCODE])  AND ((A.GROUPCODE)=[C].[GROUPCODE])   AND ((A.AGENTCODE)=[D].[ACCOUNTCODE]) and (A.GROUPCODE ='0000-000000039')) ")

            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_Cut_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,CUTM.CUTNAME  ")
                .Append(" ,CUTM.CUTTYPE ")
                .Append(" , CUTM.ID As ACCOUNTCODE ")
                .Append(" FROM MstCutMaster As CUTM ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY CAST(CUTM.ORDERNO AS INT)")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_VENDORMASTER_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,VM.STATEMASTER As VendorName ")
                .Append(" , VM.TRANSPORT_MASTER As AccountCode")
                .Append(" FROM Vch_no As VM ")
                .Append(" WHERE 1=1 AND VM .Group_master_finance='VENDOR MASTER'")
                .Append(FilterString)
                .Append(" ORDER BY VM.Main_account_master")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function

    Public Function MstStoreItemType(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.TYPE_NAME As Company  ")
                .Append(" ,'' As Remark ")
                .Append(" , A.TYPE_ID As ACCOUNTCODE ")
                .Append(" FROM MstStoreItemType As A ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.TYPE_NAME")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function


    Public Function Single_STORE_DEPARTMENT_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.Departmentname as DepName")
                .Append(" ,a.Descr as Remark ")
                .Append(" , A.Departmentcode As ACCOUNTCODE ")
                .Append(" FROM MstDepartment As A ")
                .Append(" WHERE 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY Departmentname")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_POST_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,POSTNAME as Post ")
                .Append(" ,descr as Descr ")
                .Append(" ,A.POSTCODE As ACCOUNTCODE ")
                .Append(" FROM MSTPOST A ")
                .Append("  WHERE 1=1  ")
                .Append(FilterString)
                .Append("  ORDER BY A.POSTNAME ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_Employee_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.EMPNAME As EmployeeName ")
                .Append(" ,A.FATHERNAME as FatherName ")
                .Append(" ,A.EMPCODE As ACCOUNTCODE ")
                .Append(" ,B.PostName ")
                .Append(" ,A.EMPCODE ")
                .Append(" From MstEmployee A ")
                .Append(" left join MSTPOST as B ON A.PostCode=B.postcode ")
                .Append(" Where 1 = 1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.EMPNAME ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_Fabric_Item_Group_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.fabric_GroupName as GroupName ")
                .Append(" ,'' as Remark ")
                .Append(" ,A.ID As ACCOUNTCODE ")
                .Append(" From MstFabricGroup A ")
                .Append(" Where 1 = 1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.fabric_GroupName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_Godown_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.GodownName as GodownName")
                .Append(" ,'' as Remark ")
                .Append(" ,A.GodownCode As ACCOUNTCODE ")
                .Append(" From MstGodown A ")
                .Append(" Where 1 = 1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.GodownName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_GRADER_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append("  SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append("  ,A.GraderName   ")
                .Append("  , a.OP1 as MobileNo  ")
                .Append("  ,A.GraderCode As ACCOUNTCODE ")
                .Append("  from MstGrader as A   ")
                .Append(" Where 1 = 1 ")
                .Append(FilterString)
                .Append("  ORDER BY  A.GraderName ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_INSURANCE_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append("  SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.COMPANYNAME   ")
                '.Append("  ,A.POLICYNO  ")
                .Append("  ,A.ID As ACCOUNTCODE ")
                .Append("  from MstInsuranceCompany as A   ")
                .Append(" Where 1 = 1 and a.TOPUPCOMPANY is null")
                .Append(FilterString)
                .Append("  ORDER BY  A.COMPANYNAME ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_LoomNo_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,a.LOOMNO as LoomNo ")
                .Append(" ,a.rpm as RPM ")
                .Append(" ,a.LoomNoCode As ACCOUNTCODE")
                .Append(" FROM MSTLOOMNO as a ")
                .Append(" where 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY CAST(A.LOOMNO AS INT) ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function Single_SalesMan_Selection(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.salesmanname as Saleman ")
                .Append(" ,'' as Remark  ")
                .Append(" ,A.salesmancode As ACCOUNTCODE")
                .Append(" FROM MstSalesMan as a ")
                .Append(" where 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.salesmanname ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
    End Function
    Public Function SINGLE_TRANSPORT_SELECTION(ByVal FilterString As String)
        Dim _strQuery As New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.TRANSPORTNAME as TransportName ")
                .Append(" ,A.city as CityName  ")
                .Append(" ,A.ID As ACCOUNTCODE")
                .Append(" ,A.GSTIN AS [Gst No] ")
                .Append(" FROM MstTransport as a ")
                .Append(" where 1=1 ")
                .Append(FilterString)
                .Append(" ORDER BY A.TRANSPORTNAME ")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString()
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
    Public Function MstFabricItem_Select(ByVal FilterString As String)
        Dim _strQuery = New StringBuilder

        Try
            With _strQuery
                .Append(" SELECT ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ITENNAME AS ItemName ")
                .Append(" ,A.HSNCODE AS HsnCode ")
                .Append(" ,A.ID AS ACCOUNTCODE  ")
                .Append(" ,A.GROUPID AS GROUPCODE  ")
                .Append(" FROM MstFabricItem A ")
                .Append(" WHERE 1=1 ")
                .Append(" AND ISNULL(A.OP10,'YES')<>'NO'")
                .Append(FilterString)
                .Append(" ORDER BY A.ITENNAME")
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try

        Return _strQuery.ToString
    End Function

    Public Function MstInsuranceCompany_Select(ByVal FilterString As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.COMPANYNAME AS CompanyName ")
                .Append(" ,A.POLICYNO as PolicyNo ")
                .Append(" ,A.OP1 as DecNo ")
                .Append(" ,A.ID AS ACCOUNTCODE  ")
                .Append("  FROM MstInsuranceCompany A  ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.TOPUPCOMPANY is null ")
                .Append(FilterString)
                .Append(" ORDER BY A.COMPANYNAME ")
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
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ItemName AS ItemName ")
                .Append(" ,A.HSNCode as HsnCode ")
                .Append(" ,A.PartNo ")
                .Append(" ,A.Goods_Type as Location ")
                .Append(" ,B.DepartmentName")
                .Append(" ,A.ItemCode AS ACCOUNTCODE  ")
                .Append("  FROM MstStoreItem A  ")
                .Append("  LEFT JOIN MstDepartment AS B ON  A.OP8=B.DepartmentCode ")
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
    Public Function MstStoreItem_Select_AllActiveNonActive(ByVal FilterString As String)
        Dim _strQuery = New StringBuilder
        Try
            With _strQuery
                .Append(" SELECT  ")
                .Append(" 'False' as TickMark  ")
                .Append(" ,A.ItemName AS ItemName ")
                .Append(" ,A.HSNCode as HsnCode ")
                .Append(" ,A.PartNo ")
                .Append(" ,A.Goods_Type as Location ")
                .Append(" ,B.DepartmentName")
                .Append(" ,A.ItemCode AS ACCOUNTCODE  ")
                .Append("  FROM MstStoreItem A  ")
                .Append("  LEFT JOIN MstDepartment AS B ON  A.OP8=B.DepartmentCode ")
                .Append(" WHERE 1=1 ")
                '.Append(" AND ISNULL(A.OP7,'YES') <> 'NO' ")
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
    Public Function MstBookSelection(ByVal _FilterString As String, ByVal ShowAllStatus As Boolean)
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
                If ShowAllStatus = True Then
                    .Append(" AND A.ACTIVE_STATUS = 'YES' ")
                End If
                .Append(_FilterString)
                .Append(" ORDER BY ISNULL(a.OP95,0) ,A.BOOKCATEGORY,A.BookName ")
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
