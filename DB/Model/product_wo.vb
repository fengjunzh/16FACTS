Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'product_wo
<Serializable()>
Public Class product_wo
Private _id As Integer
Private _product_main_id As Integer
Private _wo_descr As String
Private _validity As Boolean
Private _validation As Boolean
Private _wo_status As Integer
Private _register_date As DateTime
Private _employee_id As Integer
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
    Public Property product_main_id() As Integer
       Get
           Return _product_main_id
       End Get
       Set(value As Integer)
          _product_main_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property wo_descr() As String
       Get
           Return _wo_descr
       End Get
       Set(value As String)
          _wo_descr = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property validity() As Boolean
       Get
           Return _validity
       End Get
       Set(value As Boolean)
          _validity = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property validation() As Boolean
       Get
           Return _validation
       End Get
       Set(value As Boolean)
          _validation = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property wo_status() As Integer
       Get
           Return _wo_status
       End Get
       Set(value As Integer)
          _wo_status = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property register_date() As DateTime
       Get
           Return _register_date
       End Get
       Set(value As DateTime)
          _register_date = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property employee_id() As Integer
       Get
           Return _employee_id
       End Get
       Set(value As Integer)
          _employee_id = value
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
