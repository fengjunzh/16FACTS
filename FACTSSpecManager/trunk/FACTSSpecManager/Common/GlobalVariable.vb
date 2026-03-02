Module GlobalVariable
    Public Enum emUserLevel
        NULL_USER
        ADMIN_USER
        F_CUSTOMER_USER
        F_MODE_USER 'Foundation -> Mode
        F_PHASE_USER 'Foundation -> Phase
        M_PROD_USER  'Manager -> Product
        M_MODE_USER 'Manager -> Mode
        M_SPEC_ADMIN_USER 'Manager -> All Specifications
        M_SPEC_PIM_USER 'Manager -> Specification Pim
        M_SPEC_SPARA_USER 'Manager -> Specification RL/ISO
        SN_USER 'Manager -> Sn
        WEB_ADMIN
        WEB_EXCEL_DOWNLOAD
    End Enum
    Public Enum EmMode
        NA = 0
        PROD = 1
        NPI = 2
        RD = 3
        REL = 4
        DOE = 5
        RETEST = 6
        PTP = 7
        SAMPLE = 8
    End Enum
    Public Enum Family
        NA = 0
        MM = 1 'Mulit Mode
        SM = 2 'Single Mode
    End Enum

    Public pExcelSavePath As String = "C:\CATS\CATSConsole\"
    Public pUserLevelList As List(Of emUserLevel)
    Public pOneState As Boolean
    Public pFamily As Family
    Public pActivedDb As ComboxItem
    Public Const gLightSpeed As Decimal = 299792458
    Public Const gInputCableVelocity = 0.3492
    Public gMyApplicationCaption = "FACTS Spec Manager(version " & Application.ProductVersion & ")"

End Module
