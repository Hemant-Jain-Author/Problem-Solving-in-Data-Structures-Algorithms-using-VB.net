Imports System
Imports System.Collections.Generic

Public Class Tree
	Private Class Node
		Friend value As Integer
		Friend lChild As Node
		Friend rChild As Node

		Public Sub New(ByVal v As Integer, ByVal l As Node, ByVal r As Node)
			value = v
			lChild = l
			rChild = r
		End Sub

		Public Sub New(ByVal v As Integer)
			value = v
			lChild = Nothing
			rChild = Nothing
		End Sub
	End Class

	Private root As Node

	Public Sub New()
		root = Nothing
	End Sub

End Class

Public Sub levelOrderBinaryTree(ByVal arr() As Integer)
	root = levelOrderBinaryTree(arr, 0)
End Sub

Private Function levelOrderBinaryTree(ByVal arr() As Integer, ByVal start As Integer) As Node
	Dim size As Integer = arr.Length
	Dim curr As New Node(arr(start))

	Dim left As Integer = 2 * start + 1
	Dim right As Integer = 2 * start + 2

	If left < size Then
		curr.lChild = levelOrderBinaryTree(arr, left)
	End If
	If right < size Then
		curr.rChild = levelOrderBinaryTree(arr, right)
	End If

	Return curr
End Function


Public Sub InsertNode(ByVal value As Integer)
	root = InsertNode(value, root)
End Sub

Private Function InsertNode(ByVal value As Integer, ByVal node As Node) As Node
	If node Is Nothing Then
		node = New Node(value, Nothing, Nothing)
	Else
		If node.value > value Then
			node.lChild = InsertNode(value, node.lChild)
		Else
			node.rChild = InsertNode(value, node.rChild)
		End If
	End If
	Return node
End Function


Public Sub PrintPreOrder()
	PrintPreOrder(root)
End Sub

Private Sub PrintPreOrder(ByVal node As Node) '   pre order
	If node IsNot Nothing Then
		Console.Write(" " & node.value)
		PrintPreOrder(node.lChild)
		PrintPreOrder(node.rChild)
	End If
End Sub

Public Sub NthPreOrder(ByVal index As Integer)
	NthPreOrder(root, index, 0)
End Sub

Private Sub NthPreOrder(ByVal node As Node, ByVal index As Integer, ByVal counter As Integer) '   pre order
	If node IsNot Nothing Then
		counter += 1
		If counter = index Then
			Console.Write(" " & node.value)
		End If
		NthPreOrder(node.lChild, index, counter)
		NthPreOrder(node.rChild, index, counter)
	End If
End Sub


Public Sub PrintPostOrder()
	PrintPostOrder(root)
End Sub

Private Sub PrintPostOrder(ByVal node As Node) '   post order
	If node IsNot Nothing Then
		PrintPostOrder(node.lChild)
		PrintPostOrder(node.rChild)
		Console.Write(" " & node.value)
	End If
End Sub

Public Sub NthPostOrder(ByVal index As Integer)
	NthPostOrder(root, index, 0)
End Sub

Private Sub NthPostOrder(ByVal node As Node, ByVal index As Integer, ByVal counter As Integer) '   post order
	If node IsNot Nothing Then
		NthPostOrder(node.lChild, index, counter)
		NthPostOrder(node.rChild, index, counter)
		counter += 1
		If counter = index Then
			Console.Write(" " & node.value)
		End If
	End If
End Sub


Public Sub PrintInOrder()
	PrintInOrder(root)
End Sub

Private Sub PrintInOrder(ByVal node As Node) '   In order
	If node IsNot Nothing Then
		PrintInOrder(node.lChild)
		Console.Write(" " & node.value)
		PrintInOrder(node.rChild)
	End If
End Sub


Public Sub NthInOrder(ByVal index As Integer)
	NthPostOrder(root, index, 0)
End Sub

Private Sub NthInOrder(ByVal node As Node, ByVal index As Integer, ByVal counter As Integer)
	If node IsNot Nothing Then
		NthInOrder(node.lChild, index, counter)
		counter += 1
		If counter = index Then
			Console.Write(" " & node.value)
		End If
		NthInOrder(node.rChild, index, counter)
	End If
