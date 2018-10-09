Imports System

Public Class QuickSelect
	Public Shared Sub quickSelect(ByVal arr() As Integer, ByVal k As Integer)
		quickSelect(arr, 0, arr.Length - 1, k)
	End Sub

	Public Shared Sub quickSelect(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer, ByVal k As Integer)
		If upper <= lower Then
			Return
		End If

		Dim pivot As Integer = arr(lower)

		Dim start As Integer = lower
		Dim [stop] As Integer = upper

		Do While lower < upper
			Do While arr(lower) <= pivot AndAlso lower < upper
				lower += 1
			Loop
			Do While arr(upper) > pivot AndAlso lower <= upper
				upper -= 1
			Loop
			If lower < upper Then
				swap(arr, upper, lower)
			End If
		Loop

		swap(arr, upper, start) 'upper is the pivot position

		If k < upper Then
			quickSelect(arr, start, upper - 1, k) 'pivot -1 is the upper for left sub array.
		End If
		If k > upper Then
			quickSelect(arr, upper + 1, [stop], k) ' pivot + 1 is the lower for right sub array.
		End If
	End Sub

	Public Shared Sub swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Integer = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub
	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = { 3, 4, 2, 1, 6, 5, 7, 8, 10, 9 }
		QuickSelect.quickSelect(array, 5)
		Console.Write("value at index 5 is : " & array(4))
	End Sub
End Class