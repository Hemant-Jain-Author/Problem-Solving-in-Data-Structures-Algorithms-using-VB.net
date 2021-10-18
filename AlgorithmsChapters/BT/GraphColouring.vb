Imports System

Public Class GraphColouring
	' Is it safe to colour vth vertice with c colour.
	Private Shared Function IsSafe(ByVal graph(,) As Boolean, ByVal V As Integer, ByVal colour() As Integer, ByVal vs As Integer, ByVal c As Integer) As Boolean
		For i As Integer = 0 To V - 1
			If graph(vs, i) = True AndAlso c = colour(i) Then
				Return False
			End If
		Next i
		Return True
	End Function

	Private Shared Function ColouringUtil(ByVal graph(,) As Boolean, ByVal V As Integer, ByVal m As Integer, ByVal colour() As Integer, ByVal i As Integer) As Boolean
		If i = V Then
			PrintSolution(colour, V)
			Return True
		End If
		
		Dim j As Integer = 1
		Do While j <= m
			If IsSafe(graph, V, colour, i, j) Then
				colour(i) = j
				If ColouringUtil(graph, V, m, colour, i + 1) Then
					Return True
				End If
			End If
			j += 1
		Loop
		Return False
	End Function

	Public Shared Function Colouring(ByVal graph(,) As Boolean, ByVal V As Integer, ByVal m As Integer) As Boolean
		Dim colour(V - 1) As Integer
		If ColouringUtil(graph, V, m, colour, 0) Then
			Return True
		End If
		Return False
	End Function

	Private Shared Sub PrintSolution(ByVal colour() As Integer, ByVal V As Integer)
		Console.Write("Assigned colours are::")
		For i As Integer = 0 To V - 1
			Console.Write(" " & colour(i))
		Next i
		Console.WriteLine()
	End Sub

	' Check if the whole graph is coloured properly.
	Private Shared Function IsSafe2(ByVal graph(,) As Boolean, ByVal colour() As Integer, ByVal V As Integer) As Boolean
		For i As Integer = 0 To V - 1
			For j As Integer = i + 1 To V - 1
				If graph(i, j) AndAlso colour(j) = colour(i) Then
					Return False
				End If
			Next j
		Next i
		Return True
	End Function

	Private Shared Function Colouring2(ByVal graph(,) As Boolean, ByVal V As Integer, ByVal m As Integer, ByVal colour() As Integer, ByVal i As Integer) As Boolean
		If i = V Then
			If IsSafe2(graph, colour, V) Then
				PrintSolution(colour, V)
				Return True
			End If
			Return False
		End If

		' Assign each colour from 1 to m
		Dim j As Integer = 1
		Do While j <= m
			colour(i) = j
			If Colouring2(graph, V, m, colour, i + 1) Then
				Return True
			End If
			j += 1
		Loop
		Return False
	End Function


	Public Shared Function Colouring2(ByVal graph(,) As Boolean, ByVal V As Integer, ByVal m As Integer) As Boolean
		Dim colour(V - 1) As Integer
		If Colouring2(graph, V, m, colour, 0) Then
				Return True
		End If
		Return False
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim graph(,) As Boolean = {
			{False, True, False, False, True},
			{True, False, True, False, True},
			{False, True, False, True, True},
			{False, False, True, False, True},
			{True, True, True, True, False}
		}
		Dim V As Integer = 5 ' Number of vertices
		Dim m As Integer = 4 ' Number of colours
		If Not GraphColouring.Colouring2(graph, V, m) Then
			Console.WriteLine("Solution does not exist")
		End If

		If Not GraphColouring.Colouring(graph, V, m) Then
			Console.WriteLine("Solution does not exist")
		End If
	End Sub
End Class
'
'Assigned colours are:: 1 2 1 2 3
'Assigned colours are:: 1 2 1 2 3
'