End Sub


Public Sub PrintBredthFirst()
	Dim que As New Queue(Of Node)()
	Dim temp As Node
	If root IsNot Nothing Then
		que.Enqueue(root)
	End If

	Do While que.Count <> 0
		temp = que.Dequeue()
		Console.WriteLine(temp.value)

		If temp.lChild IsNot Nothing Then
			que.Enqueue(temp.lChild)
		End If
		If temp.rChild IsNot Nothing Then
			que.Enqueue(temp.rChild)
		End If
	Loop
End Sub

Public Sub PrintDepthFirst()
	Dim stk As New Stack(Of Node)()
	Dim temp As Node

	If root IsNot Nothing Then
		stk.Push(root)
	End If

	Do While stk.Count <> 0
		temp = stk.Pop()
		Console.WriteLine(temp.value)

		If temp.lChild IsNot Nothing Then
			stk.Push(temp.lChild)
		End If
		If temp.rChild IsNot Nothing Then
			stk.Push(temp.rChild)
		End If
	Loop
End Sub


Public Function Find(ByVal value As Integer) As Boolean
	Dim curr As Node = root

	Do While curr IsNot Nothing
		If curr.value = value Then
			Return True
		ElseIf curr.value > value Then
			curr = curr.lChild
		Else
			curr = curr.rChild
		End If
	Loop
	Return False
End Function

Public Function Find2(ByVal value As Integer) As Boolean
	Dim curr As Node = root
	Do While curr IsNot Nothing AndAlso curr.value <> value
		curr = If(curr.value > value, curr.lChild, curr.rChild)
	Loop
	Return curr IsNot Nothing
End Function


Public Function FindMin() As Integer
	Dim node As Node = root
	If node Is Nothing Then
		Return Integer.MaxValue
	End If

	Do While node.lChild IsNot Nothing
		node = node.lChild
	Loop
	Return node.value
End Function

Public Function FindMax() As Integer
	Dim node As Node = root
	If node Is Nothing Then
		Return Integer.MinValue
	End If

	Do While node.rChild IsNot Nothing
		node = node.rChild
	Loop
	Return node.value
End Function

Private Function FindMax(ByVal curr As Node) As Node
	Dim node As Node = curr
	If node Is Nothing Then
		Return Nothing
	End If

	Do While node.rChild IsNot Nothing
		node = node.rChild
	Loop
	Return node
End Function

Private Function FindMin(ByVal curr As Node) As Node
	Dim node As Node = curr
	If node Is Nothing Then
		Return Nothing
	End If

	Do While node.lChild IsNot Nothing
		node = node.lChild
	Loop
	Return node
End Function

Public Sub Free()
	root = Nothing
End Sub

Public Sub DeleteNode(ByVal value As Integer)
	root = DeleteNode(root, value)
End Sub

Private Function DeleteNode(ByVal node As Node, ByVal value As Integer) As Node
	Dim temp As Node = Nothing

	If node IsNot Nothing Then
		If node.value = value Then
			If node.lChild Is Nothing AndAlso node.rChild Is Nothing Then
				Return Nothing
			Else
				If node.lChild Is Nothing Then
					temp = node.rChild
					Return temp
				End If

				If node.rChild Is Nothing Then
					temp = node.lChild
					Return temp
				End If

				Dim maxNode As Node = FindMax(node)
				Dim maxValue As Integer = maxNode.value
				node.value = maxValue
				node.lChild = DeleteNode(node.lChild, maxValue)
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

Private Function TreeDepth(ByVal root As Node) As Integer
	If root Is Nothing Then
		Return 0
	Else
		Dim lDepth As Integer = TreeDepth(root.lChild)
		Dim rDepth As Integer = TreeDepth(root.rChild)

		If lDepth > rDepth Then
			Return lDepth + 1
		Else
			Return rDepth + 1
		End If
	End If
End Function


Public Function isEqual(ByVal T2 As Tree) As Boolean
	Return isEqual(root, T2.root)
End Function

