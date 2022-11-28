Imports System

Public Module GridUniquePaths
	Function GridUniquePaths(ByVal m As Integer, ByVal n As Integer) As Integer
		Dim dp(m - 1, n - 1) As Integer
		dp(0, 0) = 1

		' Initialize first column.
		For i As Integer = 1 To m - 1
			dp(i, 0) = dp(i - 1, 0)
		Next i
		' Initialize first row.
		For j As Integer = 1 To n - 1
			dp(0, j) = dp(0, j - 1)
		Next j

		For i As Integer = 1 To m - 1
			For j As Integer = 1 To n - 1
				dp(i, j) = dp(i - 1, j) + dp(i, j - 1)
			Next j
		Next i
		Return dp(m - 1, n - 1)
	End Function

	' Diagonal movement allowed.
	Function GridUnique3Paths(ByVal m As Integer, ByVal n As Integer) As Integer
		Dim dp(m - 1, n - 1) As Integer
		dp(0, 0) = 1

		' Initialize first column.
		For i As Integer = 1 To m - 1
			dp(i, 0) = dp(i - 1, 0)
		Next i
		' Initialize first row.
		For j As Integer = 1 To n - 1
			dp(0, j) = dp(0, j - 1)
		Next j

		For i As Integer = 1 To m - 1
			For j As Integer = 1 To n - 1
				dp(i, j) = dp(i - 1, j - 1) + dp(i - 1, j) + dp(i, j - 1)
			Next j
		Next i
		Return dp(m - 1, n - 1)
	End Function

	' Testing code.
	Sub Main(ByVal args() As String)
		Console.WriteLine(GridUniquePaths(3, 3))
		Console.WriteLine(GridUnique3Paths(3, 3))
	End Sub
End Module

'
'6
'13
'