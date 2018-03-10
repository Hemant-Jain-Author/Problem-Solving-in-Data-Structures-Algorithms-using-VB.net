Imports System

Public Class MedianHeap
	Friend minHeap As PriorityQueue(Of Integer)
	Friend maxHeap As PriorityQueue(Of Integer)

	Public Sub New()
		minHeap = New PriorityQueue(Of Integer)()
		maxHeap = New PriorityQueue(Of Integer)(Collections.reverseOrder())
	End Sub

	'Other Methods.

	Public Sub insert(ByVal value As Integer)
		If maxHeap.size() = 0 OrElse maxHeap.peek() >= value Then
			maxHeap.add(value)
		Else
			minHeap.add(value)
		End If

		'size balancing
		If maxHeap.size() > minHeap.size() + 1 Then
			value = maxHeap.remove()
			minHeap.add(value)
		End If

		If minHeap.size() > maxHeap.size() + 1 Then
			value = minHeap.remove()
			maxHeap.add(value)
		End If
	End Sub

	Public Function median() As Integer
		If maxHeap.size() = 0 AndAlso minHeap.size() = 0 Then
			Throw New System.InvalidOperationException("EmptyException")
		End If

		If maxHeap.size() = minHeap.size() Then
			Return (maxHeap.peek() + minHeap.peek()) / 2
		ElseIf maxHeap.size() > minHeap.size() Then
			Return maxHeap.peek()
		Else
			Return minHeap.peek()
		End If
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 9, 2, 8, 3, 7, 4, 6, 5, 1, 9, 2, 8, 3, 7, 4, 6, 5, 10, 10}
		Dim hp As New MedianHeap()

		For i As Integer = 0 To 19
			hp.insert(arr(i))
			Console.WriteLine("Median after insertion of " & arr(i) & " is  " & hp.median())
		Next i
	End Sub
End Class

