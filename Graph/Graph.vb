Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class Graph
	Friend count As Integer
	Private Adj As List(Of List(Of Edge))

	Private Class Edge
		Implements IComparable(Of Edge)

		Friend dest As Integer
		Friend cost As Integer

		Public Sub New(ByVal dst As Integer, ByVal cst As Integer)
			dest = dst
			cost = cst
		End Sub

		Private Function IComparableGeneric_CompareTo(ByVal other As Edge) As Integer Implements IComparable(Of Edge).CompareTo
			Return cost - other.cost
		End Function
	End Class

	Public Sub New(ByVal cnt As Integer)
		count = cnt
		Adj = New List(Of List(Of Edge))()
		For i As Integer = 0 To cnt - 1
			Adj.Add(New List(Of Edge)())
		Next i
	End Sub

	Private Sub addDirectedEdge(ByVal source As Integer, ByVal dest As Integer, ByVal cost As Integer)
		Dim edge As New Edge(dest, cost)
		Adj(source).Add(edge)
	End Sub

	Public Overridable Sub addDirectedEdge(ByVal source As Integer, ByVal dest As Integer)
		addDirectedEdge(source, dest, 1)
	End Sub

	Public Overridable Sub addUndirectedEdge(ByVal source As Integer, ByVal dest As Integer, ByVal cost As Integer)
		addDirectedEdge(source, dest, cost)
		addDirectedEdge(dest, source, cost)
	End Sub

	Public Overridable Sub addUndirectedEdge(ByVal source As Integer, ByVal dest As Integer)
		addUndirectedEdge(source, dest, 1)
	End Sub

	Public Overridable Sub print()
		For i As Integer = 0 To count - 1
			Dim ad As List(Of Edge) = Adj(i)
			Console.Write(ControlChars.Lf & " Vertex " & i & " is connected to : ")
			For Each adn As Edge In ad
				Console.Write("(" & adn.dest & ", " & adn.cost & ") ")
			Next adn
		Next i
	End Sub

	Public Shared Function dfsStack(ByVal gph As Graph, ByVal source As Integer, ByVal target As Integer) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		Dim stk As New Stack(Of Integer)()
		stk.Push(source)
		visited(source) = True

		Do While stk.Count > 0
			Dim curr As Integer = stk.Pop()
			Dim adl As List(Of Edge) = gph.Adj(curr)
			For Each adn As Edge In adl
				If visited(adn.dest) = False Then
					visited(adn.dest) = True
					stk.Push(adn.dest)
				End If
			Next adn
		Loop
		Return visited(target)
	End Function

	Public Shared Function dfs(ByVal gph As Graph, ByVal source As Integer, ByVal target As Integer) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		dfsUtil(gph, source, visited)
		Return visited(target)
	End Function

	Public Shared Sub dfsUtil(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Boolean)
		visited(index) = True
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				dfsUtil(gph, adn.dest, visited)
			End If
		Next adn
	End Sub

	Public Shared Sub dfsUtil2(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Boolean, ByVal stk As Stack(Of Integer))
		visited(index) = True
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				dfsUtil2(gph, adn.dest, visited, stk)
			End If
		Next adn
		stk.Push(index)
	End Sub

	Public Shared Function bfs(ByVal gph As Graph, ByVal source As Integer, ByVal target As Integer) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim que As New Queue(Of Integer)()
		que.Enqueue(source)
		visited(source) = True

		Do While que.Count > 0
			Dim curr As Integer = que.Dequeue()
			Dim adl As List(Of Edge) = gph.Adj(curr)
			For Each adn As Edge In adl
				If visited(adn.dest) = False Then
					visited(adn.dest) = True
					que.Enqueue(adn.dest)
				End If
			Next adn
		Loop
		Return visited(target)
	End Function

	Public Shared Sub Main1()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(0, 1, 3)
		gph.addDirectedEdge(0, 4, 2)
		gph.addDirectedEdge(1, 2, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(4, 1, -2)
		gph.addDirectedEdge(4, 3, 1)
		gph.print()
		Console.WriteLine(Graph.dfs(gph, 0, 2))
		Console.WriteLine(Graph.bfs(gph, 0, 2))
		Console.WriteLine(Graph.dfsStack(gph, 0, 2))
	End Sub

	Public Shared Sub topologicalSort(ByVal gph As Graph)
		Dim stk As New Stack(Of Integer)()
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				dfsUtil2(gph, i, visited, stk)
			End If
		Next i
		Console.Write("topologicalSort :: ")
		Do While stk.Count = 0 <> True
			Console.Write(" " & stk.Pop())
		Loop
	End Sub

	Public Shared Sub main2()
		Dim gph As New Graph(6)
		gph.addDirectedEdge(5, 2, 1)
		gph.addDirectedEdge(5, 0, 1)
		gph.addDirectedEdge(4, 0, 1)
		gph.addDirectedEdge(4, 1, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(3, 1, 1)
		gph.print()
		topologicalSort(gph)
	End Sub

	Public Shared Function pathExist(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		dfsUtil(gph, source, visited)
		Return visited(dest)
	End Function

	Public Shared Function countAllPathDFS(ByVal gph As Graph, ByVal visited() As Boolean, ByVal source As Integer, ByVal dest As Integer) As Integer
		If source = dest Then
			Return 1
		End If
		Dim count As Integer = 0
		visited(source) = True
		Dim adl As List(Of Edge) = gph.Adj(source)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				count += countAllPathDFS(gph, visited, adn.dest, dest)
			End If
			visited(source) = False
		Next adn
		Return count
	End Function

	Public Shared Function countAllPath(ByVal gph As Graph, ByVal src As Integer, ByVal dest As Integer) As Integer
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Return countAllPathDFS(gph, visited, src, dest)
	End Function

	Public Shared Sub printAllPathDFS(ByVal gph As Graph, ByVal visited() As Boolean, ByVal source As Integer, ByVal dest As Integer, ByVal path As Stack(Of Integer))
		path.Push(source)

		If source = dest Then
			Console.WriteLine(path)
			path.Pop()
			Return
		End If
		visited(source) = True
		Dim adl As List(Of Edge) = gph.Adj(source)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				printAllPathDFS(gph, visited, adn.dest, dest, path)
			End If
		Next adn
		visited(source) = False
		path.Pop()
	End Sub

	Public Shared Sub printAllPath(ByVal gph As Graph, ByVal src As Integer, ByVal dest As Integer)
		Dim visited(gph.count - 1) As Boolean
		Dim path As New Stack(Of Integer)()
		printAllPathDFS(gph, visited, src, dest, path)
	End Sub

	Public Shared Sub main3()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(0, 2, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(1, 3, 1)
		gph.addDirectedEdge(3, 4, 1)
		gph.addDirectedEdge(1, 4, 1)
		gph.print()
		Console.WriteLine("PathExist :: " & pathExist(gph, 0, 4))

		Console.WriteLine()
		Console.WriteLine(countAllPath(gph, 0, 4))
		printAllPath(gph, 0, 4)
	End Sub

	Public Shared Function rootVertex(ByVal gph As Graph) As Integer
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim retVal As Integer = -1
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				dfsUtil(gph, i, visited)
				retVal = i
			End If
		Next i
		Console.Write("Root vertex is :: " & retVal)
		Return retVal
	End Function

	Public Shared Sub main4()
		Dim gph As New Graph(7)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(0, 2, 1)
		gph.addDirectedEdge(1, 3, 1)
		gph.addDirectedEdge(4, 1, 1)
		gph.addDirectedEdge(6, 4, 1)
		gph.addDirectedEdge(5, 6, 1)
		gph.addDirectedEdge(5, 2, 1)
		gph.addDirectedEdge(6, 0, 1)
		gph.print()
		rootVertex(gph)
	End Sub

	'	
	'		* Given a directed graph, find transitive closure matrix or reach ability
	'		* matrix vertex v is reachable form vertex u if their is a path from u to v.
	'		

	Public Shared Sub transitiveClosureUtil(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer, ByVal tc(,) As Integer)
		tc(source, dest) = 1
		Dim adl As List(Of Edge) = gph.Adj(dest)
		For Each adn As Edge In adl
			If tc(source, adn.dest) = 0 Then
				transitiveClosureUtil(gph, source, adn.dest, tc)
			End If
		Next adn
	End Sub

	Public Shared Function transitiveClosure(ByVal gph As Graph) As Integer(,)
		Dim count As Integer = gph.count
		Dim tc(count - 1, count - 1) As Integer

		For i As Integer = 0 To count - 1
			transitiveClosureUtil(gph, i, i, tc)
		Next i
		Return tc
	End Function

	Public Shared Sub main5()
		Dim gph As New Graph(4)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(0, 2, 1)
		gph.addDirectedEdge(1, 2, 1)
		gph.addDirectedEdge(2, 0, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(3, 3, 1)
		Dim tc(,) As Integer = transitiveClosure(gph)
		For i As Integer = 0 To 3
			For j As Integer = 0 To 3
				Console.Write(tc(i, j) & " ")
			Next j
			Console.WriteLine()
		Next i
	End Sub

	Public Shared Sub bfsLevelNode(ByVal gph As Graph, ByVal source As Integer)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim level(count - 1) As Integer
		visited(source) = True

		Dim que As New Queue(Of Integer)()
		que.Enqueue(source)
		level(source) = 0
		Console.WriteLine(ControlChars.Lf & "Node  - Level")

		Do While que.Count > 0
			Dim curr As Integer = que.Dequeue()
			Dim depth As Integer = level(curr)
			Dim adl As List(Of Edge) = gph.Adj(curr)
			Console.WriteLine(curr & " - " & depth)
			For Each adn As Edge In adl
				If visited(adn.dest) = False Then
					visited(adn.dest) = True
					que.Enqueue(adn.dest)
					level(adn.dest) = depth + 1
				End If
			Next adn
		Loop
	End Sub

	Public Shared Function bfsDistance(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer) As Integer
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim que As New Queue(Of Integer)()
		que.Enqueue(source)
		visited(source) = True
		Dim level(count - 1) As Integer
		level(source) = 0

		Do While que.Count > 0
			Dim curr As Integer = que.Dequeue()
			Dim depth As Integer = level(curr)
			Dim adl As List(Of Edge) = gph.Adj(curr)
			For Each adn As Edge In adl
				If adn.dest = dest Then
					Return depth
				End If
				If visited(adn.dest) = False Then
					visited(adn.dest) = True
					que.Enqueue(adn.dest)
					level(adn.dest) = depth + 1
				End If
			Next adn
		Loop
		Return -1
	End Function

	Public Shared Sub main6()
		Dim gph As New Graph(7)
		gph.addUndirectedEdge(0, 1, 1)
		gph.addUndirectedEdge(0, 2, 1)
		gph.addUndirectedEdge(0, 4, 1)
		gph.addUndirectedEdge(1, 2, 1)
		gph.addUndirectedEdge(2, 5, 1)
		gph.addUndirectedEdge(3, 4, 1)
		gph.addUndirectedEdge(4, 5, 1)
		gph.addUndirectedEdge(4, 6, 1)
		gph.print()
		bfsLevelNode(gph, 1)
		Console.WriteLine(bfsDistance(gph, 1, 6))
	End Sub

	Public Shared Function isCyclePresentUndirectedDFS(ByVal graph_Renamed As Graph, ByVal index As Integer, ByVal parentIndex As Integer, ByVal visited() As Boolean) As Boolean
		visited(index) = True
		Dim dest As Integer
		Dim adl As List(Of Edge) = graph_Renamed.Adj(index)
		For Each adn As Edge In adl
			dest = adn.dest
			If visited(dest) = False Then
				If isCyclePresentUndirectedDFS(graph_Renamed, dest, index, visited) Then
					Return True
				End If
			ElseIf parentIndex <> dest Then
				Return True
			End If
		Next adn
		Return False
	End Function

	Public Shared Function isCyclePresentUndirected(ByVal graph_Renamed As Graph) As Boolean
		Dim count As Integer = graph_Renamed.count
		Dim visited(count - 1) As Boolean
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				If isCyclePresentUndirectedDFS(graph_Renamed, i, -1, visited) Then
					Return True
				End If
			End If
		Next i
		Return False
	End Function

	Public Shared Sub main7()
		Dim gph As New Graph(6)
		gph.addUndirectedEdge(0, 1, 1)
		gph.addUndirectedEdge(1, 2, 1)
		gph.addUndirectedEdge(3, 4, 1)
		gph.addUndirectedEdge(4, 2, 1)
		gph.addUndirectedEdge(2, 5, 1)
		' gph.addUndirectedEdge(4, 1, 1);
		Console.WriteLine(isCyclePresentUndirected(gph))
	End Sub

	'	
	'		* Given a directed graph find if there is a cycle in it.
	'		
	Public Shared Function isCyclePresentDFS(ByVal graph_Renamed As Graph, ByVal index As Integer, ByVal visited() As Boolean, ByVal marked() As Integer) As Boolean
		visited(index) = True
		marked(index) = 1
		Dim adl As List(Of Edge) = graph_Renamed.Adj(index)
		For Each adn As Edge In adl
			Dim dest As Integer = adn.dest
			If marked(dest) = 1 Then
				Return True
			End If

			If visited(dest) = False Then
				If isCyclePresentDFS(graph_Renamed, dest, visited, marked) Then
					Return True
				End If
			End If
		Next adn
		marked(index) = 0
		Return False
	End Function

	Public Shared Function isCyclePresent(ByVal graph_Renamed As Graph) As Boolean
		Dim count As Integer = graph_Renamed.count
		Dim visited(count - 1) As Boolean
		Dim marked(count - 1) As Integer
		For index As Integer = 0 To count - 1
			If visited(index) = False Then
				If isCyclePresentDFS(graph_Renamed, index, visited, marked) Then
					Return True
				End If
			End If
		Next index
		Return False
	End Function

	Public Shared Function isCyclePresentDFSColor(ByVal graph_Renamed As Graph, ByVal index As Integer, ByVal visited() As Integer) As Boolean
		visited(index) = 1 ' 1 = grey
		Dim dest As Integer
		Dim adl As List(Of Edge) = graph_Renamed.Adj(index)
		For Each adn As Edge In adl
			dest = adn.dest
			If visited(dest) = 1 Then ' "Grey":
				Return True
			End If

			If visited(dest) = 0 Then ' "White":
				If isCyclePresentDFSColor(graph_Renamed, dest, visited) Then
					Return True
				End If
			End If
		Next adn
		visited(index) = 2 ' "Black"
		Return False
	End Function

	Public Shared Function isCyclePresentColor(ByVal graph_Renamed As Graph) As Boolean
		Dim count As Integer = graph_Renamed.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			If visited(i) = 0 Then ' "White"
				If isCyclePresentDFSColor(graph_Renamed, i, visited) Then
					Return True
				End If
			End If
		Next i
		Return False
	End Function

	Public Shared Sub main8()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(0, 2, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(1, 3, 1)
		gph.addDirectedEdge(3, 4, 1)
		gph.addDirectedEdge(4, 1, 1)
		Console.WriteLine(isCyclePresentColor(gph))
	End Sub

	Public Shared Function transposeGraph(ByVal gph As Graph) As Graph
		Dim count As Integer = gph.count
		Dim g As New Graph(count)
		For i As Integer = 0 To count - 1
			Dim adl As List(Of Edge) = gph.Adj(i)
			For Each adn As Edge In adl
				Dim dest As Integer = adn.dest
				g.addDirectedEdge(dest, i)
			Next adn
		Next i
		Return g
	End Function

	Public Shared Function isConnectedUndirected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		dfsUtil(gph, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				Return False
			End If
		Next i
		Return True
	End Function

	'	
	'		* Kosaraju Algorithm
	'		* 
	'		* Kosaraju’s Algorithm to find strongly connected directed graph based on DFS :
	'		* 1) Create a visited array of size V, and Initialize all count in visited array as 0. 
	'		* 2) Choose any vertex and perform a DFS traversal of graph. For all visited count mark them visited as 1. 
	'		* 3) If DFS traversal does not mark all count as 1, then return 0. 
	'		* 4) Find transpose or reverse of graph 
	'		* 5) Repeat step 1, 2 and 3 for the reversed graph. 
	'		* 6) If DFS traversal mark all the count as 1, then return 1.
	'		
	Public Shared Function isStronglyConnected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		dfsUtil(gph, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				Return False
			End If
		Next i
		Dim gReversed As Graph = transposeGraph(gph)
		For i As Integer = 0 To count - 1
			visited(i) = False
		Next i
		dfsUtil(gReversed, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Sub main9()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(1, 2, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(3, 0, 1)
		gph.addDirectedEdge(2, 4, 1)
		gph.addDirectedEdge(4, 2, 1)
		Console.WriteLine(" IsStronglyConnected:: " & isStronglyConnected(gph))
	End Sub

	Public Shared Sub stronglyConnectedComponent(ByVal gph As Graph)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		Dim stk As New Stack(Of Integer)()
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				dfsUtil2(gph, i, visited, stk)
			End If
		Next i
		Dim gReversed As Graph = transposeGraph(gph)
		For i As Integer = 0 To count - 1
			visited(i) = False
		Next i

		Dim stk2 As New Stack(Of Integer)()
		Do While stk.Count > 0
			Dim index As Integer = stk.Pop()
			If visited(index) = False Then
				stk2.Clear()
				dfsUtil2(gReversed, index, visited, stk2)
				Console.WriteLine(stk2)
			End If
		Loop
	End Sub

	Public Shared Sub main10()
		Dim gph As New Graph(7)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(1, 2, 1)
		gph.addDirectedEdge(2, 0, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(3, 4, 1)
		gph.addDirectedEdge(4, 5, 1)
		gph.addDirectedEdge(5, 3, 1)
		gph.addDirectedEdge(5, 6, 1)
		stronglyConnectedComponent(gph)
	End Sub

	Public Shared Sub prims(ByVal gph As Graph)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim visited(gph.count - 1) As Boolean
		Dim source As Integer = 1

		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = 999999 ' infinite
		Next i

		dist(source) = 0
		previous(source) = -1
		Dim queue As New PriorityQueue(Of Edge)()
		Dim node As New Edge(source, 0)
		queue.add(node)

		Do While queue.isEmpty() <> True
			node = queue.peek()
			queue.remove()
			visited(source) = True
			source = node.dest
			Dim adl As List(Of Edge) = gph.Adj(source)
			For Each adn As Edge In adl
				Dim dest As Integer = adn.dest
				Dim alt As Integer = adn.cost
				If dist(dest) > alt AndAlso visited(dest) = False Then
					dist(dest) = alt
					previous(dest) = source
					node = New Edge(dest, alt)
					queue.add(node)
				End If
			Next adn
		Loop
		' printing result.
		Dim count As Integer = gph.count
		For i As Integer = 0 To count - 1
			If dist(i) = Integer.MaxValue Then
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : Unreachable")
			Else
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : " & dist(i))
			End If
		Next i
	End Sub

	Public Shared Sub main11()
		Dim gph As New Graph(9)
		gph.addUndirectedEdge(0, 1, 4)
		gph.addUndirectedEdge(0, 7, 8)
		gph.addUndirectedEdge(1, 2, 8)
		gph.addUndirectedEdge(1, 7, 11)
		gph.addUndirectedEdge(2, 3, 7)
		gph.addUndirectedEdge(2, 8, 2)
		gph.addUndirectedEdge(2, 5, 4)
		gph.addUndirectedEdge(3, 4, 9)
		gph.addUndirectedEdge(3, 5, 14)
		gph.addUndirectedEdge(4, 5, 10)
		gph.addUndirectedEdge(5, 6, 2)
		gph.addUndirectedEdge(6, 7, 1)
		gph.addUndirectedEdge(6, 8, 6)
		gph.addUndirectedEdge(7, 8, 7)
		gph.print()
		Console.WriteLine()
		prims(gph)
		Console.WriteLine()
		dijkstra(gph, 0)
	End Sub

	Public Shared Sub shortestPath(ByVal gph As Graph, ByVal source As Integer) ' unweighted graph
		Dim curr As Integer
		Dim count As Integer = gph.count
		Dim distance(count - 1) As Integer
		Dim path(count - 1) As Integer
		For i As Integer = 0 To count - 1
			distance(i) = -1
		Next i
		Dim que As New Queue(Of Integer)()
		que.Enqueue(source)
		distance(source) = 0
		Do While que.Count > 0
			curr = que.Dequeue()
			Dim adl As List(Of Edge) = gph.Adj(curr)
			For Each adn As Edge In adl
				If distance(adn.dest) = -1 Then
					distance(adn.dest) = distance(curr) + 1
					path(adn.dest) = curr
					que.Enqueue(adn.dest)
				End If
			Next adn
		Loop
		For i As Integer = 0 To count - 1
			Console.WriteLine(path(i) & " to " & i & " weight " & distance(i))
		Next i
	End Sub

	Public Shared Sub main12()
		Dim gph As New Graph(9)
		gph.addUndirectedEdge(0, 2, 1)
		gph.addUndirectedEdge(1, 2, 5)
		gph.addUndirectedEdge(1, 3, 7)
		gph.addUndirectedEdge(1, 4, 9)
		gph.addUndirectedEdge(3, 2, 2)
		gph.addUndirectedEdge(3, 5, 4)
		gph.addUndirectedEdge(4, 5, 6)
		gph.addUndirectedEdge(4, 6, 3)
		gph.addUndirectedEdge(5, 7, 1)
		gph.addUndirectedEdge(6, 7, 7)
		gph.addUndirectedEdge(7, 8, 17)
		bellmanFordshortestPath(gph, 1)
		dijkstra(gph, 1)
		prims(gph)
		Console.WriteLine("isConnectedUndirected :: " & isConnectedUndirected(gph))
	End Sub

	Public Shared Sub dijkstra(ByVal gph As Graph, ByVal source As Integer)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim visited(gph.count - 1) As Boolean

		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = 999999 ' infinite
		Next i

		dist(source) = 0
		previous(source) = -1
		Dim queue As New PriorityQueue(Of Edge)()
		Dim node As New Edge(source, 0)
		queue.add(node)

		Do While queue.isEmpty() <> True
			node = queue.peek()
			queue.remove()
			source = node.dest
			visited(source) = True
			Dim adl As List(Of Edge) = gph.Adj(source)
			For Each adn As Edge In adl
				Dim dest As Integer = adn.dest
				Dim alt As Integer = adn.cost + dist(source)
				If dist(dest) > alt AndAlso visited(dest) = False Then
					dist(dest) = alt
					previous(dest) = source
					node = New Edge(dest, alt)
					queue.add(node)
				End If
			Next adn
		Loop

		Dim count As Integer = gph.count
		For i As Integer = 0 To count - 1
			If dist(i) = Integer.MaxValue Then
				Console.WriteLine(" " & ControlChars.Lf & " node id " & i & "  prev " & previous(i) & " distance : Unreachable")
			Else
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : " & dist(i))
			End If
		Next i
	End Sub

	Public Shared Sub bellmanFordshortestPath(ByVal gph As Graph, ByVal source As Integer)
		Dim count As Integer = gph.count
		Dim distance(count - 1) As Integer
		Dim path(count - 1) As Integer

		For j As Integer = 0 To count - 1
			distance(j) = 999999 ' infinite
			path(j) = -1
		Next j

		distance(source) = 0
		' Outer loop will run (V-1) number of times.
		' Inner for loop and while loop runs combined will run for Edges number of times.
		' Which make the total complexity as O(V*E)

		Dim i As Integer = 0
		Do While i < count - 1
			For j As Integer = 0 To count - 1
				Dim adl As List(Of Edge) = gph.Adj(j)
				For Each adn As Edge In adl
					Dim newDistance As Integer = distance(j) + adn.cost
					If distance(adn.dest) > newDistance Then
						distance(adn.dest) = newDistance
						path(adn.dest) = j
					End If
				Next adn
			Next j
			i += 1
		Loop
		For k As Integer = 0 To count - 1
			Console.WriteLine(path(k) & " to " & k & " weight " & distance(k))
		Next k
	End Sub

	Public Shared Sub main13()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(0, 1, 3)
		gph.addDirectedEdge(0, 4, 2)
		gph.addDirectedEdge(1, 2, 1)
		gph.addDirectedEdge(2, 3, 1)
		gph.addDirectedEdge(4, 1, -2)
		gph.addDirectedEdge(4, 3, 1)
		gph.print()
		Console.WriteLine()
		bellmanFordshortestPath(gph, 0)
	End Sub

	Public Shared Function heightTreeParentArr(ByVal arr() As Integer) As Integer
		Dim count As Integer = arr.Length
		Dim heightArr(count - 1) As Integer
		Dim gph As New Graph(count)
		Dim source As Integer = 0
		For i As Integer = 0 To count - 1
			If arr(i) <> -1 Then
				gph.addDirectedEdge(arr(i), i)
			Else
				source = i
			End If
		Next i
		Dim visited(count - 1) As Boolean
		visited(source) = True
		Dim que As New Queue(Of Integer)()
		que.Enqueue(source)
		heightArr(source) = 0
		Dim maxHight As Integer = 0
		Do While que.Count > 0
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
			Next adn
		Loop
		Return maxHight
	End Function

	Public Shared Function getHeight(ByVal arr() As Integer, ByVal height() As Integer, ByVal index As Integer) As Integer
		If arr(index) = -1 Then
			Return 0
		Else
			Return getHeight(arr, height, arr(index)) + 1
		End If
	End Function

	Public Shared Function heightTreeParentArr2(ByVal arr() As Integer) As Integer
		Dim count As Integer = arr.Length
		Dim height(count - 1) As Integer
		Dim maxHeight As Integer = -1
		For i As Integer = 0 To count - 1
			height(i) = getHeight(arr, height, i)
			maxHeight = Math.Max(maxHeight, height(i))
		Next i
		Return maxHeight
	End Function

	Public Shared Sub main14()
		Dim parentArray() As Integer = {-1, 0, 1, 2, 3}
		Console.WriteLine(heightTreeParentArr(parentArray))
		Console.WriteLine(heightTreeParentArr2(parentArray))
	End Sub
	'	
	'	public static int bestFirstSearchPQ(Graph gph, int source, int dest)
	'	{
	'		int[] previous = new int[gph.count];
	'		int[] dist = new int[gph.count];
	'		bool[] visited = new bool[gph.count];
	'		for (int i = 0; i < gph.count; i++)
	'		{
	'			previous[i] = -1;
	'			dist[i] = 999999; // infinite
	'		}
	'		EdgeComparator comp = new EdgeComparator();
	'		PriorityQueue<Edge> pq = new PriorityQueue<Edge>(100, comp);
	'		dist[source] = 0;
	'		previous[source] = -1;
	'		Edge node = new Edge(source, 0);
	'		pq.add(node);
	'
	'		while (pq.Empty != true)
	'		{
	'			node = pq.peek();
	'			pq.remove();
	'			source = node.dest;
	'			if (source == dest)
	'			{
	'				return node.cost;
	'			}
	'			visited[source] = true;
	'
	'			List<Edge> adl = gph.Adj[source];
	'			foreach (Edge adn in adl)
	'			{
	'				int curr = adn.dest;
	'				int cost = adn.cost;
	'				int alt = cost + dist[source];
	'				if (dist[curr] > alt && visited[curr] == false)
	'				{
	'					dist[curr] = alt;
	'					previous[curr] = source;
	'					node = new Edge(curr, alt);
	'					pq.add(node);
	'				}
	'			}
	'		}
	'		return -1;
	'	}
	'	
	Public Shared Function isConnected(ByVal graph_Renamed As Graph) As Boolean
		Dim count As Integer = graph_Renamed.count
		Dim visited(count - 1) As Boolean

		' Find a vertex with non - zero degree
		' DFS traversal of graph from a vertex with non - zero degree
		Dim adl As List(Of Edge)
		For i As Integer = 0 To count - 1
			adl = graph_Renamed.Adj(i)
			If adl.Count > 0 Then
				dfsUtil(graph_Renamed, i, visited)
				Exit For
			End If
		Next i
		' Check if all non - zero degree count are visited
		For i As Integer = 0 To count - 1
			adl = graph_Renamed.Adj(i)
			If adl.Count > 0 Then
				If visited(i) = False Then
					Return False
				End If
			End If
		Next i
		Return True
	End Function

	'	
	'		* The function returns one of the following values Return 0 if graph is not
	'		* Eulerian Return 1 if graph has an Euler path (Semi-Eulerian) Return 2 if
	'		* graph has an Euler Circuit (Eulerian)
	'		
	Public Shared Function isEulerian(ByVal graph_Renamed As Graph) As Integer
		Dim count As Integer = graph_Renamed.count
		Dim odd As Integer
		Dim inDegree() As Integer
		Dim outDegree() As Integer
		Dim adl As List(Of Edge)
		' Check if all non - zero degree nodes are connected
		If isConnected(graph_Renamed) = False Then
			Console.WriteLine("graph is not Eulerian")
			Return 0
		Else
			' Count odd degree
			odd = 0
			inDegree = New Integer(count - 1) {}
			outDegree = New Integer(count - 1) {}

			For i As Integer = 0 To count - 1
				adl = graph_Renamed.Adj(i)
				For Each adn As Edge In adl
					outDegree(i) += 1
					inDegree(adn.dest) += 1
				Next adn
			Next i
			For i As Integer = 0 To count - 1
				If (inDegree(i) + outDegree(i)) Mod 2 <> 0 Then
					odd += 1
				End If
			Next i
		End If

		If odd = 0 Then
			Console.WriteLine("graph is Eulerian")
			Return 2
		ElseIf odd = 2 Then
			Console.WriteLine("graph is Semi-Eulerian")
			Return 1
		Else
			Console.WriteLine("graph is not Eulerian")
			Return 0
		End If
	End Function

	Public Shared Sub main15()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(1, 0, 1)
		gph.addDirectedEdge(0, 2, 1)
		gph.addDirectedEdge(2, 1, 1)
		gph.addDirectedEdge(0, 3, 1)
		gph.addDirectedEdge(3, 4, 1)
		Console.WriteLine(isEulerian(gph))
	End Sub

	Public Shared Function isStronglyConnected2(ByVal graph_Renamed As Graph) As Boolean
		Dim count As Integer = graph_Renamed.count
		Dim visited(count - 1) As Boolean
		Dim gReversed As Graph
		Dim index As Integer
		' Find a vertex with non - zero degree
		Dim adl As List(Of Edge)
		For index = 0 To count - 1
			adl = graph_Renamed.Adj(index)
			If adl.Count > 0 Then
				Exit For
			End If
		Next index
		' DFS traversal of graph from a vertex with non - zero degree
		dfsUtil(graph_Renamed, index, visited)
		For i As Integer = 0 To count - 1
			adl = graph_Renamed.Adj(i)
			If visited(i) = False AndAlso adl.Count > 0 Then
				Return False
			End If
		Next i

		gReversed = transposeGraph(graph_Renamed)
		For i As Integer = 0 To count - 1
			visited(i) = False
		Next i
		dfsUtil(gReversed, index, visited)

		For i As Integer = 0 To count - 1
			adl = graph_Renamed.Adj(i)
			If visited(i) = False AndAlso adl.Count > 0 Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Function isEulerianCycle(ByVal graph_Renamed As Graph) As Boolean
		' Check if all non - zero degree count are connected
		Dim count As Integer = graph_Renamed.count
		Dim inDegree(count - 1) As Integer
		Dim outDegree(count - 1) As Integer
		If Not isStronglyConnected2(graph_Renamed) Then
			Return False
		End If

		' Check if in degree and out degree of every vertex is same
		For i As Integer = 0 To count - 1
			Dim adl As List(Of Edge) = graph_Renamed.Adj(i)
			For Each adn As Edge In adl
				outDegree(i) += 1
				inDegree(adn.dest) += 1
			Next adn
		Next i
		For i As Integer = 0 To count - 1
			If inDegree(i) <> outDegree(i) Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Sub main16()
		Dim gph As New Graph(5)
		gph.addDirectedEdge(0, 1, 1)
		gph.addDirectedEdge(1, 2, 1)
		gph.addDirectedEdge(2, 0, 1)
		gph.addDirectedEdge(0, 4, 1)
		gph.addDirectedEdge(4, 3, 1)
		gph.addDirectedEdge(3, 0, 1)
		Console.WriteLine(isEulerianCycle(gph))
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Main1()
		main3()
		main2()
		main3()
		main4()
		main5()
		main6()
		main7()
		main8()
		main9()
		main10()
		main11()
		main12()
		main13()
		main14()
		main15()
		main16()
	End Sub
End Class


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
		Next i
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

	Public Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
		' Create max heap for increasing order sorting.
		Dim hp As New PriorityQueue(Of Integer)(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.remove()
		Next i
	End Sub
End Class
