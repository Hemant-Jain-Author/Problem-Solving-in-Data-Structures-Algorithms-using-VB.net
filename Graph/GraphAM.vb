Imports System

Public Class GraphAM
    Private count As Integer
    Private adj As Integer(,)

    Public Sub New(ByVal cnt As Integer)
        count = cnt
        adj = New Integer(count - 1, count - 1) {}
    End Sub

    Public Sub AddDirectedEdge(ByVal src As Integer, ByVal dst As Integer, ByVal Optional cost As Integer = 1)
        adj(src, dst) = cost
    End Sub

    Public Sub AddUndirectedEdge(ByVal src As Integer, ByVal dst As Integer, ByVal Optional cost As Integer = 1)
        adj(src, dst) = cost
        adj(dst, src) = cost
    End Sub

    Public Sub Print()
        For i As Integer = 0 To count - 1
            Console.Write("Vertex " & i & " is connected to : ")
            For j As Integer = 0 To count - 1
                If adj(i, j) <> 0 Then
                    Console.Write(j & "(cost: " & adj(i, j) & ") ")
                End If
            Next
            Console.WriteLine()
        Next
    End Sub

    ' Testing code.
    Public Shared Sub Main1()
        Dim graph As GraphAM = New GraphAM(4)
        graph.AddUndirectedEdge(0, 1)
        graph.AddUndirectedEdge(0, 2)
        graph.AddUndirectedEdge(1, 2)
        graph.AddUndirectedEdge(2, 3)
        graph.Print()
    End Sub
' Vertex 0 is connected to : 1(cost: 1) 2(cost: 1)
' Vertex 1 is connected to : 0(cost: 1) 2(cost: 1) 
' Vertex 2 is connected to : 0(cost: 1) 1(cost: 1) 3(cost: 1) 
' Vertex 3 is connected to : 2(cost: 1) 

    Private Class Edge
        Implements IComparable(Of Edge)
        Friend src, dest, cost As Integer
        Public Sub New(ByVal s As Integer, ByVal d As Integer, ByVal c As Integer)
            src = s
            dest = d
            cost = c
        End Sub

		Private Function IComparable_CompareTo(other As Edge) As Integer Implements IComparable(Of Edge).CompareTo
			Return Me.cost - other.cost
		End Function
    End Class

    Public Sub Dijkstra(ByVal source As Integer)
        Dim previous As Integer() = New Integer(count - 1) {}
        Dim dist As Integer() = New Integer(count - 1) {}
        Dim visited As Boolean() = New Boolean(count - 1) {}
        For i As Integer = 0 To (count - 1)
            previous(i) = -1
            dist(i) = Integer.MaxValue ' infinite
        Next i
        dist(source) = 0
        previous(source) = source
        Dim hp As Heap(Of Edge) = New Heap(Of Edge)()
        Dim node As Edge = New Edge(source, source, 0)
        hp.Enqueue(node)
        Dim curr As Integer

        While hp.IsEmpty() <> True
            node = hp.Dequeue()
            curr = node.dest
            visited(curr) = True
            For dest As Integer = 0 To count - 1
                Dim cost As Integer = adj(curr, dest)
                If cost <> 0 Then
                    Dim alt As Integer = cost + dist(curr)
                    If dist(dest) > alt AndAlso visited(dest) = False Then
                        dist(dest) = alt
                        previous(dest) = curr
                        node = New Edge(curr, dest, alt)
                        hp.Enqueue(node)
                    End If
                End If
            Next
        End While

        PrintPath(previous, dist, count, source)
    End Sub

    Private Function PrintPathUtil(ByVal previous As Integer(), ByVal source As Integer, ByVal dest As Integer) As String
        Dim path As String = ""
        If dest = source Then
            path = source
        Else
            path += PrintPathUtil(previous, source, previous(dest))
            path += ("->" & CStr(dest))
        End If
        Return path
    End Function

    Public Sub PrintPath(ByVal previous As Integer(), ByVal dist As Integer(), ByVal count As Integer, ByVal source As Integer)
        Dim output As String = "Shortest Paths: "
        For i As Integer = 0 To count - 1
            If dist(i) = 99999 Then
                output += ("(" & source & "->" & i & " @ Unreachable) ")
            ElseIf i <> previous(i) Then
                output += "("
                output += PrintPathUtil(previous, source, i)
                output += (" @ " & dist(i) & ") ")
            End If
        Next
        Console.WriteLine(output)
    End Sub

    Public Sub PrimsMST()
        Dim previous As Integer() = New Integer(count - 1) {}
        Dim dist As Integer() = New Integer(count - 1) {}
        Dim source As Integer = 0
        Dim visited As Boolean() = New Boolean(count - 1) {}
		For i As Integer = 0 To (count - 1)
            previous(i) = -1
            dist(i) = Integer.MaxValue ' infinite
        Next i
        dist(source) = 0
        previous(source) = source
        Dim hp As Heap(Of Edge) = New Heap(Of Edge)()
        Dim node As Edge = New Edge(source, source, 0)
        hp.Enqueue(node)

        While hp.IsEmpty() <> True
            node = hp.Dequeue()
            source = node.dest
            visited(source) = True
            For dest As Integer = 0 To count - 1
                Dim cost As Integer = adj(source, dest)
                If cost <> 0 Then
                    If dist(dest) > cost AndAlso visited(dest) = False Then
                        dist(dest) = cost
                        previous(dest) = source
                        node = New Edge(source, dest, cost)
                        hp.Enqueue(node)
                    End If
                End If
            Next
        End While

        Dim sum As Integer = 0
        Dim isMst As Boolean = True
        Dim output As String = "Edges are "
        For i As Integer = 0 To count - 1
            If dist(i) = 99999 Then
                output += ("(" & i & ", Unreachable) ")
                isMst = False
            ElseIf previous(i) <> i Then
                output += ("(" & previous(i) & "->" & i & " @ " & dist(i) & ") ")
                sum += dist(i)
            End If
        Next

        If isMst Then
            Console.WriteLine(output)
            Console.WriteLine("Total MST cost: " & sum)
        Else
            Console.WriteLine("Can't get a Spanning Tree")
        End If
    End Sub

    Public Shared Sub Main2()
        Dim gph As GraphAM = New GraphAM(9)
        gph.AddUndirectedEdge(0, 1, 4)
        gph.AddUndirectedEdge(0, 7, 8)
        gph.AddUndirectedEdge(1, 2, 8)
        gph.AddUndirectedEdge(1, 7, 11)
        gph.AddUndirectedEdge(2, 3, 7)
        gph.AddUndirectedEdge(2, 8, 2)
        gph.AddUndirectedEdge(2, 5, 4)
        gph.AddUndirectedEdge(3, 4, 9)
        gph.AddUndirectedEdge(3, 5, 14)
        gph.AddUndirectedEdge(4, 5, 10)
        gph.AddUndirectedEdge(5, 6, 2)
        gph.AddUndirectedEdge(6, 7, 1)
        gph.AddUndirectedEdge(6, 8, 6)
        gph.AddUndirectedEdge(7, 8, 7)
        gph.PrimsMST()
        gph.Dijkstra(0)
    End Sub
