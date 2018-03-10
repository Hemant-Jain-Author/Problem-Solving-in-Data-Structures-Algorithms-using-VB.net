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

	Public Overridable Sub Enqueue(ByVal value As T)
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

	Public Overridable Function Dequeue() As T
		If isEmpty() Then
			Throw New System.InvalidOperationException("HeapEmptyException")
		End If

		Dim value As T = arr(1)
		arr(1) = arr(size)
		size -= 1
		proclateDown(1)
		Return value
	End Function

	Public Overridable Sub Print()
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

	Public Overridable Function Peek() As T
		If isEmpty() Then
			Throw New System.InvalidOperationException("HeapEmptyException")
		End If
		Return arr(1)
	End Function

	Public ReadOnly Property Count() As Integer
		Get
			Return size
		End Get

	End Property

	Public Shared Sub Sort(ByVal array() As T)
		Dim hp As New PriorityQueue(Of T)(array)
		For i As Integer = 0 To array.Length - 1
			array(i) = hp.Dequeue()
		Next i
	End Sub
End Class
