Imports System
Imports System.Collections.Generic

Public Class HashTableExercise

	Public Shared Sub Main333(ByVal args() As String)
		Dim first() As Char = "hello".ToCharArray()
		Dim second() As Char = "elloh".ToCharArray()
		Dim third() As Char = "world".ToCharArray()

		Console.WriteLine("isAnagram : " & isAnagram(first, second))
		Console.WriteLine("isAnagram : " & isAnagram(first, third))

		removeDuplicate(first)
		Console.WriteLine(first)

		Dim arr() As Integer = {1, 2, 3, 5, 6, 7, 8, 9, 10}
		Console.WriteLine(findMissing(arr, 1, 10))

		Dim arr1() As Integer = {1, 2, 3, 4, 4, 5, 6, 7, 8, 9, 1}
		printRepeating(arr1)
		printFirstRepeating(arr1)
	End Sub


	Public Shared Function isAnagram(ByVal str1() As Char, ByVal str2() As Char) As Boolean
		Dim size1 As Integer = str1.Length
		Dim size2 As Integer = str2.Length

		If size1 <> size2 Then
			Return False
		End If

		Dim cm As New CountMap(Of Char)()

		For Each ch As Char In str1
			cm.add(ch)
		Next ch

		For Each ch As Char In str2
			If cm.containsKey(ch) Then
				cm.remove(ch)
			Else
				Return False
			End If
		Next ch

		Return (cm.size() = 0)
	End Function

	Public Shared Sub removeDuplicate(ByVal str() As Char)
		Dim index As Integer = 0
		Dim hs As New HashSet(Of Char)()


		For Each ch As Char In str
			If hs.Contains(ch) = False Then
				str(index) = ch
				index += 1
				hs.Add(ch)
			End If
		Next ch
		str(index) = ControlChars.NullChar
	End Sub

	Public Shared Function findMissing(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Integer
		Dim hs As New HashSet(Of Integer)()
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

	Public Shared Sub printRepeating(ByVal arr() As Integer)
		Dim hs As New HashSet(Of Integer)()

		Console.Write("Repeating elements are:")
		For Each val As Integer In arr
			If hs.Contains(val) Then
				Console.Write("  " & val)
			Else
				hs.Add(val)
			End If
		Next val
	End Sub

	Public Shared Sub printFirstRepeating(ByVal arr() As Integer)
		Dim i As Integer
		Dim size As Integer = arr.Length
		Dim hs As New CountMap(Of Integer)()

		For i = 0 To size - 1
			hs.add(arr(i))
		Next i
		For i = 0 To size - 1
			hs.remove(arr(i))
			If hs.containsKey(arr(i)) Then
				Console.WriteLine("First Repeating number is : " & arr(i))
				Return
			End If
		Next i
	End Sub

	Friend Overridable Function hornerHash(ByVal key() As Char, ByVal tableSize As Integer) As Integer
		Dim size As Integer = key.Length
		Dim h As Integer = 0
		Dim i As Integer
		For i = 0 To size - 1
			h = (32 * h + AscW(key(i))) Mod tableSize
		Next i
		Return h
	End Function


	Public Shared Sub Main(ByVal args() As String)
		Dim cm As New CountMap(Of Integer)()
		cm.add(2)
		cm.add(2)
		cm.remove(2)
		Console.WriteLine("count is : " & cm.getCount(2))
		Console.WriteLine("count is : " & cm.getCount(3))
	End Sub
End Class