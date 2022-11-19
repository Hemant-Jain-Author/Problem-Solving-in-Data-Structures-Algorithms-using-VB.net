
Imports System
Imports System.Collections.Generic

Public Class SortingEx

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

	Public Shared Function Partition01(ByVal arr() As Integer, ByVal size As Integer) As Integer
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
				Swap(arr, left, right)
				count += 1
			End If
		Loop
		Return count
	End Function

	Public Shared Sub Partition012_(ByVal arr() As Integer, ByVal size As Integer)
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
		Do While zero > 0
			arr(index) = 0
			index += 1
			zero -= 1
		Loop
		Do While one > 0
			arr(index) = 1
			index += 1
			one -= 1
		Loop
		Do While two > 0
			arr(index) = 2
			index += 1
			two -= 1
		Loop
	End Sub

	Public Shared Sub Partition012(ByVal arr() As Integer, ByVal size As Integer)
		Dim left As Integer = 0
		Dim right As Integer = size - 1
		Dim i As Integer = 0
		Do While i <= right
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
		Loop
	End Sub

	' Testing code
	Public Shared Sub Main1()
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
	Public Shared Sub RangePartition(ByVal arr() As Integer, ByVal size As Integer, ByVal lower As Integer, ByVal higher As Integer)
		Dim start As Integer = 0
		Dim [end] As Integer = size - 1
		Dim i As Integer = 0
		Do While i <= [end]
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
		Loop
	End Sub

	' Testing code
	Public Shared Sub Main2()
		Dim arr() As Integer = {1, 2, 3, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11}
		RangePartition(arr, arr.Length, 9, 12)
		PrintArray(arr, arr.Length)
	End Sub
	'
	'[ 1 2 3 4 5 6 7 8 10 12 9 11 14 13 15 16 17 18 ]
	'


	Public Shared Function MinSwaps(ByVal arr() As Integer, ByVal size As Integer, ByVal val As Integer) As Integer
		Dim SwapCount As Integer = 0
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
				SwapCount += 1
			End If
		Loop
		Return SwapCount
	End Function

	'Testing code
	Public Shared Sub Main3()
		Dim array() As Integer = {1, 2, 3, 4, 18, 5, 17, 6, 16, 7, 15, 8, 14, 9, 13, 10, 12, 11}
		Console.WriteLine("MinSwaps " & MinSwaps(array, array.Length, 10))
	End Sub
	' MinSwaps 3

	Public Shared Sub SeparateEvenAndOdd(ByVal data() As Integer, ByVal size As Integer)
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

	Public Shared Sub SeparateEvenAndOdd2(ByVal data() As Integer, ByVal size As Integer)
		Dim left As Integer = 0, right As Integer = size - 1
		Do While left < right
			If data(left) Mod 2 = 0 Then
				left += 1
			ElseIf data(right) Mod 2 = 1 Then
				right -= 1
			Else
				Swap(data, left, right)
				left += 1
				right -= 1
			End If
		Loop
	End Sub

	' Testing code
	Public Shared Sub Main4()
		Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		SeparateEvenAndOdd(array, array.Length)
		PrintArray(array, array.Length)
		Dim array2() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		SeparateEvenAndOdd2(array2, array2.Length)
		PrintArray(array2, array2.Length)
	End Sub
	' [ 8 2 6 4 5 3 7 1 9 ]
	' [ 4 6 8 2 7 3 1 9 5 ]

	Public Shared Function AbsGreater(ByVal value1 As Integer, ByVal value2 As Integer, ByVal ref As Integer) As Boolean
		Return (Math.Abs(value1 - ref) > Math.Abs(value2 - ref))
	End Function

	Public Shared Sub AbsBubbleSort(ByVal arr() As Integer, ByVal size As Integer, ByVal ref As Integer)
		Dim i As Integer = 0
		Do While i < (size - 1)
			Dim j As Integer = 0
			Do While j < (size - i - 1)
				If AbsGreater(arr(j), arr(j + 1), ref) Then
					Swap(arr, j, j + 1)
				End If
				j += 1
			Loop
			i += 1
		Loop
	End Sub

	' Testing code
	Public Shared Sub Main5()
		Dim array() As Integer = {9, 1, 8, 2, 7, 3, 6, 4, 5}
		Dim reference As Integer = 5
		AbsBubbleSort(array, array.Length, reference)
		PrintArray(array, array.Length)
	End Sub
	'
	'[ 5 6 4 7 3 8 2 9 1 ]
	'
	Public Shared Function EqGreater(ByVal value1 As Integer, ByVal value2 As Integer, ByVal A As Integer) As Boolean
		value1 = A * value1 * value1
		value2 = A * value2 * value2
		Return value1 > value2
	End Function

	Public Shared Sub ArrayReduction(ByVal arr() As Integer, ByVal size As Integer)
		Array.Sort(arr)
		Dim count As Integer = 1
		Dim reduction As Integer = arr(0)

		For i As Integer = 0 To size - 1
			If arr(i) - reduction > 0 Then
				reduction = arr(i)
				count += 1
				Console.WriteLine(size - i)
			End If
		Next i
		Console.WriteLine(0) ' after all the reduction the array will be empty.
		Console.WriteLine("Total number of reductions: " & count)
	End Sub

	' Testing code
	Public Shared Sub Main6()
		Dim arr() As Integer = {5, 1, 1, 1, 2, 3, 5}
		ArrayReduction(arr, arr.Length)
	End Sub
	'
	'4
	'3
	'2
	'0
	'Total number of reductions: 4
	'

	Public Shared Sub SortByOrder(ByVal arr() As Integer, ByVal size As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
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
	Public Shared Sub Main7()
		Dim arr() As Integer = {2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8}
		Dim arr2() As Integer = {2, 1, 8, 3}
		SortByOrder(arr, arr.Length, arr2, arr2.Length)
		Console.WriteLine()
	End Sub
	'
	'2 2 1 1 8 8 3 5 7 9 6 

	Public Shared Sub Merge(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
		Dim index As Integer = 0
		Dim temp As Integer
		Do While index < size1
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
				Do While i < (size2 - 1)
					If arr2(i) < arr2(i + 1) Then
						Exit Do
					End If
					temp = arr2(i)
					arr2(i) = arr2(i + 1)
					arr2(i + 1) = temp
					i += 1
				Loop
			End If
		Loop
	End Sub

	' Testing code.
	Public Shared Sub Main8()
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

	Public Shared Function CheckReverse(ByVal arr() As Integer, ByVal size As Integer) As Boolean
		Dim start As Integer = -1
		Dim finish As Integer = -1
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
				finish = i
				Exit Do
			End If
			i += 1
		Loop

		If finish = -1 Then
			Return True
		End If

		' increasing property
		' after reversal the sub array should fit in the array.
		If arr(start - 1) > arr(finish) OrElse arr(finish + 1) < arr(start) Then
			Return False
		End If

		i = finish + 1
		Do While i < size - 1
			If arr(i) > arr(i + 1) Then
				Return False
			End If
			i += 1
		Loop
		Return True
	End Function

	Public Shared Sub Main9()
		Dim arr1() As Integer = {1, 2, 6, 5, 4, 7}
		Console.WriteLine(CheckReverse(arr1, arr1.Length))
	End Sub
	' True

	Public Shared Function Min(ByVal X As Integer, ByVal Y As Integer) As Integer
		If X < Y Then
			Return X
		End If
		Return Y
	End Function

	Public Shared Sub UnionIntersectionSorted(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
		Dim first As Integer = 0, second As Integer = 0
		Dim unionArr((size1 + size2) - 1) As Integer
		Dim interArr(Min(size1, size2) - 1) As Integer
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
		PrintArray(unionArr, uIndex)
		PrintArray(interArr, iIndex)
	End Sub

	Public Shared Sub unionIntersectionUnsorted(ByVal arr1() As Integer, ByVal size1 As Integer, ByVal arr2() As Integer, ByVal size2 As Integer)
		Array.Sort(arr1)
		Array.Sort(arr2)
		UnionIntersectionSorted(arr1, size1, arr2, size2)
	End Sub

	Public Shared Sub Main10()
		Dim arr1() As Integer = {1, 11, 2, 3, 14, 5, 6, 8, 9}
		Dim arr2() As Integer = {2, 4, 5, 12, 7, 8, 13, 10}
		unionIntersectionUnsorted(arr1, arr1.Length, arr2, arr2.Length)
	End Sub
	'
	'[ 1 2 3 4 5 6 7 8 9 10 11 12 13 14 ]
	'[ 2 5 8 ]
	'
	Public Shared Sub Main(ByVal args() As String)
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
	End Sub
End Class