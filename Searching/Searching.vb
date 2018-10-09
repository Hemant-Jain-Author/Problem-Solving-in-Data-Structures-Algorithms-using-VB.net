Imports System
Imports System.Collections.Generic

Public Class Searching

	Public Shared Function linearSearchUnsorted(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		For i As Integer = 0 To size - 1
			If value = arr(i) Then
				Return True
			End If
		Next i
		Return False
	End Function

	Public Shared Function linearSearchSorted(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		For i As Integer = 0 To size - 1
			If value = arr(i) Then
				Return True
			ElseIf value < arr(i) Then
				Return False
			End If
		Next i
		Return False
	End Function

	' Binary Search Algorithm - Iterative Way
	Public Shared Function Binarysearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Dim mid As Integer

		Do While low <= high
			mid = (low + high) \ 2
			If arr(mid) = value Then
				Return True
			ElseIf arr(mid) < value Then
				low = mid + 1
			Else
				high = mid - 1
			End If
		Loop
		Return False
	End Function

	Public Shared Function BinarySearchRec(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Return BinarySearchRecUtil(arr, low, high, value)
	End Function

	' Binary Search Algorithm - Recursive Way
	Public Shared Function BinarySearchRecUtil(ByVal arr() As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Boolean
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

	Public Shared Function BinarySearch_Renamed(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer, ByVal isInc As Boolean) As Integer
		Dim mid As Integer
		If [end] < start Then
			Return -1
		End If
		mid = (start + [end]) \ 2
		If key = arr(mid) Then
			Return mid
		End If
		If isInc <> False AndAlso key < arr(mid) OrElse isInc = False AndAlso key > arr(mid) Then
			Return BinarySearch_Renamed(arr, start, mid - 1, key, isInc)
		Else
			Return BinarySearch_Renamed(arr, mid + 1, [end], key, isInc)
		End If
	End Function

	Public Shared Sub Main1(ByVal args() As String)
		Dim first() As Integer = {1, 3, 5, 7, 9, 25, 30}
		Console.WriteLine(linearSearchUnsorted(first, 7, 8))
		Console.WriteLine(linearSearchSorted(first, 7, 8))
		Console.WriteLine(Binarysearch(first, 7, 8))
		Console.WriteLine(BinarySearchRec(first, 7, 8))
		Console.WriteLine(linearSearchUnsorted(first, 7, 25))
		Console.WriteLine(linearSearchSorted(first, 7, 25))
		Console.WriteLine(Binarysearch(first, 7, 25))
		Console.WriteLine(BinarySearchRec(first, 7, 25))

	End Sub

	Public Shared Sub swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Integer = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub

	Public Shared Function FirstRepeated(ByVal arr() As Integer, ByVal size As Integer) As Integer
		For i As Integer = 0 To size - 1
			For j As Integer = i + 1 To size - 1
				If arr(i) = arr(j) Then
					Return arr(i)
				End If
			Next j
		Next i
		Return 0
	End Function

	Public Shared Sub Main2(ByVal args() As String)
		Dim first() As Integer = {34, 56, 77, 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 34, 20, 30}
		Console.WriteLine(FirstRepeated(first, first.Length))
	End Sub

	Public Shared Sub printRepeating(ByVal arr() As Integer, ByVal size As Integer)
		Console.Write(" " & ControlChars.Lf & "Repeating elements are ")
		For i As Integer = 0 To size - 1
			For j As Integer = i + 1 To size - 1
				If arr(i) = arr(j) Then
					Console.Write(" " & arr(i))
				End If
			Next j
		Next i
	End Sub

	Public Shared Sub printRepeating2(ByVal arr() As Integer, ByVal size As Integer)
		Array.Sort(arr)
		Console.Write(" " & ControlChars.Lf & "Repeating elements are ")

		For i As Integer = 1 To size - 1
			If arr(i) = arr(i - 1) Then
				Console.Write(" " & arr(i))
			End If
		Next i
	End Sub

	Public Shared Sub printRepeating3(ByVal arr() As Integer, ByVal size As Integer)
		Dim hs As New HashSet(Of Integer)()
		Console.Write(" " & ControlChars.Lf & "Repeating elements are ")
		For i As Integer = 0 To size - 1
			If hs.Contains(arr(i)) Then
				Console.Write(" " & arr(i))
			Else
				hs.Add(arr(i))
			End If
		Next i
	End Sub

	Public Shared Sub printRepeating4(ByVal arr() As Integer, ByVal size As Integer, ByVal range As Integer)
		Dim count(range - 1) As Integer
		Dim i As Integer
		For i = 0 To size - 1
			count(i) = 0
		Next i
		Console.Write(" " & ControlChars.Lf & "Repeating elements are ")
		For i = 0 To size - 1
			If count(arr(i)) = 1 Then
				Console.Write(" " & arr(i))
			Else
				count(arr(i)) += 1
			End If
		Next i
	End Sub

	Public Shared Sub Main3(ByVal args() As String)
		Dim first() As Integer = {1, 3, 5, 3, 9, 1, 30}
		printRepeating(first, first.Length)
		printRepeating2(first, first.Length)
		printRepeating3(first, first.Length)
		printRepeating4(first, first.Length, 50)
	End Sub

	Public Shared Function removeDuplicates(ByVal array() As Integer, ByVal size As Integer) As Integer()
		Dim j As Integer = 0
		System.Array.Sort(array)
		For i As Integer = 1 To size - 1
			If array(i) <> array(j) Then
				j += 1
				array(j) = array(i)
			End If
		Next i
		Dim ret(j) As Integer
		System.Array.Copy(array, ret, j + 1)
		Return ret
	End Function

	Public Shared Sub Main4(ByVal args() As String)
		Dim first() As Integer = {1, 3, 5, 3, 9, 1, 30}
		Dim ret() As Integer = removeDuplicates(first, first.Length)
		For i As Integer = 0 To ret.Length - 1
			Console.Write(ret(i) & " ")
		Next i
	End Sub

	Public Shared Function findMissingNumber(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i As Integer, j As Integer, found As Integer = 0
		For i = 1 To size
			found = 0
			For j = 0 To size - 1
				If arr(j) = i Then
					found = 1
					Exit For
				End If
			Next j
			If found = 0 Then
				Return i
			End If
		Next i
		Return Integer.MaxValue
	End Function

	Public Shared Function findMissingNumber2(ByVal arr() As Integer, ByVal size As Integer, ByVal range As Integer) As Integer
		Dim i As Integer
		Dim xorSum As Integer = 0
		' get the XOR of all the numbers from 1 to range
		For i = 1 To range
			xorSum = xorSum Xor i
		Next i
		' loop through the array and get the XOR of elements
		For i = 0 To size - 1
			xorSum = xorSum Xor arr(i)
		Next i
		Return xorSum
	End Function

	Public Shared Function findMissingNumber3(ByVal arr() As Integer, ByVal size As Integer, ByVal upperRange As Integer) As Integer
		Dim st As New HashSet(Of Integer)()

		Dim i As Integer = 0
		Do While i < size
			st.Add(arr(i))
			i += 1
		Loop
		i = 1
		Do While i <= upperRange
			If st.Contains(i) = False Then
				Return i
			End If
			i += 1
		Loop
		Console.WriteLine("NoNumberMissing")
		Return -1
	End Function

	Public Shared Sub Main5(ByVal args() As String)
		Dim first() As Integer = {1, 3, 5, 4, 6, 8, 7}
		Console.WriteLine(findMissingNumber(first, first.Length))
		Console.WriteLine(findMissingNumber2(first, first.Length, 8))
		Console.WriteLine(findMissingNumber3(first, first.Length, 8))
	End Sub

	Public Shared Sub MissingValues(ByVal arr() As Integer, ByVal size As Integer)
		Array.Sort(arr)
		Dim value As Integer = arr(0)
		Dim i As Integer = 0
		Do While i < size
			If value = arr(i) Then
				value += 1
				i += 1
			Else
				Console.WriteLine(value)
				value += 1
			End If
		Loop
	End Sub

	Public Shared Sub MissingValues2(ByVal arr() As Integer, ByVal size As Integer)
		Dim ht As New HashSet(Of Integer)()
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
		Next i
		Dim j As Integer = minVal
		Do While j < maxVal + 1
			If ht.Contains(j) = False Then
				Console.WriteLine(j)
			End If
			j += 1
		Loop
	End Sub

	Public Shared Sub Main6(ByVal args() As String)
		Dim arr() As Integer = {1, 9, 2, 8, 3, 7, 4, 6}
		Dim size As Integer = arr.Length
		MissingValues(arr, size)
		MissingValues2(arr, size)
	End Sub

	Public Shared Sub OddCount(ByVal arr() As Integer, ByVal size As Integer)
		Dim ctr As New Dictionary(Of Integer, Integer)()
		Dim count As Integer = 0

		For i As Integer = 0 To size - 1
			If ctr.ContainsKey(arr(i)) Then
				ctr(arr(i)) = ctr(arr(i)) + 1
			Else
				ctr(arr(i)) = 1
			End If
		Next i
		For i As Integer = 0 To size - 1
			If ctr.ContainsKey(arr(i)) AndAlso (ctr(arr(i)) Mod 2 = 1) Then
				Console.WriteLine(arr(i))
				count += 1
				ctr.Remove(arr(i))
			End If
		Next i
		Console.WriteLine("Odd count is :: " & count)
	End Sub

	Public Shared Sub OddCount2(ByVal arr() As Integer, ByVal size As Integer)
		Dim xorSum As Integer = 0
		Dim first As Integer = 0
		Dim second As Integer = 0
		Dim setBit As Integer
		'	
		'		* xor of all elements in arr[] even occurrence will cancel each other. sum will
		'		* contain sum of two odd elements.
		'		
		For i As Integer = 0 To size - 1
			xorSum = xorSum Xor arr(i)
		Next i

		' Rightmost set bit. 
		setBit = xorSum And Not (xorSum - 1)

		'	
		'		* Dividing elements in two group: Elements having setBit bit as 1. Elements
		'		* having setBit bit as 0. Even elements cancelled themselves if group and we
		'		* get our numbers.
		'		
		For i As Integer = 0 To size - 1
			If (arr(i) And setBit) <> 0 Then
				first = first Xor arr(i)
			Else
				second = second Xor arr(i)
			End If
		Next i
		Console.WriteLine(first + second)
	End Sub

	Public Shared Sub SumDistinct(ByVal arr() As Integer, ByVal size As Integer)
		Dim sum As Integer = 0
		Array.Sort(arr)
		Dim i As Integer = 0
		Do While i < (size - 1)
			If arr(i) <> arr(i + 1) Then
				sum += arr(i)
			End If
			i += 1
		Loop
		sum += arr(size - 1)
		Console.WriteLine(sum)
	End Sub

	Public Shared Sub minAbsSumPair(ByVal arr() As Integer, ByVal size As Integer)
		Dim l, r, minSum, sum, minFirst, minSecond As Integer
		' Array should have at least two elements
		If size < 2 Then
			Console.WriteLine("Invalid Input")
			Return
		End If
		' Initialization of values
		minFirst = 0
		minSecond = 1
		minSum = Math.Abs(arr(0) + arr(1))
		l = 0
		Do While l < size - 1
			For r = l + 1 To size - 1
				sum = Math.Abs(arr(l) + arr(r))
				If sum < minSum Then
					minSum = sum
					minFirst = l
					minSecond = r
				End If
			Next r
			l += 1
		Loop
		Console.WriteLine(" Minimum sum elements are : " & arr(minFirst) & " , " & arr(minSecond))
	End Sub

	Public Shared Sub minAbsSumPair2(ByVal arr() As Integer, ByVal size As Integer)
		Dim l, r, minSum, sum, minFirst, minSecond As Integer
		' Array should have at least two elements
		If size < 2 Then
			Console.WriteLine("Invalid Input")
			Return
		End If
		Array.Sort(arr) ' Array.Sort(arr);

		' Initialization of values
		minFirst = 0
		minSecond = size - 1
		minSum = Math.Abs(arr(minFirst) + arr(minSecond))
		l = 0
		r = size - 1
		Do While l < r
			sum = (arr(l) + arr(r))
			If Math.Abs(sum) < minSum Then
				minSum = Math.Abs(sum) '/ just corrected......hemant
				minFirst = l
				minSecond = r
			End If
			If sum < 0 Then
				l += 1
			ElseIf sum > 0 Then
				r -= 1
			Else
				Exit Do
			End If
		Loop
		Console.WriteLine(" Minimum sum pair : " & arr(minFirst) & " , " & arr(minSecond))
	End Sub

	Public Shared Sub Main7(ByVal str() As String)
		Dim first() As Integer = {1, 5, -10, 3, 2, -6, 8, 9, 6}
		minAbsSumPair2(first, first.Length)
		minAbsSumPair(first, first.Length)

	End Sub

	Public Shared Function FindPair(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		For i As Integer = 0 To size - 1
			For j As Integer = i + 1 To size - 1
				If (arr(i) + arr(j)) = value Then
					Console.WriteLine("The pair is : " & arr(i) & "," & arr(j))
					Return True
				End If
			Next j
		Next i
		Return False
	End Function

	Public Shared Function FindPair2(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim first As Integer = 0, second As Integer = size - 1
		Dim curr As Integer
		Array.Sort(arr) ' Array.Sort(arr);
		Do While first < second
			curr = arr(first) + arr(second)
			If curr = value Then
				Console.WriteLine("The pair is " & arr(first) & "," & arr(second))
				Return True
			ElseIf curr < value Then
				first += 1
			Else
				second -= 1
			End If
		Loop
		Return False
	End Function

	Public Shared Function FindPair3(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim hs As New HashSet(Of Integer)()
		For i As Integer = 0 To size - 1
			If hs.Contains(value - arr(i)) Then
				Console.WriteLine("The pair is : " & arr(i) & " , " & (value - arr(i)))
				Return True
			End If
			hs.Add(arr(i))
		Next i
		Return False
	End Function

	Public Shared Sub Main8(ByVal args() As String)
		Dim first() As Integer = {1, 5, 4, 3, 2, 7, 8, 9, 6}
		Console.WriteLine(FindPair(first, first.Length, 8))
		Console.WriteLine(FindPair2(first, first.Length, 8))
		Console.WriteLine(FindPair3(first, first.Length, 8))

	End Sub

	Public Shared Function FindDifference(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		For i As Integer = 0 To size - 1
			For j As Integer = i + 1 To size - 1
				If Math.Abs(arr(i) - arr(j)) = value Then
					Console.WriteLine("The pair is:: " & arr(i) & " & " & arr(j))
					Return True
				End If
			Next j
		Next i
		Return False
	End Function

	Public Shared Function FindDifference2(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim first As Integer = 0
		Dim second As Integer = 0
		Dim diff As Integer
		Array.Sort(arr)
		Do While first < size AndAlso second < size
			diff = Math.Abs(arr(first) - arr(second))
			If diff = value Then
				Console.WriteLine("The pair is::" & arr(first) & " & " & arr(second))
				Return True
			ElseIf diff > value Then
				first += 1
			Else
				second += 1
			End If
		Loop
		Return False
	End Function

	Public Shared Function findMinDiff(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Array.Sort(arr)
		Dim diff As Integer = 9999999

		Dim i As Integer = 0
		Do While i < (size - 1)
			If (arr(i + 1) - arr(i)) < diff Then
				diff = arr(i + 1) - arr(i)
			End If
			i += 1
		Loop
		Return diff
	End Function

	Public Shared Function MinDiffPair(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer) As Integer
		Dim minDiff As Integer = 9999999
		Dim first As Integer = 0
		Dim second As Integer = 0
		Dim out1 As Integer = 0, out2 As Integer = 0, diff As Integer
		Array.Sort(arr1)
		Array.Sort(arr2)
		Do While first < size1 AndAlso second < size2
			diff = Math.Abs(arr1(first) - arr2(second))
			If minDiff > diff Then
				minDiff = diff
				out1 = arr1(first)
				out2 = arr2(second)
			End If
			If arr1(first) < arr2(second) Then
				first += 1
			Else
				second += 1
			End If
		Loop
		Console.WriteLine("The pair is :: " & out1 + out2)
		Console.WriteLine("Minimum difference is :: " & minDiff)
		Return minDiff
	End Function

	Public Shared Sub Main9(ByVal args() As String)
		Dim first() As Integer = {1, 5, 4, 3, 2, 7, 8, 9, 6}
		Console.WriteLine(FindDifference(first, first.Length, 6))
		Console.WriteLine(FindDifference2(first, first.Length, 6))
		Console.WriteLine(findMinDiff(first, first.Length))
		Console.WriteLine(MinDiffPair(first, first.Length, first, first.Length))
	End Sub

	Public Shared Sub ClosestPair(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer)
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
			Next j
		Next i
		Console.WriteLine("closest pair is ::" & first + second)
	End Sub

	Public Shared Sub ClosestPair2(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer)
		Dim first As Integer = 0, second As Integer = 0
		Dim start As Integer = 0
		Dim [stop] As Integer = size - 1
		Dim diff, curr As Integer
		Array.Sort(arr)
		diff = 9999999
		If True Then
			Do While start < [stop]
				curr = (value - (arr(start) + arr([stop])))
				If Math.Abs(curr) < diff Then
					diff = Math.Abs(curr)
					first = arr(start)
					second = arr([stop])
				End If
				If curr = 0 Then
					Exit Do
				ElseIf curr > 0 Then
					start += 1
				Else
					[stop] -= 1
				End If
			Loop
		End If
		Console.WriteLine("closest pair is :: " & first + second)
	End Sub

	Public Shared Sub Main10(ByVal args() As String)
		Dim first() As Integer = {1, 5, 4, 3, 2, 7, 8, 9, 6}
		ClosestPair(first, first.Length, 6)
		ClosestPair2(first, first.Length, 6)
	End Sub

	Public Shared Function SumPairRestArray(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim total, low, high, curr, value As Integer
		Array.Sort(arr)
		total = 0
		For i As Integer = 0 To size - 1
			total += arr(i)
		Next i
		value = total \ 2
		low = 0
		high = size - 1
		Do While low < high
			curr = arr(low) + arr(high)
			If curr = value Then
				Console.WriteLine("Pair is :: " & arr(low) + arr(high))
				Return True
			ElseIf curr < value Then
				low += 1
			Else
				high -= 1
			End If
		Loop
		Return False
	End Function

	Public Shared Sub ZeroSumTriplets(ByVal arr() As Integer, ByVal size As Integer)
		Dim i As Integer = 0
		Do While i < (size - 2)
			Dim j As Integer = i + 1
			Do While j < (size - 1)
				For k As Integer = j + 1 To size - 1
					If arr(i) + arr(j) + arr(k) = 0 Then
						Console.WriteLine("Triplet :: " & arr(i) + arr(j) + arr(k))
					End If
				Next k
				j += 1
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub ZeroSumTriplets2(ByVal arr() As Integer, ByVal size As Integer)
		Dim start, [stop] As Integer
		Array.Sort(arr)
		Dim i As Integer = 0
		Do While i < (size - 2)
			start = i + 1
			[stop] = size - 1

			Do While start < [stop]
				If arr(i) + arr(start) + arr([stop]) = 0 Then
					Console.WriteLine("Triplet :: " & arr(i) + arr(start) + arr([stop]))
					start += 1
					[stop] -= 1
				ElseIf arr(i) + arr(start) + arr([stop]) > 0 Then
					[stop] -= 1
				Else
					start += 1
				End If
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub findTriplet(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer)
		Dim i As Integer = 0
		Do While i < (size - 2)
			Dim j As Integer = i + 1
			Do While j < (size - 1)
				For k As Integer = j + 1 To size - 1
					If (arr(i) + arr(j) + arr(k)) = value Then
						Console.WriteLine("Triplet :: " & arr(i) + arr(j) + arr(k))
					End If
				Next k
				j += 1
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub findTriplet2(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer)
		Dim start, [stop] As Integer
		Array.Sort(arr)
		Dim i As Integer = 0
		Do While i < size - 2
			start = i + 1
			[stop] = size - 1
			Do While start < [stop]
				If arr(i) + arr(start) + arr([stop]) = value Then
					Console.WriteLine("Triplet ::" & arr(i) + arr(start) + arr([stop]))
					start += 1
					[stop] -= 1
				ElseIf arr(i) + arr(start) + arr([stop]) > value Then
					[stop] -= 1
				Else
					start += 1
				End If
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub ABCTriplet(ByVal arr() As Integer, ByVal size As Integer)
		Dim start, [stop] As Integer
		Array.Sort(arr)
		Dim i As Integer = 0
		Do While i < (size - 2)
			start = i + 1
			[stop] = size - 1
			Do While start < [stop]
				If arr(i) = arr(start) + arr([stop]) Then
					Console.WriteLine("Triplet ::%d, %d, %d" & arr(i) + arr(start) + arr([stop]))
					start += 1
					[stop] -= 1
				ElseIf arr(i) > arr(start) + arr([stop]) Then
					[stop] -= 1
				Else
					start += 1
				End If
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub SmallerThenTripletCount(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer)
		Dim start, [stop] As Integer
		Dim count As Integer = 0
		Array.Sort(arr)

		Dim i As Integer = 0
		Do While i < (size - 2)
			start = i + 1
			[stop] = size - 1
			Do While start < [stop]
				If arr(i) + arr(start) + arr([stop]) >= value Then
					[stop] -= 1
				Else
					count += [stop] - start
					start += 1
				End If
			Loop
			i += 1
		Loop
		Console.WriteLine(count)
	End Sub

	Public Shared Sub APTriplets(ByVal arr() As Integer, ByVal size As Integer)
		Dim i, j, k As Integer
		i = 1
		Do While i < size - 1
			j = i - 1
			k = i + 1
			Do While j >= 0 AndAlso k < size
				If arr(j) + arr(k) = 2 * arr(i) Then
					Console.WriteLine("Triplet ::" & arr(j) + arr(i) + arr(k))
					k += 1
					j -= 1
				ElseIf arr(j) + arr(k) < 2 * arr(i) Then
					k += 1
				Else
					j -= 1
				End If
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Sub GPTriplets(ByVal arr() As Integer, ByVal size As Integer)
		Dim i, j, k As Integer
		i = 1
		Do While i < size - 1
			j = i - 1
			k = i + 1
			Do While j >= 0 AndAlso k < size
				If arr(j) * arr(k) = arr(i) * arr(i) Then
					Console.WriteLine("Triplet is :: " & arr(j) + arr(i) + arr(k))
					k += 1
					j -= 1
				ElseIf arr(j) + arr(k) < 2 * arr(i) Then
					k += 1
				Else
					j -= 1
				End If
			Loop
			i += 1
		Loop
	End Sub

	Public Shared Function numberOfTriangles(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i As Integer, j As Integer, k As Integer, count As Integer = 0
		i = 0
		Do While i < (size - 2)
			j = i + 1
			Do While j < (size - 1)
				For k = j + 1 To size - 1
					If arr(i) + arr(j) > arr(k) Then
						count += 1
					End If
				Next k
				j += 1
			Loop
			i += 1
		Loop
		Return count
	End Function

	Public Shared Function numberOfTriangles2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i As Integer, j As Integer, k As Integer, count As Integer = 0
		Array.Sort(arr)

		i = 0
		Do While i < (size - 2)
			k = i + 2
			j = i + 1
			Do While j < (size - 1)
				'			
				'				* if sum of arr[i] & arr[j] is greater arr[k] then sum of arr[i] & arr[j + 1]
				'				* is also greater than arr[k] this improvement make algo O(n2)
				'				
				Do While k < size AndAlso arr(i) + arr(j) > arr(k)
					k += 1
				Loop

				count += k - j - 1
				j += 1
			Loop
			i += 1
		Loop
		Return count
	End Function

	Public Shared Function getMax(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim max As Integer = arr(0), count As Integer = 1, maxCount As Integer = 1
		For i As Integer = 0 To size - 1
			count = 1
			For j As Integer = i + 1 To size - 1
				If arr(i) = arr(j) Then
					count += 1
				End If
			Next j
			If count > maxCount Then
				max = arr(i)
				maxCount = count
			End If
		Next i
		Return max
	End Function

	Public Shared Function getMax2(ByVal arr() As Integer, ByVal size As Integer) As Integer
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
		Next i
		Return max
	End Function

	Public Shared Function getMax3(ByVal arr() As Integer, ByVal size As Integer, ByVal range As Integer) As Integer
		Dim max As Integer = arr(0), maxCount As Integer = 1
		Dim count(range - 1) As Integer
		For i As Integer = 0 To size - 1
			count(arr(i)) += 1
			If count(arr(i)) > maxCount Then
				maxCount = count(arr(i))
				max = arr(i)
			End If
		Next i
		Return max
	End Function

	Public Shared Sub Main11(ByVal args() As String)
		Dim first() As Integer = {1, 30, 5, 13, 9, 31, 5}
		Console.WriteLine(getMax(first, first.Length))
		Console.WriteLine(getMax2(first, first.Length))
		Console.WriteLine(getMax3(first, first.Length, 50))
	End Sub

	Public Shared Function getMajority(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim max As Integer = 0, count As Integer = 0, maxCount As Integer = 0
		For i As Integer = 0 To size - 1
			For j As Integer = i + 1 To size - 1
				If arr(i) = arr(j) Then
					count += 1
				End If
			Next j
			If count > maxCount Then
				max = arr(i)
				maxCount = count
			End If
		Next i
		If maxCount > size \ 2 Then
			Return max
		Else
			Return 0
		End If
	End Function

	Public Shared Function getMajority2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim majIndex As Integer = size \ 2, count As Integer = 1
		Dim candidate As Integer
		Array.Sort(arr)
		candidate = arr(majIndex)
		count = 0
		For i As Integer = 0 To size - 1
			If arr(i) = candidate Then
				count += 1
			End If
		Next i
		If count > size \ 2 Then
			Return arr(majIndex)
		Else
			Return Integer.MinValue
		End If
	End Function

	Public Shared Function getMajority3(ByVal arr() As Integer, ByVal size As Integer) As Integer
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
		Next i
		candidate = arr(majIndex)
		count = 0
		For i = 0 To size - 1
			If arr(i) = candidate Then
				count += 1
			End If
		Next i
		If count > size \ 2 Then
			Return arr(majIndex)
		Else
			Return 0
		End If
	End Function

	Public Shared Sub Main12(ByVal args() As String)
		Dim first() As Integer = {1, 5, 5, 13, 5, 31, 5}
		Console.WriteLine(getMajority(first, first.Length))
		Console.WriteLine(getMajority2(first, first.Length))
		Console.WriteLine(getMajority3(first, first.Length))
	End Sub

	Public Shared Function getMedian(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Array.Sort(arr)
		Return arr(size \ 2)
	End Function

	Public Shared Function SearchBotinicArrayMax(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim start As Integer = 0, [end] As Integer = size - 1
		Dim mid As Integer = (start + [end]) \ 2
		Dim maximaFound As Integer = 0
		If size < 3 Then
			Console.WriteLine("error")
			Return 0
		End If
		Do While start <= [end]
			mid = (start + [end]) \ 2
			If arr(mid - 1) < arr(mid) AndAlso arr(mid + 1) < arr(mid) Then ' maxima
				maximaFound = 1
				Exit Do
			ElseIf arr(mid - 1) < arr(mid) AndAlso arr(mid) < arr(mid + 1) Then ' increasing
				start = mid + 1
			ElseIf arr(mid - 1) > arr(mid) AndAlso arr(mid) > arr(mid + 1) Then ' decreasing
				[end] = mid - 1
			Else
				Exit Do
			End If
		Loop
		If maximaFound = 0 Then
			Console.WriteLine("error")
			Return 0
		End If
		Return arr(mid)
	End Function

	Public Shared Function SearchBitonicArray(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Dim max As Integer = FindMaxBitonicArray(arr, size)
		Dim k As Integer = BinarySearch_Renamed(arr, 0, max, key, True)
		If k <> -1 Then
			Return k
		Else
			Return BinarySearch_Renamed(arr, max + 1, size - 1, key, False)
		End If
	End Function

	Public Shared Function FindMaxBitonicArray(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim start As Integer = 0, [end] As Integer = size - 1, mid As Integer
		If size < 3 Then
			Console.WriteLine("error")
			Return -1
		End If
		Do While start <= [end]
			mid = (start + [end]) \ 2
			If arr(mid - 1) < arr(mid) AndAlso arr(mid + 1) < arr(mid) Then ' maxima
				Return mid
			ElseIf arr(mid - 1) < arr(mid) AndAlso arr(mid) < arr(mid + 1) Then ' increasing
				start = mid + 1
			ElseIf arr(mid - 1) > arr(mid) AndAlso arr(mid) > arr(mid + 1) Then ' increasing
				[end] = mid - 1
			Else
				Exit Do
			End If
		Loop
		Console.WriteLine("error")
		Return -1
	End Function

	Public Shared Sub Main13(ByVal args() As String)
		Dim first() As Integer = {1, 5, 10, 13, 20, 30, 8, 7, 6}

		Console.WriteLine(SearchBotinicArrayMax(first, first.Length))
		Console.WriteLine(SearchBitonicArray(first, first.Length, 7))
	End Sub

	Public Shared Function findKeyCount(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Dim count As Integer = 0
		For i As Integer = 0 To size - 1
			If arr(i) = key Then
				count += 1
			End If
		Next i
		Return count
	End Function

	Public Shared Function findKeyCount2(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Dim firstIndex_Renamed, lastIndex As Integer
		firstIndex_Renamed = findFirstIndex(arr, 0, size - 1, key)
		lastIndex = findLastIndex(arr, 0, size - 1, key)
		Return (lastIndex - firstIndex_Renamed + 1)
	End Function

	' Using binary search method. 
	Public Shared Function FirstIndex(ByVal arr() As Integer, ByVal size As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Integer
		Dim mid As Integer = 0
		If high >= low Then
			mid = (low + high) \ 2
		End If

		'	
		'		* Find first occurrence of value, either it should be the first element of the
		'		* array or the value before it is smaller than it.
		'		
		If (mid = 0 OrElse arr(mid - 1) < value) AndAlso (arr(mid) = value) Then
			Return mid
		ElseIf arr(mid) < value Then
			Return FirstIndex(arr, size, mid + 1, high, value)
		Else
			Return FirstIndex(arr, size, low, mid - 1, value)
		End If
	End Function

	Public Shared Function isMajority(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim majority As Integer = arr(size \ 2)
		Dim i As Integer = FirstIndex(arr, size, 0, size - 1, majority)
		'	
		'		* we are using majority element form array so we will get some valid index
		'		* always.
		'		
		If ((i + size \ 2) <= (size - 1)) AndAlso arr(i + size \ 2) = majority Then
			Return True
		Else
			Return False
		End If
	End Function
	Public Shared Function findFirstIndex(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer) As Integer
		Dim mid As Integer
		If [end] < start Then
			Return -1
		End If
		mid = (start + [end]) \ 2
		If key = arr(mid) AndAlso (mid = start OrElse arr(mid - 1) <> key) Then
			Return mid
		End If
		If key <= arr(mid) Then ' <= is us the number.t in sorted array.
			Return findFirstIndex(arr, start, mid - 1, key)
		Else
			Return findFirstIndex(arr, mid + 1, [end], key)
		End If
	End Function

	Public Shared Function findLastIndex(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer) As Integer
		If [end] < start Then
			Return -1
		End If
		Dim mid As Integer = (start + [end]) \ 2
		If key = arr(mid) AndAlso (mid = [end] OrElse arr(mid + 1) <> key) Then
			Return mid
		End If
		If key < arr(mid) Then ' <
			Return findLastIndex(arr, start, mid - 1, key)
		Else
			Return findLastIndex(arr, mid + 1, [end], key)
		End If
	End Function

	Public Shared Sub Main14(ByVal args() As String)
		Dim first() As Integer = {1, 5, 10, 13, 20, 30, 8, 7, 6}
		Console.WriteLine(findKeyCount(first, first.Length, 6))
		Console.WriteLine(findKeyCount2(first, first.Length, 6))
	End Sub

	Public Shared Function maxProfit(ByVal stocks() As Integer, ByVal size As Integer) As Integer
		Dim buy As Integer = 0, sell As Integer = 0
		Dim curMin As Integer = 0
		Dim currProfit As Integer = 0
		Dim maxProfit_Renamed As Integer = 0
		For i As Integer = 0 To size - 1
			If stocks(i) < stocks(curMin) Then
				curMin = i
			End If
			currProfit = stocks(i) - stocks(curMin)
			If currProfit > maxProfit_Renamed Then
				buy = curMin
				sell = i
				maxProfit_Renamed = currProfit
			End If
		Next i
		Console.WriteLine("Purchase day is- " & buy & " at price " & stocks(buy))
		Console.WriteLine("Sell day is- " & sell & " at price " & stocks(sell))
		Return maxProfit_Renamed
	End Function

	Public Shared Sub Main15(ByVal args() As String)
		Dim first() As Integer = {10, 150, 6, 67, 61, 16, 86, 6, 67, 78, 150, 3, 28, 143}
		Console.WriteLine(maxProfit(first, first.Length))
	End Sub

	Public Shared Function findMedian(ByVal arrFirst() As Integer, ByVal sizeFirst As Integer, ByVal arrSecond() As Integer, ByVal sizeSecond As Integer) As Integer
		Dim medianIndex As Integer = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) Mod 2) \ 2 ' cealing
		' function.
		Dim i As Integer = 0, j As Integer = 0
		Dim count As Integer = 0
		Do While count < medianIndex - 1
			If i < sizeFirst - 1 AndAlso arrFirst(i) < arrSecond(j) Then
				i += 1
			Else
				j += 1
			End If
			count += 1
		Loop
		If arrFirst(i) < arrSecond(j) Then
			Return arrFirst(i)
		Else
			Return arrSecond(j)
		End If
	End Function

	Public Shared Sub Main16(ByVal args() As String)
		Dim first() As Integer = {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
		Dim second() As Integer = {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
		Console.WriteLine(findMedian(first, first.Length, second, second.Length))
	End Sub

	Public Shared Function BinarySearch01(ByVal arr() As Integer, ByVal size As Integer) As Integer
		If size = 1 AndAlso arr(0) = 1 Then
			Return 0
		End If
		Return BinarySearch01Util(arr, 0, size - 1)
	End Function

	Public Shared Function BinarySearch01Util(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Integer
		If [end] < start Then
			Return -1
		End If
		Dim mid As Integer = (start + [end]) \ 2
		If 1 = arr(mid) AndAlso 0 = arr(mid - 1) Then
			Return mid
		End If
		If 0 = arr(mid) Then
			Return BinarySearch01Util(arr, mid + 1, [end])
		Else
			Return BinarySearch01Util(arr, start, mid - 1)
		End If
	End Function

	Public Shared Sub Main17(ByVal args() As String)
		Dim first() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1}
		Console.WriteLine(BinarySearch01(first, first.Length))
	End Sub

	Public Shared Function RotationMaxUtil(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Integer
		If [end] <= start Then
			Return arr(start)
		End If
		Dim mid As Integer = (start + [end]) \ 2
		If arr(mid) > arr(mid + 1) Then
			Return arr(mid)
		End If

		If arr(start) <= arr(mid) Then ' increasing part.
			Return RotationMaxUtil(arr, mid + 1, [end])
		Else
			Return RotationMaxUtil(arr, start, mid - 1)
		End If
	End Function

	Public Shared Function RotationMax(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Return RotationMaxUtil(arr, 0, size - 1)
	End Function

	Public Shared Function FindRotationMaxUtil(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Integer
		' single element case. 
		If [end] <= start Then
			Return start
		End If

		Dim mid As Integer = (start + [end]) \ 2
		If arr(mid) > arr(mid + 1) Then
			Return mid
		End If

		If arr(start) <= arr(mid) Then ' increasing part.
			Return FindRotationMaxUtil(arr, mid + 1, [end])
		Else
			Return FindRotationMaxUtil(arr, start, mid - 1)
		End If
	End Function

	Public Shared Function FindRotationMax(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Return FindRotationMaxUtil(arr, 0, size - 1)
	End Function

	Public Shared Function CountRotation(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim maxIndex As Integer = FindRotationMaxUtil(arr, 0, size - 1)
		Return (maxIndex + 1) Mod size
	End Function

	Public Shared Function BinarySearchRotateArrayUtil(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer) As Integer
		If [end] < start Then
			Return -1
		End If
		Dim mid As Integer = (start + [end]) \ 2
		If key = arr(mid) Then
			Return mid
		End If
		If arr(mid) > arr(start) Then
			If arr(start) <= key AndAlso key < arr(mid) Then
				Return BinarySearchRotateArrayUtil(arr, start, mid - 1, key)
			Else
				Return BinarySearchRotateArrayUtil(arr, mid + 1, [end], key)
			End If
		Else
			If arr(mid) < key AndAlso key <= arr([end]) Then
				Return BinarySearchRotateArrayUtil(arr, mid + 1, [end], key)
			Else
				Return BinarySearchRotateArrayUtil(arr, start, mid - 1, key)
			End If
		End If
	End Function

	Public Shared Function BinarySearchRotateArray(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Return BinarySearchRotateArrayUtil(arr, 0, size - 1, key)
	End Function

	Public Shared Sub Main18(ByVal args() As String)
		Dim first() As Integer = {34, 56, 77, 1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
		Console.WriteLine(BinarySearchRotateArray(first, first.Length, 20))
		Console.WriteLine(CountRotation(first, first.Length))
		Console.WriteLine(first(FindRotationMax(first, first.Length)))
	End Sub

	Public Shared Function minAbsDiffAdjCircular(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim diff As Integer = 9999999
		If size < 2 Then
			Return -1
		End If

		For i As Integer = 0 To size - 1
			diff = Math.Min(diff, Math.Abs(arr(i) - arr((i + 1) Mod size)))
		Next i

		Return diff
	End Function

	'
	'	* Testing code
	'	
	Public Shared Sub Main19(ByVal str() As String)
		Dim arr() As Integer = {5, 29, 18, 51, 11}
		Console.WriteLine(minAbsDiffAdjCircular(arr, arr.Length))
	End Sub

	Public Shared Sub swapch(ByVal arr() As Char, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Char = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub

	Public Shared Sub transformArrayAB1(ByVal arr() As Char, ByVal size As Integer)
		Dim N As Integer = size \ 2, i As Integer, j As Integer
		For i = 1 To N - 1
			For j = 0 To i - 1
				swapch(arr, N - i + 2 * j, N - i + 2 * j + 1)
			Next j
		Next i
	End Sub

	Public Shared Sub Main20(ByVal args() As String)
		Dim str() As Char = "aaaabbbb".ToCharArray()
		transformArrayAB1(str, str.Length)
		Console.WriteLine(str)
	End Sub

	Public Shared Function checkPermutation(ByVal array1() As Char, ByVal size1 As Integer, ByVal array2() As Char, ByVal size2 As Integer) As Boolean
		If size1 <> size2 Then
			Return False
		End If
		Array.Sort(array1)
		Array.Sort(array2)
		For i As Integer = 0 To size1 - 1
			If array1(i) <> array2(i) Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Sub Main21(ByVal args() As String)
		Dim str1() As Char = "aaaabbbb".ToCharArray()
		Dim str2() As Char = "bbaaaabb".ToCharArray()

		Console.WriteLine(checkPermutation(str1, str1.Length, str2, str2.Length))
	End Sub

	Public Shared Function FindElementIn2DArray(ByVal arr()() As Integer, ByVal r As Integer, ByVal c As Integer, ByVal value As Integer) As Boolean
		Dim row As Integer = 0
		Dim column As Integer = c - 1
		Do While row < r AndAlso column >= 0
			If arr(row)(column) = value Then
				Return True
			ElseIf arr(row)(column) > value Then
				column -= 1
			Else
				row += 1
			End If
		Loop
		Return False
	End Function

	Public Shared Function isAP(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		If size <= 1 Then
			Return True
		End If

		Array.Sort(arr)
		Dim diff As Integer = arr(1) - arr(0)
		For i As Integer = 2 To size - 1
			If arr(i) - arr(i - 1) <> diff Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Function isAP2(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim first As Integer = 9999999
		Dim second As Integer = 9999999
		Dim value As Integer
		Dim hs As New HashSet(Of Integer)()
		For i As Integer = 0 To size - 1
			If arr(i) < first Then
				second = first
				first = arr(i)
			ElseIf arr(i) < second Then
				second = arr(i)
			End If
		Next i
		Dim diff As Integer = second - first

		For i As Integer = 0 To size - 1
			If hs.Contains(arr(i)) Then
				Return False
			End If
			hs.Add(arr(i))
		Next i
		For i As Integer = 0 To size - 1
			value = first + i * diff
			If Not hs.Contains(value) Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Function isAP3(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim first As Integer = 9999999
		Dim second As Integer = 9999999
		Dim count(size - 1) As Integer
		Dim index As Integer = -1
		For i As Integer = 0 To size - 1
			If arr(i) < first Then
				second = first
				first = arr(i)
			ElseIf arr(i) < second Then
				second = arr(i)
			End If
		Next i
		Dim diff As Integer = second - first

		For i As Integer = 0 To size - 1
			index = (arr(i) - first) \ diff
		Next i
		If index > size - 1 OrElse count(index) <> 0 Then
			Return False
		End If
		count(index) = 1

		For i As Integer = 0 To size - 1
			If count(i) <> 1 Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Function findBalancedPoint(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim first As Integer = 0
		Dim second As Integer = 0
		For i As Integer = 1 To size - 1
			second += arr(i)
		Next i

		For i As Integer = 0 To size - 1
			If first = second Then
				Console.WriteLine(i)
				Return i
			End If
			If i < size - 1 Then
				first += arr(i)
			End If
			second -= arr(i + 1)
		Next i
		Return -1
	End Function

	'
	'	* Testing code
	'	
	Public Shared Sub Main22(ByVal args() As String)
		Dim arr() As Integer = {-7, 1, 5, 2, -4, 3, 0}
		Console.WriteLine(findBalancedPoint(arr, arr.Length))

	End Sub


	Public Shared Function findFloor(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim start As Integer = 0
		Dim [stop] As Integer = size - 1
		Dim mid As Integer
		Do While start <= [stop]
			mid = (start + [stop]) \ 2
			'		
			'			* search value is equal to arr[mid] value.. search value is greater than mid
			'			* index value and less than mid+1 index value. value is greater than
			'			* arr[size-1] then floor is arr[size-1]
			'			
			If arr(mid) = value OrElse (arr(mid) < value AndAlso (mid = size - 1 OrElse arr(mid + 1) > value)) Then
				Return mid
			ElseIf arr(mid) < value Then
				start = mid + 1
			Else
				[stop] = mid - 1
			End If
		Loop
		Return -1
	End Function

	Public Shared Function findCeil(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim start As Integer = 0
		Dim [stop] As Integer = size - 1
		Dim mid As Integer

		Do While start <= [stop]
			mid = (start + [stop]) \ 2
			'		
			'			* search value is equal to arr[mid] value.. search value is less than mid index
			'			* value and greater than mid-1 index value. value is less than arr[0] then ceil
			'			* is arr[0]
			'			
			If arr(mid) = value OrElse (arr(mid) > value AndAlso (mid = 0 OrElse arr(mid - 1) < value)) Then
				Return mid
			ElseIf arr(mid) < value Then
				start = mid + 1
			Else
				[stop] = mid - 1
			End If
		Loop
		Return -1
	End Function

	Public Shared Function ClosestNumber(ByVal arr() As Integer, ByVal size As Integer, ByVal num As Integer) As Integer
		Dim start As Integer = 0
		Dim [stop] As Integer = size - 1
		Dim output As Integer = -1
		Dim minDist As Integer = 9999
		Dim mid As Integer

		Do While start <= [stop]
			mid = (start + [stop]) \ 2
			If minDist > Math.Abs(arr(mid) - num) Then
				minDist = Math.Abs(arr(mid) - num)
				output = arr(mid)
			End If
			If arr(mid) = num Then
				Exit Do
			ElseIf arr(mid) > num Then
				[stop] = mid - 1
			Else
				start = mid + 1
			End If
		Loop
		Return output
	End Function

	Public Shared Function DuplicateKDistance(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Boolean
		Dim hm As New Dictionary(Of Integer, Integer)()

		For i As Integer = 0 To size - 1
			If hm.ContainsKey(arr(i)) AndAlso i - hm(arr(i)) <= k Then
				Console.WriteLine("Value:" & arr(i) & " Index: " & hm(arr(i)) & " & " & i)
				Return True
			Else
				hm(arr(i)) = i
			End If
		Next i
		Return False
	End Function

	'
	'	* Testing code
	'	
	Public Shared Sub Main23(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 1, 4, 5}
		DuplicateKDistance(arr, arr.Length, 3)
	End Sub

	Public Shared Sub frequencyCounts(ByVal arr() As Integer, ByVal size As Integer)
		Dim index As Integer
		For i As Integer = 0 To size - 1
			Do While arr(i) > 0
				index = arr(i) - 1
				If arr(index) > 0 Then
					arr(i) = arr(index)
					arr(index) = -1
				Else
					arr(index) -= 1
					arr(i) = 0
				End If
			Loop
		Next i
		For i As Integer = 0 To size - 1
			Console.WriteLine((i + 1) + Math.Abs(arr(i)))
		Next i
	End Sub

	Public Shared Function KLargestElements(ByVal arrIn() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim arr(size - 1) As Integer
		For i As Integer = 0 To size - 1
			arr(i) = arrIn(i)
		Next i

		Array.Sort(arr)
		For i As Integer = 0 To size - 1
			If arrIn(i) >= arr(size - k) Then
				Console.WriteLine(arrIn(i))
				Return arrIn(i)
			End If
		Next i
		Return -1
	End Function

	Public Shared Sub QuickSelectUtil(ByVal arr() As Integer, ByVal lower As Integer, ByVal upper As Integer, ByVal k As Integer)
		If upper <= lower Then
			Return
		End If

		Dim pivot As Integer = arr(lower)
		Dim start As Integer = lower
		Dim [stop] As Integer = upper

		Do While lower < upper
			Do While arr(lower) <= pivot
				lower += 1
			Loop
			Do While arr(upper) > pivot
				upper -= 1
			Loop
			If lower < upper Then
				swap(arr, upper, lower)
			End If
		Loop

		swap(arr, upper, start) ' upper is the pivot position
		If k < upper Then
			QuickSelectUtil(arr, start, upper - 1, k) ' pivot -1 is the upper for left sub array.
		End If
		If k > upper Then
			QuickSelectUtil(arr, upper + 1, [stop], k) ' pivot + 1 is the lower for right sub array.
		End If
	End Sub

	Public Shared Function KLargestElements2(ByVal arrIn() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim arr(size - 1) As Integer
		For i As Integer = 0 To size - 1
			arr(i) = arrIn(i)
		Next i

		QuickSelectUtil(arr, 0, size - 1, size - k)
		For i As Integer = 0 To size - 1
			If arrIn(i) >= arr(size - k) Then
				Console.WriteLine(arrIn(i))
				Return arrIn(i)
			End If
		Next i
		Return -1
	End Function

	' linear search method 
	Public Shared Function FixPoint(ByVal arr() As Integer, ByVal size As Integer) As Integer
		For i As Integer = 0 To size - 1
			If arr(i) = i Then
				Return i
			End If
		Next i ' fix point not found so return invalid index
		Return -1
	End Function

	' Binary search method 
	Public Shared Function FixPoint2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Dim mid As Integer
		Do While low <= high
			mid = (low + high) \ 2
			If arr(mid) = mid Then
				Return mid
			ElseIf arr(mid) < mid Then
				low = mid + 1
			Else
				high = mid - 1
			End If
		Loop
		' fix point not found so return invalid index 
		Return -1
	End Function

	Public Shared Function subArraySums(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim first As Integer = 0
		Dim second As Integer = 0
		Dim sum As Integer = arr(first)
		Do While second < size AndAlso first < size
			If sum = value Then
				Console.WriteLine(first + second)
			End If

			If sum < value Then
				second += 1
				If second < size Then
					sum += arr(second)
				End If
			Else
				sum -= arr(first)
				first += 1
			End If
		Loop
		Return sum
	End Function

	Public Shared Function MaxConSub(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim currMax As Integer = 0
		Dim maximum As Integer = 0
		For i As Integer = 0 To size - 1
			currMax = Math.Max(arr(i), currMax + arr(i))
			If currMax < 0 Then
				currMax = 0
			End If
			If maximum < currMax Then
				maximum = currMax
			End If
		Next i
		Console.WriteLine(maximum)
		Return maximum
	End Function

	Public Shared Function MaxConSubArr(ByVal A() As Integer, ByVal sizeA As Integer, ByVal B() As Integer, ByVal sizeB As Integer) As Integer
		Dim currMax As Integer = 0
		Dim maximum As Integer = 0
		Dim hs As New HashSet(Of Integer)()

		For i As Integer = 0 To sizeB - 1
			hs.Add(B(i))
		Next i

		For i As Integer = 0 To sizeA - 1
			If hs.Contains(A(i)) Then
				currMax = 0
			Else
				currMax = Math.Max(A(i), currMax + A(i))
			End If
		Next i
		If currMax < 0 Then
			currMax = 0
		End If
		If maximum < currMax Then
			maximum = currMax
		End If
		Console.WriteLine(maximum)
		Return maximum
	End Function

	Public Shared Function MaxConSubArr2(ByVal A() As Integer, ByVal sizeA As Integer, ByVal B() As Integer, ByVal sizeB As Integer) As Integer
		Array.Sort(B)
		Dim currMax As Integer = 0
		Dim maximum As Integer = 0

		For i As Integer = 0 To sizeA - 1
			If Binarysearch(B, sizeB, A(i)) Then
				currMax = 0
			Else
				currMax = Math.Max(A(i), currMax + A(i))
				If currMax < 0 Then
					currMax = 0
				End If
				If maximum < currMax Then
					maximum = currMax
				End If
			End If
		Next i
		Console.WriteLine(maximum)
		Return maximum
	End Function

	Public Shared Function RainWater(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim leftHigh(size - 1) As Integer
		Dim rightHigh(size - 1) As Integer

		Dim max As Integer = arr(0)
		leftHigh(0) = arr(0)
		For i As Integer = 1 To size - 1
			If max < arr(i) Then
				max = arr(i)
			End If
			leftHigh(i) = max
		Next i
		max = arr(size - 1)
		rightHigh(size - 1) = arr(size - 1)
		For i As Integer = (size - 2) To 0 Step -1
			If max < arr(i) Then
				max = arr(i)
			End If
			rightHigh(i) = max
		Next i

		Dim water As Integer = 0
		For i As Integer = 0 To size - 1
			water += Math.Min(leftHigh(i), rightHigh(i)) - arr(i)
		Next i
		Console.WriteLine("Water : " & water)
		Return water
	End Function

	Public Shared Function RainWater2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim water As Integer = 0
		Dim leftMax As Integer = 0, rightMax As Integer = 0
		Dim left As Integer = 0
		Dim right As Integer = size - 1

		Do While left <= right
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
		Loop
		Console.WriteLine("Water : " & water)
		Return water
	End Function

	Public Shared Sub seperateEvenAndOdd(ByVal arr() As Integer, ByVal size As Integer)
		Dim left As Integer = 0, right As Integer = size - 1
		Do While left < right
			If arr(left) Mod 2 = 0 Then
				left += 1
			ElseIf arr(right) Mod 2 = 1 Then
				right -= 1
			Else
				swap(arr, left, right)
				left += 1
				right -= 1
			End If
		Loop
	End Sub

	Public Shared Sub Main24(ByVal args() As String)
		Dim first() As Integer = {1, 5, 6, 6, 6, 6, 6, 6, 7, 8, 10, 13, 20, 30}
		seperateEvenAndOdd(first, first.Length)
		For Each val As Integer In first
			Console.Write(val & " ")
		Next val
	End Sub


	Public Shared Sub Main(ByVal args() As String)
		Main1(args)
		Main2(args)
		Main3(args)
		Main4(args)
		Main5(args)
		Main6(args)
		Main7(args)
		Main8(args)
		Main9(args)
		Main10(args)
		Main11(args)
		Main12(args)
		Main13(args)
		Main14(args)
		Main15(args)
		Main16(args)
		Main17(args)
		Main18(args)
		Main19(args)
		Main20(args)
		Main21(args)
		Main22(args)
		Main23(args)
		Main24(args)
	End Sub
End Class