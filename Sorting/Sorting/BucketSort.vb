Public Class BucketSort
	Friend array() As Integer
	Friend range As Integer
	Friend lowerRange As Integer

	Public Sub New(ByVal arr() As Integer, ByVal lowerRange As Integer, ByVal upperRange As Integer)
		array = arr
		range = upperRange - lowerRange
		Me.lowerRange = lowerRange
	End Sub

	Public Sub sort()
		Dim i, j As Integer
		Dim size As Integer = array.Length
		Dim count(range - 1) As Integer

		For i = 0 To range - 1
			count(i) = 0
		Next i

		For i = 0 To size - 1
			count(array(i) - lowerRange) += 1
		Next i

		j = 0

		For i = 0 To range - 1
			Do While count(i) > 0
				array(j) = i + lowerRange
				j += 1
				count(i) -= 1
			Loop
		Next i
	End Sub
End Class