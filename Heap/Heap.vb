Imports System
Imports System.Collections.Generic

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

    ' Other Methods.
End Class
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
    arr(count) = value
    count++
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
Public Function Delete(ByVal value As T) As Boolean
    For i As Integer = 0 To size - 1
        If arr(i) = value Then
            arr(i) = arr(size - 1)
            size -= 1
            PercolateDown(i)
            Return True
        End If
    Next

    Return False
End Function
End Class

' Testing code.HeapSort
Public Module HeapEx
Sub Main1()
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)(True)
    hp.Enqueue(1)
    hp.Enqueue(6)
    hp.Enqueue(5)
    hp.Enqueue(7)
    hp.Enqueue(3)
    hp.Enqueue(4)
    hp.Enqueue(2)
    hp.Print()

    While Not hp.IsEmpty()
        Console.Write(hp.Dequeue() & " ")
    End While

    Console.WriteLine()
End Sub


Sub HeapSort(ByVal array As Integer(), ByVal inc As Boolean)
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)(array, Not inc)

    For i As Integer = 0 To array.Length - 1
        array(array.Length - i - 1) = hp.Dequeue()
    Next
End Sub

Sub Main2()
    Dim a2 As Integer() = New Integer() {1, 9, 6, 7, 8, 2, 4, 5, 3}
    HeapSort(a2, True)

    For i As Integer = 0 To a2.Length - 1
        Console.Write(a2(i) & " ")
    Next

    Console.WriteLine()
    Dim a3 As Integer() = New Integer() {1, 9, 6, 7, 8, 2, 4, 5, 3}
    HeapSort(a3, False)

    For i As Integer = 0 To a3.Length - 1
        Console.Write(a3(i) & " ")
    Next

    Console.WriteLine()
End Sub

