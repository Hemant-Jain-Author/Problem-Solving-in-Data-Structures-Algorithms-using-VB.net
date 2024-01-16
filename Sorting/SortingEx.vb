
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

Function Partition01(ByVal arr() As Integer, ByVal size As Integer) As Integer
    Dim left As Integer = 0
    Dim right As Integer = size - 1
    Dim count As Integer = 0
    While left < right
        While arr(left) = 0
            left += 1
        End While

        While arr(right) = 1
            right -= 1
        End While

        If left < right Then
            Swap(arr, left, right)
            count += 1
        End If
    End While
    Return count
End Function

Sub Partition012_(ByVal arr() As Integer, ByVal size As Integer)
    Dim zero As Integer = 0, one As Integer = 0, two As Integer = 0

    For i As Integer = 0 To size - 1
        If arr(i) = 0 Then
            zero += 1
        ElseIf arr(i) = 1 Then
            one += 1
        Else
            two += 1
        End If
    Next i
    Dim index As Integer = 0
    While zero > 0
        arr(index) = 0
        index += 1
        zero -= 1
    End While
    While one > 0
        arr(index) = 1
        index += 1
        one -= 1
    End While
    While two > 0
        arr(index) = 2
        index += 1
        two -= 1
    End While
End Sub

Sub Partition012(ByVal arr() As Integer, ByVal size As Integer)
    Dim left As Integer = 0
    Dim right As Integer = size - 1
    Dim i As Integer = 0
    While i <= right
        If arr(i) = 0 Then
            Swap(arr, i, left)
            i += 1
            left += 1
        ElseIf arr(i) = 2 Then
            Swap(arr, i, right)
            right -= 1
        Else
            i += 1
        End If
    End While
End Sub

' Testing code
Sub Main1()
    Dim arr() As Integer = {0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1}
    Partition01(arr, arr.Length)
    PrintArray(arr, arr.Length)

    Dim arr2() As Integer = {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1}
    Partition012(arr2, arr2.Length)
    PrintArray(arr2, arr2.Length)

    Dim arr3() As Integer = {0, 1, 1, 0, 1, 2, 1, 2, 0, 0, 0, 1}
    Partition012_(arr3, arr3.Length)
    PrintArray(arr3, arr3.Length)
End Sub
'
'[ 0 0 0 0 0 0 1 1 1 1 1 1 ]
'[ 0 0 0 0 0 1 1 1 1 1 2 2 ]
'
Sub RangePartition(ByVal arr() As Integer, ByVal size As Integer, ByVal lower As Integer, ByVal higher As Integer)
    Dim start As Integer = 0
    Dim [end] As Integer = size - 1
    Dim i As Integer = 0
    While i <= [end]
        If arr(i) < lower Then
            Swap(arr, i, start)
            i += 1
            start += 1
        ElseIf arr(i) > higher Then
            Swap(arr, i, [end])
            [end] -= 1
        Else
            i += 1
        End If
    End While
End Sub

' Testing code
Sub Main2()
    Dim arr() As Integer = {1, 2, 3, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11}
    RangePartition(arr, arr.Length, 9, 12)
    PrintArray(arr, arr.Length)
End Sub
'
'[ 1 2 3 4 5 6 7 8 10 12 9 11 14 13 15 16 17 18 ]
'

Function MinSwaps(ByVal arr() As Integer, ByVal size As Integer, ByVal val As Integer) As Integer
    Dim SwapCount As Integer = 0
    Dim first As Integer = 0
    Dim second As Integer = size - 1
    Dim temp As Integer
    While first < second
        If arr(first) <= val Then
            first += 1
        ElseIf arr(second) > val Then
            second -= 1
        Else
            temp = arr(first)
            arr(first) = arr(second)
            arr(second) = temp
            SwapCount += 1
        End If
    End While
    Return SwapCount
End Function

'Testing code
Sub Main3()
    Dim array() As Integer = {1, 2, 3, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11}
    Console.WriteLine("MinSwaps " & MinSwaps(array, array.Length, 10))
