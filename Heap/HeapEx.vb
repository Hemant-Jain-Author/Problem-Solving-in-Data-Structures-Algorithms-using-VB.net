Module Module1
    Public Sub demo(ByVal args() As String)

        Dim pq As New PriorityQueue(Of Integer)()

        Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}

        For Each i As Integer In arr
            pq.add(i)
        Next i

        Console.Write("Dequeue elements of Priority Queue ::")
        Do While pq.isEmpty() = False
            Console.Write(" " & pq.remove())
        Loop
    End Sub

    Public Function KthSmallest(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
        Array.Sort(arr)
        Return arr(k - 1)
    End Function

    Public Function KthSmallest2(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
        Dim i As Integer = 0
        Dim value As Integer = 0
        Dim pq As New PriorityQueue(Of Integer)()
        For i = 0 To size - 1
            pq.add(arr(i))
        Next i

        Do While i < size AndAlso i < k
            value = pq.remove()
            i += 1
        Loop
        Return value
    End Function

    Public Function isMinHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
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

    Public Function isMaxHeap(ByVal arr() As Integer, ByVal size As Integer) As Boolean
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

    Public Sub main2()
        Dim arr() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Console.WriteLine("Kth Smallest :: " & KthSmallest(arr, arr.Length, 3))
        Dim arr2() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Console.WriteLine("Kth Smallest :: " & KthSmallest2(arr2, arr2.Length, 3))
        Dim arr3() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Console.WriteLine("isMaxHeap :: " & isMaxHeap(arr3, arr3.Length))
        Dim arr4() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Array.Sort(arr4)
        Console.WriteLine("isMinHeap :: " & isMinHeap(arr4, arr4.Length))
    End Sub

    Public Function KSmallestProduct(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
        Array.Sort(arr) ' , size, 1);
        Dim product As Integer = 1
        For i As Integer = 0 To k - 1
            product *= arr(i)
        Next i
        Return product
    End Function

    Public Sub swap(ByVal arr() As Integer, ByVal i As Integer, ByVal j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub

    Public Sub QuickSelectUtil(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer, ByVal k As Integer)
        If upper <= lower Then
            Return
        End If

        Dim pivot As Integer = arr(lower)

        Dim start As Integer = lower
        Dim [stop] As Integer = upper

        Do While lower < upper
            Do While lower < upper AndAlso arr(lower) <= pivot
                lower += 1
            Loop
            Do While lower <= upper AndAlso arr(upper) > pivot
                upper -= 1
            Loop
            If lower < upper Then
                swap(arr, upper, lower)
            End If
        Loop

        swap(arr, upper, start) ' upper is the pivot position
        If k < upper Then
            QuickSelectUtil(arr, start, upper - 1, k) ' pivot -1 is the upper for left sub array.
        End If
        If k > upper Then
            QuickSelectUtil(arr, upper + 1, [stop], k) ' pivot + 1 is the lower for right sub array.
        End If
    End Sub
    Public Function KSmallestProduct2(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
        Dim pq As New PriorityQueue(Of Integer)()
        Dim i As Integer = 0
        Dim product As Integer = 1
        For i = 0 To size - 1
            pq.add(arr(i))
        Next i

        Do While i < size AndAlso i < k
            product *= pq.remove()
            i += 1
        Loop
        Return product
    End Function

    Public Function KSmallestProduct3(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
        QuickSelectUtil(arr, 0, size - 1, k)
        Dim product As Integer = 1
        For i As Integer = 0 To k - 1
            product *= arr(i)
        Next i
        Return product
    End Function

    Public Sub main3()
        Dim arr() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Console.WriteLine("Kth Smallest product:: " & KSmallestProduct(arr, 8, 3))
        Dim arr2() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Console.WriteLine("Kth Smallest product:: " & KSmallestProduct2(arr2, 8, 3))
        Dim arr3() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        Console.WriteLine("Kth Smallest product:: " & KSmallestProduct3(arr3, 8, 3))
    End Sub

    Public Sub PrintLargerHalf(ByVal arr() As Integer, ByVal size As Integer)
        Array.Sort(arr) ' , size, 1);
        For i As Integer = size \ 2 To size - 1
            Console.Write(arr(i) & " ")
        Next i
        Console.WriteLine()
    End Sub

    Public Sub PrintLargerHalf2(ByVal arr() As Integer, ByVal size As Integer)
        Dim pq As New PriorityQueue(Of Integer)()
        Dim i As Integer = 0
        For i = 0 To size - 1
            pq.add(arr(i))
        Next i

        i = 0
        Do While i < size \ 2
            pq.remove()
            i += 1
        Loop
        pq.print()
    End Sub

    Public Sub PrintLargerHalf3(ByVal arr() As Integer, ByVal size As Integer)
        QuickSelectUtil(arr, 0, size - 1, size \ 2)
        For i As Integer = size \ 2 To size - 1
            Console.Write(arr(i) & " ")
        Next i
        Console.WriteLine()
    End Sub

    Public Sub main4()
        Dim arr() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        PrintLargerHalf(arr, 8)
        Dim arr2() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        PrintLargerHalf2(arr2, 8)
        Dim arr3() As Integer = {8, 7, 6, 5, 7, 5, 2, 1}
        PrintLargerHalf3(arr3, 8)
    End Sub

    Public Sub sortK(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
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

        For i = 0 To size - 1
            arr(i) = output(i)
        Next i

        For i = 0 To size - 1
            Console.Write(output(i) & " ")
        Next i
    End Sub

    ' Testing Code
    Public Sub main5()
        Dim k As Integer = 3
        Dim arr() As Integer = {1, 5, 4, 10, 50, 9}
        Dim size As Integer = arr.Length
        sortK(arr, size, k)
    End Sub

    Public Function ChotaBhim(ByVal cups() As Integer, ByVal size As Integer) As Integer
        Dim time As Integer = 60
        Array.Sort(cups)
        Array.Reverse(cups)
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
        Console.WriteLine("Total " & total)
        Return total
    End Function

    Public Function ChotaBhim3(ByVal cups() As Integer, ByVal size As Integer) As Integer
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

    Public Function JoinRopes(ByVal ropes() As Integer, ByVal size As Integer) As Integer
        Array.Sort(ropes)
        Array.Reverse(ropes)
        Console.WriteLine(ropes)
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

    Public Function JoinRopes2(ByVal ropes() As Integer, ByVal size As Integer) As Integer
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

    Public Sub main6()
        Dim cups() As Integer = {2, 1, 7, 4, 2}
        ChotaBhim(cups, cups.Length)
        Dim cups3() As Integer = {2, 1, 7, 4, 2}
        ChotaBhim3(cups3, cups.Length)

        Dim ropes() As Integer = {2, 1, 7, 4, 2}
        JoinRopes(ropes, ropes.Length)
        Dim rope2() As Integer = {2, 1, 7, 4, 2}
        JoinRopes2(rope2, rope2.Length)
    End Sub

    Public Function kthLargestStream(ByVal k As Integer) As Integer
        Dim pq As New PriorityQueue(Of Integer)()
        Dim size As Integer = 0
        Dim data As Integer = 0
        Do
            Console.WriteLine("Enter data: ")
            data = Console.Read()

            If size < k - 1 Then
                pq.add(data)
            Else
                If size = k - 1 Then
                    pq.add(data)
                ElseIf pq.peek() < data Then
                    pq.add(data)
                    pq.remove()
                End If
                Console.WriteLine("Kth larges element is :: " & pq.peek())
            End If
            size += 1
        Loop
    End Function

    Public Sub main7()
        kthLargestStream(3)
    End Sub

    Sub Main()
        main2()
        main3()
        main4()
        main5()
        main6()
        ' main7()
    End Sub

End Module

Public Class PriorityQueue(Of T As IComparable(Of T))
    Private Const CAPACITY As Integer = 32
    Private Count As Integer ' Number of elements in Heap
    Private arr() As T ' The Heap array
    Private isMinHeap As Boolean

    Public Sub New(Optional ByVal isMin As Boolean = True)
        arr = New T(CAPACITY - 1) {}
        Count = 0
        isMinHeap = isMin
    End Sub

    Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
        Count = array.Length
        arr = array
        isMinHeap = isMin
        ' Build Heap operation over array
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
        If Count = arr.Length Then
            doubleSize()
        End If

        'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
        'ORIGINAL LINE: arr[Count++] = value;
        arr(Count) = value
        Count += 1
        proclateUp(Count - 1)
    End Sub

    Private Sub doubleSize()
        Dim old() As T = arr
        arr = New T((arr.Length * 2) - 1) {}
        Array.Copy(old, 0, arr, 0, Count)
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

End Class


