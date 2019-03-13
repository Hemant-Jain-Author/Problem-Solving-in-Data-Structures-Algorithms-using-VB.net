Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Module Module1

    Public Sub printArray(ByVal arr() As Integer, ByVal count As Integer)
        Console.Write("[")
        For i As Integer = 0 To count - 1
            Console.Write(" " & arr(i))
        Next i
        Console.Write(" ]" & ControlChars.Lf)
    End Sub

    Public Sub swap(ByVal arr() As Integer, ByVal x As Integer, ByVal y As Integer)
        Dim temp As Integer = arr(x)
        arr(x) = arr(y)
        arr(y) = temp
        Return
    End Sub

    Public Function Partition01(ByVal arr() As Integer, ByVal size As Integer) As Integer
        Dim left As Integer = 0
        Dim right As Integer = size - 1
        Dim count As Integer = 0
        Do While left < right
            Do While arr(left) = 0
                left += 1
            Loop

            Do While arr(right) = 1
                right -= 1
            Loop

            If left < right Then
                swap(arr, left, right)
                count += 1
            End If
        Loop
        Return count
    End Function

    Public Sub Partition012(ByVal arr() As Integer, ByVal size As Integer)
        Dim left As Integer = 0
        Dim right As Integer = size - 1
        Dim i As Integer = 0
        Do While i <= right
            If arr(i) = 0 Then
                swap(arr, i, left)
                i += 1
                left += 1
            ElseIf arr(i) = 2 Then
                swap(arr, i, right)
                right -= 1
            Else
                i += 1
            End If
        Loop
    End Sub

    ' Testing code
    Public Sub main1()
        Dim arr() As Integer = {0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1}
        Partition01(arr, arr.Length)
        printArray(arr, arr.Length)
        Dim arr2() As Integer = {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1}
        Partition012(arr2, arr2.Length)
        printArray(arr2, arr2.Length)
    End Sub

    Public Sub RangePartition(ByVal arr() As Integer, ByVal size As Integer, ByVal lower As Integer, ByVal higher As Integer)
        Dim start As Integer = 0
        Dim [end] As Integer = size - 1
        Dim i As Integer = 0
        Do While i <= [end]
            If arr(i) < lower Then
                swap(arr, i, start)
                i += 1
                start += 1
            ElseIf arr(i) > higher Then
                swap(arr, i, [end])
                [end] -= 1
            Else
                i += 1
            End If
        Loop
    End Sub

    ' Testing code
    Public Sub main2()
        Dim arr() As Integer = {1, 21, 2, 20, 3, 19, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11}
        RangePartition(arr, arr.Length, 9, 12)
        printArray(arr, arr.Length)
    End Sub

    Public Function minSwaps(ByVal arr() As Integer, ByVal size As Integer, ByVal val As Integer) As Integer
        Dim swapCount As Integer = 0
        Dim first As Integer = 0
        Dim second As Integer = size - 1
        Dim temp As Integer
        Do While first < second
            If arr(first) <= val Then
                first += 1
            ElseIf arr(second) > val Then
                second -= 1
            Else
                temp = arr(first)
                arr(first) = arr(second)
                arr(second) = temp
                swapCount += 1
            End If
        Loop
        Return swapCount
    End Function

    Public Sub seperateEvenAndOdd(ByVal data() As Integer, ByVal size As Integer)
        Dim left As Integer = 0, right As Integer = size - 1
        Do While left < right
            If data(left) Mod 2 = 0 Then
                left += 1
            ElseIf data(right) Mod 2 = 1 Then
                right -= 1
            Else
                swap(data, left, right)
                left += 1
                right -= 1
            End If
        Loop
    End Sub

    Public Function AbsMore(ByVal value1 As Integer, ByVal value2 As Integer, ByVal reference As Integer) As Boolean
        Return (Math.Abs(value1 - reference) > Math.Abs(value2 - reference))
    End Function

    Public Sub AbsBubbleSort(ByVal arr() As Integer, ByVal size As Integer, ByVal reference As Integer)
        Dim i As Integer = 0
        Do While i < (size - 1)
            Dim j As Integer = 0
            Do While j < (size - i - 1)
                If AbsMore(arr(j), arr(j + 1), reference) Then
                    swap(arr, j, j + 1)
                End If
                j += 1
            Loop
            i += 1
        Loop
    End Sub

    ' Testing code
    Public Sub main3()
        Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
        Dim reference As Integer = 5
        AbsBubbleSort(array, array.Length, reference)
        printArray(array, array.Length)
    End Sub

    Public Function EqMore(ByVal value1 As Integer, ByVal value2 As Integer, ByVal A As Integer) As Boolean
        value1 = A * value1 * value1
        value2 = A * value2 * value2
        Return value1 > value2
    End Function

    '	

    Public Sub SortByOrder(ByVal arr() As Integer, ByVal size As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
        Dim ht As New Dictionary(Of Integer, Integer)()
        Dim value As Integer
        For i As Integer = 0 To size - 1
            If ht.ContainsKey(arr(i)) Then
                value = ht(arr(i))
                ht(arr(i)) = value + 1
            Else
                ht(arr(i)) = 1
            End If
        Next i

        For j As Integer = 0 To size2 - 1
            If ht.ContainsKey(arr2(j)) Then
                value = ht(arr2(j))
                For k As Integer = 0 To value - 1
                    Console.Write(arr2(j))
                Next k
                ht.Remove(arr2(j))
            End If
        Next j

        For i As Integer = 0 To size - 1
            If ht.ContainsKey(arr(i)) Then
                value = ht(arr(i))
                For k As Integer = 0 To value - 1
                    Console.Write(arr(i))
                Next k
                ht.Remove(arr(i))
            End If
        Next i
    End Sub

    ' Testing code
    Public Sub main4()
        Dim arr() As Integer = {2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8}
        Dim arr2() As Integer = {2, 1, 8, 3}
        SortByOrder(arr, arr.Length, arr2, arr2.Length)
    End Sub

    Public Sub ArrayReduction(ByVal arr() As Integer, ByVal size As Integer)

        Array.Sort(arr)
        Dim count As Integer = 1
        Dim reduction As Integer = arr(0)

        For i As Integer = 0 To size - 1
            If arr(i) - reduction > 0 Then
                Console.WriteLine(size - i)
                reduction = arr(i)
                count += 1
            End If
        Next i
        Console.WriteLine("Total number of reductions " & count)
    End Sub

    ' Testing code
    Public Sub main5()
        Dim arr() As Integer = {5, 1, 1, 1, 2, 3, 5}
        ArrayReduction(arr, arr.Length)
    End Sub

    Public Sub merge(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
        Dim index As Integer = 0
        Dim temp As Integer = 0
        Do While index < size1
            If arr1(index) <= arr2(0) Then
                index += 1
            Else
                ' always first element of arr2 is compared.
                temp = arr1(index)
                arr1(index) = arr2(0)
                arr2(0) = temp
                index += 1
                ' After swap arr2 may be unsorted.
                ' Insertion of the element in proper sorted position.
                Dim i As Integer = 0
                Do While i < (size2 - 1)
                    If arr2(i) < arr2(i + 1) Then
                        Exit Do
                    End If
                    temp = arr2(i)
                    arr2(i) = arr2(i + 1)
                    arr2(i + 1) = temp
                    arr2(i) = arr2(i) Xor arr2(i + 1)
                    i += 1
                Loop
            End If
        Loop
    End Sub

    ' Testing code.
    Public Sub main6()
        Dim arr1() As Integer = {1, 5, 9, 10, 15, 20}
        Dim arr2() As Integer = {2, 3, 8, 13}
        merge(arr1, arr1.Length, arr2, arr2.Length)
        printArray(arr1, arr1.Length)
        printArray(arr2, arr2.Length)
    End Sub

    Public Function checkReverse(ByVal arr() As Integer, ByVal size As Integer) As Boolean
        Dim start As Integer = -1
        Dim [stop] As Integer = -1
        Dim i As Integer = 0
        Do While i < (size - 1)
            If arr(i) > arr(i + 1) Then
                start = i
                Exit Do
            End If
            i += 1
        Loop

        If start = -1 Then
            Return True
        End If

        i = start
        Do While i < (size - 1)
            If arr(i) < arr(i + 1) Then
                [stop] = i
                Exit Do
            End If
            i += 1
        Loop

        If [stop] = -1 Then
            Return True
        End If

        ' increasing property
        ' after reversal the sub array should fit in the array.
        If arr(start - 1) > arr([stop]) OrElse arr([stop] + 1) < arr(start) Then
            Return False
        End If

        i = [stop] + 1
        Do While i < size - 1
            If arr(i) > arr(i + 1) Then
                Return False
            End If
            i += 1
        Loop
        Return True
    End Function

    Public Function min(ByVal X As Integer, ByVal Y As Integer) As Integer
        If X < Y Then
            Return X
        End If
        Return Y
    End Function

    Public Sub UnionIntersectionSorted(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
        Dim first As Integer = 0, second As Integer = 0
        Dim unionArr((size1 + size2) - 1) As Integer
        Dim interArr(min(size1, size2) - 1) As Integer
        Dim uIndex As Integer = 0
        Dim iIndex As Integer = 0

        Do While first < size1 AndAlso second < size2
            If arr1(first) = arr2(second) Then
                unionArr(uIndex) = arr1(first)
                uIndex += 1
                interArr(iIndex) = arr1(first)
                iIndex += 1
                first += 1
                second += 1
            ElseIf arr1(first) < arr2(second) Then
                unionArr(uIndex) = arr1(first)
                uIndex += 1
                first += 1
            Else
                unionArr(uIndex) = arr2(second)
                uIndex += 1
                second += 1
            End If
        Loop

        Do While first < size1
            unionArr(uIndex) = arr1(first)
            uIndex += 1
            first += 1
        Loop

        Do While second < size2
            unionArr(uIndex) = arr2(second)
            uIndex += 1
            second += 1
        Loop
        printArray(unionArr, uIndex)
        printArray(interArr, iIndex)
    End Sub

    Public Sub UnionIntersectionUnsorted(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
        Array.Sort(arr1)
        Array.Sort(arr2)
        UnionIntersectionSorted(arr1, size1, arr2, size2)
    End Sub

    Public Sub main7()
        Dim arr1() As Integer = {1, 11, 2, 3, 14, 5, 6, 8, 9}
        Dim arr2() As Integer = {2, 4, 5, 12, 7, 8, 13, 10}
        UnionIntersectionUnsorted(arr1, arr1.Length, arr2, arr2.Length)
    End Sub

    Public Sub Main()
        main1()
        main2()
        main3()
        main4()
        main5()
        main6()
        main7()
    End Sub
End Module