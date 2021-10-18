
Imports System

Public Class AVLTree
	Private root As Node

	Private Class Node
		Friend data As Integer
		Friend left As Node
		Friend right As Node
		Friend Height As Integer

		Friend Sub New(ByVal d As Integer, ByVal l As Node, ByVal r As Node)
			data = d
			left = l
			right = r
			Height = 0
		End Sub
	End Class

	Public Sub New()
		root = Nothing
	End Sub

	Private Function Height(ByVal n As Node) As Integer
		If n Is Nothing Then
			Return -1
		End If
		Return n.Height
	End Function

	Private Function GetBalance(ByVal node As Node) As Integer
		Return If(node Is Nothing, 0, Height(node.left) - Height(node.right))
	End Function

	Public Sub Insert(ByVal data As Integer)
		root = Insert(root, data)
	End Sub

	Private Function Insert(ByVal node As Node, ByVal data As Integer) As Node
		If node Is Nothing Then
			Return New Node(data, Nothing, Nothing)
		End If

		If node.data > data Then
			node.left = Insert(node.left, data)
		ElseIf node.data < data Then
			node.right = Insert(node.right, data)
		Else ' Duplicate data not allowed
			Return node
		End If

		node.Height = Max(Height(node.left), Height(node.right)) + 1
		Dim balance As Integer = GetBalance(node)

		If balance > 1 Then
			If data < node.left.data Then ' Left Left Case
				Return RightRotate(node)
			End If
			If data > node.left.data Then ' Left Right Case
				Return LeftRightRotate(node)
			End If
		End If

		If balance < -1 Then
			If data > node.right.data Then ' Right Right Case
				Return LeftRotate(node)
			End If
			If data < node.right.data Then ' Right Left Case
				Return RightLeftRotate(node)
			End If
		End If
		Return node
	End Function

	' Function to right rotate subtree rooted with x
	Private Function RightRotate(ByVal x As Node) As Node
		Dim y As Node = x.left
		Dim T As Node = y.right

		' Rotation
		y.right = x
		x.left = T

		' Update Heights
		x.Height = Max(Height(x.left), Height(x.right)) + 1
		y.Height = Max(Height(y.left), Height(y.right)) + 1

		' Return new root
		Return y
	End Function

	' Function to left rotate subtree rooted with x
	Private Function LeftRotate(ByVal x As Node) As Node
		Dim y As Node = x.right
		Dim T As Node = y.left

		' Rotation
		y.left = x
		x.right = T

		' Update Heights
		x.Height = Max(Height(x.left), Height(x.right)) + 1
		y.Height = Max(Height(y.left), Height(y.right)) + 1

		' Return new root
		Return y
	End Function

	' Function to right then left rotate subtree rooted with x
	Private Function RightLeftRotate(ByVal x As Node) As Node
		x.right = RightRotate(x.right)
		Return LeftRotate(x)
	End Function

	' Function to left then right rotate subtree rooted with x
	Private Function LeftRightRotate(ByVal x As Node) As Node
		x.left = LeftRotate(x.left)
		Return RightRotate(x)
	End Function

	Public Sub Delete(ByVal data As Integer)
		root = Delete(root, data)
	End Sub

	Private Function Delete(ByVal node As Node, ByVal data As Integer) As Node
		If node Is Nothing Then
			Return Nothing
		End If

		If node.data = data Then
			If node.left Is Nothing AndAlso node.right Is Nothing Then
				Return Nothing
			ElseIf node.left Is Nothing Then
				Return node.right ' no need to modify Height
			ElseIf node.right Is Nothing Then
				Return node.left ' no need to modify Height
			Else
				Dim minNode As Node = FindMin(node.right)
				node.data = minNode.data
				node.right = Delete(node.right, minNode.data)
			End If
		Else
			If node.data > data Then
				node.left = Delete(node.left, data)
			Else
				node.right = Delete(node.right, data)
			End If
		End If

		node.Height = Max(Height(node.left), Height(node.right)) + 1
		Dim balance As Integer = GetBalance(node)

		If balance > 1 Then
			If data >= node.left.data Then ' Left Left Case
				Return RightRotate(node)
			End If
			If data < node.left.data Then ' Left Right Case
				Return LeftRightRotate(node)
			End If
		End If

		If balance < -1 Then
			If data <= node.right.data Then ' Right Right Case
				Return LeftRotate(node)
			End If
			If data > node.right.data Then ' Right Left Case
				Return RightLeftRotate(node)
			End If
		End If
		Return node
	End Function

	Private Function FindMin(ByVal curr As Node) As Node
		Dim node As Node = curr
		If node Is Nothing Then
			Return Nothing
		End If

		Do While node.left IsNot Nothing
			node = node.left
		Loop
		Return node
	End Function

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

		Console.WriteLine(node.data & "(" & node.Height & ")")
		PrintTree(node.left, indent, True)
		PrintTree(node.right, indent, False)
	End Sub

	Private Function Max(ByVal a As Integer, ByVal b As Integer) As Integer
		Return If(a > b, a, b)
	End Function

	Public Shared Sub Main(ByVal arg() As String)
		Dim t As New AVLTree()
		t.Insert(1)
		t.Insert(2)
		t.Insert(3)
		t.Insert(4)
		t.Insert(5)
		t.Insert(6)
		t.Insert(7)
		t.Insert(8)
		t.PrintTree()

'		
' R:4(3)
'   L:2(1)
'   |  L:1(0)
'   |  R:3(0)
'   R:6(2)
'	  L:5(0)
'	  R:7(1)
'		 R:8(0)
'
'		

		t.Delete(5)
		t.PrintTree()

'		
' R:4(2)
'   L:2(1)
'   |  L:1(0)
'   |  R:3(0)
'   R:7(1)
'	  L:6(0)
'	  R:8(0)
'
'	   

		t.Delete(1)
		t.PrintTree()

'		
'R:4(2)
'   L:2(1)
'   |  R:3(0)
'   R:7(1)
'	  L:6(0)
'	  R:8(0)
'
'		

		t.Delete(2)
		t.PrintTree()

'		
'R:4(2)
'   L:3(0)
'   R:7(1)
'	  L:6(0)
'	  R:8(0) 
'		
	End Sub
End Class