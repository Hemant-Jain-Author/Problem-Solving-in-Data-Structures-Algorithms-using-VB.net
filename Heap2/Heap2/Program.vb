Imports System

Public Class Heap

	Private Const CAPACITY As Integer = 16
	Private size As Integer ' Number of elements in heap
	Private arr() As Integer ' The heap array

	Public Sub New()
		arr = New Integer(CAPACITY - 1) {}
		size = 0
	End Sub

	Public Sub New(ByVal array() As Integer)
		size = array.Length
		arr = New Integer(array.Length) {}
		System.Array.Copy(array, 0, arr, 1, array.Length) 'we do not use 0 index

		'Build Heap operation over array
		For i As Integer = (size \ 2) To 1 Step -1
			proclateDown(i)
		Next i
	End Sub
	'Other Methods.


	Private Sub proclateDown(ByVal position As Integer)
		Dim lChild As Integer = 2 * position
		Dim rChild As Integer = lChild + 1
		Dim small As Integer = -1
		Dim temp As Integer

		If lChild <= size Then
			small = lChild
		End If

		If rChild <= size AndAlso (arr(rChild) - arr(lChild)) < 0 Then
			small = rChild
		End If

		If small <> -1 AndAlso (arr(small) - arr(position)) < 0 Then
			temp = arr(position)
			arr(position) = arr(small)
			arr(small) = temp
			proclateDown(small)
		End If
	End Sub

	Private Sub proclateUp(ByVal position As Integer)
		Dim parent As Integer = position \ 2
		Dim temp As Integer
		If parent = 0 Then
			Return
		End If

		If (arr(parent) - arr(position)) < 0 Then
			temp = arr(position)
			arr(position) = arr(parent)
			arr(parent) = temp
			proclateUp(parent)
		End If
	End Sub

	Public Sub add(ByVal value As Integer)
		If size = arr.Length - 1 Then
			doubleSize()
		End If
		size += 1
		arr(size) = value
		proclateUp(size)
	End Sub

	Private Sub doubleSize()
		Dim old() As Integer = arr
		arr = New Integer((arr.Length * 2) - 1) {}
		Array.Copy(old, 1, arr, 1, size)
	End Sub

	Public Function remove() As Integer
		If isEmpty() Then
			Throw New System.InvalidOperationException("HeapEmptyException")
		End If

		Dim value As Integer = arr(1)
		arr(1) = arr(size)
		size -= 1
		proclateDown(1)
		Return value
	End Function

	Public Sub print()
		For i As Integer = 1 To size
			Console.WriteLine("value is :: " & arr(i))
		Next i
	End Sub

	Friend Function IsMinHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim i As Integer = 0
		Do While i <= (size - 2) \ 2
			If 2 * i + 1 < size Then
				If arr(i) > arr(2 * i + 1) Then
					Return False
				End If
			End If
			If 2 * i + 2 < size Then
				If arr(i) > arr(2 * i + 2) Then
					Return False
				End If
			End If
			i += 1
		Loop
		Return True
	End Function

	Friend Function IsMaxHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim i As Integer = 0
		Do While i <= (size - 2) \ 2
			If 2 * i + 1 < size Then
				If arr(i) < arr(2 * i + 1) Then
					Return False
				End If
			End If
			If 2 * i + 2 < size Then
				If arr(i) < arr(2 * i + 2) Then
					Return False
				End If
			End If
			i += 1
		Loop
		Return True
	End Function

	Public Function isEmpty() As Boolean
		Return (size = 0)
	End Function

	Public Function peek() As Integer
		If isEmpty() Then
			Throw New System.InvalidOperationException("HeapEmptyException")
		End If
		Return arr(1)
	End Function

	Public Shared Sub heapSort(ByVal array() As Integer)
		Dim hp As New Heap(array)
		For i As Integer = 0 To array.Length - 1
			array(i) = hp.remove()
		Next i
	End Sub
End Class

Public Shared Sub Main(ByVal args() As String)
	Dim a() As Integer = {4, 5, 3}

	Dim arr() As Integer = {1, 9, 2, 8, 3, 7, 4, 6, 5, 1}
	Dim hp As New Heap()

	For i As Integer = 0 To 9
		hp.add(arr(i))
		Console.WriteLine("pop value :: " & hp.remove())
	Next i


	Heap.heapSort(a)
	For i As Integer = 0 To a.Length - 1
		Console.WriteLine("value is :: " & a(i))
	Next i
End Sub
End Class