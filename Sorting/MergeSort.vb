Imports System

Public Class MergeSort
	Private Shared Sub merge(ByVal arr() As Integer, ByVal tempArray() As Integer, ByVal lowerIndex As Integer, ByVal middleIndex As Integer, ByVal upperIndex As Integer)
		Dim lowerStart As Integer = lowerIndex
		Dim lowerStop As Integer = middleIndex
		Dim upperStart As Integer = middleIndex + 1
		Dim upperStop As Integer = upperIndex
		Dim count As Integer = lowerIndex
		Do While lowerStart <= lowerStop AndAlso upperStart <= upperStop
			If arr(lowerStart) < arr(upperStart) Then
				tempArray(count) = arr(lowerStart)
				lowerStart += 1
				count += 1
			Else
				tempArray(count) = arr(upperStart)
				upperStart += 1
				count += 1
			End If
		Loop
		Do While lowerStart <= lowerStop
			tempArray(count) = arr(lowerStart)
			lowerStart += 1
			count += 1
		Loop
		Do While upperStart <= upperStop
			tempArray(count) = arr(upperStart)
			upperStart += 1
			count += 1
		Loop
		For i As Integer = lowerIndex To upperIndex
			arr(i) = tempArray(i)
		Next i
	End Sub

	Private Shared Sub mergeSrt(ByVal arr() As Integer, ByVal tempArray() As Integer, ByVal lowerIndex As Integer, ByVal upperIndex As Integer)
		If lowerIndex >= upperIndex Then
			Return
		End If
		Dim middleIndex As Integer = (lowerIndex + upperIndex) \ 2
		mergeSrt(arr, tempArray, lowerIndex, middleIndex)
		mergeSrt(arr, tempArray, middleIndex + 1, upperIndex)
		merge(arr, tempArray, lowerIndex, middleIndex, upperIndex)
	End Sub

	Public Shared Sub sort(ByVal arr() As Integer)
		Dim size As Integer = arr.Length
		Dim tempArray(size - 1) As Integer
		mergeSrt(arr, tempArray, 0, size - 1)
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = { 3, 4, 2, 1, 6, 5, 7, 8, 1, 1 }
		MergeSort.sort(array)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class