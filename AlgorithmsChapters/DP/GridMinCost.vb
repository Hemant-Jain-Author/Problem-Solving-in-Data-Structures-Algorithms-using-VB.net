Imports System

Public Module GridMinCost
	Function Min(ByVal x As Integer, ByVal y As Integer, ByVal z As Integer) As Integer
		x = Math.Min(x, y)
		Return Math.Min(x, z)
	End Function

	Function MinCost(ByVal cost(,) As Integer, ByVal m As Integer, ByVal n As Integer) As Integer
		If m = 0 Or n = 0 Then
			Return 99999
		End If

		If m = 1 AndAlso n = 1 Then
			Return cost(0, 0)
		End If

		Return cost(m - 1, n - 1) + Min(MinCost(cost, m - 1, n - 1), MinCost(cost, m - 1, n), MinCost(cost, m, n - 1))
	End Function

    Function MinCostBU(ByVal cost(,) As Integer, ByVal m As Integer, ByVal n As Integer) As Integer
        Dim tc(m - 1, n - 1) As Integer
        tc(0, 0) = cost(0, 0)

        ' Initialize first column.
        For i As Integer = 1 To m - 1
            tc(i, 0) = tc(i - 1, 0) + cost(i, 0)
        Next i
        ' Initialize first row.
        For j As Integer = 1 To n - 1
            tc(0, j) = tc(0, j - 1) + cost(0, j)
        Next j

        For i As Integer = 1 To m - 1
            For j As Integer = 1 To n - 1
                tc(i, j) = cost(i, j) + Min(tc(i - 1, j - 1), tc(i - 1, j), tc(i, j - 1))
            Next j
        Next i
        Return tc(m - 1, n - 1)
    End Function

    ' Testing code.
    Sub Main(ByVal args() As String)
        Dim cost(,) As Integer = {{1, 3, 4},{4, 7, 5},{1, 5, 3}}
        Console.WriteLine(MinCost(cost, 3, 3))
        Console.WriteLine(MinCostBU(cost, 3, 3))
    End Sub
End Module

'
'11
'11
'