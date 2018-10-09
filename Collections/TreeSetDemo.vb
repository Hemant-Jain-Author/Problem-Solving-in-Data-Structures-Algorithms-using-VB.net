Imports System
Imports System.Collections.Generic

Public Class TreeSetDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a tree set.
		Dim ts As New SortedSet(Of String)()
		' Add elements to the tree set.
		ts.Add("India")
		ts.Add("USA")
		ts.Add("Brazile")
		ts.Add("Canada")
		ts.Add("UK")
		ts.Add("China")
		ts.Add("France")
		ts.Add("Spain")
		ts.Add("Italy")

		For Each str As String In ts
			Console.WriteLine(str)
		Next str


	End Sub
End Class