' Edges are (0->1 @ 4) (5->2 @ 4) (2->3 @ 7) (3->4 @ 9) (6->5 @ 2) (7->6 @ 1) (0->7 @ 8) (2->8 @ 2) 
' Total MST cost: 37
' Shortest Paths: (0->1 @ 4) (0->1->2 @ 12) (0->1->2->3 @ 19) (0->7->6->5->4 @ 21) (0->7->6->5 @ 11) (0->7->6 @ 9) (0->7 @ 8) (0->1->2->8 @ 14)

    Public Function HamiltonianPathUtil(ByVal path As Integer(), ByVal pSize As Integer, ByVal added As Integer()) As Boolean
        If pSize = count Then
            Return True
        End If

        For vertex As Integer = 0 To count - 1
            If pSize = 0 OrElse (adj(path(pSize - 1), vertex) = 1 AndAlso added(vertex) = 0) Then
                path(pSize) = vertex
                pSize += 1
                added(vertex) = 1
                If HamiltonianPathUtil(path, pSize, added) Then
                    Return True
                End If
                pSize -= 1
                added(vertex) = 0
            End If
        Next
        Return False
    End Function

    Public Function HamiltonianPath() As Boolean
        Dim path As Integer() = New Integer(count - 1) {}
        Dim added As Integer() = New Integer(count - 1) {}
        If HamiltonianPathUtil(path, 0, added) Then
            Console.Write("Hamiltonian Path found :: ")
            For i As Integer = 0 To count - 1
                Console.Write(" " & path(i))
            Next
            Console.WriteLine()
            Return True
        End If
        Console.WriteLine("Hamiltonian Path not found")
        Return False
    End Function

    Public Function HamiltonianCycleUtil(ByVal path As Integer(), ByVal pSize As Integer, ByVal added As Integer()) As Boolean
        If pSize = count Then
            If adj(path(pSize - 1), path(0)) = 1 Then
                path(pSize) = path(0)
                Return True
            Else
                Return False
            End If
        End If

        For vertex As Integer = 0 To count - 1
            If pSize = 0 OrElse (adj(path(pSize - 1), vertex) = 1 AndAlso added(vertex) = 0) Then
                path(pSize) = vertex
                pSize += 1
                added(vertex) = 1
                If HamiltonianCycleUtil(path, pSize, added) Then
                    Return True
                End If
                pSize -= 1
                added(vertex) = 0
            End If
        Next
        Return False
    End Function

    Public Function HamiltonianCycle() As Boolean
        Dim path As Integer() = New Integer(count + 1 - 1) {}
        Dim added As Integer() = New Integer(count - 1) {}
        If HamiltonianCycleUtil(path, 0, added) Then
            Console.Write("Hamiltonian Cycle found :: ")
            For i As Integer = 0 To count
                Console.Write(" " & path(i))
            Next
            Console.WriteLine()
            Return True
        End If
        Console.WriteLine("Hamiltonian Cycle not found")
        Return False
    End Function

    Public Shared Sub Main3()
        Dim count As Integer = 5
        Dim graph As GraphAM = New GraphAM(count)
        Dim adj As Integer(,) = New Integer(,) {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 1},
        {0, 1, 1, 1, 0}}

        For i As Integer = 0 To count - 1
            For j As Integer = 0 To count - 1
                If adj(i, j) = 1 Then
                    graph.AddDirectedEdge(i, j, 1)
                End If
            Next
        Next

        Console.WriteLine("HamiltonianPath : " & graph.HamiltonianPath())
        Dim graph2 As GraphAM = New GraphAM(count)
        Dim adj2 As Integer(,) = New Integer(,) {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 0},
        {0, 1, 1, 0, 0}}

        For i As Integer = 0 To count - 1
            For j As Integer = 0 To count - 1
                If adj2(i, j) = 1 Then
                    graph2.AddDirectedEdge(i, j, 1)
                End If
            Next
        Next

        Console.WriteLine("HamiltonianPath :  " & graph2.HamiltonianPath())
    End Sub
