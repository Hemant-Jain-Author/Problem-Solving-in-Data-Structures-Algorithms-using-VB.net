Imports System
Imports System.Collections.Generic
Public Class Stack
	Private que1 As New Queue(Of Integer)()
	Private que2 As New Queue(Of Integer)()
	Private size As Integer = 0

	Public Sub Push(ByVal value As Integer)
		que1.Enqueue(value)
		size += 1
	End Sub

	Public Function Pop() As Integer
		Dim value As Integer = 0, s As Integer = size
		Do While s > 0
			value = que1.Peek()
			que1.Dequeue()
			If s > 1 Then
				que2.Enqueue(value)
			End If
			s -= 1
		Loop
		Dim temp As Queue(Of Integer) = que1
		que1 = que2
		que2 = temp
		size -= 1
		Return value
	End Function

	Public Sub Push2(ByVal value As Integer)
		que1.Enqueue(value)
		size += 1
	End Sub

	Public Function Pop2() As Integer
		Dim value As Integer = 0, s As Integer = size
		Do While s > 0
			value = que1.Peek()
			que1.Dequeue()
			If s > 1 Then
				que1.Enqueue(value)
			End If
			s -= 1
		Loop
		size -= 1
		Return value
	End Function



	Public Shared Sub Main(ByVal args() As String)
		Dim s As New Stack()
		For i As Integer = 0 To 4
			s.Push(i)
		Next i
		For i As Integer = 0 To 4
			Console.Write(s.Pop() & " ")
		Next i
	End Sub
End Class
