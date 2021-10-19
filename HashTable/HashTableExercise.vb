Imports System
Imports System.Collections.Generic

Public Class HashTableExercise

	Public Shared Sub Main(ByVal args() As String)
		Main1()
		Main2()
		Main3()
		Main4()
		Main5()
	End Sub

	Public Shared Function IsAnagram(ByVal str1() As Char, ByVal str2() As Char) As Boolean
		Dim size1 As Integer = str1.Length
		Dim size2 As Integer = str2.Length
		If size1 <> size2 Then
			Return False
		End If

		Dim hm As New Dictionary(Of Char, Integer)()
		For Each ch As Char In str1
			If hm.ContainsKey(ch) Then
				hm(ch) = hm(ch) + 1
			Else
				hm(ch) = 1
			End If
		Next ch

		For Each ch As Char In str2
			If hm.ContainsKey(ch) = False OrElse hm(ch) = 0 Then
				Return False
			Else
				hm(ch) = hm(ch) - 1
			End If
		Next ch
		Return True
	End Function

	Public Shared Sub Main1()
		Dim first() As Char = "hello".ToCharArray()
		Dim second() As Char = "elloh".ToCharArray()
		Dim third() As Char = "world".ToCharArray()

		Console.WriteLine("IsAnagram : " & IsAnagram(first, second))
		Console.WriteLine("IsAnagram : " & IsAnagram(first, third))
	End Sub
	'	
	'	IsAnagram : True
	'	IsAnagram : False
	'	

	Public Shared Function RemoveDuplicate(ByVal str() As Char) As String
		Dim hs As New HashSet(Of Char)()
		Dim output As String = ""

		For Each ch As Char In str
			If hs.Contains(ch) = False Then
				output &= ch
				hs.Add(ch)
			End If
		Next ch
		Return output
	End Function

	Public Shared Sub Main2()
		Dim first() As Char = "hello".ToCharArray()
		Console.WriteLine(RemoveDuplicate(first))
	End Sub
	'	
	'	helo
	'	

	Public Shared Function FindMissing(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Integer
		Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()
		For Each i As Integer In arr
			hs.Add(i)
		Next i

		For curr As Integer = start To [end]
			If hs.Contains(curr) = False Then
				Return curr
			End If
		Next curr
		Return Integer.MaxValue
	End Function

	Public Shared Sub Main3()
		Dim arr() As Integer = {1, 2, 3, 5, 6, 7, 8, 9, 10}
		Console.WriteLine(FindMissing(arr, 1, 10))
	End Sub
	'	
	'	4
	'	

	Public Shared Sub PrintRepeating(ByVal arr() As Integer)
		Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()

		Console.Write("Repeating elements are:")
		For Each val As Integer In arr
			If hs.Contains(val) Then
				Console.Write(" " & val)
			Else
				hs.Add(val)
			End If
		Next val
	End Sub

	Public Shared Sub Main4()
		Dim arr1() As Integer = {1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 1}
		PrintRepeating(arr1)
	End Sub
	'	
	'	Repeating elements are: 4 1
	'	

	Public Shared Sub PrintFirstRepeating(ByVal arr() As Integer)
		Dim i As Integer
		Dim size As Integer = arr.Length

		Dim hs As HashSet(Of Integer) = New HashSet(Of Integer)()
		Dim firstRepeating As Integer = Integer.MaxValue

		For i = size - 1 To 0 Step -1
			If hs.Contains(arr(i)) Then
				firstRepeating = arr(i)
			End If
			hs.Add(arr(i))
		Next i
		Console.WriteLine("First Repeating number is:" & firstRepeating)
	End Sub

	Public Shared Sub Main5()
		Dim arr() As Integer = {1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 1}
		PrintFirstRepeating(arr)
	End Sub
	'	
	'	First Repeating number is:1
	'	

	Public Shared Function HornerHash(ByVal key() As Char, ByVal tableSize As Integer) As Integer
		Dim size As Integer = key.Length
		Dim h As Integer = 0
		Dim i As Integer
		For i = 0 To size - 1
			h = (32 * h + AscW(key(i))) Mod tableSize
		Next i
		Return h
	End Function
End Class