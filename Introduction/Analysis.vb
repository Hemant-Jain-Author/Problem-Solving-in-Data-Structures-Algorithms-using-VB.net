Imports System

Imports Math

Module Module1
    Public Sub Main()
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun1(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun2(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun3(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun4(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun5(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun6(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun7(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun8(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun9(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun10(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun11(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun12(100))
        System.Console.WriteLine("N = 100, Number of instructions :: " & fun13(100))
    End Sub

    Private Function fun1(ByVal n As Integer) As Integer
        Dim m As Integer = 0
        For i As Integer = 0 To n - 1
            m += 1
        Next i
        Return m
    End Function

    Private Function fun2(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, m As Integer = 0
        For i = 0 To n - 1
            For j = 0 To n - 1
                m += 1
            Next j
        Next i
        Return m
    End Function

    Private Function fun3(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, m As Integer = 0
        For i = 0 To n - 1
            For j = 0 To i - 1
                m += 1
            Next j
        Next i
        Return m
    End Function

    Private Function fun4(ByVal n As Integer) As Integer
        Dim i As Integer, m As Integer = 0
        i = 1
        Do While i < n
            m += 1
            i = i * 2
        Loop
        Return m
    End Function

    Private Function fun5(ByVal n As Integer) As Integer
        Dim i As Integer, m As Integer = 0
        i = n
        Do While i > 0
            m += 1
            i = i \ 2
        Loop
        Return m
    End Function

    Private Function fun6(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, k As Integer, m As Integer = 0
        For i = 0 To n - 1
            For j = 0 To n - 1
                For k = 0 To n - 1
                    m += 1
                Next k
            Next j
        Next i
        Return m
    End Function

    Private Function fun7(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, k As Integer, m As Integer = 0
        For i = 0 To n - 1
            For j = 0 To n - 1
                m += 1
            Next j
        Next i
        For i = 0 To n - 1
            For k = 0 To n - 1
                m += 1
            Next k
        Next i
        Return m
    End Function

    Private Function fun8(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, m As Integer = 0
        i = 0
        Do While i < n
            j = 0
            Do While j < Math.Sqrt(n)
                m += 1
                j += 1
            Loop
            i += 1
        Loop
        Return m
    End Function

    Private Function fun9(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, m As Integer = 0
        i = n
        Do While i > 0
            For j = 0 To i - 1
                m += 1
            Next j
            i \= 2
        Loop
        Return m
    End Function

    Private Function fun10(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, m As Integer = 0
        For i = 0 To n - 1
            For j = i To 1 Step -1
                m += 1
            Next j
        Next i
        Return m
    End Function

    Private Function fun11(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer, k As Integer, m As Integer = 0
        For i = 0 To n - 1
            For j = i To n - 1
                For k = j + 1 To n - 1
                    m += 1
                Next k
            Next j
        Next i
        Return m
    End Function

    Private Function fun12(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer = 0, m As Integer = 0
        For i = 0 To n - 1
            Do While j < n
                m += 1
                j += 1
            Loop
        Next i
        Return m
    End Function

    Private Function fun13(ByVal n As Integer) As Integer
        Dim i As Integer, j As Integer = 0, m As Integer = 0
        i = 1
        Do While i <= n
            For j = 0 To i
                m += 1
            Next j
            i *= 2
        Loop
        Return m
    End Function

End Module
