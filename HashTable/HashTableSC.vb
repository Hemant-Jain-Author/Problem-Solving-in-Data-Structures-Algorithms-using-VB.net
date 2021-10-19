Imports System

Public Class HashTableSC
	Private tableSize As Integer
	Private listArray() As Node

	Private Class Node
		Friend value As Integer
		Friend nextPtr As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			nextPtr = n
		End Sub
	End Class

	Public Sub New()
		tableSize = 512
		listArray = New Node(tableSize - 1) {}
		For i As Integer = 0 To tableSize - 1
			listArray(i) = Nothing
		Next i
	End Sub

	Private Function ComputeHash(ByVal key As Integer) As Integer ' division method
		Dim hashValue As Integer = key
		Return hashValue Mod tableSize
	End Function

	Public Sub Add(ByVal value As Integer)
		Dim index As Integer = ComputeHash(value)
		listArray(index) = New Node(value, listArray(index))
	End Sub

	Public Function Remove(ByVal value As Integer) As Boolean
		Dim index As Integer = ComputeHash(value)
		Dim nextPtrNode As Node, head As Node = listArray(index)
		If head IsNot Nothing AndAlso head.value = value Then
			listArray(index) = head.nextPtr
			Return True
		End If
		Do While head IsNot Nothing
			nextPtrNode = head.nextPtr
			If nextPtrNode IsNot Nothing AndAlso nextPtrNode.value = value Then
				head.nextPtr = nextPtrNode.nextPtr
				Return True
			Else
				head = nextPtrNode
			End If
		Loop
		Return False
	End Function

	Public Sub Print()
		Console.Write("Hash Table contains ::")
		For i As Integer = 0 To tableSize - 1
			Dim head As Node = listArray(i)
			Do While head IsNot Nothing
				Console.Write(head.value & " ")
				head = head.nextPtr
			Loop
		Next i
		Console.WriteLine()
	End Sub

	Public Function Find(ByVal value As Integer) As Boolean
		Dim index As Integer = ComputeHash(value)
		Dim head As Node = listArray(index)
		Do While head IsNot Nothing
			If head.value = value Then
				Return True
			End If
			head = head.nextPtr
		Loop
		Return False
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim ht As New HashTableSC()
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
'Find key 2 : True
'Find key 2 : False
'