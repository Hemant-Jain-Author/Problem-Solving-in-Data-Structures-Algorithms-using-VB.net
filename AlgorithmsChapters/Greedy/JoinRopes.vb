
Imports System

Public Class JoinRopes
	Public Shared Function Join(ByVal ropes() As Integer, ByVal size As Integer) As Integer
		Array.Sort(ropes)
		Dim i As Integer = 0
		Dim j As Integer = size - 1
		Do While i < j
			Dim temp As Integer = ropes(i)
			ropes(i) = ropes(j)
			ropes(j) = temp
			i += 1
			j -= 1
		Loop
		Dim total As Integer = 0
		Dim value As Integer = 0
		Dim index As Integer
		Dim length As Integer = size

		Do While length >= 2
			value = ropes(length - 1) + ropes(length - 2)
			total += value
			index = length - 2
			Do While index > 0 AndAlso ropes(index - 1) < value
				ropes(index) = ropes(index - 1)
				index -= 1
			Loop
			ropes(index) = value
			length -= 1
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Function Join2(ByVal ropes() As Integer, ByVal size As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)()
		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.Enqueue(ropes(i))
		Next i

		Dim total As Integer = 0
		Dim value As Integer = 0
		Do While pq.Size() > 1
			value = pq.Dequeue()
			value += pq.Dequeue()
			pq.Enqueue(value)
			total += value
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim ropes() As Integer = {4, 3, 2, 6}
		JoinRopes.Join(ropes, ropes.Length)
		Dim rope2() As Integer = {4, 3, 2, 6}
		JoinRopes.Join2(rope2, rope2.Length)
	End Sub

	'	
	' Total : 29 
	' Total : 29
	'	 
End Class


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
