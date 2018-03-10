Imports System

Public Class QuickSortDemo
	Public Shared Sub Main5(ByVal args() As String)
		Dim array() As Integer = { 3, 4, 2, 1, 6, 5, 7, 8, 1, 1 }
		Dim m As New QuickSort(array)
		m.sort()
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class