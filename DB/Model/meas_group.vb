Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'meas_group
<Serializable()>
Public Class meas_group
    Private _id As Integer
    Private _meas_phase_id As Integer
    Private _order_idx As Integer
    Private _group_main_id As Integer
    Private _group_status As String
    Private _test_idx As Integer
    Private _last_test_flag As Boolean
    Private _gen1 As String
    Private _gen2 As String
    Private _gen3 As String

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property meas_phase_id() As Integer
        Get
            Return _meas_phase_id
        End Get
        Set(value As Integer)
            _meas_phase_id = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property order_idx() As Integer
        Get
            Return _order_idx
        End Get
        Set(value As Integer)
            _order_idx = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property group_main_id() As Integer
        Get
            Return _group_main_id
        End Get
        Set(value As Integer)
            _group_main_id = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property group_status() As String
        Get
            Return _group_status
        End Get
        Set(value As String)
            _group_status = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property test_idx() As Integer
        Get
            Return _test_idx
        End Get
        Set(value As Integer)
            _test_idx = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property last_test_flag() As Boolean
        Get
            Return _last_test_flag
        End Get
        Set(value As Boolean)
            _last_test_flag = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property gen1() As String
        Get
            Return _gen1
        End Get
        Set(value As String)
            _gen1 = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property gen2() As String
        Get
            Return _gen2
        End Get
        Set(value As String)
            _gen2 = value
        End Set
    End Property

    ''' <summary>
    ''' id
    ''' </summary>
    Public Property gen3() As String
        Get
            Return _gen3
        End Get
        Set(value As String)
            _gen3 = value
        End Set
    End Property
End Class
