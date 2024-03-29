﻿Imports System

Public Module StringEx
Function MatchPattern(ByVal src As String, ByVal ptn As String) As Boolean
    Dim source As Char() = src.ToCharArray()
    Dim pattern As Char() = ptn.ToCharArray()
    Dim iSource As Integer = 0
    Dim iPattern As Integer = 0
    Dim sourceLen As Integer = source.Length
    Dim patternLen As Integer = pattern.Length
    For iSource = 0 To sourceLen - 1
        If source(iSource) = pattern(iPattern) Then
            iPattern += 1
        End If
        If iPattern = patternLen Then
            Return True
        End If
    Next
    Return False
End Function

' Testing code.
Sub Main2()
    Console.WriteLine(MatchPattern("harrypottermustnotgotoschool", "pottergo"))
End Sub
' True

Function MyStrdup(ByVal src As Char()) As Char()
    Dim index As Integer = 0
    Dim dst As Char() = New Char(src.Length - 1) {}
    For Each ch As Char In src
        dst(index) = ch
    Next
    Return dst
End Function

Function IsPrime(ByVal n As Integer) As Boolean
    Dim answer As Boolean = If(n > 1, True, False)
    Dim i As Integer = 2
    While i * i <= n
        If n Mod i = 0 Then
            answer = False
            Exit While
        End If
        i += 1
    End While
    Return answer
End Function

' Testing code.
Sub Main3()
    Console.Write("Prime numbers under 10 :: ")
    For i As Integer = 0 To 9
        If IsPrime(i) Then
            Console.Write(i & " ")
        End If
    Next
    Console.WriteLine()
End Sub
' Prime numbers under 10 :: 2 3 5 7

Function MyAtoi(ByVal str As String) As Integer
    Dim value As Integer = 0
    Dim size As Integer = str.Length
    For i As Integer = 0 To size - 1
        Dim ch As Char = str(i)
        value = (value << 3) + (value << 1) + (AscW(ch) - AscW("0"c))
    Next
    Return value
End Function

' Testing code.
Sub Main4()
    Console.WriteLine(MyAtoi("1000"))
End Sub
' 1000

Function IsUniqueChar(ByVal str As String) As Boolean
    Dim bitarr As Boolean() = New Boolean(25) {}
    For i As Integer = 0 To 25
        bitarr(i) = False
    Next
    Dim index As Integer
    Dim size As Integer = str.Length
    For i As Integer = 0 To size - 1
        Dim c As Char = str(i)
        If "A"c <= c AndAlso "Z"c >= c Then
            index = (AscW(c) - AscW("A"c))
        ElseIf "a"c <= c AndAlso "z"c >= c Then
            index = (AscW(c) - AscW("a"c))
        Else
            Console.WriteLine("Unknown Char!" & vbLf)
            Return False
        End If
        If bitarr(index) Then
            Console.WriteLine("Duplicate detected!")
            Return False
        End If
        bitarr(index) = True
    Next
    Console.WriteLine("No duplicate detected!")
    Return True
End Function

' Testing code.
Sub Main5()
    IsUniqueChar("aple")
    IsUniqueChar("apple")
End Sub
'	No duplicate detected!
'	Duplicate detected!

Function ToUpper(ByVal s As Char) As Char
    If s >= ChrW(97) AndAlso s <= ChrW(97 + 25) Then
        s = ChrW(AscW(s) - 32)
    End If
    Return s
End Function

Function ToLower(ByVal s As Char) As Char
    If s >= ChrW(65) AndAlso s <= ChrW(65 + 25) Then
        s = ChrW(AscW(s) + 32)
    End If
    Return s
End Function

Function LowerUpper(ByVal s As Char) As Char
    If s >= ChrW(97) AndAlso s <= ChrW(97 + 25) Then
        s = ChrW(AscW(s) - 32)
    ElseIf s >= ChrW(65) AndAlso s <= ChrW(65 + 25) Then
        s = ChrW(AscW(s) + 32)
    End If
    Return s
