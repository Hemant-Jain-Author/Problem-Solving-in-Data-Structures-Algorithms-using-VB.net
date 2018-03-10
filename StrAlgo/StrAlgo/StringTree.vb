Imports System

Public Class StringTree
	Friend Class Node
		Friend value As String
		Friend count As Integer
		Friend lChild As Node
		Friend rChild As Node
	End Class
	Friend root As Node = Nothing
	'Other Methods.



	Public Sub print()
		print(root)
	End Sub

	Private Sub print(ByVal curr As Node) ' pre order
		If curr IsNot Nothing Then
			Console.Write(" value is ::" & curr.value)
			Console.WriteLine(" count is :: " & curr.count)
			print(curr.lChild)
			print(curr.rChild)
		End If
	End Sub

	Public Sub insert(ByVal value As String)
		root = insert(value, root)
	End Sub

	Friend Function insert(ByVal value As String, ByVal curr As Node) As Node
		Dim compare As Integer
		If curr Is Nothing Then
			curr = New Node()
			curr.value = value
			curr.rChild = Nothing
			curr.lChild = Nothing
			curr.count = 1
		Else
			compare = curr.value.CompareTo(value)
			If compare = 0 Then
				curr.count += 1
			ElseIf compare = 1 Then
				curr.lChild = insert(value, curr.lChild)
			Else
				curr.rChild = insert(value, curr.rChild)
			End If
		End If
		Return curr
	End Function

	Friend Sub freeTree()
		root = Nothing
	End Sub

	Friend Function find(ByVal value As String) As Boolean
		Dim ret As Boolean = find(root, value)
		Console.WriteLine("Find " & value & " Return " & ret)
		Return ret
	End Function

	Friend Function find(ByVal curr As Node, ByVal value As String) As Boolean
		Dim compare As Integer
		If curr Is Nothing Then
			Return False
		End If
		compare = curr.value.CompareTo(value)
		If compare = 0 Then
			Return True
		Else
			If compare = 1 Then
				Return find(curr.lChild, value)
			Else
				Return find(curr.rChild, value)
			End If
		End If
	End Function

	Friend Function frequency(ByVal value As String) As Integer
		Return frequency(root, value)

	End Function

	Friend Function frequency(ByVal curr As Node, ByVal value As String) As Integer
		Dim compare As Integer
		If curr Is Nothing Then
			Return 0
		End If

		compare = curr.value.CompareTo(value)
		If compare = 0 Then
			Return curr.count
		Else
			If compare > 0 Then
				Return frequency(curr.lChild, value)
			Else
				Return frequency(curr.rChild, value)
			End If
		End If
	End Function
	Public Shared Sub Main(ByVal args() As String)
		Dim tt As New StringTree()
		tt.insert("apple")
		tt.insert("banana")
		tt.insert("apple")

		Console.WriteLine(ControlChars.Lf & "Search results for apple, banana and mango :" & ControlChars.Lf)
		Console.WriteLine("frequency returned :: " & tt.frequency("apple"))
		Console.WriteLine("frequency returned :: " & tt.frequency("banana"))
		Console.WriteLine("frequency returned :: " & tt.frequency("mango"))
	End Sub

End Class
