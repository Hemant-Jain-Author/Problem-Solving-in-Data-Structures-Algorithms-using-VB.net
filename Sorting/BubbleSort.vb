﻿Imports System

Public Class BubbleSort
Private Function Less(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
    Return value1 < value2
End Function

Private Function Greater(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
    Return value1 > value2
End Function

    Public Sub Sort(ByVal arr() As Integer)
        Dim size As Integer = arr.Length
        Dim i, j, temp As Integer
        i = 0
        Do While i < (size - 1)
            j = 0
            Do While j < size - i - 1
                If Greater(arr(j), arr(j + 1)) Then
                    ' Swapping
                    temp = arr(j)
                    arr(j) = arr(j + 1)
                    arr(j + 1) = temp
                End If
                j += 1
            Loop
            i += 1
        Loop
    End Sub

Public Sub Sort2(ByVal arr() As Integer)
    Dim size As Integer = arr.Length
    Dim i As Integer, j As Integer, temp As Integer, swapped As Integer = 1
    i = 0
    Do While i < (size - 1) AndAlso swapped = 1
        swapped = 0
        j = 0
        Do While j < size - i - 1
            If Greater(arr(j), arr(j + 1)) Then
                temp = arr(j)
                arr(j) = arr(j + 1)
                arr(j + 1) = temp
                swapped = 1
            End If
            j += 1
        Loop
        i += 1
    Loop
End Sub

    Public Shared Sub Main(ByVal args() As String)
        Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
        Dim b As New BubbleSort()
        b.Sort(array)
        For i As Integer = 0 To array.Length - 1
            Console.Write(array(i) & " ")
        Next i
        Console.WriteLine()
        Dim array2() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
        b = New BubbleSort()
        b.Sort2(array2)
        For i As Integer = 0 To array2.Length - 1
            Console.Write(array2(i) & " ")
        Next i
    End Sub
End Class
'
'1 2 3 4 5 6 7 8 9 
'1 2 3 4 5 6 7 8 9
'