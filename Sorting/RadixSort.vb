Imports System

Public Class RadixSort
	Private Function GetMax(ByVal arr() As Integer, ByVal n As Integer) As Integer
		Dim max As Integer = arr(0)
		For i As Integer = 1 To n - 1
			If max < arr(i) Then
				max = arr(i)
			End If
		Next i
		Return max
	End Function

	Private Sub CountSort(ByVal arr() As Integer, ByVal n As Integer, ByVal dividend As Integer)
		Dim temp As Integer() = CType(arr.Clone(), Integer())
		Dim count(9) As Integer
		For i As Integer = 0 To 9
			count(i) = 0
		Next i
		' Store count of occurrences in count array.
		' (number / dividend) % 10 is used to find the working digit.
		For i As Integer = 0 To n - 1
			count((temp(i) \ dividend) Mod 10) += 1
		Next i

		' Change count[i] so that count[i] contains 
		' number of elements till index i in output.
		For i As Integer = 1 To 9
			count(i) += count(i - 1)
		Next i

		' Copy content to input arr.
		For i As Integer = n - 1 To 0 Step -1
			arr(count((temp(i) \ dividend) Mod 10) - 1) = temp(i)
			count((temp(i) \ dividend) Mod 10) -= 1
		Next i
	End Sub

	Public Sub Sort(ByVal arr() As Integer)
		Dim n As Integer = arr.Length
		Dim m As Integer = GetMax(arr, n)

		' Counting Sort for every digit.
		' The dividend passed is used to calculate current working digit.
		Dim div As Integer = 1
		Do While m \ div > 0
			CountSort(arr, n, div)
			div *= 10
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {100, 49, 65, 91, 702, 29, 4, 55}
		Dim b As New RadixSort()
		b.Sort(array)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class

'
'4 29 49 55 65 91 100 702
'
