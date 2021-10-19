
Imports System

Public Class Heap
	Private Const CAPACITY As Integer = 32
	Private count As Integer ' Number of elements in Heap
	Private arr() As Integer ' The Heap array
	Friend isMinHeap As Boolean

	Public Sub New(ByVal isMin As Boolean)
		arr = New Integer(CAPACITY - 1) {}
		count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As Integer, ByVal isMin As Boolean)
		count = array.Length
		arr = array
		isMinHeap = isMin
		' Build Heap operation over array
		For i As Integer = (count \ 2) To 0 Step -1
			PercolateDown(i)
		Next i
	End Sub

	' Other Methods.
	Friend Function Compare(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer) As Boolean
		If isMinHeap Then
			Return (arr(first) - arr(second)) > 0 ' Min heap compare
		Else
			Return (arr(first) - arr(second)) < 0 ' Max heap compare
		End If
	End Function

	Private Sub PercolateDown(ByVal parent As Integer)
		Dim lChild As Integer = 2 * parent + 1
		Dim rChild As Integer = lChild + 1
		Dim child As Integer = -1
		Dim temp As Integer

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
		Dim temp As Integer
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

	Public Sub Add(ByVal value As Integer)
		If count = arr.Length Then
			DoubleSize()
		End If

		arr(count) = value
		count += 1
		PercolateUp(count - 1)
	End Sub

	Private Sub DoubleSize()
		Dim old() As Integer = arr
		arr = New Integer((arr.Length * 2) - 1) {}
		Array.Copy(old, 0, arr, 0, count)
	End Sub

	Public Function Remove() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException()
		End If

		Dim value As Integer = arr(0)
		arr(0) = arr(count - 1)
		count -= 1
		PercolateDown(0)
		Return value
	End Function

	Public Sub Print()
		For i As Integer = 0 To count - 1
			Console.Write(arr(i) & " ")
		Next i
	End Sub

	Public Function Delete(ByVal value As Integer) As Boolean
		Dim i As Integer = 0
		Do While i < count
			If arr(i) = value Then
				arr(i) = arr(count - 1)
				count -= 1
				PercolateDown(i)
				Return True
			End If
			i += 1
		Loop
		Return False
	End Function


	Public Function IsEmpty() As Boolean
		Return count = 0
	End Function

	Public Function Size1() As Integer
		Return count
	End Function

	Public Function Peek() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException()
		End If
		Return arr(0)
	End Function

	Public Shared Sub main1()
		Dim a() As Integer = {1, 9, 6, 7, 8, 2, 4, 5, 3}
		Dim hp As New Heap(a, True)
		hp.Print()
		Console.WriteLine()
		hp.Delete(5)
		hp.Print()
		Console.WriteLine()
	End Sub

	'	
	'	1 3 2 5 8 6 4 9 7
	'	1 3 2 7 8 6 4 9
	'

	Public Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
		' Create max heap for increasing order sorting.
		Dim hp As New Heap(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.Remove()
		Next i
	End Sub

	Public Shared Sub main2()
		Dim a2() As Integer = {1, 9, 6, 7, 8, 2, 4, 5, 3}
		Heap.HeapSort(a2, True)
		For i As Integer = 0 To a2.Length - 1
			Console.Write(a2(i) & " ")
		Next i
		Console.WriteLine()

		Dim a3() As Integer = {1, 9, 6, 7, 8, 2, 4, 5, 3}
		Heap.HeapSort(a3, False)
		For i As Integer = 0 To a3.Length - 1
			Console.Write(a3(i) & " ")
		Next i
	End Sub

	'	
	'	1 2 3 4 5 6 7 8 9 
	'	9 8 7 6 5 4 3 2 1
	'	

	Public Shared Sub Main(ByVal args() As String)
		main1()
		main2()
	End Sub
End Class