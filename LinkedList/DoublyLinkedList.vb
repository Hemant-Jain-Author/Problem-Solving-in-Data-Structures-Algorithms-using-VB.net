Imports System

Public Class DoublyLinkedList
	Private head As Node
	Private tail As Node
	Private count As Integer = 0

	Private Class Node
		Friend value As Integer
		Friend [next] As Node
		Friend prev As Node

		Public Sub New(ByVal v As Integer, ByVal nxt As Node, ByVal prv As Node)
			value = v
			[next] = nxt
			prev = prv
		End Sub

		Public Sub New(ByVal v As Integer)
			value = v
			[next] = Nothing
			prev = Nothing
		End Sub
	End Class

	' Other methods 

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
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: tail = head = newNode;
			head = newNode
			tail = head
		Else
			head.prev = newNode
			newNode.next = head
			head = newNode
		End If
		count += 1
	End Sub

	Public Sub addTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: head = tail = newNode;
			tail = newNode
			head = tail
		Else
			newNode.prev = tail
			tail.next = newNode
			tail = newNode
		End If
		count += 1
	End Sub

	Public Function removeHead() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = head.value
		head = head.next

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
		If curr Is Nothing Then ' empty list
			Return False
		End If

		If curr.value = key Then ' head is the node with value key.
			head = head.next
			count -= 1
			If head IsNot Nothing Then
				head.prev = Nothing
			Else
				tail = Nothing ' only one element in list.
			End If
			Return True
		End If

		Do While curr.next IsNot Nothing
			If curr.next.value = key Then
				curr.next = curr.next.next
				If curr.next Is Nothing Then ' last element case.
					tail = curr
				Else
					curr.next = curr
				End If
				count -= 1
				Return True
			End If
			curr = curr.next
		Loop
		Return False
	End Function

	Public Function isPresent(ByVal key As Integer) As Boolean
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.value = key Then
				Return True
			End If
			temp = temp.next
		Loop
		Return False
	End Function

	Public Sub deleteList()
		head = Nothing
		tail = Nothing
		count = 0
	End Sub

	Public Sub print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.next
		Loop
	End Sub

	' SORTED INSERT DECREASING
	Public Sub sortedInsert(ByVal value As Integer)
		Dim temp As New Node(value)

		Dim curr As Node = head
		If curr Is Nothing Then ' first element
			head = temp
			tail = temp
		End If

		If head.value <= value Then ' at the begining
			temp.next = head
			head.prev = temp
			head = temp
		End If

		Do While curr.next IsNot Nothing AndAlso curr.next.value > value ' treversal
			curr = curr.next
		Loop

		If curr.next Is Nothing Then ' at the end
			tail = temp
			temp.prev = curr
			curr.next = temp
		Else '/ all other
			temp.next = curr.next
			temp.prev = curr
			curr.next = temp
			temp.next.prev = temp
		End If
	End Sub

'	
'	* Reverse a doubly linked List iteratively
'	

	Public Sub reverseList()
		Dim curr As Node = head
		Dim tempNode As Node
		Do While curr IsNot Nothing
			tempNode = curr.next
			curr.next = curr.prev
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
	Public Sub removeDuplicate()
		Dim curr As Node = head
		Dim deleteMe As Node
		Do While curr IsNot Nothing
			If (curr.next IsNot Nothing) AndAlso curr.value = curr.next.value Then
				deleteMe = curr.next
				curr.next = deleteMe.next
				curr.next.prev = curr
				If deleteMe Is tail Then
					tail = curr
				End If
			Else
				curr = curr.next
			End If
		Loop
	End Sub

	Public Function copyListReversed() As DoublyLinkedList
		Dim dll As New DoublyLinkedList()
		Dim curr As Node = head

		Do While curr IsNot Nothing
			dll.addHead(curr.value)
			curr = curr.next
		Loop
		Return dll
	End Function

	Public Function copyList() As DoublyLinkedList
		Dim dll As New DoublyLinkedList()
		Dim curr As Node = head

		Do While curr IsNot Nothing
			dll.addTail(curr.value)
			curr = curr.next
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
		ll.removeHead()
		ll.deleteList()
		ll.print()
		ll.addHead(11)
		ll.addHead(21)
		ll.addHead(31)
		ll.addHead(41)
		ll.addHead(51)
		ll.addHead(61)
		ll.print()
	End Sub
}
