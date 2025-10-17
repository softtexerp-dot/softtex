Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Tile

Public Class PlanningGatway

    Dim SelectionOfView As String = ""
    Dim SelectionButton As String = ""
    Dim SelectionType As String = ""
    Dim SelectionDashBordName As String = ""
    Dim NoOfstage As Integer = 0
    Dim _StgIRowNo As Integer = 0
    Dim _StgIIRowNo As Integer = 0
    Dim _StgIIIRowNo As Integer = 0
    Dim _StgIVRowNo As Integer = 0
    Dim focusedColumn_I As DevExpress.XtraGrid.Columns.GridColumn
    Dim focusedColumn_II As DevExpress.XtraGrid.Columns.GridColumn
    Dim focusedColumn_III As DevExpress.XtraGrid.Columns.GridColumn
    Dim focusedColumn_IV As DevExpress.XtraGrid.Columns.GridColumn
    Dim FactStockTable As New DataTable
    Dim ProcessStageTable As New DataTable

    Dim FoloupSelectionEnter As String = ""
    Dim AvgWtPerMtr As String = ""
    Dim _StageActColName As String = ""
    Dim _RedyeningShadeCode As String = ""
    Dim _RedyeningShadeType As String = ""
    Dim FactoryYarnCountCode As String = ""
    Dim FactoryPlaningNo As String = ""
    Dim FactoryActiveClmItemCode As String = ""
    Dim FactoryActiveClmName As String = ""
    Dim FilterBookVno As String = ""
    Dim _CommanFilterString As String = ""
    Dim _CommanFirstStageActivColumn As String = ""
    Private _lastSelectedMenu As DevExpress.XtraBars.Navigation.AccordionControlElement = Nothing
    Private _isMenuFocused As Boolean = False

    Private ReadOnly BeamColorMap As New Dictionary(Of String, Color)
    Private ReadOnly rnd As New Random()

#Region "Creat New Database On Company"
    Public Sub _CreatNewDatabaseOnCompany()

        ' Connection to master DB (needed to create new DB)
        Dim connStr As String = _GetServerConnection("master")
        Dim dbName As String = "CompanyDatabase"
        Dim tableName As String = "PaymentFolo"

        ' Step 1: Create Database if not exists
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" IF NOT EXISTS ( ")
            .Append("  SELECT name  ")
            .Append("  FROM sys.databases  ")
            .Append("  WHERE name = N'" & dbName & "' ")
            .Append(" ) ")
            .Append(" BEGIN ")
            .Append("  CREATE DATABASE " & dbName & "; ")
            .Append(" END ")
        End With
        Dim createDbQuery = _strQuery.ToString
        _CompanyDataBaseCreatSqlCOnnection(connStr, createDbQuery)


        Dim connStrNewDb As String = _GetServerConnection(dbName)
        Dim createTableQuery As String = ""

        Dim ColumnCheck As Boolean = False
        _strQuery = New StringBuilder
        With _strQuery
            .Append("  SELECT TABLE_NAME ")
            .Append("  From INFORMATION_SCHEMA.TABLES  ")
            .Append(" Where TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME='PaymentFolo'  ")
        End With
        sqL = _strQuery.ToString
        PaymentFolo_QueryLoad()
        If DefaltSoftTable.Rows.Count > 0 Then
            ColumnCheck = True
        End If

        If ColumnCheck = False Then

#Region "PaymentFolo"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PaymentFolo') BEGIN ")
                .Append(" CREATE TABLE PaymentFolo ( ")
                .Append(" ID INT IDENTITY(1,1) PRIMARY KEY, ")
                .Append(" [Database] NVARCHAR(100), ")
                .Append(" bookvno NVARCHAR(50), ")
                .Append(" BillNo NVARCHAR(50), ")
                .Append(" BillDate datetime, ")
                .Append(" Accountcode NVARCHAR(50), ")
                .Append(" Amount numeric(18, 2), ")
                .Append(" Folodate datetime, ")
                .Append(" PaymentRemark NVARCHAR(255), ")
                .Append(" PaymentRemarkDate datetime, ")
                .Append(" GrRemark NVARCHAR(255), ")
                .Append(" OtherRemark NVARCHAR(255), ")
                .Append(" DetailRemark NVARCHAR(MAX), ")
                .Append(" OtherReson NVARCHAR(255), ")
                .Append(" CompAlies NVARCHAR(100), ")
                .Append(" PartyName NVARCHAR(150), ")
                .Append(" PartyMobNo NVARCHAR(20), ")
                .Append(" AgentName NVARCHAR(100), ")
                .Append(" AgentMobileNo NVARCHAR(20), ")
                .Append(" callerName NVARCHAR(100), ")
                .Append(" CallerMob NVARCHAR(20), ")
                .Append(" CotactPerson NVARCHAR(100), ")
                .Append(" CotactPersonMob NVARCHAR(20), ")
                .Append(" OP1 NVARCHAR(255), ")
                .Append(" OP2 NVARCHAR(255), ")
                .Append(" OP3 NVARCHAR(255), ")
                .Append(" OP4 NVARCHAR(255), ")
                .Append(" OP5 NVARCHAR(255), ")
                .Append(" OP6 NVARCHAR(255), ")
                .Append(" OP7 NVARCHAR(255), ")
                .Append(" OP8 NVARCHAR(255), ")
                .Append(" OP9 NVARCHAR(255), ")
                .Append(" OP10 NVARCHAR(255), ")
                .Append(" OP11 NVARCHAR(255), ")
                .Append(" OP12 NVARCHAR(255), ")
                .Append(" OP13 NVARCHAR(255), ")
                .Append(" OP14 NVARCHAR(255), ")
                .Append(" OP15 NVARCHAR(255), ")
                .Append(" OP16 NVARCHAR(255), ")
                .Append(" OP17 NVARCHAR(255), ")
                .Append(" OP18 NVARCHAR(255), ")
                .Append(" OP19 NVARCHAR(255), ")
                .Append(" OP20 NVARCHAR(255), ")
                .Append(" OP21 numeric(18, 2), ")
                .Append(" OP22 numeric(18, 2), ")
                .Append(" OP23 numeric(18, 2), ")
                .Append(" OP24 numeric(18, 2), ")
                .Append(" OP25 numeric(18, 2), ")
                .Append(" OP26 datetime, ")
                .Append(" OP27 datetime, ")
                .Append(" OP28 datetime, ")
                .Append(" OP29 datetime, ")
                .Append(" OP30 datetime, ")
                .Append(" [USER] NVARCHAR(100), ")
                .Append(" USERID NVARCHAR(50) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "MenuTable"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MenuTable') BEGIN ")
                .Append(" CREATE TABLE MenuTable ( ")
                .Append(" ID INT, ")
                .Append(" MENU NVARCHAR(255) , ")
                .Append(" SUBID INT , ")
                .Append(" ORDERNO INT , ")
                .Append(" Installation_Type NVARCHAR(255) , ")
                .Append(" SELECTFORM NVARCHAR(255) , ")
                .Append(" ACTIVE_STATUS NVARCHAR(255) , ")
                .Append(" SHORT_KEY_ACTIVE NVARCHAR(255) , ")
                .Append(" SHORT_KEY_ORDER NVARCHAR(255) , ")
                .Append(" [SHORT_KEY_CTRL+ALTR_KEY] NVARCHAR(255) , ")
                .Append(" SHORT_KEY NVARCHAR(255) , ")
                .Append(" OP1 NVARCHAR(255) , ")
                .Append(" OP2 NVARCHAR(255) , ")
                .Append(" OP3 NVARCHAR(255) , ")
                .Append(" OP4 NVARCHAR(255) , ")
                .Append(" OP5 NVARCHAR(255) , ")
                .Append(" OP6 NVARCHAR(255) , ")
                .Append(" OP7 NVARCHAR(255) , ")
                .Append(" OP8 NVARCHAR(255) , ")
                .Append(" OP9 NVARCHAR(255) , ")
                .Append(" OP10 NVARCHAR(255) , ")
                .Append(" OP11 NVARCHAR(255) , ")
                .Append(" OP12 NVARCHAR(255) , ")
                .Append(" OP13 NVARCHAR(255) , ")
                .Append(" OP14 NVARCHAR(255) , ")
                .Append(" OP15 NVARCHAR(255) , ")
                .Append(" OP16 NVARCHAR(255) , ")
                .Append(" OP17 NVARCHAR(255) , ")
                .Append(" OP18 NVARCHAR(255) , ")
                .Append(" OP19 NVARCHAR(255) , ")
                .Append(" OP20 NVARCHAR(255)  ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "MstCompany"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MstCompany') BEGIN ")
                .Append("CREATE TABLE MstCompany (")
                .Append("    ID INT PRIMARY KEY,")
                .Append("    RECORD_TYPE NVARCHAR(50) ,")
                .Append("    Comp_Name NVARCHAR(50) ,")
                .Append("    Comp_Print_Name NVARCHAR(50) ,")
                .Append("    Comp_Code INT ,")
                .Append("    Comp_Year_Code INT ,")
                .Append("    Comp_Add1 NVARCHAR(255) ,")
                .Append("    Comp_Add2 NVARCHAR(255) ,")
                .Append("    Comp_Add3 NVARCHAR(255) ,")
                .Append("    Comp_Add4 NVARCHAR(255) ,")
                .Append("    Comp_Fin_Year_Start DATETIME ,")
                .Append("    Comp_Fin_Year_End DATETIME ,")
                .Append("    Comp_CIN NVARCHAR(255) ,")
                .Append("    Comp_IT_Pan NVARCHAR(50) ,")
                .Append("    Comp_Tel_No NVARCHAR(50) ,")
                .Append("    Comp_Ward NVARCHAR(50) ,")
                .Append("    Comp_Fax NVARCHAR(50) ,")
                .Append("    Comp_Email NVARCHAR(50) ,")
                .Append("    Comp_Country NVARCHAR(50) ,")
                .Append("    Comp_State NVARCHAR(50) ,")
                .Append("    Comp_City NVARCHAR(50) ,")
                .Append("    Comp_Jurisdiction NVARCHAR(50) ,")
                .Append("    Comp_Enable_Tax NVARCHAR(50) ,")
                .Append("    Comp_TaxType NVARCHAR(50) ,")
                .Append("    Comp_Enable_SurCharge NVARCHAR(50) ,")
                .Append("    Comp_TIN NVARCHAR(50) ,")
                .Append("    Comp_Cst_No NVARCHAR(50) ,")
                .Append("    Comp_TDS_No NVARCHAR(50) ,")
                .Append("    Comp_TDS_Circle NVARCHAR(50) ,")
                .Append("    Comp_Mono NVARCHAR(50) ,")
                .Append("    Comp_Bank_Name NVARCHAR(50) ,")
                .Append("    Comp_Bank_Acc_No NVARCHAR(50) ,")
                .Append("    Comp_Bank_IFSCode NVARCHAR(255) ,")
                .Append("    Comp_Director_Name NVARCHAR(50) ,")
                .Append("    Comp_Hide NVARCHAR(50) ,")
                .Append("    Comp_TDS_Per NVARCHAR(50) ,")
                .Append("    Comp_Type NVARCHAR(50) ,")
                .Append("    Data_Folder_Name NVARCHAR(255) ,")
                .Append("    COMP_ADMINUSER NVARCHAR(255) ,")
                .Append("    COMP_PASSWORD NVARCHAR(255) ,")
                .Append("    PIECE_NO_GENERATE_BY NVARCHAR(255) ,")
                .Append("    PROCESS_SHRINKAGE_CALC_BY NVARCHAR(255) ,")
                .Append("    DESIGN_SHADE_REQ_IN_PROCESS_CHALLAN NVARCHAR(255) ,")
                .Append("    LOGO_FILE_NAME NVARCHAR(255) ,")
                .Append("    EDP_PASSWORD NVARCHAR(255) ,")
                .Append("    GRADING_RCPT_BY_PROCESS_CHALLAN NVARCHAR(255) ,")
                .Append("    FINISH_PSLIP_BY_GRADING_STK NVARCHAR(255) ,")
                .Append("    PF_IMP NVARCHAR(255) ,")
                .Append("    PF_COMPANYCODE NVARCHAR(255) ,")
                .Append("    PF_COMPANY_AC_GROUPCODE NVARCHAR(255) ,")
                .Append("    PF_COMPANY_SECURITYCODE NVARCHAR(255) ,")
                .Append("    PF_IMPDATE DATETIME ,")
                .Append("    ESI_IMP NVARCHAR(255) ,")
                .Append("    ESI_COMPANYCODE NVARCHAR(255) ,")
                .Append("    ESI_BRANCHCODE NVARCHAR(255) ,")
                .Append("    ESI_IMPDATE DATETIME ,")
                .Append("    PF_MAX_SALARY FLOAT ,")
                .Append("    PENSION_MAX_SALARY FLOAT ,")
                .Append("    EDLI_MAX_SALARY FLOAT ,")
                .Append("    ESI_MAX_SALARY FLOAT ,")
                .Append("    PF_RATE_EMP FLOAT ,")
                .Append("    PF_RATE_COMP FLOAT ,")
                .Append("    PS_RATE_COMP FLOAT ,")
                .Append("    PS_RATE_EMP FLOAT ,")
                .Append("    EDLI_RATE FLOAT ,")
                .Append("    EDLI_RATE_COMP FLOAT ,")
                .Append("    EDLI_RATE_EMP FLOAT ,")
                .Append("    PF_ADMIN_RATE_COMP FLOAT ,")
                .Append("    PF_ADMIN_RATE_EMP FLOAT ,")
                .Append("    EDLI_ADMIN_RATE_COMP FLOAT ,")
                .Append("    EDLI_ADMIN_RATE_EMP FLOAT ,")
                .Append("    PF_INTEREST_RATE FLOAT ,")
                .Append("    ESI_RATE_COMP FLOAT ,")
                .Append("    ESI_RATE_EMP FLOAT ,")
                .Append("    PS_MAX_AGE FLOAT ,")
                .Append("    COMP_GSTIN NVARCHAR(255) ,")
                .Append("    COMP_AADHARNO NVARCHAR(255) ,")
                .Append("    FIN_YEAR NVARCHAR(255) ,")
                .Append("    GstApiUserName NVARCHAR(MAX) ,")
                .Append("    GstApiUserPassword NVARCHAR(MAX) ,")
                .Append("    WhatsAppApiKey NVARCHAR(MAX) ,")
                .Append(" OP1 NVARCHAR(255) , ")
                .Append(" OP2 NVARCHAR(255) , ")
                .Append(" OP3 NVARCHAR(255) , ")
                .Append(" OP4 NVARCHAR(255) , ")
                .Append(" OP5 NVARCHAR(255) , ")
                .Append(" OP6 NVARCHAR(255) , ")
                .Append(" OP7 NVARCHAR(255) , ")
                .Append(" OP8 NVARCHAR(255) , ")
                .Append(" OP9 NVARCHAR(255) , ")
                .Append(" OP10 NVARCHAR(255), ")
                .Append(" OP11 NVARCHAR(255), ")
                .Append(" OP12 NVARCHAR(255), ")
                .Append(" OP13 NVARCHAR(255), ")
                .Append(" OP14 NVARCHAR(255), ")
                .Append(" OP15 NVARCHAR(255), ")
                .Append(" OP16 NVARCHAR(255), ")
                .Append(" OP17 NVARCHAR(255), ")
                .Append(" OP18 NVARCHAR(255), ")
                .Append(" OP19 NVARCHAR(255), ")
                .Append(" OP20 NVARCHAR(255), ")
                .Append(" OP21 NVARCHAR(255), ")
                .Append(" OP22 NVARCHAR(255), ")
                .Append(" OP23 NVARCHAR(255), ")
                .Append(" OP24 NVARCHAR(255), ")
                .Append(" OP25 NVARCHAR(255), ")
                .Append(" OP26 NVARCHAR(255), ")
                .Append(" OP27 NVARCHAR(255), ")
                .Append(" OP28 NVARCHAR(255), ")
                .Append(" OP29 NVARCHAR(255), ")
                .Append(" OP30 NVARCHAR(255), ")
                .Append(" OP31 NVARCHAR(255), ")
                .Append(" OP32 NVARCHAR(255), ")
                .Append(" OP33 NVARCHAR(255), ")
                .Append(" OP34 NVARCHAR(255), ")
                .Append(" OP35 NVARCHAR(255), ")
                .Append(" OP36 NVARCHAR(255), ")
                .Append(" OP37 NVARCHAR(255), ")
                .Append(" OP38 NVARCHAR(255), ")
                .Append(" OP39 NVARCHAR(255), ")
                .Append(" OP40 NVARCHAR(255), ")
                .Append(" OP41 NVARCHAR(255), ")
                .Append(" OP42 NVARCHAR(255), ")
                .Append(" OP43 NVARCHAR(255), ")
                .Append(" OP44 NVARCHAR(255), ")
                .Append(" OP45 NVARCHAR(255), ")
                .Append(" OP46 NVARCHAR(255), ")
                .Append(" OP47 NVARCHAR(255), ")
                .Append(" OP48 NVARCHAR(255), ")
                .Append(" OP49 NVARCHAR(255), ")
                .Append(" OP50 NVARCHAR(255) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "MstUser"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MstUser') BEGIN ")
                .Append("CREATE TABLE MstUser (")
                .Append("    ID INT IDENTITY(1,1) PRIMARY KEY,")
                .Append("    USER_ID INT ,")
                .Append("    USERNAME NVARCHAR(255) ,")
                .Append("    PWD NVARCHAR(255) ,")
                .Append("    ACTIVESTATUS NVARCHAR(255) ,")
                .Append("    Comp_Code SMALLINT ,")
                .Append("    User_add NVARCHAR(255) ,")
                .Append("    User_modify NVARCHAR(255) ,")
                .Append("    User_delete NVARCHAR(255) ,")
                .Append("    User_view NVARCHAR(255) ,")
                .Append("    User_print NVARCHAR(255) ,")
                .Append("    User_report NVARCHAR(255) ,")
                .Append("    Led_Display NVARCHAR(255) ,")
                .Append("    Data_Alter_Days INT ,")
                .Append("    Display_Shortcut_Menu NVARCHAR(255) ,")
                .Append("    Create_Account NVARCHAR(255) ,")
                .Append("    Create_Master NVARCHAR(255) ,")
                .Append("    WhatsUpSend NVARCHAR(MAX) ,")
                .Append("    OP1 NVARCHAR(MAX) ,")
                .Append("    OP2 NVARCHAR(MAX) ,")
                .Append("    WhatsAppUserAPI NVARCHAR(MAX) ,")
                .Append("    OP3 NVARCHAR(MAX) ,")
                .Append("    OP4 NVARCHAR(MAX) ,")
                .Append("    OP5 NVARCHAR(MAX) ,")
                .Append("    OP6 NVARCHAR(MAX) ,")
                .Append("    OP7 NVARCHAR(MAX) ,")
                .Append("    OP8 NVARCHAR(MAX) ,")
                .Append("    OP9 NVARCHAR(MAX) ,")
                .Append("    OP10 NVARCHAR(MAX) ,")
                .Append(" OP11 NVARCHAR(255) , ")
                .Append(" OP12 NVARCHAR(255) , ")
                .Append(" OP13 NVARCHAR(255) , ")
                .Append(" OP14 NVARCHAR(255) , ")
                .Append(" OP15 NVARCHAR(255) , ")
                .Append(" OP16 NVARCHAR(255) , ")
                .Append(" OP17 NVARCHAR(255) , ")
                .Append(" OP18 NVARCHAR(255) , ")
                .Append(" OP19 NVARCHAR(255) , ")
                .Append(" OP20 NVARCHAR(255) ,")
                .Append(" OP21 NVARCHAR(255) , ")
                .Append(" OP22 NVARCHAR(255) , ")
                .Append(" OP23 NVARCHAR(255) , ")
                .Append(" OP24 NVARCHAR(255) , ")
                .Append(" OP25 NVARCHAR(255) , ")
                .Append(" OP26 NVARCHAR(255) , ")
                .Append(" OP27 NVARCHAR(255) , ")
                .Append(" OP28 NVARCHAR(255) , ")
                .Append(" OP29 NVARCHAR(255) , ")
                .Append(" OP30 NVARCHAR(255) , ")
                .Append(" OP31 NVARCHAR(255) , ")
                .Append(" OP32 NVARCHAR(255) , ")
                .Append(" OP33 NVARCHAR(255) , ")
                .Append(" OP34 NVARCHAR(255) , ")
                .Append(" OP35 NVARCHAR(255) , ")
                .Append(" OP36 NVARCHAR(255) , ")
                .Append(" OP37 NVARCHAR(255) , ")
                .Append(" OP38 NVARCHAR(255) , ")
                .Append(" OP39 NVARCHAR(255) , ")
                .Append(" OP40 NVARCHAR(255) , ")
                .Append(" OP41 NVARCHAR(255) , ")
                .Append(" OP42 NVARCHAR(255) , ")
                .Append(" OP43 NVARCHAR(255) , ")
                .Append(" OP44 NVARCHAR(255) , ")
                .Append(" OP45 NVARCHAR(255) , ")
                .Append(" OP46 NVARCHAR(255) , ")
                .Append(" OP47 NVARCHAR(255) , ")
                .Append(" OP48 NVARCHAR(255) , ")
                .Append(" OP49 NVARCHAR(255) , ")
                .Append(" OP50 NVARCHAR(255)  ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "SMSInfo"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SMSInfo') BEGIN ")
                .Append("CREATE TABLE SMSInfo (")
                .Append("    ID INT,")
                .Append("    sms_url NVARCHAR(255) ,")
                .Append("    sms_userid NVARCHAR(255) ,")
                .Append("    sms_password NVARCHAR(255) ,")
                .Append("    sms_senderid NVARCHAR(255) ,")
                .Append("    OP1 NVARCHAR(MAX) ,")
                .Append("    OP2 NVARCHAR(MAX) ,")
                .Append("    OP3 NVARCHAR(MAX) ,")
                .Append("    OP4 NVARCHAR(MAX) ,")
                .Append("    OP5 NVARCHAR(MAX) ,")
                .Append("    OP6 NVARCHAR(MAX) ,")
                .Append("    OP7 NVARCHAR(MAX) ,")
                .Append("    OP8 NVARCHAR(MAX) ,")
                .Append("    OP9 NVARCHAR(MAX) ,")
                .Append("    OP10 NVARCHAR(MAX) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "SqlSetting"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SqlSetting') BEGIN ")
                .Append("CREATE TABLE SqlSetting (")
                .Append("    ID INT,")
                .Append("    ServerPcName NVARCHAR(255) ,")
                .Append("    SQLServerName NVARCHAR(255) ,")
                .Append("    UserName NVARCHAR(255) ,")
                .Append("    UserPassword NVARCHAR(255) ,")
                .Append("    op1 NVARCHAR(255) ,")
                .Append("    op2 NVARCHAR(255) ,")
                .Append("    op3 NVARCHAR(255) ,")
                .Append("    op4 NVARCHAR(255) ,")
                .Append("    OP5 NVARCHAR(MAX) ,")
                .Append("    OP6 NVARCHAR(MAX) ,")
                .Append("    OP7 NVARCHAR(MAX) ,")
                .Append("    OP8 NVARCHAR(MAX) ,")
                .Append("    OP9 NVARCHAR(MAX) ,")
                .Append("    OP10 NVARCHAR(MAX) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "UserMenu"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UserMenu') BEGIN ")
                .Append("CREATE TABLE UserMenu (")
                .Append("    ID INT IDENTITY(1,1) PRIMARY KEY,")
                .Append("    MenuID INT ,")
                .Append("    UserID INT ,")
                .Append("    Active_Status NVARCHAR(255) ,")
                .Append("    op1 NVARCHAR(255) ,")
                .Append("    op2 NVARCHAR(255) ,")
                .Append("    op3 NVARCHAR(255) ,")
                .Append("    op4 NVARCHAR(255) ,")
                .Append("    OP5 NVARCHAR(MAX) ,")
                .Append("    OP6 NVARCHAR(MAX) ,")
                .Append("    OP7 NVARCHAR(MAX) ,")
                .Append("    OP8 NVARCHAR(MAX) ,")
                .Append("    OP9 NVARCHAR(MAX) ,")
                .Append("    OP10 NVARCHAR(MAX) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "UserLoginStatus"
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'UserLoginStatus') BEGIN ")
                .Append("CREATE TABLE UserLoginStatus (")
                .Append("    ID INT IDENTITY(1,1) PRIMARY KEY,")
                .Append("    UserID INT ,")
                .Append("    UserName NVARCHAR(255) ,")
                .Append("    MachineName NVARCHAR(255) ,")
                .Append("    LoginTime DATETIME  DEFAULT GETDATE(),")
                .Append("    LogoutTime DATETIME NULL,")
                .Append("    IsActive BIT  DEFAULT 1,")
                .Append("    SessionID UNIQUEIDENTIFIER  DEFAULT NEWID(),")
                .Append("    IPAddress NVARCHAR(50) NULL,")
                .Append("    op1 NVARCHAR(255) ,")
                .Append("    op2 NVARCHAR(255) ,")
                .Append("    op3 NVARCHAR(255) ,")
                .Append("    op4 NVARCHAR(255) ,")
                .Append("    OP5 NVARCHAR(MAX) ,")
                .Append("    OP6 NVARCHAR(MAX) ,")
                .Append("    OP7 NVARCHAR(MAX) ,")
                .Append("    OP8 NVARCHAR(MAX) ,")
                .Append("    OP9 NVARCHAR(MAX) ,")
                .Append("    OP10 NVARCHAR(MAX) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

#Region "OtheInfo"

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'OtheInfo') BEGIN ")
                .Append(" CREATE TABLE OtheInfo ( ")
                .Append(" ID INT IDENTITY(1,1) PRIMARY KEY, ")
                .Append(" [Database] NVARCHAR(100), ")
                .Append(" TypeOfEntry NVARCHAR(255), ")
                .Append(" bookvno NVARCHAR(50), ")
                .Append(" BillNo NVARCHAR(50), ")
                .Append(" BillDate datetime, ")
                .Append(" Accountcode NVARCHAR(50), ")
                .Append(" Amount numeric(18, 2), ")
                .Append(" Folodate datetime, ")
                .Append(" PaymentRemark NVARCHAR(255), ")
                .Append(" PaymentRemarkDate datetime, ")
                .Append(" GrRemark NVARCHAR(255), ")
                .Append(" OtherRemark NVARCHAR(255), ")
                .Append(" DetailRemark NVARCHAR(MAX), ")
                .Append(" OtherReson NVARCHAR(255), ")
                .Append(" CompAlies NVARCHAR(100), ")
                .Append(" PartyName NVARCHAR(150), ")
                .Append(" PartyMobNo NVARCHAR(20), ")
                .Append(" AgentName NVARCHAR(100), ")
                .Append(" AgentMobileNo NVARCHAR(20), ")
                .Append(" callerName NVARCHAR(100), ")
                .Append(" CallerMob NVARCHAR(20), ")
                .Append(" CotactPerson NVARCHAR(100), ")
                .Append(" CotactPersonMob NVARCHAR(20), ")
                .Append(" OP1 NVARCHAR(255), ")
                .Append(" OP2 NVARCHAR(255), ")
                .Append(" OP3 NVARCHAR(255), ")
                .Append(" OP4 NVARCHAR(255), ")
                .Append(" OP5 NVARCHAR(255), ")
                .Append(" OP6 NVARCHAR(255), ")
                .Append(" OP7 NVARCHAR(255), ")
                .Append(" OP8 NVARCHAR(255), ")
                .Append(" OP9 NVARCHAR(255), ")
                .Append(" OP10 NVARCHAR(255), ")
                .Append(" OP11 NVARCHAR(255), ")
                .Append(" OP12 NVARCHAR(255), ")
                .Append(" OP13 NVARCHAR(255), ")
                .Append(" OP14 NVARCHAR(255), ")
                .Append(" OP15 NVARCHAR(255), ")
                .Append(" OP16 NVARCHAR(255), ")
                .Append(" OP17 NVARCHAR(255), ")
                .Append(" OP18 NVARCHAR(255), ")
                .Append(" OP19 NVARCHAR(255), ")
                .Append(" OP20 NVARCHAR(255), ")
                .Append(" OP21 numeric(18, 2), ")
                .Append(" OP22 numeric(18, 2), ")
                .Append(" OP23 numeric(18, 2), ")
                .Append(" OP24 numeric(18, 2), ")
                .Append(" OP25 numeric(18, 2), ")
                .Append(" OP26 numeric(18, 3), ")
                .Append(" OP27 numeric(18, 3), ")
                .Append(" OP28 numeric(18, 3), ")
                .Append(" OP29 numeric(18, 3), ")
                .Append(" OP30 numeric(18, 3), ")
                .Append(" OP31 NVARCHAR(255) , ")
                .Append(" OP32 NVARCHAR(255) , ")
                .Append(" OP33 NVARCHAR(255) , ")
                .Append(" OP34 NVARCHAR(255) , ")
                .Append(" OP35 NVARCHAR(255) , ")
                .Append(" OP36 NVARCHAR(255) , ")
                .Append(" OP37 NVARCHAR(255) , ")
                .Append(" OP38 NVARCHAR(255) , ")
                .Append(" OP39 NVARCHAR(255) , ")
                .Append(" OP40 NVARCHAR(255) , ")
                .Append(" OP41 NVARCHAR(255) , ")
                .Append(" OP42 NVARCHAR(255) , ")
                .Append(" OP43 NVARCHAR(255) , ")
                .Append(" OP44 NVARCHAR(255) , ")
                .Append(" OP45 datetime ,")
                .Append(" OP46 datetime ,")
                .Append(" OP47 datetime ,")
                .Append(" OP48 datetime ,")
                .Append(" OP49 datetime ,")
                .Append(" OP50 datetime ,")
                .Append(" [USER] NVARCHAR(100),")
                .Append(" USERID NVARCHAR(50) ")
                .Append(" ); END ")
            End With
            createTableQuery = _strQuery.ToString
            _CompanyDataBaseCreatSqlCOnnection(connStrNewDb, createTableQuery)
#End Region

        End If

    End Sub
    Public Sub _CompanyDataBaseCreatSqlCOnnection(ByVal connStrNewDb As String, ByVal createTableQuery As String)
        Using conn As New SqlConnection(connStrNewDb)
            conn.Open()
            Using cmd As New SqlCommand(createTableQuery, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
#End Region
    Private Sub AccordionControl1_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.ElementClickEventArgs) Handles AccordionControl1.ElementClick
        _lastSelectedMenu = e.Element
        _isMenuFocused = False

        ' Selected element set karo
        AccordionControl1.SelectedElement = e.Element
        AccordionControl1.AllowItemSelection = True

        ' Force focus for mouse clicks
        'AccordionControl1.Focus()
        'AccordionControl1.Invalidate()

    End Sub
    Private Sub HandleAccordionSelection(elem As DevExpress.XtraBars.Navigation.AccordionControlElement)
        If elem IsNot Nothing Then
            _lastSelectedMenu = elem
            _isMenuFocused = False

            ' Select and expand
            AccordionControl1.SelectedElement = elem
            ExpandToRoot(elem)

            ' Ensure visibility and focus
            'elem.EnsureVisible()
            AccordionControl1.Select()
            AccordionControl1.Invalidate()
        End If
    End Sub
    Private Sub PlanningGatway_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

        Me.PerformAutoScale()

        AccordionControl1.Appearance.Item.Hovered.BackColor = Color.LightBlue
        AccordionControl1.Appearance.Item.Hovered.ForeColor = Color.Black
        AccordionControl1.Appearance.Item.Pressed.BackColor = Color.Orange
        AccordionControl1.Appearance.Item.Pressed.ForeColor = Color.White

        ' KeyPreview on hona chahiye taki ESC form capture kare
        Me.KeyPreview = True


        AttachButtonFocusEvents(Me)


        Me.Size = New Size(1350, 680)


#Region "Tool Tip display"
        ToolTip1.AutoPopDelay = 5000   ' कितने समय तक दिखेगा
        ToolTip1.InitialDelay = 200    ' Mouse hover के बाद delay
        ToolTip1.ReshowDelay = 200     ' दुबारा दिखने में delay
        ToolTip1.ShowAlways = True     ' Control disabled होने पर भी दिखे
        Dim _UpdatTip As String = "Grid Item Print"
        Dim _UpdatTip_2 As String = "Process Beam Wise Detail Print"


        ToolTip1.SetToolTip(BtnGridPrint, _UpdatTip)
        ToolTip1.SetToolTip(BtnProcessDetailPrint, _UpdatTip_2)

#End Region


        If _CheckServerPcs = True Then
            _CreatNewDatabaseOnCompany()
        End If


        PnlRemark.Width = 586
        PnlRemark.Height = 230
        PnlRemark.Location = New Point(370, 250)
        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")


        'Fabric_Item_Master_Frm.ConstructionFildCreat()

        'Main_MDI_Frm.Pnk_Newdeshbord_2.Visible = False

        Pnl_Dashbord.Location = New Point(206, 47)


        'Pnl_Dashbord.Width = FluentDesignFormContainer1.Width
        'Pnl_Dashbord.Height = FluentDesignFormContainer1.Height - 50
        Pnl_Dashbord.Width = 1105
        Pnl_Dashbord.Height = 580


        GridControl1.Width = Pnl_Dashbord.Width - 10
        GridControl1.Height = Pnl_Dashbord.Height - 35

        GridControl2.Width = Pnl_Dashbord.Width
        GridControl2.Height = Pnl_Dashbord.Height


        Pnl_OutstandingView.Width = Pnl_Dashbord.Width
        Pnl_OutstandingView.Height = Pnl_Dashbord.Height

        GridControl3.Width = Pnl_OutstandingView.Width - 10
        GridControl3.Height = Pnl_OutstandingView.Height - 50





        'SchedulerControl1.Width = GridControl1.Width
        'SchedulerControl1.Height = GridControl1.Height

        Dim x As Integer = Pnl_Dashbord.Location.X
        Dim y As Integer = Pnl_Dashbord.Location.Y

        x = Pnl_Dashbord.Location.X
        y = Pnl_Dashbord.Location.Y
        GridControl1.Location = New Point(3, 35)
        GridControl2.Location = New Point(x, y)
        GridControl3.Location = New Point(3, 35)
        Pnl_OutstandingView.Location = New Point(x, y)
        'SchedulerControl1.Location = New Point(x, y)



        LblSelectedOptionName.Width = FluentDesignFormContainer1.Width

        'Factory.Expanded = True
        FactoryOrder.Expanded = False

        Process.Expanded = False
        Sales.Expanded = False
        Despatch.Expanded = False
        Factory.Expanded = False
        OutstandingCalendar.Expanded = False



        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = False

        CreateDropDownMenu()

    End Sub
    Private Sub _RemarkPanelVisuable()
        PnlRemark.Visible = False
        If SelectionOfView = "Outstanding" Then
            FirstStage.Focus()
        ElseIf SelectionOfView = "Factory" Then
            If NoOfstage = 1 Then
                FirstStage.Focus()
            ElseIf NoOfstage = 2 Then
                GridView1.Focus()
            End If
        ElseIf SelectionOfView = "Process" Then
            GridView1.Focus()
        End If
    End Sub
    Private Sub PlanningGatway_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then

            If PnlRemark.Visible = True Then
                _RemarkPanelVisuable()
                Exit Sub
            End If

            LblSelectedOptionName.Text = SelectionDashBordName

            If GridControl2.Visible = True Then
                GridControl2.Visible = False
                If SelectionOfView = "Outstanding" Then
                    GridControl3.Focus()
                Else
                    GridControl1.Focus()
                End If
                Exit Sub
            End If


            If _isMenuFocused Then
                If MessageBox.Show("Do You Want To Exit?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Close()
                    Dispose(True)
                End If
                Return
            End If

            If _lastSelectedMenu IsNot Nothing Then
                AccordionControl1.AllowItemSelection = True
                AccordionControl1.SelectedElement = _lastSelectedMenu
                ExpandToRoot(_lastSelectedMenu)

                ' Force focus back
                AccordionControl1.Focus()
                AccordionControl1.Invalidate()
            End If

            _isMenuFocused = True
        End If

    End Sub
    Private Sub ExpandToRoot(elem As DevExpress.XtraBars.Navigation.AccordionControlElement)
        Try
            ' Group type elements are expandable
            If elem.Style = DevExpress.XtraBars.Navigation.ElementStyle.Group Then
                elem.Expanded = True
            End If

            ' Try to expand via DisplayText hierarchy safely
            Dim parentGroup = AccordionControl1.Elements.Cast(Of DevExpress.XtraBars.Navigation.AccordionControlElement)().
            FirstOrDefault(Function(x) x.Elements.Contains(elem))

            If parentGroup IsNot Nothing Then
                parentGroup.Expanded = True
                ExpandToRoot(parentGroup)
            End If
        Catch
            ' ignore any hierarchy issue
        End Try
    End Sub

#Region "Outstanding Folo"
    Dim TileView1 As New TileView()
    ' Optionally set default view
    ' GridControl3.MainView = TileView1
    'Dim tileView1 As New DevExpress.XtraGrid.Views.Tile.TileView(GridControl3)
    Dim _GetAllComOotstanding As DataTable
    Dim _GetFnlOutFoloTbl As DataTable
    Private Sub OutstangPanelContrlVisable(ByVal _Visuable As Boolean)
        lbl_High_Days.Visible = _Visuable
        txt_DefaltDays_Days.Visible = _Visuable
        Btn_View.Visible = _Visuable
        Label11.Visible = _Visuable
        Txt_GroupSelection.Visible = _Visuable

    End Sub

#Region "' === Define handlers globally ==="
    Private Sub _TileViewClickEvent()
        PnlColoView.Visible = False


        ' First clear previous handlers to prevent stacking
        'RemoveHandler TileView1.ItemClick, AddressOf TileView1_TodayDue_RowClick
        RemoveHandler GridView4.KeyDown, AddressOf TileView1_TodayDue_KeyDown
        RemoveHandler TileView1.ItemClick, AddressOf TileView1_Followup_Click
        RemoveHandler TileView1.KeyDown, AddressOf TileView1_Followup_KeyDown
        RemoveHandler TileView1.ItemClick, AddressOf TileView1_GR_Click
        RemoveHandler TileView1.KeyDown, AddressOf TileView1_GR_KeyDown
        RemoveHandler TileView1.ItemClick, AddressOf TileView1_OthRemark_Click
        RemoveHandler TileView1.KeyDown, AddressOf TileView1_OthRemark_KeyDown

        RemoveHandler TileView1.ItemClick, AddressOf TileView1_DiscountUnFollowup_Click
        RemoveHandler TileView1.KeyDown, AddressOf TileView1_DiscountUnFollowup_KeyDown

        RemoveHandler TileView1.ItemClick, AddressOf TileView1_UnFollowup_Click
        RemoveHandler TileView1.KeyDown, AddressOf TileView1_UnFollowup_KeyDown

        'RemoveHandler GridView4.RowClick, AddressOf GridView4_RowClick
        'RemoveHandler GridView4.KeyDown, AddressOf GridView4_KeyDown


        ' Add based on condition
        If SelectionButton = "Today Due Bill" Then
            'AddHandler TileView1.ItemClick, AddressOf TileView1_TodayDue_RowClick
            AddHandler GridView4.KeyDown, AddressOf TileView1_TodayDue_KeyDown

        ElseIf SelectionButton = "Foloup Outstanding List" Then
            AddHandler TileView1.ItemClick, AddressOf TileView1_Followup_Click
            AddHandler TileView1.KeyDown, AddressOf TileView1_Followup_KeyDown
        ElseIf SelectionButton = "GR Matter" Then
            AddHandler TileView1.ItemClick, AddressOf TileView1_GR_Click
            AddHandler TileView1.KeyDown, AddressOf TileView1_GR_KeyDown
        ElseIf SelectionButton = "Other Matter" Then
            AddHandler TileView1.ItemClick, AddressOf TileView1_OthRemark_Click
            AddHandler TileView1.KeyDown, AddressOf TileView1_OthRemark_KeyDown
        ElseIf SelectionButton = "Discount Foloup Outstanding List" Then
            AddHandler TileView1.ItemClick, AddressOf TileView1_DiscountUnFollowup_Click
            AddHandler TileView1.KeyDown, AddressOf TileView1_DiscountUnFollowup_KeyDown
        ElseIf SelectionButton = "Un Foloup Outstanding List" Then
            AddHandler TileView1.ItemClick, AddressOf TileView1_UnFollowup_Click
            AddHandler TileView1.KeyDown, AddressOf TileView1_UnFollowup_KeyDown
            'AddHandler GridView4.KeyDown, AddressOf GridView4_KeyDown
        End If

    End Sub
    Private Sub TileView1_TodayDue_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)
        Dim view = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim rowHandle = e.RowHandle
        NoOfstage = 2
        ' Check row is valid
        If rowHandle >= 0 Then
            Dim party = view.GetRowCellValue(rowHandle, "PartyName").ToString()
            _GetTodayDueSecondStage(party)
        End If
    End Sub
    Private Sub TileView1_TodayDue_KeyDown(sender As Object, e As KeyEventArgs)
        NoOfstage = 2
        If e.KeyCode = Keys.Enter Then
            Dim view = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim party = view.GetRowCellValue(rowHandle, "PartyName").ToString()
                _GetTodayDueSecondStage(party)
            End If

        End If
    End Sub

    Private Sub TileView1_UnFollowup_Click(s As Object, args As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs)
        NoOfstage = 2
        Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = view.FocusedRowHandle
        Dim party = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
        _OutstangUnFoloSecondStage(party)
    End Sub
    Private Sub TileView1_UnFollowup_KeyDown(s As Object, e As KeyEventArgs)
        NoOfstage = 2
        If e.KeyCode = Keys.Enter Then
            Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim party = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
                _OutstangUnFoloSecondStage(party)
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub TileView1_DiscountUnFollowup_Click(s As Object, args As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs)
        NoOfstage = 2
        Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = view.FocusedRowHandle
        Dim party = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
        _OutstangUnFoloSecondStage(party)
    End Sub
    Private Sub TileView1_DiscountUnFollowup_KeyDown(s As Object, e As KeyEventArgs)
        NoOfstage = 2
        If e.KeyCode = Keys.Enter Then
            Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim party = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
                _OutstangUnFoloSecondStage(party)
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub TileView1_Followup_Click(s As Object, args As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs)
        NoOfstage = 2
        Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = view.FocusedRowHandle
        Dim PymtDate = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
        _GetPymtRemarkSecondStage(PymtDate)
    End Sub
    Private Sub TileView1_Followup_KeyDown(s As Object, e As KeyEventArgs)
        NoOfstage = 2
        If e.KeyCode = Keys.Enter Then
            Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim PymtDate = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
                _GetPymtRemarkSecondStage(PymtDate)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TileView1_GR_Click(s As Object, args As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs)
        Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = view.FocusedRowHandle
        NoOfstage = 2
        Dim PymtDate = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
        _GrMatterSecondStage(PymtDate)
    End Sub
    Private Sub TileView1_GR_KeyDown(s As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            NoOfstage = 2
            Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim PymtDate = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
                _GrMatterSecondStage(PymtDate)
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TileView1_OthRemark_Click(s As Object, args As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs)
        Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = view.FocusedRowHandle
        NoOfstage = 2
        Dim PymtDate = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
        _OthRemarkSecondStage(PymtDate)
    End Sub
    Private Sub TileView1_OthRemark_KeyDown(s As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            NoOfstage = 2
            Dim view = CType(s, DevExpress.XtraGrid.Views.Tile.TileView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim PymtDate = view.GetRowCellValue(rowHandle, "PymtDate").ToString()
                _OthRemarkSecondStage(PymtDate)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub GridView4_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            NoOfstage = 2
            Dim view = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim rowHandle = view.FocusedRowHandle
            If rowHandle >= 0 Then
                Dim party = view.GetRowCellValue(rowHandle, "PartyName").ToString()
                _OutstangUnFoloSecondStage(party)
                e.Handled = True
            End If
        End If
    End Sub

#End Region


#Region "Outstanding DueDays Wise"
    Private Sub TodayDueBill_Click(sender As Object, e As EventArgs) Handles TodayDueBill.Click
        NoOfstage = 1
        GridControl3.MainView = GridView4

        LblSelectedOptionName.Text = "Today Due Bill (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionDashBordName = "Today Due Bill (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionOfView = "Outstanding"
        SelectionButton = "Today Due Bill"
        _RemarkLableNameChange()
        Pnl_Dashbord.Visible = False
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = True
        GridView1.OptionsBehavior.Editable = False
        OutstangPanelContrlVisable(True)
        _TileViewClickEvent()

        If _GetAllComOotstanding IsNot Nothing AndAlso _GetAllComOotstanding.Rows.Count > 0 Then
        Else
            Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
            Outstanding_Zooming_AllCompany.Txt_SideDayCarry.Text = "MANUAL"
            _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
        End If
        _OutstangTileView()
    End Sub
    Private Sub Btn_View_Click(sender As Object, e As EventArgs) Handles Btn_View.Click
        If SelectionButton = "Today Due Bill" Then
            _OutstangTileView()
        ElseIf SelectionButton = "Un Foloup Outstanding List" Then
            _OutstangUnFoloTileView("UnFoloOutstanding")
        End If

    End Sub
    Private Sub _OutstangTileView()
        If _GetAllComOotstanding.Rows.Count = 0 Then Exit Sub

        Dim query_1 = From row In _GetAllComOotstanding
                      Where row.Field(Of Integer)("Days") > txt_DefaltDays_Days.Text
                      Order By row.Field(Of String)("PartyName")
                      Group row By
                  GroupName = row.Field(Of String)("GroupName"),
                  PartyName = row.Field(Of String)("PartyName"),
                  PartyCity = row.Field(Of String)("PartyCity"),
                  AgentName = row.Field(Of String)("AgentName"),
                  AgentMob = row.Field(Of String)("AgentMob"),
                  DrCr = "",
                  TickMark = "False",
                  PartyMob = row.Field(Of String)("PartyMob")
              Into PartyNameGroup = Group
                      Select New With {
                  Key TickMark,
                  GroupName,
                  PartyName,
                  PartyCity,
                  PartyMob,
                  AgentName,
                  AgentMob,
                  .Balance = PartyNameGroup.Sum(Function(r) CDec(r("Balance"))),
                  .NoOfBill = PartyNameGroup.Count(Function(r) Not String.IsNullOrWhiteSpace(r("BillNo").ToString())),
                  DrCr
              }

        Dim _FirstStageTbl = LINQToDataTable(query_1)



        GridView4.Columns.Clear()
        GridControl3.DataSource = _FirstStageTbl.Copy


        GridView4.Columns("TickMark").Visible = False
        GridView4.Columns("DrCr").Visible = False

        DevGridFitColumn(GridControl3, GridView4)
        GridView4.Columns("PartyCity").Width = 60
        GridView4.Columns("GroupName").Width = 100

        GridView4.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
        GridControl3.Focus()
        GridView4.Focus()
        GridView4.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]

        GridView4.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Balance", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView4.Columns("Balance")})
        GridView4.Appearance.GroupRow.BackColor = Color.LightGreen
        'GridControl3.MainView = TileView1

        'TileView1.Columns.AddVisible("PartyName")
        'TileView1.Columns.AddVisible("Balance")
        'TileView1.Columns.AddVisible("Bill")
        ''tileView1.Columns.AddVisible("DueDays")

        'TileView1.TileTemplate.Clear()

        'Dim e1 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        'e1.Column = TileView1.Columns("PartyName")
        'e1.Text = "Party: {0}"
        'e1.RowIndex = 0
        'e1.ColumnIndex = 0
        'TileView1.TileTemplate.Add(e1)



        'Dim e2 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        'e2.Column = TileView1.Columns("Blank")
        'e2.Text = ""
        'e2.RowIndex = 1
        'e2.ColumnIndex = 0
        'TileView1.TileTemplate.Add(e2)

        'Dim e3 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        'e3.Column = TileView1.Columns("Balance")
        'e3.Text = "Due: ₹{1:n2}"
        'e3.RowIndex = 2
        'e3.ColumnIndex = 0
        'TileView1.TileTemplate.Add(e3)

        'Dim e4 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        'e4.Column = TileView1.Columns("Bill")
        'e4.Text = "Last Due: " & "{3}"
        'e4.RowIndex = 3
        'e4.ColumnIndex = 0
        'TileView1.TileTemplate.Add(e4)

        'TileView1.OptionsTiles.ItemSize = New Size(250, 100)

        ''tileView1.OptionsTiles.ItemSize = New Size(300, 120)  ' Width x Height
        'TileView1.OptionsTiles.RowCount = 0 ' Let it auto-fit
        'TileView1.OptionsTiles.Padding = New Padding(10)

        'GridControl3.Focus()
        'TileView1.Focus()
    End Sub
    Private Sub _GetTodayDueSecondStage(ByVal PartyName As String)
        Dim _tbl As New DataTable
        _tbl = _GetAllComOotstanding.Clone
        For Each dr As DataRow In _GetAllComOotstanding.Select("PartyName='" & PartyName & "' and Days > " & txt_DefaltDays_Days.Text & "")
            _tbl.ImportRow(dr)
        Next

        GridView1.Columns.Clear()



        Dim dataView As New DataView(_tbl)
        dataView.Sort = "AgentName,PartyName, BillDate, BillNo ASC"
        Dim dataTable As DataTable = dataView.ToTable()
        _tbl = dataView.ToTable()


        For Each dr As DataRow In _tbl.Select
            Dim Balance = Format(dr("Debit"), "0.00")
            dr("Debit") = Balance
            Balance = Format(dr("Credit"), "0.00")
            dr("Credit") = Balance
            Balance = Format(dr("Balance"), "0.00")
            dr("Balance") = Balance
            If Val(dr("Debit")) = 0 Then dr("Debit") = DBNull.Value
            If Val(dr("Credit")) = 0 Then dr("Credit") = DBNull.Value
            If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
        Next

        GridControl2.DataSource = _tbl.Copy

        GridView1.Columns("Debit").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridView1.Columns("Credit").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridView1.Columns("Balance").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far


        GridView1.Columns("Debit").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0}"))
        GridView1.Columns("Credit").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0}"))
        GridView1.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
        GridView1.Columns("PartyCity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PartyCity", "{0}"))


        GridView1.Columns("TickMark").Visible = False
        GridView1.Columns("Debit").Visible = False
        GridView1.Columns("Credit").Visible = False

        GridView1.Columns("D/C").Visible = False
        GridView1.Columns("ACCOUNTCODE").Visible = False
        GridView1.Columns("AGENTCODE").Visible = False
        GridView1.Columns("BOOKVNO").Visible = False
        GridView1.Columns("DataBaseName").Visible = False
        GridView1.Columns("RunBalance").Visible = False
        GridView1.Columns("AgentCity").Visible = False

        GridView1.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Balance").DisplayFormat.FormatString = "n2"

        GridView1.Columns("Debit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Debit").DisplayFormat.FormatString = "n2"

        GridView1.Columns("Credit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Credit").DisplayFormat.FormatString = "n2"

        DevGridFitColumn(GridControl2, GridView1)

        GridView1.Columns("GroupName").Width = 100
        GridView1.Columns("ComAlies").Width = 50

        GridControl2.Visible = True
        GridControl2.BringToFront()
        GridView1.Focus()

    End Sub
#End Region
#Region "Un Folo Outstanding"
    Private Sub UnFoloOutstanding_Click(sender As Object, e As EventArgs) Handles UnFoloOutstanding.Click
        NoOfstage = 1
        'GridControl3.MainView = GridView4
        TileView1 = New TileView(GridControl3)
        GridControl3.MainView = TileView1
        GridView1.OptionsBehavior.Editable = False

        LblSelectedOptionName.Text = "Un Foloup Outstanding List (F2=Add Bill Remark, Ctrl + F = Search)"
        SelectionDashBordName = "Un Foloup Outstanding List (F2=Add Bill Remark, Ctrl + F = Search)"
        SelectionOfView = "Outstanding"
        SelectionButton = "Un Foloup Outstanding List"
        _RemarkLableNameChange()
        Pnl_Dashbord.Visible = False
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = True
        OutstangPanelContrlVisable(True)
        _TileViewClickEvent()

        If _GetAllComOotstanding IsNot Nothing AndAlso _GetAllComOotstanding.Rows.Count > 0 Then
        Else
            Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
            Outstanding_Zooming_AllCompany.Txt_SideDayCarry.Text = "MASTER"
            _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
        End If

        _OutstangUnFoloTileView("UnFoloOutstanding")
    End Sub
    Private Sub _OutstangUnFoloTileView(ByVal _Filterstring As String)
        Try
            Dim _TempTbl As New DataTable
            _TempTbl = _FirstStageDataGAte(_Filterstring)

            If _TempTbl Is Nothing OrElse _TempTbl.Rows.Count = 0 Then Exit Sub

            Dim _GroupName As String = ""

            If Txt_GroupSelection.Text = "SELECT" Then

                sqL = Outstanding_Zooming_AllCompany._GetDebtorsCreditrGrup("DEBTORS")
                obj_Party_Selection.Multy_List_Load_Data()
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    _GroupName = " GroupName IN " & MULTY_SELECTION_COLOUM_1_DATA
                Else
                    Exit Sub
                End If
            End If

            'Dim query_1 = From row In _TempTbl.Select(_GroupName)
            '              Order By row.Field(Of Date)("BillDate") Descending
            '              Group row By PymtDate = row.Field(Of String)("F_BillDate")
            '      Into PartyNameGroup = Group
            '              Select New With {
            '          Key PymtDate,
            '          .Balance = PartyNameGroup.Sum(Function(r) CDec(r("Balance"))),
            '          .Bill = PartyNameGroup.Count(Function(r) Not String.IsNullOrWhiteSpace(r("PartyName").ToString()))
            '      }

            'Dim _FirstStageTbl = LINQToDataTable(query_1)


            Dim query_1 = From row In _TempTbl.Select(_GroupName)
                          Order By row.Field(Of Date)("BillDate") Descending
                          Group row By PymtDate = row.Field(Of String)("F_BillDate") Into PartyGroup = Group
                          Select New With {
                  Key PymtDate,
                  .Balance = PartyGroup.Sum(Function(r) CDec(r("Balance"))),
                   .Bill = PartyGroup.Select(Function(r) r.Field(Of String)("PartyName")).Distinct().Count()
              }

            Dim _FirstStageTbl = LINQToDataTable(query_1)



            'GridView4.Columns.Clear()
            'GridControl3.DataSource = _FirstStageTbl.Copy
            'GridView4.Columns("TickMark").Visible = False
            'GridView4.Columns("DrCr").Visible = False

            'DevGridFitColumn(GridControl3, GridView4)
            'GridView4.Columns("PartyCity").Width = 60
            'GridView4.Columns("GroupName").Width = 150
            'GridView4.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))





            GridControl3.DataSource = _FirstStageTbl.Copy
            GridControl3.MainView = TileView1


            TileView1.Columns.AddVisible("PymtDate")
            TileView1.Columns.AddVisible("Balance")
            TileView1.Columns.AddVisible("Bill")


            TileView1.TileTemplate.Clear()

            Dim e1 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
            e1.Column = TileView1.Columns("PymtDate")
            e1.Text = "{0}"
            e1.RowIndex = 0
            e1.ColumnIndex = 0
            TileView1.TileTemplate.Add(e1)


            Dim e2 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
            e2.Column = TileView1.Columns("Blank")
            e2.Text = ""
            e2.RowIndex = 1
            e2.ColumnIndex = 0
            TileView1.TileTemplate.Add(e2)

            Dim e3 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
            e3.Column = TileView1.Columns("Balance")
            e3.Text = "{1:n2}"
            e3.RowIndex = 2
            e3.ColumnIndex = 0
            TileView1.TileTemplate.Add(e3)

            Dim e4 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
            e4.Column = TileView1.Columns("Bill")
            e4.Text = "{3}"
            e4.RowIndex = 3
            e4.ColumnIndex = 0
            TileView1.TileTemplate.Add(e4)


            TileView1.OptionsTiles.ItemSize = New Size(150, 50)

            'tileView1.OptionsTiles.ItemSize = New Size(300, 120)  ' Width x Height
            TileView1.OptionsTiles.RowCount = 0 ' Let it auto-fit
            TileView1.OptionsTiles.Padding = New Padding(10)

            GridControl3.Focus()
            TileView1.Focus()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _OutstangUnFoloSecondStage(ByVal PartyName As String)
        Dim _tbl As New DataTable
        _tbl = _GetAllComOotstanding.Clone


        If SelectionButton = "Discount Foloup Outstanding List" Then
            Dim rows = From r In _GetAllComOotstanding.AsEnumerable()
                       Where r.Field(Of String)("F_BillDate") = PartyName _
                         AndAlso r.Field(Of String)("FoloDate") = "" _
                         AndAlso Val(r.Field(Of String)("SideDays")) > 0
                       Order By r.Field(Of String)("AgentName")

            For Each dr As DataRow In rows
                _tbl.ImportRow(dr)
            Next

        Else
            For Each dr As DataRow In _GetAllComOotstanding.Select("F_BillDate='" & PartyName & "' and FoloDate='' ", "AgentName")
                _tbl.ImportRow(dr)
            Next
        End If





        GridView1.Columns.Clear()


        Dim dataView As New DataView(_tbl)
        dataView.Sort = "AgentName,PartyName, BillDate, BillNo ASC"
        Dim dataTable As DataTable = dataView.ToTable()
        _tbl = dataView.ToTable()


        For Each dr As DataRow In _tbl.Select
            Dim Balance = Format(dr("Debit"), "0.00")
            dr("Debit") = Balance
            Balance = Format(dr("Credit"), "0.00")
            dr("Credit") = Balance
            Balance = Format(dr("Balance"), "0.00")
            dr("Balance") = Balance
            If Val(dr("Debit")) = 0 Then dr("Debit") = DBNull.Value
            If Val(dr("Credit")) = 0 Then dr("Credit") = DBNull.Value
            If Val(dr("Balance")) = 0 Then dr("Balance") = DBNull.Value
        Next

        GridControl2.DataSource = _tbl.Copy

        GridView1.Columns("Debit").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridView1.Columns("Credit").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        GridView1.Columns("Balance").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far


        GridView1.Columns("Debit").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0}"))
        GridView1.Columns("Credit").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0}"))
        GridView1.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
        GridView1.Columns("PartyCity").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PartyCity", "{0}"))


        GridView1.Columns("TickMark").Visible = False
        GridView1.Columns("Debit").Visible = False
        GridView1.Columns("Credit").Visible = False

        GridView1.Columns("D/C").Visible = False
        GridView1.Columns("ACCOUNTCODE").Visible = False
        GridView1.Columns("AGENTCODE").Visible = False
        GridView1.Columns("BOOKVNO").Visible = False
        GridView1.Columns("DataBaseName").Visible = False
        GridView1.Columns("RunBalance").Visible = False
        GridView1.Columns("AgentCity").Visible = False

        GridView1.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Balance").DisplayFormat.FormatString = "n2"

        GridView1.Columns("Debit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Debit").DisplayFormat.FormatString = "n2"

        GridView1.Columns("Credit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GridView1.Columns("Credit").DisplayFormat.FormatString = "n2"

        DevGridFitColumn(GridControl2, GridView1)
        GridView1.Columns("GroupName").Width = 100
        GridView1.Columns("ComAlies").Width = 50
        GridControl2.Visible = True
        GridControl2.BringToFront()
        GridView1.Focus()

    End Sub

#End Region

#Region "Discount Foloup Outstanding"
    Private Sub DiscountFoloOutstanding_Click(sender As Object, e As EventArgs) Handles DiscountFoloOutstanding.Click
        TileView1 = New TileView(GridControl3)
        GridControl3.MainView = TileView1
        NoOfstage = 1
        LblSelectedOptionName.Text = "Discount Foloup Outstanding List (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionDashBordName = "Discount Foloup Outstanding List (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionOfView = "Outstanding"
        SelectionButton = "Discount Foloup Outstanding List"
        _RemarkLableNameChange()
        Pnl_Dashbord.Visible = False
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = True
        GridView1.OptionsBehavior.Editable = False
        OutstangPanelContrlVisable(False)
        _TileViewClickEvent()

        PnlColoView.Visible = True

        If _GetAllComOotstanding IsNot Nothing AndAlso _GetAllComOotstanding.Rows.Count > 0 Then
        Else
            Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
            Outstanding_Zooming_AllCompany.Txt_SideDayCarry.Text = "MASTER"
            _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
        End If

        _OutstangUnFoloTileView("DiscountUnFoloOutstanding")
    End Sub


#End Region

#Region "Foloup Outstanding"

    Private Sub OutstandingDashBoard_Click(sender As Object, e As EventArgs) Handles FoloOutstanding.Click
        TileView1 = New TileView(GridControl3)
        GridControl3.MainView = TileView1
        NoOfstage = 1
        LblSelectedOptionName.Text = "Foloup Outstanding List (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionDashBordName = "Foloup Outstanding List (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionOfView = "Outstanding"
        SelectionButton = "Foloup Outstanding List"
        _RemarkLableNameChange()
        Pnl_Dashbord.Visible = False
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = True
        GridView1.OptionsBehavior.Editable = False
        OutstangPanelContrlVisable(False)
        _TileViewClickEvent()

        PnlColoView.Visible = True

        If _GetAllComOotstanding IsNot Nothing AndAlso _GetAllComOotstanding.Rows.Count > 0 Then
        Else
            Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
            Outstanding_Zooming_AllCompany.Txt_SideDayCarry.Text = "MASTER"
            _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
        End If

        _OutstangFoloTileView()
    End Sub
    Private Function _FirstStageDataGAte(ByVal _FilterType As String)

        If _GetAllComOotstanding.Rows.Count = 0 Then Exit Function

        Dim query_1 = From row In _GetAllComOotstanding
                      Where row.Field(Of String)("Folodate") > ""
                      Order By row.Field(Of String)("PartyName")
                      Group row By
                  GroupName = row.Field(Of String)("GroupName"),
                  PartyName = row.Field(Of String)("PartyName"),
                  PartyCity = row.Field(Of String)("PartyCity"),
                  PymtRem = row.Field(Of String)("PymtRem"),
                  AgentName = row.Field(Of String)("AgentName"),
                  AgentMob = row.Field(Of String)("AgentMob"),
                  AgentCity = row.Field(Of String)("AgentCity"),
                  PymtDate = row.Field(Of String)("PymtDate"),
                  BOOKVNO = row.Field(Of String)("BOOKVNO"),
                  Days = row.Field(Of Integer)("Days"),
                   PartyMob = row.Field(Of String)("PartyMob"),
                   ComAlies = row.Field(Of String)("ComAlies")
        Into PartyNameGroup = Group
                      Select New With {
                  Key GroupName, PartyName, PartyCity, PymtDate, BOOKVNO, Days, ComAlies,
                  PymtRem,
                  PartyMob, AgentName, AgentMob, AgentCity,
                  .Balance = PartyNameGroup.Sum(Function(r) CDec(r("Balance"))),
                  .Bill = PartyNameGroup.Count(Function(r) Not String.IsNullOrWhiteSpace(r("BillNo").ToString()))
                               }

        Dim _FirstStageTbl = LINQToDataTable(query_1)

        ' Step 1: Extract distinct BOOKVNO values from DataTable
        Dim bookvoList As String() = (From row In _FirstStageTbl
                                      Where Not IsDBNull(row("BOOKVNO")) AndAlso row("BOOKVNO").ToString.Trim() <> ""
                                      Select row("BOOKVNO").ToString.Trim()).Distinct().ToArray()

        ' Step 2: Build the SQL filter string with OR conditions
        Dim filterString As String = String.Join(" OR ", bookvoList.Select(Function(b) $"[BOOKVNO] = '{b.Replace("'", "''")}'"))
        Dim filterString_SingDate As String = String.Join(" OR ", bookvoList.Select(Function(b) $"T.[BOOKVNO] = '{b.Replace("'", "''")}'"))


        If filterString = "" Then Exit Function

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" T.PartyName ")
            .Append(" ,T.PartyMobNo as PartyMob  ")
            .Append(" ,T.AgentName  ")
            .Append(" ,T.AgentMobileNo as AgentMob ")
            .Append(" ,T.BillNo  ")
            .Append(" ,T.BillDate ")
            .Append(" ,0 as Days  ")
            .Append(" ,FORMAT(T.Amount, '0.00') as Balance ")
            .Append(" ,format(T.PaymentRemarkDate,'dd/MM/yyyy') as PymtDate ")
            .Append(" ,T.PaymentRemark as PymtRem ")
            .Append(" ,T.BOOKVNO ")
            .Append(" ,T.GRRemark ")
            .Append(" ,T.OtherRemark as OthRemark ")
            .Append(" ,T.[DataBase] as DataBaseName ")
            .Append(" ,T.ACCOUNTCODE ")
            .Append(" ,T.PaymentRemarkDate as Rmkdate ")
            .Append(" ,M.NoOfFolo ")
            .Append(" ,'' as ComAlies ")
            .Append(" ,'' as GroupName")
            .Append(" ,'' as PartyCity ")
            .Append(" ,'' as F_BillDate ")
            .Append(" FROM PaymentFolo as T ")
            .Append(" INNER JOIN ( ")
            .Append(" SELECT BOOKVNO, MAX(PaymentRemarkDate) AS MaxDate ")
            .Append(",count(bookvno ) as NoOfFolo ")
            .Append(" FROM PaymentFolo ")
            .Append(" GROUP BY BOOKVNO ")
            .Append(" ) AS M ON T.BOOKVNO = M.BOOKVNO AND T.PaymentRemarkDate = M.MaxDate ")
            .Append(" where  ")
            .Append("(" & filterString_SingDate & ")")

            If _FilterType = "PymtRem" Then
                .Append(" AND T.Folodate IS NOT NULL ")
                .Append(" and T.GRRemark = '' ")
                .Append(" and T.OtherRemark = '' ")
            ElseIf _FilterType = "GRRemark" Then
                .Append(" and T.GRRemark > '' ")
            ElseIf _FilterType = "OthRemark" Then
                .Append(" and T.OtherRemark > '' ")
            End If

            .Append(" ORDER BY T.PartyName,T.BillDate ")
        End With

        sqL = _strQuery.ToString
        PaymentFolo_QueryLoad()

        If _GetFnlOutFoloTbl IsNot Nothing AndAlso _GetFnlOutFoloTbl.Rows.Count > 0 Then
            _GetFnlOutFoloTbl.Clear()
        End If
        _GetFnlOutFoloTbl = DefaltSoftTable.Copy


        Dim _FIlterString As String = ""
        Dim _TempTbl As New DataTable

        If _FilterType = "UnFoloOutstanding" Or _FilterType = "DiscountUnFoloOutstanding" Then

            ' Step 1: Get all BOOKVNOs from _GetFnlOutFoloTbl into a HashSet
            Dim existingBookvnos As New HashSet(Of String)(
                From row In _GetFnlOutFoloTbl.AsEnumerable()
                Select row.Field(Of String)("BOOKVNO"))

            _GetFnlOutFoloTbl.Clear()
            ' Step 2: Loop _FirstStageTbl and transfer if BOOKVNO is not in existing list
            'For Each dr1 As DataRow In _GetAllComOotstanding.Select("", "Days Desc")
            '    Dim _billdate As String = dr1("BillDate").ToString

            '    Dim bookvno As String = dr1("BOOKVNO").ToString().Trim()
            '    If Not existingBookvnos.Contains(bookvno) Then
            '        _GetFnlOutFoloTbl.ImportRow(dr1)
            '    End If
            'Next

            For Each dr1 As DataRow In _GetAllComOotstanding.Select("", "Days Desc")
                Dim bookvno As String = dr1("BOOKVNO").ToString().Trim()
                If _FilterType = "UnFoloOutstanding" Then

                    If Not existingBookvnos.Contains(bookvno) Then
                        _GetFnlOutFoloTbl.ImportRow(dr1)
                    End If

                ElseIf _FilterType = "DiscountUnFoloOutstanding" Then
                    If dr1("SideDays") > 0 Then
                        Dim _billdate As Date
                        If Date.TryParse(dr1("BillDate").ToString(), _billdate) Then
                            Dim diffDays As Integer = (Date.Today - _billdate).Days
                            If diffDays <= dr1("SideDays") + 5 Then

                                If Not existingBookvnos.Contains(bookvno) Then
                                    _GetFnlOutFoloTbl.ImportRow(dr1)
                                End If
                            End If
                        End If
                    End If
                End If
            Next



            _TempTbl = _GetFnlOutFoloTbl.Copy
        Else

            For Each dr As DataRow In _GetFnlOutFoloTbl.Select
                _FIlterString = "BOOKVNO='" & dr("BOOKVNO").ToString & "'"
                For Each dr1 As DataRow In _FirstStageTbl.Select(_FIlterString)
                    dr("PartyName") = dr1("PartyName").ToString
                    dr("PartyMob") = dr1("PartyMob").ToString
                    dr("AgentName") = dr1("AgentName").ToString
                    dr("AgentMob") = dr1("AgentMob").ToString
                    dr("PartyCity") = dr1("PartyCity").ToString
                    dr("Days") = dr1("Days").ToString
                    dr("Balance") = dr1("Balance").ToString
                    dr("ComAlies") = dr1("ComAlies").ToString
                    dr("GroupName") = dr1("GroupName").ToString
                Next
            Next
            Dim query_2 = From row In _GetFnlOutFoloTbl
                          Order By row.Field(Of DateTime)("Rmkdate")
                          Group row By
                  PymtDate = row.Field(Of String)("PymtDate")
              Into PartyNameGroup = Group
                          Select New With {
                  Key PymtDate,
                  .Balance = PartyNameGroup.Sum(Function(r) CDec(r("Balance"))),
                  .Bill = PartyNameGroup.Count(Function(r) Not String.IsNullOrWhiteSpace(r("PartyName").ToString()))
              }

            _TempTbl = LINQToDataTable(query_2)
        End If

        Return _TempTbl
    End Function
    Private Sub _OutstangFoloTileView()

        Dim _TempTbl = _FirstStageDataGAte("PymtRem")

        If _TempTbl Is Nothing OrElse _TempTbl.Rows.Count = 0 Then Exit Sub



        GridControl3.DataSource = _TempTbl.Copy
        GridControl3.MainView = TileView1


        TileView1.Columns.AddVisible("PymtDate")
        TileView1.Columns.AddVisible("Balance")
        TileView1.Columns.AddVisible("Bill")


        TileView1.TileTemplate.Clear()

        Dim e1 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e1.Column = TileView1.Columns("PymtDate")
        e1.Text = "{0}"
        e1.RowIndex = 0
        e1.ColumnIndex = 0
        TileView1.TileTemplate.Add(e1)


        Dim e2 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e2.Column = TileView1.Columns("Blank")
        e2.Text = ""
        e2.RowIndex = 1
        e2.ColumnIndex = 0
        TileView1.TileTemplate.Add(e2)

        Dim e3 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e3.Column = TileView1.Columns("Balance")
        e3.Text = "{1:n2}"
        e3.RowIndex = 2
        e3.ColumnIndex = 0
        TileView1.TileTemplate.Add(e3)

        Dim e4 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e4.Column = TileView1.Columns("Bill")
        e4.Text = "{3}"
        e4.RowIndex = 3
        e4.ColumnIndex = 0
        TileView1.TileTemplate.Add(e4)


        TileView1.OptionsTiles.ItemSize = New Size(250, 100)

        'tileView1.OptionsTiles.ItemSize = New Size(300, 120)  ' Width x Height
        TileView1.OptionsTiles.RowCount = 0 ' Let it auto-fit
        TileView1.OptionsTiles.Padding = New Padding(10)

        GridControl3.Focus()
        TileView1.Focus()

    End Sub
    Private Sub _GetPymtRemarkSecondStage(ByVal PymtDate As String)
        Dim _tbl As New DataTable
        _tbl = _GetFnlOutFoloTbl.Clone
        For Each dr As DataRow In _GetFnlOutFoloTbl.Select("PymtDate='" & PymtDate & "'", "AgentName")
            _tbl.ImportRow(dr)
        Next

        GridView1.Columns.Clear()
        GridControl2.DataSource = _tbl.Copy
        ' Step 1: Create Dictionary to count BOOKVNOs




        GridView1.Columns("BOOKVNO").Visible = False
        GridView1.Columns("Rmkdate").Visible = False
        GridView1.Columns("GRRemark").Visible = False
        GridView1.Columns("OthRemark").Visible = False
        GridView1.Columns("DataBaseName").Visible = False
        GridView1.Columns("ACCOUNTCODE").Visible = False
        'GridView1.Columns("ComAlies").Visible = False

        DevGridFitColumn(GridControl2, GridView1)
        GridView1.Columns("GroupName").Width = 100
        GridView1.Columns("ComAlies").Width = 50
        'AddHandler GridView1.RowStyle, AddressOf GridView1_RowStyle

        GridView1.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
        GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
        GridControl2.Visible = True
        GridControl2.BringToFront()
        GridView1.Focus()

    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle

        If SelectionButton = "Today Due Bill" Or SelectionButton = "Un Foloup Outstanding List" Or SelectionButton = "Discount Foloup Outstanding List" Then Exit Sub

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If SelectionOfView = "Outstanding" Then
            If e.RowHandle >= 0 Then

                Dim bookvnoCountDict As New Dictionary(Of String, Integer)
                For Each dr As DataRow In _GetFnlOutFoloTbl.Rows
                    If Not IsDBNull(dr("BOOKVNO")) Then
                        Dim bookvno1 As String = dr("BOOKVNO").ToString().Trim()
                        If bookvnoCountDict.ContainsKey(bookvno1) Then
                            bookvnoCountDict(bookvno1) += 1
                        Else
                            bookvnoCountDict(bookvno1) = 1
                        End If
                    End If
                Next
                Dim count As Integer = view.GetRowCellValue(e.RowHandle, "NoOfFolo").ToString().Trim()

                With GridView1
                    .OptionsSelection.EnableAppearanceFocusedRow = False
                    .OptionsSelection.EnableAppearanceHideSelection = False
                    .OptionsSelection.EnableAppearanceFocusedCell = False
                End With

                ' Set row color based on count
                Select Case count
                    Case 1

                    Case 2
                        e.Appearance.BackColor = Color.LightGreen
                    Case 3
                        e.Appearance.BackColor = Color.Yellow
                    Case 4
                        e.Appearance.BackColor = Color.LightCoral
                    Case Is >= 5
                        e.Appearance.BackColor = Color.Red

                End Select
            End If

        ElseIf SelectionOfView = "Factory" Then

            If e.RowHandle < 0 Then Return ' skip header rows

            ' Get current value
            Dim beamValue As String = view.GetRowCellValue(e.RowHandle, "MainBeamBookvno")?.ToString().Trim()
            If String.IsNullOrEmpty(beamValue) Then Return

            ' Check if we already assigned a color for this value
            If Not BeamColorMap.ContainsKey(beamValue) Then
                ' Generate a random light color (to keep grid readable)
                Dim color As Color = color.FromArgb(255, Rnd.Next(180, 255), Rnd.Next(180, 255), Rnd.Next(180, 255))
                BeamColorMap(beamValue) = color
            End If

            ' Apply that color to this row
            e.Appearance.BackColor = BeamColorMap(beamValue)

        ElseIf SelectionOfView = "Process" Then
            If e.RowHandle >= 0 AndAlso e.Column.FieldName = "TypeOfBeam" Then
                Dim BeamType As String = view.GetRowCellValue(e.RowHandle, "TypeOfBeam").ToString().Trim()

                Select Case BeamType
                    Case "Requisition Beam"
                        e.Appearance.ForeColor = Color.DarkBlue
                    Case "Dyening Plan Beam"
                        e.Appearance.ForeColor = Color.Red
                End Select
            End If
        End If
    End Sub


#End Region
#Region "Gr Matter"
    Private Sub GRMatter_Click(sender As Object, e As EventArgs) Handles GRMatter.Click
        TileView1 = New TileView(GridControl3)
        NoOfstage = 1
        GridControl3.MainView = TileView1
        LblSelectedOptionName.Text = "GR Matter (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionDashBordName = "GR Matter (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionOfView = "Outstanding"
        SelectionButton = "GR Matter"
        _RemarkLableNameChange()
        Pnl_Dashbord.Visible = False
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = True
        GridView1.OptionsBehavior.Editable = False
        OutstangPanelContrlVisable(False)
        _TileViewClickEvent()
        PnlColoView.Visible = True
        If _GetAllComOotstanding IsNot Nothing AndAlso _GetAllComOotstanding.Rows.Count > 0 Then
        Else
            Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
            Outstanding_Zooming_AllCompany.Txt_SideDayCarry.Text = "MASTER"
            _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
        End If
        _GRTileView()
    End Sub
    Private Sub _GRTileView()

        Dim _TempTbl = _FirstStageDataGAte("GRRemark")

        If _TempTbl Is Nothing OrElse _TempTbl.Rows.Count = 0 Then Exit Sub



        GridControl3.DataSource = _TempTbl.Copy
        GridControl3.MainView = TileView1

        TileView1.Columns.AddVisible("PymtDate")
        TileView1.Columns.AddVisible("Balance")
        TileView1.Columns.AddVisible("Bill")


        TileView1.TileTemplate.Clear()

        Dim e1 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e1.Column = TileView1.Columns("PymtDate")
        e1.Text = "{0}"
        e1.RowIndex = 0
        e1.ColumnIndex = 0
        TileView1.TileTemplate.Add(e1)


        Dim e2 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e2.Column = TileView1.Columns("Blank")
        e2.Text = ""
        e2.RowIndex = 1
        e2.ColumnIndex = 0
        TileView1.TileTemplate.Add(e2)

        Dim e3 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e3.Column = TileView1.Columns("Balance")
        e3.Text = "{1:n2}"
        e3.RowIndex = 2
        e3.ColumnIndex = 0
        TileView1.TileTemplate.Add(e3)

        Dim e4 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e4.Column = TileView1.Columns("Bill")
        e4.Text = "{3}"
        e4.RowIndex = 3
        e4.ColumnIndex = 0
        TileView1.TileTemplate.Add(e4)


        TileView1.OptionsTiles.ItemSize = New Size(250, 100)

        'tileView1.OptionsTiles.ItemSize = New Size(300, 120)  ' Width x Height
        TileView1.OptionsTiles.RowCount = 0 ' Let it auto-fit
        TileView1.OptionsTiles.Padding = New Padding(10)

        GridControl3.Focus()
        TileView1.Focus()

    End Sub
    Private Sub _GrMatterSecondStage(ByVal PymtDate As String)
        Dim _tbl As New DataTable
        _tbl = _GetFnlOutFoloTbl.Clone
        For Each dr As DataRow In _GetFnlOutFoloTbl.Select("PymtDate='" & PymtDate & "' and GRRemark > ''", "AgentName")
            _tbl.ImportRow(dr)
        Next

        GridView1.Columns.Clear()
        GridControl2.DataSource = _tbl.Copy


        GridView1.Columns("BOOKVNO").Visible = False
        GridView1.Columns("Rmkdate").Visible = False
        GridView1.Columns("PymtRem").Visible = False
        GridView1.Columns("OthRemark").Visible = False
        GridView1.Columns("DataBaseName").Visible = False
        GridView1.Columns("ACCOUNTCODE").Visible = False
        'GridView1.Columns("ComAlies").Visible = False

        DevGridFitColumn(GridControl2, GridView1)
        GridView1.Columns("GroupName").Width = 100
        GridView1.Columns("ComAlies").Width = 50
        GridView1.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
        GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
        GridControl2.Visible = True
        GridControl2.BringToFront()
        GridView1.Focus()

    End Sub
#End Region
#Region "Other Remark"
    Private Sub OtherRemark_Click(sender As Object, e As EventArgs) Handles OtherRemark.Click
        NoOfstage = 1
        TileView1 = New TileView(GridControl3)
        GridControl3.MainView = TileView1
        LblSelectedOptionName.Text = "Other Matter (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionDashBordName = "Other Matter (F2=Add Bill Remark,Ctrl+F=Search)"
        SelectionOfView = "Outstanding"
        SelectionButton = "Other Matter"
        _RemarkLableNameChange()
        Pnl_Dashbord.Visible = False
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = True
        GridView1.OptionsBehavior.Editable = False
        OutstangPanelContrlVisable(False)
        _TileViewClickEvent()
        PnlColoView.Visible = True
        If _GetAllComOotstanding IsNot Nothing AndAlso _GetAllComOotstanding.Rows.Count > 0 Then
        Else
            Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
            Outstanding_Zooming_AllCompany.Txt_SideDayCarry.Text = "MASTER"
            _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
        End If
        _OthRemarkTileView()
    End Sub

    Private Sub _OthRemarkTileView()

        Dim _TempTbl = _FirstStageDataGAte("OthRemark")

        If _TempTbl Is Nothing OrElse _TempTbl.Rows.Count = 0 Then Exit Sub



        GridControl3.DataSource = _TempTbl.Copy
        GridControl3.MainView = TileView1

        TileView1.Columns.AddVisible("PymtDate")
        TileView1.Columns.AddVisible("Balance")
        TileView1.Columns.AddVisible("Bill")


        TileView1.TileTemplate.Clear()

        Dim e1 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e1.Column = TileView1.Columns("PymtDate")
        e1.Text = "{0}"
        e1.RowIndex = 0
        e1.ColumnIndex = 0
        TileView1.TileTemplate.Add(e1)


        Dim e2 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e2.Column = TileView1.Columns("Blank")
        e2.Text = ""
        e2.RowIndex = 1
        e2.ColumnIndex = 0
        TileView1.TileTemplate.Add(e2)

        Dim e3 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e3.Column = TileView1.Columns("Balance")
        e3.Text = "{1:n2}"
        e3.RowIndex = 2
        e3.ColumnIndex = 0
        TileView1.TileTemplate.Add(e3)

        Dim e4 As New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        e4.Column = TileView1.Columns("Bill")
        e4.Text = "{3}"
        e4.RowIndex = 3
        e4.ColumnIndex = 0
        TileView1.TileTemplate.Add(e4)


        TileView1.OptionsTiles.ItemSize = New Size(250, 100)

        'tileView1.OptionsTiles.ItemSize = New Size(300, 120)  ' Width x Height
        TileView1.OptionsTiles.RowCount = 0 ' Let it auto-fit
        TileView1.OptionsTiles.Padding = New Padding(10)

        GridControl3.Focus()
        TileView1.Focus()

    End Sub
    Private Sub _OthRemarkSecondStage(ByVal PymtDate As String)
        Dim _tbl As New DataTable
        _tbl = _GetFnlOutFoloTbl.Clone
        For Each dr As DataRow In _GetFnlOutFoloTbl.Select("PymtDate='" & PymtDate & "' and OthRemark > ''", "AgentName")
            _tbl.ImportRow(dr)
        Next

        GridView1.Columns.Clear()
        GridControl2.DataSource = _tbl.Copy

        GridView1.Columns("BOOKVNO").Visible = False
        GridView1.Columns("Rmkdate").Visible = False
        GridView1.Columns("PymtRem").Visible = False
        GridView1.Columns("GRRemark").Visible = False
        GridView1.Columns("DataBaseName").Visible = False
        GridView1.Columns("ACCOUNTCODE").Visible = False
        'GridView1.Columns("ComAlies").Visible = False
        DevGridFitColumn(GridControl2, GridView1)
        GridView1.Columns("GroupName").Width = 100
        GridView1.Columns("ComAlies").Width = 50
        GridView1.Columns("Balance").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0}"))
        GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
        GridControl2.Visible = True
        GridControl2.BringToFront()
        GridView1.Focus()

    End Sub

#End Region
    Private Sub Txt_Remark_3_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Remark_3.KeyDown

        If SelectionOfView = "Factory" Then
            If SelectionType = "BeamPlan" AndAlso NoOfstage = 1 Then
                If e.KeyCode = Keys.Enter Then
                    Party_selection.txtSearch.Text = Txt_Remark_3.Text
                    Dim _Filter As String = " AND B.ID ='" & FactoryActiveClmItemCode & "'"
                    _GetPlanningQuery(_Filter)
                    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                        Txt_Remark_3.Text = MULTY_SELECTION_COLOUM_1_DATA
                    End If
                    SendKeys.Send("{TAB}")
                End If

            End If
        End If
    End Sub

    Private Sub BtnRemarkClose_Click(sender As Object, e As EventArgs) Handles BtnRemarkClose.Click
        PnlRemark.Visible = False
        _RemarkPanelVisuable()
    End Sub
    Private Sub BtnRemarkSave_Click(sender As Object, e As EventArgs) Handles BtnRemarkSave.Click
        Try

            Generate_Date_For_DataBase(txtRemarkDate)


            'If SelectionOfView = "Process" Then
            '    If Txt_Remark_1.Text = "" Then
            '        MsgBox("Enter Beam No", MsgBoxStyle.Critical, "Soft-Tex PRO")
            '        Txt_Remark_1.Focus()
            '        Exit Sub
            '    End If
            '    If Txt_Remark_2.Text = "" Then
            '        MsgBox("Enter Shade", MsgBoxStyle.Critical, "Soft-Tex PRO")
            '        Txt_Remark_2.Focus()
            '        Exit Sub
            '    End If
            '    _SaveProcessChangeStage("Re Dyening")
            '    _RemarkPanelVisuable()
            If SelectionOfView = "Factory" Then
                If Txt_Remark_1.Text = "" Then
                    MsgBox("Enter Count Name", MsgBoxStyle.Critical, "Soft-Tex PRO")
                    Txt_Remark_1.Focus()
                    Exit Sub
                End If
                If Txt_Remark_2.Text = "" Then
                    MsgBox("Enter Qty", MsgBoxStyle.Critical, "Soft-Tex PRO")
                    Txt_Remark_2.Focus()
                    Exit Sub
                End If
                _RemarkPanelVisuable()
                If (SelectionType = "FactStkUse" Or SelectionType = "PurPlanQty") AndAlso NoOfstage = 2 Then
                    _PalanningYarnSave()
                ElseIf SelectionType = "BeamPlan" AndAlso NoOfstage = 1 Then
                    _NewBeamCreat()
                ElseIf (SelectionType = "WarpDate" Or SelectionType = "DrawDate" Or SelectionType = "Drawing" Or SelectionType = "PinDate" Or SelectionType = "Pinning" Or SelectionType = "LoomNo") AndAlso NoOfstage = 2 Then
                    _NewBeamCreat()

                End If


            Else
#Region "Outstanding"
                Dim FoloDate As String = ""
                If SelectionButton = "Today Due Bill" Or SelectionButton = "Un Foloup Outstanding List" Then
                    If GridView1.GetFocusedRowCellValue("FoloDate").ToString = "" Then
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "FoloDate", CDate(Date.Now).ToString("dd/MM/yyyy"))
                    End If
                    FoloDate = GridView1.GetFocusedRowCellValue("FoloDate").ToString
                Else
                    FoloDate = CDate(Date.Now).ToString("dd/MM/yyyy")
                End If

                If txtRemarkDate.Text.Trim = "" Then txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "PymtRem", Txt_Remark_1.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "PymtDate", txtRemarkDate.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "GRRemark", Txt_Remark_2.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "OthRemark", Txt_Remark_3.Text)

                Dim DataBaseName = GridView1.GetFocusedRowCellValue("DataBaseName").ToString
                Dim BOOKVNO As String = GridView1.GetFocusedRowCellValue("BOOKVNO").ToString
                Dim ACCOUNTCODE As String = GridView1.GetFocusedRowCellValue("ACCOUNTCODE").ToString
                Dim ComAlies As String = GridView1.GetFocusedRowCellValue("ComAlies").ToString
                Dim BillNo As String = GridView1.GetFocusedRowCellValue("BillNo").ToString
                Dim BillDate As String = GridView1.GetFocusedRowCellValue("BillDate").ToString

                Dim PymtRem As String = GridView1.GetFocusedRowCellValue("PymtRem").ToString
                Dim PymtDate As String = GridView1.GetFocusedRowCellValue("PymtDate").ToString
                Dim GRRemark As String = GridView1.GetFocusedRowCellValue("GRRemark").ToString
                Dim OthRemark As String = GridView1.GetFocusedRowCellValue("OthRemark").ToString
                Dim Balance As Double = GridView1.GetFocusedRowCellValue("Balance").ToString
                Dim PartyName As String = GridView1.GetFocusedRowCellValue("PartyName").ToString
                Dim PartyMob As String = GridView1.GetFocusedRowCellValue("PartyMob").ToString
                Dim AgentName As String = GridView1.GetFocusedRowCellValue("AgentName").ToString
                Dim AgentMob As String = GridView1.GetFocusedRowCellValue("AgentMob").ToString

                _strQuery = New StringBuilder
                With _strQuery
                    .Append(" INSERT INTO PaymentFolo ( ")
                    .Append(" [Database], bookvno, Accountcode, CompAlies, BillNo, BillDate, Amount, Folodate, PaymentRemark, PaymentRemarkDate, GrRemark, OtherRemark ")
                    .Append(" ,PartyName ")
                    .Append(" ,PartyMobNo ")
                    .Append(" ,AgentName ")
                    .Append(" ,AgentMobileNo ")
                    .Append(" ) VALUES ( ")
                    .Append(" '" & DataBaseName & "', ")
                    .Append(" '" & BOOKVNO & "', ")
                    .Append(" '" & ACCOUNTCODE & "', ")
                    .Append(" '" & ComAlies & "', ")
                    .Append(" '" & BillNo & "', ")
                    .Append(" '" & Format(CDate(BillDate), "yyyy-MM-dd") & "', ")
                    .Append(" '" & Val(Balance) & "', ")
                    .Append(" '" & Format(CDate(FoloDate), "yyyy-MM-dd") & "', ")
                    .Append(" '" & PymtRem & "', ")
                    .Append(" '" & Format(CDate(PymtDate), "yyyy-MM-dd") & "', ")
                    .Append(" '" & GRRemark & "', ")
                    .Append(" '" & OthRemark & "' ")
                    .Append(" ,'" & PartyName & "' ")
                    .Append(" ,'" & PartyMob & "' ")
                    .Append(" ,'" & AgentName & "' ")
                    .Append(" ,'" & AgentMob & "' ")
                    .Append(" ) ")
                End With
                sqL = _strQuery.ToString
                PaymentFolo_QuerySaveUpdateDelete()
                _GetAllComOotstanding.Clear()
                Outstanding_Zooming_AllCompany.Txt_EntryType.Text = "DEBTORS"
                _GetAllComOotstanding = Outstanding_Zooming_AllCompany._GetAllCompanyOutstanding("ALL")
                MsgBox("Remark Save Success", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
                PnlRemark.Visible = False
                GridControl2.Focus()

#End Region
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _NewBeamCreat()

        If Txt_Remark_2.Text.Trim = "" Then Txt_Remark_2.Text = 0
        If Txt_Remark_4.Text.Trim = "" Then Txt_Remark_4.Text = 1


        If LblRemarkHeader.Text = "Warping Entry" Then
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" UPDATE TRNBEAMHEADER SET ")
                .Append(" Beam_Length = '" & Txt_Remark_2.Text & "' ")
                .Append(" ,Warper_Code = '" & _RedyeningShadeCode & "' ")
                .Append(" ,WarpDate = '" & txtRemarkDate.Date_for_Database & "' ")
                .Append(" ,OP10 = 'WARPING' ")
                .Append(" WHERE SYNSTATUS='" & FilterBookVno & "' ")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")
            _GetBeamPlanQty(FactoryActiveClmItemCode, _CommanFilterString, "")
        ElseIf LblRemarkHeader.Text = "Drawer Entry" Then
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" UPDATE TRNBEAMHEADER SET ")
                .Append("  OP7 = '" & _RedyeningShadeCode & "' ")
                .Append(" ,OP6 = '" & txtRemarkDate.Text & "' ")
                .Append(" ,OP10 = 'DRAWING' ")
                .Append(" WHERE SYNSTATUS='" & FilterBookVno & "' ")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")
            _GetBeamPlanQty(FactoryActiveClmItemCode, _CommanFilterString, "")
        ElseIf LblRemarkHeader.Text = "Pinner Entry" Then

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" UPDATE TRNBEAMHEADER SET ")
                .Append("  OP9 = '" & _RedyeningShadeCode & "' ")
                .Append(" ,OP8 = '" & txtRemarkDate.Text & "' ")
                .Append(" ,OP10 = 'PINNING' ")
                .Append(" WHERE SYNSTATUS='" & FilterBookVno & "' ")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")
            _GetBeamPlanQty(FactoryActiveClmItemCode, _CommanFilterString, "")
        ElseIf LblRemarkHeader.Text = "Loom No Entry" Then
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" UPDATE TRNBEAMHEADER SET ")
                .Append("  LoomCode = '" & _RedyeningShadeCode & "' ")
                .Append(" ,Get_Date = '" & txtRemarkDate.Date_for_Database & "' ")
                .Append(" ,OP10 = 'ONLOOM' ")
                .Append(" WHERE SYNSTATUS='" & FilterBookVno & "' ")
            End With
            sqL = _strQuery.ToString
            sql_Data_Save_Delete_Update()
            MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")
            _GetBeamPlanQty(FactoryActiveClmItemCode, _CommanFilterString, "")
        Else

            If Txt_Remark_3.Text = "" Then
                MsgBox("Select Planning", MsgBoxStyle.Critical, "Soft-Tex PRO")
                Txt_Remark_3.Focus()
                Exit Sub
            End If


            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT TOP 1 isnull(A.ENTRYNO,0)+1 as ENTRYNO ")
                .Append(" FROM TRNBEAMHEADER AS A ")
                .Append(" ORDER BY A.ENTRYNO DESC ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim _ENtryNo As Int64 = 1
            If DefaltSoftTable.Rows.Count > 0 Then
                _ENtryNo = DefaltSoftTable.Rows(0).Item("ENTRYNO")
            End If



            Dim _planBookTrtype As String = "BM-E1"
            Dim _planBookcode As String = "0001-000000091"
            Dim _PlanBookVNo = Generate_Book_Vno(Val(_ENtryNo), _planBookTrtype)
            Dim DefineBeamNoDoubleSingle As String = _PlanBookVNo


            sqL = "SELECT*FROM MstItemBatchWise WHERE id ='" & Txt_Remark_3.Text & "'"
            sql_connect_slect()
            Dim _OwnJoB As String = DefaltSoftTable.Rows(0).Item("MINSALE").ToString
            Dim _Accountcode As String = DefaltSoftTable.Rows(0).Item("TAXSLAB").ToString
            Dim ItemCode As String = DefaltSoftTable.Rows(0).Item("GROUPNAME").ToString
            Dim DEsignCode As String = DefaltSoftTable.Rows(0).Item("COMPNAME").ToString
            Dim ShadeCode As String = DefaltSoftTable.Rows(0).Item("PRIMERUNIT").ToString
            Dim PlanningBookvno As String = DefaltSoftTable.Rows(0).Item("ITEMNAME").ToString



            sqL = "SELECT*FROM MstFabricItem WHERE ID ='" & FactoryActiveClmItemCode & "'"
            sql_connect_slect()
            Dim _MstItemTbl As New DataTable
            _MstItemTbl = DefaltSoftTable.Copy



            Dim Reed_Value As Double = 0
            Dim TotalEnds As Double = 0
            Dim Extra_Reed_Value As Double = 0
            Dim Dent_Value As Double = Val(_MstItemTbl.Rows(0).Item("OP22"))

            If Dent_Value > 2 Then
                Reed_Value = Val(_MstItemTbl.Rows(0).Item("REED")) / 2
                Extra_Reed_Value = Reed_Value * (Dent_Value - 2)
                Reed_Value = Val(_MstItemTbl.Rows(0).Item("REED")) + Extra_Reed_Value
            ElseIf Dent_Value = 2 Then
                Reed_Value = Val(_MstItemTbl.Rows(0).Item("REED")) / Val(_MstItemTbl.Rows(0).Item("OP22"))
            End If

            Dim RS_Value As Double = Val(_MstItemTbl.Rows(0).Item("OP23"))

            If Dent_Value = 2 Then
                TotalEnds = (Reed_Value * RS_Value) * 2
            Else
                TotalEnds = (Reed_Value * RS_Value)
            End If

            Dim loopCount As Integer
            If Integer.TryParse(Txt_Remark_4.Text, loopCount) Then
                For i As Integer = 1 To loopCount

                    _PlanBookVNo = Generate_Book_Vno(Val(_ENtryNo), _planBookTrtype)

                    _strQuery = New StringBuilder
                    With _strQuery
                        .Append(" INSERT INTO TRNBEAMHEADER ( ")
                        .Append(" ENTRYNO")
                        .Append(" ,BookTrtype")
                        .Append(" ,BookVno")
                        .Append(" ,BookCode")
                        .Append(" ,BeamNo")
                        .Append(" ,WarpDate")
                        .Append(", AccountCode")
                        .Append(", Fabric_ItemCode   ")
                        .Append(", Fabric_DesignCode   ")
                        .Append(", Fabric_ShadeCode  ")
                        .Append(", FabricDesignNo    ")
                        .Append(", FabricShadeNo")
                        .Append(", Beam_Length")
                        .Append(", Warper_Code")
                        .Append(", Beam_Avg_Wt")
                        .Append(", Own_Job  ")
                        .Append(", SU_SH")
                        .Append(", LoomCode ")
                        '.Append(", Get_Date ")
                        .Append(", Reed ")
                        .Append(", Dent1")
                        .Append(", Dent2")
                        .Append(", Dent3")
                        .Append(", Pick_On_Loom ")
                        .Append(", Reed_Space ")
                        .Append(", Pick_Rate  ")
                        .Append(", Mending_Rate ")
                        .Append(", Total_Ends ")
                        .Append(", Shrink_Per ")
                        .Append(", Yarn_West_Per")
                        .Append(", OP3")
                        .Append(", Modvat   ")
                        .Append(", FactoryCode")
                        .Append(", SelvCode ")
                        .Append(", OP5 ") ' plan date
                        .Append(", OP4 ")
                        .Append(", OP6 ")
                        .Append(", OP8 ")
                        .Append(", OP10 ")
                        .Append(", SYNSTATUS ")
                        .Append(", OP16 ")

                        .Append(" ) VALUES (")
                        .Append(" '" & _ENtryNo & "'")
                        .Append(" ,'" & _planBookTrtype & "'")
                        .Append(" ,'" & _PlanBookVNo & "'")
                        .Append(" ,'" & _planBookcode & "'")
                        .Append(" ,'" & _ENtryNo & "'")
                        .Append(" ,'" & txtRemarkDate.Date_for_Database & "'")
                        .Append(" ,'" & _Accountcode & "'")
                        .Append(" ,'" & FactoryActiveClmItemCode & "'")
                        .Append(" ,'" & DEsignCode & "'")
                        .Append(" ,'" & ShadeCode & "'")
                        .Append(" ,'.'")
                        .Append(" ,'.'")
                        .Append(" ,'" & Txt_Remark_2.Text & "'")
                        .Append(" ,'0000-000000001'")
                        .Append(" ,'" & _MstItemTbl.Rows(0).Item("WTPERMTR") & "'")
                        .Append(" ,'" & _OwnJoB & "'")
                        .Append(" ,'SUITING'")
                        .Append(" ,'0000-000000001'")
                        .Append(" ,'" & _MstItemTbl.Rows(0).Item("REED") & "'")
                        .Append(" ,'" & _MstItemTbl.Rows(0).Item("OP22") & "'") 'DENT
                        .Append(" ,'1'") 'DENT
                        .Append(" ,'1'") 'DENT
                        .Append(" ,'" & _MstItemTbl.Rows(0).Item("PICK") & "'")
                        .Append(" ,'" & _MstItemTbl.Rows(0).Item("OP23") & "'")
                        .Append(" ,'0'")
                        .Append(" ,'0'")
                        .Append(" ,'" & TotalEnds & "'")
                        .Append(" ,'0'")
                        .Append(" ,'0'")
                        .Append(" ,'" & Txt_Remark_3.Text & "'")
                        .Append(" ,'FLOOR'")
                        .Append(" ,'0000-000000001'")
                        .Append(" ,'0000-000000001'")
                        .Append(" ,'" & txtRemarkDate.Text & "'")
                        .Append(" ,'FOLDING'")
                        .Append(" ,''")
                        .Append(" ,''")
                        .Append(" ,'PLANNING'")
                        .Append(" ,'" & DefineBeamNoDoubleSingle & "'")
                        .Append(" ,'" & PlanningBookvno & "'")

                        .Append(" ) ")
                    End With
                    sqL = _strQuery.ToString
                    sql_Data_Save_Delete_Update()
                    _ENtryNo += 1
                Next
                MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")

            Else
                MsgBox("Please enter a valid Width etc...(1,2,3,4)", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            End If

            _FactoryDesbordLoad()
        End If

    End Sub
    Private Sub _PalanningYarnSave()

        Dim _planBookcode As String = "YRNPL-000000001"
        Dim _planBookTrtype As String = "YPN01"
        Dim _StockType As String = ""

        If SelectionType = "FactStkUse" Then
            _StockType = "FACTORY STOCK"
        ElseIf SelectionType = "PurPlanQty" Then
            _StockType = "PURCHASE"
        End If

        Dim _Accountcode As String = ""
        Dim _OwnJob As String = ""
        Dim PlanningBookvno As String = ""
        sqL = "SELECT* FROM MstItemBatchWise WHERE ID='" & FactoryPlaningNo & "'"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _Accountcode = DefaltSoftTable.Rows(0).Item("TAXSLAB").ToString
            _OwnJob = DefaltSoftTable.Rows(0).Item("MINSALE").ToString
            PlanningBookvno = DefaltSoftTable.Rows(0).Item("ITEMNAME").ToString
        End If


        Dim _MaxEntryNo As Integer = 1
        sqL = " SELECT TOP 1 ENTRYNO FROM TRNOFFER WHERE BOOKCODE='" & _planBookcode & "' ORDER BY ENTRYNO DESC"
        sql_connect_slect()
        If DefaltSoftTable.Rows.Count > 0 Then
            _MaxEntryNo = DefaltSoftTable.Rows(0).Item("ENTRYNO") + 1
        End If

        Dim _PlanBookVNo = Generate_Book_Vno(Val(_MaxEntryNo), _planBookTrtype)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" INSERT INTO TRNOFFER ( ")
            .Append(" ENTRYNO")
            .Append(" ,BookTrtype")
            .Append(" ,BookVno")
            .Append(" ,BookCode")
            .Append(" ,OfferDate")
            .Append(" ,SRNO")
            .Append(" ,ItemCode")
            .Append(" ,Descr")
            .Append(" ,Mtr_Weight")
            .Append(" ,OfferNo")
            .Append(" ,ACCOUNTCODE")
            .Append(" ,LOTNO")
            .Append(" ,AgentOfferNo")
            .Append(" ) VALUES (")
            .Append(" '" & _MaxEntryNo & "'")
            .Append(" ,'" & _planBookTrtype & "'")
            .Append(" ,'" & _PlanBookVNo & "'")
            .Append(" ,'" & _planBookcode & "'")
            .Append(" ,'" & txtRemarkDate.Date_for_Database & "'")
            .Append(" ,1")
            .Append(" ,'" & FactoryYarnCountCode & "'")
            .Append(" ,'" & _StockType & "'")
            .Append(" ,'" & Val(Txt_Remark_2.Text) & "'")
            .Append(" ,'" & FactoryPlaningNo & "'")
            .Append(" ,'" & _Accountcode & "'")
            .Append(" ,'" & _OwnJob & "'")
            .Append(" ,'" & PlanningBookvno & "'")
            .Append(" )")
        End With
        sqL = _strQuery.ToString
        sql_Data_Save_Delete_Update()

        MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")

        If FactoryActiveClmName = "YarnRequire" AndAlso FactoryActiveClmItemCode > "" Then
            _GetYarnRequirQty(FactoryActiveClmItemCode)
        End If

    End Sub

#End Region

#Region "Factory Menu"
    Private Sub _ProcessStkLblDiplay(ByVal _Visuable As Boolean)
        Lbl_ProcessStk.Visible = _Visuable
        Txt_ProcessStockDisplay.Visible = _Visuable
        'BtnProcessRefresh.Visible = _Visuable
        BtnGridPrint.Visible = _Visuable
        BtnProcessDetailPrint.Visible = _Visuable

    End Sub
    Private Sub FactoryDashbord_Click(sender As Object, e As EventArgs) Handles FactoryDashbord.Click
        LblSelectedOptionName.Text = "Factory DashBoard"
        SelectionDashBordName = "Factory DashBoard"
        SelectionOfView = "Factory"
        SelectionButton = ""
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = False
        GridView1.OptionsBehavior.Editable = False
        PnlColoView.Visible = False
        _RemarkLableNameChange()



        _ProcessStkLblDiplay(False)
        _FactoryDesbordLoad()

    End Sub
    Private Sub ProdDashBoard_Click(sender As Object, e As EventArgs) Handles ProdDashBoard.Click
        LblSelectedOptionName.Text = "Factory Producation DashBoard"
        SelectionDashBordName = "Producation DashBoard"
        SelectionOfView = "Producation DashBoard"
        SelectionButton = ""
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = False
        GridView1.OptionsBehavior.Editable = False
        PnlColoView.Visible = False
        _RemarkLableNameChange()
        _ProcessStkLblDiplay(False)
        _ProducationDesbordLoad()
    End Sub
    Private Sub CreatNewItem_Click(sender As Object, e As EventArgs) Handles YarnPlanning.Click
        'ShowFormMDI(New YarnPlaningEntry)
        YarnPlaningEntry.ShowDialog()
    End Sub
    Private Sub YarnPurOrderPlan_Click(sender As Object, e As EventArgs) Handles YarnPurOrderPlan.Click
        'ShowFormMDI(New YarnPurchasesPlaningDisplay)
        YarnPurchasesPlaningDisplay.ShowDialog()
    End Sub
    Private Sub NewQualityPlan_Click(sender As Object, e As EventArgs) Handles NewQualityPlan.Click
        SelectionOfView = "Factory"
        NewQualityPlanEntry.ShowDialog()
    End Sub
    Private Sub JobOrderEntry_Click(sender As Object, e As EventArgs) Handles JobOrderEntry.Click
        LEDGER_ENTER_DISPLAY_FROM = "_CallOther"
        'ShowFormMDI(New Job_Order)
    End Sub
    Private Sub GreyOrder_Click(sender As Object, e As EventArgs) Handles GreyOrder.Click
        LEDGER_ENTER_DISPLAY_FROM = "_CallOther"
        'ShowFormMDI(New Gray_order)
    End Sub
    Private Sub YarnOrder_Click(sender As Object, e As EventArgs) Handles YarnOrder.Click
        LEDGER_ENTER_DISPLAY_FROM = "_CallOther"
        'ShowFormMDI(New Yarn_order)
    End Sub
    Public Function GetRequrYarnQuery() As String
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            .Append(" A.ITEMNAME AS bookvno ")
            .Append(" ,C.CountCode   ")
            .Append(" ,(CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)))* ISNULL(C.Avg_weight,0) as RequirQty ")
            .Append(" ,0.00 PlanQty ")
            .Append(" ,0.00 FactStkUse ")
            .Append(" ,0.00 PurchPlan ")
            .Append(" ,0.00 PurchOrder ")
            .Append(" FROM MstItemBatchWise AS A  ")
            .Append(" LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID  ")
            .Append(" LEFT JOIN MstFabricItemCons AS C ON A.GROUPNAME=C.Fabric_ItemCode  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND MRP='NO'   ")
            .Append(" AND A.SHORTNAME='NEW QUALITY PLANNING' ")
            .Append(" UNION ALL ")
            .Append(" SELECT  ")
            .Append(" A.AgentOfferNo AS bookvno ")
            .Append(" ,a.ItemCode as CountCode   ")
            .Append(" ,0.00 as RequirQty ")
            .Append(" ,ISNULL(sum(a.Mtr_Weight),0)  PlanQty ")
            .Append(" ,0.00 FactStkUse ")
            .Append(" ,0.00 PurchPlan ")
            .Append(" ,0.00 PurchOrder ")
            .Append(" FROM TrnOffer  AS A  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND DESCR in ('PURCHASE','FACTORY STOCK')")
            .Append(" AND Bookcode='YRNPL-000000001'   ")
            .Append(" GROUP BY  ")
            .Append(" A.AgentOfferNo ")
            .Append(" ,a.ItemCode ")
        End With
        Return _strQuery.ToString
    End Function
    Private Sub _FactoryDesbordLoad()

        Dim _PlanningFilter As String = " AND A.MRP='NO'  AND A.SHORTNAME='NEW QUALITY PLANNING' "

        Dim YarnReqQtyQuery As String = GetRequrYarnQuery()


        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" Z.ItemCode")
            .Append(" ,A.ITENNAME as ItemName")
            .Append(" ,SUM(Z.PlanningQty)-(SUM(Z.JobOrder)+SUM(Z.GreyOrder)+SUM(Z.OwnBeamPlanQty)) AS PlanningQty")
            .Append(" ,IIF(SUM(Z.JobOrder)>0,SUM(Z.JobOrder)- SUM(Z.JobBeamPlanQty),0) as JobOrder")
            .Append(" ,IIF(SUM(Z.GreyOrder)>0,SUM(Z.GreyOrder)-(SUM(Z.OwnBeamPlanQty)+ SUM(Z.JobBeamPlanQty)),0) as GreyOrder")
            .Append(" ,SUM(Z.YarnRequire) as YarnRequire")
            .Append(" ,SUM(Z.YarnPlan)-SUM(Z.YarnOrder) as YarnPlan")
            .Append(" ,SUM(Z.YarnInStk) as YarnInStk")
            .Append(" ,IIF ( SUM(Z.YarnOrder)-SUM(Z.YarnRecived) > 0,SUM(Z.YarnOrder)-SUM(Z.YarnRecived),0) as YarnOrder")
            .Append(" ,SUM(Z.YarnRecived) as YarnRecived")
            .Append(" ,(SUM(Z.OwnBeamPlanQty)+ SUM(Z.JobBeamPlanQty)) as BeamPlan")

            .Append(" ,SUM(Z.PlBM) AS PlBM ")
            .Append(" ,SUM(Z.WpBM) AS WpBM ")
            .Append(" ,SUM(Z.DrBM) AS DrBM ")
            .Append(" ,SUM(Z.PinBM) AS PinBM ")
            .Append(" ,SUM(Z.OnLmBM) AS OnLmBM ")
            .Append(" ,SUM(Z.SinFloor) AS SinFloor ")
            .Append(" ,SUM(Z.DoubFloor) AS DoubFloor ")
            .Append(" ,SUM(Z.SinFall) AS SinFall ")
            .Append(" ,SUM(Z.DoubFall) AS DoubFall ")

            .Append(" ,SUM(Z.FoldingQty) as FoldingQty")
            .Append(" ,SUM(Z.DespatchQty) as DespatchQty")
            .Append(" ,SUM(Z.FoldingQty)-SUM(Z.DespatchQty) as FactStock")
            .Append(" ,SUM(Z.YarnConsumQty) as YarnConsumQty")
            .Append(" ,SUM(Z.YarnRecived)-SUM(Z.YarnConsumQty) as YarnBalQty")

            .Append(" FROM ( ")

#Region "Planning Data"
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)) AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.SHORTNAME='NEW QUALITY PLANNING'")
#End Region

#Region "JOb Order Data"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,B.Mtr_Weight as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnOffer AS B ON A.ITEMNAME=B.AgentOfferNo ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND A.GROUPNAME=B.ItemCode ")
            .Append(" AND A.ITEMNAME=B.AgentOfferNo ")
            .Append(" AND C.BOOKCATEGORY='OFFER' AND C.BEHAVIOUR='JOB-WEAVING' ")
            .Append(_PlanningFilter)

#End Region

#Region "Grey Order Data"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,B.Mtr_Weight as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnOffer AS B ON A.ITEMNAME=B.AgentOfferNo ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND A.GROUPNAME=B.ItemCode ")
            .Append(" AND A.ITEMNAME=B.AgentOfferNo ")
            .Append(" AND C.BOOKCATEGORY='OFFER' AND C.BEHAVIOUR='GREY' ")
            .Append(_PlanningFilter)
#End Region

#Region "Yarn Req Qty"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.ItemCode")
            .Append(" ,A.DesignCode")
            .Append(" ,A.Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.00 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,sum(z.RequirQty)-SUM(z.PlanQty) as RequirQty ")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM ( ")
            .Append(YarnReqQtyQuery)
            .Append(" ) AS Z ")
            .Append(" LEFT JOIN MstYarnCount AS D ON z.CountCode=D.CountCode  ")
            .Append(" left join (SELECT ID,HSNCODE as PlanDate,GROUPNAME AS ItemCode,COMPNAME AS DesignCode,PRIMERUNIT AS Shadecode,SHORTNAME,MRP,ITEMNAME FROM MstItemBatchWise GROUP BY ID,HSNCODE,GROUPNAME,COMPNAME,PRIMERUNIT,SHORTNAME,MRP,ITEMNAME) AS A ON  Z.bookvno =A.ITEMNAME  ")
            .Append(_PlanningFilter)
            .Append(" GROUP BY ")
            .Append("  A.ItemCode")
            .Append(" ,A.DesignCode")
            .Append(" ,A.Shadecode")
            .Append(" HAVING sum(z.RequirQty )-SUM(z.PlanQty )>0 ")


#End Region

#Region "Yarn Plan Data"
            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,ISNULL((F.Mtr_Weight),0) as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN MstYarnCount AS D ON B.CountCode=D.CountCode ")
            .Append(" LEFT JOIN TrnOffer AS F  ON (A.ITEMNAME=F.AgentOfferNo AND B.CountCode = F.ITEMCODE AND F.BookCode ='YRNPL-000000001' AND F.DESCR='PURCHASE' AND F.accountcode=a.TAXSLAB)")
            .Append(" WHERE 1=1")
            .Append(" AND ISNULL((F.Mtr_Weight),0)>0 ")
            .Append(_PlanningFilter)
            .Append(" AND A.MRP='NO'  ")

#End Region

#Region "Yarn Order Data"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,F.Mtr_Weight as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN TrnOffer AS F  ON B.CountCode=F.ITEMCODE")
            '.Append(" LEFT JOIN TrnOffer AS G  ON F.LOOM_TYPE=G.BOOKVNO ")
            .Append(" LEFT JOIN MSTBOOK AS C ON F.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            '.Append(" AND G.ITEMCODE=F.ITEMCODE ")
            .Append(" AND F.accountcode=a.TAXSLAB ")
            .Append(" AND B.CountCode=F.ITEMCODE ")
            .Append(" AND F.DESCR in ('YARN PLANNING ENTRY')")
            .Append(" AND F.Bookcode='YRNPO-000000002'   ")
            .Append(" AND F.OFFERNO > '0'   ")
            .Append(" AND ISNULL((F.Mtr_Weight),0)>0 ")
            '.Append(" AND C.BOOKCATEGORY='OFFER' AND C.BEHAVIOUR='YARN' ")
            .Append(_PlanningFilter)
#End Region

#Region "Yarn Recived Data"

            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" A.GROUPNAME AS ItemCode ")
            .Append(" ,A.COMPNAME AS DesignCode ")
            .Append(" ,A.PRIMERUNIT AS Shadecode ")
            .Append(" ,0.00 AS PlanningQty ")
            .Append(" ,0.00 as JobOrder ")
            .Append(" ,0.00 as GreyOrder ")
            .Append(" ,0.000 as YarnPlan ")
            .Append(" ,0.000 as YarnOrder ")
            .Append(" ,D.ACTUAL_WEIGHT as YarnRecived ")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty ")
            .Append(" ,0.00 as DespatchQty ")
            .Append(" ,0.00 as FactStock ")
            .Append(" ,0.000 as YarnBalQty ")
            .Append(" ,0.000 as YarnConsumQty ")
            .Append(" ,0.000 as YarnInStk ")
            .Append(" ,0.000 as YarnRequire ")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN TrnOffer AS F  ON B.CountCode=F.ITEMCODE")
            .Append(" LEFT JOIN TrnOffer AS E  ON F.LOOM_TYPE=E.BOOKVNO")
            .Append(" LEFT JOIN MSTBOOK AS C ON F.BOOKCODE=C.BOOKCODE ")
            .Append(" LEFT JOIN TrnFactoryYarn AS D ON ( D.OFFERBOOKVNO=F.BOOKVNO AND  F.ITEMCODE=D.COUNTCODE) ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.MINSALE <> 'JOB RCPT' ")
            .Append(" AND E.ITEMCODE=F.ITEMCODE ")
            .Append(" AND E.OFFERNO=A.ID")
            .Append(" AND F.DESCR in ('YARN PLANNING ENTRY')")
            .Append(" AND D.OFFERBOOKVNO=F.BOOKVNO ")
            .Append(" AND E.ITEMCODE=D.COUNTCODE ")
            .Append(" AND E.BOOKVNO >'' ")
            .Append(_PlanningFilter)


            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" A.GROUPNAME AS ItemCode ")
            .Append(" ,A.COMPNAME AS DesignCode ")
            .Append(" ,A.PRIMERUNIT AS Shadecode ")
            .Append(" ,0.00 AS PlanningQty ")
            .Append(" ,0.00 as JobOrder ")
            .Append(" ,0.00 as GreyOrder ")
            .Append(" ,0.000 as YarnPlan ")
            .Append(" ,0.000 as YarnOrder ")
            .Append(" ,D.ACTUAL_WEIGHT as YarnRecived ")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty ")
            .Append(" ,0.00 as DespatchQty ")
            .Append(" ,0.00 as FactStock ")
            .Append(" ,0.000 as YarnBalQty ")
            .Append(" ,0.000 as YarnConsumQty ")
            .Append(" ,0.000 as YarnInStk ")
            .Append(" ,0.000 as YarnRequire ")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN TrnFactoryYarn AS D ON ( D.OFFERBOOKVNO=A.ITEMNAME AND  B.CountCode=D.COUNTCODE) ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.MINSALE='JOB RCPT' ")
            .Append(" AND D.OFFERBOOKVNO=A.ITEMNAME ")
            .Append(" AND B.CountCode=D.COUNTCODE ")
            .Append(" AND D.OFFERBOOKVNO >'' ")
            .Append(_PlanningFilter)

#End Region

#Region "PBeam Plan Data"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,IIF (B.Own_Job='OWN',B.Beam_Length,0) as OwnBeamPlanQty")
            .Append(" ,IIF (B.Own_Job='JOB',B.Beam_Length,0) as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16 ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND A.ITEMNAME=B.OP16")
            .Append(_PlanningFilter)
#End Region

#Region "Beam Stage"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,IIF(B.OP10='PLANNING',COUNT(B.ENTRYNO),0) AS PlBM ")
            .Append(" ,IIF(B.OP10='WARPING',COUNT(B.ENTRYNO),0) AS WpBM ")
            .Append(" ,IIF(B.OP10='DRAWING',COUNT(DISTINCT B.SYNSTATUS),0) AS DrBM ")
            .Append(" ,IIF(B.OP10='PINNING',COUNT(DISTINCT B.SYNSTATUS),0)AS PinBM ")
            .Append(" ,IIF(B.OP10='ONLOOM',COUNT(DISTINCT B.SYNSTATUS),0) AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,0.00 AS SinFall ")
            .Append(" ,0.00 AS DoubFall ")

            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16 ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND A.ITEMNAME=B.OP16")
            .Append(_PlanningFilter)

            .Append("  GROUP BY ")
            .Append("  A.GROUPNAME ")
            .Append(" ,A.COMPNAME ")
            .Append(" ,A.PRIMERUNIT ")
            .Append(" ,B.OP10 ")
#End Region

#Region "Beam Stage"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.GROUPNAME AS ItemCode ")
            .Append(" ,A.COMPNAME AS DesignCode ")
            .Append(" ,A.PRIMERUNIT AS Shadecode ")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append("  ,SUM(CASE WHEN B.OP10='PINNING' AND SYN_COUNT = 1 THEN 1 ELSE 0 END) AS SinFloor")
            .Append("  ,SUM(CASE WHEN B.OP10='PINNING' AND SYN_COUNT = 2 THEN 1 ELSE 0 END) AS DoubFloor ")
            .Append("  ,0.00 AS SinFall ")
            .Append("  ,0.00 AS DoubFall ")

            .Append(" FROM ( ")
            .Append("       SELECT B.OP3,B.BOOKCODE, B.OP10 , B.SYNSTATUS, COUNT( B.SYNSTATUS) AS SYN_COUNT,B.OP16 ")
            .Append("      FROM TrnBeamHeader B ")
            .Append("      WHERE B.OP10='PINNING' ")
            .Append("      GROUP BY B.OP3,B.BOOKCODE, B.OP10 , B.SYNSTATUS ,B.OP16")
            .Append(" ) B ")
            .Append(" RIGHT JOIN MstItemBatchWise A ON A.ITEMNAME=B.OP16 ")
            .Append(" LEFT JOIN MSTBOOK C ON B.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1 ")
            .Append(_PlanningFilter)
            .Append(" GROUP BY A.GROUPNAME, A.COMPNAME, A.PRIMERUNIT, B.OP10 ")

#End Region


#Region "Beam Falling Data"

            .Append(" UNION ALL ")

            .Append(" SELECT   ")
            .Append(" x.ItemCode ")
            .Append(" ,x.DesignCode")
            .Append(" ,x.Shadecode ")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,0.00 as JobOrder")
            .Append(" ,0.00 as GreyOrder")
            .Append(" ,0.000 as YarnPlan")
            .Append(" ,0.000 as YarnOrder")
            .Append(" ,0.000 as YarnRecived")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" ,0.00 as FoldingQty")
            .Append(" ,0.00 as DespatchQty")
            .Append(" ,0.00 as FactStock")
            .Append(" ,0.000 as YarnBalQty")
            .Append(" ,0.000 as YarnConsumQty")
            .Append(" ,0.000 as YarnInStk")
            .Append(" ,0.000 as YarnRequire")
            .Append(" ,0.00 AS PlBM ")
            .Append(" ,0.00 AS WpBM ")
            .Append(" ,0.00 AS DrBM ")
            .Append(" ,0.00 AS PinBM ")
            .Append(" ,0.00 AS OnLmBM ")
            .Append(" ,0.00 AS SinFloor ")
            .Append(" ,0.00 AS DoubFloor ")
            .Append(" ,SUM(CASE WHEN x.LoomWidth = 1 THEN 1 ELSE 0 END) AS SinFall ")
            .Append(" ,SUM(CASE WHEN x.LoomWidth = 2 THEN 1 ELSE 0 END) AS DoubFall ")

            .Append(" FROM (  ")
            .Append(" SELECT  ")
            .Append(" A.GROUPNAME AS ItemCode, ")
            .Append(" A.COMPNAME AS DesignCode, ")
            .Append(" A.PRIMERUNIT AS Shadecode, ")
            .Append(" B.Beam_Length,  ")
            .Append(" B.SYNSTATUS AS BeamPlan,  ")
            .Append(" B.BEAMNO, ")
            .Append(" SUM(D.Prod_Mtr) AS TotalProdMtr, ")
            .Append(" MAX(D.Log_Book_Date) AS LastLogDate,   ") ' last entry date
            .Append(" DATEADD(DAY,  ")
            .Append(" CASE WHEN SUM(D.Prod_Mtr) > 0  ")
            .Append(" THEN (B.Beam_Length / SUM(D.Prod_Mtr))  ")
            .Append(" ELSE 0 END,  ")
            .Append(" MAX(D.Log_Book_Date)) AS SinFallDate ")
            .Append(" ,E.width AS LoomWidth ")
            .Append(" FROM MstItemBatchWise AS A  ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16  ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE = C.BOOKCODE  ")
            .Append(" LEFT JOIN TrnLogBook AS D ON B.BEAMNO = D.BEAMNO  ")
            .Append(" LEFT JOIN MstLoomNo AS E ON D.LoomNoCode = E.LoomNoCode  ")
            .Append(" WHERE 1=1   ")
            .Append(_PlanningFilter)
            .Append(" AND A.ITEMNAME=B.OP16  ")
            .Append(" GROUP BY A.GROUPNAME, A.COMPNAME, A.PRIMERUNIT,  ")
            .Append(" B.Beam_Length, B.SYNSTATUS, B.BEAMNO ")
            .Append(" ,E.width ")
            .Append(" ) X  ")
            .Append(" WHERE X.SinFallDate BETWEEN GETDATE() AND DATEADD(DAY, 15, GETDATE())  ")
            .Append(" GROUP BY  ")
            .Append(" x.ItemCode, ")
            .Append(" x.LoomWidth, ")
            .Append(" x.DesignCode, ")
            .Append(" x.Shadecode ")
#End Region
            .Append(" ) AS Z")
            .Append(" LEFT JOIN MstFabricItem AS A  ON Z.ItemCode=A.ID ")
            .Append(" GROUP BY ")
            .Append(" Z.ItemCode")
            .Append(" ,A.ITENNAME")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _Tmptbl As New DataTable
        _Tmptbl = DefaltSoftTable.Copy
        If _Tmptbl.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else




            Dim columnNames As String() = {"PlanningQty", "JobOrder", "GreyOrder", "YarnPlan", "BeamPlan",
    "FoldingQty", "FactStock", "YarnBalQty", "YarnConsumQty", "DespatchQty",
    "YarnRecived", "YarnOrder", "YarnInStk", "YarnRequire",
    "PlBM", "WpBM", "DrBM", "PinBM", "OnLmBM", "SinFloor", "DoubFloor", "SinFall", "DoubFall"}

            Dim columnNames_SingleDecimal As String() = {"PlBM", "WpBM", "DrBM", "PinBM", "OnLmBM", "SinFloor", "DoubFloor", "SinFall", "DoubFall"}


            For Each dr As DataRow In _Tmptbl.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
                For Each colName In columnNames_SingleDecimal
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
            Next


            FirstStage.Columns.Clear()
            GridControl1.DataSource = _Tmptbl.Copy




            For Each colName In columnNames
                FirstStage.Columns(colName).Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}"))
            Next


            'For Each colName In columnNames
            '    Dim summary As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}")
            '    FirstStage.Columns(colName).Summary.Clear()
            '    FirstStage.Columns(colName).Summary.Add(summary)
            '    ' --- Check total value for column ---
            '    Dim total As Decimal = Convert.ToDecimal(FirstStage.Columns(colName).SummaryItem.SummaryValue)
            '    ' Agar total = 0 hai to column hide kar do
            '    If total = 0D Then
            '        FirstStage.Columns(colName).Visible = False
            '    Else
            '        FirstStage.Columns(colName).Visible = True
            '    End If
            'Next



            FirstStage.Columns("ItemCode").Visible = False
            FirstStage.Columns("FoldingQty").Visible = False
            FirstStage.Columns("DespatchQty").Visible = False
            FirstStage.Columns("YarnInStk").Visible = False
            FirstStage.Columns("YarnBalQty").Visible = False
            FirstStage.Columns("YarnConsumQty").Visible = False
            FirstStage.Columns("OnLmBM").Visible = False
            FirstStage.Columns("FactStock").Visible = False
            'FirstStage.Columns("PinBM").Visible = False


            Pnl_Dashbord.Visible = True
            DevGridFitColumnWiotScroll(GridControl1, FirstStage)
            FirstStage.Focus()
        End If
    End Sub
    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        Try

            _CommanFilterString = ""

            If e.KeyCode = Keys.Escape Then Exit Sub
            Dim _ActivatedColName As String = ""

            If FirstStage IsNot Nothing AndAlso FirstStage.FocusedColumn IsNot Nothing Then
                _ActivatedColName = FirstStage.FocusedColumn.FieldName
            End If

            SelectionType = _ActivatedColName.ToString
            _CommanFirstStageActivColumn = _ActivatedColName.ToString

            If FactStockTable IsNot Nothing Then
                FactStockTable.Clear()
            End If

            If SelectionOfView = "Factory" Then
#Region "Factory"

                NoOfstage = 1
                Dim ItemName As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemName").ToString
                Dim ItemCode As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString
                Dim PlanningQty As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PlanningQty").ToString
                Dim JobOrder As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "JobOrder").ToString
                Dim GreyOrder As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "GreyOrder").ToString
                Dim YarnOrder As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "YarnOrder").ToString
                Dim YarnRecived As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "YarnRecived").ToString
                Dim YarnPlan As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "YarnPlan").ToString
                Dim YarnInStk As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "YarnInStk").ToString
                Dim BeamPlan As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "BeamPlan").ToString
                Dim FoldingQty As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "FoldingQty").ToString
                Dim DespatchQty As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "DespatchQty").ToString
                Dim FactStock As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "FactStock").ToString
                Dim YarnRequire As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "YarnRequire").ToString

                FactoryActiveClmItemCode = ItemCode
                FactoryActiveClmName = _ActivatedColName

                If _ActivatedColName = "ItemName" Then
                    If e.KeyCode = Keys.F2 Then
                        SelectionOfView = "Factory"
                        NewQualityPlanEntry.ShowDialog()
                    End If
                ElseIf _ActivatedColName = "PlanningQty" Then
                    If e.KeyCode = Keys.Enter AndAlso PlanningQty > "" Then
                        _GetPlanningQuery(ItemCode)
                    End If
                ElseIf _ActivatedColName = "JobOrder" Then
                    If e.KeyCode = Keys.Enter AndAlso JobOrder > "" Then
                        _GetJobQuery(ItemCode)
                    ElseIf e.KeyCode = Keys.F2 Then
                        Planning_OrderEntry.LblHeader.Text = "Job Order Entry"
                        Planning_OrderEntry.txtItemCode.Text = ItemCode
                        Planning_OrderEntry.ShowDialog()

                    End If
                ElseIf _ActivatedColName = "GreyOrder" Then
                    If e.KeyCode = Keys.Enter AndAlso GreyOrder > "" Then
                        _GetGreyQuery(ItemCode)
                    ElseIf e.KeyCode = Keys.F2 Then
                        Planning_OrderEntry.LblHeader.Text = "Grey Order Entry"
                        Planning_OrderEntry.txtItemCode.Text = ItemCode
                        Planning_OrderEntry.ShowDialog()
                    End If
                ElseIf _ActivatedColName = "YarnOrder" Then
                    If e.KeyCode = Keys.Enter AndAlso YarnOrder > "" Then
                        _GetYarnOrderQty(ItemCode)
                    End If
                ElseIf _ActivatedColName = "YarnRecived" Then
                    If e.KeyCode = Keys.Enter AndAlso YarnRecived > "" Then
                        _GetYarnPurQty(ItemCode)
                    End If
                ElseIf _ActivatedColName = "YarnRequire" Then
                    If e.KeyCode = Keys.Enter AndAlso YarnRequire > "" Then
                        _GetYarnRequirQty(ItemCode)

                    End If
                ElseIf _ActivatedColName = "YarnPlan" Then
                    If e.KeyCode = Keys.Enter AndAlso YarnPlan > "" Then
                        '_GetYarnPlanQty(ItemCode)
                        _GetYarnRequirQty(ItemCode)
                    End If
                ElseIf _ActivatedColName = "YarnInStk" Then
                    If e.KeyCode = Keys.Enter AndAlso YarnInStk > "" Then
                        _GetYarnInStk(ItemCode)
                    End If
                ElseIf _ActivatedColName = "PlBM" Or _ActivatedColName = "WpBM" Or _ActivatedColName = "DrBM" Or _ActivatedColName = "PinBM" Or _ActivatedColName = "OnLmBM" Then
                    If e.KeyCode = Keys.Enter AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, _ActivatedColName).ToString > "" Then
                        Dim _FilterString As String = ""
                        If _ActivatedColName = "PlBM" Then
                            _FilterString = " AND B.OP10 ='PLANNING'"
                        ElseIf _ActivatedColName = "WpBM" Then
                            _FilterString = " AND B.OP10 ='WARPING'"
                        ElseIf _ActivatedColName = "DrBM" Then
                            _FilterString = " AND B.OP10 ='DRAWING'"
                        ElseIf _ActivatedColName = "PinBM" Then
                            _FilterString = " AND B.OP10 ='PINNING'"
                        ElseIf _ActivatedColName = "OnLmBM" Then
                            _FilterString = " AND B.OP10 ='ONLOOM'"
                        End If

                        _CommanFilterString = _FilterString
                        _GetBeamPlanQty(ItemCode, _FilterString, "")
                    End If

                ElseIf _ActivatedColName = "BeamPlan" Then
                    If e.KeyCode = Keys.Enter AndAlso BeamPlan > "" Then
                        _GetBeamPlanQty(ItemCode, "", "")
                    ElseIf e.KeyCode = Keys.F2 Then
                        _RemarkLableNameFeeler("New Beam Plan Entry", "Plan Date", "Item Name", "Beam Length", "Planning No", "Loom Width")
                        _textBoxVisablecheck(True)

                        Txt_Remark_1.Text = ItemName
                        Txt_Remark_2.Text = ""
                        Txt_Remark_4.Text = "1"
                        Txt_Remark_3.Text = ""
                        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                        Txt_Remark_2.Focus()
                        Txt_Remark_2.SelectAll()
                    End If

                ElseIf _ActivatedColName = "SinFloor" Or _ActivatedColName = "DoubFloor" Then
                    If e.KeyCode = Keys.Enter AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, _ActivatedColName).ToString > "" Then
                        Dim _FilterString As String = ""
                        Dim _FilterGroupby As String = ""
                        If _ActivatedColName = "SinFloor" Then
                            _FilterString = " AND B.OP10 ='PINNING' "
                            _FilterGroupby = " AND SYNCount=1 "
                        Else
                            _FilterString = " AND B.OP10 ='PINNING'"
                            _FilterGroupby = " AND SYNCount=2 "
                        End If


                        _CommanFilterString = _FilterString
                        _GetBeamPlanQty(ItemCode, _FilterString, _FilterGroupby)
                    End If
                ElseIf _ActivatedColName = "SinFall" Or _ActivatedColName = "DoubFall" Then
                    If e.KeyCode = Keys.Enter AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, _ActivatedColName).ToString > "" Then
                        Dim _FilterString As String = ""
                        If _ActivatedColName = "SinFall" Then
                            _FilterString = " AND x.ItemCode ='" & ItemCode & "' AND X.LoomWidth = 1 "
                        Else
                            _FilterString = " AND x.ItemCode ='" & ItemCode & "' AND X.LoomWidth = 2 "
                        End If
                        _GetBeamFalling(_FilterString)
                    End If
                ElseIf _ActivatedColName = "FoldingQty" Then
                    If e.KeyCode = Keys.Enter AndAlso FoldingQty > "" Then
                        _GetFoldingQty(ItemCode)
                    End If
                ElseIf _ActivatedColName = "DespatchQty" Then
                    If e.KeyCode = Keys.Enter AndAlso DespatchQty > "" Then
                        _GetDespatchQty(ItemCode)
                    End If
                    'ElseIf _ActivatedColName = "FactStock" Then
                    '    If e.KeyCode = Keys.Enter AndAlso FactStock > "" Then
                    '        _GetFactStkQty(ItemCode)
                    '    End If
                End If

#End Region

            ElseIf SelectionOfView = "Producation DashBoard" Then
#Region "Producation DashBoard"
                NoOfstage = 1
                Dim ItemName As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemName").ToString
                Dim ItemCode As String = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemCode").ToString

                FactoryActiveClmItemCode = ItemCode
                FactoryActiveClmName = _ActivatedColName

                If _ActivatedColName = "FactStock" Then
                    If e.KeyCode = Keys.Enter AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, _ActivatedColName).ToString > "" Then
                        _GetFactStkQty(ItemCode)
                    End If
                End If
#End Region
            ElseIf SelectionOfView = "Process" Then
#Region "Process"
                Dim _FilterString As String = ""
                Dim ProcessCode As String = ""
                If Txt_ProcessStockDisplay.Text = "PROCESS WISE" Then
                    NoOfstage = 1
                    _FilterString = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PROCESSCODE").ToString
                    ProcessCode = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PROCESSCODE").ToString
                    _FilterString = " AND  A.PROCESSCODE = '" & _FilterString & "'"
                ElseIf Txt_ProcessStockDisplay.Text = "ITEM WISE" Then
                    NoOfstage = 1
                    _FilterString = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ITEMCODE").ToString
                    _FilterString = " AND  A.FABRIC_ITEMCODE = '" & _FilterString & "'"
                End If

                If _ActivatedColName = "ProcStk" Or _ActivatedColName = "Process" Or _ActivatedColName = "MixMtr" Or _ActivatedColName = "DprMtr" Or _ActivatedColName = "GreyMtr" Then
                    SelectionType = "ProcStk"
                    Dim ProcStk As String = ""
                    If FirstStage.FocusedRowHandle >= 0 Then
                        Dim val = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ProcStk")
                        If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                            ProcStk = val.ToString()
                        End If
                    End If
                    If e.KeyCode = Keys.Enter AndAlso ProcStk > "" Then

                        focusedColumn_I = FirstStage.FocusedColumn
                        _StgIRowNo = FirstStage.FocusedRowHandle
                        Dim _ProcessName = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Process")
                        _ProcessSecondStageDisplay(_FilterString, "FIRST", _ProcessName, "", focusedColumn_I, 0, "", ProcessCode)
                    End If
                ElseIf _ActivatedColName = "GrdDprMtr" Then
                    SelectionType = _ActivatedColName
                    Dim GrdDprMtr As String = ""
                    If FirstStage.FocusedRowHandle >= 0 Then
                        Dim val = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, SelectionType)
                        If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                            GrdDprMtr = val.ToString()
                        End If
                    End If
                    If e.KeyCode = Keys.Enter AndAlso GrdDprMtr > "" Then
                        _StgIRowNo = FirstStage.FocusedRowHandle
                        Dim _ProcessName = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Process")
                        _FilterString = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PROCESSCODE").ToString
                        _FilterString = " AND  A.accountcode = '" & _FilterString & "'"
                        _GradingDprStockGate(_FilterString, "FIRST", SelectionType, _ProcessName, "", "ENTER", "GRID", "")
                    End If
                ElseIf _ActivatedColName = "PBeam" Then
                    SelectionType = "PBeam"
                    Dim PBeam As String = ""
                    If FirstStage.FocusedRowHandle >= 0 Then
                        Dim val = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PBeam")
                        If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                            PBeam = val.ToString()
                        End If
                    End If
                    If e.KeyCode = Keys.Enter AndAlso PBeam > "" Then
                        _StgIRowNo = FirstStage.FocusedRowHandle
                        Dim _ProcessName = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Process")
                        _ProcessSecondPBeam(_FilterString, "FIRST", _ProcessName, "", 0)
                    End If
                ElseIf _ActivatedColName = "Req" Or _ActivatedColName = "Wash" Or _ActivatedColName = "Dyn" Or _ActivatedColName = "Stenter" Or _ActivatedColName = "Mechan" Or _ActivatedColName = "Fold" Or _ActivatedColName = "TblChk" Or _ActivatedColName = "RtMtr" Or _ActivatedColName = "Ready" Or _ActivatedColName = "Decision" Then
                    SelectionType = _ActivatedColName
                    Dim Req As String = ""
                    If FirstStage.FocusedRowHandle >= 0 Then
                        Dim val = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, SelectionType)
                        If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                            Req = val.ToString()
                        End If
                    End If

                    If e.KeyCode = Keys.Enter AndAlso Req > "" Then
                        _StgIRowNo = FirstStage.FocusedRowHandle
                        Dim _ProcessName = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Process")
                        _ProcessSecond_Req(_FilterString, "FIRST", SelectionType, _ProcessName, "", "ENTER", "GRID", _FilterString)
                    End If
                End If
#End Region
            ElseIf SelectionOfView = "Sales Planning DashBoard" Then
#Region "sales Planning"
                Dim _FilterString As String = ""
                Dim ProcessCode As String = ""
                If Txt_ProcessStockDisplay.Text = "PARTY WISE" Then
                    NoOfstage = 1
                    _FilterString = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ACCOUNTCODE").ToString
                    _FilterString = " AND  A.ACCOUNTCODE = '" & _FilterString & "'"
                ElseIf Txt_ProcessStockDisplay.Text = "ITEM WISE" Then
                    NoOfstage = 1
                    _FilterString = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ITEMCODE").ToString
                    _FilterString = " AND  Z.ItemCode = '" & _FilterString & "'"
                End If

                If e.KeyCode = Keys.Enter Then

                    If _ActivatedColName = "OldSales" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "OldSales").ToString > "" Then
                        Dim _OldSales As String = _QueyOldSales("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_OldSales, _ActivatedColName)
                    ElseIf _ActivatedColName = "ItemName" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ItemName").ToString > "" Then
                        'Dim _OldSales As String = _QueyOldSales("FIRST", _FilterString)
                        '_SalesSecondstageGridSetting(_OldSales, _ActivatedColName)
                    ElseIf _ActivatedColName = "Planning" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "Planning").ToString > "" Then
                        Dim _Beamplanning As String = _QueySalesBeamPlan("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_Beamplanning, _ActivatedColName)
                    ElseIf _ActivatedColName = "BeamPlan" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "BeamPlan").ToString > "" Then
                        Dim _Beamplanning As String = _QueySalesBeamPlan("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_Beamplanning, _ActivatedColName)
                    ElseIf _ActivatedColName = "FactStock" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "FactStock").ToString > "" Then
                        Dim _Factstock As String = _QueySalesFactstock("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_Factstock, _ActivatedColName)
                    ElseIf _ActivatedColName = "ProcsDyn" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ProcsDyn").ToString > "" Then
                        Dim _ProcsDyn As String = _QueySalesProcsDyn("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_ProcsDyn, _ActivatedColName)

                    ElseIf _ActivatedColName = "GreyMtr" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "GreyMtr").ToString > "" Then
                        Dim _GreyMtr As String = _QueySalesGreyMtr("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_GreyMtr, _ActivatedColName)
                    ElseIf _ActivatedColName = "ProcReady" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ProcReady").ToString > "" Then
                        Dim _ProcReady As String = _QueySalesProcready("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_ProcReady, _ActivatedColName)
                    ElseIf _ActivatedColName = "ProcReady" AndAlso FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "ProcReady").ToString > "" Then
                        Dim _Gradingstk As String = _QueySalesGradingStk("SECOND", _FilterString)
                        _SalesSecondstageGridSetting(_Gradingstk, _ActivatedColName)

                    End If
            End If

#End Region

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub _RemarkLableNameFeeler(ByVal _Header As String, ByVal DateLbl As String, ByVal Remk1 As String, ByVal Remk2 As String, ByVal Remk3 As String, ByVal Remk4 As String)
        LblRemarkHeader.Text = _Header
        Lbl_PymtDate.Text = DateLbl
        LblPymtRemark.Text = Remk1
        Lbl_GrRemark.Text = Remk2
        Lbl_OtherRemark.Text = Remk3
        LblRemark_4.Text = Remk4

        _textBoxVisablecheck(False)

        PnlRemark.Visible = True
        PnlRemark.BringToFront()

    End Sub


#Region "Producation DashBoard"
    Private Sub _ProducationDesbordLoad()

        Dim _PlanningFilter As String = " AND A.MRP='NO'  AND A.SHORTNAME='NEW QUALITY PLANNING' "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" Z.ItemCode")
            .Append(" ,A.ITENNAME as ItemName")
            .Append(" ,SUM(z.FactStock) as FactStock")

            .Append(" FROM ( ")



#Region "Factory Stock"
            '.Append(" UNION ALL ")

            .Append(" SELECT  ")
            .Append(" A.GROUPNAME AS ItemCode, ")
            .Append(" A.COMPNAME AS DesignCode, ")
            .Append(" A.PRIMERUNIT AS Shadecode, ")
            .Append(" ISNULL(SUM(D.GMtr), 0) - ISNULL(SUM(E.GMtr), 0) AS FactStock ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16  ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE = C.BOOKCODE ")
            .Append(" LEFT JOIN TrnGreyRcpt AS D ON B.BEAMNO = D.BEAMNO ")
            .Append(" LEFT JOIN TrnGreyDesp AS E ON D.Grey_Rcpt_Pcs_ID = E.Grey_Rcpt_Pcs_ID ")
            .Append(" WHERE 1 = 1 ")
            .Append(_PlanningFilter)
            .Append(" AND A.ITEMNAME=B.OP16  ")
            .Append(" GROUP BY  ")
            .Append(" A.GROUPNAME, ")
            .Append(" A.COMPNAME, ")
            .Append(" A.PRIMERUNIT ")
#End Region



            .Append(" ) AS Z")
            .Append(" LEFT JOIN MstFabricItem AS A  ON Z.ItemCode=A.ID ")
            .Append(" GROUP BY ")
            .Append(" Z.ItemCode")
            .Append(" ,A.ITENNAME")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _Tmptbl As New DataTable
        _Tmptbl = DefaltSoftTable.Copy
        If _Tmptbl.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else

            Dim columnNames As String() = {"FactStock"}


            For Each dr As DataRow In _Tmptbl.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0.00", True)
                Next
            Next


            FirstStage.Columns.Clear()
            GridControl1.DataSource = _Tmptbl.Copy


            For Each colName In columnNames
                FirstStage.Columns(colName).Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}"))
            Next


            'For Each colName In columnNames
            '    Dim summary As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}")
            '    FirstStage.Columns(colName).Summary.Clear()
            '    FirstStage.Columns(colName).Summary.Add(summary)
            '    ' --- Check total value for column ---
            '    Dim total As Decimal = Convert.ToDecimal(FirstStage.Columns(colName).SummaryItem.SummaryValue)
            '    ' Agar total = 0 hai to column hide kar do
            '    If total = 0D Then
            '        FirstStage.Columns(colName).Visible = False
            '    Else
            '        FirstStage.Columns(colName).Visible = True
            '    End If
            'Next


            FirstStage.Columns("ItemCode").Visible = False


            Pnl_Dashbord.Visible = True
            DevGridFitColumnWiotScroll(GridControl1, FirstStage)
            FirstStage.Focus()
        End If
    End Sub
    Public Sub _GetBeamFalling(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" Select   ")
            .Append(" D.ITENNAME As ItemName,")
            .Append(" x.ItemCode, ")
            .Append(" x.DesignCode, ")
            .Append(" x.Shadecode, ")
            .Append(" x.BeamNo, ")
            .Append(" x.LoomNo, ")
            .Append(" x.Get_Date As GetDate, ")
            .Append(" x.Beam_Length As BeamLength, ")
            .Append(" sum(x.TotalProdMtr) As TotalProdMtr, ")
            .Append(" X.BeamFallDate ")
            .Append(" FROM (  ")
            .Append(" SELECT  ")
            .Append(" A.GROUPNAME As ItemCode, ")
            .Append(" A.COMPNAME As DesignCode, ")
            .Append(" A.PRIMERUNIT As Shadecode, ")
            .Append(" B.Beam_Length,  ")
            .Append(" B.Get_Date,  ")
            .Append(" B.SYNSTATUS As BeamPlan,  ")
            .Append(" B.BEAMNO, ")
            .Append(" SUM(D.Prod_Mtr) As TotalProdMtr, ")
            .Append(" MAX(D.Log_Book_Date) As LastLogDate,   ") ' last entry date
            .Append(" DATEADD(DAY,  ")
            .Append(" CASE WHEN SUM(D.Prod_Mtr) > 0  ")
            .Append(" THEN (B.Beam_Length / SUM(D.Prod_Mtr))  ")
            .Append(" ELSE 0 END,  ")
            .Append(" MAX(D.Log_Book_Date)) As BeamFallDate ")
            .Append(" ,E.width AS LoomWidth ")
            .Append(" ,E.LoomNo")
            .Append(" FROM MstItemBatchWise As A  ")
            .Append(" LEFT JOIN TrnBeamHeader As B On A.ITEMNAME=B.OP16   ")
            .Append(" LEFT JOIN MSTBOOK As C On B.BOOKCODE = C.BOOKCODE  ")
            .Append(" LEFT JOIN TrnLogBook As D On B.BEAMNO = D.BEAMNO  ")
            .Append(" LEFT JOIN MstLoomNo AS E ON D.LoomNoCode = E.LoomNoCode  ")
            .Append(" WHERE 1=1   ")

            .Append(" And A.ITEMNAME=B.OP16   ")
            .Append(" GROUP BY A.GROUPNAME, A.COMPNAME, A.PRIMERUNIT,  ")
            .Append(" B.Beam_Length, B.SYNSTATUS, B.BEAMNO,b.Get_Date ")
            .Append(" ,E.width ")
            .Append(" ,E.LoomNo ")
            .Append(" ) X  ")
            .Append("  LEFT JOIN  MstFabricItem As D On x.ItemCode=D.id ")
            .Append(" WHERE X.BeamFallDate BETWEEN GETDATE() And DATEADD(DAY, 15, GETDATE())  ")
            .Append(_ItemCode)

            .Append(" GROUP BY  ")
            .Append(" D.ITENNAME, ")
            .Append(" x.ItemCode, ")
            .Append(" x.DesignCode, ")
            .Append(" x.Shadecode, ")
            .Append(" x.BeamNo, ")
            .Append(" x.Get_Date, ")
            .Append(" x.Beam_Length, ")
            .Append(" X.BeamFallDate, ")
            .Append(" X.LoomNo ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _Tmptbl As New DataTable
        _Tmptbl = DefaltSoftTable.Copy
        If _Tmptbl.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else


            GridView1.Columns.Clear()
            GridControl2.DataSource = _Tmptbl.Copy


            GridView1.Columns("ItemCode").Visible = False
            GridView1.Columns("DesignCode").Visible = False
            GridView1.Columns("Shadecode").Visible = False


            DevGridFitColumn(GridControl2, GridView1)
            GridView1.Columns("BeamLength").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BeamLength", "{0}"))
            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)

        End If
    End Sub
#End Region


#Region "Get Second Stage Detail"
    Private Sub FactoryOrder_Click(sender As Object, e As EventArgs) Handles FactoryOrder.Click
        SelectionOfView = "Factory"
    End Sub
    Private Sub _GetBeamWiseStockFirstStage(ByVal _QtyTyeColumName)
        Try

            Dim _ThidTable As New DataTable
            Dim query_1 = From row In FactStockTable
                          Order By row.Field(Of String)("BeamNo")
                          Group row By
                      PartyName = row.Field(Of String)("PartyName"),
                      ItemName = row.Field(Of String)("ItemName"),
                      Design = row.Field(Of String)("Design"),
                      Shade = row.Field(Of String)("Shade"),
                      BeamNo = row.Field(Of String)("BeamNo")
                      Into PartyNameGroup = Group
                          Select New With {
                      Key PartyName, ItemName, Design, Shade, BeamNo,
                      .Pcs = PartyNameGroup.Count(Function(r) Not String.IsNullOrWhiteSpace(r("PieceNo").ToString())),
                      .Mtrs = PartyNameGroup.Sum(Function(r) CDec(r(_QtyTyeColumName)))
                       }
            _ThidTable = LINQToDataTable(query_1)


            If _ThidTable.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else
                For Each dr As DataRow In _ThidTable.Select
                    dr("Mtrs") = Convert.ToDouble(dr("Mtrs")).ToString("0.00")

                    If Val(dr("Mtrs")) = 0 Then dr("Mtrs") = DBNull.Value
                Next
                GridView1.Columns.Clear()
                GridControl2.DataSource = _ThidTable.Copy
                GridView1.Columns("Mtrs").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridView1.Columns("Mtrs").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Mtrs", "{0}"))

                GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Mtrs", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("Mtrs")})
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "Pcs", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("Pcs")})

                GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()
                GridView1.FocusedRowHandle = _StgIRowNo
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _GetBeamWiseStockSecondStage(ByVal FiltBeamNo As String, ByVal FilterColumName As String)

        Try
            If FactStockTable.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else
                For Each dr As DataRow In FactStockTable.Select
                    dr(FilterColumName) = Convert.ToDouble(dr(FilterColumName)).ToString("0.00")

                    If Val(dr(FilterColumName)) = 0 Then dr(FilterColumName) = DBNull.Value
                Next
                GridView1.Columns.Clear()
                Dim filteredRows As DataRow() = FactStockTable.Select("BeamNo='" & FiltBeamNo & "'")
                If filteredRows.Any() Then
                    GridControl2.DataSource = filteredRows.CopyToDataTable()
                Else
                    GridControl2.DataSource = FactStockTable.Clone() ' empty table with same schema
                End If

                GridView1.Columns(FilterColumName).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridView1.Columns(FilterColumName).Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, FilterColumName, "{0}"))
                GridView1.Columns("PieceNo").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PieceNo", "{0}"))

                GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = FilterColumName, .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns(FilterColumName)})
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "PieceNo", .SummaryType = DevExpress.Data.SummaryItemType.Count, .ShowInGroupColumnFooter = GridView1.Columns("PieceNo")})

                GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _GetFactStkQty(ByVal _ItemCode As String)
        FactStockTable = _GetFactStkQtyQuery(_ItemCode)
        _StgIRowNo = 1
        _GetBeamWiseStockFirstStage("FactStock")
    End Sub
    Public Function _GetFactStkQtyQuery(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" E.ACCOUNTNAME as PartyName")
            .Append(" ,D.ITENNAME as ItemName ")
            .Append(" ,F.Design_Name as Design")
            .Append(" ,G.SHADE as Shade")
            .Append(" ,H.EntryNo")
            .Append(" ,H.ChallanDate AS Date")
            .Append(" ,J.LoomNo")
            .Append(" ,H.BeamNo")
            .Append(" ,H.PieceNo")
            .Append(" ,H.GMtr as FactStock")
            .Append(" ,H.Folding_Remark as Remark")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ID=CAST(B.OP3 AS INT) ")
            .Append("  LEFT JOIN  MstFabricItem AS D ON A.GROUPNAME=D.id ")
            .Append("  LEFT JOIN MstMasterAccount AS E  ON B.ACCOUNTCODE=E.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS F  ON A.COMPNAME=F.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS G  ON A.PRIMERUNIT=G.ID")
            .Append(" LEFT JOIN TrnGreyRcpt AS H ON B.BEAMNO=H.BEAMNO ")
            .Append(" LEFT JOIN TrnGreyDesp AS I ON H.Grey_Rcpt_Pcs_ID=I.Grey_Rcpt_Pcs_ID ")
            .Append(" LEFT JOIN MstLoomNo AS J ON H.LoomCode=J.LoomNoCode ")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND H.GMtr>0  ")
            .Append(" AND I.Grey_Rcpt_Pcs_ID IS NULL  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.ID=ISNULL(NULLIF(B.OP3, ''), 0) ")
            .Append("ORDER BY I.BeamNo ,H.EntryNo,H.PieceNo")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        Return _ThidTable
    End Function
    Private Sub _GetDespatchQty(ByVal _ItemCode As String)
        FactStockTable = _GetDespatchEntry(_ItemCode)
        _StgIRowNo = 1
        _GetBeamWiseStockFirstStage("DespatchQty")
    End Sub
    Public Function _GetDespatchEntry(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" E.ACCOUNTNAME as PartyName")
            .Append(" ,D.ITENNAME as ItemName ")
            .Append(" ,F.Design_Name as Design")
            .Append(" ,G.SHADE as Shade")
            .Append(" ,I.EntryNo")
            .Append(" ,I.ChallanDate AS Date")
            .Append(" ,I.BeamNo")
            .Append(" ,I.PieceNo")
            .Append(" ,I.GMtr as DespatchQty")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ID=CAST(B.OP3 AS INT) ")
            .Append("  LEFT JOIN  MstFabricItem AS D ON A.GROUPNAME=D.id ")
            .Append("  LEFT JOIN MstMasterAccount AS E  ON B.ACCOUNTCODE=E.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS F  ON A.COMPNAME=F.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS G  ON A.PRIMERUNIT=G.ID")
            .Append(" LEFT JOIN TrnGreyRcpt AS H ON B.BEAMNO=H.BEAMNO ")
            .Append(" LEFT JOIN TrnGreyDesp AS I ON H.Grey_Rcpt_Pcs_ID=I.Grey_Rcpt_Pcs_ID ")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND I.Grey_Rcpt_Pcs_ID>''  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.ID=ISNULL(NULLIF(B.OP3, ''), 0) ")
            .Append("ORDER BY I.BeamNo ,I.EntryNo,I.PieceNo")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        Return _ThidTable
    End Function
    Private Sub _GetFoldingQty(ByVal _ItemCode As String)
        FactStockTable = _GetFoldingEntry(_ItemCode)
        _StgIRowNo = 1
        _GetBeamWiseStockFirstStage("FoldingQty")
    End Sub

    Public Function _GetFoldingEntry(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" E.ACCOUNTNAME as PartyName")
            .Append(" ,D.ITENNAME as ItemName ")
            .Append(" ,F.Design_Name as Design")
            .Append(" ,G.SHADE as Shade")
            .Append(" ,H.EntryNo")
            .Append(" ,H.ChallanDate AS Date")
            .Append(" ,B.BeamNo")
            .Append(" ,I.LoomNo")
            .Append(" ,H.PieceNo")
            .Append(" ,H.GMtr as FoldingQty")
            .Append(" ,H.Folding_Remark as Remark")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ID=CAST(B.OP3 AS INT) ")
            .Append("  LEFT JOIN  MstFabricItem AS D ON A.GROUPNAME=D.id ")
            .Append("  LEFT JOIN MstMasterAccount AS E  ON B.ACCOUNTCODE=E.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS F  ON A.COMPNAME=F.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS G  ON A.PRIMERUNIT=G.ID")
            .Append(" LEFT JOIN TrnGreyRcpt AS H ON B.BEAMNO=H.BEAMNO ")
            .Append(" LEFT JOIN MstLoomNo AS I ON H.LoomCode=I.LoomNoCode ")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND H.Grey_Rcpt_Pcs_ID>''  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.ID=ISNULL(NULLIF(B.OP3, ''), 0) ")
            .Append("ORDER BY B.BeamNo ,H.EntryNo,H.PieceNo")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        Return _ThidTable
    End Function

    Private Sub _GetBeamPlanQty(ByVal _ItemCode As String, ByVal FilterString As String, ByVal GroupbyFilter As String)

        Dim _ThidTable As New DataTable
        _ThidTable = _GetBeamPlanning(_ItemCode, FilterString, GroupbyFilter)

        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else

            For Each dr As DataRow In _ThidTable.Select
                dr("BeamLength") = Convert.ToDouble(dr("BeamLength")).ToString("0")

                If Val(dr("BeamLength")) = 0 Then dr("BeamLength") = DBNull.Value
            Next

            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy
            GridView1.Columns("BeamLength").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns("Design").Visible = False
            GridView1.Columns("Shade").Visible = False
            GridView1.Columns("BOOKVNO").Visible = False
            GridView1.Columns("Warper_Code").Visible = False
            GridView1.Columns("DrawerCode").Visible = False
            GridView1.Columns("PinnerCode").Visible = False
            GridView1.Columns("WarperName").Visible = False
            GridView1.Columns("DrawerName").Visible = False
            GridView1.Columns("PinnerName").Visible = False
            GridView1.Columns("LOOMCODE").Visible = False
            GridView1.Columns("MainBeamBookvno").Visible = False
            GridView1.Columns("SYNCount").Visible = False


            DevGridFitColumn(GridControl2, GridView1)
            GridView1.Columns("BeamLength").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BeamLength", "{0}"))
            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If
    End Sub
    Public Function _GetBeamPlanning(ByVal _ItemCode As String, ByVal FilterString As String, ByVal GroupbyFilter As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT * ")
            .Append(" FROM ( ")
            .Append(" SELECT   ")
            .Append(" E.ACCOUNTNAME as PartyName, ")
            .Append(" D.ITENNAME as ItemName, ")
            .Append(" F.Design_Name as Design, ")
            .Append(" G.SHADE as Shade, ")
            .Append(" B.BeamNo, ")
            .Append(" B.Own_Job as OwnJob, ")
            .Append(" B.Op5 as PlanDate, ")
            .Append(" IIF( B.Warper_Code = '0000-000000001', '', CONVERT(VARCHAR(10), B.WarpDate, 103)) AS WarpDate , ")
            .Append(" B.op6 as DrawDate, ")
            .Append(" B.op8 as PinDate, ")
            .Append(" H.LoomNo, ")
            .Append(" B.Beam_Length as BeamLength, ")
            .Append(" B.BOOKVNO, ")
            .Append(" B.Warper_Code, ")
            .Append(" B.LOOMCODE, ")
            .Append(" B.OP7 as DrawerCode, ")
            .Append(" B.OP8 as PinnerCode, ")
            .Append(" K.EMPNAME  AS WarperName, ")
            .Append(" L.EMPNAME  AS DrawerName, ")
            .Append(" M.EMPNAME  AS PinnerName, ")
            .Append(" B.SYNSTATUS as MainBeamBookvno, ")
            .Append(" COUNT(B.SYNSTATUS) OVER(PARTITION BY B.SYNSTATUS) AS SYNCount ")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ID=CAST(B.OP3 AS INT) ")
            .Append(" LEFT JOIN MstFabricItem AS D ON A.GROUPNAME=D.id ")
            .Append(" LEFT JOIN MstMasterAccount AS E ON B.ACCOUNTCODE=E.ACCOUNTCODE ")
            .Append(" LEFT JOIN Mst_Fabric_Design AS F ON A.COMPNAME=F.Design_code ")
            .Append(" LEFT JOIN Mst_Fabric_Shade AS G ON A.PRIMERUNIT=G.ID ")
            .Append(" LEFT JOIN MSTLOOMNO H ON B.LOOMCODE=H.LOOMNOCODE ")
            .Append(" LEFT JOIN MstEmployee AS K ON B.Warper_Code=K.EMPCODE ")
            .Append(" LEFT JOIN MstEmployee AS L ON B.OP7=L.EMPCODE ")
            .Append(" LEFT JOIN MstEmployee AS M ON B.OP9=M.EMPCODE ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.MRP='NO' ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(FilterString)
            .Append(" AND A.ID=ISNULL(NULLIF(B.OP3, ''), 0) ")
            .Append(" ) AS T ")
            .Append(" WHERE 1=1 ")
            .Append(GroupbyFilter)
            .Append(" ORDER BY BeamNo ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        Return _ThidTable
    End Function
    Private Sub _GetYarnInStk(ByVal _ItemCode As String)

        _ItemCode = " AND C.GROUPNAME='" & _ItemCode & "'"

        Dim _ThidTable As New DataTable
        _ThidTable = _GetFactoryYarnStock(_ItemCode, "YES")

        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else
            For Each dr As DataRow In _ThidTable.Select
                dr("YarnInStk") = Convert.ToDouble(dr("YarnInStk")).ToString("0.00")

                If Val(dr("YarnInStk")) = 0 Then dr("YarnInStk") = DBNull.Value
            Next
            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy
            GridView1.Columns("YarnInStk").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            DevGridFitColumn(GridControl2, GridView1)
            GridView1.Columns("YarnInStk").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "YarnInStk", "{0}"))
            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If

    End Sub
    Public Function _GetFactoryYarnStock(ByVal _ItemCode As String, ByVal _PlanEntryWise As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.CountName ")
            .Append(" ,(SUM(Z.RCPTWT)+SUM(Z.BEAM_RETUREN))-(SUM(Z.ISSUEWT)+SUM(Z.BEAM_ISSUE)) AS YarnInStk ")
            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append(" A.COUNTCODE,A.ACCOUNTCODE ")
            .Append(" ,IIF(B.NATURE='RCPT',A.ACTUAL_WEIGHT,(0.00)) AS RCPTWT ")
            .Append(" ,IIF(B.NATURE='ISSUE',A.ACTUAL_WEIGHT,(0.00)) AS ISSUEWT ")
            .Append(" ,0.00 AS BEAM_ISSUE ")
            .Append(" ,0.00 AS BEAM_RETUREN  		 		 ")
            .Append(" FROM TRNFACTORYYARN AS A  	  			 ")
            .Append(" ,MSTBOOK AS B ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE=B.BOOKCODE ")
            .Append(" AND A.BOOKCODE<>'0001-000000310' ")
            .Append(" AND A.BOOKCODE<>'0001-000000311' ")
            .Append(" AND A.BOOKCODE<>'0001-000000146' ")
            .Append(" UNION ALL ")
            .Append(" SELECT  	  			 ")
            .Append(" A.COUNTCODE ")
            .Append(" ,A.FACTORY_CODE AS ACCOUNTCODE, ")
            .Append(" IIF(B.NATURE='RCPT',A.ACTUAL_WEIGHT ,(0.00)) AS RCPTWT, ")
            .Append(" IIF(B.NATURE='ISSUE',A.ACTUAL_WEIGHT ,(0.00)) AS ISSUEWT ")
            .Append(" ,0.00 AS BEAM_ISSUE ")
            .Append(" ,0.00 AS BEAM_RETUREN ")
            .Append(" FROM TRNFACTORYYARN AS A ")
            .Append(" ,MSTBOOK AS B ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE=B.BOOKCODE ")
            .Append(" AND A.BOOKCODE='0001-000000146' ")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.COUNTCODE ")
            .Append(" ,A.ACCOUNTCODE ")
            .Append(" ,0.00 AS RCPTWT ")
            .Append(" ,0.00 AS ISSUEWT ")
            .Append(" ,A.CHALLAN_WEIGHT AS BEAM_ISSUE ")
            .Append(" ,0.00 AS BEAM_RETUREN ")
            .Append(" FROM TRNFACTORYYARN AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='0001-000000310' ")
            .Append(" UNION ALL ")
            .Append(" SELECT A.COUNTCODE,A.ACCOUNTCODE ")
            .Append(" ,0.00 AS RCPTWT, 0.00 AS ISSUEWT ")
            .Append(" ,0.00 AS BEAM_ISSUE ")
            .Append(" ,A.CHALLAN_WEIGHT AS BEAM_RETUREN ")
            .Append(" FROM TRNFACTORYYARN AS A ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.BOOKCODE='0001-000000311' ")
            .Append(" )AS Z ")
            .Append(" LEFT JOIN MSTYARNCOUNT AS A ON Z.COUNTCODE=A.COUNTCODE  ")

            If _PlanEntryWise = "YES" Then
                .Append(" LEFT JOIN (SELECT COUNTCODE,Fabric_ItemCode FROM MstFabricItemCons GROUP BY COUNTCODE,Fabric_ItemCode)  AS B  ON Z.COUNTCODE=B.COUNTCODE  ")
                .Append(" LEFT JOIN ( SELECT MRP,PRIMERUNIT, GROUPNAME,SHORTNAME,COMPNAME FROM MstItemBatchWise GROUP BY MRP,PRIMERUNIT,COMPNAME,GROUPNAME,SHORTNAME) AS C  ON B.Fabric_ItemCode=C.GROUPNAME  ")
            End If


            .Append(" WHERE 1=1 ")
            .Append(_ItemCode)
            .Append(" AND  Z.COUNTCODE=A.COUNTCODE  ")
            '.Append(" AND B.Fabric_ItemCode=C.GROUPNAME ")
            .Append(" GROUP BY ")
            .Append(" A.CountName ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        Return _ThidTable
    End Function
    Private Sub _GetYarnRequirQty(ByVal _ItemCode As String)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" A.ID AS PlanNo  ")
            .Append(" ,D.CountName  ")
            .Append(" ,Z.CountCode  ")
            .Append(" ,Z.Accountcode  ")
            .Append(" ,0.00 as FYPStk")
            .Append(" ,sum(z.RequirQty) as RequirQty ")
            .Append(" ,ISNULL(SUM(Z.FactStkUse),0) as FactStkUse")
            .Append(" ,ISNULL(SUM(Z.PurchPlan),0)-ISNULL(SUM(Z.PurchOrder),0) as PurPlanQty")
            .Append(" ,ISNULL(SUM(Z.PurchOrder),0) as YarnOrder")
            .Append(" ,sum(z.RequirQty)-(SUM(Z.FactStkUse)+SUM(Z.PurchPlan)) as YarnBalReq")
            .Append(" FROM ( ")
            .Append(" SELECT  ")
            .Append(" A.ID AS ENo ")
            .Append(" ,C.CountCode   ")
            .Append(" ,A.TAXSLAB AS Accountcode ")

            .Append(" ,(CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)))* ISNULL(C.Avg_weight,0) as RequirQty ")
            .Append(" ,0.00 PlanQty ")
            .Append(" ,0.00 FactStkUse ")
            .Append(" ,0.00 PurchPlan ")
            .Append(" ,0.00 PurchOrder ")
            .Append(" FROM MstItemBatchWise AS A  ")
            .Append(" LEFT JOIN MstFabricItem AS B  ON A.GROUPNAME=B.ID  ")
            .Append(" LEFT JOIN MstFabricItemCons AS C ON A.GROUPNAME=C.Fabric_ItemCode  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND MRP='NO'   ")
            .Append(" AND A.SHORTNAME='NEW QUALITY PLANNING' ")
            .Append(" UNION ALL  ")
            .Append(" SELECT  ")
            .Append(" A.Offerno AS ENo ")
            .Append(" ,a.ItemCode as CountCode   ")
            .Append(" ,a.Accountcode  ")
            .Append(" ,0.00 as RequirQty ")
            .Append(" ,0.00  PlanQty ")
            .Append(" ,0.00 FactStkUse ")
            .Append(" ,a.Mtr_Weight PurchPlan ")
            .Append(" ,0.00 PurchOrder ")
            .Append(" FROM TrnOffer  AS A  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND DESCR in ('PURCHASE')")
            .Append(" AND Bookcode='YRNPL-000000001'   ")
            .Append(" UNION ALL  ")
            .Append(" SELECT  ")
            .Append(" A.Offerno AS ENo ")
            .Append(" ,a.ItemCode as CountCode   ")
            .Append(" ,a.Accountcode   ")
            .Append(" ,0.00 as RequirQty ")
            .Append(" ,0.00  PlanQty ")
            .Append(" ,(a.Mtr_Weight) FactStkUse ")
            .Append(" ,0.00 PurchPlan ")
            .Append(" ,0.00 PurchOrder ")
            .Append(" FROM TrnOffer  AS A  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND DESCR in ('FACTORY STOCK')")
            .Append(" AND Bookcode='YRNPL-000000001'   ")
            .Append(" UNION ALL  ")
            .Append(" SELECT  ")
            .Append(" A.Offerno AS ENo ")
            .Append(" ,a.ItemCode as CountCode   ")
            .Append(" ,a.Accountcode   ")
            .Append(" ,0.00 as RequirQty ")
            .Append(" ,0.00  PlanQty ")
            .Append(" ,0.00 FactStkUse ")
            .Append(" ,0.00 PurchPlan ")
            .Append(" ,(a.Mtr_Weight) PurchOrder ")
            .Append(" FROM TrnOffer  AS A  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND DESCR in ('YARN PLANNING ENTRY')")
            .Append(" AND Bookcode='YRNPO-000000002'   ")
            .Append(" ) AS Z ")
            .Append(" LEFT JOIN MstYarnCount AS D ON z.CountCode=D.CountCode  ")
            .Append(" left join (SELECT ID,HSNCODE as PlanDate,GROUPNAME AS ItemCode,COMPNAME AS DesignCode,PRIMERUNIT AS Shadecode,SHORTNAME,MRP FROM MstItemBatchWise GROUP BY ID,HSNCODE,GROUPNAME,COMPNAME,PRIMERUNIT,SHORTNAME,MRP) AS A ON  Z.ENo =A.ID  ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.ItemCode='" & _ItemCode & "'")
            .Append(" GROUP BY ")
            .Append(" A.ID ")
            .Append(" ,D.CountName  ")
            .Append(" ,Z.CountCode  ")
            .Append(" ,Z.Accountcode  ")
            If FactoryActiveClmName = "YarnRequire" Then
                .Append(" HAVING (sum(z.RequirQty)-SUM(z.PlanQty))-(SUM(Z.FactStkUse)+SUM(Z.PurchPlan)) >0 ")
            ElseIf FactoryActiveClmName = "YarnPlan" Then
                .Append(" HAVING ISNULL(SUM(Z.PurchPlan),0)-ISNULL(SUM(Z.PurchOrder),0) >0 ")
            End If


        End With

        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy

        FactStockTable = DefaltSoftTable.Copy

        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else
            For Each dr As DataRow In _ThidTable.Select
                Dim _filter As String = " and Z.ITEMCODE='" & dr("CountCode").ToString & "' and Z.Accountcode='" & dr("Accountcode").ToString & "'"
                Dim Tbl As New DataTable
                Tbl = YarnPlaningEntry._GetFactoryYarnPlanStock(_filter)
                If Tbl.Rows.Count > 0 Then
                    dr("FYPStk") = Tbl(0).Item("YarnInStk")
                End If
            Next


            Dim columnNames As String() = {"FYPStk", "RequirQty", "PurPlanQty", "YarnOrder", "YarnBalReq", "FactStkUse"}

            For Each dr As DataRow In _ThidTable.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0.00", True)
                Next
            Next

            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy

            _GriddataSum(GridControl2, GridView1, columnNames, "NO")

            GridView1.Columns("CountCode").Visible = False
            GridView1.Columns("Accountcode").Visible = False
            'GridView1.Columns("YarnBalQty").Visible = False

            DevGridFitColumn(GridControl2, GridView1)
            'GridView1.Columns("YarnRequire").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "YarnRequire", "{0}"))

            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridControl2.Focus()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If
    End Sub

    Private Sub _GetYarnPurQty(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT*FROM ( ")
            .Append(" SELECT ")
            .Append(" D.ENTRYNO AS EntryNo ")
            .Append(" ,D.CHALLANNO as ChallanNo ")
            .Append(" ,D.CHALLANDATE AS ChlDate ")
            .Append(" ,H.ACCOUNTNAME as PartyName")
            .Append(" ,G.CountName  ")
            .Append(" ,SUM(D.ACTUAL_WEIGHT) as YarnRecived")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN TrnOffer AS F  ON B.CountCode=F.ITEMCODE")
            .Append(" LEFT JOIN TrnOffer AS E  ON F.LOOM_TYPE=E.BOOKVNO")
            .Append(" LEFT JOIN MSTBOOK AS C ON F.BOOKCODE=C.BOOKCODE ")
            .Append(" LEFT JOIN TrnFactoryYarn AS D ON ( D.OFFERBOOKVNO=F.BOOKVNO AND  F.ITEMCODE=D.COUNTCODE) ")
            .Append(" LEFT JOIN MstYarnCount AS G ON D.COUNTCODE=G.CountCode ")
            .Append(" LEFT JOIN MstMasterAccount AS H  ON D.ACCOUNTCODE=H.ACCOUNTCODE")
            .Append(" WHERE 1=1 ")
            .Append(" AND E.ITEMCODE=F.ITEMCODE ")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND E.OFFERNO=A.ID")
            .Append(" AND F.DESCR in ('YARN PLANNING ENTRY')")
            .Append(" AND D.OFFERBOOKVNO=F.BOOKVNO ")
            .Append(" AND E.BOOKVNO >'' ")
            .Append(" AND A.MINSALE <> 'JOB RCPT' ")
            .Append(" GROUP BY ")
            .Append(" D.ENTRYNO ")
            .Append(" ,D.CHALLANNO ")
            .Append(" ,D.CHALLANDATE ")
            .Append(" ,H.ACCOUNTNAME")
            .Append(" ,G.CountName  ")
            .Append(" HAVING SUM(D.ACTUAL_WEIGHT)>0")


            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" D.ENTRYNO AS EntryNo ")
            .Append(" ,D.CHALLANNO as ChallanNo ")
            .Append(" ,D.CHALLANDATE AS ChlDate ")
            .Append(" ,H.ACCOUNTNAME as PartyName")
            .Append(" ,G.CountName  ")
            .Append(" ,SUM(D.ACTUAL_WEIGHT) as YarnRecived")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN TrnFactoryYarn AS D ON ( D.OFFERBOOKVNO=A.ITEMNAME AND  B.COUNTCODE=D.COUNTCODE) ")
            .Append(" LEFT JOIN MstYarnCount AS G ON D.COUNTCODE=G.CountCode ")
            .Append(" LEFT JOIN MstMasterAccount AS H  ON D.ACCOUNTCODE=H.ACCOUNTCODE")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.MINSALE='JOB RCPT' ")
            .Append(" AND B.COUNTCODE=D.COUNTCODE ")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.MINSALE='JOB RCPT'")
            .Append(" AND D.OFFERBOOKVNO=A.ITEMNAME ")
            .Append(" AND D.OFFERBOOKVNO >'' ")
            .Append(" GROUP BY ")
            .Append(" D.ENTRYNO ")
            .Append(" ,D.CHALLANNO ")
            .Append(" ,D.CHALLANDATE ")
            .Append(" ,H.ACCOUNTNAME")
            .Append(" ,G.CountName  ")
            .Append(" HAVING SUM(D.ACTUAL_WEIGHT)>0")

            .Append(" ) AS Z ")
            .Append(" ORDER BY Z.ENTRYNO ")

        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else
            GridView1.Columns.Clear()


            Dim columnNames As String() = {"YarnRecived"}

            For Each dr As DataRow In _ThidTable.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
            Next

            GridControl2.DataSource = _ThidTable.Copy

            _GriddataSum(GridControl2, GridView1, columnNames, "NO")
            DevGridFitColumn(GridControl2, GridView1)


            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If

    End Sub
    Private Sub _GetYarnOrderQty(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append("  F.ENTRYNO AS EntryNo ")
            .Append(" ,F.OFFERDATE AS OrderDate ")
            .Append(" ,H.ACCOUNTNAME as PartyName")
            .Append(" ,D.CountName  ")
            .Append(" ,SUM (F.Mtr_Weight) as YarnOrder")
            .Append(" ,F.Rate as Rate")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN MstFabricItemCons AS B ON A.GROUPNAME=B.Fabric_ItemCode ")
            .Append(" LEFT JOIN MstYarnCount AS D ON B.CountCode=D.CountCode ")
            .Append(" LEFT JOIN TrnOffer AS F  ON B.CountCode=F.ITEMCODE")
            .Append(" LEFT JOIN MstMasterAccount AS H  ON F.ACCOUNTCODE=H.ACCOUNTCODE")
            .Append(" LEFT JOIN MSTBOOK AS C ON F.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND F.accountcode=a.TAXSLAB ")
            .Append(" AND F.DESCR in ('YARN PLANNING ENTRY')")
            .Append(" AND F.Bookcode='YRNPO-000000002'   ")

            .Append(" AND ISNULL((F.Mtr_Weight),0)>0 ")
            .Append(" AND F.OFFERNO > '0'   ")
            '.Append(" AND A.ID=ISNULL(NULLIF(B.OP16, ''), 0) ")
            '.Append(" AND C.BOOKCATEGORY='OFFER' AND C.BEHAVIOUR='YARN' ")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" GROUP BY ")
            .Append("  F.ENTRYNO  ")
            .Append(" ,F.OFFERDATE  ")
            .Append(" ,H.ACCOUNTNAME ")
            .Append(" ,D.CountName  ")
            .Append(" ,F.Rate")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else
            GridView1.Columns.Clear()


            Dim columnNames As String() = {"YarnOrder"}

            For Each dr As DataRow In _ThidTable.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
            Next

            GridControl2.DataSource = _ThidTable.Copy

            _GriddataSum(GridControl2, GridView1, columnNames, "NO")
            DevGridFitColumn(GridControl2, GridView1)



            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If
    End Sub
    Private Sub _GetGreyQuery(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" B.ENTRYNO AS EntryNo ")
            .Append(" ,B.OFFERDATE AS OrderDate ")
            .Append(" ,E.ACCOUNTNAME as PartyName")
            .Append(" ,D.ITENNAME as ItemName ")
            .Append(" ,F.Design_Name as Design")
            .Append(" ,G.SHADE as Shade")
            .Append(" ,B.Mtr_Weight as GreyOrder")
            .Append(" ,B.REED as Reed")
            .Append(" ,B.DENT as Dent")
            .Append(" ,B.ReedSpace")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnOffer AS B ON A.ID=ISNULL(NULLIF(B.OP16, ''), 0) ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append("  LEFT JOIN  MstFabricItem AS D ON A.GROUPNAME=D.id ")
            .Append("  LEFT JOIN MstMasterAccount AS E  ON B.ACCOUNTCODE=E.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS F  ON A.COMPNAME=F.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS G  ON A.PRIMERUNIT=G.ID")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.ID=ISNULL(NULLIF(B.OP16, ''), 0) ")
            .Append(" AND C.BOOKCATEGORY='OFFER' AND C.BEHAVIOUR='GREY' ")

        End With
        sqL = _strQuery.ToString
        sql_connect_slect()

        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else

            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy

            GridView1.Columns("GreyOrder").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            DevGridFitColumn(GridControl2, GridView1)

            GridView1.Columns("GreyOrder").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GreyOrder", "{0}"))

            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If
    End Sub
    Private Sub _GetJobQuery(ByVal _ItemCode As String)

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" B.ENTRYNO AS EntryNo ")
            .Append(" ,B.OFFERDATE AS OrderDate ")
            .Append(" ,E.ACCOUNTNAME as PartyName")
            .Append(" ,D.ITENNAME as ItemName ")
            .Append(" ,F.Design_Name as Design")
            .Append(" ,G.SHADE as Shade")
            .Append(" ,B.Mtr_Weight as JobOrder")
            .Append(" ,B.REED as Reed")
            .Append(" ,B.DENT as Dent")
            .Append(" ,B.ReedSpace")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnOffer AS B ON A.ID=ISNULL(NULLIF(B.OP16, ''), 0) ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append("  LEFT JOIN  MstFabricItem AS D ON A.GROUPNAME=D.id ")
            .Append("  LEFT JOIN MstMasterAccount AS E  ON B.ACCOUNTCODE=E.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS F  ON A.COMPNAME=F.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS G  ON A.PRIMERUNIT=G.ID")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.ID=ISNULL(NULLIF(B.OP16, ''), 0) ")
            .Append(" AND C.BOOKCATEGORY='OFFER' AND C.BEHAVIOUR='JOB-WEAVING' ")

        End With
        sqL = _strQuery.ToString
        sql_connect_slect()

        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else

            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy

            GridView1.Columns("JobOrder").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            DevGridFitColumn(GridControl2, GridView1)

            GridView1.Columns("JobOrder").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JobOrder", "{0}"))

            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If
    End Sub
    Private Sub _GetPlanningQuery(ByVal _ItemCode As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" a.id as EntryNo ")
            .Append(" ,FORMAT(CONVERT(datetime, A.HSNCODE, 103), 'dd/MM/yyyy') AS EntryDate ")
            .Append(" ,C.ACCOUNTNAME as PartyName")
            .Append(" ,B.ITENNAME as ItemName ")
            .Append(" ,D.Design_Name as Design")
            .Append(" ,E.SHADE as Shade")
            .Append(" ,a.ALTUNIT as PlanQty ")
            .Append(" ,ISNULL(SUM(F.Mtr_Weight),0) as JobOrder")
            .Append(" ,a.ALTUNIT-ISNULL(SUM(F.Mtr_Weight),0) as BalPlanQty ")
            .Append(" FROM  MstItemBatchWise AS  A ")
            .Append("  LEFT JOIN  MstFabricItem AS B ON A.GROUPNAME=B.id ")
            .Append("  LEFT JOIN MstMasterAccount AS C  ON A.TAXSLAB=C.ACCOUNTCODE")
            .Append("  LEFT JOIN Mst_Fabric_Design AS D  ON A.COMPNAME=D.Design_code")
            .Append("  LEFT JOIN Mst_Fabric_Shade AS E  ON A.PRIMERUNIT=E.ID")
            .Append("  LEFT JOIN TrnOffer AS F ON (A.ID=ISNULL(NULLIF(F.OP16, ''), 0) AND A.GROUPNAME=F.ITEMCODE) ")
            .Append(" WHERE 1=1 ")

            .Append(" AND A.GROUPNAME='" & _ItemCode & "' ")
            .Append(" AND A.MRP='NO' ")
            .Append(" GROUP BY")
            .Append(" a.id ")
            .Append(" ,A.HSNCODE")
            .Append(" ,C.ACCOUNTNAME")
            .Append(" ,B.ITENNAME ")
            .Append(" ,D.Design_Name ")
            .Append(" ,E.SHADE")
            .Append(" ,a.ALTUNIT ")

            .Append(" ORDER BY a.id ")
        End With
        sqL = _strQuery.ToString
        sql_connect_slect()

        Dim _ThidTable As New DataTable
        _ThidTable = DefaltSoftTable.Copy
        If _ThidTable.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else

            For Each dr As DataRow In _ThidTable.Select

                dr("PlanQty") = Convert.ToDouble(dr("PlanQty")).ToString("0.00")
                dr("JobOrder") = Convert.ToDouble(dr("JobOrder")).ToString("0.00")
                dr("BalPlanQty") = Convert.ToDouble(dr("BalPlanQty")).ToString("0.00")


                If Val(dr("PlanQty")) = 0 Then dr("PlanQty") = DBNull.Value
                If Val(dr("JobOrder")) = 0 Then dr("JobOrder") = DBNull.Value
                If Val(dr("BalPlanQty")) = 0 Then dr("BalPlanQty") = DBNull.Value
            Next

            GridView1.Columns.Clear()
            GridControl2.DataSource = _ThidTable.Copy
            GridView1.Columns("PlanQty").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns("JobOrder").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            GridView1.Columns("BalPlanQty").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            DevGridFitColumn(GridControl2, GridView1)
            GridView1.Columns("PlanQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PlanQty", "{0}"))
            GridView1.Columns("BalPlanQty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalPlanQty", "{0}"))
            GridView1.Columns("JobOrder").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "JobOrder", "{0}"))
            GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
            GridControl2.Visible = True
            GridControl2.BringToFront()
            GridView1.Focus()
            GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
        End If
    End Sub
    Private Sub _GetFactroyYarnStkUe(ByVal PlanNo As String, ByVal CountCode As String, ByVal FilterColumName As String, ByVal Stockdisplay As String)
        Try

            'PlanNo, CountCode, SelectionType, "FACTORY STOCK"

            Dim _bookcode As String = ""

            If Stockdisplay = "YARN PLANNING ENTRY" Then
                _bookcode = "YRNPO-000000002"
            Else
                _bookcode = "YRNPL-000000001"
            End If
            _strQuery = New StringBuilder
            With _strQuery

                .Append(" SELECT  ")
                .Append(" a.ItemCode as CountCode   ")
                .Append(" ,A.Offerno AS PlanNo ")
                .Append(" ,A.EntryNo ")
                .Append(" ,A.OfferDate as Date ")
                .Append(" ,d.CountName ")
                .Append(" ,a.Mtr_Weight Qty ")
                .Append(" FROM TrnOffer  AS A  ")
                .Append(" LEFT JOIN MstYarnCount AS D ON a.ItemCode=D.CountCode ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.OFFERNO ='" & PlanNo & "'")
                .Append(" AND A.ItemCode ='" & CountCode & "'")
                .Append(" AND a.DESCR = '" & Stockdisplay & "'")
                .Append(" AND a.Bookcode = '" & _bookcode & "'")


                '.Append(" SELECT  ")
                '.Append(" A.Offerno AS ENo ")
                '.Append(" ,a.ItemCode as CountCode   ")
                '.Append(" ,0.00 as RequirQty ")
                '.Append(" ,0.00  PlanQty ")
                '.Append(" ,(a.Mtr_Weight) FactStkUse ")
                '.Append(" ,0.00 PurchPlan ")
                '.Append(" ,0.00 PurchOrder ")
                '.Append(" FROM TrnOffer  AS A  ")
                '.Append(" WHERE 1=1 ")
                '.Append(" AND DESCR in ('FACTORY STOCK')")
                '.Append(" AND Bookcode='YRNPL-000000001'   ")
                '.Append(" UNION ALL  ")
                '.Append(" SELECT  ")
                '.Append(" A.Offerno AS ENo ")
                '.Append(" ,a.ItemCode as CountCode   ")
                '.Append(" ,0.00 as RequirQty ")
                '.Append(" ,0.00  PlanQty ")
                '.Append(" ,0.00 FactStkUse ")
                '.Append(" ,0.00 PurchPlan ")
                '.Append(" ,(a.Mtr_Weight) PurchOrder ")
                '.Append(" FROM TrnOffer  AS A  ")
                '.Append(" WHERE 1=1 ")
                '.Append(" AND DESCR in ('YARN PLANNING ENTRY')")
                '.Append(" AND Bookcode='YRNPO-000000002'   ")
                '.Append(" ) AS Z ")
                '.Append(" LEFT JOIN MstYarnCount AS D ON z.CountCode=D.CountCode  ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim _tmptbl As New DataTable
            _tmptbl = DefaltSoftTable.Copy



            If _tmptbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else
                For Each dr As DataRow In _tmptbl.Select
                    dr("Qty") = Convert.ToDouble(dr("Qty")).ToString("0.00")

                    If Val(dr("Qty")) = 0 Then dr("Qty") = DBNull.Value
                Next
                GridView1.Columns.Clear()

                GridControl2.DataSource = _tmptbl.Copy

                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridView1.Columns("Qty").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "{0}"))

                GridView1.Columns("CountCode").Visible = False

                GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

#End Region

#End Region

#Region "Process Menu"
    Private Sub _textBoxVisablecheck(ByVal _Visbal As Boolean)
        LblRemark_4.Visible = _Visbal
        LblRemark_4dot.Visible = _Visbal
        Txt_Remark_4.Visible = _Visbal
    End Sub


    Private Sub _RemarkLableNameChange()
        _textBoxVisablecheck(False)


        If SelectionOfView = "Process" Then
            Lbl_PymtDate.Text = "Date"
            LblPymtRemark.Text = "Beam No"
            Lbl_GrRemark.Text = "Shade"
            Lbl_OtherRemark.Text = "Remark"
        ElseIf SelectionOfView = "Factory" Then
            Lbl_PymtDate.Text = "Date"
            LblPymtRemark.Text = "Count"
            Lbl_GrRemark.Text = "Qty"
            Lbl_OtherRemark.Text = "Remark"

        Else
            Lbl_PymtDate.Text = "Pymt Date"
            LblPymtRemark.Text = "Pymt Remark"
            Lbl_GrRemark.Text = "GR Remark"
            Lbl_OtherRemark.Text = "Other Remark"
        End If

    End Sub
    Private Sub ProcessDashBord_Click(sender As Object, e As EventArgs) Handles ProcessDashBord.Click
        LblSelectedOptionName.Text = "Process DashBoard"
        SelectionDashBordName = "Process DashBoard"
        SelectionOfView = "Process"
        Txt_ProcessStockDisplay.SpacerString = "PROCESS WISE,ITEM WISE"
        _RemarkLableNameChange()
        SelectionButton = ""
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = False
        GridView1.OptionsBehavior.Editable = False
        PnlColoView.Visible = False
        _ProcessStkLblDiplay(True)
        ProcessDashbordDispaly()
    End Sub
    Private Sub BtnProcessRefresh_Click(sender As Object, e As EventArgs) Handles BtnProcessRefresh.Click

        If SelectionDashBordName = "Factory DashBoard" Then
            _FactoryDesbordLoad()
        ElseIf SelectionDashBordName = "Producation DashBoard" Then
            _ProducationDesbordLoad()
        ElseIf SelectionDashBordName = "Sales Planning DashBoard" Then
            SalesAllCompanyPlanningDashBoard()
        Else SelectionDashBordName = "Process DashBoard"
            ProcessDashbordDispaly()
        End If

    End Sub
    Private Sub ProcessDashbordDispaly()

        AvgWtPerMtr = " (150/ iif(avg(D.WTPERMTR)=0,0.001,avg(D.WTPERMTR))) "

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            If Txt_ProcessStockDisplay.Text = "PROCESS WISE" Then
                .Append(" X.PROCESSCODE  ")
                .Append(" ,C.ACCOUNTNAME as Process ")
            ElseIf Txt_ProcessStockDisplay.Text = "ITEM WISE" Then
                .Append(" X.ITEMCODE ")
                .Append(" ,D.ITENNAME as Item  ")
            End If

            .Append(" ,SUM(X.FdMtr)+SUM(X.PdMtr) AS  ProcStk")
            .Append(" ,SUM(X.MixMtr) AS  MixMtr")
            .Append(" ,SUM(X.DprMtr) AS  DprMtr")
            .Append(" ,SUM(X.GradingDprMtr) AS  GrdDprMtr")
            .Append(" ,SUM(X.GreyMtr) AS  GreyMtr")
            .Append(" ,CEILING(SUM(X.PBeam) * " & AvgWtPerMtr & " / 25.0) * 25 AS PMtr ")
            .Append(" ,CEILING((SUM(X.FdMtr)+SUM(X.PdMtr) - ((SUM(X.PBeam) * " & AvgWtPerMtr & ")+SUM(X.TotalPlanMtr))) / 25.0) * 25 AS PlanBal ")
            .Append(" ,SUM(X.PBeam) AS PBeam  ")
            .Append(" ,SUM(X.Req) AS Req ")
            .Append(" ,SUM(X.Wash) AS Wash ")
            .Append(" ,SUM(X.Dyn) AS  Dyn")
            .Append(" ,SUM(X.Stenter) AS Stenter ")
            .Append(" ,SUM(X.Mechan) AS Mechan ")
            .Append(" ,SUM(X.Fold) AS Fold ")
            .Append(" ,SUM(X.TblChk) AS TblChk ")
            .Append(" ,SUM(X.RtMtr) AS RtMtr ")
            .Append(" ,SUM(X.Ready) AS Ready ")
            .Append(" ,SUM(X.Decision) AS Decision ")

            .Append(" FROM ( ")

#Region "Process Stock"

            .Append(" SELECT ")
            .Append(" Z.FABRIC_ITEMCODE as ITEMCODE ,Z.PROCESSCODE  ")
            .Append(" ,SUM(Z.GFDMtr)-SUM(Z.FFDMtr) AS FdMtr ")
            .Append(" ,SUM(Z.GPDMtr)-SUM(Z.FPDMtr) AS PdMtr ")
            .Append(" ,SUM(Z.GMixMtr)-SUM(Z.FMixMtr) AS MixMtr ")

            .Append(" ,0.00 AS DprMtr ")
            .Append(" ,0.00 AS PBeam ")
            .Append(" ,0.00 AS PMtr ")
            .Append(" ,0.00 AS PlanBal ")
            .Append(" ,0.00 AS Req ")
            .Append(" ,0.00 AS Wash ")
            .Append(" ,0.00 AS Dyn ")
            .Append(" ,0.00 AS Stenter ")
            .Append(" ,0.00 AS Mechan ")
            .Append(" ,0.00 AS Fold ")
            .Append(" ,0.00 AS TblChk ")
            .Append(" ,0.00 AS RtMtr ")
            .Append(" ,0.00 AS Ready ")
            .Append(" ,0.00 AS Decision ")
            .Append(" ,0.00 AS TotalPlanMtr ")
            .Append(" ,0.00 AS GradingDprMtr ")
            .Append(" ,0.00 AS GreyMtr ")
            .Append(" FROM ( ")
            .Append(" SELECT    ")
            .Append(" A.FABRIC_ITEMCODE,A.PROCESSCODE  ")
            .Append(" ,IIF (A.FD_PD='FD',(A.GMTR),0) AS GFDMtr ")
            .Append(" ,IIF (A.FD_PD='PD',(A.GMTR),0) AS GPDMtr ")
            .Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),(A.GMTR),0) AS  GMixMtr ")
            .Append(" ,0.00 AS FMixMtr ")
            .Append(" ,0.00 AS FFDMtr ")
            .Append(" ,0.00 AS FPDMtr ")
            .Append(" ,a.PcAvgWt ")
            .Append(" ,a.BeamNo ")
            .Append(" ,a.PieceNo ")
            .Append(" FROM TRNGREYDESP AS A  ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.IDP='YES' ")
            .Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            .Append(" UNION ALL ")
            .Append(" SELECT    ")
            .Append(" A.FABRIC_ITEMCODE,A.PROCESSCODE  ")
            .Append(" ,0.00 AS GFDMtr ")
            .Append(" ,0.00 AS GPDMtr ")
            .Append(" ,0.00 AS  GMixMtr ")
            .Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),ISNULL(B.GMTR,0),0) AS FMixMtr ")
            .Append(" ,IIF (A.FD_PD='FD',ISNULL(B.GMTR,0),0) AS FFDMtr ")
            .Append(" ,IIF (A.FD_PD='PD',ISNULL(B.GMTR,0),0) AS FPDMtr ")
            .Append(" ,a.PcAvgWt ")
            .Append(" ,a.BeamNo ")
            .Append(" ,a.PieceNo ")
            .Append(" FROM TRNGREYDESP AS A  ")
            .Append(" LEFT JOIN TRNFINISHRCPT AS B ON A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.IDP='YES' ")
            .Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            .Append(" ) AS Z ")
            .Append(" GROUP BY ")
            .Append(" Z.FABRIC_ITEMCODE,Z.PROCESSCODE ")
            .Append(" ,Z.BeamNo ")
            .Append(" ,Z.PieceNo ")
            .Append(" HAVING (SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.GMixMtr)+SUM(Z.FMixMtr))-(SUM(Z.FFDMtr)+SUM(Z.FPDMtr))>0 ")

#End Region

#Region "Process DPR Stock"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE as ITEMCODE ,A.PROCESSCODE  ")
            .Append(" ,0.00 AS FdMtr ")
            .Append(" ,0.00 AS PdMtr ")
            .Append(" ,0.00 AS  MixMtr ")
            .Append(" ,(A.GMTR)-ISNULL(sum(B.GMTR),0) AS DprMtr ")
            .Append(" ,0.00 AS PBeam ")
            .Append(" ,0.00 AS PMtr ")
            .Append(" ,0.00 AS PlanBal ")
            .Append(" ,0.00 AS Req ")
            .Append(" ,0.00 AS Wash ")
            .Append(" ,0.00 AS Dyn ")
            .Append(" ,0.00 AS Stenter ")
            .Append(" ,0.00 AS Mechan ")
            .Append(" ,0.00 AS Fold ")
            .Append(" ,0.00 AS TblChk ")
            .Append(" ,0.00 AS RtMtr ")
            .Append(" ,0.00 AS Ready ")
            .Append(" ,0.00 AS Decision ")
            .Append(" ,0.00 AS TotalPlanMtr ")
            .Append(" ,0.00 AS GradingDprMtr ")
            .Append(" ,0.00 AS GreyMtr ")
            .Append(" FROM ")
            .Append(" TRNGREYDESP AS A ")
            .Append(" LEFT JOIN TRNFINISHRCPT AS B ON  A.GREY_DESP_PCS_ID = B.GREY_DESP_PCS_ID ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.IDP='YES' ")
            .Append(" AND A.BOOKCODE IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            .Append(" group by ")
            .Append(" a.fabric_ItemCode ")
            .Append(" ,a.Fabric_ShadeCode ")
            .Append(" ,A.BeamNo ")
            .Append(" ,A.PieceNo ")
            .Append(" ,A.Weight ")
            .Append(" ,A.PcAvgWt ")
            .Append(" ,A.Pick ")
            .Append(" ,A.FD_PD ")
            .Append(" ,A.EntryNo ")
            .Append(" ,A.GMTR ")
            .Append(" ,A.ChallanDate ")
            .Append(" ,A.BookVno ")
            .Append(" ,A.BookCode ")
            .Append(" ,A.ProcessCode ")
            .Append(" ,A.AccountCode ")
            .Append(" ,A.FactoryCode ")
            .Append(" ,A.Process_ShadeType ")
            .Append(" having (A.GMTR)-ISNULL(sum(B.GMTR),0)>0 ")
#End Region

#Region "Process Stock After Req"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.FABRIC_ITEMCODE as ITEMCODE ,A.PROCESSCODE  ")
            .Append(" ,0.00 AS FdMtr ")
            .Append(" ,0.00 AS PdMtr ")
            .Append(" ,0.00 AS  MixMtr ")
            .Append(" ,0.00 AS DprMtr ")
            .Append(" ,0.00 AS PBeam ")
            .Append(" ,0.00 AS PMtr ")
            .Append(" ,0.00 AS PlanBal ")
            .Append(" ,0.00 AS Req ")
            .Append(" ,0.00 AS Wash ")
            .Append(" ,0.00 AS Dyn ")
            .Append(" ,0.00 AS Stenter ")
            .Append(" ,0.00 AS Mechan ")
            .Append(" ,0.00 AS Fold ")
            .Append(" ,0.00 AS TblChk ")
            .Append(" ,0.00 AS RtMtr ")
            .Append(" ,0.00 AS Ready ")
            .Append(" ,0.00 AS Decision ")
            .Append(" ,0.00 AS TotalPlanMtr ")
            .Append(" ,0.00 AS GradingDprMtr ")
            .Append(" ,A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0),3) AS GreyMtr ")
            .Append(" FROM ")
            .Append(" TRNGREYDESP AS A ")
            .Append(" LEFT JOIN TRNFINISHRCPT AS B ON  A.GREY_DESP_PCS_ID = B.GREY_DESP_PCS_ID ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.IDP='YES' ")
            .Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            .Append(" AND (A.Process_PcsIdSelect IS NULL  OR A.Process_PcsIdSelect='')  ")
            .Append(" group by ")
            .Append(" a.fabric_ItemCode ")
            .Append(" ,a.Fabric_ShadeCode ")
            .Append(" ,A.BeamNo ")
            .Append(" ,A.PieceNo ")
            .Append(" ,A.Weight ")
            .Append(" ,A.PcAvgWt ")
            .Append(" ,A.Pick ")
            .Append(" ,A.FD_PD ")
            .Append(" ,A.EntryNo ")
            .Append(" ,A.GMTR ")
            .Append(" ,A.ChallanDate ")
            .Append(" ,A.BookVno ")
            .Append(" ,A.BookCode ")
            .Append(" ,A.ProcessCode ")
            .Append(" ,A.AccountCode ")
            .Append(" ,A.FactoryCode ")
            .Append(" ,A.Process_ShadeType ")
            .Append(" having (A.GMTR)-ISNULL(sum(B.GMTR),0)>0 ")
#End Region

#Region "Plan Beam"
            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" Z.ITEMCODE ")
            .Append(" ,Z.ProcessCode ")
            .Append(" ,0.00 AS FdMtr ")
            .Append(" ,0.00 AS PdMtr ")
            .Append(" ,0.00 AS MixMtr ")
            .Append(" ,0.00 AS DprMtr ")
            .Append(" ,SUM(Z.TotalBeamPlan) AS PBeam  ")
            .Append(" ,0.00 AS PMtr ")
            .Append(" ,0.00 AS PlanBal  ")
            .Append(" ,0.00 AS Req  ")
            .Append(" ,SUM(Z.Wash) AS Wash ")
            .Append(" ,SUM(Z.Dyn) AS Dyn ")
            .Append(" ,SUM(Z.Stenter) AS Stenter ")
            .Append(" ,SUM(Z.Mechan) AS Mechan ")
            .Append(" ,SUM(Z.Fold) AS Fold ")
            .Append(" ,SUM(Z.TblChk) AS TblChk ")
            .Append(" ,0.00 AS RtMtr  ")
            .Append(" ,0.00 AS Ready  ")
            .Append(" ,0.00 AS Decision  ")
            .Append(" ,0.00 AS TotalPlanMtr  ")
            .Append(" ,0.00 AS GradingDprMtr  ")
            .Append(" ,0.00 AS GreyMtr ")
            .Append(" FROM ( ")
            .Append(" SELECT  ")
            .Append(" A.Fabric_ItemCode AS ITEMCODE  ")
            .Append(" ,A.ProcessCode  ")
            .Append(" ,B.Process_Dyeing_Bookvno AS  BookVno ")
            .Append(" , IIF (A.Process_OT5 ='NO' OR  A.Process_OT5 IS NULL ,A.No_Of_Beam ,0) AS TotalBeamPlan ")
            .Append(" , IIF (A.Process_OT5='Washing',A.No_Of_Beam,0) AS Wash ")
            .Append(" , IIF (A.Process_OT5 IN ('Dyening','Re Dyening'),A.No_Of_Beam,0) AS Dyn ")
            .Append(" , IIF (A.Process_OT5='Stenter',A.No_Of_Beam,0) AS Stenter ")
            .Append(" , IIF (A.Process_OT5='Mechanical',A.No_Of_Beam,0) AS Mechan ")
            .Append(" , IIF (A.Process_OT5='Folding',A.No_Of_Beam,0) AS Fold ")
            .Append(" , IIF (A.Process_OT5='Table Checking',A.No_Of_Beam,0) AS TblChk ")
            .Append(" FROM  TrnProcessDyeingPlan AS A  ")
            .Append(" left join TRNGREYDESP as B ON ( A.BookVno =B.Process_Dyeing_Bookvno and A.Fabric_ItemCode=B.Fabric_ItemCode and A.Fabric_ShadeCode=B.Fabric_ShadeCode)   ")
            .Append(" WHERE 1=1  ")
            .Append(" AND a.BOOKCODE='PRDY-000000001'  ")
            .Append(" AND (B.Process_Dyeing_Bookvno IS NULL) ")
            .Append(" ) AS Z ")
            .Append(" GROUP BY ")
            .Append(" Z.ITEMCODE ")
            .Append(" ,Z.ProcessCode ")
#End Region

#Region "Pending PBeam"

            .Append(" UNION ALL ")

            .Append(" SELECT ")
            .Append(" A.Fabric_ItemCode AS ITEMCODE ")
            .Append(" ,A.ProcessCode ")
            .Append(" ,0.00 AS FdMtr ")
            .Append(" ,0.00 AS PdMtr ")
            .Append(" ,0.00 AS MixMtr ")
            .Append(" ,0.00 AS DprMtr ")
            .Append(" ,0.00 AS PBeam ")
            .Append(" ,0.00 AS PMtr ")
            .Append(" ,0.00 AS PlanBal ")
            .Append(" , IIF (A.Process_OT5='NO',COUNT (distinct A.Process_EntryNo ),0) AS Req ")

            .Append(" , IIF (A.Process_OT5='Washing',COUNT (distinct A.Process_EntryNo ),0) AS Wash ")
            .Append(" , IIF (A.Process_OT5 IN ('Dyening','Re Dyening'),COUNT (distinct A.Process_EntryNo ),0) AS Dyn ")
            .Append(" , IIF (A.Process_OT5='Stenter',COUNT (distinct A.Process_EntryNo ),0) AS Stenter ")
            .Append(" , IIF (A.Process_OT5='Mechanical',COUNT (distinct A.Process_EntryNo ),0) AS Mechan ")
            .Append(" , IIF (A.Process_OT5='Folding',COUNT (distinct A.Process_EntryNo ),0) AS Fold ")
            .Append(" , IIF (A.Process_OT5='Table Checking',COUNT (distinct A.Process_EntryNo ),0) AS TblChk ")

            .Append(" , IIF (A.Process_OT5='RT',SUM(A.GMTR),0) AS RtMtr ")
            .Append(" , IIF (A.Process_OT5 IN ('OK','YES') ,SUM(A.GMTR),0) AS Ready ")
            .Append(" , IIF (A.Process_OT5='Decision',SUM(A.GMTR),0) AS Decision ")
            .Append(" , SUM(A.GMTR) AS TotalPlanMtr ")
            .Append(" , 0.00 AS GradingDprMtr ")
            .Append(" ,0.00 AS GreyMtr ")
            .Append(" FROM  ")
            .Append(" TRNGREYDESP AS A ")
            .Append(" LEFT JOIN  trnfinishrcpt AS F ON A.grey_desp_pcs_id=F.grey_desp_pcs_id ")
            .Append(" WHERE 1=1 ")
            .Append(" AND A.Process_PcsIdSelect >'' ")
            .Append(" and f.Grey_Desp_Pcs_ID IS NULL ")
            .Append(" and A.Process_Beamlotno>'' ")
            .Append(" GROUP BY ")
            .Append(" A.Fabric_ItemCode ")
            .Append(" ,A.ProcessCode ")
            .Append(" ,a.Process_OT5 ")

#End Region


#Region "Grading Dpr Stock"
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append(" A.ITEMCODE ,A.accountcode AS PROCESSCODE  ")
            .Append(" ,0.00 AS FdMtr ")
            .Append(" ,0.00 AS PdMtr ")
            .Append(" ,0.00 AS  MixMtr ")
            .Append(" ,0.00 AS DprMtr ")
            .Append(" ,0.00 AS PBeam ")
            .Append(" ,0.00 AS PMtr ")
            .Append(" ,0.00 AS PlanBal ")
            .Append(" ,0.00 AS Req ")
            .Append(" ,0.00 AS Wash ")
            .Append(" ,0.00 AS Dyn ")
            .Append(" ,0.00 AS Stenter ")
            .Append(" ,0.00 AS Mechan ")
            .Append(" ,0.00 AS Fold ")
            .Append(" ,0.00 AS TblChk ")
            .Append(" ,0.00 AS RtMtr ")
            .Append(" ,0.00 AS Ready ")
            .Append(" ,0.00 AS Decision ")
            .Append(" ,0.00 AS TotalPlanMtr ")
            .Append(" ,A.mtr AS GradingDprMtr ")
            .Append(" ,0.00 AS GreyMtr ")
            .Append(" FROM ")
            .Append(" trnGrading AS A ")
            .Append(" LEFT JOIN TRNGREYDESP AS B ON B.Fabric_Design_no = A.BOOKVNO ")
            .Append(" WHERE 1=1 ")
            .Append(" AND B.Fabric_Design_no IS NULL ")
            .Append(" AND A.BOOKCODE IN ('0001-000000145') ")


#End Region

            .Append(" ) AS X ")
            .Append(" LEFT JOIN MstMasterAccount AS C  ON X.PROCESSCODE=C.ACCOUNTCODE ")
            .Append(" LEFT JOIN MstFabricItem AS D ON X.ITEMCODE=D.id  ")

            .Append(" GROUP BY   ")
            If Txt_ProcessStockDisplay.Text = "PROCESS WISE" Then
                .Append(" X.PROCESSCODE  ")
                .Append(" ,C.ACCOUNTNAME  ")
            ElseIf Txt_ProcessStockDisplay.Text = "ITEM WISE" Then
                .Append(" X.ITEMCODE ")
                .Append(" ,D.ITENNAME ")
            End If


        End With
        sqL = _strQuery.ToString
        sql_connect_slect()
        Dim _Tmptbl As New DataTable
        _Tmptbl = DefaltSoftTable.Copy

        If _Tmptbl.Rows.Count = 0 Then
            MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Sub
        Else

            Dim columnNames As String() = {"PMtr", "PlanBal", "PBeam", "Req", "Wash", "Dyn", "Stenter", "GreyMtr",
    "Mechan", "Fold", "TblChk", "RtMtr", "Decision", "ProcStk", "Ready", "DprMtr", "MixMtr", "GrdDprMtr"}

            Dim columnNames_SingleDecimal As String() = {"PBeam", "Req", "Wash", "Dyn", "Stenter", "Mechan", "Fold", "TblChk"}



            For Each dr As DataRow In _Tmptbl.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next
                For Each colName In columnNames_SingleDecimal
                    dr(colName) = SafeFormat(dr, colName, "0", True)
                Next

            Next



            GridView1.OptionsBehavior.Editable = False
            FirstStage.Columns.Clear()
            GridControl1.DataSource = _Tmptbl.Copy



            If Txt_ProcessStockDisplay.Text = "PROCESS WISE" Then
                FirstStage.Columns("PROCESSCODE").Visible = False
            ElseIf Txt_ProcessStockDisplay.Text = "ITEM WISE" Then
                FirstStage.Columns("ITEMCODE").Visible = False
            End If


            For Each colName In columnNames
                Dim summary As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}")
                FirstStage.Columns(colName).Summary.Clear()
                FirstStage.Columns(colName).Summary.Add(summary)
                ' --- Check total value for column ---
                Dim total As Decimal = Convert.ToDecimal(FirstStage.Columns(colName).SummaryItem.SummaryValue)
                ' Agar total = 0 hai to column hide kar do
                If total = 0D Then
                    FirstStage.Columns(colName).Visible = False
                Else
                    FirstStage.Columns(colName).Visible = True
                End If
            Next


            DevGridFitColumnWiotScroll(GridControl1, FirstStage)
            FirstStage.GroupRowHeight = 30

            Pnl_Dashbord.Visible = True

            FirstStage.Focus()
            FirstStage.FocusedRowHandle = 0
            FirstStage.FocusedColumn = FirstStage.Columns("Process")

        End If
    End Sub
    Private Sub ChangeStage_Click(sender As Object, e As EventArgs) Handles ChangeStage.Click
        'ShowFormMDI(New ProcessDyeningStageChange)
    End Sub
    Private Sub _GradingDprStockGate(ByVal _FIlterString As String, ByVal _STAGE As String, ByVal _ViewType As String, ByVal _ProcessName As String, ByVal ItemName As String, ByVal _FocusType As String, ByVal _RptViewType As String, ByVal _FilterString_Second As String)
        Try
            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" A.ITEMCODE ,A.accountcode AS PROCESSCODE  ")
                .Append(" ,a.EntryNo  ")
                .Append(" ,a.Bill_Chl_Date as ChallanDate  ")
                .Append(" ,C.ITENNAME AS Item ")
                .Append(" ,D.ACCOUNTNAME AS Process ")
                .Append(" ,a.PieceNo ")
                .Append(" ,A.Mtr as GrdDprMtr ")
                .Append(" FROM ")
                .Append(" trnGrading AS A ")
                .Append(" LEFT JOIN TRNGREYDESP AS B ON B.Fabric_Design_no = A.BOOKVNO ")
                .Append(" LEFT JOIN MSTFABRICITEM  as C ON a.ITEMCODE=C.ID ")
                .Append(" LEFT JOIN MstMasterAccount AS D ON A.ACCOUNTCODE=D.ACCOUNTCODE")
                .Append(" WHERE 1=1 ")
                .Append(_FIlterString)
                .Append(" AND B.Fabric_Design_no IS NULL ")
                .Append(" AND A.BOOKCODE IN ('0001-000000145') ")
            End With

            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim _Tmptbl = DefaltSoftTable.Copy

            If _Tmptbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else
                If NoOfstage = 1 Then
                    LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName
                ElseIf NoOfstage = 2 Then
                    LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName & " :: " & ItemName
                ElseIf NoOfstage = 3 Then
                    LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName & " :: " & ItemName
                End If


                GridView1.Columns.Clear()
                GridControl2.DataSource = _Tmptbl.Copy


                GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]

                GridView1.Columns("GrdDprMtr").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrdDprMtr", "{0}"))
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "GrdDprMtr", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("GrdDprMtr")})


                GridView1.Columns("ITEMCODE").Visible = False
                GridView1.Columns("PROCESSCODE").Visible = False


                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()

                If _FocusType = "ENTER" Then
                    GridView1.FocusedRowHandle = 0
                Else
                    If NoOfstage = 1 Then
                        GridView1.FocusedRowHandle = _StgIIRowNo
                    ElseIf NoOfstage = 2 Then
                        GridView1.FocusedRowHandle = _StgIIIRowNo
                    ElseIf NoOfstage = 3 Then
                        GridView1.FocusedRowHandle = _StgIVRowNo
                    End If
                End If



                GridView1.Focus()
                GridView1.FocusedColumn = GridView1.VisibleColumns(GridView1.VisibleColumns.Count - 1) ' Last visible column
                GridView1.MakeRowVisible(0)
                GridView1.SelectCell(0, GridView1.FocusedColumn)


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub _ProcessSecond_Req(ByVal _FIlterString As String, ByVal _STAGE As String, ByVal _ViewType As String, ByVal _ProcessName As String, ByVal ItemName As String, ByVal _FocusType As String, ByVal _RptViewType As String, ByVal _FilterString_Second As String)
        Try
            Dim laststageChak As String = ""
            Dim _Tmptbl As New DataTable

            Dim processMapStage_ByDyening As New Dictionary(Of String, String) From {
    {"Req", "IIF(A.Process_OT5='NO',0,0) AS Req"},
     {"Wash", "IIF(A.Process_OT5='Washing',sum(A.No_Of_Beam),0) AS Wash"},
    {"Dyn", "IIF(A.Process_OT5 IN ('Dyening','Re Dyening'),sum(A.No_Of_Beam),0) AS Dyn"},
    {"Stenter", "IIF(A.Process_OT5='Stenter',sum(A.No_Of_Beam),0) AS Stenter"},
    {"Mechan", "IIF(A.Process_OT5='Mechanical',sum(A.No_Of_Beam),0) AS Mechan"},
    {"Fold", "IIF(A.Process_OT5='Folding',sum(A.No_Of_Beam),0) AS Fold"},
    {"TblChk", "IIF(A.Process_OT5='Table Checking',sum(A.No_Of_Beam),0) AS TblChk"},
    {"RtMtr", "IIF(A.Process_OT5='RT',0,0 ) AS RtMtr"},
    {"Ready", "IIF(A.Process_OT5 IN ('OK','YES'),0,0) AS Ready"},
    {"Decision", "IIF(A.Process_OT5='Decision',0,0) AS Decision"}
   }

            Dim allProcessesSql As String = String.Join("," & Environment.NewLine, processMapStage_ByDyening.Values)


            Dim processMapStage As New Dictionary(Of String, String) From {
    {"Req", "IIF(A.Process_OT5='NO',COUNT(DISTINCT A.Process_EntryNo),0) AS Req"},
    {"Wash", "IIF(A.Process_OT5='Washing',COUNT(DISTINCT A.Process_EntryNo),0) AS Wash"},
    {"Dyn", "IIF(A.Process_OT5 IN ('Dyening','Re Dyening'),COUNT(DISTINCT A.Process_EntryNo),0) AS Dyn"},
    {"Stenter", "IIF(A.Process_OT5='Stenter',COUNT(DISTINCT A.Process_EntryNo),0) AS Stenter"},
    {"Mechan", "IIF(A.Process_OT5='Mechanical',COUNT(DISTINCT A.Process_EntryNo),0) AS Mechan"},
    {"Fold", "IIF(A.Process_OT5='Folding',COUNT(DISTINCT A.Process_EntryNo),0) AS Fold"},
    {"TblChk", "IIF(A.Process_OT5='Table Checking',COUNT(DISTINCT A.Process_EntryNo),0) AS TblChk"},
    {"RtMtr", "IIF(A.Process_OT5='RT',SUM(A.GMTR),0) AS RtMtr"},
    {"Ready", "IIF(A.Process_OT5 IN ('OK','YES'),SUM(A.GMTR),0) AS Ready"},
    {"Decision", "IIF(A.Process_OT5='Decision',SUM(A.GMTR),0) AS Decision"}}

            Dim allprocessMapStageSql As String = String.Join("," & Environment.NewLine, processMapStage.Values)


            Dim processMap As New Dictionary(Of String, String) From {
    {"Req", "A.Process_OT5='NO'"},
    {"Wash", "A.Process_OT5='Washing'"},
    {"Dyn", "A.Process_OT5 IN ('Dyening','Re Dyening')"},
    {"Stenter", "A.Process_OT5='Stenter'"},
    {"Mechan", "A.Process_OT5='Mechanical'"},
    {"Fold", "A.Process_OT5='Folding'"},
    {"TblChk", "A.Process_OT5='Table Checking'"},
    {"RtMtr", "A.Process_OT5='RT'"},
    {"Ready", "A.Process_OT5 IN ('OK','YES')"},
    {"Decision", "A.Process_OT5='Decision'"}}


            _strQuery = New StringBuilder
            With _strQuery

                .Append(" SELECT *  ")
                .Append(" ,'' as ShadeType ")
                .Append(" FROM ( ")

                .Append(" SELECT ")
                .Append(" A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.PROCESSCODE ")
                .Append(" ,'Dyening Plan Beam' as TypeOfBeam ")
                .Append(" ,C.ACCOUNTNAME as Process ")
                .Append(" ,D.ITENNAME as Item  ")
                If _STAGE = "SECOND" Then
                    .Append(" ,A.BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE as Shade  ")
                    .Append(" ,CAST(A.EntryNo AS varchar(50)) AS BeamNo ")
                    .Append(" ,CAST(A.EntryNo AS varchar(50)) AS OrgBeamNo ")
                    .Append(" ,A.ChallanDate ")

                    .Append(" , " & processMapStage_ByDyening(_ViewType) & " ")
                    .Append(" , A.Process_OT5 AS Status ")
                ElseIf _STAGE = "THIRD" Then
                    .Append(" ,A.BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE as Shade  ")
                    .Append(" ,CAST(A.EntryNo AS varchar(50)) AS BeamNo ")
                    .Append(" ,CAST(A.EntryNo AS varchar(50)) AS OrgBeamNo ")

                    .Append(" ,A.EntryNo ")
                    .Append(" ,A.ChallanDate ")
                    .Append(" ,A.PieceNo ")
                    .Append(" ,'' AS DyeningRemark ")
                    .Append(" ,A.No_Of_Beam as GMtr ")
                    .Append(" ,'' AS grey_desp_pcs_id ")
                    .Append(" , " & processMapStage_ByDyening(_ViewType) & " ")
                    .Append(" , A.Process_OT5 AS Status ")
                ElseIf _STAGE = "Print Process+Item+Beam Wise" Then
                    .Append(" ,A.BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE as Shade  ")
                    .Append(" ,CAST(A.EntryNo AS varchar(50)) AS BeamNo ")
                    .Append(" ,CAST(A.EntryNo AS varchar(50)) AS OrgBeamNo ")
                    .Append(" , " & allProcessesSql & " ")
                    .Append(" , A.Process_OT5 AS Status ")
                Else
                    .Append(" , " & processMapStage_ByDyening(_ViewType) & " ")
                End If
                .Append(" FROM  ")
                .Append(" TrnProcessDyeingPlan AS A ")
                .Append(" LEFT JOIN MstMasterAccount AS C  ON A.PROCESSCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstFabricItem AS D ON A.Fabric_ItemCode=D.id  ")
                .Append(" LEFT JOIN Mst_Fabric_Shade AS G ON  A.Fabric_ShadeCode=G.ID  ")
                .Append(" left join TRNGREYDESP as B ON ( A.BookVno =B.Process_Dyeing_Bookvno and A.Fabric_ItemCode=B.Fabric_ItemCode and A.Fabric_ShadeCode=B.Fabric_ShadeCode)   ")
                .Append(" WHERE 1=1  ")
                .Append(" AND a.BOOKCODE='PRDY-000000001'  ")
                .Append(" AND (B.Process_Dyeing_Bookvno IS NULL) ")
                .Append(_FilterString_Second)

                If _STAGE <> "Print Process+Item+Beam Wise" Then
                    .Append(" AND " & processMap(_ViewType) & " ")
                End If

                .Append(" GROUP BY ")
                .Append(" A.Fabric_ItemCode ")
                .Append(" ,A.ProcessCode ")
                .Append(" ,a.Process_OT5 ")
                .Append(" ,C.ACCOUNTNAME ")
                .Append(" ,D.ITENNAME  ")

                If _STAGE = "SECOND" Then

                    .Append(" ,A.BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE  ")
                    .Append(" ,a.EntryNo ")
                    .Append(" ,A.ChallanDate ")
                ElseIf _STAGE = "Print Process+Item+Beam Wise" Then
                    .Append(" ,A.BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE  ")
                    .Append(" ,a.EntryNo ")
                ElseIf _STAGE = "THIRD" Then
                    .Append(" ,A.BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE  ")
                    .Append(" ,a.EntryNo ")
                    .Append(" ,a.EntryNo ")
                    .Append(" ,a.ChallanDate ")
                    .Append(" ,a.PieceNo ")
                    .Append(" ,A.No_Of_Beam ")
                End If

                .Append(" UNION ALL ")

                .Append(" SELECT ")
                .Append(" A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" ,A.PROCESSCODE ")
                .Append(" ,'Requisition Beam' as TypeOfBeam ")
                .Append(" ,C.ACCOUNTNAME as Process ")
                .Append(" ,D.ITENNAME as Item  ")
                If _STAGE = "SECOND" Then
                    .Append(" ,'' as BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE as Shade  ")
                    .Append(" ,a.Process_Beamlotno  AS BeamNo ")
                    .Append(" ,a.Process_Beamlotno  AS OrgBeamNo ")
                    .Append(" ,A.ChallanDate ")
                    .Append(" , " & processMapStage(_ViewType) & " ")
                    .Append(" , A.Process_OT5 AS Status ")
                ElseIf _STAGE = "Print Process+Item+Beam Wise" Then
                    .Append(" ,'' as BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE as Shade  ")
                    .Append(" ,a.Process_Beamlotno  AS BeamNo ")
                    .Append(" ,a.Process_Beamlotno  AS OrgBeamNo ")
                    .Append(" , " & allprocessMapStageSql & " ")
                    .Append(" , A.Process_OT5 AS Status ")
                ElseIf _STAGE = "THIRD" Then
                    .Append(" ,'' as BookVno ")
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE as Shade  ")
                    .Append(" ,a.Process_Beamlotno  AS BeamNo ")
                    .Append(" ,a.Process_Beamlotno  AS OrgBeamNo ")
                    .Append(" ,E.EntryNo ")
                    .Append(" ,E.ChallanDate ")
                    .Append(" ,E.PieceNo ")
                    .Append(" ,ISNULL(a.Process_DetailRemark,'') AS DyeningRemark ")
                    .Append(" ,E.GMtr ")
                    .Append(" ,a.grey_desp_pcs_id ")
                    .Append(" , " & processMapStage(_ViewType) & " ")
                    .Append(" , A.Process_OT5 AS Status ")
                Else
                    .Append(" , " & processMapStage(_ViewType) & " ")
                End If
                .Append(" FROM  ")
                .Append(" TRNGREYDESP AS A ")
                .Append(" LEFT JOIN trnfinishrcpt AS F ON A.grey_desp_pcs_id=F.grey_desp_pcs_id ")
                .Append(" LEFT JOIN MstMasterAccount AS C  ON A.PROCESSCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstFabricItem AS D ON A.Fabric_ItemCode=D.id  ")
                .Append(" LEFT JOIN TrnProcessDyeingPlan AS E ON ( A.Grey_Desp_Pcs_ID=E.Grey_Desp_Pcs_ID ) ")
                .Append(" LEFT JOIN Mst_Fabric_Shade AS G ON  A.Fabric_ShadeCode=G.ID  ")
                .Append(" WHERE 1=1 ")
                .Append(_FIlterString)

                If _STAGE <> "Print Process+Item+Beam Wise" Then
                    .Append(" AND " & processMap(_ViewType) & " ")
                End If
                .Append(" AND A.Process_PcsIdSelect >'' ")
                .Append(" and f.Grey_Desp_Pcs_ID IS NULL ")
                .Append(" and A.Process_Beamlotno>'' ")
                .Append(" GROUP BY ")
                .Append(" A.Fabric_ItemCode ")
                .Append(" ,A.ProcessCode ")
                .Append(" ,a.Process_OT5 ")
                .Append(" ,C.ACCOUNTNAME ")
                .Append(" ,D.ITENNAME  ")

                If _STAGE = "SECOND" Then
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE  ")
                    .Append(" ,a.Process_Beamlotno ")
                    .Append(" ,A.ChallanDate ")
                ElseIf _STAGE = "Print Process+Item+Beam Wise" Then
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE  ")
                    .Append(" ,a.Process_Beamlotno ")
                ElseIf _STAGE = "THIRD" Then
                    .Append(" ,A.Fabric_ShadeCode ")
                    .Append(" ,G.SHADE  ")
                    .Append(" ,a.Process_Beamlotno ")
                    .Append(" ,E.EntryNo ")
                    .Append(" ,E.ChallanDate ")
                    .Append(" ,a.Process_DetailRemark ")
                    .Append(" ,E.PieceNo ")
                    .Append(" ,E.GMtr ")
                    .Append(" ,a.grey_desp_pcs_id ")
                End If

                .Append(" ) AS Z ")
                .Append(" WHERE 1=1 ")

                If _STAGE <> "Print Process+Item+Beam Wise" Then
                    .Append(" AND " & _ViewType & " > 0")
                End If

                .Append(" ORDER BY ")
                .Append(" Z.Process ")
                .Append(" ,Z.Item  ")
                If _STAGE = "SECOND" Or _STAGE = "THIRD" Then
                    .Append(" ,Z.BeamNo  ")
                End If


            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            _Tmptbl = DefaltSoftTable.Copy

            If _Tmptbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else

                For Each dr As DataRow In _Tmptbl.Rows
                    If Not String.IsNullOrEmpty(_ViewType) AndAlso dr.Table.Columns.Contains(_ViewType) Then
                        Dim val As Double
                        If Double.TryParse(dr(_ViewType).ToString(), val) Then
                            If val = 0 Then
                                dr(_ViewType) = DBNull.Value
                            Else

                                Dim colType As Type = dr.Table.Columns(_ViewType).DataType

                                If colType Is GetType(Integer) Then
                                    dr(_ViewType) = Convert.ToInt32(val)
                                ElseIf colType Is GetType(Double) OrElse colType Is GetType(Decimal) Then
                                    dr(_ViewType) = Math.Round(val, 2)
                                Else
                                    dr(_ViewType) = val.ToString("0.00")
                                End If
                            End If
                        Else
                            dr(_ViewType) = DBNull.Value
                        End If
                    End If
                Next

                If _RptViewType = "PRINT" Then
                    Dim RptTitle = "Report From : " & _ViewType.ToString
                    REPORT_RPT_FILE_NAME = "ProcessPlanStage_1"
                    Dim Date_Range = "Print Date : " & CDate(Date.Now).ToString("dd/MM/yyyy")
                    NewReportPrint(_Tmptbl, RptTitle, Date_Range)
                    Exit Sub
                ElseIf _RptViewType = "Print Process+Item+Beam Wise" Then
                    Dim RptTitle = "Report From : " & "Process+Item+Beam Wise"
                    REPORT_RPT_FILE_NAME = "ProcessPlanStage_4"
                    Dim Date_Range = "Print Date : " & CDate(Date.Now).ToString("dd/MM/yyyy")
                    NewReportPrint(_Tmptbl, RptTitle, Date_Range)

                    Exit Sub
                End If


                If NoOfstage = 1 Then
                    LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName
                ElseIf NoOfstage = 2 Then
                    LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName & " :: " & ItemName & " :: ( F1=Stage Update )"
                ElseIf NoOfstage = 3 Then
                    LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName & " :: " & ItemName & " :: ( F1=Stage Update )"
                End If


                GridView1.Columns.Clear()
                GridControl2.DataSource = _Tmptbl.Copy

                Dim statusCombo As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
                statusCombo.Items.AddRange(_ProcessStage_2)
                statusCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                GridControl1.RepositoryItems.Add(statusCombo)


                Dim view As GridView = GridView1

                ' Grid level editable hona chahiye, warna koi bhi column edit nahi hoga
                view.OptionsBehavior.Editable = True

                ' Sabhi columns ko read-only bana do
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In view.Columns
                    col.OptionsColumn.AllowEdit = False
                    col.OptionsColumn.ReadOnly = True
                Next

                ' Sirf Status column ko editable rakho (agar stage condition allow kare to)
                If _STAGE <> "FIRST" Then
                    Dim statusCol = view.Columns("Status")
                    If statusCol IsNot Nothing Then
                        statusCol.OptionsColumn.AllowEdit = True
                        statusCol.OptionsColumn.ReadOnly = False
                        statusCol.ColumnEdit = statusCombo  ' ComboBox ya RepositoryItem
                    End If
                End If




                GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]

                GridView1.Columns(_ViewType).Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, _ViewType, "{0}"))
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = _ViewType, .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns(_ViewType)})

                If _STAGE = "SECOND" Then
                    GridView1.Columns("BeamNo").OptionsColumn.AllowEdit = True
                    GridView1.Columns("BeamNo").OptionsColumn.ReadOnly = False
                ElseIf _STAGE = "THIRD" Then
                    GridView1.Columns("DyeningRemark").OptionsColumn.AllowEdit = True
                    GridView1.Columns("DyeningRemark").OptionsColumn.ReadOnly = False

                    GridView1.Columns("BeamNo").OptionsColumn.AllowEdit = True
                    GridView1.Columns("BeamNo").OptionsColumn.ReadOnly = False

                    GridView1.Columns("grey_desp_pcs_id").Visible = False
                    GridView1.Columns("GMtr").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GMtr", "{0}"))
                    GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "GMtr", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("GMtr")})
                End If

                GridView1.Columns("ITEMCODE").Visible = False
                GridView1.Columns("PROCESSCODE").Visible = False
                GridView1.Columns("ShadeType").Visible = False



                If NoOfstage = 1 Then
                    GridView1.Columns("Process").Visible = False
                ElseIf NoOfstage = 2 Or NoOfstage = 3 Then
                    GridView1.Columns("BookVno").Visible = False
                    GridView1.Columns("OrgBeamNo").Visible = False
                    GridView1.Columns("Fabric_ShadeCode").Visible = False
                    GridView1.Columns("Process").Visible = False
                    GridView1.Columns("Item").Visible = False
                End If

                GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue

                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()

                If _FocusType = "ENTER" Then
                    GridView1.FocusedRowHandle = 0
                Else
                    If NoOfstage = 1 Then
                        GridView1.FocusedRowHandle = _StgIIRowNo
                    ElseIf NoOfstage = 2 Then
                        GridView1.FocusedRowHandle = _StgIIIRowNo
                    ElseIf NoOfstage = 3 Then
                        GridView1.FocusedRowHandle = _StgIVRowNo
                    End If
                End If


                'AddHandler GridView1.RowStyle, AddressOf GridView1_RowStyle
                GridView1.Focus()
                GridView1.FocusedColumn = GridView1.VisibleColumns(GridView1.VisibleColumns.Count - 1) ' Last visible column
                GridView1.MakeRowVisible(0)
                GridView1.SelectCell(0, GridView1.FocusedColumn)


                'If _STAGE <> "FIRST" Then
                '    GridView1.FocusedColumn = GridView1.Columns(_ViewType)
                '    SendKeys.Send("{TAB}")
                'End If
                laststageChak = _ViewType
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _ProcessSecondPBeam(ByVal _FIlterString As String, ByVal _STAGE As String, ByVal _ProcessName As String, ByVal ItemName As String, ByVal FocusRow As Integer)
        Try

            If NoOfstage = 1 Then
                LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName
            ElseIf NoOfstage = 2 Then
                LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName & " :: " & ItemName
            Else
                LblSelectedOptionName.Text = SelectionDashBordName
            End If



            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT ")
                .Append(" Z.ITEMCODE ")
                .Append(" ,z.PROCESSCODE ")
                .Append(" ,'Dyening Plan Beam' as TypeOfBeam ")
                .Append(" ,C.ACCOUNTNAME as Process ")
                .Append(" ,D.ITENNAME as Item  ")

                If _STAGE = "SECOND" Then
                    .Append(" ,Z.BookVno ")
                    .Append(" ,z.Shade  ")
                    .Append(" ,Z.Fabric_ShadeCode ")
                    .Append(" ,Z.EntryNo ")
                    .Append(" ,Z.ChallanDate ")
                    .Append(" ,SUM (Z.TotalBeamPlan) AS PBeam ")
                    .Append(" , Z.Process_OT5 AS Status ")
                Else
                    .Append(" ,SUM (Z.TotalBeamPlan) AS PBeam ")
                End If

                .Append(" FROM( ")
                .Append(" SELECT ")
                .Append(" A.Fabric_ItemCode AS ITEMCODE ")
                .Append(" , IIF (A.Process_OT5 ='NO' OR  A.Process_OT5 IS NULL ,A.No_Of_Beam ,0) AS TotalBeamPlan ")
                .Append(" ,A.ProcessCode ")
                .Append(" ,A.BookVno ")
                .Append(" ,a.EntryNo ")
                .Append(" ,a.ChallanDate ")
                .Append(" ,a.Fabric_ShadeCode ")
                .Append(" ,G.SHADE  ")
                .Append(" ,A.ShadeType ")
                .Append(" ,A.Process_OT5 ")
                .Append(" FROM  ")
                .Append(" TrnProcessDyeingPlan AS A ")
                .Append(" left join TRNGREYDESP as B ON ( A.BookVno =B.Process_Dyeing_Bookvno and A.Fabric_ItemCode=B.Fabric_ItemCode and A.Fabric_ShadeCode=B.Fabric_ShadeCode)   ")
                .Append(" LEFT JOIN Mst_Fabric_Shade AS G ON  A.Fabric_ShadeCode=G.ID  ")
                .Append(" WHERE 1=1  ")
                .Append(" AND (B.Process_Dyeing_Bookvno IS NULL) ")
                .Append(_FIlterString)
                .Append(" AND a.BOOKCODE='PRDY-000000001' ")
                .Append(" )AS Z ")
                .Append(" LEFT JOIN MstMasterAccount AS C  ON Z.PROCESSCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstFabricItem AS D ON Z.ITEMCODE=D.id  ")
                .Append(" GROUP BY ")
                .Append(" Z.ITEMCODE ")
                .Append(" ,z.ProcessCode ")
                .Append(" ,C.ACCOUNTNAME ")
                .Append(" ,D.ITENNAME ")
                If _STAGE = "SECOND" Then
                    .Append(" ,Z.EntryNo ")
                    .Append(" ,Z.shade ")
                    .Append(" ,Z.Fabric_ShadeCode ")
                    .Append(" ,Z.BookVno ")
                    .Append(" ,Z.ChallanDate ")
                    .Append(" ,Z.Process_OT5 ")
                End If
                .Append(" HAVING SUM (Z.TotalBeamPlan)>0 ")
            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim _Tmptbl As New DataTable
            _Tmptbl = DefaltSoftTable.Copy

            If _Tmptbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else
                For Each dr As DataRow In _Tmptbl.Select
                    dr("PBeam") = Convert.ToDouble(dr("PBeam")).ToString("0")

                    If Val(dr("PBeam")) = 0 Then dr("PBeam") = DBNull.Value

                Next
                GridView1.Columns.Clear()
                GridControl2.DataSource = _Tmptbl.Copy



                If _STAGE = "SECOND" Then
                    Dim statusCombo As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
                    statusCombo.Items.AddRange(_ProcessStage_3)
                    statusCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
                    GridControl1.RepositoryItems.Add(statusCombo)
                    Dim view As GridView = GridView1
                    view.OptionsBehavior.Editable = True
                    For Each col In view.Columns
                        col.OptionsColumn.AllowEdit = False
                        col.OptionsColumn.ReadOnly = True
                    Next
                    With view.Columns("Status")
                        .OptionsColumn.AllowEdit = True
                        .OptionsColumn.ReadOnly = False
                        .ColumnEdit = statusCombo
                    End With
                    GridView1.Columns("BookVno").Visible = False
                    GridView1.Columns("Fabric_ShadeCode").Visible = False
                End If



                GridView1.Columns("PBeam").Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PBeam", "{0}"))

                GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
                GridView1.GroupSummary.Add(New DevExpress.XtraGrid.GridGroupSummaryItem() With {.FieldName = "PBeam", .SummaryType = DevExpress.Data.SummaryItemType.Sum, .ShowInGroupColumnFooter = GridView1.Columns("PBeam")})

                GridView1.Columns("ITEMCODE").Visible = False
                GridView1.Columns("PROCESSCODE").Visible = False

                If NoOfstage = 1 Then
                    GridView1.Columns("Process").Visible = False
                ElseIf NoOfstage = 2 Then
                    GridView1.Columns("Process").Visible = False
                    GridView1.Columns("Item").Visible = True
                End If

                GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue

                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridControl2.Visible = True
                GridControl2.BringToFront()


                If _STAGE = "SECOND" Then
                    GridView1.Focus()
                    GridView1.FocusedColumn = GridView1.VisibleColumns(GridView1.VisibleColumns.Count - 1) ' Last visible column
                    GridView1.MakeRowVisible(0)
                    GridView1.SelectCell(0, GridView1.FocusedColumn)
                Else
                    GridView1.Focus()
                    GridView1.FocusedRowHandle = FocusRow
                    'GridView1.FocusedRowHandle = GridView1.VisibleColumns.Count - 1
                    Dim lastColumnIndex As Integer = GridView1.VisibleColumns.Count - 1

                    If lastColumnIndex >= 0 Then
                        GridView1.FocusedColumn = GridView1.VisibleColumns(lastColumnIndex)
                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub _ProcessSecondStageDisplay(ByVal _FIlterString As String, ByVal _STAGE As String, ByVal _ProcessName As String, ByVal ItemName As String, ByVal focColum As DevExpress.XtraGrid.Columns.GridColumn, ByVal _frow As Integer, ByVal EntryViewType As String, ByVal ProcessCode As String)


        Try
            If NoOfstage = 1 Then
                LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName
            ElseIf NoOfstage = 2 Then
                LblSelectedOptionName.Text = SelectionDashBordName & " :: " & _ProcessName & " :: " & ItemName
            Else
                LblSelectedOptionName.Text = SelectionDashBordName
            End If

            _strQuery = New StringBuilder
            With _strQuery
                .Append(" SELECT  ")
                .Append(" X.PROCESSCODE  ")
                .Append(" ,C.ACCOUNTNAME as Process ")

                If EntryViewType <> "Print Process Wise" Then
                    .Append(" ,X.ITEMCODE ")
                    .Append(" ,D.ITENNAME as Item  ")
                End If
                If EntryViewType = "Print Process+Item+Beam Wise" Then
                    .Append(" ,X.BeamNo ")
                End If

                If _STAGE = "SECOND" Then
                    .Append(" ,X.BeamNo ")
                    .Append(" ,X.PieceNo ")
                End If
                .Append(" ,SUM(X.FdMtr) AS  FdMtr")
                .Append(" ,SUM(X.PdMtr) AS  PdMtr")
                .Append(" ,SUM(X.MixMtr) AS  MixMtr")
                .Append(" ,SUM(X.DprMtr) AS  DprMtr")
                .Append(" ,SUM(X.GradingDprMtr) AS  GrdDprMtr")
                .Append(" ,SUM(X.GreyMtr) AS  GreyMtr")
                .Append(" ,CEILING(SUM(X.PBeam) * " & AvgWtPerMtr & " / 25.0) * 25 AS PMtr ")
                .Append(" ,CEILING((SUM(X.FdMtr)+SUM(X.PdMtr) - ((SUM(X.PBeam) * " & AvgWtPerMtr & ")+SUM(X.TotalPlanMtr))) / 25.0) * 25 AS PlanBal ")
                .Append(" ,SUM(X.PBeam) AS PBeam  ")
                .Append(" ,SUM(X.Req) AS Req ")
                .Append(" ,SUM(X.Wash) AS Wash ")
                .Append(" ,SUM(X.Dyn) AS  Dyn")
                .Append(" ,SUM(X.Stenter) AS Stenter ")
                .Append(" ,SUM(X.Mechan) AS Mechan ")
                .Append(" ,SUM(X.Fold) AS Fold ")
                .Append(" ,SUM(X.TblChk) AS TblChk ")
                .Append(" ,SUM(X.RtMtr) AS RtMtr ")
                .Append(" ,SUM(X.Ready) AS Ready ")
                .Append(" ,SUM(X.Decision) AS Decision ")
                .Append(" FROM ( ")

#Region "Process Stock"
                .Append(" SELECT ")
                .Append(" Z.FABRIC_ITEMCODE as ITEMCODE ,Z.PROCESSCODE  ")
                .Append(" ,SUM(Z.GFDMtr)-SUM(Z.FFDMtr) AS FdMtr ")
                .Append(" ,SUM(Z.GPDMtr)-SUM(Z.FPDMtr) AS PdMtr ")
                .Append(" ,SUM(Z.GMixMtr)-SUM(Z.FMixMtr) AS MixMtr ")
                .Append(" ,0.00 AS DprMtr ")
                .Append(" ,0.00 AS PBeam ")
                .Append(" ,0.00 AS PMtr ")
                .Append(" ,0.00 AS PlanBal ")
                .Append(" ,0.00 AS Req ")
                .Append(" ,0.00 AS Wash ")
                .Append(" ,0.00 AS Dyn ")
                .Append(" ,0.00 AS Stenter ")
                .Append(" ,0.00 AS Mechan ")
                .Append(" ,0.00 AS Fold ")
                .Append(" ,0.00 AS TblChk ")
                .Append(" ,0.00 AS RtMtr ")
                .Append(" ,0.00 AS Ready ")
                .Append(" ,0.00 AS Decision ")
                .Append(" ,0.00 AS TotalPlanMtr ")
                .Append(" ,Z.BeamNo ")
                .Append(" ,Z.PieceNo ")
                .Append(" ,0.00 as GradingDprMtr ")
                .Append(" ,0.00 as GreyMtr ")
                .Append(" FROM ( ")
                .Append(" SELECT    ")
                .Append(" A.FABRIC_ITEMCODE,A.PROCESSCODE  ")
                .Append(" ,IIF (A.FD_PD='FD',(A.GMTR),0) AS GFDMtr ")
                .Append(" ,IIF (A.FD_PD='PD',(A.GMTR),0) AS GPDMtr ")
                .Append(" ,0.00 AS FFDMtr ")
                .Append(" ,0.00 AS FPDMtr ")
                .Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),(A.GMTR),0) AS  GMixMtr ")
                .Append(" ,0.00 AS FMixMtr ")
                .Append(" ,a.PcAvgWt ")
                .Append(" ,a.BeamNo ")
                .Append(" ,a.PieceNo ")
                .Append(" FROM TRNGREYDESP AS A  ")
                .Append(" WHERE 1=1  ")
                .Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
                .Append(_FIlterString)
                .Append(" AND A.IDP='YES' ")
                .Append(" UNION ALL ")
                .Append(" SELECT    ")
                .Append(" A.FABRIC_ITEMCODE,A.PROCESSCODE  ")
                .Append(" ,0.00 AS GFDMtr ")
                .Append(" ,0.00 AS GPDMtr ")
                .Append(" ,IIF (A.FD_PD='FD',ISNULL(B.GMTR,0),0) AS FFDMtr ")
                .Append(" ,IIF (A.FD_PD='PD',ISNULL(B.GMTR,0),0) AS FPDMtr ")
                .Append(" ,0.00 AS  GMixMtr ")
                .Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),ISNULL(B.GMTR,0),0) AS FMixMtr ")
                .Append(" ,a.PcAvgWt ")
                .Append(" ,a.BeamNo ")
                .Append(" ,a.PieceNo ")
                .Append(" FROM TRNGREYDESP AS A  ")
                .Append(" LEFT JOIN TRNFINISHRCPT AS B ON A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
                .Append(" WHERE 1=1  ")
                .Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
                .Append(_FIlterString)
                .Append(" ) AS Z ")
                .Append(" GROUP BY ")
                .Append(" Z.FABRIC_ITEMCODE,Z.PROCESSCODE ")
                .Append(" ,Z.BeamNo ")
                .Append(" ,Z.PieceNo ")
                .Append(" HAVING (SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.GMixMtr)+SUM(Z.FMixMtr))-(SUM(Z.FFDMtr)+SUM(Z.FPDMtr))>0 ")
#End Region

#Region "Process DPR Stock"
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" Z.FABRIC_ITEMCODE as ITEMCODE ,Z.PROCESSCODE  ")
                .Append(" ,0.00 AS FdMtr ")
                .Append(" ,0.00 AS PdMtr ")
                .Append(" ,0.00 AS MixMtr ")
                .Append(" ,SUM(Z.GDprMtr)-SUM(Z.FDprMtr) AS DprMtr ")
                .Append(" ,0.00 AS PBeam ")
                .Append(" ,0.00 AS PMtr ")
                .Append(" ,0.00 AS PlanBal ")
                .Append(" ,0.00 AS Req ")
                .Append(" ,0.00 AS Wash ")
                .Append(" ,0.00 AS Dyn ")
                .Append(" ,0.00 AS Stenter ")
                .Append(" ,0.00 AS Mechan ")
                .Append(" ,0.00 AS Fold ")
                .Append(" ,0.00 AS TblChk ")
                .Append(" ,0.00 AS RtMtr ")
                .Append(" ,0.00 AS Ready ")
                .Append(" ,0.00 AS Decision ")
                .Append(" ,0.00 AS TotalPlanMtr ")
                .Append(" ,Z.BeamNo ")
                .Append(" ,Z.PieceNo ")
                .Append(" ,0.00 as GradingDprMtr ")
                .Append(" ,0.00 as GreyMtr ")
                .Append(" FROM ( ")
                .Append(" SELECT    ")
                .Append(" A.FABRIC_ITEMCODE,A.PROCESSCODE  ")
                .Append(" ,A.GMTR AS  GDprMtr ")
                .Append(" ,0.00 AS FDprMtr ")
                .Append(" ,a.PcAvgWt ")
                .Append(" ,a.BeamNo ")
                .Append(" ,a.PieceNo ")
                .Append(" FROM TRNGREYDESP AS A  ")
                .Append(" WHERE 1=1  ")
                .Append(_FIlterString)
                .Append(" AND A.IDP='YES' ")
                .Append(" AND A.BOOKCODE IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
                .Append(" UNION ALL ")
                .Append(" SELECT    ")
                .Append(" A.FABRIC_ITEMCODE,A.PROCESSCODE  ")
                .Append(" ,0.00 AS  GDprMtr ")
                .Append(" ,B.GMTR AS FDprMtr ")
                .Append(" ,a.PcAvgWt ")
                .Append(" ,a.BeamNo ")
                .Append(" ,a.PieceNo ")
                .Append(" FROM TRNGREYDESP AS A  ")
                .Append(" LEFT JOIN TRNFINISHRCPT AS B ON A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
                .Append(" WHERE 1=1  ")
                .Append(" AND A.BOOKCODE IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
                .Append(_FIlterString)
                .Append(" ) AS Z ")
                .Append(" GROUP BY ")
                .Append(" Z.FABRIC_ITEMCODE,Z.PROCESSCODE ")
                .Append(" ,Z.BeamNo ")
                .Append(" ,Z.PieceNo ")
                .Append(" HAVING (SUM(Z.GDprMtr))-(SUM(Z.FDprMtr))>0 ")
#End Region
#Region "Process Stock After Req"
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.FABRIC_ITEMCODE as ITEMCODE ,A.PROCESSCODE  ")
                .Append(" ,0.00 AS FdMtr ")
                .Append(" ,0.00 AS PdMtr ")
                .Append(" ,0.00 AS  MixMtr ")
                .Append(" ,0.00 AS DprMtr ")
                .Append(" ,0.00 AS PBeam ")
                .Append(" ,0.00 AS PMtr ")
                .Append(" ,0.00 AS PlanBal ")
                .Append(" ,0.00 AS Req ")
                .Append(" ,0.00 AS Wash ")
                .Append(" ,0.00 AS Dyn ")
                .Append(" ,0.00 AS Stenter ")
                .Append(" ,0.00 AS Mechan ")
                .Append(" ,0.00 AS Fold ")
                .Append(" ,0.00 AS TblChk ")
                .Append(" ,0.00 AS RtMtr ")
                .Append(" ,0.00 AS Ready ")
                .Append(" ,0.00 AS Decision ")
                .Append(" ,0.00 AS TotalPlanMtr ")
                .Append(" ,a.BeamNo ")
                .Append(" ,a.PieceNo ")
                .Append(" ,0.00 AS GradingDprMtr ")
                .Append(" ,A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0),3) AS GreyMtr ")
                .Append(" FROM ")
                .Append(" TRNGREYDESP AS A ")
                .Append(" LEFT JOIN TRNFINISHRCPT AS B ON  A.GREY_DESP_PCS_ID = B.GREY_DESP_PCS_ID ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
                .Append(_FIlterString)
                .Append(" AND A.IDP='YES' ")
                .Append(" AND (A.Process_PcsIdSelect IS NULL  OR A.Process_PcsIdSelect='')  ")
                .Append(" group by ")
                .Append(" a.fabric_ItemCode ")
                .Append(" ,a.Fabric_ShadeCode ")
                .Append(" ,A.BeamNo ")
                .Append(" ,A.PieceNo ")
                .Append(" ,A.Weight ")
                .Append(" ,A.PcAvgWt ")
                .Append(" ,A.Pick ")
                .Append(" ,A.FD_PD ")
                .Append(" ,A.EntryNo ")
                .Append(" ,A.GMTR ")
                .Append(" ,A.ChallanDate ")
                .Append(" ,A.BookVno ")
                .Append(" ,A.BookCode ")
                .Append(" ,A.ProcessCode ")
                .Append(" ,A.AccountCode ")
                .Append(" ,A.FactoryCode ")
                .Append(" ,A.Process_ShadeType ")
                .Append(" having (A.GMTR)-ISNULL(sum(B.GMTR),0)>0 ")
#End Region
                If NoOfstage = 1 Then

#Region "Plan Beam"
                    .Append(" UNION ALL ")
                    .Append(" SELECT ")
                    .Append(" Z.ITEMCODE ")
                    .Append(" ,Z.ProcessCode ")
                    .Append(" ,0.00 AS FdMtr ")
                    .Append(" ,0.00 AS PdMtr ")
                    .Append(" ,0.00 AS MixMtr ")
                    .Append(" ,0.00 AS DprMtr ")
                    .Append(" ,SUM(Z.TotalBeamPlan) AS PBeam  ")
                    .Append(" ,0.00 AS PMtr ")
                    .Append(" ,0.00 AS PlanBal  ")
                    .Append(" ,0.00 AS Req  ")
                    .Append(" ,SUM(Z.Wash) AS Wash ")
                    .Append(" ,SUM(Z.Dyn) AS Dyn ")
                    .Append(" ,SUM(Z.Stenter) AS Stenter ")
                    .Append(" ,SUM(Z.Mechan) AS Mechan ")
                    .Append(" ,SUM(Z.Fold) AS Fold ")
                    .Append(" ,SUM(Z.TblChk) AS TblChk ")
                    .Append(" ,0.00 AS RtMtr  ")
                    .Append(" ,0.00 AS Ready  ")
                    .Append(" ,0.00 AS Decision  ")
                    .Append(" ,0.00 AS TotalPlanMtr  ")
                    .Append(" ,'' AS BeamNo ")
                    .Append(" ,'' AS PieceNo ")
                    .Append(" ,0.00 as GradingDprMtr ")
                    .Append(" ,0.00 as GreyMtr ")
                    .Append(" FROM ( ")
                    .Append(" SELECT  ")
                    .Append(" A.Fabric_ItemCode AS ITEMCODE  ")
                    .Append(" ,A.ProcessCode  ")
                    .Append(" ,B.Process_Dyeing_Bookvno AS  BookVno ")
                    .Append(" , IIF (A.Process_OT5 ='NO' OR  A.Process_OT5 IS NULL ,A.No_Of_Beam ,0) AS TotalBeamPlan ")
                    .Append(" , IIF (A.Process_OT5='Washing',A.No_Of_Beam,0) AS Wash ")
                    .Append(" , IIF (A.Process_OT5 IN ('Dyening','Re Dyening'),A.No_Of_Beam,0) AS Dyn ")
                    .Append(" , IIF (A.Process_OT5='Stenter',A.No_Of_Beam,0) AS Stenter ")
                    .Append(" , IIF (A.Process_OT5='Mechanical',A.No_Of_Beam,0) AS Mechan ")
                    .Append(" , IIF (A.Process_OT5='Folding',A.No_Of_Beam,0) AS Fold ")
                    .Append(" , IIF (A.Process_OT5='Table Checking',A.No_Of_Beam,0) AS TblChk ")
                    .Append(" FROM  TrnProcessDyeingPlan AS A  ")
                    .Append(" left join TRNGREYDESP as B ON ( A.BookVno =B.Process_Dyeing_Bookvno and A.Fabric_ItemCode=B.Fabric_ItemCode and A.Fabric_ShadeCode=B.Fabric_ShadeCode)   ")
                    .Append(" WHERE 1=1  ")
                    .Append(_FIlterString)
                    .Append(" AND a.BOOKCODE='PRDY-000000001'  ")
                    .Append(" AND (B.Process_Dyeing_Bookvno IS NULL) ")
                    .Append(" ) AS Z ")
                    .Append(" GROUP BY ")
                    .Append(" Z.ITEMCODE ")
                    .Append(" ,Z.ProcessCode ")
#End Region

#Region "Pending PBeam"
                    .Append(" UNION ALL ")

                    .Append(" SELECT ")
                    .Append(" A.Fabric_ItemCode AS ITEMCODE ")
                    .Append(" ,A.ProcessCode ")
                    .Append(" ,0.00 AS FdMtr ")
                    .Append(" ,0.00 AS PdMtr ")
                    .Append(" ,0.00 AS MixMtr ")
                    .Append(" ,0.00 AS DprMtr ")
                    .Append(" ,0.00 AS PBeam ")
                    .Append(" ,0.00 AS PMtr ")
                    .Append(" ,0.00 AS PlanBal ")
                    .Append(" , IIF (A.Process_OT5='NO',COUNT (distinct A.Process_EntryNo ),0) AS Req ")
                    .Append(" , IIF (A.Process_OT5='Washing',COUNT (distinct A.Process_EntryNo ),0) AS Wash ")
                    .Append(" , IIF (A.Process_OT5 IN ('Dyening','Re Dyening'),COUNT (distinct A.Process_EntryNo ),0) AS Dyn ")
                    .Append(" , IIF (A.Process_OT5='Stenter',COUNT (distinct A.Process_EntryNo ),0) AS Stenter ")
                    .Append(" , IIF (A.Process_OT5='Mechanical',COUNT (distinct A.Process_EntryNo ),0) AS Mechan ")
                    .Append(" , IIF (A.Process_OT5='Folding',COUNT (distinct A.Process_EntryNo ),0) AS Fold ")
                    .Append(" , IIF (A.Process_OT5='Table Checking',COUNT (distinct A.Process_EntryNo ),0) AS TblChk ")
                    .Append(" , IIF (A.Process_OT5='RT',SUM(A.GMTR),0) AS RtMtr ")
                    .Append(" , IIF (A.Process_OT5 IN ('OK','YES') ,SUM(A.GMTR),0) AS Ready ")
                    .Append(" , IIF (A.Process_OT5='Decision',SUM(A.GMTR),0) AS Decision ")
                    .Append(" , SUM(A.GMTR) AS TotalPlanMtr ")
                    '.Append(" ,A.BeamNo ")
                    '.Append(" ,A.PieceNo ")
                    .Append(" ,'' AS BeamNo ")
                    .Append(" ,'' AS PieceNo ")
                    .Append(" ,0.00 as GradingDprMtr ")
                    .Append(" ,0.00 as GreyMtr ")
                    .Append(" FROM  ")
                    .Append(" TRNGREYDESP AS A ")
                    .Append(" LEFT JOIN  trnfinishrcpt AS F ON A.grey_desp_pcs_id=F.grey_desp_pcs_id ")
                    .Append(" WHERE 1=1 ")
                    .Append(_FIlterString)
                    .Append(" AND A.Process_PcsIdSelect >'' ")
                    .Append(" and f.Grey_Desp_Pcs_ID IS NULL ")
                    .Append(" and A.Process_Beamlotno>'' ")
                    .Append(" GROUP BY ")
                    .Append(" A.Fabric_ItemCode ")
                    .Append(" ,A.ProcessCode ")
                    .Append(" ,a.Process_OT5 ")
                    '.Append(" ,A.BeamNo ")
                    '.Append(" ,A.PieceNo ")
#End Region

                End If

#Region "Grading Dpr Stock"
                .Append(" UNION ALL ")
                .Append(" SELECT ")
                .Append(" A.ITEMCODE ,A.accountcode AS PROCESSCODE  ")
                .Append(" ,0.00 AS FdMtr ")
                .Append(" ,0.00 AS PdMtr ")
                .Append(" ,0.00 AS MixMtr ")
                .Append(" ,0.00 AS DprMtr ")
                .Append(" ,0.00 AS PBeam ")
                .Append(" ,0.00 AS PMtr ")
                .Append(" ,0.00 AS PlanBal ")
                .Append(" ,0.00 AS Req ")
                .Append(" ,0.00 AS Wash ")
                .Append(" ,0.00 AS Dyn ")
                .Append(" ,0.00 AS Stenter ")
                .Append(" ,0.00 AS Mechan ")
                .Append(" ,0.00 AS Fold ")
                .Append(" ,0.00 AS TblChk ")
                .Append(" ,0.00 AS RtMtr ")
                .Append(" ,0.00 AS Ready ")
                .Append(" ,0.00 AS Decision ")
                .Append(" ,0.00 AS TotalPlanMtr ")
                .Append(" ,a.EntryNo as BeamNo ")
                .Append(" ,a.PieceNo ")
                .Append(" ,A.mtr AS GradingDprMtr ")
                .Append(" ,0.00 AS GreyMtr ")
                .Append(" FROM ")
                .Append(" trnGrading AS A ")
                .Append(" LEFT JOIN TRNGREYDESP AS B ON B.Fabric_Design_no = A.BOOKVNO ")
                .Append(" WHERE 1=1 ")
                .Append(" AND A.accountcode='" & ProcessCode & "'")
                .Append(" AND B.Fabric_Design_no IS NULL ")
                .Append(" AND A.BOOKCODE IN ('0001-000000145') ")


#End Region
                .Append(" ) AS X ")
                .Append(" LEFT JOIN MstMasterAccount AS C  ON X.PROCESSCODE=C.ACCOUNTCODE ")
                .Append(" LEFT JOIN MstFabricItem AS D ON X.ITEMCODE=D.id  ")

                .Append(" GROUP BY   ")
                .Append(" X.PROCESSCODE  ")
                .Append(" ,C.ACCOUNTNAME  ")

                If EntryViewType <> "Print Process Wise" Then
                    .Append(" ,X.ITEMCODE ")
                    .Append(" ,D.ITENNAME  ")
                End If
                If EntryViewType = "Print Process+Item+Beam Wise" Then
                    .Append(" ,X.BeamNo ")
                End If

                If _STAGE = "SECOND" Then
                    .Append(" ,X.BeamNo ")
                    .Append(" ,X.PieceNo ")
                End If

            End With
            sqL = _strQuery.ToString
            sql_connect_slect()
            Dim _Tmptbl As New DataTable
            _Tmptbl = DefaltSoftTable.Copy

            If _Tmptbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else


                If EntryViewType = "Print Process Wise" Or EntryViewType = "Print Process+Item Wise" Or EntryViewType = "Print Process+Item+Beam Wise" Then
                    Dim RptTitle = "Process Wise Report : "

                    If EntryViewType = "Print Process Wise" Then
                        REPORT_RPT_FILE_NAME = "ProcessPlanStage_2"
                    ElseIf EntryViewType = "Print Process+Item Wise" Then
                        REPORT_RPT_FILE_NAME = "ProcessPlanStage_3"
                    ElseIf EntryViewType = "Print Process+Item+Beam Wise" Then
                        REPORT_RPT_FILE_NAME = "ProcessPlanStage_4"

                    End If

                    Dim Date_Range = "Print Date : " & CDate(Date.Now).ToString("dd/MM/yyyy")
                    NewReportPrint(_Tmptbl, RptTitle, Date_Range)
                    Exit Sub
                End If




                Dim columnNames As String() = {
"FdMtr", "PdMtr", "PMtr", "GreyMtr", "PlanBal", "PBeam", "Req", "Wash", "Dyn", "Stenter",
"Mechan", "Fold", "TblChk", "RtMtr", "Decision", "Ready", "DprMtr", "MixMtr", "GrdDprMtr"}

                Dim columnNames_SingleDecimal As String() = {
 "PBeam", "Req", "Wash", "Dyn", "Stenter",
"Mechan", "Fold", "TblChk"}


                For Each dr As DataRow In _Tmptbl.Rows
                    For Each colName In columnNames
                        dr(colName) = SafeFormat(dr, colName, "0", True)
                    Next
                    For Each colName In columnNames_SingleDecimal
                        dr(colName) = SafeFormat(dr, colName, "0", True)
                    Next

                Next




                GridView1.Columns.Clear()
                GridControl2.DataSource = _Tmptbl.Copy

                DevGridSummeryAndHideColm(GridView1, columnNames)

                GridView1.OptionsBehavior.Editable = False

                GridView1.Columns("ITEMCODE").Visible = False
                GridView1.Columns("PROCESSCODE").Visible = False

                If NoOfstage = 1 Then
                    GridView1.Columns("Process").Visible = False
                    GridView1.Columns("PlanBal").Visible = False
                    'GridView1.Columns("PBeam").Visible = False
                    GridView1.Columns("PMtr").Visible = False
                ElseIf NoOfstage = 2 Then
                    GridView1.Columns("Process").Visible = False
                    GridView1.Columns("Item").Visible = False
                    GridView1.Columns("PBeam").Visible = False
                    GridView1.Columns("PlanBal").Visible = False
                    GridView1.Columns("PMtr").Visible = False
                End If


                GridView1.Appearance.FocusedRow.BackColor = GridView1.Appearance.FocusedRow.BackColor.LightBlue

                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()

                GridView1.FocusedRowHandle = _frow
                GridView1.FocusedColumn = focColum

                GridView1.FocusedColumn = GridView1.VisibleColumns(GridView1.VisibleColumns.Count - 1) ' Last visible column
                GridView1.MakeRowVisible(0)
                GridView1.SelectCell(0, GridView1.FocusedColumn)

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region

#Region "Sales DashBoard"


    Private Sub GradingDashBord_Click(sender As Object, e As EventArgs) Handles SalesDashBord.Click
        LblSelectedOptionName.Text = "Sales Planning DashBoard"
        SelectionDashBordName = "Sales Planning DashBoard"
        SelectionOfView = "Sales Planning DashBoard"
        Txt_ProcessStockDisplay.SpacerString = "ITEM WISE,PARTY WISE"
        SelectionButton = ""
        GridControl2.Visible = False
        Pnl_OutstandingView.Visible = False
        GridView1.OptionsBehavior.Editable = False
        PnlColoView.Visible = False
        _ProcessStkLblDiplay(False)

        Lbl_ProcessStk.Visible = True
        Txt_ProcessStockDisplay.Visible = True

        SalesAllCompanyPlanningDashBoard()

    End Sub

    Private Function SalesAllCompanyPlanningDashBoard()
        Dim AllCompCompTbl As DataTable
        Dim _TmpDataTable As DataTable

        AllCompCompTbl = Outstanding_Zooming_AllCompany._GetCurrentYearCompanyTable()


        For Each dr As DataRow In AllCompCompTbl.Select
            Dim DataBaseName = dr("Data_Folder_Name").ToString
            Dim Comp_Print_Name = dr("Comp_Print_Name").ToString

            ' Step 1: Connect to master to check if database exists
            Dim checkConnStr = Main_MDI_Frm.TextBox1.Text
            Using checkConn As New SqlConnection(checkConnStr)
                Try
                    checkConn.Open()
                    Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = @DBName", checkConn)
                    checkCmd.Parameters.AddWithValue("@DBName", DataBaseName)
                    Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If exists = 0 Then
                        ' Database not found, skip to next
                        Continue For
                    End If
                Catch ex As Exception
                    ' Connection to master failed, skip this row
                    Continue For
                End Try
            End Using

            Dim _FilterItemPartyWise As String = Txt_ProcessStockDisplay.Text

            Dim _YearConn = _GetServerConnection(DataBaseName)
            NewYearConnection = New SqlConnection(_YearConn)
            Dim _BackYrTbl As New DataTable
            sqL = _salesQuery(Comp_Print_Name, DataBaseName, _FilterItemPartyWise, "FIRST")
            sql_Data_Select_NewYearConnection()
            _BackYrTbl = DefaltSoftTable.Copy

            If _TmpDataTable Is Nothing Then
                _TmpDataTable = _BackYrTbl.Clone()
            End If

            If _BackYrTbl.Rows.Count > 0 Then
                For Each dr1 As DataRow In _BackYrTbl.Select
                    _TmpDataTable.ImportRow(dr1)
                Next
            End If
        Next

        FirstStage.Columns.Clear()
        If _TmpDataTable.Rows.Count = 0 Then
            MsgBox("Record Not Found", MsgBoxStyle.Information, "Soft-Tex PRO")
            Exit Function

        Else
            Dim columnNames As String() = {"OldSales", "BeamPlan", "Planning", "FactStock", "ProcsDyn", "GreyMtr", "ProcReady", "GradingStk", "TotStk"}

            'Dim columnNames_SingleDecimal As String() = {"PlBM", "WpBM", "DrBM", "PinBM", "OnLmBM", "SinFloor", "DoubFloor", "SinFall", "DoubFall"}


            For Each dr As DataRow In _TmpDataTable.Rows
                For Each colName In columnNames
                    dr(colName) = SafeFormat(dr, colName, "0.00", True)
                Next
                'For Each colName In columnNames_SingleDecimal
                '    dr(colName) = SafeFormat(dr, colName, "0", True)
                'Next
            Next


            FirstStage.Columns.Clear()
            GridControl1.DataSource = _TmpDataTable.Copy




            For Each colName In columnNames
                FirstStage.Columns(colName).Summary.Add(New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}"))
            Next

            FirstStage.Columns("DataBaseName").Visible = False
            If Txt_ProcessStockDisplay.Text = "PARTY WISE" Then
                FirstStage.Columns("ACCOUNTCODE").Visible = False
            Else
                FirstStage.Columns("ITEMCODE").Visible = False
            End If


            Pnl_Dashbord.Visible = True
            DevGridFitColumnWiotScroll(GridControl1, FirstStage)
            FirstStage.Focus()
        End If

    End Function

#Region "Sales Dashbord ShortQuery"

    Private Sub _SalesSecondstageGridSetting(ByVal _sqlquery As String, ByVal ColName As String)
        Try
            sqL = _sqlquery.ToString
            sql_connect_slect()
            Dim _Tmptbl As New DataTable
            _Tmptbl = DefaltSoftTable.Copy

            If _Tmptbl.Rows.Count = 0 Then
                MsgBox("No Record Found !", MsgBoxStyle.Information, "Soft-Tex PRO")
                Exit Sub
            Else
                Dim columnNames As String() = {ColName}


                For Each dr As DataRow In _Tmptbl.Rows
                    For Each ColName In columnNames
                        dr(ColName) = SafeFormat(dr, ColName, "0.00", True)
                    Next
                Next


                GridView1.Columns.Clear()
                GridControl2.DataSource = _Tmptbl.Copy

                DevGridSummeryAndHideColm(GridView1, columnNames)

                GridView1.OptionsBehavior.Editable = False


                GridView1.Columns("ACCOUNTCODE").Visible = False
                GridView1.Columns("ITEMCODE").Visible = False
                GridView1.Columns("DESIGNCODE").Visible = False
                GridView1.Columns("SHADECODE").Visible = False


                DevGridFitColumnWiotScroll(GridControl2, GridView1)
                GridControl2.Visible = True
                GridControl2.BringToFront()
                GridView1.Focus()


                GridView1.FocusedColumn = GridView1.VisibleColumns(GridView1.VisibleColumns.Count - 1) ' Last visible column
                GridView1.MakeRowVisible(0)
                GridView1.SelectCell(0, GridView1.FocusedColumn)

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function _QueySalesBeamPlan(ByVal _Stage As String, ByVal Filterstring As String)
        _strQuery = New StringBuilder
        With _strQuery

            .Append(" SELECT ")

            If _Stage = "FIRST" Then
                .Append(" Z.ACCOUNTCODE")
                .Append(" ,Z.ITEMCODE")
                .Append(" ,Z.DESIGNCODE")
                .Append(" ,Z.SHADECODE")
                .Append(" ,0.00 as OldSales")
                .Append(" ,SUM(Z.PlanningQty)-SUM(Z.OwnBeamPlanQty) as Planning")
                .Append(" ,SUM(Z.OwnBeamPlanQty) as BeamPlan")
                .Append(" ,0.00 as FactStock")
                .Append(" ,0.00 AS ProcsDyn ")
                .Append(" ,0.00 AS GreyMtr ")
                .Append(" ,0.00 AS ProcReady ")
                .Append(" ,0.00 AS GradingStk ")
            ElseIf _Stage = "SECOND" Then
                .Append(" Z.ACCOUNTCODE")
                .Append(" ,Z.ITEMCODE")
                .Append(" ,Z.DESIGNCODE")
                .Append(" ,Z.SHADECODE")
                .Append(" ,A.ACCOUNTNAME AS PartyName")
                .Append(" ,B.ITENNAME AS Item")
                .Append(" ,C.SHADE AS Shade")
                .Append(" ,SUM(Z.PlanningQty)-SUM(Z.OwnBeamPlanQty) as Planning")
                .Append(" ,SUM(Z.OwnBeamPlanQty) as BeamPlan")
            End If
            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append("  A.TAXSLAB AS ACCOUNTCODE")
            .Append(" ,A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)) AS PlanningQty")
            .Append(" ,0.00 as OwnBeamPlanQty")
            .Append(" ,0.00 as JobBeamPlanQty")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" WHERE 1=1")
            .Append(" AND A.MRP='NO'  ")
            .Append(" AND A.SHORTNAME='NEW QUALITY PLANNING'")
            .Append(" UNION ALL ")
            .Append(" SELECT ")
            .Append("  A.TAXSLAB AS ACCOUNTCODE")
            .Append(" , A.GROUPNAME AS ItemCode")
            .Append(" ,A.COMPNAME AS DesignCode")
            .Append(" ,A.PRIMERUNIT AS Shadecode")
            .Append(" ,0.00 AS PlanningQty")
            .Append(" ,IIF (B.Own_Job='OWN',B.Beam_Length,0) as OwnBeamPlanQty")
            .Append(" ,IIF (B.Own_Job='JOB',B.Beam_Length,0) as JobBeamPlanQty")
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16 ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            .Append(" WHERE 1=1")
            .Append(" AND A.ITEMNAME=B.OP16")
            .Append(" ) AS Z ")

            If _Stage = "SECOND" Then
                .Append(" LEFT JOIN MstMasterAccount AS A ON Z.ACCOUNTCODE=A.ACCOUNTCODE")
                .Append(" LEFT JOIN MstFabricItem AS B ON Z.ITEMCODE=B.ID")
                .Append(" LEFT JOIN Mst_Fabric_Shade AS c ON Z.SHADECODE=c.ID")
                .Append(" WHERE 1=1")
                .Append(Filterstring)
                .Append(" GROUP BY ")
                .Append(" Z.ACCOUNTCODE,")
                .Append(" Z.ITEMCODE,")
                .Append(" Z.DESIGNCODE,")
                .Append(" Z.SHADECODE")
                .Append(" ,A.ACCOUNTNAME")
                .Append(" ,B.ITENNAME ")
                .Append(" ,C.SHADE")
                .Append(" ORDER BY ")
                .Append(" A.ACCOUNTNAME")
                .Append(" ,B.ITENNAME ")
                .Append(" ,C.SHADE")
            Else
                .Append(" WHERE 1=1")
                .Append(Filterstring)
                .Append(" GROUP BY ")
                .Append(" Z.ACCOUNTCODE,")
                .Append(" Z.ITEMCODE,")
                .Append(" Z.DESIGNCODE,")
                .Append(" Z.SHADECODE")
            End If



        End With

        Return _strQuery.ToString
    End Function
    Private Function _QueySalesFactstock(ByVal _Stage As String, ByVal Filterstring As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            If _Stage = "FIRST" Then
                .Append("  A.TAXSLAB AS ACCOUNTCODE")
                .Append(" ,A.GROUPNAME AS ItemCode ")
                .Append(" ,A.COMPNAME AS DesignCode ")
                .Append(" ,A.PRIMERUNIT AS Shadecode ")
                .Append(" ,0.00 as OldSales")
                .Append(" ,0.00 as Planning")
                .Append(" ,0.00 as BeamPlan")
                .Append(" ,ISNULL(SUM(D.GMtr), 0) - ISNULL(SUM(E.GMtr), 0) AS FactStock ")
                .Append(" ,0.00 AS ProcsDyn ")
                .Append(" ,0.00 AS GreyMtr ")
                .Append(" ,0.00 AS ProcReady ")
                .Append(" ,0.00 AS GradingStk ")
            ElseIf _Stage = "SECOND" Then
                .Append("  A.TAXSLAB AS ACCOUNTCODE")
                .Append(" ,A.GROUPNAME AS ItemCode ")
                .Append(" ,A.COMPNAME AS DesignCode ")
                .Append(" ,A.PRIMERUNIT AS Shadecode ")
                .Append(" ,ISNULL(SUM(D.GMtr), 0) - ISNULL(SUM(E.GMtr), 0) AS FactStock ")
            End If
            .Append(" FROM MstItemBatchWise AS A ")
            .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16  ")
            .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE = C.BOOKCODE ")
            .Append(" LEFT JOIN TrnGreyRcpt AS D ON B.BEAMNO = D.BEAMNO ")
            .Append(" LEFT JOIN TrnGreyDesp AS E ON D.Grey_Rcpt_Pcs_ID = E.Grey_Rcpt_Pcs_ID ")
            .Append(" AND A.ITEMNAME=B.OP16  ")

            If _Stage = "SECOND" Then
                .Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16  ")
                .Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE = C.BOOKCODE ")
                .Append(" LEFT JOIN TrnGreyRcpt AS D ON B.BEAMNO = D.BEAMNO ")
                .Append(" LEFT JOIN TrnGreyDesp AS E ON D.Grey_Rcpt_Pcs_ID = E.Grey_Rcpt_Pcs_ID ")
                .Append(" WHERE 1=1")
                .Append(Filterstring)
            Else
                .Append(" WHERE 1=1")
                .Append(Filterstring)
                .Append(" GROUP BY  ")
                .Append(" A.GROUPNAME, ")
                .Append(" A.COMPNAME, ")
                .Append("  A.TAXSLAB, ")
                .Append(" A.PRIMERUNIT ")
            End If
        End With

        Return _strQuery.ToString
    End Function
    Private Function _QueySalesProcsDyn(ByVal _Stage As String, ByVal Filterstring As String)
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT  ")
            If _Stage = "FIRST" Then
                .Append(" Z.ITEMCODE   ")
                .Append(" ,Z.DESIGNCODE   ")
                .Append(" ,Z.SHADECODE   ")
                .Append(" ,Z.ACCOUNTCODE  ")
                .Append(" ,0.00 as OldSales")
                .Append(" ,0.00 as Planning")
                .Append(" ,0.00 as BeamPlan")
                .Append(" ,0.00 AS FactStock ")
                .Append(" ,SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.FMixMtr) AS ProcsDyn ")
                .Append(" ,0.00 AS GreyMtr ")
                .Append(" ,0.00 AS ProcReady ")
                .Append(" ,0.00 AS GradingStk ")
            ElseIf _Stage = "SECOND" Then
                .Append(" Z.ITEMCODE   ")
                .Append(" ,Z.DESIGNCODE   ")
                .Append(" ,Z.SHADECODE   ")
                .Append(" ,Z.ACCOUNTCODE  ")
                .Append(" ,A.ACCOUNTNAME AS PartyName")
                .Append(" ,B.ITENNAME AS Item")
                .Append(" ,C.SHADE AS Shade")
                .Append(" ,SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.FMixMtr) AS ProcsDyn ")
            End If
            .Append(" FROM ( ")
            .Append(" SELECT    ")
            .Append(" A.FABRIC_ITEMCODE as ITEMCODE,A.processcode as AccountCode  ")
            .Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            .Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            .Append(" ,IIF (A.FD_PD='FD',(A.GMTR),0) AS GFDMtr ")
            .Append(" ,IIF (A.FD_PD='PD',(A.GMTR),0) AS GPDMtr ")
            .Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),(A.GMTR),0) AS  GMixMtr ")
            .Append(" ,0.00 AS FMixMtr ")
            .Append(" ,0.00 AS FFDMtr ")
            .Append(" ,0.00 AS FPDMtr ")
            .Append(" ,a.PcAvgWt ")
            .Append(" ,a.BeamNo ")
            .Append(" ,a.PieceNo ")
            .Append(" FROM TRNGREYDESP AS A  ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.IDP='YES' ")
            .Append(" UNION ALL ")
            .Append(" SELECT    ")
            .Append(" A.FABRIC_ITEMCODE as ITEMCODE,A.processcode as AccountCode  ")
            .Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            .Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            .Append(" ,0.00 AS GFDMtr ")
            .Append(" ,0.00 AS GPDMtr ")
            .Append(" ,0.00 AS  GMixMtr ")
            .Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),ISNULL(B.GMTR,0),0) AS FMixMtr ")
            .Append(" ,IIF (A.FD_PD='FD',ISNULL(B.GMTR,0),0) AS FFDMtr ")
            .Append(" ,IIF (A.FD_PD='PD',ISNULL(B.GMTR,0),0) AS FPDMtr ")
            .Append(" ,a.PcAvgWt ")
            .Append(" ,a.BeamNo ")
            .Append(" ,a.PieceNo ")
            .Append(" FROM TRNGREYDESP AS A  ")
            .Append(" LEFT JOIN TRNFINISHRCPT AS B ON A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
            .Append(" WHERE 1=1  ")
            .Append(" AND A.IDP='YES' ")
            .Append(" ) AS Z ")
            If _Stage = "SECOND" Then
                .Append(" LEFT JOIN MstMasterAccount AS A ON Z.ACCOUNTCODE=A.ACCOUNTCODE")
                .Append(" LEFT JOIN MstFabricItem AS B ON Z.ITEMCODE=B.ID")
                .Append(" LEFT JOIN Mst_Fabric_Shade AS c ON Z.SHADECODE=c.ID")
                .Append(" WHERE 1=1")
                .Append(Filterstring)
                .Append(" GROUP BY ")
                .Append(" Z.ITEMCODE,Z.ACCOUNTCODE ")
                .Append(" ,Z.DESIGNCODE   ")
                .Append(" ,Z.SHADECODE   ")
                .Append(" ,A.ACCOUNTNAME")
                .Append(" ,B.ITENNAME ")
                .Append(" ,C.SHADE")
                .Append(" HAVING (SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.GMixMtr)+SUM(Z.FMixMtr))-(SUM(Z.FFDMtr)+SUM(Z.FPDMtr))>0 ")

            Else
                .Append(" WHERE 1=1")
                .Append(Filterstring)
                .Append(" GROUP BY ")
                .Append(" Z.ITEMCODE,Z.AccountCode ")
                .Append(" ,Z.DESIGNCODE   ")
                .Append(" ,Z.SHADECODE   ")
                .Append(" HAVING (SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.GMixMtr)+SUM(Z.FMixMtr))-(SUM(Z.FFDMtr)+SUM(Z.FPDMtr))>0 ")

            End If
        End With

        Return _strQuery.ToString
    End Function
    Private Function _QueySalesGreyMtr(ByVal _Stage As String, ByVal Filterstring As String)
        _strQuery = New StringBuilder
        With _strQuery
            .AppendLine("SELECT")
            If _Stage = "FIRST" Then
                .AppendLine(" Z.ITEMCODE,")
                .AppendLine(" Z.DESIGNCODE,")
                .AppendLine(" Z.SHADECODE,")
                .AppendLine(" Z.ACCOUNTCODE,")
                .AppendLine(" 0.00 AS OldSales,")
                .AppendLine(" 0.00 AS Planning,")
                .AppendLine(" 0.00 AS BeamPlan,")
                .AppendLine(" 0.00 AS FactStock,")
                .AppendLine(" 0.00 AS ProcsDyn,")
                .AppendLine(" SUM(Z.GREYMTR) AS GreyMtr,")
                .AppendLine(" 0.00 AS ProcReady,")
                .AppendLine(" 0.00 AS GradingStk")

            ElseIf _Stage = "SECOND" Then
                .AppendLine(" Z.ITEMCODE,")
                .AppendLine(" Z.DESIGNCODE,")
                .AppendLine(" Z.SHADECODE,")
                .AppendLine(" Z.ACCOUNTCODE,")
                .AppendLine(" A.ACCOUNTNAME AS PartyName,")
                .AppendLine(" B.ITENNAME AS Item,")
                .AppendLine(" C.SHADE AS Shade,")
                .AppendLine(" SUM(Z.GREYMTR) AS GreyMtr")
            End If

            .AppendLine(" FROM (")
            .AppendLine("   SELECT")
            .AppendLine("     A.FABRIC_ITEMCODE AS ITEMCODE,")
            .AppendLine("     A.Fabric_DesignCode AS DESIGNCODE,")
            .AppendLine("     A.Fabric_ShadeCode AS SHADECODE,")
            .AppendLine("     A.ProcessCode AS ProcessCode,")
            .AppendLine("     A.AccountCode AS AccountCode,")
            .AppendLine("     (A.GMTR - ISNULL(SUM(B.GMTR),0)) AS GREYMTR")
            .AppendLine("   FROM TRNGREYDESP AS A")
            .AppendLine("   LEFT JOIN TRNFINISHRCPT AS B ON A.GREY_DESP_PCS_ID = B.GREY_DESP_PCS_ID")
            .AppendLine("   WHERE 1=1")
            .AppendLine("     AND A.IDP = 'YES'")
            .AppendLine("     AND A.BOOKCODE NOT IN ('0001-000000135','0001-000000095','0001-000000654')")
            .AppendLine("     AND (A.Process_PcsIdSelect IS NULL OR A.Process_PcsIdSelect = '')")
            .AppendLine("   GROUP BY")
            .AppendLine("     A.FABRIC_ITEMCODE,")
            .AppendLine("     A.Fabric_DesignCode,")
            .AppendLine("     A.Fabric_ShadeCode,")
            .AppendLine("     A.ProcessCode,")
            .AppendLine("     A.AccountCode,")
            .AppendLine("     A.GMTR")
            .AppendLine("   HAVING (A.GMTR - ISNULL(SUM(B.GMTR),0)) > 0")
            .AppendLine(" ) AS Z")

            If _Stage = "SECOND" Then
                .AppendLine(" LEFT JOIN MstMasterAccount AS A ON Z.ACCOUNTCODE = A.ACCOUNTCODE")
                .AppendLine(" LEFT JOIN MstFabricItem AS B ON Z.ITEMCODE = B.ID")
                .AppendLine(" LEFT JOIN Mst_Fabric_Shade AS C ON Z.SHADECODE = C.ID")
            End If

            .AppendLine(" WHERE 1=1")
            .AppendLine(Filterstring)

            If _Stage = "SECOND" Then
                .AppendLine(" GROUP BY")
                .AppendLine("   Z.ITEMCODE, Z.ACCOUNTCODE,")
                .AppendLine("   Z.DESIGNCODE, Z.SHADECODE,")
                .AppendLine("   A.ACCOUNTNAME, B.ITENNAME, C.SHADE")
            Else
                .AppendLine(" GROUP BY")
                .AppendLine("   Z.ITEMCODE, Z.ACCOUNTCODE,")
                .AppendLine("   Z.DESIGNCODE, Z.SHADECODE")
            End If
        End With

        Return _strQuery.ToString
    End Function
    Private Function _QueySalesProcready(ByVal _Stage As String, ByVal Filterstring As String)
        _strQuery = New StringBuilder
        With _strQuery
            .AppendLine("SELECT")
            If _Stage = "FIRST" Then
                .AppendLine(" Z.ITEMCODE,")
                .AppendLine(" Z.DESIGNCODE,")
                .AppendLine(" Z.SHADECODE,")
                .AppendLine(" Z.ACCOUNTCODE,")
                .AppendLine(" 0.00 AS OldSales,")
                .AppendLine(" 0.00 AS Planning,")
                .AppendLine(" 0.00 AS BeamPlan,")
                .AppendLine(" 0.00 AS FactStock,")
                .AppendLine(" 0.00 AS ProcsDyn,")
                .AppendLine(" 0.00 AS GreyMtr,")
                '.AppendLine(" SUM(Z.GMTR) AS ProcReady,")
                .AppendLine(" 0.00 AS ProcReady,")
                .AppendLine(" 0.00 AS GradingStk")

            ElseIf _Stage = "SECOND" Then
                .AppendLine(" Z.ITEMCODE,")
                .AppendLine(" Z.DESIGNCODE,")
                .AppendLine(" Z.SHADECODE,")
                .AppendLine(" Z.ACCOUNTCODE,")
                .AppendLine(" A.ACCOUNTNAME AS PartyName,")
                .AppendLine(" B.ITENNAME AS Item,")
                .AppendLine(" C.SHADE AS Shade,")
                .AppendLine(" SUM(Z.GMTR) AS ProcReady")
            End If

            .AppendLine(" FROM (")
            .AppendLine("   SELECT")
            .Append(" A.Fabric_ItemCode AS ITEMCODE ")
            .Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            .Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            .Append(" ,a.processcode as AccountCode  ")
            .Append(" , IIF (A.Process_OT5 IN ('OK','YES') ,SUM(A.GMTR),0) AS ProcReady ")
            .Append(" FROM  ")
            .Append(" TRNGREYDESP AS A ")
            .Append(" LEFT JOIN  trnfinishrcpt AS F ON A.grey_desp_pcs_id=F.grey_desp_pcs_id ")
            .Append(" WHERE 1=1 ")
            .AppendLine(Filterstring)
            .Append(" AND A.Process_PcsIdSelect >'' ")
            .Append(" and f.Grey_Desp_Pcs_ID IS NULL ")
            .Append(" and A.Process_Beamlotno>'' ")
            .Append(" GROUP BY ")
            .Append(" A.Fabric_ItemCode ")
            .Append(" ,A.processcode ")
            .Append(" ,a.Process_OT5 ")
            .Append(" ,a.Fabric_DesignCode ")
            .Append(" ,a.Fabric_ShadeCode ")
            .AppendLine(" ) AS Z")

            If _Stage = "SECOND" Then
                .AppendLine(" LEFT JOIN MstMasterAccount AS A ON Z.ACCOUNTCODE = A.ACCOUNTCODE")
                .AppendLine(" LEFT JOIN MstFabricItem AS B ON Z.ITEMCODE = B.ID")
                .AppendLine(" LEFT JOIN Mst_Fabric_Shade AS C ON Z.SHADECODE = C.ID")

            End If
            .AppendLine(" WHERE 1=1")
            .AppendLine(Filterstring)
            If _Stage = "SECOND" Then
                .AppendLine(" GROUP BY")
                .AppendLine("   Z.ITEMCODE, Z.ACCOUNTCODE,")
                .AppendLine("   Z.DESIGNCODE, Z.SHADECODE,")
                .AppendLine("   A.ACCOUNTNAME, B.ITENNAME, C.SHADE")
            Else
                .AppendLine(" GROUP BY")
                .AppendLine("   Z.ITEMCODE, Z.ACCOUNTCODE,")
                .AppendLine("   Z.DESIGNCODE, Z.SHADECODE")
            End If
        End With

        Return _strQuery.ToString
    End Function
    Private Function _QueySalesGradingStk(ByVal _Stage As String, ByVal Filterstring As String)
        _strQuery = New StringBuilder
        With _strQuery
            .AppendLine("SELECT")
            If _Stage = "FIRST" Then
                .AppendLine(" Z.ITEMCODE,")
                .AppendLine(" Z.DESIGNCODE,")
                .AppendLine(" Z.SHADECODE,")
                .AppendLine(" Z.ACCOUNTCODE,")
                .AppendLine(" 0.00 AS OldSales,")
                .AppendLine(" 0.00 AS Planning,")
                .AppendLine(" 0.00 AS BeamPlan,")
                .AppendLine(" 0.00 AS FactStock,")
                .AppendLine(" 0.00 AS ProcsDyn,")
                .AppendLine(" SUM(Z.GREYMTR) AS GreyMtr,")
                .AppendLine(" 0.00 AS ProcReady,")
                .AppendLine(" 0.00 AS GradingStk")

            ElseIf _Stage = "SECOND" Then
                .AppendLine(" Z.ITEMCODE,")
                .AppendLine(" Z.DESIGNCODE,")
                .AppendLine(" Z.SHADECODE,")
                .AppendLine(" Z.ACCOUNTCODE,")
                .AppendLine(" A.ACCOUNTNAME AS PartyName,")
                .AppendLine(" B.ITENNAME AS Item,")
                .AppendLine(" C.SHADE AS Shade,")
                .AppendLine(" SUM(Z.GREYMTR) AS GreyMtr")
            End If
            .AppendLine(" FROM (")
            .AppendLine("   SELECT")
            .Append(" A.ItemCode")
            .Append(" ,A.DESIGNCODE")
            .Append(" ,A.shadecode")
            .Append(" ,A.AccountCode")
            .Append(" ,0.00 as OldSales")
            .Append(" ,0.00 as Planning")
            .Append(" ,0.00 as BeamPlan")
            .Append(" ,0.00 AS FactStock ")
            .Append(" ,0.00 AS ProcsDyn ")
            .Append(" ,0.00 AS GreyMtr ")
            .Append(" ,0.00 AS ProcReady ")
            .Append(" ,SUM (Z.CHK_MTR)-SUM (Z.CUT_MTR) As GradingStk")
            .Append("  	FROM (")
            .Append("  	SELECT")
            .Append("  	Y.PIECE_ID")
            .Append("  	, SUM(Y.Checked_mtr) AS CHK_MTR,")
            .Append("  	SUM(Y.CUTTING_MTR) AS CUT_MTR")
            .Append("  	FROM")
            .Append("  	(")
            .Append("  	SELECT")
            .Append("  	A.PIECE_ID, A.mtr as Checked_mtr,0.00 AS CUTTING_MTR")
            .Append("  	FROM TRNGRADING A,MstCutMaster B")
            .Append("  	WHERE 1=1 AND LEFT(A.BOOKTRTYPE,1)<>'P'")
            .Append("  	AND LEFT(A.BOOKTRTYPE,1)<>'R'")
            .Append("  	AND A.CutCode=B.ID")
            .Append("  	AND B.CutType in ('LUMP','THAN','RIGHT CUT')")

            .Append("  	UNION ALL")
            .Append("  	SELECT ")
            .Append("  	A.PARENT_PIECE_ID AS PIECE_ID,")
            .Append("  	0.00 AS Checked_mtr,SUM(A.MTR) AS CUTTING_MTR")
            .Append("  	FROM TRNGRADING A")
            .Append("  	WHERE 1=1")

            .Append("  	GROUP BY A.PARENT_PIECE_ID   ")
            .Append("  	) AS Y")
            .Append("  	GROUP BY Y.PIECE_ID ")
            .Append("  	HAVING SUM(Checked_mtr)>0")
            .Append("  	) AS Z")
            .Append("  	, TRNGRADING as A ")
            .Append("  where 1=1 ")
            .Append(" And ROUND(Z.CHK_MTR-Z.CUT_MTR,2)>0 ")
            .Append(" AND A.Piece_ID =Z.Piece_ID  ")
            .Append("  	GROUP BY")
            .Append("  	A.ItemCode")
            .Append("  	,A.shadecode")
            .Append("  	,A.DESIGNCODE")
            .Append("  	,A.AccountCode")
            .AppendLine(" ) AS Z")

            If _Stage = "SECOND" Then
                .AppendLine(" LEFT JOIN MstMasterAccount AS A ON Z.ACCOUNTCODE = A.ACCOUNTCODE")
                .AppendLine(" LEFT JOIN MstFabricItem AS B ON Z.ITEMCODE = B.ID")
                .AppendLine(" LEFT JOIN Mst_Fabric_Shade AS C ON Z.SHADECODE = C.ID")
            End If

            .AppendLine(" WHERE 1=1")
            .AppendLine(Filterstring)

            If _Stage = "SECOND" Then
                .AppendLine(" GROUP BY")
                .AppendLine("   Z.ITEMCODE, Z.ACCOUNTCODE,")
                .AppendLine("   Z.DESIGNCODE, Z.SHADECODE,")
                .AppendLine("   A.ACCOUNTNAME, B.ITENNAME, C.SHADE")
            Else
                .AppendLine(" GROUP BY")
                .AppendLine("   Z.ITEMCODE, Z.ACCOUNTCODE,")
                .AppendLine("   Z.DESIGNCODE, Z.SHADECODE")
            End If
        End With

        Return _strQuery.ToString
    End Function
    Private Function _QueyOldSales(ByVal _Stage As String, ByVal Filterstring As String)


        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")

            If _Stage = "FIRST" Then
                .Append(" Z.ACCOUNTCODE")
                .Append(" ,Z.ITEMCODE")
                .Append(" ,Z.DESIGNCODE")
                .Append(" ,Z.SHADECODE")
                .Append(" ,Z.OldSales")
                .Append(" ,0.00 as Planning")
                .Append(" ,0.00 as BeamPlan")
                .Append(" ,0.00 as FactStock")
                .Append(" ,0.00 AS ProcsDyn ")
                .Append(" ,0.00 AS GreyMtr ")
                .Append(" ,0.00 AS ProcReady ")
                .Append(" ,0.00 AS GradingStk ")
            ElseIf _Stage = "SECOND" Then
                .Append(" Z.ACCOUNTCODE")
                .Append(" ,Z.ITEMCODE")
                .Append(" ,Z.DESIGNCODE")
                .Append(" ,Z.SHADECODE")
                .Append(" ,A.ACCOUNTNAME AS PartyName")
                .Append(" ,B.ITENNAME AS Item")
                .Append(" ,C.SHADE AS Shade")
                .Append(" ,Z.OldSales")
            End If

            .Append(" FROM ( ")
            .Append(" SELECT ")
            .Append(" A.ACCOUNTCODE")
            .Append(" ,A.ITEMCODE")
            .Append(" ,A.DESIGNCODE")
            .Append(" ,A.SHADECODE")
            .Append(" ,A.MTR_WEIGHT as OldSales")
            .Append(" FROM")
            .Append(" TrnPackingSlip AS A ")
            .Append(" LEFT JOIN MSTBOOK AS C ON A.BOOKCODE=C.BOOKCODE")

            .Append(" WHERE 1=1")
            .Append(" AND C.BEHAVIOUR='FINISH'")
            .Append(" AND C.BOOKCATEGORY='PACKING SLIP'")
            .Append(" ) AS Z")

            If _Stage = "SECOND" Then
                .Append(" LEFT JOIN MstMasterAccount AS A ON Z.ACCOUNTCODE=A.ACCOUNTCODE")
                .Append(" LEFT JOIN MstFabricItem AS B ON Z.ITEMCODE=B.ID")
                .Append(" LEFT JOIN Mst_Fabric_Shade AS c ON Z.SHADECODE=c.ID")
                .Append(" WHERE 1=1")
                .Append(Filterstring)
                .Append(" ORDER BY ")
                .Append(" A.ACCOUNTNAME")
                .Append(" ,B.ITENNAME ")
                .Append(" ,C.SHADE")
            Else
                .Append(" WHERE 1=1")
                .Append(Filterstring)
            End If

        End With
        Return _strQuery.ToString
    End Function
#End Region

    Private Function _salesQuery(ByVal Comp_Print_Name As String, ByVal DataBaseName As String, ByVal _FilterItemPartyWise As String, ByVal _GridStage As String)

        Dim _OldSales As String = _QueyOldSales(_GridStage, "")
        Dim _Beamplanning As String = _QueySalesBeamPlan(_GridStage, "")
        Dim _Factstock As String = _QueySalesFactstock(_GridStage, "")
        Dim _ProcsDyn As String = _QueySalesProcsDyn(_GridStage, "")
        Dim _GreyMtr As String = _QueySalesGreyMtr(_GridStage, "")
        Dim _ProcReady As String = _QueySalesProcready(_GridStage, "")
        Dim _Gradingstk As String = _QueySalesGradingStk(_GridStage, "")

        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" '" & Comp_Print_Name & "' as ComAlies")
            .Append(" ,'" & DataBaseName & "' as DataBaseName")

            If _FilterItemPartyWise = "PARTY WISE" Then
                .Append(" ,Z.ACCOUNTCODE")
                .Append(" ,B.ACCOUNTNAME AS PartyName")
            Else
                .Append(" ,D.ITENNAME AS ItemName")
                .Append(" ,Z.ITEMCODE")
            End If

            .Append(" ,SUM(Z.OldSales) AS OldSales")
            .Append(" ,SUM(Z.Planning) AS Planning")
            .Append(" ,SUM(Z.BeamPlan) AS BeamPlan")
            .Append(" ,SUM(Z.FactStock) AS FactStock")
            .Append(" ,SUM(Z.ProcsDyn) AS ProcsDyn")
            .Append(" ,SUM(Z.GreyMtr) AS GreyMtr")
            .Append(" ,SUM(Z.ProcReady) AS ProcReady")
            .Append(" ,SUM(Z.GradingStk) AS GradingStk")
            .Append(" ,SUM(Z.Planning)+SUM(Z.BeamPlan)+SUM(Z.FactStock)+SUM(Z.ProcsDyn)+SUM(Z.GreyMtr)+SUM(Z.ProcReady)+SUM(Z.GradingStk) AS TotStk")

            .Append(" FROM (")

#Region "Old sales"
            .Append(_OldSales)
            '.Append(" SELECT ")
            '.Append(" A.ACCOUNTCODE")
            '.Append(" ,A.ITEMCODE")
            '.Append(" ,A.DESIGNCODE")
            '.Append(" ,A.SHADECODE")
            '.Append(" ,A.MTR_WEIGHT as OldSales")
            '.Append(" ,0.00 as Planning")
            '.Append(" ,0.00 as BeamPlan")
            '.Append(" ,0.00 as FactStock")
            '.Append(" ,0.00 AS ProcsDyn ")
            '.Append(" ,0.00 AS GreyMtr ")
            '.Append(" ,0.00 AS ProcReady ")
            '.Append(" ,0.00 AS GradingStk ")
            '.Append(" FROM")
            '.Append(" TrnPackingSlip AS A ")
            '.Append(" LEFT JOIN MSTBOOK AS C ON A.BOOKCODE=C.BOOKCODE")
            '.Append(" WHERE 1=1")
            '.Append(" AND C.BEHAVIOUR='FINISH'")
            '.Append(" AND C.BOOKCATEGORY='PACKING SLIP'")

#End Region

#Region "Beam Planning Data"
            .Append(" UNION ALL ")
            .Append(_Beamplanning)
            '.Append(" SELECT ")
            '.Append(" Z.ACCOUNTCODE")
            '.Append(" ,Z.ITEMCODE")
            '.Append(" ,Z.DESIGNCODE")
            '.Append(" ,Z.SHADECODE")
            '.Append(" ,0.00 as OldSales")
            '.Append(" ,SUM(Z.PlanningQty)-SUM(Z.OwnBeamPlanQty) as Planning")
            '.Append(" ,SUM(Z.OwnBeamPlanQty) as BeamPlan")
            '.Append(" ,0.00 as FactStock")
            '.Append(" ,0.00 AS ProcsDyn ")
            '.Append(" ,0.00 AS GreyMtr ")
            '.Append(" ,0.00 AS ProcReady ")
            '.Append(" ,0.00 AS GradingStk ")
            '.Append(" FROM ( ")
            '.Append(" SELECT ")
            '.Append("  A.TAXSLAB AS ACCOUNTCODE")
            '.Append(" ,A.GROUPNAME AS ItemCode")
            '.Append(" ,A.COMPNAME AS DesignCode")
            '.Append(" ,A.PRIMERUNIT AS Shadecode")
            '.Append(" ,CAST(ISNULL(a.ALTUNIT,'0') AS DECIMAL(18, 3)) AS PlanningQty")
            '.Append(" ,0.00 as OwnBeamPlanQty")
            '.Append(" ,0.00 as JobBeamPlanQty")
            '.Append(" FROM MstItemBatchWise AS A ")
            '.Append(" WHERE 1=1")
            '.Append(" AND A.MRP='NO'  ")
            '.Append(" AND A.SHORTNAME='NEW QUALITY PLANNING'")

            '.Append(" UNION ALL ")

            '.Append(" SELECT ")
            '.Append("  A.TAXSLAB AS ACCOUNTCODE")
            '.Append(" , A.GROUPNAME AS ItemCode")
            '.Append(" ,A.COMPNAME AS DesignCode")
            '.Append(" ,A.PRIMERUNIT AS Shadecode")
            '.Append(" ,0.00 AS PlanningQty")
            '.Append(" ,IIF (B.Own_Job='OWN',B.Beam_Length,0) as OwnBeamPlanQty")
            '.Append(" ,IIF (B.Own_Job='JOB',B.Beam_Length,0) as JobBeamPlanQty")
            '.Append(" FROM MstItemBatchWise AS A ")
            '.Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16 ")
            '.Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE=C.BOOKCODE ")
            '.Append(" WHERE 1=1")
            '.Append(" AND A.ITEMNAME=B.OP16")
            '.Append(" ) AS Z ")
            '.Append(" GROUP BY ")
            '.Append(" Z.ACCOUNTCODE,")
            '.Append(" Z.ITEMCODE,")
            '.Append(" Z.DESIGNCODE,")
            '.Append(" Z.SHADECODE")
#End Region


#Region "Factory Stock"
            .Append(" UNION ALL ")
            .Append(_Factstock)
            '.Append(" SELECT  ")
            '.Append("  A.TAXSLAB AS ACCOUNTCODE")
            '.Append(" ,A.GROUPNAME AS ItemCode ")
            '.Append(" ,A.COMPNAME AS DesignCode ")
            '.Append(" ,A.PRIMERUNIT AS Shadecode ")
            '.Append(" ,0.00 as OldSales")
            '.Append(" ,0.00 as Planning")
            '.Append(" ,0.00 as BeamPlan")
            '.Append(" ,ISNULL(SUM(D.GMtr), 0) - ISNULL(SUM(E.GMtr), 0) AS FactStock ")
            '.Append(" ,0.00 AS ProcsDyn ")
            '.Append(" ,0.00 AS GreyMtr ")
            '.Append(" ,0.00 AS ProcReady ")
            '.Append(" ,0.00 AS GradingStk ")
            '.Append(" FROM MstItemBatchWise AS A ")
            '.Append(" LEFT JOIN TrnBeamHeader AS B ON A.ITEMNAME=B.OP16  ")
            '.Append(" LEFT JOIN MSTBOOK AS C ON B.BOOKCODE = C.BOOKCODE ")
            '.Append(" LEFT JOIN TrnGreyRcpt AS D ON B.BEAMNO = D.BEAMNO ")
            '.Append(" LEFT JOIN TrnGreyDesp AS E ON D.Grey_Rcpt_Pcs_ID = E.Grey_Rcpt_Pcs_ID ")
            '.Append(" WHERE 1 = 1 ")
            '.Append(" AND A.ITEMNAME=B.OP16  ")
            '.Append(" GROUP BY  ")
            '.Append(" A.GROUPNAME, ")
            '.Append(" A.COMPNAME, ")
            '.Append("  A.TAXSLAB, ")
            '.Append(" A.PRIMERUNIT ")
#End Region



#Region "Process Stock"
            .Append(" UNION ALL ")
            .Append(_ProcsDyn)
            '.Append(" SELECT ")
            '.Append(" Z.FABRIC_ITEMCODE as ITEMCODE   ")
            '.Append(" ,Z.DESIGNCODE   ")
            '.Append(" ,Z.SHADECODE   ")
            '.Append(" ,Z.AccountCode  ")
            '.Append(" ,0.00 as OldSales")
            '.Append(" ,0.00 as Planning")
            '.Append(" ,0.00 as BeamPlan")
            '.Append(" ,0.00 AS FactStock ")
            '.Append(" ,SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.FMixMtr) AS ProcsDyn ")
            '.Append(" ,0.00 AS GreyMtr ")
            '.Append(" ,0.00 AS ProcReady ")
            '.Append(" ,0.00 AS GradingStk ")
            '.Append(" FROM ( ")
            '.Append(" SELECT    ")
            '.Append(" A.FABRIC_ITEMCODE,A.processcode as AccountCode  ")
            '.Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            '.Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            '.Append(" ,IIF (A.FD_PD='FD',(A.GMTR),0) AS GFDMtr ")
            '.Append(" ,IIF (A.FD_PD='PD',(A.GMTR),0) AS GPDMtr ")
            '.Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),(A.GMTR),0) AS  GMixMtr ")
            '.Append(" ,0.00 AS FMixMtr ")
            '.Append(" ,0.00 AS FFDMtr ")
            '.Append(" ,0.00 AS FPDMtr ")
            '.Append(" ,a.PcAvgWt ")
            '.Append(" ,a.BeamNo ")
            '.Append(" ,a.PieceNo ")
            '.Append(" FROM TRNGREYDESP AS A  ")
            '.Append(" WHERE 1=1  ")
            '.Append(" AND A.IDP='YES' ")
            ''.Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            '.Append(" UNION ALL ")
            '.Append(" SELECT    ")
            '.Append(" A.FABRIC_ITEMCODE,A.processcode as AccountCode  ")
            '.Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            '.Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            '.Append(" ,0.00 AS GFDMtr ")
            '.Append(" ,0.00 AS GPDMtr ")
            '.Append(" ,0.00 AS  GMixMtr ")
            '.Append(" ,IIF (A.FD_PD NOT IN ('FD','PD'),ISNULL(B.GMTR,0),0) AS FMixMtr ")
            '.Append(" ,IIF (A.FD_PD='FD',ISNULL(B.GMTR,0),0) AS FFDMtr ")
            '.Append(" ,IIF (A.FD_PD='PD',ISNULL(B.GMTR,0),0) AS FPDMtr ")
            '.Append(" ,a.PcAvgWt ")
            '.Append(" ,a.BeamNo ")
            '.Append(" ,a.PieceNo ")
            '.Append(" FROM TRNGREYDESP AS A  ")
            '.Append(" LEFT JOIN TRNFINISHRCPT AS B ON A.GREY_DESP_PCS_ID=B.GREY_DESP_PCS_ID ")
            '.Append(" WHERE 1=1  ")
            '.Append(" AND A.IDP='YES' ")
            ''.Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            '.Append(" ) AS Z ")
            '.Append(" GROUP BY ")
            '.Append(" Z.FABRIC_ITEMCODE,Z.AccountCode ")
            '.Append(" ,Z.DESIGNCODE   ")
            '.Append(" ,Z.SHADECODE   ")
            ''.Append(" ,Z.BeamNo ")
            ''.Append(" ,Z.PieceNo ")
            '.Append(" HAVING (SUM(Z.GFDMtr)+SUM(Z.GPDMtr)+SUM(Z.GMixMtr)+SUM(Z.FMixMtr))-(SUM(Z.FFDMtr)+SUM(Z.FPDMtr))>0 ")

#End Region


#Region "Process Stock After Req"
            .Append(" UNION ALL ")
            .Append(_GreyMtr)

            '.Append(" SELECT ")
            '.Append(" a.FABRIC_ITEMCODE as ITEMCODE   ")
            '.Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            '.Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            '.Append(" ,a.processcode as AccountCode  ")
            '.Append(" ,0.00 as OldSales")
            '.Append(" ,0.00 as Planning")
            '.Append(" ,0.00 as BeamPlan")
            '.Append(" ,0.00 AS FactStock ")
            '.Append(" ,0.00 AS ProcsDyn ")
            '.Append(" ,A.GMTR-ROUND(ISNULL(SUM(B.GMTR),0),3) AS GreyMtr ")
            '.Append(" ,0.00 AS ProcReady ")
            '.Append(" ,0.00 AS GradingStk ")
            '.Append(" FROM ")
            '.Append(" TRNGREYDESP AS A ")
            '.Append(" LEFT JOIN TRNFINISHRCPT AS B ON  A.GREY_DESP_PCS_ID = B.GREY_DESP_PCS_ID ")
            '.Append(" WHERE 1=1 ")
            '.Append(" AND A.IDP='YES' ")
            '.Append(" AND A.BOOKCODE NOT IN ( '0001-000000135','0001-000000095','0001-000000654')   ")
            '.Append(" AND (A.Process_PcsIdSelect IS NULL  OR A.Process_PcsIdSelect='')  ")
            '.Append(" group by ")
            '.Append(" a.fabric_ItemCode ")
            '.Append(" ,a.Fabric_ShadeCode ")
            '.Append(" ,a.Fabric_DesignCode ")
            '.Append(" ,A.BeamNo ")
            '.Append(" ,A.PieceNo ")
            '.Append(" ,A.Weight ")
            '.Append(" ,A.PcAvgWt ")
            '.Append(" ,A.Pick ")
            '.Append(" ,A.FD_PD ")
            '.Append(" ,A.EntryNo ")
            '.Append(" ,A.GMTR ")
            '.Append(" ,A.ChallanDate ")
            '.Append(" ,A.BookVno ")
            '.Append(" ,A.BookCode ")
            '.Append(" ,A.ProcessCode ")
            '.Append(" ,A.AccountCode ")
            '.Append(" ,A.FactoryCode ")
            '.Append(" ,A.Process_ShadeType ")
            '.Append(" having (A.GMTR)-ISNULL(sum(B.GMTR),0)>0 ")
#End Region

#Region "Pending PBeam"

            .Append(" UNION ALL ")
            .Append(_ProcReady)

            '.Append(" SELECT ")
            '.Append(" A.Fabric_ItemCode AS ITEMCODE ")
            '.Append(" ,a.Fabric_DesignCode as DESIGNCODE   ")
            '.Append(" ,a.Fabric_ShadeCode as SHADECODE   ")
            '.Append(" ,a.processcode as AccountCode  ")
            '.Append(" ,0.00 as OldSales")
            '.Append(" ,0.00 as Planning")
            '.Append(" ,0.00 as BeamPlan")
            '.Append(" ,0.00 AS FactStock ")
            '.Append(" ,0.00 AS ProcsDyn ")
            '.Append(" ,0.00 AS GreyMtr ")
            '.Append(" , IIF (A.Process_OT5 IN ('OK','YES') ,SUM(A.GMTR),0) AS ProcReady ")
            '.Append(" ,0.00 AS GradingStk ")

            '.Append(" FROM  ")
            '.Append(" TRNGREYDESP AS A ")
            '.Append(" LEFT JOIN  trnfinishrcpt AS F ON A.grey_desp_pcs_id=F.grey_desp_pcs_id ")
            '.Append(" WHERE 1=1 ")
            '.Append(" AND A.Process_PcsIdSelect >'' ")
            '.Append(" and f.Grey_Desp_Pcs_ID IS NULL ")
            '.Append(" and A.Process_Beamlotno>'' ")
            '.Append(" GROUP BY ")
            '.Append(" A.Fabric_ItemCode ")
            '.Append(" ,A.processcode ")
            '.Append(" ,a.Process_OT5 ")
            '.Append(" ,a.Fabric_DesignCode ")
            '.Append(" ,a.Fabric_ShadeCode ")

#End Region


#Region "Grading Stock Read"
            .Append(" UNION ALL ")
            .Append(_Gradingstk)

            '.Append("  	Select")
            '.Append(" A.ItemCode")
            '.Append(" ,A.DESIGNCODE")
            '.Append(" ,A.shadecode")
            '.Append(" ,A.AccountCode")
            '.Append(" ,0.00 as OldSales")
            '.Append(" ,0.00 as Planning")
            '.Append(" ,0.00 as BeamPlan")
            '.Append(" ,0.00 AS FactStock ")
            '.Append(" ,0.00 AS ProcsDyn ")
            '.Append(" ,0.00 AS GreyMtr ")
            '.Append(" ,0.00 AS ProcReady ")
            '.Append(" ,SUM (Z.CHK_MTR)-SUM (Z.CUT_MTR) As GradingStk")
            '.Append("  	FROM (")
            '.Append("  	SELECT")
            '.Append("  	Y.PIECE_ID")
            '.Append("  	, SUM(Y.Checked_mtr) AS CHK_MTR,")
            '.Append("  	SUM(Y.CUTTING_MTR) AS CUT_MTR")
            '.Append("  	FROM")
            '.Append("  	(")
            '.Append("  	SELECT")
            '.Append("  	A.PIECE_ID, A.mtr as Checked_mtr,0.00 AS CUTTING_MTR")
            '.Append("  	FROM TRNGRADING A,MstCutMaster B")
            '.Append("  	WHERE 1=1 AND LEFT(A.BOOKTRTYPE,1)<>'P'")
            '.Append("  	AND LEFT(A.BOOKTRTYPE,1)<>'R'")
            '.Append("  	AND A.CutCode=B.ID")
            '.Append("  	AND B.CutType in ('LUMP','THAN','RIGHT CUT')")

            '.Append("  	UNION ALL")
            '.Append("  	SELECT ")
            '.Append("  	A.PARENT_PIECE_ID AS PIECE_ID,")
            '.Append("  	0.00 AS Checked_mtr,SUM(A.MTR) AS CUTTING_MTR")
            '.Append("  	FROM TRNGRADING A")
            '.Append("  	WHERE 1=1")

            '.Append("  	GROUP BY A.PARENT_PIECE_ID   ")
            '.Append("  	) AS Y")
            '.Append("  	GROUP BY Y.PIECE_ID ")
            '.Append("  	HAVING SUM(Checked_mtr)>0")
            '.Append("  	) AS Z")
            '.Append("  	, TRNGRADING as A ")
            '.Append("  where 1=1 ")
            '.Append(" And ROUND(Z.CHK_MTR-Z.CUT_MTR,2)>0 ")
            '.Append(" AND A.Piece_ID =Z.Piece_ID  ")
            '.Append("  	GROUP BY")
            '.Append("  	A.ItemCode")
            '.Append("  	,A.shadecode")
            '.Append("  	,A.DESIGNCODE")
            '.Append("  	,A.AccountCode")
#End Region

            .Append(" ) AS Z ")

            .Append(" LEFT JOIN MstMasterAccount AS B ON Z.ACCOUNTCODE=B.ACCOUNTCODE")
            '.Append(" LEFT JOIN MstMasterAccount AS C ON B.AGENTCODE=C.ACCOUNTCODE")
            .Append(" LEFT JOIN MstFabricItem AS D ON Z.ITEMCODE=D.ID")

            .Append(" GROUP BY")

            If _FilterItemPartyWise = "PARTY WISE" Then
                .Append(" Z.ACCOUNTCODE,")
                .Append(" B.ACCOUNTNAME")
            Else
                .Append(" D.ITENNAME,")
                .Append(" Z.ITEMCODE")
            End If

        End With

        Return _strQuery.ToString
    End Function
#End Region

#Region " Grid Second Key Event"
    Dim validTypes As String() = {"Req", "Wash", "Dyn", "Stenter", "Mechan", "Fold", "TblChk", "RtMtr", "Ready", "Decision"}
    Private Sub CreateDropDownMenu()
        Dim item1 As New DevExpress.XtraBars.BarButtonItem(BarManager1, "Process Wise")
        Dim item2 As New DevExpress.XtraBars.BarButtonItem(BarManager1, "Process+Item")
        Dim item3 As New DevExpress.XtraBars.BarButtonItem(BarManager1, "Process+Item+Beam")


        item1.Appearance.Options.UseFont = True
        item1.Appearance.Font = New Font("Verdana", 10, FontStyle.Bold)

        item2.Appearance.Options.UseFont = True
        item2.Appearance.Font = New Font("Verdana", 10, FontStyle.Bold)

        item3.Appearance.Options.UseFont = True
        item3.Appearance.Font = New Font("Verdana", 10, FontStyle.Bold)


        AddHandler item1.ItemClick, AddressOf ProcessWise_Click
        AddHandler item2.ItemClick, AddressOf ProcessItem_Click
        AddHandler item3.ItemClick, AddressOf ProcessItemBeam_Click


        PopupMenu1.AddItem(item1)
        PopupMenu1.AddItem(item2)
        PopupMenu1.AddItem(item3)

    End Sub
    Private Sub BtnGridPrint_Click(sender As Object, e As EventArgs) Handles BtnGridPrint.Click
        'Dim _RptTiltle = " Process Wise Stock List :"
        '_DevExpressPrintPrivew(_RptTiltle, FirstStage)
        PopupMenu1.ShowPopup(BtnGridPrint.PointToScreen(New Point(0, BtnGridPrint.Height)))
    End Sub
    Private Sub ProcessWise_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

        obj_Party_Selection.MULTY_Process_SELECTION()
        If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            focusedColumn_I = FirstStage.FocusedColumn
            _StgIRowNo = FirstStage.FocusedRowHandle
            NoOfstage = 1
            Dim _FilterString = " AND  A.PROCESSCODE in  " & MULTY_SELECTION_COLOUM_3_DATA & ""
            _ProcessSecondStageDisplay(_FilterString, "FIRST", "", "", focusedColumn_I, 0, "Print Process Wise", MULTY_SELECTION_COLOUM_3_DATA)
        End If

    End Sub
    Private Sub ProcessItem_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

        obj_Party_Selection.MULTY_Process_SELECTION()
        If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            focusedColumn_I = FirstStage.FocusedColumn
            _StgIRowNo = FirstStage.FocusedRowHandle
            NoOfstage = 1
            Dim _FilterString = " AND  A.PROCESSCODE in  " & MULTY_SELECTION_COLOUM_3_DATA & ""
            _ProcessSecondStageDisplay(_FilterString, "FIRST", "", "", focusedColumn_I, 0, "Print Process+Item Wise", MULTY_SELECTION_COLOUM_3_DATA)
        End If
    End Sub
    Private Sub ProcessItemBeam_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim _FilterString = ""
        obj_Party_Selection.MULTY_Process_SELECTION()
        If MULTY_SELECTION_COLOUM_3_DATA > "" Then
            focusedColumn_I = FirstStage.FocusedColumn
            _StgIRowNo = FirstStage.FocusedRowHandle
            NoOfstage = 2
            Dim ProcessCodeFilter = " AND  A.PROCESSCODE in  " & MULTY_SELECTION_COLOUM_3_DATA & ""
            obj_Party_Selection.MULTY_ITEM_SELECTION()
            If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                Dim ItemCodeFilter = " AND  A.FABRIC_ITEMCODE in  " & MULTY_SELECTION_COLOUM_3_DATA & ""
                _FilterString = ProcessCodeFilter & ItemCodeFilter
                _ProcessSecond_Req(_FilterString, "Print Process+Item+Beam Wise", SelectionType, "", "", "ENTER", "Print Process+Item+Beam Wise", _FilterString)
            End If
        End If
    End Sub
    Private Sub BtnProcessDetailPrint_Click(sender As Object, e As EventArgs) Handles BtnProcessDetailPrint.Click
        If SelectionOfView = "Process" Then
            Dim _ActClmValue As String = String.Empty
            If FirstStage IsNot Nothing AndAlso FirstStage.FocusedColumn IsNot Nothing Then
                _StageActColName = FirstStage.FocusedColumn.FieldName
            End If
            If FirstStage IsNot Nothing AndAlso _StageActColName IsNot Nothing Then
                Dim cellValue = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, _StageActColName)
                If cellValue IsNot Nothing Then
                    _ActClmValue = cellValue.ToString()
                End If
            End If

            If validTypes.Contains(_StageActColName) AndAlso _ActClmValue > "" Then
                Dim ProcessCode = FirstStage.GetRowCellValue(FirstStage.FocusedRowHandle, "PROCESSCODE").ToString
                Dim _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'"
                _ProcessSecond_Req(_FilterString, "THIRD", _StageActColName, "", "", "ENTER", "PRINT", _FilterString)
            End If

        End If
    End Sub

    Private Sub GridControl2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl2.KeyDown
        Try
            Dim _ActivatedColName As String = ""
            If GridView1 IsNot Nothing AndAlso GridView1.FocusedColumn IsNot Nothing Then
                _ActivatedColName = GridView1.FocusedColumn.FieldName
            End If

            _RedyeningShadeCode = ""
            FilterBookVno = ""
            If SelectionOfView = "Outstanding" Then
                SelectionType = _ActivatedColName.ToString
#Region "Outstanding"
                If e.KeyCode = Keys.F2 Then

                    Dim BOOKVNO As String = GridView1.GetFocusedRowCellValue("BOOKVNO").ToString

                    Txt_Remark_1.Text = ""
                    Txt_Remark_2.Text = ""
                    Txt_Remark_3.Text = ""
                    txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                    PnlRemark.Visible = True
                    PnlRemark.BringToFront()
                    txtRemarkDate.Focus()
                    txtRemarkDate.SelectAll()

                ElseIf e.KeyCode = Keys.Enter Then
                    Dim BOOKVNO As String = GridView1.GetFocusedRowCellValue("BOOKVNO").ToString
                    If SelectionButton = "Foloup Outstanding List" Then
                        FoloupSelectionEnter = GridView1.GetFocusedRowCellValue("PymtDate").ToString
                        _GetBillWiseFoloList(BOOKVNO)
                    ElseIf SelectionButton = "GR Matter" Then
                        FoloupSelectionEnter = GridView1.GetFocusedRowCellValue("PymtDate").ToString
                        _GetBillWiseFoloList(BOOKVNO)
                    ElseIf SelectionButton = "Other Matter" Then
                        FoloupSelectionEnter = GridView1.GetFocusedRowCellValue("PymtDate").ToString
                        _GetBillWiseFoloList(BOOKVNO)
                    End If
                ElseIf e.KeyCode = Keys.Delete Then
                    If NoOfstage = 3 Then
                        If MsgBox("Do You Want To Delete This Folo", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete ?") = MsgBoxResult.Yes Then
                            Dim BOOKVNO As String = GridView1.GetFocusedRowCellValue("BOOKVNO").ToString
                            Dim FoloDate As String = GridView1.GetFocusedRowCellValue("PymtDate").ToString
                            _DeleteFoloof(BOOKVNO, FoloDate)
                            _GetBillWiseFoloList(BOOKVNO)
                        End If
                    End If
                ElseIf e.KeyCode = Keys.Escape Then
                    NoOfstage = 2
                    If FoloupSelectionEnter = "" Then Exit Sub
                    If SelectionButton = "Foloup Outstanding List" Then
                        _GetPymtRemarkSecondStage(FoloupSelectionEnter)
                        FoloupSelectionEnter = ""
                    ElseIf SelectionButton = "GR Matter" Then
                        _GrMatterSecondStage(FoloupSelectionEnter)
                    ElseIf SelectionButton = "Other Matter" Then
                        _OthRemarkSecondStage(FoloupSelectionEnter)
                    End If
                End If
#End Region
            ElseIf SelectionOfView = "Factory" Then
                SelectionType = _ActivatedColName.ToString
#Region "Factory"
                If e.KeyCode = Keys.Enter Then
                    _StgIRowNo = GridView1.FocusedRowHandle

                    If SelectionType = "FoldingQty" AndAlso NoOfstage = 1 Then
                        Dim BeamNo As String = GridView1.GetFocusedRowCellValue("BeamNo").ToString
                        NoOfstage = 2
                        _GetBeamWiseStockSecondStage(BeamNo, "FoldingQty")
                    ElseIf SelectionType = "DespatchQty" AndAlso NoOfstage = 1 Then
                        NoOfstage = 2
                        Dim BeamNo As String = GridView1.GetFocusedRowCellValue("BeamNo").ToString
                        _GetBeamWiseStockSecondStage(BeamNo, "DespatchQty")


                    ElseIf (SelectionType = "FactStkUse" Or SelectionType = "PurPlanQty" Or SelectionType = "YarnOrder") AndAlso NoOfstage = 1 Then
                        NoOfstage = 2
                        Dim _StockType As String = ""
                        If SelectionType = "FactStkUse" Then
                            _StockType = "FACTORY STOCK"
                        ElseIf SelectionType = "PurPlanQty" Then
                            _StockType = "PURCHASE"
                        ElseIf SelectionType = "YarnOrder" Then
                            _StockType = "YARN PLANNING ENTRY"
                        End If
                        Dim PlanNo As String = GridView1.GetFocusedRowCellValue("PlanNo").ToString
                        Dim CountCode As String = GridView1.GetFocusedRowCellValue("CountCode").ToString
                        _GetFactroyYarnStkUe(PlanNo, CountCode, SelectionType, _StockType)
                    End If
                ElseIf e.KeyCode = Keys.F2 Then
                    NoOfstage = 2
                    FactoryYarnCountCode = ""
                    FactoryPlaningNo = ""

                    If SelectionType = "FactStkUse" AndAlso GridView1.GetFocusedRowCellValue("FYPStk").ToString > "" Then

                        _RemarkLableNameFeeler("Factory Yarn Stock Use Entry", "Plan Date", "Count Name", "Qty", "Remark", "")

                        FactoryYarnCountCode = GridView1.GetFocusedRowCellValue("CountCode").ToString
                        FactoryPlaningNo = GridView1.GetFocusedRowCellValue("PlanNo").ToString
                        Txt_Remark_1.Text = GridView1.GetFocusedRowCellValue("CountName").ToString
                        Txt_Remark_2.Text = ""
                        Txt_Remark_3.Text = ""
                        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

                        PnlRemark.Visible = True
                        PnlRemark.BringToFront()
                        txtRemarkDate.Focus()
                        txtRemarkDate.SelectAll()

                    ElseIf SelectionType = "PurPlanQty" Then
                        _RemarkLableNameFeeler("Yarn Purchase Plan Entry", "Plan Date", "Count Name", "Qty", "Remark", "")
                        FactoryYarnCountCode = GridView1.GetFocusedRowCellValue("CountCode").ToString
                        FactoryPlaningNo = GridView1.GetFocusedRowCellValue("PlanNo").ToString
                        Txt_Remark_1.Text = GridView1.GetFocusedRowCellValue("CountName").ToString
                        Txt_Remark_2.Text = ""
                        Txt_Remark_3.Text = ""
                        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")

                        PnlRemark.Visible = True
                        PnlRemark.BringToFront()
                        txtRemarkDate.Focus()
                        txtRemarkDate.SelectAll()


                    ElseIf SelectionType = "WarpDate" Then
                        _RemarkLableNameFeeler("Warping Entry", "Warp Date", "Warper Name", "Beam Length", "Remark", "Remark-1")
                        Txt_Remark_1.Text = GridView1.GetFocusedRowCellValue("WarperName").ToString
                        _RedyeningShadeCode = GridView1.GetFocusedRowCellValue("Warper_Code").ToString
                        Txt_Remark_2.Text = GridView1.GetFocusedRowCellValue("BeamLength").ToString
                        FilterBookVno = GridView1.GetFocusedRowCellValue("MainBeamBookvno").ToString
                        Dim warpDateValue As Object = GridView1.GetFocusedRowCellValue("WarpDate")
                        Dim warpDateFormatted As String = ""
                        If warpDateValue > "" AndAlso Not IsDBNull(warpDateValue) Then
                            Dim dt As DateTime = Convert.ToDateTime(warpDateValue)
                            warpDateFormatted = dt.ToString("dd/MM/yyyy")
                            txtRemarkDate.Text = warpDateFormatted
                        Else
                            txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                        End If

                        Txt_Remark_3.Text = ""
                        Txt_Remark_1.Focus()
                        Txt_Remark_1.SelectAll()
                    ElseIf SelectionType = "DrawDate" Or SelectionType = "Drawing" Then
                        _RemarkLableNameFeeler("Drawer Entry", "Drawer Date", "Drawer Name", "Beam Length", "Remark", "Remark-1")
                        Txt_Remark_1.Text = GridView1.GetFocusedRowCellValue("DrawerName").ToString
                        _RedyeningShadeCode = GridView1.GetFocusedRowCellValue("DrawerCode").ToString
                        Txt_Remark_2.Text = GridView1.GetFocusedRowCellValue("BeamLength").ToString
                        FilterBookVno = GridView1.GetFocusedRowCellValue("MainBeamBookvno").ToString
                        txtRemarkDate.Text = GridView1.GetFocusedRowCellValue("DrawDate").ToString
                        If txtRemarkDate.Text = "" Then txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                        Txt_Remark_3.Text = ""
                        Lbl_GrRemark.Visible = False
                        Label4.Visible = False
                        Txt_Remark_2.Visible = False

                        Txt_Remark_1.Focus()
                        Txt_Remark_1.SelectAll()
                    ElseIf SelectionType = "PinDate" Or SelectionType = "Pinning" Then
                        _RemarkLableNameFeeler("Pinner Entry", "Pinneing Date", "Pinner Name", "Beam Length", "Remark", "Remark-1")
                        Txt_Remark_1.Text = GridView1.GetFocusedRowCellValue("PinnerName").ToString
                        _RedyeningShadeCode = GridView1.GetFocusedRowCellValue("PinnerCode").ToString
                        Txt_Remark_2.Text = GridView1.GetFocusedRowCellValue("BeamLength").ToString
                        FilterBookVno = GridView1.GetFocusedRowCellValue("MainBeamBookvno").ToString
                        txtRemarkDate.Text = GridView1.GetFocusedRowCellValue("PinDate").ToString
                        If txtRemarkDate.Text = "" Then txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                        Lbl_GrRemark.Visible = False
                        Label4.Visible = False
                        Txt_Remark_2.Visible = False

                        Txt_Remark_3.Text = ""
                        Txt_Remark_1.Focus()
                        Txt_Remark_1.SelectAll()
                    ElseIf SelectionType = "LoomNo" Then
                        _RemarkLableNameFeeler("Loom No Entry", "Gatting Date", "Loom No", "Beam Length", "Remark", "Remark-1")
                        Txt_Remark_1.Text = GridView1.GetFocusedRowCellValue("LoomNo").ToString
                        _RedyeningShadeCode = GridView1.GetFocusedRowCellValue("LOOMCODE").ToString
                        Txt_Remark_2.Text = GridView1.GetFocusedRowCellValue("BeamLength").ToString
                        FilterBookVno = GridView1.GetFocusedRowCellValue("MainBeamBookvno").ToString
                        txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
                        Txt_Remark_3.Text = ""
                        Txt_Remark_1.Focus()
                        Txt_Remark_1.SelectAll()
                    ElseIf SelectionType = "YarnOrder" Then
                        Dim frm As New YarnPurchasesPlaningDisplay()
                        frm._isCallerByOther = True
                        frm.ShowDialog()
                        'ShowFormMDI(frm)

                    End If

                ElseIf e.KeyCode = Keys.Escape Then
                    If NoOfstage = 2 Then
                        If SelectionType = "FoldingQty" Then
                            NoOfstage = 1
                            _GetBeamWiseStockFirstStage("FoldingQty")
                        ElseIf SelectionType = "DespatchQty" Then
                            NoOfstage = 1
                            _GetBeamWiseStockFirstStage("DespatchQty")
                        ElseIf SelectionType = "FactStock" Then
                            NoOfstage = 1
                            _GetBeamWiseStockFirstStage("FactStock")
                        End If
                        If FactoryActiveClmName = "YarnRequire" Then
                            NoOfstage = 1
                            _GetYarnRequirQty(FactoryActiveClmItemCode)
                        End If
                    End If
                End If

#End Region
            ElseIf SelectionOfView = "Producation DashBoard" Then
                SelectionType = _ActivatedColName.ToString
#Region "Producation DashBoard"
                If e.KeyCode = Keys.Enter Then
                    _StgIRowNo = GridView1.FocusedRowHandle
                    If _CommanFirstStageActivColumn = "FactStock" AndAlso NoOfstage = 1 Then
                        NoOfstage = 2
                        Dim BeamNo As String = GridView1.GetFocusedRowCellValue("BeamNo").ToString
                        _GetBeamWiseStockSecondStage(BeamNo, "FactStock")
                    End If
                ElseIf e.KeyCode = Keys.Escape Then
                    If NoOfstage = 2 Then
                        If _CommanFirstStageActivColumn = "FactStock" Then
                            NoOfstage = 1
                            _GetBeamWiseStockFirstStage("FactStock")
                        End If
                    End If
                End If
#End Region
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GridControl2_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl2.ProcessGridKey
        If SelectionOfView = "Process" Then
#Region "Process"

            Dim _ActivatedColName As String = ""
            If GridView1 IsNot Nothing AndAlso GridView1.FocusedColumn IsNot Nothing Then
                _ActivatedColName = GridView1.FocusedColumn.FieldName
            End If


            Dim _FilterString = ""
            If e.KeyCode = Keys.Enter Then
                If SelectionType = "ProcStk" Then
                    Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                    Dim ITEMCODE As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ITEMCODE").ToString
                    _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                    Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                    Dim ItemName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Item").ToString
                    If GridView1 IsNot Nothing AndAlso GridView1.FocusedColumn IsNot Nothing Then
                        _StageActColName = GridView1.FocusedColumn.FieldName
                    End If
                    Dim _ActClmValue As String = String.Empty

                    If GridView1 IsNot Nothing AndAlso _StageActColName IsNot Nothing Then
                        Dim cellValue = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, _StageActColName)
                        If cellValue IsNot Nothing Then
                            _ActClmValue = cellValue.ToString()
                        End If
                    End If

                    If validTypes.Contains(_StageActColName) AndAlso _ActClmValue > "" Then
                        If NoOfstage = 1 Then
                            focusedColumn_I = GridView1.FocusedColumn
                            _StgIIRowNo = GridView1.FocusedRowHandle
                            NoOfstage = 2
                            _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                            _ProcessSecond_Req(_FilterString, "SECOND", _StageActColName, _ProcessName, ItemName, "ENTER", "GRID", _FilterString)
                        ElseIf NoOfstage = 2 Then
                            focusedColumn_II = GridView1.FocusedColumn
                            NoOfstage = 3
                            _StgIIIRowNo = GridView1.FocusedRowHandle
                            Dim BeamNo As String = ""
                            Dim rowHandle As Integer = GridView1.FocusedRowHandle

                            If rowHandle >= 0 Then
                                Dim cellValue = GridView1.GetRowCellValue(rowHandle, "BeamNo")
                                If cellValue IsNot Nothing AndAlso cellValue IsNot DBNull.Value Then
                                    BeamNo = cellValue.ToString()
                                End If
                            End If

                            _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'" & " AND  A.Process_Beamlotno = '" & BeamNo & "'"
                            Dim _FilterString_Second = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'" & " AND  A.ENTRYNO = '" & BeamNo & "'"
                            _ProcessSecond_Req(_FilterString, "THIRD", _StageActColName, _ProcessName, ItemName, "ENTER", "GRID", _FilterString_Second)
                        End If
                    ElseIf _StageActColName = "PBeam" AndAlso _ActClmValue > "" Then
                        _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                        NoOfstage = 2
                        _StgIIRowNo = GridView1.FocusedRowHandle

                        _ProcessSecondPBeam(_FilterString, "SECOND", _ProcessName, ItemName, 0)



                    ElseIf _StageActColName = "GrdDprMtr" AndAlso _ActClmValue > "" Then
                        NoOfstage = 2
                        _StgIIRowNo = GridView1.FocusedRowHandle
                        _FilterString = " AND  A.accountcode = '" & ProcessCode & "'" & " AND  A.ITEMCODE = '" & ITEMCODE & "'"
                        _GradingDprStockGate(_FilterString, "FIRST", SelectionType, _ProcessName, "", "ENTER", "GRID", "")
                    End If

                ElseIf SelectionType = "PBeam" Then
                    Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                    Dim ITEMCODE As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ITEMCODE").ToString
                    _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                    NoOfstage = 2
                    _StgIIRowNo = GridView1.FocusedRowHandle
                    Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                    Dim ItemName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Item").ToString
                    _ProcessSecondPBeam(_FilterString, "SECOND", _ProcessName, ItemName, 0)

                ElseIf SelectionType = "Req" Or SelectionType = "Wash" Or SelectionType = "Dyn" Or SelectionType = "Stenter" Or SelectionType = "Mechan" Or SelectionType = "Fold" Or SelectionType = "TblChk" Or SelectionType = "RtMtr" Or SelectionType = "Ready" Or SelectionType = "Decision" Then
                    Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                    Dim ITEMCODE As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ITEMCODE").ToString

                    If NoOfstage = 1 Then
                        NoOfstage = 2
                        _StgIIRowNo = GridView1.FocusedRowHandle
                        Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                        Dim ItemName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Item").ToString
                        _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                        _ProcessSecond_Req(_FilterString, "SECOND", SelectionType, _ProcessName, ItemName, "ENTER", "GRID", _FilterString)
                    ElseIf NoOfstage = 2 Then
                        NoOfstage = 3
                        _StgIIIRowNo = GridView1.FocusedRowHandle
                        Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                        Dim ItemName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Item").ToString
                        Dim BeamNo As String = ""
                        Dim rowHandle As Integer = GridView1.FocusedRowHandle

                        If rowHandle >= 0 Then
                            Dim cellValue = GridView1.GetRowCellValue(rowHandle, "BeamNo")
                            If cellValue IsNot Nothing AndAlso cellValue IsNot DBNull.Value Then
                                BeamNo = cellValue.ToString()
                            End If
                        End If

                        _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'" & " AND  A.Process_Beamlotno = '" & BeamNo & "'"
                        Dim _FilterString_Second = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'" & " AND  A.ENTRYNO = '" & BeamNo & "'"
                        _ProcessSecond_Req(_FilterString, "THIRD", SelectionType, _ProcessName, ItemName, "ENTER", "GRID", _FilterString_Second)
                    End If
                ElseIf _ActivatedColName = "Shade" AndAlso GridView1.GetFocusedRowCellValue("Status").ToString = "Re Dyening" Then
                    Party_selection.txtSearch.Text = If(GridView1.GetFocusedRowCellValue("Shade")?.ToString(), "")

                    obj_Party_Selection.SINGLE_SHADE_SELECTION()
                    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Shade", MULTY_SELECTION_COLOUM_1_DATA)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Fabric_ShadeCode", MULTY_SELECTION_COLOUM_3_DATA)
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ShadeType", MULTY_SELECTION_COLOUM_2_DATA)
                        SendKeys.Send("{TAB}")
                    End If
                End If
            ElseIf e.KeyCode = Keys.Escape Then
                If NoOfstage = 2 Or NoOfstage = 3 Then
                    If Txt_ProcessStockDisplay.Text = "PROCESS WISE" Then
                        Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                        _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'"
                    ElseIf Txt_ProcessStockDisplay.Text = "ITEM WISE" Then
                        Dim ITEMCODE As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ITEMCODE").ToString
                        _FilterString = " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                    End If

                    If SelectionType = "ProcStk" Then
                        Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                        If NoOfstage = 3 Then
                            Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                            Dim ITEMCODE As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ITEMCODE").ToString
                            Dim ItemName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Item").ToString
                            _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                            NoOfstage = 2
                            _ProcessSecond_Req(_FilterString, "SECOND", _StageActColName, _ProcessName, ItemName, "ESC", "GRID", _FilterString)
                        ElseIf NoOfstage = 2 Then
                            NoOfstage = 1
                            Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                            _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'"
                            Dim fColumn As DevExpress.XtraGrid.Columns.GridColumn = GridView1.Columns(_StageActColName)
                            _ProcessSecondStageDisplay(_FilterString, "FIRST", _ProcessName, "", fColumn, _StgIIRowNo, "", ProcessCode)
                        End If
                    ElseIf SelectionType = "PBeam" Then
                        NoOfstage = 1
                        Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                        _ProcessSecondPBeam(_FilterString, "FIRST", _ProcessName, "", _StgIIRowNo)
                    ElseIf SelectionType = "Req" Or SelectionType = "Wash" Or SelectionType = "Dyn" Or SelectionType = "Stenter" Or SelectionType = "Mechan" Or SelectionType = "Fold" Or SelectionType = "TblChk" Or SelectionType = "RtMtr" Or SelectionType = "Ready" Or SelectionType = "Decision" Then
                        If NoOfstage = 3 Then
                            NoOfstage = 2
                            Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                            Dim ITEMCODE As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ITEMCODE").ToString
                            Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                            Dim ItemName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Item").ToString
                            _FilterString = " AND  A.PROCESSCODE = '" & ProcessCode & "'" & " AND  A.FABRIC_ITEMCODE = '" & ITEMCODE & "'"
                            _ProcessSecond_Req(_FilterString, "SECOND", SelectionType, _ProcessName, ItemName, "ESC", "GRID", _FilterString)
                        ElseIf NoOfstage = 2 Then
                            NoOfstage = 1

                            Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                            _ProcessSecond_Req(_FilterString, "FIRST", SelectionType, _ProcessName, "", "ESC", "GRID", _FilterString)
                        End If
                    ElseIf SelectionType = "GrdDprMtr" Then
                        If NoOfstage = 2 Then
                            NoOfstage = 1
                            Dim _ProcessName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Process").ToString
                            Dim ProcessCode = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PROCESSCODE").ToString
                            _FilterString = " AND  A.accountcode = '" & ProcessCode & "'"
                            _GradingDprStockGate(_FilterString, "FIRST", SelectionType, _ProcessName, "", "ENTER", "GRID", "")

                        End If
                    End If
                End If

#End Region
            ElseIf e.KeyCode = Keys.F1 Then
                GridView1.PostEditor()
                GridView1.CloseEditor()
                _SaveProcessChangeStage("")
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub _SaveProcessChangeStage(ByVal _RedyengBeamSave As String)
        GridView1.ActiveFilter.Clear()
        If NoOfstage = 2 Or NoOfstage = 3 Then

            'Dim _RowStatus As Boolean = False


            For i As Int64 = 0 To GridView1.RowCount - 1
                Dim Status As String = GridView1.GetRowCellValue(i, "Status").ToString()
                If String.IsNullOrWhiteSpace(Status) Then
                    GridView1.SetRowCellValue(i, "Status", "NO")
                End If



                If GridView1.GetRowCellValue(i, "TypeOfBeam")?.ToString() = "Dyening Plan Beam" Then
                    Dim rawVal = GridView1.GetRowCellValue(i, "Status")
                    If rawVal IsNot Nothing AndAlso rawVal IsNot DBNull.Value Then
                        Status = rawVal.ToString().Trim()
                    End If
                    If Array.IndexOf(_ProcessStage_3, Status) >= 0 Then
                        _strQuery = New StringBuilder
                        With _strQuery
                            .Append(" UPDATE TrnProcessDyeingPlan SET  ")
                            .Append(" Process_OT5='" & GridView1.GetRowCellValue(i, "Status").ToString & "'  ")
                            .Append(" ,Grey_Rcpt_Pcs_ID='" & CDate(Date.Now).ToString("dd/MM/yyyy") & "'  ")
                            .Append(" WHERE 1=1 ")
                            .Append(" AND BOOKVNO='" & GridView1.GetRowCellValue(i, "BookVno").ToString & "' ")
                            .Append(" AND PROCESSCODE='" & GridView1.GetRowCellValue(i, "PROCESSCODE").ToString & "' ")
                            .Append(" AND Fabric_ItemCode='" & GridView1.GetRowCellValue(i, "ITEMCODE").ToString & "' ")
                            .Append(" AND Fabric_ShadeCode='" & GridView1.GetRowCellValue(i, "Fabric_ShadeCode").ToString & "' ")
                        End With
                        sqL = _strQuery.ToString
                        sql_Data_Save_Delete_Update()
                    End If

                ElseIf GridView1.GetRowCellValue(i, "TypeOfBeam")?.ToString() = "Requisition Beam" Then

                    'If Status = "Re Dyening" AndAlso _RedyengBeamSave = "" Then
                    '    _RowStatus = True
                    'End If

                    If Txt_Remark_1.Text = "." Then Txt_Remark_1.Text = ""
                    If Txt_Remark_1.Text = "0" Then Txt_Remark_1.Text = ""


                    If GridView1.GetRowCellValue(i, "Status").ToString <> "Re Dyening" Then
                        _strQuery = New StringBuilder
                        With _strQuery
                            .Append(" UPDATE TrnGreyDesp SET  ")
                            .Append(" Process_OT5='" & GridView1.GetRowCellValue(i, "Status").ToString & "'  ")
                            .Append(" ,OP20='" & CDate(Date.Now).ToString("dd/MM/yyyy") & "'  ")
                            If NoOfstage = 3 Then
                                .Append(" ,Process_DetailRemark='" & GridView1.GetRowCellValue(i, "DyeningRemark").ToString & "'  ")
                            End If
                            .Append(" WHERE 1=1 ")
                            .Append(" AND Process_Beamlotno='" & GridView1.GetRowCellValue(i, "OrgBeamNo").ToString & "' ")
                            .Append(" AND PROCESSCODE='" & GridView1.GetRowCellValue(i, "PROCESSCODE").ToString & "' ")
                            .Append(" AND Fabric_ItemCode='" & GridView1.GetRowCellValue(i, "ITEMCODE").ToString & "' ")
                            If NoOfstage = 3 Then
                                .Append(" AND  grey_desp_pcs_id='" & GridView1.GetRowCellValue(i, "grey_desp_pcs_id").ToString & "' ")
                            End If
                        End With
                        sqL = _strQuery.ToString
                        sql_Data_Save_Delete_Update()
                    End If


                    If GridView1.GetRowCellValue(i, "Status").ToString = "Re Dyening" Then
                        _strQuery = New StringBuilder
                        With _strQuery
                            .Append(" UPDATE TrnGreyDesp SET  ")
                            .Append(" Process_OT5='" & GridView1.GetRowCellValue(i, "Status").ToString & "'  ")
                            .Append(" ,Process_Beamlotno='" & GridView1.GetRowCellValue(i, "BeamNo").ToString & "' ")
                            .Append(" ,Fabric_ShadeCode='" & GridView1.GetRowCellValue(i, "Fabric_ShadeCode").ToString & "' ")
                            .Append(" ,Process_ShadeType='" & GridView1.GetRowCellValue(i, "ShadeType").ToString & "' ")
                            .Append(" ,OP20='" & CDate(Date.Now).ToString("dd/MM/yyyy") & "'  ")
                            If NoOfstage = 3 Then
                                .Append(" ,Process_DetailRemark='" & GridView1.GetRowCellValue(i, "DyeningRemark").ToString & "'  ")
                            End If
                            .Append(" WHERE 1=1 ")
                            .Append(" AND Process_Beamlotno='" & GridView1.GetRowCellValue(i, "OrgBeamNo").ToString & "' ")
                            .Append(" AND PROCESSCODE='" & GridView1.GetRowCellValue(i, "PROCESSCODE").ToString & "' ")
                            .Append(" AND Fabric_ItemCode='" & GridView1.GetRowCellValue(i, "ITEMCODE").ToString & "' ")
                            If NoOfstage = 3 Then
                                .Append(" AND  grey_desp_pcs_id='" & GridView1.GetRowCellValue(i, "grey_desp_pcs_id").ToString & "' ")
                            End If
                        End With
                        sqL = _strQuery.ToString
                        sql_Data_Save_Delete_Update()
                    End If



                    If GridView1.GetRowCellValue(i, "Status").ToString <> "Re Dyening" Then

                        _strQuery = New StringBuilder
                        With _strQuery
                            .Append(" UPDATE TrnProcessDyeingPlan SET  ")
                            .Append(" Process_OT5='" & GridView1.GetRowCellValue(i, "Status").ToString & "'  ")
                            .Append(" ,Grey_Rcpt_Pcs_ID='" & CDate(Date.Now).ToString("dd/MM/yyyy") & "'  ")
                            If NoOfstage = 3 Then
                                .Append(" ,DetailRemark='" & GridView1.GetRowCellValue(i, "DyeningRemark").ToString & "'  ")
                            End If
                            .Append(" WHERE 1=1 ")
                            .Append(" AND Proc_BeamNo='" & GridView1.GetRowCellValue(i, "OrgBeamNo").ToString & "' ")
                            .Append(" AND PROCESSCODE='" & GridView1.GetRowCellValue(i, "PROCESSCODE").ToString & "' ")
                            .Append(" AND Fabric_ItemCode='" & GridView1.GetRowCellValue(i, "ITEMCODE").ToString & "' ")
                            If NoOfstage = 3 Then
                                .Append(" AND  grey_desp_pcs_id='" & GridView1.GetRowCellValue(i, "grey_desp_pcs_id").ToString & "' ")
                            End If
                        End With
                        sqL = _strQuery.ToString
                        sql_Data_Save_Delete_Update()
                    End If


                    If GridView1.GetRowCellValue(i, "Status").ToString = "Re Dyening" Then
                        _strQuery = New StringBuilder
                        With _strQuery
                            .Append(" UPDATE TrnProcessDyeingPlan SET  ")
                            .Append(" Process_OT5='" & GridView1.GetRowCellValue(i, "Status").ToString & "'  ")
                            .Append(" ,Proc_BeamNo='" & GridView1.GetRowCellValue(i, "BeamNo").ToString & "' ")
                            .Append(" ,Fabric_ShadeCode='" & GridView1.GetRowCellValue(i, "Fabric_ShadeCode").ToString & "' ")
                            .Append(" ,ShadeType='" & GridView1.GetRowCellValue(i, "ShadeType").ToString & "' ")
                            .Append(" ,Grey_Rcpt_Pcs_ID='" & CDate(Date.Now).ToString("dd/MM/yyyy") & "'  ")
                            If NoOfstage = 3 Then
                                .Append(" ,DetailRemark='" & GridView1.GetRowCellValue(i, "DyeningRemark").ToString & "'  ")
                            End If
                            .Append(" WHERE 1=1 ")
                            .Append(" AND Proc_BeamNo='" & GridView1.GetRowCellValue(i, "OrgBeamNo").ToString & "' ")
                            .Append(" AND PROCESSCODE='" & GridView1.GetRowCellValue(i, "PROCESSCODE").ToString & "' ")
                            .Append(" AND Fabric_ItemCode='" & GridView1.GetRowCellValue(i, "ITEMCODE").ToString & "' ")
                            If NoOfstage = 3 Then
                                .Append(" AND  grey_desp_pcs_id='" & GridView1.GetRowCellValue(i, "grey_desp_pcs_id").ToString & "' ")
                            End If
                        End With
                        sqL = _strQuery.ToString
                        sql_Data_Save_Delete_Update()
                    End If

                End If
            Next


            'If _RowStatus = True Then
            '    _RedyeningShadeCode = ""
            '    _RedyeningShadeType = ""
            '    Txt_Remark_1.Text = ""
            '    Txt_Remark_2.Text = ""
            '    Txt_Remark_3.Text = ""
            '    txtRemarkDate.Text = CDate(Date.Now).ToString("dd/MM/yyyy")
            '    PnlRemark.Visible = True
            '    PnlRemark.BringToFront()
            '    txtRemarkDate.Focus()
            '    txtRemarkDate.SelectAll()
            'Else
            MsgBox("Records Successfully Saved", MsgBoxStyle.Information, "Soft-Tex PRO")

            'End If

        End If

    End Sub
    Private Sub _DeleteFoloof(ByVal _Bookvno As String, ByVal _date As String)
        Dim _sqlDate As String = Convert.ToDateTime(_date).ToString("yyyy-MM-dd")
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" DELETE ")
            .Append(" FROM PaymentFolo  ")
            .Append(" WHERE   ")
            .Append(" BOOKVNO='" & _Bookvno & "'  ")
            .Append(" AND PaymentRemarkDate='" & _sqlDate & "'  ")
        End With
        sqL = _strQuery.ToString
        PaymentFolo_QuerySaveUpdateDelete()
        MsgBox("Entry Delete", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Soft-Tex PRO")
    End Sub
    Private Function _GetBillWiseFoloList(ByVal BOOKVNO As String)
        NoOfstage = 3
        _strQuery = New StringBuilder
        With _strQuery
            .Append(" SELECT ")
            .Append(" T.CompAlies AS ComAlies ")
            .Append(" ,T.PartyName ")
            .Append(" ,'' as PartyCity ")
            .Append(" ,T.PartyMobNo as PartyMob  ")
            .Append(" ,T.AgentName  ")
            .Append(" ,T.AgentMobileNo as AgentMob ")
            .Append(" ,T.BillNo  ")
            .Append(" ,T.BillDate ")
            .Append(" ,0 as Days  ")
            .Append(" ,FORMAT(T.Amount, '0.00') as Balance ")
            .Append(" ,format(T.PaymentRemarkDate,'dd/MM/yyyy') as PymtDate ")
            .Append(" ,T.PaymentRemark as PymtRem ")
            .Append(" ,T.BOOKVNO ")
            .Append(" ,T.GRRemark ")
            .Append(" ,T.OtherRemark as OthRemark ")
            .Append(" ,T.[DataBase] as DataBaseName ")
            .Append(" ,T.ACCOUNTCODE ")
            .Append(" ,T.PaymentRemarkDate as Rmkdate ")
            .Append(" ,0 as NoOfFolo ")
            .Append(" FROM PaymentFolo as T ")
            .Append(" where  ")
            .Append(" T.BOOKVNO = '" & BOOKVNO & "'")

            If SelectionButton = "Foloup Outstanding List" Then
                .Append(" AND T.Folodate IS NOT NULL ")
                .Append(" and T.GRRemark = '' ")
                .Append(" and T.OtherRemark = '' ")
            ElseIf SelectionButton = "GR Matter" Then
                .Append(" and T.GRRemark > '' ")
            ElseIf SelectionButton = "Other Matter" Then
                .Append(" and T.OtherRemark > '' ")
            End If

            .Append(" ORDER BY T.PartyName,T.BillDate ")
        End With

        sqL = _strQuery.ToString
        PaymentFolo_QueryLoad()
        Dim _tbl As New DataTable
        _tbl = DefaltSoftTable.Copy
        GridView1.Columns.Clear()
        GridControl2.DataSource = _tbl.Copy

        GridView1.Columns("BOOKVNO").Visible = False
        GridView1.Columns("GRRemark").Visible = False
        GridView1.Columns("OthRemark").Visible = False
        GridView1.Columns("DataBaseName").Visible = False
        GridView1.Columns("ACCOUNTCODE").Visible = False
        GridView1.Columns("Rmkdate").Visible = False
        GridView1.Columns("NoOfFolo").Visible = False

        _DevGridColumSizeAuto(GridControl1, GridView1)
        GridView1.Focus()
    End Function


#End Region

    Private Sub Btn_Exl_Click(sender As Object, e As EventArgs) Handles Btn_Exl.Click
        _DevExpressExcelExport(GridControl3)
    End Sub
    Public Sub _DevGridColumSizeAuto(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        gridView.Appearance.Row.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.Appearance.HeaderPanel.Font = New Font("Tahoma", 9, FontStyle.Bold)
        gridView.RowHeight = 25
        gridView.OptionsView.ColumnAutoWidth = False

        Dim totalBestWidth As Integer = 0
        Dim visibleCols As New List(Of DevExpress.XtraGrid.Columns.GridColumn)


        For Each col In gridView.Columns
            col.AppearanceHeader.BackColor = Color.Khaki
            col.AppearanceHeader.BackColor2 = Color.Khaki
            col.AppearanceHeader.Options.UseForeColor = True
            col.AppearanceHeader.Options.UseBackColor = True

            If col.Visible Then
                If col.FieldName = "TickMark" Then
                    col.Width = 60 ' Set fixed width
                Else
                    totalBestWidth += col.Width
                    visibleCols.Add(col)
                End If
            End If
        Next

        ' Step 4: Available width minus fixed TickMark column and scrollbar
        Dim usableWidth As Integer = gridControl.ClientSize.Width - gridView.IndicatorWidth + 60

        ' Step 5: Resize only non-TickMark visible columns proportionally
        If totalBestWidth > 0 Then
            For Each col In visibleCols
                col.Width = CInt((col.Width / totalBestWidth) * usableWidth)
            Next
        End If


        For Each col In gridView.Columns
            ' Check if column field type is numeric
            If col.ColumnType Is GetType(Integer) OrElse
                   col.ColumnType Is GetType(Decimal) OrElse
                   col.ColumnType Is GetType(Double) OrElse
                   col.ColumnType Is GetType(Single) OrElse
                   col.ColumnType Is GetType(Long) Then
                ' Align header text to the right
                col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                ' Optionally: also align cell text to right
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If
        Next


    End Sub
    Private Sub Txt_Remark_2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Remark_2.KeyDown
        If SelectionOfView = "Process" Then
            If e.KeyCode = Keys.Enter Then
                Party_selection.txtSearch.Text = Txt_Remark_2.Text
                Dim _itemcode = ""
                obj_Party_Selection.Single_List_ItemWise_shade_Selection(_itemcode, "")
                If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                    Txt_Remark_2.Text = MULTY_SELECTION_COLOUM_1_DATA
                    _RedyeningShadeCode = MULTY_SELECTION_COLOUM_3_DATA
                    _RedyeningShadeType = MULTY_SELECTION_COLOUM_2_DATA
                End If
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub
    Private Sub _GriddataSum(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal columnNames As String(), ByVal _VisbalallColumn As String)
        For Each colName In columnNames
            Dim summary As New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colName, "{0}")
            gridView.Columns(colName).Summary.Clear()
            gridView.Columns(colName).Summary.Add(summary)


            ' Agar total = 0 then column hide
            If _VisbalallColumn = "YES" Then
                Dim total As Decimal = Convert.ToDecimal(gridView.Columns(colName).SummaryItem.SummaryValue)
                If total = 0D Then
                    gridView.Columns(colName).Visible = False
                Else
                    gridView.Columns(colName).Visible = True
                End If
            End If

        Next

    End Sub
    Private Sub Txt_Remark_1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Remark_1.KeyDown
        If SelectionOfView = "Factory" Then
            If LblRemarkHeader.Text = "Warping Entry" Or LblRemarkHeader.Text = "Pinner Entry" Or LblRemarkHeader.Text = "Drawer Entry" Then
                If e.KeyCode = Keys.Enter Then
                    Party_selection.txtSearch.Text = Txt_Remark_1.Text

                    obj_Party_Selection.SINGLE_Employee_SELECTION("")
                    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                        Txt_Remark_1.Text = MULTY_SELECTION_COLOUM_1_DATA
                        _RedyeningShadeCode = MULTY_SELECTION_COLOUM_3_DATA
                    End If
                    SendKeys.Send("{TAB}")
                End If
            ElseIf LblRemarkHeader.Text = "Loom No Entry" Then
                If e.KeyCode = Keys.Enter Then
                    Party_selection.txtSearch.Text = Txt_Remark_1.Text

                    obj_Party_Selection.Single_LoomNo_Selection()
                    If MULTY_SELECTION_COLOUM_3_DATA > "" Then
                        Txt_Remark_1.Text = MULTY_SELECTION_COLOUM_1_DATA
                        _RedyeningShadeCode = MULTY_SELECTION_COLOUM_3_DATA
                    End If
                    SendKeys.Send("{TAB}")
                End If
            End If
        End If
    End Sub
    'testing

End Class