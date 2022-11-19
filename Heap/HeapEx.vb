
Imports System

Public Class HeapEx

	Public Shared Sub Demo(ByVal args() As String)
		Dim pq As New PriorityQueue(Of Integer)()
		Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}

		For Each i As Integer In arr
			pq.Enqueue(i)
		Next i
		Console.WriteLine("Printing Priority Queue Heap : ")
		pq.Print()

		Console.Write("Dequeue elements of Priority Queue ::")
		While pq.IsEmpty() = False
			Console.Write(" " & pq.Dequeue())
		End While
	End Sub

	Public Shared Function KthSmallest(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Array.Sort(arr)
		Return arr(k - 1)
	End Function

	Public Shared Function KthSmallest2(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)()
		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.Enqueue(arr(i))
		Next i

		i = 0
		While i < k - 1
			pq.Dequeue()
			i += 1
		End While
		Return pq.Peek()
	End Function

	Public Shared Function KthSmallest3(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)(False)
		For i As Integer = 0 To size - 1
			If i < k Then
				pq.Enqueue(arr(i))
			Else
				If pq.Peek() > arr(i) Then
					pq.Enqueue(arr(i))
					pq.Dequeue()
				End If
			End If
		Next i
		Return pq.Peek()
	End Function

	Public Shared Function KthLargest(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim value As Integer = 0
		Dim pq As New PriorityQueue(Of Integer)(False)
		For i As Integer = 0 To size - 1
			pq.Enqueue(arr(i))
		Next i
		For i As Integer = 0 To k - 1
			value = pq.Dequeue()
		Next i
		Return value
	End Function

	Public Shared Function IsMinHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim lchild, rchild As Integer
		' last element index size - 1
		Dim parent As Integer = 0
		While parent < (size \ 2 + 1)
			lchild = parent * 2 + 1
			rchild = parent * 2 + 2
			' heap property check.
			If ((lchild < size) AndAlso (arr(parent) > arr(lchild))) OrElse ((rchild < size) AndAlso (arr(parent) > arr(rchild))) Then
				Return False
			End If
			parent += 1
		End While
		Return True
	End Function

	Public Shared Function IsMaxHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim lchild, rchild As Integer
		' last element index size - 1
		Dim parent As Integer = 0
		While parent < (size \ 2 + 1)
			lchild = parent * 2 + 1
			rchild = lchild + 1
			' heap property check.
			If ((lchild < size) AndAlso (arr(parent) < arr(lchild))) OrElse ((rchild < size) AndAlso (arr(parent) < arr(rchild))) Then
				Return False
			End If
			parent += 1
		End While
		Return True
	End Function

	Public Shared Sub Main0(ByVal args() As String)
		Dim arr() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("Kth Smallest :: " & KthSmallest(arr, arr.Length, 3))
		Dim arr2() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("Kth Smallest :: " & KthSmallest2(arr2, arr2.Length, 3))
	End Sub
	'	
	'	Kth Smallest :: 5
	'	Kth Smallest :: 5
	'	

	Public Shared Sub Main1()
		Dim arr3() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("IsMaxHeap :: " & IsMaxHeap(arr3, arr3.Length))
		Dim arr4() As Integer = {1, 2, 3, 4, 5, 6, 7, 8}
		Console.WriteLine("IsMinHeap :: " & IsMinHeap(arr4, arr4.Length))
	End Sub

	'	
	'	IsMaxHeap :: True
	'	IsMinHeap :: True     
	'	
	Public Shared Function KSmallestProduct(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Array.Sort(arr)
		Dim product As Integer = 1
		For i As Integer = 0 To k - 1
			product *= arr(i)
		Next i
		Return product
	End Function

	Public Shared Sub Swap(ByVal arr() As Integer, ByVal i As Integer, ByVal j As Integer)
		Dim temp As Integer = arr(i)
		arr(i) = arr(j)
		arr(j) = temp
	End Sub

	Public Shared Sub QuickSelectUtil(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer, ByVal k As Integer)
		If upper <= lower Then
			Return
		End If

		Dim pivot As Integer = arr(lower)
		Dim start As Integer = lower
		Dim finish As Integer = upper

		While lower < upper
			While lower < upper AndAlso arr(lower) <= pivot
				lower += 1
			End While
			While lower <= upper AndAlso arr(upper) > pivot
				upper -= 1
			End While
			If lower < upper Then
				Swap(arr, upper, lower)
			End If
		End While

		Swap(arr, upper, start) ' upper is the pivot position
		If k < upper Then
			QuickSelectUtil(arr, start, upper - 1, k) ' pivot -1 is the upper for left sub array.
		End If
		If k > upper Then
			QuickSelectUtil(arr, upper + 1, finish, k) ' pivot + 1 is the lower for right sub array.
		End If
	End Sub

	Public Shared Function KSmallestProduct3(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		QuickSelectUtil(arr, 0, size - 1, k)
		Dim product As Integer = 1
		For i As Integer = 0 To k - 1
			product *= arr(i)
		Next i
		Return product
	End Function

	Public Shared Function KSmallestProduct2(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)()
		Dim i As Integer = 0
		Dim product As Integer = 1
		For i = 0 To size - 1
			pq.Enqueue(arr(i))
		Next i
		i = 0
		While i < size AndAlso i < k
			product *= pq.Dequeue()
			i += 1
		End While
		Return product
	End Function

	Public Shared Function KSmallestProduct4(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)(False)
		For i As Integer = 0 To size - 1
			If i < k Then
				pq.Enqueue(arr(i))
			Else
				If pq.Peek() > arr(i) Then
					pq.Enqueue(arr(i))
					pq.Dequeue()
				End If
			End If
		Next i
		Dim product As Integer = 1
		For i As Integer = 0 To k - 1
			product *= pq.Dequeue()
		Next i
		Return product
	End Function

	Public Shared Sub Main2()
		Dim arr() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("Kth Smallest product:: " & KSmallestProduct(arr, 8, 3))
		Dim arr2() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("Kth Smallest product:: " & KSmallestProduct2(arr2, 8, 3))
		Dim arr3() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("Kth Smallest product:: " & KSmallestProduct3(arr3, 8, 3))
		Dim arr4() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		Console.WriteLine("Kth Smallest product:: " & KSmallestProduct4(arr4, 8, 3))
	End Sub

	'	
	' Kth Smallest product:: 10 
	' Kth Smallest product:: 10 
	' Kth Smallest product:: 10
	' Kth Smallest product:: 10
	'	 


	Public Shared Sub PrintLargerHalf(ByVal arr() As Integer, ByVal size As Integer)
		Array.Sort(arr)
		For i As Integer = size \ 2 To size - 1
			Console.Write(arr(i) & " ")
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub PrintLargerHalf2(ByVal arr() As Integer, ByVal size As Integer)
		Dim pq As New PriorityQueue(Of Integer)()

		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.Enqueue(arr(i))
		Next i

		i = 0
		While i < size \ 2
			pq.Dequeue()
			i += 1
		End While
		pq.Print()
	End Sub

	Public Shared Sub PrintLargerHalf3(ByVal arr() As Integer, ByVal size As Integer)
		QuickSelectUtil(arr, 0, size - 1, size \ 2)
		For i As Integer = size \ 2 To size - 1
			Console.Write(arr(i) & " ")
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub Main3()
		Dim arr() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		PrintLargerHalf(arr, 8)
		Dim arr2() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		PrintLargerHalf2(arr2, 8)
		Dim arr3() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
		PrintLargerHalf3(arr3, 8)
	End Sub

	'	
	' 6 7 7 8 
	' 6 7 7 8 
	' 6 7 7 8
	'	 

	Public Shared Sub SortK(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim pq As New PriorityQueue(Of Integer)()

		Dim i As Integer = 0
		For i = 0 To k - 1
			pq.Enqueue(arr(i))
		Next i

		Dim index As Integer = 0
		For i = k To size - 1

			arr(index) = pq.Dequeue()
			index += 1
			pq.Enqueue(arr(i))
		Next i

		While pq.Size() > 0

			arr(index) = pq.Dequeue()
			index += 1
		End While
	End Sub

	' Testing Code
	Public Shared Sub Main4()
		Dim k As Integer = 3
		Dim arr() As Integer = {1, 5, 4, 10, 50, 9}
		Dim size As Integer = arr.Length
		SortK(arr, size, k)
		For i As Integer = 0 To size - 1
			Console.Write(arr(i) & " ")
		Next i
	End Sub
	'	
	' 1 5 4 9 10 50
	'	 
	Public Shared Sub Main(ByVal args() As String)
		Main1()
		Main2()
		Main3()
		Main4()
	End Sub
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


