Imports System

Public Class DoublyCircularLinkedList
	Private head As Node = Nothing
	Private tail As Node = Nothing
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
			[next] = Me
			prev = Me
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

	Public Function peekHead() As Integer
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
			newNode.next = newNode
			newNode.prev = newNode
		Else
			newNode.next = head
			newNode.prev = head.prev
			head.prev = newNode
			newNode.prev.next = newNode
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
			newNode.next = newNode
			newNode.prev = newNode
		Else
			newNode.next = tail.next
			newNode.prev = tail
			tail.next = newNode
			newNode.next.prev = newNode
			tail = newNode
		End If
		count += 1
	End Sub

	Public Function removeHead() As Integer
		If count = 0 Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If

		Dim value As Integer = head.value
		count -= 1

		If count = 0 Then
			head = Nothing
			tail = Nothing
			Return value
		End If

		Dim [next] As Node = head.next
		[next].prev = tail
		tail.next = [next]
		head = [next]
		Return value
	End Function

	Public Function removeTail() As Integer
		If count = 0 Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If

		Dim value As Integer = tail.value
		count -= 1

		If count = 0 Then
			head = Nothing
			tail = Nothing
			Return value
		End If

		Dim prev As Node = tail.prev
		prev.next = head
		head.prev = prev
		tail = prev
		Return value
	End Function

	Public Function isPresent(ByVal key As Integer) As Boolean
		Dim temp As Node = head
		If head Is Nothing Then
			Return False
		End If

		Do
			If temp.value = key Then
				Return True
			End If
			temp = temp.next
		Loop While temp IsNot head

		Return False
	End Function

	Public Sub deleteList()
		head = Nothing
		tail = Nothing
		count = 0
	End Sub

	Public Sub print()
		If Empty Then
			Return
		End If
		Dim temp As Node = head
		Do While temp IsNot tail
			Console.Write(temp.value & " ")
			temp = temp.next
		Loop
		Console.Write(temp.value)
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New DoublyCircularLinkedList()
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		ll.print()
	End Sub
End Class
