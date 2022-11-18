﻿Imports System

Public Class Permutations
    Private Shared Sub PrintArray(ByVal arr As Integer(), ByVal n As Integer)
        For i As Integer = 0 To n - 1
            Console.Write(arr(i) & " ")
        Next

        Console.WriteLine()
    End Sub

    Private Shared Sub Swap(ByVal arr As Integer(), ByVal i As Integer, ByVal j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub

    Public Shared Sub Permutation(ByVal arr As Integer(), ByVal i As Integer, ByVal length As Integer)
        If length = i Then
            PrintArray(arr, length)
            Return
        End If

        For j As Integer = i To length - 1
            Swap(arr, i, j)
            Permutation(arr, i + 1, length)
            Swap(arr, i, j)
        Next

        Return
    End Sub

	'
	'1 2 3 4 
	'1 2 4 3 
	'.....
	'4 1 3 2 
	'4 1 2 3 
	'

    Private Shared Function IsValid(ByVal arr As Integer(), ByVal n As Integer) As Boolean
        For j As Integer = 1 To n - 1

            If Math.Abs(arr(j) - arr(j - 1)) < 2 Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Sub Permutation2(ByVal arr As Integer(), ByVal i As Integer, ByVal length As Integer)
        If length = i Then

            If IsValid(arr, length) Then
                PrintArray(arr, length)
            End If

            Return
        End If

        For j As Integer = i To length - 1
            Swap(arr, i, j)
            Permutation2(arr, i + 1, length)
            Swap(arr, i, j)
        Next

        Return
    End Sub

	'2 4 1 3 
	'3 1 4 2

    Private Shared Function IsValid2(ByVal arr As Integer(), ByVal i As Integer) As Boolean
        If i < 1 OrElse Math.Abs(arr(i) - arr(i - 1)) >= 2 Then
            Return True
        End If

        Return False
    End Function

    Public Shared Sub Permutation3(ByVal arr As Integer(), ByVal i As Integer, ByVal length As Integer)
        If length = i Then
            PrintArray(arr, length)
            Return
        End If

        For j As Integer = i To length - 1
            Swap(arr, i, j)

            If IsValid2(arr, i) Then
                Permutation3(arr, i + 1, length)
            End If

            Swap(arr, i, j)
        Next

        Return
    End Sub

	'2 4 1 3 
	'3 1 4 2

    Public Shared Sub Main(ByVal args As String())
        Dim arr As Integer() = {1, 2, 3, 4}
        Permutation(arr, 0, 4)
        Console.WriteLine()
        Permutation2(arr, 0, 4)
        Console.WriteLine()
        Permutation3(arr, 0, 4)
    End Sub
End Class
