Imports System

Public Class RBTree
	Private root As Node
	Private NullNode As Node

	Private Class Node
		Friend left, right, parent As Node
		Friend data As Integer
		Friend colour As Boolean ' true for red colour, false for black colour

		Friend Sub New(ByVal data As Integer, ByVal nullNode As Node)
			Me.data = data
			left = nullNode
			right = nullNode
			colour = True ' New node are red in colour.
			parent = nullNode
		End Sub
	End Class

	Public Sub New()
		NullNode = New Node(0, Nothing)
		NullNode.colour = False
		root = NullNode

	End Sub

	' To check whether node is of colour red or not.
	Private Function IsRed(ByVal node As Node) As Boolean
		Return If(node Is Nothing, False, (node.colour = True))
	End Function

	Private Function GetUncle(ByVal node As Node) As Node
		' If no parent or grandparent, then no uncle
		If node.parent Is NullNode OrElse node.parent.parent Is NullNode Then
			Return Nothing
		End If

		If node.parent Is node.parent.parent.left Then
			' uncle on right
			Return node.parent.parent.right
		Else
			' uncle on left
			Return node.parent.parent.left
		End If
	End Function

	' Function to right rotate subtree rooted with x
	Private Function RightRotate(ByVal x As Node) As Node
		Dim y As Node = x.left
		Dim T As Node = y.right

		' Rotation
		y.parent = x.parent
		y.right = x
		x.parent = y
		x.left = T
		If T IsNot NullNode Then
			T.parent = x
		End If

		If x Is root Then
			root = y
			Return y
		End If

		If y.parent.left Is x Then
			y.parent.left = y
		Else
			y.parent.right = y
		End If

		' Return new root
		Return y
	End Function

	' Function to left rotate subtree rooted with x
	Private Function LeftRotate(ByVal x As Node) As Node
		Dim y As Node = x.right
		Dim T As Node = y.left

		' Rotation
		y.parent = x.parent
		y.left = x
		x.parent = y
		x.right = T
		If T IsNot NullNode Then
			T.parent = x
		End If

		If x Is root Then
			root = y
			Return y
		End If

		If y.parent.left Is x Then
			y.parent.left = y
		Else
			y.parent.right = y
		End If

		' Return new root
		Return y
	End Function

	Private Function RightLeftRotate(ByVal node As Node) As Node
		node.right = RightRotate(node.right)
		Return LeftRotate(node)
	End Function

	Private Function LeftRightRotate(ByVal node As Node) As Node
		node.left = LeftRotate(node.left)
		Return RightRotate(node)
	End Function

	Private Function FindNode(ByVal data As Integer) As Node
		Dim curr As Node = root
		Do While curr IsNot NullNode
			If curr.data = data Then
				Return curr
			ElseIf curr.data > data Then
				curr = curr.left
			Else
				curr = curr.right
			End If
		Loop
		Return Nothing
	End Function

	Public Function Search(ByVal data As Integer) As Boolean
		Dim curr As Node = root
		Do While curr <> NullNode
			If curr.data = data Then
				Return True
			ElseIf curr.data > data Then
				curr = curr.left
			Else
				curr = curr.right
			End If
		Loop
		Return False
	End Function
	Public Sub PrintTree()
		PrintTree(root, "", False)
		Console.WriteLine()
	End Sub

	Private Sub PrintTree(ByVal node As Node, ByVal indent As String, ByVal isLeft As Boolean)
		If node = NullNode Then
			Return
		End If
		If isLeft Then
			Console.Write(indent & "L:")
			indent &= "|  "
		Else
			Console.Write(indent & "R:")
			indent &= "   "
		End If
		Console.WriteLine(node.data + (If(node.colour, "(Red)", "(Black)")))
		PrintTree(node.left, indent, True)
		PrintTree(node.right, indent, False)
	End Sub

	Public Sub Insert(ByVal data As Integer)
		root = Insert(root, data)
		Dim temp As Node = FindNode(data)
		FixRedRed(temp)
	End Sub

	Private Function Insert(ByVal node As Node, ByVal data As Integer) As Node
		If node = NullNode Then
			node = New Node(data, NullNode)
		ElseIf node.data > data Then
			node.left = Insert(node.left, data)
			node.left.parent = node
		ElseIf node.data < data Then
			node.right = Insert(node.right, data)
			node.right.parent = node
		End If
		Return node
	End Function

	Private Sub FixRedRed(ByVal x As Node)
		' if x is root colour it black and return
		If x = root Then
			x.colour = False
			Return
		End If

		If x.parent = NullNode OrElse x.parent.parent = NullNode Then
			Return
		End If
		' Initialize parent, grandparent, uncle
		Dim parent As Node = x.parent
		Dim grandparent As Node = parent.parent
		Dim uncle As Node = GetUncle(x)
		Dim mid As Node = Nothing

		If parent.colour = False Then
			Return
		End If

		' parent colour is red. gp is black.
		If uncle <> NullNode AndAlso uncle.colour = True Then
			' uncle and parent is red.
			parent.colour = False
			uncle.colour = False
			grandparent.colour = True
			FixRedRed(grandparent)
			Return
		End If

		' parent is red, uncle is black and gp is black.
		' Perform LR, LL, RL, RR
		If parent = grandparent.left AndAlso x = parent.left Then ' LL
			mid = RightRotate(grandparent)
		ElseIf parent = grandparent.left AndAlso x = parent.right Then ' LR
			mid = LeftRightRotate(grandparent)
		ElseIf parent = grandparent.right AndAlso x = parent.left Then ' RL
			mid = RightLeftRotate(grandparent)
		ElseIf parent = grandparent.right AndAlso x = parent.right Then ' RR
			mid = LeftRotate(grandparent)
		End If

		mid.colour = False
		mid.left.colour = True
		mid.right.colour = True
	End Sub

	Public Sub Delete(ByVal data As Integer)
		Delete(Me.root, data)
	End Sub

	Private Sub Delete(ByVal node As Node, ByVal key As Integer)
		Dim z As Node = NullNode
		Dim x, y As Node
		Do While node <> NullNode
			If node.data = key Then
				z = node
				Exit Do
			ElseIf node.data <= key Then
				node = node.right
			Else
				node = node.left
			End If
		Loop

		If z = NullNode Then
			Console.WriteLine("Couldn't FindNode key in the tree")
			Return
		End If

		y = z
		Dim yColour As Boolean = y.colour
		If z.left = NullNode Then
			x = z.right
			JoinParentChild(z, z.right)
		ElseIf z.right = NullNode Then
			x = z.left
			JoinParentChild(z, z.left)
		Else
			y = Minimum(z.right)
			yColour = y.colour
			z.data = y.data
			JoinParentChild(y, y.right)
			x = y.right
		End If

		If yColour = False Then
			If x.colour = True Then
				x.colour = False
				Return
			Else
				FixDoubleBlack(x)
			End If
		End If
	End Sub
	Private Sub FixDoubleBlack(ByVal x As Node)
		If x = root Then ' Root node.
			Return
		End If

		Dim sib As Node = Sibling(x)
		Dim parent As Node = x.parent
		If sib = NullNode Then
			' No sibling double black shifted to parent.
			FixDoubleBlack(parent)
		Else
			If sib.colour = True Then
				' Sibling colour is red.
				parent.colour = True
				sib.colour = False
				If sib.parent.left = sib Then
					' Sibling is left child.
					RightRotate(parent)
				Else
					' Sibling is right child.
					LeftRotate(parent)
				End If
				FixDoubleBlack(x)
			Else
				' Sibling colour is black
				' At least one child is red.
				If sib.left.colour = True OrElse sib.right.colour = True Then
					If sib.parent.left = sib Then
						' Sibling is left child.
						If sib.left <> NullNode AndAlso sib.left.colour = True Then
							' left left case.
							sib.left.colour = sib.colour
							sib.colour = parent.colour
							RightRotate(parent)
						Else
							' left right case.
							sib.right.colour = parent.colour
							LeftRotate(sib)
							RightRotate(parent)
						End If
					Else
						' Sibling is right child.
						If sib.left <> NullNode AndAlso sib.left.colour = True Then
							' right left case.
							sib.left.colour = parent.colour
							RightRotate(sib)
							LeftRotate(parent)
						Else
							' right right case.
							sib.right.colour = sib.colour
							sib.colour = parent.colour
							LeftRotate(parent)
						End If
					End If
					parent.colour = False
				Else
					' Both children black.
					sib.colour = True
					If parent.colour = False Then
						FixDoubleBlack(parent)
					Else
						parent.colour = False
					End If
				End If
			End If
		End If
	End Sub

	Private Function Sibling(ByVal node As Node) As Node
		' sibling null if no parent
		If node.parent = NullNode Then
			Return Nothing
		End If

		If node.parent.left = node Then
			Return node.parent.right
		End If

		Return node.parent.left
	End Function

	Private Sub JoinParentChild(ByVal u As Node, ByVal v As Node)
		If u.parent = NullNode Then
			root = v
		ElseIf u = u.parent.left Then
			u.parent.left = v
		Else
			u.parent.right = v
		End If
		v.parent = u.parent
	End Sub

	Private Function Minimum(ByVal node As Node) As Node
		Do While node.left <> NullNode
			node = node.left
		Loop
		Return node
	End Function

	Public Shared Sub Main(ByVal arg() As String)
