Imports System

Public Class SelectionSort
    Private Function more(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
        Return value1 > value2
    End Function

    Public Shared Sub sort(ByVal arr() As Integer) ' sorted array created from back.
        Dim size As Integer = arr.Length
        Dim i, j, max, temp As Integer
        i = 0
        Do While i < size - 1
            max = 0
            j = 1
            Do While j < size - 1 - i
                If arr(j) > arr(max) Then
                    max = j
                End If
                j += 1
            Loop
            temp = arr(size - 1 - i)
            arr(size - 1 - i) = arr(max)
            arr(max) = temp
            i += 1
        Loop
    End Sub

    Public Shared Sub sort2(ByVal arr() As Integer) ' sorted array created from front
        Dim size As Integer = arr.Length
        Dim i, j, min, temp As Integer
        i = 0
        Do While i < size - 1
            min = i
            For j = i + 1 To size - 1
                If arr(j) < arr(min) Then
                    min = j
                End If
            Next j
            temp = arr(i)
            arr(i) = arr(min)
            arr(min) = temp
            i += 1
        Loop
    End Sub

End Class


Module Module1
    Public Sub Main(ByVal args() As String)
        Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
        SelectionSort.sort(array)
        For i As Integer = 0 To array.Length - 1
            Console.Write(array(i) & " ")
        Next i
        Console.WriteLine()
        Dim array2() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
        SelectionSort.sort2(array2)
        For i As Integer = 0 To array2.Length - 1
            Console.Write(array2(i) & " ")
        Next i
    End Sub
End Module
