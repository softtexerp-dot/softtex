Imports System.Data.OleDb
Imports System.Data.SqlClient
'Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine


Module Module2
    Public databaseconnecton As String = "Data Source=DESKTOP-N7G62DM\HP;database=Accounts24_342025104153;Integrated Security=SSPI;persist security info=True"

    Public _UserReportPassword As String = "SOFTTEXMS"

    Public Next_Year_Code As Integer = 0
    Public _NewYearDataBaseName As String
    Public _GstBillLockDate As String
    Public _Gstr_1_BillLockDate As String
    Public _TfoSelectionFormName As String = ""
    Public _NewMasterCreatForm As Boolean = False



    Public _SelectedMenu_1 As String = ""
    Public _SelectedMenu_2 As String = ""
    Public _SelectedMenu_3 As String = ""
    Public _UserWiseWhatsappApi As String = ""
    Public _PrintingSelectionType As String = ""

    Public _PasswardWindow As String = ""
    Public WhatsAppKey As String = ""
    Public WhatsAppUrl As String = ""
    Public WhatsAppMobileNo As String = ""
    Public _whatsappselectionmode As String = ""
    Public WhatsAppToken As String = ""
    Public _LedgerDisplayAllfromFront As String = ""
    Public _LoadOutstandingDefaltMessage As String = ""
    Public _LoadOutstandingDefaltMessage_After As String = ""
    Public _GridLayoutFileName As String = ""


    Public _LoginCompanyTbl As New DataTable
    Public _LedgerAvgTbl As New DataTable
    Public _ComissionmGridTbl As New DataTable
    Public _LedgerAvgLabel1 As String = ""
    Public _LedgerAvgLabel2 As String = ""
    Public _MultyShadeTbl As New DataTable
    Public _MstBook As New DataTable
    Public _ReportViewerTbl As New DataTable
    Public _Accountactive As Boolean = False
    Public _ChkSideDaysLocking As Boolean = False


    Public _CheckWhtaspOkNo As Boolean = False
    Public _callByOtherFrom As Boolean = False
    Public _BookCodeDataAudit As String = ""
    Public _EntryNoDataAudit As String = ""
    Public _ShowOldDeshBord As String = ""
    Public _ReportLoadOption As String = ""
    Public _EInvoiceDefaltFocus As String = ""
    Public _ItemSearchTypingWise As String = ""
    Public _SelectionListName As String = ""
    Public _ServerPcPath As String = ""
    Public _CheckServerPcs As Boolean = False


    Public sql_dbConnect As dbLayer.cls_DataLayer
    Public Next_Year_Database_Name As String = ""
    Public UseFinPostFrm As String = ""
    Public ADJRemark As String = ""


    Public ReqStoreCategory As String = "No"
    Public Login_Password As String = ""
    Public _OnlineGstDetalTbl As New DataTable
    Public MASTER_VIEW As Boolean = False

    Public F2_OPEN_FROM As Boolean = False
    Public sqlServerTbl As New DataTable
    Public CheckCpuId As String = ""
    Public GroupCodeFiletrCode As String = ""
    Public PymtCalcInAdv As String = "N"
    Public Voucher_Entry_Date_From_Ledger_Display As String = ""
    Public LedgerBookvnoModify As String
    Public Continure_For_Inovice As Boolean = False
    Public rptDS As Report_set
    Public rptDS1 As Report_set
    Public Selection_Return_Array_Values(0) As String
    '------ USER RIGHTS VARIABLE START
    Public pub_User_Display_Short_Cut As String = ""
    Public pub_User_add As String = ""
    Public pub_User_modify As String = ""
    Public pub_User_delete As String = ""
    Public pub_User_view As String = ""
    Public pub_User_print As String = ""
    Public pub_User_report As String = ""
    Public pub_Data_Alter_Days As Integer = 0
    Public pub_Create_Account As String = ""
    Public pub_Create_Master As String = ""
    Public pub_Ledger_Display As String = "YES"
    Public Pub_sms_url As String = ""
    Public Pub_sms_userid As String = ""
    Public Pub_sms_password As String = ""
    Public Pub_sms_senderid As String = ""
    Public _Use_Design_Shade_In_Entry As String = ""
    Public _Pcs_No_Generate_By As String = ""
    Public SendWhatsappDefaltMobileNo As String = ""
    Public SendOnlyDefaltNoWhatsapp As String = ""
    Public _WhatsappSendCompany As String = ""
    Public _RateLock As String = ""
    Public _DirectPrintNoCopy As Integer = 1
    '------ USER RIGHTS VARIABLE END
    Public _AlterDaysCheckSystem As Boolean = True


    Public OUTSTANDING_RUNTIME_ACCOUNTCODE As String = ""
    Public OUTSTANDING_RUNTIME_DATE As String = ""
    Public User_ChangeCompany As String = ""
    Public User_change_FinYear As String = ""

    Public MULTY_SELECTION_COLOUM_1_DATA As String = ""
    Public MULTY_SELECTION_COLOUM_2_DATA As String = ""
    Public MULTY_SELECTION_COLOUM_3_DATA As String = ""
    Public MULTY_SELECTION_COLOUM_4_DATA As String = ""
    Public MULTY_SELECTION_COLOUM_5_DATA As String = ""
    Public MULTY_SELECTION_COLOUM_6_DATA As String = ""
    Public MULTY_SELECTION_COLOUM_7_DATA As String = ""
    Public GetListNoOfColumn As Integer = 0



    Public MultiReturnSelectionListArrayValues(10) As String
    Public Zero_edit_invoice As Integer
    Public strQuery As String = ""

    Public RUN_TIME_PRINT As String = ""
    Public COMPANY_TBL As New DataTable
    Public COMP_STATE As String = ""
    Public CompanyStateCode As String = ""
    Public COMPANY_NAME As String = ""
    Public COMPANY_GSTIN As String = ""
    Public _SELECTEDCOMPANYCODE As String = ""
    Public _ComapnyYearCode As String = ""

    Public COMP_CODE As String = ""

    Public _MAILPARTY_TBL As New DataTable
    Public MAIL_SUBJECT As String = ""
    Public cryRpt As New ReportDocument
    Public Access_cryRpt As New ReportDocument
    Public GROUP_WISE_MULTY_STATE_TO_CITY_SELECT As String
    Public SelectiedBookCode As String = ""


    Public LEDGER_FORM_DISPALY_BY As String
    Public strReportPath As String = ""
    Public dbConnect As dbLayer.cls_DataLayer
    Public dbConnectCmp As dbLayer.cls_DataLayer
    'Public objBackDataRpt As New Report_data
    Public LEDGER_ENTER_DISPLAY_FROM As String = ""
    Public SMTP_Server_Name As String = "smtp.gmail.com"

    'Public _strQuery As StringBuilder
    'Public ObjCls_General As New cls_FrmHandle.cls_frmHandle
    Public Screen_Height As Integer = Screen.PrimaryScreen.Bounds.Height
    Public Screen_Width As Integer = Screen.PrimaryScreen.Bounds.Width
    Public GMDI_Border_Width As Integer = 0
    Public GMDI_Main_Menu_Height As Integer = 0
    Public GMDI_Title_Bar_Height As Integer = 0

    Public _MISSING_SERIES_BOOK_CATGER As String = ""
    Public BOOK_CATGER As String = ""
    Public BOOK_BHEWAR As String = ""
    Public Book_Behaviour As String = ""
    Public _Selection_Book_Behaviour As String = ""
    Public BOOK_TRTYPE As String = ""
    Public GROUP_WISE_MULTY_PARTY_SELECT As String = ""
    Public EmailSubject As String = ""
    Public _AlterBookvno As String = ""


    Public party_selection_book_code As String = ""
    Public REPORT_RPT_FILE_NAME As String = ""
    Public REPORT_TITAL As String = ""




    Public Master_company_code As String = ""
    Public USER_ID As String = ""


    Public Cdate_FinYearDay_Start As String '= CDate("01-APR-2010").Day
    Public Cdate_FinYearMonth_Start As String '= CDate("01-APR-2010").Month
    Public Cdate_FinYearYear_Start As String '= CDate("01-APR-2010").Year
    Public USERDATE_FinYearStartDate As String = ""


    Public Cdate_FinYearDay_End As String '= CDate("31-MAR-2011").Day
    Public Cdate_FinYearMonth_End As String '= CDate("31-MAR-2011").Month
    Public Cdate_FinYearYear_End As String '= CDate("31-MAR-2011").Year
    Public USERDATE_FinYearEndDate As String '= Cdate_FinYearDay_End & "-" & Cdate_FinYearMonth_End & "-" & Cdate_FinYearYear_End
    Public FinYearStartDate As String = ""
    Public FinYearEndDate As String = ""

    Public Cdate_Today_Day As String = Date.Today.Day.ToString.PadLeft(2, "0")
    Public Cdate_Today_Month As String = Date.Today.Month.ToString.PadLeft(2, "0")
    Public Cdate_Today_Year As String = Date.Today.Year
    Public USERDATE_TodayDate As String = Cdate_Today_Day & "/" & Cdate_Today_Month & "/" & Cdate_Today_Year

    Public sqL As String
    Public sqL2 As String
    Public sqL1 As String
    Public sqL3 As String

    Public sqL4 As String
    Public sqL5 As String
    Public sqL6 As String
    Public sqL7 As String
    Public sqL8 As String

    Public ds As New DataSet
    Public cmd2 As SqlCommand
    Public cmd As SqlCommand
    Public cmd1 As SqlCommand
    Public cmd3 As SqlCommand

    Public cmd4 As SqlCommand
    Public cmd5 As SqlCommand
    Public cmd6 As SqlCommand
    Public cmd7 As SqlCommand
    Public cmd8 As SqlCommand

    Public cmdupdate As SqlCommand
    Public CMD_SUNDYDATA As SqlCommand
    Public CMD_LEDGER As SqlCommand
    Public CMD_LEDGER1 As SqlCommand
    Public CMD_LEDGER2 As SqlCommand
    Public CMDSUNDYDATA As SqlCommand
    Public CMD_Outstanding As SqlCommand

    Public dr1 As SqlDataReader
    Public dr As SqlDataReader
    Public dr2 As SqlDataReader
    Public dr3 As SqlDataReader

    Public dr4 As SqlDataReader
    Public dr5 As SqlDataReader
    Public dr6 As SqlDataReader
    Public dr7 As SqlDataReader
    Public dr8 As SqlDataReader



    Public data_reader As SqlDataReader
    Public da As SqlDataAdapter
    Public Sql_data As SqlDataAdapter
    Public conn As New SqlConnection
    Public PymtFoloconn As New SqlConnection
    Public NewYearConnection As New SqlConnection
    Public MSA_CONN As New OleDbConnection
    Public MSA_CONN1 As New OleDbConnection
    Public New_DbMenu As New OleDbConnection

    Public ReportsConnection As New OleDbConnection
    Public MenuDesignConnection As New OleDbConnection
    Public ReedMenuDesignConnection As New OleDbConnection
    Public PaymentFolo As New OleDbConnection

    Public Printing_CONN As New OleDbConnection
    Public import_CONN As New OleDbConnection

    Public RS As String
    Public RS1 As String
    Public RS2 As String
    Public MSA_CMD As OleDbCommand
    Public MSA_CMD1 As OleDbCommand
    Public MSA_CMD2 As OleDbCommand
    Public MSA_DR As OleDbDataReader
    Public MSA_DR1 As OleDbDataReader
    Public MSA_DR2 As OleDbDataReader

    Public Pub_TBL_DataView As DataTable
    Public DefaltSoftTable As New DataTable
    Public Sql_ServerName As String = ""
    Public Sql_DatabaesName As String = ""
    Public Sql_UserName As String = ""
    Public Sql_Password As String = ""

    Public _USERNAME As String = ""
    Public _USERADD As String = ""
    Public _USEREDIT As String = ""
    Public _USERDELETE As String = ""
    Public _USERVIEW As String = ""
    Public _USERPRINT As String = ""
    Public _USERREPORT As String = ""
    Public _USERLEDDIPLAY As String = ""
    Public _USERSHORTCUT As String = ""
    Public _USERMASTERMENU As String = ""
    Public _USERACCOUNTMASTER As String = ""
    Public _WhatsUpSend As String = ""
    Public _UserLedgerAccountDisplay As String = ""

    Public Comp_name As String = ""
    Public Comp_Add1 As String = ""
    Public Comp_Add2 As String = ""
    Public Comp_Add3 As String = ""
    Public Comp_Add4 As String = ""
    Public Comp_Tin As String = ""
    Public Comp_Tel_no As String = ""
    Public Comp_email As String = ""
    Public Comp_Remark_1 As String = ""
    Public Comp_Remark_2 As String = ""
    Public Comp_Remark_3 As String = ""
    Public _ShadeLoadDesignMaster As String = ""
    Public _UpiID As String = ""

    Public Comp_Cin As String = ""
    Public Comp_Tds As String = ""
    Public Comp_Tan As String = ""
    Public Comp_Pan As String = ""
    Public Comp_Subject As String = ""
    Public Comp_Bank_Name As String = ""
    Public Comp_Bank_Ac_No As String = ""
    Public Comp_Bank_IFSCode As String = ""
    Public COMP_GSTIN As String = ""
    Public COMP_AADHARNO As String = ""
    Public Comp_MSME_No As String = ""
    Public _StichingBillPrintNo As String = ""
    Public _BillNotSaveLedger As Boolean = False
    Public _SoftMode As String = ""
    Public _NewYearConnectonAddress As String = ""
    Public DataBasePasswordSet As String = "M#@softtex2025"

    Public SqlServerConnectionString As String = ""
    Public Sub databaseconnection()
        Dim appPath As String = My.Application.Info.DirectoryPath
        MSA_CONN1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\SQLDB.mdb"
        'MSA_CONN1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\SQLDB.mdb;Jet OLEDB:Database Password=" & DataBasePasswordSet & ""
        MSA_CONN1.Open()
    End Sub
    Public Sub SELECT_DATABSE()
        databaseconnection()
        RS = " select * from SqlSetting"
        MSA_CMD = New OleDb.OleDbCommand(RS, MSA_CONN1)
        MSA_CMD.CommandType = CommandType.Text
        Dim Defalt_ADP As New OleDb.OleDbDataAdapter(MSA_CMD)
        sqlServerTbl.Clear()
        Defalt_ADP.Fill(sqlServerTbl)
        MSA_CMD.Dispose()
        MSA_CONN1.Close()
        For Each dr As DataRow In sqlServerTbl.Select
            If dr.IsNull("SQLServerName") Then dr("SQLServerName") = ""
        Next

    End Sub


    Public Sub _creatPasswordInDbMenu()
        Dim appPath As String = My.Application.Info.DirectoryPath
        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\SQLDB.mdb;Mode=12;Jet OLEDB:Database Password=;"
        Try
            Using connection As New OleDbConnection(connectionString)
                connection.Open()
                Dim setPasswordQuery As String = "ALTER DATABASE PASSWORD [" & DataBasePasswordSet & "] NULL"
                Using cmd As New OleDbCommand(setPasswordQuery, connection)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Dim _sty As String = ex.ToString
            'MsgBox(ex.ToString)
        End Try

    End Sub

    Public Function GetLogin(ByVal databaseServer As String, ByVal userName As String, ByVal userPass As String, ByVal database As String) As String

        Dim conn_address As String = ""
        'Dim _serverName As String = sqlServerTbl(0).Item("SQLServerName")
        'If sqlServerTbl(0).Item("OP1").ToString = "YES" Then ' SERVER BASE MODULE LOGIN
        '    conn_address = " Database=" & database & ";Server=" & _serverName & ";user=" & sqlServerTbl(0).Item("UserName") & ";password=" & sqlServerTbl(0).Item("UserPassword") & ""
        'Else
        '    If sqlServerTbl.Rows(0).Item("ServerPcName").ToString = Nothing Then
        '        conn_address = "server=" & databaseServer & ";database=" & database & ";" & "Integrated Security=True"
        '        'conn_address = " Data Source=" & _serverName & ";" & "database=" & database & ";" & "Integrated Security=SSPI;persist security info=True"
        '    Else
        '        conn_address = "server=" & databaseServer & ";database=" & database & ";" & "Integrated Security=True"
        '        'conn_address = "  Data Source = " & _serverName & "  ;Initial Catalog= " & database & " ;User ID= " & sqlServerTbl(0).Item("UserName") & " ;Password= " & sqlServerTbl(0).Item("UserPassword") & " "
        '    End If
        'End If


        conn_address = "server=" & databaseServer & ";database=" & database & ";" & "Integrated Security=True"

        Return conn_address
    End Function

    Public Sub DB_CONNECT()
        Try
            Dim appPath As String = My.Application.Info.DirectoryPath
            If sqlServerTbl.Rows(0).Item("ServerPcName").ToString = Nothing Then
                _CheckServerPcs = True
                MSA_CONN.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\SQLDB.mdb"
                'MSA_CONN.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\SQLDB.mdb;Jet OLEDB:Database Password=" & DataBasePasswordSet & ""
            Else
                _CheckServerPcs = False
                MSA_CONN.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sqlServerTbl.Rows(0).Item("ServerPcName").ToString + "\SQLDB.mdb"
                'MSA_CONN.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sqlServerTbl.Rows(0).Item("ServerPcName").ToString + "\SQLDB.mdb;Jet OLEDB:Database Password=" & DataBasePasswordSet & ""
            End If
            MSA_CONN.Open()


        Catch ex As Exception
            MsgBox("Please Configure Database.", MsgBoxStyle.Information, "Database")
            Exit Sub
        End Try
    End Sub

    Public Sub ReportsMenuConn()

        Dim appPath As String = ""
        If _CheckServerPcs = True Then
            appPath = (System.Windows.Forms.Application.StartupPath)
        Else
            appPath = _ServerPcPath
        End If

        'Dim appPath As String = My.Application.Info.DirectoryPath
        ReportsConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\Reports.dll;Jet OLEDB:Database Password={M#~Softex&$@*"
        ReportsConnection.Open()
    End Sub
    Public Sub ReportsMenu_QueryLoad()
        Try
            DefaltSoftTable.Reset()
            ReportsMenuConn()

            MSA_CMD = New OleDb.OleDbCommand(RS, ReportsConnection)
            MSA_CMD.CommandType = CommandType.Text
            Dim ADP As New OleDb.OleDbDataAdapter(MSA_CMD)
            Dim TAB As New DataTable
            ADP.Fill(DefaltSoftTable)
            MSA_CMD.Dispose()
            ReportsConnection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub ReportsMenu_QuerySaveUpdateDelete()
        Try
            ReportsMenuConn()
            MSA_CMD = New OleDb.OleDbCommand(RS, ReportsConnection)
            MSA_CMD.ExecuteNonQuery()
            MSA_CMD.Dispose()
            ReportsConnection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub


#Region "MenuDesign Data Connection"
    Public Sub MenuDesignConn()

        'Dim appPath As String = My.Application.Info.DirectoryPath

        Dim appPath As String = ""
        If _CheckServerPcs = True Then
            appPath = (System.Windows.Forms.Application.StartupPath)
        Else
            appPath = _ServerPcPath
        End If



        MenuDesignConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\Soft.dll;Jet OLEDB:Database Password={M#~Softex&$@*"
        'MenuDesignConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\Soft.dll"
        MenuDesignConnection.Open()
    End Sub
    Public Sub MenuDesign_QueryLoad()
        Try
            DefaltSoftTable.Reset()

            MenuDesignConn()

            MSA_CMD = New OleDb.OleDbCommand(RS, MenuDesignConnection)
            MSA_CMD.CommandType = CommandType.Text

            Dim ADP As New OleDb.OleDbDataAdapter(MSA_CMD)
            ADP.Fill(DefaltSoftTable)

            MSA_CMD.Dispose()
            MenuDesignConnection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Database Error")

        Finally
            If MenuDesignConnection.State = ConnectionState.Open Then
                MenuDesignConnection.Close()
            End If
        End Try

    End Sub
    Public Sub MenuDesign_QuerySaveUpdateDelete()
        Try
            MenuDesignConn()
            MSA_CMD = New OleDb.OleDbCommand(RS, MenuDesignConnection)
            MSA_CMD.ExecuteNonQuery()
            MSA_CMD.Dispose()
            MenuDesignConnection.Close()
            Dim Err As String = ""
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Database Error")
            Dim Err As String = ""
            Err = ex.ToString
        Finally
            If MenuDesignConnection.State = ConnectionState.Open Then
                MenuDesignConnection.Close()
            End If
        End Try
    End Sub
#End Region

#Region " Reed MenuDesign Data Connection"
    Public Sub ReedMenuDesignConn()
        'Dim appPath As String = My.Application.Info.DirectoryPath

        Dim appPath As String = ""
        If _CheckServerPcs = True Then
            appPath = (System.Windows.Forms.Application.StartupPath)
        Else
            appPath = _ServerPcPath
        End If

        ReedMenuDesignConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\SoftDesigner.dll;Jet OLEDB:Database Password={M#~Softex&$@*"
        'MenuDesignConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\Soft1.dll"
        ReedMenuDesignConnection.Open()
    End Sub
    Public Sub ReedMenuDesign_QueryLoad()
        Try
            DefaltSoftTable.Reset()

            ReedMenuDesignConn()

            MSA_CMD = New OleDb.OleDbCommand(RS, ReedMenuDesignConnection)
            MSA_CMD.CommandType = CommandType.Text

            Dim ADP As New OleDb.OleDbDataAdapter(MSA_CMD)
            ADP.Fill(DefaltSoftTable)

            MSA_CMD.Dispose()
            ReedMenuDesignConnection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Database Error")
        Finally
            If ReedMenuDesignConnection.State = ConnectionState.Open Then
                ReedMenuDesignConnection.Close()
            End If
        End Try
    End Sub
    Public Sub ReedMenuDesign_QuerySaveUpdateDelete()
        Try
            ReedMenuDesignConn()
            MSA_CMD = New OleDb.OleDbCommand(RS, ReedMenuDesignConnection)
            MSA_CMD.ExecuteNonQuery()
            MSA_CMD.Dispose()
            ReedMenuDesignConnection.Close()
            Dim Err As String = ""
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Database Error")
            Dim Err As String = ""
            Err = ex.ToString
            Err = ex.ToString

        Finally

            If ReedMenuDesignConnection.State = ConnectionState.Open Then
                ReedMenuDesignConnection.Close()
            End If
        End Try

    End Sub

#End Region

#Region "PaymentFolo Data Connection"
    Public Sub PymtFoConn()

        'Dim appPath As String = ""

        'If _CheckServerPcs = True Then
        '    appPath = (System.Windows.Forms.Application.StartupPath)
        'Else
        '    appPath = _ServerPcPath
        'End If
        'PaymentFolo.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & appPath + "\PaymentFolo.mdb"
        'PaymentFolo.Open()

        Dim _DataBaseName As String = "CompanyDatabase"
        Dim _YearConn = _GetServerConnection(_DataBaseName)
        PymtFoloconn = New SqlConnection(_YearConn)
        PymtFoloconn.Open()

    End Sub
    Public Sub PaymentFolo_QueryLoad()

        Try
            DefaltSoftTable.Reset()
            PymtFoConn()
            cmd = New SqlClient.SqlCommand(sqL, PymtFoloconn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 420
            Dim Defalt_ADP As New SqlDataAdapter(cmd)

            Defalt_ADP.Fill(DefaltSoftTable)
            cmd.Dispose()
            PymtFoloconn.Close()
        Catch ex As Exception
            MsgBox(sqL + ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub PaymentFolo_QuerySaveUpdateDelete()

        Try
            DefaltSoftTable.Reset()
            PymtFoConn()
            cmd = New SqlClient.SqlCommand(sqL, PymtFoloconn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 420
            Dim Defalt_ADP As New SqlDataAdapter(cmd)
            Defalt_ADP.Fill(DefaltSoftTable)
            cmd.Dispose()
            PymtFoloconn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try


        'Try
        '    PymtFoConn()
        '    MSA_CMD = New OleDb.OleDbCommand(RS, PaymentFolo)
        '    MSA_CMD.ExecuteNonQuery()
        '    MSA_CMD.Dispose()
        '    PaymentFolo.Close()
        '    Dim Err As String = ""
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Database Error")
        '    Dim Err As String = ""
        '    Err = ex.ToString
        'Finally

        '    If PaymentFolo.State = ConnectionState.Open Then
        '        PaymentFolo.Close()
        '    End If
        'End Try
    End Sub
#End Region

    Public Sub DB_PRINTING()
        Try
            Dim Print_Path As String = My.Application.Info.DirectoryPath
            Printing_CONN.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Print_Path & "\Reports" & "\Printing.mdb;"
            Printing_CONN.Open()
        Catch
        End Try
    End Sub

    Public Sub ConnDB()
        Try

            SqlServerConnectionString = Main_MDI_Frm.TextBox1.Text

            'datapath = " Database=Accounts2_12122023123533;Server=62.138.14.242;user=sa;password=1234"
            conn = New SqlConnection(SqlServerConnectionString)
            'conn = New SqlConnection("Data Source=MAHAVEER\SQLEXPRESS;Initial Catalog=Accounts2;Integrated Security=True")
            'conn = New SqlConnection("Data Source= datapath;database=Accounts;Integrated Security=True")
            conn.Open()



        Catch
            MsgBox("Please configure database.", MsgBoxStyle.Information, "Database")
        End Try
    End Sub

    Public Sub SQLDBMENU_CONNECT()
        Try
            DefaltSoftTable.Reset()
            DB_CONNECT()

            MSA_CMD = New OleDb.OleDbCommand(RS, MSA_CONN)
            MSA_CMD.CommandType = CommandType.Text
            Dim ADP As New OleDb.OleDbDataAdapter(MSA_CMD)
            Dim TAB As New DataTable
            ADP.Fill(DefaltSoftTable)
            MSA_CMD.Dispose()
            MSA_CONN.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub SQLDBMENU_Save_Delete_Update()
        Try
            DB_CONNECT()
            MSA_CMD = New OleDb.OleDbCommand(RS, MSA_CONN)
            MSA_CMD.ExecuteNonQuery()
            MSA_CMD.Dispose()
            MSA_CONN.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Function sql_connect_slect()
        Try
            DefaltSoftTable.Reset()
            ConnDB()
            cmd = New SqlClient.SqlCommand(sqL, conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 420
            Dim Defalt_ADP As New SqlDataAdapter(cmd)

            Defalt_ADP.Fill(DefaltSoftTable)
            cmd.Dispose()
            conn.Close()
            Return DefaltSoftTable
        Catch ex As Exception
            MsgBox(sqL + ex.ToString)
        Finally
        End Try
    End Function
    Public Function sql_Data_Save_Delete_Update()

        Dim _GetError As Boolean = False
        Try

            ConnDB()
            cmd = New SqlClient.SqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()

        Catch ex As Exception
            MsgBox(sqL.ToString)
            _GetError = True
        Finally
        End Try
        Return _GetError
    End Function

    Public Sub sql_Data_Save_Delete_Update_NewYearConnection()
        Try


            NewYearConnection.Open()
            cmd = New SqlClient.SqlCommand(sqL, NewYearConnection)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            NewYearConnection.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    Public Sub sql_Data_Select_NewYearConnection()
        Try
            DefaltSoftTable.Reset()
            ConnDB()
            cmd = New SqlClient.SqlCommand(sqL, NewYearConnection)
            cmd.CommandType = CommandType.Text
            cmd.CommandTimeout = 420
            Dim Defalt_ADP As New SqlDataAdapter(cmd)
            Defalt_ADP.Fill(DefaltSoftTable)
            cmd.Dispose()
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

End Module

