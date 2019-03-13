Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Public Class GraphAM
	Friend count As Integer
	Friend adj(,) As Integer

	Friend Sub New(ByVal cnt As Integer)
		count = cnt
		adj = New Integer(count - 1, count - 1) {}
	End Sub

	Public Overridable Sub addDirectedEdge(ByVal src As Integer, ByVal dst As Integer, ByVal cost As Integer)
		adj(src, dst) = cost
	End Sub

	Public Overridable Sub addUndirectedEdge(ByVal src As Integer, ByVal dst As Integer, ByVal cost As Integer)
		addDirectedEdge(src, dst, cost)
		addDirectedEdge(dst, src, cost)
	End Sub

	Public Overridable Sub print()
		For i As Integer = 0 To count - 1
			Console.Write("Node index [ " & i & " ] is connected with : ")
			For j As Integer = 0 To count - 1
				If adj(i, j) <> 0 Then
					Console.Write(j & " ")
				End If
			Next j
			Console.WriteLine("")
		Next i
	End Sub

	Public Shared Sub main1()
		Dim graph As New GraphAM(4)
		graph.addUndirectedEdge(0, 1, 1)
		graph.addUndirectedEdge(0, 2, 1)
		graph.addUndirectedEdge(1, 2, 1)
		graph.addUndirectedEdge(2, 3, 1)
		graph.print()
	End Sub

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

	Public Shared Sub dijkstra(ByVal gph As GraphAM, ByVal source As Integer)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim visited(gph.count - 1) As Boolean

		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = Integer.MaxValue ' infinite
			visited(i) = False
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
			For dest As Integer = 0 To gph.count - 1
				Dim cost As Integer = gph.adj(source, dest)
				If cost <> 0 Then
					Dim alt As Integer = cost + dist(source)
					If dist(dest) > alt AndAlso visited(dest) = False Then

						dist(dest) = alt
						previous(dest) = source
						node = New Edge(dest, alt)
						queue.add(node)
					End If
				End If
			Next dest
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

	Public Shared Sub prims(ByVal gph As GraphAM)
		Dim previous(gph.count - 1) As Integer
		Dim dist(gph.count - 1) As Integer
		Dim source As Integer = 0
		Dim visited(gph.count - 1) As Boolean

		For i As Integer = 0 To gph.count - 1
			previous(i) = -1
			dist(i) = Integer.MaxValue ' infinite
			visited(i) = False
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
			For dest As Integer = 0 To gph.count - 1
				Dim cost As Integer = gph.adj(source, dest)
				If cost <> 0 Then
					Dim alt As Integer = cost
					If dist(dest) > alt AndAlso visited(dest) = False Then
						dist(dest) = alt
						previous(dest) = source
						node = New Edge(dest, alt)
						queue.add(node)
					End If
				End If
			Next dest
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

	Public Shared Sub main2()
		Dim gph As New GraphAM(9)
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
		prims(gph)
		dijkstra(gph, 0)
	End Sub

	Public Shared Sub main3()
		Dim gph As New GraphAM(9)
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
		gph.print()
		prims(gph)
		dijkstra(gph, 1)
	End Sub

	Public Shared Function hamiltonianPathUtil(ByVal graph As GraphAM, ByVal path() As Integer, ByVal pSize As Integer, ByVal added() As Integer) As Boolean
		' Base case full length path is found
		If pSize = graph.count Then
			Return True
		End If
		For vertex As Integer = 0 To graph.count - 1
			' there is a path from last element and next vertex
			' and next vertex is not already included in path.
			If pSize = 0 OrElse (graph.adj(path(pSize - 1), vertex) = 1 AndAlso added(vertex) = 0) Then
				'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
				'ORIGINAL LINE: path[pSize++] = vertex;
				path(pSize) = vertex
				pSize += 1
				added(vertex) = 1
				If hamiltonianPathUtil(graph, path, pSize, added) Then
					Return True
				End If
				' backtracking
				pSize -= 1
				added(vertex) = 0
			End If
		Next vertex
		Return False
	End Function

	Public Shared Function hamiltonianPath(ByVal graph As GraphAM) As Boolean
		Dim path(graph.count - 1) As Integer
		Dim added(graph.count - 1) As Integer

		If hamiltonianPathUtil(graph, path, 0, added) Then
			Console.WriteLine("Hamiltonian Path found :: ")
			For i As Integer = 0 To graph.count - 1
				Console.WriteLine(" " & path(i))
			Next i
			Return True
		End If
		Console.WriteLine("Hamiltonian Path not found")
		Return False
	End Function

	Public Shared Function hamiltonianCycleUtil(ByVal graph As GraphAM, ByVal path() As Integer, ByVal pSize As Integer, ByVal added() As Integer) As Boolean
		' Base case full length path is found this last check can be modified to make it a path.
		If pSize = graph.count Then
			If graph.adj(path(pSize - 1), path(0)) = 1 Then
				path(pSize) = path(0)
				Return True
			Else
				Return False
			End If
		End If
		For vertex As Integer = 0 To graph.count - 1
			' there is a path from last element and next vertex
			If pSize = 0 OrElse (graph.adj(path(pSize - 1), vertex) = 1 AndAlso added(vertex) = 0) Then
				'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
				'ORIGINAL LINE: path[pSize++] = vertex;
				path(pSize) = vertex
				pSize += 1
				added(vertex) = 1
				If hamiltonianCycleUtil(graph, path, pSize, added) Then
					Return True
				End If
				' backtracking
				pSize -= 1
				added(vertex) = 0
			End If
		Next vertex
		Return False
	End Function

	Public Shared Function hamiltonianCycle(ByVal graph As GraphAM) As Boolean
		Dim path(graph.count) As Integer
		Dim added(graph.count - 1) As Integer
		If hamiltonianCycleUtil(graph, path, 0, added) Then
			Console.WriteLine("Hamiltonian Cycle found :: ")
			For i As Integer = 0 To graph.count
				Console.Write(" " & path(i))
			Next i
			Return True
		End If
		Console.WriteLine("Hamiltonian Cycle not found")
		Return False
	End Function

	Public Shared Sub main4()
		Dim count As Integer = 5
		Dim graph As New GraphAM(count)
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
					graph.addDirectedEdge(i, j, 1)
				End If
			Next j
		Next i
		Console.WriteLine("hamiltonianPath : " & hamiltonianPath(graph))
		Console.WriteLine("hamiltonianCycle : " & hamiltonianCycle(graph))

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
					graph2.addDirectedEdge(i, j, 1)
				End If
			Next j
		Next i

		Console.WriteLine("hamiltonianPath :  " & hamiltonianPath(graph2))
		Console.WriteLine("hamiltonianCycle :  " & hamiltonianCycle(graph2))
	End Sub

	Public Shared Sub Main()
		main1()
		main2()
		main3()
		main4()
	End Sub
End Class

Module Module1
	Public Sub Main(ByVal args() As String)
		GraphAM.Main()
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