Private Function isEqual(ByVal node1 As Node, ByVal node2 As Node) As Boolean
	If node1 Is Nothing AndAlso node2 Is Nothing Then
		Return True
	ElseIf node1 Is Nothing OrElse node2 Is Nothing Then
		Return False
	Else
		Return (isEqual(node1.lChild, node2.lChild) AndAlso isEqual(node1.rChild, node2.rChild) AndAlso (node1.value = node2.value))
	End If
End Function

Public Function Ancestor(ByVal first As Integer, ByVal second As Integer) As Integer
	If first > second Then
		Dim temp As Integer = first
		first = second
		second = temp
	End If
	Return Ancestor(root, first, second).value
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
	tree2.root = CopyTree(root)
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

Public Function numNodes() As Integer
	Return numNodes(root)
End Function

Private Function numNodes(ByVal curr As Node) As Integer
	If curr Is Nothing Then
		Return 0
	Else
		Return (1 + numNodes(curr.rChild) + numNodes(curr.lChild))
	End If
End Function

Public Function numFullNodesBT() As Integer
	Return numNodes(root)
End Function

Private Function numFullNodesBT(ByVal curr As Node) As Integer
	Dim count As Integer
	If curr Is Nothing Then
		Return 0
	End If

	count = numFullNodesBT(curr.rChild) + numFullNodesBT(curr.lChild)
	If curr.rChild IsNot Nothing AndAlso curr.lChild IsNot Nothing Then
		count += 1
	End If

	Return count
End Function

Public Function maxLengthPathBT() As Integer
	Return maxLengthPathBT(root)
End Function

Private Function maxLengthPathBT(ByVal curr As Node) As Integer 'diameter
	Dim max As Integer
	Dim leftPath, rightPath As Integer
	Dim leftMax, rightMax As Integer

	If curr Is Nothing Then
		Return 0
	End If

	leftPath = TreeDepth(curr.lChild)
	rightPath = TreeDepth(curr.rChild)

	max = leftPath + rightPath + 1

	leftMax = maxLengthPathBT(curr.lChild)
	rightMax = maxLengthPathBT(curr.rChild)

	If leftMax > max Then
		max = leftMax
	End If

	If rightMax > max Then
		max = rightMax
	End If

	Return max
End Function

Public Function numLeafNodes() As Integer
	Return numLeafNodes(root)
End Function

Private Function numLeafNodes(ByVal curr As Node) As Integer
	If curr Is Nothing Then
		Return 0
	End If
	If curr.lChild Is Nothing AndAlso curr.rChild Is Nothing Then
		Return 1
	Else
		Return (numLeafNodes(curr.rChild) + numLeafNodes(curr.lChild))
	End If
End Function


Public Function sumAllBT() As Integer
	Return sumAllBT(root)
End Function

Private Function sumAllBT(ByVal curr As Node) As Integer
	Dim sum, leftSum, rightSum As Integer

	If curr Is Nothing Then
		Return 0
	End If

	rightSum = sumAllBT(curr.rChild)
	leftSum = sumAllBT(curr.lChild)

	sum = rightSum + leftSum + curr.value

	Return sum
End Function

Public Sub iterativePreOrder()
	Dim stk As New Stack(Of Node)()
	Dim curr As Node

	If root IsNot Nothing Then
		stk.Push(root)
	End If

	Do While stk.Count <> 0
		curr = stk.Pop()
		Console.Write(curr.value & " ")

		If curr.rChild IsNot Nothing Then
			stk.Push(curr.rChild)
		End If

		If curr.lChild IsNot Nothing Then
			stk.Push(curr.lChild)
		End If
	Loop
End Sub

Public Sub iterativePostOrder()
	Dim stk As New Stack(Of Node)()
	Dim visited As New Stack(Of Integer)()
	Dim curr As Node
	Dim vtd As Integer

	If root IsNot Nothing Then
		stk.Push(root)
		visited.Push(0)
	End If

	Do While stk.Count <> 0

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
	Loop
End Sub

Public Sub iterativeInOrder()
	Dim stk As New Stack(Of Node)()
	Dim visited As New Stack(Of Integer)()
	Dim curr As Node
	Dim vtd As Integer

	If root IsNot Nothing Then
		stk.Push(root)
		visited.Push(0)
	End If

	Do While stk.Count <> 0

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
	Loop
End Sub


