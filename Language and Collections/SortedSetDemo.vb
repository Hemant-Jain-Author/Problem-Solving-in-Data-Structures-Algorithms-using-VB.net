Imports System
Imports System.Collections.Generic

Public Class SortedSetDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a tree set.
		Dim ts As New SortedSet(Of String)()
		' Add elements to the hash set.
		ts.Add("Banana")
		ts.Add("Apple")
		ts.Add("Mango")
		For Each ele In ts
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()

		Console.WriteLine("Apple present : " & ts.Contains("Apple"))
		Console.WriteLine("Grapes present : " & ts.Contains("Grapes"))
		ts.Remove("Apple")
		Console.WriteLine("Apple present : " & ts.Contains("Apple"))
	End Sub
End Class

'
'Apple Banana Mango 
'Apple present : True
'Grapes present : False
'Apple present : False
'