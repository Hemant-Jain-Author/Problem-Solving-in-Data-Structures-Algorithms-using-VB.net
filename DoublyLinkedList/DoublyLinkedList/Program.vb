Imports System

Public Class DoublyLinkedList

	Private Class Node
		'Node class methods and fields.
		Public value As Integer
		Public nextNode As Node
		Public prev As Node

		Public Sub New(ByVal v As Integer, ByVal nxt As Node, ByVal prv As Node)
			value = v
			nextNode = nxt
			prev = prv
		End Sub

		Public Sub New(ByVal v As Integer)
			value = v
			nextNode = Nothing
			prev = Nothing
		End Sub
	End Class

	Private head As Node
	Private tail As Node

	Private count As Integer = 0
	'Other Methods.



	Public Function size() As Integer
		Return count
	End Function

	Public ReadOnly Property Empty() As Boolean
		Get
			Return count = 0
		End Get
	End Property

	Public Function peek() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Return head.value
	End Function

	Public Sub addHead(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then
			head = newNode
			tail = head
		Else
			head.prev = newNode
			newNode.nextNode = head
			head = newNode
		End If
		count += 1
	End Sub

	Public Sub addTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then
			tail = newNode
			head = tail
		Else
			newNode.prev = tail
			tail.nextNode = newNode
			tail = newNode
		End If
		count += 1
	End Sub

	Public Function removeHead() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = head.value
		head = head.nextNode

		If head Is Nothing Then
			tail = Nothing
		Else
			head.prev = Nothing
		End If

		count -= 1
		Return value
	End Function

	Public Function removeNode(ByVal key As Integer) As Boolean
		Dim curr As Node = head

		If curr Is Nothing Then 'empty list
			Return False
		End If

		If curr.value = key Then 'head is the node with value key.
			head = head.nextNode
			count -= 1
			If head IsNot Nothing Then
				head = Nothing
			Else
				tail = Nothing ' only one element in list.
			End If

			Return True
		End If

		Do While curr.nextNode IsNot Nothing
			If curr.nextNode.value = key Then
				curr.nextNode = curr.nextNode.nextNode
				If curr.nextNode Is Nothing Then 'last element case.
					tail = curr
				Else
					curr.nextNode = curr
				End If
				count -= 1
				Return True
			End If
			curr = curr.nextNode
		Loop
		Return False
	End Function


	Public Function isPresent(ByVal key As Integer) As Boolean
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.value = key Then
				Return True
			End If
			temp = temp.nextNode
		Loop
		Return False
	End Function


	Public Sub freeList()
		head = Nothing
		tail = Nothing
		count = 0
	End Sub

	Public Sub print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.nextNode
		Loop
		Console.WriteLine("")
	End Sub

	'SORTED INSERT DECREASING
	Public Sub sortedInsert(ByVal value As Integer)
		Dim temp As New Node(value)

		Dim curr As Node = head
		If curr Is Nothing Then 'first element
			head = temp
			tail = temp
		End If

		If head.value <= value Then 'at the begining
			temp.nextNode = head
			head.prev = temp
			head = temp
		End If

		Do While curr.nextNode IsNot Nothing AndAlso curr.nextNode.value > value 'treversal
			curr = curr.nextNode
		Loop

		If curr.nextNode Is Nothing Then 'at the end
			tail = temp
			temp.prev = curr
			curr.nextNode = temp
		Else '/all other
			temp.nextNode = curr.nextNode
			temp.prev = curr
			curr.nextNode = temp
			temp.nextNode.prev = temp
		End If
	End Sub

	' Reverse a doubly linked List iteratively
	Public Sub reverseList()
		Dim curr As Node = head
		Dim tempNode As Node
		Do While curr IsNot Nothing
			tempNode = curr.nextNode
			curr.nextNode = curr.prev
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

	'  Remove Duplicate 
	Public Sub removeDuplicate()
		Dim curr As Node = head
		Dim deleteMe As Node
		Do While curr IsNot Nothing
			If (curr.nextNode IsNot Nothing) AndAlso curr.value = curr.nextNode.value Then
				deleteMe = curr.nextNode
				curr.nextNode = deleteMe.nextNode
				curr.nextNode.prev = curr
				If deleteMe Is tail Then
					tail = curr
				End If
			Else
				curr = curr.nextNode
			End If
		Loop
	End Sub

	Public Function copyListReversed() As DoublyLinkedList
		Dim dll As New DoublyLinkedList()
		Dim curr As Node = head

		Do While curr IsNot Nothing
			dll.addHead(curr.value)
			curr = curr.nextNode
		Loop
		Return dll
	End Function

	Public Function copyList() As DoublyLinkedList
		Dim dll As New DoublyLinkedList()
		Dim curr As Node = head

		Do While curr IsNot Nothing
			dll.addTail(curr.value)
			curr = curr.nextNode
		Loop
		Return dll
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New DoublyLinkedList()
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		ll.addHead(4)
		ll.addHead(5)
		ll.addHead(6)
		ll.print()
		ll.removeHead()
		ll.print()
		ll.freeList()
		ll.print()
		ll.addHead(11)
		ll.addHead(21)
		ll.addHead(31)
		ll.addHead(41)
		ll.addHead(51)
		ll.addHead(61)
		ll.print()
	End Sub
End Class