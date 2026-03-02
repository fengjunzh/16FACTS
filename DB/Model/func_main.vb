Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'func_main
<Serializable()>
Public Class func_main
Private _id As Integer
Private _name As String
Private _descr As String
Private _permission As Boolean

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
    Public Property descr() As String
       Get
           Return _descr
       End Get
       Set(value As String)
          _descr = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property permission() As Boolean
       Get
           Return _permission
       End Get
       Set(value As Boolean)
          _permission = value
       End Set
    End Property
End Class
