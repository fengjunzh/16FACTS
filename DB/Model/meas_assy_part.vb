Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'meas_assy_part
<Serializable()>
Public Class meas_assy_part
Private _id As Integer
Private _meas_phase_id As Integer
Private _part_model As String
Private _part_sn As String
Private _part_idx As Integer
Private _part_hw As String
Private _part_fw As String
Private _part_tilt_min As Decimal
Private _part_tilt_max As Decimal
Private _part_desc As String
Private _part_type As String

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
    Public Property part_model() As String
       Get
           Return _part_model
       End Get
       Set(value As String)
          _part_model = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_sn() As String
       Get
           Return _part_sn
       End Get
       Set(value As String)
          _part_sn = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_idx() As Integer
       Get
           Return _part_idx
       End Get
       Set(value As Integer)
          _part_idx = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_hw() As String
       Get
           Return _part_hw
       End Get
       Set(value As String)
          _part_hw = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_fw() As String
       Get
           Return _part_fw
       End Get
       Set(value As String)
          _part_fw = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_tilt_min() As Decimal
       Get
           Return _part_tilt_min
       End Get
       Set(value As Decimal)
          _part_tilt_min = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_tilt_max() As Decimal
       Get
           Return _part_tilt_max
       End Get
       Set(value As Decimal)
          _part_tilt_max = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_desc() As String
       Get
           Return _part_desc
       End Get
       Set(value As String)
          _part_desc = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property part_type() As String
       Get
           Return _part_type
       End Get
       Set(value As String)
          _part_type = value
       End Set
    End Property
End Class
