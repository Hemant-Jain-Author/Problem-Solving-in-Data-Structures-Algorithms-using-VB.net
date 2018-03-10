Imports System
Imports System.Collections.Generic

Public Class HashSetDemo
	Public Shared Sub Main99(ByVal args() As String)
		' Create a hash set.
		Dim hs As New HashSet(Of String)()

		' Add elements to the hash set.
		hs.Add("India")
		hs.Add("USA")
		hs.Add("Brazile")
		hs.Add("Canada")
		hs.Add("UK")
		hs.Add("China")
		hs.Add("France")
		hs.Add("Spain")
		hs.Add("Italy")

		For Each str As String In hs
			Console.Write(str)
		Next str

		Console.WriteLine("Hash Table contains USA : " & hs.Contains("USA"))
		Console.WriteLine("Hash Table contains Russia : " & hs.Contains("Russia"))

		hs.Remove("USA")
		For Each str As String In hs
			Console.Write(str)
		Next str
		Console.WriteLine("Hash Table contains USA : " & hs.Contains("USA"))
	End Sub
End Class