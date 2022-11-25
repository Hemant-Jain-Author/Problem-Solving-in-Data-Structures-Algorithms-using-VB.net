Imports System

Public Module HouseRobber
	Function MaxRobbery(ByVal house() As Integer) As Integer
		Dim n As Integer = house.Length
		Dim dp(n - 1) As Integer
		dp(0) = house(0)
		dp(1) = house(1)
		dp(2) = dp(0) + house(2)
		For i As Integer = 3 To n - 1
			dp(i) = Math.Max(dp(i - 2), dp(i - 3)) + house(i)
		Next i
		Return Math.Max(dp(n - 1), dp(n - 2))
	End Function

	Function MaxRobbery2(ByVal house() As Integer) As Integer
		Dim n As Integer = house.Length
		Dim dp(n - 1, 1) As Integer

		dp(0, 1) = house(0)
		dp(0, 0) = 0

		For i As Integer = 1 To n - 1
			dp(i, 1) = Math.Max(dp(i - 1, 0) + house(i), dp(i - 1, 1))
			dp(i, 0) = dp(i - 1, 1)
		Next i
		Return Math.Max(dp(n - 1, 1), dp(n - 1, 0))
	End Function

	Sub Main(ByVal args() As String)
		Dim arr() As Integer = {10, 12, 9, 23, 25, 55, 49, 70}
		Console.WriteLine("Total cash: " & MaxRobbery(arr))
		Console.WriteLine("Total cash: " & MaxRobbery2(arr))
	End Sub
End Module

'
'Total cash: 160
'Total cash: 160
'