Imports System

Public Class SegmentTree
	Private segArr() As Integer
	Private size As Integer

	Public Sub New(ByVal input() As Integer)
		size = input.Length
		' Height of segment tree.
		Dim x As Integer = CInt(Math.Truncate(Math.Ceiling(Math.Log(size) / Math.Log(2))))
		'Maximum size of segment tree
		Dim max_size As Integer = 2 * CInt(Math.Truncate(Math.Pow(2, x))) - 1
		' Allocate memory for segment tree
		segArr = New Integer(max_size - 1){}
		ConstructST(input, 0, size - 1, 0)
	End Sub


	Private Function ConstructST(ByVal input() As Integer, ByVal start As Integer, ByVal finish As Integer, ByVal index As Integer) As Integer
		' Store it in current node of the segment tree and return
		If start = finish Then
			segArr(index) = input(start)
			Return input(start)
		End If

		' If there are more than one elements, 
		' then traverse left and right subtrees 
		' and store the sum of values in current node.
		Dim mid As Integer = (start + finish) \ 2
		segArr(index) = ConstructST(input, start, mid, index * 2 + 1) + ConstructST(input, mid + 1, finish, index * 2 + 2)
		 Return segArr(index)
	End Function

	Public Function GetSum(ByVal start As Integer, ByVal finish As Integer) As Integer
		' Check for error conditions.
		If start > finish OrElse start < 0 OrElse finish > size - 1 Then
			Console.WriteLine("Invalid Input.")
			Return -1
		End If
		Return GetSumUtil(0, size - 1, start, finish, 0)
	End Function

	Private Function GetSumUtil(ByVal segStart As Integer, ByVal segEnd As Integer, ByVal queryStart As Integer, ByVal queryEnd As Integer, ByVal index As Integer) As Integer
		If queryStart <= segStart AndAlso segEnd <= queryEnd Then ' complete overlapping case.
			Return segArr(index)
		End If

		If segEnd < queryStart OrElse queryEnd < segStart Then ' no overlapping case.
			Return 0
		End If

		' Segment tree is partly overlaps with the query range.
		Dim mid As Integer = (segStart + segEnd) \ 2
		Return GetSumUtil(segStart, mid, queryStart, queryEnd, 2 * index + 1) + GetSumUtil(mid + 1, segEnd, queryStart, queryEnd, 2 * index + 2)
	End Function

	Public Sub [Set](ByVal arr() As Integer, ByVal ind As Integer, ByVal val As Integer)
		' Check for error conditions.
		If ind < 0 OrElse ind > size - 1 Then
			Console.WriteLine("Invalid Input.")
			Return
		End If

		arr(ind) = val

		' Set new value in segment tree
		SetUtil(0, size - 1, ind, val, 0)
	End Sub

	' Always diff will be returned.
	Private Function SetUtil(ByVal segStart As Integer, ByVal segEnd As Integer, ByVal ind As Integer, ByVal val As Integer, ByVal index As Integer) As Integer
		' set index lies outside the range of current segment.
		' So diff to its parent node will be zero.
		If ind < segStart OrElse ind > segEnd Then
			Return 0
		End If

		' If the input index is in range of this node, then set the
		' value of the node and its children
		Dim diff As Integer = 0
		If segStart = segEnd Then
			If segStart = ind Then ' Index that need to be set.
				diff = val - segArr(index)
				segArr(index) = val
				Return diff
			Else
				Return 0
			End If
		End If

		Dim mid As Integer = (segStart + segEnd) \ 2
		diff = SetUtil(segStart, mid, ind, val, 2 * index + 1) + SetUtil(mid + 1, segEnd, ind, val, 2 * index + 2)

		' Current node value is set with diff. 
		segArr(index) = segArr(index) + diff

		' Value of diff is propagated to the parent node.
		Return diff
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 4, 8, 16, 32, 64}
		Dim tree_Conflict As New SegmentTree(arr)
		Console.WriteLine("Sum of values in the range(0, 3): " & tree_Conflict.GetSum(1, 3))
		Console.WriteLine("Sum of values of all the elements: " & tree_Conflict.GetSum(0, arr.Length - 1))

		tree_Conflict.Set(arr, 1, 10)
		Console.WriteLine("Sum of values in the range(0, 3): " & tree_Conflict.GetSum(1, 3))
		Console.WriteLine("Sum of values of all the elements: " & tree_Conflict.GetSum(0, arr.Length - 1))
	End Sub
End Class

'
'Sum of values in the range(0, 3): 14
'Sum of values of all the elements: 127
'Sum of values in the range(0, 3): 22
'Sum of values of all the elements: 135
'