Public Class CATSFile
    Public Enum CATSFileEnum

        'CATSXmls
        CATSAppServerXmls
        CATSDbServerXmls
        CATSApplicationsXmls
        CATSEntryApplicationsXmls
        CATSUpdateExe
        MeExe
        MeExeLib
    End Enum
    Public Class CATSFilePath
        Private _TestApplicationDirectoryName As String = "test_application\" ' not used
        Private _TestEntryDirectoryName As String = "FACTSEntry\"
        Private _TestSystemDirectoryName As String = "test_system\"

        Private _ServerMainDirectory As String
        Private _ServerEntryDirectory As String
        Private _ServerApplicationDirectory As String
        Private _LocalMainDirectory As String = "C:\Andrew\"
        Private _LocalEntryDirectory As String = _LocalMainDirectory & _TestEntryDirectoryName
        Private _LocalApplicationDirectory As String = _LocalMainDirectory & _TestApplicationDirectoryName  'not used



        Private _CATSXmls As String = "FACTS.xmls"
        Private _CATSAppServerXmls As String = "FACTSAppServer.xmls"
        Private _CATSDbServerXmls As String = "FACTSDbServer.xmls"
        Private _CATSApplicationsXmls As String = "FACTSApplications.xmls"
        Private _CATSEntryApplicationsXmls As String = "FACTSEntryApplications.xmls"

        Private _CATSUpdateExe As String = "FACTSEntryUpdate.exe"
        Private _MeExe As String = My.Application.Info.ProductName & ".exe"
        Private _CATSXmlsFilePathSource As String = _LocalEntryDirectory
        Private _CATSXmlsFilePathDes As String = _LocalMainDirectory & _TestSystemDirectoryName
        Private _CATSXmlsFile As String = _CATSXmlsFilePathDes & _CATSXmls
        Private _CATSXmlsFileSource As String = _CATSXmlsFilePathSource & _CATSXmls
        Public Property ServerMainDirectory As String
            Get
                Return _ServerMainDirectory
            End Get
            Set(value As String)
                _ServerMainDirectory = IIf(value.EndsWith("\"), value, value + "\")
                _ServerMainDirectory = IIf(_ServerMainDirectory.StartsWith("\\"), _ServerMainDirectory, "\\" + _ServerMainDirectory)
                _ServerEntryDirectory = _ServerMainDirectory & _TestEntryDirectoryName
                _ServerApplicationDirectory = _ServerMainDirectory & _TestApplicationDirectoryName
            End Set
        End Property
        Public ReadOnly Property ServerEntryDirectory As String
            Get
                Return _ServerEntryDirectory
            End Get
        End Property
        Public ReadOnly Property ServerApplicationDirectory As String
            Get
                Return _ServerApplicationDirectory
            End Get
        End Property
        Public ReadOnly Property LocalMainDirectory As String
            Get
                Return _LocalMainDirectory
            End Get
        End Property
        Public ReadOnly Property LocalEntryDirectory As String
            Get
                Return _LocalEntryDirectory
            End Get
        End Property
        Public ReadOnly Property LocalApplicationDirectory As String
            Get
                Return _LocalApplicationDirectory
            End Get
        End Property
        Public ReadOnly Property CATSXmls As String
            Get
                Return _CATSXmls
            End Get
            'Set(value As String)
            '	_CATSXmls = value
            'End Set
        End Property
        Public ReadOnly Property CATSXmlsFilePathSource As String
            Get
                Return _CATSXmlsFilePathSource
            End Get
        End Property
        Public ReadOnly Property CATSXmlsFilePathDes As String
            Get
                Return _CATSXmlsFilePathDes
            End Get
        End Property
        Public ReadOnly Property CATSXmlsFile As String
            Get
                Return _CATSXmlsFile
            End Get
        End Property
        Public ReadOnly Property CATSXmlsFileSource As String
            Get
                Return _CATSXmlsFileSource
            End Get
        End Property
        Public ReadOnly Property CATSAppServerXmls As String
            Get
                Return _CATSAppServerXmls
            End Get
            'Set(value As String)
            '	_CATSAppServerXmls = value
            'End Set
        End Property
        Public ReadOnly Property CATSDbServerXmls As String
            Get
                Return _CATSDbServerXmls
            End Get
            'Set(value As String)
            '	_CATSDbServerXmls = value
            'End Set
        End Property
        Public ReadOnly Property CATSApplicationsXmls As String
            Get
                Return _CATSApplicationsXmls
            End Get
            'Set(value As String)
            '	_CATSApplicationsXmls = value
            'End Set
        End Property
        Public ReadOnly Property CATSEntryApplicationsXmls As String
            Get
                Return _CATSEntryApplicationsXmls
            End Get
            'Set(value As String)
            '	_CATSEntryApplicationsXmls = value
            'End Set
        End Property
        Public ReadOnly Property CATSUpdateExe As String
            Get
                Return _CATSUpdateExe
            End Get
        End Property
        Public ReadOnly Property MeExe As String
            Get
                Return _MeExe
            End Get
        End Property
    End Class
End Class
