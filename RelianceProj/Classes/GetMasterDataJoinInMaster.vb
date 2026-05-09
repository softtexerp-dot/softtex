
Imports System.Text

Module GetMasterDataJoinInMaster
    Public Class JoinResult
        Public Property LeftJoin As String
        Public Property JoinHeader As String
        Public Property MasterList As List(Of String) ' 👈 NEW

    End Class
    Public Property masterListcode1 As New List(Of Tuple(Of String, String, String))
    Public Property masterListcode2 As New List(Of Tuple(Of String, String, String))
    Public Property masterListcode3 As New List(Of Tuple(Of String, String, String))
    Public Property masterListcode4 As New List(Of Tuple(Of String, String, String))
    Public Property masterListcode5 As New List(Of Tuple(Of String, String, String))
    Public _UniqueValues As New List(Of Tuple(Of String, String, String))
    Public _DataTableGrid1 As New DataTable
    Public _DataTableGrid2 As New DataTable
    Public _DataTableGrid3 As New DataTable
    Public _DataTableGrid4 As New DataTable
    Public _DataTableGrid5 As New DataTable
    Public Function GetAccountMaster(_DatabaseHeaderName As String, _OppositCode As String, _SelectionMastrName As String) As JoinResult
        Dim result As New JoinResult()
        ' Master list help page par load niche wali list se hota h
        If _SelectionMastrName = "GET_LIST" Then
            result.MasterList = New List(Of String) From {
            "ACCOUNT MASTER",
            "AGENT MASTER",
            "CITY MASTER",
            "STATE MASTER",
            "FABRIC ITEM MASTER",
            "FABRIC DESIGN MASTER",
            "FABRIC SHADE MASTER",
            "FABRIC SELVEDGE MASTER",
            "YARN MASTER",
            "YARN SHADE MASTER",
            "GENRAL ITEM MASTER",
            "SUBITEM MASTER",
            "SIZE MASTER",
            "COLOR MASTER",
            "REMARK MASTER",
            "PROCESS MASTER",
            "CUT MASTER",
            "DEPARTMENT MASTER",
            "POST MASTER",
            "EMPLOYEE MASTER",
            "FABRIC GROUP MASTER",
            "GODOWN MASTER",
            "GRADER MASTER",
            "INSURANCE MASTER",
            "LOOMNO MASTER",
            "SALESMAN MASTER",
            "TRANSPORT MASTER",
            "BOOK MASTER"
        }
            Return result
        End If


        If _SelectionMastrName = "ACCOUNT MASTER" Then
            result.JoinHeader = ",MstMasterAccount.Accountname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstMasterAccount ON A." & _OppositCode & " = MstMasterAccount.ACCOUNTCODE"
        ElseIf _SelectionMastrName = "AGENT MASTER" Then
            result.JoinHeader = ",MstMasterAccount.Accountname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstMasterAccount ON A." & _OppositCode & " = MstMasterAccount.ACCOUNTCODE"
        ElseIf _SelectionMastrName = "CITY MASTER" Then
            result.JoinHeader = ",MstCity.Cityname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstCity ON A." & _OppositCode & " = MstCity.citycode"
        ElseIf _SelectionMastrName = "STATE MASTER" Then
            result.JoinHeader = ",MstState.StateName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstState ON A." & _OppositCode & " = MstState.STATEID"
        ElseIf _SelectionMastrName = "FABRIC ITEM MASTER" Then
            result.JoinHeader = ",MstFabricItem.ITENNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstFabricItem ON A." & _OppositCode & " = MstFabricItem.ID"
        ElseIf _SelectionMastrName = "FABRIC DESIGN MASTER" Then
            result.JoinHeader = ",Mst_Fabric_Design.Design_Name as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN Mst_Fabric_Design ON A." & _OppositCode & " = Mst_Fabric_Design.Design_code"
        ElseIf _SelectionMastrName = "FABRIC SHADE MASTER" Then
            result.JoinHeader = ",Mst_Fabric_Shade.SHADE as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN Mst_Fabric_Shade ON A." & _OppositCode & " = Mst_Fabric_Shade.Id"
        ElseIf _SelectionMastrName = "FABRIC SELVEDGE MASTER" Then
            result.JoinHeader = ",Mst_selvedge.SELVEDGE_NAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN Mst_selvedge ON A." & _OppositCode & " = Mst_selvedge.Id"
        ElseIf _SelectionMastrName = "YARN MASTER" Then
            result.JoinHeader = ",MstYarnType.YarnTypeName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstYarnType ON A." & _OppositCode & " = MstYarnType.YarnTypeCode"
        ElseIf _SelectionMastrName = "YARN SHADE MASTER" Then
            result.JoinHeader = ",MstYarnCount.CountName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstYarnCount ON A." & _OppositCode & " = MstYarnCount.CountCode"
        ElseIf _SelectionMastrName = "GENRAL ITEM MASTER" Then
            result.JoinHeader = ",MstStoreItem.ItemName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstStoreItem ON A." & _OppositCode & " = MstStoreItem.ItemCode"
        ElseIf _SelectionMastrName = "SUBITEM MASTER" Then
            result.JoinHeader = ",MstStoreSubItem.SUBITEMNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstStoreSubItem ON A." & _OppositCode & " = MstStoreSubItem.subItemCode"
        ElseIf _SelectionMastrName = "SIZE MASTER" Then
            result.JoinHeader = ",MstSize.SizeName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstSize ON A." & _OppositCode & " = MstSize.SizeCode"
        ElseIf _SelectionMastrName = "COLOR MASTER" Then
            result.JoinHeader = ",MstColor.ColorName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstColor ON A." & _OppositCode & " = MstColor.ColorCode"
        ElseIf _SelectionMastrName = "REMARK MASTER" Then
            result.JoinHeader = ",MstRemark.RemarkName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstRemark ON A." & _OppositCode & " = MstRemark.RemarkCode"
        ElseIf _SelectionMastrName = "PROCESS MASTER" Then
            result.JoinHeader = ",MstMasterAccount.ACCOUNTNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstMasterAccount ON A." & _OppositCode & " = MstMasterAccount.ACCOUNTCODE"
        ElseIf _SelectionMastrName = "CUT MASTER" Then
            result.JoinHeader = ",MstCutMaster.CUTNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstCutMaster ON A." & _OppositCode & " = MstCutMaster.ID"
        ElseIf _SelectionMastrName = "DEPARTMENT MASTER" Then
            result.JoinHeader = ",MstDepartment.Departmentname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstDepartment ON A." & _OppositCode & " = MstDepartment.Departmentcode"
        ElseIf _SelectionMastrName = "POST MASTER" Then
            result.JoinHeader = ",MSTPOST.POSTNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MSTPOST ON A." & _OppositCode & " = MSTPOST.POSTCODE"
        ElseIf _SelectionMastrName = "EMPLOYEE MASTER" Then
            result.JoinHeader = ",MstEmployee.EMPNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstEmployee ON A." & _OppositCode & " = MstEmployee.EMPCODE"
        ElseIf _SelectionMastrName = "FABRIC GROUP MASTER" Then
            result.JoinHeader = ",MstFabricGroup.fabric_GroupName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstFabricGroup ON A." & _OppositCode & " = MstFabricGroup.ID"
        ElseIf _SelectionMastrName = "GODOWN MASTER" Then
            result.JoinHeader = ",MstGodown.GodownName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstGodown ON A." & _OppositCode & " = MstGodown.GodownCode"
        ElseIf _SelectionMastrName = "GRADER MASTER" Then
            result.JoinHeader = ",MstGrader.GraderName as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstGrader ON A." & _OppositCode & " = MstGrader.GraderCode"
        ElseIf _SelectionMastrName = "INSURANCE MASTER" Then
            result.JoinHeader = ",MstInsuranceCompany.COMPANYNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstInsuranceCompany ON A." & _OppositCode & " = MstInsuranceCompany.ID"
        ElseIf _SelectionMastrName = "LOOMNO MASTER" Then
            result.JoinHeader = ",MSTLOOMNO.LOOMNO as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MSTLOOMNO ON A." & _OppositCode & " = MSTLOOMNO.LoomNoCode"
        ElseIf _SelectionMastrName = "SALESMAN MASTER" Then
            result.JoinHeader = ",MstSalesMan.salesmanname as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstSalesMan ON A." & _OppositCode & " = MstSalesMan.salesmancode"
        ElseIf _SelectionMastrName = "TRANSPORT MASTER" Then
            result.JoinHeader = ",MstTransport.TRANSPORTNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstTransport ON A." & _OppositCode & " = MstTransport.ID"
        ElseIf _SelectionMastrName = "BOOK MASTER" Then
            result.JoinHeader = ",MstBook.BOOKNAME as [" & _DatabaseHeaderName & "]"
            result.LeftJoin = " LEFT JOIN MstBook ON A." & _OppositCode & " = MstBook.BookCode"
        End If
        Return result
    End Function
    Public Sub HandleMultipleMasterSelection(ByVal masterName As String, ByVal listtype As String)
        Select Case masterName
            Case "ACCOUNT MASTER"
                Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
                'Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", "MULTIPLE")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim list = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In list
                        If dict.ContainsKey("AccountName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("AccountName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "AGENT MASTER"
                Dim _LoadQuery = NewSelectionList.Bill_Agent_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim list = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In list
                        If dict.ContainsKey("AgentName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("AgentName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "CITY MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_City_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim list = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In list
                        If dict.ContainsKey("cityname") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("cityname").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "STATE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_State_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim list = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In list
                        If dict.ContainsKey("StateName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("StateName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "FABRIC ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_ITEM_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("ITENNAME") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("ITENNAME").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "FABRIC DESIGN MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_DESIGN_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("DesignName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("DesignName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "FABRIC SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_SHADE_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("ShadeName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("ShadeName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "FABRIC SELVEDGE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Selvedge_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("SelvedgeName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("SelvedgeName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "YARN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Yarn_Type_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("YarnType") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("YarnType").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "YARN SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_YarnItem_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("CountName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("CountName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "GENRAL ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_storeItem_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("ItemName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("ItemName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "SUBITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_store_Sub_Item_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("SubItemName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("SubItemName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "SIZE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_size_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("SizeName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("SizeName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "COLOR MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Color_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("ColorName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("ColorName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "REMARK MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Remark_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("Remark") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("Remark").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "PROCESS MASTER"
                Dim _LoadQuery = NewSelectionList.Single_process_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("ACCOUNTNAME") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("ACCOUNTNAME").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "CUT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Cut_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("CUTNAME") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("CUTNAME").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "DEPARTMENT MASTER"
                Dim _LoadQuery = NewSelectionList.Single_STORE_DEPARTMENT_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("DepName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("DepName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "POST MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_POST_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("Post") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("Post").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "EMPLOYEE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Employee_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("EmployeeName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("EmployeeName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "FABRIC GROUP MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Fabric_Item_Group_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("GroupName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("GroupName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "GODOWN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Godown_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("GodownName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("GodownName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "GRADER MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_GRADER_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("GraderName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("GraderName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "INSURANCE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_INSURANCE_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("COMPANYNAME") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("COMPANYNAME").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "LOOMNO MASTER"
                Dim _LoadQuery = NewSelectionList.Single_LoomNo_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("LoomNo") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("LoomNo").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "SALESMAN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_SalesMan_Selection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("Saleman") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("Saleman").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "TRANSPORT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_TRANSPORT_SELECTION("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("TransportName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("TransportName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
            Case "BOOK MASTER"
                Dim _LoadQuery = NewSelectionList.MstBookSelection("")
                Dim selected = MultyAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", listtype)
                If selected IsNot Nothing Then
                    Dim List = CType(selected, List(Of Dictionary(Of String, Object)))
                    For Each dict In List
                        If dict.ContainsKey("BookName") AndAlso dict.ContainsKey("ACCOUNTCODE") Then
                            AddToMasterList(dict("BookName").ToString(), dict("ACCOUNTCODE").ToString(), masterName)
                        End If
                    Next
                End If
        End Select
    End Sub
    Public Sub AddToMasterList(name As String, code As String, masterName As String)
        masterListcode1.Add(New Tuple(Of String, String, String)(code, name, masterName))
        masterListcode2.Add(New Tuple(Of String, String, String)(code, name, masterName))
        masterListcode3.Add(New Tuple(Of String, String, String)(code, name, masterName))
        masterListcode4.Add(New Tuple(Of String, String, String)(code, name, masterName))
        masterListcode5.Add(New Tuple(Of String, String, String)(code, name, masterName))
    End Sub

    Public Sub HandleMasterSelection(ByVal masterName As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal CntrlName As Control, ByVal ActivetextName As String, ByVal listtype As String)
        Select Case masterName
            Case "ACCOUNT MASTER"
                Dim _LoadQuery = NewSelectionList.MstMasterAccount_Select("")
                'Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, "SINGLE")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("AccountName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("AccountName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "AGENT MASTER"
                Dim _LoadQuery = NewSelectionList.Bill_Agent_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("AgentName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("AgentName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "CITY MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_City_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("cityname") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("cityname").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "STATE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_State_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("StateName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("StateName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_ITEM_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ITENNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ITENNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC DESIGN MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_DESIGN_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("DesignName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("DesignName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_SHADE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ShadeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ShadeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC SELVEDGE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Selvedge_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SelvedgeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SelvedgeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "YARN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Yarn_Type_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("YarnType") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("YarnType").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "YARN SHADE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_YarnItem_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("CountName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("CountName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GENRAL ITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_storeItem_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ItemName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ItemName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SUBITEM MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_store_Sub_Item_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SubItemName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SubItemName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SIZE MASTER"
                Dim _LoadQuery = NewSelectionList.Single_size_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("SizeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("SizeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "COLOR MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Color_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ColorName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ColorName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "REMARK MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Remark_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Remark") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Remark").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "PROCESS MASTER"
                Dim _LoadQuery = NewSelectionList.Single_process_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("ACCOUNTNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("ACCOUNTNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "CUT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Cut_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("CUTNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("CUTNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "DEPARTMENT MASTER"
                Dim _LoadQuery = NewSelectionList.Single_STORE_DEPARTMENT_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("DepName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("DepName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "POST MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_POST_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Post") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Post").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "EMPLOYEE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_Employee_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("EmployeeName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("EmployeeName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "FABRIC GROUP MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Fabric_Item_Group_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GroupName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GroupName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GODOWN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_Godown_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GodownName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GodownName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "GRADER MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_GRADER_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("GraderName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("GraderName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "INSURANCE MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_INSURANCE_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("COMPANYNAME") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("COMPANYNAME").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "LOOMNO MASTER"
                Dim _LoadQuery = NewSelectionList.Single_LoomNo_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("LoomNo") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("LoomNo").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "SALESMAN MASTER"
                Dim _LoadQuery = NewSelectionList.Single_SalesMan_Selection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("Saleman") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("Saleman").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "TRANSPORT MASTER"
                Dim _LoadQuery = NewSelectionList.SINGLE_TRANSPORT_SELECTION("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("TransportName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("TransportName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
            Case "BOOK MASTER"
                Dim _LoadQuery = NewSelectionList.MstBookSelection("")
                Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), ActivetextName, listtype)
                If selected IsNot Nothing Then
                    If selected.ContainsKey("BookName") AndAlso selected.ContainsKey("ACCOUNTCODE") Then
                        SetGridValue(selected("BookName").ToString(), selected("ACCOUNTCODE").ToString(), activeColName, offMasterCode, CntrlName)
                    End If
                End If
        End Select
    End Sub
    Public Sub SetGridValue(ByVal displayValue As String, ByVal codeValue As String, ByVal activeColName As String, ByVal offMasterCode As String, ByVal ctrl As Control)
        If ctrl IsNot Nothing Then
            If TypeOf ctrl Is TextBox Then
                Dim txt As TextBox = DirectCast(ctrl, TextBox)
                txt.Text = displayValue
                txt.ReadOnly = True
                Dim existingItem = _UniqueValues.FirstOrDefault(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase))
                If existingItem Is Nothing Then
                    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                Else
                    ' 🔹 Agar value update karni ho to replace karo
                    _UniqueValues.Remove(existingItem)
                    _UniqueValues.Add(Tuple.Create(ctrl.Name, offMasterCode, codeValue))
                End If
            ElseIf TypeOf ctrl Is FlexCell.Grid Then
                Dim grd = DirectCast(ctrl, FlexCell.Grid)
                If ctrl.Name = "Grid1" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid1.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid2" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid2.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid2.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid3" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid3.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid3.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid4" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid4.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid4.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                ElseIf ctrl.Name = "Grid5" Then
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid5.Columns.IndexOf(activeColName) + 1).Text = displayValue
                    grd.Cell(grd.ActiveCell.Row, _DataTableGrid5.Columns.IndexOf(offMasterCode) + 1).Text = codeValue
                End If
            End If
        End If
        'Dim listByControl = _UniqueValues.Where(Function(x) String.Equals(x.Item1, ctrl.Name, StringComparison.OrdinalIgnoreCase)).ToList()
    End Sub
    Public Sub LoadShadeSelection(ByVal ReqBookvnorawData As String, ByVal _ReqBookCode As String, ByVal GrdItem As Object, ByVal _DataTableGrid As DataTable)
        Dim _StrQuery As New StringBuilder
        With _StrQuery
            .Append(" SELECT ")
            .Append(" DISTINCT B.SUBITEMNAME AS COMPANYNAME, ")
            .Append(" A.SHADECODE AS SHADECODE ")
            .Append(" FROM TrnPackingSlip AS A ")
            .Append(" LEFT JOIN MstStoreSubItem AS B ")
            .Append(" ON A.SHADECODE = B.SUBITEMCODE ")
            .Append(" WHERE 1=1 ")
            '.Append(" AND A.Bookcode = '" & _ReqBookCode & "' ")
            .Append(" AND A.BOOKVNO IN " & ReqBookvnorawData & " ")
        End With
        Dim _LoadQuery As String = _StrQuery.ToString()
        Dim selected = SingleAccountSelectionForm(_LoadQuery, GetType(Master_frm), "", "SINGLE")
        If selected IsNot Nothing Then
            If selected.ContainsKey("SHADECODE") Then
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("SHADECODE") + 1).Text = selected("SHADECODE").ToString()
            End If
            If selected.ContainsKey("COMPANYNAME") Then
                GrdItem.Cell(GrdItem.ActiveCell.Row, _DataTableGrid.Columns.IndexOf("COMPANYNAME") + 1).Text = selected("COMPANYNAME").ToString()
            End If
        End If
    End Sub
End Module
