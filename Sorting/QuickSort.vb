Imports System

Public Class QuickSort
    Private Sub SortUtil(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer)
        If upper <= lower Then
            Return
        End If
        Dim pivot As Integer = arr(lower)
        Dim start As Integer = lower
        Dim finish As Integer = upper

        While lower < upper
            While arr(lower) <= pivot AndAlso lower < upper
                lower += 1
            End While
            While arr(upper) > pivot AndAlso lower <= upper
                upper -= 1
            End While
            If lower < upper Then
                swap(arr, upper, lower)
            End If
        End While
        swap(arr, upper, start) ' upper is the pivot position
        SortUtil(arr, start, upper - 1) ' pivot -1 is the upper for left sub array.
        SortUtil(arr, upper + 1, finish) ' pivot + 1 is the lower for right sub array
    End Sub

    Public Sub sort(ByVal arr() As Integer)
        Dim size As Integer = arr.Length
        SortUtil(arr, 0, size - 1)
    End Sub

    Private Sub swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
        Dim temp As Integer = arr(first)
        arr(first) = arr(second)
        arr(second) = temp
    End Sub
End Class

Module Module1
    Public Sub Main(ByVal args() As String)
        Dim array() As Integer = {3, 4, 2, 1, 6, 5, 7, 8, 1, 1}
		Dim srt As New QuickSort()
		srt.Sort(array)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
    End Sub
End Module

' 1 1 1 2 3 4 5 6 7 8 