Imports System
public Class FenWickTree
	Private size As Integer
	Private sum() As Integer

	Public Sub New(ByVal input() As Integer, ByVal n As Integer)
		size = n
		sum = New Integer(size){}
		For i As Integer = 0 To n - 1
			add(i, input(i))
		Next i
	End Sub

	Public Sub add(ByVal index As Integer, ByVal val As Integer)
		index += 1
		Do While index <= size
			sum(index) += val
			index += index And (-index) ' Parent is first set bit grater then the index.
		Loop
	End Sub

	Public Function getPrefixSum(ByVal index As Integer) As Integer
		Dim total As Integer = 0
		index += 1
		Do While index>0
			total += sum(index)
			index -= index And (-index)
		Loop
		Return total
	End Function
End Class

public Class InventoryManager
	Private tree As FenWickTree

	Public Sub New(ByVal size As Integer)

		Dim arr(size - 1) As Integer
		tree = New FenWickTree(arr, size)
	End Sub

	Public Sub AddSupply(ByVal bucket As Integer, ByVal delta As Integer)
		tree.add(bucket, delta)
	End Sub

	Public Sub AddDemand(ByVal bucket As Integer, ByVal delta As Integer)
		tree.add(bucket, -1*delta)
	End Sub

	Public Function GetInventory(ByVal bucket As Integer) As Integer
		Return tree.getPrefixSum(bucket)
	End Function
End Class

' public Class Program
' 	Shared Sub Main(ByVal args() As String)
' 		Dim im As New InventoryManager(10)
' 		im.AddSupply(2, 50)

' 		Console.WriteLine(im.GetInventory(6))
' 		im.AddDemand(3, 25)
' 		Console.WriteLine(im.GetInventory(6))
' 		im.AddDemand(2, 30)
' 		Console.WriteLine(im.GetInventory(6))
' 	End Sub
' End Class

public Class Program
  	Shared Sub Main(ByVal args() As String)
		Dim input() As Integer = {2, 1, 1, 3, 2, 3, 4, 5, 6, 7, 8, 9}
		Dim size As Integer = input.Length
		Dim tree As New FenWickTree(input, size)

		Console.WriteLine("Sum of elements in arr[0..5] is " & tree.getPrefixSum(5))

		tree.add(3, 6)

		Console.WriteLine("Sum of elements in arr[0..5] after update is " & tree.getPrefixSum(5))


  	End Sub
End Class