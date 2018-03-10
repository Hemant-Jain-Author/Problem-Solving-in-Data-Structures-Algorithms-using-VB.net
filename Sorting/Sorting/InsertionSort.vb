Public Class InsertionSort
	Private arr() As Integer
	Public Sub New(ByVal array() As Integer)
		arr = array
	End Sub

	Private Function more(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
		Return value1 > value2
	End Function

	Public Sub sort()
		Dim size As Integer = arr.Length

		Dim temp, j As Integer
		For i As Integer = 1 To size - 1
			temp = arr(i)
			j = i
			Do While j > 0 AndAlso more(arr(j - 1), temp)
				arr(j) = arr(j - 1)
				j -= 1
			Loop
			arr(j) = temp
		Next i
	End Sub
End Class