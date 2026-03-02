Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'instr_main
<Serializable()>
Public Class instr_main
  Private _id As Integer
  Private _instr_model_id As Integer
  Private _serial_num As String
  Private _instr_num As String
  Private _fw_version As String
  Private _hw_version As String
  Private _entry_date As DateTime
  Private _location As String
  Private _status As String
  Private _employee_id As Integer
  Private _instr_idn As String

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
  Public Property instr_model_id() As Integer
    Get
      Return _instr_model_id
    End Get
    Set(value As Integer)
      _instr_model_id = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property serial_num() As String
    Get
      Return _serial_num
    End Get
    Set(value As String)
      _serial_num = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property instr_num() As String
    Get
      Return _instr_num
    End Get
    Set(value As String)
      _instr_num = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property fw_version() As String
    Get
      Return _fw_version
    End Get
    Set(value As String)
      _fw_version = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property hw_version() As String
    Get
      Return _hw_version
    End Get
    Set(value As String)
      _hw_version = value
    End Set
  End Property

  ''' <summary>
  ''' id
  ''' </summary>
  Public Property entry_date() As DateTime
    Get
      Return _entry_date
    End Get
    Set(value As DateTime)
      _entry_date = value
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
  Public Property status() As String
    Get
      Return _status
    End Get
    Set(value As String)
      _status = value
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
  Public Property instr_idn() As String
    Get
      Return _instr_idn
    End Get
    Set(value As String)
      _instr_idn = value
    End Set
  End Property
End Class
