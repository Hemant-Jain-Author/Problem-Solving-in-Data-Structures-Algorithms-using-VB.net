Imports System

Public Class QuickSort
    Private Shared Sub quickSort(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer)
        If upper <= lower Then
            Return
        End If
        Dim pivot As Integer = arr(lower)
        Dim start As Integer = lower
        Dim [stop] As Integer = upper

        Do While lower < upper
            Do While arr(lower) <= pivot AndAlso lower < upper
                lower += 1
            Loop
            Do While arr(upper) > pivot AndAlso lower <= upper
                upper -= 1
            Loop
            If lower < upper Then
                swap(arr, upper, lower)
            End If
        Loop
        swap(arr, upper, start) ' upper is the pivot position
        quickSort(arr, start, upper - 1) ' pivot -1 is the upper for left sub array.
        quickSort(arr, upper + 1, [stop]) ' pivot + 1 is the lower for right sub array
    End Sub

    Public Shared Sub sort(ByVal arr() As Integer)
        Dim size As Integer = arr.Length
        quickSort(arr, 0, size - 1)
    End Sub

    Private Shared Sub swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
        Dim temp As Integer = arr(first)
        arr(first) = arr(second)
        arr(second) = temp
    End Sub
End Class

Module Module1
    Public Sub Main(ByVal args() As String)
        Dim array() As Integer = {3, 4, 2, 1, 6, 5, 7, 8, 1, 1}
        QuickSort.sort(array)
        For i As Integer = 0 To array.Length - 1
            Console.Write(array(i) & " ")
        Next i
    End Sub
End Module
