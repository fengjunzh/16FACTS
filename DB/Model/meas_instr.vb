Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Generic

'meas_instr
<Serializable()>
Public Class meas_instr
Private _meas_phase_id As Integer
Private _instr_main_id As Integer
  'Private _instr_idn As String
  Private _gen1 As String
Private _gen2 As String
Private _gen3 As String

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
    Public Property instr_main_id() As Integer
       Get
           Return _instr_main_id
       End Get
       Set(value As Integer)
          _instr_main_id = value
       End Set
    End Property

  '''' <summary>
  '''' id
  '''' </summary>
  '    Public Property instr_idn() As String
  '       Get
  '           Return _instr_idn
  '       End Get
  '       Set(value As String)
  '          _instr_idn = value
  '       End Set
  '    End Property

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
