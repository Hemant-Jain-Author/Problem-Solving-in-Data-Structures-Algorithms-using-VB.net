﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Friend Class StackDemo
	Public Shared Sub Main44(ByVal args() As String)
		Dim stk As New Stack(Of Integer)()
		stk.Push(1)
		stk.Push(2)
		stk.Push(3)
		stk.Push(4)
		stk.Push(5)
		stk.Push(6)

		Console.WriteLine("Element at top of stack ::" & stk.Peek())
		Dim size As Integer = stk.Count
		For i As Integer = 0 To size - 1
			Console.WriteLine("Pop from stack: " & stk.Pop())
		Next i
	End Sub
End Class
