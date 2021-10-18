
Imports System

Public Class HeapEx

	Public Shared Sub Demo(ByVal args() As String)
		Dim pq As New PriorityQueue(Of Integer)()
		Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}

		For Each i As Integer In arr
			pq.add(i)
		Next i
		Console.WriteLine("Printing Priority Queue Heap : " & pq)

		Console.Write("Dequeue elements of Priority Queue ::")
		Do While pq.isEmpty() = False
			Console.Write(" " & pq.remove())
		Loop
	End Sub

	Public Shared Function KthSmallest(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Array.Sort(arr)
		Return arr(k - 1)
	End Function

	Public Shared Function KthSmallest2(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)()
		For i As Integer = 0 To size - 1
			pq.add(arr(i))
		Next i
		Dim i As Integer = 0
		Do While i < k - 1
			pq.remove()
			i += 1
		Loop
		Return pq.peek()
	End Function

	Public Shared Function KthSmallest3(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)(Collections.reverseOrder())
		For i As Integer = 0 To size - 1
			If i < k Then
				pq.add(arr(i))
			Else
				If pq.peek() > arr(i) Then
					pq.add(arr(i))
					pq.remove()
				End If
			End If
		Next i
		Return pq.peek()
	End Function

	Public Shared Function KthLargest(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim value As Integer = 0
		Dim pq As New PriorityQueue(Of Integer)(Collections.reverseOrder())
		For i As Integer = 0 To size - 1
			pq.add(arr(i))
		Next i
		For i As Integer = 0 To k - 1
			value = pq.remove()
		Next i
		Return value
	End Function

	Public Shared Function IsMinHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim lchild, rchild As Integer
		' last element index size - 1
		Dim parent As Integer = 0
		Do While parent < (size \ 2 + 1)
			lchild = parent * 2 + 1
			rchild = parent * 2 + 2
			' heap property check.
			If ((lchild < size) AndAlso (arr(parent) > arr(lchild))) OrElse ((rchild < size) AndAlso (arr(parent) > arr(rchild))) Then
				Return False
			End If
			parent += 1
		Loop
		Return True
	End Function

	Public Shared Function IsMaxHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim lchild, rchild As Integer
		' last element index size - 1
		Dim parent As Integer = 0
		Do While parent < (size \ 2 + 1)
			lchild = parent * 2 + 1
			rchild = lchild + 1
			' heap property check.
			If ((lchild < size) AndAlso (arr(parent) < arr(lchild))) OrElse ((rchild < size) AndAlso (arr(parent) < arr(rchild))) Then
				Return False
			End If
			parent += 1
		Loop
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
'	IsMaxHeap :: true
'	IsMinHeap :: true     
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

		Do While lower < upper
			Do While lower < upper AndAlso arr(lower) <= pivot
				lower += 1
			Loop
			Do While lower <= upper AndAlso arr(upper) > pivot
				upper -= 1
			Loop
			If lower < upper Then
				Swap(arr, upper, lower)
			End If
		Loop

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
			pq.add(arr(i))
		Next i
		i = 0
		Do While i < size AndAlso i < k
			product *= pq.remove()
			i += 1
		Loop
		Return product
	End Function

	Public Shared Function KSmallestProduct4(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)(Collections.reverseOrder())
		For i As Integer = 0 To size - 1
			If i < k Then
				pq.add(arr(i))
			Else
				If pq.peek() > arr(i) Then
					pq.add(arr(i))
					pq.remove()
				End If
			End If
		Next i
		Dim product As Integer = 1
		For i As Integer = 0 To k - 1
			product *= pq.remove()
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
'	 * Kth Smallest product:: 10 
'	 * Kth Smallest product:: 10 
'	 * Kth Smallest product:: 10
'	 * Kth Smallest product:: 10
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
		For i As Integer = 0 To size - 1
			pq.add(arr(i))
		Next i

		Dim i As Integer = 0
		Do While i < size \ 2
			pq.remove()
			i += 1
		Loop
		Console.WriteLine(pq)
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
'	 * 6 7 7 8 
'	 * [6, 7, 7, 8] 
'	 * 6 7 7 8
'	 

	Public Shared Sub SortK(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim pq As New PriorityQueue(Of Integer)()
		Dim i As Integer = 0
		For i = 0 To k - 1
			pq.add(arr(i))
		Next i

		Dim output(size - 1) As Integer
		Dim index As Integer = 0

		For i = k To size - 1

			output(index) = pq.remove()
			index += 1
			pq.add(arr(i))
		Next i
		Do While pq.size() > 0

			output(index) = pq.remove()
			index += 1
		Loop

		For i = k To size - 1
			arr(i) = output(i)
		Next i
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
'	 * 1 5 4 9 10 50
'	 
	Public Shared Sub Main(ByVal args() As String)
		Main2()
	End Sub
End Class

