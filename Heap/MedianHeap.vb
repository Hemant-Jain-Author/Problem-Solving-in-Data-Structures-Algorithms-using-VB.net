Imports System

Public Class MedianHeap
	Friend minHeap As PriorityQueue(Of Integer)
	Friend maxHeap As PriorityQueue(Of Integer)

	Public Sub New()
		minHeap = New PriorityQueue(Of Integer)()
		maxHeap = New PriorityQueue(Of Integer)(Collections.reverseOrder())
	End Sub

	' Other Methods.
	Public Sub add(ByVal value As Integer)
		If maxHeap.size() = 0 OrElse maxHeap.peek() >= value Then
			maxHeap.add(value)
		Else
			minHeap.add(value)
		End If

		' size balancing
		If maxHeap.size() > minHeap.size() + 1 Then
			value = maxHeap.remove()
			minHeap.add(value)
		End If

		If minHeap.size() > maxHeap.size() + 1 Then
			value = minHeap.remove()
			maxHeap.add(value)
		End If
	End Sub

	Public ReadOnly Property Median() As Integer
		Get
			If maxHeap.size() = 0 AndAlso minHeap.size() = 0 Then
				Return Integer.MaxValue
			End If

			If maxHeap.size() = minHeap.size() Then
				Return (maxHeap.peek() + minHeap.peek()) \ 2
			ElseIf maxHeap.size() > minHeap.size() Then
				Return maxHeap.peek()
			Else
				Return minHeap.peek()
			End If
		End Get
	End Property

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 9, 2, 8, 3, 7}
		Dim hp As New MedianHeap()

		For i As Integer = 0 To 5
			hp.add(arr(i))
			Console.WriteLine("Median after addition of " & arr(i) & " is  " & hp.Median)
		Next i
	End Sub
End Class

'
' * Median after addition of 1 is 1 
' * Median after addition of 9 is 5 
' * Median after addition of 2 is 2 
' * Median after addition of 8 is 5 
' * Median after addition of 3 is 3 
' * Median after addition of 7 is 5
' 