Imports System

Public Class InsertionSortDemo
	Public Shared Sub Main2(ByVal args() As String)
		Dim array() As Integer = { 9, 1, 8, 2, 7, 3, 6, 4, 5 }
		Dim bs As New InsertionSort(array)
		bs.sort()
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")

		Next i
	End Sub
End Class
