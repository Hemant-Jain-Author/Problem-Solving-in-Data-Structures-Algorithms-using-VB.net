Imports System

Public Class PriorityQueue(Of T As IComparable(Of T))
	Private Const CAPACITY As Integer = 16
	Private size As Integer ' Number of elements in PriorityQueue
	Private arr() As T ' The PriorityQueue array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal minHeap As Boolean = True)
		arr = New T(CAPACITY - 1) {}
		size = 0
		isMinHeap = minHeap
	End Sub

	Public Sub New(ByVal array() As T, Optional ByVal minHeap As Boolean = True)
		size = array.Length
		arr = New T(array.Length) {}
		size = array.Length
		isMinHeap = minHeap
		System.Array.Copy(array, 0, arr, 1, array.Length) 'we do not use 0 index

		'Build PriorityQueue operation over array
		For i As Integer = (size \ 2) To 1 Step -1
			proclateDown(i)
		Next i
	End Sub
	'Other Methods.

	Private Function comp(ByVal first As Integer, ByVal second As Integer) As Integer
		If isMinHeap Then
			Return arr(first).CompareTo(arr(second))
		Else
			Return arr(second).CompareTo(arr(first))
		End If
	End Function

	Private Sub proclateDown(ByVal position As Integer)
		Dim lChild As Integer = 2 * position
		Dim rChild As Integer = lChild + 1
		Dim small As Integer = -1
		Dim temp As T

		If lChild <= size Then
			small = lChild
		End If

		If rChild <= size AndAlso comp(rChild, lChild) < 0 Then
			small = rChild
		End If

		If small <> -1 AndAlso comp(small, position) < 0 Then
			temp = arr(position)
			arr(position) = arr(small)
			arr(small) = temp
			proclateDown(small)
		End If
	End Sub

	Private Sub proclateUp(ByVal position As Integer)
		Dim parent As Integer = position \ 2
		Dim temp As T
		If parent = 0 Then
			Return
		End If

		If comp(parent, position) > 0 Then 'parent grater then child.
			temp = arr(position)
			arr(position) = arr(parent)
			arr(parent) = temp
			proclateUp(parent)
		End If
	End Sub

	Public Overridable Sub add(ByVal value As T)
		If size = arr.Length - 1 Then
			doubleSize()
		End If

		size += 1
		arr(size) = value
		proclateUp(size)
	End Sub

	Private Sub doubleSize()
		Dim old() As T = arr
		arr = New T((arr.Length * 2) - 1) {}
		Array.Copy(old, 1, arr, 1, size)
	End Sub

	Public Overridable Function remove() As T
		If isEmpty() Then
			Throw New System.InvalidOperationException("HeapEmptyException")
		End If

		Dim value As T = arr(1)
		arr(1) = arr(size)
		size -= 1
		proclateDown(1)
		Return value
	End Function

	Public Overridable Sub print()
		Dim i As Integer = 1
		Do While i <= size + 1
			Console.Write("value is :: ")
			Console.WriteLine(arr(i))
			i += 1
		Loop
	End Sub

	Public Overridable Function isEmpty() As Boolean
		Return (size = 0)
	End Function

	Public Overridable Function peek() As T
		If isEmpty() Then
			Throw New System.InvalidOperationException("HeapEmptyException")
		End If
		Return arr(1)
	End Function

	Public Function length() As Integer
		Return size
	End Function

	Public Shared Sub Sort(ByVal array() As T)
		Dim hp As New PriorityQueue(Of T)(array)
		For i As Integer = 0 To array.Length - 1
			array(i) = hp.remove()
		Next i
	End Sub
End Class

Public Class PriorityQueueDemo
	Public Shared Sub Main333(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}
		Dim pq As New PriorityQueue(Of Integer)(arr, True)
		Console.WriteLine("Dequeue elements of priority queue ::")
		Do While pq.isEmpty() = False
			Console.WriteLine(pq.remove())
		Loop
	End Sub
End Class

Public Class MedianHeap
	Friend minHeap As PriorityQueue(Of Integer)
	Friend maxHeap As PriorityQueue(Of Integer)

	Public Sub New()
		minHeap = New PriorityQueue(Of Integer)()
		maxHeap = New PriorityQueue(Of Integer)(False)
	End Sub

	'Other Methods.


	Public Overridable Sub insert(ByVal value As Integer)
		If maxHeap.length() = 0 OrElse maxHeap.peek() >= value Then
			maxHeap.add(value)
		Else
			minHeap.add(value)
		End If

		'size balancing
		If maxHeap.length() > minHeap.length() + 1 Then
			value = maxHeap.remove()
			minHeap.add(value)
		End If

		If minHeap.length() > maxHeap.length() + 1 Then
			value = minHeap.remove()
			maxHeap.add(value)
		End If
		Console.WriteLine(" heap length " & maxHeap.length() & " & " & minHeap.length())
		If minHeap.length() > 0 Then
			Console.WriteLine(" heap top " & maxHeap.peek() & " & " & minHeap.peek())
		End If
	End Sub

	Public Overridable Function median() As Integer
		If maxHeap.length() = 0 AndAlso minHeap.length() = 0 Then
			Throw New System.InvalidOperationException("EmptyException")
		End If

		If maxHeap.length() = minHeap.length() Then
			Return (maxHeap.peek() + minHeap.peek()) / 2
		ElseIf maxHeap.length() > minHeap.length() Then
			Return maxHeap.peek()
		Else
			Return minHeap.peek()
		End If
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 9, 2, 8, 3, 7, 4, 6, 5, 1}
		Dim hp As New MedianHeap()

		For i As Integer = 0 To 9
			hp.insert(arr(i))
			Console.WriteLine("Median after insertion of " & arr(i) & " is  " & hp.median())
		Next i
	End Sub
End Class