
Imports System

Public Class BTree
	Private root As Node ' Pointer to root node
	Private max As Integer ' Maximum degree
	Private min As Integer ' Minimum degree

	Public Sub New(ByVal dg As Integer)
		Me.root = Nothing
		Me.max = dg ' Max number of children.
		Me.min = dg \ 2 ' Min number of children.
	End Sub

	Private Class Node
		Friend n As Integer ' Current number of keys
		Friend keys() As Integer ' An array of keys
		Friend arr() As Node ' An array of child pointers
		Friend leaf As Boolean ' Is true when node is leaf. Otherwise false

		' Constructor
		Friend Sub New(ByVal leaf As Boolean, ByVal max As Integer)
			Me.n = 0
			Me.keys = New Integer(max - 1){}
			Me.arr = New Node(max){}
			Me.leaf = leaf
		End Sub
	End Class

	Public Sub PrintTree()
		PrintTree(root, "")
		Console.WriteLine()
	End Sub

	Private Sub PrintTree(ByVal node As Node, ByVal indent As String)
		If node Is Nothing Then
			Return
		End If
		Dim i As Integer
		For i = 0 To node.n - 1
			PrintTree(node.arr(i), indent & "    ")
			Console.WriteLine(indent & "key[" & i & "]:" & node.keys(i))
		Next i
		PrintTree(node.arr(i), indent & "    ")
	End Sub

	Private Sub PrintInOrder(ByVal node As Node)
		Dim i As Integer
		For i = 0 To node.n - 1
			If node.leaf = False Then
				PrintInOrder(node.arr(i))
			End If
			Console.Write(node.keys(i) & " ")
		Next i

		If node.leaf = False Then
			PrintInOrder(node.arr(i))
		End If
	End Sub

	Public Function Search(ByVal key As Integer) As Boolean
		If root Is Nothing Then
			Return False
		End If

		Return Search(root, key)
	End Function

	Private Function Search(ByVal node As Node, ByVal key As Integer) As Boolean
		Dim i As Integer = 0
		Do While i < node.n AndAlso node.keys(i) < key
			i += 1
		Loop

		' If the found key is equal to key, return this node
		If node.keys(i) = key Then
			Return True
		End If

		' If the key is not found and this is a leaf node
		If node.leaf = True Then
			Return False
		End If

		' Search in the appropriate child
		Return Search(node.arr(i), key)
	End Function

	Public Sub Insert(ByVal key As Integer)
		' If tree is empty
		If root Is Nothing Then
			' Allocate memory for root
			root = New Node(True, max)
			root.keys(0) = key ' Insert key
			root.n = 1 ' Update number of keys in root
			Return
		End If

		If root.leaf = True Then
			' Finds the location where new key can be Inserted.
			' By moving all keys greater than key to one place forward.
			Dim i As Integer = root.n - 1
			Do While i >= 0 AndAlso root.keys(i) > key
				root.keys(i + 1) = root.keys(i)
				i -= 1
			Loop

			' Insert the new key at found location
			root.keys(i + 1) = key
			root.n = root.n + 1
		Else
			Dim i As Integer = 0
			Do While i < root.n AndAlso root.keys(i) < key
				i += 1
			Loop
			Insert(root, root.arr(i), i, key)
		End If
		If root.n = max Then
			' If root contains more then allowed nodes, then tree grows in height.
			' Allocate memory for new root
			Dim rt As New Node(False, max)
			rt.arr(0) = root
			Split(rt, root, 0) ' divide the child into two and then add the median to the parent.
			root = rt
		End If
	End Sub

	' Insert a new key in this node
	' Arguments are parent, child, index of child and key.
	Private Sub Insert(ByVal parent As Node, ByVal child As Node, ByVal index As Integer, ByVal key As Integer)
		If child.leaf = True Then
			' Finds the location where new key will be Inserted 
			' by moving all keys greater than key to one place forward.
			Dim i As Integer = child.n - 1
			Do While i >= 0 AndAlso child.keys(i) > key
				child.keys(i + 1) = child.keys(i)
				i -= 1
			Loop

			' Insert the new key at found location
			child.keys(i + 1) = key
			child.n += 1
		Else
			Dim i As Integer = 0
			' Insert the node to the proper child.
			Do While i < child.n AndAlso child.keys(i) < key
				i += 1
			Loop
			Insert(child, child.arr(i), i, key) ' parent, child and index of child.
		End If

		If child.n = max Then ' More nodes than allowed.
			' divide the child into two and then add the median to the parent.
			Split(parent, child, index)
		End If
	End Sub

	Private Sub Split(ByVal parent As Node, ByVal child As Node, ByVal index As Integer)
		' Getting index of median.
