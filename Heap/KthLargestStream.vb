
Imports System

Public Class KthLargestStream
	Friend hp As New Heap(Of Integer)()
	Friend size As Integer = 0
	Friend k As Integer = 10

	Friend Sub New(ByVal a As Integer)
		k = a
	End Sub

	Public Sub Add(ByVal value As Integer)
		If size < k Then
			hp.Enqueue(value)
		ElseIf hp.Peek() < value Then
			hp.Enqueue(value)
			hp.Dequeue()
		End If
		size += 1
	End Sub

	Public Sub Print()
		hp.Print()
	End Sub

	Public Sub Add2(ByVal value As Integer)
		If size < k Then
			hp.Enqueue(value)
			Console.Write("- ")
		Else
			If hp.Peek() < value Then
				hp.Enqueue(value)
				hp.Dequeue()
			End If
			Console.Write(hp.Peek() & " ")
		End If
		size += 1
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim kt As New KthLargestStream(10)
		Dim value As Integer
		Dim rand As New Random()
		For i As Integer = 0 To 99
			value = rand.Next(1000)
			kt.Add2(value)
		Next i
		kt.Print()
	End Sub
End Class

Public Class Heap(Of T As IComparable(Of T))
    Private count As Integer ' Number of elements in Heap
    Private arr As T() ' The Heap array
    Private isMinHeap As Boolean

    Public Sub New(ByVal Optional isMin As Boolean = True)
        Dim CAPACITY As Integer = 32
        arr = New T(CAPACITY - 1) {}
        count = 0
        isMinHeap = isMin
    End Sub

    Public Sub New(ByVal array As T(), ByVal Optional isMin As Boolean = True)
        count = array.Length
        arr = array
        isMinHeap = isMin

        For i As Integer = (count / 2) To 0
            PercolateDown(i)
        Next
    End Sub

    Private Function Compare(ByVal arr As T(), ByVal first As Integer, ByVal second As Integer) As Boolean
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
        If lChild < count Then child = lChild
        If rChild < count AndAlso Compare(arr, lChild, rChild) Then child = rChild

        If child <> -1 AndAlso Compare(arr, parent, child) Then
            Dim temp As T = arr(parent)
            arr(parent) = arr(child)
            arr(child) = temp
            PercolateDown(child)
        End If
    End Sub

    Private Sub PercolateUp(ByVal child As Integer)
        Dim parent As Integer = (child - 1) / 2

        If parent >= 0 AndAlso Compare(arr, parent, child) Then
            Dim temp As T = arr(child)
            arr(child) = arr(parent)
            arr(parent) = temp
            PercolateUp(parent)
        End If
    End Sub

    Public Sub Enqueue(ByVal value As T)
        If count = arr.Length Then DoubleSize()
        arr(Math.Min(System.Threading.Interlocked.Increment(count), count - 1)) = value
        PercolateUp(count - 1)
    End Sub

    Private Sub DoubleSize()
        Dim old As T() = arr
        arr = New T(old.Length * 2 - 1) {}
        Array.Copy(old, 0, arr, 0, count)
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
        Next
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
End Class
