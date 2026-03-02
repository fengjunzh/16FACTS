Public Class cq_test_data
    Private _group_main_id As Integer
    Private _group_status As String
    Private _meas_group_id As Integer
    Private _spec_detail_id As Integer
    Private _meas_high_value As Double
    Private _meas_string As String
    Private _meas_low_value As Double
    Private _meas_detail_status As String
    Private _meas_data_x1 As String
    Private _meas_data_y1 As String
    Private _spara As String
    Private _trace_name As String

    Public Property Group_main_id As Integer
        Get
            Return _group_main_id
        End Get
        Set(value As Integer)
            _group_main_id = value
        End Set
    End Property

    Public Property Group_status As String
        Get
            Return _group_status
        End Get
        Set(value As String)
            _group_status = value
        End Set
    End Property

    Public Property Meas_group_id As Integer
        Get
            Return _meas_group_id
        End Get
        Set(value As Integer)
            _meas_group_id = value
        End Set
    End Property

    Public Property Spec_detail_id As Integer
        Get
            Return _spec_detail_id
        End Get
        Set(value As Integer)
            _spec_detail_id = value
        End Set
    End Property

    Public Property Meas_high_value As Double
        Get
            Return _meas_high_value
        End Get
        Set(value As Double)
            _meas_high_value = value
        End Set
    End Property

    Public Property Meas_string As String
        Get
            Return _meas_string
        End Get
        Set(value As String)
            _meas_string = value
        End Set
    End Property

    Public Property Meas_low_value As Double
        Get
            Return _meas_low_value
        End Get
        Set(value As Double)
            _meas_low_value = value
        End Set
    End Property

    Public Property Meas_detail_status As String
        Get
            Return _meas_detail_status
        End Get
        Set(value As String)
            _meas_detail_status = value
        End Set
    End Property

    Public Property Meas_data_x1 As String
        Get
            Return _meas_data_x1
        End Get
        Set(value As String)
            _meas_data_x1 = value
        End Set
    End Property

    Public Property Meas_data_y1 As String
        Get
            Return _meas_data_y1
        End Get
        Set(value As String)
            _meas_data_y1 = value
        End Set
    End Property

    Public Property Spara As String
        Get
            Return _spara
        End Get
        Set(value As String)
            _spara = value
        End Set
    End Property

    Public Property Trace_name As String
        Get
            Return _trace_name
        End Get
        Set(value As String)
            _trace_name = value
        End Set
    End Property
End Class
