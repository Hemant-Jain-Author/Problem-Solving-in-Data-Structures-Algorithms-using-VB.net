Imports System
Imports System.Collections.Generic

Module Module1
	Public Class Tree
		Private root As Node

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

		Public Sub New()
			root = Nothing
		End Sub

		' Other methods 

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
		End Sub

		Private Sub PrintPreOrder(ByVal node As Node) ' pre order
			If node IsNot Nothing Then
				Console.Write(" " & node.value)
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
				counter(0) += 1
				If counter(0) = index Then
					Console.Write(node.value)
				End If
				NthPreOrder(node.lChild, index, counter)
				NthPreOrder(node.rChild, index, counter)
			End If
		End Sub

		Public Sub PrintPostOrder()
			PrintPostOrder(root)
		End Sub

		Private Sub PrintPostOrder(ByVal node As Node) ' post order
			If node IsNot Nothing Then
				PrintPostOrder(node.lChild)
				PrintPostOrder(node.rChild)
				Console.Write(" " & node.value)
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
				counter(0) += 1
				If counter(0) = index Then
					Console.Write(" " & node.value)
				End If
			End If
		End Sub

		Public Sub PrintInOrder()
			PrintInOrder(root)
		End Sub

		Private Sub PrintInOrder(ByVal node As Node) ' In order
			If node IsNot Nothing Then
				PrintInOrder(node.lChild)
				Console.Write(" " & node.value)
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
				counter(0) += 1
				If counter(0) = index Then
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
				Console.Write(" " & temp.value)

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

		Public Sub PrintLevelOrderLineByLine()
			Dim que1 As New Queue(Of Node)()
			Dim que2 As New Queue(Of Node)()
			Dim temp As Node = Nothing
			If root IsNot Nothing Then
				que1.Enqueue(root)
			End If
			Do While que1.Count <> 0 OrElse que2.Count <> 0
				Do While que1.Count <> 0
					temp = que1.Dequeue()
					Console.Write(" " & temp.value)
					If temp.lChild IsNot Nothing Then
						que2.Enqueue(temp.lChild)
					End If
					If temp.rChild IsNot Nothing Then
						que2.Enqueue(temp.rChild)
					End If
				Loop
				Console.WriteLine("")

				Do While que2.Count <> 0
					temp = DirectCast(que2.Dequeue(), Node)
					Console.Write(" " & temp.value)
					If temp.lChild IsNot Nothing Then
						que1.Enqueue(temp.lChild)
					End If
					If temp.rChild IsNot Nothing Then
						que1.Enqueue(temp.rChild)
					End If
				Loop
				Console.WriteLine("")
			Loop
		End Sub

		Public Sub PrintLevelOrderLineByLine2()
			Dim que As New Queue(Of Node)()
			Dim temp As Node = Nothing
			Dim count As Integer = 0

			If root IsNot Nothing Then
				que.Enqueue(root)
			End If
			Do While que.Count <> 0
				count = que.Count
				Do While count > 0
					temp = que.Dequeue()
					Console.Write(" " & temp.value)
					If temp.lChild IsNot Nothing Then
						que.Enqueue(temp.lChild)
					End If
					If temp.rChild IsNot Nothing Then
						que.Enqueue(temp.rChild)
					End If
					count -= 1
				Loop
				Console.WriteLine("")
			Loop
		End Sub

		Public Sub PrintSpiralTree()
			Dim stk1 As New Stack(Of Node)()
			Dim stk2 As New Stack(Of Node)()

			Dim temp As Node
			If root IsNot Nothing Then
				stk1.Push(root)
			End If
			Do While stk1.Count <> 0 OrElse stk2.Count <> 0
				Do While stk1.Count <> 0
					temp = stk1.Pop()
					Console.Write(" " & temp.value)
					If temp.rChild IsNot Nothing Then
						stk2.Push(temp.rChild)
					End If
					If temp.lChild IsNot Nothing Then
						stk2.Push(temp.lChild)
					End If
				Loop
				Do While stk2.Count <> 0
					temp = stk2.Pop()
					Console.Write(" " & temp.value)
					If temp.lChild IsNot Nothing Then
						stk1.Push(temp.lChild)
					End If
					If temp.rChild IsNot Nothing Then
						stk1.Push(temp.rChild)
					End If
				Loop
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

		Private Function FindMaxNode(ByVal curr As Node) As Node
			Dim node As Node = curr
			If node Is Nothing Then
				Return Nothing
			End If

			Do While node.rChild IsNot Nothing
				node = node.rChild
			Loop
			Return node
		End Function

		Private Function FindMinNode(ByVal curr As Node) As Node
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

		Public Function isEqual(ByVal T2 As Tree) As Boolean
			Return isEqualUtil(root, T2.root)
		End Function

		Private Function isEqualUtil(ByVal node1 As Node, ByVal node2 As Node) As Boolean
			If node1 Is Nothing AndAlso node2 Is Nothing Then
				Return True
			ElseIf node1 Is Nothing OrElse node2 Is Nothing Then
				Return False
			Else
				Return (isEqualUtil(node1.lChild, node2.lChild) AndAlso isEqualUtil(node1.rChild, node2.rChild) AndAlso (node1.value = node2.value))
			End If
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

		Private Function maxLengthPathBT(ByVal curr As Node) As Integer ' diameter
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
			If curr Is Nothing Then
				Return 0
			End If

			Return (curr.value + sumAllBT(curr.lChild) + sumAllBT(curr.lChild))
		End Function

		Public Sub iterativePreOrder()
			Dim stk As New Stack(Of Node)()
			Dim curr As Node

			If root IsNot Nothing Then
				stk.Push(root)
			End If

			Do While stk.Count > 0
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

			Do While stk.Count > 0
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

			Do While stk.Count > 0
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

		Public Function isBST3() As Boolean
			Return isBSTUtil3(root)
		End Function

		Private Function isBSTUtil3(ByVal root As Node) As Boolean
			If root Is Nothing Then
				Return True
			End If
			If root.lChild IsNot Nothing AndAlso FindMaxNode(root.lChild).value > root.value Then
				Return False
			End If
			If root.rChild IsNot Nothing AndAlso FindMinNode(root.rChild).value <= root.value Then
				Return False
			End If
			Return (isBSTUtil3(root.lChild) AndAlso isBSTUtil3(root.rChild))
		End Function

		Public Function isBST() As Boolean
			Return isBST(root, Integer.MinValue, Integer.MaxValue)
		End Function

		Private Function isBST(ByVal curr As Node, ByVal min As Integer, ByVal max As Integer) As Boolean
			If curr Is Nothing Then
				Return True
			End If

			If curr.value < min OrElse curr.value > max Then
				Return False
			End If

			Return isBST(curr.lChild, min, curr.value) AndAlso isBST(curr.rChild, curr.value, max)
		End Function

		Public Function isBST2() As Boolean
			Dim count(0) As Integer
			Return isBST2(root, count)
		End Function

		Private Function isBST2(ByVal root As Node, ByVal count() As Integer) As Boolean ' in order traversal
			Dim ret As Boolean
			If root IsNot Nothing Then
				ret = isBST2(root.lChild, count)
				If Not ret Then
					Return False
				End If

				If count(0) > root.value Then
					Return False
				End If
				count(0) = root.value

				ret = isBST2(root.rChild, count)
				If Not ret Then
					Return False
				End If
			End If
			Return True
		End Function

		Public Function isCompleteTree() As Boolean
			Dim que As New Queue(Of Node)()
			Dim temp As Node = Nothing
			Dim noChild As Integer = 0
			If root IsNot Nothing Then
				que.Enqueue(root)
			End If
			Do While que.Count <> 0
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
			Loop
			Return True
		End Function

		Private Function isCompleteTreeUtil(ByVal curr As Node, ByVal index As Integer, ByVal count As Integer) As Boolean
			If curr Is Nothing Then
				Return True
			End If
			If index > count Then
				Return False
			End If
			Return isCompleteTreeUtil(curr.lChild, index * 2 + 1, count) AndAlso isCompleteTreeUtil(curr.rChild, index * 2 + 2, count)
		End Function

		Public Function isCompleteTree2() As Boolean
			Dim count As Integer = numNodes()
			Return isCompleteTreeUtil(root, 0, count)
		End Function

		Private Function isHeapUtil(ByVal curr As Node, ByVal parentValue As Integer) As Boolean
			If curr Is Nothing Then
				Return True
			End If
			If curr.value < parentValue Then
				Return False
			End If
			Return (isHeapUtil(curr.lChild, curr.value) AndAlso isHeapUtil(curr.rChild, curr.value))
		End Function

		Public Function isHeap() As Boolean
			Dim infi As Integer = -9999999
			Return (isCompleteTree() AndAlso isHeapUtil(root, infi))
		End Function

		Private Function isHeapUtil2(ByVal curr As Node, ByVal index As Integer, ByVal count As Integer, ByVal parentValue As Integer) As Boolean
			If curr Is Nothing Then
				Return True
			End If
			If index > count Then
				Return False
			End If
			If curr.value < parentValue Then
				Return False
			End If
			Return isHeapUtil2(curr.lChild, index * 2 + 1, count, curr.value) AndAlso isHeapUtil2(curr.rChild, index * 2 + 2, count, curr.value)
		End Function

		Public Function isHeap2() As Boolean
			Dim count As Integer = numNodes()
			Dim parentValue As Integer = -9999999
			Return isHeapUtil2(root, 0, count, parentValue)
		End Function


		Public Sub printAllPath()
			Dim stk As New Stack(Of Integer)()
			printAllPathUtil(root, stk)
		End Sub

		Private Sub printAllPathUtil(ByVal curr As Node, ByVal stk As Stack(Of Integer))
			If curr Is Nothing Then
				Return
			End If

			stk.Push(curr.value)

			If curr.lChild Is Nothing AndAlso curr.rChild Is Nothing Then
				For Each val As Integer In stk
					Console.Write(val & " ")
				Next val
				Console.WriteLine()
				stk.Pop()
				Return
			End If

			printAllPathUtil(curr.rChild, stk)
			printAllPathUtil(curr.lChild, stk)
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

			curr.lChild = trimOutsideRange(curr.lChild, min, max)
			curr.rChild = trimOutsideRange(curr.rChild, min, max)

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
			Dim floor As Integer = Integer.MaxValue

			Do While curr IsNot Nothing
				If curr.value = val Then
					floor = curr.value
					Exit Do
				ElseIf curr.value > val Then
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

			Do While curr IsNot Nothing
				If curr.value = val Then
					ceil = curr.value
					Exit Do
				ElseIf curr.value > val Then
					ceil = curr.value
					curr = curr.lChild
				Else
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

		Public Function searchBT(ByVal value As Integer) As Boolean
			Return searchBTUtil(root, value)
		End Function

		Private Function searchBTUtil(ByVal curr As Node, ByVal value As Integer) As Boolean
			Dim left, right As Boolean
			If curr Is Nothing Then
				Return False
			End If

			If curr.value = value Then
				Return True
			End If

			left = searchBTUtil(curr.lChild, value)
			If left Then
				Return True
			End If

			right = searchBTUtil(curr.rChild, value)
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

		Public Function isBSTArray(ByVal preorder() As Integer, ByVal size As Integer) As Boolean
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
				Do While stk.Count > 0 AndAlso stk.Peek() < value
					root = stk.Pop()
				Loop
				' add current value to the stack.
				stk.Push(value)
			Next i
			Return True
		End Function


	End Class

	Public Sub Main(ByVal args() As String)
		Dim t As New Tree()
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		t.levelOrderBinaryTree(arr)
		Console.WriteLine("")
		Console.WriteLine(t.isCompleteTree())

		Console.WriteLine("")
		t.PrintBredthFirst()
		Console.WriteLine("")
		t.PrintPreOrder()
		Console.WriteLine("")
		t.PrintLevelOrderLineByLine()
		Console.WriteLine("")
		t.PrintLevelOrderLineByLine2()
		Console.WriteLine("")
		t.PrintSpiralTree()
		Console.WriteLine("")
		t.printAllPath()
		Console.WriteLine("")
		t.NthInOrder(4)
		Console.WriteLine("")
		t.NthPostOrder(4)
		Console.WriteLine("")
		t.NthPreOrder(4)
		Console.WriteLine("")
	End Sub
End Module