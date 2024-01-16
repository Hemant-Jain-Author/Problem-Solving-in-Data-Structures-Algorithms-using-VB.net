Imports System

Public Module TSP
    Function TSPPath(ByVal graph As Integer(,), ByVal n As Integer, ByVal path As Integer(), ByVal pSize As Integer, ByVal pCost As Integer, ByVal visited As Boolean(), ByVal ans As Integer, ByVal ansPath As Integer()) As Integer
        Dim curr As Integer = path(pSize - 1)

        If pSize = n Then

            If graph(curr, 0) > 0 AndAlso ans > pCost + graph(curr, 0) Then
                ans = pCost + graph(curr, 0)

                For i As Integer = 0 To n
                    ansPath(i) = path(i Mod n)
                Next
            End If

            Return ans
        End If

        For i As Integer = 0 To n - 1

            If visited(i) = False AndAlso graph(curr, i) > 0 Then
                visited(i) = True
                path(pSize) = i
                ans = TSPPath(graph, n, path, pSize + 1, pCost + graph(curr, i), visited, ans, ansPath)
                visited(i) = False
            End If
        Next

        Return ans
    End Function

    Function TSPPath(ByVal graph As Integer(,), ByVal n As Integer) As Integer
        Dim visited As Boolean() = New Boolean(n - 1) {}
        Dim path As Integer() = New Integer(n - 1) {}
        Dim ansPath As Integer() = New Integer(n + 1 - 1) {}
        path(0) = 0
        visited(0) = True
        Dim ans As Integer = Integer.MaxValue
        ans = TSPPath(graph, n, path, 1, 0, visited, ans, ansPath)
        Console.WriteLine("Path length : " & ans)
        Console.Write("Path : ")

        For i As Integer = 0 To n
            Console.Write(ansPath(i) & " ")
        Next

        Return ans
    End Function

    ' Testing code.
    Sub Main(ByVal args As String())
        Dim n As Integer = 4
        Dim graph As Integer(,) = New Integer(,) {
        {0, 10, 15, 20},
        {10, 0, 35, 25},
        {15, 35, 0, 30},
        {20, 25, 30, 0}}
        TSPPath(graph, n)
    End Sub
End Module

' Path length : 80
' Path : 0 1 3 2 0 
