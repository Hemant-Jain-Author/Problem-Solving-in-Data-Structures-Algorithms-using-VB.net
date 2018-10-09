Imports System

Public Class HashTableLP

	Private Shared EMPTY_VALUE As Integer = -1
	Private Shared DELETED_VALUE As Integer = -2
	Private Shared FILLED_VALUE As Integer = 0

	Private tableSize As Integer
	Private Arr() As Integer
	Private Flag() As Integer

	Public Sub New(ByVal tSize As Integer)
		tableSize = tSize
		Arr = New Integer(tSize){}
		Flag = New Integer(tSize){}
		For i As Integer = 0 To tSize
			Flag(i) = EMPTY_VALUE
		Next i
	End Sub

	' Other Methods 

	Private Function computeHash(ByVal key As Integer) As Integer
		Return key Mod tableSize
	End Function

	Private Function resolverFun(ByVal index As Integer) As Integer
		Return index
	End Function

	Private Function resolverFun2(ByVal index As Integer) As Integer
		Return index * index
	End Function

	Public Function add(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = computeHash(value)
		For i As Integer = 0 To tableSize - 1
			If Flag(hashValue) = EMPTY_VALUE OrElse Flag(hashValue) = DELETED_VALUE Then
				Arr(hashValue) = value
				Flag(hashValue) = FILLED_VALUE
				Return True
			End If
			hashValue += resolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Public Function find(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = computeHash(value)
		For i As Integer = 0 To tableSize - 1
			If Flag(hashValue) = EMPTY_VALUE Then
				Return False
			End If

			If Flag(hashValue) = FILLED_VALUE AndAlso Arr(hashValue) = value Then
				Return True
			End If

			hashValue += resolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Public Function remove(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = computeHash(value)
		For i As Integer = 0 To tableSize - 1
			If Flag(hashValue) = EMPTY_VALUE Then
				Return False
			End If

			If Flag(hashValue) = FILLED_VALUE AndAlso Arr(hashValue) = value Then
				Flag(hashValue) = DELETED_VALUE
				Return True
			End If
			hashValue += resolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Public Sub print()
		For i As Integer = 0 To tableSize - 1
			If Flag(i) = FILLED_VALUE Then
				Console.WriteLine("Node at index [" & i & " ] :: " & Arr(i))
			End If
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ht As New HashTableLP(1000)
		ht.add(1)
		ht.add(2)
		ht.add(3)
		ht.print()
		Console.WriteLine(ht.remove(1))
		Console.WriteLine(ht.remove(4))
		ht.print()
	End Sub
End Class