Imports System

Public Class HashTable
	Private Shared EMPTY_NODE As Integer = -1
	Private Shared LAZY_DELETED As Integer = -2
	Private Shared FILLED_NODE As Integer = 0

	Private tableSize As Integer
	Friend Arr() As Integer
	Friend Flag() As Integer

	Public Sub New(ByVal tSize As Integer)
		tableSize = tSize
		Arr = New Integer(tSize) {}
		Flag = New Integer(tSize) {}
		For i As Integer = 0 To tSize
			Flag(i) = EMPTY_NODE
		Next i
	End Sub


	Friend Overridable Function ComputeHash(ByVal key As Integer) As Integer
		Return key Mod tableSize
	End Function

	Friend Overridable Function resolverFun(ByVal index As Integer) As Integer
		Return index
	End Function

	Friend Overridable Function InsertNode(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = ComputeHash(value)
		For i As Integer = 0 To tableSize - 1
			If Flag(hashValue) = EMPTY_NODE OrElse Flag(hashValue) = LAZY_DELETED Then
				Arr(hashValue) = value
				Flag(hashValue) = FILLED_NODE
				Return True
			End If
			hashValue += resolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Friend Overridable Function FindNode(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = ComputeHash(value)
		For i As Integer = 0 To tableSize - 1
			If Flag(hashValue) = EMPTY_NODE Then
				Return False
			End If

			If Flag(hashValue) = FILLED_NODE AndAlso Arr(hashValue) = value Then
				Return True
			End If

			hashValue += resolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Friend Overridable Function DeleteNode(ByVal value As Integer) As Boolean
		Dim hashValue As Integer = ComputeHash(value)
		For i As Integer = 0 To tableSize - 1
			If Flag(hashValue) = EMPTY_NODE Then
				Return False
			End If

			If Flag(hashValue) = FILLED_NODE AndAlso Arr(hashValue) = value Then
				Flag(hashValue) = LAZY_DELETED
				Return True
			End If
			hashValue += resolverFun(i)
			hashValue = hashValue Mod tableSize
		Next i
		Return False
	End Function

	Friend Overridable Sub Print()
		For i As Integer = 0 To tableSize - 1
			If Flag(i) = FILLED_NODE Then
				Console.WriteLine("Node at index [" & i & " ] :: " & Arr(i))
			End If
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ht As New HashTable(1000)
		ht.InsertNode(89)
		ht.InsertNode(18)
		ht.InsertNode(49)
		ht.InsertNode(58)
		ht.InsertNode(69)
		ht.InsertNode(89)
		ht.InsertNode(18)
		ht.InsertNode(49)
		ht.InsertNode(58)
		ht.InsertNode(69)

		ht.Print()
		Console.WriteLine("")

		ht.DeleteNode(89)
		ht.DeleteNode(18)
		ht.DeleteNode(49)
		ht.DeleteNode(58)
		ht.DeleteNode(100)

		ht.Print()
	End Sub
End Class