﻿Public Class QuickSort
	Private arr() As Integer

	Public Sub New(ByVal array() As Integer)
		arr = array
	End Sub

	Public Sub sort()
		Dim size As Integer = arr.Length
		quickSortUtil(arr, 0, size - 1)
	End Sub

	Private Sub swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Integer = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub

	Private Sub quickSortUtil(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer)
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

		quickSortUtil(arr, start, upper - 1) 'pivot -1 is the upper for left sub array.
		quickSortUtil(arr, upper + 1, [stop]) ' pivot + 1 is the lower for right sub array.
	End Sub
End Class