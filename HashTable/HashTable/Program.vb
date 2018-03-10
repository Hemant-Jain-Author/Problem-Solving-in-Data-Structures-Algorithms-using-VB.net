Imports System

Public Class HashTableSC
	Private Class Node
		Friend value As Integer
		Friend nextRef As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			nextRef = n
		End Sub
	End Class

	Private tableSize As Integer
	Private listArray() As Node 'double pointer

	Public Sub New()
		tableSize = 512
		listArray = New Node(tableSize - 1) {}
		For i As Integer = 0 To tableSize - 1
			listArray(i) = Nothing
		Next i
	End Sub
End Class

Private Function ComputeHash(ByVal key As Integer) As Integer 'division method
	Dim hashValue As Integer = 0
	hashValue = key
	Return hashValue Mod tableSize
End Function

Friend Overridable Function resolverFun(ByVal i As Integer) As Integer
	Return i
End Function

Friend Overridable Function resolverFun2(ByVal i As Integer) As Integer
	Return i * i
End Function


Public Overridable Sub insert(ByVal value As Integer)
	Dim index As Integer = ComputeHash(value)
	listArray(index) = New Node(value, listArray(index))
End Sub

Public Overridable Function delete(ByVal value As Integer) As Boolean
	Dim index As Integer = ComputeHash(value)
	Dim nextNode As Node, head As Node = listArray(index)
	If head IsNot Nothing AndAlso head.value = value Then
		listArray(index) = head.nextRef
		Return True
	End If
	Do While head IsNot Nothing
		nextNode = head.nextRef
		If nextNode IsNot Nothing AndAlso nextNode.value = value Then
			head.nextRef = nextNode.nextRef
			Return True
		Else
			head = nextNode
		End If
	Loop
	Return False
End Function

Public Overridable Sub print()
	For i As Integer = 0 To tableSize - 1
		Console.WriteLine("Printing for index value :: " & i & "List of value printing :: ")
		Dim head As Node = listArray(i)
		Do While head IsNot Nothing
			Console.WriteLine(head.value)
			head = head.nextRef
		Loop
	Next i
End Sub

Public Overridable Function find(ByVal value As Integer) As Boolean
	Dim index As Integer = ComputeHash(value)
	Dim head As Node = listArray(index)
	Do While head IsNot Nothing
		If head.value = value Then
			Return True
		End If
		head = head.nextRef
	Loop
	Return False
End Function

Public Shared Sub Main(ByVal args() As String)
	Dim ht As New HashTableSC()

	For i As Integer = 100 To 109
		ht.insert(i)
	Next i
	Console.WriteLine("search 100 :: " & ht.find(100))
	Console.WriteLine("remove 100 :: " & ht.delete(100))
	Console.WriteLine("search 100 :: " & ht.find(100))
	Console.WriteLine("remove 100 :: " & ht.delete(100))
End Sub
End Class