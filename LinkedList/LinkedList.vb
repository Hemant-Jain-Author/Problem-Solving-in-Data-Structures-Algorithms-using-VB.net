
Imports System
Imports System.Collections.Generic

Public Class LinkedList
	Private Class Node
		Friend value As Integer
		Friend nextPtr As Node

		Friend Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			nextPtr = n
		End Sub
	End Class

	Private head As Node
	Private count As Integer = 0

	' Other Methods.
	Public Function Size() As Integer
		Return count
	End Function

	Public Function IsEmpty() As Boolean
		Return count = 0
	End Function

	' Other Methods.
	Public Function Peek() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Return head.value
	End Function

	Public Sub AddHead(ByVal value As Integer)
		head = New Node(value, head)
		count += 1
	End Sub

	Public Sub AddTail(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing)
		Dim curr As Node = head

		If head Is Nothing Then
			head = newNode
		End If

		While curr.nextPtr IsNot Nothing
			curr = curr.nextPtr
		End While
		curr.nextPtr = newNode
	End Sub

	Public Function RemoveHead() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("EmptyListException")
		End If
		Dim value As Integer = head.value
		head = head.nextPtr
		count -= 1
		Return value
	End Function

	Public Function Search(ByVal data As Integer) As Boolean
		Dim temp As Node = head
		While temp IsNot Nothing
			If temp.value = data Then
				Return True
			End If
			temp = temp.nextPtr
		End While
		Return False
	End Function

	Public Function DeleteNode(ByVal delValue As Integer) As Boolean
		Dim temp As Node = head

		If IsEmpty() Then
			Return False
		End If

		If delValue = head.value Then
			head = head.nextPtr
			count -= 1
			Return True
		End If

		While temp.nextPtr IsNot Nothing
			If temp.nextPtr.value = delValue Then
				temp.nextPtr = temp.nextPtr.nextPtr
				count -= 1
				Return True
			End If
			temp = temp.nextPtr
		End While
		Return False
	End Function

	Public Function DeleteNodes(ByVal delValue As Integer) As Boolean
		Dim currNode As Node = head
		Dim nextPtrNode As Node
		Dim found As Boolean = False
		While currNode IsNot Nothing AndAlso currNode.value = delValue ' first node
			head = currNode.nextPtr
			currNode = head
			found = True
		End While

		While currNode IsNot Nothing
			nextPtrNode = currNode.nextPtr
			If nextPtrNode IsNot Nothing AndAlso nextPtrNode.value = delValue Then
				currNode.nextPtr = nextPtrNode.nextPtr
				found = True
			Else
				currNode = nextPtrNode
			End If
		End While
		Return found
	End Function

	Private Function ReverseRecurseUtil(ByVal currentNode As Node, ByVal nextPtrNode As Node) As Node
		Dim ret As Node
		If currentNode Is Nothing Then
			Return Nothing
		End If
		If currentNode.nextPtr Is Nothing Then
			currentNode.nextPtr = nextPtrNode
			Return currentNode
		End If

		ret = ReverseRecurseUtil(currentNode.nextPtr, currentNode)
		currentNode.nextPtr = nextPtrNode
		Return ret
	End Function

	Public Sub ReverseRecurse()
		head = ReverseRecurseUtil(head, Nothing)
	End Sub

	Public Sub Reverse()
		Dim curr As Node = head
		Dim prev As Node = Nothing
		Dim nextPtr As Node = Nothing
		While curr IsNot Nothing
			nextPtr = curr.nextPtr
			curr.nextPtr = prev
			prev = curr
			curr = nextPtr
		End While
		head = prev
	End Sub

	Public Function CopyListReversed() As LinkedList
		Dim tempNode As Node = Nothing
		Dim tempNode2 As Node = Nothing
		Dim curr As Node = head
		While curr IsNot Nothing
			tempNode2 = New Node(curr.value, tempNode)
			curr = curr.nextPtr
			tempNode = tempNode2
		End While
		Dim ll2 As New LinkedList()
		ll2.head = tempNode
		Return ll2
	End Function

	Public Function CopyList() As LinkedList
		Dim headNode As Node = Nothing
		Dim tailNode As Node = Nothing
		Dim tempNode As Node = Nothing
		Dim curr As Node = head

		If curr Is Nothing Then
			Return Nothing
		End If

		headNode = New Node(curr.value, Nothing)
		tailNode = headNode
		curr = curr.nextPtr

		While curr IsNot Nothing
			tempNode = New Node(curr.value, Nothing)
			tailNode.nextPtr = tempNode
			tailNode = tempNode
			curr = curr.nextPtr
		End While
		Dim ll2 As New LinkedList()
		ll2.head = headNode
		Return ll2
	End Function

	Public Function CompareList(ByVal ll As LinkedList) As Boolean
		Return CompareList(head, ll.head)
	End Function

	Private Function CompareList(ByVal head1 As Node, ByVal head2 As Node) As Boolean
		If head1 Is Nothing AndAlso head2 Is Nothing Then
			Return True
		ElseIf (head1 Is Nothing) OrElse (head2 Is Nothing) OrElse (head1.value <> head2.value) Then
			Return False
		Else
			Return CompareList(head1.nextPtr, head2.nextPtr)
		End If
	End Function

	Public Function CompareList2(ByVal ll2 As LinkedList) As Boolean
		Dim head1 As Node = head
		Dim head2 As Node = ll2.head

		While head1 IsNot Nothing AndAlso head2 IsNot Nothing
			If head1.value <> head2.value Then
				Return False
			End If
			head1 = head1.nextPtr
			head2 = head2.nextPtr
		End While

		If head1 Is Nothing AndAlso head2 Is Nothing Then
			Return True
		End If
		Return False
	End Function

	Public Function FindLength() As Integer
		Dim curr As Node = head
		Dim count As Integer = 0
		While curr IsNot Nothing
			count += 1
			curr = curr.nextPtr
		End While
		Return count
	End Function

	Public Function NthNodeFromBeginning(ByVal index As Integer) As Integer
		If index > Size() OrElse index < 1 Then
			Return Integer.MaxValue
		End If
		Dim count As Integer = 0
		Dim curr As Node = head
		While curr IsNot Nothing AndAlso count < index - 1
			count += 1
			curr = curr.nextPtr
		End While
		Return curr.value
	End Function

	Public Function NthNodeFromEnd(ByVal index As Integer) As Integer
		Dim size As Integer = FindLength()
		Dim startIndex As Integer
		If size <> 0 AndAlso size < index Then
			Return Integer.MaxValue
		End If
		startIndex = size - index + 1
		Return NthNodeFromBeginning(startIndex)
	End Function

	Public Function NthNodeFromEnd2(ByVal index As Integer) As Integer
		Dim count As Integer = 1
		Dim forward As Node = head
		Dim curr As Node = head
		While forward IsNot Nothing AndAlso count <= index
			count += 1
			forward = forward.nextPtr
		End While

		If forward Is Nothing Then
			Return Integer.MaxValue
		End If

		While forward IsNot Nothing
			forward = forward.nextPtr
			curr = curr.nextPtr
		End While
		Return curr.value
	End Function


	Public Function FindIntersection(ByVal lst2 As LinkedList) As Integer
		Dim head2 As Node = lst2.head
		Dim l1 As Integer = 0
		Dim l2 As Integer = 0
		Dim tempHead As Node = Me.head
		Dim tempHead2 As Node = head2
		While tempHead IsNot Nothing
			l1 += 1
			tempHead = tempHead.nextPtr
		End While
		While tempHead2 IsNot Nothing
			l2 += 1
			tempHead2 = tempHead2.nextPtr
		End While

		Dim diff As Integer
		tempHead = Me.head
		tempHead2 = head2
		If l1 < l2 Then
			Dim temp As Node = tempHead
			tempHead = tempHead2
			tempHead2 = temp
			diff = l2 - l1
		Else
			diff = l1 - l2
		End If

		While diff > 0
			tempHead = tempHead.nextPtr
			diff -= 1
		End While
		While tempHead IsNot tempHead2
			tempHead = tempHead.nextPtr
			tempHead2 = tempHead2.nextPtr
		End While
		Return If(tempHead IsNot Nothing, tempHead.value, -1)
	End Function

	Public Sub DeleteList()
		head = Nothing
		count = 0
	End Sub

	Public Sub Print()
		Dim temp As Node = head
		While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.nextPtr
		End While
		Console.WriteLine("")
	End Sub


	Public Sub SortedInsert(ByVal value As Integer)
		Dim newNode As New Node(value, Nothing)
		Dim curr As Node = head

		If curr Is Nothing OrElse curr.value > value Then
			newNode.nextPtr = head
			head = newNode
			Return
		End If
		While curr.nextPtr IsNot Nothing AndAlso curr.nextPtr.value < value
			curr = curr.nextPtr
		End While

		newNode.nextPtr = curr.nextPtr
		curr.nextPtr = newNode
	End Sub

	Public Sub BubbleSort()
		Dim curr As Node, last As Node = Nothing
		Dim temp As Integer

		If head Is Nothing OrElse head.nextPtr Is Nothing Then
			Return
		End If

		Dim flag As Boolean = True
		While flag
			flag = False
			curr = head
			While curr.nextPtr IsNot last
				If curr.value > curr.nextPtr.value Then
					flag = True
					temp = curr.value
					curr.value = curr.nextPtr.value
					curr.nextPtr.value = temp
				End If
				curr = curr.nextPtr
			End While
			last = curr
		End While
	End Sub

	Public Sub SelectionSort()
		Dim curr As Node, last As Node = Nothing, maxNode As Node
		Dim temp, max As Integer

		If head Is Nothing OrElse head.nextPtr Is Nothing Then
			Return
		End If

		While head IsNot last
			curr = head
			max = curr.value
			maxNode = curr
			While curr.nextPtr IsNot last
				If max < curr.nextPtr.value Then
					maxNode = curr.nextPtr
					max = curr.nextPtr.value
				End If
				curr = curr.nextPtr
			End While
			last = curr
			If curr.value < max Then
				temp = curr.value
				curr.value = max
				maxNode.value = temp
			End If
		End While
	End Sub

	Public Sub InsertionSort()
		Dim curr, last As Node
		Dim temp As Integer

		If head Is Nothing OrElse head.nextPtr Is Nothing Then
			Return
		End If

		last = head.nextPtr
		While last IsNot Nothing
			curr = head
			While curr IsNot last
				If curr.value > last.value Then
					temp = curr.value
					curr.value = last.value
					last.value = temp
				End If
				curr = curr.nextPtr
			End While
			last = last.nextPtr
		End While
	End Sub

	Public Sub RemoveDuplicate()
		Dim curr As Node = head
		While curr IsNot Nothing
			If curr.nextPtr IsNot Nothing AndAlso curr.value = curr.nextPtr.value Then
				curr.nextPtr = curr.nextPtr.nextPtr
			Else
				curr = curr.nextPtr
			End If
		End While
	End Sub

	Public Sub MakeLoop()
		Dim temp As Node = head
		While temp IsNot Nothing
			If temp.nextPtr Is Nothing Then
				temp.nextPtr = head
				Return
			End If
			temp = temp.nextPtr
		End While
	End Sub

	Public Function LoopDetect() As Boolean
		Dim curr As Node = head
		Dim hs As New HashSet(Of Node)()
		While curr IsNot Nothing
			If hs.Contains(curr) Then
				Console.WriteLine("Loop found")
				Return True
			End If
			hs.Add(curr)
			curr = curr.nextPtr
		End While
		Console.WriteLine("Loop not found")
		Return False
	End Function

	Public Function LoopDetect2() As Boolean
		Dim slowPtr As Node
		Dim fastPtr As Node
		fastPtr = head
		slowPtr = fastPtr

		While fastPtr.nextPtr IsNot Nothing AndAlso fastPtr.nextPtr.nextPtr IsNot Nothing
			slowPtr = slowPtr.nextPtr
			fastPtr = fastPtr.nextPtr.nextPtr
			If slowPtr Is fastPtr Then
				Console.WriteLine("Loop found")
				Return True
			End If
		End While
		Console.WriteLine("Loop not found")
		Return False
	End Function

	Public Function ReverseListLoopDetect() As Boolean
		Dim tempHead As Node = head
		Reverse()
		If tempHead Is head Then
			Reverse()
			Console.WriteLine("Loop found")
			Return True
		Else
			Reverse()
			Console.WriteLine("Loop not found")
			Return False
		End If
	End Function

	Public Function LoopTypeDetect() As Integer
		Dim slowPtr As Node
		Dim fastPtr As Node
		fastPtr = head
		slowPtr = fastPtr

		While fastPtr.nextPtr IsNot Nothing AndAlso fastPtr.nextPtr.nextPtr IsNot Nothing
			If head Is fastPtr.nextPtr OrElse head Is fastPtr.nextPtr.nextPtr Then
				Console.WriteLine("Circular list loop found")
				Return 2
			End If
			slowPtr = slowPtr.nextPtr
			fastPtr = fastPtr.nextPtr.nextPtr
			If slowPtr Is fastPtr Then
				Console.WriteLine("Loop found")
				Return 1
			End If
		End While
		Console.WriteLine("Loop not found")
		Return 0
	End Function

	Private Function LoopPointDetect() As Node
		Dim slowPtr As Node
		Dim fastPtr As Node

		fastPtr = head
		slowPtr = fastPtr

		While fastPtr.nextPtr IsNot Nothing AndAlso fastPtr.nextPtr.nextPtr IsNot Nothing
			slowPtr = slowPtr.nextPtr
			fastPtr = fastPtr.nextPtr.nextPtr
			If slowPtr Is fastPtr Then
				Return slowPtr
			End If
		End While
		Return Nothing
	End Function

	Public Sub RemoveLoop()
		Dim LoopPoint As Node = LoopPointDetect()
		If LoopPoint Is Nothing Then
			Return
		End If

		Dim firstPtr As Node = head
		If LoopPoint Is head Then
			While firstPtr.nextPtr IsNot head
				firstPtr = firstPtr.nextPtr
			End While
			firstPtr.nextPtr = Nothing
			Return
		End If

		Dim secondPtr As Node = LoopPoint
		While firstPtr.nextPtr IsNot secondPtr.nextPtr
			firstPtr = firstPtr.nextPtr
			secondPtr = secondPtr.nextPtr
		End While
		secondPtr.nextPtr = Nothing
	End Sub

	Public Shared Sub Main1()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		Console.WriteLine("Size : " & ll.Size())
		Console.WriteLine("Size : " & ll.FindLength())
		Console.WriteLine("Is empty : " & ll.IsEmpty())
		ll.AddTail(4)
		ll.Print()
	End Sub

	'	
	'	3 2 1 
	'	Size : 3
	'	Size : 3
	'	Is empty : False
	'	3 2 1 4 
	'	

	Public Shared Sub Main2()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		Console.WriteLine("Search : " & ll.Search(2))
		ll.RemoveHead()
		ll.Print()
	End Sub

	'	
	'	3 2 1 
	'	Search : True
	'	2 1 
	'	 

	Public Shared Sub Main3()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(1)
		ll.AddHead(3)
		ll.Print()
		Console.WriteLine("DeleteNode : " & ll.DeleteNode(2))
		ll.Print()
		Console.WriteLine("DeleteNodes : " & ll.DeleteNodes(1))
		ll.Print()
	End Sub

	'	
	'	3 1 2 1 2 1 
	'	DeleteNode : True
	'	3 1 1 2 1 
	'	DeleteNodes : True
	'	3 2 
	'	

	Public Shared Sub Main4()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()

		ll.Reverse()
		ll.Print()

		ll.ReverseRecurse()
		ll.Print()

		Dim l2 As LinkedList = ll.CopyList()
		l2.Print()
		Dim l3 As LinkedList = ll.CopyListReversed()
		l3.Print()
	End Sub

	'	
	'	3 2 1 
	'	1 2 3 
	'	3 2 1 
	'	3 2 1 
	'	1 2 3 
	'	

	Public Shared Sub Main5()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()

		Dim l2 As LinkedList = ll.CopyList()
		l2.Print()
		Dim l3 As LinkedList = ll.CopyListReversed()
		l3.Print()
		Console.WriteLine("CompareList : " & ll.CompareList(l2))
		Console.WriteLine("CompareList : " & ll.CompareList2(l2))
		Console.WriteLine("CompareList : " & ll.CompareList(l3))
		Console.WriteLine("CompareList : " & ll.CompareList2(l3))
	End Sub

	'	
	'	3 2 1 
	'	3 2 1 
	'	1 2 3 
	'CompareList : True
	'CompareList : True
	'CompareList : False
	'CompareList : False
	'	

	Public Shared Sub Main6()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		Console.WriteLine(ll.NthNodeFromBeginning(2))
		Console.WriteLine(ll.NthNodeFromEnd(2))
		Console.WriteLine(ll.NthNodeFromEnd2(2))
	End Sub

	'	
	'	3 2 1 
	'	2
	'	2
	'	2
	'	
	Public Shared Sub Main7()
		Dim ll As New LinkedList()
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

	Public Shared Sub Main8()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.Print()
		ll.MakeLoop()
		ll.LoopDetect()
		ll.LoopDetect2()
		ll.LoopTypeDetect()
		ll.RemoveLoop()
		ll.LoopDetect2()
	End Sub

	'	
	'	3 2 1 
	'	Loop found
	'	Loop found
	'	circular list loop found
	'	Loop not found
	'	

	Public Shared Sub Main9()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(2)
		Dim ll2 As New LinkedList()
		ll2.AddHead(3)
		ll2.head.nextPtr = ll.head
		ll.AddHead(4)
		ll2.AddHead(5)
		ll.Print()
		ll2.Print()
		Dim val As Integer = ll.FindIntersection(ll2)
		Console.WriteLine("Intersection:: " & val)
	End Sub

	'	
	'	4 2 1 
	'	5 3 2 1 
	'	Intersection:: 2
	'	

	Public Shared Sub Main10()
		Dim ll As New LinkedList()
		ll.AddHead(1)
		ll.AddHead(10)
		ll.AddHead(9)
		ll.AddHead(7)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.AddHead(5)
		ll.AddHead(4)
		ll.AddHead(6)
		ll.AddHead(8)

		ll.BubbleSort()
		ll.Print()

		ll.AddHead(10)
		ll.AddHead(9)
		ll.AddHead(7)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.AddHead(5)
		ll.AddHead(4)
		ll.AddHead(6)
		ll.AddHead(8)

		ll.SelectionSort()
		ll.Print()

		ll.AddHead(10)
		ll.AddHead(9)
		ll.AddHead(7)
		ll.AddHead(2)
		ll.AddHead(3)
		ll.AddHead(5)
		ll.AddHead(4)
		ll.AddHead(6)
		ll.AddHead(8)

		ll.InsertionSort()
		ll.Print()
	End Sub

	'
	'1 2 3 4 5 6 7 8 9 10 
	'1 2 2 3 3 4 4 5 5 6 6 7 7 8 8 9 9 10 10 
	'1 2 2 2 3 3 3 4 4 4 5 5 5 6 6 6 7 7 7 8 8 8 9 9 9 10 10 10 
	'

	Public Shared Sub Main(ByVal args() As String)
		Main1()
		Main2()
		Main3()
		Main4()
		Main5()
		Main6()
		Main7()
		Main8()
		Main9()
		Main10()
	End Sub
End Class