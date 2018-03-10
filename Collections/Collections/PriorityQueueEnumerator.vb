'Imports System
'Imports System.Collections
'Imports System.Collections.Generic

'Friend Class PriorityQueueEnumerator(Of T As IComparable(Of T))
'    Implements IEnumerator(Of T)

'    Private priorityQueue As PriorityQueue(Of T)
'	Private index As Integer
''INSTANT VB NOTE: The field current was renamed since Visual Basic does not allow fields to have the same name as methods:
'	Private current_Renamed As T

'	Public Sub New(ByVal pq As PriorityQueue(Of T))
'		Me.priorityQueue = pq
'		current_Renamed = Nothing
'		index = 1
'	End Sub

'	Public ReadOnly Property Current() As T Implements IEnumerator(Of T).Current
'		Get
'			Return current_Renamed
'		End Get
'	End Property

'	Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
'		Get
'			Return Me.Current
'		End Get
'	End Property

'    Public Sub Dispose() Implements System.IDisposable(Of T).Dispose
'        priorityQueue = Nothing
'        current_Renamed = Nothing
'        index = 1
'    End Sub

'    Public Function MoveNext() As Boolean Implements IEnumerator(Of T).MoveNext
'		If index <= priorityQueue.Count Then
'			current_Renamed = priorityQueue.CurrIndex(index)
'			index += 1
'			Return True
'		End If
'		Return False
'	End Function

'	Public Sub Reset() Implements IEnumerator(Of T).Reset
'		current_Renamed = Nothing
'		index = 1
'	End Sub
'End Class