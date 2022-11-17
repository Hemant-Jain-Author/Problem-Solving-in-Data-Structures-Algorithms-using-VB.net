Imports System

Public Class SelectionSort
	 Private Function more(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
		Return value1 > value2
	 End Function

	Public Sub Sort(ByVal arr() As Integer) ' Sorted array created in reverse order.
		Dim size As Integer = arr.Length
		Dim i, j, max, temp As Integer
		i = 0
		While i < size - 1
			max = 0
			j = 1
			While j < size - i
				If arr(j) > arr(max) Then
					max = j
				End If
				j += 1
			End While
			temp = arr(size - 1 - i)
			arr(size - 1 - i) = arr(max)
			arr(max) = temp
			i += 1
		End While
	End Sub

	Public Sub Sort2(ByVal arr() As Integer) ' Sorted array created in forward direction
		Dim size As Integer = arr.Length
		Dim i, j, min, temp As Integer
		i = 0
		While i < size - 1
			min = i
			For j = i + 1 To size - 1
				If arr(j) < arr(min) Then
					min = j
				End If
			Next j
			temp = arr(i)
			arr(i) = arr(min)
			arr(min) = temp
			i += 1
		End While
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		Dim srt As New SelectionSort()
		srt.Sort(array)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
		Console.WriteLine()

		Dim array2() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		srt = New SelectionSort()
		srt.Sort2(array2)
		For i As Integer = 0 To array2.Length - 1
			Console.Write(array2(i) & " ")
		Next i
	End Sub
End Class

'
'1 2 3 4 5 6 7 8 9 
'1 2 3 4 5 6 7 8 9
'