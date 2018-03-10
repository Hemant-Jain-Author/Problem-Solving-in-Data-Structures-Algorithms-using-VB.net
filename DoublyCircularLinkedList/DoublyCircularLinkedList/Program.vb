Imports System

Public Class DoublyCircularLinkedList

	Private Class Node
		Friend value As Integer
		Friend nextNode As Node
		Friend prev As Node

		Public Sub New(ByVal v As Integer, ByVal nxt As Node, ByVal prv As Node)
			value = v
			nextNode = nxt
			prev = prv
		End Sub

		Public Sub New(ByVal v As Integer)
			value = v
			nextNode = Me
			prev = Me
		End Sub
	End Class

	Private head As Node = Nothing
	Private tail As Node = Nothing

	Private count As Integer = 0


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
			head = newNode
			tail = head
			newNode.nextNode = newNode
			newNode.prev = newNode
		Else
			newNode.nextNode = head
			newNode.prev = head.prev
			head.prev = newNode
			head = newNode
		End If
		count += 1
	End Sub

	Public Sub addTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then
			tail = newNode
			head = tail
			newNode.nextNode = newNode
			newNode.prev = newNode
		Else
			newNode.nextNode = tail.nextNode
			newNode.prev = tail
			tail.nextNode = newNode
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

		Dim nextNode As Node = head.nextNode
		nextNode.prev = tail
		tail.nextNode = nextNode
		head = nextNode
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
		prev.nextNode = head
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
			temp = temp.nextNode
		Loop While temp IsNot head

		Return False
	End Function

	Public Sub freeList()
		head = Nothing
		tail = Nothing
		count = 0
	End Sub

	Public Sub print()
		If Empty Then
			Return
		End If
		Dim temp As Node = head
		Do
			Console.Write(temp.value & " ")
			temp = temp.nextNode
		Loop While temp IsNot Nothing
	End Sub
End Class