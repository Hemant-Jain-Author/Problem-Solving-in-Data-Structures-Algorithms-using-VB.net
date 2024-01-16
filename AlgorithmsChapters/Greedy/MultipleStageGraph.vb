Imports System

Public Module MultipleStageGraph
	Dim INF As Integer = Integer.MaxValue

	' Returns shortest distance from 0 to N-1.
	Function ShortestDist(ByVal graph(,) As Integer, ByVal n As Integer) As Integer
		' dist[i] is going to store shortest
		' distance from node i to node n-1.
		Dim dist(n - 1) As Integer
		For i As Integer = 0 To (n - 1)
			dist(i)= INF
		Next i
		Dim path(n - 1) As Integer
		Dim value As Integer
		dist(0) = 0
		path(0) = -1

		' Calculating shortest path for the nodes
		For i As Integer = 0 To n - 1
			' Check all nodes of next 
			For j As Integer = i To n - 1
				' Reject if no edge exists
				If graph(i, j) = INF Then
					Continue For
				End If
				value = graph(i, j) + dist(i)
				If dist(j) > value Then
					dist(j) = value
					path(j) = i
				End If
			Next j
		Next i
		value = n - 1
		Do While value <> -1
			Console.Write(value & " ")
			value = path(value)
		Loop
		Console.WriteLine()

		Return dist(n - 1)
	End Function

	' Testing code.
	Sub Main(ByVal args() As String)
		' Graph stored in the form of an
		' adjacency Matrix
		Dim graph(,) As Integer = {
			{INF, 1, 2, 5, INF, INF, INF, INF},
			{INF, INF, INF, INF, 4, 11, INF, INF},
			{INF, INF, INF, INF, 9, 5, 16, INF},
			{INF, INF, INF, INF, INF, INF, 2, INF},
			{INF, INF, INF, INF, INF, INF, INF, 18},
			{INF, INF, INF, INF, INF, INF, INF, 13},
			{INF, INF, INF, INF, INF, INF, INF, 2},
			{INF, INF, INF, INF, INF, INF, INF, INF}
		}

		Console.WriteLine(ShortestDist(graph, 8))
	End Sub
End Module

'
'7 6 3 0 
'9
'