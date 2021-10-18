Imports System

Public Class GraphAM
	Private count As Integer
	Private adj(,) As Integer

	Public Sub New(ByVal cnt As Integer)
		count = cnt
		adj = New Integer(count - 1, count - 1){}
	End Sub

	Public Sub AddDirectedEdge(ByVal src As Integer, ByVal dst As Integer, ByVal cost As Integer)
		adj(src, dst) = cost
	End Sub

	Public Sub AddUndirectedEdge(ByVal src As Integer, ByVal dst As Integer, ByVal cost As Integer)
		AddDirectedEdge(src, dst, cost)
		AddDirectedEdge(dst, src, cost)
	End Sub

	Public Sub Print()
		For i As Integer = 0 To count - 1
			Console.Write("Vertex " & i & " is connected to : ")
			For j As Integer = 0 To count - 1
				If adj(i, j) <> 0 Then
					Console.Write("(" & j & ", " & adj(i, j) & ") ")
				End If
			Next j
			Console.WriteLine("")
		Next i
	End Sub

	Public Shared Sub Main1()
		Dim gph As New GraphAM(4)
		f.AddUndirectedEdge(0, 1, 1)
		gph.AddUndirectedEdge(0, 2, 1)
		gph.AddUndirectedEdge(1, 2, 1)
		gph.AddUndirectedEdge(2, 3, 1)
		gph.Print()
	End Sub

'
'Vertex 0 is connected to : (1, 1) (2, 1) 
'Vertex 1 is connected to : (0, 1) (2, 1) 
'Vertex 2 is connected to : (0, 1) (1, 1) (3, 1) 
'Vertex 3 is connected to : (2, 1)
'
	Private Class Edge
		Implements IComparable(Of Edge)

		Friend src, dest, cost As Integer

		Public Sub New(ByVal s As Integer, ByVal d As Integer, ByVal c As Integer)
			src = s
			dest = d
			cost = c
		End Sub

		Public Function CompareTo(ByVal compareEdge As Edge) As Integer
			Return Me.cost - compareEdge.cost
		End Function
	End Class

	Public Shared Sub Dijkstra(ByVal gph As GraphAM, ByVal source As Integer)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim visited(gph.count - 1) As Boolean
		Array.Fill(previous, -1)
		Array.Fill(dist, Integer.MaxValue) ' infinite

		dist(source) = 0
		previous(source) = -1

		Dim queue As New PriorityQueue(Of Edge)()
		Dim node As New Edge(source, source, 0)
		queue.Add(node)

		Do While queue.IsEmpty() <> True
			node = queue.Peek()
			queue.Remove()
			source = node.dest
			visited(source) = True
			For dest As Integer = 0 To gph.count - 1
				Dim cost As Integer = gph.adj(source, dest)
				If cost <> 0 Then
					Dim alt As Integer = cost + dist(source)
					If dist(dest) > alt AndAlso visited(dest) = False Then

						dist(dest) = alt
						previous(dest) = source
						node = New Edge(source, dest, alt)
						queue.Add(node)
					End If
				End If
			Next dest
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

	Public Shared Sub Prims(ByVal gph As GraphAM)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim source As Integer = 0
		Dim visited(gph.count - 1) As Boolean
		Array.Fill(previous, -1)
		Array.Fill(dist, Integer.MaxValue) ' infinite

		dist(source) = 0
		previous(source) = -1
		Dim queue As New PriorityQueue(Of Edge)()
		Dim node As New Edge(source, source, 0)
		queue.Add(node)

		Do While queue.IsEmpty() <> True
			node = queue.Peek()
			queue.Remove()
			source = node.dest
			visited(source) = True
			For dest As Integer = 0 To gph.count - 1
				Dim cost As Integer = gph.adj(source, dest)
				If cost <> 0 Then
					If dist(dest) > cost AndAlso visited(dest) = False Then
						dist(dest) = cost
						previous(dest) = source
						node = New Edge(source, dest, cost)
						queue.Add(node)
					End If
				End If
			Next dest
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

	Public Shared Sub Main2()
		Dim gph As New GraphAM(9)
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
		'gph.Print();
		Prims(gph)
		'Dijkstra(gph, 0);
	End Sub
