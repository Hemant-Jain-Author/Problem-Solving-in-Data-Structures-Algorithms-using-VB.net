Imports System

Public Class StringAlgo
	Public Function matchExpUtil(ByVal exp() As Char, ByVal str() As Char, ByVal i As Integer, ByVal j As Integer) As Boolean
		If i = exp.Length AndAlso j = str.Length Then
			Return True
		End If
		If (i = exp.Length AndAlso j <> str.Length) OrElse (i <> exp.Length AndAlso j = str.Length) Then
			Return False
		End If
		If exp(i) = "?"c OrElse exp(i) = str(j) Then
			Return matchExpUtil(exp, str, i + 1, j + 1)
		End If
		If exp(i) = "*"c Then
			Return matchExpUtil(exp, str, i + 1, j) OrElse matchExpUtil(exp, str, i, j + 1) OrElse matchExpUtil(exp, str, i + 1, j + 1)
		End If
		Return False
	End Function


	Public Sub shuffle(ByVal ar() As Char, ByVal n As Integer)
		Dim count As Integer = 0
		Dim k As Integer = 1
		Dim temp As Char = ControlChars.NullChar
		Dim temp2 As Char = ControlChars.NullChar

		For i As Integer = 1 To n - 1 Step 2
			temp = ar(i)
			k = i
			Do
				k = (2 * k) Mod (2 * n - 1)
				temp2 = ar(k)
				ar(k) = temp
				temp = temp2
				count += 1
			Loop While i <> k
			If count = (2 * n - 2) Then
				Exit For
			End If
		Next i
	End Sub

	Public Function matchExp(ByVal exp() As Char, ByVal str() As Char) As Boolean
		Return matchExpUtil(exp, str, 0, 0)
	End Function

	Public Function match(ByVal source() As Char, ByVal pattern() As Char) As Integer
		Dim iSource As Integer = 0
		Dim iPattern As Integer = 0
		Dim sourceLen As Integer = source.Length
		Dim patternLen As Integer = pattern.Length
		For iSource = 0 To sourceLen - 1
			If source(iSource) = pattern(iPattern) Then
				iPattern += 1
			End If
			If iPattern = patternLen Then
				Return 1
			End If
		Next iSource
		Return 0
	End Function

	Public Function myStrdup(ByVal src() As Char) As Char()
		Dim index As Integer = 0
		Dim dst(src.Length - 1) As Char
		For Each ch As Char In src
			dst(index) = ch
		Next ch
		Return dst
	End Function


	Private Function isPrime(ByVal n As Integer) As Boolean
		Dim answer As Boolean = If(n > 1, True, False)

		Dim i As Integer = 2
		Do While i * i <= n
			If n Mod i = 0 Then
				answer = True
				Exit Do
			End If
			i += 1
		Loop
		Return answer
	End Function



	Public Function myAtoi(ByVal str As String) As Integer
		Dim value As Integer = 0

		Dim size As Integer = str.Length
		For i As Integer = 0 To size - 1
			Dim ch As Char = str.Chars(i)
			value = (value << 3) + (value << 1) + (AscW(ch) - AscW("0"c))
		Next i
		Return value
	End Function

	Public Function isUniqueChar(ByVal str As String) As Boolean
		Dim bitarr(25) As Integer
		For i As Integer = 0 To 25
			bitarr(i) = 0
		Next i
		Dim size As Integer = str.Length
		For i As Integer = 0 To size - 1
			Dim c As Char = str.Chars(i)
			If "A"c <= c AndAlso "Z"c >= c Then
				c = ChrW(AscW(c) - AscW("A"c))
			ElseIf "a"c <= c AndAlso "z"c >= c Then
				c = ChrW(AscW(c) - AscW("a"c))
			Else
				Console.WriteLine("Unknown Char!")
				Return False
			End If
			If bitarr(AscW(c)) <> 0 Then
				Console.WriteLine("Duplicate detected!")
				Return False
			End If
		Next i
		Console.WriteLine("No duplicate detected!")
		Return True
	End Function

	Public Function ToUpper(ByVal s As Char) As Char
		If AscW(s) >= 97 AndAlso AscW(s) <= (97 + 25) Then
			s = ChrW(AscW(s) - 32)
		End If
		Return s
	End Function

	Public Function ToLower(ByVal s As Char) As Char
		If AscW(s) >= 65 AndAlso AscW(s) <= (65 + 25) Then
			s = ChrW(AscW(s) + 32)
		End If
		Return s
	End Function



	Public Function LowerUpper(ByVal s As Char) As Char
		If AscW(s) >= 97 AndAlso AscW(s) <= (97 + 25) Then
			s = ChrW(AscW(s) - 32)
		ElseIf AscW(s) >= 65 AndAlso AscW(s) <= (65 + 25) Then
			s = ChrW(AscW(s) + 32)
		End If
		Return s
	End Function


	Public Function isPermutation(ByVal s1 As String, ByVal s2 As String) As Boolean
		Dim count(255) As Integer
		Dim length As Integer = s1.Length
		If s2.Length <> length Then
			Console.WriteLine("is permutation return false")
			Return False
		End If
		For i As Integer = 0 To 255
			count(i) = 0
		Next i
		For i As Integer = 0 To length - 1
			Dim ch As Char = s1.Chars(i)
			count(AscW(ch)) += 1
			ch = s2.Chars(i)
			count(AscW(ch)) -= 1
		Next i
		For i As Integer = 0 To length - 1
			If count(i) <> 0 Then
				Console.WriteLine("is permutation return false")
				Return False
			End If
		Next i
		Console.WriteLine("is permutation return true")
		Return True
	End Function

	Public Function isPalindrome(ByVal str As String) As Boolean
		Dim i As Integer = 0, j As Integer = str.Length - 1
		Do While i < j AndAlso str.Chars(i) = str.Chars(j)
			i += 1
			j -= 1
		Loop
		If i < j Then
			Console.WriteLine("String is not a Palindrome")
			Return False
		Else
			Console.WriteLine("String is a Palindrome")
			Return True
		End If
	End Function

	Public Function pow(ByVal x As Integer, ByVal n As Integer) As Integer
		Dim value As Integer
		If n = 0 Then
			Return (1)
		ElseIf n Mod 2 = 0 Then
			value = pow(x, n \ 2)
			Return (value * value)
		Else
			value = pow(x, n \ 2)
			Return (x * value * value)
		End If
	End Function

	Public Function myStrcmp(ByVal a As String, ByVal b As String) As Integer
		Dim index As Integer = 0
		Dim len1 As Integer = a.Length
		Dim len2 As Integer = b.Length
		Dim minlen As Integer = len1
		If len1 > len2 Then
			minlen = len2
		End If

		Do While index < minlen AndAlso a.Chars(index) = b.Chars(index)
			index += 1
		Loop

		If index = len1 AndAlso index = len2 Then
			Return 0
		ElseIf len1 = index Then
			Return -1
		ElseIf len2 = index Then
			Return 1
		Else
			Return AscW(a.Chars(index)) - AscW(b.Chars(index))
		End If
	End Function

	Public Sub reverseString(ByVal a() As Char)
		Dim lower As Integer = 0
		Dim upper As Integer = a.Length - 1
		Dim tempChar As Char
		Do While lower < upper
			tempChar = a(lower)
			a(lower) = a(upper)
			a(upper) = tempChar
			lower += 1
			upper -= 1
		Loop
	End Sub

	Public Sub reverseString(ByVal a() As Char, ByVal lower As Integer, ByVal upper As Integer)
		Dim tempChar As Char
		Do While lower < upper
			tempChar = a(lower)
			a(lower) = a(upper)
			a(upper) = tempChar
			lower += 1
			upper -= 1
		Loop
	End Sub

	Public Sub reverseWords(ByVal a() As Char)
		Dim length As Integer = a.Length
		Dim lower As Integer, upper As Integer = -1
		lower = 0
		For i As Integer = 0 To length
			If a(i) = " "c OrElse a(i) = ControlChars.NullChar Then
				reverseString(a, lower, upper)
				lower = i + 1
				upper = i
			Else
				upper += 1
			End If
		Next i
		reverseString(a, 0, length - 1) '-1 because we do not want to reverse �\0�
	End Sub

	Public Sub printAnagram(ByVal a() As Char)
		Dim n As Integer = a.Length
		printAnagram(a, 0, n)
	End Sub
	Public Sub printAnagram(ByVal a() As Char, ByVal max As Integer, ByVal n As Integer)
		If max = 1 Then
			Console.WriteLine(a.ToString())
		End If
		Dim temp As Char
		Dim i As Integer = -1
		Do While i < max - 1
			If i <> -1 Then
				temp = a(max - 1)
				a(max - 1) = a(i)
				a(i) = temp
			End If
			printAnagram(a, max - 1, n)
			If i <> -1 Then
				temp = a(max - 1)
				a(max - 1) = a(i)
				a(i) = temp
			End If
			i += 1
		Loop
	End Sub

	Public Function addBinary(ByVal first() As Char, ByVal second() As Char) As Char()
		Dim size1 As Integer = first.Length
		Dim size2 As Integer = second.Length
		Dim totalIndex As Integer
		Dim total() As Char
		If size1 > size2 Then
			total = New Char((size1 + 2) - 1) {}
			totalIndex = size1
		Else
			total = New Char((size2 + 2) - 1) {}
			totalIndex = size2
		End If
		total(totalIndex + 1) = ControlChars.NullChar
		Dim carry As Integer = 0
		size1 -= 1
		size2 -= 1
		Do While size1 >= 0 OrElse size2 >= 0
			Dim firstValue As Integer = If(size1 < 0, 0, AscW(first(size1)) - AscW("0"c))
			Dim secondValue As Integer = If(size2 < 0, 0, AscW(second(size2)) - AscW("0"c))
			Dim sum As Integer = firstValue + secondValue + carry
			carry = sum >> 1
			sum = sum And 1
			total(totalIndex) = If(sum = 0, "0"c, "1"c)
			totalIndex -= 1
			size1 -= 1
			size2 -= 1
		Loop
		total(totalIndex) = If(carry = 0, "0"c, "1"c)
		Return total
	End Function
End Class