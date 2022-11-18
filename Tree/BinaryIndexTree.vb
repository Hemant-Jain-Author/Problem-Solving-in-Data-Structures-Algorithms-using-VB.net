Imports System

Public Class BinaryIndexTree
	Private BIT() As Integer
	Private size As Integer

	Public Sub New(ByVal arr() As Integer)
		size = arr.Length
		BIT = New Integer(size) {}
		For i As Integer = 0 To size
			BIT(i) = 0
		Next i

		' Populating bit. 
		For i As Integer = 0 To size - 1
			Update(i, arr(i))
		Next i
	End Sub

	Public Sub Assign(ByVal arr() As Integer, ByVal index As Integer, ByVal val As Integer)
		Dim diff As Integer = val - arr(index)
		arr(index) = val

		' Difference is propagated.
		Update(index, diff)
	End Sub

	Private Sub Update(ByVal index As Integer, ByVal val As Integer)
		' Index in bit is 1 more than the input array.
		index = index + 1

		' Traverse to ancestors of nodes.
		Do While index <= size
			' Add val to current node of Binary Index Tree.
			BIT(index) += val

			' Next element which need to store val.
			index += index And (-index)
		Loop
	End Sub

	' Range sum in the range start to end.
	Public Function RangeSum(ByVal start As Integer, ByVal finish As Integer) As Integer
		' Check for error conditions.
		If start > finish OrElse start < 0 OrElse finish > size - 1 Then
			Console.WriteLine("Invalid Input.")
			Return -1
		End If

		Return PrefixSum(finish) - PrefixSum(start - 1)
	End Function

	' Prefix sum in the range 0 to index.
	Public Function PrefixSum(ByVal index As Integer) As Integer
		Dim sum As Integer = 0
		index = index + 1

		' Traverse ancestors of Binary Index Tree nodes.
		Do While index > 0
			' Add current element to sum.
			sum += BIT(index)

			' Parent index calculation.
			index -= index And (-index)
		Loop
		Return sum
	End Function


	' Main function
	Public Shared Sub Main(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}
		Dim tree As New BinaryIndexTree(arr)

		Console.WriteLine("Sum of elements in range(0, 5): " & tree.PrefixSum(5))
		Console.WriteLine("Sum of elements in range(2, 5): " & tree.RangeSum(2, 5))

		' Assign fourth element to 10.
		tree.Assign(arr, 3, 10)

		' Find sum after the value is Updated
		Console.WriteLine("Sum of elements in range(0, 5): " & tree.PrefixSum(5))
	End Sub
End Class

'
'Sum of elements in range(0, 5): 21
'Sum of elements in range(2, 5): 18
'Sum of elements in range(0, 5): 27
'