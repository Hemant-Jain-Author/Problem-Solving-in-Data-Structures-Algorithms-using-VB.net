Imports System
Imports System.Collections.Generic
Public Class LinkedListDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New LinkedList(Of Integer)()
		ll.AddFirst(1)
		ll.AddLast(3)
		ll.AddFirst(2)
		ll.AddLast(4)
		Console.Write("Linked List: ")
		For Each ele In ll
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()
		ll.RemoveFirst()
		ll.RemoveLast()
		Console.Write("Linked List: ")
		For Each ele In ll
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()
	End Sub
End Class

' 
'Linked List: 2 1 3 4 
'Linked List: 1 3 
'