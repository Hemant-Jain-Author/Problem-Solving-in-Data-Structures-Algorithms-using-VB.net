Imports System
Imports System.Collections.Generic

Public Class CountMap(Of T)
	Friend hm As New Dictionary(Of T, Integer)()

	Public Sub Add(ByVal key As T)
		If hm.ContainsKey(key) Then
			hm(key) = hm(key) + 1
		Else
			hm(key) = 1
		End If
	End Sub

	Public Sub Remove(ByVal key As T)
		If hm.ContainsKey(key) Then
			If hm(key) = 1 Then
				hm.Remove(key)
			Else
				hm(key) = hm(key) - 1
			End If
		End If
	End Sub

	Public Function [Get](ByVal key As T) As Integer
		If hm.ContainsKey(key) Then
			Return hm(key)
		End If
		Return 0
	End Function

	Public Function ContainsKey(ByVal key As T) As Boolean
		Return hm.ContainsKey(key)
	End Function

	Public Function size() As Integer
		Return hm.Count
	End Function
End Class
Friend Class countMapDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim cm As New CountMap(Of Integer)()
		cm.Add(2)
		cm.Add(2)
		Console.WriteLine("count is : " & cm.Get(2))
		cm.Remove(2)
		Console.WriteLine("count is : " & cm.Get(2))
		cm.Remove(2)
		Console.WriteLine("count is : " & cm.Get(2))
	End Sub
End Class
