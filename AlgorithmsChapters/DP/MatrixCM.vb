Imports System

Public Class MatrixCM

	Private Shared Function MatrixChainMulBruteForce(ByVal p() As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		If i = j Then
			Return 0
		End If

		Dim min As Integer = Integer.MaxValue

		' place parenthesis at different places between
		' first and last matrix, recursively calculate
		' count of multiplications for each parenthesis
		' placement and return the minimum count
		Dim k As Integer = i
		Do While k < j
			Dim count As Integer = MatrixChainMulBruteForce(p, i, k) + MatrixChainMulBruteForce(p, k + 1, j) + p(i - 1) * p(k) * p(j)

			If count < min Then
				min = count
			End If
			k += 1
		Loop

		' Return minimum count
		Return min
	End Function

	Public Shared Function MatrixChainMulBruteForce(ByVal p() As Integer, ByVal n As Integer) As Integer
		Dim i As Integer = 1, j As Integer = n - 1
		Return MatrixChainMulBruteForce(p, i, j)
	End Function

	Public Shared Function MatrixChainMulTD(ByVal p() As Integer, ByVal n As Integer) As Integer
		Dim dp(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				dp(i, j) = Integer.MaxValue
			Next j
		Next i

		Return MatrixChainMulTD(dp, p, 1, n - 1)
	End Function

	' Function for matrix chain multiplication
	Private Shared Function MatrixChainMulTD(ByVal dp(,) As Integer, ByVal p() As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		' Base Case
		If i = j Then
			Return 0
		End If
		If dp(i, j) <> Integer.MaxValue Then
			Return dp(i, j)
		End If

		For k As Integer = i To j - 1
			dp(i, j) = Math.Min(dp(i, j), MatrixChainMulTD(dp, p, i, k) + MatrixChainMulTD(dp, p, k + 1, j) + p(i - 1) * p(k) * p(j))
		Next k
		Return dp(i, j)
	End Function



	Public Shared Function MatrixChainMulBU(ByVal p() As Integer, ByVal n As Integer) As Integer
		Dim dp(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				dp(i, j) = Integer.MaxValue
			Next j
		Next i

		For i As Integer = 1 To n - 1
				dp(i, i) = 0
		Next i

		For l As Integer = 1 To n - 1 ' l is length of range.
			Dim i As Integer = 1
			Dim j As Integer = i + l
			Do While j < n
				For k As Integer = i To j - 1
					dp(i, j) = Math.Min(dp(i, j), dp(i, k) + p(i - 1) * p(k) * p(j) + dp(k + 1, j))
				Next k
				i += 1
				j += 1
			Loop
		Next l
		Return dp(1, n - 1)
	End Function

	' Driver Code
	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4}
		Dim n As Integer = arr.Length
		Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulBruteForce(arr, n))
		Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulTD(arr, n))
		Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulBU(arr, n))
	End Sub
End Class

'
'Matrix Chain Multiplication is: 18
'Matrix Chain Multiplication is: 18
'Matrix Chain Multiplication is: 18
'