'
'Vertex 0 is connected to : (1, 4) (7, 8) 
'Vertex 1 is connected to : (0, 4) (2, 8) (7, 11) 
'Vertex 2 is connected to : (1, 8) (3, 7) (5, 4) (8, 2) 
'Vertex 3 is connected to : (2, 7) (4, 9) (5, 14) 
'Vertex 4 is connected to : (3, 9) (5, 10) 
'Vertex 5 is connected to : (2, 4) (3, 14) (4, 10) (6, 2) 
'Vertex 6 is connected to : (5, 2) (7, 1) (8, 6) 
'Vertex 7 is connected to : (0, 8) (1, 11) (6, 1) (8, 7) 
'Vertex 8 is connected to : (2, 2) (6, 6) (7, 7)  
'
'
'node id 0  prev -1 distance : 0
'node id 1  prev 0 distance : 4
'node id 2  prev 5 distance : 4
'node id 3  prev 2 distance : 7
'node id 4  prev 3 distance : 9
'node id 5  prev 6 distance : 2
'node id 6  prev 7 distance : 1
'node id 7  prev 0 distance : 8
'node id 8  prev 2 distance : 2
'
'node id 0  prev -1 distance : 0
'node id 1  prev 0 distance : 4
'node id 2  prev 1 distance : 12
'node id 3  prev 2 distance : 19
'node id 4  prev 5 distance : 21
'node id 5  prev 6 distance : 11
'node id 6  prev 7 distance : 9
'node id 7  prev 0 distance : 8
'node id 8  prev 2 distance : 14
'
'

	Public Shared Sub Main3()
		Dim gph As New GraphAM(9)
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
		gph.Print()
		Prims(gph)
		Dijkstra(gph, 1)
	End Sub
'
'Vertex 0 is connected to : (2, 1) 
'Vertex 1 is connected to : (2, 5) (3, 7) (4, 9) 
'Vertex 2 is connected to : (0, 1) (1, 5) (3, 2) 
'Vertex 3 is connected to : (1, 7) (2, 2) (5, 4) 
'Vertex 4 is connected to : (1, 9) (5, 6) (6, 3) 
'Vertex 5 is connected to : (3, 4) (4, 6) (7, 1) 
'Vertex 6 is connected to : (4, 3) (7, 7) 
'Vertex 7 is connected to : (5, 1) (6, 7) (8, 17) 
'Vertex 8 is connected to : (7, 17)
'
'node id 0  prev -1 distance : 0
'node id 1  prev 2 distance : 5
'node id 2  prev 0 distance : 1
'node id 3  prev 2 distance : 2
'node id 4  prev 5 distance : 6
'node id 5  prev 3 distance : 4
'node id 6  prev 4 distance : 3
'node id 7  prev 5 distance : 1
'node id 8  prev 7 distance : 17
'
'node id 0  prev 2 distance : 6
'node id 1  prev -1 distance : 0
'node id 2  prev 1 distance : 5
'node id 3  prev 1 distance : 7
'node id 4  prev 1 distance : 9
'node id 5  prev 3 distance : 11
'node id 6  prev 4 distance : 12
'node id 7  prev 5 distance : 12
'node id 8  prev 7 distance : 29
'
	Public Shared Function HamiltonianPathUtil(ByVal gph As GraphAM, ByVal path() As Integer, ByVal pSize As Integer, ByVal added() As Integer) As Boolean
		' Base case full length path is found
		If pSize = gph.count Then
			Return True
		End If
		For vertex As Integer = 0 To gph.count - 1
			' There is an edge from last element of path and next vertex
			' and the next vertex is not already included in the path.
			If pSize = 0 OrElse (gph.adj(path(pSize - 1), vertex) = 1 AndAlso added(vertex) = 0) Then
				path(pSize) = vertex
				pSize += 1
				added(vertex) = 1
				If HamiltonianPathUtil(gph, path, pSize, added) Then
					Return True
				End If
				' backtracking
				pSize -= 1
				added(vertex) = 0
			End If
		Next vertex
		Return False
	End Function


	Public Shared Function HamiltonianPath(ByVal gph As GraphAM) As Boolean
		Dim path(gph.count - 1) As Integer
		Dim added(gph.count - 1) As Integer

		If HamiltonianPathUtil(gph, path, 0, added) Then
			Console.Write("Hamiltonian Path found :: ")
			For i As Integer = 0 To gph.count - 1
				Console.Write(" " & path(i))
			Next i
			Console.WriteLine("")
			Return True
		End If

		Console.WriteLine("Hamiltonian Path not found")
		Return False
	End Function

	Public Shared Function HamiltonianCycleUtil(ByVal gph As GraphAM, ByVal path() As Integer, ByVal pSize As Integer, ByVal added() As Integer) As Boolean
		' Base case full length path is found
		' this last check can be modified to make it a path.
		If pSize = gph.count Then
			If gph.adj(path(pSize - 1), path(0)) = 1 Then
				path(pSize) = path(0)
				Return True
			Else
				Return False
			End If
		End If
		For vertex As Integer = 0 To gph.count - 1
			' there is a path from last element and next vertex
			If pSize = 0 OrElse (gph.adj(path(pSize - 1), vertex) = 1 AndAlso added(vertex) = 0) Then

				path(pSize) = vertex
				pSize += 1
				added(vertex) = 1
				If HamiltonianCycleUtil(gph, path, pSize, added) Then
					Return True
				End If
				' backtracking
				pSize -= 1
				added(vertex) = 0
			End If
		Next vertex
		Return False
	End Function

	Public Shared Function HamiltonianCycle(ByVal gph As GraphAM) As Boolean
		Dim path(gph.count) As Integer
		Dim added(gph.count - 1) As Integer
		If HamiltonianCycleUtil(gph, path, 0, added) Then
			Console.Write("Hamiltonian Cycle found :: ")
			For i As Integer = 0 To gph.count
				Console.Write(" " & path(i))
			Next i
			Console.WriteLine("")
			Return True
		End If
		Console.WriteLine("Hamiltonian Cycle not found")
		Return False
	End Function

		Public Shared Sub Main4()
		Dim count As Integer = 5
		Dim gph As New GraphAM(count)
		Dim adj(,) As Integer = {
			{0, 1, 0, 1, 0},
			{1, 0, 1, 1, 0},
			{0, 1, 0, 0, 1},
			{1, 1, 0, 0, 1},
			{0, 1, 1, 1, 0}
		}

		For i As Integer = 0 To count - 1
			For j As Integer = 0 To count - 1
				If adj(i, j) = 1 Then
					gph.AddDirectedEdge(i, j, 1)
				End If
			Next j
		Next i
		Console.WriteLine("HamiltonianPath : " & HamiltonianPath(gph))

		Dim graph2 As New GraphAM(count)
		Dim adj2(,) As Integer = {
			{0, 1, 0, 1, 0},
			{1, 0, 1, 1, 0},
			{0, 1, 0, 0, 1},
			{1, 1, 0, 0, 0},
			{0, 1, 1, 0, 0}
		}
		For i As Integer = 0 To count - 1
			For j As Integer = 0 To count - 1
				If adj2(i, j) = 1 Then
					graph2.AddDirectedEdge(i, j, 1)
				End If
			Next j
		Next i

		Console.WriteLine("HamiltonianPath :  " & HamiltonianPath(graph2))
		End Sub
