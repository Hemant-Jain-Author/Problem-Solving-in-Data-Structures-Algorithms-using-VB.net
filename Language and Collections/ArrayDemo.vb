Imports System

Public Class ArrayDemo
	Public Shared Sub oneD()
		Dim arr(9) As Integer
		For i As Integer = 0 To 9
			arr(i) = i
		Next i
		For i As Integer = 0 To 9
			Console.Write(arr(i) & " ")
		Next i
	End Sub

	Private Shared Sub twoD()
		Dim arr(3, 3) As Integer

		For i As Integer = 0 To 3
			For j As Integer = 0 To 3
				arr(i, j) = i + j
			Next j
		Next i

		For i As Integer = 0 To 3
			For j As Integer = 0 To 3
				Console.Write(arr(i, j))
			Next j
			Console.WriteLine()
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		oneD()
		Console.WriteLine()
		twoD()
	End Sub
End Class

'
'0 1 2 3 4 5 6 7 8 9
'
'0123 
'1234 
'2345 
'3456 
'