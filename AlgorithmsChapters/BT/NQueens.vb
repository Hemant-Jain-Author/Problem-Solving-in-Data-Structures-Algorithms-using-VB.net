﻿Imports System

Public Class NQueens
	Public Shared Sub Print(ByVal Q() As Integer, ByVal n As Integer)
		For i As Integer = 0 To n - 1
			Console.Write(" " & Q(i))
		Next i
		Console.WriteLine(" ")
	End Sub

	Public Shared Function Feasible(ByVal Q() As Integer, ByVal k As Integer) As Boolean
		For i As Integer = 0 To k - 1
			If Q(k) = Q(i) OrElse Math.Abs(Q(i) - Q(k)) = Math.Abs(i - k) Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Sub Arrange(ByVal Q() As Integer, ByVal k As Integer, ByVal n As Integer)
		If k = n Then
			Print(Q, n)
			Return
		End If
		Dim i As Integer = 0
		Do While i < n
			Q(k) = i
			If Feasible(Q, k) Then
				Arrange(Q, k + 1, n)
			End If
			i += 1
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim Q(7) As Integer
		NQueens.Arrange(Q, 0, 8)
	End Sub
End Class

'
' 0 4 7 5 2 6 1 3 
' 0 5 7 2 6 3 1 4 
' ......
' 7 2 0 5 1 4 6 3 
' 7 3 0 2 5 1 6 4 
' 