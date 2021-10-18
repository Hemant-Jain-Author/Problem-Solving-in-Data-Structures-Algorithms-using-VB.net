Imports System
Imports System.Collections.Generic

'
'A Dictionary is an object that stores associations between keys and values, or key/value pairs.
'Both keys and values are objects. The keys must be unique, but the values may be duplicated.
'

Public Class DictionaryDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a dictionary.
		Dim hm As New Dictionary(Of String, Integer)()

		' Add elements into the dictionary.
		hm("Apple") = 40
		hm("Banana") = 10
		hm("Mango") = 20

		Console.WriteLine("Size :: " & hm.Count)
		For Each key As String In hm.Keys
			Console.WriteLine(key & " cost :" & hm(key))
		Next key

		Console.WriteLine("Apple present ::" & hm.ContainsKey("Apple"))
		Console.WriteLine("Grapes present :: " & hm.ContainsKey("Grapes"))
	End Sub
End Class

'
'Size :: 3
'Apple cost :40
'Banana cost :10
'Mango cost :20
'Apple present ::True
'Grapes present :: False
'