'INSTANT VB NOTE: The variable tree was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Dim tree_Conflict As New RBTree()
		tree_Conflict.Insert(1)
		tree_Conflict.Insert(2)
		tree_Conflict.Insert(3)
		tree_Conflict.Insert(4)
		tree_Conflict.Insert(5)
		tree_Conflict.Insert(7)
		tree_Conflict.Insert(6)
		tree_Conflict.Insert(8)
		tree_Conflict.Insert(9)
		tree_Conflict.PrintTree()
		tree_Conflict.Delete(4)
		tree_Conflict.PrintTree()
		Console.WriteLine(tree_Conflict.Search(7))
		tree_Conflict.Delete(7)
		tree_Conflict.PrintTree()
	End Sub
End Class

'
'R:4(Black)
'   L:2(Red)
'   |  L:1(Black)
'   |  R:3(Black)
'   R:6(Red)
'      L:5(Black)
'      R:8(Black)
'         L:7(Red)
'         R:9(Red)
'
'R:5(Black)
'   L:2(Red)
'   |  L:1(Black)
'   |  R:3(Black)
'   R:7(Red)
'      L:6(Black)
'      R:8(Black)
'         R:9(Red)
'
'True
'R:5(Black)
'   L:2(Red)
'   |  L:1(Black)
'   |  R:3(Black)
'   R:8(Red)
'      L:6(Black)
'      R:9(Black)
'

