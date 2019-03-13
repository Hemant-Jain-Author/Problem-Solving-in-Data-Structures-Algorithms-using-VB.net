Imports System

Public Class Heap
	Private Const CAPACITY As Integer = 32
	Private Count As Integer ' Number of elements in Heap
	Private arr() As Integer ' The Heap array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal isMin As Boolean = True)
		arr = New Integer(CAPACITY - 1) {}
		Count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As Integer, Optional ByVal isMin As Boolean = True)
		Count = array.Length
		arr = array
		isMinHeap = isMin
		' Build Heap operation over array
		For i As Integer = (Count \ 2) To 0 Step -1
			proclateDown(i)
		Next i
	End Sub
	' Other Methods.

	Private Function compare(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer) As Boolean
		If isMinHeap Then
			Return (arr(first) - arr(second)) > 0 ' Min heap compare
		Else
			Return (arr(first) - arr(second)) < 0 ' Max heap compare
		End If
	End Function

	Private Sub proclateDown(ByVal parent As Integer)
		Dim lChild As Integer = 2 * parent + 1
		Dim rChild As Integer = lChild + 1
		Dim child As Integer = -1
		Dim temp As Integer

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
		Dim temp As Integer
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

	Public Sub add(ByVal value As Integer)
		If Count = arr.Length Then
			doubleSize()
		End If
		arr(Count) = value
		Count += 1
		proclateUp(Count - 1)
	End Sub

	Private Sub doubleSize()
		Dim old() As Integer = arr
		arr = New Integer((arr.Length * 2) - 1) {}
		Array.Copy(old, 0, arr, 0, Count)
	End Sub

	Public Function remove() As Integer
		If Count = 0 Then
			Throw New System.InvalidOperationException()
		End If

		Dim value As Integer = arr(0)
		arr(0) = arr(Count - 1)
		Count -= 1
		proclateDown(0)
		Return value
	End Function

	Public Sub print()
		For i As Integer = 0 To Count - 1
			Console.Write(arr(i) & " ")
		Next i
	End Sub

	Public Function isEmpty() As Boolean
		Return (Count = 0)
	End Function

	Public Function size() As Integer
		Return Count
	End Function

	Public Function peek() As Integer
		If Count = 0 Then
			Throw New System.InvalidOperationException()
		End If
		Return arr(0)
	End Function

	Public Shared Sub heapSort(ByVal array() As Integer, ByVal inc As Boolean)
		Dim hp As New Heap(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.remove()
		Next i
	End Sub

End Class

Module Module1
	Public Sub Main(ByVal args() As String)
		Dim a() As Integer = {1, 9, 6, 7, 8, 0, 2, 4, 5, 3}
		Dim hp As New Heap(a, False)
		hp.add(100)
		hp.add(-1)
		hp.print()
		Console.WriteLine()

		Do While hp.isEmpty() = False
			Console.Write(hp.remove() & " ")
		Loop

		Console.WriteLine()
		Dim a1() As Integer = {1, 9, 6, 7, 8, 0, 2, 4, 5, 3}
		Heap.heapSort(a1, True)
		For i As Integer = 0 To a1.Length - 1
			Console.Write(a1(i) & " ")
		Next i
		Console.WriteLine()
		Dim a2() As Integer = {1, 9, 6, 7, 8, 0, 2, 4, 5, 3}
		Heap.heapSort(a2, False)
		For i As Integer = 0 To a2.Length - 1
			Console.Write(a2(i) & " ")
		Next i
	End Sub
End Module