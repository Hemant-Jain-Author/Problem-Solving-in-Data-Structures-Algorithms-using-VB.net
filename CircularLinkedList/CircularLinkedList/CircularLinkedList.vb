Imports System

Public Class CircularLinkedList

	Private Class Node
		'Node class Fields and Methods
		Friend value As Integer
		Friend nextNode As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			nextNode = n
		End Sub

		Public Sub New(ByVal v As Integer)
			value = v
			nextNode = Nothing
		End Sub
	End Class

	Private tail As Node
	Private count As Integer = 0

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
		Return tail.nextNode.value
	End Function
	'Other Methods

	Public Sub addTail(ByVal value As Integer)
		Dim temp As New Node(value, Nothing)
		If Empty Then
			tail = temp
			temp.nextNode = temp
		Else
			temp.nextNode = tail.nextNode
			tail.nextNode = temp
			tail = temp
		End If
		count += 1
	End Sub

	Public Sub addHead(ByVal value As Integer)
		Dim temp As New Node(value, Nothing)
		If Empty Then
			tail = temp
			temp.nextNode = temp
		Else
			temp.nextNode = tail.nextNode
			tail.nextNode = temp
		End If
		count += 1
	End Sub

	Public Function removeHead() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = tail.nextNode.value
		If tail Is tail.nextNode Then
			tail = Nothing
		Else
			tail.nextNode = tail.nextNode.nextNode
		End If

		count -= 1
		Return value
	End Function

	Public Function removeNode(ByVal key As Integer) As Boolean
		If Empty Then
			Return False
		End If
		Dim prev As Node = tail
		Dim curr As Node = tail.nextNode
		Dim head As Node = tail.nextNode

		If curr.value = key Then 'head and single node case.
			If curr Is curr.nextNode Then 'single node case
				tail = Nothing
			Else ' head case
				tail.nextNode = tail.nextNode.nextNode
			End If
			Return True
		End If

		prev = curr
		curr = curr.nextNode

		Do While curr IsNot head
			If curr.value = key Then
				If curr Is tail Then
					tail = prev
				End If
				prev.nextNode = curr.nextNode
				Return True
			End If
			prev = curr
			curr = curr.nextNode
		Loop

		Return False
	End Function

	Public Sub copyListReversed()
		Dim cl As New CircularLinkedList()
		Dim curr As Node = tail.nextNode
		Dim head As Node = curr

		If curr IsNot Nothing Then
			cl.addHead(curr.value)
			curr = curr.nextNode
		End If
		Do While curr IsNot head
			cl.addHead(curr.value)
			curr = curr.nextNode
		Loop
	End Sub

	Public Sub copyList()
		Dim cl As New CircularLinkedList()
		Dim curr As Node = tail.nextNode
		Dim head As Node = curr

		If curr IsNot Nothing Then
			cl.addTail(curr.value)
			curr = curr.nextNode
		End If
		Do While curr IsNot head
			cl.addTail(curr.value)
			curr = curr.nextNode
		Loop
	End Sub

	Public Function isPresent(ByVal data As Integer) As Boolean
		Dim temp As Node = tail
		For i As Integer = 0 To count - 1
			If temp.value = data Then
				Return True
			End If
			temp = temp.nextNode
		Next i
		Return False
	End Function

	Public Sub freeList()
		tail = Nothing
		count = 0
	End Sub

	Public Sub print()
		If Empty Then
			Return
		End If
		Dim temp As Node = tail.nextNode
		Do While temp IsNot tail
			Console.Write(temp.value & " ")
			temp = temp.nextNode
		Loop
		Console.Write(temp.value)
	End Sub
End Class