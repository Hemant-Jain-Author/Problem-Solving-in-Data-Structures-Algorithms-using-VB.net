Imports System

Public Module GraphColouring
    Function Colouring(ByVal graph As Boolean(,), ByVal V As Integer, ByVal m As Integer) As Boolean
        Dim colour As Integer() = New Integer(V - 1) {}

        If ColouringUtil(graph, V, m, colour, 0) Then
            Return True
        End If

        Return False
    End Function

    Function ColouringUtil(ByVal graph As Boolean(,), ByVal V As Integer, ByVal m As Integer, ByVal colour As Integer(), ByVal i As Integer) As Boolean
        If i = V Then
            PrintSolution(colour, V)
            Return True
        End If

        For j As Integer = 1 To m

            If IsSafe(graph, V, colour, i, j) Then
                colour(i) = j

                If ColouringUtil(graph, V, m, colour, i + 1) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    ' Is it safe to colour vth vertice with c colour.
    Function IsSafe(ByVal graph As Boolean(,), ByVal V As Integer, ByVal colour As Integer(), ByVal vs As Integer, ByVal c As Integer) As Boolean
        For i As Integer = 0 To V - 1

            If graph(vs, i) = True AndAlso c = colour(i) Then
                Return False
            End If
        Next

        Return True
    End Function

    Sub PrintSolution(ByVal colour As Integer(), ByVal V As Integer)
        Console.Write("Assigned colours are::")

        For i As Integer = 0 To V - 1
            Console.Write(" " & colour(i))
        Next

        Console.WriteLine()
    End Sub

    Function IsSafe2(ByVal graph As Boolean(,), ByVal colour As Integer(), ByVal V As Integer) As Boolean
        For i As Integer = 0 To V - 1

            For j As Integer = i + 1 To V - 1

                If graph(i, j) AndAlso colour(j) = colour(i) Then
                    Return False
                End If
            Next
        Next

        Return True
    End Function

    Function Colouring2(ByVal graph As Boolean(,), ByVal V As Integer, ByVal m As Integer, ByVal colour As Integer(), ByVal i As Integer) As Boolean
        If i = V Then

            If IsSafe2(graph, colour, V) Then
                PrintSolution(colour, V)
                Return True
            End If

            Return False
        End If

        For j As Integer = 1 To m
            colour(i) = j

            If Colouring2(graph, V, m, colour, i + 1) Then
                Return True
            End If
        Next

        Return False
    End Function

    Function Colouring2(ByVal graph As Boolean(,), ByVal V As Integer, ByVal m As Integer) As Boolean
        Dim colour As Integer() = New Integer(V - 1) {}

        If Colouring2(graph, V, m, colour, 0) Then
            Return True
        End If

        Return False
    End Function

    ' Testing code.
    Sub Main(ByVal args As String())
        Dim graph As Boolean(,) = New Boolean(,) {
        {False, True, False, False, True},
        {True, False, True, False, True},
        {False, True, False, True, True},
        {False, False, True, False, True},
        {True, True, True, True, False}}
        Dim V As Integer = 5
        Dim m As Integer = 4

        If Not GraphColouring.Colouring2(graph, V, m) Then
            Console.WriteLine("Solution does not exist")
        End If

        If Not GraphColouring.Colouring(graph, V, m) Then
            Console.WriteLine("Solution does not exist")
        End If
    End Sub
End Module
'
'Assigned colours are:: 1 2 1 2 3
'Assigned colours are:: 1 2 1 2 3
'