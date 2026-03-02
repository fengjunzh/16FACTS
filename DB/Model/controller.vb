Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'controller
<Serializable()>
Public Class controller
Private _id As Integer
Private _name As String
Private _location As String
Private _owner_id As Integer
Private _factory_id As Integer
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
    Public Property location() As String
       Get
           Return _location
       End Get
       Set(value As String)
          _location = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property owner_id() As Integer
       Get
           Return _owner_id
       End Get
       Set(value As Integer)
          _owner_id = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property factory_id() As Integer
       Get
           Return _factory_id
       End Get
       Set(value As Integer)
          _factory_id = value
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
