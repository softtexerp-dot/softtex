Imports DevExpress.CodeParser

Module GetMasterDataJoinInMaster
    Public Class JoinResult
        Public Property LeftJoin As String
        Public Property JoinHeader As String
        Public Property MasterList As List(Of String) ' 👈 NEW
    End Class

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
End Module
