Imports System

Public Class HashTableLP
	Private Shared EMPTY_VALUE As Integer = -1
	Private Shared DELETED_VALUE As Integer = -2
	Private Shared FILLED_VALUE As Integer = 0

	Private tableSize As Integer
	Friend array() As Integer
	Friend flag() As Integer

	Public Sub New(ByVal tSize As Integer)
		tableSize = tSize
		array = New Integer(tSize){}
		flag = New Integer(tSize){}
		For i As Integer = 0 To tSize
			flag(i) = EMPTY_VALUE
		Next i
	End Sub

	' Other Methods 

	Friend Function ComputeHash(ByVal key As Integer) As Integer
		Return key Mod tableSize
	End Function

	Friend Function ResolverFun(ByVal index As Integer) As Integer
		Return index
	End Function

	Friend Function ResolverFun2(ByVal index As Integer) As Integer
		Return index * index
	End Function

	Friend Function Add(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = ComputeHash(value)
		For i As Integer = 0 To tableSize - 1
			If flag(hashValue) = EMPTY_VALUE OrElse flag(hashValue) = DELETED_VALUE Then
				array(hashValue) = value
				flag(hashValue) = FILLED_VALUE
				Return True
			End If
			hashValue += ResolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Friend Function Find(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = ComputeHash(value)
		For i As Integer = 0 To tableSize - 1
			If flag(hashValue) = EMPTY_VALUE Then
				Return False
			End If

			If flag(hashValue) = FILLED_VALUE AndAlso array(hashValue) = value Then
				Return True
			End If

			hashValue += ResolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Friend Function Remove(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = ComputeHash(value)
		For i As Integer = 0 To tableSize - 1
			If flag(hashValue) = EMPTY_VALUE Then
				Return False
			End If

			If flag(hashValue) = FILLED_VALUE AndAlso array(hashValue) = value Then
				flag(hashValue) = DELETED_VALUE
				Return True
			End If
			hashValue += ResolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Friend Sub Print()
		Console.Write("Hash Table contains ::")
		For i As Integer = 0 To tableSize - 1
			If flag(i) = FILLED_VALUE Then
				Console.Write(array(i) & " ")
			End If
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ht As New HashTableLP(1000)
		ht.Add(1)
		ht.Add(2)
		ht.Add(3)
		ht.Print()
		Console.WriteLine("Find key 2 : " & ht.Find(2))
		ht.Remove(2)
		Console.WriteLine("Find key 2 : " & ht.Find(2))
	End Sub
End Class

'
'Hash Table contains ::1 2 3 
'Find key 2 : true
'Find key 2 : false
'