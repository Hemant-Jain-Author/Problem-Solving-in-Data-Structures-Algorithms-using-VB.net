Imports System
Imports System.Collections.Generic

Public Class StackDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim stack As New Stack(Of Integer)()
		stack.Push(1)
		stack.Push(2)
		stack.Push(3)
		Console.WriteLine("Stack size : " & stack.Count)
		Console.Write("Stack : ")
		Dim ele As Integer
		For Each ele In stack
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()

		Console.WriteLine("Stack pop : " & stack.Pop())
		Console.WriteLine("Stack top : " & stack.Peek())
		Console.WriteLine("Stack isEmpty : " & (stack.Count = 0))
	End Sub
End Class

' 
'Stack size : 3
'Stack : 3 2 1 
'Stack pop : 3
'Stack top : 2
'Stack isEmpty : False
'