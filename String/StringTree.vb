Imports System

Public Class StringTree
	Private root As Node = Nothing

	Private Class Node
		Friend value As String
		Friend count As Integer
		Friend lChild As Node
		Friend rChild As Node
	End Class

	' Other Methods.
	Public Sub Print()
		Print(root)
	End Sub

	Private Sub Print(ByVal curr As Node) ' pre order
		If curr IsNot Nothing Then
			Console.Write(" value is ::" & curr.value)
			Console.WriteLine(" count is :: " & curr.count)
			Print(curr.lChild)
			Print(curr.rChild)
		End If
	End Sub

	Public Sub Add(ByVal value As String)
		root = Add(value, root)
	End Sub

	Private Function Add(ByVal value As String, ByVal curr As Node) As Node
		If curr Is Nothing Then
			curr = New Node()
			curr.value = value
			curr.rChild = Nothing
			curr.lChild = curr.rChild
			curr.count = 1
		Else
			Dim compare As Integer = String.CompareOrdinal(curr.value, value)
			If compare = 0 Then
				curr.count += 1
			ElseIf compare = 1 Then
				curr.lChild = Add(value, curr.lChild)
			Else
				curr.rChild = Add(value, curr.rChild)
			End If
		End If
		Return curr
	End Function

	Public Function Find(ByVal value As String) As Boolean
		Return Find(root, value)
	End Function

	Private Function Find(ByVal curr As Node, ByVal value As String) As Boolean
		If curr Is Nothing Then
			Return False
		End If
		Dim compare As Integer = String.CompareOrdinal(curr.value, value)
		If compare = 0 Then
			Return True
		Else
			If compare = 1 Then
				Return Find(curr.lChild, value)
			Else
				Return Find(curr.rChild, value)
			End If
		End If
	End Function

	Public Function Frequency(ByVal value As String) As Integer
		Return Frequency(root, value)
	End Function

	Private Function Frequency(ByVal curr As Node, ByVal value As String) As Integer
		If curr Is Nothing Then
			Return 0
		End If

		Dim compare As Integer = String.CompareOrdinal(curr.value, value)
		If compare = 0 Then
			Return curr.count
		Else
			If compare > 0 Then
				Return Frequency(curr.lChild, value)
			Else
				Return Frequency(curr.rChild, value)
			End If
		End If
	End Function

	Public Sub FreeTree()
		root = Nothing
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim tt As New StringTree()
		tt.Add("banana")
		tt.Add("apple")
		tt.Add("mango")
		Console.WriteLine("Apple Found : " & tt.Find("apple"))
		Console.WriteLine("Banana Found : " & tt.Find("banana"))
		Console.WriteLine("Grapes Found : " & tt.Find("grapes"))

	End Sub
End Class
'
'Apple Found : True
'Banana Found : True
'Grapes Found : False
'