End Sub

' MinSwaps 3

Sub SeparateEvenAndOdd(ByVal data() As Integer, ByVal size As Integer)
    Dim left As Integer = 0, right As Integer = size - 1
    Dim aux(size - 1) As Integer

    For i As Integer = 0 To size - 1
        If data(i) Mod 2 = 0 Then
            aux(left) = data(i)
            left += 1
        ElseIf data(i) Mod 2 = 1 Then
            aux(right) = data(i)
            right -= 1
        End If
    Next i
    For i As Integer = 0 To size - 1
        data(i) = aux(i)
    Next i
End Sub

Sub SeparateEvenAndOdd2(ByVal data() As Integer, ByVal size As Integer)
    Dim left As Integer = 0, right As Integer = size - 1
    While left < right
        If data(left) Mod 2 = 0 Then
            left += 1
        ElseIf data(right) Mod 2 = 1 Then
            right -= 1
        Else
            Swap(data, left, right)
            left += 1
            right -= 1
        End If
    End While
End Sub

' Testing code
Sub Main4()
    Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
    SeparateEvenAndOdd(array, array.Length)
    PrintArray(array, array.Length)
    Dim array2() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
    SeparateEvenAndOdd2(array2, array2.Length)
    PrintArray(array2, array2.Length)
End Sub

' [ 8 2 6 4 5 3 7 1 9 ]
' [ 4 6 8 2 7 3 1 9 5 ]

Function AbsGreater(ByVal value1 As Integer, ByVal value2 As Integer, ByVal ref As Integer) As Boolean
    Return (Math.Abs(value1 - ref) > Math.Abs(value2 - ref))
End Function

Sub AbsBubbleSort(ByVal arr() As Integer, ByVal size As Integer, ByVal ref As Integer)
    Dim i As Integer = 0
    While i < (size - 1)
        Dim j As Integer = 0
        While j < (size - i - 1)
            If AbsGreater(arr(j), arr(j + 1), ref) Then
                Swap(arr, j, j + 1)
            End If
            j += 1
        End While
        i += 1
    End While
End Sub

' Testing code
Sub Main5()
    Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
    Dim reference As Integer = 5
    AbsBubbleSort(array, array.Length, reference)
    PrintArray(array, array.Length)
End Sub

'
'[ 5 6 4 7 3 8 2 9 1 ]
'
Function EqGreater(ByVal value1 As Integer, ByVal value2 As Integer, ByVal A As Integer) As Boolean
    value1 = A * value1 * value1
    value2 = A * value2 * value2
    Return value1 > value2
End Function

Sub ArrayReduction(ByVal arr() As Integer, ByVal size As Integer)
    Array.Sort(arr)
    Dim count As Integer = 1
    Dim reduction As Integer = arr(0)

    For i As Integer = 0 To size - 1
        If arr(i) - reduction > 0 Then
            reduction = arr(i)
            count += 1
        End If
    Next i
    Console.WriteLine(0) ' after all the reduction the array will be empty.
    Console.WriteLine("Total number of reductions: " & count)
End Sub

' Testing code
Sub Main6()
    Dim arr() As Integer = {5, 1, 1, 1, 2, 3, 5}
    ArrayReduction(arr, arr.Length)
End Sub

'
'Total number of reductions: 4
'

