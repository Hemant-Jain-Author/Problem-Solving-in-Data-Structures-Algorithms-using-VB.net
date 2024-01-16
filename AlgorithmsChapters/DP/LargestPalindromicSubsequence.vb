Imports System

' Palindromic Subsequence
Public Module LargestPalindromicSubsequence
    Function PalindromicSubsequence(ByVal str As String) As Integer
        Dim n As Integer = str.Length
        Dim dp(n - 1, n - 1) As Integer

        For i As Integer = 0 To n - 1 ' each char is itself palindromic with length 1
            dp(i, i) = 1
        Next i

        For l As Integer = 1 To n - 1
            Dim i As Integer = 0
            Dim j As Integer = l
            While j < n
                If str.Chars(i) = str.Chars(j) Then
                    dp(i, j) = dp(i + 1, j - 1) + 2
                Else
                    dp(i, j) = Math.Max(dp(i + 1, j), dp(i, j - 1))
                End If
                i += 1
                j += 1
            End While
        Next l
        Return dp(0, n - 1)
    End Function

    ' Testing code.
    Sub Main(ByVal args() As String)
        Dim str As String = "ABCAUCBCxxCBA"
        Console.WriteLine("Max Palindromic Subsequence length: " & PalindromicSubsequence(str))
    End Sub
End Module

'
'Max Palindromic Subsequence length: 9
'
