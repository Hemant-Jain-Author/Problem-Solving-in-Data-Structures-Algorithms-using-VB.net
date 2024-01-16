Imports System

Public Module LongestCommonSubseq
	Function LCSubSeq(ByVal st1 As String, ByVal st2 As String) As Integer
		Dim X() As Char = st1.ToCharArray()
		Dim Y() As Char = st2.ToCharArray()
		Dim m As Integer = st1.Length
		Dim n As Integer = st2.Length
		Dim dp(m, n) As Integer ' Dynamic programming array.
		Dim p(m, n) As Integer ' For printing the substring.

		' Fill dp array in bottom up fashion.
		For i As Integer = 1 To m
			For j As Integer = 1 To n
				If X(i - 1) = Y(j - 1) Then
					dp(i, j) = dp(i - 1, j - 1) + 1
					p(i, j) = 0
				Else
					dp(i, j) = If(dp(i - 1, j) > dp(i, j - 1), dp(i - 1, j), dp(i, j - 1))
					p(i, j) = If(dp(i - 1, j) > dp(i, j - 1), 1, 2)
				End If
			Next j
		Next i
		PrintLCS(p, X, m, n)
		Console.WriteLine()
		Return dp(m, n)
	End Function

	Sub PrintLCS(ByVal p(,) As Integer, ByVal X() As Char, ByVal i As Integer, ByVal j As Integer)
		If i = 0 OrElse j = 0 Then
			Return
		End If

		If p(i, j) = 0 Then
			PrintLCS(p, X, i - 1, j - 1)
			Console.Write(X(i - 1))
		ElseIf p(i, j) = 1 Then
			PrintLCS(p, X, i - 1, j)
		Else
			PrintLCS(p, X, i, j - 1)
		End If
	End Sub

	' Testing code.
	Sub Main(ByVal args() As String)
		Dim X As String = "carpenter"
		Dim Y As String = "sharpener"
		Console.WriteLine(LCSubSeq(X, Y))
	End Sub
End Module

'
'arpener
'7
'