Sub SortByOrder(ByVal arr() As Integer, ByVal size As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
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
                Console.Write(arr2(j) & " ")
            Next k
            ht.Remove(arr2(j))
        End If
    Next j

    For i As Integer = 0 To size - 1
        If ht.ContainsKey(arr(i)) Then
            value = ht(arr(i))
            For k As Integer = 0 To value - 1
                Console.Write(arr(i) & " ")
            Next k
            ht.Remove(arr(i))
        End If
    Next i
End Sub

' Testing code
Sub Main7()
    Dim arr() As Integer = {2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8}
    Dim arr2() As Integer = {2, 1, 8, 3}
    SortByOrder(arr, arr.Length, arr2, arr2.Length)
    Console.WriteLine()
End Sub
'
'2 2 1 1 8 8 3 5 7 9 6

Sub Merge(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
    Dim index As Integer = 0
    Dim temp As Integer
    While index < size1
        If arr1(index) <= arr2(0) Then
            index += 1
        Else
            ' always first element of arr2 is compared.
            temp = arr1(index)
            arr1(index) = arr2(0)
            arr2(0) = temp
            index += 1
            ' After Swap arr2 may be unsorted.
            ' Insertion of the element in proper sorted position.
            Dim i As Integer = 0
            While i < (size2 - 1)
                If arr2(i) < arr2(i + 1) Then
                    Exit While
                End If
                temp = arr2(i)
                arr2(i) = arr2(i + 1)
                arr2(i + 1) = temp
                i += 1
            End While
        End If
    End While
End Sub

' Testing code.
Sub Main8()
    Dim arr1() As Integer = {1, 5, 9, 10, 15, 20}
    Dim arr2() As Integer = {2, 3, 8, 13}
    Merge(arr1, arr1.Length, arr2, arr2.Length)
    PrintArray(arr1, arr1.Length)
    PrintArray(arr2, arr2.Length)
End Sub

'
'[ 1 2 3 5 8 9 ]
'[ 10 13 15 20 ]
'

Function CheckReverse(ByVal arr() As Integer, ByVal size As Integer) As Boolean
    Dim start As Integer = -1
    Dim finish As Integer = -1
    Dim i As Integer = 0
    While i < (size - 1)
        If arr(i) > arr(i + 1) Then
            start = i
            Exit While
        End If
        i += 1
    End While

    If start = -1 Then
        Return True
    End If

    i = start
    While i < (size - 1)
        If arr(i) < arr(i + 1) Then
            finish = i
            Exit While
        End If
        i += 1
    End While

    If finish = -1 Then
        Return True
    End If

    ' increasing property
    ' after reversal the sub array should fit in the array.
    If arr(start - 1) > arr(finish) OrElse arr(finish + 1) < arr(start) Then
        Return False
    End If

    i = finish + 1
    While i < size - 1
        If arr(i) > arr(i + 1) Then
            Return False
        End If
        i += 1
    End While
    Return True
End Function

Sub Main9()
    Dim arr1() As Integer = {1, 2, 6, 5, 4, 7}
    Console.WriteLine(CheckReverse(arr1, arr1.Length))
End Sub
' True

Function Min(ByVal X As Integer, ByVal Y As Integer) As Integer
    If X < Y Then
        Return X
    End If
    Return Y
End Function

Sub UnionIntersectionSorted(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
    Dim first As Integer = 0, second As Integer = 0
    Dim unionArr((size1 + size2) - 1) As Integer
    Dim interArr(Min(size1, size2) - 1) As Integer
    Dim uIndex As Integer = 0
    Dim iIndex As Integer = 0

    While first < size1 AndAlso second < size2
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
    End While
    While first < size1
        unionArr(uIndex) = arr1(first)
        uIndex += 1
        first += 1
    End While
    While second < size2
        unionArr(uIndex) = arr2(second)
        uIndex += 1
        second += 1
    End While
    PrintArray(unionArr, uIndex)
    PrintArray(interArr, iIndex)
End Sub

Sub unionIntersectionUnsorted(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
    Array.Sort(arr1)
    Array.Sort(arr2)
    UnionIntersectionSorted(arr1, size1, arr2, size2)
End Sub

Sub Main10()
    Dim arr1() As Integer = {1, 11, 2, 3, 14, 5, 6, 8, 9}
    Dim arr2() As Integer = {2, 4, 5, 12, 7, 8, 13, 10}
    unionIntersectionUnsorted(arr1, arr1.Length, arr2, arr2.Length)
End Sub
'
'[ 1 2 3 4 5 6 7 8 9 10 11 12 13 14 ]
'[ 2 5 8 ]
'
Sub RotateArray(ByVal a() As Integer, ByVal n As Integer, ByVal k As Integer)
    ReverseArray(a, 0, k - 1)
    ReverseArray(a, k, n - 1)
    ReverseArray(a, 0, n - 1)
End Sub

Sub ReverseArray(ByVal a() As Integer, ByVal start As Integer, ByVal finish As Integer)
    Dim i As Integer = start
    Dim j As Integer = finish
    While i < j
        Dim temp As Integer = a(i)
        a(i) = a(j)
        a(j) = temp
        i += 1
        j -= 1
    End While
End Sub

Sub ReverseArray2(ByVal a() As Integer)
    Dim start As Integer = 0
    Dim finish As Integer = a.Length - 1
    Dim i As Integer = start
    Dim j As Integer = finish
    While i < j
        Dim temp As Integer = a(i)
        a(i) = a(j)
        a(j) = temp
        i += 1
        j -= 1
    End While
End Sub

' Testing code
Sub Main11()
    Dim arr() As Integer = {1, 2, 3, 4, 5, 6}
    RotateArray(arr, arr.Length, 2)
    PrintArray(arr, arr.Length)
End Sub

'
'	[ 3 4 5 6 1 2 ]
'
Sub WaveArray2(ByVal arr() As Integer)
    Dim size As Integer = arr.Length
    ' Odd elements are lesser then even elements.
    For i As Integer = 1 To size - 1 Step 2
        If (i - 1) >= 0 AndAlso arr(i) > arr(i - 1) Then
            Swap(arr, i, i - 1)
        End If
        If (i + 1) < size AndAlso arr(i) > arr(i + 1) Then
            Swap(arr, i, i + 1)
        End If
    Next i
End Sub

Sub WaveArray(ByVal arr() As Integer)
    Dim size As Integer = arr.Length
    Array.Sort(arr)
    Dim i As Integer = 0
    While i < size - 1
        Swap(arr, i, i + 1)
        i += 2
    End While
End Sub


' Testing code
Sub Main12()
    Dim arr() As Integer = {8, 1, 2, 3, 4, 5, 6, 4, 2}
    WaveArray(arr)
    PrintArray(arr, arr.Length)
    Dim arr2() As Integer = {8, 1, 2, 3, 4, 5, 6, 4, 2}
    WaveArray2(arr2)
    PrintArray(arr2, arr2.Length)
End Sub

'
'	[ 2 1 3 2 4 4 6 5 8 ]
'	[ 8 1 3 2 5 4 6 2 4 ]
'

Sub IndexArray(ByVal arr() As Integer, ByVal size As Integer)
    For i As Integer = 0 To size - 1
        Dim curr As Integer = i
        Dim value As Integer = -1

			' Swaps to move elements in proper position.
			While arr(curr) <> -1 AndAlso arr(curr) <> curr
				Dim temp As Integer = arr(curr)
				arr(curr) = value
				curr = temp
				value = curr
			End While

        ' check if some Swaps happened.
        If value <> -1 Then
            arr(curr) = value
        End If
    Next i
End Sub

Sub IndexArray2(ByVal arr() As Integer, ByVal size As Integer)
    Dim temp As Integer
    For i As Integer = 0 To size - 1
        While arr(i) <> -1 AndAlso arr(i) <> i
            ' Swap arr[i] and arr[arr[i]]
            temp = arr(i)
            arr(i) = arr(temp)
            arr(temp) = temp
        End While
    Next i
End Sub

' Testing code
Sub Main13()
    Dim arr() As Integer = {8, -1, 6, 1, 9, 3, 2, 7, 4, -1}
    Dim size As Integer = arr.Length
    IndexArray2(arr, size)
    PrintArray(arr, size)
    Dim arr2() As Integer = {8, -1, 6, 1, 9, 3, 2, 7, 4, -1}
    size = arr2.Length
    IndexArray(arr2, size)
    PrintArray(arr2, size)
End Sub

'
'	[ -1 1 2 3 4 -1 6 7 8 9 ]
'	[ -1 1 2 3 4 -1 6 7 8 9 ]
'

Sub Sort1toN(ByVal arr() As Integer, ByVal size As Integer)
    Dim curr, value, nextValue As Integer
    For i As Integer = 0 To size - 1
        curr = i
        value = -1
        ' Swaps to move elements in proper position.
        While curr >= 0 AndAlso curr < size AndAlso arr(curr) <> curr + 1
            nextValue = arr(curr)
            arr(curr) = value
            value = nextValue
            curr = nextValue - 1
        End While
    Next i
End Sub

Sub Sort1toN2(ByVal arr() As Integer, ByVal size As Integer)
    Dim temp As Integer
    For i As Integer = 0 To size - 1
        While arr(i) <> i + 1 AndAlso arr(i) > 1
            temp = arr(i)
            arr(i) = arr(temp - 1)
            arr(temp - 1) = temp
        End While
    Next i
End Sub

' Testing code
Sub Main14()
    Dim arr() As Integer = {8, 5, 6, 1, 9, 3, 2, 7, 4, 10}
    Dim size As Integer = arr.Length
    Sort1toN2(arr, size)
    PrintArray(arr, size)
    Dim arr2() As Integer = {8, 5, 6, 1, 9, 3, 2, 7, 4, 10}
    size = arr2.Length
    Sort1toN(arr2, size)
    PrintArray(arr2, size)
End Sub
'
'	[ 1 2 3 4 5 6 7 8 9 10 ]
'	[ 1 2 3 4 5 6 7 8 9 10 ]

Sub MaxMinArr(ByVal arr() As Integer, ByVal size As Integer)
    Dim aux(size - 1) As Integer
    Array.Copy(arr, aux, size)
    Dim start As Integer = 0
    Dim finish As Integer = size - 1
    For i As Integer = 0 To size - 1
        If i Mod 2 = 0 Then
            arr(i) = aux(finish)
            finish -= 1
        Else
            arr(i) = aux(start)
            start += 1
        End If
    Next i
End Sub

Sub ReverseArr(ByVal arr() As Integer, ByVal start As Integer, ByVal finish As Integer)
    While start < finish
        Swap(arr, start, finish)
        start += 1
        finish -= 1
    End While
End Sub

Sub MaxMinArr2(ByVal arr() As Integer, ByVal size As Integer)
    Dim i As Integer = 0
    While i < (size - 1)
        ReverseArr(arr, i, size - 1)
        i += 1
    End While
End Sub

' Testing code
Sub Main15()
    Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7}
    Dim size As Integer = arr.Length
    MaxMinArr(arr, size)
    PrintArray(arr, size)
    Dim arr2() As Integer = {1, 2, 3, 4, 5, 6, 7}
    Dim size2 As Integer = arr.Length
    MaxMinArr2(arr2, size2)
    PrintArray(arr2, size2)
End Sub

'
'	[ 7 1 6 2 5 3 4 ]
'	[ 7 1 6 2 5 3 4 ]
'

Function MaxCircularSum(ByVal arr() As Integer, ByVal size As Integer) As Integer
    Dim sumAll As Integer = 0
    Dim currVal As Integer = 0
    Dim maxVal As Integer

    For i As Integer = 0 To size - 1
        sumAll += arr(i)
        currVal += (i * arr(i))
    Next i
    maxVal = currVal
    For i As Integer = 1 To size - 1
        currVal = (currVal + sumAll) - (size * arr(size - i))
        If currVal > maxVal Then
            maxVal = currVal
        End If
    Next i
    Return maxVal
End Function

' Testing code
Sub Main16()
    Dim arr() As Integer = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}
    Console.WriteLine("MaxCircularSum: " & MaxCircularSum(arr, arr.Length))
End Sub
'
'	MaxCircularSum: 290
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
    Main15()
    Main16()
End Sub
End Module