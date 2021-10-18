Imports System

Public Class EditDist
	Private Shared Function Min(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Integer
		x = Math.Min(x, y)
		Return Math.Min(x, z)
	End Function

	Public Shared Function FindEditDist(ByVal str1 As String, ByVal str2 As String) As Integer
		Dim m As Integer = str1.Length
		Dim n As Integer = str2.Length
		Return FindEditDist(str1, str2, m, n)
	End Function

	Private Shared Function FindEditDist(ByVal str1 As String, ByVal str2 As String, ByVal m As Integer, ByVal n As Integer) As Integer
		If m = 0 OrElse n = 0 Then ' If any one string is empty, then empty the other string.
			Return m + n
		End If

		' If last characters of both strings are same, ignore last characters.
		If str1.Chars(m - 1) = str2.Chars(n - 1) Then
			Return FindEditDist(str1, str2, m - 1, n - 1)
		End If

		' If last characters are not same, 
		' consider all three operations:
		' Insert last char of second into first.
		' Remove last char of first.
		' Replace last char of first with second.
		Return 1 + Min(FindEditDist(str1, str2, m, n - 1), FindEditDist(str1, str2, m - 1, n), FindEditDist(str1, str2, m - 1, n - 1)) ' Replace
	End Function

	Public Shared Function FindEditDistDP(ByVal str1 As String, ByVal str2 As String) As Integer
		Dim m As Integer = str1.Length
		Dim n As Integer = str2.Length
		Dim dp(m, n) As Integer

		' Fill dp[, ] in bottom up manner.
		For i As Integer = 0 To m
			For j As Integer = 0 To n
				' If any one string is empty, then empty the other string.
				If i = 0 OrElse j = 0 Then
					dp(i, j) = (i + j)
				' If last characters of both strings are same, ignore last characters.
				ElseIf str1.Chars(i - 1) = str2.Chars(j - 1) Then
					dp(i, j) = dp(i - 1, j - 1)
				' If last characters are not same, consider all three operations:
				' Insert last char of second into first.
				' Remove last char of first.
				' Replace last char of first with second.
				Else
					dp(i, j) = 1 + Min(dp(i, j - 1), dp(i - 1, j), dp(i - 1, j - 1)) ' Replace
				End If
			Next j
		Next i
		Return dp(m, n)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim str1 As String = "sunday"
		Dim str2 As String = "saturday"
		Console.WriteLine(FindEditDist(str1, str2))
		Console.WriteLine(FindEditDistDP(str1, str2))
	End Sub
End Class

'
'3
'3
'