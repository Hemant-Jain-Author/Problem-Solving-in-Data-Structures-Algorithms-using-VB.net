Imports System
Imports System.Collections.Generic

Public Class ArrayListDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New List(Of Integer)()
		ll.Add(1) ' Add 1 to the end of the list.
		ll.Add(2) ' Add 2 to the end of the list.
		ll.Add(3) ' Add 3 to the end of the list.

		Console.Write("Contents of List: ")
		Dim ele As Integer
		For Each ele In ll
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()

		Console.WriteLine("List Size : " & ll.Count)
		Console.WriteLine("List IsEmpty : " & (ll.Count = 0))
		ll.RemoveAt(ll.Count - 1) ' Last element of list is removed.
		ll.Clear() ' lll the elements of list are removed.
		Console.WriteLine("List IsEmpty : " & (ll.Count = 0))
	End Sub
End Class

'
'Contents of List : 1 2 3
'List Size : 3
'List IsEmpty : False
'List IsEmpty : True
'
