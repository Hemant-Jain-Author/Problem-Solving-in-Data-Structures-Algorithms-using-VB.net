Imports System

Public Class MedianHeap
	Friend minHeap As PriorityQueue(Of Integer)
	Friend maxHeap As PriorityQueue(Of Integer)

	Public Sub New()
		minHeap = New PriorityQueue(Of Integer)()
		maxHeap = New PriorityQueue(Of Integer)(False)
	End Sub

	' Other Methods.
	Public Sub Add(ByVal value As Integer)
		If maxHeap.Size() = 0 OrElse maxHeap.Peek() >= value Then
			maxHeap.Enqueue(value)
		Else
			minHeap.Enqueue(value)
		End If

		' size balancing
		If maxHeap.Size() > minHeap.Size() + 1 Then
			value = maxHeap.Dequeue()
			minHeap.Enqueue(value)
		End If

		If minHeap.Size() > maxHeap.Size() + 1 Then
			value = minHeap.Dequeue()
			maxHeap.Enqueue(value)
		End If
	End Sub

	Public Function getMedian() As Integer
		If maxHeap.Size() = 0 AndAlso minHeap.Size() = 0 Then
			Return Integer.MaxValue
		End If

		If maxHeap.Size() = minHeap.Size() Then
			Return (maxHeap.Peek() + minHeap.Peek()) \ 2
		ElseIf maxHeap.Size() > minHeap.Size() Then
			Return maxHeap.Peek()
		Else
			Return minHeap.Peek()
		End If
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 9, 2, 8, 3, 7}
		Dim hp As New MedianHeap()

		For i As Integer = 0 To 5
			hp.Add(arr(i))
			Console.WriteLine("Median after addition of " & arr(i) & " is  " & hp.getMedian())
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


Public Class PriorityQueue(Of T As IComparable(Of T))
	Private Capacity As Integer = 100
	Private count As Integer ' Number of elements in Heap
	Private arr() As T ' The Heap array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal isMin As Boolean = True)
		arr = New T(Capacity) {}
		count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
		Capacity = array.Length
		count = array.Length
		arr = array
		isMinHeap = isMin
		For i As Integer = (count \ 2) To 0 Step -1
			PercolateDown(i)
		Next i
	End Sub

	' Other Methods.
	Private Function Compare(ByVal arr() As T, ByVal first As Integer, ByVal second As Integer) As Boolean
		If isMinHeap Then
			Return arr(first).CompareTo(arr(second)) > 0
		Else
			Return arr(first).CompareTo(arr(second)) < 0
		End If
	End Function

	Private Sub PercolateDown(ByVal parent As Integer)
		Dim lChild As Integer = 2 * parent + 1
		Dim rChild As Integer = lChild + 1
		Dim child As Integer = -1
		Dim temp As T

		If lChild < count Then
			child = lChild
		End If

		If rChild < count AndAlso Compare(arr, lChild, rChild) Then
			child = rChild
		End If

		If child <> -1 AndAlso Compare(arr, parent, child) Then
			temp = arr(parent)
			arr(parent) = arr(child)
			arr(child) = temp
			PercolateDown(child)
		End If
	End Sub

	Private Sub PercolateUp(ByVal child As Integer)
		Dim parent As Integer = (child - 1) \ 2
		Dim temp As T
		If parent < 0 Then
			Return
		End If

		If Compare(arr, parent, child) Then
			temp = arr(child)
			arr(child) = arr(parent)
			arr(parent) = temp
			PercolateUp(parent)
		End If
	End Sub

	Public Sub Enqueue(ByVal value As T)
		If count = Capacity Then
			DoubleSize()
		End If

		arr(count) = value
		count += 1
		PercolateUp(count - 1)
	End Sub

	Private Sub DoubleSize()
		Dim old() As T = arr
		arr = New T(Capacity * 2) {}
		Capacity = Capacity * 2
		For i As Integer = 0 To count - 1
			arr(i) = old(i)
		Next i
	End Sub

	Public Function Dequeue() As T
		If count = 0 Then
			Throw New System.InvalidOperationException()
		End If

		Dim value As T = arr(0)
		arr(0) = arr(count - 1)
		count -= 1
		PercolateDown(0)
		Return value
	End Function

	Public Sub Print()
		For i As Integer = 0 To count - 1
			Console.Write(arr(i))
			Console.Write(" ")
		Next i
		Console.WriteLine()
	End Sub

	Public Function IsEmpty() As Boolean
		Return (count = 0)
	End Function

	Public Function Size() As Integer
		Return count
	End Function

	Public Function Peek() As T
		If count = 0 Then
			Throw New System.InvalidOperationException()
		End If
		Return arr(0)
	End Function

	Friend Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
		' Create max heap for increasing order sorting.
		Dim hp As New PriorityQueue(Of Integer)(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.Dequeue()
		Next i
	End Sub
End Class


