Imports System


Public Class LinkedList

	Private Class Node
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

	Private head As Node
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
		head = New Node(value, head)
		count += 1
	End Sub

	Public Sub addTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing)
		Dim curr As Node = head

		If head Is Nothing Then
			head = newNode
		End If

		Do While curr.nextNode IsNot Nothing
			curr = curr.nextNode
		Loop
		curr.nextNode = newNode
	End Sub

	Public Sub print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.nextNode
		Loop
	End Sub

	Public Sub sortedInsert(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing)
		Dim curr As Node = head

		If curr Is Nothing OrElse curr.value > value Then
			newNode.nextNode = head
			head = newNode
			Return
		End If
		Do While curr.nextNode IsNot Nothing AndAlso curr.nextNode.value < value
			curr = curr.nextNode
		Loop

		newNode.nextNode = curr.nextNode
		curr.nextNode = newNode
	End Sub

	Public Function isPresent(ByVal data As Integer) As Boolean
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.value = data Then
				Return True
			End If
			temp = temp.nextNode
		Loop
		Return False
	End Function

	Public Function removeHead() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = head.value
		head = head.nextNode
		count -= 1
		Return value
	End Function



	Public Function deleteNode(ByVal delValue As Integer) As Boolean
		Dim temp As Node = head

		If Empty Then
			Return False
		End If

		If delValue = head.value Then
			head = head.nextNode
			count -= 1
			Return True
		End If

		Do While temp.nextNode IsNot Nothing
			If temp.nextNode.value = delValue Then
				temp.nextNode = temp.nextNode.nextNode
				count -= 1
				Return True
			End If
			temp = temp.nextNode
		Loop
		Return False
	End Function

	Public Sub deleteNodes(ByVal delValue As Integer)
		Dim currNode As Node = head
		Dim nextNode As Node

		Do While currNode IsNot Nothing AndAlso currNode.value = delValue 'first node
			head = currNode.nextNode
			currNode = head
		Loop

		Do While currNode IsNot Nothing
			nextNode = currNode.nextNode
			If nextNode IsNot Nothing AndAlso nextNode.value = delValue Then
				currNode.nextNode = nextNode.nextNode
			Else
				currNode = nextNode
			End If
		Loop
	End Sub

	Public Sub freeList()
		head = Nothing
		count = 0
	End Sub

	Public Sub reverse()
		Dim curr As Node = head
		Dim prev As Node = Nothing
		Dim nextNode As Node = Nothing
		Do While curr IsNot Nothing
			nextNode = curr.nextNode
			curr.nextNode = prev
			prev = curr
			curr = nextNode
		Loop
		head = prev
	End Sub

	Private Function reverseRecurseUtil(ByVal currentNode As Node, ByVal nextNode As Node) As Node
		Dim ret As Node
		If currentNode Is Nothing Then
			Return Nothing
		End If
		If currentNode.nextNode Is Nothing Then
			currentNode.nextNode = nextNode
			Return currentNode
		End If

		ret = reverseRecurseUtil(currentNode.nextNode, currentNode)
		currentNode.nextNode = nextNode
		Return ret
	End Function

	Public Sub reverseRecurse()
		head = reverseRecurseUtil(head, Nothing)
	End Sub

	Public Sub removeDuplicate()
		Do While head IsNot Nothing
			If head.nextNode IsNot Nothing AndAlso head.value = head.nextNode.value Then
				head.nextNode = head.nextNode.nextNode
			Else
				head = head.nextNode
			End If
		Loop
	End Sub

	Public Function copyListReversed() As LinkedList
		Dim ll As New LinkedList()

		Dim tempNode As Node = Nothing
		Dim tempNode2 As Node = Nothing
		Dim curr As Node = head
		Do While curr IsNot Nothing
			tempNode2 = New Node(curr.value, tempNode)
			curr = curr.nextNode
			tempNode = tempNode2
		Loop
		ll.head = tempNode
		Return ll
	End Function

	Public Function copyList() As LinkedList
		Dim ll As New LinkedList()
		Dim headNode As Node = Nothing
		Dim tailNode As Node = Nothing
		Dim tempNode As Node = Nothing

		Dim curr As Node = head

		If curr Is Nothing Then
			Return Nothing
		End If

		headNode = New Node(curr.value, Nothing)
		tailNode = headNode
		curr = curr.nextNode

		Do While curr IsNot Nothing
			tempNode = New Node(curr.value, Nothing)
			tailNode.nextNode = tempNode
			tailNode = tempNode
			curr = curr.nextNode
		Loop
		ll.head = headNode
		Return ll
	End Function

	Public Function compareList(ByVal ll As LinkedList) As Boolean
		Return compareList(head, ll.head)
	End Function

	Private Function compareList(ByVal head1 As Node, ByVal head2 As Node) As Boolean
		If head1 Is Nothing AndAlso head2 Is Nothing Then
			Return True
		ElseIf (head1 Is Nothing) OrElse (head2 Is Nothing) OrElse (head1.value <> head2.value) Then
			Return False
		Else
			Return compareList(head1.nextNode, head2.nextNode)
		End If
	End Function

	Public Function findLength() As Integer
		Dim curr As Node = head
		Dim count As Integer = 0
		Do While curr IsNot Nothing
			count += 1
			curr = curr.nextNode
		Loop
		Return count
	End Function

	Public Function nthNodeFromBegining(ByVal index As Integer) As Integer
		Dim count As Integer = 0
		Dim curr As Node = head
		Do While curr IsNot Nothing AndAlso count < index - 1
			count += 1
			curr = curr.nextNode
		Loop
		If curr Is Nothing Then
			Throw New Exception("null element")
		End If

		Return curr.value
	End Function

	Public Function nthNodeFromEnd(ByVal index As Integer) As Integer
		Dim size As Integer = findLength()
		Dim startIndex As Integer
		If size <> 0 AndAlso size < index Then
			Throw New Exception("null element")
		End If
		startIndex = size - index + 1
		Return nthNodeFromBegining(startIndex)
	End Function

	Public Function nthNodeFromEnd2(ByVal index As Integer) As Integer
		Dim count As Integer = 0
		Dim forward As Node = head
		Dim curr As Node = head
		Do While forward IsNot Nothing AndAlso count < index - 1
			count += 1
			forward = forward.nextNode
		Loop

		If forward Is Nothing Then
			Throw New Exception("null element")
		End If

		Do While forward IsNot Nothing
			forward = forward.nextNode
			curr = curr.nextNode
		Loop
		Return curr.value
	End Function


	Public Function loopDetect() As Boolean
		Dim slowPtr As Node
		Dim fastPtr As Node
		fastPtr = head
		slowPtr = fastPtr

		Do While fastPtr.nextNode IsNot Nothing AndAlso fastPtr.nextNode.nextNode IsNot Nothing
			slowPtr = slowPtr.nextNode
			fastPtr = fastPtr.nextNode.nextNode
			If slowPtr Is fastPtr Then
				Console.WriteLine("loop found")
				Return True
			End If
		Loop
		Console.WriteLine("loop not found")
		Return False
	End Function

	Public Function reverseListLoopDetect() As Boolean
		Dim tempHead As Node = head
		reverse()
		If tempHead Is head Then
			reverse()
			Console.WriteLine("loop found")
			Return True
		Else
			reverse()
			Console.WriteLine("loop not found")
			Return False
		End If
	End Function


	Public Function loopTypeDetect() As Integer
		Dim slowPtr As Node
		Dim fastPtr As Node

		fastPtr = head
		slowPtr = fastPtr

		Do While fastPtr.nextNode IsNot Nothing AndAlso fastPtr.nextNode.nextNode IsNot Nothing
			If head Is fastPtr.nextNode OrElse head Is fastPtr.nextNode.nextNode Then
				Console.WriteLine("circular list loop found")
				Return 2
			End If
			slowPtr = slowPtr.nextNode
			fastPtr = fastPtr.nextNode.nextNode
			If slowPtr Is fastPtr Then
				Console.WriteLine("loop found")

				Return 1
			End If
		Loop
		Console.WriteLine("loop not found")
		Return 0
	End Function

	Private Function loopPointDetect() As Node
		Dim slowPtr As Node
		Dim fastPtr As Node

		fastPtr = head
		slowPtr = fastPtr

		Do While fastPtr.nextNode IsNot Nothing AndAlso fastPtr.nextNode.nextNode IsNot Nothing
			slowPtr = slowPtr.nextNode
			fastPtr = fastPtr.nextNode.nextNode
			If slowPtr Is fastPtr Then
				Return slowPtr
			End If
		Loop
		Return Nothing
	End Function

	Public Sub removeLoop()
		Dim loopPoint As Node = loopPointDetect()
		If loopPoint IsNot Nothing Then
			Return
		End If

		Dim firstPtr As Node = head
		If loopPoint Is head Then
			Do While firstPtr.nextNode IsNot head
				firstPtr = firstPtr.nextNode
			Loop
			firstPtr.nextNode = Nothing
			Return
		End If

		Dim secondPtr As Node = loopPoint
		Do While firstPtr.nextNode IsNot secondPtr.nextNode
			firstPtr = firstPtr.nextNode
			secondPtr = secondPtr.nextNode
		Loop
		secondPtr.nextNode = Nothing
	End Sub




	Private Function findIntersection(ByVal list2 As LinkedList) As Node
		Dim l1 As Integer = 0
		Dim l2 As Integer = 0
		Dim tempHead As Node = head
		Dim tempHead2 As Node = list2.head
		Dim head2 As Node = list2.head
		Do While tempHead IsNot Nothing
			l1 += 1
			tempHead = tempHead.nextNode
		Loop
		Do While tempHead2 IsNot Nothing
			l2 += 1
			tempHead2 = tempHead2.nextNode
		Loop

		Dim diff As Integer
		If l1 < 12 Then
			Dim temp As Node = head
			head = head2
			head2 = temp
			diff = l2 - l1
		Else
			diff = l1 - l2
		End If

		Do While diff > 0
			head = head.nextNode
			diff -= 1
		Loop
		Do While head IsNot head2
			head = head.nextNode
			head2 = head2.nextNode
		Loop

		Return head
	End Function

	Public Sub makeLoop()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.nextNode Is Nothing Then
				temp.nextNode = head
				Return
			End If
			temp = temp.nextNode
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New LinkedList()
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		Dim ll2 As New LinkedList()
		ll2.addHead(1)
		ll2.addHead(2)
		ll2.addHead(3)
		ll.print()
		Console.WriteLine(ll.compareList(ll2))
	End Sub
End Class