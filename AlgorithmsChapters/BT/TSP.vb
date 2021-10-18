Imports System

Public Class TSP
	' Function to find the minimum weight Hamiltonian Cycle 
	Friend Shared Function FindPath(ByVal graph(,) As Integer, ByVal n As Integer, ByVal path() As Integer, ByVal pSize As Integer, ByVal pCost As Integer, ByVal visited() As Boolean, ByVal ans As Integer) As Integer
		Dim curr As Integer = path(n - 1)
		If pSize = n AndAlso graph(curr, 0) > 0 Then
			ans = Math.Min(ans, pCost + graph(curr, 0))
			Return ans
		End If

		Dim i As Integer = 0
		Do While i < n
			If visited(i) = False AndAlso graph(curr, i) > 0 Then
				visited(i) = True
				path(pSize) = i
				ans = FindPath(graph, n, path, pSize+1, pCost + graph(curr, i),visited, ans)
				visited(i) = False
			End If
			i += 1
		Loop
		Return ans
	End Function

	Friend Shared Function FindPath(ByVal graph(,) As Integer, ByVal n As Integer) As Integer
		Dim visited(n - 1) As Boolean
		Dim path(n - 1) As Integer
		path(0) = 0
		visited(0) = True
		Dim ans As Integer = Integer.MaxValue
		ans = FindPath(graph, n, path, 1, 0, visited, ans)
		Console.WriteLine(ans)
		Return ans
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim n As Integer = 4
		Dim graph(,) As Integer = {
			{0, 10, 15, 20},
			{10, 0, 35, 25},
			{15, 35, 0, 30},
			{20, 25, 30, 0}
		}
		TSP.FindPath(graph, n)
	End Sub
End Class

' 65