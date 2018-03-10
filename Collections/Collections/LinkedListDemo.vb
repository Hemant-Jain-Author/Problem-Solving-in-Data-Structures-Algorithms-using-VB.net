Imports System
Imports System.Collections.Generic

Public Class LinkedListDemo
	Public Shared Sub Main66(ByVal args() As String)
		Dim ll As New LinkedList(Of Integer)()
		ll.AddFirst(10)
		ll.AddLast(20)
		ll.AddFirst(9)
		ll.AddLast(21)
		ll.AddFirst(8)
		ll.AddLast(22)

		Console.Write("Contents of Linked List: ")
		For Each val As Integer In ll
			Console.Write(val & " ")
		Next val

		ll.RemoveFirst()
		ll.RemoveLast()

		Console.Write(ControlChars.Lf & "Contents of Linked List: ")
		For Each val As Integer In ll
			Console.Write(val & " ")
		Next val
	End Sub
End Class