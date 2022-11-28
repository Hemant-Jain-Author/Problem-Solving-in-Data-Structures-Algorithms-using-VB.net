Imports System

Public Module Fibo
    Function Fibonacci(ByVal n As Integer) As Integer
        If n < 2 Then
            Return n
        End If
        Return Fibonacci(n - 1) + Fibonacci(n - 2)
    End Function

    Function FibonacciBU2(ByVal n As Integer) As Integer
        If n < 2 Then
            Return n
        End If

        Dim first As Integer = 0, second As Integer = 1
        Dim temp As Integer = 0

        For i As Integer = 2 To n
            temp = first + second
            first = second
            second = temp
        Next

        Return temp
    End Function

    Function FibonacciBU(ByVal n As Integer) As Integer
        If n < 2 Then
            Return n
        End If

        Dim dp As Integer() = New Integer(n + 1 - 1) {}
        dp(0) = 0
        dp(1) = 1

        For i As Integer = 2 To n
            dp(i) = dp(i - 2) + dp(i - 1)
        Next

        Return dp(n)
    End Function


    Function FibonacciTD(ByVal n As Integer) As Integer
        Dim dp As Integer() = New Integer(n + 1 - 1) {}
        FibonacciTD(n, dp)
        Return dp(n)
    End Function

    Function FibonacciTD(ByVal n As Integer, ByVal dp As Integer()) As Integer
        If n < 2 Then

        dp(n) = n
            Return dp(n)
        End If

        If dp(n) <> 0 Then Return dp(n)
        dp(n) = FibonacciTD(n - 1, dp) + FibonacciTD(n - 2, dp)
        Return dp(n)
    End Function

    ' Testing code.
	Sub Main(ByVal args As String())
        Console.WriteLine(Fibonacci(10))
        Console.WriteLine(FibonacciBU2(10))
        Console.WriteLine(FibonacciBU(10))
        Console.WriteLine(FibonacciTD(10))
    End Sub
End Module

' 55
' 55
' 55
' 55