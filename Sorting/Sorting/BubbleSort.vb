Imports System

Public Class BubbleSort
	Private arr() As Integer

	Public Sub New(ByVal array() As Integer)
		arr = array
	End Sub

	Private Function less(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
		Return value1 < value2
	End Function

	Private Function more(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
		Return value1 > value2
	End Function

	Public Sub sort()
		Dim size As Integer = arr.Length

		Dim i, j, temp As Integer
		i = 0
		Do While i < (size - 1)
			j = 0
			Do While j < size - i - 1
				If more(arr(j), arr(j + 1)) Then
					' Swapping 
					temp = arr(j)
					arr(j) = arr(j + 1)
					arr(j + 1) = temp
				End If
				j += 1
			Loop
			i += 1
		Loop
	End Sub

	Public Sub sort2()
		Dim size As Integer = arr.Length
		Dim i As Integer, j As Integer, temp As Integer, swapped As Integer = 1
		i = 0
		Do While i < (size - 1) AndAlso swapped = 1
			swapped = 0
			j = 0
			Do While j < size - i - 1
				If more(arr(j), arr(j + 1)) Then
					' Swapping 
					temp = arr(j)
					arr(j) = arr(j + 1)
					arr(j + 1) = temp
					swapped = 1
				End If
				j += 1
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub Main1(ByVal args() As String)
		Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		Dim bs As New BubbleSort(array)
		bs.sort2()
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class