Private Function isBST3(ByVal root As Node) As Boolean
	If root Is Nothing Then
		Return True
	End If
	If root.lChild IsNot Nothing AndAlso FindMax(root.lChild).value > root.value Then
		Return False
	End If
	If root.rChild IsNot Nothing AndAlso FindMin(root.rChild).value <= root.value Then
		Return False
	End If
	Return (isBST3(root.lChild) AndAlso isBST3(root.rChild))
End Function



Public Function isBst() As Boolean
	Return isBST_util(root, Integer.MinValue, Integer.MaxValue)
End Function

Private Function isBST_util(ByVal curr As Node, ByVal min As Integer, ByVal max As Integer) As Boolean
	If curr Is Nothing Then
		Return True
	End If

	If curr.value < min OrElse curr.value > max Then
		Return False
	End If

	Return isBST_util(curr.lChild, min, curr.value) AndAlso isBST_util(curr.rChild, curr.value, max)
End Function

Friend Class counter
	Friend value As Integer
End Class

Friend Function isBST2() As Boolean
	Dim c As New counter()
	Return isBST2(root, c)
End Function

Private Function isBST2(ByVal root As Node, ByVal count As counter) As Boolean '  in order  traversal
	Dim ret As Boolean
	If root IsNot Nothing Then
		ret = isBST2(root.lChild, count)
		If Not ret Then
			Return False
		End If

		If count.value > root.value Then
			Return False
		End If
		count.value = root.value

		ret = isBST2(root.rChild, count)
		If Not ret Then
			Return False
		End If
	End If
	Return True
End Function

'	void DFS(Node head)
'	{
'		Node curr = head, prev;
'		int count = 0;
'		while (curr && ! curr.visited)
'		{
'			count++;
'			if (curr.lChild && ! curr.lChild.visited)
'			{
'				curr= curr.lChild;
'			}
'			else if (curr.rChild && ! curr.rChild.visited)
'			{
'				curr= curr.rChild;
'			}
'			else
'			{
'				System.out.print(("  " + curr.value);
'				curr.visited = 1;
'				curr = head;
'			}
'		}
'		System.out.print(("count is : " + count);
'	}


Private Function treeToListRec() As Node
	Dim head As Node = treeToListRec(root)
	Dim temp As Node = head
	Return temp
End Function

Private Function treeToListRec(ByVal curr As Node) As Node
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
		Head = treeToListRec(curr.lChild)
		Tail = Head.lChild

		curr.lChild = Tail
		Tail.rChild = curr
	Else
		Head = curr
	End If

	If curr.rChild IsNot Nothing Then
		Dim tempHead As Node = treeToListRec(curr.rChild)
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

Public Sub printAllPath()
	Dim stk As New Stack(Of Integer)()
	printAllPath(root, stk)
End Sub

Private Sub printAllPath(ByVal curr As Node, ByVal stk As Stack(Of Integer))
	If curr Is Nothing Then
		Return
	End If

	stk.Push(curr.value)

	If curr.lChild Is Nothing AndAlso curr.rChild Is Nothing Then
		Console.WriteLine(stk)
		stk.Pop()
		Return
	End If

	printAllPath(curr.rChild, stk)
	printAllPath(curr.lChild, stk)
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

Public Function LcaBST(ByVal first As Integer, ByVal second As Integer) As Integer
	Return LcaBST(root, first, second)
End Function
Private Function LcaBST(ByVal curr As Node, ByVal first As Integer, ByVal second As Integer) As Integer
	If curr Is Nothing Then
		Return Integer.MaxValue
	End If

	If curr.value > first AndAlso curr.value > second Then
		Return LcaBST(curr.lChild, first, second)
	End If
	If curr.value < first AndAlso curr.value < second Then
		Return LcaBST(curr.rChild, first, second)
	End If
	Return curr.value
End Function
Public Sub trimOutsideRange(ByVal min As Integer, ByVal max As Integer)
	trimOutsideRange(root, min, max)
End Sub
Private Function trimOutsideRange(ByVal curr As Node, ByVal min As Integer, ByVal max As Integer) As Node
	If curr Is Nothing Then
		Return Nothing
	End If

	curr.lChild = trimOutsideRange(curr.rChild, min, max)
	curr.rChild = trimOutsideRange(curr.lChild, min, max)

	If curr.value < min Then
		Return curr.rChild
	End If

	If curr.value > max Then
		Return curr.lChild
	End If

	Return curr
