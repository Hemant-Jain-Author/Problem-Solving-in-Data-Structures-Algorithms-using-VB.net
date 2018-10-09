Imports System
Imports System.Collections.Generic

Public Class HashSetDemo
	Public Shared Sub Main(ByVal args() As String)
		' Create a hash set.
		Dim hs As New HashSet(Of String)()

		' Add elements to the hash set.
		hs.Add("India")
		hs.Add("USA")
		hs.Add("Brazil")
		hs.Add("Canada")
		For Each str As String In hs
			Console.Write(str)
		Next str

		Console.WriteLine("Hash Table contains USA : " & hs.Contains("USA"))
		Console.WriteLine("Hash Table contains Russia:" & hs.Contains("Russia"))
		hs.Remove("USA")
		Console.WriteLine("Hash Table contains USA : " & hs.Contains("USA"))
	End Sub
End Class