'
'Hamiltonian Path found ::  0 1 2 4 3
'HamiltonianPath : true
'
'Hamiltonian Path found ::  0 3 1 2 4
'HamiltonianPath :  true


	Public Shared Sub Main5()
		Dim count As Integer = 5
		Dim gph As New GraphAM(count)
		Dim adj(,) As Integer = {
			{0, 1, 0, 1, 0},
			{1, 0, 1, 1, 0},
			{0, 1, 0, 0, 1},
			{1, 1, 0, 0, 1},
			{0, 1, 1, 1, 0}
		}

		For i As Integer = 0 To count - 1
			For j As Integer = 0 To count - 1
				If adj(i, j) = 1 Then
					gph.AddDirectedEdge(i, j, 1)
				End If
			Next j
		Next i
		Console.WriteLine("HamiltonianCycle : " & HamiltonianCycle(gph))

		Dim graph2 As New GraphAM(count)
		Dim adj2(,) As Integer = {
			{0, 1, 0, 1, 0},
			{1, 0, 1, 1, 0},
			{0, 1, 0, 0, 1},
			{1, 1, 0, 0, 0},
			{0, 1, 1, 0, 0}
		}
		For i As Integer = 0 To count - 1
			For j As Integer = 0 To count - 1
				If adj2(i, j) = 1 Then
					graph2.AddDirectedEdge(i, j, 1)
				End If
			Next j
		Next i

		Console.WriteLine("HamiltonianCycle :  " & HamiltonianCycle(graph2))
	End Sub

'
'Hamiltonian Cycle found ::  0 1 2 4 3 0
'HamiltonianCycle : true
'
'Hamiltonian Cycle not found
'HamiltonianCycle :  false
'
	Public Shared Sub Main(ByVal args() As String)
			Main1()
			Main2()
			Main3()
			Main4()
	End Sub
End Class

