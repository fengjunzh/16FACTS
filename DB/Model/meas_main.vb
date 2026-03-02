Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'meas_main
<Serializable()>
Public Class meas_main
Private _id As Integer
Private _product_sn_id As Integer
Private _product_mode_id As Integer
Private _mode As String
Private _start_datetime As DateTime
Private _stop_datetime As DateTime
Private _duration_minute As Integer
Private _meas_status As String
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
    Public Property product_sn_id() As Integer
       Get
           Return _product_sn_id
       End Get
       Set(value As Integer)
          _product_sn_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property product_mode_id() As Integer
       Get
           Return _product_mode_id
       End Get
       Set(value As Integer)
          _product_mode_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property mode() As String
       Get
           Return _mode
       End Get
       Set(value As String)
          _mode = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property start_datetime() As DateTime
       Get
           Return _start_datetime
       End Get
       Set(value As DateTime)
          _start_datetime = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property stop_datetime() As DateTime
       Get
           Return _stop_datetime
       End Get
       Set(value As DateTime)
          _stop_datetime = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property duration_minute() As Integer
       Get
           Return _duration_minute
       End Get
       Set(value As Integer)
          _duration_minute = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property meas_status() As String
       Get
           Return _meas_status
       End Get
       Set(value As String)
          _meas_status = value
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
