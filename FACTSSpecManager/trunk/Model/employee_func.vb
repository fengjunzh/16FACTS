Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'employee_func
<Serializable()>
Public Class employee_func
Private _id As Integer
Private _employee_id As Integer
Private _func_main_id As Integer

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
    Public Property func_main_id() As Integer
       Get
           Return _func_main_id
       End Get
       Set(value As Integer)
          _func_main_id = value
       End Set
    End Property
End Class
