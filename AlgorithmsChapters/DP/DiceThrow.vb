Imports System

Public Class DiceThrow
	Public Shared Function FindWays(ByVal n As Integer, ByVal m As Integer, ByVal V As Integer) As Integer
		Dim dp(n, V) As Integer

		' Table entries for only one dice.
		For j As Integer = 1 To Math.Min(m, V)
			dp(1, j) = 1
		Next j

		' i is number of dice, j is Value, k value of dice.
		For i As Integer = 2 To n
			For j As Integer = 1 To V
				Dim k As Integer = 1
				Do While k <= j AndAlso k <= m
					dp(i, j) += dp(i - 1, j - k)
					k += 1
				Loop
			Next j
		Next i
		Return dp(n, V)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		For i As Integer = 1 To 6
			Console.WriteLine(FindWays(i, 6, 6))
		Next i
	End Sub
End Class

'
'1
'5
'10
'10
'5
'1
'