End Function

' Testing code.
Sub Main6()
    Console.WriteLine(ToLower("A"c))
    Console.WriteLine(ToUpper("a"c))
    Console.WriteLine(LowerUpper("s"c))
    Console.WriteLine(LowerUpper("S"c))
End Sub

'	a
'	A
'	S
'	s

Function IsPermutation(ByVal s1 As String, ByVal s2 As String) As Boolean
    Dim count As Integer() = New Integer(255) {}
    Dim length As Integer = s1.Length
    If s2.Length <> length Then
        Console.WriteLine("is permutation return false")
        Return False
    End If
    For i As Integer = 0 To length - 1
        Dim ch As Char = s1(i)
        count(AscW(ch)) += 1
        ch = s2(i)
        count(AscW(ch)) -= 1
    Next
    For i As Integer = 0 To length - 1
        If count(i) <> 0 Then
            Console.WriteLine("Strings are not permutation.")
            Return False
        End If
    Next
    Console.WriteLine("Strings are permutation.")
    Return True
End Function

' Testing code.
Sub Main7()
    Console.WriteLine(IsPermutation("apple", "plepa"))
End Sub

'	Strings are permutation.
'	True

Function IsPalindrome(ByVal str As String) As Boolean
    Dim i As Integer = 0, j As Integer = str.Length - 1
    While i < j AndAlso str(i) = str(j)
        i += 1
        j -= 1
    End While
    If i < j Then
        Console.WriteLine("String is not a Palindrome")
        Return False
    Else
        Console.WriteLine("String is a Palindrome")
        Return True
    End If
End Function

' Testing code.
Sub Main8()
    IsPalindrome("hello")
    IsPalindrome("oyo")
End Sub
'	String is not a Palindrome
'	String is a Palindrome

Function Pow(ByVal x As Integer, ByVal n As Integer) As Integer
    Dim value As Integer
    If n = 0 Then
        Return (1)
    ElseIf n Mod 2 = 0 Then
        value = Pow(x, n \ 2)
        Return (value * value)
    Else
        value = Pow(x, n \ 2)
        Return (x * value * value)
    End If
End Function

' Testing code.
Sub Main9()
    Console.WriteLine(Pow(5, 2))
End Sub
' 25

Function MyStrcmp(ByVal a As String, ByVal b As String) As Integer
    Dim index As Integer = 0
    Dim len1 As Integer = a.Length
    Dim len2 As Integer = b.Length
    Dim minlen As Integer = If(len1 < len2, len1, len2)

    While index < minlen AndAlso a(index) = b(index)
        index += 1
    End While

    If index = len1 AndAlso index = len2 Then
        Return 0
    ElseIf len1 = index Then
        Return -1
    ElseIf len2 = index Then
        Return 1
    Else
        Return AscW(a(index)) - AscW(b(index))
    End If
End Function

' Testing code.
Sub Main10()
    Console.WriteLine(MyStrcmp("apple", "appke"))
    Console.WriteLine(MyStrcmp("apple", "apple"))
    Console.WriteLine(MyStrcmp("apple", "appme"))
End Sub
' 1
' 0
' -1

Function ReverseString(ByVal str As String) As String
    Dim a As Char() = str.ToCharArray()
    ReverseStringUtil(a)
    Dim expn As String = New String(a)
    Return expn
End Function

Sub ReverseStringUtil(ByVal a As Char())
    Dim lower As Integer = 0
    Dim upper As Integer = a.Length - 1
    Dim tempChar As Char
    While lower < upper
        tempChar = a(lower)
        a(lower) = a(upper)
        a(upper) = tempChar
        lower += 1
        upper -= 1
    End While
End Sub

Sub ReverseStringUtil(ByVal a As Char(), ByVal lower As Integer, ByVal upper As Integer)
    Dim tempChar As Char
    While lower < upper
        tempChar = a(lower)
        a(lower) = a(upper)
        a(upper) = tempChar
        lower += 1
        upper -= 1
    End While
