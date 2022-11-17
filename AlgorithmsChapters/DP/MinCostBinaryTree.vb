Imports System

Public Class MinCostBinaryTree
	Private Shared Function MaxVal(ByVal max(,) As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		If max(i, j) <> Integer.MinValue Then
			Return max(i, j)
		End If

		For k As Integer = i To j - 1
			max(i, j) = Math.Max(max(i, j), Math.Max(MaxVal(max, i, k), MaxVal(max, k + 1, j)))
		Next k
		Return max(i, j)
	End Function

	Private Shared Function FindSumTD(ByVal dp(,) As Integer, ByVal max(,) As Integer, ByVal i As Integer, ByVal j As Integer, ByVal arr() As Integer) As Integer
	If j <= i Then
		Return 0
	End If

	If dp(i, j) <> Integer.MaxValue Then
		Return dp(i, j)
	End If

	For k As Integer = i To j - 1
		dp(i, j) = Math.Min(dp(i, j), FindSumTD(dp, max, i, k, arr) + FindSumTD(dp, max, k + 1, j, arr) + MaxVal(max, i, k) * MaxVal(max, k + 1,j))
	Next k
	Return dp(i, j)
	End Function

	Public Shared Function FindSumTD(ByVal arr() As Integer) As Integer
		Dim n As Integer = arr.Length
		Dim dp(n - 1, n - 1) As Integer

		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				dp(i, j) = Integer.MaxValue
			Next j
		Next i

		Dim max(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				max(i, j) = Integer.MinValue
			Next j
		Next i

		For i As Integer = 0 To n - 1
			max(i, i) = arr(i)
		Next i

		Return FindSumTD(dp, max, 0, n - 1, arr)
	End Function

	Public Shared Function FindSumBU(ByVal arr() As Integer) As Integer
		Dim n As Integer = arr.Length
		Dim dp(n - 1, n - 1) As Integer

		Dim max(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			max(i, i) = arr(i)
		Next i

		For l As Integer = 1 To n - 1 ' l is length of range.
			Dim i As Integer = 0
			Dim j As Integer = i + l
			While j < n
				dp(i, j) = Integer.MaxValue
				For k As Integer = i To j - 1
					dp(i, j) = Math.Min(dp(i, j), dp(i, k) + dp(k + 1, j) + max(i, k) * max(k + 1, j))
					max(i, j) = Math.Max(max(i, k), max(k + 1, j))
				Next k
				i += 1
				j += 1
			End While
		Next l
		Return dp(0, n - 1)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {6, 2, 4}
		Console.WriteLine("Total cost: " & FindSumTD(arr))
		Console.WriteLine("Total cost: " & FindSumBU(arr))
	End Sub
End Class

'
'Total cost: 32
'Total cost: 32
'