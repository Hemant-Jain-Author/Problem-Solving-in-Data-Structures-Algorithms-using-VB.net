Imports System

Public Class InsertionSort
	Private Function Greater(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
		Return value1 > value2
	End Function

	Public Sub Sort(ByVal arr() As Integer)
		Dim size As Integer = arr.Length
		Dim temp, j As Integer
		For i As Integer = 1 To size - 1
			temp = arr(i)
			j = i
			Do While j > 0 AndAlso Greater(arr(j - 1), temp)
				arr(j) = arr(j - 1)
				j -= 1
			Loop
			arr(j) = temp
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		Dim srt As New InsertionSort()
		srt.Sort(array)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class
'
'1 2 3 4 5 6 7 8 9
'