Imports System

' Palindromic Substrings
Public Class LargestPalindromicSubstr
	Public Shared Function PalindromicSubstring(ByVal str As String) As Integer
		Dim n As Integer = str.Length
		Dim dp(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			dp(i, i) = 1
		Next i

		Dim max As Integer = 1
		Dim start As Integer = 0

		For l As Integer = 1 To n - 1
			Dim i As Integer = 0
			Dim j As Integer = i + l
			Do While j < n
				If str.Chars(i) = str.Chars(j) AndAlso dp(i + 1, j - 1) = j - i - 1 Then
					dp(i, j) = dp(i + 1, j - 1) + 2
					If dp(i, j) > max Then
						max = dp(i, j) ' Keeping track of max length and
						start = i ' starting position of sub-string.
					End If
				Else
					dp(i, j) = 0
				End If
				i += 1
				j += 1
			Loop
		Next l
		Console.WriteLine("Max Length Palindromic Substrings : " & str.Substring(start, max))
		Return max
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim str As String = "ABCAUCBCxxCBA"
		Console.WriteLine("Max Palindromic Substrings len: " & PalindromicSubstring(str))
	End Sub
End Class

'
'Max Length Palindromic Substrings : BCxxCB
'Max Palindromic Substrings len: 6
'

'
'	* If asked to find how many different palindromic substrings are possible.
'	* 
'int count = 0;
'for(int i=0;i<n;i++)
'	for(int j=0;j<n;j++)
'	if(dp[i, j] > 0)
'		count++;
'return count;
'