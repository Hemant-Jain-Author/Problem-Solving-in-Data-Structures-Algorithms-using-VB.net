
Imports System
Imports System.Collections.Generic

Public Class Introduction
	Public Shared Sub PrintArray(ByVal arr() As Integer, ByVal count As Integer)
		Console.Write("[")
		For i As Integer = 0 To count - 1
			Console.Write(" " & arr(i))
		Next i
		Console.WriteLine(" ]")
	End Sub

	Public Shared Sub Swap(ByVal arr() As Integer, ByVal x As Integer, ByVal y As Integer)
		Dim temp As Integer = arr(x)
		arr(x) = arr(y)
		arr(y) = temp
		Return
	End Sub

	Public Shared Function SumArray(ByVal arr() As Integer) As Integer
		Dim size As Integer = arr.Length
		Dim total As Integer = 0
		For index As Integer = 0 To size - 1
			total = total + arr(index)
		Next index
		Return total
	End Function

	' Testing code 
	Public Shared Sub Main1()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		Console.WriteLine("Sum of values in array:" & SumArray(arr))
	End Sub
	'	
	'	Sum of values in array:45
	'	

	Public Sub Function2()
		Console.WriteLine("Fun2 line 1")
	End Sub

	Public Sub Function1()
		Console.WriteLine("Fun1 line 1")
		Function2()
		Console.WriteLine("Fun1 line 2")
	End Sub

	' Testing code 
	Public Sub Main2()
		Console.WriteLine("Main line 1")
		Function1()
		Console.WriteLine("Main line 2")
	End Sub
	'	
	'	Main line 1
	'	Fun1 line 1
	'	Fun2 line 1
	'	Fun1 line 2
	'	Main line 2
	'	
	Public Shared Function SequentialSearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		For i As Integer = 0 To size - 1
			If value = arr(i) Then
				If True Then
					Return i
				End If
			End If
		Next i
		Return -1
	End Function

	Public Shared Function BinarySearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim mid As Integer
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Do While low <= high
			mid = (low + high) \ 2
			If arr(mid) = value Then
				Return mid
			Else
				If arr(mid) < value Then
					low = mid + 1
				Else
					high = mid - 1
				End If
			End If
		Loop
		Return -1
	End Function

	Public Shared Sub Main3()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		Console.WriteLine("SequentialSearch:" & SequentialSearch(arr, arr.Length, 7))
		Console.WriteLine("BinarySearch:" & BinarySearch(arr, arr.Length, 7))
	End Sub
	'	
	'	SequentialSearch:6
	'	BinarySearch:6
	'	
	Public Shared Sub RotateArray(ByVal a() As Integer, ByVal n As Integer, ByVal k As Integer)
		ReverseArray(a, 0, k - 1)
		ReverseArray(a, k, n - 1)
		ReverseArray(a, 0, n - 1)
	End Sub

	Public Shared Sub ReverseArray(ByVal a() As Integer, ByVal start As Integer, ByVal finish As Integer)
		Dim i As Integer = start
		Dim j As Integer = finish
		Do While i < j
			Dim temp As Integer = a(i)
			a(i) = a(j)
			a(j) = temp
			i += 1
			j -= 1
		Loop
	End Sub

	Public Shared Sub ReverseArray2(ByVal a() As Integer)
		Dim start As Integer = 0
		Dim finish As Integer = a.Length - 1
		Dim i As Integer = start
		Dim j As Integer = finish
		Do While i < j
			Dim temp As Integer = a(i)
			a(i) = a(j)
			a(j) = temp
			i += 1
			j -= 1
		Loop
	End Sub

	' Testing code 
	Public Shared Sub Main4()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6}
		RotateArray(arr, arr.Length, 2)
		PrintArray(arr, arr.Length)
	End Sub
	'	
	'	[ 3 4 5 6 1 2 ]
	'	
	Public Shared Function MaxSubArraySum(ByVal a() As Integer, ByVal size As Integer) As Integer
		Dim maxSoFar As Integer = 0, maxEndingHere As Integer = 0

		For i As Integer = 0 To size - 1
			maxEndingHere = maxEndingHere + a(i)
			If maxEndingHere < 0 Then
				maxEndingHere = 0
			End If
			If maxSoFar < maxEndingHere Then
				maxSoFar = maxEndingHere
			End If
		Next i
		Return maxSoFar
	End Function

	' Testing code 
	Public Shared Sub Main5()
		Dim arr() As Integer = {1, -2, 3, 4, -4, 6, -4, 3, 2}
		Console.WriteLine("Max sub array sum :" & MaxSubArraySum(arr, 9))
	End Sub
	'	
	'	Max sub array sum :10
	'	
	Public Shared Sub WaveArray2(ByVal arr() As Integer)
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

	Public Shared Sub WaveArray(ByVal arr() As Integer)
		Dim size As Integer = arr.Length
		Array.Sort(arr)
		Dim i As Integer = 0
		Do While i < size - 1
			Swap(arr, i, i + 1)
			i += 2
		Loop
	End Sub


	' Testing code 
	Public Shared Sub Main6()
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
	Public Shared Sub IndexArray(ByVal arr() As Integer, ByVal size As Integer)
		For i As Integer = 0 To size - 1
			Dim curr As Integer = i
			Dim value As Integer = -1

			' Swaps to move elements in proper position. 
			Do While arr(curr) <> -1 AndAlso arr(curr) <> curr
				Dim temp As Integer = arr(curr)
				arr(curr) = value
				curr = temp
				value = curr
			Loop

			' check if some Swaps happened. 
			If value <> -1 Then
				arr(curr) = value
			End If
		Next i
	End Sub

	Public Shared Sub IndexArray2(ByVal arr() As Integer, ByVal size As Integer)
		Dim temp As Integer
		For i As Integer = 0 To size - 1
			Do While arr(i) <> -1 AndAlso arr(i) <> i
				' Swap arr[i] and arr[arr[i]] 
				temp = arr(i)
				arr(i) = arr(temp)
				arr(temp) = temp
			Loop
		Next i
	End Sub

	' Testing code 
	Public Shared Sub Main7()
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

	Public Shared Sub Sort1toN(ByVal arr() As Integer, ByVal size As Integer)
		Dim curr, value, nextValue As Integer
		For i As Integer = 0 To size - 1
			curr = i
			value = -1
			' Swaps to move elements in proper position. 
			Do While curr >= 0 AndAlso curr < size AndAlso arr(curr) <> curr + 1
				nextValue = arr(curr)
				arr(curr) = value
				value = nextValue
				curr = nextValue - 1
			Loop
		Next i
	End Sub

	Public Shared Sub Sort1toN2(ByVal arr() As Integer, ByVal size As Integer)
		Dim temp As Integer
		For i As Integer = 0 To size - 1
			Do While arr(i) <> i + 1 AndAlso arr(i) > 1
				temp = arr(i)
				arr(i) = arr(temp - 1)
				arr(temp - 1) = temp
			Loop
		Next i
	End Sub

	' Testing code 
	Public Shared Sub Main8()
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
	'	
	Public Shared Function SmallestPositiveMissingNumber(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim found As Integer
		Dim i As Integer = 1
		Do While i < size + 1
			found = 0
			For j As Integer = 0 To size - 1
				If arr(j) = i Then
					found = 1
					Exit For
				End If
			Next j
			If found = 0 Then
				Return i
			End If
			i += 1
		Loop
		Return -1
	End Function

	Public Shared Function SmallestPositiveMissingNumber2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim hs As New Dictionary(Of Integer, Integer)()
		For j As Integer = 0 To size - 1
			hs(arr(j)) = 1
		Next j
		Dim i As Integer = 1
		Do While i < size + 1
			If hs.ContainsKey(i) = False Then
				Return i
			End If
			i += 1
		Loop
		Return -1
	End Function

	Public Shared Function SmallestPositiveMissingNumber3(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim aux(size - 1) As Integer
		Array.Fill(aux, -1)

		For i As Integer = 0 To size - 1
			If arr(i) > 0 AndAlso arr(i) <= size Then
				aux(arr(i) - 1) = arr(i)
			End If
		Next i
		For i As Integer = 0 To size - 1
			If aux(i) <> i + 1 Then
				Return i + 1
			End If
		Next i
		Return -1
	End Function


	Public Shared Function SmallestPositiveMissingNumber4(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim temp As Integer
		For i As Integer = 0 To size - 1
			Do While arr(i) <> i + 1 AndAlso arr(i) > 0 AndAlso arr(i) <= size
				temp = arr(i)
				arr(i) = arr(temp - 1)
				arr(temp - 1) = temp
			Loop
		Next i
		For i As Integer = 0 To size - 1
			If arr(i) <> i + 1 Then
				Return i + 1
			End If
		Next i
		Return -1
	End Function

	' Testing code 
	Public Shared Sub Main9()
		Dim arr() As Integer = {8, 5, 6, 1, 9, 11, 2, 7, 4, 10}
		Dim size As Integer = arr.Length

		Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber(arr, size))
		Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber2(arr, size))
		Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber3(arr, size))
		Console.WriteLine("SmallestPositiveMissingNumber :" & SmallestPositiveMissingNumber4(arr, size))
	End Sub

	'	
	'	SmallestPositiveMissingNumber :3
	'	SmallestPositiveMissingNumber :3
	'	SmallestPositiveMissingNumber :3
	'	SmallestPositiveMissingNumber :3
	'	
	Public Shared Sub MaxMinArr(ByVal arr() As Integer, ByVal size As Integer)
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

	Public Shared Sub ReverseArr(ByVal arr() As Integer, ByVal start As Integer, ByVal finish As Integer)
		Do While start < finish
			Swap(arr, start, finish)
			start += 1
			finish -= 1
		Loop
	End Sub

	Public Shared Sub MaxMinArr2(ByVal arr() As Integer, ByVal size As Integer)
		Dim i As Integer = 0
		Do While i < (size - 1)
			ReverseArr(arr, i, size - 1)
			i += 1
		Loop
	End Sub

	' Testing code 
	Public Shared Sub Main10()
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
	Public Shared Function MaxCircularSum(ByVal arr() As Integer, ByVal size As Integer) As Integer
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
	Public Shared Sub Main11()
		Dim arr() As Integer = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}
		Console.WriteLine("MaxCircularSum: " & MaxCircularSum(arr, arr.Length))
	End Sub
	'	
	'	MaxCircularSum: 290
	'	

	Public Shared Function ArrayIndexMaxDiff(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim maxDiff As Integer = -1
		Dim j As Integer
		For i As Integer = 0 To size - 1
			j = size - 1
			Do While i < j
				If arr(i) <= arr(j) Then
					maxDiff = Math.Max(maxDiff, j - i)
					Exit Do
				End If
				j -= 1
			Loop
		Next i
		Return maxDiff
	End Function

	Public Shared Function ArrayIndexMaxDiff2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim rightMax(size - 1) As Integer
		rightMax(size - 1) = arr(size - 1)
		For k As Integer = size - 2 To 0 Step -1
			rightMax(k) = Math.Max(rightMax(k + 1), arr(k))
		Next k

		Dim maxDiff As Integer = -1
		Dim i As Integer = 0
		Dim j As Integer = 1
		Do While i < size AndAlso j < size
			If arr(i) <= rightMax(j) Then
				If i < j Then
					maxDiff = Math.Max(maxDiff, j - i)
				End If
				j = j + 1
			Else
				i = i + 1
			End If
		Loop
		Return maxDiff
	End Function

	' Testing code 
	Public Shared Sub Main12()
		Dim arr() As Integer = {33, 9, 10, 3, 2, 60, 30, 33, 1} ' {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
		Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff(arr, arr.Length))
		Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff2(arr, arr.Length))
	End Sub
	'	
	'	ArrayIndexMaxDiff : 7
	'	ArrayIndexMaxDiff : 7
	'	

	Public Shared Function MaxPathSum(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, result As Integer = 0, sum1 As Integer = 0, sum2 As Integer = 0

		Do While i < size1 AndAlso j < size2
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
		Loop
		Do While i < size1
			sum1 += arr1(i)
			i += 1
		Loop

		Do While j < size2
			sum2 += arr2(j)
			j += 1
		Loop

		result += Math.Max(sum1, sum2)
		Return result
	End Function

	' Testing code 
	Public Shared Sub Main13()
		Dim arr1() As Integer = {12, 13, 18, 20, 22, 26, 70}
		Dim arr2() As Integer = {11, 15, 18, 19, 20, 26, 30, 31}
		Console.WriteLine("Max Path Sum :: " & MaxPathSum(arr1, arr1.Length, arr2, arr2.Length))
	End Sub
	'	
	'	Max Path Sum :: 201
	'	
	Public Shared Function Factorial(ByVal i As Integer) As Integer
		' Termination Condition
		If i <= 1 Then
			Return 1
		End If
		' Body, Recursive Expansion
		Return i * Factorial(i - 1)
	End Function

	' Testing code 
	Public Shared Sub Main14()
		Console.WriteLine("Factorial:" & Factorial(5))
	End Sub

	' Factorial:120

	Public Shared Sub PrintInt10(ByVal number As Integer)
		Dim digit As Char = ChrW(number Mod 10 + AscW("0"c))
		number = number \ 10
		If number <> 0 Then
			PrintInt10(number)
		End If
		Console.Write(digit)
	End Sub


	Public Shared Sub PrintInt(ByVal number As Integer, ByVal outputbase As Integer)
		Dim conversion As String = "0123456789ABCDEF"
		Dim digit As Char = ChrW(number Mod outputbase)
		number = number \ outputbase
		If number <> 0 Then
			PrintInt(number, outputbase)
		End If
		Console.Write(conversion.Chars(AscW(digit)))
	End Sub

	' Testing code 
	Public Shared Sub Main15()
		PrintInt10(50)
		Console.WriteLine()
		PrintInt(500, 16)
		Console.WriteLine()
	End Sub
	'	
	'	50
	'	1F4
	'	


	Public Shared Sub TowerOfHanoi(ByVal num As Integer, ByVal src As Char, ByVal dst As Char, ByVal temp As Char)
		If num < 1 Then
			Return
		End If

		TowerOfHanoi(num - 1, src, temp, dst)
		Console.WriteLine("Move " & num & " disk  from peg " & src & " to peg " & dst)
		TowerOfHanoi(num - 1, temp, dst, src)
	End Sub

	' Testing code 
	Public Shared Sub Main16()
		Dim num As Integer = 3
		Console.WriteLine("Moves involved in the Tower of Hanoi are:")
		TowerOfHanoi(num, "A"c, "C"c, "B"c)
	End Sub
	'	
	'	Moves involved in the Tower of Hanoi are:
	'	Move 1 disk  from peg A to peg C
	'	Move 2 disk  from peg A to peg B
	'	Move 1 disk  from peg C to peg B
	'	Move 3 disk  from peg A to peg C
	'	Move 1 disk  from peg B to peg A
	'	Move 2 disk  from peg B to peg C
	'	Move 1 disk  from peg A to peg C
	'	
	Public Shared Function GCD(ByVal m As Integer, ByVal n As Integer) As Integer
		If m < n Then
			Return (GCD(n, m))
		End If
		If m Mod n = 0 Then
			Return (n)
		End If
		Return (GCD(n, m Mod n))
	End Function

	' Testing code 
	Public Shared Sub Main17()
		Console.WriteLine("GCD is:: " & GCD(5, 2))
	End Sub

	'	
	'	GCD is:: 1
	'	

	Public Shared Function Fibonacci(ByVal n As Integer) As Integer
		If n <= 1 Then
			Return n
		End If
		Return Fibonacci(n - 1) + Fibonacci(n - 2)
	End Function

	' Testing code 
	Public Shared Sub Main18()
		For i As Integer = 0 To 9
			Console.Write(Fibonacci(i) & " ")
		Next i
		Console.WriteLine()
	End Sub

	'	
	'	0 1 1 2 3 5 8 13 21 34 
	'	

	Public Shared Sub Permutation(ByVal arr() As Integer, ByVal i As Integer, ByVal length As Integer)
		If length = i Then
			PrintArray(arr, length)
			Return
		End If
		Dim j As Integer = i
		j = i
		Do While j < length
			Swap(arr, i, j)
			Permutation(arr, i + 1, length)
			Swap(arr, i, j)
			j += 1
		Loop
		Return
	End Sub

	' Testing code 
	Public Shared Sub Main19()
		Dim arr(2) As Integer
		For i As Integer = 0 To 2
			arr(i) = i
		Next i
		Permutation(arr, 0, 3)
	End Sub
	'	
	'	[ 0 1 2 ]
	'	[ 0 2 1 ]
	'	[ 1 0 2 ]
	'	[ 1 2 0 ]
	'	[ 2 1 0 ]
	'	[ 2 0 1 ]
	'	
	' Binary Search Algorithm - Recursive
	Public Shared Function BinarySearchRecursive(ByVal arr() As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Integer
		If low > high Then
			Return -1
		End If
		Dim mid As Integer = (low + high) \ 2
		If arr(mid) = value Then
			Return mid
		ElseIf arr(mid) < value Then
			Return BinarySearchRecursive(arr, mid + 1, high, value)
		Else
			Return BinarySearchRecursive(arr, low, mid - 1, value)
		End If
	End Function

	' Testing code 
	Public Shared Sub Main20()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 6))
		Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 16))
	End Sub
	'	
	'	5
	'	-1
	'	
	Public Shared Sub Main(ByVal args() As String)

		Main1()
		Dim i As New Introduction()
		i.Main2()
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
	End Sub
End Class