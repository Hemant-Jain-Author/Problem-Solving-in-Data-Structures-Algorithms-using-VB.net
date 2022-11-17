
Imports System

Public Class DoublyCircularLinkedList
	Private head As Node = Nothing
	Private tail As Node = Nothing
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

	Public Function PeekHead() As Integer
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
			newNode.nextPtr = newNode
			newNode.prev = newNode
		Else
			newNode.nextPtr = head
			newNode.prev = head.prev
			head.prev = newNode
			newNode.prev.nextPtr = newNode
			head = newNode
		End If
		count += 1
	End Sub

	Public Sub AddTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing, Nothing)
		If count = 0 Then
			tail = newNode
			head = tail
			newNode.nextPtr = newNode
			newNode.prev = newNode
		Else
			newNode.nextPtr = tail.nextPtr
			newNode.prev = tail
			tail.nextPtr = newNode
			newNode.nextPtr.prev = newNode
			tail = newNode
		End If
		count += 1
	End Sub

	Public Function RemoveHead() As Integer
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

		Dim nextPtr As Node = head.nextPtr
		nextPtr.prev = tail
		tail.nextPtr = nextPtr
		head = nextPtr
		Return value
	End Function

	Public Function RemoveTail() As Integer
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
		prev.nextPtr = head
		head.prev = prev
		tail = prev
		Return value
	End Function

	Public Function Search(ByVal key As Integer) As Boolean
		Dim temp As Node = head
		If head Is Nothing Then
			Return False
		End If

		Do
			If temp.value = key Then
				Return True
			End If
			temp = temp.nextPtr
		Loop While temp IsNot head

		Return False
	End Function

	Public Sub DeleteList()
		head = Nothing
		tail = Nothing
		count = 0
	End Sub

	Public Sub Print()
		If IsEmpty() Then
			Console.WriteLine("Empty List.")
			Return
		End If
		Dim temp As Node = head
		While temp IsNot tail
			Console.Write(temp.value & " ")
			temp = temp.nextPtr
		End While
		Console.WriteLine(temp.value)
	End Sub

	Public Shared Sub Main1()
		Dim ll As New DoublyCircularLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		Console.WriteLine(ll.Size())
		Console.WriteLine(ll.IsEmpty())
		Console.WriteLine(ll.PeekHead())
		Console.WriteLine(ll.Search(3))
	End Sub

	'
	'3 2 1
	'3
	'False
	'3
	'True
	'

	Public Shared Sub Main2()
		Dim ll As New DoublyCircularLinkedList()
		ll.AddTail(1)
		ll.AddTail(2)
		ll.AddTail(3)
		ll.Print()

		ll.RemoveHead()
		ll.Print()
		ll.RemoveTail()
		ll.Print()
		ll.DeleteList()
		ll.Print()
	End Sub

	'
	'1 2 3
	'2 3
	'2
	'Empty List.
	'

	Public Shared Sub Main3()
		Dim ll As New DoublyCircularLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()

		ll.RemoveHead()
		ll.Print()

	End Sub
	'
	'3 2 1
	'2 1
	'
	Public Shared Sub Main4()
		Dim ll As New DoublyCircularLinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()

		ll.RemoveTail()
		ll.Print()
	End Sub
	'
	'3 2 1
	'3 2
	'
	Public Shared Sub Main(ByVal args() As String)
		Main1()
		Main2()
		Main3()
		Main4()
	End Sub
End Class