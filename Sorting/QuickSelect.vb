Imports System

Public Class QuickSelect
	Public Shared Sub FindIndex(ByVal arr() As Integer,
	ByVal lower As Integer,
	ByVal upper As Integer,
	ByVal k As Integer)
		If upper <= lower Then
			Return
		End If

		Dim pivot As Integer = arr(lower)
		Dim start As Integer = lower
		Dim finish As Integer = upper

		While lower < upper
			While arr(lower) <= pivot AndAlso lower < upper
				lower += 1
			End While
			While arr(upper) > pivot AndAlso lower <= upper
				upper -= 1
			End While
			If lower < upper Then
				Swap(arr, upper, lower)
			End If
		End While

		Swap(arr, upper, start) ' upper is the pivot position
		If k < upper Then
			FindIndex(arr, start, upper - 1, k) ' pivot -1 is the upper for
		End If
		' left sub array.
		If k > upper Then
			FindIndex(arr, upper + 1, finish, k) ' pivot + 1 is the lower for
		End If
		' right sub array.
	End Sub

	Public Shared Sub Swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Integer = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub

	Public Shared Function FindIndex(ByVal arr() As Integer, ByVal k As Integer) As Integer
		FindIndex(arr, 0, arr.Length - 1, k)
		Return arr(k - 1)
	End Function

    ' Testing code.
	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {3, 4, 2, 1, 6, 5, 7, 8}
		Console.Write("Value at index 5 is : " & QuickSelect.FindIndex(array, 5))
	End Sub
End Class

' Value at index 5 is : 5