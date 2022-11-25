Imports System

Public Module NutsAndBolts
    Sub PrintArray(ByVal arr As Integer())
        Console.Write("[ ")
        For Each i As Integer In arr
            Console.Write(i & " ")
        Next
        Console.WriteLine("]")
    End Sub

    Sub MakePairs(ByVal nuts As Integer(), ByVal bolts As Integer())
        MakePairs(nuts, bolts, 0, nuts.Length - 1)
        Console.WriteLine("Matched nuts and bolts are : ")
        PrintArray(nuts)
        PrintArray(bolts)
    End Sub

    Sub MakePairs(ByVal nuts As Integer(), ByVal bolts As Integer(), ByVal low As Integer, ByVal high As Integer)
        If low < high Then
            Dim pivot As Integer = Partition(nuts, low, high, bolts(low))
            Partition(bolts, low, high, nuts(pivot))
            MakePairs(nuts, bolts, low, pivot - 1)
            MakePairs(nuts, bolts, pivot + 1, high)
        End If
    End Sub

    Sub Swap(ByVal arr As Integer(), ByVal first As Integer, ByVal second As Integer)
        Dim temp As Integer = arr(first)
        arr(first) = arr(second)
        arr(second) = temp
    End Sub

    Function Partition(ByVal arr As Integer(), ByVal low As Integer, ByVal high As Integer, ByVal pivot As Integer) As Integer
        Dim i As Integer = low

        For j As Integer = low To high - 1

            If arr(j) < pivot Then
                Swap(arr, i, j)
                i += 1
            ElseIf arr(j) = pivot Then
                Swap(arr, high, j)
                j -= 1
            End If
        Next

        Swap(arr, i, high)
        Return i
    End Function

    Sub Main(ByVal args As String())
        Dim nuts As Integer() = New Integer() {1, 2, 6, 5, 4, 3}
        Dim bolts As Integer() = New Integer() {6, 4, 5, 1, 3, 2}
        MakePairs(nuts, bolts)
    End Sub
End Module

' Matched nuts and bolts are : 
' [ 1 2 3 4 5 6 ]
' [ 1 2 3 4 5 6 ]