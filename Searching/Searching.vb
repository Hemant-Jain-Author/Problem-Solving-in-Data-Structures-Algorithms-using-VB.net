Imports System
Imports System.Collections.Generic

Public Class Searching
    Public Shared Function LinearSearchUnsorted(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        For i As Integer = 0 To size - 1
            If value = arr(i) Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Shared Function LinearSearchSorted(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        For i As Integer = 0 To size - 1
            If value = arr(i) Then
                Return True
            ElseIf value < arr(i) Then
                Return False
            End If
        Next

        Return False
    End Function

    Public Shared Function BinarySearch(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        Dim low As Integer = 0
        Dim high As Integer = size - 1
        Dim mid As Integer

        While low <= high
            mid = (low + high) \ 2
            If arr(mid) = value Then
                Return True
            ElseIf arr(mid) < value Then
                low = mid + 1
            Else
                high = mid - 1
            End If
        End While

        Return False
    End Function

    Public Shared Function BinarySearchRec(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        Dim low As Integer = 0
        Dim high As Integer = size - 1
        Return BinarySearchRecUtil(arr, low, high, value)
    End Function

    Public Shared Function BinarySearchRecUtil(ByVal arr As Integer(), ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Boolean
        If low > high Then
            Return False
        End If

        Dim mid As Integer = (low + high) \ 2
        If arr(mid) = value Then
            Return True
        ElseIf arr(mid) < value Then
            Return BinarySearchRecUtil(arr, mid + 1, high, value)
        Else
            Return BinarySearchRecUtil(arr, low, mid - 1, value)
        End If
    End Function

    Public Shared Function BinarySearch(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer, ByVal key As Integer, ByVal isInc As Boolean) As Integer
        Dim mid As Integer

        If finish < start Then
            Return -1
        End If

        mid = (start + finish) \ 2

        If key = arr(mid) Then
            Return mid
        End If

        If isInc <> False AndAlso key < arr(mid) OrElse isInc = False AndAlso key > arr(mid) Then
            Return BinarySearch(arr, start, mid - 1, key, isInc)
        Else
            Return BinarySearch(arr, mid + 1, finish, key, isInc)
        End If
    End Function

    Public Shared Function FibonacciSearch(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        Dim fibNMn2 As Integer = 0
        Dim fibNMn1 As Integer = 1
        Dim fibN As Integer = fibNMn2 + fibNMn1

        While fibN < size
            fibNMn2 = fibNMn1
            fibNMn1 = fibN
            fibN = fibNMn2 + fibNMn1
        End While

        Dim low As Integer = 0

        While fibN > 1
            Dim i As Integer = Math.Min(low + fibNMn2, size - 1)
            If arr(i) = value Then
                Return True
            ElseIf arr(i) < value Then
                fibN = fibNMn1
                fibNMn1 = fibNMn2
                fibNMn2 = fibN - fibNMn1
                low = i
            Else
                fibN = fibNMn2
                fibNMn1 = fibNMn1 - fibNMn2
                fibNMn2 = fibN - fibNMn1
            End If
        End While

        If arr(low + fibNMn2) = value Then
            Return True
        End If

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main1()
        Dim first As Integer() = New Integer() {1, 3, 5, 7, 9, 25, 30}
        Console.WriteLine(LinearSearchUnsorted(first, 7, 8))
        Console.WriteLine(LinearSearchSorted(first, 7, 8))
        Console.WriteLine(BinarySearch(first, 7, 8))
        Console.WriteLine(BinarySearchRec(first, 7, 8))
        Console.WriteLine(FibonacciSearch(first, 7, 8))
        Console.WriteLine(FibonacciSearch(first, 7, 25))
        Console.WriteLine(LinearSearchUnsorted(first, 7, 25))
        Console.WriteLine(LinearSearchSorted(first, 7, 25))
        Console.WriteLine(BinarySearch(first, 7, 25))
        Console.WriteLine(BinarySearchRec(first, 7, 25))
    End Sub
	'	
	'False
	'False
	'False
	'False
	'False

	'True
	'True
	'True
	'True
	'True

    Public Shared Function SumArray(ByVal arr As Integer()) As Integer
        Dim size As Integer = arr.Length
        Dim total As Integer = 0

        For index As Integer = 0 To size - 1
            total = total + arr(index)
        Next

        Return total
    End Function

   ' Testing Code
	Public Shared Sub Main2()
        Dim arr As Integer() = New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9}
        Console.WriteLine("Sum of values in array:" & SumArray(arr))
    End Sub

	' Sum of values in array:45

    Public Shared Sub Swap(ByVal arr As Integer(), ByVal first As Integer, ByVal second As Integer)
        Dim temp As Integer = arr(first)
        arr(first) = arr(second)
        arr(second) = temp
    End Sub

    Public Shared Function FirstRepeated(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                If arr(i) = arr(j) Then
                    Return arr(i)
                End If
            Next
        Next

        Return 0
    End Function

    Public Shared Function FirstRepeated2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim hm As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

        For i As Integer = 0 To size - 1
            If hm.ContainsKey(arr(i)) Then
                hm(arr(i)) = 2
            Else
                hm(arr(i)) = 1
            End If
        Next

        For i As Integer = 0 To size - 1
            If hm(arr(i)) = 2 Then
                Return arr(i)
            End If
        Next

        Return 0
    End Function

   ' Testing Code
	Public Shared Sub Main3()
        Dim first As Integer() = New Integer() {1, 3, 5, 3, 9, 1, 30}
        Console.WriteLine(FirstRepeated(first, first.Length))
        Console.WriteLine(FirstRepeated2(first, first.Length))
    End Sub

	' 1
	' 1

    Public Shared Sub PrintRepeating(ByVal arr As Integer(), ByVal size As Integer)
        Console.Write("Repeating elements are ")
        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                If arr(i) = arr(j) Then
                    Console.Write(" " & arr(i))
                End If
            Next
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub PrintRepeating2(ByVal arr As Integer(), ByVal size As Integer)
        Array.Sort(arr)
        Console.Write("Repeating elements are ")
        For i As Integer = 1 To size - 1
            If arr(i) = arr(i - 1) Then
                Console.Write(" " & arr(i))
            End If
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub PrintRepeating3(ByVal arr As Integer(), ByVal size As Integer)
        Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()
        Console.Write("Repeating elements are ")
        For i As Integer = 0 To size - 1
            If hs.Contains(arr(i)) Then
                Console.Write(" " & arr(i))
            Else
                hs.Add(arr(i))
            End If
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub PrintRepeating4(ByVal arr As Integer(), ByVal size As Integer, ByVal range As Integer)
        Dim count As Integer() = New Integer(range - 1) {}
        Dim i As Integer
        For i = 0 To size - 1
            count(i) = 0
        Next

        Console.Write("Repeating elements are ")
        For i = 0 To size - 1
            If count(arr(i)) = 1 Then
                Console.Write(" " & arr(i))
            Else
                count(arr(i)) += 1
            End If
        Next

        Console.WriteLine()
    End Sub

   ' Testing Code
	Public Shared Sub Main4()
        Dim first As Integer() = New Integer() {1, 3, 5, 3, 9, 1, 30}
        PrintRepeating(first, first.Length)
        PrintRepeating2(first, first.Length)
        PrintRepeating3(first, first.Length)
        PrintRepeating4(first, first.Length, 50)
    End Sub
	'	Repeating elements are  1 3
	'	Repeating elements are  1 3
	'	Repeating elements are  1 3
	'	Repeating elements are  1 3

    Public Shared Function RemoveDuplicates(ByVal arr() As Integer, ByVal size As Integer) As Integer()
        Dim j As Integer = 0
        Array.Sort(arr)
        For i As Integer = 1 To size - 1
            If arr(i) <> arr(j) Then
                j += 1
                arr(j) = arr(i)
            End If
        Next

        Dim ret As Integer() = New Integer(j) {}
        Array.Copy(arr, ret, j + 1)
        Return ret
    End Function

    Public Shared Function RemoveDuplicates2(ByVal arr As Integer(), ByVal size As Integer) As Integer()
        Dim hm As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()
        Dim j As Integer = 0
        For i As Integer = 0 To size - 1
            If Not hm.ContainsKey(arr(i)) Then
                arr(j) = arr(i)
                j += 1
                hm(arr(i)) = 1
            End If
        Next

        Dim ret As Integer() = New Integer(j - 1) {}
        Array.Copy(arr, ret, j)
        Return ret
    End Function

   ' Testing Code
	Public Shared Sub Main5()
        Dim first As Integer() = New Integer() {1, 3, 5, 3, 9, 1, 30}
        Dim ret As Integer() = RemoveDuplicates(first, first.Length)
        For i As Integer = 0 To ret.Length - 1
            Console.Write(ret(i) & " ")
        Next
        Console.WriteLine()

        Dim first2 As Integer() = New Integer() {1, 3, 5, 3, 9, 1, 30}
        Dim ret2 As Integer() = RemoveDuplicates2(first2, first2.Length)
        For i As Integer = 0 To ret2.Length - 1
            Console.Write(ret2(i) & " ")
        Next
        Console.WriteLine()
    End Sub

' 1 3 5 9 30 
' 1 3 5 9 30

    Public Shared Function FindMissingNumber(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim i, j As Integer, found As Integer = 0
        For i = 1 To size
            found = 0
            For j = 0 To size - 1
                If arr(j) = i Then
                    found = 1
                    Exit For
                End If
            Next
            If found = 0 Then
                Return i
            End If
        Next

        Return Integer.MaxValue
    End Function

    Public Shared Function FindMissingNumber2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Array.Sort(arr)
        For i As Integer = 0 To size - 1
            If arr(i) <> i + 1 Then
                Return i + 1
            End If
        Next

        Return size
    End Function

    Public Shared Function FindMissingNumber3(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim hm As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()
        For i As Integer = 0 To size - 1
            hm(arr(i)) = 1
        Next

        For i As Integer = 1 To size
            If Not hm.ContainsKey(i) Then
                Return i
            End If
        Next

        Return Integer.MaxValue
    End Function

    Public Shared Function FindMissingNumber4(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim count As Integer() = New Integer(size) {}
		For i As Integer = 0 To size
            count(i) = -1
        Next

        For i As Integer = 0 To size - 1
            count(arr(i) - 1) = 1
        Next

        For i As Integer = 0 To size
            If count(i) = -1 Then
                Return i + 1
            End If
        Next

        Return Integer.MaxValue
    End Function

    Public Shared Function FindMissingNumber5(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim sum As Integer = 0
        For i As Integer = 1 To (size + 2) - 1
            sum += i
        Next

        For i As Integer = 0 To size - 1
            sum -= arr(i)
        Next

        Return sum
    End Function

    Public Shared Function FindMissingNumber6(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 1
            If arr(i) <> size + 1 AndAlso arr(i) <> size * 3 + 1 Then
                arr((arr(i) - 1) Mod size) += (size * 2)
            End If
        Next

        For i As Integer = 0 To size - 1
            If arr(i) < (size * 2) Then
                Return i + 1
            End If
        Next

        Return Integer.MaxValue
    End Function

    Public Shared Function FindMissingNumber7(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim i As Integer
        Dim xorSum As Integer = 0
        For i = 1 To (size + 2) - 1
            xorSum = xorSum Xor i
        Next

        For i = 0 To size - 1
            xorSum = xorSum Xor arr(i)
        Next

        Return xorSum
    End Function

    Public Shared Function FindMissingNumber8(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim st As HashSet(Of Integer) = New HashSet(Of Integer)()
        Dim i As Integer = 0
        While i < size
            st.Add(arr(i))
            i += 1
        End While

        i = 1

        While i <= size
            If st.Contains(i) = False Then
                Return i
            End If
            i += 1
        End While

        Console.WriteLine("NoNumberMissing")
        Return -1
    End Function

   ' Testing Code
	Public Shared Sub Main6()
        Dim first As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9}
        Console.WriteLine(FindMissingNumber(first, first.Length))
        Console.WriteLine(FindMissingNumber2(first, first.Length))
        Console.WriteLine(FindMissingNumber3(first, first.Length))
        Console.WriteLine(FindMissingNumber4(first, first.Length))
        Console.WriteLine(FindMissingNumber5(first, first.Length))
        Console.WriteLine(FindMissingNumber7(first, first.Length))
        Console.WriteLine(FindMissingNumber8(first, first.Length))
        Dim second As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9}
        Console.WriteLine(FindMissingNumber6(second, second.Length))
    End Sub
	'6
	'6
	'6
	'6
	'6
	'6
	'6
	'6

    Public Shared Sub MissingValues(ByVal arr As Integer(), ByVal size As Integer)
        Dim max As Integer = arr(0)
        Dim min As Integer = arr(0)
        For i As Integer = 1 To size - 1
            If max < arr(i) Then
                max = arr(i)
            End If

            If min > arr(i) Then
                min = arr(i)
            End If
        Next

        Dim found As Boolean
        For i As Integer = min + 1 To max - 1
            found = False
            For j As Integer = 0 To size - 1
                If arr(j) = i Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                Console.Write(i & " ")
            End If
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub MissingValues2(ByVal arr As Integer(), ByVal size As Integer)
        Array.Sort(arr)
        Dim value As Integer = arr(0)
        Dim i As Integer = 0
        While i < size
            If value = arr(i) Then
                value += 1
                i += 1
            Else
                Console.Write(value & " ")
                value += 1
            End If
        End While

        Console.WriteLine()
    End Sub

    Public Shared Sub MissingValues3(ByVal arr As Integer(), ByVal size As Integer)
        Dim ht As HashSet(Of Integer) = New HashSet(Of Integer)()
        Dim minVal As Integer = 999999
        Dim maxVal As Integer = -999999

        For i As Integer = 0 To size - 1
            ht.Add(arr(i))
            If minVal > arr(i) Then
                minVal = arr(i)
            End If
            If maxVal < arr(i) Then
                maxVal = arr(i)
            End If
        Next

        For i As Integer = minVal To maxVal
            If ht.Contains(i) = False Then
                Console.Write(i & " ")
            End If
        Next

        Console.WriteLine()
    End Sub

   ' Testing Code
	Public Shared Sub Main7()
        Dim arr As Integer() = New Integer() {11, 14, 13, 17, 21, 18, 19, 23, 24}
        Dim size As Integer = arr.Length
        MissingValues(arr, size)
        MissingValues2(arr, size)
        MissingValues3(arr, size)
    End Sub

	'	12 15 16 20 22 
	'	12 15 16 20 22 
	'	12 15 16 20 22 

    Public Shared Sub OddCount(ByVal arr As Integer(), ByVal size As Integer)
        Dim xorSum As Integer = 0
        For i As Integer = 0 To size - 1
            xorSum = xorSum Xor arr(i)
        Next
        Console.WriteLine("Odd values: " & xorSum)
    End Sub

    Public Shared Sub OddCount2(ByVal arr As Integer(), ByVal size As Integer)
        Dim hm As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

        For i As Integer = 0 To size - 1
            If hm.ContainsKey(arr(i)) Then
                hm.Remove(arr(i))
            Else
                hm(arr(i)) = 1
            End If
        Next

        Console.Write("Odd values: ")
        For Each key As Integer? In hm.Keys
            Console.Write(key & " ")
        Next
        Console.WriteLine()
        Console.WriteLine("Odd count is :: " & hm.Count)
    End Sub

    Public Shared Sub OddCount3(ByVal arr As Integer(), ByVal size As Integer)
        Dim xorSum As Integer = 0
        Dim first As Integer = 0
        Dim second As Integer = 0
        Dim setBit As Integer
        For i As Integer = 0 To size - 1
            xorSum = xorSum Xor arr(i)
        Next
		' Rightmost set bit. 
        setBit = xorSum And Not (xorSum - 1)
		'		
		' Dividing elements in two group: Elements having setBit bit as 1. Elements
		' having setBit bit as 0. Even elements cancelled themselves if group and we
		' get our numbers.
		'	
        For i As Integer = 0 To size - 1
            If (arr(i) And setBit) <> 0 Then
                first = first Xor arr(i)
            Else
                second = second Xor arr(i)
            End If
        Next

        Console.WriteLine("Odd values: " & first & " " & second)
    End Sub

   ' Testing Code
	Public Shared Sub Main8()
        Dim arr As Integer() = New Integer() {10, 25, 30, 10, 15, 25, 15}
        Dim size As Integer = arr.Length
        OddCount(arr, size)
        OddCount2(arr, size)
        Dim arr2 As Integer() = New Integer() {10, 25, 30, 10, 15, 25, 15, 40}
        Dim size2 As Integer = arr2.Length
        OddCount3(arr2, size2)
    End Sub

' Odd values: 30
' Odd values: 30 
' Odd count is :: 1
' Odd values: 30 40

    Public Shared Sub SumDistinct(ByVal arr As Integer(), ByVal size As Integer)
        Dim sum As Integer = 0
        Array.Sort(arr)

        For i As Integer = 0 To (size - 1) - 1
            If arr(i) <> arr(i + 1) Then
                sum += arr(i)
            End If
        Next

        sum += arr(size - 1)
        Console.WriteLine("sum : " & sum)
    End Sub

   ' Testing Code
	Public Shared Sub Main9()
        Dim arr As Integer() = New Integer() {1, 2, 3, 1, 1, 4, 5, 6}
        Dim size As Integer = arr.Length
        SumDistinct(arr, size)
    End Sub
	'	sum : 21

    Public Shared Sub MinAbsSumPair(ByVal arr As Integer(), ByVal size As Integer)
        Dim l, r, minSum, sum, minFirst, minSecond As Integer
        If size < 2 Then
            Console.WriteLine("Invalid Input")
            Return
        End If

        minFirst = 0
        minSecond = 1
        minSum = Math.Abs(arr(0) + arr(1))

        For l = 0 To size - 1 - 1
            For r = l + 1 To size - 1
                sum = Math.Abs(arr(l) + arr(r))
                If sum < minSum Then
                    minSum = sum
                    minFirst = l
                    minSecond = r
                End If
            Next
        Next

        Console.WriteLine("Minimum sum elements are : " & arr(minFirst) & " , " & arr(minSecond))
    End Sub

    Public Shared Sub MinAbsSumPair2(ByVal arr As Integer(), ByVal size As Integer)
        Dim l, r, minSum, sum, minFirst, minSecond As Integer
        If size < 2 Then
            Console.WriteLine("Invalid Input")
            Return
        End If

        Array.Sort(arr)
        minFirst = 0
        minSecond = size - 1
        minSum = Math.Abs(arr(minFirst) + arr(minSecond))
        l = 0
        r = size - 1

        While l < r
            sum = (arr(l) + arr(r))
            If Math.Abs(sum) < minSum Then
                minSum = Math.Abs(sum)
                minFirst = l
                minSecond = r
            End If
            If sum < 0 Then
                l += 1
            ElseIf sum > 0 Then
                r -= 1
            Else
                Exit While
            End If
        End While

        Console.WriteLine("Minimum sum elements are : " & arr(minFirst) & " , " & arr(minSecond))
    End Sub

   ' Testing Code
	Public Shared Sub Main10()
        Dim first As Integer() = New Integer() {1, 5, -10, 3, 2, -6, 8, 9, 6}
        MinAbsSumPair2(first, first.Length)
        MinAbsSumPair(first, first.Length)
    End Sub

	'	Minimum sum elements are : -6 , 6
	'	Minimum sum elements are : -6 , 6

    Public Shared Function FindPair(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                If (arr(i) + arr(j)) = value Then
                    Console.WriteLine("The pair is : " & arr(i) & ", " & arr(j))
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Public Shared Function FindPair2(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        Dim first As Integer = 0, second As Integer = size - 1
        Dim curr As Integer
        Array.Sort(arr)

        While first < second
            curr = arr(first) + arr(second)
            If curr = value Then
                Console.WriteLine("The pair is " & arr(first) & ", " & arr(second))
                Return True
            ElseIf curr < value Then
                first += 1
            Else
                second -= 1
            End If
        End While

        Return False
    End Function

    Public Shared Function FindPair3(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 0 To size - 1
            If hs.Contains(value - arr(i)) Then
                Console.WriteLine("The pair is : " & arr(i) & ", " & (value - arr(i)))
                Return True
            End If
            hs.Add(arr(i))
        Next

        Return False
    End Function

    Public Shared Function FindPair4(ByVal arr As Integer(), ByVal size As Integer, ByVal range As Integer, ByVal value As Integer) As Boolean
        Dim count As Integer() = New Integer(range) {}
		For i As Integer = 0 To range
			count(i)= 0
		Next i
        For i As Integer = 0 To size - 1
            If count(value - arr(i)) > 0 Then
                Console.WriteLine("The pair is : " & arr(i) & ", " & (value - arr(i)))
                Return True
            End If
            count(arr(i)) += 1
        Next

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main11()
        Dim first As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9, 6}
        Console.WriteLine(FindPair(first, first.Length, 8))
        Console.WriteLine(FindPair2(first, first.Length, 8))
        Console.WriteLine(FindPair3(first, first.Length, 8))
        Console.WriteLine(FindPair4(first, first.Length, 9, 8))
    End Sub
	'	The pair is : 1, 7
	'	True
	'	The pair is 1, 7
	'	True
	'	The pair is : 5, 3
	'	True
	'	The pair is : 5, 3
	'	True

    Public Shared Function FindPairTwoLists(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer, ByVal value As Integer) As Boolean
        For i As Integer = 0 To size1 - 1
            For j As Integer = 0 To size2 - 1
                If (arr1(i) + arr2(j)) = value Then
                    Console.WriteLine("The pair is : " & arr1(i) & ", " & arr2(j))
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Public Shared Function FindPairTwoLists2(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer, ByVal value As Integer) As Boolean
        Array.Sort(arr2)
        For i As Integer = 0 To size1 - 1
            If BinarySearch(arr2, size2, value - arr1(i)) Then
                Console.WriteLine("The pair is " & arr1(i) & ", " & (value - arr1(i)))
                Return True
            End If
        Next

        Return False
    End Function

    Public Shared Function FindPairTwoLists3(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer, ByVal value As Integer) As Boolean
        Dim first As Integer = 0, second As Integer = size2 - 1, curr As Integer = 0
        Array.Sort(arr1)
        Array.Sort(arr2)

        While first < size1 AndAlso second >= 0
            curr = arr1(first) + arr2(second)
            If curr = value Then
                Console.WriteLine("The pair is " & arr1(first) & ", " & arr2(second))
                Return True
            ElseIf curr < value Then
                first += 1
            Else
                second -= 1
            End If
        End While

        Return False
    End Function

    Public Shared Function FindPairTwoLists4(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer, ByVal value As Integer) As Boolean
        Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()
        For i As Integer = 0 To size2 - 1
            hs.Add(arr2(i))
        Next

        For i As Integer = 0 To size1 - 1
            If hs.Contains(value - arr1(i)) Then
                Console.WriteLine("The pair is : " & arr1(i) & ", " & (value - arr1(i)))
                Return True
            End If
        Next

        Return False
    End Function

    Public Shared Function FindPairTwoLists5(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer, ByVal range As Integer, ByVal value As Integer) As Boolean
        Dim count As Integer() = New Integer(range) {}
		For i As Integer = 0 To range
			count(i)= 0
		Next i
        For i As Integer = 0 To size2 - 1
            count(arr2(i)) = 1
        Next

        For i As Integer = 0 To size1 - 1
            If count(value - arr1(i)) <> 0 Then
                Console.WriteLine("The pair is : " & arr1(i) & ", " & (value - arr1(i)))
                Return True
            End If
        Next

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main12()
        Dim first As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9, 6}
        Dim second As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9, 6}
        Console.WriteLine(FindPairTwoLists(first, first.Length, second, second.Length, 8))
        Console.WriteLine(FindPairTwoLists2(first, first.Length, second, second.Length, 8))
        Console.WriteLine(FindPairTwoLists3(first, first.Length, second, second.Length, 8))
        Console.WriteLine(FindPairTwoLists4(first, first.Length, second, second.Length, 8))
        Console.WriteLine(FindPairTwoLists5(first, first.Length, second, second.Length, 9, 8))
    End Sub

	'The pair is 1 & 7
	'True
	'The pair is 1 & 7
	'True
	'The pair is 1 & 7
	'True
	'The pair is 1 & 7
	'True
	'The pair is 1 & 7
	'True 

    Public Shared Function FindDifference(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                If Math.Abs(arr(i) - arr(j)) = value Then
                    Console.WriteLine("The pair is:: " & arr(i) & " & " & arr(j))
                    Return True
                End If
            Next
        Next

        Return False
    End Function

    Public Shared Function FindDifference2(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Boolean
        Dim first As Integer = 0
        Dim second As Integer = 0
        Dim diff As Integer
        Array.Sort(arr)

        While first < size AndAlso second < size
            diff = Math.Abs(arr(first) - arr(second))
            If diff = value Then
                Console.WriteLine("The pair is::" & arr(first) & " & " & arr(second))
                Return True
            ElseIf diff > value Then
                first += 1
            Else
                second += 1
            End If
        End While

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main13()
        Dim first As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9, 6}
        Console.WriteLine(FindDifference(first, first.Length, 6))
        Console.WriteLine(FindDifference2(first, first.Length, 6))
    End Sub

	'The pair is 1 & 7
	'True
	'The pair is 1 & 7
	'True 
	
    Public Shared Function FindMinDiff(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim diff As Integer = Integer.MaxValue
        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                Dim value As Integer = Math.Abs(arr(i) - arr(j))
                If diff > value Then
                    diff = value
                End If
            Next
        Next

        Return diff
    End Function

    Public Shared Function FindMinDiff2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Array.Sort(arr)
        Dim diff As Integer = Integer.MaxValue

        For i As Integer = 0 To (size - 1) - 1
            If (arr(i + 1) - arr(i)) < diff Then
                diff = arr(i + 1) - arr(i)
            End If
        Next

        Return diff
    End Function

   ' Testing Code
	Public Shared Sub Main14()
        Dim second As Integer() = New Integer() {1, 6, 4, 19, 17, 20}
        Console.WriteLine("FindMinDiff : " & FindMinDiff(second, second.Length))
        Console.WriteLine("FindMinDiff : " & FindMinDiff2(second, second.Length))
    End Sub

	'	FindMinDiff : 1
	'	FindMinDiff : 1

    Public Shared Function MinDiffPair(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer) As Integer
        Dim diff As Integer = Integer.MaxValue
        Dim first As Integer = 0
        Dim second As Integer = 0

        For i As Integer = 0 To size1 - 1
            For j As Integer = 0 To size2 - 1
                Dim value As Integer = Math.Abs(arr1(i) - arr2(j))
                If diff > value Then
                    diff = value
                    first = arr1(i)
                    second = arr2(j)
                End If
            Next
        Next

        Console.WriteLine("The pair is :: " & first & " & " & second)
        Console.WriteLine("Minimum difference is :: " & diff)
        Return diff
    End Function

    Public Shared Function MinDiffPair2(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer) As Integer
        Dim minDiff As Integer = Integer.MaxValue
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim diff As Integer, first As Integer = 0, second As Integer = 0
        Array.Sort(arr1)
        Array.Sort(arr2)

        While i < size1 AndAlso j < size2
            diff = Math.Abs(arr1(i) - arr2(j))
            If minDiff > diff Then
                minDiff = diff
                first = arr1(i)
                second = arr2(j)
            End If
            If arr1(i) < arr2(j) Then
                i += 1
            Else
                j += 1
            End If
        End While

        Console.WriteLine("The pair is :: " & first & " & " & second)
        Console.WriteLine("Minimum difference is :: " & minDiff)
        Return minDiff
    End Function

   ' Testing Code
	Public Shared Sub Main15()
        Dim first As Integer() = New Integer() {1, 5, 4, 3, 2, 7, 8, 9, 6}
        Dim second As Integer() = New Integer() {6, 4, 19, 17, 20}
        MinDiffPair(first, first.Length, second, second.Length)
        MinDiffPair(first, first.Length, second, second.Length)
    End Sub

' The pair is :: 4 & 4
' Minimum difference is :: 0
' The pair is :: 4 & 4
' Minimum difference is :: 0

    Public Shared Sub ClosestPair(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        Dim diff As Integer = 999999
        Dim first As Integer = -1
        Dim second As Integer = -1
        Dim curr As Integer

        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                curr = Math.Abs(value - (arr(i) + arr(j)))
                If curr < diff Then
                    diff = curr
                    first = arr(i)
                    second = arr(j)
                End If
            Next
        Next

        Console.WriteLine("closest pair is :: " & first & " " & second)
    End Sub

    Public Shared Sub ClosestPair2(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        Dim first As Integer = 0, second As Integer = 0
        Dim start As Integer = 0
        Dim finish As Integer = size - 1
        Dim diff, curr As Integer
        Array.Sort(arr)
        diff = 9999999

        If True Then
            While start < finish
                curr = (value - (arr(start) + arr(finish)))
                If Math.Abs(curr) < diff Then
                    diff = Math.Abs(curr)
                    first = arr(start)
                    second = arr(finish)
                End If
                If curr = 0 Then
                    Exit While
                ElseIf curr > 0 Then
                    start += 1
                Else
                    finish -= 1
                End If
            End While
        End If

        Console.WriteLine("closest pair is :: " & first & " " & second)
    End Sub

   ' Testing Code
	Public Shared Sub Main16()
        Dim first As Integer() = New Integer() {10, 20, 3, 4, 50, 80}
        ClosestPair(first, first.Length, 47)
        ClosestPair2(first, first.Length, 47)
    End Sub

' closest pair is :: 3 50
' closest pair is :: 3 50


    Public Shared Function SumPairRestArray(ByVal arr As Integer(), ByVal size As Integer) As Boolean
        Dim total, low, high, curr, value As Integer
        Array.Sort(arr)
        total = 0
        For i As Integer = 0 To size - 1
            total += arr(i)
        Next

        value = total \ 2
        low = 0
        high = size - 1

        While low < high
            curr = arr(low) + arr(high)
            If curr = value Then
                Console.WriteLine("Pair is :: " & arr(low) & " " & arr(high))
                Return True
            ElseIf curr < value Then
                low += 1
            Else
                high -= 1
            End If
        End While

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main17()
        Dim first As Integer() = New Integer() {1, 2, 4, 8, 16, 15}
        Console.WriteLine(SumPairRestArray(first, first.Length))
    End Sub

' Pair is :: 8 15
' True

    Public Shared Sub ZeroSumTriplets(ByVal arr As Integer(), ByVal size As Integer)
        For i As Integer = 0 To (size - 2) - 1
            For j As Integer = i + 1 To (size - 1) - 1
                For k As Integer = j + 1 To size - 1
                    If arr(i) + arr(j) + arr(k) = 0 Then
                        Console.WriteLine("Triplet:: " & arr(i) & " " & arr(j) & " " & arr(k))
                    End If
                Next
            Next
        Next
    End Sub

    Public Shared Sub ZeroSumTriplets2(ByVal arr As Integer(), ByVal size As Integer)
        Dim start, finish As Integer
        Array.Sort(arr)
        For i As Integer = 0 To (size - 2) - 1
            start = i + 1
            finish = size - 1
            While start < finish
                If arr(i) + arr(start) + arr(finish) = 0 Then
                    Console.WriteLine("Triplet :: " & arr(i) & " " & arr(start) & " " & arr(finish))
                    start += 1
                    finish -= 1
                ElseIf arr(i) + arr(start) + arr(finish) > 0 Then
                    finish -= 1
                Else
                    start += 1
                End If
            End While
        Next
    End Sub

   ' Testing Code
	Public Shared Sub Main18()
        Dim first As Integer() = New Integer() {0, -1, 2, -3, 1}
        ZeroSumTriplets(first, first.Length)
        ZeroSumTriplets2(first, first.Length)
    End Sub
	'	Triplet :: 0 -1 1
	'	Triplet :: 2 -3 1
	'	Triplet :: -3 1 2
	'	Triplet :: -1 0 1

    Public Shared Sub FindTriplet(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        For i As Integer = 0 To (size - 2) - 1
            For j As Integer = i + 1 To (size - 1) - 1
                For k As Integer = j + 1 To size - 1
                    If (arr(i) + arr(j) + arr(k)) = value Then
                        Console.WriteLine("Triplet :: " & arr(i) & " " & arr(j) & " " & arr(k))
                    End If
                Next
            Next
        Next
    End Sub

    Public Shared Sub FindTriplet2(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        Dim start, finish As Integer
        Array.Sort(arr)
        For i As Integer = 0 To size - 2 - 1
            start = i + 1
            finish = size - 1
            While start < finish
                If arr(i) + arr(start) + arr(finish) = value Then
                    Console.WriteLine("Triplet ::" & arr(i) & " " & arr(start) & " " & arr(finish))
                    start += 1
                    finish -= 1
                ElseIf arr(i) + arr(start) + arr(finish) > value Then
                    finish -= 1
                Else
                    start += 1
                End If
            End While
        Next
    End Sub

   ' Testing Code
	Public Shared Sub Main19()
        Dim first As Integer() = New Integer() {1, 5, 15, 6, 9, 8}
        FindTriplet(first, first.Length, 22)
        FindTriplet2(first, first.Length, 22)
    End Sub
	'	Triplet :: 1 15 6
	'	Triplet :: 5 9 8
	'	Triplet :: 1 6 15
	'	Triplet :: 5 8 9

    Public Shared Sub AbcTriplet(ByVal arr As Integer(), ByVal size As Integer)
        For i As Integer = 0 To size - 1 - 1
            For j As Integer = i + 1 To size - 1
                For k As Integer = 0 To size - 1
                    If k <> i AndAlso k <> j AndAlso arr(i) + arr(j) = arr(k) Then
                        Console.WriteLine("AbcTriplet:: " & arr(i) & " " & arr(j) & " " & arr(k))
                    End If
                Next
            Next
        Next
    End Sub

    Public Shared Sub AbcTriplet2(ByVal arr As Integer(), ByVal size As Integer)
        Dim start, finish As Integer
        Array.Sort(arr)
        For i As Integer = 0 To size - 1
            start = 0
            finish = size - 1
            While start < finish
                If arr(i) = arr(start) + arr(finish) Then
                    Console.WriteLine("AbcTriplet:: " & arr(start) & " " & arr(finish) & " " & arr(i))
                    start += 1
                    finish -= 1
                ElseIf arr(i) < arr(start) + arr(finish) Then
                    finish -= 1
                Else
                    start += 1
                End If
            End While
        Next
    End Sub

   ' Testing Code
	Public Shared Sub Main20()
        Dim first As Integer() = New Integer() {1, 5, 15, 6, 9, 8}
        AbcTriplet(first, first.Length)
        AbcTriplet2(first, first.Length)
    End Sub

' AbcTriplet:: 1 5 6
' AbcTriplet:: 1 8 9
' AbcTriplet:: 6 9 15

' AbcTriplet:: 1 5 6
' AbcTriplet:: 1 8 9
' AbcTriplet:: 6 9 15

    Public Shared Sub SmallerThenTripletCount(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        Dim count As Integer = 0
        For i As Integer = 0 To size - 1 - 1
            For j As Integer = i + 1 To size - 1
                For k As Integer = j + 1 To size - 1
                    If arr(i) + arr(j) + arr(k) < value Then
                        count += 1
                    End If
                Next
            Next
        Next

        Console.WriteLine("Smaller Then Triplet Count:: " & count)
    End Sub

    Public Shared Sub SmallerThenTripletCount2(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        Dim start, finish As Integer
        Dim count As Integer = 0
        Array.Sort(arr)

        For i As Integer = 0 To (size - 2) - 1
            start = i + 1
            finish = size - 1
            While start < finish
                If arr(i) + arr(start) + arr(finish) >= value Then
                    finish -= 1
                Else
                    count += finish - start
                    start += 1
                End If
            End While
        Next

        Console.WriteLine("Smaller Then Triplet Count:: " & count)
    End Sub

   ' Testing Code
	Public Shared Sub Main21()
        Dim first As Integer() = New Integer() {-2, -1, 0, 1}
        SmallerThenTripletCount(first, first.Length, 2)
        SmallerThenTripletCount(first, first.Length, 2)
    End Sub
	'Smaller Then Triplet Count:: 4
	'Smaller Then Triplet Count:: 4

    Public Shared Sub APTriplets(ByVal arr As Integer(), ByVal size As Integer)
        Dim i, j, k As Integer

        For i = 1 To size - 1 - 1
            j = i - 1
            k = i + 1
            While j >= 0 AndAlso k < size
                If arr(j) + arr(k) = 2 * arr(i) Then
                    Console.WriteLine("AP Triplet:: " & arr(j) & " " & arr(i) & " " & arr(k))
                    k += 1
                    j -= 1
                ElseIf arr(j) + arr(k) < 2 * arr(i) Then
                    k += 1
                Else
                    j -= 1
                End If
            End While
        Next
    End Sub

   ' Testing Code
	Public Shared Sub Main22()
        Dim arr As Integer() = New Integer() {2, 4, 10, 12, 14, 18, 36}
        APTriplets(arr, arr.Length)
    End Sub
	'	AP Triplet:: 2 10 18
	'	AP Triplet:: 10 12 14
	'	AP Triplet:: 10 14 18

    Public Shared Sub GPTriplets(ByVal arr As Integer(), ByVal size As Integer)
        Dim i, j, k As Integer

        For i = 1 To size - 1 - 1
            j = i - 1
            k = i + 1
            While j >= 0 AndAlso k < size
                If arr(j) * arr(k) = arr(i) * arr(i) Then
                    Console.WriteLine("GP Triplet:: " & arr(j) & " " & arr(i) & " " & arr(k))
                    k += 1
                    j -= 1
                ElseIf arr(j) + arr(k) < 2 * arr(i) Then
                    k += 1
                Else
                    j -= 1
                End If
            End While
        Next
    End Sub

   ' Testing Code
	Public Shared Sub Main23()
        Dim arr As Integer() = New Integer() {1, 2, 4, 8, 16}
        GPTriplets(arr, arr.Length)
    End Sub
	'	GP Triplet:: 1 2 4
	'	GP Triplet:: 2 4 8
	'	GP Triplet:: 1 4 16
	'	GP Triplet:: 4 8 16

    Public Shared Function NumberOfTriangles(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim i, j, k As Integer, count As Integer = 0

        For i = 0 To (size - 2) - 1
            For j = i + 1 To (size - 1) - 1
                For k = j + 1 To size - 1
                    If arr(i) + arr(j) > arr(k) Then
                        count += 1
                    End If
                Next
            Next
        Next

        Return count
    End Function

    Public Shared Function NumberOfTriangles2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim i, j, k As Integer, count As Integer = 0
        Array.Sort(arr)

        For i = 0 To (size - 2) - 1
            k = i + 2
            For j = i + 1 To (size - 1) - 1
                While k < size AndAlso arr(i) + arr(j) > arr(k)
                    k += 1
                End While
                count += k - j - 1
            Next
        Next

        Return count
    End Function

   ' Testing Code
	Public Shared Sub Main24()
        Dim arr As Integer() = New Integer() {1, 2, 3, 4, 5}
        Console.WriteLine(NumberOfTriangles(arr, arr.Length))
        Console.WriteLine(NumberOfTriangles2(arr, arr.Length))
    End Sub
	'	3
	'	3

    Public Shared Function GetMax(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim max As Integer = arr(0), count As Integer = 1, maxCount As Integer = 1
        For i As Integer = 0 To size - 1
            count = 1
            For j As Integer = i + 1 To size - 1
                If arr(i) = arr(j) Then
                    count += 1
                End If
            Next
            If count > maxCount Then
                max = arr(i)
                maxCount = count
            End If
        Next

        Return max
    End Function

    Public Shared Function GetMax2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim max As Integer = arr(0), maxCount As Integer = 1
        Dim curr As Integer = arr(0), currCount As Integer = 1
        Array.Sort(arr)
        For i As Integer = 1 To size - 1
            If arr(i) = arr(i - 1) Then
                currCount += 1
            Else
                currCount = 1
                curr = arr(i)
            End If
            If currCount > maxCount Then
                maxCount = currCount
                max = curr
            End If
        Next

        Return max
    End Function

    Public Shared Function GetMax3(ByVal arr As Integer(), ByVal size As Integer, ByVal range As Integer) As Integer
        Dim max As Integer = arr(0), maxCount As Integer = 1
        Dim count As Integer() = New Integer(range - 1) {}

        For i As Integer = 0 To size - 1
            count(arr(i)) += 1
            If count(arr(i)) > maxCount Then
                maxCount = count(arr(i))
                max = arr(i)
            End If
        Next

        Return max
    End Function

   ' Testing Code
	Public Shared Sub Main25()
        Dim first As Integer() = New Integer() {1, 30, 5, 13, 9, 31, 5}
        Console.WriteLine(GetMax(first, first.Length))
        Console.WriteLine(GetMax2(first, first.Length))
        Console.WriteLine(GetMax3(first, first.Length, 50))
    End Sub
	'	5
	'	5
	'	5

    Public Shared Function GetMajority(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim max As Integer = 0, count As Integer = 0, maxCount As Integer = 0

        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                If arr(i) = arr(j) Then
                    count += 1
                End If
            Next
            If count > maxCount Then
                max = arr(i)
                maxCount = count
            End If
        Next

        If maxCount > size \ 2 Then
            Return max
        Else
            Return 0
        End If
    End Function

    Public Shared Function GetMajority2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim majIndex As Integer = size \ 2, count As Integer = 1
        Dim candidate As Integer
        Array.Sort(arr)
        candidate = arr(majIndex)
        count = 0

        For i As Integer = 0 To size - 1
            If arr(i) = candidate Then
                count += 1
            End If
        Next

        If count > size \ 2 Then
            Return arr(majIndex)
        Else
            Return Integer.MinValue
        End If
    End Function

    Public Shared Function GetMajority3(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim majIndex As Integer = 0, count As Integer = 1
        Dim i As Integer
        Dim candidate As Integer

        For i = 1 To size - 1
            If arr(majIndex) = arr(i) Then
                count += 1
            Else
                count -= 1
            End If
            If count = 0 Then
                majIndex = i
                count = 1
            End If
        Next

        candidate = arr(majIndex)
        count = 0

        For i = 0 To size - 1
            If arr(i) = candidate Then
                count += 1
            End If
        Next

        If count > size \ 2 Then
            Return arr(majIndex)
        Else
            Return 0
        End If
    End Function

   ' Testing Code
	Public Shared Sub Main26()
        Dim first As Integer() = New Integer() {1, 5, 5, 13, 5, 31, 5}
        Console.WriteLine(GetMajority(first, first.Length))
        Console.WriteLine(GetMajority2(first, first.Length))
        Console.WriteLine(GetMajority3(first, first.Length))
    End Sub
	'	5
	'	5
	'	5

    Public Shared Function GetMedian(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Array.Sort(arr)
        Return arr(size \ 2)
    End Function

    Public Shared Function GetMedian2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        QuickSelectUtil(arr, 0, size - 1, size \ 2)
        Return arr(size \ 2)
    End Function

   ' Testing Code
	Public Shared Sub Main27()
        Dim first As Integer() = New Integer() {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
        Console.WriteLine(GetMedian(first, first.Length))
        Console.WriteLine(GetMedian(first, first.Length))
    End Sub
	'	6

    Public Shared Function SearchBitonicArrayMax(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 2 - 1
            If arr(i) > arr(i + 1) Then
                Return arr(i)
            End If
        Next

        Console.WriteLine("error not a bitonic array")
        Return 0
    End Function

    Public Shared Function SearchBitonicArrayMax2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim start As Integer = 0, finish As Integer = size - 1
        Dim mid As Integer = (start + finish) \ 2
        Dim maximaFound As Integer = 0

        If size < 3 Then
            Console.WriteLine("error")
            Return 0
        End If

        While start <= finish
            mid = (start + finish) \ 2
            If arr(mid - 1) < arr(mid) AndAlso arr(mid + 1) < arr(mid) Then
                maximaFound = 1
                Exit While
            ElseIf arr(mid - 1) < arr(mid) AndAlso arr(mid) < arr(mid + 1) Then
                start = mid + 1
            ElseIf arr(mid - 1) > arr(mid) AndAlso arr(mid) > arr(mid + 1) Then
                finish = mid - 1
            Else
                Exit While
            End If
        End While

        If maximaFound = 0 Then
            Console.WriteLine("error not a bitonic array")
            Return 0
        End If

        Return arr(mid)
    End Function

    Public Shared Function SearchBitonicArray(ByVal arr As Integer(), ByVal size As Integer, ByVal key As Integer) As Integer
        Dim max As Integer = findMaxBitonicArray(arr, size)
        Dim k As Integer = BinarySearch(arr, 0, max, key, True)
        If k <> -1 Then
            Return k
        Else
            Return BinarySearch(arr, max + 1, size - 1, key, False)
        End If
    End Function

    Public Shared Function findMaxBitonicArray(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim mid As Integer, start As Integer = 0, finish As Integer = size - 1
        If size < 3 Then
            Console.WriteLine("error")
            Return -1
        End If

        While start <= finish
            mid = (start + finish) \ 2
            If arr(mid - 1) < arr(mid) AndAlso arr(mid + 1) < arr(mid) Then
                Return mid
            ElseIf arr(mid - 1) < arr(mid) AndAlso arr(mid) < arr(mid + 1) Then
                start = mid + 1
            ElseIf arr(mid - 1) > arr(mid) AndAlso arr(mid) > arr(mid + 1) Then
                finish = mid - 1
            Else
                Exit While
            End If
        End While

        Console.WriteLine("error")
        Return -1
    End Function

   ' Testing Code
	Public Shared Sub Main28()
        Dim first As Integer() = New Integer() {1, 5, 10, 13, 20, 30, 8, 7, 6}
        Console.WriteLine(SearchBitonicArrayMax(first, first.Length))
        Console.WriteLine(SearchBitonicArrayMax2(first, first.Length))
        Console.WriteLine(SearchBitonicArray(first, first.Length, 7))
    End Sub
' 30
' 30
' 7

    Public Shared Function FindKeyCount(ByVal arr As Integer(), ByVal size As Integer, ByVal key As Integer) As Integer
        Dim count As Integer = 0
        For i As Integer = 0 To size - 1
            If arr(i) = key Then
                count += 1
            End If
        Next

        Return count
    End Function

    Public Shared Function FindFirstIndex(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer, ByVal key As Integer) As Integer
        Dim mid As Integer
        If finish < start Then
            Return -1
        End If

        mid = (start + finish) \ 2

        If key = arr(mid) AndAlso (mid = start OrElse arr(mid - 1) <> key) Then
            Return mid
        End If

        If key <= arr(mid) Then
            Return FindFirstIndex(arr, start, mid - 1, key)
        Else
            Return FindFirstIndex(arr, mid + 1, finish, key)
        End If
    End Function

    Public Shared Function FindLastIndex(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer, ByVal key As Integer) As Integer
        If finish < start Then
            Return -1
        End If

        Dim mid As Integer = (start + finish) \ 2

        If key = arr(mid) AndAlso (mid = finish OrElse arr(mid + 1) <> key) Then
            Return mid
        End If

        If key < arr(mid) Then
            Return FindLastIndex(arr, start, mid - 1, key)
        Else
            Return FindLastIndex(arr, mid + 1, finish, key)
        End If
    End Function

    Public Shared Function FindKeyCount2(ByVal arr As Integer(), ByVal size As Integer, ByVal key As Integer) As Integer
        Dim FirstIndex, lastIndex As Integer
        FirstIndex = FindFirstIndex(arr, 0, size - 1, key)
        lastIndex = FindLastIndex(arr, 0, size - 1, key)
        Return (lastIndex - FirstIndex + 1)
    End Function

   ' Testing Code
	Public Shared Sub Main29()
        Dim first As Integer() = New Integer() {1, 5, 10, 13, 20, 30, 8, 7, 6}
        Console.WriteLine(FindKeyCount(first, first.Length, 6))
        Console.WriteLine(FindKeyCount2(first, first.Length, 6))
    End Sub
	'	1
	'	1

    Public Shared Function FirstIndex(ByVal arr As Integer(), ByVal size As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Integer
        Dim mid As Integer = 0

        If high >= low Then
            mid = (low + high) \ 2
        End If

        '		
		' Find first occurrence of value, either it should be the first element of the
		' array or the value before it is smaller than it.
		'
		If (mid = 0 OrElse arr(mid - 1) < value) AndAlso (arr(mid) = value) Then
            Return mid
        ElseIf arr(mid) < value Then
            Return FirstIndex(arr, size, mid + 1, high, value)
        Else
            Return FirstIndex(arr, size, low, mid - 1, value)
        End If
    End Function

    Public Shared Function IsMajority2(ByVal arr As Integer(), ByVal size As Integer) As Boolean
        Dim majority As Integer = arr(size \ 2)
        Dim i As Integer = FirstIndex(arr, size, 0, size - 1, majority)

        '		
		' we are using majority element form array so we will get some valid index
		' always.
		'
		If ((i + size \ 2) <= (size - 1)) AndAlso arr(i + size \ 2) = majority Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function IsMajority(ByVal arr As Integer(), ByVal size As Integer) As Boolean
        Dim count As Integer = 0
        Dim mid As Integer = arr(size \ 2)

        For i As Integer = 0 To size - 1
            If arr(i) = mid Then
                count += 1
            End If
        Next

        If count > size \ 2 Then
            Return True
        End If

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main30()
        Dim arr As Integer() = New Integer() {3, 3, 3, 3, 4, 5, 10}
        Console.WriteLine(IsMajority(arr, arr.Length))
        Console.WriteLine(IsMajority2(arr, arr.Length))
    End Sub

' True
' True

    Public Shared Function MaxProfit(ByVal stocks As Integer(), ByVal size As Integer) As Integer
        Dim maxPfit As Integer = 0
        Dim buy As Integer = 0, sell As Integer = 0

        For i As Integer = 0 To size - 1 - 1
            For j As Integer = i + 1 To size - 1
                If maxPfit < stocks(j) - stocks(i) Then
                    maxPfit = stocks(j) - stocks(i)
                    buy = i
                    sell = j
                End If
            Next
        Next

        Console.WriteLine("Purchase day is " & buy & " at price " & stocks(buy))
        Console.WriteLine("Sell day is " & sell & " at price " & stocks(sell))
        Return maxPfit
    End Function

    Public Shared Function MaxProfit2(ByVal stocks As Integer(), ByVal size As Integer) As Integer
        Dim buy As Integer = 0, sell As Integer = 0
        Dim curMin As Integer = 0
        Dim currProfit As Integer = 0
        Dim maxProfit As Integer = 0

        For i As Integer = 0 To size - 1
            If stocks(i) < stocks(curMin) Then
                curMin = i
            End If
            currProfit = stocks(i) - stocks(curMin)
            If currProfit > maxProfit Then
                buy = curMin
                sell = i
                maxProfit = currProfit
            End If
        Next

        Console.WriteLine("Purchase day is " & buy & " at price " & stocks(buy))
        Console.WriteLine("Sell day is " & sell & " at price " & stocks(sell))
        Return maxProfit
    End Function

   ' Testing Code
	Public Shared Sub Main31()
        Dim first As Integer() = New Integer() {10, 150, 6, 67, 61, 16, 86, 6, 67, 78, 150, 3, 28, 143}
        Console.WriteLine("Profit : " & MaxProfit(first, first.Length))
        Console.WriteLine("Profit : " & MaxProfit2(first, first.Length))
    End Sub

' Purchase day is 2 at price 6
' Sell day is 10 at price 150
' Profit : 144
' Purchase day is 2 at price 6
' Sell day is 10 at price 150
' Profit : 144


    Public Shared Function FindMedian(ByVal arrFirst As Integer(), ByVal sizeFirst As Integer, ByVal arrSecond As Integer(), ByVal sizeSecond As Integer) As Integer
        Dim medianIndex As Integer = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) Mod 2) \ 2
        Dim i As Integer = 0, j As Integer = 0
        Dim count As Integer = 0
        While count < medianIndex - 1
            If i < sizeFirst - 1 AndAlso arrFirst(i) < arrSecond(j) Then
                i += 1
            Else
                j += 1
            End If
            count += 1
        End While

        If arrFirst(i) < arrSecond(j) Then
            Return arrFirst(i)
        Else
            Return arrSecond(j)
        End If
    End Function

   ' Testing Code
	Public Shared Sub Main32()
        Dim first As Integer() = New Integer() {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
        Dim second As Integer() = New Integer() {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
        Console.WriteLine(FindMedian(first, first.Length, second, second.Length))
    End Sub

		'	6

    Public Shared Function Search01(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 1
            If arr(i) = 1 Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Shared Function BinarySearch01(ByVal arr As Integer(), ByVal size As Integer) As Integer
        If size = 1 AndAlso arr(0) = 1 Then
            Return 0
        End If

        Return BinarySearch01Util(arr, 0, size - 1)
    End Function

    Public Shared Function BinarySearch01Util(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer) As Integer
        If finish < start Then
            Return -1
        End If

        Dim mid As Integer = (start + finish) \ 2

        If 1 = arr(mid) AndAlso 0 = arr(mid - 1) Then
            Return mid
        End If

        If 0 = arr(mid) Then
            Return BinarySearch01Util(arr, mid + 1, finish)
        Else
            Return BinarySearch01Util(arr, start, mid - 1)
        End If
    End Function

   ' Testing Code
	Public Shared Sub Main33()
        Dim first As Integer() = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1}
        Console.WriteLine(Search01(first, first.Length))
        Console.WriteLine(BinarySearch01(first, first.Length))
    End Sub

' 8
' 8

    Public Shared Function RotationMax(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 1 - 1
            If arr(i) > arr(i + 1) Then
                Return arr(i)
            End If
        Next

        Return -1
    End Function

    Public Shared Function RotationMaxUtil(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer) As Integer
        If finish <= start Then
            Return arr(start)
        End If

        Dim mid As Integer = (start + finish) \ 2

        If arr(mid) > arr(mid + 1) Then
            Return arr(mid)
        End If

        If arr(start) <= arr(mid) Then
            Return RotationMaxUtil(arr, mid + 1, finish)
        Else
            Return RotationMaxUtil(arr, start, mid - 1)
        End If
    End Function

    Public Shared Function RotationMax2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Return RotationMaxUtil(arr, 0, size - 1)
    End Function

   ' Testing Code
	Public Shared Sub Main34()
        Dim first As Integer() = New Integer() {34, 56, 77, 1, 5, 6, 6, 8, 10, 20, 30, 34}
        Console.WriteLine(RotationMax(first, first.Length))
        Console.WriteLine(RotationMax2(first, first.Length))
    End Sub

' 77
' 77

    Public Shared Function FindRotationMax(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 1 - 1
            If arr(i) > arr(i + 1) Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Shared Function FindRotationMaxUtil(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer) As Integer
        If finish <= start Then
            Return start
        End If

        Dim mid As Integer = (start + finish) \ 2

        If arr(mid) > arr(mid + 1) Then
            Return mid
        End If

        If arr(start) <= arr(mid) Then
            Return FindRotationMaxUtil(arr, mid + 1, finish)
        Else
            Return FindRotationMaxUtil(arr, start, mid - 1)
        End If
    End Function

    Public Shared Function FindRotationMax2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Return FindRotationMaxUtil(arr, 0, size - 1)
    End Function

   ' Testing Code
	Public Shared Sub Main35()
        Dim first As Integer() = New Integer() {34, 56, 77, 1, 5, 6, 6, 8, 10, 20, 30, 34}
        Console.WriteLine(FindRotationMax(first, first.Length))
        Console.WriteLine(FindRotationMax2(first, first.Length))
    End Sub

' 2
' 2

    Public Shared Function CountRotation(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim maxIndex As Integer = FindRotationMaxUtil(arr, 0, size - 1)
        Return (maxIndex + 1) Mod size
    End Function

   ' Testing Code
	Public Shared Sub Main36()
        Dim first As Integer() = New Integer() {34, 56, 77, 1, 5, 6, 6, 8, 10, 20, 30, 34}
        Console.WriteLine(CountRotation(first, first.Length))
    End Sub

	'	3

    Public Shared Function SearchRotateArray(ByVal arr As Integer(), ByVal size As Integer, ByVal key As Integer) As Integer
        For i As Integer = 0 To size - 1 - 1
            If arr(i) = key Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Shared Function BinarySearchRotateArrayUtil(ByVal arr As Integer(), ByVal start As Integer, ByVal finish As Integer, ByVal key As Integer) As Integer
        If finish < start Then
            Return -1
        End If

        Dim mid As Integer = (start + finish) \ 2

        If key = arr(mid) Then
            Return mid
        End If

        If arr(mid) > arr(start) Then
            If arr(start) <= key AndAlso key < arr(mid) Then
                Return BinarySearchRotateArrayUtil(arr, start, mid - 1, key)
            Else
                Return BinarySearchRotateArrayUtil(arr, mid + 1, finish, key)
            End If
        Else
            If arr(mid) < key AndAlso key <= arr(finish) Then
                Return BinarySearchRotateArrayUtil(arr, mid + 1, finish, key)
            Else
                Return BinarySearchRotateArrayUtil(arr, start, mid - 1, key)
            End If
        End If
    End Function

    Public Shared Function BinarySearchRotateArray(ByVal arr As Integer(), ByVal size As Integer, ByVal key As Integer) As Integer
        Return BinarySearchRotateArrayUtil(arr, 0, size - 1, key)
    End Function

   ' Testing Code
	Public Shared Sub Main37()
        Dim first As Integer() = New Integer() {34, 56, 77, 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
        Console.WriteLine(SearchRotateArray(first, first.Length, 20))
        Console.WriteLine(BinarySearchRotateArray(first, first.Length, 20))
        Console.WriteLine(CountRotation(first, first.Length))
        Console.WriteLine(first(FindRotationMax(first, first.Length)))
    End Sub

' 15
' 15
' 3
' 77

    Public Shared Function MinAbsDiffAdjCircular(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim diff As Integer = 9999999

        If size < 2 Then
            Return -1
        End If

        For i As Integer = 0 To size - 1
            diff = Math.Min(diff, Math.Abs(arr(i) - arr((i + 1) Mod size)))
        Next

        Return diff
    End Function

   ' Testing Code
	Public Shared Sub Main38()
        Dim arr As Integer() = New Integer() {5, 29, 18, 51, 11}
        Console.WriteLine(MinAbsDiffAdjCircular(arr, arr.Length))
    End Sub

	'	6

    Public Shared Sub Swapch(ByVal arr As Char(), ByVal first As Integer, ByVal second As Integer)
        Dim temp As Char = arr(first)
        arr(first) = arr(second)
        arr(second) = temp
    End Sub

    Public Shared Sub TransformArrayAB1(ByVal arr As Char(), ByVal size As Integer)
        Dim i, j As Integer, N As Integer = size \ 2

        For i = 1 To N - 1
            For j = 0 To i - 1
                Swapch(arr, N - i + 2 * j, N - i + 2 * j + 1)
            Next
        Next
    End Sub

   ' Testing Code
	Public Shared Sub Main39()
        Dim str As Char() = "aaaabbbb".ToCharArray()
        TransformArrayAB1(str, str.Length)
        Console.WriteLine(str)
    End Sub
	'	abababab

    Public Shared Function CheckPermutation(ByVal array1 As Char(), ByVal size1 As Integer, ByVal array2 As Char(), ByVal size2 As Integer) As Boolean
        If size1 <> size2 Then
            Return False
        End If

        Array.Sort(array1)
        Array.Sort(array2)

        For i As Integer = 0 To size1 - 1
            If array1(i) <> array2(i) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Function CheckPermutation2(ByVal arr1 As Char(), ByVal size1 As Integer, ByVal arr2 As Char(), ByVal size2 As Integer) As Boolean
        If size1 <> size2 Then
            Return False
        End If

        Dim hm As Dictionary(Of Char, Integer) = New Dictionary(Of Char, Integer)()

        For i As Integer = 0 To size1 - 1
            If hm.ContainsKey(arr1(i)) Then
                hm(arr1(i)) = hm(arr1(i)) + 1
            Else
                hm(arr1(i)) = 1
            End If
        Next

        For i As Integer = 0 To size2 - 1
            If hm.ContainsKey(arr2(i)) AndAlso hm(arr2(i)) <> 0 Then
                hm(arr2(i)) = hm(arr2(i)) - 1
            Else
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Function CheckPermutation3(ByVal array1 As Char(), ByVal size1 As Integer, ByVal array2 As Char(), ByVal size2 As Integer) As Boolean
        If size1 <> size2 Then
            Return False
        End If

        Dim count As Integer() = New Integer(255) {}

        For i As Integer = 0 To size1 - 1
            count(AscW(array1(i))) += 1
			count(AscW(array2(i))) -= 1
        Next

        For i As Integer = 0 To size1 - 1
            If count(i) <> 0 Then
                Console.WriteLine("Not Permutation")
                Return False
            End If
        Next

        Return True
    End Function

   ' Testing Code
	Public Shared Sub Main40()
        Dim str1 As Char() = "aaaabbbb".ToCharArray()
        Dim str2 As Char() = "bbaaaabb".ToCharArray()
        Console.WriteLine(CheckPermutation(str1, str1.Length, str2, str2.Length))
        Console.WriteLine(CheckPermutation2(str1, str1.Length, str2, str2.Length))
        Console.WriteLine(CheckPermutation3(str1, str1.Length, str2, str2.Length))
    End Sub

' True
' True
' True

    Public Shared Function FindElementIn2DArray(ByVal arr As Integer(,), ByVal r As Integer, ByVal c As Integer, ByVal value As Integer) As Boolean
        Dim row As Integer = 0
        Dim column As Integer = c - 1

        While row < r AndAlso column >= 0
            If arr(row, column) = value Then
                Return True
            ElseIf arr(row, column) > value Then
                column -= 1
            Else
                row += 1
            End If
        End While

        Return False
    End Function

    Public Shared Function IsAP(ByVal arr As Integer(), ByVal size As Integer) As Boolean
        If size <= 1 Then
            Return True
        End If

        Array.Sort(arr)
        Dim diff As Integer = arr(1) - arr(0)

        For i As Integer = 2 To size - 1
            If arr(i) - arr(i - 1) <> diff Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Function IsAP2(ByVal arr As Integer(), ByVal size As Integer) As Boolean
        Dim first As Integer = 9999999
        Dim second As Integer = 9999999
        Dim value As Integer
        Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 0 To size - 1
            If arr(i) < first Then
                second = first
                first = arr(i)
            ElseIf arr(i) < second Then
                second = arr(i)
            End If
        Next

        Dim diff As Integer = second - first

        For i As Integer = 0 To size - 1
            If hs.Contains(arr(i)) Then
                Return False
            End If
            hs.Add(arr(i))
        Next

        For i As Integer = 0 To size - 1
            value = first + i * diff
            If Not hs.Contains(value) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Function IsAP3(ByVal arr As Integer(), ByVal size As Integer) As Boolean
        Dim first As Integer = 9999999
        Dim second As Integer = 9999999
        Dim count As Integer() = New Integer(size - 1) {}
        Dim index As Integer = -1

        For i As Integer = 0 To size - 1
            If arr(i) < first Then
                second = first
                first = arr(i)
            ElseIf arr(i) < second Then
                second = arr(i)
            End If
        Next

        Dim diff As Integer = second - first

        For i As Integer = 0 To size - 1
            index = (arr(i) - first) / diff
            If index > size - 1 OrElse count(index) <> 0 Then
                Return False
            End If
            count(index) = 1
        Next

        For i As Integer = 0 To size - 1
            If count(i) <> 1 Then
                Return False
            End If
        Next

        Return True
    End Function

   ' Testing Code
	Public Shared Sub Main41()
        Dim arr As Integer() = New Integer() {20, 25, 15, 5, 0, 10, 35, 30}
        Console.WriteLine(IsAP(arr, arr.Length))
        Console.WriteLine(IsAP2(arr, arr.Length))
        Console.WriteLine(IsAP3(arr, arr.Length))
    End Sub
	'	True
	'	True
	'	True

    Public Shared Function FindBalancedPoint(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim first As Integer = 0
        Dim second As Integer = 0

        For i As Integer = 1 To size - 1
            second += arr(i)
        Next

        For i As Integer = 0 To size - 1
            If first = second Then
                Console.WriteLine(i)
                Return i
            End If
            If i < size - 1 Then
                first += arr(i)
            End If
            second -= arr(i + 1)
        Next

        Return -1
    End Function

   ' Testing Code
	Public Shared Sub Main42()
        Dim arr As Integer() = New Integer() {-7, 1, 5, 2, -4, 3, 0}
        Console.WriteLine(FindBalancedPoint(arr, arr.Length))
    End Sub
	'	3

    Public Shared Function FindFloor(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Integer
        Dim start As Integer = 0
        Dim finish As Integer = size - 1
        Dim mid As Integer

        While start <= finish
            mid = (start + finish) \ 2
            If arr(mid) = value OrElse (arr(mid) < value AndAlso (mid = size - 1 OrElse arr(mid + 1) > value)) Then
                Return arr(mid)
            ElseIf arr(mid) < value Then
                start = mid + 1
            Else
                finish = mid - 1
            End If
        End While

        Return -1
    End Function

    Public Shared Function FindCeil(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer) As Integer
        Dim start As Integer = 0
        Dim finish As Integer = size - 1
        Dim mid As Integer

        While start <= finish
            mid = (start + finish) \ 2
            If arr(mid) = value OrElse (arr(mid) > value AndAlso (mid = 0 OrElse arr(mid - 1) < value)) Then
                Return arr(mid)
            ElseIf arr(mid) < value Then
                start = mid + 1
            Else
                finish = mid - 1
            End If
        End While

        Return -1
    End Function

   ' Testing Code
	Public Shared Sub Main43()
        Dim arr As Integer() = New Integer() {2, 4, 8, 16}
        Console.WriteLine("Floor : " & FindFloor(arr, arr.Length, 5))
        Console.WriteLine("Ceil : " & FindCeil(arr, arr.Length, 5))
    End Sub

' Floor : 4
' Ceil : 8

    Public Shared Function ClosestNumber(ByVal arr As Integer(), ByVal size As Integer, ByVal num As Integer) As Integer
        Dim start As Integer = 0
        Dim finish As Integer = size - 1
        Dim output As Integer = -1
        Dim minDist As Integer = Integer.MaxValue
        Dim mid As Integer

        While start <= finish
            mid = (start + finish) \ 2
            If minDist > Math.Abs(arr(mid) - num) Then
                minDist = Math.Abs(arr(mid) - num)
                output = arr(mid)
            End If
            If arr(mid) = num Then
                Exit While
            ElseIf arr(mid) > num Then
                finish = mid - 1
            Else
                start = mid + 1
            End If
        End While

        Return output
    End Function

   ' Testing Code
	Public Shared Sub Main44()
        Dim arr As Integer() = New Integer() {2, 4, 8, 16}
        Console.WriteLine(ClosestNumber(arr, arr.Length, 9))
    End Sub

	'	8

    Public Shared Function DuplicateKDistance(ByVal arr As Integer(), ByVal size As Integer, ByVal k As Integer) As Boolean
        Dim hm As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

        For i As Integer = 0 To size - 1
            If hm.ContainsKey(arr(i)) AndAlso i - hm(arr(i)) <= k Then
                Console.WriteLine("Value:" & arr(i) & " Index: " & hm(arr(i)) & " & " & i)
                Return True
            Else
                hm(arr(i)) = i
            End If
        Next

        Return False
    End Function

   ' Testing Code
	Public Shared Sub Main45()
        Dim arr As Integer() = New Integer() {1, 2, 3, 1, 4, 5}
        DuplicateKDistance(arr, arr.Length, 3)
    End Sub

    Public Shared Sub FrequencyCounts(ByVal arr As Integer(), ByVal size As Integer)
        Dim hm As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

        For i As Integer = 0 To size - 1
            If hm.ContainsKey(arr(i)) Then
                hm(arr(i)) = hm(arr(i)) + 1
            Else
                hm(arr(i)) = 1
            End If
        Next

        For Each key As Integer In hm.Keys
            Console.Write("(" & key & " : " & hm(key) & ") ")
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub FrequencyCounts2(ByVal arr As Integer(), ByVal size As Integer)
        Array.Sort(arr)
        Dim count As Integer = 1

        For i As Integer = 1 To size - 1
            If arr(i) = arr(i - 1) Then
                count += 1
            Else
                Console.Write("(" & arr(i - 1) & " : " & count & ") ")
                count = 1
            End If
        Next

        Console.Write("(" & arr(size - 1) & " : " & count & ") ")
        Console.WriteLine()
    End Sub

    Public Shared Sub FrequencyCounts3(ByVal arr As Integer(), ByVal size As Integer)
        Dim aux As Integer() = New Integer(size) {}

        For i As Integer = 0 To size - 1
            aux(arr(i)) += 1
        Next

        For i As Integer = 0 To size
            If aux(i) > 0 Then
                Console.Write("(" & i & " : " & aux(i) & ") ")
            End If
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub FrequencyCounts4(ByVal arr As Integer(), ByVal size As Integer)
        Dim index As Integer

        For i As Integer = 0 To size - 1
            While arr(i) > 0
                index = arr(i) - 1
                If arr(index) > 0 Then
                    arr(i) = arr(index)
                    arr(index) = -1
                Else
                    arr(index) -= 1
                    arr(i) = 0
                End If
            End While
        Next

        For i As Integer = 0 To size - 1
            If arr(i) <> 0 Then
                Console.Write("(" & (i + 1) & " : " & Math.Abs(arr(i)) & ") ")
            End If
        Next

        Console.WriteLine()
    End Sub

   ' Testing Code
	Public Shared Sub Main46()
        Dim arr As Integer() = New Integer() {1, 2, 2, 2, 1}
        FrequencyCounts(arr, arr.Length)
        FrequencyCounts2(arr, arr.Length)
        FrequencyCounts3(arr, arr.Length)
        FrequencyCounts4(arr, arr.Length)
    End Sub

	'(1 : 2) (2 : 3) 
	'(1 : 2) (2 : 3) 
	'(1 : 2) (2 : 3) 
	'(1 : 2) (2 : 3) 

    Public Shared Sub KLargestElements(ByVal arrIn As Integer(), ByVal size As Integer, ByVal k As Integer)
        Dim arr As Integer() = New Integer(size - 1) {}

        For i As Integer = 0 To size - 1
            arr(i) = arrIn(i)
        Next

        Array.Sort(arr)

        For i As Integer = 0 To size - 1
            If arrIn(i) >= arr(size - k) Then
                Console.Write(arrIn(i) & " ")
            End If
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub QuickSelectUtil(ByVal arr As Integer(), ByVal lower As Integer, ByVal upper As Integer, ByVal k As Integer)
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
                Swap(arr, upper, lower)
            End If
        End While

        Swap(arr, upper, start)

        If k < upper Then
            QuickSelectUtil(arr, start, upper - 1, k)
        End If

        If k > upper Then
            QuickSelectUtil(arr, upper + 1, finish, k)
        End If
    End Sub

    Public Shared Sub KLargestElements2(ByVal arrIn As Integer(), ByVal size As Integer, ByVal k As Integer)
        Dim arr As Integer() = New Integer(size - 1) {}
        For i As Integer = 0 To size - 1
            arr(i) = arrIn(i)
        Next

        QuickSelectUtil(arr, 0, size - 1, size - k)
        For i As Integer = 0 To size - 1
            If arrIn(i) >= arr(size - k) Then
                Console.Write(arrIn(i) & " ")
            End If
        Next

        Console.WriteLine()
    End Sub

   ' Testing Code
	Public Shared Sub Main47()
        Dim arr As Integer() = New Integer() {10, 50, 30, 60, 15}
        KLargestElements(arr, arr.Length, 2)
        KLargestElements2(arr, arr.Length, 2)
    End Sub
	'	50 60 
	'	50 60 

    Public Shared Function FixPoint(ByVal arr As Integer(), ByVal size As Integer) As Integer
        For i As Integer = 0 To size - 1
            If arr(i) = i Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Shared Function FixPoint2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim low As Integer = 0
        Dim high As Integer = size - 1
        Dim mid As Integer

        While low <= high
            mid = (low + high) \ 2
            If arr(mid) = mid Then
                Return mid
            ElseIf arr(mid) < mid Then
                low = mid + 1
            Else
                high = mid - 1
            End If
        End While

        Return -1
    End Function

   ' Testing Code
	Public Shared Sub Main48()
        Dim arr As Integer() = New Integer() {-10, -2, 0, 3, 11, 12, 35, 51, 200}
        Console.WriteLine(FixPoint(arr, arr.Length))
        Console.WriteLine(FixPoint2(arr, arr.Length))
    End Sub
	'	3
	'	3

    Public Shared Sub SubArraySums(ByVal arr As Integer(), ByVal size As Integer, ByVal value As Integer)
        Dim start As Integer = 0, finish As Integer = 0, sum As Integer = 0

        While start < size AndAlso finish < size
            If sum < value Then
                sum += arr(finish)
                finish += 1
            Else
                sum -= arr(start)
                start += 1
            End If
            If sum = value Then
                Console.Write("(" & start & " to " & (finish - 1) & ") ")
            End If
        End While
    End Sub

   ' Testing Code
	Public Shared Sub Main49()
        Dim arr As Integer() = New Integer() {15, 5, 5, 20, 10, 5, 5, 20, 10, 10}
        SubArraySums(arr, arr.Length, 20)
    End Sub

	' (0 to 1) (3 to 3) (4 to 6) (7 to 7) (8 to 9)

    Public Shared Function MaxConSub(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim currMax As Integer = 0, maximum As Integer = 0

        For i As Integer = 0 To size - 1
            currMax += arr(i)
            If currMax < 0 Then
                currMax = 0
            End If
            If maximum < currMax Then
                maximum = currMax
            End If
        Next

        Console.WriteLine(maximum)
        Return maximum
    End Function

    Public Shared Function MaxConSubArr(ByVal A As Integer(), ByVal sizeA As Integer, ByVal B As Integer(), ByVal sizeB As Integer) As Integer
        Dim currMax As Integer = 0
        Dim maximum As Integer = 0
        Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()

        For i As Integer = 0 To sizeB - 1
            hs.Add(B(i))
        Next

        For i As Integer = 0 To sizeA - 1
            If hs.Contains(A(i)) Then
                currMax = 0
            Else
                currMax = currMax + A(i)
                If currMax < 0 Then
                    currMax = 0
                End If
                If maximum < currMax Then
                    maximum = currMax
                End If
            End If
        Next

        Console.WriteLine(maximum)
        Return maximum
    End Function

    Public Shared Function MaxConSubArr2(ByVal A As Integer(), ByVal sizeA As Integer, ByVal B As Integer(), ByVal sizeB As Integer) As Integer
        Array.Sort(B)
        Dim currMax As Integer = 0
        Dim maximum As Integer = 0

        For i As Integer = 0 To sizeA - 1
            If BinarySearch(B, sizeB, A(i)) Then
                currMax = 0
            Else
                currMax = currMax + A(i)
                If currMax < 0 Then
                    currMax = 0
                End If
                If maximum < currMax Then
                    maximum = currMax
                End If
            End If
        Next

        Console.WriteLine(maximum)
        Return maximum
    End Function

   ' Testing Code
	Public Shared Sub Main50()
        Dim arr As Integer() = New Integer() {1, 2, -3, 4, 5, -10, 6, 7}
        MaxConSub(arr, arr.Length)
        Dim arr2 As Integer() = New Integer() {1, 2, 3, 4, 5, -10, 6, 7, 3}
        Dim arr3 As Integer() = New Integer() {1, 3}
        MaxConSubArr(arr2, arr2.Length, arr3, arr3.Length)
        MaxConSubArr2(arr2, arr2.Length, arr3, arr3.Length)
    End Sub

	'	13
	'	13
	'	13

    Public Shared Function RainWater(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim leftHigh As Integer() = New Integer(size - 1) {}
        Dim rightHigh As Integer() = New Integer(size - 1) {}
        Dim max As Integer = arr(0)
        leftHigh(0) = arr(0)

        For i As Integer = 1 To size - 1
            If max < arr(i) Then
                max = arr(i)
            End If
            leftHigh(i) = max
        Next

        max = arr(size - 1)
        rightHigh(size - 1) = arr(size - 1)

        For i As Integer = (size - 2) To 0 Step -1
            If max < arr(i) Then
                max = arr(i)
            End If
            rightHigh(i) = max
        Next

        Dim water As Integer = 0

        For i As Integer = 0 To size - 1
            water += Math.Min(leftHigh(i), rightHigh(i)) - arr(i)
        Next

        Console.WriteLine("Water : " & water)
        Return water
    End Function

    Public Shared Function RainWater2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim water As Integer = 0
        Dim leftMax As Integer = 0, rightMax As Integer = 0
        Dim left As Integer = 0
        Dim right As Integer = size - 1

        While left <= right
            If arr(left) < arr(right) Then
                If arr(left) > leftMax Then
                    leftMax = arr(left)
                Else
                    water += leftMax - arr(left)
                End If
                left += 1
            Else
                If arr(right) > rightMax Then
                    rightMax = arr(right)
                Else
                    water += rightMax - arr(right)
                End If
                right -= 1
            End If
        End While

        Console.WriteLine("Water : " & water)
        Return water
    End Function

   ' Testing Code
	Public Shared Sub Main51()
        Dim arr As Integer() = New Integer() {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1}
        RainWater(arr, arr.Length)
        RainWater2(arr, arr.Length)
    End Sub

	'	Water : 6
	'	Water : 6

    Public Shared Sub SeparateEvenAndOdd(ByVal arr As Integer(), ByVal size As Integer)
        Dim left As Integer = 0, right As Integer = size - 1

        While left < right
            If arr(left) Mod 2 = 0 Then
                left += 1
            ElseIf arr(right) Mod 2 = 1 Then
                right -= 1
            Else
                Swap(arr, left, right)
                left += 1
                right -= 1
            End If
        End While
    End Sub

   ' Testing Code
	Public Shared Sub Main52()
        Dim first As Integer() = New Integer() {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
        SeparateEvenAndOdd(first, first.Length)

        For Each val As Integer In first
            Console.Write(val & " ")
        Next
    End Sub
	'	30 20 6 6 6 6 6 6 10 8 7 13 5 1

    Public Shared Function MaxSubArraySum(ByVal a As Integer(), ByVal size As Integer) As Integer
        Dim maxSoFar As Integer = 0, maxEndingHere As Integer = 0

        For i As Integer = 0 To size - 1
            maxEndingHere = maxEndingHere + a(i)
            If maxEndingHere < 0 Then
                maxEndingHere = 0
            End If
            If maxSoFar < maxEndingHere Then
                maxSoFar = maxEndingHere
            End If
        Next

        Return maxSoFar
    End Function

   ' Testing Code
	Public Shared Sub Main53()
        Dim arr As Integer() = New Integer() {1, -2, 3, 4, -4, 6, -4, 3, 2}
        Console.WriteLine("Max sub array sum :" & MaxSubArraySum(arr, 9))
    End Sub
	' Max sub array sum :10

    Public Shared Function SmallestPositiveMissingNumber(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim found As Integer

        For i As Integer = 1 To size
            found = 0
            For j As Integer = 0 To size - 1
                If arr(j) = i Then
                    found = 1
                    Exit For
                End If
            Next
            If found = 0 Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Shared Function SmallestPositiveMissingNumber2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim hs As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

        For i As Integer = 0 To size - 1
            hs(arr(i)) = 1
        Next

        For i As Integer = 1 To size
            If hs.ContainsKey(i) = False Then
                Return i
            End If
        Next

        Return -1
    End Function

    Public Shared Function SmallestPositiveMissingNumber3(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim aux As Integer() = New Integer(size - 1) {}
		For i As Integer = 0 To size - 1
			aux(i)= -1
		Next i
        For i As Integer = 0 To size - 1
            If arr(i) > 0 AndAlso arr(i) <= size Then
                aux(arr(i) - 1) = arr(i)
            End If
        Next

        For i As Integer = 0 To size - 1
            If aux(i) <> i + 1 Then
                Return i + 1
            End If
        Next

        Return -1
    End Function

    Public Shared Function SmallestPositiveMissingNumber4(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim temp As Integer

        For i As Integer = 0 To size - 1
            While arr(i) <> i + 1 AndAlso arr(i) > 0 AndAlso arr(i) <= size
                temp = arr(i)
                arr(i) = arr(temp - 1)
                arr(temp - 1) = temp
            End While
        Next

        For i As Integer = 0 To size - 1
            If arr(i) <> i + 1 Then
                Return i + 1
            End If
        Next

        Return -1
    End Function

   ' Testing Code
	Public Shared Sub Main54()
        Dim arr As Integer() = New Integer() {8, 5, 6, 1, 9, 11, 2, 7, 4, 10}
        Dim size As Integer = arr.Length
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber(arr, size))
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber2(arr, size))
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber3(arr, size))
        Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber4(arr, size))
    End Sub
' SmallestPositiveMissingNumber :3
' SmallestPositiveMissingNumber :3
' SmallestPositiveMissingNumber :3
' SmallestPositiveMissingNumber :3
    Public Shared Function MaxPathSum(ByVal arr1 As Integer(), ByVal size1 As Integer, ByVal arr2 As Integer(), ByVal size2 As Integer) As Integer
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

   ' Testing Code
	Public Shared Sub Main55()
        Dim arr1 As Integer() = New Integer() {12, 13, 18, 20, 22, 26, 70}
        Dim arr2 As Integer() = New Integer() {11, 15, 18, 19, 20, 26, 30, 31}
        Console.WriteLine("Max Path Sum :: " & MaxPathSum(arr1, arr1.Length, arr2, arr2.Length))
    End Sub
' Max Path Sum :: 201

    Public Shared Function ArrayIndexMaxDiff(ByVal arr As Integer(), ByVal size As Integer) As Integer
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
        Next

        Return maxDiff
    End Function

    Public Shared Function ArrayIndexMaxDiff2(ByVal arr As Integer(), ByVal size As Integer) As Integer
        Dim rightMax As Integer() = New Integer(size - 1) {}
        rightMax(size - 1) = arr(size - 1)

        For k As Integer = size - 2 To 0  Step -1
            rightMax(k) = Math.Max(rightMax(k + 1), arr(k))
        Next

        Dim maxDiff As Integer = -1
        Dim i As Integer = 0, j As Integer = 1

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

   ' Testing Code
	Public Shared Sub Main56()
        Dim arr As Integer() = New Integer() {33, 9, 10, 3, 2, 60, 30, 33, 1}
        Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff(arr, arr.Length))
        Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff2(arr, arr.Length))
    End Sub

' ArrayIndexMaxDiff : 7
' ArrayIndexMaxDiff : 7

   ' Testing Code
	Public Shared Sub Main(ByVal args As String())
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
        Main17()
        Main18()
        Main19()
        Main20()
        Main21()
        Main22()
        Main23()
        Main24()
        Main25()
        Main26()
        Main27()
        Main28()
        Main29()
        Main30()
        Main31()
        Main32()
        Main33()
        Main34()
        Main35()
        Main36()
        Main37()
        Main38()
        Main39()
        Main40()
        Main41()
        Main42()
        Main43()
        Main44()
        Main45()
        Main46()
        Main47()
        Main48()
        Main49()
        Main50()
        Main51()
        Main52()
        Main53()
        Main54()
        Main55()
        Main56()
    End Sub
End Class
