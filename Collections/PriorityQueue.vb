Imports System

Public Class PriorityQueue(Of T As IComparable(Of T))
	Private Const CAPACITY As Integer = 32
	Private Count As Integer ' Number of elements in Heap
	Private arr() As T ' The Heap array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal isMin As Boolean = True)
		arr = New T(CAPACITY - 1) {}
		Count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
		Count = array.Length
		arr = array
		isMinHeap = isMin
		' Build Heap operation over array
		For i As Integer = (Count \ 2) To 0 Step -1
			proclateDown(i)
		Next i
	End Sub

	' Other Methods.
	Private Function compare(ByVal arr() As T, ByVal first As Integer, ByVal second As Integer) As Boolean
		If isMinHeap Then
			Return arr(first).CompareTo(arr(second)) > 0
		Else
			Return arr(first).CompareTo(arr(second)) < 0
		End If
	End Function

	Private Sub proclateDown(ByVal parent As Integer)
		Dim lChild As Integer = 2 * parent + 1
		Dim rChild As Integer = lChild + 1
		Dim child As Integer = -1
		Dim temp As T

		If lChild < Count Then
			child = lChild
		End If

		If rChild < Count AndAlso compare(arr, lChild, rChild) Then
			child = rChild
		End If

		If child <> -1 AndAlso compare(arr, parent, child) Then
			temp = arr(parent)
			arr(parent) = arr(child)
			arr(child) = temp
			proclateDown(child)
		End If
	End Sub

	Private Sub proclateUp(ByVal child As Integer)
		Dim parent As Integer = (child - 1) \ 2
		Dim temp As T
		If parent < 0 Then
			Return
		End If

		If compare(arr, parent, child) Then
			temp = arr(child)
			arr(child) = arr(parent)
			arr(parent) = temp
			proclateUp(parent)
		End If
	End Sub

	Public Sub add(ByVal value As T)
		If Count = arr.Length Then
			doubleSize()
		End If

		'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
		'ORIGINAL LINE: arr[Count++] = value;
		arr(Count) = value
		Count += 1
		proclateUp(Count - 1)
	End Sub

	Private Sub doubleSize()
		Dim old() As T = arr
		arr = New T((arr.Length * 2) - 1) {}
		Array.Copy(old, 0, arr, 0, Count)
	End Sub

	Public Function remove() As T
		If Count = 0 Then
			Throw New System.InvalidOperationException()
		End If

		Dim value As T = arr(0)
		arr(0) = arr(Count - 1)
		Count -= 1
		proclateDown(0)
		Return value
	End Function

	Public Sub print()
		For i As Integer = 0 To Count - 1
			Console.Write(arr(i))
		Next i
	End Sub

	Public Function isEmpty() As Boolean
		Return (Count = 0)
	End Function

	Public Function size() As Integer
		Return Count
	End Function

	Public Function peek() As T
		If Count = 0 Then
			Throw New System.InvalidOperationException()
		End If
		Return arr(0)
	End Function

	Public Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
		' Create max heap for increasing order sorting.
		Dim hp As New PriorityQueue(Of Integer)(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.remove()
		Next i
	End Sub
End Class

Public Class PQDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim a() As Integer = {1, 9, 6, 7, 8, 0, 2, 4, 5, 3}
		Dim hp As New PriorityQueue(Of Integer)(a, True)
		hp.print()
		Console.WriteLine()
		Do While hp.isEmpty() = False
			Console.Write(hp.remove() & " ")
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
			Return (maxHeap.peek() + minHeap.peek()) \ 2
		ElseIf maxHeap.size() > minHeap.size() Then
			Return maxHeap.peek()
		Else
			Return minHeap.peek()
		End If
	End Function
End Class

Module Module1
	Public Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 9, 2, 8, 3, 7, 4, 6, 5, 1}
		Dim hp As New MedianHeap()

		For i As Integer = 0 To 9
			hp.insert(arr(i))
			Console.WriteLine("Median after insertion of " & arr(i) & " is  " & hp.median())
		Next i
	End Sub
End Module