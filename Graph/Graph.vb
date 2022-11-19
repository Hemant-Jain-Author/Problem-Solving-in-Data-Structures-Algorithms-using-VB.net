Imports System
Imports System.Collections.Generic

Public Class Graph
    Private count As Integer
    Private Adj As List(Of List(Of Edge))
    
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

    Public Sub New(ByVal cnt As Integer)
        count = cnt
        Adj = New List(Of List(Of Edge))()

        For i As Integer = 0 To cnt - 1
            Adj.Add(New List(Of Edge)())
        Next
    End Sub

    Public Sub AddDirectedEdge(ByVal source As Integer, ByVal dest As Integer, ByVal Optional cost As Integer = 1)
        Dim edge As Edge = New Edge(source, dest, cost)
        Adj(source).Add(edge)
    End Sub

    Public Sub AddUndirectedEdge(ByVal source As Integer, ByVal dest As Integer, ByVal Optional cost As Integer = 1)
        AddDirectedEdge(source, dest, cost)
        AddDirectedEdge(dest, source, cost)
    End Sub

    Public Sub Print()
        For i As Integer = 0 To count - 1
            Dim ad As List(Of Edge) = Adj(i)
            Console.Write("Vertex " & i & " is connected to : ")

            For Each adn As Edge In ad
                Console.Write(adn.dest & "(cost: " & adn.cost & ") ")
            Next

            Console.WriteLine()
        Next
    End Sub

    Public Function DFSStack(ByVal source As Integer, ByVal target As Integer) As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim stk As Stack(Of Integer) = New Stack(Of Integer)()
        stk.Push(source)
        visited(source) = True

        While stk.Count > 0
            Dim curr As Integer = stk.Pop()
            Dim adl As List(Of Edge) = Adj(curr)

            For Each adn As Edge In adl

                If visited(adn.dest) = False Then
                    visited(adn.dest) = True
                    stk.Push(adn.dest)
                End If
            Next
        End While

        Return visited(target)
    End Function

    Public Function DFS(ByVal source As Integer, ByVal target As Integer) As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        DFSUtil(source, visited)
        Return visited(target)
    End Function

    Private Sub DFSUtil(ByVal index As Integer, ByVal visited As Boolean())
        visited(index) = True
        Dim adl As List(Of Edge) = Adj(index)

        For Each adn As Edge In adl

            If visited(adn.dest) = False Then
                DFSUtil(adn.dest, visited)
            End If
        Next
    End Sub

    Public Sub DFSUtil2(ByVal index As Integer, ByVal visited As Boolean(), ByVal stk As Stack(Of Integer))
        visited(index) = True
        Dim adl As List(Of Edge) = Adj(index)

        For Each adn As Edge In adl

            If visited(adn.dest) = False Then
                DFSUtil2(adn.dest, visited, stk)
            End If
        Next

        stk.Push(index)
    End Sub

    Public Function BFS(ByVal source As Integer, ByVal target As Integer) As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim que As Queue(Of Integer) = New Queue(Of Integer)()
        que.Enqueue(source)
        visited(source) = True

        While que.Count > 0
            Dim curr As Integer = que.Dequeue()
            Dim adl As List(Of Edge) = Adj(curr)

            For Each adn As Edge In adl

                If visited(adn.dest) = False Then
                    visited(adn.dest) = True
                    que.Enqueue(adn.dest)
                End If
            Next
        End While

        Return visited(target)
    End Function

    Public Shared Sub Main1()
        Dim gph As Graph = New Graph(4)
        gph.AddUndirectedEdge(0, 1)
        gph.AddUndirectedEdge(0, 2)
        gph.AddUndirectedEdge(1, 2)
        gph.AddUndirectedEdge(2, 3)
        gph.Print()
    End Sub

    Public Shared Sub Main2()
        Dim gph As Graph = New Graph(8)
        gph.AddUndirectedEdge(0, 3)
        gph.AddUndirectedEdge(0, 2)
        gph.AddUndirectedEdge(0, 1)
        gph.AddUndirectedEdge(1, 4)
        gph.AddUndirectedEdge(2, 5)
        gph.AddUndirectedEdge(3, 6)
        gph.AddUndirectedEdge(6, 7)
        gph.AddUndirectedEdge(5, 7)
        gph.AddUndirectedEdge(4, 7)
        Console.WriteLine("Path between 0 & 6 : " & gph.DFS(0, 6))
        Console.WriteLine("Path between 0 & 6 : " & gph.BFS(0, 6))
        Console.WriteLine("Path between 0 & 6 : " & gph.DFSStack(0, 6))
    End Sub

    Public Sub TopologicalSort()
        Dim stk As Stack(Of Integer) = New Stack(Of Integer)()
        Dim visited As Boolean() = New Boolean(count - 1) {}

        For i As Integer = 0 To count - 1

            If visited(i) = False Then
                DFSUtil2(i, visited, stk)
            End If
        Next

        Console.Write("Topological Sort::")

        While stk.Count = 0 <> True
            Console.Write(" " & stk.Pop())
        End While
    End Sub

    Public Shared Sub Main3()
        Dim gph As Graph = New Graph(9)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(1, 2)
        gph.AddDirectedEdge(1, 3)
        gph.AddDirectedEdge(1, 4)
        gph.AddDirectedEdge(3, 2)
        gph.AddDirectedEdge(3, 5)
        gph.AddDirectedEdge(4, 5)
        gph.AddDirectedEdge(4, 6)
        gph.AddDirectedEdge(5, 7)
        gph.AddDirectedEdge(6, 7)
        gph.AddDirectedEdge(7, 8)
        gph.TopologicalSort()
    End Sub

    Public Function PathExist(ByVal source As Integer, ByVal dest As Integer) As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        DFSUtil(source, visited)
        Return visited(dest)
    End Function

    Public Function CountAllPathDFS(ByVal visited As Boolean(), ByVal source As Integer, ByVal dest As Integer) As Integer
        If source = dest Then
            Return 1
        End If

        Dim count As Integer = 0
        visited(source) = True
        Dim adl As List(Of Edge) = Adj(source)

        For Each adn As Edge In adl

            If visited(adn.dest) = False Then
                count += CountAllPathDFS(visited, adn.dest, dest)
            End If
        Next

        visited(source) = False
        Return count
    End Function

    Public Function CountAllPath(ByVal src As Integer, ByVal dest As Integer) As Integer
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Return CountAllPathDFS(visited, src, dest)
    End Function

    Public Sub PrintAllPathDFS(ByVal visited As Boolean(), ByVal source As Integer, ByVal dest As Integer, ByVal path As Stack(Of Integer))
        path.Push(source)

        If source = dest Then

            For Each item As Integer In path
                Console.Write(item & " ")
            Next

            Console.WriteLine()
            path.Pop()
            Return
        End If

        visited(source) = True
        Dim adl As List(Of Edge) = Adj(source)

        For Each adn As Edge In adl

            If visited(adn.dest) = False Then
                PrintAllPathDFS(visited, adn.dest, dest, path)
            End If
        Next

        visited(source) = False
        path.Pop()
    End Sub

    Public Sub PrintAllPath(ByVal src As Integer, ByVal dest As Integer)
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim path As Stack(Of Integer) = New Stack(Of Integer)()
        PrintAllPathDFS(visited, src, dest, path)
    End Sub

    Public Shared Sub Main4()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(2, 3)
        gph.AddDirectedEdge(1, 3)
        gph.AddDirectedEdge(3, 4)
        gph.AddDirectedEdge(1, 4)
        Console.WriteLine("PathExist :: " & gph.PathExist(0, 4))
        Console.WriteLine("Path Count :: " & gph.CountAllPath(0, 4))
        gph.PrintAllPath(0, 4)
    End Sub

    Public Function RootVertex() As Integer
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim retVal As Integer = -1

        For i As Integer = 0 To count - 1

            If visited(i) = False Then
                DFSUtil(i, visited)
                retVal = i
            End If
        Next

        Console.Write("Root vertex is :: " & retVal)
        Return retVal
    End Function

    Public Shared Sub Main5()
        Dim gph As Graph = New Graph(7)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(1, 3)
        gph.AddDirectedEdge(4, 1)
        gph.AddDirectedEdge(6, 4)
        gph.AddDirectedEdge(5, 6)
        gph.AddDirectedEdge(5, 2)
        gph.AddDirectedEdge(6, 0)
        gph.RootVertex()
    End Sub

    Public Sub TransitiveClosureUtil(ByVal source As Integer, ByVal dest As Integer, ByVal tc As Integer(,))
        tc(source, dest) = 1
        Dim adl As List(Of Edge) = Adj(dest)

        For Each adn As Edge In adl

            If tc(source, adn.dest) = 0 Then
                TransitiveClosureUtil(source, adn.dest, tc)
            End If
        Next
    End Sub

    Public Function TransitiveClosure() As Integer(,)
        Dim tc As Integer(,) = New Integer(count - 1, count - 1) {}

        For i As Integer = 0 To count - 1
            TransitiveClosureUtil(i, i, tc)
        Next

        Return tc
    End Function

    Public Shared Sub Main6()
        Dim gph As Graph = New Graph(4)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(1, 2)
        gph.AddDirectedEdge(2, 0)
        gph.AddDirectedEdge(2, 3)
        gph.AddDirectedEdge(3, 3)
        Dim tc As Integer(,) = gph.TransitiveClosure()

        For i As Integer = 0 To 4 - 1

            For j As Integer = 0 To 4 - 1
                Console.Write(tc(i, j) & " ")
            Next

            Console.WriteLine()
        Next
    End Sub

    Public Sub BFSLevelNode(ByVal source As Integer)
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim level As Integer() = New Integer(count - 1) {}
        visited(source) = True
        Dim que As Queue(Of Integer) = New Queue(Of Integer)()
        que.Enqueue(source)
        level(source) = 0
        Console.WriteLine("Node  - Level")

        While que.Count > 0
            Dim curr As Integer = que.Dequeue()
            Dim depth As Integer = level(curr)
            Dim adl As List(Of Edge) = Adj(curr)
            Console.WriteLine(curr & " - " & depth)

            For Each adn As Edge In adl

                If visited(adn.dest) = False Then
                    visited(adn.dest) = True
                    que.Enqueue(adn.dest)
                    level(adn.dest) = depth + 1
                End If
            Next
        End While
    End Sub

    Public Function BFSDistance(ByVal source As Integer, ByVal dest As Integer) As Integer
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim que As Queue(Of Integer) = New Queue(Of Integer)()
        que.Enqueue(source)
        visited(source) = True
        Dim level As Integer() = New Integer(count - 1) {}
        level(source) = 0

        While que.Count > 0
            Dim curr As Integer = que.Dequeue()
            Dim depth As Integer = level(curr)
            Dim adl As List(Of Edge) = Adj(curr)

            For Each adn As Edge In adl

                If adn.dest = dest Then
                    Return depth + 1
                End If

                If visited(adn.dest) = False Then
                    visited(adn.dest) = True
                    que.Enqueue(adn.dest)
                    level(adn.dest) = depth + 1
                End If
            Next
        End While

        Return -1
    End Function

    Public Shared Sub Main7()
        Dim gph As Graph = New Graph(7)
        gph.AddUndirectedEdge(0, 1)
        gph.AddUndirectedEdge(0, 2)
        gph.AddUndirectedEdge(0, 4)
        gph.AddUndirectedEdge(1, 2)
        gph.AddUndirectedEdge(2, 5)
        gph.AddUndirectedEdge(3, 4)
        gph.AddUndirectedEdge(4, 5)
        gph.AddUndirectedEdge(4, 6)
        gph.BFSLevelNode(1)
        Console.WriteLine("BfsDistance(1, 6) : " & gph.BFSDistance(1, 6))
    End Sub

    Public Function IsCyclePresentUndirectedDFS(ByVal index As Integer, ByVal parentIndex As Integer, ByVal visited As Boolean()) As Boolean
        visited(index) = True
        Dim dest As Integer
        Dim adl As List(Of Edge) = Adj(index)

        For Each adn As Edge In adl
            dest = adn.dest

            If visited(dest) = False Then

                If IsCyclePresentUndirectedDFS(dest, index, visited) Then
                    Return True
                End If
            ElseIf parentIndex <> dest Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function IsCyclePresentUndirected() As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}

        For i As Integer = 0 To count - 1

            If visited(i) = False AndAlso IsCyclePresentUndirectedDFS(i, -1, visited) Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function Find(ByVal parent As Integer(), ByVal index As Integer) As Integer
        Dim p As Integer = parent(index)

        While p <> -1
            index = p
            p = parent(index)
        End While

        Return index
    End Function

    Public Sub union(ByVal parent As Integer(), ByVal x As Integer, ByVal y As Integer)
        parent(y) = x
    End Sub

    Public Function IsCyclePresentUndirected2() As Boolean
        Dim parent As Integer() = New Integer(count - 1) {}
        For i As Integer = 0 To (count - 1)
            parent(i) = -1
        Next
        Dim edge As List(Of Edge) = New List(Of Edge)()
        Dim flags As Boolean(,) = New Boolean(count - 1, count - 1) {}

        For i As Integer = 0 To count - 1
            Dim ad As List(Of Edge) = Adj(i)

            For Each adn As Edge In ad

                If flags(adn.dest, adn.src) = False Then
                    edge.Add(adn)
                    flags(adn.src, adn.dest) = True
                End If
            Next
        Next

        For Each e As Edge In edge
            Dim x As Integer = Find(parent, e.src)
            Dim y As Integer = Find(parent, e.dest)

            If x = y Then
                Return True
            End If

            union(parent, x, y)
        Next

        Return False
    End Function

    Public Function IsCyclePresentUndirected3() As Boolean
        Dim sets As Sets() = New Sets(count - 1) {}

        For i As Integer = 0 To count - 1
            sets(i) = New Sets(i, 0)
        Next

        Dim edge As List(Of Edge) = New List(Of Edge)()
        Dim flags As Boolean(,) = New Boolean(count - 1, count - 1) {}

        For i As Integer = 0 To count - 1
            Dim ad As List(Of Edge) = Adj(i)

            For Each adn As Edge In ad

                If flags(adn.dest, adn.src) = False Then
                    edge.Add(adn)
                    flags(adn.src, adn.dest) = True
                End If
            Next
        Next

        For Each e As Edge In edge
            Dim x As Integer = Find(sets, e.src)
            Dim y As Integer = Find(sets, e.dest)

            If x = y Then
                Return True
            End If

            union(sets, x, y)
        Next

        Return False
    End Function

    Public Shared Sub Main8()
        Dim gph As Graph = New Graph(6)
        gph.AddUndirectedEdge(0, 1)
        gph.AddUndirectedEdge(1, 2)
        gph.AddUndirectedEdge(3, 4)
        gph.AddUndirectedEdge(4, 2)
        gph.AddUndirectedEdge(2, 5)
        Console.WriteLine("Cycle Presen : " & gph.IsCyclePresentUndirected())
        Console.WriteLine("Cycle Presen : " & gph.IsCyclePresentUndirected2())
        Console.WriteLine("Cycle Presen : " & gph.IsCyclePresentUndirected3())
        gph.AddUndirectedEdge(4, 1)
        Console.WriteLine("Cycle Presen : " & gph.IsCyclePresentUndirected())
        Console.WriteLine("Cycle Presen : " & gph.IsCyclePresentUndirected2())
        Console.WriteLine("Cycle Presen : " & gph.IsCyclePresentUndirected3())
    End Sub

    Public Function IsCyclePresentDFS(ByVal index As Integer, ByVal visited As Boolean(), ByVal marked As Integer()) As Boolean
        visited(index) = True
        marked(index) = 1
        Dim adl As List(Of Edge) = Adj(index)

        For Each adn As Edge In adl
            Dim dest As Integer = adn.dest

            If marked(dest) = 1 Then
                Return True
            End If

            If visited(dest) = False Then

                If IsCyclePresentDFS(dest, visited, marked) Then
                    Return True
                End If
            End If
        Next

        marked(index) = 0
        Return False
    End Function

    Public Function IsCyclePresent() As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim marked As Integer() = New Integer(count - 1) {}

        For index As Integer = 0 To count - 1

            If Not visited(index) Then

                If IsCyclePresentDFS(index, visited, marked) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Public Function IsCyclePresentDFSColour(ByVal index As Integer, ByVal visited As Integer()) As Boolean
        visited(index) = 1
        Dim dest As Integer
        Dim adl As List(Of Edge) = Adj(index)

        For Each adn As Edge In adl
            dest = adn.dest

            If visited(dest) = 1 Then
                Return True
            End If

            If visited(dest) = 0 Then

                If IsCyclePresentDFSColour(dest, visited) Then
                    Return True
                End If
            End If
        Next

        visited(index) = 2
        Return False
    End Function

    Public Function IsCyclePresentColour() As Boolean
        Dim visited As Integer() = New Integer(count - 1) {}

        For i As Integer = 0 To count - 1

            If visited(i) = 0 Then

                If IsCyclePresentDFSColour(i, visited) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Public Shared Sub Main9()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(2, 3)
        gph.AddDirectedEdge(1, 3)
        gph.AddDirectedEdge(3, 4)
        Console.WriteLine("isCyclePresent : " & gph.IsCyclePresent())
        Console.WriteLine("isCyclePresent : " & gph.IsCyclePresentColour())
        gph.AddDirectedEdge(4, 1)
        Console.WriteLine("isCyclePresent : " & gph.IsCyclePresent())
        Console.WriteLine("isCyclePresent : " & gph.IsCyclePresentColour())
    End Sub

    Public Function TransposeGraph() As Graph
        Dim g As Graph = New Graph(count)

        For i As Integer = 0 To count - 1
            Dim adl As List(Of Edge) = Adj(i)

            For Each adn As Edge In adl
                Dim dest As Integer = adn.dest
                g.AddDirectedEdge(dest, i)
            Next
        Next

        Return g
    End Function

    Public Shared Sub Main10()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(2, 3)
        gph.AddDirectedEdge(1, 3)
        gph.AddDirectedEdge(3, 4)
        gph.AddDirectedEdge(4, 1)
        Dim gReversed As Graph = gph.TransposeGraph()
        gReversed.Print()
    End Sub

    Public Function IsConnectedUndirected() As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        DFSUtil(0, visited)

        For i As Integer = 0 To count - 1

            If visited(i) = False Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Sub Main11()
        Dim gph As Graph = New Graph(6)
        gph.AddUndirectedEdge(0, 1)
        gph.AddUndirectedEdge(1, 2)
        gph.AddUndirectedEdge(3, 4)
        gph.AddUndirectedEdge(2, 5)
        gph.AddUndirectedEdge(4, 2)
        Console.WriteLine("IsConnectedUndirected:: " & gph.IsConnectedUndirected())
    End Sub

    Public Function IsStronglyConnected() As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        DFSUtil(0, visited)

        For i As Integer = 0 To count - 1

            If visited(i) = False Then
                Return False
            End If
        Next

        Dim gReversed As Graph = TransposeGraph()

        For i As Integer = 0 To count - 1
            visited(i) = False
        Next

        gReversed.DFSUtil(0, visited)

        For i As Integer = 0 To count - 1

            If visited(i) = False Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Sub Main12()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(1, 2)
        gph.AddDirectedEdge(2, 3)
        gph.AddDirectedEdge(3, 0)
        gph.AddDirectedEdge(2, 4)
        gph.AddDirectedEdge(4, 2)
        Console.WriteLine("IsStronglyConnected:: " & gph.IsStronglyConnected())
    End Sub

    Public Sub stronglyConnectedComponent()
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim stk As Stack(Of Integer) = New Stack(Of Integer)()

        For i As Integer = 0 To count - 1

            If visited(i) = False Then
                DFSUtil2(i, visited, stk)
            End If
        Next

        Dim gReversed As Graph = TransposeGraph()
        For i As Integer = 0 To (count - 1)
            visited(i) = False
        Next i
        Dim stk2 As Stack(Of Integer) = New Stack(Of Integer)()

        While stk.Count > 0
            Dim index As Integer = stk.Pop()

            If visited(index) = False Then
                stk2.Clear()
                gReversed.DFSUtil2(index, visited, stk2)

                For Each ele In stk2
                    Console.Write(ele & " ")
                Next

                Console.WriteLine()
            End If
        End While
    End Sub

    Public Shared Sub Main13()
        Dim gph As Graph = New Graph(7)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(1, 2)
        gph.AddDirectedEdge(2, 0)
        gph.AddDirectedEdge(2, 3)
        gph.AddDirectedEdge(3, 4)
        gph.AddDirectedEdge(4, 5)
        gph.AddDirectedEdge(5, 3)
        gph.AddDirectedEdge(5, 6)
        gph.stronglyConnectedComponent()
    End Sub

    Public Sub PrimsMST()
        Dim previous(count - 1) As Integer
        Dim dist(count - 1) As Integer
        For i As Integer = 0 To (count - 1)
            previous(i) = -1
            dist(i) = 9999 ' infinite
        Next i
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim source As Integer = 0
        dist(source) = 0
        previous(source) = source
        Dim pq As PriorityQueue(Of Edge) = New PriorityQueue(Of Edge)()
        Dim node As Edge = New Edge(source, source, 0)
        pq.Enqueue(node)

        While pq.IsEmpty() <> True
            node = pq.Peek()
            pq.Dequeue()
            visited(source) = True
            source = node.dest
            Dim adl As List(Of Edge) = Adj(source)

            For Each adn As Edge In adl
                Dim dest As Integer = adn.dest
                Dim alt As Integer = adn.cost

                If dist(dest) > alt AndAlso visited(dest) = False Then
                    dist(dest) = alt
                    previous(dest) = source
                    node = New Edge(source, dest, alt)
                    pq.Enqueue(node)
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

    Public Class Sets
        Friend parent As Integer
        Friend rank As Integer

        Friend Sub New(ByVal p As Integer, ByVal r As Integer)
            parent = p
            rank = r
        End Sub
    End Class

    Public Function Find(ByVal sets As Sets(), ByVal index As Integer) As Integer
        Dim p As Integer = sets(index).parent

        While p <> index
            index = p
            p = sets(index).parent
        End While

        Return index
    End Function

    Public Sub union(ByVal sets As Sets(), ByVal x As Integer, ByVal y As Integer)
        If sets(x).rank < sets(y).rank Then
            sets(x).parent = y
        ElseIf sets(y).rank < sets(x).rank Then
            sets(y).parent = x
        Else
            sets(x).parent = y
            sets(y).rank += 1
        End If
    End Sub

    Public Sub KruskalMST()
        Dim sets As Sets() = New Sets(count - 1) {}

        For i As Integer = 0 To count - 1
            sets(i) = New Sets(i, 0)
        Next

        Dim E As Integer = 0
        Dim edge As Edge() = New Edge(99) {}

        For i As Integer = 0 To count - 1
            Dim ad As List(Of Edge) = Adj(i)

            For Each adn As Edge In ad
                edge(Math.Min(System.Threading.Interlocked.Increment(E), E - 1)) = adn
            Next
        Next

        Array.Sort(edge, 0, E - 1)
        Dim sum As Integer = 0
        Dim output As String = "Edges are "

        For i As Integer = 0 To E - 1
            Dim x As Integer = Find(sets, edge(i).src)
            Dim y As Integer = Find(sets, edge(i).dest)

            If x <> y Then
                output += ("(" & edge(i).src & "->" & edge(i).dest & " @ " & edge(i).cost & ") ")
                sum += edge(i).cost
                union(sets, x, y)
            End If
        Next

        Console.WriteLine(output)
        Console.WriteLine("Total MST cost: " & sum)
    End Sub

    Public Shared Sub Main14()
        Dim gph As Graph = New Graph(9)
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
        Console.WriteLine()
        gph.KruskalMST()
        Console.WriteLine()
        gph.Dijkstra(0)
    End Sub

    Public Sub ShortestPath(ByVal source As Integer)
        Dim curr As Integer
        Dim distance As Integer() = New Integer(count - 1) {}
        Dim previous As Integer() = New Integer(count - 1) {}
        For i As Integer = 0 To count - 1
            distance(i) = -1
            previous(i) = -1
        Next i

        Dim que As Queue(Of Integer) = New Queue(Of Integer)()
        que.Enqueue(source)
        distance(source) = 0
        previous(source) = source

        While que.Count > 0
            curr = que.Dequeue()
            Dim adl As List(Of Edge) = Adj(curr)

            For Each adn As Edge In adl

                If distance(adn.dest) = -1 Then
                    distance(adn.dest) = distance(curr) + 1
                    previous(adn.dest) = curr
                    que.Enqueue(adn.dest)
                End If
            Next
        End While

        PrintPath(previous, distance, count, source)
    End Sub

    Public Sub Dijkstra(ByVal source As Integer)
        Dim previous As Integer() = New Integer(count - 1) {}
        Dim dist As Integer() = New Integer(count - 1) {}
        For i As Integer = 0 To (count - 1)
            previous(i) = -1
            dist(i) = Integer.MaxValue ' infinite
        Next i

        Dim visited As Boolean() = New Boolean(count - 1) {}
        dist(source) = 0
        previous(source) = source
        Dim pq As PriorityQueue(Of Edge) = New PriorityQueue(Of Edge)()
        Dim node As Edge = New Edge(source, source, 0)
        pq.Enqueue(node)
        Dim curr As Integer

        While pq.IsEmpty() <> True
            node = pq.Peek()
            pq.Dequeue()
            curr = node.dest
            visited(curr) = True
            Dim adl As List(Of Edge) = Adj(curr)

            For Each adn As Edge In adl
                Dim dest As Integer = adn.dest
                Dim alt As Integer = adn.cost + dist(curr)

                If dist(dest) > alt AndAlso visited(dest) = False Then
                    dist(dest) = alt
                    previous(dest) = curr
                    node = New Edge(curr, dest, alt)
                    pq.Enqueue(node)
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
            path += "->" + CStr(dest)
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

    Public Sub BellmanFordShortestPath(ByVal source As Integer)
        Dim distance As Integer() = New Integer(count - 1) {}
        Dim path As Integer() = New Integer(count - 1) {}
        For i = 0 To count - 1
            distance(i) = 99999 ' infinite
            path(i) = -1
        Next i

        distance(source) = 0
        path(source) = source

        For i As Integer = 0 To count - 1 - 1
            For j As Integer = 0 To count - 1
                Dim adl As List(Of Edge) = Adj(j)

                For Each adn As Edge In adl
                    Dim newDistance As Integer = distance(j) + adn.cost

                    If distance(adn.dest) > newDistance Then
                        distance(adn.dest) = newDistance
                        path(adn.dest) = j
                    End If
                Next
            Next
        Next

        PrintPath(path, distance, count, source)
    End Sub

    Public Shared Sub Main16()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(0, 1, 3)
        gph.AddDirectedEdge(0, 4, 2)
        gph.AddDirectedEdge(1, 2, 1)
        gph.AddDirectedEdge(2, 3, 1)
        gph.AddDirectedEdge(4, 1, -2)
        gph.AddDirectedEdge(4, 3, 1)
        gph.BellmanFordShortestPath(0)
    End Sub

    Public Shared Function HeightTreeParentArr(ByVal arr As Integer()) As Integer
        Dim count As Integer = arr.Length
        Dim heightArr As Integer() = New Integer(count - 1) {}
        Dim gph As Graph = New Graph(count)
        Dim source As Integer = 0

        For i As Integer = 0 To count - 1

            If arr(i) <> -1 Then
                gph.AddDirectedEdge(arr(i), i)
            Else
                source = i
            End If
        Next

        Dim visited As Boolean() = New Boolean(count - 1) {}
        visited(source) = True
        Dim que As Queue(Of Integer) = New Queue(Of Integer)()
        que.Enqueue(source)
        heightArr(source) = 0
        Dim maxHight As Integer = 0

        While que.Count > 0
            Dim curr As Integer = que.Dequeue()
            Dim height As Integer = heightArr(curr)

            If height > maxHight Then
                maxHight = height
            End If

            Dim adl As List(Of Edge) = gph.Adj(curr)

            For Each adn As Edge In adl

                If visited(adn.dest) = False Then
                    visited(adn.dest) = True
                    que.Enqueue(adn.dest)
                    heightArr(adn.dest) = height + 1
                End If
            Next
        End While

        Return maxHight
    End Function

    Public Shared Function GetHeight(ByVal arr As Integer(), ByVal height As Integer(), ByVal index As Integer) As Integer
        If arr(index) = -1 Then
            Return 0
        Else
            Return GetHeight(arr, height, arr(index)) + 1
        End If
    End Function

    Public Shared Function HeightTreeParentArr2(ByVal arr As Integer()) As Integer
        Dim count As Integer = arr.Length
        Dim height As Integer() = New Integer(count - 1) {}
        Dim maxHeight As Integer = -1

        For i As Integer = 0 To count - 1
            height(i) = GetHeight(arr, height, i)
            maxHeight = Math.Max(maxHeight, height(i))
        Next

        Return maxHeight
    End Function

    Public Shared Sub Main17()
        Dim parentArray As Integer() = New Integer() {-1, 0, 1, 2, 3}
        Console.WriteLine(HeightTreeParentArr(parentArray))
        Console.WriteLine(HeightTreeParentArr2(parentArray))
    End Sub

    Public Function BestFirstSearchPQ(ByVal source As Integer, ByVal dest As Integer) As Integer
        Dim previous As Integer() = New Integer(count - 1) {}
        Dim dist As Integer() = New Integer(count - 1) {}
        Dim visited As Boolean() = New Boolean(count - 1) {}

        For i As Integer = 0 To count - 1
            previous(i) = -1
            dist(i) = Integer.MaxValue
        Next

        Dim pq As PriorityQueue(Of Edge) = New PriorityQueue(Of Edge)()
        dist(source) = 0
        previous(source) = -1
        Dim node As Edge = New Edge(source, source, 0)
        pq.Enqueue(node)

        While pq.IsEmpty() <> True
            node = pq.Peek()
            pq.Dequeue()
            source = node.dest

            If source = dest Then
                Return node.cost
            End If

            visited(source) = True
            Dim adl As List(Of Edge) = Adj(source)

            For Each adn As Edge In adl
                Dim curr As Integer = adn.dest
                Dim cost As Integer = adn.cost
                Dim alt As Integer = cost + dist(source)

                If dist(curr) > alt AndAlso visited(curr) = False Then
                    dist(curr) = alt
                    previous(curr) = source
                    node = New Edge(source, curr, alt)
                    pq.Enqueue(node)
                End If
            Next
        End While

        Return -1
    End Function

    Public Function IsConnected() As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim adl As List(Of Edge)

        For i As Integer = 0 To count - 1
            adl = Adj(i)

            If adl.Count > 0 Then
                DFSUtil(i, visited)
                Exit For
            End If
        Next

        For i As Integer = 0 To count - 1
            adl = Adj(i)

            If adl.Count > 0 Then

                If visited(i) = False Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Public Function IsEulerian() As Integer
        Dim odd As Integer
        Dim inDegree As Integer()
        Dim outDegree As Integer()
        Dim adl As List(Of Edge)

        If IsConnected() = False Then
            Console.WriteLine("graph is not Eulerian")
            Return 0
        Else
            odd = 0
            inDegree = New Integer(count - 1) {}
            outDegree = New Integer(count - 1) {}

            For i As Integer = 0 To count - 1
                adl = Adj(i)

                For Each adn As Edge In adl
                    outDegree(i) += 1
                    inDegree(adn.dest) += 1
                Next
            Next

            For i As Integer = 0 To count - 1

                If (inDegree(i) + outDegree(i)) Mod 2 <> 0 Then
                    odd += 1
                End If
            Next
        End If

        If odd = 0 Then
            Console.WriteLine("Graph is Eulerian")
            Return 2
        ElseIf odd = 2 Then
            Console.WriteLine("Graph is Semi-Eulerian")
            Return 1
        Else
            Console.WriteLine("Graph is not Eulerian")
            Return 0
        End If
    End Function

    Public Shared Sub Main18()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(1, 0)
        gph.AddDirectedEdge(0, 2)
        gph.AddDirectedEdge(2, 1)
        gph.AddDirectedEdge(0, 3)
        gph.AddDirectedEdge(3, 4)
        gph.IsEulerian()
        gph.AddDirectedEdge(4, 0)
        gph.IsEulerian()
    End Sub

    Public Function IsStronglyConnected2() As Boolean
        Dim visited As Boolean() = New Boolean(count - 1) {}
        Dim gReversed As Graph
        Dim index As Integer
        Dim adl As List(Of Edge)

        For index = 0 To count - 1
            adl = Adj(index)

            If adl.Count > 0 Then
                Exit For
            End If
        Next

        DFSUtil(index, visited)

        For i As Integer = 0 To count - 1
            adl = Adj(i)

            If visited(i) = False AndAlso adl.Count > 0 Then
                Return False
            End If
        Next

        gReversed = TransposeGraph()

        For i As Integer = 0 To count - 1
            visited(i) = False
        Next

        gReversed.DFSUtil(index, visited)

        For i As Integer = 0 To count - 1
            adl = Adj(i)

            If visited(i) = False AndAlso adl.Count > 0 Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function IsEulerianCycle() As Boolean
        Dim inDegree As Integer() = New Integer(count - 1) {}
        Dim outDegree As Integer() = New Integer(count - 1) {}

        If Not IsStronglyConnected2() Then
            Return False
        End If

        For i As Integer = 0 To count - 1
            Dim adl As List(Of Edge) = Adj(i)

            For Each adn As Edge In adl
                outDegree(i) += 1
                inDegree(adn.dest) += 1
            Next
        Next

        For i As Integer = 0 To count - 1

            If inDegree(i) <> outDegree(i) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Sub Main19()
        Dim gph As Graph = New Graph(5)
        gph.AddDirectedEdge(0, 1)
        gph.AddDirectedEdge(1, 2)
        gph.AddDirectedEdge(2, 0)
        gph.AddDirectedEdge(0, 4)
        gph.AddDirectedEdge(4, 3)
        gph.AddDirectedEdge(3, 0)
        Console.WriteLine(gph.IsEulerianCycle())
    End Sub

    Public Shared Sub Main20()
        Dim gph As Graph = New Graph(9)
        gph.AddUndirectedEdge(0, 1)
        gph.AddUndirectedEdge(0, 7)
        gph.AddUndirectedEdge(1, 2)
        gph.AddUndirectedEdge(1, 7)
        gph.AddUndirectedEdge(2, 3)
        gph.AddUndirectedEdge(2, 8)
        gph.AddUndirectedEdge(2, 5)
        gph.AddUndirectedEdge(3, 4)
        gph.AddUndirectedEdge(3, 5)
        gph.AddUndirectedEdge(4, 5)
        gph.AddUndirectedEdge(5, 6)
        gph.AddUndirectedEdge(6, 7)
        gph.AddUndirectedEdge(6, 8)
        gph.AddUndirectedEdge(7, 8)
        gph.ShortestPath(0)
    End Sub

    Public Sub FloydWarshall()
        Dim V As Integer = count
        Dim dist As Integer(,) = New Integer(V - 1, V - 1) {}
        Dim path As Integer(,) = New Integer(V - 1, V - 1) {}

        For i As Integer = 0 To V - 1

            For j As Integer = 0 To V - 1
                dist(i, j) = 99999

                If i = j Then
                    path(i, j) = 0
                Else
                    path(i, j) = -1
                End If
            Next
        Next

        For i As Integer = 0 To V - 1
            Dim adl As List(Of Edge) = Adj(i)

            For Each adn As Edge In adl
                path(adn.src, adn.dest) = adn.src
                dist(adn.src, adn.dest) = adn.cost
            Next
        Next

        For k As Integer = 0 To V - 1

            For i As Integer = 0 To V - 1

                For j As Integer = 0 To V - 1

                    If dist(i, k) + dist(k, j) < dist(i, j) Then
                        dist(i, j) = dist(i, k) + dist(k, j)
                        path(i, j) = path(k, j)
                    End If
                Next

                If dist(i, i) < 0 Then
                    Console.WriteLine("Negative-weight cycle found.")
                    Return
                End If
            Next
        Next

        PrintSolution(dist, path, V)
    End Sub

    Private Sub PrintSolution(ByVal cost As Integer(,), ByVal path As Integer(,), ByVal V As Integer)
        Console.Write("Shortest Paths : ")

        For i As Integer = 0 To V - 1

            For j As Integer = 0 To V - 1

                If i <> j AndAlso path(i, j) <> -1 Then
                    Console.Write("(")
                    PrintPath(path, i, j)
                    Console.Write(" @ " & cost(i, j) & ") ")
                End If
            Next
        Next

        Console.WriteLine()
    End Sub

    Private Sub PrintPath(ByVal path As Integer(,), ByVal u As Integer, ByVal v As Integer)
        If path(u, v) = u Then
            Console.Write(u & "->" & v)
            Return
        End If

        PrintPath(path, u, path(u, v))
        Console.Write("->" & v)
    End Sub

    Public Shared Sub Main21()
        Dim gph As Graph = New Graph(4)
        gph.AddDirectedEdge(0, 0, 0)
        gph.AddDirectedEdge(1, 1, 0)
        gph.AddDirectedEdge(2, 2, 0)
        gph.AddDirectedEdge(3, 3, 0)
        gph.AddDirectedEdge(0, 1, 5)
        gph.AddDirectedEdge(0, 3, 10)
        gph.AddDirectedEdge(1, 2, 3)
        gph.AddDirectedEdge(2, 3, 1)
        gph.FloydWarshall()
    End Sub

    Friend Sub PrintSolution(ByVal dist As Integer(,), ByVal V As Integer)
        For i As Integer = 0 To V - 1

            For j As Integer = 0 To V - 1

                If dist(i, j) = Integer.MaxValue Then
                    Console.Write("INF ")
                Else
                    Console.Write(dist(i, j) & "   ")
                End If
            Next

            Console.WriteLine()
        Next
    End Sub

    Public Shared Sub Main(ByVal args As String())
        Main1()
        Main2()
        Main3()
        Main4()
        Main5()
        Main6()
        Main7()
        Main8()
        Main9()
        Main10()
        Main11()
        Main12()
        Main13()
        Main14()
        Main16()
        Main17()
        Main18()
        Main19()
        Main20()
        Main21()
    End Sub
End Class


Public Class PriorityQueue(Of T As IComparable(Of T))
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
        Dim hp As New PriorityQueue(Of Integer)(array, Not inc)
        For i As Integer = 0 To array.Length - 1
            array(array.Length - i - 1) = hp.Dequeue()
        Next i
    End Sub
End Class