'INSTANT VB WARNING: Instant VB cannot determine whether both operands of this division are integer types - if they are then you should use the VB integer division operator:
		Dim median As Integer = max / 2
		' Reduce the number of keys in child
		child.n = median

		Dim node As New Node(child.leaf, max)
		' Copy the second half keys of child to node
		Dim j As Integer = 0
		Do While median + 1 + j < max
			node.keys(j) = child.keys(median + 1 + j)
			j += 1
		Loop
		node.n = j

		' Copy the second half children of child to node
		j = 0
		Do While child.leaf = False AndAlso median + j <= max - 1
			node.arr(j) = child.arr(median + 1 + j)
			j += 1
		Loop

		' parent is going to have a new child,
		' create space of new child
		j = parent.n
		Do While j >= index + 1
			parent.arr(j + 1) = parent.arr(j)
			j -= 1
		Loop

		' Link the new child to the parent node
		parent.arr(index + 1) = node

		' A key of child will move to the parent node. 
		' Find the location of new key by moving
		' all greater keys one space forward.
		For j = parent.n - 1 To index Step -1
			parent.keys(j + 1) = parent.keys(j)
		Next j

		' Copy the middle key of child to the parent
		parent.keys(index) = child.keys(median)

		' Increment count of keys in this parent
		parent.n += 1
	End Sub

	Public Sub Remove(ByVal key As Integer)
		Remove(root, key)

		If root.n = 0 Then
			' Shrinking : If root is pointing to empty node.
			' If that node is a leaf node then root will become null.
			' Else root will point to first child of node.
			If root.leaf Then
				root = Nothing
			Else
				root = root.arr(0)
			End If
		End If
	End Sub

	Private Sub Remove(ByVal node As Node, ByVal key As Integer)
		Dim index As Integer = findKey(node, key)
		If node.leaf Then
			If index < node.n AndAlso node.keys(index) = key Then
				RemoveFromLeaf(node, index) ' Leaf node key found.
			Else
				Console.WriteLine("The key " & key & " not found.")
				Return
			End If
		Else
			If index < node.n AndAlso node.keys(index) = key Then
				RemoveFromNonLeaf(node, index) ' Internal node key found.
			Else
				Remove(node.arr(index), key)
			End If

			' All the property violation in index subtree only.
			' which include remove from leaf case too.
			If node.arr(index).n < min Then
				FixBTree(node, index)
			End If
		End If

	End Sub

	' Returns the index of first key which is greater than or equal to key.
	Private Function findKey(ByVal node As Node, ByVal key As Integer) As Integer
		Dim index As Integer = 0
		Do While index < node.n AndAlso node.keys(index) < key
			index += 1
		Loop
		Return index
	End Function

	' Remove the index key from leaf node.
	Private Sub RemoveFromLeaf(ByVal node As Node, ByVal index As Integer)
		' Move all the keys after the index position one step left.
		For i As Integer = index + 1 To node.n - 1
			node.keys(i - 1) = node.keys(i)
		Next i

		' Reduce the key count.
		node.n -= 1
		Return
	End Sub

	' Remove the index key from a non-leaf node.
	Private Sub RemoveFromNonLeaf(ByVal node As Node, ByVal index As Integer)
		Dim key As Integer = node.keys(index)

		' If the child that precedes key has at least min keys,
		' Find the predecessor 'pred' of key in the subtree rooted at index.
		' Replace key by pred and recursively delete pred in arr[index]
		If node.arr(index).n > min Then
			Dim pred As Integer = GetPred(node, index)
			node.keys(index) = pred
			Remove(node.arr(index), pred)

		' If the child that succeeds key has at least min keys,
		' Find the successor 'succ' of key in the subtree rooted at index+1.
		' Replace key by succ and recursively delete succ in arr[ index+1].
		ElseIf node.arr(index + 1).n > min Then
			Dim succ As Integer = GetSucc(node, index)
			node.keys(index) = succ
			Remove(node.arr(index + 1), succ)

		' If both left and right subtree has min number of keys.
		' Then merge left, right child along with parent key.
		' Then call Remove on the merged child.
		Else
			Merge(node, index)
			Remove(node.arr(index), key)
		End If
		Return
	End Sub

	' To get predecessor of keys[index]
	Private Function GetPred(ByVal node As Node, ByVal index As Integer) As Integer
		' Keep moving to the right most node of left subtree until we reach a leaf.
		Dim cur As Node = node.arr(index)
		Do While Not cur.leaf
			cur = cur.arr(cur.n)
		Loop

		' Return the last key of the leaf
		Return cur.keys(cur.n - 1)
	End Function

	' To get successor of keys[index]
	Private Function GetSucc(ByVal node As Node, ByVal index As Integer) As Integer
		' Keep moving to the left most node of right subtree until we reach a leaf
		Dim cur As Node = node.arr(index + 1)
		Do While Not cur.leaf
			cur = cur.arr(0)
		Loop

		' Return the first key of the leaf
		Return cur.keys(0)
	End Function

	' Make sure that the node have at least min number of keys
	Private Sub FixBTree(ByVal node As Node, ByVal index As Integer)
		' If the left sibling has more than min keys.
		If index <> 0 AndAlso node.arr(index - 1).n > min Then
			BorrowFromLeft(node, index)
		' If the right sibling has more than min keys.
		ElseIf index <> node.n AndAlso node.arr(index + 1).n > min Then
			BorrowFromRight(node, index)
		' If both siblings has less than min keys.
		' When right sibling exist always merge with the right sibling.
		' When right sibling does not exist then merge with left sibling.
		Else
			If index <> node.n Then
				Merge(node, index)
			Else
				Merge(node, index - 1)
			End If
		End If
	End Sub

		' Move a key from parent to right and left to parent.
	Private Sub BorrowFromLeft(ByVal node As Node, ByVal index As Integer)
		Dim child As Node = node.arr(index)
		Dim sibling As Node = node.arr(index - 1)

		' Moving all key in child one step forward.
		For i As Integer = child.n - 1 To 0 Step -1
			child.keys(i + 1) = child.keys(i)
		Next i

		' Move all its child pointers one step forward.
		Dim i As Integer = child.n
		Do While Not child.leaf AndAlso i >= 0
			child.arr(i + 1) = child.arr(i)
			i -= 1
		Loop

		' Setting child's first key equal to of the current node.
		child.keys(0) = node.keys(index - 1)

		' Moving sibling's last child as child's first child.
		If Not child.leaf Then
			child.arr(0) = sibling.arr(sibling.n)
		End If

		' Moving the key from the sibling to the parent
		node.keys(index - 1) = sibling.keys(sibling.n - 1)

		' Increase child key count and decrease sibling key count.
		child.n += 1
		sibling.n -= 1

		Return
	End Sub

	' Move a key from parent to left and right to parent.
	Private Sub BorrowFromRight(ByVal node As Node, ByVal index As Integer)
		Dim child As Node = node.arr(index)
		Dim sibling As Node = node.arr(index + 1)

		' node key is Inserted as the last key in child.
		child.keys(child.n) = node.keys(index)

		' Sibling's first child is Inserted as the last child of child.
		If Not (child.leaf) Then
			child.arr((child.n) + 1) = sibling.arr(0)
		End If

		'First key from sibling is Inserted into node.
		node.keys(index) = sibling.keys(0)

		' Moving all keys in sibling one step left
		For i As Integer = 1 To sibling.n - 1
			sibling.keys(i - 1) = sibling.keys(i)
		Next i

		' Moving the child pointers one step behind
		Dim i As Integer = 1
		Do While Not sibling.leaf AndAlso i <= sibling.n
			sibling.arr(i - 1) = sibling.arr(i)
			i += 1
		Loop

		' Increase child key count and decrease sibling key count.
		child.n += 1
		sibling.n -= 1

		Return
	End Sub

	' Merge node's children at index and index+1.
	Private Sub Merge(ByVal node As Node, ByVal index As Integer)
		Dim left As Node = node.arr(index)
		Dim right As Node = node.arr(index + 1)
		Dim start As Integer = left.n
		' Adding a key from node to the left child.
		left.keys(start) = node.keys(index)

		' Copying the keys from right to left.
		For i As Integer = 0 To right.n - 1
			left.keys(start + 1 + i) = right.keys(i)
		Next i

		' Copying the child pointers from right to left.
		Dim i As Integer = 0
		Do While Not left.leaf AndAlso i <= right.n
			left.arr(start + 1 + i) = right.arr(i)
			i += 1
		Loop


		' Moving all keys after  index in the current node one step forward.
		For i As Integer = index + 1 To node.n - 1
			node.keys(i - 1) = node.keys(i)
		Next i

		' Moving the child pointers after (index+1) in the current node one step forward.
		For i As Integer = index + 2 To node.n
			node.arr(i - 1) = node.arr(i)
		Next i

		' Updating the key count of child and the current node
		left.n += right.n + 1
		node.n -= 1
		Return
	End Sub

	Public Shared Sub Main(ByVal arg() As String)
		Dim t As New BTree(3) ' A B-Tree with max key 3
		t.Insert(1)
		t.Insert(2)
		t.Insert(3)
		t.Insert(4)
		t.Insert(5)
		t.Insert(6)
		t.Insert(7)
		t.Insert(8)
		t.Insert(9)
		t.Insert(10)
		t.PrintTree()
		Console.WriteLine("6 : " & (If(t.Search(6) = True, "Present", "Not Present")))
		Console.WriteLine("11 : " & (If(t.Search(11) = True, "Present", "Not Present")))
		t.Remove(6)
		t.Remove(3)
		t.Remove(7)
		t.PrintTree()
	End Sub
End Class
'
'        key[0]:1
'    key[0]:2
'        key[0]:3
'key[0]:4
'        key[0]:5
'    key[0]:6
'        key[0]:7
'    key[1]:8
'        key[0]:9
'        key[1]:10
'
'6 : Present
'11 : Not Present
'
'    key[0]:1
'    key[1]:2
'key[0]:4
'    key[0]:5
'key[1]:8
'    key[0]:9
'    key[1]:10
'
