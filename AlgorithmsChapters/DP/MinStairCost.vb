﻿Imports System

Public Class MinStairCost
	Public Shared Function MinCost(ByVal cost() As Integer, ByVal n As Integer) As Integer
		' base case
		If n = 1 Then
			Return cost(0)
		End If

		Dim dp(n - 1) As Integer
		dp(0) = cost(0)
		dp(1) = cost(1)

		For i As Integer = 2 To n - 1
			dp(i) = Math.Min(dp(i - 1), dp(i - 2)) + cost(i)
		Next i

		Return Math.Min(dp(n - 2), dp(n - 1))
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim a() As Integer = {1, 5, 6, 3, 4, 7, 9, 1, 2, 11}
		Dim n As Integer = a.Length
		Console.Write(MinCost(a, n))
	End Sub
End Class

'
'18
'