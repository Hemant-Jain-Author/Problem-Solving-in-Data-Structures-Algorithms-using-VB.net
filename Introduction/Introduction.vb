﻿
Imports System
Imports System.Collections.Generic

Public Module Program

    Sub PrintArray(ByVal arr() As Integer, ByVal count As Integer)
        Console.Write("[")
        For i As Integer = 0 To count - 1
            Console.Write(" " & arr(i))
        Next i
        Console.WriteLine(" ]")
    End Sub

    Sub Swap(ByVal arr() As Integer, ByVal x As Integer, ByVal y As Integer)
        Dim temp As Integer = arr(x)
        arr(x) = arr(y)
        arr(y) = temp
        Return
    End Sub

    Function SumArray(ByVal arr() As Integer) As Integer
        Dim size As Integer = arr.Length
        Dim total As Integer = 0
        For index As Integer = 0 To size - 1
            total = total + arr(index)
        Next index
        Return total
    End Function

    ' Testing code
    Sub Main1()
        Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
        Console.WriteLine("Sum of values in array:" & SumArray(arr))
    End Sub
    '
    '	Sum of values in array:45
    '

    Public Sub Function2()
        Console.WriteLine("Fun2 line 1")
    End Sub

    Public Sub Function1()
        Console.WriteLine("Fun1 line 1")
        Function2()
        Console.WriteLine("Fun1 line 2")
    End Sub

    ' Testing code
    Public Sub Main2()
        Console.WriteLine("Main line 1")
        Function1()
        Console.WriteLine("Main line 2")
    End Sub
    '
    '	Main line 1
    '	Fun1 line 1
    '	Fun2 line 1
    '	Fun1 line 2
    '	Main line 2
    '
    Function SequentialSearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
        For i As Integer = 0 To size - 1
            If value = arr(i) Then
                If True Then
                    Return i
                End If
            End If
        Next i
        Return -1
    End Function

    Function BinarySearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
        Dim mid As Integer
        Dim low As Integer = 0
        Dim high As Integer = size - 1
        While low <= high
            mid = (low + high) \ 2
            If arr(mid) = value Then
                Return mid
            Else
                If arr(mid) < value Then
                    low = mid + 1
                Else
                    high = mid - 1
                End If
            End If
        End While
        Return -1
    End Function

    Sub Main3()
        Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
        Console.WriteLine("SequentialSearch:" & SequentialSearch(arr, arr.Length, 7))
        Console.WriteLine("BinarySearch:" & BinarySearch(arr, arr.Length, 7))
    End Sub
    '
    '	SequentialSearch:6
    '	BinarySearch:6
    '

    Function MaxSubArraySum(ByVal a() As Integer, ByVal size As Integer) As Integer
        Dim maxSoFar As Integer = 0, maxEndingHere As Integer = 0

        For i As Integer = 0 To size - 1
            maxEndingHere = maxEndingHere + a(i)
            If maxEndingHere < 0 Then
                maxEndingHere = 0
            End If
            If maxSoFar < maxEndingHere Then
                maxSoFar = maxEndingHere
            End If
        Next i
        Return maxSoFar
    End Function

    ' Testing code
    Sub Main4()
        Dim arr() As Integer = {1, -2, 3, 4, -4, 6, -4, 3, 2}
        Console.WriteLine("Max sub array sum :" & MaxSubArraySum(arr, 9))
    End Sub
    '
    '	Max sub array sum :10
    '

        '
        Function SmallestPositiveMissingNumber(ByVal arr() As Integer, ByVal size As Integer) As Integer
            Dim found As Integer
            Dim i As Integer = 1
            While i < size + 1
                found = 0
                For j As Integer = 0 To size - 1
                    If arr(j) = i Then
                        found = 1
                        Exit For
                    End If
                Next j
                If found = 0 Then
                    Return i
                End If
                i += 1
            End While
            Return -1
        End Function

        Function SmallestPositiveMissingNumber2(ByVal arr() As Integer, ByVal size As Integer) As Integer
            Dim hs As New Dictionary(Of Integer, Integer)()
            For j As Integer = 0 To size - 1
                hs(arr(j)) = 1
            Next j
            Dim i As Integer = 1
            While i < size + 1
                If hs.ContainsKey(i) = False Then
                    Return i
                End If
                i += 1
            End While
            Return -1
        End Function

    Function SmallestPositiveMissingNumber3(ByVal arr() As Integer, ByVal size As Integer) As Integer
        Dim aux(size - 1) As Integer
        For i As Integer = 0 To size - 1
            aux(i)= -1
        Next i

        For i As Integer = 0 To size - 1
            If arr(i) > 0 AndAlso arr(i) <= size Then
                aux(arr(i) - 1) = arr(i)
            End If
        Next i
        For i As Integer = 0 To size - 1
            If aux(i) <> i + 1 Then
                Return i + 1
            End If
        Next i
        Return -1
    End Function


        Function SmallestPositiveMissingNumber4(ByVal arr() As Integer, ByVal size As Integer) As Integer
            Dim temp As Integer
            For i As Integer = 0 To size - 1
                While arr(i) <> i + 1 AndAlso arr(i) > 0 AndAlso arr(i) <= size
                    temp = arr(i)
                    arr(i) = arr(temp - 1)
                    arr(temp - 1) = temp
                End While
            Next i
            For i As Integer = 0 To size - 1
                If arr(i) <> i + 1 Then
                    Return i + 1
                End If
            Next i
            Return -1
        End Function

    ' Testing code
    Sub Main5()
        Dim arr() As Integer = {8, 5, 6, 1, 9, 11, 2, 7, 4, 10}
        Dim size As Integer = arr.Length

        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber(arr, size))
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber2(arr, size))
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber3(arr, size))
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber4(arr, size))
    End Sub

    '
    '	SmallestPositiveMissingNumber :3
    '	SmallestPositiveMissingNumber :3
    '	SmallestPositiveMissingNumber :3
    '	SmallestPositiveMissingNumber :3
    '

        Function ArrayIndexMaxDiff(ByVal arr() As Integer, ByVal size As Integer) As Integer
            Dim maxDiff As Integer = -1
            Dim j As Integer
            For i As Integer = 0 To size - 1
                j = size - 1
                While i < j
                    If arr(i) <= arr(j) Then
                        maxDiff = Math.Max(maxDiff, j - i)
                        Exit While
                    End If
                    j -= 1
                End While
            Next i
            Return maxDiff
        End Function

    Function ArrayIndexMaxDiff2(ByVal arr() As Integer, ByVal size As Integer) As Integer
        Dim rightMax(size - 1) As Integer
        rightMax(size - 1) = arr(size - 1)
        For k As Integer = size - 2 To 0 Step -1
            rightMax(k) = Math.Max(rightMax(k + 1), arr(k))
        Next k

            Dim maxDiff As Integer = -1
            Dim i As Integer = 0
            Dim j As Integer = 1
            While i < size AndAlso j < size
                If arr(i) <= rightMax(j) Then
                    If i < j Then
                        maxDiff = Math.Max(maxDiff, j - i)
                    End If
                    j = j + 1
                Else
                    i = i + 1
                End If
            End While
            Return maxDiff
        End Function

    ' Testing code
    Sub Main6()
        Dim arr() As Integer = {33, 9, 10, 3, 2, 60, 30, 33, 1} ' {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
        Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff(arr, arr.Length))
        Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff2(arr, arr.Length))
    End Sub
    '
    '	ArrayIndexMaxDiff : 7
    '	ArrayIndexMaxDiff : 7
    '

    Function MaxPathSum(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer) As Integer
        Dim i As Integer = 0, j As Integer = 0, result As Integer = 0, sum1 As Integer = 0, sum2 As Integer = 0

            While i < size1 AndAlso j < size2
                If arr1(i) < arr2(j) Then
                    sum1 += arr1(i)
                    i += 1
                ElseIf arr1(i) > arr2(j) Then
                    sum2 += arr2(j)
                    j += 1
                Else
                    result += Math.Max(sum1, sum2)
                    result = result + arr1(i)
                    sum1 = 0
                    sum2 = 0
                    i += 1
                    j += 1
                End If
            End While
            While i < size1
                sum1 += arr1(i)
                i += 1
            End While

            While j < size2
                sum2 += arr2(j)
                j += 1
            End While

        result += Math.Max(sum1, sum2)
        Return result
    End Function

    ' Testing code
    Sub Main7()
        Dim arr1() As Integer = {12, 13, 18, 20, 22, 26, 70}
        Dim arr2() As Integer = {11, 15, 18, 19, 20, 26, 30, 31}
        Console.WriteLine("Max Path Sum :: " & MaxPathSum(arr1, arr1.Length, arr2, arr2.Length))
    End Sub
    '
    '	Max Path Sum :: 201
    '
    Function Factorial(ByVal i As Integer) As Integer
        ' Termination Condition
        If i <= 1 Then
            Return 1
        End If
        ' Body, Recursive Expansion
        Return i * Factorial(i - 1)
    End Function

    ' Testing code
    Sub Main8()
        Console.WriteLine("Factorial:" & Factorial(5))
    End Sub

    ' Factorial:120

    Sub PrintInt10(ByVal number As Integer)
        Dim digit As Char = ChrW(number Mod 10 + AscW("0"c))
        number = number \ 10
        If number <> 0 Then
            PrintInt10(number)
        End If
        Console.Write(digit)
    End Sub


    Sub PrintInt(ByVal number As Integer, ByVal outputbase As Integer)
        Dim conversion As String = "0123456789ABCDEF"
        Dim digit As Char = ChrW(number Mod outputbase)
        number = number \ outputbase
        If number <> 0 Then
            PrintInt(number, outputbase)
        End If
        Console.Write(conversion.Chars(AscW(digit)))
    End Sub

    ' Testing code
    Sub Main9()
        PrintInt10(50)
        Console.WriteLine()
        PrintInt(500, 16)
        Console.WriteLine()
    End Sub
    '
    '	50
    '	1F4
    '


    Sub TowerOfHanoi(ByVal num As Integer, ByVal src As Char, ByVal dst As Char, ByVal temp As Char)
        If num < 1 Then
            Return
        End If

        TowerOfHanoi(num - 1, src, temp, dst)
        Console.WriteLine("Move " & num & " disk  from peg " & src & " to peg " & dst)
        TowerOfHanoi(num - 1, temp, dst, src)
    End Sub

    ' Testing code
    Sub Main10()
        Dim num As Integer = 3
        Console.WriteLine("Moves involved in the Tower of Hanoi are:")
        TowerOfHanoi(num, "A"c, "C"c, "B"c)
    End Sub
    '
    '	Moves involved in the Tower of Hanoi are:
    '	Move 1 disk  from peg A to peg C
    '	Move 2 disk  from peg A to peg B
    '	Move 1 disk  from peg C to peg B
    '	Move 3 disk  from peg A to peg C
    '	Move 1 disk  from peg B to peg A
    '	Move 2 disk  from peg B to peg C
    '	Move 1 disk  from peg A to peg C
    '
    Function GCD(ByVal m As Integer, ByVal n As Integer) As Integer
        If m < n Then
            Return (GCD(n, m))
        End If
        If m Mod n = 0 Then
            Return (n)
        End If
        Return (GCD(n, m Mod n))
    End Function

    ' Testing code
    Sub Main11()
        Console.WriteLine("GCD is:: " & GCD(5, 2))
    End Sub

    '
    '	GCD is:: 1
    '

    Function Fibonacci(ByVal n As Integer) As Integer
        If n <= 1 Then
            Return n
        End If
        Return Fibonacci(n - 1) + Fibonacci(n - 2)
    End Function

    ' Testing code
    Sub Main12()
        Console.WriteLine(Fibonacci(10) & " ")
    End Sub

    '
    '	55
    '

        Sub Permutation(ByVal arr() As Integer, ByVal i As Integer, ByVal length As Integer)
            If length = i Then
                PrintArray(arr, length)
                Return
            End If
            Dim j As Integer = i
            j = i
            While j < length
                Swap(arr, i, j)
                Permutation(arr, i + 1, length)
                Swap(arr, i, j)
                j += 1
            End While
            Return
        End Sub

    ' Testing code
    Sub Main13()
        Dim arr(2) As Integer
        For i As Integer = 0 To 2
            arr(i) = i
        Next i
        Permutation(arr, 0, 3)
    End Sub
    '
    '	[ 0 1 2 ]
    '	[ 0 2 1 ]
    '	[ 1 0 2 ]
    '	[ 1 2 0 ]
    '	[ 2 1 0 ]
    '	[ 2 0 1 ]
    '
    ' Binary Search Algorithm - Recursive
    Function BinarySearchRecursive(ByVal arr() As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Integer
        If low > high Then
            Return -1
        End If
        Dim mid As Integer = (low + high) \ 2
        If arr(mid) = value Then
            Return mid
        ElseIf arr(mid) < value Then
            Return BinarySearchRecursive(arr, mid + 1, high, value)
        Else
            Return BinarySearchRecursive(arr, low, mid - 1, value)
        End If
    End Function

    ' Testing code
    Sub Main14()
        Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
        Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 6))
        Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 16))
    End Sub
    '
    '	5
    '	-1
    '
    Sub Main(ByVal args() As String)
        Main1()
        Main2()
        Main3()
        Main4()
        Main5()
        Main6()
        Main7()
        Main8()
        Main9()
        Main10()
        Main11()
        Main12()
        Main13()
        Main14()
    End Sub
