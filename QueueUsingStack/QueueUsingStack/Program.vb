Imports System
Imports System.Collections.Generic

Public Class QueueUsingStack
	Public Sub New()
		stk1 = New Stack(Of Integer)()
		stk2 = New Stack(Of Integer)()
	End Sub
	Private stk1 As Stack(Of Integer)
	Private stk2 As Stack(Of Integer)
	' Other methods.
End Class


Public Sub add(ByVal value As Integer)
	stk1.Push(value)
End Sub

Public Function remove() As Integer
	Dim value As Integer
	If stk2.Count <> 0 Then
		Return stk2.Pop()
	End If

	Do While stk1.Count <> 0
		value = stk1.Pop()
		stk2.Push(value)
	Loop
	Return stk2.Pop()
End Function

Public Shared Sub Main(ByVal args() As String)
	Dim que As New QueueUsingStack()
	que.add(1)
	que.add(11)
	que.add(111)
	Console.WriteLine(que.remove())
	que.add(2)
	que.add(21)
	que.add(211)
	Console.WriteLine(que.remove())
	Console.WriteLine(que.remove())
	Console.WriteLine(que.remove())
	Console.WriteLine(que.remove())
	Console.WriteLine(que.remove())
End Sub
End Class