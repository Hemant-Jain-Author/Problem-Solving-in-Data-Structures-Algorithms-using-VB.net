Imports System
Imports System.Collections.Generic

' Allowed values from 0 to maxValue.
Public Class BucketSort

	Public Sub Sort(ByVal arr() As Integer, ByVal maxValue As Integer)
		Dim numBucket As Integer = 5
		Sort(arr, maxValue, numBucket)
	End Sub

	Public Sub Sort(ByVal arr() As Integer, ByVal maxValue As Integer, ByVal numBucket As Integer)
		Dim length As Integer = arr.Length
		If length = 0 Then
			Return
		End If

		Dim bucket As New List(Of List(Of Integer))(numBucket)

		' Create empty buckets
		For i As Integer = 0 To numBucket - 1
			bucket.Add(New List(Of Integer)())
		Next i

		Dim div As Integer = CInt(Math.Truncate(Math.Ceiling(CDbl(maxValue) / (numBucket))))

		' Add elements into the buckets
		For i As Integer = 0 To length - 1
			If arr(i) < 0 OrElse arr(i) > maxValue Then
				Console.WriteLine("Value out of range.")
				Return
			End If

			Dim bucketIndex As Integer = (arr(i) \ div)

			' Maximum value will be assigned to last bucket.
			If bucketIndex >= numBucket Then
				bucketIndex = numBucket - 1
			End If

			bucket(bucketIndex).Add(arr(i))
		Next i

		' Sort the elements of each bucket.
		For i As Integer = 0 To numBucket - 1
			bucket(i).Sort()
		Next i

		' Populate output from the Sorted subarray.
		Dim index As Integer = 0, count As Integer
		For i As Integer = 0 To numBucket - 1
			Dim temp As List(Of Integer) = bucket(i)
			count = temp.Count
			For j As Integer = 0 To count - 1
				arr(index) = temp(j)
				index += 1
			Next j
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {1, 34, 7, 99, 5, 23, 45, 88, 77, 19, 91, 100}
		Dim maxValue As Integer = 100
		Dim b As New BucketSort()
		b.Sort(array, maxValue)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class

'
'1 5 7 19 23 34 45 77 88 91 99 100
' 