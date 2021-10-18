Imports System

Public Class SPLAYTree
	Private root As Node

	Private Class Node
		Friend data As Integer
		Friend left, right, parent As Node
		Friend Sub New(ByVal d As Integer, ByVal l As Node, ByVal r As Node)
			data = d
			left = l
			right = r
			parent = Nothing
		End Sub
	End Class

	Public Sub New()
		root = Nothing
	End Sub

	Public Sub PrintTree()
		PrintTree(root, "", False)
		Console.WriteLine()
	End Sub

	Private Sub PrintTree(ByVal node As Node, ByVal indent As String, ByVal isLeft As Boolean)
		If node Is Nothing Then
			Return
		End If
		If isLeft Then
			Console.Write(indent & "L:")
			indent &= "|  "
		Else
			Console.Write(indent & "R:")
			indent &= "   "
		End If

		Console.WriteLine(node.data)
		PrintTree(node.left, indent, True)
		PrintTree(node.right, indent, False)
	End Sub


	' Function to right rotate subtree rooted with x
	Private Function RightRotate(ByVal x As Node) As Node
		Dim y As Node = x.left
		Dim T As Node = y.right

		' Rotation
		y.parent = x.parent
		y.right = x
		x.parent = y
		x.left = T
		If T IsNot Nothing Then
			T.parent = x
		End If

		If y.parent IsNot Nothing AndAlso y.parent.left Is x Then
			y.parent.left = y
		ElseIf y.parent IsNot Nothing AndAlso y.parent.right Is x Then
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
		If T IsNot Nothing Then
			T.parent = x
		End If

		If y.parent IsNot Nothing AndAlso y.parent.left Is x Then
			y.parent.left = y
		ElseIf y.parent IsNot Nothing AndAlso y.parent.right Is x Then
			y.parent.right = y
		End If
		' Return new root
		Return y
	End Function

	Private Function Parent(ByVal node As Node) As Node
		If node Is Nothing OrElse node.parent Is Nothing Then
			Return Nothing
		End If
		Return node.parent
	End Function

	Private Sub Splay(ByVal node As Node)
		Dim parent, grand As Node
		Do While node IsNot root
			parent = Me.Parent(node)
			grand = Me.Parent(parent)
			If parent Is Nothing Then ' rotations had created new root, always last condition.
				root = node
			ElseIf grand Is Nothing Then ' single rotation case.
				If parent.left Is node Then
				   node = RightRotate(parent)
				Else
					node = LeftRotate(parent)
				End If
			ElseIf grand.left Is parent AndAlso parent.left Is node Then ' Zig Zig case.
				RightRotate(grand)
				node = RightRotate(parent)
			ElseIf grand.right Is parent AndAlso parent.right Is node Then ' Zag Zag case.
				LeftRotate(grand)
				node = LeftRotate(parent)
			ElseIf grand.left Is parent AndAlso parent.right Is node Then 'Zig Zag case.
				LeftRotate(parent)
				node = RightRotate(grand)
			ElseIf grand.right Is parent AndAlso parent.left Is node Then ' Zag Zig case.
				RightRotate(parent)
				node = LeftRotate(grand)
			End If
		Loop
	End Sub

	Public Function Find(ByVal data As Integer) As Boolean
		Dim curr As Node = root
		Do While curr IsNot Nothing
			If curr.data = data Then
				Splay(curr)
				Return True
			ElseIf curr.data > data Then
				curr = curr.left
			Else
				curr = curr.right
			End If
		Loop
		Return False
	End Function

	Public Sub Insert(ByVal data As Integer)
		Dim newNode As New Node(data, Nothing, Nothing)
		If root Is Nothing Then
			root = newNode
			Return
		End If

		Dim node As Node = root
		Dim parent As Node = Nothing
		Do While node IsNot Nothing
			parent = node
			If node.data > data Then
				node = node.left
			ElseIf node.data < data Then
				node = node.right
			Else
				Splay(node) ' duplicate Insertion not allowed but splaying for it.
				Return
			End If
		Loop

		newNode.parent = parent
		If parent.data > data Then
			parent.left = newNode
		Else
			parent.right = newNode
		End If
		Splay(newNode)
	End Sub

	Private Function FindMinNode(ByVal curr As Node) As Node
		Dim node As Node = curr
		If node Is Nothing Then
			Return Nothing
		End If
		Do While node.left IsNot Nothing
			node = node.left
		Loop
		Return node
	End Function

	Public Sub Delete(ByVal data As Integer)
		Dim node As Node = root
		Dim parent As Node = Nothing
		Dim nextNode As Node = Nothing
		Do While node IsNot Nothing
			If node.data = data Then
				parent = node.parent
				If node.left Is Nothing AndAlso node.right Is Nothing Then
					nextNode = Nothing
				ElseIf node.left Is Nothing Then
					nextNode = node.right
				ElseIf node.right Is Nothing Then
					nextNode = node.left
				End If

				If node.left Is Nothing OrElse node.right Is Nothing Then
					If node Is root Then
						root = nextNode
						Return
					End If
					If parent.left Is node Then
						parent.left = nextNode
					Else
						parent.right = nextNode
					End If
					If nextNode IsNot Nothing Then
						nextNode.parent = parent
					End If
					Exit Do
				End If

				Dim minNode As Node = FindMinNode(node.right)
				data = minNode.data
				node.data = data
				node = node.right

			ElseIf node.data > data Then
				parent = node
				node = node.left
			Else
				parent = node
				node = node.right
			End If
		Loop
		Splay(parent) ' Splaying for the parent of the node deleted.
	End Sub

	Public Sub PrintInOrder()
		PrintInOrder(root)
		Console.WriteLine()
	End Sub

	Private Sub PrintInOrder(ByVal node As Node) ' In order
		If node IsNot Nothing Then
			PrintInOrder(node.left)
			Console.Write(node.data & " ")
			PrintInOrder(node.right)
		End If
	End Sub

	Public Shared Sub Main(ByVal arg() As String)
		Dim tree As New SPLAYTree()
		tree.Insert(5)
		tree.Insert(4)
		tree.Insert(6)
		tree.Insert(3)
		tree.Insert(2)
		tree.Insert(1)
		tree.Insert(3)
		tree.PrintTree()

		Console.WriteLine("Value 2 found: " & tree.Find(2))
		tree.Delete(2)
		tree.Delete(5)
		tree.PrintTree()
	End Sub
End Class

'
'R:3
'   L:2
'   |  L:1
'   R:6
'      L:4
'      |  R:5
'
'Value 2 found: True
'R:4
'   L:3
'   |  L:1
'   R:6 
'

