Imports System

Public Class SubsetSum
	Private Shared Sub PrintSubset(ByVal flags() As Boolean, ByVal arr() As Integer, ByVal size As Integer)
		For i As Integer = 0 To size - 1
			If flags(i) Then
				Console.Write(arr(i) & " ")
			End If
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub FindSubsetSum(ByVal arr() As Integer, ByVal n As Integer, ByVal target As Integer)
		Dim flags(n - 1) As Boolean
		FindSubsetSum(arr, n, flags, 0, 0, target)
	End Sub

	Private Shared Sub FindSubsetSum(ByVal arr() As Integer, ByVal n As Integer, ByVal flags() As Boolean, ByVal sum As Integer, ByVal curr As Integer, ByVal target As Integer)
		If target = sum Then
			PrintSubset(flags, arr, n) ' Solution found.
			Return
		End If

		' constraint check
		If curr >= n OrElse sum > target Then
			' Backtracking.
			Return
		End If

		' Current element included.
		flags(curr) = True
		FindSubsetSum(arr, n, flags, sum + arr(curr), curr + 1, target)
		' Current element excluded.
		flags(curr) = False
		FindSubsetSum(arr, n, flags, sum, curr + 1, target)
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {15, 22, 14, 26, 32, 9, 16, 8}
		Dim target As Integer = 53
		Dim n As Integer = arr.Length
		SubsetSum.FindSubsetSum(arr, n, target)
	End Sub
End Class

'
'15 22 16 
'15 14 16 8 
'22 14 9 8 
'