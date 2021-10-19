Imports System

Public Class ChotaBhim
	Public Shared Function TotalQuantity(ByVal cups() As Integer, ByVal size As Integer) As Integer
		Dim time As Integer = 60
		Array.Sort(cups)
		Dim total As Integer = 0
		Dim index, temp As Integer
		Do While time > 0
			total += cups(0)
			cups(0) = CInt(Math.Truncate(Math.Ceiling(cups(0) / 2.0)))
			index = 0
			temp = cups(0)
			Do While index < size - 1 AndAlso temp < cups(index + 1)
				cups(index) = cups(index + 1)
				index += 1
			Loop
			cups(index) = temp
			time -= 1
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Function TotalQuantity2(ByVal cups() As Integer, ByVal size As Integer) As Integer
		Dim time As Integer = 60
		Dim pq As New PriorityQueue(Of Integer)(False)
		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.add(cups(i))
		Next i

		Dim total As Integer = 0
		Dim value As Integer
		Do While time > 0
			value = pq.remove()
			total += value
			value = CInt(Math.Truncate(Math.Ceiling(value / 2.0)))
			pq.add(value)
			time -= 1
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim cups() As Integer = {2, 1, 7, 4, 2}
		ChotaBhim.TotalQuantity(cups, cups.Length)
		Dim cups2() As Integer = {2, 1, 7, 4, 2}
		ChotaBhim.TotalQuantity2(cups2, cups.Length)
	End Sub

	'	
	' Total : 76 
	' Total : 76 
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