' Hamiltonian Path found ::  0 1 2 4 3
' HamiltonianPath : True
' Hamiltonian Path found ::  0 3 1 2 4
' HamiltonianPath :  True

    Public Shared Sub Main4()
        Dim count As Integer = 5
        Dim graph As GraphAM = New GraphAM(count)
        Dim adj As Integer(,) = New Integer(,) {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 1},
        {0, 1, 1, 1, 0}}

        For i As Integer = 0 To count - 1
            For j As Integer = 0 To count - 1
                If adj(i, j) = 1 Then
                    graph.AddDirectedEdge(i, j, 1)
                End If
            Next
        Next

        Console.WriteLine("HamiltonianCycle : " & graph.HamiltonianCycle())
        Dim graph2 As GraphAM = New GraphAM(count)
        Dim adj2 As Integer(,) = New Integer(,) {
        {0, 1, 0, 1, 0},
        {1, 0, 1, 1, 0},
        {0, 1, 0, 0, 1},
        {1, 1, 0, 0, 0},
        {0, 1, 1, 0, 0}}

        For i As Integer = 0 To count - 1
            For j As Integer = 0 To count - 1
                If adj2(i, j) = 1 Then
                    graph2.AddDirectedEdge(i, j, 1)
                End If
            Next
        Next

        Console.WriteLine("HamiltonianCycle :  " & graph2.HamiltonianCycle())
    End Sub

' Hamiltonian Cycle found ::  0 1 2 4 3 0
' HamiltonianCycle : True
' Hamiltonian Cycle not found
' HamiltonianCycle :  False

    Public Shared Sub Main(ByVal args As String())
        Main1()
        Main2()
        Main3()
        Main4()
    End Sub
End Class


Public Class Heap(Of T As IComparable(Of T))
    Private Capacity As Integer = 100
    Private count As Integer ' Number of elements in Heap
    Private arr() As T ' The Heap array
    Private isMinHeap As Boolean

    Public Sub New(Optional ByVal isMin As Boolean = True)
        arr = New T(Capacity) {}
        count = 0
        isMinHeap = isMin
    End Sub

    Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
        Capacity = array.Length
        count = array.Length
        arr = array
        isMinHeap = isMin
        For i As Integer = (count \ 2) To 0 Step -1
            PercolateDown(i)
        Next i
    End Sub

    ' Other Methods.
    Private Function Compare(ByVal arr() As T, ByVal first As Integer, ByVal second As Integer) As Boolean
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
        Dim temp As T

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
        Dim temp As T
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

    Public Sub Enqueue(ByVal value As T)
        If count = Capacity Then
            DoubleSize()
        End If

        arr(count) = value
        count += 1
        PercolateUp(count - 1)
    End Sub

    Private Sub DoubleSize()
        Dim old() As T = arr
        arr = New T(Capacity * 2) {}
        Capacity = Capacity * 2
        For i As Integer = 0 To count - 1
            arr(i) = old(i)
        Next i
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
        Next i
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

    Friend Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
        ' Create max heap for increasing order sorting.
        Dim hp As New Heap(Of Integer)(array, Not inc)
        For i As Integer = 0 To array.Length - 1
            array(array.Length - i - 1) = hp.Dequeue()
        Next i
    End Sub
End Class