End Sub

Function ReverseWords(ByVal str As String) As String
    Dim a As Char() = str.ToCharArray()
    Dim length As Integer = a.Length
    Dim lower As Integer = 0, upper As Integer = -1
    For i As Integer = 0 To length
        If i = length OrElse a(i) = " "c Then
            ReverseStringUtil(a, lower, upper)
            lower = i + 1
            upper = i
        Else
            upper += 1
        End If
    Next
    ReverseStringUtil(a, 0, length - 1)
    Dim expn As String = New String(a)
    Return expn
End Function

' Testing code.
Sub Main11()
    Console.WriteLine(ReverseString("apple"))
    Console.WriteLine(ReverseWords("hello world"))
End Sub

'	elppa
'	world hello

Sub PrintAnagram(ByVal str As String)
    PrintAnagram(str.ToCharArray(), 0, str.Length)
End Sub

Sub PrintAnagram(ByVal arr As Char(), ByVal i As Integer, ByVal length As Integer)
    If length = i Then
        PrintArray(arr, length)
        Return
    End If
    For j As Integer = i To length - 1
        Swap(arr, i, j)
        PrintAnagram(arr, i + 1, length)
        Swap(arr, i, j)
    Next
End Sub

Sub PrintArray(ByVal arr As Char(), ByVal n As Integer)
    For i As Integer = 0 To n - 1
        Console.Write(arr(i))
    Next
    Console.WriteLine()
End Sub

Sub Swap(ByVal arr As Char(), ByVal i As Integer, ByVal j As Integer)
    Dim temp As Char = arr(i)
    arr(i) = arr(j)
    arr(j) = temp
End Sub

' Testing code.
Sub Main12()
    PrintAnagram("123")
End Sub

'	123
'	213
'	321
'	231
'	132
'	312

Sub Shuffle(ByVal str As String)
    Dim ar As Char() = str.ToCharArray()
    Dim n As Integer = ar.Length \ 2
    Dim count As Integer = 0
    Dim k As Integer = 1
    Dim temp2 As Char, temp As Char = vbNullChar
    Dim i As Integer
    For i = 1 To n - 1 Step 2
        temp = ar(i)
        k = i
        Do
            k = (2 * k) Mod (2 * n - 1)
            temp2 = temp
            temp = ar(k)
            ar(k) = temp2
            count += 1
        Loop While i <> k
        If count = (2 * n - 2) Then
            Exit For
        End If
    Next
    Console.WriteLine(ar)
End Sub

' Testing code.
Sub Main13()
    Shuffle("ABCDE12345")
End Sub
' A1B2C3D4E5

Function AddBinary(ByVal st1 As String, ByVal st2 As String) As String
    Dim str1 As Char() = st1.ToCharArray()
    Dim str2 As Char() = st2.ToCharArray()
    Dim size1 As Integer = str1.Length
    Dim size2 As Integer = str2.Length
    Dim max As Integer = If((size1 > size2), size1, size2)
    Dim total As Char() = New Char(max) {}
    Dim first As Integer = 0, second As Integer = 0, sum As Integer = 0, carry As Integer = 0
    Dim index As Integer = max
    While index > 0
        first = If(size1 <= 0, 0, AscW(str1(size1 - 1)) - AscW("0"c))
        second = If(size2 <= 0, 0, AscW(str2(size2 - 1)) - AscW("0"c))
        sum = first + second + carry
        carry = sum >> 1
        sum = sum And 1
        total(index) = If(sum = 0, "0"c, "1"c)
        index -= 1
        size1 -= 1
        size2 -= 1
    End While
    total(0) = If(carry = 0, "0"c, "1"c)
    Return New String(total)
End Function

' Testing code.
Sub Main14()
    Console.WriteLine(AddBinary("1000", "11111111"))
End Sub
' 100000111

Sub Main(ByVal args As String())
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
End Sub
End Module