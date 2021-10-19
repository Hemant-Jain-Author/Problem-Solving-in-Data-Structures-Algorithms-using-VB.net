﻿Imports System

Public Class PriorityQueueDemo
	Public Shared Sub Main(ByVal args() As String)

		Dim pq As New PriorityQueue(Of Integer)()
		Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}
		For Each i As Integer In arr
			pq.add(i)
		Next i

		Console.Write("Heap Array: ")
		pq.print()
		Do While pq.isEmpty() = False
			Console.Write(pq.remove() & " ")
		Loop
		Console.WriteLine()

		pq = New PriorityQueue(Of Integer)(False)
		For Each i As Integer In arr
			pq.add(i)
		Next i

		Console.Write("Heap Array: ")
		pq.print()
		Do While pq.isEmpty() = False
			Console.Write(pq.remove() & " ")
		Loop
	End Sub
End Class


' Heap Array :  1 2 3 5 7 10 4 8 6 9
' 1 2 3 4 5 6 7 8 9 10
' Heap Array :  10 9 4 6 8 2 3 1 5 7
' 10 9 8 7 6 5 4 3 2 1


Public Class PriorityQueue(Of T As IComparable(Of T))
	Private CAPACITY As Integer = 100
	Private count As Integer ' Number of elements in Heap
	Private arr() As T ' The Heap array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal isMin As Boolean = True)
		arr = New T(CAPACITY) {}
		count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
		CAPACITY = array.Length
		count = array.Length
		arr = array
		isMinHeap = isMin
		For i As Integer = (count \ 2) To 0 Step -1
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

		If lChild < count Then
			child = lChild
		End If

		If rChild < count AndAlso compare(arr, lChild, rChild) Then
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
		If count = CAPACITY Then
			doubleSize()
		End If

		arr(count) = value
		count += 1
		proclateUp(count - 1)
	End Sub

	Private Sub doubleSize()
		Dim old() As T = arr
		arr = New T(CAPACITY * 2) {}
		CAPACITY = CAPACITY * 2
		For i As Integer = 0 To count - 1
			arr(i) = old(i)
		Next i
		' Array.Copy(old, 0, arr, 0, count)
	End Sub

	Public Function remove() As T
		If count = 0 Then
			Throw New System.InvalidOperationException()
		End If

		Dim value As T = arr(0)
		arr(0) = arr(count - 1)
		count -= 1
		proclateDown(0)
		Return value
	End Function

	Public Sub print()
		For i As Integer = 0 To count - 1
			Console.Write(arr(i))
			Console.Write(" ")
		Next i
		Console.WriteLine()
	End Sub

	Public Function isEmpty() As Boolean
		Return (count = 0)
	End Function

	Public Function size() As Integer
		Return count
	End Function

	Public Function peek() As T
		If count = 0 Then
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


