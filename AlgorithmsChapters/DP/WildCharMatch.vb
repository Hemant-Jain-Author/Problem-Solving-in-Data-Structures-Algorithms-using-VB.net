Imports System

Public Class WildCharMatch
	Public Shared Function matchExp(ByVal exp As String, ByVal str As String) As Boolean
		Return matchExpUtil(exp.ToCharArray(), str.ToCharArray(), 0, 0)
	End Function

	Private Shared Function matchExpUtil(ByVal exp() As Char, ByVal str() As Char, ByVal m As Integer, ByVal n As Integer) As Boolean
		If m = exp.Length AndAlso (n = str.Length OrElse exp(m - 1) = "*"c) Then
			Return True
		End If
		If (m = exp.Length AndAlso n <> str.Length) OrElse (m <> exp.Length AndAlso n = str.Length) Then
			Return False
		End If
		If exp(m) = "?"c OrElse exp(m) = str(n) Then
			Return matchExpUtil(exp, str, m + 1, n + 1)
		End If
		If exp(m) = "*"c Then
			Return matchExpUtil(exp, str, m + 1, n) OrElse matchExpUtil(exp, str, m, n + 1)
		End If
		Return False
	End Function

	Public Shared Function matchExpDP(ByVal exp As String, ByVal str As String) As Boolean
		Return matchExpUtilDP(exp.ToCharArray(), str.ToCharArray(), exp.Length, str.Length)
	End Function

	Private Shared Function matchExpUtilDP(ByVal exp() As Char, ByVal str() As Char, ByVal m As Integer, ByVal n As Integer) As Boolean
		Dim lookup(m, n) As Boolean
		lookup(0, 0) = True ' empty exp and empty str match.

		' 0 row will remain all false. empty exp can't match any str.
		' '*' can match with empty string, column 0 update.
		For i As Integer = 1 To m
			If exp(i - 1) = "*"c Then
				lookup(i, 0) = lookup(i - 1, 0)
			Else
				Exit For
			End If
		Next i

		' Fill the table in bottom-up fashion
		For i As Integer = 1 To m
			For j As Integer = 1 To n
				' If we see a '*' in pattern:
				' 1) We ignore '*' character and consider 
				' next character in the pattern.
				' 2) We ignore one character in the input str
				' and consider next character.
				If exp(i - 1) = "*"c Then
					lookup(i, j) = lookup(i - 1, j) OrElse lookup(i, j - 1)
				' Condition when both the pattern and input string
				' have same character. Also '?' match with all the
				' characters.
				ElseIf exp(i - 1) = "?"c OrElse str(j - 1) = exp(i - 1) Then
					lookup(i, j) = lookup(i - 1, j - 1)
				' If characters don't match
				Else
					lookup(i, j) = False
				End If
			Next j
		Next i
		Return lookup(m, n)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Console.WriteLine(matchExp("*llo,?World?", "Hello, World!"))
		Console.WriteLine(matchExpDP("*llo,?World?", "Hello, World!"))
	End Sub
'
'True
'True
'

	Public Shared Sub main2(ByVal args() As String)
		Dim str As String = "baaabab"
		Dim pattern() As String = {"*****ba*****ab", "ba*****ab", "ba*ab", "a*ab", "a*****ab", "*a*****ab", "ba*ab****", "****", "*", "aa?ab", "b*b", "a*a", "baaabab", "?baaabab", "*baaaba*"}

		For Each p As String In pattern
			If matchExp(p, str) <> matchExpDP(p, str) Then
				Console.Write(matchExpDP(p, str) & " for ")
				Console.WriteLine(p & " == " & str)
			End If
		Next p
	End Sub
End Class