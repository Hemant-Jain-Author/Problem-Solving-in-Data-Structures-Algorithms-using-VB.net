Imports System

Public Class CountSort
	Public Sub Sort(ByVal arr() As Integer, ByVal lowerRange As Integer, ByVal upperRange As Integer)
		Dim i, j As Integer
		Dim size As Integer = arr.Length
		Dim range As Integer = upperRange - lowerRange
		Dim count(range - 1) As Integer

		For i = 0 To size - 1
			count(arr(i) - lowerRange) += 1
		Next i

		j = 0
		For i = 0 To range - 1
			Do While count(i) > 0
				arr(j) = i + lowerRange
				j += 1
				(count(i)) -= 1
			Loop
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {23, 24, 22, 21, 26, 25, 27, 28, 21, 21}
		Dim b As New CountSort()
		b.Sort(array, 20, 30)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class

'
'21 21 21 22 23 24 25 26 27 28
'