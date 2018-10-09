Imports System

Public Class HashTableSC
	Private tableSize As Integer
	Private listArray() As Node

	Private Class Node
		Friend value As Integer
		Friend [next] As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			[next] = n
		End Sub
	End Class

	Public Sub New()
		tableSize = 512
		listArray = New Node(tableSize - 1){}
		For i As Integer = 0 To tableSize - 1
			listArray(i) = Nothing
		Next i
	End Sub

	Private Function computeHash(ByVal key As Integer) As Integer ' division method
		Dim hashValue As Integer = key
		Return hashValue Mod tableSize
	End Function

	Public Sub add(ByVal value As Integer)
		Dim index As Integer = computeHash(value)
		listArray(index) = New Node(value, listArray(index))
	End Sub

	Public Function remove(ByVal value As Integer) As Boolean
		Dim index As Integer = computeHash(value)
		Dim nextNode As Node, head As Node = listArray(index)
		If head IsNot Nothing AndAlso head.value = value Then
			listArray(index) = head.next
			Return True
		End If
		Do While head IsNot Nothing
			nextNode = head.next
			If nextNode IsNot Nothing AndAlso nextNode.value = value Then
				head.next = nextNode.next
				Return True
			Else
				head = nextNode
			End If
		Loop
		Return False
	End Function

	Public Sub print()
		For i As Integer = 0 To tableSize - 1
			Console.WriteLine("printing for index value :: " & i & "List of value printing :: ")
			Dim head As Node = listArray(i)
			Do While head IsNot Nothing
				Console.WriteLine(head.value)
				head = head.next
			Loop
		Next i
	End Sub

	Public Function find(ByVal value As Integer) As Boolean
		Dim index As Integer = computeHash(value)
		Dim head As Node = listArray(index)
		Do While head IsNot Nothing
			If head.value = value Then
				Return True
			End If
			head = head.next
		Loop
		Return False
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim ht As New HashTableSC()

		For i As Integer = 100 To 109
			ht.add(i)
		Next i
		Console.WriteLine("search 100 :: " & ht.find(100))
		Console.WriteLine("remove 100 :: " & ht.remove(100))
		Console.WriteLine("search 100 :: " & ht.find(100))
		Console.WriteLine("remove 100 :: " & ht.remove(100))
	End Sub
End Class
