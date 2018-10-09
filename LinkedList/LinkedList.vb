Imports System

Public Class LinkedList
	Private Class Node
		Friend value As Integer
		Friend [next] As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			[next] = n
		End Sub
	End Class

	Private head As Node
	Private count As Integer = 0

	' Other Methods.
	Public Function size() As Integer
		Return count
	End Function

	Public ReadOnly Property Empty() As Boolean
		Get
			Return count = 0
		End Get
	End Property

	' Other Methods.

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

		Do While curr.next IsNot Nothing
			curr = curr.next
		Loop
		curr.next = newNode
	End Sub

	Public Function removeHead() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = head.value
		head = head.next
		count -= 1
		Return value
	End Function

	Public Function searchList(ByVal data As Integer) As Boolean
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.value = data Then
				Return True
			End If
			temp = temp.next
		Loop
		Return False
	End Function

	Public Function deleteNode(ByVal delValue As Integer) As Boolean
		Dim temp As Node = head

		If Empty Then
			Return False
		End If

		If delValue = head.value Then
			head = head.next
			count -= 1
			Return True
		End If

		Do While temp.next IsNot Nothing
			If temp.next.value = delValue Then
				temp.next = temp.next.next
				count -= 1
				Return True
			End If
			temp = temp.next
		Loop
		Return False
	End Function

	Public Sub deleteNodes(ByVal delValue As Integer)
		Dim currNode As Node = head
		Dim nextNode As Node

		Do While currNode IsNot Nothing AndAlso currNode.value = delValue ' first node
			head = currNode.next
			currNode = head
		Loop

		Do While currNode IsNot Nothing
			nextNode = currNode.next
			If nextNode IsNot Nothing AndAlso nextNode.value = delValue Then
				currNode.next = nextNode.next
			Else
				currNode = nextNode
			End If
		Loop
	End Sub

	Private Function reverseRecurseUtil(ByVal currentNode As Node, ByVal nextNode As Node) As Node
		Dim ret As Node
		If currentNode Is Nothing Then
			Return Nothing
		End If
		If currentNode.next Is Nothing Then
			currentNode.next = nextNode
			Return currentNode
		End If

		ret = reverseRecurseUtil(currentNode.next, currentNode)
		currentNode.next = nextNode
		Return ret
	End Function

	Public Sub reverseRecurse()
		head = reverseRecurseUtil(head, Nothing)
	End Sub

	Public Sub reverse()
		Dim curr As Node = head
		Dim prev As Node = Nothing
		Dim [next] As Node = Nothing
		Do While curr IsNot Nothing
			[next] = curr.next
			curr.next = prev
			prev = curr
			curr = [next]
		Loop
		head = prev
	End Sub

	Public Function copyListReversed() As LinkedList
		Dim tempNode As Node = Nothing
		Dim tempNode2 As Node = Nothing
		Dim curr As Node = head
		Do While curr IsNot Nothing
			tempNode2 = New Node(curr.value, tempNode)
			curr = curr.next
			tempNode = tempNode2
		Loop
		Dim ll2 As New LinkedList()
		ll2.head = tempNode
		Return ll2
	End Function

	Public Function copyList() As LinkedList
		Dim headNode As Node = Nothing
		Dim tailNode As Node = Nothing
		Dim tempNode As Node = Nothing
		Dim curr As Node = head

		If curr Is Nothing Then
			Return Nothing
		End If

		headNode = New Node(curr.value, Nothing)
		tailNode = headNode
		curr = curr.next

		Do While curr IsNot Nothing
			tempNode = New Node(curr.value, Nothing)
			tailNode.next = tempNode
			tailNode = tempNode
			curr = curr.next
		Loop
		Dim ll2 As New LinkedList()
		ll2.head = headNode
		Return ll2
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
			Return compareList(head1.next, head2.next)
		End If
	End Function

	Public Function compareList2(ByVal ll2 As LinkedList) As Boolean
		Dim head1 As Node = head
		Dim head2 As Node = ll2.head

		Do While head1 Is Nothing AndAlso head2 Is Nothing
			If head1.value <> head2.value Then
				Return False
			End If
			head1 = head1.next
			head2 = head2.next
		Loop

		If head1 Is Nothing AndAlso head2 Is Nothing Then
			Return True
		End If
		Return False
	End Function

	Public Function findLength() As Integer
		Dim curr As Node = head
		Dim count As Integer = 0
		Do While curr IsNot Nothing
			count += 1
			curr = curr.next
		Loop
		Return count
	End Function

	Public Function nthNodeFromBegining(ByVal index As Integer) As Integer
		If index > size() OrElse index < 1 Then
			Return Integer.MaxValue
		End If
		Dim count As Integer = 0
		Dim curr As Node = head
		Do While curr IsNot Nothing AndAlso count < index - 1
			count += 1
			curr = curr.next
		Loop
		Return curr.value
	End Function

	Public Function nthNodeFromEnd(ByVal index As Integer) As Integer
		Dim size As Integer = findLength()
		Dim startIndex As Integer
		If size <> 0 AndAlso size < index Then
			Return Integer.MaxValue
		End If
		startIndex = size - index + 1
		Return nthNodeFromBegining(startIndex)
	End Function

	Public Function nthNodeFromEnd2(ByVal index As Integer) As Integer
		Dim count As Integer = 1
		Dim forward As Node = head
		Dim curr As Node = head
		Do While forward IsNot Nothing AndAlso count <= index
			count += 1
			forward = forward.next
		Loop

		If forward Is Nothing Then
			Return Integer.MaxValue
		End If

		Do While forward IsNot Nothing
			forward = forward.next
			curr = curr.next
		Loop
		Return curr.value
	End Function

	Public Function findIntersection(ByVal lst2 As LinkedList) As Integer
		Dim head2 As Node = lst2.head
		Dim l1 As Integer = 0
		Dim l2 As Integer = 0
		Dim tempHead As Node = Me.head
		Dim tempHead2 As Node = head2
		Do While tempHead IsNot Nothing
			l1 += 1
			tempHead = tempHead.next
		Loop
		Do While tempHead2 IsNot Nothing
			l2 += 1
			tempHead2 = tempHead2.next
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
			head = head.next
			diff -= 1
		Loop
		Do While head IsNot head2
			head = head.next
			head2 = head2.next
		Loop
		Return head.value
	End Function

	Public Sub deleteList()
		head = Nothing
		count = 0
	End Sub

	Public Sub print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.next
		Loop
	End Sub

	Public Sub sortedInsert(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing)
		Dim curr As Node = head

		If curr Is Nothing OrElse curr.value > value Then
			newNode.next = head
			head = newNode
			Return
		End If
		Do While curr.next IsNot Nothing AndAlso curr.next.value < value
			curr = curr.next
		Loop

		newNode.next = curr.next
		curr.next = newNode
	End Sub

	Public Sub removeDuplicate()
		Dim curr As Node = head
		Do While curr IsNot Nothing
			If curr.next IsNot Nothing AndAlso curr.value = curr.next.value Then
				curr.next = curr.next.next
			Else
				curr = curr.next
			End If
		Loop
	End Sub

	Public Sub makeLoop()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			If temp.next Is Nothing Then
				temp.next = head
				Return
			End If
			temp = temp.next
		Loop
	End Sub

	Public Function loopDetect() As Boolean
		Dim slowPtr As Node
		Dim fastPtr As Node
		'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
		'ORIGINAL LINE: slowPtr = fastPtr = head;
		fastPtr = head
		slowPtr = fastPtr

		Do While fastPtr.next IsNot Nothing AndAlso fastPtr.next.next IsNot Nothing
			slowPtr = slowPtr.next
			fastPtr = fastPtr.next.next
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
		'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
		'ORIGINAL LINE: slowPtr = fastPtr = head;
		fastPtr = head
		slowPtr = fastPtr

		Do While fastPtr.next IsNot Nothing AndAlso fastPtr.next.next IsNot Nothing
			If head Is fastPtr.next OrElse head Is fastPtr.next.next Then
				Console.WriteLine("circular list loop found")
				Return 2
			End If
			slowPtr = slowPtr.next
			fastPtr = fastPtr.next.next
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
		'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
		'ORIGINAL LINE: slowPtr = fastPtr = head;
		fastPtr = head
		slowPtr = fastPtr

		Do While fastPtr.next IsNot Nothing AndAlso fastPtr.next.next IsNot Nothing
			slowPtr = slowPtr.next
			fastPtr = fastPtr.next.next
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
			Do While firstPtr.next IsNot head
				firstPtr = firstPtr.next
			Loop
			firstPtr.next = Nothing
			Return
		End If

		Dim secondPtr As Node = loopPoint
		Do While firstPtr.next IsNot secondPtr.next
			firstPtr = firstPtr.next
			secondPtr = secondPtr.next
		Loop
		secondPtr.next = Nothing
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New LinkedList()
		ll.addHead(1)
		ll.addHead(2)
		Dim nd As Node = ll.head
		ll.addHead(3)
		Dim ll2 As New LinkedList()
		ll2.addHead(1)
		ll2.head.next = nd
		ll2.addHead(2)
		ll2.addHead(3)
		ll2.print()

		Console.WriteLine(ll.findIntersection(ll2))
		'		
		'			* LinkedList l2 = ll.copyList(); l2.print(); LinkedList l3 =
		'			* ll.CopyListReversed(); l3.print()
		'			* 
		'			* System.out.println(ll.nthNodeFromBegining(2));
		'			* System.out.println(ll.nthNodeFromEnd(2));
		'			* System.out.println(ll.nthNodeFromEnd2(2));
		'			
	End Sub
End Class