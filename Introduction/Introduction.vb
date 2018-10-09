Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class Introduction

	Public Shared Sub printArray(ByVal arr() As Integer, ByVal count As Integer)
		Console.Write("[")
		For i As Integer = 0 To count - 1
			Console.Write(" " & arr(i))
		Next i
		Console.Write(" ]" & ControlChars.Lf)
	End Sub

	Public Shared Sub swap(ByVal arr() As Integer, ByVal x As Integer, ByVal y As Integer)
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

	Public Shared Sub Main1(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		Console.WriteLine("Sum of values in array:" & SumArray(arr))
	End Sub

	Public Sub function2()
		Console.WriteLine("fun2 line 1")
	End Sub

	Public Sub function1()
		Console.WriteLine("fun1 line 1")
		function2()
		Console.WriteLine("fun1 line 2")
	End Sub

	Public Sub main2()
		Console.WriteLine("main line 1")
		function1()
		Console.WriteLine("main line 2")
	End Sub

	Public Shared Function SequentialSearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		For i As Integer = 0 To size - 1
			If value = arr(i) Then
				Return i
			End If
		Next i
		Return -1
	End Function

	Public Shared Function BinarySearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim mid As Integer
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Do While low <= high
			mid = low + (high - low) \ 2 ' To avoid the overflow
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

	Public Shared Sub Main3(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		Console.WriteLine(" Search 7:" & SequentialSearch(arr, arr.Length, 7))
		Console.WriteLine(" Search 7:" & BinarySearch(arr, arr.Length, 7))
	End Sub

	Public Shared Sub rotateArray(ByVal a() As Integer, ByVal n As Integer, ByVal k As Integer)
		reverseArray(a, 0, k - 1)
		reverseArray(a, k, n - 1)
		reverseArray(a, 0, n - 1)
	End Sub

	Public Shared Sub reverseArray(ByVal a() As Integer, ByVal start As Integer, ByVal [end] As Integer)
		Dim i As Integer = start
		Dim j As Integer = [end]
		Do While i < j
			Dim temp As Integer = a(i)
			a(i) = a(j)
			a(j) = temp
			i += 1
			j -= 1
		Loop
	End Sub

	Public Shared Sub reverseArray2(ByVal a() As Integer)
		Dim start As Integer = 0
		Dim [end] As Integer = a.Length - 1
		Dim i As Integer = start
		Dim j As Integer = [end]
		Do While i < j
			Dim temp As Integer = a(i)
			a(i) = a(j)
			a(j) = temp
			i += 1
			j -= 1
		Loop
	End Sub

	Public Shared Sub Main4(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6}
		rotateArray(arr, arr.Length, 2)
		printArray(arr, arr.Length)
	End Sub

	Public Shared Function maxSubArraySum(ByVal a() As Integer, ByVal size As Integer) As Integer
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

	Public Shared Sub Main5(ByVal args() As String)
		Dim arr() As Integer = {1, -2, 3, 4, -4, 6, -4, 3, 2}
		Console.WriteLine("Max sub array sum :" & maxSubArraySum(arr, 9))
	End Sub

	Public Shared Sub WaveArray2(ByVal arr() As Integer)
		Dim size As Integer = arr.Length
		' Odd elements are lesser then even elements. 
		For i As Integer = 1 To size - 1 Step 2
			If (i - 1) >= 0 AndAlso arr(i) > arr(i - 1) Then
				swap(arr, i, i - 1)
			End If

			If (i + 1) < size AndAlso arr(i) > arr(i + 1) Then
				swap(arr, i, i + 1)
			End If
		Next i
	End Sub

	Public Shared Sub WaveArray(ByVal arr() As Integer)
		Dim size As Integer = arr.Length
		Array.Sort(arr)
		Dim i As Integer = 0
		Do While i < size - 1
			swap(arr, i, i + 1)
			i += 2
		Loop
	End Sub

	' Testing code 
	Public Shared Sub Main6(ByVal args() As String)
		Dim arr() As Integer = {8, 1, 2, 3, 4, 5, 6, 4, 2}
		printArray(arr, arr.Length)
		WaveArray(arr)
		printArray(arr, arr.Length)
		Dim arr2() As Integer = {8, 1, 2, 3, 4, 5, 6, 4, 2}
		WaveArray2(arr2)
		printArray(arr2, arr2.Length)
	End Sub

	Public Shared Sub indexArray(ByVal arr() As Integer, ByVal size As Integer)
		For i As Integer = 0 To size - 1
			Dim curr As Integer = i
			Dim value As Integer = -1

			' swaps to move elements in proper position. 
			Do While arr(curr) <> -1 AndAlso arr(curr) <> curr
				Dim temp As Integer = arr(curr)
				arr(curr) = value
				curr = temp
				value = curr
			Loop

			' check if some swaps happened. 
			If value <> -1 Then
				arr(curr) = value
			End If
		Next i
	End Sub

	Public Shared Sub indexArray2(ByVal arr() As Integer, ByVal size As Integer)
		Dim temp As Integer
		For i As Integer = 0 To size - 1
			Do While arr(i) <> -1 AndAlso arr(i) <> i
				' swap arr[i] and arr[arr[i]] 
				temp = arr(i)
				arr(i) = arr(temp)
				arr(temp) = temp
			Loop
		Next i
	End Sub

	' Testing code 
	Public Shared Sub Main7(ByVal args() As String)
		Dim arr() As Integer = {8, -1, 6, 1, 9, 3, 2, 7, 4, -1}
		Dim size As Integer = arr.Length
		indexArray2(arr, size)
		printArray(arr, size)
		Dim arr2() As Integer = {8, -1, 6, 1, 9, 3, 2, 7, 4, -1}
		size = arr2.Length
		indexArray(arr2, size)
		printArray(arr2, size)
	End Sub

	Public Shared Sub Sort1toN(ByVal arr() As Integer, ByVal size As Integer)
		Dim curr, value, [next] As Integer
		For i As Integer = 0 To size - 1
			curr = i
			value = -1
			' swaps to move elements in proper position. 
			Do While curr >= 0 AndAlso curr < size AndAlso arr(curr) <> curr + 1
				[next] = arr(curr)
				arr(curr) = value
				value = [next]
				curr = [next] - 1
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

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {8, 5, 6, 1, 9, 3, 2, 7, 4, 10}
		Dim size As Integer = arr.Length
		Sort1toN2(arr, size)
		printArray(arr, size)
		Dim arr2() As Integer = {8, 5, 6, 1, 9, 3, 2, 7, 4, 10}
		size = arr2.Length
		Sort1toN(arr2, size)
		printArray(arr2, size)

	End Sub

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
		For k As Integer = 0 To size - 1
			hs(arr(k)) = 1
		Next k

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
		For i As Integer = 0 To size - 1
			aux(i) = -1
		Next i

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

	Public Shared Sub Main9(ByVal args() As String)
		Dim arr() As Integer = {8, 5, 6, 1, 9, 11, 2, 7, 4, 10}
		Dim size As Integer = arr.Length

		Console.WriteLine("Max sub array sum :" & SmallestPositiveMissingNumber(arr, size))
		Console.WriteLine("Max sub array sum :" & SmallestPositiveMissingNumber2(arr, size))
		Console.WriteLine("Max sub array sum :" & SmallestPositiveMissingNumber3(arr, size))
		Console.WriteLine("Max sub array sum :" & SmallestPositiveMissingNumber4(arr, size))
	End Sub

	'	public static void MaxMinArr(int[] arr, int size)
	'	{
	'		int[] aux = Arrays.copyOf(arr, size);
	'		int start = 0;
	'		int stop = size - 1;
	'		for (int i = 0; i < size; i++)
	'		{
	'			if (i % 2 == 0)
	'			{
	'				arr[i] = aux[stop];
	'				stop -= 1;
	'			}
	'			else
	'			{
	'				arr[i] = aux[start];
	'				start += 1;
	'			}
	'		}
	'	}
	'	
	Public Shared Sub ReverseArr(ByVal arr() As Integer, ByVal start As Integer, ByVal [stop] As Integer)
		Do While start < [stop]
			swap(arr, start, [stop])
			start += 1
			[stop] -= 1
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
	Public Shared Sub Main10(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7}
		Dim size As Integer = arr.Length
		'MaxMinArr(arr, size);
		printArray(arr, size)
		Dim arr2() As Integer = {1, 2, 3, 4, 5, 6, 7}
		Dim size2 As Integer = arr.Length
		MaxMinArr2(arr2, size2)
		printArray(arr2, size2)
	End Sub

	Public Shared Function maxCircularSum(ByVal arr() As Integer, ByVal size As Integer) As Integer
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
	Public Shared Sub Main11(ByVal args() As String)
		Dim arr() As Integer = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}
		Console.WriteLine("MaxCirculrSm: " & maxCircularSum(arr, arr.Length))
	End Sub

	Public Shared Function ArrayIndexMaxDiff(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim maxDiff As Integer = -1
		Dim j As Integer
		For i As Integer = 0 To size - 1
			j = size - 1
			Do While j > i
				If arr(j) > arr(i) Then
					maxDiff = Math.Max(maxDiff, j - i)
					Exit Do
				End If
				j -= 1
			Loop
		Next i
		Return maxDiff
	End Function

	Public Shared Function ArrayIndexMaxDiff2(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim leftMin(size - 1) As Integer
		Dim rightMax(size - 1) As Integer
		leftMin(0) = arr(0)
		Dim i, j As Integer
		Dim maxDiff As Integer
		For i = 1 To size - 1
			If leftMin(i - 1) < arr(i) Then
				leftMin(i) = leftMin(i - 1)
			Else
				leftMin(i) = arr(i)
			End If
		Next i
		rightMax(size - 1) = arr(size - 1)
		For i = size - 2 To 0 Step -1
			If rightMax(i + 1) > arr(i) Then
				rightMax(i) = rightMax(i + 1)
			Else
				rightMax(i) = arr(i)
			End If
		Next i
		i = 0
		j = 0
		maxDiff = -1
		Do While j < size AndAlso i < size
			If leftMin(i) < rightMax(j) Then
				maxDiff = Math.Max(maxDiff, j - i)
				j = j + 1
			Else
				i = i + 1
			End If
		Loop
		Return maxDiff
	End Function

	'	
	'	public static int ArrayIndexMaxDiff3(int arr[], int size) { 
	'		int[] leftMin = new int[size]; 
	'		int[] rightMax = new int[size]; 
	'		int minIndex = 0, maxIndex = 0; 
	'		int i, j; 
	'		int maxDiff; 
	'		leftMin[minIndex++] = 0;
	'		for (i = 1; i < size; i++)
	'		{
	'			if (arr[leftMin[minIndex]] > arr[i]) { 
	'				leftMin[minIndex++] = i; 
	'			} 
	'		}
	'
	'		rightMax[maxIndex++] = size - 1; 
	'		for (i = size - 2; i >= 0; i--) { 
	'			if (arr[rightMax[maxIndex]] < arr[i]) { 
	'				rightMax[maxIndex++] = i; 
	'			} 
	'		}
	'
	'		i = 0; 
	'		j = maxIndex - 1; 
	'		maxDiff = -1;
	'
	'		while (i < minIndex && j >= 0) { 
	'			if (arr[leftMin[i]] < arr[rightMax[j]]) {
	'				maxDiff = Math.max(maxDiff, rightMax[j] - leftMin[i]); 
	'				j -= 1; 
	'			} else { 
	'				i += 1; 
	'			} 
	'		} 
	'		return maxDiff; 
	'	}
	'	
	Public Shared Sub Main12(ByVal args() As String)
		Dim arr() As Integer = {33, 9, 10, 3, 2, 60, 30, 33, 1}
		Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff(arr, arr.Length))
		Console.WriteLine("ArrayIndexMaxDiff : " & ArrayIndexMaxDiff2(arr, arr.Length))
		'  System.out.println("ArrayIndexMaxDiff : " + ArrayIndexMaxDiff3(arr, arr.length));
	End Sub

	Public Shared Function maxPathSum(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer) As Integer
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
	Public Shared Sub Main13(ByVal args() As String)
		Dim arr1() As Integer = {12, 13, 18, 20, 22, 26, 70}
		Dim arr2() As Integer = {11, 15, 18, 19, 20, 26, 30, 31}
		Console.WriteLine("Max Path Sum :: " & maxPathSum(arr1, arr1.Length, arr2, arr2.Length))
	End Sub

	Public Function factorial(ByVal i As Integer) As Integer
		' Termination Condition
		If i <= 1 Then
			Return 1
		End If
		' Body, Recursive Expansion
		Return i * factorial(i - 1)
	End Function

	Public Sub printInt1(ByVal number As Integer)
		Dim digit As Char = ChrW(number Mod 10 + AscW("0"c))
		number = number \ 10
		If number <> 0 Then
			printInt1(number)
		End If

		Console.Write("%c" & digit)
	End Sub

	Public Sub printInt(ByVal number As Integer)
		Dim conversion As String = "0123456789ABCDEF"
		Dim baseValue As Integer = 16
		Dim digit As Char = ChrW(number Mod baseValue)
		number = number \ baseValue
		If number <> 0 Then
			printInt(number)
		End If

		Console.Write(conversion.Chars(AscW(digit)))
	End Sub

	Public Shared Sub towerOfHanoi(ByVal num As Integer, ByVal src As Char, ByVal dst As Char, ByVal temp As Char)
		If num < 1 Then
			Return
		End If

		towerOfHanoi(num - 1, src, temp, dst)
		Console.WriteLine("Move " & num & " disk  from peg " & src & " to peg " & dst)
		towerOfHanoi(num - 1, temp, dst, src)
	End Sub

	Public Shared Sub Main14(ByVal args() As String)
		Dim num As Integer = 4
		Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are :" & ControlChars.Lf)
		towerOfHanoi(num, "A"c, "C"c, "B"c)
	End Sub

	Public Shared Function GCD(ByVal m As Integer, ByVal n As Integer) As Integer
		If m < n Then
			Return (GCD(n, m))
		End If

		If m Mod n = 0 Then
			Return (n)
		End If

		Return (GCD(n, m Mod n))
	End Function

	Public Shared Function fibonacci(ByVal n As Integer) As Integer
		If n <= 1 Then
			Return n
		End If

		Return fibonacci(n - 1) + fibonacci(n - 2)
	End Function

	Public Shared Sub permutation(ByVal arr() As Integer, ByVal i As Integer, ByVal length As Integer)
		If length = i Then
			printArray(arr, length)
			Return
		End If
		Dim j As Integer = i
		j = i
		Do While j < length
			swap(arr, i, j)
			permutation(arr, i + 1, length)
			swap(arr, i, j)
			j += 1
		Loop
		Return
	End Sub

	Public Shared Sub Main15(ByVal args() As String)
		Dim arr(4) As Integer
		For i As Integer = 0 To 4
			arr(i) = i
		Next i
		permutation(arr, 0, 5)
	End Sub

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
	Public Shared Sub Main16(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}
		Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 6))
		Console.WriteLine(BinarySearchRecursive(arr, 0, arr.Length - 1, 16))
	End Sub
End Class