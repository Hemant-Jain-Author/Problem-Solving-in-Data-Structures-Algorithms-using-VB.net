Imports System
Imports System.Collections.Generic

Public Class QueueUsingStack

	Private stk1 As Stack(Of Integer)
	Private stk2 As Stack(Of Integer)

	Public Sub New()
		stk1 = New Stack(Of Integer)()
		stk2 = New Stack(Of Integer)()
	End Sub

	Friend Sub Add(ByVal value As Integer)
		stk1.Push(value)
	End Sub

	Friend Function Remove() As Integer
		Dim value As Integer
		If stk2.Count > 0 Then
			Return stk2.Pop()
		End If

		While stk1.Count > 0
			value = stk1.Pop()
			stk2.Push(value)
		End While
		Return stk2.Pop()
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim que As New QueueUsingStack()
		que.Add(1)
		que.Add(2)
		que.Add(3)
		For i As Integer = 0 To 2
			Console.WriteLine(que.Remove())
		Next i
	End Sub
End Class
'
'1
'2
'3
'