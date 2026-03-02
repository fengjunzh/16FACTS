Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'customer
<Serializable()>
Public Class customer
Private _id As Integer
Private _cust_name As String
Private _cust_desc As String
Private _validity As Boolean

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
    Public Property cust_name() As String
       Get
           Return _cust_name
       End Get
       Set(value As String)
          _cust_name = value
       End Set
    End Property

''' <summary>
''' id
''' </summary>
    Public Property cust_desc() As String
       Get
           Return _cust_desc
       End Get
       Set(value As String)
          _cust_desc = value
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

  Public Overrides Function ToString() As String
    Return _cust_name
  End Function
End Class
