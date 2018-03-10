Imports System
Imports System.Collections.Generic

Public Class Graph


	Public Class AdjNode
		' AdjNode class internal fields and methods.
		Implements IComparable(Of AdjNode)

		Friend source As Integer
		Friend destination As Integer
		Friend cost As Integer
		Friend nextNode As AdjNode

		Public Sub New(ByVal src As Integer, ByVal dst As Integer, ByVal cst As Integer)
			source = src
			destination = dst
			cost = cst
			nextNode = Nothing
		End Sub

		Public Sub New(ByVal src As Integer, ByVal dst As Integer)
			Me.New(src, dst, 1)
		End Sub

		Private Function IComparableGeneric_CompareTo(ByVal other As AdjNode) As Integer Implements IComparable(Of AdjNode).CompareTo
			Return cost - other.cost
		End Function
	End Class

	Private Class AdjList
		Friend head As AdjNode
	End Class

	Private count As Integer
	Private array() As AdjList

	Public Sub New(ByVal cnt As Integer)
		count = cnt
		array = New AdjList(cnt - 1) {}
		For i As Integer = 0 To cnt - 1
			array(i) = New AdjList()
			array(i).head = Nothing
		Next i
	End Sub
	' Othere methods.


	Public Overridable Sub AddEdge(ByVal source As Integer, ByVal destination As Integer, ByVal cost As Integer)
		Dim node As New AdjNode(source, destination, cost)
		node.nextNode = array(source).head
		array(source).head = node
	End Sub

	Public Overridable Sub AddEdge(ByVal source As Integer, ByVal destination As Integer)
		AddEdge(source, destination, 1)
	End Sub

	Public Overridable Sub AddBiEdge(ByVal source As Integer, ByVal destination As Integer, ByVal cost As Integer) 'bi directional edge
		AddEdge(source, destination, cost)
		AddEdge(destination, source, cost)
	End Sub

	Public Overridable Sub AddBiEdge(ByVal source As Integer, ByVal destination As Integer) 'bi directional edge
		AddBiEdge(source, destination, 1)
	End Sub

	Public Overridable Sub Print()
		Dim ad As AdjNode
		For i As Integer = 0 To count - 1
			ad = array(i).head
			If ad IsNot Nothing Then
				Console.Write("Vertex " & i & " is connected to : ")
				Do While ad IsNot Nothing
					Console.Write(ad.destination & " ")
					ad = ad.nextNode
				Loop
				Console.WriteLine("")
			End If
		Next i
	End Sub

	Public Shared Sub Dijkstra(ByVal gph As Graph, ByVal source As Integer)

		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer

		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = Integer.MaxValue 'infinite
		Next i

		dist(source) = 0
		previous(source) = -1

		Dim queue As New PriorityQueue(Of AdjNode)()

		Dim node As New AdjNode(source, source, 0)
		queue.Enqueue(node)

		Do While queue.Count <> 0
			node = queue.Peek()
			queue.Dequeue()

			Dim adl As AdjList = gph.array(node.destination)
			Dim adn As AdjNode = adl.head
			Do While adn IsNot Nothing
				Dim alt As Integer = adn.cost + dist(adn.source)
				If alt < dist(adn.destination) Then
					dist(adn.destination) = alt
					previous(adn.destination) = adn.source
					node = New AdjNode(adn.source, adn.destination, alt)
					queue.Enqueue(node)
				End If
				adn = adn.nextNode
			Loop
		Loop

		Dim count As Integer = gph.count
		For i As Integer = 0 To count - 1
			If dist(i) = Integer.MaxValue Then
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : Unreachable")
			Else
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : " & dist(i))

			End If
		Next i
	End Sub

	Public Shared Sub Prims(ByVal gph As Graph)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim source As Integer = 1

		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = Integer.MaxValue
		Next i

		dist(source) = 0
		previous(source) = -1

		Dim queue As New PriorityQueue(Of AdjNode)()
		Dim node As New AdjNode(source, source, 0)
		queue.Enqueue(node)

		Do While queue.Count <> 0
			node = queue.Peek()
			queue.Dequeue()

			If dist(node.destination) < node.cost Then
				Continue Do
			End If

			dist(node.destination) = node.cost
			previous(node.destination) = node.source

			Dim adl As AdjList = gph.array(node.destination)
			Dim adn As AdjNode = adl.head

			Do While adn IsNot Nothing
				If previous(adn.destination) = -1 Then
					node = New AdjNode(adn.source, adn.destination, adn.cost)
					queue.Enqueue(node)
				End If
				adn = adn.nextNode
			Loop
		Loop

		' Printing result.
		Dim count As Integer = gph.count
		For i As Integer = 0 To count - 1
			If dist(i) = Integer.MaxValue Then
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : Unreachable")
			Else
				Console.WriteLine(" node id " & i & "  prev " & previous(i) & " distance : " & dist(i))
			End If
		Next i
	End Sub

	Private Shared Sub TopologicalSortDFS(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Integer, ByVal stk As Stack(Of Integer))
		Dim head As AdjNode = gph.array(index).head
		Do While head IsNot Nothing
			If visited(head.destination) = 0 Then
				visited(head.destination) = 1
				TopologicalSortDFS(gph, head.destination, visited, stk)
			End If
			head = head.nextNode
		Loop
		stk.Push(index)
	End Sub

	Public Shared Sub TopologicalSort(ByVal gph As Graph)
		Dim stk As New Stack(Of Integer)()
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			visited(i) = 0
		Next i
		For i As Integer = 0 To count - 1
			If visited(i) = 0 Then
				visited(i) = 1
				TopologicalSortDFS(gph, i, visited, stk)
			End If
		Next i
		Do While stk.Count = 0 <> True
			Console.Write(" " & stk.Pop())
		Loop
	End Sub

	Public Shared Function PathExist(ByVal gph As Graph, ByVal source As Integer, ByVal destination As Integer) As Integer
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			visited(i) = 0
		Next i
		visited(source) = 1
		DFSRec(gph, source, visited)
		Return visited(destination)
	End Function

	Public Shared Sub DFSRec(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Integer)
		Dim head As AdjNode = gph.array(index).head
		Do While head IsNot Nothing
			If visited(head.destination) = 0 Then
				visited(head.destination) = 1
				DFSRec(gph, head.destination, visited)
			End If
			head = head.nextNode
		Loop
	End Sub

	Public Overridable Sub DFSStack(ByVal gph As Graph)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		Dim curr As Integer
		Dim stk As New Stack(Of Integer)()
		For i As Integer = 0 To count - 1
			visited(i) = 0
		Next i

		visited(0) = 1
		stk.Push(0)

		Do While stk.Count > 0
			curr = stk.Pop()
			Dim head As AdjNode = gph.array(curr).head
			Do While head IsNot Nothing
				If visited(head.destination) = 0 Then
					visited(head.destination) = 1
					stk.Push(head.destination)
				End If
				head = head.nextNode
			Loop
		Loop
	End Sub

	Friend Overridable Sub DFS(ByVal gph As Graph)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			visited(i) = 0
		Next i
		For i As Integer = 0 To count - 1
			If visited(i) = 0 Then
				visited(i) = 1
				DFSRec(gph, i, visited)
			End If
		Next i
	End Sub

	Public Overridable Sub BFSQueue(ByVal gph As Graph, ByVal index As Integer, ByVal visited() As Integer)
		Dim curr As Integer
		Dim que As New Queue(Of Integer)()

		visited(index) = 1
		que.Enqueue(index)

		Do While que.Count > 0
			curr = que.Dequeue()
			Dim head As AdjNode = gph.array(curr).head
			Do While head IsNot Nothing
				If visited(head.destination) = 0 Then
					visited(head.destination) = 1
					que.Enqueue(head.destination)
				End If
				head = head.nextNode
			Loop
		Loop
	End Sub

	Public Overridable Sub BFS(ByVal gph As Graph)
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			visited(i) = 0
		Next i
		For i As Integer = 0 To count - 1
			If visited(i) = 0 Then
				BFSQueue(gph, i, visited)
			End If
		Next i
	End Sub

	Public Overridable Function isConnected(ByVal gph As Graph) As Boolean
		Dim count As Integer = gph.count
		Dim visited(count - 1) As Integer
		For i As Integer = 0 To count - 1
			visited(i) = 0
		Next i
		visited(0) = 1
		DFSRec(gph, 0, visited)
		For i As Integer = 0 To count - 1
			If visited(i) = 0 Then
				Return False
			End If
		Next i
		Return True
	End Function

	Friend Overridable Sub ShortestPath(ByVal gph As Graph, ByVal source As Integer) ' unweighted graph
		Dim curr As Integer
		Dim count As Integer = gph.count
		Dim distance(count - 1) As Integer
		Dim path(count - 1) As Integer

		Dim que As New Queue(Of Integer)()

		For i As Integer = 0 To count - 1
			distance(i) = -1
		Next i
		que.Enqueue(source)
		distance(source) = 0
		Do While que.Count > 0
			curr = que.Dequeue()
			Dim head As AdjNode = gph.array(curr).head
			Do While head IsNot Nothing
				If distance(head.destination) = -1 Then
					distance(head.destination) = distance(curr) + 1
					path(head.destination) = curr
					que.Enqueue(head.destination)
				End If
				head = head.nextNode
			Loop
		Loop
		For i As Integer = 0 To count - 1
			Console.WriteLine(path(i) & " to " & i & " weight " & distance(i))
		Next i
	End Sub

	Friend Overridable Sub BellmanFordShortestPath(ByVal gph As Graph, ByVal source As Integer)
		Dim count As Integer = gph.count
		Dim distance(count - 1) As Integer
		Dim path(count - 1) As Integer

		For var As Integer = 0 To count - 1
			distance(var) = Integer.MaxValue
		Next var
		distance(source) = 0
		Dim i As Integer = 0
		Do While i < count - 1
			For j As Integer = 0 To count - 1
				Dim head As AdjNode = gph.array(j).head
				Do While head IsNot Nothing
					Dim newDistance As Integer = distance(j) + head.cost
					If distance(head.destination) > newDistance Then
						distance(head.destination) = newDistance
						path(head.destination) = j
					End If
					head = head.nextNode
				Loop
			Next j
			i += 1
		Loop
		For var As Integer = 0 To count - 1
			Console.WriteLine(path(var) & " to " & var & " weight " & distance(var))
		Next var
	End Sub

	Public Shared Sub Main3(ByVal args() As String)
		Dim gph As New Graph(9)
		gph.AddBiEdge(0, 2, 1)
		gph.AddBiEdge(1, 2, 5)
		gph.AddBiEdge(1, 3, 7)
		gph.AddBiEdge(1, 4, 9)
		gph.AddBiEdge(3, 2, 2)
		gph.AddBiEdge(3, 5, 4)
		gph.AddBiEdge(4, 5, 6)
		gph.AddBiEdge(4, 6, 3)
		gph.AddBiEdge(5, 7, 5)
		gph.AddBiEdge(6, 7, 7)
		gph.AddBiEdge(7, 8, 17)

		Prims(gph)
		'Dijkstra(gph,1);
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim g As New Graph(6)
		g.AddEdge(5, 2)
		g.AddEdge(5, 0)
		g.AddEdge(4, 0)
		g.AddEdge(4, 1)
		g.AddEdge(2, 3)
		g.AddEdge(3, 1)

		Console.WriteLine("Following is a Topological Sort of the given graph.")
		Graph.TopologicalSort(g)
	End Sub
End Class