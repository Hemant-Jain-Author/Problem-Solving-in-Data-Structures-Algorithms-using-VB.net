Imports System
Imports System.Collections.Generic

Public Class SortedListDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a Sorted List.
		Dim tm As New SortedList(Of String, Integer)()

		' Put elements into Sorted List
		tm("Apple") = 40
		tm("Mango") = 20
		tm("Banana") = 10

		Console.WriteLine("Size :: " & tm.Count)
		For Each key As String In tm.Keys
			Console.WriteLine(key & " cost :" & tm(key))
		Next key

		Console.WriteLine("Apple present :: " & tm.ContainsKey("Apple"))
		Console.WriteLine("Grapes present :: " & tm.ContainsKey("Grapes"))

		tm.Remove("Apple")
		Console.WriteLine("Apple present :: " & tm.ContainsKey("Apple"))
	End Sub
End Class
'
'Size :: 3
'Apple cost :40
'Banana cost :10
'Mango cost :20
'Apple present :: True
'Grapes present :: False
'Apple present :: False
'
