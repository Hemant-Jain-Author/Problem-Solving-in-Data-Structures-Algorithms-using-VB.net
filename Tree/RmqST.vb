Imports System

Public Class RmqST
	Private segArr() As Integer
	Private n As Integer

	Public Sub New(ByVal input() As Integer)
		n = input.Length
		' Height of segment tree.
		Dim x As Integer = CInt(Math.Truncate(Math.Ceiling(Math.Log(n) / Math.Log(2))))
		'Maximum size of segment tree
		Dim max_size As Integer = 2 * CInt(Math.Truncate(Math.Pow(2, x))) - 1
		' Allocate memory for segment tree
		segArr = New Integer(max_size - 1){}
		ConstructST(input, 0, n - 1, 0)
	End Sub


	Private Function ConstructST(ByVal input() As Integer, ByVal start As Integer, ByVal finish As Integer, ByVal index As Integer) As Integer
		' Store it in current node of the segment tree and return
		If start = finish Then
			segArr(index) = input(start)
			Return input(start)
		End If

		' If there are more than one elements, 
		' then traverse left and right subtrees 
		' and store the minimum of values in current node.
		Dim mid As Integer = (start + finish) \ 2
		segArr(index) = Min(ConstructST(input, start, mid, index * 2 + 1), ConstructST(input, mid + 1, finish, index * 2 + 2))
		 Return segArr(index)
	End Function

	Private Function Min(ByVal first As Integer, ByVal second As Integer) As Integer
		If first < second Then
			Return first
		Else
			Return second
		End If
	End Function

	Public Function GetMin(ByVal start As Integer, ByVal finish As Integer) As Integer
		' Check for error conditions.
		If start > finish OrElse start < 0 OrElse finish > n - 1 Then
			Console.WriteLine("Invalid Input.")
			Return Integer.MaxValue
		End If
		Return GetMinUtil(0, n - 1, start, finish, 0)
	End Function

	Private Function GetMinUtil(ByVal segStart As Integer, ByVal segEnd As Integer, ByVal queryStart As Integer, ByVal queryEnd As Integer, ByVal index As Integer) As Integer
		If queryStart <= segStart AndAlso segEnd <= queryEnd Then ' complete overlapping case.
			Return segArr(index)
		End If

		If segEnd < queryStart OrElse queryEnd < segStart Then ' no overlapping case.
			Return Integer.MaxValue
		End If

		' Segment tree is partly overlaps with the query range.
		Dim mid As Integer = (segStart + segEnd) \ 2
		Return Min(GetMinUtil(segStart, mid, queryStart, queryEnd, 2 * index + 1), GetMinUtil(mid + 1, segEnd, queryStart, queryEnd, 2 * index + 2))
	End Function

	Public Sub Update(ByVal ind As Integer, ByVal val As Integer)
		' Check for error conditions.
		If ind < 0 OrElse ind > n - 1 Then
			Console.WriteLine("Invalid Input.")
			Return
		End If

		' Update the values in segment tree
		UpdateUtil(0, n - 1, ind, val, 0)
	End Sub

	' Always min inside valid range will be returned.
	Private Function UpdateUtil(ByVal segStart As Integer, ByVal segEnd As Integer, ByVal ind As Integer, ByVal val As Integer, ByVal index As Integer) As Integer
		' Update index lies outside the range of current segment.
		' So minimum will not change.
		If ind < segStart OrElse ind > segEnd Then
			Return segArr(index)
		End If

		' If the input index is in range of this node, then update the
		' value of the node and its children

		If segStart = segEnd Then
			If segStart = ind Then ' Index value need to be updated.
				segArr(index) = val
				Return val
			Else
				Return segArr(index) ' index value is not changed.
			End If
		End If

		Dim mid As Integer = (segStart + segEnd) \ 2

		' Current node value is updated with min. 
		segArr(index) = Min(UpdateUtil(segStart, mid, ind, val, 2 * index + 1), UpdateUtil(mid + 1, segEnd, ind, val, 2 * index + 2))

		' Value of diff is propagated to the parent node.
		Return segArr(index)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {2, 3, 1, 7, 12, 5}
		Dim tree_Conflict As New RmqST(arr)
		Console.WriteLine("Min value in the range(1, 5): " & tree_Conflict.GetMin(1, 5))
		Console.WriteLine("Min value of all the elements: " & tree_Conflict.GetMin(0, arr.Length - 1))

		tree_Conflict.Update(2, -1)
		Console.WriteLine("Min value in the range(1, 5): " & tree_Conflict.GetMin(1, 5))
		Console.WriteLine("Min value of all the elements: " & tree_Conflict.GetMin(0, arr.Length - 1))

		tree_Conflict.Update(5, -2)
		Console.WriteLine("Min value in the range(0, 4): " & tree_Conflict.GetMin(0, 4))
		Console.WriteLine("Min value of all the elements: " & tree_Conflict.GetMin(0, arr.Length - 1))
	End Sub
End Class

'
'Min value in the range(1, 5): 1
'Min value of all the elements: 1
'Min value in the range(1, 5): -1
'Min value of all the elements: -1
'Min value in the range(0, 4): -1
'Min value of all the elements: -2
'