Imports System
Imports System.Collections.Generic

Public Class HashSetDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a hash set.
		Dim hs As New HashSet(Of String)()
		' Add elements to the hash set.
		hs.Add("Banana")
		hs.Add("Apple")
		hs.Add("Mango")
		For Each ele In hs
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()

		Console.WriteLine("Apple present : " & hs.Contains("Apple"))
		Console.WriteLine("Grapes present : " & hs.Contains("Grapes"))
		hs.Remove("Apple")
		Console.WriteLine("Apple present : " & hs.Contains("Apple"))
		hs.ForEach(Console.Write)
		For Each ele In hs
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()
	End Sub
End Class

'
'Banana Apple Mango 
'Apple present : True
'Grapes present : False
'Apple present : False
'Banana Mango 
'