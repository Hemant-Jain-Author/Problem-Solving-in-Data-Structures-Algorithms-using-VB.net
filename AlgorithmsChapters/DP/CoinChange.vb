
Imports System

Public Class CoinChange
	Public Shared Function MinCoins(ByVal coins() As Integer, ByVal n As Integer, ByVal val As Integer) As Integer ' Greedy may be wrong.
		If val <= 0 Then
			Return 0
		End If

		Dim count As Integer = 0
		Array.Sort(coins)

		Dim i As Integer = n - 1
		While i >= 0 AndAlso val > 0
			If coins(i) <= val Then
				count += 1
				val -= coins(i)
			Else
				i -= 1
			End If
		End While
		Return If(val = 0, count, -1)
	End Function

	Public Shared Function MinCoins2(ByVal coins() As Integer, ByVal n As Integer, ByVal val As Integer) As Integer ' Brute force.
		If val = 0 Then
			Return 0
		End If

		Dim count As Integer = Integer.MaxValue
		Dim i As Integer = 0
		While i < n
			If coins(i) <= val Then
				Dim subCount As Integer = MinCoins2(coins, n, val - coins(i))
				If subCount >= 0 Then
					count = Math.Min(count, subCount + 1)
				End If
			End If
			i += 1
		End While
		Return If(count <> Integer.MaxValue, count, -1)
	End Function

	Public Shared Function MinCoinsTD(ByVal coins() As Integer, ByVal n As Integer, ByVal val As Integer) As Integer
		Dim dp(val) As Integer
		For i As Integer = 0 To val
			dp(i)= Integer.MaxValue
		Next i
		Return MinCoinsTD(dp, coins, n, val)
	End Function

	Private Shared Function MinCoinsTD(ByVal dp() As Integer, ByVal coins() As Integer, ByVal n As Integer, ByVal val As Integer) As Integer
		' Base Case
		If val = 0 Then
			Return 0
		End If

		If dp(val) <> Integer.MaxValue Then
			Return dp(val)
		End If

		' Recursion
		Dim i As Integer = 0
		While i < n
			If coins(i) <= val Then ' check validity of a sub-problem
				Dim subCount As Integer = MinCoinsTD(dp, coins, n, val - coins(i))
				If subCount <> Integer.MaxValue Then
					dp(val) = Math.Min(dp(val), subCount + 1)
				End If
			End If
			i += 1
		End While
		Return dp(val)
	End Function


	Public Shared Function MinCoinsBU(ByVal coins() As Integer, ByVal n As Integer, ByVal val As Integer) As Integer ' DP bottom up approach.
		Dim dp(val) As Integer 
		For i As Integer = 0 To val
			dp(i)= Integer.MaxValue
		Next
		dp(0) = 0 ' Base value.

		For i As Integer = 1 To val
			For j As Integer = 0 To n - 1
				' For all coins smaller than or equal to i.
				If coins(j) <= i Then
					If dp(i - coins(j)) <> Integer.MaxValue Then
						dp(i) = Math.Min(dp(i), dp(i - coins(j)) + 1)
					End If
				End If
			Next j
		Next i

		Return If(dp(val) <> Integer.MaxValue, dp(val), -1)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim coins() As Integer = {5, 6}
		Dim value As Integer = 16
		Dim n As Integer = coins.Length
		Console.WriteLine("Count is:" & MinCoins(coins, n, value))
		Console.WriteLine("Count is:" & MinCoins2(coins, n, value))
		Console.WriteLine("Count is:" & MinCoinsBU(coins, n, value))
		Console.WriteLine("Count is:" & MinCoinsTD(coins, n, value))
	End Sub

	Public Shared Sub main1(ByVal args() As String)
		Dim coins() As Integer = {1, 5, 6, 9, 12}
		Dim value As Integer = 15
		Dim n As Integer = coins.Length
		Console.WriteLine("Count is:" & MinCoins(coins, n, value))
		Console.WriteLine("Count is:" & MinCoins2(coins, n, value))
		Console.WriteLine("Count is:" & MinCoinsBU(coins, n, value))
		Console.WriteLine("Count is:" & MinCoinsTD(coins, n, value))
	End Sub

	Public Shared Sub main2(ByVal args() As String)
		Dim coins() As Integer = {1, 5, 6, 9, 11}
		Dim v As Integer = 15
		Dim n As Integer = coins.Length
		MinCoins(coins, n, v)
		MinCoins2(coins, n, v)
	End Sub
End Class

'Count Is: -1
'Count Is: 3
'Count Is: 3
'Count Is: 3