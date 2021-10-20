
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
		Next i
	End Sub

	Public Sub AddDirectedEdge(ByVal source As Integer, ByVal dest As Integer, ByVal cost As Integer)
		Dim edge As New Edge(source, dest, cost)
		Adj(source).Add(edge)
	End Sub

	Public Sub AddDirectedEdge(ByVal source As Integer, ByVal dest As Integer)
		AddDirectedEdge(source, dest, 1)
	End Sub

	Public Sub AddUndirectedEdge(ByVal source As Integer, ByVal dest As Integer, ByVal cost As Integer)
		AddDirectedEdge(source, dest, cost)
		AddDirectedEdge(dest, source, cost)
	End Sub

	Public Sub AddUndirectedEdge(ByVal source As Integer, ByVal dest As Integer)
		AddUndirectedEdge(source, dest, 1)
	End Sub

	Public Sub Print()
		For i As Integer = 0 To count - 1
			Dim ad As List(Of Edge) = Adj(i)
			Console.Write("Vertex " & i & " is connected to : ")
			For Each adn As Edge In ad
				Console.Write("(" & adn.dest & ", " & adn.cost & ") ")
			Next adn
			Console.WriteLine()
		Next i
	End Sub

	Public Shared Function DFSStack(ByVal gph As Graph, ByVal source As Integer, ByVal target As Integer) As Boolean
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

	Public Shared Function DFS(ByVal gph As Graph, ByVal source As Integer, ByVal target As Integer) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		DFSUtil(gph, source, visited)
		Return visited(target)
	End Function

	Private Shared Sub DFSUtil(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Boolean)
		visited(index) = True
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				DFSUtil(gph, adn.dest, visited)
			End If
		Next adn
	End Sub

	Public Shared Sub DFSUtil2(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Boolean, ByVal stk As Stack(Of Integer))
		visited(index) = True
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				DFSUtil2(gph, adn.dest, visited, stk)
			End If
		Next adn
		stk.Push(index)
	End Sub

	Public Shared Function BFS(ByVal gph As Graph, ByVal source As Integer, ByVal target As Integer) As Boolean
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

	' Testing Code
	Public Shared Sub Main1()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(0, 1, 3)
		gph.AddDirectedEdge(0, 4, 2)
		gph.AddDirectedEdge(1, 2, 1)
		gph.AddDirectedEdge(2, 3, 1)
		gph.AddDirectedEdge(4, 1, -2)
		gph.AddDirectedEdge(4, 3, 1)
		gph.Print()

		Console.WriteLine(Graph.DFS(gph, 0, 2))
		Console.WriteLine(Graph.BFS(gph, 0, 2))
		Console.WriteLine(Graph.DFSStack(gph, 0, 2))
	End Sub

	'	
	'	Vertex 0 is connected to : (1, 3) (4, 2) 
	'	Vertex 1 is connected to : (2, 1) 
	'	Vertex 2 is connected to : (3, 1) 
	'	Vertex 3 is connected to : 
	'	Vertex 4 is connected to : (1, -2) (3, 1) 
	'True
	'True
	'True
	'	

	Public Shared Sub TopologicalSort(ByVal gph As Graph)
		Dim stk As New Stack(Of Integer)()
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				DFSUtil2(gph, i, visited, stk)
			End If
		Next i
		Console.Write("Topological Sort::")
		Do While stk.Count = 0 <> True
			Console.Write(" " & stk.Pop())
		Loop
	End Sub

	' Testing Code
	Public Shared Sub Main2()
		Dim gph As New Graph(9)
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
		TopologicalSort(gph)
	End Sub

	'	
	'	    TopologicalSort ::  1 4 6 3 5 7 8 0 2
	'	

	Public Shared Function PathExist(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		DFSUtil(gph, source, visited)
		Return visited(dest)
	End Function

	Public Shared Function CountAllPathDFS(ByVal gph As Graph, ByVal visited() As Boolean, ByVal source As Integer, ByVal dest As Integer) As Integer
		If source = dest Then
			Return 1
		End If
		Dim count As Integer = 0
		visited(source) = True
		Dim adl As List(Of Edge) = gph.Adj(source)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				count += CountAllPathDFS(gph, visited, adn.dest, dest)
			End If
		Next adn
		visited(source) = False
		Return count
	End Function

	Public Shared Function CountAllPath(ByVal gph As Graph, ByVal src As Integer, ByVal dest As Integer) As Integer
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Return CountAllPathDFS(gph, visited, src, dest)
	End Function

	Public Shared Sub PrintAllPathDFS(ByVal gph As Graph, ByVal visited() As Boolean, ByVal source As Integer, ByVal dest As Integer, ByVal path As Stack(Of Integer))
		path.Push(source)
		If source = dest Then
			For Each item As Integer In path
				Console.Write(item & " ")
			Next item
			Console.WriteLine()
			path.Pop()
			Return
		End If
		visited(source) = True
		Dim adl As List(Of Edge) = gph.Adj(source)
		For Each adn As Edge In adl
			If visited(adn.dest) = False Then
				PrintAllPathDFS(gph, visited, adn.dest, dest, path)
			End If
		Next adn
		visited(source) = False
		path.Pop()
	End Sub

	Public Shared Sub PrintAllPath(ByVal gph As Graph, ByVal src As Integer, ByVal dest As Integer)
		Dim visited(gph.count - 1) As Boolean
		Dim path As New Stack(Of Integer)()
		PrintAllPathDFS(gph, visited, src, dest, path)
	End Sub

	' Testing Code
	Public Shared Sub Main3()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(0, 2)
		gph.AddDirectedEdge(2, 3)
		gph.AddDirectedEdge(1, 3)
		gph.AddDirectedEdge(3, 4)
		gph.AddDirectedEdge(1, 4)
		gph.Print()
		Console.WriteLine("PathExist :: " & PathExist(gph, 0, 4))

		Console.WriteLine()
		Console.WriteLine(CountAllPath(gph, 0, 4))
		PrintAllPath(gph, 0, 4)
	End Sub

	'	
	'	Vertex 0 is connected to : (1, 1) (2, 1) 
	'	Vertex 1 is connected to : (3, 1) (4, 1) 
	'	Vertex 2 is connected to : (3, 1) 
	'	Vertex 3 is connected to : (4, 1) 
	'	Vertex 4 is connected to : 
	'	PathExist :: True
	'
	'3
	'4 3 1 0
	'4 1 0
	'4 3 2 0 
	'	

	Public Shared Function RootVertex(ByVal gph As Graph) As Integer
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim retVal As Integer = -1
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				DFSUtil(gph, i, visited)
				retVal = i
			End If
		Next i
		Console.Write("Root vertex is :: " & retVal)
		Return retVal
	End Function

	' Testing Code
	Public Shared Sub Main4()
		Dim gph As New Graph(7)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(0, 2)
		gph.AddDirectedEdge(1, 3)
		gph.AddDirectedEdge(4, 1)
		gph.AddDirectedEdge(6, 4)
		gph.AddDirectedEdge(5, 6)
		gph.AddDirectedEdge(5, 2)
		gph.AddDirectedEdge(6, 0)
		gph.Print()
		RootVertex(gph)
	End Sub

	'	
	'	Vertex 0 is connected to : (1, 1) (2, 1) 
	'	Vertex 1 is connected to : (3, 1) 
	'	Vertex 2 is connected to : 
	'	Vertex 3 is connected to : 
	'	Vertex 4 is connected to : (1, 1) 
	'	Vertex 5 is connected to : (6, 1) (2, 1) 
	'	Vertex 6 is connected to : (4, 1) (0, 1) 
	'	Root vertex is :: 5
	'	

	'	
	'	Given a directed graph, Find transitive closure matrix or reach ability
	'	matrix vertex v is reachable form vertex u if their is a path from u to v.
	'	

	Public Shared Sub TransitiveClosureUtil(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer, ByVal tc(,) As Integer)
		tc(source, dest) = 1
		Dim adl As List(Of Edge) = gph.Adj(dest)
		For Each adn As Edge In adl
			If tc(source, adn.dest) = 0 Then
				TransitiveClosureUtil(gph, source, adn.dest, tc)
			End If
		Next adn
	End Sub

	Public Shared Function TransitiveClosure(ByVal gph As Graph) As Integer(,)
		Dim count As Integer = gph.count
		Dim tc(count - 1, count - 1) As Integer
		For i As Integer = 0 To count - 1
			TransitiveClosureUtil(gph, i, i, tc)
		Next i
		Return tc
	End Function

	' Testing Code
	Public Shared Sub Main5()
		Dim gph As New Graph(4)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(0, 2)
		gph.AddDirectedEdge(1, 2)
		gph.AddDirectedEdge(2, 0)
		gph.AddDirectedEdge(2, 3)
		gph.AddDirectedEdge(3, 3)
		Dim tc(,) As Integer = TransitiveClosure(gph)
		For i As Integer = 0 To 3
			For j As Integer = 0 To 3
				Console.Write(tc(i, j) & " ")
			Next j
			Console.WriteLine()
		Next i
	End Sub

	'	
	'	1 1 1 1 
	'	1 1 1 1 
	'	1 1 1 1 
	'	0 0 0 1 
	'	

	Public Shared Sub BFSLevelNode(ByVal gph As Graph, ByVal source As Integer)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim level(count - 1) As Integer
		visited(source) = True
		Dim que As New Queue(Of Integer)()
		que.Enqueue(source)
		level(source) = 0
		Console.WriteLine("Node  - Level")

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

	Public Shared Function BFSDistance(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer) As Integer
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
					Return depth + 1
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

	' Testing Code
	Public Shared Sub Main6()
		Dim gph As New Graph(7)
		gph.AddUndirectedEdge(0, 1)
		gph.AddUndirectedEdge(0, 2)
		gph.AddUndirectedEdge(0, 4)
		gph.AddUndirectedEdge(1, 2)
		gph.AddUndirectedEdge(2, 5)
		gph.AddUndirectedEdge(3, 4)
		gph.AddUndirectedEdge(4, 5)
		gph.AddUndirectedEdge(4, 6)
		gph.Print()
		BFSLevelNode(gph, 1)
		Console.WriteLine(BFSDistance(gph, 1, 6))
	End Sub
	'	
	'	Vertex 0 is connected to : (1, 1) (2, 1) (4, 1) 
	'	Vertex 1 is connected to : (0, 1) (2, 1) 
	'	Vertex 2 is connected to : (0, 1) (1, 1) (5, 1) 
	'	Vertex 3 is connected to : (4, 1) 
	'	Vertex 4 is connected to : (0, 1) (3, 1) (5, 1) (6, 1) 
	'	Vertex 5 is connected to : (2, 1) (4, 1) 
	'	Vertex 6 is connected to : (4, 1) 
	'
	'	Node  - Level
	'	1 - 0
	'	0 - 1
	'	2 - 1
	'	4 - 2
	'	5 - 2
	'	3 - 3
	'	6 - 3
	'	3
	'	

	Public Shared Function IsCyclePresentUndirectedDFS(ByVal gph As Graph, ByVal index As Integer, ByVal parentIndex As Integer, ByVal visited() As Boolean) As Boolean
		visited(index) = True
		Dim dest As Integer
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			dest = adn.dest
			If visited(dest) = False Then
				If IsCyclePresentUndirectedDFS(gph, dest, index, visited) Then
					Return True
				End If
			ElseIf parentIndex <> dest Then
				Return True
			End If
		Next adn
		Return False
	End Function

	Public Shared Function IsCyclePresentUndirected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		For i As Integer = 0 To count - 1
			If visited(i) = False AndAlso IsCyclePresentUndirectedDFS(gph, i, -1, visited) Then
				Return True
			End If
		Next i
		Return False
	End Function

	Public Shared Function Find(ByVal parent() As Integer, ByVal index As Integer) As Integer
		Dim p As Integer = parent(index)
		Do While p <> -1
			index = p
			p = parent(index)
		Loop
		Return index
	End Function

	Public Shared Sub union(ByVal parent() As Integer, ByVal x As Integer, ByVal y As Integer)
		parent(y) = x
	End Sub

	Public Shared Function IsCyclePresentUndirected2(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim parent(count - 1) As Integer
		Array.Fill(parent, -1)
		Dim edge As New List(Of Edge)()
		Dim flags(count - 1, count - 1) As Boolean
		For i As Integer = 0 To count - 1
			Dim ad As List(Of Edge) = gph.Adj(i)
			For Each adn As Edge In ad
				' Using flags[, ] array, if considered edge x to y, 
				' then ignore edge y to x.
				If flags(adn.dest, adn.src) = False Then
					edge.Add(adn)
					flags(adn.src, adn.dest) = True
				End If
			Next adn
		Next i

		For Each e As Edge In edge
			Dim x As Integer = Find(parent, e.src)
			Dim y As Integer = Find(parent, e.dest)
			If x = y Then
				Return True
			End If
			union(parent, x, y)
		Next e
		Return False
	End Function

	Public Shared Function IsCyclePresentUndirected3(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		'Different subsets are created.
		Dim sets(count - 1) As Sets
		For i As Integer = 0 To count - 1
			sets(i) = New Sets(i, 0)
		Next i

		Dim edge As New List(Of Edge)()
		Dim flags(count - 1, count - 1) As Boolean
		For i As Integer = 0 To count - 1
			Dim ad As List(Of Edge) = gph.Adj(i)
			For Each adn As Edge In ad
				' Using flags[, ] array, if considered edge x to y, 
				' then ignore edge y to x.
				If flags(adn.dest, adn.src) = False Then
					edge.Add(adn)
					flags(adn.src, adn.dest) = True
				End If
			Next adn
		Next i

		For Each e As Edge In edge
			Dim x As Integer = Find(sets, e.src)
			Dim y As Integer = Find(sets, e.dest)
			If x = y Then
				Return True
			End If
			union(sets, x, y)
		Next e
		Return False
	End Function

	' Testing Code
	Public Shared Sub Main7()
		Dim gph As New Graph(6)
		gph.AddUndirectedEdge(0, 1)
		gph.AddUndirectedEdge(1, 2)
		gph.AddUndirectedEdge(3, 4)
		gph.AddUndirectedEdge(4, 2)
		gph.AddUndirectedEdge(2, 5)
		gph.AddUndirectedEdge(4, 1)
		Console.WriteLine(IsCyclePresentUndirected(gph))
		Console.WriteLine(IsCyclePresentUndirected2(gph))
		Console.WriteLine(IsCyclePresentUndirected3(gph))
	End Sub

	'	
	'True
	'True
	'True
	'	

	'	
	' Given a directed graph Find if there is a cycle in it.
	'	
	Public Shared Function IsCyclePresentDFS(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Boolean, ByVal marked() As Integer) As Boolean
		visited(index) = True
		marked(index) = 1
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			Dim dest As Integer = adn.dest
			If marked(dest) = 1 Then
				Return True
			End If

			If visited(dest) = False Then
				If IsCyclePresentDFS(gph, dest, visited, marked) Then
					Return True
				End If
			End If
		Next adn
		marked(index) = 0
		Return False
	End Function

	Public Shared Function IsCyclePresent(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim marked(count - 1) As Integer
		For index As Integer = 0 To count - 1
			If Not visited(index) Then
				If IsCyclePresentDFS(gph, index, visited, marked) Then
					Return True
				End If
			End If
		Next index
		Return False
	End Function

	Public Shared Function IsCyclePresentDFSColour(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Integer) As Boolean
		visited(index) = 1 ' 1 = grey
		Dim dest As Integer
		Dim adl As List(Of Edge) = gph.Adj(index)
		For Each adn As Edge In adl
			dest = adn.dest
			If visited(dest) = 1 Then ' "Grey":
				Return True
			End If

			If visited(dest) = 0 Then ' "White":
				If IsCyclePresentDFSColour(gph, dest, visited) Then
					Return True
				End If
			End If
		Next adn
		visited(index) = 2 ' "Black"
		Return False
	End Function

	Public Shared Function IsCyclePresentColour(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			If visited(i) = 0 Then ' "White"
				If IsCyclePresentDFSColour(gph, i, visited) Then
					Return True
				End If
			End If
		Next i
		Return False
	End Function

	' Testing Code
	Public Shared Sub Main8()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(0, 2)
		gph.AddDirectedEdge(2, 3)
		gph.AddDirectedEdge(1, 3)
		gph.AddDirectedEdge(3, 4)
		'gph.AddDirectedEdge(4, 1)
		Console.WriteLine(IsCyclePresent(gph))
		Console.WriteLine(IsCyclePresentColour(gph))
	End Sub

	'	
	' False
	' False
	'	

	Public Shared Function TransposeGraph(ByVal gph As Graph) As Graph
		Dim count As Integer = gph.count
		Dim g As New Graph(count)
		For i As Integer = 0 To count - 1
			Dim adl As List(Of Edge) = gph.Adj(i)
			For Each adn As Edge In adl
				Dim dest As Integer = adn.dest
				g.AddDirectedEdge(dest, i)
			Next adn
		Next i
		Return g
	End Function


	Public Shared Function IsConnectedUndirected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		DFSUtil(gph, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				Return False
			End If
		Next i
		Return True
	End Function

	'		
	' Kosaraju Algorithm
	' 
	' Kosaraju's Algorithm to Find strongly connected directed graph based on DFS :
	' 1) Create a visited array of size V, and Initialize all count in visited array as 0. 
	' 2) Choose any vertex and perform a DFS traversal of graph. For all visited count mark them visited as 1. 
	' 3) If DFS traversal does not mark all count as 1, then return 0. 
	' 4) Find transpose or reverse of graph 
	' 5) Repeat step 1, 2 and 3 for the reversed graph. 
	' 6) If DFS traversal mark all the count as 1, then return 1.
	'	

	Public Shared Function IsStronglyConnected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		DFSUtil(gph, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				Return False
			End If
		Next i
		Dim gReversed As Graph = TransposeGraph(gph)
		For i As Integer = 0 To count - 1
			visited(i) = False
		Next i
		DFSUtil(gReversed, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				Return False
			End If
		Next i
		Return True
	End Function

	' Testing Code
	Public Shared Sub Main9()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(1, 2)
		gph.AddDirectedEdge(2, 3)
		gph.AddDirectedEdge(3, 0)
		gph.AddDirectedEdge(2, 4)
		gph.AddDirectedEdge(4, 2)
		Console.WriteLine("Is Strongly Connected:: " & IsStronglyConnected(gph))
	End Sub

	'	
	'	Is Strongly Connected:: True
	'	

	Public Shared Sub stronglyConnectedComponent(ByVal gph As Graph)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		Dim stk As New Stack(Of Integer)()
		For i As Integer = 0 To count - 1
			If visited(i) = False Then
				DFSUtil2(gph, i, visited, stk)
			End If
		Next i

		Dim gReversed As Graph = TransposeGraph(gph)
		Array.Fill(visited, False)

		Dim stk2 As New Stack(Of Integer)()
		Do While stk.Count > 0
			Dim index As Integer = stk.Pop()
			If visited(index) = False Then
				stk2.Clear()
				DFSUtil2(gReversed, index, visited, stk2)
				For Each ele In stk2
					Console.Write(ele & " ")
				Next ele
				Console.WriteLine()
			End If
		Loop
	End Sub

	' Testing Code
	Public Shared Sub Main10()
		Dim gph As New Graph(7)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(1, 2)
		gph.AddDirectedEdge(2, 0)
		gph.AddDirectedEdge(2, 3)
		gph.AddDirectedEdge(3, 4)
		gph.AddDirectedEdge(4, 5)
		gph.AddDirectedEdge(5, 3)
		gph.AddDirectedEdge(5, 6)
		stronglyConnectedComponent(gph)

		Dim gReversed As Graph = TransposeGraph(gph)
		gReversed.Print()
		Console.WriteLine()
	End Sub

	'	
	'0 2 1 
	'3 5 4 
	'6 
	'	

	Public Shared Sub primsMST(ByVal gph As Graph)
		Dim count As Integer = gph.count
		Dim previous(count - 1) As Integer
		Array.Fill(previous, -1)

		Dim dist(count - 1) As Integer
		Array.Fill(dist, 9999) ' infinite
		Dim visited(count - 1) As Boolean
		Dim source As Integer = 1

		dist(source) = 0
		previous(source) = -1
		Dim pq As New PriorityQueue(Of Edge)()
		Dim node As New Edge(source, source, 0)
		pq.Enqueue(node)

		Do While pq.IsEmpty() <> True
			node = pq.Peek()
			pq.Dequeue()
			visited(source) = True
			source = node.dest
			Dim adl As List(Of Edge) = gph.Adj(source)
			For Each adn As Edge In adl
				Dim dest As Integer = adn.dest
				Dim alt As Integer = adn.cost
				If dist(dest) > alt AndAlso visited(dest) = False Then
					dist(dest) = alt
					previous(dest) = source
					node = New Edge(source, dest, alt)
					pq.Enqueue(node)
				End If
			Next adn
		Loop
		' Printing result.
		Dim sum As Integer = 0
		Dim isMst As Boolean = True
		For i As Integer = 0 To count - 1
			If dist(i) = 99999 Then
				Console.WriteLine("Node id " & i & "  prev " & previous(i) & " distance : Unreachable")
				isMst = False
			Else
				Console.WriteLine("Node id " & i & "  prev " & previous(i) & " distance : " & dist(i))
				sum += dist(i)
			End If
		Next i

		If isMst Then
			Console.WriteLine("Total MST cost: " & sum)
		Else
			Console.WriteLine("Not a mst")
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

	Public Shared Function Find(ByVal sets() As Sets, ByVal index As Integer) As Integer
		Dim p As Integer = sets(index).parent
		Do While p <> index
			index = p
			p = sets(index).parent
		Loop
		Return index
	End Function

	' consider x and y are roots of sets.
	Public Shared Sub union(ByVal sets() As Sets, ByVal x As Integer, ByVal y As Integer)
		If sets(x).rank < sets(y).rank Then
			sets(x).parent = y
		ElseIf sets(y).rank < sets(x).rank Then
			sets(y).parent = x
		Else
			sets(x).parent = y
			sets(y).rank += 1
		End If
	End Sub
	Public Shared Sub kruskalMST(ByVal gph As Graph)
		Dim count As Integer = gph.count

		'Different subsets are created.
		Dim sets(count - 1) As Sets
		For i As Integer = 0 To count - 1
			sets(i) = New Sets(i, 0)
		Next i

		' Edges are added to array and sorted.
		Dim E As Integer = 0
		Dim edge(99) As Edge
		For i As Integer = 0 To count - 1
			Dim ad As List(Of Edge) = gph.Adj(i)
			For Each adn As Edge In ad

				edge(E) = adn
				E += 1
			Next adn
		Next i
		Array.Sort(edge, 0, E - 1)

		Dim sum As Integer = 0
		Dim output As New List(Of Edge)()
		For i As Integer = 0 To E - 1
			Dim x As Integer = Find(sets, edge(i).src)
			Dim y As Integer = Find(sets, edge(i).dest)
			If x <> y Then
				Console.Write("(" & edge(i).src & ", " & edge(i).dest & ", " & edge(i).cost & ") ")
				sum += edge(i).cost
				output.Add(edge(i))
				union(sets, x, y)
			End If
		Next i
		Console.WriteLine(vbLf & "Total MST cost: " & sum)
	End Sub

	' Testing Code
	Public Shared Sub Main11()
		Dim gph As New Graph(9)
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
		gph.Print()
		Console.WriteLine("primsMST")
		primsMST(gph)
		Console.WriteLine("kruskalMST")
		kruskalMST(gph)
		Console.WriteLine("Dijkstra")
		Dijkstra(gph, 0)
		Console.WriteLine()
	End Sub

	'	
	'	Vertex 0 is connected to : (1, 4) (7, 8) 
	'	Vertex 1 is connected to : (0, 4) (2, 8) (7, 11) 
	'	Vertex 2 is connected to : (1, 8) (3, 7) (8, 2) (5, 4) 
	'	Vertex 3 is connected to : (2, 7) (4, 9) (5, 14) 
	'	Vertex 4 is connected to : (3, 9) (5, 10) 
	'	Vertex 5 is connected to : (2, 4) (3, 14) (4, 10) (6, 2) 
	'	Vertex 6 is connected to : (5, 2) (7, 1) (8, 6) 
	'	Vertex 7 is connected to : (0, 8) (1, 11) (6, 1) (8, 7) 
	'	Vertex 8 is connected to : (2, 2) (6, 6) (7, 7) 
	'
	'	node id 0  prev 1 distance : 4
	'	node id 1  prev -1 distance : 0
	'	node id 2  prev 1 distance : 8
	'	node id 3  prev 2 distance : 7
	'	node id 4  prev 3 distance : 9
	'	node id 5  prev 2 distance : 4
	'	node id 6  prev 5 distance : 2
	'	node id 7  prev 6 distance : 1
	'	node id 8  prev 2 distance : 2
	'
	'	node id 0  prev -1 distance : 0
	'	node id 1  prev 0 distance : 4
	'	node id 2  prev 1 distance : 12
	'	node id 3  prev 2 distance : 19
	'	node id 4  prev 5 distance : 21
	'	node id 5  prev 6 distance : 11
	'	node id 6  prev 7 distance : 9
	'	node id 7  prev 0 distance : 8
	'	node id 8  prev 2 distance : 14
	'	

	' Unweighed graph
	Public Shared Sub shortestPath(ByVal gph As Graph, ByVal source As Integer)
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

	' Testing Code
	Public Shared Sub Main12()
		Dim gph As New Graph(9)
		gph.AddUndirectedEdge(0, 2, 1)
		gph.AddUndirectedEdge(1, 2, 5)
		gph.AddUndirectedEdge(1, 3, 7)
		gph.AddUndirectedEdge(1, 4, 9)
		gph.AddUndirectedEdge(3, 2, 2)
		gph.AddUndirectedEdge(3, 5, 4)
		gph.AddUndirectedEdge(4, 5, 6)
		gph.AddUndirectedEdge(4, 6, 3)
		gph.AddUndirectedEdge(5, 7, 1)
		gph.AddUndirectedEdge(6, 7, 7)
		gph.AddUndirectedEdge(7, 8, 17)
		BellmanFordShortestPath(gph, 1)
		Console.WriteLine()
		primsMST(gph)
		Console.WriteLine()
		kruskalMST(gph)
		Console.WriteLine()
	End Sub

	'	
	'	2 to 0 weight 6
	'	-1 to 1 weight 0
	'	1 to 2 weight 5
	'	1 to 3 weight 7
	'	1 to 4 weight 9
	'	3 to 5 weight 11
	'	4 to 6 weight 12
	'	5 to 7 weight 12
	'	7 to 8 weight 29
	'
	'
	'ode id 0  prev 2 distance : 1
	'Node id 1  prev -1 distance : 0
	'Node id 2  prev 1 distance : 5
	'Node id 3  prev 2 distance : 2
	'Node id 4  prev 5 distance : 6
	'Node id 5  prev 3 distance : 4
	'Node id 6  prev 4 distance : 3
	'Node id 7  prev 5 distance : 1
	'Node id 8  prev 7 distance : 17
	'Total MST cost: 39
	'
	'
	'(0, 2, 1) (5, 7, 1) (2, 3, 2) (6, 4, 3) (3, 5, 4) (1, 2, 5) (4, 5, 6) (7, 8, 17) 
	'Total MST cost: 39	
	'


	Public Shared Sub Dijkstra(ByVal gph As Graph, ByVal source As Integer)
		Dim previous(gph.count - 1) As Integer
		Array.Fill(previous, -1)
		Dim dist(gph.count - 1) As Integer
		Array.Fill(dist, Integer.MaxValue) ' infinite
		Dim visited(gph.count - 1) As Boolean

		dist(source) = 0
		previous(source) = -1

		Dim pq As New PriorityQueue(Of Edge)()
		Dim node As New Edge(source, source, 0)
		pq.Enqueue(node)

		Do While pq.IsEmpty() <> True
			node = pq.Peek()
			pq.Dequeue()
			source = node.dest
			visited(source) = True
			Dim adl As List(Of Edge) = gph.Adj(source)
			For Each adn As Edge In adl
				Dim dest As Integer = adn.dest
				Dim alt As Integer = adn.cost + dist(source)
				If dist(dest) > alt AndAlso visited(dest) = False Then

					dist(dest) = alt
					previous(dest) = source
					node = New Edge(source, dest, alt)
					pq.Enqueue(node)
				End If
			Next adn
		Loop

		Dim count As Integer = gph.count
		For i As Integer = 0 To count - 1
			If dist(i) = Integer.MaxValue Then
				Console.WriteLine("node id " & i & "  prev " & previous(i) & " distance : Unreachable")
			Else
				Console.WriteLine("node id " & i & "  prev " & previous(i) & " distance : " & dist(i))

			End If
		Next i
	End Sub

	Public Shared Sub BellmanFordShortestPath(ByVal gph As Graph, ByVal source As Integer)
		Dim count As Integer = gph.count
		Dim distance(count - 1) As Integer
		Dim path(count - 1) As Integer

		Dim i As Integer = 0
		For i = 0 To count - 1
			distance(i) = 99999 ' infinite
			path(i) = -1
		Next i
		distance(source) = 0
		' Outer loop will run (V-1) number of times.
		' Inner for loop and while loop runs combined will
		' run for Edges number of times.
		' Which make the total complexity as O(V*E)

		i = 0
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

		For i = 0 To count - 1
			Console.WriteLine(path(i) & " to " & i & " weight " & distance(i))
		Next i
	End Sub

	' Testing Code
	Public Shared Sub Main13()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(0, 1, 3)
		gph.AddDirectedEdge(0, 4, 2)
		gph.AddDirectedEdge(1, 2, 1)
		gph.AddDirectedEdge(2, 3, 1)
		gph.AddDirectedEdge(4, 1, -2)
		gph.AddDirectedEdge(4, 3, 1)
		gph.Print()
		Console.WriteLine()
		BellmanFordShortestPath(gph, 0)
		Console.WriteLine()
	End Sub

	'	
	'	Vertex 0 is connected to : (1, 3) (4, 2) 
	'	Vertex 1 is connected to : (2, 1) 
	'	Vertex 2 is connected to : (3, 1) 
	'	Vertex 3 is connected to : 
	'	Vertex 4 is connected to : (1, -2) (3, 1) 
	'
	'	-1 to 0 weight 0
	'	4 to 1 weight 0
	'	1 to 2 weight 1
	'	2 to 3 weight 2
	'	0 to 4 weight 2
	'	
	Public Shared Function HeightTreeParentArr(ByVal arr() As Integer) As Integer
		Dim count As Integer = arr.Length
		Dim heightArr(count - 1) As Integer
		Dim gph As New Graph(count)
		Dim source As Integer = 0
		For i As Integer = 0 To count - 1
			If arr(i) <> -1 Then
				gph.AddDirectedEdge(arr(i), i)
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

	Public Shared Function GetHeight(ByVal arr() As Integer, ByVal height() As Integer, ByVal index As Integer) As Integer
		If arr(index) = -1 Then
			Return 0
		Else
			Return GetHeight(arr, height, arr(index)) + 1
		End If
	End Function

	Public Shared Function HeightTreeParentArr2(ByVal arr() As Integer) As Integer
		Dim count As Integer = arr.Length
		Dim height(count - 1) As Integer
		Dim maxHeight As Integer = -1
		For i As Integer = 0 To count - 1
			height(i) = GetHeight(arr, height, i)
			maxHeight = Math.Max(maxHeight, height(i))
		Next i
		Return maxHeight
	End Function

	' Testing Code
	Public Shared Sub Main14()
		Dim parentArray() As Integer = {-1, 0, 1, 2, 3}
		Console.WriteLine(HeightTreeParentArr(parentArray))
		Console.WriteLine(HeightTreeParentArr2(parentArray))
	End Sub

	'	
	'	4
	'	4
	'	

	Public Shared Function BestFirstSearchPQ(ByVal gph As Graph, ByVal source As Integer, ByVal dest As Integer) As Integer
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim visited(gph.count - 1) As Boolean
		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = Integer.MaxValue ' infinite
		Next i
		Dim pq As New PriorityQueue(Of Edge)()
		dist(source) = 0
		previous(source) = -1
		Dim node As New Edge(source, source, 0)
		pq.Enqueue(node)

		Do While pq.IsEmpty() <> True
			node = pq.Peek()
			pq.Dequeue()
			source = node.dest
			If source = dest Then
				Return node.cost
			End If
			visited(source) = True

			Dim adl As List(Of Edge) = gph.Adj(source)
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
			Next adn
		Loop
		Return -1
	End Function


	Public Shared Function IsConnected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean

		' Find a vertex with non - zero degree
		' DFS traversal of graph from a vertex with non - zero degree
		Dim adl As List(Of Edge)
		For i As Integer = 0 To count - 1
			adl = gph.Adj(i)
			If adl.Count > 0 Then
				DFSUtil(gph, i, visited)
				Exit For
			End If
		Next i
		' Check if all non - zero degree count are visited
		For i As Integer = 0 To count - 1
			adl = gph.Adj(i)
			If adl.Count > 0 Then
				If visited(i) = False Then
					Return False
				End If
			End If
		Next i
		Return True
	End Function

	'	
	' The function returns one of the following values Return 0 if graph is not
	' Eulerian Return 1 if graph has an Euler path (Semi-Eulerian) Return 2 if
	' graph has an Euler Circuit (Eulerian)
	'	
	Public Shared Function IsEulerian(ByVal gph As Graph) As Integer
		Dim count As Integer = gph.count
		Dim odd As Integer
		Dim inDegree() As Integer
		Dim outDegree() As Integer
		Dim adl As List(Of Edge)
		' Check if all non - zero degree nodes are connected
		If IsConnected(gph) = False Then
			Console.WriteLine("graph is not Eulerian")
			Return 0
		Else
			' Count odd degree
			odd = 0
			inDegree = New Integer(count - 1) {}
			outDegree = New Integer(count - 1) {}

			For i As Integer = 0 To count - 1
				adl = gph.Adj(i)
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

	' Testing Code
	Public Shared Sub Main15()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(1, 0)
		gph.AddDirectedEdge(0, 2)
		gph.AddDirectedEdge(2, 1)
		gph.AddDirectedEdge(0, 3)
		gph.AddDirectedEdge(3, 4)
		Console.WriteLine(IsEulerian(gph))
	End Sub

	'	
	'	graph is Semi-Eulerian
	'	1
	'	

	Public Shared Function IsStronglyConnected2(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Boolean
		Dim gReversed As Graph
		Dim index As Integer
		' Find a vertex with non - zero degree
		Dim adl As List(Of Edge)
		For index = 0 To count - 1
			adl = gph.Adj(index)
			If adl.Count > 0 Then
				Exit For
			End If
		Next index
		' DFS traversal of graph from a vertex with non - zero degree
		DFSUtil(gph, index, visited)
		For i As Integer = 0 To count - 1
			adl = gph.Adj(i)
			If visited(i) = False AndAlso adl.Count > 0 Then
				Return False
			End If
		Next i

		gReversed = TransposeGraph(gph)
		For i As Integer = 0 To count - 1
			visited(i) = False
		Next i
		DFSUtil(gReversed, index, visited)

		For i As Integer = 0 To count - 1
			adl = gph.Adj(i)
			If visited(i) = False AndAlso adl.Count > 0 Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Function IsEulerianCycle(ByVal gph As Graph) As Boolean
		' Check if all non - zero degree count are connected
		Dim count As Integer = gph.count
		Dim inDegree(count - 1) As Integer
		Dim outDegree(count - 1) As Integer
		If Not IsStronglyConnected2(gph) Then
			Return False
		End If

		' Check if in degree and out degree of every vertex is same
		For i As Integer = 0 To count - 1
			Dim adl As List(Of Edge) = gph.Adj(i)
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

	' Testing Code
	Public Shared Sub Main16()
		Dim gph As New Graph(5)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(1, 2)
		gph.AddDirectedEdge(2, 0)
		gph.AddDirectedEdge(0, 4)
		gph.AddDirectedEdge(4, 3)
		gph.AddDirectedEdge(3, 0)
		Console.WriteLine(IsEulerianCycle(gph))
	End Sub

	'	
	'	True
	'	

	' Testing Code
	Public Shared Sub Main17()
		Dim gph As New Graph(7)
		gph.AddDirectedEdge(0, 1)
		gph.AddDirectedEdge(1, 2)
		gph.AddDirectedEdge(2, 0)
		gph.AddDirectedEdge(2, 3)
		gph.AddDirectedEdge(3, 4)
		gph.AddDirectedEdge(4, 5)
		gph.AddDirectedEdge(5, 3)
		gph.AddDirectedEdge(5, 6)

		Dim gReversed As Graph = TransposeGraph(gph)
		gReversed.Print()
		Console.WriteLine()
	End Sub

	'	
	'	Vertex 0 is connected to : (2, 1) 
	'	Vertex 1 is connected to : (0, 1) 
	'	Vertex 2 is connected to : (1, 1) 
	'	Vertex 3 is connected to : (2, 1) (5, 1) 
	'	Vertex 4 is connected to : (3, 1) 
	'	Vertex 5 is connected to : (4, 1) 
	'	Vertex 6 is connected to : (5, 1) 
	'	

	' Testing Code
	Public Shared Sub Main18()
		Dim gph As New Graph(9)
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
		shortestPath(gph, 0)
		Console.WriteLine()
	End Sub

	'	
	'	0 to 0 weight 0
	'	0 to 1 weight 1
	'	1 to 2 weight 2
	'	2 to 3 weight 3
	'	3 to 4 weight 4
	'	2 to 5 weight 3
	'	7 to 6 weight 2
	'	0 to 7 weight 1
	'	7 to 8 weight 2
	'	


	Friend Shared Sub FloydWarshall(ByVal gph As Graph)
		Dim V As Integer = gph.count
		Dim dist(V - 1, V - 1) As Integer
		Dim path(V - 1, V - 1) As Integer

		For i As Integer = 0 To V - 1
			For j As Integer = 0 To V - 1
				dist(i, j) = 99999
				If i = j Then
					path(i, j) = 0
				Else
					path(i, j) = -1
				End If
			Next j
		Next i

		For i As Integer = 0 To V - 1
			Dim adl As List(Of Edge) = gph.Adj(i)
			For Each adn As Edge In adl
				path(adn.src, adn.dest) = adn.src
				dist(adn.src, adn.dest) = adn.cost
			Next adn
		Next i

		' Pick intermediate vertices.
		For k As Integer = 0 To V - 1
			' Pick source vertices one by one.
			For i As Integer = 0 To V - 1
				' Pick destination vertices.
				For j As Integer = 0 To V - 1
					' If we have a shorter path from i to j via k.
					' then update dist[i, j] and  and path[i, j]
					If dist(i, k) + dist(k, j) < dist(i, j) Then
						dist(i, j) = dist(i, k) + dist(k, j)
						path(i, j) = path(k, j)
					End If
				Next j
				' dist[i, i] is 0 in the start.
				' If there is a better path from i to i and is better path then we have -ve cycle.                //
				If dist(i, i) < 0 Then
					Console.WriteLine("Negative-weight cycle found.")
					Return
				End If
			Next i
		Next k
		PrintSolution(dist, path, V)
	End Sub

	Private Shared Sub PrintSolution(ByVal cost(,) As Integer, ByVal path(,) As Integer, ByVal V As Integer)
		For i As Integer = 0 To V - 1
			For j As Integer = 0 To V - 1
				If i <> j AndAlso path(i, j) <> -1 Then
					Console.Write("Shortest Path from {0:D} —> {1:D} ", i, j)
					Console.Write("Cost:" & cost(i, j) & " Path:")
					PrintPath(path, i, j)
					Console.WriteLine()
				End If
			Next j
		Next i
	End Sub

	Private Shared Sub PrintPath(ByVal path(,) As Integer, ByVal u As Integer, ByVal v As Integer)
		If path(u, v) = u Then
			Console.Write(u & " " & v & " ")
			Return
		End If
		PrintPath(path, u, path(u, v))
		Console.Write(v & " ")
	End Sub

	Public Shared Sub Main19()
		Dim gph As New Graph(4)
		gph.AddDirectedEdge(0, 0, 0)
		gph.AddDirectedEdge(1, 1, 0)
		gph.AddDirectedEdge(2, 2, 0)
		gph.AddDirectedEdge(3, 3, 0)

		gph.AddDirectedEdge(0, 1, 5)
		gph.AddDirectedEdge(0, 3, 10)
		gph.AddDirectedEdge(1, 2, 3)
		gph.AddDirectedEdge(2, 3, 1)
		FloydWarshall(gph)
		Console.WriteLine()
	End Sub

	'
	'Shortest Path from 0 —> 1 Cost:5 Path:0 1 
	'Shortest Path from 0 —> 2 Cost:8 Path:0 1 2 
	'Shortest Path from 0 —> 3 Cost:9 Path:0 1 2 3 
	'Shortest Path from 1 —> 2 Cost:3 Path:1 2 
	'Shortest Path from 1 —> 3 Cost:4 Path:1 2 3 
	'Shortest Path from 2 —> 3 Cost:1 Path:2 3
	'

	Friend Shared Sub PrintSolution(ByVal dist(,) As Integer, ByVal V As Integer)
		For i As Integer = 0 To V - 1
			For j As Integer = 0 To V - 1
				If dist(i, j) = Integer.MaxValue Then
					Console.Write("INF ")
				Else
					Console.Write(dist(i, j) & "   ")
				End If
			Next j
			Console.WriteLine()
		Next i
	End Sub


	Public Shared Sub Main(ByVal args() As String)
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
		Main15()
		Main16()
		Main17()
		Main18()
		Main19()

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

