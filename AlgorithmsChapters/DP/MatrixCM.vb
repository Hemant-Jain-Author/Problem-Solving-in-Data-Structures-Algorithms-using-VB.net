Imports System

Public Module MatrixCM
    Function MatrixChainMulBruteForce(ByVal p As Integer(), ByVal i As Integer, ByVal j As Integer) As Integer
        If i = j Then Return 0
        Dim min As Integer = Integer.MaxValue
        ' place parenthesis at different places between
        ' first and last matrix, recursively calculate
        ' count of multiplications for each parenthesis
        ' placement and return the minimum count
        For k As Integer = i To j - 1
            Dim count As Integer = MatrixChainMulBruteForce(p, i, k) + MatrixChainMulBruteForce(p, k + 1, j) + p(i - 1) * p(k) * p(j)
            If count < min Then
                min = count
            End If
        Next
        Return min ' Return minimum count
    End Function

    Function MatrixChainMulBruteForce(ByVal p As Integer(), ByVal n As Integer) As Integer
        Dim i As Integer = 1, j As Integer = n - 1
        Return MatrixChainMulBruteForce(p, i, j)
    End Function

    Function MatrixChainMulTD(ByVal p As Integer(), ByVal n As Integer) As Integer
        Dim dp As Integer(,) = New Integer(n - 1, n - 1) {}

        For i As Integer = 0 To n - 1
            For j As Integer = 0 To n - 1
                dp(i, j) = Integer.MaxValue
            Next
            dp(i, i) = 0
        Next

        Return MatrixChainMulTD(dp, p, 1, n - 1)
    End Function

    Function MatrixChainMulTD(ByVal dp As Integer(,), ByVal p As Integer(), ByVal i As Integer, ByVal j As Integer) As Integer
        ' Base Case
        If dp(i, j) <> Integer.MaxValue Then
            Return dp(i, j)
        End If

        For k As Integer = i To j - 1
            dp(i, j) = Math.Min(dp(i, j), MatrixChainMulTD(dp, p, i, k) + MatrixChainMulTD(dp, p, k + 1, j) + p(i - 1) * p(k) * p(j))
        Next
        Return dp(i, j)
    End Function

    Function MatrixChainMulBU(ByVal p As Integer(), ByVal n As Integer) As Integer
        Dim dp As Integer(,) = New Integer(n - 1, n - 1) {}

        For i As Integer = 0 To n - 1

            For j As Integer = 0 To n - 1
                dp(i, j) = Integer.MaxValue
            Next

            dp(i, i) = 0
        Next

        For l As Integer = 1 To n - 1
            Dim i As Integer = 1, j As Integer = i + l

            While j < n

                For k As Integer = i To j - 1
                    dp(i, j) = Math.Min(dp(i, j), dp(i, k) + p(i - 1) * p(k) * p(j) + dp(k + 1, j))
                Next

                i += 1
                j += 1
            End While
        Next

        Return dp(1, n - 1)
    End Function

    Sub PrintOptPar(ByVal n As Integer, ByVal pos As Integer(,), ByVal i As Integer, ByVal j As Integer)
        If i = j Then
            Console.Write("M" & pos(i, i) & " ")
        Else
            Console.Write("( ")
            PrintOptPar(n, pos, i, pos(i, j))
            PrintOptPar(n, pos, pos(i, j) + 1, j)
            Console.Write(") ")
        End If
    End Sub

    Sub PrintOptimalParenthesis(ByVal n As Integer, ByVal pos As Integer(,))
        Console.Write("OptimalParenthesis : ")
        PrintOptPar(n, pos, 1, n - 1)
        Console.WriteLine()
    End Sub

    Function MatrixChainMulBU2(ByVal p As Integer(), ByVal n As Integer) As Integer
        Dim dp As Integer(,) = New Integer(n - 1, n - 1) {}
        Dim pos As Integer(,) = New Integer(n - 1, n - 1) {}

        For i As Integer = 0 To n - 1
            For j As Integer = 0 To n - 1
                dp(i, j) = Integer.MaxValue
            Next
            dp(i, i) = 0
            pos(i, i) = i
        Next

        For l As Integer = 1 To n - 1
            Dim i As Integer = 1, j As Integer = i + l
            While j < n
                For k As Integer = i To j - 1
                    dp(i, j) = Math.Min(dp(i, j), dp(i, k) + p(i - 1) * p(k) * p(j) + dp(k + 1, j))
                    pos(i, j) = k
                Next
                i += 1
                j += 1
            End While
        Next
        PrintOptimalParenthesis(n, pos)
        Return dp(1, n - 1)
    End Function

    ' Testing Code.
    Sub Main(ByVal args As String())
        Dim arr As Integer() = New Integer() {1, 2, 3, 4}
        Dim n As Integer = arr.Length
        Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulBruteForce(arr, n))
        Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulTD(arr, n))
        Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulBU(arr, n))
        Console.WriteLine("Matrix Chain Multiplication is: " & MatrixChainMulBU2(arr, n))
    End Sub
End Module

' Matrix Chain Multiplication is: 18
' Matrix Chain Multiplication is: 18
' Matrix Chain Multiplication is: 18
' OptimalParenthesis : ( ( M1 M2 ) M3 ) 
' Matrix Chain Multiplication is: 18

