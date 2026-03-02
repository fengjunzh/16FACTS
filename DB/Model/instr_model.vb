Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'instr_model
<Serializable()>
Public Class instr_model
Private _id As Integer
Private _name As String
Private _model_num As String
Private _start_freq As Decimal
Private _stop_freq As Decimal
Private _type As String
Private _instr_vendor_id As Integer

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
    Public Property name() As String
       Get
           Return _name
       End Get
       Set(value As String)
          _name = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property model_num() As String
       Get
           Return _model_num
       End Get
       Set(value As String)
          _model_num = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property start_freq() As Decimal
       Get
           Return _start_freq
       End Get
       Set(value As Decimal)
          _start_freq = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property stop_freq() As Decimal
       Get
           Return _stop_freq
       End Get
       Set(value As Decimal)
          _stop_freq = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property type() As String
       Get
           Return _type
       End Get
       Set(value As String)
          _type = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property instr_vendor_id() As Integer
       Get
           Return _instr_vendor_id
       End Get
       Set(value As Integer)
          _instr_vendor_id = value
       End Set
    End Property
End Class
