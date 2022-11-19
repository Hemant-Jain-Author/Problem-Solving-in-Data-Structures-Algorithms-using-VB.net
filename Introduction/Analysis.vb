Imports System

Public Module Program
Function Fun1(ByVal n As Integer) As Integer
    Dim m As Integer = 0
    For i As Integer = 0 To n - 1
        m += 1
    Next
    Return m
End Function

Function Fun2(ByVal n As Integer) As Integer
    Dim i, j As Integer, m As Integer = 0
    For i = 0 To n - 1
        For j = 0 To n - 1
            m += 1
        Next
    Next
    Return m
End Function

Function Fun3(ByVal n As Integer) As Integer
    Dim i, j, k As Integer, m As Integer = 0
    For i = 0 To n - 1
        For j = 0 To n - 1
            For k = 0 To n - 1
                m += 1
            Next
        Next
    Next
    Return m
End Function

Function Fun4(ByVal n As Integer) As Integer
    Dim i, j, k As Integer, m As Integer = 0
    For i = 0 To n - 1
        For j = i To n - 1
            For k = j + 1 To n - 1
                m += 1
            Next
        Next
    Next
    Return m
End Function

Function Fun5(ByVal n As Integer) As Integer
    Dim i, j As Integer, m As Integer = 0
    For i = 1 To n
        For j = 0 To i - 1
            m += 1
        Next
    Next
    Return m
End Function

Function Fun6(ByVal n As Integer) As Integer
    Dim i, j As Integer, m As Integer = 0
    For i = 0 To n - 1
        For j = i To 0 Step -1
            m += 1
        Next
    Next
    Return m
End Function

Function Fun7(ByVal n As Integer) As Integer
    Dim i As Integer = n, j As Integer, m As Integer = 0
    While i > 0
        For j = 0 To i - 1
            m += 1
        Next j
        i \= 2
    End While
    Return m
End Function

Function Fun8(ByVal n As Integer) As Integer
    Dim i As Integer = 1, j As Integer = 0, m As Integer = 0
    While i <= n
        For j = 0 To i
            m += 1
        Next j
        i *= 2
    End While
    Return m
End Function

Function Fun9(ByVal n As Integer) As Integer
    Dim i As Integer = 1, m As Integer = 0
    While i < n
        m += 1
        i = i * 2
    End While
    Return m
End Function

Function Fun10(ByVal n As Integer) As Integer
    Dim i As Integer = n, m As Integer = 0
    While i > 0
        m += 1
        i = i / 2
    End While
    Return m
End Function

Function Fun11(ByVal n As Integer) As Integer
    Dim i, j, k As Integer, m As Integer = 0
    For i = 0 To n - 1
        For j = 0 To n - 1
            m += 1
        Next
    Next

    For i = 0 To n - 1
        For k = 0 To n - 1
            m += 1
        Next
    Next
    Return m
End Function

Function Fun12(ByVal n As Integer) As Integer
    Dim i, j As Integer, m As Integer = 0
    For i = 0 To n - 1
        For j = 0 To Math.Sqrt(n) - 1
            m += 1
        Next
    Next
    Return m
End Function

Function Fun13(ByVal n As Integer) As Integer
    Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
    For i = 0 To n - 1
        While j < n
            m += 1
            j += 1
        End While
    Next
    Return m
End Function

Sub Main()
    Console.WriteLine("N = 100, Number of instructions in O(n)::" & Fun1(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & Fun2(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^3)::" & Fun3(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^3)::" & Fun4(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & Fun5(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & Fun6(100))
    Console.WriteLine("N = 100, Number of instructions in O(n)::" & Fun7(100))
    Console.WriteLine("N = 100, Number of instructions in O(n)::" & Fun8(100))
    Console.WriteLine("N = 100, Number of instructions in O(log(n))::" & Fun9(100))
    Console.WriteLine("N = 100, Number of instructions in O(log(n))::" & Fun10(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & Fun11(100))
    Console.WriteLine("N = 100, Number of instructions in O(n^(3/2))::" & Fun12(100))
    Console.WriteLine("N = 100, Number of instructions in O(n)::" & Fun13(100))
End Sub
End Module



' N = 100, Number of instructions in O(n)::100
' N = 100, Number of instructions in O(n^2)::10000
' N = 100, Number of instructions in O(n^3)::1000000
' N = 100, Number of instructions in O(n^3)::166650
' N = 100, Number of instructions in O(n^2)::5050
' N = 100, Number of instructions in O(n^2)::5050
' N = 100, Number of instructions in O(n)::197
' N = 100, Number of instructions in O(n)::134
' N = 100, Number of instructions in O(log(n))::7
' N = 100, Number of instructions in O(log(n))::8
' N = 100, Number of instructions in O(n^2)::20000
' N = 100, Number of instructions in O(n^(3/2))::1000
' N = 100, Number of instructions in O(n)::100
'