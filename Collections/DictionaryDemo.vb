Imports System
Imports System.Collections.Generic

Module Module1
	Public Sub Main(ByVal args() As String)
		' Create a Dictionary or map.
		Dim hm As New Dictionary(Of String, Integer)()

		' Put elements into the Dictionary or map
		hm("William") = 99
		hm("Alexander") = 80
		hm("Michael") = 50
		hm("Emma") = 65

		Console.WriteLine("Total number of students in class :: " & hm.Count)
		For Each key As String In hm.Keys
			Console.WriteLine(key & " score marks :" & hm(key))
		Next key

		Console.WriteLine("Emma present in class :: " & hm.ContainsKey("Emma"))
		Console.WriteLine("John present in class :: " & hm.ContainsKey("John"))
	End Sub
End Module

