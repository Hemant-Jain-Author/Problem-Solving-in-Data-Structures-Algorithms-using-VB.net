Imports System

Public Class BucketSortDemo
	Public Shared Sub Main4(ByVal args() As String)
		Dim array() As Integer = { 23, 24, 22, 21, 26, 25, 27, 28, 21, 21 }

		Dim m As New BucketSort(array, 20, 30)
		m.sort()
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class
