Imports System

Public Class SelectionSortDemo
	Public Shared Sub Main7(ByVal args() As String)
		Dim array() As Integer = { 9, 1, 8, 2, 7, 3, 6, 4, 5 }
		Dim bs As New SelectionSort(array)
		bs.sort2()
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class