End Function
Public Sub printInRange(ByVal min As Integer, ByVal max As Integer)
	printInRange(root, min, max)
End Sub
Private Sub printInRange(ByVal root As Node, ByVal min As Integer, ByVal max As Integer)
	If root Is Nothing Then
		Return
	End If

	printInRange(root.lChild, min, max)

	If root.value >= min AndAlso root.value <= max Then
		Console.Write(root.value & " ")
	End If

	printInRange(root.rChild, min, max)
End Sub


Public Function FloorBST(ByVal val As Integer) As Integer
	Dim curr As Node = root
	Dim ceil As Integer = Integer.MinValue
	Dim floor As Integer = Integer.MaxValue

	Do While curr IsNot Nothing
		If curr.value = val Then
			ceil = curr.value
			floor = curr.value
			Exit Do
		ElseIf curr.value > val Then
			ceil = curr.value
			curr = curr.lChild
		Else
			floor = curr.value
			curr = curr.rChild
		End If
	Loop
	Return floor
End Function

Public Function CeilBST(ByVal val As Integer) As Integer
	Dim curr As Node = root
	Dim ceil As Integer = Integer.MinValue
	Dim floor As Integer = Integer.MaxValue

	Do While curr IsNot Nothing
		If curr.value = val Then
			ceil = curr.value
			floor = curr.value
			Exit Do
		ElseIf curr.value > val Then
			ceil = curr.value
			curr = curr.lChild
		Else
			floor = curr.value
			curr = curr.rChild
		End If
	Loop
	Return ceil
End Function

Public Function findMaxBT() As Integer
	Dim ans As Integer = findMaxBT(root)
	Return ans
End Function

Private Function findMaxBT(ByVal curr As Node) As Integer
	Dim left, right As Integer

	If curr Is Nothing Then
		Return Integer.MinValue
	End If

	Dim max As Integer = curr.value

	left = findMaxBT(curr.lChild)
	right = findMaxBT(curr.rChild)

	If left > max Then
		max = left
	End If
	If right > max Then
		max = right
	End If

	Return max
End Function

Private Function searchBT(ByVal root As Node, ByVal value As Integer) As Boolean
	Dim max As Integer
	Dim left, right As Boolean

	If root Is Nothing Then
		Return False
	End If

	If root.value = value Then
		Return True
	End If

	left = searchBT(root.lChild, value)
	If left Then
		Return True
	End If

	right = searchBT(root.rChild, value)
	If right Then
		Return True
	End If

	Return False
End Function

Public Sub CreateBinaryTree(ByVal arr() As Integer)
	root = CreateBinaryTree(arr, 0, arr.Length - 1)
End Sub

Private Function CreateBinaryTree(ByVal arr() As Integer, ByVal start As Integer, ByVal [end] As Integer) As Node
	Dim curr As Node = Nothing
	If start > [end] Then
		Return Nothing
	End If

	Dim mid As Integer = (start + [end]) \ 2
	curr = New Node(arr(mid))
	curr.lChild = CreateBinaryTree(arr, start, mid - 1)
	curr.rChild = CreateBinaryTree(arr, mid + 1, [end])
	Return curr
End Function


Public Shared Sub Main(ByVal args() As String)
	Dim t As New Tree()
	Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
	t.CreateBinaryTree(arr)
End Sub

t.levelOrderBinaryTree(arr)
	't.PrintBredthFirst();
	't.treeToListRec();
	't.printAllPath();
	'System.out.println(t.LCA(10, 3));
	'System.out.println(t.());
	t.PrintPreOrder()
	Console.WriteLine("")
	t.iterativePreOrder()
	Console.WriteLine("")

	t.PrintPostOrder()
	Console.WriteLine("")
	t.iterativePostOrder()
	Console.WriteLine("")

	t.PrintInOrder()
	Console.WriteLine("")
	t.iterativeInOrder()
	Console.WriteLine("")

	't.PrintPreOrder();
	't.CreateBinaryTree(arr);
	'System.out.println(t.isBST2());

End Sub
