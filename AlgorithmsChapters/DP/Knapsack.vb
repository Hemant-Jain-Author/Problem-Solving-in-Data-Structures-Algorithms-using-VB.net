Imports System

Public Module Knapsack
	Public Function GetMaxKnapsackCost01(ByVal wt() As Integer, ByVal cost() As Integer, ByVal capacity As Integer) As Integer
		Dim n As Integer = wt.Length
		Return GetMaxKnapsackCost01Util(wt, cost, n, capacity)
	End Function

	Private Function GetMaxKnapsackCost01Util(ByVal wt() As Integer, ByVal cost() As Integer, ByVal n As Integer, ByVal capacity As Integer) As Integer
		' Base Case
		If n = 0 OrElse capacity = 0 Then
			Return 0
		End If

		' Return the maximum of two cases:
		' (1) nth item is included
		' (2) nth item is not included
		Dim first As Integer = 0
		If wt(n - 1) <= capacity Then
			first = cost(n - 1) + GetMaxKnapsackCost01Util(wt, cost, n - 1, capacity - wt(n - 1))
		End If

		Dim second As Integer = GetMaxKnapsackCost01Util(wt, cost, n - 1, capacity)
		Return Math.Max(first, second)
	End Function

	Public Function GetMaxKnapsackCost01TD(ByVal wt() As Integer, ByVal cost() As Integer, ByVal capacity As Integer) As Integer
		Dim n As Integer = wt.Length
		Dim dp(capacity, n) As Integer
		Return GetMaxKnapsackCost01TD(dp, wt, cost, n, capacity)
	End Function

	Private Function GetMaxKnapsackCost01TD(ByVal dp(,) As Integer, ByVal wt() As Integer, ByVal cost() As Integer, ByVal i As Integer, ByVal w As Integer) As Integer
		If w = 0 OrElse i = 0 Then
			Return 0
		End If

		If dp(w, i) <> 0 Then
			Return dp(w, i)
		End If

		' Their are two cases:
		' (1) ith item is included
		' (2) ith item is not included
		Dim first As Integer = 0
		If wt(i - 1) <= w Then
			first = GetMaxKnapsackCost01TD(dp, wt, cost, i - 1, w - wt(i - 1)) + cost(i - 1)
		End If

		Dim second As Integer = GetMaxKnapsackCost01TD(dp, wt, cost, i - 1, w)
		dp(w, i) = Math.Max(first, second)
		Return dp(w, i)
	End Function

	Public Function GetMaxKnapsackCost01BU(ByVal wt() As Integer, ByVal cost() As Integer, ByVal capacity As Integer) As Integer
		Dim n As Integer = wt.Length
		Dim dp(capacity, n) As Integer

		' Build table dp[, ] in bottom up approach.
		' Weights considered against capacity.
		For w As Integer = 1 To capacity
			For i As Integer = 1 To n
				' Their are two cases:
				' (1) ith item is included
				' (2) ith item is not included
				Dim first As Integer = 0
				If wt(i - 1) <= w Then
					first = dp(w - wt(i - 1), i - 1) + cost(i - 1)
				End If

				Dim second As Integer = dp(w, i - 1)
				dp(w, i) = Math.Max(first, second)
			Next i
		Next w
		'PrintItems(dp, wt, cost, n, capacity);
		Return dp(capacity, n) ' Number of weights considered and final capacity.
	End Function

	Private Sub PrintItems(ByVal dp(,) As Integer, ByVal wt() As Integer, ByVal cost() As Integer, ByVal n As Integer, ByVal capacity As Integer)
		Dim totalCost As Integer = dp(capacity, n)
		Console.Write("Selected items are:")
		For i As Integer = n - 1 To 1 Step -1
			If totalCost <> dp(capacity, i - 1) Then
				Console.Write(" (" & wt(i) & "," & cost(i) & ")")
				capacity -= wt(i)
				totalCost -= cost(i)
			End If
		Next i
	End Sub

	Public Function KS01UnboundBU(ByVal wt() As Integer, ByVal cost() As Integer, ByVal capacity As Integer) As Integer
		Dim n As Integer = wt.Length
		Dim dp(capacity) As Integer

		' Build table dp[] in bottom up approach.
		' Weights considered against capacity.
		For w As Integer = 1 To capacity
			For i As Integer = 1 To n
				' Their are two cases:
				' (1) ith item is included 
				' (2) ith item is not included
				If wt(i - 1) <= w Then
					dp(w) = Math.Max(dp(w), dp(w - wt(i - 1)) + cost(i - 1))
				End If
			Next i
		Next w
		'PrintItems(dp, wt, cost, n, capacity);
		Return dp(capacity) ' Number of weights considered and final capacity.
	End Function

	Sub Main1(ByVal args() As String)
		Dim wt() As Integer = {5, 10, 15}
		Dim cost() As Integer = {10, 30, 20}
		Dim capacity As Integer = 20

		Dim maxCost As Double = GetMaxKnapsackCost01(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
		maxCost = GetMaxKnapsackCost01BU(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
		maxCost = GetMaxKnapsackCost01TD(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
	End Sub

	Sub Main(ByVal args() As String)
		Dim wt() As Integer = {10, 40, 20, 30}
		Dim cost() As Integer = {60, 40, 90, 120}
		Dim capacity As Integer = 50

		Dim maxCost As Double = GetMaxKnapsackCost01(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
		maxCost = GetMaxKnapsackCost01BU(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
		maxCost = GetMaxKnapsackCost01TD(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
	End Sub
End Module

'
'Maximum cost obtained = 210.0
'Maximum cost obtained = 210.0
'Maximum cost obtained = 210.0
'