Function KthSmallest(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Array.Sort(arr)
    Return arr(k - 1)
End Function

Function KthSmallest2(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)()

    For i As Integer = 0 To size - 1
        hp.Enqueue(arr(i))
    Next

    For i As Integer = 0 To k - 1 - 1
        hp.Dequeue()
    Next

    Return hp.Peek()
End Function

Function KthSmallest3(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)(False)

    For i As Integer = 0 To size - 1

        If i < k Then
            hp.Enqueue(arr(i))
        Else

            If hp.Peek() > arr(i) Then
                hp.Enqueue(arr(i))
                hp.Dequeue()
            End If
        End If
    Next

    Return hp.Peek()
End Function

Function KthLargest(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Dim value As Integer = 0
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)(False)

    For i As Integer = 0 To size - 1
        hp.Enqueue(arr(i))
    Next

    For i As Integer = 0 To k - 1
        value = hp.Dequeue()
    Next

    Return value
End Function

Sub Main3()
    Dim arr As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest :: " & KthSmallest(arr, arr.Length, 3))
    Dim arr2 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest :: " & KthSmallest2(arr2, arr2.Length, 3))
    Dim arr3 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest :: " & KthSmallest3(arr3, arr3.Length, 3))
    Dim arr4 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Largest :: " & KthLargest(arr4, arr4.Length, 3))
End Sub

Function IsMinHeap(ByVal arr As Integer(), ByVal size As Integer) As Boolean
    Dim lchild, rchild As Integer

    For parent As Integer = 0 To (size / 2 + 1) - 1
        lchild = parent * 2 + 1
        rchild = parent * 2 + 2
        If ((lchild < size) AndAlso (arr(parent) > arr(lchild))) OrElse ((rchild < size) AndAlso (arr(parent) > arr(rchild))) Then Return False
    Next

    Return True
End Function

Function IsMaxHeap(ByVal arr As Integer(), ByVal size As Integer) As Boolean
    Dim lchild, rchild As Integer

    For parent As Integer = 0 To (size / 2 + 1) - 1
        lchild = parent * 2 + 1
        rchild = lchild + 1
        If ((lchild < size) AndAlso (arr(parent) < arr(lchild))) OrElse ((rchild < size) AndAlso (arr(parent) < arr(rchild))) Then Return False
    Next

    Return True
End Function

Sub Main4()
    Dim arr3 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("IsMaxHeap :: " & IsMaxHeap(arr3, arr3.Length))
    Dim arr4 As Integer() = New Integer() {1, 2, 3, 4, 5, 6, 7, 8}
    Console.WriteLine("IsMinHeap :: " & IsMinHeap(arr4, arr4.Length))
End Sub

Function KSmallestProduct(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Array.Sort(arr)
    Dim product As Integer = 1

    For i As Integer = 0 To k - 1
        product *= arr(i)
    Next
    Return product
End Function

Sub Swap(ByVal arr As Integer(), ByVal i As Integer, ByVal j As Integer)
    Dim temp As Integer = arr(i)
    arr(i) = arr(j)
    arr(j) = temp
End Sub

Sub QuickSelectUtil(ByVal arr As Integer(), ByVal lower As Integer, ByVal upper As Integer, ByVal k As Integer)
    If upper <= lower Then Return
    Dim pivot As Integer = arr(lower)
    Dim start As Integer = lower
    Dim [stop] As Integer = upper

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

    Swap(arr, upper, start)
    If k < upper Then QuickSelectUtil(arr, start, upper - 1, k)
    If k > upper Then QuickSelectUtil(arr, upper + 1, [stop], k)
End Sub

Function KSmallestProduct3(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    QuickSelectUtil(arr, 0, size - 1, k)
    Dim product As Integer = 1

    For i As Integer = 0 To k - 1
        product *= arr(i)
    Next

    Return product
End Function

Function KSmallestProduct2(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)()
    Dim i As Integer = 0
    Dim product As Integer = 1

    For i = 0 To size - 1
        hp.Enqueue(arr(i))
    Next

    i = 0

    While i < size AndAlso i < k
        product *= hp.Dequeue()
        i += 1
    End While

    Return product
End Function

Function KSmallestProduct4(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Integer
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)(False)

    For i As Integer = 0 To size - 1

        If i < k Then
            hp.Enqueue(arr(i))
        Else

            If hp.Peek() > arr(i) Then
                hp.Enqueue(arr(i))
                hp.Dequeue()
            End If
        End If
    Next

    Dim product As Integer = 1

    For i As Integer = 0 To k - 1
        product *= hp.Dequeue()
    Next

    Return product
End Function

Sub Main5()
    Dim arr As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest product:: " & KSmallestProduct(arr, 8, 3))
    Dim arr2 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest product:: " & KSmallestProduct2(arr2, 8, 3))
    Dim arr3 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest product:: " & KSmallestProduct3(arr3, 8, 3))
    Dim arr4 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
    Console.WriteLine("Kth Smallest product:: " & KSmallestProduct4(arr4, 8, 3))
End Sub

    Sub PrintLargerHalf(ByVal arr As Integer(), ByVal size As Integer)
        Array.Sort(arr)

        For i As Integer = size / 2 To size - 1
            Console.Write(arr(i) & " ")
        Next

        Console.WriteLine()
    End Sub

    Sub PrintLargerHalf2(ByVal arr As Integer(), ByVal size As Integer)
        Dim hp As Heap(Of Integer) = New Heap(Of Integer)()

        For i As Integer = 0 To size - 1
            hp.Enqueue(arr(i))
        Next

        For i As Integer = 0 To size / 2 - 1
            hp.Dequeue()
        Next

        hp.Print()
    End Sub

    Sub PrintLargerHalf3(ByVal arr As Integer(), ByVal size As Integer)
        QuickSelectUtil(arr, 0, size - 1, size / 2)

        For i As Integer = size / 2 To size - 1
            Console.Write(arr(i) & " ")
        Next

        Console.WriteLine()
    End Sub

    Sub Main6()
        Dim arr As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
        PrintLargerHalf(arr, 8)
        Dim arr2 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
        PrintLargerHalf2(arr2, 8)
        Dim arr3 As Integer() = New Integer() {8, 7, 6, 5, 7, 5, 2, 1}
        PrintLargerHalf3(arr3, 8)
    End Sub

Sub SortK(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer)
    Dim hp As Heap(Of Integer) = New Heap(Of Integer)()
    Dim i As Integer = 0

    For i = 0 To k - 1
        hp.Enqueue(arr(i))
    Next

    Dim index As Integer = 0

    For i = k To size - 1
        arr(index) = hp.Dequeue()
        index++
        hp.Enqueue(arr(i))
    Next

    While hp.Size() > 0
        arr(index) = hp.Dequeue()
        index++
    End While
End Sub

Sub Main7()
    Dim k As Integer = 3
    Dim arr As Integer() = New Integer() {1, 5, 4, 10, 50, 9}
    Dim size As Integer = arr.Length
    SortK(arr, size, k)

    For i As Integer = 0 To size - 1
        Console.Write(arr(i) & " ")
    Next
End Sub

    Sub Main(ByVal args As String())
        Main1()
        Main2()
        Main3()
        Main4()
        Main5()
        Main6()
        Main7()
    End Sub
End Module
