Imports System

Module Module1
	Private Sub onedimension()
		Dim arr(9) As Integer
		For i As Integer = 0 To 9
			arr(i) = i
		Next i
		For i As Integer = 0 To 9
			Console.WriteLine(arr(i))
		Next i

	End Sub


	Private Sub twodimension()
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
			Console.WriteLine(" ")
		Next i
	End Sub

	Sub Main()
		onedimension()
		twodimension()
	End Sub
End Module
