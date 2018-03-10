Imports System
Imports System.Collections.Generic

Public Class CountMap(Of T)
	Friend hm As New Dictionary(Of T, Integer)()


	Public Sub add(ByVal key As T)
		If hm.ContainsKey(key) Then
			Dim count As Integer = hm(key)
			hm(key) = count + 1
		Else
			hm(key) = 1
		End If
	End Sub

	Public Sub remove(ByVal key As T)
		If hm.ContainsKey(key) Then
			If hm(key) = 1 Then
				hm.Remove(key)
			Else
				Dim count As Integer = hm(key)
				hm(key) = count - 1
			End If
		End If
	End Sub

	Public Function getCount(ByVal key As T) As Integer
		If hm.ContainsKey(key) Then
			Return hm(key)
		End If
		Return 0
	End Function

	Public Function containsKey(ByVal key As T) As Boolean
		Return hm.ContainsKey(key)
	End Function

	Public Function size() As Integer
		Return hm.Count
	End Function


End Class
