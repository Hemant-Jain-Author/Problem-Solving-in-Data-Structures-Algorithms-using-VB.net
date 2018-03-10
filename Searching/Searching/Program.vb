Imports System
Imports System.Collections.Generic

Public Class Searching

	Public Sub New()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim first() As Integer = {1, 3, 5, 7, 9, 25, 30}
		Dim second() As Integer = {2, 4, 6, 8, 10, 12, 14, 16, 21, 23, 24}

		For i As Integer = 1 To 15
			Console.Write("Index : " & i & " Value : ")
			Console.WriteLine(findkth(first, second, i))
		Next i

	End Sub

	'buggy implimentation.
	Friend Shared Function findkth(ByVal first() As Integer, ByVal second() As Integer, ByVal k As Integer) As Integer
		Dim sizeFirst As Integer = first.Length
		Dim sizeSecond As Integer = second.Length

		If sizeFirst + sizeSecond < k Then
			Return Integer.MaxValue
		End If

		If k = 1 Then
			Return min(first(0), second(0))
		End If

		Dim i As Integer = min(sizeFirst, k \ 2)
		Dim j As Integer = min(sizeSecond, k - i)

		Dim [step] As Integer = max(1, min(i, j) \ 2)

		Do While [step] > 0
			If first(i - 1) > second(j - 1) AndAlso first(i - 1) > second(min(second.Length, j + [step]) - 1) Then
				j = min(second.Length, j + [step])
				i = k - j

			ElseIf first(i - 1) < second(j - 1) AndAlso first(min(first.Length, i + [step]) - 1) < second(j - 1) Then
				i = min(first.Length, i + [step])
				j = k - i
			End If
			[step] = [step] \ 2
		Loop
		Return max(first(i - 1), second(j - 1))
	End Function


	Public Function linearSearchUnsorted(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim i As Integer = 0
		For i = 0 To size - 1
			If value = arr(i) Then
				Return True
			End If
		Next i
		Return False
	End Function

	Public Function linearSearchSorted(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim i As Integer = 0
		For i = 0 To size - 1
			If value = arr(i) Then
				Return True
			ElseIf value < arr(i) Then
				Return False
			End If
		Next i
		Return False
	End Function

	' Binary Search Algorithm � Iterative Way 
	Public Function Binarysearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Boolean
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Dim mid As Integer

		Do While low <= high
			mid = low + (high - low) \ 2 ' To avoid the overflow
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


	' Binary Search Algorithm � Recursive Way 
	Public Function BinarySearchRecursive(ByVal arr() As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Boolean
		If low > high Then
			Return False
		End If
		Dim mid As Integer = low + (high - low) \ 2 ' To avoid the overflow
		If arr(mid) = value Then
			Return True
		ElseIf arr(mid) < value Then
			Return BinarySearchRecursive(arr, mid + 1, high, value)
		Else
			Return BinarySearchRecursive(arr, low, mid - 1, value)
		End If
	End Function

	Public Sub printRepeating(ByVal arr() As Integer, ByVal size As Integer)
		Dim i, j As Integer
		Console.WriteLine(" Repeating elements are ")
		For i = 0 To size - 1
			For j = i + 1 To size - 1
				If arr(i) = arr(j) Then
					Console.WriteLine(" " & arr(i))
				End If
			Next j
		Next i
	End Sub

	Public Sub printRepeating2(ByVal arr() As Integer, ByVal size As Integer)
		Dim i As Integer
		Array.Sort(arr) ' Sort(arr,size);
		Console.WriteLine(" Repeating elements are ")

		For i = 1 To size - 1
			If arr(i) = arr(i - 1) Then
				Console.WriteLine(" " & arr(i))
			End If
		Next i
	End Sub



	Public Sub printRepeating3(ByVal arr() As Integer, ByVal size As Integer)
		Dim hs As New HashSet(Of Integer)()
		Dim i As Integer
		Console.WriteLine(" Repeating elements are ")
		For i = 0 To size - 1
			If hs.Contains(arr(i)) Then
				Console.WriteLine(" " & arr(i))
			Else
				hs.Add(arr(i))
			End If
		Next i
	End Sub


	Public Sub printRepeating4(ByVal arr() As Integer, ByVal size As Integer)
		Dim count(size - 1) As Integer
		Dim i As Integer
		For i = 0 To size - 1
			count(i) = 0
		Next i
		Console.WriteLine(" Repeating elements are ")
		For i = 0 To size - 1
			If count(arr(i)) = 1 Then
				Console.WriteLine(" " & arr(i))
			Else
				count(arr(i)) += 1
			End If
		Next i
	End Sub


	Public Function getMax(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i, j As Integer
		Dim max As Integer = 0, count As Integer = 0, maxCount As Integer = 0
		For i = 0 To size - 1
			For j = i + 1 To size - 1
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

	Public Function getMax2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim max As Integer = arr(0), maxCount As Integer = 1
		Dim curr As Integer = arr(0), currCount As Integer = 1
		Dim i As Integer
		Array.Sort(arr) ' Sort(arr,size);
		For i = 1 To size - 1
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

	Public Function getMax(ByVal arr() As Integer, ByVal size As Integer, ByVal range As Integer) As Integer
		Dim max As Integer = arr(0), maxCount As Integer = 1
		Dim count(range - 1) As Integer
		Dim i As Integer
		For i = 0 To size - 1
			count(arr(i)) += 1
			If count(arr(i)) > maxCount Then
				maxCount = count(arr(i))
				max = arr(i)
			End If
		Next i
		Return max
	End Function

	Public Function getMajority(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i, j As Integer
		Dim max As Integer = 0, count As Integer = 0, maxCount As Integer = 0
		For i = 0 To size - 1
			For j = i + 1 To size - 1
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

	Public Function getMajority2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim majIndex As Integer = size \ 2, count As Integer = 1
		Dim i As Integer
		Dim candidate As Integer
		Array.Sort(arr) ' Sort(arr,size);
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
			Return Integer.MinValue
		End If
	End Function

	Public Function getMajority3(ByVal arr() As Integer, ByVal size As Integer) As Integer
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

	Public Function findMissingNumber(ByVal arr() As Integer, ByVal size As Integer) As Integer
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

	Public Function findMissingNumber(ByVal arr() As Integer, ByVal size As Integer, ByVal range As Integer) As Integer
		Dim i As Integer
		Dim xorSum As Integer = 0
		'get the XOR of all the numbers from 1 to range
		For i = 1 To range
			xorSum = xorSum Xor i
		Next i
		'loop through the array and get the XOR of elements
		For i = 0 To size - 1
			xorSum = xorSum Xor arr(i)
		Next i
		Return xorSum
	End Function

	Public Function FindPair(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim i, j As Integer
		For i = 0 To size - 1
			For j = i + 1 To size - 1
				If (arr(i) + arr(j)) = value Then
					Console.WriteLine("The pair is : " & arr(i) & "," & arr(j))
					Return 1
				End If
			Next j
		Next i
		Return 0
	End Function

	Public Function FindPair2(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim first As Integer = 0, second As Integer = size - 1
		Dim curr As Integer
		Array.Sort(arr) 'Sort(arr, size);
		Do While first < second
			curr = arr(first) + arr(second)
			If curr = value Then
				Console.WriteLine("The pair is " & arr(first) & "," & arr(second))
				Return 1
			ElseIf curr < value Then
				first += 1
			Else
				second -= 1
			End If
		Loop
		Return 0
	End Function

	Public Function FindPair3(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim hs As New HashSet(Of Integer?)()
		Dim i As Integer
		For i = 0 To size - 1
			If hs.Contains(value - arr(i)) Then
				Console.WriteLine("The pair is : " & arr(i) & " , " & (value - arr(i)))
				Return 1
			End If
			hs.Add(arr(i))
		Next i
		Return 0
	End Function



	Public Sub minAbsSumPair(ByVal arr() As Integer, ByVal size As Integer)
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
		Console.WriteLine(" The two elements with minimum sum are : " & arr(minFirst) & " , " & arr(minSecond))
	End Sub


	Public Sub minabsSumPair2(ByVal arr() As Integer, ByVal size As Integer)
		Dim l, r, minSum, sum, minFirst, minSecond As Integer
		' Array should have at least two elements
		If size < 2 Then
			Console.WriteLine("Invalid Input")
			Return
		End If
		Array.Sort(arr) 'Sort(arr, size);

		' Initialization of values
		minFirst = 0
		minSecond = size - 1
		minSum = Math.Abs(arr(minFirst) + arr(minSecond))
		l = 0
		r = size - 1
		Do While l < r
			sum = (arr(l) + arr(r))
			If Math.Abs(sum) < minSum Then
				minSum = sum
				minFirst = l
				minSecond = r
			End If
			If sum < 0 Then
				l += 1
			ElseIf sum > 0 Then
				r += 1
			Else
				Exit Do
			End If
		Loop
		Console.WriteLine(" The two elements with minimum sum are : " & arr(minFirst) & " , " & arr(minSecond))
	End Sub


	Public Function SearchBotinicArrayMax(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim start As Integer = 0, [end] As Integer = size - 1
		Dim mid As Integer = (start + [end]) \ 2
		Dim maximaFound As Integer = 0
		If size < 3 Then
			Console.WriteLine("error")
			Return 0
		End If
		Do While start <= [end]
			mid = (start + [end]) \ 2
			If arr(mid - 1) < arr(mid) AndAlso arr(mid + 1) < arr(mid) Then 'maxima
				maximaFound = 1
				Exit Do
			ElseIf arr(mid - 1) < arr(mid) AndAlso arr(mid) < arr(mid + 1) Then 'increasing
				start = mid + 1
			ElseIf arr(mid - 1) > arr(mid) AndAlso arr(mid) > arr(mid + 1) Then 'decreasing
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

	Public Function SearchBitonicArray(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Dim max As Integer = FindMaxBitonicArray(arr, size)
		Dim k As Integer = BinarySearch_Renamed(arr, 0, max, key, True)
		If k <> -1 Then
			Return k
		Else
			Return BinarySearch_Renamed(arr, max + 1, size - 1, key, False)
		End If
	End Function

	Public Function FindMaxBitonicArray(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim start As Integer = 0, [end] As Integer = size - 1, mid As Integer
		If size < 3 Then
			Console.WriteLine("error")
			Return 0
		End If
		Do While start <= [end]
			mid = (start + [end]) \ 2
			If arr(mid - 1) < arr(mid) AndAlso arr(mid + 1) < arr(mid) Then 'maxima
				Return mid
			ElseIf arr(mid - 1) < arr(mid) AndAlso arr(mid) < arr(mid + 1) Then 'increasing
				start = mid + 1
			ElseIf arr(mid - 1) > arr(mid) AndAlso arr(mid) > arr(mid + 1) Then 'increasing
				[end] = mid - 1
			Else
				Exit Do
			End If
		Loop
		Console.WriteLine("error")
		Return 0
	End Function

	'INSTANT VB NOTE: The method BinarySearch was renamed since Visual Basic does not allow same-signature methods with the same name:
	Public Function BinarySearch_Renamed(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer, ByVal isInc As Boolean) As Integer
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


	Public Function findKeyCount(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Dim i As Integer, count As Integer = 0
		i = 0
		Do While i < size - 1
			If arr(i) = key Then
				count += 1
			End If
			i += 1
		Loop
		Return count
	End Function


	Public Function findKeyCount2(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Dim firstIndex, lastIndex As Integer
		firstIndex = findFirstIndex(arr, 0, size - 1, key)
		lastIndex = findLastIndex(arr, 0, size - 1, key)
		Return (lastIndex - firstIndex + 1)
	End Function

	Public Function findFirstIndex(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer) As Integer
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


	Public Function findLastIndex(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer) As Integer
		Dim mid As Integer
		If [end] < start Then
			Return -1
		End If
		mid = (start + [end]) \ 2
		If key = arr(mid) AndAlso (mid = [end] OrElse arr(mid + 1) <> key) Then
			Return mid
		End If
		If key < arr(mid) Then ' <
			Return findLastIndex(arr, start, mid - 1, key)
		Else
			Return findLastIndex(arr, mid + 1, [end], key)
		End If
	End Function

	Public Sub swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Integer = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub

	Public Sub seperateEvenAndOdd(ByVal arr() As Integer, ByVal size As Integer)
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

	Public Sub maxProfit(ByVal stocks() As Integer, ByVal size As Integer)
		Dim buy As Integer = 0, sell As Integer = 0
		Dim curMin As Integer = 0
		Dim currProfit As Integer = 0
		Dim maxProfit As Integer = 0
		Dim i As Integer
		For i = 0 To size - 1
			If stocks(i) < stocks(curMin) Then
				curMin = i
			End If
			currProfit = stocks(i) - stocks(curMin)
			If currProfit > maxProfit Then
				buy = curMin
				sell = i
				maxProfit = currProfit
			End If
		Next i
		Console.WriteLine("Purchase day is- " & buy & " at price " & stocks(buy))
		Console.WriteLine("Sell day is- " & sell & " at price " & stocks(sell))
	End Sub

	Public Function getMedian(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Array.Sort(arr) 'Sort(arr, size);
		Return arr(size \ 2)
	End Function


	Public Function findMedian(ByVal arrFirst() As Integer, ByVal sizeFirst As Integer, ByVal arrSecond() As Integer, ByVal sizeSecond As Integer) As Integer
		Dim medianIndex As Integer = ((sizeFirst + sizeSecond) + (sizeFirst + sizeSecond) Mod 2) \ 2 'cealing function.
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

	Friend Shared Function min(ByVal a As Integer, ByVal b As Integer) As Integer
		Return If(a > b, b, a)
	End Function

	Friend Shared Function max(ByVal a As Integer, ByVal b As Integer) As Integer
		Return If(a < b, b, a)
	End Function


	Public Function BinarySearch01(ByVal arr() As Integer, ByVal size As Integer) As Integer
		If size = 1 AndAlso arr(0) = 1 Then
			Return 0
		End If
		Return BinarySearch01Util(arr, 0, size - 1)
	End Function

	Public Function BinarySearch01Util(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Integer
		Dim mid As Integer
		If [end] < start Then
			Return -1
		End If
		mid = (start + [end]) \ 2
		If 1 = arr(mid) AndAlso 0 = arr(mid - 1) Then
			Return mid
		End If
		If 0 = arr(mid) Then
			Return BinarySearch01Util(arr, mid + 1, [end])
		Else
			Return BinarySearch01Util(arr, start, mid - 1)
		End If
	End Function

	Public Function BinarySearchRotateArrayUtil(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer, ByVal key As Integer) As Integer
		Dim mid As Integer
		If [end] < start Then
			Return -1
		End If
		mid = (start + [end]) \ 2
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

	Public Function BinarySearchRotateArray(ByVal arr() As Integer, ByVal size As Integer, ByVal key As Integer) As Integer
		Return BinarySearchRotateArrayUtil(arr, 0, size - 1, key)
	End Function

	Public Function FirstRepeated(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i, j As Integer
		For i = 0 To size - 1
			For j = i + 1 To size - 1
				If arr(i) = arr(j) Then
					Return arr(i)
				End If
			Next j
		Next i
		Return 0
	End Function

	Public Sub transformArrayAB1(ByVal arr() As Integer, ByVal size As Integer)
		Dim N As Integer = size \ 2, i As Integer, j As Integer
		For i = 1 To N - 1
			For j = 0 To i - 1
				swap(arr, N - i + 2 * j, N - i + 2 * j + 1)
			Next j
		Next i
	End Sub

	Public Function checkPermutation(ByVal array1() As Integer, ByVal size1 As Integer, ByVal array2() As Integer, ByVal size2 As Integer) As Boolean
		If size1 <> size2 Then
			Return False
		End If
		Array.Sort(array1) ' Sort(array1, size1);
		Array.Sort(array2) ' Sort(array2, size2);
		For i As Integer = 0 To size1 - 1
			If array1(i) <> array2(i) Then
				Return False
			End If
		Next i
		Return True
	End Function


	Public Function checkPermutation2(ByVal array1() As Integer, ByVal size1 As Integer, ByVal array2() As Integer, ByVal size2 As Integer) As Boolean
		Dim i As Integer
		If size1 <> size2 Then
			Return False
		End If

		Dim al As New List(Of Integer?)()

		For i = 0 To size1 - 1
			al.Add(array1(i))
		Next i

		For i = 0 To size2 - 1
			If al.Contains(array2(i)) = False Then
				Return False
			End If
			al.RemoveAt(array2(i))
		Next i
		Return True
	End Function


	Public Function removeDuplicates(ByVal array() As Integer, ByVal size As Integer) As Integer
		Dim j As Integer = 0
		Dim i As Integer
		If size = 0 Then
			Return 0
		End If
		System.Array.Sort(array) ' Sort(array,size);
		For i = 1 To size - 1
			If array(i) <> array(j) Then
				j += 1
				array(j) = array(i)
			End If
		Next i
		Return j + 1
	End Function

	Public Function FindElementIn2DArray1(ByVal arr()() As Integer, ByVal r As Integer, ByVal c As Integer, ByVal value As Integer) As Integer
		Dim row As Integer = 0
		Dim column As Integer = c - 1
		Do While row < r AndAlso column >= 0
			If arr(row)(column) = value Then
				Return 1
			ElseIf arr(row)(column) > value Then
				column -= 1
			Else
				row += 1
			End If
		Loop
		Return 0
	End Function


	Public Function FindElementIn2DArray(ByVal arr(,) As Integer, ByVal r As Integer, ByVal c As Integer, ByVal value As Integer) As Integer
		Dim row As Integer = 0
		Dim column As Integer = c - 1
		Do While row < r AndAlso column >= 0
			If arr(row, column) = value Then
				Return 1
			ElseIf arr(row, column) > value Then
				column -= 1
			Else
				row += 1
			End If
		Loop
		Return 0
	End Function

End Class