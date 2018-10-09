Imports System

Public Class CircularLinkedList
	Private tail As Node
	Private count As Integer = 0

	Private Class Node
		Friend value As Integer
		Friend [next] As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			[next] = n
		End Sub
	End Class
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
		Return tail.next.value
	End Function

	Public Sub addTail(ByVal value As Integer)
		Dim temp As New Node(value, Nothing)
		If Empty Then
			tail = temp
			temp.next = temp
		Else
			temp.next = tail.next
			tail.next = temp
			tail = temp
		End If
		count += 1
	End Sub

	Public Sub addHead(ByVal value As Integer)
		Dim temp As New Node(value, Nothing)
		If Empty Then
			tail = temp
			temp.next = temp
		Else
			temp.next = tail.next
			tail.next = temp
		End If
		count += 1
	End Sub

	Public Function removeHead() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = tail.next.value
		If tail Is tail.next Then
			tail = Nothing
		Else
			tail.next = tail.next.next
		End If

		count -= 1
		Return value
	End Function

	Public Function removeNode(ByVal key As Integer) As Boolean
		If Empty Then
			Return False
		End If
		Dim prev As Node = tail
		Dim curr As Node = tail.next
		Dim head As Node = tail.next

		If curr.value = key Then ' head and single node case.
			If curr Is curr.next Then ' single node case
				tail = Nothing
			Else ' head case
				tail.next = tail.next.next
			End If
			Return True
		End If

		prev = curr
		curr = curr.next

		Do While curr IsNot head
			If curr.value = key Then
				If curr Is tail Then
					tail = prev
				End If
				prev.next = curr.next
				Return True
			End If
			prev = curr
			curr = curr.next
		Loop
		Return False
	End Function

	Public Function copyListReversed() As CircularLinkedList
		Dim cl As New CircularLinkedList()
		Dim curr As Node = tail.next
		Dim head As Node = curr

		If curr IsNot Nothing Then
			cl.addHead(curr.value)
			curr = curr.next
		End If
		Do While curr IsNot head
			cl.addHead(curr.value)
			curr = curr.next
		Loop
		Return cl
	End Function

	Public Function copyList() As CircularLinkedList
		Dim cl As New CircularLinkedList()
		Dim curr As Node = tail.next
		Dim head As Node = curr

		If curr IsNot Nothing Then
			cl.addTail(curr.value)
			curr = curr.next
		End If
		Do While curr IsNot head
			cl.addTail(curr.value)
			curr = curr.next
		Loop
		Return cl
	End Function

	Public Function searchList(ByVal data As Integer) As Boolean
		Dim temp As Node = tail
		For i As Integer = 0 To count - 1
			If temp.value = data Then
				Return True
			End If
			temp = temp.next
		Next i
		Return False
	End Function

	Public Sub deleteList()
		tail = Nothing
		count = 0
	End Sub

	Public Sub print()
		If Empty Then
			Return
		End If
		Dim temp As Node = tail.next
		Do While temp IsNot tail
			Console.Write(temp.value & " ")
			temp = temp.next
		Loop
		Console.Write(temp.value)
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New CircularLinkedList()
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		ll.print()
	End Sub
End Class