End Module


' Sum of values in array:45
' Main line 1
' Fun1 line 1
' Fun2 line 1
' Fun1 line 2
' Main line 2
' SequentialSearch:6
' BinarySearch:6
' [ 3 4 5 6 1 2 ]
' Max sub array sum :10
' [ 2 1 3 2 4 4 6 5 8 ]
' [ 8 1 3 2 5 4 6 2 4 ]
' [ -1 1 2 3 4 -1 6 7 8 9 ]
' [ -1 1 2 3 4 -1 6 7 8 9 ]
' [ 1 2 3 4 5 6 7 8 9 10 ]
' [ 1 2 3 4 5 6 7 8 9 10 ]
' SmallestPositiveMissingNumber :3
' SmallestPositiveMissingNumber :3
' SmallestPositiveMissingNumber :3
' SmallestPositiveMissingNumber :3
' [ 7 1 6 2 5 3 4 ]
' [ 7 1 6 2 5 3 4 ]
' MaxCircularSum: 290
' ArrayIndexMaxDiff : 7
' ArrayIndexMaxDiff : 7
' Max Path Sum :: 201
' Factorial:120
' 50
' 1F4
' Moves involved in the Tower of Hanoi are:
' Move 1 disk  from peg A to peg C
' Move 2 disk  from peg A to peg B
' Move 1 disk  from peg C to peg B
' Move 3 disk  from peg A to peg C
' Move 1 disk  from peg B to peg A
' Move 2 disk  from peg B to peg C
' Move 1 disk  from peg A to peg C
' GCD is:: 1
' 0 1 1 2 3 5 8 13 21 34 
' [ 0 1 2 ]
' [ 0 2 1 ]
' [ 1 0 2 ]
' [ 1 2 0 ]
' [ 2 1 0 ]
' [ 2 0 1 ]
' 5
' -1
' "