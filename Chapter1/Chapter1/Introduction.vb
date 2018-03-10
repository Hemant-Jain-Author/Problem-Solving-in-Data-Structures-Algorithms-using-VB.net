Imports System


Public Class MyInt
	Public value As Integer
End Class

Public Class Introduction2

	Public Shared Sub increment(ByVal var As Integer)
		var += 1
	End Sub



	Public Shared Sub Main66(ByVal args() As String)
		Dim x As Integer = 10
		Console.WriteLine("Value of i before increment is :  " & x)
		increment(x)
		Console.WriteLine("Value of i after increment is :  " & x)
	End Sub

	Public Shared Sub increment(ByVal value As MyInt)
		value.value += 1
	End Sub
	Public Shared Sub Maineee(ByVal args() As String)
		Dim x As New MyInt()
		x.value = 10
		Console.WriteLine("Value of i before increment is :  " & x.value)
		increment(x)
		Console.WriteLine("Value of i after increment is :  " & x.value)
	End Sub



	Public Shared Sub printArray(ByVal arr() As Integer, ByVal count As Integer)
		Console.Write(ControlChars.Lf & " Values stored in array are : ")
		For i As Integer = 0 To count - 1
			Console.Write(" " & arr(i))
		Next i
	End Sub

	Public Shared Sub swap(ByVal arr() As Integer, ByVal x As Integer, ByVal y As Integer)
		Dim temp As Integer = arr(x)
		arr(x) = arr(y)
		arr(y) = temp
		Return
	End Sub
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

	Friend Overridable Sub main12()
		Dim arr(4) As Integer
		For i As Integer = 0 To 4
			arr(i) = i
		Next i
		permutation(arr, 0, 5)
	End Sub


	Public Shared Sub Main33(ByVal args() As String)
		Dim arr(4) As Integer
		For i As Integer = 0 To 4
			arr(i) = i
		Next i
		permutation(arr, 0, 5)
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


	Public Shared Sub towerOfHanoi(ByVal num As Integer, ByVal src As Char, ByVal dst As Char, ByVal temp As Char)
		If num < 1 Then
			Return
		End If

		towerOfHanoi(num - 1, src, temp, dst)
		Console.WriteLine("Move " & num & " disk  from peg " & src & " to peg " & dst)
		towerOfHanoi(num - 1, temp, dst, src)
	End Sub


	Public Shared Sub Main3443(ByVal args() As String)
		Dim num As Integer = 4
		Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are :" & ControlChars.Lf)
		towerOfHanoi(num, "A"c, "C"c, "B"c)
	End Sub

	Public Shared Sub function2()
		Console.WriteLine("fun2 line 1")
	End Sub

	Public Shared Sub function1()
		Console.WriteLine("fun1 line 1")
		function2()
		Console.WriteLine("fun1 line 2")
	End Sub

	Public Shared Sub main()
		Console.WriteLine("main line 1")
		function1()
		Console.WriteLine("main line 2")
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

	Friend Shared Sub variableExample()
		Dim var1, var2, var3 As Integer
		var1 = 100
		var2 = 200
		var3 = var1 + var2
		Console.WriteLine("Adding " & var1 & " and " & var2 & " will give " & var3)
	End Sub

	Public Shared Sub arrayExample()
		Dim arr(9) As Integer
		For i As Integer = 0 To 9
			arr(i) = i
		Next i
		printArray1(arr, 10)
	End Sub

	Public Shared Sub printArray1(ByVal arr() As Integer, ByVal count As Integer)
		Console.WriteLine("Values stored in array are : ")
		For i As Integer = 0 To count - 1
			Console.WriteLine(" " & arr(i))
		Next i
	End Sub

	Public Shared Sub twoDArrayExample()
		Dim arr(3, 1) As Integer
		Dim count As Integer = 0
		For i As Integer = 0 To 3
			For j As Integer = 0 To 1
				arr(i, j) = count
				count += 1
			Next j
		Next i
		print2DArray(arr, 4, 2)
	End Sub

	Public Shared Sub print2DArray(ByVal arr(,) As Integer, ByVal row As Integer, ByVal col As Integer)
		For i As Integer = 0 To row - 1
			For j As Integer = 0 To col - 1
				Console.WriteLine(" " & arr(i, j))
			Next j
		Next i
	End Sub

	Public Shared Function SumArray(ByVal arr() As Integer) As Integer
		Dim size As Integer = arr.Length
		Dim total As Integer = 0
		Dim index As Integer = 0
		For index = 0 To size - 1
			total = total + arr(index)
		Next index
		Return total
	End Function

	Public Shared Function SequentialSearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		For i As Integer = 0 To size - 1
			If value = arr(i) Then
				Return i
			End If
		Next i
		Return -1
	End Function

	' Binary Search Algorithm � Iterative Way  
	Public Shared Function BinarySearch(ByVal arr() As Integer, ByVal size As Integer, ByVal value As Integer) As Integer
		Dim mid As Integer
		Dim low As Integer = 0
		Dim high As Integer = size - 1
		Do While low <= high
			mid = low + (high - low) \ 2 ' To avoid the overflow
			If arr(mid) = value Then
				Return mid
			ElseIf arr(mid) < value Then
				low = mid + 1
			Else
				high = mid - 1
			End If
		Loop
		Return -1
	End Function


	Public Shared Sub rotateArray(ByVal a() As Integer, ByVal n As Integer, ByVal k As Integer)
		reverseArray(a, 0, k - 1)
		reverseArray(a, k, n - 1)
		reverseArray(a, 0, n - 1)
	End Sub

	Public Shared Sub reverseArray(ByVal a() As Integer, ByVal startind As Integer, ByVal endind As Integer)
		Dim i As Integer = startind
		Dim j As Integer = endind
		Do While i < j
			Dim temp As Integer = a(i)
			a(i) = a(j)
			a(j) = temp
			i += 1
			j -= 1
		Loop
	End Sub

	Public Shared Sub reverseArray(ByVal a() As Integer)
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

	Friend Class coord
		Friend x As Integer
		Friend y As Integer
	End Class

	Friend Overridable Function main2() As Integer
		Dim point As New coord()
		point.x = 10
		point.y = 10
		Console.WriteLine("X axis coord value is  " & point.x)
		Console.WriteLine("Y axis coord value is  " & point.y)
		Return 0
	End Function

	Friend Class student

		Friend rollNo As Integer
		Friend firstName As String
		Friend lastName As String
	End Class

	Friend Overridable Function main3() As Integer
		Dim stud As New student()
		Dim refStud As student
		refStud = stud
		refStud.rollNo = 1
		refStud.firstName = "john"
		refStud.lastName = "smith"
		Console.WriteLine("Roll No:   Student Name:  " & refStud.rollNo & refStud.firstName & refStud.lastName)

		Return 0
	End Function

	' function declaration 
	Friend Overridable Function main4() As Integer
		' local variable definition 
		Dim x As Integer = 10
		Dim y As Integer = 20
		Dim result As Integer
		' calling a function to find sum 
		result = sum(x, y)
		Console.WriteLine("Sum is : " & result)
		Return 0
	End Function

	' function returning the sum of two numbers 
	Friend Overridable Function sum(ByVal num1 As Integer, ByVal num2 As Integer) As Integer
		' local variable declaration 
		Dim result As Integer
		result = num1 + num2
		Return result
	End Function

	Public Shared Function factorial(ByVal i As Integer) As Integer
		' Termination Condition 
		If i <= 1 Then
			Return 1
		End If
		' Body, Recursive Expansion 
		Return i * factorial(i - 1)
	End Function

	Public Shared Sub printInt1(ByVal number As Integer)
		Dim digit As Char = ChrW(number Mod 10 + AscW("0"c))
		number = number \ 10
		If number <> 0 Then
			printInt1(number \ 10)
		End If
		Console.Write("%c" & digit)
	End Sub

	'JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
	'ORIGINAL LINE: public static void printInt2(int number, final int super)
	Public Shared Sub printInt2(ByVal number As Integer, ByVal baseValue As Integer)
		Dim conversion As String = "0123456789ABCDEF"
		Dim digit As Char = ChrW(number Mod baseValue)
		number = number \ baseValue
		If number <> 0 Then
			printInt2(number, baseValue)
		End If
		Console.Write(" " & conversion.Chars(AscW(digit)))
	End Sub

	'			char * intToStr(char *p, unsigned int number)
	'			{
	'				char digit = number % 10 + '0';
	'				if (number /= 10) 
	'					p = intToStr(p, number);
	'				*p++ = digit;
	'				return (p);
	'			}









	Public Shared Function fibonacci(ByVal n As Integer) As Integer
		If n <= 1 Then
			Return n
		End If
		Return fibonacci(n - 1) + fibonacci(n - 2)
	End Function




	' Binary Search Algorithm � Recursive Way 
	Public Shared Function BinarySearchRecursive(ByVal arr() As Integer, ByVal low As Integer, ByVal high As Integer, ByVal value As Integer) As Integer
		Dim mid As Integer = low + (high - low) \ 2 ' To avoid the overflow
		If arr(mid) = value Then
			Return mid
		ElseIf arr(mid) < value Then
			Return BinarySearchRecursive(arr, mid + 1, high, value)
		Else
			Return BinarySearchRecursive(arr, low, mid - 1, value)
		End If
	End Function

End Class
