
Imports System

Public Class DoublyLinkedList
	Private head As Node
	Private tail As Node
	Private count As Integer = 0

	Private Class Node
		Friend value As Integer
		Friend nextPtr As Node
		Friend prev As Node

		Friend Sub New(ByVal v As Integer, ByVal nxt As Node, ByVal prv As Node)
			value = v
			nextPtr = nxt
			prev = prv
		End Sub
	End Class

	' Other methods 

	Public Function Size() As Integer
		Return count
	End Function

	Public Function IsEmpty() As Boolean
		Return count = 0
	End Function

	Public Function Peek() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Return head.value
	End Function

	Public Sub AddHead(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then

			head = newNode
			tail = head
		Else
			head.prev = newNode
			newNode.nextPtr = head
			head = newNode
		End If
		count += 1
	End Sub

	Public Sub AddTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then

			tail = newNode
			head = tail
		Else
			newNode.prev = tail
			tail.nextPtr = newNode
			tail = newNode
		End If
		count += 1
	End Sub

	Public Function RemoveHead() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = head.value
		head = head.nextPtr

		If head Is Nothing Then
			tail = Nothing
		Else
			head.prev = Nothing
		End If

		count -= 1
		Return value
	End Function

	Public Function DeleteNode(ByVal key As Integer) As Boolean
		Dim curr As Node = head
		If curr Is Nothing Then ' empty list
			Return False
		End If

		If curr.value = key Then ' head is the node with value key.
			head = head.nextPtr
			count -= 1
			If head IsNot Nothing Then
				head.prev = Nothing
			Else
				tail = Nothing ' only one element in list.
			End If
			Return True
		End If

		Do While curr.nextPtr IsNot Nothing
			If curr.nextPtr.value = key Then
				curr.nextPtr = curr.nextPtr.nextPtr
				If curr.nextPtr Is Nothing Then ' last element case.
					tail = curr
				Else
					curr.nextPtr.prev = curr
				End If
				count -= 1
				Return True
			End If
			curr = curr.nextPtr
		Loop
		Return False
	End Function

	Public Function Search(ByVal key As Integer) As Boolean
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.value = key Then
				Return True
			End If
			temp = temp.nextPtr
		Loop
		Return False
	End Function

	Public Sub DeleteList()
		head = Nothing
		tail = Nothing
		count = 0
	End Sub

	Public Sub Print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.nextPtr
		Loop
		Console.WriteLine("")
	End Sub

	' Sorted insert increasing
	Public Sub SortedInsert(ByVal value As Integer)
		Dim temp As New Node(value, Nothing, Nothing)

		Dim curr As Node = head
		If curr Is Nothing Then ' first element
			head = temp
			tail = temp
			Return
		End If

		If head.value > value Then ' at the beginning
			temp.nextPtr = head
			head.prev = temp
			head = temp
			Return
		End If

		Do While curr.nextPtr IsNot Nothing AndAlso curr.nextPtr.value < value ' traversal
			curr = curr.nextPtr
		Loop

		If curr.nextPtr Is Nothing Then ' at the end
			tail = temp
			temp.prev = curr
			curr.nextPtr = temp
		Else '/ all other
			temp.nextPtr = curr.nextPtr
			temp.prev = curr
			curr.nextPtr = temp
			temp.nextPtr.prev = temp
		End If
	End Sub

	'	
	'	 * Reverse a doubly linked List iteratively
	'	 

	Public Sub ReverseList()
		Dim curr As Node = head
		Dim tempNode As Node
		Do While curr IsNot Nothing
			tempNode = curr.nextPtr
			curr.nextPtr = curr.prev
			curr.prev = tempNode

			If curr.prev Is Nothing Then
				tail = head
				head = curr
				Return
			End If

			curr = curr.prev
		Loop
		Return
	End Sub

	' Remove Duplicate 
	Public Sub RemoveDuplicate()
		Dim curr As Node = head
		Do While curr IsNot Nothing
			If (curr.nextPtr IsNot Nothing) AndAlso curr.value = curr.nextPtr.value Then
				curr.nextPtr = curr.nextPtr.nextPtr
				If curr.nextPtr IsNot Nothing Then
					curr.nextPtr.prev = curr
				End If
				If curr.nextPtr Is Nothing Then
					tail = curr
				End If
			Else
				curr = curr.nextPtr
			End If
		Loop
	End Sub

	Public Function CopyListReversed() As DoublyLinkedList
		Dim dll As New DoublyLinkedList()
		Dim curr As Node = head

		Do While curr IsNot Nothing
			dll.AddHead(curr.value)
			curr = curr.nextPtr
		Loop
		Return dll
	End Function

	Public Function CopyList() As DoublyLinkedList
		Dim dll As New DoublyLinkedList()
		Dim curr As Node = head

		Do While curr IsNot Nothing
			dll.AddTail(curr.value)
			curr = curr.nextPtr
		Loop
		Return dll
	End Function

	Public Shared Sub Main1()
		Dim ll As New DoublyLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		ll.RemoveHead()
		ll.Print()
		Console.WriteLine(ll.Search(2))
	End Sub
	'	
	'	3 2 1 
	'	2 1 
	'	True
	'	

	Public Shared Sub Main2()
		Dim ll As New DoublyLinkedList()
		ll.SortedInsert(1)
		ll.SortedInsert(2)
		ll.SortedInsert(3)
		ll.Print()
		ll.SortedInsert(1)
		ll.SortedInsert(2)
		ll.SortedInsert(3)
		ll.Print()
		ll.RemoveDuplicate()
		ll.Print()
	End Sub
	'	
	'	1 2 3 
	'	1 1 2 2 3 3 
	'	1 2 3 
	'	

	Public Shared Sub Main3()
		Dim ll As New DoublyLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()

		Dim l2 As DoublyLinkedList = ll.CopyList()
		l2.Print()
		Dim l3 As DoublyLinkedList = ll.CopyListReversed()
		l3.Print()
	End Sub
	'	
	'	3 2 1 
	'	3 2 1 
	'	1 2 3
	'	

	Public Shared Sub Main4()
		Dim ll As New DoublyLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		ll.DeleteNode(2)
		ll.Print()
	End Sub

	'	
	'	3 2 1 
	'	3 1 
	'	

	Public Shared Sub Main5()
		Dim ll As New DoublyLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		ll.ReverseList()
		ll.Print()
	End Sub

	'	
	'	3 2 1
	'	1 2 3
	'	

	Public Shared Sub Main(ByVal args() As String)
		Main1()
		Main2()
		Main3()
		Main4()
		Main5()
	End Sub
End Class