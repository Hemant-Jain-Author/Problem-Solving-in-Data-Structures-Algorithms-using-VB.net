Imports System
Imports System.Collections.Generic

Friend Class SortedSetDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a Sorted set.
		Dim ts As New SortedSet(Of String)()
		' Add elements to the Sorted set.
		ts.Add("India")
		ts.Add("USA")
		ts.Add("Brazil")
		ts.Add("Canada")

		For Each str As String In ts
			Console.Write(str & " ")
		Next str
	End Sub
End Class
