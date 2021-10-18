Imports System

Public Class LargestIncreasingSubseq
	Public Shared Function LIS(ByVal arr() As Integer) As Integer
		Dim n As Integer = arr.Length
		Dim dp(n - 1) As Integer
		Dim max As Integer = 0

		' Populating LIS values in bottom up manner.
		For i As Integer = 0 To n - 1
			dp(i) = 1 ' Initialize LIS values for all indexes as 1.
			For j As Integer = 0 To i - 1
				If arr(j) < arr(i) AndAlso dp(i) < dp(j) + 1 Then
					dp(i) = dp(j) + 1
				End If
			Next j
			If max < dp(i) Then ' Max LIS values.
				max = dp(i)
			End If
		Next i
		Return max
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {10, 12, 9, 23, 25, 55, 49, 70}
		Console.WriteLine("Length of LIS is " & LIS(arr))
	End Sub
End Class

' Length of lis is 6
