Imports System

Public Module NQueens
    Sub Print(ByVal Q As Integer(), ByVal n As Integer)
        For i As Integer = 0 To n - 1
            Console.Write(" " & Q(i))
        Next

        Console.WriteLine(" ")
    End Sub

    Function Feasible(ByVal Q As Integer(), ByVal k As Integer) As Boolean
        For i As Integer = 0 To k - 1

            If Q(k) = Q(i) OrElse Math.Abs(Q(i) - Q(k)) = Math.Abs(i - k) Then
                Return False
            End If
        Next

        Return True
    End Function

    Sub NQueensPattern(ByVal Q As Integer(), ByVal k As Integer, ByVal n As Integer)
        If k = n Then
            Print(Q, n)
            Return
        End If

        For i As Integer = 0 To n - 1
            Q(k) = i

            If Feasible(Q, k) Then
                NQueensPattern(Q, k + 1, n)
            End If
        Next
    End Sub

    ' Testing code.
    Sub Main(ByVal args As String())
        Dim Q As Integer() = New Integer(7) {}
        NQueensPattern(Q, 0, 8)
    End Sub
End Module


'
' 0 4 7 5 2 6 1 3 
' 0 5 7 2 6 3 1 4 
' ......
' 7 2 0 5 1 4 6 3 
' 7 3 0 2 5 1 6 4 
' 