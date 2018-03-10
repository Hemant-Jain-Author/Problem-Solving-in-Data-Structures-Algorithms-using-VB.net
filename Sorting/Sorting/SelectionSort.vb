Public Class SelectionSort
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

	Public Sub sort() 'back array
		Dim size As Integer = arr.Length
		Dim i, j, max, temp As Integer
		i = 0
		Do While i < size - 1
			max = 0
			j = 1
			Do While j < size - 1 - i
				If arr(j) > arr(max) Then
					max = j
				End If
				j += 1
			Loop
			temp = arr(size - 1 - i)
			arr(size - 1 - i) = arr(max)
			arr(max) = temp
			i += 1
		Loop
	End Sub


	Friend Sub sort2() 'front array
		Dim size As Integer = arr.Length
		Dim i, j, min, temp As Integer
		i = 0
		Do While i < size - 1
			min = i
			For j = i + 1 To size - 1
				If arr(j) < arr(min) Then
					min = j
				End If
			Next j
			temp = arr(i)
			arr(i) = arr(min)
			arr(min) = temp
			i += 1
		Loop
	End Sub
End Class