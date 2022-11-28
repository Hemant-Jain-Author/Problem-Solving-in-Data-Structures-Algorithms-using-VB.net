Imports System

Public Module FloydWarshall
	ReadOnly INF As Integer = Integer.MaxValue

	Sub FindAllPairPath(ByVal graph(,) As Integer, ByVal V As Integer)
		Dim dist(V - 1, V - 1) As Integer

		For i As Integer = 0 To V - 1
			For j As Integer = 0 To V - 1
				dist(i, j) = graph(i, j)
			Next j
		Next i

		' Pick intermediate vertices.
		For k As Integer = 0 To V - 1
			' Pick source vertices one by one.
			For i As Integer = 0 To V - 1
				' Pick destination vertices.
				For j As Integer = 0 To V - 1
					' If we have shorter path from i to j via k.
					' then update dist[i, j]
					If dist(i, k) <> INF AndAlso dist(k, j) <> INF AndAlso dist(i, k) + dist(k, j) < dist(i, j) Then
						dist(i, j) = dist(i, k) + dist(k, j)
					End If
				Next j
			Next i
		Next k

		' Print the shortest distance matrix
		PrintSolution(dist, V)
	End Sub

	Sub PrintSolution(ByVal dist(,) As Integer, ByVal V As Integer)
		For i As Integer = 0 To V - 1
			For j As Integer = 0 To V - 1
				If dist(i, j) = INF Then
					Console.Write("INF ")
				Else
					Console.Write(dist(i, j) & "   ")
				End If
			Next j
			Console.WriteLine()
		Next i
	End Sub

	' Testing code.
	Sub Main(ByVal args() As String)
		Dim graph(,) As Integer = {
			{0, 2, 4, INF, INF, INF, INF},
			{2, 0, 4, 1, INF, INF, INF},
			{4, 4, 0, 2, 8, 4, INF},
			{INF, 1, 2, 0, 3, INF, 6},
			{INF, INF, 6, 4, 0, 3, 1},
			{INF, INF, 4, INF, 4, 0, 2},
			{INF, INF, INF, 4, 2, 3, 0}
		}

		FindAllPairPath(graph, 7)
	End Sub
End Module

'
'0   2   4   3   6   8   7   
'2   0   3   1   4   7   5   
'4   3   0   2   5   4   6   
'3   1   2   0   3   6   4   
'7   5   6   4   0   3   1   
'8   7   4   6   4   0   2   
'7   5   6   4   2   3   0  
' 
