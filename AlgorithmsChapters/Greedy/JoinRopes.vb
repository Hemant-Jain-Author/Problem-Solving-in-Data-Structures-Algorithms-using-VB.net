
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
			pq.add(ropes(i))
		Next i

		Dim total As Integer = 0
		Dim value As Integer = 0
		Do While pq.size() > 1
			value = pq.remove()
			value += pq.remove()
			pq.add(value)
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
	Private CAPACITY As Integer = 100
	Private Count As Integer ' Number of elements in Heap
	Private arr() As T ' The Heap array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal isMin As Boolean = True)
		arr = New T(CAPACITY) {}
		Count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
		CAPACITY = array.Length
		Count = array.Length
		arr = array
		isMinHeap = isMin
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
		If Count = CAPACITY Then
			doubleSize()
		End If

		arr(Count) = value
		Count += 1
		proclateUp(Count - 1)
	End Sub

	Private Sub doubleSize()
		Dim old() As T = arr
		arr = New T(CAPACITY * 2) {}
		CAPACITY = CAPACITY * 2
		For i As Integer = 0 To Count - 1
			arr(i) = old(i)
		Next i
		' Array.Copy(old, 0, arr, 0, Count)
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
			Console.Write(" ")
		Next i
		Console.WriteLine()
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

	Friend Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
		' Create max heap for increasing order sorting.
		Dim hp As New PriorityQueue(Of Integer)(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.remove()
		Next i
	End Sub
End Class

