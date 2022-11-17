
Imports System
Imports System.Collections.Generic

Public Class Tree
	Private root As Node

	Private Class Node
		Friend value As Integer
		Friend lChild As Node
		Friend rChild As Node

		Friend Sub New(ByVal v As Integer, ByVal l As Node, ByVal r As Node)
			value = v
			lChild = l
			rChild = r
		End Sub

		Friend Sub New(ByVal v As Integer)
			value = v
			lChild = Nothing
			rChild = Nothing
		End Sub
	End Class

	Public Sub New()
		root = Nothing
	End Sub
	' Other methods 

	Public Sub LevelOrderBinaryTree(ByVal arr() As Integer)
		root = LevelOrderBinaryTree(arr, 0)
	End Sub

	Private Function LevelOrderBinaryTree(ByVal arr() As Integer, ByVal start As Integer) As Node
		Dim size As Integer = arr.Length
		Dim curr As New Node(arr(start))

		Dim left As Integer = 2 * start + 1
		Dim right As Integer = 2 * start + 2

		If left < size Then
			curr.lChild = LevelOrderBinaryTree(arr, left)
		End If
		If right < size Then
			curr.rChild = LevelOrderBinaryTree(arr, right)
		End If

		Return curr
	End Function

	Public Sub InsertNode(ByVal value As Integer)
		root = InsertNode(root, value)
	End Sub

	Private Function InsertNode(ByVal node As Node, ByVal value As Integer) As Node
		If node Is Nothing Then
			node = New Node(value, Nothing, Nothing)
		Else
			If node.value > value Then
				node.lChild = InsertNode(node.lChild, value)
			Else
				node.rChild = InsertNode(node.rChild, value)
			End If
		End If
		Return node
	End Function

	Public Sub PrintPreOrder()
		PrintPreOrder(root)
		Console.WriteLine()
	End Sub

	Private Sub PrintPreOrder(ByVal node As Node) ' pre order
		If node IsNot Nothing Then
			Console.Write(node.value & " ")
			PrintPreOrder(node.lChild)
			PrintPreOrder(node.rChild)
		End If
	End Sub

	Public Sub NthPreOrder(ByVal index As Integer)
		Dim counter() As Integer = {0}
		NthPreOrder(root, index, counter)
	End Sub

	Private Sub NthPreOrder(ByVal node As Node, ByVal index As Integer, ByVal counter() As Integer) ' pre order
		If node IsNot Nothing Then
			counter(0) = counter(0) + 1
			If counter(0) = index Then
				Console.WriteLine(node.value)
			End If
			NthPreOrder(node.lChild, index, counter)
			NthPreOrder(node.rChild, index, counter)
		End If
	End Sub

	Public Sub PrintPostOrder()
		PrintPostOrder(root)
		Console.WriteLine()
	End Sub

	Private Sub PrintPostOrder(ByVal node As Node) ' post order
		If node IsNot Nothing Then
			PrintPostOrder(node.lChild)
			PrintPostOrder(node.rChild)
			Console.Write(node.value & " ")
		End If
	End Sub

	Public Sub NthPostOrder(ByVal index As Integer)
		Dim counter() As Integer = {0}
		NthPostOrder(root, index, counter)
	End Sub

	Private Sub NthPostOrder(ByVal node As Node, ByVal index As Integer, ByVal counter() As Integer) ' post order
		If node IsNot Nothing Then
			NthPostOrder(node.lChild, index, counter)
			NthPostOrder(node.rChild, index, counter)
			counter(0) = counter(0) + 1
			If counter(0) = index Then
				Console.WriteLine(node.value)
			End If
		End If
	End Sub

	Public Sub PrintInOrder()
		PrintInOrder(root)
		Console.WriteLine()
	End Sub

	Private Sub PrintInOrder(ByVal node As Node) ' In order
		If node IsNot Nothing Then
			PrintInOrder(node.lChild)
			Console.Write(node.value & " ")
			PrintInOrder(node.rChild)
		End If
	End Sub

	Public Sub NthInOrder(ByVal index As Integer)
		Dim counter() As Integer = {0}
		NthInOrder(root, index, counter)
	End Sub

	Private Sub NthInOrder(ByVal node As Node, ByVal index As Integer, ByVal counter() As Integer)

		If node IsNot Nothing Then
			NthInOrder(node.lChild, index, counter)
			counter(0) = counter(0) + 1
			If counter(0) = index Then
				Console.WriteLine(node.value)
			End If
			NthInOrder(node.rChild, index, counter)
		End If
	End Sub

	Public Sub PrintBreadthFirst()
		Dim que As New Queue(Of Node)()
		Dim temp As Node
		If root IsNot Nothing Then
			que.Enqueue(root)
		End If

		While que.Count > 0
			temp = que.Dequeue()
			Console.Write(temp.value & " ")

			If temp.lChild IsNot Nothing Then
				que.Enqueue(temp.lChild)
			End If
			If temp.rChild IsNot Nothing Then
				que.Enqueue(temp.rChild)
			End If
		End While
		Console.WriteLine()
	End Sub

	Public Sub PrintDepthFirst()
		Dim stk As New Stack(Of Node)()
		Dim temp As Node

		If root IsNot Nothing Then
			stk.Push(root)
		End If

		While stk.Count > 0
			temp = stk.Pop()
			Console.Write(temp.value & " ")

			If temp.lChild IsNot Nothing Then
				stk.Push(temp.lChild)
			End If
			If temp.rChild IsNot Nothing Then
				stk.Push(temp.rChild)
			End If
		End While
		Console.WriteLine()
	End Sub

	Friend Sub PrintLevelOrderLineByLine()
		Dim que1 As New Queue(Of Node)()
		Dim que2 As New Queue(Of Node)()
		Dim temp As Node = Nothing
		If root IsNot Nothing Then
			que1.Enqueue(root)
		End If
		While que1.Count <> 0 OrElse que2.Count <> 0
			While que1.Count <> 0
				temp = que1.Dequeue()
				Console.Write(temp.value & " ")
				If temp.lChild IsNot Nothing Then
					que2.Enqueue(temp.lChild)
				End If
				If temp.rChild IsNot Nothing Then
					que2.Enqueue(temp.rChild)
				End If
			End While
			Console.WriteLine("")

			While que2.Count <> 0
				temp = que2.Dequeue()
				Console.Write(temp.value & " ")
				If temp.lChild IsNot Nothing Then
					que1.Enqueue(temp.lChild)
				End If
				If temp.rChild IsNot Nothing Then
					que1.Enqueue(temp.rChild)
				End If
			End While
			Console.WriteLine("")
		End While
	End Sub

	Friend Sub PrintLevelOrderLineByLine2()
		Dim que As New Queue(Of Node)()
		Dim temp As Node = Nothing
		Dim count As Integer = 0

		If root IsNot Nothing Then
			que.Enqueue(root)
		End If
		While que.Count <> 0
			count = que.Count
			While count > 0
				temp = que.Dequeue()
				Console.Write(temp.value & " ")
				If temp.lChild IsNot Nothing Then
					que.Enqueue(temp.lChild)
				End If
				If temp.rChild IsNot Nothing Then
					que.Enqueue(temp.rChild)
				End If
				count -= 1
			End While
			Console.WriteLine("")
		End While
	End Sub
	Friend Sub PrintSpiralTree()
		Dim stk1 As New Stack(Of Node)()
		Dim stk2 As New Stack(Of Node)()

		Dim temp As Node
		If root IsNot Nothing Then
			stk1.Push(root)
		End If
		While stk1.Count <> 0 OrElse stk2.Count <> 0
			While stk1.Count <> 0
				temp = stk1.Pop()
				Console.Write(temp.value & " ")
				If temp.rChild IsNot Nothing Then
					stk2.Push(temp.rChild)
				End If
				If temp.lChild IsNot Nothing Then
					stk2.Push(temp.lChild)
				End If
			End While
			While stk2.Count <> 0
				temp = stk2.Pop()
				Console.Write(temp.value & " ")
				If temp.lChild IsNot Nothing Then
					stk1.Push(temp.lChild)
				End If
				If temp.rChild IsNot Nothing Then
					stk1.Push(temp.rChild)
				End If
			End While
		End While
		Console.WriteLine()
	End Sub

	Public Function Find(ByVal value As Integer) As Boolean
		Dim curr As Node = root

		While curr IsNot Nothing
			If curr.value = value Then
				Return True
			ElseIf curr.value > value Then
				curr = curr.lChild
			Else
				curr = curr.rChild
			End If
		End While
		Return False
	End Function

	Public Function Find2(ByVal value As Integer) As Boolean
		Dim curr As Node = root
		While curr IsNot Nothing AndAlso curr.value <> value
			curr = If(curr.value > value, curr.lChild, curr.rChild)
		End While
		Return curr IsNot Nothing
	End Function

	Public Function FindMin() As Integer
		Dim node As Node = root
		If node Is Nothing Then
			Return Integer.MaxValue
		End If

		While node.lChild IsNot Nothing
			node = node.lChild
		End While
		Return node.value
	End Function

	Public Function FindMax() As Integer
		Dim node As Node = root
		If node Is Nothing Then
			Return Integer.MinValue
		End If

		While node.rChild IsNot Nothing
			node = node.rChild
		End While
		Return node.value
	End Function

	Private Function FindMaxNode(ByVal curr As Node) As Node
		Dim node As Node = curr
		If node Is Nothing Then
			Return Nothing
		End If

		While node.rChild IsNot Nothing
			node = node.rChild
		End While
		Return node
	End Function

	Private Function FindMinNode(ByVal curr As Node) As Node
		Dim node As Node = curr
		If node Is Nothing Then
			Return Nothing
		End If

		While node.lChild IsNot Nothing
			node = node.lChild
		End While
		Return node
	End Function

	Public Sub Free()
		root = Nothing
	End Sub

	Public Sub DeleteNode(ByVal value As Integer)
		root = DeleteNode(root, value)
	End Sub

	Private Function DeleteNode(ByVal node As Node, ByVal value As Integer) As Node
		If node IsNot Nothing Then
			If node.value = value Then
				If node.lChild Is Nothing AndAlso node.rChild Is Nothing Then
					Return Nothing
				Else
					If node.lChild Is Nothing Then
						Return node.rChild
					End If

					If node.rChild Is Nothing Then
						Return node.lChild
					End If
					Dim minNode As Node = FindMinNode(node.rChild)
					Dim minValue As Integer = minNode.value
					node.value = minValue
					node.rChild = DeleteNode(node.rChild, minValue)
				End If
			Else
				If node.value > value Then
					node.lChild = DeleteNode(node.lChild, value)
				Else
					node.rChild = DeleteNode(node.rChild, value)
				End If
			End If
		End If
		Return node
	End Function

	Public Function TreeDepth() As Integer
		Return TreeDepth(root)
	End Function

	Private Function TreeDepth(ByVal curr As Node) As Integer
		If curr Is Nothing Then
			Return 0
		Else
			Dim lDepth As Integer = TreeDepth(curr.lChild)
			Dim rDepth As Integer = TreeDepth(curr.rChild)

			If lDepth > rDepth Then
				Return lDepth + 1
			Else
				Return rDepth + 1
			End If
		End If
	End Function

	Public Function IsEqual(ByVal T2 As Tree) As Boolean
		Return IsEqualUtil(root, T2.root)
	End Function

	Private Function IsEqualUtil(ByVal node1 As Node, ByVal node2 As Node) As Boolean
		If node1 Is Nothing AndAlso node2 Is Nothing Then
			Return True
		ElseIf node1 Is Nothing OrElse node2 Is Nothing Then
			Return False
		Else
			Return (IsEqualUtil(node1.lChild, node2.lChild) AndAlso IsEqualUtil(node1.rChild, node2.rChild) AndAlso (node1.value = node2.value))
		End If
	End Function

	Private Function Ancestor(ByVal first As Integer, ByVal second As Integer) As Integer
		If first > second Then
			Dim temp As Integer = first
			first = second
			second = temp
		End If
		Dim nd As Node = Ancestor(root, first, second)
		Return If(nd IsNot Nothing, nd.value, -1)
	End Function

	Private Function Ancestor(ByVal curr As Node, ByVal first As Integer, ByVal second As Integer) As Node
		If curr Is Nothing Then
			Return Nothing
		End If

		If curr.value > first AndAlso curr.value > second Then
			Return Ancestor(curr.lChild, first, second)
		End If
		If curr.value < first AndAlso curr.value < second Then
			Return Ancestor(curr.rChild, first, second)
		End If
		Return curr
	End Function

	Public Function CopyTree() As Tree
		Dim tree2 As New Tree()
		tree2.root = CopyTree(root)
		Return tree2
	End Function

	Private Function CopyTree(ByVal curr As Node) As Node
		Dim temp As Node
		If curr IsNot Nothing Then
			temp = New Node(curr.value)
			temp.lChild = CopyTree(curr.lChild)
			temp.rChild = CopyTree(curr.rChild)
			Return temp
		Else
			Return Nothing
		End If
	End Function

	Public Function CopyMirrorTree() As Tree
		Dim tree2 As New Tree()
		tree2.root = CopyMirrorTree(root)
		Return tree2
	End Function

	Private Function CopyMirrorTree(ByVal curr As Node) As Node
		Dim temp As Node
		If curr IsNot Nothing Then
			temp = New Node(curr.value)
			temp.rChild = CopyMirrorTree(curr.lChild)
			temp.lChild = CopyMirrorTree(curr.rChild)
			Return temp
		Else
			Return Nothing
		End If
	End Function

	Public Function NumNodes() As Integer
		Return NumNodes(root)
	End Function

	Private Function NumNodes(ByVal curr As Node) As Integer
		If curr Is Nothing Then
			Return 0
		Else
			Return (1 + NumNodes(curr.rChild) + NumNodes(curr.lChild))
		End If
	End Function

	Public Function NumFullNodesBT() As Integer
		Return NumFullNodesBT(root)
	End Function

	Private Function NumFullNodesBT(ByVal curr As Node) As Integer
		If curr Is Nothing Then
			Return 0
		End If

		Dim count As Integer = NumFullNodesBT(curr.rChild) + NumFullNodesBT(curr.lChild)
		If curr.rChild IsNot Nothing AndAlso curr.lChild IsNot Nothing Then
			count += 1
		End If
		Return count
	End Function

	Public Function MaxLengthPathBT() As Integer
		Return MaxLengthPathBT(root)
	End Function

	Private Function MaxLengthPathBT(ByVal curr As Node) As Integer ' diameter
		Dim max As Integer
		Dim leftPath, rightPath As Integer
		Dim leftMax, rightMax As Integer

		If curr Is Nothing Then
			Return 0
		End If

		leftPath = TreeDepth(curr.lChild)
		rightPath = TreeDepth(curr.rChild)

		max = leftPath + rightPath + 1

		leftMax = MaxLengthPathBT(curr.lChild)
		rightMax = MaxLengthPathBT(curr.rChild)

		If leftMax > max Then
			max = leftMax
		End If

		If rightMax > max Then
			max = rightMax
		End If

		Return max
	End Function

	Public Function NumLeafNodes() As Integer
		Return NumLeafNodes(root)
	End Function

	Private Function NumLeafNodes(ByVal curr As Node) As Integer
		If curr Is Nothing Then
			Return 0
		End If
		If curr.lChild Is Nothing AndAlso curr.rChild Is Nothing Then
			Return 1
		Else
			Return (NumLeafNodes(curr.rChild) + NumLeafNodes(curr.lChild))
		End If
	End Function

	Public Function SumAllBT() As Integer
		Return SumAllBT(root)
	End Function

	Private Function SumAllBT(ByVal curr As Node) As Integer
		If curr Is Nothing Then
			Return 0
		End If

		Return (curr.value + SumAllBT(curr.lChild) + SumAllBT(curr.rChild))
	End Function

	Public Sub IterativePreOrder()
		Dim stk As New Stack(Of Node)()
		Dim curr As Node

		If root IsNot Nothing Then
			stk.Push(root)
		End If

		While stk.Count > 0
			curr = stk.Pop()
			Console.Write(curr.value & " ")

			If curr.rChild IsNot Nothing Then
				stk.Push(curr.rChild)
			End If

			If curr.lChild IsNot Nothing Then
				stk.Push(curr.lChild)
			End If
		End While
		Console.WriteLine()
	End Sub

	Public Sub IterativePostOrder()
		Dim stk As New Stack(Of Node)()
		Dim visited As New Stack(Of Integer)()
		Dim curr As Node
		Dim vtd As Integer

		If root IsNot Nothing Then
			stk.Push(root)
			visited.Push(0)
		End If

		While stk.Count > 0
			curr = stk.Pop()
			vtd = visited.Pop()
			If vtd = 1 Then
				Console.Write(curr.value & " ")
			Else
				stk.Push(curr)
				visited.Push(1)
				If curr.rChild IsNot Nothing Then
					stk.Push(curr.rChild)
					visited.Push(0)
				End If
				If curr.lChild IsNot Nothing Then
					stk.Push(curr.lChild)
					visited.Push(0)
				End If
			End If
		End While
		Console.WriteLine()
	End Sub

	Public Sub IterativeInOrder()
		Dim stk As New Stack(Of Node)()
		Dim visited As New Stack(Of Integer)()
		Dim curr As Node
		Dim vtd As Integer

		If root IsNot Nothing Then
			stk.Push(root)
			visited.Push(0)
		End If

		While stk.Count > 0
			curr = stk.Pop()
			vtd = visited.Pop()
			If vtd = 1 Then
				Console.Write(curr.value & " ")
			Else
				If curr.rChild IsNot Nothing Then
					stk.Push(curr.rChild)
					visited.Push(0)
				End If
				stk.Push(curr)
				visited.Push(1)
				If curr.lChild IsNot Nothing Then
					stk.Push(curr.lChild)
					visited.Push(0)
				End If
			End If
		End While
		Console.WriteLine()
	End Sub

	Private Function IsBST3(ByVal root As Node) As Boolean
		If root Is Nothing Then
			Return True
		End If
		If root.lChild IsNot Nothing AndAlso FindMaxNode(root.lChild).value > root.value Then
			Return False
		End If
		If root.rChild IsNot Nothing AndAlso FindMinNode(root.rChild).value <= root.value Then
			Return False
		End If
		Return (IsBST3(root.lChild) AndAlso IsBST3(root.rChild))
	End Function

	Public Function IsBST3() As Boolean
		Return IsBST3(root)
	End Function

	Public Function IsBST() As Boolean
		Return IsBST(root, Integer.MinValue, Integer.MaxValue)
	End Function

	Private Function IsBST(ByVal curr As Node, ByVal min As Integer, ByVal max As Integer) As Boolean
		If curr Is Nothing Then
			Return True
		End If

		If curr.value < min OrElse curr.value > max Then
			Return False
		End If

		Return IsBST(curr.lChild, min, curr.value) AndAlso IsBST(curr.rChild, curr.value, max)
	End Function

	Public Function IsBST2() As Boolean
		Dim count(0) As Integer
		Return IsBST2(root, count)
	End Function

	Private Function IsBST2(ByVal root As Node, ByVal count() As Integer) As Boolean ' in order traversal
		Dim ret As Boolean
		If root IsNot Nothing Then
			ret = IsBST2(root.lChild, count)
			If Not ret Then
				Return False
			End If

			If count(0) > root.value Then
				Return False
			End If
			count(0) = root.value

			ret = IsBST2(root.rChild, count)
			If Not ret Then
				Return False
			End If
		End If
		Return True
	End Function

	Public Function IsCompleteTree() As Boolean
		Dim que As New Queue(Of Node)()
		Dim temp As Node = Nothing
		Dim noChild As Integer = 0
		If root IsNot Nothing Then
			que.Enqueue(root)
		End If
		While que.Count <> 0
			temp = que.Dequeue()
			If temp.lChild IsNot Nothing Then
				If noChild = 1 Then
					Return False
				End If
				que.Enqueue(temp.lChild)
			Else
				noChild = 1
			End If

			If temp.rChild IsNot Nothing Then
				If noChild = 1 Then
					Return False
				End If
				que.Enqueue(temp.rChild)
			Else
				noChild = 1
			End If
		End While
		Return True
	End Function


	Private Function IsCompleteTreeUtil(ByVal curr As Node, ByVal index As Integer, ByVal count As Integer) As Boolean
		If curr Is Nothing Then
			Return True
		End If
		If index > count Then
			Return False
		End If
		Return IsCompleteTreeUtil(curr.lChild, index * 2 + 1, count) AndAlso IsCompleteTreeUtil(curr.rChild, index * 2 + 2, count)
	End Function

	Public Function IsCompleteTree2() As Boolean
		Dim count As Integer = NumNodes()
		Return IsCompleteTreeUtil(root, 0, count)
	End Function

	Private Function IsHeapUtil(ByVal curr As Node, ByVal parentValue As Integer) As Boolean
		If curr Is Nothing Then
			Return True
		End If
		If curr.value < parentValue Then
			Return False
		End If
		Return (IsHeapUtil(curr.lChild, curr.value) AndAlso IsHeapUtil(curr.rChild, curr.value))
	End Function

	Public Function IsHeap() As Boolean
		Dim infinite As Integer = -9999999
		Return (IsCompleteTree() AndAlso IsHeapUtil(root, infinite))
	End Function

	Private Function IsHeapUtil2(ByVal curr As Node, ByVal index As Integer, ByVal count As Integer, ByVal parentValue As Integer) As Boolean
		If curr Is Nothing Then
			Return True
		End If
		If index > count Then
			Return False
		End If
		If curr.value < parentValue Then
			Return False
		End If
		Return IsHeapUtil2(curr.lChild, index * 2 + 1, count, curr.value) AndAlso IsHeapUtil2(curr.rChild, index * 2 + 2, count, curr.value)
	End Function

	Public Function IsHeap2() As Boolean
		Dim count As Integer = NumNodes()
		Dim parentValue As Integer = -9999999
		Return IsHeapUtil2(root, 0, count, parentValue)
	End Function

	'	public Node TreeToListRec()
	'	{
	'		Node head = TreeToListRec(root);
	'		Node temp = head;
	'		return temp;
	'	}
	'	
	Private Function TreeToListRec(ByVal curr As Node) As Node
		Dim Head As Node = Nothing, Tail As Node = Nothing
		If curr Is Nothing Then
			Return Nothing
		End If

		If curr.lChild Is Nothing AndAlso curr.rChild Is Nothing Then
			curr.lChild = curr
			curr.rChild = curr
			Return curr
		End If

		If curr.lChild IsNot Nothing Then
			Head = TreeToListRec(curr.lChild)
			Tail = Head.lChild

			curr.lChild = Tail
			Tail.rChild = curr
		Else
			Head = curr
		End If

		If curr.rChild IsNot Nothing Then
			Dim tempHead As Node = TreeToListRec(curr.rChild)
			Tail = tempHead.lChild

			curr.rChild = tempHead
			tempHead.lChild = curr
		Else
			Tail = curr
		End If

		Head.lChild = Tail
		Tail.rChild = Head
		Return Head
	End Function

	Public Sub PrintAllPath()
		Dim stk As New Stack(Of Integer)()
		PrintAllPathUtil(root, stk)
	End Sub

	Private Sub PrintAllPathUtil(ByVal curr As Node, ByVal stk As Stack(Of Integer))
		If curr Is Nothing Then
			Return
		End If

		stk.Push(curr.value)

		If curr.lChild Is Nothing AndAlso curr.rChild Is Nothing Then
			Dim ele As Integer
			For Each ele In stk
				Console.Write(ele & " ")
			Next ele
			Console.WriteLine()
			stk.Pop()
			Return
		End If

		PrintAllPathUtil(curr.rChild, stk)
		PrintAllPathUtil(curr.lChild, stk)
		stk.Pop()
	End Sub

	Public Function LCA(ByVal first As Integer, ByVal second As Integer) As Integer
		Dim ans As Node = LCA(root, first, second)
		If ans IsNot Nothing Then
			Return ans.value
		Else
			Return Integer.MinValue
		End If
	End Function

	Private Function LCA(ByVal curr As Node, ByVal first As Integer, ByVal second As Integer) As Node
		Dim left, right As Node

		If curr Is Nothing Then
			Return Nothing
		End If

		If curr.value = first OrElse curr.value = second Then
			Return curr
		End If

		left = LCA(curr.lChild, first, second)
		right = LCA(curr.rChild, first, second)

		If left IsNot Nothing AndAlso right IsNot Nothing Then
			Return curr
		ElseIf left IsNot Nothing Then
			Return left
		Else
			Return right
		End If
	End Function

	Public Function LCABST(ByVal first As Integer, ByVal second As Integer) As Integer
		Dim result As Integer
		If first > second Then
			result = LCABST(root, second, first)
		Else
			result = LCABST(root, first, second)
		End If

		If result = Integer.MaxValue Then
			Console.WriteLine("LCA does not exist")
		Else
			Console.WriteLine("LCA is :" & result)
		End If
		Return result
	End Function

	Private Function LCABST(ByVal curr As Node, ByVal first As Integer, ByVal second As Integer) As Integer
		If curr Is Nothing Then
			Return Integer.MaxValue
		End If

		If curr.value > second Then
			Return LCABST(curr.lChild, first, second)
		End If
		If curr.value < first Then
			Return LCABST(curr.rChild, first, second)
		End If
		If Find(first) AndAlso Find(second) Then
			Return curr.value
		End If
		Return Integer.MaxValue
	End Function

	Public Sub TrimOutsideRange(ByVal min As Integer, ByVal max As Integer)
		TrimOutsideRange(root, min, max)
	End Sub

	Private Function TrimOutsideRange(ByVal curr As Node, ByVal min As Integer, ByVal max As Integer) As Node
		If curr Is Nothing Then
			Return Nothing
		End If

		curr.lChild = TrimOutsideRange(curr.lChild, min, max)
		curr.rChild = TrimOutsideRange(curr.rChild, min, max)

		If curr.value < min Then
			Return curr.rChild
		End If

		If curr.value > max Then
			Return curr.lChild
		End If

		Return curr
	End Function

	Public Sub PrintInRange(ByVal min As Integer, ByVal max As Integer)
		PrintInRange(root, min, max)
		Console.WriteLine()
	End Sub

	Private Sub PrintInRange(ByVal root As Node, ByVal min As Integer, ByVal max As Integer)
		If root Is Nothing Then
			Return
		End If

		PrintInRange(root.lChild, min, max)

		If root.value >= min AndAlso root.value <= max Then
			Console.Write(root.value & " ")
		End If

		PrintInRange(root.rChild, min, max)
	End Sub

	Public Function FloorBST(ByVal val As Double) As Integer
		Dim curr As Node = root
		Dim floor As Integer = Integer.MaxValue

		While curr IsNot Nothing
			If curr.value = val Then
				floor = curr.value
				Exit While
			ElseIf curr.value > val Then
				curr = curr.lChild
			Else
				floor = curr.value
				curr = curr.rChild
			End If
		End While
		Return floor
	End Function

	Public Function CeilBST(ByVal val As Double) As Integer
		Dim curr As Node = root
		Dim ceil As Integer = Integer.MinValue

		While curr IsNot Nothing
			If curr.value = val Then
				ceil = curr.value
				Exit While
			ElseIf curr.value > val Then
				ceil = curr.value
				curr = curr.lChild
			Else
				curr = curr.rChild
			End If
		End While
		Return ceil
	End Function

	Public Function FindMaxBT() As Integer
		Dim ans As Integer = FindMaxBT(root)
		Return ans
	End Function

	Private Function FindMaxBT(ByVal curr As Node) As Integer
		Dim left, right As Integer

		If curr Is Nothing Then
			Return Integer.MinValue
		End If

		Dim max As Integer = curr.value

		left = FindMaxBT(curr.lChild)
		right = FindMaxBT(curr.rChild)

		If left > max Then
			max = left
		End If
		If right > max Then
			max = right
		End If

		Return max
	End Function

	Public Function SearchBT(ByVal value As Integer) As Boolean
		Return SearchBTUtil(root, value)
	End Function

	Private Function SearchBTUtil(ByVal curr As Node, ByVal value As Integer) As Boolean
		Dim left, right As Boolean
		If curr Is Nothing Then
			Return False
		End If

		If curr.value = value Then
			Return True
		End If

		left = SearchBTUtil(curr.lChild, value)
		If left Then
			Return True
		End If

		right = SearchBTUtil(curr.rChild, value)
		If right Then
			Return True
		End If
		Return False
	End Function

	Public Sub CreateBinarySearchTree(ByVal arr() As Integer)
		root = CreateBinarySearchTree(arr, 0, arr.Length - 1)
	End Sub

	Private Function CreateBinarySearchTree(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Node
		Dim curr As Node = Nothing
		If start > [end] Then
			Return Nothing
		End If

		Dim mid As Integer = (start + [end]) \ 2
		curr = New Node(arr(mid))
		curr.lChild = CreateBinarySearchTree(arr, start, mid - 1)
		curr.rChild = CreateBinarySearchTree(arr, mid + 1, [end])
		Return curr
	End Function

	Friend Function IsBSTArray(ByVal preorder() As Integer) As Boolean
		Dim size As Integer = preorder.Length
		Dim stk As New Stack(Of Integer)()
		Dim value As Integer
		Dim root As Integer = -999999
		For i As Integer = 0 To size - 1
			value = preorder(i)

			' If value of the right child is less than root.
			If value < root Then
				Return False
			End If
			' First left child values will be popped
			' Last popped value will be the root.
			While stk.Count > 0 AndAlso stk.Peek() < value
				root = stk.Pop()
			End While
			' add current value to the stack.
			stk.Push(value)
		Next i
		Return True
	End Function

	Public Shared Sub Main1()
		Dim t As New Tree()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		t.LevelOrderBinaryTree(arr)
		t.PrintPreOrder()
		' 1 2 4 8 9 5 10 3 6 7 

		t.PrintPostOrder()
		' 8 9 4 10 5 2 6 7 3 1 

		t.PrintInOrder()
		' 8 4 9 2 10 5 1 6 3 7 

		t.IterativePreOrder()
		' 1 2 4 8 9 5 10 3 6 7 

		t.IterativePostOrder()
		' 8 9 4 10 5 2 6 7 3 1 

		t.IterativeInOrder()
		' 8 4 9 2 10 5 1 6 3 7 

		t.PrintBreadthFirst()
		' 1 2 3 4 5 6 7 8 9 10 

		t.PrintDepthFirst()
		' 1 3 7 6 2 5 10 4 9 8

		t.PrintLevelOrderLineByLine()
		'		
		'		1 
		'		2 3 
		'		4 5 6 7 
		'		8 9 10 
		'		

		t.PrintLevelOrderLineByLine2()
		'		
		'		1 
		'		2 3 
		'		4 5 6 7 
		'		8 9 10 
		'		

		t.PrintSpiralTree()
		' 1 2 3 7 6 5 4 8 9 10 

		t.NthInOrder(2)
		t.NthPostOrder(2)
		t.NthPreOrder(2)

		'		
		'		4
		'		9
		'		2
		'		

		t.PrintAllPath()

		'		
		'7 3 1 
		'6 3 1 
		'10 5 2 1 
		'9 4 2 1 
		'8 4 2 1 
		'		
	End Sub


	Public Shared Sub Main2()
		Dim t As New Tree()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		t.LevelOrderBinaryTree(arr)

		Console.WriteLine(t.NumNodes())
		' 10

		Console.WriteLine(t.SumAllBT())
		' 55

		Console.WriteLine(t.NumLeafNodes())
		' 5

		Console.WriteLine(t.NumFullNodesBT())
		' 4

		Console.WriteLine(t.SearchBT(9))
		' True

		Console.WriteLine(t.FindMaxBT())
		' 10

		Console.WriteLine(t.TreeDepth())
		' 4

		Console.WriteLine(t.MaxLengthPathBT())
		' 6
	End Sub

	Public Shared Sub Main3()
		Dim t As New Tree()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		t.LevelOrderBinaryTree(arr)

		Dim t2 As Tree = t.CopyTree()
		t2.PrintLevelOrderLineByLine()
		'	
		'	1 
		'	2 3 
		'	4 5 6 7 
		'	8 9 10 
		'	
		Dim t3 As Tree = t.CopyMirrorTree()
		t3.PrintLevelOrderLineByLine()
		'	
		'	1 
		'	3 2 
		'	7 6 5 4 
		'	10 9 8
		'	
		Console.WriteLine(t.IsEqual(t2))
		'	
		'	True
		'	
		Console.WriteLine(t.IsHeap())
		Console.WriteLine(t.IsHeap2())
		Console.WriteLine(t.IsCompleteTree())
		Console.WriteLine(t.IsCompleteTree2())
		'	
		'True
		'True
		'True
		'True
		'	
	End Sub

	Public Shared Sub Main4()
		Dim t As New Tree()
		t.InsertNode(2)
		t.InsertNode(1)
		t.InsertNode(3)
		t.InsertNode(4)

		t.PrintInOrder()

		'		
		'		1 2 3 4 
		'		
		Console.WriteLine(t.Find(3))
		Console.WriteLine(t.Find(6))
		'		
		'True
		'False
		'		
		Console.WriteLine(t.IsBST())
		Console.WriteLine(t.IsBST2())
		Console.WriteLine(t.IsBST3())
		'		
		'True
		'True
		'True
		'		

	End Sub



	Public Shared Sub Main5()
		Dim t As New Tree()
		t.InsertNode(2)
		t.InsertNode(1)
		t.InsertNode(3)
		t.InsertNode(4)
		Console.WriteLine(t.FindMin())
		Console.WriteLine(t.FindMax())
		t.LCABST(3, 4)
		t.LCABST(1, 4)
		t.LCABST(10, 4)
	End Sub

	'	
	'	1
	'	4
	'	LCA is :3
	'	LCA is :2
	'	LCA does not exist
	'	

	Public Shared Sub Main6()
		Dim t As New Tree()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		t.CreateBinarySearchTree(arr)
		t.PrintInOrder()
		t.PrintInRange(4, 7)
		t.TrimOutsideRange(4, 7)
		t.PrintInOrder()
	End Sub

	'	
	'	1 2 3 4 5 6 7 8 9 10 
	'	4 5 6 7 
	'	4 5 6 7 
	'	

	Public Shared Sub Main7()
		Dim t As New Tree()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		t.CreateBinarySearchTree(arr)
		Console.WriteLine(t.Ancestor(1, 10))
		' 5

		Console.WriteLine(t.CeilBST(5.5))
		' 6

		Console.WriteLine(t.FloorBST(8))
		' 8

		Dim arr1() As Integer = {5, 2, 4, 6, 9, 10}
		Dim arr2() As Integer = {5, 2, 6, 4, 7, 9, 10}
		Console.WriteLine(t.IsBSTArray(arr1))
		Console.WriteLine(t.IsBSTArray(arr2))
	End Sub
	'True
	'False
	'
	Public Shared Sub Main8()
		Dim t As New Tree()
		t.InsertNode(2)
		t.InsertNode(1)
		t.InsertNode(3)
		t.InsertNode(4)

		Console.Write("Before delete operation: ")
		t.PrintInOrder()

		t.DeleteNode(2)
		Console.Write("After delete operation: ")
		t.PrintInOrder()
	End Sub
	'	
	'Before delete operation: 1 2 3 4 
	'After delete operation: 1 3 4 
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

	End Sub
End Class
