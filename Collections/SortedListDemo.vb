Imports System
Imports System.Collections.Generic

Module Module1
	Public Sub Main(ByVal args() As String)
		' Create a Sorted List.
		Dim tm As New SortedList(Of String, Integer)()

		' Put elements into Sorted List
		tm("William") = 99
		tm("Alexander") = 80
		tm("Michael") = 50
		tm("Emma") = 65

		Console.WriteLine("Total number of students in class :: " & tm.Count)
		For Each key As String In tm.Keys
			Console.WriteLine(key & " score marks :" & tm(key))
		Next key

		Console.WriteLine("Emma present in class :: " & tm.ContainsKey("Emma"))
		Console.WriteLine("John present in class :: " & tm.ContainsKey("John"))

		tm.Remove("Emma")
		Console.WriteLine("Emma present in class :: " & tm.ContainsKey("Emma"))
	End Sub
End Module

'
'Total number of students in class :: 4
'Alexander score marks :80
'Emma score marks :65
'Michael score marks :50
'William score marks :99
'Emma present in class :: True
'John present in class :: False
'Emma present in class :: False
'
