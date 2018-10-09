Imports System
Imports System.Collections.Generic

Public Class SortedDictionaryDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a Sorted Dictionary.
		Dim tm As New SortedDictionary(Of String, Integer)()

		' Put elements into Sorted Dictionary
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
End Class
